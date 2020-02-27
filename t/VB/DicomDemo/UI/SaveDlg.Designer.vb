<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SaveDlg
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
      Me.checkBoxFullEndStatement = New System.Windows.Forms.CheckBox()
      Me.groupBoxMiscOptions = New System.Windows.Forms.GroupBox()
      Me.CheckBoxWriteKeyword = New System.Windows.Forms.CheckBox()
      Me.checkBoxTrimWhiteSpace = New System.Windows.Forms.CheckBox()
      Me.buttonSave = New System.Windows.Forms.Button()
      Me.radioButtonIncludeAllData = New System.Windows.Forms.RadioButton()
      Me.groupBoxBinaryDataOptions = New System.Windows.Forms.GroupBox()
      Me.labelInlineBinary = New System.Windows.Forms.Label()
      Me.radioButtonInlineBinary = New System.Windows.Forms.RadioButton()
      Me.radioButtonBulkDataUri = New System.Windows.Forms.RadioButton()
      Me.radioButtonBulkDataUuid = New System.Windows.Forms.RadioButton()
      Me.radioButtonIgnoreAllData = New System.Windows.Forms.RadioButton()
      Me.buttonOK = New System.Windows.Forms.Button()
      Me.groupBoxDataOptions = New System.Windows.Forms.GroupBox()
      Me.radioButtonIgnoreBinaryData = New System.Windows.Forms.RadioButton()
      Me.radioButtonIgnorePixelData = New System.Windows.Forms.RadioButton()
      Me.textBoxDescription = New System.Windows.Forms.TextBox()
      Me.buttonCancel = New System.Windows.Forms.Button()
      Me.checkBoxMinify = New System.Windows.Forms.CheckBox()
      Me.groupBoxMiscOptions.SuspendLayout()
      Me.groupBoxBinaryDataOptions.SuspendLayout()
      Me.groupBoxDataOptions.SuspendLayout()
      Me.SuspendLayout()
      '
      'checkBoxFullEndStatement
      '
      Me.checkBoxFullEndStatement.AutoSize = True
      Me.checkBoxFullEndStatement.Location = New System.Drawing.Point(7, 43)
      Me.checkBoxFullEndStatement.Name = "checkBoxFullEndStatement"
      Me.checkBoxFullEndStatement.Size = New System.Drawing.Size(143, 17)
      Me.checkBoxFullEndStatement.TabIndex = 16
      Me.checkBoxFullEndStatement.Text = "Write Full End Statement"
      Me.checkBoxFullEndStatement.UseVisualStyleBackColor = True
      '
      'groupBoxMiscOptions
      '
      Me.groupBoxMiscOptions.Controls.Add(Me.checkBoxMinify)
      Me.groupBoxMiscOptions.Controls.Add(Me.CheckBoxWriteKeyword)
      Me.groupBoxMiscOptions.Controls.Add(Me.checkBoxFullEndStatement)
      Me.groupBoxMiscOptions.Controls.Add(Me.checkBoxTrimWhiteSpace)
      Me.groupBoxMiscOptions.Location = New System.Drawing.Point(12, 187)
      Me.groupBoxMiscOptions.Name = "groupBoxMiscOptions"
      Me.groupBoxMiscOptions.Size = New System.Drawing.Size(330, 67)
      Me.groupBoxMiscOptions.TabIndex = 26
      Me.groupBoxMiscOptions.TabStop = False
      Me.groupBoxMiscOptions.Text = "Miscellaneous Options"
      '
      'CheckBoxWriteKeyword
      '
      Me.CheckBoxWriteKeyword.AutoSize = True
      Me.CheckBoxWriteKeyword.Location = New System.Drawing.Point(173, 19)
      Me.CheckBoxWriteKeyword.Name = "CheckBoxWriteKeyword"
      Me.CheckBoxWriteKeyword.Size = New System.Drawing.Size(95, 17)
      Me.CheckBoxWriteKeyword.TabIndex = 17
      Me.CheckBoxWriteKeyword.Text = "Write Keyword"
      Me.CheckBoxWriteKeyword.UseVisualStyleBackColor = True
      '
      'checkBoxTrimWhiteSpace
      '
      Me.checkBoxTrimWhiteSpace.AutoSize = True
      Me.checkBoxTrimWhiteSpace.Location = New System.Drawing.Point(7, 19)
      Me.checkBoxTrimWhiteSpace.Name = "checkBoxTrimWhiteSpace"
      Me.checkBoxTrimWhiteSpace.Size = New System.Drawing.Size(111, 17)
      Me.checkBoxTrimWhiteSpace.TabIndex = 15
      Me.checkBoxTrimWhiteSpace.Text = "Trim White Space"
      Me.checkBoxTrimWhiteSpace.UseVisualStyleBackColor = True
      '
      'buttonSave
      '
      Me.buttonSave.Location = New System.Drawing.Point(12, 266)
      Me.buttonSave.Name = "buttonSave"
      Me.buttonSave.Size = New System.Drawing.Size(78, 23)
      Me.buttonSave.TabIndex = 25
      Me.buttonSave.Text = "Save File..."
      Me.buttonSave.UseVisualStyleBackColor = True
      '
      'radioButtonIncludeAllData
      '
      Me.radioButtonIncludeAllData.AutoSize = True
      Me.radioButtonIncludeAllData.Location = New System.Drawing.Point(7, 19)
      Me.radioButtonIncludeAllData.Name = "radioButtonIncludeAllData"
      Me.radioButtonIncludeAllData.Size = New System.Drawing.Size(100, 17)
      Me.radioButtonIncludeAllData.TabIndex = 3
      Me.radioButtonIncludeAllData.TabStop = True
      Me.radioButtonIncludeAllData.Text = "Include All Data"
      Me.radioButtonIncludeAllData.UseVisualStyleBackColor = True
      '
      'groupBoxBinaryDataOptions
      '
      Me.groupBoxBinaryDataOptions.Controls.Add(Me.labelInlineBinary)
      Me.groupBoxBinaryDataOptions.Controls.Add(Me.radioButtonInlineBinary)
      Me.groupBoxBinaryDataOptions.Controls.Add(Me.radioButtonBulkDataUri)
      Me.groupBoxBinaryDataOptions.Controls.Add(Me.radioButtonBulkDataUuid)
      Me.groupBoxBinaryDataOptions.Location = New System.Drawing.Point(12, 56)
      Me.groupBoxBinaryDataOptions.Name = "groupBoxBinaryDataOptions"
      Me.groupBoxBinaryDataOptions.Size = New System.Drawing.Size(330, 123)
      Me.groupBoxBinaryDataOptions.TabIndex = 24
      Me.groupBoxBinaryDataOptions.TabStop = False
      Me.groupBoxBinaryDataOptions.Text = "Binary Data Options"
      '
      'labelInlineBinary
      '
      Me.labelInlineBinary.AutoSize = True
      Me.labelInlineBinary.ForeColor = System.Drawing.Color.Red
      Me.labelInlineBinary.Location = New System.Drawing.Point(94, 21)
      Me.labelInlineBinary.Name = "labelInlineBinary"
      Me.labelInlineBinary.Size = New System.Drawing.Size(203, 13)
      Me.labelInlineBinary.TabIndex = 14
      Me.labelInlineBinary.Text = "saves only 1st frame of multiframe dataset"
      '
      'radioButtonInlineBinary
      '
      Me.radioButtonInlineBinary.AutoSize = True
      Me.radioButtonInlineBinary.Location = New System.Drawing.Point(6, 19)
      Me.radioButtonInlineBinary.Name = "radioButtonInlineBinary"
      Me.radioButtonInlineBinary.Size = New System.Drawing.Size(82, 17)
      Me.radioButtonInlineBinary.TabIndex = 11
      Me.radioButtonInlineBinary.TabStop = True
      Me.radioButtonInlineBinary.Text = "Inline Binary"
      Me.radioButtonInlineBinary.UseVisualStyleBackColor = True
      '
      'radioButtonBulkDataUri
      '
      Me.radioButtonBulkDataUri.AutoSize = True
      Me.radioButtonBulkDataUri.Location = New System.Drawing.Point(6, 43)
      Me.radioButtonBulkDataUri.Name = "radioButtonBulkDataUri"
      Me.radioButtonBulkDataUri.Size = New System.Drawing.Size(82, 17)
      Me.radioButtonBulkDataUri.TabIndex = 12
      Me.radioButtonBulkDataUri.TabStop = True
      Me.radioButtonBulkDataUri.Text = "BulkDataUri"
      Me.radioButtonBulkDataUri.UseVisualStyleBackColor = True
      '
      'radioButtonBulkDataUuid
      '
      Me.radioButtonBulkDataUuid.AutoSize = True
      Me.radioButtonBulkDataUuid.Location = New System.Drawing.Point(6, 67)
      Me.radioButtonBulkDataUuid.Name = "radioButtonBulkDataUuid"
      Me.radioButtonBulkDataUuid.Size = New System.Drawing.Size(91, 17)
      Me.radioButtonBulkDataUuid.TabIndex = 13
      Me.radioButtonBulkDataUuid.TabStop = True
      Me.radioButtonBulkDataUuid.Text = "BulkDataUuid"
      Me.radioButtonBulkDataUuid.UseVisualStyleBackColor = True
      '
      'radioButtonIgnoreAllData
      '
      Me.radioButtonIgnoreAllData.AutoSize = True
      Me.radioButtonIgnoreAllData.Location = New System.Drawing.Point(7, 90)
      Me.radioButtonIgnoreAllData.Name = "radioButtonIgnoreAllData"
      Me.radioButtonIgnoreAllData.Size = New System.Drawing.Size(95, 17)
      Me.radioButtonIgnoreAllData.TabIndex = 2
      Me.radioButtonIgnoreAllData.TabStop = True
      Me.radioButtonIgnoreAllData.Text = "Ignore All Data"
      Me.radioButtonIgnoreAllData.UseVisualStyleBackColor = True
      '
      'buttonOK
      '
      Me.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK
      Me.buttonOK.Location = New System.Drawing.Point(348, 266)
      Me.buttonOK.Name = "buttonOK"
      Me.buttonOK.Size = New System.Drawing.Size(75, 23)
      Me.buttonOK.TabIndex = 21
      Me.buttonOK.Text = "&OK"
      '
      'groupBoxDataOptions
      '
      Me.groupBoxDataOptions.Controls.Add(Me.radioButtonIncludeAllData)
      Me.groupBoxDataOptions.Controls.Add(Me.radioButtonIgnoreAllData)
      Me.groupBoxDataOptions.Controls.Add(Me.radioButtonIgnoreBinaryData)
      Me.groupBoxDataOptions.Controls.Add(Me.radioButtonIgnorePixelData)
      Me.groupBoxDataOptions.Location = New System.Drawing.Point(348, 56)
      Me.groupBoxDataOptions.Name = "groupBoxDataOptions"
      Me.groupBoxDataOptions.Size = New System.Drawing.Size(155, 123)
      Me.groupBoxDataOptions.TabIndex = 23
      Me.groupBoxDataOptions.TabStop = False
      Me.groupBoxDataOptions.Text = "Data Options"
      '
      'radioButtonIgnoreBinaryData
      '
      Me.radioButtonIgnoreBinaryData.AutoSize = True
      Me.radioButtonIgnoreBinaryData.Location = New System.Drawing.Point(7, 66)
      Me.radioButtonIgnoreBinaryData.Name = "radioButtonIgnoreBinaryData"
      Me.radioButtonIgnoreBinaryData.Size = New System.Drawing.Size(113, 17)
      Me.radioButtonIgnoreBinaryData.TabIndex = 1
      Me.radioButtonIgnoreBinaryData.TabStop = True
      Me.radioButtonIgnoreBinaryData.Text = "Ignore Binary Data"
      Me.radioButtonIgnoreBinaryData.UseVisualStyleBackColor = True
      '
      'radioButtonIgnorePixelData
      '
      Me.radioButtonIgnorePixelData.AutoSize = True
      Me.radioButtonIgnorePixelData.Location = New System.Drawing.Point(7, 42)
      Me.radioButtonIgnorePixelData.Name = "radioButtonIgnorePixelData"
      Me.radioButtonIgnorePixelData.Size = New System.Drawing.Size(103, 17)
      Me.radioButtonIgnorePixelData.TabIndex = 0
      Me.radioButtonIgnorePixelData.TabStop = True
      Me.radioButtonIgnorePixelData.Text = "Ignore PixelData"
      Me.radioButtonIgnorePixelData.UseVisualStyleBackColor = True
      '
      'textBoxDescription
      '
      Me.textBoxDescription.BorderStyle = System.Windows.Forms.BorderStyle.None
      Me.textBoxDescription.Location = New System.Drawing.Point(11, 16)
      Me.textBoxDescription.Multiline = True
      Me.textBoxDescription.Name = "textBoxDescription"
      Me.textBoxDescription.ReadOnly = True
      Me.textBoxDescription.Size = New System.Drawing.Size(479, 35)
      Me.textBoxDescription.TabIndex = 22
      '
      'buttonCancel
      '
      Me.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.buttonCancel.Location = New System.Drawing.Point(428, 266)
      Me.buttonCancel.Name = "buttonCancel"
      Me.buttonCancel.Size = New System.Drawing.Size(75, 23)
      Me.buttonCancel.TabIndex = 20
      Me.buttonCancel.Text = "&Cancel"
      '
      'checkBoxMinify
      '
      Me.checkBoxMinify.AutoSize = True
      Me.checkBoxMinify.Location = New System.Drawing.Point(173, 43)
      Me.checkBoxMinify.Name = "checkBoxMinify"
      Me.checkBoxMinify.Size = New System.Drawing.Size(53, 17)
      Me.checkBoxMinify.TabIndex = 19
      Me.checkBoxMinify.Text = "Minify"
      Me.checkBoxMinify.UseVisualStyleBackColor = True
      '
      'SaveDlg
      '
      Me.AcceptButton = Me.buttonOK
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
      Me.CancelButton = Me.buttonCancel
      Me.ClientSize = New System.Drawing.Size(515, 305)
      Me.Controls.Add(Me.groupBoxMiscOptions)
      Me.Controls.Add(Me.buttonSave)
      Me.Controls.Add(Me.groupBoxBinaryDataOptions)
      Me.Controls.Add(Me.buttonOK)
      Me.Controls.Add(Me.groupBoxDataOptions)
      Me.Controls.Add(Me.textBoxDescription)
      Me.Controls.Add(Me.buttonCancel)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "SaveDlg"
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
      Me.Text = "Save"
      Me.groupBoxMiscOptions.ResumeLayout(False)
      Me.groupBoxMiscOptions.PerformLayout()
      Me.groupBoxBinaryDataOptions.ResumeLayout(False)
      Me.groupBoxBinaryDataOptions.PerformLayout()
      Me.groupBoxDataOptions.ResumeLayout(False)
      Me.groupBoxDataOptions.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Private WithEvents checkBoxFullEndStatement As System.Windows.Forms.CheckBox
   Private WithEvents groupBoxMiscOptions As System.Windows.Forms.GroupBox
   Private WithEvents checkBoxTrimWhiteSpace As System.Windows.Forms.CheckBox
   Private WithEvents buttonSave As System.Windows.Forms.Button
   Private WithEvents radioButtonIncludeAllData As System.Windows.Forms.RadioButton
   Private WithEvents groupBoxBinaryDataOptions As System.Windows.Forms.GroupBox
   Private WithEvents labelInlineBinary As System.Windows.Forms.Label
   Private WithEvents radioButtonInlineBinary As System.Windows.Forms.RadioButton
   Private WithEvents radioButtonBulkDataUri As System.Windows.Forms.RadioButton
   Private WithEvents radioButtonBulkDataUuid As System.Windows.Forms.RadioButton
   Private WithEvents radioButtonIgnoreAllData As System.Windows.Forms.RadioButton
   Private WithEvents buttonOK As System.Windows.Forms.Button
   Private WithEvents groupBoxDataOptions As System.Windows.Forms.GroupBox
   Private WithEvents radioButtonIgnoreBinaryData As System.Windows.Forms.RadioButton
   Private WithEvents radioButtonIgnorePixelData As System.Windows.Forms.RadioButton
   Private WithEvents textBoxDescription As System.Windows.Forms.TextBox
   Private WithEvents buttonCancel As System.Windows.Forms.Button
   Friend WithEvents CheckBoxWriteKeyword As System.Windows.Forms.CheckBox
   Private WithEvents checkBoxMinify As System.Windows.Forms.CheckBox
End Class
