using Inventory_Management_v1._0._3.Forms;
using Inventory_Management_v1._0._3.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_Management_v1._0._3
{
    public static class Helper
    {
        public static List<StoreData> storedata = new List<StoreData>();
        public static string storedbname;
        public static string storename;
        public static string storeConString = $@"Server =.\POSSERVER; Database ={storedbname}; Trusted_Connection = True;";

        public static string sqlConString(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }
        public static void getStoreDb()
        {
            SQLiteDataAccess sq = new SQLiteDataAccess();
            storedata = sq.GetSqliteData();
            if(storedata.Count > 0)
            {
                storedbname = storedata[0].dbName.ToString();
                storename = storedata[0].storeName.ToString();
            }
        }

    }
}
