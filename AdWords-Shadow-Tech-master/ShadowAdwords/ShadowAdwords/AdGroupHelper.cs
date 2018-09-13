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
    public partial class AdGroupHelper : Form
    {
        public AdGroupHelper()
        {
            InitializeComponent();
        }

        private void inputTB_TextChanged(object sender, EventArgs e)
        {
            var input = inputTB.Text.Split(' ');
            for (int i = 0; i < input.Length; i++)
            {
                try
                {
                    input[i] = input[i].First().ToString().ToUpper() + input[i].Substring(1);
                }
                catch { }


            }

            string AdGroupName = string.Join(" ", input);
            adGroupNameTB.Text = AdGroupName;

            input = inputTB.Text.Split(' ');
            string exactAndphrase = $"[{inputTB.Text}]\n\"{inputTB.Text}\"";
            var action = input.Select(s => s = "+" + s).ToArray();
            string broad = string.Join(" ", action);
            KeywordsRTB.Text = exactAndphrase + Environment.NewLine + broad;
        }

        private void adGroupNameTB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.A)
            {
                if (sender is RichTextBox)
                    ((RichTextBox)sender).SelectAll();
                else
                    ((TextBox)sender).SelectAll();
            }
        }
    }
}
