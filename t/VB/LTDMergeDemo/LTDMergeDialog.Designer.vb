
Partial Class LTDMergeDialog
   ''' <summary>
   ''' Required designer variable.
   ''' </summary>
   Private components As System.ComponentModel.IContainer = Nothing

   ''' <summary>
   ''' Clean up any resources being used.
   ''' </summary>
   ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
   Protected Overrides Sub Dispose(disposing As Boolean)
      If disposing AndAlso (components IsNot Nothing) Then
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LTDMergeDialog))
      Me._exitButton = New System.Windows.Forms.Button()
      Me._nextButton = New System.Windows.Forms.Button()
      Me._previousButton = New System.Windows.Forms.Button()
      Me._aboutButton = New System.Windows.Forms.Button()
      Me._progressBar = New System.Windows.Forms.ProgressBar()
      Me._mainWizardControl = New LTDMergeDemo.WizardControl()
      Me._sourceLTDFilesTabPage = New System.Windows.Forms.TabPage()
      Me._sourceLTDFilesGroupBox = New System.Windows.Forms.GroupBox()
      Me.label3 = New System.Windows.Forms.Label()
      Me._ltdDocumentTypeComboBox = New System.Windows.Forms.ComboBox()
      Me.label2 = New System.Windows.Forms.Label()
      Me._moveBottomButton = New System.Windows.Forms.Button()
      Me._moveDownButton = New System.Windows.Forms.Button()
      Me._moveUpButton = New System.Windows.Forms.Button()
      Me._moveTopButton = New System.Windows.Forms.Button()
      Me._sourceLTDFileListView = New System.Windows.Forms.ListView()
      Me._headerFileName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me._columnFileType = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.label1 = New System.Windows.Forms.Label()
      Me._sourceLTDFilesRemoveButton = New System.Windows.Forms.Button()
      Me._sourceFilesNoteLabel = New System.Windows.Forms.Label()
      Me._sourceLTDFilesClearButton = New System.Windows.Forms.Button()
      Me._sourceLTDFilesAddButton = New System.Windows.Forms.Button()
      Me._outputOptionsTabPage = New System.Windows.Forms.TabPage()
      Me.groupBox1 = New System.Windows.Forms.GroupBox()
      Me._viewDocumentCheckBox = New System.Windows.Forms.CheckBox()
      Me._outputFileNameBrowseButton = New System.Windows.Forms.Button()
      Me._outputFileNameTextBox = New System.Windows.Forms.TextBox()
      Me._outputFileNameLabel = New System.Windows.Forms.Label()
      Me._sourceFileNameGroupBox = New System.Windows.Forms.GroupBox()
      Me._documentFormatOptionsControl = New LTDMergeDemo.DocumentFormatOptionsControl()
      Me._mainWizardControl.SuspendLayout()
      Me._sourceLTDFilesTabPage.SuspendLayout()
      Me._sourceLTDFilesGroupBox.SuspendLayout()
      Me._outputOptionsTabPage.SuspendLayout()
      Me.groupBox1.SuspendLayout()
      Me._sourceFileNameGroupBox.SuspendLayout()
      Me.SuspendLayout()
      '
      '_exitButton
      '
      Me._exitButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me._exitButton.Location = New System.Drawing.Point(641, 565)
      Me._exitButton.Name = "_exitButton"
      Me._exitButton.Size = New System.Drawing.Size(75, 23)
      Me._exitButton.TabIndex = 4
      Me._exitButton.Text = "E&xit"
      Me._exitButton.UseVisualStyleBackColor = True
      '
      '_nextButton
      '
      Me._nextButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me._nextButton.Location = New System.Drawing.Point(545, 565)
      Me._nextButton.Name = "_nextButton"
      Me._nextButton.Size = New System.Drawing.Size(75, 23)
      Me._nextButton.TabIndex = 3
      Me._nextButton.Text = "&Next"
      Me._nextButton.UseVisualStyleBackColor = True
      '
      '_previousButton
      '
      Me._previousButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me._previousButton.Location = New System.Drawing.Point(464, 565)
      Me._previousButton.Name = "_previousButton"
      Me._previousButton.Size = New System.Drawing.Size(75, 23)
      Me._previousButton.TabIndex = 2
      Me._previousButton.Text = "&Previous"
      Me._previousButton.UseVisualStyleBackColor = True
      '
      '_aboutButton
      '
      Me._aboutButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me._aboutButton.Location = New System.Drawing.Point(11, 565)
      Me._aboutButton.Name = "_aboutButton"
      Me._aboutButton.Size = New System.Drawing.Size(75, 23)
      Me._aboutButton.TabIndex = 1
      Me._aboutButton.Text = "About..."
      Me._aboutButton.UseVisualStyleBackColor = True
      '
      '_progressBar
      '
      Me._progressBar.Location = New System.Drawing.Point(92, 566)
      Me._progressBar.Name = "_progressBar"
      Me._progressBar.Size = New System.Drawing.Size(366, 23)
      Me._progressBar.Step = 1
      Me._progressBar.TabIndex = 5
      '
      '_mainWizardControl
      '
      Me._mainWizardControl.Controls.Add(Me._sourceLTDFilesTabPage)
      Me._mainWizardControl.Controls.Add(Me._outputOptionsTabPage)
      Me._mainWizardControl.Location = New System.Drawing.Point(12, 12)
      Me._mainWizardControl.Name = "_mainWizardControl"
      Me._mainWizardControl.SelectedIndex = 0
      Me._mainWizardControl.Size = New System.Drawing.Size(708, 547)
      Me._mainWizardControl.TabIndex = 0
      '
      '_sourceLTDFilesTabPage
      '
      Me._sourceLTDFilesTabPage.Controls.Add(Me._sourceLTDFilesGroupBox)
      Me._sourceLTDFilesTabPage.Location = New System.Drawing.Point(4, 22)
      Me._sourceLTDFilesTabPage.Name = "_sourceLTDFilesTabPage"
      Me._sourceLTDFilesTabPage.Size = New System.Drawing.Size(700, 499)
      Me._sourceLTDFilesTabPage.TabIndex = 4
      Me._sourceLTDFilesTabPage.Text = "Source LTD files"
      Me._sourceLTDFilesTabPage.UseVisualStyleBackColor = True
      '
      '_sourceLTDFilesGroupBox
      '
      Me._sourceLTDFilesGroupBox.Controls.Add(Me.label3)
      Me._sourceLTDFilesGroupBox.Controls.Add(Me._ltdDocumentTypeComboBox)
      Me._sourceLTDFilesGroupBox.Controls.Add(Me.label2)
      Me._sourceLTDFilesGroupBox.Controls.Add(Me._moveBottomButton)
      Me._sourceLTDFilesGroupBox.Controls.Add(Me._moveDownButton)
      Me._sourceLTDFilesGroupBox.Controls.Add(Me._moveUpButton)
      Me._sourceLTDFilesGroupBox.Controls.Add(Me._moveTopButton)
      Me._sourceLTDFilesGroupBox.Controls.Add(Me._sourceLTDFileListView)
      Me._sourceLTDFilesGroupBox.Controls.Add(Me.label1)
      Me._sourceLTDFilesGroupBox.Controls.Add(Me._sourceLTDFilesRemoveButton)
      Me._sourceLTDFilesGroupBox.Controls.Add(Me._sourceFilesNoteLabel)
      Me._sourceLTDFilesGroupBox.Controls.Add(Me._sourceLTDFilesClearButton)
      Me._sourceLTDFilesGroupBox.Controls.Add(Me._sourceLTDFilesAddButton)
      Me._sourceLTDFilesGroupBox.Location = New System.Drawing.Point(16, 16)
      Me._sourceLTDFilesGroupBox.Name = "_sourceLTDFilesGroupBox"
      Me._sourceLTDFilesGroupBox.Size = New System.Drawing.Size(665, 369)
      Me._sourceLTDFilesGroupBox.TabIndex = 0
      Me._sourceLTDFilesGroupBox.TabStop = False
      Me._sourceLTDFilesGroupBox.Text = "Select source LTD files:"
      '
      'label3
      '
      Me.label3.AutoSize = True
      Me.label3.Location = New System.Drawing.Point(236, 25)
      Me.label3.Name = "label3"
      Me.label3.Size = New System.Drawing.Size(398, 13)
      Me.label3.TabIndex = 28
      Me.label3.Text = "Only LTD files of selected type will be converted (Mixed type LTDs not supported)" &
    ""
      '
      '_ltdDocumentTypeComboBox
      '
      Me._ltdDocumentTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me._ltdDocumentTypeComboBox.FormattingEnabled = True
      Me._ltdDocumentTypeComboBox.Items.AddRange(New Object() {"Ocr", "Svg"})
      Me._ltdDocumentTypeComboBox.Location = New System.Drawing.Point(134, 21)
      Me._ltdDocumentTypeComboBox.Name = "_ltdDocumentTypeComboBox"
      Me._ltdDocumentTypeComboBox.Size = New System.Drawing.Size(96, 21)
      Me._ltdDocumentTypeComboBox.TabIndex = 27
      '
      'label2
      '
      Me.label2.AutoSize = True
      Me.label2.Location = New System.Drawing.Point(21, 25)
      Me.label2.Name = "label2"
      Me.label2.Size = New System.Drawing.Size(103, 13)
      Me.label2.TabIndex = 26
      Me.label2.Text = "LTD Document Type"
      '
      '_moveBottomButton
      '
      Me._moveBottomButton.Image = CType(resources.GetObject("_moveBottomButton.Image"), System.Drawing.Image)
      Me._moveBottomButton.Location = New System.Drawing.Point(614, 162)
      Me._moveBottomButton.Name = "_moveBottomButton"
      Me._moveBottomButton.Size = New System.Drawing.Size(32, 32)
      Me._moveBottomButton.TabIndex = 25
      Me._moveBottomButton.UseVisualStyleBackColor = True
      '
      '_moveDownButton
      '
      Me._moveDownButton.Image = CType(resources.GetObject("_moveDownButton.Image"), System.Drawing.Image)
      Me._moveDownButton.Location = New System.Drawing.Point(614, 124)
      Me._moveDownButton.Name = "_moveDownButton"
      Me._moveDownButton.Size = New System.Drawing.Size(32, 32)
      Me._moveDownButton.TabIndex = 24
      Me._moveDownButton.UseVisualStyleBackColor = True
      '
      '_moveUpButton
      '
      Me._moveUpButton.Image = CType(resources.GetObject("_moveUpButton.Image"), System.Drawing.Image)
      Me._moveUpButton.Location = New System.Drawing.Point(614, 86)
      Me._moveUpButton.Name = "_moveUpButton"
      Me._moveUpButton.Size = New System.Drawing.Size(32, 32)
      Me._moveUpButton.TabIndex = 23
      Me._moveUpButton.UseVisualStyleBackColor = True
      '
      '_moveTopButton
      '
      Me._moveTopButton.Image = CType(resources.GetObject("_moveTopButton.Image"), System.Drawing.Image)
      Me._moveTopButton.Location = New System.Drawing.Point(614, 48)
      Me._moveTopButton.Name = "_moveTopButton"
      Me._moveTopButton.Size = New System.Drawing.Size(32, 32)
      Me._moveTopButton.TabIndex = 22
      Me._moveTopButton.UseVisualStyleBackColor = True
      '
      '_sourceLTDFileListView
      '
      Me._sourceLTDFileListView.AllowDrop = True
      Me._sourceLTDFileListView.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me._headerFileName, Me._columnFileType})
      Me._sourceLTDFileListView.FullRowSelect = True
      Me._sourceLTDFileListView.GridLines = True
      Me._sourceLTDFileListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
      Me._sourceLTDFileListView.HideSelection = False
      Me._sourceLTDFileListView.Location = New System.Drawing.Point(104, 48)
      Me._sourceLTDFileListView.Name = "_sourceLTDFileListView"
      Me._sourceLTDFileListView.Size = New System.Drawing.Size(504, 271)
      Me._sourceLTDFileListView.TabIndex = 21
      Me._sourceLTDFileListView.UseCompatibleStateImageBehavior = False
      Me._sourceLTDFileListView.View = System.Windows.Forms.View.Details
      '
      '_headerFileName
      '
      Me._headerFileName.Text = "File name"
      Me._headerFileName.Width = 420
      '
      '_columnFileType
      '
      Me._columnFileType.Text = "LTD Type"
      '
      'label1
      '
      Me.label1.Location = New System.Drawing.Point(102, 322)
      Me.label1.Name = "label1"
      Me.label1.Size = New System.Drawing.Size(544, 16)
      Me.label1.TabIndex = 5
      Me.label1.Text = "● Drag/Drop operations are supported for the above list."
      '
      '_sourceLTDFilesRemoveButton
      '
      Me._sourceLTDFilesRemoveButton.Location = New System.Drawing.Point(24, 77)
      Me._sourceLTDFilesRemoveButton.Name = "_sourceLTDFilesRemoveButton"
      Me._sourceLTDFilesRemoveButton.Size = New System.Drawing.Size(75, 23)
      Me._sourceLTDFilesRemoveButton.TabIndex = 4
      Me._sourceLTDFilesRemoveButton.Text = "&Remove"
      Me._sourceLTDFilesRemoveButton.UseVisualStyleBackColor = True
      '
      '_sourceFilesNoteLabel
      '
      Me._sourceFilesNoteLabel.Location = New System.Drawing.Point(102, 338)
      Me._sourceFilesNoteLabel.Name = "_sourceFilesNoteLabel"
      Me._sourceFilesNoteLabel.Size = New System.Drawing.Size(544, 16)
      Me._sourceFilesNoteLabel.TabIndex = 3
      Me._sourceFilesNoteLabel.Text = "● Files will be merged in the same order shown in the above list."
      '
      '_sourceLTDFilesClearButton
      '
      Me._sourceLTDFilesClearButton.Location = New System.Drawing.Point(24, 106)
      Me._sourceLTDFilesClearButton.Name = "_sourceLTDFilesClearButton"
      Me._sourceLTDFilesClearButton.Size = New System.Drawing.Size(75, 23)
      Me._sourceLTDFilesClearButton.TabIndex = 1
      Me._sourceLTDFilesClearButton.Text = "&Clear"
      Me._sourceLTDFilesClearButton.UseVisualStyleBackColor = True
      '
      '_sourceLTDFilesAddButton
      '
      Me._sourceLTDFilesAddButton.Location = New System.Drawing.Point(23, 48)
      Me._sourceLTDFilesAddButton.Name = "_sourceLTDFilesAddButton"
      Me._sourceLTDFilesAddButton.Size = New System.Drawing.Size(75, 23)
      Me._sourceLTDFilesAddButton.TabIndex = 0
      Me._sourceLTDFilesAddButton.Text = "A&dd..."
      Me._sourceLTDFilesAddButton.UseVisualStyleBackColor = True
      '
      '_outputOptionsTabPage
      '
      Me._outputOptionsTabPage.Controls.Add(Me.groupBox1)
      Me._outputOptionsTabPage.Controls.Add(Me._sourceFileNameGroupBox)
      Me._outputOptionsTabPage.Location = New System.Drawing.Point(4, 22)
      Me._outputOptionsTabPage.Name = "_outputOptionsTabPage"
      Me._outputOptionsTabPage.Padding = New System.Windows.Forms.Padding(3)
      Me._outputOptionsTabPage.Size = New System.Drawing.Size(700, 521)
      Me._outputOptionsTabPage.TabIndex = 0
      Me._outputOptionsTabPage.Text = "Output options"
      Me._outputOptionsTabPage.UseVisualStyleBackColor = True
      '
      'groupBox1
      '
      Me.groupBox1.Controls.Add(Me._viewDocumentCheckBox)
      Me.groupBox1.Controls.Add(Me._outputFileNameBrowseButton)
      Me.groupBox1.Controls.Add(Me._outputFileNameTextBox)
      Me.groupBox1.Controls.Add(Me._outputFileNameLabel)
      Me.groupBox1.Location = New System.Drawing.Point(16, 418)
      Me.groupBox1.Name = "groupBox1"
      Me.groupBox1.Size = New System.Drawing.Size(665, 93)
      Me.groupBox1.TabIndex = 1
      Me.groupBox1.TabStop = False
      Me.groupBox1.Text = "Output file"
      '
      '_viewDocumentCheckBox
      '
      Me._viewDocumentCheckBox.AutoSize = True
      Me._viewDocumentCheckBox.ImeMode = System.Windows.Forms.ImeMode.NoControl
      Me._viewDocumentCheckBox.Location = New System.Drawing.Point(15, 61)
      Me._viewDocumentCheckBox.Name = "_viewDocumentCheckBox"
      Me._viewDocumentCheckBox.Size = New System.Drawing.Size(121, 17)
      Me._viewDocumentCheckBox.TabIndex = 20
      Me._viewDocumentCheckBox.Text = "View final document"
      Me._viewDocumentCheckBox.UseVisualStyleBackColor = True
      '
      '_outputFileNameBrowseButton
      '
      Me._outputFileNameBrowseButton.ImeMode = System.Windows.Forms.ImeMode.NoControl
      Me._outputFileNameBrowseButton.Location = New System.Drawing.Point(364, 22)
      Me._outputFileNameBrowseButton.Name = "_outputFileNameBrowseButton"
      Me._outputFileNameBrowseButton.Size = New System.Drawing.Size(27, 23)
      Me._outputFileNameBrowseButton.TabIndex = 19
      Me._outputFileNameBrowseButton.Text = "..."
      Me._outputFileNameBrowseButton.UseVisualStyleBackColor = True
      '
      '_outputFileNameTextBox
      '
      Me._outputFileNameTextBox.Location = New System.Drawing.Point(105, 24)
      Me._outputFileNameTextBox.Name = "_outputFileNameTextBox"
      Me._outputFileNameTextBox.Size = New System.Drawing.Size(253, 20)
      Me._outputFileNameTextBox.TabIndex = 18
      '
      '_outputFileNameLabel
      '
      Me._outputFileNameLabel.AutoSize = True
      Me._outputFileNameLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl
      Me._outputFileNameLabel.Location = New System.Drawing.Point(12, 27)
      Me._outputFileNameLabel.Name = "_outputFileNameLabel"
      Me._outputFileNameLabel.Size = New System.Drawing.Size(91, 13)
      Me._outputFileNameLabel.TabIndex = 17
      Me._outputFileNameLabel.Text = "Output file name:"
      '
      '_sourceFileNameGroupBox
      '
      Me._sourceFileNameGroupBox.Controls.Add(Me._documentFormatOptionsControl)
      Me._sourceFileNameGroupBox.Location = New System.Drawing.Point(16, 16)
      Me._sourceFileNameGroupBox.Name = "_sourceFileNameGroupBox"
      Me._sourceFileNameGroupBox.Size = New System.Drawing.Size(665, 396)
      Me._sourceFileNameGroupBox.TabIndex = 0
      Me._sourceFileNameGroupBox.TabStop = False
      Me._sourceFileNameGroupBox.Text = "Output format options"
      '
      '_documentFormatOptionsControl
      '
      Me._documentFormatOptionsControl.Location = New System.Drawing.Point(7, 20)
      Me._documentFormatOptionsControl.Name = "_documentFormatOptionsControl"
      Me._documentFormatOptionsControl.Size = New System.Drawing.Size(387, 370)
      Me._documentFormatOptionsControl.TabIndex = 0
      '
      'LTDMergeDialog
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(732, 600)
      Me.Controls.Add(Me._progressBar)
      Me.Controls.Add(Me._aboutButton)
      Me.Controls.Add(Me._previousButton)
      Me.Controls.Add(Me._nextButton)
      Me.Controls.Add(Me._exitButton)
      Me.Controls.Add(Me._mainWizardControl)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.MaximizeBox = False
      Me.Name = "LTDMergeDialog"
      Me.Text = "VB LTD Merge Demo"
      Me._mainWizardControl.ResumeLayout(False)
      Me._sourceLTDFilesTabPage.ResumeLayout(False)
      Me._sourceLTDFilesGroupBox.ResumeLayout(False)
      Me._sourceLTDFilesGroupBox.PerformLayout()
      Me._outputOptionsTabPage.ResumeLayout(False)
      Me.groupBox1.ResumeLayout(False)
      Me.groupBox1.PerformLayout()
      Me._sourceFileNameGroupBox.ResumeLayout(False)
      Me.ResumeLayout(False)

   End Sub

