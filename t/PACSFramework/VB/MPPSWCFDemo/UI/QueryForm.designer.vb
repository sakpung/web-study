Imports Microsoft.VisualBasic
Imports System
Namespace MPPSWCFDemo.UI
   Public Partial Class QueryForm
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
		 Me.label1 = New System.Windows.Forms.Label()
		 Me.PatientId = New System.Windows.Forms.TextBox()
		 Me.label2 = New System.Windows.Forms.Label()
		 Me.Firstname = New System.Windows.Forms.TextBox()
		 Me.AccessionNumber = New System.Windows.Forms.TextBox()
		 Me.label4 = New System.Windows.Forms.Label()
		 Me.label5 = New System.Windows.Forms.Label()
		 Me.RequestedProcedureId = New System.Windows.Forms.TextBox()
		 Me.label6 = New System.Windows.Forms.Label()
		 Me.ScheduledProcedureId = New System.Windows.Forms.TextBox()
		 Me.label7 = New System.Windows.Forms.Label()
		 Me.PerformedStationAe = New System.Windows.Forms.TextBox()
		 Me.label8 = New System.Windows.Forms.Label()
		 Me.buttonQuery = New System.Windows.Forms.Button()
		 Me.buttonClear = New System.Windows.Forms.Button()
		 Me.button3 = New System.Windows.Forms.Button()
		 Me.buttonOK = New System.Windows.Forms.Button()
		 Me.label9 = New System.Windows.Forms.Label()
		 Me.SearchResults = New System.Windows.Forms.ListView()
		 Me.columnHeader3 = New System.Windows.Forms.ColumnHeader()
		 Me.columnHeader4 = New System.Windows.Forms.ColumnHeader()
		 Me.columnHeader1 = New System.Windows.Forms.ColumnHeader()
		 Me.columnHeader2 = New System.Windows.Forms.ColumnHeader()
		 Me.columnHeader5 = New System.Windows.Forms.ColumnHeader()
		 Me.columnHeader6 = New System.Windows.Forms.ColumnHeader()
		 Me.StartDateBegin = New System.Windows.Forms.DateTimePicker()
		 Me.groupBox1 = New System.Windows.Forms.GroupBox()
		 Me.StartDateEnd = New System.Windows.Forms.DateTimePicker()
		 Me.label11 = New System.Windows.Forms.Label()
		 Me.label10 = New System.Windows.Forms.Label()
		 Me.groupBox2 = New System.Windows.Forms.GroupBox()
		 Me.EndDateEnd = New System.Windows.Forms.DateTimePicker()
		 Me.label12 = New System.Windows.Forms.Label()
		 Me.label13 = New System.Windows.Forms.Label()
		 Me.EndDateBegin = New System.Windows.Forms.DateTimePicker()
		 Me.Modality = New System.Windows.Forms.ComboBox()
		 Me.label14 = New System.Windows.Forms.Label()
		 Me.Status = New System.Windows.Forms.ComboBox()
		 Me.Lastname = New System.Windows.Forms.TextBox()
		 Me.label3 = New System.Windows.Forms.Label()
		 Me.columnHeader7 = New System.Windows.Forms.ColumnHeader()
		 Me.columnHeader8 = New System.Windows.Forms.ColumnHeader()
		 Me.groupBox1.SuspendLayout()
		 Me.groupBox2.SuspendLayout()
		 Me.SuspendLayout()
		 ' 
		 ' label1
		 ' 
		 Me.label1.AutoSize = True
		 Me.label1.Location = New System.Drawing.Point(13, 13)
		 Me.label1.Name = "label1"
		 Me.label1.Size = New System.Drawing.Size(57, 13)
		 Me.label1.TabIndex = 0
		 Me.label1.Text = "Patient ID:"
		 ' 
		 ' PatientId
		 ' 
		 Me.PatientId.Location = New System.Drawing.Point(16, 30)
		 Me.PatientId.Name = "PatientId"
		 Me.PatientId.Size = New System.Drawing.Size(368, 20)
		 Me.PatientId.TabIndex = 1
		 ' 
		 ' label2
		 ' 
		 Me.label2.AutoSize = True
		 Me.label2.Location = New System.Drawing.Point(13, 54)
		 Me.label2.Name = "label2"
		 Me.label2.Size = New System.Drawing.Size(96, 13)
		 Me.label2.TabIndex = 2
		 Me.label2.Text = "Patient First Name:"
		 ' 
		 ' Firstname
		 ' 
		 Me.Firstname.Location = New System.Drawing.Point(15, 70)
		 Me.Firstname.Name = "Firstname"
		 Me.Firstname.Size = New System.Drawing.Size(165, 20)
		 Me.Firstname.TabIndex = 3
		 ' 
		 ' AccessionNumber
		 ' 
		 Me.AccessionNumber.Location = New System.Drawing.Point(16, 110)
		 Me.AccessionNumber.Name = "AccessionNumber"
		 Me.AccessionNumber.Size = New System.Drawing.Size(164, 20)
		 Me.AccessionNumber.TabIndex = 7
		 ' 
		 ' label4
		 ' 
		 Me.label4.AutoSize = True
		 Me.label4.Location = New System.Drawing.Point(13, 93)
		 Me.label4.Name = "label4"
		 Me.label4.Size = New System.Drawing.Size(99, 13)
		 Me.label4.TabIndex = 6
		 Me.label4.Text = "Accession Number:"
		 ' 
		 ' label5
		 ' 
		 Me.label5.AutoSize = True
		 Me.label5.Location = New System.Drawing.Point(217, 93)
		 Me.label5.Name = "label5"
		 Me.label5.Size = New System.Drawing.Size(49, 13)
		 Me.label5.TabIndex = 8
		 Me.label5.Text = "Modality:"
		 ' 
		 ' RequestedProcedureId
		 ' 
		 Me.RequestedProcedureId.Location = New System.Drawing.Point(15, 150)
		 Me.RequestedProcedureId.Name = "RequestedProcedureId"
		 Me.RequestedProcedureId.Size = New System.Drawing.Size(164, 20)
		 Me.RequestedProcedureId.TabIndex = 11
		 ' 
		 ' label6
		 ' 
		 Me.label6.AutoSize = True
		 Me.label6.Location = New System.Drawing.Point(12, 133)
		 Me.label6.Name = "label6"
		 Me.label6.Size = New System.Drawing.Size(126, 13)
		 Me.label6.TabIndex = 10
		 Me.label6.Text = "Requested Procedure Id:"
		 ' 
		 ' ScheduledProcedureId
		 ' 
		 Me.ScheduledProcedureId.Location = New System.Drawing.Point(220, 150)
		 Me.ScheduledProcedureId.Name = "ScheduledProcedureId"
		 Me.ScheduledProcedureId.Size = New System.Drawing.Size(164, 20)
		 Me.ScheduledProcedureId.TabIndex = 13
		 ' 
		 ' label7
		 ' 
		 Me.label7.AutoSize = True
		 Me.label7.Location = New System.Drawing.Point(217, 133)
		 Me.label7.Name = "label7"
		 Me.label7.Size = New System.Drawing.Size(125, 13)
		 Me.label7.TabIndex = 12
		 Me.label7.Text = "Scheduled Procedure Id:"
		 ' 
		 ' PerformedStationAe
		 ' 
		 Me.PerformedStationAe.Location = New System.Drawing.Point(16, 190)
		 Me.PerformedStationAe.Name = "PerformedStationAe"
		 Me.PerformedStationAe.Size = New System.Drawing.Size(164, 20)
		 Me.PerformedStationAe.TabIndex = 15
		 ' 
		 ' label8
		 ' 
		 Me.label8.AutoSize = True
		 Me.label8.Location = New System.Drawing.Point(13, 173)
		 Me.label8.Name = "label8"
		 Me.label8.Size = New System.Drawing.Size(134, 13)
		 Me.label8.TabIndex = 14
		 Me.label8.Text = "Performed Station AE Title:"
		 ' 
		 ' buttonQuery
		 ' 
		 Me.buttonQuery.Location = New System.Drawing.Point(471, 216)
		 Me.buttonQuery.Name = "buttonQuery"
		 Me.buttonQuery.Size = New System.Drawing.Size(75, 23)
		 Me.buttonQuery.TabIndex = 16
		 Me.buttonQuery.Text = "Query"
		 Me.buttonQuery.UseVisualStyleBackColor = True
