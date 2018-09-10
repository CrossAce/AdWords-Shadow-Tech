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
    
        private ConfigData configData;
        private List<PopUpAccNumber> popUpAccNumberForms;
        private bool isConfigured = false;

        public Form1()
        {
            InitializeComponent();
            popUpAccNumberForms = new List<PopUpAccNumber>();
        }

        private void openConfigMenuItem_Click(object sender, EventArgs e)
        {
            string path = Application.StartupPath;
            try
            {
                if (File.Exists(path + @"\config.txt"))
                {
                    Process.Start("notepad.exe", path + @"\config.xml");
                }
                else
                {

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
        }

        private void fileSystemWatcherPDF_Changed(object sender, FileSystemEventArgs e)
        {
            if (!e.FullPath.Contains(".crdownload"))
            {
                var cf = new PopUpAccNumber(e.FullPath, Mode.PDFReport, configData);
                cf.ShowForm();
                popUpAccNumberForms.Add(cf);
            }
        }

        private void fileSystemWatcherZIP_Changed(object sender, FileSystemEventArgs e)
        {
            if (!e.FullPath.Contains(".crdownload"))
            {

            }
        }
    }
}
