Imports Microsoft.VisualBasic
Imports System
Namespace MainDemo
   Public Partial Class UnsharpMaskDialog
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
		 Me._cbColorSpace = New System.Windows.Forms.ComboBox()
		 Me._lblColorSpace = New System.Windows.Forms.Label()
		 Me._numThreshold = New System.Windows.Forms.NumericUpDown()
		 Me._lblThreshold = New System.Windows.Forms.Label()
		 Me._numRadius = New System.Windows.Forms.NumericUpDown()
		 Me._lblRadius = New System.Windows.Forms.Label()
		 Me._numAmount = New System.Windows.Forms.NumericUpDown()
		 Me._lblAmount = New System.Windows.Forms.Label()
		 Me._btnCancel = New System.Windows.Forms.Button()
		 Me._btnOk = New System.Windows.Forms.Button()
		 Me._gbOptions.SuspendLayout()
		 CType(Me._numThreshold, System.ComponentModel.ISupportInitialize).BeginInit()
		 CType(Me._numRadius, System.ComponentModel.ISupportInitialize).BeginInit()
		 CType(Me._numAmount, System.ComponentModel.ISupportInitialize).BeginInit()
		 Me.SuspendLayout()
		 ' 
		 ' _gbOptions
		 ' 
		 Me._gbOptions.Controls.Add(Me._cbColorSpace)
		 Me._gbOptions.Controls.Add(Me._lblColorSpace)
		 Me._gbOptions.Controls.Add(Me._numThreshold)
		 Me._gbOptions.Controls.Add(Me._lblThreshold)
		 Me._gbOptions.Controls.Add(Me._numRadius)
		 Me._gbOptions.Controls.Add(Me._lblRadius)
		 Me._gbOptions.Controls.Add(Me._numAmount)
		 Me._gbOptions.Controls.Add(Me._lblAmount)
		 Me._gbOptions.FlatStyle = System.Windows.Forms.FlatStyle.System
		 Me._gbOptions.Location = New System.Drawing.Point(12, 12)
		 Me._gbOptions.Name = "_gbOptions"
		 Me._gbOptions.Size = New System.Drawing.Size(278, 166)
		 Me._gbOptions.TabIndex = 0
		 Me._gbOptions.TabStop = False
		 ' 
		 ' _cbColorSpace
		 ' 
		 Me._cbColorSpace.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		 Me._cbColorSpace.Location = New System.Drawing.Point(115, 129)
		 Me._cbColorSpace.Name = "_cbColorSpace"
		 Me._cbColorSpace.Size = New System.Drawing.Size(145, 24)
		 Me._cbColorSpace.TabIndex = 7
		 ' 
		 ' _lblColorSpace
		 ' 
		 Me._lblColorSpace.FlatStyle = System.Windows.Forms.FlatStyle.System
		 Me._lblColorSpace.Location = New System.Drawing.Point(19, 129)
		 Me._lblColorSpace.Name = "_lblColorSpace"
		 Me._lblColorSpace.Size = New System.Drawing.Size(87, 27)
		 Me._lblColorSpace.TabIndex = 6
		 Me._lblColorSpace.Text = "Color Space"
		 Me._lblColorSpace.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		 ' 
		 ' _numThreshold
		 ' 
		 Me._numThreshold.Location = New System.Drawing.Point(115, 92)
		 Me._numThreshold.Maximum = New Decimal(New Integer() { 255, 0, 0, 0})
		 Me._numThreshold.Name = "_numThreshold"
		 Me._numThreshold.Size = New System.Drawing.Size(144, 22)
		 Me._numThreshold.TabIndex = 5
		 Me._numThreshold.Value = New Decimal(New Integer() { 1, 0, 0, 0})
'		 Me._numThreshold.Leave += New System.EventHandler(Me._num_Leave);
		 ' 
		 ' _lblThreshold
		 ' 
		 Me._lblThreshold.FlatStyle = System.Windows.Forms.FlatStyle.System
		 Me._lblThreshold.Location = New System.Drawing.Point(19, 92)
		 Me._lblThreshold.Name = "_lblThreshold"
		 Me._lblThreshold.Size = New System.Drawing.Size(87, 27)
		 Me._lblThreshold.TabIndex = 4
		 Me._lblThreshold.Text = "Threshold"
		 Me._lblThreshold.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		 ' 
		 ' _numRadius
		 ' 
		 Me._numRadius.Location = New System.Drawing.Point(115, 55)
		 Me._numRadius.Maximum = New Decimal(New Integer() { 1000, 0, 0, 0})
		 Me._numRadius.Minimum = New Decimal(New Integer() { 1, 0, 0, 0})
		 Me._numRadius.Name = "_numRadius"
		 Me._numRadius.Size = New System.Drawing.Size(144, 22)
		 Me._numRadius.TabIndex = 3
		 Me._numRadius.Value = New Decimal(New Integer() { 1, 0, 0, 0})
