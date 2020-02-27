Namespace MedicalViewerDemo
   Partial Class CellPropertiesDialog
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
         Me.groupBox1 = New System.Windows.Forms.GroupBox()
         Me._rdoApplyToSelected = New System.Windows.Forms.RadioButton()
         Me._rdoApplyToAll = New System.Windows.Forms.RadioButton()
         Me.groupBox2 = New System.Windows.Forms.GroupBox()
         Me._chkSnapRulers = New System.Windows.Forms.CheckBox()
         Me.label1 = New System.Windows.Forms.Label()
         Me._cmbDisplayRuler = New System.Windows.Forms.ComboBox()
         Me._chkFitImage = New System.Windows.Forms.CheckBox()
         Me._chkShowTags = New System.Windows.Forms.CheckBox()
         Me.groupBox3 = New System.Windows.Forms.GroupBox()
         Me._chkApplyOnMove = New System.Windows.Forms.CheckBox()
         Me._chkApplyWLToAll = New System.Windows.Forms.CheckBox()
         Me._txtColumns = New MedicalViewerDemo.NumericTextBox()
         Me._txtRows = New MedicalViewerDemo.NumericTextBox()
         Me.label3 = New System.Windows.Forms.Label()
         Me.label2 = New System.Windows.Forms.Label()
         Me._btnApply = New System.Windows.Forms.Button()
         Me._btnCancel = New System.Windows.Forms.Button()
         Me._btnOK = New System.Windows.Forms.Button()
         Me._chkDisableControlPoints = New System.Windows.Forms.CheckBox()
         Me.groupBox1.SuspendLayout()
         Me.groupBox2.SuspendLayout()
         Me.groupBox3.SuspendLayout()
         Me.SuspendLayout()
         ' 
         ' groupBox1
         ' 
         Me.groupBox1.Controls.Add(Me._rdoApplyToSelected)
         Me.groupBox1.Controls.Add(Me._rdoApplyToAll)
         Me.groupBox1.Location = New System.Drawing.Point(11, 8)
         Me.groupBox1.Name = "groupBox1"
         Me.groupBox1.Size = New System.Drawing.Size(228, 70)
         Me.groupBox1.TabIndex = 0
         Me.groupBox1.TabStop = False
         Me.groupBox1.Text = "Apply &to"
         ' 
         ' _rdoApplyToSelected
         ' 
         Me._rdoApplyToSelected.AutoSize = True
         Me._rdoApplyToSelected.Location = New System.Drawing.Point(16, 43)
         Me._rdoApplyToSelected.Name = "_rdoApplyToSelected"
         Me._rdoApplyToSelected.Size = New System.Drawing.Size(131, 17)
         Me._rdoApplyToSelected.TabIndex = 1
         Me._rdoApplyToSelected.TabStop = True
         Me._rdoApplyToSelected.Text = "A&pply to selected cells"
         Me._rdoApplyToSelected.UseVisualStyleBackColor = True
         ' 
         ' _rdoApplyToAll
         ' 
         Me._rdoApplyToAll.AutoSize = True
         Me._rdoApplyToAll.Location = New System.Drawing.Point(16, 20)
         Me._rdoApplyToAll.Name = "_rdoApplyToAll"
         Me._rdoApplyToAll.Size = New System.Drawing.Size(122, 17)
         Me._rdoApplyToAll.TabIndex = 0
         Me._rdoApplyToAll.TabStop = True
         Me._rdoApplyToAll.Text = "&Apply to all sub-cells"
         Me._rdoApplyToAll.UseVisualStyleBackColor = True
         ' 
         ' groupBox2
         ' 
         Me.groupBox2.Controls.Add(Me._chkSnapRulers)
         Me.groupBox2.Controls.Add(Me.label1)
         Me.groupBox2.Controls.Add(Me._cmbDisplayRuler)
         Me.groupBox2.Controls.Add(Me._chkFitImage)
         Me.groupBox2.Controls.Add(Me._chkShowTags)
         Me.groupBox2.Location = New System.Drawing.Point(11, 79)
         Me.groupBox2.Name = "groupBox2"
         Me.groupBox2.Size = New System.Drawing.Size(228, 103)
         Me.groupBox2.TabIndex = 1
         Me.groupBox2.TabStop = False
         Me.groupBox2.Text = "Propert&ies"
         ' 
         ' _chkSnapRulers
         ' 
         Me._chkSnapRulers.AutoSize = True
         Me._chkSnapRulers.Location = New System.Drawing.Point(17, 74)
         Me._chkSnapRulers.Name = "_chkSnapRulers"
         Me._chkSnapRulers.Size = New System.Drawing.Size(83, 17)
         Me._chkSnapRulers.TabIndex = 4
         Me._chkSnapRulers.Text = "&Snap Rulers"
         Me._chkSnapRulers.UseVisualStyleBackColor = True
         ' 
         ' label1
         ' 
         Me.label1.AutoSize = True
         Me.label1.Location = New System.Drawing.Point(127, 31)
         Me.label1.Name = "label1"
         Me.label1.Size = New System.Drawing.Size(71, 13)
         Me.label1.TabIndex = 3
         Me.label1.Text = "&Display rulers"
         ' 
         ' _cmbDisplayRuler
         ' 
         Me._cmbDisplayRuler.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
         Me._cmbDisplayRuler.FormattingEnabled = True
         Me._cmbDisplayRuler.Items.AddRange(New Object() {"None", "Both", "Vertical", "Horizontal"})
         Me._cmbDisplayRuler.Location = New System.Drawing.Point(114, 56)
         Me._cmbDisplayRuler.Name = "_cmbDisplayRuler"
         Me._cmbDisplayRuler.Size = New System.Drawing.Size(95, 21)
         Me._cmbDisplayRuler.TabIndex = 2
         ' 
         ' _chkFitImage
         ' 
         Me._chkFitImage.AutoSize = True
         Me._chkFitImage.Location = New System.Drawing.Point(17, 51)
         Me._chkFitImage.Name = "_chkFitImage"
         Me._chkFitImage.Size = New System.Drawing.Size(71, 17)
         Me._chkFitImage.TabIndex = 1
         Me._chkFitImage.Text = "&Fit Image"
         Me._chkFitImage.UseVisualStyleBackColor = True
         ' 
         ' _chkShowTags
         ' 
         Me._chkShowTags.AutoSize = True
         Me._chkShowTags.Location = New System.Drawing.Point(17, 27)
         Me._chkShowTags.Name = "_chkShowTags"
         Me._chkShowTags.Size = New System.Drawing.Size(78, 17)
         Me._chkShowTags.TabIndex = 0
         Me._chkShowTags.Text = "Show &Tags"
         Me._chkShowTags.UseVisualStyleBackColor = True
         ' 
         ' groupBox3
         ' 
         Me.groupBox3.Controls.Add(Me._chkDisableControlPoints)
         Me.groupBox3.Controls.Add(Me._chkApplyOnMove)
         Me.groupBox3.Controls.Add(Me._chkApplyWLToAll)
         Me.groupBox3.Controls.Add(Me._txtColumns)
         Me.groupBox3.Controls.Add(Me._txtRows)
         Me.groupBox3.Controls.Add(Me.label3)
         Me.groupBox3.Controls.Add(Me.label2)
         Me.groupBox3.Location = New System.Drawing.Point(11, 188)
         Me.groupBox3.Name = "groupBox3"
         Me.groupBox3.Size = New System.Drawing.Size(228, 137)
         Me.groupBox3.TabIndex = 1
         Me.groupBox3.TabStop = False
         Me.groupBox3.Text = "Sub-&cells"
         ' 
         ' _chkApplyOnMove
         ' 
         Me._chkApplyOnMove.AutoSize = True
         Me._chkApplyOnMove.Location = New System.Drawing.Point(16, 87)
         Me._chkApplyOnMove.Name = "_chkApplyOnMove"
         Me._chkApplyOnMove.Size = New System.Drawing.Size(205, 17)
         Me._chkApplyOnMove.TabIndex = 5
         Me._chkApplyOnMove.Text = "Apply the action as the mouse &moves"
         Me._chkApplyOnMove.UseVisualStyleBackColor = True
         ' 
         ' _chkApplyWLToAll
         ' 
         Me._chkApplyWLToAll.AutoSize = True
         Me._chkApplyWLToAll.Location = New System.Drawing.Point(16, 61)
         Me._chkApplyWLToAll.Name = "_chkApplyWLToAll"
         Me._chkApplyWLToAll.Size = New System.Drawing.Size(203, 17)
         Me._chkApplyWLToAll.TabIndex = 4
         Me._chkApplyWLToAll.Text = "Apply &window leveling on all sub-cells"
         Me._chkApplyWLToAll.UseVisualStyleBackColor = True
         ' 
         ' _txtColumns
         ' 
         Me._txtColumns.Location = New System.Drawing.Point(164, 21)
         Me._txtColumns.MaximumAllowed = 8
         Me._txtColumns.MinimumAllowed = 1
         Me._txtColumns.Name = "_txtColumns"
         Me._txtColumns.Size = New System.Drawing.Size(46, 20)
         Me._txtColumns.TabIndex = 3
         Me._txtColumns.Text = "1"
         Me._txtColumns.Value = 1
         ' 
         ' _txtRows
         ' 
         Me._txtRows.Location = New System.Drawing.Point(57, 21)
         Me._txtRows.MaximumAllowed = 8
         Me._txtRows.MinimumAllowed = 1
         Me._txtRows.Name = "_txtRows"
         Me._txtRows.Size = New System.Drawing.Size(46, 20)
         Me._txtRows.TabIndex = 2
         Me._txtRows.Text = "1"
         Me._txtRows.Value = 1
         ' 
         ' label3
         ' 
         Me.label3.AutoSize = True
         Me.label3.Location = New System.Drawing.Point(115, 25)
         Me.label3.Name = "label3"
         Me.label3.Size = New System.Drawing.Size(47, 13)
         Me.label3.TabIndex = 1
         Me.label3.Text = "C&olumns"
         ' 
         ' label2
         ' 
         Me.label2.AutoSize = True
         Me.label2.Location = New System.Drawing.Point(17, 25)
         Me.label2.Name = "label2"
         Me.label2.Size = New System.Drawing.Size(33, 13)
         Me.label2.TabIndex = 0
         Me.label2.Text = "&Rows"
         ' 
         ' _btnApply
         ' 
         Me._btnApply.Location = New System.Drawing.Point(168, 334)
         Me._btnApply.Name = "_btnApply"
         Me._btnApply.Size = New System.Drawing.Size(71, 29)
         Me._btnApply.TabIndex = 14
         Me._btnApply.Text = "App&ly"
         Me._btnApply.UseVisualStyleBackColor = True
         ' 
         ' _btnCancel
         ' 
         Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
         Me._btnCancel.Location = New System.Drawing.Point(88, 334)
         Me._btnCancel.Name = "_btnCancel"
         Me._btnCancel.Size = New System.Drawing.Size(71, 29)
         Me._btnCancel.TabIndex = 13
         Me._btnCancel.Text = "Canc&el"
         Me._btnCancel.UseVisualStyleBackColor = True
         ' 
         ' _btnOK
         ' 
         Me._btnOK.DialogResult = System.Windows.Forms.DialogResult.Cancel
         Me._btnOK.Location = New System.Drawing.Point(10, 334)
         Me._btnOK.Name = "_btnOK"
         Me._btnOK.Size = New System.Drawing.Size(71, 29)
         Me._btnOK.TabIndex = 12
         Me._btnOK.Text = "O&K"
         Me._btnOK.UseVisualStyleBackColor = True
         ' 
         ' _chkDisableControlPoints
         ' 
         Me._chkDisableControlPoints.AutoSize = True
         Me._chkDisableControlPoints.Location = New System.Drawing.Point(16, 110)
         Me._chkDisableControlPoints.Name = "_chkDisableControlPoints"
         Me._chkDisableControlPoints.Size = New System.Drawing.Size(186, 17)
         Me._chkDisableControlPoints.TabIndex = 6
         Me._chkDisableControlPoints.Text = "Disable Annotation Control points"
         Me._chkDisableControlPoints.UseVisualStyleBackColor = True
         ' 
         ' CellPropertiesDialog
         ' 
         Me.AcceptButton = Me._btnOK
         Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.CancelButton = Me._btnCancel
         Me.ClientSize = New System.Drawing.Size(249, 371)
         Me.Controls.Add(Me._btnApply)
         Me.Controls.Add(Me._btnCancel)
         Me.Controls.Add(Me._btnOK)
         Me.Controls.Add(Me.groupBox2)
         Me.Controls.Add(Me.groupBox3)
         Me.Controls.Add(Me.groupBox1)
         Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
         Me.MaximizeBox = False
         Me.MinimizeBox = False
         Me.Name = "CellPropertiesDialog"
         Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
         Me.Text = "Cell Properties"
         Me.groupBox1.ResumeLayout(False)
         Me.groupBox1.PerformLayout()
         Me.groupBox2.ResumeLayout(False)
         Me.groupBox2.PerformLayout()
         Me.groupBox3.ResumeLayout(False)
         Me.groupBox3.PerformLayout()
         Me.ResumeLayout(False)

      End Sub

