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
    public enum Mode
    {
        PDFReport, CallfireReport
    }
    
    public partial class Form1 : Form
    {
        private bool shouldClose = false;
        private int ids = 0;
        private ConfigData configData;
        private Dictionary<int,PopUpAccNumber> popUpAccNumberForms; // change to dictionary and id the forms and close base on id
        private bool isConfigured = false;
        private string CurrentPath = "";

        public Form1()
        {
            InitializeComponent();
            popUpAccNumberForms = new Dictionary<int,PopUpAccNumber>();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RepositionForm();
            HasConfig();
            if (!isConfigured)
                MakeConfig();

            readConfigToolStripMenuItem_Click(this, EventArgs.Empty);
            fileSystemWatcherPDF.Path = configData.DownloadPath;
            fileSystemWatcherZIP.Path = configData.DownloadPath;
          
            this.Hide();
        }

        // Put this in a different class
        private void MakeConfig()
        {
            string path = Application.StartupPath;
            using (var streamWriter = new StreamWriter(path + @"\config.xml", false))
            {
                streamWriter.WriteLine("<xml>");
                streamWriter.WriteLine("<directoryForDwedReports></directoryForDwedReports>");
                streamWriter.WriteLine("<emailFromName></emailFromName>");
                streamWriter.WriteLine("<emailFromPassword></emailFromPassword>");
                streamWriter.WriteLine("<emailToListPHL></emailToListPHL>");
                streamWriter.WriteLine("<emailToListAcc></emailToListAcc>");
                streamWriter.WriteLine("</xml>");
            }
            isConfigured = true;

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
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
         
        }

        private void chargeEmailMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            ChargeForm chargeForm = new ChargeForm();
            chargeForm.Show();
        }

        private void exitToolStrip_Click(object sender, EventArgs e)
        {
            shouldClose = true;
            this.Close();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = !shouldClose;
        }

        private void readConfigToolStripMenuItem_Click(object sender, EventArgs e)
        {
            configData = ConfigXmlReader.BuildConfigData(Application.StartupPath + @"\config.xml");
            if (configData.TestForEmptyFields())
                MessageBox.Show("Config file empty.\nPlease configurate the program.");
            else
                isConfigured = true;
        }



        private void fileSystemWatcherPDF_Changed(object sender, FileSystemEventArgs e)
        {
            if (!e.FullPath.Contains(".crdownload") && CurrentPath != e.FullPath)
            {           
                var cf = new PopUpAccNumber(e.FullPath, Mode.PDFReport, configData,ids);
                cf.ShowForm();
                cf.OnClosedEvent += Cf_OnClosedEvent;
                popUpAccNumberForms.Add(ids++,cf);
                CurrentPath = e.FullPath; 
            }
        }

        private void Cf_OnClosedEvent(int id)
        {
            
        }

        private void fileSystemWatcherZIP_Changed(object sender, FileSystemEventArgs e)
        {
            if (!e.FullPath.Contains(".crdownload") && CurrentPath != e.FullPath)
            {
                var cf = new PopUpAccNumber(e.FullPath, Mode.CallfireReport, configData,ids);
                cf.ShowForm();
                cf.OnClosedEvent += Cf_OnClosedEvent;
                popUpAccNumberForms.Add(ids++,cf);
                CurrentPath = e.FullPath;
            }
        }



       
    }
}
