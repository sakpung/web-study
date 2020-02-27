// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Windows.Forms;
using System.Text;
using System.Drawing;

using Leadtools;
using Leadtools.Codecs;
using Leadtools.WinForms.CommonDialogs.File;
using Leadtools.Demos;

#if ! LEADTOOLS_V17_OR_LATER
using LeadPoint = System.Drawing.Point;
using LeadSize = System.Drawing.Size;
using LeadRect = System.Drawing.Rectangle;
#endif // #if !LEADTOOLS_V17_OR_LATER

#if LEADTOOLS_V17_OR_LATER
using Leadtools.Drawing;
#endif // #if LEADTOOLS_V17_OR_LATER

namespace PdfCompDemo
{
   public class PdfImageFileLoader
   {
      private static int _filterIndex = 1;
      private string _fileName;
      private RasterOpenDialogLoadFormat[] _filters;
      private RasterImage _image;
      private bool _loadOnlyOnePage = false;
      private int _firstPage;
      private int _lastPage;
      private bool _showLoadPagesDialog = false;
      private RasterDialogFileOptionsType _FileFormatType;
      private static bool _firstPdfLoaded = false;

      public PdfImageFileLoader( )
      {
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

      public RasterImage Image
      {
         get
         {
            return _image;
         }
      }

      public RasterOpenDialogLoadFormat[] Filters
      {
         get
         {
            return _filters;
         }
         set
         {
            _filters = value;
         }
      }

      public bool ShowLoadPagesDialog
      {
         get
         {
            return _showLoadPagesDialog;
         }
         set
         {
            _showLoadPagesDialog = value;
         }
      }

      public bool LoadOnlyOnePage
      {
         get
         {
            return _loadOnlyOnePage;
         }
         set
         {
            _loadOnlyOnePage = value;
         }
      }

      public static int FilterIndex
      {
         get
         {
            return _filterIndex;
         }
         set
         {
            _filterIndex = value;
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

      public RasterDialogFileOptionsType FileFormatType
      {
         get
         {
            return _FileFormatType;
         }
      }

      public bool Load(IWin32Window owner, RasterCodecs codecs, bool autoLoad)
      {
#if LEADTOOLS_V16_OR_LATER && !LEADTOOLS_V17_OR_LATER
      // Load using the RasterizeDocument options
      codecs.Options.RasterizeDocument.Load.Enabled = true;
#endif

         RasterOpenDialog ofd = new RasterOpenDialog(codecs);

         ofd.DereferenceLinks = true;
         ofd.CheckFileExists = false;
         ofd.CheckPathExists = true;
         ofd.EnableSizing = true;
         ofd.Filter = Filters;
         ofd.FilterIndex = _filterIndex;
         ofd.LoadFileImage = false;
         ofd.LoadOptions = false;
         ofd.LoadRotated = true;
         ofd.LoadCompressed = true;
         ofd.Multiselect = false;
         ofd.ShowGeneralOptions = true;
         ofd.ShowLoadCompressed = true;
         ofd.ShowLoadOptions = true;
         ofd.ShowLoadRotated = true;
         ofd.ShowMultipage = true;
         ofd.ShowPdfOptions = true;
         ofd.ShowPreview = true;
         ofd.ShowProgressive = true;
         ofd.ShowRasterOptions = true;
         ofd.ShowTotalPages = true;
         ofd.ShowDeletePage = true;
         ofd.ShowFileInformation = true;
         ofd.UseFileStamptoPreview = true;
         ofd.PreviewWindowVisible = true;
         ofd.Title = "LEADTOOLS Open Dialog";
         ofd.FileName = FileName;
#if LEADTOOLS_V16_OR_LATER
         ofd.ShowRasterizeDocumentOptions = true;
         ofd.ShowXlsOptions = true;
#endif
         bool ok = false;

         if(ofd.ShowDialog(owner) == DialogResult.OK)
         {
            RasterDialogFileData firstItem = ofd.OpenedFileData[0] as RasterDialogFileData;
            FileName = firstItem.Name;

            ok = true;

            _filterIndex = ofd.FilterIndex;

            CodecsImageInfo info;

            using(WaitCursor wait = new WaitCursor())
               info = codecs.GetInformation(FileName, true);

            if(info.Format == RasterImageFormat.RasPdf ||
               info.Format == RasterImageFormat.RasPdfG31Dim ||
               info.Format == RasterImageFormat.RasPdfG32Dim ||
               info.Format == RasterImageFormat.RasPdfG4 ||
               info.Format == RasterImageFormat.RasPdfJpeg ||
               info.Format == RasterImageFormat.RasPdfJpeg422 ||
               info.Format == RasterImageFormat.RasPdfJpeg411)
            {
               if(!codecs.Options.Pdf.IsEngineInstalled)
               {
#if !LEADTOOLS_V17_OR_LATER
                  PdfEngineDialog dlg = new PdfEngineDialog();
                  if(dlg.ShowDialog(owner) != DialogResult.OK)
                     return false;
#endif
               }
            }

#if LEADTOOLS_V16_OR_LATER
         // Set the RasterizeDocument load options before calling GetInformation
#if !LEADTOOLS_V17_OR_LATER
            codecs.Options.RasterizeDocument.Load.Enabled = firstItem.Options.RasterizeDocumentOptions.Enabled;
#endif
            codecs.Options.RasterizeDocument.Load.PageWidth = firstItem.Options.RasterizeDocumentOptions.PageWidth;
            codecs.Options.RasterizeDocument.Load.PageHeight = firstItem.Options.RasterizeDocumentOptions.PageHeight;
            codecs.Options.RasterizeDocument.Load.LeftMargin = firstItem.Options.RasterizeDocumentOptions.LeftMargin;
            codecs.Options.RasterizeDocument.Load.TopMargin = firstItem.Options.RasterizeDocumentOptions.TopMargin;
            codecs.Options.RasterizeDocument.Load.RightMargin = firstItem.Options.RasterizeDocumentOptions.RightMargin;
            codecs.Options.RasterizeDocument.Load.BottomMargin = firstItem.Options.RasterizeDocumentOptions.BottomMargin;
            codecs.Options.RasterizeDocument.Load.Unit = firstItem.Options.RasterizeDocumentOptions.Unit;
            codecs.Options.RasterizeDocument.Load.XResolution = firstItem.Options.RasterizeDocumentOptions.XResolution;
            codecs.Options.RasterizeDocument.Load.YResolution = firstItem.Options.RasterizeDocumentOptions.YResolution;
            codecs.Options.RasterizeDocument.Load.SizeMode = firstItem.Options.RasterizeDocumentOptions.SizeMode;
#endif

            // Set the user Options
            codecs.Options.Load.Passes = firstItem.Passes;
            codecs.Options.Load.Rotated = firstItem.LoadRotated;
            codecs.Options.Load.Compressed = firstItem.LoadCompressed;
            _FileFormatType = firstItem.Options.FileType;

            switch(firstItem.Options.FileType)
            {
               case RasterDialogFileOptionsType.Meta:
                  {
                     // Set the user options               
                     codecs.Options.Wmf.Load.XResolution = firstItem.Options.MetaOptions.XResolution;
                     codecs.Options.Wmf.Load.YResolution = firstItem.Options.MetaOptions.XResolution;

                     break;
                  }

               case RasterDialogFileOptionsType.Pdf:
                  {
                     if(codecs.Options.Pdf.IsEngineInstalled)
                     {
#if !LEADTOOLS_V175_OR_LATER
                        if(!_firstPdfLoaded)
                        {
                           PdfDPIOptions DPIOptions = new PdfDPIOptions();

                           if(DPIOptions.ShowDialog() == DialogResult.OK)
                           {
                              codecs.Options.Pdf.Load.XResolution = DPIOptions.XResolution;
                              codecs.Options.Pdf.Load.YResolution = DPIOptions.YResolution;
                              _firstPdfLoaded = true;
                           }
                           else
                           {
                              codecs.Options.Pdf.Load.XResolution = 150;
                              codecs.Options.Pdf.Load.YResolution = 150;
                           }
                        }
                        else
                        {
                           // Set the user options
                           codecs.Options.Pdf.Load.DisplayDepth = firstItem.Options.PdfOptions.DisplayDepth;
                           codecs.Options.Pdf.Load.GraphicsAlpha = firstItem.Options.PdfOptions.GraphicsAlpha;
                           codecs.Options.Pdf.Load.TextAlpha = firstItem.Options.PdfOptions.TextAlpha;
                           codecs.Options.Pdf.Load.UseLibFonts = firstItem.Options.PdfOptions.UseLibFonts;
                        }
#endif
                     }

                     break;
                  }

               case RasterDialogFileOptionsType.Misc:
                  {
                     switch(firstItem.FileInfo.Format)
                     {
                        case RasterImageFormat.Jbig:
                           {
                              // Set the user options
                              codecs.Options.Jbig.Load.Resolution = new LeadSize(firstItem.Options.MiscOptions.XResolution,
                                                                              firstItem.Options.MiscOptions.YResolution);
                              break;
                           }

                        case RasterImageFormat.Cmw:
                           {
                              // Set the user options
                              codecs.Options.Jpeg2000.Load.CmwResolution = new LeadSize(firstItem.Options.MiscOptions.XResolution,
                                                                                    firstItem.Options.MiscOptions.YResolution);
                              break;
                           }

                        case RasterImageFormat.Jp2:
                           {
                              // Set the user options
                              codecs.Options.Jpeg2000.Load.Jp2Resolution = new LeadSize(firstItem.Options.MiscOptions.XResolution,
                                                                                    firstItem.Options.MiscOptions.YResolution);
                              break;
                           }

                        case RasterImageFormat.J2k:
                           {
                              // Set the user options
                              codecs.Options.Jpeg2000.Load.J2kResolution = new LeadSize(firstItem.Options.MiscOptions.XResolution,
                                                                                    firstItem.Options.MiscOptions.YResolution);
                              break;
                           }
                     }

                     break;
                  }
            }

            int firstPage = 1;
            int lastPage = 1;

            if(ShowLoadPagesDialog)
            {
               firstPage = 1;
               lastPage = info.TotalPages;

               if(firstPage != lastPage)
               {
                  ImageFileLoaderPagesDialog dlg = new ImageFileLoaderPagesDialog(info.TotalPages, LoadOnlyOnePage);
                  if(dlg.ShowDialog(owner) == DialogResult.OK)
                  {
                     firstPage = dlg.FirstPage;
                     lastPage = dlg.LastPage;
                  }
                  else
                     ok = false;
               }
            }
            else
            {
               firstPage = firstItem.PageNumber;
               lastPage = firstItem.PageNumber;
            }

            _firstPage = firstPage;
            _lastPage = lastPage;

            if(autoLoad && ok)
               using(WaitCursor wait = new WaitCursor())
               {
                  _image = codecs.Load(FileName, 0, CodecsLoadByteOrder.BgrOrGray, firstPage, lastPage);
               }
         }

         return ok;
      }
   }
}
