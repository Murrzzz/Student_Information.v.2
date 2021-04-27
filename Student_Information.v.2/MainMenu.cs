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
    public partial class MainMenu : Form
    {
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\Student_Info.accdb;Persist Security Info = True");
      

        public MainMenu()
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
            pnlClass.Hide();
            pnlRecords.Hide();
            pnlSubjects.Hide();
            pnlAccounts.Hide();

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Hide_panels();
            pnlClass.Show();
        }

        private void btnAddClass_Click(object sender, EventArgs e)
        {
            Hide_panels();
            pnlSubjects.Show();

        }

        private void btnAddStudents_Click(object sender, EventArgs e)
        {
            Hide_panels();
            pnlRecords.Show();

        }

        private void btnRecords_Click(object sender, EventArgs e)
        {
            Hide_panels();
            pnlAccounts.Show();
        }

   
        private void button5_Click_1(object sender, EventArgs e)
        {
            Add ad = new Add(this);
            this.Hide();
            ad.Show();
        }

        private void btnAdd_Class_Click(object sender, EventArgs e)
        {
            con.Open();
            if ((txtCourse.Text == "") || (txtDepartment.Text == "") || (txtSchoolYear.Text == "") || (txtSection.Text == "") || (txtYearLevel.Text == "")||(txtClass_Des.Text =="")||(txtClass_Name .Text ==""))
            {
                MessageBox.Show("Please fill the blank");
            }

            OleDbCommand cmd = new OleDbCommand(" insert into[class]([Department],[Course],[Section],[Year_Level],[School_Year],[Class_Description],[Class_Name]) values(?,?,?,?,?,?,?)",con);
            cmd.Parameters.AddWithValue("@Department", OleDbType.VarChar).Value = txtDepartment.Text;
            cmd.Parameters.AddWithValue("@Course", OleDbType.VarChar).Value = txtCourse.Text;
            cmd.Parameters.AddWithValue("@Section", OleDbType.VarChar).Value = txtSection.Text;
            cmd.Parameters.AddWithValue("@Year_Level", OleDbType.VarChar).Value = txtYearLevel.Text;
            cmd.Parameters.AddWithValue("@School_Year", OleDbType.VarChar).Value = txtSchoolYear.Text ;
            cmd.Parameters.AddWithValue("@Class_Description", OleDbType.VarChar).Value = txtClass_Des .Text ;
            cmd.Parameters.AddWithValue("@Class_Name", OleDbType.VarChar).Value = txtClass_Name .Text ;

            cmd.ExecuteNonQuery();

            Class_SelectAll();
            con.Close();
        }

        private void Class_SelectAll()
        {
            OleDbDataAdapter adapt = new OleDbDataAdapter("Select * from [class]",con);
            DataTable table = new DataTable();
            adapt.Fill(table);
            dgvClass.DataSource = table;

            dgvClass.AllowUserToAddRows = false;
            dgvClass.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvClass.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

        }

        private void dgvClass_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvClass.Rows[e.RowIndex];
                txtDepartment.Text=row.Cells["Department"].Value .ToString();
                txtCourse.Text = row.Cells["Course"].Value.ToString();
                txtSection.Text = row.Cells["Section"].Value.ToString();
                txtYearLevel .Text  = row.Cells["Year_Level"].Value.ToString();
                txtSchoolYear.Text  = row.Cells["School_Year"].Value.ToString();
            }
        }

        private void btnUpdate_Class_Click(object sender, EventArgs e)
        {
            string Department = txtDepartment.Text;
            string Course = txtCourse.Text;
            string Section = txtSection.Text;
            string School_Year = txtSchoolYear.Text ;
            string Year_Level = txtYearLevel.Text;

            con.Open();
            OleDbCommand cmd = new OleDbCommand("UPDATE [class] SET [Department]='" + txtDepartment.Text + "',[Course]='" + txtCourse.Text + "',[Section]='" + txtSection.Text + "',[Year_Level]='" + txtYearLevel.Text + "',[School_Year]='" + txtSchoolYear.Text + "' WHERE [Course]='" + Course + "' AND [Section]='" + Section  + "' AND [Year_Level]='" + Year_Level +"'" , con);
            cmd.ExecuteNonQuery();

            Class_SelectAll();
            con.Close();
        }
    
    }
}
