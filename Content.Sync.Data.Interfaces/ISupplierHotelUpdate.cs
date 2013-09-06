using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContentUpdate.Hotel.Model;

namespace Content.Sync.Data.Interfaces
{
    public interface ISupplierHotelUpdate
    {
        List<string> GetSupplierHotels(IKey hotelKey);
        void InsertSupplierHotel(IKey hotelKey, string supplierHotelId);
        void UpdateSupplierHotel(IKey hotelKey, string supplierHotelId);
        void DeleteSupplierHotel(IKey hotelKey, string supplierHotelId);
    }
}
