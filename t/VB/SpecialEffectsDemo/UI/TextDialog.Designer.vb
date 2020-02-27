Imports Microsoft.VisualBasic
Namespace SpecialEffectsDemo
   Partial Class TextDialog
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
         Me._lblTextStyle = New System.Windows.Forms.Label()
         Me._tbText = New System.Windows.Forms.TextBox()
         Me._lblText = New System.Windows.Forms.Label()
         Me._cmbTextStyle = New System.Windows.Forms.ComboBox()
         Me._gbOptions = New System.Windows.Forms.GroupBox()
         Me._btnBorderColor = New System.Windows.Forms.Button()
         Me._lblBorderColor = New System.Windows.Forms.Label()
         Me._btnTextColor = New System.Windows.Forms.Button()
         Me._lblTextColor = New System.Windows.Forms.Label()
         Me._btnCancel = New System.Windows.Forms.Button()
         Me._btnOK = New System.Windows.Forms.Button()
         Me._gbOptions.SuspendLayout()
         Me.SuspendLayout()
         ' 
         ' _lblTextStyle
         ' 
         Me._lblTextStyle.AutoSize = True
         Me._lblTextStyle.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._lblTextStyle.Location = New System.Drawing.Point(8, 56)
         Me._lblTextStyle.Name = "_lblTextStyle"
         Me._lblTextStyle.Size = New System.Drawing.Size(60, 13)
         Me._lblTextStyle.TabIndex = 2
         Me._lblTextStyle.Text = "Text Style :"
         ' 
         ' _tbText
         ' 
         Me._tbText.Location = New System.Drawing.Point(72, 18)
         Me._tbText.Name = "_tbText"
         Me._tbText.Size = New System.Drawing.Size(237, 20)
         Me._tbText.TabIndex = 1
         Me._tbText.Text = "LEADTOOLS"
         ' 
         ' _lblText
         ' 
         Me._lblText.AutoSize = True
         Me._lblText.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._lblText.Location = New System.Drawing.Point(8, 25)
         Me._lblText.Name = "_lblText"
         Me._lblText.Size = New System.Drawing.Size(34, 13)
         Me._lblText.TabIndex = 0
         Me._lblText.Text = "Text :"
         ' 
         ' _cmbTextStyle
         ' 
         Me._cmbTextStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
         Me._cmbTextStyle.FormattingEnabled = True
         Me._cmbTextStyle.Location = New System.Drawing.Point(72, 51)
         Me._cmbTextStyle.Name = "_cmbTextStyle"
         Me._cmbTextStyle.Size = New System.Drawing.Size(238, 21)
         Me._cmbTextStyle.TabIndex = 3
         ' 
         ' _gbOptions
         ' 
         Me._gbOptions.Controls.Add(Me._btnBorderColor)
         Me._gbOptions.Controls.Add(Me._lblBorderColor)
         Me._gbOptions.Controls.Add(Me._btnTextColor)
         Me._gbOptions.Controls.Add(Me._lblTextColor)
         Me._gbOptions.Controls.Add(Me._lblTextStyle)
         Me._gbOptions.Controls.Add(Me._tbText)
         Me._gbOptions.Controls.Add(Me._lblText)
         Me._gbOptions.Controls.Add(Me._cmbTextStyle)
         Me._gbOptions.Location = New System.Drawing.Point(5, 2)
         Me._gbOptions.Name = "_gbOptions"
         Me._gbOptions.Size = New System.Drawing.Size(319, 161)
         Me._gbOptions.TabIndex = 0
         Me._gbOptions.TabStop = False
         ' 
         ' _btnBorderColor
         ' 
         Me._btnBorderColor.ForeColor = System.Drawing.SystemColors.ControlText
         Me._btnBorderColor.Location = New System.Drawing.Point(72, 120)
         Me._btnBorderColor.Name = "_btnBorderColor"
         Me._btnBorderColor.Size = New System.Drawing.Size(75, 23)
         Me._btnBorderColor.TabIndex = 7
         Me._btnBorderColor.Text = Constants.vbCrLf
         Me._btnBorderColor.UseVisualStyleBackColor = False
         ' 
         ' _lblBorderColor
         ' 
         Me._lblBorderColor.AutoSize = True
         Me._lblBorderColor.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._lblBorderColor.Location = New System.Drawing.Point(8, 125)
         Me._lblBorderColor.Name = "_lblBorderColor"
         Me._lblBorderColor.Size = New System.Drawing.Size(71, 13)
         Me._lblBorderColor.TabIndex = 6
         Me._lblBorderColor.Text = "Border Color :"
         ' 
         ' _btnTextColor
         ' 
         Me._btnTextColor.ForeColor = System.Drawing.Color.Black
         Me._btnTextColor.Location = New System.Drawing.Point(72, 87)
         Me._btnTextColor.Name = "_btnTextColor"
         Me._btnTextColor.Size = New System.Drawing.Size(75, 23)
         Me._btnTextColor.TabIndex = 5
         Me._btnTextColor.UseVisualStyleBackColor = False
         ' 
         ' _lblTextColor
         ' 
         Me._lblTextColor.AutoSize = True
         Me._lblTextColor.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._lblTextColor.Location = New System.Drawing.Point(8, 92)
         Me._lblTextColor.Name = "_lblTextColor"
         Me._lblTextColor.Size = New System.Drawing.Size(58, 13)
         Me._lblTextColor.TabIndex = 4
         Me._lblTextColor.Text = "Text Color:"
         ' 
         ' _btnCancel
         ' 
         Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
         Me._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._btnCancel.Location = New System.Drawing.Point(168, 171)
         Me._btnCancel.Name = "_btnCancel"
         Me._btnCancel.Size = New System.Drawing.Size(75, 23)
         Me._btnCancel.TabIndex = 2
         Me._btnCancel.Text = "Cancel"
         Me._btnCancel.UseVisualStyleBackColor = True
         ' 
         ' _btnOK
         ' 
         Me._btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
         Me._btnOK.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._btnOK.Location = New System.Drawing.Point(87, 171)
         Me._btnOK.Name = "_btnOK"
         Me._btnOK.Size = New System.Drawing.Size(75, 23)
         Me._btnOK.TabIndex = 1
         Me._btnOK.Text = "OK" & Constants.vbCrLf
         Me._btnOK.UseVisualStyleBackColor = True
         ' 
         ' TextDialog
         ' 
         Me.AcceptButton = Me._btnOK
         Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.CancelButton = Me._btnCancel
         Me.ClientSize = New System.Drawing.Size(330, 202)
         Me.Controls.Add(Me._gbOptions)
         Me.Controls.Add(Me._btnCancel)
         Me.Controls.Add(Me._btnOK)
         Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
         Me.MaximizeBox = False
         Me.MinimizeBox = False
         Me.Name = "TextDialog"
         Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
         Me.Text = "Text Dialog"
         Me._gbOptions.ResumeLayout(False)
         Me._gbOptions.PerformLayout()
         Me.ResumeLayout(False)

      End Sub

#End Region

      Private _lblTextStyle As System.Windows.Forms.Label
      Private _tbText As System.Windows.Forms.TextBox
      Private _lblText As System.Windows.Forms.Label
      Private _cmbTextStyle As System.Windows.Forms.ComboBox
      Private _gbOptions As System.Windows.Forms.GroupBox
      Private _btnCancel As System.Windows.Forms.Button
      Private WithEvents _btnOK As System.Windows.Forms.Button
      Private WithEvents _btnBorderColor As System.Windows.Forms.Button
      Private _lblBorderColor As System.Windows.Forms.Label
      Private WithEvents _btnTextColor As System.Windows.Forms.Button
      Private _lblTextColor As System.Windows.Forms.Label
   End Class
End Namespace
