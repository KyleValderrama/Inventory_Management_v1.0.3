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
using System.Runtime.InteropServices;
using Inventory_Management_v1._0._3.Controls;

namespace Inventory_Management_v1._0._3
{
    public static class Themes
    {
        [DllImport("user32.dll")]
        static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, Int32 wParam, Int32 lParam);
        private const Int32 CB_SETITEMHEIGHT = 0x153;

        public static void SetComboBoxHeight(IntPtr comboBoxHandle, Int32 comboBoxDesiredHeight)
        {
            SendMessage(comboBoxHandle, CB_SETITEMHEIGHT, -1, comboBoxDesiredHeight);
        }

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
            if (myControl is CustomButtonBack)
            {
                ((CustomButtonBack)myControl).FlatAppearance.MouseOverBackColor = Color.FromArgb(63, 63, 65);
                ((CustomButtonBack)myControl).FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 122, 204);
                ((CustomButtonBack)myControl).Image = Properties.Resources.icon_back_01;
            }


            foreach (Control subC in myControl.Controls)
            {
                    ThemeDark(subC);
            }
        }


        public static void ThemeLightbtn(CustomButtonBack myControl)
        {
            if (myControl is CustomButtonBack)
            {
                
            }
        }
        public static void UpdateThemeDark(Form thisForm, Button btnMin, Button btnExit, ToolTip ttipText, Button btnSwitch)
        {
            thisForm.BackColor = Color.FromArgb(37, 37, 38);
            btnMin.Image = Properties.Resources.minimize_icon_01;
            btnExit.Image = Properties.Resources.close_icon_01;
            btnSwitch.Image = Properties.Resources.darkmode_icon_dark_01;
            btnMin.FlatAppearance.MouseOverBackColor = Color.FromArgb(63, 63, 65);
            btnExit.FlatAppearance.MouseOverBackColor = Color.FromArgb(63, 63, 65);
            btnSwitch.FlatAppearance.MouseOverBackColor = Color.FromArgb(63, 63, 65);
            btnMin.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 122, 204);
            btnExit.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 122, 204);
            btnSwitch.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 122, 204);
            ttipText.SetToolTip(btnSwitch, "Switch To Light Mode");
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

            if(myControl is CustomComboBox)
            {
                myControl.ForeColor = Color.Black;
                myControl.BackColor = Color.Gainsboro;
            }

            if (myControl is CustomButtonBack)
            {
                ((CustomButtonBack)myControl).FlatAppearance.MouseOverBackColor = Color.LightGray;
                ((CustomButtonBack)myControl).FlatAppearance.MouseDownBackColor = Color.FromArgb(202, 202, 203);
                ((CustomButtonBack)myControl).Image = Properties.Resources.icon_back_black_01;
            }

            foreach (Control subC in myControl.Controls)
            {
                ThemeLight(subC);
            }
        }
        public static void UpdateThemeLight(Form thisForm, Button btnMin, Button btnExit, ToolTip ttipText, Button btnSwitch)
        {
            thisForm.BackColor = Color.WhiteSmoke;
            btnMin.Image = Properties.Resources.minimize_icon_black_01;
            btnExit.Image = Properties.Resources.close_icon_black_01;
            btnSwitch.Image = Properties.Resources.darkmode_icon_01;
            btnMin.FlatAppearance.MouseOverBackColor = Color.LightGray;
            btnExit.FlatAppearance.MouseOverBackColor = Color.LightGray;
            btnSwitch.FlatAppearance.MouseOverBackColor = Color.LightGray;
            btnMin.FlatAppearance.MouseDownBackColor = Color.FromArgb(202,202,203);
            btnExit.FlatAppearance.MouseDownBackColor = Color.FromArgb(202, 202, 203);
            ttipText.SetToolTip(btnSwitch, "Switch To Dark Mode");
            foreach (Control c in thisForm.Controls)
            {
                ThemeLight(c);
            }

        }


        public static string ThemeStyle = "Light";
        
        public static void UpdateThemeStyle(Form thisForm, Button btnMin, Button btnExit, Button btnSwitch, ToolTip ttip)
        {
            
            if (ThemeStyle == "Light")
            {
                UpdateThemeLight(thisForm, btnMin, btnExit, ttip, btnSwitch);
            }
            else
                UpdateThemeDark(thisForm, btnMin, btnExit, ttip, btnSwitch);
        }

    }
}
