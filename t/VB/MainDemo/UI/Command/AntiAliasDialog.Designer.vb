Imports Microsoft.VisualBasic
Imports System
Namespace MainDemo
   Public Partial Class AntiAliasDialog
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
		 Me._cbFilter = New System.Windows.Forms.ComboBox()
		 Me._numDimension = New System.Windows.Forms.NumericUpDown()
		 Me._numThreshold = New System.Windows.Forms.NumericUpDown()
		 Me._lblFilter = New System.Windows.Forms.Label()
		 Me._lblDimension = New System.Windows.Forms.Label()
		 Me._lblThreshold = New System.Windows.Forms.Label()
		 Me._btnCancel = New System.Windows.Forms.Button()
		 Me._btnOk = New System.Windows.Forms.Button()
		 Me._gbOptions.SuspendLayout()
		 CType(Me._numDimension, System.ComponentModel.ISupportInitialize).BeginInit()
		 CType(Me._numThreshold, System.ComponentModel.ISupportInitialize).BeginInit()
		 Me.SuspendLayout()
		 ' 
		 ' _gbOptions
		 ' 
		 Me._gbOptions.Controls.Add(Me._cbFilter)
		 Me._gbOptions.Controls.Add(Me._numDimension)
		 Me._gbOptions.Controls.Add(Me._numThreshold)
		 Me._gbOptions.Controls.Add(Me._lblFilter)
		 Me._gbOptions.Controls.Add(Me._lblDimension)
		 Me._gbOptions.Controls.Add(Me._lblThreshold)
		 Me._gbOptions.FlatStyle = System.Windows.Forms.FlatStyle.System
		 Me._gbOptions.Location = New System.Drawing.Point(10, 9)
		 Me._gbOptions.Name = "_gbOptions"
		 Me._gbOptions.Size = New System.Drawing.Size(278, 129)
		 Me._gbOptions.TabIndex = 0
		 Me._gbOptions.TabStop = False
		 ' 
		 ' _cbFilter
		 ' 
		 Me._cbFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		 Me._cbFilter.FormattingEnabled = True
		 Me._cbFilter.Location = New System.Drawing.Point(115, 92)
		 Me._cbFilter.Name = "_cbFilter"
		 Me._cbFilter.Size = New System.Drawing.Size(145, 24)
		 Me._cbFilter.TabIndex = 5
		 ' 
		 ' _numDimension
		 ' 
		 Me._numDimension.Location = New System.Drawing.Point(115, 60)
		 Me._numDimension.Minimum = New Decimal(New Integer() { 2, 0, 0, 0})
		 Me._numDimension.Name = "_numDimension"
		 Me._numDimension.Size = New System.Drawing.Size(145, 22)
		 Me._numDimension.TabIndex = 3
		 Me._numDimension.Value = New Decimal(New Integer() { 2, 0, 0, 0})
'		 Me._numDimension.Leave += New System.EventHandler(Me._num_Leave);
		 ' 
		 ' _numThreshold
		 ' 
		 Me._numThreshold.Location = New System.Drawing.Point(115, 22)
		 Me._numThreshold.Maximum = New Decimal(New Integer() { 65535, 0, 0, 0})
		 Me._numThreshold.Name = "_numThreshold"
		 Me._numThreshold.Size = New System.Drawing.Size(145, 22)
		 Me._numThreshold.TabIndex = 1
		 Me._numThreshold.Value = New Decimal(New Integer() { 1, 0, 0, 0})
'		 Me._numThreshold.Leave += New System.EventHandler(Me._num_Leave);
		 ' 
		 ' _lblFilter
		 ' 
		 Me._lblFilter.AutoSize = True
		 Me._lblFilter.FlatStyle = System.Windows.Forms.FlatStyle.System
		 Me._lblFilter.Location = New System.Drawing.Point(17, 99)
		 Me._lblFilter.Name = "_lblFilter"
		 Me._lblFilter.Size = New System.Drawing.Size(39, 17)
		 Me._lblFilter.TabIndex = 4
		 Me._lblFilter.Text = "Filter"
		 ' 
		 ' _lblDimension
		 ' 
		 Me._lblDimension.AutoSize = True
		 Me._lblDimension.FlatStyle = System.Windows.Forms.FlatStyle.System
		 Me._lblDimension.Location = New System.Drawing.Point(17, 60)
		 Me._lblDimension.Name = "_lblDimension"
		 Me._lblDimension.Size = New System.Drawing.Size(74, 17)
		 Me._lblDimension.TabIndex = 2
		 Me._lblDimension.Text = "Dimension"
		 ' 
		 ' _lblThreshold
		 ' 
		 Me._lblThreshold.AutoSize = True
		 Me._lblThreshold.FlatStyle = System.Windows.Forms.FlatStyle.System
		 Me._lblThreshold.Location = New System.Drawing.Point(17, 22)
		 Me._lblThreshold.Name = "_lblThreshold"
		 Me._lblThreshold.Size = New System.Drawing.Size(72, 17)
		 Me._lblThreshold.TabIndex = 0
		 Me._lblThreshold.Text = "Threshold"
		 ' 
		 ' _btnCancel
		 ' 
		 Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
		 Me._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
		 Me._btnCancel.Location = New System.Drawing.Point(311, 49)
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
		 Me._btnOk.Location = New System.Drawing.Point(311, 12)
		 Me._btnOk.Name = "_btnOk"
		 Me._btnOk.Size = New System.Drawing.Size(90, 27)
		 Me._btnOk.TabIndex = 1
		 Me._btnOk.Text = "OK"
		 Me._btnOk.UseVisualStyleBackColor = True
'		 Me._btnOk.Click += New System.EventHandler(Me._btnOk_Click);
		 ' 
		 ' AntiAliasDialog
		 ' 
		 Me.AcceptButton = Me._btnOk
		 Me.AutoScaleDimensions = New System.Drawing.SizeF(8F, 16F)
		 Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		 Me.CancelButton = Me._btnCancel
		 Me.ClientSize = New System.Drawing.Size(416, 156)
		 Me.Controls.Add(Me._btnCancel)
		 Me.Controls.Add(Me._gbOptions)
		 Me.Controls.Add(Me._btnOk)
		 Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		 Me.MaximizeBox = False
		 Me.MinimizeBox = False
		 Me.Name = "AntiAliasDialog"
		 Me.ShowInTaskbar = False
		 Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
		 Me.Text = "Anti Alias"
'		 Me.Load += New System.EventHandler(Me.AntiAliasDialog_Load);
		 Me._gbOptions.ResumeLayout(False)
		 Me._gbOptions.PerformLayout()
		 CType(Me._numDimension, System.ComponentModel.ISupportInitialize).EndInit()
		 CType(Me._numThreshold, System.ComponentModel.ISupportInitialize).EndInit()
		 Me.ResumeLayout(False)

	  End Sub

	  #End Region

	  Private _gbOptions As System.Windows.Forms.GroupBox
	  Private _cbFilter As System.Windows.Forms.ComboBox
	  Private WithEvents _numDimension As System.Windows.Forms.NumericUpDown
	  Private WithEvents _numThreshold As System.Windows.Forms.NumericUpDown
	  Private _lblFilter As System.Windows.Forms.Label
	  Private _lblDimension As System.Windows.Forms.Label
	  Private _lblThreshold As System.Windows.Forms.Label
	  Private _btnCancel As System.Windows.Forms.Button
	  Private WithEvents _btnOk As System.Windows.Forms.Button
   End Class
End Namespace