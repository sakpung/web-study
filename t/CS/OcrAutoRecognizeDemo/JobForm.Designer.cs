namespace OcrAutoRecognizeDemo
{
   partial class JobForm
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
         if(disposing && (components != null))
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JobForm));
         this._infoLabel = new System.Windows.Forms.Label();
         this._optionsGroupBox = new System.Windows.Forms.GroupBox();
         this._preprocessingComboBox = new System.Windows.Forms.ComboBox();
         this._enableTraceCheckBox = new System.Windows.Forms.CheckBox();
         this._continueOnErrorCheckBox = new System.Windows.Forms.CheckBox();
         this._preprocessingLabel = new System.Windows.Forms.Label();
         this._maximumPagesBeforeLtdInfoLabel = new System.Windows.Forms.Label();
         this._maximumPagesBeforeLtdTextBox = new System.Windows.Forms.TextBox();
         this._maximumPagesBeforeLtdLabel = new System.Windows.Forms.Label();
         this._maximumThreadsPerJobInfoLabel = new System.Windows.Forms.Label();
         this._maximumThreadsPerJobTextBox = new System.Windows.Forms.TextBox();
         this._maximumThreadsPerJobLabel = new System.Windows.Forms.Label();
         this._zonesFileNameTextBox = new System.Windows.Forms.TextBox();
         this._zonesFileNameLabel = new System.Windows.Forms.Label();
         this._zonesFileNameBrowseButton = new System.Windows.Forms.Button();
         this._jobDataGroupBox = new System.Windows.Forms.GroupBox();
         this._documentFormatsSelectorPanel = new System.Windows.Forms.Panel();
         this._imageFileNameTextBox = new System.Windows.Forms.TextBox();
         this._imageFileNameLabel = new System.Windows.Forms.Label();
         this._imageFileNameBrowseButton = new System.Windows.Forms.Button();
         this._documentFormatLabel = new System.Windows.Forms.Label();
         this._imageFileNamePagesLabel = new System.Windows.Forms.Label();
         this._documentFileNameBrowseButton = new System.Windows.Forms.Button();
         this._imageFileNamePagesValueLabel = new System.Windows.Forms.Label();
         this._documentFileNameTextBox = new System.Windows.Forms.TextBox();
         this._imageFilePagesBrowseButton = new System.Windows.Forms.Button();
         this._documentFileNameLabel = new System.Windows.Forms.Label();
         this._runButton = new System.Windows.Forms.Button();
         this._exitButton = new System.Windows.Forms.Button();
         this._viewFinalDocumentCheckBox = new System.Windows.Forms.CheckBox();
         this._engineSettingsButton = new System.Windows.Forms.Button();
         this._engineLanguagesButton = new System.Windows.Forms.Button();
         this._optionsGroupBox.SuspendLayout();
         this._jobDataGroupBox.SuspendLayout();
         this.SuspendLayout();
         // 
         // _infoLabel
         // 
         this._infoLabel.AutoSize = true;
         this._infoLabel.Location = new System.Drawing.Point(12, 9);
         this._infoLabel.Name = "_infoLabel";
         this._infoLabel.Size = new System.Drawing.Size(404, 13);
         this._infoLabel.TabIndex = 0;
         this._infoLabel.Text = "This demo shows the different features of the IOcrAutoRecognizeManager interface." +
             "";
         // 
         // _optionsGroupBox
         // 
         this._optionsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this._optionsGroupBox.Controls.Add(this._preprocessingComboBox);
         this._optionsGroupBox.Controls.Add(this._enableTraceCheckBox);
         this._optionsGroupBox.Controls.Add(this._continueOnErrorCheckBox);
         this._optionsGroupBox.Controls.Add(this._preprocessingLabel);
         this._optionsGroupBox.Controls.Add(this._maximumPagesBeforeLtdInfoLabel);
         this._optionsGroupBox.Controls.Add(this._maximumPagesBeforeLtdTextBox);
         this._optionsGroupBox.Controls.Add(this._maximumPagesBeforeLtdLabel);
         this._optionsGroupBox.Controls.Add(this._maximumThreadsPerJobInfoLabel);
         this._optionsGroupBox.Controls.Add(this._maximumThreadsPerJobTextBox);
         this._optionsGroupBox.Controls.Add(this._maximumThreadsPerJobLabel);
         this._optionsGroupBox.Controls.Add(this._zonesFileNameTextBox);
         this._optionsGroupBox.Controls.Add(this._zonesFileNameLabel);
         this._optionsGroupBox.Controls.Add(this._zonesFileNameBrowseButton);
         this._optionsGroupBox.Location = new System.Drawing.Point(15, 191);
         this._optionsGroupBox.Name = "_optionsGroupBox";
         this._optionsGroupBox.Size = new System.Drawing.Size(824, 179);
         this._optionsGroupBox.TabIndex = 4;
         this._optionsGroupBox.TabStop = false;
         this._optionsGroupBox.Text = "Options:";
         // 
         // _preprocessingComboBox
         // 
         this._preprocessingComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._preprocessingComboBox.FormattingEnabled = true;
         this._preprocessingComboBox.Location = new System.Drawing.Point(184, 108);
         this._preprocessingComboBox.Name = "_preprocessingComboBox";
         this._preprocessingComboBox.Size = new System.Drawing.Size(271, 21);
         this._preprocessingComboBox.TabIndex = 10;
         // 
         // _enableTraceCheckBox
         // 
         this._enableTraceCheckBox.AutoSize = true;
         this._enableTraceCheckBox.Location = new System.Drawing.Point(183, 156);
         this._enableTraceCheckBox.Name = "_enableTraceCheckBox";
         this._enableTraceCheckBox.Size = new System.Drawing.Size(86, 17);
         this._enableTraceCheckBox.TabIndex = 12;
         this._enableTraceCheckBox.Text = "Enable trace";
         this._enableTraceCheckBox.UseVisualStyleBackColor = true;
         // 
         // _continueOnErrorCheckBox
         // 
         this._continueOnErrorCheckBox.AutoSize = true;
         this._continueOnErrorCheckBox.Location = new System.Drawing.Point(183, 133);
         this._continueOnErrorCheckBox.Name = "_continueOnErrorCheckBox";
         this._continueOnErrorCheckBox.Size = new System.Drawing.Size(171, 17);
         this._continueOnErrorCheckBox.TabIndex = 11;
         this._continueOnErrorCheckBox.Text = "Continue on recoverable errors";
         this._continueOnErrorCheckBox.UseVisualStyleBackColor = true;
         // 
         // _preprocessingLabel
         // 
         this._preprocessingLabel.AutoSize = true;
         this._preprocessingLabel.Location = new System.Drawing.Point(100, 111);
         this._preprocessingLabel.Name = "_preprocessingLabel";
         this._preprocessingLabel.Size = new System.Drawing.Size(77, 13);
         this._preprocessingLabel.TabIndex = 9;
         this._preprocessingLabel.Text = "Preprocessing:";
         // 
         // _maximumPagesBeforeLtdInfoLabel
         // 
         this._maximumPagesBeforeLtdInfoLabel.AutoSize = true;
         this._maximumPagesBeforeLtdInfoLabel.Location = new System.Drawing.Point(289, 86);
         this._maximumPagesBeforeLtdInfoLabel.Name = "_maximumPagesBeforeLtdInfoLabel";
         this._maximumPagesBeforeLtdInfoLabel.Size = new System.Drawing.Size(438, 13);
         this._maximumPagesBeforeLtdInfoLabel.TabIndex = 8;
         this._maximumPagesBeforeLtdInfoLabel.Text = "or more pages. Select 0 to not use LTD (1 page LTD are always used when multi-thr" +
             "eading)";
         // 
         // _maximumPagesBeforeLtdTextBox
         // 
         this._maximumPagesBeforeLtdTextBox.Location = new System.Drawing.Point(183, 83);
         this._maximumPagesBeforeLtdTextBox.Name = "_maximumPagesBeforeLtdTextBox";
         this._maximumPagesBeforeLtdTextBox.Size = new System.Drawing.Size(100, 20);
         this._maximumPagesBeforeLtdTextBox.TabIndex = 7;
         // 
         // _maximumPagesBeforeLtdLabel
         // 
         this._maximumPagesBeforeLtdLabel.AutoSize = true;
         this._maximumPagesBeforeLtdLabel.Location = new System.Drawing.Point(14, 86);
         this._maximumPagesBeforeLtdLabel.Name = "_maximumPagesBeforeLtdLabel";
         this._maximumPagesBeforeLtdLabel.Size = new System.Drawing.Size(163, 13);
         this._maximumPagesBeforeLtdLabel.TabIndex = 6;
         this._maximumPagesBeforeLtdLabel.Text = "Use LTD format if document has:";
         // 
         // _maximumThreadsPerJobInfoLabel
         // 
         this._maximumThreadsPerJobInfoLabel.AutoSize = true;
         this._maximumThreadsPerJobInfoLabel.Location = new System.Drawing.Point(289, 62);
         this._maximumThreadsPerJobInfoLabel.Name = "_maximumThreadsPerJobInfoLabel";
         this._maximumThreadsPerJobInfoLabel.Size = new System.Drawing.Size(486, 13);
         this._maximumThreadsPerJobInfoLabel.TabIndex = 5;
         this._maximumThreadsPerJobInfoLabel.Text = "0 = Use all available CPUs/Cores (fastest), 1 = Single threaded, otherwise, numbe" +
             "r of threads up to 64";
         // 
         // _maximumThreadsPerJobTextBox
         // 
         this._maximumThreadsPerJobTextBox.Location = new System.Drawing.Point(183, 57);
         this._maximumThreadsPerJobTextBox.Name = "_maximumThreadsPerJobTextBox";
         this._maximumThreadsPerJobTextBox.Size = new System.Drawing.Size(100, 20);
         this._maximumThreadsPerJobTextBox.TabIndex = 4;
         // 
         // _maximumThreadsPerJobLabel
         // 
         this._maximumThreadsPerJobLabel.AutoSize = true;
         this._maximumThreadsPerJobLabel.Location = new System.Drawing.Point(66, 60);
         this._maximumThreadsPerJobLabel.Name = "_maximumThreadsPerJobLabel";
         this._maximumThreadsPerJobLabel.Size = new System.Drawing.Size(111, 13);
         this._maximumThreadsPerJobLabel.TabIndex = 3;
         this._maximumThreadsPerJobLabel.Text = "Maximum threads/job:";
         // 
         // _zonesFileNameTextBox
         // 
         this._zonesFileNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this._zonesFileNameTextBox.Location = new System.Drawing.Point(183, 29);
         this._zonesFileNameTextBox.Name = "_zonesFileNameTextBox";
         this._zonesFileNameTextBox.Size = new System.Drawing.Size(598, 20);
         this._zonesFileNameTextBox.TabIndex = 1;
         // 
         // _zonesFileNameLabel
         // 
         this._zonesFileNameLabel.AutoSize = true;
         this._zonesFileNameLabel.Location = new System.Drawing.Point(92, 32);
         this._zonesFileNameLabel.Name = "_zonesFileNameLabel";
         this._zonesFileNameLabel.Size = new System.Drawing.Size(85, 13);
         this._zonesFileNameLabel.TabIndex = 0;
         this._zonesFileNameLabel.Text = "Zones file name:";
         // 
         // _zonesFileNameBrowseButton
         // 
         this._zonesFileNameBrowseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this._zonesFileNameBrowseButton.Location = new System.Drawing.Point(787, 27);
         this._zonesFileNameBrowseButton.Name = "_zonesFileNameBrowseButton";
         this._zonesFileNameBrowseButton.Size = new System.Drawing.Size(31, 23);
         this._zonesFileNameBrowseButton.TabIndex = 2;
         this._zonesFileNameBrowseButton.Text = "...";
         this._zonesFileNameBrowseButton.UseVisualStyleBackColor = true;
         this._zonesFileNameBrowseButton.Click += new System.EventHandler(this._zonesFileNameBrowseButton_Click);
         // 
         // _jobDataGroupBox
         // 
         this._jobDataGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this._jobDataGroupBox.Controls.Add(this._documentFormatsSelectorPanel);
         this._jobDataGroupBox.Controls.Add(this._imageFileNameTextBox);
         this._jobDataGroupBox.Controls.Add(this._imageFileNameLabel);
         this._jobDataGroupBox.Controls.Add(this._imageFileNameBrowseButton);
         this._jobDataGroupBox.Controls.Add(this._documentFormatLabel);
         this._jobDataGroupBox.Controls.Add(this._imageFileNamePagesLabel);
         this._jobDataGroupBox.Controls.Add(this._documentFileNameBrowseButton);
         this._jobDataGroupBox.Controls.Add(this._imageFileNamePagesValueLabel);
         this._jobDataGroupBox.Controls.Add(this._documentFileNameTextBox);
         this._jobDataGroupBox.Controls.Add(this._imageFilePagesBrowseButton);
         this._jobDataGroupBox.Controls.Add(this._documentFileNameLabel);
         this._jobDataGroupBox.Location = new System.Drawing.Point(15, 36);
         this._jobDataGroupBox.Name = "_jobDataGroupBox";
         this._jobDataGroupBox.Size = new System.Drawing.Size(824, 149);
         this._jobDataGroupBox.TabIndex = 3;
         this._jobDataGroupBox.TabStop = false;
         this._jobDataGroupBox.Text = "Job data:";
         // 
         // _documentFormatsSelectorPanel
         // 
         this._documentFormatsSelectorPanel.Location = new System.Drawing.Point(124, 86);
         this._documentFormatsSelectorPanel.Name = "_documentFormatsSelectorPanel";
         this._documentFormatsSelectorPanel.Size = new System.Drawing.Size(331, 23);
         this._documentFormatsSelectorPanel.TabIndex = 7;
         // 
         // _imageFileNameTextBox
         // 
         this._imageFileNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this._imageFileNameTextBox.Location = new System.Drawing.Point(124, 36);
         this._imageFileNameTextBox.Name = "_imageFileNameTextBox";
         this._imageFileNameTextBox.Size = new System.Drawing.Size(657, 20);
         this._imageFileNameTextBox.TabIndex = 1;
         // 
         // _imageFileNameLabel
         // 
         this._imageFileNameLabel.AutoSize = true;
         this._imageFileNameLabel.Location = new System.Drawing.Point(34, 39);
         this._imageFileNameLabel.Name = "_imageFileNameLabel";
         this._imageFileNameLabel.Size = new System.Drawing.Size(84, 13);
         this._imageFileNameLabel.TabIndex = 0;
         this._imageFileNameLabel.Text = "Image file name:";
         // 
         // _imageFileNameBrowseButton
         // 
         this._imageFileNameBrowseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this._imageFileNameBrowseButton.Location = new System.Drawing.Point(787, 34);
         this._imageFileNameBrowseButton.Name = "_imageFileNameBrowseButton";
         this._imageFileNameBrowseButton.Size = new System.Drawing.Size(31, 23);
         this._imageFileNameBrowseButton.TabIndex = 2;
         this._imageFileNameBrowseButton.Text = "...";
         this._imageFileNameBrowseButton.UseVisualStyleBackColor = true;
         this._imageFileNameBrowseButton.Click += new System.EventHandler(this._imageFileNameBrowseButton_Click);
         // 
         // _documentFormatLabel
         // 
         this._documentFormatLabel.AutoSize = true;
         this._documentFormatLabel.Location = new System.Drawing.Point(44, 88);
         this._documentFormatLabel.Name = "_documentFormatLabel";
         this._documentFormatLabel.Size = new System.Drawing.Size(74, 13);
         this._documentFormatLabel.TabIndex = 6;
         this._documentFormatLabel.Text = "Output format:";
         // 
         // _imageFileNamePagesLabel
         // 
         this._imageFileNamePagesLabel.AutoSize = true;
         this._imageFileNamePagesLabel.Location = new System.Drawing.Point(78, 64);
         this._imageFileNamePagesLabel.Name = "_imageFileNamePagesLabel";
         this._imageFileNamePagesLabel.Size = new System.Drawing.Size(40, 13);
         this._imageFileNamePagesLabel.TabIndex = 3;
         this._imageFileNamePagesLabel.Text = "Pages:";
         // 
         // _documentFileNameBrowseButton
         // 
         this._documentFileNameBrowseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this._documentFileNameBrowseButton.Location = new System.Drawing.Point(787, 113);
         this._documentFileNameBrowseButton.Name = "_documentFileNameBrowseButton";
         this._documentFileNameBrowseButton.Size = new System.Drawing.Size(31, 23);
         this._documentFileNameBrowseButton.TabIndex = 10;
         this._documentFileNameBrowseButton.Text = "...";
         this._documentFileNameBrowseButton.UseVisualStyleBackColor = true;
         this._documentFileNameBrowseButton.Click += new System.EventHandler(this._documentFileNameBrowseButton_Click);
         // 
         // _imageFileNamePagesValueLabel
         // 
         this._imageFileNamePagesValueLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this._imageFileNamePagesValueLabel.Location = new System.Drawing.Point(124, 59);
         this._imageFileNamePagesValueLabel.Name = "_imageFileNamePagesValueLabel";
         this._imageFileNamePagesValueLabel.Size = new System.Drawing.Size(294, 23);
         this._imageFileNamePagesValueLabel.TabIndex = 4;
         this._imageFileNamePagesValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // _documentFileNameTextBox
         // 
         this._documentFileNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this._documentFileNameTextBox.Location = new System.Drawing.Point(124, 115);
         this._documentFileNameTextBox.Name = "_documentFileNameTextBox";
         this._documentFileNameTextBox.Size = new System.Drawing.Size(657, 20);
         this._documentFileNameTextBox.TabIndex = 9;
         // 
         // _imageFilePagesBrowseButton
         // 
         this._imageFilePagesBrowseButton.Location = new System.Drawing.Point(424, 59);
         this._imageFilePagesBrowseButton.Name = "_imageFilePagesBrowseButton";
         this._imageFilePagesBrowseButton.Size = new System.Drawing.Size(31, 23);
         this._imageFilePagesBrowseButton.TabIndex = 5;
         this._imageFilePagesBrowseButton.Text = "...";
         this._imageFilePagesBrowseButton.UseVisualStyleBackColor = true;
         this._imageFilePagesBrowseButton.Click += new System.EventHandler(this._imageFilePagesBrowseButton_Click);
         // 
         // _documentFileNameLabel
         // 
         this._documentFileNameLabel.AutoSize = true;
         this._documentFileNameLabel.Location = new System.Drawing.Point(14, 118);
         this._documentFileNameLabel.Name = "_documentFileNameLabel";
         this._documentFileNameLabel.Size = new System.Drawing.Size(104, 13);
         this._documentFileNameLabel.TabIndex = 8;
         this._documentFileNameLabel.Text = "Document file name:";
         // 
         // _runButton
         // 
         this._runButton.Location = new System.Drawing.Point(683, 387);
         this._runButton.Name = "_runButton";
         this._runButton.Size = new System.Drawing.Size(75, 23);
         this._runButton.TabIndex = 6;
         this._runButton.Text = "Run";
         this._runButton.UseVisualStyleBackColor = true;
         this._runButton.Click += new System.EventHandler(this._runButton_Click);
         // 
         // _exitButton
         // 
         this._exitButton.Location = new System.Drawing.Point(764, 386);
         this._exitButton.Name = "_exitButton";
         this._exitButton.Size = new System.Drawing.Size(75, 23);
         this._exitButton.TabIndex = 7;
         this._exitButton.Text = "Exit";
         this._exitButton.UseVisualStyleBackColor = true;
         this._exitButton.Click += new System.EventHandler(this._exitButton_Click);
         // 
         // _viewFinalDocumentCheckBox
         // 
         this._viewFinalDocumentCheckBox.AutoSize = true;
         this._viewFinalDocumentCheckBox.Location = new System.Drawing.Point(13, 386);
         this._viewFinalDocumentCheckBox.Name = "_viewFinalDocumentCheckBox";
         this._viewFinalDocumentCheckBox.Size = new System.Drawing.Size(121, 17);
         this._viewFinalDocumentCheckBox.TabIndex = 5;
         this._viewFinalDocumentCheckBox.Text = "View final document";
         this._viewFinalDocumentCheckBox.UseVisualStyleBackColor = true;
         // 
         // _engineSettingsButton
         // 
         this._engineSettingsButton.Location = new System.Drawing.Point(531, 12);
         this._engineSettingsButton.Name = "_engineSettingsButton";
         this._engineSettingsButton.Size = new System.Drawing.Size(148, 23);
         this._engineSettingsButton.TabIndex = 1;
         this._engineSettingsButton.Text = "Engine settings...";
         this._engineSettingsButton.UseVisualStyleBackColor = true;
         this._engineSettingsButton.Click += new System.EventHandler(this._engineSettingsButton_Click);
         // 
         // _engineLanguagesButton
         // 
         this._engineLanguagesButton.Location = new System.Drawing.Point(685, 12);
         this._engineLanguagesButton.Name = "_engineLanguagesButton";
         this._engineLanguagesButton.Size = new System.Drawing.Size(148, 23);
         this._engineLanguagesButton.TabIndex = 2;
         this._engineLanguagesButton.Text = "Engine languages...";
         this._engineLanguagesButton.UseVisualStyleBackColor = true;
         this._engineLanguagesButton.Click += new System.EventHandler(this._engineLanguagesButton_Click);
         // 
         // JobForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(851, 422);
         this.Controls.Add(this._engineLanguagesButton);
         this.Controls.Add(this._engineSettingsButton);
         this.Controls.Add(this._viewFinalDocumentCheckBox);
         this.Controls.Add(this._exitButton);
         this.Controls.Add(this._runButton);
         this.Controls.Add(this._optionsGroupBox);
         this.Controls.Add(this._jobDataGroupBox);
         this.Controls.Add(this._infoLabel);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.MaximizeBox = false;
         this.Name = "JobForm";
         this.Text = "JobForm";
         this._optionsGroupBox.ResumeLayout(false);
         this._optionsGroupBox.PerformLayout();
         this._jobDataGroupBox.ResumeLayout(false);
         this._jobDataGroupBox.PerformLayout();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Label _infoLabel;
      private System.Windows.Forms.GroupBox _optionsGroupBox;
      private System.Windows.Forms.ComboBox _preprocessingComboBox;
      private System.Windows.Forms.CheckBox _enableTraceCheckBox;
      private System.Windows.Forms.CheckBox _continueOnErrorCheckBox;
      private System.Windows.Forms.Label _preprocessingLabel;
      private System.Windows.Forms.Label _maximumPagesBeforeLtdInfoLabel;
      private System.Windows.Forms.TextBox _maximumPagesBeforeLtdTextBox;
      private System.Windows.Forms.Label _maximumPagesBeforeLtdLabel;
      private System.Windows.Forms.Label _maximumThreadsPerJobInfoLabel;
      private System.Windows.Forms.TextBox _maximumThreadsPerJobTextBox;
      private System.Windows.Forms.Label _maximumThreadsPerJobLabel;
      private System.Windows.Forms.TextBox _zonesFileNameTextBox;
      private System.Windows.Forms.Label _zonesFileNameLabel;
      private System.Windows.Forms.Button _zonesFileNameBrowseButton;
      private System.Windows.Forms.GroupBox _jobDataGroupBox;
      private System.Windows.Forms.Panel _documentFormatsSelectorPanel;
      private System.Windows.Forms.TextBox _imageFileNameTextBox;
      private System.Windows.Forms.Label _imageFileNameLabel;
      private System.Windows.Forms.Button _imageFileNameBrowseButton;
      private System.Windows.Forms.Label _documentFormatLabel;
      private System.Windows.Forms.Label _imageFileNamePagesLabel;
      private System.Windows.Forms.Button _documentFileNameBrowseButton;
      private System.Windows.Forms.Label _imageFileNamePagesValueLabel;
      private System.Windows.Forms.TextBox _documentFileNameTextBox;
      private System.Windows.Forms.Button _imageFilePagesBrowseButton;
      private System.Windows.Forms.Label _documentFileNameLabel;
      private System.Windows.Forms.Button _runButton;
      private System.Windows.Forms.Button _exitButton;
      private System.Windows.Forms.CheckBox _viewFinalDocumentCheckBox;
      private System.Windows.Forms.Button _engineSettingsButton;
      private System.Windows.Forms.Button _engineLanguagesButton;
   }
}