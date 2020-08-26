namespace Inventory_Management_v1._0._3.Forms
{
    partial class LoadingScreenForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.fade = new System.Windows.Forms.Timer(this.components);
            this.WinformBorder = new System.Windows.Forms.Panel();
            this.WinformTtl = new System.Windows.Forms.Panel();
            this.bunifuCustomLabel3 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.Load = new System.Windows.Forms.Timer(this.components);
            this.customLabel12 = new Inventory_Management_v1._0._3.CustomLabel1();
            this.WinformBorder.SuspendLayout();
            this.WinformTtl.SuspendLayout();
            this.SuspendLayout();
            // 
            // fade
            // 
            this.fade.Interval = 30;
            this.fade.Tick += new System.EventHandler(this.fade_Tick);
            // 
            // WinformBorder
            // 
            this.WinformBorder.BackColor = System.Drawing.Color.Transparent;
            this.WinformBorder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.WinformBorder.Controls.Add(this.WinformTtl);
            this.WinformBorder.Controls.Add(this.bunifuCustomLabel1);
            this.WinformBorder.Controls.Add(this.progressBar1);
            this.WinformBorder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WinformBorder.Location = new System.Drawing.Point(0, 0);
            this.WinformBorder.Name = "WinformBorder";
            this.WinformBorder.Size = new System.Drawing.Size(413, 196);
            this.WinformBorder.TabIndex = 5;
            // 
            // WinformTtl
            // 
            this.WinformTtl.Controls.Add(this.customLabel12);
            this.WinformTtl.Controls.Add(this.bunifuCustomLabel3);
            this.WinformTtl.Dock = System.Windows.Forms.DockStyle.Top;
            this.WinformTtl.Location = new System.Drawing.Point(0, 0);
            this.WinformTtl.Name = "WinformTtl";
            this.WinformTtl.Size = new System.Drawing.Size(411, 111);
            this.WinformTtl.TabIndex = 2;
            // 
            // bunifuCustomLabel3
            // 
            this.bunifuCustomLabel3.AutoSize = true;
            this.bunifuCustomLabel3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel3.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.bunifuCustomLabel3.Location = new System.Drawing.Point(25, 79);
            this.bunifuCustomLabel3.Name = "bunifuCustomLabel3";
            this.bunifuCustomLabel3.Size = new System.Drawing.Size(203, 20);
            this.bunifuCustomLabel3.TabIndex = 3;
            this.bunifuCustomLabel3.Text = "We are acquiring information";
            // 
            // bunifuCustomLabel1
            // 
            this.bunifuCustomLabel1.AutoSize = true;
            this.bunifuCustomLabel1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel1.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.bunifuCustomLabel1.Location = new System.Drawing.Point(25, 147);
            this.bunifuCustomLabel1.Name = "bunifuCustomLabel1";
            this.bunifuCustomLabel1.Size = new System.Drawing.Size(118, 17);
            this.bunifuCustomLabel1.TabIndex = 3;
            this.bunifuCustomLabel1.Text = "Setting Theme Syle";
            // 
            // progressBar1
            // 
            this.progressBar1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(66)))));
            this.progressBar1.Location = new System.Drawing.Point(29, 121);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(349, 23);
            this.progressBar1.TabIndex = 0;
            // 
            // Load
            // 
            this.Load.Interval = 40;
            this.Load.Tick += new System.EventHandler(this.Load_Tick);
            // 
            // customLabel12
            // 
            this.customLabel12.AutoSize = true;
            this.customLabel12.Font = new System.Drawing.Font("Segoe UI", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customLabel12.Location = new System.Drawing.Point(20, 29);
            this.customLabel12.Name = "customLabel12";
            this.customLabel12.Size = new System.Drawing.Size(210, 50);
            this.customLabel12.TabIndex = 4;
            this.customLabel12.Text = "Please Wait";
            // 
            // LoadingScreenForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(413, 196);
            this.Controls.Add(this.WinformBorder);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LoadingScreenForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LoadingScreenForm";
            this.WinformBorder.ResumeLayout(false);
            this.WinformBorder.PerformLayout();
            this.WinformTtl.ResumeLayout(false);
            this.WinformTtl.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer fade;
        private System.Windows.Forms.Panel WinformBorder;
        private System.Windows.Forms.Panel WinformTtl;
        private CustomLabel1 customLabel12;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel3;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Timer Load;
    }
}