'		 Me._numRadius.Leave += New System.EventHandler(Me._num_Leave);
		 ' 
		 ' _lblRadius
		 ' 
		 Me._lblRadius.FlatStyle = System.Windows.Forms.FlatStyle.System
		 Me._lblRadius.Location = New System.Drawing.Point(19, 55)
		 Me._lblRadius.Name = "_lblRadius"
		 Me._lblRadius.Size = New System.Drawing.Size(87, 27)
		 Me._lblRadius.TabIndex = 2
		 Me._lblRadius.Text = "Radius"
		 Me._lblRadius.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		 ' 
		 ' _numAmount
		 ' 
		 Me._numAmount.Location = New System.Drawing.Point(115, 18)
		 Me._numAmount.Maximum = New Decimal(New Integer() { 500, 0, 0, 0})
		 Me._numAmount.Name = "_numAmount"
		 Me._numAmount.Size = New System.Drawing.Size(144, 22)
		 Me._numAmount.TabIndex = 1
		 Me._numAmount.Value = New Decimal(New Integer() { 1, 0, 0, 0})
'		 Me._numAmount.Leave += New System.EventHandler(Me._num_Leave);
		 ' 
		 ' _lblAmount
		 ' 
		 Me._lblAmount.FlatStyle = System.Windows.Forms.FlatStyle.System
		 Me._lblAmount.Location = New System.Drawing.Point(19, 18)
		 Me._lblAmount.Name = "_lblAmount"
		 Me._lblAmount.Size = New System.Drawing.Size(87, 27)
		 Me._lblAmount.TabIndex = 0
		 Me._lblAmount.Text = "Amount"
		 Me._lblAmount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		 ' 
		 ' _btnCancel
		 ' 
		 Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
		 Me._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
		 Me._btnCancel.Location = New System.Drawing.Point(319, 58)
		 Me._btnCancel.Name = "_btnCancel"
		 Me._btnCancel.Size = New System.Drawing.Size(90, 27)
		 Me._btnCancel.TabIndex = 2
		 Me._btnCancel.Text = "Cancel"
		 ' 
		 ' _btnOk
		 ' 
		 Me._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK
		 Me._btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System
		 Me._btnOk.Location = New System.Drawing.Point(319, 21)
		 Me._btnOk.Name = "_btnOk"
		 Me._btnOk.Size = New System.Drawing.Size(90, 27)
		 Me._btnOk.TabIndex = 1
		 Me._btnOk.Text = "OK"
'		 Me._btnOk.Click += New System.EventHandler(Me._btnOk_Click);
		 ' 
		 ' UnsharpMaskDialog
		 ' 
		 Me.AcceptButton = Me._btnOk
		 Me.AutoScaleDimensions = New System.Drawing.SizeF(8F, 16F)
		 Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		 Me.CancelButton = Me._btnCancel
		 Me.ClientSize = New System.Drawing.Size(420, 194)
		 Me.Controls.Add(Me._gbOptions)
		 Me.Controls.Add(Me._btnCancel)
		 Me.Controls.Add(Me._btnOk)
		 Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		 Me.MaximizeBox = False
		 Me.MinimizeBox = False
		 Me.Name = "UnsharpMaskDialog"
		 Me.ShowInTaskbar = False
		 Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
		 Me.Text = "Unsharp Mask"
'		 Me.Load += New System.EventHandler(Me.UnsharpMaskDialog_Load);
		 Me._gbOptions.ResumeLayout(False)
		 CType(Me._numThreshold, System.ComponentModel.ISupportInitialize).EndInit()
		 CType(Me._numRadius, System.ComponentModel.ISupportInitialize).EndInit()
		 CType(Me._numAmount, System.ComponentModel.ISupportInitialize).EndInit()
		 Me.ResumeLayout(False)

	  End Sub

	  #End Region

	  Private _gbOptions As System.Windows.Forms.GroupBox
	  Private _cbColorSpace As System.Windows.Forms.ComboBox
	  Private _lblColorSpace As System.Windows.Forms.Label
	  Private WithEvents _numThreshold As System.Windows.Forms.NumericUpDown
	  Private _lblThreshold As System.Windows.Forms.Label
	  Private WithEvents _numRadius As System.Windows.Forms.NumericUpDown
	  Private _lblRadius As System.Windows.Forms.Label
	  Private WithEvents _numAmount As System.Windows.Forms.NumericUpDown
	  Private _lblAmount As System.Windows.Forms.Label
	  Private _btnCancel As System.Windows.Forms.Button
	  Private WithEvents _btnOk As System.Windows.Forms.Button
   End Class
End Namespace