// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Text;
using Leadtools.Wia;
using Leadtools.Demos;

namespace WiaDemo
{
   class HelperFunctions
   {
      static string _filter;
      static string _extension;
      static string _formatName;
      static string _propertyName;
      static string _propertyValueString;
      static string _listPropertyValueString;
      static WiaFileFormats _format;

      public struct WiaSupportedFormatsInfo
      {
         private WiaFileFormats _format;
         private String _formatFilter;
         private String _formatExtension;

         public WiaSupportedFormatsInfo(WiaFileFormats format, String filter, String extension)
         {
            _format = format;
            _formatFilter = filter;
            _formatExtension = extension;
         }

         public WiaFileFormats Format
         {
            get
            {
               return _format;
            }
            set
            {
               _format = value;
            }
         }

         public String Filter
         {
            get
            {
               return _formatFilter;
            }
            set
            {
               _formatFilter = value;
            }
         }

         public String Extension
         {
            get
            {
               return _formatExtension;
            }
            set
            {
               _formatExtension = value;
            }
         }
      }

      public readonly static WiaSupportedFormatsInfo[] _wiaFormatsInfo =
      {
         new WiaSupportedFormatsInfo(WiaFileFormats.MemoryBmp  , ""                    , ""),
         new WiaSupportedFormatsInfo(WiaFileFormats.Bmp        , "BMP Files|*.bmp"     , "bmp"),
         new WiaSupportedFormatsInfo(WiaFileFormats.Ciff       , "CIFF Files|*.iff"    , "iff"),
         new WiaSupportedFormatsInfo(WiaFileFormats.Emf        , "EMF Files|*.emf"     , "emf"),
         new WiaSupportedFormatsInfo(WiaFileFormats.Exif       , "EXIF Files|*.tif"    , "tif"),
         new WiaSupportedFormatsInfo(WiaFileFormats.Fpx        , "FPX Files|*.fpx"     , "fpx"),
         new WiaSupportedFormatsInfo(WiaFileFormats.Gif        , "GIF Files|*.gif"     , "gif"),
         new WiaSupportedFormatsInfo(WiaFileFormats.Ico        , "ICO Files|*.ico"     , "ico"),
         new WiaSupportedFormatsInfo(WiaFileFormats.Jbig       , "JBIG Files|*.jbg"    , "jbg"),
         new WiaSupportedFormatsInfo(WiaFileFormats.Jpeg       , "JPEG Files|*.jpg"    , "jpg"),
         new WiaSupportedFormatsInfo(WiaFileFormats.J2k        , "JPEG2K Files|*.j2k"  , "j2k"),
         new WiaSupportedFormatsInfo(WiaFileFormats.J2kx       , "JPEG2KX Files|*.j2k" , "j2k"),
         new WiaSupportedFormatsInfo(WiaFileFormats.Pcd        , "PCD Files|*.pcd"     , "pcd"),
         new WiaSupportedFormatsInfo(WiaFileFormats.Pct        , "PCT Files|*.pct"     , "pct"),
         new WiaSupportedFormatsInfo(WiaFileFormats.Png        , "PNG Files|*.png"     , "png"),
         new WiaSupportedFormatsInfo(WiaFileFormats.Raw        , "RAW Files|*.raw"     , "raw"),
         new WiaSupportedFormatsInfo(WiaFileFormats.RawRgb     , "RAWRGB Files|*.raw"  , "raw"),
         new WiaSupportedFormatsInfo(WiaFileFormats.Tiff       , "TIFF Files|*.tif"    , "tif"),
         new WiaSupportedFormatsInfo(WiaFileFormats.Wmf        , "WMF Files|*.wmf"     , "wmf"),
         new WiaSupportedFormatsInfo(WiaFileFormats.Rtf        , "RTF Files|*.rtf"     , "rtf"),
         new WiaSupportedFormatsInfo(WiaFileFormats.Xml        , "XML Files|*.xml"     , "xml"),
         new WiaSupportedFormatsInfo(WiaFileFormats.Html       , "HTML Files|*.htm"    , "htm"),
         new WiaSupportedFormatsInfo(WiaFileFormats.Txt        , "TXT Files|*.txt"     , "txt"),
         new WiaSupportedFormatsInfo(WiaFileFormats.Pdfa       , "PDFA Files|*.pdf"    , "pdf"),
         new WiaSupportedFormatsInfo(WiaFileFormats.Xps        , "XPS Files|*.xps"     , "xps"),
         new WiaSupportedFormatsInfo(WiaFileFormats.Mpg        , "MPEG Files|*.mpg"    , "mpg"),
         new WiaSupportedFormatsInfo(WiaFileFormats.Avi        , "AVI Files|*.avi"     , "avi"),
         new WiaSupportedFormatsInfo(WiaFileFormats.Wav        , "WAV Files|*.wav"     , "wav"),
         new WiaSupportedFormatsInfo(WiaFileFormats.Mp3        , "MP3 Files|*.mp3"     , "mp3"),
         new WiaSupportedFormatsInfo(WiaFileFormats.Aiff       , "AIFF Files|*.iff"    , "iff"),
         new WiaSupportedFormatsInfo(WiaFileFormats.Wma        , "WMA Files|*.wma"     , "wma"),
         new WiaSupportedFormatsInfo(WiaFileFormats.Asf        , "ASF Files|*.asf"     , "asf"),
         new WiaSupportedFormatsInfo(WiaFileFormats.Script     , "SCRIPT Files|*.ps"   , "ps"),
         new WiaSupportedFormatsInfo(WiaFileFormats.Exec       , "EXEC Files|*.exe"    , "exe"),
         new WiaSupportedFormatsInfo(WiaFileFormats.Dpof       , "DPOF Files|*.dpf"    , "dpf"),
      };

      public struct WiaPropertyValues
      {
         private UInt32 _valueId;
         private String _valueNameString;

