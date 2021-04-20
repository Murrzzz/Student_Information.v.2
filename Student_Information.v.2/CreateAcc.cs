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
    public partial class frmCreateAcc : Form
    {
        public frmCreateAcc()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            txtPass.PasswordChar = checkBox1.Checked ? '\0' : '•';
            txtConPass.PasswordChar = checkBox1.Checked ? '\0' : '•';
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
           if (txtFullname.Text=="roger" && txtUsername.Text=="roger" && txtPass.Text=="roger" && txtConPass.Text=="roger")
            {
                new frmLogin().Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show("Invalid Account");
                txtFullname.Clear();
                txtUsername.Clear();
                txtPass.Clear();
                txtConPass.Clear();
                txtUsername.Focus();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            new frmLogin().Show();
            this.Hide();
        }
        private void CreateAcc_Paint(object sender, PaintEventArgs e)
        {
            Graphics mgraphics = e.Graphics;
            Pen pen = new Pen(Color.FromArgb(40, 188, 178), 1);

            Rectangle area = new Rectangle(0, 0, this.Width - 1, this.Height - 1);
            LinearGradientBrush lgb = new LinearGradientBrush(area, Color.FromArgb(40, 188, 178), Color.FromArgb(37, 137, 202), LinearGradientMode.Vertical);
            mgraphics.FillRectangle(lgb, area);
            mgraphics.DrawRectangle(pen, area);
        }

        private void txtFullname_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        }

     
    }

