Partial Class KeyPanel
   Private components As System.ComponentModel.IContainer = Nothing

   Protected Overrides Sub Dispose(ByVal disposing As Boolean)
      If disposing AndAlso (components IsNot Nothing) Then
         components.Dispose()
      End If

      MyBase.Dispose(disposing)
   End Sub

   Private Sub InitializeComponent()
      Me.pnlThumbnail = New System.Windows.Forms.Panel()
      Me.grpSelectSource = New System.Windows.Forms.GroupBox()
      Me.lblPassingGrade = New System.Windows.Forms.Label()
      Me.txtScanPath = New System.Windows.Forms.TextBox()
      Me.nudPassingGrade = New System.Windows.Forms.NumericUpDown()
      Me.rdBtnFile = New System.Windows.Forms.RadioButton()
      Me.txtFilePath = New System.Windows.Forms.TextBox()
      Me.btnBrowse = New System.Windows.Forms.Button()
      Me.btnScan = New System.Windows.Forms.Button()
      Me.rdbtnTwain = New System.Windows.Forms.RadioButton()
      Me.chkUseKey = New System.Windows.Forms.CheckBox()
      Me.label2 = New System.Windows.Forms.Label()
      Me.grpSelectSource.SuspendLayout()
      CType(Me.nudPassingGrade, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      Me.pnlThumbnail.BackColor = System.Drawing.SystemColors.ControlDark
      Me.pnlThumbnail.Location = New System.Drawing.Point(445, 0)
      Me.pnlThumbnail.Name = "pnlThumbnail"
      Me.pnlThumbnail.Size = New System.Drawing.Size(169, 195)
      Me.pnlThumbnail.TabIndex = 24
      Me.grpSelectSource.Controls.Add(Me.lblPassingGrade)
      Me.grpSelectSource.Controls.Add(Me.txtScanPath)
      Me.grpSelectSource.Controls.Add(Me.nudPassingGrade)
      Me.grpSelectSource.Controls.Add(Me.chkUseKey)
      Me.grpSelectSource.Controls.Add(Me.rdBtnFile)
      Me.grpSelectSource.Controls.Add(Me.txtFilePath)
      Me.grpSelectSource.Controls.Add(Me.btnBrowse)
      Me.grpSelectSource.Controls.Add(Me.btnScan)
      Me.grpSelectSource.Controls.Add(Me.rdbtnTwain)
      Me.grpSelectSource.Location = New System.Drawing.Point(4, 39)
      Me.grpSelectSource.Name = "grpSelectSource"
      Me.grpSelectSource.Size = New System.Drawing.Size(435, 156)
      Me.grpSelectSource.TabIndex = 25
      Me.grpSelectSource.TabStop = False
      Me.grpSelectSource.Text = "Choose Answer Key"
      Me.lblPassingGrade.AutoSize = True
      Me.lblPassingGrade.Location = New System.Drawing.Point(7, 26)
      Me.lblPassingGrade.Name = "lblPassingGrade"
      Me.lblPassingGrade.Size = New System.Drawing.Size(79, 13)
      Me.lblPassingGrade.TabIndex = 24
      Me.lblPassingGrade.Text = "Passing Grade:"
      Me.txtScanPath.Location = New System.Drawing.Point(109, 128)
      Me.txtScanPath.Name = "txtScanPath"
      Me.txtScanPath.Size = New System.Drawing.Size(229, 20)
      Me.txtScanPath.TabIndex = 23
      Me.nudPassingGrade.Location = New System.Drawing.Point(92, 24)
      Me.nudPassingGrade.Name = "nudPassingGrade"
      Me.nudPassingGrade.Size = New System.Drawing.Size(47, 20)
      Me.nudPassingGrade.TabIndex = 4
      Me.nudPassingGrade.Value = New Decimal(New Integer() {70, 0, 0, 0})
      Me.rdBtnFile.AutoSize = True
      Me.rdBtnFile.Location = New System.Drawing.Point(6, 54)
      Me.rdBtnFile.Name = "rdBtnFile"
      Me.rdBtnFile.Size = New System.Drawing.Size(133, 17)
      Me.rdBtnFile.TabIndex = 0
      Me.rdBtnFile.TabStop = True
      Me.rdBtnFile.Text = "Load From File on Disk"
      Me.rdBtnFile.UseVisualStyleBackColor = True
      AddHandler Me.rdBtnFile.CheckedChanged, AddressOf Me.rdBtnToggled
      Me.txtFilePath.Location = New System.Drawing.Point(28, 77)
      Me.txtFilePath.Name = "txtFilePath"
      Me.txtFilePath.Size = New System.Drawing.Size(310, 20)
      Me.txtFilePath.TabIndex = 4
      Me.btnBrowse.Location = New System.Drawing.Point(344, 77)
      Me.btnBrowse.Name = "btnBrowse"
      Me.btnBrowse.Size = New System.Drawing.Size(75, 23)
      Me.btnBrowse.TabIndex = 5
      Me.btnBrowse.Text = "Browse"
      Me.btnBrowse.UseVisualStyleBackColor = True
      AddHandler Me.btnBrowse.Click, AddressOf Me.btnImageFileBrowse_Click
      Me.btnScan.Location = New System.Drawing.Point(28, 126)
      Me.btnScan.Name = "btnScan"
      Me.btnScan.Size = New System.Drawing.Size(75, 23)
      Me.btnScan.TabIndex = 7
      Me.btnScan.Text = "Scan"
      Me.btnScan.UseVisualStyleBackColor = True
      AddHandler Me.btnScan.Click, AddressOf Me.btnScan_Click
      Me.rdbtnTwain.AutoSize = True
      Me.rdbtnTwain.Location = New System.Drawing.Point(6, 103)
      Me.rdbtnTwain.Name = "rdbtnTwain"
      Me.rdbtnTwain.Size = New System.Drawing.Size(111, 17)
      Me.rdbtnTwain.TabIndex = 18
      Me.rdbtnTwain.TabStop = True
      Me.rdbtnTwain.Text = "Get From Scanner"
      Me.rdbtnTwain.UseVisualStyleBackColor = True
      AddHandler Me.rdbtnTwain.CheckedChanged, AddressOf Me.rdBtnToggled
      Me.chkUseKey.AutoSize = True
      Me.chkUseKey.Checked = True
      Me.chkUseKey.CheckState = System.Windows.Forms.CheckState.Checked
      Me.chkUseKey.Location = New System.Drawing.Point(6, 0)
      Me.chkUseKey.Name = "chkUseKey"
      Me.chkUseKey.Size = New System.Drawing.Size(104, 17)
      Me.chkUseKey.TabIndex = 22
      Me.chkUseKey.Text = "Use Answer Key"
      Me.chkUseKey.UseVisualStyleBackColor = True
      AddHandler Me.chkUseKey.CheckedChanged, AddressOf Me.chkUseKey_CheckedChanged
      Me.label2.Location = New System.Drawing.Point(7, 8)
      Me.label2.Name = "label2"
      Me.label2.Size = New System.Drawing.Size(432, 28)
      Me.label2.TabIndex = 26
      Me.label2.Text = "Answer keys are generally used when processing exams or worksheets, but usually a" & "ren't necessary when processing surveys and questionnaires."
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.Controls.Add(Me.label2)
      Me.Controls.Add(Me.grpSelectSource)
      Me.Controls.Add(Me.pnlThumbnail)
      Me.Name = "KeyPanel"
      Me.Size = New System.Drawing.Size(617, 198)
      Me.grpSelectSource.ResumeLayout(False)
      Me.grpSelectSource.PerformLayout()
      CType(Me.nudPassingGrade, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
   End Sub

   Private pnlThumbnail As System.Windows.Forms.Panel
   Private grpSelectSource As System.Windows.Forms.GroupBox
   Private chkUseKey As System.Windows.Forms.CheckBox
   Private rdBtnFile As System.Windows.Forms.RadioButton
   Private txtFilePath As System.Windows.Forms.TextBox
   Private btnBrowse As System.Windows.Forms.Button
   Private btnScan As System.Windows.Forms.Button
   Private rdbtnTwain As System.Windows.Forms.RadioButton
   Private nudPassingGrade As System.Windows.Forms.NumericUpDown
   Private txtScanPath As System.Windows.Forms.TextBox
   Private lblPassingGrade As System.Windows.Forms.Label
   Private label2 As System.Windows.Forms.Label
End Class
