using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Content.Sync.Data.Interfaces;
using ContentUpdate.Hotel.Model;

namespace Content.Sync.Data.SqlServer
{
    public class ImageDataProvider : IImageDataProvider
    {
        public List<HotelImage> GetImagesForHotel(string hotelId, string supplierFamily)
        {
            throw new NotImplementedException();
        }

        public void SaveImage(string hotelId, string supplierFamily, HotelImage sourceImage)
        {
            throw new NotImplementedException();
        }

        public void UpdateImage(string hotelId, string supplierFamily, HotelImage sourceImage)
        {
            throw new NotImplementedException();
        }

        public void DeleteImage(string imageId)
        {
            throw new NotImplementedException();
        }
    }
}
