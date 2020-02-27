Imports Microsoft.VisualBasic
Imports System
Namespace MainDemo
   Public Partial Class ContourDialog
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
         Me._btnCancel = New System.Windows.Forms.Button
         Me._btnOk = New System.Windows.Forms.Button
         Me._gbOptions = New System.Windows.Forms.GroupBox
         Me._cbType = New System.Windows.Forms.ComboBox
         Me._numMaximumError = New System.Windows.Forms.NumericUpDown
         Me._numDeltaDirection = New System.Windows.Forms.NumericUpDown
         Me._numThreshold = New System.Windows.Forms.NumericUpDown
         Me._lblType = New System.Windows.Forms.Label
         Me._lblMaximumError = New System.Windows.Forms.Label
         Me._lblDeltaDirection = New System.Windows.Forms.Label
         Me._lblThreshold = New System.Windows.Forms.Label
         Me._gbOptions.SuspendLayout()
         CType(Me._numMaximumError, System.ComponentModel.ISupportInitialize).BeginInit()
         CType(Me._numDeltaDirection, System.ComponentModel.ISupportInitialize).BeginInit()
         CType(Me._numThreshold, System.ComponentModel.ISupportInitialize).BeginInit()
         Me.SuspendLayout()
         '
         '_btnCancel
         '
         Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
         Me._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._btnCancel.Location = New System.Drawing.Point(274, 45)
         Me._btnCancel.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
         Me._btnCancel.Name = "_btnCancel"
         Me._btnCancel.Size = New System.Drawing.Size(68, 22)
         Me._btnCancel.TabIndex = 2
         Me._btnCancel.Text = "Cancel"
         Me._btnCancel.UseVisualStyleBackColor = True
         '
         '_btnOk
         '
         Me._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK
         Me._btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._btnOk.Location = New System.Drawing.Point(274, 15)
         Me._btnOk.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
         Me._btnOk.Name = "_btnOk"
         Me._btnOk.Size = New System.Drawing.Size(68, 22)
         Me._btnOk.TabIndex = 1
         Me._btnOk.Text = "OK"
         Me._btnOk.UseVisualStyleBackColor = True
         '
         '_gbOptions
         '
         Me._gbOptions.Controls.Add(Me._cbType)
         Me._gbOptions.Controls.Add(Me._numMaximumError)
         Me._gbOptions.Controls.Add(Me._numDeltaDirection)
         Me._gbOptions.Controls.Add(Me._numThreshold)
         Me._gbOptions.Controls.Add(Me._lblType)
         Me._gbOptions.Controls.Add(Me._lblMaximumError)
         Me._gbOptions.Controls.Add(Me._lblDeltaDirection)
         Me._gbOptions.Controls.Add(Me._lblThreshold)
         Me._gbOptions.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._gbOptions.Location = New System.Drawing.Point(8, 7)
         Me._gbOptions.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
         Me._gbOptions.Name = "_gbOptions"
         Me._gbOptions.Padding = New System.Windows.Forms.Padding(2, 2, 2, 2)
         Me._gbOptions.Size = New System.Drawing.Size(244, 143)
         Me._gbOptions.TabIndex = 0
         Me._gbOptions.TabStop = False
         '
         '_cbType
         '
         Me._cbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
         Me._cbType.FormattingEnabled = True
         Me._cbType.Location = New System.Drawing.Point(100, 105)
         Me._cbType.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
         Me._cbType.Name = "_cbType"
         Me._cbType.Size = New System.Drawing.Size(131, 21)
         Me._cbType.TabIndex = 7
         '
         '_numMaximumError
         '
         Me._numMaximumError.Location = New System.Drawing.Point(100, 75)
         Me._numMaximumError.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
         Me._numMaximumError.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
         Me._numMaximumError.Name = "_numMaximumError"
         Me._numMaximumError.Size = New System.Drawing.Size(130, 20)
         Me._numMaximumError.TabIndex = 5
         Me._numMaximumError.Value = New Decimal(New Integer() {1, 0, 0, 0})
         '
         '_numDeltaDirection
         '
         Me._numDeltaDirection.Location = New System.Drawing.Point(100, 45)
         Me._numDeltaDirection.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
         Me._numDeltaDirection.Maximum = New Decimal(New Integer() {64, 0, 0, 0})
         Me._numDeltaDirection.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
         Me._numDeltaDirection.Name = "_numDeltaDirection"
         Me._numDeltaDirection.Size = New System.Drawing.Size(130, 20)
         Me._numDeltaDirection.TabIndex = 3
         Me._numDeltaDirection.Value = New Decimal(New Integer() {1, 0, 0, 0})
         '
         '_numThreshold
         '
         Me._numThreshold.Location = New System.Drawing.Point(100, 15)
         Me._numThreshold.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
         Me._numThreshold.Maximum = New Decimal(New Integer() {254, 0, 0, 0})
         Me._numThreshold.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
         Me._numThreshold.Name = "_numThreshold"
         Me._numThreshold.Size = New System.Drawing.Size(130, 20)
         Me._numThreshold.TabIndex = 1
         Me._numThreshold.Value = New Decimal(New Integer() {1, 0, 0, 0})
         '
         '_lblType
         '
         Me._lblType.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._lblType.Location = New System.Drawing.Point(14, 105)
         Me._lblType.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
         Me._lblType.Name = "_lblType"
         Me._lblType.Size = New System.Drawing.Size(80, 22)
         Me._lblType.TabIndex = 6
         Me._lblType.Text = "Type"
         Me._lblType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
         '
         '_lblMaximumError
         '
         Me._lblMaximumError.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._lblMaximumError.Location = New System.Drawing.Point(14, 75)
         Me._lblMaximumError.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
         Me._lblMaximumError.Name = "_lblMaximumError"
         Me._lblMaximumError.Size = New System.Drawing.Size(80, 22)
         Me._lblMaximumError.TabIndex = 4
         Me._lblMaximumError.Text = "Maximum Error"
         Me._lblMaximumError.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
         '
         '_lblDeltaDirection
         '
         Me._lblDeltaDirection.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._lblDeltaDirection.Location = New System.Drawing.Point(14, 45)
         Me._lblDeltaDirection.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
         Me._lblDeltaDirection.Name = "_lblDeltaDirection"
         Me._lblDeltaDirection.Size = New System.Drawing.Size(80, 22)
         Me._lblDeltaDirection.TabIndex = 2
         Me._lblDeltaDirection.Text = "Delta Direction"
         Me._lblDeltaDirection.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
         '
         '_lblThreshold
         '
         Me._lblThreshold.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._lblThreshold.Location = New System.Drawing.Point(14, 15)
         Me._lblThreshold.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
         Me._lblThreshold.Name = "_lblThreshold"
         Me._lblThreshold.Size = New System.Drawing.Size(80, 22)
         Me._lblThreshold.TabIndex = 0
         Me._lblThreshold.Text = "Threshold"
         Me._lblThreshold.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
         '
         'ContourDialog
         '
         Me.AcceptButton = Me._btnOk
         Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.CancelButton = Me._btnCancel
         Me.ClientSize = New System.Drawing.Size(352, 163)
         Me.Controls.Add(Me._gbOptions)
         Me.Controls.Add(Me._btnCancel)
         Me.Controls.Add(Me._btnOk)
         Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
         Me.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
         Me.MaximizeBox = False
         Me.MinimizeBox = False
         Me.Name = "ContourDialog"
         Me.ShowInTaskbar = False
         Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
         Me.Text = "Contour"
         Me._gbOptions.ResumeLayout(False)
         CType(Me._numMaximumError, System.ComponentModel.ISupportInitialize).EndInit()
         CType(Me._numDeltaDirection, System.ComponentModel.ISupportInitialize).EndInit()
         CType(Me._numThreshold, System.ComponentModel.ISupportInitialize).EndInit()
         Me.ResumeLayout(False)

      End Sub

	  #End Region

	  Private _btnCancel As System.Windows.Forms.Button
	  Private WithEvents _btnOk As System.Windows.Forms.Button
	  Private _gbOptions As System.Windows.Forms.GroupBox
	  Private _lblThreshold As System.Windows.Forms.Label
	  Private _lblType As System.Windows.Forms.Label
	  Private _lblMaximumError As System.Windows.Forms.Label
	  Private _lblDeltaDirection As System.Windows.Forms.Label
	  Private WithEvents _numMaximumError As System.Windows.Forms.NumericUpDown
	  Private WithEvents _numDeltaDirection As System.Windows.Forms.NumericUpDown
	  Private WithEvents _numThreshold As System.Windows.Forms.NumericUpDown
	  Private WithEvents _cbType As System.Windows.Forms.ComboBox
   End Class
End Namespace