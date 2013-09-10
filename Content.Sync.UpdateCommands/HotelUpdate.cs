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
    public class HotelUpdate : HotelUpdateCommand
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
            if (workItem.ChangeAction != ChangeActionType.Delete)
            {
                //1. Get the hotel article from the appacitive
                HotelProperty changedHotel = _appacitive.GetPrimaryContent(_appacitive.CreateHotelKey(key));

                //2. If hotel not found in the database then insert hotel else update the hotel data.
                //_sqlDb.SaveHotelAndDetails(changedHotel);
            }
            else
            {
                //Disable hotel
                _sqlDb.DisableHotel(_sqlDb.CreateHotelKey(key));
            }
            return null;
        }

        protected override Task OnFault(WorkItem workItem, Exception ex)
        {
            throw new NotImplementedException();
        }
    }
}
