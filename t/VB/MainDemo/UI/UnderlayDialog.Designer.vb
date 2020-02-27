Imports Microsoft.VisualBasic
Imports System
Namespace MainDemo
   Public Partial Class UnderlayDialog
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
		 Me._btnCancel = New System.Windows.Forms.Button()
		 Me._btnOk = New System.Windows.Forms.Button()
		 Me._gbOptions = New System.Windows.Forms.GroupBox()
		 Me._rbTile = New System.Windows.Forms.RadioButton()
		 Me._rbStretch = New System.Windows.Forms.RadioButton()
		 Me._gbOptions.SuspendLayout()
		 Me.SuspendLayout()
		 ' 
		 ' _btnCancel
		 ' 
		 Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
		 Me._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
		 Me._btnCancel.Location = New System.Drawing.Point(202, 55)
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
		 Me._btnOk.Location = New System.Drawing.Point(202, 18)
		 Me._btnOk.Name = "_btnOk"
		 Me._btnOk.Size = New System.Drawing.Size(90, 27)
		 Me._btnOk.TabIndex = 1
		 Me._btnOk.Text = "OK"
		 Me._btnOk.UseVisualStyleBackColor = True
'		 Me._btnOk.Click += New System.EventHandler(Me._btnOk_Click);
		 ' 
		 ' _gbOptions
		 ' 
		 Me._gbOptions.Controls.Add(Me._rbTile)
		 Me._gbOptions.Controls.Add(Me._rbStretch)
		 Me._gbOptions.FlatStyle = System.Windows.Forms.FlatStyle.System
		 Me._gbOptions.Location = New System.Drawing.Point(10, 9)
		 Me._gbOptions.Name = "_gbOptions"
		 Me._gbOptions.Size = New System.Drawing.Size(163, 102)
		 Me._gbOptions.TabIndex = 0
		 Me._gbOptions.TabStop = False
		 ' 
		 ' _rbTile
		 ' 
		 Me._rbTile.FlatStyle = System.Windows.Forms.FlatStyle.System
		 Me._rbTile.Location = New System.Drawing.Point(19, 62)
		 Me._rbTile.Name = "_rbTile"
		 Me._rbTile.Size = New System.Drawing.Size(125, 27)
		 Me._rbTile.TabIndex = 1
		 Me._rbTile.TabStop = True
		 Me._rbTile.Text = "Tile"
		 Me._rbTile.UseVisualStyleBackColor = True
		 ' 
		 ' _rbStretch
		 ' 
		 Me._rbStretch.FlatStyle = System.Windows.Forms.FlatStyle.System
		 Me._rbStretch.Location = New System.Drawing.Point(19, 25)
		 Me._rbStretch.Name = "_rbStretch"
		 Me._rbStretch.Size = New System.Drawing.Size(125, 27)
		 Me._rbStretch.TabIndex = 0
		 Me._rbStretch.TabStop = True
		 Me._rbStretch.Text = "Stretch"
		 Me._rbStretch.UseVisualStyleBackColor = True
		 ' 
		 ' UnderlayDialog
		 ' 
		 Me.AcceptButton = Me._btnOk
		 Me.AutoScaleDimensions = New System.Drawing.SizeF(8F, 16F)
		 Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		 Me.CancelButton = Me._btnCancel
		 Me.ClientSize = New System.Drawing.Size(302, 123)
		 Me.Controls.Add(Me._gbOptions)
		 Me.Controls.Add(Me._btnCancel)
		 Me.Controls.Add(Me._btnOk)
		 Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		 Me.MaximizeBox = False
		 Me.MinimizeBox = False
		 Me.Name = "UnderlayDialog"
		 Me.ShowInTaskbar = False
		 Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
		 Me.Text = "Underlay"
'		 Me.Load += New System.EventHandler(Me.UnderlayDialog_Load);
		 Me._gbOptions.ResumeLayout(False)
		 Me.ResumeLayout(False)

	  End Sub

	  #End Region

	  Private _btnCancel As System.Windows.Forms.Button
	  Private WithEvents _btnOk As System.Windows.Forms.Button
	  Private _gbOptions As System.Windows.Forms.GroupBox
	  Private _rbTile As System.Windows.Forms.RadioButton
	  Private _rbStretch As System.Windows.Forms.RadioButton
   End Class
End Namespace