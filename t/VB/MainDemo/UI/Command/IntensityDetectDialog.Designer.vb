Imports Microsoft.VisualBasic
Imports System
Namespace MainDemo
   Public Partial Class IntensityDetectDialog
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
		 Me._lblMsg = New System.Windows.Forms.Label()
		 Me._gbOptions = New System.Windows.Forms.GroupBox()
		 Me._btnOutColor = New System.Windows.Forms.Button()
		 Me._btnInColor = New System.Windows.Forms.Button()
		 Me._cbChannel = New System.Windows.Forms.ComboBox()
		 Me._pnlOutColor = New System.Windows.Forms.Panel()
		 Me._pnlInColor = New System.Windows.Forms.Panel()
		 Me._numHigh = New System.Windows.Forms.NumericUpDown()
		 Me._numLow = New System.Windows.Forms.NumericUpDown()
		 Me._lblChannel = New System.Windows.Forms.Label()
		 Me._lblOutColor = New System.Windows.Forms.Label()
		 Me._lblInColor = New System.Windows.Forms.Label()
		 Me._lblHigh = New System.Windows.Forms.Label()
		 Me._lblLow = New System.Windows.Forms.Label()
		 Me._gbOptions.SuspendLayout()
		 CType(Me._numHigh, System.ComponentModel.ISupportInitialize).BeginInit()
		 CType(Me._numLow, System.ComponentModel.ISupportInitialize).BeginInit()
		 Me.SuspendLayout()
		 ' 
		 ' _btnCancel
		 ' 
		 Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
		 Me._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
		 Me._btnCancel.Location = New System.Drawing.Point(317, 55)
		 Me._btnCancel.Name = "_btnCancel"
		 Me._btnCancel.Size = New System.Drawing.Size(90, 27)
		 Me._btnCancel.TabIndex = 3
		 Me._btnCancel.Text = "Cancel"
		 Me._btnCancel.UseVisualStyleBackColor = True
		 ' 
		 ' _btnOk
		 ' 
		 Me._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK
		 Me._btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System
		 Me._btnOk.Location = New System.Drawing.Point(317, 18)
		 Me._btnOk.Name = "_btnOk"
		 Me._btnOk.Size = New System.Drawing.Size(90, 27)
		 Me._btnOk.TabIndex = 2
		 Me._btnOk.Text = "OK"
		 Me._btnOk.UseVisualStyleBackColor = True
'		 Me._btnOk.Click += New System.EventHandler(Me._btnOk_Click);
		 ' 
		 ' _lblMsg
		 ' 
		 Me._lblMsg.FlatStyle = System.Windows.Forms.FlatStyle.System
		 Me._lblMsg.Location = New System.Drawing.Point(10, 258)
		 Me._lblMsg.Name = "_lblMsg"
		 Me._lblMsg.Size = New System.Drawing.Size(278, 27)
		 Me._lblMsg.TabIndex = 1
		 Me._lblMsg.Text = "Low must be less than High."
		 ' 
		 ' _gbOptions
		 ' 
		 Me._gbOptions.Controls.Add(Me._btnOutColor)
		 Me._gbOptions.Controls.Add(Me._btnInColor)
		 Me._gbOptions.Controls.Add(Me._cbChannel)
		 Me._gbOptions.Controls.Add(Me._pnlOutColor)
		 Me._gbOptions.Controls.Add(Me._pnlInColor)
		 Me._gbOptions.Controls.Add(Me._numHigh)
		 Me._gbOptions.Controls.Add(Me._numLow)
		 Me._gbOptions.Controls.Add(Me._lblChannel)
		 Me._gbOptions.Controls.Add(Me._lblOutColor)
		 Me._gbOptions.Controls.Add(Me._lblInColor)
		 Me._gbOptions.Controls.Add(Me._lblHigh)
		 Me._gbOptions.Controls.Add(Me._lblLow)
		 Me._gbOptions.FlatStyle = System.Windows.Forms.FlatStyle.System
		 Me._gbOptions.Location = New System.Drawing.Point(10, 9)
		 Me._gbOptions.Name = "_gbOptions"
		 Me._gbOptions.Size = New System.Drawing.Size(278, 231)
		 Me._gbOptions.TabIndex = 0
		 Me._gbOptions.TabStop = False
		 ' 
		 ' _btnOutColor
		 ' 
		 Me._btnOutColor.FlatStyle = System.Windows.Forms.FlatStyle.System
		 Me._btnOutColor.Location = New System.Drawing.Point(230, 138)
		 Me._btnOutColor.Name = "_btnOutColor"
		 Me._btnOutColor.Size = New System.Drawing.Size(29, 27)
		 Me._btnOutColor.TabIndex = 9
		 Me._btnOutColor.Text = "..."
		 Me._btnOutColor.UseVisualStyleBackColor = True
