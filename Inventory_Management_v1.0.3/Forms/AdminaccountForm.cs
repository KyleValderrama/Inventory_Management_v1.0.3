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
using Inventory_Management_v1._0._3.Forms;
using System.Data.Common;

namespace Inventory_Management_v1._0._3
{

    public partial class AdminaccountForm : Form
    {
        //Variable Decalarations
        private bool firstnamevalid = false;
        private bool lastnamevalid = false;
        private bool emailvalid = false;
        private string dbpassword = "";
        private string dbname = "";
        private bool flag = true;
        private bool next;
        private bool back;

        //Themes & TitleBar
        private void switchTheme()
        {
            if (Themes.ThemeStyle == "Dark")
                Themes.ThemeStyle = "Light";
            else if (Themes.ThemeStyle == "Light")
                Themes.ThemeStyle = "Dark";
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

                //Admin Information
                firstName = firstnameTxt.Text,
                lastName = lastnameTxt.Text,
                middleName = middlenameTxt.Text,
                birthDate = new DateTime((int)yearCmb.SelectedItem, monthCmb.SelectedIndex + 1, (int)dayCmb.SelectedItem),
                emailAddress = emailTxt.Text
            };
        }

        public void getData(firstSetupModel fsm)
        {
            firstnameTxt.Text = fsm.firstName;
            lastnameTxt.Text = fsm.lastName;
            middlenameTxt.Text = fsm.middleName;
            emailTxt.Text = fsm.emailAddress;
            storenameLbl.Text = $"{fsm.storeName}";
            dbpassword = fsm.dbPassword;
            dbname = fsm.dbName;            

            if(fsm.birthDate.Month == 1 && fsm.birthDate.Day == 1 && fsm.birthDate.Year == 1)
            {
                monthCmb.SelectedIndex = DateTime.Now.Month - 1;
                yearCmb.SelectedItem = DateTime.Now.Year - 18;
                dayCmb.SelectedItem = DateTime.Now.Day;
            }
            else
            {
                monthCmb.SelectedIndex = fsm.birthDate.Month - 1;
                dayCmb.SelectedItem = fsm.birthDate.Day;
                yearCmb.SelectedItem = fsm.birthDate.Year;
            }

        }

        
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
            else if (monthCmb.SelectedIndex == 3 ||
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
            dayCmb.SelectedIndex = 0;
        }
        private void formReset()
        {
            firstSetupModel fsm = new firstSetupModel();
            Themes.UpdateThemeStyle(this, MinimizeBtn, ExitBtn, switchBtn, themeToolTip);
            firstnameTxt.Text = "";
            lastnameTxt.Text = "";
            middlenameTxt.Text = "";
            emailTxt.Text = "";
            namevalidLbl.Text = "";
            nextBtn.Enabled = false;
            monthCmb.Hide();
            dayCmb.Hide();
            yearCmb.Hide();
            monthCmb.DataSource = CultureInfo.InvariantCulture.DateTimeFormat.MonthNames.Take(12).ToList();            
            yearCmb.DataSource = Enumerable.Range(1940, (DateTime.Now.Year-18) - 1940 + 1).ToList();        
            getData(fsm);
            this.AcceptButton = nextBtn;
            this.Opacity = 0.1;
            fade.Start();
            this.ActiveControl = firstnameTxt;
            next = false;
            back = false;

        }

        //Validations
        private void validate()
        {
            if (firstnamevalid == true && lastnamevalid == true && emailvalid == true)
                nextBtn.Enabled = true;
            else
                nextBtn.Enabled = false;
        }                    
        private void firstnameValidation()
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
                    namevalidLbl.Text = $"Full Name : { lastnameTxt.Text }, { firstnameTxt.Text } {  middlenameTxt.Text}";
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
        private void emailValidation()
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
                    emailvalidLbl.Text = "            ";
                    emailvalidLbl.Image = Properties.Resources.icon_check_reverse_01;
                    emailvalid = true;
                }
                else
                {
                    emailvalidLbl.Text = "You must enter a valid email address.";
                    emailvalidLbl.ForeColor = Color.Orange;
                    emailvalidLbl.Image = null;
                    emailvalid = false;
                }
                validate();
            }
        }
        private void lastnameValidation()
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
                    namevalidLbl.Text = $"Full Name : { lastnameTxt.Text }, { firstnameTxt.Text } {  middlenameTxt.Text}";
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
        private void middlenameValidation()
        {
            if (lastnameTxt.Text != "" && firstnameTxt.Text != "")
            {
                namevalidLbl.Text = $"Full Name : { lastnameTxt.Text }, { firstnameTxt.Text } {  middlenameTxt.Text}";
            }
            else
            {
                namevalidLbl.Text = "Fill-up Required Fields.";
                namevalidLbl.ForeColor = Color.Orange;
                lastnamevalid = false;
            }

        }


        // Form Start
        public AdminaccountForm()
        {
            
            InitializeComponent();           
            formReset();
            
        }

        private void firstnameTxt_TextChanged(object sender, EventArgs e)
        {
            firstnameValidation();
        }
        private void switchBtn_Click(object sender, EventArgs e)
        {
            switchTheme();
        }
        private void ExitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
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
            emailValidation();
        }

        private void lastnameTxt_TextChanged(object sender, EventArgs e)
        {
            lastnameValidation();
        }

        private void middlenameTxt_TextChanged(object sender, EventArgs e)
        {
            middlenameValidation();
        }

        private void timer1_Tick(object sender, EventArgs e)
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
                        CreateAdminPassForm next = new CreateAdminPassForm();
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
                        RegisterstoreForm back = new RegisterstoreForm();
                        back.getData(fsm);
                        this.Close();
                        back.Show();
                    }
                }

            }
        }

        private void nextBtn_Click(object sender, EventArgs e)
        {
            flag = false;
            fade.Start();
            next = true;
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            flag = false;
            fade.Start();
            back = true;
        }
    }
}