'		 Me.buttonQuery.Click += New System.EventHandler(Me.buttonQuery_Click);
		 ' 
		 ' buttonClear
		 ' 
		 Me.buttonClear.Location = New System.Drawing.Point(16, 378)
		 Me.buttonClear.Name = "buttonClear"
		 Me.buttonClear.Size = New System.Drawing.Size(75, 23)
		 Me.buttonClear.TabIndex = 17
		 Me.buttonClear.Text = "Clear"
		 Me.buttonClear.UseVisualStyleBackColor = True
'		 Me.buttonClear.Click += New System.EventHandler(Me.buttonClear_Click);
		 ' 
		 ' button3
		 ' 
		 Me.button3.DialogResult = System.Windows.Forms.DialogResult.Cancel
		 Me.button3.Location = New System.Drawing.Point(471, 377)
		 Me.button3.Name = "button3"
		 Me.button3.Size = New System.Drawing.Size(75, 23)
		 Me.button3.TabIndex = 18
		 Me.button3.Text = "Cancel"
		 Me.button3.UseVisualStyleBackColor = True
		 ' 
		 ' buttonOK
		 ' 
		 Me.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK
		 Me.buttonOK.Location = New System.Drawing.Point(390, 377)
		 Me.buttonOK.Name = "buttonOK"
		 Me.buttonOK.Size = New System.Drawing.Size(75, 23)
		 Me.buttonOK.TabIndex = 19
		 Me.buttonOK.Text = "OK"
		 Me.buttonOK.UseVisualStyleBackColor = True
		 ' 
		 ' label9
		 ' 
		 Me.label9.AutoSize = True
		 Me.label9.Location = New System.Drawing.Point(13, 227)
		 Me.label9.Name = "label9"
		 Me.label9.Size = New System.Drawing.Size(82, 13)
		 Me.label9.TabIndex = 20
		 Me.label9.Text = "Search Results:"
		 ' 
		 ' SearchResults
		 ' 
		 Me.SearchResults.Columns.AddRange(New System.Windows.Forms.ColumnHeader() { Me.columnHeader7, Me.columnHeader8, Me.columnHeader3, Me.columnHeader4, Me.columnHeader1, Me.columnHeader2, Me.columnHeader5, Me.columnHeader6})
		 Me.SearchResults.FullRowSelect = True
		 Me.SearchResults.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
		 Me.SearchResults.HideSelection = False
		 Me.SearchResults.Location = New System.Drawing.Point(16, 244)
		 Me.SearchResults.MultiSelect = False
		 Me.SearchResults.Name = "SearchResults"
		 Me.SearchResults.Size = New System.Drawing.Size(530, 127)
		 Me.SearchResults.TabIndex = 21
		 Me.SearchResults.UseCompatibleStateImageBehavior = False
		 Me.SearchResults.View = System.Windows.Forms.View.Details
