using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContentUpdate.Hotel.Model;

namespace Content.Sync.Data.Interfaces
{
    public interface IImageDataProvider
    {
        List<HotelImage> GetImagesForHotel(string hotelId, string supplierFamily);
        void SaveImage(string hotelId, string supplierFamily, HotelImage sourceImage);
        void UpdateImage(string hotelId, string supplierFamily, HotelImage sourceImage);
        void DeleteImage(string imageId);
    }
}
