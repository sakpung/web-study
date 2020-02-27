Namespace Main3DDemo
   Partial Class ThresholdDialog
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
         Me._btnReset = New System.Windows.Forms.Button()
         Me._btnCancel = New System.Windows.Forms.Button()
         Me._btnOK = New System.Windows.Forms.Button()
         Me.groupBox1 = New System.Windows.Forms.GroupBox()
         Me._removeInnerRangeChkBox = New System.Windows.Forms.CheckBox()
         Me._toLbl = New System.Windows.Forms.Label()
         Me._fromLbl = New System.Windows.Forms.Label()
         Me._chkBoxenableThreshold = New System.Windows.Forms.CheckBox()
         Me._textBoxUpper = New Main3DDemo.NumericTextBox()
         Me._textBoxLower = New Main3DDemo.NumericTextBox()
         _trackBarUpper = New System.Windows.Forms.TrackBar()
         _trackBarLower = New System.Windows.Forms.TrackBar()
         Me.groupBox1.SuspendLayout()
         CType(_trackBarUpper, System.ComponentModel.ISupportInitialize).BeginInit()
         CType(_trackBarLower, System.ComponentModel.ISupportInitialize).BeginInit()
         Me.SuspendLayout()
         ' 
         ' _btnReset
         ' 
         Me._btnReset.Location = New System.Drawing.Point(168, 165)
         Me._btnReset.Name = "_btnReset"
         Me._btnReset.Size = New System.Drawing.Size(61, 33)
         Me._btnReset.TabIndex = 19
         Me._btnReset.Text = "&Reset"
         Me._btnReset.UseVisualStyleBackColor = True
         ' 
         ' _btnCancel
         ' 
         Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
         Me._btnCancel.Location = New System.Drawing.Point(98, 165)
         Me._btnCancel.Name = "_btnCancel"
         Me._btnCancel.Size = New System.Drawing.Size(64, 33)
         Me._btnCancel.TabIndex = 18
         Me._btnCancel.Text = "&Cancel"
         Me._btnCancel.UseVisualStyleBackColor = True
         ' 
         ' _btnOK
         ' 
         Me._btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
         Me._btnOK.Location = New System.Drawing.Point(28, 165)
         Me._btnOK.Name = "_btnOK"
         Me._btnOK.Size = New System.Drawing.Size(64, 33)
         Me._btnOK.TabIndex = 17
         Me._btnOK.Text = "&OK"
         Me._btnOK.UseVisualStyleBackColor = True
         ' 
         ' groupBox1
         ' 
         Me.groupBox1.Controls.Add(Me._removeInnerRangeChkBox)
         Me.groupBox1.Controls.Add(Me._toLbl)
         Me.groupBox1.Controls.Add(Me._fromLbl)
         Me.groupBox1.Controls.Add(Me._chkBoxenableThreshold)
         Me.groupBox1.Controls.Add(Me._textBoxUpper)
         Me.groupBox1.Controls.Add(Me._textBoxLower)
         Me.groupBox1.Controls.Add(_trackBarUpper)
         Me.groupBox1.Controls.Add(_trackBarLower)
         Me.groupBox1.Location = New System.Drawing.Point(12, 12)
         Me.groupBox1.Name = "groupBox1"
         Me.groupBox1.Size = New System.Drawing.Size(237, 141)
         Me.groupBox1.TabIndex = 16
         Me.groupBox1.TabStop = False
         Me.groupBox1.Text = "&Parameters"
         ' 
         ' _removeInnerRangeChkBox
         ' 
         Me._removeInnerRangeChkBox.AutoSize = True
         Me._removeInnerRangeChkBox.Location = New System.Drawing.Point(103, 107)
         Me._removeInnerRangeChkBox.Name = "_removeInnerRangeChkBox"
         Me._removeInnerRangeChkBox.Size = New System.Drawing.Size(128, 17)
         Me._removeInnerRangeChkBox.TabIndex = 15
         Me._removeInnerRangeChkBox.Text = "&Remove Inner Range"
         Me._removeInnerRangeChkBox.UseVisualStyleBackColor = True
         ' 
         ' _toLbl
         ' 
         Me._toLbl.AutoSize = True
         Me._toLbl.Location = New System.Drawing.Point(10, 65)
         Me._toLbl.Name = "_toLbl"
         Me._toLbl.Size = New System.Drawing.Size(20, 13)
         Me._toLbl.TabIndex = 14
         Me._toLbl.Text = "&To"
         ' 
         ' _fromLbl
         ' 
         Me._fromLbl.AutoSize = True
         Me._fromLbl.Location = New System.Drawing.Point(6, 25)
         Me._fromLbl.Name = "_fromLbl"
         Me._fromLbl.Size = New System.Drawing.Size(30, 13)
         Me._fromLbl.TabIndex = 13
         Me._fromLbl.Text = "From"
         ' 
         ' _chkBoxenableThreshold
         ' 
         Me._chkBoxenableThreshold.AutoSize = True
         Me._chkBoxenableThreshold.Location = New System.Drawing.Point(9, 107)
         Me._chkBoxenableThreshold.Name = "_chkBoxenableThreshold"
         Me._chkBoxenableThreshold.Size = New System.Drawing.Size(65, 17)
         Me._chkBoxenableThreshold.TabIndex = 12
         Me._chkBoxenableThreshold.Text = "&Enabled"
         Me._chkBoxenableThreshold.UseVisualStyleBackColor = True
         ' 
         ' _textBoxUpper
         ' 
         Me._textBoxUpper.Location = New System.Drawing.Point(170, 58)
         Me._textBoxUpper.MaximumAllowed = 100000
         Me._textBoxUpper.MinimumAllowed = 0
         Me._textBoxUpper.Name = "_textBoxUpper"
         Me._textBoxUpper.Size = New System.Drawing.Size(50, 20)
         Me._textBoxUpper.TabIndex = 9
         Me._textBoxUpper.Text = "100000"
         Me._textBoxUpper.Value = 100000
         ' 
         ' _textBoxLower
         ' 
         Me._textBoxLower.Location = New System.Drawing.Point(171, 18)
         Me._textBoxLower.MaximumAllowed = 100000
         Me._textBoxLower.MinimumAllowed = 0
         Me._textBoxLower.Name = "_textBoxLower"
         Me._textBoxLower.Size = New System.Drawing.Size(50, 20)
         Me._textBoxLower.TabIndex = 6
         Me._textBoxLower.Text = "0"
         Me._textBoxLower.Value = 0
         ' 
         ' _trackBarUpper
         ' 
         _trackBarUpper.Location = New System.Drawing.Point(34, 60)
         _trackBarUpper.Maximum = 100000
         _trackBarUpper.Name = "_trackBarUpper"
         _trackBarUpper.Size = New System.Drawing.Size(133, 45)
         _trackBarUpper.TabIndex = 3
         _trackBarUpper.TickFrequency = 0
         _trackBarUpper.TickStyle = System.Windows.Forms.TickStyle.None
         _trackBarUpper.Value = 255
         ' 
         ' _trackBarLower
         ' 
         _trackBarLower.Location = New System.Drawing.Point(34, 20)
         _trackBarLower.Maximum = 100000
         _trackBarLower.Name = "_trackBarLower"
         _trackBarLower.Size = New System.Drawing.Size(133, 45)
         _trackBarLower.TabIndex = 0
         _trackBarLower.TickFrequency = 0
         _trackBarLower.TickStyle = System.Windows.Forms.TickStyle.None
         ' 
         ' ThresholdDialog
         ' 
         Me.AcceptButton = Me._btnOK
         Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.CancelButton = Me._btnCancel
         Me.ClientSize = New System.Drawing.Size(258, 208)
         Me.Controls.Add(Me._btnReset)
         Me.Controls.Add(Me._btnCancel)
         Me.Controls.Add(Me._btnOK)
         Me.Controls.Add(Me.groupBox1)
         Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
         Me.MaximizeBox = False
         Me.MinimizeBox = False
         Me.Name = "ThresholdDialog"
         Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
         Me.Text = "Remove Density Dialog"
         Me.groupBox1.ResumeLayout(False)
         Me.groupBox1.PerformLayout()
         CType(_trackBarUpper, System.ComponentModel.ISupportInitialize).EndInit()
         CType(_trackBarLower, System.ComponentModel.ISupportInitialize).EndInit()
         Me.ResumeLayout(False)

      End Sub

#End Region

      Private WithEvents _btnReset As System.Windows.Forms.Button
      Private WithEvents _btnCancel As System.Windows.Forms.Button
      Private _btnOK As System.Windows.Forms.Button
      Private groupBox1 As System.Windows.Forms.GroupBox
      Private WithEvents _chkBoxenableThreshold As System.Windows.Forms.CheckBox
      Private WithEvents _textBoxUpper As NumericTextBox
      Private WithEvents _textBoxLower As NumericTextBox
      Private WithEvents _removeInnerRangeChkBox As System.Windows.Forms.CheckBox
      Private _toLbl As System.Windows.Forms.Label
      Private _fromLbl As System.Windows.Forms.Label
      Private WithEvents _trackBarUpper As System.Windows.Forms.TrackBar
      Private WithEvents _trackBarLower As System.Windows.Forms.TrackBar
   End Class
End Namespace
