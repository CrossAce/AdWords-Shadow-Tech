using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShadowAdwords
{
    public partial class ChargeForm : Form
    {
        /// <summary>
        /// Keeps The Read Config.xml data
        /// </summary>
        public ConfigData ConfigData { get; set; }


        public ErrorLogWriter ErrorLogWriter { get; set; }

        /// <summary>
        /// Constructor for the class 
        /// Assign the Property ConfigData
        /// </summary>
        public ChargeForm()
        {
            InitializeComponent();
        }

       

        //send Button
        private void button1_Click(object sender, EventArgs e)
        {
            if(ConfigData == null)
            {
                MessageBox.Show("No Config Information. Please Update The Config File.", "Error - NO Config", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            }
            else
            {
                if (numberTB.Text != "" && nameTB.Text != "" && amountTLTB.Text != "")
                {
                    string result = Mailer.SendChargeEmail(ConfigData.accountantEmails, amountTLTB.Text,
                                       $"{numberTB.Text + "_" + nameTB.Text}", ConfigData.authToken);

                    if (result == "")
                    {
                        MessageBox.Show("Email Sent Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        ErrorLogWriter.LogError(result);
                        MessageBox.Show("Ugh Something Went Wrong!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
               
            }
        }

        //cancel Button
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public string RemoveWhitespace(string input) => new string(input.ToCharArray()
              .Where(c => !Char.IsWhiteSpace(c))
              .ToArray());
    }
}
