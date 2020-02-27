
Partial Class CopyImageDialog
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
      Me._btnCancel = New System.Windows.Forms.Button()
      Me._btnOk = New System.Windows.Forms.Button()
      Me._gbDigitalSubtract = New System.Windows.Forms.GroupBox()
      Me._cmbDestImage = New System.Windows.Forms.ComboBox()
      Me._lblMaskImage = New System.Windows.Forms.Label()
      Me._gbDigitalSubtract.SuspendLayout()
      Me.SuspendLayout()
      ' 
      ' _btnCancel
      ' 
      Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._btnCancel.Location = New System.Drawing.Point(765, 67)
      Me._btnCancel.Margin = New System.Windows.Forms.Padding(2)
      Me._btnCancel.Name = "_btnCancel"
      Me._btnCancel.Size = New System.Drawing.Size(68, 22)
      Me._btnCancel.TabIndex = 17
      Me._btnCancel.Text = "Cancel"
      Me._btnCancel.UseVisualStyleBackColor = True
      ' 
      ' _btnOk
      ' 
      Me._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK
      Me._btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._btnOk.Location = New System.Drawing.Point(693, 67)
      Me._btnOk.Margin = New System.Windows.Forms.Padding(2)
      Me._btnOk.Name = "_btnOk"
      Me._btnOk.Size = New System.Drawing.Size(68, 22)
      Me._btnOk.TabIndex = 16
      Me._btnOk.Text = "OK"
      Me._btnOk.UseVisualStyleBackColor = True
      ' 
      ' _gbDigitalSubtract
      ' 
      Me._gbDigitalSubtract.Controls.Add(Me._cmbDestImage)
      Me._gbDigitalSubtract.Controls.Add(Me._lblMaskImage)
      Me._gbDigitalSubtract.Location = New System.Drawing.Point(6, 4)
      Me._gbDigitalSubtract.Name = "_gbDigitalSubtract"
      Me._gbDigitalSubtract.Size = New System.Drawing.Size(833, 51)
      Me._gbDigitalSubtract.TabIndex = 15
      Me._gbDigitalSubtract.TabStop = False
      ' 
      ' _cmbDestImage
      ' 
      Me._cmbDestImage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me._cmbDestImage.FormattingEnabled = True
      Me._cmbDestImage.Location = New System.Drawing.Point(107, 19)
      Me._cmbDestImage.Name = "_cmbDestImage"
      Me._cmbDestImage.Size = New System.Drawing.Size(720, 21)
      Me._cmbDestImage.TabIndex = 4
      ' 
      ' _lblMaskImage
      ' 
      Me._lblMaskImage.AutoSize = True
      Me._lblMaskImage.Location = New System.Drawing.Point(6, 22)
      Me._lblMaskImage.Name = "_lblMaskImage"
      Me._lblMaskImage.Size = New System.Drawing.Size(95, 13)
      Me._lblMaskImage.TabIndex = 3
      Me._lblMaskImage.Text = "Destination Image:"
      ' 
      ' CopyImageDialog
      ' 
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(851, 100)
      Me.Controls.Add(Me._btnCancel)
      Me.Controls.Add(Me._btnOk)
      Me.Controls.Add(Me._gbDigitalSubtract)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "CopyImageDialog"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
      Me.Text = "Copy Image"
      Me._gbDigitalSubtract.ResumeLayout(False)
      Me._gbDigitalSubtract.PerformLayout()
      Me.ResumeLayout(False)

   End Sub

#End Region

   Private _btnCancel As System.Windows.Forms.Button
   Private WithEvents _btnOk As System.Windows.Forms.Button
   Private _gbDigitalSubtract As System.Windows.Forms.GroupBox
   Private _cmbDestImage As System.Windows.Forms.ComboBox
   Private _lblMaskImage As System.Windows.Forms.Label
End Class