         public WiaPropertyValues(UInt32 valueId, String valueNameString)
         {
            _valueId = valueId;
            _valueNameString = valueNameString;
         }

         public UInt32 ValueId
         {
            get
            {
               return _valueId;
            }
         }

         public String ValueNameString
         {
            get
            {
               return _valueNameString;
            }
         }

         public static WiaPropertyValues[] CameraDeviceExposureModes
         {
            get
            {
               return _wiaCameraDeviceExposureModesValues;
            }
         }

         private readonly static WiaPropertyValues[] _wiaCameraDeviceExposureModesValues =
         {
            new WiaPropertyValues((UInt32)WiaExposureMode.Manual           , "Manual"),
            new WiaPropertyValues((UInt32)WiaExposureMode.Auto             , "Auto"),
            new WiaPropertyValues((UInt32)WiaExposureMode.AperturePriority , "AperturePriority"),
            new WiaPropertyValues((UInt32)WiaExposureMode.Shutter_Priority , "Shutter_Priority"),
            new WiaPropertyValues((UInt32)WiaExposureMode.Creative         , "Creative"),
            new WiaPropertyValues((UInt32)WiaExposureMode.Action           , "Action"),
            new WiaPropertyValues((UInt32)WiaExposureMode.Portrait         , "Portrait"),
         };

         public static WiaPropertyValues[] CameraDeviceFlashModes
         {
            get
            {
               return _wiaCameraDeviceFlashModesValues;
            }
         }

         private readonly static WiaPropertyValues[] _wiaCameraDeviceFlashModesValues =
         {
            new WiaPropertyValues((UInt32)WiaFlashMode.Auto        , "Auto"),
            new WiaPropertyValues((UInt32)WiaFlashMode.Fill        , "Fill"),
            new WiaPropertyValues((UInt32)WiaFlashMode.Off         , "Off"),
            new WiaPropertyValues((UInt32)WiaFlashMode.RedeyeAuto  , "RedeyeAuto"),
            new WiaPropertyValues((UInt32)WiaFlashMode.RedeyeFill  , "RedeyeFill"),
            new WiaPropertyValues((UInt32)WiaFlashMode.ExternalSync, "ExternalSync"),
         };

         public static WiaPropertyValues[] CameraDeviceFocusModes
         {
            get
            {
               return _wiaCameraDeviceFocusModesValues;
            }
         }

         private readonly static WiaPropertyValues[] _wiaCameraDeviceFocusModesValues =
         {
            new WiaPropertyValues((UInt32)WiaFocusMode.Manual   , "Manual"),
            new WiaPropertyValues((UInt32)WiaFocusMode.Auto     , "Auto"),
            new WiaPropertyValues((UInt32)WiaFocusMode.MacroAuto, "MacroAuto"),
         };

         public static WiaPropertyValues[] CameraDeviceEffectMode
         {
            get
            {
               return _wiaCameraDeviceEffectModeValues;
            }
         }

         private readonly static WiaPropertyValues[] _wiaCameraDeviceEffectModeValues =
         {
            new WiaPropertyValues((UInt32)WiaEffectMode.Standard  , "Standard"),
            new WiaPropertyValues((UInt32)WiaEffectMode.BlackWhite, "BlackWhite"),
            new WiaPropertyValues((UInt32)WiaEffectMode.Sepia     , "Sepia"),
         };

         public static WiaPropertyValues[] CameraDeviceCaptureMode
         {
            get
            {
               return _wiaCameraDeviceCaptureModeValues;
            }
         }

         private readonly static WiaPropertyValues[] _wiaCameraDeviceCaptureModeValues =
         {
            new WiaPropertyValues((UInt32)WiaCaptureMode.Normal   , "Normal"),
            new WiaPropertyValues((UInt32)WiaCaptureMode.Burst    , "Burst"),
            new WiaPropertyValues((UInt32)WiaCaptureMode.Timelapse, "Timelapse"),
         };

         public static WiaPropertyValues[] CameraDeviceExposureMeteringMode
         {
            get
            {
               return _wiaCameraDeviceExposureMeteringModeValues;
            }
         }

         private readonly static WiaPropertyValues[] _wiaCameraDeviceExposureMeteringModeValues =
         {
            new WiaPropertyValues((UInt32)WiaExposureMeteringMode.Average     , "Average"),
            new WiaPropertyValues((UInt32)WiaExposureMeteringMode.CenterWeight, "CenterWeight"),
            new WiaPropertyValues((UInt32)WiaExposureMeteringMode.MultiSpot   , "MultiSpot"),
            new WiaPropertyValues((UInt32)WiaExposureMeteringMode.CenterSpot  , "CenterSpot"),
         };

         public static WiaPropertyValues[] CameraDeviceWhiteBalance
         {
            get
            {
               return _wiaCameraDeviceWhiteBalanceValues;
            }
         }

         private readonly static WiaPropertyValues[] _wiaCameraDeviceWhiteBalanceValues =
         {
            new WiaPropertyValues((UInt32)WiaWhiteBalanceMode.Manual     , "Manual"),
            new WiaPropertyValues((UInt32)WiaWhiteBalanceMode.Auto       , "Auto"),
            new WiaPropertyValues((UInt32)WiaWhiteBalanceMode.OnePushAuto, "OnePushAuto"),
            new WiaPropertyValues((UInt32)WiaWhiteBalanceMode.Daylight   , "Daylight"),
            new WiaPropertyValues((UInt32)WiaWhiteBalanceMode.Florescent , "Florescent"),
            new WiaPropertyValues((UInt32)WiaWhiteBalanceMode.Tungsten   , "Tungsten"),
            new WiaPropertyValues((UInt32)WiaWhiteBalanceMode.Flash      , "Flash"),
         };

         public static WiaPropertyValues[] ScannerDeviceDocumentHandlingSelect
         {
            get
            {
               return _wiaScannerDeviceDocumentHandlingSelectValues;
            }
         }

