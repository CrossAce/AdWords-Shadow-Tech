namespace ShadowAdwords
{
    partial class PopUpAccNumber
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PopUpAccNumber));
            this.inputTB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.okButt = new System.Windows.Forms.Button();
            this.cancelButt = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.SLR_RB = new System.Windows.Forms.RadioButton();
            this.StB_RB = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // inputTB
            // 
            this.inputTB.Location = new System.Drawing.Point(12, 39);
            this.inputTB.Name = "inputTB";
            this.inputTB.Size = new System.Drawing.Size(255, 20);
            this.inputTB.TabIndex = 0;
            this.inputTB.KeyDown += new System.Windows.Forms.KeyEventHandler(this.inputTB_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Enter Account Number Here";
            // 
            // okButt
            // 
            this.okButt.Location = new System.Drawing.Point(111, 87);
            this.okButt.Name = "okButt";
            this.okButt.Size = new System.Drawing.Size(75, 23);
            this.okButt.TabIndex = 2;
            this.okButt.Text = "OK ";
            this.okButt.UseVisualStyleBackColor = true;
            this.okButt.Click += new System.EventHandler(this.okButt_Click);
            // 
            // cancelButt
            // 
            this.cancelButt.Location = new System.Drawing.Point(192, 87);
            this.cancelButt.Name = "cancelButt";
            this.cancelButt.Size = new System.Drawing.Size(75, 23);
            this.cancelButt.TabIndex = 3;
            this.cancelButt.Text = "Cancel";
            this.cancelButt.UseVisualStyleBackColor = true;
            this.cancelButt.Click += new System.EventHandler(this.cancelButt_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Items.AddRange(new object[] {
            ""});
            this.listBox1.Location = new System.Drawing.Point(282, 15);
            this.listBox1.Name = "listBox1";
            this.listBox1.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBox1.Size = new System.Drawing.Size(145, 95);
            this.listBox1.TabIndex = 4;
            // 
            // SLR_RB
            // 
            this.SLR_RB.AutoSize = true;
            this.SLR_RB.Checked = true;
            this.SLR_RB.Location = new System.Drawing.Point(20, 65);
            this.SLR_RB.Name = "SLR_RB";
            this.SLR_RB.Size = new System.Drawing.Size(99, 17);
            this.SLR_RB.TabIndex = 5;
            this.SLR_RB.TabStop = true;
            this.SLR_RB.Text = "Since Last Refil";
            this.SLR_RB.UseVisualStyleBackColor = true;
            this.SLR_RB.Visible = false;
            this.SLR_RB.CheckedChanged += new System.EventHandler(this.SLR_RB_CheckedChanged);
            // 
            // StB_RB
            // 
            this.StB_RB.AutoSize = true;
            this.StB_RB.Location = new System.Drawing.Point(148, 65);
            this.StB_RB.Name = "StB_RB";
            this.StB_RB.Size = new System.Drawing.Size(114, 17);
            this.StB_RB.TabIndex = 6;
            this.StB_RB.TabStop = true;
            this.StB_RB.Text = "Since the Begining";
            this.StB_RB.UseVisualStyleBackColor = true;
            this.StB_RB.Visible = false;
            this.StB_RB.CheckedChanged += new System.EventHandler(this.StB_RB_CheckedChanged);
            // 
            // PopUpAccNumber
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(278, 122);
            this.Controls.Add(this.StB_RB);
            this.Controls.Add(this.SLR_RB);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.cancelButt);
            this.Controls.Add(this.okButt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.inputTB);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PopUpAccNumber";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Shadow Tech";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PopUpAccNumber_FormClosing);
            this.Load += new System.EventHandler(this.PopUpAccNumber_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox inputTB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button okButt;
        private System.Windows.Forms.Button cancelButt;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.RadioButton SLR_RB;
        private System.Windows.Forms.RadioButton StB_RB;
    }
}