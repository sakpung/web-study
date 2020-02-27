' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Leadtools.Twain

Public Class Template
   Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

   Public Sub New()
      MyBase.New()

      'This call is required by the Windows Form Designer.
      InitializeComponent()

      'Add any initialization after the InitializeComponent() call

   End Sub

   'Form overrides dispose to clean up the component list.
   Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
      If disposing Then
         If Not (components Is Nothing) Then
            components.Dispose()
         End If
      End If
      MyBase.Dispose(disposing)
   End Sub

   'Required by the Windows Form Designer
   Private components As System.ComponentModel.IContainer

   'NOTE: The following procedure is required by the Windows Form Designer
   'It can be modified using the Windows Form Designer.  
   'Do not modify it using the code editor.
   Friend WithEvents _btnOK As System.Windows.Forms.Button
   Friend WithEvents _btnCancel As System.Windows.Forms.Button
   Friend WithEvents _gbImgeEfx As System.Windows.Forms.GroupBox
   Friend WithEvents _cmbHighlight As System.Windows.Forms.ComboBox
   Friend WithEvents _lblHighlight As System.Windows.Forms.Label
   Friend WithEvents _cmbBrightness As System.Windows.Forms.ComboBox
   Friend WithEvents _lblBrightness As System.Windows.Forms.Label
   Friend WithEvents _cmbContrast As System.Windows.Forms.ComboBox
   Friend WithEvents _lblContrast As System.Windows.Forms.Label
   Friend WithEvents _cmbHalftone As System.Windows.Forms.ComboBox
   Friend WithEvents _lblHalftone As System.Windows.Forms.Label
   Friend WithEvents _cmbOrientation As System.Windows.Forms.ComboBox
   Friend WithEvents _lblOrientation As System.Windows.Forms.Label
   Friend WithEvents _cmbPixelType As System.Windows.Forms.ComboBox
   Friend WithEvents _lblPixelType As System.Windows.Forms.Label
   Friend WithEvents _gbMemoryOptions As System.Windows.Forms.GroupBox
   Friend WithEvents _cmbCompression As System.Windows.Forms.ComboBox
   Friend WithEvents _lblCompression As System.Windows.Forms.Label
   Friend WithEvents _gbImageFrame As System.Windows.Forms.GroupBox
   Friend WithEvents _cmbYRes As System.Windows.Forms.ComboBox
   Friend WithEvents _cmbXRes As System.Windows.Forms.ComboBox
   Friend WithEvents _lblYRes As System.Windows.Forms.Label
   Friend WithEvents _lblXRes As System.Windows.Forms.Label
   Friend WithEvents _txtFrameBottom As System.Windows.Forms.TextBox
   Friend WithEvents _txtFrameRight As System.Windows.Forms.TextBox
   Friend WithEvents _txtFrameTop As System.Windows.Forms.TextBox
   Friend WithEvents _txtFrameLeft As System.Windows.Forms.TextBox
   Friend WithEvents _lblFrameBottom As System.Windows.Forms.Label
   Friend WithEvents _lblFrameRight As System.Windows.Forms.Label
   Friend WithEvents _lblFrameTop As System.Windows.Forms.Label
   Friend WithEvents _lblFrameLeft As System.Windows.Forms.Label
   Friend WithEvents _cmbUnit As System.Windows.Forms.ComboBox
   Friend WithEvents _lblUnit As System.Windows.Forms.Label
   Friend WithEvents _btnLoad As System.Windows.Forms.Button
   Friend WithEvents _btnSave As System.Windows.Forms.Button
   Friend WithEvents _gbTransferMode As System.Windows.Forms.GroupBox
   Friend WithEvents _rdNative As System.Windows.Forms.RadioButton
   Friend WithEvents _rdMemory As System.Windows.Forms.RadioButton
   Friend WithEvents _rdFile As System.Windows.Forms.RadioButton
   Friend WithEvents _gbFileOptions As System.Windows.Forms.GroupBox
   Friend WithEvents _cmbFileFormat As System.Windows.Forms.ComboBox
   Friend WithEvents _lblFormat As System.Windows.Forms.Label
   Friend WithEvents _btnBrowse As System.Windows.Forms.Button
   Friend WithEvents _txtFileName As System.Windows.Forms.TextBox
   Friend WithEvents _lblFileName As System.Windows.Forms.Label
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Template))
      Me._btnOK = New System.Windows.Forms.Button
      Me._btnCancel = New System.Windows.Forms.Button
      Me._gbImgeEfx = New System.Windows.Forms.GroupBox
      Me._cmbHighlight = New System.Windows.Forms.ComboBox
      Me._lblHighlight = New System.Windows.Forms.Label
      Me._cmbBrightness = New System.Windows.Forms.ComboBox
      Me._lblBrightness = New System.Windows.Forms.Label
      Me._cmbContrast = New System.Windows.Forms.ComboBox
      Me._lblContrast = New System.Windows.Forms.Label
      Me._cmbHalftone = New System.Windows.Forms.ComboBox
      Me._lblHalftone = New System.Windows.Forms.Label
      Me._cmbOrientation = New System.Windows.Forms.ComboBox
      Me._lblOrientation = New System.Windows.Forms.Label
      Me._cmbPixelType = New System.Windows.Forms.ComboBox
      Me._lblPixelType = New System.Windows.Forms.Label
      Me._gbMemoryOptions = New System.Windows.Forms.GroupBox
      Me._cmbCompression = New System.Windows.Forms.ComboBox
      Me._lblCompression = New System.Windows.Forms.Label
      Me._gbImageFrame = New System.Windows.Forms.GroupBox
      Me._cmbYRes = New System.Windows.Forms.ComboBox
      Me._cmbXRes = New System.Windows.Forms.ComboBox
      Me._lblYRes = New System.Windows.Forms.Label
      Me._lblXRes = New System.Windows.Forms.Label
      Me._txtFrameBottom = New System.Windows.Forms.TextBox
      Me._txtFrameRight = New System.Windows.Forms.TextBox
      Me._txtFrameTop = New System.Windows.Forms.TextBox
      Me._txtFrameLeft = New System.Windows.Forms.TextBox
      Me._lblFrameBottom = New System.Windows.Forms.Label
      Me._lblFrameRight = New System.Windows.Forms.Label
      Me._lblFrameTop = New System.Windows.Forms.Label
      Me._lblFrameLeft = New System.Windows.Forms.Label
      Me._cmbUnit = New System.Windows.Forms.ComboBox
      Me._lblUnit = New System.Windows.Forms.Label
      Me._btnLoad = New System.Windows.Forms.Button
      Me._btnSave = New System.Windows.Forms.Button
      Me._gbTransferMode = New System.Windows.Forms.GroupBox
      Me._rdNative = New System.Windows.Forms.RadioButton
      Me._rdMemory = New System.Windows.Forms.RadioButton
      Me._rdFile = New System.Windows.Forms.RadioButton
      Me._gbFileOptions = New System.Windows.Forms.GroupBox
      Me._cmbFileFormat = New System.Windows.Forms.ComboBox
      Me._lblFormat = New System.Windows.Forms.Label
      Me._btnBrowse = New System.Windows.Forms.Button
      Me._txtFileName = New System.Windows.Forms.TextBox
      Me._lblFileName = New System.Windows.Forms.Label
      Me._gbImgeEfx.SuspendLayout()
      Me._gbMemoryOptions.SuspendLayout()
      Me._gbImageFrame.SuspendLayout()
      Me._gbTransferMode.SuspendLayout()
      Me._gbFileOptions.SuspendLayout()
      Me.SuspendLayout()
      '
      '_btnOK
      '
      Me._btnOK.Location = New System.Drawing.Point(328, 256)
      Me._btnOK.Name = "_btnOK"
      Me._btnOK.Size = New System.Drawing.Size(75, 23)
      Me._btnOK.TabIndex = 16
      Me._btnOK.Text = "OK"
      '
      '_btnCancel
      '
      Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me._btnCancel.Location = New System.Drawing.Point(408, 256)
      Me._btnCancel.Name = "_btnCancel"
      Me._btnCancel.Size = New System.Drawing.Size(75, 23)
      Me._btnCancel.TabIndex = 17
      Me._btnCancel.Text = "Cancel"
      '
      '_gbImgeEfx
      '
      Me._gbImgeEfx.Controls.Add(Me._cmbHighlight)
      Me._gbImgeEfx.Controls.Add(Me._lblHighlight)
      Me._gbImgeEfx.Controls.Add(Me._cmbBrightness)
      Me._gbImgeEfx.Controls.Add(Me._lblBrightness)
      Me._gbImgeEfx.Controls.Add(Me._cmbContrast)
      Me._gbImgeEfx.Controls.Add(Me._lblContrast)
      Me._gbImgeEfx.Controls.Add(Me._cmbHalftone)
      Me._gbImgeEfx.Controls.Add(Me._lblHalftone)
      Me._gbImgeEfx.Controls.Add(Me._cmbOrientation)
      Me._gbImgeEfx.Controls.Add(Me._lblOrientation)
      Me._gbImgeEfx.Controls.Add(Me._cmbPixelType)
      Me._gbImgeEfx.Controls.Add(Me._lblPixelType)
      Me._gbImgeEfx.Location = New System.Drawing.Point(432, 8)
      Me._gbImgeEfx.Name = "_gbImgeEfx"
      Me._gbImgeEfx.Size = New System.Drawing.Size(208, 240)
      Me._gbImgeEfx.TabIndex = 13
      Me._gbImgeEfx.TabStop = False
      Me._gbImgeEfx.Text = "Image Effects"
      '
      '_cmbHighlight
      '
      Me._cmbHighlight.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me._cmbHighlight.Location = New System.Drawing.Point(72, 192)
      Me._cmbHighlight.Name = "_cmbHighlight"
      Me._cmbHighlight.Size = New System.Drawing.Size(121, 21)
      Me._cmbHighlight.TabIndex = 11
      '
      '_lblHighlight
      '
      Me._lblHighlight.Location = New System.Drawing.Point(8, 192)
      Me._lblHighlight.Name = "_lblHighlight"
      Me._lblHighlight.Size = New System.Drawing.Size(56, 23)
      Me._lblHighlight.TabIndex = 10
      Me._lblHighlight.Text = "Highlight:"
      '
      '_cmbBrightness
      '
      Me._cmbBrightness.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me._cmbBrightness.Location = New System.Drawing.Point(72, 160)
      Me._cmbBrightness.Name = "_cmbBrightness"
      Me._cmbBrightness.Size = New System.Drawing.Size(121, 21)
      Me._cmbBrightness.TabIndex = 9
      '
      '_lblBrightness
      '
      Me._lblBrightness.Location = New System.Drawing.Point(8, 160)
      Me._lblBrightness.Name = "_lblBrightness"
      Me._lblBrightness.Size = New System.Drawing.Size(64, 23)
      Me._lblBrightness.TabIndex = 8
      Me._lblBrightness.Text = "Brightness:"
      '
      '_cmbContrast
      '
      Me._cmbContrast.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me._cmbContrast.Location = New System.Drawing.Point(72, 128)
      Me._cmbContrast.Name = "_cmbContrast"
      Me._cmbContrast.Size = New System.Drawing.Size(121, 21)
      Me._cmbContrast.TabIndex = 7
      '
      '_lblContrast
      '
      Me._lblContrast.Location = New System.Drawing.Point(8, 128)
      Me._lblContrast.Name = "_lblContrast"
      Me._lblContrast.Size = New System.Drawing.Size(56, 23)
      Me._lblContrast.TabIndex = 6
      Me._lblContrast.Text = "Contrast:"
      '
      '_cmbHalftone
      '
      Me._cmbHalftone.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me._cmbHalftone.Location = New System.Drawing.Point(72, 96)
      Me._cmbHalftone.Name = "_cmbHalftone"
      Me._cmbHalftone.Size = New System.Drawing.Size(121, 21)
      Me._cmbHalftone.TabIndex = 5
      '
      '_lblHalftone
      '
      Me._lblHalftone.Location = New System.Drawing.Point(8, 96)
      Me._lblHalftone.Name = "_lblHalftone"
      Me._lblHalftone.Size = New System.Drawing.Size(56, 23)
      Me._lblHalftone.TabIndex = 4
      Me._lblHalftone.Text = "Halftone:"
      '
      '_cmbOrientation
      '
      Me._cmbOrientation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me._cmbOrientation.Location = New System.Drawing.Point(72, 64)
      Me._cmbOrientation.Name = "_cmbOrientation"
      Me._cmbOrientation.Size = New System.Drawing.Size(121, 21)
      Me._cmbOrientation.TabIndex = 3
      '
      '_lblOrientation
      '
      Me._lblOrientation.Location = New System.Drawing.Point(8, 64)
      Me._lblOrientation.Name = "_lblOrientation"
      Me._lblOrientation.Size = New System.Drawing.Size(64, 23)
      Me._lblOrientation.TabIndex = 2
      Me._lblOrientation.Text = "Orientation:"
      '
      '_cmbPixelType
      '
      Me._cmbPixelType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me._cmbPixelType.Location = New System.Drawing.Point(72, 32)
      Me._cmbPixelType.Name = "_cmbPixelType"
      Me._cmbPixelType.Size = New System.Drawing.Size(121, 21)
      Me._cmbPixelType.TabIndex = 1
      '
      '_lblPixelType
      '
      Me._lblPixelType.Location = New System.Drawing.Point(8, 32)
      Me._lblPixelType.Name = "_lblPixelType"
      Me._lblPixelType.Size = New System.Drawing.Size(64, 23)
      Me._lblPixelType.TabIndex = 0
      Me._lblPixelType.Text = "Pixel Type:"
      '
      '_gbMemoryOptions
      '
      Me._gbMemoryOptions.Controls.Add(Me._cmbCompression)
      Me._gbMemoryOptions.Controls.Add(Me._lblCompression)
      Me._gbMemoryOptions.Location = New System.Drawing.Point(200, 184)
      Me._gbMemoryOptions.Name = "_gbMemoryOptions"
      Me._gbMemoryOptions.Size = New System.Drawing.Size(224, 64)
      Me._gbMemoryOptions.TabIndex = 12
      Me._gbMemoryOptions.TabStop = False
      Me._gbMemoryOptions.Text = "Memory Mode Options"
      '
      '_cmbCompression
      '
      Me._cmbCompression.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me._cmbCompression.Location = New System.Drawing.Point(88, 24)
      Me._cmbCompression.Name = "_cmbCompression"
      Me._cmbCompression.Size = New System.Drawing.Size(121, 21)
      Me._cmbCompression.TabIndex = 1
      '
      '_lblCompression
      '
      Me._lblCompression.Location = New System.Drawing.Point(8, 24)
      Me._lblCompression.Name = "_lblCompression"
      Me._lblCompression.Size = New System.Drawing.Size(80, 16)
      Me._lblCompression.TabIndex = 0
      Me._lblCompression.Text = "Compression:"
      '
      '_gbImageFrame
      '
      Me._gbImageFrame.Controls.Add(Me._cmbYRes)
      Me._gbImageFrame.Controls.Add(Me._cmbXRes)
      Me._gbImageFrame.Controls.Add(Me._lblYRes)
      Me._gbImageFrame.Controls.Add(Me._lblXRes)
      Me._gbImageFrame.Controls.Add(Me._txtFrameBottom)
      Me._gbImageFrame.Controls.Add(Me._txtFrameRight)
      Me._gbImageFrame.Controls.Add(Me._txtFrameTop)
      Me._gbImageFrame.Controls.Add(Me._txtFrameLeft)
      Me._gbImageFrame.Controls.Add(Me._lblFrameBottom)
      Me._gbImageFrame.Controls.Add(Me._lblFrameRight)
      Me._gbImageFrame.Controls.Add(Me._lblFrameTop)
      Me._gbImageFrame.Controls.Add(Me._lblFrameLeft)
      Me._gbImageFrame.Controls.Add(Me._cmbUnit)
      Me._gbImageFrame.Controls.Add(Me._lblUnit)
      Me._gbImageFrame.Location = New System.Drawing.Point(8, 8)
      Me._gbImageFrame.Name = "_gbImageFrame"
      Me._gbImageFrame.Size = New System.Drawing.Size(184, 240)
      Me._gbImageFrame.TabIndex = 9
      Me._gbImageFrame.TabStop = False
      Me._gbImageFrame.Text = "Image Frame"
      '
      '_cmbYRes
      '
      Me._cmbYRes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me._cmbYRes.Location = New System.Drawing.Point(72, 208)
      Me._cmbYRes.Name = "_cmbYRes"
      Me._cmbYRes.Size = New System.Drawing.Size(100, 21)
      Me._cmbYRes.TabIndex = 15
      '
      '_cmbXRes
      '
      Me._cmbXRes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me._cmbXRes.Location = New System.Drawing.Point(72, 176)
      Me._cmbXRes.Name = "_cmbXRes"
      Me._cmbXRes.Size = New System.Drawing.Size(100, 21)
      Me._cmbXRes.TabIndex = 14
      '
      '_lblYRes
      '
      Me._lblYRes.Location = New System.Drawing.Point(8, 208)
      Me._lblYRes.Name = "_lblYRes"
      Me._lblYRes.Size = New System.Drawing.Size(72, 23)
      Me._lblYRes.TabIndex = 13
      Me._lblYRes.Text = "YResolution:"
      '
      '_lblXRes
      '
      Me._lblXRes.Location = New System.Drawing.Point(8, 176)
      Me._lblXRes.Name = "_lblXRes"
      Me._lblXRes.Size = New System.Drawing.Size(72, 23)
      Me._lblXRes.TabIndex = 11
      Me._lblXRes.Text = "XResolution:"
      '
      '_txtFrameBottom
      '
      Me._txtFrameBottom.Location = New System.Drawing.Point(72, 144)
      Me._txtFrameBottom.Name = "_txtFrameBottom"
      Me._txtFrameBottom.Size = New System.Drawing.Size(100, 20)
      Me._txtFrameBottom.TabIndex = 10
      '
      '_txtFrameRight
      '
      Me._txtFrameRight.Location = New System.Drawing.Point(72, 112)
      Me._txtFrameRight.Name = "_txtFrameRight"
      Me._txtFrameRight.Size = New System.Drawing.Size(100, 20)
      Me._txtFrameRight.TabIndex = 8
      '
      '_txtFrameTop
      '
      Me._txtFrameTop.Location = New System.Drawing.Point(72, 80)
      Me._txtFrameTop.Name = "_txtFrameTop"
      Me._txtFrameTop.Size = New System.Drawing.Size(100, 20)
      Me._txtFrameTop.TabIndex = 6
      '
      '_txtFrameLeft
      '
      Me._txtFrameLeft.Location = New System.Drawing.Point(72, 48)
      Me._txtFrameLeft.Name = "_txtFrameLeft"
      Me._txtFrameLeft.Size = New System.Drawing.Size(100, 20)
      Me._txtFrameLeft.TabIndex = 4
      '
      '_lblFrameBottom
      '
      Me._lblFrameBottom.Location = New System.Drawing.Point(8, 144)
      Me._lblFrameBottom.Name = "_lblFrameBottom"
      Me._lblFrameBottom.Size = New System.Drawing.Size(48, 23)
      Me._lblFrameBottom.TabIndex = 9
      Me._lblFrameBottom.Text = "Bottom:"
      '
      '_lblFrameRight
      '
      Me._lblFrameRight.Location = New System.Drawing.Point(8, 112)
      Me._lblFrameRight.Name = "_lblFrameRight"
      Me._lblFrameRight.Size = New System.Drawing.Size(40, 23)
      Me._lblFrameRight.TabIndex = 7
      Me._lblFrameRight.Text = "Right:"
      '
      '_lblFrameTop
      '
      Me._lblFrameTop.Location = New System.Drawing.Point(8, 80)
      Me._lblFrameTop.Name = "_lblFrameTop"
      Me._lblFrameTop.Size = New System.Drawing.Size(40, 23)
      Me._lblFrameTop.TabIndex = 5
      Me._lblFrameTop.Text = "Top:"
      '
      '_lblFrameLeft
      '
      Me._lblFrameLeft.Location = New System.Drawing.Point(8, 48)
      Me._lblFrameLeft.Name = "_lblFrameLeft"
      Me._lblFrameLeft.Size = New System.Drawing.Size(32, 23)
      Me._lblFrameLeft.TabIndex = 3
      Me._lblFrameLeft.Text = "Left:"
      '
      '_cmbUnit
      '
      Me._cmbUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me._cmbUnit.Location = New System.Drawing.Point(72, 16)
      Me._cmbUnit.Name = "_cmbUnit"
      Me._cmbUnit.Size = New System.Drawing.Size(100, 21)
      Me._cmbUnit.TabIndex = 2
      '
      '_lblUnit
      '
      Me._lblUnit.Location = New System.Drawing.Point(8, 16)
      Me._lblUnit.Name = "_lblUnit"
      Me._lblUnit.Size = New System.Drawing.Size(32, 23)
      Me._lblUnit.TabIndex = 1
      Me._lblUnit.Text = "Unit:"
      '
      '_btnLoad
      '
      Me._btnLoad.Location = New System.Drawing.Point(168, 256)
      Me._btnLoad.Name = "_btnLoad"
      Me._btnLoad.Size = New System.Drawing.Size(75, 23)
      Me._btnLoad.TabIndex = 14
      Me._btnLoad.Text = "Load"
      '
      '_btnSave
      '
      Me._btnSave.Location = New System.Drawing.Point(248, 256)
      Me._btnSave.Name = "_btnSave"
      Me._btnSave.Size = New System.Drawing.Size(75, 23)
      Me._btnSave.TabIndex = 15
      Me._btnSave.Text = "Save"
      '
      '_gbTransferMode
      '
      Me._gbTransferMode.Controls.Add(Me._rdNative)
      Me._gbTransferMode.Controls.Add(Me._rdMemory)
      Me._gbTransferMode.Controls.Add(Me._rdFile)
      Me._gbTransferMode.Location = New System.Drawing.Point(200, 8)
      Me._gbTransferMode.Name = "_gbTransferMode"
      Me._gbTransferMode.Size = New System.Drawing.Size(224, 64)
      Me._gbTransferMode.TabIndex = 10
      Me._gbTransferMode.TabStop = False
      Me._gbTransferMode.Text = "Transfer Mode"
      '
      '_rdNative
      '
      Me._rdNative.Location = New System.Drawing.Point(160, 24)
      Me._rdNative.Name = "_rdNative"
      Me._rdNative.Size = New System.Drawing.Size(56, 24)
      Me._rdNative.TabIndex = 2
      Me._rdNative.Text = "Native"
      '
      '_rdMemory
      '
      Me._rdMemory.Location = New System.Drawing.Point(72, 24)
      Me._rdMemory.Name = "_rdMemory"
      Me._rdMemory.Size = New System.Drawing.Size(64, 24)
      Me._rdMemory.TabIndex = 1
      Me._rdMemory.Text = "Memory"
      '
      '_rdFile
      '
      Me._rdFile.Location = New System.Drawing.Point(8, 24)
      Me._rdFile.Name = "_rdFile"
      Me._rdFile.Size = New System.Drawing.Size(48, 24)
      Me._rdFile.TabIndex = 0
      Me._rdFile.Text = "File"
      '
      '_gbFileOptions
      '
      Me._gbFileOptions.Controls.Add(Me._cmbFileFormat)
      Me._gbFileOptions.Controls.Add(Me._lblFormat)
      Me._gbFileOptions.Controls.Add(Me._btnBrowse)
      Me._gbFileOptions.Controls.Add(Me._txtFileName)
      Me._gbFileOptions.Controls.Add(Me._lblFileName)
      Me._gbFileOptions.Location = New System.Drawing.Point(200, 80)
      Me._gbFileOptions.Name = "_gbFileOptions"
      Me._gbFileOptions.Size = New System.Drawing.Size(224, 96)
      Me._gbFileOptions.TabIndex = 11
      Me._gbFileOptions.TabStop = False
      Me._gbFileOptions.Text = "File Mode Options"
      '
      '_cmbFileFormat
      '
      Me._cmbFileFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me._cmbFileFormat.Location = New System.Drawing.Point(64, 64)
      Me._cmbFileFormat.Name = "_cmbFileFormat"
      Me._cmbFileFormat.Size = New System.Drawing.Size(152, 21)
      Me._cmbFileFormat.TabIndex = 4
      '
      '_lblFormat
      '
      Me._lblFormat.Location = New System.Drawing.Point(8, 64)
      Me._lblFormat.Name = "_lblFormat"
      Me._lblFormat.Size = New System.Drawing.Size(48, 23)
      Me._lblFormat.TabIndex = 3
      Me._lblFormat.Text = "Format:"
      '
      '_btnBrowse
      '
      Me._btnBrowse.Location = New System.Drawing.Point(184, 32)
      Me._btnBrowse.Name = "_btnBrowse"
      Me._btnBrowse.Size = New System.Drawing.Size(32, 23)
      Me._btnBrowse.TabIndex = 2
      Me._btnBrowse.Text = "..."
      '
      '_txtFileName
      '
      Me._txtFileName.Location = New System.Drawing.Point(64, 32)
      Me._txtFileName.Name = "_txtFileName"
      Me._txtFileName.Size = New System.Drawing.Size(112, 20)
      Me._txtFileName.TabIndex = 1
      '
      '_lblFileName
      '
      Me._lblFileName.Location = New System.Drawing.Point(8, 32)
      Me._lblFileName.Name = "_lblFileName"
      Me._lblFileName.Size = New System.Drawing.Size(64, 23)
      Me._lblFileName.TabIndex = 0
      Me._lblFileName.Text = "File Name:"
      '
      'Template
      '
      Me.AcceptButton = Me._btnOK
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.CancelButton = Me._btnCancel
      Me.ClientSize = New System.Drawing.Size(650, 288)
      Me.Controls.Add(Me._btnOK)
      Me.Controls.Add(Me._btnCancel)
      Me.Controls.Add(Me._gbImgeEfx)
      Me.Controls.Add(Me._gbMemoryOptions)
      Me.Controls.Add(Me._gbImageFrame)
      Me.Controls.Add(Me._btnLoad)
      Me.Controls.Add(Me._btnSave)
      Me.Controls.Add(Me._gbTransferMode)
      Me.Controls.Add(Me._gbFileOptions)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "Template"
      Me.Text = "LEAD Template"
      Me._gbImgeEfx.ResumeLayout(False)
      Me._gbMemoryOptions.ResumeLayout(False)
      Me._gbImageFrame.ResumeLayout(False)
      Me._gbImageFrame.PerformLayout()
      Me._gbTransferMode.ResumeLayout(False)
      Me._gbFileOptions.ResumeLayout(False)
      Me._gbFileOptions.PerformLayout()
      Me.ResumeLayout(False)

   End Sub

