using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Content.Sync.Clarifi
{
    public class HotelWorkItem
    {
        public string TenantId { get; internal set; }

        public string PropertyId { get; internal set; }

        public string SupplierFamily { get; internal set; }

        public long Revision { get; internal set; }

        public string DataType { get; internal set; }

        public string Id { get; internal set; }

    }
}
