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
            pnlAdd_Subject.Hide();
           
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
        private void select_Subject()
        {
            OleDbDataAdapter adapt = new OleDbDataAdapter("Select * from [Subject]", con);
            DataTable table = new DataTable();
            adapt.Fill(table);
            dgvSubject.DataSource = table;

            dgvSubject.AllowUserToAddRows = false;
            dgvSubject.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvSubject.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

        }
        private void select_Student_Subject()
        {
            OleDbDataAdapter adapt1 = new OleDbDataAdapter("Select [Sub_Code],[Sub_Name],[Sub_Units] from [Student_Subject] where[Stud_Id]='"+txtStudentNumber .Text +"'", con);
            DataTable table1 = new DataTable();
            adapt1.Fill(table1);
            dgvStudent_Subject.DataSource = table1;

            dgvStudent_Subject.AllowUserToAddRows = false;
            dgvStudent_Subject.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvStudent_Subject.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        private void pnlAdd_Subject_Paint(object sender, PaintEventArgs e)
        {
            select_Subject();

         
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            pnlAddStudent.Hide();

            if ((txtFname.Text == "") || (txtLname.Text == "") || (txtMname.Text == "") || (txtGmail.Text == "") || (txtCourse.Text == "") || (cmbYear.Text == "") || (txtStudentNumber.Text == "") || (txtSection.Text == "") || (txtContactNumber.Text == "") || (TxtDepartment.Text == "") || (txtAddress.Text == "") || (cmbSex.Text == "") || (txtReligion.Text == "") || (txtBirthdate.Text == "") || (cmbStatus.Text == "") || (txtSchoolYear.Text == "") || (cmbCivilStatus.Text == ""))
            {
                MessageBox.Show("Please fill the blank");
            }

            else
            {

                con.Open();
                MainMenu menu = new MainMenu();//from Mainmenu
                



                OleDbCommand cmd = new OleDbCommand(" insert into[Students]([Stud_Id],[Stud_Fname],[Stud_Lname],[Stud_Mname],[Stud_Gmail],[Stud_Course],[Stud_Year],[Stud_Section],[Stud_ContactNumber],[Stud_Department],[Stud_Address],[Stud_Sex],[Stud_Religion],[Stud_BirthDate],[Stud_Status],[Stud_SchoolYear],[Stud_CivilStatus],[Class_Name]) values(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)", con);
                cmd.Parameters.AddWithValue("@Stud_Id", OleDbType.VarChar).Value = txtStudentNumber.Text;
                cmd.Parameters.AddWithValue("@Stud_Fname", OleDbType.VarChar).Value = txtFname.Text;
                cmd.Parameters.AddWithValue("@Stud_Lname", OleDbType.VarChar).Value = txtLname.Text;
                cmd.Parameters.AddWithValue("@Stud_Mname", OleDbType.VarChar).Value = txtMname.Text;
                cmd.Parameters.AddWithValue("@Stud_Gmail", OleDbType.VarChar).Value = txtGmail.Text;
                cmd.Parameters.AddWithValue("@Stud_Course", OleDbType.VarChar).Value = MainMenu.course;
                cmd.Parameters.AddWithValue("@Stud_Year", OleDbType.VarChar).Value = cmbYear.Text;
                cmd.Parameters.AddWithValue("@Stud_Section", OleDbType.VarChar).Value = MainMenu.section;
                cmd.Parameters.AddWithValue("@Stud_ContactNumber", OleDbType.VarChar).Value = txtContactNumber.Text;
                cmd.Parameters.AddWithValue("@Stud_Department", OleDbType.VarChar).Value = MainMenu.department;
                cmd.Parameters.AddWithValue("@Stud_Address", OleDbType.VarChar).Value = txtAddress.Text;
                cmd.Parameters.AddWithValue("@Stud_Sex", OleDbType.VarChar).Value = cmbSex.Text;
                cmd.Parameters.AddWithValue("@Stud_Religion", OleDbType.VarChar).Value = txtReligion.Text;
                cmd.Parameters.AddWithValue("@Stud_BirthDate", OleDbType.VarChar).Value = txtBirthdate.Text;
                cmd.Parameters.AddWithValue("@Stud_Status", OleDbType.VarChar).Value = cmbStatus.Text;
                cmd.Parameters.AddWithValue("@Stud_SchoolYear", OleDbType.VarChar).Value = txtSchoolYear.Text;
                cmd.Parameters.AddWithValue("@Stud_CivilStatus", OleDbType.VarChar).Value = cmbCivilStatus.Text;
                cmd.Parameters.AddWithValue("@Stud_CivilStatus", OleDbType.VarChar).Value = MainMenu .classname;


                cmd.ExecuteNonQuery();
                con.Close();

            }

            pnlAdd_Subject.Show();

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            
        }

        private void dgvSubject_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvSubject.Rows[e.RowIndex];
                lblSubject_Code .Text  = row.Cells["Sub_Code"].Value.ToString();
                lblSub_Name .Text  = row.Cells["Sub_Name"].Value.ToString();
                lblSub_Units.Text  = row.Cells["Sub_Units"].Value.ToString();
            
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvStudent_Subject.Rows[e.RowIndex];
                lblSubject_Code1.Text = row.Cells["Sub_Code"].Value.ToString();
                lblSub_Name1.Text = row.Cells["Sub_Name"].Value.ToString();
                lblSub_Units1.Text = row.Cells["Sub_Units"].Value.ToString();

            }
        }

        private void btnSet_Click(object sender, EventArgs e)
        {
           
        
            con.Open();
            OleDbCommand cmd = new OleDbCommand(" insert into[Student_Subject]([Stud_Id],[Sub_Code],[Sub_Name],[Sub_Units]) values(?,?,?,?)", con);
            cmd.Parameters.AddWithValue("@Department", OleDbType.VarChar).Value = txtStudentNumber .Text ;
            cmd.Parameters.AddWithValue("@Course", OleDbType.VarChar).Value = lblSubject_Code.Text ;
            cmd.Parameters.AddWithValue("@Section", OleDbType.VarChar).Value = lblSub_Name .Text ;
            cmd.Parameters.AddWithValue("@Section", OleDbType.VarChar).Value = lblSub_Units .Text ;

           
            cmd.ExecuteNonQuery();
            select_Student_Subject();
            con.Close();
        }

        private void pnlAddStudent_Paint(object sender, PaintEventArgs e)
        {
            TxtDepartment.Text = MainMenu.department;
            txtSection.Text = MainMenu.section;
            txtCourse.Text = MainMenu.course;


            TxtDepartment.ReadOnly = true;//for text box not to Edit
            TxtDepartment.BackColor = System.Drawing.SystemColors.Window;//for color of the textbox

            txtSection.ReadOnly = true;
            txtSection.BackColor = System.Drawing.SystemColors.Window;

            TxtDepartment.ReadOnly = true;
            TxtDepartment.BackColor = System.Drawing.SystemColors.Window;


         //   txtSection.ReadOnly = true;
          //  TxtDepartment.ReadOnly = true;
          //  txtCourse.ReadOnly = true;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            OleDbCommand cmd = new OleDbCommand(" update[Students] set[Stud_Id]='"+txtStudentNumber .Text +"',[Stud_Fname]='"+txtFname .Text +"',[Stud_Lname]='"+txtLname .Text +"',[Stud_Mname]='"+txtMname .Text +"',[Stud_Gmail]='"+txtGmail .Text +"',[Stud_Course]='"+txtCourse .Text +"',[Stud_Year]='"+cmbYear.Text +"',[Stud_Section]='"+txtSection .Text +"',[Stud_Contact]='"+txtContactNumber .Text +"',[Stud_Department]='"+TxtDepartment .Text +"',[Stud_Address]='"+txtAddress .Text+"',[Stud_Sex]='"+cmbSex .Text +"',[Stud_Religion]='"+txtReligion .Text +"',[Stud_BirthDate]='"+txtBirthdate .Text +"',[Stud_Status]='"+cmbStatus .Text +"',[Stud_SchoolYear]='"+txtSchoolYear .Text +"',[Stud_CivilStatus]='"+cmbCivilStatus .Text +"',[Class_Name]='"+MainMenu .classname +"'",con);


            cmd.ExecuteNonQuery();
        }


        
    }

}
