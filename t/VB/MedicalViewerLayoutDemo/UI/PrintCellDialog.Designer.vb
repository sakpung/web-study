Imports Microsoft.VisualBasic
Imports System
Namespace MedicalViewerLayoutDemo
   Public Partial Class PrintCellDialog
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
		 Me._chkTags = New System.Windows.Forms.CheckBox()
		 Me._chkRulers = New System.Windows.Forms.CheckBox()
		 Me._chkBorders = New System.Windows.Forms.CheckBox()
		 Me._chkRegion = New System.Windows.Forms.CheckBox()
		 Me._chkAnnotation = New System.Windows.Forms.CheckBox()
		 Me._chkAll = New System.Windows.Forms.CheckBox()
		 Me.groupBox2 = New System.Windows.Forms.GroupBox()
		 Me._chkPrintAll = New System.Windows.Forms.CheckBox()
		 Me._chkExploded = New System.Windows.Forms.CheckBox()
		 Me._lblIndex = New System.Windows.Forms.Label()
		 Me._btnPrint = New System.Windows.Forms.Button()
		 Me._btnSave = New System.Windows.Forms.Button()
		 Me._btnCancel = New System.Windows.Forms.Button()
		 Me._cellImage = New System.Windows.Forms.PictureBox()
		 Me._txtIndex = New MedicalViewerLayoutDemo.NumericTextBox()
		 Me.groupBox1.SuspendLayout()
		 Me.groupBox2.SuspendLayout()
		 CType(Me._cellImage, System.ComponentModel.ISupportInitialize).BeginInit()
		 Me.SuspendLayout()
		 ' 
		 ' groupBox1
		 ' 
		 Me.groupBox1.Controls.Add(Me._chkTags)
		 Me.groupBox1.Controls.Add(Me._chkRulers)
		 Me.groupBox1.Controls.Add(Me._chkBorders)
		 Me.groupBox1.Controls.Add(Me._chkRegion)
		 Me.groupBox1.Controls.Add(Me._chkAnnotation)
		 Me.groupBox1.Controls.Add(Me._chkAll)
		 Me.groupBox1.Location = New System.Drawing.Point(9, 12)
		 Me.groupBox1.Name = "groupBox1"
		 Me.groupBox1.Size = New System.Drawing.Size(140, 319)
		 Me.groupBox1.TabIndex = 3
		 Me.groupBox1.TabStop = False
		 Me.groupBox1.Text = "&Options"
		 ' 
		 ' _chkTags
		 ' 
		 Me._chkTags.AutoSize = True
		 Me._chkTags.Checked = True
		 Me._chkTags.CheckState = System.Windows.Forms.CheckState.Checked
		 Me._chkTags.Location = New System.Drawing.Point(13, 266)
		 Me._chkTags.Name = "_chkTags"
		 Me._chkTags.Size = New System.Drawing.Size(50, 17)
		 Me._chkTags.TabIndex = 11
		 Me._chkTags.Text = "&Tags"
		 Me._chkTags.UseVisualStyleBackColor = True
'		 Me._chkTags.CheckedChanged += New System.EventHandler(Me._chkTags_CheckedChanged);
		 ' 
		 ' _chkRulers
		 ' 
		 Me._chkRulers.AutoSize = True
		 Me._chkRulers.Checked = True
		 Me._chkRulers.CheckState = System.Windows.Forms.CheckState.Checked
		 Me._chkRulers.Location = New System.Drawing.Point(13, 219)
		 Me._chkRulers.Name = "_chkRulers"
		 Me._chkRulers.Size = New System.Drawing.Size(56, 17)
		 Me._chkRulers.TabIndex = 10
		 Me._chkRulers.Text = "&Rulers"
		 Me._chkRulers.UseVisualStyleBackColor = True
'		 Me._chkRulers.CheckedChanged += New System.EventHandler(Me._chkRulers_CheckedChanged);
		 ' 
		 ' _chkBorders
		 ' 
		 Me._chkBorders.AutoSize = True
		 Me._chkBorders.Checked = True
		 Me._chkBorders.CheckState = System.Windows.Forms.CheckState.Checked
		 Me._chkBorders.Location = New System.Drawing.Point(13, 172)
		 Me._chkBorders.Name = "_chkBorders"
		 Me._chkBorders.Size = New System.Drawing.Size(62, 17)
		 Me._chkBorders.TabIndex = 9
		 Me._chkBorders.Text = "&Borders"
		 Me._chkBorders.UseVisualStyleBackColor = True
