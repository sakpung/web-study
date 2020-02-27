' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Leadtools.Twain

Public Class SupportedCaps
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
   Friend WithEvents _gbCaps As System.Windows.Forms.GroupBox
   Friend WithEvents _lstCaps As System.Windows.Forms.ListBox
   Friend WithEvents _lblCapsCount As System.Windows.Forms.Label
   Friend WithEvents _lblCaps As System.Windows.Forms.Label
   Friend WithEvents _btnOk As System.Windows.Forms.Button
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(SupportedCaps))
      Me._gbCaps = New System.Windows.Forms.GroupBox
      Me._lstCaps = New System.Windows.Forms.ListBox
      Me._lblCapsCount = New System.Windows.Forms.Label
      Me._lblCaps = New System.Windows.Forms.Label
      Me._btnOk = New System.Windows.Forms.Button
      Me._gbCaps.SuspendLayout()
      Me.SuspendLayout()
      '
      '_gbCaps
      '
      Me._gbCaps.Controls.Add(Me._lstCaps)
      Me._gbCaps.Controls.Add(Me._lblCapsCount)
      Me._gbCaps.Controls.Add(Me._lblCaps)
      Me._gbCaps.Location = New System.Drawing.Point(8, 8)
      Me._gbCaps.Name = "_gbCaps"
      Me._gbCaps.Size = New System.Drawing.Size(296, 264)
      Me._gbCaps.TabIndex = 2
      Me._gbCaps.TabStop = False
      '
      '_lstCaps
      '
      Me._lstCaps.Location = New System.Drawing.Point(16, 40)
      Me._lstCaps.Name = "_lstCaps"
      Me._lstCaps.Size = New System.Drawing.Size(264, 212)
      Me._lstCaps.TabIndex = 2
      '
      '_lblCapsCount
      '
      Me._lblCapsCount.Location = New System.Drawing.Point(176, 16)
      Me._lblCapsCount.Name = "_lblCapsCount"
      Me._lblCapsCount.Size = New System.Drawing.Size(112, 16)
      Me._lblCapsCount.TabIndex = 1
      '
      '_lblCaps
      '
      Me._lblCaps.Location = New System.Drawing.Point(16, 16)
      Me._lblCaps.Name = "_lblCaps"
      Me._lblCaps.Size = New System.Drawing.Size(168, 16)
      Me._lblCaps.TabIndex = 0
      Me._lblCaps.Text = "Supported Capabilities Count = "
      '
      '_btnOk
      '
      Me._btnOk.Location = New System.Drawing.Point(112, 280)
      Me._btnOk.Name = "_btnOk"
      Me._btnOk.TabIndex = 3
      Me._btnOk.Text = "OK"
      '
      'SupportedCaps
      '
      Me.AcceptButton = Me._btnOk
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.ClientSize = New System.Drawing.Size(312, 310)
      Me.Controls.Add(Me._gbCaps)
      Me.Controls.Add(Me._btnOk)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "SupportedCaps"
      Me.Text = "Supported Capabilities"
      Me._gbCaps.ResumeLayout(False)
      Me.ResumeLayout(False)

   End Sub

