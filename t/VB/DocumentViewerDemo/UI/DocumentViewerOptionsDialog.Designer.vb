
Partial Class DocumentViewerOptionsDialog
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
      Me._okButton = New System.Windows.Forms.Button()
      Me._cancelButton = New System.Windows.Forms.Button()
      Me._thumbnailsOptionsGroupBox = New System.Windows.Forms.GroupBox()
      Me._thumbnailsGridPixelSizeTextBox = New System.Windows.Forms.TextBox()
      Me._thumbnailsGridPixelSizeLabel = New System.Windows.Forms.Label()
      Me._thumbnailsUseGridsCheckBox = New System.Windows.Forms.CheckBox()
      Me._noteLabel = New System.Windows.Forms.Label()
      Me._timeoutsGroupBox = New System.Windows.Forms.GroupBox()
      Me._loadDocumentTimeoutHelpLabel = New System.Windows.Forms.Label()
      Me._loadDocumentTimeoutTextBox = New System.Windows.Forms.TextBox()
      Me._loadDocumentTimeoutLabel = New System.Windows.Forms.Label()
      Me._imagesOptionsGroupBox = New System.Windows.Forms.GroupBox()
      Me._maximumImagesPixelSizeHelpLabel = New System.Windows.Forms.Label()
      Me._maximumImagesPixelSizeTextBox = New System.Windows.Forms.TextBox()
      Me._maximumImagesPixelSizeLabel = New System.Windows.Forms.Label()
      Me._thumbnailsOptionsGroupBox.SuspendLayout()
      Me._timeoutsGroupBox.SuspendLayout()
      Me._imagesOptionsGroupBox.SuspendLayout()
      Me.SuspendLayout()
      '
      '_okButton
      '
      Me._okButton.DialogResult = System.Windows.Forms.DialogResult.OK
      Me._okButton.Location = New System.Drawing.Point(832, 430)
      Me._okButton.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
      Me._okButton.Name = "_okButton"
      Me._okButton.Size = New System.Drawing.Size(112, 35)
      Me._okButton.TabIndex = 5
      Me._okButton.Text = "OK"
      Me._okButton.UseVisualStyleBackColor = True
      '
      '_cancelButton
      '
      Me._cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me._cancelButton.Location = New System.Drawing.Point(712, 430)
      Me._cancelButton.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
      Me._cancelButton.Name = "_cancelButton"
      Me._cancelButton.Size = New System.Drawing.Size(112, 35)
      Me._cancelButton.TabIndex = 4
      Me._cancelButton.Text = "Cancel"
      Me._cancelButton.UseVisualStyleBackColor = True
      '
      '_thumbnailsOptionsGroupBox
      '
      Me._thumbnailsOptionsGroupBox.Controls.Add(Me._thumbnailsGridPixelSizeTextBox)
      Me._thumbnailsOptionsGroupBox.Controls.Add(Me._thumbnailsGridPixelSizeLabel)
      Me._thumbnailsOptionsGroupBox.Controls.Add(Me._thumbnailsUseGridsCheckBox)
      Me._thumbnailsOptionsGroupBox.Location = New System.Drawing.Point(18, 18)
      Me._thumbnailsOptionsGroupBox.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
      Me._thumbnailsOptionsGroupBox.Name = "_thumbnailsOptionsGroupBox"
      Me._thumbnailsOptionsGroupBox.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
      Me._thumbnailsOptionsGroupBox.Size = New System.Drawing.Size(459, 154)
      Me._thumbnailsOptionsGroupBox.TabIndex = 0
      Me._thumbnailsOptionsGroupBox.TabStop = False
      Me._thumbnailsOptionsGroupBox.Text = "Thumbnails:"
      '
      '_thumbnailsGridPixelSizeTextBox
      '
      Me._thumbnailsGridPixelSizeTextBox.Location = New System.Drawing.Point(107, 84)
      Me._thumbnailsGridPixelSizeTextBox.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
      Me._thumbnailsGridPixelSizeTextBox.Name = "_thumbnailsGridPixelSizeTextBox"
      Me._thumbnailsGridPixelSizeTextBox.Size = New System.Drawing.Size(148, 26)
      Me._thumbnailsGridPixelSizeTextBox.TabIndex = 2
      '
      '_thumbnailsGridPixelSizeLabel
      '
      Me._thumbnailsGridPixelSizeLabel.AutoSize = True
      Me._thumbnailsGridPixelSizeLabel.Location = New System.Drawing.Point(22, 87)
      Me._thumbnailsGridPixelSizeLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
      Me._thumbnailsGridPixelSizeLabel.Name = "_thumbnailsGridPixelSizeLabel"
      Me._thumbnailsGridPixelSizeLabel.Size = New System.Drawing.Size(77, 20)
      Me._thumbnailsGridPixelSizeLabel.TabIndex = 1
      Me._thumbnailsGridPixelSizeLabel.Text = "Pixel size:"
      '
      '_thumbnailsUseGridsCheckBox
      '
      Me._thumbnailsUseGridsCheckBox.AutoSize = True
      Me._thumbnailsUseGridsCheckBox.Location = New System.Drawing.Point(26, 51)
      Me._thumbnailsUseGridsCheckBox.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
      Me._thumbnailsUseGridsCheckBox.Name = "_thumbnailsUseGridsCheckBox"
      Me._thumbnailsUseGridsCheckBox.Size = New System.Drawing.Size(102, 24)
      Me._thumbnailsUseGridsCheckBox.TabIndex = 0
      Me._thumbnailsUseGridsCheckBox.Text = "Use grids"
      Me._thumbnailsUseGridsCheckBox.UseVisualStyleBackColor = True
      '
      '_noteLabel
      '
      Me._noteLabel.AutoSize = True
      Me._noteLabel.Location = New System.Drawing.Point(14, 429)
      Me._noteLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
      Me._noteLabel.Name = "_noteLabel"
      Me._noteLabel.Size = New System.Drawing.Size(463, 20)
      Me._noteLabel.TabIndex = 2
      Me._noteLabel.Text = "These options will take effect the next time you load a document."
      '
      '_timeoutsGroupBox
      '
      Me._timeoutsGroupBox.Controls.Add(Me._loadDocumentTimeoutHelpLabel)
      Me._timeoutsGroupBox.Controls.Add(Me._loadDocumentTimeoutTextBox)
      Me._timeoutsGroupBox.Controls.Add(Me._loadDocumentTimeoutLabel)
      Me._timeoutsGroupBox.Location = New System.Drawing.Point(13, 182)
      Me._timeoutsGroupBox.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
      Me._timeoutsGroupBox.Name = "_timeoutsGroupBox"
      Me._timeoutsGroupBox.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
      Me._timeoutsGroupBox.Size = New System.Drawing.Size(459, 229)
      Me._timeoutsGroupBox.TabIndex = 1
      Me._timeoutsGroupBox.TabStop = False
      Me._timeoutsGroupBox.Text = "Timeouts:"
      '
      '_loadDocumentTimeoutHelpLabel
      '
      Me._loadDocumentTimeoutHelpLabel.Location = New System.Drawing.Point(27, 84)
      Me._loadDocumentTimeoutHelpLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
      Me._loadDocumentTimeoutHelpLabel.Name = "_loadDocumentTimeoutHelpLabel"
      Me._loadDocumentTimeoutHelpLabel.Size = New System.Drawing.Size(398, 126)
      Me._loadDocumentTimeoutHelpLabel.TabIndex = 3
      Me._loadDocumentTimeoutHelpLabel.Text = "Abort loading documents if it takes more than this value. A value of 0 means wait" &
    " indefinitely till document loading finishes."
      '
      '_loadDocumentTimeoutTextBox
      '
      Me._loadDocumentTimeoutTextBox.Location = New System.Drawing.Point(277, 47)
      Me._loadDocumentTimeoutTextBox.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
      Me._loadDocumentTimeoutTextBox.Name = "_loadDocumentTimeoutTextBox"
      Me._loadDocumentTimeoutTextBox.Size = New System.Drawing.Size(148, 26)
      Me._loadDocumentTimeoutTextBox.TabIndex = 2
      '
      '_loadDocumentTimeoutLabel
      '
      Me._loadDocumentTimeoutLabel.AutoSize = True
      Me._loadDocumentTimeoutLabel.Location = New System.Drawing.Point(27, 50)
      Me._loadDocumentTimeoutLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
      Me._loadDocumentTimeoutLabel.Name = "_loadDocumentTimeoutLabel"
      Me._loadDocumentTimeoutLabel.Size = New System.Drawing.Size(232, 20)
      Me._loadDocumentTimeoutLabel.TabIndex = 1
      Me._loadDocumentTimeoutLabel.Text = "Load document timeout (in ms):"
      '
      '_imagesOptionsGroupBox
      '
      Me._imagesOptionsGroupBox.Controls.Add(Me._maximumImagesPixelSizeHelpLabel)
      Me._imagesOptionsGroupBox.Controls.Add(Me._maximumImagesPixelSizeTextBox)
      Me._imagesOptionsGroupBox.Controls.Add(Me._maximumImagesPixelSizeLabel)
      Me._imagesOptionsGroupBox.Location = New System.Drawing.Point(485, 20)
      Me._imagesOptionsGroupBox.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
      Me._imagesOptionsGroupBox.Name = "_imagesOptionsGroupBox"
      Me._imagesOptionsGroupBox.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
      Me._imagesOptionsGroupBox.Size = New System.Drawing.Size(459, 391)
      Me._imagesOptionsGroupBox.TabIndex = 3
      Me._imagesOptionsGroupBox.TabStop = False
      Me._imagesOptionsGroupBox.Text = "Images:"
      '
      '_maximumImagesPixelSizeHelpLabel
      '
      Me._maximumImagesPixelSizeHelpLabel.Location = New System.Drawing.Point(20, 84)
      Me._maximumImagesPixelSizeHelpLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
      Me._maximumImagesPixelSizeHelpLabel.Name = "_maximumImagesPixelSizeHelpLabel"
      Me._maximumImagesPixelSizeHelpLabel.Size = New System.Drawing.Size(431, 116)
      Me._maximumImagesPixelSizeHelpLabel.TabIndex = 4
      Me._maximumImagesPixelSizeHelpLabel.Text = "Maximum width or height in pixels to use when obtaining raster image data from th" &
    "e pages in the document. Value of 0 means to use the original size."
      '
      '_maximumImagesPixelSizeTextBox
      '
      Me._maximumImagesPixelSizeTextBox.Location = New System.Drawing.Point(230, 46)
      Me._maximumImagesPixelSizeTextBox.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
      Me._maximumImagesPixelSizeTextBox.Name = "_maximumImagesPixelSizeTextBox"
      Me._maximumImagesPixelSizeTextBox.Size = New System.Drawing.Size(148, 26)
      Me._maximumImagesPixelSizeTextBox.TabIndex = 2
      '
      '_maximumImagesPixelSizeLabel
      '
      Me._maximumImagesPixelSizeLabel.AutoSize = True
      Me._maximumImagesPixelSizeLabel.Location = New System.Drawing.Point(20, 49)
      Me._maximumImagesPixelSizeLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
      Me._maximumImagesPixelSizeLabel.Name = "_maximumImagesPixelSizeLabel"
      Me._maximumImagesPixelSizeLabel.Size = New System.Drawing.Size(202, 20)
      Me._maximumImagesPixelSizeLabel.TabIndex = 1
      Me._maximumImagesPixelSizeLabel.Text = "Maximum images pixel size:"
      '
      'DocumentViewerOptionsDialog
      '
      Me.AcceptButton = Me._okButton
      Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.CancelButton = Me._cancelButton
      Me.ClientSize = New System.Drawing.Size(973, 479)
      Me.Controls.Add(Me._imagesOptionsGroupBox)
      Me.Controls.Add(Me._timeoutsGroupBox)
      Me.Controls.Add(Me._noteLabel)
      Me.Controls.Add(Me._thumbnailsOptionsGroupBox)
      Me.Controls.Add(Me._cancelButton)
      Me.Controls.Add(Me._okButton)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "DocumentViewerOptionsDialog"
      Me.ShowIcon = False
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
      Me.Text = "Document Viewer Options"
      Me._thumbnailsOptionsGroupBox.ResumeLayout(False)
      Me._thumbnailsOptionsGroupBox.PerformLayout()
      Me._timeoutsGroupBox.ResumeLayout(False)
      Me._timeoutsGroupBox.PerformLayout()
      Me._imagesOptionsGroupBox.ResumeLayout(False)
      Me._imagesOptionsGroupBox.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub

