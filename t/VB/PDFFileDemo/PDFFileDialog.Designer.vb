Imports Microsoft.VisualBasic
Imports System
Namespace PDFFileDemo
   Partial Public Class PDFFileDialog
      ''' <summary>
      ''' Required designer variable.
      ''' </summary>
      Private components As System.ComponentModel.IContainer = Nothing

      ''' <summary>
      ''' Clean up any resources being used.
      ''' </summary>
      ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      Protected Overrides Sub Dispose(ByVal disposing As Boolean)
         If disposing AndAlso (Not components Is Nothing) Then
            components.Dispose()
         End If
         MyBase.Dispose(disposing)
      End Sub

#Region "Windows Form Designer generated code"

      ''' <summary>
      ''' Required method for Designer support - do not modify
      ''' the contents of this method with the code editor.
      ''' </summary>
      Private Sub InitializeComponent()
         Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PDFFileDialog))
         Me._exitButton = New System.Windows.Forms.Button()
         Me._nextButton = New System.Windows.Forms.Button()
         Me._previousButton = New System.Windows.Forms.Button()
         Me._aboutButton = New System.Windows.Forms.Button()
         Me._mainWizardControl = New PDFFileDemo.WizardControl()
         Me._sourceFileTabPage = New System.Windows.Forms.TabPage()
         Me._sourceFileIsPostscriptLabel = New System.Windows.Forms.Label()
         Me._sourceFilePropertiesControl = New PDFFileDemo.FilePropertiesControl()
         Me._sourceDocumentPropertiesControl = New PDFFileDemo.DocumentPropertiesControl()
         Me._sourceFileNameGroupBox = New System.Windows.Forms.GroupBox()
         Me._sourceFileNameBrowseButton = New System.Windows.Forms.Button()
         Me._sourceFileNameTextBox = New System.Windows.Forms.TextBox()
         Me._operationTabPage = New System.Windows.Forms.TabPage()
         Me._operationSourcePages = New System.Windows.Forms.GroupBox()
         Me._operationPageCountLabel = New System.Windows.Forms.Label()
         Me._operationLastPageNumberTextBox = New System.Windows.Forms.TextBox()
         Me._operationLastPageNumberLabel = New System.Windows.Forms.Label()
         Me._operationFirstPageNumberTextBox = New System.Windows.Forms.TextBox()
         Me._operationFirstPageNumberLabel = New System.Windows.Forms.Label()
         Me._operationAllPagesCheckBox = New System.Windows.Forms.CheckBox()
         Me._operationGroupBox = New System.Windows.Forms.GroupBox()
         Me._operationComboBox = New System.Windows.Forms.ComboBox()
         Me._destinationFileTabPage = New System.Windows.Forms.TabPage()
         Me._signatureFileNameGroupBox = New System.Windows.Forms.GroupBox()
         Me._signatureFileNameBrowseButton = New System.Windows.Forms.Button()
         Me._signatureFileNameTextBox = New System.Windows.Forms.TextBox()
         Me._filePasswordGroupBox = New System.Windows.Forms.GroupBox()
         Me._filePasswordTextBox = New System.Windows.Forms.TextBox()
         Me._destinationFileInsertPageNumberGroupBox = New System.Windows.Forms.GroupBox()
         Me._destinationFileInsertPageNumberTextBox = New System.Windows.Forms.TextBox()
         Me._destinationFileInsertPageNoteLabel = New System.Windows.Forms.Label()
         Me._destinationFilePropertiesControl = New PDFFileDemo.FilePropertiesControl()
         Me._destinationFileUseSourceFileCheckBox = New System.Windows.Forms.CheckBox()
         Me._destinationFileNameGroupBox = New System.Windows.Forms.GroupBox()
         Me._destinationFileNameBrowseButton = New System.Windows.Forms.Button()
         Me._destinationFileNameTextBox = New System.Windows.Forms.TextBox()
         Me._sourceFilesTabPage = New System.Windows.Forms.TabPage()
         Me._sourceFilesGroupBox = New System.Windows.Forms.GroupBox()
         Me._sourceFilesNoteLabel = New System.Windows.Forms.Label()
         Me._sourceFilesListBox = New System.Windows.Forms.ListBox()
         Me._sourceFilesClearButton = New System.Windows.Forms.Button()
         Me._sourceFilesAddButton = New System.Windows.Forms.Button()
         Me._optionsTabPage = New System.Windows.Forms.TabPage()
         Me._optionsConvertOptionsControl = New PDFFileDemo.ConvertOptionsControl()
         Me._distillTabPage = New System.Windows.Forms.TabPage()
         Me._distillOptionsGroupBox = New System.Windows.Forms.GroupBox()
         Me._distillOptionsAutoRotatePageModeLabel = New System.Windows.Forms.Label()
         Me._distillOptionsAutoRotatePageModeComboBox = New System.Windows.Forms.ComboBox()
         Me._distillOptionsOutputModeLabel = New System.Windows.Forms.Label()
         Me._distillOptionsOutputModeComboBox = New System.Windows.Forms.ComboBox()
         Me._distillPDFFileGroupBox = New System.Windows.Forms.GroupBox()
         Me._distillPDFFileBrowseButton = New System.Windows.Forms.Button()
         Me._distillPDFFileTextBox = New System.Windows.Forms.TextBox()
         Me._mainWizardControl.SuspendLayout()
         Me._sourceFileTabPage.SuspendLayout()
         Me._sourceFileNameGroupBox.SuspendLayout()
         Me._operationTabPage.SuspendLayout()
         Me._operationSourcePages.SuspendLayout()
         Me._operationGroupBox.SuspendLayout()
         Me._destinationFileTabPage.SuspendLayout()
         Me._signatureFileNameGroupBox.SuspendLayout()
         Me._filePasswordGroupBox.SuspendLayout()
         Me._destinationFileInsertPageNumberGroupBox.SuspendLayout()
         Me._destinationFileNameGroupBox.SuspendLayout()
         Me._sourceFilesTabPage.SuspendLayout()
         Me._sourceFilesGroupBox.SuspendLayout()
         Me._optionsTabPage.SuspendLayout()
         Me._distillTabPage.SuspendLayout()
         Me._distillOptionsGroupBox.SuspendLayout()
         Me._distillPDFFileGroupBox.SuspendLayout()
         Me.SuspendLayout()
         ' 
         ' _exitButton
         ' 
         Me._exitButton.Anchor = (CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
         Me._exitButton.Location = New System.Drawing.Point(641, 582)
         Me._exitButton.Name = "_exitButton"
         Me._exitButton.Size = New System.Drawing.Size(75, 23)
         Me._exitButton.TabIndex = 4
         Me._exitButton.Text = "E&xit"
         Me._exitButton.UseVisualStyleBackColor = True
         '		 Me._exitButton.Click += New System.EventHandler(Me._exitButton_Click);
         ' 
         ' _nextButton
         ' 
         Me._nextButton.Anchor = (CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
         Me._nextButton.Location = New System.Drawing.Point(545, 582)
         Me._nextButton.Name = "_nextButton"
         Me._nextButton.Size = New System.Drawing.Size(75, 23)
         Me._nextButton.TabIndex = 3
         Me._nextButton.Text = "&Next"
         Me._nextButton.UseVisualStyleBackColor = True
         '		 Me._nextButton.Click += New System.EventHandler(Me._nextButton_Click);
         ' 
         ' _previousButton
         ' 
         Me._previousButton.Anchor = (CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
         Me._previousButton.Location = New System.Drawing.Point(464, 582)
         Me._previousButton.Name = "_previousButton"
         Me._previousButton.Size = New System.Drawing.Size(75, 23)
         Me._previousButton.TabIndex = 2
         Me._previousButton.Text = "&Previous"
         Me._previousButton.UseVisualStyleBackColor = True
         '		 Me._previousButton.Click += New System.EventHandler(Me._previousButton_Click);
         ' 
         ' _aboutButton
         ' 
         Me._aboutButton.Anchor = (CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles))
         Me._aboutButton.Location = New System.Drawing.Point(11, 582)
         Me._aboutButton.Name = "_aboutButton"
         Me._aboutButton.Size = New System.Drawing.Size(75, 23)
         Me._aboutButton.TabIndex = 1
         Me._aboutButton.Text = "About..."
         Me._aboutButton.UseVisualStyleBackColor = True
         '		 Me._aboutButton.Click += New System.EventHandler(Me._aboutButton_Click);
         ' 
         ' _mainWizardControl
         ' 
         Me._mainWizardControl.Controls.Add(Me._sourceFileTabPage)
         Me._mainWizardControl.Controls.Add(Me._operationTabPage)
         Me._mainWizardControl.Controls.Add(Me._destinationFileTabPage)
         Me._mainWizardControl.Controls.Add(Me._sourceFilesTabPage)
         Me._mainWizardControl.Controls.Add(Me._optionsTabPage)
         Me._mainWizardControl.Controls.Add(Me._distillTabPage)
         Me._mainWizardControl.Location = New System.Drawing.Point(12, 12)
         Me._mainWizardControl.Name = "_mainWizardControl"
         Me._mainWizardControl.SelectedIndex = 0
         Me._mainWizardControl.Size = New System.Drawing.Size(708, 566)
         Me._mainWizardControl.TabIndex = 0
         ' 
         ' _sourceFileTabPage
         ' 
         Me._sourceFileTabPage.Controls.Add(Me._sourceFileIsPostscriptLabel)
         Me._sourceFileTabPage.Controls.Add(Me._sourceFilePropertiesControl)
         Me._sourceFileTabPage.Controls.Add(Me._sourceDocumentPropertiesControl)
         Me._sourceFileTabPage.Controls.Add(Me._sourceFileNameGroupBox)
         Me._sourceFileTabPage.Location = New System.Drawing.Point(4, 22)
         Me._sourceFileTabPage.Name = "_sourceFileTabPage"
         Me._sourceFileTabPage.Padding = New System.Windows.Forms.Padding(3)
         Me._sourceFileTabPage.Size = New System.Drawing.Size(700, 454)
         Me._sourceFileTabPage.TabIndex = 0
         Me._sourceFileTabPage.Text = "Source File"
         Me._sourceFileTabPage.UseVisualStyleBackColor = True
         ' 
         ' _sourceFileIsPostscriptLabel
         ' 
         Me._sourceFileIsPostscriptLabel.AutoSize = True
         Me._sourceFileIsPostscriptLabel.Location = New System.Drawing.Point(18, 96)
         Me._sourceFileIsPostscriptLabel.Name = "_sourceFileIsPostscriptLabel"
         Me._sourceFileIsPostscriptLabel.Size = New System.Drawing.Size(195, 13)
         Me._sourceFileIsPostscriptLabel.TabIndex = 3
         Me._sourceFileIsPostscriptLabel.Text = "File is Postscript or Enhanced Postscript"
         ' 
         ' _sourceFilePropertiesControl
         ' 
         Me._sourceFilePropertiesControl.Location = New System.Drawing.Point(18, 96)
         Me._sourceFilePropertiesControl.Name = "_sourceFilePropertiesControl"
         Me._sourceFilePropertiesControl.Size = New System.Drawing.Size(273, 246)
         Me._sourceFilePropertiesControl.TabIndex = 1
         ' 
         ' _sourceDocumentPropertiesControl
         ' 
         Me._sourceDocumentPropertiesControl.Location = New System.Drawing.Point(297, 96)
         Me._sourceDocumentPropertiesControl.Name = "_sourceDocumentPropertiesControl"
         Me._sourceDocumentPropertiesControl.Size = New System.Drawing.Size(386, 246)
         Me._sourceDocumentPropertiesControl.TabIndex = 2
         ' 
         ' _sourceFileNameGroupBox
         ' 
         Me._sourceFileNameGroupBox.Controls.Add(Me._sourceFileNameBrowseButton)
         Me._sourceFileNameGroupBox.Controls.Add(Me._sourceFileNameTextBox)
         Me._sourceFileNameGroupBox.Location = New System.Drawing.Point(18, 16)
         Me._sourceFileNameGroupBox.Name = "_sourceFileNameGroupBox"
         Me._sourceFileNameGroupBox.Size = New System.Drawing.Size(665, 73)
         Me._sourceFileNameGroupBox.TabIndex = 0
         Me._sourceFileNameGroupBox.TabStop = False
         Me._sourceFileNameGroupBox.Text = "Select source file:"
         ' 
         ' _sourceFileNameBrowseButton
         ' 
         Me._sourceFileNameBrowseButton.Location = New System.Drawing.Point(575, 28)
         Me._sourceFileNameBrowseButton.Name = "_sourceFileNameBrowseButton"
         Me._sourceFileNameBrowseButton.Size = New System.Drawing.Size(75, 23)
         Me._sourceFileNameBrowseButton.TabIndex = 1
         Me._sourceFileNameBrowseButton.Text = "Browse..."
         Me._sourceFileNameBrowseButton.UseVisualStyleBackColor = True
         '		 Me._sourceFileNameBrowseButton.Click += New System.EventHandler(Me._sourceFileNameBrowseButton_Click);
         ' 
         ' _sourceFileNameTextBox
         ' 
         Me._sourceFileNameTextBox.Location = New System.Drawing.Point(15, 30)
         Me._sourceFileNameTextBox.Name = "_sourceFileNameTextBox"
         Me._sourceFileNameTextBox.ReadOnly = True
         Me._sourceFileNameTextBox.Size = New System.Drawing.Size(554, 20)
         Me._sourceFileNameTextBox.TabIndex = 0
         ' 
         ' _operationTabPage
         ' 
         Me._operationTabPage.Controls.Add(Me._operationSourcePages)
         Me._operationTabPage.Controls.Add(Me._operationGroupBox)
         Me._operationTabPage.Location = New System.Drawing.Point(4, 22)
         Me._operationTabPage.Name = "_operationTabPage"
         Me._operationTabPage.Size = New System.Drawing.Size(700, 454)
         Me._operationTabPage.TabIndex = 1
         Me._operationTabPage.Text = "Operation"
         Me._operationTabPage.UseVisualStyleBackColor = True
         ' 
         ' _operationSourcePages
         ' 
         Me._operationSourcePages.Controls.Add(Me._operationPageCountLabel)
         Me._operationSourcePages.Controls.Add(Me._operationLastPageNumberTextBox)
         Me._operationSourcePages.Controls.Add(Me._operationLastPageNumberLabel)
         Me._operationSourcePages.Controls.Add(Me._operationFirstPageNumberTextBox)
         Me._operationSourcePages.Controls.Add(Me._operationFirstPageNumberLabel)
         Me._operationSourcePages.Controls.Add(Me._operationAllPagesCheckBox)
         Me._operationSourcePages.Location = New System.Drawing.Point(20, 98)
         Me._operationSourcePages.Name = "_operationSourcePages"
         Me._operationSourcePages.Size = New System.Drawing.Size(661, 95)
         Me._operationSourcePages.TabIndex = 1
         Me._operationSourcePages.TabStop = False
         Me._operationSourcePages.Text = "Select the pages to perfrom this operation on:"
         ' 
         ' _operationPageCountLabel
         ' 
         Me._operationPageCountLabel.AutoSize = True
         Me._operationPageCountLabel.Location = New System.Drawing.Point(128, 31)
         Me._operationPageCountLabel.Name = "_operationPageCountLabel"
         Me._operationPageCountLabel.Size = New System.Drawing.Size(132, 13)
         Me._operationPageCountLabel.TabIndex = 1
         Me._operationPageCountLabel.Text = "Document has ### pages"
         ' 
         ' _operationLastPageNumberTextBox
         ' 
         Me._operationLastPageNumberTextBox.Location = New System.Drawing.Point(353, 55)
         Me._operationLastPageNumberTextBox.Name = "_operationLastPageNumberTextBox"
         Me._operationLastPageNumberTextBox.Size = New System.Drawing.Size(100, 20)
         Me._operationLastPageNumberTextBox.TabIndex = 5
         ' 
         ' _operationLastPageNumberLabel
         ' 
         Me._operationLastPageNumberLabel.AutoSize = True
         Me._operationLastPageNumberLabel.Location = New System.Drawing.Point(253, 58)
         Me._operationLastPageNumberLabel.Name = "_operationLastPageNumberLabel"
         Me._operationLastPageNumberLabel.Size = New System.Drawing.Size(95, 13)
         Me._operationLastPageNumberLabel.TabIndex = 4
         Me._operationLastPageNumberLabel.Text = "Last page number:"
         ' 
         ' _operationFirstPageNumberTextBox
         ' 
         Me._operationFirstPageNumberTextBox.Location = New System.Drawing.Point(128, 55)
         Me._operationFirstPageNumberTextBox.Name = "_operationFirstPageNumberTextBox"
         Me._operationFirstPageNumberTextBox.Size = New System.Drawing.Size(100, 20)
         Me._operationFirstPageNumberTextBox.TabIndex = 3
         ' 
         ' _operationFirstPageNumberLabel
         ' 
         Me._operationFirstPageNumberLabel.AutoSize = True
         Me._operationFirstPageNumberLabel.Location = New System.Drawing.Point(24, 58)
         Me._operationFirstPageNumberLabel.Name = "_operationFirstPageNumberLabel"
         Me._operationFirstPageNumberLabel.Size = New System.Drawing.Size(94, 13)
         Me._operationFirstPageNumberLabel.TabIndex = 2
         Me._operationFirstPageNumberLabel.Text = "First page number:"
         ' 
         ' _operationAllPagesCheckBox
         ' 
         Me._operationAllPagesCheckBox.AutoSize = True
         Me._operationAllPagesCheckBox.Location = New System.Drawing.Point(27, 31)
         Me._operationAllPagesCheckBox.Name = "_operationAllPagesCheckBox"
         Me._operationAllPagesCheckBox.Size = New System.Drawing.Size(69, 17)
         Me._operationAllPagesCheckBox.TabIndex = 0
         Me._operationAllPagesCheckBox.Text = "All pages"
         Me._operationAllPagesCheckBox.UseVisualStyleBackColor = True
         '		 Me._operationAllPagesCheckBox.CheckedChanged += New System.EventHandler(Me._operationAllPagesCheckBox_CheckedChanged);
         ' 
         ' _operationGroupBox
         ' 
         Me._operationGroupBox.Controls.Add(Me._operationComboBox)
         Me._operationGroupBox.Location = New System.Drawing.Point(20, 14)
         Me._operationGroupBox.Name = "_operationGroupBox"
         Me._operationGroupBox.Size = New System.Drawing.Size(661, 78)
         Me._operationGroupBox.TabIndex = 0
         Me._operationGroupBox.TabStop = False
         Me._operationGroupBox.Text = "Operation:"
         ' 
         ' _operationComboBox
         ' 
         Me._operationComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
         Me._operationComboBox.FormattingEnabled = True
         Me._operationComboBox.Location = New System.Drawing.Point(27, 36)
         Me._operationComboBox.Name = "_operationComboBox"
         Me._operationComboBox.Size = New System.Drawing.Size(613, 21)
         Me._operationComboBox.TabIndex = 0
         '		 Me._operationComboBox.SelectedIndexChanged += New System.EventHandler(Me._operationComboBox_SelectedIndexChanged);
         ' 
         ' _destinationFileTabPage
         ' 
         Me._destinationFileTabPage.Controls.Add(Me._signatureFileNameGroupBox)
         Me._destinationFileTabPage.Controls.Add(Me._filePasswordGroupBox)
         Me._destinationFileTabPage.Controls.Add(Me._destinationFileInsertPageNumberGroupBox)
         Me._destinationFileTabPage.Controls.Add(Me._destinationFilePropertiesControl)
         Me._destinationFileTabPage.Controls.Add(Me._destinationFileUseSourceFileCheckBox)
         Me._destinationFileTabPage.Controls.Add(Me._destinationFileNameGroupBox)
         Me._destinationFileTabPage.Location = New System.Drawing.Point(4, 22)
         Me._destinationFileTabPage.Name = "_destinationFileTabPage"
         Me._destinationFileTabPage.Size = New System.Drawing.Size(700, 454)
         Me._destinationFileTabPage.TabIndex = 2
         Me._destinationFileTabPage.Text = "Destination File"
         Me._destinationFileTabPage.UseVisualStyleBackColor = True
         ' 
         ' _signatureFileNameGroupBox
         ' 
         Me._signatureFileNameGroupBox.Controls.Add(Me._signatureFileNameBrowseButton)
         Me._signatureFileNameGroupBox.Controls.Add(Me._signatureFileNameTextBox)
         Me._signatureFileNameGroupBox.Location = New System.Drawing.Point(17, 126)
         Me._signatureFileNameGroupBox.Name = "_signatureFileNameGroupBox"
         Me._signatureFileNameGroupBox.Size = New System.Drawing.Size(665, 73)
         Me._signatureFileNameGroupBox.TabIndex = 2
         Me._signatureFileNameGroupBox.TabStop = False
         Me._signatureFileNameGroupBox.Text = "Select signature file:"
         ' 
         ' _signatureFileNameBrowseButton
         ' 
         Me._signatureFileNameBrowseButton.Location = New System.Drawing.Point(575, 28)
         Me._signatureFileNameBrowseButton.Name = "_signatureFileNameBrowseButton"
         Me._signatureFileNameBrowseButton.Size = New System.Drawing.Size(75, 23)
         Me._signatureFileNameBrowseButton.TabIndex = 1
         Me._signatureFileNameBrowseButton.Text = "Browse..."
         Me._signatureFileNameBrowseButton.UseVisualStyleBackColor = True
         ' 
         ' _signatureFileNameTextBox
         ' 
         Me._signatureFileNameTextBox.Location = New System.Drawing.Point(15, 30)
         Me._signatureFileNameTextBox.Name = "_signatureFileNameTextBox"
         Me._signatureFileNameTextBox.[ReadOnly] = True
         Me._signatureFileNameTextBox.Size = New System.Drawing.Size(554, 20)
         Me._signatureFileNameTextBox.TabIndex = 0
         ' 
         ' _filePasswordGroupBox
         ' 
         Me._filePasswordGroupBox.Controls.Add(Me._filePasswordTextBox)
         Me._filePasswordGroupBox.Location = New System.Drawing.Point(17, 215)
         Me._filePasswordGroupBox.Name = "_filePasswordGroupBox"
         Me._filePasswordGroupBox.Size = New System.Drawing.Size(665, 73)
         Me._filePasswordGroupBox.TabIndex = 4
         Me._filePasswordGroupBox.TabStop = False
         Me._filePasswordGroupBox.Text = "Enter password:"
         ' 
         ' _filePasswordTextBox
         ' 
         Me._filePasswordTextBox.Location = New System.Drawing.Point(15, 31)
         Me._filePasswordTextBox.Name = "_filePasswordTextBox"
         Me._filePasswordTextBox.PasswordChar = "*"c
         Me._filePasswordTextBox.Size = New System.Drawing.Size(635, 20)
         Me._filePasswordTextBox.TabIndex = 0
         ' 
         ' _destinationFileInsertPageNumberGroupBox
         ' 
         Me._destinationFileInsertPageNumberGroupBox.Controls.Add(Me._destinationFileInsertPageNumberTextBox)
         Me._destinationFileInsertPageNumberGroupBox.Controls.Add(Me._destinationFileInsertPageNoteLabel)
         Me._destinationFileInsertPageNumberGroupBox.Location = New System.Drawing.Point(297, 117)
         Me._destinationFileInsertPageNumberGroupBox.Name = "_destinationFileInsertPageNumberGroupBox"
         Me._destinationFileInsertPageNumberGroupBox.Size = New System.Drawing.Size(385, 134)
         Me._destinationFileInsertPageNumberGroupBox.TabIndex = 3
         Me._destinationFileInsertPageNumberGroupBox.TabStop = False
         Me._destinationFileInsertPageNumberGroupBox.Text = "Insert page number"
         ' 
         ' _destinationFileInsertPageNumberTextBox
         ' 
         Me._destinationFileInsertPageNumberTextBox.Location = New System.Drawing.Point(24, 32)
         Me._destinationFileInsertPageNumberTextBox.Name = "_destinationFileInsertPageNumberTextBox"
         Me._destinationFileInsertPageNumberTextBox.Size = New System.Drawing.Size(159, 20)
         Me._destinationFileInsertPageNumberTextBox.TabIndex = 1
         ' 
         ' _destinationFileInsertPageNoteLabel
         ' 
         Me._destinationFileInsertPageNoteLabel.Location = New System.Drawing.Point(21, 66)
         Me._destinationFileInsertPageNoteLabel.Name = "_destinationFileInsertPageNoteLabel"
         Me._destinationFileInsertPageNoteLabel.Size = New System.Drawing.Size(349, 49)
         Me._destinationFileInsertPageNoteLabel.TabIndex = 0
         Me._destinationFileInsertPageNoteLabel.Text = "0 = Insert the page(s) at the beginning of the file, -1 = insert at the end of th" & "e file, otherwise, insert after specified page number."
         ' 
         ' _destinationFilePropertiesControl
         ' 
         Me._destinationFilePropertiesControl.Location = New System.Drawing.Point(17, 117)
         Me._destinationFilePropertiesControl.Name = "_destinationFilePropertiesControl"
         Me._destinationFilePropertiesControl.Size = New System.Drawing.Size(273, 246)
         Me._destinationFilePropertiesControl.TabIndex = 2
         ' 
         ' _destinationFileUseSourceFileCheckBox
         ' 
         Me._destinationFileUseSourceFileCheckBox.AutoSize = True
         Me._destinationFileUseSourceFileCheckBox.Location = New System.Drawing.Point(17, 15)
         Me._destinationFileUseSourceFileCheckBox.Name = "_destinationFileUseSourceFileCheckBox"
         Me._destinationFileUseSourceFileCheckBox.Size = New System.Drawing.Size(96, 17)
         Me._destinationFileUseSourceFileCheckBox.TabIndex = 0
         Me._destinationFileUseSourceFileCheckBox.Text = "Use source file"
         Me._destinationFileUseSourceFileCheckBox.UseVisualStyleBackColor = True
         '		 Me._destinationFileUseSourceFileCheckBox.CheckedChanged += New System.EventHandler(Me._destinationFileUseSourceFileCheckBox_CheckedChanged);
         ' 
         ' _destinationFileNameGroupBox
         ' 
         Me._destinationFileNameGroupBox.Controls.Add(Me._destinationFileNameBrowseButton)
         Me._destinationFileNameGroupBox.Controls.Add(Me._destinationFileNameTextBox)
         Me._destinationFileNameGroupBox.Location = New System.Drawing.Point(17, 38)
         Me._destinationFileNameGroupBox.Name = "_destinationFileNameGroupBox"
         Me._destinationFileNameGroupBox.Size = New System.Drawing.Size(665, 73)
         Me._destinationFileNameGroupBox.TabIndex = 1
         Me._destinationFileNameGroupBox.TabStop = False
         Me._destinationFileNameGroupBox.Text = "Select destination file:"
         ' 
         ' _destinationFileNameBrowseButton
         ' 
         Me._destinationFileNameBrowseButton.Location = New System.Drawing.Point(575, 28)
         Me._destinationFileNameBrowseButton.Name = "_destinationFileNameBrowseButton"
         Me._destinationFileNameBrowseButton.Size = New System.Drawing.Size(75, 23)
         Me._destinationFileNameBrowseButton.TabIndex = 1
         Me._destinationFileNameBrowseButton.Text = "Browse..."
         Me._destinationFileNameBrowseButton.UseVisualStyleBackColor = True
         '		 Me._destinationFileNameBrowseButton.Click += New System.EventHandler(Me._destinationFileNameBrowseButton_Click);
         ' 
         ' _destinationFileNameTextBox
         ' 
         Me._destinationFileNameTextBox.Location = New System.Drawing.Point(15, 30)
         Me._destinationFileNameTextBox.Name = "_destinationFileNameTextBox"
         Me._destinationFileNameTextBox.ReadOnly = True
         Me._destinationFileNameTextBox.Size = New System.Drawing.Size(554, 20)
         Me._destinationFileNameTextBox.TabIndex = 0
         ' 
         ' _sourceFilesTabPage
         ' 
         Me._sourceFilesTabPage.Controls.Add(Me._sourceFilesGroupBox)
         Me._sourceFilesTabPage.Location = New System.Drawing.Point(4, 22)
         Me._sourceFilesTabPage.Name = "_sourceFilesTabPage"
         Me._sourceFilesTabPage.Size = New System.Drawing.Size(700, 454)
         Me._sourceFilesTabPage.TabIndex = 4
         Me._sourceFilesTabPage.Text = "Source files"
         Me._sourceFilesTabPage.UseVisualStyleBackColor = True
         ' 
         ' _sourceFilesGroupBox
         ' 
         Me._sourceFilesGroupBox.Controls.Add(Me._sourceFilesNoteLabel)
         Me._sourceFilesGroupBox.Controls.Add(Me._sourceFilesListBox)
         Me._sourceFilesGroupBox.Controls.Add(Me._sourceFilesClearButton)
         Me._sourceFilesGroupBox.Controls.Add(Me._sourceFilesAddButton)
         Me._sourceFilesGroupBox.Location = New System.Drawing.Point(17, 18)
         Me._sourceFilesGroupBox.Name = "_sourceFilesGroupBox"
         Me._sourceFilesGroupBox.Size = New System.Drawing.Size(665, 319)
         Me._sourceFilesGroupBox.TabIndex = 0
         Me._sourceFilesGroupBox.TabStop = False
         Me._sourceFilesGroupBox.Text = "Select source files:"
         ' 
         ' _sourceFilesNoteLabel
         ' 
         Me._sourceFilesNoteLabel.Location = New System.Drawing.Point(101, 235)
         Me._sourceFilesNoteLabel.Name = "_sourceFilesNoteLabel"
         Me._sourceFilesNoteLabel.Size = New System.Drawing.Size(544, 81)
         Me._sourceFilesNoteLabel.TabIndex = 3
         Me._sourceFilesNoteLabel.Text = "Files will be merged in the following order: Source file selected in the previous" & " page first, then the files in the list box above in the order they are entered." & ""
         ' 
         ' _sourceFilesListBox
         ' 
         Me._sourceFilesListBox.FormattingEnabled = True
         Me._sourceFilesListBox.Location = New System.Drawing.Point(101, 29)
         Me._sourceFilesListBox.Name = "_sourceFilesListBox"
         Me._sourceFilesListBox.Size = New System.Drawing.Size(544, 199)
         Me._sourceFilesListBox.TabIndex = 2
         ' 
         ' _sourceFilesClearButton
         ' 
         Me._sourceFilesClearButton.Location = New System.Drawing.Point(19, 58)
         Me._sourceFilesClearButton.Name = "_sourceFilesClearButton"
         Me._sourceFilesClearButton.Size = New System.Drawing.Size(75, 23)
         Me._sourceFilesClearButton.TabIndex = 1
         Me._sourceFilesClearButton.Text = "Clear"
         Me._sourceFilesClearButton.UseVisualStyleBackColor = True
         '		 Me._sourceFilesClearButton.Click += New System.EventHandler(Me._sourceFilesClearButton_Click);
         ' 
         ' _sourceFilesAddButton
         ' 
         Me._sourceFilesAddButton.Location = New System.Drawing.Point(19, 29)
         Me._sourceFilesAddButton.Name = "_sourceFilesAddButton"
         Me._sourceFilesAddButton.Size = New System.Drawing.Size(75, 23)
         Me._sourceFilesAddButton.TabIndex = 0
         Me._sourceFilesAddButton.Text = "Add..."
         Me._sourceFilesAddButton.UseVisualStyleBackColor = True
         '		 Me._sourceFilesAddButton.Click += New System.EventHandler(Me._sourceFilesAddButton_Click);
         ' 
         ' _optionsTabPage
         ' 
         Me._optionsTabPage.Controls.Add(Me._optionsConvertOptionsControl)
         Me._optionsTabPage.Location = New System.Drawing.Point(4, 22)
         Me._optionsTabPage.Name = "_optionsTabPage"
         Me._optionsTabPage.Size = New System.Drawing.Size(700, 540)
         Me._optionsTabPage.TabIndex = 3
         Me._optionsTabPage.Text = "Options"
         Me._optionsTabPage.UseVisualStyleBackColor = True
         ' 
         ' _optionsConvertOptionsControl
         ' 
         Me._optionsConvertOptionsControl.Location = New System.Drawing.Point(3, 9)
         Me._optionsConvertOptionsControl.Name = "_optionsConvertOptionsControl"
         Me._optionsConvertOptionsControl.Size = New System.Drawing.Size(672, 531)
         Me._optionsConvertOptionsControl.TabIndex = 1
         ' 
         ' _distillTabPage
         ' 
         Me._distillTabPage.Controls.Add(Me._distillOptionsGroupBox)
         Me._distillTabPage.Controls.Add(Me._distillPDFFileGroupBox)
         Me._distillTabPage.Location = New System.Drawing.Point(4, 22)
         Me._distillTabPage.Name = "_distillTabPage"
         Me._distillTabPage.Padding = New System.Windows.Forms.Padding(3)
         Me._distillTabPage.Size = New System.Drawing.Size(700, 454)
         Me._distillTabPage.TabIndex = 5
         Me._distillTabPage.Text = "Distill"
         Me._distillTabPage.UseVisualStyleBackColor = True
         ' 
         ' _distillOptionsGroupBox
         ' 
         Me._distillOptionsGroupBox.Controls.Add(Me._distillOptionsAutoRotatePageModeLabel)
         Me._distillOptionsGroupBox.Controls.Add(Me._distillOptionsAutoRotatePageModeComboBox)
         Me._distillOptionsGroupBox.Controls.Add(Me._distillOptionsOutputModeLabel)
         Me._distillOptionsGroupBox.Controls.Add(Me._distillOptionsOutputModeComboBox)
         Me._distillOptionsGroupBox.Location = New System.Drawing.Point(16, 96)
         Me._distillOptionsGroupBox.Name = "_distillOptionsGroupBox"
         Me._distillOptionsGroupBox.Size = New System.Drawing.Size(665, 191)
         Me._distillOptionsGroupBox.TabIndex = 1
         Me._distillOptionsGroupBox.TabStop = False
         Me._distillOptionsGroupBox.Text = "Distiller options:"
         ' 
         ' _distillOptionsAutoRotatePageModeLabel
         ' 
         Me._distillOptionsAutoRotatePageModeLabel.AutoSize = True
         Me._distillOptionsAutoRotatePageModeLabel.Location = New System.Drawing.Point(25, 59)
         Me._distillOptionsAutoRotatePageModeLabel.Name = "_distillOptionsAutoRotatePageModeLabel"
         Me._distillOptionsAutoRotatePageModeLabel.Size = New System.Drawing.Size(118, 13)
         Me._distillOptionsAutoRotatePageModeLabel.TabIndex = 2
         Me._distillOptionsAutoRotatePageModeLabel.Text = "Auto rotate page mode:"
         ' 
         ' _distillOptionsAutoRotatePageModeComboBox
         ' 
         Me._distillOptionsAutoRotatePageModeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
         Me._distillOptionsAutoRotatePageModeComboBox.FormattingEnabled = True
         Me._distillOptionsAutoRotatePageModeComboBox.Location = New System.Drawing.Point(149, 56)
         Me._distillOptionsAutoRotatePageModeComboBox.Name = "_distillOptionsAutoRotatePageModeComboBox"
         Me._distillOptionsAutoRotatePageModeComboBox.Size = New System.Drawing.Size(501, 21)
         Me._distillOptionsAutoRotatePageModeComboBox.TabIndex = 3
         ' 
         ' _distillOptionsOutputModeLabel
         ' 
         Me._distillOptionsOutputModeLabel.AutoSize = True
         Me._distillOptionsOutputModeLabel.Location = New System.Drawing.Point(25, 32)
         Me._distillOptionsOutputModeLabel.Name = "_distillOptionsOutputModeLabel"
         Me._distillOptionsOutputModeLabel.Size = New System.Drawing.Size(71, 13)
         Me._distillOptionsOutputModeLabel.TabIndex = 0
         Me._distillOptionsOutputModeLabel.Text = "Output mode:"
         ' 
         ' _distillOptionsOutputModeComboBox
         ' 
         Me._distillOptionsOutputModeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
         Me._distillOptionsOutputModeComboBox.FormattingEnabled = True
         Me._distillOptionsOutputModeComboBox.Location = New System.Drawing.Point(149, 29)
         Me._distillOptionsOutputModeComboBox.Name = "_distillOptionsOutputModeComboBox"
         Me._distillOptionsOutputModeComboBox.Size = New System.Drawing.Size(501, 21)
         Me._distillOptionsOutputModeComboBox.TabIndex = 1
         ' 
         ' _distillPDFFileGroupBox
         ' 
         Me._distillPDFFileGroupBox.Controls.Add(Me._distillPDFFileBrowseButton)
         Me._distillPDFFileGroupBox.Controls.Add(Me._distillPDFFileTextBox)
         Me._distillPDFFileGroupBox.Location = New System.Drawing.Point(16, 17)
         Me._distillPDFFileGroupBox.Name = "_distillPDFFileGroupBox"
         Me._distillPDFFileGroupBox.Size = New System.Drawing.Size(665, 73)
         Me._distillPDFFileGroupBox.TabIndex = 0
         Me._distillPDFFileGroupBox.TabStop = False
         Me._distillPDFFileGroupBox.Text = "Select PDF file name to create: "
         ' 
         ' _distillPDFFileBrowseButton
         ' 
         Me._distillPDFFileBrowseButton.Location = New System.Drawing.Point(575, 28)
         Me._distillPDFFileBrowseButton.Name = "_distillPDFFileBrowseButton"
         Me._distillPDFFileBrowseButton.Size = New System.Drawing.Size(75, 23)
         Me._distillPDFFileBrowseButton.TabIndex = 1
         Me._distillPDFFileBrowseButton.Text = "Browse..."
         Me._distillPDFFileBrowseButton.UseVisualStyleBackColor = True
         '		 Me._distillPDFFileBrowseButton.Click += New System.EventHandler(Me._distillPDFFileBrowseButton_Click);
         ' 
         ' _distillPDFFileTextBox
         ' 
         Me._distillPDFFileTextBox.Location = New System.Drawing.Point(15, 30)
         Me._distillPDFFileTextBox.Name = "_distillPDFFileTextBox"
         Me._distillPDFFileTextBox.ReadOnly = True
         Me._distillPDFFileTextBox.Size = New System.Drawing.Size(554, 20)
         Me._distillPDFFileTextBox.TabIndex = 0
         ' 
         ' PDFFileDialog
         ' 
         Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.ClientSize = New System.Drawing.Size(732, 617)
         Me.Controls.Add(Me._aboutButton)
         Me.Controls.Add(Me._previousButton)
         Me.Controls.Add(Me._nextButton)
         Me.Controls.Add(Me._exitButton)
         Me.Controls.Add(Me._mainWizardControl)
         Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
         Me.Icon = (CType(resources.GetObject("$this.Icon"), System.Drawing.Icon))
         Me.MaximizeBox = False
         Me.Name = "PDFFileDialog"
         Me.Text = "PDFFileDialog"
         Me._mainWizardControl.ResumeLayout(False)
         Me._sourceFileTabPage.ResumeLayout(False)
         Me._sourceFileTabPage.PerformLayout()
         Me._sourceFileNameGroupBox.ResumeLayout(False)
         Me._sourceFileNameGroupBox.PerformLayout()
         Me._operationTabPage.ResumeLayout(False)
         Me._operationSourcePages.ResumeLayout(False)
         Me._operationSourcePages.PerformLayout()
         Me._operationGroupBox.ResumeLayout(False)
         Me._destinationFileTabPage.ResumeLayout(False)
         Me._destinationFileTabPage.PerformLayout()
         Me._signatureFileNameGroupBox.ResumeLayout(False)
         Me._signatureFileNameGroupBox.PerformLayout()
         Me._filePasswordGroupBox.ResumeLayout(False)
         Me._filePasswordGroupBox.PerformLayout()
         Me._destinationFileInsertPageNumberGroupBox.ResumeLayout(False)
         Me._destinationFileInsertPageNumberGroupBox.PerformLayout()
         Me._destinationFileNameGroupBox.ResumeLayout(False)
         Me._destinationFileNameGroupBox.PerformLayout()
         Me._sourceFilesTabPage.ResumeLayout(False)
         Me._sourceFilesGroupBox.ResumeLayout(False)
         Me._optionsTabPage.ResumeLayout(False)
         Me._distillTabPage.ResumeLayout(False)
         Me._distillOptionsGroupBox.ResumeLayout(False)
         Me._distillOptionsGroupBox.PerformLayout()
         Me._distillPDFFileGroupBox.ResumeLayout(False)
         Me._distillPDFFileGroupBox.PerformLayout()
         Me.ResumeLayout(False)

      End Sub

#End Region

      Private _mainWizardControl As PDFFileDemo.WizardControl
      Private _sourceFileTabPage As System.Windows.Forms.TabPage
      Private WithEvents _exitButton As System.Windows.Forms.Button
      Private WithEvents _nextButton As System.Windows.Forms.Button
      Private WithEvents _previousButton As System.Windows.Forms.Button
      Private _sourceFileNameGroupBox As System.Windows.Forms.GroupBox
      Private WithEvents _sourceFileNameBrowseButton As System.Windows.Forms.Button
      Private _sourceFileNameTextBox As System.Windows.Forms.TextBox
      Private _sourceDocumentPropertiesControl As DocumentPropertiesControl
      Private _sourceFilePropertiesControl As FilePropertiesControl
      Private _operationTabPage As System.Windows.Forms.TabPage
      Private _operationGroupBox As System.Windows.Forms.GroupBox
      Private _operationSourcePages As System.Windows.Forms.GroupBox
      Private WithEvents _operationComboBox As System.Windows.Forms.ComboBox
      Private WithEvents _operationAllPagesCheckBox As System.Windows.Forms.CheckBox
      Private _operationFirstPageNumberLabel As System.Windows.Forms.Label
      Private _operationFirstPageNumberTextBox As System.Windows.Forms.TextBox
      Private _operationLastPageNumberTextBox As System.Windows.Forms.TextBox
      Private _operationLastPageNumberLabel As System.Windows.Forms.Label
      Private _operationPageCountLabel As System.Windows.Forms.Label
      Private _destinationFileTabPage As System.Windows.Forms.TabPage
      Private _destinationFileNameGroupBox As System.Windows.Forms.GroupBox
      Private WithEvents _destinationFileNameBrowseButton As System.Windows.Forms.Button
      Private _destinationFileNameTextBox As System.Windows.Forms.TextBox
      Private WithEvents _destinationFileUseSourceFileCheckBox As System.Windows.Forms.CheckBox
      Private _destinationFilePropertiesControl As FilePropertiesControl
      Private _destinationFileInsertPageNumberGroupBox As System.Windows.Forms.GroupBox
      Private _destinationFileInsertPageNoteLabel As System.Windows.Forms.Label
      Private _destinationFileInsertPageNumberTextBox As System.Windows.Forms.TextBox
      Private _optionsTabPage As System.Windows.Forms.TabPage
      Private _sourceFilesTabPage As System.Windows.Forms.TabPage
      Private _sourceFilesGroupBox As System.Windows.Forms.GroupBox
      Private WithEvents _sourceFilesAddButton As System.Windows.Forms.Button
      Private WithEvents _sourceFilesClearButton As System.Windows.Forms.Button
      Private _sourceFilesNoteLabel As System.Windows.Forms.Label
      Private _sourceFilesListBox As System.Windows.Forms.ListBox
      Private WithEvents _aboutButton As System.Windows.Forms.Button
      Private _sourceFileIsPostscriptLabel As System.Windows.Forms.Label
      Private _distillTabPage As System.Windows.Forms.TabPage
      Private _distillPDFFileGroupBox As System.Windows.Forms.GroupBox
      Private WithEvents _distillPDFFileBrowseButton As System.Windows.Forms.Button
      Private _distillPDFFileTextBox As System.Windows.Forms.TextBox
      Private _distillOptionsGroupBox As System.Windows.Forms.GroupBox
      Private _distillOptionsOutputModeLabel As System.Windows.Forms.Label
      Private _distillOptionsOutputModeComboBox As System.Windows.Forms.ComboBox
      Private _distillOptionsAutoRotatePageModeLabel As System.Windows.Forms.Label
      Private _distillOptionsAutoRotatePageModeComboBox As System.Windows.Forms.ComboBox
      Private _optionsConvertOptionsControl As ConvertOptionsControl
      Private _filePasswordGroupBox As System.Windows.Forms.GroupBox
      Private _filePasswordTextBox As System.Windows.Forms.TextBox
      Private _signatureFileNameGroupBox As System.Windows.Forms.GroupBox
      Private WithEvents _signatureFileNameBrowseButton As System.Windows.Forms.Button
      Private _signatureFileNameTextBox As System.Windows.Forms.TextBox
   End Class
End Namespace