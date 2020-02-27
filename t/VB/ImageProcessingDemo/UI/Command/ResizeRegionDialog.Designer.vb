Imports Microsoft.VisualBasic
Imports System
Namespace ImageProcessingDemo
   Public Partial Class ResizeRegionDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ResizeRegionDialog))
            Me._gbDimension = New System.Windows.Forms.GroupBox
            Me._tbDimension = New System.Windows.Forms.TrackBar
            Me._txbDimension = New System.Windows.Forms.TextBox
            Me._btnCancel = New System.Windows.Forms.Button
            Me._btnOk = New System.Windows.Forms.Button
            Me._gbType = New System.Windows.Forms.GroupBox
            Me._cmbType = New System.Windows.Forms.ComboBox
            Me._chkFrame = New System.Windows.Forms.CheckBox
            Me._gbDimension.SuspendLayout()
            CType(Me._tbDimension, System.ComponentModel.ISupportInitialize).BeginInit()
            Me._gbType.SuspendLayout()
            Me.SuspendLayout()
            '
            '_gbDimension
            '
            Me._gbDimension.Controls.Add(Me._tbDimension)
            Me._gbDimension.Controls.Add(Me._txbDimension)
            Me._gbDimension.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._gbDimension.Location = New System.Drawing.Point(1, 4)
            Me._gbDimension.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gbDimension.Name = "_gbDimension"
            Me._gbDimension.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gbDimension.Size = New System.Drawing.Size(329, 69)
            Me._gbDimension.TabIndex = 0
            Me._gbDimension.TabStop = False
            Me._gbDimension.Text = "Dimension"
            '
            '_tbDimension
            '
            Me._tbDimension.Location = New System.Drawing.Point(72, 15)
            Me._tbDimension.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._tbDimension.Maximum = 500
            Me._tbDimension.Minimum = 1
            Me._tbDimension.Name = "_tbDimension"
            Me._tbDimension.Size = New System.Drawing.Size(243, 45)
            Me._tbDimension.TabIndex = 1
            Me._tbDimension.TickStyle = System.Windows.Forms.TickStyle.None
            Me._tbDimension.Value = 1
            '
            '_txbDimension
            '
            Me._txbDimension.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me._txbDimension.Location = New System.Drawing.Point(5, 19)
            Me._txbDimension.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._txbDimension.Name = "_txbDimension"
            Me._txbDimension.Size = New System.Drawing.Size(62, 20)
            Me._txbDimension.TabIndex = 0
            '
            '_btnCancel
            '
            Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._btnCancel.Location = New System.Drawing.Point(335, 40)
            Me._btnCancel.Name = "_btnCancel"
            Me._btnCancel.Size = New System.Drawing.Size(75, 23)
            Me._btnCancel.TabIndex = 13
            Me._btnCancel.Text = "Cancel"
            Me._btnCancel.UseVisualStyleBackColor = True
            '
            '_btnOk
            '
            Me._btnOk.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me._btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._btnOk.Location = New System.Drawing.Point(335, 11)
            Me._btnOk.Name = "_btnOk"
            Me._btnOk.Size = New System.Drawing.Size(75, 23)
            Me._btnOk.TabIndex = 12
            Me._btnOk.Text = "OK"
            Me._btnOk.UseVisualStyleBackColor = True
            '
            '_gbType
            '
            Me._gbType.Controls.Add(Me._cmbType)
            Me._gbType.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._gbType.Location = New System.Drawing.Point(1, 78)
            Me._gbType.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gbType.Name = "_gbType"
            Me._gbType.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gbType.Size = New System.Drawing.Size(329, 60)
            Me._gbType.TabIndex = 14
            Me._gbType.TabStop = False
            Me._gbType.Text = "Type"
            '
            '_cmbType
            '
            Me._cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me._cmbType.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._cmbType.FormattingEnabled = True
            Me._cmbType.Location = New System.Drawing.Point(9, 26)
            Me._cmbType.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._cmbType.Name = "_cmbType"
            Me._cmbType.Size = New System.Drawing.Size(235, 21)
            Me._cmbType.TabIndex = 0
            '
            '_chkFrame
            '
            Me._chkFrame.AutoSize = True
            Me._chkFrame.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._chkFrame.Location = New System.Drawing.Point(6, 152)
            Me._chkFrame.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._chkFrame.Name = "_chkFrame"
            Me._chkFrame.Size = New System.Drawing.Size(101, 18)
            Me._chkFrame.TabIndex = 16
            Me._chkFrame.Text = "Create a frame"
            Me._chkFrame.UseVisualStyleBackColor = True
            '
            'ResizeRegionDialog
            '
            Me.AcceptButton = Me._btnOk
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.CancelButton = Me._btnCancel
            Me.ClientSize = New System.Drawing.Size(416, 177)
            Me.Controls.Add(Me._chkFrame)
            Me.Controls.Add(Me._gbType)
            Me.Controls.Add(Me._btnCancel)
            Me.Controls.Add(Me._btnOk)
            Me.Controls.Add(Me._gbDimension)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "ResizeRegionDialog"
            Me.ShowIcon = False
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "Resize Region"
            Me._gbDimension.ResumeLayout(False)
            Me._gbDimension.PerformLayout()
            CType(Me._tbDimension, System.ComponentModel.ISupportInitialize).EndInit()
            Me._gbType.ResumeLayout(False)
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub

	  #End Region

	  Private _gbDimension As System.Windows.Forms.GroupBox
	  Private WithEvents _txbDimension As System.Windows.Forms.TextBox
	  Public WithEvents _tbDimension As System.Windows.Forms.TrackBar
	  Private WithEvents _btnCancel As System.Windows.Forms.Button
	  Private WithEvents _btnOk As System.Windows.Forms.Button
	  Private _gbType As System.Windows.Forms.GroupBox
	  Private _cmbType As System.Windows.Forms.ComboBox
	  Private _chkFrame As System.Windows.Forms.CheckBox
   End Class
End Namespace