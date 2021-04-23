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
    public partial class frmHome : Form
    {
        public frmHome()
        {
            InitializeComponent();
            customizeDesign();
        }

        private void HomePage_Load(object sender, EventArgs e)
        {

        }
            private void customizeDesign()
            {
                panelMainSubmenu.Visible = false;
                panelSettingsSubmenu.Visible = false;
                //..
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
               

            }

            private void btnAddClass_Click(object sender, EventArgs e)
            {
            
            }

            private void btnStud_Click(object sender, EventArgs e)
            {
                //..
                //my code
                //..
                
            }
            private void btnRecord_Click(object sender, EventArgs e)
            {
            //..
            
            }
            private void btnSettings_Click(object sender, EventArgs e)
            {
               
            }

            private void btnUserUpdate_Click(object sender, EventArgs e)
            {
                //..
                //my code
             
                hideSubmenu();
            }

            private void btnSave_Click(object sender, EventArgs e)
            {
                //..
                //my code
                //..
              
            }

            private void btnHelp_Click(object sender, EventArgs e)
            {
                //..
                //my code
                //..
                
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

            private void Form1_Paint(object sender, PaintEventArgs e)
            {
                Graphics mgraphics = e.Graphics;
                Pen pen = new Pen(Color.FromArgb(40, 188, 178), 1);

                Rectangle area = new Rectangle(0, 0, this.Width -1,this.Height -1);
                LinearGradientBrush lgb = new LinearGradientBrush(area, Color.FromArgb(40, 188, 178), Color.FromArgb(37, 137, 202), LinearGradientMode.Vertical);
                mgraphics.FillRectangle(lgb, area);
                mgraphics.DrawRectangle(pen, area);
            }
            private void panel1_Paint(object sender, PaintEventArgs e)
            {
                Graphics mgraphics = e.Graphics;
                Pen pen = new Pen(Color.FromArgb(75, 115, 134), 1);

                Rectangle area = new Rectangle(0, 0, this.Width - 1, this.Height - 1);
                LinearGradientBrush lgb = new LinearGradientBrush(area, Color.FromArgb(75, 115, 134), Color.FromArgb(78, 44, 112), LinearGradientMode.Vertical);
                mgraphics.FillRectangle(lgb, area);
                mgraphics.DrawRectangle(pen, area);
            }

            private void btnExit_Click(object sender, EventArgs e)
            {
                System.Windows.Forms.Application.Exit();
            }

            private void pictureBox1_Click(object sender, EventArgs e)
            {

            }
            private void picmax_Click(object sender, EventArgs e)
            {
                WindowState = FormWindowState.Maximized;
                picmax.Visible = false;
                picres.Visible = true;
            }

            private void picmin_Click_1(object sender, EventArgs e)
            {
                WindowState = FormWindowState.Minimized;
            }

            private void picres_Click(object sender, EventArgs e)
            {
                WindowState = FormWindowState.Normal;
                picres.Visible = false;
                picmax.Visible = true;
            }

            private void picexit_Click(object sender, EventArgs e)
            {
                Application.Exit();
            }

            private void panelChildform_Paint(object sender, PaintEventArgs e)
            {
                Graphics mgraphics = e.Graphics;
                Pen pen = new Pen(Color.FromArgb(75, 115, 134), 1);

                Rectangle area = new Rectangle(0, 0, this.Width - 1, this.Height - 1);
                LinearGradientBrush lgb = new LinearGradientBrush(area, Color.FromArgb(75, 115, 134), Color.FromArgb(78, 44, 112), LinearGradientMode.Vertical);
                mgraphics.FillRectangle(lgb, area);
                mgraphics.DrawRectangle(pen, area);
            }
            private Form activeForm = null;
            private void openChildform(Form childform)
            {
                if (activeForm != null)
                    activeForm.Close();
                activeForm = childform;
                childform.TopLevel = false;
                childform.FormBorderStyle = FormBorderStyle.None;
                childform.Dock = DockStyle.Fill;
                panelChildform.Controls.Add(childform);
                panelChildform.Tag = childform;
                childform.BringToFront();
                childform.Show();
            
            }

            private void panelMainSubmenu_Paint(object sender, PaintEventArgs e)
            {
                Graphics mgraphics = e.Graphics;
                Pen pen = new Pen(Color.FromArgb(75, 115, 134), 1);

                Rectangle area = new Rectangle(0, 0, this.Width - 1, this.Height - 1);
                LinearGradientBrush lgb = new LinearGradientBrush(area, Color.FromArgb(75, 115, 134), Color.FromArgb(78, 44, 112), LinearGradientMode.Vertical);
                mgraphics.FillRectangle(lgb, area);
                mgraphics.DrawRectangle(pen, area);
            }

            private void panelSettingsSubmenu_Paint(object sender, PaintEventArgs e)
            {
                Graphics mgraphics = e.Graphics;
                Pen pen = new Pen(Color.FromArgb(75, 115, 134), 1);

                Rectangle area = new Rectangle(0, 0, this.Width - 1, this.Height - 1);
                LinearGradientBrush lgb = new LinearGradientBrush(area, Color.FromArgb(75, 115, 134), Color.FromArgb(78, 44, 112), LinearGradientMode.Vertical);
                mgraphics.FillRectangle(lgb, area);
                mgraphics.DrawRectangle(pen, area);
            }

            private void panelHome_Paint(object sender, PaintEventArgs e)
            {
                Graphics mgraphics = e.Graphics;
                Pen pen = new Pen(Color.FromArgb(75, 115, 134), 1);

                Rectangle area = new Rectangle(0, 0, this.Width - 1, this.Height - 1);
                LinearGradientBrush lgb = new LinearGradientBrush(area, Color.FromArgb(75, 115, 134), Color.FromArgb(78, 44, 112), LinearGradientMode.Vertical);
                mgraphics.FillRectangle(lgb, area);
                mgraphics.DrawRectangle(pen, area);
            }

            private void btnInfo_Click(object sender, EventArgs e)
            {
                Application.Exit();
            }
            Writeline.Console("Hello Mundo");
            }
}


