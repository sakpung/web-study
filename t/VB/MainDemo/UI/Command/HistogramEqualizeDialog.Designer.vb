Imports Microsoft.VisualBasic
Imports System
Namespace MainDemo
   Public Partial Class HistogramEqualizeDialog
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
		 Me._cbColorSpace = New System.Windows.Forms.ComboBox()
		 Me._lblColorSpace = New System.Windows.Forms.Label()
		 Me._gbOptions.SuspendLayout()
		 Me.SuspendLayout()
		 ' 
		 ' _btnCancel
		 ' 
		 Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
		 Me._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
		 Me._btnCancel.Location = New System.Drawing.Point(278, 55)
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
		 Me._btnOk.Location = New System.Drawing.Point(278, 18)
		 Me._btnOk.Name = "_btnOk"
		 Me._btnOk.Size = New System.Drawing.Size(90, 27)
		 Me._btnOk.TabIndex = 1
		 Me._btnOk.Text = "OK"
		 Me._btnOk.UseVisualStyleBackColor = True
'		 Me._btnOk.Click += New System.EventHandler(Me._btnOk_Click);
		 ' 
		 ' _gbOptions
		 ' 
		 Me._gbOptions.Controls.Add(Me._cbColorSpace)
		 Me._gbOptions.Controls.Add(Me._lblColorSpace)
		 Me._gbOptions.FlatStyle = System.Windows.Forms.FlatStyle.System
		 Me._gbOptions.Location = New System.Drawing.Point(10, 9)
		 Me._gbOptions.Name = "_gbOptions"
		 Me._gbOptions.Size = New System.Drawing.Size(240, 102)
		 Me._gbOptions.TabIndex = 0
		 Me._gbOptions.TabStop = False
		 ' 
		 ' _cbColorSpace
		 ' 
		 Me._cbColorSpace.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		 Me._cbColorSpace.FormattingEnabled = True
		 Me._cbColorSpace.Location = New System.Drawing.Point(19, 65)
		 Me._cbColorSpace.Name = "_cbColorSpace"
		 Me._cbColorSpace.Size = New System.Drawing.Size(202, 24)
		 Me._cbColorSpace.TabIndex = 1
		 ' 
		 ' _lblColorSpace
		 ' 
		 Me._lblColorSpace.FlatStyle = System.Windows.Forms.FlatStyle.System
		 Me._lblColorSpace.Location = New System.Drawing.Point(19, 28)
		 Me._lblColorSpace.Name = "_lblColorSpace"
		 Me._lblColorSpace.Size = New System.Drawing.Size(87, 26)
		 Me._lblColorSpace.TabIndex = 0
		 Me._lblColorSpace.Text = "Color Space"
		 Me._lblColorSpace.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		 ' 
		 ' HistogramEqualizeDialog
		 ' 
		 Me.AutoScaleDimensions = New System.Drawing.SizeF(8F, 16F)
		 Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		 Me.ClientSize = New System.Drawing.Size(385, 130)
		 Me.Controls.Add(Me._btnCancel)
		 Me.Controls.Add(Me._btnOk)
		 Me.Controls.Add(Me._gbOptions)
		 Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		 Me.MaximizeBox = False
		 Me.MinimizeBox = False
		 Me.Name = "HistogramEqualizeDialog"
		 Me.ShowInTaskbar = False
		 Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
		 Me.Text = "Histo Equalize"
'		 Me.Load += New System.EventHandler(Me.HistogramEqualizeDialog_Load);
		 Me._gbOptions.ResumeLayout(False)
		 Me.ResumeLayout(False)

	  End Sub

	  #End Region

	  Private _btnCancel As System.Windows.Forms.Button
	  Private WithEvents _btnOk As System.Windows.Forms.Button
	  Private _gbOptions As System.Windows.Forms.GroupBox
	  Private _cbColorSpace As System.Windows.Forms.ComboBox
	  Private _lblColorSpace As System.Windows.Forms.Label
   End Class
End Namespace