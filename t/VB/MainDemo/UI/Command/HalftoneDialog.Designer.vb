Imports Microsoft.VisualBasic
Imports System
Namespace MainDemo
   Public Partial Class HalftoneDialog
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
		 Me._cbType = New System.Windows.Forms.ComboBox()
		 Me._numDimension = New System.Windows.Forms.NumericUpDown()
		 Me._numAngle = New System.Windows.Forms.NumericUpDown()
		 Me._lblDimension = New System.Windows.Forms.Label()
		 Me._lblAngle = New System.Windows.Forms.Label()
		 Me._lblType = New System.Windows.Forms.Label()
		 Me._gbOptions.SuspendLayout()
		 CType(Me._numDimension, System.ComponentModel.ISupportInitialize).BeginInit()
		 CType(Me._numAngle, System.ComponentModel.ISupportInitialize).BeginInit()
		 Me.SuspendLayout()
		 ' 
		 ' _btnCancel
		 ' 
		 Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
		 Me._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
		 Me._btnCancel.Location = New System.Drawing.Point(346, 55)
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
		 Me._btnOk.Location = New System.Drawing.Point(346, 18)
		 Me._btnOk.Name = "_btnOk"
		 Me._btnOk.Size = New System.Drawing.Size(90, 27)
		 Me._btnOk.TabIndex = 1
		 Me._btnOk.Text = "OK"
		 Me._btnOk.UseVisualStyleBackColor = True
'		 Me._btnOk.Click += New System.EventHandler(Me._btnOk_Click);
		 ' 
		 ' _gbOptions
		 ' 
		 Me._gbOptions.Controls.Add(Me._cbType)
		 Me._gbOptions.Controls.Add(Me._numDimension)
		 Me._gbOptions.Controls.Add(Me._numAngle)
		 Me._gbOptions.Controls.Add(Me._lblDimension)
		 Me._gbOptions.Controls.Add(Me._lblAngle)
		 Me._gbOptions.Controls.Add(Me._lblType)
		 Me._gbOptions.FlatStyle = System.Windows.Forms.FlatStyle.System
		 Me._gbOptions.Location = New System.Drawing.Point(10, 9)
		 Me._gbOptions.Name = "_gbOptions"
		 Me._gbOptions.Size = New System.Drawing.Size(316, 139)
		 Me._gbOptions.TabIndex = 0
		 Me._gbOptions.TabStop = False
		 ' 
		 ' _cbType
		 ' 
		 Me._cbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		 Me._cbType.FormattingEnabled = True
		 Me._cbType.Location = New System.Drawing.Point(106, 28)
		 Me._cbType.Name = "_cbType"
		 Me._cbType.Size = New System.Drawing.Size(192, 24)
		 Me._cbType.TabIndex = 1
'		 Me._cbType.SelectedIndexChanged += New System.EventHandler(Me._cbType_SelectedIndexChanged);
		 ' 
		 ' _numDimension
		 ' 
		 Me._numDimension.Location = New System.Drawing.Point(106, 102)
		 Me._numDimension.Minimum = New Decimal(New Integer() { 2, 0, 0, 0})
		 Me._numDimension.Name = "_numDimension"
		 Me._numDimension.Size = New System.Drawing.Size(105, 22)
		 Me._numDimension.TabIndex = 5
		 Me._numDimension.Value = New Decimal(New Integer() { 2, 0, 0, 0})
'		 Me._numDimension.Leave += New System.EventHandler(Me._num_Leave);
		 ' 
		 ' _numAngle
		 ' 
		 Me._numAngle.Location = New System.Drawing.Point(106, 65)
		 Me._numAngle.Maximum = New Decimal(New Integer() { 360, 0, 0, 0})
		 Me._numAngle.Minimum = New Decimal(New Integer() { 360, 0, 0, -2147483648})
		 Me._numAngle.Name = "_numAngle"
		 Me._numAngle.Size = New System.Drawing.Size(105, 22)
		 Me._numAngle.TabIndex = 3
'		 Me._numAngle.Leave += New System.EventHandler(Me._num_Leave);
		 ' 
		 ' _lblDimension
		 ' 
		 Me._lblDimension.FlatStyle = System.Windows.Forms.FlatStyle.System
		 Me._lblDimension.Location = New System.Drawing.Point(19, 102)
		 Me._lblDimension.Name = "_lblDimension"
		 Me._lblDimension.Size = New System.Drawing.Size(77, 26)
		 Me._lblDimension.TabIndex = 4
		 Me._lblDimension.Text = "Dimension"
		 Me._lblDimension.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		 ' 
		 ' _lblAngle
		 ' 
		 Me._lblAngle.FlatStyle = System.Windows.Forms.FlatStyle.System
		 Me._lblAngle.Location = New System.Drawing.Point(19, 65)
		 Me._lblAngle.Name = "_lblAngle"
		 Me._lblAngle.Size = New System.Drawing.Size(77, 26)
		 Me._lblAngle.TabIndex = 2
		 Me._lblAngle.Text = "Angle"
		 Me._lblAngle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		 ' 
		 ' _lblType
		 ' 
		 Me._lblType.FlatStyle = System.Windows.Forms.FlatStyle.System
		 Me._lblType.Location = New System.Drawing.Point(19, 28)
		 Me._lblType.Name = "_lblType"
		 Me._lblType.Size = New System.Drawing.Size(77, 26)
		 Me._lblType.TabIndex = 0
		 Me._lblType.Text = "Type"
		 Me._lblType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		 ' 
		 ' HalftoneDialog
		 ' 
		 Me.AcceptButton = Me._btnOk
		 Me.AutoScaleDimensions = New System.Drawing.SizeF(8F, 16F)
		 Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		 Me.CancelButton = Me._btnCancel
		 Me.ClientSize = New System.Drawing.Size(452, 166)
		 Me.Controls.Add(Me._btnCancel)
		 Me.Controls.Add(Me._btnOk)
		 Me.Controls.Add(Me._gbOptions)
		 Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		 Me.MaximizeBox = False
		 Me.MinimizeBox = False
		 Me.Name = "HalftoneDialog"
		 Me.ShowInTaskbar = False
		 Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
		 Me.Text = "Halftone"
'		 Me.Load += New System.EventHandler(Me.HalftoneDialog_Load);
		 Me._gbOptions.ResumeLayout(False)
		 CType(Me._numDimension, System.ComponentModel.ISupportInitialize).EndInit()
		 CType(Me._numAngle, System.ComponentModel.ISupportInitialize).EndInit()
		 Me.ResumeLayout(False)

	  End Sub

	  #End Region

	  Private _btnCancel As System.Windows.Forms.Button
	  Private WithEvents _btnOk As System.Windows.Forms.Button
	  Private _gbOptions As System.Windows.Forms.GroupBox
	  Private WithEvents _numDimension As System.Windows.Forms.NumericUpDown
	  Private WithEvents _numAngle As System.Windows.Forms.NumericUpDown
	  Private _lblDimension As System.Windows.Forms.Label
	  Private _lblAngle As System.Windows.Forms.Label
	  Private _lblType As System.Windows.Forms.Label
	  Private WithEvents _cbType As System.Windows.Forms.ComboBox

   End Class
End Namespace