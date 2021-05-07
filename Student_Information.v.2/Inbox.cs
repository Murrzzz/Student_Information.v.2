using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Net;
using System.Net.Mail;
namespace Student_Information.v._2
{
    public partial class Inbox : Form
    {
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\Student_Info.accdb;Persist Security Info = True");
        NetworkCredential login;
        SmtpClient client;
        MailMessage msg;
        int num = 0;

        public Inbox()
        {
            InitializeComponent();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void Inbox_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'student_InfoDataSet._class' table. You can move, or remove it, as needed.
            this.classTableAdapter.Fill(this.student_InfoDataSet._class);

        }

        private void pnlAnnouncements_Paint(object sender, PaintEventArgs e)
        {
            //cmbClass.Refresh();
            string message = "Hello this is template";
            txtMessage.Text = message;


            Students();
            txtReciepients.ReadOnly = true;
            txtReciepients.BackColor = System.Drawing.SystemColors.Window;
        }
        private void Students()
        {
            OleDbDataAdapter adapt1 = new OleDbDataAdapter("Select [Stud_Lname],[Stud_Gmail],[Stud_Id] from [Students] where [Class_Name]='" + cmbClass.Text + "'", con);



            DataTable table1 = new DataTable();
            adapt1.Fill(table1);
            dgvStudents.DataSource = table1;

            num = table1.Rows.Count;
            Console.WriteLine(num);

            dgvStudents.AllowUserToAddRows = false;
            dgvStudents.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvStudents.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void textBox1_MouseEnter(object sender, EventArgs e)
        {
            if (txtMessage.Text == "Write Message!")
            {
                txtMessage.Text = "";
                txtMessage.ForeColor = Color.DarkGray;
            }
        }

        private void txtMessage_MouseLeave(object sender, EventArgs e)
        {
            if (txtMessage.Text == "")
            {
                txtMessage.Text = "Write Message!";
                txtMessage.ForeColor = Color.DarkGray;
            }
        }

        private void textBox2_MouseEnter(object sender, EventArgs e)
        {
            if (txtTitle.Text == "Title")
            {
                txtTitle.Text = "";
                txtTitle.ForeColor = Color.DarkGray;
            }
        }

        private void txtTitle_MouseLeave(object sender, EventArgs e)
        {
            if (txtTitle.Text == "")
            {
                txtTitle.Text = "Title";
                txtTitle.ForeColor = Color.DarkGray;

            }
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {
            Students();
        }

        private void btnGrade_Students_Click(object sender, EventArgs e)
        {
           
        }

        private static void SendCompletedCallback(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Cancelled)
                MessageBox.Show(string.Format("{0} send canceled.", e.UserState), "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (e.Error != null)
                MessageBox.Show(string.Format("{0} {1}.", e.UserState, e.Error), "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Your message has been successfully sent.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }


        private void dgvStudents_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }

        private void Inbox_Load_1(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'student_InfoDataSet_ClassName._class' table. You can move, or remove it, as needed.
           
        }

        private void dgvStudents_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvStudents.Rows[e.RowIndex];
                txtReciepients.Text = row.Cells["Stud_Gmail"].Value.ToString();

                txtReciepients.ReadOnly = true;
                txtReciepients.BackColor = System.Drawing.SystemColors.Window;
            }
        }

        private void btnGrade_Students_Click_1(object sender, EventArgs e)
        {
             if (rdPersonal.Checked==true)
            {
                try
                {
                    string Username = "rogermooresangol@gmail.com";
                    string Password = "@Nocompromise1";
                    string Subject = txtTitle.Text;
                    int Port = 587;

                    string To = txtReciepients.Text;
                    string Smtp = "smtp.gmail.com";

                    login = new NetworkCredential(Username, Password);
                    client = new SmtpClient(Smtp);
                    client.Port = Convert.ToInt32(Port);
                    client.EnableSsl = chkSSL.Checked;
                    client.Credentials = login;

                    msg = new MailMessage { From = new MailAddress(Username, "Master", Encoding.UTF8) };
                    msg.To.Add(new MailAddress(To));
                    if (!string.IsNullOrEmpty(To)) ;
                    msg.Subject = Subject;
                    msg.Body = txtMessage.Text;
                    msg.BodyEncoding = Encoding.UTF8;
                    msg.IsBodyHtml = true;
                    msg.Priority = MailPriority.Normal;
                    msg.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                    client.SendCompleted += new SendCompletedEventHandler(SendCompletedCallback);
                    string userstate = "Sending....";
                    client.SendAsync(msg, userstate);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            else if (rdGroup.Checked==true )
            {
                string email;
                string Emails = " ";

                try
                {
                  
                    for (int i = 0; i <= num-1; i++)//the variable num is in students method
                    {
                        if(i==num-1 )
                        {
                            DataGridViewRow row = this.dgvStudents.Rows[i];
                            email = row.Cells["Stud_Gmail"].Value.ToString();
                            Emails = Emails.Insert(0, "" + email + "; ");
                            Console.WriteLine(email);
                        }
                        else
                        {
                            DataGridViewRow row = this.dgvStudents.Rows[i];
                            email = row.Cells["Stud_Gmail"].Value.ToString();
                            Emails = Emails.Insert(0, "" + email + " ");
                            Console.WriteLine(email);
                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }


                try
                {
                    string Username = "rogermooresangol@gmail.com";
                    string Password = "@Nocompromise1";
                    string Subject = txtTitle.Text;
                    int Port = 587;

                    string To = Emails;
                    string Smtp = "smtp.gmail.com";

                    login = new NetworkCredential(Username, Password);
                    client = new SmtpClient(Smtp);
                    client.Port = Convert.ToInt32(Port);
                    client.EnableSsl = chkSSL.Checked;
                    client.Credentials = login;

                    msg = new MailMessage { From = new MailAddress(Username, "Master", Encoding.UTF8) };

                    msg.To.Add(new MailAddress(To));

                    foreach (var item in Emails.Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries))
                    {
                        msg.To.Add(item);
                    }
                    Console.WriteLine("Items");
                    Console.WriteLine(Emails );

                    if (!string.IsNullOrEmpty(To)) ;

                    msg.Subject = Subject;
                    msg.Body = txtMessage.Text;
                    msg.BodyEncoding = Encoding.UTF8;
                    msg.IsBodyHtml = true;
                    msg.Priority = MailPriority.Normal;
                    msg.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                    client.SendCompleted += new SendCompletedEventHandler(SendCompletedCallback);
                    string userstate = "Sending....";
                    client.SendAsync(msg, userstate);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    Console.WriteLine("Items");
                    Console.WriteLine(Emails);
                }

            }
        }

      
    }
}
