using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace ShadowAdwords
{
    /*
     ToDo: 
     Make Emailing Async if You Can
     
     Test it fully with everything
    */


    public enum Mode
    {
        PDFReport, CallfireReport
    }
    
    public partial class Form1 : Form
    {
        private bool shouldClose = false;
        private int ids = 0;
        private ConfigData configData;
        private ErrorLogWriter ErrorLogWriter;
        private Dictionary<int,PopUpAccNumber> popUpAccNumberForms; 
        private bool isConfigured = false;
        private string CurrentPath = "";

        public Form1()
        {
            InitializeComponent();
            popUpAccNumberForms = new Dictionary<int,PopUpAccNumber>();
            ErrorLogWriter = new ErrorLogWriter(Application.StartupPath); 
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RepositionForm();
            HasConfig();
            if (!isConfigured)
                isConfigured = ConfigBuilder.Build(Application.StartupPath);

            readConfigToolStripMenuItem_Click(this, EventArgs.Empty);
            try
            {
                fileSystemWatcherPDF.Path = configData.DownloadPath;
                fileSystemWatcherZIP.Path = configData.DownloadPath;
            }
            catch
            {
                MessageBox.Show("Please Reconfig the Config File!","Important!",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            
        }

        private void HasConfig()
        {
            string path = Application.StartupPath;
            isConfigured = File.Exists(path + @"\config.xml");   
        }

        private void RepositionForm()
        {
            var desktopWorkingArea = Screen.PrimaryScreen.WorkingArea;
            this.Left = desktopWorkingArea.Right - this.Width;
            this.Top = desktopWorkingArea.Bottom - this.Height;
        }

        private void openConfigMenuItem_Click(object sender, EventArgs e)
        {
            string path = Application.StartupPath;
            try
            {
                if (isConfigured)
                {
                    Process.Start("notepad.exe", path + @"\config.xml");
                }
               
            }
            catch(Exception ex)
            {
                ErrorLogWriter.LogError(ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
         
        }

        private void chargeEmailMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            ChargeForm chargeForm = new ChargeForm() { ConfigData = this.configData };
            chargeForm.ErrorLogWriter = this.ErrorLogWriter;
            chargeForm.Show();
        }

        private void exitToolStrip_Click(object sender, EventArgs e)
        {
            shouldClose = true;
            this.Close();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!shouldClose) this.Hide();
            e.Cancel = !shouldClose;
            
        }

        private void readConfigToolStripMenuItem_Click(object sender, EventArgs e)
        {
            configData = ConfigXmlReader.BuildConfigData(Application.StartupPath + @"\config.xml");
            if (configData.TestForEmptyFields())
                MessageBox.Show("Config file empty.\nPlease configurate the program.",
                    "Important!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
                isConfigured = true;
        }



        private void fileSystemWatcherPDF_Changed(object sender, FileSystemEventArgs e)
        {
            if (!e.FullPath.Contains(".crdownload") && CurrentPath != e.FullPath)
            {           
                var cf = new PopUpAccNumber(e.FullPath, Mode.PDFReport, configData,ids);
                cf.ErrorLogWriter = this.ErrorLogWriter;
                cf.ShowForm();
                cf.OnClosedEvent += Cf_OnClosedEvent;
                popUpAccNumberForms.Add(ids++,cf);
                CurrentPath = e.FullPath; 
            }
        }

        private void Cf_OnClosedEvent(int id, string newName)
        {
            popUpAccNumberForms.Remove(id);
            this.CurrentPath = newName;
            if (popUpAccNumberForms.Count == 0)
                id = 0;
        }

        private void fileSystemWatcherZIP_Changed(object sender, FileSystemEventArgs e)
        {
            if (!e.FullPath.Contains(".crdownload") && CurrentPath != e.FullPath)
            {
                var cf = new PopUpAccNumber(e.FullPath, Mode.CallfireReport, configData,ids);
                cf.ErrorLogWriter = this.ErrorLogWriter;
                cf.ShowForm();
                cf.OnClosedEvent += Cf_OnClosedEvent;
                popUpAccNumberForms.Add(ids++,cf);
                CurrentPath = e.FullPath;
            }
        }

        private void notification_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
        }

        private void adGroupHelperToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdGroupHelper helper = new AdGroupHelper();
            helper.Show();
        }



        //Testing the Error Log Writer - toolStrip is disabled in actual program
        private void testLogWriterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ErrorLogWriter.LogError("Error");
        }
    }
}
