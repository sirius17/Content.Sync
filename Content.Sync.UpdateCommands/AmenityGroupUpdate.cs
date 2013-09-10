using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Content.Sync.Clarifi;
using Content.Sync.Data.Interfaces;
using Content.Sync.Data.SqlServer;
using ContentUpdate.Hotel.Model;
using AppacitiveDAL = ContentUpdate.Hotel.DAL.Appacitive;

namespace Content.Sync.UpdateCommands
{
    public class AmenityGroupUpdate : HotelUpdateCommand
    {
        protected override Task ProcessHotelWorkItem(WorkItem workItem, System.Threading.CancellationToken cancellationToken)
        {
            if(workItem.ChildSchema == Schema.AmenityGroup && workItem.ChangeAction == ChangeActionType.Add)
            {
                AmenityGroup amenityGroup = new AppacitiveDAL.DatabaseManager().GetAmenityGroup(new AppacitiveDAL.AmenityGroupKey(){ AmenityGroupArticleId = workItem.ArticleId });
                new AmenityGroupDataProvider().InsertAmenityGroup(amenityGroup);
            }
            else if(workItem.ChildSchema == Schema.AmenityGroup && workItem.ChangeAction == ChangeActionType.Update)
            {
                AmenityGroup amenityGroup = new AppacitiveDAL.DatabaseManager().GetAmenityGroup(new AppacitiveDAL.AmenityGroupKey() { AmenityGroupArticleId = workItem.ArticleId });
                new AmenityGroupDataProvider().UpdateAmenityGroup(amenityGroup);
            }
            else if(workItem.ChildSchema == Schema.Amenity && workItem.ChangeAction == ChangeActionType.Update)
            {
                AppacitiveDAL.DatabaseManager databaseManager = new AppacitiveDAL.DatabaseManager();

                // Get amenities by AmenityGroupArticleId
                IKey amenityGroupKey = new AppacitiveDAL.AmenityGroupKey() { AmenityGroupArticleId = workItem.ArticleId };
                Dictionary<string, List<HotelAmenity>> suppliersHotelAmenities = databaseManager.GetHotelAmenitiesForAmenityGroup(amenityGroupKey);

                // Get amenityGroupId based on Appacitive
                AmenityGroup amenityGroup = new AmenityGroupDataProvider().GetAmenityGroupDetails(databaseManager.GetAmenityGroup(amenityGroupKey));

                if (suppliersHotelAmenities != null && suppliersHotelAmenities.Count > 0)
                {
                    IAmenityDataProvider amenityDataProvider = new AmenityDataProvider();
                    foreach (var supplierHotelAmenities in suppliersHotelAmenities)
                    {
                        IKey hotelKey = new AppacitiveDAL.HotelKey() { SupplierFamily = supplierHotelAmenities.Key };
                        foreach (var hotelAmenity in supplierHotelAmenities.Value)
                        {
                            amenityDataProvider.UpdateAmenityGroup(hotelKey, hotelAmenity, amenityGroup.Id);    
                        }
                    }
                }
            }
            else
                throw new ArgumentException(string.Format("Invalid ChildSchema: {0} or ChangeAction: {1} in AmenityGroupUpdate Command", workItem.ChildSchema, workItem.ChangeAction));

            return null;
        }

        protected override Task OnFault(WorkItem workItem, Exception ex)
        {
            throw new NotImplementedException();
        }
    }
}
