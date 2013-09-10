using Content.Sync.Appacitive;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Content.Sync.Fixtures
{
    [TestClass]
    public static class TestInitialize
    {
        [AssemblyInitialize]
        public static void Initialize(TestContext context)
        {
            Storage.Initialize();
        }
    }
}
