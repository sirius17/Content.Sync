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
        List<HotelAmenity> GetHotelAmenities(IKey hotelKey);
        void InsertHotelAmenity(IKey hotelKey, HotelAmenity activity);
        void UpdateHotelAmenity(IKey hotelKey, HotelAmenity activity);
        void DeleteHotelAmenity(IKey hotelKey, HotelAmenity activity);
    }
}
