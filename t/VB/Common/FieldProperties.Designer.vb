Imports Microsoft.VisualBasic
Imports System
Namespace FormsDemo
   Public Partial Class FieldProperties
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
		 Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FieldProperties))
		 Me._chkEnableOcr = New System.Windows.Forms.CheckBox()
		 Me._chkEnableIcr = New System.Windows.Forms.CheckBox()
		 Me._btnCancel = New System.Windows.Forms.Button()
		 Me._btnOk = New System.Windows.Forms.Button()
		 Me._methodGroup = New System.Windows.Forms.GroupBox()
		 Me._typeGroup = New System.Windows.Forms.GroupBox()
		 Me._radioTextNumerical = New System.Windows.Forms.RadioButton()
		 Me._radioTextCharacter = New System.Windows.Forms.RadioButton()
		 Me.label1 = New System.Windows.Forms.Label()
		 Me._txtName = New System.Windows.Forms.TextBox()
		 Me.label2 = New System.Windows.Forms.Label()
		 Me._cmbType = New System.Windows.Forms.ComboBox()
		 Me._boundsGroup = New System.Windows.Forms.GroupBox()
		 Me._txtHeight = New System.Windows.Forms.TextBox()
		 Me._txtWidth = New System.Windows.Forms.TextBox()
		 Me.label6 = New System.Windows.Forms.Label()
		 Me._txtTop = New System.Windows.Forms.TextBox()
		 Me.label5 = New System.Windows.Forms.Label()
		 Me._txtLeft = New System.Windows.Forms.TextBox()
		 Me.label4 = New System.Windows.Forms.Label()
		 Me.label3 = New System.Windows.Forms.Label()
		 Me._methodGroup.SuspendLayout()
		 Me._typeGroup.SuspendLayout()
		 Me._boundsGroup.SuspendLayout()
		 Me.SuspendLayout()
		 ' 
		 ' _chkEnableOcr
		 ' 
		 Me._chkEnableOcr.AutoSize = True
		 Me._chkEnableOcr.Checked = True
		 Me._chkEnableOcr.CheckState = System.Windows.Forms.CheckState.Checked
		 Me._chkEnableOcr.Location = New System.Drawing.Point(10, 19)
		 Me._chkEnableOcr.Name = "_chkEnableOcr"
		 Me._chkEnableOcr.Size = New System.Drawing.Size(85, 17)
		 Me._chkEnableOcr.TabIndex = 6
		 Me._chkEnableOcr.Text = "Enable OCR"
		 Me._chkEnableOcr.UseVisualStyleBackColor = True
		 ' 
		 ' _chkEnableIcr
		 ' 
		 Me._chkEnableIcr.AutoSize = True
		 Me._chkEnableIcr.Checked = True
		 Me._chkEnableIcr.CheckState = System.Windows.Forms.CheckState.Checked
		 Me._chkEnableIcr.Location = New System.Drawing.Point(10, 42)
		 Me._chkEnableIcr.Name = "_chkEnableIcr"
		 Me._chkEnableIcr.Size = New System.Drawing.Size(80, 17)
		 Me._chkEnableIcr.TabIndex = 7
		 Me._chkEnableIcr.Text = "Enable ICR"
		 Me._chkEnableIcr.TextAlign = System.Drawing.ContentAlignment.TopLeft
		 Me._chkEnableIcr.UseVisualStyleBackColor = True
		 ' 
		 ' _btnCancel
		 ' 
		 Me._btnCancel.Location = New System.Drawing.Point(128, 208)
		 Me._btnCancel.Name = "_btnCancel"
		 Me._btnCancel.Size = New System.Drawing.Size(50, 26)
		 Me._btnCancel.TabIndex = 11
		 Me._btnCancel.Text = "Cancel"
		 Me._btnCancel.UseVisualStyleBackColor = True
'		 Me._btnCancel.Click += New System.EventHandler(Me._btnCancel_Click);
		 ' 
		 ' _btnOk
		 ' 
		 Me._btnOk.Location = New System.Drawing.Point(61, 208)
		 Me._btnOk.Name = "_btnOk"
		 Me._btnOk.Size = New System.Drawing.Size(50, 26)
		 Me._btnOk.TabIndex = 10
		 Me._btnOk.Text = "OK"
		 Me._btnOk.UseVisualStyleBackColor = True
