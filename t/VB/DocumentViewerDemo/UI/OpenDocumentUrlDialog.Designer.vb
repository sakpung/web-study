Partial Class OpenDocumentUrlDialog
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
      Me._documentLocationTextBox = New System.Windows.Forms.TextBox()
      Me._documentLocationGroupBox = New System.Windows.Forms.GroupBox()
      Me._documentLocationLabel = New System.Windows.Forms.Label()
      Me._loadButton = New System.Windows.Forms.Button()
      Me._cancelButton = New System.Windows.Forms.Button()
      Me._progressBar = New System.Windows.Forms.ProgressBar()
      Me._annotationsGroupBox = New System.Windows.Forms.GroupBox()
      Me._externalAnnotationsLabel = New System.Windows.Forms.Label()
      Me._embeddedAnnotationsLabel = New System.Windows.Forms.Label()
      Me._noAnnotationsLabel = New System.Windows.Forms.Label()
      Me._externalAnnotationsLocationLabel = New System.Windows.Forms.Label()
      Me._externalAnnotationsRadioButton = New System.Windows.Forms.RadioButton()
      Me._embeddedAnnotationsRadioButton = New System.Windows.Forms.RadioButton()
      Me._noAnnotationsRadioButton = New System.Windows.Forms.RadioButton()
      Me._annotationsLocationTextBox = New System.Windows.Forms.TextBox()
      Me._pagesLabel = New System.Windows.Forms.Label()
      Me._pagesButton = New System.Windows.Forms.Button()
      Me._documentLocationGroupBox.SuspendLayout()
      Me._annotationsGroupBox.SuspendLayout()
      Me.SuspendLayout()
      ' 
      ' _documentLocationTextBox
      ' 
      Me._documentLocationTextBox.Location = New System.Drawing.Point(9, 42)
      Me._documentLocationTextBox.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
      Me._documentLocationTextBox.Name = "_documentLocationTextBox"
      Me._documentLocationTextBox.Size = New System.Drawing.Size(760, 26)
      Me._documentLocationTextBox.TabIndex = 0
      AddHandler Me._documentLocationTextBox.TextChanged, AddressOf Me._locationTextBox_TextChanged
      ' 
      ' _documentLocationGroupBox
      ' 
      Me._documentLocationGroupBox.Controls.Add(Me._pagesLabel)
      Me._documentLocationGroupBox.Controls.Add(Me._pagesButton)
      Me._documentLocationGroupBox.Controls.Add(Me._documentLocationLabel)
      Me._documentLocationGroupBox.Controls.Add(Me._documentLocationTextBox)
      Me._documentLocationGroupBox.Location = New System.Drawing.Point(18, 18)
      Me._documentLocationGroupBox.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
      Me._documentLocationGroupBox.Name = "_documentLocationGroupBox"
      Me._documentLocationGroupBox.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
      Me._documentLocationGroupBox.Size = New System.Drawing.Size(780, 173)
      Me._documentLocationGroupBox.TabIndex = 0
      Me._documentLocationGroupBox.TabStop = False
      Me._documentLocationGroupBox.Text = "Document &location:"
      ' 
      ' _documentLocationLabel
      ' 
      Me._documentLocationLabel.AutoSize = True
      Me._documentLocationLabel.Location = New System.Drawing.Point(9, 77)
      Me._documentLocationLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
      Me._documentLocationLabel.Name = "_documentLocationLabel"
      Me._documentLocationLabel.Size = New System.Drawing.Size(366, 20)
      Me._documentLocationLabel.TabIndex = 1
      Me._documentLocationLabel.Text = "For example: http://website.com/part/document.pdf"
      ' 
      ' _loadButton
      ' 
      Me._loadButton.Location = New System.Drawing.Point(686, 653)
      Me._loadButton.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
      Me._loadButton.Name = "_loadButton"
      Me._loadButton.Size = New System.Drawing.Size(112, 35)
      Me._loadButton.TabIndex = 3
      Me._loadButton.Text = "&Load"
      Me._loadButton.UseVisualStyleBackColor = True
      AddHandler Me._loadButton.Click, AddressOf Me._loadButton_Click
      ' 
      ' _cancelButton
      ' 
      Me._cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me._cancelButton.Location = New System.Drawing.Point(686, 699)
      Me._cancelButton.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
      Me._cancelButton.Name = "_cancelButton"
      Me._cancelButton.Size = New System.Drawing.Size(112, 35)
      Me._cancelButton.TabIndex = 4
      Me._cancelButton.Text = "Cancel"
      Me._cancelButton.UseVisualStyleBackColor = True
      AddHandler Me._cancelButton.Click, AddressOf Me._cancelButton_Click
      ' 
      ' _progressBar
      ' 
      Me._progressBar.Location = New System.Drawing.Point(18, 699)
      Me._progressBar.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
      Me._progressBar.Name = "_progressBar"
      Me._progressBar.Size = New System.Drawing.Size(650, 35)
      Me._progressBar.TabIndex = 2
      ' 
      ' _annotationsGroupBox
      ' 
      Me._annotationsGroupBox.Controls.Add(Me._externalAnnotationsLabel)
      Me._annotationsGroupBox.Controls.Add(Me._embeddedAnnotationsLabel)
      Me._annotationsGroupBox.Controls.Add(Me._noAnnotationsLabel)
      Me._annotationsGroupBox.Controls.Add(Me._externalAnnotationsLocationLabel)
      Me._annotationsGroupBox.Controls.Add(Me._externalAnnotationsRadioButton)
      Me._annotationsGroupBox.Controls.Add(Me._embeddedAnnotationsRadioButton)
      Me._annotationsGroupBox.Controls.Add(Me._noAnnotationsRadioButton)
      Me._annotationsGroupBox.Controls.Add(Me._annotationsLocationTextBox)
      Me._annotationsGroupBox.Location = New System.Drawing.Point(18, 201)
      Me._annotationsGroupBox.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
      Me._annotationsGroupBox.Name = "_annotationsGroupBox"
      Me._annotationsGroupBox.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
      Me._annotationsGroupBox.Size = New System.Drawing.Size(780, 442)
      Me._annotationsGroupBox.TabIndex = 1
      Me._annotationsGroupBox.TabStop = False
      Me._annotationsGroupBox.Text = "&Annotations"
      ' 
      ' _externalAnnotationsLabel
      ' 
      Me._externalAnnotationsLabel.Location = New System.Drawing.Point(58, 309)
      Me._externalAnnotationsLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
      Me._externalAnnotationsLabel.Name = "_externalAnnotationsLabel"
      Me._externalAnnotationsLabel.Size = New System.Drawing.Size(690, 77)
      Me._externalAnnotationsLabel.TabIndex = 5
      Me._externalAnnotationsLabel.Text = "Select this option if the annotations are stored in an external address, such as " & "LEADTOOLS annotations store in an XML file (for example: http://website.com/part" & "/document.xml)."
      ' 
      ' _embeddedAnnotationsLabel
      ' 
      Me._embeddedAnnotationsLabel.Location = New System.Drawing.Point(58, 197)
      Me._embeddedAnnotationsLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
      Me._embeddedAnnotationsLabel.Name = "_embeddedAnnotationsLabel"
      Me._embeddedAnnotationsLabel.Size = New System.Drawing.Size(690, 77)
      Me._embeddedAnnotationsLabel.TabIndex = 3
      Me._embeddedAnnotationsLabel.Text = "Some document formats such as PDF and TIFF can have embedded annotations inside t" & "he file itself. Select this option to try to load these annotations if they exis" & "t."
      ' 
      ' _noAnnotationsLabel
      ' 
      Me._noAnnotationsLabel.Location = New System.Drawing.Point(58, 75)
      Me._noAnnotationsLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
      Me._noAnnotationsLabel.Name = "_noAnnotationsLabel"
      Me._noAnnotationsLabel.Size = New System.Drawing.Size(690, 77)
      Me._noAnnotationsLabel.TabIndex = 1
      Me._noAnnotationsLabel.Text = "Annotations will not be loaded."
      ' 
      ' _externalAnnotationsLocationLabel
      ' 
      Me._externalAnnotationsLocationLabel.AutoSize = True
      Me._externalAnnotationsLocationLabel.Location = New System.Drawing.Point(75, 405)
      Me._externalAnnotationsLocationLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
      Me._externalAnnotationsLocationLabel.Name = "_externalAnnotationsLocationLabel"
      Me._externalAnnotationsLocationLabel.Size = New System.Drawing.Size(72, 20)
      Me._externalAnnotationsLocationLabel.TabIndex = 6
      Me._externalAnnotationsLocationLabel.Text = "Address:"
      ' 
      ' _externalAnnotationsRadioButton
      ' 
      Me._externalAnnotationsRadioButton.AutoSize = True
      Me._externalAnnotationsRadioButton.Location = New System.Drawing.Point(34, 278)
      Me._externalAnnotationsRadioButton.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
      Me._externalAnnotationsRadioButton.Name = "_externalAnnotationsRadioButton"
      Me._externalAnnotationsRadioButton.Size = New System.Drawing.Size(364, 24)
      Me._externalAnnotationsRadioButton.TabIndex = 4
      Me._externalAnnotationsRadioButton.TabStop = True
      Me._externalAnnotationsRadioButton.Text = "&Load the annotations from an external address"
      Me._externalAnnotationsRadioButton.UseVisualStyleBackColor = True
      AddHandler Me._externalAnnotationsRadioButton.CheckedChanged, AddressOf Me._annotationsRadioButton_CheckedChanged
      ' 
      ' _embeddedAnnotationsRadioButton
      ' 
      Me._embeddedAnnotationsRadioButton.AutoSize = True
      Me._embeddedAnnotationsRadioButton.Location = New System.Drawing.Point(34, 166)
      Me._embeddedAnnotationsRadioButton.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
      Me._embeddedAnnotationsRadioButton.Name = "_embeddedAnnotationsRadioButton"
      Me._embeddedAnnotationsRadioButton.Size = New System.Drawing.Size(383, 24)
      Me._embeddedAnnotationsRadioButton.TabIndex = 2
      Me._embeddedAnnotationsRadioButton.TabStop = True
      Me._embeddedAnnotationsRadioButton.Text = "Load the annotations &embedded in the document"
      Me._embeddedAnnotationsRadioButton.UseVisualStyleBackColor = True
      AddHandler Me._embeddedAnnotationsRadioButton.CheckedChanged, AddressOf Me._annotationsRadioButton_CheckedChanged
      ' 
      ' _noAnnotationsRadioButton
      ' 
      Me._noAnnotationsRadioButton.AutoSize = True
      Me._noAnnotationsRadioButton.Location = New System.Drawing.Point(34, 45)
      Me._noAnnotationsRadioButton.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
      Me._noAnnotationsRadioButton.Name = "_noAnnotationsRadioButton"
      Me._noAnnotationsRadioButton.Size = New System.Drawing.Size(233, 24)
      Me._noAnnotationsRadioButton.TabIndex = 0
      Me._noAnnotationsRadioButton.TabStop = True
      Me._noAnnotationsRadioButton.Text = "&Do not load any annotations"
      Me._noAnnotationsRadioButton.UseVisualStyleBackColor = True
      AddHandler Me._noAnnotationsRadioButton.CheckedChanged, AddressOf Me._annotationsRadioButton_CheckedChanged
      ' 
      ' _annotationsLocationTextBox
      ' 
      Me._annotationsLocationTextBox.Location = New System.Drawing.Point(166, 400)
      Me._annotationsLocationTextBox.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
      Me._annotationsLocationTextBox.Name = "_annotationsLocationTextBox"
      Me._annotationsLocationTextBox.Size = New System.Drawing.Size(602, 26)
      Me._annotationsLocationTextBox.TabIndex = 6
      AddHandler Me._annotationsLocationTextBox.TextChanged, AddressOf Me._locationTextBox_TextChanged
      ' 
      ' _pagesLabel
      ' 
      Me._pagesLabel.AutoSize = True
      Me._pagesLabel.Location = New System.Drawing.Point(136, 126)
      Me._pagesLabel.Name = "_pagesLabel"
      Me._pagesLabel.Size = New System.Drawing.Size(0, 20)
      Me._pagesLabel.TabIndex = 3
      ' 
      ' _pagesButton
      ' 
      Me._pagesButton.Location = New System.Drawing.Point(9, 119)
      Me._pagesButton.Name = "_pagesButton"
      Me._pagesButton.Size = New System.Drawing.Size(112, 35)
      Me._pagesButton.TabIndex = 2
      Me._pagesButton.Text = "&Pages..."
      Me._pagesButton.UseVisualStyleBackColor = True
      AddHandler Me._pagesButton.Click, AddressOf Me._pagesButton_Click
      ' 
      ' OpenDocumentUrlDialog
      ' 
      Me.AcceptButton = Me._loadButton
      Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0F, 20.0F)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.CancelButton = Me._cancelButton
      Me.ClientSize = New System.Drawing.Size(816, 759)
      Me.Controls.Add(Me._annotationsGroupBox)
      Me.Controls.Add(Me._progressBar)
      Me.Controls.Add(Me._loadButton)
      Me.Controls.Add(Me._cancelButton)
      Me.Controls.Add(Me._documentLocationGroupBox)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "OpenDocumentUrlDialog"
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
      Me.Text = "Open URL"
      Me._documentLocationGroupBox.ResumeLayout(False)
      Me._documentLocationGroupBox.PerformLayout()
      Me._annotationsGroupBox.ResumeLayout(False)
      Me._annotationsGroupBox.PerformLayout()
      Me.ResumeLayout(False)

   End Sub

