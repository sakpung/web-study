
Partial Class TissueEqualizeDialog
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
      Me._gbTissueEqualize = New System.Windows.Forms.GroupBox()
      Me._lblFlags = New System.Windows.Forms.Label()
      Me._btnCancel = New System.Windows.Forms.Button()
      Me._btnOk = New System.Windows.Forms.Button()
      Me._rbUseIntensifyOption = New System.Windows.Forms.RadioButton()
      Me._rbUseSimplifyOption = New System.Windows.Forms.RadioButton()
      Me._gbTissueEqualize.SuspendLayout()
      Me.SuspendLayout()
      ' 
      ' _gbTissueEqualize
      ' 
      Me._gbTissueEqualize.Controls.Add(Me._rbUseSimplifyOption)
      Me._gbTissueEqualize.Controls.Add(Me._rbUseIntensifyOption)
      Me._gbTissueEqualize.Controls.Add(Me._lblFlags)
      Me._gbTissueEqualize.Location = New System.Drawing.Point(7, 6)
      Me._gbTissueEqualize.Name = "_gbTissueEqualize"
      Me._gbTissueEqualize.Size = New System.Drawing.Size(196, 65)
      Me._gbTissueEqualize.TabIndex = 0
      Me._gbTissueEqualize.TabStop = False
      ' 
      ' _lblFlags
      ' 
      Me._lblFlags.AutoSize = True
      Me._lblFlags.Location = New System.Drawing.Point(14, 32)
      Me._lblFlags.Name = "_lblFlags"
      Me._lblFlags.Size = New System.Drawing.Size(38, 13)
      Me._lblFlags.TabIndex = 2
      Me._lblFlags.Text = "Flags :"
      ' 
      ' _btnCancel
      ' 
      Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._btnCancel.Location = New System.Drawing.Point(114, 76)
      Me._btnCancel.Margin = New System.Windows.Forms.Padding(2)
      Me._btnCancel.Name = "_btnCancel"
      Me._btnCancel.Size = New System.Drawing.Size(68, 22)
      Me._btnCancel.TabIndex = 15
      Me._btnCancel.Text = "Cancel"
      Me._btnCancel.UseVisualStyleBackColor = True
      ' 
      ' _btnOk
      ' 
      Me._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK
      Me._btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._btnOk.Location = New System.Drawing.Point(29, 76)
      Me._btnOk.Margin = New System.Windows.Forms.Padding(2)
      Me._btnOk.Name = "_btnOk"
      Me._btnOk.Size = New System.Drawing.Size(68, 22)
      Me._btnOk.TabIndex = 14
      Me._btnOk.Text = "OK"
      Me._btnOk.UseVisualStyleBackColor = True
      ' 
      ' _rbUseIntensifyOption
      ' 
      Me._rbUseIntensifyOption.AutoSize = True
      Me._rbUseIntensifyOption.Location = New System.Drawing.Point(70, 19)
      Me._rbUseIntensifyOption.Name = "_rbUseIntensifyOption"
      Me._rbUseIntensifyOption.Size = New System.Drawing.Size(120, 17)
      Me._rbUseIntensifyOption.TabIndex = 3
      Me._rbUseIntensifyOption.TabStop = True
      Me._rbUseIntensifyOption.Text = "Use Intensify Option"
      Me._rbUseIntensifyOption.UseVisualStyleBackColor = True
      ' 
      ' _rbUseSimplifyOption
      ' 
      Me._rbUseSimplifyOption.AutoSize = True
      Me._rbUseSimplifyOption.Location = New System.Drawing.Point(70, 42)
      Me._rbUseSimplifyOption.Name = "_rbUseSimplifyOption"
      Me._rbUseSimplifyOption.Size = New System.Drawing.Size(116, 17)
      Me._rbUseSimplifyOption.TabIndex = 4
      Me._rbUseSimplifyOption.TabStop = True
      Me._rbUseSimplifyOption.Text = "Use Simplify Option"
      Me._rbUseSimplifyOption.UseVisualStyleBackColor = True
      ' 
      ' TissueEqualizeDialog
      ' 
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(211, 108)
      Me.Controls.Add(Me._btnCancel)
      Me.Controls.Add(Me._btnOk)
      Me.Controls.Add(Me._gbTissueEqualize)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "TissueEqualizeDialog"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
      Me.Text = "TissueEqualize"
      Me._gbTissueEqualize.ResumeLayout(False)
      Me._gbTissueEqualize.PerformLayout()
      Me.ResumeLayout(False)

   End Sub

#End Region

   Private _gbTissueEqualize As System.Windows.Forms.GroupBox
   Private _lblFlags As System.Windows.Forms.Label
   Private _btnCancel As System.Windows.Forms.Button
   Private WithEvents _btnOk As System.Windows.Forms.Button
   Private _rbUseSimplifyOption As System.Windows.Forms.RadioButton
   Private _rbUseIntensifyOption As System.Windows.Forms.RadioButton
End Class