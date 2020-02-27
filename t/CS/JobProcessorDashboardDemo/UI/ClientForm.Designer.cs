namespace JobProcessorDashboardDemo
{
   partial class ClientForm
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
         if (disposing)
         {
            if (components != null)
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClientForm));
         this.splitContainer1 = new System.Windows.Forms.SplitContainer();
         this._lblJobCount = new System.Windows.Forms.Label();
         this._chkAutoRefreshJobs = new System.Windows.Forms.CheckBox();
         this._btnRefreshJobs = new System.Windows.Forms.Button();
         this._btnChangeUsername = new System.Windows.Forms.Button();
         this._lblUsername = new System.Windows.Forms.Label();
         this._tcJobTypes = new System.Windows.Forms.TabControl();
         this._tpOCR = new System.Windows.Forms.TabPage();
         this._btnOCRAddJob = new System.Windows.Forms.Button();
         this._lblOCRFormat = new System.Windows.Forms.Label();
         this._cmbOCRFormat = new System.Windows.Forms.ComboBox();
         this._lblOCRDestFile = new System.Windows.Forms.Label();
         this._tpMultimedia = new System.Windows.Forms.TabPage();
         this._btnMMLoadProfiles = new System.Windows.Forms.Button();
         this._btnMMAddJob = new System.Windows.Forms.Button();
         this._lblMMConversionProfile = new System.Windows.Forms.Label();
         this._cmbMMConversionProfile = new System.Windows.Forms.ComboBox();
         this._lblMMDestFile = new System.Windows.Forms.Label();
         this._dgvJobs = new System.Windows.Forms.DataGridView();
         this._cmJobs = new System.Windows.Forms.ContextMenuStrip(this.components);
         this._menuItemDeleteJob = new System.Windows.Forms.ToolStripMenuItem();
         this._menuItemAbortJob = new System.Windows.Forms.ToolStripMenuItem();
         this._menuItemResetJob = new System.Windows.Forms.ToolStripMenuItem();
         this._menuItemOpenConvertedFile = new System.Windows.Forms.ToolStripMenuItem();
         this.splitContainer1.Panel1.SuspendLayout();
         this.splitContainer1.Panel2.SuspendLayout();
         this.splitContainer1.SuspendLayout();
         this._tcJobTypes.SuspendLayout();
         this._tpOCR.SuspendLayout();
         this._tpMultimedia.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this._dgvJobs)).BeginInit();
         this._cmJobs.SuspendLayout();
         this.SuspendLayout();
         // 
         // splitContainer1
         // 
         this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
         this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
         this.splitContainer1.IsSplitterFixed = true;
         this.splitContainer1.Location = new System.Drawing.Point(0, 0);
         this.splitContainer1.Name = "splitContainer1";
         this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
         // 
         // splitContainer1.Panel1
         // 
         this.splitContainer1.Panel1.Controls.Add(this._lblJobCount);
         this.splitContainer1.Panel1.Controls.Add(this._chkAutoRefreshJobs);
         this.splitContainer1.Panel1.Controls.Add(this._btnRefreshJobs);
         this.splitContainer1.Panel1.Controls.Add(this._btnChangeUsername);
         this.splitContainer1.Panel1.Controls.Add(this._lblUsername);
         this.splitContainer1.Panel1.Controls.Add(this._tcJobTypes);
         // 
         // splitContainer1.Panel2
         // 
         this.splitContainer1.Panel2.Controls.Add(this._dgvJobs);
         this.splitContainer1.Size = new System.Drawing.Size(990, 573);
         this.splitContainer1.SplitterDistance = 315;
         this.splitContainer1.TabIndex = 0;
         // 
         // _lblJobCount
         // 
         this._lblJobCount.AutoSize = true;
         this._lblJobCount.Location = new System.Drawing.Point(33, 276);
         this._lblJobCount.Name = "_lblJobCount";
         this._lblJobCount.Size = new System.Drawing.Size(52, 13);
         this._lblJobCount.TabIndex = 15;
         this._lblJobCount.Text = "JobCount";
         // 
         // _chkAutoRefreshJobs
         // 
         this._chkAutoRefreshJobs.AutoSize = true;
         this._chkAutoRefreshJobs.Location = new System.Drawing.Point(445, 181);
         this._chkAutoRefreshJobs.Name = "_chkAutoRefreshJobs";
         this._chkAutoRefreshJobs.Size = new System.Drawing.Size(113, 17);
         this._chkAutoRefreshJobs.TabIndex = 14;
         this._chkAutoRefreshJobs.Text = "Auto Refresh Jobs";
         this._chkAutoRefreshJobs.UseVisualStyleBackColor = true;
         this._chkAutoRefreshJobs.CheckedChanged += new System.EventHandler(this._chkAutoRefreshJobs_CheckedChanged);
         // 
         // _btnRefreshJobs
         // 
         this._btnRefreshJobs.Location = new System.Drawing.Point(445, 214);
         this._btnRefreshJobs.Name = "_btnRefreshJobs";
         this._btnRefreshJobs.Size = new System.Drawing.Size(112, 34);
         this._btnRefreshJobs.TabIndex = 13;
         this._btnRefreshJobs.Text = "Refresh Jobs";
         this._btnRefreshJobs.UseVisualStyleBackColor = true;
         this._btnRefreshJobs.Click += new System.EventHandler(this._btnRefreshJobs_Click);
         // 
         // _btnChangeUsername
         // 
         this._btnChangeUsername.Location = new System.Drawing.Point(594, 214);
         this._btnChangeUsername.Name = "_btnChangeUsername";
         this._btnChangeUsername.Size = new System.Drawing.Size(112, 34);
         this._btnChangeUsername.TabIndex = 12;
         this._btnChangeUsername.Text = "Change Username";
         this._btnChangeUsername.UseVisualStyleBackColor = true;
         this._btnChangeUsername.Click += new System.EventHandler(this._btnChangeUsername_Click);
         // 
         // _lblUsername
         // 
         this._lblUsername.AutoSize = true;
         this._lblUsername.Location = new System.Drawing.Point(591, 182);
         this._lblUsername.Name = "_lblUsername";
         this._lblUsername.Size = new System.Drawing.Size(55, 13);
         this._lblUsername.TabIndex = 4;
         this._lblUsername.Text = "Username";
         // 
         // _tcJobTypes
         // 
         this._tcJobTypes.Controls.Add(this._tpOCR);
         this._tcJobTypes.Controls.Add(this._tpMultimedia);
         this._tcJobTypes.Location = new System.Drawing.Point(32, 25);
         this._tcJobTypes.Name = "_tcJobTypes";
         this._tcJobTypes.SelectedIndex = 0;
         this._tcJobTypes.Size = new System.Drawing.Size(374, 223);
         this._tcJobTypes.TabIndex = 3;
         // 
         // _tpOCR
         // 
         this._tpOCR.Controls.Add(this._btnOCRAddJob);
         this._tpOCR.Controls.Add(this._lblOCRFormat);
         this._tpOCR.Controls.Add(this._cmbOCRFormat);
         this._tpOCR.Controls.Add(this._lblOCRDestFile);
         this._tpOCR.Location = new System.Drawing.Point(4, 22);
         this._tpOCR.Name = "_tpOCR";
         this._tpOCR.Padding = new System.Windows.Forms.Padding(3);
         this._tpOCR.Size = new System.Drawing.Size(366, 197);
         this._tpOCR.TabIndex = 0;
         this._tpOCR.Text = "OCR";
         this._tpOCR.UseVisualStyleBackColor = true;
         // 
         // _btnOCRAddJob
         // 
         this._btnOCRAddJob.Location = new System.Drawing.Point(19, 91);
         this._btnOCRAddJob.Name = "_btnOCRAddJob";
         this._btnOCRAddJob.Size = new System.Drawing.Size(290, 34);
         this._btnOCRAddJob.TabIndex = 5;
         this._btnOCRAddJob.Text = "Add Job(s)";
         this._btnOCRAddJob.UseVisualStyleBackColor = true;
         this._btnOCRAddJob.Click += new System.EventHandler(this._btnOCRAddJob_Click);
         // 
         // _lblOCRFormat
         // 
         this._lblOCRFormat.AutoSize = true;
         this._lblOCRFormat.Location = new System.Drawing.Point(16, 19);
         this._lblOCRFormat.Name = "_lblOCRFormat";
         this._lblOCRFormat.Size = new System.Drawing.Size(91, 13);
         this._lblOCRFormat.TabIndex = 4;
         this._lblOCRFormat.Text = "Document Format";
         // 
         // _cmbOCRFormat
         // 
         this._cmbOCRFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._cmbOCRFormat.FormattingEnabled = true;
         this._cmbOCRFormat.Items.AddRange(new object[] {
            "Pdf",
            "Doc",
            "Rtf",
            "Html",
            "Text",
            "Emf",
            "Xps",
            "Docx",
            "Xls"});
         this._cmbOCRFormat.Location = new System.Drawing.Point(19, 48);
         this._cmbOCRFormat.Name = "_cmbOCRFormat";
         this._cmbOCRFormat.Size = new System.Drawing.Size(290, 21);
         this._cmbOCRFormat.TabIndex = 3;
         // 
         // _lblOCRDestFile
         // 
         this._lblOCRDestFile.AutoSize = true;
         this._lblOCRDestFile.Location = new System.Drawing.Point(16, 158);
         this._lblOCRDestFile.Name = "_lblOCRDestFile";
         this._lblOCRDestFile.Size = new System.Drawing.Size(267, 13);
         this._lblOCRDestFile.TabIndex = 1;
         this._lblOCRDestFile.Text = "Converted files will be placed in the source file directory";
         // 
         // _tpMultimedia
         // 
         this._tpMultimedia.Controls.Add(this._btnMMLoadProfiles);
         this._tpMultimedia.Controls.Add(this._btnMMAddJob);
         this._tpMultimedia.Controls.Add(this._lblMMConversionProfile);
         this._tpMultimedia.Controls.Add(this._cmbMMConversionProfile);
         this._tpMultimedia.Controls.Add(this._lblMMDestFile);
         this._tpMultimedia.Location = new System.Drawing.Point(4, 22);
         this._tpMultimedia.Name = "_tpMultimedia";
         this._tpMultimedia.Padding = new System.Windows.Forms.Padding(3);
         this._tpMultimedia.Size = new System.Drawing.Size(366, 197);
         this._tpMultimedia.TabIndex = 1;
         this._tpMultimedia.Text = "Multimedia";
         this._tpMultimedia.UseVisualStyleBackColor = true;
         // 
         // _btnMMLoadProfiles
         // 
         this._btnMMLoadProfiles.Location = new System.Drawing.Point(254, 48);
         this._btnMMLoadProfiles.Name = "_btnMMLoadProfiles";
         this._btnMMLoadProfiles.Size = new System.Drawing.Size(96, 23);
         this._btnMMLoadProfiles.TabIndex = 13;
         this._btnMMLoadProfiles.Text = "Load Profiles";
         this._btnMMLoadProfiles.UseVisualStyleBackColor = true;
         this._btnMMLoadProfiles.Click += new System.EventHandler(this._btnMMLoadProfiles_Click);
         // 
         // _btnMMAddJob
         // 
         this._btnMMAddJob.Location = new System.Drawing.Point(19, 93);
         this._btnMMAddJob.Name = "_btnMMAddJob";
         this._btnMMAddJob.Size = new System.Drawing.Size(331, 34);
         this._btnMMAddJob.TabIndex = 11;
         this._btnMMAddJob.Text = "Add Job(s)";
         this._btnMMAddJob.UseVisualStyleBackColor = true;
         this._btnMMAddJob.Click += new System.EventHandler(this._btnMMAddJob_Click);
         // 
         // _lblMMConversionProfile
         // 
         this._lblMMConversionProfile.AutoSize = true;
         this._lblMMConversionProfile.Location = new System.Drawing.Point(16, 22);
         this._lblMMConversionProfile.Name = "_lblMMConversionProfile";
         this._lblMMConversionProfile.Size = new System.Drawing.Size(92, 13);
         this._lblMMConversionProfile.TabIndex = 10;
         this._lblMMConversionProfile.Text = "Conversion Profile";
         // 
         // _cmbMMConversionProfile
         // 
         this._cmbMMConversionProfile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._cmbMMConversionProfile.FormattingEnabled = true;
         this._cmbMMConversionProfile.Location = new System.Drawing.Point(19, 49);
         this._cmbMMConversionProfile.Name = "_cmbMMConversionProfile";
         this._cmbMMConversionProfile.Size = new System.Drawing.Size(220, 21);
         this._cmbMMConversionProfile.TabIndex = 9;
         // 
         // _lblMMDestFile
         // 
         this._lblMMDestFile.AutoSize = true;
         this._lblMMDestFile.Location = new System.Drawing.Point(16, 157);
         this._lblMMDestFile.Name = "_lblMMDestFile";
         this._lblMMDestFile.Size = new System.Drawing.Size(267, 13);
         this._lblMMDestFile.TabIndex = 7;
         this._lblMMDestFile.Text = "Converted files will be placed in the source file directory";
         // 
         // _dgvJobs
         // 
         this._dgvJobs.AllowUserToAddRows = false;
         this._dgvJobs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
         this._dgvJobs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
         this._dgvJobs.ContextMenuStrip = this._cmJobs;
         this._dgvJobs.Dock = System.Windows.Forms.DockStyle.Fill;
         this._dgvJobs.Location = new System.Drawing.Point(0, 0);
         this._dgvJobs.Name = "_dgvJobs";
         this._dgvJobs.ReadOnly = true;
         this._dgvJobs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
         this._dgvJobs.Size = new System.Drawing.Size(990, 254);
         this._dgvJobs.TabIndex = 0;
         this._dgvJobs.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this._dgvJobs_UserDeletingRow);
         // 
         // _cmJobs
         // 
         this._cmJobs.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._menuItemDeleteJob,
            this._menuItemAbortJob,
            this._menuItemResetJob,
            this._menuItemOpenConvertedFile});
         this._cmJobs.Name = "_cmJobs";
         this._cmJobs.Size = new System.Drawing.Size(183, 92);
         this._cmJobs.Opening += new System.ComponentModel.CancelEventHandler(this._cmJobs_Opening);
         // 
         // _menuItemDeleteJob
         // 
         this._menuItemDeleteJob.Name = "_menuItemDeleteJob";
         this._menuItemDeleteJob.Size = new System.Drawing.Size(182, 22);
         this._menuItemDeleteJob.Text = "Delete Job(s)";
         this._menuItemDeleteJob.Click += new System.EventHandler(this._menuItemDeleteJob_Click);
         // 
         // _menuItemAbortJob
         // 
         this._menuItemAbortJob.Name = "_menuItemAbortJob";
         this._menuItemAbortJob.Size = new System.Drawing.Size(182, 22);
         this._menuItemAbortJob.Text = "Abort Job(s)";
         this._menuItemAbortJob.Click += new System.EventHandler(this._menuItemAbortJob_Click);
         // 
         // _menuItemResetJob
         // 
         this._menuItemResetJob.Name = "_menuItemResetJob";
         this._menuItemResetJob.Size = new System.Drawing.Size(182, 22);
         this._menuItemResetJob.Text = "Reset Job(s)";
         this._menuItemResetJob.Click += new System.EventHandler(this._menuItemResetJob_Click);
         // 
         // _menuItemOpenConvertedFile
         // 
         this._menuItemOpenConvertedFile.Name = "_menuItemOpenConvertedFile";
         this._menuItemOpenConvertedFile.Size = new System.Drawing.Size(182, 22);
         this._menuItemOpenConvertedFile.Text = "Open Converted File";
         this._menuItemOpenConvertedFile.Click += new System.EventHandler(this._menuItemOpenConvertedFile_Click);
         // 
         // ClientForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(990, 573);
         this.Controls.Add(this.splitContainer1);
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.MinimumSize = new System.Drawing.Size(747, 507);
         this.Name = "ClientForm";
         this.Text = "Client Form";
         this.Load += new System.EventHandler(this.ClientForm_Load);
         this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ClientForm_FormClosing);
         this.splitContainer1.Panel1.ResumeLayout(false);
         this.splitContainer1.Panel1.PerformLayout();
         this.splitContainer1.Panel2.ResumeLayout(false);
         this.splitContainer1.ResumeLayout(false);
         this._tcJobTypes.ResumeLayout(false);
         this._tpOCR.ResumeLayout(false);
         this._tpOCR.PerformLayout();
         this._tpMultimedia.ResumeLayout(false);
         this._tpMultimedia.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this._dgvJobs)).EndInit();
         this._cmJobs.ResumeLayout(false);
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.SplitContainer splitContainer1;
      private System.Windows.Forms.DataGridView _dgvJobs;
      private System.Windows.Forms.TabControl _tcJobTypes;
      private System.Windows.Forms.TabPage _tpOCR;
      private System.Windows.Forms.TabPage _tpMultimedia;
      private System.Windows.Forms.Button _btnOCRAddJob;
      private System.Windows.Forms.Label _lblOCRFormat;
      private System.Windows.Forms.ComboBox _cmbOCRFormat;
      private System.Windows.Forms.Label _lblOCRDestFile;
      private System.Windows.Forms.Button _btnMMAddJob;
      private System.Windows.Forms.Label _lblMMConversionProfile;
      private System.Windows.Forms.ComboBox _cmbMMConversionProfile;
      private System.Windows.Forms.Label _lblMMDestFile;
      private System.Windows.Forms.Label _lblUsername;
      private System.Windows.Forms.ContextMenuStrip _cmJobs;
      private System.Windows.Forms.ToolStripMenuItem _menuItemDeleteJob;
      private System.Windows.Forms.ToolStripMenuItem _menuItemAbortJob;
      private System.Windows.Forms.ToolStripMenuItem _menuItemResetJob;
      private System.Windows.Forms.Button _btnChangeUsername;
      private System.Windows.Forms.Button _btnRefreshJobs;
      private System.Windows.Forms.CheckBox _chkAutoRefreshJobs;
      private System.Windows.Forms.Button _btnMMLoadProfiles;
      private System.Windows.Forms.Label _lblJobCount;
      private System.Windows.Forms.ToolStripMenuItem _menuItemOpenConvertedFile;
   }
}
