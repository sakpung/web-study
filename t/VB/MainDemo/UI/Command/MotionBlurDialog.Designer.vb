Imports Microsoft.VisualBasic
Imports System
Namespace MainDemo
   Public Partial Class MotionBlurDialog
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
		 Me._lblAngle = New System.Windows.Forms.Label()
		 Me._numDimension = New System.Windows.Forms.NumericUpDown()
		 Me._gbOptions = New System.Windows.Forms.GroupBox()
		 Me._cbUniDirectional = New System.Windows.Forms.CheckBox()
		 Me._numAngle = New System.Windows.Forms.NumericUpDown()
		 Me._lblDimension = New System.Windows.Forms.Label()
		 Me._btnCancel = New System.Windows.Forms.Button()
		 Me._btnOk = New System.Windows.Forms.Button()
		 CType(Me._numDimension, System.ComponentModel.ISupportInitialize).BeginInit()
		 Me._gbOptions.SuspendLayout()
		 CType(Me._numAngle, System.ComponentModel.ISupportInitialize).BeginInit()
		 Me.SuspendLayout()
		 ' 
		 ' _lblAngle
		 ' 
		 Me._lblAngle.FlatStyle = System.Windows.Forms.FlatStyle.System
		 Me._lblAngle.Location = New System.Drawing.Point(19, 55)
		 Me._lblAngle.Name = "_lblAngle"
		 Me._lblAngle.Size = New System.Drawing.Size(77, 27)
		 Me._lblAngle.TabIndex = 2
		 Me._lblAngle.Text = "Angle"
		 Me._lblAngle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		 ' 
		 ' _numDimension
		 ' 
		 Me._numDimension.Location = New System.Drawing.Point(115, 18)
		 Me._numDimension.Maximum = New Decimal(New Integer() { 255, 0, 0, 0})
		 Me._numDimension.Name = "_numDimension"
		 Me._numDimension.Size = New System.Drawing.Size(144, 22)
		 Me._numDimension.TabIndex = 1
		 Me._numDimension.Value = New Decimal(New Integer() { 1, 0, 0, 0})
'		 Me._numDimension.Leave += New System.EventHandler(Me._num_Leave);
		 ' 
		 ' _gbOptions
		 ' 
		 Me._gbOptions.Controls.Add(Me._cbUniDirectional)
		 Me._gbOptions.Controls.Add(Me._numAngle)
		 Me._gbOptions.Controls.Add(Me._lblAngle)
		 Me._gbOptions.Controls.Add(Me._numDimension)
		 Me._gbOptions.Controls.Add(Me._lblDimension)
		 Me._gbOptions.FlatStyle = System.Windows.Forms.FlatStyle.System
		 Me._gbOptions.Location = New System.Drawing.Point(12, 12)
		 Me._gbOptions.Name = "_gbOptions"
		 Me._gbOptions.Size = New System.Drawing.Size(278, 129)
		 Me._gbOptions.TabIndex = 0
		 Me._gbOptions.TabStop = False
		 ' 
		 ' _cbUniDirectional
		 ' 
		 Me._cbUniDirectional.FlatStyle = System.Windows.Forms.FlatStyle.System
		 Me._cbUniDirectional.Location = New System.Drawing.Point(19, 92)
		 Me._cbUniDirectional.Name = "_cbUniDirectional"
		 Me._cbUniDirectional.Size = New System.Drawing.Size(125, 28)
		 Me._cbUniDirectional.TabIndex = 4
		 Me._cbUniDirectional.Text = "Uni Directional"
		 ' 
		 ' _numAngle
		 ' 
		 Me._numAngle.Location = New System.Drawing.Point(115, 55)
		 Me._numAngle.Maximum = New Decimal(New Integer() { 360, 0, 0, 0})
		 Me._numAngle.Minimum = New Decimal(New Integer() { 1, 0, 0, 0})
		 Me._numAngle.Name = "_numAngle"
		 Me._numAngle.Size = New System.Drawing.Size(144, 22)
		 Me._numAngle.TabIndex = 3
		 Me._numAngle.Value = New Decimal(New Integer() { 1, 0, 0, 0})
'		 Me._numAngle.Leave += New System.EventHandler(Me._num_Leave);
		 ' 
		 ' _lblDimension
		 ' 
		 Me._lblDimension.FlatStyle = System.Windows.Forms.FlatStyle.System
		 Me._lblDimension.Location = New System.Drawing.Point(19, 18)
		 Me._lblDimension.Name = "_lblDimension"
		 Me._lblDimension.Size = New System.Drawing.Size(77, 27)
		 Me._lblDimension.TabIndex = 0
		 Me._lblDimension.Text = "Dimension"
		 Me._lblDimension.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
		 ' MotionBlurDialog
		 ' 
		 Me.AcceptButton = Me._btnOk
		 Me.AutoScaleDimensions = New System.Drawing.SizeF(8F, 16F)
		 Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		 Me.CancelButton = Me._btnCancel
		 Me.ClientSize = New System.Drawing.Size(424, 158)
		 Me.Controls.Add(Me._gbOptions)
		 Me.Controls.Add(Me._btnCancel)
		 Me.Controls.Add(Me._btnOk)
		 Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		 Me.MaximizeBox = False
		 Me.MinimizeBox = False
		 Me.Name = "MotionBlurDialog"
		 Me.ShowInTaskbar = False
		 Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
		 Me.Text = "Motion Blur"
'		 Me.Load += New System.EventHandler(Me.MotionBlurDialog_Load);
		 CType(Me._numDimension, System.ComponentModel.ISupportInitialize).EndInit()
		 Me._gbOptions.ResumeLayout(False)
		 CType(Me._numAngle, System.ComponentModel.ISupportInitialize).EndInit()
		 Me.ResumeLayout(False)

	  End Sub

	  #End Region

	  Private _lblAngle As System.Windows.Forms.Label
	  Private WithEvents _numDimension As System.Windows.Forms.NumericUpDown
	  Private _gbOptions As System.Windows.Forms.GroupBox
	  Private _cbUniDirectional As System.Windows.Forms.CheckBox
	  Private WithEvents _numAngle As System.Windows.Forms.NumericUpDown
	  Private _lblDimension As System.Windows.Forms.Label
	  Private _btnCancel As System.Windows.Forms.Button
	  Private WithEvents _btnOk As System.Windows.Forms.Button
   End Class
End Namespace