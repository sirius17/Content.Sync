using Appacitive.Sdk;
using Content.Sync.Clarifi;
using Content.Sync.ErrorSpace;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Content.Sync.Appacitive
{
    public class SyncDb : ISyncDb
    {
        private static readonly BotSettings[] Empty = new BotSettings[] { };
        public async Task<IEnumerable<BotSettings>> GetBotSettings(string deploymentName)
        {   
            // Specification
            // 1. Resolve the deployment id from the name
            // 2. Get connected articles of type "bot" via  the "bots" connection.
            var deployments =await Articles.FindAllAsync("deployment",
                Query.Property("name").IsEqualTo(deploymentName).ToString(),
                pageSize: 1);
            if (deployments == null || deployments.Count ==  0 )
                throw new LookupFailedException( string.Format("No deployment found with name '{0}'.", deploymentName));
            Debug.Assert(deployments.Count == 1, "List of deployments should contain just a single article.");

            var deployment = deployments.Single();
            var botArticles = await deployment.GetConnectedArticlesAsync("bots").GetContentsAsync();
            return botArticles.ConvertAll(a =>
                {
                    return new BotSettings
                    {
                        Id = a.Id,
                        InitialRevision = a.Get<long>("version_to_start_from"),
                        SupplierFamily = a.Get<string>("supplier_family"),
                        Deployment = deploymentName,
                        MaxDelayInSeconds = a.Get<int>("max_poll_interval_in_seconds"),
                        MinDelayInSeconds = a.Get<int>("min_poll_interval_in_seconds")
                    };
                });
        }

        public async Task CheckpointRevision(string botId, long revision)
        {
            //TODO: Fix this to use the bot revision number for MVCC
            var bot = new Article("bot", botId);
            bot.Set("version", revision);
            await bot.SaveAsync();
        }
    }
}
