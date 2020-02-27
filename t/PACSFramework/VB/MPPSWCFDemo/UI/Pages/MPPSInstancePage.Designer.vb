Imports Microsoft.VisualBasic
Imports System
Namespace MPPSWCFDemo.UI.Pages
	Public Partial Class MPPSInstancePage
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

		#Region "Component Designer generated code"

		''' <summary> 
		''' Required method for Designer support - do not modify 
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
		   Me.components = New System.ComponentModel.Container()
		   Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MPPSInstancePage))
		   Me.label1 = New System.Windows.Forms.Label()
		   Me.label10 = New System.Windows.Forms.Label()
		   Me.textBoxPPSId = New System.Windows.Forms.TextBox()
		   Me.textBoxStationName = New System.Windows.Forms.TextBox()
		   Me.label11 = New System.Windows.Forms.Label()
		   Me.textBoxStationAE = New System.Windows.Forms.TextBox()
		   Me.label12 = New System.Windows.Forms.Label()
		   Me.errorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
		   Me.textBoxLocation = New System.Windows.Forms.TextBox()
		   Me.label2 = New System.Windows.Forms.Label()
		   Me.label3 = New System.Windows.Forms.Label()
		   Me.dateTimePickerStartDate = New System.Windows.Forms.DateTimePicker()
		   Me.label4 = New System.Windows.Forms.Label()
		   Me.comboBoxStatus = New System.Windows.Forms.ComboBox()
		   Me.label5 = New System.Windows.Forms.Label()
		   Me.comboBoxModality = New System.Windows.Forms.ComboBox()
		   Me.label6 = New System.Windows.Forms.Label()
		   Me.textBoxStudyInstance = New System.Windows.Forms.TextBox()
		   Me.label7 = New System.Windows.Forms.Label()
		   Me.textBoxDescription = New System.Windows.Forms.TextBox()
		   Me.label8 = New System.Windows.Forms.Label()
		   Me.textBoxComments = New System.Windows.Forms.TextBox()
		   Me.label9 = New System.Windows.Forms.Label()
		   Me.dateTimePickerStartTime = New System.Windows.Forms.DateTimePicker()
		   Me.label13 = New System.Windows.Forms.Label()
		   Me.dateTimePickerEndDate = New System.Windows.Forms.DateTimePicker()
		   Me.label14 = New System.Windows.Forms.Label()
		   Me.dateTimePickerEndTime = New System.Windows.Forms.DateTimePicker()
		   Me.toolTip1 = New System.Windows.Forms.ToolTip(Me.components)
		   Me.buttonQuery = New System.Windows.Forms.Button()
		   Me.buttonDelete = New System.Windows.Forms.Button()
		   Me.linkLabelPatient = New System.Windows.Forms.LinkLabel()
		   Me.textBoxMPPSInstance = New System.Windows.Forms.TextBox()
		   Me.labelPatient = New System.Windows.Forms.Label()
		   Me.TopBannerPanel.SuspendLayout()
		   CType(Me.IconPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
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
		   Me.TitleDescriptionLabel.Text = "Edit an existing modality performed procedure step instance."
		   ' 
		   ' TitleLabel
		   ' 
		   Me.TitleLabel.Size = New System.Drawing.Size(260, 31)
		   Me.TitleLabel.Text = "Modality Peformed Procedure Step (Step 1)"
		   ' 
		   ' IconPictureBox
		   ' 
         Me.IconPictureBox.Image = My.Resources.Logo
		   Me.IconPictureBox.Location = New System.Drawing.Point(321, 22)
		   Me.IconPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
		   ' 
		   ' label1
		   ' 
		   Me.label1.AutoSize = True
		   Me.label1.Location = New System.Drawing.Point(19, 89)
		   Me.label1.Name = "label1"
		   Me.label1.Size = New System.Drawing.Size(106, 13)
		   Me.label1.TabIndex = 0
		   Me.label1.Text = "MPPS Instance UID:"
		   ' 
		   ' label10
		   ' 
		   Me.label10.AutoSize = True
		   Me.label10.Location = New System.Drawing.Point(284, 89)
		   Me.label10.Name = "label10"
		   Me.label10.Size = New System.Drawing.Size(149, 13)
		   Me.label10.TabIndex = 1
		   Me.label10.Text = "Performed Procedure Step ID:"
		   ' 
		   ' textBoxPPSId
		   ' 
		   Me.textBoxPPSId.Location = New System.Drawing.Point(287, 105)
		   Me.textBoxPPSId.Name = "textBoxPPSId"
		   Me.textBoxPPSId.Size = New System.Drawing.Size(259, 20)
		   Me.textBoxPPSId.TabIndex = 3
		   Me.textBoxPPSId.Tag = "Required"
		   ' 
		   ' textBoxStationName
		   ' 
		   Me.textBoxStationName.Location = New System.Drawing.Point(287, 145)
		   Me.textBoxStationName.Name = "textBoxStationName"
		   Me.textBoxStationName.Size = New System.Drawing.Size(259, 20)
		   Me.textBoxStationName.TabIndex = 5
		   ' 
		   ' label11
		   ' 
		   Me.label11.AutoSize = True
		   Me.label11.Location = New System.Drawing.Point(284, 128)
		   Me.label11.Name = "label11"
		   Me.label11.Size = New System.Drawing.Size(125, 13)
		   Me.label11.TabIndex = 5
		   Me.label11.Text = "Performed Station Name:"
		   ' 
		   ' textBoxStationAE
		   ' 
		   Me.textBoxStationAE.Location = New System.Drawing.Point(22, 145)
		   Me.textBoxStationAE.Name = "textBoxStationAE"
		   Me.textBoxStationAE.Size = New System.Drawing.Size(259, 20)
		   Me.textBoxStationAE.TabIndex = 4
		   Me.textBoxStationAE.Tag = "Required"
		   ' 
		   ' label12
		   ' 
		   Me.label12.AutoSize = True
		   Me.label12.Location = New System.Drawing.Point(19, 129)
		   Me.label12.Name = "label12"
		   Me.label12.Size = New System.Drawing.Size(134, 13)
		   Me.label12.TabIndex = 4
		   Me.label12.Text = "Performed Station AE Title:"
		   ' 
		   ' errorProvider
		   ' 
		   Me.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
		   Me.errorProvider.ContainerControl = Me
		   ' 
		   ' textBoxLocation
		   ' 
		   Me.textBoxLocation.Location = New System.Drawing.Point(22, 184)
		   Me.textBoxLocation.Name = "textBoxLocation"
		   Me.textBoxLocation.Size = New System.Drawing.Size(259, 20)
		   Me.textBoxLocation.TabIndex = 6
		   Me.textBoxLocation.Tag = ""
		   ' 
		   ' label2
		   ' 
		   Me.label2.AutoSize = True
		   Me.label2.Location = New System.Drawing.Point(19, 168)
		   Me.label2.Name = "label2"
		   Me.label2.Size = New System.Drawing.Size(102, 13)
		   Me.label2.TabIndex = 17
		   Me.label2.Text = "Performed Location:"
		   ' 
		   ' label3
		   ' 
		   Me.label3.AutoSize = True
		   Me.label3.Location = New System.Drawing.Point(19, 207)
		   Me.label3.Name = "label3"
		   Me.label3.Size = New System.Drawing.Size(58, 13)
		   Me.label3.TabIndex = 18
		   Me.label3.Text = "Start Date:"
		   ' 
		   ' dateTimePickerStartDate
		   ' 
		   Me.dateTimePickerStartDate.Enabled = False
		   Me.dateTimePickerStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short
		   Me.dateTimePickerStartDate.Location = New System.Drawing.Point(22, 223)
		   Me.dateTimePickerStartDate.Name = "dateTimePickerStartDate"
		   Me.dateTimePickerStartDate.Size = New System.Drawing.Size(131, 20)
		   Me.dateTimePickerStartDate.TabIndex = 8
		   Me.dateTimePickerStartDate.Tag = "Required"
		   ' 
		   ' label4
		   ' 
		   Me.label4.AutoSize = True
		   Me.label4.Location = New System.Drawing.Point(284, 168)
		   Me.label4.Name = "label4"
		   Me.label4.Size = New System.Drawing.Size(40, 13)
		   Me.label4.TabIndex = 20
		   Me.label4.Text = "Status:"
		   ' 
		   ' comboBoxStatus
		   ' 
		   Me.comboBoxStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		   Me.comboBoxStatus.FormattingEnabled = True
		   Me.comboBoxStatus.Items.AddRange(New Object() { "IN PROGRESS", "COMPLETED", "DISCONTINUED"})
		   Me.comboBoxStatus.Location = New System.Drawing.Point(287, 183)
		   Me.comboBoxStatus.Name = "comboBoxStatus"
		   Me.comboBoxStatus.Size = New System.Drawing.Size(259, 21)
		   Me.comboBoxStatus.TabIndex = 7
		   Me.comboBoxStatus.Tag = "Required"
		   ' 
		   ' label5
		   ' 
		   Me.label5.AutoSize = True
		   Me.label5.Location = New System.Drawing.Point(284, 207)
		   Me.label5.Name = "label5"
		   Me.label5.Size = New System.Drawing.Size(55, 13)
		   Me.label5.TabIndex = 22
		   Me.label5.Text = "End Date:"
		   ' 
		   ' comboBoxModality
		   ' 
		   Me.comboBoxModality.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		   Me.comboBoxModality.FormattingEnabled = True
		   Me.comboBoxModality.Location = New System.Drawing.Point(22, 261)
		   Me.comboBoxModality.Name = "comboBoxModality"
		   Me.comboBoxModality.Size = New System.Drawing.Size(255, 21)
		   Me.comboBoxModality.TabIndex = 12
		   Me.comboBoxModality.Tag = "Required"
		   ' 
		   ' label6
		   ' 
		   Me.label6.AutoSize = True
		   Me.label6.Location = New System.Drawing.Point(19, 246)
		   Me.label6.Name = "label6"
		   Me.label6.Size = New System.Drawing.Size(49, 13)
		   Me.label6.TabIndex = 24
		   Me.label6.Text = "Modality:"
		   ' 
		   ' textBoxStudyInstance
		   ' 
		   Me.textBoxStudyInstance.Location = New System.Drawing.Point(287, 262)
		   Me.textBoxStudyInstance.Name = "textBoxStudyInstance"
		   Me.textBoxStudyInstance.ReadOnly = True
		   Me.textBoxStudyInstance.Size = New System.Drawing.Size(259, 20)
		   Me.textBoxStudyInstance.TabIndex = 13
		   Me.textBoxStudyInstance.Tag = "Required"
		   ' 
		   ' label7
		   ' 
		   Me.label7.AutoSize = True
		   Me.label7.Location = New System.Drawing.Point(284, 246)
		   Me.label7.Name = "label7"
		   Me.label7.Size = New System.Drawing.Size(103, 13)
		   Me.label7.TabIndex = 27
		   Me.label7.Text = "Study Instance UID:"
		   ' 
		   ' textBoxDescription
		   ' 
		   Me.textBoxDescription.Location = New System.Drawing.Point(22, 301)
		   Me.textBoxDescription.Multiline = True
		   Me.textBoxDescription.Name = "textBoxDescription"
		   Me.textBoxDescription.Size = New System.Drawing.Size(259, 65)
		   Me.textBoxDescription.TabIndex = 14
		   Me.textBoxDescription.Tag = ""
		   ' 
		   ' label8
		   ' 
		   Me.label8.AutoSize = True
		   Me.label8.Location = New System.Drawing.Point(19, 285)
		   Me.label8.Name = "label8"
		   Me.label8.Size = New System.Drawing.Size(63, 13)
		   Me.label8.TabIndex = 29
		   Me.label8.Text = "Description:"
		   ' 
		   ' textBoxComments
		   ' 
		   Me.textBoxComments.Location = New System.Drawing.Point(287, 301)
		   Me.textBoxComments.Multiline = True
		   Me.textBoxComments.Name = "textBoxComments"
		   Me.textBoxComments.Size = New System.Drawing.Size(259, 65)
		   Me.textBoxComments.TabIndex = 15
		   Me.textBoxComments.Tag = ""
		   ' 
		   ' label9
		   ' 
		   Me.label9.AutoSize = True
		   Me.label9.Location = New System.Drawing.Point(284, 285)
		   Me.label9.Name = "label9"
		   Me.label9.Size = New System.Drawing.Size(59, 13)
		   Me.label9.TabIndex = 31
		   Me.label9.Text = "Comments:"
		   ' 
		   ' dateTimePickerStartTime
		   ' 
		   Me.dateTimePickerStartTime.Enabled = False
		   Me.dateTimePickerStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Time
		   Me.dateTimePickerStartTime.Location = New System.Drawing.Point(159, 223)
		   Me.dateTimePickerStartTime.Name = "dateTimePickerStartTime"
		   Me.dateTimePickerStartTime.ShowUpDown = True
		   Me.dateTimePickerStartTime.Size = New System.Drawing.Size(114, 20)
		   Me.dateTimePickerStartTime.TabIndex = 9
		   Me.dateTimePickerStartTime.Tag = "Required"
		   ' 
		   ' label13
		   ' 
		   Me.label13.AutoSize = True
		   Me.label13.Location = New System.Drawing.Point(156, 207)
		   Me.label13.Name = "label13"
		   Me.label13.Size = New System.Drawing.Size(58, 13)
		   Me.label13.TabIndex = 32
		   Me.label13.Text = "Start Time:"
		   ' 
		   ' dateTimePickerEndDate
		   ' 
		   Me.dateTimePickerEndDate.Checked = False
		   Me.dateTimePickerEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short
		   Me.dateTimePickerEndDate.Location = New System.Drawing.Point(287, 223)
		   Me.dateTimePickerEndDate.Name = "dateTimePickerEndDate"
		   Me.dateTimePickerEndDate.ShowCheckBox = True
		   Me.dateTimePickerEndDate.Size = New System.Drawing.Size(131, 20)
		   Me.dateTimePickerEndDate.TabIndex = 10
		   Me.dateTimePickerEndDate.Tag = ""
'		   Me.dateTimePickerEndDate.MouseDown += New System.Windows.Forms.MouseEventHandler(Me.dateTimePickerEndDate_MouseDown);
'		   Me.dateTimePickerEndDate.KeyDown += New System.Windows.Forms.KeyEventHandler(Me.dateTimePickerEndDate_KeyDown);
		   ' 
		   ' label14
		   ' 
		   Me.label14.AutoSize = True
		   Me.label14.Location = New System.Drawing.Point(429, 207)
		   Me.label14.Name = "label14"
		   Me.label14.Size = New System.Drawing.Size(55, 13)
		   Me.label14.TabIndex = 35
		   Me.label14.Text = "End Time:"
		   ' 
		   ' dateTimePickerEndTime
		   ' 
		   Me.dateTimePickerEndTime.Checked = False
		   Me.dateTimePickerEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Time
		   Me.dateTimePickerEndTime.Location = New System.Drawing.Point(432, 223)
		   Me.dateTimePickerEndTime.Name = "dateTimePickerEndTime"
		   Me.dateTimePickerEndTime.ShowCheckBox = True
		   Me.dateTimePickerEndTime.ShowUpDown = True
		   Me.dateTimePickerEndTime.Size = New System.Drawing.Size(114, 20)
		   Me.dateTimePickerEndTime.TabIndex = 11
		   Me.dateTimePickerEndTime.Tag = ""
'		   Me.dateTimePickerEndTime.MouseDown += New System.Windows.Forms.MouseEventHandler(Me.dateTimePickerEndTime_MouseDown);
'		   Me.dateTimePickerEndTime.KeyDown += New System.Windows.Forms.KeyEventHandler(Me.dateTimePickerEndTime_KeyDown);
		   ' 
		   ' buttonQuery
		   ' 
		   Me.buttonQuery.Image = (CType(resources.GetObject("buttonQuery.Image"), System.Drawing.Image))
		   Me.buttonQuery.Location = New System.Drawing.Point(220, 103)
		   Me.buttonQuery.Name = "buttonQuery"
		   Me.buttonQuery.Size = New System.Drawing.Size(31, 23)
		   Me.buttonQuery.TabIndex = 1
		   Me.toolTip1.SetToolTip(Me.buttonQuery, "Query MPPS")
		   Me.buttonQuery.UseVisualStyleBackColor = True
'		   Me.buttonQuery.Click += New System.EventHandler(Me.buttonQuery_Click);
		   ' 
		   ' buttonDelete
		   ' 
         Me.buttonDelete.Image = My.Resources.Delete
		   Me.buttonDelete.Location = New System.Drawing.Point(250, 103)
		   Me.buttonDelete.Name = "buttonDelete"
		   Me.buttonDelete.Size = New System.Drawing.Size(31, 23)
		   Me.buttonDelete.TabIndex = 2
		   Me.toolTip1.SetToolTip(Me.buttonDelete, "Delete MPPS Instance")
		   Me.buttonDelete.UseVisualStyleBackColor = True
'		   Me.buttonDelete.Click += New System.EventHandler(Me.buttonDelete_Click);
		   ' 
		   ' linkLabelPatient
		   ' 
		   Me.linkLabelPatient.AutoSize = True
		   Me.linkLabelPatient.Location = New System.Drawing.Point(19, 380)
		   Me.linkLabelPatient.Name = "linkLabelPatient"
		   Me.linkLabelPatient.Size = New System.Drawing.Size(43, 13)
		   Me.linkLabelPatient.TabIndex = 16
		   Me.linkLabelPatient.TabStop = True
		   Me.linkLabelPatient.Text = "Patient:"
		   Me.toolTip1.SetToolTip(Me.linkLabelPatient, "Click to edit patient info")
'		   Me.linkLabelPatient.LinkClicked += New System.Windows.Forms.LinkLabelLinkClickedEventHandler(Me.linkLabelPatient_LinkClicked);
		   ' 
		   ' textBoxMPPSInstance
		   ' 
		   Me.textBoxMPPSInstance.Location = New System.Drawing.Point(22, 105)
		   Me.textBoxMPPSInstance.Name = "textBoxMPPSInstance"
		   Me.textBoxMPPSInstance.ReadOnly = True
		   Me.textBoxMPPSInstance.Size = New System.Drawing.Size(197, 20)
		   Me.textBoxMPPSInstance.TabIndex = 0
		   ' 
		   ' labelPatient
		   ' 
		   Me.labelPatient.AutoSize = True
		   Me.labelPatient.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (CByte(0)))
		   Me.labelPatient.Location = New System.Drawing.Point(68, 380)
		   Me.labelPatient.Name = "labelPatient"
		   Me.labelPatient.Size = New System.Drawing.Size(0, 13)
		   Me.labelPatient.TabIndex = 42
		   ' 
		   ' MPPSInstancePage
		   ' 
		   Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
		   Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		   Me.Controls.Add(Me.labelPatient)
		   Me.Controls.Add(Me.linkLabelPatient)
		   Me.Controls.Add(Me.buttonDelete)
		   Me.Controls.Add(Me.textBoxMPPSInstance)
		   Me.Controls.Add(Me.buttonQuery)
		   Me.Controls.Add(Me.dateTimePickerEndTime)
		   Me.Controls.Add(Me.label14)
		   Me.Controls.Add(Me.dateTimePickerEndDate)
		   Me.Controls.Add(Me.dateTimePickerStartTime)
		   Me.Controls.Add(Me.label13)
		   Me.Controls.Add(Me.textBoxComments)
		   Me.Controls.Add(Me.label9)
		   Me.Controls.Add(Me.textBoxDescription)
		   Me.Controls.Add(Me.label8)
		   Me.Controls.Add(Me.textBoxStudyInstance)
		   Me.Controls.Add(Me.label7)
		   Me.Controls.Add(Me.comboBoxModality)
		   Me.Controls.Add(Me.label6)
		   Me.Controls.Add(Me.label5)
		   Me.Controls.Add(Me.comboBoxStatus)
		   Me.Controls.Add(Me.label4)
		   Me.Controls.Add(Me.dateTimePickerStartDate)
		   Me.Controls.Add(Me.label3)
		   Me.Controls.Add(Me.textBoxLocation)
		   Me.Controls.Add(Me.label2)
		   Me.Controls.Add(Me.textBoxStationName)
		   Me.Controls.Add(Me.label11)
		   Me.Controls.Add(Me.textBoxStationAE)
		   Me.Controls.Add(Me.label12)
		   Me.Controls.Add(Me.textBoxPPSId)
		   Me.Controls.Add(Me.label10)
		   Me.Controls.Add(Me.label1)
		   Me.Name = "MPPSInstancePage"
		   Me.Size = New System.Drawing.Size(556, 411)
