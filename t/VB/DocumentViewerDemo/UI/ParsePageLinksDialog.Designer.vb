
Partial Class ParsePageLinksDialog
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
      Dim resources As New System.ComponentModel.ComponentResourceManager(GetType(ParsePageLinksDialog))
      Me._noButton = New System.Windows.Forms.Button()
      Me._yesButton = New System.Windows.Forms.Button()
      Me._infoLabel = New System.Windows.Forms.Label()
      Me._rememberDecisionCheckBox = New System.Windows.Forms.CheckBox()
      Me.SuspendLayout()
      ' 
      ' _noButton
      ' 
      Me._noButton.DialogResult = System.Windows.Forms.DialogResult.No
      Me._noButton.Location = New System.Drawing.Point(380, 101)
      Me._noButton.Name = "_noButton"
      Me._noButton.Size = New System.Drawing.Size(75, 23)
      Me._noButton.TabIndex = 3
      Me._noButton.Text = "No"
      Me._noButton.UseVisualStyleBackColor = True
      ' 
      ' _yesButton
      ' 
      Me._yesButton.DialogResult = System.Windows.Forms.DialogResult.Yes
      Me._yesButton.Location = New System.Drawing.Point(299, 101)
      Me._yesButton.Name = "_yesButton"
      Me._yesButton.Size = New System.Drawing.Size(75, 23)
      Me._yesButton.TabIndex = 2
      Me._yesButton.Text = "Yes"
      Me._yesButton.UseVisualStyleBackColor = True
      '
      ' _infoLabel
      ' 
      Me._infoLabel.Location = New System.Drawing.Point(13, 13)
      Me._infoLabel.Name = "_infoLabel"
      Me._infoLabel.Size = New System.Drawing.Size(442, 69)
      Me._infoLabel.TabIndex = 0
      Me._infoLabel.Text = resources.GetString("_infoLabel.Text")
      ' 
      ' _rememberDecisionCheckBox
      ' 
      Me._rememberDecisionCheckBox.AutoSize = True
      Me._rememberDecisionCheckBox.Location = New System.Drawing.Point(16, 101)
      Me._rememberDecisionCheckBox.Name = "_rememberDecisionCheckBox"
      Me._rememberDecisionCheckBox.Size = New System.Drawing.Size(135, 17)
      Me._rememberDecisionCheckBox.TabIndex = 1
      Me._rememberDecisionCheckBox.Text = "&Remember my decision"
      Me._rememberDecisionCheckBox.UseVisualStyleBackColor = True
      ' 
      ' ParsePageLinksDialog
      ' 
      Me.AcceptButton = Me._noButton
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.CancelButton = Me._yesButton
      Me.ClientSize = New System.Drawing.Size(467, 139)
      Me.Controls.Add(Me._rememberDecisionCheckBox)
      Me.Controls.Add(Me._infoLabel)
      Me.Controls.Add(Me._yesButton)
      Me.Controls.Add(Me._noButton)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "ParsePageLinksDialog"
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
      Me.Text = "Parse Page Links"
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub

#End Region

   Private WithEvents _noButton As System.Windows.Forms.Button
   Private WithEvents _yesButton As System.Windows.Forms.Button
   Private _infoLabel As System.Windows.Forms.Label
   Private _rememberDecisionCheckBox As System.Windows.Forms.CheckBox
End Class