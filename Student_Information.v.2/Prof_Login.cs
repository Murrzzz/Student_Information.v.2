using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Data.OleDb;

namespace Student_Information.v._2
{
    public partial class Prof_Login : Form
    {
        OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Administrator\Desktop\Student_Information.v.2\Student_Information.v.2\database\Student_Info.accdb;Persist Security Info = False");
      
        public Prof_Login()
        {
            InitializeComponent();
        }
        
        private void Prof_Login_Load(object sender, EventArgs e)
        {
            
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if ((txtPassword.Text == "") || (txtUsername.Text == ""))
            {
                MessageBox.Show("Fill the blanks");

            }
            con.Open();
            OleDbCommand cmd = new OleDbCommand("select count(*) from[Prof_account] where [username]=? and [password]=?", con);
            cmd.Parameters.AddWithValue("@Username", OleDbType.VarChar).Value = txtUsername.Text;
            cmd.Parameters.AddWithValue("@Password", OleDbType.VarChar).Value = txtPassword.Text;

            var Count = Convert.ToInt32(cmd.ExecuteScalar());
            if (Count > 0)
            {
                MessageBox.Show("Success");
                new Settings().Show();
                this.Hide();
            }


            con.Close();

        }

        private void Prof_Login_Paint(object sender, PaintEventArgs e)
        {
            Graphics mgraphics = e.Graphics;
            Pen pen = new Pen(Color.FromArgb(40, 188, 178), 1);

            Rectangle area = new Rectangle(0, 0, this.Width - 1, this.Height - 1);
            LinearGradientBrush lgb = new LinearGradientBrush(area, Color.FromArgb(40, 188, 178), Color.FromArgb(37, 137, 202), LinearGradientMode.Vertical);
            mgraphics.DrawRectangle(pen, area);
            mgraphics.FillRectangle(lgb, area);
            mgraphics.DrawRectangle(pen, area);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

    }
}
