using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Content.Sync.Clarifi
{
    class FailedWorkItemIterator : IWorkItemIterator
    {
        public FailedWorkItemIterator(string tenantId)
        {
            this.TenantId = tenantId;
        }

        public string TenantId { get; private set; }

        public IRetryLog RetryDb { get; set; }

        public async Task<WorkItem> GetNextItemAsync()
        {
            return await this.RetryDb.GetNextFailedItemAsync(this.TenantId);
        }
    }
}
