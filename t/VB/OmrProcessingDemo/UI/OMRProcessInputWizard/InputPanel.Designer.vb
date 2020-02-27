Partial Class InputPanel
   Private components As System.ComponentModel.IContainer = Nothing

   Protected Overrides Sub Dispose(ByVal disposing As Boolean)
      If disposing AndAlso (components IsNot Nothing) Then
         components.Dispose()
      End If

      MyBase.Dispose(disposing)
   End Sub

   Private Sub InitializeComponent()
      Me.btnChooseFile = New System.Windows.Forms.Button()
      Me.btnScan = New System.Windows.Forms.Button()
      Me.chkFiles = New System.Windows.Forms.CheckedListBox()
      Me.btnChooseFolderofFiles = New System.Windows.Forms.Button()
      Me.btnChooseWorkspaceFilename = New System.Windows.Forms.Button()
      Me.txtSavePath = New System.Windows.Forms.TextBox()
      Me.lblWorkspaceFilename = New System.Windows.Forms.Label()
      Me.chkSaveWorkspace = New System.Windows.Forms.CheckBox()
      Me.btnRemoveUnchecked = New System.Windows.Forms.Button()
      Me.SuspendLayout()
      Me.btnChooseFile.Location = New System.Drawing.Point(3, 3)
      Me.btnChooseFile.Name = "btnChooseFile"
      Me.btnChooseFile.Size = New System.Drawing.Size(75, 23)
      Me.btnChooseFile.TabIndex = 1
      Me.btnChooseFile.Text = "&Choose Files"
      Me.btnChooseFile.UseVisualStyleBackColor = True
      AddHandler Me.btnChooseFile.Click, AddressOf Me.btnChooseFile_Click
      Me.btnScan.Location = New System.Drawing.Point(218, 3)
      Me.btnScan.Name = "btnScan"
      Me.btnScan.Size = New System.Drawing.Size(75, 23)
      Me.btnScan.TabIndex = 2
      Me.btnScan.Text = "&Scan Files"
      Me.btnScan.UseVisualStyleBackColor = True
      AddHandler Me.btnScan.Click, AddressOf Me.btnScan_Click
      Me.chkFiles.CheckOnClick = True
      Me.chkFiles.FormattingEnabled = True
      Me.chkFiles.Location = New System.Drawing.Point(3, 32)
      Me.chkFiles.Name = "chkFiles"
      Me.chkFiles.Size = New System.Drawing.Size(611, 109)
      Me.chkFiles.TabIndex = 3
      Me.btnChooseFolderofFiles.Location = New System.Drawing.Point(84, 3)
      Me.btnChooseFolderofFiles.Name = "btnChooseFolderofFiles"
      Me.btnChooseFolderofFiles.Size = New System.Drawing.Size(128, 23)
      Me.btnChooseFolderofFiles.TabIndex = 4
      Me.btnChooseFolderofFiles.Text = "Choose &Folder of Files"
      Me.btnChooseFolderofFiles.UseVisualStyleBackColor = True
      AddHandler Me.btnChooseFolderofFiles.Click, AddressOf Me.btnChooseFolderofFiles_Click
      Me.btnChooseWorkspaceFilename.Location = New System.Drawing.Point(539, 173)
      Me.btnChooseWorkspaceFilename.Name = "btnChooseWorkspaceFilename"
      Me.btnChooseWorkspaceFilename.Size = New System.Drawing.Size(75, 23)
      Me.btnChooseWorkspaceFilename.TabIndex = 14
      Me.btnChooseWorkspaceFilename.Text = "&Choose File"
      Me.btnChooseWorkspaceFilename.UseVisualStyleBackColor = True
      AddHandler Me.btnChooseWorkspaceFilename.Click, AddressOf Me.btnChooseWorkspaceFilename_Click
      Me.txtSavePath.Location = New System.Drawing.Point(142, 175)
      Me.txtSavePath.Name = "txtSavePath"
      Me.txtSavePath.Size = New System.Drawing.Size(391, 20)
      Me.txtSavePath.TabIndex = 13
      AddHandler Me.txtSavePath.TextChanged, AddressOf Me.txtSavePath_TextChanged
      Me.lblWorkspaceFilename.AutoSize = True
      Me.lblWorkspaceFilename.Location = New System.Drawing.Point(26, 178)
      Me.lblWorkspaceFilename.Name = "lblWorkspaceFilename"
      Me.lblWorkspaceFilename.Size = New System.Drawing.Size(110, 13)
      Me.lblWorkspaceFilename.TabIndex = 12
      Me.lblWorkspaceFilename.Text = "Workspace Filename:"
      Me.chkSaveWorkspace.AutoSize = True
      Me.chkSaveWorkspace.Checked = True
      Me.chkSaveWorkspace.CheckState = System.Windows.Forms.CheckState.Checked
      Me.chkSaveWorkspace.Location = New System.Drawing.Point(3, 146)
      Me.chkSaveWorkspace.Name = "chkSaveWorkspace"
      Me.chkSaveWorkspace.Size = New System.Drawing.Size(269, 17)
      Me.chkSaveWorkspace.TabIndex = 11
      Me.chkSaveWorkspace.Text = "&Save Workspace after Processing (Recommended)"
      Me.chkSaveWorkspace.UseVisualStyleBackColor = True
      AddHandler Me.chkSaveWorkspace.CheckedChanged, AddressOf Me.chkSaveWorkspace_CheckedChanged
      Me.btnRemoveUnchecked.Location = New System.Drawing.Point(487, 3)
      Me.btnRemoveUnchecked.Name = "btnRemoveUnchecked"
      Me.btnRemoveUnchecked.Size = New System.Drawing.Size(127, 23)
      Me.btnRemoveUnchecked.TabIndex = 15
      Me.btnRemoveUnchecked.Text = "&Remove Unchecked"
      Me.btnRemoveUnchecked.UseVisualStyleBackColor = True
      AddHandler Me.btnRemoveUnchecked.Click, AddressOf Me.btnRemoveUnchecked_Click
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.Controls.Add(Me.btnRemoveUnchecked)
      Me.Controls.Add(Me.btnChooseWorkspaceFilename)
      Me.Controls.Add(Me.txtSavePath)
      Me.Controls.Add(Me.lblWorkspaceFilename)
      Me.Controls.Add(Me.chkSaveWorkspace)
      Me.Controls.Add(Me.btnChooseFolderofFiles)
      Me.Controls.Add(Me.chkFiles)
      Me.Controls.Add(Me.btnScan)
      Me.Controls.Add(Me.btnChooseFile)
      Me.Name = "InputPanel"
      Me.Size = New System.Drawing.Size(617, 198)
      Me.ResumeLayout(False)
      Me.PerformLayout()
   End Sub

   Private WithEvents btnChooseFile As System.Windows.Forms.Button
   Private WithEvents btnScan As System.Windows.Forms.Button
   Private chkFiles As System.Windows.Forms.CheckedListBox
   Private WithEvents btnChooseFolderofFiles As System.Windows.Forms.Button
   Private WithEvents btnChooseWorkspaceFilename As System.Windows.Forms.Button
   Private txtSavePath As System.Windows.Forms.TextBox
   Private lblWorkspaceFilename As System.Windows.Forms.Label
   Private chkSaveWorkspace As System.Windows.Forms.CheckBox
   Private btnRemoveUnchecked As System.Windows.Forms.Button
End Class
