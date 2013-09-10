using Appacitive.Sdk;
using Content.Sync.Appacitive;
using Content.Sync.Clarifi;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Content.Sync.Fixtures.Appacitive
{
    [TestClass]
    public class HotelWorkItemDbFixture
    {
        [TestMethod]
        public async Task VerifyRevisionFilterAndSortingTest()
        {
            // Setup test data
            string id2 = null, id3 = null, id4 = null, id5 = null, id6 = null;
            var task2 = CreateNewChangeLog("pegasus_test", 2).ContinueWith(t => id2 = t.Result.Id);
            var task3 = CreateNewChangeLog("pegasus_test", 3).ContinueWith(t => id3 = t.Result.Id); ;
            var task4 = CreateNewChangeLog("tourico_test", 4).ContinueWith(t => id4 = t.Result.Id); ;
            var task5 = CreateNewChangeLog("pegasus_test", 5).ContinueWith(t => id5 = t.Result.Id); ;
            var task6 = CreateNewChangeLog("tourico_test", 6).ContinueWith(t => id6 = t.Result.Id); ;
            await Task.WhenAll(task2, task3, task4, task5, task6);
            

            // Test for invalid supplier. Should return null.
            IHotelWorkItemDb db = new WorkItemDb();
            var workItem = await db.GetNextItemAsync(Unique.NewString, 1);
            Assert.IsNull(workItem, "Test failed as work item was retrieved for an invalid supplier family.");

            // Test for pegasus with version 1, Should return work item with id same as id2.
            workItem = await db.GetNextItemAsync("pegasus_test", 1);
            Assert.IsTrue(workItem.Id == id2, "Incorrect work item retrieved for given revision.");

            // Test for pegasus with version 3, Should return work item with id same as id5.
            workItem = await db.GetNextItemAsync("pegasus_test", 3);
            Assert.IsTrue(workItem.Id == id5, "Incorrect work item retrieved for given revision.");

            // Clean up test data
            await Articles.MultiDeleteAsync("hotel_change_log", id2, id3, id4, id5,id6);
        }

        private async Task<Article> CreateNewChangeLog(string supplierFamily, int version)
        {
            var log = new Article("hotel_change_log");
            log.Set("hotel_id", Unique.NewString);
            log.Set("hotel_article_id", Unique.NewString);
            log.Set("supplier_family", supplierFamily);
            log.Set("content_type", "hotel");
            log.Set("change_type", "updated");
            log.Set("version", version);
            await log.SaveAsync();
            return log;
        }

    }
}
