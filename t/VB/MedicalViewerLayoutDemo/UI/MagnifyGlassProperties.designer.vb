Imports Microsoft.VisualBasic
Imports System
Namespace MedicalViewerLayoutDemo
   Public Partial Class MagnifyGlassProperties
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
		 Me._btnApply = New System.Windows.Forms.Button()
		 Me._btnCancel = New System.Windows.Forms.Button()
		 Me._btnOK = New System.Windows.Forms.Button()
		 Me.groupBox1 = New System.Windows.Forms.GroupBox()
		 Me._cmbCrosshair = New System.Windows.Forms.ComboBox()
		 Me._chk3D = New System.Windows.Forms.CheckBox()
		 Me._chkElliptical = New System.Windows.Forms.CheckBox()
		 Me._lblPenColor = New System.Windows.Forms.Label()
		 Me._btnPenColor = New System.Windows.Forms.Button()
		 Me._txtBorder = New MedicalViewerLayoutDemo.NumericTextBox()
		 Me._txtZoom = New MedicalViewerLayoutDemo.NumericTextBox()
		 Me._txtHeight = New MedicalViewerLayoutDemo.NumericTextBox()
		 Me._txtWidth = New MedicalViewerLayoutDemo.NumericTextBox()
		 Me.label5 = New System.Windows.Forms.Label()
		 Me.label4 = New System.Windows.Forms.Label()
		 Me.label3 = New System.Windows.Forms.Label()
		 Me.label2 = New System.Windows.Forms.Label()
		 Me.label1 = New System.Windows.Forms.Label()
		 Me.groupBox1.SuspendLayout()
		 Me.SuspendLayout()
		 ' 
		 ' _btnApply
		 ' 
		 Me._btnApply.Location = New System.Drawing.Point(199, 157)
		 Me._btnApply.Name = "_btnApply"
		 Me._btnApply.Size = New System.Drawing.Size(69, 29)
		 Me._btnApply.TabIndex = 17
		 Me._btnApply.Text = "App&ly"
		 Me._btnApply.UseVisualStyleBackColor = True
'		 Me._btnApply.Click += New System.EventHandler(Me._btnApply_Click);
		 ' 
		 ' _btnCancel
		 ' 
		 Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
		 Me._btnCancel.Location = New System.Drawing.Point(111, 157)
		 Me._btnCancel.Name = "_btnCancel"
		 Me._btnCancel.Size = New System.Drawing.Size(69, 29)
		 Me._btnCancel.TabIndex = 16
		 Me._btnCancel.Text = "Canc&el"
		 Me._btnCancel.UseVisualStyleBackColor = True
		 ' 
		 ' _btnOK
		 ' 
		 Me._btnOK.Location = New System.Drawing.Point(26, 157)
		 Me._btnOK.Name = "_btnOK"
		 Me._btnOK.Size = New System.Drawing.Size(69, 29)
		 Me._btnOK.TabIndex = 15
		 Me._btnOK.Text = "&OK"
		 Me._btnOK.UseVisualStyleBackColor = True
