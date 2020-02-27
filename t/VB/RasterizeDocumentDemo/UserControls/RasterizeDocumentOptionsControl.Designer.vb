<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RasterizeDocumentOptionsControl
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
      Me._rightMarginLabel = New System.Windows.Forms.Label
      Me._topMarginTextBox = New System.Windows.Forms.TextBox
      Me._topMarginLabel = New System.Windows.Forms.Label
      Me._leftMarginTextBox = New System.Windows.Forms.TextBox
      Me._rasterizeDocumentLoadOptionsGroupBox = New System.Windows.Forms.GroupBox
      Me._bottomMarginTextBox = New System.Windows.Forms.TextBox
      Me._bottomMarginLabel = New System.Windows.Forms.Label
      Me._rightMarginTextBox = New System.Windows.Forms.TextBox
      Me._leftMarginLabel = New System.Windows.Forms.Label
      Me._sizeModeHelp = New System.Windows.Forms.Label
      Me._sizeModeComboBox = New System.Windows.Forms.ComboBox
      Me._sizeModeLabel = New System.Windows.Forms.Label
      Me._unitComboBox = New System.Windows.Forms.ComboBox
      Me._unitLabel = New System.Windows.Forms.Label
      Me._resolutionComboBox = New System.Windows.Forms.ComboBox
      Me._resolutionLabel = New System.Windows.Forms.Label
      Me._pageHeightTextBox = New System.Windows.Forms.TextBox
      Me._pageHeightLabel = New System.Windows.Forms.Label
      Me._pageWidthTextBox = New System.Windows.Forms.TextBox
      Me._pageWidthLabel = New System.Windows.Forms.Label
      Me._resetToDefaultsButton = New System.Windows.Forms.Button
      Me._controlsToolTip = New System.Windows.Forms.ToolTip(Me.components)
      Me._rasterizeDocumentLoadOptionsGroupBox.SuspendLayout()
      Me.SuspendLayout()
      '
      '_rightMarginLabel
      '
      Me._rightMarginLabel.AutoSize = True
      Me._rightMarginLabel.Location = New System.Drawing.Point(21, 126)
      Me._rightMarginLabel.Name = "_rightMarginLabel"
      Me._rightMarginLabel.Size = New System.Drawing.Size(69, 13)
      Me._rightMarginLabel.TabIndex = 8
      Me._rightMarginLabel.Text = "&Right margin:"
      '
      '_topMarginTextBox
      '
      Me._topMarginTextBox.Location = New System.Drawing.Point(106, 97)
      Me._topMarginTextBox.Name = "_topMarginTextBox"
      Me._topMarginTextBox.Size = New System.Drawing.Size(100, 20)
      Me._topMarginTextBox.TabIndex = 7
      Me._controlsToolTip.SetToolTip(Me._topMarginTextBox, "The page top margin of the document (in unit)")
      '
      '_topMarginLabel
      '
      Me._topMarginLabel.AutoSize = True
      Me._topMarginLabel.Location = New System.Drawing.Point(21, 100)
      Me._topMarginLabel.Name = "_topMarginLabel"
      Me._topMarginLabel.Size = New System.Drawing.Size(63, 13)
      Me._topMarginLabel.TabIndex = 6
      Me._topMarginLabel.Text = "&Top margin:"
      '
      '_leftMarginTextBox
      '
      Me._leftMarginTextBox.Location = New System.Drawing.Point(106, 71)
      Me._leftMarginTextBox.Name = "_leftMarginTextBox"
      Me._leftMarginTextBox.Size = New System.Drawing.Size(100, 20)
      Me._leftMarginTextBox.TabIndex = 5
      Me._controlsToolTip.SetToolTip(Me._leftMarginTextBox, "The page left margin of the document (in unit)")
      '
      '_rasterizeDocumentLoadOptionsGroupBox
      '
      Me._rasterizeDocumentLoadOptionsGroupBox.Controls.Add(Me._bottomMarginTextBox)
      Me._rasterizeDocumentLoadOptionsGroupBox.Controls.Add(Me._bottomMarginLabel)
      Me._rasterizeDocumentLoadOptionsGroupBox.Controls.Add(Me._rightMarginTextBox)
      Me._rasterizeDocumentLoadOptionsGroupBox.Controls.Add(Me._rightMarginLabel)
      Me._rasterizeDocumentLoadOptionsGroupBox.Controls.Add(Me._topMarginTextBox)
      Me._rasterizeDocumentLoadOptionsGroupBox.Controls.Add(Me._topMarginLabel)
      Me._rasterizeDocumentLoadOptionsGroupBox.Controls.Add(Me._leftMarginTextBox)
      Me._rasterizeDocumentLoadOptionsGroupBox.Controls.Add(Me._leftMarginLabel)
      Me._rasterizeDocumentLoadOptionsGroupBox.Controls.Add(Me._sizeModeHelp)
      Me._rasterizeDocumentLoadOptionsGroupBox.Controls.Add(Me._sizeModeComboBox)
      Me._rasterizeDocumentLoadOptionsGroupBox.Controls.Add(Me._sizeModeLabel)
      Me._rasterizeDocumentLoadOptionsGroupBox.Controls.Add(Me._unitComboBox)
      Me._rasterizeDocumentLoadOptionsGroupBox.Controls.Add(Me._unitLabel)
      Me._rasterizeDocumentLoadOptionsGroupBox.Controls.Add(Me._resolutionComboBox)
      Me._rasterizeDocumentLoadOptionsGroupBox.Controls.Add(Me._resolutionLabel)
      Me._rasterizeDocumentLoadOptionsGroupBox.Controls.Add(Me._pageHeightTextBox)
      Me._rasterizeDocumentLoadOptionsGroupBox.Controls.Add(Me._pageHeightLabel)
      Me._rasterizeDocumentLoadOptionsGroupBox.Controls.Add(Me._pageWidthTextBox)
      Me._rasterizeDocumentLoadOptionsGroupBox.Controls.Add(Me._pageWidthLabel)
      Me._rasterizeDocumentLoadOptionsGroupBox.Controls.Add(Me._resetToDefaultsButton)
      Me._rasterizeDocumentLoadOptionsGroupBox.Dock = System.Windows.Forms.DockStyle.Fill
      Me._rasterizeDocumentLoadOptionsGroupBox.Location = New System.Drawing.Point(0, 0)
      Me._rasterizeDocumentLoadOptionsGroupBox.Name = "_rasterizeDocumentLoadOptionsGroupBox"
      Me._rasterizeDocumentLoadOptionsGroupBox.Size = New System.Drawing.Size(500, 230)
      Me._rasterizeDocumentLoadOptionsGroupBox.TabIndex = 0
      Me._rasterizeDocumentLoadOptionsGroupBox.TabStop = False
      Me._rasterizeDocumentLoadOptionsGroupBox.Text = "Load the document at the specific size and resolution:"
      '
      '_bottomMarginTextBox
      '
      Me._bottomMarginTextBox.Location = New System.Drawing.Point(106, 149)
      Me._bottomMarginTextBox.Name = "_bottomMarginTextBox"
      Me._bottomMarginTextBox.Size = New System.Drawing.Size(100, 20)
      Me._bottomMarginTextBox.TabIndex = 11
      Me._controlsToolTip.SetToolTip(Me._bottomMarginTextBox, "The page bottom margin of the document (in unit)")
      '
      '_bottomMarginLabel
      '
      Me._bottomMarginLabel.AutoSize = True
      Me._bottomMarginLabel.Location = New System.Drawing.Point(21, 152)
      Me._bottomMarginLabel.Name = "_bottomMarginLabel"
      Me._bottomMarginLabel.Size = New System.Drawing.Size(77, 13)
      Me._bottomMarginLabel.TabIndex = 10
      Me._bottomMarginLabel.Text = "&Bottom margin:"
      '
      '_rightMarginTextBox
      '
      Me._rightMarginTextBox.Location = New System.Drawing.Point(106, 123)
      Me._rightMarginTextBox.Name = "_rightMarginTextBox"
      Me._rightMarginTextBox.Size = New System.Drawing.Size(100, 20)
      Me._rightMarginTextBox.TabIndex = 9
      Me._controlsToolTip.SetToolTip(Me._rightMarginTextBox, "The page right margin of the document (in unit)")
      '
      '_leftMarginLabel
      '
      Me._leftMarginLabel.AutoSize = True
      Me._leftMarginLabel.Location = New System.Drawing.Point(21, 74)
      Me._leftMarginLabel.Name = "_leftMarginLabel"
      Me._leftMarginLabel.Size = New System.Drawing.Size(62, 13)
      Me._leftMarginLabel.TabIndex = 4
      Me._leftMarginLabel.Text = "&Left margin:"
      '
      '_sizeModeHelp
      '
      Me._sizeModeHelp.Location = New System.Drawing.Point(251, 51)
      Me._sizeModeHelp.Name = "_sizeModeHelp"
      Me._sizeModeHelp.Size = New System.Drawing.Size(240, 140)
      Me._sizeModeHelp.TabIndex = 18
      Me._sizeModeHelp.Text = "###"
      '
      '_sizeModeComboBox
      '
      Me._sizeModeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me._sizeModeComboBox.FormattingEnabled = True
      Me._sizeModeComboBox.Location = New System.Drawing.Point(314, 19)
      Me._sizeModeComboBox.Name = "_sizeModeComboBox"
      Me._sizeModeComboBox.Size = New System.Drawing.Size(121, 21)
      Me._sizeModeComboBox.TabIndex = 17
      Me._controlsToolTip.SetToolTip(Me._sizeModeComboBox, "Select the method to fit or stretch the doucment into width and height")
      '
      '_sizeModeLabel
      '
      Me._sizeModeLabel.AutoSize = True
      Me._sizeModeLabel.Location = New System.Drawing.Point(248, 22)
      Me._sizeModeLabel.Name = "_sizeModeLabel"
      Me._sizeModeLabel.Size = New System.Drawing.Size(59, 13)
      Me._sizeModeLabel.TabIndex = 16
      Me._sizeModeLabel.Text = "&Size mode:"
      '
      '_unitComboBox
      '
      Me._unitComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me._unitComboBox.FormattingEnabled = True
      Me._unitComboBox.Location = New System.Drawing.Point(106, 175)
      Me._unitComboBox.Name = "_unitComboBox"
      Me._unitComboBox.Size = New System.Drawing.Size(121, 21)
      Me._unitComboBox.TabIndex = 13
      Me._controlsToolTip.SetToolTip(Me._unitComboBox, "Unit of page width, height and margins")
      '
      '_unitLabel
      '
      Me._unitLabel.AutoSize = True
      Me._unitLabel.Location = New System.Drawing.Point(21, 178)
      Me._unitLabel.Name = "_unitLabel"
      Me._unitLabel.Size = New System.Drawing.Size(29, 13)
      Me._unitLabel.TabIndex = 12
      Me._unitLabel.Text = "&Unit:"
      '
      '_resolutionComboBox
      '
      Me._resolutionComboBox.FormattingEnabled = True
      Me._resolutionComboBox.Items.AddRange(New Object() {"0", "10", "72", "96", "110", "150", "200", "300", "400", "600", "1200", "2400", "4800"})
      Me._resolutionComboBox.Location = New System.Drawing.Point(106, 202)
      Me._resolutionComboBox.Name = "_resolutionComboBox"
      Me._resolutionComboBox.Size = New System.Drawing.Size(121, 21)
      Me._resolutionComboBox.TabIndex = 15
      Me._controlsToolTip.SetToolTip(Me._resolutionComboBox, "Resolution to use when loading the document. Select 0 for current screen resoluti" & _
              "on")
      '
      '_resolutionLabel
      '
      Me._resolutionLabel.AutoSize = True
      Me._resolutionLabel.Location = New System.Drawing.Point(21, 205)
      Me._resolutionLabel.Name = "_resolutionLabel"
      Me._resolutionLabel.Size = New System.Drawing.Size(60, 13)
      Me._resolutionLabel.TabIndex = 14
      Me._resolutionLabel.Text = "&Resolution:"
      '
      '_pageHeightTextBox
      '
      Me._pageHeightTextBox.Location = New System.Drawing.Point(106, 45)
      Me._pageHeightTextBox.Name = "_pageHeightTextBox"
      Me._pageHeightTextBox.Size = New System.Drawing.Size(100, 20)
      Me._pageHeightTextBox.TabIndex = 3
      Me._controlsToolTip.SetToolTip(Me._pageHeightTextBox, "The page height of the document (in unit)")
      '
      '_pageHeightLabel
      '
      Me._pageHeightLabel.AutoSize = True
      Me._pageHeightLabel.Location = New System.Drawing.Point(21, 48)
      Me._pageHeightLabel.Name = "_pageHeightLabel"
      Me._pageHeightLabel.Size = New System.Drawing.Size(67, 13)
      Me._pageHeightLabel.TabIndex = 2
      Me._pageHeightLabel.Text = "Page &height:"
      '
      '_pageWidthTextBox
      '
      Me._pageWidthTextBox.Location = New System.Drawing.Point(106, 19)
      Me._pageWidthTextBox.Name = "_pageWidthTextBox"
      Me._pageWidthTextBox.Size = New System.Drawing.Size(100, 20)
      Me._pageWidthTextBox.TabIndex = 1
      Me._controlsToolTip.SetToolTip(Me._pageWidthTextBox, "The page width of the document (in unit)")
      '
      '_pageWidthLabel
      '
      Me._pageWidthLabel.AutoSize = True
      Me._pageWidthLabel.Location = New System.Drawing.Point(21, 22)
      Me._pageWidthLabel.Name = "_pageWidthLabel"
      Me._pageWidthLabel.Size = New System.Drawing.Size(63, 13)
      Me._pageWidthLabel.TabIndex = 0
      Me._pageWidthLabel.Text = "Page &width:"
      '
      '_resetToDefaultsButton
      '
      Me._resetToDefaultsButton.Location = New System.Drawing.Point(305, 201)
      Me._resetToDefaultsButton.Name = "_resetToDefaultsButton"
      Me._resetToDefaultsButton.Size = New System.Drawing.Size(189, 23)
      Me._resetToDefaultsButton.TabIndex = 19
      Me._resetToDefaultsButton.Text = "Reset to defa&ults"
      Me._controlsToolTip.SetToolTip(Me._resetToDefaultsButton, "Reset the options to LEADTOOLS default values")
      Me._resetToDefaultsButton.UseVisualStyleBackColor = True
      '
      '_controlsToolTip
      '
      Me._controlsToolTip.IsBalloon = True
      Me._controlsToolTip.ShowAlways = True
      '
      'RasterizeDocumentOptionsControl
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.Controls.Add(Me._rasterizeDocumentLoadOptionsGroupBox)
      Me.Name = "RasterizeDocumentOptionsControl"
      Me.Size = New System.Drawing.Size(500, 230)
      Me._rasterizeDocumentLoadOptionsGroupBox.ResumeLayout(False)
      Me._rasterizeDocumentLoadOptionsGroupBox.PerformLayout()
      Me.ResumeLayout(False)

   End Sub
   Private WithEvents _rightMarginLabel As System.Windows.Forms.Label
   Private WithEvents _topMarginTextBox As System.Windows.Forms.TextBox
   Private WithEvents _controlsToolTip As System.Windows.Forms.ToolTip
   Private WithEvents _topMarginLabel As System.Windows.Forms.Label
   Private WithEvents _leftMarginTextBox As System.Windows.Forms.TextBox
   Private WithEvents _rasterizeDocumentLoadOptionsGroupBox As System.Windows.Forms.GroupBox
   Private WithEvents _bottomMarginTextBox As System.Windows.Forms.TextBox
   Private WithEvents _bottomMarginLabel As System.Windows.Forms.Label
   Private WithEvents _rightMarginTextBox As System.Windows.Forms.TextBox
   Private WithEvents _leftMarginLabel As System.Windows.Forms.Label
   Private WithEvents _sizeModeHelp As System.Windows.Forms.Label
   Private WithEvents _sizeModeComboBox As System.Windows.Forms.ComboBox
   Private WithEvents _sizeModeLabel As System.Windows.Forms.Label
   Private WithEvents _unitComboBox As System.Windows.Forms.ComboBox
   Private WithEvents _unitLabel As System.Windows.Forms.Label
   Private WithEvents _resolutionComboBox As System.Windows.Forms.ComboBox
   Private WithEvents _resolutionLabel As System.Windows.Forms.Label
   Private WithEvents _pageHeightTextBox As System.Windows.Forms.TextBox
   Private WithEvents _pageHeightLabel As System.Windows.Forms.Label
   Private WithEvents _pageWidthTextBox As System.Windows.Forms.TextBox
   Private WithEvents _pageWidthLabel As System.Windows.Forms.Label
   Private WithEvents _resetToDefaultsButton As System.Windows.Forms.Button

End Class
