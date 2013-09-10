using Content.Sync.Clarifi;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Content.Sync.Fixtures
{
    [TestClass]
    public class SyncTaskFixture
    {

        //[TestMethod]
        //public async Task RegularIterationTest()
        //{
        //    int count = 0;
        //    var task = Task.FromResult<WorkItem>( new WorkItem() { DataType = "hotel", HotelArticleId = "1", HotelId = "2", Revision = 3, SupplierFamily = "Pegasus", DeploymentId = "4" }); 
        //    var iterator = new Mock<IWorkItemIterator>();
        //    iterator.Setup(it => it.GetNextItemAsync()).Returns(task).Callback( () => count++);
        //    var syncTask = new SyncBot( iterator.Object );
        //    var cancellationSource = new CancellationTokenSource();
        //    var running = syncTask.Run(new BotSettings()
        //    {
        //        MinDelayInSeconds = 1,
        //        MaxDelayInSeconds = 10,
        //        SupplierFamily = "Pegasus",
        //        InitialRevision = 1
        //    }, cancellationSource.Token);

        //    // Wait for 4 seconds
        //    await Task.Delay(4000).ContinueWith( t => cancellationSource.Cancel());
        //    running.Wait();
        //    // Iterator should have been called atleast 3-4 times
        //    Console.WriteLine("Iterator called {0} times.", count);
        //    iterator.Verify(it => it.GetNextItemAsync(), Times.Between(3,5, Range.Inclusive));
        //}
    }
}
