namespace Leadtools.Medical.Winforms
{
   partial class EventLogViewer
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

      #region Component Designer generated code

      /// <summary> 
      /// Required method for Designer support - do not modify 
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent ( )
      {
         this.components = new System.ComponentModel.Container();
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EventLogViewer));
         this.tabEventLogViewer = new System.Windows.Forms.TabControl();
         this.tabpgDICOMServer = new System.Windows.Forms.TabPage();
         this.pnlDICOMQueryButton = new System.Windows.Forms.Panel();
         this.groupBox3 = new System.Windows.Forms.GroupBox();
         this.btnDICOMServerCancelImport = new System.Windows.Forms.Button();
         this.btnDICOMServerImport = new System.Windows.Forms.Button();
         this.grpDICOMServerSeparator1 = new System.Windows.Forms.GroupBox();
         this.btnDICOMServerDetails = new System.Windows.Forms.Button();
         this.btnDICOMServerExport = new System.Windows.Forms.Button();
         this.btnDICOMServerDelete = new System.Windows.Forms.Button();
         this.grpDICOMServerSeparator2 = new System.Windows.Forms.GroupBox();
         this.btnDICOMServerQuery = new System.Windows.Forms.Button();
         this.btnDICOMServerStopConQuery = new System.Windows.Forms.Button();
         this.btnDICOMServerStartConQuery = new System.Windows.Forms.Button();
         this.panel1 = new System.Windows.Forms.Panel();
         this.groupBox1 = new System.Windows.Forms.GroupBox();
         this.groupBox2 = new System.Windows.Forms.GroupBox();
         this.LogsSaveFileDialog = new System.Windows.Forms.SaveFileDialog();
         this.tmrServerQueryUpdate = new System.Windows.Forms.Timer(this.components);
         this.toltpLogViewer = new System.Windows.Forms.ToolTip(this.components);
         this.DeleteLogsContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
         this.DeleteSelectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.DeleteCurrentViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
         this.ClearAllLogsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.LogsOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
         this.LogsImageList = new System.Windows.Forms.ImageList(this.components);
         this.ctlServerMain = new Leadtools.Medical.Winforms.Control.DICOMServerMain();
         this.tabEventLogViewer.SuspendLayout();
         this.tabpgDICOMServer.SuspendLayout();
         this.pnlDICOMQueryButton.SuspendLayout();
         this.panel1.SuspendLayout();
         this.DeleteLogsContextMenuStrip.SuspendLayout();
         this.SuspendLayout();
         // 
         // tabEventLogViewer
         // 
         this.tabEventLogViewer.Controls.Add(this.tabpgDICOMServer);
         this.tabEventLogViewer.Dock = System.Windows.Forms.DockStyle.Fill;
         this.tabEventLogViewer.ImageList = this.LogsImageList;
         this.tabEventLogViewer.Location = new System.Drawing.Point(0, 0);
         this.tabEventLogViewer.Name = "tabEventLogViewer";
         this.tabEventLogViewer.SelectedIndex = 0;
         this.tabEventLogViewer.Size = new System.Drawing.Size(702, 621);
         this.tabEventLogViewer.TabIndex = 0;
         // 
         // tabpgDICOMServer
         // 
         this.tabpgDICOMServer.AutoScroll = true;
         this.tabpgDICOMServer.Controls.Add(this.ctlServerMain);
         this.tabpgDICOMServer.Controls.Add(this.pnlDICOMQueryButton);
         this.tabpgDICOMServer.Location = new System.Drawing.Point(4, 23);
         this.tabpgDICOMServer.Name = "tabpgDICOMServer";
         this.tabpgDICOMServer.Size = new System.Drawing.Size(694, 594);
         this.tabpgDICOMServer.TabIndex = 0;
         this.tabpgDICOMServer.Text = "Event Log Viewer";
         this.tabpgDICOMServer.UseVisualStyleBackColor = true;
         // 
         // pnlDICOMQueryButton
         // 
         this.pnlDICOMQueryButton.Controls.Add(this.groupBox3);
         this.pnlDICOMQueryButton.Controls.Add(this.btnDICOMServerCancelImport);
         this.pnlDICOMQueryButton.Controls.Add(this.btnDICOMServerImport);
         this.pnlDICOMQueryButton.Controls.Add(this.grpDICOMServerSeparator1);
         this.pnlDICOMQueryButton.Controls.Add(this.btnDICOMServerDetails);
         this.pnlDICOMQueryButton.Controls.Add(this.btnDICOMServerExport);
         this.pnlDICOMQueryButton.Controls.Add(this.btnDICOMServerDelete);
         this.pnlDICOMQueryButton.Controls.Add(this.grpDICOMServerSeparator2);
         this.pnlDICOMQueryButton.Controls.Add(this.btnDICOMServerQuery);
         this.pnlDICOMQueryButton.Controls.Add(this.btnDICOMServerStopConQuery);
         this.pnlDICOMQueryButton.Controls.Add(this.btnDICOMServerStartConQuery);
         this.pnlDICOMQueryButton.Dock = System.Windows.Forms.DockStyle.Bottom;
         this.pnlDICOMQueryButton.Location = new System.Drawing.Point(0, 514);
         this.pnlDICOMQueryButton.Name = "pnlDICOMQueryButton";
         this.pnlDICOMQueryButton.Size = new System.Drawing.Size(694, 80);
         this.pnlDICOMQueryButton.TabIndex = 1;
         // 
         // groupBox3
         // 
         this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.groupBox3.Location = new System.Drawing.Point(269, 8);
         this.groupBox3.Name = "groupBox3";
         this.groupBox3.Size = new System.Drawing.Size(3, 64);
         this.groupBox3.TabIndex = 2;
         this.groupBox3.TabStop = false;
         // 
         // btnDICOMServerCancelImport
         // 
         this.btnDICOMServerCancelImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.btnDICOMServerCancelImport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
         this.btnDICOMServerCancelImport.Location = new System.Drawing.Point(202, 8);
         this.btnDICOMServerCancelImport.Name = "btnDICOMServerCancelImport";
         this.btnDICOMServerCancelImport.Size = new System.Drawing.Size(64, 64);
         this.btnDICOMServerCancelImport.TabIndex = 1;
         this.toltpLogViewer.SetToolTip(this.btnDICOMServerCancelImport, "Cancel Import Logs");
         this.btnDICOMServerCancelImport.UseVisualStyleBackColor = true;
         // 
         // btnDICOMServerImport
         // 
         this.btnDICOMServerImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.btnDICOMServerImport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
         this.btnDICOMServerImport.Location = new System.Drawing.Point(136, 8);
         this.btnDICOMServerImport.Name = "btnDICOMServerImport";
         this.btnDICOMServerImport.Size = new System.Drawing.Size(64, 64);
         this.btnDICOMServerImport.TabIndex = 0;
         this.toltpLogViewer.SetToolTip(this.btnDICOMServerImport, "Import Logs");
         this.btnDICOMServerImport.UseVisualStyleBackColor = true;
         // 
         // grpDICOMServerSeparator1
         // 
         this.grpDICOMServerSeparator1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.grpDICOMServerSeparator1.Location = new System.Drawing.Point(475, 8);
         this.grpDICOMServerSeparator1.Name = "grpDICOMServerSeparator1";
         this.grpDICOMServerSeparator1.Size = new System.Drawing.Size(3, 64);
         this.grpDICOMServerSeparator1.TabIndex = 5;
         this.grpDICOMServerSeparator1.TabStop = false;
         // 
         // btnDICOMServerDetails
         // 
         this.btnDICOMServerDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.btnDICOMServerDetails.Enabled = false;
         this.btnDICOMServerDetails.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
         this.btnDICOMServerDetails.Location = new System.Drawing.Point(275, 8);
         this.btnDICOMServerDetails.Name = "btnDICOMServerDetails";
         this.btnDICOMServerDetails.Size = new System.Drawing.Size(64, 64);
         this.btnDICOMServerDetails.TabIndex = 2;
         this.toltpLogViewer.SetToolTip(this.btnDICOMServerDetails, "Show details");
         // 
         // btnDICOMServerExport
         // 
         this.btnDICOMServerExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.btnDICOMServerExport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
         this.btnDICOMServerExport.Enabled = false;
         this.btnDICOMServerExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
         this.btnDICOMServerExport.Location = new System.Drawing.Point(407, 8);
         this.btnDICOMServerExport.Name = "btnDICOMServerExport";
         this.btnDICOMServerExport.Size = new System.Drawing.Size(64, 64);
         this.btnDICOMServerExport.TabIndex = 4;
         this.toltpLogViewer.SetToolTip(this.btnDICOMServerExport, "Export selected to file");
         // 
         // btnDICOMServerDelete
         // 
         this.btnDICOMServerDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.btnDICOMServerDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
         this.btnDICOMServerDelete.Enabled = false;
         this.btnDICOMServerDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
         this.btnDICOMServerDelete.Location = new System.Drawing.Point(341, 8);
         this.btnDICOMServerDelete.Name = "btnDICOMServerDelete";
         this.btnDICOMServerDelete.Size = new System.Drawing.Size(64, 64);
         this.btnDICOMServerDelete.TabIndex = 3;
         this.toltpLogViewer.SetToolTip(this.btnDICOMServerDelete, "Delete selected");
         // 
         // grpDICOMServerSeparator2
         // 
         this.grpDICOMServerSeparator2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.grpDICOMServerSeparator2.Location = new System.Drawing.Point(549, 8);
         this.grpDICOMServerSeparator2.Name = "grpDICOMServerSeparator2";
         this.grpDICOMServerSeparator2.Size = new System.Drawing.Size(3, 64);
         this.grpDICOMServerSeparator2.TabIndex = 6;
         this.grpDICOMServerSeparator2.TabStop = false;
         // 
         // btnDICOMServerQuery
         // 
         this.btnDICOMServerQuery.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.btnDICOMServerQuery.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
         this.btnDICOMServerQuery.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
         this.btnDICOMServerQuery.Location = new System.Drawing.Point(481, 8);
         this.btnDICOMServerQuery.Name = "btnDICOMServerQuery";
         this.btnDICOMServerQuery.Size = new System.Drawing.Size(64, 64);
         this.btnDICOMServerQuery.TabIndex = 5;
         this.toltpLogViewer.SetToolTip(this.btnDICOMServerQuery, "Single query");
         // 
         // btnDICOMServerStopConQuery
         // 
         this.btnDICOMServerStopConQuery.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.btnDICOMServerStopConQuery.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
         this.btnDICOMServerStopConQuery.Location = new System.Drawing.Point(555, 8);
         this.btnDICOMServerStopConQuery.Name = "btnDICOMServerStopConQuery";
         this.btnDICOMServerStopConQuery.Size = new System.Drawing.Size(64, 64);
         this.btnDICOMServerStopConQuery.TabIndex = 6;
         this.toltpLogViewer.SetToolTip(this.btnDICOMServerStopConQuery, "Stop continuous query");
         // 
         // btnDICOMServerStartConQuery
         // 
         this.btnDICOMServerStartConQuery.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.btnDICOMServerStartConQuery.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
         this.btnDICOMServerStartConQuery.Location = new System.Drawing.Point(621, 8);
         this.btnDICOMServerStartConQuery.Name = "btnDICOMServerStartConQuery";
         this.btnDICOMServerStartConQuery.Size = new System.Drawing.Size(64, 64);
         this.btnDICOMServerStartConQuery.TabIndex = 7;
         this.toltpLogViewer.SetToolTip(this.btnDICOMServerStartConQuery, "Start continuous query");
         // 
         // panel1
         // 
         this.panel1.Controls.Add(this.groupBox1);
         this.panel1.Controls.Add(this.groupBox2);
         this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
         this.panel1.Location = new System.Drawing.Point(0, 536);
         this.panel1.Name = "panel1";
         this.panel1.Size = new System.Drawing.Size(694, 80);
         this.panel1.TabIndex = 1;
         // 
         // groupBox1
         // 
         this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.groupBox1.Location = new System.Drawing.Point(475, 8);
         this.groupBox1.Name = "groupBox1";
         this.groupBox1.Size = new System.Drawing.Size(3, 64);
         this.groupBox1.TabIndex = 3;
         this.groupBox1.TabStop = false;
         // 
         // groupBox2
         // 
         this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.groupBox2.Location = new System.Drawing.Point(549, 8);
         this.groupBox2.Name = "groupBox2";
         this.groupBox2.Size = new System.Drawing.Size(3, 64);
         this.groupBox2.TabIndex = 6;
         this.groupBox2.TabStop = false;
         // 
         // LogsSaveFileDialog
         // 
         this.LogsSaveFileDialog.Filter = "Text files (*.txt)|*.txt";
         this.LogsSaveFileDialog.RestoreDirectory = true;
         this.LogsSaveFileDialog.Title = "Export Logs";
         // 
         // tmrServerQueryUpdate
         // 
         this.tmrServerQueryUpdate.Interval = 1000;
         // 
         // DeleteLogsContextMenuStrip
         // 
         this.DeleteLogsContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DeleteSelectedToolStripMenuItem,
            this.DeleteCurrentViewToolStripMenuItem,
            this.toolStripSeparator1,
            this.ClearAllLogsToolStripMenuItem});
         this.DeleteLogsContextMenuStrip.Name = "DeleteLogsContextMenuStrip";
         this.DeleteLogsContextMenuStrip.Size = new System.Drawing.Size(207, 76);
         // 
         // DeleteSelectedToolStripMenuItem
         // 
         this.DeleteSelectedToolStripMenuItem.Name = "DeleteSelectedToolStripMenuItem";
         this.DeleteSelectedToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
         this.DeleteSelectedToolStripMenuItem.Text = "Delete Selected Logs";
         // 
         // DeleteCurrentViewToolStripMenuItem
         // 
         this.DeleteCurrentViewToolStripMenuItem.Name = "DeleteCurrentViewToolStripMenuItem";
         this.DeleteCurrentViewToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
         this.DeleteCurrentViewToolStripMenuItem.Text = "Delete Current View Logs";
         // 
         // toolStripSeparator1
         // 
         this.toolStripSeparator1.Name = "toolStripSeparator1";
         this.toolStripSeparator1.Size = new System.Drawing.Size(203, 6);
         // 
         // ClearAllLogsToolStripMenuItem
         // 
         this.ClearAllLogsToolStripMenuItem.Name = "ClearAllLogsToolStripMenuItem";
         this.ClearAllLogsToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
         this.ClearAllLogsToolStripMenuItem.Text = "Clear All Logs";
         // 
         // LogsOpenFileDialog
         // 
         this.LogsOpenFileDialog.Filter = "log files (*.txt)|*.txt";
         this.LogsOpenFileDialog.Multiselect = true;
         this.LogsOpenFileDialog.RestoreDirectory = true;
         this.LogsOpenFileDialog.Title = "Import Logs";
         // 
         // LogsImageList
         // 
         this.LogsImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("LogsImageList.ImageStream")));
         this.LogsImageList.TransparentColor = System.Drawing.Color.Transparent;
         this.LogsImageList.Images.SetKeyName(0, "import.png");
         // 
         // ctlServerMain
         // 
         this.ctlServerMain.CommandDataSource = null;
         this.ctlServerMain.CommandDisplayMember = "";
         this.ctlServerMain.Dock = System.Windows.Forms.DockStyle.Fill;
         this.ctlServerMain.Location = new System.Drawing.Point(0, 0);
         this.ctlServerMain.Name = "ctlServerMain";
         this.ctlServerMain.Padding = new System.Windows.Forms.Padding(5);
         this.ctlServerMain.ServerLogsCount = 0;
         this.ctlServerMain.Size = new System.Drawing.Size(694, 514);
         this.ctlServerMain.TabIndex = 0;
         this.ctlServerMain.TypeDataSource = null;
         this.ctlServerMain.TypeDisplayMember = "";
         this.ctlServerMain.VirutalListBackColor = System.Drawing.SystemColors.Window;
         // 
         // EventLogViewer
         // 
         this.Controls.Add(this.tabEventLogViewer);
         this.Name = "EventLogViewer";
         this.Size = new System.Drawing.Size(702, 621);
         this.tabEventLogViewer.ResumeLayout(false);
         this.tabpgDICOMServer.ResumeLayout(false);
         this.pnlDICOMQueryButton.ResumeLayout(false);
         this.panel1.ResumeLayout(false);
         this.DeleteLogsContextMenuStrip.ResumeLayout(false);
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.TabPage tabpgDICOMServer;
      private System.Windows.Forms.TabControl tabEventLogViewer ;
      private System.Windows.Forms.SaveFileDialog LogsSaveFileDialog ;
      private System.Windows.Forms.Button btnDICOMServerQuery ;
      private System.Windows.Forms.Panel pnlDICOMQueryButton;
      private System.Windows.Forms.Timer tmrServerQueryUpdate;
      private System.Windows.Forms.Button btnDICOMServerDetails;
      private System.Windows.Forms.Button btnDICOMServerExport;
      private System.Windows.Forms.Button btnDICOMServerDelete;
      private System.Windows.Forms.ToolTip toltpLogViewer;
      private System.Windows.Forms.GroupBox grpDICOMServerSeparator1;
      private System.Windows.Forms.GroupBox grpDICOMServerSeparator2;
      private System.Windows.Forms.Button btnDICOMServerStopConQuery;
      private System.Windows.Forms.Button btnDICOMServerStartConQuery;
      private System.Windows.Forms.Panel panel1;
      private System.Windows.Forms.GroupBox groupBox1;
      private System.Windows.Forms.GroupBox groupBox2;
      private System.Windows.Forms.ContextMenuStrip DeleteLogsContextMenuStrip;
      private System.Windows.Forms.ToolStripMenuItem DeleteSelectedToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem DeleteCurrentViewToolStripMenuItem;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
      private System.Windows.Forms.ToolStripMenuItem ClearAllLogsToolStripMenuItem;
      private System.Windows.Forms.Button btnDICOMServerImport;
      private System.Windows.Forms.OpenFileDialog LogsOpenFileDialog;
      private System.Windows.Forms.GroupBox groupBox3;
      private System.Windows.Forms.Button btnDICOMServerCancelImport;
      private System.Windows.Forms.ImageList LogsImageList;
      
      
   }
}
