using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using Microsoft.Office.Interop.Word;

namespace Student_Information.v._2
{
    public partial class PrintMasterlist : Form
    {
        MainMenu mainn = new MainMenu();
        public PrintMasterlist(MainMenu f1)
        {
            InitializeComponent();
            this.mainn = f1;
        }
        Microsoft.Office.Interop.Word.Application appp;
        Microsoft.Office.Interop.Word.Document docc;
        object objMisss = Missing.Value;
        object TmpFilee = System.IO.Path.GetTempPath() + "INVOICE.pdf";
        object FileLocationn = @"C:\Users\Administrator\Desktop\Student_Information.v.2\Student_Information.v.2\Properties\MasterList.docx";


  

        private void PrintSubjects_Load(object sender, EventArgs e)
        {
 
        }
        private void FindAndReplacee(object FindText, object ReplaceText)
        { 
            this .appp.Selection.Find.Execute(ref FindText ,true ,true,false ,false, false,true,false,1
                ,ref ReplaceText ,2,false,false,false, false);
        }

        private void axAcroPDF1_OnError(object sender, EventArgs e)
        {

        }

        private void PrintMasterList_Load(object sender, EventArgs e)
        {

            try
            {
                appp = new Microsoft.Office.Interop.Word.Application();
                docc = appp.Documents.Open(ref FileLocationn, ref objMisss, ref objMisss, ref objMisss, ref objMisss, ref objMisss, ref objMisss, ref objMisss, ref objMisss, ref objMisss, ref objMisss, ref objMisss, ref objMisss, ref objMisss, ref objMisss, ref objMisss);


                //Pas value to word in Table
                Microsoft.Office.Interop.Word.Table tab = docc.Tables[1];
                int i = 2;
                for (i = 2; i < 10; i++)
                {
                    tab.Rows.Add(ref objMisss);
                    tab.Cell(i, 1).Range.Text = "" + MainMenu.Student_id[i] + "";
                    tab.Cell(i, 2).Range.Text = "" + MainMenu.Student_Lname[i] + "";
                    tab.Cell(i, 3).Range.Text = "" + MainMenu.Student_Fname[i] + "";
                    tab.Cell(i, 4).Range.Text = "" + MainMenu.Student_Mname[i] + "";
                }



                //Totals
                //     FindAndReplace ("[Total]","0000001");//not sum
                docc.ExportAsFixedFormat(TmpFilee.ToString(), Microsoft.Office.Interop.Word.WdExportFormat.wdExportFormatPDF);
                this.PDFreader.src = TmpFilee.ToString();
                this.PDFreader.Show();

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally
            {
                docc.Close(WdSaveOptions.wdDoNotSaveChanges, WdOriginalFormat.wdOriginalDocumentFormat, false);//when close dont change
                appp.Quit(WdSaveOptions.wdDoNotSaveChanges);
            }
        }
    }
}
