using Appacitive.Sdk;
using Content.Sync.Clarifi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Content.Sync.Appacitive
{
    public class WorkItemDb : IHotelWorkItemDb, IMasterWorkItemDb
    {
        async Task<WorkItem> IHotelWorkItemDb.GetNextItemAsync(string supplierFamily, long lastProcessedRevision)
        {
            // Get next work item with the given supplier name and with revision > the last processed revision
            var query = BooleanOperator.And(new[] {
                                                                    Query.Property("supplier_family").IsEqualTo(supplierFamily),
                                                                    Query.Property("version").IsGreaterThan(lastProcessedRevision)
                                                                });
            var changeLog = (await Articles.FindAllAsync("hotel_change_log", query.ToString(), pageSize: 1, orderBy: "version", sortOrder: SortOrder.Ascending)).SingleOrDefault();
            if (changeLog == null) return null;
            return changeLog.ToHotelWorkItem();
        }

        async Task<WorkItem> IMasterWorkItemDb.GetNextItemAsync(string supplierFamily, long lastProcessedRevision)
        {
            // Get next work item with the given supplier name and with revision > the last processed revision
            var query = BooleanOperator.And(new[] {
                                                                    Query.Property("supplier_family").IsEqualTo(supplierFamily),
                                                                    Query.Property("version").IsGreaterThan(lastProcessedRevision)
                                                                });
            var changeLog = (await Articles.FindAllAsync("master_change_log", query.ToString(), pageSize: 1, orderBy: "version", sortOrder: SortOrder.Ascending)).SingleOrDefault();
            if (changeLog == null) return null;
            return changeLog.ToHotelWorkItem();
        }
    }
}
