﻿namespace Student_Information.v._2
{
    partial class PrintSem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrintSem));
            this.PDFreader = new AxAcroPDFLib.AxAcroPDF();
            this.axAcroPDF1 = new AxAcroPDFLib.AxAcroPDF();
            ((System.ComponentModel.ISupportInitialize)(this.PDFreader)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axAcroPDF1)).BeginInit();
            this.SuspendLayout();
            // 
            // PDFreader
            // 
            this.PDFreader.Enabled = true;
            this.PDFreader.Location = new System.Drawing.Point(0, 0);
            this.PDFreader.Name = "PDFreader";
            this.PDFreader.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("PDFreader.OcxState")));
            this.PDFreader.Size = new System.Drawing.Size(192, 192);
            this.PDFreader.TabIndex = 0;
            // 
            // axAcroPDF1
            // 
            this.axAcroPDF1.Enabled = true;
            this.axAcroPDF1.Location = new System.Drawing.Point(1, 2);
            this.axAcroPDF1.Name = "axAcroPDF1";
            this.axAcroPDF1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axAcroPDF1.OcxState")));
            this.axAcroPDF1.Size = new System.Drawing.Size(1230, 899);
            this.axAcroPDF1.TabIndex = 0;
            // 
            // PrintSem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1229, 898);
            this.Controls.Add(this.axAcroPDF1);
            this.Name = "PrintSem";
            this.Text = "PrintSem";
            this.Load += new System.EventHandler(this.PrintSem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PDFreader)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axAcroPDF1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AxAcroPDFLib.AxAcroPDF PDFreader;
        private AxAcroPDFLib.AxAcroPDF axAcroPDF1;
    }
}