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
    public partial class Panel : Form
    {
        public Panel()
        {
            InitializeComponent();
          
        }
      
  
      

        private void btnMainMenu_Click(object sender, EventArgs e)
        {
            new MainMenu().Show();
            this.Hide();
        }
        private void btnSettings_Click(object sender, EventArgs e)
        {
            new Prof_Login().Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Grading grad = new Grading();
            grad.Show();

          
            this.Hide();
        }

        private void Panel_Paint(object sender, PaintEventArgs e)
        {
            Graphics mgraphics = e.Graphics;
            Pen pen = new Pen(Color.FromArgb(40, 188, 178), 1);

            Rectangle area = new Rectangle(0, 0, this.Width - 1, this.Height - 1);
            LinearGradientBrush lgb = new LinearGradientBrush(area, Color.FromArgb(40, 188, 178), Color.FromArgb(37, 137, 202), LinearGradientMode.Vertical);
            mgraphics.DrawRectangle(pen, area);
            mgraphics.FillRectangle(lgb, area);
            mgraphics.DrawRectangle(pen, area);
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            new MainMenu().Show();
            this.Hide();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            new Prof_Login().Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
           this.Close();
        }
    }
}
