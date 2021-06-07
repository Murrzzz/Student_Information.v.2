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
using System.IO;
using DGVPrinterHelper;
namespace Student_Information.v._2
{
    public partial class MainMenu : Form
    {
        OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Administrator\Desktop\Student_Information.v.2\Student_Information.v.2\database\Stud_Info_Update.accdb");
        Boolean set = false;
        public static string stud_id;//update
        public static string stud_id_Archive;//to archive
        public static string stud_id_restore;
        public static string SchoolYear;

        public static string messageMasterlist;
        public static string messageArchive;
        public static string messageEnrolled;

        public static string[] SubName= new string[30];
        public static string[] SubCode=new string [30];
        public static string[] SubUnits=new string[30];

        public static int count_sub = 0;//Count subjects into the print form

        public static int masterAndArchiveChoose = 0;

        public static int  addUp = 1;

        public static string SetupClassName = "";

        public static string StudentId;//data that will imported to print form
        public static string Name;
        public static string Course;
        public static string Year;
        public static string Section;
        public static string Sem;
        public static string SchoolYear_Print;

        public MainMenu()
        {
            InitializeComponent();
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
            pnlEnrolledList.Hide();
            pnlSubjects.Hide();
            pnlAccounts.Hide();
            pnlArchiveList.Hide();
            pnlEnroll.Hide();
            pnlMasterList.Hide ();
            pnlAcc.Hide();

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
            pnlMasterList.Show();

        }

