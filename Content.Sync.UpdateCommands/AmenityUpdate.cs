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
            if(workItem.ChildSchema == Schema.Amenity && workItem.ChangeAction == ChangeActionType.Add)
            {
               HotelAmenity amenity = new AppacitiveDAL.DatabaseManager().GetAmenityForSupplierFamily( new HotelAmenity() { Id = workItem.ArticleId }, workItem.SupplierFamily);
               new AmenityDataProvider().InsertHotelAmenity(new AppacitiveDAL.HotelKey() { SupplierFamily = workItem.SupplierFamily }, amenity);
            }
            else if(workItem.ChildSchema == Schema.Amenity && workItem.ChangeAction == ChangeActionType.Update)
            {
                HotelAmenity amenity = new AppacitiveDAL.DatabaseManager().GetAmenityForSupplierFamily(new HotelAmenity() { Id = workItem.ArticleId }, workItem.SupplierFamily);
                new AmenityDataProvider().UpdateHotelAmenity(new AppacitiveDAL.HotelKey() { SupplierFamily = workItem.SupplierFamily }, amenity);
            }
            else
                throw new ArgumentException(string.Format("Invalid ChildSchema: {0} or ChangeAction: {1} in AmenityUpdate Command", workItem.ChildSchema, workItem.ChangeAction));

            return null;
        }

        protected override Task OnFault(WorkItem workItem, Exception ex)
        {
            throw new NotImplementedException();
        }
    }
}
