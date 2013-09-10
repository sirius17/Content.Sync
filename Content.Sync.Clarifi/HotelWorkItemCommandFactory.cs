using Content.Sync.ErrorSpace;
using Content.Sync.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Content.Sync.Clarifi
{
    public class HotelWorkItemCommandFactory : IWorkItemCommandFactory
    {
        public IWorkItemCommand BuildCommand(WorkItem item)
        {
            /* 
             * Specification:
             * Only workitem type supported is the hotel work item.
             * Incase null then throw.. 
             * Incase unsupported type then throw
             * Incase hotel work item then get command mapped corresponding to the data type + change type.
            */
            if (item == null)
                throw new InvalidParameterException("Work item cannot be null.");
            if (item is HotelWorkItem == false )
                throw new InvalidParameterException(string.Format("{0} is not a supported work item type for HotelWorkItemCommandFactory.", item == null ? "null" : item.GetType().Name));
            var hotelWorkItem = item as HotelWorkItem;
            var key = string.Format("{0}.{1}", hotelWorkItem.DataType, hotelWorkItem.ChangeType);
            return ObjectBuilder.BuildIfDefined<IWorkItemCommand>(key);
        }
    }
}
