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
    public class NearbyAttractionsUpdate : HotelUpdateCommand
    {
        private readonly IDatabaseManager _appacitive = AppacitiveDataProviderFactory.GetDatabaseManager();
        private readonly IDatabaseManager _sqlDb = SqlDataProviderFactory.GetDatabaseManager();
        protected override Task ProcessHotelWorkItem(WorkItem workItem, System.Threading.CancellationToken cancellationToken)
        {
            var key = new HotelProperty()
            {
                AppacitiveId = workItem.HotelArticleId,
                PropertyId = long.Parse(workItem.HotelId),
                SupplierFamily = workItem.SupplierFamily
            };
            var sqlHotelKey = _sqlDb.CreateHotelKey(key);
            var appacitiveHotelKey = _appacitive.CreateHotelKey(key);

            //1. Get nearby hotel attractions from the appacitive for the hotelarticle id.
            var sourceAttractions = _appacitive.GetAreaAttractions(appacitiveHotelKey);

            //2. Get nearby hotel attractions from the client database
            var destAttractions = _sqlDb.GetAreaAttractions(sqlHotelKey);

            //3. compare these two lists and update the client database accordingly
            sourceAttractions = sourceAttractions ?? new List<AreaAttraction>();
            destAttractions = destAttractions ?? new List<AreaAttraction>();
            //3.1 Add or Update hotel attractions
            foreach (var sourceAttraction in sourceAttractions)
            {
                var foundIndex = destAttractions.FindIndex(i => i.Equals(sourceAttraction));
                if (foundIndex == -1)
                {
                    _sqlDb.SaveAreaAttraction(sqlHotelKey, sourceAttraction); // Add
                }
                else
                {
                    if (destAttractions[foundIndex].IsUpdated(sourceAttraction))
                    {
                        sourceAttraction.Id = destAttractions[foundIndex].Id;
                        _sqlDb.SaveAreaAttraction(sqlHotelKey, sourceAttraction); //Update
                    }
                    destAttractions.RemoveAt(foundIndex);
                }
            }
            //3.2 delete missing hotel nearby attractions
            foreach (var destAttraction in destAttractions)
            {
                _sqlDb.DeleteAreaAttraction(sqlHotelKey, destAttraction);
            }
            return null;
        }

        protected override Task OnFault(WorkItem workItem, Exception ex)
        {
            throw new NotImplementedException();
        }
    }
}
