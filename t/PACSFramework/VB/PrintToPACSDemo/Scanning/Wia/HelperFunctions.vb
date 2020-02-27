' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports Leadtools.Wia

Namespace PrintToPACSDemo
   Friend Class HelperFunctions
      Private Shared _filter As String
      Private Shared _extension As String
      Private Shared _formatName As String
      Private Shared _propertyName As String
      Private Shared _propertyValueString As String
      Private Shared _listPropertyValueString As String
      Private Shared _format As WiaFileFormats

      Public Structure WiaSupportedFormatsInfo
         Private _format As WiaFileFormats
         Private _formatFilter As String
         Private _formatExtension As String

         Public Sub New(ByVal formatParam As WiaFileFormats, ByVal filterParam As String, ByVal extensionParam As String)
            _format = formatParam
            _formatFilter = filterParam
            _formatExtension = extensionParam
         End Sub

         Public Property Format() As WiaFileFormats
            Get
               Return _format
            End Get
            Set(ByVal value As WiaFileFormats)
               _format = value
            End Set
         End Property

         Public Property Filter() As String
            Get
               Return _formatFilter
            End Get
            Set(ByVal value As String)
               _formatFilter = value
            End Set
         End Property

         Public Property Extension() As String
            Get
               Return _formatExtension
            End Get
            Set(ByVal value As String)
               _formatExtension = value
            End Set
         End Property
      End Structure

      Public Shared ReadOnly _wiaFormatsInfo As WiaSupportedFormatsInfo() = {New WiaSupportedFormatsInfo(WiaFileFormats.MemoryBmp, "", ""), New WiaSupportedFormatsInfo(WiaFileFormats.Bmp, "BMP Files|*.bmp", "bmp"), New WiaSupportedFormatsInfo(WiaFileFormats.Ciff, "CIFF Files|*.iff", "iff"), New WiaSupportedFormatsInfo(WiaFileFormats.Emf, "EMF Files|*.emf", "emf"), New WiaSupportedFormatsInfo(WiaFileFormats.Exif, "EXIF Files|*.tif", "tif"), New WiaSupportedFormatsInfo(WiaFileFormats.Fpx, "FPX Files|*.fpx", "fpx"), New WiaSupportedFormatsInfo(WiaFileFormats.Gif, "GIF Files|*.gif", "gif"), New WiaSupportedFormatsInfo(WiaFileFormats.Ico, "ICO Files|*.ico", "ico"), New WiaSupportedFormatsInfo(WiaFileFormats.Jbig, "JBIG Files|*.jbg", "jbg"), New WiaSupportedFormatsInfo(WiaFileFormats.Jpeg, "JPEG Files|*.jpg", "jpg"), New WiaSupportedFormatsInfo(WiaFileFormats.J2k, "JPEG2K Files|*.j2k", "j2k"), New WiaSupportedFormatsInfo(WiaFileFormats.J2kx, "JPEG2KX Files|*.j2k", "j2k"), New WiaSupportedFormatsInfo(WiaFileFormats.Pcd, "PCD Files|*.pcd", "pcd"), New WiaSupportedFormatsInfo(WiaFileFormats.Pct, "PCT Files|*.pct", "pct"), New WiaSupportedFormatsInfo(WiaFileFormats.Png, "PNG Files|*.png", "png"), New WiaSupportedFormatsInfo(WiaFileFormats.Raw, "RAW Files|*.raw", "raw"), New WiaSupportedFormatsInfo(WiaFileFormats.RawRgb, "RAWRGB Files|*.raw", "raw"), New WiaSupportedFormatsInfo(WiaFileFormats.Tiff, "TIFF Files|*.tif", "tif"), New WiaSupportedFormatsInfo(WiaFileFormats.Wmf, "WMF Files|*.wmf", "wmf"), New WiaSupportedFormatsInfo(WiaFileFormats.Rtf, "RTF Files|*.rtf", "rtf"), New WiaSupportedFormatsInfo(WiaFileFormats.Xml, "XML Files|*.xml", "xml"), New WiaSupportedFormatsInfo(WiaFileFormats.Html, "HTML Files|*.htm", "htm"), New WiaSupportedFormatsInfo(WiaFileFormats.Txt, "TXT Files|*.txt", "txt"), New WiaSupportedFormatsInfo(WiaFileFormats.Pdfa, "PDFA Files|*.pdf", "pdf"), New WiaSupportedFormatsInfo(WiaFileFormats.Xps, "XPS Files|*.xps", "xps"), New WiaSupportedFormatsInfo(WiaFileFormats.Mpg, "MPEG Files|*.mpg", "mpg"), New WiaSupportedFormatsInfo(WiaFileFormats.Avi, "AVI Files|*.avi", "avi"), New WiaSupportedFormatsInfo(WiaFileFormats.Wav, "WAV Files|*.wav", "wav"), New WiaSupportedFormatsInfo(WiaFileFormats.Mp3, "MP3 Files|*.mp3", "mp3"), New WiaSupportedFormatsInfo(WiaFileFormats.Aiff, "AIFF Files|*.iff", "iff"), New WiaSupportedFormatsInfo(WiaFileFormats.Wma, "WMA Files|*.wma", "wma"), New WiaSupportedFormatsInfo(WiaFileFormats.Asf, "ASF Files|*.asf", "asf"), New WiaSupportedFormatsInfo(WiaFileFormats.Script, "SCRIPT Files|*.ps", "ps"), New WiaSupportedFormatsInfo(WiaFileFormats.Exec, "EXEC Files|*.exe", "exe"), New WiaSupportedFormatsInfo(WiaFileFormats.Dpof, "DPOF Files|*.dpf", "dpf")}

      Public Structure WiaPropertyValues
         Private _valueId As UInt32
         Private _valueNameString As String

         Public Sub New(ByVal valueIdParam As UInt32, ByVal valueNameStringParam As String)
            _valueId = valueIdParam
            _valueNameString = valueNameStringParam
         End Sub

         Public ReadOnly Property ValueId() As UInt32
            Get
               Return _valueId
            End Get
         End Property

         Public ReadOnly Property ValueNameString() As String
            Get
               Return _valueNameString
            End Get
         End Property

         Public Shared ReadOnly Property CameraDeviceExposureModes() As WiaPropertyValues()
            Get
               Return _wiaCameraDeviceExposureModesValues
            End Get
         End Property

         Private Shared ReadOnly _wiaCameraDeviceExposureModesValues As WiaPropertyValues() = {New WiaPropertyValues(CUInt(WiaExposureMode.Manual), "Manual"), New WiaPropertyValues(CUInt(WiaExposureMode.Auto), "Auto"), New WiaPropertyValues(CUInt(WiaExposureMode.AperturePriority), "AperturePriority"), New WiaPropertyValues(CUInt(WiaExposureMode.Shutter_Priority), "Shutter_Priority"), New WiaPropertyValues(CUInt(WiaExposureMode.Creative), "Creative"), New WiaPropertyValues(CUInt(WiaExposureMode.Action), "Action"), New WiaPropertyValues(CUInt(WiaExposureMode.Portrait), "Portrait")}

         Public Shared ReadOnly Property CameraDeviceFlashModes() As WiaPropertyValues()
            Get
               Return _wiaCameraDeviceFlashModesValues
            End Get
         End Property

         Private Shared ReadOnly _wiaCameraDeviceFlashModesValues As WiaPropertyValues() = {New WiaPropertyValues(CUInt(WiaFlashMode.Auto), "Auto"), New WiaPropertyValues(CUInt(WiaFlashMode.Fill), "Fill"), New WiaPropertyValues(CUInt(WiaFlashMode.Off), "Off"), New WiaPropertyValues(CUInt(WiaFlashMode.RedeyeAuto), "RedeyeAuto"), New WiaPropertyValues(CUInt(WiaFlashMode.RedeyeFill), "RedeyeFill"), New WiaPropertyValues(CUInt(WiaFlashMode.ExternalSync), "ExternalSync")}

         Public Shared ReadOnly Property CameraDeviceFocusModes() As WiaPropertyValues()
            Get
               Return _wiaCameraDeviceFocusModesValues
            End Get
         End Property

         Private Shared ReadOnly _wiaCameraDeviceFocusModesValues As WiaPropertyValues() = {New WiaPropertyValues(CUInt(WiaFocusMode.Manual), "Manual"), New WiaPropertyValues(CUInt(WiaFocusMode.Auto), "Auto"), New WiaPropertyValues(CUInt(WiaFocusMode.MacroAuto), "MacroAuto")}

         Public Shared ReadOnly Property CameraDeviceEffectMode() As WiaPropertyValues()
            Get
               Return _wiaCameraDeviceEffectModeValues
            End Get
         End Property

         Private Shared ReadOnly _wiaCameraDeviceEffectModeValues As WiaPropertyValues() = {New WiaPropertyValues(CUInt(WiaEffectMode.Standard), "Standard"), New WiaPropertyValues(CUInt(WiaEffectMode.BlackWhite), "BlackWhite"), New WiaPropertyValues(CUInt(WiaEffectMode.Sepia), "Sepia")}

         Public Shared ReadOnly Property CameraDeviceCaptureMode() As WiaPropertyValues()
            Get
               Return _wiaCameraDeviceCaptureModeValues
            End Get
         End Property

         Private Shared ReadOnly _wiaCameraDeviceCaptureModeValues As WiaPropertyValues() = {New WiaPropertyValues(CUInt(WiaCaptureMode.Normal), "Normal"), New WiaPropertyValues(CUInt(WiaCaptureMode.Burst), "Burst"), New WiaPropertyValues(CUInt(WiaCaptureMode.Timelapse), "Timelapse")}

         Public Shared ReadOnly Property CameraDeviceExposureMeteringMode() As WiaPropertyValues()
            Get
               Return _wiaCameraDeviceExposureMeteringModeValues
            End Get
         End Property

         Private Shared ReadOnly _wiaCameraDeviceExposureMeteringModeValues As WiaPropertyValues() = {New WiaPropertyValues(CUInt(WiaExposureMeteringMode.Average), "Average"), New WiaPropertyValues(CUInt(WiaExposureMeteringMode.CenterWeight), "CenterWeight"), New WiaPropertyValues(CUInt(WiaExposureMeteringMode.MultiSpot), "MultiSpot"), New WiaPropertyValues(CUInt(WiaExposureMeteringMode.CenterSpot), "CenterSpot")}

         Public Shared ReadOnly Property CameraDeviceWhiteBalance() As WiaPropertyValues()
            Get
               Return _wiaCameraDeviceWhiteBalanceValues
            End Get
         End Property

         Private Shared ReadOnly _wiaCameraDeviceWhiteBalanceValues As WiaPropertyValues() = {New WiaPropertyValues(CUInt(WiaWhiteBalanceMode.Manual), "Manual"), New WiaPropertyValues(CUInt(WiaWhiteBalanceMode.Auto), "Auto"), New WiaPropertyValues(CUInt(WiaWhiteBalanceMode.OnePushAuto), "OnePushAuto"), New WiaPropertyValues(CUInt(WiaWhiteBalanceMode.Daylight), "Daylight"), New WiaPropertyValues(CUInt(WiaWhiteBalanceMode.Florescent), "Florescent"), New WiaPropertyValues(CUInt(WiaWhiteBalanceMode.Tungsten), "Tungsten"), New WiaPropertyValues(CUInt(WiaWhiteBalanceMode.Flash), "Flash")}

         Public Shared ReadOnly Property ScannerDeviceDocumentHandlingSelect() As WiaPropertyValues()
            Get
               Return _wiaScannerDeviceDocumentHandlingSelectValues
            End Get
         End Property

         Private Shared ReadOnly _wiaScannerDeviceDocumentHandlingSelectValues As WiaPropertyValues() = {New WiaPropertyValues(CUInt(WiaScanningModeFlags.Feeder), "Feeder"), New WiaPropertyValues(CUInt(WiaScanningModeFlags.Flatbed), "Flatbed"), New WiaPropertyValues(CUInt(WiaScanningModeFlags.Duplex), "Duplex"), New WiaPropertyValues(CUInt(WiaScanningModeFlags.AutoAdvance), "AutoAdvance"), New WiaPropertyValues(CUInt(WiaScanningModeFlags.FrontFirst), "FrontFirst"), New WiaPropertyValues(CUInt(WiaScanningModeFlags.BackFirst), "BackFirst"), New WiaPropertyValues(CUInt(WiaScanningModeFlags.FrontOnly), "FrontOnly"), New WiaPropertyValues(CUInt(WiaScanningModeFlags.BackOnly), "BackOnly"), New WiaPropertyValues(CUInt(WiaScanningModeFlags.NextPage), "NextPage"), New WiaPropertyValues(CUInt(WiaScanningModeFlags.Prefeed), "Prefeed"), New WiaPropertyValues(CUInt(WiaScanningModeFlags.AdvancedDuplex), "AdvancedDuplex")}

         Public Shared ReadOnly Property ScannerDeviceDocumentHandlingCapabilities() As WiaPropertyValues()
            Get
               Return _wiaScannerDeviceDocumentHandlingCapabilitiesValues
            End Get
         End Property

         Private Shared ReadOnly _wiaScannerDeviceDocumentHandlingCapabilitiesValues As WiaPropertyValues() = {New WiaPropertyValues(CUInt(WiaDocumentHandlingCapabilitiesFlags.Feeder), "Feeder"), New WiaPropertyValues(CUInt(WiaDocumentHandlingCapabilitiesFlags.Flatbed), "Flatbed"), New WiaPropertyValues(CUInt(WiaDocumentHandlingCapabilitiesFlags.DetectFlatbed), "DetectFlatbed"), New WiaPropertyValues(CUInt(WiaDocumentHandlingCapabilitiesFlags.DetectScan), "DetectScan"), New WiaPropertyValues(CUInt(WiaDocumentHandlingCapabilitiesFlags.DetectFeed), "DetectFeed"), New WiaPropertyValues(CUInt(WiaDocumentHandlingCapabilitiesFlags.DetectDuplex), "DetectDuplex"), New WiaPropertyValues(CUInt(WiaDocumentHandlingCapabilitiesFlags.DetectFeedAvailable), "DetectFeedAvailable"), New WiaPropertyValues(CUInt(WiaDocumentHandlingCapabilitiesFlags.DetectDupAvailable), "DetectDupAvailable"), New WiaPropertyValues(CUInt(WiaDocumentHandlingCapabilitiesFlags.Duplexer), "Duplexer"), New WiaPropertyValues(CUInt(WiaDocumentHandlingCapabilitiesFlags.AdvancedDuplex), "AdvancedDuplex"), New WiaPropertyValues(CUInt(WiaDocumentHandlingCapabilitiesFlags.Tpa), "Tpa"), New WiaPropertyValues(CUInt(WiaDocumentHandlingCapabilitiesFlags.DetectTpa), "DetectTpa"), New WiaPropertyValues(CUInt(WiaDocumentHandlingCapabilitiesFlags.Storage), "Storage"), New WiaPropertyValues(CUInt(WiaDocumentHandlingCapabilitiesFlags.DetectStorage), "DetectStorage")}

         Public Shared ReadOnly Property ScannerDeviceOrientation() As WiaPropertyValues()
            Get
               Return _wiaScannerDeviceOrientationValues
            End Get
         End Property

         Private Shared ReadOnly _wiaScannerDeviceOrientationValues As WiaPropertyValues() = {New WiaPropertyValues(CUInt(WiaOrientation.Landscape), "Landscape"), New WiaPropertyValues(CUInt(WiaOrientation.Portrait), "Portrait"), New WiaPropertyValues(CUInt(WiaOrientation.Rotate180), "Rotate180"), New WiaPropertyValues(CUInt(WiaOrientation.Rotate270), "Rotate270")}

         Public Shared ReadOnly Property ScannerItemRotation() As WiaPropertyValues()
            Get
               Return _wiaScannerItemRotationValues
            End Get
         End Property

         Private Shared ReadOnly _wiaScannerItemRotationValues As WiaPropertyValues() = {New WiaPropertyValues(CUInt(WiaScannerItemRotation.Landscape), "Landscape"), New WiaPropertyValues(CUInt(WiaScannerItemRotation.Portrait), "Portrait"), New WiaPropertyValues(CUInt(WiaScannerItemRotation.Rotate180), "Rotate180"), New WiaPropertyValues(CUInt(WiaScannerItemRotation.Rotate270), "Rotate270")}

         Public Shared ReadOnly Property ItemCompression() As WiaPropertyValues()
            Get
               Return _wiaItemCompressionValues
            End Get
         End Property

         Private Shared ReadOnly _wiaItemCompressionValues As WiaPropertyValues() = {New WiaPropertyValues(CUInt(WiaCompressionMode.None), "None"), New WiaPropertyValues(CUInt(WiaCompressionMode.Rle4), "Rle4"), New WiaPropertyValues(CUInt(WiaCompressionMode.Rle8), "Rle8"), New WiaPropertyValues(CUInt(WiaCompressionMode.Group3), "Group3"), New WiaPropertyValues(CUInt(WiaCompressionMode.Group4), "Group4"), New WiaPropertyValues(CUInt(WiaCompressionMode.Jpeg), "Jpeg"), New WiaPropertyValues(CUInt(WiaCompressionMode.Jbig), "Jbig"), New WiaPropertyValues(CUInt(WiaCompressionMode.Jpeg2000), "Jpeg2000"), New WiaPropertyValues(CUInt(WiaCompressionMode.Png), "Png")}

         Public Shared ReadOnly Property ItemDatatype() As WiaPropertyValues()
            Get
               Return _wiaItemDatatypeValues
            End Get
         End Property

         Private Shared ReadOnly _wiaItemDatatypeValues As WiaPropertyValues() = {New WiaPropertyValues(CUInt(WiaImageDataType.Threshold), "Threshold"), New WiaPropertyValues(CUInt(WiaImageDataType.Dither), "Dither"), New WiaPropertyValues(CUInt(WiaImageDataType.Grayscale), "Grayscale"), New WiaPropertyValues(CUInt(WiaImageDataType.Color), "Color"), New WiaPropertyValues(CUInt(WiaImageDataType.ColorThreshold), "ColorThreshold"), New WiaPropertyValues(CUInt(WiaImageDataType.ColorDither), "ColorDither"), New WiaPropertyValues(CUInt(WiaImageDataType.RawBgr), "RawBgr"), New WiaPropertyValues(CUInt(WiaImageDataType.RawCmy), "RawCmy"), New WiaPropertyValues(CUInt(WiaImageDataType.RawCmyk), "RawCmyk"), New WiaPropertyValues(CUInt(WiaImageDataType.RawRgb), "RawRgb"), New WiaPropertyValues(CUInt(WiaImageDataType.RawYuv), "RawYuv"), New WiaPropertyValues(CUInt(WiaImageDataType.RawYuvk), "RawYuvk")}

         Public Shared ReadOnly Property ItemPlanar() As WiaPropertyValues()
            Get
               Return _wiaItemPlanarValues
            End Get
         End Property

         Private Shared ReadOnly _wiaItemPlanarValues As WiaPropertyValues() = {New WiaPropertyValues(CUInt(WiaItemPlanarMode.PackedPixel), "PackedPixel"), New WiaPropertyValues(CUInt(WiaItemPlanarMode.Planar), "Planar")}

         Public Shared ReadOnly Property ItemTymed() As WiaPropertyValues()
            Get
               Return _wiaItemTymedValues
            End Get
         End Property

         Private Shared ReadOnly _wiaItemTymedValues As WiaPropertyValues() = {New WiaPropertyValues(CUInt(WiaTransferMode.File), "File"), New WiaPropertyValues(CUInt(WiaTransferMode.Memory), "Memory")}

         Public Shared ReadOnly Property ScannerDevicePageSize() As WiaPropertyValues()
            Get
               Return _wiaScannerDevicePageSizeValues
            End Get
         End Property

         Private Shared ReadOnly _wiaScannerDevicePageSizeValues As WiaPropertyValues() = {New WiaPropertyValues(CUInt(WiaPageSizeMode.A4), "A4"), New WiaPropertyValues(CUInt(WiaPageSizeMode.Custom), "Custom"), New WiaPropertyValues(CUInt(WiaPageSizeMode.Letter), "Letter"), New WiaPropertyValues(CUInt(WiaPageSizeMode.Auto), "Auto"), New WiaPropertyValues(CUInt(WiaPageSizeMode.CustomBase), "CustomBase")}

         Public Shared ReadOnly Property ItemAccessRights() As WiaPropertyValues()
            Get
               Return _wiaItemAccessRightsValues
            End Get
         End Property

         Private Shared ReadOnly _wiaItemAccessRightsValues As WiaPropertyValues() = {New WiaPropertyValues(CUInt(WiaItemAccessRights.Read), "Read"), New WiaPropertyValues(CUInt(WiaItemAccessRights.Write), "Write"), New WiaPropertyValues(CUInt(WiaItemAccessRights.CanBeDeleted), "CanBeDeleted"), New WiaPropertyValues(CUInt(WiaItemAccessRights.RD), "RD"), New WiaPropertyValues(CUInt(WiaItemAccessRights.RWD), "RWD")}

         Public Shared ReadOnly Property ScannerDeviceDocumentHandlingStatus() As WiaPropertyValues()
            Get
               Return _wiaScannerDeviceDocumentHandlingStatusValues
            End Get
         End Property

         Private Shared ReadOnly _wiaScannerDeviceDocumentHandlingStatusValues As WiaPropertyValues() = {New WiaPropertyValues(CUInt(WiaDocumentHandlingStatusFlags.FeederReady), "FeederReady"), New WiaPropertyValues(CUInt(WiaDocumentHandlingStatusFlags.FlatbedReady), "FlatbedReady"), New WiaPropertyValues(CUInt(WiaDocumentHandlingStatusFlags.DuplexerReady), "DuplexerReady"), New WiaPropertyValues(CUInt(WiaDocumentHandlingStatusFlags.FlatbedCoverUp), "FlatbedCoverUp"), New WiaPropertyValues(CUInt(WiaDocumentHandlingStatusFlags.PapaerPathCoverUp), "PapaerPathCoverUp"), New WiaPropertyValues(CUInt(WiaDocumentHandlingStatusFlags.PaperJam), "PaperJam"), New WiaPropertyValues(CUInt(WiaDocumentHandlingStatusFlags.TpaReady), "TpaReady"), New WiaPropertyValues(CUInt(WiaDocumentHandlingStatusFlags.StorageReady), "StorageReady"), New WiaPropertyValues(CUInt(WiaDocumentHandlingStatusFlags.StorageFull), "StorageFull"), New WiaPropertyValues(CUInt(WiaDocumentHandlingStatusFlags.MultipleFeeder), "MultipleFeeder"), New WiaPropertyValues(CUInt(WiaDocumentHandlingStatusFlags.DeviceAttention), "DeviceAttention"), New WiaPropertyValues(CUInt(WiaDocumentHandlingStatusFlags.LampError), "LampError")}

         Public Shared ReadOnly Property ItemFlags() As WiaPropertyValues()
            Get
               Return _wiaItemFlagsValues
            End Get
         End Property

         Private Shared ReadOnly _wiaItemFlagsValues As WiaPropertyValues() = {New WiaPropertyValues(CUInt(WiaItemTypeFlags.Analyze), "Analyze"), New WiaPropertyValues(CUInt(WiaItemTypeFlags.Audio), "Audio"), New WiaPropertyValues(CUInt(WiaItemTypeFlags.Burst), "Burst"), New WiaPropertyValues(CUInt(WiaItemTypeFlags.Deleted), "Deleted"), New WiaPropertyValues(CUInt(WiaItemTypeFlags.Device), "Device"), New WiaPropertyValues(CUInt(WiaItemTypeFlags.Disconnected), "Disconnected"), New WiaPropertyValues(CUInt(WiaItemTypeFlags.File), "File"), New WiaPropertyValues(CUInt(WiaItemTypeFlags.Folder), "Folder"), New WiaPropertyValues(CUInt(WiaItemTypeFlags.Free), "Free"), New WiaPropertyValues(CUInt(WiaItemTypeFlags.Generated), "Generated"), New WiaPropertyValues(CUInt(WiaItemTypeFlags.HasAttachments), "HasAttachments"), New WiaPropertyValues(CUInt(WiaItemTypeFlags.HorizontalPanorama), "HorizontalPanorama"), New WiaPropertyValues(CUInt(WiaItemTypeFlags.Image), "Image"), New WiaPropertyValues(CUInt(WiaItemTypeFlags.Root), "Root"), New WiaPropertyValues(CUInt(WiaItemTypeFlags.Storage), "Storage"), New WiaPropertyValues(CUInt(WiaItemTypeFlags.Transfer), "Transfer"), New WiaPropertyValues(CUInt(WiaItemTypeFlags.Video), "Video"), New WiaPropertyValues(CUInt(WiaItemTypeFlags.VerticalPanorama), "VerticalPanorama"), New WiaPropertyValues(CUInt(WiaItemTypeFlags.Document), "Document"), New WiaPropertyValues(CUInt(WiaItemTypeFlags.ProgrammableDataSource), "ProgrammableDataSource")}

         Public Shared ReadOnly Property ScannerItemCurIntent() As WiaPropertyValues()
            Get
               Return _wiaScannerItemCurIntentValues
            End Get
         End Property

         Private Shared ReadOnly _wiaScannerItemCurIntentValues As WiaPropertyValues() = {New WiaPropertyValues(CUInt(WiaImageType.None), "None"), New WiaPropertyValues(CUInt(WiaImageType.Color), "Color"), New WiaPropertyValues(CUInt(WiaImageType.Grayscale), "Grayscale"), New WiaPropertyValues(CUInt(WiaImageType.Text), "Text"), New WiaPropertyValues(CUInt(WiaImageType.Mask), "Mask"), New WiaPropertyValues(CUInt(WiaImageType.MinimizeSize), "MinimizeSize"), New WiaPropertyValues(CUInt(WiaImageType.MaximizeQuality), "MaximizeQuality"), New WiaPropertyValues(CUInt(WiaImageType.SizeMask), "SizeMask"), New WiaPropertyValues(CUInt(WiaImageType.BestPreview), "BestPreview")}

         Public Shared ReadOnly Property ScannerItemAutoDeskew() As WiaPropertyValues()
            Get
               Return _wiaScannerItemAutoDeskewValues
            End Get
         End Property

         Private Shared ReadOnly _wiaScannerItemAutoDeskewValues As WiaPropertyValues() = {New WiaPropertyValues(CUInt(WiaAutoDeskewMode.On), "On"), New WiaPropertyValues(CUInt(WiaAutoDeskewMode.Off), "Off")}

         Public Shared ReadOnly Property ScannerItemPhotometricInterp() As WiaPropertyValues()
            Get
               Return _wiaScannerItemPhotometricInterpValues
            End Get
         End Property

         Private Shared ReadOnly _wiaScannerItemPhotometricInterpValues As WiaPropertyValues() = {New WiaPropertyValues(CUInt(WiaScannerItemPhotometricMode.White0), "White0"), New WiaPropertyValues(CUInt(WiaScannerItemPhotometricMode.White1), "White1")}

         Public Shared ReadOnly Property ScannerItemFilmScanMode() As WiaPropertyValues()
            Get
               Return _wiaScannerItemFilmScanModeValues
            End Get
         End Property

         Private Shared ReadOnly _wiaScannerItemFilmScanModeValues As WiaPropertyValues() = {New WiaPropertyValues(CUInt(WiaFilmScanMode.ColorSlide), "ColorSlide"), New WiaPropertyValues(CUInt(WiaFilmScanMode.ColorNegative), "ColorNegative"), New WiaPropertyValues(CUInt(WiaFilmScanMode.BlackWhiteNegative), "BlackWhiteNegative")}

         Public Shared ReadOnly Property ScannerItemLamp() As WiaPropertyValues()
            Get
               Return _wiaScannerItemLampValues
            End Get
         End Property

         Private Shared ReadOnly _wiaScannerItemLampValues As WiaPropertyValues() = {New WiaPropertyValues(CUInt(WiaScannerLampMode.On), "On"), New WiaPropertyValues(CUInt(WiaScannerLampMode.Off), "Off")}

         Public Shared ReadOnly Property ScannerDevicePreview() As WiaPropertyValues()
            Get
               Return _wiaScannerDevicePreviewValues
            End Get
         End Property

         Private Shared ReadOnly _wiaScannerDevicePreviewValues As WiaPropertyValues() = {New WiaPropertyValues(CUInt(WiaPreviewMode.FinalScan), "FinalScan"), New WiaPropertyValues(CUInt(WiaPreviewMode.PreviewScan), "PreviewScan")}

         Public Shared ReadOnly Property ScannerItemTransferCapabilities() As WiaPropertyValues()
            Get
               Return _wiaScannerItemTransferCapabilitiesValues
            End Get
         End Property

         Private Shared ReadOnly _wiaScannerItemTransferCapabilitiesValues As WiaPropertyValues() = {New WiaPropertyValues(CUInt(WiaScannerItemTransferCapabilitiesMode.SingleScan), "SingleScan")}
      End Structure

      Public Structure WiaPropertyValuesInfo
         Private _propertyId As WiaPropertyId
         Private _propertyValues As WiaPropertyValues()

         Public Sub New(ByVal propertyIdParam As WiaPropertyId, ByVal propertyValues As WiaPropertyValues())
            _propertyId = propertyIdParam
            _propertyValues = propertyValues
         End Sub

         Public ReadOnly Property PropertyId() As WiaPropertyId
            Get
               Return _propertyId
            End Get
         End Property

         Public ReadOnly Property Values() As WiaPropertyValues()
            Get
               Return _propertyValues
            End Get
         End Property
      End Structure

      Public Shared ReadOnly _wiaPropertyValuesInfo As WiaPropertyValuesInfo() = {New WiaPropertyValuesInfo(WiaPropertyId.CameraDeviceExposureMode, WiaPropertyValues.CameraDeviceExposureModes), New WiaPropertyValuesInfo(WiaPropertyId.CameraDeviceFlashMode, WiaPropertyValues.CameraDeviceFlashModes), New WiaPropertyValuesInfo(WiaPropertyId.CameraDeviceFocusMode, WiaPropertyValues.CameraDeviceFocusModes), New WiaPropertyValuesInfo(WiaPropertyId.CameraDeviceEffectMode, WiaPropertyValues.CameraDeviceEffectMode), New WiaPropertyValuesInfo(WiaPropertyId.CameraDeviceCaptureMode, WiaPropertyValues.CameraDeviceCaptureMode), New WiaPropertyValuesInfo(WiaPropertyId.CameraDeviceExposureMeteringMode, WiaPropertyValues.CameraDeviceExposureMeteringMode), New WiaPropertyValuesInfo(WiaPropertyId.CameraDeviceWhiteBalance, WiaPropertyValues.CameraDeviceWhiteBalance), New WiaPropertyValuesInfo(WiaPropertyId.ScannerDeviceDocumentHandlingSelect, WiaPropertyValues.ScannerDeviceDocumentHandlingSelect), New WiaPropertyValuesInfo(WiaPropertyId.ScannerDeviceDocumentHandlingCapabilities, WiaPropertyValues.ScannerDeviceDocumentHandlingCapabilities), New WiaPropertyValuesInfo(WiaPropertyId.ScannerDeviceOrientation, WiaPropertyValues.ScannerDeviceOrientation), New WiaPropertyValuesInfo(WiaPropertyId.ScannerItemRotation, WiaPropertyValues.ScannerItemRotation), New WiaPropertyValuesInfo(WiaPropertyId.ItemCompression, WiaPropertyValues.ItemCompression), New WiaPropertyValuesInfo(WiaPropertyId.ItemDatatype, WiaPropertyValues.ItemDatatype), New WiaPropertyValuesInfo(WiaPropertyId.ItemPlanar, WiaPropertyValues.ItemPlanar), New WiaPropertyValuesInfo(WiaPropertyId.ItemTymed, WiaPropertyValues.ItemTymed), New WiaPropertyValuesInfo(WiaPropertyId.ScannerDevicePageSize, WiaPropertyValues.ScannerDevicePageSize), New WiaPropertyValuesInfo(WiaPropertyId.ItemAccessRights, WiaPropertyValues.ItemAccessRights), New WiaPropertyValuesInfo(WiaPropertyId.ScannerDeviceDocumentHandlingStatus, WiaPropertyValues.ScannerDeviceDocumentHandlingStatus), New WiaPropertyValuesInfo(WiaPropertyId.ItemFlags, WiaPropertyValues.ItemFlags), New WiaPropertyValuesInfo(WiaPropertyId.ScannerItemCurIntent, WiaPropertyValues.ScannerItemCurIntent), New WiaPropertyValuesInfo(WiaPropertyId.ScannerItemAutoDeskew, WiaPropertyValues.ScannerItemAutoDeskew), New WiaPropertyValuesInfo(WiaPropertyId.ScannerItemPhotometricInterp, WiaPropertyValues.ScannerItemPhotometricInterp), New WiaPropertyValuesInfo(WiaPropertyId.ScannerItemFilmScanMode, WiaPropertyValues.ScannerItemFilmScanMode), New WiaPropertyValuesInfo(WiaPropertyId.ScannerItemLamp, WiaPropertyValues.ScannerItemLamp), New WiaPropertyValuesInfo(WiaPropertyId.ScannerDevicePreview, WiaPropertyValues.ScannerDevicePreview), New WiaPropertyValuesInfo(WiaPropertyId.ScannerItemTransferCapabilities, WiaPropertyValues.ScannerItemTransferCapabilities)}

      Public Shared Sub GetFormatFilterAndExtension()
         Dim formatParam As WiaFileFormats
         If FrmMain._wiaProperties.DataTransfer.Format = WiaFileFormats.None Then ' GetProperties() method not called yet.
            formatParam = WiaFileFormats.Bmp
         Else
            formatParam = FrmMain._wiaProperties.DataTransfer.Format
         End If

         For Each i As WiaSupportedFormatsInfo In _wiaFormatsInfo
            If formatParam = i.Format Then ' match found
               _filter = i.Filter
               _extension = i.Extension
               Return
            End If
         Next i
      End Sub

      ' This property is related to the GetFormatFilterAndExtension() method.
      Public Shared ReadOnly Property Filter() As String
         Get
            Return _filter
         End Get
      End Property

      ' This property is related to the GetFormatFilterAndExtension() method.
      Public Shared ReadOnly Property Extension() As String
         Get
            Return _extension
         End Get
      End Property

      Public Shared Function SelectFormatFromCombo(ByVal comboBoxCtrl As System.Windows.Forms.ComboBox, ByVal guidFormat As System.Guid) As Integer
         Dim ret As Integer = GetFormatNameString(guidFormat)
         If ret <> 1 Then
            Return 0
         End If

         Dim i As Integer = 0
         Do While i < comboBoxCtrl.Items.Count
            Dim itemText As String = comboBoxCtrl.GetItemText(comboBoxCtrl.Items(i))
            If itemText.Length > 0 Then
               If itemText = FormatName Then
                  comboBoxCtrl.SelectedIndex = i
                  Return 1
               End If
            End If
            i += 1
         Loop

         Return 0
      End Function

      Public Shared Function GetFormatNameString(ByVal guidFormat As System.Guid) As Integer
         For Each i As WiaSupportedFormatsInfo In _wiaFormatsInfo
            Dim guidValue As Guid
            guidValue = WiaSession.GetFormatGuid(i.Format)
            If guidValue = guidFormat Then
               _formatName = i.Format.ToString()
               Return 1
            End If
         Next i

         Return 0
      End Function

      ' This property is related to the GetFormatNameString() method.
      Public Shared ReadOnly Property FormatName() As String
         Get
            Return _formatName
         End Get
      End Property

      Public Shared Function SelectItemFromCombo(ByVal comboBoxCtrl As System.Windows.Forms.ComboBox, ByVal value As Integer) As Integer
         Dim i As Integer = 0
         Do While i < comboBoxCtrl.Items.Count
            Dim item As MyItemData = CType(comboBoxCtrl.Items(i), MyItemData)
            If item.ItemData = value Then
               comboBoxCtrl.SelectedIndex = i
               Return 1
            End If
            i += 1
         Loop

         Return 0
      End Function

      Public Shared Function GetSelectedFormatFromCombo(ByVal comboBoxCtrl As System.Windows.Forms.ComboBox) As Integer
         Dim itemText As String = comboBoxCtrl.GetItemText(comboBoxCtrl.SelectedItem)

         For Each i As WiaSupportedFormatsInfo In _wiaFormatsInfo
            If itemText = i.Format.ToString() Then
               _format = i.Format
               Return 1
            End If
         Next i

         Return 0
      End Function

      ' This property is related to the GetSelectedFormatFromCombo() method.
      Public Shared ReadOnly Property Format() As WiaFileFormats
         Get
            Return _format
         End Get
      End Property

      Public Shared Sub FindRelevantPropName(ByVal propertyId As WiaPropertyId, ByVal value As Object)
         If propertyId = WiaPropertyId.ScannerDeviceDocumentHandlingSelect Then
            Dim val As UInt32 = Convert.ToUInt32(value)
            If (val And CInt(WiaScanningModeFlags.Feeder)) = CInt(WiaScanningModeFlags.Feeder) OrElse (val And CInt(WiaScanningModeFlags.Flatbed)) = CInt(WiaScanningModeFlags.Flatbed) Then
               _propertyName = "Paper Source"
            End If
         Else
            _propertyName = WiaSession.GetPropertyIdString(propertyId)
         End If
      End Sub

      ' This property is related to the FindRelevantPropName() method.
      Public Shared ReadOnly Property PropertyName() As String
         Get
            Return _propertyName
         End Get
      End Property

      Public Shared Sub FindRelevantPropValue(ByVal propertyId As WiaPropertyId, ByVal value As Object)
         Dim val As UInt32 = Convert.ToUInt32(value)

         Select Case propertyId
            Case WiaPropertyId.ScannerDevicePages, WiaPropertyId.ItemDepth, WiaPropertyId.ScannerItemXExtent, WiaPropertyId.ScannerItemYExtent, WiaPropertyId.ScannerItemXRes, WiaPropertyId.ScannerItemYRes, WiaPropertyId.ScannerItemXPos, WiaPropertyId.ScannerItemYPos, WiaPropertyId.ScannerItemXScaling, WiaPropertyId.ScannerItemYScaling, WiaPropertyId.ScannerItemBrightness, WiaPropertyId.ScannerItemContrast
               _propertyValueString = val.ToString()

            Case WiaPropertyId.ScannerDeviceOrientation, WiaPropertyId.ScannerItemRotation
               Select Case val
                  Case CInt(WiaOrientation.Landscape)
                     _propertyValueString = "Landscape"

                  Case CInt(WiaOrientation.Portrait)
                     _propertyValueString = "Portrait"

                  Case CInt(WiaOrientation.Rotate180)
                     _propertyValueString = "Rotate 180"

                  Case CInt(WiaOrientation.Rotate270)
                     _propertyValueString = "Rotate 270"
               End Select

            Case WiaPropertyId.ScannerDeviceDocumentHandlingSelect
               Select Case val
                  Case CInt(WiaScanningModeFlags.Feeder)
                     _propertyValueString = "Feeder"

                  Case CInt(WiaScanningModeFlags.Flatbed)
                     _propertyValueString = "Flatbed"

                  Case CInt(WiaScanningModeFlags.Duplex)
                     _propertyValueString = "Duplex"

                  Case CInt(WiaScanningModeFlags.AutoAdvance)
                     _propertyValueString = "Auto Advance"

                  Case CInt(WiaScanningModeFlags.FrontFirst)
                     _propertyValueString = "Front First"

                  Case CInt(WiaScanningModeFlags.BackFirst)
                     _propertyValueString = "Back First"

                  Case CInt(WiaScanningModeFlags.FrontOnly)
                     _propertyValueString = "Front Only"

                  Case CInt(WiaScanningModeFlags.BackOnly)
                     _propertyValueString = "Back Only"

                  Case CInt(WiaScanningModeFlags.NextPage)
                     _propertyValueString = "Next Page"

                  Case CInt(WiaScanningModeFlags.Prefeed)
                     _propertyValueString = "Pre-feed"
               End Select

            Case WiaPropertyId.ScannerItemCurIntent
               If val = CInt(WiaImageType.Color) Then
                  _propertyValueString = "Color"
               ElseIf val = CInt(WiaImageType.Grayscale) Then
                  _propertyValueString = "Grayscale"
               Else
                  _propertyValueString = "Text"
               End If

            Case WiaPropertyId.ItemCompression
               Select Case val
                  Case CInt(WiaCompressionMode.None)
                     _propertyValueString = "None"

                  Case CInt(WiaCompressionMode.Rle4)
                     _propertyValueString = "RLE4 Compression"

                  Case CInt(WiaCompressionMode.Rle8)
                     _propertyValueString = "RLE8 Compression"

                  Case CInt(WiaCompressionMode.Group3)
                     _propertyValueString = "Group 3 Compression"

                  Case CInt(WiaCompressionMode.Group4)
                     _propertyValueString = "Group 4 Compression"

                  Case CInt(WiaCompressionMode.Jpeg)
                     _propertyValueString = "JPEG Compression"

                  Case CInt(WiaCompressionMode.Jbig)
                     _propertyValueString = "JBIG compression"

                  Case CInt(WiaCompressionMode.Jpeg2000)
                     _propertyValueString = "JPEG 2000 compression"

                  Case CInt(WiaCompressionMode.Png)
                     _propertyValueString = "PNG compression"
               End Select

            Case WiaPropertyId.ItemTymed
               Select Case val
                  Case CInt(WiaTransferMode.Memory)
                     _propertyValueString = "Memory Transfer"

                  Case CInt(WiaTransferMode.File)
                     _propertyValueString = "File Transfer"
               End Select

            Case WiaPropertyId.ItemDatatype
               Select Case val
                  Case CInt(WiaImageDataType.Threshold)
                     _propertyValueString = "Threshold"

                  Case CInt(WiaImageDataType.Dither)
                     _propertyValueString = "Dither"

                  Case CInt(WiaImageDataType.Grayscale)
                     _propertyValueString = "Grayscale"

                  Case CInt(WiaImageDataType.Color)
                     _propertyValueString = "Color"

                  Case CInt(WiaImageDataType.ColorThreshold)
                     _propertyValueString = "Color Threshold"

                  Case CInt(WiaImageDataType.ColorDither)
                     _propertyValueString = "Color Dither"
               End Select

            Case WiaPropertyId.ItemFormat
               Dim guidFormat As System.Guid = CType(value, System.Guid)
               GetFormatNameString(guidFormat)
               _propertyValueString = FormatName
         End Select
      End Sub

      ' This property is related to the FindRelevantPropValue() method.
      Public Shared ReadOnly Property PropertyValueString() As String
         Get
            Return _propertyValueString
         End Get
      End Property

      Public Shared Sub FillComboWithValidValues(ByVal comboBoxCtrl As System.Windows.Forms.ComboBox, ByVal capability As WiaCapability)
         If capability.Values.ListValues.ValuesCount <= 0 OrElse capability.Values.ListValues.Values Is Nothing Then
            Return
         End If

         Dim item As MyItemData = New MyItemData()
         Dim value As Integer = 0

         For Each i As Object In capability.Values.ListValues.Values
            value = Convert.ToInt32(i)
            ' If Bits per pixel property, then just add the received values.
            If capability.PropertyId = WiaPropertyId.ItemDepth OrElse capability.PropertyId = WiaPropertyId.ScannerItemXRes OrElse capability.PropertyId = WiaPropertyId.ScannerItemYRes Then
               item.ItemData = value
               item.ItemString = value.ToString()
               comboBoxCtrl.Items.Add(item)
            Else
               Dim ret As Integer = GetWiaListPropertyValueString(capability.PropertyId, value)
               If ret = 1 Then
                  item.ItemData = value
                  item.ItemString = ListPropertyValueString
                  comboBoxCtrl.Items.Add(item)
               End If
            End If
         Next i
      End Sub

      Public Shared Function GetWiaListPropertyValueString(ByVal propertyId As WiaPropertyId, ByVal value As Integer) As Integer
         Dim found As Boolean = False

         For Each i As WiaPropertyValuesInfo In _wiaPropertyValuesInfo
            If i.PropertyId = propertyId Then
               For Each j As WiaPropertyValues In i.Values
                  If j.ValueId = value Then
                     _listPropertyValueString = j.ValueNameString
                     found = True
                     Exit For
                  End If
               Next j

               If found = True Then
                  Return 1
               End If
            End If
         Next i
         Return 0
      End Function

      ' This property is related to the GetWiaListPropertyValueString() method.
      Public Shared ReadOnly Property ListPropertyValueString() As String
         Get
            Return _listPropertyValueString
         End Get
      End Property

      Public Shared Function GetWiaFlagPropertyValueString(ByVal propertyId As WiaPropertyId, ByVal value As Int32) As Integer
         Dim foundCount As Integer = 0

         FrmMain._flagValuesStrings.Clear()

         For Each i As WiaPropertyValuesInfo In _wiaPropertyValuesInfo
            If i.PropertyId = propertyId Then
               For Each j As WiaPropertyValues In i.Values
                  If (value And j.ValueId) = j.ValueId Then
                     FrmMain._flagValuesStrings.Add(j.ValueNameString)
                     foundCount += 1
                  End If
               Next j

               If foundCount > 0 Then
                  Return 1
               End If
            End If
         Next i

         Return 0
      End Function
   End Class
End Namespace
