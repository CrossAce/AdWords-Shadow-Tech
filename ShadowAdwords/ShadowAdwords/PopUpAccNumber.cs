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
                }
                else
                {
                    RenameFile(CFFileNameTemplate);

                }

                this.Close();
            }
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


    }
}
