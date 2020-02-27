namespace PDFFileDemo
{
   partial class PDFFileDialog
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PDFFileDialog));
         this._exitButton = new System.Windows.Forms.Button();
         this._nextButton = new System.Windows.Forms.Button();
         this._previousButton = new System.Windows.Forms.Button();
         this._aboutButton = new System.Windows.Forms.Button();
         this._mainWizardControl = new PDFFileDemo.WizardControl();
         this._sourceFileTabPage = new System.Windows.Forms.TabPage();
         this._sourceFileIsPostscriptLabel = new System.Windows.Forms.Label();
         this._sourceFilePropertiesControl = new PDFFileDemo.FilePropertiesControl();
         this._sourceDocumentPropertiesControl = new PDFFileDemo.DocumentPropertiesControl();
         this._sourceFileNameGroupBox = new System.Windows.Forms.GroupBox();
         this._sourceFileNameBrowseButton = new System.Windows.Forms.Button();
         this._sourceFileNameTextBox = new System.Windows.Forms.TextBox();
         this._operationTabPage = new System.Windows.Forms.TabPage();
         this._operationSourcePages = new System.Windows.Forms.GroupBox();
         this._operationPageCountLabel = new System.Windows.Forms.Label();
         this._operationLastPageNumberTextBox = new System.Windows.Forms.TextBox();
         this._operationLastPageNumberLabel = new System.Windows.Forms.Label();
         this._operationFirstPageNumberTextBox = new System.Windows.Forms.TextBox();
         this._operationFirstPageNumberLabel = new System.Windows.Forms.Label();
         this._operationAllPagesCheckBox = new System.Windows.Forms.CheckBox();
         this._operationGroupBox = new System.Windows.Forms.GroupBox();
         this._operationComboBox = new System.Windows.Forms.ComboBox();
         this._destinationFileTabPage = new System.Windows.Forms.TabPage();
         this._signatureFileNameGroupBox = new System.Windows.Forms.GroupBox();
         this._signatureFileNameBrowseButton = new System.Windows.Forms.Button();
         this._signatureFileNameTextBox = new System.Windows.Forms.TextBox();
         this._filePasswordGroupBox = new System.Windows.Forms.GroupBox();
         this._filePasswordTextBox = new System.Windows.Forms.TextBox();
         this._destinationFileInsertPageNumberGroupBox = new System.Windows.Forms.GroupBox();
         this._destinationFileInsertPageNumberTextBox = new System.Windows.Forms.TextBox();
         this._destinationFileInsertPageNoteLabel = new System.Windows.Forms.Label();
         this._destinationFilePropertiesControl = new PDFFileDemo.FilePropertiesControl();
         this._destinationFileUseSourceFileCheckBox = new System.Windows.Forms.CheckBox();
         this._destinationFileNameGroupBox = new System.Windows.Forms.GroupBox();
         this._destinationFileNameBrowseButton = new System.Windows.Forms.Button();
         this._destinationFileNameTextBox = new System.Windows.Forms.TextBox();
         this._sourceFilesTabPage = new System.Windows.Forms.TabPage();
         this._sourceFilesGroupBox = new System.Windows.Forms.GroupBox();
         this._sourceFilesNoteLabel = new System.Windows.Forms.Label();
         this._sourceFilesListBox = new System.Windows.Forms.ListBox();
         this._sourceFilesClearButton = new System.Windows.Forms.Button();
         this._sourceFilesAddButton = new System.Windows.Forms.Button();
         this._optionsTabPage = new System.Windows.Forms.TabPage();
         this._optionsConvertOptionsControl = new PDFFileDemo.ConvertOptionsControl();
         this._distillTabPage = new System.Windows.Forms.TabPage();
         this._distillOptionsGroupBox = new System.Windows.Forms.GroupBox();
         this._distillOptionsAutoRotatePageModeLabel = new System.Windows.Forms.Label();
         this._distillOptionsAutoRotatePageModeComboBox = new System.Windows.Forms.ComboBox();
         this._distillOptionsOutputModeLabel = new System.Windows.Forms.Label();
         this._distillOptionsOutputModeComboBox = new System.Windows.Forms.ComboBox();
         this._distillPDFFileGroupBox = new System.Windows.Forms.GroupBox();
         this._distillPDFFileBrowseButton = new System.Windows.Forms.Button();
         this._distillPDFFileTextBox = new System.Windows.Forms.TextBox();
         this._mainWizardControl.SuspendLayout();
         this._sourceFileTabPage.SuspendLayout();
         this._sourceFileNameGroupBox.SuspendLayout();
         this._operationTabPage.SuspendLayout();
         this._operationSourcePages.SuspendLayout();
         this._operationGroupBox.SuspendLayout();
         this._destinationFileTabPage.SuspendLayout();
         this._signatureFileNameGroupBox.SuspendLayout();
         this._filePasswordGroupBox.SuspendLayout();
         this._destinationFileInsertPageNumberGroupBox.SuspendLayout();
         this._destinationFileNameGroupBox.SuspendLayout();
         this._sourceFilesTabPage.SuspendLayout();
         this._sourceFilesGroupBox.SuspendLayout();
         this._optionsTabPage.SuspendLayout();
         this._distillTabPage.SuspendLayout();
         this._distillOptionsGroupBox.SuspendLayout();
         this._distillPDFFileGroupBox.SuspendLayout();
         this.SuspendLayout();
         // 
         // _exitButton
         // 
         this._exitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this._exitButton.Location = new System.Drawing.Point(641, 582);
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
         this._nextButton.Location = new System.Drawing.Point(545, 582);
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
         this._previousButton.Location = new System.Drawing.Point(464, 582);
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
         this._aboutButton.Location = new System.Drawing.Point(11, 582);
         this._aboutButton.Name = "_aboutButton";
         this._aboutButton.Size = new System.Drawing.Size(75, 23);
         this._aboutButton.TabIndex = 1;
         this._aboutButton.Text = "About...";
         this._aboutButton.UseVisualStyleBackColor = true;
         this._aboutButton.Click += new System.EventHandler(this._aboutButton_Click);
         // 
         // _mainWizardControl
         // 
         this._mainWizardControl.Controls.Add(this._sourceFileTabPage);
         this._mainWizardControl.Controls.Add(this._operationTabPage);
         this._mainWizardControl.Controls.Add(this._destinationFileTabPage);
         this._mainWizardControl.Controls.Add(this._sourceFilesTabPage);
         this._mainWizardControl.Controls.Add(this._optionsTabPage);
         this._mainWizardControl.Controls.Add(this._distillTabPage);
         this._mainWizardControl.Location = new System.Drawing.Point(12, 12);
         this._mainWizardControl.Name = "_mainWizardControl";
         this._mainWizardControl.SelectedIndex = 0;
         this._mainWizardControl.Size = new System.Drawing.Size(708, 566);
         this._mainWizardControl.TabIndex = 0;
         // 
         // _sourceFileTabPage
         // 
         this._sourceFileTabPage.Controls.Add(this._sourceFileIsPostscriptLabel);
         this._sourceFileTabPage.Controls.Add(this._sourceFilePropertiesControl);
         this._sourceFileTabPage.Controls.Add(this._sourceDocumentPropertiesControl);
         this._sourceFileTabPage.Controls.Add(this._sourceFileNameGroupBox);
         this._sourceFileTabPage.Location = new System.Drawing.Point(4, 22);
         this._sourceFileTabPage.Name = "_sourceFileTabPage";
         this._sourceFileTabPage.Padding = new System.Windows.Forms.Padding(3);
         this._sourceFileTabPage.Size = new System.Drawing.Size(700, 454);
         this._sourceFileTabPage.TabIndex = 0;
         this._sourceFileTabPage.Text = "Source File";
         this._sourceFileTabPage.UseVisualStyleBackColor = true;
         // 
         // _sourceFileIsPostscriptLabel
         // 
         this._sourceFileIsPostscriptLabel.AutoSize = true;
         this._sourceFileIsPostscriptLabel.Location = new System.Drawing.Point(18, 96);
         this._sourceFileIsPostscriptLabel.Name = "_sourceFileIsPostscriptLabel";
         this._sourceFileIsPostscriptLabel.Size = new System.Drawing.Size(195, 13);
         this._sourceFileIsPostscriptLabel.TabIndex = 3;
         this._sourceFileIsPostscriptLabel.Text = "File is Postscript or Enhanced Postscript";
         // 
         // _sourceFilePropertiesControl
         // 
         this._sourceFilePropertiesControl.Location = new System.Drawing.Point(18, 96);
         this._sourceFilePropertiesControl.Name = "_sourceFilePropertiesControl";
         this._sourceFilePropertiesControl.Size = new System.Drawing.Size(273, 246);
         this._sourceFilePropertiesControl.TabIndex = 1;
         // 
         // _sourceDocumentPropertiesControl
         // 
         this._sourceDocumentPropertiesControl.Location = new System.Drawing.Point(297, 96);
         this._sourceDocumentPropertiesControl.Name = "_sourceDocumentPropertiesControl";
         this._sourceDocumentPropertiesControl.Size = new System.Drawing.Size(386, 246);
         this._sourceDocumentPropertiesControl.TabIndex = 2;
         // 
         // _sourceFileNameGroupBox
         // 
         this._sourceFileNameGroupBox.Controls.Add(this._sourceFileNameBrowseButton);
         this._sourceFileNameGroupBox.Controls.Add(this._sourceFileNameTextBox);
         this._sourceFileNameGroupBox.Location = new System.Drawing.Point(18, 16);
         this._sourceFileNameGroupBox.Name = "_sourceFileNameGroupBox";
         this._sourceFileNameGroupBox.Size = new System.Drawing.Size(665, 73);
         this._sourceFileNameGroupBox.TabIndex = 0;
         this._sourceFileNameGroupBox.TabStop = false;
         this._sourceFileNameGroupBox.Text = "Select source file:";
         // 
         // _sourceFileNameBrowseButton
         // 
         this._sourceFileNameBrowseButton.Location = new System.Drawing.Point(575, 28);
         this._sourceFileNameBrowseButton.Name = "_sourceFileNameBrowseButton";
         this._sourceFileNameBrowseButton.Size = new System.Drawing.Size(75, 23);
         this._sourceFileNameBrowseButton.TabIndex = 1;
         this._sourceFileNameBrowseButton.Text = "Browse...";
         this._sourceFileNameBrowseButton.UseVisualStyleBackColor = true;
         this._sourceFileNameBrowseButton.Click += new System.EventHandler(this._sourceFileNameBrowseButton_Click);
         // 
         // _sourceFileNameTextBox
         // 
         this._sourceFileNameTextBox.Location = new System.Drawing.Point(15, 30);
         this._sourceFileNameTextBox.Name = "_sourceFileNameTextBox";
         this._sourceFileNameTextBox.ReadOnly = true;
         this._sourceFileNameTextBox.Size = new System.Drawing.Size(554, 20);
         this._sourceFileNameTextBox.TabIndex = 0;
         // 
         // _operationTabPage
         // 
         this._operationTabPage.Controls.Add(this._operationSourcePages);
         this._operationTabPage.Controls.Add(this._operationGroupBox);
         this._operationTabPage.Location = new System.Drawing.Point(4, 22);
         this._operationTabPage.Name = "_operationTabPage";
         this._operationTabPage.Size = new System.Drawing.Size(700, 454);
         this._operationTabPage.TabIndex = 1;
         this._operationTabPage.Text = "Operation";
         this._operationTabPage.UseVisualStyleBackColor = true;
         // 
         // _operationSourcePages
         // 
         this._operationSourcePages.Controls.Add(this._operationPageCountLabel);
         this._operationSourcePages.Controls.Add(this._operationLastPageNumberTextBox);
         this._operationSourcePages.Controls.Add(this._operationLastPageNumberLabel);
         this._operationSourcePages.Controls.Add(this._operationFirstPageNumberTextBox);
         this._operationSourcePages.Controls.Add(this._operationFirstPageNumberLabel);
         this._operationSourcePages.Controls.Add(this._operationAllPagesCheckBox);
         this._operationSourcePages.Location = new System.Drawing.Point(20, 98);
         this._operationSourcePages.Name = "_operationSourcePages";
         this._operationSourcePages.Size = new System.Drawing.Size(661, 95);
         this._operationSourcePages.TabIndex = 1;
         this._operationSourcePages.TabStop = false;
         this._operationSourcePages.Text = "Select the pages to perfrom this operation on:";
         // 
         // _operationPageCountLabel
         // 
         this._operationPageCountLabel.AutoSize = true;
         this._operationPageCountLabel.Location = new System.Drawing.Point(128, 31);
         this._operationPageCountLabel.Name = "_operationPageCountLabel";
         this._operationPageCountLabel.Size = new System.Drawing.Size(132, 13);
         this._operationPageCountLabel.TabIndex = 1;
         this._operationPageCountLabel.Text = "Document has ### pages";
         // 
         // _operationLastPageNumberTextBox
         // 
         this._operationLastPageNumberTextBox.Location = new System.Drawing.Point(353, 55);
         this._operationLastPageNumberTextBox.Name = "_operationLastPageNumberTextBox";
         this._operationLastPageNumberTextBox.Size = new System.Drawing.Size(100, 20);
         this._operationLastPageNumberTextBox.TabIndex = 5;
         // 
         // _operationLastPageNumberLabel
         // 
         this._operationLastPageNumberLabel.AutoSize = true;
         this._operationLastPageNumberLabel.Location = new System.Drawing.Point(253, 58);
         this._operationLastPageNumberLabel.Name = "_operationLastPageNumberLabel";
         this._operationLastPageNumberLabel.Size = new System.Drawing.Size(95, 13);
         this._operationLastPageNumberLabel.TabIndex = 4;
         this._operationLastPageNumberLabel.Text = "Last page number:";
         // 
         // _operationFirstPageNumberTextBox
         // 
         this._operationFirstPageNumberTextBox.Location = new System.Drawing.Point(128, 55);
         this._operationFirstPageNumberTextBox.Name = "_operationFirstPageNumberTextBox";
         this._operationFirstPageNumberTextBox.Size = new System.Drawing.Size(100, 20);
         this._operationFirstPageNumberTextBox.TabIndex = 3;
         // 
         // _operationFirstPageNumberLabel
         // 
         this._operationFirstPageNumberLabel.AutoSize = true;
         this._operationFirstPageNumberLabel.Location = new System.Drawing.Point(24, 58);
         this._operationFirstPageNumberLabel.Name = "_operationFirstPageNumberLabel";
         this._operationFirstPageNumberLabel.Size = new System.Drawing.Size(94, 13);
         this._operationFirstPageNumberLabel.TabIndex = 2;
         this._operationFirstPageNumberLabel.Text = "First page number:";
         // 
         // _operationAllPagesCheckBox
         // 
         this._operationAllPagesCheckBox.AutoSize = true;
         this._operationAllPagesCheckBox.Location = new System.Drawing.Point(27, 31);
         this._operationAllPagesCheckBox.Name = "_operationAllPagesCheckBox";
         this._operationAllPagesCheckBox.Size = new System.Drawing.Size(69, 17);
         this._operationAllPagesCheckBox.TabIndex = 0;
         this._operationAllPagesCheckBox.Text = "All pages";
         this._operationAllPagesCheckBox.UseVisualStyleBackColor = true;
         this._operationAllPagesCheckBox.CheckedChanged += new System.EventHandler(this._operationAllPagesCheckBox_CheckedChanged);
         // 
         // _operationGroupBox
         // 
         this._operationGroupBox.Controls.Add(this._operationComboBox);
         this._operationGroupBox.Location = new System.Drawing.Point(20, 14);
         this._operationGroupBox.Name = "_operationGroupBox";
         this._operationGroupBox.Size = new System.Drawing.Size(661, 78);
         this._operationGroupBox.TabIndex = 0;
         this._operationGroupBox.TabStop = false;
         this._operationGroupBox.Text = "Operation:";
         // 
         // _operationComboBox
         // 
         this._operationComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._operationComboBox.FormattingEnabled = true;
         this._operationComboBox.Location = new System.Drawing.Point(27, 36);
         this._operationComboBox.Name = "_operationComboBox";
         this._operationComboBox.Size = new System.Drawing.Size(613, 21);
         this._operationComboBox.TabIndex = 0;
         this._operationComboBox.SelectedIndexChanged += new System.EventHandler(this._operationComboBox_SelectedIndexChanged);
         // 
         // _destinationFileTabPage
         // 
         this._destinationFileTabPage.Controls.Add(this._signatureFileNameGroupBox);
         this._destinationFileTabPage.Controls.Add(this._filePasswordGroupBox);
         this._destinationFileTabPage.Controls.Add(this._destinationFileInsertPageNumberGroupBox);
         this._destinationFileTabPage.Controls.Add(this._destinationFilePropertiesControl);
         this._destinationFileTabPage.Controls.Add(this._destinationFileUseSourceFileCheckBox);
         this._destinationFileTabPage.Controls.Add(this._destinationFileNameGroupBox);
         this._destinationFileTabPage.Location = new System.Drawing.Point(4, 22);
         this._destinationFileTabPage.Name = "_destinationFileTabPage";
         this._destinationFileTabPage.Size = new System.Drawing.Size(700, 454);
         this._destinationFileTabPage.TabIndex = 2;
         this._destinationFileTabPage.Text = "Destination File";
         this._destinationFileTabPage.UseVisualStyleBackColor = true;
         // 
         // _signatureFileNameGroupBox
         // 
         this._signatureFileNameGroupBox.Controls.Add(this._signatureFileNameBrowseButton);
         this._signatureFileNameGroupBox.Controls.Add(this._signatureFileNameTextBox);
         this._signatureFileNameGroupBox.Location = new System.Drawing.Point(17, 126);
         this._signatureFileNameGroupBox.Name = "_signatureFileNameGroupBox";
         this._signatureFileNameGroupBox.Size = new System.Drawing.Size(665, 73);
         this._signatureFileNameGroupBox.TabIndex = 2;
         this._signatureFileNameGroupBox.TabStop = false;
         this._signatureFileNameGroupBox.Text = "Select signature file:";
         // 
         // _signatureFileNameBrowseButton
         // 
         this._signatureFileNameBrowseButton.Location = new System.Drawing.Point(575, 28);
         this._signatureFileNameBrowseButton.Name = "_signatureFileNameBrowseButton";
         this._signatureFileNameBrowseButton.Size = new System.Drawing.Size(75, 23);
         this._signatureFileNameBrowseButton.TabIndex = 1;
         this._signatureFileNameBrowseButton.Text = "Browse...";
         this._signatureFileNameBrowseButton.UseVisualStyleBackColor = true;
         this._signatureFileNameBrowseButton.Click += new System.EventHandler(this._signatureFileNameBrowseButton_Click);
         // 
         // _signatureFileNameTextBox
         // 
         this._signatureFileNameTextBox.Location = new System.Drawing.Point(15, 30);
         this._signatureFileNameTextBox.Name = "_signatureFileNameTextBox";
         this._signatureFileNameTextBox.ReadOnly = true;
         this._signatureFileNameTextBox.Size = new System.Drawing.Size(554, 20);
         this._signatureFileNameTextBox.TabIndex = 0;
         // 
         // _filePasswordGroupBox
         // 
         this._filePasswordGroupBox.Controls.Add(this._filePasswordTextBox);
         this._filePasswordGroupBox.Location = new System.Drawing.Point(17, 215);
         this._filePasswordGroupBox.Name = "_filePasswordGroupBox";
         this._filePasswordGroupBox.Size = new System.Drawing.Size(665, 73);
         this._filePasswordGroupBox.TabIndex = 4;
         this._filePasswordGroupBox.TabStop = false;
         this._filePasswordGroupBox.Text = "Enter password:";
         // 
         // _filePasswordTextBox
         // 
         this._filePasswordTextBox.Location = new System.Drawing.Point(15, 31);
         this._filePasswordTextBox.Name = "_filePasswordTextBox";
         this._filePasswordTextBox.PasswordChar = '*';
         this._filePasswordTextBox.Size = new System.Drawing.Size(635, 20);
         this._filePasswordTextBox.TabIndex = 0;
         // 
         // _destinationFileInsertPageNumberGroupBox
         // 
         this._destinationFileInsertPageNumberGroupBox.Controls.Add(this._destinationFileInsertPageNumberTextBox);
         this._destinationFileInsertPageNumberGroupBox.Controls.Add(this._destinationFileInsertPageNoteLabel);
         this._destinationFileInsertPageNumberGroupBox.Location = new System.Drawing.Point(297, 117);
         this._destinationFileInsertPageNumberGroupBox.Name = "_destinationFileInsertPageNumberGroupBox";
         this._destinationFileInsertPageNumberGroupBox.Size = new System.Drawing.Size(385, 134);
         this._destinationFileInsertPageNumberGroupBox.TabIndex = 3;
         this._destinationFileInsertPageNumberGroupBox.TabStop = false;
         this._destinationFileInsertPageNumberGroupBox.Text = "Insert page number";
         // 
         // _destinationFileInsertPageNumberTextBox
         // 
         this._destinationFileInsertPageNumberTextBox.Location = new System.Drawing.Point(24, 32);
         this._destinationFileInsertPageNumberTextBox.Name = "_destinationFileInsertPageNumberTextBox";
         this._destinationFileInsertPageNumberTextBox.Size = new System.Drawing.Size(159, 20);
         this._destinationFileInsertPageNumberTextBox.TabIndex = 1;
         // 
         // _destinationFileInsertPageNoteLabel
         // 
         this._destinationFileInsertPageNoteLabel.Location = new System.Drawing.Point(21, 66);
         this._destinationFileInsertPageNoteLabel.Name = "_destinationFileInsertPageNoteLabel";
         this._destinationFileInsertPageNoteLabel.Size = new System.Drawing.Size(349, 49);
         this._destinationFileInsertPageNoteLabel.TabIndex = 0;
         this._destinationFileInsertPageNoteLabel.Text = "0 = Insert the page(s) at the beginning of the file, -1 = insert at the end of th" +
    "e file, otherwise, insert after specified page number.";
         // 
         // _destinationFilePropertiesControl
         // 
         this._destinationFilePropertiesControl.Location = new System.Drawing.Point(17, 117);
         this._destinationFilePropertiesControl.Name = "_destinationFilePropertiesControl";
         this._destinationFilePropertiesControl.Size = new System.Drawing.Size(273, 246);
         this._destinationFilePropertiesControl.TabIndex = 2;
         // 
         // _destinationFileUseSourceFileCheckBox
         // 
         this._destinationFileUseSourceFileCheckBox.AutoSize = true;
         this._destinationFileUseSourceFileCheckBox.Location = new System.Drawing.Point(17, 15);
         this._destinationFileUseSourceFileCheckBox.Name = "_destinationFileUseSourceFileCheckBox";
         this._destinationFileUseSourceFileCheckBox.Size = new System.Drawing.Size(96, 17);
         this._destinationFileUseSourceFileCheckBox.TabIndex = 0;
         this._destinationFileUseSourceFileCheckBox.Text = "Use source file";
         this._destinationFileUseSourceFileCheckBox.UseVisualStyleBackColor = true;
         this._destinationFileUseSourceFileCheckBox.CheckedChanged += new System.EventHandler(this._destinationFileUseSourceFileCheckBox_CheckedChanged);
         // 
         // _destinationFileNameGroupBox
         // 
         this._destinationFileNameGroupBox.Controls.Add(this._destinationFileNameBrowseButton);
         this._destinationFileNameGroupBox.Controls.Add(this._destinationFileNameTextBox);
         this._destinationFileNameGroupBox.Location = new System.Drawing.Point(17, 38);
         this._destinationFileNameGroupBox.Name = "_destinationFileNameGroupBox";
         this._destinationFileNameGroupBox.Size = new System.Drawing.Size(665, 73);
         this._destinationFileNameGroupBox.TabIndex = 1;
         this._destinationFileNameGroupBox.TabStop = false;
         this._destinationFileNameGroupBox.Text = "Select destination file:";
         // 
         // _destinationFileNameBrowseButton
         // 
         this._destinationFileNameBrowseButton.Location = new System.Drawing.Point(575, 28);
         this._destinationFileNameBrowseButton.Name = "_destinationFileNameBrowseButton";
         this._destinationFileNameBrowseButton.Size = new System.Drawing.Size(75, 23);
         this._destinationFileNameBrowseButton.TabIndex = 1;
         this._destinationFileNameBrowseButton.Text = "Browse...";
         this._destinationFileNameBrowseButton.UseVisualStyleBackColor = true;
         this._destinationFileNameBrowseButton.Click += new System.EventHandler(this._destinationFileNameBrowseButton_Click);
         // 
         // _destinationFileNameTextBox
         // 
         this._destinationFileNameTextBox.Location = new System.Drawing.Point(15, 30);
         this._destinationFileNameTextBox.Name = "_destinationFileNameTextBox";
         this._destinationFileNameTextBox.ReadOnly = true;
         this._destinationFileNameTextBox.Size = new System.Drawing.Size(554, 20);
         this._destinationFileNameTextBox.TabIndex = 0;
         // 
         // _sourceFilesTabPage
         // 
         this._sourceFilesTabPage.Controls.Add(this._sourceFilesGroupBox);
         this._sourceFilesTabPage.Location = new System.Drawing.Point(4, 22);
         this._sourceFilesTabPage.Name = "_sourceFilesTabPage";
         this._sourceFilesTabPage.Size = new System.Drawing.Size(700, 454);
         this._sourceFilesTabPage.TabIndex = 4;
         this._sourceFilesTabPage.Text = "Source files";
         this._sourceFilesTabPage.UseVisualStyleBackColor = true;
         // 
         // _sourceFilesGroupBox
         // 
         this._sourceFilesGroupBox.Controls.Add(this._sourceFilesNoteLabel);
         this._sourceFilesGroupBox.Controls.Add(this._sourceFilesListBox);
         this._sourceFilesGroupBox.Controls.Add(this._sourceFilesClearButton);
         this._sourceFilesGroupBox.Controls.Add(this._sourceFilesAddButton);
         this._sourceFilesGroupBox.Location = new System.Drawing.Point(17, 18);
         this._sourceFilesGroupBox.Name = "_sourceFilesGroupBox";
         this._sourceFilesGroupBox.Size = new System.Drawing.Size(665, 319);
         this._sourceFilesGroupBox.TabIndex = 0;
         this._sourceFilesGroupBox.TabStop = false;
         this._sourceFilesGroupBox.Text = "Select source files:";
         // 
         // _sourceFilesNoteLabel
         // 
         this._sourceFilesNoteLabel.Location = new System.Drawing.Point(101, 235);
         this._sourceFilesNoteLabel.Name = "_sourceFilesNoteLabel";
         this._sourceFilesNoteLabel.Size = new System.Drawing.Size(544, 81);
         this._sourceFilesNoteLabel.TabIndex = 3;
         this._sourceFilesNoteLabel.Text = "Files will be merged in the following order: Source file selected in the previous" +
    " page first, then the files in the list box above in the order they are entered." +
    "";
         // 
         // _sourceFilesListBox
         // 
         this._sourceFilesListBox.FormattingEnabled = true;
         this._sourceFilesListBox.Location = new System.Drawing.Point(101, 29);
         this._sourceFilesListBox.Name = "_sourceFilesListBox";
         this._sourceFilesListBox.Size = new System.Drawing.Size(544, 199);
         this._sourceFilesListBox.TabIndex = 2;
         // 
         // _sourceFilesClearButton
         // 
         this._sourceFilesClearButton.Location = new System.Drawing.Point(19, 58);
         this._sourceFilesClearButton.Name = "_sourceFilesClearButton";
         this._sourceFilesClearButton.Size = new System.Drawing.Size(75, 23);
         this._sourceFilesClearButton.TabIndex = 1;
         this._sourceFilesClearButton.Text = "Clear";
         this._sourceFilesClearButton.UseVisualStyleBackColor = true;
         this._sourceFilesClearButton.Click += new System.EventHandler(this._sourceFilesClearButton_Click);
         // 
         // _sourceFilesAddButton
         // 
         this._sourceFilesAddButton.Location = new System.Drawing.Point(19, 29);
         this._sourceFilesAddButton.Name = "_sourceFilesAddButton";
         this._sourceFilesAddButton.Size = new System.Drawing.Size(75, 23);
         this._sourceFilesAddButton.TabIndex = 0;
         this._sourceFilesAddButton.Text = "Add...";
         this._sourceFilesAddButton.UseVisualStyleBackColor = true;
         this._sourceFilesAddButton.Click += new System.EventHandler(this._sourceFilesAddButton_Click);
         // 
         // _optionsTabPage
         // 
         this._optionsTabPage.Controls.Add(this._optionsConvertOptionsControl);
         this._optionsTabPage.Location = new System.Drawing.Point(4, 22);
         this._optionsTabPage.Name = "_optionsTabPage";
         this._optionsTabPage.Size = new System.Drawing.Size(700, 540);
         this._optionsTabPage.TabIndex = 3;
         this._optionsTabPage.Text = "Options";
         this._optionsTabPage.UseVisualStyleBackColor = true;
         // 
         // _optionsConvertOptionsControl
         // 
         this._optionsConvertOptionsControl.Location = new System.Drawing.Point(3, 9);
         this._optionsConvertOptionsControl.Name = "_optionsConvertOptionsControl";
         this._optionsConvertOptionsControl.Size = new System.Drawing.Size(672, 531);
         this._optionsConvertOptionsControl.TabIndex = 1;
         // 
         // _distillTabPage
         // 
         this._distillTabPage.Controls.Add(this._distillOptionsGroupBox);
         this._distillTabPage.Controls.Add(this._distillPDFFileGroupBox);
         this._distillTabPage.Location = new System.Drawing.Point(4, 22);
         this._distillTabPage.Name = "_distillTabPage";
         this._distillTabPage.Padding = new System.Windows.Forms.Padding(3);
         this._distillTabPage.Size = new System.Drawing.Size(700, 454);
         this._distillTabPage.TabIndex = 5;
         this._distillTabPage.Text = "Distill";
         this._distillTabPage.UseVisualStyleBackColor = true;
         // 
         // _distillOptionsGroupBox
         // 
         this._distillOptionsGroupBox.Controls.Add(this._distillOptionsAutoRotatePageModeLabel);
         this._distillOptionsGroupBox.Controls.Add(this._distillOptionsAutoRotatePageModeComboBox);
         this._distillOptionsGroupBox.Controls.Add(this._distillOptionsOutputModeLabel);
         this._distillOptionsGroupBox.Controls.Add(this._distillOptionsOutputModeComboBox);
         this._distillOptionsGroupBox.Location = new System.Drawing.Point(16, 96);
         this._distillOptionsGroupBox.Name = "_distillOptionsGroupBox";
         this._distillOptionsGroupBox.Size = new System.Drawing.Size(665, 191);
         this._distillOptionsGroupBox.TabIndex = 1;
         this._distillOptionsGroupBox.TabStop = false;
         this._distillOptionsGroupBox.Text = "Distiller options:";
         // 
         // _distillOptionsAutoRotatePageModeLabel
         // 
         this._distillOptionsAutoRotatePageModeLabel.AutoSize = true;
         this._distillOptionsAutoRotatePageModeLabel.Location = new System.Drawing.Point(25, 59);
         this._distillOptionsAutoRotatePageModeLabel.Name = "_distillOptionsAutoRotatePageModeLabel";
         this._distillOptionsAutoRotatePageModeLabel.Size = new System.Drawing.Size(118, 13);
         this._distillOptionsAutoRotatePageModeLabel.TabIndex = 2;
         this._distillOptionsAutoRotatePageModeLabel.Text = "Auto rotate page mode:";
         // 
         // _distillOptionsAutoRotatePageModeComboBox
         // 
         this._distillOptionsAutoRotatePageModeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._distillOptionsAutoRotatePageModeComboBox.FormattingEnabled = true;
         this._distillOptionsAutoRotatePageModeComboBox.Location = new System.Drawing.Point(149, 56);
         this._distillOptionsAutoRotatePageModeComboBox.Name = "_distillOptionsAutoRotatePageModeComboBox";
         this._distillOptionsAutoRotatePageModeComboBox.Size = new System.Drawing.Size(501, 21);
         this._distillOptionsAutoRotatePageModeComboBox.TabIndex = 3;
         // 
         // _distillOptionsOutputModeLabel
         // 
         this._distillOptionsOutputModeLabel.AutoSize = true;
         this._distillOptionsOutputModeLabel.Location = new System.Drawing.Point(25, 32);
         this._distillOptionsOutputModeLabel.Name = "_distillOptionsOutputModeLabel";
         this._distillOptionsOutputModeLabel.Size = new System.Drawing.Size(71, 13);
         this._distillOptionsOutputModeLabel.TabIndex = 0;
         this._distillOptionsOutputModeLabel.Text = "Output mode:";
         // 
         // _distillOptionsOutputModeComboBox
         // 
         this._distillOptionsOutputModeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._distillOptionsOutputModeComboBox.FormattingEnabled = true;
         this._distillOptionsOutputModeComboBox.Location = new System.Drawing.Point(149, 29);
         this._distillOptionsOutputModeComboBox.Name = "_distillOptionsOutputModeComboBox";
         this._distillOptionsOutputModeComboBox.Size = new System.Drawing.Size(501, 21);
         this._distillOptionsOutputModeComboBox.TabIndex = 1;
         // 
         // _distillPDFFileGroupBox
         // 
         this._distillPDFFileGroupBox.Controls.Add(this._distillPDFFileBrowseButton);
         this._distillPDFFileGroupBox.Controls.Add(this._distillPDFFileTextBox);
         this._distillPDFFileGroupBox.Location = new System.Drawing.Point(16, 17);
         this._distillPDFFileGroupBox.Name = "_distillPDFFileGroupBox";
         this._distillPDFFileGroupBox.Size = new System.Drawing.Size(665, 73);
         this._distillPDFFileGroupBox.TabIndex = 0;
         this._distillPDFFileGroupBox.TabStop = false;
         this._distillPDFFileGroupBox.Text = "Select PDF file name to create: ";
         // 
         // _distillPDFFileBrowseButton
         // 
         this._distillPDFFileBrowseButton.Location = new System.Drawing.Point(575, 28);
         this._distillPDFFileBrowseButton.Name = "_distillPDFFileBrowseButton";
         this._distillPDFFileBrowseButton.Size = new System.Drawing.Size(75, 23);
         this._distillPDFFileBrowseButton.TabIndex = 1;
         this._distillPDFFileBrowseButton.Text = "Browse...";
         this._distillPDFFileBrowseButton.UseVisualStyleBackColor = true;
         this._distillPDFFileBrowseButton.Click += new System.EventHandler(this._distillPDFFileBrowseButton_Click);
         // 
         // _distillPDFFileTextBox
         // 
         this._distillPDFFileTextBox.Location = new System.Drawing.Point(15, 30);
         this._distillPDFFileTextBox.Name = "_distillPDFFileTextBox";
         this._distillPDFFileTextBox.ReadOnly = true;
         this._distillPDFFileTextBox.Size = new System.Drawing.Size(554, 20);
         this._distillPDFFileTextBox.TabIndex = 0;
         // 
         // PDFFileDialog
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(732, 617);
         this.Controls.Add(this._aboutButton);
         this.Controls.Add(this._previousButton);
         this.Controls.Add(this._nextButton);
         this.Controls.Add(this._exitButton);
         this.Controls.Add(this._mainWizardControl);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.MaximizeBox = false;
         this.Name = "PDFFileDialog";
         this.Text = "PDFFileDialog";
         this._mainWizardControl.ResumeLayout(false);
         this._sourceFileTabPage.ResumeLayout(false);
         this._sourceFileTabPage.PerformLayout();
         this._sourceFileNameGroupBox.ResumeLayout(false);
         this._sourceFileNameGroupBox.PerformLayout();
         this._operationTabPage.ResumeLayout(false);
         this._operationSourcePages.ResumeLayout(false);
         this._operationSourcePages.PerformLayout();
         this._operationGroupBox.ResumeLayout(false);
         this._destinationFileTabPage.ResumeLayout(false);
         this._destinationFileTabPage.PerformLayout();
         this._signatureFileNameGroupBox.ResumeLayout(false);
         this._signatureFileNameGroupBox.PerformLayout();
         this._filePasswordGroupBox.ResumeLayout(false);
         this._filePasswordGroupBox.PerformLayout();
         this._destinationFileInsertPageNumberGroupBox.ResumeLayout(false);
         this._destinationFileInsertPageNumberGroupBox.PerformLayout();
         this._destinationFileNameGroupBox.ResumeLayout(false);
         this._destinationFileNameGroupBox.PerformLayout();
         this._sourceFilesTabPage.ResumeLayout(false);
         this._sourceFilesGroupBox.ResumeLayout(false);
         this._optionsTabPage.ResumeLayout(false);
         this._distillTabPage.ResumeLayout(false);
         this._distillOptionsGroupBox.ResumeLayout(false);
         this._distillOptionsGroupBox.PerformLayout();
         this._distillPDFFileGroupBox.ResumeLayout(false);
         this._distillPDFFileGroupBox.PerformLayout();
         this.ResumeLayout(false);

      }

      #endregion

      private PDFFileDemo.WizardControl _mainWizardControl;
      private System.Windows.Forms.TabPage _sourceFileTabPage;
      private System.Windows.Forms.Button _exitButton;
      private System.Windows.Forms.Button _nextButton;
      private System.Windows.Forms.Button _previousButton;
      private System.Windows.Forms.GroupBox _sourceFileNameGroupBox;
      private System.Windows.Forms.Button _sourceFileNameBrowseButton;
      private System.Windows.Forms.TextBox _sourceFileNameTextBox;
      private DocumentPropertiesControl _sourceDocumentPropertiesControl;
      private FilePropertiesControl _sourceFilePropertiesControl;
      private System.Windows.Forms.TabPage _operationTabPage;
      private System.Windows.Forms.GroupBox _operationGroupBox;
      private System.Windows.Forms.GroupBox _operationSourcePages;
      private System.Windows.Forms.ComboBox _operationComboBox;
      private System.Windows.Forms.CheckBox _operationAllPagesCheckBox;
      private System.Windows.Forms.Label _operationFirstPageNumberLabel;
      private System.Windows.Forms.TextBox _operationFirstPageNumberTextBox;
      private System.Windows.Forms.TextBox _operationLastPageNumberTextBox;
      private System.Windows.Forms.Label _operationLastPageNumberLabel;
      private System.Windows.Forms.Label _operationPageCountLabel;
      private System.Windows.Forms.TabPage _destinationFileTabPage;
      private System.Windows.Forms.GroupBox _destinationFileNameGroupBox;
      private System.Windows.Forms.Button _destinationFileNameBrowseButton;
      private System.Windows.Forms.TextBox _destinationFileNameTextBox;
      private System.Windows.Forms.CheckBox _destinationFileUseSourceFileCheckBox;
      private FilePropertiesControl _destinationFilePropertiesControl;
      private System.Windows.Forms.GroupBox _destinationFileInsertPageNumberGroupBox;
      private System.Windows.Forms.Label _destinationFileInsertPageNoteLabel;
      private System.Windows.Forms.TextBox _destinationFileInsertPageNumberTextBox;
      private System.Windows.Forms.TabPage _optionsTabPage;
      private System.Windows.Forms.TabPage _sourceFilesTabPage;
      private System.Windows.Forms.GroupBox _sourceFilesGroupBox;
      private System.Windows.Forms.Button _sourceFilesAddButton;
      private System.Windows.Forms.Button _sourceFilesClearButton;
      private System.Windows.Forms.Label _sourceFilesNoteLabel;
      private System.Windows.Forms.ListBox _sourceFilesListBox;
      private System.Windows.Forms.Button _aboutButton;
      private System.Windows.Forms.Label _sourceFileIsPostscriptLabel;
      private System.Windows.Forms.TabPage _distillTabPage;
      private System.Windows.Forms.GroupBox _distillPDFFileGroupBox;
      private System.Windows.Forms.Button _distillPDFFileBrowseButton;
      private System.Windows.Forms.TextBox _distillPDFFileTextBox;
      private System.Windows.Forms.GroupBox _distillOptionsGroupBox;
      private System.Windows.Forms.Label _distillOptionsOutputModeLabel;
      private System.Windows.Forms.ComboBox _distillOptionsOutputModeComboBox;
      private System.Windows.Forms.Label _distillOptionsAutoRotatePageModeLabel;
      private System.Windows.Forms.ComboBox _distillOptionsAutoRotatePageModeComboBox;
      private ConvertOptionsControl _optionsConvertOptionsControl;
      private System.Windows.Forms.GroupBox _filePasswordGroupBox;
      private System.Windows.Forms.TextBox _filePasswordTextBox;
      private System.Windows.Forms.GroupBox _signatureFileNameGroupBox;
      private System.Windows.Forms.Button _signatureFileNameBrowseButton;
      private System.Windows.Forms.TextBox _signatureFileNameTextBox;
   }
}