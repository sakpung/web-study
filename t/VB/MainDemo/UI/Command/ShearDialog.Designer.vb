Imports Microsoft.VisualBasic
Imports System
Namespace MainDemo
   Public Partial Class ShearDialog
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
		 Me._gb = New System.Windows.Forms.GroupBox()
		 Me._lblDirection = New System.Windows.Forms.Label()
		 Me._gbDirection = New System.Windows.Forms.GroupBox()
		 Me._btnFillColor = New System.Windows.Forms.Button()
		 Me._pnlFillColor = New System.Windows.Forms.Panel()
		 Me._lblFillColor = New System.Windows.Forms.Label()
		 Me._numAngle = New System.Windows.Forms.NumericUpDown()
		 Me._lblAngle = New System.Windows.Forms.Label()
		 Me._rbHorizontal = New System.Windows.Forms.RadioButton()
		 Me._rbVertical = New System.Windows.Forms.RadioButton()
		 Me._btnCancel = New System.Windows.Forms.Button()
		 Me._btnOk = New System.Windows.Forms.Button()
		 Me._gb.SuspendLayout()
		 CType(Me._numAngle, System.ComponentModel.ISupportInitialize).BeginInit()
		 Me.SuspendLayout()
		 ' 
		 ' _gb
		 ' 
		 Me._gb.Controls.Add(Me._lblDirection)
		 Me._gb.Controls.Add(Me._gbDirection)
		 Me._gb.Controls.Add(Me._btnFillColor)
		 Me._gb.Controls.Add(Me._pnlFillColor)
		 Me._gb.Controls.Add(Me._lblFillColor)
		 Me._gb.Controls.Add(Me._numAngle)
		 Me._gb.Controls.Add(Me._lblAngle)
		 Me._gb.Controls.Add(Me._rbHorizontal)
		 Me._gb.Controls.Add(Me._rbVertical)
		 Me._gb.FlatStyle = System.Windows.Forms.FlatStyle.System
		 Me._gb.Location = New System.Drawing.Point(12, 12)
		 Me._gb.Name = "_gb"
		 Me._gb.Size = New System.Drawing.Size(316, 231)
		 Me._gb.TabIndex = 0
		 Me._gb.TabStop = False
		 ' 
		 ' _lblDirection
		 ' 
		 Me._lblDirection.FlatStyle = System.Windows.Forms.FlatStyle.System
		 Me._lblDirection.Location = New System.Drawing.Point(19, 120)
		 Me._lblDirection.Name = "_lblDirection"
		 Me._lblDirection.Size = New System.Drawing.Size(120, 27)
		 Me._lblDirection.TabIndex = 6
		 Me._lblDirection.Text = "Direction"
		 Me._lblDirection.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		 ' 
		 ' _gbDirection
		 ' 
		 Me._gbDirection.FlatStyle = System.Windows.Forms.FlatStyle.System
		 Me._gbDirection.Location = New System.Drawing.Point(19, 102)
		 Me._gbDirection.Name = "_gbDirection"
		 Me._gbDirection.Size = New System.Drawing.Size(279, 9)
		 Me._gbDirection.TabIndex = 5
		 Me._gbDirection.TabStop = False
		 ' 
		 ' _btnFillColor
		 ' 
		 Me._btnFillColor.FlatStyle = System.Windows.Forms.FlatStyle.System
		 Me._btnFillColor.Location = New System.Drawing.Point(269, 65)
		 Me._btnFillColor.Name = "_btnFillColor"
		 Me._btnFillColor.Size = New System.Drawing.Size(29, 26)
		 Me._btnFillColor.TabIndex = 4
		 Me._btnFillColor.Text = "..."
'		 Me._btnFillColor.Click += New System.EventHandler(Me._btnFillColor_Click);
		 ' 
		 ' _pnlFillColor
		 ' 
		 Me._pnlFillColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		 Me._pnlFillColor.Location = New System.Drawing.Point(154, 65)
		 Me._pnlFillColor.Name = "_pnlFillColor"
		 Me._pnlFillColor.Size = New System.Drawing.Size(115, 27)
		 Me._pnlFillColor.TabIndex = 3
'		 Me._pnlFillColor.Paint += New System.Windows.Forms.PaintEventHandler(Me._pnlFillColor_Paint);
		 ' 
		 ' _lblFillColor
		 ' 
		 Me._lblFillColor.FlatStyle = System.Windows.Forms.FlatStyle.System
		 Me._lblFillColor.Location = New System.Drawing.Point(19, 65)
		 Me._lblFillColor.Name = "_lblFillColor"
		 Me._lblFillColor.Size = New System.Drawing.Size(120, 26)
		 Me._lblFillColor.TabIndex = 2
		 Me._lblFillColor.Text = "Fill Color"
		 Me._lblFillColor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		 ' 
		 ' _numAngle
		 ' 
		 Me._numAngle.Location = New System.Drawing.Point(154, 28)
		 Me._numAngle.Maximum = New Decimal(New Integer() { 45, 0, 0, 0})
		 Me._numAngle.Name = "_numAngle"
		 Me._numAngle.Size = New System.Drawing.Size(144, 22)
		 Me._numAngle.TabIndex = 1
