using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Content.Sync.Clarifi  
{
    public class MasterWorkItem : WorkItem
    {
        public string ArticleId { get; set; }

        public string NativeId { get; set; }

        public string DataType { get; set; }

        public string ChangeType { get; set; }

        public string SupplierFamily { get; set; }

        public long Revision { get; set; }

    }
}
