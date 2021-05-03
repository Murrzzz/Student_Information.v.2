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
namespace Student_Information.v._2
{
    public partial class MainMenu : Form
    {
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\Student_Info.accdb;Persist Security Info = True");

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

   
        private void button5_Click_1(object sender, EventArgs e)
        {
            if((Course1 =="")||(Department1 =="")||(Section1 ==""))
            {
                MessageBox.Show("Please Setup First the Class !");
            }
            else 
            {
                Add ad = new Add(this);
                this.Hide();
                addUp = 1;
                ad.Show();
                addUp = 1;
            }
        }

        private void btnAdd_Class_Click(object sender, EventArgs e)
        {
            
            if ((txtCourse.Text == "") || (txtDepartment.Text == "") || (txtSchoolYear.Text == "") || (txtSection.Text == "") || (txtYearLevel.Text == "") || (txtClass_Name.Text == "") ||(txtSem.Text  ==""))
            {
                MessageBox.Show("Please fill the blank");
            }
            else
            {
                 

                con.Open();
                OleDbCommand cmd = new OleDbCommand(" insert into[class]([Department],[Course],[Section],[Year_Level],[School_Year],[Class_Name],[Sem]) values(?,?,?,?,?,?,?)", con);
                cmd.Parameters.AddWithValue("@Department", OleDbType.VarChar).Value = txtDepartment.Text;
                cmd.Parameters.AddWithValue("@Course", OleDbType.VarChar).Value = txtCourse.Text;
                cmd.Parameters.AddWithValue("@Section", OleDbType.VarChar).Value = txtSection.Text;
                cmd.Parameters.AddWithValue("@Year_Level", OleDbType.VarChar).Value = txtYearLevel.Text;
                cmd.Parameters.AddWithValue("@School_Year", OleDbType.VarChar).Value = txtSchoolYear.Text;
                cmd.Parameters.AddWithValue("@Class_Name", OleDbType.VarChar).Value = txtClass_Name.Text;
                cmd.Parameters.AddWithValue("@Sem", OleDbType.VarChar).Value = txtSem.Text;
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

        private void dgvClass_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvClass.Rows[e.RowIndex];
                txtDepartment.Text = row.Cells["Department"].Value.ToString();
                txtCourse.Text = row.Cells["Course"].Value.ToString();
                txtSection.Text = row.Cells["Section"].Value.ToString();
                txtYearLevel.Text = row.Cells["Year_Level"].Value.ToString();
                txtSchoolYear.Text = row.Cells["School_Year"].Value.ToString();
                txtClass_Name.Text = row.Cells["Class_Name"].Value.ToString();
                txtSem.Text = row.Cells["Sem"].Value.ToString();
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
            OleDbCommand cmd = new OleDbCommand("UPDATE [class] SET [Department]='" + txtDepartment.Text + "',[Course]='" + txtCourse.Text + "',[Section]='" + txtSection.Text + "',[Year_Level]='" + txtYearLevel.Text + "',[School_Year]='" + txtSchoolYear.Text + "',[Sem]='"+txtSem .Text +"' WHERE [Course]='" + Course + "' AND [Section]='" + Section  + "' AND [Year_Level]='" + Year_Level +"'" , con);
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
        private void select_students()
        {
            OleDbDataAdapter adapt1 = new OleDbDataAdapter("Select * from [Students] where [Class_Name]='"+ SetupClassName  +"'", con);
            DataTable table1 = new DataTable();
            adapt1.Fill(table1);
            dgvStudents.DataSource = table1;

            dgvStudents.AllowUserToAddRows = false;
            dgvStudents.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvStudents.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                

                DataGridViewRow row = this.dgvStudents.Rows[e.RowIndex];
                Console.WriteLine(row.Cells["Stud_Gmail"]);
                //Stud_Id = row.Cells["Stud_Id"].Value.ToString();
                Fname  = row.Cells["Stud_Fname"].Value.ToString();
                Lname  = row.Cells["Stud_Lname"].Value.ToString();
                Mname  = row.Cells["Stud_Mname"].Value.ToString();
                Gmail  = row.Cells["Stud_Gmail"].Value.ToString();
                course  = row.Cells["Stud_Course"].Value.ToString();
                Year  = row.Cells["Stud_Year"].Value.ToString();
                section  = row.Cells["Stud_Section"].Value.ToString();
                ContactNumber  = row.Cells["Stud_ContactNumber"].Value.ToString();
                department  = row.Cells["Stud_Department"].Value.ToString();
                Address  = row.Cells["Stud_Address"].Value.ToString();
                Sex  = row.Cells["Stud_Sex"].Value.ToString();
                Religion  = row.Cells["Stud_Religion"].Value.ToString();
                BirthDate  = row.Cells["Stud_BirthDate"].Value.ToString();
                Status  = row.Cells["Stud_Status"].Value.ToString();
                SchoolYear  = row.Cells["Stud_SchoolYear"].Value.ToString();
                CivilStatus  = row.Cells["Stud_CivilStatus"].Value.ToString();
                classname  = row.Cells["Class_Name"].Value.ToString();
                Sem  = row.Cells["Sem"].Value.ToString();

                int id = Convert.ToInt32(dgvStudents.Rows[e.RowIndex].Cells["Stud_Id"].FormattedValue);
                OleDbCommand cmd = new OleDbCommand("select [Stud_Image] from[Students] where [Stud_Id]="+id  +"", con);
                con.Open();
                string img = cmd.ExecuteScalar().ToString();
                pictureBox2.Image = Image.FromFile(img);

                con.Close();

              
                lblFname.Text = Fname;
                lblLName.Text = Lname;
                lblMname.Text = Mname;
                lblYear.Text = Year;
                lblCourse.Text = course;
                lblSection.Text = section;
                lblStatus.Text = Status;
                lblSex.Text = Sex;

            }
        }

        private void pnlRecords_Paint(object sender, PaintEventArgs e)
        {
            select_students();
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
            section = txtSection.Text;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SetupClassName = txtClass_Name.Text;
            if ((txtCourse.Text == "") || (txtDepartment.Text == "") || (txtSchoolYear.Text == "") || (txtSection.Text == "") || (txtYearLevel.Text == "") || (txtClass_Name.Text == ""))
            {
                MessageBox.Show("Setup Failed Please Choose to the table or add ");
              
            }
            else
            {

                Course1 = txtCourse.Text;
                Department1 = txtDepartment.Text;
                Section1 = txtSection.Text;
                Sem = txtSem.Text;
                MessageBox.Show("Setup Successfully");
            }

            
        }

        private void picexit_Click(object sender, EventArgs e)
        {
            Panel pan = new Panel();

            this.Hide();
            pan.Show();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SetupClassName = txtClass_Name.Text;
            if ((txtCourse.Text == "") || (txtDepartment.Text == "") || (txtSchoolYear.Text == "") || (txtSection.Text == "") || (txtYearLevel.Text == "") || (txtClass_Name.Text == ""))
            {
                MessageBox.Show("Setup Failed Please Choose to the table or add ");

            }
            else
            {
                Add ad = new Add(this);
                this.Hide();
                ad.Show();
                addUp = 0;//add to Add form
            }
           
        }
    }
}