'		 Me._numAngle.Leave += New System.EventHandler(Me._num_Leave);
		 ' 
		 ' _lblAngle
		 ' 
		 Me._lblAngle.FlatStyle = System.Windows.Forms.FlatStyle.System
		 Me._lblAngle.Location = New System.Drawing.Point(19, 28)
		 Me._lblAngle.Name = "_lblAngle"
		 Me._lblAngle.Size = New System.Drawing.Size(120, 26)
		 Me._lblAngle.TabIndex = 0
		 Me._lblAngle.Text = "Angle"
		 Me._lblAngle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		 ' 
		 ' _rbHorizontal
		 ' 
		 Me._rbHorizontal.FlatStyle = System.Windows.Forms.FlatStyle.System
		 Me._rbHorizontal.Location = New System.Drawing.Point(19, 157)
		 Me._rbHorizontal.Name = "_rbHorizontal"
		 Me._rbHorizontal.Size = New System.Drawing.Size(154, 28)
		 Me._rbHorizontal.TabIndex = 7
		 Me._rbHorizontal.Text = "Horizontal"
		 ' 
		 ' _rbVertical
		 ' 
		 Me._rbVertical.FlatStyle = System.Windows.Forms.FlatStyle.System
		 Me._rbVertical.Location = New System.Drawing.Point(19, 194)
		 Me._rbVertical.Name = "_rbVertical"
		 Me._rbVertical.Size = New System.Drawing.Size(154, 28)
		 Me._rbVertical.TabIndex = 8
		 Me._rbVertical.Text = "Vertical"
		 ' 
		 ' _btnCancel
		 ' 
		 Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
		 Me._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
		 Me._btnCancel.Location = New System.Drawing.Point(348, 58)
		 Me._btnCancel.Name = "_btnCancel"
		 Me._btnCancel.Size = New System.Drawing.Size(90, 27)
		 Me._btnCancel.TabIndex = 2
		 Me._btnCancel.Text = "Cancel"
		 ' 
		 ' _btnOk
		 ' 
		 Me._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK
		 Me._btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System
		 Me._btnOk.Location = New System.Drawing.Point(348, 21)
		 Me._btnOk.Name = "_btnOk"
		 Me._btnOk.Size = New System.Drawing.Size(90, 27)
		 Me._btnOk.TabIndex = 1
		 Me._btnOk.Text = "OK"
'		 Me._btnOk.Click += New System.EventHandler(Me._btnOk_Click);
		 ' 
		 ' ShearDialog
		 ' 
		 Me.AcceptButton = Me._btnOk
		 Me.AutoScaleDimensions = New System.Drawing.SizeF(8F, 16F)
		 Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		 Me.CancelButton = Me._btnCancel
		 Me.ClientSize = New System.Drawing.Size(450, 259)
		 Me.Controls.Add(Me._gb)
		 Me.Controls.Add(Me._btnCancel)
		 Me.Controls.Add(Me._btnOk)
		 Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		 Me.MaximizeBox = False
		 Me.MinimizeBox = False
		 Me.Name = "ShearDialog"
		 Me.ShowInTaskbar = False
		 Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
		 Me.Text = "Shear"
'		 Me.Load += New System.EventHandler(Me.ShearDialog_Load);
		 Me._gb.ResumeLayout(False)
		 CType(Me._numAngle, System.ComponentModel.ISupportInitialize).EndInit()
		 Me.ResumeLayout(False)

	  End Sub

	  #End Region

	  Private _gb As System.Windows.Forms.GroupBox
	  Private _lblDirection As System.Windows.Forms.Label
	  Private _gbDirection As System.Windows.Forms.GroupBox
	  Private WithEvents _btnFillColor As System.Windows.Forms.Button
	  Private WithEvents _pnlFillColor As System.Windows.Forms.Panel
	  Private _lblFillColor As System.Windows.Forms.Label
	  Private WithEvents _numAngle As System.Windows.Forms.NumericUpDown
	  Private _lblAngle As System.Windows.Forms.Label
	  Private _rbHorizontal As System.Windows.Forms.RadioButton
	  Private _rbVertical As System.Windows.Forms.RadioButton
	  Private _btnCancel As System.Windows.Forms.Button
	  Private WithEvents _btnOk As System.Windows.Forms.Button
   End Class
End Namespace