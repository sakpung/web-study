namespace LTDMergeDemo
{
   partial class LTDMergeDialog
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LTDMergeDialog));
         this._exitButton = new System.Windows.Forms.Button();
         this._nextButton = new System.Windows.Forms.Button();
         this._previousButton = new System.Windows.Forms.Button();
         this._aboutButton = new System.Windows.Forms.Button();
         this._progressBar = new System.Windows.Forms.ProgressBar();
         this._mainWizardControl = new LTDMergeDemo.WizardControl();
         this._sourceLTDFilesTabPage = new System.Windows.Forms.TabPage();
         this._sourceLTDFilesGroupBox = new System.Windows.Forms.GroupBox();
         this.label3 = new System.Windows.Forms.Label();
         this._ltdDocumentTypeComboBox = new System.Windows.Forms.ComboBox();
         this.label2 = new System.Windows.Forms.Label();
         this._moveBottomButton = new System.Windows.Forms.Button();
         this._moveDownButton = new System.Windows.Forms.Button();
         this._moveUpButton = new System.Windows.Forms.Button();
         this._moveTopButton = new System.Windows.Forms.Button();
         this._sourceLTDFileListView = new System.Windows.Forms.ListView();
         this._headerFileName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this._columnFileType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this.label1 = new System.Windows.Forms.Label();
         this._sourceLTDFilesRemoveButton = new System.Windows.Forms.Button();
         this._sourceFilesNoteLabel = new System.Windows.Forms.Label();
         this._sourceLTDFilesClearButton = new System.Windows.Forms.Button();
         this._sourceLTDFilesAddButton = new System.Windows.Forms.Button();
         this._outputOptionsTabPage = new System.Windows.Forms.TabPage();
         this.groupBox1 = new System.Windows.Forms.GroupBox();
         this._viewDocumentCheckBox = new System.Windows.Forms.CheckBox();
         this._outputFileNameBrowseButton = new System.Windows.Forms.Button();
         this._outputFileNameTextBox = new System.Windows.Forms.TextBox();
         this._outputFileNameLabel = new System.Windows.Forms.Label();
         this._sourceFileNameGroupBox = new System.Windows.Forms.GroupBox();
         this._documentFormatOptionsControl = new LTDMergeDemo.DocumentFormatOptionsControl();
         this._mainWizardControl.SuspendLayout();
         this._sourceLTDFilesTabPage.SuspendLayout();
         this._sourceLTDFilesGroupBox.SuspendLayout();
         this._outputOptionsTabPage.SuspendLayout();
         this.groupBox1.SuspendLayout();
         this._sourceFileNameGroupBox.SuspendLayout();
         this.SuspendLayout();
         // 
         // _exitButton
         // 
         this._exitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this._exitButton.Location = new System.Drawing.Point(641, 566);
         this._exitButton.Name = "_exitButton";
         this._exitButton.Size = new System.Drawing.Size(75, 23);
         this._exitButton.TabIndex = 4;
         this._exitButton.Text = "E&xit";
         this._exitButton.UseVisualStyleBackColor = true;
         this._exitButton.Click += new System.EventHandler(this._exitButton_Click);
         // 
         // _nextButton
         // 
         this._nextButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this._nextButton.Location = new System.Drawing.Point(545, 566);
         this._nextButton.Name = "_nextButton";
         this._nextButton.Size = new System.Drawing.Size(75, 23);
         this._nextButton.TabIndex = 3;
         this._nextButton.Text = "&Next";
         this._nextButton.UseVisualStyleBackColor = true;
         this._nextButton.Click += new System.EventHandler(this._nextButton_Click);
         // 
         // _previousButton
         // 
         this._previousButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this._previousButton.Location = new System.Drawing.Point(464, 566);
         this._previousButton.Name = "_previousButton";
         this._previousButton.Size = new System.Drawing.Size(75, 23);
         this._previousButton.TabIndex = 2;
         this._previousButton.Text = "&Previous";
         this._previousButton.UseVisualStyleBackColor = true;
         this._previousButton.Click += new System.EventHandler(this._previousButton_Click);
         // 
         // _aboutButton
         // 
         this._aboutButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
         this._aboutButton.Location = new System.Drawing.Point(11, 566);
         this._aboutButton.Name = "_aboutButton";
         this._aboutButton.Size = new System.Drawing.Size(75, 23);
         this._aboutButton.TabIndex = 1;
         this._aboutButton.Text = "About...";
         this._aboutButton.UseVisualStyleBackColor = true;
         this._aboutButton.Click += new System.EventHandler(this._aboutButton_Click);
         // 
         // _progressBar
         // 
         this._progressBar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
         this._progressBar.Location = new System.Drawing.Point(92, 566);
         this._progressBar.Name = "_progressBar";
         this._progressBar.Size = new System.Drawing.Size(366, 23);
         this._progressBar.Step = 1;
         this._progressBar.TabIndex = 5;
         // 
         // _mainWizardControl
         // 
         this._mainWizardControl.Controls.Add(this._sourceLTDFilesTabPage);
         this._mainWizardControl.Controls.Add(this._outputOptionsTabPage);
         this._mainWizardControl.Location = new System.Drawing.Point(12, 12);
         this._mainWizardControl.Name = "_mainWizardControl";
         this._mainWizardControl.SelectedIndex = 0;
         this._mainWizardControl.Size = new System.Drawing.Size(708, 548);
         this._mainWizardControl.TabIndex = 0;
         // 
         // _sourceLTDFilesTabPage
         // 
         this._sourceLTDFilesTabPage.Controls.Add(this._sourceLTDFilesGroupBox);
         this._sourceLTDFilesTabPage.Location = new System.Drawing.Point(4, 22);
         this._sourceLTDFilesTabPage.Name = "_sourceLTDFilesTabPage";
         this._sourceLTDFilesTabPage.Size = new System.Drawing.Size(700, 522);
         this._sourceLTDFilesTabPage.TabIndex = 4;
         this._sourceLTDFilesTabPage.Text = "Source LTD files";
         this._sourceLTDFilesTabPage.UseVisualStyleBackColor = true;
         // 
         // _sourceLTDFilesGroupBox
         // 
         this._sourceLTDFilesGroupBox.Controls.Add(this.label3);
         this._sourceLTDFilesGroupBox.Controls.Add(this._ltdDocumentTypeComboBox);
         this._sourceLTDFilesGroupBox.Controls.Add(this.label2);
         this._sourceLTDFilesGroupBox.Controls.Add(this._moveBottomButton);
         this._sourceLTDFilesGroupBox.Controls.Add(this._moveDownButton);
         this._sourceLTDFilesGroupBox.Controls.Add(this._moveUpButton);
         this._sourceLTDFilesGroupBox.Controls.Add(this._moveTopButton);
         this._sourceLTDFilesGroupBox.Controls.Add(this._sourceLTDFileListView);
         this._sourceLTDFilesGroupBox.Controls.Add(this.label1);
         this._sourceLTDFilesGroupBox.Controls.Add(this._sourceLTDFilesRemoveButton);
         this._sourceLTDFilesGroupBox.Controls.Add(this._sourceFilesNoteLabel);
         this._sourceLTDFilesGroupBox.Controls.Add(this._sourceLTDFilesClearButton);
         this._sourceLTDFilesGroupBox.Controls.Add(this._sourceLTDFilesAddButton);
         this._sourceLTDFilesGroupBox.Location = new System.Drawing.Point(16, 16);
         this._sourceLTDFilesGroupBox.Name = "_sourceLTDFilesGroupBox";
         this._sourceLTDFilesGroupBox.Size = new System.Drawing.Size(665, 369);
         this._sourceLTDFilesGroupBox.TabIndex = 0;
         this._sourceLTDFilesGroupBox.TabStop = false;
         this._sourceLTDFilesGroupBox.Text = "Select source LTD files:";
         // 
         // label3
         // 
         this.label3.AutoSize = true;
         this.label3.Location = new System.Drawing.Point(236, 25);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(398, 13);
         this.label3.TabIndex = 28;
         this.label3.Text = "Only LTD files of selected type will be converted (Mixed type LTDs not supported)" +
    "";
         // 
         // _ltdDocumentTypeComboBox
         // 
         this._ltdDocumentTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._ltdDocumentTypeComboBox.FormattingEnabled = true;
         this._ltdDocumentTypeComboBox.Items.AddRange(new object[] {
            "Ocr",
            "Svg"});
         this._ltdDocumentTypeComboBox.Location = new System.Drawing.Point(134, 21);
         this._ltdDocumentTypeComboBox.Name = "_ltdDocumentTypeComboBox";
         this._ltdDocumentTypeComboBox.Size = new System.Drawing.Size(96, 21);
         this._ltdDocumentTypeComboBox.TabIndex = 27;
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(21, 25);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(103, 13);
         this.label2.TabIndex = 26;
         this.label2.Text = "LTD Document Type";
         // 
         // _moveBottomButton
         // 
         this._moveBottomButton.Image = ((System.Drawing.Image)(resources.GetObject("_moveBottomButton.Image")));
         this._moveBottomButton.Location = new System.Drawing.Point(614, 162);
         this._moveBottomButton.Name = "_moveBottomButton";
         this._moveBottomButton.Size = new System.Drawing.Size(32, 32);
         this._moveBottomButton.TabIndex = 25;
         this._moveBottomButton.UseVisualStyleBackColor = true;
         this._moveBottomButton.Click += new System.EventHandler(this._moveBottomButton_Click);
         // 
         // _moveDownButton
         // 
         this._moveDownButton.Image = ((System.Drawing.Image)(resources.GetObject("_moveDownButton.Image")));
         this._moveDownButton.Location = new System.Drawing.Point(614, 124);
         this._moveDownButton.Name = "_moveDownButton";
         this._moveDownButton.Size = new System.Drawing.Size(32, 32);
         this._moveDownButton.TabIndex = 24;
         this._moveDownButton.UseVisualStyleBackColor = true;
         this._moveDownButton.Click += new System.EventHandler(this._moveDownButton_Click);
         // 
         // _moveUpButton
         // 
         this._moveUpButton.Image = ((System.Drawing.Image)(resources.GetObject("_moveUpButton.Image")));
         this._moveUpButton.Location = new System.Drawing.Point(614, 86);
         this._moveUpButton.Name = "_moveUpButton";
         this._moveUpButton.Size = new System.Drawing.Size(32, 32);
         this._moveUpButton.TabIndex = 23;
         this._moveUpButton.UseVisualStyleBackColor = true;
         this._moveUpButton.Click += new System.EventHandler(this._moveUpButton_Click);
         // 
         // _moveTopButton
         // 
         this._moveTopButton.Image = ((System.Drawing.Image)(resources.GetObject("_moveTopButton.Image")));
         this._moveTopButton.Location = new System.Drawing.Point(614, 48);
         this._moveTopButton.Name = "_moveTopButton";
         this._moveTopButton.Size = new System.Drawing.Size(32, 32);
         this._moveTopButton.TabIndex = 22;
         this._moveTopButton.UseVisualStyleBackColor = true;
         this._moveTopButton.Click += new System.EventHandler(this._moveTopButton_Click);
         // 
         // _sourceLTDFileListView
         // 
         this._sourceLTDFileListView.AllowDrop = true;
         this._sourceLTDFileListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this._headerFileName,
            this._columnFileType});
         this._sourceLTDFileListView.FullRowSelect = true;
         this._sourceLTDFileListView.GridLines = true;
         this._sourceLTDFileListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
         this._sourceLTDFileListView.HideSelection = false;
         this._sourceLTDFileListView.Location = new System.Drawing.Point(104, 48);
         this._sourceLTDFileListView.Name = "_sourceLTDFileListView";
         this._sourceLTDFileListView.Size = new System.Drawing.Size(504, 271);
         this._sourceLTDFileListView.TabIndex = 21;
         this._sourceLTDFileListView.UseCompatibleStateImageBehavior = false;
         this._sourceLTDFileListView.View = System.Windows.Forms.View.Details;
         this._sourceLTDFileListView.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this._sourceLTDFileListView_ItemDrag);
         this._sourceLTDFileListView.SelectedIndexChanged += new System.EventHandler(this._sourceLTDFileListView_SelectedIndexChanged);
         this._sourceLTDFileListView.DragDrop += new System.Windows.Forms.DragEventHandler(this._sourceLTDFileListView_DragDrop);
         this._sourceLTDFileListView.DragEnter += new System.Windows.Forms.DragEventHandler(this._sourceLTDFileListView_DragEnter);
         this._sourceLTDFileListView.DragOver += new System.Windows.Forms.DragEventHandler(this._sourceLTDFileListView_DragOver);
         this._sourceLTDFileListView.KeyDown += new System.Windows.Forms.KeyEventHandler(this._sourceLTDFileListView_KeyDown);
         // 
         // _headerFileName
         // 
         this._headerFileName.Text = "File name";
         this._headerFileName.Width = 420;
         // 
         // _columnFileType
         // 
         this._columnFileType.Text = "LTD Type";
         // 
         // label1
         // 
         this.label1.Location = new System.Drawing.Point(102, 322);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(544, 16);
         this.label1.TabIndex = 5;
         this.label1.Text = "● Drag/Drop operations are supported for the above list.";
         // 
         // _sourceLTDFilesRemoveButton
         // 
         this._sourceLTDFilesRemoveButton.Location = new System.Drawing.Point(24, 77);
         this._sourceLTDFilesRemoveButton.Name = "_sourceLTDFilesRemoveButton";
         this._sourceLTDFilesRemoveButton.Size = new System.Drawing.Size(75, 23);
         this._sourceLTDFilesRemoveButton.TabIndex = 4;
         this._sourceLTDFilesRemoveButton.Text = "&Remove";
         this._sourceLTDFilesRemoveButton.UseVisualStyleBackColor = true;
         this._sourceLTDFilesRemoveButton.Click += new System.EventHandler(this._sourceLTDFilesRemoveButton_Click);
         // 
         // _sourceFilesNoteLabel
         // 
         this._sourceFilesNoteLabel.Location = new System.Drawing.Point(102, 338);
         this._sourceFilesNoteLabel.Name = "_sourceFilesNoteLabel";
         this._sourceFilesNoteLabel.Size = new System.Drawing.Size(544, 16);
         this._sourceFilesNoteLabel.TabIndex = 3;
         this._sourceFilesNoteLabel.Text = "● Files will be merged in the same order shown in the above list.";
         // 
         // _sourceLTDFilesClearButton
         // 
         this._sourceLTDFilesClearButton.Location = new System.Drawing.Point(24, 106);
         this._sourceLTDFilesClearButton.Name = "_sourceLTDFilesClearButton";
         this._sourceLTDFilesClearButton.Size = new System.Drawing.Size(75, 23);
         this._sourceLTDFilesClearButton.TabIndex = 1;
         this._sourceLTDFilesClearButton.Text = "&Clear";
         this._sourceLTDFilesClearButton.UseVisualStyleBackColor = true;
         this._sourceLTDFilesClearButton.Click += new System.EventHandler(this._sourceLTDFilesClearButton_Click);
         // 
         // _sourceLTDFilesAddButton
         // 
         this._sourceLTDFilesAddButton.Location = new System.Drawing.Point(23, 48);
         this._sourceLTDFilesAddButton.Name = "_sourceLTDFilesAddButton";
         this._sourceLTDFilesAddButton.Size = new System.Drawing.Size(75, 23);
         this._sourceLTDFilesAddButton.TabIndex = 0;
         this._sourceLTDFilesAddButton.Text = "A&dd...";
         this._sourceLTDFilesAddButton.UseVisualStyleBackColor = true;
         this._sourceLTDFilesAddButton.Click += new System.EventHandler(this._sourceLTDFilesAddButton_Click);
         // 
         // _outputOptionsTabPage
         // 
         this._outputOptionsTabPage.Controls.Add(this.groupBox1);
         this._outputOptionsTabPage.Controls.Add(this._sourceFileNameGroupBox);
         this._outputOptionsTabPage.Location = new System.Drawing.Point(4, 22);
         this._outputOptionsTabPage.Name = "_outputOptionsTabPage";
         this._outputOptionsTabPage.Padding = new System.Windows.Forms.Padding(3);
         this._outputOptionsTabPage.Size = new System.Drawing.Size(700, 522);
         this._outputOptionsTabPage.TabIndex = 0;
         this._outputOptionsTabPage.Text = "Output options";
         this._outputOptionsTabPage.UseVisualStyleBackColor = true;
         // 
         // groupBox1
         // 
         this.groupBox1.Controls.Add(this._viewDocumentCheckBox);
         this.groupBox1.Controls.Add(this._outputFileNameBrowseButton);
         this.groupBox1.Controls.Add(this._outputFileNameTextBox);
         this.groupBox1.Controls.Add(this._outputFileNameLabel);
         this.groupBox1.Location = new System.Drawing.Point(16, 419);
         this.groupBox1.Name = "groupBox1";
         this.groupBox1.Size = new System.Drawing.Size(665, 93);
         this.groupBox1.TabIndex = 1;
         this.groupBox1.TabStop = false;
         this.groupBox1.Text = "Output file";
         // 
         // _viewDocumentCheckBox
         // 
         this._viewDocumentCheckBox.AutoSize = true;
         this._viewDocumentCheckBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
         this._viewDocumentCheckBox.Location = new System.Drawing.Point(15, 61);
         this._viewDocumentCheckBox.Name = "_viewDocumentCheckBox";
         this._viewDocumentCheckBox.Size = new System.Drawing.Size(121, 17);
         this._viewDocumentCheckBox.TabIndex = 20;
         this._viewDocumentCheckBox.Text = "View final document";
         this._viewDocumentCheckBox.UseVisualStyleBackColor = true;
         // 
         // _outputFileNameBrowseButton
         // 
         this._outputFileNameBrowseButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
         this._outputFileNameBrowseButton.Location = new System.Drawing.Point(364, 22);
         this._outputFileNameBrowseButton.Name = "_outputFileNameBrowseButton";
         this._outputFileNameBrowseButton.Size = new System.Drawing.Size(27, 23);
         this._outputFileNameBrowseButton.TabIndex = 19;
         this._outputFileNameBrowseButton.Text = "...";
         this._outputFileNameBrowseButton.UseVisualStyleBackColor = true;
         this._outputFileNameBrowseButton.Click += new System.EventHandler(this._outputFileNameBrowseButton_Click);
         // 
         // _outputFileNameTextBox
         // 
         this._outputFileNameTextBox.Location = new System.Drawing.Point(105, 24);
         this._outputFileNameTextBox.Name = "_outputFileNameTextBox";
         this._outputFileNameTextBox.Size = new System.Drawing.Size(253, 20);
         this._outputFileNameTextBox.TabIndex = 18;
         this._outputFileNameTextBox.TextChanged += new System.EventHandler(this._outputFileNameTextBox_TextChanged);
         // 
         // _outputFileNameLabel
         // 
         this._outputFileNameLabel.AutoSize = true;
         this._outputFileNameLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
         this._outputFileNameLabel.Location = new System.Drawing.Point(12, 27);
         this._outputFileNameLabel.Name = "_outputFileNameLabel";
         this._outputFileNameLabel.Size = new System.Drawing.Size(91, 13);
         this._outputFileNameLabel.TabIndex = 17;
         this._outputFileNameLabel.Text = "Output file name:";
         // 
         // _sourceFileNameGroupBox
         // 
         this._sourceFileNameGroupBox.Controls.Add(this._documentFormatOptionsControl);
         this._sourceFileNameGroupBox.Location = new System.Drawing.Point(16, 16);
         this._sourceFileNameGroupBox.Name = "_sourceFileNameGroupBox";
         this._sourceFileNameGroupBox.Size = new System.Drawing.Size(665, 397);
         this._sourceFileNameGroupBox.TabIndex = 0;
         this._sourceFileNameGroupBox.TabStop = false;
         this._sourceFileNameGroupBox.Text = "Output format options";
         // 
         // _documentFormatOptionsControl
         // 
         this._documentFormatOptionsControl.Location = new System.Drawing.Point(7, 20);
         this._documentFormatOptionsControl.Name = "_documentFormatOptionsControl";
         this._documentFormatOptionsControl.Size = new System.Drawing.Size(500, 371);
         this._documentFormatOptionsControl.TabIndex = 0;
         // 
         // LTDMergeDialog
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(732, 601);
         this.Controls.Add(this._progressBar);
         this.Controls.Add(this._aboutButton);
         this.Controls.Add(this._previousButton);
         this.Controls.Add(this._nextButton);
         this.Controls.Add(this._exitButton);
         this.Controls.Add(this._mainWizardControl);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.MaximizeBox = false;
         this.Name = "LTDMergeDialog";
         this.Text = "C# LTD Merge Demo";
         this._mainWizardControl.ResumeLayout(false);
         this._sourceLTDFilesTabPage.ResumeLayout(false);
         this._sourceLTDFilesGroupBox.ResumeLayout(false);
         this._sourceLTDFilesGroupBox.PerformLayout();
         this._outputOptionsTabPage.ResumeLayout(false);
         this.groupBox1.ResumeLayout(false);
         this.groupBox1.PerformLayout();
         this._sourceFileNameGroupBox.ResumeLayout(false);
         this.ResumeLayout(false);

      }

      #endregion

      private LTDMergeDemo.WizardControl _mainWizardControl;
      private System.Windows.Forms.TabPage _outputOptionsTabPage;
      private System.Windows.Forms.Button _exitButton;
      private System.Windows.Forms.Button _nextButton;
      private System.Windows.Forms.Button _previousButton;
      private System.Windows.Forms.GroupBox _sourceFileNameGroupBox;
      private System.Windows.Forms.TabPage _sourceLTDFilesTabPage;
      private System.Windows.Forms.GroupBox _sourceLTDFilesGroupBox;
      private System.Windows.Forms.Button _sourceLTDFilesAddButton;
      private System.Windows.Forms.Button _sourceLTDFilesClearButton;
      private System.Windows.Forms.Button _aboutButton;
      private System.Windows.Forms.Button _sourceLTDFilesRemoveButton;
      private System.Windows.Forms.Label _sourceFilesNoteLabel;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.ListView _sourceLTDFileListView;
      private System.Windows.Forms.ColumnHeader _headerFileName;
      private System.Windows.Forms.GroupBox groupBox1;
      private System.Windows.Forms.CheckBox _viewDocumentCheckBox;
      private System.Windows.Forms.Button _outputFileNameBrowseButton;
      private System.Windows.Forms.TextBox _outputFileNameTextBox;
      private System.Windows.Forms.Label _outputFileNameLabel;
      private System.Windows.Forms.Button _moveTopButton;
      private System.Windows.Forms.Button _moveBottomButton;
      private System.Windows.Forms.Button _moveDownButton;
      private System.Windows.Forms.Button _moveUpButton;
      private DocumentFormatOptionsControl _documentFormatOptionsControl;
      private System.Windows.Forms.ProgressBar _progressBar;
      private System.Windows.Forms.ColumnHeader _columnFileType;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.ComboBox _ltdDocumentTypeComboBox;
      private System.Windows.Forms.Label label2;
   }
}