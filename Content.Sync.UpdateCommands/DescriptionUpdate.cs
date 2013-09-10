using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Content.Sync.Clarifi;
using Content.Sync.Data.Interfaces;
using Content.Sync.Data.SqlServer;
using ContentUpdate.Hotel.Core.Interfaces;
using AppacitiveDAL = ContentUpdate.Hotel.DAL.Appacitive;
using ContentUpdate.Hotel.Model;
using System.Threading;

namespace Content.Sync.UpdateCommands
{
    public class DescriptionUpdate : HotelUpdateCommand
    {
        protected override Task ProcessHotelWorkItem(HotelWorkItem workItem, CancellationToken cancellationToken)
        {
            IKey hotelKey = new AppacitiveDAL.HotelKey() { HotelArticleId = workItem.ArticleId, HotelId = Convert.ToInt64(workItem.HotelId), SupplierFamily = workItem.SupplierFamily };
            IDescriptionDataProvider descriptionDataProvider = new DescriptionDataProvider();

            // Get Appacitive descriptions by HotelArticleId
            List<HotelDescription> sourceDescriptions = new AppacitiveDAL.DatabaseManager().GetHotelDescriptions(hotelKey);

            // Get Client DB descriptions by HotelArticleId
            List<HotelDescription> destinationDescriptions = descriptionDataProvider.GetHotelDescriptions(hotelKey);

            foreach (var sourceDescription in sourceDescriptions)
            {
                HotelDescription description = destinationDescriptions.Find(x => x.Equals(sourceDescription));
                if (description == null)
                {
                    // New Hotel description 
                    descriptionDataProvider.InsertHotelDescription(hotelKey, sourceDescription);
                }
                else
                {
                    // Old Hotel description
                    if (!description.IsUpdated(sourceDescription))
                        descriptionDataProvider.UpdateHotelDescription(hotelKey, sourceDescription);

                    destinationDescriptions.Remove(description);
                }
            }

            destinationDescriptions.ForEach(x => descriptionDataProvider.DeleteHotelDescription(hotelKey, x));

            return null;
        }
    }
}
