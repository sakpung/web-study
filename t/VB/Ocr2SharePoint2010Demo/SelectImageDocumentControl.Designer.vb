Imports Microsoft.VisualBasic
Imports System
Namespace Ocr2SharePointDemo
   Public Partial Class SelectImageDocumentControl
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

	  #Region "Component Designer generated code"

	  ''' <summary> 
	  ''' Required method for Designer support - do not modify 
	  ''' the contents of this method with the code editor.
	  ''' </summary>
	  Private Sub InitializeComponent()
		 Me._descriptionLabel = New System.Windows.Forms.Label()
		 Me._fileNameLabel = New System.Windows.Forms.Label()
		 Me._fileNameTextBox = New System.Windows.Forms.TextBox()
		 Me._browseButton = New System.Windows.Forms.Button()
		 Me._formatComboBox = New System.Windows.Forms.ComboBox()
		 Me._formatLabel = New System.Windows.Forms.Label()
		 Me._documentFormatLabel = New System.Windows.Forms.Label()
		 Me._nextLabel = New System.Windows.Forms.Label()
		 Me.SuspendLayout()
		 ' 
		 ' _descriptionLabel
		 ' 
		 Me._descriptionLabel.AutoSize = True
		 Me._descriptionLabel.Location = New System.Drawing.Point(14, 14)
		 Me._descriptionLabel.Name = "_descriptionLabel"
		 Me._descriptionLabel.Size = New System.Drawing.Size(402, 13)
		 Me._descriptionLabel.TabIndex = 0
		 Me._descriptionLabel.Text = "Select the image document to recognize (OCR) and upload to the SharePoint server"
		 ' 
		 ' _fileNameLabel
		 ' 
		 Me._fileNameLabel.AutoSize = True
		 Me._fileNameLabel.Location = New System.Drawing.Point(17, 45)
		 Me._fileNameLabel.Name = "_fileNameLabel"
		 Me._fileNameLabel.Size = New System.Drawing.Size(55, 13)
		 Me._fileNameLabel.TabIndex = 1
		 Me._fileNameLabel.Text = "File name:"
		 ' 
		 ' _fileNameTextBox
		 ' 
		 Me._fileNameTextBox.Location = New System.Drawing.Point(78, 42)
		 Me._fileNameTextBox.Name = "_fileNameTextBox"
		 Me._fileNameTextBox.Size = New System.Drawing.Size(578, 20)
		 Me._fileNameTextBox.TabIndex = 2
'		 Me._fileNameTextBox.TextChanged += New System.EventHandler(Me._fileNameTextBox_TextChanged);
		 ' 
		 ' _browseButton
		 ' 
		 Me._browseButton.Location = New System.Drawing.Point(662, 40)
		 Me._browseButton.Name = "_browseButton"
		 Me._browseButton.Size = New System.Drawing.Size(75, 23)
		 Me._browseButton.TabIndex = 3
		 Me._browseButton.Text = "Browse..."
		 Me._browseButton.UseVisualStyleBackColor = True
'		 Me._browseButton.Click += New System.EventHandler(Me._browseButton_Click);
		 ' 
		 ' _formatComboBox
		 ' 
		 Me._formatComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		 Me._formatComboBox.FormattingEnabled = True
		 Me._formatComboBox.Location = New System.Drawing.Point(78, 135)
		 Me._formatComboBox.Name = "_formatComboBox"
		 Me._formatComboBox.Size = New System.Drawing.Size(578, 21)
		 Me._formatComboBox.TabIndex = 6
		 ' 
		 ' _formatLabel
		 ' 
		 Me._formatLabel.AutoSize = True
		 Me._formatLabel.Location = New System.Drawing.Point(17, 138)
		 Me._formatLabel.Name = "_formatLabel"
		 Me._formatLabel.Size = New System.Drawing.Size(42, 13)
		 Me._formatLabel.TabIndex = 5
		 Me._formatLabel.Text = "Format:"
		 ' 
		 ' _documentFormatLabel
		 ' 
		 Me._documentFormatLabel.Location = New System.Drawing.Point(17, 77)
		 Me._documentFormatLabel.Name = "_documentFormatLabel"
		 Me._documentFormatLabel.Size = New System.Drawing.Size(711, 50)
		 Me._documentFormatLabel.TabIndex = 4
		 Me._documentFormatLabel.Text = "Select the output document format" & Constants.vbCrLf & Constants.vbCrLf & "Note: You can use the LEADTOOLS OCR Main Dem" & "o or Auto Recognize Demo for more OCR engines and options."
		 ' 
		 ' _nextLabel
		 ' 
		 Me._nextLabel.AutoSize = True
		 Me._nextLabel.Location = New System.Drawing.Point(17, 178)
		 Me._nextLabel.Name = "_nextLabel"
		 Me._nextLabel.Size = New System.Drawing.Size(409, 13)
		 Me._nextLabel.TabIndex = 7
		 Me._nextLabel.Text = "Click 'Next' to recognize the document and upload it to the selected SharePoint f" & "older"
		 ' 
		 ' SelectImageDocumentControl
		 ' 
		 Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
		 Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		 Me.Controls.Add(Me._nextLabel)
		 Me.Controls.Add(Me._formatComboBox)
		 Me.Controls.Add(Me._formatLabel)
		 Me.Controls.Add(Me._documentFormatLabel)
		 Me.Controls.Add(Me._browseButton)
		 Me.Controls.Add(Me._fileNameTextBox)
		 Me.Controls.Add(Me._fileNameLabel)
		 Me.Controls.Add(Me._descriptionLabel)
		 Me.Name = "SelectImageDocumentControl"
		 Me.Size = New System.Drawing.Size(740, 330)
		 Me.ResumeLayout(False)
		 Me.PerformLayout()

	  End Sub

	  #End Region

	  Private _descriptionLabel As System.Windows.Forms.Label
	  Private _fileNameLabel As System.Windows.Forms.Label
	  Private WithEvents _fileNameTextBox As System.Windows.Forms.TextBox
	  Private WithEvents _browseButton As System.Windows.Forms.Button
	  Private _formatComboBox As System.Windows.Forms.ComboBox
	  Private _formatLabel As System.Windows.Forms.Label
	  Private _documentFormatLabel As System.Windows.Forms.Label
	  Private _nextLabel As System.Windows.Forms.Label
   End Class
End Namespace
