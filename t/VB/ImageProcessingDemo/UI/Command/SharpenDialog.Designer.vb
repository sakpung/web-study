Imports Microsoft.VisualBasic
Imports System
Namespace ImageProcessingDemo
   Public Partial Class SharpenDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SharpenDialog))
            Me._gbSharpness = New System.Windows.Forms.GroupBox
            Me._numSharpness = New System.Windows.Forms.NumericUpDown
            Me._tbSharpness = New System.Windows.Forms.TrackBar
            Me._btnOk = New System.Windows.Forms.Button
            Me._btnCancel = New System.Windows.Forms.Button
            Me._gbSharpness.SuspendLayout()
            CType(Me._numSharpness, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me._tbSharpness, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            '_gbSharpness
            '
            Me._gbSharpness.Controls.Add(Me._numSharpness)
            Me._gbSharpness.Controls.Add(Me._tbSharpness)
            Me._gbSharpness.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._gbSharpness.Location = New System.Drawing.Point(10, 10)
            Me._gbSharpness.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gbSharpness.Name = "_gbSharpness"
            Me._gbSharpness.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gbSharpness.Size = New System.Drawing.Size(372, 72)
            Me._gbSharpness.TabIndex = 1
            Me._gbSharpness.TabStop = False
            Me._gbSharpness.Text = "Sharpness"
            '
            '_numSharpness
            '
            Me._numSharpness.Location = New System.Drawing.Point(5, 19)
            Me._numSharpness.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._numSharpness.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
            Me._numSharpness.Minimum = New Decimal(New Integer() {1000, 0, 0, -2147483648})
            Me._numSharpness.Name = "_numSharpness"
            Me._numSharpness.Size = New System.Drawing.Size(62, 20)
            Me._numSharpness.TabIndex = 2
            '
            '_tbSharpness
            '
            Me._tbSharpness.Location = New System.Drawing.Point(72, 18)
            Me._tbSharpness.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._tbSharpness.Maximum = 1000
            Me._tbSharpness.Minimum = -1000
            Me._tbSharpness.Name = "_tbSharpness"
            Me._tbSharpness.Size = New System.Drawing.Size(283, 45)
            Me._tbSharpness.TabIndex = 1
            Me._tbSharpness.TickStyle = System.Windows.Forms.TickStyle.None
            Me._tbSharpness.Value = 100
            '
            '_btnOk
            '
            Me._btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._btnOk.Location = New System.Drawing.Point(403, 18)
            Me._btnOk.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._btnOk.Name = "_btnOk"
            Me._btnOk.Size = New System.Drawing.Size(64, 21)
            Me._btnOk.TabIndex = 2
            Me._btnOk.Text = "OK"
            Me._btnOk.UseVisualStyleBackColor = True
            '
            '_btnCancel
            '
            Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._btnCancel.Location = New System.Drawing.Point(403, 44)
            Me._btnCancel.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._btnCancel.Name = "_btnCancel"
            Me._btnCancel.Size = New System.Drawing.Size(64, 21)
            Me._btnCancel.TabIndex = 3
            Me._btnCancel.Text = "Cancel"
            Me._btnCancel.UseVisualStyleBackColor = True
            '
            'SharpenDialog
            '
            Me.AcceptButton = Me._btnOk
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.CancelButton = Me._btnCancel
            Me.ClientSize = New System.Drawing.Size(478, 92)
            Me.Controls.Add(Me._btnCancel)
            Me.Controls.Add(Me._btnOk)
            Me.Controls.Add(Me._gbSharpness)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "SharpenDialog"
            Me.ShowIcon = False
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "Sharpen"
            Me._gbSharpness.ResumeLayout(False)
            Me._gbSharpness.PerformLayout()
            CType(Me._numSharpness, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me._tbSharpness, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

	  #End Region

	  Private _gbSharpness As System.Windows.Forms.GroupBox
	  Private WithEvents _btnOk As System.Windows.Forms.Button
	  Private WithEvents _btnCancel As System.Windows.Forms.Button
	  Public WithEvents _tbSharpness As System.Windows.Forms.TrackBar
	  Private WithEvents _numSharpness As System.Windows.Forms.NumericUpDown
   End Class
End Namespace