'		 Me._btnOk.Click += New System.EventHandler(Me._btnOk_Click);
		 ' 
		 ' _methodGroup
		 ' 
		 Me._methodGroup.Controls.Add(Me._chkEnableIcr)
		 Me._methodGroup.Controls.Add(Me._chkEnableOcr)
		 Me._methodGroup.Location = New System.Drawing.Point(21, 131)
		 Me._methodGroup.Name = "_methodGroup"
		 Me._methodGroup.Size = New System.Drawing.Size(101, 72)
		 Me._methodGroup.TabIndex = 4
		 Me._methodGroup.TabStop = False
		 Me._methodGroup.Text = "Method"
		 ' 
		 ' _typeGroup
		 ' 
		 Me._typeGroup.Controls.Add(Me._radioTextNumerical)
		 Me._typeGroup.Controls.Add(Me._radioTextCharacter)
		 Me._typeGroup.Location = New System.Drawing.Point(128, 131)
		 Me._typeGroup.Name = "_typeGroup"
		 Me._typeGroup.Size = New System.Drawing.Size(93, 72)
		 Me._typeGroup.TabIndex = 5
		 Me._typeGroup.TabStop = False
		 Me._typeGroup.Text = "Type"
		 ' 
		 ' _radioTextNumerical
		 ' 
		 Me._radioTextNumerical.AutoSize = True
		 Me._radioTextNumerical.Location = New System.Drawing.Point(10, 45)
		 Me._radioTextNumerical.Name = "_radioTextNumerical"
		 Me._radioTextNumerical.Size = New System.Drawing.Size(72, 17)
		 Me._radioTextNumerical.TabIndex = 9
		 Me._radioTextNumerical.TabStop = True
		 Me._radioTextNumerical.Text = "Numerical"
		 Me._radioTextNumerical.UseVisualStyleBackColor = True
		 ' 
		 ' _radioTextCharacter
		 ' 
		 Me._radioTextCharacter.AutoSize = True
		 Me._radioTextCharacter.Location = New System.Drawing.Point(10, 19)
		 Me._radioTextCharacter.Name = "_radioTextCharacter"
		 Me._radioTextCharacter.Size = New System.Drawing.Size(71, 17)
		 Me._radioTextCharacter.TabIndex = 8
		 Me._radioTextCharacter.TabStop = True
		 Me._radioTextCharacter.Text = "Character"
		 Me._radioTextCharacter.UseVisualStyleBackColor = True
		 ' 
		 ' label1
		 ' 
		 Me.label1.AutoSize = True
		 Me.label1.Location = New System.Drawing.Point(28, 9)
		 Me.label1.Name = "label1"
		 Me.label1.Size = New System.Drawing.Size(35, 13)
		 Me.label1.TabIndex = 6
		 Me.label1.Text = "Name"
		 ' 
		 ' _txtName
		 ' 
		 Me._txtName.Location = New System.Drawing.Point(69, 6)
		 Me._txtName.Name = "_txtName"
		 Me._txtName.Size = New System.Drawing.Size(141, 20)
		 Me._txtName.TabIndex = 0
		 ' 
		 ' label2
		 ' 
		 Me.label2.AutoSize = True
		 Me.label2.Location = New System.Drawing.Point(28, 35)
		 Me.label2.Name = "label2"
		 Me.label2.Size = New System.Drawing.Size(31, 13)
		 Me.label2.TabIndex = 8
		 Me.label2.Text = "Type"
		 ' 
		 ' _cmbType
		 ' 
		 Me._cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		 Me._cmbType.FormattingEnabled = True
		 Me._cmbType.Items.AddRange(New Object() { "Text", "Omr", "Barcode", "Image"})
		 Me._cmbType.Location = New System.Drawing.Point(69, 32)
		 Me._cmbType.Name = "_cmbType"
		 Me._cmbType.Size = New System.Drawing.Size(140, 21)
		 Me._cmbType.TabIndex = 1
