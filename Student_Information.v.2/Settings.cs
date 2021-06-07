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
using DGVPrinterHelper;
namespace Student_Information.v._2
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }

        OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Administrator\Desktop\Student_Information.v.2\Student_Information.v.2\database\Stud_Info_Update.accdb");
        public static string []SubName =new string[30];
        public static string[] SubCode = new string[30];
        public static string[] SubUnits = new string[30];
        public static string[] SubGrades = new string[30];

        public static string[] SubName1 = new string[30];
        public static string[] SubCode1 = new string[30];
        public static string[] SubUnits1 = new string[30];
        public static string[] SubGrades1 = new string[30];

        public static string StudentId;//data that will imported to print form
        public static string Name;
        public static string Course;
        public static string Year;
        public static string Section;
        public static string Sem;
        public static string SchoolYear_Print;

        public static int count_sub;
        public static int count_sub1;

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
            pnldAccounts.Hide();
            pnlPrint.Hide();
            pnlRecords.Hide();
            pnlSend.Hide();
            pnlRecords.Hide();
        }


        private void btnLogout_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void btnUserUpdate_Click(object sender, EventArgs e)
        {
            Hide_panels();
            pnlRecords.Show();
        }

        private void btnSaveData_Click(object sender, EventArgs e)
        {
            Hide_panels();
            pnlSend.Show();
            Inbox inb = new Inbox();

            inb.Show();
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            Hide_panels();
            //pnlPrint.Show();
            Grading grad = new Grading();
            grad.Show();
        }

        private void btnRecycle_Click(object sender, EventArgs e)
        {
            Hide_panels();
            pnldAccounts.Show();
        }

        private void pnlSaveData_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnlRecords_Paint(object sender, PaintEventArgs e)
        {
          
        }
        private void Comboboxes()
        {
            con.Open();

            OleDbDataAdapter adapt = new OleDbDataAdapter("Select [SchoolYear] from [SchoolYear]", con);
            DataTable table = new DataTable();
            adapt.Fill(table);


            foreach (DataRow dr1 in table.Rows)
            {
                cmbSchoolYear.Items.Add(dr1["SchoolYear"].ToString());
               
            }


            con.Close();
        }
        private void btnGrade_Click(object sender, EventArgs e)
        {
           
        }

        private void dgvSubject_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
                     
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            Comboboxes();

            OleDbCommand cmd = new OleDbCommand("Select [Stud_Id] from [Stud_Info]", con);


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

      

    

        private void dgvStudents_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }

        private void dgvSubject_Students_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
         
        }

        private void lblClassName_Click(object sender, EventArgs e)
        {

        }

        private void btnGrade_Students_Click(object sender, EventArgs e)
        {
          
        }

        private void pnlPrint_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Inbox inb = new Inbox();

            inb.Show();
        }

     
        private void btnprint_Click(object sender, EventArgs e)
        {
            /*
            DGVPrinter print = new DGVPrinter();
            print.Title = "Title";
            print.SubTitle = string.Format("Date:{0}", DateTime.Now.Date);
            print.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            print.PageNumbers = true;
            print.PageNumberInHeader = false;
            print.PorportionalColumns = true;
            print.HeaderCellAlignment = StringAlignment.Near;
            print.Footer = "Footer";
            print.FooterSpacing = 15;*/
            //print.PrintDataGridView(dgvStudent);
          
       


            FirstSem();
            SecondSem();

            StudentId = txtStudentNumber.Text;
            Name = txtName.Text;



            PrintSem sem = new PrintSem(this);
            sem.Show();

        }
        private void FirstSem()
        {
            con.Open();
            Console.WriteLine("aaaaaaaaaaaaaaaaaaaaaaaa");
            OleDbCommand adapt1 = new OleDbCommand("Select count(*) from [Erollment] where [SchoolYear]='" + cmbSchoolYear.Text + "' and [Stud_Id]='" + txtStudentNumber.Text + "' and [Stud_Name]='" + txtName.Text + "' and [Stud_Sem]='1st Sem'", con);

            int i = 0;
            int a = 2;
            count_sub = (int)adapt1.ExecuteScalar();//i use the count to count the rowws
            Console.WriteLine(count_sub);

            while (i < count_sub)
            {
                /*
                Console.WriteLine("aaaaaaaaaaaaaaaaaaaaaaaa");
                if (i == 0)
                {
                    SubName[a] = dgvFirstSem.Rows[i].Cells[0].Value.ToString();//Subjects to print
                    SubCode[a] = dgvFirstSem.Rows[i].Cells[1].Value.ToString();
                    SubUnits[a] = dgvFirstSem.Rows[i].Cells[2].Value.ToString();
                    SubGrades[a] = dgvFirstSem.Rows[i].Cells[3].Value.ToString();
                    Console.WriteLine(a);
                    i++;
                    a++;
                }
                */

                SubName[a] = dgvFirstSem.Rows[i].Cells[0].Value.ToString();//Subjects to print
                SubCode[a] = dgvFirstSem.Rows[i].Cells[1].Value.ToString();
                SubUnits[a] = dgvFirstSem.Rows[i].Cells[2].Value.ToString();
                SubGrades[a] = dgvFirstSem.Rows[i].Cells[3].Value.ToString();

                Console.WriteLine(a);
                i++;
                a++;
            }
          
            con.Close();

        }
        private void SecondSem()
        {
            con.Open();
            OleDbCommand adapt1 = new OleDbCommand("Select count(*) from [Erollment] where [SchoolYear]='" + cmbSchoolYear.Text + "' and [Stud_Id]='" + txtStudentNumber.Text + "' and [Stud_Name]='" + txtName.Text + "' and [Stud_Sem]='2nd Sem'", con);

            int i = 0;
            int a = 2;
            count_sub1 = (int)adapt1.ExecuteScalar();//i use the count to count the rowws

            while (i < count_sub1)
            {
                /*
                if (i == 0)
                {
                    SubName1[a] = dgvSecondSem.Rows[i].Cells[0].Value.ToString();//Subjects to print
                    SubCode1[a] = dgvSecondSem.Rows[i].Cells[1].Value.ToString();
                    SubUnits1[a] = dgvSecondSem.Rows[i].Cells[2].Value.ToString();
                    SubGrades1[a] = dgvSecondSem.Rows[i].Cells[3].Value.ToString();
                    Console.WriteLine(a);
                    i++;
                    a++;
                }
                */

                SubName1[a] = dgvSecondSem.Rows[i].Cells[0].Value.ToString();//Subjects to print
                SubCode1[a] = dgvSecondSem.Rows[i].Cells[1].Value.ToString();
                SubUnits1[a] = dgvSecondSem.Rows[i].Cells[2].Value.ToString();
                SubGrades1[a] = dgvSecondSem.Rows[i].Cells[3].Value.ToString();

                Console.WriteLine(a);
                i++;
                a++;
            }
          
            con.Close();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
         
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            OleDbDataAdapter adapt = new OleDbDataAdapter("Select [Stud_Id],[Stud_FullName],[Stud_Gender],[Stud_BirthDate],[Stud_Address] from [Stud_Info] where [Stud_Id]='" + txtSearchRecords.Text + "'", con);
            DataTable table = new DataTable();
            adapt.Fill(table);


            foreach (DataRow dr1 in table.Rows)
            {
                txtStudentNumber .Text  = (dr1["Stud_Id"]).ToString();
                txtName.Text = (dr1["Stud_FullName"]).ToString();
                txtGender.Text = (dr1["Stud_Gender"]).ToString();
                dtpBirthday.Text = (dr1["Stud_BirthDate"]).ToString();
                txtAddress.Text = (dr1["Stud_Address"]).ToString();
            }

        }

        private void cmbSchoolYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            Grade_Sem1();
            Grade_Sem2();
        }

        private void Grade_Sem1()//First Sem
        {
            try
            {
                con.Open();

                OleDbDataAdapter adapt = new OleDbDataAdapter("Select [Stud_Sem],[Stud_Course],[Stud_Year],[Stud_Section] from [Erollment] where [SchoolYear]='"+cmbSchoolYear .Text +"' and [Stud_Id]='"+txtStudentNumber .Text +"' and [Stud_Name]='"+txtName .Text +"' and [Stud_Sem]='1st Sem'", con);
                DataTable table = new DataTable();
                adapt.Fill(table);


                foreach (DataRow dr1 in table.Rows)
                {
                    txtSem .Text =(dr1["Stud_Sem"].ToString());
                    txtCourse .Text =(dr1["Stud_Course"].ToString());
                    txtYear .Text  = (dr1["Stud_Year"].ToString());
                    txtSection .Text  = (dr1["Stud_Section"].ToString());
                   
                }

                Section_FirstSem();//Table Subject
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex .Message );
            }
        }

        private void Section_FirstSem()//Grades and subjects in First sem
        {
            try
            {
                OleDbDataAdapter adapt = new OleDbDataAdapter("Select [Sub_Code],[Sub_Name],[Sub_Units],[Sub_Grades] from [Erollment] where [SchoolYear]='" + cmbSchoolYear.Text + "' and [Stud_Id]='" + txtStudentNumber.Text + "' and [Stud_Name]='" + txtName.Text + "' and [Stud_Sem]='1st Sem'", con);
                DataTable table = new DataTable();
                adapt.Fill(table);
                dgvFirstSem.DataSource = table;

                dgvFirstSem.AllowUserToAddRows = false;
                dgvFirstSem.EditMode = DataGridViewEditMode.EditProgrammatically;
                dgvFirstSem.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message );
            }
        }

        private void Grade_Sem2()//Second Sem
        {
            try
            {
                con.Open();

                OleDbDataAdapter adapt = new OleDbDataAdapter("Select [Stud_Sem],[Stud_Course],[Stud_Year],[Stud_Section] from [Erollment] where [SchoolYear]='" + cmbSchoolYear.Text + "' and [Stud_Id]='" + txtStudentNumber.Text + "' and [Stud_Name]='" + txtName.Text + "' and [Stud_Sem]='2nd Sem'", con);
                DataTable table = new DataTable();
                adapt.Fill(table);


                foreach (DataRow dr1 in table.Rows)
                {
                    txtSem2.Text = (dr1["Stud_Sem"].ToString());
                    txtCourse2.Text = (dr1["Stud_Course"].ToString());
                    txtYear2.Text = (dr1["Stud_Year"].ToString());
                    txtSection2.Text = (dr1["Stud_Section"].ToString());

                }

                Section_Second();//Table Subject
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Section_Second()//Grades and subjects in First sem
        {
            try
            {
                OleDbDataAdapter adapt = new OleDbDataAdapter("Select [Sub_Code],[Sub_Name],[Sub_Units],[Sub_Grades] from [Erollment] where [SchoolYear]='" + cmbSchoolYear.Text + "' and [Stud_Id]='" + txtStudentNumber.Text + "' and [Stud_Name]='" + txtName.Text + "' and [Stud_Sem]='2nd Sem'", con);
                DataTable table = new DataTable();
                adapt.Fill(table);
                dgvSecondSem.DataSource = table;

                dgvSecondSem.AllowUserToAddRows = false;
                dgvSecondSem.EditMode = DataGridViewEditMode.EditProgrammatically;
                dgvSecondSem.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void pnlGrade_Paint(object sender, PaintEventArgs e)
        {
            Prof_Acc();
            if ((txtPassword_Admin.Text == "") || (txtRepassword_Admin.Text == ""))
            {
                lblError.Visible = false;
            }
        }
        private void Prof_Acc()
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
        private void txtSearchRecords_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Admin_Click(object sender, EventArgs e)
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
                    insertProfAcc();

                }
            }
        }
        private void insertProfAcc()
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

        private void Settings_Paint(object sender, PaintEventArgs e)
        {
            Graphics mgraphics = e.Graphics;
            Pen pen = new Pen(Color.FromArgb(40, 188, 178), 1);

            Rectangle area = new Rectangle(0, 0, this.Width - 1, this.Height - 1);
            LinearGradientBrush lgb = new LinearGradientBrush(area, Color.FromArgb(40, 188, 178), Color.FromArgb(37, 137, 202), LinearGradientMode.Vertical);
            mgraphics.DrawRectangle(pen, area);
            mgraphics.FillRectangle(lgb, area);
            mgraphics.DrawRectangle(pen, area);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void checkPass_CheckedChanged(object sender, EventArgs e)
        {
            if (checkPass.Checked)
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

        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
            new Panel().Show();
        }
    }
}
