Imports Microsoft.VisualBasic
Imports System
Namespace MainDemo
   Public Partial Class GrayScaleFactorDialog
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
		 Me._numBlue = New System.Windows.Forms.NumericUpDown()
		 Me._numGreen = New System.Windows.Forms.NumericUpDown()
		 Me._numRed = New System.Windows.Forms.NumericUpDown()
		 Me._lblBlue = New System.Windows.Forms.Label()
		 Me._lblGreen = New System.Windows.Forms.Label()
		 Me._lblRed = New System.Windows.Forms.Label()
		 Me._lblMsg = New System.Windows.Forms.Label()
		 Me._gbOptions.SuspendLayout()
		 CType(Me._numBlue, System.ComponentModel.ISupportInitialize).BeginInit()
		 CType(Me._numGreen, System.ComponentModel.ISupportInitialize).BeginInit()
		 CType(Me._numRed, System.ComponentModel.ISupportInitialize).BeginInit()
		 Me.SuspendLayout()
		 ' 
		 ' _btnCancel
		 ' 
		 Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
		 Me._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
		 Me._btnCancel.Location = New System.Drawing.Point(278, 55)
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
		 Me._btnOk.Location = New System.Drawing.Point(278, 18)
		 Me._btnOk.Name = "_btnOk"
		 Me._btnOk.Size = New System.Drawing.Size(90, 27)
		 Me._btnOk.TabIndex = 2
		 Me._btnOk.Text = "OK"
		 Me._btnOk.UseVisualStyleBackColor = True
'		 Me._btnOk.Click += New System.EventHandler(Me._btnOk_Click);
		 ' 
		 ' _gbOptions
		 ' 
		 Me._gbOptions.Controls.Add(Me._numBlue)
		 Me._gbOptions.Controls.Add(Me._numGreen)
		 Me._gbOptions.Controls.Add(Me._numRed)
		 Me._gbOptions.Controls.Add(Me._lblBlue)
		 Me._gbOptions.Controls.Add(Me._lblGreen)
		 Me._gbOptions.Controls.Add(Me._lblRed)
		 Me._gbOptions.FlatStyle = System.Windows.Forms.FlatStyle.System
		 Me._gbOptions.Location = New System.Drawing.Point(10, 9)
		 Me._gbOptions.Name = "_gbOptions"
		 Me._gbOptions.Size = New System.Drawing.Size(240, 139)
		 Me._gbOptions.TabIndex = 0
		 Me._gbOptions.TabStop = False
		 ' 
		 ' _numBlue
		 ' 
		 Me._numBlue.Location = New System.Drawing.Point(125, 102)
		 Me._numBlue.Maximum = New Decimal(New Integer() { 1000, 0, 0, 0})
		 Me._numBlue.Name = "_numBlue"
		 Me._numBlue.Size = New System.Drawing.Size(96, 22)
		 Me._numBlue.TabIndex = 5
'		 Me._numBlue.Leave += New System.EventHandler(Me._num_Leave);
		 ' 
		 ' _numGreen
		 ' 
		 Me._numGreen.Location = New System.Drawing.Point(125, 65)
		 Me._numGreen.Maximum = New Decimal(New Integer() { 1000, 0, 0, 0})
		 Me._numGreen.Name = "_numGreen"
		 Me._numGreen.Size = New System.Drawing.Size(96, 22)
		 Me._numGreen.TabIndex = 3
'		 Me._numGreen.Leave += New System.EventHandler(Me._num_Leave);
		 ' 
		 ' _numRed
		 ' 
		 Me._numRed.Location = New System.Drawing.Point(125, 28)
		 Me._numRed.Maximum = New Decimal(New Integer() { 1000, 0, 0, 0})
		 Me._numRed.Name = "_numRed"
		 Me._numRed.Size = New System.Drawing.Size(96, 22)
		 Me._numRed.TabIndex = 1
