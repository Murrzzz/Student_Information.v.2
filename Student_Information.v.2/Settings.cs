﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Data.OleDb;
namespace Student_Information.v._2
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }

        OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\Student_Info.accdb;Persist Security Info = True");
      

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
            pnlRecycleBin.Hide();
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
            pnlGrade.Show();
        }

        private void btnRecycle_Click(object sender, EventArgs e)
        {
            Hide_panels();
            pnlRecycleBin.Show();
        }

        private void pnlSaveData_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnlRecords_Paint(object sender, PaintEventArgs e)
        {
            select_class();
            select_students();
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
            pnlGrade.Show();
        }

        private void dgvSubject_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvClass.Rows[e.RowIndex];
                lblClass_Name.Text = row.Cells["Class_Name"].Value.ToString();
               
            }
        }

      
    }
}
