
Partial Class LineHistogramDialog
   ''' <summary>
   ''' Required designer variable.
   ''' </summary>
   Private components As System.ComponentModel.IContainer = Nothing

   ''' <summary>
   ''' Clean up any resources being used.
   ''' </summary>
   ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
   Protected Overrides Sub Dispose(disposing As Boolean)
      If disposing AndAlso (components IsNot Nothing) Then
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
      Me._lblXStart = New System.Windows.Forms.Label()
      Me._lblXEnd = New System.Windows.Forms.Label()
      Me._lblPixelNumber = New System.Windows.Forms.Label()
      Me._lblYStart = New System.Windows.Forms.Label()
      Me._lblYEnd = New System.Windows.Forms.Label()
      Me._txtPixelNumber = New System.Windows.Forms.TextBox()
      Me._tabs = New System.Windows.Forms.TabControl()
      Me._tabAll = New System.Windows.Forms.TabPage()
      Me._tabRed = New System.Windows.Forms.TabPage()
      Me._tabGreen = New System.Windows.Forms.TabPage()
      Me._tabBlue = New System.Windows.Forms.TabPage()
      Me._lblXPixel = New System.Windows.Forms.Label()
      Me._lblYPixel = New System.Windows.Forms.Label()
      Me._txtXPixel = New System.Windows.Forms.TextBox()
      Me._txtYPixel = New System.Windows.Forms.TextBox()
      Me._lblRed = New System.Windows.Forms.Label()
      Me._lblRedMax = New System.Windows.Forms.Label()
      Me._lblRedMin = New System.Windows.Forms.Label()
      Me._txtRed = New System.Windows.Forms.TextBox()
      Me._txtRedMax = New System.Windows.Forms.TextBox()
      Me._txtRedMin = New System.Windows.Forms.TextBox()
      Me._txtGreenMin = New System.Windows.Forms.TextBox()
      Me._txtGreenMax = New System.Windows.Forms.TextBox()
      Me._txtGreen = New System.Windows.Forms.TextBox()
      Me._lblGreenMin = New System.Windows.Forms.Label()
      Me._lblGreenMax = New System.Windows.Forms.Label()
      Me._lblGreen = New System.Windows.Forms.Label()
      Me._txtBlueMin = New System.Windows.Forms.TextBox()
      Me._txtBlueMax = New System.Windows.Forms.TextBox()
      Me._txtBlue = New System.Windows.Forms.TextBox()
      Me._lblBlueMin = New System.Windows.Forms.Label()
      Me._lblBlueMax = New System.Windows.Forms.Label()
      Me._lblBlue = New System.Windows.Forms.Label()
      Me._btnOK = New System.Windows.Forms.Button()
      Me._tbTabs = New System.Windows.Forms.TrackBar()
      Me._numXStart = New System.Windows.Forms.NumericUpDown()
      Me._numXEnd = New System.Windows.Forms.NumericUpDown()
      Me._numYStart = New System.Windows.Forms.NumericUpDown()
      Me._numYEnd = New System.Windows.Forms.NumericUpDown()
      Me._gbCursorPosition = New System.Windows.Forms.GroupBox()
      Me._yCursorPosition = New System.Windows.Forms.TextBox()
      Me.label2 = New System.Windows.Forms.Label()
      Me._xCursorPosition = New System.Windows.Forms.TextBox()
      Me.label1 = New System.Windows.Forms.Label()
      Me._cbFillCurve = New System.Windows.Forms.CheckBox()
      Me._cbMovable = New System.Windows.Forms.CheckBox()
      Me._tabs.SuspendLayout()
      CType(Me._tbTabs, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me._numXStart, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me._numXEnd, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me._numYStart, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me._numYEnd, System.ComponentModel.ISupportInitialize).BeginInit()
      Me._gbCursorPosition.SuspendLayout()
      Me.SuspendLayout()
      ' 
      ' _lblXStart
      ' 
      Me._lblXStart.AutoSize = True
      Me._lblXStart.Location = New System.Drawing.Point(79, 72)
      Me._lblXStart.Name = "_lblXStart"
      Me._lblXStart.Size = New System.Drawing.Size(42, 13)
      Me._lblXStart.TabIndex = 0
      Me._lblXStart.Text = "X Start:"
      ' 
      ' _lblXEnd
      ' 
      Me._lblXEnd.AutoSize = True
      Me._lblXEnd.Location = New System.Drawing.Point(79, 106)
      Me._lblXEnd.Name = "_lblXEnd"
      Me._lblXEnd.Size = New System.Drawing.Size(39, 13)
      Me._lblXEnd.TabIndex = 1
      Me._lblXEnd.Text = "X End:"
      ' 
      ' _lblPixelNumber
      ' 
      Me._lblPixelNumber.AutoSize = True
      Me._lblPixelNumber.Location = New System.Drawing.Point(140, 138)
      Me._lblPixelNumber.Name = "_lblPixelNumber"
      Me._lblPixelNumber.Size = New System.Drawing.Size(72, 13)
      Me._lblPixelNumber.TabIndex = 2
      Me._lblPixelNumber.Text = "Pixel Number:"
      ' 
      ' _lblYStart
      ' 
      Me._lblYStart.AutoSize = True
      Me._lblYStart.Location = New System.Drawing.Point(244, 72)
      Me._lblYStart.Name = "_lblYStart"
      Me._lblYStart.Size = New System.Drawing.Size(42, 13)
      Me._lblYStart.TabIndex = 3
      Me._lblYStart.Text = "Y Start:"
      ' 
      ' _lblYEnd
      ' 
      Me._lblYEnd.AutoSize = True
      Me._lblYEnd.Location = New System.Drawing.Point(244, 106)
      Me._lblYEnd.Name = "_lblYEnd"
      Me._lblYEnd.Size = New System.Drawing.Size(39, 13)
      Me._lblYEnd.TabIndex = 4
      Me._lblYEnd.Text = "Y End:"
      ' 
      ' _txtPixelNumber
      ' 
      Me._txtPixelNumber.Location = New System.Drawing.Point(218, 135)
      Me._txtPixelNumber.Name = "_txtPixelNumber"
      Me._txtPixelNumber.[ReadOnly] = True
      Me._txtPixelNumber.Size = New System.Drawing.Size(60, 20)
      Me._txtPixelNumber.TabIndex = 9
      Me._txtPixelNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
      ' 
      ' _tabs
      ' 
      Me._tabs.Controls.Add(Me._tabAll)
      Me._tabs.Controls.Add(Me._tabRed)
      Me._tabs.Controls.Add(Me._tabGreen)
      Me._tabs.Controls.Add(Me._tabBlue)
      Me._tabs.Location = New System.Drawing.Point(29, 166)
      Me._tabs.Name = "_tabs"
      Me._tabs.SelectedIndex = 0
      Me._tabs.Size = New System.Drawing.Size(358, 281)
      Me._tabs.TabIndex = 10
      ' 
      ' _tabAll
      ' 
      Me._tabAll.BackColor = System.Drawing.Color.White
      Me._tabAll.Location = New System.Drawing.Point(4, 22)
      Me._tabAll.Name = "_tabAll"
      Me._tabAll.Padding = New System.Windows.Forms.Padding(3)
      Me._tabAll.Size = New System.Drawing.Size(350, 255)
      Me._tabAll.TabIndex = 0
      Me._tabAll.Text = "All"
      ' 
      ' _tabRed
      ' 
      Me._tabRed.BackColor = System.Drawing.Color.White
      Me._tabRed.Location = New System.Drawing.Point(4, 22)
      Me._tabRed.Name = "_tabRed"
      Me._tabRed.Padding = New System.Windows.Forms.Padding(3)
      Me._tabRed.Size = New System.Drawing.Size(350, 255)
      Me._tabRed.TabIndex = 1
      Me._tabRed.Text = "Red"
      ' 
      ' _tabGreen
      ' 
      Me._tabGreen.BackColor = System.Drawing.Color.White
      Me._tabGreen.Location = New System.Drawing.Point(4, 22)
      Me._tabGreen.Name = "_tabGreen"
      Me._tabGreen.Padding = New System.Windows.Forms.Padding(3)
      Me._tabGreen.Size = New System.Drawing.Size(350, 255)
      Me._tabGreen.TabIndex = 2
      Me._tabGreen.Text = "Green"
      ' 
      ' _tabBlue
      ' 
      Me._tabBlue.BackColor = System.Drawing.Color.White
      Me._tabBlue.Location = New System.Drawing.Point(4, 22)
      Me._tabBlue.Name = "_tabBlue"
      Me._tabBlue.Padding = New System.Windows.Forms.Padding(3)
      Me._tabBlue.Size = New System.Drawing.Size(350, 255)
      Me._tabBlue.TabIndex = 3
      Me._tabBlue.Text = "Blue"
      ' 
      ' _lblXPixel
      ' 
      Me._lblXPixel.AutoSize = True
      Me._lblXPixel.Location = New System.Drawing.Point(75, 501)
      Me._lblXPixel.Name = "_lblXPixel"
      Me._lblXPixel.Size = New System.Drawing.Size(42, 13)
      Me._lblXPixel.TabIndex = 11
      Me._lblXPixel.Text = "X Pixel:"
      ' 
      ' _lblYPixel
      ' 
      Me._lblYPixel.AutoSize = True
      Me._lblYPixel.Location = New System.Drawing.Point(233, 501)
      Me._lblYPixel.Name = "_lblYPixel"
      Me._lblYPixel.Size = New System.Drawing.Size(42, 13)
      Me._lblYPixel.TabIndex = 12
      Me._lblYPixel.Text = "Y Pixel:"
      ' 
      ' _txtXPixel
      ' 
      Me._txtXPixel.Location = New System.Drawing.Point(123, 498)
      Me._txtXPixel.Name = "_txtXPixel"
      Me._txtXPixel.[ReadOnly] = True
      Me._txtXPixel.Size = New System.Drawing.Size(60, 20)
      Me._txtXPixel.TabIndex = 13
      Me._txtXPixel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
      ' 
      ' _txtYPixel
      ' 
      Me._txtYPixel.Location = New System.Drawing.Point(281, 498)
      Me._txtYPixel.Name = "_txtYPixel"
      Me._txtYPixel.[ReadOnly] = True
      Me._txtYPixel.Size = New System.Drawing.Size(60, 20)
      Me._txtYPixel.TabIndex = 14
      Me._txtYPixel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
      ' 
      ' _lblRed
      ' 
      Me._lblRed.AutoSize = True
      Me._lblRed.Location = New System.Drawing.Point(32, 535)
      Me._lblRed.Name = "_lblRed"
      Me._lblRed.Size = New System.Drawing.Size(30, 13)
      Me._lblRed.TabIndex = 15
      Me._lblRed.Text = "Red:"
      ' 
      ' _lblRedMax
      ' 
      Me._lblRedMax.AutoSize = True
      Me._lblRedMax.Location = New System.Drawing.Point(32, 567)
      Me._lblRedMax.Name = "_lblRedMax"
      Me._lblRedMax.Size = New System.Drawing.Size(30, 13)
      Me._lblRedMax.TabIndex = 16
      Me._lblRedMax.Text = "Max:"
      ' 
      ' _lblRedMin
      ' 
      Me._lblRedMin.AutoSize = True
      Me._lblRedMin.Location = New System.Drawing.Point(32, 601)
      Me._lblRedMin.Name = "_lblRedMin"
      Me._lblRedMin.Size = New System.Drawing.Size(27, 13)
      Me._lblRedMin.TabIndex = 17
      Me._lblRedMin.Text = "Min:"
      ' 
      ' _txtRed
      ' 
      Me._txtRed.Location = New System.Drawing.Point(68, 532)
      Me._txtRed.Name = "_txtRed"
      Me._txtRed.[ReadOnly] = True
      Me._txtRed.Size = New System.Drawing.Size(60, 20)
      Me._txtRed.TabIndex = 18
      Me._txtRed.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
      ' 
      ' _txtRedMax
      ' 
      Me._txtRedMax.Location = New System.Drawing.Point(68, 564)
      Me._txtRedMax.Name = "_txtRedMax"
      Me._txtRedMax.[ReadOnly] = True
      Me._txtRedMax.Size = New System.Drawing.Size(60, 20)
      Me._txtRedMax.TabIndex = 19
      Me._txtRedMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
      ' 
      ' _txtRedMin
      ' 
      Me._txtRedMin.Location = New System.Drawing.Point(68, 598)
      Me._txtRedMin.Name = "_txtRedMin"
      Me._txtRedMin.[ReadOnly] = True
      Me._txtRedMin.Size = New System.Drawing.Size(60, 20)
      Me._txtRedMin.TabIndex = 20
      Me._txtRedMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
      ' 
      ' _txtGreenMin
      ' 
      Me._txtGreenMin.Location = New System.Drawing.Point(196, 598)
      Me._txtGreenMin.Name = "_txtGreenMin"
      Me._txtGreenMin.[ReadOnly] = True
      Me._txtGreenMin.Size = New System.Drawing.Size(60, 20)
      Me._txtGreenMin.TabIndex = 26
      Me._txtGreenMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
      ' 
      ' _txtGreenMax
      ' 
      Me._txtGreenMax.Location = New System.Drawing.Point(196, 564)
      Me._txtGreenMax.Name = "_txtGreenMax"
      Me._txtGreenMax.[ReadOnly] = True
      Me._txtGreenMax.Size = New System.Drawing.Size(60, 20)
      Me._txtGreenMax.TabIndex = 25
      Me._txtGreenMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
      ' 
      ' _txtGreen
      ' 
      Me._txtGreen.Location = New System.Drawing.Point(196, 532)
      Me._txtGreen.Name = "_txtGreen"
      Me._txtGreen.[ReadOnly] = True
      Me._txtGreen.Size = New System.Drawing.Size(60, 20)
      Me._txtGreen.TabIndex = 24
      Me._txtGreen.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
      ' 
      ' _lblGreenMin
      ' 
      Me._lblGreenMin.AutoSize = True
      Me._lblGreenMin.Location = New System.Drawing.Point(160, 601)
      Me._lblGreenMin.Name = "_lblGreenMin"
      Me._lblGreenMin.Size = New System.Drawing.Size(27, 13)
      Me._lblGreenMin.TabIndex = 23
      Me._lblGreenMin.Text = "Min:"
      ' 
      ' _lblGreenMax
      ' 
      Me._lblGreenMax.AutoSize = True
      Me._lblGreenMax.Location = New System.Drawing.Point(160, 567)
      Me._lblGreenMax.Name = "_lblGreenMax"
      Me._lblGreenMax.Size = New System.Drawing.Size(30, 13)
      Me._lblGreenMax.TabIndex = 22
      Me._lblGreenMax.Text = "Max:"
      ' 
      ' _lblGreen
      ' 
      Me._lblGreen.AutoSize = True
      Me._lblGreen.Location = New System.Drawing.Point(160, 535)
      Me._lblGreen.Name = "_lblGreen"
      Me._lblGreen.Size = New System.Drawing.Size(39, 13)
      Me._lblGreen.TabIndex = 21
      Me._lblGreen.Text = "Green:"
      ' 
      ' _txtBlueMin
      ' 
      Me._txtBlueMin.Location = New System.Drawing.Point(324, 598)
      Me._txtBlueMin.Name = "_txtBlueMin"
      Me._txtBlueMin.[ReadOnly] = True
      Me._txtBlueMin.Size = New System.Drawing.Size(60, 20)
      Me._txtBlueMin.TabIndex = 32
      Me._txtBlueMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
      ' 
      ' _txtBlueMax
      ' 
      Me._txtBlueMax.Location = New System.Drawing.Point(324, 564)
      Me._txtBlueMax.Name = "_txtBlueMax"
      Me._txtBlueMax.[ReadOnly] = True
      Me._txtBlueMax.Size = New System.Drawing.Size(60, 20)
      Me._txtBlueMax.TabIndex = 31
      Me._txtBlueMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
      ' 
      ' _txtBlue
      ' 
      Me._txtBlue.Location = New System.Drawing.Point(324, 532)
      Me._txtBlue.Name = "_txtBlue"
      Me._txtBlue.[ReadOnly] = True
      Me._txtBlue.Size = New System.Drawing.Size(60, 20)
      Me._txtBlue.TabIndex = 30
      Me._txtBlue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
      ' 
      ' _lblBlueMin
      ' 
      Me._lblBlueMin.AutoSize = True
      Me._lblBlueMin.Location = New System.Drawing.Point(288, 601)
      Me._lblBlueMin.Name = "_lblBlueMin"
      Me._lblBlueMin.Size = New System.Drawing.Size(27, 13)
      Me._lblBlueMin.TabIndex = 29
      Me._lblBlueMin.Text = "Min:"
      ' 
      ' _lblBlueMax
      ' 
      Me._lblBlueMax.AutoSize = True
      Me._lblBlueMax.Location = New System.Drawing.Point(288, 567)
      Me._lblBlueMax.Name = "_lblBlueMax"
      Me._lblBlueMax.Size = New System.Drawing.Size(30, 13)
      Me._lblBlueMax.TabIndex = 28
      Me._lblBlueMax.Text = "Max:"
      ' 
      ' _lblBlue
      ' 
      Me._lblBlue.AutoSize = True
      Me._lblBlue.Location = New System.Drawing.Point(288, 535)
      Me._lblBlue.Name = "_lblBlue"
      Me._lblBlue.Size = New System.Drawing.Size(31, 13)
      Me._lblBlue.TabIndex = 27
      Me._lblBlue.Text = "Blue:"
      ' 
      ' _btnOK
      ' 
      Me._btnOK.Location = New System.Drawing.Point(175, 667)
      Me._btnOK.Name = "_btnOK"
      Me._btnOK.Size = New System.Drawing.Size(66, 32)
      Me._btnOK.TabIndex = 33
      Me._btnOK.Text = "OK"
      Me._btnOK.UseVisualStyleBackColor = True
      ' 
      ' _tbTabs
      ' 
      Me._tbTabs.LargeChange = 1
      Me._tbTabs.Location = New System.Drawing.Point(29, 453)
      Me._tbTabs.Maximum = 6
      Me._tbTabs.Name = "_tbTabs"
      Me._tbTabs.Size = New System.Drawing.Size(355, 45)
      Me._tbTabs.TabIndex = 34
      ' 
      ' _numXStart
      ' 
      Me._numXStart.Location = New System.Drawing.Point(127, 70)
      Me._numXStart.Name = "_numXStart"
      Me._numXStart.Size = New System.Drawing.Size(50, 20)
      Me._numXStart.TabIndex = 35
      ' 
      ' _numXEnd
      ' 
      Me._numXEnd.Location = New System.Drawing.Point(127, 104)
      Me._numXEnd.Name = "_numXEnd"
      Me._numXEnd.Size = New System.Drawing.Size(50, 20)
      Me._numXEnd.TabIndex = 36
      ' 
      ' _numYStart
      ' 
      Me._numYStart.Location = New System.Drawing.Point(291, 70)
      Me._numYStart.Name = "_numYStart"
      Me._numYStart.Size = New System.Drawing.Size(50, 20)
      Me._numYStart.TabIndex = 37
      ' 
      ' _numYEnd
      ' 
      Me._numYEnd.Location = New System.Drawing.Point(291, 104)
      Me._numYEnd.Name = "_numYEnd"
      Me._numYEnd.Size = New System.Drawing.Size(50, 20)
      Me._numYEnd.TabIndex = 38
      ' 
      ' _gbCursorPosition
      ' 
      Me._gbCursorPosition.Controls.Add(Me._yCursorPosition)
      Me._gbCursorPosition.Controls.Add(Me.label2)
      Me._gbCursorPosition.Controls.Add(Me._xCursorPosition)
      Me._gbCursorPosition.Controls.Add(Me.label1)
      Me._gbCursorPosition.Location = New System.Drawing.Point(106, 9)
      Me._gbCursorPosition.Name = "_gbCursorPosition"
      Me._gbCursorPosition.Size = New System.Drawing.Size(205, 51)
      Me._gbCursorPosition.TabIndex = 39
      Me._gbCursorPosition.TabStop = False
      Me._gbCursorPosition.Text = "Cursor Position"
      ' 
      ' _yCursorPosition
      ' 
      Me._yCursorPosition.Location = New System.Drawing.Point(141, 23)
      Me._yCursorPosition.Name = "_yCursorPosition"
      Me._yCursorPosition.[ReadOnly] = True
      Me._yCursorPosition.Size = New System.Drawing.Size(48, 20)
      Me._yCursorPosition.TabIndex = 3
      Me._yCursorPosition.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
      ' 
      ' label2
      ' 
      Me.label2.AutoSize = True
      Me.label2.Location = New System.Drawing.Point(112, 25)
      Me.label2.Name = "label2"
      Me.label2.Size = New System.Drawing.Size(23, 13)
      Me.label2.TabIndex = 2
      Me.label2.Text = "Y : "
      ' 
      ' _xCursorPosition
      ' 
      Me._xCursorPosition.Location = New System.Drawing.Point(48, 23)
      Me._xCursorPosition.Name = "_xCursorPosition"
      Me._xCursorPosition.[ReadOnly] = True
      Me._xCursorPosition.Size = New System.Drawing.Size(50, 20)
      Me._xCursorPosition.TabIndex = 1
      Me._xCursorPosition.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
      ' 
      ' label1
      ' 
      Me.label1.AutoSize = True
      Me.label1.Location = New System.Drawing.Point(20, 25)
      Me.label1.Name = "label1"
      Me.label1.Size = New System.Drawing.Size(23, 13)
      Me.label1.TabIndex = 0
      Me.label1.Text = "X : "
      ' 
      ' _cbFillCurve
      ' 
      Me._cbFillCurve.AutoSize = True
      Me._cbFillCurve.Location = New System.Drawing.Point(95, 645)
      Me._cbFillCurve.Name = "_cbFillCurve"
      Me._cbFillCurve.Size = New System.Drawing.Size(69, 17)
      Me._cbFillCurve.TabIndex = 40
      Me._cbFillCurve.Text = "Fill Curve"
      Me._cbFillCurve.UseVisualStyleBackColor = True
      ' 
      ' _cbMovable
      ' 
      Me._cbMovable.AutoSize = True
      Me._cbMovable.Location = New System.Drawing.Point(265, 645)
      Me._cbMovable.Name = "_cbMovable"
      Me._cbMovable.Size = New System.Drawing.Size(67, 17)
      Me._cbMovable.TabIndex = 41
      Me._cbMovable.Text = "Movable"
      Me._cbMovable.UseVisualStyleBackColor = True
      ' 
      ' LineHistogramDialog
      ' 
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(417, 707)
      Me.Controls.Add(Me._cbMovable)
      Me.Controls.Add(Me._cbFillCurve)
      Me.Controls.Add(Me._gbCursorPosition)
      Me.Controls.Add(Me._numYEnd)
      Me.Controls.Add(Me._numYStart)
      Me.Controls.Add(Me._numXEnd)
      Me.Controls.Add(Me._numXStart)
      Me.Controls.Add(Me._tbTabs)
      Me.Controls.Add(Me._btnOK)
      Me.Controls.Add(Me._txtBlueMin)
      Me.Controls.Add(Me._txtBlueMax)
      Me.Controls.Add(Me._txtBlue)
      Me.Controls.Add(Me._lblBlueMin)
      Me.Controls.Add(Me._lblBlueMax)
      Me.Controls.Add(Me._lblBlue)
      Me.Controls.Add(Me._txtGreenMin)
      Me.Controls.Add(Me._txtGreenMax)
      Me.Controls.Add(Me._txtGreen)
      Me.Controls.Add(Me._lblGreenMin)
      Me.Controls.Add(Me._lblGreenMax)
      Me.Controls.Add(Me._lblGreen)
      Me.Controls.Add(Me._txtRedMin)
      Me.Controls.Add(Me._txtRedMax)
      Me.Controls.Add(Me._txtRed)
      Me.Controls.Add(Me._lblRedMin)
      Me.Controls.Add(Me._lblRedMax)
      Me.Controls.Add(Me._lblRed)
      Me.Controls.Add(Me._txtYPixel)
      Me.Controls.Add(Me._txtXPixel)
      Me.Controls.Add(Me._lblYPixel)
      Me.Controls.Add(Me._lblXPixel)
      Me.Controls.Add(Me._tabs)
      Me.Controls.Add(Me._txtPixelNumber)
      Me.Controls.Add(Me._lblYEnd)
      Me.Controls.Add(Me._lblYStart)
      Me.Controls.Add(Me._lblPixelNumber)
      Me.Controls.Add(Me._lblXEnd)
      Me.Controls.Add(Me._lblXStart)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "LineHistogramDialog"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
      Me.Text = "Line Histogram"
      Me._tabs.ResumeLayout(False)
      CType(Me._tbTabs, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me._numXStart, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me._numXEnd, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me._numYStart, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me._numYEnd, System.ComponentModel.ISupportInitialize).EndInit()
      Me._gbCursorPosition.ResumeLayout(False)
      Me._gbCursorPosition.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub

