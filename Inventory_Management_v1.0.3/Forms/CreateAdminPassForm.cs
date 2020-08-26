using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Data.Common;
using Inventory_Management_v1._0._3.Properties;

namespace Inventory_Management_v1._0._3.Forms
{
    public partial class CreateAdminPassForm : Form
    {
        //Varibales
        private bool passwordaccept = false;
        private bool passwordmatch = false;
        private string dbpassword = "";
        private string firstname = "";
        private string lastname = "";
        private string middlename = "";
        private string dbname = "";
        private DateTime birthdate;
        private bool flag = true;
        private bool next;
        private bool back;


        //Themes & TitleBar
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
            Themes.UpdateThemeStyle(this, MinimizeBtn, ExitBtn, switchBtn, themeToolTip);
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
        private firstSetupModel setData()
        {
            return new firstSetupModel
            {
                //Store Db Information
                storeName = storenameLbl.Text,
                dbName = dbname,
                dbPassword = dbpassword,

                //Administrator
                firstName = firstname,
                lastName = lastname,
                middleName = middlename,
                emailAddress = emailLbl.Text,
                birthDate = birthdate,
                adminPassword = passwordTxt.Text
            };
        }

        public void getData(firstSetupModel fsm)
        {
            storenameLbl.Text = fsm.storeName;
            adminnameLbl.Text = fsm.fullName;
            emailLbl.Text = fsm.emailAddress;
            firstname = fsm.firstName;
            lastname = fsm.lastName;
            middlename = fsm.middleName;
            birthdate = fsm.birthDate;
            dbpassword = fsm.dbPassword;
            dbname = fsm.dbName;
        }        

        private void formReset()
        {
            Themes.UpdateThemeStyle(this, MinimizeBtn, ExitBtn, switchBtn, themeToolTip);
            firstSetupModel fsm = new firstSetupModel();
            getData(fsm);                    
            passwordTxt.Text = "";
            reenterTxt.Text = "";
            passwordvalidLbl.Text = "";
            reentervalidLbl.Text = "";
            nextBtn.Enabled = false;
            this.ActiveControl = passwordTxt;
            this.AcceptButton = nextBtn;
            this.Opacity = 0.1;
            fade.Start();
            next = false;
            next = false;
        }

        //Validations

        private void validate()
        {
            if (passwordTxt.Text != "" && reenterTxt.Text != "")
            {
                if (passwordaccept == true && passwordmatch == true)
                    nextBtn.Enabled = true;
                else
                    nextBtn.Enabled = false;
            }
            else
            {
                nextBtn.Enabled = false;
            }
        }
        private void passwordValidation()
        {
            if (passwordTxt.Text == "")
                passwordvalidLbl.Text = "";
            else
            {
                Regex rg = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,}$");

                if (rg.IsMatch(passwordTxt.Text))
                {
                    passwordvalidLbl.Text = "       ";
                    passwordvalidLbl.Image = Properties.Resources.icon_check_reverse_01;
                    passwordvalidLbl.ForeColor = Color.Green;
                    passwordaccept = true;
                }
                else
                {
                    passwordvalidLbl.Text = "Your password Should have atleast 1 UPPERCASE\n and 1 lowercase letter and a numeric character.";
                    passwordvalidLbl.ForeColor = Color.Orange;
                    passwordvalidLbl.Image = null;
                    passwordaccept = false;
                }
            }

            if (passwordaccept == true)
            {
                if (reenterTxt.Text == passwordTxt.Text)
                {
                    reentervalidLbl.Text = "            ";
                    reentervalidLbl.Image = Properties.Resources.icon_check_reverse_01;
                    passwordmatch = true;
                }
                else
                {
                    reentervalidLbl.Text = "Password must match.";
                    reentervalidLbl.ForeColor = Color.Red;
                    reentervalidLbl.Image = null;
                    passwordmatch = false;
                }
            }
            else
            {
                reentervalidLbl.Text = "Password must be valid.";
                reentervalidLbl.ForeColor = Color.Orange;
                reentervalidLbl.Image = null;
            }
            validate();
        }

        private void reenterValidation()
        {
            if (reenterTxt.Text == "")
                reentervalidLbl.Text = "";
            else
            {
                if (passwordaccept == true)
                {
                    if (reenterTxt.Text == passwordTxt.Text)
                    {
                        reentervalidLbl.Text = "            ";
                        reentervalidLbl.Image = Properties.Resources.icon_check_reverse_01;
                        reentervalidLbl.ForeColor = Color.Green;
                        passwordmatch = true;
                    }
                    else
                    {
                        reentervalidLbl.Text = "Password must match.";
                        reentervalidLbl.Image = null;
                        reentervalidLbl.ForeColor = Color.Red;
                        passwordmatch = false;
                    }
                }
                else
                {
                    reentervalidLbl.Text = "Password must be valid.";
                    reentervalidLbl.ForeColor = Color.Orange;
                    reentervalidLbl.Image = null;
                }
            }
            validate();
        }

        //Form Start
        public CreateAdminPassForm()
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

        private void passwordTxt_TextChanged(object sender, EventArgs e)
        {
            passwordValidation();
        }

        private void reenterTxt_TextChanged(object sender, EventArgs e)
        {
            reenterValidation();
        }

        private void nextBtn_Click(object sender, EventArgs e)
        {
            flag = false;
            fade.Start();
            next = true;
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
                if (next)
                {
                    if (this.Opacity > 0.0)
                    {
                        this.Opacity -= 0.2;
                    }
                    else
                    {
                        fade.Stop();
                        firstSetupModel fsm = setData();
                        FirstSetupSummaryForm next = new FirstSetupSummaryForm();
                        next.getData(fsm);
                        this.Close();
                        next.Show();
                    }
                }
                if (back)
                {
                    if (this.Opacity > 0.0)
                    {
                        this.Opacity -= 0.2;
                    }
                    else
                    {
                        fade.Stop();
                        firstSetupModel fsm = setData();
                        AdminaccountForm back = new AdminaccountForm();
                        back.getData(fsm);
                        this.Close();
                        back.Show();
                    }
                }
            }
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            flag = false;
            fade.Start();
            back = true;
        }

        private void showpassBtn_Click(object sender, EventArgs e)
        {
            if (passwordTxt.PasswordChar == '•')
            {
                passwordTxt.PasswordChar = '\0';
            }
            else
            {
                passwordTxt.PasswordChar = '•';
            }
        }
    }
}
