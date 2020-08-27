using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Inventory_Management_v1._0._3.Models;
using Microsoft.SqlServer.TransactSql.ScriptDom;

namespace Inventory_Management_v1._0._3
{
    public class ServerDataAccess
    {
        public static void insertDatabase(firstSetupModel fsm)
        {
            using (IDbConnection mastercon = new SqlConnection(Helper.masterConString))
            {
                mastercon.Execute($"create database {fsm.dbName}");
            }
        }
        public static void insertStoreTable()
        {
            Helper.getStoreDb();
            using (IDbConnection storecon = new SqlConnection(Helper.storeConString))
            {

                storecon.Execute($"USE {Helper.storedbname} " +
                                 $"create table userAccounts " +
                                 $"(userId int PRIMARY KEY IDENTITY, " +
                                 $"firstName nvarchar(50), " +
                                 $"lastName nvarchar(50), " +
                                 $"middleName nvarchar(50), " +
                                 $"birthDate datetime, " +
                                 $"emailAddress nvarchar(50), " +
                                 $"userPrivilege nvarchar(30), " +
                                 $"timeCreated datetime);");
            }
        }
        public static void createStoredProcedure()
        {
            Helper.getStoreDb();
            using (IDbConnection storecon = new SqlConnection(Helper.masterConString))
            {
                var sqlQuery = new StringBuilder();
                sqlQuery.AppendLine($"USE {Helper.storedbname}");
                sqlQuery.AppendLine("go");
                sqlQuery.AppendLine("create procedure spUserAccounts_InsertAdmin");
                sqlQuery.AppendLine("@firstName nvarchar(50), @lastName nvarchar(50), @middleName nvarchar(50), @birthDate datetime, @emailAddress nvarchar(50)");
                sqlQuery.AppendLine("as");
                sqlQuery.AppendLine("begin");
                sqlQuery.AppendLine("insert into userAccounts (firstName, lastName, middleName, birthDate, emailAddress, userPrivilege, timeCreated) ");
                sqlQuery.Append("values ");
                sqlQuery.AppendLine("(@firstName, @lastName, @middlename, @birthDate, @emailAddress, 'admin', GETDATE())");
                sqlQuery.AppendLine("end");
                storecon.Execute(sqlQuery.ToString());
            }
        }
        public static void insertUserAccountAdmin(firstSetupModel fsm)
        {
            using (IDbConnection storecon = new SqlConnection(Helper.storeConString))
            {
                storecon.Execute($"USE {fsm.dbName} " +
                                 $"exec spUserAccounts_InsertAdmin " +
                                 $"@firstName, " +
                                 $"@lastName, " +
                                 $"@middleName, " +
                                 $"@birthDate, " +
                                 $"@emailAddress",
                                 new { firstName = fsm.firstName, 
                                       lastName = fsm.lastName,
                                       middleName = fsm.middleName,
                                       birthDate = fsm.birthDate,
                                       emailAddress = fsm.emailAddress } );
            }
        } 
    }
}
