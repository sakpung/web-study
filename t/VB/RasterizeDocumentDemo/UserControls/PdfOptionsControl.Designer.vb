<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PdfOptionsControl
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
      Me._passwordTextBox = New System.Windows.Forms.TextBox
      Me._passwordLabel = New System.Windows.Forms.Label
      Me._generalPdfLoadOptionsGroupBox = New System.Windows.Forms.GroupBox
      Me._resetToDefaultsButton = New System.Windows.Forms.Button
      Me._displayCieColorsCheckBox = New System.Windows.Forms.CheckBox
      Me._disableCroppingCheckBox = New System.Windows.Forms.CheckBox
      Me._graphicsAlphaComboBox = New System.Windows.Forms.ComboBox
      Me._graphicsAlphaLabel = New System.Windows.Forms.Label
      Me._textAlphaComboBox = New System.Windows.Forms.ComboBox
      Me._textAlphaLabel = New System.Windows.Forms.Label
      Me._displayDepthComboBox = New System.Windows.Forms.ComboBox
      Me._displayDepthLabel = New System.Windows.Forms.Label
      Me._useLibFontsCheckBox = New System.Windows.Forms.CheckBox
      Me._controlsToolTip = New System.Windows.Forms.ToolTip(Me.components)
      Me._generalPdfLoadOptionsGroupBox.SuspendLayout()
      Me.SuspendLayout()
      '
      '_passwordTextBox
      '
      Me._passwordTextBox.Location = New System.Drawing.Point(114, 113)
      Me._passwordTextBox.Name = "_passwordTextBox"
      Me._passwordTextBox.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
      Me._passwordTextBox.Size = New System.Drawing.Size(194, 20)
      Me._passwordTextBox.TabIndex = 7
      Me._controlsToolTip.SetToolTip(Me._passwordTextBox, "The user password to be used with encrypted PDF files")
      '
      '_passwordLabel
      '
      Me._passwordLabel.AutoSize = True
      Me._passwordLabel.Location = New System.Drawing.Point(13, 116)
      Me._passwordLabel.Name = "_passwordLabel"
      Me._passwordLabel.Size = New System.Drawing.Size(56, 13)
      Me._passwordLabel.TabIndex = 6
      Me._passwordLabel.Text = "&Password:"
      '
      '_generalPdfLoadOptionsGroupBox
      '
      Me._generalPdfLoadOptionsGroupBox.Controls.Add(Me._resetToDefaultsButton)
      Me._generalPdfLoadOptionsGroupBox.Controls.Add(Me._passwordTextBox)
      Me._generalPdfLoadOptionsGroupBox.Controls.Add(Me._passwordLabel)
      Me._generalPdfLoadOptionsGroupBox.Controls.Add(Me._displayCieColorsCheckBox)
      Me._generalPdfLoadOptionsGroupBox.Controls.Add(Me._disableCroppingCheckBox)
      Me._generalPdfLoadOptionsGroupBox.Controls.Add(Me._graphicsAlphaComboBox)
      Me._generalPdfLoadOptionsGroupBox.Controls.Add(Me._graphicsAlphaLabel)
      Me._generalPdfLoadOptionsGroupBox.Controls.Add(Me._textAlphaComboBox)
      Me._generalPdfLoadOptionsGroupBox.Controls.Add(Me._textAlphaLabel)
      Me._generalPdfLoadOptionsGroupBox.Controls.Add(Me._displayDepthComboBox)
      Me._generalPdfLoadOptionsGroupBox.Controls.Add(Me._displayDepthLabel)
      Me._generalPdfLoadOptionsGroupBox.Controls.Add(Me._useLibFontsCheckBox)
      Me._generalPdfLoadOptionsGroupBox.Dock = System.Windows.Forms.DockStyle.Fill
      Me._generalPdfLoadOptionsGroupBox.Location = New System.Drawing.Point(0, 0)
      Me._generalPdfLoadOptionsGroupBox.Name = "_generalPdfLoadOptionsGroupBox"
      Me._generalPdfLoadOptionsGroupBox.Size = New System.Drawing.Size(500, 230)
      Me._generalPdfLoadOptionsGroupBox.TabIndex = 0
      Me._generalPdfLoadOptionsGroupBox.TabStop = False
      Me._generalPdfLoadOptionsGroupBox.Text = "General Adobe Portable Format (PDF), Postscript (PS) and Enhanced Postscript (EPS) load options:"
      '
      '_resetToDefaultsButton
      '
      Me._resetToDefaultsButton.Location = New System.Drawing.Point(305, 201)
      Me._resetToDefaultsButton.Name = "_resetToDefaultsButton"
      Me._resetToDefaultsButton.Size = New System.Drawing.Size(189, 23)
      Me._resetToDefaultsButton.TabIndex = 11
      Me._resetToDefaultsButton.Text = "Reset to defa&ults"
      Me._controlsToolTip.SetToolTip(Me._resetToDefaultsButton, "Reset the options to LEADTOOLS default values")
      Me._resetToDefaultsButton.UseVisualStyleBackColor = True
      '
      '_displayCieColorsCheckBox
      '
      Me._displayCieColorsCheckBox.AutoSize = True
      Me._displayCieColorsCheckBox.Location = New System.Drawing.Point(340, 88)
      Me._displayCieColorsCheckBox.Name = "_displayCieColorsCheckBox"
      Me._displayCieColorsCheckBox.Size = New System.Drawing.Size(112, 17)
      Me._displayCieColorsCheckBox.TabIndex = 10
      Me._displayCieColorsCheckBox.Text = "Disable &CIE colors"
      Me._controlsToolTip.SetToolTip(Me._displayCieColorsCheckBox, "Enable or disable using CIE colors for both PDF and PostScript (PS) files")
      Me._displayCieColorsCheckBox.UseVisualStyleBackColor = True
      '
      '_disableCroppingCheckBox
      '
      Me._disableCroppingCheckBox.AutoSize = True
      Me._disableCroppingCheckBox.Location = New System.Drawing.Point(340, 61)
      Me._disableCroppingCheckBox.Name = "_disableCroppingCheckBox"
      Me._disableCroppingCheckBox.Size = New System.Drawing.Size(105, 17)
      Me._disableCroppingCheckBox.TabIndex = 9
      Me._disableCroppingCheckBox.Text = "Disable c&ropping"
      Me._controlsToolTip.SetToolTip(Me._disableCroppingCheckBox, "Enable or disable cropping for PostScript (PS) files to actual drawing size")
      Me._disableCroppingCheckBox.UseVisualStyleBackColor = True
      '
      '_graphicsAlphaComboBox
      '
      Me._graphicsAlphaComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me._graphicsAlphaComboBox.FormattingEnabled = True
      Me._graphicsAlphaComboBox.Location = New System.Drawing.Point(114, 86)
      Me._graphicsAlphaComboBox.Name = "_graphicsAlphaComboBox"
      Me._graphicsAlphaComboBox.Size = New System.Drawing.Size(194, 21)
      Me._graphicsAlphaComboBox.TabIndex = 5
      Me._controlsToolTip.SetToolTip(Me._graphicsAlphaComboBox, "The type of anti-aliasing to use when rendering graphics")
      '
      '_graphicsAlphaLabel
      '
      Me._graphicsAlphaLabel.AutoSize = True
      Me._graphicsAlphaLabel.Location = New System.Drawing.Point(13, 89)
      Me._graphicsAlphaLabel.Name = "_graphicsAlphaLabel"
      Me._graphicsAlphaLabel.Size = New System.Drawing.Size(81, 13)
      Me._graphicsAlphaLabel.TabIndex = 4
      Me._graphicsAlphaLabel.Text = "&Graphics alpha:"
      '
      '_textAlphaComboBox
      '
      Me._textAlphaComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me._textAlphaComboBox.FormattingEnabled = True
      Me._textAlphaComboBox.Location = New System.Drawing.Point(114, 59)
      Me._textAlphaComboBox.Name = "_textAlphaComboBox"
      Me._textAlphaComboBox.Size = New System.Drawing.Size(194, 21)
      Me._textAlphaComboBox.TabIndex = 3
      Me._controlsToolTip.SetToolTip(Me._textAlphaComboBox, "The type of anti-aliasing to use when rendering text")
      '
      '_textAlphaLabel
      '
      Me._textAlphaLabel.AutoSize = True
      Me._textAlphaLabel.Location = New System.Drawing.Point(13, 62)
      Me._textAlphaLabel.Name = "_textAlphaLabel"
      Me._textAlphaLabel.Size = New System.Drawing.Size(60, 13)
      Me._textAlphaLabel.TabIndex = 2
      Me._textAlphaLabel.Text = "&Text alpha:"
      '
      '_displayDepthComboBox
      '
      Me._displayDepthComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me._displayDepthComboBox.FormattingEnabled = True
      Me._displayDepthComboBox.Location = New System.Drawing.Point(114, 32)
      Me._displayDepthComboBox.Name = "_displayDepthComboBox"
      Me._displayDepthComboBox.Size = New System.Drawing.Size(194, 21)
      Me._displayDepthComboBox.TabIndex = 1
      Me._controlsToolTip.SetToolTip(Me._displayDepthComboBox, "The resulting image pixel per pixel")
      '
      '_displayDepthLabel
      '
      Me._displayDepthLabel.AutoSize = True
      Me._displayDepthLabel.Location = New System.Drawing.Point(13, 35)
      Me._displayDepthLabel.Name = "_displayDepthLabel"
      Me._displayDepthLabel.Size = New System.Drawing.Size(74, 13)
      Me._displayDepthLabel.TabIndex = 0
      Me._displayDepthLabel.Text = "&Display depth:"
      '
      '_useLibFontsCheckBox
      '
      Me._useLibFontsCheckBox.AutoSize = True
      Me._useLibFontsCheckBox.Location = New System.Drawing.Point(340, 34)
      Me._useLibFontsCheckBox.Name = "_useLibFontsCheckBox"
      Me._useLibFontsCheckBox.Size = New System.Drawing.Size(101, 17)
      Me._useLibFontsCheckBox.TabIndex = 8
      Me._useLibFontsCheckBox.Text = "&Use library fonts"
      Me._controlsToolTip.SetToolTip(Me._useLibFontsCheckBox, "Use the library installed fonts, otherwise use the system fonts")
      Me._useLibFontsCheckBox.UseVisualStyleBackColor = True
      '
      '_controlsToolTip
      '
      Me._controlsToolTip.IsBalloon = True
      Me._controlsToolTip.ShowAlways = True
      '
      'PdfOptionsControl
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.Controls.Add(Me._generalPdfLoadOptionsGroupBox)
      Me.Name = "PdfOptionsControl"
      Me.Size = New System.Drawing.Size(500, 230)
      Me._generalPdfLoadOptionsGroupBox.ResumeLayout(False)
      Me._generalPdfLoadOptionsGroupBox.PerformLayout()
      Me.ResumeLayout(False)

   End Sub
   Private WithEvents _passwordTextBox As System.Windows.Forms.TextBox
   Private WithEvents _controlsToolTip As System.Windows.Forms.ToolTip
   Private WithEvents _passwordLabel As System.Windows.Forms.Label
   Private WithEvents _generalPdfLoadOptionsGroupBox As System.Windows.Forms.GroupBox
   Private WithEvents _resetToDefaultsButton As System.Windows.Forms.Button
   Private WithEvents _displayCieColorsCheckBox As System.Windows.Forms.CheckBox
   Private WithEvents _disableCroppingCheckBox As System.Windows.Forms.CheckBox
   Private WithEvents _graphicsAlphaComboBox As System.Windows.Forms.ComboBox
   Private WithEvents _graphicsAlphaLabel As System.Windows.Forms.Label
   Private WithEvents _textAlphaComboBox As System.Windows.Forms.ComboBox
   Private WithEvents _textAlphaLabel As System.Windows.Forms.Label
   Private WithEvents _displayDepthComboBox As System.Windows.Forms.ComboBox
   Private WithEvents _displayDepthLabel As System.Windows.Forms.Label
   Private WithEvents _useLibFontsCheckBox As System.Windows.Forms.CheckBox

End Class
