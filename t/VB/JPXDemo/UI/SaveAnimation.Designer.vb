<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SaveAnimation
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SaveAnimation))
      Me._txtFileName = New System.Windows.Forms.TextBox
      Me._grpFile = New System.Windows.Forms.GroupBox
      Me._btnBrowse = New System.Windows.Forms.Button
      Me._lblFileName = New System.Windows.Forms.Label
      Me._btnSave = New System.Windows.Forms.Button
      Me._grpFile.SuspendLayout()
      Me.SuspendLayout()
      '
      '_txtFileName
      '
      Me._txtFileName.Location = New System.Drawing.Point(6, 37)
      Me._txtFileName.Name = "_txtFileName"
      Me._txtFileName.Size = New System.Drawing.Size(306, 20)
      Me._txtFileName.TabIndex = 1
      '
      '_grpFile
      '
      Me._grpFile.Controls.Add(Me._btnBrowse)
      Me._grpFile.Controls.Add(Me._txtFileName)
      Me._grpFile.Controls.Add(Me._lblFileName)
      Me._grpFile.Location = New System.Drawing.Point(4, 4)
      Me._grpFile.Name = "_grpFile"
      Me._grpFile.Size = New System.Drawing.Size(399, 69)
      Me._grpFile.TabIndex = 4
      Me._grpFile.TabStop = False
      Me._grpFile.Text = "File"
      '
      '_btnBrowse
      '
      Me._btnBrowse.Location = New System.Drawing.Point(318, 35)
      Me._btnBrowse.Name = "_btnBrowse"
      Me._btnBrowse.Size = New System.Drawing.Size(75, 23)
      Me._btnBrowse.TabIndex = 2
      Me._btnBrowse.Text = "&Browse"
      Me._btnBrowse.UseVisualStyleBackColor = True
      '
      '_lblFileName
      '
      Me._lblFileName.AutoSize = True
      Me._lblFileName.Location = New System.Drawing.Point(8, 16)
      Me._lblFileName.Name = "_lblFileName"
      Me._lblFileName.Size = New System.Drawing.Size(116, 13)
      Me._lblFileName.TabIndex = 0
      Me._lblFileName.Text = "Select JPEG 2000 File:"
      '
      '_btnSave
      '
      Me._btnSave.Location = New System.Drawing.Point(166, 79)
      Me._btnSave.Name = "_btnSave"
      Me._btnSave.Size = New System.Drawing.Size(75, 23)
      Me._btnSave.TabIndex = 3
      Me._btnSave.Text = "&Save"
      Me._btnSave.UseVisualStyleBackColor = True
      '
      'SaveAnimation
      '
      Me.AcceptButton = Me._btnSave
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(407, 106)
      Me.Controls.Add(Me._grpFile)
      Me.Controls.Add(Me._btnSave)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "SaveAnimation"
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
      Me.Text = "Save Animation"
      Me._grpFile.ResumeLayout(False)
      Me._grpFile.PerformLayout()
      Me.ResumeLayout(False)

   End Sub
   Private WithEvents _txtFileName As System.Windows.Forms.TextBox
   Private WithEvents _grpFile As System.Windows.Forms.GroupBox
   Private WithEvents _btnBrowse As System.Windows.Forms.Button
   Private WithEvents _lblFileName As System.Windows.Forms.Label
   Private WithEvents _btnSave As System.Windows.Forms.Button
End Class
