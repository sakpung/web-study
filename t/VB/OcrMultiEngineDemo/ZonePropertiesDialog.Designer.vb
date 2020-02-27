<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ZonePropertiesDialog
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
      Me._cancelButton = New System.Windows.Forms.Button()
      Me._zonesLabel = New System.Windows.Forms.Label()
      Me._okButton = New System.Windows.Forms.Button()
      Me._pnlContainer = New System.Windows.Forms.Panel()
      Me._tvZonesList = New System.Windows.Forms.TreeView()
      Me.groupBox1 = New System.Windows.Forms.GroupBox()
      Me._btnClearZones = New System.Windows.Forms.Button()
      Me._btnAddZone = New System.Windows.Forms.Button()
      Me._btnDeleteZone = New System.Windows.Forms.Button()
      Me._cellsGroupBox = New System.Windows.Forms.GroupBox()
      Me._btnClearCells = New System.Windows.Forms.Button()
      Me._btnDetectCells = New System.Windows.Forms.Button()
      Me.groupBox1.SuspendLayout()
      Me._cellsGroupBox.SuspendLayout()
      Me.SuspendLayout()
      ' 
      ' _cancelButton
      ' 
      Me._cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me._cancelButton.Location = New System.Drawing.Point(747, 358)
      Me._cancelButton.Name = "_cancelButton"
      Me._cancelButton.Size = New System.Drawing.Size(75, 23)
      Me._cancelButton.TabIndex = 10
      Me._cancelButton.Text = "Cancel"
      Me._cancelButton.UseVisualStyleBackColor = True
      ' 
      ' _zonesLabel
      ' 
      Me._zonesLabel.AutoSize = True
      Me._zonesLabel.Location = New System.Drawing.Point(12, 9)
      Me._zonesLabel.Name = "_zonesLabel"
      Me._zonesLabel.Size = New System.Drawing.Size(40, 13)
      Me._zonesLabel.TabIndex = 0
      Me._zonesLabel.Text = "&Zones:"
      ' 
      ' _okButton
      ' 
      Me._okButton.DialogResult = System.Windows.Forms.DialogResult.OK
      Me._okButton.Location = New System.Drawing.Point(666, 358)
      Me._okButton.Name = "_okButton"
      Me._okButton.Size = New System.Drawing.Size(75, 23)
      Me._okButton.TabIndex = 9
      Me._okButton.Text = "OK"
      Me._okButton.UseVisualStyleBackColor = True
      '         Me._okButton.Click += New System.EventHandler(Me._okButton_Click);
      ' 
      ' _pnlContainer
      ' 
      Me._pnlContainer.Location = New System.Drawing.Point(222, 12)
      Me._pnlContainer.Name = "_pnlContainer"
      Me._pnlContainer.Size = New System.Drawing.Size(600, 339)
      Me._pnlContainer.TabIndex = 8
      ' 
      ' _tvZonesList
      ' 
      Me._tvZonesList.FullRowSelect = True
      Me._tvZonesList.HideSelection = False
      Me._tvZonesList.Location = New System.Drawing.Point(15, 25)
      Me._tvZonesList.Name = "_tvZonesList"
      Me._tvZonesList.Size = New System.Drawing.Size(192, 210)
      Me._tvZonesList.TabIndex = 14
      '         Me._tvZonesList.AfterSelect += New System.Windows.Forms.TreeViewEventHandler(Me._tvZonesList_AfterSelect);
      ' 
      ' groupBox1
      ' 
      Me.groupBox1.Controls.Add(Me._btnClearZones)
      Me.groupBox1.Controls.Add(Me._btnAddZone)
      Me.groupBox1.Controls.Add(Me._btnDeleteZone)
      Me.groupBox1.Location = New System.Drawing.Point(15, 241)
      Me.groupBox1.Name = "groupBox1"
      Me.groupBox1.Size = New System.Drawing.Size(93, 110)
      Me.groupBox1.TabIndex = 16
      Me.groupBox1.TabStop = False
      Me.groupBox1.Text = "Zones"
      ' 
      ' _btnClearZones
      ' 
      Me._btnClearZones.Location = New System.Drawing.Point(6, 77)
      Me._btnClearZones.Name = "_btnClearZones"
      Me._btnClearZones.Size = New System.Drawing.Size(75, 23)
      Me._btnClearZones.TabIndex = 6
      Me._btnClearZones.Text = "&Clear"
      Me._btnClearZones.UseVisualStyleBackColor = True
      '         Me._btnClearZones.Click += New System.EventHandler(Me._btnClearZones_Click);
      ' 
      ' _btnAddZone
      ' 
      Me._btnAddZone.Location = New System.Drawing.Point(6, 19)
      Me._btnAddZone.Name = "_btnAddZone"
      Me._btnAddZone.Size = New System.Drawing.Size(75, 23)
      Me._btnAddZone.TabIndex = 4
      Me._btnAddZone.Text = "&Add"
      Me._btnAddZone.UseVisualStyleBackColor = True
      '         Me._btnAddZone.Click += New System.EventHandler(Me._btnAddZone_Click);
      ' 
      ' _btnDeleteZone
      ' 
      Me._btnDeleteZone.Location = New System.Drawing.Point(6, 48)
      Me._btnDeleteZone.Name = "_btnDeleteZone"
      Me._btnDeleteZone.Size = New System.Drawing.Size(75, 23)
      Me._btnDeleteZone.TabIndex = 5
      Me._btnDeleteZone.Text = "&Delete"
      Me._btnDeleteZone.UseVisualStyleBackColor = True
      '         Me._btnDeleteZone.Click += New System.EventHandler(Me._btnDeleteZone_Click);
      ' 
      ' _cellsGroupBox
      ' 
      Me._cellsGroupBox.Controls.Add(Me._btnClearCells)
      Me._cellsGroupBox.Controls.Add(Me._btnDetectCells)
      Me._cellsGroupBox.Location = New System.Drawing.Point(114, 241)
      Me._cellsGroupBox.Name = "_cellsGroupBox"
      Me._cellsGroupBox.Size = New System.Drawing.Size(93, 110)
      Me._cellsGroupBox.TabIndex = 17
      Me._cellsGroupBox.TabStop = False
      Me._cellsGroupBox.Text = "Cells"
      ' 
      ' _btnClearCells
      ' 
      Me._btnClearCells.Location = New System.Drawing.Point(6, 77)
      Me._btnClearCells.Name = "_btnClearCells"
      Me._btnClearCells.Size = New System.Drawing.Size(75, 23)
      Me._btnClearCells.TabIndex = 17
      Me._btnClearCells.Text = "Clea&r"
      Me._btnClearCells.UseVisualStyleBackColor = True
      '         Me._btnClearCells.Click += New System.EventHandler(Me._btnClearCells_Click);
      ' 
      ' _btnDetectCells
      ' 
      Me._btnDetectCells.Location = New System.Drawing.Point(6, 48)
      Me._btnDetectCells.Name = "_btnDetectCells"
      Me._btnDetectCells.Size = New System.Drawing.Size(75, 23)
      Me._btnDetectCells.TabIndex = 16
      Me._btnDetectCells.Text = "D&etect Cells"
      Me._btnDetectCells.UseVisualStyleBackColor = True
      '         Me._btnDetectCells.Click += New System.EventHandler(Me._btnDetectCells_Click);
      ' 
      ' ZonePropertiesDialog
      ' 
      Me.AcceptButton = Me._okButton
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.CancelButton = Me._cancelButton
      Me.ClientSize = New System.Drawing.Size(832, 392)
      Me.Controls.Add(Me._cellsGroupBox)
      Me.Controls.Add(Me.groupBox1)
      Me.Controls.Add(Me._tvZonesList)
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
      Me.groupBox1.ResumeLayout(False)
      Me._cellsGroupBox.ResumeLayout(False)
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub

   Private _cancelButton As System.Windows.Forms.Button
   Private _zonesLabel As System.Windows.Forms.Label
   Private WithEvents _okButton As System.Windows.Forms.Button
   Private _pnlContainer As System.Windows.Forms.Panel
   Private WithEvents _tvZonesList As System.Windows.Forms.TreeView
   Private groupBox1 As System.Windows.Forms.GroupBox
   Private WithEvents _btnClearZones As System.Windows.Forms.Button
   Private WithEvents _btnAddZone As System.Windows.Forms.Button
   Private WithEvents _btnDeleteZone As System.Windows.Forms.Button
   Private _cellsGroupBox As System.Windows.Forms.GroupBox
   Private WithEvents _btnClearCells As System.Windows.Forms.Button
   Private WithEvents _btnDetectCells As System.Windows.Forms.Button
End Class