Partial Class ResultSearchDialog
   Private components As System.ComponentModel.IContainer = Nothing

   Protected Overrides Sub Dispose(ByVal disposing As Boolean)
      If disposing AndAlso (components IsNot Nothing) Then
         components.Dispose()
      End If

      MyBase.Dispose(disposing)
   End Sub

   Private Sub InitializeComponent()
      Me.lblFindWhat = New System.Windows.Forms.Label()
      Me.txtSearch = New System.Windows.Forms.TextBox()
      Me.btnFindNext = New System.Windows.Forms.Button()
      Me.btnClose = New System.Windows.Forms.Button()
      Me.grpDirection = New System.Windows.Forms.GroupBox()
      Me.rdbtnBackward = New System.Windows.Forms.RadioButton()
      Me.rdbtnForward = New System.Windows.Forms.RadioButton()
      Me.grpSearchIn = New System.Windows.Forms.GroupBox()
      Me.rdbtnSearchbyCols = New System.Windows.Forms.RadioButton()
      Me.rdbtnSearchbyRows = New System.Windows.Forms.RadioButton()
      Me.chkMatchCase = New System.Windows.Forms.CheckBox()
      Me.grpDirection.SuspendLayout()
      Me.grpSearchIn.SuspendLayout()
      Me.SuspendLayout()
      Me.lblFindWhat.AutoSize = True
      Me.lblFindWhat.Location = New System.Drawing.Point(12, 9)
      Me.lblFindWhat.Name = "lblFindWhat"
      Me.lblFindWhat.Size = New System.Drawing.Size(56, 13)
      Me.lblFindWhat.TabIndex = 0
      Me.lblFindWhat.Text = "F&ind what:"
      Me.txtSearch.Location = New System.Drawing.Point(74, 6)
      Me.txtSearch.Name = "txtSearch"
      Me.txtSearch.Size = New System.Drawing.Size(228, 20)
      Me.txtSearch.TabIndex = 1
      Me.btnFindNext.Location = New System.Drawing.Point(308, 6)
      Me.btnFindNext.Name = "btnFindNext"
      Me.btnFindNext.Size = New System.Drawing.Size(75, 23)
      Me.btnFindNext.TabIndex = 3
      Me.btnFindNext.Text = "&Find Next"
      Me.btnFindNext.UseVisualStyleBackColor = True
      AddHandler Me.btnFindNext.Click, AddressOf Me.btnFindNext_Click
      Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.btnClose.Location = New System.Drawing.Point(308, 105)
      Me.btnClose.Name = "btnClose"
      Me.btnClose.Size = New System.Drawing.Size(75, 23)
      Me.btnClose.TabIndex = 5
      Me.btnClose.Text = "Close"
      Me.btnClose.UseVisualStyleBackColor = True
      Me.grpDirection.Controls.Add(Me.rdbtnBackward)
      Me.grpDirection.Controls.Add(Me.rdbtnForward)
      Me.grpDirection.Location = New System.Drawing.Point(188, 54)
      Me.grpDirection.Name = "grpDirection"
      Me.grpDirection.Size = New System.Drawing.Size(114, 74)
      Me.grpDirection.TabIndex = 2
      Me.grpDirection.TabStop = False
      Me.grpDirection.Text = "Search Direction"
      Me.rdbtnBackward.AutoSize = True
      Me.rdbtnBackward.Location = New System.Drawing.Point(17, 43)
      Me.rdbtnBackward.Name = "rdbtnBackward"
      Me.rdbtnBackward.Size = New System.Drawing.Size(73, 17)
      Me.rdbtnBackward.TabIndex = 1
      Me.rdbtnBackward.Text = "&Backward"
      Me.rdbtnBackward.UseVisualStyleBackColor = True
      Me.rdbtnForward.AutoSize = True
      Me.rdbtnForward.Checked = True
      Me.rdbtnForward.Location = New System.Drawing.Point(17, 19)
      Me.rdbtnForward.Name = "rdbtnForward"
      Me.rdbtnForward.Size = New System.Drawing.Size(63, 17)
      Me.rdbtnForward.TabIndex = 0
      Me.rdbtnForward.TabStop = True
      Me.rdbtnForward.Text = "&Forward"
      Me.rdbtnForward.UseVisualStyleBackColor = True
      Me.grpSearchIn.Controls.Add(Me.rdbtnSearchbyCols)
      Me.grpSearchIn.Controls.Add(Me.rdbtnSearchbyRows)
      Me.grpSearchIn.Location = New System.Drawing.Point(74, 54)
      Me.grpSearchIn.Name = "grpSearchIn"
      Me.grpSearchIn.Size = New System.Drawing.Size(108, 74)
      Me.grpSearchIn.TabIndex = 6
      Me.grpSearchIn.TabStop = False
      Me.grpSearchIn.Text = "Search In"
      Me.rdbtnSearchbyCols.AutoSize = True
      Me.rdbtnSearchbyCols.Location = New System.Drawing.Point(6, 43)
      Me.rdbtnSearchbyCols.Name = "rdbtnSearchbyCols"
      Me.rdbtnSearchbyCols.Size = New System.Drawing.Size(65, 17)
      Me.rdbtnSearchbyCols.TabIndex = 1
      Me.rdbtnSearchbyCols.Text = "&Columns"
      Me.rdbtnSearchbyCols.UseVisualStyleBackColor = True
      AddHandler Me.rdbtnSearchbyCols.CheckedChanged, AddressOf Me.rdbtnSearchby_CheckedChanged
      Me.rdbtnSearchbyRows.AutoSize = True
      Me.rdbtnSearchbyRows.Checked = True
      Me.rdbtnSearchbyRows.Location = New System.Drawing.Point(6, 19)
      Me.rdbtnSearchbyRows.Name = "rdbtnSearchbyRows"
      Me.rdbtnSearchbyRows.Size = New System.Drawing.Size(52, 17)
      Me.rdbtnSearchbyRows.TabIndex = 0
      Me.rdbtnSearchbyRows.TabStop = True
      Me.rdbtnSearchbyRows.Text = "&Rows"
      Me.rdbtnSearchbyRows.UseVisualStyleBackColor = True
      AddHandler Me.rdbtnSearchbyRows.CheckedChanged, AddressOf Me.rdbtnSearchby_CheckedChanged
      Me.chkMatchCase.AutoSize = True
      Me.chkMatchCase.Location = New System.Drawing.Point(74, 32)
      Me.chkMatchCase.Name = "chkMatchCase"
      Me.chkMatchCase.Size = New System.Drawing.Size(83, 17)
      Me.chkMatchCase.TabIndex = 7
      Me.chkMatchCase.Text = "&Match Case"
      Me.chkMatchCase.UseVisualStyleBackColor = True
      Me.AcceptButton = Me.btnFindNext
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.CancelButton = Me.btnClose
      Me.ClientSize = New System.Drawing.Size(395, 137)
      Me.Controls.Add(Me.chkMatchCase)
      Me.Controls.Add(Me.grpSearchIn)
      Me.Controls.Add(Me.grpDirection)
      Me.Controls.Add(Me.btnClose)
      Me.Controls.Add(Me.btnFindNext)
      Me.Controls.Add(Me.txtSearch)
      Me.Controls.Add(Me.lblFindWhat)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "ResultSearchDialog"
      Me.ShowIcon = False
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
      Me.Text = "Search"
      Me.grpDirection.ResumeLayout(False)
      Me.grpDirection.PerformLayout()
      Me.grpSearchIn.ResumeLayout(False)
      Me.grpSearchIn.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()
   End Sub

   Private lblFindWhat As System.Windows.Forms.Label
   Private txtSearch As System.Windows.Forms.TextBox
   Private btnFindNext As System.Windows.Forms.Button
   Private btnClose As System.Windows.Forms.Button
   Private grpDirection As System.Windows.Forms.GroupBox
   Private rdbtnBackward As System.Windows.Forms.RadioButton
   Private rdbtnForward As System.Windows.Forms.RadioButton
   Private grpSearchIn As System.Windows.Forms.GroupBox
   Private rdbtnSearchbyCols As System.Windows.Forms.RadioButton
   Private rdbtnSearchbyRows As System.Windows.Forms.RadioButton
   Private chkMatchCase As System.Windows.Forms.CheckBox
End Class
