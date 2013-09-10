using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Content.Sync.Data.Interfaces;
using ContentUpdate.Hotel.Model;

namespace Content.Sync.Data.SqlServer
{
    public class AmenityDataProvider : IAmenityDataProvider
    {
        public List<HotelAmenity> GetHotelAmenities(IKey hotelKey)
        {
            throw new NotImplementedException();
        }

        public void InsertHotelAmenity(IKey hotelKey, HotelAmenity activity)
        {
            throw new NotImplementedException();
        }

        public void UpdateHotelAmenity(IKey hotelKey, HotelAmenity activity)
        {
            throw new NotImplementedException();
        }

        public void DeleteHotelAmenity(IKey hotelKey, HotelAmenity activity)
        {
            throw new NotImplementedException();
        }
    }
}