'		 Me._btnOK.Click += New System.EventHandler(Me._btnOK_Click);
		 ' 
		 ' groupBox1
		 ' 
		 Me.groupBox1.Controls.Add(Me._cmbCrosshair)
		 Me.groupBox1.Controls.Add(Me._chk3D)
		 Me.groupBox1.Controls.Add(Me._chkElliptical)
		 Me.groupBox1.Controls.Add(Me._lblPenColor)
		 Me.groupBox1.Controls.Add(Me._btnPenColor)
		 Me.groupBox1.Controls.Add(Me._txtBorder)
		 Me.groupBox1.Controls.Add(Me._txtZoom)
		 Me.groupBox1.Controls.Add(Me._txtHeight)
		 Me.groupBox1.Controls.Add(Me._txtWidth)
		 Me.groupBox1.Controls.Add(Me.label5)
		 Me.groupBox1.Controls.Add(Me.label4)
		 Me.groupBox1.Controls.Add(Me.label3)
		 Me.groupBox1.Controls.Add(Me.label2)
		 Me.groupBox1.Controls.Add(Me.label1)
		 Me.groupBox1.Location = New System.Drawing.Point(12, 5)
		 Me.groupBox1.Name = "groupBox1"
		 Me.groupBox1.Size = New System.Drawing.Size(272, 146)
		 Me.groupBox1.TabIndex = 18
		 Me.groupBox1.TabStop = False
		 Me.groupBox1.Text = "P&roperties"
		 ' 
		 ' _cmbCrosshair
		 ' 
		 Me._cmbCrosshair.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		 Me._cmbCrosshair.FormattingEnabled = True
		 Me._cmbCrosshair.Items.AddRange(New Object() { "None", "Fine", "Invert Pen", "Invert Screen"})
		 Me._cmbCrosshair.Location = New System.Drawing.Point(175, 107)
		 Me._cmbCrosshair.Name = "_cmbCrosshair"
		 Me._cmbCrosshair.Size = New System.Drawing.Size(84, 21)
		 Me._cmbCrosshair.TabIndex = 28
		 ' 
		 ' _chk3D
		 ' 
		 Me._chk3D.AutoSize = True
		 Me._chk3D.Location = New System.Drawing.Point(119, 86)
		 Me._chk3D.Name = "_chk3D"
		 Me._chk3D.Size = New System.Drawing.Size(40, 17)
		 Me._chk3D.TabIndex = 27
		 Me._chk3D.Text = "&3D"
		 Me._chk3D.UseVisualStyleBackColor = True
		 ' 
		 ' _chkElliptical
		 ' 
		 Me._chkElliptical.AutoSize = True
		 Me._chkElliptical.Location = New System.Drawing.Point(119, 60)
		 Me._chkElliptical.Name = "_chkElliptical"
		 Me._chkElliptical.Size = New System.Drawing.Size(93, 17)
		 Me._chkElliptical.TabIndex = 26
		 Me._chkElliptical.Text = "&Elliptical Glass"
		 Me._chkElliptical.UseVisualStyleBackColor = True
'		 Me._chkElliptical.CheckedChanged += New System.EventHandler(Me._chkElliptical_CheckedChanged);
		 ' 
		 ' _lblPenColor
		 ' 
		 Me._lblPenColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		 Me._lblPenColor.Location = New System.Drawing.Point(191, 25)
		 Me._lblPenColor.Name = "_lblPenColor"
		 Me._lblPenColor.Size = New System.Drawing.Size(49, 26)
		 Me._lblPenColor.TabIndex = 25
		 ' 
		 ' _btnPenColor
		 ' 
		 Me._btnPenColor.Location = New System.Drawing.Point(119, 25)
		 Me._btnPenColor.Name = "_btnPenColor"
		 Me._btnPenColor.Size = New System.Drawing.Size(66, 26)
		 Me._btnPenColor.TabIndex = 24
		 Me._btnPenColor.Text = "&Pen Color"
		 Me._btnPenColor.UseVisualStyleBackColor = True
