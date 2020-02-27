Imports Microsoft.VisualBasic
Imports System
Namespace Ocr2SharePointDemo
   Public Partial Class RecognizeAndUploadControl
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
		 Me._imageDocumentFileNameLabel = New System.Windows.Forms.Label()
		 Me._itemsGroupBox = New System.Windows.Forms.GroupBox()
		 Me._serverDocumentNameTextBox = New System.Windows.Forms.TextBox()
		 Me._serverDocumentNameLabel = New System.Windows.Forms.Label()
		 Me._imageDocumentFileNameTextBox = New System.Windows.Forms.TextBox()
		 Me._successLabel = New System.Windows.Forms.Label()
		 Me._errorLabel = New System.Windows.Forms.Label()
		 Me._itemsGroupBox.SuspendLayout()
		 Me.SuspendLayout()
		 ' 
		 ' _imageDocumentFileNameLabel
		 ' 
		 Me._imageDocumentFileNameLabel.AutoSize = True
		 Me._imageDocumentFileNameLabel.Location = New System.Drawing.Point(6, 32)
		 Me._imageDocumentFileNameLabel.Name = "_imageDocumentFileNameLabel"
		 Me._imageDocumentFileNameLabel.Size = New System.Drawing.Size(105, 13)
		 Me._imageDocumentFileNameLabel.TabIndex = 0
		 Me._imageDocumentFileNameLabel.Text = "Image document file:"
		 ' 
		 ' _itemsGroupBox
		 ' 
		 Me._itemsGroupBox.Controls.Add(Me._serverDocumentNameTextBox)
		 Me._itemsGroupBox.Controls.Add(Me._serverDocumentNameLabel)
		 Me._itemsGroupBox.Controls.Add(Me._imageDocumentFileNameTextBox)
		 Me._itemsGroupBox.Controls.Add(Me._imageDocumentFileNameLabel)
		 Me._itemsGroupBox.Location = New System.Drawing.Point(12, 3)
		 Me._itemsGroupBox.Name = "_itemsGroupBox"
		 Me._itemsGroupBox.Size = New System.Drawing.Size(714, 101)
		 Me._itemsGroupBox.TabIndex = 0
		 Me._itemsGroupBox.TabStop = False
		 Me._itemsGroupBox.Text = "Source document image file name and destination document on the server:"
		 ' 
		 ' _serverDocumentNameTextBox
		 ' 
		 Me._serverDocumentNameTextBox.Location = New System.Drawing.Point(128, 59)
		 Me._serverDocumentNameTextBox.Name = "_serverDocumentNameTextBox"
		 Me._serverDocumentNameTextBox.ReadOnly = True
		 Me._serverDocumentNameTextBox.Size = New System.Drawing.Size(570, 20)
		 Me._serverDocumentNameTextBox.TabIndex = 3
		 ' 
		 ' _serverDocumentNameLabel
		 ' 
		 Me._serverDocumentNameLabel.AutoSize = True
		 Me._serverDocumentNameLabel.Location = New System.Drawing.Point(20, 62)
		 Me._serverDocumentNameLabel.Name = "_serverDocumentNameLabel"
		 Me._serverDocumentNameLabel.Size = New System.Drawing.Size(91, 13)
		 Me._serverDocumentNameLabel.TabIndex = 2
		 Me._serverDocumentNameLabel.Text = "Server document:"
		 ' 
		 ' _imageDocumentFileNameTextBox
		 ' 
		 Me._imageDocumentFileNameTextBox.Location = New System.Drawing.Point(128, 29)
		 Me._imageDocumentFileNameTextBox.Name = "_imageDocumentFileNameTextBox"
		 Me._imageDocumentFileNameTextBox.ReadOnly = True
		 Me._imageDocumentFileNameTextBox.Size = New System.Drawing.Size(570, 20)
		 Me._imageDocumentFileNameTextBox.TabIndex = 1
		 ' 
		 ' _successLabel
		 ' 
		 Me._successLabel.AutoSize = True
		 Me._successLabel.Location = New System.Drawing.Point(12, 111)
		 Me._successLabel.Name = "_successLabel"
		 Me._successLabel.Size = New System.Drawing.Size(379, 65)
		 Me._successLabel.TabIndex = 2
		 Me._successLabel.Text = "Document recognized and uploaded successfully." & Constants.vbCrLf & Constants.vbCrLf & "Click 'Next' to view the upload" & "ed document in the SharePoint browser" & Constants.vbCrLf & Constants.vbCrLf & "Click 'Previous' to recognize and uploa" & "d another document into the same folder"
		 ' 
		 ' _errorLabel
		 ' 
		 Me._errorLabel.AutoSize = True
		 Me._errorLabel.Location = New System.Drawing.Point(12, 183)
		 Me._errorLabel.Name = "_errorLabel"
		 Me._errorLabel.Size = New System.Drawing.Size(379, 65)
		 Me._errorLabel.TabIndex = 1
		 Me._errorLabel.Text = "An err occured while recognizing or uploading the document." & Constants.vbCrLf & Constants.vbCrLf & "Click 'Next' to " & "go back to the SharePoint browser" & Constants.vbCrLf & Constants.vbCrLf & "Click 'Previous' to recognize and upload an" & "other document into the same folder"
		 ' 
		 ' RecognizeAndUploadControl
		 ' 
		 Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
		 Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		 Me.Controls.Add(Me._successLabel)
		 Me.Controls.Add(Me._errorLabel)
		 Me.Controls.Add(Me._itemsGroupBox)
		 Me.Name = "RecognizeAndUploadControl"
		 Me.Size = New System.Drawing.Size(740, 330)
		 Me._itemsGroupBox.ResumeLayout(False)
		 Me._itemsGroupBox.PerformLayout()
		 Me.ResumeLayout(False)
		 Me.PerformLayout()

	  End Sub

	  #End Region

	  Private _imageDocumentFileNameLabel As System.Windows.Forms.Label
	  Private _itemsGroupBox As System.Windows.Forms.GroupBox
	  Private _imageDocumentFileNameTextBox As System.Windows.Forms.TextBox
	  Private _serverDocumentNameLabel As System.Windows.Forms.Label
	  Private _serverDocumentNameTextBox As System.Windows.Forms.TextBox
	  Private _successLabel As System.Windows.Forms.Label
	  Private _errorLabel As System.Windows.Forms.Label
   End Class
End Namespace
