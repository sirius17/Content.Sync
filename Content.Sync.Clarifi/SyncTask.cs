using Content.Sync.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Content.Sync.Clarifi
{
    public class SyncTask
    {
        public async Task Run(SyncSettings settings, CancellationToken token)
        {
            /*
                First get all failed items and process them.
                Subsequently keep polling the Items iterator for work items to process.
                Incase no work items are found then delay incrementally.
            */
            await ProcessFaultedItems(settings,  token);
            await ProcessItems(settings, token);
        }

        private async Task ProcessFaultedItems(SyncSettings settings, CancellationToken token)
        {
            IWorkItemIterator failedItems = new FailedWorkItemIterator(settings.TenantId);
            do
            {
                WorkItem item = await failedItems.GetNextItemAsync();
                if( item == null ) return;
                await item.Do();
            } while (token.IsCancellationRequested == false);
        }


        private async Task ProcessItems(SyncSettings settings, CancellationToken token)
        {
            var items = new WorkItemIterator(settings.SupplierFamily, settings.InitialRevision);
            var delay = new IncrementalDelay(settings.DelayStepSizeInSeconds, settings.MaxDelayInSeconds);
            do
            {
                WorkItem item = await items.GetNextItemAsync();
                if (item != null)
                {
                    delay.Reset();
                    await item.Do();
                }
                else
                    await delay.Wait();
            } while (token.IsCancellationRequested == false);
        }
    }
}
