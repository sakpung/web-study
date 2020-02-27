<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReadGML
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReadGML))
      Me._lblJPEG2000 = New System.Windows.Forms.Label
      Me._btnRead = New System.Windows.Forms.Button
      Me._txtJPEG2000 = New System.Windows.Forms.TextBox
      Me._grpFile = New System.Windows.Forms.GroupBox
      Me._btnJPEG2000Browse = New System.Windows.Forms.Button
      Me._grpFile.SuspendLayout()
      Me.SuspendLayout()
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
      '_btnRead
      '
      Me._btnRead.Location = New System.Drawing.Point(135, 83)
      Me._btnRead.Name = "_btnRead"
      Me._btnRead.Size = New System.Drawing.Size(75, 23)
      Me._btnRead.TabIndex = 4
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
      '_grpFile
      '
      Me._grpFile.Controls.Add(Me._lblJPEG2000)
      Me._grpFile.Controls.Add(Me._txtJPEG2000)
      Me._grpFile.Controls.Add(Me._btnJPEG2000Browse)
      Me._grpFile.Location = New System.Drawing.Point(6, 5)
      Me._grpFile.Name = "_grpFile"
      Me._grpFile.Size = New System.Drawing.Size(330, 72)
      Me._grpFile.TabIndex = 3
      Me._grpFile.TabStop = False
      Me._grpFile.Text = "File"
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
      'ReadGML
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(343, 110)
      Me.Controls.Add(Me._btnRead)
      Me.Controls.Add(Me._grpFile)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "ReadGML"
      Me.ShowInTaskbar = False
      Me.Text = "Read GML Data"
      Me._grpFile.ResumeLayout(False)
      Me._grpFile.PerformLayout()
      Me.ResumeLayout(False)

   End Sub
   Private WithEvents _lblJPEG2000 As System.Windows.Forms.Label
   Private WithEvents _btnRead As System.Windows.Forms.Button
   Private WithEvents _txtJPEG2000 As System.Windows.Forms.TextBox
   Private WithEvents _grpFile As System.Windows.Forms.GroupBox
   Private WithEvents _btnJPEG2000Browse As System.Windows.Forms.Button
End Class
