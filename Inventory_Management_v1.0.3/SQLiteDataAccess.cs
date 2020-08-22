using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace Inventory_Management_v1._0._3
{
    public class SQLiteDataAccess
    {
        public static string LoadConnectionString(string id = "firstSetupConnection")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }

    }
}
