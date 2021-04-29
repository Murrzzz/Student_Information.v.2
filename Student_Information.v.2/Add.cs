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

        private void pnlAdd_Subject_Paint(object sender, PaintEventArgs e)
        {
            OleDbDataAdapter adapt = new OleDbDataAdapter("Select * from [Subject]", con);
            DataTable table = new DataTable();
            adapt.Fill(table);
            dgvSubject.DataSource = table;

            dgvSubject.AllowUserToAddRows = false;
            dgvSubject.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvSubject.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            pnlAddStudent.Hide();
            pnlAdd_Subject.Show();

        }
    }
}
