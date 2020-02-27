Imports Microsoft.VisualBasic
Imports System
Namespace ImageProcessingDemo
   Public Partial Class AutoColorLevelDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AutoColorLevelDialog))
            Me._lblBlackClip = New System.Windows.Forms.Label
            Me._tbBlackClip = New System.Windows.Forms.TrackBar
            Me._numBlackClip = New System.Windows.Forms.NumericUpDown
            Me._lblWhiteClip = New System.Windows.Forms.Label
            Me._tbWhiteClip = New System.Windows.Forms.TrackBar
            Me._numWhiteClip = New System.Windows.Forms.NumericUpDown
            Me._lblFlag = New System.Windows.Forms.Label
            Me._cmbFlag = New System.Windows.Forms.ComboBox
            Me._lblType = New System.Windows.Forms.Label
            Me._cmbType = New System.Windows.Forms.ComboBox
            Me._gp1 = New System.Windows.Forms.GroupBox
            Me._gb2 = New System.Windows.Forms.GroupBox
            Me._btnCancel = New System.Windows.Forms.Button
            Me._btnOk = New System.Windows.Forms.Button
            CType(Me._tbBlackClip, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me._numBlackClip, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me._tbWhiteClip, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me._numWhiteClip, System.ComponentModel.ISupportInitialize).BeginInit()
            Me._gp1.SuspendLayout()
            Me._gb2.SuspendLayout()
            Me.SuspendLayout()
            '
            '_lblBlackClip
            '
            Me._lblBlackClip.AutoSize = True
            Me._lblBlackClip.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._lblBlackClip.Location = New System.Drawing.Point(5, 32)
            Me._lblBlackClip.Name = "_lblBlackClip"
            Me._lblBlackClip.Size = New System.Drawing.Size(54, 13)
            Me._lblBlackClip.TabIndex = 0
            Me._lblBlackClip.Text = "Black Clip"
            '
            '_tbBlackClip
            '
            Me._tbBlackClip.AutoSize = False
            Me._tbBlackClip.Location = New System.Drawing.Point(62, 27)
            Me._tbBlackClip.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._tbBlackClip.Maximum = 10000
            Me._tbBlackClip.Name = "_tbBlackClip"
            Me._tbBlackClip.Size = New System.Drawing.Size(253, 32)
            Me._tbBlackClip.TabIndex = 1
            Me._tbBlackClip.TickStyle = System.Windows.Forms.TickStyle.None
            '
            '_numBlackClip
            '
            Me._numBlackClip.Location = New System.Drawing.Point(320, 32)
            Me._numBlackClip.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._numBlackClip.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
            Me._numBlackClip.Name = "_numBlackClip"
            Me._numBlackClip.Size = New System.Drawing.Size(53, 20)
            Me._numBlackClip.TabIndex = 2
            '
            '_lblWhiteClip
            '
            Me._lblWhiteClip.AutoSize = True
            Me._lblWhiteClip.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._lblWhiteClip.Location = New System.Drawing.Point(5, 88)
            Me._lblWhiteClip.Name = "_lblWhiteClip"
            Me._lblWhiteClip.Size = New System.Drawing.Size(55, 13)
            Me._lblWhiteClip.TabIndex = 3
            Me._lblWhiteClip.Text = "White Clip"
            '
            '_tbWhiteClip
            '
            Me._tbWhiteClip.AutoSize = False
            Me._tbWhiteClip.Location = New System.Drawing.Point(62, 77)
            Me._tbWhiteClip.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._tbWhiteClip.Maximum = 10000
            Me._tbWhiteClip.Name = "_tbWhiteClip"
            Me._tbWhiteClip.Size = New System.Drawing.Size(253, 36)
            Me._tbWhiteClip.TabIndex = 4
            Me._tbWhiteClip.TickStyle = System.Windows.Forms.TickStyle.None
            '
            '_numWhiteClip
            '
            Me._numWhiteClip.Location = New System.Drawing.Point(320, 77)
            Me._numWhiteClip.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._numWhiteClip.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
            Me._numWhiteClip.Name = "_numWhiteClip"
            Me._numWhiteClip.Size = New System.Drawing.Size(53, 20)
            Me._numWhiteClip.TabIndex = 5
            '
            '_lblFlag
            '
            Me._lblFlag.AutoSize = True
            Me._lblFlag.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._lblFlag.Location = New System.Drawing.Point(5, 126)
            Me._lblFlag.Name = "_lblFlag"
            Me._lblFlag.Size = New System.Drawing.Size(94, 13)
            Me._lblFlag.TabIndex = 6
            Me._lblFlag.Text = "Process the image"
            '
            '_cmbFlag
            '
            Me._cmbFlag.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me._cmbFlag.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._cmbFlag.FormattingEnabled = True
            Me._cmbFlag.Location = New System.Drawing.Point(8, 142)
            Me._cmbFlag.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._cmbFlag.Name = "_cmbFlag"
            Me._cmbFlag.Size = New System.Drawing.Size(183, 21)
            Me._cmbFlag.TabIndex = 7
            '
            '_lblType
            '
            Me._lblType.AutoSize = True
            Me._lblType.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._lblType.Location = New System.Drawing.Point(5, 184)
            Me._lblType.Name = "_lblType"
            Me._lblType.Size = New System.Drawing.Size(85, 13)
            Me._lblType.TabIndex = 8
            Me._lblType.Text = "Type of leveling "
            '
            '_cmbType
            '
            Me._cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me._cmbType.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._cmbType.FormattingEnabled = True
            Me._cmbType.Location = New System.Drawing.Point(8, 201)
            Me._cmbType.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._cmbType.Name = "_cmbType"
            Me._cmbType.Size = New System.Drawing.Size(183, 21)
            Me._cmbType.TabIndex = 9
            '
            '_gp1
            '
            Me._gp1.Controls.Add(Me._lblWhiteClip)
            Me._gp1.Controls.Add(Me._cmbType)
            Me._gp1.Controls.Add(Me._lblBlackClip)
            Me._gp1.Controls.Add(Me._lblType)
            Me._gp1.Controls.Add(Me._tbBlackClip)
            Me._gp1.Controls.Add(Me._cmbFlag)
            Me._gp1.Controls.Add(Me._numBlackClip)
            Me._gp1.Controls.Add(Me._lblFlag)
            Me._gp1.Controls.Add(Me._tbWhiteClip)
            Me._gp1.Controls.Add(Me._numWhiteClip)
            Me._gp1.Location = New System.Drawing.Point(10, 4)
            Me._gp1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gp1.Name = "_gp1"
            Me._gp1.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gp1.Size = New System.Drawing.Size(382, 236)
            Me._gp1.TabIndex = 10
            Me._gp1.TabStop = False
            '
            '_gb2
            '
            Me._gb2.Controls.Add(Me._btnCancel)
            Me._gb2.Controls.Add(Me._btnOk)
            Me._gb2.Location = New System.Drawing.Point(10, 245)
            Me._gb2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gb2.Name = "_gb2"
            Me._gb2.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gb2.Size = New System.Drawing.Size(382, 51)
            Me._gb2.TabIndex = 11
            Me._gb2.TabStop = False
            '
            '_btnCancel
            '
            Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._btnCancel.Location = New System.Drawing.Point(247, 15)
            Me._btnCancel.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._btnCancel.Name = "_btnCancel"
            Me._btnCancel.Size = New System.Drawing.Size(83, 22)
            Me._btnCancel.TabIndex = 6
            Me._btnCancel.Text = "Cancel"
            '
            '_btnOk
            '
            Me._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK
            Me._btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._btnOk.Location = New System.Drawing.Point(53, 15)
            Me._btnOk.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._btnOk.Name = "_btnOk"
            Me._btnOk.Size = New System.Drawing.Size(83, 22)
            Me._btnOk.TabIndex = 5
            Me._btnOk.Text = "OK"
            '
            'AutoColorLevelDialog
            '
            Me.AcceptButton = Me._btnOk
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.CancelButton = Me._btnCancel
            Me.ClientSize = New System.Drawing.Size(401, 306)
            Me.Controls.Add(Me._gb2)
            Me.Controls.Add(Me._gp1)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "AutoColorLevelDialog"
            Me.ShowIcon = False
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "Auto Color Level"
            CType(Me._tbBlackClip, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me._numBlackClip, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me._tbWhiteClip, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me._numWhiteClip, System.ComponentModel.ISupportInitialize).EndInit()
            Me._gp1.ResumeLayout(False)
            Me._gp1.PerformLayout()
            Me._gb2.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

	  #End Region

	  Private _lblBlackClip As System.Windows.Forms.Label
	  Private WithEvents _numBlackClip As System.Windows.Forms.NumericUpDown
	  Private _lblWhiteClip As System.Windows.Forms.Label
	  Private WithEvents _numWhiteClip As System.Windows.Forms.NumericUpDown
	  Private _lblFlag As System.Windows.Forms.Label
	  Private _cmbFlag As System.Windows.Forms.ComboBox
	  Private _lblType As System.Windows.Forms.Label
	  Private _cmbType As System.Windows.Forms.ComboBox
	  Private _gp1 As System.Windows.Forms.GroupBox
	  Private _gb2 As System.Windows.Forms.GroupBox
	  Public WithEvents _tbBlackClip As System.Windows.Forms.TrackBar
	  Public WithEvents _tbWhiteClip As System.Windows.Forms.TrackBar
	  Private WithEvents _btnCancel As System.Windows.Forms.Button
	  Private WithEvents _btnOk As System.Windows.Forms.Button
   End Class
End Namespace