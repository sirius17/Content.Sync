using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Content.Sync.Data.Interfaces;
using ContentUpdate.Hotel.Model;

namespace Content.Sync.Data.SqlServer
{
    public class ActivityDataProvider : IActivityDataProvider
    {
        public List<HotelActivity> GetHotelActivities(IKey hotelKey)
        {
            throw new NotImplementedException();
        }

        public void InsertHotelActivity(IKey hotelKey, HotelActivity activity)
        {
            throw new NotImplementedException();
        }

        public void UpdateHotelActivity(IKey hotelKey, HotelActivity activity)
        {
            throw new NotImplementedException();
        }

        public void DeleteHotelActivity(IKey hotelKey, HotelActivity activity)
        {
            throw new NotImplementedException();
        }
    }
}
