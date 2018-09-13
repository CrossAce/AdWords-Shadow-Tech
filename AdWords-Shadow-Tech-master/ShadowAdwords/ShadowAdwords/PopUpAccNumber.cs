using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace ShadowAdwords
{

    /*
     294, 160 - unresized size;
     449, 160 - resized
         
     */


    public partial class PopUpAccNumber : Form
    {

        public delegate void OnClosedEventDelegate(int id);

        private const string PDFFileNameTemplate = "AdWords_{0}_Report_{1}.pdf";
        private const string CFFileNameTemplate = "{0}_recordings_{1}.zip";
        private const string datePattern = "MM.dd.yy";
        private string FilePath = "";
        private ConfigData ConfigData;
        private Mode Mode;



        public int Id { get; set; }
        public event OnClosedEventDelegate OnClosedEvent;



        public PopUpAccNumber()
        {
            InitializeComponent();
        }

        public PopUpAccNumber(string filePath, Mode mode, ConfigData data, int id)
        {
            InitializeComponent();
            this.FilePath = filePath;
            this.ConfigData = data;
            this.Mode = mode;
            this.Id = id;
        }

        public void ShowForm()
        {
            if (Mode == Mode.PDFReport)
            {
                this.Width = 294;
                okButt.Text = "OK";
            }
            else
            {
                this.Width = 449;
                SLR_RB.Visible = StB_RB.Visible = true;
                okButt.Text = "Send Mail";
                listBox1.Items.AddRange(ConfigData.adWordsPHLTeamEmails);
            }

            var desktopWorkingArea = Screen.PrimaryScreen.WorkingArea;
            this.Left = desktopWorkingArea.Right - this.Width;
            this.Top = desktopWorkingArea.Bottom - this.Height;
            this.Show();
        }

        protected virtual void OnClosedEventTriggered()
        {
            this?.OnClosedEvent.Invoke(this.Id);
        }


        private void PopUpAccNumber_Load(object sender, EventArgs e)
        {
            
        }

        private void okButt_Click(object sender, EventArgs e)
        {
            okButtonAction();
        }

        private void cancelButt_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void okButtonAction()
        {
            if(inputTB.Text != String.Empty && inputTB.Text != "")
            {
                if (Mode == Mode.PDFReport)
                {
                    var result = RenameFile(PDFFileNameTemplate);
                    if (result != null)
                        Process.Start("explorer.exe", result);
                    this.Close();
                }
                else
                {
                    FilePath = RenameFile(CFFileNameTemplate);
                    var emails = GetSelectedEmails();
                    if (emails.Length > 0)
                    {
                        bool result = Mailer.SendCFReportsEmail(emails,
                        RemoveWhitespace(inputTB.Text),
                        ConfigData.authToken,
                        FilePath,
                        SLR_RB.Checked);
                        if (result)
                        {
                            MessageBox.Show("Email Sent Successfully","Success",MessageBoxButtons.OK,MessageBoxIcon.Information);
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Ugh Something Went Wrong!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }
                  
                }

               
            }
        }

        private string[] GetSelectedEmails()
        {
            List<string> result = new List<string>(); 
            foreach(var i in listBox1.SelectedItems)
            {
                if(i.ToString() != "")
                result.Add(i.ToString());
            }
            if (result.Count == 0)
                MessageBox.Show("Please select the emails you want to send to!","Please Select Emails",
                    MessageBoxButtons.OKCancel,MessageBoxIcon.Warning);

            return result.ToArray();
        }

        private string RenameFile(string template)
        {
            string fileName = string.Format(template,
                           RemoveWhitespace(inputTB.Text),
                           DateTime.Now.ToString(datePattern));

            var newName = Path.GetDirectoryName(FilePath) + "\\" + fileName;

            try
            {
                File.Move(FilePath, newName);

                return newName; 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return null;
            }
        }



        public string RemoveWhitespace(string input) => new string(input.ToCharArray()
               .Where(c => !Char.IsWhiteSpace(c))
               .ToArray());

        private void SLR_RB_CheckedChanged(object sender, EventArgs e)
        {
            if (StB_RB.Checked)
                StB_RB.Checked = false;
        }

        private void StB_RB_CheckedChanged(object sender, EventArgs e)
        {
            if (SLR_RB.Checked)
                SLR_RB.Checked = false;
        }

        private void PopUpAccNumber_FormClosing(object sender, FormClosingEventArgs e)
        {
            OnClosedEventTriggered();
        }
    }
}
