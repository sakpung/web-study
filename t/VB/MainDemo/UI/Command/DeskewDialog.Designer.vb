Imports Microsoft.VisualBasic
Imports System
Namespace MainDemo
   Public Partial Class DeskewDialog
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
		 Me._pnlFillColor = New System.Windows.Forms.Panel()
		 Me._btnFillColor = New System.Windows.Forms.Button()
		 Me._rbNoFill = New System.Windows.Forms.RadioButton()
		 Me._rbFill = New System.Windows.Forms.RadioButton()
		 Me._lblFillColor = New System.Windows.Forms.Label()
		 Me._gbOptions.SuspendLayout()
		 Me.SuspendLayout()
		 ' 
		 ' _btnCancel
		 ' 
		 Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
		 Me._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
		 Me._btnCancel.Location = New System.Drawing.Point(346, 55)
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
		 Me._btnOk.Location = New System.Drawing.Point(346, 18)
		 Me._btnOk.Name = "_btnOk"
		 Me._btnOk.Size = New System.Drawing.Size(90, 27)
		 Me._btnOk.TabIndex = 1
		 Me._btnOk.Text = "OK"
		 Me._btnOk.UseVisualStyleBackColor = True
'		 Me._btnOk.Click += New System.EventHandler(Me._btnOk_Click);
		 ' 
		 ' _gbOptions
		 ' 
		 Me._gbOptions.Controls.Add(Me._pnlFillColor)
		 Me._gbOptions.Controls.Add(Me._btnFillColor)
		 Me._gbOptions.Controls.Add(Me._rbNoFill)
		 Me._gbOptions.Controls.Add(Me._rbFill)
		 Me._gbOptions.Controls.Add(Me._lblFillColor)
		 Me._gbOptions.FlatStyle = System.Windows.Forms.FlatStyle.System
		 Me._gbOptions.Location = New System.Drawing.Point(10, 9)
		 Me._gbOptions.Name = "_gbOptions"
		 Me._gbOptions.Size = New System.Drawing.Size(307, 148)
		 Me._gbOptions.TabIndex = 0
		 Me._gbOptions.TabStop = False
		 ' 
		 ' _pnlFillColor
		 ' 
		 Me._pnlFillColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		 Me._pnlFillColor.Location = New System.Drawing.Point(144, 65)
		 Me._pnlFillColor.Name = "_pnlFillColor"
		 Me._pnlFillColor.Size = New System.Drawing.Size(115, 27)
		 Me._pnlFillColor.TabIndex = 2
'		 Me._pnlFillColor.Paint += New System.Windows.Forms.PaintEventHandler(Me._pnlFillColor_Paint);
		 ' 
		 ' _btnFillColor
		 ' 
		 Me._btnFillColor.FlatStyle = System.Windows.Forms.FlatStyle.System
		 Me._btnFillColor.Location = New System.Drawing.Point(259, 65)
		 Me._btnFillColor.Name = "_btnFillColor"
		 Me._btnFillColor.Size = New System.Drawing.Size(29, 26)
		 Me._btnFillColor.TabIndex = 3
		 Me._btnFillColor.Text = "..."
		 Me._btnFillColor.UseVisualStyleBackColor = True
'		 Me._btnFillColor.Click += New System.EventHandler(Me._btnFillColor_Click);
		 ' 
		 ' _rbNoFill
		 ' 
		 Me._rbNoFill.FlatStyle = System.Windows.Forms.FlatStyle.System
		 Me._rbNoFill.Location = New System.Drawing.Point(19, 102)
		 Me._rbNoFill.Name = "_rbNoFill"
		 Me._rbNoFill.Size = New System.Drawing.Size(173, 27)
		 Me._rbNoFill.TabIndex = 4
		 Me._rbNoFill.TabStop = True
		 Me._rbNoFill.Text = "Do not fill exposed area"
		 Me._rbNoFill.UseVisualStyleBackColor = True
'		 Me._rbNoFill.CheckedChanged += New System.EventHandler(Me._rb_CheckedChanged);
		 ' 
		 ' _rbFill
		 ' 
		 Me._rbFill.FlatStyle = System.Windows.Forms.FlatStyle.System
		 Me._rbFill.Location = New System.Drawing.Point(19, 28)
		 Me._rbFill.Name = "_rbFill"
		 Me._rbFill.Size = New System.Drawing.Size(144, 27)
		 Me._rbFill.TabIndex = 0
		 Me._rbFill.TabStop = True
		 Me._rbFill.Text = "Fill Exposed Area"
		 Me._rbFill.UseVisualStyleBackColor = True
'		 Me._rbFill.CheckedChanged += New System.EventHandler(Me._rb_CheckedChanged);
		 ' 
		 ' _lblFillColor
		 ' 
		 Me._lblFillColor.FlatStyle = System.Windows.Forms.FlatStyle.System
		 Me._lblFillColor.Location = New System.Drawing.Point(67, 65)
		 Me._lblFillColor.Name = "_lblFillColor"
		 Me._lblFillColor.Size = New System.Drawing.Size(67, 26)
		 Me._lblFillColor.TabIndex = 1
		 Me._lblFillColor.Text = "Fill Color"
		 Me._lblFillColor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		 ' 
		 ' DeskewDialog
		 ' 
		 Me.AcceptButton = Me._btnOk
		 Me.AutoScaleDimensions = New System.Drawing.SizeF(8F, 16F)
		 Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		 Me.CancelButton = Me._btnCancel
		 Me.ClientSize = New System.Drawing.Size(453, 175)
		 Me.Controls.Add(Me._gbOptions)
		 Me.Controls.Add(Me._btnCancel)
		 Me.Controls.Add(Me._btnOk)
		 Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		 Me.MaximizeBox = False
		 Me.MinimizeBox = False
		 Me.Name = "DeskewDialog"
		 Me.ShowInTaskbar = False
		 Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
		 Me.Text = "Deskew"
'		 Me.Load += New System.EventHandler(Me.DeskewDialog_Load);
		 Me._gbOptions.ResumeLayout(False)
		 Me.ResumeLayout(False)

	  End Sub

	  #End Region

	  Private _btnCancel As System.Windows.Forms.Button
	  Private WithEvents _btnOk As System.Windows.Forms.Button
	  Private _gbOptions As System.Windows.Forms.GroupBox
	  Private _lblFillColor As System.Windows.Forms.Label
	  Private WithEvents _pnlFillColor As System.Windows.Forms.Panel
	  Private WithEvents _btnFillColor As System.Windows.Forms.Button
	  Private WithEvents _rbNoFill As System.Windows.Forms.RadioButton
	  Private WithEvents _rbFill As System.Windows.Forms.RadioButton
   End Class
End Namespace