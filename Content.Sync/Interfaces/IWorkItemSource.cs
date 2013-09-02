using Content.Sync.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Content.Sync.Interfaces
{
    /// <summary>
    /// Work item 
    /// </summary>
    public interface IWorkItemSource
    {
        /// Infinite iterator for work items.
        Task<WorkItem> GetNextTaskAsync();
    }
}
