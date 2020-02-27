Imports Microsoft.VisualBasic
Imports System
Namespace DicomDemo
	Public Partial Class Page2
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
			Me.label1 = New System.Windows.Forms.Label()
			Me.radPatient = New System.Windows.Forms.RadioButton()
			Me.radBroad = New System.Windows.Forms.RadioButton()
			Me.chkScheduledDate = New System.Windows.Forms.CheckBox()
			Me.chkModality = New System.Windows.Forms.CheckBox()
			Me.cboModality = New System.Windows.Forms.ComboBox()
			Me.grpBroad = New System.Windows.Forms.GroupBox()
			Me.dtpScheduledDate = New System.Windows.Forms.DateTimePicker()
			Me.grpPatient = New System.Windows.Forms.GroupBox()
			Me.txtRequestedProcedureID = New System.Windows.Forms.TextBox()
			Me.txtAccessionNumber = New System.Windows.Forms.TextBox()
			Me.txtPatientID = New System.Windows.Forms.TextBox()
			Me.txtPatientName = New System.Windows.Forms.TextBox()
			Me.label5 = New System.Windows.Forms.Label()
			Me.label4 = New System.Windows.Forms.Label()
			Me.label3 = New System.Windows.Forms.Label()
			Me.label2 = New System.Windows.Forms.Label()
			Me.grpBroad.SuspendLayout()
			Me.grpPatient.SuspendLayout()
			Me.SuspendLayout()
			' 
			' label1
			' 
			Me.label1.AutoSize = True
			Me.label1.Location = New System.Drawing.Point(16, 16)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(343, 13)
			Me.label1.TabIndex = 0
			Me.label1.Text = "Choose Query Type, supply the requested information, and click ""Next"""
			' 
			' radPatient
			' 
			Me.radPatient.AutoSize = True
			Me.radPatient.Location = New System.Drawing.Point(19, 198)
			Me.radPatient.Name = "radPatient"
			Me.radPatient.Size = New System.Drawing.Size(122, 17)
			Me.radPatient.TabIndex = 1
			Me.radPatient.Text = "Patient Based Query"
			Me.radPatient.UseVisualStyleBackColor = True
'			Me.radPatient.CheckedChanged += New System.EventHandler(Me.radPatient_CheckedChanged);
			' 
			' radBroad
			' 
			Me.radBroad.AutoSize = True
			Me.radBroad.Location = New System.Drawing.Point(19, 68)
			Me.radBroad.Name = "radBroad"
			Me.radBroad.Size = New System.Drawing.Size(174, 17)
			Me.radBroad.TabIndex = 1
			Me.radBroad.Text = "Broad Modality Work List Query"
			Me.radBroad.UseVisualStyleBackColor = True
'			Me.radBroad.CheckedChanged += New System.EventHandler(Me.radBroad_CheckedChanged);
			' 
			' chkScheduledDate
			' 
			Me.chkScheduledDate.AutoSize = True
			Me.chkScheduledDate.Location = New System.Drawing.Point(39, 22)
			Me.chkScheduledDate.Name = "chkScheduledDate"
			Me.chkScheduledDate.Size = New System.Drawing.Size(205, 17)
			Me.chkScheduledDate.TabIndex = 0
			Me.chkScheduledDate.Text = "Scheduled Procedure Step Start Date"
			Me.chkScheduledDate.UseVisualStyleBackColor = True
'			Me.chkScheduledDate.CheckedChanged += New System.EventHandler(Me.chkScheduledDate_CheckedChanged);
			' 
			' chkModality
			' 
			Me.chkModality.AutoSize = True
			Me.chkModality.Location = New System.Drawing.Point(39, 49)
			Me.chkModality.Name = "chkModality"
			Me.chkModality.Size = New System.Drawing.Size(65, 17)
			Me.chkModality.TabIndex = 2
			Me.chkModality.Text = "Modality"
			Me.chkModality.UseVisualStyleBackColor = True