#End Region

   Private WithEvents _okButton As System.Windows.Forms.Button
   Private _cancelButton As System.Windows.Forms.Button
   Private _thumbnailsOptionsGroupBox As System.Windows.Forms.GroupBox
   Private WithEvents _thumbnailsUseGridsCheckBox As System.Windows.Forms.CheckBox
   Private _noteLabel As System.Windows.Forms.Label
   Private _thumbnailsGridPixelSizeLabel As System.Windows.Forms.Label
   Private _thumbnailsGridPixelSizeTextBox As System.Windows.Forms.TextBox
   Private WithEvents _timeoutsGroupBox As System.Windows.Forms.GroupBox
   Private WithEvents _loadDocumentTimeoutHelpLabel As System.Windows.Forms.Label
   Private WithEvents _loadDocumentTimeoutTextBox As System.Windows.Forms.TextBox
   Private WithEvents _loadDocumentTimeoutLabel As System.Windows.Forms.Label
   Private WithEvents _imagesOptionsGroupBox As System.Windows.Forms.GroupBox
   Private WithEvents _maximumImagesPixelSizeHelpLabel As System.Windows.Forms.Label
   Private WithEvents _maximumImagesPixelSizeTextBox As System.Windows.Forms.TextBox
   Private WithEvents _maximumImagesPixelSizeLabel As System.Windows.Forms.Label
End Class