'		 Me._btnPenColor.Click += New System.EventHandler(Me._btnPenColor_Click);
		 ' 
		 ' _txtBorder
		 ' 
		 Me._txtBorder.Location = New System.Drawing.Point(60, 108)
		 Me._txtBorder.MaximumAllowed = 10
		 Me._txtBorder.MinimumAllowed = 1
		 Me._txtBorder.Name = "_txtBorder"
		 Me._txtBorder.Size = New System.Drawing.Size(41, 20)
		 Me._txtBorder.TabIndex = 23
		 Me._txtBorder.Value = 0
		 ' 
		 ' _txtZoom
		 ' 
		 Me._txtZoom.Location = New System.Drawing.Point(60, 81)
		 Me._txtZoom.MaximumAllowed = 1000
		 Me._txtZoom.MinimumAllowed = 1
		 Me._txtZoom.Name = "_txtZoom"
		 Me._txtZoom.Size = New System.Drawing.Size(41, 20)
		 Me._txtZoom.TabIndex = 22
		 Me._txtZoom.Value = 0
		 ' 
		 ' _txtHeight
		 ' 
		 Me._txtHeight.Location = New System.Drawing.Point(60, 53)
		 Me._txtHeight.MaximumAllowed = 500
		 Me._txtHeight.MinimumAllowed = 1
		 Me._txtHeight.Name = "_txtHeight"
		 Me._txtHeight.Size = New System.Drawing.Size(41, 20)
		 Me._txtHeight.TabIndex = 21
		 Me._txtHeight.Value = 0
		 ' 
		 ' _txtWidth
		 ' 
		 Me._txtWidth.Location = New System.Drawing.Point(60, 26)
		 Me._txtWidth.MaximumAllowed = 500
		 Me._txtWidth.MinimumAllowed = 1
		 Me._txtWidth.Name = "_txtWidth"
		 Me._txtWidth.Size = New System.Drawing.Size(41, 20)
		 Me._txtWidth.TabIndex = 20
		 Me._txtWidth.Value = 0
		 ' 
		 ' label5
		 ' 
		 Me.label5.AutoSize = True
		 Me.label5.Location = New System.Drawing.Point(116, 110)
		 Me.label5.Name = "label5"
		 Me.label5.Size = New System.Drawing.Size(53, 13)
		 Me.label5.TabIndex = 19
		 Me.label5.Text = "Corss &hair"
		 ' 
		 ' label4
		 ' 
		 Me.label4.AutoSize = True
		 Me.label4.Location = New System.Drawing.Point(11, 111)
		 Me.label4.Name = "label4"
		 Me.label4.Size = New System.Drawing.Size(38, 13)
		 Me.label4.TabIndex = 18
		 Me.label4.Text = "&Border"
		 ' 
		 ' label3
		 ' 
		 Me.label3.AutoSize = True
		 Me.label3.Location = New System.Drawing.Point(11, 84)
		 Me.label3.Name = "label3"
		 Me.label3.Size = New System.Drawing.Size(34, 13)
		 Me.label3.TabIndex = 17
		 Me.label3.Text = "&Zoom"
		 ' 
		 ' label2
		 ' 
		 Me.label2.AutoSize = True
		 Me.label2.Location = New System.Drawing.Point(11, 56)
		 Me.label2.Name = "label2"
		 Me.label2.Size = New System.Drawing.Size(38, 13)
		 Me.label2.TabIndex = 16
		 Me.label2.Text = "&Height"
		 ' 
		 ' label1
		 ' 
		 Me.label1.AutoSize = True
		 Me.label1.Location = New System.Drawing.Point(11, 26)
		 Me.label1.Name = "label1"
		 Me.label1.Size = New System.Drawing.Size(35, 13)
		 Me.label1.TabIndex = 15
		 Me.label1.Text = "&Width"
		 ' 
		 ' MagnifyGlassProperties
		 ' 
		 Me.AcceptButton = Me._btnOK
		 Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
		 Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		 Me.CancelButton = Me._btnCancel
		 Me.ClientSize = New System.Drawing.Size(294, 195)
		 Me.Controls.Add(Me.groupBox1)
		 Me.Controls.Add(Me._btnApply)
		 Me.Controls.Add(Me._btnCancel)
		 Me.Controls.Add(Me._btnOK)
		 Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		 Me.MaximizeBox = False
		 Me.MinimizeBox = False
		 Me.Name = "MagnifyGlassProperties"
		 Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
		 Me.Text = "Magnify Glass Properties"
		 Me.groupBox1.ResumeLayout(False)
		 Me.groupBox1.PerformLayout()
		 Me.ResumeLayout(False)

	  End Sub

	  #End Region

	  Private WithEvents _btnApply As System.Windows.Forms.Button
	  Private _btnCancel As System.Windows.Forms.Button
	  Private WithEvents _btnOK As System.Windows.Forms.Button
	  Private groupBox1 As System.Windows.Forms.GroupBox
	  Private _cmbCrosshair As System.Windows.Forms.ComboBox
	  Private _chk3D As System.Windows.Forms.CheckBox
	  Private WithEvents _chkElliptical As System.Windows.Forms.CheckBox
	  Private _lblPenColor As System.Windows.Forms.Label
	  Private WithEvents _btnPenColor As System.Windows.Forms.Button
	  Private _txtBorder As NumericTextBox
	  Private _txtZoom As NumericTextBox
	  Private _txtHeight As NumericTextBox
	  Private _txtWidth As NumericTextBox
	  Private label5 As System.Windows.Forms.Label
	  Private label4 As System.Windows.Forms.Label
	  Private label3 As System.Windows.Forms.Label
	  Private label2 As System.Windows.Forms.Label
	  Private label1 As System.Windows.Forms.Label
   End Class
End Namespace