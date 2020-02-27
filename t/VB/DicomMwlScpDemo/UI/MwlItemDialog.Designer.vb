Imports Microsoft.VisualBasic
Imports System
Namespace DicomDemo
	Public Partial Class MwlItemDialog
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
			Me.btnOk = New System.Windows.Forms.Button()
			Me.btnCancel = New System.Windows.Forms.Button()
			Me.txtAccessionNumber = New System.Windows.Forms.TextBox()
			Me.txtModality = New System.Windows.Forms.TextBox()
			Me.txtInstitutionName = New System.Windows.Forms.TextBox()
			Me.txtReferringPhysicianName = New System.Windows.Forms.TextBox()
			Me.txtPatientName = New System.Windows.Forms.TextBox()
			Me.txtPatientID = New System.Windows.Forms.TextBox()
			Me.txtPatientBirthDate = New System.Windows.Forms.TextBox()
			Me.txtStartDate = New System.Windows.Forms.TextBox()
			Me.txtWeight = New System.Windows.Forms.TextBox()
			Me.txtStudyInstanceUID = New System.Windows.Forms.TextBox()
			Me.txtRequestingPhysician = New System.Windows.Forms.TextBox()
			Me.txtRequestedProcedureDescription = New System.Windows.Forms.TextBox()
			Me.txtAdmissionID = New System.Windows.Forms.TextBox()
			Me.txtDescription = New System.Windows.Forms.TextBox()
			Me.txtStartTime = New System.Windows.Forms.TextBox()
			Me.txtID = New System.Windows.Forms.TextBox()
			Me.txtPhysicianName = New System.Windows.Forms.TextBox()
			Me.txtLocation = New System.Windows.Forms.TextBox()
			Me.txtStationAETitle = New System.Windows.Forms.TextBox()
			Me.txtRequestedProcedureID = New System.Windows.Forms.TextBox()
			Me.txtReasonForProcedure = New System.Windows.Forms.TextBox()
			Me.cboProcedurePriority = New System.Windows.Forms.ComboBox()
			Me.cboSex = New System.Windows.Forms.ComboBox()
			Me.groupBox1 = New System.Windows.Forms.GroupBox()
			Me.label18 = New System.Windows.Forms.Label()
			Me.label15 = New System.Windows.Forms.Label()
			Me.label16 = New System.Windows.Forms.Label()
			Me.label21 = New System.Windows.Forms.Label()
			Me.label17 = New System.Windows.Forms.Label()
			Me.label20 = New System.Windows.Forms.Label()
			Me.label19 = New System.Windows.Forms.Label()
			Me.label1 = New System.Windows.Forms.Label()
			Me.label2 = New System.Windows.Forms.Label()
			Me.label3 = New System.Windows.Forms.Label()
			Me.label4 = New System.Windows.Forms.Label()
			Me.label5 = New System.Windows.Forms.Label()
			Me.label7 = New System.Windows.Forms.Label()
			Me.label8 = New System.Windows.Forms.Label()
			Me.label9 = New System.Windows.Forms.Label()
			Me.label10 = New System.Windows.Forms.Label()
			Me.label11 = New System.Windows.Forms.Label()
			Me.label12 = New System.Windows.Forms.Label()
			Me.label13 = New System.Windows.Forms.Label()
			Me.label14 = New System.Windows.Forms.Label()
			Me.label22 = New System.Windows.Forms.Label()
			Me.label23 = New System.Windows.Forms.Label()
			Me.label24 = New System.Windows.Forms.Label()
			Me.groupBox1.SuspendLayout()
			Me.SuspendLayout()
			' 
			' btnOk
			' 
			Me.btnOk.Location = New System.Drawing.Point(361, 419)
			Me.btnOk.Name = "btnOk"
			Me.btnOk.Size = New System.Drawing.Size(75, 23)
			Me.btnOk.TabIndex = 17
			Me.btnOk.Text = "OK"
			Me.btnOk.UseVisualStyleBackColor = True
'			Me.btnOk.Click += New System.EventHandler(Me.btnOk_Click);
			' 
			' btnCancel
			' 
			Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
			Me.btnCancel.Location = New System.Drawing.Point(444, 419)
			Me.btnCancel.Name = "btnCancel"
			Me.btnCancel.Size = New System.Drawing.Size(75, 23)
			Me.btnCancel.TabIndex = 18
			Me.btnCancel.Text = "Cancel"
			Me.btnCancel.UseVisualStyleBackColor = True
