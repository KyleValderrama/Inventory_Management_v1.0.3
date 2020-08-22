using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using Inventory_Management_v1._0._3.Forms;

namespace Inventory_Management_v1._0._3
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            Application.EnableVisualStyles();
            //DefaultFont = new System.Drawing.Font("Arial", 12);
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new CreateAdminPassForm());
        }
    }
}
