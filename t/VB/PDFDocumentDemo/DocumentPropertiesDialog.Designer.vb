' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************

Namespace PDFDocumentDemo
   Class DocumentPropertiesDialog

      ''' <summary>
      ''' Required designer variable.
      ''' </summary>
      Private components As System.ComponentModel.IContainer = Nothing

      ''' <summary>
      ''' Clean up any resources being used.
      ''' </summary>
      ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      Protected Overrides Sub Dispose(ByVal disposing As Boolean)
         If (disposing _
                     AndAlso (Not (Me.components) Is Nothing)) Then
            Me.components.Dispose()
         End If

         MyBase.Dispose(disposing)
      End Sub
#Region "Windows Form Designer generated code"

      Private Sub InitializeComponent()
         Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DocumentPropertiesDialog))
         Me._okButton = New System.Windows.Forms.Button
         Me._notesLabel = New System.Windows.Forms.Label
         Me._fileNameLabel = New System.Windows.Forms.Label
         Me._fileNameTextBox = New System.Windows.Forms.TextBox
         Me._numberOfPagesTextBox = New System.Windows.Forms.TextBox
         Me._numberOfPagesLabel = New System.Windows.Forms.Label
         Me._pageSizeTextBox = New System.Windows.Forms.TextBox
         Me._pageSizeLabel = New System.Windows.Forms.Label
         Me._isEncryptedTextBox = New System.Windows.Forms.TextBox
         Me._isEncryptedLabel = New System.Windows.Forms.Label
         Me._versionTextBox = New System.Windows.Forms.TextBox
         Me._versionLabel = New System.Windows.Forms.Label
         Me._isPdfATextBox = New System.Windows.Forms.TextBox
         Me._isPdfALabel = New System.Windows.Forms.Label
         Me._documentPropertiesControl = New PDFDocumentDemo.DocumentPropertiesControl
         Me._isLinearizedTextBox = New System.Windows.Forms.TextBox
         Me._isLinearizedLabel = New System.Windows.Forms.Label
         Me.SuspendLayout()
         ' 
         ' _okButton
         ' 
         Me._okButton.DialogResult = System.Windows.Forms.DialogResult.OK
         resources.ApplyResources(Me._okButton, "_okButton")
         Me._okButton.Name = "_okButton"
         Me._okButton.UseVisualStyleBackColor = True
         ' 
         ' _notesLabel
         ' 
         resources.ApplyResources(Me._notesLabel, "_notesLabel")
         Me._notesLabel.Name = "_notesLabel"
         ' 
         ' _fileNameLabel
         ' 
         resources.ApplyResources(Me._fileNameLabel, "_fileNameLabel")
         Me._fileNameLabel.Name = "_fileNameLabel"
         ' 
         ' _fileNameTextBox
         ' 
         resources.ApplyResources(Me._fileNameTextBox, "_fileNameTextBox")
         Me._fileNameTextBox.Name = "_fileNameTextBox"
         Me._fileNameTextBox.ReadOnly = True
         ' 
         ' _numberOfPagesTextBox
         ' 
         resources.ApplyResources(Me._numberOfPagesTextBox, "_numberOfPagesTextBox")
         Me._numberOfPagesTextBox.Name = "_numberOfPagesTextBox"
         Me._numberOfPagesTextBox.ReadOnly = True
         ' 
         ' _numberOfPagesLabel
         ' 
         resources.ApplyResources(Me._numberOfPagesLabel, "_numberOfPagesLabel")
         Me._numberOfPagesLabel.Name = "_numberOfPagesLabel"
         ' 
         ' _pageSizeTextBox
         ' 
         resources.ApplyResources(Me._pageSizeTextBox, "_pageSizeTextBox")
         Me._pageSizeTextBox.Name = "_pageSizeTextBox"
         Me._pageSizeTextBox.ReadOnly = True
         ' 
         ' _pageSizeLabel
         ' 
         resources.ApplyResources(Me._pageSizeLabel, "_pageSizeLabel")
         Me._pageSizeLabel.Name = "_pageSizeLabel"
         ' 
         ' _isEncryptedTextBox
         ' 
         resources.ApplyResources(Me._isEncryptedTextBox, "_isEncryptedTextBox")
         Me._isEncryptedTextBox.Name = "_isEncryptedTextBox"
         Me._isEncryptedTextBox.ReadOnly = True
         ' 
         ' _isEncryptedLabel
         ' 
         resources.ApplyResources(Me._isEncryptedLabel, "_isEncryptedLabel")
         Me._isEncryptedLabel.Name = "_isEncryptedLabel"
         ' 
         ' _versionTextBox
         ' 
         resources.ApplyResources(Me._versionTextBox, "_versionTextBox")
         Me._versionTextBox.Name = "_versionTextBox"
         Me._versionTextBox.ReadOnly = True
         ' 
         ' _versionLabel
         ' 
         resources.ApplyResources(Me._versionLabel, "_versionLabel")
         Me._versionLabel.Name = "_versionLabel"
         ' 
         ' _isPdfATextBox
         ' 
         Me._isPdfATextBox.BackColor = System.Drawing.SystemColors.Control
         resources.ApplyResources(Me._isPdfATextBox, "_isPdfATextBox")
         Me._isPdfATextBox.Name = "_isPdfATextBox"
         ' 
         ' _isPdfALabel
         ' 
         resources.ApplyResources(Me._isPdfALabel, "_isPdfALabel")
         Me._isPdfALabel.Name = "_isPdfALabel"
         ' 
         ' _documentPropertiesControl
         ' 
         resources.ApplyResources(Me._documentPropertiesControl, "_documentPropertiesControl")
         Me._documentPropertiesControl.Name = "_documentPropertiesControl"
         ' 
         ' _isLinearizedTextBox
         ' 
         resources.ApplyResources(Me._isLinearizedTextBox, "_isLinearizedTextBox")
         Me._isLinearizedTextBox.Name = "_isLinearizedTextBox"
         Me._isLinearizedTextBox.ReadOnly = True
         ' 
         ' _isLinearizedLabel
         ' 
         resources.ApplyResources(Me._isLinearizedLabel, "_isLinearizedLabel")
         Me._isLinearizedLabel.Name = "_isLinearizedLabel"
         ' 
         ' DocumentPropertiesDialog
         ' 
         Me.AcceptButton = Me._okButton
         resources.ApplyResources(Me, "$this")
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.CancelButton = Me._okButton
         Me.Controls.Add(Me._isLinearizedTextBox)
         Me.Controls.Add(Me._isLinearizedLabel)
         Me.Controls.Add(Me._documentPropertiesControl)
         Me.Controls.Add(Me._isPdfALabel)
         Me.Controls.Add(Me._isPdfATextBox)
         Me.Controls.Add(Me._versionTextBox)
         Me.Controls.Add(Me._versionLabel)
         Me.Controls.Add(Me._isEncryptedTextBox)
         Me.Controls.Add(Me._isEncryptedLabel)
         Me.Controls.Add(Me._pageSizeTextBox)
         Me.Controls.Add(Me._pageSizeLabel)
         Me.Controls.Add(Me._numberOfPagesTextBox)
         Me.Controls.Add(Me._numberOfPagesLabel)
         Me.Controls.Add(Me._fileNameTextBox)
         Me.Controls.Add(Me._fileNameLabel)
         Me.Controls.Add(Me._notesLabel)
         Me.Controls.Add(Me._okButton)
         Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
         Me.MaximizeBox = False
         Me.MinimizeBox = False
         Me.Name = "DocumentPropertiesDialog"
         Me.ShowInTaskbar = False
         Me.ResumeLayout(False)
         Me.PerformLayout()
      End Sub
#End Region

      Private _okButton As System.Windows.Forms.Button

      Private _notesLabel As System.Windows.Forms.Label

      Private _fileNameLabel As System.Windows.Forms.Label

      Private _fileNameTextBox As System.Windows.Forms.TextBox

      Private _numberOfPagesTextBox As System.Windows.Forms.TextBox

      Private _numberOfPagesLabel As System.Windows.Forms.Label

      Private _pageSizeTextBox As System.Windows.Forms.TextBox

      Private _pageSizeLabel As System.Windows.Forms.Label

      Private _isEncryptedTextBox As System.Windows.Forms.TextBox

      Private _isEncryptedLabel As System.Windows.Forms.Label

      Private _versionTextBox As System.Windows.Forms.TextBox

      Private _versionLabel As System.Windows.Forms.Label

      Private _documentPropertiesControl As DocumentPropertiesControl

      Private _isPdfATextBox As System.Windows.Forms.TextBox

      Private _isPdfALabel As System.Windows.Forms.Label

      Private _isLinearizedTextBox As System.Windows.Forms.TextBox

      Private _isLinearizedLabel As System.Windows.Forms.Label
   End Class
End Namespace