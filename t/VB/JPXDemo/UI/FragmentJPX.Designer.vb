<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FragmentJPX
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
      Me._txtCodeStreamsFiles = New System.Windows.Forms.TextBox
      Me._lblCodeStreamsFiles = New System.Windows.Forms.Label
      Me._lblJPEG2000 = New System.Windows.Forms.Label
      Me._btnCancel = New System.Windows.Forms.Button
      Me._grpCodeStreams = New System.Windows.Forms.GroupBox
      Me._btnCodeStreamsFiles = New System.Windows.Forms.Button
      Me._btnOk = New System.Windows.Forms.Button
      Me._lblOutputFile = New System.Windows.Forms.Label
      Me._txtOutputFile = New System.Windows.Forms.TextBox
      Me._grpOutputFile = New System.Windows.Forms.GroupBox
      Me._btnOutputBrowse = New System.Windows.Forms.Button
      Me._txtInputFile = New System.Windows.Forms.TextBox
      Me._btnInputBrowse = New System.Windows.Forms.Button
      Me._grpInputFile = New System.Windows.Forms.GroupBox
      Me._grpCodeStreams.SuspendLayout()
      Me._grpOutputFile.SuspendLayout()
      Me._grpInputFile.SuspendLayout()
      Me.SuspendLayout()
      '
      '_txtCodeStreamsFiles
      '
      Me._txtCodeStreamsFiles.Location = New System.Drawing.Point(9, 36)
      Me._txtCodeStreamsFiles.Name = "_txtCodeStreamsFiles"
      Me._txtCodeStreamsFiles.Size = New System.Drawing.Size(232, 20)
      Me._txtCodeStreamsFiles.TabIndex = 1
      '
      '_lblCodeStreamsFiles
      '
      Me._lblCodeStreamsFiles.AutoSize = True
      Me._lblCodeStreamsFiles.Location = New System.Drawing.Point(6, 18)
      Me._lblCodeStreamsFiles.Name = "_lblCodeStreamsFiles"
      Me._lblCodeStreamsFiles.Size = New System.Drawing.Size(97, 13)
      Me._lblCodeStreamsFiles.TabIndex = 0
      Me._lblCodeStreamsFiles.Text = "Code Streams Files"
      '
      '_lblJPEG2000
      '
      Me._lblJPEG2000.AutoSize = True
      Me._lblJPEG2000.Location = New System.Drawing.Point(6, 21)
      Me._lblJPEG2000.Name = "_lblJPEG2000"
      Me._lblJPEG2000.Size = New System.Drawing.Size(116, 13)
      Me._lblJPEG2000.TabIndex = 0
      Me._lblJPEG2000.Text = "Select JPEG 2000 File:"
      '
      '_btnCancel
      '
      Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me._btnCancel.Location = New System.Drawing.Point(172, 228)
      Me._btnCancel.Name = "_btnCancel"
      Me._btnCancel.Size = New System.Drawing.Size(75, 23)
      Me._btnCancel.TabIndex = 11
      Me._btnCancel.Text = "Cancel"
      Me._btnCancel.UseVisualStyleBackColor = True
      '
      '_grpCodeStreams
      '
      Me._grpCodeStreams.Controls.Add(Me._lblCodeStreamsFiles)
      Me._grpCodeStreams.Controls.Add(Me._txtCodeStreamsFiles)
      Me._grpCodeStreams.Controls.Add(Me._btnCodeStreamsFiles)
      Me._grpCodeStreams.Location = New System.Drawing.Point(3, 155)
      Me._grpCodeStreams.Name = "_grpCodeStreams"
      Me._grpCodeStreams.Size = New System.Drawing.Size(330, 67)
      Me._grpCodeStreams.TabIndex = 9
      Me._grpCodeStreams.TabStop = False
      Me._grpCodeStreams.Text = "Code Streams"
      '
      '_btnCodeStreamsFiles
      '
      Me._btnCodeStreamsFiles.Location = New System.Drawing.Point(251, 34)
      Me._btnCodeStreamsFiles.Name = "_btnCodeStreamsFiles"
      Me._btnCodeStreamsFiles.Size = New System.Drawing.Size(75, 23)
      Me._btnCodeStreamsFiles.TabIndex = 2
      Me._btnCodeStreamsFiles.Text = "Browse"
      Me._btnCodeStreamsFiles.UseVisualStyleBackColor = True
      '
      '_btnOk
      '
      Me._btnOk.Location = New System.Drawing.Point(91, 228)
      Me._btnOk.Name = "_btnOk"
      Me._btnOk.Size = New System.Drawing.Size(75, 23)
      Me._btnOk.TabIndex = 10
      Me._btnOk.Text = "Ok"
      Me._btnOk.UseVisualStyleBackColor = True
      '
      '_lblOutputFile
      '
      Me._lblOutputFile.AutoSize = True
      Me._lblOutputFile.Location = New System.Drawing.Point(6, 18)
      Me._lblOutputFile.Name = "_lblOutputFile"
      Me._lblOutputFile.Size = New System.Drawing.Size(118, 13)
      Me._lblOutputFile.TabIndex = 0
      Me._lblOutputFile.Text = "Output JPEG 2000 File:"
      '
      '_txtOutputFile
      '
      Me._txtOutputFile.Location = New System.Drawing.Point(9, 36)
      Me._txtOutputFile.Name = "_txtOutputFile"
      Me._txtOutputFile.Size = New System.Drawing.Size(232, 20)
      Me._txtOutputFile.TabIndex = 1
      '
      '_grpOutputFile
      '
      Me._grpOutputFile.Controls.Add(Me._lblOutputFile)
      Me._grpOutputFile.Controls.Add(Me._txtOutputFile)
      Me._grpOutputFile.Controls.Add(Me._btnOutputBrowse)
      Me._grpOutputFile.Location = New System.Drawing.Point(3, 82)
      Me._grpOutputFile.Name = "_grpOutputFile"
      Me._grpOutputFile.Size = New System.Drawing.Size(330, 67)
      Me._grpOutputFile.TabIndex = 8
      Me._grpOutputFile.TabStop = False
      Me._grpOutputFile.Text = "Output File"
      '
      '_btnOutputBrowse
      '
      Me._btnOutputBrowse.Location = New System.Drawing.Point(251, 34)
      Me._btnOutputBrowse.Name = "_btnOutputBrowse"
      Me._btnOutputBrowse.Size = New System.Drawing.Size(75, 23)
      Me._btnOutputBrowse.TabIndex = 2
      Me._btnOutputBrowse.Text = "Browse"
      Me._btnOutputBrowse.UseVisualStyleBackColor = True
      '
      '_txtInputFile
      '
      Me._txtInputFile.Location = New System.Drawing.Point(13, 39)
      Me._txtInputFile.Name = "_txtInputFile"
      Me._txtInputFile.Size = New System.Drawing.Size(232, 20)
      Me._txtInputFile.TabIndex = 1
      '
      '_btnInputBrowse
      '
      Me._btnInputBrowse.Location = New System.Drawing.Point(251, 37)
      Me._btnInputBrowse.Name = "_btnInputBrowse"
      Me._btnInputBrowse.Size = New System.Drawing.Size(75, 23)
      Me._btnInputBrowse.TabIndex = 2
      Me._btnInputBrowse.Text = "Browse"
      Me._btnInputBrowse.UseVisualStyleBackColor = True
      '
      '_grpInputFile
      '
      Me._grpInputFile.Controls.Add(Me._lblJPEG2000)
      Me._grpInputFile.Controls.Add(Me._txtInputFile)
      Me._grpInputFile.Controls.Add(Me._btnInputBrowse)
      Me._grpInputFile.Location = New System.Drawing.Point(3, 4)
      Me._grpInputFile.Name = "_grpInputFile"
      Me._grpInputFile.Size = New System.Drawing.Size(330, 72)
      Me._grpInputFile.TabIndex = 7
      Me._grpInputFile.TabStop = False
      Me._grpInputFile.Text = "Input File"
      '
      'FragmentJPX
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(337, 254)
      Me.Controls.Add(Me._btnCancel)
      Me.Controls.Add(Me._grpCodeStreams)
      Me.Controls.Add(Me._btnOk)
      Me.Controls.Add(Me._grpOutputFile)
      Me.Controls.Add(Me._grpInputFile)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "FragmentJPX"
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
      Me.Text = "Fragment JPX"
      Me._grpCodeStreams.ResumeLayout(False)
      Me._grpCodeStreams.PerformLayout()
      Me._grpOutputFile.ResumeLayout(False)
      Me._grpOutputFile.PerformLayout()
      Me._grpInputFile.ResumeLayout(False)
      Me._grpInputFile.PerformLayout()
      Me.ResumeLayout(False)

   End Sub
   Private WithEvents _txtCodeStreamsFiles As System.Windows.Forms.TextBox
   Private WithEvents _lblCodeStreamsFiles As System.Windows.Forms.Label
   Private WithEvents _lblJPEG2000 As System.Windows.Forms.Label
   Private WithEvents _btnCancel As System.Windows.Forms.Button
   Private WithEvents _grpCodeStreams As System.Windows.Forms.GroupBox
   Private WithEvents _btnCodeStreamsFiles As System.Windows.Forms.Button
   Private WithEvents _btnOk As System.Windows.Forms.Button
   Private WithEvents _lblOutputFile As System.Windows.Forms.Label
   Private WithEvents _txtOutputFile As System.Windows.Forms.TextBox
   Private WithEvents _grpOutputFile As System.Windows.Forms.GroupBox
   Private WithEvents _btnOutputBrowse As System.Windows.Forms.Button
   Private WithEvents _txtInputFile As System.Windows.Forms.TextBox
   Private WithEvents _btnInputBrowse As System.Windows.Forms.Button
   Private WithEvents _grpInputFile As System.Windows.Forms.GroupBox
End Class
