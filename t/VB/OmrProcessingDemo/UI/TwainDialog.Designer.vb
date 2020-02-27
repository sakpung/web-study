Partial Class TwainDialog
   Private components As System.ComponentModel.IContainer = Nothing

   Protected Overrides Sub Dispose(ByVal disposing As Boolean)
      If disposing AndAlso (components IsNot Nothing) Then
         components.Dispose()
      End If

      MyBase.Dispose(disposing)
   End Sub

   Private Sub InitializeComponent()
      Me.btnScan = New System.Windows.Forms.Button()
      Me.btnCancel = New System.Windows.Forms.Button()
      Me.btnSelectSource = New System.Windows.Forms.Button()
      Me.btnChooseSaveLocation = New System.Windows.Forms.Button()
      Me.txtSelectedSource = New System.Windows.Forms.TextBox()
      Me.txtSaveLocation = New System.Windows.Forms.TextBox()
      Me.SuspendLayout()
      Me.btnScan.Location = New System.Drawing.Point(221, 70)
      Me.btnScan.Name = "btnScan"
      Me.btnScan.Size = New System.Drawing.Size(75, 23)
      Me.btnScan.TabIndex = 1
      Me.btnScan.Text = "Scan"
      Me.btnScan.UseVisualStyleBackColor = True
      AddHandler Me.btnScan.Click, AddressOf Me.btnScan_Click
      Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.btnCancel.Location = New System.Drawing.Point(302, 70)
      Me.btnCancel.Name = "btnCancel"
      Me.btnCancel.Size = New System.Drawing.Size(75, 23)
      Me.btnCancel.TabIndex = 2
      Me.btnCancel.Text = "Cancel"
      Me.btnCancel.UseVisualStyleBackColor = True
      Me.btnSelectSource.Location = New System.Drawing.Point(12, 12)
      Me.btnSelectSource.Name = "btnSelectSource"
      Me.btnSelectSource.Size = New System.Drawing.Size(137, 23)
      Me.btnSelectSource.TabIndex = 3
      Me.btnSelectSource.Text = "Choose Scanner"
      Me.btnSelectSource.UseVisualStyleBackColor = True
      AddHandler Me.btnSelectSource.Click, AddressOf Me.btnSelectSource_Click
      Me.btnChooseSaveLocation.Location = New System.Drawing.Point(12, 41)
      Me.btnChooseSaveLocation.Name = "btnChooseSaveLocation"
      Me.btnChooseSaveLocation.Size = New System.Drawing.Size(137, 23)
      Me.btnChooseSaveLocation.TabIndex = 5
      Me.btnChooseSaveLocation.Text = "Choose Save Location"
      Me.btnChooseSaveLocation.UseVisualStyleBackColor = True
      AddHandler Me.btnChooseSaveLocation.Click, AddressOf Me.btnChooseSaveLocation_Click
      Me.txtSelectedSource.Enabled = False
      Me.txtSelectedSource.Location = New System.Drawing.Point(155, 15)
      Me.txtSelectedSource.Name = "txtSelectedSource"
      Me.txtSelectedSource.Size = New System.Drawing.Size(222, 20)
      Me.txtSelectedSource.TabIndex = 6
      Me.txtSaveLocation.Enabled = False
      Me.txtSaveLocation.Location = New System.Drawing.Point(155, 44)
      Me.txtSaveLocation.Name = "txtSaveLocation"
      Me.txtSaveLocation.Size = New System.Drawing.Size(222, 20)
      Me.txtSaveLocation.TabIndex = 7
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.CancelButton = Me.btnCancel
      Me.ClientSize = New System.Drawing.Size(388, 104)
      Me.Controls.Add(Me.txtSaveLocation)
      Me.Controls.Add(Me.txtSelectedSource)
      Me.Controls.Add(Me.btnChooseSaveLocation)
      Me.Controls.Add(Me.btnSelectSource)
      Me.Controls.Add(Me.btnCancel)
      Me.Controls.Add(Me.btnScan)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "TwainDialog"
      Me.ShowInTaskbar = False
      Me.Text = "Scanner Input"
      AddHandler Me.FormClosing, AddressOf Me.TwainDialog_FormClosing
      AddHandler Me.Load, AddressOf Me.TwainDialog_Load
      Me.ResumeLayout(False)
      Me.PerformLayout()
   End Sub

   Private btnScan As System.Windows.Forms.Button
   Private btnCancel As System.Windows.Forms.Button
   Private btnSelectSource As System.Windows.Forms.Button
   Private btnChooseSaveLocation As System.Windows.Forms.Button
   Private txtSelectedSource As System.Windows.Forms.TextBox
   Private txtSaveLocation As System.Windows.Forms.TextBox
End Class