         private readonly static WiaPropertyValues[] _wiaScannerDeviceDocumentHandlingSelectValues =
         {
            new WiaPropertyValues((UInt32)WiaScanningModeFlags.Feeder        , "Feeder"),
            new WiaPropertyValues((UInt32)WiaScanningModeFlags.Flatbed       , "Flatbed"),
            new WiaPropertyValues((UInt32)WiaScanningModeFlags.Duplex        , "Duplex"),
            new WiaPropertyValues((UInt32)WiaScanningModeFlags.AutoAdvance   , "AutoAdvance"),
            new WiaPropertyValues((UInt32)WiaScanningModeFlags.FrontFirst    , "FrontFirst"),
            new WiaPropertyValues((UInt32)WiaScanningModeFlags.BackFirst     , "BackFirst"),
            new WiaPropertyValues((UInt32)WiaScanningModeFlags.FrontOnly     , "FrontOnly"),
            new WiaPropertyValues((UInt32)WiaScanningModeFlags.BackOnly      , "BackOnly"),
            new WiaPropertyValues((UInt32)WiaScanningModeFlags.NextPage      , "NextPage"),
            new WiaPropertyValues((UInt32)WiaScanningModeFlags.Prefeed       , "Prefeed"),
            new WiaPropertyValues((UInt32)WiaScanningModeFlags.AdvancedDuplex, "AdvancedDuplex"),
         };

         public static WiaPropertyValues[] ScannerDeviceDocumentHandlingCapabilities
         {
            get
            {
               return _wiaScannerDeviceDocumentHandlingCapabilitiesValues;
            }
         }

         private readonly static WiaPropertyValues[] _wiaScannerDeviceDocumentHandlingCapabilitiesValues =
         {
            new WiaPropertyValues((UInt32)WiaDocumentHandlingCapabilitiesFlags.Feeder             , "Feeder"),
            new WiaPropertyValues((UInt32)WiaDocumentHandlingCapabilitiesFlags.Flatbed            , "Flatbed"),
            new WiaPropertyValues((UInt32)WiaDocumentHandlingCapabilitiesFlags.DetectFlatbed      , "DetectFlatbed"),
            new WiaPropertyValues((UInt32)WiaDocumentHandlingCapabilitiesFlags.DetectScan         , "DetectScan"),
            new WiaPropertyValues((UInt32)WiaDocumentHandlingCapabilitiesFlags.DetectFeed         , "DetectFeed"),
            new WiaPropertyValues((UInt32)WiaDocumentHandlingCapabilitiesFlags.DetectDuplex       , "DetectDuplex"),
            new WiaPropertyValues((UInt32)WiaDocumentHandlingCapabilitiesFlags.DetectFeedAvailable, "DetectFeedAvailable"),
            new WiaPropertyValues((UInt32)WiaDocumentHandlingCapabilitiesFlags.DetectDupAvailable , "DetectDupAvailable"),
            new WiaPropertyValues((UInt32)WiaDocumentHandlingCapabilitiesFlags.Duplexer           , "Duplexer"),
            new WiaPropertyValues((UInt32)WiaDocumentHandlingCapabilitiesFlags.AdvancedDuplex     , "AdvancedDuplex"),
            new WiaPropertyValues((UInt32)WiaDocumentHandlingCapabilitiesFlags.Tpa                , "Tpa"),
            new WiaPropertyValues((UInt32)WiaDocumentHandlingCapabilitiesFlags.DetectTpa          , "DetectTpa"),
            new WiaPropertyValues((UInt32)WiaDocumentHandlingCapabilitiesFlags.Storage            , "Storage"),
            new WiaPropertyValues((UInt32)WiaDocumentHandlingCapabilitiesFlags.DetectStorage      , "DetectStorage"),
         };

         public static WiaPropertyValues[] ScannerDeviceOrientation
         {
            get
            {
               return _wiaScannerDeviceOrientationValues;
            }
         }

         private readonly static WiaPropertyValues[] _wiaScannerDeviceOrientationValues =
         {
            new WiaPropertyValues((UInt32)WiaOrientation.Landscape, "Landscape"),
            new WiaPropertyValues((UInt32)WiaOrientation.Portrait , "Portrait"),
            new WiaPropertyValues((UInt32)WiaOrientation.Rotate180, "Rotate180"),
            new WiaPropertyValues((UInt32)WiaOrientation.Rotate270, "Rotate270"),
         };

         public static WiaPropertyValues[] ScannerItemRotation
         {
            get
            {
               return _wiaScannerItemRotationValues;
            }
         }

         private readonly static WiaPropertyValues[] _wiaScannerItemRotationValues =
         {
            new WiaPropertyValues((UInt32)WiaScannerItemRotation.Landscape, "Landscape"),
            new WiaPropertyValues((UInt32)WiaScannerItemRotation.Portrait , "Portrait"),
            new WiaPropertyValues((UInt32)WiaScannerItemRotation.Rotate180, "Rotate180"),
            new WiaPropertyValues((UInt32)WiaScannerItemRotation.Rotate270, "Rotate270"),
         };

         public static WiaPropertyValues[] ItemCompression
         {
            get
            {
               return _wiaItemCompressionValues;
            }
         }

         private readonly static WiaPropertyValues[] _wiaItemCompressionValues =
         {
            new WiaPropertyValues((UInt32)WiaCompressionMode.None    , "None"),
            new WiaPropertyValues((UInt32)WiaCompressionMode.Rle4    , "Rle4"),
            new WiaPropertyValues((UInt32)WiaCompressionMode.Rle8    , "Rle8"),
            new WiaPropertyValues((UInt32)WiaCompressionMode.Group3  , "Group3"),
            new WiaPropertyValues((UInt32)WiaCompressionMode.Group4  , "Group4"),
            new WiaPropertyValues((UInt32)WiaCompressionMode.Jpeg    , "Jpeg"),
            new WiaPropertyValues((UInt32)WiaCompressionMode.Jbig    , "Jbig"),
            new WiaPropertyValues((UInt32)WiaCompressionMode.Jpeg2000, "Jpeg2000"),
            new WiaPropertyValues((UInt32)WiaCompressionMode.Png     , "Png"),
         };

