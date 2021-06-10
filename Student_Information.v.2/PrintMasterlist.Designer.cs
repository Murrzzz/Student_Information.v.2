namespace Student_Information.v._2
{
    partial class PrintMasterlist
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer componentss = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (componentss != null))
            {
                componentss.Dispose();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrintMasterlist));
            this.PDFreader = new AxAcroPDFLib.AxAcroPDF();
            ((System.ComponentModel.ISupportInitialize)(this.PDFreader)).BeginInit();
            this.SuspendLayout();
            // 
            // PDFreader
            // 
            this.PDFreader.Enabled = true;
            this.PDFreader.Location = new System.Drawing.Point(-1, 2);
            this.PDFreader.Name = "PDFreader";
            this.PDFreader.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("PDFreader.OcxState")));
            this.PDFreader.Size = new System.Drawing.Size(1249, 897);
            this.PDFreader.TabIndex = 0;
            // 
            // PrintMasterlist
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1241, 891);
            this.Controls.Add(this.PDFreader);
            this.Name = "PrintMasterlist";
            this.Text = "PrintSubjects";
            this.Load += new System.EventHandler(this.PrintMasterList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PDFreader)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AxAcroPDFLib.AxAcroPDF PDFreader;


    }
}