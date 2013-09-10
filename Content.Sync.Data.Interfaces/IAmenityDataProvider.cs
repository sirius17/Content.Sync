using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContentUpdate.Hotel.Model;

namespace Content.Sync.Data.Interfaces
{
    public interface IAmenityDataProvider
    {
        void InsertHotelAmenity(IKey hotelKey, HotelAmenity amenity);
        void UpdateHotelAmenity(IKey hotelKey, HotelAmenity amenity);
        void UpdateAmenityGroup(IKey hotelKey, HotelAmenity amenity, long amenityGroupId);
    }
}
