using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Security.Cryptography.X509Certificates;

namespace Inventory_Management_v1._0._3
{
    public partial class AdminaccountForm : Form
    {
        private void validate()
        {
            if (firstnamevalid == true && lastnamevalid == true && emailvalid == true)
                nextBtn.Enabled = true;
            else
                nextBtn.Enabled = false;
        }

        //validation
        public bool firstnamevalid = false;
        public bool lastnamevalid = false;
        public bool emailvalid = false;
        public void fillDay()
        {
            dayCmb.Items.Clear();
            if (monthCmb.SelectedIndex == 0 ||
                monthCmb.SelectedIndex == 2 ||
                monthCmb.SelectedIndex == 4 ||
                monthCmb.SelectedIndex == 6 ||
                monthCmb.SelectedIndex == 7 ||
                monthCmb.SelectedIndex == 9 ||
                monthCmb.SelectedIndex == 11)
            {
                for (int x = 1; x <= 31; x++)
                {
                    dayCmb.Items.Add(x);
                }
            }
            else if(monthCmb.SelectedIndex == 3 ||
                monthCmb.SelectedIndex == 5 ||
                monthCmb.SelectedIndex == 8 ||
                monthCmb.SelectedIndex == 10)
            {
                for (int x = 1; x <= 30; x++)
                {
                    dayCmb.Items.Add(x);
                }
            }
            else
            {
                for (int x = 1; x <= 29; x++)
                {
                    dayCmb.Items.Add(x);
                }
            }
        }
        public AdminaccountForm()
        {
            firstSetupModel fsm = new firstSetupModel();
            InitializeComponent();
            Themes.UpdateThemeStyle(this, MinimizeBtn, ExitBtn, switchBtn, themeToolTip);
            firstnameTxt.Text = "";
            lastnameTxt.Text = "";
            middlenameTxt.Text = "";
            emailTxt.Text = "";
            namevalidLbl.Text = "";
            storenameLbl.Text = fsm.GetStoreName();
            nextBtn.Enabled = false;
            monthCmb.Hide();
            dayCmb.Hide();
            yearCmb.Hide();
            monthCmb.DataSource = CultureInfo.InvariantCulture.DateTimeFormat.MonthNames.Take(12).ToList();
            monthCmb.SelectedIndex = DateTime.Now.Month - 1;
            yearCmb.DataSource = Enumerable.Range(1940, DateTime.Now.Year - 1940 + 1).ToList();
            yearCmb.SelectedItem = DateTime.Now.Year;
            dayCmb.SelectedItem = DateTime.Now.Day;
            this.AcceptButton = nextBtn;
        }

        private void firstnameTxt_TextChanged(object sender, EventArgs e)
        {
            if (firstnameTxt.Text != "")
            {
                if (lastnameTxt.Text == "")
                {
                    namevalidLbl.Text = "Fill-up Required Fields.";
                    namevalidLbl.ForeColor = Color.Orange;
                    lastnamevalid = false;
                }
                else
                {
                    namevalidLbl.Text = "Full Name : " + lastnameTxt.Text + ", " + firstnameTxt.Text + " " + middlenameTxt.Text;
                    namevalidLbl.ForeColor = Color.DodgerBlue;
                }
                firstnamevalid = true;
            }
            else
            {
                namevalidLbl.Text = "Fill-up Required Fields.";
                namevalidLbl.ForeColor = Color.Orange;
                firstnamevalid = false;
            }
            validate();
        }
        private void switchBtn_Click(object sender, EventArgs e)
        {
            if (Themes.ThemeStyle == "Dark")
                Themes.ThemeStyle = "Light";
            else if (Themes.ThemeStyle == "Light")
                Themes.ThemeStyle = "Dark";

            Themes.UpdateThemeStyle(this, MinimizeBtn, ExitBtn, switchBtn, themeToolTip);
        }
        private void ExitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBoxPanel1_Enter(object sender, EventArgs e )
        {

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

        private void ExitBtn_MouseHover(object sender, EventArgs e)
        {
           // ExitBtn.Image = Properties.Resources.close_icon_01;
        }

        private void ExitBtn_MouseDown(object sender, MouseEventArgs e)
        {
        }
        
        private void metroPanel4_MouseDown(object sender, MouseEventArgs e)
        {
            yearCmb.DroppedDown = true;
        }

        private void customComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            monthLbl.Text = monthCmb.Text;
            fillDay();
        }

        private void customComboBox1_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void metroPanel5_MouseDown(object sender, MouseEventArgs e)
        {
            dayCmb.DroppedDown = true;
        }

        private void dayLbl_MouseDown(object sender, MouseEventArgs e)
        {
            dayCmb.DroppedDown = true;
        }

        private void yearLbl_MouseDown(object sender, MouseEventArgs e)
        {
            yearCmb.DroppedDown = true;
        }

        private void metroPanel6_MouseDown(object sender, MouseEventArgs e)
        {
            yearCmb.DroppedDown = true;
        }

        private void monthLbl_MouseDown(object sender, MouseEventArgs e)
        {
            monthCmb.DroppedDown = true;
        }

        private void metroPanel4_MouseDown_1(object sender, MouseEventArgs e)
        {
            monthCmb.DroppedDown = true;
        }

        private void dayCmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            dayLbl.Text = dayCmb.Text;
        }

        private void yearCmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            yearLbl.Text = yearCmb.Text;
        }

        private void emailTxt_TextChanged(object sender, EventArgs e)
        {
            if (emailTxt.Text == "")
            {
                emailvalidLbl.Text = "";
            }
            else
            {
                Regex rg = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");

                if (rg.IsMatch(emailTxt.Text))
                {
                    emailvalidLbl.Text = "Email Valid";
                    emailvalidLbl.ForeColor = Color.Green;
                    emailvalid = true;
                }
                else
                {
                    emailvalidLbl.Text = "You must enter a valid email address.";
                    emailvalidLbl.ForeColor = Color.Orange;
                    emailvalid = false;
                }
                validate();
            }
        }

        private void lastnameTxt_TextChanged(object sender, EventArgs e)
        {
            if (lastnameTxt.Text != "" && firstnameTxt.Text != "")
            {
                if (firstnameTxt.Text == "")
                {
                    namevalidLbl.Text = "Fill-up Required Fields.";
                    namevalidLbl.ForeColor = Color.Orange;
                    firstnamevalid = false;
                }
                else
                {
                    namevalidLbl.Text = "Full Name : " + lastnameTxt.Text + ", " + firstnameTxt.Text + " " + middlenameTxt.Text;
                    namevalidLbl.ForeColor = Color.DodgerBlue;
                }
                lastnamevalid = true;
            }
            else
            {
                namevalidLbl.Text = "Fill-up Required Fields.";
                namevalidLbl.ForeColor = Color.Orange;
                lastnamevalid = false;
            }
            validate();
        }

        private void middlenameTxt_TextChanged(object sender, EventArgs e)
        {
            namevalidLbl.Text = "Full Name : " + lastnameTxt.Text + ", " + firstnameTxt.Text + " " + middlenameTxt.Text;
        }
    }
}
