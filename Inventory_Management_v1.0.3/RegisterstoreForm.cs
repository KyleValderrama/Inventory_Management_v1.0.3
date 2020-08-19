using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;


namespace Inventory_Management_v1._0._3
{
    public partial class RegisterstoreForm : Form
    {
        private bool passwordmatch = false;
        private bool passwordaccept = false;

        //==============strings
        public static string storename = "";
        public static string password = "";
        public static string storedbname = "";

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

        //Form Start
        public RegisterstoreForm()
        {
            InitializeComponent();
            Themes.UpdateThemeStyle(this, MinimizeBtn, ExitBtn);
            storedbnameLbl.Text = "";
            storenameTxt.Text = "";
            passwordvalidLbl.Text = "";
            reenterLbl.Text = "";
            passwordTxt.Text = "";
            reenterTxt.Text = "";
            this.ActiveControl = storenameTxt;
            nextBtn.Enabled = false;

        }
        private void RegisterstoreForm_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Themes.ThemeStyle == "Dark")
                Themes.ThemeStyle = "Light";
            else if (Themes.ThemeStyle == "Light")
                Themes.ThemeStyle = "Dark";

            Themes.UpdateThemeStyle(this, MinimizeBtn, ExitBtn);
        }

        private void WinformTtb_MouseDown(object sender, MouseEventArgs e)
        {
            TopPanel.panelMouseDown(e);
        }
        private void WinformTtb_MouseUp(object sender, MouseEventArgs e)
        {
            TopPanel.panelMouseUp();
        }

        private void WinformTtb_MouseMove(object sender, MouseEventArgs e)
        {
            if (TopPanel._dragging)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - TopPanel._start_point.X, p.Y - TopPanel._start_point.Y);
            }

        }
        private void nxtBtn_MouseClick(object sender, MouseEventArgs e)
        {

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
            if (storenameTxt.Text == "")
                storedbnameLbl.Text = "";
            else
            {
                if (storedbnameLbl.Text.Length > 2)
                    storedbnameLbl.Text = storedbnameLbl.Text.Substring(0, storedbnameLbl.Text.Length - 2);
            }
            validate();
        }

        private void passwordTxt_TextChanged(object sender, EventArgs e)
        {
            if (passwordTxt.Text == "")
                passwordvalidLbl.Text = "";
            else
            {
                Regex rg = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,}$");

                if (rg.IsMatch(passwordTxt.Text))
                {
                    passwordvalidLbl.Text = "Password Accepted";
                    passwordvalidLbl.ForeColor = Color.Green;
                    passwordaccept = true;
                }
                else
                {
                    passwordvalidLbl.Text = "Your password Should have atleast 1 UPPERCASE\n and 1 lowercase letter and a numeric character.";
                    passwordvalidLbl.ForeColor = Color.Orange;
                    passwordaccept = false;
                }
            }

            if (passwordaccept == true)
            {
                if (reenterTxt.Text == passwordTxt.Text)
                {
                    reenterLbl.Text = "Password Confirmed";
                    reenterLbl.ForeColor = Color.Green;
                    passwordmatch = true;
                }
                else
                {
                    reenterLbl.Text = "Password must match.";
                    reenterLbl.ForeColor = Color.Red;
                    passwordmatch = false;
                }
            }
            else
            {
                reenterLbl.Text = "Password must be valid.";
                reenterLbl.ForeColor = Color.Orange;
            }
            validate();
        }

        private void reenterTxt_TextChanged(object sender, EventArgs e)
        {
            if (reenterTxt.Text == "")
                reenterLbl.Text = "";
            else
            {
                if (passwordaccept == true)
                {
                    if (reenterTxt.Text == passwordTxt.Text)
                    {
                        reenterLbl.Text = "Password Confirmed";
                        reenterLbl.ForeColor = Color.Green;
                        passwordmatch = true;
                    }
                    else
                    {
                        reenterLbl.Text = "Password must match.";
                        reenterLbl.ForeColor = Color.Red;
                        passwordmatch = false;
                    }
                }
                else
                {
                    reenterLbl.Text = "Password must be valid.";
                    reenterLbl.ForeColor = Color.Orange;
                }
            }
            validate();
        }

        private void reenterTxt_TextChanged_1(object sender, EventArgs e)
        {
            if (reenterTxt.Text == "")
                reenterLbl.Text = "";
            else
            {
                if (passwordaccept == true)
                {
                    if (reenterTxt.Text == passwordTxt.Text)
                    {
                        reenterLbl.Text = "Password Confirmed";
                        reenterLbl.ForeColor = Color.Green;
                        passwordmatch = true;
                    }
                    else
                    {
                        reenterLbl.Text = "Password must match.";
                        reenterLbl.ForeColor = Color.Red;
                        passwordmatch = false;
                    }
                }
                else
                {
                    reenterLbl.Text = "Password must be valid.";
                    reenterLbl.ForeColor = Color.Orange;
                }
            }
            validate();
        }

        private void nextBtn_Click(object sender, EventArgs e)
        {
            AdminaccountForm next = new AdminaccountForm();
            next.Show();
            this.Hide();
        }
    }   
}

