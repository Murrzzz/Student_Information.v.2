using System;
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
using System.Drawing.Drawing2D;


namespace Student_Information.v._2
{
    public partial class Add : Form
    {
        OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Administrator\Desktop\Student_Information.v.2\Student_Information.v.2\database\Stud_Info_Update.accdb;Persist Security Info = False");
      
        MainMenu  main = new MainMenu  ();
        public Add(MainMenu   f1)
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

       
        private void DataImported()
        {
            /*
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
            dtpBirthdate.Text = MainMenu.BirthDate;
            cmbStatus.Text = MainMenu.Status;
            cmbSchoolYear.Text = MainMenu.SchoolYear;
            cmbCivilStatus.Text = MainMenu.CivilStatus;
            txtClass_Name.Text = MainMenu.classname;
            cmbSem.Text = MainMenu.Sem;
             */
            //Update button
        }

        private void pnlAddStudent_Paint(object sender, PaintEventArgs e)
        {
           
            //   txtSection.ReadOnly = true;
            //  TxtDepartment.ReadOnly = true;
            //  txtCourse.ReadOnly = true;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
         
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

        private void txtFname_MouseEnter(object sender, EventArgs e)
        {
            if (txtFname.Text == "FirstName")
            {
                txtFname.Text = "";
                txtFname.ForeColor = Color.Black;
            }
        }

        private void txtFname_MouseLeave(object sender, EventArgs e)
        {
            if (txtFname.Text == "")
            {
                txtFname.Text = "FirstName";
                txtFname.ForeColor = Color.Gray;
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            Graphics mgraphics = e.Graphics;
            Pen pen = new Pen(Color.FromArgb(40, 188, 178), 1);

            Rectangle area = new Rectangle(0, 0, this.Width - 1, this.Height - 1);
            LinearGradientBrush lgb = new LinearGradientBrush(area, Color.FromArgb(40, 188, 178), Color.FromArgb(37, 137, 202), LinearGradientMode.Vertical);
            mgraphics.DrawRectangle(pen, area);
            mgraphics.FillRectangle(lgb, area);
            mgraphics.DrawRectangle(pen, area);
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
        private void btnAdd_Click(object sender, EventArgs e)
        {
            con.Open();
            OleDbCommand cmd = new OleDbCommand(" insert into[Stud_Info]([Stud_Id],[Stud_Fname],[Stud_Lname],[Stud_Mname],[Stud_Gmail],[Stud_Age],[Stud_Birthplace],[Stud_Contact],[Stud_Gender],[Stud_Address],"+
                "[Stud_MaritalStatus],[Stud_Citizenship],[Stud_Religion],[Stud_Birthdate],[Stud_FathersName],[Stud_MothersName],[Stud_FatherOccup],[Stud_MotherOccup],[Stud_ParentsAddress],[Stud_HighSchool],[Stud_HighSchoolYear],[Stud_SeniorHigh],[Stud_SeniorHighYear])"+
                " values(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)",con);
            cmd.Parameters.AddWithValue("@Stud_Id", OleDbType.Integer).Value = txtStudentNumber.Text;
            cmd.Parameters.AddWithValue("@Stud_Fname", OleDbType.VarChar).Value = txtFname.Text;
            cmd.Parameters.AddWithValue("@Stud_Lname", OleDbType.VarChar).Value = txtLname.Text;
            cmd.Parameters.AddWithValue("@Stud_Mname", OleDbType.VarChar).Value = txtMname.Text;
            cmd.Parameters.AddWithValue("@Stud_Gmail", OleDbType.VarChar).Value = txtGmail.Text;
            cmd.Parameters.AddWithValue("@Stud_Course", OleDbType.VarChar).Value = txtAge.Text;
            cmd.Parameters.AddWithValue("@Stud_Year", OleDbType.VarChar).Value = txtBirthPlace.Text;
            cmd.Parameters.AddWithValue("@Stud_Section", OleDbType.VarChar).Value = txtContact.Text;
            cmd.Parameters.AddWithValue("@Stud_ContactNumber", OleDbType.VarChar).Value = cmbGender.Text;
            cmd.Parameters.AddWithValue("@Stud_Department", OleDbType.VarChar).Value = txtAddress.Text;
            cmd.Parameters.AddWithValue("@Stud_Address", OleDbType.VarChar).Value = cmbMStatus.Text;
            cmd.Parameters.AddWithValue("@Stud_Sex", OleDbType.VarChar).Value = txtCitizenship.Text;
            cmd.Parameters.AddWithValue("@Stud_Religion", OleDbType.VarChar).Value = txtReligion.Text;
            cmd.Parameters.AddWithValue("@Stud_BirthDate", OleDbType.Date).Value = dtpBirthday.Text;
            cmd.Parameters.AddWithValue("@Stud_Status", OleDbType.VarChar).Value = txtFathersName.Text;
            cmd.Parameters.AddWithValue("@Stud_SchoolYear", OleDbType.VarChar).Value = txtMothersName.Text;
            cmd.Parameters.AddWithValue("@Stud_CivilStatus", OleDbType.VarChar).Value = txtFathersOccup.Text;
            cmd.Parameters.AddWithValue("@Class_Name", OleDbType.VarChar).Value = txtMothersOccup.Text;
            cmd.Parameters.AddWithValue("@Sem", OleDbType.VarChar).Value = txtParentsAddress.Text;
            cmd.Parameters.AddWithValue("@Sem", OleDbType.VarChar).Value = txtHighSchool.Text;
            cmd.Parameters.AddWithValue("@Sem", OleDbType.VarChar).Value = txtHighYear.Text;
            cmd.Parameters.AddWithValue("@Sem", OleDbType.VarChar).Value = txtSeniorHigh.Text;
            cmd.Parameters.AddWithValue("@Sem", OleDbType.VarChar).Value = txtSeniorYear.Text;
            
            cmd.ExecuteNonQuery();
            con.Close();
        }

        private void txtStudentNumber_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtStudentNumber_KeyPress_1(object sender, KeyPressEventArgs e)
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

        private void txtContact_KeyPress(object sender, KeyPressEventArgs e)
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
