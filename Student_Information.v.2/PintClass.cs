using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using DGVPrinterHelper;

namespace Student_Information.v._2
{
    public partial class PintClass : Form
    {
        public static int addUp = 1;
        OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Administrator\Desktop\Student_Information.v.2\Student_Information.v.2\database\Stud_Info_Update.accdb");
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


        public PintClass()
        {
            InitializeComponent();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            
        }
        private void select_students()
        {
            OleDbDataAdapter adapt1 = new OleDbDataAdapter("Select * from [Students] where [Class_Name]='" + MainMenu.SetupClassName + "'", con);
            DataTable table1 = new DataTable();
            adapt1.Fill(table1);
            dgvStudents.DataSource = table1;

            dgvStudents.AllowUserToAddRows = false;
            dgvStudents.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvStudents.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void PintClass_Load(object sender, EventArgs e)
        {
            select_students();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
         
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
           
        }

        private void dgvStudents_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {


                DataGridViewRow row = this.dgvStudents.Rows[e.RowIndex];
                Console.WriteLine(row.Cells["Stud_Gmail"]);
                //Stud_Id = row.Cells["Stud_Id"].Value.ToString();
                Fname = row.Cells["Stud_Fname"].Value.ToString();
                Lname = row.Cells["Stud_Lname"].Value.ToString();
                Mname = row.Cells["Stud_Mname"].Value.ToString();
                Gmail = row.Cells["Stud_Gmail"].Value.ToString();
                course = row.Cells["Stud_Course"].Value.ToString();
                Year = row.Cells["Stud_Year"].Value.ToString();
                section = row.Cells["Stud_Section"].Value.ToString();
                ContactNumber = row.Cells["Stud_ContactNumber"].Value.ToString();
                department = row.Cells["Stud_Department"].Value.ToString();
                Address = row.Cells["Stud_Address"].Value.ToString();
                Sex = row.Cells["Stud_Sex"].Value.ToString();
                Religion = row.Cells["Stud_Religion"].Value.ToString();
                BirthDate = row.Cells["Stud_BirthDate"].Value.ToString();
                Status = row.Cells["Stud_Status"].Value.ToString();
                SchoolYear = row.Cells["Stud_SchoolYear"].Value.ToString();
                CivilStatus = row.Cells["Stud_CivilStatus"].Value.ToString();
                classname = row.Cells["Class_Name"].Value.ToString();
                Sem = row.Cells["Sem"].Value.ToString();
                Stud_Id = row.Cells["Stud_Id"].Value.ToString();


            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            DGVPrinter print = new DGVPrinter();
            print.Title = "Title";
            print.SubTitle = string.Format("Date:{0}", DateTime.Now.Date);
            print.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            print.PageNumbers = true;
            print.PageNumberInHeader = false;
            print.PorportionalColumns = true;
            print.HeaderCellAlignment = StringAlignment.Near;
            print.Footer = "Footer";
            print.FooterSpacing = 15;
            print.PrintDataGridView(dgvStudents);
        }

      
    }
}
