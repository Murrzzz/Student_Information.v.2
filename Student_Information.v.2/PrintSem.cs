using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Office.Interop.Word;
using System.Reflection;

namespace Student_Information.v._2
{
    public partial class PrintSem : Form
    {
        Settings set = new Settings();
        public PrintSem(Settings f1)
        {
            InitializeComponent();
            this.set = f1;
        }
        Microsoft.Office.Interop.Word.Application app;
        Microsoft.Office.Interop.Word.Document doc;
        object objMiss = Missing.Value;
        object TmpFile = System.IO.Path.GetTempPath() + "INVOICE.pdf";
        object FileLocation = @"C:\Users\Administrator\Desktop\Student_Information.v.2\Student_Information.v.2\Properties\Registration.docx";


        private void PrintSem_Load(object sender, EventArgs e)
        {
              
         try
            {
                app=new Microsoft.Office.Interop.Word.Application ();
                doc =app.Documents .Open (ref FileLocation ,ref objMiss,ref objMiss,ref objMiss,ref objMiss,ref objMiss,ref objMiss,ref objMiss,ref objMiss,ref objMiss,ref objMiss,ref objMiss,ref objMiss,ref objMiss,ref objMiss,ref objMiss);

                FindAndReplace ("[StudentNumber]",""+Settings.StudentId +"");
                FindAndReplace("[SchoolYear]", "" + Settings.SchoolYear_Print + "");
                FindAndReplace("[Name]", "" + Settings.Name + "");
                FindAndReplace("[Sem]", "" + Settings.Sem + "");//test
                FindAndReplace("[Year]", "" + Settings.Year + "");//test
                FindAndReplace("[Section]", "" + Settings.Section + "");//test
            
                //Pas value to word in Table
                Microsoft .Office .Interop .Word .Table tab= doc.Tables [2];
                int i=2;
                for(i=2; i<10; i++)
                {
                    tab .Rows .Add (ref objMiss );
                    tab.Cell(i, 1).Range.Text = "" + Settings.SubCode[i] + "";
                    tab.Cell(i, 2).Range.Text = "" + Settings.SubName[i] + "";
                    tab.Cell(i, 3).Range.Text = "" + Settings.SubUnits[i] + "";
                    tab.Cell(i, 4).Range.Text = "" + Settings.SubGrades[i] + "";
                }

                Microsoft.Office.Interop.Word.Table tabi = doc.Tables[1];
                int ii = 2;
                for (ii = 2; ii < 10; ii++)
                {
                    tabi.Rows.Add(ref objMiss);
                    tabi.Cell(ii, 1).Range.Text = "" + Settings.SubCode1[ii] + "";
                    tabi.Cell(ii, 2).Range.Text = "" + Settings.SubName1[ii] + "";
                    tabi.Cell(ii, 3).Range.Text = "" + Settings.SubUnits1[ii] + "";
                    tab.Cell(i, 4).Range.Text = "" + Settings.SubGrades1[ii] + "";
                }
                //Totals
            //     FindAndReplace ("[Total]","0000001");//not sum
                doc.ExportAsFixedFormat (TmpFile .ToString (), Microsoft.Office.Interop.Word.WdExportFormat.wdExportFormatPDF);
                this.axAcroPDF1.src = TmpFile.ToString();
                this.axAcroPDF1.Show();

            }
            catch (Exception ex) { MessageBox .Show (ex.Message ); }
            finally 
            {
                doc.Close (WdSaveOptions.wdDoNotSaveChanges,WdOriginalFormat.wdOriginalDocumentFormat,false );//when close dont change
                app.Quit(WdSaveOptions .wdDoNotSaveChanges );
            }
        }
        private void FindAndReplace(object FindText, object ReplaceText)
        { 
            this .app.Selection.Find.Execute(ref FindText ,true ,true,false ,false, false,true,false,1
                ,ref ReplaceText ,2,false,false,false, false);
        }

        private void Pdfread_OnError(object sender, EventArgs e)
        {

        }
    }
}
