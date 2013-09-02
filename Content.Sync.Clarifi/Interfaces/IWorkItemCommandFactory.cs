using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Content.Sync.Clarifi
{
    public interface IWorkItemCommandFactory
    {
        IWorkItemCommand BuildCommand(WorkItem item);
    }
}
