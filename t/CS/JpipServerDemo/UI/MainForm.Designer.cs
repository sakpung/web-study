namespace JpipServerDemo
{
   partial class MainForm
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

         if (_server.IsRunning)
         {
            _server.Stop();
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
         this.lstvwEventLog = new System.Windows.Forms.ListView();
         this.ServerName = new System.Windows.Forms.ColumnHeader();
         this.ServerIPAddress = new System.Windows.Forms.ColumnHeader();
         this.ServerPort = new System.Windows.Forms.ColumnHeader();
         this.ClientIPAddress = new System.Windows.Forms.ColumnHeader();
         this.ClientPort = new System.Windows.Forms.ColumnHeader();
         this.EventType = new System.Windows.Forms.ColumnHeader();
         this.ChannelID = new System.Windows.Forms.ColumnHeader();
         this.DateTime = new System.Windows.Forms.ColumnHeader();
         this.Description = new System.Windows.Forms.ColumnHeader();
         this.mnuMain = new System.Windows.Forms.MenuStrip();
         this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.stopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.clearLogsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
         this.displayLogsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.ClearCacheToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.InteractiveRequeststoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.InteractiveResponsestoolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
         this.serverConfigurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.fileEnumerationServiceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.howToToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.mnuMain.SuspendLayout();
         this.SuspendLayout();
         // 
         // lstvwEventLog
         // 
         this.lstvwEventLog.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ServerName,
            this.ServerIPAddress,
            this.ServerPort,
            this.ClientIPAddress,
            this.ClientPort,
            this.EventType,
            this.ChannelID,
            this.DateTime,
            this.Description});
         this.lstvwEventLog.Dock = System.Windows.Forms.DockStyle.Fill;
         this.lstvwEventLog.FullRowSelect = true;
         this.lstvwEventLog.HideSelection = false;
         this.lstvwEventLog.Location = new System.Drawing.Point(0, 24);
         this.lstvwEventLog.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.lstvwEventLog.MultiSelect = false;
         this.lstvwEventLog.Name = "lstvwEventLog";
         this.lstvwEventLog.Size = new System.Drawing.Size(639, 485);
         this.lstvwEventLog.Sorting = System.Windows.Forms.SortOrder.Ascending;
         this.lstvwEventLog.TabIndex = 2;
         this.lstvwEventLog.UseCompatibleStateImageBehavior = false;
         this.lstvwEventLog.View = System.Windows.Forms.View.Details;
         // 
         // ServerName
         // 
         this.ServerName.Text = "Server Name";
         this.ServerName.Width = 115;
         // 
         // ServerIPAddress
         // 
         this.ServerIPAddress.Text = "Server IP Address";
         this.ServerIPAddress.Width = 67;
         // 
         // ServerPort
         // 
         this.ServerPort.Text = "Server Port";
         this.ServerPort.Width = 72;
         // 
         // ClientIPAddress
         // 
         this.ClientIPAddress.Text = "Client IP Address";
         this.ClientIPAddress.Width = 93;
         // 
         // ClientPort
         // 
         this.ClientPort.Text = "Client Port";
         this.ClientPort.Width = 64;
         // 
         // EventType
         // 
         this.EventType.Text = "Event Type";
         // 
         // ChannelID
         // 
         this.ChannelID.Text = "Channel ID";
         // 
         // DateTime
         // 
         this.DateTime.Text = "Date/Time";
         // 
         // Description
         // 
         this.Description.Text = "Description";
         this.Description.Width = 224;
         // 
         // mnuMain
         // 
         this.mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startToolStripMenuItem,
            this.stopToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.serverConfigurationToolStripMenuItem,
            this.fileEnumerationServiceToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.exitToolStripMenuItem});
         this.mnuMain.Location = new System.Drawing.Point(0, 0);
         this.mnuMain.Name = "mnuMain";
         this.mnuMain.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
         this.mnuMain.Size = new System.Drawing.Size(639, 24);
         this.mnuMain.TabIndex = 5;
         this.mnuMain.Text = "menuStrip1";
         // 
         // startToolStripMenuItem
         // 
         this.startToolStripMenuItem.Name = "startToolStripMenuItem";
         this.startToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
         this.startToolStripMenuItem.Text = "&Start";
         this.startToolStripMenuItem.Click += new System.EventHandler(this.startToolStripMenuItem_Click);
         // 
         // stopToolStripMenuItem
         // 
         this.stopToolStripMenuItem.Name = "stopToolStripMenuItem";
         this.stopToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
         this.stopToolStripMenuItem.Text = "Sto&p";
         this.stopToolStripMenuItem.Click += new System.EventHandler(this.stopToolStripMenuItem_Click);
         // 
         // viewToolStripMenuItem
         // 
         this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearLogsToolStripMenuItem,
            this.toolStripSeparator2,
            this.displayLogsToolStripMenuItem});
         this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
         this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
         this.viewToolStripMenuItem.Text = "&View";
         // 
         // clearLogsToolStripMenuItem
         // 
         this.clearLogsToolStripMenuItem.Name = "clearLogsToolStripMenuItem";
         this.clearLogsToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
         this.clearLogsToolStripMenuItem.Text = "&Clear Logs";
         this.clearLogsToolStripMenuItem.Click += new System.EventHandler(this.clearLogsToolStripMenuItem_Click);
         // 
         // toolStripSeparator2
         // 
         this.toolStripSeparator2.Name = "toolStripSeparator2";
         this.toolStripSeparator2.Size = new System.Drawing.Size(137, 6);
         // 
         // displayLogsToolStripMenuItem
         // 
         this.displayLogsToolStripMenuItem.Checked = true;
         this.displayLogsToolStripMenuItem.CheckOnClick = true;
         this.displayLogsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
         this.displayLogsToolStripMenuItem.Name = "displayLogsToolStripMenuItem";
         this.displayLogsToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
         this.displayLogsToolStripMenuItem.Text = "&Display Logs";
         this.displayLogsToolStripMenuItem.Click += new System.EventHandler(this.displayLogsToolStripMenuItem_Click);
         // 
         // toolsToolStripMenuItem
         // 
         this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ClearCacheToolStripMenuItem,
            this.InteractiveRequeststoolStripMenuItem,
            this.InteractiveResponsestoolStripMenuItem3});
         this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
         this.toolsToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
         this.toolsToolStripMenuItem.Text = "&Tools";
         // 
         // ClearCacheToolStripMenuItem
         // 
         this.ClearCacheToolStripMenuItem.Name = "ClearCacheToolStripMenuItem";
         this.ClearCacheToolStripMenuItem.Size = new System.Drawing.Size(248, 22);
         this.ClearCacheToolStripMenuItem.Text = "C&lear Server Cache";
         this.ClearCacheToolStripMenuItem.Click += new System.EventHandler(this.cacheToolStripMenuItem_Click);
         // 
         // InteractiveRequeststoolStripMenuItem
         // 
         this.InteractiveRequeststoolStripMenuItem.Name = "InteractiveRequeststoolStripMenuItem";
         this.InteractiveRequeststoolStripMenuItem.Size = new System.Drawing.Size(248, 22);
         this.InteractiveRequeststoolStripMenuItem.Text = "Interactive Requests Handling...";
         this.InteractiveRequeststoolStripMenuItem.Click += new System.EventHandler(this.InteractiveRequeststoolStripMenuItem_Click);
         // 
         // InteractiveResponsestoolStripMenuItem3
         // 
         this.InteractiveResponsestoolStripMenuItem3.Name = "InteractiveResponsestoolStripMenuItem3";
         this.InteractiveResponsestoolStripMenuItem3.Size = new System.Drawing.Size(248, 22);
         this.InteractiveResponsestoolStripMenuItem3.Text = "Interactive Responses Handling...";
         this.InteractiveResponsestoolStripMenuItem3.Click += new System.EventHandler(this.InteractiveResponsestoolStripMenuItem3_Click);
         // 
         // serverConfigurationToolStripMenuItem
         // 
         this.serverConfigurationToolStripMenuItem.Name = "serverConfigurationToolStripMenuItem";
         this.serverConfigurationToolStripMenuItem.Size = new System.Drawing.Size(102, 20);
         this.serverConfigurationToolStripMenuItem.Text = "&Configuration...";
         this.serverConfigurationToolStripMenuItem.Click += new System.EventHandler(this.configurationToolStripMenuItem_Click);
         // 
         // fileEnumerationServiceToolStripMenuItem
         // 
         this.fileEnumerationServiceToolStripMenuItem.Name = "fileEnumerationServiceToolStripMenuItem";
         this.fileEnumerationServiceToolStripMenuItem.Size = new System.Drawing.Size(177, 20);
         this.fileEnumerationServiceToolStripMenuItem.Text = "&Images Enumeration Service...";
         this.fileEnumerationServiceToolStripMenuItem.Click += new System.EventHandler(this.fileEnumerationServiceToolStripMenuItem_Click);
         // 
         // helpToolStripMenuItem
         // 
         this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem,
            this.howToToolStripMenuItem});
         this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
         this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
         this.helpToolStripMenuItem.Text = "&Help";
         // 
         // aboutToolStripMenuItem
         // 
         this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
         this.aboutToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
         this.aboutToolStripMenuItem.Text = "&About";
         this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
         // 
         // howToToolStripMenuItem
         // 
         this.howToToolStripMenuItem.Name = "howToToolStripMenuItem";
         this.howToToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
         this.howToToolStripMenuItem.Text = "How To";
         this.howToToolStripMenuItem.Click += new System.EventHandler(this.howToToolStripMenuItem_Click);
         // 
         // exitToolStripMenuItem
         // 
         this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
         this.exitToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
         this.exitToolStripMenuItem.Text = "&Exit";
         this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
         // 
         // MainForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(643, 513);
         this.Controls.Add(this.lstvwEventLog);
         this.Controls.Add(this.mnuMain);
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.MainMenuStrip = this.mnuMain;
         this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.Name = "MainForm";
         this.Padding = new System.Windows.Forms.Padding(0, 0, 4, 4);
         this.Text = "JPIP Server Demo";
         this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
         this.mnuMain.ResumeLayout(false);
         this.mnuMain.PerformLayout();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.ListView lstvwEventLog;
      private System.Windows.Forms.ColumnHeader ServerName;
      private System.Windows.Forms.ColumnHeader ServerIPAddress;
      private System.Windows.Forms.ColumnHeader ServerPort;
      private System.Windows.Forms.ColumnHeader ClientIPAddress;
      private System.Windows.Forms.ColumnHeader ClientPort;
      private System.Windows.Forms.ColumnHeader EventType;
      private System.Windows.Forms.ColumnHeader Description;
      private System.Windows.Forms.ColumnHeader ChannelID;
      private System.Windows.Forms.ColumnHeader DateTime;
      private System.Windows.Forms.MenuStrip mnuMain;
      private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem clearLogsToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
      private System.Windows.Forms.ToolStripMenuItem displayLogsToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem ClearCacheToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem InteractiveRequeststoolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem InteractiveResponsestoolStripMenuItem3;
      private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem howToToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem serverConfigurationToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem stopToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem fileEnumerationServiceToolStripMenuItem;
   }
}

