using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContentUpdate.Hotel.Model;

namespace Content.Sync.Data.Interfaces
{
    public interface IDescriptionDataProvider
    {
        List<HotelDescription> GetHotelDescriptions(IKey hotelKey);
        void InsertHotelDescription(IKey hotelKey, HotelDescription hotelDescription);
        void UpdateHotelDescription(IKey hotelKey, HotelDescription hotelDescription);
        void DeleteHotelDescription(IKey hotelKey, HotelDescription hotelDescription);
    }
}
