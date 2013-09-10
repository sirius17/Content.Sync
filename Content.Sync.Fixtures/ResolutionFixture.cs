using Content.Sync.Appacitive;
using Content.Sync.Clarifi;
using Content.Sync.Infrastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Content.Sync.Fixtures
{
    [TestClass]
    public class ResolutionFixture
    {
        [TestMethod]
        public void CommandFactoryResolutionTest()
        {
            var factory = ObjectBuilder.Build<IWorkItemCommandFactory>(typeof(HotelWorkItem).Name);
            Assert.IsTrue(factory is HotelWorkItemCommandFactory);

            factory = ObjectBuilder.Build<IWorkItemCommandFactory>(typeof(MasterWorkItem).Name);
            Assert.IsTrue(factory is MasterWorkItemCommandFactory);
        }

        [TestMethod]
        public void AppacitiveModuleResolutionTest()
        {
            var syncDb = ObjectBuilder.Build<ISyncDb>();
            Assert.IsTrue(syncDb is SyncDb);

            var hotelWorkItemDb = ObjectBuilder.Build<IHotelWorkItemDb>();
            Assert.IsTrue(hotelWorkItemDb is WorkItemDb);
        }
    }
}
