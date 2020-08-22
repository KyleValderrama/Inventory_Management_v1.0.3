using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_Management_v1._0._3
{
    public class firstSetupModel
    {
        public string storeName { get; set; }
        public string dbPassword { get; set; }
        public string dbName { get; set; }

        public string GetStoreName()
        {
            return storeName;
        }

    }
}
