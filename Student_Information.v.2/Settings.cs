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

        OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Administrator\Desktop\Student_Information.v.2\Student_Information.v.2\bin\Debug\Student_Info.accdb;Persist Security Info = False");
      

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
            pnlGrade.Hide();
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
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            Hide_panels();
            pnlPrint.Show();
        }

        private void btnRecycle_Click(object sender, EventArgs e)
        {
            Hide_panels();
            pnlPrint.Show();
        }

        private void pnlSaveData_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnlRecords_Paint(object sender, PaintEventArgs e)
        {
            
        }
        private void select_students()
        {
            OleDbDataAdapter adapt1 = new OleDbDataAdapter("Select * from [Students] where[Class_Name]='"+lblClass_Name.Text  +"'", con);
            DataTable table1 = new DataTable();
            adapt1.Fill(table1);
            dgvStudent.DataSource = table1;

            dgvStudent.AllowUserToAddRows = false;
            dgvStudent.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvStudent.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void select_class()
        {
            OleDbDataAdapter adapt = new OleDbDataAdapter("Select * from [class]", con);
            DataTable table = new DataTable();
            adapt.Fill(table);
            dgvClass.DataSource = table;

            dgvClass.AllowUserToAddRows = false;
            dgvClass.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvClass.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void btnGrade_Click(object sender, EventArgs e)
        {
            Hide_panels();
            //pnlGrade.Show();
            Grading grad = new Grading();
            grad.Show();
        }

        private void dgvSubject_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvClass.Rows[e.RowIndex];
                lblClass_Name.Text = row.Cells["ClassName"].Value.ToString();
               
            }
            select_students();
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            select_class();
            select_students();
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
            print.PrintDataGridView(dgvStudent);
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
         
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
      
    }
}
