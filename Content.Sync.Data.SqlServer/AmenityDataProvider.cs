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
        public void InsertHotelAmenity(IKey hotelKey, HotelAmenity amenity)
        {
            //Get supplierfamily from hotelkey & insert amenity
            throw new NotImplementedException();
        }

        public void UpdateHotelAmenity(IKey hotelKey, HotelAmenity amenity)
        {
            //Get supplierfamily from hotelkey & update amenity
            throw new NotImplementedException();
        }

        public void UpdateAmenityGroup(IKey hotelKey, HotelAmenity amenity, long amenityGroupId)
        {
            throw new NotImplementedException();
        }
    }
}
