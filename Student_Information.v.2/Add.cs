﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Drawing.Imaging;
using System.IO;


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
            OleDbDataAdapter adapt1 = new OleDbDataAdapter("Select [Sub_Code],[Sub_Name],[Sub_Units] from [Student_Subject] where[Stud_Id]='" + txtStudentNumber.Text + "'", con);
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
            select_Student_Subject();

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




                OleDbCommand cmd = new OleDbCommand(" insert into[Students]([Stud_Id],[Stud_Fname],[Stud_Lname],[Stud_Mname],[Stud_Gmail],[Stud_Course],[Stud_Year],[Stud_Section],[Stud_ContactNumber],[Stud_Department],[Stud_Address],[Stud_Sex],[Stud_Religion],[Stud_BirthDate],[Stud_Status],[Stud_SchoolYear],[Stud_CivilStatus],[Class_Name],[Stud_Image]) values(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)", con);
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
                cmd.Parameters.AddWithValue("@Stud_CivilStatus", OleDbType.VarChar).Value = MainMenu.classname;
                cmd.Parameters.AddWithValue("@Stud_Image", pictureBox1);

              
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
                lblSubject_Code.Text = row.Cells["Sub_Code"].Value.ToString();
                lblSub_Name.Text = row.Cells["Sub_Name"].Value.ToString();
                lblSub_Units.Text = row.Cells["Sub_Units"].Value.ToString();

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
            cmd.Parameters.AddWithValue("@Department", OleDbType.VarChar).Value = txtStudentNumber.Text;
            cmd.Parameters.AddWithValue("@Course", OleDbType.VarChar).Value = lblSubject_Code.Text;
            cmd.Parameters.AddWithValue("@Section", OleDbType.VarChar).Value = lblSub_Name.Text;
            cmd.Parameters.AddWithValue("@Section", OleDbType.VarChar).Value = lblSub_Units.Text;


            cmd.ExecuteNonQuery();
            select_Student_Subject();
            con.Close();
        }
        private void DataImported()
        {
            txtStudentNumber.Text = MainMenu.Stud_Id;
            txtFname.Text = MainMenu.Fname;
            txtLname.Text = MainMenu.Lname;
            txtMname.Text = MainMenu.Mname;
            txtGmail.Text = MainMenu.Gmail;
            txtCourse.Text = MainMenu.course;
            cmbYear.Text = MainMenu.Year;
            txtSection.Text = MainMenu.section;
            txtContactNumber.Text = MainMenu.ContactNumber;
            TxtDepartment.Text = MainMenu.department;
            txtAddress.Text = MainMenu.Address;
            cmbSex.Text = MainMenu.Sex;
            txtReligion.Text = MainMenu.Religion;
            txtBirthdate.Text = MainMenu.BirthDate;
            cmbStatus.Text = MainMenu.Status;
            txtSchoolYear.Text = MainMenu.SchoolYear;
            cmbCivilStatus.Text = MainMenu.CivilStatus;

            //Update button
        }

        private void pnlAddStudent_Paint(object sender, PaintEventArgs e)
        {
            if (MainMenu.addUp == 1)
            {
               
                TxtDepartment.Text = MainMenu .Department1  ;
                txtSection.Text = MainMenu .Section1 ;
                txtCourse.Text = MainMenu .Course1  ;


                TxtDepartment.ReadOnly = true;//for text box not to Edit
                TxtDepartment.BackColor = System.Drawing.SystemColors.Window;//for color of the textbox

                txtSection.ReadOnly = true;
                txtSection.BackColor = System.Drawing.SystemColors.Window;

                TxtDepartment.ReadOnly = true;
                TxtDepartment.BackColor = System.Drawing.SystemColors.Window;
                MainMenu.addUp = 3;
            }
            else if (MainMenu.addUp == 0)
            {
                DataImported();
                MainMenu.addUp = 3;
            }

            //   txtSection.ReadOnly = true;
            //  TxtDepartment.ReadOnly = true;
            //  txtCourse.ReadOnly = true;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                OleDbCommand cmd = new OleDbCommand(" update[Students] set[Stud_Id]='" + txtStudentNumber.Text + "',[Stud_Fname]='" + txtFname.Text + "',[Stud_Lname]='" + txtLname.Text + "',[Stud_Mname]='" + txtMname.Text + "',[Stud_Gmail]='" + txtGmail.Text + "',[Stud_Year]='" + cmbYear.Text.ToString() + "',[Stud_ContactNumber]='" + txtContactNumber.Text + "',[Stud_Address]='" + txtAddress.Text + "',[Stud_Sex]='" + cmbSex.Text.ToString() + "',[Stud_Religion]='" + txtReligion.Text + "',[Stud_BirthDate]='" + txtBirthdate.Text + "',[Stud_Status]='" + cmbStatus.Text.ToString() + "',[Stud_SchoolYear]='" + txtSchoolYear.Text + "',[Stud_CivilStatus]='" + cmbCivilStatus.Text.ToString() + "',[Stud_Image]=? where [Stud_Id]='" + txtStudentNumber.Text + "'", con);

                cmd.Parameters.AddWithValue("@1", pictureBox1.Image);

                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            pnlAddStudent.Hide();
            pnlAdd_Subject.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainMenu main = new MainMenu();
            main.Show();
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            MainMenu main = new MainMenu();
            main.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                OleDbCommand cmd = new OleDbCommand("delete from [Student_Subject] where[Sub_Code]='" + lblSubject_Code1.Text + "'", con);
                cmd.ExecuteNonQuery();
                select_Student_Subject();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                string Mypictures = System.Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);

                ofd.Filter = "Jpg Jpeg Image|*.jpe;*.jpeg|PNG Image|*.png|BMP Image|*.bmp|" + "All files (*.*)|*.*";
                ofd.FileName = "Image file name";
                ofd.Title = "Choose image....";
                

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    this.pictureBox1.Image = Image.FromFile(ofd.FileName);
                }
                else
                {
                    return;
                }


            }
            catch (Exception exx)
            {
                MessageBox.Show (exx.Message);
            }


        }

        private void txtStudentNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }

        }

        private void txtContactNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
        }     
}
