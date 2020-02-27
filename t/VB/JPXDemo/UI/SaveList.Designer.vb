<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SaveList
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SaveList))
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
      Me._btnRemoveAll = New System.Windows.Forms.Button
      Me._btnAddAll = New System.Windows.Forms.Button
      Me._btnRemove = New System.Windows.Forms.Button
      Me._btnAdd = New System.Windows.Forms.Button
      Me._lstSelectedImages = New System.Windows.Forms.ListBox
      Me._lblSelectedImages = New System.Windows.Forms.Label
      Me._lstAvailableImages = New System.Windows.Forms.ListBox
      Me._lblAvailableImages = New System.Windows.Forms.Label
      Me._cbQualityFactor = New System.Windows.Forms.ComboBox
      Me.SuspendLayout()
      '
      'label1
      '
      Me.label1.AutoSize = True
      Me.label1.Location = New System.Drawing.Point(86, 267)
      Me.label1.Name = "label1"
      Me.label1.Size = New System.Drawing.Size(72, 13)
      Me.label1.TabIndex = 39
      Me.label1.Text = "&Quality Factor"
      '
      '_cbBPP
      '
      Me._cbBPP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me._cbBPP.FormattingEnabled = True
      Me._cbBPP.Location = New System.Drawing.Point(34, 264)
      Me._cbBPP.Name = "_cbBPP"
      Me._cbBPP.Size = New System.Drawing.Size(43, 21)
      Me._cbBPP.TabIndex = 38
      '
      '_lblBPP
      '
      Me._lblBPP.AutoSize = True
      Me._lblBPP.Location = New System.Drawing.Point(5, 267)
      Me._lblBPP.Name = "_lblBPP"
      Me._lblBPP.Size = New System.Drawing.Size(28, 13)
      Me._lblBPP.TabIndex = 37
      Me._lblBPP.Text = "BP&P"
      '
      '_btnCancel
      '
      Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me._btnCancel.Location = New System.Drawing.Point(455, 262)
      Me._btnCancel.Name = "_btnCancel"
      Me._btnCancel.Size = New System.Drawing.Size(75, 23)
      Me._btnCancel.TabIndex = 36
      Me._btnCancel.Text = "&Cancel"
      Me._btnCancel.UseVisualStyleBackColor = True
      '
      '_btnSave
      '
      Me._btnSave.Location = New System.Drawing.Point(375, 262)
      Me._btnSave.Name = "_btnSave"
      Me._btnSave.Size = New System.Drawing.Size(75, 23)
      Me._btnSave.TabIndex = 35
      Me._btnSave.Text = "&Save"
      Me._btnSave.UseVisualStyleBackColor = True
      '
      '_btnBrowse
      '
      Me._btnBrowse.Location = New System.Drawing.Point(455, 230)
      Me._btnBrowse.Name = "_btnBrowse"
      Me._btnBrowse.Size = New System.Drawing.Size(75, 23)
      Me._btnBrowse.TabIndex = 34
      Me._btnBrowse.Text = "&Browse"
      Me._btnBrowse.UseVisualStyleBackColor = True
      '
      '_txtFileName
      '
      Me._txtFileName.Location = New System.Drawing.Point(8, 232)
      Me._txtFileName.Name = "_txtFileName"
      Me._txtFileName.ReadOnly = True
      Me._txtFileName.Size = New System.Drawing.Size(440, 20)
      Me._txtFileName.TabIndex = 33
      '
      '_lblFileName
      '
      Me._lblFileName.AutoSize = True
      Me._lblFileName.Location = New System.Drawing.Point(5, 216)
      Me._lblFileName.Name = "_lblFileName"
      Me._lblFileName.Size = New System.Drawing.Size(54, 13)
      Me._lblFileName.TabIndex = 32
      Me._lblFileName.Text = "File Name"
      '
      '_btnDown
      '
      Me._btnDown.Image = CType(resources.GetObject("_btnDown.Image"), System.Drawing.Image)
      Me._btnDown.Location = New System.Drawing.Point(247, 186)
      Me._btnDown.Name = "_btnDown"
      Me._btnDown.Size = New System.Drawing.Size(41, 23)
      Me._btnDown.TabIndex = 31
      Me._btnDown.UseVisualStyleBackColor = True
      '
      '_btnUp
      '
      Me._btnUp.Image = CType(resources.GetObject("_btnUp.Image"), System.Drawing.Image)
      Me._btnUp.Location = New System.Drawing.Point(247, 157)
      Me._btnUp.Name = "_btnUp"
      Me._btnUp.Size = New System.Drawing.Size(41, 23)
      Me._btnUp.TabIndex = 30
      Me._btnUp.UseVisualStyleBackColor = True
      '
      '_btnRemoveAll
      '
      Me._btnRemoveAll.Location = New System.Drawing.Point(250, 116)
      Me._btnRemoveAll.Name = "_btnRemoveAll"
      Me._btnRemoveAll.Size = New System.Drawing.Size(32, 23)
      Me._btnRemoveAll.TabIndex = 29
      Me._btnRemoveAll.Text = "<<"
      Me._btnRemoveAll.UseVisualStyleBackColor = True
      '
      '_btnAddAll
      '
      Me._btnAddAll.Location = New System.Drawing.Point(250, 87)
      Me._btnAddAll.Name = "_btnAddAll"
      Me._btnAddAll.Size = New System.Drawing.Size(32, 23)
      Me._btnAddAll.TabIndex = 28
      Me._btnAddAll.Text = ">>"
      Me._btnAddAll.UseVisualStyleBackColor = True
      '
      '_btnRemove
      '
      Me._btnRemove.Location = New System.Drawing.Point(250, 58)
      Me._btnRemove.Name = "_btnRemove"
      Me._btnRemove.Size = New System.Drawing.Size(32, 23)
      Me._btnRemove.TabIndex = 27
      Me._btnRemove.Text = "<"
      Me._btnRemove.UseVisualStyleBackColor = True
      '
      '_btnAdd
      '
      Me._btnAdd.Location = New System.Drawing.Point(250, 29)
      Me._btnAdd.Name = "_btnAdd"
      Me._btnAdd.Size = New System.Drawing.Size(32, 23)
      Me._btnAdd.TabIndex = 26
      Me._btnAdd.Text = ">"
      Me._btnAdd.UseVisualStyleBackColor = True
      '
      '_lstSelectedImages
      '
      Me._lstSelectedImages.FormattingEnabled = True
      Me._lstSelectedImages.Location = New System.Drawing.Point(292, 26)
      Me._lstSelectedImages.Name = "_lstSelectedImages"
      Me._lstSelectedImages.Size = New System.Drawing.Size(234, 186)
      Me._lstSelectedImages.TabIndex = 25
      '
      '_lblSelectedImages
      '
      Me._lblSelectedImages.AutoSize = True
      Me._lblSelectedImages.Location = New System.Drawing.Point(299, 8)
      Me._lblSelectedImages.Name = "_lblSelectedImages"
      Me._lblSelectedImages.Size = New System.Drawing.Size(86, 13)
      Me._lblSelectedImages.TabIndex = 24
      Me._lblSelectedImages.Text = "Se&lected Images"
      '
      '_lstAvailableImages
      '
      Me._lstAvailableImages.FormattingEnabled = True
      Me._lstAvailableImages.Location = New System.Drawing.Point(8, 26)
      Me._lstAvailableImages.Name = "_lstAvailableImages"
      Me._lstAvailableImages.Size = New System.Drawing.Size(234, 186)
      Me._lstAvailableImages.TabIndex = 23
      '
      '_lblAvailableImages
      '
      Me._lblAvailableImages.AutoSize = True
      Me._lblAvailableImages.Location = New System.Drawing.Point(5, 8)
      Me._lblAvailableImages.Name = "_lblAvailableImages"
      Me._lblAvailableImages.Size = New System.Drawing.Size(87, 13)
      Me._lblAvailableImages.TabIndex = 22
      Me._lblAvailableImages.Text = "&Available Images"
      '
      '_cbQualityFactor
      '
      Me._cbQualityFactor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me._cbQualityFactor.FormattingEnabled = True
      Me._cbQualityFactor.Location = New System.Drawing.Point(165, 264)
      Me._cbQualityFactor.Name = "_cbQualityFactor"
      Me._cbQualityFactor.Size = New System.Drawing.Size(77, 21)
      Me._cbQualityFactor.TabIndex = 59
      '
      'SaveList
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.CancelButton = Me._btnCancel
      Me.ClientSize = New System.Drawing.Size(534, 293)
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
      Me.Controls.Add(Me._btnRemoveAll)
      Me.Controls.Add(Me._btnAddAll)
      Me.Controls.Add(Me._btnRemove)
      Me.Controls.Add(Me._btnAdd)
      Me.Controls.Add(Me._lstSelectedImages)
      Me.Controls.Add(Me._lblSelectedImages)
      Me.Controls.Add(Me._lstAvailableImages)
      Me.Controls.Add(Me._lblAvailableImages)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "SaveList"
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
      Me.Text = "Save List"
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
   Private WithEvents _btnRemoveAll As System.Windows.Forms.Button
   Private WithEvents _btnAddAll As System.Windows.Forms.Button
   Private WithEvents _btnRemove As System.Windows.Forms.Button
   Private WithEvents _btnAdd As System.Windows.Forms.Button
   Private WithEvents _lstSelectedImages As System.Windows.Forms.ListBox
   Private WithEvents _lblSelectedImages As System.Windows.Forms.Label
   Private WithEvents _lstAvailableImages As System.Windows.Forms.ListBox
   Private WithEvents _lblAvailableImages As System.Windows.Forms.Label
   Private WithEvents _cbQualityFactor As System.Windows.Forms.ComboBox
End Class
