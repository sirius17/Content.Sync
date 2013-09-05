using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Content.Sync.Clarifi;
using Content.Sync.Data.Factories;
using ContentUpdate.Hotel.Core.Interfaces;

namespace Content.Sync.UpdateCommands
{
    public class HotelUpdate : HotelUpdateCommand
    {
        private readonly IDatabaseManager _appacitive = AppacitiveDataProviderFactory.GetDatabaseManager();
        private readonly IDatabaseManager _sqlDb = AppacitiveDataProviderFactory.GetDatabaseManager();
        protected override Task ProcessHotelWorkItem(WorkItem workItem, System.Threading.CancellationToken cancellationToken)
        {
            //1. Get the hotel article from the appacitive
            
            //2. Get the hotel row from the client database
            //3. If hotel not found in the database then insert hotel else update the hotel data.
            throw new NotImplementedException();
        }

        protected override Task OnFault(WorkItem workItem, Exception ex)
        {
            throw new NotImplementedException();
        }
    }
}
