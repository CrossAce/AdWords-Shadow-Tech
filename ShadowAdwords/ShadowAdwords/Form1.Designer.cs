namespace ShadowAdwords
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.actionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chargeEmailMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openConfigMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.readConfigToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notification = new System.Windows.Forms.NotifyIcon(this.components);
            this.notificationMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openChargeFormToolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.fileSystemWatcherPDF = new System.IO.FileSystemWatcher();
            this.fileSystemWatcherZIP = new System.IO.FileSystemWatcher();
            this.menuStrip1.SuspendLayout();
            this.notificationMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcherPDF)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcherZIP)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.actionsToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(324, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // actionsToolStripMenuItem
            // 
            this.actionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.chargeEmailMenuItem});
            this.actionsToolStripMenuItem.Name = "actionsToolStripMenuItem";
            this.actionsToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.actionsToolStripMenuItem.Text = "Actions";
            // 
            // chargeEmailMenuItem
            // 
            this.chargeEmailMenuItem.Name = "chargeEmailMenuItem";
            this.chargeEmailMenuItem.Size = new System.Drawing.Size(144, 22);
            this.chargeEmailMenuItem.Text = "Charge Email";
            this.chargeEmailMenuItem.Click += new System.EventHandler(this.chargeEmailMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openConfigMenuItem,
            this.readConfigToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // openConfigMenuItem
            // 
            this.openConfigMenuItem.Name = "openConfigMenuItem";
            this.openConfigMenuItem.Size = new System.Drawing.Size(142, 22);
            this.openConfigMenuItem.Text = "Open Config";
            this.openConfigMenuItem.Click += new System.EventHandler(this.openConfigMenuItem_Click);
            // 
            // readConfigToolStripMenuItem
            // 
            this.readConfigToolStripMenuItem.Name = "readConfigToolStripMenuItem";
            this.readConfigToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.readConfigToolStripMenuItem.Text = "Read Config";
            this.readConfigToolStripMenuItem.Click += new System.EventHandler(this.readConfigToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // notification
            // 
            this.notification.BalloonTipText = "Double Click To Open";
            this.notification.BalloonTipTitle = "Shadow Adwords";
            this.notification.Text = "Notification";
            this.notification.Visible = true;
            // 
            // notificationMenuStrip
            // 
            this.notificationMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openChargeFormToolStrip,
            this.toolStripSeparator1,
            this.exitToolStrip});
            this.notificationMenuStrip.Name = "notificationMenuStrip";
            this.notificationMenuStrip.Size = new System.Drawing.Size(176, 54);
            // 
            // openChargeFormToolStrip
            // 
            this.openChargeFormToolStrip.Name = "openChargeFormToolStrip";
            this.openChargeFormToolStrip.Size = new System.Drawing.Size(175, 22);
            this.openChargeFormToolStrip.Text = "Open Charge Form";
            this.openChargeFormToolStrip.Click += new System.EventHandler(this.chargeEmailMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(172, 6);
            // 
            // exitToolStrip
            // 
            this.exitToolStrip.Name = "exitToolStrip";
            this.exitToolStrip.Size = new System.Drawing.Size(175, 22);
            this.exitToolStrip.Text = "Exit";
            this.exitToolStrip.Click += new System.EventHandler(this.exitToolStrip_Click);
            // 
            // fileSystemWatcherPDF
            // 
            this.fileSystemWatcherPDF.EnableRaisingEvents = true;
            this.fileSystemWatcherPDF.Filter = "*.pdf*";
            this.fileSystemWatcherPDF.SynchronizingObject = this;
            this.fileSystemWatcherPDF.Changed += new System.IO.FileSystemEventHandler(this.fileSystemWatcherPDF_Changed);
            // 
            // fileSystemWatcherZIP
            // 
            this.fileSystemWatcherZIP.EnableRaisingEvents = true;
            this.fileSystemWatcherZIP.Filter = "*.zip*";
            this.fileSystemWatcherZIP.SynchronizingObject = this;
            this.fileSystemWatcherZIP.Changed += new System.IO.FileSystemEventHandler(this.fileSystemWatcherZIP_Changed);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 131);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Shadow Adwords";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.notificationMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcherPDF)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcherZIP)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openConfigMenuItem;
        private System.Windows.Forms.ToolStripMenuItem actionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chargeEmailMenuItem;
        private System.Windows.Forms.NotifyIcon notification;
        private System.Windows.Forms.ContextMenuStrip notificationMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem openChargeFormToolStrip;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStrip;
        private System.Windows.Forms.ToolStripMenuItem readConfigToolStripMenuItem;
        private System.IO.FileSystemWatcher fileSystemWatcherPDF;
        private System.IO.FileSystemWatcher fileSystemWatcherZIP;
    }
}

