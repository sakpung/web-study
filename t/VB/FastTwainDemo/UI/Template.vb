' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.IO

Imports Leadtools.Twain

Namespace VBFastTwainDemo
   ''' <summary>
   ''' Summary description for Template.
   ''' </summary>
   Public Class Template : Inherits System.Windows.Forms.Form
      Private _lblYRes As System.Windows.Forms.Label
      Private _lblXRes As System.Windows.Forms.Label
      Private _txtFrameBottom As System.Windows.Forms.TextBox
      Private _txtFrameRight As System.Windows.Forms.TextBox
      Private _txtFrameTop As System.Windows.Forms.TextBox
      Private _txtFrameLeft As System.Windows.Forms.TextBox
      Private _lblFrameBottom As System.Windows.Forms.Label
      Private _lblFrameRight As System.Windows.Forms.Label
      Private _lblFrameTop As System.Windows.Forms.Label
      Private _lblFrameLeft As System.Windows.Forms.Label
      Private _cmbUnit As System.Windows.Forms.ComboBox
      Private _lblUnit As System.Windows.Forms.Label
      Private WithEvents _rdNative As System.Windows.Forms.RadioButton
      Private WithEvents _rdMemory As System.Windows.Forms.RadioButton
      Private WithEvents _rdFile As System.Windows.Forms.RadioButton
      Private _lblFileName As System.Windows.Forms.Label
      Private WithEvents _txtFileName As System.Windows.Forms.TextBox
      Private WithEvents _btnBrowse As System.Windows.Forms.Button
      Private _lblFormat As System.Windows.Forms.Label
      Private _cmbFileFormat As System.Windows.Forms.ComboBox
      Private _lblCompression As System.Windows.Forms.Label
      Private _lblPixelType As System.Windows.Forms.Label
      Private _cmbPixelType As System.Windows.Forms.ComboBox
      Private _lblOrientation As System.Windows.Forms.Label
      Private _cmbOrientation As System.Windows.Forms.ComboBox
      Private _lblHalftone As System.Windows.Forms.Label
      Private _cmbHalftone As System.Windows.Forms.ComboBox
      Private _lblContrast As System.Windows.Forms.Label
      Private _cmbContrast As System.Windows.Forms.ComboBox
      Private _lblBrightness As System.Windows.Forms.Label
      Private _cmbBrightness As System.Windows.Forms.ComboBox
      Private _lblHighlight As System.Windows.Forms.Label
      Private _cmbHighlight As System.Windows.Forms.ComboBox
      Private WithEvents _btnLoad As System.Windows.Forms.Button
      Private WithEvents _btnSave As System.Windows.Forms.Button
      Private WithEvents _btnOK As System.Windows.Forms.Button
      Private _btnCancel As System.Windows.Forms.Button
      Private _gbImageFrame As System.Windows.Forms.GroupBox
      Private _gbTransferMode As System.Windows.Forms.GroupBox
      Private _gbFileOptions As System.Windows.Forms.GroupBox
      Private _gbMemoryOptions As System.Windows.Forms.GroupBox
      Private _gbImgeEfx As System.Windows.Forms.GroupBox
      Private _cmbXRes As System.Windows.Forms.ComboBox
      Private _cmbYRes As System.Windows.Forms.ComboBox
      Private _cmbCompression As System.Windows.Forms.ComboBox
      ''' <summary>
      ''' Required designer variable.
      ''' </summary>
      Private components As System.ComponentModel.Container = Nothing

      Public Sub New()
         '
         ' Required for Windows Form Designer support
         '
         InitializeComponent()

         '
         ' TODO: Add any constructor code after InitializeComponent call
         '
      End Sub

      ''' <summary>
      ''' Clean up any resources being used.
      ''' </summary>
      Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
         If disposing Then
            If Not components Is Nothing Then
               components.Dispose()
            End If
         End If
         MyBase.Dispose(disposing)
      End Sub

#Region "Windows Form Designer generated code"
      ''' <summary>
      ''' Required method for Designer support - do not modify
      ''' the contents of this method with the code editor.
      ''' </summary>
      Private Sub InitializeComponent()
         Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Template))
         Me._gbImageFrame = New System.Windows.Forms.GroupBox()
         Me._cmbYRes = New System.Windows.Forms.ComboBox()
         Me._cmbXRes = New System.Windows.Forms.ComboBox()
         Me._lblYRes = New System.Windows.Forms.Label()
         Me._lblXRes = New System.Windows.Forms.Label()
         Me._txtFrameBottom = New System.Windows.Forms.TextBox()
         Me._txtFrameRight = New System.Windows.Forms.TextBox()
         Me._txtFrameTop = New System.Windows.Forms.TextBox()
         Me._txtFrameLeft = New System.Windows.Forms.TextBox()
         Me._lblFrameBottom = New System.Windows.Forms.Label()
         Me._lblFrameRight = New System.Windows.Forms.Label()
         Me._lblFrameTop = New System.Windows.Forms.Label()
         Me._lblFrameLeft = New System.Windows.Forms.Label()
         Me._cmbUnit = New System.Windows.Forms.ComboBox()
         Me._lblUnit = New System.Windows.Forms.Label()
         Me._gbTransferMode = New System.Windows.Forms.GroupBox()
         Me._rdNative = New System.Windows.Forms.RadioButton()
         Me._rdMemory = New System.Windows.Forms.RadioButton()
         Me._rdFile = New System.Windows.Forms.RadioButton()
         Me._gbFileOptions = New System.Windows.Forms.GroupBox()
         Me._cmbFileFormat = New System.Windows.Forms.ComboBox()
         Me._lblFormat = New System.Windows.Forms.Label()
         Me._btnBrowse = New System.Windows.Forms.Button()
         Me._txtFileName = New System.Windows.Forms.TextBox()
         Me._lblFileName = New System.Windows.Forms.Label()
         Me._gbMemoryOptions = New System.Windows.Forms.GroupBox()
         Me._cmbCompression = New System.Windows.Forms.ComboBox()
         Me._lblCompression = New System.Windows.Forms.Label()
         Me._gbImgeEfx = New System.Windows.Forms.GroupBox()
         Me._cmbHighlight = New System.Windows.Forms.ComboBox()
         Me._lblHighlight = New System.Windows.Forms.Label()
         Me._cmbBrightness = New System.Windows.Forms.ComboBox()
         Me._lblBrightness = New System.Windows.Forms.Label()
         Me._cmbContrast = New System.Windows.Forms.ComboBox()
         Me._lblContrast = New System.Windows.Forms.Label()
         Me._cmbHalftone = New System.Windows.Forms.ComboBox()
         Me._lblHalftone = New System.Windows.Forms.Label()
         Me._cmbOrientation = New System.Windows.Forms.ComboBox()
         Me._lblOrientation = New System.Windows.Forms.Label()
         Me._cmbPixelType = New System.Windows.Forms.ComboBox()
         Me._lblPixelType = New System.Windows.Forms.Label()
         Me._btnLoad = New System.Windows.Forms.Button()
         Me._btnSave = New System.Windows.Forms.Button()
         Me._btnOK = New System.Windows.Forms.Button()
         Me._btnCancel = New System.Windows.Forms.Button()
         Me._gbImageFrame.SuspendLayout()
         Me._gbTransferMode.SuspendLayout()
         Me._gbFileOptions.SuspendLayout()
         Me._gbMemoryOptions.SuspendLayout()
         Me._gbImgeEfx.SuspendLayout()
         Me.SuspendLayout()
         ' 
         ' _gbImageFrame
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
         Me._gbImageFrame.TabIndex = 0
         Me._gbImageFrame.TabStop = False
         Me._gbImageFrame.Text = "Image Frame"
         ' 
         ' _cmbYRes
         ' 
         Me._cmbYRes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
         Me._cmbYRes.Location = New System.Drawing.Point(72, 208)
         Me._cmbYRes.Name = "_cmbYRes"
         Me._cmbYRes.Size = New System.Drawing.Size(100, 21)
         Me._cmbYRes.TabIndex = 15
         ' 
         ' _cmbXRes
         ' 
         Me._cmbXRes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
         Me._cmbXRes.Location = New System.Drawing.Point(72, 176)
         Me._cmbXRes.Name = "_cmbXRes"
         Me._cmbXRes.Size = New System.Drawing.Size(100, 21)
         Me._cmbXRes.TabIndex = 14
         ' 
         ' _lblYRes
         ' 
         Me._lblYRes.Location = New System.Drawing.Point(8, 208)
         Me._lblYRes.Name = "_lblYRes"
         Me._lblYRes.Size = New System.Drawing.Size(72, 23)
         Me._lblYRes.TabIndex = 13
         Me._lblYRes.Text = "YResolution:"
         ' 
         ' _lblXRes
         ' 
         Me._lblXRes.Location = New System.Drawing.Point(8, 176)
         Me._lblXRes.Name = "_lblXRes"
         Me._lblXRes.Size = New System.Drawing.Size(72, 23)
         Me._lblXRes.TabIndex = 11
         Me._lblXRes.Text = "XResolution:"
         ' 
         ' _txtFrameBottom
         ' 
         Me._txtFrameBottom.Location = New System.Drawing.Point(72, 144)
         Me._txtFrameBottom.Name = "_txtFrameBottom"
         Me._txtFrameBottom.Size = New System.Drawing.Size(100, 20)
         Me._txtFrameBottom.TabIndex = 10
         ' 
         ' _txtFrameRight
         ' 
         Me._txtFrameRight.Location = New System.Drawing.Point(72, 112)
         Me._txtFrameRight.Name = "_txtFrameRight"
         Me._txtFrameRight.Size = New System.Drawing.Size(100, 20)
         Me._txtFrameRight.TabIndex = 8
         ' 
         ' _txtFrameTop
         ' 
         Me._txtFrameTop.Location = New System.Drawing.Point(72, 80)
         Me._txtFrameTop.Name = "_txtFrameTop"
         Me._txtFrameTop.Size = New System.Drawing.Size(100, 20)
         Me._txtFrameTop.TabIndex = 6
         ' 
         ' _txtFrameLeft
         ' 
         Me._txtFrameLeft.Location = New System.Drawing.Point(72, 48)
         Me._txtFrameLeft.Name = "_txtFrameLeft"
         Me._txtFrameLeft.Size = New System.Drawing.Size(100, 20)
         Me._txtFrameLeft.TabIndex = 4
         ' 
         ' _lblFrameBottom
         ' 
         Me._lblFrameBottom.Location = New System.Drawing.Point(8, 144)
         Me._lblFrameBottom.Name = "_lblFrameBottom"
         Me._lblFrameBottom.Size = New System.Drawing.Size(48, 23)
         Me._lblFrameBottom.TabIndex = 9
         Me._lblFrameBottom.Text = "Bottom:"
         ' 
         ' _lblFrameRight
         ' 
         Me._lblFrameRight.Location = New System.Drawing.Point(8, 112)
         Me._lblFrameRight.Name = "_lblFrameRight"
         Me._lblFrameRight.Size = New System.Drawing.Size(40, 23)
         Me._lblFrameRight.TabIndex = 7
         Me._lblFrameRight.Text = "Right:"
         ' 
         ' _lblFrameTop
         ' 
         Me._lblFrameTop.Location = New System.Drawing.Point(8, 80)
         Me._lblFrameTop.Name = "_lblFrameTop"
         Me._lblFrameTop.Size = New System.Drawing.Size(40, 23)
         Me._lblFrameTop.TabIndex = 5
         Me._lblFrameTop.Text = "Top:"
         ' 
         ' _lblFrameLeft
         ' 
         Me._lblFrameLeft.Location = New System.Drawing.Point(8, 48)
         Me._lblFrameLeft.Name = "_lblFrameLeft"
         Me._lblFrameLeft.Size = New System.Drawing.Size(32, 23)
         Me._lblFrameLeft.TabIndex = 3
         Me._lblFrameLeft.Text = "Lef:"
         ' 
         ' _cmbUnit
         ' 
         Me._cmbUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
         Me._cmbUnit.Location = New System.Drawing.Point(72, 16)
         Me._cmbUnit.Name = "_cmbUnit"
         Me._cmbUnit.Size = New System.Drawing.Size(100, 21)
         Me._cmbUnit.TabIndex = 2
         ' 
         ' _lblUnit
         ' 
         Me._lblUnit.Location = New System.Drawing.Point(8, 16)
         Me._lblUnit.Name = "_lblUnit"
         Me._lblUnit.Size = New System.Drawing.Size(32, 23)
         Me._lblUnit.TabIndex = 1
         Me._lblUnit.Text = "Unit:"
         ' 
         ' _gbTransferMode
         ' 
         Me._gbTransferMode.Controls.Add(Me._rdNative)
         Me._gbTransferMode.Controls.Add(Me._rdMemory)
         Me._gbTransferMode.Controls.Add(Me._rdFile)
         Me._gbTransferMode.Location = New System.Drawing.Point(200, 8)
         Me._gbTransferMode.Name = "_gbTransferMode"
         Me._gbTransferMode.Size = New System.Drawing.Size(224, 64)
         Me._gbTransferMode.TabIndex = 1
         Me._gbTransferMode.TabStop = False
         Me._gbTransferMode.Text = "Transfer Mode"
         ' 
         ' _rdNative
         ' 
         Me._rdNative.Location = New System.Drawing.Point(160, 24)
         Me._rdNative.Name = "_rdNative"
         Me._rdNative.Size = New System.Drawing.Size(56, 24)
         Me._rdNative.TabIndex = 2
         Me._rdNative.Text = "Native"
         ' 
         ' _rdMemory
         ' 
         Me._rdMemory.Location = New System.Drawing.Point(72, 24)
         Me._rdMemory.Name = "_rdMemory"
         Me._rdMemory.Size = New System.Drawing.Size(64, 24)
         Me._rdMemory.TabIndex = 1
         Me._rdMemory.Text = "Memory"
         ' 
         ' _rdFile
         ' 
         Me._rdFile.Location = New System.Drawing.Point(8, 24)
         Me._rdFile.Name = "_rdFile"
         Me._rdFile.Size = New System.Drawing.Size(48, 24)
         Me._rdFile.TabIndex = 0
         Me._rdFile.Text = "File"
         ' 
         ' _gbFileOptions
         ' 
         Me._gbFileOptions.Controls.Add(Me._cmbFileFormat)
         Me._gbFileOptions.Controls.Add(Me._lblFormat)
         Me._gbFileOptions.Controls.Add(Me._btnBrowse)
         Me._gbFileOptions.Controls.Add(Me._txtFileName)
         Me._gbFileOptions.Controls.Add(Me._lblFileName)
         Me._gbFileOptions.Location = New System.Drawing.Point(200, 80)
         Me._gbFileOptions.Name = "_gbFileOptions"
         Me._gbFileOptions.Size = New System.Drawing.Size(224, 96)
         Me._gbFileOptions.TabIndex = 2
         Me._gbFileOptions.TabStop = False
         Me._gbFileOptions.Text = "File Mode Options"
         ' 
         ' _cmbFileFormat
         ' 
         Me._cmbFileFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
         Me._cmbFileFormat.Location = New System.Drawing.Point(64, 64)
         Me._cmbFileFormat.Name = "_cmbFileFormat"
         Me._cmbFileFormat.Size = New System.Drawing.Size(152, 21)
         Me._cmbFileFormat.TabIndex = 4
         ' 
         ' _lblFormat
         ' 
         Me._lblFormat.Location = New System.Drawing.Point(8, 64)
         Me._lblFormat.Name = "_lblFormat"
         Me._lblFormat.Size = New System.Drawing.Size(48, 23)
         Me._lblFormat.TabIndex = 3
         Me._lblFormat.Text = "Format:"
         ' 
         ' _btnBrowse
         ' 
         Me._btnBrowse.Location = New System.Drawing.Point(184, 32)
         Me._btnBrowse.Name = "_btnBrowse"
         Me._btnBrowse.Size = New System.Drawing.Size(32, 23)
         Me._btnBrowse.TabIndex = 2
         Me._btnBrowse.Text = "..."
         ' 
         ' _txtFileName
         ' 
         Me._txtFileName.Location = New System.Drawing.Point(64, 32)
         Me._txtFileName.Name = "_txtFileName"
         Me._txtFileName.Size = New System.Drawing.Size(112, 20)
         Me._txtFileName.TabIndex = 1
         ' 
         ' _lblFileName
         ' 
         Me._lblFileName.Location = New System.Drawing.Point(8, 32)
         Me._lblFileName.Name = "_lblFileName"
         Me._lblFileName.Size = New System.Drawing.Size(64, 23)
         Me._lblFileName.TabIndex = 0
         Me._lblFileName.Text = "File Name:"
         ' 
         ' _gbMemoryOptions
         ' 
         Me._gbMemoryOptions.Controls.Add(Me._cmbCompression)
         Me._gbMemoryOptions.Controls.Add(Me._lblCompression)
         Me._gbMemoryOptions.Location = New System.Drawing.Point(200, 184)
         Me._gbMemoryOptions.Name = "_gbMemoryOptions"
         Me._gbMemoryOptions.Size = New System.Drawing.Size(224, 64)
         Me._gbMemoryOptions.TabIndex = 3
         Me._gbMemoryOptions.TabStop = False
         Me._gbMemoryOptions.Text = "Memory Mode Options"
         ' 
         ' _cmbCompression
         ' 
         Me._cmbCompression.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
         Me._cmbCompression.Location = New System.Drawing.Point(88, 24)
         Me._cmbCompression.Name = "_cmbCompression"
         Me._cmbCompression.Size = New System.Drawing.Size(121, 21)
         Me._cmbCompression.TabIndex = 1
         ' 
         ' _lblCompression
         ' 
         Me._lblCompression.Location = New System.Drawing.Point(8, 24)
         Me._lblCompression.Name = "_lblCompression"
         Me._lblCompression.Size = New System.Drawing.Size(80, 16)
         Me._lblCompression.TabIndex = 0
         Me._lblCompression.Text = "Compression:"
         ' 
         ' _gbImgeEfx
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
         Me._gbImgeEfx.TabIndex = 4
         Me._gbImgeEfx.TabStop = False
         Me._gbImgeEfx.Text = "Image Effects"
         ' 
         ' _cmbHighlight
         ' 
         Me._cmbHighlight.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
         Me._cmbHighlight.Location = New System.Drawing.Point(72, 192)
         Me._cmbHighlight.Name = "_cmbHighlight"
         Me._cmbHighlight.Size = New System.Drawing.Size(121, 21)
         Me._cmbHighlight.TabIndex = 11
         ' 
         ' _lblHighlight
         ' 
         Me._lblHighlight.Location = New System.Drawing.Point(8, 192)
         Me._lblHighlight.Name = "_lblHighlight"
         Me._lblHighlight.Size = New System.Drawing.Size(56, 23)
         Me._lblHighlight.TabIndex = 10
         Me._lblHighlight.Text = "Highlight:"
         ' 
         ' _cmbBrightness
         ' 
         Me._cmbBrightness.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
         Me._cmbBrightness.Location = New System.Drawing.Point(72, 160)
         Me._cmbBrightness.Name = "_cmbBrightness"
         Me._cmbBrightness.Size = New System.Drawing.Size(121, 21)
         Me._cmbBrightness.TabIndex = 9
         ' 
         ' _lblBrightness
         ' 
         Me._lblBrightness.Location = New System.Drawing.Point(8, 160)
         Me._lblBrightness.Name = "_lblBrightness"
         Me._lblBrightness.Size = New System.Drawing.Size(64, 23)
         Me._lblBrightness.TabIndex = 8
         Me._lblBrightness.Text = "Brightness:"
         ' 
         ' _cmbContrast
         ' 
         Me._cmbContrast.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
         Me._cmbContrast.Location = New System.Drawing.Point(72, 128)
         Me._cmbContrast.Name = "_cmbContrast"
         Me._cmbContrast.Size = New System.Drawing.Size(121, 21)
         Me._cmbContrast.TabIndex = 7
         ' 
         ' _lblContrast
         ' 
         Me._lblContrast.Location = New System.Drawing.Point(8, 128)
         Me._lblContrast.Name = "_lblContrast"
         Me._lblContrast.Size = New System.Drawing.Size(56, 23)
         Me._lblContrast.TabIndex = 6
         Me._lblContrast.Text = "Contrast:"
         ' 
         ' _cmbHalftone
         ' 
         Me._cmbHalftone.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
         Me._cmbHalftone.Location = New System.Drawing.Point(72, 96)
         Me._cmbHalftone.Name = "_cmbHalftone"
         Me._cmbHalftone.Size = New System.Drawing.Size(121, 21)
         Me._cmbHalftone.TabIndex = 5
         ' 
         ' _lblHalftone
         ' 
         Me._lblHalftone.Location = New System.Drawing.Point(8, 96)
         Me._lblHalftone.Name = "_lblHalftone"
         Me._lblHalftone.Size = New System.Drawing.Size(56, 23)
         Me._lblHalftone.TabIndex = 4
         Me._lblHalftone.Text = "Halftone:"
         ' 
         ' _cmbOrientation
         ' 
         Me._cmbOrientation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
         Me._cmbOrientation.Location = New System.Drawing.Point(72, 64)
         Me._cmbOrientation.Name = "_cmbOrientation"
         Me._cmbOrientation.Size = New System.Drawing.Size(121, 21)
         Me._cmbOrientation.TabIndex = 3
         ' 
         ' _lblOrientation
         ' 
         Me._lblOrientation.Location = New System.Drawing.Point(8, 64)
         Me._lblOrientation.Name = "_lblOrientation"
         Me._lblOrientation.Size = New System.Drawing.Size(64, 23)
         Me._lblOrientation.TabIndex = 2
         Me._lblOrientation.Text = "Orientation:"
         ' 
         ' _cmbPixelType
         ' 
         Me._cmbPixelType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
         Me._cmbPixelType.Location = New System.Drawing.Point(72, 32)
         Me._cmbPixelType.Name = "_cmbPixelType"
         Me._cmbPixelType.Size = New System.Drawing.Size(121, 21)
         Me._cmbPixelType.TabIndex = 1
         ' 
         ' _lblPixelType
         ' 
         Me._lblPixelType.Location = New System.Drawing.Point(8, 32)
         Me._lblPixelType.Name = "_lblPixelType"
         Me._lblPixelType.Size = New System.Drawing.Size(64, 23)
         Me._lblPixelType.TabIndex = 0
         Me._lblPixelType.Text = "Pixel Type:"
         ' 
         ' _btnLoad
         ' 
         Me._btnLoad.Location = New System.Drawing.Point(167, 256)
         Me._btnLoad.Name = "_btnLoad"
         Me._btnLoad.Size = New System.Drawing.Size(75, 23)
         Me._btnLoad.TabIndex = 5
         Me._btnLoad.Text = "Load"
         ' 
         ' _btnSave
         ' 
         Me._btnSave.Location = New System.Drawing.Point(247, 256)
         Me._btnSave.Name = "_btnSave"
         Me._btnSave.Size = New System.Drawing.Size(75, 23)
         Me._btnSave.TabIndex = 6
         Me._btnSave.Text = "Save"
         ' 
         ' _btnOK
         ' 
         Me._btnOK.Location = New System.Drawing.Point(327, 256)
         Me._btnOK.Name = "_btnOK"
         Me._btnOK.Size = New System.Drawing.Size(75, 23)
         Me._btnOK.TabIndex = 7
         Me._btnOK.Text = "OK"
         ' 
         ' _btnCancel
         ' 
         Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
         Me._btnCancel.Location = New System.Drawing.Point(407, 256)
         Me._btnCancel.Name = "_btnCancel"
         Me._btnCancel.Size = New System.Drawing.Size(75, 23)
         Me._btnCancel.TabIndex = 8
         Me._btnCancel.Text = "Cancel"
         ' 
         ' Template
         ' 
         Me.AcceptButton = Me._btnOK
         Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
         Me.CancelButton = Me._btnCancel
         Me.ClientSize = New System.Drawing.Size(648, 286)
         Me.Controls.Add(Me._btnCancel)
         Me.Controls.Add(Me._btnOK)
         Me.Controls.Add(Me._btnSave)
         Me.Controls.Add(Me._btnLoad)
         Me.Controls.Add(Me._gbImgeEfx)
         Me.Controls.Add(Me._gbMemoryOptions)
         Me.Controls.Add(Me._gbFileOptions)
         Me.Controls.Add(Me._gbTransferMode)
         Me.Controls.Add(Me._gbImageFrame)
         Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
         Me.Icon = (CType(resources.GetObject("$this.Icon"), System.Drawing.Icon))
         Me.Name = "Template"
         Me.Text = "LEAD Template"
         Me._gbImageFrame.ResumeLayout(False)
         Me._gbImageFrame.PerformLayout()
         Me._gbTransferMode.ResumeLayout(False)
         Me._gbFileOptions.ResumeLayout(False)
         Me._gbFileOptions.PerformLayout()
         Me._gbMemoryOptions.ResumeLayout(False)
         Me._gbImgeEfx.ResumeLayout(False)
         Me.ResumeLayout(False)

      End Sub
#End Region

      Public _twainSession As TwainSession = Nothing
      Public _transferMode As TwainCapabilityValue = TwainCapabilityValue.TransferMechanismNative
      Private _unitsValue As TwainCapabilityValue()
      Private _pixelValue As TwainCapabilityValue()
      Private _orientationValue As TwainCapabilityValue()
      Private _compressionValue As TwainCapabilityValue()
      Private _formatValue As TwainFileFormat()
      Private _openInitialPath As String = String.Empty

      Private Sub Template_Load(ByVal sender As Object, ByVal e As System.EventArgs)Handles Me.Load
         InitializeTemplate()
      End Sub

      Private Sub InitializeTemplate()
         _unitsValue = New TwainCapabilityValue(5) {}
         _pixelValue = New TwainCapabilityValue(8) {}
         _orientationValue = New TwainCapabilityValue(3) {}
         _compressionValue = New TwainCapabilityValue(13) {}
         _formatValue = New TwainFileFormat(9) {}

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
         ' ICAP_UNITS 
         _cmbUnit.Items.Clear()

         Try
            Dim twnCap As TwainCapability = _twainSession.GetCapability(TwainCapabilityType.ImageUnits, TwainGetCapabilityMode.GetValues)
            _cmbUnit.Enabled = True

            Select Case twnCap.Information.ContainerType
               Case TwainContainerType.OneValue
                  Dim item As Object = twnCap.OneValueCapability.Value
                  Dim itemValue As TwainCapabilityValue = CType(Convert.ToUInt16(item), TwainCapabilityValue)
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
                  Exit Select
               Case TwainContainerType.Enumeration
                  Dim itemsCount As Integer = twnCap.EnumerationCapability.Count
                  Dim i As Integer = 0
                  Do While i < itemsCount
                     Dim item As Object = twnCap.EnumerationCapability.GetValue(i)
                     Dim itemValue As TwainCapabilityValue = CType(Convert.ToUInt16(item), TwainCapabilityValue)
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
                     i += 1
                  Loop

                  _cmbUnit.SelectedIndex = twnCap.EnumerationCapability.CurrentIndex
                  Exit Select
            End Select
         Catch
            _cmbUnit.Enabled = False
         End Try
      End Sub

      Private Sub FillFrameCaps()
         ' ICAP_FRAMES 
         _txtFrameLeft.Text = ""
         _txtFrameTop.Text = ""
         _txtFrameRight.Text = ""
         _txtFrameBottom.Text = ""

         Try
            Dim twnCap As TwainCapability = _twainSession.GetCapability(TwainCapabilityType.ImageFrames, TwainGetCapabilityMode.GetCurrent)

            _txtFrameLeft.Enabled = True
            _txtFrameTop.Enabled = True
            _txtFrameRight.Enabled = True
            _txtFrameBottom.Enabled = True

            Dim twnFrame As TwainFrame = New TwainFrame()
            Dim item As Object = twnCap.OneValueCapability.Value
            twnFrame = CType(item, TwainFrame)

            _txtFrameLeft.Text = twnFrame.LeftMargin.ToString()
            _txtFrameTop.Text = twnFrame.TopMargin.ToString()
            _txtFrameRight.Text = twnFrame.RightMargin.ToString()
            _txtFrameBottom.Text = twnFrame.BottomMargin.ToString()
         Catch
            _txtFrameLeft.Enabled = False
            _txtFrameTop.Enabled = False
            _txtFrameRight.Enabled = False
            _txtFrameBottom.Enabled = False
         End Try
      End Sub

      Private Sub FillXYRes()
         ' ICAP_XRESOLUTION and ICAP_YRESOLUTION 
         _cmbXRes.Items.Clear()
         _cmbYRes.Items.Clear()

         ' ICAP_XRESOLUTION 
         Try
            Dim twnCap As TwainCapability = _twainSession.GetCapability(TwainCapabilityType.ImageXResolution, TwainGetCapabilityMode.GetValues)
            _cmbXRes.Enabled = True

            Select Case twnCap.Information.ContainerType
               Case TwainContainerType.OneValue
                  Dim item As Object = twnCap.OneValueCapability.Value
                  Dim fix32Value As Single = CSng(Convert.ToDouble(item))
                  _cmbXRes.Items.Add(fix32Value.ToString())

                  _cmbXRes.SelectedIndex = 0
                  Exit Select
               Case TwainContainerType.Enumeration
                  Dim item As Object
                  Dim fix32Value As Single

                  Dim itemsCount As Integer = twnCap.EnumerationCapability.Count
                  Dim i As Integer = 0
                  Do While i < itemsCount
                     item = twnCap.EnumerationCapability.GetValue(i)
                     fix32Value = CSng(Convert.ToDouble(item))
                     _cmbXRes.Items.Add(fix32Value.ToString())
                     i += 1
                  Loop

                  _cmbXRes.SelectedIndex = twnCap.EnumerationCapability.CurrentIndex
                  Exit Select
               Case TwainContainerType.Range
                  Dim minValue As Single = CSng(Convert.ToDouble(twnCap.RangeCapability.MinimumValue))
                  Dim maxValue As Single = CSng(Convert.ToDouble(twnCap.RangeCapability.MaximumValue))
                  Dim stepSize As Single = CSng(Convert.ToDouble(twnCap.RangeCapability.StepSize))
                  Dim currentValue As Single = CSng(Convert.ToDouble(twnCap.RangeCapability.CurrentValue))

                  Dim i As Integer = 0
                  Dim selIndex As Integer = 0

                  _cmbXRes.Items.Add(minValue.ToString())
                  If minValue = currentValue Then
                     selIndex = i
                  End If

                  Dim tempValue As Single = minValue + stepSize
                  Do While tempValue <= maxValue
                     i += 1
                     _cmbXRes.Items.Add(tempValue.ToString())
                     If tempValue = currentValue Then
                        selIndex = i
                     End If

                     tempValue = tempValue + stepSize
                  Loop

                  _cmbXRes.SelectedIndex = selIndex
                  Exit Select
            End Select
         Catch
            _cmbXRes.Enabled = False
         End Try

         ' ICAP_YRESOLUTION 
         Try
            Dim twnCap As TwainCapability = _twainSession.GetCapability(TwainCapabilityType.ImageYResolution, TwainGetCapabilityMode.GetValues)
            _cmbYRes.Enabled = True

            Select Case twnCap.Information.ContainerType
               Case TwainContainerType.OneValue
                  Dim item As Object = twnCap.OneValueCapability.Value
                  Dim fix32Value As Single = CSng(Convert.ToDouble(item))
                  _cmbYRes.Items.Add(fix32Value.ToString())

                  _cmbYRes.SelectedIndex = 0
                  Exit Select
               Case TwainContainerType.Enumeration
                  Dim item As Object
                  Dim fix32Value As Single

                  Dim itemsCount As Integer = twnCap.EnumerationCapability.Count
                  Dim i As Integer = 0
                  Do While i < itemsCount
                     item = twnCap.EnumerationCapability.GetValue(i)
                     fix32Value = CSng(Convert.ToDouble(item))
                     _cmbYRes.Items.Add(fix32Value.ToString())
                     i += 1
                  Loop

                  _cmbYRes.SelectedIndex = twnCap.EnumerationCapability.CurrentIndex
                  Exit Select
               Case TwainContainerType.Range
                  Dim minValue As Single = CSng(Convert.ToDouble(twnCap.RangeCapability.MinimumValue))
                  Dim maxValue As Single = CSng(Convert.ToDouble(twnCap.RangeCapability.MaximumValue))
                  Dim stepSize As Single = CSng(Convert.ToDouble(twnCap.RangeCapability.StepSize))
                  Dim currentValue As Single = CSng(Convert.ToDouble(twnCap.RangeCapability.CurrentValue))

                  Dim i As Integer = 0
                  Dim selIndex As Integer = 0

                  _cmbYRes.Items.Add(minValue.ToString())
                  If minValue = currentValue Then
                     selIndex = i
                  End If

                  Dim tempValue As Single = minValue + stepSize
                  Do While tempValue <= maxValue
                     i += 1
                     _cmbYRes.Items.Add(tempValue.ToString())
                     If tempValue = currentValue Then
                        selIndex = i
                     End If

                     tempValue = tempValue + stepSize
                  Loop

                  _cmbYRes.SelectedIndex = selIndex
                  Exit Select
            End Select
         Catch
            _cmbYRes.Enabled = False
         End Try
      End Sub

      Private Sub FillTransferMode()
         Dim fileMode, nativeMode, memoryMode As Boolean

         _rdFile.Checked = False
         _rdMemory.Checked = False
         _rdNative.Checked = False
         fileMode = nativeMode = memoryMode = False

         ' ICAP_XFERMECH 
         Try
            Dim twnCap As TwainCapability = _twainSession.GetCapability(TwainCapabilityType.ImageTransferMechanism, TwainGetCapabilityMode.GetValues)

            Select Case twnCap.Information.ContainerType
               Case TwainContainerType.OneValue
                  Dim item As Object = twnCap.OneValueCapability.Value
                  Dim itemValue As TwainCapabilityValue = CType(Convert.ToUInt16(item), TwainCapabilityValue)
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

                  Exit Select
               Case TwainContainerType.Enumeration
                  Dim itemsCount As Integer = twnCap.EnumerationCapability.Count
                  Dim i As Integer = 0
                  Do While i < itemsCount
                     Dim item As Object = twnCap.EnumerationCapability.GetValue(i)
                     Dim itemValue As TwainCapabilityValue = CType(Convert.ToUInt16(item), TwainCapabilityValue)
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
                     i += 1
                  Loop
                  Exit Select
            End Select
         Catch
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

         Dim twnTransferModeCap As TwainCapability = _twainSession.GetCapability(TwainCapabilityType.ImageTransferMechanism, TwainGetCapabilityMode.GetCurrent)
         Select Case CType(twnTransferModeCap.OneValueCapability.Value, TwainCapabilityValue)
            Case TwainCapabilityValue.TransferMechanismFile
               EnableFileMode()
            Case TwainCapabilityValue.TransferMechanismMemory
               EnableMemoryMode()
            Case TwainCapabilityValue.TransferMechanismNative
               EnableNativeMode()
         End Select
      End Sub

      Private Sub EnableFileMode()
         _transferMode = TwainCapabilityValue.TransferMechanismFile

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
         ' ICAP_IMAGEFILEFORMAT 

         Try
            Dim twnCap As TwainCapability = _twainSession.GetCapability(TwainCapabilityType.ImageImageFileFormat, TwainGetCapabilityMode.GetValues)

            _txtFileName.Enabled = True
            _btnBrowse.Enabled = True
            _cmbFileFormat.Enabled = True
            _cmbFileFormat.Items.Clear()

            Select Case twnCap.Information.ContainerType
               Case TwainContainerType.OneValue
                  Dim item As Object = twnCap.OneValueCapability.Value
                  Dim itemValue As TwainFileFormat = CType(Convert.ToUInt16(item), TwainFileFormat)
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

                  _cmbFileFormat.SelectedIndex = 0
                  _formatValue(0) = itemValue
                  Exit Select
               Case TwainContainerType.Enumeration
                  Dim itemsCount As Integer = twnCap.EnumerationCapability.Count
                  Dim i As Integer = 0
                  Do While i < itemsCount
                     Dim item As Object = twnCap.EnumerationCapability.GetValue(i)
                     Dim itemValue As TwainFileFormat = CType(Convert.ToUInt16(item), TwainFileFormat)
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
                     i += 1
                  Loop

                  _cmbFileFormat.SelectedIndex = twnCap.EnumerationCapability.CurrentIndex
                  Exit Select
            End Select
         Catch
            ' disable all file modes controls 
            _txtFileName.Enabled = False
            _btnBrowse.Enabled = False
            _cmbFileFormat.Enabled = False
         End Try
      End Sub

      Private Sub EnableMemoryMode()
         _transferMode = TwainCapabilityValue.TransferMechanismMemory

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
         ' ICAP_COMPRESSION 

         Try
            Dim twnCap As TwainCapability = _twainSession.GetCapability(TwainCapabilityType.ImageCompression, TwainGetCapabilityMode.GetValues)

            _cmbCompression.Enabled = True
            _cmbCompression.Items.Clear()

            Select Case twnCap.Information.ContainerType
               Case TwainContainerType.OneValue
                  Dim item As Object = twnCap.OneValueCapability.Value
                  Dim itemValue As TwainCapabilityValue = CType(Convert.ToUInt16(item), TwainCapabilityValue)
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

                  _cmbCompression.SelectedIndex = 0
                  _compressionValue(0) = itemValue
                  Exit Select
               Case TwainContainerType.Enumeration
                  Dim itemsCount As Integer = twnCap.EnumerationCapability.Count
                  Dim i As Integer = 0
                  Do While i < itemsCount
                     Dim item As Object = twnCap.EnumerationCapability.GetValue(i)
                     Dim itemValue As TwainCapabilityValue = CType(Convert.ToUInt16(item), TwainCapabilityValue)
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
                     i += 1
                  Loop

                  _cmbCompression.SelectedIndex = twnCap.EnumerationCapability.CurrentIndex
                  Exit Select
            End Select
         Catch
            _cmbCompression.Enabled = False
         End Try
      End Sub

      Private Sub EnableNativeMode()
         _transferMode = TwainCapabilityValue.TransferMechanismNative

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
            If _txtFrameLeft.Text.Length = 0 OrElse _txtFrameTop.Text.Length = 0 OrElse _txtFrameRight.Text.Length = 0 OrElse _txtFrameBottom.Text.Length = 0 Then
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

      Private Sub _rdFile_Click(ByVal sender As Object, ByVal e As System.EventArgs)Handles _rdFile.Click
         EnableFileMode()
      End Sub

      Private Sub _rdMemory_Click(ByVal sender As Object, ByVal e As System.EventArgs)Handles _rdMemory.Click
         EnableMemoryMode()
      End Sub

      Private Sub _rdNative_Click(ByVal sender As Object, ByVal e As System.EventArgs)Handles _rdNative.Click
         EnableNativeMode()
      End Sub

      Private Sub FillPixelType()
         ' ICAP_PIXELTYPE 
         Try
            Dim twnCap As TwainCapability = _twainSession.GetCapability(TwainCapabilityType.ImagePixelType, TwainGetCapabilityMode.GetValues)

            _cmbPixelType.Enabled = True
            _cmbPixelType.Items.Clear()

            Select Case twnCap.Information.ContainerType
               Case TwainContainerType.OneValue
                  Dim item As Object = twnCap.OneValueCapability.Value
                  Dim itemValue As TwainCapabilityValue = CType(Convert.ToUInt16(item), TwainCapabilityValue)
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
                  Exit Select
               Case TwainContainerType.Enumeration
                  Dim itemsCount As Integer = twnCap.EnumerationCapability.Count
                  Dim i As Integer = 0
                  Do While i < itemsCount
                     Dim item As Object = twnCap.EnumerationCapability.GetValue(i)
                     Dim itemValue As TwainCapabilityValue = CType(Convert.ToUInt16(item), TwainCapabilityValue)
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
                     i += 1
                  Loop

                  _cmbPixelType.SelectedIndex = twnCap.EnumerationCapability.CurrentIndex
                  Exit Select
            End Select
         Catch
            _cmbPixelType.Enabled = False
         End Try
      End Sub

      Private Sub FillOrientation()
         ' ICAP_ORIENTATION 
         Try
            Dim twnCap As TwainCapability = _twainSession.GetCapability(TwainCapabilityType.ImageOrientation, TwainGetCapabilityMode.GetValues)

            _cmbOrientation.Enabled = True
            _cmbOrientation.Items.Clear()

            Select Case twnCap.Information.ContainerType
               Case TwainContainerType.OneValue
                  Dim item As Object = twnCap.OneValueCapability.Value
                  Dim itemValue As TwainCapabilityValue = CType(Convert.ToUInt16(item), TwainCapabilityValue)
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
                  Exit Select
               Case TwainContainerType.Enumeration
                  Dim itemsCount As Integer = twnCap.EnumerationCapability.Count
                  Dim i As Integer = 0
                  Do While i < itemsCount
                     Dim item As Object = twnCap.EnumerationCapability.GetValue(i)
                     Dim itemValue As TwainCapabilityValue = CType(Convert.ToUInt16(item), TwainCapabilityValue)
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
                     i += 1
                  Loop

                  _cmbOrientation.SelectedIndex = twnCap.EnumerationCapability.CurrentIndex
                  Exit Select
            End Select
         Catch
            _cmbOrientation.Enabled = False
         End Try
      End Sub

      Private Sub FillEffectsCap(ByVal capType As TwainCapabilityType)
         ' ICAP_CONTRAST, ICAP_BRIGHTNESS, ICAP_HIGHLIGHT 
         Try
            Dim twnCap As TwainCapability = _twainSession.GetCapability(capType, TwainGetCapabilityMode.GetValues)

            Dim tempCombo As ComboBox = New ComboBox()
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
                  Dim fix32Value As Single = CSng(Convert.ToDouble(item))
                  tempCombo.Items.Add(fix32Value.ToString())

                  tempCombo.SelectedIndex = 0
                  Exit Select
               Case TwainContainerType.Enumeration
                  Dim item As Object
                  Dim fix32Value As Single

                  Dim itemsCount As Integer = twnCap.EnumerationCapability.Count
                  Dim i As Integer = 0
                  Do While i < itemsCount
                     item = twnCap.EnumerationCapability.GetValue(i)
                     fix32Value = CSng(Convert.ToDouble(item))
                     tempCombo.Items.Add(fix32Value.ToString())
                     i += 1
                  Loop

                  tempCombo.SelectedIndex = twnCap.EnumerationCapability.CurrentIndex
                  Exit Select
               Case TwainContainerType.Range
                  Dim minValue As Single = CSng(Convert.ToDouble(twnCap.RangeCapability.MinimumValue))
                  Dim maxValue As Single = CSng(Convert.ToDouble(twnCap.RangeCapability.MaximumValue))
                  Dim stepSize As Single = CSng(Convert.ToDouble(twnCap.RangeCapability.StepSize))
                  Dim currentValue As Single = CSng(Convert.ToDouble(twnCap.RangeCapability.CurrentValue))

                  Dim i As Integer = 0
                  Dim selIndex As Integer = 0

                  tempCombo.Items.Add(minValue.ToString())
                  If minValue = currentValue Then
                     selIndex = i
                  End If

                  Dim tempValue As Single = minValue + stepSize
                  Do While tempValue <= maxValue
                     i += 1
                     tempCombo.Items.Add(tempValue.ToString())
                     If tempValue = currentValue Then
                        selIndex = i
                     End If

                     tempValue = tempValue + stepSize
                  Loop

                  tempCombo.SelectedIndex = selIndex
                  Exit Select
            End Select
         Catch
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
         ' ICAP_HALFTONES 
         Try
            Dim twnCap As TwainCapability = _twainSession.GetCapability(TwainCapabilityType.ImageHalftones, TwainGetCapabilityMode.GetValues)
            _cmbHalftone.Enabled = True

            Select Case twnCap.Information.ContainerType
               Case TwainContainerType.OneValue
                  Dim item As Object
                  Dim stringValue As String

                  item = twnCap.OneValueCapability.Value
                  stringValue = CStr(Convert.ToString(item))
                  _cmbHalftone.Items.Add(stringValue)
                  _cmbHalftone.SelectedIndex = 0
                  Exit Select
               Case TwainContainerType.Enumeration
                  Dim item As Object
                  Dim stringValue As String

                  Dim itemsCount As Integer = twnCap.EnumerationCapability.Count
                  Dim i As Integer = 0
                  Do While i < itemsCount
                     item = twnCap.EnumerationCapability.GetValue(i)
                     stringValue = CStr(Convert.ToString(item))
                     _cmbHalftone.Items.Add(stringValue)
                     i += 1
                  Loop

                  _cmbHalftone.SelectedIndex = twnCap.EnumerationCapability.CurrentIndex
                  Exit Select
               Case TwainContainerType.Array
                  Dim item As Object
                  Dim stringValue As String

                  Dim itemsCount As Integer = twnCap.ArrayCapability.Count
                  Dim i As Integer = 0
                  Do While i < itemsCount
                     item = twnCap.ArrayCapability.GetValue(i)
                     stringValue = CStr(Convert.ToString(item))
                     _cmbHalftone.Items.Add(stringValue)
                     i += 1
                  Loop

                  _cmbHalftone.SelectedIndex = 0
                  Exit Select
            End Select
         Catch
            _cmbHalftone.Enabled = False
         End Try
      End Sub

      Private Function GetFileFormatString() As String
         Dim filter As String = "All Files (*.*)|*.*"
         Select Case _formatValue(_cmbFileFormat.SelectedIndex)
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

      Private Sub _btnBrowse_Click(ByVal sender As Object, ByVal e As System.EventArgs)Handles _btnBrowse.Click
         Using saveDialog As SaveFileDialog = New SaveFileDialog()
            saveDialog.Filter = GetFileFormatString()
            saveDialog.FilterIndex = 0

            If saveDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
               _txtFileName.Text = saveDialog.FileName
            End If

            DialogResult = DialogResult.None
         End Using
      End Sub

      Private Sub _btnLoad_Click(ByVal sender As Object, ByVal e As System.EventArgs)Handles _btnLoad.Click
         Using openDialog As OpenFileDialog = New OpenFileDialog()
            openDialog.Filter = "LEAD Twain Template Files (*.ltt)|*.ltt"
            openDialog.FilterIndex = 0
            openDialog.InitialDirectory = _openInitialPath
            If openDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
               Try
                  _openInitialPath = Path.GetDirectoryName(openDialog.FileName)
                  _twainSession.LoadTemplateFile(openDialog.FileName)
                  InitializeTemplate()
               Catch ex As Exception
                  Messager.ShowError(Me, ex)
               End Try
            End If

            DialogResult = DialogResult.None
         End Using
      End Sub

      Private Sub _btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs)Handles _btnSave.Click
         Using saveDialog As SaveFileDialog = New SaveFileDialog()
            saveDialog.Filter = "LEAD Twain Template Files (*.ltt)|*.ltt"
            saveDialog.FilterIndex = 0

            If saveDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
               Try
                  SetCapabilities()
                  _twainSession.SaveTemplateFile(saveDialog.FileName)
               Catch ex As Exception
                  Messager.ShowError(Me, ex)
               End Try
            End If

            DialogResult = DialogResult.None
         End Using
      End Sub

      Private Sub _btnOK_Click(ByVal sender As Object, ByVal e As System.EventArgs)Handles _btnOK.Click
         SetCapabilities()
         DialogResult = System.Windows.Forms.DialogResult.OK
      End Sub


      Private Sub SetCapabilities()
         SetUnitsCapability()
         SetXYResCapability()
         SetXferCapability()
         SetPixelTypeCapability()
         SetOrientationCapability()
         SetFramesCapability()
         SetHalftoneCapability()
         SetContrastCapability()
         SetBrightnessCapability()
         SetHighlightCapability()
      End Sub

      Private Sub MySetCapability(ByVal capType As TwainCapabilityType, ByVal itemType As TwainItemType, ByVal data As Object)
         Using twnCap As TwainCapability = New TwainCapability()
            Try
               twnCap.Information.Type = capType
               twnCap.Information.ContainerType = TwainContainerType.OneValue

               twnCap.OneValueCapability.ItemType = itemType
               twnCap.OneValueCapability.Value = data

               _twainSession.SetCapability(twnCap, TwainSetCapabilityMode.Set)
            Catch
            End Try
         End Using
      End Sub

      Private Sub SetUnitsCapability()
         Try
            MySetCapability(TwainCapabilityType.ImageUnits, TwainItemType.Uint16, _unitsValue(_cmbUnit.SelectedIndex))
         Catch
         End Try
      End Sub

      Private Sub SetFramesCapability()
         Try
            Dim frame As TwainFrame = New TwainFrame()

            frame.LeftMargin = CSng(Convert.ToDouble(_txtFrameLeft.Text))
            frame.TopMargin = CSng(Convert.ToDouble(_txtFrameTop.Text))
            frame.RightMargin = CSng(Convert.ToDouble(_txtFrameRight.Text))
            frame.BottomMargin = CSng(Convert.ToDouble(_txtFrameBottom.Text))

            MySetCapability(TwainCapabilityType.ImageFrames, TwainItemType.Frame, frame)
         Catch
         End Try
      End Sub

      Private Sub SetXYResCapability()
         Try
            Dim xRes As Single = CSng(Convert.ToDouble(_cmbXRes.SelectedItem))
            Dim yRes As Single = CSng(Convert.ToDouble(_cmbYRes.SelectedItem))

            MySetCapability(TwainCapabilityType.ImageXResolution, TwainItemType.Fix32, xRes)
            MySetCapability(TwainCapabilityType.ImageYResolution, TwainItemType.Fix32, yRes)
         Catch
         End Try
      End Sub

      Private Sub SetXferCapability()
         Try
            MySetCapability(TwainCapabilityType.ImageTransferMechanism, TwainItemType.Uint16, _transferMode)
         Catch
            Return
         End Try

         Select Case _transferMode
            Case TwainCapabilityValue.TransferMechanismNative
               ' do nothing 
            Case TwainCapabilityValue.TransferMechanismMemory
               Try
                  ' ICAP_COMPRESSION 
                  MySetCapability(TwainCapabilityType.ImageCompression, TwainItemType.Uint16, _compressionValue(_cmbCompression.SelectedIndex))
               Catch
               End Try
            Case TwainCapabilityValue.TransferMechanismFile
               If _txtFileName.Text = "" Then
                  Return
               End If

               Try
                  ' ICAP_IMAGEFILEFORMAT 
                  MySetCapability(TwainCapabilityType.ImageImageFileFormat, TwainItemType.Uint16, _formatValue(_cmbFileFormat.SelectedIndex))
               Catch
                  Return
               End Try

               Try
                  Dim twnProps As TwainProperties = _twainSession.Properties
                  Dim dataTransfer As TwainDataTransferProperties = twnProps.DataTransfer
                  dataTransfer.FileName = _txtFileName.Text
                  dataTransfer.ScanFileFormat = _formatValue(_cmbFileFormat.SelectedIndex)
                  twnProps.DataTransfer = dataTransfer
                  _twainSession.Properties = twnProps
               Catch
               End Try
         End Select
      End Sub

      Private Sub SetPixelTypeCapability()
         Try
            MySetCapability(TwainCapabilityType.ImagePixelType, TwainItemType.Uint16, _pixelValue(_cmbPixelType.SelectedIndex))
         Catch
         End Try
      End Sub

      Private Sub SetOrientationCapability()
         Try
            MySetCapability(TwainCapabilityType.ImageOrientation, TwainItemType.Uint16, _orientationValue(_cmbOrientation.SelectedIndex))
         Catch
         End Try
      End Sub

      Private Sub SetHalftoneCapability()
         Try
            MySetCapability(TwainCapabilityType.ImageHalftones, TwainItemType.Str32, _cmbHalftone.Text)
         Catch
         End Try
      End Sub

      Private Sub SetContrastCapability()
         Try
            Dim contrast As Single = CSng(Convert.ToDouble(_cmbContrast.SelectedItem))
            MySetCapability(TwainCapabilityType.ImageContrast, TwainItemType.Fix32, contrast)
         Catch
         End Try
      End Sub

      Private Sub SetBrightnessCapability()
         Try
            Dim brightness As Single = CSng(Convert.ToDouble(_cmbBrightness.SelectedItem))
            MySetCapability(TwainCapabilityType.ImageBrightness, TwainItemType.Fix32, brightness)
         Catch
         End Try
      End Sub

      Private Sub SetHighlightCapability()
         Try
            Dim highlight As Single = CSng(Convert.ToDouble(_cmbHighlight.SelectedItem))
            MySetCapability(TwainCapabilityType.ImageHighlight, TwainItemType.Fix32, highlight)
         Catch
         End Try
      End Sub

      Private Sub _txtFileName_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)Handles _txtFileName.TextChanged
         CheckOkButton()
      End Sub
   End Class
End Namespace
