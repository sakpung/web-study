// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Drawing;

using Leadtools;
using Leadtools.Codecs;
using Leadtools.WinForms.CommonDialogs.File;

namespace PrinterDemo
{
   public class ImageFileSaver
   {
      private string _fileName;
      private RasterImageFormat _format;
      private RasterDialogFileTypesIndex _fileTypeIndex;
      private int _fileSubTypeIndex;
      private int _bitsPerPixel;
      private int _firstPage;
      private int _lastPage;
      private int _savePageNumber;
      private CodecsSavePageMode _pageMode;
      private RasterSaveDialogFileFormatsList _saveFormats;
      private bool _autoSave;
#if LEADTOOLS_V16_OR_LATER
      private FileSavePdfProfiles _pdfProfile;
#endif

      public ImageFileSaver()
      {
         _fileName = string.Empty;
         _bitsPerPixel = 24;
         _firstPage = 0;
         _lastPage = 0;
         _savePageNumber = 1;
         _pageMode = CodecsSavePageMode.Overwrite;
         _saveFormats = null;
         _fileTypeIndex = RasterDialogFileTypesIndex.Lead;
         _fileSubTypeIndex = (int)RasterDialogCmpSubTypesIndex.Progressive;
         _autoSave = true;
#if LEADTOOLS_V16_OR_LATER
         _pdfProfile = FileSavePdfProfiles.Pdf14;
#endif
      }

      public string FileName
      {
         get
         {
            return _fileName;
         }
         set
         {
            _fileName = value;
         }
      }

      public RasterSaveDialogFileFormatsList SaveFormats
      {
         get
         {
            return _saveFormats;
         }
         set
         {
            _saveFormats = value;
         }
      }

      public RasterDialogFileTypesIndex FormatIndex
      {
         get
         {
            return _fileTypeIndex;
         }
         set
         {
            _fileTypeIndex = value;
         }
      }

      public int SubTypeIndex
      {
         get
         {
            return _fileSubTypeIndex;
         }
         set
         {
            _fileSubTypeIndex = value;
         }
      }

      public RasterImageFormat Format
      {
         get
         {
            return _format;
         }
      }

      public int BitsPerPixel
      {
         get
         {
            return _bitsPerPixel;
         }
      }

      public int FirstPage
      {
         get
         {
            return _firstPage;
         }
      }

      public int LastPage
      {
         get
         {
            return _lastPage;
         }
      }

      public int SavePageNumber
      {
         get
         {
            return _savePageNumber;
         }
      }

      public CodecsSavePageMode PageMode
      {
         get
         {
            return _pageMode;
         }
      }

      public bool AutoSave
      {
         get
         {
            return _autoSave;
         }
         set
         {
            _autoSave = value;
         }
      }

#if LEADTOOLS_V16_OR_LATER
      public FileSavePdfProfiles PdfProfile
      {
         get
         {
            return _pdfProfile;
         }

         set
         {
            _pdfProfile = value;
         }
      }
#endif

