Imports Microsoft.VisualBasic
Imports System
Namespace MainDemo
   Public Partial Class GrayScaleDialog
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
		 Me._rb8 = New System.Windows.Forms.RadioButton()
		 Me._rb12 = New System.Windows.Forms.RadioButton()
		 Me._gbOptions = New System.Windows.Forms.GroupBox()
		 Me._rb16 = New System.Windows.Forms.RadioButton()
		 Me._btnCancel = New System.Windows.Forms.Button()
		 Me._btnOk = New System.Windows.Forms.Button()
		 Me._gbOptions.SuspendLayout()
		 Me.SuspendLayout()
		 ' 
		 ' _rb8
		 ' 
		 Me._rb8.FlatStyle = System.Windows.Forms.FlatStyle.System
		 Me._rb8.Location = New System.Drawing.Point(19, 28)
		 Me._rb8.Name = "_rb8"
		 Me._rb8.Size = New System.Drawing.Size(192, 27)
		 Me._rb8.TabIndex = 0
		 Me._rb8.TabStop = True
		 Me._rb8.Text = "Gray Scale 8 Bits/Pixel"
		 Me._rb8.UseVisualStyleBackColor = True
		 ' 
		 ' _rb12
		 ' 
		 Me._rb12.FlatStyle = System.Windows.Forms.FlatStyle.System
		 Me._rb12.Location = New System.Drawing.Point(19, 65)
		 Me._rb12.Name = "_rb12"
		 Me._rb12.Size = New System.Drawing.Size(192, 27)
		 Me._rb12.TabIndex = 1
		 Me._rb12.TabStop = True
		 Me._rb12.Text = "Gray Scale 12 Bits/Pixel"
		 Me._rb12.UseVisualStyleBackColor = True
		 ' 
		 ' _gbOptions
		 ' 
		 Me._gbOptions.Controls.Add(Me._rb16)
		 Me._gbOptions.Controls.Add(Me._rb12)
		 Me._gbOptions.Controls.Add(Me._rb8)
		 Me._gbOptions.FlatStyle = System.Windows.Forms.FlatStyle.System
		 Me._gbOptions.Location = New System.Drawing.Point(10, 9)
		 Me._gbOptions.Name = "_gbOptions"
		 Me._gbOptions.Size = New System.Drawing.Size(249, 148)
		 Me._gbOptions.TabIndex = 0
		 Me._gbOptions.TabStop = False
		 ' 
		 ' _rb16
		 ' 
		 Me._rb16.FlatStyle = System.Windows.Forms.FlatStyle.System
		 Me._rb16.Location = New System.Drawing.Point(19, 102)
		 Me._rb16.Name = "_rb16"
		 Me._rb16.Size = New System.Drawing.Size(192, 27)
		 Me._rb16.TabIndex = 2
		 Me._rb16.TabStop = True
		 Me._rb16.Text = "Gray Scale 16 Bits/Pixel"
		 Me._rb16.UseVisualStyleBackColor = True
		 ' 
		 ' _btnCancel
		 ' 
		 Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
		 Me._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
		 Me._btnCancel.Location = New System.Drawing.Point(282, 55)
		 Me._btnCancel.Name = "_btnCancel"
		 Me._btnCancel.Size = New System.Drawing.Size(90, 27)
		 Me._btnCancel.TabIndex = 2
		 Me._btnCancel.Text = "Cancel"
		 Me._btnCancel.UseVisualStyleBackColor = True
		 ' 
		 ' _btnOk
		 ' 
		 Me._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK
		 Me._btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System
		 Me._btnOk.Location = New System.Drawing.Point(282, 18)
		 Me._btnOk.Name = "_btnOk"
		 Me._btnOk.Size = New System.Drawing.Size(90, 27)
		 Me._btnOk.TabIndex = 1
		 Me._btnOk.Text = "OK"
		 Me._btnOk.UseVisualStyleBackColor = True
'		 Me._btnOk.Click += New System.EventHandler(Me._btnOk_Click);
		 ' 
		 ' GrayScaleDialog
		 ' 
		 Me.AcceptButton = Me._btnOk
		 Me.AutoScaleDimensions = New System.Drawing.SizeF(8F, 16F)
		 Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		 Me.CancelButton = Me._btnCancel
		 Me.ClientSize = New System.Drawing.Size(386, 175)
		 Me.Controls.Add(Me._gbOptions)
		 Me.Controls.Add(Me._btnCancel)
		 Me.Controls.Add(Me._btnOk)
		 Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		 Me.MaximizeBox = False
		 Me.MinimizeBox = False
		 Me.Name = "GrayScaleDialog"
		 Me.ShowInTaskbar = False
		 Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
		 Me.Text = "Gray Scale"
'		 Me.Load += New System.EventHandler(Me.GrayScaleDialog_Load);
		 Me._gbOptions.ResumeLayout(False)
		 Me.ResumeLayout(False)

	  End Sub

	  #End Region

	  Private _rb8 As System.Windows.Forms.RadioButton
	  Private _rb12 As System.Windows.Forms.RadioButton
	  Private _gbOptions As System.Windows.Forms.GroupBox
	  Private _btnCancel As System.Windows.Forms.Button
	  Private WithEvents _btnOk As System.Windows.Forms.Button
	  Private _rb16 As System.Windows.Forms.RadioButton
   End Class
End Namespace