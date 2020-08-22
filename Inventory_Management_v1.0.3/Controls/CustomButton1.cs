using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inventory_Management_v1._0._3
{
    public class CustomButton1 : System.Windows.Forms.Button
    {
       
        protected override void OnEnabledChanged(EventArgs e)
        {
            
            base.OnEnabledChanged(e);
            if (base.Enabled == true)
            {
                Enabled = true;
                base.ForeColor = Color.White;
                base.BackColor = Color.DodgerBlue;
                base.Cursor = Cursors.Hand;

            }
            else
            {
                this.ForeColor = Color.White;
                base.BackColor = Color.LightGray;
                base.Cursor = Cursors.No;
            }
        }

        


    }
}
