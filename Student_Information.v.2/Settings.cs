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
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics mgraphics = e.Graphics;
            Pen pen = new Pen(Color.FromArgb(40, 188, 178), 1);

            Rectangle area = new Rectangle(0, 0, this.Width - 1, this.Height - 1);
            LinearGradientBrush lgb = new LinearGradientBrush(area, Color.FromArgb(40, 188, 178), Color.FromArgb(37, 137, 202), LinearGradientMode.Vertical);
            mgraphics.DrawRectangle(pen, area);
            mgraphics.FillRectangle(lgb, area);
            mgraphics.DrawRectangle(pen, area);
        }

        private void panel2_Paint_1(object sender, PaintEventArgs e)
        {
            Graphics mgraphics = e.Graphics;
            Pen pen = new Pen(Color.FromArgb(40, 188, 178), 1);

            Rectangle area = new Rectangle(0, 0, this.Width - 1, this.Height - 1);
            LinearGradientBrush lgb = new LinearGradientBrush(area, Color.FromArgb(40, 188, 178), Color.FromArgb(37, 137, 202), LinearGradientMode.Vertical);
            mgraphics.DrawRectangle(pen, area);
            mgraphics.FillRectangle(lgb, area);
            mgraphics.DrawRectangle(pen, area);
        }
        private void Hide_panels()//Hide all panels
        {
            pnlHelp.Hide();
            pnlRecycleBin.Hide();
            pnlUserUpdate.Hide();
            pnlSaveData.Hide();
            pnlUserUpdate.Hide();
        }


        private void btnLogout_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void btnUserUpdate_Click(object sender, EventArgs e)
        {
            Hide_panels();
            pnlUserUpdate.Show();
        }

        private void btnSaveData_Click(object sender, EventArgs e)
        {
            Hide_panels();
            pnlSaveData.Show();
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            Hide_panels();
            pnlHelp.Show();
        }

        private void btnRecycle_Click(object sender, EventArgs e)
        {
            Hide_panels();
            pnlRecycleBin.Show();
        }

        private void pnlSaveData_Paint(object sender, PaintEventArgs e)
        {

        }

      
    }
}
