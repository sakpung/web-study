Imports Microsoft.VisualBasic
Imports System
Namespace ImageProcessingDemo
   Public Partial Class UnsharpMaskDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UnsharpMaskDialog))
            Me._gbAmount = New System.Windows.Forms.GroupBox
            Me._tbAmount = New System.Windows.Forms.TrackBar
            Me._txbAmount = New System.Windows.Forms.TextBox
            Me._gbRadius = New System.Windows.Forms.GroupBox
            Me._tbRadius = New System.Windows.Forms.TrackBar
            Me._txbRadius = New System.Windows.Forms.TextBox
            Me._gbThreshold = New System.Windows.Forms.GroupBox
            Me._tbThreshold = New System.Windows.Forms.TrackBar
            Me._txbThreshold = New System.Windows.Forms.TextBox
            Me._btnCancel = New System.Windows.Forms.Button
            Me._btnOk = New System.Windows.Forms.Button
            Me._cmbColorType = New System.Windows.Forms.ComboBox
            Me._lblColorType = New System.Windows.Forms.Label
            Me._gbAmount.SuspendLayout()
            CType(Me._tbAmount, System.ComponentModel.ISupportInitialize).BeginInit()
            Me._gbRadius.SuspendLayout()
            CType(Me._tbRadius, System.ComponentModel.ISupportInitialize).BeginInit()
            Me._gbThreshold.SuspendLayout()
            CType(Me._tbThreshold, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            '_gbAmount
            '
            Me._gbAmount.Controls.Add(Me._tbAmount)
            Me._gbAmount.Controls.Add(Me._txbAmount)
            Me._gbAmount.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._gbAmount.Location = New System.Drawing.Point(10, 10)
            Me._gbAmount.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gbAmount.Name = "_gbAmount"
            Me._gbAmount.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gbAmount.Size = New System.Drawing.Size(367, 75)
            Me._gbAmount.TabIndex = 0
            Me._gbAmount.TabStop = False
            Me._gbAmount.Text = "Amount"
            '
            '_tbAmount
            '
            Me._tbAmount.Location = New System.Drawing.Point(60, 19)
            Me._tbAmount.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._tbAmount.Maximum = 500
            Me._tbAmount.Name = "_tbAmount"
            Me._tbAmount.Size = New System.Drawing.Size(292, 45)
            Me._tbAmount.TabIndex = 1
            Me._tbAmount.TickStyle = System.Windows.Forms.TickStyle.None
            '
            '_txbAmount
            '
            Me._txbAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me._txbAmount.Location = New System.Drawing.Point(5, 26)
            Me._txbAmount.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._txbAmount.Name = "_txbAmount"
            Me._txbAmount.Size = New System.Drawing.Size(50, 20)
            Me._txbAmount.TabIndex = 0
            '
            '_gbRadius
            '
            Me._gbRadius.Controls.Add(Me._tbRadius)
            Me._gbRadius.Controls.Add(Me._txbRadius)
            Me._gbRadius.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._gbRadius.Location = New System.Drawing.Point(10, 89)
            Me._gbRadius.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gbRadius.Name = "_gbRadius"
            Me._gbRadius.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gbRadius.Size = New System.Drawing.Size(367, 71)
            Me._gbRadius.TabIndex = 1
            Me._gbRadius.TabStop = False
            Me._gbRadius.Text = "Radius"
            '
            '_tbRadius
            '
            Me._tbRadius.Location = New System.Drawing.Point(60, 23)
            Me._tbRadius.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._tbRadius.Maximum = 1000
            Me._tbRadius.Minimum = 1
            Me._tbRadius.Name = "_tbRadius"
            Me._tbRadius.Size = New System.Drawing.Size(292, 45)
            Me._tbRadius.TabIndex = 1
            Me._tbRadius.TickStyle = System.Windows.Forms.TickStyle.None
            Me._tbRadius.Value = 1
            '
            '_txbRadius
            '
            Me._txbRadius.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me._txbRadius.Location = New System.Drawing.Point(5, 29)
            Me._txbRadius.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._txbRadius.Name = "_txbRadius"
            Me._txbRadius.Size = New System.Drawing.Size(50, 20)
            Me._txbRadius.TabIndex = 0
            '
            '_gbThreshold
            '
            Me._gbThreshold.Controls.Add(Me._tbThreshold)
            Me._gbThreshold.Controls.Add(Me._txbThreshold)
            Me._gbThreshold.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._gbThreshold.Location = New System.Drawing.Point(10, 165)
            Me._gbThreshold.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gbThreshold.Name = "_gbThreshold"
            Me._gbThreshold.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gbThreshold.Size = New System.Drawing.Size(367, 73)
            Me._gbThreshold.TabIndex = 2
            Me._gbThreshold.TabStop = False
            Me._gbThreshold.Text = "Threshold"
            '
            '_tbThreshold
            '
            Me._tbThreshold.Location = New System.Drawing.Point(60, 25)
            Me._tbThreshold.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._tbThreshold.Maximum = 255
            Me._tbThreshold.Name = "_tbThreshold"
            Me._tbThreshold.Size = New System.Drawing.Size(292, 45)
            Me._tbThreshold.TabIndex = 1
            Me._tbThreshold.TickStyle = System.Windows.Forms.TickStyle.None
            '
            '_txbThreshold
            '
            Me._txbThreshold.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me._txbThreshold.Location = New System.Drawing.Point(5, 30)
            Me._txbThreshold.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._txbThreshold.Name = "_txbThreshold"
            Me._txbThreshold.Size = New System.Drawing.Size(50, 20)
            Me._txbThreshold.TabIndex = 0
            '
            '_btnCancel
            '
            Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._btnCancel.Location = New System.Drawing.Point(382, 49)
            Me._btnCancel.Name = "_btnCancel"
            Me._btnCancel.Size = New System.Drawing.Size(75, 23)
            Me._btnCancel.TabIndex = 11
            Me._btnCancel.Text = "Cancel"
            Me._btnCancel.UseVisualStyleBackColor = True
            '
            '_btnOk
            '
            Me._btnOk.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me._btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._btnOk.Location = New System.Drawing.Point(382, 20)
            Me._btnOk.Name = "_btnOk"
            Me._btnOk.Size = New System.Drawing.Size(75, 23)
            Me._btnOk.TabIndex = 10
            Me._btnOk.Text = "OK"
            Me._btnOk.UseVisualStyleBackColor = True
            '
            '_cmbColorType
            '
            Me._cmbColorType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me._cmbColorType.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._cmbColorType.FormattingEnabled = True
            Me._cmbColorType.Location = New System.Drawing.Point(102, 263)
            Me._cmbColorType.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._cmbColorType.Name = "_cmbColorType"
            Me._cmbColorType.Size = New System.Drawing.Size(207, 21)
            Me._cmbColorType.TabIndex = 12
            '
            '_lblColorType
            '
            Me._lblColorType.AutoSize = True
            Me._lblColorType.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._lblColorType.Location = New System.Drawing.Point(10, 266)
            Me._lblColorType.Name = "_lblColorType"
            Me._lblColorType.Size = New System.Drawing.Size(80, 13)
            Me._lblColorType.TabIndex = 13
            Me._lblColorType.Text = "Apply Mask on:"
            '
            'UnsharpMaskDialog
            '
            Me.AcceptButton = Me._btnOk
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.CancelButton = Me._btnCancel
            Me.ClientSize = New System.Drawing.Size(460, 298)
            Me.Controls.Add(Me._lblColorType)
            Me.Controls.Add(Me._cmbColorType)
            Me.Controls.Add(Me._btnCancel)
            Me.Controls.Add(Me._btnOk)
            Me.Controls.Add(Me._gbThreshold)
            Me.Controls.Add(Me._gbRadius)
            Me.Controls.Add(Me._gbAmount)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "UnsharpMaskDialog"
            Me.ShowIcon = False
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "Unsharp Mask"
            Me._gbAmount.ResumeLayout(False)
            Me._gbAmount.PerformLayout()
            CType(Me._tbAmount, System.ComponentModel.ISupportInitialize).EndInit()
            Me._gbRadius.ResumeLayout(False)
            Me._gbRadius.PerformLayout()
            CType(Me._tbRadius, System.ComponentModel.ISupportInitialize).EndInit()
            Me._gbThreshold.ResumeLayout(False)
            Me._gbThreshold.PerformLayout()
            CType(Me._tbThreshold, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub

	  #End Region

	  Private _gbAmount As System.Windows.Forms.GroupBox
	  Private _gbRadius As System.Windows.Forms.GroupBox
	  Private _gbThreshold As System.Windows.Forms.GroupBox
	  Private WithEvents _btnCancel As System.Windows.Forms.Button
	  Private WithEvents _btnOk As System.Windows.Forms.Button
	  Private _cmbColorType As System.Windows.Forms.ComboBox
	  Private _lblColorType As System.Windows.Forms.Label
	  Public WithEvents _tbAmount As System.Windows.Forms.TrackBar
	  Private WithEvents _txbAmount As System.Windows.Forms.TextBox
	  Public WithEvents _tbRadius As System.Windows.Forms.TrackBar
	  Private WithEvents _txbRadius As System.Windows.Forms.TextBox
	  Public WithEvents _tbThreshold As System.Windows.Forms.TrackBar
	  Private WithEvents _txbThreshold As System.Windows.Forms.TextBox
   End Class
End Namespace