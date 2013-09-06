using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Content.Sync.Clarifi;
using Content.Sync.Data.Factories;
using ContentUpdate.Hotel.Core.Interfaces;
using ContentUpdate.Hotel.Model;

namespace Content.Sync.UpdateCommands
{
    public class InOutDetailsUpdate : HotelUpdateCommand
    {
        private readonly IDatabaseManager _appacitive = AppacitiveDataProviderFactory.GetDatabaseManager();
        private readonly IDatabaseManager _sqlDb = SqlDataProviderFactory.GetDatabaseManager();

        protected override Task ProcessHotelWorkItem(WorkItem workItem, System.Threading.CancellationToken cancellationToken)
        {
            var key = new HotelProperty()
            {
                AppacitiveId = workItem.ArticleId,
                PropertyId = long.Parse(workItem.HotelId),
                SupplierFamily = workItem.SupplierFamily
            };
            var sqlHotelKey = _sqlDb.CreateHotelKey(key);
            var appacitiveHotelKey = _appacitive.CreateHotelKey(key);

            //1. Get the checkinout details from the appacitive
            List<HotelTimeDetail> inDetails = null;
            List<HotelTimeDetail> outDetails = null;
            _appacitive.GetCheckInOutDetails(appacitiveHotelKey, out inDetails, out outDetails);
            
            //2. Update/Add the checkinout details
            _sqlDb.SaveHotelInOutDetails(sqlHotelKey, inDetails, outDetails);
            return null;
        }

        protected override Task OnFault(WorkItem workItem, Exception ex)
        {
            throw new NotImplementedException();
        }
    }
}
