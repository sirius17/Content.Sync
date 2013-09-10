using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Content.Sync.Data.Interfaces;
using ContentUpdate.Hotel.Model;

namespace Content.Sync.Data.SqlServer
{
    public class HotelDataProvider : IHotelDataProvider
    {
        public void AddHotel(HotelProperty hotel)
        {
            throw new NotImplementedException();
        }

        public void UpdateHotel(HotelProperty hotel)
        {
            throw new NotImplementedException();
        }

        public void DisableHotel(string hotelId, string supplierFamily)
        {
            throw new NotImplementedException();
        }
    }
}
