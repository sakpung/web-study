<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TxtOptionsControl
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
      Me.components = New System.ComponentModel.Container
      Me._fontBoldCheckBox = New System.Windows.Forms.CheckBox
      Me._fontSizeComboBox = New System.Windows.Forms.ComboBox
      Me._fontSizeLabel = New System.Windows.Forms.Label
      Me._fontNameComboBox = New System.Windows.Forms.ComboBox
      Me._generalTxtLoadOptionsGroupBox = New System.Windows.Forms.GroupBox
      Me._fontStrikethroughCheckBox = New System.Windows.Forms.CheckBox
      Me._fontUnderlineCheckBox = New System.Windows.Forms.CheckBox
      Me._fontItalicCheckBox = New System.Windows.Forms.CheckBox
      Me._resetToDefaultsButton = New System.Windows.Forms.Button
      Me._useSystenLocaleCheckBox = New System.Windows.Forms.CheckBox
      Me._highlightColorButton = New System.Windows.Forms.Button
      Me._highlightColorPanel = New System.Windows.Forms.Panel
      Me._highlightColorLabel = New System.Windows.Forms.Label
      Me._fontColorButton = New System.Windows.Forms.Button
      Me._fontColorPanel = New System.Windows.Forms.Panel
      Me._fontColorLabel = New System.Windows.Forms.Label
      Me._fontLabel = New System.Windows.Forms.Label
      Me._enabledCheckBox = New System.Windows.Forms.CheckBox
      Me._backColorButton = New System.Windows.Forms.Button
      Me._backColorPanel = New System.Windows.Forms.Panel
      Me._backColorLabel = New System.Windows.Forms.Label
      Me._controlsToolTip = New System.Windows.Forms.ToolTip(Me.components)
      Me._generalTxtLoadOptionsGroupBox.SuspendLayout()
      Me.SuspendLayout()
      '
      '_fontBoldCheckBox
      '
      Me._fontBoldCheckBox.AutoSize = True
      Me._fontBoldCheckBox.Location = New System.Drawing.Point(124, 99)
      Me._fontBoldCheckBox.Name = "_fontBoldCheckBox"
      Me._fontBoldCheckBox.Size = New System.Drawing.Size(47, 17)
      Me._fontBoldCheckBox.TabIndex = 7
      Me._fontBoldCheckBox.Text = "Bold"
      Me._fontBoldCheckBox.UseVisualStyleBackColor = True
      '
      '_fontSizeComboBox
      '
      Me._fontSizeComboBox.FormattingEnabled = True
      Me._fontSizeComboBox.Items.AddRange(New Object() {"8", "9", "10", "11", "12", "14", "16", "18", "20", "22", "24", "26", "28", "36", "48", "72"})
      Me._fontSizeComboBox.Location = New System.Drawing.Point(385, 73)
      Me._fontSizeComboBox.Name = "_fontSizeComboBox"
      Me._fontSizeComboBox.Size = New System.Drawing.Size(83, 21)
      Me._fontSizeComboBox.TabIndex = 5
      '
      '_fontSizeLabel
      '
      Me._fontSizeLabel.AutoSize = True
      Me._fontSizeLabel.Location = New System.Drawing.Point(337, 75)
      Me._fontSizeLabel.Name = "_fontSizeLabel"
      Me._fontSizeLabel.Size = New System.Drawing.Size(30, 13)
      Me._fontSizeLabel.TabIndex = 4
      Me._fontSizeLabel.Text = "&Size:"
      '
      '_fontNameComboBox
      '
      Me._fontNameComboBox.FormattingEnabled = True
      Me._fontNameComboBox.Location = New System.Drawing.Point(124, 72)
      Me._fontNameComboBox.Name = "_fontNameComboBox"
      Me._fontNameComboBox.Size = New System.Drawing.Size(196, 21)
      Me._fontNameComboBox.TabIndex = 3
      '
      '_generalTxtLoadOptionsGroupBox
      '
      Me._generalTxtLoadOptionsGroupBox.Controls.Add(Me._fontStrikethroughCheckBox)
      Me._generalTxtLoadOptionsGroupBox.Controls.Add(Me._fontUnderlineCheckBox)
      Me._generalTxtLoadOptionsGroupBox.Controls.Add(Me._fontItalicCheckBox)
      Me._generalTxtLoadOptionsGroupBox.Controls.Add(Me._fontBoldCheckBox)
      Me._generalTxtLoadOptionsGroupBox.Controls.Add(Me._fontSizeComboBox)
      Me._generalTxtLoadOptionsGroupBox.Controls.Add(Me._fontSizeLabel)
      Me._generalTxtLoadOptionsGroupBox.Controls.Add(Me._fontNameComboBox)
      Me._generalTxtLoadOptionsGroupBox.Controls.Add(Me._resetToDefaultsButton)
      Me._generalTxtLoadOptionsGroupBox.Controls.Add(Me._useSystenLocaleCheckBox)
      Me._generalTxtLoadOptionsGroupBox.Controls.Add(Me._highlightColorButton)
      Me._generalTxtLoadOptionsGroupBox.Controls.Add(Me._highlightColorPanel)
      Me._generalTxtLoadOptionsGroupBox.Controls.Add(Me._highlightColorLabel)
      Me._generalTxtLoadOptionsGroupBox.Controls.Add(Me._fontColorButton)
      Me._generalTxtLoadOptionsGroupBox.Controls.Add(Me._fontColorPanel)
      Me._generalTxtLoadOptionsGroupBox.Controls.Add(Me._fontColorLabel)
      Me._generalTxtLoadOptionsGroupBox.Controls.Add(Me._fontLabel)
      Me._generalTxtLoadOptionsGroupBox.Controls.Add(Me._enabledCheckBox)
      Me._generalTxtLoadOptionsGroupBox.Controls.Add(Me._backColorButton)
      Me._generalTxtLoadOptionsGroupBox.Controls.Add(Me._backColorPanel)
      Me._generalTxtLoadOptionsGroupBox.Controls.Add(Me._backColorLabel)
      Me._generalTxtLoadOptionsGroupBox.Dock = System.Windows.Forms.DockStyle.Fill
      Me._generalTxtLoadOptionsGroupBox.Location = New System.Drawing.Point(0, 0)
      Me._generalTxtLoadOptionsGroupBox.Name = "_generalTxtLoadOptionsGroupBox"
      Me._generalTxtLoadOptionsGroupBox.Size = New System.Drawing.Size(500, 230)
      Me._generalTxtLoadOptionsGroupBox.TabIndex = 0
      Me._generalTxtLoadOptionsGroupBox.TabStop = False
      Me._generalTxtLoadOptionsGroupBox.Text = "General Text load options:"
      '
      '_fontStrikethroughCheckBox
      '
      Me._fontStrikethroughCheckBox.AutoSize = True
      Me._fontStrikethroughCheckBox.Location = New System.Drawing.Point(377, 99)
      Me._fontStrikethroughCheckBox.Name = "_fontStrikethroughCheckBox"
      Me._fontStrikethroughCheckBox.Size = New System.Drawing.Size(89, 17)
      Me._fontStrikethroughCheckBox.TabIndex = 10
      Me._fontStrikethroughCheckBox.Text = "Strikethrough"
      Me._fontStrikethroughCheckBox.UseVisualStyleBackColor = True
      '
      '_fontUnderlineCheckBox
      '
      Me._fontUnderlineCheckBox.AutoSize = True
      Me._fontUnderlineCheckBox.Location = New System.Drawing.Point(277, 99)
      Me._fontUnderlineCheckBox.Name = "_fontUnderlineCheckBox"
      Me._fontUnderlineCheckBox.Size = New System.Drawing.Size(71, 17)
      Me._fontUnderlineCheckBox.TabIndex = 9
      Me._fontUnderlineCheckBox.Text = "Underline"
      Me._fontUnderlineCheckBox.UseVisualStyleBackColor = True
      '
      '_fontItalicCheckBox
      '
      Me._fontItalicCheckBox.AutoSize = True
      Me._fontItalicCheckBox.Location = New System.Drawing.Point(200, 99)
      Me._fontItalicCheckBox.Name = "_fontItalicCheckBox"
      Me._fontItalicCheckBox.Size = New System.Drawing.Size(48, 17)
      Me._fontItalicCheckBox.TabIndex = 8
      Me._fontItalicCheckBox.Text = "Italic"
      Me._fontItalicCheckBox.UseVisualStyleBackColor = True
      '
      '_resetToDefaultsButton
      '
      Me._resetToDefaultsButton.Location = New System.Drawing.Point(305, 201)
      Me._resetToDefaultsButton.Name = "_resetToDefaultsButton"
      Me._resetToDefaultsButton.Size = New System.Drawing.Size(189, 23)
      Me._resetToDefaultsButton.TabIndex = 20
      Me._resetToDefaultsButton.Text = "Reset to defa&ults"
      Me._controlsToolTip.SetToolTip(Me._resetToDefaultsButton, "Reset the options to LEADTOOLS default values")
      Me._resetToDefaultsButton.UseVisualStyleBackColor = True
      '
      '_useSystenLocaleCheckBox
      '
      Me._useSystenLocaleCheckBox.AutoSize = True
      Me._useSystenLocaleCheckBox.Location = New System.Drawing.Point(21, 42)
      Me._useSystenLocaleCheckBox.Name = "_useSystenLocaleCheckBox"
      Me._useSystenLocaleCheckBox.Size = New System.Drawing.Size(111, 17)
      Me._useSystenLocaleCheckBox.TabIndex = 1
      Me._useSystenLocaleCheckBox.Text = "&Use system locale"
      Me._controlsToolTip.SetToolTip(Me._useSystenLocaleCheckBox, "Use current system locale (code page) when rendering text file")
      Me._useSystenLocaleCheckBox.UseVisualStyleBackColor = True
      '
      '_highlightColorButton
      '
      Me._highlightColorButton.Location = New System.Drawing.Point(201, 180)
      Me._highlightColorButton.Name = "_highlightColorButton"
      Me._highlightColorButton.Size = New System.Drawing.Size(25, 23)
      Me._highlightColorButton.TabIndex = 19
      Me._highlightColorButton.Text = "..."
      Me._controlsToolTip.SetToolTip(Me._highlightColorButton, "Change the text highlight color used when rendering Text documents")
      Me._highlightColorButton.UseVisualStyleBackColor = True
      '
      '_highlightColorPanel
      '
      Me._highlightColorPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me._highlightColorPanel.Location = New System.Drawing.Point(124, 180)
      Me._highlightColorPanel.Name = "_highlightColorPanel"
      Me._highlightColorPanel.Size = New System.Drawing.Size(71, 23)
      Me._highlightColorPanel.TabIndex = 18
      Me._controlsToolTip.SetToolTip(Me._highlightColorPanel, "The text highlight color used when rendering Text documents")
      '
      '_highlightColorLabel
      '
      Me._highlightColorLabel.AutoSize = True
      Me._highlightColorLabel.Location = New System.Drawing.Point(18, 185)
      Me._highlightColorLabel.Name = "_highlightColorLabel"
      Me._highlightColorLabel.Size = New System.Drawing.Size(77, 13)
      Me._highlightColorLabel.TabIndex = 17
      Me._highlightColorLabel.Text = "&Highlight color:"
      '
      '_fontColorButton
      '
      Me._fontColorButton.Location = New System.Drawing.Point(201, 122)
      Me._fontColorButton.Name = "_fontColorButton"
      Me._fontColorButton.Size = New System.Drawing.Size(25, 23)
      Me._fontColorButton.TabIndex = 13
      Me._fontColorButton.Text = "..."
      Me._controlsToolTip.SetToolTip(Me._fontColorButton, "Change the font (foreground) color used when rendering Text documents")
      Me._fontColorButton.UseVisualStyleBackColor = True
      '
      '_fontColorPanel
      '
      Me._fontColorPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me._fontColorPanel.Location = New System.Drawing.Point(124, 122)
      Me._fontColorPanel.Name = "_fontColorPanel"
      Me._fontColorPanel.Size = New System.Drawing.Size(71, 23)
      Me._fontColorPanel.TabIndex = 12
      Me._controlsToolTip.SetToolTip(Me._fontColorPanel, "The font (foreground) color used when rendering Text documents")
      '
      '_fontColorLabel
      '
      Me._fontColorLabel.AutoSize = True
      Me._fontColorLabel.Location = New System.Drawing.Point(18, 127)
      Me._fontColorLabel.Name = "_fontColorLabel"
      Me._fontColorLabel.Size = New System.Drawing.Size(57, 13)
      Me._fontColorLabel.TabIndex = 11
      Me._fontColorLabel.Text = "F&ont color:"
      '
      '_fontLabel
      '
      Me._fontLabel.AutoSize = True
      Me._fontLabel.Location = New System.Drawing.Point(18, 75)
      Me._fontLabel.Name = "_fontLabel"
      Me._fontLabel.Size = New System.Drawing.Size(31, 13)
      Me._fontLabel.TabIndex = 2
      Me._fontLabel.Text = "&Font:"
      '
      '_enabledCheckBox
      '
      Me._enabledCheckBox.AutoSize = True
      Me._enabledCheckBox.Location = New System.Drawing.Point(21, 19)
      Me._enabledCheckBox.Name = "_enabledCheckBox"
      Me._enabledCheckBox.Size = New System.Drawing.Size(65, 17)
      Me._enabledCheckBox.TabIndex = 0
      Me._enabledCheckBox.Text = "&Enabled"
      Me._controlsToolTip.SetToolTip(Me._enabledCheckBox, "Enable or disable the LEADTOOLS TXT codecs. If disable, TXT files will not be loa" & _
              "ded but overall system performance will be faster")
      Me._enabledCheckBox.UseVisualStyleBackColor = True
      '
      '_backColorButton
      '
      Me._backColorButton.Location = New System.Drawing.Point(201, 151)
      Me._backColorButton.Name = "_backColorButton"
      Me._backColorButton.Size = New System.Drawing.Size(25, 23)
      Me._backColorButton.TabIndex = 16
      Me._backColorButton.Text = "..."
      Me._controlsToolTip.SetToolTip(Me._backColorButton, "Change the background color used when rendering Text documents")
      Me._backColorButton.UseVisualStyleBackColor = True
      '
      '_backColorPanel
      '
      Me._backColorPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me._backColorPanel.Location = New System.Drawing.Point(124, 151)
      Me._backColorPanel.Name = "_backColorPanel"
      Me._backColorPanel.Size = New System.Drawing.Size(71, 23)
      Me._backColorPanel.TabIndex = 15
      Me._controlsToolTip.SetToolTip(Me._backColorPanel, "The background color used when rendering Text documents")
      '
      '_backColorLabel
      '
      Me._backColorLabel.AutoSize = True
      Me._backColorLabel.Location = New System.Drawing.Point(18, 156)
      Me._backColorLabel.Name = "_backColorLabel"
      Me._backColorLabel.Size = New System.Drawing.Size(61, 13)
      Me._backColorLabel.TabIndex = 14
      Me._backColorLabel.Text = "&Back color:"
      '
      '_controlsToolTip
      '
      Me._controlsToolTip.IsBalloon = True
      Me._controlsToolTip.ShowAlways = True
      '
      'TxtOptionsControl
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.Controls.Add(Me._generalTxtLoadOptionsGroupBox)
      Me.Name = "TxtOptionsControl"
      Me.Size = New System.Drawing.Size(500, 230)
      Me._generalTxtLoadOptionsGroupBox.ResumeLayout(False)
      Me._generalTxtLoadOptionsGroupBox.PerformLayout()
      Me.ResumeLayout(False)

   End Sub
   Private WithEvents _fontBoldCheckBox As System.Windows.Forms.CheckBox
   Private WithEvents _fontSizeComboBox As System.Windows.Forms.ComboBox
   Private WithEvents _fontSizeLabel As System.Windows.Forms.Label
   Private WithEvents _fontNameComboBox As System.Windows.Forms.ComboBox
   Private WithEvents _generalTxtLoadOptionsGroupBox As System.Windows.Forms.GroupBox
   Private WithEvents _fontStrikethroughCheckBox As System.Windows.Forms.CheckBox
   Private WithEvents _fontUnderlineCheckBox As System.Windows.Forms.CheckBox
   Private WithEvents _fontItalicCheckBox As System.Windows.Forms.CheckBox
   Private WithEvents _resetToDefaultsButton As System.Windows.Forms.Button
   Private WithEvents _controlsToolTip As System.Windows.Forms.ToolTip
   Private WithEvents _useSystenLocaleCheckBox As System.Windows.Forms.CheckBox
   Private WithEvents _highlightColorButton As System.Windows.Forms.Button
   Private WithEvents _highlightColorPanel As System.Windows.Forms.Panel
   Private WithEvents _highlightColorLabel As System.Windows.Forms.Label
   Private WithEvents _fontColorButton As System.Windows.Forms.Button
   Private WithEvents _fontColorPanel As System.Windows.Forms.Panel
   Private WithEvents _fontColorLabel As System.Windows.Forms.Label
   Private WithEvents _fontLabel As System.Windows.Forms.Label
   Private WithEvents _enabledCheckBox As System.Windows.Forms.CheckBox
   Private WithEvents _backColorButton As System.Windows.Forms.Button
   Private WithEvents _backColorPanel As System.Windows.Forms.Panel
   Private WithEvents _backColorLabel As System.Windows.Forms.Label

End Class
