using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Content.Sync.Clarifi
{
    public interface IHotelWorkItemDb
    {
        Task<WorkItem> GetNextItemAsync(string supplierFamily, long lastProcessedRevision);
    }
}
