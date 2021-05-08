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
        OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Administrator\Desktop\Student_Information.v.2\Student_Information.v.2\database\Student_Info.accdb;Persist Security Info = False");
      
        Boolean set = false;
        public static string Stud_Id = "";
        public static string classname = "";
        public static string department = "";
        public static string course = "";
        public static string section = "";
        public static string Fname = "";
        public static string Lname = "";
        public static string Mname = "";
        public static string Gmail = "";
        public static string Year = "";
        public static string ContactNumber = "";
        public static string Address = "";
        public static string Sex = "";
        public static string Religion = "";
        public static string BirthDate = "";
        public static string Status = "";
        public static string SchoolYear = "";
        public static string CivilStatus = "";
        public static string Sem = "";
        //for ADD
        public static string Department1 = "";
        public static string Section1 = "";
        public static string Course1 = "";


        public static int  addUp = 1;

        public static string SetupClassName = "";

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

        private void btnAdd_Class_Click(object sender, EventArgs e)
        {
            
            if ((txtCourse.Text == "") || (txtDepartment.Text == "") || (cmbSchoolYear.Text == "") || (cmbSection.Text == "") || (cmbYearLevel.Text == "") || (txtClass_Name.Text == "") ||(cmbSem.Text  ==""))
            {
                MessageBox.Show("Please fill the blank");
            }
            else
            {
                con.Open();
                OleDbCommand cmd = new OleDbCommand(" insert into[class]([Department],[Course],[Section],[YearLevel],[SchoolYear],[ClassName],[Sem]) values(?,?,?,?,?,?,?)", con);
                cmd.Parameters.AddWithValue("@Department", OleDbType.VarChar).Value = txtDepartment.Text;
                cmd.Parameters.AddWithValue("@Course", OleDbType.VarChar).Value = txtCourse.Text;
                cmd.Parameters.AddWithValue("@Section", OleDbType.VarChar).Value = cmbSection.Text;
                cmd.Parameters.AddWithValue("@YearLevel", OleDbType.VarChar).Value = cmbYearLevel.Text;
                cmd.Parameters.AddWithValue("@SchoolYear", OleDbType.VarChar).Value = cmbSchoolYear.Text;
                cmd.Parameters.AddWithValue("@ClassName", OleDbType.VarChar).Value = txtClass_Name.Text;
                cmd.Parameters.AddWithValue("@Sem", OleDbType.VarChar).Value = cmbSem.Text;
                cmd.ExecuteNonQuery();

                Class_SelectAll();
                con.Close();
            }
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

     
        private void btnUpdate_Class_Click(object sender, EventArgs e)
        {
            string Department = txtDepartment.Text;
            string Course = txtCourse.Text;
            string Section = cmbSection.Text;
            string School_Year = cmbSchoolYear.Text ;
            string Year_Level = cmbYearLevel.Text;

            con.Open();
            OleDbCommand cmd = new OleDbCommand("UPDATE [class] SET [Department]=?,[Course]=?,[Section]=?,[YearLevel]=? ,[Sem]=? WHERE [ClassName]=?" , con);

            cmd.Parameters.AddWithValue("@1", OleDbType.VarChar).Value = txtDepartment.Text;
            cmd.Parameters.AddWithValue("@2", OleDbType.VarChar).Value = txtCourse .Text ;
            cmd.Parameters.AddWithValue("@3", OleDbType.VarChar).Value = cmbSection.Text;
            cmd.Parameters.AddWithValue("@4", OleDbType.VarChar).Value = cmbYearLevel.Text;
            cmd.Parameters.AddWithValue("@5", OleDbType.VarChar).Value = cmbSchoolYear.Text;
            cmd.Parameters.AddWithValue("@6", OleDbType.VarChar).Value = txtClass_Name.Text;
            cmd.Parameters.AddWithValue("@7", OleDbType.VarChar).Value = cmbSem.Text;
            cmd.Parameters.AddWithValue("@8", OleDbType.VarChar).Value = txtClass_Name .Text ;

            cmd.ExecuteNonQuery();

            Class_SelectAll();
            con.Close();
        }

        private void btnAdd(object sender, EventArgs e)
        {
            if ((txtSub_Code.Text == "") || (txtSub_Units.Text == "") || (txtSub_Name.Text == ""))
            {
                MessageBox.Show("Please fill the blank");
            }
            else
            {
                con.Open();
                OleDbCommand cmd = new OleDbCommand(" insert into[Subject]([Sub_Code],[Sub_Name],[Sub_Units]) values(?,?,?)", con);
                cmd.Parameters.AddWithValue("@Department", OleDbType.VarChar).Value = txtSub_Code.Text;
                cmd.Parameters.AddWithValue("@Course", OleDbType.VarChar).Value = txtSub_Units.Text;
                cmd.Parameters.AddWithValue("@Section", OleDbType.VarChar).Value = txtSub_Name.Text;

                
                cmd.ExecuteNonQuery();
                select_Subject();
                con.Close();
            }
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

        private void dgvSubject_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvSubject.Rows[e.RowIndex];
                txtSub_Code.Text = row.Cells["Sub_Code"].Value.ToString();
                txtSub_Units.Text = row.Cells["Sub_Name"].Value.ToString();
                txtSub_Name.Text = row.Cells["Sub_Units"].Value.ToString();
               
            }
        }

        private void pnlSubjects_Paint(object sender, PaintEventArgs e)
        {
            select_Subject();
        }
        

       

        private void pnlRecords_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void pnlClass_Paint(object sender, PaintEventArgs e)
        {
            Class_SelectAll();



        }
        private void VariableImported()
        {
            classname = txtClass_Name.Text;
            department = txtDepartment.Text;
            course = txtCourse.Text;
            section = cmbSection.Text;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SetupClassName = txtClass_Name.Text;
            if ((txtCourse.Text == "") || (txtDepartment.Text == "") || (cmbSchoolYear.Text == "") || (cmbSection.Text == "") || (cmbYearLevel.Text == "") || (txtClass_Name.Text == ""))
            {
                MessageBox.Show("Setup Failed Please Choose to the table or add ");
              
            }
            else
            {
                classname = txtClass_Name.Text;

                Course1 = txtCourse.Text;
                Department1 = txtDepartment.Text;
                department = txtDepartment.Text;
                Section1 = cmbSection.Text;
                Sem = cmbSem.Text;
                MessageBox.Show("Setup Successfully");
            }

            
        }

        private void picexit_Click(object sender, EventArgs e)
        {
            Panel pan = new Panel();

            this.Hide();
            pan.Show();
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            Hide_panels();
        }

        private void txtClass_Name_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvClass_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvClass.Rows[e.RowIndex];
                txtDepartment.Text = row.Cells["Department"].Value.ToString();
                txtCourse.Text = row.Cells["Course"].Value.ToString();
                cmbSection .Text  = row.Cells["Section"].Value.ToString();
                cmbYearLevel.Text  = row.Cells["YearLevel"].Value.ToString();
                cmbSchoolYear.Text  = row.Cells["SchoolYear"].Value.ToString();
                txtClass_Name.Text = row.Cells["ClassName"].Value.ToString();
                cmbSem.Text = row.Cells["Sem"].Value.ToString();
            }
        }

    
        private void dgvClass_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvClass.Rows[e.RowIndex];
                txtDepartment.Text = row.Cells["Department"].Value.ToString();
                txtCourse.Text = row.Cells["Course"].Value.ToString();
                cmbSection.Text = row.Cells["Section"].Value.ToString();
                cmbYearLevel.Text = row.Cells["YearLevel"].Value.ToString();
                cmbSchoolYear.Text = row.Cells["SchoolYear"].Value.ToString();
                txtClass_Name.Text = row.Cells["ClassName"].Value.ToString();
                cmbSem.Text = row.Cells["Sem"].Value.ToString();
            }
        }

        private void dgvClass_CellContentClick_2(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {

                txtDepartment.Text = dgvClass.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtCourse.Text = dgvClass.Rows[e.RowIndex].Cells[1].Value.ToString();
                cmbSection.Text = dgvClass.Rows[e.RowIndex].Cells[2].Value.ToString();
                cmbYearLevel.Text = dgvClass.Rows[e.RowIndex ].Cells[3].Value.ToString();
                cmbSchoolYear.Text = dgvClass.Rows[e.RowIndex].Cells[4].Value.ToString();
                txtClass_Name.Text = dgvClass.Rows[e.RowIndex].Cells[5].Value.ToString();
                cmbSem.Text = dgvClass.Rows[e.RowIndex].Cells[6].Value.ToString();
            }
           

            /*
            txtDepartment.Text = dgvClass.SelectedRows[0].Cells[0].Value.ToString();
            txtCourse.Text = dgvClass.SelectedRows[0].Cells[1].Value.ToString();
            cmbSection.Text = dgvClass.SelectedRows[0].Cells[2].Value.ToString();
            cmbYearLevel.Text = dgvClass.SelectedRows[0].Cells[3].Value.ToString();
            cmbSchoolYear.Text = dgvClass.SelectedRows[0].Cells[4].Value.ToString();
            txtClass_Name.Text = dgvClass.SelectedRows[0].Cells[5].Value.ToString();
            cmbSem.Text = dgvClass.SelectedRows[0].Cells[6].Value.ToString();
             */
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            PintClass pClass = new PintClass();
            pClass.Show();
        }

    }
}
