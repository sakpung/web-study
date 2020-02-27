namespace Leadtools.Medical.Winforms
{
   partial class ServerInformationControl
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
      private void InitializeComponent()
      {
         this.buttonSystemInformation = new System.Windows.Forms.Button();
         this.groupBoxStorageStatistics = new System.Windows.Forms.GroupBox();
         this.progressBar = new System.Windows.Forms.ProgressBar();
         this.textBoxTotalDataStored = new System.Windows.Forms.TextBox();
         this.textBoxTotalImages = new System.Windows.Forms.TextBox();
         this.textBoxTotalSeries = new System.Windows.Forms.TextBox();
         this.textBoxTotalStudies = new System.Windows.Forms.TextBox();
         this.textBoxTotalPatients = new System.Windows.Forms.TextBox();
         this.buttonRecalculateTotalDataStored = new System.Windows.Forms.Button();
         this.labelTotalDataStored = new System.Windows.Forms.Label();
         this.labelTotalImages = new System.Windows.Forms.Label();
         this.labelTotalSeries = new System.Windows.Forms.Label();
         this.labelTotalStudies = new System.Windows.Forms.Label();
         this.labelTotalPatients = new System.Windows.Forms.Label();
         this.groupBoxSqlServerInformation = new System.Windows.Forms.GroupBox();
         this.treeViewSqlServerInformation = new System.Windows.Forms.TreeView();
         this.groupBoxServerConnections = new System.Windows.Forms.GroupBox();
         this.textBoxCurrentConnections = new System.Windows.Forms.TextBox();
         this.textBoxMaximumConnections = new System.Windows.Forms.TextBox();
         this.labelCurrentConnections = new System.Windows.Forms.Label();
         this.labelMaximumConnections = new System.Windows.Forms.Label();
         this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
         this.label1 = new System.Windows.Forms.Label();
         this.linkLabelServiceName = new System.Windows.Forms.LinkLabel();
         this.label3 = new System.Windows.Forms.Label();
         this.labelUptime = new System.Windows.Forms.Label();
         this.label2 = new System.Windows.Forms.Label();
         this.linkLabel1 = new System.Windows.Forms.LinkLabel();
         this.label4 = new System.Windows.Forms.Label();
         this.label5 = new System.Windows.Forms.Label();
         this.groupBox1 = new System.Windows.Forms.GroupBox();
         this.listViewModules = new System.Windows.Forms.ListView();
         this.columnName = new System.Windows.Forms.ColumnHeader();
         this.columnVersion = new System.Windows.Forms.ColumnHeader();
         this.groupBoxStorageStatistics.SuspendLayout();
         this.groupBoxSqlServerInformation.SuspendLayout();
         this.groupBoxServerConnections.SuspendLayout();
         this.groupBox1.SuspendLayout();
         this.SuspendLayout();
         // 
         // buttonSystemInformation
         // 
         this.buttonSystemInformation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.buttonSystemInformation.Location = new System.Drawing.Point(305, 7);
         this.buttonSystemInformation.Name = "buttonSystemInformation";
         this.buttonSystemInformation.Size = new System.Drawing.Size(131, 23);
         this.buttonSystemInformation.TabIndex = 0;
         this.buttonSystemInformation.Text = "System Information...";
         this.buttonSystemInformation.UseVisualStyleBackColor = true;
         this.buttonSystemInformation.Click += new System.EventHandler(this.buttonSystemInformation_Click);
         // 
         // groupBoxStorageStatistics
         // 
         this.groupBoxStorageStatistics.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.groupBoxStorageStatistics.Controls.Add(this.progressBar);
         this.groupBoxStorageStatistics.Controls.Add(this.textBoxTotalDataStored);
         this.groupBoxStorageStatistics.Controls.Add(this.textBoxTotalImages);
         this.groupBoxStorageStatistics.Controls.Add(this.textBoxTotalSeries);
         this.groupBoxStorageStatistics.Controls.Add(this.textBoxTotalStudies);
         this.groupBoxStorageStatistics.Controls.Add(this.textBoxTotalPatients);
         this.groupBoxStorageStatistics.Controls.Add(this.buttonRecalculateTotalDataStored);
         this.groupBoxStorageStatistics.Controls.Add(this.labelTotalDataStored);
         this.groupBoxStorageStatistics.Controls.Add(this.labelTotalImages);
         this.groupBoxStorageStatistics.Controls.Add(this.labelTotalSeries);
         this.groupBoxStorageStatistics.Controls.Add(this.labelTotalStudies);
         this.groupBoxStorageStatistics.Controls.Add(this.labelTotalPatients);
         this.groupBoxStorageStatistics.Location = new System.Drawing.Point(8, 277);
         this.groupBoxStorageStatistics.Name = "groupBoxStorageStatistics";
         this.groupBoxStorageStatistics.Size = new System.Drawing.Size(431, 133);
         this.groupBoxStorageStatistics.TabIndex = 2;
         this.groupBoxStorageStatistics.TabStop = false;
         this.groupBoxStorageStatistics.Text = "Storage Statistics";
         // 
         // progressBar
         // 
         this.progressBar.Location = new System.Drawing.Point(251, 72);
         this.progressBar.Name = "progressBar";
         this.progressBar.Size = new System.Drawing.Size(166, 21);
         this.progressBar.Step = 1;
         this.progressBar.TabIndex = 59;
         // 
         // textBoxTotalDataStored
         // 
         this.textBoxTotalDataStored.Location = new System.Drawing.Point(346, 20);
         this.textBoxTotalDataStored.Name = "textBoxTotalDataStored";
         this.textBoxTotalDataStored.ReadOnly = true;
         this.textBoxTotalDataStored.Size = new System.Drawing.Size(71, 20);
         this.textBoxTotalDataStored.TabIndex = 57;
         this.textBoxTotalDataStored.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
         // 
         // textBoxTotalImages
         // 
         this.textBoxTotalImages.Location = new System.Drawing.Point(97, 98);
         this.textBoxTotalImages.Name = "textBoxTotalImages";
         this.textBoxTotalImages.ReadOnly = true;
         this.textBoxTotalImages.Size = new System.Drawing.Size(71, 20);
         this.textBoxTotalImages.TabIndex = 55;
         this.textBoxTotalImages.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
         this.textBoxTotalImages.DoubleClick += new System.EventHandler(this.textBoxTotalImages_DoubleClick);
         // 
         // textBoxTotalSeries
         // 
         this.textBoxTotalSeries.Location = new System.Drawing.Point(97, 72);
         this.textBoxTotalSeries.Name = "textBoxTotalSeries";
         this.textBoxTotalSeries.ReadOnly = true;
         this.textBoxTotalSeries.Size = new System.Drawing.Size(71, 20);
         this.textBoxTotalSeries.TabIndex = 53;
         this.textBoxTotalSeries.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
         this.textBoxTotalSeries.DoubleClick += new System.EventHandler(this.textBoxTotalSeries_DoubleClick);
         // 
         // textBoxTotalStudies
         // 
         this.textBoxTotalStudies.Location = new System.Drawing.Point(97, 46);
         this.textBoxTotalStudies.Name = "textBoxTotalStudies";
         this.textBoxTotalStudies.ReadOnly = true;
         this.textBoxTotalStudies.Size = new System.Drawing.Size(71, 20);
         this.textBoxTotalStudies.TabIndex = 51;
         this.textBoxTotalStudies.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
         this.textBoxTotalStudies.DoubleClick += new System.EventHandler(this.textBoxTotalStudies_DoubleClick);
         // 
         // textBoxTotalPatients
         // 
         this.textBoxTotalPatients.Location = new System.Drawing.Point(97, 20);
         this.textBoxTotalPatients.Name = "textBoxTotalPatients";
         this.textBoxTotalPatients.ReadOnly = true;
         this.textBoxTotalPatients.Size = new System.Drawing.Size(71, 20);
         this.textBoxTotalPatients.TabIndex = 49;
         this.textBoxTotalPatients.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
         this.textBoxTotalPatients.DoubleClick += new System.EventHandler(this.textBoxTotalPatients_DoubleClick);
         // 
         // buttonRecalculateTotalDataStored
         // 
         this.buttonRecalculateTotalDataStored.Location = new System.Drawing.Point(251, 45);
         this.buttonRecalculateTotalDataStored.Name = "buttonRecalculateTotalDataStored";
         this.buttonRecalculateTotalDataStored.Size = new System.Drawing.Size(166, 23);
         this.buttonRecalculateTotalDataStored.TabIndex = 58;
         this.buttonRecalculateTotalDataStored.Text = "Calculate Total Data Stored";
         this.buttonRecalculateTotalDataStored.UseVisualStyleBackColor = true;
         this.buttonRecalculateTotalDataStored.Click += new System.EventHandler(this.buttonRecalculateTotalDataStored_Click);
         // 
         // labelTotalDataStored
         // 
         this.labelTotalDataStored.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.labelTotalDataStored.AutoSize = true;
         this.labelTotalDataStored.Location = new System.Drawing.Point(248, 24);
         this.labelTotalDataStored.Name = "labelTotalDataStored";
         this.labelTotalDataStored.Size = new System.Drawing.Size(94, 13);
         this.labelTotalDataStored.TabIndex = 56;
         this.labelTotalDataStored.Text = "Total Data Stored:";
         // 
         // labelTotalImages
         // 
         this.labelTotalImages.AutoSize = true;
         this.labelTotalImages.Location = new System.Drawing.Point(8, 102);
         this.labelTotalImages.Name = "labelTotalImages";
         this.labelTotalImages.Size = new System.Drawing.Size(71, 13);
         this.labelTotalImages.TabIndex = 54;
         this.labelTotalImages.Text = "Total Images:";
         // 
         // labelTotalSeries
         // 
         this.labelTotalSeries.AutoSize = true;
         this.labelTotalSeries.Location = new System.Drawing.Point(8, 76);
         this.labelTotalSeries.Name = "labelTotalSeries";
         this.labelTotalSeries.Size = new System.Drawing.Size(66, 13);
         this.labelTotalSeries.TabIndex = 52;
         this.labelTotalSeries.Text = "Total Series:";
         // 
         // labelTotalStudies
         // 
         this.labelTotalStudies.AutoSize = true;
         this.labelTotalStudies.Location = new System.Drawing.Point(8, 50);
         this.labelTotalStudies.Name = "labelTotalStudies";
         this.labelTotalStudies.Size = new System.Drawing.Size(72, 13);
         this.labelTotalStudies.TabIndex = 50;
         this.labelTotalStudies.Text = "Total Studies:";
         // 
         // labelTotalPatients
         // 
         this.labelTotalPatients.AutoSize = true;
         this.labelTotalPatients.Location = new System.Drawing.Point(8, 24);
         this.labelTotalPatients.Name = "labelTotalPatients";
         this.labelTotalPatients.Size = new System.Drawing.Size(75, 13);
         this.labelTotalPatients.TabIndex = 48;
         this.labelTotalPatients.Text = "Total Patients:";
         // 
         // groupBoxSqlServerInformation
         // 
         this.groupBoxSqlServerInformation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.groupBoxSqlServerInformation.Controls.Add(this.treeViewSqlServerInformation);
         this.groupBoxSqlServerInformation.Location = new System.Drawing.Point(8, 60);
         this.groupBoxSqlServerInformation.Name = "groupBoxSqlServerInformation";
         this.groupBoxSqlServerInformation.Size = new System.Drawing.Size(434, 156);
         this.groupBoxSqlServerInformation.TabIndex = 1;
         this.groupBoxSqlServerInformation.TabStop = false;
         this.groupBoxSqlServerInformation.Text = "Sql Server Information";
         // 
         // treeViewSqlServerInformation
         // 
         this.treeViewSqlServerInformation.Dock = System.Windows.Forms.DockStyle.Fill;
         this.treeViewSqlServerInformation.Location = new System.Drawing.Point(3, 16);
         this.treeViewSqlServerInformation.Name = "treeViewSqlServerInformation";
         this.treeViewSqlServerInformation.Size = new System.Drawing.Size(428, 137);
         this.treeViewSqlServerInformation.TabIndex = 0;
         // 
         // groupBoxServerConnections
         // 
         this.groupBoxServerConnections.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.groupBoxServerConnections.Controls.Add(this.textBoxCurrentConnections);
         this.groupBoxServerConnections.Controls.Add(this.textBoxMaximumConnections);
         this.groupBoxServerConnections.Controls.Add(this.labelCurrentConnections);
         this.groupBoxServerConnections.Controls.Add(this.labelMaximumConnections);
         this.groupBoxServerConnections.Location = new System.Drawing.Point(8, 426);
         this.groupBoxServerConnections.Name = "groupBoxServerConnections";
         this.groupBoxServerConnections.Size = new System.Drawing.Size(431, 52);
         this.groupBoxServerConnections.TabIndex = 0;
         this.groupBoxServerConnections.TabStop = false;
         this.groupBoxServerConnections.Text = "Server Connections";
         // 
         // textBoxCurrentConnections
         // 
         this.textBoxCurrentConnections.Location = new System.Drawing.Point(95, 17);
         this.textBoxCurrentConnections.Name = "textBoxCurrentConnections";
         this.textBoxCurrentConnections.ReadOnly = true;
         this.textBoxCurrentConnections.Size = new System.Drawing.Size(71, 20);
         this.textBoxCurrentConnections.TabIndex = 2;
         this.textBoxCurrentConnections.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
         // 
         // textBoxMaximumConnections
         // 
         this.textBoxMaximumConnections.Location = new System.Drawing.Point(344, 17);
         this.textBoxMaximumConnections.Name = "textBoxMaximumConnections";
         this.textBoxMaximumConnections.ReadOnly = true;
         this.textBoxMaximumConnections.Size = new System.Drawing.Size(71, 20);
         this.textBoxMaximumConnections.TabIndex = 1;
         this.textBoxMaximumConnections.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
         // 
         // labelCurrentConnections
         // 
         this.labelCurrentConnections.AutoSize = true;
         this.labelCurrentConnections.Location = new System.Drawing.Point(6, 21);
         this.labelCurrentConnections.Name = "labelCurrentConnections";
         this.labelCurrentConnections.Size = new System.Drawing.Size(75, 13);
         this.labelCurrentConnections.TabIndex = 1;
         this.labelCurrentConnections.Text = "Current Count:";
         // 
         // labelMaximumConnections
         // 
         this.labelMaximumConnections.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.labelMaximumConnections.AutoSize = true;
         this.labelMaximumConnections.Location = new System.Drawing.Point(246, 21);
         this.labelMaximumConnections.Name = "labelMaximumConnections";
         this.labelMaximumConnections.Size = new System.Drawing.Size(85, 13);
         this.labelMaximumConnections.TabIndex = 0;
         this.labelMaximumConnections.Text = "Maximum Count:";
         // 
         // backgroundWorker
         // 
         this.backgroundWorker.WorkerReportsProgress = true;
         this.backgroundWorker.WorkerSupportsCancellation = true;
         this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundworker_DoWork);
         this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundworker_RunWorkerCompleted);
         this.backgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker_ProgressChanged);
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(8, 12);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(77, 13);
         this.label1.TabIndex = 3;
         this.label1.Text = "Service Name:";
         // 
         // linkLabelServiceName
         // 
         this.linkLabelServiceName.AutoSize = true;
         this.linkLabelServiceName.Cursor = System.Windows.Forms.Cursors.Hand;
         this.linkLabelServiceName.LinkBehavior = System.Windows.Forms.LinkBehavior.AlwaysUnderline;
         this.linkLabelServiceName.Location = new System.Drawing.Point(92, 11);
         this.linkLabelServiceName.Name = "linkLabelServiceName";
         this.linkLabelServiceName.Size = new System.Drawing.Size(0, 13);
         this.linkLabelServiceName.TabIndex = 4;
         this.linkLabelServiceName.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelServiceName_LinkClicked);
         // 
         // label3
         // 
         this.label3.AutoSize = true;
         this.label3.Location = new System.Drawing.Point(8, 33);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(43, 13);
         this.label3.TabIndex = 5;
         this.label3.Text = "Uptime:";
         // 
         // labelUptime
         // 
         this.labelUptime.AutoSize = true;
         this.labelUptime.Location = new System.Drawing.Point(92, 33);
         this.labelUptime.Name = "labelUptime";
         this.labelUptime.Size = new System.Drawing.Size(0, 13);
         this.labelUptime.TabIndex = 6;
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(8, 12);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(77, 13);
         this.label2.TabIndex = 3;
         this.label2.Text = "Service Name:";
         // 
         // linkLabel1
         // 
         this.linkLabel1.AutoSize = true;
         this.linkLabel1.Cursor = System.Windows.Forms.Cursors.Hand;
         this.linkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.AlwaysUnderline;
         this.linkLabel1.Location = new System.Drawing.Point(92, 11);
         this.linkLabel1.Name = "linkLabel1";
         this.linkLabel1.Size = new System.Drawing.Size(0, 13);
         this.linkLabel1.TabIndex = 4;
         this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelServiceName_LinkClicked);
         // 
         // label4
         // 
         this.label4.AutoSize = true;
         this.label4.Location = new System.Drawing.Point(8, 33);
         this.label4.Name = "label4";
         this.label4.Size = new System.Drawing.Size(43, 13);
         this.label4.TabIndex = 5;
         this.label4.Text = "Uptime:";
         // 
         // label5
         // 
         this.label5.AutoSize = true;
         this.label5.Location = new System.Drawing.Point(92, 33);
         this.label5.Name = "label5";
         this.label5.Size = new System.Drawing.Size(0, 13);
         this.label5.TabIndex = 6;
         // 
         // groupBox1
         // 
         this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                     | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.groupBox1.Controls.Add(this.listViewModules);
         this.groupBox1.Location = new System.Drawing.Point(8, 222);
         this.groupBox1.Name = "groupBox1";
         this.groupBox1.Size = new System.Drawing.Size(434, 49);
         this.groupBox1.TabIndex = 7;
         this.groupBox1.TabStop = false;
         this.groupBox1.Text = "Modules";
         // 
         // listViewModules
         // 
         this.listViewModules.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnName,
            this.columnVersion});
         this.listViewModules.Dock = System.Windows.Forms.DockStyle.Fill;
         this.listViewModules.FullRowSelect = true;
         this.listViewModules.HideSelection = false;
         this.listViewModules.Location = new System.Drawing.Point(3, 16);
         this.listViewModules.MultiSelect = false;
         this.listViewModules.Name = "listViewModules";
         this.listViewModules.Size = new System.Drawing.Size(428, 30);
         this.listViewModules.TabIndex = 16;
         this.listViewModules.UseCompatibleStateImageBehavior = false;
         this.listViewModules.View = System.Windows.Forms.View.Details;
         this.listViewModules.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listViewModules_ColumnClick);
         // 
         // columnName
         // 
         this.columnName.Text = "Name";
         this.columnName.Width = 150;
         // 
         // columnVersion
         // 
         this.columnVersion.Text = "Version";
         this.columnVersion.Width = 150;
         // 
         // ServerInformationControl
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.AutoScroll = true;
         this.Controls.Add(this.groupBox1);
         this.Controls.Add(this.label5);
         this.Controls.Add(this.labelUptime);
         this.Controls.Add(this.label4);
         this.Controls.Add(this.label3);
         this.Controls.Add(this.linkLabel1);
         this.Controls.Add(this.linkLabelServiceName);
         this.Controls.Add(this.label2);
         this.Controls.Add(this.label1);
         this.Controls.Add(this.groupBoxServerConnections);
         this.Controls.Add(this.groupBoxSqlServerInformation);
         this.Controls.Add(this.groupBoxStorageStatistics);
         this.Controls.Add(this.buttonSystemInformation);
         this.Name = "ServerInformationControl";
         this.Size = new System.Drawing.Size(447, 485);
         this.Load += new System.EventHandler(this.ServerInformationControl_Load);
         this.VisibleChanged += new System.EventHandler(this.ServerInformationControl_VisibleChanged);
         this.groupBoxStorageStatistics.ResumeLayout(false);
         this.groupBoxStorageStatistics.PerformLayout();
         this.groupBoxSqlServerInformation.ResumeLayout(false);
         this.groupBoxServerConnections.ResumeLayout(false);
         this.groupBoxServerConnections.PerformLayout();
         this.groupBox1.ResumeLayout(false);
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Button buttonSystemInformation;
      private System.Windows.Forms.GroupBox groupBoxStorageStatistics;
      private System.Windows.Forms.GroupBox groupBoxSqlServerInformation;
      private System.Windows.Forms.TreeView treeViewSqlServerInformation;
      private System.Windows.Forms.GroupBox groupBoxServerConnections;
      private System.Windows.Forms.Label labelCurrentConnections;
      private System.Windows.Forms.Label labelMaximumConnections;
      private System.Windows.Forms.TextBox textBoxCurrentConnections;
      private System.Windows.Forms.TextBox textBoxMaximumConnections;
      private System.ComponentModel.BackgroundWorker backgroundWorker;
      private System.Windows.Forms.ProgressBar progressBar;
      private System.Windows.Forms.TextBox textBoxTotalDataStored;
      private System.Windows.Forms.TextBox textBoxTotalImages;
      private System.Windows.Forms.TextBox textBoxTotalSeries;
      private System.Windows.Forms.TextBox textBoxTotalStudies;
      private System.Windows.Forms.TextBox textBoxTotalPatients;
      private System.Windows.Forms.Button buttonRecalculateTotalDataStored;
      private System.Windows.Forms.Label labelTotalDataStored;
      private System.Windows.Forms.Label labelTotalImages;
      private System.Windows.Forms.Label labelTotalSeries;
      private System.Windows.Forms.Label labelTotalStudies;
      private System.Windows.Forms.Label labelTotalPatients;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.LinkLabel linkLabelServiceName;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.Label labelUptime;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.LinkLabel linkLabel1;
      private System.Windows.Forms.Label label4;
      private System.Windows.Forms.Label label5;
      private System.Windows.Forms.GroupBox groupBox1;
      private System.Windows.Forms.ListView listViewModules;
      private System.Windows.Forms.ColumnHeader columnName;
      private System.Windows.Forms.ColumnHeader columnVersion;
   }
}
