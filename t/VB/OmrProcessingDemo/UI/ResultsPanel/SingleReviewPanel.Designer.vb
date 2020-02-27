Partial Class SingleReviewPanel
   Private components As System.ComponentModel.IContainer = Nothing

   Protected Overrides Sub Dispose(ByVal disposing As Boolean)
      If disposing AndAlso (components IsNot Nothing) Then
         components.Dispose()
      End If

      MyBase.Dispose(disposing)
   End Sub

   Private Sub InitializeComponent()
      Me.spltMain = New System.Windows.Forms.SplitContainer()
      Me.grpInfo = New System.Windows.Forms.GroupBox()
      Me.cbFiles = New System.Windows.Forms.ComboBox()
      Me.btnNextWorksheet = New System.Windows.Forms.Button()
      Me.btnPreviousWorksheet = New System.Windows.Forms.Button()
      Me.lblFilename = New System.Windows.Forms.Label()
      Me.spltInfo = New System.Windows.Forms.SplitContainer()
      Me.grpAnswerCrop = New System.Windows.Forms.GroupBox()
      Me.pnlAnswerCrop = New System.Windows.Forms.Panel()
      Me.lblAnswerKey = New System.Windows.Forms.Label()
      Me.cbZones = New System.Windows.Forms.ComboBox()
      Me.chkSkipNonOMR = New System.Windows.Forms.CheckBox()
      Me.btnNextZone = New System.Windows.Forms.Button()
      Me.btnPreviousZone = New System.Windows.Forms.Button()
      Me.lblCurrentPage = New System.Windows.Forms.Label()
      Me.btnNextPage = New System.Windows.Forms.Button()
      Me.btnPreviousPage = New System.Windows.Forms.Button()
      Me.grpReview = New System.Windows.Forms.GroupBox()
      Me.btnChooseFilters = New System.Windows.Forms.Button()
      Me.rdbtnSpecific = New System.Windows.Forms.RadioButton()
      Me.rdbtnAllFields = New System.Windows.Forms.RadioButton()
      Me.btnCancel = New System.Windows.Forms.Button()
      Me.pnlFullSheet = New System.Windows.Forms.Panel()
      Me.lblNoFieldSelected = New System.Windows.Forms.Label()
      CType(Me.spltMain, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.spltMain.Panel1.SuspendLayout()
      Me.spltMain.Panel2.SuspendLayout()
      Me.spltMain.SuspendLayout()
      Me.grpInfo.SuspendLayout()
      CType(Me.spltInfo, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.spltInfo.Panel1.SuspendLayout()
      Me.spltInfo.Panel2.SuspendLayout()
      Me.spltInfo.SuspendLayout()
      Me.grpAnswerCrop.SuspendLayout()
      Me.pnlAnswerCrop.SuspendLayout()
      Me.grpReview.SuspendLayout()
      Me.SuspendLayout()
      Me.spltMain.Dock = System.Windows.Forms.DockStyle.Fill
      Me.spltMain.IsSplitterFixed = True
      Me.spltMain.Location = New System.Drawing.Point(0, 0)
      Me.spltMain.Name = "spltMain"
      Me.spltMain.Panel1.BackColor = System.Drawing.SystemColors.Control
      Me.spltMain.Panel1.Controls.Add(Me.grpInfo)
      Me.spltMain.Panel1.Controls.Add(Me.spltInfo)
      Me.spltMain.Panel2.Controls.Add(Me.lblCurrentPage)
      Me.spltMain.Panel2.Controls.Add(Me.btnNextPage)
      Me.spltMain.Panel2.Controls.Add(Me.btnPreviousPage)
      Me.spltMain.Panel2.Controls.Add(Me.grpReview)
      Me.spltMain.Panel2.Controls.Add(Me.btnCancel)
      Me.spltMain.Panel2.Controls.Add(Me.pnlFullSheet)
      Me.spltMain.Size = New System.Drawing.Size(807, 751)
      Me.spltMain.SplitterDistance = 308
      Me.spltMain.TabIndex = 1
      Me.grpInfo.Controls.Add(Me.cbFiles)
      Me.grpInfo.Controls.Add(Me.btnNextWorksheet)
      Me.grpInfo.Controls.Add(Me.btnPreviousWorksheet)
      Me.grpInfo.Controls.Add(Me.lblFilename)
      Me.grpInfo.Location = New System.Drawing.Point(4, 3)
      Me.grpInfo.Name = "grpInfo"
      Me.grpInfo.Size = New System.Drawing.Size(299, 82)
      Me.grpInfo.TabIndex = 1
      Me.grpInfo.TabStop = False
      Me.grpInfo.Text = "Worksheet"
      Me.cbFiles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cbFiles.FormattingEnabled = True
      Me.cbFiles.Location = New System.Drawing.Point(69, 19)
      Me.cbFiles.Name = "cbFiles"
      Me.cbFiles.Size = New System.Drawing.Size(224, 21)
      Me.cbFiles.TabIndex = 5
      AddHandler Me.cbFiles.SelectedIndexChanged, AddressOf Me.cbFiles_SelectedIndexChanged
      Me.btnNextWorksheet.Location = New System.Drawing.Point(186, 46)
      Me.btnNextWorksheet.Name = "btnNextWorksheet"
      Me.btnNextWorksheet.Size = New System.Drawing.Size(106, 23)
      Me.btnNextWorksheet.TabIndex = 3
      Me.btnNextWorksheet.Text = "N&ext Worksheet"
      Me.btnNextWorksheet.UseVisualStyleBackColor = True
      AddHandler Me.btnNextWorksheet.Click, AddressOf Me.btnNextWorksheet_Click
      Me.btnPreviousWorksheet.Location = New System.Drawing.Point(10, 46)
      Me.btnPreviousWorksheet.Name = "btnPreviousWorksheet"
      Me.btnPreviousWorksheet.Size = New System.Drawing.Size(112, 23)
      Me.btnPreviousWorksheet.TabIndex = 2
      Me.btnPreviousWorksheet.Text = "P&revious Worksheet"
      Me.btnPreviousWorksheet.UseVisualStyleBackColor = True
      AddHandler Me.btnPreviousWorksheet.Click, AddressOf Me.btnPreviousWorksheet_Click
      Me.lblFilename.AutoSize = True
      Me.lblFilename.Location = New System.Drawing.Point(9, 22)
      Me.lblFilename.Name = "lblFilename"
      Me.lblFilename.Size = New System.Drawing.Size(38, 13)
      Me.lblFilename.TabIndex = 0
      Me.lblFilename.Text = "Name:"
      Me.spltInfo.Dock = System.Windows.Forms.DockStyle.Fill
      Me.spltInfo.IsSplitterFixed = True
      Me.spltInfo.Location = New System.Drawing.Point(0, 0)
      Me.spltInfo.Name = "spltInfo"
      Me.spltInfo.Orientation = System.Windows.Forms.Orientation.Horizontal
      Me.spltInfo.Panel1.Controls.Add(Me.grpAnswerCrop)
      Me.spltInfo.Panel2.Controls.Add(Me.lblNoFieldSelected)
      Me.spltInfo.Panel2.Controls.Add(Me.cbZones)
      Me.spltInfo.Panel2.Controls.Add(Me.chkSkipNonOMR)
      Me.spltInfo.Panel2.Controls.Add(Me.btnNextZone)
      Me.spltInfo.Panel2.Controls.Add(Me.btnPreviousZone)
      Me.spltInfo.Size = New System.Drawing.Size(308, 751)
      Me.spltInfo.SplitterDistance = 247
      Me.spltInfo.TabIndex = 5
      Me.grpAnswerCrop.Controls.Add(Me.pnlAnswerCrop)
      Me.grpAnswerCrop.Location = New System.Drawing.Point(4, 91)
      Me.grpAnswerCrop.Name = "grpAnswerCrop"
      Me.grpAnswerCrop.Size = New System.Drawing.Size(299, 154)
      Me.grpAnswerCrop.TabIndex = 1
      Me.grpAnswerCrop.TabStop = False
      Me.grpAnswerCrop.Text = "Answer Sheet"
      Me.pnlAnswerCrop.BackColor = System.Drawing.SystemColors.ControlDark
      Me.pnlAnswerCrop.Controls.Add(Me.lblAnswerKey)
      Me.pnlAnswerCrop.Dock = System.Windows.Forms.DockStyle.Fill
      Me.pnlAnswerCrop.Location = New System.Drawing.Point(3, 16)
      Me.pnlAnswerCrop.Name = "pnlAnswerCrop"
      Me.pnlAnswerCrop.Size = New System.Drawing.Size(293, 135)
      Me.pnlAnswerCrop.TabIndex = 2
      Me.lblAnswerKey.Anchor = System.Windows.Forms.AnchorStyles.None
      Me.lblAnswerKey.BackColor = System.Drawing.SystemColors.Control
      Me.lblAnswerKey.Location = New System.Drawing.Point(7, 59)
      Me.lblAnswerKey.Name = "lblAnswerKey"
      Me.lblAnswerKey.Size = New System.Drawing.Size(282, 13)
      Me.lblAnswerKey.TabIndex = 0
      Me.lblAnswerKey.Text = "Answer Key"
      Me.lblAnswerKey.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      Me.cbZones.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cbZones.FormattingEnabled = True
      Me.cbZones.Location = New System.Drawing.Point(49, 467)
      Me.cbZones.Name = "cbZones"
      Me.cbZones.Size = New System.Drawing.Size(211, 21)
      Me.cbZones.TabIndex = 6
      AddHandler Me.cbZones.SelectedIndexChanged, AddressOf Me.cbZones_SelectedIndexChanged
      Me.chkSkipNonOMR.AutoSize = True
      Me.chkSkipNonOMR.Checked = True
      Me.chkSkipNonOMR.CheckState = System.Windows.Forms.CheckState.Checked
      Me.chkSkipNonOMR.Location = New System.Drawing.Point(88, 440)
      Me.chkSkipNonOMR.Name = "chkSkipNonOMR"
      Me.chkSkipNonOMR.Size = New System.Drawing.Size(128, 17)
      Me.chkSkipNonOMR.TabIndex = 5
      Me.chkSkipNonOMR.Text = "Skip Non-OMR Fields"
      Me.chkSkipNonOMR.UseVisualStyleBackColor = True
      Me.btnNextZone.Location = New System.Drawing.Point(225, 436)
      Me.btnNextZone.Name = "btnNextZone"
      Me.btnNextZone.Size = New System.Drawing.Size(75, 23)
      Me.btnNextZone.TabIndex = 4
      Me.btnNextZone.Text = "&Next"
      Me.btnNextZone.UseVisualStyleBackColor = True
      AddHandler Me.btnNextZone.Click, AddressOf Me.btnNextZone_Click
      Me.btnPreviousZone.Location = New System.Drawing.Point(7, 436)
      Me.btnPreviousZone.Name = "btnPreviousZone"
      Me.btnPreviousZone.Size = New System.Drawing.Size(75, 23)
      Me.btnPreviousZone.TabIndex = 3
      Me.btnPreviousZone.Text = "&Previous"
      Me.btnPreviousZone.UseVisualStyleBackColor = True
      AddHandler Me.btnPreviousZone.Click, AddressOf Me.btnPreviousZone_Click
      Me.lblCurrentPage.Location = New System.Drawing.Point(123, 645)
      Me.lblCurrentPage.Name = "lblCurrentPage"
      Me.lblCurrentPage.Size = New System.Drawing.Size(249, 23)
      Me.lblCurrentPage.TabIndex = 6
      Me.lblCurrentPage.Text = "Page 1 of 1"
      Me.lblCurrentPage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      Me.btnNextPage.Location = New System.Drawing.Point(378, 645)
      Me.btnNextPage.Name = "btnNextPage"
      Me.btnNextPage.Size = New System.Drawing.Size(105, 23)
      Me.btnNextPage.TabIndex = 5
      Me.btnNextPage.Text = "Next Pa&ge"
      Me.btnNextPage.UseVisualStyleBackColor = True
      AddHandler Me.btnNextPage.Click, AddressOf Me.btnNextPage_Click
      Me.btnPreviousPage.Location = New System.Drawing.Point(12, 645)
      Me.btnPreviousPage.Name = "btnPreviousPage"
      Me.btnPreviousPage.Size = New System.Drawing.Size(105, 23)
      Me.btnPreviousPage.TabIndex = 4
      Me.btnPreviousPage.Text = "Previous P&age"
      Me.btnPreviousPage.UseVisualStyleBackColor = True
      AddHandler Me.btnPreviousPage.Click, AddressOf Me.btnPreviousPage_Click
      Me.grpReview.Controls.Add(Me.btnChooseFilters)
      Me.grpReview.Controls.Add(Me.rdbtnSpecific)
      Me.grpReview.Controls.Add(Me.rdbtnAllFields)
      Me.grpReview.Location = New System.Drawing.Point(14, 687)
      Me.grpReview.Name = "grpReview"
      Me.grpReview.Size = New System.Drawing.Size(313, 52)
      Me.grpReview.TabIndex = 3
      Me.grpReview.TabStop = False
      Me.grpReview.Text = "Fields to Review"
      Me.btnChooseFilters.Location = New System.Drawing.Point(186, 16)
      Me.btnChooseFilters.Name = "btnChooseFilters"
      Me.btnChooseFilters.Size = New System.Drawing.Size(114, 23)
      Me.btnChooseFilters.TabIndex = 2
      Me.btnChooseFilters.Text = "&Choose Filters..."
      Me.btnChooseFilters.UseVisualStyleBackColor = True
      AddHandler Me.btnChooseFilters.Click, AddressOf Me.btnChooseFilters_Click
      Me.rdbtnSpecific.AutoSize = True
      Me.rdbtnSpecific.Location = New System.Drawing.Point(87, 19)
      Me.rdbtnSpecific.Name = "rdbtnSpecific"
      Me.rdbtnSpecific.Size = New System.Drawing.Size(93, 17)
      Me.rdbtnSpecific.TabIndex = 1
      Me.rdbtnSpecific.Text = "&Specific Fields"
      Me.rdbtnSpecific.UseVisualStyleBackColor = True
      Me.rdbtnAllFields.AutoSize = True
      Me.rdbtnAllFields.Checked = True
      Me.rdbtnAllFields.Location = New System.Drawing.Point(15, 19)
      Me.rdbtnAllFields.Name = "rdbtnAllFields"
      Me.rdbtnAllFields.Size = New System.Drawing.Size(66, 17)
      Me.rdbtnAllFields.TabIndex = 0
      Me.rdbtnAllFields.TabStop = True
      Me.rdbtnAllFields.Text = "&All Fields"
      Me.rdbtnAllFields.UseVisualStyleBackColor = True
      AddHandler Me.rdbtnAllFields.CheckedChanged, AddressOf Me.rdbtnAllFields_CheckedChanged
      Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.btnCancel.Location = New System.Drawing.Point(408, 720)
      Me.btnCancel.Name = "btnCancel"
      Me.btnCancel.Size = New System.Drawing.Size(75, 23)
      Me.btnCancel.TabIndex = 2
      Me.btnCancel.Text = "&Close"
      Me.btnCancel.UseVisualStyleBackColor = True
      AddHandler Me.btnCancel.Click, AddressOf Me.btnCancel_Click
      Me.pnlFullSheet.Location = New System.Drawing.Point(3, 3)
      Me.pnlFullSheet.Name = "pnlFullSheet"
      Me.pnlFullSheet.Size = New System.Drawing.Size(489, 636)
      Me.pnlFullSheet.TabIndex = 0
      Me.lblNoFieldSelected.AutoSize = True
      Me.lblNoFieldSelected.Location = New System.Drawing.Point(110, 244)
      Me.lblNoFieldSelected.Name = "lblNoFieldSelected"
      Me.lblNoFieldSelected.Size = New System.Drawing.Size(89, 13)
      Me.lblNoFieldSelected.TabIndex = 7
      Me.lblNoFieldSelected.Text = "No field selected."
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.CancelButton = Me.btnCancel
      Me.ClientSize = New System.Drawing.Size(807, 751)
      Me.Controls.Add(Me.spltMain)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "SingleReviewPanel"
      Me.ShowIcon = False
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
      Me.Text = "Review"
      Me.spltMain.Panel1.ResumeLayout(False)
      Me.spltMain.Panel2.ResumeLayout(False)
      CType(Me.spltMain, System.ComponentModel.ISupportInitialize).EndInit()
      Me.spltMain.ResumeLayout(False)
      Me.grpInfo.ResumeLayout(False)
      Me.grpInfo.PerformLayout()
      Me.spltInfo.Panel1.ResumeLayout(False)
      Me.spltInfo.Panel2.ResumeLayout(False)
      Me.spltInfo.Panel2.PerformLayout()
      CType(Me.spltInfo, System.ComponentModel.ISupportInitialize).EndInit()
      Me.spltInfo.ResumeLayout(False)
      Me.grpAnswerCrop.ResumeLayout(False)
      Me.pnlAnswerCrop.ResumeLayout(False)
      Me.grpReview.ResumeLayout(False)
      Me.grpReview.PerformLayout()
      Me.ResumeLayout(False)
   End Sub

   Private spltMain As System.Windows.Forms.SplitContainer
   Private grpInfo As System.Windows.Forms.GroupBox
   Private pnlAnswerCrop As System.Windows.Forms.Panel
   Private lblFilename As System.Windows.Forms.Label
   Private pnlFullSheet As System.Windows.Forms.Panel
   Private lblAnswerKey As System.Windows.Forms.Label
   Private btnCancel As System.Windows.Forms.Button
   Private btnNextWorksheet As System.Windows.Forms.Button
   Private btnPreviousWorksheet As System.Windows.Forms.Button
   Private btnNextZone As System.Windows.Forms.Button
   Private btnPreviousZone As System.Windows.Forms.Button
   Private spltInfo As System.Windows.Forms.SplitContainer
   Private grpReview As System.Windows.Forms.GroupBox
   Private btnChooseFilters As System.Windows.Forms.Button
   Private rdbtnSpecific As System.Windows.Forms.RadioButton
   Private rdbtnAllFields As System.Windows.Forms.RadioButton
   Private lblCurrentPage As System.Windows.Forms.Label
   Private btnNextPage As System.Windows.Forms.Button
   Private btnPreviousPage As System.Windows.Forms.Button
   Private grpAnswerCrop As System.Windows.Forms.GroupBox
   Private cbFiles As System.Windows.Forms.ComboBox
   Private chkSkipNonOMR As System.Windows.Forms.CheckBox
   Private cbZones As System.Windows.Forms.ComboBox
   Private lblNoFieldSelected As System.Windows.Forms.Label
End Class
