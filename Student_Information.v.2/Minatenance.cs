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
    public partial class Minatenance : Form
    {
        public static string SchoolYearSetup;
        OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Administrator\Desktop\Student_Information.v.2\Student_Information.v.2\database\Stud_Info_Update.accdb;Persist Security Info = False");
      
        public Minatenance()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SchoolYearSetup = cmbYearLevel.Text;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            OleDbDataAdapter adapt = new OleDbDataAdapter("Select * from [SchoolYear]", con);
            DataTable table = new DataTable();
            adapt.Fill(table);
            dgvSchoolYear.DataSource = table;

            dgvSchoolYear.AllowUserToAddRows = false;
            dgvSchoolYear.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvSchoolYear.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void btnAdd_Class_Click(object sender, EventArgs e)
        {
            con.Open();
            OleDbCommand cmd = new OleDbCommand(" insert into[SchoolYear]([SchoolYear]) values(?)", con);
            cmd.Parameters.AddWithValue("@Stud_Fname", OleDbType.VarChar).Value = cmbYearLevel.Text;
            cmd.ExecuteNonQuery();
            con.Close();
        }

        private void dgvSchoolYear_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvSchoolYear.Rows[e.RowIndex];
                cmbYearLevel .Text  = row.Cells["SchoolYear"].Value.ToString();
            }
        }
    }
}
