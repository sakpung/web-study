Imports Microsoft.VisualBasic
Imports System
Namespace ImageProcessingDemo
   Public Partial Class BlankPageDetectorDialog
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
         Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BlankPageDetectorDialog))
         Me._lblUnitRight = New System.Windows.Forms.Label()
         Me._lblUnitTop = New System.Windows.Forms.Label()
         Me._gbDetectPage = New System.Windows.Forms.GroupBox()
         Me._rdUseInches = New System.Windows.Forms.RadioButton()
         Me._chkUseActiveArea = New System.Windows.Forms.CheckBox()
         Me._rdUseCentimeters = New System.Windows.Forms.RadioButton()
         Me._chkIgnorBleedThrough = New System.Windows.Forms.CheckBox()
         Me._rdUsePixels = New System.Windows.Forms.RadioButton()
         Me._chkDetectLinedPage = New System.Windows.Forms.CheckBox()
         Me._chkDetectNoisyPage = New System.Windows.Forms.CheckBox()
         Me._chkDetectTextOnly = New System.Windows.Forms.CheckBox()
         Me._chkUseAdvanced = New System.Windows.Forms.CheckBox()
         Me._lblUnitBottom = New System.Windows.Forms.Label()
         Me._lblUnitLeft = New System.Windows.Forms.Label()
         Me._lblBottom = New System.Windows.Forms.Label()
         Me._tbRight = New System.Windows.Forms.TextBox()
         Me._lblRight = New System.Windows.Forms.Label()
         Me._tbBottom = New System.Windows.Forms.TextBox()
         Me._lblTop = New System.Windows.Forms.Label()
         Me._lblUnits = New System.Windows.Forms.Label()
         Me._tbTop = New System.Windows.Forms.TextBox()
         Me._lblLeft = New System.Windows.Forms.Label()
         Me._gbMargins = New System.Windows.Forms.GroupBox()
         Me._chkUseDefaultMargin = New System.Windows.Forms.CheckBox()
         Me._gbUserMargins = New System.Windows.Forms.GroupBox()
         Me._tbLeft = New System.Windows.Forms.TextBox()
         Me._btnCancel = New System.Windows.Forms.Button()
         Me._btnok = New System.Windows.Forms.Button()
         Me._gbDetectPage.SuspendLayout()
         Me._gbMargins.SuspendLayout()
         Me._gbUserMargins.SuspendLayout()
         Me.SuspendLayout()
         '
         '_lblUnitRight
         '
         Me._lblUnitRight.AutoSize = True
         Me._lblUnitRight.ImeMode = System.Windows.Forms.ImeMode.NoControl
         Me._lblUnitRight.Location = New System.Drawing.Point(316, 21)
         Me._lblUnitRight.Name = "_lblUnitRight"
         Me._lblUnitRight.Size = New System.Drawing.Size(34, 13)
         Me._lblUnitRight.TabIndex = 9
         Me._lblUnitRight.Text = "Pixels"
         '
         '_lblUnitTop
         '
         Me._lblUnitTop.AutoSize = True
         Me._lblUnitTop.ImeMode = System.Windows.Forms.ImeMode.NoControl
         Me._lblUnitTop.Location = New System.Drawing.Point(127, 50)
         Me._lblUnitTop.Name = "_lblUnitTop"
         Me._lblUnitTop.Size = New System.Drawing.Size(34, 13)
         Me._lblUnitTop.TabIndex = 8
         Me._lblUnitTop.Text = "Pixels"
         '
         '_gbDetectPage
         '
         Me._gbDetectPage.Controls.Add(Me._rdUseInches)
         Me._gbDetectPage.Controls.Add(Me._chkUseActiveArea)
         Me._gbDetectPage.Controls.Add(Me._rdUseCentimeters)
         Me._gbDetectPage.Controls.Add(Me._chkIgnorBleedThrough)
         Me._gbDetectPage.Controls.Add(Me._rdUsePixels)
         Me._gbDetectPage.Controls.Add(Me._chkDetectLinedPage)
         Me._gbDetectPage.Controls.Add(Me._chkDetectNoisyPage)
         Me._gbDetectPage.Controls.Add(Me._chkDetectTextOnly)
         Me._gbDetectPage.Controls.Add(Me._chkUseAdvanced)
         Me._gbDetectPage.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._gbDetectPage.Location = New System.Drawing.Point(415, 11)
         Me._gbDetectPage.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
         Me._gbDetectPage.Name = "_gbDetectPage"
         Me._gbDetectPage.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
         Me._gbDetectPage.Size = New System.Drawing.Size(287, 152)
         Me._gbDetectPage.TabIndex = 7
         Me._gbDetectPage.TabStop = False
         Me._gbDetectPage.Text = "Blank page Properties"
         '
         '_rdUseInches
         '
         Me._rdUseInches.AutoSize = True
         Me._rdUseInches.ImeMode = System.Windows.Forms.ImeMode.NoControl
         Me._rdUseInches.Location = New System.Drawing.Point(158, 60)
         Me._rdUseInches.Name = "_rdUseInches"
         Me._rdUseInches.Size = New System.Drawing.Size(78, 17)
         Me._rdUseInches.TabIndex = 9
         Me._rdUseInches.TabStop = True
         Me._rdUseInches.Text = "Use Inches"
         Me._rdUseInches.UseVisualStyleBackColor = True
         '
         '_chkUseActiveArea
         '
         Me._chkUseActiveArea.AutoSize = True
         Me._chkUseActiveArea.ImeMode = System.Windows.Forms.ImeMode.NoControl
         Me._chkUseActiveArea.Location = New System.Drawing.Point(6, 128)
         Me._chkUseActiveArea.Name = "_chkUseActiveArea"
         Me._chkUseActiveArea.Size = New System.Drawing.Size(103, 17)
         Me._chkUseActiveArea.TabIndex = 10
         Me._chkUseActiveArea.Text = "Use Active Area"
         Me._chkUseActiveArea.UseVisualStyleBackColor = True
         '
         '_rdUseCentimeters
         '
         Me._rdUseCentimeters.AutoSize = True
         Me._rdUseCentimeters.ImeMode = System.Windows.Forms.ImeMode.NoControl
         Me._rdUseCentimeters.Location = New System.Drawing.Point(158, 40)
         Me._rdUseCentimeters.Name = "_rdUseCentimeters"
         Me._rdUseCentimeters.Size = New System.Drawing.Size(104, 17)
         Me._rdUseCentimeters.TabIndex = 8
         Me._rdUseCentimeters.TabStop = True
         Me._rdUseCentimeters.Text = "Use Centimeters"
         Me._rdUseCentimeters.UseVisualStyleBackColor = True
         '
         '_chkIgnorBleedThrough
         '
         Me._chkIgnorBleedThrough.AutoSize = True
         Me._chkIgnorBleedThrough.ImeMode = System.Windows.Forms.ImeMode.NoControl
         Me._chkIgnorBleedThrough.Location = New System.Drawing.Point(6, 105)
         Me._chkIgnorBleedThrough.Name = "_chkIgnorBleedThrough"
         Me._chkIgnorBleedThrough.Size = New System.Drawing.Size(129, 17)
         Me._chkIgnorBleedThrough.TabIndex = 9
         Me._chkIgnorBleedThrough.Text = "Ignore Bleed-through"
         Me._chkIgnorBleedThrough.UseVisualStyleBackColor = True
         '
         '_rdUsePixels
         '
         Me._rdUsePixels.AutoSize = True
         Me._rdUsePixels.ImeMode = System.Windows.Forms.ImeMode.NoControl
         Me._rdUsePixels.Location = New System.Drawing.Point(158, 20)
         Me._rdUsePixels.Name = "_rdUsePixels"
         Me._rdUsePixels.Size = New System.Drawing.Size(73, 17)
         Me._rdUsePixels.TabIndex = 7
         Me._rdUsePixels.TabStop = True
         Me._rdUsePixels.Text = "Use Pixels"
         Me._rdUsePixels.UseVisualStyleBackColor = True
         '
         '_chkDetectLinedPage
         '
         Me._chkDetectLinedPage.AutoSize = True
         Me._chkDetectLinedPage.ImeMode = System.Windows.Forms.ImeMode.NoControl
         Me._chkDetectLinedPage.Location = New System.Drawing.Point(6, 62)
         Me._chkDetectLinedPage.Name = "_chkDetectLinedPage"
         Me._chkDetectLinedPage.Size = New System.Drawing.Size(113, 17)
         Me._chkDetectLinedPage.TabIndex = 8
         Me._chkDetectLinedPage.Text = "Detect Lined Page"
         Me._chkDetectLinedPage.UseVisualStyleBackColor = True
         '
         '_chkDetectNoisyPage
         '
         Me._chkDetectNoisyPage.AutoSize = True
         Me._chkDetectNoisyPage.ImeMode = System.Windows.Forms.ImeMode.NoControl
         Me._chkDetectNoisyPage.Location = New System.Drawing.Point(6, 41)
         Me._chkDetectNoisyPage.Name = "_chkDetectNoisyPage"
         Me._chkDetectNoisyPage.Size = New System.Drawing.Size(114, 17)
         Me._chkDetectNoisyPage.TabIndex = 7
         Me._chkDetectNoisyPage.Text = "Detect Noisy Page"
         Me._chkDetectNoisyPage.UseVisualStyleBackColor = True
         '
         '_chkDetectTextOnly
         '
         Me._chkDetectTextOnly.AutoSize = True
         Me._chkDetectTextOnly.ImeMode = System.Windows.Forms.ImeMode.NoControl
         Me._chkDetectTextOnly.Location = New System.Drawing.Point(6, 85)
         Me._chkDetectTextOnly.Name = "_chkDetectTextOnly"
         Me._chkDetectTextOnly.Size = New System.Drawing.Size(108, 17)
         Me._chkDetectTextOnly.TabIndex = 6
         Me._chkDetectTextOnly.Text = "Detect Text Only"
         Me._chkDetectTextOnly.UseVisualStyleBackColor = True
         '
         '_chkUseAdvanced
         '
         Me._chkUseAdvanced.AutoSize = True
         Me._chkUseAdvanced.ImeMode = System.Windows.Forms.ImeMode.NoControl
         Me._chkUseAdvanced.Location = New System.Drawing.Point(6, 20)
         Me._chkUseAdvanced.Name = "_chkUseAdvanced"
         Me._chkUseAdvanced.Size = New System.Drawing.Size(95, 17)
         Me._chkUseAdvanced.TabIndex = 2
         Me._chkUseAdvanced.Text = "Use Advanced"
         Me._chkUseAdvanced.UseVisualStyleBackColor = True
         '
         '_lblUnitBottom
         '
         Me._lblUnitBottom.AutoSize = True
         Me._lblUnitBottom.ImeMode = System.Windows.Forms.ImeMode.NoControl
         Me._lblUnitBottom.Location = New System.Drawing.Point(316, 48)
         Me._lblUnitBottom.Name = "_lblUnitBottom"
         Me._lblUnitBottom.Size = New System.Drawing.Size(34, 13)
         Me._lblUnitBottom.TabIndex = 10
         Me._lblUnitBottom.Text = "Pixels"
         '
         '_lblUnitLeft
         '
         Me._lblUnitLeft.AutoSize = True
         Me._lblUnitLeft.ImeMode = System.Windows.Forms.ImeMode.NoControl
         Me._lblUnitLeft.Location = New System.Drawing.Point(127, 21)
         Me._lblUnitLeft.Name = "_lblUnitLeft"
         Me._lblUnitLeft.Size = New System.Drawing.Size(34, 13)
         Me._lblUnitLeft.TabIndex = 7
         Me._lblUnitLeft.Text = "Pixels"
         '
         '_lblBottom
         '
         Me._lblBottom.AutoSize = True
         Me._lblBottom.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._lblBottom.ImeMode = System.Windows.Forms.ImeMode.NoControl
         Me._lblBottom.Location = New System.Drawing.Point(197, 48)
         Me._lblBottom.Name = "_lblBottom"
         Me._lblBottom.Size = New System.Drawing.Size(41, 13)
         Me._lblBottom.TabIndex = 6
         Me._lblBottom.Text = "Bottom"
         '
         '_tbRight
         '
         Me._tbRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
         Me._tbRight.Location = New System.Drawing.Point(245, 19)
         Me._tbRight.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
         Me._tbRight.Name = "_tbRight"
         Me._tbRight.Size = New System.Drawing.Size(65, 20)
         Me._tbRight.TabIndex = 3
         '
         '_lblRight
         '
         Me._lblRight.AutoSize = True
         Me._lblRight.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._lblRight.ImeMode = System.Windows.Forms.ImeMode.NoControl
         Me._lblRight.Location = New System.Drawing.Point(197, 21)
         Me._lblRight.Name = "_lblRight"
         Me._lblRight.Size = New System.Drawing.Size(32, 13)
         Me._lblRight.TabIndex = 5
         Me._lblRight.Text = "Right"
         '
         '_tbBottom
         '
         Me._tbBottom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
         Me._tbBottom.Location = New System.Drawing.Point(245, 46)
         Me._tbBottom.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
         Me._tbBottom.Name = "_tbBottom"
         Me._tbBottom.Size = New System.Drawing.Size(65, 20)
         Me._tbBottom.TabIndex = 2
         '
         '_lblTop
         '
         Me._lblTop.AutoSize = True
         Me._lblTop.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._lblTop.ImeMode = System.Windows.Forms.ImeMode.NoControl
         Me._lblTop.Location = New System.Drawing.Point(15, 50)
         Me._lblTop.Name = "_lblTop"
         Me._lblTop.Size = New System.Drawing.Size(25, 13)
         Me._lblTop.TabIndex = 4
         Me._lblTop.Text = "Top"
         '
         '_lblUnits
         '
         Me._lblUnits.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._lblUnits.ImeMode = System.Windows.Forms.ImeMode.NoControl
         Me._lblUnits.Location = New System.Drawing.Point(14, 46)
         Me._lblUnits.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
         Me._lblUnits.Name = "_lblUnits"
         Me._lblUnits.Size = New System.Drawing.Size(275, 19)
         Me._lblUnits.TabIndex = 8
         Me._lblUnits.Text = "Units of 1/1000  i.e. for inch unit means 1000 is an inch."
         Me._lblUnits.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
         '
         '_tbTop
         '
         Me._tbTop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
         Me._tbTop.Location = New System.Drawing.Point(56, 48)
         Me._tbTop.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
         Me._tbTop.Name = "_tbTop"
         Me._tbTop.Size = New System.Drawing.Size(65, 20)
         Me._tbTop.TabIndex = 1
         '
         '_lblLeft
         '
         Me._lblLeft.AutoSize = True
         Me._lblLeft.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._lblLeft.ImeMode = System.Windows.Forms.ImeMode.NoControl
         Me._lblLeft.Location = New System.Drawing.Point(15, 24)
         Me._lblLeft.Name = "_lblLeft"
         Me._lblLeft.Size = New System.Drawing.Size(26, 13)
         Me._lblLeft.TabIndex = 3
         Me._lblLeft.Text = "Left"
         '
         '_gbMargins
         '
         Me._gbMargins.Controls.Add(Me._lblUnits)
         Me._gbMargins.Controls.Add(Me._chkUseDefaultMargin)
         Me._gbMargins.Controls.Add(Me._gbUserMargins)
         Me._gbMargins.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._gbMargins.Location = New System.Drawing.Point(12, 11)
         Me._gbMargins.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
         Me._gbMargins.Name = "_gbMargins"
         Me._gbMargins.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
         Me._gbMargins.Size = New System.Drawing.Size(397, 152)
         Me._gbMargins.TabIndex = 10
         Me._gbMargins.TabStop = False
         Me._gbMargins.Text = "Margins"
         '
         '_chkUseDefaultMargin
         '
         Me._chkUseDefaultMargin.AutoSize = True
         Me._chkUseDefaultMargin.ImeMode = System.Windows.Forms.ImeMode.NoControl
         Me._chkUseDefaultMargin.Location = New System.Drawing.Point(17, 20)
         Me._chkUseDefaultMargin.Name = "_chkUseDefaultMargin"
         Me._chkUseDefaultMargin.Size = New System.Drawing.Size(122, 17)
         Me._chkUseDefaultMargin.TabIndex = 3
         Me._chkUseDefaultMargin.Text = "Use Default Margins"
         Me._chkUseDefaultMargin.UseVisualStyleBackColor = True
         '
         '_gbUserMargins
         '
         Me._gbUserMargins.Controls.Add(Me._lblUnitBottom)
         Me._gbUserMargins.Controls.Add(Me._lblUnitRight)
         Me._gbUserMargins.Controls.Add(Me._lblUnitTop)
         Me._gbUserMargins.Controls.Add(Me._lblUnitLeft)
         Me._gbUserMargins.Controls.Add(Me._lblBottom)
         Me._gbUserMargins.Controls.Add(Me._tbRight)
         Me._gbUserMargins.Controls.Add(Me._lblRight)
         Me._gbUserMargins.Controls.Add(Me._tbBottom)
         Me._gbUserMargins.Controls.Add(Me._lblTop)
         Me._gbUserMargins.Controls.Add(Me._tbTop)
         Me._gbUserMargins.Controls.Add(Me._lblLeft)
         Me._gbUserMargins.Controls.Add(Me._tbLeft)
         Me._gbUserMargins.Enabled = False
         Me._gbUserMargins.Location = New System.Drawing.Point(6, 66)
         Me._gbUserMargins.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
         Me._gbUserMargins.Name = "_gbUserMargins"
         Me._gbUserMargins.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
         Me._gbUserMargins.Size = New System.Drawing.Size(385, 80)
         Me._gbUserMargins.TabIndex = 2
         Me._gbUserMargins.TabStop = False
         '
         '_tbLeft
         '
         Me._tbLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
         Me._tbLeft.Location = New System.Drawing.Point(56, 19)
         Me._tbLeft.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
         Me._tbLeft.Name = "_tbLeft"
         Me._tbLeft.Size = New System.Drawing.Size(65, 20)
         Me._tbLeft.TabIndex = 0
         '
         '_btnCancel
         '
         Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
         Me._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._btnCancel.ImeMode = System.Windows.Forms.ImeMode.NoControl
         Me._btnCancel.Location = New System.Drawing.Point(362, 175)
         Me._btnCancel.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
         Me._btnCancel.Name = "_btnCancel"
         Me._btnCancel.Size = New System.Drawing.Size(72, 19)
         Me._btnCancel.TabIndex = 9
         Me._btnCancel.Text = "Cancel"
         Me._btnCancel.UseVisualStyleBackColor = True
         '
         '_btnok
         '
         Me._btnok.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._btnok.ImeMode = System.Windows.Forms.ImeMode.NoControl
         Me._btnok.Location = New System.Drawing.Point(278, 175)
         Me._btnok.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
         Me._btnok.Name = "_btnok"
         Me._btnok.Size = New System.Drawing.Size(72, 22)
         Me._btnok.TabIndex = 8
         Me._btnok.Text = "OK"
         Me._btnok.UseVisualStyleBackColor = True
         '
         'BlankPageDetectorDialog
         '
         Me.AcceptButton = Me._btnok
         Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.CancelButton = Me._btnCancel
         Me.ClientSize = New System.Drawing.Size(717, 210)
         Me.Controls.Add(Me._gbDetectPage)
         Me.Controls.Add(Me._gbMargins)
         Me.Controls.Add(Me._btnCancel)
         Me.Controls.Add(Me._btnok)
         Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
         Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
         Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
         Me.MaximizeBox = False
         Me.MinimizeBox = False
         Me.Name = "BlankPageDetectorDialog"
         Me.ShowIcon = False
         Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
         Me.Text = "Blank Page Detector"
         Me._gbDetectPage.ResumeLayout(False)
         Me._gbDetectPage.PerformLayout()
         Me._gbMargins.ResumeLayout(False)
         Me._gbMargins.PerformLayout()
         Me._gbUserMargins.ResumeLayout(False)
         Me._gbUserMargins.PerformLayout()
         Me.ResumeLayout(False)

      End Sub
      Private WithEvents _lblUnitRight As System.Windows.Forms.Label
      Private WithEvents _lblUnitTop As System.Windows.Forms.Label
      Private WithEvents _gbDetectPage As System.Windows.Forms.GroupBox
      Private WithEvents _rdUseInches As System.Windows.Forms.RadioButton
      Private WithEvents _chkUseActiveArea As System.Windows.Forms.CheckBox
      Private WithEvents _rdUseCentimeters As System.Windows.Forms.RadioButton
      Private WithEvents _chkIgnorBleedThrough As System.Windows.Forms.CheckBox
      Private WithEvents _rdUsePixels As System.Windows.Forms.RadioButton
      Private WithEvents _chkDetectLinedPage As System.Windows.Forms.CheckBox
      Private WithEvents _chkDetectNoisyPage As System.Windows.Forms.CheckBox
      Private WithEvents _chkDetectTextOnly As System.Windows.Forms.CheckBox
      Private WithEvents _chkUseAdvanced As System.Windows.Forms.CheckBox
      Private WithEvents _lblUnitBottom As System.Windows.Forms.Label
      Private WithEvents _lblUnitLeft As System.Windows.Forms.Label
      Private WithEvents _lblBottom As System.Windows.Forms.Label
      Private WithEvents _tbRight As System.Windows.Forms.TextBox
      Private WithEvents _lblRight As System.Windows.Forms.Label
      Private WithEvents _tbBottom As System.Windows.Forms.TextBox
      Private WithEvents _lblTop As System.Windows.Forms.Label
      Private WithEvents _lblUnits As System.Windows.Forms.Label
      Private WithEvents _tbTop As System.Windows.Forms.TextBox
      Private WithEvents _lblLeft As System.Windows.Forms.Label
      Private WithEvents _gbMargins As System.Windows.Forms.GroupBox
      Private WithEvents _chkUseDefaultMargin As System.Windows.Forms.CheckBox
      Private WithEvents _gbUserMargins As System.Windows.Forms.GroupBox
      Private WithEvents _tbLeft As System.Windows.Forms.TextBox
      Private WithEvents _btnCancel As System.Windows.Forms.Button
      Private WithEvents _btnok As System.Windows.Forms.Button

	  #End Region

   End Class
End Namespace