         public static WiaPropertyValues[] ItemDatatype
         {
            get
            {
               return _wiaItemDatatypeValues;
            }
         }

         private readonly static WiaPropertyValues[] _wiaItemDatatypeValues =
         {
            new WiaPropertyValues((UInt32)WiaImageDataType.Threshold      , "Threshold"),
            new WiaPropertyValues((UInt32)WiaImageDataType.Dither         , "Dither"),
            new WiaPropertyValues((UInt32)WiaImageDataType.Grayscale      , "Grayscale"),
            new WiaPropertyValues((UInt32)WiaImageDataType.Color          , "Color"),
            new WiaPropertyValues((UInt32)WiaImageDataType.ColorThreshold , "ColorThreshold"),
            new WiaPropertyValues((UInt32)WiaImageDataType.ColorDither    , "ColorDither"),
            new WiaPropertyValues((UInt32)WiaImageDataType.RawBgr         , "RawBgr"),
            new WiaPropertyValues((UInt32)WiaImageDataType.RawCmy         , "RawCmy"),
            new WiaPropertyValues((UInt32)WiaImageDataType.RawCmyk        , "RawCmyk"),
            new WiaPropertyValues((UInt32)WiaImageDataType.RawRgb         , "RawRgb"),
            new WiaPropertyValues((UInt32)WiaImageDataType.RawYuv         , "RawYuv"),
            new WiaPropertyValues((UInt32)WiaImageDataType.RawYuvk        , "RawYuvk"),
         };

         public static WiaPropertyValues[] ItemPlanar
         {
            get
            {
               return _wiaItemPlanarValues;
            }
         }

         private readonly static WiaPropertyValues[] _wiaItemPlanarValues =
         {
            new WiaPropertyValues((UInt32)WiaItemPlanarMode.PackedPixel, "PackedPixel"),
            new WiaPropertyValues((UInt32)WiaItemPlanarMode.Planar     , "Planar"),
         };

         public static WiaPropertyValues[] ItemTymed
         {
            get
            {
               return _wiaItemTymedValues;
            }
         }

         private readonly static WiaPropertyValues[] _wiaItemTymedValues =
         {
            new WiaPropertyValues((UInt32)WiaTransferMode.File  , "File"),
            new WiaPropertyValues((UInt32)WiaTransferMode.Memory, "Memory"),
         };

         public static WiaPropertyValues[] ScannerDevicePageSize
         {
            get
            {
               return _wiaScannerDevicePageSizeValues;
            }
         }

         private readonly static WiaPropertyValues[] _wiaScannerDevicePageSizeValues =
         {
            new WiaPropertyValues((UInt32)WiaPageSizeMode.A4        , "A4"),
            new WiaPropertyValues((UInt32)WiaPageSizeMode.Custom    , "Custom"),
            new WiaPropertyValues((UInt32)WiaPageSizeMode.Letter    , "Letter"),
            new WiaPropertyValues((UInt32)WiaPageSizeMode.Auto      , "Auto"),
            new WiaPropertyValues((UInt32)WiaPageSizeMode.CustomBase, "CustomBase"),
         };

         public static WiaPropertyValues[] ItemAccessRights
         {
            get
            {
               return _wiaItemAccessRightsValues;
            }
         }

         private readonly static WiaPropertyValues[] _wiaItemAccessRightsValues =
         {
            new WiaPropertyValues((UInt32)WiaItemAccessRights.Read        , "Read"),
            new WiaPropertyValues((UInt32)WiaItemAccessRights.Write       , "Write"),
            new WiaPropertyValues((UInt32)WiaItemAccessRights.CanBeDeleted, "CanBeDeleted"),
            new WiaPropertyValues((UInt32)WiaItemAccessRights.RD          , "RD"),
            new WiaPropertyValues((UInt32)WiaItemAccessRights.RWD         , "RWD"),
         };

         public static WiaPropertyValues[] ScannerDeviceDocumentHandlingStatus
         {
            get
            {
               return _wiaScannerDeviceDocumentHandlingStatusValues;
            }
         }

         private readonly static WiaPropertyValues[] _wiaScannerDeviceDocumentHandlingStatusValues =
         {
            new WiaPropertyValues((UInt32)WiaDocumentHandlingStatusFlags.FeederReady      , "FeederReady"),
            new WiaPropertyValues((UInt32)WiaDocumentHandlingStatusFlags.FlatbedReady     , "FlatbedReady"),
            new WiaPropertyValues((UInt32)WiaDocumentHandlingStatusFlags.DuplexerReady    , "DuplexerReady"),
            new WiaPropertyValues((UInt32)WiaDocumentHandlingStatusFlags.FlatbedCoverUp   , "FlatbedCoverUp"),
            new WiaPropertyValues((UInt32)WiaDocumentHandlingStatusFlags.PapaerPathCoverUp, "PapaerPathCoverUp"),
            new WiaPropertyValues((UInt32)WiaDocumentHandlingStatusFlags.PaperJam         , "PaperJam"),
            new WiaPropertyValues((UInt32)WiaDocumentHandlingStatusFlags.TpaReady         , "TpaReady"),
            new WiaPropertyValues((UInt32)WiaDocumentHandlingStatusFlags.StorageReady     , "StorageReady"),
            new WiaPropertyValues((UInt32)WiaDocumentHandlingStatusFlags.StorageFull      , "StorageFull"),
            new WiaPropertyValues((UInt32)WiaDocumentHandlingStatusFlags.MultipleFeeder   , "MultipleFeeder"),
            new WiaPropertyValues((UInt32)WiaDocumentHandlingStatusFlags.DeviceAttention  , "DeviceAttention"),
            new WiaPropertyValues((UInt32)WiaDocumentHandlingStatusFlags.LampError        , "LampError"),
         };