'		 Me.SearchResults.DoubleClick += New System.EventHandler(Me.SearchResults_DoubleClick);
		 ' 
		 ' columnHeader3
		 ' 
		 Me.columnHeader3.Text = "Status"
		 Me.columnHeader3.Width = 90
		 ' 
		 ' columnHeader4
		 ' 
		 Me.columnHeader4.Text = "Modality"
		 ' 
		 ' columnHeader1
		 ' 
		 Me.columnHeader1.Text = "Peformed Procedure Step Id"
		 Me.columnHeader1.Width = 150
		 ' 
		 ' columnHeader2
		 ' 
		 Me.columnHeader2.Text = "Performed Station AE"
		 Me.columnHeader2.Width = 115
		 ' 
		 ' columnHeader5
		 ' 
		 Me.columnHeader5.Text = "Start Date"
		 Me.columnHeader5.Width = 80
		 ' 
		 ' columnHeader6
		 ' 
		 Me.columnHeader6.Text = "End Date"
		 Me.columnHeader6.Width = 80
		 ' 
		 ' StartDateBegin
		 ' 
		 Me.StartDateBegin.Checked = False
		 Me.StartDateBegin.Format = System.Windows.Forms.DateTimePickerFormat.Short
		 Me.StartDateBegin.Location = New System.Drawing.Point(50, 31)
		 Me.StartDateBegin.Name = "StartDateBegin"
		 Me.StartDateBegin.ShowCheckBox = True
		 Me.StartDateBegin.Size = New System.Drawing.Size(93, 20)
		 Me.StartDateBegin.TabIndex = 22
		 ' 
		 ' groupBox1
		 ' 
		 Me.groupBox1.Controls.Add(Me.StartDateEnd)
		 Me.groupBox1.Controls.Add(Me.label11)
		 Me.groupBox1.Controls.Add(Me.label10)
		 Me.groupBox1.Controls.Add(Me.StartDateBegin)
		 Me.groupBox1.Location = New System.Drawing.Point(390, 13)
		 Me.groupBox1.Name = "groupBox1"
		 Me.groupBox1.Size = New System.Drawing.Size(156, 93)
		 Me.groupBox1.TabIndex = 23
		 Me.groupBox1.TabStop = False
		 Me.groupBox1.Text = "MPPS Start Date"
		 ' 
		 ' StartDateEnd
		 ' 
		 Me.StartDateEnd.Checked = False
		 Me.StartDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short
		 Me.StartDateEnd.Location = New System.Drawing.Point(50, 57)
		 Me.StartDateEnd.Name = "StartDateEnd"
		 Me.StartDateEnd.ShowCheckBox = True
		 Me.StartDateEnd.Size = New System.Drawing.Size(93, 20)
		 Me.StartDateEnd.TabIndex = 24
		 ' 
		 ' label11
		 ' 
		 Me.label11.AutoSize = True
		 Me.label11.Location = New System.Drawing.Point(7, 64)
		 Me.label11.Name = "label11"
		 Me.label11.Size = New System.Drawing.Size(29, 13)
		 Me.label11.TabIndex = 23
		 Me.label11.Text = "End:"
		 ' 
		 ' label10
		 ' 
		 Me.label10.AutoSize = True
		 Me.label10.Location = New System.Drawing.Point(7, 38)
		 Me.label10.Name = "label10"
		 Me.label10.Size = New System.Drawing.Size(37, 13)
		 Me.label10.TabIndex = 0
		 Me.label10.Text = "Begin:"
		 ' 
		 ' groupBox2
		 ' 
		 Me.groupBox2.Controls.Add(Me.EndDateEnd)
		 Me.groupBox2.Controls.Add(Me.label12)
		 Me.groupBox2.Controls.Add(Me.label13)
		 Me.groupBox2.Controls.Add(Me.EndDateBegin)
		 Me.groupBox2.Location = New System.Drawing.Point(390, 117)
		 Me.groupBox2.Name = "groupBox2"
		 Me.groupBox2.Size = New System.Drawing.Size(156, 93)
		 Me.groupBox2.TabIndex = 24
		 Me.groupBox2.TabStop = False
		 Me.groupBox2.Text = "MPPS End Date"
		 ' 
		 ' EndDateEnd
		 ' 
		 Me.EndDateEnd.Checked = False
		 Me.EndDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short
		 Me.EndDateEnd.Location = New System.Drawing.Point(50, 56)
		 Me.EndDateEnd.Name = "EndDateEnd"
		 Me.EndDateEnd.ShowCheckBox = True
		 Me.EndDateEnd.Size = New System.Drawing.Size(93, 20)
		 Me.EndDateEnd.TabIndex = 28
		 ' 
		 ' label12
		 ' 
		 Me.label12.AutoSize = True
		 Me.label12.Location = New System.Drawing.Point(10, 64)
		 Me.label12.Name = "label12"
		 Me.label12.Size = New System.Drawing.Size(29, 13)
		 Me.label12.TabIndex = 27
		 Me.label12.Text = "End:"
		 ' 
		 ' label13
		 ' 
		 Me.label13.AutoSize = True
		 Me.label13.Location = New System.Drawing.Point(10, 37)
		 Me.label13.Name = "label13"
		 Me.label13.Size = New System.Drawing.Size(37, 13)
		 Me.label13.TabIndex = 25
		 Me.label13.Text = "Begin:"
		 ' 
		 ' EndDateBegin
		 ' 
		 Me.EndDateBegin.Checked = False
		 Me.EndDateBegin.Format = System.Windows.Forms.DateTimePickerFormat.Short
		 Me.EndDateBegin.Location = New System.Drawing.Point(50, 30)
		 Me.EndDateBegin.Name = "EndDateBegin"
		 Me.EndDateBegin.ShowCheckBox = True
		 Me.EndDateBegin.Size = New System.Drawing.Size(93, 20)
		 Me.EndDateBegin.TabIndex = 26
		 ' 
		 ' Modality
		 ' 
		 Me.Modality.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		 Me.Modality.FormattingEnabled = True
		 Me.Modality.Location = New System.Drawing.Point(220, 110)
		 Me.Modality.Name = "Modality"
		 Me.Modality.Size = New System.Drawing.Size(164, 21)
		 Me.Modality.TabIndex = 25
		 ' 
		 ' label14
		 ' 
		 Me.label14.AutoSize = True
		 Me.label14.Location = New System.Drawing.Point(217, 173)
		 Me.label14.Name = "label14"
		 Me.label14.Size = New System.Drawing.Size(40, 13)
		 Me.label14.TabIndex = 26
		 Me.label14.Text = "Status:"
		 ' 
		 ' Status
		 ' 
		 Me.Status.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		 Me.Status.FormattingEnabled = True
		 Me.Status.Items.AddRange(New Object() { "COMPLETED", "DISCONTINUED", "IN PROGRESS"})
		 Me.Status.Location = New System.Drawing.Point(220, 189)
		 Me.Status.Name = "Status"
		 Me.Status.Size = New System.Drawing.Size(164, 21)
		 Me.Status.TabIndex = 27
		 ' 
		 ' Lastname
		 ' 
		 Me.Lastname.Location = New System.Drawing.Point(220, 70)
		 Me.Lastname.Name = "Lastname"
		 Me.Lastname.Size = New System.Drawing.Size(165, 20)
		 Me.Lastname.TabIndex = 28
		 ' 
		 ' label3
		 ' 
		 Me.label3.AutoSize = True
		 Me.label3.Location = New System.Drawing.Point(217, 54)
		 Me.label3.Name = "label3"
		 Me.label3.Size = New System.Drawing.Size(97, 13)
		 Me.label3.TabIndex = 2
		 Me.label3.Text = "Patient Last Name:"
		 ' 
		 ' columnHeader7
		 ' 
		 Me.columnHeader7.DisplayIndex = 0
		 Me.columnHeader7.Text = "Patient ID"
		 Me.columnHeader7.Width = 100
		 ' 
		 ' columnHeader8
		 ' 
		 Me.columnHeader8.DisplayIndex = 1
		 Me.columnHeader8.Text = "Patient Name"
		 Me.columnHeader8.Width = 150
		 ' 
		 ' QueryForm
		 ' 
		 Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
		 Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		 Me.ClientSize = New System.Drawing.Size(558, 412)
		 Me.Controls.Add(Me.Lastname)
		 Me.Controls.Add(Me.Status)
		 Me.Controls.Add(Me.label14)
		 Me.Controls.Add(Me.Modality)
		 Me.Controls.Add(Me.groupBox2)
		 Me.Controls.Add(Me.groupBox1)
		 Me.Controls.Add(Me.SearchResults)
		 Me.Controls.Add(Me.label9)
		 Me.Controls.Add(Me.buttonOK)
		 Me.Controls.Add(Me.button3)
		 Me.Controls.Add(Me.buttonClear)
		 Me.Controls.Add(Me.buttonQuery)
		 Me.Controls.Add(Me.PerformedStationAe)
		 Me.Controls.Add(Me.label8)
		 Me.Controls.Add(Me.ScheduledProcedureId)
		 Me.Controls.Add(Me.label7)
		 Me.Controls.Add(Me.RequestedProcedureId)
		 Me.Controls.Add(Me.label6)
		 Me.Controls.Add(Me.label5)
		 Me.Controls.Add(Me.AccessionNumber)
		 Me.Controls.Add(Me.label4)
		 Me.Controls.Add(Me.Firstname)
		 Me.Controls.Add(Me.label3)
		 Me.Controls.Add(Me.label2)
		 Me.Controls.Add(Me.PatientId)
		 Me.Controls.Add(Me.label1)
		 Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		 Me.MinimizeBox = False
		 Me.Name = "QueryForm"
		 Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
		 Me.Text = "Modality Performed Procedure Step Query"