#End Region

      Private groupBox1 As System.Windows.Forms.GroupBox
      Private groupBox2 As System.Windows.Forms.GroupBox
      Private groupBox3 As System.Windows.Forms.GroupBox
      Private _rdoApplyToSelected As System.Windows.Forms.RadioButton
      Private _rdoApplyToAll As System.Windows.Forms.RadioButton
      Private label1 As System.Windows.Forms.Label
      Private _cmbDisplayRuler As System.Windows.Forms.ComboBox
      Private _chkFitImage As System.Windows.Forms.CheckBox
      Private _chkShowTags As System.Windows.Forms.CheckBox
      Private _chkApplyOnMove As System.Windows.Forms.CheckBox
      Private _chkApplyWLToAll As System.Windows.Forms.CheckBox
      Private _txtColumns As NumericTextBox
      Private _txtRows As NumericTextBox
      Private label3 As System.Windows.Forms.Label
      Private label2 As System.Windows.Forms.Label
      Private WithEvents _btnApply As System.Windows.Forms.Button
      Private _btnCancel As System.Windows.Forms.Button
      Private WithEvents _btnOK As System.Windows.Forms.Button
      Private _chkSnapRulers As System.Windows.Forms.CheckBox
      Private _chkDisableControlPoints As System.Windows.Forms.CheckBox
   End Class
End Namespace
