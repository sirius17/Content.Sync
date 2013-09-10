using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Content.Sync.Data.SqlServer.DataStore
{
    internal class HotelCoreContext : IDisposable
    {
        public static void UsingRead(Action<HotelCoreDataContext> action)
        {
            using (var context = new HotelCoreContext())
            {
                action(context.Read);
            }
        }

        public static void UsingRead(string connectionString, Action<HotelCoreDataContext> action)
        {
            using (var context = new HotelCoreContext(connectionString))
            {
                action(context.Read);
            }
        }

        public static void UsingWrite(Action<HotelCoreDataContext> action)
        {
            using (var context = new HotelCoreContext())
            {
                action(context.Write);
            }
        }

        public HotelCoreContext()
        {
            this.Read = new HotelCoreDataContext(DataConfiguration.ReadDatabaseConnection);
            this.Write = new HotelCoreDataContext(DataConfiguration.WriteDatabaseConnection);
        }

        public HotelCoreContext(string connectionString)
        {
            this.Read = new HotelCoreDataContext(connectionString);
            this.Write = new HotelCoreDataContext(connectionString);
        }

        public HotelCoreDataContext Read { get; private set; }
        public HotelCoreDataContext Write { get; private set; }

        #region IDisposable Members

        public void Dispose()
        {
            this.Read.Dispose();
            this.Write.Dispose();

        }

        #endregion
    }
}
