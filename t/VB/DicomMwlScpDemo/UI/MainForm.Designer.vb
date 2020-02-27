Imports Microsoft.VisualBasic
Imports System
Namespace DicomDemo
	Public Partial Class MainForm
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
			Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
			Me.tabControl1 = New System.Windows.Forms.TabControl()
			Me.tabSCPProperties = New System.Windows.Forms.TabPage()
			Me.grpClients = New System.Windows.Forms.GroupBox()
			Me.lblSeparator1 = New System.Windows.Forms.Label()
			Me.lstClients = New System.Windows.Forms.ListView()
			Me.columnHeader1 = New System.Windows.Forms.ColumnHeader()
			Me.columnHeader2 = New System.Windows.Forms.ColumnHeader()
			Me.btnDeleteClient = New System.Windows.Forms.Button()
			Me.btnAddClient = New System.Windows.Forms.Button()
			Me.txtIP = New System.Windows.Forms.TextBox()
			Me.txtCallingAE = New System.Windows.Forms.TextBox()
			Me.label7 = New System.Windows.Forms.Label()
			Me.label6 = New System.Windows.Forms.Label()
			Me.label5 = New System.Windows.Forms.Label()
			Me.grpSCP = New System.Windows.Forms.GroupBox()
			Me.txtConcurrentConnections = New System.Windows.Forms.TextBox()
			Me.txtPort = New System.Windows.Forms.TextBox()
			Me.txtCalledAE = New System.Windows.Forms.TextBox()
			Me.label4 = New System.Windows.Forms.Label()
			Me.label3 = New System.Windows.Forms.Label()
			Me.label2 = New System.Windows.Forms.Label()
			Me.btnStop = New System.Windows.Forms.Button()
			Me.btnStart = New System.Windows.Forms.Button()
			Me.label1 = New System.Windows.Forms.Label()
			Me.pictureBox1 = New System.Windows.Forms.PictureBox()
			Me.tabWorklistItems = New System.Windows.Forms.TabPage()
			Me.lstDatabase = New System.Windows.Forms.ListView()
			Me.btnEditRecord = New System.Windows.Forms.Button()
			Me.btnDeleteRecord = New System.Windows.Forms.Button()
			Me.btnAddRecord = New System.Windows.Forms.Button()
			Me.label12 = New System.Windows.Forms.Label()
			Me.label11 = New System.Windows.Forms.Label()
			Me.label9 = New System.Windows.Forms.Label()
			Me.label8 = New System.Windows.Forms.Label()
			Me.pictureBox2 = New System.Windows.Forms.PictureBox()
			Me.tabLog = New System.Windows.Forms.TabPage()
			Me.txtLog = New System.Windows.Forms.TextBox()
			Me.btnClearAll = New System.Windows.Forms.Button()
			Me.btnClose = New System.Windows.Forms.Button()
			Me.tabControl1.SuspendLayout()
			Me.tabSCPProperties.SuspendLayout()
			Me.grpClients.SuspendLayout()
			Me.grpSCP.SuspendLayout()
			CType(Me.pictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.tabWorklistItems.SuspendLayout()
			CType(Me.pictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.tabLog.SuspendLayout()
			Me.SuspendLayout()
			' 
			' tabControl1
			' 
			Me.tabControl1.Controls.Add(Me.tabSCPProperties)
			Me.tabControl1.Controls.Add(Me.tabWorklistItems)
			Me.tabControl1.Controls.Add(Me.tabLog)
			Me.tabControl1.Location = New System.Drawing.Point(12, 12)
			Me.tabControl1.Name = "tabControl1"
			Me.tabControl1.SelectedIndex = 0
			Me.tabControl1.Size = New System.Drawing.Size(632, 493)
			Me.tabControl1.TabIndex = 0
			' 
			' tabSCPProperties
			' 
			Me.tabSCPProperties.Controls.Add(Me.grpClients)
			Me.tabSCPProperties.Controls.Add(Me.grpSCP)
			Me.tabSCPProperties.Controls.Add(Me.btnStop)
			Me.tabSCPProperties.Controls.Add(Me.btnStart)
			Me.tabSCPProperties.Controls.Add(Me.label1)
			Me.tabSCPProperties.Controls.Add(Me.pictureBox1)
			Me.tabSCPProperties.Location = New System.Drawing.Point(4, 22)
			Me.tabSCPProperties.Name = "tabSCPProperties"
			Me.tabSCPProperties.Padding = New System.Windows.Forms.Padding(3)
			Me.tabSCPProperties.Size = New System.Drawing.Size(624, 467)
			Me.tabSCPProperties.TabIndex = 0
			Me.tabSCPProperties.Text = "SCP Properties"
			Me.tabSCPProperties.UseVisualStyleBackColor = True
			' 
			' grpClients
			' 
			Me.grpClients.Controls.Add(Me.lblSeparator1)
			Me.grpClients.Controls.Add(Me.lstClients)
			Me.grpClients.Controls.Add(Me.btnDeleteClient)
			Me.grpClients.Controls.Add(Me.btnAddClient)
			Me.grpClients.Controls.Add(Me.txtIP)
			Me.grpClients.Controls.Add(Me.txtCallingAE)
			Me.grpClients.Controls.Add(Me.label7)
			Me.grpClients.Controls.Add(Me.label6)
			Me.grpClients.Controls.Add(Me.label5)
			Me.grpClients.Location = New System.Drawing.Point(51, 156)
			Me.grpClients.Name = "grpClients"
			Me.grpClients.Size = New System.Drawing.Size(567, 276)
			Me.grpClients.TabIndex = 5
			Me.grpClients.TabStop = False
			Me.grpClients.Text = "Clients"
			' 
			' lblSeparator1
			' 
			Me.lblSeparator1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
			Me.lblSeparator1.Location = New System.Drawing.Point(9, 97)
			Me.lblSeparator1.Name = "lblSeparator1"
			Me.lblSeparator1.Size = New System.Drawing.Size(464, 2)
			Me.lblSeparator1.TabIndex = 8
			' 
			' lstClients
			' 
			Me.lstClients.Columns.AddRange(New System.Windows.Forms.ColumnHeader() { Me.columnHeader1, Me.columnHeader2})
			Me.lstClients.FullRowSelect = True
			Me.lstClients.GridLines = True
			Me.lstClients.Location = New System.Drawing.Point(6, 115)
			Me.lstClients.MultiSelect = False
			Me.lstClients.Name = "lstClients"
			Me.lstClients.Size = New System.Drawing.Size(464, 155)
			Me.lstClients.TabIndex = 7
			Me.lstClients.UseCompatibleStateImageBehavior = False
			Me.lstClients.View = System.Windows.Forms.View.Details
			' 
			' columnHeader1
			' 
			Me.columnHeader1.Text = "Calling AE Title"
			Me.columnHeader1.Width = 230
			' 
			' columnHeader2
			' 
			Me.columnHeader2.Text = "IP Address"
			Me.columnHeader2.Width = 230
			' 
			' btnDeleteClient
			' 
			Me.btnDeleteClient.Location = New System.Drawing.Point(476, 247)
			Me.btnDeleteClient.Name = "btnDeleteClient"
			Me.btnDeleteClient.Size = New System.Drawing.Size(85, 23)
			Me.btnDeleteClient.TabIndex = 6
			Me.btnDeleteClient.Text = "Delete Client"
			Me.btnDeleteClient.UseVisualStyleBackColor = True
'			Me.btnDeleteClient.Click += New System.EventHandler(Me.btnDeleteClient_Click);
			' 
			' btnAddClient
			' 
			Me.btnAddClient.Location = New System.Drawing.Point(379, 71)
			Me.btnAddClient.Name = "btnAddClient"
			Me.btnAddClient.Size = New System.Drawing.Size(94, 23)
			Me.btnAddClient.TabIndex = 5
			Me.btnAddClient.Text = "Add to List >>"
			Me.btnAddClient.UseVisualStyleBackColor = True
'			Me.btnAddClient.Click += New System.EventHandler(Me.btnAddClient_Click);
			' 
			' txtIP
			' 
			Me.txtIP.Location = New System.Drawing.Point(103, 45)
			Me.txtIP.Name = "txtIP"
			Me.txtIP.Size = New System.Drawing.Size(370, 20)
			Me.txtIP.TabIndex = 4
			' 
			' txtCallingAE
			' 
			Me.txtCallingAE.Location = New System.Drawing.Point(103, 21)
			Me.txtCallingAE.Name = "txtCallingAE"
			Me.txtCallingAE.Size = New System.Drawing.Size(370, 20)
			Me.txtCallingAE.TabIndex = 3
			' 
			' label7
			' 
			Me.label7.AutoSize = True
			Me.label7.Location = New System.Drawing.Point(6, 99)
			Me.label7.Name = "label7"
			Me.label7.Size = New System.Drawing.Size(327, 13)
			Me.label7.TabIndex = 2
			Me.label7.Text = "Note: If you leave this list empty, any client can connect to the SCP."
			' 
			' label6
			' 
			Me.label6.AutoSize = True
			Me.label6.Location = New System.Drawing.Point(16, 48)
			Me.label6.Name = "label6"
			Me.label6.Size = New System.Drawing.Size(61, 13)
			Me.label6.TabIndex = 1
			Me.label6.Text = "IP Address:"
			' 
			' label5
			' 
			Me.label5.AutoSize = True
			Me.label5.Location = New System.Drawing.Point(16, 24)
			Me.label5.Name = "label5"
			Me.label5.Size = New System.Drawing.Size(81, 13)
			Me.label5.TabIndex = 0
			Me.label5.Text = "Calling AE Title:"
			' 
			' grpSCP
			' 
			Me.grpSCP.Controls.Add(Me.txtConcurrentConnections)
			Me.grpSCP.Controls.Add(Me.txtPort)
			Me.grpSCP.Controls.Add(Me.txtCalledAE)
			Me.grpSCP.Controls.Add(Me.label4)
			Me.grpSCP.Controls.Add(Me.label3)
			Me.grpSCP.Controls.Add(Me.label2)
			Me.grpSCP.Location = New System.Drawing.Point(51, 48)
			Me.grpSCP.Name = "grpSCP"
			Me.grpSCP.Size = New System.Drawing.Size(567, 102)
			Me.grpSCP.TabIndex = 4
			Me.grpSCP.TabStop = False
			Me.grpSCP.Text = "Service Class Provider (SCP)"
			' 
			' txtConcurrentConnections
			' 
			Me.txtConcurrentConnections.Location = New System.Drawing.Point(172, 69)
			Me.txtConcurrentConnections.Name = "txtConcurrentConnections"
			Me.txtConcurrentConnections.Size = New System.Drawing.Size(389, 20)
			Me.txtConcurrentConnections.TabIndex = 5
			' 
			' txtPort
			' 
			Me.txtPort.Location = New System.Drawing.Point(172, 45)
			Me.txtPort.Name = "txtPort"
			Me.txtPort.Size = New System.Drawing.Size(389, 20)
			Me.txtPort.TabIndex = 4
			' 
			' txtCalledAE
			' 
			Me.txtCalledAE.Location = New System.Drawing.Point(172, 21)
			Me.txtCalledAE.Name = "txtCalledAE"
			Me.txtCalledAE.Size = New System.Drawing.Size(389, 20)
			Me.txtCalledAE.TabIndex = 3
			' 
			' label4
			' 
			Me.label4.AutoSize = True
			Me.label4.Location = New System.Drawing.Point(16, 72)
			Me.label4.Name = "label4"
			Me.label4.Size = New System.Drawing.Size(150, 13)
			Me.label4.TabIndex = 2
			Me.label4.Text = "Max. Concurrent Connections:"
			' 
			' label3
			' 
			Me.label3.AutoSize = True
			Me.label3.Location = New System.Drawing.Point(16, 48)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(69, 13)
			Me.label3.TabIndex = 1
			Me.label3.Text = "Port Number:"
			' 
			' label2
			' 
			Me.label2.AutoSize = True
			Me.label2.Location = New System.Drawing.Point(16, 24)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(79, 13)
			Me.label2.TabIndex = 0
			Me.label2.Text = "Called AE Title:"
			' 
			' btnStop
			' 
			Me.btnStop.Enabled = False
			Me.btnStop.Location = New System.Drawing.Point(543, 438)
			Me.btnStop.Name = "btnStop"
			Me.btnStop.Size = New System.Drawing.Size(75, 23)
			Me.btnStop.TabIndex = 3
			Me.btnStop.Text = "Stop"
			Me.btnStop.UseVisualStyleBackColor = True
'			Me.btnStop.Click += New System.EventHandler(Me.btnStop_Click);
			' 
			' btnStart
			' 
			Me.btnStart.Location = New System.Drawing.Point(462, 438)
			Me.btnStart.Name = "btnStart"
			Me.btnStart.Size = New System.Drawing.Size(75, 23)
			Me.btnStart.TabIndex = 2
			Me.btnStart.Text = "Start"
			Me.btnStart.UseVisualStyleBackColor = True
'			Me.btnStart.Click += New System.EventHandler(Me.btnStart_Click);
			' 
			' label1
			' 
			Me.label1.AutoSize = True
			Me.label1.Location = New System.Drawing.Point(48, 16)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(519, 13)
			Me.label1.TabIndex = 1
			Me.label1.Text = "In order to run this worklist SCP, fill the required properties below then click " & "the start button to start the server."
			' 
			' pictureBox1
			' 
			Me.pictureBox1.Image = (CType(resources.GetObject("pictureBox1.Image"), System.Drawing.Image))
			Me.pictureBox1.Location = New System.Drawing.Point(0, 0)
			Me.pictureBox1.Name = "pictureBox1"
			Me.pictureBox1.Size = New System.Drawing.Size(32, 32)
			Me.pictureBox1.TabIndex = 0
			Me.pictureBox1.TabStop = False
			' 
			' tabWorklistItems
			' 
			Me.tabWorklistItems.Controls.Add(Me.lstDatabase)
			Me.tabWorklistItems.Controls.Add(Me.btnEditRecord)
			Me.tabWorklistItems.Controls.Add(Me.btnDeleteRecord)
			Me.tabWorklistItems.Controls.Add(Me.btnAddRecord)
			Me.tabWorklistItems.Controls.Add(Me.label12)
			Me.tabWorklistItems.Controls.Add(Me.label11)
			Me.tabWorklistItems.Controls.Add(Me.label9)
			Me.tabWorklistItems.Controls.Add(Me.label8)
			Me.tabWorklistItems.Controls.Add(Me.pictureBox2)
			Me.tabWorklistItems.Location = New System.Drawing.Point(4, 22)
			Me.tabWorklistItems.Name = "tabWorklistItems"
			Me.tabWorklistItems.Padding = New System.Windows.Forms.Padding(3)
			Me.tabWorklistItems.Size = New System.Drawing.Size(624, 467)
			Me.tabWorklistItems.TabIndex = 1
			Me.tabWorklistItems.Text = "Worklist Items"
			Me.tabWorklistItems.UseVisualStyleBackColor = True
			' 
			' lstDatabase
			' 
			Me.lstDatabase.FullRowSelect = True
			Me.lstDatabase.GridLines = True
			Me.lstDatabase.HideSelection = False
			Me.lstDatabase.Location = New System.Drawing.Point(6, 124)
			Me.lstDatabase.MultiSelect = False
			Me.lstDatabase.Name = "lstDatabase"
			Me.lstDatabase.Size = New System.Drawing.Size(522, 337)
			Me.lstDatabase.TabIndex = 9
			Me.lstDatabase.UseCompatibleStateImageBehavior = False
			Me.lstDatabase.View = System.Windows.Forms.View.Details
			' 
			' btnEditRecord
			' 
			Me.btnEditRecord.Location = New System.Drawing.Point(543, 153)
			Me.btnEditRecord.Name = "btnEditRecord"
			Me.btnEditRecord.Size = New System.Drawing.Size(75, 23)
			Me.btnEditRecord.TabIndex = 8
			Me.btnEditRecord.Text = "Edit"
			Me.btnEditRecord.UseVisualStyleBackColor = True
'			Me.btnEditRecord.Click += New System.EventHandler(Me.btnEditRecord_Click);
			' 
			' btnDeleteRecord
			' 
			Me.btnDeleteRecord.Location = New System.Drawing.Point(543, 182)
			Me.btnDeleteRecord.Name = "btnDeleteRecord"
			Me.btnDeleteRecord.Size = New System.Drawing.Size(75, 23)
			Me.btnDeleteRecord.TabIndex = 7
			Me.btnDeleteRecord.Text = "Delete"
			Me.btnDeleteRecord.UseVisualStyleBackColor = True
'			Me.btnDeleteRecord.Click += New System.EventHandler(Me.btnDeleteRecord_Click);
			' 
			' btnAddRecord
			' 
			Me.btnAddRecord.Location = New System.Drawing.Point(543, 124)
			Me.btnAddRecord.Name = "btnAddRecord"
			Me.btnAddRecord.Size = New System.Drawing.Size(75, 23)
			Me.btnAddRecord.TabIndex = 6
			Me.btnAddRecord.Text = "Add"
			Me.btnAddRecord.UseVisualStyleBackColor = True
'			Me.btnAddRecord.Click += New System.EventHandler(Me.btnAddRecord_Click);
			' 
			' label12
			' 
			Me.label12.AutoSize = True
			Me.label12.Location = New System.Drawing.Point(48, 93)
			Me.label12.Name = "label12"
			Me.label12.Size = New System.Drawing.Size(380, 13)
			Me.label12.TabIndex = 5
			Me.label12.Text = "- To modify the Value of an Attribute, enter the new value and then press Enter."
			' 
			' label11
			' 
			Me.label11.AutoSize = True
			Me.label11.Location = New System.Drawing.Point(48, 69)
			Me.label11.Name = "label11"
			Me.label11.Size = New System.Drawing.Size(552, 13)
			Me.label11.TabIndex = 4
			Me.label11.Text = "- To delete a Worklist Item, select the whole record by clicking the correspondin" & "g left bar cell and then press Delete."
			' 
			' label9
			' 
			Me.label9.Location = New System.Drawing.Point(48, 32)
			Me.label9.Name = "label9"
			Me.label9.Size = New System.Drawing.Size(570, 26)
			Me.label9.TabIndex = 2
			Me.label9.Text = "- To add a new Worklist Item, set the cursor on the last record denoted by '*' an" & "d then add the values you want.               The data will be saved once the fo" & "cus goes out of this record."
			' 
			' label8
			' 
			Me.label8.AutoSize = True
			Me.label8.Location = New System.Drawing.Point(48, 8)
			Me.label8.Name = "label8"
			Me.label8.Size = New System.Drawing.Size(480, 13)
			Me.label8.TabIndex = 1
			Me.label8.Text = "In the list below, you can add and delete Worklist Items, as well as update the V" & "alue of any Attribute:"
			' 
			' pictureBox2
			' 
			Me.pictureBox2.Image = (CType(resources.GetObject("pictureBox2.Image"), System.Drawing.Image))
			Me.pictureBox2.Location = New System.Drawing.Point(0, 0)
			Me.pictureBox2.Name = "pictureBox2"
			Me.pictureBox2.Size = New System.Drawing.Size(32, 32)
			Me.pictureBox2.TabIndex = 0
			Me.pictureBox2.TabStop = False
			' 
			' tabLog
			' 
			Me.tabLog.Controls.Add(Me.txtLog)
			Me.tabLog.Controls.Add(Me.btnClearAll)
			Me.tabLog.Location = New System.Drawing.Point(4, 22)
			Me.tabLog.Name = "tabLog"
			Me.tabLog.Padding = New System.Windows.Forms.Padding(3)
			Me.tabLog.Size = New System.Drawing.Size(624, 467)
			Me.tabLog.TabIndex = 2
			Me.tabLog.Text = "Log"
			Me.tabLog.UseVisualStyleBackColor = True
			' 
			' txtLog
			' 
			Me.txtLog.Location = New System.Drawing.Point(6, 6)
			Me.txtLog.Multiline = True
			Me.txtLog.Name = "txtLog"
			Me.txtLog.ReadOnly = True
			Me.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Both
			Me.txtLog.Size = New System.Drawing.Size(612, 426)
			Me.txtLog.TabIndex = 1
			' 
			' btnClearAll
			' 
			Me.btnClearAll.Location = New System.Drawing.Point(543, 438)
			Me.btnClearAll.Name = "btnClearAll"
			Me.btnClearAll.Size = New System.Drawing.Size(75, 23)
			Me.btnClearAll.TabIndex = 0
			Me.btnClearAll.Text = "Clear All"
			Me.btnClearAll.UseVisualStyleBackColor = True
'			Me.btnClearAll.Click += New System.EventHandler(Me.btnClearAll_Click);
			' 
			' btnClose
			' 
			Me.btnClose.Location = New System.Drawing.Point(565, 511)
			Me.btnClose.Name = "btnClose"
			Me.btnClose.Size = New System.Drawing.Size(75, 23)
			Me.btnClose.TabIndex = 1
			Me.btnClose.Text = "Close"
			Me.btnClose.UseVisualStyleBackColor = True
'			Me.btnClose.Click += New System.EventHandler(Me.btnClose_Click);
			' 
			' MainForm
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(656, 546)
			Me.Controls.Add(Me.btnClose)
			Me.Controls.Add(Me.tabControl1)
			Me.Icon = (CType(resources.GetObject("$this.Icon"), System.Drawing.Icon))
			Me.Name = "MainForm"
			Me.Text = "Modality Worklist Provider"
'			Me.FormClosing += New System.Windows.Forms.FormClosingEventHandler(Me.MainForm_FormClosing);
'			Me.Load += New System.EventHandler(Me.MainForm_Load);
			Me.tabControl1.ResumeLayout(False)
			Me.tabSCPProperties.ResumeLayout(False)
			Me.tabSCPProperties.PerformLayout()
			Me.grpClients.ResumeLayout(False)
			Me.grpClients.PerformLayout()
			Me.grpSCP.ResumeLayout(False)
			Me.grpSCP.PerformLayout()
			CType(Me.pictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
			Me.tabWorklistItems.ResumeLayout(False)
			Me.tabWorklistItems.PerformLayout()
			CType(Me.pictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
			Me.tabLog.ResumeLayout(False)
			Me.tabLog.PerformLayout()
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Private tabControl1 As System.Windows.Forms.TabControl
		Private tabSCPProperties As System.Windows.Forms.TabPage
		Private tabWorklistItems As System.Windows.Forms.TabPage
		Private tabLog As System.Windows.Forms.TabPage
		Private WithEvents btnClose As System.Windows.Forms.Button
		Private txtLog As System.Windows.Forms.TextBox
		Private WithEvents btnClearAll As System.Windows.Forms.Button
		Private grpClients As System.Windows.Forms.GroupBox
		Private grpSCP As System.Windows.Forms.GroupBox
		Private txtConcurrentConnections As System.Windows.Forms.TextBox
		Private txtPort As System.Windows.Forms.TextBox
		Private txtCalledAE As System.Windows.Forms.TextBox
		Private label4 As System.Windows.Forms.Label
		Private label3 As System.Windows.Forms.Label
		Private label2 As System.Windows.Forms.Label
		Private WithEvents btnStop As System.Windows.Forms.Button
		Private WithEvents btnStart As System.Windows.Forms.Button
		Private label1 As System.Windows.Forms.Label
		Private pictureBox1 As System.Windows.Forms.PictureBox
		Private lblSeparator1 As System.Windows.Forms.Label
		Private WithEvents btnDeleteClient As System.Windows.Forms.Button
		Private WithEvents btnAddClient As System.Windows.Forms.Button
		Private txtIP As System.Windows.Forms.TextBox
		Private txtCallingAE As System.Windows.Forms.TextBox
		Private label7 As System.Windows.Forms.Label
		Private label6 As System.Windows.Forms.Label
		Private label5 As System.Windows.Forms.Label
		Private columnHeader1 As System.Windows.Forms.ColumnHeader
		Private columnHeader2 As System.Windows.Forms.ColumnHeader
		Private WithEvents btnEditRecord As System.Windows.Forms.Button
		Private WithEvents btnDeleteRecord As System.Windows.Forms.Button
		Private WithEvents btnAddRecord As System.Windows.Forms.Button
		Private label12 As System.Windows.Forms.Label
		Private label11 As System.Windows.Forms.Label
		Private label9 As System.Windows.Forms.Label
		Private label8 As System.Windows.Forms.Label
		Private pictureBox2 As System.Windows.Forms.PictureBox
		Public lstClients As System.Windows.Forms.ListView
		Public lstDatabase As System.Windows.Forms.ListView

	End Class
End Namespace