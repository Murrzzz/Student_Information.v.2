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
    public partial class Grading : Form
    {
        OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Administrator\Desktop\Student_Information.v.2\Student_Information.v.2\database\Student_Info.accdb;Persist Security Info = False");
      
        public Grading()
        {
            InitializeComponent();
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Grading_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'sub_Name.Subject' table. You can move, or remove it, as needed.
           
            // TODO: This line of code loads data into the 'sub_Name_DataSet1.Subject' table. You can move, or remove it, as needed.
            
            
        }

        private void subjectD()
        {
          
        }
    }
}
