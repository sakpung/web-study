Namespace Main3DDemo
   Partial Class Histogram3DDialog
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
         Me._btnReset = New System.Windows.Forms.Button()
         Me._btnOK = New System.Windows.Forms.Button()
         Me._tabGreen = New System.Windows.Forms.TabPage()
         Me._tabRed = New System.Windows.Forms.TabPage()
         Me._tabControl = New System.Windows.Forms.TabControl()
         Me._tabBlue = New System.Windows.Forms.TabPage()
         Me._tabOpacity = New System.Windows.Forms.TabPage()
         Me.panel1 = New System.Windows.Forms.Panel()
         Me._txtYPos = New System.Windows.Forms.Label()
         Me.label5 = New System.Windows.Forms.Label()
         Me._txtXPos = New System.Windows.Forms.Label()
         Me.label2 = New System.Windows.Forms.Label()
         Me._radMoveHist = New System.Windows.Forms.RadioButton()
         Me.button1 = New System.Windows.Forms.Button()
         Me._radMove = New System.Windows.Forms.RadioButton()
         Me._radZoom = New System.Windows.Forms.RadioButton()
         Me._maxHistogram = New System.Windows.Forms.Label()
         Me._minHistogram = New System.Windows.Forms.Label()
         Me._maxValue = New System.Windows.Forms.Label()
         Me._minValue = New System.Windows.Forms.Label()
         Me._histogramMap = New System.Windows.Forms.Label()
         Me._groupBox = New System.Windows.Forms.GroupBox()
         Me._save = New System.Windows.Forms.Button()
         Me._cmbPalette = New System.Windows.Forms.ComboBox()
         Me.label1 = New System.Windows.Forms.Label()
         Me._btnExport = New System.Windows.Forms.Button()
         Me._btnImport = New System.Windows.Forms.Button()
         Me._tabControl.SuspendLayout()
         Me.panel1.SuspendLayout()
         Me._groupBox.SuspendLayout()
         Me.SuspendLayout()
         '
         '_btnReset
         '
         Me._btnReset.Location = New System.Drawing.Point(314, 404)
         Me._btnReset.Name = "_btnReset"
         Me._btnReset.Size = New System.Drawing.Size(90, 33)
         Me._btnReset.TabIndex = 18
         Me._btnReset.Text = "&Reset"
         Me._btnReset.UseVisualStyleBackColor = True
         '
         '_btnOK
         '
         Me._btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
         Me._btnOK.Location = New System.Drawing.Point(215, 404)
         Me._btnOK.Name = "_btnOK"
         Me._btnOK.Size = New System.Drawing.Size(90, 33)
         Me._btnOK.TabIndex = 16
         Me._btnOK.Text = "&Close"
         Me._btnOK.UseVisualStyleBackColor = True
         '
         '_tabGreen
         '
         Me._tabGreen.Location = New System.Drawing.Point(4, 22)
         Me._tabGreen.Name = "_tabGreen"
         Me._tabGreen.Size = New System.Drawing.Size(422, 0)
         Me._tabGreen.TabIndex = 4
         Me._tabGreen.Text = "Green"
         Me._tabGreen.UseVisualStyleBackColor = True
         '
         '_tabRed
         '
         Me._tabRed.Location = New System.Drawing.Point(4, 22)
         Me._tabRed.Name = "_tabRed"
         Me._tabRed.Size = New System.Drawing.Size(422, 0)
         Me._tabRed.TabIndex = 3
         Me._tabRed.Text = "Red"
         Me._tabRed.UseVisualStyleBackColor = True
         '
         '_tabControl
         '
         Me._tabControl.Controls.Add(Me._tabRed)
         Me._tabControl.Controls.Add(Me._tabGreen)
         Me._tabControl.Controls.Add(Me._tabBlue)
         Me._tabControl.Controls.Add(Me._tabOpacity)
         Me._tabControl.Location = New System.Drawing.Point(9, 9)
         Me._tabControl.Name = "_tabControl"
         Me._tabControl.SelectedIndex = 0
         Me._tabControl.Size = New System.Drawing.Size(430, 20)
         Me._tabControl.TabIndex = 0
         '
         '_tabBlue
         '
         Me._tabBlue.Location = New System.Drawing.Point(4, 22)
         Me._tabBlue.Name = "_tabBlue"
         Me._tabBlue.Size = New System.Drawing.Size(422, 0)
         Me._tabBlue.TabIndex = 5
         Me._tabBlue.Text = "Blue"
         Me._tabBlue.UseVisualStyleBackColor = True
         '
         '_tabOpacity
         '
         Me._tabOpacity.Location = New System.Drawing.Point(4, 22)
         Me._tabOpacity.Name = "_tabOpacity"
         Me._tabOpacity.Size = New System.Drawing.Size(422, 0)
         Me._tabOpacity.TabIndex = 6
         Me._tabOpacity.Text = "Opacity"
         Me._tabOpacity.UseVisualStyleBackColor = True
         '
         'panel1
         '
         Me.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight
         Me.panel1.Controls.Add(Me._txtYPos)
         Me.panel1.Controls.Add(Me.label5)
         Me.panel1.Controls.Add(Me._txtXPos)
         Me.panel1.Controls.Add(Me.label2)
         Me.panel1.Controls.Add(Me._radMoveHist)
         Me.panel1.Controls.Add(Me.button1)
         Me.panel1.Controls.Add(Me._radMove)
         Me.panel1.Controls.Add(Me._radZoom)
         Me.panel1.Controls.Add(Me._maxHistogram)
         Me.panel1.Controls.Add(Me._minHistogram)
         Me.panel1.Controls.Add(Me._maxValue)
         Me.panel1.Controls.Add(Me._minValue)
         Me.panel1.Controls.Add(Me._histogramMap)
         Me.panel1.Location = New System.Drawing.Point(9, 30)
         Me.panel1.Name = "panel1"
         Me.panel1.Size = New System.Drawing.Size(401, 302)
         Me.panel1.TabIndex = 25
         '
         '_txtYPos
         '
         Me._txtYPos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
         Me._txtYPos.FlatStyle = System.Windows.Forms.FlatStyle.Flat
         Me._txtYPos.Location = New System.Drawing.Point(124, 271)
         Me._txtYPos.Name = "_txtYPos"
         Me._txtYPos.Size = New System.Drawing.Size(49, 13)
         Me._txtYPos.TabIndex = 38
         '
         'label5
         '
         Me.label5.AutoSize = True
         Me.label5.Location = New System.Drawing.Point(104, 271)
         Me.label5.Name = "label5"
         Me.label5.Size = New System.Drawing.Size(14, 13)
         Me.label5.TabIndex = 37
         Me.label5.Text = "Y"
         '
         '_txtXPos
         '
         Me._txtXPos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
         Me._txtXPos.FlatStyle = System.Windows.Forms.FlatStyle.Flat
         Me._txtXPos.Location = New System.Drawing.Point(55, 271)
         Me._txtXPos.Name = "_txtXPos"
         Me._txtXPos.Size = New System.Drawing.Size(46, 13)
         Me._txtXPos.TabIndex = 36
         '
         'label2
         '
         Me.label2.AutoSize = True
         Me.label2.Location = New System.Drawing.Point(34, 271)
         Me.label2.Name = "label2"
         Me.label2.Size = New System.Drawing.Size(14, 13)
         Me.label2.TabIndex = 28
         Me.label2.Text = "X"
         '
         '_radMoveHist
         '
         Me._radMoveHist.Appearance = System.Windows.Forms.Appearance.Button
         Me._radMoveHist.AutoSize = True
         Me._radMoveHist.Location = New System.Drawing.Point(242, 267)
         Me._radMoveHist.Name = "_radMoveHist"
         Me._radMoveHist.Size = New System.Drawing.Size(44, 23)
         Me._radMoveHist.TabIndex = 35
         Me._radMoveHist.TabStop = True
         Me._radMoveHist.Text = "Move"
         Me._radMoveHist.UseVisualStyleBackColor = True
         '
         'button1
         '
         Me.button1.Location = New System.Drawing.Point(340, 266)
         Me.button1.Name = "button1"
         Me.button1.Size = New System.Drawing.Size(49, 25)
         Me.button1.TabIndex = 34
         Me.button1.Text = "Reset"
         Me.button1.UseVisualStyleBackColor = True
         '
         '_radMove
         '
         Me._radMove.Appearance = System.Windows.Forms.Appearance.Button
         Me._radMove.AutoSize = True
         Me._radMove.Location = New System.Drawing.Point(190, 267)
         Me._radMove.Name = "_radMove"
         Me._radMove.Size = New System.Drawing.Size(46, 23)
         Me._radMove.TabIndex = 32
         Me._radMove.TabStop = True
         Me._radMove.Text = "Adjust"
         Me._radMove.UseVisualStyleBackColor = True
         '
         '_radZoom
         '
         Me._radZoom.Appearance = System.Windows.Forms.Appearance.Button
         Me._radZoom.AutoSize = True
         Me._radZoom.Location = New System.Drawing.Point(292, 267)
         Me._radZoom.Name = "_radZoom"
         Me._radZoom.Size = New System.Drawing.Size(44, 23)
         Me._radZoom.TabIndex = 31
         Me._radZoom.TabStop = True
         Me._radZoom.Text = "Zoom"
         Me._radZoom.UseVisualStyleBackColor = True
         '
         '_maxHistogram
         '
         Me._maxHistogram.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (CByte(0)))
         Me._maxHistogram.ImageAlign = System.Drawing.ContentAlignment.TopRight
         Me._maxHistogram.Location = New System.Drawing.Point(360, 245)
         Me._maxHistogram.Name = "_maxHistogram"
         Me._maxHistogram.Size = New System.Drawing.Size(30, 10)
         Me._maxHistogram.TabIndex = 29
         Me._maxHistogram.Text = "32332"
         Me._maxHistogram.TextAlign = System.Drawing.ContentAlignment.TopRight
         '
         '_minHistogram
         '
         Me._minHistogram.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (CByte(0)))
         Me._minHistogram.Location = New System.Drawing.Point(34, 245)
         Me._minHistogram.Name = "_minHistogram"
         Me._minHistogram.Size = New System.Drawing.Size(30, 10)
         Me._minHistogram.TabIndex = 28
         Me._minHistogram.Text = "32332"
         '
         '_maxValue
         '
         Me._maxValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (CByte(0)))
         Me._maxValue.Location = New System.Drawing.Point(9, 18)
         Me._maxValue.Name = "_maxValue"
         Me._maxValue.Size = New System.Drawing.Size(25, 10)
         Me._maxValue.TabIndex = 27
         Me._maxValue.Text = "32332"
         Me._maxValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight
         '
         '_minValue
         '
         Me._minValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (CByte(0)))
         Me._minValue.Location = New System.Drawing.Point(5, 224)
         Me._minValue.Name = "_minValue"
         Me._minValue.Size = New System.Drawing.Size(25, 10)
         Me._minValue.TabIndex = 26
         Me._minValue.Text = "32332"
         Me._minValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight
         '
         '_histogramMap
         '
         Me._histogramMap.BackColor = System.Drawing.SystemColors.ScrollBar
         Me._histogramMap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
         Me._histogramMap.Location = New System.Drawing.Point(36, 14)
         Me._histogramMap.Name = "_histogramMap"
         Me._histogramMap.Size = New System.Drawing.Size(354, 224)
         Me._histogramMap.TabIndex = 25
         '
         '_groupBox
         '
         Me._groupBox.Controls.Add(Me._save)
         Me._groupBox.Controls.Add(Me._cmbPalette)
         Me._groupBox.Controls.Add(Me.label1)
         Me._groupBox.Location = New System.Drawing.Point(10, 338)
         Me._groupBox.Name = "_groupBox"
         Me._groupBox.Size = New System.Drawing.Size(400, 52)
         Me._groupBox.TabIndex = 26
         Me._groupBox.TabStop = False
         Me._groupBox.Text = "Palette Type"
         '
         '_save
         '
         Me._save.Location = New System.Drawing.Point(314, 21)
         Me._save.Name = "_save"
         Me._save.Size = New System.Drawing.Size(57, 26)
         Me._save.TabIndex = 27
         Me._save.Text = "&Save"
         Me._save.UseVisualStyleBackColor = True
         '
         '_cmbPalette
         '
         Me._cmbPalette.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
         Me._cmbPalette.FormattingEnabled = True
         Me._cmbPalette.Location = New System.Drawing.Point(167, 23)
         Me._cmbPalette.Name = "_cmbPalette"
         Me._cmbPalette.Size = New System.Drawing.Size(132, 21)
         Me._cmbPalette.TabIndex = 1
         '
         'label1
         '
         Me.label1.AutoSize = True
         Me.label1.Location = New System.Drawing.Point(83, 26)
         Me.label1.Name = "label1"
         Me.label1.Size = New System.Drawing.Size(73, 13)
         Me.label1.TabIndex = 0
         Me.label1.Text = "Preset Palette"
         '
         '_btnExport
         '
         Me._btnExport.Location = New System.Drawing.Point(20, 404)
         Me._btnExport.Name = "_btnExport"
         Me._btnExport.Size = New System.Drawing.Size(90, 33)
         Me._btnExport.TabIndex = 27
         Me._btnExport.Text = "&Export"
         Me._btnExport.UseVisualStyleBackColor = True
         '
         '_btnImport
         '
         Me._btnImport.Location = New System.Drawing.Point(116, 404)
         Me._btnImport.Name = "_btnImport"
         Me._btnImport.Size = New System.Drawing.Size(90, 33)
         Me._btnImport.TabIndex = 28
         Me._btnImport.Text = "&Import"
         Me._btnImport.UseVisualStyleBackColor = True
         '
         'Histogram3DDialog
         '
         Me.AcceptButton = Me._btnOK
         Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.ClientSize = New System.Drawing.Size(423, 452)
         Me.Controls.Add(Me._btnImport)
         Me.Controls.Add(Me._btnExport)
         Me.Controls.Add(Me._groupBox)
         Me.Controls.Add(Me.panel1)
         Me.Controls.Add(Me._btnReset)
         Me.Controls.Add(Me._btnOK)
         Me.Controls.Add(Me._tabControl)
         Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
         Me.KeyPreview = True
         Me.MaximizeBox = False
         Me.MinimizeBox = False
         Me.Name = "Histogram3DDialog"
         Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
         Me.Text = "Color Map"
         Me._tabControl.ResumeLayout(False)
         Me.panel1.ResumeLayout(False)
         Me.panel1.PerformLayout()
         Me._groupBox.ResumeLayout(False)
         Me._groupBox.PerformLayout()
         Me.ResumeLayout(False)

      End Sub