#End Region
   Public WithEvents _twainSession As TwainSession
   Public _transferMode As TwainTransferMechanism = TwainTransferMechanism.Native
   Private _unitsValue As TwainCapabilityValue()
   Private _pixelValue As TwainCapabilityValue()
   Private _orientationValue As TwainCapabilityValue()
   Private _compressionValue As TwainCapabilityValue()
   Private _formatValue As TwainFileFormat()
   Private _selectedUnitsIndex As Int32

   Private Sub Template_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      InitializeTemplate()
   End Sub

   Private Sub InitializeTemplate()
      ReDim _unitsValue(6)
      ReDim _pixelValue(9)
      ReDim _orientationValue(4)
      ReDim _compressionValue(14)
      ReDim _formatValue(10)

      FillUnitsCap()
      FillFrameCaps()
      FillXYRes()
      FillTransferMode()
      FillPixelType()
      FillOrientation()
      FillEffectsCap(TwainCapabilityType.ImageContrast)
      FillEffectsCap(TwainCapabilityType.ImageBrightness)
      FillEffectsCap(TwainCapabilityType.ImageHighlight)
      FillHalftones()
   End Sub

   Private Sub FillUnitsCap()
      Dim twnCap As TwainCapability = New TwainCapability

      ' ICAP_UNITS
      _cmbUnit.Items.Clear()

      Try
         twnCap = _twainSession.GetCapability(TwainCapabilityType.ImageUnits, TwainGetCapabilityMode.GetValues)
         _cmbUnit.Enabled = True

         Select Case twnCap.Information.ContainerType
            Case TwainContainerType.OneValue
               Dim item As Object = twnCap.OneValueCapability.Value
               Dim itemValue As TwainCapabilityValue = CType(item, TwainCapabilityValue)
               Select Case itemValue
                  Case TwainCapabilityValue.UnitCentimeters
                     _cmbUnit.Items.Add("Centimeters")
                  Case TwainCapabilityValue.UnitInches
                     _cmbUnit.Items.Add("Inches")
                  Case TwainCapabilityValue.UnitPicas
                     _cmbUnit.Items.Add("Picas")
                  Case TwainCapabilityValue.UnitPixels
                     _cmbUnit.Items.Add("Pixels")
                  Case TwainCapabilityValue.UnitPoints
                     _cmbUnit.Items.Add("Points")
                  Case TwainCapabilityValue.UnitTwips
                     _cmbUnit.Items.Add("Twips")
               End Select

               _unitsValue(0) = itemValue
               _cmbUnit.SelectedIndex = 0
            Case TwainContainerType.Enumeration
               Dim itemsCount As Integer = twnCap.EnumerationCapability.Count
               Dim i As Integer
               For i = 0 To itemsCount - 1
                  Dim item As Object = twnCap.EnumerationCapability.GetValue(i)
                  Dim itemValue As TwainCapabilityValue = CType(item, TwainCapabilityValue)
                  Select Case itemValue
                     Case TwainCapabilityValue.UnitCentimeters
                        _cmbUnit.Items.Add("Centimeters")
                     Case TwainCapabilityValue.UnitInches
                        _cmbUnit.Items.Add("Inches")
                     Case TwainCapabilityValue.UnitPicas
                        _cmbUnit.Items.Add("Picas")
                     Case TwainCapabilityValue.UnitPixels
                        _cmbUnit.Items.Add("Pixels")
                     Case TwainCapabilityValue.UnitPoints
                        _cmbUnit.Items.Add("Points")
                     Case TwainCapabilityValue.UnitTwips
                        _cmbUnit.Items.Add("Twips")
                  End Select

                  _unitsValue(i) = itemValue
               Next

               _cmbUnit.SelectedIndex = twnCap.EnumerationCapability.CurrentIndex
         End Select

         _selectedUnitsIndex = _cmbUnit.SelectedIndex
      Catch ex As Exception
         Dim errorMsg As String = String.Format("Get TwainCapabilityType.ImageUnits returns {0}", ex.Message)
         AddErrorToErrorList(errorMsg)
         _cmbUnit.Enabled = False
      End Try
   End Sub

   Private Sub FillFrameCaps()
      Dim twnCap As TwainCapability = New TwainCapability

      ' ICAP_FRAMES
      _txtFrameLeft.Text = ""
      _txtFrameTop.Text = ""
      _txtFrameRight.Text = ""
      _txtFrameBottom.Text = ""

      Try
         twnCap = _twainSession.GetCapability(TwainCapabilityType.ImageFrames, TwainGetCapabilityMode.GetValues)

         _txtFrameLeft.Enabled = True
         _txtFrameTop.Enabled = True
         _txtFrameRight.Enabled = True
         _txtFrameBottom.Enabled = True

         Dim twnFrame As TwainFrame = New TwainFrame
         Select Case twnCap.Information.ContainerType
            Case TwainContainerType.OneValue
               Dim item As Object = twnCap.OneValueCapability.Value
               twnFrame = CType(item, TwainFrame)
            Case TwainContainerType.Enumeration
               Dim item As Object = twnCap.EnumerationCapability.GetValue(twnCap.EnumerationCapability.CurrentIndex)
               twnFrame = CType(item, TwainFrame)
         End Select

         _txtFrameLeft.Text = twnFrame.LeftMargin.ToString()
         _txtFrameTop.Text = twnFrame.TopMargin.ToString()
         _txtFrameRight.Text = twnFrame.RightMargin.ToString()
         _txtFrameBottom.Text = twnFrame.BottomMargin.ToString()
      Catch ex As Exception
         Dim errorMsg As String = String.Format("Get TwainCapabilityType.ImageFrames returns {0}", ex.Message)
         AddErrorToErrorList(errorMsg)

         _txtFrameLeft.Enabled = False
         _txtFrameTop.Enabled = False
         _txtFrameRight.Enabled = False
         _txtFrameBottom.Enabled = False
      End Try
   End Sub

   Private Sub FillXYRes()
      Dim twnCap As TwainCapability = New TwainCapability

      ' ICAP_XRESOLUTION and ICAP_YRESOLUTION
      _cmbXRes.Items.Clear()
      _cmbYRes.Items.Clear()

      ' ICAP_XRESOLUTION
      Try
         twnCap = _twainSession.GetCapability(TwainCapabilityType.ImageXResolution, TwainGetCapabilityMode.GetValues)
         _cmbXRes.Enabled = True

         Select Case twnCap.Information.ContainerType
            Case TwainContainerType.OneValue
               Dim item As Object = twnCap.OneValueCapability.Value
               Dim fix32Value As Double = CType(item, Double)
               _cmbXRes.Items.Add(fix32Value.ToString())

               _cmbXRes.SelectedIndex = 0
            Case TwainContainerType.Enumeration
               Dim item As Object
               Dim fix32Value As Double

               Dim itemsCount As Integer = twnCap.EnumerationCapability.Count
               Dim i As Integer
               For i = 0 To itemsCount - 1
                  item = twnCap.EnumerationCapability.GetValue(i)
                  fix32Value = CType(item, Double)
                  _cmbXRes.Items.Add(fix32Value.ToString())
               Next

               _cmbXRes.SelectedIndex = twnCap.EnumerationCapability.CurrentIndex
            Case TwainContainerType.Range
               Dim minValue As Double = CType(twnCap.RangeCapability.MinimumValue, Double)
               Dim maxValue As Double = CType(twnCap.RangeCapability.MaximumValue, Double)
               Dim stepSize As Double = CType(twnCap.RangeCapability.StepSize, Double)
               Dim currentValue As Double = CType(twnCap.RangeCapability.CurrentValue, Double)

               Dim i As Integer
               Dim selIndex As Integer = 0

               _cmbXRes.Items.Add(minValue.ToString())
               If minValue = currentValue Then
                  selIndex = i
               End If

               Dim tempValue As Double = minValue + stepSize
               While tempValue <= maxValue
                  i = i + 1
                  _cmbXRes.Items.Add(tempValue.ToString())
                  If tempValue = currentValue Then
                     selIndex = i
                  End If

                  tempValue = tempValue + stepSize
               End While

               _cmbXRes.SelectedIndex = selIndex
         End Select
      Catch ex As Exception
         Dim errorMsg As String = String.Format("Get TwainCapabilityType.ImageXResolution returns {0}", ex.Message)
         AddErrorToErrorList(errorMsg)

         _cmbXRes.Enabled = False
      End Try

      ' ICAP_YRESOLUTION
      Try
         twnCap = _twainSession.GetCapability(TwainCapabilityType.ImageYResolution, TwainGetCapabilityMode.GetValues)
         _cmbYRes.Enabled = True

         Select Case twnCap.Information.ContainerType
            Case TwainContainerType.OneValue
               Dim item As Object = twnCap.OneValueCapability.Value
               Dim fix32Value As Double = CType(item, Double)
               _cmbYRes.Items.Add(fix32Value.ToString())

               _cmbYRes.SelectedIndex = 0
            Case TwainContainerType.Enumeration
               Dim item As Object
               Dim fix32Value As Double

               Dim itemsCount As Integer = twnCap.EnumerationCapability.Count
               Dim i As Integer
               For i = 0 To itemsCount - 1
                  item = twnCap.EnumerationCapability.GetValue(i)
                  fix32Value = CType(item, Double)
                  _cmbYRes.Items.Add(fix32Value.ToString())
               Next

               _cmbYRes.SelectedIndex = twnCap.EnumerationCapability.CurrentIndex
            Case TwainContainerType.Range
               Dim minValue As Double = CType(twnCap.RangeCapability.MinimumValue, Double)
               Dim maxValue As Double = CType(twnCap.RangeCapability.MaximumValue, Double)
               Dim stepSize As Double = CType(twnCap.RangeCapability.StepSize, Double)
               Dim currentValue As Double = CType(twnCap.RangeCapability.CurrentValue, Double)

               Dim i As Integer
               Dim selIndex As Integer = 0

               _cmbYRes.Items.Add(minValue.ToString())
               If minValue = currentValue Then
                  selIndex = i
               End If

               Dim tempValue As Double = minValue + stepSize
               While tempValue <= maxValue
                  i = i + 1
                  _cmbYRes.Items.Add(tempValue.ToString())
                  If tempValue = currentValue Then
                     selIndex = i
                  End If

                  tempValue = tempValue + stepSize
               End While

               _cmbYRes.SelectedIndex = selIndex
         End Select
      Catch ex As Exception
         Dim errorMsg As String = String.Format("Get TwainCapabilityType.ImageXResolution returns {0}", ex.Message)
         AddErrorToErrorList(errorMsg)

         _cmbYRes.Enabled = False
      End Try
   End Sub

   Private Sub FillTransferMode()
      Dim twnCap As TwainCapability = New TwainCapability
      Dim fileMode, nativeMode, memoryMode As Boolean

      _rdFile.Checked = False
      _rdMemory.Checked = False
      _rdNative.Checked = False
      fileMode = nativeMode = memoryMode = False

      ' ICAP_XFERMECH
      Try
         twnCap = _twainSession.GetCapability(TwainCapabilityType.ImageTransferMechanism, TwainGetCapabilityMode.GetValues)

         Select Case twnCap.Information.ContainerType
            Case TwainContainerType.OneValue
               Dim item As Object = twnCap.OneValueCapability.Value
               Dim itemValue As TwainCapabilityValue = CType(item, TwainCapabilityValue)
               Select Case itemValue
                  Case TwainCapabilityValue.TransferMechanismFile
                     _rdFile.Enabled = True
                     fileMode = True
                  Case TwainCapabilityValue.TransferMechanismMemory
                     _rdMemory.Enabled = True
                     memoryMode = True
                  Case TwainCapabilityValue.TransferMechanismNative
                     _rdNative.Enabled = True
                     nativeMode = True
               End Select
            Case TwainContainerType.Enumeration
               Dim itemsCount As Integer = twnCap.EnumerationCapability.Count
               Dim i As Integer
               For i = 0 To itemsCount - 1
                  Dim item As Object = twnCap.EnumerationCapability.GetValue(i)
                  Dim current As Object = twnCap.EnumerationCapability.GetValue(twnCap.EnumerationCapability.CurrentIndex)

                  Dim itemValue As TwainCapabilityValue = CType(item, TwainCapabilityValue)
                  Dim currentValue As TwainCapabilityValue = CType(current, TwainCapabilityValue)
                  Select Case itemValue
                     Case TwainCapabilityValue.TransferMechanismFile
                        _rdFile.Enabled = True
                        If currentValue = itemValue Then
                           fileMode = True
                        End If
                     Case TwainCapabilityValue.TransferMechanismMemory
                        _rdMemory.Enabled = True
                        If currentValue = itemValue Then
                           memoryMode = True
                        End If
                     Case TwainCapabilityValue.TransferMechanismNative
                        _rdNative.Enabled = True
                        If currentValue = itemValue Then
                           nativeMode = True
                        End If
                  End Select
               Next
         End Select
      Catch ex As Exception
         Dim errorMsg As String = String.Format("Get TwainCapabilityType.ImageTransferMechanism returns {0}", ex.Message)
         AddErrorToErrorList(errorMsg)

         _rdFile.Enabled = False
         _rdMemory.Enabled = False
         _rdNative.Enabled = False
      End Try

      If fileMode Then
         EnableFileMode()
      End If

      If memoryMode Then
         EnableMemoryMode()
      End If

      If nativeMode Then
         EnableNativeMode()
      End If
   End Sub

   Private Sub EnableFileMode()
      _transferMode = TwainTransferMechanism.File

      ' Enable file options
      _txtFileName.Enabled = True
      _btnBrowse.Enabled = True
      _cmbFileFormat.Enabled = True

      ' Disable other options
      _cmbCompression.Enabled = False

      ' select file radio and deselect others
      _rdFile.Checked = True
      _rdMemory.Checked = False
      _rdNative.Checked = False

      ' ICAP_IMAGEFILEFORMAT
      FillImageFileFormat()

      CheckOkButton()
   End Sub

   Private Sub FillImageFileFormat()
      Dim twnCap As TwainCapability = New TwainCapability

      ' ICAP_IMAGEFILEFORMAT

      Try
         twnCap = _twainSession.GetCapability(TwainCapabilityType.ImageImageFileFormat, TwainGetCapabilityMode.GetValues)

         _txtFileName.Enabled = True
         _btnBrowse.Enabled = True
         _cmbFileFormat.Enabled = True
         _cmbFileFormat.Items.Clear()

         Select Case twnCap.Information.ContainerType
            Case TwainContainerType.OneValue
               Dim item As Object = twnCap.OneValueCapability.Value
               Dim itemValue As TwainFileFormat = CType(item, TwainFileFormat)
               Select Case itemValue
                  Case TwainFileFormat.Tiff
                     _cmbFileFormat.Items.Add("TIFF")

                  Case TwainFileFormat.Pict
                     _cmbFileFormat.Items.Add("PICT")

                  Case TwainFileFormat.Bmp
                     _cmbFileFormat.Items.Add("BMP")

                  Case TwainFileFormat.Xbm
                     _cmbFileFormat.Items.Add("XBM")

                  Case TwainFileFormat.Jfif
                     _cmbFileFormat.Items.Add("JFIF")

                  Case TwainFileFormat.Fpx
                     _cmbFileFormat.Items.Add("FPX")

                  Case TwainFileFormat.TiffMulti
                     _cmbFileFormat.Items.Add("TIFFMULTI")

                  Case TwainFileFormat.Png
                     _cmbFileFormat.Items.Add("PNG")

                  Case TwainFileFormat.Spiff
                     _cmbFileFormat.Items.Add("SPIFF")

                  Case TwainFileFormat.Exif
                     _cmbFileFormat.Items.Add("EXIF")
               End Select

               _formatValue(0) = itemValue
               _cmbFileFormat.SelectedIndex = 0
            Case TwainContainerType.Enumeration
               Dim itemsCount As Integer = twnCap.EnumerationCapability.Count
               Dim i As Integer
               For i = 0 To itemsCount - 1
                  Dim item As Object = twnCap.EnumerationCapability.GetValue(i)
                  Dim itemValue As TwainFileFormat = CType(item, TwainFileFormat)
                  Select Case itemValue
                     Case TwainFileFormat.Tiff
                        _cmbFileFormat.Items.Add("TIFF")

                     Case TwainFileFormat.Pict
                        _cmbFileFormat.Items.Add("PICT")

                     Case TwainFileFormat.Bmp
                        _cmbFileFormat.Items.Add("BMP")

                     Case TwainFileFormat.Xbm
                        _cmbFileFormat.Items.Add("XBM")

                     Case TwainFileFormat.Jfif
                        _cmbFileFormat.Items.Add("JFIF")

                     Case TwainFileFormat.Fpx
                        _cmbFileFormat.Items.Add("FPX")

                     Case TwainFileFormat.TiffMulti
                        _cmbFileFormat.Items.Add("TIFFMULTI")

                     Case TwainFileFormat.Png
                        _cmbFileFormat.Items.Add("PNG")

                     Case TwainFileFormat.Spiff
                        _cmbFileFormat.Items.Add("SPIFF")

                     Case TwainFileFormat.Exif
                        _cmbFileFormat.Items.Add("EXIF")

                  End Select
                  _formatValue(i) = itemValue
               Next

               _cmbFileFormat.SelectedIndex = twnCap.EnumerationCapability.CurrentIndex
         End Select
      Catch ex As Exception
         Dim errorMsg As String = String.Format("Get TwainCapabilityType.ImageImageFileFormat returns {0}", ex.Message)
         AddErrorToErrorList(errorMsg)

         ' disable all file modes controls 
         _txtFileName.Enabled = False
         _btnBrowse.Enabled = False
         _cmbFileFormat.Enabled = False
      End Try
   End Sub

   Private Sub EnableMemoryMode()
      _transferMode = TwainTransferMechanism.Memory

      ' Enable memory options
      _cmbCompression.Enabled = True

      ' Disable other options
      _txtFileName.Enabled = False
      _btnBrowse.Enabled = False
      _cmbFileFormat.Enabled = False

      ' select memory radio and deselect others
      _rdMemory.Checked = True
      _rdFile.Checked = False
      _rdNative.Checked = False

      ' ICAP_COMPRESSION
      FillCompression()

      CheckOkButton()
   End Sub

   Private Sub FillCompression()
      Dim twnCap As TwainCapability = New TwainCapability

      ' ICAP_COMPRESSION

      Try
         twnCap = _twainSession.GetCapability(TwainCapabilityType.ImageCompression, TwainGetCapabilityMode.GetValues)

         _cmbCompression.Enabled = True
         _cmbCompression.Items.Clear()

         Select Case twnCap.Information.ContainerType
            Case TwainContainerType.OneValue
               Dim item As Object = twnCap.OneValueCapability.Value
               Dim itemValue As TwainCapabilityValue = CType(item, TwainCapabilityValue)
               Select Case itemValue
                  Case TwainCapabilityValue.CompressionNone
                     _cmbCompression.Items.Add("NONE")
                  Case TwainCapabilityValue.CompressionPackBits
                     _cmbCompression.Items.Add("PACKBITS")
                  Case TwainCapabilityValue.CompressionGroup31D
                     _cmbCompression.Items.Add("GROUP31D")
                  Case TwainCapabilityValue.CompressionGroup31DEol
                     _cmbCompression.Items.Add("GROUP31DEOL")
                  Case TwainCapabilityValue.CompressionGroup32D
                     _cmbCompression.Items.Add("GROUP32D")
                  Case TwainCapabilityValue.CompressionGroup4
                     _cmbCompression.Items.Add("GROUP4")
                  Case TwainCapabilityValue.CompressionJpeg
                     _cmbCompression.Items.Add("JPEG")
                  Case TwainCapabilityValue.CompressionLzw
                     _cmbCompression.Items.Add("LZW")
                  Case TwainCapabilityValue.CompressionJbig
                     _cmbCompression.Items.Add("JBIG")
                  Case TwainCapabilityValue.CompressionPng
                     _cmbCompression.Items.Add("PNG")
                  Case TwainCapabilityValue.CompressionRle4
                     _cmbCompression.Items.Add("RLE4")
                  Case TwainCapabilityValue.CompressionRle8
                     _cmbCompression.Items.Add("RLE8")
                  Case TwainCapabilityValue.CompressionBitFields
                     _cmbCompression.Items.Add("BITFIELDS")
               End Select

               _compressionValue(0) = itemValue
               _cmbCompression.SelectedIndex = 0
            Case TwainContainerType.Enumeration
               Dim itemsCount As Integer = twnCap.EnumerationCapability.Count
               Dim i As Integer
               For i = 0 To itemsCount - 1
                  Dim item As Object = twnCap.EnumerationCapability.GetValue(i)
                  Dim itemValue As TwainCapabilityValue = CType(item, TwainCapabilityValue)
                  Select Case itemValue
                     Case TwainCapabilityValue.CompressionNone
                        _cmbCompression.Items.Add("NONE")
                     Case TwainCapabilityValue.CompressionPackBits
                        _cmbCompression.Items.Add("PACKBITS")
                     Case TwainCapabilityValue.CompressionGroup31D
                        _cmbCompression.Items.Add("GROUP31D")
                     Case TwainCapabilityValue.CompressionGroup31DEol
                        _cmbCompression.Items.Add("GROUP31DEOL")
                     Case TwainCapabilityValue.CompressionGroup32D
                        _cmbCompression.Items.Add("GROUP32D")
                     Case TwainCapabilityValue.CompressionGroup4
                        _cmbCompression.Items.Add("GROUP4")
                     Case TwainCapabilityValue.CompressionJpeg
                        _cmbCompression.Items.Add("JPEG")
                     Case TwainCapabilityValue.CompressionLzw
                        _cmbCompression.Items.Add("LZW")
                     Case TwainCapabilityValue.CompressionJbig
                        _cmbCompression.Items.Add("JBIG")
                     Case TwainCapabilityValue.CompressionPng
                        _cmbCompression.Items.Add("PNG")
                     Case TwainCapabilityValue.CompressionRle4
                        _cmbCompression.Items.Add("RLE4")
                     Case TwainCapabilityValue.CompressionRle8
                        _cmbCompression.Items.Add("RLE8")
                     Case TwainCapabilityValue.CompressionBitFields
                        _cmbCompression.Items.Add("BITFIELDS")
                  End Select
                  _compressionValue(i) = itemValue
               Next

               _cmbCompression.SelectedIndex = twnCap.EnumerationCapability.CurrentIndex
         End Select
      Catch ex As Exception
         Dim errorMsg As String = String.Format("Get TwainCapabilityType.ImageCompression returns {0}", ex.Message)
         AddErrorToErrorList(errorMsg)
         _cmbCompression.Enabled = False
      End Try
   End Sub

   Private Sub EnableNativeMode()
      _transferMode = TwainTransferMechanism.Native

      ' Disable other options
      _cmbCompression.Enabled = False

      _txtFileName.Enabled = False
      _btnBrowse.Enabled = False
      _cmbFileFormat.Enabled = False

      ' select native radio and deselect others
      _rdNative.Checked = True
      _rdMemory.Checked = False
      _rdFile.Checked = False

      CheckOkButton()
   End Sub

   Private Sub CheckOkButton()
      Dim okEnabled As Boolean = True
      Dim frameEnabled As Boolean = True
      Dim fileEnabled As Boolean = True

      frameEnabled = _txtFrameLeft.Enabled
      If frameEnabled Then
         If _txtFrameLeft.Text.Length = 0 Or _txtFrameTop.Text.Length = 0 Or _
             _txtFrameRight.Text.Length = 0 Or _txtFrameBottom.Text.Length = 0 Then
            okEnabled = False
         End If
      Else
         okEnabled = True
      End If

      fileEnabled = _txtFileName.Enabled
      If fileEnabled Then
         If _txtFileName.Text.Length = 0 Then
            okEnabled = False
         End If
      End If

      _btnOK.Enabled = okEnabled
   End Sub

   Private Sub _rdFile_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _rdFile.Click
      EnableFileMode()
   End Sub

   Private Sub _rdMemory_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _rdMemory.Click
      EnableMemoryMode()
   End Sub

   Private Sub _rdNative_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _rdNative.Click
      EnableNativeMode()
   End Sub

   Private Sub FillPixelType()
      Dim twnCap As TwainCapability = New TwainCapability

      ' ICAP_PIXELTYPE
      Try
         twnCap = _twainSession.GetCapability(TwainCapabilityType.ImagePixelType, TwainGetCapabilityMode.GetValues)

         _cmbPixelType.Enabled = True
         _cmbPixelType.Items.Clear()

         Select Case twnCap.Information.ContainerType
            Case TwainContainerType.OneValue
               Dim item As Object = twnCap.OneValueCapability.Value
               Dim itemValue As TwainCapabilityValue = CType(item, TwainCapabilityValue)
               Select Case itemValue
                  Case TwainCapabilityValue.PixelTypeBW
                     _cmbPixelType.Items.Add("BW")
                  Case TwainCapabilityValue.PixelTypeGray
                     _cmbPixelType.Items.Add("GRAY")
                  Case TwainCapabilityValue.PixelTypeRgb
                     _cmbPixelType.Items.Add("RGB")
                  Case TwainCapabilityValue.PixelTypePalette
                     _cmbPixelType.Items.Add("PALETTE")
                  Case TwainCapabilityValue.PixelTypeCmy
                     _cmbPixelType.Items.Add("CMY")
                  Case TwainCapabilityValue.PixelTypeCmyk
                     _cmbPixelType.Items.Add("CMYK")
                  Case TwainCapabilityValue.PixelTypeYuv
                     _cmbPixelType.Items.Add("YUV")
                  Case TwainCapabilityValue.PixelTypeYuvk
                     _cmbPixelType.Items.Add("YUVK")
                  Case TwainCapabilityValue.PixelTypeCieXyz
                     _cmbPixelType.Items.Add("CIEXYZ")
               End Select

               _pixelValue(0) = itemValue
               _cmbPixelType.SelectedIndex = 0
            Case TwainContainerType.Enumeration
               Dim itemsCount As Integer = twnCap.EnumerationCapability.Count
               Dim i As Integer
               For i = 0 To itemsCount - 1
                  Dim item As Object = twnCap.EnumerationCapability.GetValue(i)
                  Dim itemValue As TwainCapabilityValue = CType(item, TwainCapabilityValue)
                  Select Case itemValue
                     Case TwainCapabilityValue.PixelTypeBW
                        _cmbPixelType.Items.Add("BW")
                     Case TwainCapabilityValue.PixelTypeGray
                        _cmbPixelType.Items.Add("GRAY")
                     Case TwainCapabilityValue.PixelTypeRgb
                        _cmbPixelType.Items.Add("RGB")
                     Case TwainCapabilityValue.PixelTypePalette
                        _cmbPixelType.Items.Add("PALETTE")
                     Case TwainCapabilityValue.PixelTypeCmy
                        _cmbPixelType.Items.Add("CMY")
                     Case TwainCapabilityValue.PixelTypeCmyk
                        _cmbPixelType.Items.Add("CMYK")
                     Case TwainCapabilityValue.PixelTypeYuv
                        _cmbPixelType.Items.Add("YUV")
                     Case TwainCapabilityValue.PixelTypeYuvk
                        _cmbPixelType.Items.Add("YUVK")
                     Case TwainCapabilityValue.PixelTypeCieXyz
                        _cmbPixelType.Items.Add("CIEXYZ")
                  End Select

                  _pixelValue(i) = itemValue
               Next

               _cmbPixelType.SelectedIndex = twnCap.EnumerationCapability.CurrentIndex
         End Select
      Catch ex As Exception
         Dim errorMsg As String = String.Format("Get TwainCapabilityType.ImagePixelType returns {0}", ex.Message)
         AddErrorToErrorList(errorMsg)
         _cmbPixelType.Enabled = False
      End Try
   End Sub

   Private Sub FillOrientation()
      Dim twnCap As TwainCapability = New TwainCapability

      ' ICAP_ORIENTATION
      Try
         twnCap = _twainSession.GetCapability(TwainCapabilityType.ImageOrientation, TwainGetCapabilityMode.GetValues)

         _cmbOrientation.Enabled = True
         _cmbOrientation.Items.Clear()

         Select Case twnCap.Information.ContainerType
            Case TwainContainerType.OneValue
               Dim item As Object = twnCap.OneValueCapability.Value
               Dim itemValue As TwainCapabilityValue = CType(item, TwainCapabilityValue)
               Select Case itemValue
                  Case TwainCapabilityValue.OrientationRot0
                     _cmbOrientation.Items.Add("ROT0")
                  Case TwainCapabilityValue.OrientationRot90
                     _cmbOrientation.Items.Add("ROT90")
                  Case TwainCapabilityValue.OrientationRot180
                     _cmbOrientation.Items.Add("ROT180")
                  Case TwainCapabilityValue.OrientationRot270
                     _cmbOrientation.Items.Add("ROT270")
               End Select

               _orientationValue(0) = itemValue
               _cmbOrientation.SelectedIndex = 0
            Case TwainContainerType.Enumeration
               Dim itemsCount As Integer = twnCap.EnumerationCapability.Count
               Dim i As Integer
               For i = 0 To itemsCount - 1
                  Dim item As Object = twnCap.EnumerationCapability.GetValue(i)
                  Dim itemValue As TwainCapabilityValue = CType(item, TwainCapabilityValue)
                  Select Case itemValue
                     Case TwainCapabilityValue.OrientationRot0
                        _cmbOrientation.Items.Add("ROT0")
                     Case TwainCapabilityValue.OrientationRot90
                        _cmbOrientation.Items.Add("ROT90")
                     Case TwainCapabilityValue.OrientationRot180
                        _cmbOrientation.Items.Add("ROT180")
                     Case TwainCapabilityValue.OrientationRot270
                        _cmbOrientation.Items.Add("ROT270")
                  End Select

                  _orientationValue(i) = itemValue
               Next

               _cmbOrientation.SelectedIndex = twnCap.EnumerationCapability.CurrentIndex
         End Select
      Catch ex As Exception
         Dim errorMsg As String = String.Format("Get TwainCapabilityType.ImageOrientation returns {0}", ex.Message)
         AddErrorToErrorList(errorMsg)
         _cmbOrientation.Enabled = False
      End Try
   End Sub

   Private Sub FillEffectsCap(ByVal capType As TwainCapabilityType)
      Dim twnCap As TwainCapability = New TwainCapability

      ' ICAP_CONTRAST, ICAP_BRIGHTNESS, ICAP_HIGHLIGHT
      Try
         twnCap = _twainSession.GetCapability(capType, TwainGetCapabilityMode.GetValues)

         Dim tempCombo As ComboBox = New ComboBox
         Select Case capType
            Case TwainCapabilityType.ImageContrast
               _cmbContrast.Enabled = True
               _cmbContrast.Items.Clear()
               tempCombo = _cmbContrast
            Case TwainCapabilityType.ImageBrightness
               _cmbBrightness.Enabled = True
               _cmbBrightness.Items.Clear()
               tempCombo = _cmbBrightness
            Case TwainCapabilityType.ImageHighlight
               _cmbHighlight.Enabled = True
               _cmbHighlight.Items.Clear()
               tempCombo = _cmbHighlight
         End Select

         Select Case twnCap.Information.ContainerType
            Case TwainContainerType.OneValue
               Dim item As Object = twnCap.OneValueCapability.Value
               Dim fix32Value As Double = CType(item, Double)
               tempCombo.Items.Add(fix32Value.ToString())

               tempCombo.SelectedIndex = 0
            Case TwainContainerType.Enumeration
               Dim item As Object
               Dim fix32Value As Double
               Dim itemsCount As Integer = twnCap.EnumerationCapability.Count
               Dim i As Integer
               For i = 0 To itemsCount - 1
                  item = twnCap.EnumerationCapability.GetValue(i)
                  fix32Value = CType(item, Double)
                  tempCombo.Items.Add(fix32Value.ToString())
               Next

               tempCombo.SelectedIndex = twnCap.EnumerationCapability.CurrentIndex
            Case TwainContainerType.Range
               Dim minValue As Double = CType(twnCap.RangeCapability.MinimumValue, Double)
               Dim maxValue As Double = CType(twnCap.RangeCapability.MaximumValue, Double)
               Dim stepSize As Double = CType(twnCap.RangeCapability.StepSize, Double)
               Dim currentValue As Double = CType(twnCap.RangeCapability.CurrentValue, Double)

               Dim i As Integer = 0
               Dim selIndex As Integer = 0

               tempCombo.Items.Add(minValue.ToString())
               If minValue = currentValue Then
                  selIndex = i
               End If

               Dim tempValue As Double = minValue + stepSize
               While tempValue <= maxValue
                  i = i + 1
                  tempCombo.Items.Add(tempValue.ToString())
                  If tempValue = currentValue Then
                     selIndex = i
                  End If

                  tempValue = tempValue + stepSize
               End While

               tempCombo.SelectedIndex = selIndex
         End Select
      Catch ex As Exception
         Dim errorMsg As String = String.Format("Get {0} returns {1}", capType.ToString(), ex.Message)
         AddErrorToErrorList(errorMsg)

         Select Case capType
            Case TwainCapabilityType.ImageContrast
               _cmbContrast.Enabled = False
            Case TwainCapabilityType.ImageBrightness
               _cmbBrightness.Enabled = False
            Case TwainCapabilityType.ImageHighlight
               _cmbHighlight.Enabled = False
         End Select
      End Try
   End Sub

   Private Sub FillHalftones()
      Dim twnCap As TwainCapability = New TwainCapability

      ' ICAP_HALFTONES
      Try
         twnCap = _twainSession.GetCapability(TwainCapabilityType.ImageHalftones, TwainGetCapabilityMode.GetValues)
         _cmbHalftone.Enabled = True
         _cmbHalftone.Items.Clear()

         Select Case twnCap.Information.ContainerType
            Case TwainContainerType.OneValue
               Dim item As Object
               Dim stringValue As String

               item = twnCap.OneValueCapability.Value
               stringValue = CType(item, String)
               _cmbHalftone.Items.Add(stringValue)
               _cmbHalftone.SelectedIndex = 0
            Case TwainContainerType.Enumeration
               Dim item As Object
               Dim stringValue As String
               Dim itemsCount As Integer = twnCap.EnumerationCapability.Count
               Dim i As Integer
               For i = 0 To itemsCount - 1
                  item = twnCap.EnumerationCapability.GetValue(i)
                  stringValue = CType(item, String)
                  _cmbHalftone.Items.Add(stringValue)
               Next

               _cmbHalftone.SelectedIndex = twnCap.EnumerationCapability.CurrentIndex
            Case TwainContainerType.Array
               Dim item As Object
               Dim stringValue As String
               Dim itemsCount As Integer = twnCap.ArrayCapability.Count
               Dim i As Integer
               For i = 0 To itemsCount - 1
                  item = twnCap.ArrayCapability.GetValue(i)
                  stringValue = CType(item, String)
                  _cmbHalftone.Items.Add(stringValue)
               Next

               _cmbHalftone.SelectedIndex = 0
         End Select
      Catch ex As Exception
         Dim errorMsg As String = String.Format("Get TwainCapabilityType.ImageHalftones returns {0}", ex.Message)
         AddErrorToErrorList(errorMsg)
         _cmbHalftone.Enabled = False
      End Try
   End Sub

   Private Function GetFileFormatString() As String
      Dim filter As String = "All Files (*.*)|*.*"
      Select Case (_formatValue(_cmbFileFormat.SelectedIndex))
         Case TwainFileFormat.Tiff
            filter = "TIFF Files|*.tif"

         Case TwainFileFormat.Pict
            filter = "PICT Files|*.pct"

         Case TwainFileFormat.Bmp
            filter = "BMP Files|*.bmp"

         Case TwainFileFormat.Xbm
            filter = "XBM Files|*.xbm"

         Case TwainFileFormat.Jfif
            filter = "JFIF Files|*.jpg"

         Case TwainFileFormat.Fpx
            filter = "FPX Files|*.fpx"

         Case TwainFileFormat.TiffMulti
            filter = "TIFF Multi Files|*.tif"

         Case TwainFileFormat.Png
            filter = "PNG Files|*.png"

         Case TwainFileFormat.Spiff
            filter = "SPIFF Files|*.spif"

         Case TwainFileFormat.Exif
            filter = "EXIF Files|*.xif"

      End Select
      Return filter
   End Function

   Private Sub _btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _btnBrowse.Click
      Dim saveDialog As SaveFileDialog = New SaveFileDialog

      Try
         Dim filterString As String = GetFileFormatString()
         saveDialog.Filter = filterString
         saveDialog.FilterIndex = 0

         If saveDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
            _txtFileName.Text = saveDialog.FileName
         End If

         DialogResult = System.Windows.Forms.DialogResult.None
      Catch ex As Exception
         ex = ex
      Finally
         saveDialog.Dispose()
      End Try
   End Sub

   Private Sub _btnLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _btnLoad.Click
      Dim openDialog As OpenFileDialog = New OpenFileDialog

      Try
         openDialog.Filter = "LEAD Twain Template Files (*.ltt)|*.ltt"
         openDialog.FilterIndex = 0

         If openDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
            Try
               _twainSession.LoadTemplateFile(openDialog.FileName)
               InitializeTemplate()
            Catch ex As Exception
               Messager.ShowError(Me, ex)
            End Try
         End If

         DialogResult = System.Windows.Forms.DialogResult.None
      Catch ex As Exception
         ex = ex
      Finally
         openDialog.Dispose()
      End Try
   End Sub

   Private Sub _btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _btnSave.Click
      SetCapabilities()
      Dim saveDialog As SaveFileDialog = New SaveFileDialog

      Try
         saveDialog.Filter = "LEAD Twain Template Files (*.ltt)|*.ltt"
         saveDialog.FilterIndex = 0

         If saveDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
            Try
               _twainSession.SaveTemplateFile(saveDialog.FileName)
            Catch ex As Exception
               Messager.ShowError(Me, ex)
            End Try
         End If

         DialogResult = System.Windows.Forms.DialogResult.None
      Catch ex As Exception
      Finally
         saveDialog.Dispose()
      End Try
   End Sub

   Private Sub _btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _btnOK.Click
      SetCapabilities()
      DialogResult = System.Windows.Forms.DialogResult.OK
   End Sub

   Private Sub SetCapabilities()
      SetUnitsCapability()
      SetOrientationCapability()
      SetFramesCapability()
      SetXYResCapability()
      SetXferCapability()
      SetPixelTypeCapability()
      SetContrastCapability()
      SetBrightnessCapability()
      SetHighlightCapability()
      SetHalftonesCapability()
   End Sub

   Private Sub MySetCapability(ByVal capType As TwainCapabilityType, ByVal itemType As TwainItemType, ByVal data As Object)
      Dim twnCap As TwainCapability = New TwainCapability

      twnCap.Information.Type = capType
      twnCap.Information.ContainerType = TwainContainerType.OneValue

      twnCap.OneValueCapability.ItemType = itemType
      twnCap.OneValueCapability.Value = data

      _twainSession.SetCapability(twnCap, TwainSetCapabilityMode.Set)
   End Sub

   Private Sub SetUnitsCapability()
      Try
         MySetCapability(TwainCapabilityType.ImageUnits, TwainItemType.Uint16, _unitsValue(_cmbUnit.SelectedIndex))
      Catch ex As Exception
         Dim errorMsg As String = String.Format("Set TwainCapabilityType.ImageUnits returns {0}", ex.Message)
         AddErrorToErrorList(errorMsg)
      End Try
   End Sub

   Private Sub SetFramesCapability()
      Dim frame As TwainFrame = New TwainFrame
      Try
         frame.LeftMargin = CType(_txtFrameLeft.Text, Single)
         frame.TopMargin = CType(_txtFrameTop.Text, Single)
         frame.RightMargin = CType(_txtFrameRight.Text, Single)
         frame.BottomMargin = CType(_txtFrameBottom.Text, Single)

         MySetCapability(TwainCapabilityType.ImageFrames, TwainItemType.Frame, frame)
      Catch ex As Exception
         Dim errorMsg As String = String.Format("Set TwainCapabilityType.ImageFrames returns {0}", ex.Message)
         AddErrorToErrorList(errorMsg)
      End Try
   End Sub

   Private Sub SetXYResCapability()
      Try
         Dim xRes As Single = CType(_cmbXRes.SelectedItem, Single)
         MySetCapability(TwainCapabilityType.ImageXResolution, TwainItemType.Fix32, xRes)
      Catch ex As Exception
         Dim errorMsg As String = String.Format("Set TwainCapabilityType.ImageXResolution returns {0}", ex.Message)
         AddErrorToErrorList(errorMsg)
      End Try

      Try
         Dim yRes As Single = CType(_cmbYRes.SelectedItem, Single)
         MySetCapability(TwainCapabilityType.ImageYResolution, TwainItemType.Fix32, yRes)
      Catch ex As Exception
         Dim errorMsg As String = String.Format("Set TwainCapabilityType.ImageYResolution returns {0}", ex.Message)
         AddErrorToErrorList(errorMsg)
      End Try
   End Sub

   Private Sub SetXferCapability()
      Try
         MySetCapability(TwainCapabilityType.ImageTransferMechanism, TwainItemType.Uint16, CType(_transferMode, UInt16))
      Catch ex As Exception
         Dim errorMsg As String = String.Format("Set TwainCapabilityType.ImageTransferMechanism returns {0}", ex.Message)
         AddErrorToErrorList(errorMsg)
         Return
      End Try

      Select Case _transferMode
         Case TwainTransferMechanism.Native
            ' do nothing
         Case TwainTransferMechanism.Memory
            Try
               ' ICAP_COMPRESSION
               MySetCapability(TwainCapabilityType.ImageCompression, TwainItemType.Uint16, _compressionValue(_cmbCompression.SelectedIndex))
            Catch ex As Exception
               Dim errorMsg As String = String.Format("Set TwainCapabilityType.ImageCompression returns {0}", ex.Message)
               AddErrorToErrorList(errorMsg)
            End Try
         Case TwainTransferMechanism.File
            Try
               If _txtFileName.Text = "" Then
                  Return
               End If

               ' ICAP_IMAGEFILEFORMAT
               MySetCapability(TwainCapabilityType.ImageImageFileFormat, TwainItemType.Uint16, CType(_formatValue(_cmbFileFormat.SelectedIndex), UInt16))

               Dim twnProps As TwainProperties = _twainSession.Properties
               Dim dataTransfer As TwainDataTransferProperties = twnProps.DataTransfer
               dataTransfer.FileName = _txtFileName.Text
               dataTransfer.ScanFileFormat = _formatValue(_cmbFileFormat.SelectedIndex)
               twnProps.DataTransfer = dataTransfer
               _twainSession.Properties = twnProps
            Catch ex As Exception
               Dim errorMsg As String = String.Format("Set TwainCapabilityType.ImageImageFileFormat returns {0}", ex.Message)
               AddErrorToErrorList(errorMsg)
            End Try
      End Select
   End Sub

   Private Sub SetPixelTypeCapability()
      Try
         MySetCapability(TwainCapabilityType.ImagePixelType, TwainItemType.Uint16, _pixelValue(_cmbPixelType.SelectedIndex))
      Catch ex As Exception
         Dim errorMsg As String = String.Format("Set TwainCapabilityType.ImagePixelType returns {0}", ex.Message)
         AddErrorToErrorList(errorMsg)
      End Try
   End Sub

   Private Sub SetOrientationCapability()
      Try
         MySetCapability(TwainCapabilityType.ImageOrientation, TwainItemType.Uint16, _orientationValue(_cmbOrientation.SelectedIndex))
      Catch ex As Exception
         Dim errorMsg As String = String.Format("Set TwainCapabilityType.ImageOrientation returns {0}", ex.Message)
         AddErrorToErrorList(errorMsg)
      End Try
   End Sub

   Private Sub SetContrastCapability()
      Try
         Dim contrast As Single = CType(_cmbContrast.SelectedItem, Single)
         MySetCapability(TwainCapabilityType.ImageContrast, TwainItemType.Fix32, contrast)
      Catch ex As Exception
         Dim errorMsg As String = String.Format("Set TwainCapabilityType.ImageContrast returns {0}", ex.Message)
         AddErrorToErrorList(errorMsg)
      End Try
   End Sub

   Private Sub SetBrightnessCapability()
      Try
         Dim brightness As Single = CType(_cmbBrightness.SelectedItem, Single)
         MySetCapability(TwainCapabilityType.ImageBrightness, TwainItemType.Fix32, brightness)
      Catch ex As Exception
         Dim errorMsg As String = String.Format("Set TwainCapabilityType.ImageBrightness returns {0}", ex.Message)
         AddErrorToErrorList(errorMsg)
      End Try
   End Sub

   Private Sub SetHighlightCapability()
      Try
         Dim highlight As Single = CType(_cmbHighlight.SelectedItem, Single)
         MySetCapability(TwainCapabilityType.ImageHighlight, TwainItemType.Fix32, highlight)
      Catch ex As Exception
         Dim errorMsg As String = String.Format("Set TwainCapabilityType.ImageHighLight returns {0}", ex.Message)
         AddErrorToErrorList(errorMsg)
      End Try
   End Sub

   Private Sub SetHalftonesCapability()
      Try
         MySetCapability(TwainCapabilityType.ImageHalftones, TwainItemType.Str32, _cmbHalftone.GetItemText(_cmbHalftone.SelectedItem))
      Catch ex As Exception
         Dim errorMsg As String = String.Format("Set TwainCapabilityType.ImageHalftones returns {0}", ex.Message)
         AddErrorToErrorList(errorMsg)
      End Try
   End Sub

   Private Sub _txtFileName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _txtFileName.TextChanged
      CheckOkButton()
   End Sub

   Private Sub _cmbUnit_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _cmbUnit.SelectedIndexChanged
      If _unitsValue(_cmbUnit.SelectedIndex) = TwainCapabilityValue.UnitPixels Then
         _cmbXRes.Enabled = False
         _cmbYRes.Enabled = False
      Else
         _cmbXRes.Enabled = True
         _cmbYRes.Enabled = True
      End If

      SetUnitsCapability()
      FillFrameCaps()
      FillXYRes()
   End Sub

   Private Sub _btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _btnCancel.Click
      MySetCapability(TwainCapabilityType.ImageUnits, TwainItemType.Uint16, CInt(_unitsValue(_selectedUnitsIndex)))
   End Sub
End Class
