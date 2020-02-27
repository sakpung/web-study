Imports Microsoft.VisualBasic
Imports System
Namespace MainDemo
   Public Partial Class SwapColorsDialog
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
		 Me._cbType = New System.Windows.Forms.ComboBox()
		 Me._labelType = New System.Windows.Forms.Label()
		 Me._btnCancel = New System.Windows.Forms.Button()
		 Me._btnOk = New System.Windows.Forms.Button()
		 Me._gbOptions.SuspendLayout()
		 Me.SuspendLayout()
		 ' 
		 ' _gbOptions
		 ' 
		 Me._gbOptions.Controls.Add(Me._cbType)
		 Me._gbOptions.Controls.Add(Me._labelType)
		 Me._gbOptions.FlatStyle = System.Windows.Forms.FlatStyle.System
		 Me._gbOptions.Location = New System.Drawing.Point(12, 12)
		 Me._gbOptions.Name = "_gbOptions"
		 Me._gbOptions.Size = New System.Drawing.Size(374, 74)
		 Me._gbOptions.TabIndex = 0
		 Me._gbOptions.TabStop = False
		 ' 
		 ' _cbType
		 ' 
		 Me._cbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		 Me._cbType.Location = New System.Drawing.Point(86, 28)
		 Me._cbType.Name = "_cbType"
		 Me._cbType.Size = New System.Drawing.Size(279, 24)
		 Me._cbType.TabIndex = 0
		 ' 
		 ' _labelType
		 ' 
		 Me._labelType.FlatStyle = System.Windows.Forms.FlatStyle.System
		 Me._labelType.Location = New System.Drawing.Point(19, 28)
		 Me._labelType.Name = "_labelType"
		 Me._labelType.Size = New System.Drawing.Size(58, 26)
		 Me._labelType.TabIndex = 0
		 Me._labelType.Text = "Type"
		 Me._labelType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		 ' 
		 ' _btnCancel
		 ' 
		 Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
		 Me._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
		 Me._btnCancel.Location = New System.Drawing.Point(405, 58)
		 Me._btnCancel.Name = "_btnCancel"
		 Me._btnCancel.Size = New System.Drawing.Size(90, 27)
		 Me._btnCancel.TabIndex = 2
		 Me._btnCancel.Text = "Cancel"
		 ' 
		 ' _btnOk
		 ' 
		 Me._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK
		 Me._btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System
		 Me._btnOk.Location = New System.Drawing.Point(405, 21)
		 Me._btnOk.Name = "_btnOk"
		 Me._btnOk.Size = New System.Drawing.Size(90, 27)
		 Me._btnOk.TabIndex = 1
		 Me._btnOk.Text = "OK"
'		 Me._btnOk.Click += New System.EventHandler(Me._btnOk_Click);
		 ' 
		 ' SwapColorsDialog
		 ' 
		 Me.AcceptButton = Me._btnOk
		 Me.AutoScaleDimensions = New System.Drawing.SizeF(8F, 16F)
		 Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		 Me.CancelButton = Me._btnCancel
		 Me.ClientSize = New System.Drawing.Size(510, 104)
		 Me.Controls.Add(Me._gbOptions)
		 Me.Controls.Add(Me._btnCancel)
		 Me.Controls.Add(Me._btnOk)
		 Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		 Me.MaximizeBox = False
		 Me.MinimizeBox = False
		 Me.Name = "SwapColorsDialog"
		 Me.ShowInTaskbar = False
		 Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
		 Me.Text = "Swap Colors"
'		 Me.Load += New System.EventHandler(Me.SwapColorsDialog_Load);
		 Me._gbOptions.ResumeLayout(False)
		 Me.ResumeLayout(False)

	  End Sub

	  #End Region

	  Private _gbOptions As System.Windows.Forms.GroupBox
	  Private _cbType As System.Windows.Forms.ComboBox
	  Private _labelType As System.Windows.Forms.Label
	  Private _btnCancel As System.Windows.Forms.Button
	  Private WithEvents _btnOk As System.Windows.Forms.Button
   End Class
End Namespace