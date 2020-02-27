<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AppendDigitalSignature
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AppendDigitalSignature))
      Me._cbSignatureType = New System.Windows.Forms.ComboBox
      Me._nudLength = New System.Windows.Forms.NumericUpDown
      Me._cbPointerType = New System.Windows.Forms.ComboBox
      Me._grpType = New System.Windows.Forms.GroupBox
      Me._lblPointerType = New System.Windows.Forms.Label
      Me._lblSignatureType = New System.Windows.Forms.Label
      Me._nudOffset = New System.Windows.Forms.NumericUpDown
      Me._lblLength = New System.Windows.Forms.Label
      Me._lblOffset = New System.Windows.Forms.Label
      Me._grpPointerData = New System.Windows.Forms.GroupBox
      Me._btnCancel = New System.Windows.Forms.Button
      Me._btnOk = New System.Windows.Forms.Button
      Me._grpFile = New System.Windows.Forms.GroupBox
      Me._lblFirst = New System.Windows.Forms.Label
      Me._txtJPEG2000File = New System.Windows.Forms.TextBox
      Me._btnJPEGBrowse = New System.Windows.Forms.Button
      Me._lblSignatureDataFile = New System.Windows.Forms.Label
      Me._txtSignatureDataFile = New System.Windows.Forms.TextBox
      Me._btnSignatureData = New System.Windows.Forms.Button
      Me._grpData = New System.Windows.Forms.GroupBox
      CType(Me._nudLength, System.ComponentModel.ISupportInitialize).BeginInit()
      Me._grpType.SuspendLayout()
      CType(Me._nudOffset, System.ComponentModel.ISupportInitialize).BeginInit()
      Me._grpPointerData.SuspendLayout()
      Me._grpFile.SuspendLayout()
      Me._grpData.SuspendLayout()
      Me.SuspendLayout()
      '
      '_cbSignatureType
      '
      Me._cbSignatureType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me._cbSignatureType.FormattingEnabled = True
      Me._cbSignatureType.Location = New System.Drawing.Point(94, 17)
      Me._cbSignatureType.Name = "_cbSignatureType"
      Me._cbSignatureType.Size = New System.Drawing.Size(75, 21)
      Me._cbSignatureType.TabIndex = 4
      '
      '_nudLength
      '
      Me._nudLength.Location = New System.Drawing.Point(256, 18)
      Me._nudLength.Name = "_nudLength"
      Me._nudLength.Size = New System.Drawing.Size(75, 20)
      Me._nudLength.TabIndex = 3
      '
      '_cbPointerType
      '
      Me._cbPointerType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me._cbPointerType.FormattingEnabled = True
      Me._cbPointerType.Location = New System.Drawing.Point(256, 18)
      Me._cbPointerType.Name = "_cbPointerType"
      Me._cbPointerType.Size = New System.Drawing.Size(75, 21)
      Me._cbPointerType.TabIndex = 3
      '
      '_grpType
      '
      Me._grpType.Controls.Add(Me._cbSignatureType)
      Me._grpType.Controls.Add(Me._cbPointerType)
      Me._grpType.Controls.Add(Me._lblPointerType)
      Me._grpType.Controls.Add(Me._lblSignatureType)
      Me._grpType.Location = New System.Drawing.Point(9, 83)
      Me._grpType.Name = "_grpType"
      Me._grpType.Size = New System.Drawing.Size(342, 50)
      Me._grpType.TabIndex = 16
      Me._grpType.TabStop = False
      Me._grpType.Text = "Type"
      '
      '_lblPointerType
      '
      Me._lblPointerType.AutoSize = True
      Me._lblPointerType.Location = New System.Drawing.Point(186, 20)
      Me._lblPointerType.Name = "_lblPointerType"
      Me._lblPointerType.Size = New System.Drawing.Size(67, 13)
      Me._lblPointerType.TabIndex = 1
      Me._lblPointerType.Text = "Pointer Type"
      '
      '_lblSignatureType
      '
      Me._lblSignatureType.AutoSize = True
      Me._lblSignatureType.Location = New System.Drawing.Point(10, 20)
      Me._lblSignatureType.Name = "_lblSignatureType"
      Me._lblSignatureType.Size = New System.Drawing.Size(79, 13)
      Me._lblSignatureType.TabIndex = 0
      Me._lblSignatureType.Text = "Signature Type"
      '
      '_nudOffset
      '
      Me._nudOffset.Location = New System.Drawing.Point(95, 18)
      Me._nudOffset.Name = "_nudOffset"
      Me._nudOffset.Size = New System.Drawing.Size(75, 20)
      Me._nudOffset.TabIndex = 2
      '
      '_lblLength
      '
      Me._lblLength.AutoSize = True
      Me._lblLength.Location = New System.Drawing.Point(186, 18)
      Me._lblLength.Name = "_lblLength"
      Me._lblLength.Size = New System.Drawing.Size(40, 13)
      Me._lblLength.TabIndex = 1
      Me._lblLength.Text = "Length"
      '
      '_lblOffset
      '
      Me._lblOffset.AutoSize = True
      Me._lblOffset.Location = New System.Drawing.Point(10, 18)
      Me._lblOffset.Name = "_lblOffset"
      Me._lblOffset.Size = New System.Drawing.Size(35, 13)
      Me._lblOffset.TabIndex = 0
      Me._lblOffset.Text = "Offset"
      '
      '_grpPointerData
      '
      Me._grpPointerData.Controls.Add(Me._nudLength)
      Me._grpPointerData.Controls.Add(Me._nudOffset)
      Me._grpPointerData.Controls.Add(Me._lblLength)
      Me._grpPointerData.Controls.Add(Me._lblOffset)
      Me._grpPointerData.Location = New System.Drawing.Point(9, 139)
      Me._grpPointerData.Name = "_grpPointerData"
      Me._grpPointerData.Size = New System.Drawing.Size(342, 48)
      Me._grpPointerData.TabIndex = 17
      Me._grpPointerData.TabStop = False
      Me._grpPointerData.Text = "Pointer Data"
      '
      '_btnCancel
      '
      Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me._btnCancel.Location = New System.Drawing.Point(184, 271)
      Me._btnCancel.Name = "_btnCancel"
      Me._btnCancel.Size = New System.Drawing.Size(75, 23)
      Me._btnCancel.TabIndex = 15
      Me._btnCancel.Text = "Cancel"
      Me._btnCancel.UseVisualStyleBackColor = True
      '
      '_btnOk
      '
      Me._btnOk.Location = New System.Drawing.Point(103, 271)
      Me._btnOk.Name = "_btnOk"
      Me._btnOk.Size = New System.Drawing.Size(75, 23)
      Me._btnOk.TabIndex = 14
      Me._btnOk.Text = "Ok"
      Me._btnOk.UseVisualStyleBackColor = True
      '
      '_grpFile
      '
      Me._grpFile.Controls.Add(Me._lblFirst)
      Me._grpFile.Controls.Add(Me._txtJPEG2000File)
      Me._grpFile.Controls.Add(Me._btnJPEGBrowse)
      Me._grpFile.Location = New System.Drawing.Point(9, 5)
      Me._grpFile.Name = "_grpFile"
      Me._grpFile.Size = New System.Drawing.Size(342, 72)
      Me._grpFile.TabIndex = 12
      Me._grpFile.TabStop = False
      Me._grpFile.Text = "File"
      '
      '_lblFirst
      '
      Me._lblFirst.AutoSize = True
      Me._lblFirst.Location = New System.Drawing.Point(10, 21)
      Me._lblFirst.Name = "_lblFirst"
      Me._lblFirst.Size = New System.Drawing.Size(78, 13)
      Me._lblFirst.TabIndex = 2
      Me._lblFirst.Text = "Select JPX File"
      '
      '_txtJPEG2000File
      '
      Me._txtJPEG2000File.Location = New System.Drawing.Point(13, 39)
      Me._txtJPEG2000File.Name = "_txtJPEG2000File"
      Me._txtJPEG2000File.Size = New System.Drawing.Size(237, 20)
      Me._txtJPEG2000File.TabIndex = 1
      '
      '_btnJPEGBrowse
      '
      Me._btnJPEGBrowse.Location = New System.Drawing.Point(256, 37)
      Me._btnJPEGBrowse.Name = "_btnJPEGBrowse"
      Me._btnJPEGBrowse.Size = New System.Drawing.Size(75, 23)
      Me._btnJPEGBrowse.TabIndex = 0
      Me._btnJPEGBrowse.Text = "Browse"
      Me._btnJPEGBrowse.UseVisualStyleBackColor = True
      '
      '_lblSignatureDataFile
      '
      Me._lblSignatureDataFile.AutoSize = True
      Me._lblSignatureDataFile.Location = New System.Drawing.Point(10, 21)
      Me._lblSignatureDataFile.Name = "_lblSignatureDataFile"
      Me._lblSignatureDataFile.Size = New System.Drawing.Size(97, 13)
      Me._lblSignatureDataFile.TabIndex = 2
      Me._lblSignatureDataFile.Text = "Signature Data File"
      '
      '_txtSignatureDataFile
      '
      Me._txtSignatureDataFile.Location = New System.Drawing.Point(13, 39)
      Me._txtSignatureDataFile.Name = "_txtSignatureDataFile"
      Me._txtSignatureDataFile.Size = New System.Drawing.Size(237, 20)
      Me._txtSignatureDataFile.TabIndex = 1
      '
      '_btnSignatureData
      '
      Me._btnSignatureData.Location = New System.Drawing.Point(256, 38)
      Me._btnSignatureData.Name = "_btnSignatureData"
      Me._btnSignatureData.Size = New System.Drawing.Size(75, 23)
      Me._btnSignatureData.TabIndex = 0
      Me._btnSignatureData.Text = "Browse"
      Me._btnSignatureData.UseVisualStyleBackColor = True
      '
      '_grpData
      '
      Me._grpData.Controls.Add(Me._lblSignatureDataFile)
      Me._grpData.Controls.Add(Me._txtSignatureDataFile)
      Me._grpData.Controls.Add(Me._btnSignatureData)
      Me._grpData.Location = New System.Drawing.Point(9, 193)
      Me._grpData.Name = "_grpData"
      Me._grpData.Size = New System.Drawing.Size(342, 72)
      Me._grpData.TabIndex = 13
      Me._grpData.TabStop = False
      Me._grpData.Text = "Data"
      '
      'AppendDigitalSignature
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.CancelButton = Me._btnCancel
      Me.ClientSize = New System.Drawing.Size(360, 299)
      Me.Controls.Add(Me._grpType)
      Me.Controls.Add(Me._grpPointerData)
      Me.Controls.Add(Me._btnCancel)
      Me.Controls.Add(Me._btnOk)
      Me.Controls.Add(Me._grpFile)
      Me.Controls.Add(Me._grpData)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "AppendDigitalSignature"
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
      Me.Text = "Append Digital Signature"
      CType(Me._nudLength, System.ComponentModel.ISupportInitialize).EndInit()
      Me._grpType.ResumeLayout(False)
      Me._grpType.PerformLayout()
      CType(Me._nudOffset, System.ComponentModel.ISupportInitialize).EndInit()
      Me._grpPointerData.ResumeLayout(False)
      Me._grpPointerData.PerformLayout()
      Me._grpFile.ResumeLayout(False)
      Me._grpFile.PerformLayout()
      Me._grpData.ResumeLayout(False)
      Me._grpData.PerformLayout()
      Me.ResumeLayout(False)

   End Sub
   Private WithEvents _cbSignatureType As System.Windows.Forms.ComboBox
   Private WithEvents _nudLength As System.Windows.Forms.NumericUpDown
   Private WithEvents _cbPointerType As System.Windows.Forms.ComboBox
   Private WithEvents _grpType As System.Windows.Forms.GroupBox
   Private WithEvents _lblPointerType As System.Windows.Forms.Label
   Private WithEvents _lblSignatureType As System.Windows.Forms.Label
   Private WithEvents _nudOffset As System.Windows.Forms.NumericUpDown
   Private WithEvents _lblLength As System.Windows.Forms.Label
   Private WithEvents _lblOffset As System.Windows.Forms.Label
   Private WithEvents _grpPointerData As System.Windows.Forms.GroupBox
   Private WithEvents _btnCancel As System.Windows.Forms.Button
   Private WithEvents _btnOk As System.Windows.Forms.Button
   Private WithEvents _grpFile As System.Windows.Forms.GroupBox
   Private WithEvents _lblFirst As System.Windows.Forms.Label
   Private WithEvents _txtJPEG2000File As System.Windows.Forms.TextBox
   Private WithEvents _btnJPEGBrowse As System.Windows.Forms.Button
   Private WithEvents _lblSignatureDataFile As System.Windows.Forms.Label
   Private WithEvents _txtSignatureDataFile As System.Windows.Forms.TextBox
   Private WithEvents _btnSignatureData As System.Windows.Forms.Button
   Private WithEvents _grpData As System.Windows.Forms.GroupBox
End Class
