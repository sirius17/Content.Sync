using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Content.Sync.Data.Interfaces;
using ContentUpdate.Hotel.Model;

namespace Content.Sync.Data.SqlServer
{
    public class SupplierHotelDataProvider : ISupplierHotelDataProvider
    {
        public List<SupplierHotel> GetSupplierHotels(IKey hotelKey)
        {
            throw new NotImplementedException();
        }

        public void InsertSupplierHotel(IKey hotelKey, SupplierHotel supplierHotel)
        {
            throw new NotImplementedException();
        }

        public void UpdateSupplierHotel(IKey hotelKey, SupplierHotel supplierHotel)
        {
            throw new NotImplementedException();
        }

        public void DeleteSupplierHotel(IKey hotelKey, SupplierHotel supplierHotel)
        {
            throw new NotImplementedException();
        }
    }
}
