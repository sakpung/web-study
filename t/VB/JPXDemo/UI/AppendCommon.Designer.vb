<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AppendCommon
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AppendCommon))
      Me._lblFilterType = New System.Windows.Forms.Label
      Me._btnCancel = New System.Windows.Forms.Button
      Me._btnOk = New System.Windows.Forms.Button
      Me._grpData = New System.Windows.Forms.GroupBox
      Me._cbFilterType = New System.Windows.Forms.ComboBox
      Me._lblSecond = New System.Windows.Forms.Label
      Me._txtSecond = New System.Windows.Forms.TextBox
      Me._btnSecondBrowse = New System.Windows.Forms.Button
      Me._lblJPEG2000 = New System.Windows.Forms.Label
      Me._grpFile = New System.Windows.Forms.GroupBox
      Me._txtJPEG2000 = New System.Windows.Forms.TextBox
      Me._btnJPEG2000Browse = New System.Windows.Forms.Button
      Me._grpData.SuspendLayout()
      Me._grpFile.SuspendLayout()
      Me.SuspendLayout()
      '
      '_lblFilterType
      '
      Me._lblFilterType.AutoSize = True
      Me._lblFilterType.Location = New System.Drawing.Point(10, 22)
      Me._lblFilterType.Name = "_lblFilterType"
      Me._lblFilterType.Size = New System.Drawing.Size(56, 13)
      Me._lblFilterType.TabIndex = 0
      Me._lblFilterType.Text = "Filter Type"
      '
      '_btnCancel
      '
      Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me._btnCancel.Location = New System.Drawing.Point(205, 186)
      Me._btnCancel.Name = "_btnCancel"
      Me._btnCancel.Size = New System.Drawing.Size(75, 23)
      Me._btnCancel.TabIndex = 7
      Me._btnCancel.Text = "Cancel"
      Me._btnCancel.UseVisualStyleBackColor = True
      '
      '_btnOk
      '
      Me._btnOk.Location = New System.Drawing.Point(124, 186)
      Me._btnOk.Name = "_btnOk"
      Me._btnOk.Size = New System.Drawing.Size(75, 23)
      Me._btnOk.TabIndex = 6
      Me._btnOk.Text = "Ok"
      Me._btnOk.UseVisualStyleBackColor = True
      '
      '_grpData
      '
      Me._grpData.Controls.Add(Me._lblFilterType)
      Me._grpData.Controls.Add(Me._cbFilterType)
      Me._grpData.Controls.Add(Me._lblSecond)
      Me._grpData.Controls.Add(Me._txtSecond)
      Me._grpData.Controls.Add(Me._btnSecondBrowse)
      Me._grpData.Location = New System.Drawing.Point(7, 81)
      Me._grpData.Name = "_grpData"
      Me._grpData.Size = New System.Drawing.Size(386, 99)
      Me._grpData.TabIndex = 5
      Me._grpData.TabStop = False
      Me._grpData.Text = "Data"
      '
      '_cbFilterType
      '
      Me._cbFilterType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me._cbFilterType.FormattingEnabled = True
      Me._cbFilterType.Location = New System.Drawing.Point(72, 19)
      Me._cbFilterType.Name = "_cbFilterType"
      Me._cbFilterType.Size = New System.Drawing.Size(164, 21)
      Me._cbFilterType.TabIndex = 1
      '
      '_lblSecond
      '
      Me._lblSecond.AutoSize = True
      Me._lblSecond.Location = New System.Drawing.Point(10, 49)
      Me._lblSecond.Name = "_lblSecond"
      Me._lblSecond.Size = New System.Drawing.Size(35, 13)
      Me._lblSecond.TabIndex = 2
      Me._lblSecond.Text = "label1"
      '
      '_txtSecond
      '
      Me._txtSecond.Location = New System.Drawing.Point(13, 67)
      Me._txtSecond.Name = "_txtSecond"
      Me._txtSecond.Size = New System.Drawing.Size(282, 20)
      Me._txtSecond.TabIndex = 3
      '
      '_btnSecondBrowse
      '
      Me._btnSecondBrowse.Location = New System.Drawing.Point(301, 66)
      Me._btnSecondBrowse.Name = "_btnSecondBrowse"
      Me._btnSecondBrowse.Size = New System.Drawing.Size(75, 23)
      Me._btnSecondBrowse.TabIndex = 4
      Me._btnSecondBrowse.Text = "Browse"
      Me._btnSecondBrowse.UseVisualStyleBackColor = True
      '
      '_lblJPEG2000
      '
      Me._lblJPEG2000.AutoSize = True
      Me._lblJPEG2000.Location = New System.Drawing.Point(10, 21)
      Me._lblJPEG2000.Name = "_lblJPEG2000"
      Me._lblJPEG2000.Size = New System.Drawing.Size(104, 13)
      Me._lblJPEG2000.TabIndex = 0
      Me._lblJPEG2000.Text = "Select JP2/JPX File:"
      '
      '_grpFile
      '
      Me._grpFile.Controls.Add(Me._lblJPEG2000)
      Me._grpFile.Controls.Add(Me._txtJPEG2000)
      Me._grpFile.Controls.Add(Me._btnJPEG2000Browse)
      Me._grpFile.Location = New System.Drawing.Point(7, 3)
      Me._grpFile.Name = "_grpFile"
      Me._grpFile.Size = New System.Drawing.Size(386, 72)
      Me._grpFile.TabIndex = 4
      Me._grpFile.TabStop = False
      Me._grpFile.Text = "File"
      '
      '_txtJPEG2000
      '
      Me._txtJPEG2000.Location = New System.Drawing.Point(13, 39)
      Me._txtJPEG2000.Name = "_txtJPEG2000"
      Me._txtJPEG2000.Size = New System.Drawing.Size(282, 20)
      Me._txtJPEG2000.TabIndex = 1
      '
      '_btnJPEG2000Browse
      '
      Me._btnJPEG2000Browse.Location = New System.Drawing.Point(301, 38)
      Me._btnJPEG2000Browse.Name = "_btnJPEG2000Browse"
      Me._btnJPEG2000Browse.Size = New System.Drawing.Size(75, 23)
      Me._btnJPEG2000Browse.TabIndex = 2
      Me._btnJPEG2000Browse.Text = "Browse"
      Me._btnJPEG2000Browse.UseVisualStyleBackColor = True
      '
      'AppendCommon
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.CancelButton = Me._btnCancel
      Me.ClientSize = New System.Drawing.Size(400, 213)
      Me.Controls.Add(Me._btnCancel)
      Me.Controls.Add(Me._btnOk)
      Me.Controls.Add(Me._grpData)
      Me.Controls.Add(Me._grpFile)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "AppendCommon"
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
      Me.Text = "Append Common"
      Me._grpData.ResumeLayout(False)
      Me._grpData.PerformLayout()
      Me._grpFile.ResumeLayout(False)
      Me._grpFile.PerformLayout()
      Me.ResumeLayout(False)

   End Sub
   Private WithEvents _lblFilterType As System.Windows.Forms.Label
   Private WithEvents _btnCancel As System.Windows.Forms.Button
   Private WithEvents _btnOk As System.Windows.Forms.Button
   Private WithEvents _grpData As System.Windows.Forms.GroupBox
   Private WithEvents _cbFilterType As System.Windows.Forms.ComboBox
   Private WithEvents _lblSecond As System.Windows.Forms.Label
   Private WithEvents _txtSecond As System.Windows.Forms.TextBox
   Private WithEvents _btnSecondBrowse As System.Windows.Forms.Button
   Private WithEvents _lblJPEG2000 As System.Windows.Forms.Label
   Private WithEvents _grpFile As System.Windows.Forms.GroupBox
   Private WithEvents _txtJPEG2000 As System.Windows.Forms.TextBox
   Private WithEvents _btnJPEG2000Browse As System.Windows.Forms.Button
End Class
