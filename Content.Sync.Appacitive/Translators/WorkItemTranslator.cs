using Appacitive.Sdk;
using Content.Sync.Clarifi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Content.Sync.Appacitive
{
    internal static class HotelWorkItemTranslator
    {
        public static HotelWorkItem ToHotelWorkItem(this Article article )
        {
            if (article == null) return null;
            var workItem = new HotelWorkItem();
            workItem.Id = article.Id;
            workItem.UtcCreateDate = article.UtcCreateDate;
            workItem.UtcLastUpdated = article.UtcLastUpdated;
            workItem.ArticleId = article.Get<string>("hotel_article_id");
            workItem.HotelId = article.Get<string>("hotel_id");
            workItem.Revision = article.Get<long>("version");
            workItem.SupplierFamily = article.Get<string>("supplier_family");
            workItem.Schema = article.Get<string>("content_type");
            workItem.ChangeType = article.Get<ChangeType>("change_type");
            return workItem;
        }

        public static MasterWorkItem ToMasterWorkItem(this Article article)
        {
            if (article == null) return null;
            var workItem = new MasterWorkItem();
            workItem.Id = article.Id;
            workItem.UtcCreateDate = article.UtcCreateDate;
            workItem.UtcLastUpdated = article.UtcLastUpdated;
            workItem.Revision = article.Get<long>("version");
            workItem.SupplierFamily = article.Get<string>("supplier_family");
            workItem.Schema = article.Get<string>("content_type");
            workItem.ChangeType = article.Get<ChangeType>("change_type");
            return workItem;
        }
    }
}
