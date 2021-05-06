using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Data.OleDb ;

namespace Student_Information.v._2
{
    public partial class frmLogin : Form
    {
         OleDbConnection con= new OleDbConnection ( "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\Student_Info.accdb;Persist Security Info = True");
      
        public frmLogin()
        {

            InitializeComponent();
        }

      
        private void Login_Paint(object sender, PaintEventArgs e)
        {
           Graphics mgraphics = e.Graphics;
           Pen pen = new Pen(Color.FromArgb(40, 188, 178), 1);

            Rectangle area = new Rectangle(0, 0, this.Width - 1, this.Height - 1);
            LinearGradientBrush lgb = new LinearGradientBrush(area, Color.FromArgb(40, 188, 178), Color.FromArgb(37, 137, 202), LinearGradientMode.Vertical);
            mgraphics.DrawRectangle(pen, area);
            mgraphics.FillRectangle(lgb, area);
            mgraphics.DrawRectangle(pen, area);

        }
        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click_1(object sender, EventArgs e)
        {
            //new Panel().Show();
            //this.Hide();
         

            if ((txtPassword.Text == "") || (txtUsername.Text == ""))
            {
                MessageBox.Show("Fill the blanks");
            
            }
            con.Open();
            OleDbCommand cmd = new OleDbCommand("select count(*) from[Account] where [Username]=? and [Password]=?",con );
            cmd.Parameters.AddWithValue("@Username", OleDbType.VarChar).Value = txtUsername.Text;
            cmd.Parameters.AddWithValue("@Password", OleDbType.VarChar).Value = txtPassword.Text;

            var Count = Convert.ToInt32(cmd.ExecuteScalar());
            if (Count > 0)
            {
                MessageBox.Show("Success");
                new Panel().Show();
                this.Hide();
            }


            con.Close();



        }

        private void checkShow_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = default(char);
        }
        }

}

