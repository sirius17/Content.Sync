using Appacitive.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Content.Sync.Appacitive
{
    internal static class Extensions
    {
        public async static Task<List<T>> GetContentsAsync<T>(this Task<PagedList<T>> pagedTask)
        {
            List<T> all = new List<T>();
            var items = await pagedTask;
            all.AddRange(items);
            while (items.IsLastPage == false)
            {
                items = await items.NextPageAsync();
                all.AddRange(items);
            }
            return all;
        }
    }
}
