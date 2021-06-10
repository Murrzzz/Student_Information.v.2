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
    public partial class PrintSubjects : Form
    {
        MainMenu main = new MainMenu();
        public PrintSubjects(MainMenu f1)
        {
            InitializeComponent();
            this.main = f1;
        }

    
        Microsoft.Office.Interop.Word.Application app;
        Microsoft.Office.Interop.Word.Document doc;
        object objMiss = Missing.Value;
        object TmpFile = System.IO.Path.GetTempPath() + "INVOICE.pdf";
        object FileLocation = @"C:\Users\Administrator\Desktop\Student_Information.v.2\Student_Information.v.2\Properties\Subjects.docx";


  

        private void PrintSubjects_Load(object sender, EventArgs e)
        {
 
     
        }
        private void FindAndReplace(object FindText, object ReplaceText)
        { 
            this .app.Selection.Find.Execute(ref FindText ,true ,true,false ,false, false,true,false,1
                ,ref ReplaceText ,2,false,false,false, false);
        }

        private void axAcroPDF1_OnError(object sender, EventArgs e)
        {

        }

        private void PrintSubjects_Load_1(object sender, EventArgs e)
        {
            try
            {
                app = new Microsoft.Office.Interop.Word.Application();
                doc = app.Documents.Open(ref FileLocation, ref objMiss, ref objMiss, ref objMiss, ref objMiss, ref objMiss, ref objMiss, ref objMiss, ref objMiss, ref objMiss, ref objMiss, ref objMiss, ref objMiss, ref objMiss, ref objMiss, ref objMiss);

                FindAndReplace("[StudentNumber]", "" + MainMenu.StudentId + "");
                FindAndReplace("[SchoolYear]", "" + MainMenu.SchoolYear_Print + "");
                FindAndReplace("[Name]", "" + MainMenu.Name + "");
                FindAndReplace("[Sem]", "" + MainMenu.Sem + "");//test
                FindAndReplace("[Year]", "" + MainMenu.Year + "");//test
                FindAndReplace("[Section]", "" + MainMenu.Section + "");//test

                //Pas value to word in Table
                Microsoft.Office.Interop.Word.Table tab = doc.Tables[1];
                int i = 2;
                for (i = 2; i < 10; i++)
                {
                    tab.Rows.Add(ref objMiss);
                    tab.Cell(i, 1).Range.Text = "" + MainMenu.SubCode[i] + "";
                    tab.Cell(i, 2).Range.Text = "" + MainMenu.SubName[i] + "";
                    tab.Cell(i, 3).Range.Text = "" + MainMenu.SubUnits[i] + "";

                }



                //Totals
                //     FindAndReplace ("[Total]","0000001");//not sum
                doc.ExportAsFixedFormat(TmpFile.ToString(), Microsoft.Office.Interop.Word.WdExportFormat.wdExportFormatPDF);
                this.PDFreaderr.src = TmpFile.ToString();
                this.PDFreaderr.Show();

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally
            {
                doc.Close(WdSaveOptions.wdDoNotSaveChanges, WdOriginalFormat.wdOriginalDocumentFormat, false);//when close dont change
                app.Quit(WdSaveOptions.wdDoNotSaveChanges);
            }
        }

   
    }
}
