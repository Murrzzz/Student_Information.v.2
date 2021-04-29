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
    public partial class Add : Form
    {
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\Student_Info.accdb;Persist Security Info = True");
      
        MainMenu main = new MainMenu();
        public Add(MainMenu f1)
        {
            InitializeComponent();
            this.main = f1;
        }  

        private void Add_Load(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainMenu main = new MainMenu();
            main.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void pnlAdd_Subject_Paint(object sender, PaintEventArgs e)
        {
            OleDbDataAdapter adapt = new OleDbDataAdapter("Select * from [Subject]", con);
            DataTable table = new DataTable();
            adapt.Fill(table);
            dgvSubject.DataSource = table;

            dgvSubject.AllowUserToAddRows = false;
            dgvSubject.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvSubject.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            pnlAddStudent.Hide();
            pnlAdd_Subject.Show();

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
             if ((txtFname.Text == "") || (txtLname.Text == "") || (txtMname.Text == "")||(txtGmail.Text =="")||(txtCourse .Text =="")||(cmbYear .Text =="")||(txtStudentNumber .Text =="")||(txtSection .Text =="")||(txtContactNumber .Text=="" )||(TxtDepartment .Text =="")||(txtAddress .Text =="")||(cmbSex .Text =="")||(txtReligion .Text =="")||(txtBirthdate .Text =="")||(cmbStatus .Text =="")||(txtSchoolYear .Text =="")||(cmbCivilStatus .Text ==""))
            {
                MessageBox.Show("Please fill the blank");
            }
            else
            {
                
                    con.Open();

                    OleDbCommand cmd = new OleDbCommand(" insert into[Students]([Stud_Id],[Stud_Fname],[Stud_Lname],[Stud_Mname],[Stud_Gmail],[Stud_Course],[Stud_Year],[Stud_Section],[Stud_ContactNumber],[Stud_Department],[Stud_Address],[Stud_Sex],[Stud_Religion],[Stud_BirthDate],[Stud_Status],[Stud_SchoolYear],[Stud_CivilStatus]) values(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)", con);
                    cmd.Parameters.AddWithValue("@Stud_Id", OleDbType.VarChar).Value = txtStudentNumber.Text;
                    cmd.Parameters.AddWithValue("@Stud_Fname", OleDbType.VarChar).Value = txtFname.Text;
                    cmd.Parameters.AddWithValue("@Stud_Lname", OleDbType.VarChar).Value = txtLname.Text;
                    cmd.Parameters.AddWithValue("@Stud_Mname", OleDbType.VarChar).Value = txtMname.Text;
                    cmd.Parameters.AddWithValue("@Stud_Gmail", OleDbType.VarChar).Value = txtGmail.Text;
                    cmd.Parameters.AddWithValue("@Stud_Course", OleDbType.VarChar).Value = txtCourse.Text;
                    cmd.Parameters.AddWithValue("@Stud_Year", OleDbType.VarChar).Value = cmbYear.Text;
                    cmd.Parameters.AddWithValue("@Stud_Section", OleDbType.VarChar).Value = txtSection.Text;
                    cmd.Parameters.AddWithValue("@Stud_ContactNumber", OleDbType.VarChar).Value = txtContactNumber.Text;
                    cmd.Parameters.AddWithValue("@Stud_Department", OleDbType.VarChar).Value = TxtDepartment.Text;
                    cmd.Parameters.AddWithValue("@Stud_Address", OleDbType.VarChar).Value = txtAddress.Text;
                    cmd.Parameters.AddWithValue("@Stud_Sex", OleDbType.VarChar).Value = cmbSex.Text;
                    cmd.Parameters.AddWithValue("@Stud_Religion", OleDbType.VarChar).Value = txtReligion.Text;
                    cmd.Parameters.AddWithValue("@Stud_BirthDate", OleDbType.VarChar).Value = txtBirthdate.Text;
                    cmd.Parameters.AddWithValue("@Stud_Status", OleDbType.VarChar).Value = cmbStatus.Text;
                    cmd.Parameters.AddWithValue("@Stud_SchoolYear", OleDbType.VarChar).Value = txtSchoolYear.Text;
                    cmd.Parameters.AddWithValue("@Stud_CivilStatus", OleDbType.VarChar).Value = cmbCivilStatus.Text;


                    cmd.ExecuteNonQuery();
                    con.Close();
               
             }
        }


        
    }

}