'			Me.chkModality.CheckedChanged += New System.EventHandler(Me.chkModality_CheckedChanged);
			' 
			' cboModality
			' 
			Me.cboModality.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.cboModality.Enabled = False
			Me.cboModality.FormattingEnabled = True
			Me.cboModality.Location = New System.Drawing.Point(110, 47)
			Me.cboModality.Name = "cboModality"
			Me.cboModality.Size = New System.Drawing.Size(422, 21)
			Me.cboModality.TabIndex = 3
			' 
			' grpBroad
			' 
			Me.grpBroad.Controls.Add(Me.dtpScheduledDate)
			Me.grpBroad.Controls.Add(Me.cboModality)
			Me.grpBroad.Controls.Add(Me.chkScheduledDate)
			Me.grpBroad.Controls.Add(Me.chkModality)
			Me.grpBroad.Enabled = False
			Me.grpBroad.Location = New System.Drawing.Point(38, 92)
			Me.grpBroad.Name = "grpBroad"
			Me.grpBroad.Size = New System.Drawing.Size(564, 82)
			Me.grpBroad.TabIndex = 2
			Me.grpBroad.TabStop = False
			' 
			' dtpScheduledDate
			' 
			Me.dtpScheduledDate.Enabled = False
			Me.dtpScheduledDate.Location = New System.Drawing.Point(250, 19)
			Me.dtpScheduledDate.Name = "dtpScheduledDate"
			Me.dtpScheduledDate.Size = New System.Drawing.Size(282, 20)
			Me.dtpScheduledDate.TabIndex = 1
			Me.dtpScheduledDate.Value = New System.DateTime(2007, 10, 16, 0, 0, 0, 0)
			' 
			' grpPatient
			' 
			Me.grpPatient.Controls.Add(Me.txtRequestedProcedureID)
			Me.grpPatient.Controls.Add(Me.txtAccessionNumber)
			Me.grpPatient.Controls.Add(Me.txtPatientID)
			Me.grpPatient.Controls.Add(Me.txtPatientName)
			Me.grpPatient.Controls.Add(Me.label5)
			Me.grpPatient.Controls.Add(Me.label4)
			Me.grpPatient.Controls.Add(Me.label3)
			Me.grpPatient.Controls.Add(Me.label2)
			Me.grpPatient.Enabled = False
			Me.grpPatient.Location = New System.Drawing.Point(38, 222)
			Me.grpPatient.Name = "grpPatient"
			Me.grpPatient.Size = New System.Drawing.Size(564, 136)
			Me.grpPatient.TabIndex = 3
			Me.grpPatient.TabStop = False
			' 
			' txtRequestedProcedureID
			' 
			Me.txtRequestedProcedureID.Location = New System.Drawing.Point(185, 100)
			Me.txtRequestedProcedureID.Name = "txtRequestedProcedureID"
			Me.txtRequestedProcedureID.Size = New System.Drawing.Size(347, 20)
			Me.txtRequestedProcedureID.TabIndex = 7
			' 
			' txtAccessionNumber
			' 
			Me.txtAccessionNumber.Location = New System.Drawing.Point(185, 73)
			Me.txtAccessionNumber.Name = "txtAccessionNumber"
			Me.txtAccessionNumber.Size = New System.Drawing.Size(347, 20)
			Me.txtAccessionNumber.TabIndex = 6
			' 
			' txtPatientID
			' 
			Me.txtPatientID.Location = New System.Drawing.Point(185, 46)
			Me.txtPatientID.Name = "txtPatientID"
			Me.txtPatientID.Size = New System.Drawing.Size(347, 20)
			Me.txtPatientID.TabIndex = 5
			' 
			' txtPatientName
			' 
			Me.txtPatientName.Location = New System.Drawing.Point(185, 19)
			Me.txtPatientName.Name = "txtPatientName"
			Me.txtPatientName.Size = New System.Drawing.Size(347, 20)
			Me.txtPatientName.TabIndex = 4
			' 
			' label5
			' 
			Me.label5.AutoSize = True
			Me.label5.Location = New System.Drawing.Point(54, 103)
			Me.label5.Name = "label5"
			Me.label5.Size = New System.Drawing.Size(125, 13)
			Me.label5.TabIndex = 3
			Me.label5.Text = "Requested Procedure ID"
			' 
			' label4
			' 
			Me.label4.AutoSize = True
			Me.label4.Location = New System.Drawing.Point(83, 76)
			Me.label4.Name = "label4"
			Me.label4.Size = New System.Drawing.Size(96, 13)
			Me.label4.TabIndex = 2
			Me.label4.Text = "Accession Number"
			' 
			' label3
			' 
			Me.label3.AutoSize = True
			Me.label3.Location = New System.Drawing.Point(125, 49)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(54, 13)
			Me.label3.TabIndex = 1
			Me.label3.Text = "Patient ID"
			' 
			' label2
			' 
			Me.label2.AutoSize = True
			Me.label2.Location = New System.Drawing.Point(101, 22)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(78, 13)
			Me.label2.TabIndex = 0
			Me.label2.Text = "Patient's Name"
			' 
			' Page2
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.Controls.Add(Me.grpPatient)
			Me.Controls.Add(Me.grpBroad)
			Me.Controls.Add(Me.radBroad)
			Me.Controls.Add(Me.radPatient)
			Me.Controls.Add(Me.label1)
			Me.Name = "Page2"
			Me.Size = New System.Drawing.Size(618, 452)
'			Me.Load += New System.EventHandler(Me.Page2_Load);
			Me.grpBroad.ResumeLayout(False)
			Me.grpBroad.PerformLayout()
			Me.grpPatient.ResumeLayout(False)
			Me.grpPatient.PerformLayout()
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub

		#End Region

		Private label1 As System.Windows.Forms.Label
		Public WithEvents radPatient As System.Windows.Forms.RadioButton
		Public WithEvents radBroad As System.Windows.Forms.RadioButton
		Public WithEvents chkScheduledDate As System.Windows.Forms.CheckBox
		Public WithEvents chkModality As System.Windows.Forms.CheckBox
		Public cboModality As System.Windows.Forms.ComboBox
		Private grpBroad As System.Windows.Forms.GroupBox
		Private grpPatient As System.Windows.Forms.GroupBox
		Public txtRequestedProcedureID As System.Windows.Forms.TextBox
		Public txtAccessionNumber As System.Windows.Forms.TextBox
		Public txtPatientID As System.Windows.Forms.TextBox
		Public txtPatientName As System.Windows.Forms.TextBox
		Private label5 As System.Windows.Forms.Label
		Private label4 As System.Windows.Forms.Label
		Private label3 As System.Windows.Forms.Label
		Private label2 As System.Windows.Forms.Label
		Public dtpScheduledDate As System.Windows.Forms.DateTimePicker
	End Class
End Namespace
