<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReadCommon
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReadCommon))
      Me._nudBoxIndex = New System.Windows.Forms.NumericUpDown
      Me._grpBoxIndex = New System.Windows.Forms.GroupBox
      Me._btnJPEG2000Browse = New System.Windows.Forms.Button
      Me._grpFilterType = New System.Windows.Forms.GroupBox
      Me._txtFilterType = New System.Windows.Forms.TextBox
      Me._btnRead = New System.Windows.Forms.Button
      Me._txtJPEG2000 = New System.Windows.Forms.TextBox
      Me._txtSecond = New System.Windows.Forms.TextBox
      Me._lblSecond = New System.Windows.Forms.Label
      Me._grpData = New System.Windows.Forms.GroupBox
      Me._btnSecondBrowse = New System.Windows.Forms.Button
      Me._lblJPEG2000 = New System.Windows.Forms.Label
      Me._grpFile = New System.Windows.Forms.GroupBox
      CType(Me._nudBoxIndex, System.ComponentModel.ISupportInitialize).BeginInit()
      Me._grpBoxIndex.SuspendLayout()
      Me._grpFilterType.SuspendLayout()
      Me._grpData.SuspendLayout()
      Me._grpFile.SuspendLayout()
      Me.SuspendLayout()
      '
      '_nudBoxIndex
      '
      Me._nudBoxIndex.Location = New System.Drawing.Point(62, 30)
      Me._nudBoxIndex.Name = "_nudBoxIndex"
      Me._nudBoxIndex.Size = New System.Drawing.Size(117, 20)
      Me._nudBoxIndex.TabIndex = 0
      '
      '_grpBoxIndex
      '
      Me._grpBoxIndex.Controls.Add(Me._nudBoxIndex)
      Me._grpBoxIndex.Location = New System.Drawing.Point(4, 208)
      Me._grpBoxIndex.Name = "_grpBoxIndex"
      Me._grpBoxIndex.Size = New System.Drawing.Size(241, 67)
      Me._grpBoxIndex.TabIndex = 8
      Me._grpBoxIndex.TabStop = False
      Me._grpBoxIndex.Text = "Box Index - 0 based"
      '
      '_btnJPEG2000Browse
      '
      Me._btnJPEG2000Browse.Location = New System.Drawing.Point(251, 37)
      Me._btnJPEG2000Browse.Name = "_btnJPEG2000Browse"
      Me._btnJPEG2000Browse.Size = New System.Drawing.Size(75, 23)
      Me._btnJPEG2000Browse.TabIndex = 2
      Me._btnJPEG2000Browse.Text = "Browse"
      Me._btnJPEG2000Browse.UseVisualStyleBackColor = True
      '
      '_grpFilterType
      '
      Me._grpFilterType.Controls.Add(Me._txtFilterType)
      Me._grpFilterType.Location = New System.Drawing.Point(4, 155)
      Me._grpFilterType.Name = "_grpFilterType"
      Me._grpFilterType.Size = New System.Drawing.Size(330, 48)
      Me._grpFilterType.TabIndex = 7
      Me._grpFilterType.TabStop = False
      Me._grpFilterType.Text = "Filter Type"
      '
      '_txtFilterType
      '
      Me._txtFilterType.Location = New System.Drawing.Point(40, 18)
      Me._txtFilterType.Name = "_txtFilterType"
      Me._txtFilterType.ReadOnly = True
      Me._txtFilterType.Size = New System.Drawing.Size(250, 20)
      Me._txtFilterType.TabIndex = 0
      '
      '_btnRead
      '
      Me._btnRead.Location = New System.Drawing.Point(255, 238)
      Me._btnRead.Name = "_btnRead"
      Me._btnRead.Size = New System.Drawing.Size(75, 23)
      Me._btnRead.TabIndex = 9
      Me._btnRead.Text = "&Read"
      Me._btnRead.UseVisualStyleBackColor = True
      '
      '_txtJPEG2000
      '
      Me._txtJPEG2000.Location = New System.Drawing.Point(13, 39)
      Me._txtJPEG2000.Name = "_txtJPEG2000"
      Me._txtJPEG2000.Size = New System.Drawing.Size(232, 20)
      Me._txtJPEG2000.TabIndex = 1
      '
      '_txtSecond
      '
      Me._txtSecond.Location = New System.Drawing.Point(9, 36)
      Me._txtSecond.Name = "_txtSecond"
      Me._txtSecond.Size = New System.Drawing.Size(232, 20)
      Me._txtSecond.TabIndex = 1
      '
      '_lblSecond
      '
      Me._lblSecond.AutoSize = True
      Me._lblSecond.Location = New System.Drawing.Point(6, 18)
      Me._lblSecond.Name = "_lblSecond"
      Me._lblSecond.Size = New System.Drawing.Size(35, 13)
      Me._lblSecond.TabIndex = 0
      Me._lblSecond.Text = "label1"
      '
      '_grpData
      '
      Me._grpData.Controls.Add(Me._lblSecond)
      Me._grpData.Controls.Add(Me._txtSecond)
      Me._grpData.Controls.Add(Me._btnSecondBrowse)
      Me._grpData.Location = New System.Drawing.Point(4, 84)
      Me._grpData.Name = "_grpData"
      Me._grpData.Size = New System.Drawing.Size(330, 67)
      Me._grpData.TabIndex = 6
      Me._grpData.TabStop = False
      Me._grpData.Text = "Data"
      '
      '_btnSecondBrowse
      '
      Me._btnSecondBrowse.Location = New System.Drawing.Point(251, 34)
      Me._btnSecondBrowse.Name = "_btnSecondBrowse"
      Me._btnSecondBrowse.Size = New System.Drawing.Size(75, 23)
      Me._btnSecondBrowse.TabIndex = 2
      Me._btnSecondBrowse.Text = "Browse"
      Me._btnSecondBrowse.UseVisualStyleBackColor = True
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
      '_grpFile
      '
      Me._grpFile.Controls.Add(Me._lblJPEG2000)
      Me._grpFile.Controls.Add(Me._txtJPEG2000)
      Me._grpFile.Controls.Add(Me._btnJPEG2000Browse)
      Me._grpFile.Location = New System.Drawing.Point(4, 6)
      Me._grpFile.Name = "_grpFile"
      Me._grpFile.Size = New System.Drawing.Size(330, 72)
      Me._grpFile.TabIndex = 5
      Me._grpFile.TabStop = False
      Me._grpFile.Text = "File"
      '
      'ReadCommon
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(339, 281)
      Me.Controls.Add(Me._grpBoxIndex)
      Me.Controls.Add(Me._grpFilterType)
      Me.Controls.Add(Me._btnRead)
      Me.Controls.Add(Me._grpData)
      Me.Controls.Add(Me._grpFile)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "ReadCommon"
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
      Me.Text = "Read Common"
      CType(Me._nudBoxIndex, System.ComponentModel.ISupportInitialize).EndInit()
      Me._grpBoxIndex.ResumeLayout(False)
      Me._grpFilterType.ResumeLayout(False)
      Me._grpFilterType.PerformLayout()
      Me._grpData.ResumeLayout(False)
      Me._grpData.PerformLayout()
      Me._grpFile.ResumeLayout(False)
      Me._grpFile.PerformLayout()
      Me.ResumeLayout(False)

   End Sub
   Private WithEvents _nudBoxIndex As System.Windows.Forms.NumericUpDown
   Private WithEvents _grpBoxIndex As System.Windows.Forms.GroupBox
   Private WithEvents _btnJPEG2000Browse As System.Windows.Forms.Button
   Private WithEvents _grpFilterType As System.Windows.Forms.GroupBox
   Private WithEvents _txtFilterType As System.Windows.Forms.TextBox
   Private WithEvents _btnRead As System.Windows.Forms.Button
   Private WithEvents _txtJPEG2000 As System.Windows.Forms.TextBox
   Private WithEvents _txtSecond As System.Windows.Forms.TextBox
   Private WithEvents _lblSecond As System.Windows.Forms.Label
   Private WithEvents _grpData As System.Windows.Forms.GroupBox
   Private WithEvents _btnSecondBrowse As System.Windows.Forms.Button
   Private WithEvents _lblJPEG2000 As System.Windows.Forms.Label
   Private WithEvents _grpFile As System.Windows.Forms.GroupBox
End Class
