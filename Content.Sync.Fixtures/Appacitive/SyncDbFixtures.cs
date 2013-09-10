using Appacitive.Sdk;
using Content.Sync.Appacitive;
using Content.Sync.Clarifi;
using Content.Sync.ErrorSpace;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Content.Sync.Fixtures.Appacitive
{
    [TestClass]
    public class SyncDbFixtures
    {
        [TestMethod]
        [ExpectedException(typeof(LookupFailedException))]
        public async Task GetBotSettingsWithInvalidDeploymentNameShouldReturnEmptyTest()
        {
            ISyncDb db = new SyncDb();
            var bots = await db.GetBotSettings(Guid.NewGuid().ToString());
            Assert.IsTrue(bots.Count() == 0);
        }

        [TestMethod]
        public async Task GetBotSettingsWithExistingDataTest()
        {
            // Create dummy data for deployments
            var deployment = new Article("deployment");
            deployment.Set("name",Unique.NewString);
            deployment.Set("description","lorem ipsum etc..");
            await deployment.SaveAsync(); ;
            
            // Insert some bot settings
            var bot = new Article("bot");
            bot.Set("supplier_family", "pegasus");
            bot.Set("version_to_start_from", 123);
            bot.Set("min_poll_interval_in_seconds", 10);
            bot.Set("max_poll_interval_in_seconds", 100);
            bot.Set("bot_type", "hotel_content");
            await Connection.New("bots")
                .FromExistingArticle("deployment", deployment.Id)
                .ToNewArticle("bot", bot)
                .SaveAsync();
        
            // Test sync db
            ISyncDb syncDb = new SyncDb();
            var bots  = await syncDb.GetBotSettings(deployment.Get<string>("name"));
            var ids = bots.Select(b => b.Id);
            Assert.IsTrue(ids.Union(new[] { bot.Id }).Count() == 1);

            // Clean up the test data
            await Articles.DeleteAsync("bot", bot.Id, true);
            await Articles.DeleteAsync("deployment", deployment.Id);
        }
        
    }
}
