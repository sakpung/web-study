Imports Microsoft.VisualBasic
Imports System
Namespace MPPSWCFDemo.UI
   Public Partial Class PatientForm
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
		 Me.components = New System.ComponentModel.Container()
		 Me.textBoxComments = New System.Windows.Forms.TextBox()
		 Me.label10 = New System.Windows.Forms.Label()
		 Me.textBoxSpecialNeeds = New System.Windows.Forms.TextBox()
		 Me.label9 = New System.Windows.Forms.Label()
		 Me.comboBoxSex = New System.Windows.Forms.ComboBox()
		 Me.label8 = New System.Windows.Forms.Label()
		 Me.dateTimePickerBirth = New System.Windows.Forms.DateTimePicker()
		 Me.label7 = New System.Windows.Forms.Label()
		 Me.groupBoxName = New System.Windows.Forms.GroupBox()
		 Me.textBoxSuffix = New System.Windows.Forms.TextBox()
		 Me.label6 = New System.Windows.Forms.Label()
		 Me.textBoxFamily = New System.Windows.Forms.TextBox()
		 Me.label5 = New System.Windows.Forms.Label()
		 Me.textBoxGiven = New System.Windows.Forms.TextBox()
		 Me.label3 = New System.Windows.Forms.Label()
		 Me.textBoxPrefix = New System.Windows.Forms.TextBox()
		 Me.label4 = New System.Windows.Forms.Label()
		 Me.textBoxIssuerOfPatientId = New System.Windows.Forms.TextBox()
		 Me.label2 = New System.Windows.Forms.Label()
		 Me.label1 = New System.Windows.Forms.Label()
		 Me.buttonCancel = New System.Windows.Forms.Button()
		 Me.buttonOK = New System.Windows.Forms.Button()
		 Me.textBoxPatientId = New System.Windows.Forms.TextBox()
		 Me.errorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
		 Me.groupBoxName.SuspendLayout()
		 CType(Me.errorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
		 Me.SuspendLayout()
		 ' 
		 ' textBoxComments
		 ' 
		 Me.textBoxComments.Location = New System.Drawing.Point(15, 183)
		 Me.textBoxComments.Multiline = True
		 Me.textBoxComments.Name = "textBoxComments"
		 Me.textBoxComments.Size = New System.Drawing.Size(524, 80)
		 Me.textBoxComments.TabIndex = 27
		 ' 
		 ' label10
		 ' 
		 Me.label10.AutoSize = True
		 Me.label10.Location = New System.Drawing.Point(12, 167)
		 Me.label10.Name = "label10"
		 Me.label10.Size = New System.Drawing.Size(59, 13)
		 Me.label10.TabIndex = 28
		 Me.label10.Text = "Comments:"
		 ' 
		 ' textBoxSpecialNeeds
		 ' 
		 Me.textBoxSpecialNeeds.Location = New System.Drawing.Point(277, 144)
		 Me.textBoxSpecialNeeds.Name = "textBoxSpecialNeeds"
		 Me.textBoxSpecialNeeds.Size = New System.Drawing.Size(259, 20)
		 Me.textBoxSpecialNeeds.TabIndex = 26
		 ' 
		 ' label9
		 ' 
		 Me.label9.AutoSize = True
		 Me.label9.Location = New System.Drawing.Point(277, 127)
		 Me.label9.Name = "label9"
		 Me.label9.Size = New System.Drawing.Size(79, 13)
		 Me.label9.TabIndex = 23
		 Me.label9.Text = "Special Needs:"
		 ' 
		 ' comboBoxSex
		 ' 
		 Me.comboBoxSex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		 Me.comboBoxSex.FormattingEnabled = True
		 Me.comboBoxSex.Items.AddRange(New Object() { "M", "F", "O"})
		 Me.comboBoxSex.Location = New System.Drawing.Point(153, 143)
		 Me.comboBoxSex.Name = "comboBoxSex"
		 Me.comboBoxSex.Size = New System.Drawing.Size(121, 21)
		 Me.comboBoxSex.TabIndex = 25
		 Me.comboBoxSex.Tag = "required"
		 ' 
		 ' label8
		 ' 
		 Me.label8.AutoSize = True
		 Me.label8.Location = New System.Drawing.Point(150, 127)
		 Me.label8.Name = "label8"
		 Me.label8.Size = New System.Drawing.Size(28, 13)
		 Me.label8.TabIndex = 21
		 Me.label8.Text = "Sex:"
		 ' 
		 ' dateTimePickerBirth
		 ' 
		 Me.dateTimePickerBirth.Format = System.Windows.Forms.DateTimePickerFormat.Short
		 Me.dateTimePickerBirth.Location = New System.Drawing.Point(15, 144)
		 Me.dateTimePickerBirth.Name = "dateTimePickerBirth"
		 Me.dateTimePickerBirth.ShowCheckBox = True
		 Me.dateTimePickerBirth.Size = New System.Drawing.Size(132, 20)
		 Me.dateTimePickerBirth.TabIndex = 24
		 ' 
		 ' label7
		 ' 
		 Me.label7.AutoSize = True
		 Me.label7.Location = New System.Drawing.Point(12, 128)
		 Me.label7.Name = "label7"
		 Me.label7.Size = New System.Drawing.Size(52, 13)
		 Me.label7.TabIndex = 20
		 Me.label7.Text = "Birthdate:"
		 ' 
		 ' groupBoxName
		 ' 
		 Me.groupBoxName.BackColor = System.Drawing.SystemColors.Control
		 Me.groupBoxName.Controls.Add(Me.textBoxSuffix)
		 Me.groupBoxName.Controls.Add(Me.label6)
		 Me.groupBoxName.Controls.Add(Me.textBoxFamily)
		 Me.groupBoxName.Controls.Add(Me.label5)
		 Me.groupBoxName.Controls.Add(Me.textBoxGiven)
		 Me.groupBoxName.Controls.Add(Me.label3)
		 Me.groupBoxName.Controls.Add(Me.textBoxPrefix)
		 Me.groupBoxName.Controls.Add(Me.label4)
		 Me.groupBoxName.Location = New System.Drawing.Point(15, 52)
		 Me.groupBoxName.Name = "groupBoxName"
		 Me.groupBoxName.Size = New System.Drawing.Size(524, 73)
		 Me.groupBoxName.TabIndex = 19
		 Me.groupBoxName.TabStop = False
		 Me.groupBoxName.Tag = "Required"
		 Me.groupBoxName.Text = "Name"
		 ' 
		 ' textBoxSuffix
		 ' 
		 Me.textBoxSuffix.Location = New System.Drawing.Point(447, 42)
		 Me.textBoxSuffix.Name = "textBoxSuffix"
		 Me.textBoxSuffix.Size = New System.Drawing.Size(74, 20)
		 Me.textBoxSuffix.TabIndex = 7
		 ' 
		 ' label6
		 ' 
		 Me.label6.AutoSize = True
		 Me.label6.Location = New System.Drawing.Point(444, 26)
		 Me.label6.Name = "label6"
		 Me.label6.Size = New System.Drawing.Size(36, 13)
		 Me.label6.TabIndex = 3
		 Me.label6.Text = "Suffix:"
		 ' 
		 ' textBoxFamily
		 ' 
		 Me.textBoxFamily.BackColor = System.Drawing.SystemColors.Window
		 Me.textBoxFamily.Location = New System.Drawing.Point(265, 42)
		 Me.textBoxFamily.Name = "textBoxFamily"
		 Me.textBoxFamily.Size = New System.Drawing.Size(180, 20)
		 Me.textBoxFamily.TabIndex = 6
		 ' 
		 ' label5
		 ' 
		 Me.label5.AutoSize = True
		 Me.label5.Location = New System.Drawing.Point(262, 26)
		 Me.label5.Name = "label5"
		 Me.label5.Size = New System.Drawing.Size(39, 13)
		 Me.label5.TabIndex = 2
		 Me.label5.Text = "Family:"
		 ' 
		 ' textBoxGiven
		 ' 
		 Me.textBoxGiven.BackColor = System.Drawing.SystemColors.Window
		 Me.textBoxGiven.Location = New System.Drawing.Point(83, 42)
		 Me.textBoxGiven.Name = "textBoxGiven"
		 Me.textBoxGiven.Size = New System.Drawing.Size(180, 20)
		 Me.textBoxGiven.TabIndex = 5
		 ' 
		 ' label3
		 ' 
		 Me.label3.AutoSize = True
		 Me.label3.Location = New System.Drawing.Point(80, 26)
		 Me.label3.Name = "label3"
		 Me.label3.Size = New System.Drawing.Size(38, 13)
		 Me.label3.TabIndex = 1
		 Me.label3.Text = "Given:"
		 ' 
		 ' textBoxPrefix
		 ' 
		 Me.textBoxPrefix.Location = New System.Drawing.Point(7, 42)
		 Me.textBoxPrefix.Name = "textBoxPrefix"
		 Me.textBoxPrefix.Size = New System.Drawing.Size(74, 20)
		 Me.textBoxPrefix.TabIndex = 4
		 ' 
		 ' label4
		 ' 
		 Me.label4.AutoSize = True
		 Me.label4.Location = New System.Drawing.Point(4, 26)
		 Me.label4.Name = "label4"
		 Me.label4.Size = New System.Drawing.Size(36, 13)
		 Me.label4.TabIndex = 0
		 Me.label4.Text = "Prefix:"
		 ' 
		 ' textBoxIssuerOfPatientId
		 ' 
		 Me.textBoxIssuerOfPatientId.BackColor = System.Drawing.SystemColors.Window
		 Me.textBoxIssuerOfPatientId.Location = New System.Drawing.Point(280, 26)
		 Me.textBoxIssuerOfPatientId.Name = "textBoxIssuerOfPatientId"
		 Me.textBoxIssuerOfPatientId.Size = New System.Drawing.Size(259, 20)
		 Me.textBoxIssuerOfPatientId.TabIndex = 18
		 Me.textBoxIssuerOfPatientId.Tag = "Required"
		 ' 
		 ' label2
		 ' 
		 Me.label2.AutoSize = True
		 Me.label2.Location = New System.Drawing.Point(277, 9)
		 Me.label2.Name = "label2"
		 Me.label2.Size = New System.Drawing.Size(102, 13)
		 Me.label2.TabIndex = 22
		 Me.label2.Text = "Issuer Of Patient ID:"
		 ' 
		 ' label1
		 ' 
		 Me.label1.AutoSize = True
		 Me.label1.Location = New System.Drawing.Point(12, 9)
		 Me.label1.Name = "label1"
		 Me.label1.Size = New System.Drawing.Size(21, 13)
		 Me.label1.TabIndex = 17
		 Me.label1.Text = "ID:"
		 ' 
		 ' buttonCancel
		 ' 
		 Me.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
		 Me.buttonCancel.Location = New System.Drawing.Point(460, 270)
		 Me.buttonCancel.Name = "buttonCancel"
		 Me.buttonCancel.Size = New System.Drawing.Size(75, 23)
		 Me.buttonCancel.TabIndex = 29
		 Me.buttonCancel.Text = "Cancel"
		 Me.buttonCancel.UseVisualStyleBackColor = True
		 ' 
		 ' buttonOK
		 ' 
		 Me.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK
		 Me.buttonOK.Location = New System.Drawing.Point(379, 270)
		 Me.buttonOK.Name = "buttonOK"
		 Me.buttonOK.Size = New System.Drawing.Size(75, 23)
		 Me.buttonOK.TabIndex = 30
		 Me.buttonOK.Text = "OK"
		 Me.buttonOK.UseVisualStyleBackColor = True
		 ' 
		 ' textBoxPatientId
		 ' 
		 Me.textBoxPatientId.Location = New System.Drawing.Point(15, 26)
		 Me.textBoxPatientId.Name = "textBoxPatientId"
		 Me.textBoxPatientId.Size = New System.Drawing.Size(263, 20)
		 Me.textBoxPatientId.TabIndex = 31
		 ' 
		 ' errorProvider
		 ' 
		 Me.errorProvider.ContainerControl = Me
		 ' 
		 ' PatientForm
		 ' 
		 Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
		 Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		 Me.ClientSize = New System.Drawing.Size(550, 305)
		 Me.Controls.Add(Me.textBoxPatientId)
		 Me.Controls.Add(Me.buttonOK)
		 Me.Controls.Add(Me.buttonCancel)
		 Me.Controls.Add(Me.textBoxComments)
		 Me.Controls.Add(Me.label10)
		 Me.Controls.Add(Me.textBoxSpecialNeeds)
		 Me.Controls.Add(Me.label9)
		 Me.Controls.Add(Me.comboBoxSex)
		 Me.Controls.Add(Me.label8)
		 Me.Controls.Add(Me.dateTimePickerBirth)
		 Me.Controls.Add(Me.label7)
		 Me.Controls.Add(Me.groupBoxName)
		 Me.Controls.Add(Me.textBoxIssuerOfPatientId)
		 Me.Controls.Add(Me.label2)
		 Me.Controls.Add(Me.label1)
		 Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		 Me.MaximizeBox = False
		 Me.MinimizeBox = False
		 Me.Name = "PatientForm"
		 Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
		 Me.Text = "PatientForm"
'		 Me.Load += New System.EventHandler(Me.PatientForm_Load);
'		 Me.Paint += New System.Windows.Forms.PaintEventHandler(Me.PatientForm_Paint);
'		 Me.FormClosing += New System.Windows.Forms.FormClosingEventHandler(Me.PatientForm_FormClosing);
		 Me.groupBoxName.ResumeLayout(False)
		 Me.groupBoxName.PerformLayout()
		 CType(Me.errorProvider, System.ComponentModel.ISupportInitialize).EndInit()
		 Me.ResumeLayout(False)
		 Me.PerformLayout()

	  End Sub

	  #End Region

	  Private textBoxComments As System.Windows.Forms.TextBox
	  Private label10 As System.Windows.Forms.Label
	  Private textBoxSpecialNeeds As System.Windows.Forms.TextBox
	  Private label9 As System.Windows.Forms.Label
	  Private comboBoxSex As System.Windows.Forms.ComboBox
	  Private label8 As System.Windows.Forms.Label
	  Private dateTimePickerBirth As System.Windows.Forms.DateTimePicker
	  Private label7 As System.Windows.Forms.Label
	  Private groupBoxName As System.Windows.Forms.GroupBox
	  Private textBoxSuffix As System.Windows.Forms.TextBox
	  Private label6 As System.Windows.Forms.Label
	  Private textBoxFamily As System.Windows.Forms.TextBox
	  Private label5 As System.Windows.Forms.Label
	  Private textBoxGiven As System.Windows.Forms.TextBox
	  Private label3 As System.Windows.Forms.Label
	  Private textBoxPrefix As System.Windows.Forms.TextBox
	  Private label4 As System.Windows.Forms.Label
	  Private textBoxIssuerOfPatientId As System.Windows.Forms.TextBox
	  Private label2 As System.Windows.Forms.Label
	  Private label1 As System.Windows.Forms.Label
	  Private buttonCancel As System.Windows.Forms.Button
	  Private buttonOK As System.Windows.Forms.Button
	  Private textBoxPatientId As System.Windows.Forms.TextBox
	  Private errorProvider As System.Windows.Forms.ErrorProvider
   End Class
End Namespace