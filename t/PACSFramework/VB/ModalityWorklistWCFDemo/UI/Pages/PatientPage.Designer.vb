Imports Microsoft.VisualBasic
Imports System
Namespace ModalityWorklistWCFDemo.UI.Pages
	Partial Public Class PatientPage
		''' <summary> 
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		''' <summary> 
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso (components IsNot Nothing) Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Component Designer generated code"

		''' <summary> 
		''' Required method for Designer support - do not modify 
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
		   Me.components = New System.ComponentModel.Container()
		   Me.label1 = New System.Windows.Forms.Label()
		   Me.textBoxIssuerOfPatientId = New System.Windows.Forms.TextBox()
		   Me.label2 = New System.Windows.Forms.Label()
		   Me.textBoxPrefix = New System.Windows.Forms.TextBox()
		   Me.label4 = New System.Windows.Forms.Label()
		   Me.groupBoxName = New System.Windows.Forms.GroupBox()
		   Me.textBoxSuffix = New System.Windows.Forms.TextBox()
		   Me.label6 = New System.Windows.Forms.Label()
		   Me.textBoxFamily = New System.Windows.Forms.TextBox()
		   Me.label5 = New System.Windows.Forms.Label()
		   Me.textBoxGiven = New System.Windows.Forms.TextBox()
		   Me.label3 = New System.Windows.Forms.Label()
		   Me.label7 = New System.Windows.Forms.Label()
		   Me.dateTimePickerBirth = New System.Windows.Forms.DateTimePicker()
		   Me.label8 = New System.Windows.Forms.Label()
		   Me.comboBoxSex = New System.Windows.Forms.ComboBox()
		   Me.textBoxSpecialNeeds = New System.Windows.Forms.TextBox()
		   Me.label9 = New System.Windows.Forms.Label()
		   Me.textBoxComments = New System.Windows.Forms.TextBox()
		   Me.label10 = New System.Windows.Forms.Label()
		   Me.errorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
		   Me.toolTip = New System.Windows.Forms.ToolTip(Me.components)
		   Me.comboBoxPatientId = New System.Windows.Forms.ComboBox()
		   Me.TopBannerPanel.SuspendLayout()
		   CType(Me.IconPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
		   Me.groupBoxName.SuspendLayout()
		   CType(Me.errorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
		   Me.SuspendLayout()
		   ' 
		   ' TopBannerPanel
		   ' 
		   Me.TopBannerPanel.Size = New System.Drawing.Size(556, 87)
		   ' 
		   ' TitleDescriptionLabel
		   ' 
		   Me.TitleDescriptionLabel.Size = New System.Drawing.Size(379, 32)
		   Me.TitleDescriptionLabel.Text = "Edit an existing patient or add a new patient to the modality worklist database."
		   ' 
		   ' TitleLabel
		   ' 
		   Me.TitleLabel.Size = New System.Drawing.Size(51, 31)
		   Me.TitleLabel.Text = "Patient"
		   ' 
		   ' IconPictureBox
		   ' 
         Me.IconPictureBox.Image = My.Resources.Logo
		   Me.IconPictureBox.Location = New System.Drawing.Point(423, 13)
		   Me.IconPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
		   ' 
		   ' label1
		   ' 
		   Me.label1.AutoSize = True
		   Me.label1.Location = New System.Drawing.Point(19, 89)
		   Me.label1.Name = "label1"
		   Me.label1.Size = New System.Drawing.Size(21, 13)
		   Me.label1.TabIndex = 1
		   Me.label1.Text = "ID:"
		   ' 
		   ' textBoxIssuerOfPatientId
		   ' 
		   Me.textBoxIssuerOfPatientId.BackColor = System.Drawing.SystemColors.Window
		   Me.textBoxIssuerOfPatientId.Location = New System.Drawing.Point(287, 106)
		   Me.textBoxIssuerOfPatientId.Name = "textBoxIssuerOfPatientId"
		   Me.textBoxIssuerOfPatientId.Size = New System.Drawing.Size(256, 20)
		   Me.textBoxIssuerOfPatientId.TabIndex = 1
		   Me.textBoxIssuerOfPatientId.Tag = "Required"
		   ' 
		   ' label2
		   ' 
		   Me.label2.AutoSize = True
		   Me.label2.Location = New System.Drawing.Point(284, 89)
		   Me.label2.Name = "label2"
		   Me.label2.Size = New System.Drawing.Size(102, 13)
		   Me.label2.TabIndex = 3
		   Me.label2.Text = "Issuer Of Patient ID:"
		   ' 
		   ' textBoxPrefix
		   ' 
		   Me.textBoxPrefix.Location = New System.Drawing.Point(7, 42)
		   Me.textBoxPrefix.Name = "textBoxPrefix"
		   Me.textBoxPrefix.Size = New System.Drawing.Size(74, 20)
		   Me.textBoxPrefix.TabIndex = 0
		   ' 
		   ' label4
		   ' 
		   Me.label4.AutoSize = True
		   Me.label4.Location = New System.Drawing.Point(4, 26)
		   Me.label4.Name = "label4"
		   Me.label4.Size = New System.Drawing.Size(36, 13)
		   Me.label4.TabIndex = 7
		   Me.label4.Text = "Prefix:"
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
		   Me.groupBoxName.Location = New System.Drawing.Point(22, 132)
		   Me.groupBoxName.Name = "groupBoxName"
		   Me.groupBoxName.Size = New System.Drawing.Size(524, 73)
		   Me.groupBoxName.TabIndex = 8
		   Me.groupBoxName.TabStop = False
		   Me.groupBoxName.Tag = "Required"
		   Me.groupBoxName.Text = "Name"
		   ' 
		   ' textBoxSuffix
		   ' 
		   Me.textBoxSuffix.Location = New System.Drawing.Point(447, 42)
		   Me.textBoxSuffix.Name = "textBoxSuffix"
		   Me.textBoxSuffix.Size = New System.Drawing.Size(74, 20)
		   Me.textBoxSuffix.TabIndex = 3
		   ' 
		   ' label6
		   ' 
		   Me.label6.AutoSize = True
		   Me.label6.Location = New System.Drawing.Point(444, 26)
		   Me.label6.Name = "label6"
		   Me.label6.Size = New System.Drawing.Size(36, 13)
		   Me.label6.TabIndex = 13
		   Me.label6.Text = "Suffix:"
		   ' 
		   ' textBoxFamily
		   ' 
		   Me.textBoxFamily.BackColor = System.Drawing.SystemColors.Window
		   Me.textBoxFamily.Location = New System.Drawing.Point(265, 42)
		   Me.textBoxFamily.Name = "textBoxFamily"
		   Me.textBoxFamily.Size = New System.Drawing.Size(180, 20)
		   Me.textBoxFamily.TabIndex = 2
		   ' 
		   ' label5
		   ' 
		   Me.label5.AutoSize = True
		   Me.label5.Location = New System.Drawing.Point(262, 26)
		   Me.label5.Name = "label5"
		   Me.label5.Size = New System.Drawing.Size(39, 13)
		   Me.label5.TabIndex = 11
		   Me.label5.Text = "Family:"
		   ' 
		   ' textBoxGiven
		   ' 
		   Me.textBoxGiven.BackColor = System.Drawing.SystemColors.Window
		   Me.textBoxGiven.Location = New System.Drawing.Point(83, 42)
		   Me.textBoxGiven.Name = "textBoxGiven"
		   Me.textBoxGiven.Size = New System.Drawing.Size(180, 20)
		   Me.textBoxGiven.TabIndex = 1
		   ' 
		   ' label3
		   ' 
		   Me.label3.AutoSize = True
		   Me.label3.Location = New System.Drawing.Point(80, 26)
		   Me.label3.Name = "label3"
		   Me.label3.Size = New System.Drawing.Size(38, 13)
		   Me.label3.TabIndex = 9
		   Me.label3.Text = "Given:"
		   ' 
		   ' label7
		   ' 
		   Me.label7.AutoSize = True
		   Me.label7.Location = New System.Drawing.Point(19, 208)
		   Me.label7.Name = "label7"
		   Me.label7.Size = New System.Drawing.Size(52, 13)
		   Me.label7.TabIndex = 9
		   Me.label7.Text = "Birthdate:"
		   ' 
		   ' dateTimePickerBirth
		   ' 
		   Me.dateTimePickerBirth.Format = System.Windows.Forms.DateTimePickerFormat.Short
		   Me.dateTimePickerBirth.Location = New System.Drawing.Point(22, 224)
		   Me.dateTimePickerBirth.Name = "dateTimePickerBirth"
		   Me.dateTimePickerBirth.ShowCheckBox = True
		   Me.dateTimePickerBirth.Size = New System.Drawing.Size(132, 20)
		   Me.dateTimePickerBirth.TabIndex = 2
		   ' 
		   ' label8
		   ' 
		   Me.label8.AutoSize = True
		   Me.label8.Location = New System.Drawing.Point(157, 207)
		   Me.label8.Name = "label8"
		   Me.label8.Size = New System.Drawing.Size(28, 13)
		   Me.label8.TabIndex = 11
		   Me.label8.Text = "Sex:"
		   ' 
		   ' comboBoxSex
		   ' 
		   Me.comboBoxSex.FormattingEnabled = True
		   Me.comboBoxSex.Items.AddRange(New Object() { "M", "F", "O"})
		   Me.comboBoxSex.Location = New System.Drawing.Point(160, 223)
		   Me.comboBoxSex.Name = "comboBoxSex"
		   Me.comboBoxSex.Size = New System.Drawing.Size(121, 21)
		   Me.comboBoxSex.TabIndex = 3
		   Me.comboBoxSex.Tag = "required"
		   ' 
		   ' textBoxSpecialNeeds
		   ' 
		   Me.textBoxSpecialNeeds.Location = New System.Drawing.Point(284, 224)
		   Me.textBoxSpecialNeeds.Name = "textBoxSpecialNeeds"
		   Me.textBoxSpecialNeeds.Size = New System.Drawing.Size(259, 20)
		   Me.textBoxSpecialNeeds.TabIndex = 4
		   ' 
		   ' label9
		   ' 
		   Me.label9.AutoSize = True
		   Me.label9.Location = New System.Drawing.Point(284, 207)
		   Me.label9.Name = "label9"
		   Me.label9.Size = New System.Drawing.Size(79, 13)
		   Me.label9.TabIndex = 13
		   Me.label9.Text = "Special Needs:"
		   ' 
		   ' textBoxComments
		   ' 
		   Me.textBoxComments.Location = New System.Drawing.Point(22, 263)
		   Me.textBoxComments.Multiline = True
		   Me.textBoxComments.Name = "textBoxComments"
		   Me.textBoxComments.Size = New System.Drawing.Size(524, 80)
		   Me.textBoxComments.TabIndex = 5
		   ' 
		   ' label10
		   ' 
		   Me.label10.AutoSize = True
		   Me.label10.Location = New System.Drawing.Point(19, 247)
		   Me.label10.Name = "label10"
		   Me.label10.Size = New System.Drawing.Size(59, 13)
		   Me.label10.TabIndex = 15
		   Me.label10.Text = "Comments:"
		   ' 
		   ' errorProvider
		   ' 
		   Me.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
		   Me.errorProvider.ContainerControl = Me
		   ' 
		   ' comboBoxPatientId
		   ' 
		   Me.comboBoxPatientId.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
		   Me.comboBoxPatientId.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
		   Me.comboBoxPatientId.FormattingEnabled = True
		   Me.comboBoxPatientId.Location = New System.Drawing.Point(22, 105)
		   Me.comboBoxPatientId.Name = "comboBoxPatientId"
		   Me.comboBoxPatientId.Size = New System.Drawing.Size(259, 21)
		   Me.comboBoxPatientId.TabIndex = 0
		   Me.comboBoxPatientId.Tag = "Required"
'		   Me.comboBoxPatientId.SelectedIndexChanged += New System.EventHandler(Me.comboBoxPatientId_SelectedIndexChanged);
		   ' 
		   ' PatientPage
		   ' 
		   Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
		   Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		   Me.Controls.Add(Me.comboBoxPatientId)
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
		   Me.Name = "PatientPage"
		   Me.Size = New System.Drawing.Size(556, 362)
'		   Me.Paint += New System.Windows.Forms.PaintEventHandler(Me.PatientPage_Paint);
		   Me.Controls.SetChildIndex(Me.label1, 0)
		   Me.Controls.SetChildIndex(Me.TopBannerPanel, 0)
		   Me.Controls.SetChildIndex(Me.label2, 0)
		   Me.Controls.SetChildIndex(Me.textBoxIssuerOfPatientId, 0)
		   Me.Controls.SetChildIndex(Me.groupBoxName, 0)
		   Me.Controls.SetChildIndex(Me.label7, 0)
		   Me.Controls.SetChildIndex(Me.dateTimePickerBirth, 0)
		   Me.Controls.SetChildIndex(Me.label8, 0)
		   Me.Controls.SetChildIndex(Me.comboBoxSex, 0)
		   Me.Controls.SetChildIndex(Me.label9, 0)
		   Me.Controls.SetChildIndex(Me.textBoxSpecialNeeds, 0)
		   Me.Controls.SetChildIndex(Me.label10, 0)
		   Me.Controls.SetChildIndex(Me.textBoxComments, 0)
		   Me.Controls.SetChildIndex(Me.comboBoxPatientId, 0)
		   Me.TopBannerPanel.ResumeLayout(False)
		   CType(Me.IconPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
		   Me.groupBoxName.ResumeLayout(False)
		   Me.groupBoxName.PerformLayout()
		   CType(Me.errorProvider, System.ComponentModel.ISupportInitialize).EndInit()
		   Me.ResumeLayout(False)
		   Me.PerformLayout()

		End Sub

		#End Region

		Private label1 As System.Windows.Forms.Label
		Private textBoxIssuerOfPatientId As System.Windows.Forms.TextBox
		Private label2 As System.Windows.Forms.Label
		Private textBoxPrefix As System.Windows.Forms.TextBox
		Private label4 As System.Windows.Forms.Label
		Private groupBoxName As System.Windows.Forms.GroupBox
		Private textBoxGiven As System.Windows.Forms.TextBox
		Private label3 As System.Windows.Forms.Label
		Private textBoxSuffix As System.Windows.Forms.TextBox
		Private label6 As System.Windows.Forms.Label
		Private textBoxFamily As System.Windows.Forms.TextBox
		Private label5 As System.Windows.Forms.Label
		Private label7 As System.Windows.Forms.Label
		Private dateTimePickerBirth As System.Windows.Forms.DateTimePicker
		Private label8 As System.Windows.Forms.Label
		Private comboBoxSex As System.Windows.Forms.ComboBox
		Private textBoxSpecialNeeds As System.Windows.Forms.TextBox
		Private label9 As System.Windows.Forms.Label
		Private textBoxComments As System.Windows.Forms.TextBox
		Private label10 As System.Windows.Forms.Label
		Private errorProvider As System.Windows.Forms.ErrorProvider
		Private toolTip As System.Windows.Forms.ToolTip
		Private WithEvents comboBoxPatientId As System.Windows.Forms.ComboBox
	End Class
End Namespace