'		 Me._chkBorders.CheckedChanged += New System.EventHandler(Me._chkBorders_CheckedChanged);
		 ' 
		 ' _chkRegion
		 ' 
		 Me._chkRegion.AutoSize = True
		 Me._chkRegion.Checked = True
		 Me._chkRegion.CheckState = System.Windows.Forms.CheckState.Checked
		 Me._chkRegion.Location = New System.Drawing.Point(13, 125)
		 Me._chkRegion.Name = "_chkRegion"
		 Me._chkRegion.Size = New System.Drawing.Size(65, 17)
		 Me._chkRegion.TabIndex = 8
		 Me._chkRegion.Text = "&Regions"
		 Me._chkRegion.UseVisualStyleBackColor = True
'		 Me._chkRegion.CheckedChanged += New System.EventHandler(Me._chkRegion_CheckedChanged);
		 ' 
		 ' _chkAnnotation
		 ' 
		 Me._chkAnnotation.AutoSize = True
		 Me._chkAnnotation.Checked = True
		 Me._chkAnnotation.CheckState = System.Windows.Forms.CheckState.Checked
		 Me._chkAnnotation.Location = New System.Drawing.Point(13, 78)
		 Me._chkAnnotation.Name = "_chkAnnotation"
		 Me._chkAnnotation.Size = New System.Drawing.Size(77, 17)
		 Me._chkAnnotation.TabIndex = 7
		 Me._chkAnnotation.Text = "&Annotation"
		 Me._chkAnnotation.UseVisualStyleBackColor = True
'		 Me._chkAnnotation.CheckedChanged += New System.EventHandler(Me._chkAnnotation_CheckedChanged);
		 ' 
		 ' _chkAll
		 ' 
		 Me._chkAll.AutoSize = True
		 Me._chkAll.Location = New System.Drawing.Point(13, 31)
		 Me._chkAll.Name = "_chkAll"
		 Me._chkAll.Size = New System.Drawing.Size(37, 17)
		 Me._chkAll.TabIndex = 6
		 Me._chkAll.Text = "&All"
		 Me._chkAll.UseVisualStyleBackColor = True
'		 Me._chkAll.CheckedChanged += New System.EventHandler(Me._chkAll_CheckedChanged);
		 ' 
		 ' groupBox2
		 ' 
		 Me.groupBox2.BackColor = System.Drawing.Color.Transparent
		 Me.groupBox2.Controls.Add(Me._chkPrintAll)
		 Me.groupBox2.Controls.Add(Me._txtIndex)
		 Me.groupBox2.Controls.Add(Me._chkExploded)
		 Me.groupBox2.Controls.Add(Me._lblIndex)
		 Me.groupBox2.Location = New System.Drawing.Point(9, 337)
		 Me.groupBox2.Name = "groupBox2"
		 Me.groupBox2.Size = New System.Drawing.Size(140, 121)
		 Me.groupBox2.TabIndex = 4
		 Me.groupBox2.TabStop = False
		 Me.groupBox2.Text = "&Additional Options"
		 ' 
		 ' _chkPrintAll
		 ' 
		 Me._chkPrintAll.AutoSize = True
		 Me._chkPrintAll.Location = New System.Drawing.Point(13, 20)
		 Me._chkPrintAll.Name = "_chkPrintAll"
		 Me._chkPrintAll.Size = New System.Drawing.Size(105, 17)
		 Me._chkPrintAll.TabIndex = 9
		 Me._chkPrintAll.Text = "&Print All sub-cells"
		 Me._chkPrintAll.UseVisualStyleBackColor = True
'		 Me._chkPrintAll.CheckedChanged += New System.EventHandler(Me._chkPrintAll_CheckedChanged);
		 ' 
		 ' _chkExploded
		 ' 
		 Me._chkExploded.AutoSize = True
		 Me._chkExploded.Location = New System.Drawing.Point(13, 98)
		 Me._chkExploded.Name = "_chkExploded"
		 Me._chkExploded.Size = New System.Drawing.Size(70, 17)
		 Me._chkExploded.TabIndex = 7
		 Me._chkExploded.Text = "&Exploded"
		 Me._chkExploded.UseVisualStyleBackColor = True
'		 Me._chkExploded.CheckedChanged += New System.EventHandler(Me._chkExploded_CheckedChanged);
		 ' 
		 ' _lblIndex
		 ' 
		 Me._lblIndex.AutoSize = True
		 Me._lblIndex.Location = New System.Drawing.Point(21, 65)
		 Me._lblIndex.Name = "_lblIndex"
		 Me._lblIndex.Size = New System.Drawing.Size(33, 13)
		 Me._lblIndex.TabIndex = 6
		 Me._lblIndex.Text = "&Index"
		 ' 
		 ' _btnPrint
		 ' 
		 Me._btnPrint.DialogResult = System.Windows.Forms.DialogResult.Cancel
		 Me._btnPrint.Location = New System.Drawing.Point(169, 473)
		 Me._btnPrint.Name = "_btnPrint"
		 Me._btnPrint.Size = New System.Drawing.Size(70, 29)
		 Me._btnPrint.TabIndex = 6
		 Me._btnPrint.Text = "&Print"
		 Me._btnPrint.UseVisualStyleBackColor = True
