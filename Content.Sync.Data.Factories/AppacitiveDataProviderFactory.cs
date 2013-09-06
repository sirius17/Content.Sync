using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ContentUpdate.Hotel.Core.Interfaces;

namespace Content.Sync.Data.Factories
{
    public static class AppacitiveDataProviderFactory
    {
        private static readonly ReaderWriterLockSlim Lock = new ReaderWriterLockSlim();
        private static IDatabaseManager _provider = null;

        public static IDatabaseManager GetDatabaseManager()
        {
            if (_provider != null)
            {
                return _provider;
            }
            Lock.EnterReadLock();
            try
            {
                if (_provider == null)
                {
                    _provider = new ContentUpdate.Hotel.DAL.Appacitive.DatabaseManager();
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
