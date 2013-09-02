using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Content.Sync.Clarifi
{
    public interface IWorkItemDb
    {
        Task<WorkItem> GetNextItemAsync(string tenantId, string supplierFamily, long lastProcessedRevision);
    }
}