      public bool Save(IWin32Window owner, RasterCodecs codecs, List<string> tempFiles, bool viewOutputFile)
      {
         _format = RasterImageFormat.Unknown;
         _firstPage = -1;
         _lastPage = -1;
         _savePageNumber = -1;
         _pageMode = CodecsSavePageMode.Overwrite;

         RasterSaveDialog dlg = new RasterSaveDialog(codecs);

         dlg.PromptOverwrite = true;
         dlg.ShowFileOptionsBasicJ2kOptions = false;
         dlg.ShowFileOptionsJ2kOptions = false;
         dlg.ShowFileOptionsJbig2Options = false;
#if LEADTOOLS_V16_OR_LATER
         dlg.ShowPdfProfiles = true;
         dlg.PdfProfile = PdfProfile;
#endif // #if LEADTOOLS_V16_OR_LATER
         dlg.ShowFileOptionsMultipage = true;
         dlg.ShowFileOptionsProgressive = true;
         dlg.ShowFileOptionsQualityFactor = true;
         dlg.ShowFileOptionsStamp = true;
         dlg.ShowOptions = true;
         dlg.ShowQualityFactor = true;
         dlg.PageNumber = SavePageNumber;
         dlg.Title = "LEADTOOLS Save Dialog";
         dlg.EnableSizing = true;
         dlg.FileName = FileName;
         dlg.FileSubTypeIndex = _fileSubTypeIndex;
         dlg.FileTypeIndex = _fileTypeIndex;
         dlg.BitsPerPixel = 0;

         if (null == SaveFormats)
         {
            dlg.FileFormatsList = new RasterSaveDialogFileFormatsList(RasterDialogFileFormatDataContent.Default);
         }
         else
         {
            dlg.FileFormatsList = SaveFormats;
         }

         if (dlg.ShowDialog(owner) == DialogResult.OK)
         {
            Application.DoEvents();

            (owner as FrmMain).Cursor = Cursors.WaitCursor;
            FileName = dlg.FileName;
            _fileSubTypeIndex = dlg.FileSubTypeIndex;
            _fileTypeIndex = dlg.FileTypeIndex;
            _format = dlg.Format;
            _bitsPerPixel = dlg.BitsPerPixel;
            _firstPage = dlg.PageNumber;
            _lastPage = dlg.PageNumber;
            _savePageNumber = dlg.PageNumber;
            _pageMode = dlg.MultiPage;

            if (_autoSave)
            {
               switch (dlg.Format)
               {
                  case RasterImageFormat.Abc:
                     {
                        codecs.Options.Abc.Save.QualityFactor = dlg.AbcQualityFactor;

                        break;
                     }
#if !LEADTOOLS_V20_OR_LATER
                  case RasterImageFormat.Ecw:
                     {
                        codecs.Options.Ecw.Save.QualityFactor = dlg.QualityFactor;

                        break;
                     }
#endif // #if !LEADTOOLS_V20_OR_LATER
                  case RasterImageFormat.Png:
                     {
                        codecs.Options.Png.Save.QualityFactor = dlg.QualityFactor;
                        codecs.Options.Save.InitAlpha = true;
                        break;
                     }

                  case RasterImageFormat.PngIco:
                     {
                        codecs.Options.Save.InitAlpha = true;
                        break;
                     }

                  case RasterImageFormat.Cmp:
                     {
                        codecs.Options.Jpeg.Save.QualityFactor = dlg.QualityFactor;
                        codecs.Options.Jpeg.Save.CmpQualityFactorPredefined = dlg.CmpQualityFactor;

                        break;
                     }
                  case RasterImageFormat.Xps:
                     {
                        codecs.Options.Save.InitAlpha = true;

                        break;
                     }

                  default:
                     {
                        codecs.Options.Jpeg.Save.QualityFactor = dlg.QualityFactor;

                        break;
                     }
               }

               codecs.Options.Jpeg.Save.SaveWithStamp = dlg.WithStamp;
               codecs.Options.Jpeg.Save.StampWidth = dlg.StampWidth;
               codecs.Options.Jpeg.Save.StampHeight = dlg.StampHeight;
               codecs.Options.Jpeg.Save.StampBitsPerPixel = dlg.StampBitsPerPixel;

               if ((Format == RasterImageFormat.Cmw) ||
                  (Format == RasterImageFormat.J2k) ||
                  (Format == RasterImageFormat.Jp2) ||
                  (Format == RasterImageFormat.TifJ2k))
               {
#if !LEADTOOLS_V19_OR_LATER
                  codecs.Options.Jpeg2000.Save.CodeBlockHeight = dlg.FileJ2kOptions.CodeBlockHeight;
                  codecs.Options.Jpeg2000.Save.CodeBlockWidth = dlg.FileJ2kOptions.CodeBlockWidth;
                  codecs.Options.Jpeg2000.Save.DerivedBaseExponent = dlg.FileJ2kOptions.DerivedBaseExponent;
                  codecs.Options.Jpeg2000.Save.DerivedBaseMantissa = dlg.FileJ2kOptions.DerivedBaseMantissa;
                  codecs.Options.Jpeg2000.Save.ErrorResilienceSymbol = dlg.FileJ2kOptions.ErrorResilienceSymbol;
                  codecs.Options.Jpeg2000.Save.GuardBits = dlg.FileJ2kOptions.GuardBits;
                  codecs.Options.Jpeg2000.Save.PredictableTermination = dlg.FileJ2kOptions.PredictableTermination;
                  codecs.Options.Jpeg2000.Save.ResetContextOnBoundaries = dlg.FileJ2kOptions.ResetContextOnBoundaries;
                  codecs.Options.Jpeg2000.Save.SelectiveAcBypass = dlg.FileJ2kOptions.SelectiveAcBypass;
                  codecs.Options.Jpeg2000.Save.TerminationOnEachPass = dlg.FileJ2kOptions.TerminationOnEachPass;
                  codecs.Options.Jpeg2000.Save.VerticallyCausalContext = dlg.FileJ2kOptions.VerticallyCausalContext;
#endif // #if !LEADTOOLS_V19_OR_LATER
                  codecs.Options.Jpeg2000.Save.CompressionControl = dlg.FileJ2kOptions.CompressionControl;
                  codecs.Options.Jpeg2000.Save.CompressionRatio = dlg.FileJ2kOptions.CompressionRatio;
                  codecs.Options.Jpeg2000.Save.DecompositionLevels = dlg.FileJ2kOptions.DecompositionLevels;
                  codecs.Options.Jpeg2000.Save.DerivedQuantization = dlg.FileJ2kOptions.DerivedQuantization;
                  codecs.Options.Jpeg2000.Save.ImageAreaHorizontalOffset = dlg.FileJ2kOptions.ImageAreaHorizontalOffset;
                  codecs.Options.Jpeg2000.Save.ImageAreaVerticalOffset = dlg.FileJ2kOptions.ImageAreaVerticalOffset;
                  codecs.Options.Jpeg2000.Save.ProgressingOrder = dlg.FileJ2kOptions.ProgressingOrder;
                  codecs.Options.Jpeg2000.Save.ReferenceTileHeight = dlg.FileJ2kOptions.ReferenceTileHeight;
                  codecs.Options.Jpeg2000.Save.ReferenceTileWidth = dlg.FileJ2kOptions.ReferenceTileWidth;
                  codecs.Options.Jpeg2000.Save.RegionOfInterest = dlg.FileJ2kOptions.RegionOfInterest;
                  codecs.Options.Jpeg2000.Save.RegionOfInterestRectangle = dlg.FileJ2kOptions.RegionOfInterestRectangle;
                  codecs.Options.Jpeg2000.Save.RegionOfInterestWeight = dlg.FileJ2kOptions.RegionOfInterestWeight;
                  codecs.Options.Jpeg2000.Save.TargetFileSize = dlg.FileJ2kOptions.TargetFileSize;
                  codecs.Options.Jpeg2000.Save.TileHorizontalOffset = dlg.FileJ2kOptions.TileHorizontalOffset;
                  codecs.Options.Jpeg2000.Save.TileVerticalOffset = dlg.FileJ2kOptions.TileVerticalOffset;
                  codecs.Options.Jpeg2000.Save.UseColorTransform = dlg.FileJ2kOptions.UseColorTransform;
                  codecs.Options.Jpeg2000.Save.UseEphMarker = dlg.FileJ2kOptions.UseEphMarker;
                  codecs.Options.Jpeg2000.Save.UseRegionOfInterest = dlg.FileJ2kOptions.UseRegionOfInterest;
                  codecs.Options.Jpeg2000.Save.UseSopMarker = dlg.FileJ2kOptions.UseSopMarker;
               }

               if ((Format == RasterImageFormat.TifJbig2) ||
                   (Format == RasterImageFormat.Jbig2))
               {
                  codecs.Options.Jbig2.Save.EnableDictionary = dlg.FileJbig2Options.EnableDictionary;
                  codecs.Options.Jbig2.Save.ImageGbatX1 = dlg.FileJbig2Options.ImageGbatX1;
                  codecs.Options.Jbig2.Save.ImageGbatX2 = dlg.FileJbig2Options.ImageGbatX2;
                  codecs.Options.Jbig2.Save.ImageGbatX3 = dlg.FileJbig2Options.ImageGbatX3;
                  codecs.Options.Jbig2.Save.ImageGbatX4 = dlg.FileJbig2Options.ImageGbatX4;
                  codecs.Options.Jbig2.Save.ImageGbatY1 = dlg.FileJbig2Options.ImageGbatY1;
                  codecs.Options.Jbig2.Save.ImageGbatY2 = dlg.FileJbig2Options.ImageGbatY2;
                  codecs.Options.Jbig2.Save.ImageGbatY3 = dlg.FileJbig2Options.ImageGbatY3;
                  codecs.Options.Jbig2.Save.ImageGbatY4 = dlg.FileJbig2Options.ImageGbatY4;
                  codecs.Options.Jbig2.Save.ImageQualityFactor = dlg.FileJbig2Options.ImageQualityFactor;
                  codecs.Options.Jbig2.Save.ImageTemplateType = dlg.FileJbig2Options.ImageTemplateType;
                  codecs.Options.Jbig2.Save.ImageTypicalPredictionOn = dlg.FileJbig2Options.ImageTypicalPredictionOn;
                  codecs.Options.Jbig2.Save.RemoveEofSegment = dlg.FileJbig2Options.RemoveEofSegment;
                  codecs.Options.Jbig2.Save.RemoveEopSegment = dlg.FileJbig2Options.RemoveEopSegment;
                  codecs.Options.Jbig2.Save.RemoveHeaderSegment = dlg.FileJbig2Options.RemoveHeaderSegment;
                  codecs.Options.Jbig2.Save.RemoveMarker = dlg.FileJbig2Options.RemoveMarker;
                  codecs.Options.Jbig2.Save.TextDifferentialThreshold = dlg.FileJbig2Options.TextDifferentialThreshold;
                  codecs.Options.Jbig2.Save.TextGbatX1 = dlg.FileJbig2Options.TextGbatX1;
                  codecs.Options.Jbig2.Save.TextGbatX2 = dlg.FileJbig2Options.TextGbatX2;
                  codecs.Options.Jbig2.Save.TextGbatX3 = dlg.FileJbig2Options.TextGbatX3;
                  codecs.Options.Jbig2.Save.TextGbatX4 = dlg.FileJbig2Options.TextGbatX4;
                  codecs.Options.Jbig2.Save.TextGbatY1 = dlg.FileJbig2Options.TextGbatY1;
                  codecs.Options.Jbig2.Save.TextGbatY2 = dlg.FileJbig2Options.TextGbatY2;
                  codecs.Options.Jbig2.Save.TextGbatY3 = dlg.FileJbig2Options.TextGbatY3;
                  codecs.Options.Jbig2.Save.TextGbatY4 = dlg.FileJbig2Options.TextGbatY4;
                  codecs.Options.Jbig2.Save.TextKeepAllSymbols = dlg.FileJbig2Options.TextKeepAllSymbols;
                  codecs.Options.Jbig2.Save.TextMaximumSymbolArea = dlg.FileJbig2Options.TextMaximumSymbolArea;
                  codecs.Options.Jbig2.Save.TextMaximumSymbolHeight = dlg.FileJbig2Options.TextMaximumSymbolHeight;
                  codecs.Options.Jbig2.Save.TextMaximumSymbolWidth = dlg.FileJbig2Options.TextMaximumSymbolWidth;
                  codecs.Options.Jbig2.Save.TextMinimumSymbolArea = dlg.FileJbig2Options.TextMinimumSymbolArea;
                  codecs.Options.Jbig2.Save.TextMinimumSymbolHeight = dlg.FileJbig2Options.TextMinimumSymbolHeight;
                  codecs.Options.Jbig2.Save.TextMinimumSymbolWidth = dlg.FileJbig2Options.TextMinimumSymbolWidth;
                  codecs.Options.Jbig2.Save.TextQualityFactor = dlg.FileJbig2Options.TextQualityFactor;
                  codecs.Options.Jbig2.Save.TextRemoveUnrepeatedSymbol = dlg.FileJbig2Options.TextRemoveUnrepeatedSymbol;
                  codecs.Options.Jbig2.Save.TextTemplateType = dlg.FileJbig2Options.TextTemplateType;
                  codecs.Options.Jbig2.Save.XResolution = dlg.FileJbig2Options.XResolution;
                  codecs.Options.Jbig2.Save.YResolution = dlg.FileJbig2Options.YResolution;
               }

               if (Format == RasterImageFormat.Gif)
               {
                  codecs.Options.Gif.Save.Interlaced = dlg.Interlaced;
               }

#if LEADTOOLS_V16_OR_LATER
               PdfProfile = dlg.PdfProfile;
               if ((Format == RasterImageFormat.RasPdf) ||
                   (Format == RasterImageFormat.RasPdfG31Dim) ||
                   (Format == RasterImageFormat.RasPdfG32Dim) ||
                   (Format == RasterImageFormat.RasPdfG4) ||
                   (Format == RasterImageFormat.RasPdfJbig2) ||
                   (Format == RasterImageFormat.RasPdfJpeg) ||
                   (Format == RasterImageFormat.RasPdfJpeg422) ||
                   (Format == RasterImageFormat.RasPdfJpeg411))
               {

                  codecs.Options.Pdf.Save.SavePdfA = false;
                  codecs.Options.Pdf.Save.SavePdfv13 = false;
                  codecs.Options.Pdf.Save.SavePdfv14 = false;
                  codecs.Options.Pdf.Save.SavePdfv15 = false;
                  codecs.Options.Pdf.Save.SavePdfv16 = false;

                  switch (PdfProfile)
                  {
                     case FileSavePdfProfiles.PdfA: codecs.Options.Pdf.Save.SavePdfA = true; break;
                     case FileSavePdfProfiles.Pdf13: codecs.Options.Pdf.Save.SavePdfv13 = true; break;
                     case FileSavePdfProfiles.Pdf14: codecs.Options.Pdf.Save.SavePdfv14 = true; break;
                     case FileSavePdfProfiles.Pdf15: codecs.Options.Pdf.Save.SavePdfv15 = true; break;
                     case FileSavePdfProfiles.Pdf16: codecs.Options.Pdf.Save.SavePdfv16 = true; break;
                  }
               }
#endif
               RasterImage image = codecs.Load(tempFiles[0]);
               for (int i = 1; i < tempFiles.Count; i++)
               {
                  image.AddPage(codecs.Load(tempFiles[i]));
               }

               if (_format == RasterImageFormat.Ani ||
                   _format == RasterImageFormat.Gif ||
                   _format == RasterImageFormat.Cals ||
                   _format == RasterImageFormat.Cals2 ||
                   _format == RasterImageFormat.Cals3 ||
                   _format == RasterImageFormat.Cals4 ||
                   _format == RasterImageFormat.Pcx ||
                   _format == RasterImageFormat.Fpx ||
                   _format == RasterImageFormat.FpxJpeg ||
                   _format == RasterImageFormat.FpxJpegQFactor ||
                   _format == RasterImageFormat.FpxSingleColor ||
                   _format == RasterImageFormat.Flc ||
                   _format == RasterImageFormat.IffCat ||
                   _format == RasterImageFormat.IcaAbic ||
                   _format == RasterImageFormat.IcaG31Dim ||
                   _format == RasterImageFormat.IcaG32Dim ||
                   _format == RasterImageFormat.IcaG4 ||
                   _format == RasterImageFormat.IcaIbmMmr ||
                   _format == RasterImageFormat.IcaUncompressed ||
                   _format == RasterImageFormat.AfpIcaG31Dim ||
                   _format == RasterImageFormat.AfpIcaG32Dim ||
                   _format == RasterImageFormat.AfpIcaG4 ||
                   _format == RasterImageFormat.AfpIcaIbmMmr ||
                   _format == RasterImageFormat.AfpIcaUncompressed ||
                   _format == RasterImageFormat.Mng ||
                   _format == RasterImageFormat.MngGray ||
                   _format == RasterImageFormat.MngJng ||
                   _format == RasterImageFormat.MngJng411 ||
                   _format == RasterImageFormat.MngJng422 ||
                   _format == RasterImageFormat.Pct ||
                   _format == RasterImageFormat.Pcx ||
                   _format == RasterImageFormat.RasPdf ||
                   _format == RasterImageFormat.RasPdfCmyk ||
                   _format == RasterImageFormat.RasPdfG31Dim ||
                   _format == RasterImageFormat.RasPdfG32Dim ||
                   _format == RasterImageFormat.RasPdfG4 ||
                   _format == RasterImageFormat.RasPdfJbig2 ||
                   _format == RasterImageFormat.RasPdfJpeg ||
                   _format == RasterImageFormat.RasPdfJpeg411 ||
                   _format == RasterImageFormat.RasPdfJpeg422 ||
                   _format == RasterImageFormat.RasPdfLzw ||
                   _format == RasterImageFormat.RasPdfLzwCmyk ||
                   _format == RasterImageFormat.Sff ||
                   _format == RasterImageFormat.Ccitt ||
                   _format == RasterImageFormat.CcittGroup31Dim ||
                   _format == RasterImageFormat.CcittGroup32Dim ||
                   _format == RasterImageFormat.CcittGroup4 ||
                   _format == RasterImageFormat.GeoTiff ||
                   _format == RasterImageFormat.Exif ||
                   _format == RasterImageFormat.ExifJpeg ||
                   _format == RasterImageFormat.ExifJpeg411 ||
                   _format == RasterImageFormat.ExifJpeg422 ||
                   _format == RasterImageFormat.ExifYcc ||
                   _format == RasterImageFormat.Tif ||
                   _format == RasterImageFormat.TifAbc ||
                   _format == RasterImageFormat.TifAbic ||
                   _format == RasterImageFormat.TifCmp ||
                   _format == RasterImageFormat.TifCmw ||
                   _format == RasterImageFormat.TifCmyk ||
                   _format == RasterImageFormat.TifCustom ||
                   _format == RasterImageFormat.TifDxf ||
                   _format == RasterImageFormat.TifJ2k ||
                   _format == RasterImageFormat.TifJbig ||
                   _format == RasterImageFormat.TifJbig2 ||
                   _format == RasterImageFormat.TifJpeg ||
                   _format == RasterImageFormat.TifJpeg411 ||
                   _format == RasterImageFormat.TifJpeg422 ||
                   _format == RasterImageFormat.TifLead1Bit ||
                   _format == RasterImageFormat.TifLzw ||
                   _format == RasterImageFormat.TifLzwCmyk ||
                   _format == RasterImageFormat.TifLzwYcc ||
                   _format == RasterImageFormat.TifPackBits ||
                   _format == RasterImageFormat.TifPackBitsCmyk ||
                   _format == RasterImageFormat.TifPackbitsYcc ||
                   _format == RasterImageFormat.TifUnknown ||
                   _format == RasterImageFormat.TifxFaxG31D ||
                   _format == RasterImageFormat.TifxFaxG32D ||
                   _format == RasterImageFormat.TifxFaxG4 ||
                   _format == RasterImageFormat.TifxJbig ||
                   _format == RasterImageFormat.TifxJbigT43 ||
                   _format == RasterImageFormat.TifxJbigT43Gs ||
                   _format == RasterImageFormat.TifxJbigT43ItuLab ||
                   _format == RasterImageFormat.TifxJpeg ||
                   _format == RasterImageFormat.TifYcc ||
                   _format == RasterImageFormat.TifZip)
               {
                  codecs.Save(image,
                     _fileName,
                     _format,
                     _bitsPerPixel,
                     image.Page,
                     image.PageCount,
                     _savePageNumber,
                     _pageMode);

                  if (viewOutputFile)
                     System.Diagnostics.Process.Start(_fileName);
               }
               else
               {
                  for (int i = 0; i < image.PageCount; i++)
                  {
                     string ext = System.IO.Path.GetExtension(_fileName);
                     int index = _fileName.IndexOf(ext);
                     string newFileName = _fileName.Insert(index, "_" + (i + 1).ToString());

                     image.Page = i + 1;
                     codecs.Save(image,
                     newFileName,
                     _format,
                     _bitsPerPixel, i + 1, i + 1, 0, CodecsSavePageMode.Overwrite);
                  }

                  string ext2 = System.IO.Path.GetExtension(_fileName);
                  int index2 = _fileName.IndexOf(ext2);
                  string openFileName = _fileName.Insert(index2, "_" + 1.ToString());

                  if (viewOutputFile)
                     System.Diagnostics.Process.Start(openFileName);
               }

               if (image != null)
                  image.Dispose();
            }  

            return true;
         }
         else
            return false;
      }
   }
}
