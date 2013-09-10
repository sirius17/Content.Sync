using Content.Sync.Clarifi;
using Content.Sync.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Content.Sync.Appacitive
{
    public class ModuleInitializer : IContainerInitializer
    {
        public void Initialize(IDependencyContainer container)
        {
            container
                .RegisterInstance<ISyncDb>(new SyncDb())
                .RegisterInstance<IHotelWorkItemDb>(new WorkItemDb())
                ;

        }
    }
}
