Partial Class TemplatePanel
   Private components As System.ComponentModel.IContainer = Nothing

   Protected Overrides Sub Dispose(ByVal disposing As Boolean)
      If disposing AndAlso (components IsNot Nothing) Then
         components.Dispose()
      End If

      MyBase.Dispose(disposing)
   End Sub

   Private Sub InitializeComponent()
      Me.txtFilePath = New System.Windows.Forms.TextBox()
      Me.btnBrowse = New System.Windows.Forms.Button()
      Me.rdBtnFile = New System.Windows.Forms.RadioButton()
      Me.rdbtnTemplate = New System.Windows.Forms.RadioButton()
      Me.pnlThumbnail = New System.Windows.Forms.Panel()
      Me.grpSelectSource = New System.Windows.Forms.GroupBox()
      Me.grpSelectSource.SuspendLayout()
      Me.SuspendLayout()
      Me.txtFilePath.Location = New System.Drawing.Point(28, 65)
      Me.txtFilePath.Name = "txtFilePath"
      Me.txtFilePath.Size = New System.Drawing.Size(310, 20)
      Me.txtFilePath.TabIndex = 4
      Me.btnBrowse.Location = New System.Drawing.Point(344, 65)
      Me.btnBrowse.Name = "btnBrowse"
      Me.btnBrowse.Size = New System.Drawing.Size(75, 23)
      Me.btnBrowse.TabIndex = 5
      Me.btnBrowse.Text = "Browse"
      Me.btnBrowse.UseVisualStyleBackColor = True
      AddHandler Me.btnBrowse.Click, AddressOf Me.btnTemplateBrowse_Click
      Me.rdBtnFile.AutoSize = True
      Me.rdBtnFile.Location = New System.Drawing.Point(6, 42)
      Me.rdBtnFile.Name = "rdBtnFile"
      Me.rdBtnFile.Size = New System.Drawing.Size(80, 17)
      Me.rdBtnFile.TabIndex = 0
      Me.rdBtnFile.TabStop = True
      Me.rdBtnFile.Text = "File on Disk"
      Me.rdBtnFile.UseVisualStyleBackColor = True
      AddHandler Me.rdBtnFile.CheckedChanged, AddressOf Me.rdBtnToggled
      Me.rdbtnTemplate.AutoSize = True
      Me.rdbtnTemplate.Location = New System.Drawing.Point(6, 19)
      Me.rdbtnTemplate.Name = "rdbtnTemplate"
      Me.rdbtnTemplate.Size = New System.Drawing.Size(151, 17)
      Me.rdbtnTemplate.TabIndex = 21
      Me.rdbtnTemplate.TabStop = True
      Me.rdbtnTemplate.Text = "Use Constructed Template"
      Me.rdbtnTemplate.UseVisualStyleBackColor = True
      AddHandler Me.rdbtnTemplate.CheckedChanged, AddressOf Me.rdBtnToggled
      Me.pnlThumbnail.BackColor = System.Drawing.SystemColors.ControlDark
      Me.pnlThumbnail.Location = New System.Drawing.Point(448, 3)
      Me.pnlThumbnail.Name = "pnlThumbnail"
      Me.pnlThumbnail.Size = New System.Drawing.Size(169, 195)
      Me.pnlThumbnail.TabIndex = 23
      Me.grpSelectSource.Controls.Add(Me.rdbtnTemplate)
      Me.grpSelectSource.Controls.Add(Me.rdBtnFile)
      Me.grpSelectSource.Controls.Add(Me.txtFilePath)
      Me.grpSelectSource.Controls.Add(Me.btnBrowse)
      Me.grpSelectSource.Location = New System.Drawing.Point(7, 6)
      Me.grpSelectSource.Name = "grpSelectSource"
      Me.grpSelectSource.Size = New System.Drawing.Size(435, 97)
      Me.grpSelectSource.TabIndex = 24
      Me.grpSelectSource.TabStop = False
      Me.grpSelectSource.Text = "Select Source"
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.Controls.Add(Me.grpSelectSource)
      Me.Controls.Add(Me.pnlThumbnail)
      Me.Name = "TemplatePanel"
      Me.Size = New System.Drawing.Size(617, 198)
      Me.grpSelectSource.ResumeLayout(False)
      Me.grpSelectSource.PerformLayout()
      Me.ResumeLayout(False)
   End Sub

   Private txtFilePath As System.Windows.Forms.TextBox
   Private btnBrowse As System.Windows.Forms.Button
   Private rdBtnFile As System.Windows.Forms.RadioButton
   Private rdbtnTemplate As System.Windows.Forms.RadioButton
   Private pnlThumbnail As System.Windows.Forms.Panel
   Private grpSelectSource As System.Windows.Forms.GroupBox
End Class
