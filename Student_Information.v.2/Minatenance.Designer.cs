﻿namespace Student_Information.v._2
{
    partial class Minatenance
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnSet = new System.Windows.Forms.Button();
            this.dgvSchoolYear = new System.Windows.Forms.DataGridView();
            this.cmbYearLevel = new System.Windows.Forms.ComboBox();
            this.btnAdd_Class = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSchoolYear)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.btnSet);
            this.panel1.Controls.Add(this.dgvSchoolYear);
            this.panel1.Controls.Add(this.cmbYearLevel);
            this.panel1.Controls.Add(this.btnAdd_Class);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(1, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(649, 557);
            this.panel1.TabIndex = 152;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.MediumTurquoise;
            this.panel2.Location = new System.Drawing.Point(-155, 1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(958, 51);
            this.panel2.TabIndex = 157;
            // 
            // btnSet
            // 
            this.btnSet.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.btnSet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSet.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSet.ForeColor = System.Drawing.Color.White;
            this.btnSet.Location = new System.Drawing.Point(472, 482);
            this.btnSet.Name = "btnSet";
            this.btnSet.Size = new System.Drawing.Size(127, 36);
            this.btnSet.TabIndex = 156;
            this.btnSet.Text = "Set";
            this.btnSet.UseVisualStyleBackColor = false;
            this.btnSet.Click += new System.EventHandler(this.button1_Click);
            // 
            // dgvSchoolYear
            // 
            this.dgvSchoolYear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSchoolYear.BackgroundColor = System.Drawing.Color.MediumTurquoise;
            this.dgvSchoolYear.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSchoolYear.Location = new System.Drawing.Point(49, 182);
            this.dgvSchoolYear.Name = "dgvSchoolYear";
            this.dgvSchoolYear.Size = new System.Drawing.Size(550, 264);
            this.dgvSchoolYear.TabIndex = 155;
            this.dgvSchoolYear.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSchoolYear_CellContentClick);
            // 
            // cmbYearLevel
            // 
            this.cmbYearLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbYearLevel.FormattingEnabled = true;
            this.cmbYearLevel.Items.AddRange(new object[] {
            "1st",
            "2nd",
            "3rd",
            "4th"});
            this.cmbYearLevel.Location = new System.Drawing.Point(219, 125);
            this.cmbYearLevel.Name = "cmbYearLevel";
            this.cmbYearLevel.Size = new System.Drawing.Size(186, 28);
            this.cmbYearLevel.TabIndex = 154;
            // 
            // btnAdd_Class
            // 
            this.btnAdd_Class.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.btnAdd_Class.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd_Class.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd_Class.ForeColor = System.Drawing.Color.White;
            this.btnAdd_Class.Location = new System.Drawing.Point(422, 120);
            this.btnAdd_Class.Name = "btnAdd_Class";
            this.btnAdd_Class.Size = new System.Drawing.Size(127, 36);
            this.btnAdd_Class.TabIndex = 152;
            this.btnAdd_Class.Text = "Add";
            this.btnAdd_Class.UseVisualStyleBackColor = false;
            this.btnAdd_Class.Click += new System.EventHandler(this.btnAdd_Class_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(113, 127);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 20);
            this.label4.TabIndex = 153;
            this.label4.Text = "School Year:";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Location = new System.Drawing.Point(0, -1);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(649, 558);
            this.panel3.TabIndex = 153;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.MediumTurquoise;
            this.panel4.Location = new System.Drawing.Point(-155, 1);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(958, 51);
            this.panel4.TabIndex = 157;
            // 
            // Minatenance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.ClientSize = new System.Drawing.Size(649, 557);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Minatenance";
            this.Text = "Minatenance";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSchoolYear)).EndInit();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSet;
        private System.Windows.Forms.DataGridView dgvSchoolYear;
        public System.Windows.Forms.ComboBox cmbYearLevel;
        private System.Windows.Forms.Button btnAdd_Class;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;

    }
}