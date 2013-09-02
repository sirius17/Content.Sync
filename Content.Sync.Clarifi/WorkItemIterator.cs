using Content.Sync.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Content.Sync.Clarifi
{
    public class WorkItemIterator : IWorkItemIterator
    {
        public WorkItemIterator(string supplierFamily, long revision)
        {
            this.SupplierFamily = supplierFamily;
            this.RevisionState = new RevisionState(supplierFamily, revision);
        }

        public string SupplierFamily { get; private set; }

        public RevisionState RevisionState { get; set; }

        public IWorkItemDb WorkItemDb { get; set; }

        public async Task<WorkItem> GetNextItemAsync()
        {
            var revision = await this.RevisionState.GetNextRevisionAsync();
            return await this.WorkItemDb.GetNextItemAsync(AppContext.Current.TenantId, this.SupplierFamily, revision);
        }
    }
}