'		   Me.Load += New System.EventHandler(Me.MPPSInstancePage_Load);
'		   Me.Paint += New System.Windows.Forms.PaintEventHandler(Me.MPPSInstancePage_Paint);
		   Me.Controls.SetChildIndex(Me.label1, 0)
		   Me.Controls.SetChildIndex(Me.label10, 0)
		   Me.Controls.SetChildIndex(Me.textBoxPPSId, 0)
		   Me.Controls.SetChildIndex(Me.label12, 0)
		   Me.Controls.SetChildIndex(Me.textBoxStationAE, 0)
		   Me.Controls.SetChildIndex(Me.label11, 0)
		   Me.Controls.SetChildIndex(Me.textBoxStationName, 0)
		   Me.Controls.SetChildIndex(Me.label2, 0)
		   Me.Controls.SetChildIndex(Me.textBoxLocation, 0)
		   Me.Controls.SetChildIndex(Me.label3, 0)
		   Me.Controls.SetChildIndex(Me.dateTimePickerStartDate, 0)
		   Me.Controls.SetChildIndex(Me.label4, 0)
		   Me.Controls.SetChildIndex(Me.comboBoxStatus, 0)
		   Me.Controls.SetChildIndex(Me.label5, 0)
		   Me.Controls.SetChildIndex(Me.TopBannerPanel, 0)
		   Me.Controls.SetChildIndex(Me.label6, 0)
		   Me.Controls.SetChildIndex(Me.comboBoxModality, 0)
		   Me.Controls.SetChildIndex(Me.label7, 0)
		   Me.Controls.SetChildIndex(Me.textBoxStudyInstance, 0)
		   Me.Controls.SetChildIndex(Me.label8, 0)
		   Me.Controls.SetChildIndex(Me.textBoxDescription, 0)
		   Me.Controls.SetChildIndex(Me.label9, 0)
		   Me.Controls.SetChildIndex(Me.textBoxComments, 0)
		   Me.Controls.SetChildIndex(Me.label13, 0)
		   Me.Controls.SetChildIndex(Me.dateTimePickerStartTime, 0)
		   Me.Controls.SetChildIndex(Me.dateTimePickerEndDate, 0)
		   Me.Controls.SetChildIndex(Me.label14, 0)
		   Me.Controls.SetChildIndex(Me.dateTimePickerEndTime, 0)
		   Me.Controls.SetChildIndex(Me.buttonQuery, 0)
		   Me.Controls.SetChildIndex(Me.textBoxMPPSInstance, 0)
		   Me.Controls.SetChildIndex(Me.buttonDelete, 0)
		   Me.Controls.SetChildIndex(Me.linkLabelPatient, 0)
		   Me.Controls.SetChildIndex(Me.labelPatient, 0)
		   Me.TopBannerPanel.ResumeLayout(False)
		   CType(Me.IconPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
		   CType(Me.errorProvider, System.ComponentModel.ISupportInitialize).EndInit()
		   Me.ResumeLayout(False)
		   Me.PerformLayout()

		End Sub

		#End Region

		Private label1 As System.Windows.Forms.Label
		Private label10 As System.Windows.Forms.Label
		Private textBoxPPSId As System.Windows.Forms.TextBox
		Private textBoxStationName As System.Windows.Forms.TextBox
		Private label11 As System.Windows.Forms.Label
		Private textBoxStationAE As System.Windows.Forms.TextBox
		Private label12 As System.Windows.Forms.Label
		Private errorProvider As System.Windows.Forms.ErrorProvider
		Private comboBoxStatus As System.Windows.Forms.ComboBox
		Private label4 As System.Windows.Forms.Label
		Private dateTimePickerStartDate As System.Windows.Forms.DateTimePicker
		Private label3 As System.Windows.Forms.Label
		Private textBoxLocation As System.Windows.Forms.TextBox
		Private label2 As System.Windows.Forms.Label
		Private textBoxStudyInstance As System.Windows.Forms.TextBox
		Private label7 As System.Windows.Forms.Label
		Private comboBoxModality As System.Windows.Forms.ComboBox
		Private label6 As System.Windows.Forms.Label
		Private label5 As System.Windows.Forms.Label
		Private textBoxComments As System.Windows.Forms.TextBox
		Private label9 As System.Windows.Forms.Label
		Private textBoxDescription As System.Windows.Forms.TextBox
		Private label8 As System.Windows.Forms.Label
		Private dateTimePickerStartTime As System.Windows.Forms.DateTimePicker
		Private label13 As System.Windows.Forms.Label
		Private WithEvents dateTimePickerEndDate As System.Windows.Forms.DateTimePicker
		Private WithEvents dateTimePickerEndTime As System.Windows.Forms.DateTimePicker
		Private label14 As System.Windows.Forms.Label
		Private toolTip1 As System.Windows.Forms.ToolTip
		Private WithEvents buttonQuery As System.Windows.Forms.Button
		Private textBoxMPPSInstance As System.Windows.Forms.TextBox
		Private WithEvents buttonDelete As System.Windows.Forms.Button
		Private WithEvents linkLabelPatient As System.Windows.Forms.LinkLabel
		Private labelPatient As System.Windows.Forms.Label
	End Class
End Namespace
