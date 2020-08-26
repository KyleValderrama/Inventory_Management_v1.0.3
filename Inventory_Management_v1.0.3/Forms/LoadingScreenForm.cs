using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inventory_Management_v1._0._3.Forms
{
    public partial class LoadingScreenForm : Form
    {
        private bool flag = true;
        private bool databaseExist;
        public LoadingScreenForm()
        {
            InitializeComponent();         

            if (Themes.ThemeStyle == "Dark")
            {
                BackColor = Color.FromArgb(37, 37, 38);
                foreach (Control c in this.Controls)
                {
                    Themes.ThemeDark(c);
                }
            }
            else
            {
                BackColor = Color.WhiteSmoke;
                foreach (Control c in this.Controls)
                {
                    Themes.ThemeLight(c);
                }
            }
            Load.Start();
            this.Opacity = 0.1;
            fade.Start();
            Helper.getStoreDb();
            
        }

        private void fade_Tick(object sender, EventArgs e)
        {
            if (flag)
            {
                if (this.Opacity <= 1.0)
                {
                    this.Opacity += 0.2;
                }
                else
                {
                    fade.Stop();
                }
            }
            else
            {
                fade.Start();
                if (this.Opacity > 0.0)
                {
                    this.Opacity -= 0.2;
                }
                else
                {
                    if (databaseExist)
                    {
                        fade.Stop();
                        LoginForm next = new LoginForm();
                        next.Show();
                        this.Hide();
                    }
                    else
                    {
                        fade.Stop();
                        RegisterstoreForm next = new RegisterstoreForm();
                        next.Show();
                        this.Hide();
                    }
                }
            }
        }

        private void Load_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value < 100)
                progressBar1.Value += 1;
            else
            {
                Load.Stop();
                flag = false;
            }

            if (progressBar1.Value == 25)
            {
                bunifuCustomLabel3.Text = "Gathering Information";
                if (Helper.storedata.Count() > 0)
                {
                    databaseExist = true;
                }
                else
                {
                    databaseExist = false;
                }
            }
            if (progressBar1.Value == 50)
            {
                bunifuCustomLabel1.Text = "Securing Network Database Access";
            }
            if (progressBar1.Value == 10)
            {
                bunifuCustomLabel1.Text = "Loading Dependecies";
            }
            if (progressBar1.Value == 20)
            {
                bunifuCustomLabel1.Text = "Connecting to Server";
            }
        }
    }
}
