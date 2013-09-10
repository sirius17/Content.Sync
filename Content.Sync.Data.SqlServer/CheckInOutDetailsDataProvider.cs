using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Content.Sync.Data.Interfaces;

namespace Content.Sync.Data.SqlServer
{
    public class CheckInOutDetailsDataProvider : ICheckInOutDetailsDataProvider
    {
        public void AddOrUpdate(string hotelId, string supplierFamily, List<ContentUpdate.Hotel.Model.HotelTimeDetail> inDetails, List<ContentUpdate.Hotel.Model.HotelTimeDetail> outDetails)
        {
            throw new NotImplementedException();
        }

        public void Delete(string hotelId, string supplierFamily)
        {
            throw new NotImplementedException();
        }
    }
}
