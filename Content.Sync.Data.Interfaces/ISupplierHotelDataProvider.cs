using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContentUpdate.Hotel.Model;

namespace Content.Sync.Data.Interfaces
{
    public interface ISupplierHotelDataProvider
    {
        List<SupplierHotel> GetSupplierHotels(IKey hotelKey);
        void InsertSupplierHotel(IKey hotelKey, SupplierHotel supplierHotel);
        void UpdateSupplierHotel(IKey hotelKey, SupplierHotel supplierHotel);
        void DeleteSupplierHotel(IKey hotelKey, SupplierHotel supplierHotel);
    }
}
