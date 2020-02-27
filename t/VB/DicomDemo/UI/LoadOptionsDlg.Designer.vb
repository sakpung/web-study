<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LoadOptionsDlg
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
      Me.groupBoxGetImageFlags = New System.Windows.Forms.GroupBox()
      Me.checkBoxLoadCorrupted = New System.Windows.Forms.CheckBox()
      Me.checkBoxKeepColorPalette = New System.Windows.Forms.CheckBox()
      Me.checkBoxAutoDetectInvalidRleCompression = New System.Windows.Forms.CheckBox()
      Me.labelSeparator = New System.Windows.Forms.Label()
      Me.checkBoxAutoScaleVoiLut = New System.Windows.Forms.CheckBox()
      Me.checkBoxAutoApplyVoiLut = New System.Windows.Forms.CheckBox()
      Me.checkBoxAutoScaleModalityLut = New System.Windows.Forms.CheckBox()
      Me.checkBoxAutoApplyModalityLut = New System.Windows.Forms.CheckBox()
      Me.buttonOK = New System.Windows.Forms.Button()
      Me.buttonRestoreDefaults = New System.Windows.Forms.Button()
      Me.checkBoxAutoLoadOverlays = New System.Windows.Forms.CheckBox()
      Me.checkBoxRleSwapSegments = New System.Windows.Forms.CheckBox()
      Me.groupBoxGetImageFlags.SuspendLayout()
      Me.SuspendLayout()
      '
      'groupBoxGetImageFlags
      '
      Me.groupBoxGetImageFlags.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.groupBoxGetImageFlags.Controls.Add(Me.checkBoxAutoLoadOverlays)
      Me.groupBoxGetImageFlags.Controls.Add(Me.checkBoxRleSwapSegments)
      Me.groupBoxGetImageFlags.Controls.Add(Me.checkBoxLoadCorrupted)
      Me.groupBoxGetImageFlags.Controls.Add(Me.checkBoxKeepColorPalette)
      Me.groupBoxGetImageFlags.Controls.Add(Me.checkBoxAutoDetectInvalidRleCompression)
      Me.groupBoxGetImageFlags.Controls.Add(Me.labelSeparator)
      Me.groupBoxGetImageFlags.Controls.Add(Me.checkBoxAutoScaleVoiLut)
      Me.groupBoxGetImageFlags.Controls.Add(Me.checkBoxAutoApplyVoiLut)
      Me.groupBoxGetImageFlags.Controls.Add(Me.checkBoxAutoScaleModalityLut)
      Me.groupBoxGetImageFlags.Controls.Add(Me.checkBoxAutoApplyModalityLut)
      Me.groupBoxGetImageFlags.Location = New System.Drawing.Point(12, 8)
      Me.groupBoxGetImageFlags.Name = "groupBoxGetImageFlags"
      Me.groupBoxGetImageFlags.Size = New System.Drawing.Size(404, 161)
      Me.groupBoxGetImageFlags.TabIndex = 3
      Me.groupBoxGetImageFlags.TabStop = False
      Me.groupBoxGetImageFlags.Text = "GetImage Flags"
      '
      'checkBoxLoadCorrupted
      '
      Me.checkBoxLoadCorrupted.AutoSize = True
      Me.checkBoxLoadCorrupted.Location = New System.Drawing.Point(11, 137)
      Me.checkBoxLoadCorrupted.Name = "checkBoxLoadCorrupted"
      Me.checkBoxLoadCorrupted.Size = New System.Drawing.Size(99, 17)
      Me.checkBoxLoadCorrupted.TabIndex = 8
      Me.checkBoxLoadCorrupted.Text = "Load Corrupted"
      Me.checkBoxLoadCorrupted.UseVisualStyleBackColor = True
      '
      'checkBoxKeepColorPalette
      '
      Me.checkBoxKeepColorPalette.AutoSize = True
      Me.checkBoxKeepColorPalette.Location = New System.Drawing.Point(11, 112)
      Me.checkBoxKeepColorPalette.Name = "checkBoxKeepColorPalette"
      Me.checkBoxKeepColorPalette.Size = New System.Drawing.Size(114, 17)
      Me.checkBoxKeepColorPalette.TabIndex = 6
      Me.checkBoxKeepColorPalette.Text = "Keep Color Palette"
      Me.checkBoxKeepColorPalette.UseVisualStyleBackColor = True
      '
      'checkBoxAutoDetectInvalidRleCompression
      '
      Me.checkBoxAutoDetectInvalidRleCompression.AutoSize = True
      Me.checkBoxAutoDetectInvalidRleCompression.Location = New System.Drawing.Point(11, 88)
      Me.checkBoxAutoDetectInvalidRleCompression.Name = "checkBoxAutoDetectInvalidRleCompression"
      Me.checkBoxAutoDetectInvalidRleCompression.Size = New System.Drawing.Size(204, 17)
      Me.checkBoxAutoDetectInvalidRleCompression.TabIndex = 5
      Me.checkBoxAutoDetectInvalidRleCompression.Text = "Auto-Detect Invalid RLE Compression"
      Me.checkBoxAutoDetectInvalidRleCompression.UseVisualStyleBackColor = True
      '
      'labelSeparator
      '
      Me.labelSeparator.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
      Me.labelSeparator.Location = New System.Drawing.Point(2, 74)
      Me.labelSeparator.Name = "labelSeparator"
      Me.labelSeparator.Size = New System.Drawing.Size(402, 2)
      Me.labelSeparator.TabIndex = 4
      '
      'checkBoxAutoScaleVoiLut
      '
      Me.checkBoxAutoScaleVoiLut.AutoSize = True
      Me.checkBoxAutoScaleVoiLut.Location = New System.Drawing.Point(220, 48)
      Me.checkBoxAutoScaleVoiLut.Name = "checkBoxAutoScaleVoiLut"
      Me.checkBoxAutoScaleVoiLut.Size = New System.Drawing.Size(123, 17)
      Me.checkBoxAutoScaleVoiLut.TabIndex = 3
      Me.checkBoxAutoScaleVoiLut.Text = "Auto-Scale VOI LUT"
      Me.checkBoxAutoScaleVoiLut.UseVisualStyleBackColor = True
      '
      'checkBoxAutoApplyVoiLut
      '
      Me.checkBoxAutoApplyVoiLut.AutoSize = True
      Me.checkBoxAutoApplyVoiLut.Location = New System.Drawing.Point(11, 48)
      Me.checkBoxAutoApplyVoiLut.Name = "checkBoxAutoApplyVoiLut"
      Me.checkBoxAutoApplyVoiLut.Size = New System.Drawing.Size(122, 17)
      Me.checkBoxAutoApplyVoiLut.TabIndex = 1
      Me.checkBoxAutoApplyVoiLut.Text = "Auto-Apply VOI LUT"
      Me.checkBoxAutoApplyVoiLut.UseVisualStyleBackColor = True
      '
      'checkBoxAutoScaleModalityLut
      '
      Me.checkBoxAutoScaleModalityLut.AutoSize = True
      Me.checkBoxAutoScaleModalityLut.Location = New System.Drawing.Point(220, 23)
      Me.checkBoxAutoScaleModalityLut.Name = "checkBoxAutoScaleModalityLut"
      Me.checkBoxAutoScaleModalityLut.Size = New System.Drawing.Size(144, 17)
      Me.checkBoxAutoScaleModalityLut.TabIndex = 2
      Me.checkBoxAutoScaleModalityLut.Text = "Auto-Scale Modality LUT"
      Me.checkBoxAutoScaleModalityLut.UseVisualStyleBackColor = True
      '
      'checkBoxAutoApplyModalityLut
      '
      Me.checkBoxAutoApplyModalityLut.AutoSize = True
      Me.checkBoxAutoApplyModalityLut.Location = New System.Drawing.Point(11, 23)
      Me.checkBoxAutoApplyModalityLut.Name = "checkBoxAutoApplyModalityLut"
      Me.checkBoxAutoApplyModalityLut.Size = New System.Drawing.Size(143, 17)
      Me.checkBoxAutoApplyModalityLut.TabIndex = 0
      Me.checkBoxAutoApplyModalityLut.Text = "Auto-Apply Modality LUT"
      Me.checkBoxAutoApplyModalityLut.UseVisualStyleBackColor = True
      '
      'buttonOK
      '
      Me.buttonOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK
      Me.buttonOK.Location = New System.Drawing.Point(341, 195)
      Me.buttonOK.Name = "buttonOK"
      Me.buttonOK.Size = New System.Drawing.Size(75, 23)
      Me.buttonOK.TabIndex = 5
      Me.buttonOK.Text = "&OK"
      '
      'buttonRestoreDefaults
      '
      Me.buttonRestoreDefaults.Location = New System.Drawing.Point(12, 175)
      Me.buttonRestoreDefaults.Name = "buttonRestoreDefaults"
      Me.buttonRestoreDefaults.Size = New System.Drawing.Size(97, 23)
      Me.buttonRestoreDefaults.TabIndex = 4
      Me.buttonRestoreDefaults.Text = "Restore Defaults"
      Me.buttonRestoreDefaults.UseVisualStyleBackColor = True
      '
      'checkBoxAutoLoadOverlays
      '
      Me.checkBoxAutoLoadOverlays.AutoSize = True
      Me.checkBoxAutoLoadOverlays.Location = New System.Drawing.Point(220, 112)
      Me.checkBoxAutoLoadOverlays.Name = "checkBoxAutoLoadOverlays"
      Me.checkBoxAutoLoadOverlays.Size = New System.Drawing.Size(119, 17)
      Me.checkBoxAutoLoadOverlays.TabIndex = 11
      Me.checkBoxAutoLoadOverlays.Text = "Auto Load Overlays"
      Me.checkBoxAutoLoadOverlays.UseVisualStyleBackColor = True
      '
      'checkBoxRleSwapSegments
      '
      Me.checkBoxRleSwapSegments.AutoSize = True
      Me.checkBoxRleSwapSegments.Location = New System.Drawing.Point(220, 88)
      Me.checkBoxRleSwapSegments.Name = "checkBoxRleSwapSegments"
      Me.checkBoxRleSwapSegments.Size = New System.Drawing.Size(163, 17)
      Me.checkBoxRleSwapSegments.TabIndex = 10
      Me.checkBoxRleSwapSegments.Text = "Always Swap RLE Segments"
      Me.checkBoxRleSwapSegments.UseVisualStyleBackColor = True
      '
      'LoadOptionsDlg
      '
      Me.AcceptButton = Me.buttonOK
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.CancelButton = Me.buttonOK
      Me.ClientSize = New System.Drawing.Size(428, 227)
      Me.Controls.Add(Me.groupBoxGetImageFlags)
      Me.Controls.Add(Me.buttonOK)
      Me.Controls.Add(Me.buttonRestoreDefaults)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "LoadOptionsDlg"
      Me.ShowIcon = False
      Me.ShowInTaskbar = False
      Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
      Me.Text = "Load Options"
      Me.groupBoxGetImageFlags.ResumeLayout(False)
      Me.groupBoxGetImageFlags.PerformLayout()
      Me.ResumeLayout(False)

   End Sub

   Private WithEvents groupBoxGetImageFlags As System.Windows.Forms.GroupBox
   Private WithEvents checkBoxKeepColorPalette As System.Windows.Forms.CheckBox
   Private WithEvents checkBoxAutoDetectInvalidRleCompression As System.Windows.Forms.CheckBox
   Private WithEvents labelSeparator As System.Windows.Forms.Label
   Private WithEvents checkBoxAutoScaleVoiLut As System.Windows.Forms.CheckBox
   Private WithEvents checkBoxAutoApplyVoiLut As System.Windows.Forms.CheckBox
   Private WithEvents checkBoxAutoScaleModalityLut As System.Windows.Forms.CheckBox
   Private WithEvents checkBoxAutoApplyModalityLut As System.Windows.Forms.CheckBox
   Private WithEvents buttonOK As System.Windows.Forms.Button
   Private WithEvents buttonRestoreDefaults As System.Windows.Forms.Button
   Private WithEvents checkBoxLoadCorrupted As System.Windows.Forms.CheckBox
   Private WithEvents checkBoxAutoLoadOverlays As System.Windows.Forms.CheckBox
   Private WithEvents checkBoxRleSwapSegments As System.Windows.Forms.CheckBox
End Class