'		 Me._numRed.Leave += New System.EventHandler(Me._num_Leave);
		 ' 
		 ' _lblBlue
		 ' 
		 Me._lblBlue.FlatStyle = System.Windows.Forms.FlatStyle.System
		 Me._lblBlue.Location = New System.Drawing.Point(19, 102)
		 Me._lblBlue.Name = "_lblBlue"
		 Me._lblBlue.Size = New System.Drawing.Size(96, 26)
		 Me._lblBlue.TabIndex = 4
		 Me._lblBlue.Text = "Blue Factor"
		 Me._lblBlue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		 ' 
		 ' _lblGreen
		 ' 
		 Me._lblGreen.FlatStyle = System.Windows.Forms.FlatStyle.System
		 Me._lblGreen.Location = New System.Drawing.Point(19, 65)
		 Me._lblGreen.Name = "_lblGreen"
		 Me._lblGreen.Size = New System.Drawing.Size(96, 26)
		 Me._lblGreen.TabIndex = 2
		 Me._lblGreen.Text = "Green Factor"
		 Me._lblGreen.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		 ' 
		 ' _lblRed
		 ' 
		 Me._lblRed.FlatStyle = System.Windows.Forms.FlatStyle.System
		 Me._lblRed.Location = New System.Drawing.Point(19, 28)
		 Me._lblRed.Name = "_lblRed"
		 Me._lblRed.Size = New System.Drawing.Size(96, 26)
		 Me._lblRed.TabIndex = 0
		 Me._lblRed.Text = "Red Factor"
		 Me._lblRed.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		 ' 
		 ' _lblMsg
		 ' 
		 Me._lblMsg.FlatStyle = System.Windows.Forms.FlatStyle.System
		 Me._lblMsg.Location = New System.Drawing.Point(10, 166)
		 Me._lblMsg.Name = "_lblMsg"
		 Me._lblMsg.Size = New System.Drawing.Size(336, 40)
		 Me._lblMsg.TabIndex = 1
		 Me._lblMsg.Text = "The sum of the Red, Green, and Blue values must be less than or equal to 1000."
		 ' 
		 ' GrayScaleFactorDialog
		 ' 
		 Me.AcceptButton = Me._btnOk
		 Me.AutoScaleDimensions = New System.Drawing.SizeF(8F, 16F)
		 Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		 Me.CancelButton = Me._btnCancel
		 Me.ClientSize = New System.Drawing.Size(374, 218)
		 Me.Controls.Add(Me._lblMsg)
		 Me.Controls.Add(Me._btnCancel)
		 Me.Controls.Add(Me._btnOk)
		 Me.Controls.Add(Me._gbOptions)
		 Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		 Me.MaximizeBox = False
		 Me.MinimizeBox = False
		 Me.Name = "GrayScaleFactorDialog"
		 Me.ShowInTaskbar = False
		 Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
		 Me.Text = "Gray Scale Factor"
		 Me._gbOptions.ResumeLayout(False)
		 CType(Me._numBlue, System.ComponentModel.ISupportInitialize).EndInit()
		 CType(Me._numGreen, System.ComponentModel.ISupportInitialize).EndInit()
		 CType(Me._numRed, System.ComponentModel.ISupportInitialize).EndInit()
		 Me.ResumeLayout(False)

	  End Sub

	  #End Region

	  Private _btnCancel As System.Windows.Forms.Button
	  Private WithEvents _btnOk As System.Windows.Forms.Button
	  Private _gbOptions As System.Windows.Forms.GroupBox
	  Private _lblRed As System.Windows.Forms.Label
	  Private _lblBlue As System.Windows.Forms.Label
	  Private _lblGreen As System.Windows.Forms.Label
	  Private _lblMsg As System.Windows.Forms.Label
	  Private WithEvents _numRed As System.Windows.Forms.NumericUpDown
	  Private WithEvents _numBlue As System.Windows.Forms.NumericUpDown
	  Private WithEvents _numGreen As System.Windows.Forms.NumericUpDown
   End Class
End Namespace