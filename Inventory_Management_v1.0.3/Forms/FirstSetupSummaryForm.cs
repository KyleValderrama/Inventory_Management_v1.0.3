using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inventory_Management_v1._0._3.Forms
{
    public partial class FirstSetupSummaryForm : Form
    {
        //Variables
        private string dbpassword;
        private string adminpassword;
        private string firstname;
        private string lastname;
        private string middlename;
        private bool flag = true;
        private bool next = false;
        private bool back = false;
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

            };
        }
        public void getData(firstSetupModel fsm)
        {
            storenameLbl.Text = fsm.storeName;
            storenamedbLbl.Text = fsm.dbName;
            adminnameLbl.Text = fsm.fullName;
            birthdateLbl.Text = fsm.birthDate.ToString("MMMM, dd yyyy");
            emailLbl.Text = fsm.emailAddress;

            dbpassword = fsm.dbPassword;
            adminpassword = fsm.adminPassword;
            firstname = fsm.firstName;
            lastname = fsm.lastName;
            middlename = fsm.middleName;
        }

        private void formReset()
        {
            firstSetupModel fsm = new firstSetupModel();
            getData(fsm);
            Themes.UpdateThemeStyle(this, MinimizeBtn, ExitBtn, switchBtn, themeToolTip);
            nextBtn.Enabled = false;
            this.Opacity = 0.1;
            fade.Start();
        }
        public FirstSetupSummaryForm()
        {
            InitializeComponent();
            formReset();
        }

        private void switchBtn_Click(object sender, EventArgs e)
        {
            switchTheme();
        }

        private void customLabel18_Click(object sender, EventArgs e)
        {
            if (agreeChk.Checked == false)
            {
                agreeChk.Checked = true;
                nextBtn.Enabled = true;
            }
            else
            {
                agreeChk.Checked = false;
                nextBtn.Enabled = false;
            }
        }

        private void agreeChk_OnChange(object sender, EventArgs e)
        {
            if (agreeChk.Checked == false)
            {
                nextBtn.Enabled = false;
            }
            if (agreeChk.Checked == true)
            {
                nextBtn.Enabled = true;
            }
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            flag = false;
            fade.Start();
            back = true;
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
                        //CreateAdminPassForm next = new CreateAdminPassForm();
                        //next.getData(fsm);
                        //this.Hide();
                        //next.Show();
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
                        CreateAdminPassForm back = new CreateAdminPassForm();
                        back.getData(fsm);
                        this.Hide();
                        back.Show();
                    }
                }

            }
        }
    }
}
