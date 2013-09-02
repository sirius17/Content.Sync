using Content.Sync.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Content.Sync.Model
{
    /// <summary>
    /// Represents a single work item that is to be processed.
    /// </summary>
    public class WorkItem
    {
        public async Task Do()
        {
            await this.Do(CancellationToken.None);
        }

        public async Task Do(CancellationToken cancellationToken)
        {
            // Specification
            // Each task will build the specific command that is required to execute it.
            // and delegate the execution the the command.
            
            //TODO: Initialize the factory. Need to decide whether this should be via service locator or dependency injection.
            IWorkItemCommandFactory factory = null;  // Initialize this
            var command = factory.BuildCommand(this);
            await command.Execute(this, cancellationToken);
        }
    }
}
