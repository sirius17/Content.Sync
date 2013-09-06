using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Content.Sync.Clarifi;
using Content.Sync.Data.Interfaces;
using Content.Sync.Data.SqlServer;
using AppacitiveDAL = ContentUpdate.Hotel.DAL.Appacitive;
using ContentUpdate.Hotel.Model;

namespace Content.Sync.UpdateCommands
{
    public class AmenityUpdate : HotelUpdateCommand
    {
        protected override Task ProcessHotelWorkItem(WorkItem workItem, System.Threading.CancellationToken cancellationToken)
        {
            IKey hotelKey = new AppacitiveDAL.HotelKey() { HotelArticleId = workItem.HotelArticleId, HotelId = Convert.ToInt64(workItem.HotelId), SupplierFamily = workItem.SupplierFamily };
            IAmenityDataProvider amenityDataProvider = new AmenityDataProvider();

            // Get Appacitive activities by HotelArticleId
            List<HotelAmenity> sourceAmenities = new AppacitiveDAL.DatabaseManager().GetAmenitiesForHotel(hotelKey);

            // Get Client DB activities by HotelArticleId
            List<HotelAmenity> destinationAmenities = amenityDataProvider.GetHotelAmenities(hotelKey);

            foreach (var sourceAmenity in sourceAmenities)
            {
                HotelAmenity amenity = destinationAmenities.Find(x => x.Equals(sourceAmenity));
                if (amenity == null)
                {
                    // New Hotel Activity 
                    amenityDataProvider.InsertHotelAmenity(hotelKey, sourceAmenity);
                }
                else
                {
                    // Old Hotel Activity
                    if (!amenity.IsAmenityUpdated(sourceAmenity))
                        amenityDataProvider.UpdateHotelAmenity(hotelKey, sourceAmenity);

                    destinationAmenities.Remove(amenity);
                }
            }

            destinationAmenities.ForEach(x => amenityDataProvider.DeleteHotelAmenity(hotelKey, x));

            return null;
        }

        protected override Task OnFault(WorkItem workItem, Exception ex)
        {
            throw new NotImplementedException();
        }
    }
}
