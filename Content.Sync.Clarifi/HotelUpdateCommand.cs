using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Content.Sync.Clarifi
{
    public abstract class HotelUpdateCommand : IWorkItemCommand
    {
        public async Task Execute(WorkItem item, CancellationToken cancellationToken)
        {
            await ProcessHotelWorkItem(item, cancellationToken);
        }

        protected abstract Task ProcessHotelWorkItem( WorkItem workItem, CancellationToken cancellationToken );

        
    }
}
