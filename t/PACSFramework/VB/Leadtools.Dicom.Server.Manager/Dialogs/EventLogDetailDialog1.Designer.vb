<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EventLogDetailDialog
   Inherits System.Windows.Forms.Form

   'Form overrides dispose to clean up the component list.
   <System.Diagnostics.DebuggerNonUserCode()> _
   Protected Overrides Sub Dispose(ByVal disposing As Boolean)
      Try
         If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
         End If
      Finally
         MyBase.Dispose(disposing)
      End Try
   End Sub

   'Required by the Windows Form Designer
   Private components As System.ComponentModel.IContainer

   'NOTE: The following procedure is required by the Windows Form Designer
   'It can be modified using the Windows Form Designer.  
   'Do not modify it using the code editor.
   <System.Diagnostics.DebuggerStepThrough()> _
   Private Sub InitializeComponent()
      Me.buttonClose = New System.Windows.Forms.Button
      Me.buttonViewDataset = New System.Windows.Forms.Button
      Me.textBoxEventDateTime = New System.Windows.Forms.TextBox
      Me.textBoxClientPort = New System.Windows.Forms.TextBox
      Me.textBoxClientHostAddress = New System.Windows.Forms.TextBox
      Me.textBoxClientAeTitle = New System.Windows.Forms.TextBox
      Me.textBoxDescription = New System.Windows.Forms.TextBox
      Me.textBoxCommand = New System.Windows.Forms.TextBox
      Me.textBoxServerPort = New System.Windows.Forms.TextBox
      Me.textBoxServerIpAddress = New System.Windows.Forms.TextBox
      Me.labelEventDateTime = New System.Windows.Forms.Label
      Me.labelClientPort = New System.Windows.Forms.Label
      Me.labelClientHostAddress = New System.Windows.Forms.Label
      Me.labelClientAeTitle = New System.Windows.Forms.Label
      Me.labelDescription = New System.Windows.Forms.Label
      Me.labelCommand = New System.Windows.Forms.Label
      Me.labelServerPort = New System.Windows.Forms.Label
      Me.labelServerIpAddress = New System.Windows.Forms.Label
      Me.labelServerAeTitle = New System.Windows.Forms.Label
      Me.textBoxServerAeTitle = New System.Windows.Forms.TextBox
      Me.SuspendLayout()
      '
      'buttonClose
      '
      Me.buttonClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.buttonClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.buttonClose.Location = New System.Drawing.Point(419, 427)
      Me.buttonClose.Name = "buttonClose"
      Me.buttonClose.Size = New System.Drawing.Size(75, 23)
      Me.buttonClose.TabIndex = 39
      Me.buttonClose.Text = "Close"
      Me.buttonClose.UseVisualStyleBackColor = True
      '
      'buttonViewDataset
      '
      Me.buttonViewDataset.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.buttonViewDataset.Location = New System.Drawing.Point(18, 427)
      Me.buttonViewDataset.Name = "buttonViewDataset"
      Me.buttonViewDataset.Size = New System.Drawing.Size(92, 23)
      Me.buttonViewDataset.TabIndex = 38
      Me.buttonViewDataset.Text = "View Dataset..."
      Me.buttonViewDataset.UseVisualStyleBackColor = True
      '
      'textBoxEventDateTime
      '
      Me.textBoxEventDateTime.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.textBoxEventDateTime.Location = New System.Drawing.Point(372, 115)
      Me.textBoxEventDateTime.Name = "textBoxEventDateTime"
      Me.textBoxEventDateTime.ReadOnly = True
      Me.textBoxEventDateTime.Size = New System.Drawing.Size(123, 20)
      Me.textBoxEventDateTime.TabIndex = 35
      '
      'textBoxClientPort
      '
      Me.textBoxClientPort.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.textBoxClientPort.Location = New System.Drawing.Point(372, 81)
      Me.textBoxClientPort.Name = "textBoxClientPort"
      Me.textBoxClientPort.ReadOnly = True
      Me.textBoxClientPort.Size = New System.Drawing.Size(123, 20)
      Me.textBoxClientPort.TabIndex = 33
      '
      'textBoxClientHostAddress
      '
      Me.textBoxClientHostAddress.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.textBoxClientHostAddress.Location = New System.Drawing.Point(372, 47)
      Me.textBoxClientHostAddress.Name = "textBoxClientHostAddress"
      Me.textBoxClientHostAddress.ReadOnly = True
      Me.textBoxClientHostAddress.Size = New System.Drawing.Size(123, 20)
      Me.textBoxClientHostAddress.TabIndex = 31
      '
      'textBoxClientAeTitle
      '
      Me.textBoxClientAeTitle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.textBoxClientAeTitle.Location = New System.Drawing.Point(372, 13)
      Me.textBoxClientAeTitle.Name = "textBoxClientAeTitle"
      Me.textBoxClientAeTitle.ReadOnly = True
      Me.textBoxClientAeTitle.Size = New System.Drawing.Size(123, 20)
      Me.textBoxClientAeTitle.TabIndex = 29
      '
      'textBoxDescription
      '
      Me.textBoxDescription.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.textBoxDescription.Location = New System.Drawing.Point(18, 179)
      Me.textBoxDescription.Multiline = True
      Me.textBoxDescription.Name = "textBoxDescription"
      Me.textBoxDescription.ReadOnly = True
      Me.textBoxDescription.ScrollBars = System.Windows.Forms.ScrollBars.Both
      Me.textBoxDescription.Size = New System.Drawing.Size(477, 242)
      Me.textBoxDescription.TabIndex = 37
      '
      'textBoxCommand
      '
      Me.textBoxCommand.Location = New System.Drawing.Point(111, 115)
      Me.textBoxCommand.Name = "textBoxCommand"
      Me.textBoxCommand.ReadOnly = True
      Me.textBoxCommand.Size = New System.Drawing.Size(123, 20)
      Me.textBoxCommand.TabIndex = 27
      '
      'textBoxServerPort
      '
      Me.textBoxServerPort.Location = New System.Drawing.Point(111, 81)
      Me.textBoxServerPort.Name = "textBoxServerPort"
      Me.textBoxServerPort.ReadOnly = True
      Me.textBoxServerPort.Size = New System.Drawing.Size(123, 20)
      Me.textBoxServerPort.TabIndex = 25
      '
      'textBoxServerIpAddress
      '
      Me.textBoxServerIpAddress.Location = New System.Drawing.Point(111, 47)
      Me.textBoxServerIpAddress.Name = "textBoxServerIpAddress"
      Me.textBoxServerIpAddress.ReadOnly = True
      Me.textBoxServerIpAddress.Size = New System.Drawing.Size(123, 20)
      Me.textBoxServerIpAddress.TabIndex = 23
      '
      'labelEventDateTime
      '
      Me.labelEventDateTime.AutoSize = True
      Me.labelEventDateTime.Location = New System.Drawing.Point(267, 119)
      Me.labelEventDateTime.Name = "labelEventDateTime"
      Me.labelEventDateTime.Size = New System.Drawing.Size(92, 13)
      Me.labelEventDateTime.TabIndex = 34
      Me.labelEventDateTime.Text = "Event Date/Time:"
      '
      'labelClientPort
      '
      Me.labelClientPort.AutoSize = True
      Me.labelClientPort.Location = New System.Drawing.Point(267, 85)
      Me.labelClientPort.Name = "labelClientPort"
      Me.labelClientPort.Size = New System.Drawing.Size(58, 13)
      Me.labelClientPort.TabIndex = 32
      Me.labelClientPort.Text = "Client Port:"
      '
      'labelClientHostAddress
      '
      Me.labelClientHostAddress.AutoSize = True
      Me.labelClientHostAddress.Location = New System.Drawing.Point(267, 51)
      Me.labelClientHostAddress.Name = "labelClientHostAddress"
      Me.labelClientHostAddress.Size = New System.Drawing.Size(102, 13)
      Me.labelClientHostAddress.TabIndex = 30
      Me.labelClientHostAddress.Text = "Client Host Address:"
      '
      'labelClientAeTitle
      '
      Me.labelClientAeTitle.AutoSize = True
      Me.labelClientAeTitle.Location = New System.Drawing.Point(267, 17)
      Me.labelClientAeTitle.Name = "labelClientAeTitle"
      Me.labelClientAeTitle.Size = New System.Drawing.Size(76, 13)
      Me.labelClientAeTitle.TabIndex = 28
      Me.labelClientAeTitle.Text = "Client AE Title:"
      '
      'labelDescription
      '
      Me.labelDescription.AutoSize = True
      Me.labelDescription.Location = New System.Drawing.Point(15, 153)
      Me.labelDescription.Name = "labelDescription"
      Me.labelDescription.Size = New System.Drawing.Size(63, 13)
      Me.labelDescription.TabIndex = 36
      Me.labelDescription.Text = "Description:"
      '
      'labelCommand
      '
      Me.labelCommand.AutoSize = True
      Me.labelCommand.Location = New System.Drawing.Point(15, 119)
      Me.labelCommand.Name = "labelCommand"
      Me.labelCommand.Size = New System.Drawing.Size(57, 13)
      Me.labelCommand.TabIndex = 26
      Me.labelCommand.Text = "Command:"
      '
      'labelServerPort
      '
      Me.labelServerPort.AutoSize = True
      Me.labelServerPort.Location = New System.Drawing.Point(15, 85)
      Me.labelServerPort.Name = "labelServerPort"
      Me.labelServerPort.Size = New System.Drawing.Size(63, 13)
      Me.labelServerPort.TabIndex = 24
      Me.labelServerPort.Text = "Server Port:"
      '
      'labelServerIpAddress
      '
      Me.labelServerIpAddress.AutoSize = True
      Me.labelServerIpAddress.Location = New System.Drawing.Point(15, 51)
      Me.labelServerIpAddress.Name = "labelServerIpAddress"
      Me.labelServerIpAddress.Size = New System.Drawing.Size(95, 13)
      Me.labelServerIpAddress.TabIndex = 22
      Me.labelServerIpAddress.Text = "Server IP Address:"
      '
      'labelServerAeTitle
      '
      Me.labelServerAeTitle.AutoSize = True
      Me.labelServerAeTitle.Location = New System.Drawing.Point(15, 17)
      Me.labelServerAeTitle.Name = "labelServerAeTitle"
      Me.labelServerAeTitle.Size = New System.Drawing.Size(81, 13)
      Me.labelServerAeTitle.TabIndex = 20
      Me.labelServerAeTitle.Text = "Server AE Title:"
      '
      'textBoxServerAeTitle
      '
      Me.textBoxServerAeTitle.Location = New System.Drawing.Point(111, 13)
      Me.textBoxServerAeTitle.Name = "textBoxServerAeTitle"
      Me.textBoxServerAeTitle.ReadOnly = True
      Me.textBoxServerAeTitle.Size = New System.Drawing.Size(123, 20)
      Me.textBoxServerAeTitle.TabIndex = 21
      '
      'EventLogDetailDialog
      '
      Me.AcceptButton = Me.buttonClose
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.CancelButton = Me.buttonClose
      Me.ClientSize = New System.Drawing.Size(510, 463)
      Me.Controls.Add(Me.buttonClose)
      Me.Controls.Add(Me.buttonViewDataset)
      Me.Controls.Add(Me.textBoxEventDateTime)
      Me.Controls.Add(Me.textBoxClientPort)
      Me.Controls.Add(Me.textBoxClientHostAddress)
      Me.Controls.Add(Me.textBoxClientAeTitle)
      Me.Controls.Add(Me.textBoxDescription)
      Me.Controls.Add(Me.textBoxCommand)
      Me.Controls.Add(Me.textBoxServerPort)
      Me.Controls.Add(Me.textBoxServerIpAddress)
      Me.Controls.Add(Me.labelEventDateTime)
      Me.Controls.Add(Me.labelClientPort)
      Me.Controls.Add(Me.labelClientHostAddress)
      Me.Controls.Add(Me.labelClientAeTitle)
      Me.Controls.Add(Me.labelDescription)
      Me.Controls.Add(Me.labelCommand)
      Me.Controls.Add(Me.labelServerPort)
      Me.Controls.Add(Me.labelServerIpAddress)
      Me.Controls.Add(Me.labelServerAeTitle)
      Me.Controls.Add(Me.textBoxServerAeTitle)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.Name = "EventLogDetailDialog"
      Me.ShowIcon = False
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
      Me.Text = "Event Log Details"
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Private WithEvents buttonClose As System.Windows.Forms.Button
   Private WithEvents buttonViewDataset As System.Windows.Forms.Button
   Private WithEvents textBoxEventDateTime As System.Windows.Forms.TextBox
   Private WithEvents textBoxClientPort As System.Windows.Forms.TextBox
   Private WithEvents textBoxClientHostAddress As System.Windows.Forms.TextBox
   Private WithEvents textBoxClientAeTitle As System.Windows.Forms.TextBox
   Private WithEvents textBoxDescription As System.Windows.Forms.TextBox
   Private WithEvents textBoxCommand As System.Windows.Forms.TextBox
   Private WithEvents textBoxServerPort As System.Windows.Forms.TextBox
   Private WithEvents textBoxServerIpAddress As System.Windows.Forms.TextBox
   Private WithEvents labelEventDateTime As System.Windows.Forms.Label
   Private WithEvents labelClientPort As System.Windows.Forms.Label
   Private WithEvents labelClientHostAddress As System.Windows.Forms.Label
   Private WithEvents labelClientAeTitle As System.Windows.Forms.Label
   Private WithEvents labelDescription As System.Windows.Forms.Label
   Private WithEvents labelCommand As System.Windows.Forms.Label
   Private WithEvents labelServerPort As System.Windows.Forms.Label
   Private WithEvents labelServerIpAddress As System.Windows.Forms.Label
   Private WithEvents labelServerAeTitle As System.Windows.Forms.Label
   Private WithEvents textBoxServerAeTitle As System.Windows.Forms.TextBox

End Class
