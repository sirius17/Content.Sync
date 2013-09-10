using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Content.Sync.Data.Interfaces;

namespace Content.Sync.Data.SqlServer
{
    public class SupplierHotelUpdate : ISupplierHotelUpdate
    {
        public List<string> GetSupplierHotels(ContentUpdate.Hotel.Model.IKey hotelKey)
        {
            throw new NotImplementedException();
        }

        public void InsertSupplierHotel(ContentUpdate.Hotel.Model.IKey hotelKey, string supplierHotelId)
        {
            throw new NotImplementedException();
        }

        public void UpdateSupplierHotel(ContentUpdate.Hotel.Model.IKey hotelKey, string supplierHotelId)
        {
            throw new NotImplementedException();
        }

        public void DeleteSupplierHotel(ContentUpdate.Hotel.Model.IKey hotelKey, string supplierHotelId)
        {
            throw new NotImplementedException();
        }
    }
}
