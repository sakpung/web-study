namespace Leadtools.Dicom.Server.Manager.Dialogs
{
    partial class EventLogDialog
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EventLogDialog));
         this.listViewEventLog = new System.Windows.Forms.ListView();
         this.columnServerAeTitle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this.columnIpAddress = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this.columnServerPort = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this.columnClientAeTitle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this.columnClientHostAddress = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this.columnClientPort = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this.columnCommand = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this.columnEventDateTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this.columnMessageDirection = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this.columnDescription = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this.columnDatasetPath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this.buttonQuery = new System.Windows.Forms.Button();
         this.buttonDeleteAll = new System.Windows.Forms.Button();
         this.checkBoxLastLogs = new System.Windows.Forms.CheckBox();
         this.numericUpDownLastLogs = new System.Windows.Forms.NumericUpDown();
         this.labelLastLogs = new System.Windows.Forms.Label();
         this.textBoxServerAeTitle = new System.Windows.Forms.TextBox();
         this.checkBoxServerAeTitle = new System.Windows.Forms.CheckBox();
         this.checkBoxClientAeTitle = new System.Windows.Forms.CheckBox();
         this.textBoxClientAeTitle = new System.Windows.Forms.TextBox();
         this.buttonDeleteSelected = new System.Windows.Forms.Button();
         this.buttonDetail = new System.Windows.Forms.Button();
         this.groupBoxQueryOptions = new System.Windows.Forms.GroupBox();
         this.buttonClose = new System.Windows.Forms.Button();
         this.checkBoxEnableLogging = new System.Windows.Forms.CheckBox();
         this.checkBoxLogDatasets = new System.Windows.Forms.CheckBox();
         ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLastLogs)).BeginInit();
         this.groupBoxQueryOptions.SuspendLayout();
         this.SuspendLayout();
         // 
         // listViewEventLog
         // 
         this.listViewEventLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.listViewEventLog.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnServerAeTitle,
            this.columnIpAddress,
            this.columnServerPort,
            this.columnClientAeTitle,
            this.columnClientHostAddress,
            this.columnClientPort,
            this.columnCommand,
            this.columnEventDateTime,
            this.columnMessageDirection,
            this.columnDescription,
            this.columnDatasetPath});
         this.listViewEventLog.FullRowSelect = true;
         this.listViewEventLog.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
         this.listViewEventLog.HideSelection = false;
         this.listViewEventLog.Location = new System.Drawing.Point(2, 2);
         this.listViewEventLog.Name = "listViewEventLog";
         this.listViewEventLog.Size = new System.Drawing.Size(736, 407);
         this.listViewEventLog.TabIndex = 0;
         this.listViewEventLog.UseCompatibleStateImageBehavior = false;
         this.listViewEventLog.View = System.Windows.Forms.View.Details;
         this.listViewEventLog.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listViewEventLog_ItemSelectionChanged);
         this.listViewEventLog.DoubleClick += new System.EventHandler(this.listViewEventLog_DoubleClick);
         // 
         // columnServerAeTitle
         // 
         this.columnServerAeTitle.Text = "Server AE Title";
         this.columnServerAeTitle.Width = 84;
         // 
         // columnIpAddress
         // 
         this.columnIpAddress.Text = "IP Address";
         // 
         // columnServerPort
         // 
         this.columnServerPort.Text = "Server Port";
         // 
         // columnClientAeTitle
         // 
         this.columnClientAeTitle.Text = "Client AE Title";
         // 
         // columnClientHostAddress
         // 
         this.columnClientHostAddress.Text = "Client Host Address";
         // 
         // columnClientPort
         // 
         this.columnClientPort.Text = "Client Port";
         // 
         // columnCommand
         // 
         this.columnCommand.Text = "Command";
         // 
         // columnEventDateTime
         // 
         this.columnEventDateTime.Text = "Event Date Time";
         // 
         // columnMessageDirection
         // 
         this.columnMessageDirection.Text = "MessageDirection";
         // 
         // columnDescription
         // 
         this.columnDescription.Text = "Description";
         // 
         // columnDatasetPath
         // 
         this.columnDatasetPath.Text = "Dataset Path";
         // 
         // buttonQuery
         // 
         this.buttonQuery.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.buttonQuery.Location = new System.Drawing.Point(300, 497);
         this.buttonQuery.Name = "buttonQuery";
         this.buttonQuery.Size = new System.Drawing.Size(75, 23);
         this.buttonQuery.TabIndex = 4;
         this.buttonQuery.Text = "Query";
         this.buttonQuery.UseVisualStyleBackColor = true;
         this.buttonQuery.Click += new System.EventHandler(this.buttonQuery_Click);
         // 
         // buttonDeleteAll
         // 
         this.buttonDeleteAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.buttonDeleteAll.Location = new System.Drawing.Point(573, 497);
         this.buttonDeleteAll.Name = "buttonDeleteAll";
         this.buttonDeleteAll.Size = new System.Drawing.Size(75, 23);
         this.buttonDeleteAll.TabIndex = 7;
         this.buttonDeleteAll.Text = "Delete All...";
         this.buttonDeleteAll.UseVisualStyleBackColor = true;
         this.buttonDeleteAll.Click += new System.EventHandler(this.buttonClear_Click);
         // 
         // checkBoxLastLogs
         // 
         this.checkBoxLastLogs.AutoSize = true;
         this.checkBoxLastLogs.Location = new System.Drawing.Point(12, 20);
         this.checkBoxLastLogs.Name = "checkBoxLastLogs";
         this.checkBoxLastLogs.Size = new System.Drawing.Size(46, 17);
         this.checkBoxLastLogs.TabIndex = 0;
         this.checkBoxLastLogs.Text = "Last";
         this.checkBoxLastLogs.UseVisualStyleBackColor = true;
         this.checkBoxLastLogs.CheckedChanged += new System.EventHandler(this.checkBoxLastLogs_CheckedChanged);
         // 
         // numericUpDownLastLogs
         // 
         this.numericUpDownLastLogs.Location = new System.Drawing.Point(116, 18);
         this.numericUpDownLastLogs.Name = "numericUpDownLastLogs";
         this.numericUpDownLastLogs.Size = new System.Drawing.Size(74, 20);
         this.numericUpDownLastLogs.TabIndex = 1;
         // 
         // labelLastLogs
         // 
         this.labelLastLogs.AutoSize = true;
         this.labelLastLogs.Location = new System.Drawing.Point(196, 22);
         this.labelLastLogs.Name = "labelLastLogs";
         this.labelLastLogs.Size = new System.Drawing.Size(36, 13);
         this.labelLastLogs.TabIndex = 2;
         this.labelLastLogs.Text = "Log(s)";
         // 
         // textBoxServerAeTitle
         // 
         this.textBoxServerAeTitle.Location = new System.Drawing.Point(116, 41);
         this.textBoxServerAeTitle.Name = "textBoxServerAeTitle";
         this.textBoxServerAeTitle.Size = new System.Drawing.Size(121, 20);
         this.textBoxServerAeTitle.TabIndex = 4;
         // 
         // checkBoxServerAeTitle
         // 
         this.checkBoxServerAeTitle.AutoSize = true;
         this.checkBoxServerAeTitle.Location = new System.Drawing.Point(12, 43);
         this.checkBoxServerAeTitle.Name = "checkBoxServerAeTitle";
         this.checkBoxServerAeTitle.Size = new System.Drawing.Size(97, 17);
         this.checkBoxServerAeTitle.TabIndex = 3;
         this.checkBoxServerAeTitle.Text = "Server AE Title";
         this.checkBoxServerAeTitle.UseVisualStyleBackColor = true;
         this.checkBoxServerAeTitle.CheckedChanged += new System.EventHandler(this.checkBoxServerAeTitle_CheckedChanged);
         // 
         // checkBoxClientAeTitle
         // 
         this.checkBoxClientAeTitle.AutoSize = true;
         this.checkBoxClientAeTitle.Location = new System.Drawing.Point(12, 66);
         this.checkBoxClientAeTitle.Name = "checkBoxClientAeTitle";
         this.checkBoxClientAeTitle.Size = new System.Drawing.Size(92, 17);
         this.checkBoxClientAeTitle.TabIndex = 5;
         this.checkBoxClientAeTitle.Text = "Client AE Title";
         this.checkBoxClientAeTitle.UseVisualStyleBackColor = true;
         this.checkBoxClientAeTitle.CheckedChanged += new System.EventHandler(this.checkBoxClientAeTitle_CheckedChanged);
         // 
         // textBoxClientAeTitle
         // 
         this.textBoxClientAeTitle.Location = new System.Drawing.Point(116, 64);
         this.textBoxClientAeTitle.Name = "textBoxClientAeTitle";
         this.textBoxClientAeTitle.Size = new System.Drawing.Size(120, 20);
         this.textBoxClientAeTitle.TabIndex = 6;
         // 
         // buttonDeleteSelected
         // 
         this.buttonDeleteSelected.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.buttonDeleteSelected.Location = new System.Drawing.Point(462, 497);
         this.buttonDeleteSelected.Name = "buttonDeleteSelected";
         this.buttonDeleteSelected.Size = new System.Drawing.Size(105, 23);
         this.buttonDeleteSelected.TabIndex = 6;
         this.buttonDeleteSelected.Text = "Delete Selected...";
         this.buttonDeleteSelected.UseVisualStyleBackColor = true;
         this.buttonDeleteSelected.Click += new System.EventHandler(this.buttonDeleteSelected_Click);
         // 
         // buttonDetail
         // 
         this.buttonDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.buttonDetail.Location = new System.Drawing.Point(381, 497);
         this.buttonDetail.Name = "buttonDetail";
         this.buttonDetail.Size = new System.Drawing.Size(75, 23);
         this.buttonDetail.TabIndex = 5;
         this.buttonDetail.Text = "Detail...";
         this.buttonDetail.UseVisualStyleBackColor = true;
         this.buttonDetail.Click += new System.EventHandler(this.buttonDetail_Click);
         // 
         // groupBoxQueryOptions
         // 
         this.groupBoxQueryOptions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
         this.groupBoxQueryOptions.Controls.Add(this.textBoxClientAeTitle);
         this.groupBoxQueryOptions.Controls.Add(this.checkBoxLastLogs);
         this.groupBoxQueryOptions.Controls.Add(this.numericUpDownLastLogs);
         this.groupBoxQueryOptions.Controls.Add(this.labelLastLogs);
         this.groupBoxQueryOptions.Controls.Add(this.checkBoxClientAeTitle);
         this.groupBoxQueryOptions.Controls.Add(this.textBoxServerAeTitle);
         this.groupBoxQueryOptions.Controls.Add(this.checkBoxServerAeTitle);
         this.groupBoxQueryOptions.Location = new System.Drawing.Point(12, 426);
         this.groupBoxQueryOptions.Name = "groupBoxQueryOptions";
         this.groupBoxQueryOptions.Size = new System.Drawing.Size(248, 94);
         this.groupBoxQueryOptions.TabIndex = 1;
         this.groupBoxQueryOptions.TabStop = false;
         this.groupBoxQueryOptions.Text = "Query Options";
         // 
         // buttonClose
         // 
         this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.buttonClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.buttonClose.Location = new System.Drawing.Point(654, 497);
         this.buttonClose.Name = "buttonClose";
         this.buttonClose.Size = new System.Drawing.Size(75, 23);
         this.buttonClose.TabIndex = 8;
         this.buttonClose.Text = "Close";
         this.buttonClose.UseVisualStyleBackColor = true;
         this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
         // 
         // checkBoxEnableLogging
         // 
         this.checkBoxEnableLogging.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
         this.checkBoxEnableLogging.AutoSize = true;
         this.checkBoxEnableLogging.Location = new System.Drawing.Point(300, 446);
         this.checkBoxEnableLogging.Name = "checkBoxEnableLogging";
         this.checkBoxEnableLogging.Size = new System.Drawing.Size(100, 17);
         this.checkBoxEnableLogging.TabIndex = 2;
         this.checkBoxEnableLogging.Text = "Enable Logging";
         this.checkBoxEnableLogging.UseVisualStyleBackColor = true;
         this.checkBoxEnableLogging.CheckedChanged += new System.EventHandler(this.checkBoxEnableLogging_CheckedChanged);
         // 
         // checkBoxLogDatasets
         // 
         this.checkBoxLogDatasets.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
         this.checkBoxLogDatasets.AutoSize = true;
         this.checkBoxLogDatasets.Location = new System.Drawing.Point(300, 467);
         this.checkBoxLogDatasets.Name = "checkBoxLogDatasets";
         this.checkBoxLogDatasets.Size = new System.Drawing.Size(164, 17);
         this.checkBoxLogDatasets.TabIndex = 3;
         this.checkBoxLogDatasets.Text = "Log Communication Datasets";
         this.checkBoxLogDatasets.UseVisualStyleBackColor = true;
         this.checkBoxLogDatasets.CheckedChanged += new System.EventHandler(this.checkBoxLogDatasets_CheckedChanged);
         // 
         // EventLogDialog
         // 
         this.AcceptButton = this.buttonClose;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this.buttonClose;
         this.ClientSize = new System.Drawing.Size(741, 527);
         this.Controls.Add(this.checkBoxLogDatasets);
         this.Controls.Add(this.checkBoxEnableLogging);
         this.Controls.Add(this.buttonClose);
         this.Controls.Add(this.groupBoxQueryOptions);
         this.Controls.Add(this.buttonDetail);
         this.Controls.Add(this.buttonDeleteSelected);
         this.Controls.Add(this.buttonDeleteAll);
         this.Controls.Add(this.buttonQuery);
         this.Controls.Add(this.listViewEventLog);
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.MinimizeBox = false;
         this.Name = "EventLogDialog";
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Event Log";
         this.Load += new System.EventHandler(this.EventLogDialog_Load);
         ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLastLogs)).EndInit();
         this.groupBoxQueryOptions.ResumeLayout(false);
         this.groupBoxQueryOptions.PerformLayout();
         this.ResumeLayout(false);
         this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listViewEventLog;
        private System.Windows.Forms.ColumnHeader columnServerAeTitle;
        private System.Windows.Forms.ColumnHeader columnIpAddress;
        private System.Windows.Forms.ColumnHeader columnServerPort;
        private System.Windows.Forms.ColumnHeader columnClientAeTitle;
        private System.Windows.Forms.ColumnHeader columnClientHostAddress;
        private System.Windows.Forms.ColumnHeader columnClientPort;
        private System.Windows.Forms.ColumnHeader columnCommand;
        private System.Windows.Forms.ColumnHeader columnEventDateTime;
        private System.Windows.Forms.ColumnHeader columnMessageDirection;
        private System.Windows.Forms.ColumnHeader columnDescription;
        private System.Windows.Forms.Button buttonQuery;
        private System.Windows.Forms.Button buttonDeleteAll;
        private System.Windows.Forms.CheckBox checkBoxLastLogs;
        private System.Windows.Forms.NumericUpDown numericUpDownLastLogs;
        private System.Windows.Forms.Label labelLastLogs;
        private System.Windows.Forms.TextBox textBoxServerAeTitle;
        private System.Windows.Forms.CheckBox checkBoxServerAeTitle;
        private System.Windows.Forms.CheckBox checkBoxClientAeTitle;
        private System.Windows.Forms.TextBox textBoxClientAeTitle;
        private System.Windows.Forms.Button buttonDeleteSelected;
        private System.Windows.Forms.Button buttonDetail;
        private System.Windows.Forms.GroupBox groupBoxQueryOptions;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.ColumnHeader columnDatasetPath;
        private System.Windows.Forms.CheckBox checkBoxEnableLogging;
        private System.Windows.Forms.CheckBox checkBoxLogDatasets;

    }
}