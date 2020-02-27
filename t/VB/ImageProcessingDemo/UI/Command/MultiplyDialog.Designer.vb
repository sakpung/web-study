Imports Microsoft.VisualBasic
Imports System
Namespace ImageProcessingDemo
   Public Partial Class MultiplyDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MultiplyDialog))
            Me._gbParameters = New System.Windows.Forms.GroupBox
            Me._lblFactor = New System.Windows.Forms.Label
            Me._tbFactor = New System.Windows.Forms.TrackBar
            Me._numFactor = New System.Windows.Forms.NumericUpDown
            Me._btnCancel = New System.Windows.Forms.Button
            Me._btnOk = New System.Windows.Forms.Button
            Me._gbParameters.SuspendLayout()
            CType(Me._tbFactor, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me._numFactor, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            '_gbParameters
            '
            Me._gbParameters.Controls.Add(Me._lblFactor)
            Me._gbParameters.Controls.Add(Me._tbFactor)
            Me._gbParameters.Controls.Add(Me._numFactor)
            Me._gbParameters.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._gbParameters.Location = New System.Drawing.Point(10, 10)
            Me._gbParameters.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gbParameters.Name = "_gbParameters"
            Me._gbParameters.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gbParameters.Size = New System.Drawing.Size(423, 79)
            Me._gbParameters.TabIndex = 0
            Me._gbParameters.TabStop = False
            '
            '_lblFactor
            '
            Me._lblFactor.AutoSize = True
            Me._lblFactor.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._lblFactor.Location = New System.Drawing.Point(14, 32)
            Me._lblFactor.Name = "_lblFactor"
            Me._lblFactor.Size = New System.Drawing.Size(37, 13)
            Me._lblFactor.TabIndex = 2
            Me._lblFactor.Text = "Factor"
            '
            '_tbFactor
            '
            Me._tbFactor.Location = New System.Drawing.Point(55, 28)
            Me._tbFactor.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._tbFactor.Maximum = 255
            Me._tbFactor.Name = "_tbFactor"
            Me._tbFactor.Size = New System.Drawing.Size(296, 45)
            Me._tbFactor.TabIndex = 1
            Me._tbFactor.TickStyle = System.Windows.Forms.TickStyle.None
            '
            '_numFactor
            '
            Me._numFactor.Location = New System.Drawing.Point(356, 32)
            Me._numFactor.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._numFactor.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
            Me._numFactor.Name = "_numFactor"
            Me._numFactor.Size = New System.Drawing.Size(63, 20)
            Me._numFactor.TabIndex = 0
            '
            '_btnCancel
            '
            Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._btnCancel.Location = New System.Drawing.Point(263, 102)
            Me._btnCancel.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._btnCancel.Name = "_btnCancel"
            Me._btnCancel.Size = New System.Drawing.Size(98, 20)
            Me._btnCancel.TabIndex = 8
            Me._btnCancel.Text = "Cancel"
            Me._btnCancel.UseVisualStyleBackColor = True
            '
            '_btnOk
            '
            Me._btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._btnOk.Location = New System.Drawing.Point(65, 102)
            Me._btnOk.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._btnOk.Name = "_btnOk"
            Me._btnOk.Size = New System.Drawing.Size(98, 20)
            Me._btnOk.TabIndex = 7
            Me._btnOk.Text = "OK"
            Me._btnOk.UseVisualStyleBackColor = True
            '
            'MultiplyDialog
            '
            Me.AcceptButton = Me._btnOk
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.CancelButton = Me._btnCancel
            Me.ClientSize = New System.Drawing.Size(444, 132)
            Me.Controls.Add(Me._btnCancel)
            Me.Controls.Add(Me._gbParameters)
            Me.Controls.Add(Me._btnOk)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "MultiplyDialog"
            Me.ShowIcon = False
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "Multiply"
            Me._gbParameters.ResumeLayout(False)
            Me._gbParameters.PerformLayout()
            CType(Me._tbFactor, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me._numFactor, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

	  #End Region

	  Private _gbParameters As System.Windows.Forms.GroupBox
	  Private _lblFactor As System.Windows.Forms.Label
	  Public WithEvents _tbFactor As System.Windows.Forms.TrackBar
	  Private WithEvents _numFactor As System.Windows.Forms.NumericUpDown
	  Private WithEvents _btnCancel As System.Windows.Forms.Button
	  Private WithEvents _btnOk As System.Windows.Forms.Button
   End Class
End Namespace