using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Content.Sync.Clarifi;
using Content.Sync.Data.Interfaces;
using Content.Sync.Data.SqlServer;
using AppacitiveDAL = ContentUpdate.Hotel.DAL.Appacitive;
using ContentUpdate.Hotel.Model;

namespace Content.Sync.UpdateCommands
{
    public class ActivityUpdate : HotelUpdateCommand
    {
        protected override Task ProcessHotelWorkItem(WorkItem workItem, System.Threading.CancellationToken cancellationToken)
        {
            //1. Get the activities from the appacitive using the hotel article id.
            //2. Get the activities from the client database using the hotelid and supplierfamily
            //3. Compare two above list and detect which all activities are added/deleted/updated
            //4. Update/delete/add activities into the client database.

            IKey hotelKey = new AppacitiveDAL.HotelKey() { HotelArticleId = workItem.ArticleId, HotelId = Convert.ToInt64(workItem.HotelId), SupplierFamily = workItem.SupplierFamily };
            IActivityDataProvider activityDataProvider = new ActivityDataProvider();

            // Get Appacitive activities by HotelArticleId
            List<HotelActivity> sourceActivities = new AppacitiveDAL.DatabaseManager().GetHotelActivities(hotelKey);

            // Get Client DB activities by HotelArticleId
            List<HotelActivity> destinationActivities = activityDataProvider.GetHotelActivities(hotelKey);

            foreach (var sourceActivity in sourceActivities)
            {
                HotelActivity activity = destinationActivities.Find(x => x.Equals(sourceActivity));
                if (activity == null)
                {
                    // New Hotel Activity 
                    activityDataProvider.InsertHotelActivity(hotelKey, sourceActivity);
                }
                else
                {
                    // Old Hotel Activity
                    if (!activity.IsUpdated(sourceActivity))
                        activityDataProvider.UpdateHotelActivity(hotelKey, sourceActivity);

                    destinationActivities.Remove(activity);
                }
            }

            destinationActivities.ForEach(x => activityDataProvider.DeleteHotelActivity(hotelKey, x));

            return null;
        }

        protected override Task OnFault(WorkItem workItem, Exception ex)
        {
            throw new NotImplementedException();
        }
    }
}
