Namespace OcrDemo
   Partial Class ZonePropertiesDialog
      ''' <summary>
      ''' Required designer variable.
      ''' </summary>
      Private components As System.ComponentModel.IContainer = Nothing

      ''' <summary>
      ''' Clean up any resources being used.
      ''' </summary>
      ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      Protected Overrides Sub Dispose(disposing As Boolean)
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
         Me._cancelButton = New System.Windows.Forms.Button()
         Me._zonesLabel = New System.Windows.Forms.Label()
         Me._okButton = New System.Windows.Forms.Button()
         Me._pnlContainer = New System.Windows.Forms.Panel()
         Me._btnClearZones = New System.Windows.Forms.Button()
         Me._btnAddZone = New System.Windows.Forms.Button()
         Me._btnDeleteZone = New System.Windows.Forms.Button()
         Me._btnInvertSelection = New System.Windows.Forms.Button()
         Me._lbZonesList = New System.Windows.Forms.ListBox()
         Me.SuspendLayout()
         '
         '_cancelButton
         '
         Me._cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
         Me._cancelButton.Location = New System.Drawing.Point(745, 272)
         Me._cancelButton.Name = "_cancelButton"
         Me._cancelButton.Size = New System.Drawing.Size(75, 23)
         Me._cancelButton.TabIndex = 10
         Me._cancelButton.Text = "Cancel"
         Me._cancelButton.UseVisualStyleBackColor = True
         '
         '_zonesLabel
         '
         Me._zonesLabel.AutoSize = True
         Me._zonesLabel.Location = New System.Drawing.Point(12, 9)
         Me._zonesLabel.Name = "_zonesLabel"
         Me._zonesLabel.Size = New System.Drawing.Size(40, 13)
         Me._zonesLabel.TabIndex = 0
         Me._zonesLabel.Text = "&Zones:"
         '
         '_okButton
         '
         Me._okButton.DialogResult = System.Windows.Forms.DialogResult.OK
         Me._okButton.Location = New System.Drawing.Point(664, 272)
         Me._okButton.Name = "_okButton"
         Me._okButton.Size = New System.Drawing.Size(75, 23)
         Me._okButton.TabIndex = 9
         Me._okButton.Text = "OK"
         Me._okButton.UseVisualStyleBackColor = True
         '
         '_pnlContainer
         '
         Me._pnlContainer.Location = New System.Drawing.Point(222, 12)
         Me._pnlContainer.Name = "_pnlContainer"
         Me._pnlContainer.Size = New System.Drawing.Size(600, 223)
         Me._pnlContainer.TabIndex = 8
         '
         '_btnClearZones
         '
         Me._btnClearZones.Location = New System.Drawing.Point(15, 268)
         Me._btnClearZones.Name = "_btnClearZones"
         Me._btnClearZones.Size = New System.Drawing.Size(96, 23)
         Me._btnClearZones.TabIndex = 6
         Me._btnClearZones.Text = "&Clear"
         Me._btnClearZones.UseVisualStyleBackColor = True
         '
         '_btnAddZone
         '
         Me._btnAddZone.Location = New System.Drawing.Point(15, 241)
         Me._btnAddZone.Name = "_btnAddZone"
         Me._btnAddZone.Size = New System.Drawing.Size(96, 23)
         Me._btnAddZone.TabIndex = 4
         Me._btnAddZone.Text = "&Add"
         Me._btnAddZone.UseVisualStyleBackColor = True
         '
         '_btnDeleteZone
         '
         Me._btnDeleteZone.Location = New System.Drawing.Point(117, 241)
         Me._btnDeleteZone.Name = "_btnDeleteZone"
         Me._btnDeleteZone.Size = New System.Drawing.Size(90, 23)
         Me._btnDeleteZone.TabIndex = 5
         Me._btnDeleteZone.Text = "&Delete"
         Me._btnDeleteZone.UseVisualStyleBackColor = True
         '
         '_btnInvertSelection
         '
         Me._btnInvertSelection.Location = New System.Drawing.Point(117, 268)
         Me._btnInvertSelection.Name = "_btnInvertSelection"
         Me._btnInvertSelection.Size = New System.Drawing.Size(90, 23)
         Me._btnInvertSelection.TabIndex = 16
         Me._btnInvertSelection.Text = "I&nvert selection"
         Me._btnInvertSelection.UseVisualStyleBackColor = True
         '
         '_lbZonesList
         '
         Me._lbZonesList.FormattingEnabled = True
         Me._lbZonesList.Location = New System.Drawing.Point(15, 25)
         Me._lbZonesList.Name = "_lbZonesList"
         Me._lbZonesList.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
         Me._lbZonesList.Size = New System.Drawing.Size(192, 212)
         Me._lbZonesList.TabIndex = 17
         '
         'ZonePropertiesDialog
         '
         Me.AcceptButton = Me._okButton
         Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.CancelButton = Me._cancelButton
         Me.ClientSize = New System.Drawing.Size(832, 303)
         Me.Controls.Add(Me._lbZonesList)
         Me.Controls.Add(Me._btnInvertSelection)
         Me.Controls.Add(Me._btnClearZones)
         Me.Controls.Add(Me._btnAddZone)
         Me.Controls.Add(Me._btnDeleteZone)
         Me.Controls.Add(Me._pnlContainer)
         Me.Controls.Add(Me._cancelButton)
         Me.Controls.Add(Me._zonesLabel)
         Me.Controls.Add(Me._okButton)
         Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
         Me.MaximizeBox = False
         Me.MinimizeBox = False
         Me.Name = "ZonePropertiesDialog"
         Me.ShowInTaskbar = False
         Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
         Me.Text = "Update Zones"
         Me.ResumeLayout(False)
         Me.PerformLayout()

      End Sub

#End Region

      Private _cancelButton As System.Windows.Forms.Button
      Private _zonesLabel As System.Windows.Forms.Label
      Private _okButton As System.Windows.Forms.Button
      Private _pnlContainer As System.Windows.Forms.Panel
      Private WithEvents _btnClearZones As System.Windows.Forms.Button
      Private WithEvents _btnAddZone As System.Windows.Forms.Button
      Private WithEvents _btnDeleteZone As System.Windows.Forms.Button
      Private WithEvents _btnInvertSelection As System.Windows.Forms.Button
      Friend WithEvents _lbZonesList As System.Windows.Forms.ListBox
   End Class
End Namespace