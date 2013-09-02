using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Content.Sync.Clarifi
{
    public class RevisionState
    {
        public RevisionState(string supplierFamily, long initialRevision)
        {
            this.SupplierFamily = supplierFamily;
            this.Revision = initialRevision;
        }

        public IRevisionDb Db {get; set;}

        private string SupplierFamily { get; set; }
        
        private long Revision { get; set; }

        public async Task<long> GetNextRevisionAsync()
        {
            var current = this.Revision;
            this.Revision = await this.Db.GetNextRevisionAsync(current);
            return current;
        }
    }
}
