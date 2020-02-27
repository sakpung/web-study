Imports Microsoft.VisualBasic
Imports System
Namespace MainDemo
   Public Partial Class EmbossDialog
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
		 Me._cbDirection = New System.Windows.Forms.ComboBox()
		 Me._numDepth = New System.Windows.Forms.NumericUpDown()
		 Me._lblDirection = New System.Windows.Forms.Label()
		 Me._lblDepth = New System.Windows.Forms.Label()
		 Me._gbOptions.SuspendLayout()
		 CType(Me._numDepth, System.ComponentModel.ISupportInitialize).BeginInit()
		 Me.SuspendLayout()
		 ' 
		 ' _btnCancel
		 ' 
		 Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
		 Me._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
		 Me._btnCancel.Location = New System.Drawing.Point(311, 58)
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
		 Me._btnOk.Location = New System.Drawing.Point(311, 21)
		 Me._btnOk.Name = "_btnOk"
		 Me._btnOk.Size = New System.Drawing.Size(90, 27)
		 Me._btnOk.TabIndex = 1
		 Me._btnOk.Text = "OK"
		 Me._btnOk.UseVisualStyleBackColor = True
'		 Me._btnOk.Click += New System.EventHandler(Me._btnOk_Click);
		 ' 
		 ' _gbOptions
		 ' 
		 Me._gbOptions.Controls.Add(Me._cbDirection)
		 Me._gbOptions.Controls.Add(Me._numDepth)
		 Me._gbOptions.Controls.Add(Me._lblDirection)
		 Me._gbOptions.Controls.Add(Me._lblDepth)
		 Me._gbOptions.FlatStyle = System.Windows.Forms.FlatStyle.System
		 Me._gbOptions.Location = New System.Drawing.Point(10, 9)
		 Me._gbOptions.Name = "_gbOptions"
		 Me._gbOptions.Size = New System.Drawing.Size(278, 93)
		 Me._gbOptions.TabIndex = 0
		 Me._gbOptions.TabStop = False
		 ' 
		 ' _cbDirection
		 ' 
		 Me._cbDirection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		 Me._cbDirection.FormattingEnabled = True
		 Me._cbDirection.Location = New System.Drawing.Point(115, 18)
		 Me._cbDirection.Name = "_cbDirection"
		 Me._cbDirection.Size = New System.Drawing.Size(145, 24)
		 Me._cbDirection.TabIndex = 1
		 ' 
		 ' _numDepth
		 ' 
		 Me._numDepth.Location = New System.Drawing.Point(115, 55)
		 Me._numDepth.Name = "_numDepth"
		 Me._numDepth.Size = New System.Drawing.Size(144, 22)
		 Me._numDepth.TabIndex = 3
		 Me._numDepth.Value = New Decimal(New Integer() { 1, 0, 0, 0})
'		 Me._numDepth.Leave += New System.EventHandler(Me._num_Leave);
		 ' 
		 ' _lblDirection
		 ' 
		 Me._lblDirection.FlatStyle = System.Windows.Forms.FlatStyle.System
		 Me._lblDirection.Location = New System.Drawing.Point(19, 18)
		 Me._lblDirection.Name = "_lblDirection"
		 Me._lblDirection.Size = New System.Drawing.Size(77, 27)
		 Me._lblDirection.TabIndex = 0
		 Me._lblDirection.Text = "Filter"
		 Me._lblDirection.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		 ' 
		 ' _lblDepth
		 ' 
		 Me._lblDepth.FlatStyle = System.Windows.Forms.FlatStyle.System
		 Me._lblDepth.Location = New System.Drawing.Point(19, 55)
		 Me._lblDepth.Name = "_lblDepth"
		 Me._lblDepth.Size = New System.Drawing.Size(77, 27)
		 Me._lblDepth.TabIndex = 2
		 Me._lblDepth.Text = "Depth"
		 Me._lblDepth.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		 ' 
		 ' EmbossDialog
		 ' 
		 Me.AutoScaleDimensions = New System.Drawing.SizeF(8F, 16F)
		 Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		 Me.ClientSize = New System.Drawing.Size(420, 118)
		 Me.Controls.Add(Me._gbOptions)
		 Me.Controls.Add(Me._btnCancel)
		 Me.Controls.Add(Me._btnOk)
		 Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		 Me.MaximizeBox = False
		 Me.MinimizeBox = False
		 Me.Name = "EmbossDialog"
		 Me.ShowInTaskbar = False
		 Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
		 Me.Text = "Emboss"
'		 Me.Load += New System.EventHandler(Me.EmbossDialog_Load);
		 Me._gbOptions.ResumeLayout(False)
		 CType(Me._numDepth, System.ComponentModel.ISupportInitialize).EndInit()
		 Me.ResumeLayout(False)

	  End Sub

	  #End Region

	  Private _btnCancel As System.Windows.Forms.Button
	  Private WithEvents _btnOk As System.Windows.Forms.Button
	  Private _gbOptions As System.Windows.Forms.GroupBox
	  Private _cbDirection As System.Windows.Forms.ComboBox
	  Private WithEvents _numDepth As System.Windows.Forms.NumericUpDown
	  Private _lblDirection As System.Windows.Forms.Label
	  Private _lblDepth As System.Windows.Forms.Label
   End Class
End Namespace