#End Region

      Private WithEvents _btnReset As System.Windows.Forms.Button
      Private WithEvents _btnOK As System.Windows.Forms.Button
      Private _tabGreen As System.Windows.Forms.TabPage
      Private _tabRed As System.Windows.Forms.TabPage
      Private WithEvents _tabControl As System.Windows.Forms.TabControl
      Private _tabBlue As System.Windows.Forms.TabPage
      Private WithEvents panel1 As System.Windows.Forms.Panel
      Private _maxHistogram As System.Windows.Forms.Label
      Private _minHistogram As System.Windows.Forms.Label
      Private _maxValue As System.Windows.Forms.Label
      Private _minValue As System.Windows.Forms.Label
      Private WithEvents _histogramMap As System.Windows.Forms.Label
      Private _groupBox As System.Windows.Forms.GroupBox
      Private label1 As System.Windows.Forms.Label
      Private WithEvents _cmbPalette As System.Windows.Forms.ComboBox
      Private _tabOpacity As System.Windows.Forms.TabPage
      Private WithEvents _radMove As System.Windows.Forms.RadioButton
      Private WithEvents _radZoom As System.Windows.Forms.RadioButton
      Private WithEvents button1 As System.Windows.Forms.Button
      Private WithEvents _save As System.Windows.Forms.Button
      Private WithEvents _btnExport As System.Windows.Forms.Button
      Private WithEvents _btnImport As System.Windows.Forms.Button
      Private WithEvents _radMoveHist As System.Windows.Forms.RadioButton
      Private _txtYPos As System.Windows.Forms.Label
      Private label5 As System.Windows.Forms.Label
      Private _txtXPos As System.Windows.Forms.Label
      Private label2 As System.Windows.Forms.Label
   End Class
End Namespace
