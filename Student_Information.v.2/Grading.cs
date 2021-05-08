using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Student_Information.v._2
{
    public partial class Grading : Form
    {
        OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Administrator\Desktop\Student_Information.v.2\Student_Information.v.2\database\Student_Info.accdb;Persist Security Info = False");
      
        public Grading()
        {
            InitializeComponent();
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Grading_Load(object sender, EventArgs e)
        {
            Comboboxes();    
        }
        

        private void Comboboxes()
        {
            con.Open();
         
            OleDbDataAdapter adapt = new OleDbDataAdapter("Select [Sub_Name],[Sub_Code] from [Subject]", con);
            DataTable table = new DataTable();
            adapt.Fill(table);


            foreach (DataRow  dr1 in table.Rows)
            {
                cmbSub1.Items.Add(dr1["Sub_Name"].ToString ());
                cmbSub2.Items.Add(dr1["Sub_Name"].ToString());
                cmbSub3.Items.Add(dr1["Sub_Name"].ToString());
                cmbSub4.Items.Add(dr1["Sub_Name"].ToString());
                cmbSub5.Items.Add(dr1["Sub_Name"].ToString());
                cmbSub6.Items.Add(dr1["Sub_Name"].ToString());
                cmbSub7.Items.Add(dr1["Sub_Name"].ToString());
                cmbSub8.Items.Add(dr1["Sub_Name"].ToString());
                cmbSub9.Items.Add(dr1["Sub_Name"].ToString());
                cmbSub10.Items.Add(dr1["Sub_Name"].ToString());
            }

        
            con.Close();
        }

        private void rectangleShape3_Click(object sender, EventArgs e)
        {

        }

        private void btnC1_Click(object sender, EventArgs e)
        {
            cmbSub1.Text = "";
            //txtGr1.Text = "";
        }

        private void btnC2_Click(object sender, EventArgs e)
        {
            cmbSub2.Text = "";
            txtGr2.Text = "";
        }

        private void btnC3_Click(object sender, EventArgs e)
        {
            cmbSub3.Text = "";
            txtGr3.Text = "";
        }

        private void btnC4_Click(object sender, EventArgs e)
        {
            cmbSub4.Text = "";
            txtGr4.Text = "";
        }

        private void btnC5_Click(object sender, EventArgs e)
        {
            cmbSub5.Text = "";
            txtGr5.Text = "";
        }

        private void btnC6_Click(object sender, EventArgs e)
        {
            cmbSub6.Text = "";
            txtGr6.Text = "";
        }

        private void btnC7_Click(object sender, EventArgs e)
        {
            cmbSub7.Text = "";
            txtGr7.Text = "";
        }

        private void bntC8_Click(object sender, EventArgs e)
        {
            cmbSub8.Text = "";
            txtGr8.Text = "";
        }

        private void bntC9_Click(object sender, EventArgs e)
        {
            cmbSub9.Text = "";
            txtGr9.Text = "";
        }

        private void btnC10_Click(object sender, EventArgs e)
        {
            cmbSub10.Text = "";
            txtGr10.Text = "";
        }
   
    }
}