'			Me.btnCancel.Click += New System.EventHandler(Me.btnCancel_Click);
			' 
			' txtAccessionNumber
			' 
			Me.txtAccessionNumber.Location = New System.Drawing.Point(15, 25)
			Me.txtAccessionNumber.Name = "txtAccessionNumber"
			Me.txtAccessionNumber.Size = New System.Drawing.Size(94, 20)
			Me.txtAccessionNumber.TabIndex = 0
			' 
			' txtModality
			' 
			Me.txtModality.Location = New System.Drawing.Point(124, 25)
			Me.txtModality.Name = "txtModality"
			Me.txtModality.Size = New System.Drawing.Size(49, 20)
			Me.txtModality.TabIndex = 1
			' 
			' txtInstitutionName
			' 
			Me.txtInstitutionName.Location = New System.Drawing.Point(188, 25)
			Me.txtInstitutionName.Name = "txtInstitutionName"
			Me.txtInstitutionName.Size = New System.Drawing.Size(158, 20)
			Me.txtInstitutionName.TabIndex = 2
			' 
			' txtReferringPhysicianName
			' 
			Me.txtReferringPhysicianName.Location = New System.Drawing.Point(361, 25)
			Me.txtReferringPhysicianName.Name = "txtReferringPhysicianName"
			Me.txtReferringPhysicianName.Size = New System.Drawing.Size(158, 20)
			Me.txtReferringPhysicianName.TabIndex = 3
			' 
			' txtPatientName
			' 
			Me.txtPatientName.Location = New System.Drawing.Point(15, 71)
			Me.txtPatientName.Name = "txtPatientName"
			Me.txtPatientName.Size = New System.Drawing.Size(158, 20)
			Me.txtPatientName.TabIndex = 4
			' 
			' txtPatientID
			' 
			Me.txtPatientID.Location = New System.Drawing.Point(188, 71)
			Me.txtPatientID.Name = "txtPatientID"
			Me.txtPatientID.Size = New System.Drawing.Size(158, 20)
			Me.txtPatientID.TabIndex = 5
			' 
			' txtPatientBirthDate
			' 
			Me.txtPatientBirthDate.Location = New System.Drawing.Point(361, 71)
			Me.txtPatientBirthDate.Name = "txtPatientBirthDate"
			Me.txtPatientBirthDate.Size = New System.Drawing.Size(158, 20)
			Me.txtPatientBirthDate.TabIndex = 6
			' 
			' txtStartDate
			' 
			Me.txtStartDate.Location = New System.Drawing.Point(11, 32)
			Me.txtStartDate.Name = "txtStartDate"
			Me.txtStartDate.Size = New System.Drawing.Size(147, 20)
			Me.txtStartDate.TabIndex = 0
			' 
			' txtWeight
			' 
			Me.txtWeight.Location = New System.Drawing.Point(124, 118)
			Me.txtWeight.Name = "txtWeight"
			Me.txtWeight.Size = New System.Drawing.Size(49, 20)
			Me.txtWeight.TabIndex = 8
			' 
			' txtStudyInstanceUID
			' 
			Me.txtStudyInstanceUID.Location = New System.Drawing.Point(188, 117)
			Me.txtStudyInstanceUID.Name = "txtStudyInstanceUID"
			Me.txtStudyInstanceUID.Size = New System.Drawing.Size(158, 20)
			Me.txtStudyInstanceUID.TabIndex = 9
			' 
			' txtRequestingPhysician
			' 
			Me.txtRequestingPhysician.Location = New System.Drawing.Point(361, 118)
			Me.txtRequestingPhysician.Name = "txtRequestingPhysician"
			Me.txtRequestingPhysician.Size = New System.Drawing.Size(158, 20)
			Me.txtRequestingPhysician.TabIndex = 10
			' 
			' txtRequestedProcedureDescription
			' 
			Me.txtRequestedProcedureDescription.Location = New System.Drawing.Point(15, 163)
			Me.txtRequestedProcedureDescription.Name = "txtRequestedProcedureDescription"
			Me.txtRequestedProcedureDescription.Size = New System.Drawing.Size(158, 20)
			Me.txtRequestedProcedureDescription.TabIndex = 11
			' 
			' txtAdmissionID
			' 
			Me.txtAdmissionID.Location = New System.Drawing.Point(188, 163)
			Me.txtAdmissionID.Name = "txtAdmissionID"
			Me.txtAdmissionID.Size = New System.Drawing.Size(158, 20)
			Me.txtAdmissionID.TabIndex = 12
			' 
			' txtDescription
			' 
			Me.txtDescription.Location = New System.Drawing.Point(11, 79)
			Me.txtDescription.Name = "txtDescription"
			Me.txtDescription.Size = New System.Drawing.Size(147, 20)
			Me.txtDescription.TabIndex = 3
			' 
			' txtStartTime
			' 
			Me.txtStartTime.Location = New System.Drawing.Point(173, 32)
			Me.txtStartTime.Name = "txtStartTime"
			Me.txtStartTime.Size = New System.Drawing.Size(158, 20)
			Me.txtStartTime.TabIndex = 1
			' 
			' txtID
			' 
			Me.txtID.Location = New System.Drawing.Point(173, 79)
			Me.txtID.Name = "txtID"
			Me.txtID.Size = New System.Drawing.Size(158, 20)
			Me.txtID.TabIndex = 4
			' 
			' txtPhysicianName
			' 
			Me.txtPhysicianName.Location = New System.Drawing.Point(346, 32)
			Me.txtPhysicianName.Name = "txtPhysicianName"
			Me.txtPhysicianName.Size = New System.Drawing.Size(152, 20)
			Me.txtPhysicianName.TabIndex = 2
			' 
			' txtLocation
			' 
			Me.txtLocation.Location = New System.Drawing.Point(346, 79)
			Me.txtLocation.Name = "txtLocation"
			Me.txtLocation.Size = New System.Drawing.Size(152, 20)
			Me.txtLocation.TabIndex = 5
			' 
			' txtStationAETitle
			' 
			Me.txtStationAETitle.Location = New System.Drawing.Point(11, 125)
			Me.txtStationAETitle.Name = "txtStationAETitle"
			Me.txtStationAETitle.Size = New System.Drawing.Size(147, 20)
			Me.txtStationAETitle.TabIndex = 6
			' 
			' txtRequestedProcedureID
			' 
			Me.txtRequestedProcedureID.Location = New System.Drawing.Point(15, 378)
			Me.txtRequestedProcedureID.Name = "txtRequestedProcedureID"
			Me.txtRequestedProcedureID.Size = New System.Drawing.Size(158, 20)
			Me.txtRequestedProcedureID.TabIndex = 14
			' 
			' txtReasonForProcedure
			' 
			Me.txtReasonForProcedure.Location = New System.Drawing.Point(188, 378)
			Me.txtReasonForProcedure.Name = "txtReasonForProcedure"
			Me.txtReasonForProcedure.Size = New System.Drawing.Size(158, 20)
			Me.txtReasonForProcedure.TabIndex = 15
			' 
			' cboProcedurePriority
			' 
			Me.cboProcedurePriority.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.cboProcedurePriority.FormattingEnabled = True
			Me.cboProcedurePriority.Location = New System.Drawing.Point(361, 377)
			Me.cboProcedurePriority.Name = "cboProcedurePriority"
			Me.cboProcedurePriority.Size = New System.Drawing.Size(158, 21)
			Me.cboProcedurePriority.TabIndex = 16
			' 
			' cboSex
			' 
			Me.cboSex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.cboSex.FormattingEnabled = True
			Me.cboSex.Location = New System.Drawing.Point(15, 117)
			Me.cboSex.Name = "cboSex"
			Me.cboSex.Size = New System.Drawing.Size(96, 21)
			Me.cboSex.TabIndex = 7
			' 
			' groupBox1
			' 
			Me.groupBox1.Controls.Add(Me.txtID)
			Me.groupBox1.Controls.Add(Me.txtStartDate)
			Me.groupBox1.Controls.Add(Me.txtDescription)
			Me.groupBox1.Controls.Add(Me.txtStartTime)
			Me.groupBox1.Controls.Add(Me.txtPhysicianName)
			Me.groupBox1.Controls.Add(Me.txtLocation)
			Me.groupBox1.Controls.Add(Me.txtStationAETitle)
			Me.groupBox1.Controls.Add(Me.label18)
			Me.groupBox1.Controls.Add(Me.label15)
			Me.groupBox1.Controls.Add(Me.label16)
			Me.groupBox1.Controls.Add(Me.label21)
			Me.groupBox1.Controls.Add(Me.label17)
			Me.groupBox1.Controls.Add(Me.label20)
			Me.groupBox1.Controls.Add(Me.label19)
			Me.groupBox1.Location = New System.Drawing.Point(15, 196)
			Me.groupBox1.Name = "groupBox1"
			Me.groupBox1.Size = New System.Drawing.Size(504, 156)
			Me.groupBox1.TabIndex = 13
			Me.groupBox1.TabStop = False
			Me.groupBox1.Text = "Scheduled Procedure Items"
			' 
			' label18
			' 
			Me.label18.AutoSize = True
			Me.label18.Location = New System.Drawing.Point(8, 63)
			Me.label18.Name = "label18"
			Me.label18.Size = New System.Drawing.Size(63, 13)
			Me.label18.TabIndex = 44
			Me.label18.Text = "Description:"
			' 
			' label15
			' 
			Me.label15.AutoSize = True
			Me.label15.Location = New System.Drawing.Point(8, 16)
			Me.label15.Name = "label15"
			Me.label15.Size = New System.Drawing.Size(58, 13)
			Me.label15.TabIndex = 41
			Me.label15.Text = "Start Date:"
			' 
			' label16
			' 
			Me.label16.AutoSize = True
			Me.label16.Location = New System.Drawing.Point(170, 16)
			Me.label16.Name = "label16"
			Me.label16.Size = New System.Drawing.Size(58, 13)
			Me.label16.TabIndex = 42
			Me.label16.Text = "Start Time:"
			' 
			' label21
			' 
			Me.label21.AutoSize = True
			Me.label21.Location = New System.Drawing.Point(8, 109)
			Me.label21.Name = "label21"
			Me.label21.Size = New System.Drawing.Size(83, 13)
			Me.label21.TabIndex = 47
			Me.label21.Text = "Station AE Title:"
			' 
			' label17
			' 
			Me.label17.AutoSize = True
			Me.label17.Location = New System.Drawing.Point(343, 16)
			Me.label17.Name = "label17"
			Me.label17.Size = New System.Drawing.Size(86, 13)
			Me.label17.TabIndex = 43
			Me.label17.Text = "Physician Name:"
			' 
			' label20
			' 
			Me.label20.AutoSize = True
			Me.label20.Location = New System.Drawing.Point(343, 63)
			Me.label20.Name = "label20"
			Me.label20.Size = New System.Drawing.Size(51, 13)
			Me.label20.TabIndex = 46
			Me.label20.Text = "Location:"
			' 
			' label19
			' 
			Me.label19.AutoSize = True
			Me.label19.Location = New System.Drawing.Point(170, 63)
			Me.label19.Name = "label19"
			Me.label19.Size = New System.Drawing.Size(21, 13)
			Me.label19.TabIndex = 45
			Me.label19.Text = "ID:"
			' 
			' label1
			' 
			Me.label1.AutoSize = True
			Me.label1.Location = New System.Drawing.Point(12, 9)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(99, 13)
			Me.label1.TabIndex = 27
			Me.label1.Text = "Accession Number:"
			' 
			' label2
			' 
			Me.label2.AutoSize = True
			Me.label2.Location = New System.Drawing.Point(121, 9)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(49, 13)
			Me.label2.TabIndex = 28
			Me.label2.Text = "Modality:"
			' 
			' label3
			' 
			Me.label3.AutoSize = True
			Me.label3.Location = New System.Drawing.Point(185, 9)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(86, 13)
			Me.label3.TabIndex = 29
			Me.label3.Text = "Institution Name:"
			' 
			' label4
			' 
			Me.label4.AutoSize = True
			Me.label4.Location = New System.Drawing.Point(358, 9)
			Me.label4.Name = "label4"
			Me.label4.Size = New System.Drawing.Size(132, 13)
			Me.label4.TabIndex = 30
			Me.label4.Text = "Referring Physician Name:"
			' 
			' label5
			' 
			Me.label5.AutoSize = True
			Me.label5.Location = New System.Drawing.Point(12, 55)
			Me.label5.Name = "label5"
			Me.label5.Size = New System.Drawing.Size(74, 13)
			Me.label5.TabIndex = 31
			Me.label5.Text = "Patient Name:"
			' 
			' label7
			' 
			Me.label7.AutoSize = True
			Me.label7.Location = New System.Drawing.Point(358, 55)
			Me.label7.Name = "label7"
			Me.label7.Size = New System.Drawing.Size(93, 13)
			Me.label7.TabIndex = 33
			Me.label7.Text = "Patient Birth Date:"
			' 
			' label8
			' 
			Me.label8.AutoSize = True
			Me.label8.Location = New System.Drawing.Point(12, 101)
			Me.label8.Name = "label8"
			Me.label8.Size = New System.Drawing.Size(28, 13)
			Me.label8.TabIndex = 34
			Me.label8.Text = "Sex:"
			' 
			' label9
			' 
			Me.label9.AutoSize = True
			Me.label9.Location = New System.Drawing.Point(121, 101)
			Me.label9.Name = "label9"
			Me.label9.Size = New System.Drawing.Size(44, 13)
			Me.label9.TabIndex = 35
			Me.label9.Text = "Weight:"
			' 
			' label10
			' 
			Me.label10.AutoSize = True
			Me.label10.Location = New System.Drawing.Point(185, 55)
			Me.label10.Name = "label10"
			Me.label10.Size = New System.Drawing.Size(57, 13)
			Me.label10.TabIndex = 36
			Me.label10.Text = "Patient ID:"
			' 
			' label11
			' 
			Me.label11.AutoSize = True
			Me.label11.Location = New System.Drawing.Point(185, 101)
			Me.label11.Name = "label11"
			Me.label11.Size = New System.Drawing.Size(103, 13)
			Me.label11.TabIndex = 37
			Me.label11.Text = "Study Instance UID:"
			' 
			' label12
			' 
			Me.label12.AutoSize = True
			Me.label12.Location = New System.Drawing.Point(358, 102)
			Me.label12.Name = "label12"
			Me.label12.Size = New System.Drawing.Size(112, 13)
			Me.label12.TabIndex = 38
			Me.label12.Text = "Requesting Physician:"
			' 
			' label13
			' 
			Me.label13.AutoSize = True
			Me.label13.Location = New System.Drawing.Point(12, 147)
			Me.label13.Name = "label13"
			Me.label13.Size = New System.Drawing.Size(170, 13)
			Me.label13.TabIndex = 39
			Me.label13.Text = "Requested Procedure Description:"
			' 
			' label14
			' 
			Me.label14.AutoSize = True
			Me.label14.Location = New System.Drawing.Point(185, 147)
			Me.label14.Name = "label14"
			Me.label14.Size = New System.Drawing.Size(71, 13)
			Me.label14.TabIndex = 40
			Me.label14.Text = "Admission ID:"
			' 
			' label22
			' 
			Me.label22.AutoSize = True
			Me.label22.Location = New System.Drawing.Point(12, 361)
			Me.label22.Name = "label22"
			Me.label22.Size = New System.Drawing.Size(128, 13)
			Me.label22.TabIndex = 48
			Me.label22.Text = "Requested Procedure ID:"
			' 
			' label23
			' 
			Me.label23.AutoSize = True
			Me.label23.Location = New System.Drawing.Point(185, 362)
			Me.label23.Name = "label23"
			Me.label23.Size = New System.Drawing.Size(117, 13)
			Me.label23.TabIndex = 49
			Me.label23.Text = "Reason For Procedure:"
			' 
			' label24
			' 
			Me.label24.AutoSize = True
			Me.label24.Location = New System.Drawing.Point(358, 361)
			Me.label24.Name = "label24"
			Me.label24.Size = New System.Drawing.Size(93, 13)
			Me.label24.TabIndex = 50
			Me.label24.Text = "Procedure Priority:"
			' 
			' MwlItemDialog
			' 
			Me.AcceptButton = Me.btnOk
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.CancelButton = Me.btnCancel
			Me.ClientSize = New System.Drawing.Size(531, 448)
			Me.Controls.Add(Me.groupBox1)
			Me.Controls.Add(Me.cboSex)
			Me.Controls.Add(Me.cboProcedurePriority)
			Me.Controls.Add(Me.txtReasonForProcedure)
			Me.Controls.Add(Me.txtRequestedProcedureID)
			Me.Controls.Add(Me.txtAdmissionID)
			Me.Controls.Add(Me.txtRequestedProcedureDescription)
			Me.Controls.Add(Me.txtRequestingPhysician)
			Me.Controls.Add(Me.txtStudyInstanceUID)
			Me.Controls.Add(Me.txtWeight)
			Me.Controls.Add(Me.txtPatientBirthDate)
			Me.Controls.Add(Me.txtPatientID)
			Me.Controls.Add(Me.txtPatientName)
			Me.Controls.Add(Me.txtReferringPhysicianName)
			Me.Controls.Add(Me.txtInstitutionName)
			Me.Controls.Add(Me.txtModality)
			Me.Controls.Add(Me.txtAccessionNumber)
			Me.Controls.Add(Me.btnCancel)
			Me.Controls.Add(Me.btnOk)
			Me.Controls.Add(Me.label24)
			Me.Controls.Add(Me.label23)
			Me.Controls.Add(Me.label22)
			Me.Controls.Add(Me.label14)
			Me.Controls.Add(Me.label13)
			Me.Controls.Add(Me.label12)
			Me.Controls.Add(Me.label11)
			Me.Controls.Add(Me.label10)
			Me.Controls.Add(Me.label9)
			Me.Controls.Add(Me.label8)
			Me.Controls.Add(Me.label7)
			Me.Controls.Add(Me.label5)
			Me.Controls.Add(Me.label4)
			Me.Controls.Add(Me.label3)
			Me.Controls.Add(Me.label2)
			Me.Controls.Add(Me.label1)
			Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
			Me.MaximizeBox = False
			Me.MinimizeBox = False
			Me.Name = "MwlItemDialog"
			Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
			Me.Text = "MwlItem Dialog"
