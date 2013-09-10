using Content.Sync.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Content.Sync.Clarifi
{
    public class ModuleInitializer : IContainerInitializer
    {
        public void Initialize(IDependencyContainer container)
        {
            container
                .RegisterInstance<IWorkItemCommandFactory>(new  HotelWorkItemCommandFactory(), typeof(HotelWorkItem).Name)
                .RegisterInstance<IWorkItemCommandFactory>(new MasterWorkItemCommandFactory(), typeof(MasterWorkItem).Name)
                ;
        }
    }
}
