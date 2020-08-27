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
using System.Security.Cryptography.X509Certificates;

namespace Inventory_Management_v1._0._3
{
    public class SQLiteDataAccess
    {
        public static void insertData(firstSetupModel fsm)
        {
            using (IDbConnection sqlitecon = new SQLiteConnection(Helper.sqlConString("firstSetupConnection")))
            {
                sqlitecon.Execute("insert into storeDatabaseTbl (storeName, dbName, dbPassword, creatorName, timeCreated)" +
                    "values (@storeName , @dbName, @dbPassword, @fullName, datetime('now'))", fsm);
            }
        }
        public List<StoreData> GetSqliteData()
        {
            using (IDbConnection sqlitecon = new SQLiteConnection(Helper.sqlConString("firstSetupConnection")))
            {
                return sqlitecon.Query<StoreData>($"select * from storedatabaseTbl").ToList();
            }
        }


    }
}