         public static WiaPropertyValues[] ItemFlags
         {
            get
            {
               return _wiaItemFlagsValues;
            }
         }

         private readonly static WiaPropertyValues[] _wiaItemFlagsValues =
         {
            new WiaPropertyValues((UInt32)WiaItemTypeFlags.Analyze               , "Analyze"),
            new WiaPropertyValues((UInt32)WiaItemTypeFlags.Audio                 , "Audio"),
            new WiaPropertyValues((UInt32)WiaItemTypeFlags.Burst                 , "Burst"),
            new WiaPropertyValues((UInt32)WiaItemTypeFlags.Deleted               , "Deleted"),
            new WiaPropertyValues((UInt32)WiaItemTypeFlags.Device                , "Device"),
            new WiaPropertyValues((UInt32)WiaItemTypeFlags.Disconnected          , "Disconnected"),
            new WiaPropertyValues((UInt32)WiaItemTypeFlags.File                  , "File"),
            new WiaPropertyValues((UInt32)WiaItemTypeFlags.Folder                , "Folder"),
            new WiaPropertyValues((UInt32)WiaItemTypeFlags.Free                  , "Free"),
            new WiaPropertyValues((UInt32)WiaItemTypeFlags.Generated             , "Generated"),
            new WiaPropertyValues((UInt32)WiaItemTypeFlags.HasAttachments        , "HasAttachments"),
            new WiaPropertyValues((UInt32)WiaItemTypeFlags.HorizontalPanorama    , "HorizontalPanorama"),
            new WiaPropertyValues((UInt32)WiaItemTypeFlags.Image                 , "Image"),
            new WiaPropertyValues((UInt32)WiaItemTypeFlags.Root                  , "Root"),
            new WiaPropertyValues((UInt32)WiaItemTypeFlags.Storage               , "Storage"),
            new WiaPropertyValues((UInt32)WiaItemTypeFlags.Transfer              , "Transfer"),
            new WiaPropertyValues((UInt32)WiaItemTypeFlags.Video                 , "Video"),
            new WiaPropertyValues((UInt32)WiaItemTypeFlags.VerticalPanorama      , "VerticalPanorama"),
            new WiaPropertyValues((UInt32)WiaItemTypeFlags.Document              , "Document"),
            new WiaPropertyValues((UInt32)WiaItemTypeFlags.ProgrammableDataSource, "ProgrammableDataSource"),
         };

         public static WiaPropertyValues[] ScannerItemCurIntent
         {
            get
            {
               return _wiaScannerItemCurIntentValues;
            }
         }

         private readonly static WiaPropertyValues[] _wiaScannerItemCurIntentValues =
         {
            new WiaPropertyValues((UInt32)WiaImageType.None           , "None"),
            new WiaPropertyValues((UInt32)WiaImageType.Color          , "Color"),
            new WiaPropertyValues((UInt32)WiaImageType.Grayscale      , "Grayscale"),
            new WiaPropertyValues((UInt32)WiaImageType.Text           , "Text"),
            new WiaPropertyValues((UInt32)WiaImageType.Mask           , "Mask"),
            new WiaPropertyValues((UInt32)WiaImageType.MinimizeSize   , "MinimizeSize"),
            new WiaPropertyValues((UInt32)WiaImageType.MaximizeQuality, "MaximizeQuality"),
            new WiaPropertyValues((UInt32)WiaImageType.SizeMask       , "SizeMask"),
            new WiaPropertyValues((UInt32)WiaImageType.BestPreview    , "BestPreview"),
         };

         public static WiaPropertyValues[] ScannerItemAutoDeskew
         {
            get
            {
               return _wiaScannerItemAutoDeskewValues;
            }
         }

         private readonly static WiaPropertyValues[] _wiaScannerItemAutoDeskewValues =
         {
            new WiaPropertyValues((UInt32)WiaAutoDeskewMode.On , "On"),
            new WiaPropertyValues((UInt32)WiaAutoDeskewMode.Off, "Off"),
         };

         public static WiaPropertyValues[] ScannerItemPhotometricInterp
         {
            get
            {
               return _wiaScannerItemPhotometricInterpValues;
            }
         }

         private readonly static WiaPropertyValues[] _wiaScannerItemPhotometricInterpValues =
         {
            new WiaPropertyValues((UInt32)WiaScannerItemPhotometricMode.White0, "White0"),
            new WiaPropertyValues((UInt32)WiaScannerItemPhotometricMode.White1, "White1"),
         };

         public static WiaPropertyValues[] ScannerItemFilmScanMode
         {
            get
            {
               return _wiaScannerItemFilmScanModeValues;
            }
         }

         private readonly static WiaPropertyValues[] _wiaScannerItemFilmScanModeValues =
         {
            new WiaPropertyValues((UInt32)WiaFilmScanMode.ColorSlide        , "ColorSlide"),
            new WiaPropertyValues((UInt32)WiaFilmScanMode.ColorNegative     , "ColorNegative"),
            new WiaPropertyValues((UInt32)WiaFilmScanMode.BlackWhiteNegative, "BlackWhiteNegative"),
         };

         public static WiaPropertyValues[] ScannerItemLamp
         {
            get
            {
               return _wiaScannerItemLampValues;
            }
         }

         private readonly static WiaPropertyValues[] _wiaScannerItemLampValues =
         {
            new WiaPropertyValues((UInt32)WiaScannerLampMode.On , "On"),
            new WiaPropertyValues((UInt32)WiaScannerLampMode.Off, "Off"),
         };

         public static WiaPropertyValues[] ScannerDevicePreview
         {
            get
            {
               return _wiaScannerDevicePreviewValues;
            }
         }

