using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Content.Sync.Infrastructure
{
    /// <summary>
    /// Represents the worker process that can be used to do some work.
    /// Work is represented by a delegate (with cancellation support) which returns a future
    /// to track the progress of work and its state.
    /// </summary>
    public class Worker
    {
        public Worker(string id, Func<CancellationToken, Task> taskToRun)
        {
            this.Id = id;
            this.Run = taskToRun;   
        }

        private Func<CancellationToken, Task> Run { get; set; }
        private int _workerState = (int)WorkerState.Stopped;
        private Task TaskToRun { get; set; }
        private CancellationTokenSource TaskCancellation { get; set; }

        public string Id { get; private set; }

        public WorkerState WorkerState
        {
            get
            {
                return (WorkerState)_workerState;
            }
        }

        public void Start()
        {
            if( Interlocked.CompareExchange(ref _workerState, (int)WorkerState.Starting, (int)WorkerState.Stopped) == (int)WorkerState.Stopped)
            {
                this.TaskCancellation = new CancellationTokenSource();
                this.TaskToRun = this.Run(this.TaskCancellation.Token);
                _workerState = (int)WorkerState.Started;
            }
            else 
                throw new Exception("Worker is already running.");
        }

        public void Stop()
        {
            if (_workerState == (int)WorkerState.Stopped)
                return;
            if (Interlocked.CompareExchange(ref _workerState, (int)WorkerState.Started, (int)WorkerState.Stopping) == (int)WorkerState.Started)
            {
                this.TaskCancellation.Cancel();
                this.TaskToRun.Wait();
                _workerState = (int)WorkerState.Stopped;
                this.TaskToRun.Dispose();
                this.TaskToRun = null;
                this.TaskCancellation.Dispose();
                this.TaskCancellation = null;
            }
        }
    }
}
