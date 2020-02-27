Partial Class FormSpecificDialog
   Private components As System.ComponentModel.IContainer = Nothing

   Protected Overrides Sub Dispose(ByVal disposing As Boolean)
      If disposing AndAlso (components IsNot Nothing) Then
         components.Dispose()
      End If

      MyBase.Dispose(disposing)
   End Sub

   Private Sub InitializeComponent()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormSpecificDialog))
      Me.btnOK = New System.Windows.Forms.Button()
      Me.btnCancel = New System.Windows.Forms.Button()
      Me.txtValue = New System.Windows.Forms.TextBox()
      Me.lblValue = New System.Windows.Forms.Label()
      Me.chkChooseIdentifier = New System.Windows.Forms.CheckedListBox()
      Me.lblIdentifierDefinition = New System.Windows.Forms.Label()
      Me.SuspendLayout()
      Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
      Me.btnOK.Location = New System.Drawing.Point(197, 192)
      Me.btnOK.Name = "btnOK"
      Me.btnOK.Size = New System.Drawing.Size(75, 23)
      Me.btnOK.TabIndex = 0
      Me.btnOK.Text = "&OK"
      Me.btnOK.UseVisualStyleBackColor = True
      Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.btnCancel.Location = New System.Drawing.Point(278, 192)
      Me.btnCancel.Name = "btnCancel"
      Me.btnCancel.Size = New System.Drawing.Size(75, 23)
      Me.btnCancel.TabIndex = 1
      Me.btnCancel.Text = "&Cancel"
      Me.btnCancel.UseVisualStyleBackColor = True
      Me.txtValue.Location = New System.Drawing.Point(102, 12)
      Me.txtValue.Name = "txtValue"
      Me.txtValue.Size = New System.Drawing.Size(251, 20)
      Me.txtValue.TabIndex = 3
      Me.lblValue.AutoSize = True
      Me.lblValue.Location = New System.Drawing.Point(11, 15)
      Me.lblValue.Name = "lblValue"
      Me.lblValue.Size = New System.Drawing.Size(85, 13)
      Me.lblValue.TabIndex = 2
      Me.lblValue.Text = "Template Name:"
      Me.chkChooseIdentifier.CheckOnClick = True
      Me.chkChooseIdentifier.FormattingEnabled = True
      Me.chkChooseIdentifier.Location = New System.Drawing.Point(14, 92)
      Me.chkChooseIdentifier.Name = "chkChooseIdentifier"
      Me.chkChooseIdentifier.Size = New System.Drawing.Size(339, 94)
      Me.chkChooseIdentifier.TabIndex = 4
      AddHandler Me.chkChooseIdentifier.ItemCheck, AddressOf Me.chkChooseIdentifier_ItemCheck
      Me.lblIdentifierDefinition.Location = New System.Drawing.Point(13, 41)
      Me.lblIdentifierDefinition.Name = "lblIdentifierDefinition"
      Me.lblIdentifierDefinition.Size = New System.Drawing.Size(341, 48)
      Me.lblIdentifierDefinition.TabIndex = 6
      Me.lblIdentifierDefinition.Text = resources.GetString("lblIdentifierDefinition.Text")
      Me.AcceptButton = Me.btnOK
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.CancelButton = Me.btnCancel
      Me.ClientSize = New System.Drawing.Size(366, 227)
      Me.Controls.Add(Me.lblIdentifierDefinition)
      Me.Controls.Add(Me.chkChooseIdentifier)
      Me.Controls.Add(Me.txtValue)
      Me.Controls.Add(Me.lblValue)
      Me.Controls.Add(Me.btnCancel)
      Me.Controls.Add(Me.btnOK)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "FormSpecificDialog"
      Me.Text = "Template"
      AddHandler Me.FormClosing, AddressOf Me.FormSpecificDialog_FormClosing
      Me.ResumeLayout(False)
      Me.PerformLayout()
   End Sub

   Private btnOK As System.Windows.Forms.Button
   Private btnCancel As System.Windows.Forms.Button
   Private txtValue As System.Windows.Forms.TextBox
   Private lblValue As System.Windows.Forms.Label
   Private chkChooseIdentifier As System.Windows.Forms.CheckedListBox
   Private lblIdentifierDefinition As System.Windows.Forms.Label
End Class
