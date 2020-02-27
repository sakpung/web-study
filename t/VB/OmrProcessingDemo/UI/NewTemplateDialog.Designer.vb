Partial Class NewTemplateDialog
   Private components As System.ComponentModel.IContainer = Nothing

   Protected Overrides Sub Dispose(ByVal disposing As Boolean)
      If disposing AndAlso (components IsNot Nothing) Then
         components.Dispose()
      End If

      MyBase.Dispose(disposing)
   End Sub

   Private Sub InitializeComponent()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(NewTemplateDialog))
      Me.BtnOK = New System.Windows.Forms.Button()
      Me.btnCancel = New System.Windows.Forms.Button()
      Me.rdbtnTwain = New System.Windows.Forms.RadioButton()
      Me.grpTwain = New System.Windows.Forms.GroupBox()
      Me.txtScanPath = New System.Windows.Forms.TextBox()
      Me.btnScan = New System.Windows.Forms.Button()
      Me.grpLoad = New System.Windows.Forms.GroupBox()
      Me.txtFilePath = New System.Windows.Forms.TextBox()
      Me.btnBrowse = New System.Windows.Forms.Button()
      Me.rdBtnFile = New System.Windows.Forms.RadioButton()
      Me.pnlThumbnail = New System.Windows.Forms.Panel()
      Me.lblDescription = New System.Windows.Forms.Label()
      Me.txtTemplateName = New System.Windows.Forms.TextBox()
      Me.btnPreviousPage = New System.Windows.Forms.Button()
      Me.btnNextPage = New System.Windows.Forms.Button()
      Me.lblPageIndex = New System.Windows.Forms.Label()
      Me.grpTwain.SuspendLayout()
      Me.grpLoad.SuspendLayout()
      Me.SuspendLayout()
      Me.BtnOK.DialogResult = System.Windows.Forms.DialogResult.OK
      Me.BtnOK.Location = New System.Drawing.Point(454, 227)
      Me.BtnOK.Name = "BtnOK"
      Me.BtnOK.Size = New System.Drawing.Size(71, 23)
      Me.BtnOK.TabIndex = 2
      Me.BtnOK.Text = "OK"
      Me.BtnOK.UseVisualStyleBackColor = True
      Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.btnCancel.Location = New System.Drawing.Point(531, 227)
      Me.btnCancel.Name = "btnCancel"
      Me.btnCancel.Size = New System.Drawing.Size(75, 23)
      Me.btnCancel.TabIndex = 3
      Me.btnCancel.Text = "Cancel"
      Me.btnCancel.UseVisualStyleBackColor = True
      Me.rdbtnTwain.AutoSize = True
      Me.rdbtnTwain.Location = New System.Drawing.Point(24, 149)
      Me.rdbtnTwain.Name = "rdbtnTwain"
      Me.rdbtnTwain.Size = New System.Drawing.Size(91, 17)
      Me.rdbtnTwain.TabIndex = 13
      Me.rdbtnTwain.TabStop = True
      Me.rdbtnTwain.Text = "From Scanner"
      Me.rdbtnTwain.UseVisualStyleBackColor = True
      AddHandler Me.rdbtnTwain.CheckedChanged, AddressOf Me.rdBtnToggled
      Me.grpTwain.Controls.Add(Me.txtScanPath)
      Me.grpTwain.Controls.Add(Me.btnScan)
      Me.grpTwain.Location = New System.Drawing.Point(18, 160)
      Me.grpTwain.Name = "grpTwain"
      Me.grpTwain.Size = New System.Drawing.Size(430, 61)
      Me.grpTwain.TabIndex = 15
      Me.grpTwain.TabStop = False
      Me.txtScanPath.Location = New System.Drawing.Point(90, 23)
      Me.txtScanPath.Name = "txtScanPath"
      Me.txtScanPath.Size = New System.Drawing.Size(329, 20)
      Me.txtScanPath.TabIndex = 8
      Me.btnScan.Location = New System.Drawing.Point(9, 23)
      Me.btnScan.Name = "btnScan"
      Me.btnScan.Size = New System.Drawing.Size(75, 23)
      Me.btnScan.TabIndex = 7
      Me.btnScan.Text = "Scan"
      Me.btnScan.UseVisualStyleBackColor = True
      AddHandler Me.btnScan.Click, AddressOf Me.btnScan_Click
      Me.grpLoad.Controls.Add(Me.txtFilePath)
      Me.grpLoad.Controls.Add(Me.btnBrowse)
      Me.grpLoad.Location = New System.Drawing.Point(18, 77)
      Me.grpLoad.Name = "grpLoad"
      Me.grpLoad.Size = New System.Drawing.Size(430, 66)
      Me.grpLoad.TabIndex = 14
      Me.grpLoad.TabStop = False
      Me.txtFilePath.Location = New System.Drawing.Point(9, 19)
      Me.txtFilePath.Name = "txtFilePath"
      Me.txtFilePath.Size = New System.Drawing.Size(329, 20)
      Me.txtFilePath.TabIndex = 4
      Me.btnBrowse.Location = New System.Drawing.Point(344, 19)
      Me.btnBrowse.Name = "btnBrowse"
      Me.btnBrowse.Size = New System.Drawing.Size(75, 23)
      Me.btnBrowse.TabIndex = 5
      Me.btnBrowse.Text = "Browse"
      Me.btnBrowse.UseVisualStyleBackColor = True
      AddHandler Me.btnBrowse.Click, AddressOf Me.btnBrowse_Click
      Me.rdBtnFile.AutoSize = True
      Me.rdBtnFile.Location = New System.Drawing.Point(24, 64)
      Me.rdBtnFile.Name = "rdBtnFile"
      Me.rdBtnFile.Size = New System.Drawing.Size(80, 17)
      Me.rdBtnFile.TabIndex = 0
      Me.rdBtnFile.TabStop = True
      Me.rdBtnFile.Text = "File on Disk"
      Me.rdBtnFile.UseVisualStyleBackColor = True
      AddHandler Me.rdBtnFile.CheckedChanged, AddressOf Me.rdBtnToggled
      Me.pnlThumbnail.BackColor = System.Drawing.SystemColors.ControlDark
      Me.pnlThumbnail.Location = New System.Drawing.Point(454, 12)
      Me.pnlThumbnail.Name = "pnlThumbnail"
      Me.pnlThumbnail.Size = New System.Drawing.Size(152, 180)
      Me.pnlThumbnail.TabIndex = 25
      Me.lblDescription.AutoSize = True
      Me.lblDescription.Location = New System.Drawing.Point(24, 26)
      Me.lblDescription.Name = "lblDescription"
      Me.lblDescription.Size = New System.Drawing.Size(85, 13)
      Me.lblDescription.TabIndex = 26
      Me.lblDescription.Text = "Template Name:"
      Me.txtTemplateName.Location = New System.Drawing.Point(115, 23)
      Me.txtTemplateName.Name = "txtTemplateName"
      Me.txtTemplateName.Size = New System.Drawing.Size(322, 20)
      Me.txtTemplateName.TabIndex = 27
      AddHandler Me.txtTemplateName.TextChanged, AddressOf Me.txtTemplateName_TextChanged
      Me.btnPreviousPage.Enabled = False
      Me.btnPreviousPage.Location = New System.Drawing.Point(454, 198)
      Me.btnPreviousPage.Name = "btnPreviousPage"
      Me.btnPreviousPage.Size = New System.Drawing.Size(29, 23)
      Me.btnPreviousPage.TabIndex = 28
      Me.btnPreviousPage.Text = "<<"
      Me.btnPreviousPage.UseVisualStyleBackColor = True
      AddHandler Me.btnPreviousPage.Click, AddressOf Me.btnPreviousPage_Click
      Me.btnNextPage.Enabled = False
      Me.btnNextPage.Location = New System.Drawing.Point(576, 198)
      Me.btnNextPage.Name = "btnNextPage"
      Me.btnNextPage.Size = New System.Drawing.Size(29, 23)
      Me.btnNextPage.TabIndex = 29
      Me.btnNextPage.Text = ">>"
      Me.btnNextPage.UseVisualStyleBackColor = True
      AddHandler Me.btnNextPage.Click, AddressOf Me.btnNextPage_Click
      Me.lblPageIndex.Location = New System.Drawing.Point(494, 203)
      Me.lblPageIndex.Name = "lblPageIndex"
      Me.lblPageIndex.Size = New System.Drawing.Size(71, 18)
      Me.lblPageIndex.TabIndex = 30
      Me.lblPageIndex.Text = "Page X of Y"
      Me.lblPageIndex.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      Me.lblPageIndex.Visible = False
      Me.AcceptButton = Me.BtnOK
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.CancelButton = Me.btnCancel
      Me.ClientSize = New System.Drawing.Size(618, 263)
      Me.Controls.Add(Me.rdbtnTwain)
      Me.Controls.Add(Me.lblPageIndex)
      Me.Controls.Add(Me.rdBtnFile)
      Me.Controls.Add(Me.btnNextPage)
      Me.Controls.Add(Me.btnPreviousPage)
      Me.Controls.Add(Me.txtTemplateName)
      Me.Controls.Add(Me.lblDescription)
      Me.Controls.Add(Me.pnlThumbnail)
      Me.Controls.Add(Me.grpTwain)
      Me.Controls.Add(Me.grpLoad)
      Me.Controls.Add(Me.btnCancel)
      Me.Controls.Add(Me.BtnOK)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
      Me.Icon = (CType((resources.GetObject("$this.Icon")), System.Drawing.Icon))
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "NewTemplateDialog"
      Me.ShowInTaskbar = False
      Me.Text = "Create New Template"
      AddHandler Me.FormClosing, AddressOf Me.GetNewImageDialog_FormClosing
      Me.grpTwain.ResumeLayout(False)
      Me.grpTwain.PerformLayout()
      Me.grpLoad.ResumeLayout(False)
      Me.grpLoad.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()
   End Sub

   Private BtnOK As System.Windows.Forms.Button
   Private btnCancel As System.Windows.Forms.Button
   Private WithEvents rdbtnTwain As System.Windows.Forms.RadioButton
   Private grpTwain As System.Windows.Forms.GroupBox
   Private btnScan As System.Windows.Forms.Button
   Private grpLoad As System.Windows.Forms.GroupBox
   Private txtFilePath As System.Windows.Forms.TextBox
   Private WithEvents btnBrowse As System.Windows.Forms.Button
   Private WithEvents rdBtnFile As System.Windows.Forms.RadioButton
   Private pnlThumbnail As System.Windows.Forms.Panel
   Private lblDescription As System.Windows.Forms.Label
   Private WithEvents txtTemplateName As System.Windows.Forms.TextBox
   Private txtScanPath As System.Windows.Forms.TextBox
   Private WithEvents btnPreviousPage As System.Windows.Forms.Button
   Private WithEvents btnNextPage As System.Windows.Forms.Button
   Private lblPageIndex As System.Windows.Forms.Label
End Class
