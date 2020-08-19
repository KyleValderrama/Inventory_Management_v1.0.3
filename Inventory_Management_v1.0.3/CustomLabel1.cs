using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.ComponentModel;

namespace Inventory_Management_v1._0._3
{
    public class CustomLabel1 : System.Windows.Forms.Label
    {
        public void CustomLabel()
        {
            this.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Bold);
        }
    }
}
