Imports Microsoft.VisualBasic
Imports System
Namespace ModalityWorklistWCFDemo.UI.Pages
	Partial Public Class ScheduledProcedureStepPage
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
         Me.components = New System.ComponentModel.Container
         Me.textBoxLocation = New System.Windows.Forms.TextBox
         Me.label10 = New System.Windows.Forms.Label
         Me.label1 = New System.Windows.Forms.Label
         Me.groupBox1 = New System.Windows.Forms.GroupBox
         Me.textBoxSuffix = New System.Windows.Forms.TextBox
         Me.label6 = New System.Windows.Forms.Label
         Me.textBoxFamily = New System.Windows.Forms.TextBox
         Me.label5 = New System.Windows.Forms.Label
         Me.textBoxGiven = New System.Windows.Forms.TextBox
         Me.label3 = New System.Windows.Forms.Label
         Me.textBoxPrefix = New System.Windows.Forms.TextBox
         Me.label4 = New System.Windows.Forms.Label
         Me.label8 = New System.Windows.Forms.Label
         Me.dateTimePickerStartDate = New System.Windows.Forms.DateTimePicker
         Me.label7 = New System.Windows.Forms.Label
         Me.buttonDeleteSP = New System.Windows.Forms.Button
         Me.buttonEditSP = New System.Windows.Forms.Button
         Me.buttonAddSP = New System.Windows.Forms.Button
         Me.listViewSPCS = New System.Windows.Forms.ListView
         Me.columnHeader1 = New System.Windows.Forms.ColumnHeader
         Me.columnHeader2 = New System.Windows.Forms.ColumnHeader
         Me.columnHeader3 = New System.Windows.Forms.ColumnHeader
         Me.columnHeader4 = New System.Windows.Forms.ColumnHeader
         Me.label2 = New System.Windows.Forms.Label
         Me.label9 = New System.Windows.Forms.Label
         Me.textBoxDescription = New System.Windows.Forms.TextBox
         Me.textBoxScheduledStationAE = New System.Windows.Forms.TextBox
         Me.label11 = New System.Windows.Forms.Label
         Me.errorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
         Me.comboBoxModality = New System.Windows.Forms.ComboBox
         Me.comboBoxId = New System.Windows.Forms.ComboBox
         Me.TopBannerPanel.SuspendLayout()
         CType(Me.IconPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
         Me.groupBox1.SuspendLayout()
         CType(Me.errorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
         Me.SuspendLayout()
         '
         'TitleDescriptionLabel
         '
         Me.TitleDescriptionLabel.Size = New System.Drawing.Size(429, 32)
         Me.TitleDescriptionLabel.Text = "Edit an existing scheduled procedure step or add a new one to the modality workli" & _
             "st database."
         '
         'TitleLabel
         '
         Me.TitleLabel.Text = "Scheduled Procedure Step"
         '
         'IconPictureBox
         '
         Me.IconPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
         '
         'textBoxLocation
         '
         Me.textBoxLocation.Location = New System.Drawing.Point(160, 105)
         Me.textBoxLocation.Name = "textBoxLocation"
         Me.textBoxLocation.Size = New System.Drawing.Size(121, 20)
         Me.textBoxLocation.TabIndex = 20
         '
         'label10
         '
         Me.label10.AutoSize = True
         Me.label10.Location = New System.Drawing.Point(157, 89)
         Me.label10.Name = "label10"
         Me.label10.Size = New System.Drawing.Size(51, 13)
         Me.label10.TabIndex = 19
         Me.label10.Text = "Location:"
         '
         'label1
         '
         Me.label1.AutoSize = True
         Me.label1.Location = New System.Drawing.Point(19, 89)
         Me.label1.Name = "label1"
         Me.label1.Size = New System.Drawing.Size(21, 13)
         Me.label1.TabIndex = 17
         Me.label1.Text = "ID:"
         '
         'groupBox1
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
         Me.groupBox1.TabIndex = 21
         Me.groupBox1.TabStop = False
         Me.groupBox1.Text = "Scheduled Performing Physician Name"
         '
         'textBoxSuffix
         '
         Me.textBoxSuffix.Location = New System.Drawing.Point(447, 42)
         Me.textBoxSuffix.Name = "textBoxSuffix"
         Me.textBoxSuffix.Size = New System.Drawing.Size(74, 20)
         Me.textBoxSuffix.TabIndex = 12
         '
         'label6
         '
         Me.label6.AutoSize = True
         Me.label6.Location = New System.Drawing.Point(444, 26)
         Me.label6.Name = "label6"
         Me.label6.Size = New System.Drawing.Size(36, 13)
         Me.label6.TabIndex = 13
         Me.label6.Text = "Suffix:"
         '
         'textBoxFamily
         '
         Me.textBoxFamily.Location = New System.Drawing.Point(265, 42)
         Me.textBoxFamily.Name = "textBoxFamily"
         Me.textBoxFamily.Size = New System.Drawing.Size(180, 20)
         Me.textBoxFamily.TabIndex = 10
         Me.textBoxFamily.Tag = ""
         '
         'label5
         '
         Me.label5.AutoSize = True
         Me.label5.Location = New System.Drawing.Point(262, 26)
         Me.label5.Name = "label5"
         Me.label5.Size = New System.Drawing.Size(39, 13)
         Me.label5.TabIndex = 11
         Me.label5.Text = "Family:"
         '
         'textBoxGiven
         '
         Me.textBoxGiven.Location = New System.Drawing.Point(83, 42)
         Me.textBoxGiven.Name = "textBoxGiven"
         Me.textBoxGiven.Size = New System.Drawing.Size(180, 20)
         Me.textBoxGiven.TabIndex = 8
         Me.textBoxGiven.Tag = ""
         '
         'label3
         '
         Me.label3.AutoSize = True
         Me.label3.Location = New System.Drawing.Point(80, 26)
         Me.label3.Name = "label3"
         Me.label3.Size = New System.Drawing.Size(38, 13)
         Me.label3.TabIndex = 9
         Me.label3.Text = "Given:"
         '
         'textBoxPrefix
         '
         Me.textBoxPrefix.Location = New System.Drawing.Point(7, 42)
         Me.textBoxPrefix.Name = "textBoxPrefix"
         Me.textBoxPrefix.Size = New System.Drawing.Size(74, 20)
         Me.textBoxPrefix.TabIndex = 6
         '
         'label4
         '
         Me.label4.AutoSize = True
         Me.label4.Location = New System.Drawing.Point(4, 26)
         Me.label4.Name = "label4"
         Me.label4.Size = New System.Drawing.Size(36, 13)
         Me.label4.TabIndex = 7
         Me.label4.Text = "Prefix:"
         '
         'label8
         '
         Me.label8.AutoSize = True
         Me.label8.Location = New System.Drawing.Point(419, 88)
         Me.label8.Name = "label8"
         Me.label8.Size = New System.Drawing.Size(49, 13)
         Me.label8.TabIndex = 24
         Me.label8.Text = "Modality:"
         '
         'dateTimePickerStartDate
         '
         Me.dateTimePickerStartDate.BackColor = System.Drawing.Color.LemonChiffon
         Me.dateTimePickerStartDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
         Me.dateTimePickerStartDate.Location = New System.Drawing.Point(284, 105)
         Me.dateTimePickerStartDate.Name = "dateTimePickerStartDate"
         Me.dateTimePickerStartDate.Size = New System.Drawing.Size(132, 20)
         Me.dateTimePickerStartDate.TabIndex = 23
         Me.dateTimePickerStartDate.Tag = "Required"
         '
         'label7
         '
         Me.label7.AutoSize = True
         Me.label7.Location = New System.Drawing.Point(281, 89)
         Me.label7.Name = "label7"
         Me.label7.Size = New System.Drawing.Size(58, 13)
         Me.label7.TabIndex = 22
         Me.label7.Text = "Start Date:"
         '
         'buttonDeleteSP
         '
         Me.buttonDeleteSP.Location = New System.Drawing.Point(471, 326)
         Me.buttonDeleteSP.Name = "buttonDeleteSP"
         Me.buttonDeleteSP.Size = New System.Drawing.Size(75, 23)
         Me.buttonDeleteSP.TabIndex = 39
         Me.buttonDeleteSP.Text = "Delete"
         Me.buttonDeleteSP.UseVisualStyleBackColor = True
         '
         'buttonEditSP
         '
         Me.buttonEditSP.Location = New System.Drawing.Point(471, 299)
         Me.buttonEditSP.Name = "buttonEditSP"
         Me.buttonEditSP.Size = New System.Drawing.Size(75, 23)
         Me.buttonEditSP.TabIndex = 38
         Me.buttonEditSP.Text = "Edit"
         Me.buttonEditSP.UseVisualStyleBackColor = True
         '
         'buttonAddSP
         '
         Me.buttonAddSP.Location = New System.Drawing.Point(471, 272)
         Me.buttonAddSP.Name = "buttonAddSP"
         Me.buttonAddSP.Size = New System.Drawing.Size(75, 23)
         Me.buttonAddSP.TabIndex = 37
         Me.buttonAddSP.Text = "Add"
         Me.buttonAddSP.UseVisualStyleBackColor = True
         '
         'listViewSPCS
         '
         Me.listViewSPCS.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.columnHeader1, Me.columnHeader2, Me.columnHeader3, Me.columnHeader4})
         Me.listViewSPCS.FullRowSelect = True
         Me.listViewSPCS.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
         Me.listViewSPCS.HideSelection = False
         Me.listViewSPCS.Location = New System.Drawing.Point(22, 272)
         Me.listViewSPCS.Name = "listViewSPCS"
         Me.listViewSPCS.Size = New System.Drawing.Size(446, 77)
         Me.listViewSPCS.TabIndex = 36
         Me.listViewSPCS.UseCompatibleStateImageBehavior = False
         Me.listViewSPCS.View = System.Windows.Forms.View.Details
         '
         'columnHeader1
         '
         Me.columnHeader1.Text = "Code Value"
         Me.columnHeader1.Width = 73
         '
         'columnHeader2
         '
         Me.columnHeader2.Text = "Code Scheme Designator"
         Me.columnHeader2.Width = 139
         '
         'columnHeader3
         '
         Me.columnHeader3.Text = "Code Meaning"
         Me.columnHeader3.Width = 94
         '
         'columnHeader4
         '
         Me.columnHeader4.Text = "Code Scheme Version"
         Me.columnHeader4.Width = 120
         '
         'label2
         '
         Me.label2.AutoSize = True
         Me.label2.Location = New System.Drawing.Point(19, 256)
         Me.label2.Name = "label2"
         Me.label2.Size = New System.Drawing.Size(183, 13)
         Me.label2.TabIndex = 35
         Me.label2.Text = "Scheduled Protocol Code Sequence:"
         '
         'label9
         '
         Me.label9.AutoSize = True
         Me.label9.Location = New System.Drawing.Point(19, 207)
         Me.label9.Name = "label9"
         Me.label9.Size = New System.Drawing.Size(63, 13)
         Me.label9.TabIndex = 40
         Me.label9.Text = "Description:"
         '
         'textBoxDescription
         '
         Me.textBoxDescription.BackColor = System.Drawing.SystemColors.Window
         Me.textBoxDescription.Location = New System.Drawing.Point(22, 224)
         Me.textBoxDescription.Multiline = True
         Me.textBoxDescription.Name = "textBoxDescription"
         Me.textBoxDescription.Size = New System.Drawing.Size(259, 29)
         Me.textBoxDescription.TabIndex = 41
         Me.textBoxDescription.Tag = "Required"
         '
         'textBoxScheduledStationAE
         '
         Me.textBoxScheduledStationAE.BackColor = System.Drawing.SystemColors.Window
         Me.textBoxScheduledStationAE.Location = New System.Drawing.Point(287, 223)
         Me.textBoxScheduledStationAE.Multiline = True
         Me.textBoxScheduledStationAE.Name = "textBoxScheduledStationAE"
         Me.textBoxScheduledStationAE.Size = New System.Drawing.Size(259, 30)
         Me.textBoxScheduledStationAE.TabIndex = 43
         Me.textBoxScheduledStationAE.Tag = "Required"
         '
         'label11
         '
         Me.label11.AutoSize = True
         Me.label11.Location = New System.Drawing.Point(284, 207)
         Me.label11.Name = "label11"
         Me.label11.Size = New System.Drawing.Size(142, 13)
         Me.label11.TabIndex = 42
         Me.label11.Text = "Scheduled Station AE Titles:"
         '
         'errorProvider
         '
         Me.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
         Me.errorProvider.ContainerControl = Me
         '
         'comboBoxModality
         '
         Me.comboBoxModality.BackColor = System.Drawing.SystemColors.Window
         Me.comboBoxModality.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
         Me.comboBoxModality.FormattingEnabled = True
         Me.comboBoxModality.Location = New System.Drawing.Point(423, 104)
         Me.comboBoxModality.Name = "comboBoxModality"
         Me.comboBoxModality.Size = New System.Drawing.Size(121, 21)
         Me.comboBoxModality.TabIndex = 45
         Me.comboBoxModality.Tag = "Required"
         '
         'comboBoxId
         '
         Me.comboBoxId.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
         Me.comboBoxId.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
         Me.comboBoxId.FormattingEnabled = True
         Me.comboBoxId.Location = New System.Drawing.Point(22, 105)
         Me.comboBoxId.Name = "comboBoxId"
         Me.comboBoxId.Size = New System.Drawing.Size(132, 21)
         Me.comboBoxId.TabIndex = 46
         Me.comboBoxId.Tag = "required"
         '
         'ScheduledProcedureStepPage
         '
         Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.Controls.Add(Me.comboBoxId)
         Me.Controls.Add(Me.comboBoxModality)
         Me.Controls.Add(Me.textBoxScheduledStationAE)
         Me.Controls.Add(Me.label11)
         Me.Controls.Add(Me.textBoxDescription)
         Me.Controls.Add(Me.label9)
         Me.Controls.Add(Me.buttonDeleteSP)
         Me.Controls.Add(Me.buttonEditSP)
         Me.Controls.Add(Me.buttonAddSP)
         Me.Controls.Add(Me.listViewSPCS)
         Me.Controls.Add(Me.label2)
         Me.Controls.Add(Me.label8)
         Me.Controls.Add(Me.dateTimePickerStartDate)
         Me.Controls.Add(Me.label7)
         Me.Controls.Add(Me.groupBox1)
         Me.Controls.Add(Me.textBoxLocation)
         Me.Controls.Add(Me.label10)
         Me.Controls.Add(Me.label1)
         Me.Name = "ScheduledProcedureStepPage"
         Me.Controls.SetChildIndex(Me.TopBannerPanel, 0)
         Me.Controls.SetChildIndex(Me.label1, 0)
         Me.Controls.SetChildIndex(Me.label10, 0)
         Me.Controls.SetChildIndex(Me.textBoxLocation, 0)
         Me.Controls.SetChildIndex(Me.groupBox1, 0)
         Me.Controls.SetChildIndex(Me.label7, 0)
         Me.Controls.SetChildIndex(Me.dateTimePickerStartDate, 0)
         Me.Controls.SetChildIndex(Me.label8, 0)
         Me.Controls.SetChildIndex(Me.label2, 0)
         Me.Controls.SetChildIndex(Me.listViewSPCS, 0)
         Me.Controls.SetChildIndex(Me.buttonAddSP, 0)
         Me.Controls.SetChildIndex(Me.buttonEditSP, 0)
         Me.Controls.SetChildIndex(Me.buttonDeleteSP, 0)
         Me.Controls.SetChildIndex(Me.label9, 0)
         Me.Controls.SetChildIndex(Me.textBoxDescription, 0)
         Me.Controls.SetChildIndex(Me.label11, 0)
         Me.Controls.SetChildIndex(Me.textBoxScheduledStationAE, 0)
         Me.Controls.SetChildIndex(Me.comboBoxModality, 0)
         Me.Controls.SetChildIndex(Me.comboBoxId, 0)
         Me.TopBannerPanel.ResumeLayout(False)
         CType(Me.IconPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
         Me.groupBox1.ResumeLayout(False)
         Me.groupBox1.PerformLayout()
         CType(Me.errorProvider, System.ComponentModel.ISupportInitialize).EndInit()
         Me.ResumeLayout(False)
         Me.PerformLayout()

      End Sub

		#End Region

		Private textBoxLocation As System.Windows.Forms.TextBox
		Private label10 As System.Windows.Forms.Label
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
		Private label8 As System.Windows.Forms.Label
		Private dateTimePickerStartDate As System.Windows.Forms.DateTimePicker
		Private label7 As System.Windows.Forms.Label
		Private WithEvents buttonDeleteSP As System.Windows.Forms.Button
		Private WithEvents buttonEditSP As System.Windows.Forms.Button
		Private WithEvents buttonAddSP As System.Windows.Forms.Button
		Private listViewSPCS As System.Windows.Forms.ListView
		Private label2 As System.Windows.Forms.Label
		Private label9 As System.Windows.Forms.Label
		Private textBoxDescription As System.Windows.Forms.TextBox
		Private textBoxScheduledStationAE As System.Windows.Forms.TextBox
		Private label11 As System.Windows.Forms.Label
		Private columnHeader1 As System.Windows.Forms.ColumnHeader
		Private columnHeader2 As System.Windows.Forms.ColumnHeader
		Private columnHeader3 As System.Windows.Forms.ColumnHeader
		Private columnHeader4 As System.Windows.Forms.ColumnHeader		
		Private errorProvider As System.Windows.Forms.ErrorProvider
		Private comboBoxModality As System.Windows.Forms.ComboBox
		Private WithEvents comboBoxId As System.Windows.Forms.ComboBox
	End Class
End Namespace
