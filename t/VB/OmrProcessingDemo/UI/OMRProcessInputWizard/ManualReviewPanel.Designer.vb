Imports Microsoft.VisualBasic

Partial Class ManualReviewPanel
   Private components As System.ComponentModel.IContainer = Nothing

   Protected Overrides Sub Dispose(ByVal disposing As Boolean)
      If disposing AndAlso (components IsNot Nothing) Then
         components.Dispose()
      End If

      MyBase.Dispose(disposing)
   End Sub

   Private Sub InitializeComponent()
      Me.grpValidation = New System.Windows.Forms.GroupBox()
      Me.lblFilterTemplates = New System.Windows.Forms.Label()
      Me.rdbtnCustomize = New System.Windows.Forms.RadioButton()
      Me.rdbtnIncorrectOnly = New System.Windows.Forms.RadioButton()
      Me.rdbtnCorrect = New System.Windows.Forms.RadioButton()
      Me.rdbtnChangedOrModified = New System.Windows.Forms.RadioButton()
      Me.rdbtnCommonIssues = New System.Windows.Forms.RadioButton()
      Me.chkModified = New System.Windows.Forms.CheckBox()
      Me.chkAlreadyReviewed = New System.Windows.Forms.CheckBox()
      Me.chkDisagree = New System.Windows.Forms.CheckBox()
      Me.chkAgree = New System.Windows.Forms.CheckBox()
      Me.chkExactlyOne = New System.Windows.Forms.CheckBox()
      Me.label1 = New System.Windows.Forms.Label()
      Me.chkThreshold = New System.Windows.Forms.CheckBox()
      Me.nudThreshold = New System.Windows.Forms.NumericUpDown()
      Me.grpValidation.SuspendLayout()
      CType(Me.nudThreshold, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      Me.grpValidation.Controls.Add(Me.lblFilterTemplates)
      Me.grpValidation.Controls.Add(Me.rdbtnCustomize)
      Me.grpValidation.Controls.Add(Me.rdbtnIncorrectOnly)
      Me.grpValidation.Controls.Add(Me.rdbtnCorrect)
      Me.grpValidation.Controls.Add(Me.rdbtnChangedOrModified)
      Me.grpValidation.Controls.Add(Me.rdbtnCommonIssues)
      Me.grpValidation.Controls.Add(Me.chkModified)
      Me.grpValidation.Controls.Add(Me.chkAlreadyReviewed)
      Me.grpValidation.Controls.Add(Me.chkDisagree)
      Me.grpValidation.Controls.Add(Me.chkAgree)
      Me.grpValidation.Controls.Add(Me.chkExactlyOne)
      Me.grpValidation.Controls.Add(Me.label1)
      Me.grpValidation.Controls.Add(Me.chkThreshold)
      Me.grpValidation.Controls.Add(Me.nudThreshold)
      Me.grpValidation.Location = New System.Drawing.Point(3, 3)
      Me.grpValidation.Name = "grpValidation"
      Me.grpValidation.Size = New System.Drawing.Size(611, 192)
      Me.grpValidation.TabIndex = 0
      Me.grpValidation.TabStop = False
      Me.grpValidation.Text = "Manually review"
      Me.lblFilterTemplates.AutoSize = True
      Me.lblFilterTemplates.Location = New System.Drawing.Point(16, 19)
      Me.lblFilterTemplates.Name = "lblFilterTemplates"
      Me.lblFilterTemplates.Size = New System.Drawing.Size(81, 13)
      Me.lblFilterTemplates.TabIndex = 16
      Me.lblFilterTemplates.Text = "Filter Templates"
      Me.rdbtnCustomize.AutoSize = True
      Me.rdbtnCustomize.Location = New System.Drawing.Point(375, 35)
      Me.rdbtnCustomize.Name = "rdbtnCustomize"
      Me.rdbtnCustomize.Size = New System.Drawing.Size(73, 17)
      Me.rdbtnCustomize.TabIndex = 15
      Me.rdbtnCustomize.TabStop = True
      Me.rdbtnCustomize.Text = "C&ustomize"
      Me.rdbtnCustomize.UseVisualStyleBackColor = True
      AddHandler Me.rdbtnCustomize.CheckedChanged, AddressOf Me.rdbtnCustomize_CheckedChanged
      Me.rdbtnIncorrectOnly.AutoSize = True
      Me.rdbtnIncorrectOnly.Location = New System.Drawing.Point(258, 62)
      Me.rdbtnIncorrectOnly.Name = "rdbtnIncorrectOnly"
      Me.rdbtnIncorrectOnly.Size = New System.Drawing.Size(91, 17)
      Me.rdbtnIncorrectOnly.TabIndex = 14
      Me.rdbtnIncorrectOnly.TabStop = True
      Me.rdbtnIncorrectOnly.Text = "Incorr&ect Only"
      Me.rdbtnIncorrectOnly.UseVisualStyleBackColor = True
      AddHandler Me.rdbtnIncorrectOnly.CheckedChanged, AddressOf Me.rdbtnIncorrectOnly_CheckedChanged
      Me.rdbtnCorrect.AutoSize = True
      Me.rdbtnCorrect.Location = New System.Drawing.Point(258, 35)
      Me.rdbtnCorrect.Name = "rdbtnCorrect"
      Me.rdbtnCorrect.Size = New System.Drawing.Size(83, 17)
      Me.rdbtnCorrect.TabIndex = 13
      Me.rdbtnCorrect.TabStop = True
      Me.rdbtnCorrect.Text = "C&orrect Only"
      Me.rdbtnCorrect.UseVisualStyleBackColor = True
      AddHandler Me.rdbtnCorrect.CheckedChanged, AddressOf Me.rdbtnCorrect_CheckedChanged
      Me.rdbtnChangedOrModified.AutoSize = True
      Me.rdbtnChangedOrModified.Location = New System.Drawing.Point(73, 62)
      Me.rdbtnChangedOrModified.Name = "rdbtnChangedOrModified"
      Me.rdbtnChangedOrModified.Size = New System.Drawing.Size(137, 17)
      Me.rdbtnChangedOrModified.TabIndex = 12
      Me.rdbtnChangedOrModified.TabStop = True
      Me.rdbtnChangedOrModified.Text = "Re&viewed and Modified"
      Me.rdbtnChangedOrModified.UseVisualStyleBackColor = True
      AddHandler Me.rdbtnChangedOrModified.CheckedChanged, AddressOf Me.rdbtnChangedOrModified_CheckedChanged
      Me.rdbtnCommonIssues.AutoSize = True
      Me.rdbtnCommonIssues.Location = New System.Drawing.Point(73, 35)
      Me.rdbtnCommonIssues.Name = "rdbtnCommonIssues"
      Me.rdbtnCommonIssues.Size = New System.Drawing.Size(99, 17)
      Me.rdbtnCommonIssues.TabIndex = 11
      Me.rdbtnCommonIssues.TabStop = True
      Me.rdbtnCommonIssues.Text = "&Common Issues"
      Me.rdbtnCommonIssues.UseVisualStyleBackColor = True
      AddHandler Me.rdbtnCommonIssues.CheckedChanged, AddressOf Me.rdbtnCommonIssues_CheckedChanged
      Me.chkModified.AutoSize = True
      Me.chkModified.Location = New System.Drawing.Point(368, 141)
      Me.chkModified.Name = "chkModified"
      Me.chkModified.Size = New System.Drawing.Size(184, 17)
      Me.chkModified.TabIndex = 10
      Me.chkModified.Text = "&modified from their original values."
      Me.chkModified.UseVisualStyleBackColor = True
      AddHandler Me.chkModified.CheckedChanged, AddressOf Me.chkFilter_CheckedChanged
      Me.chkAlreadyReviewed.AutoSize = True
      Me.chkAlreadyReviewed.Location = New System.Drawing.Point(368, 166)
      Me.chkAlreadyReviewed.Name = "chkAlreadyReviewed"
      Me.chkAlreadyReviewed.Size = New System.Drawing.Size(184, 17)
      Me.chkAlreadyReviewed.TabIndex = 9
      Me.chkAlreadyReviewed.Text = "that have already been &reviewed."
      Me.chkAlreadyReviewed.UseVisualStyleBackColor = True
      AddHandler Me.chkAlreadyReviewed.CheckedChanged, AddressOf Me.chkFilter_CheckedChanged
      Me.chkDisagree.AutoSize = True
      Me.chkDisagree.Location = New System.Drawing.Point(19, 166)
      Me.chkDisagree.Name = "chkDisagree"
      Me.chkDisagree.Size = New System.Drawing.Size(333, 17)
      Me.chkDisagree.TabIndex = 8
      Me.chkDisagree.Text = "with a &different value as the answer key. (I. E., incorrect answers)"
      Me.chkDisagree.UseVisualStyleBackColor = True
      AddHandler Me.chkDisagree.CheckedChanged, AddressOf Me.chkFilter_CheckedChanged
      Me.chkAgree.AutoSize = True
      Me.chkAgree.Location = New System.Drawing.Point(19, 141)
      Me.chkAgree.Name = "chkAgree"
      Me.chkAgree.Size = New System.Drawing.Size(321, 17)
      Me.chkAgree.TabIndex = 7
      Me.chkAgree.Text = "with the &same value as the answer key. (I. E., correct answers)" & Constants.vbCrLf
      Me.chkAgree.UseVisualStyleBackColor = True
      AddHandler Me.chkAgree.CheckedChanged, AddressOf Me.chkFilter_CheckedChanged
      Me.chkExactlyOne.AutoSize = True
      Me.chkExactlyOne.Checked = True
      Me.chkExactlyOne.CheckState = System.Windows.Forms.CheckState.Checked
      Me.chkExactlyOne.Location = New System.Drawing.Point(368, 116)
      Me.chkExactlyOne.Name = "chkExactlyOne"
      Me.chkExactlyOne.Size = New System.Drawing.Size(227, 17)
      Me.chkExactlyOne.TabIndex = 6
      Me.chkExactlyOne.Text = "&that don't have exactly one bubble filled in."
      Me.chkExactlyOne.UseVisualStyleBackColor = True
      AddHandler Me.chkExactlyOne.CheckedChanged, AddressOf Me.chkFilter_CheckedChanged
      Me.label1.AutoSize = True
      Me.label1.Location = New System.Drawing.Point(6, 91)
      Me.label1.Name = "label1"
      Me.label1.Size = New System.Drawing.Size(80, 13)
      Me.label1.TabIndex = 5
      Me.label1.Text = "Available Filters"
      Me.label1.Visible = False
      Me.chkThreshold.AutoSize = True
      Me.chkThreshold.Checked = True
      Me.chkThreshold.CheckState = System.Windows.Forms.CheckState.Checked
      Me.chkThreshold.Location = New System.Drawing.Point(19, 116)
      Me.chkThreshold.Name = "chkThreshold"
      Me.chkThreshold.Size = New System.Drawing.Size(215, 17)
      Me.chkThreshold.TabIndex = 4
      Me.chkThreshold.Text = "&with OMR confidence values lower than"
      Me.chkThreshold.UseVisualStyleBackColor = True
      AddHandler Me.chkThreshold.CheckedChanged, AddressOf Me.chkThreshold_CheckedChanged
      Me.nudThreshold.Location = New System.Drawing.Point(240, 115)
      Me.nudThreshold.Name = "nudThreshold"
      Me.nudThreshold.Size = New System.Drawing.Size(51, 20)
      Me.nudThreshold.TabIndex = 3
      Me.nudThreshold.Value = New Decimal(New Integer() {73, 0, 0, 0})
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.Controls.Add(Me.grpValidation)
      Me.Name = "ManualReviewPanel"
      Me.Size = New System.Drawing.Size(617, 198)
      Me.grpValidation.ResumeLayout(False)
      Me.grpValidation.PerformLayout()
      CType(Me.nudThreshold, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
   End Sub

   Private grpValidation As System.Windows.Forms.GroupBox
   Private chkDisagree As System.Windows.Forms.CheckBox
   Private chkAgree As System.Windows.Forms.CheckBox
   Private chkExactlyOne As System.Windows.Forms.CheckBox
   Private label1 As System.Windows.Forms.Label
   Private chkThreshold As System.Windows.Forms.CheckBox
   Private nudThreshold As System.Windows.Forms.NumericUpDown
   Private chkAlreadyReviewed As System.Windows.Forms.CheckBox
   Private chkModified As System.Windows.Forms.CheckBox
   Private rdbtnCustomize As System.Windows.Forms.RadioButton
   Private rdbtnIncorrectOnly As System.Windows.Forms.RadioButton
   Private rdbtnCorrect As System.Windows.Forms.RadioButton
   Private rdbtnChangedOrModified As System.Windows.Forms.RadioButton
   Private rdbtnCommonIssues As System.Windows.Forms.RadioButton
   Private lblFilterTemplates As System.Windows.Forms.Label
End Class