'		 Me.Load += New System.EventHandler(Me.QueryForm_Load);
		 Me.groupBox1.ResumeLayout(False)
		 Me.groupBox1.PerformLayout()
		 Me.groupBox2.ResumeLayout(False)
		 Me.groupBox2.PerformLayout()
		 Me.ResumeLayout(False)
		 Me.PerformLayout()

	  End Sub

	  #End Region

	  Private label1 As System.Windows.Forms.Label
	  Private PatientId As System.Windows.Forms.TextBox
	  Private label2 As System.Windows.Forms.Label
	  Private Firstname As System.Windows.Forms.TextBox
	  Private AccessionNumber As System.Windows.Forms.TextBox
	  Private label4 As System.Windows.Forms.Label
	  Private label5 As System.Windows.Forms.Label
	  Private RequestedProcedureId As System.Windows.Forms.TextBox
	  Private label6 As System.Windows.Forms.Label
	  Private ScheduledProcedureId As System.Windows.Forms.TextBox
	  Private label7 As System.Windows.Forms.Label
	  Private PerformedStationAe As System.Windows.Forms.TextBox
	  Private label8 As System.Windows.Forms.Label
	  Private WithEvents buttonQuery As System.Windows.Forms.Button
	  Private WithEvents buttonClear As System.Windows.Forms.Button
	  Private button3 As System.Windows.Forms.Button
	  Private buttonOK As System.Windows.Forms.Button
	  Private label9 As System.Windows.Forms.Label
	  Private WithEvents SearchResults As System.Windows.Forms.ListView
	  Private columnHeader1 As System.Windows.Forms.ColumnHeader
	  Private columnHeader2 As System.Windows.Forms.ColumnHeader
	  Private StartDateBegin As System.Windows.Forms.DateTimePicker
	  Private groupBox1 As System.Windows.Forms.GroupBox
	  Private groupBox2 As System.Windows.Forms.GroupBox
	  Private StartDateEnd As System.Windows.Forms.DateTimePicker
	  Private label11 As System.Windows.Forms.Label
	  Private label10 As System.Windows.Forms.Label
	  Private EndDateEnd As System.Windows.Forms.DateTimePicker
	  Private label12 As System.Windows.Forms.Label
	  Private label13 As System.Windows.Forms.Label
	  Private EndDateBegin As System.Windows.Forms.DateTimePicker
	  Private columnHeader3 As System.Windows.Forms.ColumnHeader
	  Private columnHeader4 As System.Windows.Forms.ColumnHeader
	  Private Modality As System.Windows.Forms.ComboBox
	  Private columnHeader5 As System.Windows.Forms.ColumnHeader
	  Private columnHeader6 As System.Windows.Forms.ColumnHeader
	  Private label14 As System.Windows.Forms.Label
	  Private Status As System.Windows.Forms.ComboBox
	  Private Lastname As System.Windows.Forms.TextBox
	  Private label3 As System.Windows.Forms.Label
	  Private columnHeader7 As System.Windows.Forms.ColumnHeader
	  Private columnHeader8 As System.Windows.Forms.ColumnHeader
   End Class
End Namespace