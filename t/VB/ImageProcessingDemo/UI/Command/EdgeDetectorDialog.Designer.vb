Imports Microsoft.VisualBasic
Imports System
Namespace ImageProcessingDemo
   Public Partial Class EdgeDetectorDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EdgeDetectorDialog))
            Me._gbThreshold = New System.Windows.Forms.GroupBox
            Me._tbThreshold = New System.Windows.Forms.TrackBar
            Me._txbThreshold = New System.Windows.Forms.TextBox
            Me._lblFilter = New System.Windows.Forms.Label
            Me._cmbFilter = New System.Windows.Forms.ComboBox
            Me._btnCancel = New System.Windows.Forms.Button
            Me._btnOk = New System.Windows.Forms.Button
            Me._gbThreshold.SuspendLayout()
            CType(Me._tbThreshold, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            '_gbThreshold
            '
            Me._gbThreshold.Controls.Add(Me._tbThreshold)
            Me._gbThreshold.Controls.Add(Me._txbThreshold)
            Me._gbThreshold.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._gbThreshold.Location = New System.Drawing.Point(10, 10)
            Me._gbThreshold.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gbThreshold.Name = "_gbThreshold"
            Me._gbThreshold.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gbThreshold.Size = New System.Drawing.Size(329, 67)
            Me._gbThreshold.TabIndex = 0
            Me._gbThreshold.TabStop = False
            Me._gbThreshold.Text = "Threshold"
            '
            '_tbThreshold
            '
            Me._tbThreshold.Location = New System.Drawing.Point(66, 16)
            Me._tbThreshold.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._tbThreshold.Maximum = 255
            Me._tbThreshold.Name = "_tbThreshold"
            Me._tbThreshold.Size = New System.Drawing.Size(258, 45)
            Me._tbThreshold.TabIndex = 1
            Me._tbThreshold.TickStyle = System.Windows.Forms.TickStyle.None
            '
            '_txbThreshold
            '
            Me._txbThreshold.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me._txbThreshold.Location = New System.Drawing.Point(5, 19)
            Me._txbThreshold.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._txbThreshold.Name = "_txbThreshold"
            Me._txbThreshold.Size = New System.Drawing.Size(56, 20)
            Me._txbThreshold.TabIndex = 0
            '
            '_lblFilter
            '
            Me._lblFilter.AutoSize = True
            Me._lblFilter.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._lblFilter.Location = New System.Drawing.Point(8, 93)
            Me._lblFilter.Name = "_lblFilter"
            Me._lblFilter.Size = New System.Drawing.Size(29, 13)
            Me._lblFilter.TabIndex = 1
            Me._lblFilter.Text = "Filter"
            '
            '_cmbFilter
            '
            Me._cmbFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me._cmbFilter.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._cmbFilter.FormattingEnabled = True
            Me._cmbFilter.Location = New System.Drawing.Point(49, 91)
            Me._cmbFilter.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._cmbFilter.Name = "_cmbFilter"
            Me._cmbFilter.Size = New System.Drawing.Size(291, 21)
            Me._cmbFilter.TabIndex = 2
            '
            '_btnCancel
            '
            Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._btnCancel.Location = New System.Drawing.Point(349, 50)
            Me._btnCancel.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._btnCancel.Name = "_btnCancel"
            Me._btnCancel.Size = New System.Drawing.Size(86, 27)
            Me._btnCancel.TabIndex = 11
            Me._btnCancel.Text = "Cancel"
            Me._btnCancel.UseVisualStyleBackColor = True
            '
            '_btnOk
            '
            Me._btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._btnOk.Location = New System.Drawing.Point(349, 19)
            Me._btnOk.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._btnOk.Name = "_btnOk"
            Me._btnOk.Size = New System.Drawing.Size(86, 27)
            Me._btnOk.TabIndex = 10
            Me._btnOk.Text = "OK"
            Me._btnOk.UseVisualStyleBackColor = True
            '
            'EdgeDetectorDialog
            '
            Me.AcceptButton = Me._btnOk
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.CancelButton = Me._btnCancel
            Me.ClientSize = New System.Drawing.Size(437, 118)
            Me.Controls.Add(Me._btnCancel)
            Me.Controls.Add(Me._btnOk)
            Me.Controls.Add(Me._cmbFilter)
            Me.Controls.Add(Me._lblFilter)
            Me.Controls.Add(Me._gbThreshold)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "EdgeDetectorDialog"
            Me.ShowIcon = False
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "Edge Detector"
            Me._gbThreshold.ResumeLayout(False)
            Me._gbThreshold.PerformLayout()
            CType(Me._tbThreshold, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub

	  #End Region

	  Private _gbThreshold As System.Windows.Forms.GroupBox
	  Public WithEvents _tbThreshold As System.Windows.Forms.TrackBar
	  Private WithEvents _txbThreshold As System.Windows.Forms.TextBox
	  Private _lblFilter As System.Windows.Forms.Label
	  Private _cmbFilter As System.Windows.Forms.ComboBox
	  Private WithEvents _btnCancel As System.Windows.Forms.Button
	  Private WithEvents _btnOk As System.Windows.Forms.Button
   End Class
End Namespace