'			Me.Load += New System.EventHandler(Me.MwlItemDialog_Load);
			Me.groupBox1.ResumeLayout(False)
			Me.groupBox1.PerformLayout()
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub

		#End Region

		Private WithEvents btnOk As System.Windows.Forms.Button
		Private WithEvents btnCancel As System.Windows.Forms.Button
		Private txtAccessionNumber As System.Windows.Forms.TextBox
		Private txtModality As System.Windows.Forms.TextBox
		Private txtInstitutionName As System.Windows.Forms.TextBox
		Private txtReferringPhysicianName As System.Windows.Forms.TextBox
		Private txtPatientName As System.Windows.Forms.TextBox
		Private txtPatientID As System.Windows.Forms.TextBox
		Private txtPatientBirthDate As System.Windows.Forms.TextBox
		Private txtStartDate As System.Windows.Forms.TextBox
		Private txtWeight As System.Windows.Forms.TextBox
		Private txtStudyInstanceUID As System.Windows.Forms.TextBox
		Private txtRequestingPhysician As System.Windows.Forms.TextBox
		Private txtRequestedProcedureDescription As System.Windows.Forms.TextBox
		Private txtAdmissionID As System.Windows.Forms.TextBox
		Private txtDescription As System.Windows.Forms.TextBox
		Private txtStartTime As System.Windows.Forms.TextBox
		Private txtID As System.Windows.Forms.TextBox
		Private txtPhysicianName As System.Windows.Forms.TextBox
		Private txtLocation As System.Windows.Forms.TextBox
		Private txtStationAETitle As System.Windows.Forms.TextBox
		Private txtRequestedProcedureID As System.Windows.Forms.TextBox
		Private txtReasonForProcedure As System.Windows.Forms.TextBox
		Private cboProcedurePriority As System.Windows.Forms.ComboBox
		Private cboSex As System.Windows.Forms.ComboBox
		Private groupBox1 As System.Windows.Forms.GroupBox
		Private label1 As System.Windows.Forms.Label
		Private label2 As System.Windows.Forms.Label
		Private label3 As System.Windows.Forms.Label
		Private label4 As System.Windows.Forms.Label
		Private label5 As System.Windows.Forms.Label
		Private label7 As System.Windows.Forms.Label
		Private label8 As System.Windows.Forms.Label
		Private label9 As System.Windows.Forms.Label
		Private label10 As System.Windows.Forms.Label
		Private label11 As System.Windows.Forms.Label
		Private label12 As System.Windows.Forms.Label
		Private label13 As System.Windows.Forms.Label
		Private label14 As System.Windows.Forms.Label
		Private label15 As System.Windows.Forms.Label
		Private label16 As System.Windows.Forms.Label
		Private label17 As System.Windows.Forms.Label
		Private label18 As System.Windows.Forms.Label
		Private label19 As System.Windows.Forms.Label
		Private label20 As System.Windows.Forms.Label
		Private label21 As System.Windows.Forms.Label
		Private label22 As System.Windows.Forms.Label
		Private label23 As System.Windows.Forms.Label
		Private label24 As System.Windows.Forms.Label
	End Class
End Namespace