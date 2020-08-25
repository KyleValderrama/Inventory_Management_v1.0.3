using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Net;
using System.Data;
using Dapper;
using Inventory_Management_v1._0._3.Models;

namespace Inventory_Management_v1._0._3
{
    public class SQLiteDataAccess
    {
        public static string LoadConnectionString(string id = "firstSetupConnection")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
        public static void getData(firstSetupModel fsm)
        {
            using (IDbConnection sqlitecon = new SQLiteConnection(LoadConnectionString()))
            {
                sqlitecon.Execute("insert into storeDatabaseTbl (storeName, dbName, dbPassword, creatorName, timeCreated)" +
                    "values (@storeName , @dbName, @dbPassword, @fullName, datetime('now'))", fsm);
            }
        }

        public static List<StoreData> loadData()
        {
            using (IDbConnection sqlitecon = new SQLiteConnection(LoadConnectionString()))
            {
                var output = sqlitecon.Query<StoreData>("select * from storeDatabaseTbl", new DynamicParameters());
                return output.ToList();
            }
        }
    }
}