'		 Me._btnOutColor.Click += New System.EventHandler(Me._btnOutColor_Click);
		 ' 
		 ' _btnInColor
		 ' 
		 Me._btnInColor.FlatStyle = System.Windows.Forms.FlatStyle.System
		 Me._btnInColor.Location = New System.Drawing.Point(230, 102)
		 Me._btnInColor.Name = "_btnInColor"
		 Me._btnInColor.Size = New System.Drawing.Size(29, 26)
		 Me._btnInColor.TabIndex = 6
		 Me._btnInColor.Text = "..."
		 Me._btnInColor.UseVisualStyleBackColor = True
'		 Me._btnInColor.Click += New System.EventHandler(Me._btnInColor_Click);
		 ' 
		 ' _cbChannel
		 ' 
		 Me._cbChannel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		 Me._cbChannel.FormattingEnabled = True
		 Me._cbChannel.Location = New System.Drawing.Point(106, 185)
		 Me._cbChannel.Name = "_cbChannel"
		 Me._cbChannel.Size = New System.Drawing.Size(153, 24)
		 Me._cbChannel.TabIndex = 11
'		 Me._cbChannel.SelectedIndexChanged += New System.EventHandler(Me._cbChannel_SelectedIndexChanged);
		 ' 
		 ' _pnlOutColor
		 ' 
		 Me._pnlOutColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		 Me._pnlOutColor.Location = New System.Drawing.Point(106, 138)
		 Me._pnlOutColor.Name = "_pnlOutColor"
		 Me._pnlOutColor.Size = New System.Drawing.Size(124, 28)
		 Me._pnlOutColor.TabIndex = 8
'		 Me._pnlOutColor.Paint += New System.Windows.Forms.PaintEventHandler(Me._pnlOutColor_Paint);
		 ' 
		 ' _pnlInColor
		 ' 
		 Me._pnlInColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		 Me._pnlInColor.Location = New System.Drawing.Point(106, 102)
		 Me._pnlInColor.Name = "_pnlInColor"
		 Me._pnlInColor.Size = New System.Drawing.Size(124, 27)
		 Me._pnlInColor.TabIndex = 5
'		 Me._pnlInColor.Paint += New System.Windows.Forms.PaintEventHandler(Me._pnlInColor_Paint);
		 ' 
		 ' _numHigh
		 ' 
		 Me._numHigh.Location = New System.Drawing.Point(106, 65)
		 Me._numHigh.Maximum = New Decimal(New Integer() { 255, 0, 0, 0})
		 Me._numHigh.Name = "_numHigh"
		 Me._numHigh.Size = New System.Drawing.Size(153, 22)
		 Me._numHigh.TabIndex = 3
'		 Me._numHigh.Leave += New System.EventHandler(Me._num_Leave);
		 ' 
		 ' _numLow
		 ' 
		 Me._numLow.Location = New System.Drawing.Point(106, 28)
		 Me._numLow.Maximum = New Decimal(New Integer() { 255, 0, 0, 0})
		 Me._numLow.Name = "_numLow"
		 Me._numLow.Size = New System.Drawing.Size(153, 22)
		 Me._numLow.TabIndex = 1
