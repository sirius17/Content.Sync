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
            if (item is HotelWorkItem == false)
                throw new ErrorSpace.InvalidParameterException("Workitem must be of type HotelWorkItem.");
            await ProcessHotelWorkItem(item as HotelWorkItem, cancellationToken);
        }

        protected abstract Task ProcessHotelWorkItem( HotelWorkItem workItem, CancellationToken cancellationToken );

        
    }
}