        private void btnRecords_Click(object sender, EventArgs e)
        {
            Hide_panels();
            pnlArchiveList.Show();
        }
        private void btnAdd_Class_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                OleDbCommand cmd = new OleDbCommand(" insert into[Stud_Section]([Section_Name],[Course],[YearLevel]) values(?,?,?)", con);
                cmd.Parameters.AddWithValue("@Stud_Id", OleDbType.Integer).Value = txtSectionName.Text;
                cmd.Parameters.AddWithValue("@Stud_Fname", OleDbType.VarChar).Value = txtCourse.Text;
                cmd.Parameters.AddWithValue("@Stud_Fname", OleDbType.VarChar).Value = cmbYearLevel.Text;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message );
            }
        }

        private void btnUpdate_Class_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd(object sender, EventArgs e)
        {
            if ((txtSub_Code.Text == "") || (txtUnits.Text == "") || (txtSub_Description.Text == "")||(cmbSubYear .Text =="")||(cmbSubSem.Text ==""))
            {
                MessageBox.Show("Please fill the blank");
            }
            else
            {
                con.Open();
                OleDbCommand cmd = new OleDbCommand(" insert into[Subjects]([Sub_Code],[Sub_Name],[Sub_Year],[Sub_Sem],[Sub_Units]) values(?,?,?,?,?)", con);
                cmd.Parameters.AddWithValue("@Department", OleDbType.VarChar).Value = txtSub_Code.Text;
                cmd.Parameters.AddWithValue("@Course", OleDbType.VarChar).Value = txtSub_Description.Text;
                cmd.Parameters.AddWithValue("@Section", OleDbType.VarChar).Value = cmbSubYear.Text;
                cmd.Parameters.AddWithValue("@Section", OleDbType.VarChar).Value = cmbSubSem.Text;
                cmd.Parameters.AddWithValue("@Section", OleDbType.VarChar).Value = txtUnits.Text;
                
                cmd.ExecuteNonQuery();
                select_Subject();
                con.Close();
            }
        }


        private void select_Subject()
        {
            OleDbDataAdapter adapt = new OleDbDataAdapter("Select * from [Subjects]", con);
            DataTable table = new DataTable();
            adapt.Fill(table);
            dgvSubject.DataSource = table;

            dgvSubject.AllowUserToAddRows = false;
            dgvSubject.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvSubject.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void dgvSubject_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {    
                txtSub_Code.Text = dgvSubject.Rows[e.RowIndex ].Cells["Sub_Code"].Value.ToString();
                txtSub_Description.Text = dgvSubject.Rows [e.RowIndex ].Cells["Sub_Name"].Value.ToString();
                cmbSubYear.Text = dgvSubject.Rows[e.RowIndex].Cells["Sub_Year"].Value.ToString();
                cmbSubSem.Text = dgvSubject.Rows[e.RowIndex].Cells["Sub_Sem"].Value.ToString();
                txtUnits.Text = dgvSubject.Rows[e.RowIndex].Cells["Sub_Units"].Value.ToString();   
        }

        private void pnlSubjects_Paint(object sender, PaintEventArgs e)
        {
            select_Subject();
        }
        private void pnlEnrolledlist(object sender, PaintEventArgs e)
        {
            lblSchoolYear.Text = SchoolYear;
            Select_Enrolee();
        }
        private void Select_Enrolee()
        {
            OleDbDataAdapter adapt = new OleDbDataAdapter("Select [Stud_Id],[Stud_Name],[Stud_Course],[Stud_Section],[Stud_Sem] from [EnrollmentDetails] where [SchoolYear]='"+lblSchoolYear .Text +"'", con);

            DataTable table = new DataTable();
            adapt.Fill(table);
            dgvEnrolled.DataSource = table;

            dgvEnrolled.AllowUserToAddRows = false;
            dgvEnrolled.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvEnrolled.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        private void VariableImported()
        {
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
           
            
        }

        private void picexit_Click(object sender, EventArgs e)
        {
            Panel pan = new Panel();

            this.Hide();
            pan.Show();
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            //dgvSubject.Columns[0].Width=200;
         

            Hide_panels();
            Comboboxes();
            Comboboxes1();
            OleDbCommand cmd = new OleDbCommand("Select [Stud_FullName] from [Stud_Info]", con);


            con.Close();
            con.Open();
            AutoCompleteStringCollection compl = new AutoCompleteStringCollection();//auto complete in search


            OleDbDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                compl.Add(rdr.GetString(0));//auto complete in search

            }

            txtSearchEnroll.AutoCompleteCustomSource = compl;

            con.Close();
           
        }

        private void txtClass_Name_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvClass_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }

    
        private void dgvClass_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
        
        }

      

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            PintClass pClass = new PintClass();
            pClass.Show();
        }

        private void dgvSection_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pnlClass_Paint(object sender, PaintEventArgs e)
        {
            Section_Select();
        }
        private void Section_Select()
        {
            OleDbDataAdapter adapt = new OleDbDataAdapter("Select * from [Stud_Section]", con);
            DataTable table = new DataTable();
            adapt.Fill(table);
            dgvSection.DataSource = table;

            dgvSection.AllowUserToAddRows = false;
            dgvSection.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvSection.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbSubSem_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide_panels();
            pnlEnrolledList.Show ();
        }

        private void pnlAccounts_Paint(object sender, PaintEventArgs e)
        {
            SelectYear();
        }
        private void SelectYear()
        {
            OleDbDataAdapter adapt = new OleDbDataAdapter("Select * from [SchoolYear]", con);
            DataTable table = new DataTable();
            adapt.Fill(table);
            dgvYear.DataSource = table;

            dgvYear.AllowUserToAddRows = false;
            dgvYear.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvYear.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void btnAddStud_Click(object sender, EventArgs e)
        {
            Add ad = new Add(this);
            //this.Hide();
            addUp = 1;
            ad.Show();
            addUp = 0;
        }

        private void btnUpdateStud_Click(object sender, EventArgs e)
        {
            addUp = 2;
            Add ad = new Add(this);
            this.Hide();
        
            ad.Show();
           //add to Add form
        }
    
        private void pnlMasterList_Paint(object sender, PaintEventArgs e)
        {
            SelectStudents();
        }
        private void SelectStudents()
        {
            OleDbDataAdapter adapt = new OleDbDataAdapter("Select [Stud_Id],[Stud_Lname],[Stud_Fname],[Stud_Mname],[Stud_Gmail],[Stud_Age],[Stud_Gender] from [Stud_Info]", con);
            DataTable table = new DataTable();
            adapt.Fill(table);
            dgvStudentList.DataSource = table;

            dgvStudentList.AllowUserToAddRows = false;
            dgvStudentList.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvStudentList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Hide_panels();
            pnlEnroll.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                messageEnrolled = dgvEnrolled.Rows[e.RowIndex].Cells[0].Value.ToString();
            }
        }

        private void SelectStudentsEnroll()// hindi ko pa nilagay kasi i will add  something in the search button
        {

            lblSchoolYearEnroll.Text = SchoolYear;
            OleDbDataAdapter adapt = new OleDbDataAdapter("Select [Sub_code],[Sub_Name],[Sub_Units] from [Subjects] where [Sub_Year]='" + cmbYear.Text + "' and [Sub_Sem]='" + cmbSem.Text + "' ", con);


            DataTable table = new DataTable();
            adapt.Fill(table);
            dgvEnrolledSub.DataSource = table;

            dgvEnrolledSub.AllowUserToAddRows = false;
            dgvEnrolledSub.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvEnrolledSub.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        private void pnlEnroll_Paint(object sender, PaintEventArgs e)
        {
            lblSchoolYearEnroll.Text = SchoolYear;
            if ((cmbSem.Text == "") && (cmbYear.Text == ""))
            { 

            }
            else 
            SelectStudentsEnroll();
           
             
            //-----------------------------------------------------------------------------------
           
        
        
        }
        private void Comboboxes()
        {
            con.Open();

            OleDbDataAdapter adapt = new OleDbDataAdapter("Select [Sub_Year],[Sub_Sem] from [Subjects]", con);
            DataTable table = new DataTable();
            adapt.Fill(table);
           

            foreach (DataRow dr1 in table.Rows)
            {
                cmbYear.Items.Add(dr1["Sub_Year"].ToString());
                cmbSem.Items.Add(dr1["Sub_Sem"].ToString());
                Console.WriteLine("Dr1");
                Console.WriteLine(dr1);
            }

            con.Close();
        }
        private void Comboboxes1()
        {
            con.Open();
            OleDbDataAdapter adapt1 = new OleDbDataAdapter("Select [YearLevel],[Section_Name],[Course] from [Stud_Section]", con);
            DataTable table1 = new DataTable();
            adapt1.Fill(table1);


            foreach (DataRow dr11 in table1.Rows)
            {
                cmbYear.Items.Add(dr11["YearLevel"].ToString());
                cmbSectionName.Items.Add(dr11["Section_Name"].ToString());
                cmbCourse.Items.Add(dr11["Course"].ToString());

            }
            con.Close();
        }

        private void cmbYear_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void SelectStudents_Search()
        {
            OleDbDataAdapter adapt = new OleDbDataAdapter("Select [Sub_Code],[Sub_Name],[Sub_Units] from [Erollment] where[Stud_Name]='" + txtSearchEnroll.Text + "' and [SchoolYear]='"+lblSchoolYearEnroll .Text +"'", con);
            DataTable table = new DataTable();
            adapt.Fill(table);
            dgvEnrolledSub.DataSource = table;

            dgvEnrolled.AllowUserToAddRows = false;
            dgvEnrolled.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvEnrolled.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void btnSearch_Click_1(object sender, EventArgs e)
        {
            OleDbDataAdapter adapt = new OleDbDataAdapter("Select [Stud_Id],[Stud_FullName],[Stud_Gmail] from [Stud_Info] where [Stud_FullName]='"+txtSearchEnroll .Text +"'", con);
            DataTable table = new DataTable();
            adapt.Fill(table);
            
            SelectStudents_Search();

            foreach (DataRow dr1 in table.Rows)
            {
                txtStudentId.Text = (dr1["Stud_Id"]).ToString();
                txtName.Text = (dr1["Stud_FullName"]).ToString();
                txtEmail .Text  = (dr1["Stud_Gmail"]).ToString();
            }

        }

        private void dgvStudentList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                stud_id = dgvStudentList.Rows[e.RowIndex].Cells[0].Value.ToString();
                stud_id_Archive = dgvStudentList.Rows[e.RowIndex].Cells[0].Value.ToString();
                messageMasterlist = dgvStudentList.Rows[e.RowIndex].Cells[4].Value.ToString();
                Console.WriteLine(stud_id);
            }
        }

        private void pnlArchiveList_Paint(object sender, PaintEventArgs e)
        {
            SelectArchiveStudents();
        }
        private void SelectArchiveStudents()
        {
            OleDbDataAdapter adapt = new OleDbDataAdapter("Select [Stud_Id],[Stud_Lname],[Stud_Fname],[Stud_Mname],[Stud_Gmail],[Stud_Age],[Stud_Gender] from [Stud_Info_Archive]", con);
            DataTable table = new DataTable();
            adapt.Fill(table);
            dgvArchive.DataSource = table;

            dgvArchive.AllowUserToAddRows = false;
            dgvArchive.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvArchive.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (stud_id_Archive != "")
            {
                try
                {
                    con.Open();
                    OleDbCommand cmd = new OleDbCommand("insert into [Stud_Info_Archive] select * from [Stud_Info] where [Stud_Id]=?", con);
                    cmd.Parameters.AddWithValue("@1", OleDbType.Numeric).Value = stud_id_Archive;
                    cmd.ExecuteNonQuery();
                   

                    OleDbCommand del = new OleDbCommand("delete from [Stud_Info] where [Stud_Id]=?", con);
                    del.Parameters.AddWithValue("@2", OleDbType.Numeric).Value = stud_id_Archive;
                    Console.WriteLine(stud_id_Archive);
                    del.ExecuteNonQuery();
                    SelectStudents();
                    stud_id_Archive = "";
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex .Message );
                }
            }
            else
            {
                MessageBox.Show("please click the data properly to archive");
            }
            
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            if (stud_id_restore != "")
            {
                try
                {
                    con.Open();
                    OleDbCommand cmd = new OleDbCommand("insert into [Stud_Info] select * from [Stud_Info_Archive] where [Stud_Id]=?", con);
                    cmd.Parameters.AddWithValue("@1", OleDbType.Numeric).Value = stud_id_restore;
                    cmd.ExecuteNonQuery();


                    OleDbCommand del = new OleDbCommand("delete from [Stud_Info_Archive] where [Stud_Id]=?", con);
                    del.Parameters.AddWithValue("@2", OleDbType.Numeric).Value = stud_id_restore;
                    Console.WriteLine(stud_id_Archive);
                    del.ExecuteNonQuery();
                    SelectArchiveStudents();
                    stud_id_restore = "";
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("please click the data properly to archive");
            }
            
        }

        private void dgvArchive_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                stud_id_restore = dgvArchive.Rows[e.RowIndex].Cells[0].Value.ToString();
                messageArchive = dgvArchive.Rows[e.RowIndex].Cells[4].Value.ToString();
               
            }
        }

        private void btnSeaerchMasterList_Click(object sender, EventArgs e)
        {
            con.Open();
            OleDbDataAdapter  search = new OleDbDataAdapter ("Select * from [Stud_Info] where [Stud_Lname]='"+txtSearchMasterList .Text +"'",con );
            //search.Parameters.AddWithValue("@1", OleDbType.VarChar).Value = txtSearchMasterList.Text;

            DataTable table = new DataTable();
            search.Fill(table);
            dgvStudentList.DataSource = table;

            dgvStudentList.AllowUserToAddRows = false;
            dgvStudentList.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvStudentList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            con.Close();
        }

        private void txtYear_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int txt1 = 0;
                if (txtYear.Text == "")
                {
                    txtYear.Text = "0";
                }
                txt1 = int.Parse(txtYear.Text.ToString());
                //int txt2 = int.Parse(txtYear1.Text.ToString());
                int txt2;
                txt2 = txt1 + 1;

                txtYear1.Text = txt2.ToString();
                //  int.Parse (txtYear1.Text.ToString()) = int.Parse(txtYear.Text.ToString()) + 1;
            }
            catch (Exception tx)
            {
                MessageBox.Show(tx.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Hide_panels();
            pnlAccounts.Show();
        }

        private void btnAddYear_Click(object sender, EventArgs e)
        {
            try
            {

                string year = "" + txtYear.Text + " -" + txtYear1.Text + "";
                con.Open();
                OleDbCommand cmd = new OleDbCommand("insert into [SchoolYear]([SchoolYear]) values(?)", con);
                cmd.Parameters.AddWithValue("@1", OleDbType.VarChar).Value = year;
                cmd.ExecuteNonQuery();
                SelectYear();
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show (ex.Message );
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dgvYear_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            setYear.Text = dgvYear.Rows[e.RowIndex].Cells[0].Value.ToString();
        }

        private void btnSetYear_Click(object sender, EventArgs e)
        {
            SchoolYear = setYear.Text;
            MessageBox.Show("Setup Success");
        }

        private void btnEnroll_Click(object sender, EventArgs e)
        {
            if (lblSchoolYearEnroll.Text == "")
            {
                MessageBox.Show("Set the School Year First!");
            }
            else
            {

                con.Open();
                OleDbCommand cmd = new OleDbCommand("select [SchoolYear],[Stud_Id],[Stud_Name],[Stud_Course],[Stud_Year],[Stud_Section],[Stud_Sem] from [EnrollmentDetails] where [SchoolYear]=? and [Stud_Id]=? and [Stud_Name]=? and [Stud_Course]=? and [Stud_Year]=? and [Stud_Section]=? and [Stud_Sem]=?", con);
                cmd.Parameters.AddWithValue("@1", OleDbType.VarChar).Value = lblSchoolYearEnroll.Text;
                cmd.Parameters.AddWithValue("@1", OleDbType.VarChar).Value = txtStudentId.Text;
                cmd.Parameters.AddWithValue("@1", OleDbType.VarChar).Value = txtName.Text;
                cmd.Parameters.AddWithValue("@1", OleDbType.VarChar).Value = cmbCourse.Text;
                cmd.Parameters.AddWithValue("@1", OleDbType.VarChar).Value = cmbYear.Text;
                cmd.Parameters.AddWithValue("@1", OleDbType.VarChar).Value = cmbSectionName.Text;
                cmd.Parameters.AddWithValue("@1", OleDbType.VarChar).Value = cmbSem.Text;

                OleDbDataReader Olereader = cmd.ExecuteReader();
     

                if (Olereader.Read())
                {
                    MessageBox.Show("You are already enrolled");
                }
                else
                {
                    Console.WriteLine("Not Exist");
                    insertSubjects_Students();
                    insertEnrolled_Details();
                    MessageBox.Show("Successfully Enrolled");
                }
                con.Close();
             
            }
        }
        private void insertSubjects_Students()
        {
            try
            {
                con.Close();
                con.Open();
                //OleDbCommand cmd = new OleDbCommand("insert into[Enrollment]([]) ",con );
                OleDbDataAdapter adapt = new OleDbDataAdapter("Select [Sub_Name],[Sub_Code] from [Subjects] where [Sub_Year]='" + cmbYear.Text + "' and [Sub_Sem]='" + cmbSem.Text + "' ", con);
                DataTable table = new DataTable();
                adapt.Fill(table);

                int count = 0;

                OleDbCommand adapt1 = new OleDbCommand("Select count(*) from [Subjects] where [Sub_Year]='" + cmbYear.Text + "' and [Sub_Sem]='" + cmbSem.Text + "' ", con);



                count = (int)adapt1.ExecuteScalar();//i use the count to count the rowws

                Console.WriteLine("aaaaaaaaa");
                Console.WriteLine(count);
                int i = 0;
                string subName, subCode, subUnits;
                while (i < count)
                {
                    SubName [i] = dgvEnrolledSub.Rows[i].Cells[0].Value.ToString();//Subjects to print
                    SubCode [i]= dgvEnrolledSub.Rows[i].Cells[1].Value.ToString();
                    SubUnits [i] = dgvEnrolledSub.Rows[i].Cells[2].Value.ToString();

                    subName = dgvEnrolledSub.Rows[i].Cells[0].Value.ToString();
                    subCode = dgvEnrolledSub.Rows[i].Cells[1].Value.ToString();
                    subUnits = dgvEnrolledSub.Rows[i].Cells[2].Value.ToString();

                    OleDbCommand cmd = new OleDbCommand("insert into [Erollment]([SchoolYear],[Stud_Id],[Stud_Name],[Stud_Course],[Stud_Year],[Stud_Section],[Stud_Sem],[Sub_Code],[Sub_Name],[Sub_Units],[Stud_Gmail]) " +
                        "values(?,?,?,?,?,?,?,?,?,?,?)", con);
                    cmd.Parameters.AddWithValue("@1", OleDbType.VarChar).Value = lblSchoolYearEnroll.Text;
                    cmd.Parameters.AddWithValue("@1", OleDbType.VarChar).Value = txtStudentId.Text;
                    cmd.Parameters.AddWithValue("@1", OleDbType.VarChar).Value = txtName.Text;
                    cmd.Parameters.AddWithValue("@1", OleDbType.VarChar).Value = cmbCourse.Text;
                    cmd.Parameters.AddWithValue("@1", OleDbType.VarChar).Value = cmbYear.Text;
                    cmd.Parameters.AddWithValue("@1", OleDbType.VarChar).Value = cmbSectionName.Text;
                    cmd.Parameters.AddWithValue("@1", OleDbType.VarChar).Value = cmbSem.Text;
                    cmd.Parameters.AddWithValue("@1", OleDbType.VarChar).Value = subCode;
                    cmd.Parameters.AddWithValue("@1", OleDbType.VarChar).Value = subName;
                    cmd.Parameters.AddWithValue("@1", OleDbType.VarChar).Value = subUnits;
                    cmd.Parameters.AddWithValue("@1", OleDbType.VarChar).Value = txtEmail.Text;


                    cmd.ExecuteNonQuery();
                    i++;
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void insertEnrolled_Details()
        {
            try
            {
                con.Close();
                con.Open();
                OleDbCommand cmd = new OleDbCommand("insert into [EnrollmentDetails]([SchoolYear],[Stud_Id],[Stud_Name],[Stud_Course],[Stud_Year],[Stud_Section],[Stud_Sem],[Stud_Gmail]) " +
                       "values(?,?,?,?,?,?,?,?)", con);
                cmd.Parameters.AddWithValue("@1", OleDbType.VarChar).Value = lblSchoolYearEnroll.Text;
                cmd.Parameters.AddWithValue("@1", OleDbType.VarChar).Value = txtStudentId.Text;
                cmd.Parameters.AddWithValue("@1", OleDbType.VarChar).Value = txtName.Text;
                cmd.Parameters.AddWithValue("@1", OleDbType.VarChar).Value = cmbCourse.Text;
                cmd.Parameters.AddWithValue("@1", OleDbType.VarChar).Value = cmbYear.Text;
                cmd.Parameters.AddWithValue("@1", OleDbType.VarChar).Value = cmbSectionName.Text;
                cmd.Parameters.AddWithValue("@1", OleDbType.VarChar).Value = cmbSem.Text;
               
                cmd.Parameters.AddWithValue("@1", OleDbType.VarChar).Value = txtEmail.Text;

                
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void txtSearchEnroll_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void btnMessageEnrolled_Click(object sender, EventArgs e)
        {

        }

        private void btnMessageMasterList_Click(object sender, EventArgs e)
        {
            Inbox inb = new Inbox();
            masterAndArchiveChoose = 1;   
            inb.Show();
        }

        private void btnMessageArchive_Click(object sender, EventArgs e)
        {
            Inbox inb = new Inbox();
            masterAndArchiveChoose = 2;
            inb.Show();
        }

        private void btnPrint_Click_1(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                OleDbCommand adapt1 = new OleDbCommand("Select count(*) from [Subjects] where [Sub_Year]='" + cmbYear.Text + "' and [Sub_Sem]='" + cmbSem.Text + "' ", con);

                int i = 0;
                int a = 2;
                count_sub = (int)adapt1.ExecuteScalar();//i use the count to count the rowws

                while (i < count_sub)
                {
                    /*
                    if (i == 0)
                    {
                        SubName[a] = dgvEnrolledSub.Rows[i].Cells[0].Value.ToString();//Subjects to print
                        SubCode[a] = dgvEnrolledSub.Rows[i].Cells[1].Value.ToString();
                        SubUnits[a] = dgvEnrolledSub.Rows[i].Cells[2].Value.ToString();
                        Console.WriteLine("Hello Print");
                        Console.WriteLine(a);
                        i++;
                        a++;
                    }
                    */

                    SubName[a] = dgvEnrolledSub.Rows[i].Cells[0].Value.ToString();//Subjects to print
                    SubCode[a] = dgvEnrolledSub.Rows[i].Cells[1].Value.ToString();
                    SubUnits[a] = dgvEnrolledSub.Rows[i].Cells[2].Value.ToString();
                    Console.WriteLine(count_sub);
                    i++;
                    a++;
                }
                StudentId = txtStudentId.Text;
                Name = txtName.Text;
                Course = cmbCourse.Text;
                Section = cmbSectionName.Text;
                Sem = cmbSem.Text;
                Year = cmbYear.Text;
                SchoolYear_Print = lblSchoolYear.Text;
                PrintSubjects sub = new PrintSubjects(this);
                sub.Show();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("aaaaaaaa");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Hide_panels();
            pnlAcc.Show();
        }

        private void pnlAcc_Paint(object sender, PaintEventArgs e)
        {
            Admin_Acc();
            if ((txtPassword_Admin.Text == "") || (txtRepassword_Admin.Text == ""))
            {
                lblError.Visible = false;
            }
        }
        private void Admin_Acc()
        {
            con.Open();
            OleDbDataAdapter search = new OleDbDataAdapter("Select [Username],[Email] from [Admin_Acc]", con);
            //search.Parameters.AddWithValue("@1", OleDbType.VarChar).Value = txtSearchMasterList.Text;

            DataTable table = new DataTable();
            search.Fill(table);
            dgvAdmin.DataSource = table;

            dgvAdmin.AllowUserToAddRows = false;
            dgvAdmin.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvAdmin.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            con.Close();
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            if ((txtEmail_Admin.Text == "") || (txtUsername_Admin.Text == "") || (txtPassword_Admin.Text == ""))
            {
                MessageBox.Show("Please input date in the textbox");
            }
            else
            {
                if (txtPassword_Admin.Text != txtRepassword_Admin.Text)
                {
                    MessageBox.Show("Double check your password ");
                }
                else
                {
                    lblError.Visible = false;
                    insertAdminAcc();

                }
            }
        }

        private void txtRepassword_Admin_TextChanged(object sender, EventArgs e)
        {
            if (txtPassword_Admin.Text != txtRepassword_Admin.Text)
            {
                lblError.Visible = true;
            }
            else
            {
                lblError.Visible = false;
            }
        }

        private void insertAdminAcc()
        {
            try
            {
                con.Close();
                con.Open();
                OleDbCommand cmd = new OleDbCommand("insert into [Admin_Acc]([Username],[Email],[Password]) " +
                       "values(?,?,?)", con);
                cmd.Parameters.AddWithValue("@1", OleDbType.VarChar).Value = txtUsername_Admin.Text;
                cmd.Parameters.AddWithValue("@1", OleDbType.VarChar).Value = txtEmail_Admin.Text;
                cmd.Parameters.AddWithValue("@1", OleDbType.VarChar).Value = txtPassword_Admin.Text;
       
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvEnrolled_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            string studid;

            foreach (DataGridViewRow row in dgvEnrolled.Rows)
            {
                studid = (row.Cells[0].Value).ToString();
                Console.WriteLine(studid);
                if (stud_id == "123")
                {
                    row.DefaultCellStyle.BackColor = Color.Red;
                }
            }
        }
        private void txtCourse_TextChanged(object sender, EventArgs e)
        {

        }
        private void checkShow_CheckedChanged(object sender, EventArgs e)
        {
            if (checkShow.Checked)
            {
                txtPassword_Admin.UseSystemPasswordChar = true;
                txtRepassword_Admin.UseSystemPasswordChar = true;
            }
            else
            {
                txtPassword_Admin.UseSystemPasswordChar = false;
                txtRepassword_Admin.UseSystemPasswordChar = false;
            }
        }
        private void MainMenu_Paint(object sender, PaintEventArgs e)
        {
            Graphics mgraphics = e.Graphics;
            Pen pen = new Pen(Color.FromArgb(40, 188, 178), 1);

            Rectangle area = new Rectangle(0, 0, this.Width - 1, this.Height - 1);
            LinearGradientBrush lgb = new LinearGradientBrush(area, Color.FromArgb(40, 188, 178), Color.FromArgb(37, 137, 202), LinearGradientMode.Vertical);
            mgraphics.DrawRectangle(pen, area);
            mgraphics.FillRectangle(lgb, area);
            mgraphics.DrawRectangle(pen, area);
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
            new Panel().Show();
        }
    }
}
