using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Content.Sync.Data.Interfaces;

namespace Content.Sync.Data.SqlServer
{
    public class DescriptionDataProvider : IDescriptionDataProvider
    {
        public List<ContentUpdate.Hotel.Model.HotelDescription> GetHotelDescriptions(ContentUpdate.Hotel.Model.IKey hotelKey)
        {
            throw new NotImplementedException();
        }

        public void InsertHotelDescription(ContentUpdate.Hotel.Model.IKey hotelKey, ContentUpdate.Hotel.Model.HotelDescription hotelDescription)
        {
            throw new NotImplementedException();
        }

        public void UpdateHotelDescription(ContentUpdate.Hotel.Model.IKey hotelKey, ContentUpdate.Hotel.Model.HotelDescription hotelDescription)
        {
            throw new NotImplementedException();
        }

        public void DeleteHotelDescription(ContentUpdate.Hotel.Model.IKey hotelKey, ContentUpdate.Hotel.Model.HotelDescription hotelDescription)
        {
            throw new NotImplementedException();
        }
    }
}