         private readonly static WiaPropertyValues[] _wiaScannerDevicePreviewValues =
         {
            new WiaPropertyValues((UInt32)WiaPreviewMode.FinalScan  , "FinalScan"),
            new WiaPropertyValues((UInt32)WiaPreviewMode.PreviewScan, "PreviewScan"),
         };

         public static WiaPropertyValues[] ScannerItemTransferCapabilities
         {
            get
            {
               return _wiaScannerItemTransferCapabilitiesValues;
            }
         }

         private readonly static WiaPropertyValues[] _wiaScannerItemTransferCapabilitiesValues =
         {
            new WiaPropertyValues((UInt32)WiaScannerItemTransferCapabilitiesMode.SingleScan, "SingleScan"),
         };
      }

      public struct WiaPropertyValuesInfo
      {
         private WiaPropertyId _propertyId;
         private WiaPropertyValues[] _propertyValues;

         public WiaPropertyValuesInfo(WiaPropertyId propertyId, WiaPropertyValues[] propertyValues)
         {
            _propertyId = propertyId;
            _propertyValues = propertyValues;
         }

         public WiaPropertyId PropertyId
         {
            get
            {
               return _propertyId;
            }
         }

         public WiaPropertyValues[] Values
         {
            get
            {
               return _propertyValues;
            }
         }
      }

      public readonly static WiaPropertyValuesInfo[] _wiaPropertyValuesInfo =
      {
         new WiaPropertyValuesInfo(WiaPropertyId.CameraDeviceExposureMode                 , WiaPropertyValues.CameraDeviceExposureModes),
         new WiaPropertyValuesInfo(WiaPropertyId.CameraDeviceFlashMode                    , WiaPropertyValues.CameraDeviceFlashModes),
         new WiaPropertyValuesInfo(WiaPropertyId.CameraDeviceFocusMode                    , WiaPropertyValues.CameraDeviceFocusModes),
         new WiaPropertyValuesInfo(WiaPropertyId.CameraDeviceEffectMode                   , WiaPropertyValues.CameraDeviceEffectMode),
         new WiaPropertyValuesInfo(WiaPropertyId.CameraDeviceCaptureMode                  , WiaPropertyValues.CameraDeviceCaptureMode),
         new WiaPropertyValuesInfo(WiaPropertyId.CameraDeviceExposureMeteringMode         , WiaPropertyValues.CameraDeviceExposureMeteringMode),
         new WiaPropertyValuesInfo(WiaPropertyId.CameraDeviceWhiteBalance                 , WiaPropertyValues.CameraDeviceWhiteBalance),
         new WiaPropertyValuesInfo(WiaPropertyId.ScannerDeviceDocumentHandlingSelect      , WiaPropertyValues.ScannerDeviceDocumentHandlingSelect),
         new WiaPropertyValuesInfo(WiaPropertyId.ScannerDeviceDocumentHandlingCapabilities, WiaPropertyValues.ScannerDeviceDocumentHandlingCapabilities),
         new WiaPropertyValuesInfo(WiaPropertyId.ScannerDeviceOrientation                 , WiaPropertyValues.ScannerDeviceOrientation),
         new WiaPropertyValuesInfo(WiaPropertyId.ScannerItemRotation                      , WiaPropertyValues.ScannerItemRotation),
         new WiaPropertyValuesInfo(WiaPropertyId.ItemCompression                          , WiaPropertyValues.ItemCompression),
         new WiaPropertyValuesInfo(WiaPropertyId.ItemDatatype                             , WiaPropertyValues.ItemDatatype),
         new WiaPropertyValuesInfo(WiaPropertyId.ItemPlanar                               , WiaPropertyValues.ItemPlanar),
         new WiaPropertyValuesInfo(WiaPropertyId.ItemTymed                                , WiaPropertyValues.ItemTymed),
         new WiaPropertyValuesInfo(WiaPropertyId.ScannerDevicePageSize                    , WiaPropertyValues.ScannerDevicePageSize),
         new WiaPropertyValuesInfo(WiaPropertyId.ItemAccessRights                         , WiaPropertyValues.ItemAccessRights),
         new WiaPropertyValuesInfo(WiaPropertyId.ScannerDeviceDocumentHandlingStatus      , WiaPropertyValues.ScannerDeviceDocumentHandlingStatus),
         new WiaPropertyValuesInfo(WiaPropertyId.ItemFlags                                , WiaPropertyValues.ItemFlags),
         new WiaPropertyValuesInfo(WiaPropertyId.ScannerItemCurIntent                     , WiaPropertyValues.ScannerItemCurIntent),
         new WiaPropertyValuesInfo(WiaPropertyId.ScannerItemAutoDeskew                    , WiaPropertyValues.ScannerItemAutoDeskew),
         new WiaPropertyValuesInfo(WiaPropertyId.ScannerItemPhotometricInterp             , WiaPropertyValues.ScannerItemPhotometricInterp),
         new WiaPropertyValuesInfo(WiaPropertyId.ScannerItemFilmScanMode                  , WiaPropertyValues.ScannerItemFilmScanMode),
         new WiaPropertyValuesInfo(WiaPropertyId.ScannerItemLamp                          , WiaPropertyValues.ScannerItemLamp),
         new WiaPropertyValuesInfo(WiaPropertyId.ScannerDevicePreview                     , WiaPropertyValues.ScannerDevicePreview),
         new WiaPropertyValuesInfo(WiaPropertyId.ScannerItemTransferCapabilities          , WiaPropertyValues.ScannerItemTransferCapabilities),
      };

      public static void GetFormatFilterAndExtension()
      {
         WiaFileFormats format;
         if (MainForm._wiaProperties.DataTransfer.Format == WiaFileFormats.None) // GetProperties() method not called yet.
         {
            format = WiaFileFormats.Bmp;
         }
         else
         {
            format = MainForm._wiaProperties.DataTransfer.Format;
         }

         foreach (WiaSupportedFormatsInfo i in _wiaFormatsInfo)
         {
            if( format == i.Format )  // match found
            {
               _filter = i.Filter;
               _extension = i.Extension;
               return;
            }
         }
      }

