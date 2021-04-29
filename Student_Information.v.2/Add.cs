using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Student_Information.v._2
{
    public partial class Add : Form
    {
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
    }
}
