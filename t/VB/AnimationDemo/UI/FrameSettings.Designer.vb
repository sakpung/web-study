
Namespace AnimationDemo
   Partial Class FrameSettings
      ''' <summary>
      ''' Required designer variable.
      ''' </summary>
      Private components As System.ComponentModel.IContainer = Nothing

      ''' <summary>
      ''' Clean up any resources being used.
      ''' </summary>
      ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      Protected Overrides Sub Dispose(disposing As Boolean)
         If disposing AndAlso (components IsNot Nothing) Then
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
         Me._chkWaitForUserInput = New System.Windows.Forms.CheckBox()
         Me._lblDelay = New System.Windows.Forms.Label()
         Me._tbDelay = New System.Windows.Forms.TextBox()
         Me._chkApplyToAll = New System.Windows.Forms.CheckBox()
         Me._tbLeft = New System.Windows.Forms.TextBox()
         Me._lblLeft = New System.Windows.Forms.Label()
         Me._tbTop = New System.Windows.Forms.TextBox()
         Me._lblTop = New System.Windows.Forms.Label()
         Me._btnOK = New System.Windows.Forms.Button()
         Me._btnCancel = New System.Windows.Forms.Button()
         Me._cmbDisposalMethod = New System.Windows.Forms.ComboBox()
         Me._lblDisposalMethod = New System.Windows.Forms.Label()
         Me._chkTransparentColor = New System.Windows.Forms.CheckBox()
         Me._btnChooseColor = New System.Windows.Forms.Button()
         Me._pnlColor = New System.Windows.Forms.Panel()
         Me.SuspendLayout()
         ' 
         ' _chkWaitForUserInput
         ' 
         Me._chkWaitForUserInput.AutoSize = True
         Me._chkWaitForUserInput.Location = New System.Drawing.Point(12, 48)
         Me._chkWaitForUserInput.Name = "_chkWaitForUserInput"
         Me._chkWaitForUserInput.Size = New System.Drawing.Size(118, 17)
         Me._chkWaitForUserInput.TabIndex = 0
         Me._chkWaitForUserInput.Text = "&Wait For User Input"
         Me._chkWaitForUserInput.UseVisualStyleBackColor = True
         ' 
         ' _lblDelay
         ' 
         Me._lblDelay.AutoSize = True
         Me._lblDelay.Location = New System.Drawing.Point(9, 79)
         Me._lblDelay.Name = "_lblDelay"
         Me._lblDelay.Size = New System.Drawing.Size(62, 13)
         Me._lblDelay.TabIndex = 1
         Me._lblDelay.Text = "&Delay (ms) :"
         Me._lblDelay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
         ' 
         ' _tbDelay
         ' 
         Me._tbDelay.Location = New System.Drawing.Point(77, 76)
         Me._tbDelay.Name = "_tbDelay"
         Me._tbDelay.Size = New System.Drawing.Size(62, 20)
         Me._tbDelay.TabIndex = 2
         ' 
         ' _chkApplyToAll
         ' 
         Me._chkApplyToAll.AutoSize = True
         Me._chkApplyToAll.Location = New System.Drawing.Point(207, 75)
         Me._chkApplyToAll.Name = "_chkApplyToAll"
         Me._chkApplyToAll.Size = New System.Drawing.Size(82, 17)
         Me._chkApplyToAll.TabIndex = 3
         Me._chkApplyToAll.Text = "&Apply To All"
         Me._chkApplyToAll.UseVisualStyleBackColor = True
         ' 
         ' _tbLeft
         ' 
         Me._tbLeft.Location = New System.Drawing.Point(46, 143)
         Me._tbLeft.Name = "_tbLeft"
         Me._tbLeft.Size = New System.Drawing.Size(62, 20)
         Me._tbLeft.TabIndex = 5
         ' 
         ' _lblLeft
         ' 
         Me._lblLeft.AutoSize = True
         Me._lblLeft.Location = New System.Drawing.Point(9, 145)
         Me._lblLeft.Name = "_lblLeft"
         Me._lblLeft.Size = New System.Drawing.Size(31, 13)
         Me._lblLeft.TabIndex = 4
         Me._lblLeft.Text = "&Left :"
         ' 
         ' _tbTop
         ' 
         Me._tbTop.Location = New System.Drawing.Point(184, 143)
         Me._tbTop.Name = "_tbTop"
         Me._tbTop.Size = New System.Drawing.Size(62, 20)
         Me._tbTop.TabIndex = 7
         ' 
         ' _lblTop
         ' 
         Me._lblTop.AutoSize = True
         Me._lblTop.Location = New System.Drawing.Point(146, 146)
         Me._lblTop.Name = "_lblTop"
         Me._lblTop.Size = New System.Drawing.Size(32, 13)
         Me._lblTop.TabIndex = 6
         Me._lblTop.Text = "&Top :"
         ' 
         ' _btnOK
         ' 
         Me._btnOK.AccessibleDescription = ""
         Me._btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
         Me._btnOK.Location = New System.Drawing.Point(66, 183)
         Me._btnOK.Name = "_btnOK"
         Me._btnOK.Size = New System.Drawing.Size(75, 23)
         Me._btnOK.TabIndex = 8
         Me._btnOK.Text = "&OK"
         Me._btnOK.UseVisualStyleBackColor = True
         ' 
         ' _btnCancel
         ' 
         Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
         Me._btnCancel.Location = New System.Drawing.Point(152, 183)
         Me._btnCancel.Name = "_btnCancel"
         Me._btnCancel.Size = New System.Drawing.Size(75, 23)
         Me._btnCancel.TabIndex = 9
         Me._btnCancel.Text = "&Cancel"
         Me._btnCancel.UseVisualStyleBackColor = True
         ' 
         ' _cmbDisposalMethod
         ' 
         Me._cmbDisposalMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
         Me._cmbDisposalMethod.FormattingEnabled = True
         Me._cmbDisposalMethod.Location = New System.Drawing.Point(125, 106)
         Me._cmbDisposalMethod.Name = "_cmbDisposalMethod"
         Me._cmbDisposalMethod.Size = New System.Drawing.Size(121, 21)
         Me._cmbDisposalMethod.TabIndex = 10
         ' 
         ' _lblDisposalMethod
         ' 
         Me._lblDisposalMethod.Location = New System.Drawing.Point(9, 114)
         Me._lblDisposalMethod.Name = "_lblDisposalMethod"
         Me._lblDisposalMethod.Size = New System.Drawing.Size(92, 13)
         Me._lblDisposalMethod.TabIndex = 11
         Me._lblDisposalMethod.Text = "Disposal &Method :"
         Me._lblDisposalMethod.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
         ' 
         ' _chkTransparentColor
         ' 
         Me._chkTransparentColor.AutoSize = True
         Me._chkTransparentColor.Location = New System.Drawing.Point(12, 13)
         Me._chkTransparentColor.Name = "_chkTransparentColor"
         Me._chkTransparentColor.Size = New System.Drawing.Size(110, 17)
         Me._chkTransparentColor.TabIndex = 12
         Me._chkTransparentColor.Text = "&Transparent Color"
         Me._chkTransparentColor.UseVisualStyleBackColor = True
         ' 
         ' _btnChooseColor
         ' 
         Me._btnChooseColor.Location = New System.Drawing.Point(194, 13)
         Me._btnChooseColor.Name = "_btnChooseColor"
         Me._btnChooseColor.Size = New System.Drawing.Size(95, 21)
         Me._btnChooseColor.TabIndex = 14
         Me._btnChooseColor.Text = "&Choose Color >>"
         Me._btnChooseColor.UseVisualStyleBackColor = True
         ' 
         ' _pnlColor
         ' 
         Me._pnlColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
         Me._pnlColor.Location = New System.Drawing.Point(122, 13)
         Me._pnlColor.Name = "_pnlColor"
         Me._pnlColor.Size = New System.Drawing.Size(62, 21)
         Me._pnlColor.TabIndex = 15
         ' 
         ' FrameSettings
         ' 
         Me.AcceptButton = Me._btnOK
         Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.CancelButton = Me._btnCancel
         Me.ClientSize = New System.Drawing.Size(293, 218)
         Me.Controls.Add(Me._pnlColor)
         Me.Controls.Add(Me._btnChooseColor)
         Me.Controls.Add(Me._chkTransparentColor)
         Me.Controls.Add(Me._lblDisposalMethod)
         Me.Controls.Add(Me._cmbDisposalMethod)
         Me.Controls.Add(Me._btnCancel)
         Me.Controls.Add(Me._btnOK)
         Me.Controls.Add(Me._tbTop)
         Me.Controls.Add(Me._lblTop)
         Me.Controls.Add(Me._tbLeft)
         Me.Controls.Add(Me._lblLeft)
         Me.Controls.Add(Me._chkApplyToAll)
         Me.Controls.Add(Me._tbDelay)
         Me.Controls.Add(Me._lblDelay)
         Me.Controls.Add(Me._chkWaitForUserInput)
         Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
         Me.MaximizeBox = False
         Me.MinimizeBox = False
         Me.Name = "FrameSettings"
         Me.ShowIcon = False
         Me.ShowInTaskbar = False
         Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
         Me.Text = "Frame Settings"
         Me.ResumeLayout(False)
         Me.PerformLayout()

      End Sub

#End Region

      Private _chkWaitForUserInput As System.Windows.Forms.CheckBox
      Private _lblDelay As System.Windows.Forms.Label
      Private WithEvents _tbDelay As System.Windows.Forms.TextBox
      Private _chkApplyToAll As System.Windows.Forms.CheckBox
      Private WithEvents _tbLeft As System.Windows.Forms.TextBox
      Private _lblLeft As System.Windows.Forms.Label
      Private WithEvents _tbTop As System.Windows.Forms.TextBox
      Private _lblTop As System.Windows.Forms.Label
      Private WithEvents _btnOK As System.Windows.Forms.Button
      Private _btnCancel As System.Windows.Forms.Button
      Private _cmbDisposalMethod As System.Windows.Forms.ComboBox
      Private _lblDisposalMethod As System.Windows.Forms.Label
      Private _chkTransparentColor As System.Windows.Forms.CheckBox
      Private WithEvents _btnChooseColor As System.Windows.Forms.Button
      Private _pnlColor As System.Windows.Forms.Panel
   End Class
End Namespace