#End Region

   Private _lblXStart As System.Windows.Forms.Label
   Private _lblXEnd As System.Windows.Forms.Label
   Private _lblPixelNumber As System.Windows.Forms.Label
   Private _lblYStart As System.Windows.Forms.Label
   Private _lblYEnd As System.Windows.Forms.Label
   Private _txtPixelNumber As System.Windows.Forms.TextBox
   Private _tabs As System.Windows.Forms.TabControl
   Private WithEvents _tabAll As System.Windows.Forms.TabPage
   Private WithEvents _tabRed As System.Windows.Forms.TabPage
   Private _lblXPixel As System.Windows.Forms.Label
   Private _lblYPixel As System.Windows.Forms.Label
   Private _txtXPixel As System.Windows.Forms.TextBox
   Private _txtYPixel As System.Windows.Forms.TextBox
   Private _lblRed As System.Windows.Forms.Label
   Private _lblRedMax As System.Windows.Forms.Label
   Private _lblRedMin As System.Windows.Forms.Label
   Private _txtRed As System.Windows.Forms.TextBox
   Private _txtRedMax As System.Windows.Forms.TextBox
   Private _txtRedMin As System.Windows.Forms.TextBox
   Private _txtGreenMin As System.Windows.Forms.TextBox
   Private _txtGreenMax As System.Windows.Forms.TextBox
   Private _txtGreen As System.Windows.Forms.TextBox
   Private _lblGreenMin As System.Windows.Forms.Label
   Private _lblGreenMax As System.Windows.Forms.Label
   Private _lblGreen As System.Windows.Forms.Label
   Private _txtBlueMin As System.Windows.Forms.TextBox
   Private _txtBlueMax As System.Windows.Forms.TextBox
   Private _txtBlue As System.Windows.Forms.TextBox
   Private _lblBlueMin As System.Windows.Forms.Label
   Private _lblBlueMax As System.Windows.Forms.Label
   Private _lblBlue As System.Windows.Forms.Label
   Private WithEvents _btnOK As System.Windows.Forms.Button
   Private WithEvents _tabGreen As System.Windows.Forms.TabPage
   Private WithEvents _tabBlue As System.Windows.Forms.TabPage
   Private WithEvents _tbTabs As System.Windows.Forms.TrackBar
   Private WithEvents _numXStart As System.Windows.Forms.NumericUpDown
   Private WithEvents _numXEnd As System.Windows.Forms.NumericUpDown
   Private WithEvents _numYStart As System.Windows.Forms.NumericUpDown
   Private WithEvents _numYEnd As System.Windows.Forms.NumericUpDown
   Private _gbCursorPosition As System.Windows.Forms.GroupBox
   Private _yCursorPosition As System.Windows.Forms.TextBox
   Private label2 As System.Windows.Forms.Label
   Private _xCursorPosition As System.Windows.Forms.TextBox
   Private label1 As System.Windows.Forms.Label
   Private WithEvents _cbFillCurve As System.Windows.Forms.CheckBox
   Private WithEvents _cbMovable As System.Windows.Forms.CheckBox
End Class