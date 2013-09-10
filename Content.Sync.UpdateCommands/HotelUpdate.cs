//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Runtime.InteropServices;
//using System.Text;
//using System.Threading.Tasks;
//using Content.Sync.Clarifi;
//using Content.Sync.Data.Factories;
//using Content.Sync.Data.Interfaces;
//using ContentUpdate.Hotel.Core.Interfaces;
//using ContentUpdate.Hotel.Model;
//using System.Threading;

//namespace Content.Sync.UpdateCommands
//{
//    public class HotelUpdate : HotelUpdateCommand
//    {
//        private readonly IDatabaseManager _appacitive = AppacitiveDataProviderFactory.GetDatabaseManager();
//        private readonly IHotelDataProvider _hotelProvider = HotelDataProviderFactory.GetHotelDataProvider();
//        private readonly IHotelChainProvider _hotelChainProvider = HotelChainProviderFactory.GetHotelChainDataProvider();
//        protected override Task ProcessHotelWorkItem(HotelWorkItem workItem, CancellationToken cancellationToken)
//        {
//            var key = new HotelProperty()
//            {
//                AppacitiveId = workItem.ArticleId,
//                PropertyId = long.Parse(workItem.HotelId),
//                SupplierFamily = workItem.SupplierFamily
//            };
//            if (workItem.ChangeAction == ChangeActionType.Delete)
//            {
//                //1. Get the hotel article from the appacitive
//                HotelProperty changedHotel = _appacitive.GetPrimaryContent(_appacitive.CreateHotelKey(key));

//                //2. Update the client database with respective values.
//                if (changedHotel != null && changedHotel.PrimaryContent != null)
//                {
//                    if (changedHotel.PrimaryContent.Chain != null)
//                    {
//                        _hotelChainProvider.AddChain(changedHotel.PrimaryContent.Chain);
//                    }
//                    switch (workItem.ChangeAction)
//                    {
//                        case ChangeActionType.Add:
//                            _hotelProvider.AddHotel(changedHotel);
//                            break;
//                        case ChangeActionType.Update:
//                            _hotelProvider.UpdateHotel(changedHotel);
//                            break;
//                    }
//                }
//            }
//            else
//            {
//                //3. Disable hotel
//                _hotelProvider.DisableHotel(workItem.HotelId, workItem.SupplierFamily);
//            }
//            return null;
//        }
//    }
//}