#End Region
   Public caps As TwainCapabilityType()

   Private Sub SupportedCaps_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      Dim availableCapsCount As Integer = caps.Length
      Dim i As Integer

      For i = 0 To caps.Length - 1
         _lstCaps.Items.Add(caps(i).ToString())
         'Select Case caps(i)
         '   Case TwainCapabilityType.CustomBase
         '      _lstCaps.Items.Add("CAP_CUSTOMBASE")
         '   Case TwainCapabilityType.TransferCount
         '      _lstCaps.Items.Add("CAP_XFERCOUNT")
         '   Case TwainCapabilityType.ImageCompression
         '      _lstCaps.Items.Add("ICAP_COMPRESSION")
         '   Case TwainCapabilityType.ImagePixelType
         '      _lstCaps.Items.Add("ICAP_PIXELTYPE")
         '   Case TwainCapabilityType.ImageUnits
         '      _lstCaps.Items.Add("ICAP_UNITS")
         '   Case TwainCapabilityType.ImageTransferMechanism
         '      _lstCaps.Items.Add("ICAP_XFERMECH")
         '   Case TwainCapabilityType.Author
         '      _lstCaps.Items.Add("CAP_AUTHOR")
         '   Case TwainCapabilityType.Caption
         '      _lstCaps.Items.Add("CAP_CAPTION")
         '   Case TwainCapabilityType.FeederEnabled
         '      _lstCaps.Items.Add("CAP_FEEDERENABLED")
         '   Case TwainCapabilityType.FeederLoaded
         '      _lstCaps.Items.Add("CAP_FEEDERLOADED")
         '   Case TwainCapabilityType.TimeDate
         '      _lstCaps.Items.Add("CAP_TIMEDATE")
         '   Case TwainCapabilityType.SupportedCaps
         '      _lstCaps.Items.Add("CAP_SUPPORTEDCAPS")
         '   Case TwainCapabilityType.ExtendedCaps
         '      _lstCaps.Items.Add("CAP_EXTENDEDCAPS")
         '   Case TwainCapabilityType.AutoFeed
         '      _lstCaps.Items.Add("CAP_AUTOFEED")
         '   Case TwainCapabilityType.ClearPage
         '      _lstCaps.Items.Add("CAP_CLEARPAGE")
         '   Case TwainCapabilityType.FeedPage
         '      _lstCaps.Items.Add("CAP_FEEDPAGE")
         '   Case TwainCapabilityType.RewindPage
         '      _lstCaps.Items.Add("CAP_REWINDPAGE")
         '   Case TwainCapabilityType.Indicators
         '      _lstCaps.Items.Add("CAP_INDICATORS")
         '   Case TwainCapabilityType.SupportedCapsExt
         '      _lstCaps.Items.Add("CAP_SUPPORTEDCAPSEXT")
         '   Case TwainCapabilityType.PaperDetectable
         '      _lstCaps.Items.Add("CAP_PAPERDETECTABLE")
         '   Case TwainCapabilityType.UiControllable
         '      _lstCaps.Items.Add("CAP_UICONTROLLABLE")
         '   Case TwainCapabilityType.DeviceOnline
         '      _lstCaps.Items.Add("CAP_DEVICEONLINE")
         '   Case TwainCapabilityType.AutoScan
         '      _lstCaps.Items.Add("CAP_AUTOSCAN")
         '   Case TwainCapabilityType.ThumbnailsEnabled
         '      _lstCaps.Items.Add("CAP_THUMBNAILSENABLED")
         '   Case TwainCapabilityType.Duplex
         '      _lstCaps.Items.Add("CAP_DUPLEX")
         '   Case TwainCapabilityType.DuplexEnabled
         '      _lstCaps.Items.Add("CAP_DUPLEXENABLED")
         '   Case TwainCapabilityType.EnabledSuiOnly
         '      _lstCaps.Items.Add("CAP_ENABLEDSUIONLY")
         '   Case TwainCapabilityType.CustomDsData
         '      _lstCaps.Items.Add("CAP_CUSTOMDSDATA")
         '   Case TwainCapabilityType.EndOrser
         '      _lstCaps.Items.Add("CAP_ENDORSER")
         '   Case TwainCapabilityType.JobControl
         '      _lstCaps.Items.Add("CAP_JOBCONTROL")
         '   Case TwainCapabilityType.Alarms
         '      _lstCaps.Items.Add("CAP_ALARMS")
         '   Case TwainCapabilityType.AlarmVolume
         '      _lstCaps.Items.Add("CAP_ALARMVOLUME")
         '   Case TwainCapabilityType.AutomaticCapture
         '      _lstCaps.Items.Add("CAP_AUTOMATICCAPTURE")
         '   Case TwainCapabilityType.TimeBeforeFirstCapture
         '      _lstCaps.Items.Add("CAP_TIMEBEFOREFIRSTCAPTURE")
         '   Case TwainCapabilityType.TimeBetweenCaptures
         '      _lstCaps.Items.Add("CAP_TIMEBETWEENCAPTURES")
         '   Case TwainCapabilityType.ClearBuffers
         '      _lstCaps.Items.Add("CAP_CLEARBUFFERS")
         '   Case TwainCapabilityType.MaxBatchBuffers
         '      _lstCaps.Items.Add("CAP_MAXBATCHBUFFERS")
         '   Case TwainCapabilityType.DeviceTimeDate
         '      _lstCaps.Items.Add("CAP_DEVICETIMEDATE")
         '   Case TwainCapabilityType.PowerSupply
         '      _lstCaps.Items.Add("CAP_POWERSUPPLY")
         '   Case TwainCapabilityType.CameraPreviewUi
         '      _lstCaps.Items.Add("CAP_CAMERAPREVIEWUI")
         '   Case TwainCapabilityType.DeviceEvent
         '      _lstCaps.Items.Add("CAP_DEVICEEVENT")
         '   Case TwainCapabilityType.SerialNumber
         '      _lstCaps.Items.Add("CAP_SERIALNUMBER")
         '   Case TwainCapabilityType.Printer
         '      _lstCaps.Items.Add("CAP_PRINTER")
         '   Case TwainCapabilityType.PrinterEnabled
         '      _lstCaps.Items.Add("CAP_PRINTERENABLED")
         '   Case TwainCapabilityType.PrinterIndex
         '      _lstCaps.Items.Add("CAP_PRINTERINDEX")
         '   Case TwainCapabilityType.PrinterMode
         '      _lstCaps.Items.Add("CAP_PRINTERMODE")
         '   Case TwainCapabilityType.PrinterString
         '      _lstCaps.Items.Add("CAP_PRINTERSTRING")
         '   Case TwainCapabilityType.PrinterSuffix
         '      _lstCaps.Items.Add("CAP_PRINTERSUFFIX")
         '   Case TwainCapabilityType.Language
         '      _lstCaps.Items.Add("CAP_LANGUAGE")
         '   Case TwainCapabilityType.FeederAlignment
         '      _lstCaps.Items.Add("CAP_FEEDERALIGNMENT")
         '   Case TwainCapabilityType.FeederOrder
         '      _lstCaps.Items.Add("CAP_FEEDERORDER")
         '   Case TwainCapabilityType.ReAcquireAllowed
         '      _lstCaps.Items.Add("CAP_REACQUIREALLOWED")
         '   Case TwainCapabilityType.BatteryMinutes
         '      _lstCaps.Items.Add("CAP_BATTERYMINUTES")
         '   Case TwainCapabilityType.BatteryPercentage
         '      _lstCaps.Items.Add("CAP_BATTERYPERCENTAGE")
         '   Case TwainCapabilityType.ImageAutoBright
         '      _lstCaps.Items.Add("ICAP_AUTOBRIGHT")
         '   Case TwainCapabilityType.ImageBrightness
         '      _lstCaps.Items.Add("ICAP_BRIGHTNESS")
         '   Case TwainCapabilityType.ImageContrast
         '      _lstCaps.Items.Add("ICAP_CONTRAST")
         '   Case TwainCapabilityType.ImageCustHalftone
         '      _lstCaps.Items.Add("ICAP_CUSTHALFTONE")
         '   Case TwainCapabilityType.ImageExposureTime
         '      _lstCaps.Items.Add("ICAP_EXPOSURETIME")
         '   Case TwainCapabilityType.ImageFilter
         '      _lstCaps.Items.Add("ICAP_FILTER")
         '   Case TwainCapabilityType.ImageFlashUsed
         '      _lstCaps.Items.Add("ICAP_FLASHUSED")
         '   Case TwainCapabilityType.ImageGamma
         '      _lstCaps.Items.Add("ICAP_GAMMA")
         '   Case TwainCapabilityType.ImageHalftones
         '      _lstCaps.Items.Add("ICAP_HALFTONES")
         '   Case TwainCapabilityType.ImageHighLight
         '      _lstCaps.Items.Add("ICAP_HIGHLIGHT")
         '   Case TwainCapabilityType.ImageImageFileFormat
         '      _lstCaps.Items.Add("ICAP_IMAGEFILEFORMAT")
         '   Case TwainCapabilityType.ImageLampState
         '      _lstCaps.Items.Add("ICAP_LAMPSTATE")
         '   Case TwainCapabilityType.ImageLightSource
         '      _lstCaps.Items.Add("ICAP_LIGHTSOURCE")
         '   Case TwainCapabilityType.ImageOrientation
         '      _lstCaps.Items.Add("ICAP_ORIENTATION")
         '   Case TwainCapabilityType.ImagePhysicalWidth
         '      _lstCaps.Items.Add("ICAP_PHYSICALWIDTH")
         '   Case TwainCapabilityType.ImagePhysicalHeight
         '      _lstCaps.Items.Add("ICAP_PHYSICALHEIGHT")
         '   Case TwainCapabilityType.ImageShadow
         '      _lstCaps.Items.Add("ICAP_SHADOW")
         '   Case TwainCapabilityType.ImageFrames
         '      _lstCaps.Items.Add("ICAP_FRAMES")
         '   Case TwainCapabilityType.ImageXNativeResolution
         '      _lstCaps.Items.Add("ICAP_XNATIVERESOLUTION")
         '   Case TwainCapabilityType.ImageYNativeResolution
         '      _lstCaps.Items.Add("ICAP_YNATIVERESOLUTION")
         '   Case TwainCapabilityType.ImageXResolution
         '      _lstCaps.Items.Add("ICAP_XRESOLUTION")
         '   Case TwainCapabilityType.ImageYResolution
         '      _lstCaps.Items.Add("ICAP_YRESOLUTION")
         '   Case TwainCapabilityType.ImageMaxFrames
         '      _lstCaps.Items.Add("ICAP_MAXFRAMES")
         '   Case TwainCapabilityType.ImageTiles
         '      _lstCaps.Items.Add("ICAP_TILES")
         '   Case TwainCapabilityType.ImageBitOrder
         '      _lstCaps.Items.Add("ICAP_BITORDER")
         '   Case TwainCapabilityType.ImageCcittKFactor
         '      _lstCaps.Items.Add("ICAP_CCITTKFACTOR")
         '   Case TwainCapabilityType.ImageLightPath
         '      _lstCaps.Items.Add("ICAP_LIGHTPATH")
         '   Case TwainCapabilityType.ImagePixelFlavor
         '      _lstCaps.Items.Add("ICAP_PIXELFLAVOR")
         '   Case TwainCapabilityType.ImagePlanarChunky
         '      _lstCaps.Items.Add("ICAP_PLANARCHUNKY")
         '   Case TwainCapabilityType.ImageRotation
         '      _lstCaps.Items.Add("ICAP_ROTATION")
         '   Case TwainCapabilityType.ImageSupportedSizes
         '      _lstCaps.Items.Add("ICAP_SUPPORTEDSIZES")
         '   Case TwainCapabilityType.ImageThreshold
         '      _lstCaps.Items.Add("ICAP_THRESHOLD")
         '   Case TwainCapabilityType.ImageXScaling
         '      _lstCaps.Items.Add("ICAP_XSCALING")
         '   Case TwainCapabilityType.ImageYScaling
         '      _lstCaps.Items.Add("ICAP_YSCALING")
         '   Case TwainCapabilityType.ImageBitOrderCodes
         '      _lstCaps.Items.Add("ICAP_BITORDERCODES")
         '   Case TwainCapabilityType.ImagePixelFlavorCodes
         '      _lstCaps.Items.Add("ICAP_PIXELFLAVORCODES")
         '   Case TwainCapabilityType.ImageJpegPixelType
         '      _lstCaps.Items.Add("ICAP_JPEGPIXELTYPE")
         '   Case TwainCapabilityType.ImageTimeFill
         '      _lstCaps.Items.Add("ICAP_TIMEFILL")
         '   Case TwainCapabilityType.ImageBitDepth
         '      _lstCaps.Items.Add("ICAP_BITDEPTH")
         '   Case TwainCapabilityType.ImageBitDepthReduction
         '      _lstCaps.Items.Add("ICAP_BITDEPTHREDUCTION")
         '   Case TwainCapabilityType.ImageUndefinedImageSize
         '      _lstCaps.Items.Add("ICAP_UNDEFINEDIMAGESIZE")
         '   Case TwainCapabilityType.ImageImageDataSet
         '      _lstCaps.Items.Add("ICAP_IMAGEDATASET")
         '   Case TwainCapabilityType.ImageExtImageInfo
         '      _lstCaps.Items.Add("ICAP_EXTIMAGEINFO")
         '   Case TwainCapabilityType.ImageMinimumHeight
         '      _lstCaps.Items.Add("ICAP_MINIMUMHEIGHT")
         '   Case TwainCapabilityType.ImageMinimumWidth
         '      _lstCaps.Items.Add("ICAP_MINIMUMWIDTH")
         '   Case TwainCapabilityType.ImageFlipRotation
         '      _lstCaps.Items.Add("ICAP_FLIPROTATION")
         '   Case TwainCapabilityType.ImageBarcodeDetectionEnabled
         '      _lstCaps.Items.Add("ICAP_BARCODEDETECTIONENABLED")
         '   Case TwainCapabilityType.ImageSupportedBarcodeTypes
         '      _lstCaps.Items.Add("ICAP_SUPPORTEDBARCODETYPES")
         '   Case TwainCapabilityType.ImageBarcodeMaxSearchPriorities
         '      _lstCaps.Items.Add("ICAP_BARCODEMAXSEARCHPRIORITIES")
         '   Case TwainCapabilityType.ImageBarcodeSearchPriorities
         '      _lstCaps.Items.Add("ICAP_BARCODESEARCHPRIORITIES")
         '   Case TwainCapabilityType.ImageBarcodeSearchMode
         '      _lstCaps.Items.Add("ICAP_BARCODESEARCHMODE")
         '   Case TwainCapabilityType.ImageBarcodeMaxRetries
         '      _lstCaps.Items.Add("ICAP_BARCODEMAXRETRIES")
         '   Case TwainCapabilityType.ImageBarcodeTimeout
         '      _lstCaps.Items.Add("ICAP_BARCODETIMEOUT")
         '   Case TwainCapabilityType.ImageZoomFactor
         '      _lstCaps.Items.Add("ICAP_ZOOMFACTOR")
         '   Case TwainCapabilityType.ImagePatchCodeDetectionEnabled
         '      _lstCaps.Items.Add("ICAP_PATCHCODEDETECTIONENABLED")
         '   Case TwainCapabilityType.ImageSupportedPatchCodeTypes
         '      _lstCaps.Items.Add("ICAP_SUPPORTEDPATCHCODETYPES")
         '   Case TwainCapabilityType.ImagePatchCodeMaxSearchPriorities
         '      _lstCaps.Items.Add("ICAP_PATCHCODEMAXSEARCHPRIORITIES")
         '   Case TwainCapabilityType.ImagePatchCodeSearchPriorities
         '      _lstCaps.Items.Add("ICAP_PATCHCODESEARCHPRIORITIES")
         '   Case TwainCapabilityType.ImagePatchCodeSearchMode
         '      _lstCaps.Items.Add("ICAP_PATCHCODESEARCHMODE")
         '   Case TwainCapabilityType.ImagePatchCodeMaxRetries
         '      _lstCaps.Items.Add("ICAP_PATCHCODEMAXRETRIES")
         '   Case TwainCapabilityType.ImagePatchCodeTimeout
         '      _lstCaps.Items.Add("ICAP_PATCHCODETIMEOUT")
         '   Case TwainCapabilityType.ImageFlashUsed2
         '      _lstCaps.Items.Add("ICAP_FLASHUSED2")
         '   Case TwainCapabilityType.ImageImageFilter
         '      _lstCaps.Items.Add("ICAP_IMAGEFILTER")
         '   Case TwainCapabilityType.ImageNoiseFilter
         '      _lstCaps.Items.Add("ICAP_NOISEFILTER")
         '   Case TwainCapabilityType.ImageOverScan
         '      _lstCaps.Items.Add("ICAP_OVERSCAN")
         '   Case TwainCapabilityType.ImageAutomaticBorderDetection
         '      _lstCaps.Items.Add("ICAP_AUTOMATICBORDERDETECTION")
         '   Case TwainCapabilityType.ImageAutomaticDeskew
         '      _lstCaps.Items.Add("ICAP_AUTOMATICDESKEW")
         '   Case TwainCapabilityType.ImageAutomaticRotate
         '      _lstCaps.Items.Add("ICAP_AUTOMATICROTATE")
         '   Case TwainCapabilityType.ImageJpegQuality
         '      _lstCaps.Items.Add("ICAP_JPEGQUALITY")
         '   Case TwainCapabilityType.AudioAudioFileFormat
         '      _lstCaps.Items.Add("ACAP_AUDIOFILEFORMAT")
         '   Case TwainCapabilityType.AudioTransferMechanism
         '      _lstCaps.Items.Add("ACAP_XFERMECH")
         '   Case Else
         '      availableCapsCount = availableCapsCount - 1
         'End Select
      Next

      _lblCapsCount.Text = availableCapsCount.ToString()
   End Sub

   Private Sub _btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _btnOk.Click
      DialogResult = System.Windows.Forms.DialogResult.OK
   End Sub
End Class
