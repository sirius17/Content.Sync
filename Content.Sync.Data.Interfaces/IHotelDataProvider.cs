using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContentUpdate.Hotel.Model;

namespace Content.Sync.Data.Interfaces
{
    public interface IHotelDataProvider
    {
        void AddHotel(HotelProperty hotel);

        void UpdateHotel(HotelProperty hotel);

        void DisableHotel(string hotelId, string supplierFamily);
    }
}