#End Region

   Private _mainWizardControl As WizardControl
   Private _outputOptionsTabPage As System.Windows.Forms.TabPage
   Private WithEvents _exitButton As System.Windows.Forms.Button
   Private WithEvents _nextButton As System.Windows.Forms.Button
   Private WithEvents _previousButton As System.Windows.Forms.Button
   Private _sourceFileNameGroupBox As System.Windows.Forms.GroupBox
   Private _sourceLTDFilesTabPage As System.Windows.Forms.TabPage
   Private _sourceLTDFilesGroupBox As System.Windows.Forms.GroupBox
   Private WithEvents _sourceLTDFilesAddButton As System.Windows.Forms.Button
   Private WithEvents _sourceLTDFilesClearButton As System.Windows.Forms.Button
   Private WithEvents _aboutButton As System.Windows.Forms.Button
   Private WithEvents _sourceLTDFilesRemoveButton As System.Windows.Forms.Button
   Private _sourceFilesNoteLabel As System.Windows.Forms.Label
   Private label1 As System.Windows.Forms.Label
   Private WithEvents _sourceLTDFileListView As System.Windows.Forms.ListView
   Private _headerFileName As System.Windows.Forms.ColumnHeader
   Private groupBox1 As System.Windows.Forms.GroupBox
   Private _viewDocumentCheckBox As System.Windows.Forms.CheckBox
   Private WithEvents _outputFileNameBrowseButton As System.Windows.Forms.Button
   Private WithEvents _outputFileNameTextBox As System.Windows.Forms.TextBox
   Private _outputFileNameLabel As System.Windows.Forms.Label
   Private WithEvents _moveTopButton As System.Windows.Forms.Button
   Private WithEvents _moveBottomButton As System.Windows.Forms.Button
   Private WithEvents _moveDownButton As System.Windows.Forms.Button
   Private WithEvents _moveUpButton As System.Windows.Forms.Button
   Private _documentFormatOptionsControl As DocumentFormatOptionsControl
   Private _progressBar As System.Windows.Forms.ProgressBar
   Private _columnFileType As System.Windows.Forms.ColumnHeader
   Private label3 As System.Windows.Forms.Label
   Private _ltdDocumentTypeComboBox As System.Windows.Forms.ComboBox
   Private label2 As System.Windows.Forms.Label
End Class