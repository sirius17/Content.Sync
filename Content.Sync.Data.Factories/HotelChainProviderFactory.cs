using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Content.Sync.Data.Interfaces;
using Content.Sync.Data.SqlServer;

namespace Content.Sync.Data.Factories
{
    public static class HotelChainProviderFactory
    {
        private static readonly ReaderWriterLockSlim Lock = new ReaderWriterLockSlim();
        private static IHotelChainProvider _provider = null;

        public static IHotelChainProvider GetHotelChainDataProvider()
        {
            if (_provider != null)
                return _provider;
            Lock.EnterReadLock();
            try
            {
                if (_provider == null)
                {
                    _provider = new HotelChainProvider();
                }
            }
            finally
            {
                Lock.ExitReadLock();
            }
            return _provider;
        }
    }
}
