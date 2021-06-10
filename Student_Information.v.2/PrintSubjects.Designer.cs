namespace Student_Information.v._2
{
    partial class PrintSubjects
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrintSubjects));
            this.PDFreaderr = new AxAcroPDFLib.AxAcroPDF();
            ((System.ComponentModel.ISupportInitialize)(this.PDFreaderr)).BeginInit();
            this.SuspendLayout();
            // 
            // PDFreaderr
            // 
            this.PDFreaderr.Enabled = true;
            this.PDFreaderr.Location = new System.Drawing.Point(-1, 1);
            this.PDFreaderr.Name = "PDFreaderr";
            this.PDFreaderr.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("PDFreaderr.OcxState")));
            this.PDFreaderr.Size = new System.Drawing.Size(1245, 895);
            this.PDFreaderr.TabIndex = 0;
            // 
            // PrintSubjects
            // 
            this.ClientSize = new System.Drawing.Size(1246, 895);
            this.Controls.Add(this.PDFreaderr);
            this.Name = "PrintSubjects";
            this.Load += new System.EventHandler(this.PrintSubjects_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.PDFreaderr)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AxAcroPDFLib.AxAcroPDF PDFreader;
        private AxAcroPDFLib.AxAcroPDF PDFreaderr;

    }
}