#End Region

   Private WithEvents _documentLocationTextBox As System.Windows.Forms.TextBox
   Private _documentLocationGroupBox As System.Windows.Forms.GroupBox
   Private WithEvents _loadButton As System.Windows.Forms.Button
   Private WithEvents _cancelButton As System.Windows.Forms.Button
   Private _progressBar As System.Windows.Forms.ProgressBar
   Private _documentLocationLabel As System.Windows.Forms.Label
   Private _annotationsGroupBox As System.Windows.Forms.GroupBox
   Private _externalAnnotationsLabel As System.Windows.Forms.Label
   Private _embeddedAnnotationsLabel As System.Windows.Forms.Label
   Private _noAnnotationsLabel As System.Windows.Forms.Label
   Private _externalAnnotationsLocationLabel As System.Windows.Forms.Label
   Private WithEvents _externalAnnotationsRadioButton As System.Windows.Forms.RadioButton
   Private WithEvents _embeddedAnnotationsRadioButton As System.Windows.Forms.RadioButton
   Private WithEvents _noAnnotationsRadioButton As System.Windows.Forms.RadioButton
   Private WithEvents _annotationsLocationTextBox As System.Windows.Forms.TextBox
   Private _pagesLabel As System.Windows.Forms.Label
   Private WithEvents _pagesButton As System.Windows.Forms.Button
End Class
