<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AppendGMLData
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AppendGMLData))
      Me._btnDelete = New System.Windows.Forms.Button
      Me._btnDown = New System.Windows.Forms.Button
      Me._btnUp = New System.Windows.Forms.Button
      Me._lblGMLInformationXMLDataFile = New System.Windows.Forms.Label
      Me._lstXmlDataFile = New System.Windows.Forms.ListBox
      Me._btnAdd = New System.Windows.Forms.Button
      Me._btnCancel = New System.Windows.Forms.Button
      Me._btnOk = New System.Windows.Forms.Button
      Me._lblGMLInformationLabel = New System.Windows.Forms.Label
      Me._lstLabel = New System.Windows.Forms.ListBox
      Me._grpGMLInformation = New System.Windows.Forms.GroupBox
      Me._lblJPEG2000 = New System.Windows.Forms.Label
      Me._lblXMLDataFile = New System.Windows.Forms.Label
      Me._txtJPEG2000FileName = New System.Windows.Forms.TextBox
      Me._txtXMLDataFile = New System.Windows.Forms.TextBox
      Me._grpFile = New System.Windows.Forms.GroupBox
      Me._btnJPEG2000Browse = New System.Windows.Forms.Button
      Me._lblLabel = New System.Windows.Forms.Label
      Me._txtLabel = New System.Windows.Forms.TextBox
      Me._btnXMLBrowse = New System.Windows.Forms.Button
      Me._grpGMLFile = New System.Windows.Forms.GroupBox
      Me._grpGMLInformation.SuspendLayout()
      Me._grpFile.SuspendLayout()
      Me._grpGMLFile.SuspendLayout()
      Me.SuspendLayout()
      '
      '_btnDelete
      '
      Me._btnDelete.Location = New System.Drawing.Point(316, 162)
      Me._btnDelete.Name = "_btnDelete"
      Me._btnDelete.Size = New System.Drawing.Size(68, 23)
      Me._btnDelete.TabIndex = 6
      Me._btnDelete.Text = "D&elete"
      Me._btnDelete.UseVisualStyleBackColor = True
      '
      '_btnDown
      '
      Me._btnDown.Image = CType(resources.GetObject("_btnDown.Image"), System.Drawing.Image)
      Me._btnDown.Location = New System.Drawing.Point(325, 67)
      Me._btnDown.Name = "_btnDown"
      Me._btnDown.Size = New System.Drawing.Size(49, 23)
      Me._btnDown.TabIndex = 5
      Me._btnDown.UseVisualStyleBackColor = True
      '
      '_btnUp
      '
      Me._btnUp.Image = CType(resources.GetObject("_btnUp.Image"), System.Drawing.Image)
      Me._btnUp.Location = New System.Drawing.Point(325, 38)
      Me._btnUp.Name = "_btnUp"
      Me._btnUp.Size = New System.Drawing.Size(49, 23)
      Me._btnUp.TabIndex = 4
      Me._btnUp.UseVisualStyleBackColor = True
      '
      '_lblGMLInformationXMLDataFile
      '
      Me._lblGMLInformationXMLDataFile.AutoSize = True
      Me._lblGMLInformationXMLDataFile.Location = New System.Drawing.Point(161, 20)
      Me._lblGMLInformationXMLDataFile.Name = "_lblGMLInformationXMLDataFile"
      Me._lblGMLInformationXMLDataFile.Size = New System.Drawing.Size(74, 13)
      Me._lblGMLInformationXMLDataFile.TabIndex = 2
      Me._lblGMLInformationXMLDataFile.Text = "XML Data File"
      '
      '_lstXmlDataFile
      '
      Me._lstXmlDataFile.FormattingEnabled = True
      Me._lstXmlDataFile.Location = New System.Drawing.Point(160, 38)
      Me._lstXmlDataFile.Name = "_lstXmlDataFile"
      Me._lstXmlDataFile.Size = New System.Drawing.Size(149, 147)
      Me._lstXmlDataFile.TabIndex = 3
      '
      '_btnAdd
      '
      Me._btnAdd.Location = New System.Drawing.Point(314, 194)
      Me._btnAdd.Name = "_btnAdd"
      Me._btnAdd.Size = New System.Drawing.Size(75, 23)
      Me._btnAdd.TabIndex = 11
      Me._btnAdd.Text = "&Add"
      Me._btnAdd.UseVisualStyleBackColor = True
      '
      '_btnCancel
      '
      Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me._btnCancel.Location = New System.Drawing.Point(210, 425)
      Me._btnCancel.Name = "_btnCancel"
      Me._btnCancel.Size = New System.Drawing.Size(75, 23)
      Me._btnCancel.TabIndex = 10
      Me._btnCancel.Text = "Cancel"
      Me._btnCancel.UseVisualStyleBackColor = True
      '
      '_btnOk
      '
      Me._btnOk.Location = New System.Drawing.Point(120, 425)
      Me._btnOk.Name = "_btnOk"
      Me._btnOk.Size = New System.Drawing.Size(75, 23)
      Me._btnOk.TabIndex = 9
      Me._btnOk.Text = "Ok"
      Me._btnOk.UseVisualStyleBackColor = True
      '
      '_lblGMLInformationLabel
      '
      Me._lblGMLInformationLabel.AutoSize = True
      Me._lblGMLInformationLabel.Location = New System.Drawing.Point(15, 20)
      Me._lblGMLInformationLabel.Name = "_lblGMLInformationLabel"
      Me._lblGMLInformationLabel.Size = New System.Drawing.Size(68, 13)
      Me._lblGMLInformationLabel.TabIndex = 0
      Me._lblGMLInformationLabel.Text = "Color Images"
      '
      '_lstLabel
      '
      Me._lstLabel.FormattingEnabled = True
      Me._lstLabel.Location = New System.Drawing.Point(11, 38)
      Me._lstLabel.Name = "_lstLabel"
      Me._lstLabel.Size = New System.Drawing.Size(149, 147)
      Me._lstLabel.TabIndex = 1
      '
      '_grpGMLInformation
      '
      Me._grpGMLInformation.Controls.Add(Me._btnDelete)
      Me._grpGMLInformation.Controls.Add(Me._btnDown)
      Me._grpGMLInformation.Controls.Add(Me._btnUp)
      Me._grpGMLInformation.Controls.Add(Me._lblGMLInformationXMLDataFile)
      Me._grpGMLInformation.Controls.Add(Me._lstXmlDataFile)
      Me._grpGMLInformation.Controls.Add(Me._lblGMLInformationLabel)
      Me._grpGMLInformation.Controls.Add(Me._lstLabel)
      Me._grpGMLInformation.Location = New System.Drawing.Point(5, 223)
      Me._grpGMLInformation.Name = "_grpGMLInformation"
      Me._grpGMLInformation.Size = New System.Drawing.Size(393, 196)
      Me._grpGMLInformation.TabIndex = 8
      Me._grpGMLInformation.TabStop = False
      Me._grpGMLInformation.Text = "GML Information"
      '
      '_lblJPEG2000
      '
      Me._lblJPEG2000.AutoSize = True
      Me._lblJPEG2000.Location = New System.Drawing.Point(11, 21)
      Me._lblJPEG2000.Name = "_lblJPEG2000"
      Me._lblJPEG2000.Size = New System.Drawing.Size(81, 13)
      Me._lblJPEG2000.TabIndex = 0
      Me._lblJPEG2000.Text = "Select JPX File:"
      '
      '_lblXMLDataFile
      '
      Me._lblXMLDataFile.AutoSize = True
      Me._lblXMLDataFile.Location = New System.Drawing.Point(11, 66)
      Me._lblXMLDataFile.Name = "_lblXMLDataFile"
      Me._lblXMLDataFile.Size = New System.Drawing.Size(77, 13)
      Me._lblXMLDataFile.TabIndex = 2
      Me._lblXMLDataFile.Text = "XML Data File:"
      '
      '_txtJPEG2000FileName
      '
      Me._txtJPEG2000FileName.Location = New System.Drawing.Point(14, 39)
      Me._txtJPEG2000FileName.Name = "_txtJPEG2000FileName"
      Me._txtJPEG2000FileName.Size = New System.Drawing.Size(289, 20)
      Me._txtJPEG2000FileName.TabIndex = 1
      '
      '_txtXMLDataFile
      '
      Me._txtXMLDataFile.Location = New System.Drawing.Point(14, 84)
      Me._txtXMLDataFile.Name = "_txtXMLDataFile"
      Me._txtXMLDataFile.Size = New System.Drawing.Size(289, 20)
      Me._txtXMLDataFile.TabIndex = 3
      '
      '_grpFile
      '
      Me._grpFile.Controls.Add(Me._lblJPEG2000)
      Me._grpFile.Controls.Add(Me._txtJPEG2000FileName)
      Me._grpFile.Controls.Add(Me._btnJPEG2000Browse)
      Me._grpFile.Location = New System.Drawing.Point(5, 4)
      Me._grpFile.Name = "_grpFile"
      Me._grpFile.Size = New System.Drawing.Size(393, 72)
      Me._grpFile.TabIndex = 6
      Me._grpFile.TabStop = False
      Me._grpFile.Text = "File"
      '
      '_btnJPEG2000Browse
      '
      Me._btnJPEG2000Browse.Location = New System.Drawing.Point(309, 37)
      Me._btnJPEG2000Browse.Name = "_btnJPEG2000Browse"
      Me._btnJPEG2000Browse.Size = New System.Drawing.Size(75, 23)
      Me._btnJPEG2000Browse.TabIndex = 2
      Me._btnJPEG2000Browse.Text = "Browse"
      Me._btnJPEG2000Browse.UseVisualStyleBackColor = True
      '
      '_lblLabel
      '
      Me._lblLabel.AutoSize = True
      Me._lblLabel.Location = New System.Drawing.Point(11, 16)
      Me._lblLabel.Name = "_lblLabel"
      Me._lblLabel.Size = New System.Drawing.Size(36, 13)
      Me._lblLabel.TabIndex = 0
      Me._lblLabel.Text = "Label:"
      '
      '_txtLabel
      '
      Me._txtLabel.Location = New System.Drawing.Point(14, 34)
      Me._txtLabel.Name = "_txtLabel"
      Me._txtLabel.Size = New System.Drawing.Size(370, 20)
      Me._txtLabel.TabIndex = 1
      '
      '_btnXMLBrowse
      '
      Me._btnXMLBrowse.Location = New System.Drawing.Point(309, 81)
      Me._btnXMLBrowse.Name = "_btnXMLBrowse"
      Me._btnXMLBrowse.Size = New System.Drawing.Size(75, 23)
      Me._btnXMLBrowse.TabIndex = 4
      Me._btnXMLBrowse.Text = "Browse"
      Me._btnXMLBrowse.UseVisualStyleBackColor = True
      '
      '_grpGMLFile
      '
      Me._grpGMLFile.Controls.Add(Me._lblXMLDataFile)
      Me._grpGMLFile.Controls.Add(Me._txtXMLDataFile)
      Me._grpGMLFile.Controls.Add(Me._lblLabel)
      Me._grpGMLFile.Controls.Add(Me._txtLabel)
      Me._grpGMLFile.Controls.Add(Me._btnXMLBrowse)
      Me._grpGMLFile.Location = New System.Drawing.Point(5, 82)
      Me._grpGMLFile.Name = "_grpGMLFile"
      Me._grpGMLFile.Size = New System.Drawing.Size(393, 125)
      Me._grpGMLFile.TabIndex = 7
      Me._grpGMLFile.TabStop = False
      Me._grpGMLFile.Text = "GML"
      '
      'AppendGMLData
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.CancelButton = Me._btnCancel
      Me.ClientSize = New System.Drawing.Size(403, 453)
      Me.Controls.Add(Me._btnAdd)
      Me.Controls.Add(Me._btnCancel)
      Me.Controls.Add(Me._btnOk)
      Me.Controls.Add(Me._grpGMLInformation)
      Me.Controls.Add(Me._grpFile)
      Me.Controls.Add(Me._grpGMLFile)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "AppendGMLData"
      Me.ShowInTaskbar = False
      Me.Text = "Append GML Data"
      Me._grpGMLInformation.ResumeLayout(False)
      Me._grpGMLInformation.PerformLayout()
      Me._grpFile.ResumeLayout(False)
      Me._grpFile.PerformLayout()
      Me._grpGMLFile.ResumeLayout(False)
      Me._grpGMLFile.PerformLayout()
      Me.ResumeLayout(False)

   End Sub
   Private WithEvents _btnDelete As System.Windows.Forms.Button
   Private WithEvents _btnDown As System.Windows.Forms.Button
   Private WithEvents _btnUp As System.Windows.Forms.Button
   Private WithEvents _lblGMLInformationXMLDataFile As System.Windows.Forms.Label
   Private WithEvents _lstXmlDataFile As System.Windows.Forms.ListBox
   Private WithEvents _btnAdd As System.Windows.Forms.Button
   Private WithEvents _btnCancel As System.Windows.Forms.Button
   Private WithEvents _btnOk As System.Windows.Forms.Button
   Private WithEvents _lblGMLInformationLabel As System.Windows.Forms.Label
   Private WithEvents _lstLabel As System.Windows.Forms.ListBox
   Private WithEvents _grpGMLInformation As System.Windows.Forms.GroupBox
   Private WithEvents _lblJPEG2000 As System.Windows.Forms.Label
   Private WithEvents _lblXMLDataFile As System.Windows.Forms.Label
   Private WithEvents _txtJPEG2000FileName As System.Windows.Forms.TextBox
   Private WithEvents _txtXMLDataFile As System.Windows.Forms.TextBox
   Private WithEvents _grpFile As System.Windows.Forms.GroupBox
   Private WithEvents _btnJPEG2000Browse As System.Windows.Forms.Button
   Private WithEvents _lblLabel As System.Windows.Forms.Label
   Private WithEvents _txtLabel As System.Windows.Forms.TextBox
   Private WithEvents _btnXMLBrowse As System.Windows.Forms.Button
   Private WithEvents _grpGMLFile As System.Windows.Forms.GroupBox
End Class
