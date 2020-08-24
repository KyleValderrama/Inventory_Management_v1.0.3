using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inventory_Management_v1._0._3
{
    public class firstSetupModel
    {
        //RegisterStoreForm
        //public int storeNameId { get; set; }
        public string storeName { get; set; }
        public string dbPassword { get; set; }
        public string dbName { get; set; }


        //AdminaccountForm
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string middleName { get; set; }
        public DateTime birthDate { get; set; }
        public string emailAddress { get; set; }
        public string adminPassword { get; set; }

        public string fullName
        {
            get
            {
                return $"{lastName}, {firstName} {middleName}";
            }
        }
    }
}
