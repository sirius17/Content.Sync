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
    public class ImageUpdate : HotelUpdateCommand
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

            //1. Get images from the appacitive for the hotelarticle id.
            var sourceImages = _appacitive.GetImagesForHotel(appacitiveHotelKey);

            //2. Get images from the client database
            var destImages = _sqlDb.GetImagesForHotel(sqlHotelKey);

            //3. compare these two lists and update the client database accordingly
            sourceImages = sourceImages ?? new List<HotelImage>();
            destImages = destImages ?? new List<HotelImage>();
            //3.1 Add new hotel images
            foreach (var sourceImage in sourceImages)
            {
                var foundIndex = destImages.FindIndex(i => i.Equals(sourceImage));
                if (foundIndex == -1)
                {
                    _sqlDb.SaveImage(sqlHotelKey, sourceImage);
                }
                else
                {
                    destImages.RemoveAt(foundIndex);
                }
            }
            //3.2 delete hotel images
            foreach (var destImage in destImages)
            {
                _sqlDb.DeleteImage(destImage.Id, destImage.SupplierCode, destImage.UniqueImageFileName);
            }
            return null;
        }

        protected override Task OnFault(WorkItem workItem, Exception ex)
        {
            throw new NotImplementedException();
        }
    }
}