      // This property is related to the GetFormatFilterAndExtension() method.
      public static string Filter
      {
         get
         {
            return _filter;
         }
      }

      // This property is related to the GetFormatFilterAndExtension() method.
      public static string Extension
      {
         get
         {
            return _extension;
         }
      }

      public static int SelectFormatFromCombo(System.Windows.Forms.ComboBox comboBoxCtrl, System.Guid guidFormat)
      {
         int ret = GetFormatNameString(guidFormat);
         if(ret != 1)
            return 0;

         for (int i = 0; i < comboBoxCtrl.Items.Count; i++)
         {
            string itemText = comboBoxCtrl.GetItemText(comboBoxCtrl.Items[i]);
            if (itemText.Length > 0)
            {
               if (itemText == FormatName)
               {
                  comboBoxCtrl.SelectedIndex = i;
                  return 1;
               }
            }
         }

         return 0;
      }

      public static int GetFormatNameString(System.Guid guidFormat)
      {
         foreach (WiaSupportedFormatsInfo i in _wiaFormatsInfo)
         {
            Guid formatGuid = Guid.Empty;
#if !LEADTOOLS_V17_OR_LATER
            WiaSession.GetFormatGuid(i.Format);
            formatGuid = WiaSession.FormatGuid;
#else
            formatGuid = WiaSession.GetFormatGuid(i.Format);
#endif //#if !LEADTOOLS_V17_OR_LATER
            if (formatGuid == guidFormat)
            {
               _formatName = i.Format.ToString();
               return 1;
            }
         }

         return 0;
      }

      // This property is related to the GetFormatNameString() method.
      public static string FormatName
      {
         get
         {
            return _formatName;
         }
      }

      public static int SelectItemFromCombo(System.Windows.Forms.ComboBox comboBoxCtrl, int value)
      {
         for (int i = 0; i < comboBoxCtrl.Items.Count; i++)
         {
            MyItemData item = (MyItemData)comboBoxCtrl.Items[i];
            if (item.ItemData == value)
            {
               comboBoxCtrl.SelectedIndex = i;
               return 1;
            }
         }

         return 0;
      }

      public static int GetSelectedFormatFromCombo(System.Windows.Forms.ComboBox comboBoxCtrl)
      {
         string itemText = comboBoxCtrl.GetItemText(comboBoxCtrl.SelectedItem);

         foreach (WiaSupportedFormatsInfo i in _wiaFormatsInfo)
         {
            if (itemText == i.Format.ToString())
            {
               _format = i.Format;
               return 1;
            }
         }

         return 0;
      }

      // This property is related to the GetSelectedFormatFromCombo() method.
      public static WiaFileFormats Format
      {
         get
         {
            return _format;
         }
      }

      public static void FindRelevantPropName(WiaPropertyId propertyId, object value)
      {
         if (propertyId == WiaPropertyId.ScannerDeviceDocumentHandlingSelect)
         {
            UInt32 val = Convert.ToUInt32(value);
            if ((val & (int)WiaScanningModeFlags.Feeder) == (int)WiaScanningModeFlags.Feeder ||
                (val & (int)WiaScanningModeFlags.Flatbed) == (int)WiaScanningModeFlags.Flatbed)
            {
               _propertyName = "Paper Source";
            }
         }
         else
         {
            _propertyName = WiaSession.GetPropertyIdString(propertyId);
         }
      }

      // This property is related to the FindRelevantPropName() method.
      public static string PropertyName
      {
         get
         {
            return _propertyName;
         }
      }

