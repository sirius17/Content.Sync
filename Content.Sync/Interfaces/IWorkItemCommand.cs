using Content.Sync.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Content.Sync.Interfaces
{
    public interface IWorkItemCommand
    {
        Task Execute(WorkItem item, CancellationToken token);
    }
}
