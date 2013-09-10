using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContentUpdate.Hotel.Model;

namespace Content.Sync.Data.Interfaces
{
    public interface ICheckInOutDetailsDataProvider
    {
        void AddOrUpdate(string hotelId, string supplierFamily, List<HotelTimeDetail> inDetails, List<HotelTimeDetail> outDetails);
        void Delete(string hotelId, string supplierFamily);
    }
}
