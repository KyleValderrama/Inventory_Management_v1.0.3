using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using Bunifu.Framework.UI;
using System.Runtime.CompilerServices;
using MetroFramework.Drawing;
using MetroFramework.Controls;
using System.Runtime.Remoting.Channels;
using System.Management.Instrumentation;
using Inventory_Management_v1;

namespace Inventory_Management_v1._0._3
{
    public static class Themes
    {
        public static void ThemeDark(Control myControl)
        {
            if(myControl is CustomLabel1)
                myControl.ForeColor = Color.White;
            if (myControl is BunifuCustomLabel)
                myControl.ForeColor = Color.Gray;
            if (myControl is MetroPanel)
                myControl.BackColor = Color.FromArgb(64,64,66);
            if (myControl is TextBox)
            {
                myControl.ForeColor = Color.White;
                myControl.BackColor = Color.FromArgb(64, 64, 66);
            }

                
 
            foreach (Control subC in myControl.Controls)
            {
                    ThemeDark(subC);
            }
        }
        public static void UpdateThemeDark(Form thisForm, Button btnMin, Button btnExit)
        {
            thisForm.BackColor = Color.FromArgb(37, 37, 38);
            btnMin.Image = Properties.Resources.minimize_icon_01;
            btnExit.Image = Properties.Resources.close_icon_01;
            btnMin.FlatAppearance.MouseOverBackColor = Color.FromArgb(63, 63, 65);
            btnExit.FlatAppearance.MouseOverBackColor = Color.FromArgb(63, 63, 65);
            btnMin.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 122, 204);
            btnExit.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 122, 204);
            foreach (Control c in thisForm.Controls)
            {
                    ThemeDark(c);
            }

        }
        
        public static void ThemeLight(Control myControl)
        {
            if (myControl is CustomLabel1)
                myControl.ForeColor = Color.Black;
            if (myControl is BunifuCustomLabel)
                myControl.ForeColor = Color.Gray;
            if (myControl is MetroPanel)
                myControl.BackColor = Color.Gainsboro;
            if (myControl is TextBox)
            {
                myControl.ForeColor = Color.Black;
                myControl.BackColor = Color.Gainsboro;
            }
           
            foreach (Control subC in myControl.Controls)
            {
                ThemeLight(subC);
            }
        }
        public static void UpdateThemeLight(Form thisForm, Button btnMin, Button btnExit)
        {
            thisForm.BackColor = Color.WhiteSmoke;
            btnMin.Image = Properties.Resources.minimize_icon_black_01;
            btnExit.Image = Properties.Resources.close_icon_black_01;
            btnMin.FlatAppearance.MouseOverBackColor = Color.LightGray;
            btnExit.FlatAppearance.MouseOverBackColor = Color.LightGray;
            btnMin.FlatAppearance.MouseDownBackColor = Color.FromArgb(202,202,203);
            btnExit.FlatAppearance.MouseDownBackColor = Color.FromArgb(241,112,122);

            foreach (Control c in thisForm.Controls)
            {
                ThemeLight(c);
            }
        }


        public static string ThemeStyle = "Light";
        
        public static void UpdateThemeStyle(Form thisForm, Button btnMin, Button btnExit)
        {
            
            if (ThemeStyle == "Light")
            {
                UpdateThemeLight(thisForm, btnMin, btnExit);
            }
            else
                UpdateThemeDark(thisForm, btnMin, btnExit);
        }

    }
}
