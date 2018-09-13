namespace ShadowAdwords
{
    partial class AdGroupHelper
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdGroupHelper));
            this.inputTB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.KeywordsRTB = new System.Windows.Forms.RichTextBox();
            this.adGroupNameTB = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // inputTB
            // 
            this.inputTB.Location = new System.Drawing.Point(47, 36);
            this.inputTB.Name = "inputTB";
            this.inputTB.Size = new System.Drawing.Size(338, 20);
            this.inputTB.TabIndex = 0;
            this.inputTB.TextChanged += new System.EventHandler(this.inputTB_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Enter Keyword Text Here";
            // 
            // KeywordsRTB
            // 
            this.KeywordsRTB.Location = new System.Drawing.Point(47, 158);
            this.KeywordsRTB.Name = "KeywordsRTB";
            this.KeywordsRTB.Size = new System.Drawing.Size(338, 76);
            this.KeywordsRTB.TabIndex = 2;
            this.KeywordsRTB.Text = "";
            this.KeywordsRTB.KeyDown += new System.Windows.Forms.KeyEventHandler(this.adGroupNameTB_KeyDown);
            // 
            // adGroupNameTB
            // 
            this.adGroupNameTB.BackColor = System.Drawing.Color.White;
            this.adGroupNameTB.Location = new System.Drawing.Point(47, 95);
            this.adGroupNameTB.Name = "adGroupNameTB";
            this.adGroupNameTB.ReadOnly = true;
            this.adGroupNameTB.Size = new System.Drawing.Size(338, 20);
            this.adGroupNameTB.TabIndex = 3;
            this.adGroupNameTB.KeyDown += new System.Windows.Forms.KeyEventHandler(this.adGroupNameTB_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Ad Group Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(44, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Keywords";
            // 
            // AdGroupHelper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 250);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.adGroupNameTB);
            this.Controls.Add(this.KeywordsRTB);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.inputTB);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AdGroupHelper";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ad Group Helper";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox inputTB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox KeywordsRTB;
        private System.Windows.Forms.TextBox adGroupNameTB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}