'		 Me._cmbType.SelectedIndexChanged += New System.EventHandler(Me._cmbType_SelectedIndexChanged);
		 ' 
		 ' _boundsGroup
		 ' 
		 Me._boundsGroup.Controls.Add(Me._txtHeight)
		 Me._boundsGroup.Controls.Add(Me._txtWidth)
		 Me._boundsGroup.Controls.Add(Me.label6)
		 Me._boundsGroup.Controls.Add(Me._txtTop)
		 Me._boundsGroup.Controls.Add(Me.label5)
		 Me._boundsGroup.Controls.Add(Me._txtLeft)
		 Me._boundsGroup.Controls.Add(Me.label4)
		 Me._boundsGroup.Controls.Add(Me.label3)
		 Me._boundsGroup.Location = New System.Drawing.Point(21, 59)
		 Me._boundsGroup.Name = "_boundsGroup"
		 Me._boundsGroup.Size = New System.Drawing.Size(200, 66)
		 Me._boundsGroup.TabIndex = 10
		 Me._boundsGroup.TabStop = False
		 Me._boundsGroup.Text = "Bounds"
		 ' 
		 ' _txtHeight
		 ' 
		 Me._txtHeight.Location = New System.Drawing.Point(145, 38)
		 Me._txtHeight.Name = "_txtHeight"
		 Me._txtHeight.ReadOnly = True
		 Me._txtHeight.Size = New System.Drawing.Size(47, 20)
		 Me._txtHeight.TabIndex = 5
		 ' 
		 ' _txtWidth
		 ' 
		 Me._txtWidth.Location = New System.Drawing.Point(145, 13)
		 Me._txtWidth.Name = "_txtWidth"
		 Me._txtWidth.ReadOnly = True
		 Me._txtWidth.Size = New System.Drawing.Size(47, 20)
		 Me._txtWidth.TabIndex = 3
		 ' 
		 ' label6
		 ' 
		 Me.label6.AutoSize = True
		 Me.label6.Location = New System.Drawing.Point(104, 41)
		 Me.label6.Name = "label6"
		 Me.label6.Size = New System.Drawing.Size(38, 13)
		 Me.label6.TabIndex = 12
		 Me.label6.Text = "Height"
		 ' 
		 ' _txtTop
		 ' 
		 Me._txtTop.Location = New System.Drawing.Point(48, 38)
		 Me._txtTop.Name = "_txtTop"
		 Me._txtTop.ReadOnly = True
		 Me._txtTop.Size = New System.Drawing.Size(47, 20)
		 Me._txtTop.TabIndex = 4
		 ' 
		 ' label5
		 ' 
		 Me.label5.AutoSize = True
		 Me.label5.Location = New System.Drawing.Point(104, 16)
		 Me.label5.Name = "label5"
		 Me.label5.Size = New System.Drawing.Size(35, 13)
		 Me.label5.TabIndex = 10
		 Me.label5.Text = "Width"
		 ' 
		 ' _txtLeft
		 ' 
		 Me._txtLeft.Location = New System.Drawing.Point(48, 13)
		 Me._txtLeft.Name = "_txtLeft"
		 Me._txtLeft.ReadOnly = True
		 Me._txtLeft.Size = New System.Drawing.Size(47, 20)
		 Me._txtLeft.TabIndex = 2
		 ' 
		 ' label4
		 ' 
		 Me.label4.AutoSize = True
		 Me.label4.Location = New System.Drawing.Point(7, 41)
		 Me.label4.Name = "label4"
		 Me.label4.Size = New System.Drawing.Size(26, 13)
		 Me.label4.TabIndex = 8
		 Me.label4.Text = "Top"
		 ' 
		 ' label3
		 ' 
		 Me.label3.AutoSize = True
		 Me.label3.Location = New System.Drawing.Point(7, 16)
		 Me.label3.Name = "label3"
		 Me.label3.Size = New System.Drawing.Size(25, 13)
		 Me.label3.TabIndex = 7
		 Me.label3.Text = "Left"
		 ' 
		 ' FieldProperties
		 ' 
		 Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
		 Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		 Me.ClientSize = New System.Drawing.Size(236, 242)
		 Me.Controls.Add(Me._boundsGroup)
		 Me.Controls.Add(Me._cmbType)
		 Me.Controls.Add(Me.label2)
		 Me.Controls.Add(Me._txtName)
		 Me.Controls.Add(Me.label1)
		 Me.Controls.Add(Me._typeGroup)
		 Me.Controls.Add(Me._methodGroup)
		 Me.Controls.Add(Me._btnOk)
		 Me.Controls.Add(Me._btnCancel)
		 Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		 Me.Icon = (CType(resources.GetObject("$this.Icon"), System.Drawing.Icon))
		 Me.MaximizeBox = False
		 Me.MinimizeBox = False
		 Me.Name = "FieldProperties"
		 Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
		 Me.Text = "Field Properties"
		 Me._methodGroup.ResumeLayout(False)
		 Me._methodGroup.PerformLayout()
		 Me._typeGroup.ResumeLayout(False)
		 Me._typeGroup.PerformLayout()
		 Me._boundsGroup.ResumeLayout(False)
		 Me._boundsGroup.PerformLayout()
		 Me.ResumeLayout(False)
		 Me.PerformLayout()

	  End Sub

	  #End Region

	  Private _chkEnableOcr As System.Windows.Forms.CheckBox
	  Private _chkEnableIcr As System.Windows.Forms.CheckBox
	  Private WithEvents _btnCancel As System.Windows.Forms.Button
	  Private WithEvents _btnOk As System.Windows.Forms.Button
	  Private _methodGroup As System.Windows.Forms.GroupBox
	  Private _typeGroup As System.Windows.Forms.GroupBox
	  Private _radioTextNumerical As System.Windows.Forms.RadioButton
	  Private _radioTextCharacter As System.Windows.Forms.RadioButton
	  Private label1 As System.Windows.Forms.Label
	  Private _txtName As System.Windows.Forms.TextBox
	  Private label2 As System.Windows.Forms.Label
	  Private WithEvents _cmbType As System.Windows.Forms.ComboBox
	  Private _boundsGroup As System.Windows.Forms.GroupBox
	  Private _txtLeft As System.Windows.Forms.TextBox
	  Private label4 As System.Windows.Forms.Label
	  Private label3 As System.Windows.Forms.Label
	  Private _txtHeight As System.Windows.Forms.TextBox
	  Private _txtWidth As System.Windows.Forms.TextBox
	  Private label6 As System.Windows.Forms.Label
	  Private _txtTop As System.Windows.Forms.TextBox
	  Private label5 As System.Windows.Forms.Label
   End Class
End Namespace