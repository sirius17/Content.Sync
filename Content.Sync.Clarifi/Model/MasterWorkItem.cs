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

        public string Schema { get; set; }

        public ChangeType ChangeType { get; set; }

        public string SupplierFamily { get; set; }
    }
}
