using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Content.Sync.Clarifi
{
    public class SyncSettings
    {
        public string TenantId { get; set; }

        public string SupplierFamily { get; set; }

        public long InitialRevision { get; set; }

        public int DelayStepSizeInSeconds { get; set; }

        public int MaxDelayInSeconds { get; set; }
    }
}
