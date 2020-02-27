Imports Leadtools.Codecs

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InteractiveHistDialog
   Inherits System.Windows.Forms.Form

   'Form overrides dispose to clean up the component list.
   <System.Diagnostics.DebuggerNonUserCode()> _
   Protected Overrides Sub Dispose(ByVal disposing As Boolean)
      If disposing AndAlso components IsNot Nothing Then
         components.Dispose()
      End If
      MyBase.Dispose(disposing)
   End Sub

   'Required by the Windows Form Designer
   Private components As System.ComponentModel.IContainer

   'NOTE: The following procedure is required by the Windows Form Designer
   'It can be modified using the Windows Form Designer.  
   'Do not modify it using the code editor.
   <System.Diagnostics.DebuggerStepThrough()> _
   Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container
      Me._rbResShiftLeft = New System.Windows.Forms.RadioButton
      Me._rbResShiftRight = New System.Windows.Forms.RadioButton
      Me._nudResNewEnd = New System.Windows.Forms.NumericUpDown
      Me._lblResNewEnd = New System.Windows.Forms.Label
      Me._nudResNewStart = New System.Windows.Forms.NumericUpDown
      Me._lblResStartPtOccVal = New System.Windows.Forms.Label
      Me._lblResStartPtOcc = New System.Windows.Forms.Label
      Me._lblResStartPtClr = New System.Windows.Forms.Label
      Me._lblResEndPt = New System.Windows.Forms.Label
      Me._lblResNewStart = New System.Windows.Forms.Label
      Me._nudResShiftAmount = New System.Windows.Forms.NumericUpDown
      Me._lblResShiftAmount = New System.Windows.Forms.Label
      Me._nudResStartPt = New System.Windows.Forms.NumericUpDown
      Me._grpRescalingInfor = New System.Windows.Forms.GroupBox
      Me._rbResNewSE = New System.Windows.Forms.RadioButton
      Me._rbResShift = New System.Windows.Forms.RadioButton
      Me._lblResStartPt = New System.Windows.Forms.Label
      Me._btnResApplyBitmap = New System.Windows.Forms.Button
      Me._btnNoiseApplyBitmap = New System.Windows.Forms.Button
      Me._grpNoiseFilterInfo = New System.Windows.Forms.GroupBox
      Me._lblNoiseReplaceColor = New System.Windows.Forms.Label
      Me._btnNoiseReplaceColor = New System.Windows.Forms.Button
      Me._cbNoiseReplaceWith = New System.Windows.Forms.ComboBox
      Me._lblNoiseReplaceWith = New System.Windows.Forms.Label
      Me._lblResEndPtOccVal = New System.Windows.Forms.Label
      Me._lblResEndPtOcc = New System.Windows.Forms.Label
      Me._lblResEndPtClr = New System.Windows.Forms.Label
      Me._lblNoiseStartPtOcc = New System.Windows.Forms.Label
      Me._lblNoiseStartPtClr = New System.Windows.Forms.Label
      Me._nudNoiseStartPt = New System.Windows.Forms.NumericUpDown
      Me._lblNoiseStartPt = New System.Windows.Forms.Label
      Me._btnResApplyLUT = New System.Windows.Forms.Button
      Me._grpResSelInfo = New System.Windows.Forms.GroupBox
      Me._nudResEndPt = New System.Windows.Forms.NumericUpDown
      Me._tpgRescaling = New System.Windows.Forms.TabPage
      Me._chkResApplyInProgress = New System.Windows.Forms.CheckBox
      Me._lblOuter = New System.Windows.Forms.Label
      Me._btnOuter = New System.Windows.Forms.Button
      Me._grpSelectionColor = New System.Windows.Forms.GroupBox
      Me._lblInner = New System.Windows.Forms.Label
      Me._btnInner = New System.Windows.Forms.Button
      Me._btnShowHideOptions = New System.Windows.Forms.Button
      Me._btnCancel = New System.Windows.Forms.Button
      Me._btnUndo = New System.Windows.Forms.Button
      Me._btnOk = New System.Windows.Forms.Button
      Me._MainProgressBar = New System.Windows.Forms.ProgressBar
      Me._tabOptions = New System.Windows.Forms.TabControl
      Me._tpgSegmentation = New System.Windows.Forms.TabPage
      Me._chkSegApplyInProgress = New System.Windows.Forms.CheckBox
      Me._btnSegApplyLUT = New System.Windows.Forms.Button
      Me._grpSegmentationInfo = New System.Windows.Forms.GroupBox
      Me._rbSegThreshold = New System.Windows.Forms.RadioButton
      Me._rbSegGradient = New System.Windows.Forms.RadioButton
      Me._lblSegEndColor = New System.Windows.Forms.Label
      Me._btnSegEndColor = New System.Windows.Forms.Button
      Me._lblSegStartColor = New System.Windows.Forms.Label
      Me._btnSegStartColor = New System.Windows.Forms.Button
      Me._btnSegApply = New System.Windows.Forms.Button
      Me._grpSegSelInfo = New System.Windows.Forms.GroupBox
      Me._lblSegEndPtOccVal = New System.Windows.Forms.Label
      Me._lblSegEndPtOcc = New System.Windows.Forms.Label
      Me._lblSegEndPtClr = New System.Windows.Forms.Label
      Me._nudSegEndPt = New System.Windows.Forms.NumericUpDown
      Me._lblSegEndPt = New System.Windows.Forms.Label
      Me._lblSegStartPtOccVal = New System.Windows.Forms.Label
      Me._lblSegStartPtOcc = New System.Windows.Forms.Label
      Me._lblSegStartPtClr = New System.Windows.Forms.Label
      Me._nudSegStartPt = New System.Windows.Forms.NumericUpDown
      Me._lblSegStartPt = New System.Windows.Forms.Label
      Me._tpgGrayDistribution = New System.Windows.Forms.TabPage
      Me._chkGrayApplyInProgress = New System.Windows.Forms.CheckBox
      Me._btnGrayApplyLUT = New System.Windows.Forms.Button
      Me._grpGrySelInfo = New System.Windows.Forms.GroupBox
      Me._lblGryEndPtOccVal = New System.Windows.Forms.Label
      Me._lblGryEndPtOcc = New System.Windows.Forms.Label
      Me._lblGrayEndPtClr = New System.Windows.Forms.Label
      Me._nudGrayEndPt = New System.Windows.Forms.NumericUpDown
      Me._lblGryEndPt = New System.Windows.Forms.Label
      Me._lblGryStartPtOccVal = New System.Windows.Forms.Label
      Me._lblGryStartPtOcc = New System.Windows.Forms.Label
      Me._lblGrayStartPtClr = New System.Windows.Forms.Label
      Me._nudGrayStartPt = New System.Windows.Forms.NumericUpDown
      Me._lblGryStartPt = New System.Windows.Forms.Label
      Me._btnGrayApplyToBitmap = New System.Windows.Forms.Button
      Me._grpGrayDistributionInfo = New System.Windows.Forms.GroupBox
      Me._cbGraySelectionOnly = New System.Windows.Forms.CheckBox
      Me._lblGrayEndColor = New System.Windows.Forms.Label
      Me._btnGrayEndColor = New System.Windows.Forms.Button
      Me._lblGrayStartColor = New System.Windows.Forms.Label
      Me._btnGrayStartColor = New System.Windows.Forms.Button
      Me._txtGrayWidth = New System.Windows.Forms.TextBox
      Me._lblGrayWidth = New System.Windows.Forms.Label
      Me._txtGrayCenter = New System.Windows.Forms.TextBox
      Me._lblGrayCenter = New System.Windows.Forms.Label
      Me._nudGrayFactor = New System.Windows.Forms.NumericUpDown
      Me._cbGrayFunctionType = New System.Windows.Forms.ComboBox
      Me._lblGrayFactor = New System.Windows.Forms.Label
      Me._lblGrayFunctionType = New System.Windows.Forms.Label
      Me._tpgNoiseFilter = New System.Windows.Forms.TabPage
      Me._chkNoiseApplyInProgress = New System.Windows.Forms.CheckBox
      Me._btnNoiseApplyLUT = New System.Windows.Forms.Button
      Me._grpNoiseSelInfo = New System.Windows.Forms.GroupBox
      Me._lblNoiseEndPtOccVal = New System.Windows.Forms.Label
      Me._lblNoiseEndPtOcc = New System.Windows.Forms.Label
      Me._lblNoiseEndPtClr = New System.Windows.Forms.Label
      Me._nudNoiseEndPt = New System.Windows.Forms.NumericUpDown
      Me._lblNoiseEndPt = New System.Windows.Forms.Label
      Me._lblNoiseStartPtOccVal = New System.Windows.Forms.Label
      Me._cbChannel = New System.Windows.Forms.ComboBox
      Me._lblChannel = New System.Windows.Forms.Label
      Me._cmRightClickOptions = New System.Windows.Forms.ContextMenuStrip(Me.components)
      Me._cmiZoomToSelection = New System.Windows.Forms.ToolStripMenuItem
      Me._cmiFitGraph = New System.Windows.Forms.ToolStripMenuItem
      Me._cmiFullRangeView = New System.Windows.Forms.ToolStripMenuItem
      Me._lblHistogram = New System.Windows.Forms.Label
      Me._lblSelectionType = New System.Windows.Forms.Label
      Me._cbSelectionType = New System.Windows.Forms.ComboBox
      Me._grpView = New System.Windows.Forms.GroupBox
      Me._lblHelp = New System.Windows.Forms.Label
      Me._grpStatisticalInformation = New System.Windows.Forms.GroupBox
      Me._grpMouse = New System.Windows.Forms.GroupBox
      Me.label1 = New System.Windows.Forms.Label
      Me._lblMouseLevel = New System.Windows.Forms.Label
      Me.label2 = New System.Windows.Forms.Label
      Me._lblMousePercent = New System.Windows.Forms.Label
      Me.label3 = New System.Windows.Forms.Label
      Me._lblMouseCount = New System.Windows.Forms.Label
      Me._lblStdDev = New System.Windows.Forms.Label
      Me._lblSelStdDev = New System.Windows.Forms.Label
      Me._lblMedian = New System.Windows.Forms.Label
      Me._lblSelMedian = New System.Windows.Forms.Label
      Me._lblMean = New System.Windows.Forms.Label
      Me._lblSelMean = New System.Windows.Forms.Label
      Me._lblLevel = New System.Windows.Forms.Label
      Me._lblSelLevel = New System.Windows.Forms.Label
      Me._lblPercent = New System.Windows.Forms.Label
      Me._lblSelPercent = New System.Windows.Forms.Label
      Me._lblCount = New System.Windows.Forms.Label
      Me._lblSelCount = New System.Windows.Forms.Label
      CType(Me._nudResNewEnd, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me._nudResNewStart, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me._nudResShiftAmount, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me._nudResStartPt, System.ComponentModel.ISupportInitialize).BeginInit()
      Me._grpRescalingInfor.SuspendLayout()
      Me._grpNoiseFilterInfo.SuspendLayout()
      CType(Me._nudNoiseStartPt, System.ComponentModel.ISupportInitialize).BeginInit()
      Me._grpResSelInfo.SuspendLayout()
      CType(Me._nudResEndPt, System.ComponentModel.ISupportInitialize).BeginInit()
      Me._tpgRescaling.SuspendLayout()
      Me._grpSelectionColor.SuspendLayout()
      Me._tabOptions.SuspendLayout()
      Me._tpgSegmentation.SuspendLayout()
      Me._grpSegmentationInfo.SuspendLayout()
      Me._grpSegSelInfo.SuspendLayout()
      CType(Me._nudSegEndPt, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me._nudSegStartPt, System.ComponentModel.ISupportInitialize).BeginInit()
      Me._tpgGrayDistribution.SuspendLayout()
      Me._grpGrySelInfo.SuspendLayout()
      CType(Me._nudGrayEndPt, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me._nudGrayStartPt, System.ComponentModel.ISupportInitialize).BeginInit()
      Me._grpGrayDistributionInfo.SuspendLayout()
      CType(Me._nudGrayFactor, System.ComponentModel.ISupportInitialize).BeginInit()
      Me._tpgNoiseFilter.SuspendLayout()
      Me._grpNoiseSelInfo.SuspendLayout()
      CType(Me._nudNoiseEndPt, System.ComponentModel.ISupportInitialize).BeginInit()
      Me._cmRightClickOptions.SuspendLayout()
      Me._grpView.SuspendLayout()
      Me._grpStatisticalInformation.SuspendLayout()
      Me._grpMouse.SuspendLayout()
      Me.SuspendLayout()
      '
      '_rbResShiftLeft
      '
      Me._rbResShiftLeft.AutoCheck = False
      Me._rbResShiftLeft.AutoSize = True
      Me._rbResShiftLeft.Location = New System.Drawing.Point(135, 34)
      Me._rbResShiftLeft.Name = "_rbResShiftLeft"
      Me._rbResShiftLeft.Size = New System.Drawing.Size(67, 17)
      Me._rbResShiftLeft.TabIndex = 38
      Me._rbResShiftLeft.TabStop = True
      Me._rbResShiftLeft.Text = "Shift Left"
      Me._rbResShiftLeft.UseVisualStyleBackColor = True
      '
      '_rbResShiftRight
      '
      Me._rbResShiftRight.AutoCheck = False
      Me._rbResShiftRight.AutoSize = True
      Me._rbResShiftRight.Location = New System.Drawing.Point(135, 13)
      Me._rbResShiftRight.Name = "_rbResShiftRight"
      Me._rbResShiftRight.Size = New System.Drawing.Size(74, 17)
      Me._rbResShiftRight.TabIndex = 37
      Me._rbResShiftRight.TabStop = True
      Me._rbResShiftRight.Text = "Shift Right"
      Me._rbResShiftRight.UseVisualStyleBackColor = True
      '
      '_nudResNewEnd
      '
      Me._nudResNewEnd.Location = New System.Drawing.Point(59, 99)
      Me._nudResNewEnd.Name = "_nudResNewEnd"
      Me._nudResNewEnd.Size = New System.Drawing.Size(58, 20)
      Me._nudResNewEnd.TabIndex = 34
      '
      '_lblResNewEnd
      '
      Me._lblResNewEnd.AutoSize = True
      Me._lblResNewEnd.Location = New System.Drawing.Point(5, 102)
      Me._lblResNewEnd.Name = "_lblResNewEnd"
      Me._lblResNewEnd.Size = New System.Drawing.Size(51, 13)
      Me._lblResNewEnd.TabIndex = 33
      Me._lblResNewEnd.Text = "New End"
      '
      '_nudResNewStart
      '
      Me._nudResNewStart.Location = New System.Drawing.Point(59, 76)
      Me._nudResNewStart.Name = "_nudResNewStart"
      Me._nudResNewStart.Size = New System.Drawing.Size(58, 20)
      Me._nudResNewStart.TabIndex = 32
      '
      '_lblResStartPtOccVal
      '
      Me._lblResStartPtOccVal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
      Me._lblResStartPtOccVal.Location = New System.Drawing.Point(97, 30)
      Me._lblResStartPtOccVal.Name = "_lblResStartPtOccVal"
      Me._lblResStartPtOccVal.Size = New System.Drawing.Size(57, 20)
      Me._lblResStartPtOccVal.TabIndex = 24
      '
      '_lblResStartPtOcc
      '
      Me._lblResStartPtOcc.AutoSize = True
      Me._lblResStartPtOcc.Location = New System.Drawing.Point(95, 15)
      Me._lblResStartPtOcc.Name = "_lblResStartPtOcc"
      Me._lblResStartPtOcc.Size = New System.Drawing.Size(63, 13)
      Me._lblResStartPtOcc.TabIndex = 23
      Me._lblResStartPtOcc.Text = "Occurrence"
      '
      '_lblResStartPtClr
      '
      Me._lblResStartPtClr.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
      Me._lblResStartPtClr.Location = New System.Drawing.Point(71, 31)
      Me._lblResStartPtClr.Name = "_lblResStartPtClr"
      Me._lblResStartPtClr.Size = New System.Drawing.Size(21, 20)
      Me._lblResStartPtClr.TabIndex = 22
      '
      '_lblResEndPt
      '
      Me._lblResEndPt.AutoSize = True
      Me._lblResEndPt.Location = New System.Drawing.Point(12, 57)
      Me._lblResEndPt.Name = "_lblResEndPt"
      Me._lblResEndPt.Size = New System.Drawing.Size(53, 13)
      Me._lblResEndPt.TabIndex = 25
      Me._lblResEndPt.Text = "&End Point"
      '
      '_lblResNewStart
      '
      Me._lblResNewStart.AutoSize = True
      Me._lblResNewStart.Location = New System.Drawing.Point(5, 79)
      Me._lblResNewStart.Name = "_lblResNewStart"
      Me._lblResNewStart.Size = New System.Drawing.Size(54, 13)
      Me._lblResNewStart.TabIndex = 31
      Me._lblResNewStart.Text = "New Start"
      '
      '_nudResShiftAmount
      '
      Me._nudResShiftAmount.Location = New System.Drawing.Point(71, 30)
      Me._nudResShiftAmount.Name = "_nudResShiftAmount"
      Me._nudResShiftAmount.Size = New System.Drawing.Size(58, 20)
      Me._nudResShiftAmount.TabIndex = 30
      '
      '_lblResShiftAmount
      '
      Me._lblResShiftAmount.AutoSize = True
      Me._lblResShiftAmount.Location = New System.Drawing.Point(3, 33)
      Me._lblResShiftAmount.Name = "_lblResShiftAmount"
      Me._lblResShiftAmount.Size = New System.Drawing.Size(67, 13)
      Me._lblResShiftAmount.TabIndex = 2
      Me._lblResShiftAmount.Text = "Shift Amount"
      '
      '_nudResStartPt
      '
      Me._nudResStartPt.Location = New System.Drawing.Point(7, 30)
      Me._nudResStartPt.Name = "_nudResStartPt"
      Me._nudResStartPt.Size = New System.Drawing.Size(58, 20)
      Me._nudResStartPt.TabIndex = 1
      '
      '_grpRescalingInfor
      '
      Me._grpRescalingInfor.Controls.Add(Me._rbResShiftLeft)
      Me._grpRescalingInfor.Controls.Add(Me._rbResShiftRight)
      Me._grpRescalingInfor.Controls.Add(Me._nudResNewEnd)
      Me._grpRescalingInfor.Controls.Add(Me._lblResNewEnd)
      Me._grpRescalingInfor.Controls.Add(Me._nudResNewStart)
      Me._grpRescalingInfor.Controls.Add(Me._lblResNewStart)
      Me._grpRescalingInfor.Controls.Add(Me._nudResShiftAmount)
      Me._grpRescalingInfor.Controls.Add(Me._lblResShiftAmount)
      Me._grpRescalingInfor.Controls.Add(Me._rbResNewSE)
      Me._grpRescalingInfor.Controls.Add(Me._rbResShift)
      Me._grpRescalingInfor.Location = New System.Drawing.Point(168, 0)
      Me._grpRescalingInfor.Name = "_grpRescalingInfor"
      Me._grpRescalingInfor.Size = New System.Drawing.Size(212, 124)
      Me._grpRescalingInfor.TabIndex = 2
      Me._grpRescalingInfor.TabStop = False
      Me._grpRescalingInfor.Text = "Rescaling Information"
      '
      '_rbResNewSE
      '
      Me._rbResNewSE.AutoCheck = False
      Me._rbResNewSE.AutoSize = True
      Me._rbResNewSE.Location = New System.Drawing.Point(6, 55)
      Me._rbResNewSE.Name = "_rbResNewSE"
      Me._rbResNewSE.Size = New System.Drawing.Size(96, 17)
      Me._rbResNewSE.TabIndex = 1
      Me._rbResNewSE.TabStop = True
      Me._rbResNewSE.Text = "New Start/End"
      Me._rbResNewSE.UseVisualStyleBackColor = True
      '
      '_rbResShift
      '
      Me._rbResShift.AutoCheck = False
      Me._rbResShift.AutoSize = True
      Me._rbResShift.Location = New System.Drawing.Point(7, 14)
      Me._rbResShift.Name = "_rbResShift"
      Me._rbResShift.Size = New System.Drawing.Size(46, 17)
      Me._rbResShift.TabIndex = 0
      Me._rbResShift.TabStop = True
      Me._rbResShift.Text = "Shift"
      Me._rbResShift.UseVisualStyleBackColor = True
      '
      '_lblResStartPt
      '
      Me._lblResStartPt.AutoSize = True
      Me._lblResStartPt.Location = New System.Drawing.Point(11, 15)
      Me._lblResStartPt.Name = "_lblResStartPt"
      Me._lblResStartPt.Size = New System.Drawing.Size(56, 13)
      Me._lblResStartPt.TabIndex = 0
      Me._lblResStartPt.Text = "&Start Point"
      '
      '_btnResApplyBitmap
      '
      Me._btnResApplyBitmap.Location = New System.Drawing.Point(85, 103)
      Me._btnResApplyBitmap.Name = "_btnResApplyBitmap"
      Me._btnResApplyBitmap.Size = New System.Drawing.Size(78, 23)
      Me._btnResApplyBitmap.TabIndex = 6
      Me._btnResApplyBitmap.Text = "Bitmap Data"
      Me._btnResApplyBitmap.UseVisualStyleBackColor = True
      '
      '_btnNoiseApplyBitmap
      '
      Me._btnNoiseApplyBitmap.Location = New System.Drawing.Point(85, 103)
      Me._btnNoiseApplyBitmap.Name = "_btnNoiseApplyBitmap"
      Me._btnNoiseApplyBitmap.Size = New System.Drawing.Size(78, 23)
      Me._btnNoiseApplyBitmap.TabIndex = 6
      Me._btnNoiseApplyBitmap.Text = "Bitmap Data"
      Me._btnNoiseApplyBitmap.UseVisualStyleBackColor = True
      '
      '_grpNoiseFilterInfo
      '
      Me._grpNoiseFilterInfo.Controls.Add(Me._lblNoiseReplaceColor)
      Me._grpNoiseFilterInfo.Controls.Add(Me._btnNoiseReplaceColor)
      Me._grpNoiseFilterInfo.Controls.Add(Me._cbNoiseReplaceWith)
      Me._grpNoiseFilterInfo.Controls.Add(Me._lblNoiseReplaceWith)
      Me._grpNoiseFilterInfo.Location = New System.Drawing.Point(168, 0)
      Me._grpNoiseFilterInfo.Name = "_grpNoiseFilterInfo"
      Me._grpNoiseFilterInfo.Size = New System.Drawing.Size(212, 101)
      Me._grpNoiseFilterInfo.TabIndex = 2
      Me._grpNoiseFilterInfo.TabStop = False
      Me._grpNoiseFilterInfo.Text = "Filter(Noise) Information"
      '
      '_lblNoiseReplaceColor
      '
      Me._lblNoiseReplaceColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me._lblNoiseReplaceColor.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._lblNoiseReplaceColor.Location = New System.Drawing.Point(103, 53)
      Me._lblNoiseReplaceColor.Name = "_lblNoiseReplaceColor"
      Me._lblNoiseReplaceColor.Size = New System.Drawing.Size(75, 23)
      Me._lblNoiseReplaceColor.TabIndex = 3
      '
      '_btnNoiseReplaceColor
      '
      Me._btnNoiseReplaceColor.Location = New System.Drawing.Point(7, 53)
      Me._btnNoiseReplaceColor.Name = "_btnNoiseReplaceColor"
      Me._btnNoiseReplaceColor.Size = New System.Drawing.Size(90, 23)
      Me._btnNoiseReplaceColor.TabIndex = 2
      Me._btnNoiseReplaceColor.Text = "&Replace Color"
      Me._btnNoiseReplaceColor.UseVisualStyleBackColor = True
      '
      '_cbNoiseReplaceWith
      '
      Me._cbNoiseReplaceWith.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me._cbNoiseReplaceWith.FormattingEnabled = True
      Me._cbNoiseReplaceWith.Items.AddRange(New Object() {"Start & End Points", "Min & Max Intesities", "Replacement Color", "Zero"})
      Me._cbNoiseReplaceWith.Location = New System.Drawing.Point(82, 16)
      Me._cbNoiseReplaceWith.Name = "_cbNoiseReplaceWith"
      Me._cbNoiseReplaceWith.Size = New System.Drawing.Size(121, 21)
      Me._cbNoiseReplaceWith.TabIndex = 1
      '
      '_lblNoiseReplaceWith
      '
      Me._lblNoiseReplaceWith.AutoSize = True
      Me._lblNoiseReplaceWith.Location = New System.Drawing.Point(7, 19)
      Me._lblNoiseReplaceWith.Name = "_lblNoiseReplaceWith"
      Me._lblNoiseReplaceWith.Size = New System.Drawing.Size(72, 13)
      Me._lblNoiseReplaceWith.TabIndex = 0
      Me._lblNoiseReplaceWith.Text = "Replace With"
      '
      '_lblResEndPtOccVal
      '
      Me._lblResEndPtOccVal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
      Me._lblResEndPtOccVal.Location = New System.Drawing.Point(97, 72)
      Me._lblResEndPtOccVal.Name = "_lblResEndPtOccVal"
      Me._lblResEndPtOccVal.Size = New System.Drawing.Size(57, 20)
      Me._lblResEndPtOccVal.TabIndex = 29
      '
      '_lblResEndPtOcc
      '
      Me._lblResEndPtOcc.AutoSize = True
      Me._lblResEndPtOcc.Location = New System.Drawing.Point(96, 57)
      Me._lblResEndPtOcc.Name = "_lblResEndPtOcc"
      Me._lblResEndPtOcc.Size = New System.Drawing.Size(63, 13)
      Me._lblResEndPtOcc.TabIndex = 28
      Me._lblResEndPtOcc.Text = "Occurrence"
      '
      '_lblResEndPtClr
      '
      Me._lblResEndPtClr.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
      Me._lblResEndPtClr.Location = New System.Drawing.Point(71, 73)
      Me._lblResEndPtClr.Name = "_lblResEndPtClr"
      Me._lblResEndPtClr.Size = New System.Drawing.Size(21, 20)
      Me._lblResEndPtClr.TabIndex = 27
      '
      '_lblNoiseStartPtOcc
      '
      Me._lblNoiseStartPtOcc.AutoSize = True
      Me._lblNoiseStartPtOcc.Location = New System.Drawing.Point(95, 15)
      Me._lblNoiseStartPtOcc.Name = "_lblNoiseStartPtOcc"
      Me._lblNoiseStartPtOcc.Size = New System.Drawing.Size(63, 13)
      Me._lblNoiseStartPtOcc.TabIndex = 23
      Me._lblNoiseStartPtOcc.Text = "Occurrence"
      '
      '_lblNoiseStartPtClr
      '
      Me._lblNoiseStartPtClr.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
      Me._lblNoiseStartPtClr.Location = New System.Drawing.Point(71, 31)
      Me._lblNoiseStartPtClr.Name = "_lblNoiseStartPtClr"
      Me._lblNoiseStartPtClr.Size = New System.Drawing.Size(21, 20)
      Me._lblNoiseStartPtClr.TabIndex = 22
      '
      '_nudNoiseStartPt
      '
      Me._nudNoiseStartPt.Location = New System.Drawing.Point(7, 30)
      Me._nudNoiseStartPt.Name = "_nudNoiseStartPt"
      Me._nudNoiseStartPt.Size = New System.Drawing.Size(58, 20)
      Me._nudNoiseStartPt.TabIndex = 1
      '
      '_lblNoiseStartPt
      '
      Me._lblNoiseStartPt.AutoSize = True
      Me._lblNoiseStartPt.Location = New System.Drawing.Point(11, 15)
      Me._lblNoiseStartPt.Name = "_lblNoiseStartPt"
      Me._lblNoiseStartPt.Size = New System.Drawing.Size(56, 13)
      Me._lblNoiseStartPt.TabIndex = 0
      Me._lblNoiseStartPt.Text = "&Start Point"
      '
      '_btnResApplyLUT
      '
      Me._btnResApplyLUT.Location = New System.Drawing.Point(6, 103)
      Me._btnResApplyLUT.Name = "_btnResApplyLUT"
      Me._btnResApplyLUT.Size = New System.Drawing.Size(73, 23)
      Me._btnResApplyLUT.TabIndex = 9
      Me._btnResApplyLUT.Text = "LUT"
      Me._btnResApplyLUT.UseVisualStyleBackColor = True
      '
      '_grpResSelInfo
      '
      Me._grpResSelInfo.Controls.Add(Me._lblResEndPtOccVal)
      Me._grpResSelInfo.Controls.Add(Me._lblResEndPtOcc)
      Me._grpResSelInfo.Controls.Add(Me._lblResEndPtClr)
      Me._grpResSelInfo.Controls.Add(Me._nudResEndPt)
      Me._grpResSelInfo.Controls.Add(Me._lblResEndPt)
      Me._grpResSelInfo.Controls.Add(Me._lblResStartPtOccVal)
      Me._grpResSelInfo.Controls.Add(Me._lblResStartPtOcc)
      Me._grpResSelInfo.Controls.Add(Me._lblResStartPtClr)
      Me._grpResSelInfo.Controls.Add(Me._nudResStartPt)
      Me._grpResSelInfo.Controls.Add(Me._lblResStartPt)
      Me._grpResSelInfo.Location = New System.Drawing.Point(0, 0)
      Me._grpResSelInfo.Name = "_grpResSelInfo"
      Me._grpResSelInfo.Size = New System.Drawing.Size(164, 101)
      Me._grpResSelInfo.TabIndex = 7
      Me._grpResSelInfo.TabStop = False
      Me._grpResSelInfo.Text = "Selection Information"
      '
      '_nudResEndPt
      '
      Me._nudResEndPt.Location = New System.Drawing.Point(7, 72)
      Me._nudResEndPt.Name = "_nudResEndPt"
      Me._nudResEndPt.Size = New System.Drawing.Size(58, 20)
      Me._nudResEndPt.TabIndex = 26
      '
      '_tpgRescaling
      '
      Me._tpgRescaling.Controls.Add(Me._chkResApplyInProgress)
      Me._tpgRescaling.Controls.Add(Me._btnResApplyLUT)
      Me._tpgRescaling.Controls.Add(Me._grpResSelInfo)
      Me._tpgRescaling.Controls.Add(Me._btnResApplyBitmap)
      Me._tpgRescaling.Controls.Add(Me._grpRescalingInfor)
      Me._tpgRescaling.Location = New System.Drawing.Point(4, 22)
      Me._tpgRescaling.Name = "_tpgRescaling"
      Me._tpgRescaling.Padding = New System.Windows.Forms.Padding(3)
      Me._tpgRescaling.Size = New System.Drawing.Size(401, 150)
      Me._tpgRescaling.TabIndex = 3
      Me._tpgRescaling.Text = "Rescaling"
      Me._tpgRescaling.UseVisualStyleBackColor = True
      '
      '_chkResApplyInProgress
      '
      Me._chkResApplyInProgress.AutoSize = True
      Me._chkResApplyInProgress.Location = New System.Drawing.Point(7, 129)
      Me._chkResApplyInProgress.Name = "_chkResApplyInProgress"
      Me._chkResApplyInProgress.Size = New System.Drawing.Size(94, 17)
      Me._chkResApplyInProgress.TabIndex = 12
      Me._chkResApplyInProgress.Text = "Show Preview"
      Me._chkResApplyInProgress.UseVisualStyleBackColor = True
      '
      '_lblOuter
      '
      Me._lblOuter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me._lblOuter.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._lblOuter.Location = New System.Drawing.Point(9, 95)
      Me._lblOuter.Name = "_lblOuter"
      Me._lblOuter.Size = New System.Drawing.Size(75, 23)
      Me._lblOuter.TabIndex = 3
      '
      '_btnOuter
      '
      Me._btnOuter.Location = New System.Drawing.Point(9, 69)
      Me._btnOuter.Name = "_btnOuter"
      Me._btnOuter.Size = New System.Drawing.Size(75, 23)
      Me._btnOuter.TabIndex = 2
      Me._btnOuter.Text = "&Outer"
      Me._btnOuter.UseVisualStyleBackColor = True
      '
      '_grpSelectionColor
      '
      Me._grpSelectionColor.Controls.Add(Me._lblOuter)
      Me._grpSelectionColor.Controls.Add(Me._btnOuter)
      Me._grpSelectionColor.Controls.Add(Me._lblInner)
      Me._grpSelectionColor.Controls.Add(Me._btnInner)
      Me._grpSelectionColor.Location = New System.Drawing.Point(323, 50)
      Me._grpSelectionColor.Name = "_grpSelectionColor"
      Me._grpSelectionColor.Size = New System.Drawing.Size(94, 124)
      Me._grpSelectionColor.TabIndex = 3
      Me._grpSelectionColor.TabStop = False
      Me._grpSelectionColor.Text = "Selection Color"
      '
      '_lblInner
      '
      Me._lblInner.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me._lblInner.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._lblInner.Location = New System.Drawing.Point(9, 41)
      Me._lblInner.Name = "_lblInner"
      Me._lblInner.Size = New System.Drawing.Size(75, 23)
      Me._lblInner.TabIndex = 1
      '
      '_btnInner
      '
      Me._btnInner.Location = New System.Drawing.Point(9, 15)
      Me._btnInner.Name = "_btnInner"
      Me._btnInner.Size = New System.Drawing.Size(75, 23)
      Me._btnInner.TabIndex = 0
      Me._btnInner.Text = "&Inner"
      Me._btnInner.UseVisualStyleBackColor = True
      '
      '_btnShowHideOptions
      '
      Me._btnShowHideOptions.Location = New System.Drawing.Point(321, 217)
      Me._btnShowHideOptions.Name = "_btnShowHideOptions"
      Me._btnShowHideOptions.Size = New System.Drawing.Size(96, 23)
      Me._btnShowHideOptions.TabIndex = 6
      Me._btnShowHideOptions.Text = "Hide Options <<"
      Me._btnShowHideOptions.UseVisualStyleBackColor = True
      '
      '_btnCancel
      '
      Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me._btnCancel.Location = New System.Drawing.Point(165, 534)
      Me._btnCancel.Name = "_btnCancel"
      Me._btnCancel.Size = New System.Drawing.Size(75, 23)
      Me._btnCancel.TabIndex = 10
      Me._btnCancel.Text = "&Cancel"
      Me._btnCancel.UseVisualStyleBackColor = True
      '
      '_btnUndo
      '
      Me._btnUndo.Location = New System.Drawing.Point(84, 534)
      Me._btnUndo.Name = "_btnUndo"
      Me._btnUndo.Size = New System.Drawing.Size(75, 23)
      Me._btnUndo.TabIndex = 9
      Me._btnUndo.Text = "&Undo"
      Me._btnUndo.UseVisualStyleBackColor = True
      '
      '_btnOk
      '
      Me._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK
      Me._btnOk.Location = New System.Drawing.Point(3, 534)
      Me._btnOk.Name = "_btnOk"
      Me._btnOk.Size = New System.Drawing.Size(75, 23)
      Me._btnOk.TabIndex = 8
      Me._btnOk.Text = "&Ok"
      Me._btnOk.UseVisualStyleBackColor = True
      '
      '_MainProgressBar
      '
      Me._MainProgressBar.Location = New System.Drawing.Point(246, 537)
      Me._MainProgressBar.Name = "_MainProgressBar"
      Me._MainProgressBar.Size = New System.Drawing.Size(177, 17)
      Me._MainProgressBar.TabIndex = 7
      '
      '_tabOptions
      '
      Me._tabOptions.Controls.Add(Me._tpgSegmentation)
      Me._tabOptions.Controls.Add(Me._tpgGrayDistribution)
      Me._tabOptions.Controls.Add(Me._tpgNoiseFilter)
      Me._tabOptions.Controls.Add(Me._tpgRescaling)
      Me._tabOptions.Location = New System.Drawing.Point(6, 233)
      Me._tabOptions.Name = "_tabOptions"
      Me._tabOptions.SelectedIndex = 0
      Me._tabOptions.Size = New System.Drawing.Size(409, 176)
      Me._tabOptions.TabIndex = 5
      '
      '_tpgSegmentation
      '
      Me._tpgSegmentation.Controls.Add(Me._chkSegApplyInProgress)
      Me._tpgSegmentation.Controls.Add(Me._btnSegApplyLUT)
      Me._tpgSegmentation.Controls.Add(Me._grpSegmentationInfo)
      Me._tpgSegmentation.Controls.Add(Me._btnSegApply)
      Me._tpgSegmentation.Controls.Add(Me._grpSegSelInfo)
      Me._tpgSegmentation.Location = New System.Drawing.Point(4, 22)
      Me._tpgSegmentation.Name = "_tpgSegmentation"
      Me._tpgSegmentation.Padding = New System.Windows.Forms.Padding(3)
      Me._tpgSegmentation.Size = New System.Drawing.Size(401, 150)
      Me._tpgSegmentation.TabIndex = 0
      Me._tpgSegmentation.Text = "Segmentation"
      Me._tpgSegmentation.UseVisualStyleBackColor = True
      '
      '_chkSegApplyInProgress
      '
      Me._chkSegApplyInProgress.AutoSize = True
      Me._chkSegApplyInProgress.Location = New System.Drawing.Point(7, 130)
      Me._chkSegApplyInProgress.Name = "_chkSegApplyInProgress"
      Me._chkSegApplyInProgress.Size = New System.Drawing.Size(94, 17)
      Me._chkSegApplyInProgress.TabIndex = 11
      Me._chkSegApplyInProgress.Text = "Show Preview"
      Me._chkSegApplyInProgress.UseVisualStyleBackColor = True
      '
      '_btnSegApplyLUT
      '
      Me._btnSegApplyLUT.Location = New System.Drawing.Point(6, 103)
      Me._btnSegApplyLUT.Name = "_btnSegApplyLUT"
      Me._btnSegApplyLUT.Size = New System.Drawing.Size(73, 23)
      Me._btnSegApplyLUT.TabIndex = 9
      Me._btnSegApplyLUT.Text = "LUT"
      Me._btnSegApplyLUT.UseVisualStyleBackColor = True
      '
      '_grpSegmentationInfo
      '
      Me._grpSegmentationInfo.Controls.Add(Me._rbSegThreshold)
      Me._grpSegmentationInfo.Controls.Add(Me._rbSegGradient)
      Me._grpSegmentationInfo.Controls.Add(Me._lblSegEndColor)
      Me._grpSegmentationInfo.Controls.Add(Me._btnSegEndColor)
      Me._grpSegmentationInfo.Controls.Add(Me._lblSegStartColor)
      Me._grpSegmentationInfo.Controls.Add(Me._btnSegStartColor)
      Me._grpSegmentationInfo.Location = New System.Drawing.Point(168, 0)
      Me._grpSegmentationInfo.Name = "_grpSegmentationInfo"
      Me._grpSegmentationInfo.Size = New System.Drawing.Size(177, 101)
      Me._grpSegmentationInfo.TabIndex = 6
      Me._grpSegmentationInfo.TabStop = False
      Me._grpSegmentationInfo.Text = "Segmentation Information"
      '
      '_rbSegThreshold
      '
      Me._rbSegThreshold.AutoSize = True
      Me._rbSegThreshold.Location = New System.Drawing.Point(95, 78)
      Me._rbSegThreshold.Name = "_rbSegThreshold"
      Me._rbSegThreshold.Size = New System.Drawing.Size(72, 17)
      Me._rbSegThreshold.TabIndex = 9
      Me._rbSegThreshold.TabStop = True
      Me._rbSegThreshold.Text = "Threshold"
      Me._rbSegThreshold.UseVisualStyleBackColor = True
      '
      '_rbSegGradient
      '
      Me._rbSegGradient.AutoSize = True
      Me._rbSegGradient.Location = New System.Drawing.Point(7, 78)
      Me._rbSegGradient.Name = "_rbSegGradient"
      Me._rbSegGradient.Size = New System.Drawing.Size(65, 17)
      Me._rbSegGradient.TabIndex = 8
      Me._rbSegGradient.TabStop = True
      Me._rbSegGradient.Text = "Gradient"
      Me._rbSegGradient.UseVisualStyleBackColor = True
      '
      '_lblSegEndColor
      '
      Me._lblSegEndColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me._lblSegEndColor.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._lblSegEndColor.Location = New System.Drawing.Point(95, 47)
      Me._lblSegEndColor.Name = "_lblSegEndColor"
      Me._lblSegEndColor.Size = New System.Drawing.Size(75, 23)
      Me._lblSegEndColor.TabIndex = 7
      '
      '_btnSegEndColor
      '
      Me._btnSegEndColor.Location = New System.Drawing.Point(7, 47)
      Me._btnSegEndColor.Name = "_btnSegEndColor"
      Me._btnSegEndColor.Size = New System.Drawing.Size(75, 23)
      Me._btnSegEndColor.TabIndex = 6
      Me._btnSegEndColor.Text = "&End Color"
      Me._btnSegEndColor.UseVisualStyleBackColor = True
      '
      '_lblSegStartColor
      '
      Me._lblSegStartColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me._lblSegStartColor.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._lblSegStartColor.Location = New System.Drawing.Point(95, 19)
      Me._lblSegStartColor.Name = "_lblSegStartColor"
      Me._lblSegStartColor.Size = New System.Drawing.Size(75, 23)
      Me._lblSegStartColor.TabIndex = 5
      '
      '_btnSegStartColor
      '
      Me._btnSegStartColor.Location = New System.Drawing.Point(7, 19)
      Me._btnSegStartColor.Name = "_btnSegStartColor"
      Me._btnSegStartColor.Size = New System.Drawing.Size(75, 23)
      Me._btnSegStartColor.TabIndex = 4
      Me._btnSegStartColor.Text = "&Start Color"
      Me._btnSegStartColor.UseVisualStyleBackColor = True
      '
      '_btnSegApply
      '
      Me._btnSegApply.Location = New System.Drawing.Point(85, 103)
      Me._btnSegApply.Name = "_btnSegApply"
      Me._btnSegApply.Size = New System.Drawing.Size(78, 23)
      Me._btnSegApply.TabIndex = 5
      Me._btnSegApply.Text = "Bitmap Data"
      Me._btnSegApply.UseVisualStyleBackColor = True
      '
      '_grpSegSelInfo
      '
      Me._grpSegSelInfo.Controls.Add(Me._lblSegEndPtOccVal)
      Me._grpSegSelInfo.Controls.Add(Me._lblSegEndPtOcc)
      Me._grpSegSelInfo.Controls.Add(Me._lblSegEndPtClr)
      Me._grpSegSelInfo.Controls.Add(Me._nudSegEndPt)
      Me._grpSegSelInfo.Controls.Add(Me._lblSegEndPt)
      Me._grpSegSelInfo.Controls.Add(Me._lblSegStartPtOccVal)
      Me._grpSegSelInfo.Controls.Add(Me._lblSegStartPtOcc)
      Me._grpSegSelInfo.Controls.Add(Me._lblSegStartPtClr)
      Me._grpSegSelInfo.Controls.Add(Me._nudSegStartPt)
      Me._grpSegSelInfo.Controls.Add(Me._lblSegStartPt)
      Me._grpSegSelInfo.Location = New System.Drawing.Point(0, 0)
      Me._grpSegSelInfo.Name = "_grpSegSelInfo"
      Me._grpSegSelInfo.Size = New System.Drawing.Size(164, 101)
      Me._grpSegSelInfo.TabIndex = 0
      Me._grpSegSelInfo.TabStop = False
      Me._grpSegSelInfo.Text = "Selection Information"
      '
      '_lblSegEndPtOccVal
      '
      Me._lblSegEndPtOccVal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
      Me._lblSegEndPtOccVal.Location = New System.Drawing.Point(97, 72)
      Me._lblSegEndPtOccVal.Name = "_lblSegEndPtOccVal"
      Me._lblSegEndPtOccVal.Size = New System.Drawing.Size(57, 20)
      Me._lblSegEndPtOccVal.TabIndex = 29
      '
      '_lblSegEndPtOcc
      '
      Me._lblSegEndPtOcc.AutoSize = True
      Me._lblSegEndPtOcc.Location = New System.Drawing.Point(96, 57)
      Me._lblSegEndPtOcc.Name = "_lblSegEndPtOcc"
      Me._lblSegEndPtOcc.Size = New System.Drawing.Size(63, 13)
      Me._lblSegEndPtOcc.TabIndex = 28
      Me._lblSegEndPtOcc.Text = "Occurrence"
      '
      '_lblSegEndPtClr
      '
      Me._lblSegEndPtClr.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
      Me._lblSegEndPtClr.Location = New System.Drawing.Point(71, 73)
      Me._lblSegEndPtClr.Name = "_lblSegEndPtClr"
      Me._lblSegEndPtClr.Size = New System.Drawing.Size(21, 20)
      Me._lblSegEndPtClr.TabIndex = 27
      '
      '_nudSegEndPt
      '
      Me._nudSegEndPt.Location = New System.Drawing.Point(7, 72)
      Me._nudSegEndPt.Name = "_nudSegEndPt"
      Me._nudSegEndPt.Size = New System.Drawing.Size(58, 20)
      Me._nudSegEndPt.TabIndex = 26
      '
      '_lblSegEndPt
      '
      Me._lblSegEndPt.AutoSize = True
      Me._lblSegEndPt.Location = New System.Drawing.Point(12, 57)
      Me._lblSegEndPt.Name = "_lblSegEndPt"
      Me._lblSegEndPt.Size = New System.Drawing.Size(53, 13)
      Me._lblSegEndPt.TabIndex = 25
      Me._lblSegEndPt.Text = "&End Point"
      '
      '_lblSegStartPtOccVal
      '
      Me._lblSegStartPtOccVal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
      Me._lblSegStartPtOccVal.Location = New System.Drawing.Point(97, 30)
      Me._lblSegStartPtOccVal.Name = "_lblSegStartPtOccVal"
      Me._lblSegStartPtOccVal.Size = New System.Drawing.Size(57, 20)
      Me._lblSegStartPtOccVal.TabIndex = 24
      '
      '_lblSegStartPtOcc
      '
      Me._lblSegStartPtOcc.AutoSize = True
      Me._lblSegStartPtOcc.Location = New System.Drawing.Point(95, 15)
      Me._lblSegStartPtOcc.Name = "_lblSegStartPtOcc"
      Me._lblSegStartPtOcc.Size = New System.Drawing.Size(63, 13)
      Me._lblSegStartPtOcc.TabIndex = 23
      Me._lblSegStartPtOcc.Text = "Occurrence"
      '
      '_lblSegStartPtClr
      '
      Me._lblSegStartPtClr.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
      Me._lblSegStartPtClr.Location = New System.Drawing.Point(71, 31)
      Me._lblSegStartPtClr.Name = "_lblSegStartPtClr"
      Me._lblSegStartPtClr.Size = New System.Drawing.Size(21, 20)
      Me._lblSegStartPtClr.TabIndex = 22
      '
      '_nudSegStartPt
      '
      Me._nudSegStartPt.Location = New System.Drawing.Point(7, 30)
      Me._nudSegStartPt.Name = "_nudSegStartPt"
      Me._nudSegStartPt.Size = New System.Drawing.Size(58, 20)
      Me._nudSegStartPt.TabIndex = 1
      '
      '_lblSegStartPt
      '
      Me._lblSegStartPt.AutoSize = True
      Me._lblSegStartPt.Location = New System.Drawing.Point(11, 15)
      Me._lblSegStartPt.Name = "_lblSegStartPt"
      Me._lblSegStartPt.Size = New System.Drawing.Size(56, 13)
      Me._lblSegStartPt.TabIndex = 0
      Me._lblSegStartPt.Text = "&Start Point"
      '
      '_tpgGrayDistribution
      '
      Me._tpgGrayDistribution.Controls.Add(Me._chkGrayApplyInProgress)
      Me._tpgGrayDistribution.Controls.Add(Me._btnGrayApplyLUT)
      Me._tpgGrayDistribution.Controls.Add(Me._grpGrySelInfo)
      Me._tpgGrayDistribution.Controls.Add(Me._btnGrayApplyToBitmap)
      Me._tpgGrayDistribution.Controls.Add(Me._grpGrayDistributionInfo)
      Me._tpgGrayDistribution.Location = New System.Drawing.Point(4, 22)
      Me._tpgGrayDistribution.Name = "_tpgGrayDistribution"
      Me._tpgGrayDistribution.Padding = New System.Windows.Forms.Padding(3)
      Me._tpgGrayDistribution.Size = New System.Drawing.Size(401, 150)
      Me._tpgGrayDistribution.TabIndex = 1
      Me._tpgGrayDistribution.Text = "Gray Distribution"
      Me._tpgGrayDistribution.UseVisualStyleBackColor = True
      '
      '_chkGrayApplyInProgress
      '
      Me._chkGrayApplyInProgress.AutoSize = True
      Me._chkGrayApplyInProgress.Location = New System.Drawing.Point(7, 130)
      Me._chkGrayApplyInProgress.Name = "_chkGrayApplyInProgress"
      Me._chkGrayApplyInProgress.Size = New System.Drawing.Size(94, 17)
      Me._chkGrayApplyInProgress.TabIndex = 12
      Me._chkGrayApplyInProgress.Text = "Show Preview"
      Me._chkGrayApplyInProgress.UseVisualStyleBackColor = True
      '
      '_btnGrayApplyLUT
      '
      Me._btnGrayApplyLUT.Location = New System.Drawing.Point(6, 103)
      Me._btnGrayApplyLUT.Name = "_btnGrayApplyLUT"
      Me._btnGrayApplyLUT.Size = New System.Drawing.Size(73, 23)
      Me._btnGrayApplyLUT.TabIndex = 8
      Me._btnGrayApplyLUT.Text = "LUT"
      Me._btnGrayApplyLUT.UseVisualStyleBackColor = True
      '
      '_grpGrySelInfo
      '
      Me._grpGrySelInfo.Controls.Add(Me._lblGryEndPtOccVal)
      Me._grpGrySelInfo.Controls.Add(Me._lblGryEndPtOcc)
      Me._grpGrySelInfo.Controls.Add(Me._lblGrayEndPtClr)
      Me._grpGrySelInfo.Controls.Add(Me._nudGrayEndPt)
      Me._grpGrySelInfo.Controls.Add(Me._lblGryEndPt)
      Me._grpGrySelInfo.Controls.Add(Me._lblGryStartPtOccVal)
      Me._grpGrySelInfo.Controls.Add(Me._lblGryStartPtOcc)
      Me._grpGrySelInfo.Controls.Add(Me._lblGrayStartPtClr)
      Me._grpGrySelInfo.Controls.Add(Me._nudGrayStartPt)
      Me._grpGrySelInfo.Controls.Add(Me._lblGryStartPt)
      Me._grpGrySelInfo.Location = New System.Drawing.Point(0, 0)
      Me._grpGrySelInfo.Name = "_grpGrySelInfo"
      Me._grpGrySelInfo.Size = New System.Drawing.Size(164, 101)
      Me._grpGrySelInfo.TabIndex = 7
      Me._grpGrySelInfo.TabStop = False
      Me._grpGrySelInfo.Text = "Selection Information"
      '
      '_lblGryEndPtOccVal
      '
      Me._lblGryEndPtOccVal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
      Me._lblGryEndPtOccVal.Location = New System.Drawing.Point(97, 72)
      Me._lblGryEndPtOccVal.Name = "_lblGryEndPtOccVal"
      Me._lblGryEndPtOccVal.Size = New System.Drawing.Size(57, 20)
      Me._lblGryEndPtOccVal.TabIndex = 29
      '
      '_lblGryEndPtOcc
      '
      Me._lblGryEndPtOcc.AutoSize = True
      Me._lblGryEndPtOcc.Location = New System.Drawing.Point(96, 57)
      Me._lblGryEndPtOcc.Name = "_lblGryEndPtOcc"
      Me._lblGryEndPtOcc.Size = New System.Drawing.Size(63, 13)
      Me._lblGryEndPtOcc.TabIndex = 28
      Me._lblGryEndPtOcc.Text = "Occurrence"
      '
      '_lblGrayEndPtClr
      '
      Me._lblGrayEndPtClr.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
      Me._lblGrayEndPtClr.Location = New System.Drawing.Point(71, 73)
      Me._lblGrayEndPtClr.Name = "_lblGrayEndPtClr"
      Me._lblGrayEndPtClr.Size = New System.Drawing.Size(21, 20)
      Me._lblGrayEndPtClr.TabIndex = 27
      '
      '_nudGrayEndPt
      '
      Me._nudGrayEndPt.Location = New System.Drawing.Point(7, 72)
      Me._nudGrayEndPt.Name = "_nudGrayEndPt"
      Me._nudGrayEndPt.Size = New System.Drawing.Size(58, 20)
      Me._nudGrayEndPt.TabIndex = 26
      '
      '_lblGryEndPt
      '
      Me._lblGryEndPt.AutoSize = True
      Me._lblGryEndPt.Location = New System.Drawing.Point(12, 57)
      Me._lblGryEndPt.Name = "_lblGryEndPt"
      Me._lblGryEndPt.Size = New System.Drawing.Size(53, 13)
      Me._lblGryEndPt.TabIndex = 25
      Me._lblGryEndPt.Text = "&End Point"
      '
      '_lblGryStartPtOccVal
      '
      Me._lblGryStartPtOccVal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
      Me._lblGryStartPtOccVal.Location = New System.Drawing.Point(97, 30)
      Me._lblGryStartPtOccVal.Name = "_lblGryStartPtOccVal"
      Me._lblGryStartPtOccVal.Size = New System.Drawing.Size(57, 20)
      Me._lblGryStartPtOccVal.TabIndex = 24
      '
      '_lblGryStartPtOcc
      '
      Me._lblGryStartPtOcc.AutoSize = True
      Me._lblGryStartPtOcc.Location = New System.Drawing.Point(95, 15)
      Me._lblGryStartPtOcc.Name = "_lblGryStartPtOcc"
      Me._lblGryStartPtOcc.Size = New System.Drawing.Size(63, 13)
      Me._lblGryStartPtOcc.TabIndex = 23
      Me._lblGryStartPtOcc.Text = "Occurrence"
      '
      '_lblGrayStartPtClr
      '
      Me._lblGrayStartPtClr.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
      Me._lblGrayStartPtClr.Location = New System.Drawing.Point(71, 31)
      Me._lblGrayStartPtClr.Name = "_lblGrayStartPtClr"
      Me._lblGrayStartPtClr.Size = New System.Drawing.Size(21, 20)
      Me._lblGrayStartPtClr.TabIndex = 22
      '
      '_nudGrayStartPt
      '
      Me._nudGrayStartPt.Location = New System.Drawing.Point(7, 30)
      Me._nudGrayStartPt.Name = "_nudGrayStartPt"
      Me._nudGrayStartPt.Size = New System.Drawing.Size(58, 20)
      Me._nudGrayStartPt.TabIndex = 1
      '
      '_lblGryStartPt
      '
      Me._lblGryStartPt.AutoSize = True
      Me._lblGryStartPt.Location = New System.Drawing.Point(11, 15)
      Me._lblGryStartPt.Name = "_lblGryStartPt"
      Me._lblGryStartPt.Size = New System.Drawing.Size(56, 13)
      Me._lblGryStartPt.TabIndex = 0
      Me._lblGryStartPt.Text = "&Start Point"
      '
      '_btnGrayApplyToBitmap
      '
      Me._btnGrayApplyToBitmap.Location = New System.Drawing.Point(85, 103)
      Me._btnGrayApplyToBitmap.Name = "_btnGrayApplyToBitmap"
      Me._btnGrayApplyToBitmap.Size = New System.Drawing.Size(78, 23)
      Me._btnGrayApplyToBitmap.TabIndex = 6
      Me._btnGrayApplyToBitmap.Text = "Bitmap Data"
      Me._btnGrayApplyToBitmap.UseVisualStyleBackColor = True
      '
      '_grpGrayDistributionInfo
      '
      Me._grpGrayDistributionInfo.Controls.Add(Me._cbGraySelectionOnly)
      Me._grpGrayDistributionInfo.Controls.Add(Me._lblGrayEndColor)
      Me._grpGrayDistributionInfo.Controls.Add(Me._btnGrayEndColor)
      Me._grpGrayDistributionInfo.Controls.Add(Me._lblGrayStartColor)
      Me._grpGrayDistributionInfo.Controls.Add(Me._btnGrayStartColor)
      Me._grpGrayDistributionInfo.Controls.Add(Me._txtGrayWidth)
      Me._grpGrayDistributionInfo.Controls.Add(Me._lblGrayWidth)
      Me._grpGrayDistributionInfo.Controls.Add(Me._txtGrayCenter)
      Me._grpGrayDistributionInfo.Controls.Add(Me._lblGrayCenter)
      Me._grpGrayDistributionInfo.Controls.Add(Me._nudGrayFactor)
      Me._grpGrayDistributionInfo.Controls.Add(Me._cbGrayFunctionType)
      Me._grpGrayDistributionInfo.Controls.Add(Me._lblGrayFactor)
      Me._grpGrayDistributionInfo.Controls.Add(Me._lblGrayFunctionType)
      Me._grpGrayDistributionInfo.Location = New System.Drawing.Point(168, 0)
      Me._grpGrayDistributionInfo.Name = "_grpGrayDistributionInfo"
      Me._grpGrayDistributionInfo.Size = New System.Drawing.Size(230, 102)
      Me._grpGrayDistributionInfo.TabIndex = 2
      Me._grpGrayDistributionInfo.TabStop = False
      Me._grpGrayDistributionInfo.Text = "Gray Distribution Information"
      '
      '_cbGraySelectionOnly
      '
      Me._cbGraySelectionOnly.AutoSize = True
      Me._cbGraySelectionOnly.Location = New System.Drawing.Point(5, 51)
      Me._cbGraySelectionOnly.Name = "_cbGraySelectionOnly"
      Me._cbGraySelectionOnly.Size = New System.Drawing.Size(94, 17)
      Me._cbGraySelectionOnly.TabIndex = 11
      Me._cbGraySelectionOnly.Text = "Selection Only"
      Me._cbGraySelectionOnly.UseVisualStyleBackColor = True
      '
      '_lblGrayEndColor
      '
      Me._lblGrayEndColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me._lblGrayEndColor.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._lblGrayEndColor.Location = New System.Drawing.Point(181, 71)
      Me._lblGrayEndColor.Name = "_lblGrayEndColor"
      Me._lblGrayEndColor.Size = New System.Drawing.Size(37, 20)
      Me._lblGrayEndColor.TabIndex = 10
      '
      '_btnGrayEndColor
      '
      Me._btnGrayEndColor.Location = New System.Drawing.Point(113, 69)
      Me._btnGrayEndColor.Name = "_btnGrayEndColor"
      Me._btnGrayEndColor.Size = New System.Drawing.Size(64, 23)
      Me._btnGrayEndColor.TabIndex = 9
      Me._btnGrayEndColor.Text = "&End Color"
      Me._btnGrayEndColor.UseVisualStyleBackColor = True
      '
      '_lblGrayStartColor
      '
      Me._lblGrayStartColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me._lblGrayStartColor.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._lblGrayStartColor.Location = New System.Drawing.Point(74, 71)
      Me._lblGrayStartColor.Name = "_lblGrayStartColor"
      Me._lblGrayStartColor.Size = New System.Drawing.Size(35, 20)
      Me._lblGrayStartColor.TabIndex = 8
      '
      '_btnGrayStartColor
      '
      Me._btnGrayStartColor.Location = New System.Drawing.Point(5, 69)
      Me._btnGrayStartColor.Name = "_btnGrayStartColor"
      Me._btnGrayStartColor.Size = New System.Drawing.Size(66, 23)
      Me._btnGrayStartColor.TabIndex = 7
      Me._btnGrayStartColor.Text = "&Start Color"
      Me._btnGrayStartColor.UseVisualStyleBackColor = True
      '
      '_txtGrayWidth
      '
      Me._txtGrayWidth.Location = New System.Drawing.Point(179, 37)
      Me._txtGrayWidth.Name = "_txtGrayWidth"
      Me._txtGrayWidth.ReadOnly = True
      Me._txtGrayWidth.Size = New System.Drawing.Size(45, 20)
      Me._txtGrayWidth.TabIndex = 5
      '
      '_lblGrayWidth
      '
      Me._lblGrayWidth.AutoSize = True
      Me._lblGrayWidth.Location = New System.Drawing.Point(143, 39)
      Me._lblGrayWidth.Name = "_lblGrayWidth"
      Me._lblGrayWidth.Size = New System.Drawing.Size(35, 13)
      Me._lblGrayWidth.TabIndex = 6
      Me._lblGrayWidth.Text = "Width"
      '
      '_txtGrayCenter
      '
      Me._txtGrayCenter.Location = New System.Drawing.Point(179, 14)
      Me._txtGrayCenter.Name = "_txtGrayCenter"
      Me._txtGrayCenter.ReadOnly = True
      Me._txtGrayCenter.Size = New System.Drawing.Size(45, 20)
      Me._txtGrayCenter.TabIndex = 0
      '
      '_lblGrayCenter
      '
      Me._lblGrayCenter.AutoSize = True
      Me._lblGrayCenter.Location = New System.Drawing.Point(140, 15)
      Me._lblGrayCenter.Name = "_lblGrayCenter"
      Me._lblGrayCenter.Size = New System.Drawing.Size(38, 13)
      Me._lblGrayCenter.TabIndex = 4
      Me._lblGrayCenter.Text = "Center"
      '
      '_nudGrayFactor
      '
      Me._nudGrayFactor.Location = New System.Drawing.Point(94, 28)
      Me._nudGrayFactor.Name = "_nudGrayFactor"
      Me._nudGrayFactor.Size = New System.Drawing.Size(49, 20)
      Me._nudGrayFactor.TabIndex = 3
      '
      '_cbGrayFunctionType
      '
      Me._cbGrayFunctionType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me._cbGrayFunctionType.FormattingEnabled = True
      Me._cbGrayFunctionType.Items.AddRange(New Object() {"Exponential", "Log", "Linear", "Sigmoid"})
      Me._cbGrayFunctionType.Location = New System.Drawing.Point(6, 28)
      Me._cbGrayFunctionType.Name = "_cbGrayFunctionType"
      Me._cbGrayFunctionType.Size = New System.Drawing.Size(85, 21)
      Me._cbGrayFunctionType.TabIndex = 2
      '
      '_lblGrayFactor
      '
      Me._lblGrayFactor.AutoSize = True
      Me._lblGrayFactor.Location = New System.Drawing.Point(94, 15)
      Me._lblGrayFactor.Name = "_lblGrayFactor"
      Me._lblGrayFactor.Size = New System.Drawing.Size(37, 13)
      Me._lblGrayFactor.TabIndex = 1
      Me._lblGrayFactor.Text = "Factor"
      '
      '_lblGrayFunctionType
      '
      Me._lblGrayFunctionType.AutoSize = True
      Me._lblGrayFunctionType.Location = New System.Drawing.Point(3, 15)
      Me._lblGrayFunctionType.Name = "_lblGrayFunctionType"
      Me._lblGrayFunctionType.Size = New System.Drawing.Size(75, 13)
      Me._lblGrayFunctionType.TabIndex = 0
      Me._lblGrayFunctionType.Text = "Function Type"
      '
      '_tpgNoiseFilter
      '
      Me._tpgNoiseFilter.Controls.Add(Me._chkNoiseApplyInProgress)
      Me._tpgNoiseFilter.Controls.Add(Me._btnNoiseApplyLUT)
      Me._tpgNoiseFilter.Controls.Add(Me._grpNoiseSelInfo)
      Me._tpgNoiseFilter.Controls.Add(Me._btnNoiseApplyBitmap)
      Me._tpgNoiseFilter.Controls.Add(Me._grpNoiseFilterInfo)
      Me._tpgNoiseFilter.Location = New System.Drawing.Point(4, 22)
      Me._tpgNoiseFilter.Name = "_tpgNoiseFilter"
      Me._tpgNoiseFilter.Padding = New System.Windows.Forms.Padding(3)
      Me._tpgNoiseFilter.Size = New System.Drawing.Size(401, 150)
      Me._tpgNoiseFilter.TabIndex = 2
      Me._tpgNoiseFilter.Text = "Noise Filter"
      Me._tpgNoiseFilter.UseVisualStyleBackColor = True
      '
      '_chkNoiseApplyInProgress
      '
      Me._chkNoiseApplyInProgress.AutoSize = True
      Me._chkNoiseApplyInProgress.Location = New System.Drawing.Point(7, 130)
      Me._chkNoiseApplyInProgress.Name = "_chkNoiseApplyInProgress"
      Me._chkNoiseApplyInProgress.Size = New System.Drawing.Size(94, 17)
      Me._chkNoiseApplyInProgress.TabIndex = 12
      Me._chkNoiseApplyInProgress.Text = "Show Preview"
      Me._chkNoiseApplyInProgress.UseVisualStyleBackColor = True
      '
      '_btnNoiseApplyLUT
      '
      Me._btnNoiseApplyLUT.Location = New System.Drawing.Point(6, 103)
      Me._btnNoiseApplyLUT.Name = "_btnNoiseApplyLUT"
      Me._btnNoiseApplyLUT.Size = New System.Drawing.Size(73, 23)
      Me._btnNoiseApplyLUT.TabIndex = 9
      Me._btnNoiseApplyLUT.Text = "LUT"
      Me._btnNoiseApplyLUT.UseVisualStyleBackColor = True
      '
      '_grpNoiseSelInfo
      '
      Me._grpNoiseSelInfo.Controls.Add(Me._lblNoiseEndPtOccVal)
      Me._grpNoiseSelInfo.Controls.Add(Me._lblNoiseEndPtOcc)
      Me._grpNoiseSelInfo.Controls.Add(Me._lblNoiseEndPtClr)
      Me._grpNoiseSelInfo.Controls.Add(Me._nudNoiseEndPt)
      Me._grpNoiseSelInfo.Controls.Add(Me._lblNoiseEndPt)
      Me._grpNoiseSelInfo.Controls.Add(Me._lblNoiseStartPtOccVal)
      Me._grpNoiseSelInfo.Controls.Add(Me._lblNoiseStartPtOcc)
      Me._grpNoiseSelInfo.Controls.Add(Me._lblNoiseStartPtClr)
      Me._grpNoiseSelInfo.Controls.Add(Me._nudNoiseStartPt)
      Me._grpNoiseSelInfo.Controls.Add(Me._lblNoiseStartPt)
      Me._grpNoiseSelInfo.Location = New System.Drawing.Point(0, 0)
      Me._grpNoiseSelInfo.Name = "_grpNoiseSelInfo"
      Me._grpNoiseSelInfo.Size = New System.Drawing.Size(164, 101)
      Me._grpNoiseSelInfo.TabIndex = 7
      Me._grpNoiseSelInfo.TabStop = False
      Me._grpNoiseSelInfo.Text = "Selection Information"
      '
      '_lblNoiseEndPtOccVal
      '
      Me._lblNoiseEndPtOccVal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
      Me._lblNoiseEndPtOccVal.Location = New System.Drawing.Point(97, 72)
      Me._lblNoiseEndPtOccVal.Name = "_lblNoiseEndPtOccVal"
      Me._lblNoiseEndPtOccVal.Size = New System.Drawing.Size(57, 20)
      Me._lblNoiseEndPtOccVal.TabIndex = 29
      '
      '_lblNoiseEndPtOcc
      '
      Me._lblNoiseEndPtOcc.AutoSize = True
      Me._lblNoiseEndPtOcc.Location = New System.Drawing.Point(96, 57)
      Me._lblNoiseEndPtOcc.Name = "_lblNoiseEndPtOcc"
      Me._lblNoiseEndPtOcc.Size = New System.Drawing.Size(63, 13)
      Me._lblNoiseEndPtOcc.TabIndex = 28
      Me._lblNoiseEndPtOcc.Text = "Occurrence"
      '
      '_lblNoiseEndPtClr
      '
      Me._lblNoiseEndPtClr.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
      Me._lblNoiseEndPtClr.Location = New System.Drawing.Point(71, 73)
      Me._lblNoiseEndPtClr.Name = "_lblNoiseEndPtClr"
      Me._lblNoiseEndPtClr.Size = New System.Drawing.Size(21, 20)
      Me._lblNoiseEndPtClr.TabIndex = 27
      '
      '_nudNoiseEndPt
      '
      Me._nudNoiseEndPt.Location = New System.Drawing.Point(7, 72)
      Me._nudNoiseEndPt.Name = "_nudNoiseEndPt"
      Me._nudNoiseEndPt.Size = New System.Drawing.Size(58, 20)
      Me._nudNoiseEndPt.TabIndex = 26
      '
      '_lblNoiseEndPt
      '
      Me._lblNoiseEndPt.AutoSize = True
      Me._lblNoiseEndPt.Location = New System.Drawing.Point(12, 57)
      Me._lblNoiseEndPt.Name = "_lblNoiseEndPt"
      Me._lblNoiseEndPt.Size = New System.Drawing.Size(53, 13)
      Me._lblNoiseEndPt.TabIndex = 25
      Me._lblNoiseEndPt.Text = "&End Point"
      '
      '_lblNoiseStartPtOccVal
      '
      Me._lblNoiseStartPtOccVal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
      Me._lblNoiseStartPtOccVal.Location = New System.Drawing.Point(97, 30)
      Me._lblNoiseStartPtOccVal.Name = "_lblNoiseStartPtOccVal"
      Me._lblNoiseStartPtOccVal.Size = New System.Drawing.Size(57, 20)
      Me._lblNoiseStartPtOccVal.TabIndex = 24
      '
      '_cbChannel
      '
      Me._cbChannel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me._cbChannel.FormattingEnabled = True
      Me._cbChannel.Items.AddRange(New Object() {"RGB", "Red", "Green", "Blue"})
      Me._cbChannel.Location = New System.Drawing.Point(323, 25)
      Me._cbChannel.Name = "_cbChannel"
      Me._cbChannel.Size = New System.Drawing.Size(94, 21)
      Me._cbChannel.TabIndex = 2
      '
      '_lblChannel
      '
      Me._lblChannel.AutoSize = True
      Me._lblChannel.Location = New System.Drawing.Point(320, 9)
      Me._lblChannel.Name = "_lblChannel"
      Me._lblChannel.Size = New System.Drawing.Size(46, 13)
      Me._lblChannel.TabIndex = 1
      Me._lblChannel.Text = "Channel"
      '
      '_cmRightClickOptions
      '
      Me._cmRightClickOptions.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me._cmiZoomToSelection, Me._cmiFitGraph, Me._cmiFullRangeView})
      Me._cmRightClickOptions.Name = "_cmRightClickOptions"
      Me._cmRightClickOptions.Size = New System.Drawing.Size(159, 70)
      '
      '_cmiZoomToSelection
      '
      Me._cmiZoomToSelection.Name = "_cmiZoomToSelection"
      Me._cmiZoomToSelection.Size = New System.Drawing.Size(158, 22)
      Me._cmiZoomToSelection.Text = "Zoom to selection"
      '
      '_cmiFitGraph
      '
      Me._cmiFitGraph.Name = "_cmiFitGraph"
      Me._cmiFitGraph.Size = New System.Drawing.Size(158, 22)
      Me._cmiFitGraph.Text = "Fit Graph"
      '
      '_cmiFullRangeView
      '
      Me._cmiFullRangeView.Name = "_cmiFullRangeView"
      Me._cmiFullRangeView.Size = New System.Drawing.Size(158, 22)
      Me._cmiFullRangeView.Text = "Full Range View"
      '
      '_lblHistogram
      '
      Me._lblHistogram.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
      Me._lblHistogram.ContextMenuStrip = Me._cmRightClickOptions
      Me._lblHistogram.Location = New System.Drawing.Point(9, 16)
      Me._lblHistogram.Name = "_lblHistogram"
      Me._lblHistogram.Size = New System.Drawing.Size(305, 210)
      Me._lblHistogram.TabIndex = 0
      '
      '_lblSelectionType
      '
      Me._lblSelectionType.AutoSize = True
      Me._lblSelectionType.Location = New System.Drawing.Point(320, 176)
      Me._lblSelectionType.Name = "_lblSelectionType"
      Me._lblSelectionType.Size = New System.Drawing.Size(78, 13)
      Me._lblSelectionType.TabIndex = 1
      Me._lblSelectionType.Text = "Selection Type"
      '
      '_cbSelectionType
      '
      Me._cbSelectionType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me._cbSelectionType.FormattingEnabled = True
      Me._cbSelectionType.Items.AddRange(New Object() {"All", "Inner Area", "Left Area", "Right Area"})
      Me._cbSelectionType.Location = New System.Drawing.Point(323, 191)
      Me._cbSelectionType.Name = "_cbSelectionType"
      Me._cbSelectionType.Size = New System.Drawing.Size(94, 21)
      Me._cbSelectionType.TabIndex = 0
      '
      '_grpView
      '
      Me._grpView.Controls.Add(Me._lblHelp)
      Me._grpView.Controls.Add(Me._grpStatisticalInformation)
      Me._grpView.Controls.Add(Me._btnShowHideOptions)
      Me._grpView.Controls.Add(Me._tabOptions)
      Me._grpView.Controls.Add(Me._grpSelectionColor)
      Me._grpView.Controls.Add(Me._cbChannel)
      Me._grpView.Controls.Add(Me._lblChannel)
      Me._grpView.Controls.Add(Me._lblHistogram)
      Me._grpView.Controls.Add(Me._cbSelectionType)
      Me._grpView.Controls.Add(Me._lblSelectionType)
      Me._grpView.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._grpView.Location = New System.Drawing.Point(3, 0)
      Me._grpView.Name = "_grpView"
      Me._grpView.Size = New System.Drawing.Size(425, 528)
      Me._grpView.TabIndex = 6
      Me._grpView.TabStop = False
      Me._grpView.Text = "Histogram View"
      '
      '_lblHelp
      '
      Me._lblHelp.AutoSize = True
      Me._lblHelp.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
      Me._lblHelp.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me._lblHelp.ForeColor = System.Drawing.Color.Red
      Me._lblHelp.Location = New System.Drawing.Point(35, 413)
      Me._lblHelp.Name = "_lblHelp"
      Me._lblHelp.Size = New System.Drawing.Size(354, 15)
      Me._lblHelp.TabIndex = 11
      Me._lblHelp.Text = "Left click selects the Start point, SHIFT + Left click selects the End point."
      Me._lblHelp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      '_grpStatisticalInformation
      '
      Me._grpStatisticalInformation.Controls.Add(Me._grpMouse)
      Me._grpStatisticalInformation.Controls.Add(Me._lblStdDev)
      Me._grpStatisticalInformation.Controls.Add(Me._lblSelStdDev)
      Me._grpStatisticalInformation.Controls.Add(Me._lblMedian)
      Me._grpStatisticalInformation.Controls.Add(Me._lblSelMedian)
      Me._grpStatisticalInformation.Controls.Add(Me._lblMean)
      Me._grpStatisticalInformation.Controls.Add(Me._lblSelMean)
      Me._grpStatisticalInformation.Controls.Add(Me._lblLevel)
      Me._grpStatisticalInformation.Controls.Add(Me._lblSelLevel)
      Me._grpStatisticalInformation.Controls.Add(Me._lblPercent)
      Me._grpStatisticalInformation.Controls.Add(Me._lblSelPercent)
      Me._grpStatisticalInformation.Controls.Add(Me._lblCount)
      Me._grpStatisticalInformation.Controls.Add(Me._lblSelCount)
      Me._grpStatisticalInformation.Location = New System.Drawing.Point(6, 436)
      Me._grpStatisticalInformation.Name = "_grpStatisticalInformation"
      Me._grpStatisticalInformation.Size = New System.Drawing.Size(408, 88)
      Me._grpStatisticalInformation.TabIndex = 7
      Me._grpStatisticalInformation.TabStop = False
      Me._grpStatisticalInformation.Text = "Statistical Information (Selection)"
      '
      '_grpMouse
      '
      Me._grpMouse.Controls.Add(Me.label1)
      Me._grpMouse.Controls.Add(Me._lblMouseLevel)
      Me._grpMouse.Controls.Add(Me.label2)
      Me._grpMouse.Controls.Add(Me._lblMousePercent)
      Me._grpMouse.Controls.Add(Me.label3)
      Me._grpMouse.Controls.Add(Me._lblMouseCount)
      Me._grpMouse.Location = New System.Drawing.Point(280, 0)
      Me._grpMouse.Name = "_grpMouse"
      Me._grpMouse.Size = New System.Drawing.Size(128, 88)
      Me._grpMouse.TabIndex = 22
      Me._grpMouse.TabStop = False
      Me._grpMouse.Text = "Mouse"
      '
      'label1
      '
      Me.label1.AutoSize = True
      Me.label1.Location = New System.Drawing.Point(6, 65)
      Me.label1.Name = "label1"
      Me.label1.Size = New System.Drawing.Size(33, 13)
      Me.label1.TabIndex = 25
      Me.label1.Text = "Level"
      '
      '_lblMouseLevel
      '
      Me._lblMouseLevel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
      Me._lblMouseLevel.Location = New System.Drawing.Point(54, 62)
      Me._lblMouseLevel.Name = "_lblMouseLevel"
      Me._lblMouseLevel.Size = New System.Drawing.Size(71, 21)
      Me._lblMouseLevel.TabIndex = 11
      Me._lblMouseLevel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'label2
      '
      Me.label2.AutoSize = True
      Me.label2.Location = New System.Drawing.Point(6, 42)
      Me.label2.Name = "label2"
      Me.label2.Size = New System.Drawing.Size(44, 13)
      Me.label2.TabIndex = 24
      Me.label2.Text = "Percent"
      '
      '_lblMousePercent
      '
      Me._lblMousePercent.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
      Me._lblMousePercent.Location = New System.Drawing.Point(54, 38)
      Me._lblMousePercent.Name = "_lblMousePercent"
      Me._lblMousePercent.Size = New System.Drawing.Size(71, 21)
      Me._lblMousePercent.TabIndex = 8
      Me._lblMousePercent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'label3
      '
      Me.label3.AutoSize = True
      Me.label3.Location = New System.Drawing.Point(6, 18)
      Me.label3.Name = "label3"
      Me.label3.Size = New System.Drawing.Size(35, 13)
      Me.label3.TabIndex = 23
      Me.label3.Text = "Count"
      '
      '_lblMouseCount
      '
      Me._lblMouseCount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
      Me._lblMouseCount.Location = New System.Drawing.Point(54, 14)
      Me._lblMouseCount.Name = "_lblMouseCount"
      Me._lblMouseCount.Size = New System.Drawing.Size(71, 21)
      Me._lblMouseCount.TabIndex = 5
      Me._lblMouseCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      '_lblStdDev
      '
      Me._lblStdDev.AutoSize = True
      Me._lblStdDev.Location = New System.Drawing.Point(161, 65)
      Me._lblStdDev.Name = "_lblStdDev"
      Me._lblStdDev.Size = New System.Drawing.Size(43, 13)
      Me._lblStdDev.TabIndex = 21
      Me._lblStdDev.Text = "StdDev"
      '
      '_lblSelStdDev
      '
      Me._lblSelStdDev.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
      Me._lblSelStdDev.Location = New System.Drawing.Point(210, 62)
      Me._lblSelStdDev.Name = "_lblSelStdDev"
      Me._lblSelStdDev.Size = New System.Drawing.Size(64, 21)
      Me._lblSelStdDev.TabIndex = 19
      Me._lblSelStdDev.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      '_lblMedian
      '
      Me._lblMedian.AutoSize = True
      Me._lblMedian.Location = New System.Drawing.Point(161, 42)
      Me._lblMedian.Name = "_lblMedian"
      Me._lblMedian.Size = New System.Drawing.Size(42, 13)
      Me._lblMedian.TabIndex = 18
      Me._lblMedian.Text = "Median"
      '
      '_lblSelMedian
      '
      Me._lblSelMedian.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
      Me._lblSelMedian.Location = New System.Drawing.Point(210, 38)
      Me._lblSelMedian.Name = "_lblSelMedian"
      Me._lblSelMedian.Size = New System.Drawing.Size(64, 21)
      Me._lblSelMedian.TabIndex = 16
      Me._lblSelMedian.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      '_lblMean
      '
      Me._lblMean.AutoSize = True
      Me._lblMean.Location = New System.Drawing.Point(161, 18)
      Me._lblMean.Name = "_lblMean"
      Me._lblMean.Size = New System.Drawing.Size(34, 13)
      Me._lblMean.TabIndex = 15
      Me._lblMean.Text = "Mean"
      '
      '_lblSelMean
      '
      Me._lblSelMean.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
      Me._lblSelMean.Location = New System.Drawing.Point(210, 14)
      Me._lblSelMean.Name = "_lblSelMean"
      Me._lblSelMean.Size = New System.Drawing.Size(64, 21)
      Me._lblSelMean.TabIndex = 13
      Me._lblSelMean.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      '_lblLevel
      '
      Me._lblLevel.AutoSize = True
      Me._lblLevel.Location = New System.Drawing.Point(9, 65)
      Me._lblLevel.Name = "_lblLevel"
      Me._lblLevel.Size = New System.Drawing.Size(33, 13)
      Me._lblLevel.TabIndex = 12
      Me._lblLevel.Text = "Level"
      '
      '_lblSelLevel
      '
      Me._lblSelLevel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
      Me._lblSelLevel.Location = New System.Drawing.Point(54, 62)
      Me._lblSelLevel.Name = "_lblSelLevel"
      Me._lblSelLevel.Size = New System.Drawing.Size(96, 21)
      Me._lblSelLevel.TabIndex = 10
      Me._lblSelLevel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      '_lblPercent
      '
      Me._lblPercent.AutoSize = True
      Me._lblPercent.Location = New System.Drawing.Point(9, 42)
      Me._lblPercent.Name = "_lblPercent"
      Me._lblPercent.Size = New System.Drawing.Size(44, 13)
      Me._lblPercent.TabIndex = 9
      Me._lblPercent.Text = "Percent"
      '
      '_lblSelPercent
      '
      Me._lblSelPercent.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
      Me._lblSelPercent.Location = New System.Drawing.Point(54, 38)
      Me._lblSelPercent.Name = "_lblSelPercent"
      Me._lblSelPercent.Size = New System.Drawing.Size(96, 21)
      Me._lblSelPercent.TabIndex = 7
      Me._lblSelPercent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      '_lblCount
      '
      Me._lblCount.AutoSize = True
      Me._lblCount.Location = New System.Drawing.Point(9, 18)
      Me._lblCount.Name = "_lblCount"
      Me._lblCount.Size = New System.Drawing.Size(35, 13)
      Me._lblCount.TabIndex = 6
      Me._lblCount.Text = "Count"
      '
      '_lblSelCount
      '
      Me._lblSelCount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
      Me._lblSelCount.Location = New System.Drawing.Point(54, 14)
      Me._lblSelCount.Name = "_lblSelCount"
      Me._lblSelCount.Size = New System.Drawing.Size(96, 21)
      Me._lblSelCount.TabIndex = 4
      Me._lblSelCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'InteractiveHistDialog
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(432, 562)
      Me.Controls.Add(Me._btnCancel)
      Me.Controls.Add(Me._btnUndo)
      Me.Controls.Add(Me._btnOk)
      Me.Controls.Add(Me._MainProgressBar)
      Me.Controls.Add(Me._grpView)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "InteractiveHistDialog"
      Me.ShowIcon = False
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
      Me.Text = "Interactive Histogram"
      CType(Me._nudResNewEnd, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me._nudResNewStart, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me._nudResShiftAmount, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me._nudResStartPt, System.ComponentModel.ISupportInitialize).EndInit()
      Me._grpRescalingInfor.ResumeLayout(False)
      Me._grpRescalingInfor.PerformLayout()
      Me._grpNoiseFilterInfo.ResumeLayout(False)
      Me._grpNoiseFilterInfo.PerformLayout()
      CType(Me._nudNoiseStartPt, System.ComponentModel.ISupportInitialize).EndInit()
      Me._grpResSelInfo.ResumeLayout(False)
      Me._grpResSelInfo.PerformLayout()
      CType(Me._nudResEndPt, System.ComponentModel.ISupportInitialize).EndInit()
      Me._tpgRescaling.ResumeLayout(False)
      Me._tpgRescaling.PerformLayout()
      Me._grpSelectionColor.ResumeLayout(False)
      Me._tabOptions.ResumeLayout(False)
      Me._tpgSegmentation.ResumeLayout(False)
      Me._tpgSegmentation.PerformLayout()
      Me._grpSegmentationInfo.ResumeLayout(False)
      Me._grpSegmentationInfo.PerformLayout()
      Me._grpSegSelInfo.ResumeLayout(False)
      Me._grpSegSelInfo.PerformLayout()
      CType(Me._nudSegEndPt, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me._nudSegStartPt, System.ComponentModel.ISupportInitialize).EndInit()
      Me._tpgGrayDistribution.ResumeLayout(False)
      Me._tpgGrayDistribution.PerformLayout()
      Me._grpGrySelInfo.ResumeLayout(False)
      Me._grpGrySelInfo.PerformLayout()
      CType(Me._nudGrayEndPt, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me._nudGrayStartPt, System.ComponentModel.ISupportInitialize).EndInit()
      Me._grpGrayDistributionInfo.ResumeLayout(False)
      Me._grpGrayDistributionInfo.PerformLayout()
      CType(Me._nudGrayFactor, System.ComponentModel.ISupportInitialize).EndInit()
      Me._tpgNoiseFilter.ResumeLayout(False)
      Me._tpgNoiseFilter.PerformLayout()
      Me._grpNoiseSelInfo.ResumeLayout(False)
      Me._grpNoiseSelInfo.PerformLayout()
      CType(Me._nudNoiseEndPt, System.ComponentModel.ISupportInitialize).EndInit()
      Me._cmRightClickOptions.ResumeLayout(False)
      Me._grpView.ResumeLayout(False)
      Me._grpView.PerformLayout()
      Me._grpStatisticalInformation.ResumeLayout(False)
      Me._grpStatisticalInformation.PerformLayout()
      Me._grpMouse.ResumeLayout(False)
      Me._grpMouse.PerformLayout()
      Me.ResumeLayout(False)

   End Sub
   Private WithEvents _rbResShiftLeft As System.Windows.Forms.RadioButton
   Private WithEvents _rbResShiftRight As System.Windows.Forms.RadioButton
   Private WithEvents _nudResNewEnd As System.Windows.Forms.NumericUpDown
   Private WithEvents _lblResNewEnd As System.Windows.Forms.Label
   Private WithEvents _nudResNewStart As System.Windows.Forms.NumericUpDown
   Private WithEvents _lblResStartPtOccVal As System.Windows.Forms.Label
   Private WithEvents _lblResStartPtOcc As System.Windows.Forms.Label
   Private WithEvents _lblResStartPtClr As System.Windows.Forms.Label
   Private WithEvents _lblResEndPt As System.Windows.Forms.Label
   Private WithEvents _lblResNewStart As System.Windows.Forms.Label
   Private WithEvents _nudResShiftAmount As System.Windows.Forms.NumericUpDown
   Private WithEvents _lblResShiftAmount As System.Windows.Forms.Label
   Private WithEvents _nudResStartPt As System.Windows.Forms.NumericUpDown
   Private WithEvents _grpRescalingInfor As System.Windows.Forms.GroupBox
   Private WithEvents _rbResNewSE As System.Windows.Forms.RadioButton
   Private WithEvents _rbResShift As System.Windows.Forms.RadioButton
   Private WithEvents _lblResStartPt As System.Windows.Forms.Label
   Private WithEvents _btnResApplyBitmap As System.Windows.Forms.Button
   Private WithEvents _btnNoiseApplyBitmap As System.Windows.Forms.Button
   Private WithEvents _grpNoiseFilterInfo As System.Windows.Forms.GroupBox
   Private WithEvents _lblNoiseReplaceColor As System.Windows.Forms.Label
   Private WithEvents _btnNoiseReplaceColor As System.Windows.Forms.Button
   Private WithEvents _cbNoiseReplaceWith As System.Windows.Forms.ComboBox
   Private WithEvents _lblNoiseReplaceWith As System.Windows.Forms.Label
   Private WithEvents _lblResEndPtOccVal As System.Windows.Forms.Label
   Private WithEvents _lblResEndPtOcc As System.Windows.Forms.Label
   Private WithEvents _lblResEndPtClr As System.Windows.Forms.Label
   Private WithEvents _lblNoiseStartPtOcc As System.Windows.Forms.Label
   Private WithEvents _lblNoiseStartPtClr As System.Windows.Forms.Label
   Private WithEvents _nudNoiseStartPt As System.Windows.Forms.NumericUpDown
   Private WithEvents _lblNoiseStartPt As System.Windows.Forms.Label
   Private WithEvents _btnResApplyLUT As System.Windows.Forms.Button
   Private WithEvents _grpResSelInfo As System.Windows.Forms.GroupBox
   Private WithEvents _nudResEndPt As System.Windows.Forms.NumericUpDown
   Private WithEvents _tpgRescaling As System.Windows.Forms.TabPage
   Private WithEvents _lblOuter As System.Windows.Forms.Label
   Private WithEvents _btnOuter As System.Windows.Forms.Button
   Private WithEvents _grpSelectionColor As System.Windows.Forms.GroupBox
   Private WithEvents _lblInner As System.Windows.Forms.Label
   Private WithEvents _btnInner As System.Windows.Forms.Button
   Private WithEvents _btnShowHideOptions As System.Windows.Forms.Button
   Private WithEvents _btnCancel As System.Windows.Forms.Button
   Private WithEvents _btnUndo As System.Windows.Forms.Button
   Private WithEvents _btnOk As System.Windows.Forms.Button
   Private WithEvents _MainProgressBar As System.Windows.Forms.ProgressBar
   Private WithEvents _tabOptions As System.Windows.Forms.TabControl
   Private WithEvents _tpgSegmentation As System.Windows.Forms.TabPage
   Private WithEvents _btnSegApplyLUT As System.Windows.Forms.Button
   Private WithEvents _grpSegmentationInfo As System.Windows.Forms.GroupBox
   Private WithEvents _rbSegThreshold As System.Windows.Forms.RadioButton
   Private WithEvents _rbSegGradient As System.Windows.Forms.RadioButton
   Private WithEvents _lblSegEndColor As System.Windows.Forms.Label
   Private WithEvents _btnSegEndColor As System.Windows.Forms.Button
   Private WithEvents _lblSegStartColor As System.Windows.Forms.Label
   Private WithEvents _btnSegStartColor As System.Windows.Forms.Button
   Private WithEvents _grpSegSelInfo As System.Windows.Forms.GroupBox
   Private WithEvents _lblSegEndPtOccVal As System.Windows.Forms.Label
   Private WithEvents _lblSegEndPtOcc As System.Windows.Forms.Label
   Private WithEvents _lblSegEndPtClr As System.Windows.Forms.Label
   Private WithEvents _nudSegEndPt As System.Windows.Forms.NumericUpDown
   Private WithEvents _lblSegEndPt As System.Windows.Forms.Label
   Private WithEvents _lblSegStartPtOccVal As System.Windows.Forms.Label
   Private WithEvents _lblSegStartPtOcc As System.Windows.Forms.Label
   Private WithEvents _lblSegStartPtClr As System.Windows.Forms.Label
   Private WithEvents _nudSegStartPt As System.Windows.Forms.NumericUpDown
   Private WithEvents _lblSegStartPt As System.Windows.Forms.Label
   Private WithEvents _tpgGrayDistribution As System.Windows.Forms.TabPage
   Private WithEvents _btnGrayApplyLUT As System.Windows.Forms.Button
   Private WithEvents _grpGrySelInfo As System.Windows.Forms.GroupBox
   Private WithEvents _lblGryEndPtOccVal As System.Windows.Forms.Label
   Private WithEvents _lblGryEndPtOcc As System.Windows.Forms.Label
   Private WithEvents _lblGrayEndPtClr As System.Windows.Forms.Label
   Private WithEvents _nudGrayEndPt As System.Windows.Forms.NumericUpDown
   Private WithEvents _lblGryEndPt As System.Windows.Forms.Label
   Private WithEvents _lblGryStartPtOccVal As System.Windows.Forms.Label
   Private WithEvents _lblGryStartPtOcc As System.Windows.Forms.Label
   Private WithEvents _lblGrayStartPtClr As System.Windows.Forms.Label
   Private WithEvents _nudGrayStartPt As System.Windows.Forms.NumericUpDown
   Private WithEvents _lblGryStartPt As System.Windows.Forms.Label
   Private WithEvents _btnGrayApplyToBitmap As System.Windows.Forms.Button
   Private WithEvents _grpGrayDistributionInfo As System.Windows.Forms.GroupBox
   Private WithEvents _cbGraySelectionOnly As System.Windows.Forms.CheckBox
   Private WithEvents _lblGrayEndColor As System.Windows.Forms.Label
   Private WithEvents _btnGrayEndColor As System.Windows.Forms.Button
   Private WithEvents _lblGrayStartColor As System.Windows.Forms.Label
   Private WithEvents _btnGrayStartColor As System.Windows.Forms.Button
   Private WithEvents _txtGrayWidth As System.Windows.Forms.TextBox
   Private WithEvents _lblGrayWidth As System.Windows.Forms.Label
   Private WithEvents _txtGrayCenter As System.Windows.Forms.TextBox
   Private WithEvents _lblGrayCenter As System.Windows.Forms.Label
   Private WithEvents _nudGrayFactor As System.Windows.Forms.NumericUpDown
   Private WithEvents _cbGrayFunctionType As System.Windows.Forms.ComboBox
   Private WithEvents _lblGrayFactor As System.Windows.Forms.Label
   Private WithEvents _lblGrayFunctionType As System.Windows.Forms.Label
   Private WithEvents _tpgNoiseFilter As System.Windows.Forms.TabPage
   Private WithEvents _btnNoiseApplyLUT As System.Windows.Forms.Button
   Private WithEvents _grpNoiseSelInfo As System.Windows.Forms.GroupBox
   Private WithEvents _lblNoiseEndPtOccVal As System.Windows.Forms.Label
   Private WithEvents _lblNoiseEndPtOcc As System.Windows.Forms.Label
   Private WithEvents _lblNoiseEndPtClr As System.Windows.Forms.Label
   Private WithEvents _nudNoiseEndPt As System.Windows.Forms.NumericUpDown
   Private WithEvents _lblNoiseEndPt As System.Windows.Forms.Label
   Private WithEvents _lblNoiseStartPtOccVal As System.Windows.Forms.Label
   Private WithEvents _cbChannel As System.Windows.Forms.ComboBox
   Private WithEvents _lblChannel As System.Windows.Forms.Label
   Private WithEvents _cmRightClickOptions As System.Windows.Forms.ContextMenuStrip
   Private WithEvents _cmiZoomToSelection As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _cmiFitGraph As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _cmiFullRangeView As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _lblHistogram As System.Windows.Forms.Label
   Private WithEvents _lblSelectionType As System.Windows.Forms.Label
   Private WithEvents _cbSelectionType As System.Windows.Forms.ComboBox
   Private WithEvents _grpView As System.Windows.Forms.GroupBox
   Private WithEvents _grpStatisticalInformation As System.Windows.Forms.GroupBox
   Private WithEvents _grpMouse As System.Windows.Forms.GroupBox
   Private WithEvents label1 As System.Windows.Forms.Label
   Private WithEvents _lblMouseLevel As System.Windows.Forms.Label
   Private WithEvents label2 As System.Windows.Forms.Label
   Private WithEvents _lblMousePercent As System.Windows.Forms.Label
   Private WithEvents label3 As System.Windows.Forms.Label
   Private WithEvents _lblMouseCount As System.Windows.Forms.Label
   Private WithEvents _lblStdDev As System.Windows.Forms.Label
   Private WithEvents _lblSelStdDev As System.Windows.Forms.Label
   Private WithEvents _lblMedian As System.Windows.Forms.Label
   Private WithEvents _lblSelMedian As System.Windows.Forms.Label
   Private WithEvents _lblMean As System.Windows.Forms.Label
   Private WithEvents _lblSelMean As System.Windows.Forms.Label
   Private WithEvents _lblLevel As System.Windows.Forms.Label
   Private WithEvents _lblSelLevel As System.Windows.Forms.Label
   Private WithEvents _lblPercent As System.Windows.Forms.Label
   Private WithEvents _lblSelPercent As System.Windows.Forms.Label
   Private WithEvents _lblCount As System.Windows.Forms.Label
   Private WithEvents _lblSelCount As System.Windows.Forms.Label
   Private WithEvents _btnSegApply As System.Windows.Forms.Button
   Private WithEvents _lblHelp As System.Windows.Forms.Label
   Private WithEvents _chkResApplyInProgress As System.Windows.Forms.CheckBox
   Private WithEvents _chkSegApplyInProgress As System.Windows.Forms.CheckBox
   Private WithEvents _chkGrayApplyInProgress As System.Windows.Forms.CheckBox
   Private WithEvents _chkNoiseApplyInProgress As System.Windows.Forms.CheckBox
End Class
