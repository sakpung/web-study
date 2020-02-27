<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReadDigitalSignature
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReadDigitalSignature))
      Me._grpData = New System.Windows.Forms.GroupBox
      Me._lblDataFile = New System.Windows.Forms.Label
      Me._txtDataFile = New System.Windows.Forms.TextBox
      Me._btnDataFileBrowse = New System.Windows.Forms.Button
      Me._txtJPEG2000 = New System.Windows.Forms.TextBox
      Me._btnRead = New System.Windows.Forms.Button
      Me._lblSignatureType = New System.Windows.Forms.Label
      Me._txtSignatureType = New System.Windows.Forms.TextBox
      Me._lblJPEG2000 = New System.Windows.Forms.Label
      Me._grpFile = New System.Windows.Forms.GroupBox
      Me._btnJPEG2000Browse = New System.Windows.Forms.Button
      Me._txtLength = New System.Windows.Forms.TextBox
      Me._lblLength = New System.Windows.Forms.Label
      Me._grpBoxIndex = New System.Windows.Forms.GroupBox
      Me._nudBoxIndex = New System.Windows.Forms.NumericUpDown
      Me._lblPointerType = New System.Windows.Forms.Label
      Me._txtPointerType = New System.Windows.Forms.TextBox
      Me._lblOffset = New System.Windows.Forms.Label
      Me._txtOffset = New System.Windows.Forms.TextBox
      Me._grpType = New System.Windows.Forms.GroupBox
      Me._grpData.SuspendLayout()
      Me._grpFile.SuspendLayout()
      Me._grpBoxIndex.SuspendLayout()
      CType(Me._nudBoxIndex, System.ComponentModel.ISupportInitialize).BeginInit()
      Me._grpType.SuspendLayout()
      Me.SuspendLayout()
      '
      '_grpData
      '
      Me._grpData.Controls.Add(Me._lblDataFile)
      Me._grpData.Controls.Add(Me._txtDataFile)
      Me._grpData.Controls.Add(Me._btnDataFileBrowse)
      Me._grpData.Location = New System.Drawing.Point(5, 83)
      Me._grpData.Name = "_grpData"
      Me._grpData.Size = New System.Drawing.Size(330, 67)
      Me._grpData.TabIndex = 11
      Me._grpData.TabStop = False
      Me._grpData.Text = "Data"
      '
      '_lblDataFile
      '
      Me._lblDataFile.AutoSize = True
      Me._lblDataFile.Location = New System.Drawing.Point(6, 18)
      Me._lblDataFile.Name = "_lblDataFile"
      Me._lblDataFile.Size = New System.Drawing.Size(132, 13)
      Me._lblDataFile.TabIndex = 0
      Me._lblDataFile.Text = "Digital Signature Data File:"
      '
      '_txtDataFile
      '
      Me._txtDataFile.Location = New System.Drawing.Point(9, 36)
      Me._txtDataFile.Name = "_txtDataFile"
      Me._txtDataFile.Size = New System.Drawing.Size(232, 20)
      Me._txtDataFile.TabIndex = 1
      '
      '_btnDataFileBrowse
      '
      Me._btnDataFileBrowse.Location = New System.Drawing.Point(251, 34)
      Me._btnDataFileBrowse.Name = "_btnDataFileBrowse"
      Me._btnDataFileBrowse.Size = New System.Drawing.Size(75, 23)
      Me._btnDataFileBrowse.TabIndex = 2
      Me._btnDataFileBrowse.Text = "Browse"
      Me._btnDataFileBrowse.UseVisualStyleBackColor = True
      '
      '_txtJPEG2000
      '
      Me._txtJPEG2000.Location = New System.Drawing.Point(13, 39)
      Me._txtJPEG2000.Name = "_txtJPEG2000"
      Me._txtJPEG2000.Size = New System.Drawing.Size(232, 20)
      Me._txtJPEG2000.TabIndex = 1
      '
      '_btnRead
      '
      Me._btnRead.Location = New System.Drawing.Point(256, 278)
      Me._btnRead.Name = "_btnRead"
      Me._btnRead.Size = New System.Drawing.Size(75, 23)
      Me._btnRead.TabIndex = 14
      Me._btnRead.Text = "&Read"
      Me._btnRead.UseVisualStyleBackColor = True
      '
      '_lblSignatureType
      '
      Me._lblSignatureType.AutoSize = True
      Me._lblSignatureType.Location = New System.Drawing.Point(10, 22)
      Me._lblSignatureType.Name = "_lblSignatureType"
      Me._lblSignatureType.Size = New System.Drawing.Size(82, 13)
      Me._lblSignatureType.TabIndex = 1
      Me._lblSignatureType.Text = "Signature Type:"
      '
      '_txtSignatureType
      '
      Me._txtSignatureType.Location = New System.Drawing.Point(95, 19)
      Me._txtSignatureType.Name = "_txtSignatureType"
      Me._txtSignatureType.ReadOnly = True
      Me._txtSignatureType.Size = New System.Drawing.Size(71, 20)
      Me._txtSignatureType.TabIndex = 0
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
      Me._grpFile.Location = New System.Drawing.Point(5, 5)
      Me._grpFile.Name = "_grpFile"
      Me._grpFile.Size = New System.Drawing.Size(330, 72)
      Me._grpFile.TabIndex = 10
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
      '_txtLength
      '
      Me._txtLength.Location = New System.Drawing.Point(251, 58)
      Me._txtLength.Name = "_txtLength"
      Me._txtLength.ReadOnly = True
      Me._txtLength.Size = New System.Drawing.Size(71, 20)
      Me._txtLength.TabIndex = 6
      '
      '_lblLength
      '
      Me._lblLength.AutoSize = True
      Me._lblLength.Location = New System.Drawing.Point(180, 58)
      Me._lblLength.Name = "_lblLength"
      Me._lblLength.Size = New System.Drawing.Size(43, 13)
      Me._lblLength.TabIndex = 7
      Me._lblLength.Text = "Length:"
      '
      '_grpBoxIndex
      '
      Me._grpBoxIndex.Controls.Add(Me._nudBoxIndex)
      Me._grpBoxIndex.Location = New System.Drawing.Point(5, 248)
      Me._grpBoxIndex.Name = "_grpBoxIndex"
      Me._grpBoxIndex.Size = New System.Drawing.Size(241, 67)
      Me._grpBoxIndex.TabIndex = 13
      Me._grpBoxIndex.TabStop = False
      Me._grpBoxIndex.Text = "Box Index - 0 based"
      '
      '_nudBoxIndex
      '
      Me._nudBoxIndex.Location = New System.Drawing.Point(62, 30)
      Me._nudBoxIndex.Name = "_nudBoxIndex"
      Me._nudBoxIndex.Size = New System.Drawing.Size(117, 20)
      Me._nudBoxIndex.TabIndex = 0
      '
      '_lblPointerType
      '
      Me._lblPointerType.AutoSize = True
      Me._lblPointerType.Location = New System.Drawing.Point(180, 22)
      Me._lblPointerType.Name = "_lblPointerType"
      Me._lblPointerType.Size = New System.Drawing.Size(70, 13)
      Me._lblPointerType.TabIndex = 5
      Me._lblPointerType.Text = "Pointer Type:"
      '
      '_txtPointerType
      '
      Me._txtPointerType.Location = New System.Drawing.Point(251, 19)
      Me._txtPointerType.Name = "_txtPointerType"
      Me._txtPointerType.ReadOnly = True
      Me._txtPointerType.Size = New System.Drawing.Size(71, 20)
      Me._txtPointerType.TabIndex = 4
      '
      '_lblOffset
      '
      Me._lblOffset.AutoSize = True
      Me._lblOffset.Location = New System.Drawing.Point(10, 58)
      Me._lblOffset.Name = "_lblOffset"
      Me._lblOffset.Size = New System.Drawing.Size(38, 13)
      Me._lblOffset.TabIndex = 3
      Me._lblOffset.Text = "Offset:"
      '
      '_txtOffset
      '
      Me._txtOffset.Location = New System.Drawing.Point(95, 55)
      Me._txtOffset.Name = "_txtOffset"
      Me._txtOffset.ReadOnly = True
      Me._txtOffset.Size = New System.Drawing.Size(71, 20)
      Me._txtOffset.TabIndex = 2
      '
      '_grpType
      '
      Me._grpType.Controls.Add(Me._lblLength)
      Me._grpType.Controls.Add(Me._txtLength)
      Me._grpType.Controls.Add(Me._lblPointerType)
      Me._grpType.Controls.Add(Me._txtPointerType)
      Me._grpType.Controls.Add(Me._lblOffset)
      Me._grpType.Controls.Add(Me._txtOffset)
      Me._grpType.Controls.Add(Me._lblSignatureType)
      Me._grpType.Controls.Add(Me._txtSignatureType)
      Me._grpType.Location = New System.Drawing.Point(5, 154)
      Me._grpType.Name = "_grpType"
      Me._grpType.Size = New System.Drawing.Size(330, 88)
      Me._grpType.TabIndex = 12
      Me._grpType.TabStop = False
      Me._grpType.Text = "Type"
      '
      'ReadDigitalSignature
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(341, 320)
      Me.Controls.Add(Me._grpData)
      Me.Controls.Add(Me._btnRead)
      Me.Controls.Add(Me._grpFile)
      Me.Controls.Add(Me._grpBoxIndex)
      Me.Controls.Add(Me._grpType)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "ReadDigitalSignature"
      Me.ShowInTaskbar = False
      Me.Text = "Read Digital Signature Box"
      Me._grpData.ResumeLayout(False)
      Me._grpData.PerformLayout()
      Me._grpFile.ResumeLayout(False)
      Me._grpFile.PerformLayout()
      Me._grpBoxIndex.ResumeLayout(False)
      CType(Me._nudBoxIndex, System.ComponentModel.ISupportInitialize).EndInit()
      Me._grpType.ResumeLayout(False)
      Me._grpType.PerformLayout()
      Me.ResumeLayout(False)

   End Sub
   Private WithEvents _grpData As System.Windows.Forms.GroupBox
   Private WithEvents _lblDataFile As System.Windows.Forms.Label
   Private WithEvents _txtDataFile As System.Windows.Forms.TextBox
   Private WithEvents _btnDataFileBrowse As System.Windows.Forms.Button
   Private WithEvents _txtJPEG2000 As System.Windows.Forms.TextBox
   Private WithEvents _btnRead As System.Windows.Forms.Button
   Private WithEvents _lblSignatureType As System.Windows.Forms.Label
   Private WithEvents _txtSignatureType As System.Windows.Forms.TextBox
   Private WithEvents _lblJPEG2000 As System.Windows.Forms.Label
   Private WithEvents _grpFile As System.Windows.Forms.GroupBox
   Private WithEvents _btnJPEG2000Browse As System.Windows.Forms.Button
   Private WithEvents _txtLength As System.Windows.Forms.TextBox
   Private WithEvents _lblLength As System.Windows.Forms.Label
   Private WithEvents _grpBoxIndex As System.Windows.Forms.GroupBox
   Private WithEvents _nudBoxIndex As System.Windows.Forms.NumericUpDown
   Private WithEvents _lblPointerType As System.Windows.Forms.Label
   Private WithEvents _txtPointerType As System.Windows.Forms.TextBox
   Private WithEvents _lblOffset As System.Windows.Forms.Label
   Private WithEvents _txtOffset As System.Windows.Forms.TextBox
   Private WithEvents _grpType As System.Windows.Forms.GroupBox
End Class