      public static void FindRelevantPropValue(WiaPropertyId propertyId, object value)
      {
         UInt32 val = Convert.ToUInt32(value);

         switch(propertyId)
         {
            case WiaPropertyId.ScannerDevicePages:
            case WiaPropertyId.ItemDepth:
            case WiaPropertyId.ScannerItemXExtent:
            case WiaPropertyId.ScannerItemYExtent:
            case WiaPropertyId.ScannerItemXRes:
            case WiaPropertyId.ScannerItemYRes:
            case WiaPropertyId.ScannerItemXPos:
            case WiaPropertyId.ScannerItemYPos:
            case WiaPropertyId.ScannerItemXScaling:
            case WiaPropertyId.ScannerItemYScaling:
            case WiaPropertyId.ScannerItemBrightness:
            case WiaPropertyId.ScannerItemContrast:
               _propertyValueString = val.ToString();
               break;

            case WiaPropertyId.ScannerDeviceOrientation:
            case WiaPropertyId.ScannerItemRotation:
               switch (val)
               {
                  case (int)WiaOrientation.Landscape:
                     _propertyValueString = "Landscape";
                     break;

                  case (int)WiaOrientation.Portrait:
                     _propertyValueString = "Portrait";
                     break;

                  case (int)WiaOrientation.Rotate180:
                     _propertyValueString = "Rotate 180";
                     break;

                  case (int)WiaOrientation.Rotate270:
                     _propertyValueString = "Rotate 270";
                     break;
               }
               break;

            case WiaPropertyId.ScannerDeviceDocumentHandlingSelect:
               switch (val)
               {
                  case (int)WiaScanningModeFlags.Feeder:
                     _propertyValueString = "Feeder";
                     break;

                  case (int)WiaScanningModeFlags.Flatbed:
                     _propertyValueString = "Flatbed";
                     break;

                  case (int)WiaScanningModeFlags.Duplex:
                     _propertyValueString = "Duplex";
                     break;

                  case (int)WiaScanningModeFlags.AutoAdvance:
                     _propertyValueString = "Auto Advance";
                     break;

                  case (int)WiaScanningModeFlags.FrontFirst:
                     _propertyValueString = "Front First";
                     break;

                  case (int)WiaScanningModeFlags.BackFirst:
                     _propertyValueString = "Back First";
                     break;

                  case (int)WiaScanningModeFlags.FrontOnly:
                     _propertyValueString = "Front Only";
                     break;

                  case (int)WiaScanningModeFlags.BackOnly:
                     _propertyValueString = "Back Only";
                     break;

                  case (int)WiaScanningModeFlags.NextPage:
                     _propertyValueString = "Next Page";
                     break;

                  case (int)WiaScanningModeFlags.Prefeed:
                     _propertyValueString = "Pre-feed";
                     break;
               }
               break;

            case WiaPropertyId.ScannerItemCurIntent:
               // Check the Image Type check boxes according to the retrieved Image type flags.
               if (val == (int)WiaImageType.Color)
               {
                  _propertyValueString = "Color";
               }
               else if (val == (int)WiaImageType.Grayscale)
               {
                  _propertyValueString = "Grayscale";
               }
               else
               {
                  _propertyValueString = "Text";
               }
               break;

            case WiaPropertyId.ItemCompression:
               switch (val)
               {
                  case (int)WiaCompressionMode.None:
                     _propertyValueString = "None";
                     break;

                  case (int)WiaCompressionMode.Rle4:
                     _propertyValueString = "RLE4 Compression";
                     break;

                  case (int)WiaCompressionMode.Rle8:
                     _propertyValueString = "RLE8 Compression";
                     break;

                  case (int)WiaCompressionMode.Group3:
                     _propertyValueString = "Group 3 Compression";
                     break;

                  case (int)WiaCompressionMode.Group4:
                     _propertyValueString = "Group 4 Compression";
                     break;

                  case (int)WiaCompressionMode.Jpeg:
                     _propertyValueString = "JPEG Compression";
                     break;

                  case (int)WiaCompressionMode.Jbig:
                     _propertyValueString = "JBIG compression";
                     break;

                  case (int)WiaCompressionMode.Jpeg2000:
                     _propertyValueString = "JPEG 2000 compression";
                     break;

                  case (int)WiaCompressionMode.Png:
                     _propertyValueString = "PNG compression";
                     break;
               }
               break;

            case WiaPropertyId.ItemTymed:
               switch (val)
               {
                  case (int)WiaTransferMode.Memory:
                     _propertyValueString = "Memory Transfer";
                     break;

                  case (int)WiaTransferMode.File:
                     _propertyValueString = "File Transfer";
                     break;
               }
               break;

            case WiaPropertyId.ItemDatatype:
               switch (val)
               {
                  case (int)WiaImageDataType.Threshold:
                     _propertyValueString = "Threshold";
                     break;

                  case (int)WiaImageDataType.Dither:
                     _propertyValueString = "Dither";
                     break;

                  case (int)WiaImageDataType.Grayscale:
                     _propertyValueString = "Grayscale";
                     break;

                  case (int)WiaImageDataType.Color:
                     _propertyValueString = "Color";
                     break;

                  case (int)WiaImageDataType.ColorThreshold:
                     _propertyValueString = "Color Threshold";
                     break;

                  case (int)WiaImageDataType.ColorDither:
                     _propertyValueString = "Color Dither";
                     break;
               }
               break;

            case WiaPropertyId.ItemFormat:
               System.Guid guidFormat = (System.Guid)value;
               GetFormatNameString(guidFormat);
               _propertyValueString = FormatName;
               break;
         }
      }

      // This property is related to the FindRelevantPropValue() method.
      public static string PropertyValueString
      {
         get
         {
            return _propertyValueString;
         }
      }

      public static void FillComboWithValidValues(System.Windows.Forms.ComboBox comboBoxCtrl, WiaCapability capability)
      {
         if (capability.Values.ListValues.ValuesCount <= 0 || capability.Values.ListValues.Values == null)
            return;

         MyItemData item = new MyItemData();
         int value = 0;

         foreach (object i in capability.Values.ListValues.Values)
         {
            value = Convert.ToInt32(i);
            // If Bits per pixel property, then just add the received values.
            if(capability.PropertyId == WiaPropertyId.ItemDepth         ||
               capability.PropertyId == WiaPropertyId.ScannerItemXRes   || 
               capability.PropertyId == WiaPropertyId.ScannerItemYRes)
            {
               item.ItemData = value;
               item.ItemString = value.ToString();
               comboBoxCtrl.Items.Add(item);
            }
            else
            {
               int ret = GetWiaListPropertyValueString(capability.PropertyId, value);
               if(ret == 1)
               {
                  item.ItemData = value;
                  item.ItemString = ListPropertyValueString;
                  comboBoxCtrl.Items.Add(item);
               }
            }
         }
      }

      public static int GetWiaListPropertyValueString(WiaPropertyId propertyId, int value)
      {
         bool found = false;

         foreach (WiaPropertyValuesInfo i in _wiaPropertyValuesInfo)
         {
            if(i.PropertyId == propertyId)
            {
               foreach (WiaPropertyValues j in i.Values)
               {
                  if(j.ValueId == value)
                  {
                     _listPropertyValueString = j.ValueNameString;
                     found = true;
                     break;
                  }
               }

               if(found == true)
                  return 1;
            }
         }
         return 0;
      }

      // This property is related to the GetWiaListPropertyValueString() method.
      public static string ListPropertyValueString
      {
         get
         {
            return _listPropertyValueString;
         }
      }

      public static int GetWiaFlagPropertyValueString(WiaPropertyId propertyId, Int32 value)
      {
         int foundCount = 0;

         MainForm._flagValuesStrings.Clear();

         foreach (WiaPropertyValuesInfo i in _wiaPropertyValuesInfo)
         {
            if (i.PropertyId == propertyId)
            {
               foreach (WiaPropertyValues j in i.Values)
               {
                  if ((value & j.ValueId) == j.ValueId)
                  {
                     MainForm._flagValuesStrings.Add(j.ValueNameString);
                     foundCount++;
                  }
               }

               if (foundCount > 0)
                  return 1;
            }
         }

         return 0;
      }
   }
}
