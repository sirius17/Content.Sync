using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Content.Sync.Data.SqlServer.DataStore
{
    public class DataConfiguration
    {
        public static string ReadDatabaseConnection
        {
            get
            {
                var connection = ConfigurationManager.ConnectionStrings["HotelCore.Read"];
                return connection == null ? string.Empty : connection.ConnectionString;
            }
        }

        public static string WriteDatabaseConnection
        {
            get
            {
                var connection = ConfigurationManager.ConnectionStrings["HotelCore.Write"];
                return connection == null ? string.Empty : connection.ConnectionString;
            }
        }
    }
}
