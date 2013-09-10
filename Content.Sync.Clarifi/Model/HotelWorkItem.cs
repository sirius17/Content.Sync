
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Content.Sync.Clarifi
{
    /// <summary>
    /// Represents a single work item that is to be processed.
    /// </summary>
    public class HotelWorkItem : WorkItem
    {
        public string DeploymentId { get; set; }

        public string ArticleId { get; set; }

        public string HotelId { get; set; }

        public string SupplierFamily { get; set; }

        public string Schema { get; set; }

        public ChangeType ChangeType { get; set; }
    }
}
