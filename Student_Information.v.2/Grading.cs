﻿using System;
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
        OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Administrator\Desktop\Student_Information.v.2\Student_Information.v.2\database\Stud_Info_Update.accdb");
        public static string[] SubCode = new string[30];
        public static string[] SubName = new string[30];
        public static string[] SubGrade = new string[30];

        List<string> ComboboxPermanent;
        List<string> ComboboxTemporary;

        public Grading()
        {
            InitializeComponent();

          //  Comboboxes1();
           

            //ComboboxTemporary = ComboboxPermanent.ToList();

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
/*
        private void Comboboxes1()// Add values to the permanent list
        {
            con.Open();

            OleDbDataAdapter adapt = new OleDbDataAdapter("Select [Sub_Name] from [Erollment] where [Stud_Id]='123321'", con);
            DataTable table = new DataTable();
            adapt.Fill(table);

            ComboboxPermanent = new List<string>();
            ComboboxTemporary = new List<string>();
            foreach (DataRow dr1 in table.Rows)
            {
                ComboboxPermanent.Add(dr1["Sub_Name"].ToString());

            }
            cmbSub1.DataSource = ComboboxPermanent;
            cmbSub2.DataSource = ComboboxPermanent;
            cmbSub3.DataSource = ComboboxPermanent;
            cmbSub4.DataSource = ComboboxPermanent;
            cmbSub5.DataSource = ComboboxPermanent;
            cmbSub6.DataSource = ComboboxPermanent;
            cmbSub7.DataSource = ComboboxPermanent;
            cmbSub8.DataSource = ComboboxPermanent;
            cmbSub9.DataSource = ComboboxPermanent;
            cmbSub10.DataSource = ComboboxPermanent;
            con.Close();
        }
        */
        private void SelectGrades() 
        {

            //lblSchoolYearEnroll.Text = SchoolYear;
            OleDbDataAdapter adapt = new OleDbDataAdapter("Select [Sub_Code],[Sub_Name],[Sub_Grades] from [Erollment] where [Stud_Id]='" + cmbStudentNumber.Text + "' and  [Stud_Year]='" + cmbYear.Text + "' and [Stud_Sem]='" + cmbSem.Text + "' ", con);


            DataTable table = new DataTable();
            adapt.Fill(table);
            dgvGrades.DataSource = table;





            dgvGrades.AllowUserToAddRows = false;
            dgvGrades.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvGrades.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void Students_gradesSem()// automatic change the database
        {

            OleDbDataAdapter adapt = new OleDbDataAdapter("Select [Sub_code],[Sub_Name],[Sub_Grades] from [Erollment] where [Stud_Year]='" + cmbYear.Text + "' and [Stud_Sem]='" + cmbSem.Text + "' ", con);


            DataTable table = new DataTable();
            adapt.Fill(table);
            dgvGrades.DataSource = table;

            dgvGrades.AllowUserToAddRows = false;
            dgvGrades.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvGrades.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        private void Grading_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'stud_Info_UpdateDataSet.Erollment' table. You can move, or remove it, as needed.


            if ((cmbSem.Text == "") && (cmbYear.Text == ""))
            {

            }
            else
            {
                SelectGrades();
            }
     
            
            OleDbCommand cmd = new OleDbCommand("Select [Stud_Id] from [Erollment]", con);


            con.Close();
            con.Open();
            AutoCompleteStringCollection compl = new AutoCompleteStringCollection();//auto complete in search


            OleDbDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                compl.Add(rdr.GetString(0));//auto complete in search

            }

            txtSearchRecords.AutoCompleteCustomSource = compl;

            con.Close();



        }
        

      

        private void rectangleShape3_Click(object sender, EventArgs e)
        {

        }

        private void btnC1_Click(object sender, EventArgs e)
        {
            cmbSub1.Text = "";
            txtGr1.Text = "";
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


        private void button1_Click(object sender, EventArgs e)
        {
            if (txtGr1.Text != "")
            {
                InputGrade();
                MessageBox.Show("Grade Updated");
            }
            
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
          


            OleDbDataAdapter adapt = new OleDbDataAdapter("Select [Stud_Id],[Stud_Name],[Stud_Sem],[Stud_Section],[Stud_Year],[Sub_Code],[Sub_Name],[Sub_Grades] from [Erollment] where [Stud_Id]='" + txtSearchRecords.Text + "'", con);
            DataTable table = new DataTable();
            adapt.Fill(table);

            int i = 0;
            foreach (DataRow dr1 in table.Rows)
            {
                cmbStudentNumber .Text  = (dr1["Stud_Id"]).ToString();
                txtName.Text = (dr1["Stud_Name"]).ToString();
                cmbSection.Text = (dr1["Stud_Section"]).ToString();
                //cmbSem.Text = (dr1["Stud_Sem"]).ToString();
                //cmbYear.Text = (dr1["Stud_Year"]).ToString();
                SubCode[i]= (dr1["Sub_Code"]).ToString();
                SubName[i]= (dr1["Sub_Name"]).ToString();
                SubGrade[i]= (dr1["Sub_Grades"]).ToString();

                Console.WriteLine(SubName [i]);
                i++;
                SelectGrades();
                dataToCombo();
            }
        }
        private void InputGrade()//Inputing the Grades of the students
        {
            con.Close();
            con.Open();
            
            int count = 0;

            OleDbCommand adapt1 = new OleDbCommand("Select count(*) from [Erollment] where [Stud_Id]='" + cmbStudentNumber.Text + "' and  [Stud_Year]='" + cmbYear.Text + "' and [Stud_Sem]='" + cmbSem.Text + "' ", con);

            count = (int)adapt1.ExecuteScalar();//i use the count to count the rowws
            con.Close();
            Console.WriteLine(count);
            try
            {
                switch (count)
                {
                    case 1:
                        {
                            con.Open();
                            OleDbCommand cmd1 = new OleDbCommand("update [Erollment] set [Sub_Grades]=? where [Sub_Name]='" + cmbSub1.Text + "'",con); cmd1.Parameters.AddWithValue("@1", OleDbType.VarChar).Value = txtGr1.Text; cmd1.ExecuteNonQuery();
                            con.Close();
                            break;
                        }
                    case 2:
                        {
                            con.Open();
                            OleDbCommand cmd1 = new OleDbCommand("update [Erollment] set [Sub_Grades]=? where [Sub_Name]='" + cmbSub1.Text + "'",con); cmd1.Parameters.AddWithValue("@1", OleDbType.VarChar).Value = txtGr1.Text; cmd1.ExecuteNonQuery();
                            OleDbCommand cmd2 = new OleDbCommand("update [Erollment] set [Sub_Grades]=? where [Sub_Name]='" + cmbSub2.Text + "'",con); cmd2.Parameters.AddWithValue("@1", OleDbType.VarChar).Value = txtGr2.Text; cmd2.ExecuteNonQuery();
                            con.Close();
                            break;
                        }
                    case 3:
                        {
                            con.Open();
                            OleDbCommand cmd1 = new OleDbCommand("update [Erollment] set [Sub_Grades]=? where [Sub_Name]='" + cmbSub1.Text + "'",con); cmd1.Parameters.AddWithValue("@1", OleDbType.VarChar).Value = txtGr1.Text; cmd1.ExecuteNonQuery();
                            OleDbCommand cmd2 = new OleDbCommand("update [Erollment] set [Sub_Grades]=? where [Sub_Name]='" + cmbSub2.Text + "'",con); cmd2.Parameters.AddWithValue("@1", OleDbType.VarChar).Value = txtGr2.Text; cmd2.ExecuteNonQuery();
                            OleDbCommand cmd3 = new OleDbCommand("update [Erollment] set [Sub_Grades]=? where [Sub_Name]='" + cmbSub3.Text + "'",con); cmd3.Parameters.AddWithValue("@1", OleDbType.VarChar).Value = txtGr3.Text; cmd3.ExecuteNonQuery();
                            con.Close();
                            break;
                        }
                    case 4:
                        {
                            con.Open();
                            OleDbCommand cmd1 = new OleDbCommand("update [Erollment] set [Sub_Grades]=? where [Sub_Name]='" + cmbSub1.Text + "'",con); cmd1.Parameters.AddWithValue("@1", OleDbType.VarChar).Value = txtGr1.Text; cmd1.ExecuteNonQuery();
                            OleDbCommand cmd2 = new OleDbCommand("update [Erollment] set [Sub_Grades]=? where [Sub_Name]='" + cmbSub2.Text + "'",con); cmd2.Parameters.AddWithValue("@1", OleDbType.VarChar).Value = txtGr2.Text; cmd2.ExecuteNonQuery();
                            OleDbCommand cmd3 = new OleDbCommand("update [Erollment] set [Sub_Grades]=? where [Sub_Name]='" + cmbSub3.Text + "'",con); cmd3.Parameters.AddWithValue("@1", OleDbType.VarChar).Value = txtGr3.Text; cmd3.ExecuteNonQuery();
                            OleDbCommand cmd4 = new OleDbCommand("update [Erollment] set [Sub_Grades]=? where [Sub_Name]='" + cmbSub4.Text + "'",con); cmd4.Parameters.AddWithValue("@1", OleDbType.VarChar).Value = txtGr4.Text; cmd4.ExecuteNonQuery();
                            con.Close();
                            break;
                        }
                    case 5:
                        {
                            con.Open();
                            OleDbCommand cmd1 = new OleDbCommand("update [Erollment] set [Sub_Grades]=? where [Sub_Name]='" + cmbSub1.Text + "'",con); cmd1.Parameters.AddWithValue("@1", OleDbType.VarChar).Value = txtGr1.Text; cmd1.ExecuteNonQuery();
                            OleDbCommand cmd2 = new OleDbCommand("update [Erollment] set [Sub_Grades]=? where [Sub_Name]='" + cmbSub2.Text + "'",con); cmd2.Parameters.AddWithValue("@1", OleDbType.VarChar).Value = txtGr2.Text; cmd2.ExecuteNonQuery();
                            OleDbCommand cmd3 = new OleDbCommand("update [Erollment] set [Sub_Grades]=? where [Sub_Name]='" + cmbSub3.Text + "'",con); cmd3.Parameters.AddWithValue("@1", OleDbType.VarChar).Value = txtGr3.Text; cmd3.ExecuteNonQuery();
                            OleDbCommand cmd4 = new OleDbCommand("update [Erollment] set [Sub_Grades]=? where [Sub_Name]='" + cmbSub4.Text + "'",con); cmd4.Parameters.AddWithValue("@1", OleDbType.VarChar).Value = txtGr4.Text; cmd4.ExecuteNonQuery();
                            OleDbCommand cmd5 = new OleDbCommand("update [Erollment] set [Sub_Grades]=? where [Sub_Name]='" + cmbSub5.Text + "'",con); cmd5.Parameters.AddWithValue("@1", OleDbType.VarChar).Value = txtGr5.Text; cmd5.ExecuteNonQuery();
                            con.Close();
                            break;
                        }
                    case 6:
                        {
                            con.Open();
                            OleDbCommand cmd1 = new OleDbCommand("update [Erollment] set [Sub_Grades]=? where [Sub_Name]='" + cmbSub1.Text + "'",con); cmd1.Parameters.AddWithValue("@1", OleDbType.VarChar).Value = txtGr1.Text; cmd1.ExecuteNonQuery();
                            OleDbCommand cmd2 = new OleDbCommand("update [Erollment] set [Sub_Grades]=? where [Sub_Name]='" + cmbSub2.Text + "'",con); cmd2.Parameters.AddWithValue("@1", OleDbType.VarChar).Value = txtGr2.Text; cmd2.ExecuteNonQuery();
                            OleDbCommand cmd3 = new OleDbCommand("update [Erollment] set [Sub_Grades]=? where [Sub_Name]='" + cmbSub3.Text + "'",con); cmd3.Parameters.AddWithValue("@1", OleDbType.VarChar).Value = txtGr3.Text; cmd3.ExecuteNonQuery();
                            OleDbCommand cmd4 = new OleDbCommand("update [Erollment] set [Sub_Grades]=? where [Sub_Name]='" + cmbSub4.Text + "'",con); cmd4.Parameters.AddWithValue("@1", OleDbType.VarChar).Value = txtGr4.Text; cmd4.ExecuteNonQuery();
                            OleDbCommand cmd5 = new OleDbCommand("update [Erollment] set [Sub_Grades]=? where [Sub_Name]='" + cmbSub5.Text + "'",con); cmd5.Parameters.AddWithValue("@1", OleDbType.VarChar).Value = txtGr5.Text; cmd5.ExecuteNonQuery();
                            OleDbCommand cmd6 = new OleDbCommand("update [Erollment] set [Sub_Grades]=? where [Sub_Name]='" + cmbSub6.Text + "'",con); cmd6.Parameters.AddWithValue("@1", OleDbType.VarChar).Value = txtGr6.Text; cmd6.ExecuteNonQuery();
                            con.Close();
                            break;
                        }
                    case 7:
                        {
                            con.Open();
                            OleDbCommand cmd1 = new OleDbCommand("update [Erollment] set [Sub_Grades]=? where [Sub_Name]='" + cmbSub1.Text + "'",con); cmd1.Parameters.AddWithValue("@1", OleDbType.VarChar).Value = txtGr1.Text; cmd1.ExecuteNonQuery();
                            OleDbCommand cmd2 = new OleDbCommand("update [Erollment] set [Sub_Grades]=? where [Sub_Name]='" + cmbSub2.Text + "'",con); cmd2.Parameters.AddWithValue("@1", OleDbType.VarChar).Value = txtGr2.Text; cmd2.ExecuteNonQuery();
                            OleDbCommand cmd3 = new OleDbCommand("update [Erollment] set [Sub_Grades]=? where [Sub_Name]='" + cmbSub3.Text + "'",con); cmd3.Parameters.AddWithValue("@1", OleDbType.VarChar).Value = txtGr3.Text; cmd3.ExecuteNonQuery();
                            OleDbCommand cmd4 = new OleDbCommand("update [Erollment] set [Sub_Grades]=? where [Sub_Name]='" + cmbSub4.Text + "'",con); cmd4.Parameters.AddWithValue("@1", OleDbType.VarChar).Value = txtGr4.Text; cmd4.ExecuteNonQuery();
                            OleDbCommand cmd5 = new OleDbCommand("update [Erollment] set [Sub_Grades]=? where [Sub_Name]='" + cmbSub5.Text + "'",con); cmd5.Parameters.AddWithValue("@1", OleDbType.VarChar).Value = txtGr5.Text; cmd5.ExecuteNonQuery();
                            OleDbCommand cmd6 = new OleDbCommand("update [Erollment] set [Sub_Grades]=? where [Sub_Name]='" + cmbSub6.Text + "'",con); cmd6.Parameters.AddWithValue("@1", OleDbType.VarChar).Value = txtGr6.Text; cmd6.ExecuteNonQuery();
                            OleDbCommand cmd7 = new OleDbCommand("update [Erollment] set [Sub_Grades]=? where [Sub_Name]='" + cmbSub7.Text + "'",con); cmd7.Parameters.AddWithValue("@1", OleDbType.VarChar).Value = txtGr7.Text; cmd7.ExecuteNonQuery();
                            con.Close();
                            break;
                        }
                    case 8:
                        {
                            con.Open();
                            OleDbCommand cmd1 = new OleDbCommand("update [Erollment] set [Sub_Grades]=? where [Sub_Name]='" + cmbSub1.Text + "'",con); cmd1.Parameters.AddWithValue("@1", OleDbType.VarChar).Value = txtGr1.Text; cmd1.ExecuteNonQuery();
                            OleDbCommand cmd2 = new OleDbCommand("update [Erollment] set [Sub_Grades]=? where [Sub_Name]='" + cmbSub2.Text + "'",con); cmd2.Parameters.AddWithValue("@1", OleDbType.VarChar).Value = txtGr2.Text; cmd2.ExecuteNonQuery();
                            OleDbCommand cmd3 = new OleDbCommand("update [Erollment] set [Sub_Grades]=? where [Sub_Name]='" + cmbSub3.Text + "'",con); cmd3.Parameters.AddWithValue("@1", OleDbType.VarChar).Value = txtGr3.Text; cmd3.ExecuteNonQuery();
                            OleDbCommand cmd4 = new OleDbCommand("update [Erollment] set [Sub_Grades]=? where [Sub_Name]='" + cmbSub4.Text + "'",con); cmd4.Parameters.AddWithValue("@1", OleDbType.VarChar).Value = txtGr4.Text; cmd4.ExecuteNonQuery();
                            OleDbCommand cmd5 = new OleDbCommand("update [Erollment] set [Sub_Grades]=? where [Sub_Name]='" + cmbSub5.Text + "'",con); cmd5.Parameters.AddWithValue("@1", OleDbType.VarChar).Value = txtGr5.Text; cmd5.ExecuteNonQuery();
                            OleDbCommand cmd6 = new OleDbCommand("update [Erollment] set [Sub_Grades]=? where [Sub_Name]='" + cmbSub6.Text + "'",con); cmd6.Parameters.AddWithValue("@1", OleDbType.VarChar).Value = txtGr6.Text; cmd6.ExecuteNonQuery();
                            OleDbCommand cmd7 = new OleDbCommand("update [Erollment] set [Sub_Grades]=? where [Sub_Name]='" + cmbSub7.Text + "'",con); cmd7.Parameters.AddWithValue("@1", OleDbType.VarChar).Value = txtGr7.Text; cmd7.ExecuteNonQuery();
                            OleDbCommand cmd8 = new OleDbCommand("update [Erollment] set [Sub_Grades]=? where [Sub_Name]='" + cmbSub8.Text + "'",con); cmd8.Parameters.AddWithValue("@1", OleDbType.VarChar).Value = txtGr8.Text; cmd8.ExecuteNonQuery();
                            con.Close();
                            break;
                        }
                    case 9:
                        {
                            con.Open();
                            OleDbCommand cmd1 = new OleDbCommand("update [Erollment] set [Sub_Grades]=? where [Sub_Name]='" + cmbSub1.Text + "'",con); cmd1.Parameters.AddWithValue("@1", OleDbType.VarChar).Value = txtGr1.Text; cmd1.ExecuteNonQuery();
                            OleDbCommand cmd2 = new OleDbCommand("update [Erollment] set [Sub_Grades]=? where [Sub_Name]='" + cmbSub2.Text + "'",con); cmd2.Parameters.AddWithValue("@1", OleDbType.VarChar).Value = txtGr2.Text; cmd2.ExecuteNonQuery();
                            OleDbCommand cmd3 = new OleDbCommand("update [Erollment] set [Sub_Grades]=? where [Sub_Name]='" + cmbSub3.Text + "'",con); cmd3.Parameters.AddWithValue("@1", OleDbType.VarChar).Value = txtGr3.Text; cmd3.ExecuteNonQuery();
                            OleDbCommand cmd4 = new OleDbCommand("update [Erollment] set [Sub_Grades]=? where [Sub_Name]='" + cmbSub4.Text + "'",con); cmd4.Parameters.AddWithValue("@1", OleDbType.VarChar).Value = txtGr4.Text; cmd4.ExecuteNonQuery();
                            OleDbCommand cmd5 = new OleDbCommand("update [Erollment] set [Sub_Grades]=? where [Sub_Name]='" + cmbSub5.Text + "'",con); cmd5.Parameters.AddWithValue("@1", OleDbType.VarChar).Value = txtGr5.Text; cmd5.ExecuteNonQuery();
                            OleDbCommand cmd6 = new OleDbCommand("update [Erollment] set [Sub_Grades]=? where [Sub_Name]='" + cmbSub6.Text + "'",con); cmd6.Parameters.AddWithValue("@1", OleDbType.VarChar).Value = txtGr6.Text; cmd6.ExecuteNonQuery();
                            OleDbCommand cmd7 = new OleDbCommand("update [Erollment] set [Sub_Grades]=? where [Sub_Name]='" + cmbSub7.Text + "'",con); cmd7.Parameters.AddWithValue("@1", OleDbType.VarChar).Value = txtGr7.Text; cmd7.ExecuteNonQuery();
                            OleDbCommand cmd8 = new OleDbCommand("update [Erollment] set [Sub_Grades]=? where [Sub_Name]='" + cmbSub8.Text + "'",con); cmd8.Parameters.AddWithValue("@1", OleDbType.VarChar).Value = txtGr8.Text; cmd8.ExecuteNonQuery();
                            OleDbCommand cmd9 = new OleDbCommand("update [Erollment] set [Sub_Grades]=? where [Sub_Name]='" + cmbSub9.Text + "'",con); cmd9.Parameters.AddWithValue("@1", OleDbType.VarChar).Value = txtGr9.Text; cmd9.ExecuteNonQuery();
                            con.Close();
                            break;
                        }
                    case 10:
                        {
                            con.Open();
                            OleDbCommand cmd1 = new OleDbCommand("update [Erollment] set [Sub_Grades]=? where [Sub_Name]='" + cmbSub1.Text + "'",con); cmd1.Parameters.AddWithValue("@1", OleDbType.VarChar).Value = txtGr1.Text; cmd1.ExecuteNonQuery();
                            OleDbCommand cmd2 = new OleDbCommand("update [Erollment] set [Sub_Grades]=? where [Sub_Name]='" + cmbSub2.Text + "'",con); cmd2.Parameters.AddWithValue("@1", OleDbType.VarChar).Value = txtGr2.Text; cmd2.ExecuteNonQuery();
                            OleDbCommand cmd3 = new OleDbCommand("update [Erollment] set [Sub_Grades]=? where [Sub_Name]='" + cmbSub3.Text + "'",con); cmd3.Parameters.AddWithValue("@1", OleDbType.VarChar).Value = txtGr3.Text; cmd3.ExecuteNonQuery();
                            OleDbCommand cmd4 = new OleDbCommand("update [Erollment] set [Sub_Grades]=? where [Sub_Name]='" + cmbSub4.Text + "'",con); cmd4.Parameters.AddWithValue("@1", OleDbType.VarChar).Value = txtGr4.Text; cmd4.ExecuteNonQuery();
                            OleDbCommand cmd5 = new OleDbCommand("update [Erollment] set [Sub_Grades]=? where [Sub_Name]='" + cmbSub5.Text + "'",con); cmd5.Parameters.AddWithValue("@1", OleDbType.VarChar).Value = txtGr5.Text; cmd5.ExecuteNonQuery();
                            OleDbCommand cmd6 = new OleDbCommand("update [Erollment] set [Sub_Grades]=? where [Sub_Name]='" + cmbSub6.Text + "'",con); cmd6.Parameters.AddWithValue("@1", OleDbType.VarChar).Value = txtGr6.Text; cmd6.ExecuteNonQuery();
                            OleDbCommand cmd7 = new OleDbCommand("update [Erollment] set [Sub_Grades]=? where [Sub_Name]='" + cmbSub7.Text + "'",con); cmd7.Parameters.AddWithValue("@1", OleDbType.VarChar).Value = txtGr7.Text; cmd7.ExecuteNonQuery();
                            OleDbCommand cmd8 = new OleDbCommand("update [Erollment] set [Sub_Grades]=? where [Sub_Name]='" + cmbSub8.Text + "'",con); cmd8.Parameters.AddWithValue("@1", OleDbType.VarChar).Value = txtGr8.Text; cmd8.ExecuteNonQuery();
                            OleDbCommand cmd9 = new OleDbCommand("update [Erollment] set [Sub_Grades]=? where [Sub_Name]='" + cmbSub9.Text + "'",con); cmd9.Parameters.AddWithValue("@1", OleDbType.VarChar).Value = txtGr9.Text; cmd9.ExecuteNonQuery();
                            OleDbCommand cmd10 = new OleDbCommand("update [Erollment] set [Sub_Grades]=? where [Sub_Name]='" + cmbSub10.Text + "'",con); cmd10.Parameters.AddWithValue("@1", OleDbType.VarChar).Value = txtGr10.Text; cmd10.ExecuteNonQuery();
                            con.Close();
                            break;
                        }
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void dataToCombo()// Displaying Data of subjects to comboboxes and textbox
        {
            con.Close();
            con.Open();
            int count = 0;

            OleDbCommand adapt1 = new OleDbCommand("Select count(*) from [Erollment] where [Stud_Id]='" + cmbStudentNumber.Text + "' and  [Stud_Year]='" + cmbYear.Text + "' and [Stud_Sem]='" + cmbSem.Text + "' ", con);



            count = (int)adapt1.ExecuteScalar();//i use the count to count the rowws

            Console.WriteLine(count);
            try
            {
                switch (count)
                {
                    case 1:
                        {
                            cmbSub1.Text = dgvGrades.Rows[0].Cells[1].Value.ToString(); txtGr1.Text = dgvGrades.Rows[0].Cells[2].Value.ToString();
                            break;
                        }
                    case 2:
                        {
                            cmbSub1.Text = dgvGrades.Rows[0].Cells[1].Value.ToString(); txtGr1.Text = dgvGrades.Rows[0].Cells[2].Value.ToString();
                            cmbSub2.Text = dgvGrades.Rows[1].Cells[1].Value.ToString(); txtGr2.Text = dgvGrades.Rows[1].Cells[2].Value.ToString();
                            break;
                        }
                    case 3:
                        {
                            cmbSub1.Text = dgvGrades.Rows[0].Cells[1].Value.ToString(); txtGr1.Text = dgvGrades.Rows[0].Cells[2].Value.ToString();
                            cmbSub2.Text = dgvGrades.Rows[1].Cells[1].Value.ToString(); txtGr2.Text = dgvGrades.Rows[1].Cells[2].Value.ToString();
                            cmbSub3.Text = dgvGrades.Rows[2].Cells[1].Value.ToString(); txtGr3.Text = dgvGrades.Rows[2].Cells[2].Value.ToString();
                            break;
                        }
                    case 4:
                        {
                            cmbSub1.Text = dgvGrades.Rows[0].Cells[1].Value.ToString(); txtGr1.Text = dgvGrades.Rows[0].Cells[2].Value.ToString();
                            cmbSub2.Text = dgvGrades.Rows[1].Cells[1].Value.ToString(); txtGr2.Text = dgvGrades.Rows[1].Cells[2].Value.ToString();
                            cmbSub3.Text = dgvGrades.Rows[2].Cells[1].Value.ToString(); txtGr3.Text = dgvGrades.Rows[2].Cells[2].Value.ToString();
                            cmbSub4.Text = dgvGrades.Rows[3].Cells[1].Value.ToString(); txtGr4.Text = dgvGrades.Rows[3].Cells[2].Value.ToString();
                            break;
                        }
                    case 5:
                        {
                            cmbSub1.Text = dgvGrades.Rows[0].Cells[1].Value.ToString(); txtGr1.Text = dgvGrades.Rows[0].Cells[2].Value.ToString();
                            cmbSub2.Text = dgvGrades.Rows[1].Cells[1].Value.ToString(); txtGr2.Text = dgvGrades.Rows[1].Cells[2].Value.ToString();
                            cmbSub3.Text = dgvGrades.Rows[2].Cells[1].Value.ToString(); txtGr3.Text = dgvGrades.Rows[2].Cells[2].Value.ToString();
                            cmbSub4.Text = dgvGrades.Rows[3].Cells[1].Value.ToString(); txtGr4.Text = dgvGrades.Rows[3].Cells[2].Value.ToString();
                            cmbSub5.Text = dgvGrades.Rows[4].Cells[1].Value.ToString(); txtGr5.Text = dgvGrades.Rows[4].Cells[2].Value.ToString();
                            break;
                        }
                    case 6:
                        {
                            cmbSub1.Text = dgvGrades.Rows[0].Cells[1].Value.ToString(); txtGr1.Text = dgvGrades.Rows[0].Cells[2].Value.ToString();
                            cmbSub2.Text = dgvGrades.Rows[1].Cells[1].Value.ToString(); txtGr2.Text = dgvGrades.Rows[1].Cells[2].Value.ToString();
                            cmbSub3.Text = dgvGrades.Rows[2].Cells[1].Value.ToString(); txtGr3.Text = dgvGrades.Rows[2].Cells[2].Value.ToString();
                            cmbSub4.Text = dgvGrades.Rows[3].Cells[1].Value.ToString(); txtGr4.Text = dgvGrades.Rows[3].Cells[2].Value.ToString();
                            cmbSub5.Text = dgvGrades.Rows[4].Cells[1].Value.ToString(); txtGr5.Text = dgvGrades.Rows[4].Cells[2].Value.ToString();
                            cmbSub6.Text = dgvGrades.Rows[5].Cells[1].Value.ToString(); txtGr6.Text = dgvGrades.Rows[5].Cells[2].Value.ToString();
                            break;
                        }
                    case 7:
                        {
                            cmbSub1.Text = dgvGrades.Rows[0].Cells[1].Value.ToString(); txtGr1.Text = dgvGrades.Rows[0].Cells[2].Value.ToString();
                            cmbSub2.Text = dgvGrades.Rows[1].Cells[1].Value.ToString(); txtGr2.Text = dgvGrades.Rows[1].Cells[2].Value.ToString();
                            cmbSub3.Text = dgvGrades.Rows[2].Cells[1].Value.ToString(); txtGr3.Text = dgvGrades.Rows[2].Cells[2].Value.ToString();
                            cmbSub4.Text = dgvGrades.Rows[3].Cells[1].Value.ToString(); txtGr4.Text = dgvGrades.Rows[3].Cells[2].Value.ToString();
                            cmbSub5.Text = dgvGrades.Rows[4].Cells[1].Value.ToString(); txtGr5.Text = dgvGrades.Rows[4].Cells[2].Value.ToString();
                            cmbSub6.Text = dgvGrades.Rows[5].Cells[1].Value.ToString(); txtGr6.Text = dgvGrades.Rows[5].Cells[2].Value.ToString();
                            cmbSub7.Text = dgvGrades.Rows[6].Cells[1].Value.ToString(); txtGr7.Text = dgvGrades.Rows[6].Cells[2].Value.ToString();
                            break;
                        }
                    case 8:
                        {
                            cmbSub1.Text = dgvGrades.Rows[0].Cells[1].Value.ToString(); txtGr1.Text = dgvGrades.Rows[0].Cells[2].Value.ToString();
                            cmbSub2.Text = dgvGrades.Rows[1].Cells[1].Value.ToString(); txtGr2.Text = dgvGrades.Rows[1].Cells[2].Value.ToString();
                            cmbSub3.Text = dgvGrades.Rows[2].Cells[1].Value.ToString(); txtGr3.Text = dgvGrades.Rows[2].Cells[2].Value.ToString();
                            cmbSub4.Text = dgvGrades.Rows[3].Cells[1].Value.ToString(); txtGr4.Text = dgvGrades.Rows[3].Cells[2].Value.ToString();
                            cmbSub5.Text = dgvGrades.Rows[4].Cells[1].Value.ToString(); txtGr5.Text = dgvGrades.Rows[4].Cells[2].Value.ToString();
                            cmbSub6.Text = dgvGrades.Rows[5].Cells[1].Value.ToString(); txtGr6.Text = dgvGrades.Rows[5].Cells[2].Value.ToString();
                            cmbSub7.Text = dgvGrades.Rows[6].Cells[1].Value.ToString(); txtGr7.Text = dgvGrades.Rows[6].Cells[2].Value.ToString();
                            break;
                        }
                    case 9:
                        {
                            cmbSub1.Text = dgvGrades.Rows[0].Cells[1].Value.ToString(); txtGr1.Text = dgvGrades.Rows[0].Cells[2].Value.ToString();
                            cmbSub2.Text = dgvGrades.Rows[1].Cells[1].Value.ToString(); txtGr2.Text = dgvGrades.Rows[1].Cells[2].Value.ToString();
                            cmbSub3.Text = dgvGrades.Rows[2].Cells[1].Value.ToString(); txtGr3.Text = dgvGrades.Rows[2].Cells[2].Value.ToString();
                            cmbSub4.Text = dgvGrades.Rows[3].Cells[1].Value.ToString(); txtGr4.Text = dgvGrades.Rows[3].Cells[2].Value.ToString();
                            cmbSub5.Text = dgvGrades.Rows[4].Cells[1].Value.ToString(); txtGr5.Text = dgvGrades.Rows[4].Cells[2].Value.ToString();
                            cmbSub6.Text = dgvGrades.Rows[5].Cells[1].Value.ToString(); txtGr6.Text = dgvGrades.Rows[5].Cells[2].Value.ToString();
                            cmbSub7.Text = dgvGrades.Rows[6].Cells[1].Value.ToString(); txtGr7.Text = dgvGrades.Rows[6].Cells[2].Value.ToString();
                            cmbSub8.Text = dgvGrades.Rows[7].Cells[1].Value.ToString(); txtGr8.Text = dgvGrades.Rows[7].Cells[2].Value.ToString();
                            break;
                        }
                    case 10:
                        {
                            cmbSub1.Text = dgvGrades.Rows[0].Cells[1].Value.ToString(); txtGr1.Text = dgvGrades.Rows[0].Cells[2].Value.ToString();
                            cmbSub2.Text = dgvGrades.Rows[1].Cells[1].Value.ToString(); txtGr2.Text = dgvGrades.Rows[1].Cells[2].Value.ToString();
                            cmbSub3.Text = dgvGrades.Rows[2].Cells[1].Value.ToString(); txtGr3.Text = dgvGrades.Rows[2].Cells[2].Value.ToString();
                            cmbSub4.Text = dgvGrades.Rows[3].Cells[1].Value.ToString(); txtGr4.Text = dgvGrades.Rows[3].Cells[2].Value.ToString();
                            cmbSub5.Text = dgvGrades.Rows[4].Cells[1].Value.ToString(); txtGr5.Text = dgvGrades.Rows[4].Cells[2].Value.ToString();
                            cmbSub6.Text = dgvGrades.Rows[5].Cells[1].Value.ToString(); txtGr6.Text = dgvGrades.Rows[5].Cells[2].Value.ToString();
                            cmbSub7.Text = dgvGrades.Rows[6].Cells[1].Value.ToString(); txtGr7.Text = dgvGrades.Rows[6].Cells[2].Value.ToString();
                            cmbSub8.Text = dgvGrades.Rows[7].Cells[1].Value.ToString(); txtGr8.Text = dgvGrades.Rows[7].Cells[2].Value.ToString();
                            cmbSub9.Text = dgvGrades.Rows[8].Cells[1].Value.ToString(); txtGr9.Text = dgvGrades.Rows[8].Cells[2].Value.ToString();
                            cmbSub10.Text = dgvGrades.Rows[9].Cells[1].Value.ToString(); txtGr10.Text = dgvGrades.Rows[9].Cells[2].Value.ToString();
                            break;
                        }
                }
               con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmbStudentNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*
            SelectGrades();
            con.Open();
            if (cmbStudentNumber.Text != "")
            {
                OleDbCommand cmd = new OleDbCommand("Select [Sub_Name] from [Erollment] where [Stud_Id]=? ", con);
                cmd.Parameters.AddWithValue("@1", OleDbType.VarChar).Value = cmbStudentNumber.Text;
                OleDbDataReader da = cmd.ExecuteReader();

                while (da.Read())
                {
                    txtGr1.Text = da.GetValue(0).ToString();
                   
                }
            }
            con.Close();
             */
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Clear_allboxes();
            SelectGrades();
            dataToCombo();
        }

        private void Clear_allboxes()
        {
            cmbSub1.Text = "";
            cmbSub2.Text = "";
            cmbSub3.Text = "";
            cmbSub4.Text = "";
            cmbSub5.Text = "";
            cmbSub6.Text = "";
            cmbSub7.Text = "";
            cmbSub8.Text = "";
            cmbSub9.Text = "";
            cmbSub10.Text = "";

            txtGr1.Text = "";
            txtGr2.Text = "";
            txtGr3.Text = "";
            txtGr4.Text = "";
            txtGr5.Text = "";
            txtGr6.Text = "";
            txtGr7.Text = "";
            txtGr8.Text = "";
            txtGr9.Text = "";
            txtGr10.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Grading grad = new Grading();

            grad.Close();

            this.Hide();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void txtGr1_TextChanged(object sender, EventArgs e)
        {
            if ((txtGr1.Text == ""))
            {
                lbl1.Text = "-";
            }  
            else if ((txtGr1.Text == "1") || (txtGr1.Text == "1.00"))
            {
                lbl1.Text = "98-100";
            }
            else if (txtGr1.Text == "1.25")
            {
                lbl1.Text = "95-97";
            }
            else if ((txtGr1.Text == "1.5") || (txtGr1.Text == "1.50"))
            {
                lbl1.Text = "92-94";
            }
            else if ((txtGr1.Text == "1.7") || (txtGr1.Text == "1.75"))
            {
                lbl1.Text = "89-91";
            }
            else if ((txtGr1.Text == "2") || (txtGr1.Text == "2.00"))
            {
                lbl1.Text = "86-88";
            }
            else if (txtGr1.Text == "2.25")
            {
                lbl1.Text = "83-85";
            }
            else if ((txtGr1.Text == "2.5") || (txtGr1.Text == "2.50"))
            {
                lbl1.Text = "80-82";
            }
            else if ((txtGr1.Text == "2.75") || (txtGr1.Text == "2.7"))
            {
                lbl1.Text = "77-79";
            }
            else if ((txtGr1.Text == "5") || (txtGr1.Text == "5.00"))
            {
                lbl1.Text = "75";
            }  
        }

        private void txtGr2_TextChanged(object sender, EventArgs e)
        {
            if ((txtGr2.Text == ""))
            {
                lbl2.Text = "-";
            }
            else if ((txtGr2.Text == "1") || (txtGr2.Text == "1.00"))
            {
                lbl2.Text = "98-100";
            }
            else if (txtGr2.Text == "1.25")
            {
                lbl2.Text = "95-97";
            }
            else if ((txtGr2.Text == "1.5") || (txtGr2.Text == "1.50"))
            {
                lbl2.Text = "92-94";
            }
            else if ((txtGr2.Text == "1.7") || (txtGr2.Text == "1.75"))
            {
                lbl2.Text = "89-91";
            }
            else if ((txtGr2.Text == "2") || (txtGr2.Text == "2.00"))
            {
                lbl2.Text = "86-88";
            }
            else if (txtGr2.Text == "2.25")
            {
                lbl1.Text = "83-85";
            }
            else if ((txtGr1.Text == "2.5") || (txtGr1.Text == "2.50"))
            {
                lbl1.Text = "80-82";
            }
            else if ((txtGr1.Text == "2.75") || (txtGr1.Text == "2.7"))
            {
                lbl1.Text = "77-79";
            }
            else if ((txtGr1.Text == "5") || (txtGr1.Text == "5.00"))
            {
                lbl1.Text = "75";
            }  
        }

        private void txtGr3_TextChanged(object sender, EventArgs e)
        {
            if ((txtGr3.Text == ""))
            {
                lbl3.Text = "-";
            }
            else if ((txtGr3.Text == "1") || (txtGr3.Text == "1.00"))
            {
                lbl3.Text = "98-100";
            }
            else if (txtGr3.Text == "1.25")
            {
                lbl3.Text = "95-97";
            }
            else if ((txtGr3.Text == "1.5") || (txtGr3.Text == "1.50"))
            {
                lbl3.Text = "92-94";
            }
            else if ((txtGr3.Text == "1.7") || (txtGr3.Text == "1.75"))
            {
                lbl3.Text = "89-91";
            }
            else if ((txtGr3.Text == "2") || (txtGr3.Text == "2.00"))
            {
                lbl3.Text = "86-88";
            }
            else if (txtGr3.Text == "2.25")
            {
                lbl3.Text = "83-85";
            }
            else if ((txtGr3.Text == "2.5") || (txtGr3.Text == "2.50"))
            {
                lbl3.Text = "80-82";
            }
            else if ((txtGr3.Text == "2.75") || (txtGr3.Text == "2.7"))
            {
                lbl3.Text = "77-79";
            }
            else if ((txtGr3.Text == "5") || (txtGr3.Text == "5.00"))
            {
                lbl3.Text = "75";
            }  
        }

        private void txtGr4_TextChanged(object sender, EventArgs e)
        {
            if ((txtGr4.Text == ""))
            {
                lbl4.Text = "-";
            }
            else if ((txtGr4.Text == "1") || (txtGr4.Text == "1.00"))
            {
                lbl4.Text = "98-100";
            }
            else if (txtGr4.Text == "1.25")
            {
                lbl4.Text = "95-97";
            }
            else if ((txtGr4.Text == "1.5") || (txtGr4.Text == "1.50"))
            {
                lbl4.Text = "92-94";
            }
            else if ((txtGr4.Text == "1.7") || (txtGr4.Text == "1.75"))
            {
                lbl4.Text = "89-91";
            }
            else if ((txtGr4.Text == "2") || (txtGr4.Text == "2.00"))
            {
                lbl4.Text = "86-88";
            }
            else if (txtGr4.Text == "2.25")
            {
                lbl4.Text = "83-85";
            }
            else if ((txtGr4.Text == "2.5") || (txtGr4.Text == "2.50"))
            {
                lbl4.Text = "80-82";
            }
            else if ((txtGr4.Text == "2.75") || (txtGr4.Text == "2.7"))
            {
                lbl4.Text = "77-79";
            }
            else if ((txtGr4.Text == "5") || (txtGr4.Text == "5.00"))
            {
                lbl4.Text = "75";
            }  
        }

        private void rectangleShape2_Click(object sender, EventArgs e)
        {

        }

        private void txtGr5_TextChanged(object sender, EventArgs e)
        {
            if ((txtGr5.Text == ""))
            {
                lbl5.Text = "-";
            }
            else if ((txtGr5.Text == "1") || (txtGr5.Text == "1.00"))
            {
                lbl5.Text = "98-100";
            }
            else if (txtGr5.Text == "1.25")
            {
                lbl5.Text = "95-97";
            }
            else if ((txtGr5.Text == "1.5") || (txtGr5.Text == "1.50"))
            {
                lbl5.Text = "92-94";
            }
            else if ((txtGr5.Text == "1.7") || (txtGr5.Text == "1.75"))
            {
                lbl5.Text = "89-91";
            }
            else if ((txtGr5.Text == "2") || (txtGr5.Text == "2.00"))
            {
                lbl5.Text = "86-88";
            }
            else if (txtGr5.Text == "2.25")
            {
                lbl5.Text = "83-85";
            }
            else if ((txtGr5.Text == "2.5") || (txtGr5.Text == "2.50"))
            {
                lbl5.Text = "80-82";
            }
            else if ((txtGr5.Text == "2.75") || (txtGr5.Text == "2.7"))
            {
                lbl5.Text = "77-79";
            }
            else if ((txtGr5.Text == "5") || (txtGr5.Text == "5.00"))
            {
                lbl5.Text = "75";
            }  
        }

        private void txtGr6_TextChanged(object sender, EventArgs e)
        {
            if ((txtGr6.Text == ""))
            {
                lbl6.Text = "-";
            }
            else if ((txtGr6.Text == "1") || (txtGr6.Text == "1.00"))
            {
                lbl6.Text = "98-100";
            }
            else if (txtGr6.Text == "1.25")
            {
                lbl6.Text = "95-97";
            }
            else if ((txtGr6.Text == "1.5") || (txtGr6.Text == "1.50"))
            {
                lbl6.Text = "92-94";
            }
            else if ((txtGr6.Text == "1.7") || (txtGr6.Text == "1.75"))
            {
                lbl6.Text = "89-91";
            }
            else if ((txtGr6.Text == "2") || (txtGr6.Text == "2.00"))
            {
                lbl6.Text = "86-88";
            }
            else if (txtGr6.Text == "2.25")
            {
                lbl6.Text = "83-85";
            }
            else if ((txtGr6.Text == "2.5") || (txtGr6.Text == "2.50"))
            {
                lbl6.Text = "80-82";
            }
            else if ((txtGr6.Text == "2.75") || (txtGr6.Text == "2.7"))
            {
                lbl6.Text = "77-79";
            }
            else if ((txtGr6.Text == "5") || (txtGr6.Text == "5.00"))
            {
                lbl6.Text = "75";
            }  
        }

        private void txtGr7_TextChanged(object sender, EventArgs e)
        {
            if ((txtGr7.Text == ""))
            {
                lbl7.Text = "-";
            }
            else if ((txtGr7.Text == "1") || (txtGr7.Text == "1.00"))
            {
                lbl7.Text = "98-100";
            }
            else if (txtGr7.Text == "1.25")
            {
                lbl7.Text = "95-97";
            }
            else if ((txtGr7.Text == "1.5") || (txtGr7.Text == "1.50"))
            {
                lbl7.Text = "92-94";
            }
            else if ((txtGr7.Text == "1.7") || (txtGr7.Text == "1.75"))
            {
                lbl7.Text = "89-91";
            }
            else if ((txtGr7.Text == "2") || (txtGr7.Text == "2.00"))
            {
                lbl7.Text = "86-88";
            }
            else if (txtGr7.Text == "2.25")
            {
                lbl7.Text = "83-85";
            }
            else if ((txtGr7.Text == "2.5") || (txtGr7.Text == "2.50"))
            {
                lbl7.Text = "80-82";
            }
            else if ((txtGr7.Text == "2.75") || (txtGr7.Text == "2.7"))
            {
                lbl7.Text = "77-79";
            }
            else if ((txtGr7.Text == "5") || (txtGr7.Text == "5.00"))
            {
                lbl7.Text = "75";
            }  
        }

        private void txtGr8_TextChanged(object sender, EventArgs e)
        {
            if ((txtGr8.Text == ""))
            {
                lbl8.Text = "-";
            }
            else if ((txtGr8.Text == "1") || (txtGr8.Text == "1.00"))
            {
                lbl8.Text = "98-100";
            }
            else if (txtGr8.Text == "1.25")
            {
                lbl8.Text = "95-97";
            }
            else if ((txtGr8.Text == "1.5") || (txtGr8.Text == "1.50"))
            {
                lbl8.Text = "92-94";
            }
            else if ((txtGr8.Text == "1.7") || (txtGr8.Text == "1.75"))
            {
                lbl8.Text = "89-91";
            }
            else if ((txtGr8.Text == "2") || (txtGr8.Text == "2.00"))
            {
                lbl8.Text = "86-88";
            }
            else if (txtGr8.Text == "2.25")
            {
                lbl8.Text = "83-85";
            }
            else if ((txtGr8.Text == "2.5") || (txtGr8.Text == "2.50"))
            {
                lbl8.Text = "80-82";
            }
            else if ((txtGr8.Text == "2.75") || (txtGr8.Text == "2.7"))
            {
                lbl8.Text = "77-79";
            }
            else if ((txtGr8.Text == "5") || (txtGr8.Text == "5.00"))
            {
                lbl8.Text = "75";
            }  
        }

        private void txtGr9_TextChanged(object sender, EventArgs e)
        {
            if ((txtGr9.Text == ""))
            {
                lbl9.Text = "-";
            }
            else if ((txtGr9.Text == "1") || (txtGr9.Text == "1.00"))
            {
                lbl9.Text = "98-100";
            }
            else if (txtGr9.Text == "1.25")
            {
                lbl9.Text = "95-97";
            }
            else if ((txtGr9.Text == "1.5") || (txtGr9.Text == "1.50"))
            {
                lbl9.Text = "92-94";
            }
            else if ((txtGr9.Text == "1.7") || (txtGr9.Text == "1.75"))
            {
                lbl9.Text = "89-91";
            }
            else if ((txtGr9.Text == "2") || (txtGr9.Text == "2.00"))
            {
                lbl9.Text = "86-88";
            }
            else if (txtGr9.Text == "2.25")
            {
                lbl9.Text = "83-85";
            }
            else if ((txtGr9.Text == "2.5") || (txtGr9.Text == "2.50"))
            {
                lbl9.Text = "80-82";
            }
            else if ((txtGr9.Text == "2.75") || (txtGr9.Text == "2.7"))
            {
                lbl9.Text = "77-79";
            }
            else if ((txtGr9.Text == "5") || (txtGr9.Text == "5.00"))
            {
                lbl9.Text = "75";
            }  
        }

        private void txtGr10_TextChanged(object sender, EventArgs e)
        {
            if ((txtGr10.Text == ""))
            {
                lbl10.Text = "-";
            }
            else if ((txtGr10.Text == "1") || (txtGr10.Text == "1.00"))
            {
                lbl10.Text = "98-100";
            }
            else if (txtGr10.Text == "1.25")
            {
                lbl10.Text = "95-97";
            }
            else if ((txtGr10.Text == "1.5") || (txtGr10.Text == "1.50"))
            {
                lbl10.Text = "92-94";
            }
            else if ((txtGr10.Text == "1.7") || (txtGr10.Text == "1.75"))
            {
                lbl10.Text = "89-91";
            }
            else if ((txtGr10.Text == "2") || (txtGr10.Text == "2.00"))
            {
                lbl10.Text = "86-88";
            }
            else if (txtGr10.Text == "2.25")
            {
                lbl10.Text = "83-85";
            }
            else if ((txtGr10.Text == "2.5") || (txtGr10.Text == "2.50"))
            {
                lbl10.Text = "80-82";
            }
            else if ((txtGr10.Text == "2.75") || (txtGr10.Text == "2.7"))
            {
                lbl10.Text = "77-79";
            }
            else if ((txtGr10.Text == "5") || (txtGr10.Text == "5.00"))
            {
                lbl10.Text = "75";
            }  
        }
    
      
    }
}
 