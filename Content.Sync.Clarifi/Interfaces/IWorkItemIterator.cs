using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Content.Sync.Clarifi
{
    /// <summary>
    /// Work item 
    /// </summary>
    public interface IWorkItemIterator
    {
        /// Infinite iterator for work items.
        Task<WorkItem> GetNextItemAsync();
    }
}
