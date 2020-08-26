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
    public partial class LoaderForm : Form
    {
        //Variables
        private bool flag = true;
        private string firstname;
        private string lastname;
        private string middlename;
        private string dbname;
        private string storename;
        private string dbpassword;
        private string email;
        private string adminpassword;
        private DateTime birthdate;


        //Methods
        public void getData(firstSetupModel fsm)
        {
            //Store
            storename = fsm.storeName;
            dbname = fsm.dbName;
            dbpassword = fsm.dbPassword;

            //Admin
            firstname = fsm.firstName;
            lastname = fsm.lastName;
            middlename = fsm.middleName;
            birthdate = fsm.birthDate;
            adminpassword = fsm.adminPassword;
        }
        private firstSetupModel setData()
        {
            return new firstSetupModel
            {
                storeName = storename,
                dbName = dbname,
                birthDate = birthdate,
                emailAddress = email,
                dbPassword = dbpassword,
                adminPassword = adminpassword,
                firstName = firstname,
                lastName = lastname,
                middleName = middlename
            };
        }

        //Form Start
        public LoaderForm()
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

            if(progressBar1.Value == 25)
            {
                bunifuCustomLabel3.Text = "Creating Store Database";
            }
            if (progressBar1.Value == 50)
            {
                bunifuCustomLabel3.Text = "Securing Network Database Access";
            }
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
                    firstSetupModel fsm = setData();
                    SQLiteDataAccess.insertData(fsm);                   
                    fade.Stop();
                    this.Close();
                    WelcomeForm next = new WelcomeForm();
                    next.Show();
                }

            }
        }
    }
}
