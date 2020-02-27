Imports Microsoft.VisualBasic
Imports System
Namespace ModalityWorklistWCFDemo.UI.Pages
	Partial Public Class ImagingServiceRequestPage
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
			Me.groupBox1 = New System.Windows.Forms.GroupBox()
			Me.textBoxSuffix = New System.Windows.Forms.TextBox()
			Me.label6 = New System.Windows.Forms.Label()
			Me.textBoxFamily = New System.Windows.Forms.TextBox()
			Me.label5 = New System.Windows.Forms.Label()
			Me.textBoxGiven = New System.Windows.Forms.TextBox()
			Me.label3 = New System.Windows.Forms.Label()
			Me.textBoxPrefix = New System.Windows.Forms.TextBox()
			Me.label4 = New System.Windows.Forms.Label()
			Me.groupBox2 = New System.Windows.Forms.GroupBox()
			Me.textBoxRPSuffix = New System.Windows.Forms.TextBox()
			Me.label2 = New System.Windows.Forms.Label()
			Me.textBoxRPFamily = New System.Windows.Forms.TextBox()
			Me.label7 = New System.Windows.Forms.Label()
			Me.textBoxRPGiven = New System.Windows.Forms.TextBox()
			Me.label8 = New System.Windows.Forms.Label()
			Me.textBoxRPPrefix = New System.Windows.Forms.TextBox()
			Me.label9 = New System.Windows.Forms.Label()
			Me.label10 = New System.Windows.Forms.Label()
			Me.textBoxRequestingService = New System.Windows.Forms.TextBox()
			Me.textBoxFillOrderNumber = New System.Windows.Forms.TextBox()
			Me.label11 = New System.Windows.Forms.Label()
			Me.textBoxPlaceOrderNumber = New System.Windows.Forms.TextBox()
			Me.label12 = New System.Windows.Forms.Label()
			Me.errorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
			Me.comboBoxAccessionNumber = New System.Windows.Forms.ComboBox()
			Me.TopBannerPanel.SuspendLayout()
			CType(Me.IconPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.groupBox1.SuspendLayout()
			Me.groupBox2.SuspendLayout()
			CType(Me.errorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' TopBannerPanel
			' 
			Me.TopBannerPanel.Size = New System.Drawing.Size(556, 87)
			Me.TopBannerPanel.TabIndex = 1
			' 
			' TitleDescriptionLabel
			' 
			Me.TitleDescriptionLabel.Size = New System.Drawing.Size(379, 32)
			Me.TitleDescriptionLabel.Text = "Edit an existing imaging service request or add a new one to the modality work li" & "st database."
			' 
			' TitleLabel
			' 
			Me.TitleLabel.Size = New System.Drawing.Size(398, 31)
			Me.TitleLabel.Text = "Imaging Service Request"
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
			Me.label1.Size = New System.Drawing.Size(99, 13)
			Me.label1.TabIndex = 3
			Me.label1.Text = "Accession Number:"
			' 
			' groupBox1
			' 
			Me.groupBox1.Controls.Add(Me.textBoxSuffix)
			Me.groupBox1.Controls.Add(Me.label6)
			Me.groupBox1.Controls.Add(Me.textBoxFamily)
			Me.groupBox1.Controls.Add(Me.label5)
			Me.groupBox1.Controls.Add(Me.textBoxGiven)
			Me.groupBox1.Controls.Add(Me.label3)
			Me.groupBox1.Controls.Add(Me.textBoxPrefix)
			Me.groupBox1.Controls.Add(Me.label4)
			Me.groupBox1.Location = New System.Drawing.Point(22, 131)
			Me.groupBox1.Name = "groupBox1"
			Me.groupBox1.Size = New System.Drawing.Size(524, 73)
			Me.groupBox1.TabIndex = 9
			Me.groupBox1.TabStop = False
			Me.groupBox1.Text = "Requesting Physician"
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
			Me.textBoxGiven.Location = New System.Drawing.Point(83, 42)
			Me.textBoxGiven.Name = "textBoxGiven"
			Me.textBoxGiven.Size = New System.Drawing.Size(176, 20)
			Me.textBoxGiven.TabIndex = 1
			' 
			' label3
			' 
			Me.label3.AutoSize = True
			Me.label3.Location = New System.Drawing.Point(80, 26)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(38, 13)
			Me.label3.TabIndex = 3
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
			Me.label4.TabIndex = 7
			Me.label4.Text = "Prefix:"
			' 
			' groupBox2
			' 
			Me.groupBox2.Controls.Add(Me.textBoxRPSuffix)
			Me.groupBox2.Controls.Add(Me.label2)
			Me.groupBox2.Controls.Add(Me.textBoxRPFamily)
			Me.groupBox2.Controls.Add(Me.label7)
			Me.groupBox2.Controls.Add(Me.textBoxRPGiven)
			Me.groupBox2.Controls.Add(Me.label8)
			Me.groupBox2.Controls.Add(Me.textBoxRPPrefix)
			Me.groupBox2.Controls.Add(Me.label9)
			Me.groupBox2.Location = New System.Drawing.Point(22, 210)
			Me.groupBox2.Name = "groupBox2"
			Me.groupBox2.Size = New System.Drawing.Size(524, 73)
			Me.groupBox2.TabIndex = 2
			Me.groupBox2.TabStop = False
			Me.groupBox2.Text = "Referring Physician"
			' 
			' textBoxRPSuffix
			' 
			Me.textBoxRPSuffix.Location = New System.Drawing.Point(447, 42)
			Me.textBoxRPSuffix.Name = "textBoxRPSuffix"
			Me.textBoxRPSuffix.Size = New System.Drawing.Size(74, 20)
			Me.textBoxRPSuffix.TabIndex = 3
			' 
			' label2
			' 
			Me.label2.AutoSize = True
			Me.label2.Location = New System.Drawing.Point(444, 26)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(36, 13)
			Me.label2.TabIndex = 13
			Me.label2.Text = "Suffix:"
			' 
			' textBoxRPFamily
			' 
			Me.textBoxRPFamily.Location = New System.Drawing.Point(265, 42)
			Me.textBoxRPFamily.Name = "textBoxRPFamily"
			Me.textBoxRPFamily.Size = New System.Drawing.Size(180, 20)
			Me.textBoxRPFamily.TabIndex = 2
			' 
			' label7
			' 
			Me.label7.AutoSize = True
			Me.label7.Location = New System.Drawing.Point(262, 26)
			Me.label7.Name = "label7"
			Me.label7.Size = New System.Drawing.Size(39, 13)
			Me.label7.TabIndex = 11
			Me.label7.Text = "Family:"
			' 
			' textBoxRPGiven
			' 
			Me.textBoxRPGiven.Location = New System.Drawing.Point(83, 42)
			Me.textBoxRPGiven.Name = "textBoxRPGiven"
			Me.textBoxRPGiven.Size = New System.Drawing.Size(176, 20)
			Me.textBoxRPGiven.TabIndex = 1
			' 
			' label8
			' 
			Me.label8.AutoSize = True
			Me.label8.Location = New System.Drawing.Point(80, 26)
			Me.label8.Name = "label8"
			Me.label8.Size = New System.Drawing.Size(38, 13)
			Me.label8.TabIndex = 9
			Me.label8.Text = "Given:"
			' 
			' textBoxRPPrefix
			' 
			Me.textBoxRPPrefix.Location = New System.Drawing.Point(7, 42)
			Me.textBoxRPPrefix.Name = "textBoxRPPrefix"
			Me.textBoxRPPrefix.Size = New System.Drawing.Size(74, 20)
			Me.textBoxRPPrefix.TabIndex = 0
			' 
			' label9
			' 
			Me.label9.AutoSize = True
			Me.label9.Location = New System.Drawing.Point(4, 26)
			Me.label9.Name = "label9"
			Me.label9.Size = New System.Drawing.Size(36, 13)
			Me.label9.TabIndex = 7
			Me.label9.Text = "Prefix:"
			' 
			' label10
			' 
			Me.label10.AutoSize = True
			Me.label10.Location = New System.Drawing.Point(287, 89)
			Me.label10.Name = "label10"
			Me.label10.Size = New System.Drawing.Size(103, 13)
			Me.label10.TabIndex = 11
			Me.label10.Text = "Requesting Service:"
			' 
			' textBoxRequestingService
			' 
			Me.textBoxRequestingService.Location = New System.Drawing.Point(287, 105)
			Me.textBoxRequestingService.Name = "textBoxRequestingService"
			Me.textBoxRequestingService.Size = New System.Drawing.Size(259, 20)
			Me.textBoxRequestingService.TabIndex = 3
			' 
			' textBoxFillOrderNumber
			' 
			Me.textBoxFillOrderNumber.Location = New System.Drawing.Point(287, 302)
			Me.textBoxFillOrderNumber.Name = "textBoxFillOrderNumber"
			Me.textBoxFillOrderNumber.Size = New System.Drawing.Size(259, 20)
			Me.textBoxFillOrderNumber.TabIndex = 3
			' 
			' label11
			' 
			Me.label11.AutoSize = True
			Me.label11.Location = New System.Drawing.Point(287, 286)
			Me.label11.Name = "label11"
			Me.label11.Size = New System.Drawing.Size(91, 13)
			Me.label11.TabIndex = 15
			Me.label11.Text = "Fill Order Number:"
			' 
			' textBoxPlaceOrderNumber
			' 
			Me.textBoxPlaceOrderNumber.Location = New System.Drawing.Point(22, 302)
			Me.textBoxPlaceOrderNumber.Name = "textBoxPlaceOrderNumber"
			Me.textBoxPlaceOrderNumber.Size = New System.Drawing.Size(259, 20)
			Me.textBoxPlaceOrderNumber.TabIndex = 2
			' 
			' label12
			' 
			Me.label12.AutoSize = True
			Me.label12.Location = New System.Drawing.Point(19, 286)
			Me.label12.Name = "label12"
			Me.label12.Size = New System.Drawing.Size(106, 13)
			Me.label12.TabIndex = 13
			Me.label12.Text = "Place Order Number:"
			' 
			' errorProvider
			' 
			Me.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
			Me.errorProvider.ContainerControl = Me
			' 
			' comboBoxAccessionNumber
			' 
			Me.comboBoxAccessionNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
			Me.comboBoxAccessionNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
			Me.comboBoxAccessionNumber.FormattingEnabled = True
			Me.comboBoxAccessionNumber.Location = New System.Drawing.Point(22, 105)
			Me.comboBoxAccessionNumber.Name = "comboBoxAccessionNumber"
			Me.comboBoxAccessionNumber.Size = New System.Drawing.Size(259, 21)
			Me.comboBoxAccessionNumber.TabIndex = 2
			Me.comboBoxAccessionNumber.Tag = "Required"
'			Me.comboBoxAccessionNumber.SelectedIndexChanged += New System.EventHandler(Me.comboBoxAccessionNumber_SelectedIndexChanged);
			' 
			' ImagingServiceRequestPage
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.Controls.Add(Me.comboBoxAccessionNumber)
			Me.Controls.Add(Me.textBoxFillOrderNumber)
			Me.Controls.Add(Me.label11)
			Me.Controls.Add(Me.textBoxPlaceOrderNumber)
			Me.Controls.Add(Me.label12)
			Me.Controls.Add(Me.textBoxRequestingService)
			Me.Controls.Add(Me.label10)
			Me.Controls.Add(Me.groupBox2)
			Me.Controls.Add(Me.groupBox1)
			Me.Controls.Add(Me.label1)
			Me.Name = "ImagingServiceRequestPage"
			Me.Size = New System.Drawing.Size(556, 362)
'			Me.Paint += New System.Windows.Forms.PaintEventHandler(Me.ImagingServiceRequestPage_Paint);
			Me.Controls.SetChildIndex(Me.TopBannerPanel, 0)
			Me.Controls.SetChildIndex(Me.label1, 0)
			Me.Controls.SetChildIndex(Me.groupBox1, 0)
			Me.Controls.SetChildIndex(Me.groupBox2, 0)
			Me.Controls.SetChildIndex(Me.label10, 0)
			Me.Controls.SetChildIndex(Me.textBoxRequestingService, 0)
			Me.Controls.SetChildIndex(Me.label12, 0)
			Me.Controls.SetChildIndex(Me.textBoxPlaceOrderNumber, 0)
			Me.Controls.SetChildIndex(Me.label11, 0)
			Me.Controls.SetChildIndex(Me.textBoxFillOrderNumber, 0)
			Me.Controls.SetChildIndex(Me.comboBoxAccessionNumber, 0)
			Me.TopBannerPanel.ResumeLayout(False)
			CType(Me.IconPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
			Me.groupBox1.ResumeLayout(False)
			Me.groupBox1.PerformLayout()
			Me.groupBox2.ResumeLayout(False)
			Me.groupBox2.PerformLayout()
			CType(Me.errorProvider, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub

		#End Region

		Private label1 As System.Windows.Forms.Label
		Private groupBox1 As System.Windows.Forms.GroupBox
		Private textBoxSuffix As System.Windows.Forms.TextBox
		Private label6 As System.Windows.Forms.Label
		Private textBoxFamily As System.Windows.Forms.TextBox
		Private label5 As System.Windows.Forms.Label
		Private textBoxGiven As System.Windows.Forms.TextBox
		Private label3 As System.Windows.Forms.Label
		Private textBoxPrefix As System.Windows.Forms.TextBox
		Private label4 As System.Windows.Forms.Label
		Private groupBox2 As System.Windows.Forms.GroupBox
		Private textBoxRPSuffix As System.Windows.Forms.TextBox
		Private label2 As System.Windows.Forms.Label
		Private textBoxRPFamily As System.Windows.Forms.TextBox
		Private label7 As System.Windows.Forms.Label
		Private textBoxRPGiven As System.Windows.Forms.TextBox
		Private label8 As System.Windows.Forms.Label
		Private textBoxRPPrefix As System.Windows.Forms.TextBox
		Private label9 As System.Windows.Forms.Label
		Private label10 As System.Windows.Forms.Label
		Private textBoxRequestingService As System.Windows.Forms.TextBox
		Private textBoxFillOrderNumber As System.Windows.Forms.TextBox
		Private label11 As System.Windows.Forms.Label
		Private textBoxPlaceOrderNumber As System.Windows.Forms.TextBox
		Private label12 As System.Windows.Forms.Label
		Private errorProvider As System.Windows.Forms.ErrorProvider
		Private WithEvents comboBoxAccessionNumber As System.Windows.Forms.ComboBox
	End Class
End Namespace
