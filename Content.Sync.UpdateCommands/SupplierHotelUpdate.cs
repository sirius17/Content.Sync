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
    public class SupplierHotelUpdate : HotelUpdateCommand
    {
        protected override Task ProcessHotelWorkItem(WorkItem workItem, System.Threading.CancellationToken cancellationToken)
        {
            IKey hotelKey = new AppacitiveDAL.HotelKey() { HotelArticleId = workItem.ArticleId, HotelId = Convert.ToInt64(workItem.HotelId), SupplierFamily = workItem.SupplierFamily };

            ISupplierHotelDataProvider supplierHotelDataProvider = new SupplierHotelDataProvider();

            List<SupplierHotel> sourceSupplierHotels = new AppacitiveDAL.DatabaseManager().GetSupplierHotelIdsByHotelIdSupplierFamily(hotelKey);

            List<SupplierHotel> destinationSupplierHotels = supplierHotelDataProvider.GetSupplierHotels(hotelKey);

            foreach (var sourceSupplierHotel in sourceSupplierHotels)
            {
                SupplierHotel supplierHotel = destinationSupplierHotels.Find(x => x.Equals(sourceSupplierHotel));
                if (supplierHotel == null)
                {
                    // New Hotel SupplierHotel 
                    supplierHotelDataProvider.InsertSupplierHotel(hotelKey, sourceSupplierHotel);
                }
                else
                {
                    // Old Hotel SupplierHotel
                    if (!supplierHotel.IsUpdated(sourceSupplierHotel))
                        supplierHotelDataProvider.UpdateSupplierHotel(hotelKey, sourceSupplierHotel);

                    destinationSupplierHotels.Remove(supplierHotel);
                }
            }

            destinationSupplierHotels.ForEach(x => supplierHotelDataProvider.DeleteSupplierHotel(hotelKey, x));

            return null;
        }

        protected override Task OnFault(WorkItem workItem, Exception ex)
        {
            throw new NotImplementedException();
        }
    }
}
