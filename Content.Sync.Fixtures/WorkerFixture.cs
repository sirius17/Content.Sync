using Content.Sync.Infrastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Content.Sync.Fixtures
{
    [TestClass]
    public class WorkerFixture
    {
        [TestMethod]
        public void WorkerLifetimeTest()
        {   
            var worker = new Worker("test", LoopForever);
            worker.Start();
            Assert.IsTrue(worker.WorkerState == WorkerState.Started);
            worker.Stop();
            Assert.IsTrue(worker.WorkerState == WorkerState.Stopped);
        }

        private async Task LoopForever(CancellationToken token)
        {
            while (token.IsCancellationRequested == false)
                await Task.Delay(1000);
        }

    }
}
