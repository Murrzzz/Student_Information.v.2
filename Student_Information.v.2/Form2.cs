using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;


namespace Student_Information.v._2
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            customizeDesign();
        }
        private void customizeDesign()
        {
            panelMainSubmenu.Visible = false;
            panelSettingsSubmenu.Visible = false;

        }
        private void hideSubmenu()
        {
            if (panelMainSubmenu.Visible == true)
                panelMainSubmenu.Visible = false;
            if (panelSettingsSubmenu.Visible == true)
                panelSettingsSubmenu.Visible = false;
        }
        private void ShowSubmenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubmenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }
        private void btnMain_Click(object sender, EventArgs e)
        {
            
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //..
            //my code
            //..
            hideSubmenu();
        }

        private void btnAddClass_Click(object sender, EventArgs e)
        {
            //..
            //my code
            //..
            hideSubmenu();
        }

        private void btnStud_Click(object sender, EventArgs e)
        {
            //..
            //my code
            //..
            hideSubmenu();
        }
        private void btnRecord_Click(object sender, EventArgs e)
        {
            //..
            //my code
            //..
            hideSubmenu();
        }
        private void btnSettings_Click(object sender, EventArgs e)
        {
           
        }

        private void btnUserUpdate_Click(object sender, EventArgs e)
        {
            //..
            //my code
            //..
            hideSubmenu();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //..
            //my code
            //..
            hideSubmenu();
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            //..
            //my code
            //..
            hideSubmenu();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //..
            //my code
            //..
            hideSubmenu();
        }

        private void btnRetrieve_Click(object sender, EventArgs e)
        {
            //..
            //my code
            //..
            hideSubmenu();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            //..
            //my code
            //..
            hideSubmenu();
        }
        private void Form2_Paint(object sender, PaintEventArgs e)
        {
            Graphics mgraphics = e.Graphics;
            Pen pen = new Pen(Color.FromArgb(17, 200, 243), 1);

            Rectangle area = new Rectangle(0, 0, this.Width - 1, this.Height - 1);
            LinearGradientBrush lgb = new LinearGradientBrush(area, Color.FromArgb(17, 200, 243), Color.FromArgb(17, 39, 45), LinearGradientMode.Vertical);
            mgraphics.FillRectangle(lgb, area);
            mgraphics.DrawRectangle(pen, area);
        }

        private void panelHome_Paint(object sender, PaintEventArgs e)
        {
            new frmHome().Show();
            this.Hide();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }
        private void picres_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Normal;
            picres.Visible = false;
            picmax.Visible = true;
        }

        private void picmin_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
        private void picmax_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            picmax.Visible = false;
            picres.Visible = true;
        }

        private void picexit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panelControl_Paint(object sender, PaintEventArgs e)
        {

            Graphics mgraphics = e.Graphics;
            Pen pen = new Pen(Color.FromArgb(17, 200, 243), 1);

            Rectangle area = new Rectangle(0, 0, this.Width - 1, this.Height - 1);
            LinearGradientBrush lgb = new LinearGradientBrush(area, Color.FromArgb(17, 200, 243), Color.FromArgb(17, 39, 45), LinearGradientMode.Vertical);
            mgraphics.FillRectangle(lgb, area);
            mgraphics.DrawRectangle(pen, area);
        }
        }
    }


