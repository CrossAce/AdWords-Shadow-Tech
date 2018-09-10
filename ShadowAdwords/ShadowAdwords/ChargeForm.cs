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
        public ConfigData ConfigData { get; set; }

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

            }
        }

        //cancel Button
        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
