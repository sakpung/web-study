namespace JobProcessorAdministratorDemo
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
           System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
           System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
           System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
           System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
           System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
           System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
           System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
           this._btnStopNow = new System.Windows.Forms.Button();
           this._btnStart = new System.Windows.Forms.Button();
           this._dgDBJobs = new System.Windows.Forms.DataGridView();
           this._cmJobOptions = new System.Windows.Forms.ContextMenuStrip(this.components);
           this._tsDeleteJob = new System.Windows.Forms.ToolStripMenuItem();
           this._tsResetJob = new System.Windows.Forms.ToolStripMenuItem();
           this._mainMenu = new System.Windows.Forms.MenuStrip();
           this._menuItemFile = new System.Windows.Forms.ToolStripMenuItem();
           this._menuItemExit = new System.Windows.Forms.ToolStripMenuItem();
           this._menuItemHelp = new System.Windows.Forms.ToolStripMenuItem();
           this._menuItemTroubleshooting = new System.Windows.Forms.ToolStripMenuItem();
           this._gbServiceController = new System.Windows.Forms.GroupBox();
           this._btnReloadWorkerList = new System.Windows.Forms.Button();
           this._pbLoadingWorkers = new System.Windows.Forms.ProgressBar();
           this._dgWorkerMachines = new System.Windows.Forms.DataGridView();
           this._clmWorkerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
           this._clmWorkerServiceName = new System.Windows.Forms.DataGridViewTextBoxColumn();
           this._clmWorkerStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
           this._clmWorkerCPUUsage = new System.Windows.Forms.DataGridViewTextBoxColumn();
           this._clmWorkerJobCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
           this._clmWorkerIsRetrieving = new System.Windows.Forms.DataGridViewTextBoxColumn();
           this._clmWorkerIsSending = new System.Windows.Forms.DataGridViewTextBoxColumn();
           this._lblWorkerMachines = new System.Windows.Forms.Label();
           this._gbQueryOptions = new System.Windows.Forms.GroupBox();
           this._btnAnalyzeDB = new System.Windows.Forms.Button();
           this._lblStatus = new System.Windows.Forms.Label();
           this._clbStatus = new System.Windows.Forms.CheckedListBox();
           this._txtGuid = new System.Windows.Forms.TextBox();
           this._cbGuid = new System.Windows.Forms.CheckBox();
           this._cbAddDate = new System.Windows.Forms.CheckBox();
           this._dtAddDate = new System.Windows.Forms.DateTimePicker();
           this._btnCustomQuery = new System.Windows.Forms.Button();
           this._btnDoQuery = new System.Windows.Forms.Button();
           this._lblRowCount = new System.Windows.Forms.Label();
           this._chkAutoRefreshQuery = new System.Windows.Forms.CheckBox();
           ((System.ComponentModel.ISupportInitialize)(this._dgDBJobs)).BeginInit();
           this._cmJobOptions.SuspendLayout();
           this._mainMenu.SuspendLayout();
           this._gbServiceController.SuspendLayout();
           ((System.ComponentModel.ISupportInitialize)(this._dgWorkerMachines)).BeginInit();
           this._gbQueryOptions.SuspendLayout();
           this.SuspendLayout();
           // 
           // _btnStopNow
           // 
           this._btnStopNow.Location = new System.Drawing.Point(655, 275);
           this._btnStopNow.Name = "_btnStopNow";
           this._btnStopNow.Size = new System.Drawing.Size(107, 36);
           this._btnStopNow.TabIndex = 3;
           this._btnStopNow.Text = "Stop";
           this._btnStopNow.UseVisualStyleBackColor = true;
           this._btnStopNow.Click += new System.EventHandler(this._btnStop_Click);
           // 
           // _btnStart
           // 
           this._btnStart.Location = new System.Drawing.Point(655, 232);
           this._btnStart.Name = "_btnStart";
           this._btnStart.Size = new System.Drawing.Size(107, 36);
           this._btnStart.TabIndex = 5;
           this._btnStart.Text = "Start";
           this._btnStart.UseVisualStyleBackColor = true;
           this._btnStart.Click += new System.EventHandler(this._btnStart_Click);
           // 
           // _dgDBJobs
           // 
           this._dgDBJobs.AllowUserToAddRows = false;
           this._dgDBJobs.AllowUserToDeleteRows = false;
           this._dgDBJobs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                       | System.Windows.Forms.AnchorStyles.Left)
                       | System.Windows.Forms.AnchorStyles.Right)));
           this._dgDBJobs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
           dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
           dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
           dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
           dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
           dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
           dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
           dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
           this._dgDBJobs.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
           this._dgDBJobs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
           this._dgDBJobs.ContextMenuStrip = this._cmJobOptions;
           dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
           dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
           dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
           dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
           dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
           dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
           dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
           this._dgDBJobs.DefaultCellStyle = dataGridViewCellStyle2;
           this._dgDBJobs.Location = new System.Drawing.Point(13, 409);
           this._dgDBJobs.Name = "_dgDBJobs";
           this._dgDBJobs.ReadOnly = true;
           dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
           dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
           dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
           dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
           dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
           dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
           dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
           this._dgDBJobs.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
           this._dgDBJobs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
           this._dgDBJobs.Size = new System.Drawing.Size(1158, 295);
           this._dgDBJobs.TabIndex = 9;
           // 
           // _cmJobOptions
           // 
           this._cmJobOptions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._tsDeleteJob,
            this._tsResetJob});
           this._cmJobOptions.Name = "_cmDeleteItem";
           this._cmJobOptions.Size = new System.Drawing.Size(129, 48);
           this._cmJobOptions.Opening += new System.ComponentModel.CancelEventHandler(this._cmJobOptions_Opening);
           // 
           // _tsDeleteJob
           // 
           this._tsDeleteJob.Name = "_tsDeleteJob";
           this._tsDeleteJob.Size = new System.Drawing.Size(128, 22);
           this._tsDeleteJob.Text = "Delete Job";
           this._tsDeleteJob.Click += new System.EventHandler(this._tsDeleteJob_Click);
           // 
           // _tsResetJob
           // 
           this._tsResetJob.Name = "_tsResetJob";
           this._tsResetJob.Size = new System.Drawing.Size(128, 22);
           this._tsResetJob.Text = "Reset Job";
           this._tsResetJob.Click += new System.EventHandler(this._tsResetJob_Click);
           // 
           // _mainMenu
           // 
           this._mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._menuItemFile,
            this._menuItemHelp});
           this._mainMenu.Location = new System.Drawing.Point(0, 0);
           this._mainMenu.Name = "_mainMenu";
           this._mainMenu.Size = new System.Drawing.Size(1183, 24);
           this._mainMenu.TabIndex = 10;
           this._mainMenu.Text = "menuStrip1";
           // 
           // _menuItemFile
           // 
           this._menuItemFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._menuItemExit});
           this._menuItemFile.Name = "_menuItemFile";
           this._menuItemFile.Size = new System.Drawing.Size(37, 20);
           this._menuItemFile.Text = "File";
           // 
           // _menuItemExit
           // 
           this._menuItemExit.Name = "_menuItemExit";
           this._menuItemExit.Size = new System.Drawing.Size(92, 22);
           this._menuItemExit.Text = "Exit";
           this._menuItemExit.Click += new System.EventHandler(this._menuItemExit_Click);
           // 
           // _menuItemHelp
           // 
           this._menuItemHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._menuItemTroubleshooting});
           this._menuItemHelp.Name = "_menuItemHelp";
           this._menuItemHelp.Size = new System.Drawing.Size(44, 20);
           this._menuItemHelp.Text = "Help";
           // 
           // _menuItemTroubleshooting
           // 
           this._menuItemTroubleshooting.Name = "_menuItemTroubleshooting";
           this._menuItemTroubleshooting.Size = new System.Drawing.Size(162, 22);
           this._menuItemTroubleshooting.Text = "Troubleshooting";
           this._menuItemTroubleshooting.Click += new System.EventHandler(this._menuItemTroubleshooting_Click);
           // 
           // _gbServiceController
           // 
           this._gbServiceController.Controls.Add(this._btnReloadWorkerList);
           this._gbServiceController.Controls.Add(this._pbLoadingWorkers);
           this._gbServiceController.Controls.Add(this._dgWorkerMachines);
           this._gbServiceController.Controls.Add(this._lblWorkerMachines);
           this._gbServiceController.Controls.Add(this._btnStopNow);
           this._gbServiceController.Controls.Add(this._btnStart);
           this._gbServiceController.Location = new System.Drawing.Point(13, 27);
           this._gbServiceController.Name = "_gbServiceController";
           this._gbServiceController.Size = new System.Drawing.Size(778, 370);
           this._gbServiceController.TabIndex = 11;
           this._gbServiceController.TabStop = false;
           this._gbServiceController.Text = "Service Controller";
           // 
           // _btnReloadWorkerList
           // 
           this._btnReloadWorkerList.Location = new System.Drawing.Point(655, 317);
           this._btnReloadWorkerList.Name = "_btnReloadWorkerList";
           this._btnReloadWorkerList.Size = new System.Drawing.Size(107, 36);
           this._btnReloadWorkerList.TabIndex = 16;
           this._btnReloadWorkerList.Text = "Reload Worker List";
           this._btnReloadWorkerList.UseVisualStyleBackColor = true;
           this._btnReloadWorkerList.Click += new System.EventHandler(this._btnReloadWorkerList_Click);
           // 
           // _pbLoadingWorkers
           // 
           this._pbLoadingWorkers.Location = new System.Drawing.Point(332, 21);
           this._pbLoadingWorkers.MarqueeAnimationSpeed = 40;
           this._pbLoadingWorkers.Name = "_pbLoadingWorkers";
           this._pbLoadingWorkers.Size = new System.Drawing.Size(303, 26);
           this._pbLoadingWorkers.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
           this._pbLoadingWorkers.TabIndex = 15;
           // 
           // _dgWorkerMachines
           // 
           this._dgWorkerMachines.AllowUserToAddRows = false;
           this._dgWorkerMachines.AllowUserToDeleteRows = false;
           this._dgWorkerMachines.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                       | System.Windows.Forms.AnchorStyles.Left)
                       | System.Windows.Forms.AnchorStyles.Right)));
           dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
           dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
           dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
           dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
           dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
           dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
           dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
           this._dgWorkerMachines.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
           this._dgWorkerMachines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
           this._dgWorkerMachines.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._clmWorkerName,
            this._clmWorkerServiceName,
            this._clmWorkerStatus,
            this._clmWorkerCPUUsage,
            this._clmWorkerJobCount,
            this._clmWorkerIsRetrieving,
            this._clmWorkerIsSending});
           dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
           dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
           dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
           dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
           dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
           dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
           dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
           this._dgWorkerMachines.DefaultCellStyle = dataGridViewCellStyle5;
           this._dgWorkerMachines.Location = new System.Drawing.Point(23, 69);
           this._dgWorkerMachines.Name = "_dgWorkerMachines";
           this._dgWorkerMachines.ReadOnly = true;
           dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
           dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
           dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
           dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
           dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
           dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
           dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
           this._dgWorkerMachines.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
           this._dgWorkerMachines.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
           this._dgWorkerMachines.Size = new System.Drawing.Size(612, 284);
           this._dgWorkerMachines.TabIndex = 14;
           // 
           // _clmWorkerName
           // 
           this._clmWorkerName.DataPropertyName = "_clmWorkerName";
           this._clmWorkerName.HeaderText = "Name";
           this._clmWorkerName.Name = "_clmWorkerName";
           this._clmWorkerName.ReadOnly = true;
           this._clmWorkerName.Width = 114;
           // 
           // _clmWorkerServiceName
           // 
           this._clmWorkerServiceName.DataPropertyName = "_clmWorkerServiceName";
           this._clmWorkerServiceName.HeaderText = "Service Name";
           this._clmWorkerServiceName.Name = "_clmWorkerServiceName";
           this._clmWorkerServiceName.ReadOnly = true;
           this._clmWorkerServiceName.Width = 114;
           // 
           // _clmWorkerStatus
           // 
           this._clmWorkerStatus.DataPropertyName = "_clmWorkerStatus";
           this._clmWorkerStatus.HeaderText = "Status";
           this._clmWorkerStatus.Name = "_clmWorkerStatus";
           this._clmWorkerStatus.ReadOnly = true;
           this._clmWorkerStatus.Width = 113;
           // 
           // _clmWorkerCPUUsage
           // 
           this._clmWorkerCPUUsage.DataPropertyName = "_clmWorkerCPUUsage";
           this._clmWorkerCPUUsage.HeaderText = "CPU Usage";
           this._clmWorkerCPUUsage.Name = "_clmWorkerCPUUsage";
           this._clmWorkerCPUUsage.ReadOnly = true;
           this._clmWorkerCPUUsage.Width = 114;
           // 
           // _clmWorkerJobCount
           // 
           this._clmWorkerJobCount.DataPropertyName = "_clmWorkerJobCount";
           this._clmWorkerJobCount.HeaderText = "Total Job Count";
           this._clmWorkerJobCount.Name = "_clmWorkerJobCount";
           this._clmWorkerJobCount.ReadOnly = true;
           this._clmWorkerJobCount.Width = 114;
           // 
           // _clmWorkerIsRetrieving
           // 
           this._clmWorkerIsRetrieving.DataPropertyName = "_clmWorkerIsRetrieving";
           this._clmWorkerIsRetrieving.HeaderText = "IsRetrieving";
           this._clmWorkerIsRetrieving.Name = "_clmWorkerIsRetrieving";
           this._clmWorkerIsRetrieving.ReadOnly = true;
           this._clmWorkerIsRetrieving.Visible = false;
           // 
           // _clmWorkerIsSending
           // 
           this._clmWorkerIsSending.DataPropertyName = "_clmWorkerIsSending";
           this._clmWorkerIsSending.HeaderText = "IsSending";
           this._clmWorkerIsSending.Name = "_clmWorkerIsSending";
           this._clmWorkerIsSending.ReadOnly = true;
           this._clmWorkerIsSending.Visible = false;
           // 
           // _lblWorkerMachines
           // 
           this._lblWorkerMachines.AutoSize = true;
           this._lblWorkerMachines.Location = new System.Drawing.Point(20, 34);
           this._lblWorkerMachines.Name = "_lblWorkerMachines";
           this._lblWorkerMachines.Size = new System.Drawing.Size(91, 13);
           this._lblWorkerMachines.TabIndex = 13;
           this._lblWorkerMachines.Text = "Worker Machines";
           // 
           // _gbQueryOptions
           // 
           this._gbQueryOptions.Controls.Add(this._chkAutoRefreshQuery);
           this._gbQueryOptions.Controls.Add(this._btnAnalyzeDB);
           this._gbQueryOptions.Controls.Add(this._lblStatus);
           this._gbQueryOptions.Controls.Add(this._clbStatus);
           this._gbQueryOptions.Controls.Add(this._txtGuid);
           this._gbQueryOptions.Controls.Add(this._cbGuid);
           this._gbQueryOptions.Controls.Add(this._cbAddDate);
           this._gbQueryOptions.Controls.Add(this._dtAddDate);
           this._gbQueryOptions.Controls.Add(this._btnCustomQuery);
           this._gbQueryOptions.Controls.Add(this._btnDoQuery);
           this._gbQueryOptions.Location = new System.Drawing.Point(815, 27);
           this._gbQueryOptions.Name = "_gbQueryOptions";
           this._gbQueryOptions.Size = new System.Drawing.Size(356, 370);
           this._gbQueryOptions.TabIndex = 12;
           this._gbQueryOptions.TabStop = false;
           this._gbQueryOptions.Text = "Query Options";
           // 
           // _btnAnalyzeDB
           // 
           this._btnAnalyzeDB.Location = new System.Drawing.Point(225, 317);
           this._btnAnalyzeDB.Name = "_btnAnalyzeDB";
           this._btnAnalyzeDB.Size = new System.Drawing.Size(107, 36);
           this._btnAnalyzeDB.TabIndex = 22;
           this._btnAnalyzeDB.Text = "Analyze Database";
           this._btnAnalyzeDB.UseVisualStyleBackColor = true;
           this._btnAnalyzeDB.Click += new System.EventHandler(this._btnAnalyzeDB_Click);
           // 
           // _lblStatus
           // 
           this._lblStatus.AutoSize = true;
           this._lblStatus.Location = new System.Drawing.Point(13, 155);
           this._lblStatus.Name = "_lblStatus";
           this._lblStatus.Size = new System.Drawing.Size(37, 13);
           this._lblStatus.TabIndex = 21;
           this._lblStatus.Text = "Status";
           // 
           // _clbStatus
           // 
           this._clbStatus.CheckOnClick = true;
           this._clbStatus.FormattingEnabled = true;
           this._clbStatus.Location = new System.Drawing.Point(16, 186);
           this._clbStatus.Name = "_clbStatus";
           this._clbStatus.Size = new System.Drawing.Size(190, 169);
           this._clbStatus.TabIndex = 20;
           // 
           // _txtGuid
           // 
           this._txtGuid.Location = new System.Drawing.Point(16, 52);
           this._txtGuid.Name = "_txtGuid";
           this._txtGuid.Size = new System.Drawing.Size(190, 20);
           this._txtGuid.TabIndex = 19;
           // 
           // _cbGuid
           // 
           this._cbGuid.AutoSize = true;
           this._cbGuid.Location = new System.Drawing.Point(16, 29);
           this._cbGuid.Name = "_cbGuid";
           this._cbGuid.Size = new System.Drawing.Size(73, 17);
           this._cbGuid.TabIndex = 18;
           this._cbGuid.Text = "ID (GUID)";
           this._cbGuid.UseVisualStyleBackColor = true;
           this._cbGuid.CheckedChanged += new System.EventHandler(this._cbGuid_CheckedChanged);
           // 
           // _cbAddDate
           // 
           this._cbAddDate.AutoSize = true;
           this._cbAddDate.Location = new System.Drawing.Point(16, 93);
           this._cbAddDate.Name = "_cbAddDate";
           this._cbAddDate.Size = new System.Drawing.Size(71, 17);
           this._cbAddDate.TabIndex = 16;
           this._cbAddDate.Text = "Add Date";
           this._cbAddDate.UseVisualStyleBackColor = true;
           this._cbAddDate.CheckedChanged += new System.EventHandler(this._cbAddDate_CheckedChanged);
           // 
           // _dtAddDate
           // 
           this._dtAddDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
           this._dtAddDate.Location = new System.Drawing.Point(16, 116);
           this._dtAddDate.Name = "_dtAddDate";
           this._dtAddDate.Size = new System.Drawing.Size(190, 20);
           this._dtAddDate.TabIndex = 12;
           // 
           // _btnCustomQuery
           // 
           this._btnCustomQuery.Location = new System.Drawing.Point(225, 270);
           this._btnCustomQuery.Name = "_btnCustomQuery";
           this._btnCustomQuery.Size = new System.Drawing.Size(107, 36);
           this._btnCustomQuery.TabIndex = 7;
           this._btnCustomQuery.Text = "Custom Query";
           this._btnCustomQuery.UseVisualStyleBackColor = true;
           this._btnCustomQuery.Click += new System.EventHandler(this._btnCustomQuery_Click);
           // 
           // _btnDoQuery
           // 
           this._btnDoQuery.Location = new System.Drawing.Point(225, 222);
           this._btnDoQuery.Name = "_btnDoQuery";
           this._btnDoQuery.Size = new System.Drawing.Size(107, 36);
           this._btnDoQuery.TabIndex = 4;
           this._btnDoQuery.Text = "Do Query";
           this._btnDoQuery.UseVisualStyleBackColor = true;
           this._btnDoQuery.Click += new System.EventHandler(this._btnDoQuery_Click);
           // 
           // _lblRowCount
           // 
           this._lblRowCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
           this._lblRowCount.AutoSize = true;
           this._lblRowCount.Location = new System.Drawing.Point(12, 720);
           this._lblRowCount.Name = "_lblRowCount";
           this._lblRowCount.Size = new System.Drawing.Size(0, 13);
           this._lblRowCount.TabIndex = 13;
           // 
           // _chkAutoRefreshQuery
           // 
           this._chkAutoRefreshQuery.AutoSize = true;
           this._chkAutoRefreshQuery.Location = new System.Drawing.Point(225, 186);
           this._chkAutoRefreshQuery.Name = "_chkAutoRefreshQuery";
           this._chkAutoRefreshQuery.Size = new System.Drawing.Size(119, 17);
           this._chkAutoRefreshQuery.TabIndex = 23;
           this._chkAutoRefreshQuery.Text = "Auto Refresh Query";
           this._chkAutoRefreshQuery.UseVisualStyleBackColor = true;
           this._chkAutoRefreshQuery.CheckedChanged += new System.EventHandler(this._chkAutoRefreshQuery_CheckedChanged);
           // 
           // MainForm
           // 
           this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
           this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
           this.ClientSize = new System.Drawing.Size(1183, 742);
           this.Controls.Add(this._lblRowCount);
           this.Controls.Add(this._dgDBJobs);
           this.Controls.Add(this._gbServiceController);
           this.Controls.Add(this._mainMenu);
           this.Controls.Add(this._gbQueryOptions);
           this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
           this.MainMenuStrip = this._mainMenu;
           this.MinimumSize = new System.Drawing.Size(806, 726);
           this.Name = "MainForm";
           this.Text = "LEADTOOLS JobProcessor Administrator Utility";
           this.Load += new System.EventHandler(this.MainForm_Load);
           this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
           ((System.ComponentModel.ISupportInitialize)(this._dgDBJobs)).EndInit();
           this._cmJobOptions.ResumeLayout(false);
           this._mainMenu.ResumeLayout(false);
           this._mainMenu.PerformLayout();
           this._gbServiceController.ResumeLayout(false);
           this._gbServiceController.PerformLayout();
           ((System.ComponentModel.ISupportInitialize)(this._dgWorkerMachines)).EndInit();
           this._gbQueryOptions.ResumeLayout(false);
           this._gbQueryOptions.PerformLayout();
           this.ResumeLayout(false);
           this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _btnStopNow;
        private System.Windows.Forms.Button _btnStart;
        private System.Windows.Forms.DataGridView _dgDBJobs;
        private System.Windows.Forms.MenuStrip _mainMenu;
        private System.Windows.Forms.ToolStripMenuItem _menuItemFile;
        private System.Windows.Forms.ToolStripMenuItem _menuItemExit;
        private System.Windows.Forms.GroupBox _gbServiceController;
        private System.Windows.Forms.GroupBox _gbQueryOptions;
        private System.Windows.Forms.Button _btnCustomQuery;
        private System.Windows.Forms.Button _btnDoQuery;
        private System.Windows.Forms.DateTimePicker _dtAddDate;
        private System.Windows.Forms.CheckBox _cbAddDate;
       private System.Windows.Forms.Label _lblWorkerMachines;
       private System.Windows.Forms.TextBox _txtGuid;
       private System.Windows.Forms.CheckBox _cbGuid;
       private System.Windows.Forms.CheckedListBox _clbStatus;
       private System.Windows.Forms.Label _lblRowCount;
       private System.Windows.Forms.Label _lblStatus;
       private System.Windows.Forms.ContextMenuStrip _cmJobOptions;
       private System.Windows.Forms.ToolStripMenuItem _tsDeleteJob;
       private System.Windows.Forms.ToolStripMenuItem _tsResetJob;
       private System.Windows.Forms.ToolStripMenuItem _menuItemHelp;
       private System.Windows.Forms.ToolStripMenuItem _menuItemTroubleshooting;
       private System.Windows.Forms.DataGridView _dgWorkerMachines;
       private System.Windows.Forms.DataGridViewTextBoxColumn _clmWorkerName;
       private System.Windows.Forms.DataGridViewTextBoxColumn _clmWorkerServiceName;
       private System.Windows.Forms.DataGridViewTextBoxColumn _clmWorkerStatus;
       private System.Windows.Forms.DataGridViewTextBoxColumn _clmWorkerCPUUsage;
       private System.Windows.Forms.DataGridViewTextBoxColumn _clmWorkerJobCount;
       private System.Windows.Forms.DataGridViewTextBoxColumn _clmWorkerIsRetrieving;
       private System.Windows.Forms.DataGridViewTextBoxColumn _clmWorkerIsSending;
       private System.Windows.Forms.Button _btnAnalyzeDB;
       private System.Windows.Forms.ProgressBar _pbLoadingWorkers;
       private System.Windows.Forms.Button _btnReloadWorkerList;
       private System.Windows.Forms.CheckBox _chkAutoRefreshQuery;

    }
}

