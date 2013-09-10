using Content.Sync.Clarifi;
using Content.Sync.ErrorSpace;
using Content.Sync.Infrastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Content.Sync.Fixtures
{
    [TestClass]
    public class MasterWorkItemCommandFactoryFixture
    {
        [TestMethod]
        [ExpectedException(typeof(InvalidParameterException))]
        public void NullWorkItemShouldThrowTest()
        {
            IWorkItemCommandFactory commandFactory = new MasterWorkItemCommandFactory();
            var command = commandFactory.BuildCommand(null);
            Assert.Fail("Build command with null input did not throw.");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidParameterException))]
        public void NonHotelWorkItemInputShouldThrowTest()
        {
            IWorkItemCommandFactory commandFactory = new MasterWorkItemCommandFactory();
            var command = commandFactory.BuildCommand(new TestWorkItem());
            Assert.Fail("Build command with non hotelworkitem input did not throw.");
        }

        [TestMethod]
        public void MasterWorkItemInputShouldBuildOnDataTypeAndChangeTypeTest()
        {
            var dataType = Unique.NewString;
            var workItem = new MasterWorkItem() { Schema = dataType, ChangeType = ChangeType.Updated };
            var command = new Mock<IWorkItemCommand>().Object;
            try
            {
                var key = string.Format("{0}.{1}", dataType, "Updated");
                ObjectBuilder.RegisterInstance<IWorkItemCommand>(command, key);
                IWorkItemCommandFactory commandFactory = new MasterWorkItemCommandFactory();
                var cmd = commandFactory.BuildCommand(workItem);
                Assert.IsTrue (cmd == command, "Incorrect command built by the factory for the given workitem.");
            }
            finally
            {
                ObjectBuilder.Reset();
            }
        }

    }

    
}
