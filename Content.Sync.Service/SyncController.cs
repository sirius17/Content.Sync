using Content.Sync.Clarifi;
using Content.Sync.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Content.Sync.Service
{
    public class SyncController
    {

        private Dictionary<string, Worker> Workers { get; set; }

        public async Task Start(string deployment)
        {
            var botSettings = await BotSettings.FindAllByDeploymentAsync(deployment);
            var bots = botSettings.Select(s => new SyncBot(s, null)).ToList();
            bots.ForEach(b =>
                {
                    var worker = new Worker(b.Id, b.Run);
                    this.Workers[worker.Id] = worker;
                    worker.Start();
                });
        }

        public void Stop()
        {
            foreach (var id in this.Workers.Keys)
                this.Workers[id].Stop();
        }

        
    }
}
