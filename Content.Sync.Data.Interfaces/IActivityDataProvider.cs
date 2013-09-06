using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContentUpdate.Hotel.Model;

namespace Content.Sync.Data.Interfaces
{
    public interface IActivityDataProvider
    {
        List<HotelActivity> GetHotelActivities(IKey hotelKey);
        void InsertHotelActivity(IKey hotelKey, HotelActivity activity);
        void UpdateHotelActivity(IKey hotelKey, HotelActivity activity);
        void DeleteHotelActivity(IKey hotelKey, HotelActivity activity);
    }
}
