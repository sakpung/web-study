Imports Microsoft.VisualBasic
Imports System
Partial Public Class EnableLanguagesDialog
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
      Me._okButton = New System.Windows.Forms.Button()
      Me._cancelButton = New System.Windows.Forms.Button()
      Me.groupBox1 = New System.Windows.Forms.GroupBox()
      Me.label2 = New System.Windows.Forms.Label()
      Me.label1 = New System.Windows.Forms.Label()
      Me._btnMoveTop = New System.Windows.Forms.Button()
      Me._btnMoveLeft = New System.Windows.Forms.Button()
      Me._btnMoveRight = New System.Windows.Forms.Button()
      Me._enabledLanguagesListBox = New System.Windows.Forms.ListBox()
      Me._mainLanguageLabel = New System.Windows.Forms.Label()
      Me._additionalLabel = New System.Windows.Forms.Label()
      Me._languagesListBox = New System.Windows.Forms.ListBox()
      Me.groupBox1.SuspendLayout()
      Me.SuspendLayout()
      '
      '_okButton
      '
      Me._okButton.DialogResult = System.Windows.Forms.DialogResult.OK
      Me._okButton.Location = New System.Drawing.Point(276, 430)
      Me._okButton.Name = "_okButton"
      Me._okButton.Size = New System.Drawing.Size(75, 23)
      Me._okButton.TabIndex = 4
      Me._okButton.Text = "OK"
      Me._okButton.UseVisualStyleBackColor = True
      '
      '_cancelButton
      '
      Me._cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me._cancelButton.Location = New System.Drawing.Point(357, 430)
      Me._cancelButton.Name = "_cancelButton"
      Me._cancelButton.Size = New System.Drawing.Size(75, 23)
      Me._cancelButton.TabIndex = 5
      Me._cancelButton.Text = "Cancel"
      Me._cancelButton.UseVisualStyleBackColor = True
      '
      'groupBox1
      '
      Me.groupBox1.Controls.Add(Me.label2)
      Me.groupBox1.Controls.Add(Me.label1)
      Me.groupBox1.Controls.Add(Me._btnMoveTop)
      Me.groupBox1.Controls.Add(Me._btnMoveLeft)
      Me.groupBox1.Controls.Add(Me._btnMoveRight)
      Me.groupBox1.Controls.Add(Me._enabledLanguagesListBox)
      Me.groupBox1.Controls.Add(Me._mainLanguageLabel)
      Me.groupBox1.Controls.Add(Me._additionalLabel)
      Me.groupBox1.Controls.Add(Me._languagesListBox)
      Me.groupBox1.Location = New System.Drawing.Point(12, 12)
      Me.groupBox1.Name = "groupBox1"
      Me.groupBox1.Size = New System.Drawing.Size(420, 412)
      Me.groupBox1.TabIndex = 6
      Me.groupBox1.TabStop = False
      Me.groupBox1.Text = "Select the OCR languages to enable in this demo:"
      '
      'label2
      '
      Me.label2.AutoSize = True
      Me.label2.Location = New System.Drawing.Point(208, 25)
      Me.label2.Name = "label2"
      Me.label2.Size = New System.Drawing.Size(102, 13)
      Me.label2.TabIndex = 20
      Me.label2.Text = "Enabled Languages"
      '
      'label1
      '
      Me.label1.AutoSize = True
      Me.label1.Location = New System.Drawing.Point(6, 25)
      Me.label1.Name = "label1"
      Me.label1.Size = New System.Drawing.Size(106, 13)
      Me.label1.TabIndex = 19
      Me.label1.Text = "Available Languages"
      '
      '_btnMoveTop
      '
      Me._btnMoveTop.Location = New System.Drawing.Point(378, 41)
      Me._btnMoveTop.Name = "_btnMoveTop"
      Me._btnMoveTop.Size = New System.Drawing.Size(32, 32)
      Me._btnMoveTop.TabIndex = 17
      Me._btnMoveTop.UseVisualStyleBackColor = True
      '
      '_btnMoveLeft
      '
      Me._btnMoveLeft.Location = New System.Drawing.Point(173, 157)
      Me._btnMoveLeft.Name = "_btnMoveLeft"
      Me._btnMoveLeft.Size = New System.Drawing.Size(32, 32)
      Me._btnMoveLeft.TabIndex = 16
      Me._btnMoveLeft.UseVisualStyleBackColor = True
      '
      '_btnMoveRight
      '
      Me._btnMoveRight.Location = New System.Drawing.Point(173, 119)
      Me._btnMoveRight.Name = "_btnMoveRight"
      Me._btnMoveRight.Size = New System.Drawing.Size(32, 32)
      Me._btnMoveRight.TabIndex = 15
      Me._btnMoveRight.UseVisualStyleBackColor = True
      '
      '_enabledLanguagesListBox
      '
      Me._enabledLanguagesListBox.FormattingEnabled = True
      Me._enabledLanguagesListBox.Location = New System.Drawing.Point(211, 41)
      Me._enabledLanguagesListBox.Name = "_enabledLanguagesListBox"
      Me._enabledLanguagesListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
      Me._enabledLanguagesListBox.Size = New System.Drawing.Size(161, 264)
      Me._enabledLanguagesListBox.TabIndex = 14
      '
      '_mainLanguageLabel
      '
      Me._mainLanguageLabel.Anchor = System.Windows.Forms.AnchorStyles.Left
      Me._mainLanguageLabel.AutoSize = True
      Me._mainLanguageLabel.Location = New System.Drawing.Point(6, 318)
      Me._mainLanguageLabel.Name = "_mainLanguageLabel"
      Me._mainLanguageLabel.Size = New System.Drawing.Size(341, 13)
      Me._mainLanguageLabel.TabIndex = 12
      Me._mainLanguageLabel.Text = "Hint: The main language is the first item in the 'Enabled Languages' list."
      '
      '_additionalLabel
      '
      Me._additionalLabel.Anchor = System.Windows.Forms.AnchorStyles.None
      Me._additionalLabel.Location = New System.Drawing.Point(6, 339)
      Me._additionalLabel.Name = "_additionalLabel"
      Me._additionalLabel.Size = New System.Drawing.Size(404, 66)
      Me._additionalLabel.TabIndex = 13
      '
      '_languagesListBox
      '
      Me._languagesListBox.FormattingEnabled = True
      Me._languagesListBox.Location = New System.Drawing.Point(6, 41)
      Me._languagesListBox.Name = "_languagesListBox"
      Me._languagesListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
      Me._languagesListBox.Size = New System.Drawing.Size(161, 264)
      Me._languagesListBox.TabIndex = 11
      '
      'EnableLanguagesDialog
      '
      Me.AcceptButton = Me._okButton
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.CancelButton = Me._cancelButton
      Me.ClientSize = New System.Drawing.Size(446, 464)
      Me.Controls.Add(Me.groupBox1)
      Me.Controls.Add(Me._cancelButton)
      Me.Controls.Add(Me._okButton)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "EnableLanguagesDialog"
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
      Me.Text = "Enable Languages"
      Me.groupBox1.ResumeLayout(False)
      Me.groupBox1.PerformLayout()
      Me.ResumeLayout(False)

   End Sub

#End Region

   Private WithEvents _okButton As System.Windows.Forms.Button
   Private _cancelButton As System.Windows.Forms.Button
   Private groupBox1 As System.Windows.Forms.GroupBox
   Private label2 As System.Windows.Forms.Label
   Private label1 As System.Windows.Forms.Label
   Private WithEvents _btnMoveTop As System.Windows.Forms.Button
   Private WithEvents _btnMoveLeft As System.Windows.Forms.Button
   Private WithEvents _btnMoveRight As System.Windows.Forms.Button
   Private WithEvents _enabledLanguagesListBox As System.Windows.Forms.ListBox
   Private _mainLanguageLabel As System.Windows.Forms.Label
   Private _additionalLabel As System.Windows.Forms.Label
   Private WithEvents _languagesListBox As System.Windows.Forms.ListBox
End Class