Namespace Leadtools.Dicom.Server.Manager.Dialogs
   Partial Public Class EventLogDialog
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

#Region "Windows Form Designer generated code"

      ''' <summary>
      ''' Required method for Designer support - do not modify
      ''' the contents of this method with the code editor.
      ''' </summary>
      Private Sub InitializeComponent()
         Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EventLogDialog))
         Me.textBoxClientAeTitle = New System.Windows.Forms.TextBox
         Me.checkBoxLastLogs = New System.Windows.Forms.CheckBox
         Me.buttonClose = New System.Windows.Forms.Button
         Me.numericUpDownLastLogs = New System.Windows.Forms.NumericUpDown
         Me.labelLastLogs = New System.Windows.Forms.Label
         Me.checkBoxClientAeTitle = New System.Windows.Forms.CheckBox
         Me.groupBoxQueryOptions = New System.Windows.Forms.GroupBox
         Me.textBoxServerAeTitle = New System.Windows.Forms.TextBox
         Me.checkBoxServerAeTitle = New System.Windows.Forms.CheckBox
         Me.buttonDeleteSelected = New System.Windows.Forms.Button
         Me.buttonDetail = New System.Windows.Forms.Button
         Me.buttonDeleteAll = New System.Windows.Forms.Button
         Me.buttonQuery = New System.Windows.Forms.Button
         Me.columnDatasetPath = New System.Windows.Forms.ColumnHeader
         Me.columnClientAeTitle = New System.Windows.Forms.ColumnHeader
         Me.columnServerPort = New System.Windows.Forms.ColumnHeader
         Me.columnIpAddress = New System.Windows.Forms.ColumnHeader
         Me.columnServerAeTitle = New System.Windows.Forms.ColumnHeader
         Me.columnClientHostAddress = New System.Windows.Forms.ColumnHeader
         Me.columnClientPort = New System.Windows.Forms.ColumnHeader
         Me.columnDescription = New System.Windows.Forms.ColumnHeader
         Me.columnMessageDirection = New System.Windows.Forms.ColumnHeader
         Me.columnEventDateTime = New System.Windows.Forms.ColumnHeader
         Me.columnCommand = New System.Windows.Forms.ColumnHeader
         Me.listViewEventLog = New System.Windows.Forms.ListView
         Me.checkBoxEnableLogging = New System.Windows.Forms.CheckBox
         Me.checkBoxLogDatasets = New System.Windows.Forms.CheckBox
         CType(Me.numericUpDownLastLogs, System.ComponentModel.ISupportInitialize).BeginInit()
         Me.groupBoxQueryOptions.SuspendLayout()
         Me.SuspendLayout()
         '
         'textBoxClientAeTitle
         '
         Me.textBoxClientAeTitle.Location = New System.Drawing.Point(116, 64)
         Me.textBoxClientAeTitle.Name = "textBoxClientAeTitle"
         Me.textBoxClientAeTitle.Size = New System.Drawing.Size(120, 20)
         Me.textBoxClientAeTitle.TabIndex = 10
         '
         'checkBoxLastLogs
         '
         Me.checkBoxLastLogs.AutoSize = True
         Me.checkBoxLastLogs.Location = New System.Drawing.Point(12, 20)
         Me.checkBoxLastLogs.Name = "checkBoxLastLogs"
         Me.checkBoxLastLogs.Size = New System.Drawing.Size(46, 17)
         Me.checkBoxLastLogs.TabIndex = 4
         Me.checkBoxLastLogs.Text = "Last"
         Me.checkBoxLastLogs.UseVisualStyleBackColor = True
         '
         'buttonClose
         '
         Me.buttonClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
         Me.buttonClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
         Me.buttonClose.Location = New System.Drawing.Point(654, 499)
         Me.buttonClose.Name = "buttonClose"
         Me.buttonClose.Size = New System.Drawing.Size(75, 23)
         Me.buttonClose.TabIndex = 13
         Me.buttonClose.Text = "Close"
         Me.buttonClose.UseVisualStyleBackColor = True
         '
         'numericUpDownLastLogs
         '
         Me.numericUpDownLastLogs.Location = New System.Drawing.Point(116, 18)
         Me.numericUpDownLastLogs.Name = "numericUpDownLastLogs"
         Me.numericUpDownLastLogs.Size = New System.Drawing.Size(74, 20)
         Me.numericUpDownLastLogs.TabIndex = 5
         '
         'labelLastLogs
         '
         Me.labelLastLogs.AutoSize = True
         Me.labelLastLogs.Location = New System.Drawing.Point(196, 22)
         Me.labelLastLogs.Name = "labelLastLogs"
         Me.labelLastLogs.Size = New System.Drawing.Size(36, 13)
         Me.labelLastLogs.TabIndex = 6
         Me.labelLastLogs.Text = "Log(s)"
         '
         'checkBoxClientAeTitle
         '
         Me.checkBoxClientAeTitle.AutoSize = True
         Me.checkBoxClientAeTitle.Location = New System.Drawing.Point(12, 66)
         Me.checkBoxClientAeTitle.Name = "checkBoxClientAeTitle"
         Me.checkBoxClientAeTitle.Size = New System.Drawing.Size(92, 17)
         Me.checkBoxClientAeTitle.TabIndex = 9
         Me.checkBoxClientAeTitle.Text = "Client AE Title"
         Me.checkBoxClientAeTitle.UseVisualStyleBackColor = True
         '
         'groupBoxQueryOptions
         '
         Me.groupBoxQueryOptions.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
         Me.groupBoxQueryOptions.Controls.Add(Me.textBoxClientAeTitle)
         Me.groupBoxQueryOptions.Controls.Add(Me.checkBoxLastLogs)
         Me.groupBoxQueryOptions.Controls.Add(Me.numericUpDownLastLogs)
         Me.groupBoxQueryOptions.Controls.Add(Me.labelLastLogs)
         Me.groupBoxQueryOptions.Controls.Add(Me.checkBoxClientAeTitle)
         Me.groupBoxQueryOptions.Controls.Add(Me.textBoxServerAeTitle)
         Me.groupBoxQueryOptions.Controls.Add(Me.checkBoxServerAeTitle)
         Me.groupBoxQueryOptions.Location = New System.Drawing.Point(12, 428)
         Me.groupBoxQueryOptions.Name = "groupBoxQueryOptions"
         Me.groupBoxQueryOptions.Size = New System.Drawing.Size(248, 94)
         Me.groupBoxQueryOptions.TabIndex = 8
         Me.groupBoxQueryOptions.TabStop = False
         Me.groupBoxQueryOptions.Text = "Query Options"
         '
         'textBoxServerAeTitle
         '
         Me.textBoxServerAeTitle.Location = New System.Drawing.Point(116, 41)
         Me.textBoxServerAeTitle.Name = "textBoxServerAeTitle"
         Me.textBoxServerAeTitle.Size = New System.Drawing.Size(121, 20)
         Me.textBoxServerAeTitle.TabIndex = 7
         '
         'checkBoxServerAeTitle
         '
         Me.checkBoxServerAeTitle.AutoSize = True
         Me.checkBoxServerAeTitle.Location = New System.Drawing.Point(12, 43)
         Me.checkBoxServerAeTitle.Name = "checkBoxServerAeTitle"
         Me.checkBoxServerAeTitle.Size = New System.Drawing.Size(97, 17)
         Me.checkBoxServerAeTitle.TabIndex = 8
         Me.checkBoxServerAeTitle.Text = "Server AE Title"
         Me.checkBoxServerAeTitle.UseVisualStyleBackColor = True
         '
         'buttonDeleteSelected
         '
         Me.buttonDeleteSelected.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
         Me.buttonDeleteSelected.Location = New System.Drawing.Point(462, 499)
         Me.buttonDeleteSelected.Name = "buttonDeleteSelected"
         Me.buttonDeleteSelected.Size = New System.Drawing.Size(105, 23)
         Me.buttonDeleteSelected.TabIndex = 11
         Me.buttonDeleteSelected.Text = "Delete Selected..."
         Me.buttonDeleteSelected.UseVisualStyleBackColor = True
         '
         'buttonDetail
         '
         Me.buttonDetail.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
         Me.buttonDetail.Location = New System.Drawing.Point(381, 499)
         Me.buttonDetail.Name = "buttonDetail"
         Me.buttonDetail.Size = New System.Drawing.Size(75, 23)
         Me.buttonDetail.TabIndex = 10
         Me.buttonDetail.Text = "Detail..."
         Me.buttonDetail.UseVisualStyleBackColor = True
         '
         'buttonDeleteAll
         '
         Me.buttonDeleteAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
         Me.buttonDeleteAll.Location = New System.Drawing.Point(573, 499)
         Me.buttonDeleteAll.Name = "buttonDeleteAll"
         Me.buttonDeleteAll.Size = New System.Drawing.Size(75, 23)
         Me.buttonDeleteAll.TabIndex = 12
         Me.buttonDeleteAll.Text = "Delete All..."
         Me.buttonDeleteAll.UseVisualStyleBackColor = True
         '
         'buttonQuery
         '
         Me.buttonQuery.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
         Me.buttonQuery.Location = New System.Drawing.Point(300, 499)
         Me.buttonQuery.Name = "buttonQuery"
         Me.buttonQuery.Size = New System.Drawing.Size(75, 23)
         Me.buttonQuery.TabIndex = 9
         Me.buttonQuery.Text = "Query"
         Me.buttonQuery.UseVisualStyleBackColor = True
         '
         'columnDatasetPath
         '
         Me.columnDatasetPath.Text = "Dataset Path"
         '
         'columnClientAeTitle
         '
         Me.columnClientAeTitle.Text = "Client AE Title"
         '
         'columnServerPort
         '
         Me.columnServerPort.Text = "Server Port"
         '
         'columnIpAddress
         '
         Me.columnIpAddress.Text = "IP Address"
         '
         'columnServerAeTitle
         '
         Me.columnServerAeTitle.Text = "Server AE Title"
         Me.columnServerAeTitle.Width = 84
         '
         'columnClientHostAddress
         '
         Me.columnClientHostAddress.Text = "Client Host Address"
         '
         'columnClientPort
         '
         Me.columnClientPort.Text = "Client Port"
         '
         'columnDescription
         '
         Me.columnDescription.Text = "Description"
         '
         'columnMessageDirection
         '
         Me.columnMessageDirection.Text = "MessageDirection"
         '
         'columnEventDateTime
         '
         Me.columnEventDateTime.Text = "Event Date Time"
         '
         'columnCommand
         '
         Me.columnCommand.Text = "Command"
         '
         'listViewEventLog
         '
         Me.listViewEventLog.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                     Or System.Windows.Forms.AnchorStyles.Left) _
                     Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
         Me.listViewEventLog.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.columnServerAeTitle, Me.columnIpAddress, Me.columnServerPort, Me.columnClientAeTitle, Me.columnClientHostAddress, Me.columnClientPort, Me.columnCommand, Me.columnEventDateTime, Me.columnMessageDirection, Me.columnDescription, Me.columnDatasetPath})
         Me.listViewEventLog.FullRowSelect = True
         Me.listViewEventLog.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
         Me.listViewEventLog.HideSelection = False
         Me.listViewEventLog.Location = New System.Drawing.Point(2, 4)
         Me.listViewEventLog.Name = "listViewEventLog"
         Me.listViewEventLog.Size = New System.Drawing.Size(736, 407)
         Me.listViewEventLog.TabIndex = 7
         Me.listViewEventLog.UseCompatibleStateImageBehavior = False
         Me.listViewEventLog.View = System.Windows.Forms.View.Details
         '
         'checkBoxEnableLogging
         '
         Me.checkBoxEnableLogging.AutoSize = True
         Me.checkBoxEnableLogging.Location = New System.Drawing.Point(300, 446)
         Me.checkBoxEnableLogging.Name = "checkBoxEnableLogging"
         Me.checkBoxEnableLogging.Size = New System.Drawing.Size(100, 17)
         Me.checkBoxEnableLogging.TabIndex = 14
         Me.checkBoxEnableLogging.Text = "Enable Logging"
         Me.checkBoxEnableLogging.UseVisualStyleBackColor = True
         '
         'checkBoxLogDatasets

         Me.checkBoxLogDatasets.AutoSize = True
         Me.checkBoxLogDatasets.Location = New System.Drawing.Point(300, 467)
         Me.checkBoxLogDatasets.Name = "checkBoxLogDatasets"
         Me.checkBoxLogDatasets.Size = New System.Drawing.Size(164, 17)
         Me.checkBoxLogDatasets.TabIndex = 3
         Me.checkBoxLogDatasets.Text = "Log Communication Datasets"
         Me.checkBoxLogDatasets.UseVisualStyleBackColor = True
         '
         'EventLogDialog
         '
         Me.AcceptButton = Me.buttonClose
         Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.CancelButton = Me.buttonClose
         Me.ClientSize = New System.Drawing.Size(741, 527)
         Me.Controls.Add(Me.checkBoxEnableLogging)
         Me.Controls.Add(Me.buttonClose)
         Me.Controls.Add(Me.groupBoxQueryOptions)
         Me.Controls.Add(Me.buttonDeleteSelected)
         Me.Controls.Add(Me.buttonDetail)
         Me.Controls.Add(Me.buttonDeleteAll)
         Me.Controls.Add(Me.buttonQuery)
         Me.Controls.Add(Me.listViewEventLog)
         Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
         Me.MinimizeBox = False
         Me.Name = "EventLogDialog"
         Me.ShowInTaskbar = False
         Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
         Me.Text = "Event Log"
         CType(Me.numericUpDownLastLogs, System.ComponentModel.ISupportInitialize).EndInit()
         Me.groupBoxQueryOptions.ResumeLayout(False)
         Me.groupBoxQueryOptions.PerformLayout()
         Me.ResumeLayout(False)
         Me.PerformLayout()

      End Sub
      Private WithEvents textBoxClientAeTitle As System.Windows.Forms.TextBox
      Private WithEvents checkBoxLastLogs As System.Windows.Forms.CheckBox
      Private WithEvents buttonClose As System.Windows.Forms.Button
      Private WithEvents numericUpDownLastLogs As System.Windows.Forms.NumericUpDown
      Private WithEvents labelLastLogs As System.Windows.Forms.Label
      Private WithEvents checkBoxClientAeTitle As System.Windows.Forms.CheckBox
      Private WithEvents groupBoxQueryOptions As System.Windows.Forms.GroupBox
      Private WithEvents textBoxServerAeTitle As System.Windows.Forms.TextBox
      Private WithEvents checkBoxServerAeTitle As System.Windows.Forms.CheckBox
      Private WithEvents buttonDeleteSelected As System.Windows.Forms.Button
      Private WithEvents buttonDetail As System.Windows.Forms.Button
      Private WithEvents buttonDeleteAll As System.Windows.Forms.Button
      Private WithEvents buttonQuery As System.Windows.Forms.Button
      Private WithEvents columnDatasetPath As System.Windows.Forms.ColumnHeader
      Private WithEvents columnClientAeTitle As System.Windows.Forms.ColumnHeader
      Private WithEvents columnServerPort As System.Windows.Forms.ColumnHeader
      Private WithEvents columnIpAddress As System.Windows.Forms.ColumnHeader
      Private WithEvents columnServerAeTitle As System.Windows.Forms.ColumnHeader
      Private WithEvents columnClientHostAddress As System.Windows.Forms.ColumnHeader
      Private WithEvents columnClientPort As System.Windows.Forms.ColumnHeader
      Private WithEvents columnDescription As System.Windows.Forms.ColumnHeader
      Private WithEvents columnMessageDirection As System.Windows.Forms.ColumnHeader
      Private WithEvents columnEventDateTime As System.Windows.Forms.ColumnHeader
      Private WithEvents columnCommand As System.Windows.Forms.ColumnHeader
      Private WithEvents listViewEventLog As System.Windows.Forms.ListView
      Private WithEvents checkBoxEnableLogging As System.Windows.Forms.CheckBox
      Private WithEvents checkBoxLogDatasets As System.Windows.Forms.CheckBox

#End Region

   End Class
End Namespace