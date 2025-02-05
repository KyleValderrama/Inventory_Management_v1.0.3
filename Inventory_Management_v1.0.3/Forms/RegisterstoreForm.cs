﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Inventory_Management_v1._0._3;
using System.Runtime.Remoting.Messaging;
using Inventory_Management_v1._0._3.Properties;

namespace Inventory_Management_v1._0._3
{
    public partial class RegisterstoreForm : Form
    {
        //Variable Declarations
        private bool passwordmatch = false;
        private bool passwordaccept = false;
        private bool flag = true;
        private string firstname;
        private string lastname;
        private string middlename;
        private DateTime birthdate;
        private string email;
       

        //Reset Form
        private void formReset()
        {
            storedbnameLbl.Text = "";
            storenameTxt.Text = "";
            passwordvalidLbl.Text = "";
            reenterLbl.Text = "";
            passwordTxt.Text = "";
            reenterTxt.Text = "";
            this.ActiveControl = storenameTxt;
            nextBtn.Enabled = false;
            this.AcceptButton = nextBtn;
            Themes.UpdateThemeStyle(this, MinimizeBtn, ExitBtn, switchBtn, themeToolTip);
            this.Opacity = 0.1;
            fade.Start();

        }

        // Themes & Custom Titlebar
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
        public void getData(firstSetupModel fsm)
        {
            storenameTxt.Text = fsm.storeName;
            firstname = fsm.firstName;
            lastname = fsm.lastName;
            middlename = fsm.middleName;
            email = fsm.emailAddress;
            birthdate = fsm.birthDate;
        }
        private firstSetupModel setData()
        {
            return new firstSetupModel
            {
                storeName = storenameTxt.Text,
                dbName = storedbnameLbl.Text,
                dbPassword = passwordTxt.Text,
                firstName = firstname,
                lastName = lastname,
                middleName = middlename,
                emailAddress = email,
                birthDate = birthdate
            };
        }
        //Validations
        private void validate()
        {
            if (storenameTxt.Text != "" && passwordTxt.Text != "" && reenterTxt.Text != "")
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
                    reenterLbl.Text = "            ";
                    reenterLbl.Image = Properties.Resources.icon_check_reverse_01;
                    passwordmatch = true;
                }
                else
                {
                    reenterLbl.Text = "Password must match.";
                    reenterLbl.ForeColor = Color.Red;
                    reenterLbl.Image = null;
                    passwordmatch = false;
                }
            }
            else
            {
                reenterLbl.Text = "Password must be valid.";
                reenterLbl.ForeColor = Color.Orange;
                reenterLbl.Image = null;
            }
            validate();
        }

        private void storenameValidation()
        {
            if (storenameTxt.Text == "")
                storedbnameLbl.Text = "";
            else
            {
                if (storedbnameLbl.Text.Length > 2)
                    storedbnameLbl.Text = storedbnameLbl.Text.Substring(0, storedbnameLbl.Text.Length - 2);
            }
            validate();
        }

        private void reenterValidation()
        {
            if (reenterTxt.Text == "")
                reenterLbl.Text = "";
            else
            {
                if (passwordaccept == true)
                {
                    if (reenterTxt.Text == passwordTxt.Text)
                    {
                        reenterLbl.Text = "            ";
                        reenterLbl.Image = Properties.Resources.icon_check_reverse_01;
                        passwordmatch = true;
                    }
                    else
                    {
                        reenterLbl.Text = "Password must match.";
                        reenterLbl.ForeColor = Color.Red;
                        passwordmatch = false;
                        reenterLbl.Image = null;
                    }
                }
                else
                {
                    reenterLbl.Text = "Password must be valid.";
                    reenterLbl.ForeColor = Color.Orange;
                    reenterLbl.Image = null;
                }
            }
            validate();
        }
        
        //Form Start
        public RegisterstoreForm()
        {
            InitializeComponent();
            formReset();
                     
        }
        private void RegisterstoreForm_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
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
        private void storenameTxt_TextChanged(object sender, EventArgs e)
        {
            storedbnameLbl.Text = storenameTxt.Text.ToLower();
            validate();
        }

        private void storedbnameLbl_TextChanged(object sender, EventArgs e)
        {
            storedbnameLbl.Text = storedbnameLbl.Text.Replace(" ", String.Empty);
        }

        private void storenameTxt_Leave(object sender, EventArgs e)
        {
            storedbnameLbl.Text = storedbnameLbl.Text + "db";
            validate();
        }

        private void storenameTxt_Enter(object sender, EventArgs e)
        {
            storenameValidation();
        }

        private void passwordTxt_TextChanged(object sender, EventArgs e)
        {
            passwordValidation();
        }

        private void reenterTxt_TextChanged_1(object sender, EventArgs e)
        {
            reenterValidation();
        }

        private void nextBtn_Click(object sender, EventArgs e)
        {
            flag = false;
            fade.Start();                     
        }
        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }
        private void fadeIn_Tick(object sender, EventArgs e)
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
                if (this.Opacity > 0.0)
                {
                    this.Opacity -= 0.2;
                }
                else
                {
                    AdminaccountForm next = new AdminaccountForm();
                    firstSetupModel fsm = setData();
                    next.getData(fsm);
                    fade.Stop();
                    this.Close();
                    next.Show();
                }
            }
        }

        private void showpassBtn_Click(object sender, EventArgs e)
        {
            /*
            if (passwordTxt.UseSystemPasswordChar == true)
            {
                passwordTxt.UseSystemPasswordChar = false;
            }
            else
            {
                passwordTxt.UseSystemPasswordChar = true;
            }
            */
            if(passwordTxt.PasswordChar == '•')
            {
                passwordTxt.PasswordChar = '\0';
            }
            else
            {
                passwordTxt.PasswordChar = '•';
            }

        }

        private void showreenterBtn_Click(object sender, EventArgs e)
        {
            /*
            if (reenterTxt.UseSystemPasswordChar == true)
            {
                reenterTxt.UseSystemPasswordChar = false;
            }
            else
            {
                reenterTxt.UseSystemPasswordChar = true;
            }*/

        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            
        }
    }   
}

