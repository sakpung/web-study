Imports Microsoft.VisualBasic
Imports System

Partial Public Class AcquireOptionsForm
   ''' <summary>
   ''' Required designer variable.
   ''' </summary>
   Private components As System.ComponentModel.IContainer = Nothing

   ''' <summary>
   ''' Clean up any resources being used.
   ''' </summary>
   ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
   Protected Overrides Sub Dispose(ByVal disposing As Boolean)
      If disposing AndAlso (Not components Is Nothing) Then
         components.Dispose()
      End If
      MyBase.Dispose(disposing)
   End Sub

#Region "Windows Form Designer generated code"

   ''' <summary>
   ''' Required method for Designer support - do not modify
   ''' the contents of this method with the code editor.
   ''' </summary>
   Private Sub InitializeComponent()
      Me._gbTransferMode = New System.Windows.Forms.GroupBox
      Me._rdMemoryMode = New System.Windows.Forms.RadioButton
      Me._rdFileMode = New System.Windows.Forms.RadioButton
      Me._gbFileModeOptions = New System.Windows.Forms.GroupBox
      Me._cbAppendToFile = New System.Windows.Forms.CheckBox
      Me._cbOverwriteExisting = New System.Windows.Forms.CheckBox
      Me._cbSaveToOneFile = New System.Windows.Forms.CheckBox
      Me._btnBrowse = New System.Windows.Forms.Button
      Me._tbFileName = New System.Windows.Forms.TextBox
      Me._lblFileName = New System.Windows.Forms.Label
      Me._gbTransferBufferOptions = New System.Windows.Forms.GroupBox
      Me._cbEnableDoubleBuffer = New System.Windows.Forms.CheckBox
      Me._lblMemoryBufferSize = New System.Windows.Forms.Label
      Me._btnCancel = New System.Windows.Forms.Button
      Me._btnOk = New System.Windows.Forms.Button
      Me._numMemoryBufferSize = New System.Windows.Forms.NumericUpDown
      Me._gbTransferMode.SuspendLayout()
      Me._gbFileModeOptions.SuspendLayout()
      Me._gbTransferBufferOptions.SuspendLayout()
      CType(Me._numMemoryBufferSize, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      '_gbTransferMode
      '
      Me._gbTransferMode.Controls.Add(Me._rdMemoryMode)
      Me._gbTransferMode.Controls.Add(Me._rdFileMode)
      Me._gbTransferMode.Location = New System.Drawing.Point(12, 12)
      Me._gbTransferMode.Name = "_gbTransferMode"
      Me._gbTransferMode.Size = New System.Drawing.Size(252, 89)
      Me._gbTransferMode.TabIndex = 0
      Me._gbTransferMode.TabStop = False
      Me._gbTransferMode.Text = "Transfer Mode"
      '
      '_rdMemoryMode
      '
      Me._rdMemoryMode.AutoSize = True
      Me._rdMemoryMode.Location = New System.Drawing.Point(9, 38)
      Me._rdMemoryMode.Name = "_rdMemoryMode"
      Me._rdMemoryMode.Size = New System.Drawing.Size(92, 17)
      Me._rdMemoryMode.TabIndex = 0
      Me._rdMemoryMode.TabStop = True
      Me._rdMemoryMode.Text = "Memory Mode"
      Me._rdMemoryMode.UseVisualStyleBackColor = True
      '
      '_rdFileMode
      '
      Me._rdFileMode.AutoSize = True
      Me._rdFileMode.Location = New System.Drawing.Point(139, 38)
      Me._rdFileMode.Name = "_rdFileMode"
      Me._rdFileMode.Size = New System.Drawing.Size(71, 17)
      Me._rdFileMode.TabIndex = 1
      Me._rdFileMode.TabStop = True
      Me._rdFileMode.Text = "File Mode"
      Me._rdFileMode.UseVisualStyleBackColor = True
      '
      '_gbFileModeOptions
      '
      Me._gbFileModeOptions.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me._gbFileModeOptions.Controls.Add(Me._cbAppendToFile)
      Me._gbFileModeOptions.Controls.Add(Me._cbOverwriteExisting)
      Me._gbFileModeOptions.Controls.Add(Me._cbSaveToOneFile)
      Me._gbFileModeOptions.Controls.Add(Me._btnBrowse)
      Me._gbFileModeOptions.Controls.Add(Me._tbFileName)
      Me._gbFileModeOptions.Controls.Add(Me._lblFileName)
      Me._gbFileModeOptions.Location = New System.Drawing.Point(12, 107)
      Me._gbFileModeOptions.Name = "_gbFileModeOptions"
      Me._gbFileModeOptions.Size = New System.Drawing.Size(252, 151)
      Me._gbFileModeOptions.TabIndex = 1
      Me._gbFileModeOptions.TabStop = False
      Me._gbFileModeOptions.Text = "File Mode Options"
      '
      '_cbAppendToFile
      '
      Me._cbAppendToFile.AutoSize = True
      Me._cbAppendToFile.Location = New System.Drawing.Point(9, 108)
      Me._cbAppendToFile.Name = "_cbAppendToFile"
      Me._cbAppendToFile.Size = New System.Drawing.Size(98, 17)
      Me._cbAppendToFile.TabIndex = 6
      Me._cbAppendToFile.Text = "Append To File"
      Me._cbAppendToFile.UseVisualStyleBackColor = True
      '
      '_cbOverwriteExisting
      '
      Me._cbOverwriteExisting.AutoSize = True
      Me._cbOverwriteExisting.Location = New System.Drawing.Point(9, 85)
      Me._cbOverwriteExisting.Name = "_cbOverwriteExisting"
      Me._cbOverwriteExisting.Size = New System.Drawing.Size(110, 17)
      Me._cbOverwriteExisting.TabIndex = 5
      Me._cbOverwriteExisting.Text = "Overwrite Existing"
      Me._cbOverwriteExisting.UseVisualStyleBackColor = True
      '
      '_cbSaveToOneFile
      '
      Me._cbSaveToOneFile.AutoSize = True
      Me._cbSaveToOneFile.Location = New System.Drawing.Point(9, 62)
      Me._cbSaveToOneFile.Name = "_cbSaveToOneFile"
      Me._cbSaveToOneFile.Size = New System.Drawing.Size(109, 17)
      Me._cbSaveToOneFile.TabIndex = 4
      Me._cbSaveToOneFile.Text = "Save To One File"
      Me._cbSaveToOneFile.UseVisualStyleBackColor = True
      '
      '_btnBrowse
      '
      Me._btnBrowse.Location = New System.Drawing.Point(217, 23)
      Me._btnBrowse.Name = "_btnBrowse"
      Me._btnBrowse.Size = New System.Drawing.Size(29, 23)
      Me._btnBrowse.TabIndex = 3
      Me._btnBrowse.Text = "&..."
      Me._btnBrowse.UseVisualStyleBackColor = True
      '
      '_tbFileName
      '
      Me._tbFileName.Location = New System.Drawing.Point(66, 25)
      Me._tbFileName.Name = "_tbFileName"
      Me._tbFileName.ReadOnly = True
      Me._tbFileName.Size = New System.Drawing.Size(144, 20)
      Me._tbFileName.TabIndex = 2
      '
      '_lblFileName
      '
      Me._lblFileName.AutoSize = True
      Me._lblFileName.Location = New System.Drawing.Point(6, 28)
      Me._lblFileName.Name = "_lblFileName"
      Me._lblFileName.Size = New System.Drawing.Size(54, 13)
      Me._lblFileName.TabIndex = 0
      Me._lblFileName.Text = "File Name"
      '
      '_gbTransferBufferOptions
      '
      Me._gbTransferBufferOptions.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me._gbTransferBufferOptions.Controls.Add(Me._numMemoryBufferSize)
      Me._gbTransferBufferOptions.Controls.Add(Me._cbEnableDoubleBuffer)
      Me._gbTransferBufferOptions.Controls.Add(Me._lblMemoryBufferSize)
      Me._gbTransferBufferOptions.Location = New System.Drawing.Point(270, 12)
      Me._gbTransferBufferOptions.Name = "_gbTransferBufferOptions"
      Me._gbTransferBufferOptions.Size = New System.Drawing.Size(229, 89)
      Me._gbTransferBufferOptions.TabIndex = 1
      Me._gbTransferBufferOptions.TabStop = False
      Me._gbTransferBufferOptions.Text = "Transfer Buffer Options"
      '
      '_cbEnableDoubleBuffer
      '
      Me._cbEnableDoubleBuffer.AutoSize = True
      Me._cbEnableDoubleBuffer.Location = New System.Drawing.Point(9, 55)
      Me._cbEnableDoubleBuffer.Name = "_cbEnableDoubleBuffer"
      Me._cbEnableDoubleBuffer.Size = New System.Drawing.Size(127, 17)
      Me._cbEnableDoubleBuffer.TabIndex = 8
      Me._cbEnableDoubleBuffer.Text = "Enable Double Buffer"
      Me._cbEnableDoubleBuffer.UseVisualStyleBackColor = True
      '
      '_lblMemoryBufferSize
      '
      Me._lblMemoryBufferSize.AutoSize = True
      Me._lblMemoryBufferSize.Location = New System.Drawing.Point(6, 26)
      Me._lblMemoryBufferSize.Name = "_lblMemoryBufferSize"
      Me._lblMemoryBufferSize.Size = New System.Drawing.Size(133, 13)
      Me._lblMemoryBufferSize.TabIndex = 0
      Me._lblMemoryBufferSize.Text = "Memory Buffer Size (Bytes)"
      '
      '_btnCancel
      '
      Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me._btnCancel.Location = New System.Drawing.Point(421, 234)
      Me._btnCancel.Name = "_btnCancel"
      Me._btnCancel.Size = New System.Drawing.Size(80, 24)
      Me._btnCancel.TabIndex = 10
      Me._btnCancel.Text = "&Cancel"
      Me._btnCancel.UseVisualStyleBackColor = True
      '
      '_btnOk
      '
      Me._btnOk.Location = New System.Drawing.Point(335, 234)
      Me._btnOk.Name = "_btnOk"
      Me._btnOk.Size = New System.Drawing.Size(80, 24)
      Me._btnOk.TabIndex = 9
      Me._btnOk.Text = "&OK"
      Me._btnOk.UseVisualStyleBackColor = True
      '
      '_numMemoryBufferSize
      '
      Me._numMemoryBufferSize.Location = New System.Drawing.Point(145, 24)
      Me._numMemoryBufferSize.Maximum = New Decimal(New Integer() {65535000, 0, 0, 0})
      Me._numMemoryBufferSize.Name = "_numMemoryBufferSize"
      Me._numMemoryBufferSize.Size = New System.Drawing.Size(78, 20)
      Me._numMemoryBufferSize.TabIndex = 11
      '
      'AcquireOptionsForm
      '
      Me.AcceptButton = Me._btnOk
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.CancelButton = Me._btnCancel
      Me.ClientSize = New System.Drawing.Size(511, 270)
      Me.Controls.Add(Me._btnOk)
      Me.Controls.Add(Me._btnCancel)
      Me.Controls.Add(Me._gbTransferBufferOptions)
      Me.Controls.Add(Me._gbFileModeOptions)
      Me.Controls.Add(Me._gbTransferMode)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "AcquireOptionsForm"
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
      Me.Text = "WIA Acquire Options"
      Me._gbTransferMode.ResumeLayout(False)
      Me._gbTransferMode.PerformLayout()
      Me._gbFileModeOptions.ResumeLayout(False)
      Me._gbFileModeOptions.PerformLayout()
      Me._gbTransferBufferOptions.ResumeLayout(False)
      Me._gbTransferBufferOptions.PerformLayout()
      CType(Me._numMemoryBufferSize, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

   End Sub

#End Region

   Private _gbTransferMode As System.Windows.Forms.GroupBox
   Private _gbFileModeOptions As System.Windows.Forms.GroupBox
   Private _gbTransferBufferOptions As System.Windows.Forms.GroupBox
   Private _btnCancel As System.Windows.Forms.Button
   Private WithEvents _btnOk As System.Windows.Forms.Button
   Private WithEvents _rdMemoryMode As System.Windows.Forms.RadioButton
   Private WithEvents _rdFileMode As System.Windows.Forms.RadioButton
   Private _lblFileName As System.Windows.Forms.Label
   Private WithEvents _btnBrowse As System.Windows.Forms.Button
   Private WithEvents _tbFileName As System.Windows.Forms.TextBox
   Private WithEvents _cbAppendToFile As System.Windows.Forms.CheckBox
   Private WithEvents _cbOverwriteExisting As System.Windows.Forms.CheckBox
   Private _cbSaveToOneFile As System.Windows.Forms.CheckBox
   Private _lblMemoryBufferSize As System.Windows.Forms.Label
   Private _cbEnableDoubleBuffer As System.Windows.Forms.CheckBox
   Private WithEvents _numMemoryBufferSize As System.Windows.Forms.NumericUpDown
End Class
