Imports Microsoft.VisualBasic
Imports System
Namespace MainDemo
   Public Partial Class FlipDialog
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
		 Me._gbOptions = New System.Windows.Forms.GroupBox()
		 Me._rbVertical = New System.Windows.Forms.RadioButton()
		 Me._rbHorizontal = New System.Windows.Forms.RadioButton()
		 Me._btnCancel = New System.Windows.Forms.Button()
		 Me._btnOk = New System.Windows.Forms.Button()
		 Me._gbOptions.SuspendLayout()
		 Me.SuspendLayout()
		 ' 
		 ' _gbOptions
		 ' 
		 Me._gbOptions.Controls.Add(Me._rbVertical)
		 Me._gbOptions.Controls.Add(Me._rbHorizontal)
		 Me._gbOptions.FlatStyle = System.Windows.Forms.FlatStyle.System
		 Me._gbOptions.Location = New System.Drawing.Point(10, 6)
		 Me._gbOptions.Name = "_gbOptions"
		 Me._gbOptions.Size = New System.Drawing.Size(175, 102)
		 Me._gbOptions.TabIndex = 0
		 Me._gbOptions.TabStop = False
		 ' 
		 ' _rbVertical
		 ' 
		 Me._rbVertical.FlatStyle = System.Windows.Forms.FlatStyle.System
		 Me._rbVertical.Location = New System.Drawing.Point(17, 62)
		 Me._rbVertical.Name = "_rbVertical"
		 Me._rbVertical.Size = New System.Drawing.Size(138, 27)
		 Me._rbVertical.TabIndex = 1
		 Me._rbVertical.TabStop = True
		 Me._rbVertical.Text = "Flip Vertically"
		 Me._rbVertical.UseVisualStyleBackColor = True
		 ' 
		 ' _rbHorizontal
		 ' 
		 Me._rbHorizontal.FlatStyle = System.Windows.Forms.FlatStyle.System
		 Me._rbHorizontal.Location = New System.Drawing.Point(17, 25)
		 Me._rbHorizontal.Name = "_rbHorizontal"
		 Me._rbHorizontal.Size = New System.Drawing.Size(138, 27)
		 Me._rbHorizontal.TabIndex = 0
		 Me._rbHorizontal.TabStop = True
		 Me._rbHorizontal.Text = "Flip Horizontally"
		 Me._rbHorizontal.UseVisualStyleBackColor = True
		 ' 
		 ' _btnCancel
		 ' 
		 Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
		 Me._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
		 Me._btnCancel.Location = New System.Drawing.Point(204, 50)
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
		 Me._btnOk.Location = New System.Drawing.Point(204, 13)
		 Me._btnOk.Name = "_btnOk"
		 Me._btnOk.Size = New System.Drawing.Size(90, 27)
		 Me._btnOk.TabIndex = 1
		 Me._btnOk.Text = "OK"
		 Me._btnOk.UseVisualStyleBackColor = True
'		 Me._btnOk.Click += New System.EventHandler(Me._btnOk_Click);
		 ' 
		 ' FlipDialog
		 ' 
		 Me.AcceptButton = Me._btnOk
		 Me.AutoScaleDimensions = New System.Drawing.SizeF(8F, 16F)
		 Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		 Me.CancelButton = Me._btnCancel
		 Me.ClientSize = New System.Drawing.Size(306, 122)
		 Me.Controls.Add(Me._gbOptions)
		 Me.Controls.Add(Me._btnCancel)
		 Me.Controls.Add(Me._btnOk)
		 Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		 Me.MaximizeBox = False
		 Me.MinimizeBox = False
		 Me.Name = "FlipDialog"
		 Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
		 Me.Text = "Flip"
'		 Me.Load += New System.EventHandler(Me.FlipDialog_Load);
		 Me._gbOptions.ResumeLayout(False)
		 Me.ResumeLayout(False)

	  End Sub

	  #End Region

	  Private _gbOptions As System.Windows.Forms.GroupBox
	  Private _btnCancel As System.Windows.Forms.Button
	  Private WithEvents _btnOk As System.Windows.Forms.Button
	  Private _rbVertical As System.Windows.Forms.RadioButton
	  Private _rbHorizontal As System.Windows.Forms.RadioButton
   End Class
End Namespace