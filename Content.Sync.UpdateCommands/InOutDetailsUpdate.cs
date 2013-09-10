using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Content.Sync.Clarifi;
using Content.Sync.Data.Factories;
using Content.Sync.Data.Interfaces;
using ContentUpdate.Hotel.Core.Interfaces;
using ContentUpdate.Hotel.Model;

namespace Content.Sync.UpdateCommands
{
    public class InOutDetailsUpdate : HotelUpdateCommand
    {
        private readonly IDatabaseManager _appacitive = AppacitiveDataProviderFactory.GetDatabaseManager();
        private readonly ICheckInOutDetailsDataProvider _inOutDetailsProvider = CheckInOutDetailsDataFactory.GetChechInOutDetailsDataProvider();

        protected override Task ProcessHotelWorkItem(WorkItem workItem, System.Threading.CancellationToken cancellationToken)
        {
            var key = new HotelProperty()
            {
                AppacitiveId = workItem.ArticleId,
                PropertyId = long.Parse(workItem.HotelId),
                SupplierFamily = workItem.SupplierFamily
            };
            var appacitiveHotelKey = _appacitive.CreateHotelKey(key);

            List<HotelTimeDetail> inDetails = null;
            List<HotelTimeDetail> outDetails = null;
            //1. Get the checkinout details from the appacitive
            _appacitive.GetCheckInOutDetails(appacitiveHotelKey, out inDetails, out outDetails);
            if (inDetails != null || outDetails != null)
            {
                //2. Update/Add the checkinout details
                _inOutDetailsProvider.AddOrUpdate(workItem.HotelId, workItem.SupplierFamily, inDetails, outDetails);
            }
            else
            {
                _inOutDetailsProvider.Delete(workItem.HotelId, workItem.SupplierFamily);
            }
            return null;
        }

        protected override Task OnFault(WorkItem workItem, Exception ex)
        {
            throw new NotImplementedException();
        }
    }
}
