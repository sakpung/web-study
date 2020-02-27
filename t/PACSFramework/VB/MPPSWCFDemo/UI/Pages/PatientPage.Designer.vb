Imports Microsoft.VisualBasic
Imports System
Namespace MPPSWCFDemo.UI.Pages
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
		   Me.label7 = New System.Windows.Forms.Label()
		   Me.dateTimePickerBirth = New System.Windows.Forms.DateTimePicker()
		   Me.label8 = New System.Windows.Forms.Label()
		   Me.comboBoxSex = New System.Windows.Forms.ComboBox()
		   Me.textBoxName = New System.Windows.Forms.TextBox()
		   Me.label9 = New System.Windows.Forms.Label()
		   Me.errorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
		   Me.toolTip = New System.Windows.Forms.ToolTip(Me.components)
		   Me.textBoxId = New System.Windows.Forms.TextBox()
		   Me.TopBannerPanel.SuspendLayout()
		   CType(Me.IconPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
		   CType(Me.errorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
		   Me.SuspendLayout()
		   ' 
		   ' TopBannerPanel
		   ' 
		   Me.TopBannerPanel.Size = New System.Drawing.Size(556, 87)
		   ' 
		   ' TitleDescriptionLabel
		   ' 
		   Me.TitleDescriptionLabel.Size = New System.Drawing.Size(349, 32)
		   Me.TitleDescriptionLabel.Text = "Edit an unscheduled patient associated with this modality performed procedure ste" & "p."
		   ' 
		   ' TitleLabel
		   ' 
		   Me.TitleLabel.Size = New System.Drawing.Size(368, 31)
		   Me.TitleLabel.Text = "Modality Peformed Procedure Step (Step 3)"
		   ' 
		   ' IconPictureBox
		   ' 
		   Me.IconPictureBox.Image = My.Resources.Logo
		   Me.IconPictureBox.Location = New System.Drawing.Point(393, 13)
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
		   ' label7
		   ' 
		   Me.label7.AutoSize = True
		   Me.label7.Location = New System.Drawing.Point(284, 130)
		   Me.label7.Name = "label7"
		   Me.label7.Size = New System.Drawing.Size(52, 13)
		   Me.label7.TabIndex = 9
		   Me.label7.Text = "Birthdate:"
		   ' 
		   ' dateTimePickerBirth
		   ' 
		   Me.dateTimePickerBirth.Format = System.Windows.Forms.DateTimePickerFormat.Short
		   Me.dateTimePickerBirth.Location = New System.Drawing.Point(287, 146)
		   Me.dateTimePickerBirth.Name = "dateTimePickerBirth"
		   Me.dateTimePickerBirth.ShowCheckBox = True
		   Me.dateTimePickerBirth.Size = New System.Drawing.Size(132, 20)
		   Me.dateTimePickerBirth.TabIndex = 3
		   ' 
		   ' label8
		   ' 
		   Me.label8.AutoSize = True
		   Me.label8.Location = New System.Drawing.Point(422, 129)
		   Me.label8.Name = "label8"
		   Me.label8.Size = New System.Drawing.Size(28, 13)
		   Me.label8.TabIndex = 11
		   Me.label8.Text = "Sex:"
		   ' 
		   ' comboBoxSex
		   ' 
		   Me.comboBoxSex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		   Me.comboBoxSex.FormattingEnabled = True
		   Me.comboBoxSex.Items.AddRange(New Object() { "M", "F", "O"})
		   Me.comboBoxSex.Location = New System.Drawing.Point(425, 145)
		   Me.comboBoxSex.Name = "comboBoxSex"
		   Me.comboBoxSex.Size = New System.Drawing.Size(118, 21)
		   Me.comboBoxSex.TabIndex = 4
		   ' 
		   ' textBoxName
		   ' 
		   Me.textBoxName.Location = New System.Drawing.Point(22, 146)
		   Me.textBoxName.Name = "textBoxName"
		   Me.textBoxName.Size = New System.Drawing.Size(259, 20)
		   Me.textBoxName.TabIndex = 5
		   ' 
		   ' label9
		   ' 
		   Me.label9.AutoSize = True
		   Me.label9.Location = New System.Drawing.Point(22, 129)
		   Me.label9.Name = "label9"
		   Me.label9.Size = New System.Drawing.Size(38, 13)
		   Me.label9.TabIndex = 13
		   Me.label9.Text = "Name:"
		   ' 
		   ' errorProvider
		   ' 
		   Me.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
		   Me.errorProvider.ContainerControl = Me
		   ' 
		   ' textBoxId
		   ' 
		   Me.textBoxId.Location = New System.Drawing.Point(22, 106)
		   Me.textBoxId.Name = "textBoxId"
		   Me.textBoxId.Size = New System.Drawing.Size(259, 20)
		   Me.textBoxId.TabIndex = 16
		   ' 
		   ' PatientPage
		   ' 
		   Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
		   Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		   Me.Controls.Add(Me.textBoxId)
		   Me.Controls.Add(Me.textBoxName)
		   Me.Controls.Add(Me.comboBoxSex)
		   Me.Controls.Add(Me.label8)
		   Me.Controls.Add(Me.label9)
		   Me.Controls.Add(Me.textBoxIssuerOfPatientId)
		   Me.Controls.Add(Me.dateTimePickerBirth)
		   Me.Controls.Add(Me.label7)
		   Me.Controls.Add(Me.label2)
		   Me.Controls.Add(Me.label1)
		   Me.Name = "PatientPage"
		   Me.Size = New System.Drawing.Size(556, 362)
		   Me.Controls.SetChildIndex(Me.label1, 0)
		   Me.Controls.SetChildIndex(Me.label2, 0)
		   Me.Controls.SetChildIndex(Me.label7, 0)
		   Me.Controls.SetChildIndex(Me.dateTimePickerBirth, 0)
		   Me.Controls.SetChildIndex(Me.textBoxIssuerOfPatientId, 0)
		   Me.Controls.SetChildIndex(Me.label9, 0)
		   Me.Controls.SetChildIndex(Me.label8, 0)
		   Me.Controls.SetChildIndex(Me.comboBoxSex, 0)
		   Me.Controls.SetChildIndex(Me.textBoxName, 0)
		   Me.Controls.SetChildIndex(Me.textBoxId, 0)
		   Me.Controls.SetChildIndex(Me.TopBannerPanel, 0)
		   Me.TopBannerPanel.ResumeLayout(False)
		   CType(Me.IconPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
		   CType(Me.errorProvider, System.ComponentModel.ISupportInitialize).EndInit()
		   Me.ResumeLayout(False)
		   Me.PerformLayout()

		End Sub

		#End Region

		Private label1 As System.Windows.Forms.Label
		Private textBoxIssuerOfPatientId As System.Windows.Forms.TextBox
		Private label2 As System.Windows.Forms.Label
		Private label7 As System.Windows.Forms.Label
		Private dateTimePickerBirth As System.Windows.Forms.DateTimePicker
		Private label8 As System.Windows.Forms.Label
		Private comboBoxSex As System.Windows.Forms.ComboBox
		Private textBoxName As System.Windows.Forms.TextBox
		Private label9 As System.Windows.Forms.Label
		Private errorProvider As System.Windows.Forms.ErrorProvider
		Private toolTip As System.Windows.Forms.ToolTip
		Private textBoxId As System.Windows.Forms.TextBox
	End Class
End Namespace
