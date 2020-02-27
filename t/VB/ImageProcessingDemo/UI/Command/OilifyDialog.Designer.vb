Imports Microsoft.VisualBasic
Imports System
Namespace ImageProcessingDemo
   Public Partial Class OilifyDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(OilifyDialog))
            Me._txbDimension = New System.Windows.Forms.TextBox
            Me._gbDimension = New System.Windows.Forms.GroupBox
            Me._tbDimension = New System.Windows.Forms.TrackBar
            Me._btnOk = New System.Windows.Forms.Button
            Me._btnCancel = New System.Windows.Forms.Button
            Me._gbDimension.SuspendLayout()
            CType(Me._tbDimension, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            '_txbDimension
            '
            Me._txbDimension.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me._txbDimension.Location = New System.Drawing.Point(15, 26)
            Me._txbDimension.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._txbDimension.Name = "_txbDimension"
            Me._txbDimension.Size = New System.Drawing.Size(59, 20)
            Me._txbDimension.TabIndex = 0
            '
            '_gbDimension
            '
            Me._gbDimension.Controls.Add(Me._tbDimension)
            Me._gbDimension.Controls.Add(Me._txbDimension)
            Me._gbDimension.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._gbDimension.Location = New System.Drawing.Point(10, 10)
            Me._gbDimension.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gbDimension.Name = "_gbDimension"
            Me._gbDimension.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gbDimension.Size = New System.Drawing.Size(372, 66)
            Me._gbDimension.TabIndex = 1
            Me._gbDimension.TabStop = False
            Me._gbDimension.Text = "Dimension"
            '
            '_tbDimension
            '
            Me._tbDimension.Location = New System.Drawing.Point(101, 18)
            Me._tbDimension.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._tbDimension.Maximum = 255
            Me._tbDimension.Minimum = 1
            Me._tbDimension.Name = "_tbDimension"
            Me._tbDimension.Size = New System.Drawing.Size(266, 45)
            Me._tbDimension.TabIndex = 1
            Me._tbDimension.TickStyle = System.Windows.Forms.TickStyle.None
            Me._tbDimension.Value = 1
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
            'OilifyDialog
            '
            Me.AcceptButton = Me._btnOk
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.CancelButton = Me._btnCancel
            Me.ClientSize = New System.Drawing.Size(478, 92)
            Me.Controls.Add(Me._btnCancel)
            Me.Controls.Add(Me._btnOk)
            Me.Controls.Add(Me._gbDimension)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "OilifyDialog"
            Me.ShowIcon = False
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "Oilify"
            Me._gbDimension.ResumeLayout(False)
            Me._gbDimension.PerformLayout()
            CType(Me._tbDimension, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

	  #End Region

	  Private WithEvents _txbDimension As System.Windows.Forms.TextBox
	  Private _gbDimension As System.Windows.Forms.GroupBox
	  Public WithEvents _tbDimension As System.Windows.Forms.TrackBar
	  Private WithEvents _btnOk As System.Windows.Forms.Button
	  Private WithEvents _btnCancel As System.Windows.Forms.Button
   End Class
End Namespace