'		 Me._numLow.Leave += New System.EventHandler(Me._num_Leave);
		 ' 
		 ' _lblChannel
		 ' 
		 Me._lblChannel.FlatStyle = System.Windows.Forms.FlatStyle.System
		 Me._lblChannel.Location = New System.Drawing.Point(19, 185)
		 Me._lblChannel.Name = "_lblChannel"
		 Me._lblChannel.Size = New System.Drawing.Size(75, 26)
		 Me._lblChannel.TabIndex = 10
		 Me._lblChannel.Text = "Blue Factor"
		 Me._lblChannel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		 ' 
		 ' _lblOutColor
		 ' 
		 Me._lblOutColor.FlatStyle = System.Windows.Forms.FlatStyle.System
		 Me._lblOutColor.Location = New System.Drawing.Point(19, 138)
		 Me._lblOutColor.Name = "_lblOutColor"
		 Me._lblOutColor.Size = New System.Drawing.Size(75, 26)
		 Me._lblOutColor.TabIndex = 7
		 Me._lblOutColor.Text = "Out Color"
		 Me._lblOutColor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		 ' 
		 ' _lblInColor
		 ' 
		 Me._lblInColor.FlatStyle = System.Windows.Forms.FlatStyle.System
		 Me._lblInColor.Location = New System.Drawing.Point(19, 102)
		 Me._lblInColor.Name = "_lblInColor"
		 Me._lblInColor.Size = New System.Drawing.Size(75, 26)
		 Me._lblInColor.TabIndex = 4
		 Me._lblInColor.Text = "In Color"
		 Me._lblInColor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		 ' 
		 ' _lblHigh
		 ' 
		 Me._lblHigh.FlatStyle = System.Windows.Forms.FlatStyle.System
		 Me._lblHigh.Location = New System.Drawing.Point(19, 65)
		 Me._lblHigh.Name = "_lblHigh"
		 Me._lblHigh.Size = New System.Drawing.Size(75, 26)
		 Me._lblHigh.TabIndex = 2
		 Me._lblHigh.Text = "High"
		 Me._lblHigh.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		 ' 
		 ' _lblLow
		 ' 
		 Me._lblLow.FlatStyle = System.Windows.Forms.FlatStyle.System
		 Me._lblLow.Location = New System.Drawing.Point(19, 28)
		 Me._lblLow.Name = "_lblLow"
		 Me._lblLow.Size = New System.Drawing.Size(75, 26)
		 Me._lblLow.TabIndex = 0
		 Me._lblLow.Text = "Low"
		 Me._lblLow.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		 ' 
		 ' IntensityDetectDialog
		 ' 
		 Me.AcceptButton = Me._btnOk
		 Me.AutoScaleDimensions = New System.Drawing.SizeF(8F, 16F)
		 Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		 Me.CancelButton = Me._btnCancel
		 Me.ClientSize = New System.Drawing.Size(422, 292)
		 Me.Controls.Add(Me._lblMsg)
		 Me.Controls.Add(Me._gbOptions)
		 Me.Controls.Add(Me._btnCancel)
		 Me.Controls.Add(Me._btnOk)
		 Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		 Me.MaximizeBox = False
		 Me.MinimizeBox = False
		 Me.Name = "IntensityDetectDialog"
		 Me.ShowInTaskbar = False
		 Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
		 Me.Text = "Intensity Detect"
'		 Me.Load += New System.EventHandler(Me.IntensityDetectDialog_Load);
		 Me._gbOptions.ResumeLayout(False)
		 CType(Me._numHigh, System.ComponentModel.ISupportInitialize).EndInit()
		 CType(Me._numLow, System.ComponentModel.ISupportInitialize).EndInit()
		 Me.ResumeLayout(False)

	  End Sub

	  #End Region

	  Private _btnCancel As System.Windows.Forms.Button
	  Private WithEvents _btnOk As System.Windows.Forms.Button
	  Private _lblMsg As System.Windows.Forms.Label
	  Private _gbOptions As System.Windows.Forms.GroupBox
	  Private WithEvents _numHigh As System.Windows.Forms.NumericUpDown
	  Private WithEvents _numLow As System.Windows.Forms.NumericUpDown
	  Private _lblInColor As System.Windows.Forms.Label
	  Private _lblHigh As System.Windows.Forms.Label
	  Private _lblLow As System.Windows.Forms.Label
	  Private WithEvents _btnOutColor As System.Windows.Forms.Button
	  Private WithEvents _btnInColor As System.Windows.Forms.Button
	  Private WithEvents _cbChannel As System.Windows.Forms.ComboBox
	  Private WithEvents _pnlOutColor As System.Windows.Forms.Panel
	  Private WithEvents _pnlInColor As System.Windows.Forms.Panel
	  Private _lblChannel As System.Windows.Forms.Label
	  Private _lblOutColor As System.Windows.Forms.Label
   End Class
End Namespace