<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ExtractFrames
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
      Me._txtInputFile = New System.Windows.Forms.TextBox
      Me._btnInputBrowse = New System.Windows.Forms.Button
      Me._btnExtract = New System.Windows.Forms.Button
      Me._grpFrameIndex = New System.Windows.Forms.GroupBox
      Me._txtToFrame = New System.Windows.Forms.TextBox
      Me._txtFromFrame = New System.Windows.Forms.TextBox
      Me.label2 = New System.Windows.Forms.Label
      Me.label1 = New System.Windows.Forms.Label
      Me._lblJPEG2000 = New System.Windows.Forms.Label
      Me._lblOutputFile = New System.Windows.Forms.Label
      Me._grpOutputFile = New System.Windows.Forms.GroupBox
      Me._txtOutputFile = New System.Windows.Forms.TextBox
      Me._btnOutputBrowse = New System.Windows.Forms.Button
      Me._grpInputFile = New System.Windows.Forms.GroupBox
      Me._grpFrameIndex.SuspendLayout()
      Me._grpOutputFile.SuspendLayout()
      Me._grpInputFile.SuspendLayout()
      Me.SuspendLayout()
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
      '_btnExtract
      '
      Me._btnExtract.Location = New System.Drawing.Point(257, 186)
      Me._btnExtract.Name = "_btnExtract"
      Me._btnExtract.Size = New System.Drawing.Size(75, 23)
      Me._btnExtract.TabIndex = 11
      Me._btnExtract.Text = "&Extract"
      Me._btnExtract.UseVisualStyleBackColor = True
      '
      '_grpFrameIndex
      '
      Me._grpFrameIndex.Controls.Add(Me._txtToFrame)
      Me._grpFrameIndex.Controls.Add(Me._txtFromFrame)
      Me._grpFrameIndex.Controls.Add(Me.label2)
      Me._grpFrameIndex.Controls.Add(Me.label1)
      Me._grpFrameIndex.Location = New System.Drawing.Point(6, 156)
      Me._grpFrameIndex.Name = "_grpFrameIndex"
      Me._grpFrameIndex.Size = New System.Drawing.Size(241, 53)
      Me._grpFrameIndex.TabIndex = 10
      Me._grpFrameIndex.TabStop = False
      Me._grpFrameIndex.Text = "Frame Index - 0 based"
      '
      '_txtToFrame
      '
      Me._txtToFrame.Location = New System.Drawing.Point(174, 23)
      Me._txtToFrame.Name = "_txtToFrame"
      Me._txtToFrame.Size = New System.Drawing.Size(51, 20)
      Me._txtToFrame.TabIndex = 9
      '
      '_txtFromFrame
      '
      Me._txtFromFrame.Location = New System.Drawing.Point(51, 23)
      Me._txtFromFrame.Name = "_txtFromFrame"
      Me._txtFromFrame.Size = New System.Drawing.Size(51, 20)
      Me._txtFromFrame.TabIndex = 8
      '
      'label2
      '
      Me.label2.AutoSize = True
      Me.label2.Location = New System.Drawing.Point(148, 25)
      Me.label2.Name = "label2"
      Me.label2.Size = New System.Drawing.Size(20, 13)
      Me.label2.TabIndex = 7
      Me.label2.Text = "To"
      '
      'label1
      '
      Me.label1.AutoSize = True
      Me.label1.Location = New System.Drawing.Point(15, 25)
      Me.label1.Name = "label1"
      Me.label1.Size = New System.Drawing.Size(30, 13)
      Me.label1.TabIndex = 6
      Me.label1.Text = "From"
      '
      '_lblJPEG2000
      '
      Me._lblJPEG2000.AutoSize = True
      Me._lblJPEG2000.Location = New System.Drawing.Point(6, 21)
      Me._lblJPEG2000.Name = "_lblJPEG2000"
      Me._lblJPEG2000.Size = New System.Drawing.Size(104, 13)
      Me._lblJPEG2000.TabIndex = 0
      Me._lblJPEG2000.Text = "Select JP2/JPX File:"
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
      '_grpOutputFile
      '
      Me._grpOutputFile.Controls.Add(Me._lblOutputFile)
      Me._grpOutputFile.Controls.Add(Me._txtOutputFile)
      Me._grpOutputFile.Controls.Add(Me._btnOutputBrowse)
      Me._grpOutputFile.Location = New System.Drawing.Point(6, 83)
      Me._grpOutputFile.Name = "_grpOutputFile"
      Me._grpOutputFile.Size = New System.Drawing.Size(330, 67)
      Me._grpOutputFile.TabIndex = 9
      Me._grpOutputFile.TabStop = False
      Me._grpOutputFile.Text = "Output File"
      '
      '_txtOutputFile
      '
      Me._txtOutputFile.Location = New System.Drawing.Point(9, 36)
      Me._txtOutputFile.Name = "_txtOutputFile"
      Me._txtOutputFile.Size = New System.Drawing.Size(232, 20)
      Me._txtOutputFile.TabIndex = 1
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
      '_grpInputFile
      '
      Me._grpInputFile.Controls.Add(Me._lblJPEG2000)
      Me._grpInputFile.Controls.Add(Me._txtInputFile)
      Me._grpInputFile.Controls.Add(Me._btnInputBrowse)
      Me._grpInputFile.Location = New System.Drawing.Point(6, 5)
      Me._grpInputFile.Name = "_grpInputFile"
      Me._grpInputFile.Size = New System.Drawing.Size(330, 72)
      Me._grpInputFile.TabIndex = 8
      Me._grpInputFile.TabStop = False
      Me._grpInputFile.Text = "Input File"
      '
      'ExtractFrames
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(342, 216)
      Me.Controls.Add(Me._btnExtract)
      Me.Controls.Add(Me._grpFrameIndex)
      Me.Controls.Add(Me._grpOutputFile)
      Me.Controls.Add(Me._grpInputFile)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "ExtractFrames"
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
      Me.Text = "Extract Frames"
      Me._grpFrameIndex.ResumeLayout(False)
      Me._grpFrameIndex.PerformLayout()
      Me._grpOutputFile.ResumeLayout(False)
      Me._grpOutputFile.PerformLayout()
      Me._grpInputFile.ResumeLayout(False)
      Me._grpInputFile.PerformLayout()
      Me.ResumeLayout(False)

   End Sub
   Private WithEvents _txtInputFile As System.Windows.Forms.TextBox
   Private WithEvents _btnInputBrowse As System.Windows.Forms.Button
   Private WithEvents _btnExtract As System.Windows.Forms.Button
   Private WithEvents _grpFrameIndex As System.Windows.Forms.GroupBox
   Private WithEvents _lblJPEG2000 As System.Windows.Forms.Label
   Private WithEvents _lblOutputFile As System.Windows.Forms.Label
   Private WithEvents _grpOutputFile As System.Windows.Forms.GroupBox
   Private WithEvents _txtOutputFile As System.Windows.Forms.TextBox
   Private WithEvents _btnOutputBrowse As System.Windows.Forms.Button
   Private WithEvents _grpInputFile As System.Windows.Forms.GroupBox
   Private WithEvents _txtToFrame As System.Windows.Forms.TextBox
   Private WithEvents _txtFromFrame As System.Windows.Forms.TextBox
   Private WithEvents label2 As System.Windows.Forms.Label
   Private WithEvents label1 As System.Windows.Forms.Label
End Class
