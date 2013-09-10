using Content.Sync.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Content.Sync.Clarifi
{
    public class BotSettings
    {

        public static async Task<IEnumerable<BotSettings>> FindAllByDeploymentAsync(string deploymentName)
        {
            ISyncDb syncDb = ObjectBuilder.Build<ISyncDb>();
            return await syncDb.GetBotSettings(deploymentName);
        }

        public string Id { get; set; }

        public string Deployment { get; set; }

        public string SupplierFamily { get; set; }

        public long InitialRevision { get; set; }

        public int MaxDelayInSeconds { get; set; }

        public int MinDelayInSeconds { get; set; }
    }
}
