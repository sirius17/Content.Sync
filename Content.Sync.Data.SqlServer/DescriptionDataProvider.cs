using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Content.Sync.Data.Interfaces;
using ContentUpdate.Hotel.Model;

namespace Content.Sync.Data.SqlServer
{
    public class DescriptionDataProvider : IDescriptionDataProvider
    {
        public List<HotelDescription> GetHotelDescriptions(IKey hotelKey)
        {
            throw new NotImplementedException();
        }

        public void InsertHotelDescription(IKey hotelKey, HotelDescription hotelDescription)
        {
            throw new NotImplementedException();
        }

        public void UpdateHotelDescription(IKey hotelKey, HotelDescription hotelDescription)
        {
            throw new NotImplementedException();
        }

        public void DeleteHotelDescription(IKey hotelKey, HotelDescription hotelDescription)
        {
            throw new NotImplementedException();
        }
    }
}
