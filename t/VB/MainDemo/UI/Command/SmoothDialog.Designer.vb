Imports Microsoft.VisualBasic
Imports System
Namespace MainDemo
   Public Partial Class SmoothDialog
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
		 Me._cbFavorLong = New System.Windows.Forms.CheckBox()
		 Me._gbOptions = New System.Windows.Forms.GroupBox()
		 Me._lblLength = New System.Windows.Forms.Label()
		 Me._numLength = New System.Windows.Forms.NumericUpDown()
		 Me._gbFlags = New System.Windows.Forms.GroupBox()
		 Me._cbImageUnchanged = New System.Windows.Forms.CheckBox()
		 Me._btnCancel = New System.Windows.Forms.Button()
		 Me._btnOk = New System.Windows.Forms.Button()
		 Me._gbOptions.SuspendLayout()
		 CType(Me._numLength, System.ComponentModel.ISupportInitialize).BeginInit()
		 Me._gbFlags.SuspendLayout()
		 Me.SuspendLayout()
		 ' 
		 ' _cbFavorLong
		 ' 
		 Me._cbFavorLong.FlatStyle = System.Windows.Forms.FlatStyle.System
		 Me._cbFavorLong.Location = New System.Drawing.Point(182, 28)
		 Me._cbFavorLong.Name = "_cbFavorLong"
		 Me._cbFavorLong.Size = New System.Drawing.Size(144, 27)
		 Me._cbFavorLong.TabIndex = 1
		 Me._cbFavorLong.Text = "Favor Long"
		 ' 
		 ' _gbOptions
		 ' 
		 Me._gbOptions.Controls.Add(Me._lblLength)
		 Me._gbOptions.Controls.Add(Me._numLength)
		 Me._gbOptions.FlatStyle = System.Windows.Forms.FlatStyle.System
		 Me._gbOptions.Location = New System.Drawing.Point(12, 86)
		 Me._gbOptions.Name = "_gbOptions"
		 Me._gbOptions.Size = New System.Drawing.Size(336, 65)
		 Me._gbOptions.TabIndex = 1
		 Me._gbOptions.TabStop = False
		 Me._gbOptions.Text = "Options"
		 ' 
		 ' _lblLength
		 ' 
		 Me._lblLength.FlatStyle = System.Windows.Forms.FlatStyle.System
		 Me._lblLength.Location = New System.Drawing.Point(19, 28)
		 Me._lblLength.Name = "_lblLength"
		 Me._lblLength.Size = New System.Drawing.Size(96, 26)
		 Me._lblLength.TabIndex = 0
		 Me._lblLength.Text = "Length"
		 Me._lblLength.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		 ' 
		 ' _numLength
		 ' 
		 Me._numLength.Location = New System.Drawing.Point(125, 28)
		 Me._numLength.Maximum = New Decimal(New Integer() { 10000, 0, 0, 0})
		 Me._numLength.Minimum = New Decimal(New Integer() { 1, 0, 0, 0})
		 Me._numLength.Name = "_numLength"
		 Me._numLength.Size = New System.Drawing.Size(192, 22)
		 Me._numLength.TabIndex = 1
		 Me._numLength.Value = New Decimal(New Integer() { 1, 0, 0, 0})
'		 Me._numLength.Leave += New System.EventHandler(Me._num_Leave);
		 ' 
		 ' _gbFlags
		 ' 
		 Me._gbFlags.Controls.Add(Me._cbFavorLong)
		 Me._gbFlags.Controls.Add(Me._cbImageUnchanged)
		 Me._gbFlags.FlatStyle = System.Windows.Forms.FlatStyle.System
		 Me._gbFlags.Location = New System.Drawing.Point(12, 12)
		 Me._gbFlags.Name = "_gbFlags"
		 Me._gbFlags.Size = New System.Drawing.Size(336, 65)
		 Me._gbFlags.TabIndex = 0
		 Me._gbFlags.TabStop = False
		 Me._gbFlags.Text = "Flags"
		 ' 
		 ' _cbImageUnchanged
		 ' 
		 Me._cbImageUnchanged.FlatStyle = System.Windows.Forms.FlatStyle.System
		 Me._cbImageUnchanged.Location = New System.Drawing.Point(19, 28)
		 Me._cbImageUnchanged.Name = "_cbImageUnchanged"
		 Me._cbImageUnchanged.Size = New System.Drawing.Size(144, 27)
		 Me._cbImageUnchanged.TabIndex = 0
		 Me._cbImageUnchanged.Text = "Image Unchanged"
		 ' 
		 ' _btnCancel
		 ' 
		 Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
		 Me._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
		 Me._btnCancel.Location = New System.Drawing.Point(376, 58)
		 Me._btnCancel.Name = "_btnCancel"
		 Me._btnCancel.Size = New System.Drawing.Size(90, 27)
		 Me._btnCancel.TabIndex = 3
		 Me._btnCancel.Text = "Cancel"
		 ' 
		 ' _btnOk
		 ' 
		 Me._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK
		 Me._btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System
		 Me._btnOk.Location = New System.Drawing.Point(376, 21)
		 Me._btnOk.Name = "_btnOk"
		 Me._btnOk.Size = New System.Drawing.Size(90, 27)
		 Me._btnOk.TabIndex = 2
		 Me._btnOk.Text = "OK"
'		 Me._btnOk.Click += New System.EventHandler(Me._btnOk_Click);
		 ' 
		 ' SmoothDialog
		 ' 
		 Me.AcceptButton = Me._btnOk
		 Me.AutoScaleDimensions = New System.Drawing.SizeF(8F, 16F)
		 Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		 Me.CancelButton = Me._btnCancel
		 Me.ClientSize = New System.Drawing.Size(477, 163)
		 Me.Controls.Add(Me._gbOptions)
		 Me.Controls.Add(Me._gbFlags)
		 Me.Controls.Add(Me._btnCancel)
		 Me.Controls.Add(Me._btnOk)
		 Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		 Me.MaximizeBox = False
		 Me.MinimizeBox = False
		 Me.Name = "SmoothDialog"
		 Me.ShowInTaskbar = False
		 Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
		 Me.Text = "Smooth"
'		 Me.Load += New System.EventHandler(Me.SmoothDialog_Load);
		 Me._gbOptions.ResumeLayout(False)
		 CType(Me._numLength, System.ComponentModel.ISupportInitialize).EndInit()
		 Me._gbFlags.ResumeLayout(False)
		 Me.ResumeLayout(False)

	  End Sub

	  #End Region

	  Private _cbFavorLong As System.Windows.Forms.CheckBox
	  Private _gbOptions As System.Windows.Forms.GroupBox
	  Private _lblLength As System.Windows.Forms.Label
	  Private WithEvents _numLength As System.Windows.Forms.NumericUpDown
	  Private _gbFlags As System.Windows.Forms.GroupBox
	  Private _cbImageUnchanged As System.Windows.Forms.CheckBox
	  Private _btnCancel As System.Windows.Forms.Button
	  Private WithEvents _btnOk As System.Windows.Forms.Button
   End Class
End Namespace