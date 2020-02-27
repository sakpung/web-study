<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SaveComposite
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SaveComposite))
      Me.label1 = New System.Windows.Forms.Label
      Me._cbBPP = New System.Windows.Forms.ComboBox
      Me._lblBPP = New System.Windows.Forms.Label
      Me._btnCancel = New System.Windows.Forms.Button
      Me._btnSave = New System.Windows.Forms.Button
      Me._btnBrowse = New System.Windows.Forms.Button
      Me._txtFileName = New System.Windows.Forms.TextBox
      Me._lblFileName = New System.Windows.Forms.Label
      Me._btnDown = New System.Windows.Forms.Button
      Me._btnUp = New System.Windows.Forms.Button
      Me._btnDelete = New System.Windows.Forms.Button
      Me._btnMoveDown = New System.Windows.Forms.Button
      Me._btnMoveUp = New System.Windows.Forms.Button
      Me._lblPreOpacotyImages = New System.Windows.Forms.Label
      Me._rbPreopacity = New System.Windows.Forms.RadioButton
      Me._rbOpacity = New System.Windows.Forms.RadioButton
      Me._lstPreOpacityImages = New System.Windows.Forms.ListBox
      Me._lblOpacityImages = New System.Windows.Forms.Label
      Me._lstOpacityImages = New System.Windows.Forms.ListBox
      Me._lblColorImages = New System.Windows.Forms.Label
      Me._lstColorImages = New System.Windows.Forms.ListBox
      Me._btnAdd = New System.Windows.Forms.Button
      Me._cbAvailableOpacityImages = New System.Windows.Forms.ComboBox
      Me._cbAvailableColorImages = New System.Windows.Forms.ComboBox
      Me._lblAvailableColorImages = New System.Windows.Forms.Label
      Me._grpOpacity = New System.Windows.Forms.GroupBox
      Me._cbUseOpacity = New System.Windows.Forms.CheckBox
      Me._lblAvailableOpacityImages = New System.Windows.Forms.Label
      Me._cbQualityFactor = New System.Windows.Forms.ComboBox
      Me._grpOpacity.SuspendLayout()
      Me.SuspendLayout()
      '
      'label1
      '
      Me.label1.AutoSize = True
      Me.label1.Location = New System.Drawing.Point(88, 306)
      Me.label1.Name = "label1"
      Me.label1.Size = New System.Drawing.Size(72, 13)
      Me.label1.TabIndex = 57
      Me.label1.Text = "&Quality Factor"
      '
      '_cbBPP
      '
      Me._cbBPP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me._cbBPP.FormattingEnabled = True
      Me._cbBPP.Location = New System.Drawing.Point(39, 303)
      Me._cbBPP.Name = "_cbBPP"
      Me._cbBPP.Size = New System.Drawing.Size(43, 21)
      Me._cbBPP.TabIndex = 56
      '
      '_lblBPP
      '
      Me._lblBPP.AutoSize = True
      Me._lblBPP.Location = New System.Drawing.Point(5, 306)
      Me._lblBPP.Name = "_lblBPP"
      Me._lblBPP.Size = New System.Drawing.Size(28, 13)
      Me._lblBPP.TabIndex = 55
      Me._lblBPP.Text = "BP&P"
      '
      '_btnCancel
      '
      Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me._btnCancel.Location = New System.Drawing.Point(463, 301)
      Me._btnCancel.Name = "_btnCancel"
      Me._btnCancel.Size = New System.Drawing.Size(75, 23)
      Me._btnCancel.TabIndex = 54
      Me._btnCancel.Text = "&Cancel"
      Me._btnCancel.UseVisualStyleBackColor = True
      '
      '_btnSave
      '
      Me._btnSave.Location = New System.Drawing.Point(382, 301)
      Me._btnSave.Name = "_btnSave"
      Me._btnSave.Size = New System.Drawing.Size(75, 23)
      Me._btnSave.TabIndex = 53
      Me._btnSave.Text = "&Save"
      Me._btnSave.UseVisualStyleBackColor = True
      '
      '_btnBrowse
      '
      Me._btnBrowse.Location = New System.Drawing.Point(463, 272)
      Me._btnBrowse.Name = "_btnBrowse"
      Me._btnBrowse.Size = New System.Drawing.Size(75, 23)
      Me._btnBrowse.TabIndex = 52
      Me._btnBrowse.Text = "&Browse"
      Me._btnBrowse.UseVisualStyleBackColor = True
      '
      '_txtFileName
      '
      Me._txtFileName.Location = New System.Drawing.Point(10, 275)
      Me._txtFileName.Name = "_txtFileName"
      Me._txtFileName.ReadOnly = True
      Me._txtFileName.Size = New System.Drawing.Size(447, 20)
      Me._txtFileName.TabIndex = 51
      '
      '_lblFileName
      '
      Me._lblFileName.AutoSize = True
      Me._lblFileName.Location = New System.Drawing.Point(7, 259)
      Me._lblFileName.Name = "_lblFileName"
      Me._lblFileName.Size = New System.Drawing.Size(54, 13)
      Me._lblFileName.TabIndex = 50
      Me._lblFileName.Text = "File Name"
      '
      '_btnDown
      '
      Me._btnDown.Image = CType(resources.GetObject("_btnDown.Image"), System.Drawing.Image)
      Me._btnDown.Location = New System.Drawing.Point(475, 232)
      Me._btnDown.Name = "_btnDown"
      Me._btnDown.Size = New System.Drawing.Size(49, 23)
      Me._btnDown.TabIndex = 49
      Me._btnDown.UseVisualStyleBackColor = True
      '
      '_btnUp
      '
      Me._btnUp.Image = CType(resources.GetObject("_btnUp.Image"), System.Drawing.Image)
      Me._btnUp.Location = New System.Drawing.Point(475, 203)
      Me._btnUp.Name = "_btnUp"
      Me._btnUp.Size = New System.Drawing.Size(49, 23)
      Me._btnUp.TabIndex = 48
      Me._btnUp.UseVisualStyleBackColor = True
      '
      '_btnDelete
      '
      Me._btnDelete.Location = New System.Drawing.Point(462, 165)
      Me._btnDelete.Name = "_btnDelete"
      Me._btnDelete.Size = New System.Drawing.Size(75, 23)
      Me._btnDelete.TabIndex = 47
      Me._btnDelete.Text = "D&elete"
      Me._btnDelete.UseVisualStyleBackColor = True
      '
      '_btnMoveDown
      '
      Me._btnMoveDown.Location = New System.Drawing.Point(462, 136)
      Me._btnMoveDown.Name = "_btnMoveDown"
      Me._btnMoveDown.Size = New System.Drawing.Size(75, 23)
      Me._btnMoveDown.TabIndex = 46
      Me._btnMoveDown.Text = "Move D&own"
      Me._btnMoveDown.UseVisualStyleBackColor = True
      '
      '_btnMoveUp
      '
      Me._btnMoveUp.Location = New System.Drawing.Point(462, 108)
      Me._btnMoveUp.Name = "_btnMoveUp"
      Me._btnMoveUp.Size = New System.Drawing.Size(75, 23)
      Me._btnMoveUp.TabIndex = 45
      Me._btnMoveUp.Text = "Move U&p"
      Me._btnMoveUp.UseVisualStyleBackColor = True
      '
      '_lblPreOpacotyImages
      '
      Me._lblPreOpacotyImages.AutoSize = True
      Me._lblPreOpacotyImages.Location = New System.Drawing.Point(331, 90)
      Me._lblPreOpacotyImages.Name = "_lblPreOpacotyImages"
      Me._lblPreOpacotyImages.Size = New System.Drawing.Size(96, 13)
      Me._lblPreOpacotyImages.TabIndex = 44
      Me._lblPreOpacotyImages.Text = "PreOpacity Images"
      '
      '_rbPreopacity
      '
      Me._rbPreopacity.AutoSize = True
      Me._rbPreopacity.Location = New System.Drawing.Point(20, 48)
      Me._rbPreopacity.Name = "_rbPreopacity"
      Me._rbPreopacity.Size = New System.Drawing.Size(77, 17)
      Me._rbPreopacity.TabIndex = 2
      Me._rbPreopacity.TabStop = True
      Me._rbPreopacity.Text = "PreOpacity"
      Me._rbPreopacity.UseVisualStyleBackColor = True
      '
      '_rbOpacity
      '
      Me._rbOpacity.AutoSize = True
      Me._rbOpacity.Location = New System.Drawing.Point(20, 23)
      Me._rbOpacity.Name = "_rbOpacity"
      Me._rbOpacity.Size = New System.Drawing.Size(58, 17)
      Me._rbOpacity.TabIndex = 1
      Me._rbOpacity.TabStop = True
      Me._rbOpacity.Text = "&Opaciy"
      Me._rbOpacity.UseVisualStyleBackColor = True
      '
      '_lstPreOpacityImages
      '
      Me._lstPreOpacityImages.FormattingEnabled = True
      Me._lstPreOpacityImages.Location = New System.Drawing.Point(307, 108)
      Me._lstPreOpacityImages.Name = "_lstPreOpacityImages"
      Me._lstPreOpacityImages.Size = New System.Drawing.Size(149, 147)
      Me._lstPreOpacityImages.TabIndex = 43
      '
      '_lblOpacityImages
      '
      Me._lblOpacityImages.AutoSize = True
      Me._lblOpacityImages.Location = New System.Drawing.Point(188, 90)
      Me._lblOpacityImages.Name = "_lblOpacityImages"
      Me._lblOpacityImages.Size = New System.Drawing.Size(80, 13)
      Me._lblOpacityImages.TabIndex = 42
      Me._lblOpacityImages.Text = "Opacity Images"
      '
      '_lstOpacityImages
      '
      Me._lstOpacityImages.FormattingEnabled = True
      Me._lstOpacityImages.Location = New System.Drawing.Point(158, 108)
      Me._lstOpacityImages.Name = "_lstOpacityImages"
      Me._lstOpacityImages.Size = New System.Drawing.Size(149, 147)
      Me._lstOpacityImages.TabIndex = 41
      '
      '_lblColorImages
      '
      Me._lblColorImages.AutoSize = True
      Me._lblColorImages.Location = New System.Drawing.Point(45, 90)
      Me._lblColorImages.Name = "_lblColorImages"
      Me._lblColorImages.Size = New System.Drawing.Size(68, 13)
      Me._lblColorImages.TabIndex = 40
      Me._lblColorImages.Text = "Color Images"
      '
      '_lstColorImages
      '
      Me._lstColorImages.FormattingEnabled = True
      Me._lstColorImages.Location = New System.Drawing.Point(9, 108)
      Me._lstColorImages.Name = "_lstColorImages"
      Me._lstColorImages.Size = New System.Drawing.Size(149, 147)
      Me._lstColorImages.TabIndex = 39
      '
      '_btnAdd
      '
      Me._btnAdd.Location = New System.Drawing.Point(322, 59)
      Me._btnAdd.Name = "_btnAdd"
      Me._btnAdd.Size = New System.Drawing.Size(75, 23)
      Me._btnAdd.TabIndex = 38
      Me._btnAdd.Text = "&Add"
      Me._btnAdd.UseVisualStyleBackColor = True
      '
      '_cbAvailableOpacityImages
      '
      Me._cbAvailableOpacityImages.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me._cbAvailableOpacityImages.FormattingEnabled = True
      Me._cbAvailableOpacityImages.Location = New System.Drawing.Point(216, 31)
      Me._cbAvailableOpacityImages.Name = "_cbAvailableOpacityImages"
      Me._cbAvailableOpacityImages.Size = New System.Drawing.Size(181, 21)
      Me._cbAvailableOpacityImages.TabIndex = 37
      '
      '_cbAvailableColorImages
      '
      Me._cbAvailableColorImages.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me._cbAvailableColorImages.FormattingEnabled = True
      Me._cbAvailableColorImages.Location = New System.Drawing.Point(15, 31)
      Me._cbAvailableColorImages.Name = "_cbAvailableColorImages"
      Me._cbAvailableColorImages.Size = New System.Drawing.Size(181, 21)
      Me._cbAvailableColorImages.TabIndex = 34
      '
      '_lblAvailableColorImages
      '
      Me._lblAvailableColorImages.AutoSize = True
      Me._lblAvailableColorImages.Location = New System.Drawing.Point(12, 10)
      Me._lblAvailableColorImages.Name = "_lblAvailableColorImages"
      Me._lblAvailableColorImages.Size = New System.Drawing.Size(114, 13)
      Me._lblAvailableColorImages.TabIndex = 33
      Me._lblAvailableColorImages.Text = "Available Color Images"
      '
      '_grpOpacity
      '
      Me._grpOpacity.Controls.Add(Me._rbPreopacity)
      Me._grpOpacity.Controls.Add(Me._rbOpacity)
      Me._grpOpacity.Controls.Add(Me._cbUseOpacity)
      Me._grpOpacity.Location = New System.Drawing.Point(410, 7)
      Me._grpOpacity.Name = "_grpOpacity"
      Me._grpOpacity.Size = New System.Drawing.Size(120, 75)
      Me._grpOpacity.TabIndex = 35
      Me._grpOpacity.TabStop = False
      '
      '_cbUseOpacity
      '
      Me._cbUseOpacity.AutoSize = True
      Me._cbUseOpacity.Location = New System.Drawing.Point(6, 0)
      Me._cbUseOpacity.Name = "_cbUseOpacity"
      Me._cbUseOpacity.Size = New System.Drawing.Size(84, 17)
      Me._cbUseOpacity.TabIndex = 0
      Me._cbUseOpacity.Text = "&Use Opacity"
      Me._cbUseOpacity.UseVisualStyleBackColor = True
      '
      '_lblAvailableOpacityImages
      '
      Me._lblAvailableOpacityImages.AutoSize = True
      Me._lblAvailableOpacityImages.Location = New System.Drawing.Point(213, 10)
      Me._lblAvailableOpacityImages.Name = "_lblAvailableOpacityImages"
      Me._lblAvailableOpacityImages.Size = New System.Drawing.Size(126, 13)
      Me._lblAvailableOpacityImages.TabIndex = 36
      Me._lblAvailableOpacityImages.Text = "Available Opacity Images"
      '
      '_cbQualityFactor
      '
      Me._cbQualityFactor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me._cbQualityFactor.FormattingEnabled = True
      Me._cbQualityFactor.Location = New System.Drawing.Point(165, 303)
      Me._cbQualityFactor.Name = "_cbQualityFactor"
      Me._cbQualityFactor.Size = New System.Drawing.Size(77, 21)
      Me._cbQualityFactor.TabIndex = 58
      '
      'SaveComposite
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.CancelButton = Me._btnCancel
      Me.ClientSize = New System.Drawing.Size(542, 330)
      Me.Controls.Add(Me._cbQualityFactor)
      Me.Controls.Add(Me.label1)
      Me.Controls.Add(Me._cbBPP)
      Me.Controls.Add(Me._lblBPP)
      Me.Controls.Add(Me._btnCancel)
      Me.Controls.Add(Me._btnSave)
      Me.Controls.Add(Me._btnBrowse)
      Me.Controls.Add(Me._txtFileName)
      Me.Controls.Add(Me._lblFileName)
      Me.Controls.Add(Me._btnDown)
      Me.Controls.Add(Me._btnUp)
      Me.Controls.Add(Me._btnDelete)
      Me.Controls.Add(Me._btnMoveDown)
      Me.Controls.Add(Me._btnMoveUp)
      Me.Controls.Add(Me._lblPreOpacotyImages)
      Me.Controls.Add(Me._lstPreOpacityImages)
      Me.Controls.Add(Me._lblOpacityImages)
      Me.Controls.Add(Me._lstOpacityImages)
      Me.Controls.Add(Me._lblColorImages)
      Me.Controls.Add(Me._lstColorImages)
      Me.Controls.Add(Me._btnAdd)
      Me.Controls.Add(Me._cbAvailableOpacityImages)
      Me.Controls.Add(Me._cbAvailableColorImages)
      Me.Controls.Add(Me._lblAvailableColorImages)
      Me.Controls.Add(Me._grpOpacity)
      Me.Controls.Add(Me._lblAvailableOpacityImages)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "SaveComposite"
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
      Me.Text = "SaveComposite"
      Me._grpOpacity.ResumeLayout(False)
      Me._grpOpacity.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Private WithEvents label1 As System.Windows.Forms.Label
   Private WithEvents _cbBPP As System.Windows.Forms.ComboBox
   Private WithEvents _lblBPP As System.Windows.Forms.Label
   Private WithEvents _btnCancel As System.Windows.Forms.Button
   Private WithEvents _btnSave As System.Windows.Forms.Button
   Private WithEvents _btnBrowse As System.Windows.Forms.Button
   Private WithEvents _txtFileName As System.Windows.Forms.TextBox
   Private WithEvents _lblFileName As System.Windows.Forms.Label
   Private WithEvents _btnDown As System.Windows.Forms.Button
   Private WithEvents _btnUp As System.Windows.Forms.Button
   Private WithEvents _btnDelete As System.Windows.Forms.Button
   Private WithEvents _btnMoveDown As System.Windows.Forms.Button
   Private WithEvents _btnMoveUp As System.Windows.Forms.Button
   Private WithEvents _lblPreOpacotyImages As System.Windows.Forms.Label
   Private WithEvents _rbPreopacity As System.Windows.Forms.RadioButton
   Private WithEvents _rbOpacity As System.Windows.Forms.RadioButton
   Private WithEvents _lstPreOpacityImages As System.Windows.Forms.ListBox
   Private WithEvents _lblOpacityImages As System.Windows.Forms.Label
   Private WithEvents _lstOpacityImages As System.Windows.Forms.ListBox
   Private WithEvents _lblColorImages As System.Windows.Forms.Label
   Private WithEvents _lstColorImages As System.Windows.Forms.ListBox
   Private WithEvents _btnAdd As System.Windows.Forms.Button
   Private WithEvents _cbAvailableOpacityImages As System.Windows.Forms.ComboBox
   Private WithEvents _cbAvailableColorImages As System.Windows.Forms.ComboBox
   Private WithEvents _lblAvailableColorImages As System.Windows.Forms.Label
   Private WithEvents _grpOpacity As System.Windows.Forms.GroupBox
   Private WithEvents _cbUseOpacity As System.Windows.Forms.CheckBox
   Private WithEvents _lblAvailableOpacityImages As System.Windows.Forms.Label
   Private WithEvents _cbQualityFactor As System.Windows.Forms.ComboBox
End Class
