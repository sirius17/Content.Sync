using Content.Sync.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Content.Sync.Clarifi
{
    public class HotelWorkItemIterator : IWorkItemIterator
    {
        public HotelWorkItemIterator(string supplierFamily, long revision)
        {
            this.SupplierFamily = supplierFamily;
            _lastProcessedRevision = revision;
        }

        [Dependency]
        public IHotelWorkItemDb Db { get; set; }
         
        public string SupplierFamily { get; private set; }

        private long _lastProcessedRevision;

        public async Task<WorkItem> GetNextItemAsync()
        {
            var workItem = await this.Db.GetNextItemAsync(this.SupplierFamily, _lastProcessedRevision);
            if (workItem != null)
                _lastProcessedRevision = workItem.Revision;
            return workItem;
        }
    }
}
