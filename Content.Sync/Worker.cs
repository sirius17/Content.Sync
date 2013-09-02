using Content.Sync.Interfaces;
using Content.Sync.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Content.Sync
{
    /// <summary>
    /// Represents the worker class.
    /// Each worker class is responsible for downloading the content for a given
    /// tenant and supplier. Each worker runs of an iterator that provides a single work 
    /// for the given worker in each iteration.
    /// </summary>
    public class Worker
    {
        public IWorkItemSource Source { get; set; }
        private int _workerState = WorkerState.Stopped;
        private CancellationTokenSource _tokenSource = null;
        private ManualResetEventSlim _waitHandle = null;
        public void Start()
        {
            // Specification
            // To make calling Start multiple times a safe call, we use a worker state
            // to atomically track the state of the worker. Only a single thread can 
            // take ownership of starting the worker. All subsequent threads would 
            // simply return as the worker is already started.
            
            bool isAlreadyStarted = Interlocked.CompareExchange(ref _workerState, WorkerState.Starting, WorkerState.Stopped) != WorkerState.Stopped;
            if (isAlreadyStarted == false)
            {
                _waitHandle = new ManualResetEventSlim(false);
                _tokenSource = new CancellationTokenSource();
                this.StartWork(_tokenSource.Token);
                _workerState = WorkerState.Started;
            }
        }

        private async Task StartWork(CancellationToken cancellationToken)
        {
            // Specification
            // Until a cancellation is requested, continue iterating thru the work source.
            // and execute the work item one at a time. When cancellation is requested,
            // then set the waitHandle to signal that execution has stopped.
            try
            {
                while (cancellationToken.IsCancellationRequested == false)
                {
                    var work = await this.Source.GetNextTaskAsync();
                    await work.Do();
                }
            }
            finally
            {
                // Signal the wait handle to indicate that the work has stopped.
                _waitHandle.Set();
            }
        }

        /// <summary>
        /// Stops the worker incase it is running. Calling this multiple times in quick successing will throw. 
        /// </summary>
        /// <param name="timeoutInMs">Timeout to wait for the worker to stop. The default value -1 will block perpetually.</param>
        /// <returns>Will return true incase the worker stops successfully within the specified timeout.</returns>
        public bool Stop(int timeoutInMs = -1)
        {
            // Specification:
            // If the worker is already stopped then ignore.
            // Incase the worker is running, then signal cancellation via the cancellation token.
            // Then block on the wait handle which will be signalled when the worker has stopped running.
            // Incase the worker is in the stopping state, then throw ?

            if (_workerState == WorkerState.Stopped) return true;
            bool isAlreadyCancelling = Interlocked.CompareExchange(ref _workerState, WorkerState.Stopping, WorkerState.Started) != WorkerState.Started;
            if (isAlreadyCancelling == true) throw new Exception("Stop already requested on worker.");
            
            _tokenSource.Cancel();
            bool result = false;
            if (timeoutInMs == -1)
            {
                _waitHandle.Wait();
                result = true;
            }
            else
            {
                result = _waitHandle.Wait(timeoutInMs);
            }
            _tokenSource.Dispose();
            _tokenSource = null;
            _waitHandle.Dispose();
            _waitHandle = null;
            _workerState = WorkerState.Stopped;
            return result;
        }

        
    }
}
