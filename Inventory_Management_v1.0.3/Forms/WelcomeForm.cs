using Inventory_Management_v1._0._3.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Inventory_Management_v1._0._3.Properties;

namespace Inventory_Management_v1._0._3.Forms
{
    public partial class WelcomeForm : Form
    {
        //Variables
        //List<StoreData> storedata = new List<StoreData>();
        private bool flag = true;
        private bool next = false;

        //Themes
        private void switchTheme()
        {
            if (Themes.ThemeStyle == "Dark")
            {
                Themes.ThemeStyle = "Light";
                Settings.Default["Themestyle"] = "Light";
            }
            else if (Themes.ThemeStyle == "Light")
            {
                Themes.ThemeStyle = "Dark";
                Settings.Default["Themestyle"] = "Dark";
            }
            Settings.Default.Save();
            Themes.UpdateThemeStyle(this, MinimizeBtn, ExitBtn, switchBtn, themeTooltip);
        }
        private void titlebarMouseUp()
        {
            TopPanel.panelMouseUp();
        }
        private void titlebarMouseDown(MouseEventArgs e)
        {
            TopPanel.panelMouseDown(e);
        }
        private void titlebarMouseMove(MouseEventArgs e)
        {
            if (TopPanel._dragging)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - TopPanel._start_point.X, p.Y - TopPanel._start_point.Y);
            }
        }

        //Methods
        private void formReset()
        {
            Themes.UpdateThemeStyle(this, MinimizeBtn, ExitBtn, switchBtn, themeTooltip);
            Helper.getStoreDb();
            storenameLbl.Text = Helper.storename;
        }

        //Form Start
        public WelcomeForm()
        {
            InitializeComponent();
            formReset();
        }

        private void switchBtn_Click(object sender, EventArgs e)
        {
            switchTheme();
        }

        private void WinformTtb_MouseDown(object sender, MouseEventArgs e)
        {
            titlebarMouseDown(e);
        }

        private void WinformTtb_MouseUp(object sender, MouseEventArgs e)
        {
            titlebarMouseUp();
        }

        private void WinformTtb_MouseMove(object sender, MouseEventArgs e)
        {
            titlebarMouseMove(e);
        }
    }
}
