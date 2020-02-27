Imports Microsoft.VisualBasic
Imports System
Namespace ImageProcessingDemo
   Public Partial Class AddNoiseDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AddNoiseDialog))
            Me._gbChannel = New System.Windows.Forms.GroupBox
            Me._rbMaster = New System.Windows.Forms.RadioButton
            Me._rbBlue = New System.Windows.Forms.RadioButton
            Me._rbGreen = New System.Windows.Forms.RadioButton
            Me._rbRed = New System.Windows.Forms.RadioButton
            Me._lblRange = New System.Windows.Forms.Label
            Me._btnCancel = New System.Windows.Forms.Button
            Me._btnOk = New System.Windows.Forms.Button
            Me._numRange = New System.Windows.Forms.NumericUpDown
            Me._gbChannel.SuspendLayout()
            CType(Me._numRange, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            '_gbChannel
            '
            Me._gbChannel.Controls.Add(Me._rbMaster)
            Me._gbChannel.Controls.Add(Me._rbBlue)
            Me._gbChannel.Controls.Add(Me._rbGreen)
            Me._gbChannel.Controls.Add(Me._rbRed)
            Me._gbChannel.Location = New System.Drawing.Point(10, 60)
            Me._gbChannel.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gbChannel.Name = "_gbChannel"
            Me._gbChannel.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gbChannel.Size = New System.Drawing.Size(109, 128)
            Me._gbChannel.TabIndex = 0
            Me._gbChannel.TabStop = False
            Me._gbChannel.Text = "Channel"
            '
            '_rbMaster
            '
            Me._rbMaster.AutoSize = True
            Me._rbMaster.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._rbMaster.Location = New System.Drawing.Point(21, 93)
            Me._rbMaster.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._rbMaster.Name = "_rbMaster"
            Me._rbMaster.Size = New System.Drawing.Size(63, 18)
            Me._rbMaster.TabIndex = 3
            Me._rbMaster.TabStop = True
            Me._rbMaster.Text = "Master"
            Me._rbMaster.UseVisualStyleBackColor = True
            '
            '_rbBlue
            '
            Me._rbBlue.AutoSize = True
            Me._rbBlue.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._rbBlue.Location = New System.Drawing.Point(21, 72)
            Me._rbBlue.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._rbBlue.Name = "_rbBlue"
            Me._rbBlue.Size = New System.Drawing.Size(52, 18)
            Me._rbBlue.TabIndex = 2
            Me._rbBlue.TabStop = True
            Me._rbBlue.Text = "Blue"
            Me._rbBlue.UseVisualStyleBackColor = True
            '
            '_rbGreen
            '
            Me._rbGreen.AutoSize = True
            Me._rbGreen.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._rbGreen.Location = New System.Drawing.Point(21, 50)
            Me._rbGreen.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._rbGreen.Name = "_rbGreen"
            Me._rbGreen.Size = New System.Drawing.Size(60, 18)
            Me._rbGreen.TabIndex = 1
            Me._rbGreen.TabStop = True
            Me._rbGreen.Text = "Green"
            Me._rbGreen.UseVisualStyleBackColor = True
            '
            '_rbRed
            '
            Me._rbRed.AutoSize = True
            Me._rbRed.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._rbRed.Location = New System.Drawing.Point(21, 28)
            Me._rbRed.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._rbRed.Name = "_rbRed"
            Me._rbRed.Size = New System.Drawing.Size(51, 18)
            Me._rbRed.TabIndex = 0
            Me._rbRed.TabStop = True
            Me._rbRed.Text = "Red"
            Me._rbRed.UseVisualStyleBackColor = True
            '
            '_lblRange
            '
            Me._lblRange.AutoSize = True
            Me._lblRange.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._lblRange.Location = New System.Drawing.Point(8, 18)
            Me._lblRange.Name = "_lblRange"
            Me._lblRange.Size = New System.Drawing.Size(39, 13)
            Me._lblRange.TabIndex = 1
            Me._lblRange.Text = "Range"
            '
            '_btnCancel
            '
            Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._btnCancel.Location = New System.Drawing.Point(171, 51)
            Me._btnCancel.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._btnCancel.Name = "_btnCancel"
            Me._btnCancel.Size = New System.Drawing.Size(69, 28)
            Me._btnCancel.TabIndex = 4
            Me._btnCancel.Text = "Cancel"
            Me._btnCancel.UseVisualStyleBackColor = True
            '
            '_btnOk
            '
            Me._btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._btnOk.Location = New System.Drawing.Point(171, 18)
            Me._btnOk.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._btnOk.Name = "_btnOk"
            Me._btnOk.Size = New System.Drawing.Size(69, 28)
            Me._btnOk.TabIndex = 3
            Me._btnOk.Text = "OK"
            Me._btnOk.UseVisualStyleBackColor = True
            '
            '_numRange
            '
            Me._numRange.Location = New System.Drawing.Point(53, 16)
            Me._numRange.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._numRange.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
            Me._numRange.Name = "_numRange"
            Me._numRange.Size = New System.Drawing.Size(66, 20)
            Me._numRange.TabIndex = 5
            '
            'AddNoiseDialog
            '
            Me.AcceptButton = Me._btnOk
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.CancelButton = Me._btnCancel
            Me.ClientSize = New System.Drawing.Size(250, 195)
            Me.Controls.Add(Me._numRange)
            Me.Controls.Add(Me._btnCancel)
            Me.Controls.Add(Me._btnOk)
            Me.Controls.Add(Me._lblRange)
            Me.Controls.Add(Me._gbChannel)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "AddNoiseDialog"
            Me.ShowIcon = False
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "Add Noise"
            Me._gbChannel.ResumeLayout(False)
            Me._gbChannel.PerformLayout()
            CType(Me._numRange, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub

	  #End Region

	  Private _gbChannel As System.Windows.Forms.GroupBox
	  Private _rbMaster As System.Windows.Forms.RadioButton
	  Private _rbBlue As System.Windows.Forms.RadioButton
	  Private _rbGreen As System.Windows.Forms.RadioButton
	  Private _rbRed As System.Windows.Forms.RadioButton
	  Private _lblRange As System.Windows.Forms.Label
	  Private WithEvents _btnCancel As System.Windows.Forms.Button
	  Private WithEvents _btnOk As System.Windows.Forms.Button
	  Private WithEvents _numRange As System.Windows.Forms.NumericUpDown
   End Class
End Namespace