using Content.Sync.Infrastructure;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Content.Sync.Clarifi
{
    public class SyncBot
    {
        public SyncBot(BotSettings settings, IWorkItemIterator iterator)
        {
            this.Id = settings.Id;
            this.ItemsIterator = iterator;
            this.Settings = settings;
        }

        public IWorkItemIterator ItemsIterator { get; set; }

        public string Id { get; set; }
        public BotSettings Settings { get; private set; }
        private static readonly int MAX_STEPS_COUNT = 10;
        public async Task Run(CancellationToken token)
        {
            /*
                Get items from the iterator and process them.
                Incase of fault, retry the processing.
                Incase the retries fail, then checkpoint the log.
            */
            // var items = new WorkItemIterator(settings.SupplierFamily, settings.InitialRevision);
            var interval = this.Settings.MaxDelayInSeconds - this.Settings.MinDelayInSeconds;
            int stepSize = interval < MAX_STEPS_COUNT ? 1 : (int)Math.Ceiling(interval / (decimal)MAX_STEPS_COUNT);

            var delay = new IncrementalDelay(stepSize, this.Settings.MinDelayInSeconds, this.Settings.MaxDelayInSeconds);

            while (token.IsCancellationRequested == false)
            {
                WorkItem item = await this.ItemsIterator.GetNextItemAsync();
                if (item != null)
                {   
                    await ProcessWithRetry(item, token);
                    await item.CheckpointRevision(this.Id);
                    delay.Reset();
                }
                await delay.Wait();
            }
        }

        private async Task ProcessWithRetry(WorkItem item, CancellationToken token, int attempts = 3)
        {
            List<Exception> faults = new List<Exception>();
            for (int i = 0; i < attempts; i++)
            {
                try
                {
                    if (token.IsCancellationRequested == true)
                        return;
                    await item.Do(token);
                    return;
                }
                catch (Exception ex)
                {
                    faults.Add(ex);
                }
            }
            await item.MarkAsFaultedAsync(faults);
        }
    }
}