'		 Me._btnPrint.Click += New System.EventHandler(Me._btnPrint_Click);
		 ' 
		 ' _btnSave
		 ' 
		 Me._btnSave.DialogResult = System.Windows.Forms.DialogResult.Cancel
		 Me._btnSave.Location = New System.Drawing.Point(245, 473)
		 Me._btnSave.Name = "_btnSave"
		 Me._btnSave.Size = New System.Drawing.Size(70, 29)
		 Me._btnSave.TabIndex = 7
		 Me._btnSave.Text = "&Save"
		 Me._btnSave.UseVisualStyleBackColor = True
'		 Me._btnSave.Click += New System.EventHandler(Me._btnSave_Click);
		 ' 
		 ' _btnCancel
		 ' 
		 Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
		 Me._btnCancel.Location = New System.Drawing.Point(322, 473)
		 Me._btnCancel.Name = "_btnCancel"
		 Me._btnCancel.Size = New System.Drawing.Size(70, 29)
		 Me._btnCancel.TabIndex = 8
		 Me._btnCancel.Text = "&Cancel"
		 Me._btnCancel.UseVisualStyleBackColor = True
		 ' 
		 ' _cellImage
		 ' 
		 Me._cellImage.Location = New System.Drawing.Point(155, 14)
		 Me._cellImage.Name = "_cellImage"
		 Me._cellImage.Size = New System.Drawing.Size(437, 444)
		 Me._cellImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
		 Me._cellImage.TabIndex = 9
		 Me._cellImage.TabStop = False
		 ' 
		 ' _txtIndex
		 ' 
		 Me._txtIndex.Location = New System.Drawing.Point(78, 62)
		 Me._txtIndex.MaximumAllowed = 10000
		 Me._txtIndex.MaxLength = 3
		 Me._txtIndex.MinimumAllowed = 1
		 Me._txtIndex.Name = "_txtIndex"
		 Me._txtIndex.Size = New System.Drawing.Size(40, 20)
		 Me._txtIndex.TabIndex = 8
		 Me._txtIndex.Text = "1"
		 Me._txtIndex.Value = 1
'		 Me._txtIndex.TextChanged += New System.EventHandler(Me._txtIndex_TextChanged);
		 ' 
		 ' PrintCellDialog
		 ' 
		 Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
		 Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		 Me.CancelButton = Me._btnCancel
		 Me.ClientSize = New System.Drawing.Size(604, 513)
		 Me.Controls.Add(Me._cellImage)
		 Me.Controls.Add(Me._btnCancel)
		 Me.Controls.Add(Me._btnSave)
		 Me.Controls.Add(Me._btnPrint)
		 Me.Controls.Add(Me.groupBox2)
		 Me.Controls.Add(Me.groupBox1)
		 Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		 Me.MaximizeBox = False
		 Me.MinimizeBox = False
		 Me.Name = "PrintCellDialog"
		 Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
		 Me.Text = "Print Cell Dialog"
		 Me.groupBox1.ResumeLayout(False)
		 Me.groupBox1.PerformLayout()
		 Me.groupBox2.ResumeLayout(False)
		 Me.groupBox2.PerformLayout()
		 CType(Me._cellImage, System.ComponentModel.ISupportInitialize).EndInit()
		 Me.ResumeLayout(False)

	  End Sub

	  #End Region

	  Private groupBox1 As System.Windows.Forms.GroupBox
	  Private groupBox2 As System.Windows.Forms.GroupBox
	  Private WithEvents _btnPrint As System.Windows.Forms.Button
	  Private WithEvents _btnSave As System.Windows.Forms.Button
	  Private _btnCancel As System.Windows.Forms.Button
	  Private WithEvents _chkTags As System.Windows.Forms.CheckBox
	  Private WithEvents _chkRulers As System.Windows.Forms.CheckBox
	  Private WithEvents _chkBorders As System.Windows.Forms.CheckBox
	  Private WithEvents _chkRegion As System.Windows.Forms.CheckBox
	  Private WithEvents _chkAnnotation As System.Windows.Forms.CheckBox
	  Private WithEvents _chkAll As System.Windows.Forms.CheckBox
	  Private WithEvents _chkPrintAll As System.Windows.Forms.CheckBox
	  Private WithEvents _txtIndex As NumericTextBox
	  Private WithEvents _chkExploded As System.Windows.Forms.CheckBox
	  Private _lblIndex As System.Windows.Forms.Label
	  Private _cellImage As System.Windows.Forms.PictureBox
   End Class
End Namespace