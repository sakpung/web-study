Partial Class BarcodeFieldDialog
   Private components As System.ComponentModel.IContainer = Nothing

   Protected Overrides Sub Dispose(ByVal disposing As Boolean)
      If disposing AndAlso (components IsNot Nothing) Then
         components.Dispose()
      End If

      MyBase.Dispose(disposing)
   End Sub

   Private Sub InitializeComponent()
      Me.btnOK = New System.Windows.Forms.Button()
      Me.btnCancel = New System.Windows.Forms.Button()
      Me.txtName = New System.Windows.Forms.TextBox()
      Me.lblName = New System.Windows.Forms.Label()
      Me.lblSymbology = New System.Windows.Forms.Label()
      Me.cboxSymbology = New System.Windows.Forms.ComboBox()
      Me.btnAutoDetect = New System.Windows.Forms.Button()
      Me.SuspendLayout()
      Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
      Me.btnOK.Location = New System.Drawing.Point(168, 91)
      Me.btnOK.Name = "btnOK"
      Me.btnOK.Size = New System.Drawing.Size(75, 23)
      Me.btnOK.TabIndex = 0
      Me.btnOK.Text = "OK"
      Me.btnOK.UseVisualStyleBackColor = True
      Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.btnCancel.Location = New System.Drawing.Point(249, 91)
      Me.btnCancel.Name = "btnCancel"
      Me.btnCancel.Size = New System.Drawing.Size(75, 23)
      Me.btnCancel.TabIndex = 1
      Me.btnCancel.Text = "Cancel"
      Me.btnCancel.UseVisualStyleBackColor = True
      Me.txtName.Location = New System.Drawing.Point(73, 12)
      Me.txtName.Name = "txtName"
      Me.txtName.Size = New System.Drawing.Size(251, 20)
      Me.txtName.TabIndex = 5
      Me.lblName.AutoSize = True
      Me.lblName.Location = New System.Drawing.Point(3, 15)
      Me.lblName.Name = "lblName"
      Me.lblName.Size = New System.Drawing.Size(38, 13)
      Me.lblName.TabIndex = 4
      Me.lblName.Text = "Name:"
      Me.lblSymbology.AutoSize = True
      Me.lblSymbology.Location = New System.Drawing.Point(6, 44)
      Me.lblSymbology.Name = "lblSymbology"
      Me.lblSymbology.Size = New System.Drawing.Size(61, 13)
      Me.lblSymbology.TabIndex = 6
      Me.lblSymbology.Text = "Symbology:"
      Me.cboxSymbology.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cboxSymbology.FormattingEnabled = True
      Me.cboxSymbology.Location = New System.Drawing.Point(73, 41)
      Me.cboxSymbology.Name = "cboxSymbology"
      Me.cboxSymbology.Size = New System.Drawing.Size(170, 21)
      Me.cboxSymbology.TabIndex = 7
      Me.btnAutoDetect.Location = New System.Drawing.Point(249, 41)
      Me.btnAutoDetect.Name = "btnAutoDetect"
      Me.btnAutoDetect.Size = New System.Drawing.Size(75, 23)
      Me.btnAutoDetect.TabIndex = 8
      Me.btnAutoDetect.Text = "Auto Detect"
      Me.btnAutoDetect.UseVisualStyleBackColor = True
      AddHandler Me.btnAutoDetect.Click, AddressOf Me.btnAutoDetect_Click
      Me.AcceptButton = Me.btnOK
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.CancelButton = Me.btnCancel
      Me.ClientSize = New System.Drawing.Size(336, 126)
      Me.Controls.Add(Me.btnAutoDetect)
      Me.Controls.Add(Me.cboxSymbology)
      Me.Controls.Add(Me.lblSymbology)
      Me.Controls.Add(Me.txtName)
      Me.Controls.Add(Me.lblName)
      Me.Controls.Add(Me.btnCancel)
      Me.Controls.Add(Me.btnOK)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "BarcodeFieldDialog"
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
      Me.Text = "Barcode"
      AddHandler Me.FormClosing, AddressOf Me.BarcodeFieldDialog_FormClosing
      Me.ResumeLayout(False)
      Me.PerformLayout()
   End Sub

   Private btnOK As System.Windows.Forms.Button
   Private btnCancel As System.Windows.Forms.Button
   Private txtName As System.Windows.Forms.TextBox
   Private lblName As System.Windows.Forms.Label
   Private lblSymbology As System.Windows.Forms.Label
   Private cboxSymbology As System.Windows.Forms.ComboBox
   Private btnAutoDetect As System.Windows.Forms.Button
End Class
