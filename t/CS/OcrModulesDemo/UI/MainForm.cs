// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Text;

using Leadtools.Demos;

using Leadtools;
using Leadtools.Codecs;
using Leadtools.Controls;
using Leadtools.Ocr;
using Leadtools.Document.Writer;
using Leadtools.Drawing;

using OcrModulesDemo.Properties;

namespace OcrModulesDemo
{
   public partial class MainForm : Form
   {
      private RasterCodecs _codecs;
      private ImageViewer _viewer;
      private IOcrEngine _ocrEngine = null;
      private OcrEngineType _ocrEngineType;
      private LeadRect _frameRect = LeadRect.Empty;
      private ImageViewerRubberBandInteractiveMode _rubberBandMode;
      private IOcrPage _ocrPage;
      private string _autoOcrImageName;
      private string _openInitialPath = string.Empty;

      public MainForm()
      {
         InitializeComponent();

         Messager.Caption = "C# OCR Modules Demo";
         Text = Messager.Caption;

         _codecs = new RasterCodecs();

         //  Use the new RasterizeDocumentOptions to default loading document files at 300 DPI
         _codecs.Options.RasterizeDocument.Load.XResolution = 300;
         _codecs.Options.RasterizeDocument.Load.YResolution = 300;
         _codecs.Options.Pdf.Load.EnableInterpolate = true;
         _codecs.Options.Load.AutoFixImageResolution = true;

         // Create and initialize the raster image viewer
         _viewer = new ImageViewer();
         _viewer.Dock = DockStyle.Fill;
         _viewer.BackColor = SystemColors.AppWorkspace;
         _viewer.Padding = new Padding(10);
         _viewer.ViewBorderThickness = 2;
         _viewer.ViewHorizontalAlignment = ControlAlignment.Center;
         _viewer.ViewVerticalAlignment = ControlAlignment.Center;
         _viewer.UseDpi = true;
         _viewer.Zoom(ControlSizeMode.Fit, (float)(200 / 100.0), _viewer.DefaultZoomOrigin);
         RasterPaintProperties props = RasterPaintProperties.Default;
         props.PaintDisplayMode = RasterPaintDisplayModeFlags.ScaleToGray;
         props.PaintEngine = RasterPaintEngine.Gdi;
         _viewer.PaintProperties = props;
         _splitContainer.Panel2.Controls.Add(_viewer);
         _viewer.BringToFront();
         _viewer.PostRender += new EventHandler<ImageViewerRenderEventArgs>(_viewer_PostRender);

         InitInteractiveModes();
      }

      private void InitInteractiveModes()
      {
         _viewer.InteractiveModes.BeginUpdate();
         _rubberBandMode = new ImageViewerRubberBandInteractiveMode();
         _rubberBandMode.IdleCursor = Cursors.Cross;
         _rubberBandMode.WorkingCursor = Cursors.Cross;
         _rubberBandMode.RubberBandCompleted += new EventHandler<ImageViewerRubberBandEventArgs>(_rubberBandMode_RubberBandCompleted);
         _viewer.InteractiveModes.Add(_rubberBandMode);
         _viewer.InteractiveModes.EndUpdate();
      }

      protected override void OnLoad(EventArgs e)
      {
         if (!DesignMode)
         {
            BeginInvoke(new MethodInvoker(Startup));
         }

         base.OnLoad(e);
      }

      private void Startup()
      {
         Properties.Settings settings = new Properties.Settings();

         string engineType = settings.OcrEngineType;

         // Show the engine selection dialog
         using (OcrEngineSelectDialog dlg = new OcrEngineSelectDialog(Messager.Caption, engineType, true))
         {
            dlg.RasterCodecsInstance = _codecs;
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
               _ocrEngine = dlg.OcrEngine;
               _ocrEngineType = dlg.SelectedOcrEngineType;

               InitEngines();
            }
            else
            {
               // Close the demo
               Close();
            }
         }
      }

      /// <summary>
      /// The main entry point for the application.
      /// </summary>
      [STAThread]
      static void Main()
      {
         if (!Support.SetLicense())
            return;

         Application.EnableVisualStyles();
         Application.SetCompatibleTextRenderingDefault(false);
         Application.Run(new MainForm());
      }

      void CleanUp()
      {
         if (_ocrPage != null)
         {
            _ocrPage.Dispose();
            _ocrPage = null;
         }

         if (_ocrEngine != null && _ocrEngine.IsStarted)
         {
            _ocrEngine.Shutdown();
            _ocrEngine.Dispose();
         }

         if (_codecs != null)
            _codecs.Dispose();
      }

      static string ImagesFolder
      {
         get
         {
            string strLEADTOOLSFolder =
#if LT_CLICKONCE
               Application.StartupPath;
#else
               DemosGlobal.ImagesFolder + "\\";
#endif
            return strLEADTOOLSFolder;
         }
      }

      protected override void OnFormClosed(FormClosedEventArgs e)
      {
         SaveSettings();
         base.OnFormClosed(e);
      }

      bool LoadImage(string fileName)
      {
         try
         {
            RasterImage image = _codecs.Load(fileName);

            // Add the page first.
            _ocrPage = _ocrEngine.CreatePage(image, OcrImageSharingMode.None);

            // Add zones by default.
            AddZones(false);

            // Engine will correct the page deskew before AutoZone or Recognize, so we need to load the page again form the engine.
            _viewer.Image = _ocrPage.GetRasterImage();

            _viewer.Refresh();
            return true;
         }
         catch (Exception ex)
         {
            Messager.ShowError(this, ex);
            return false;
         }
      }

      void InitEngines()
      {
         _documentFormatSelector.SetDocumentWriter(_ocrEngine.DocumentWriterInstance, false);

         StartupEngine();

         _documentFormatSelector.SetOcrEngineType(_ocrEngineType);

         if (_ocrEngineType == OcrEngineType.OmniPageArabic)
            _autoOcrImageName = "ArabicSample.Tif";
         else
            _autoOcrImageName = "OCR1.Tif";

         // Add the selected engine name to the demo caption
         Text = Text + " [" + _ocrEngineType.ToString() + " Engine]";

         UpdateSupportedOcrModulesList();
         UpdateMyControls();
         Properties.Settings settings = new Properties.Settings();

         // If user provided a command line argument then forget about the saved OCR Module
         // otherwise use the saved OCR module (if there is any).
         if (Environment.GetCommandLineArgs().Length > 1)
         {
            String[] arguments = Environment.GetCommandLineArgs();
            if (arguments[1].Equals("Auto"))
            {
               _cmbOcrModules.SelectedIndex = 1;
            }
            else if (arguments[1].Equals("Omr"))
            {
               _cmbOcrModules.SelectedIndex = 2;
            }
            else if (arguments[1].Equals("HnrText"))
            {
               _cmbOcrModules.SelectedIndex = 3;
            }
            else if (arguments[1].Equals("HnrNum"))
            {
               _cmbOcrModules.SelectedIndex = 4;
            }
            else
            {
               _cmbOcrModules.SelectedIndex = 0;
            }
         }
         else
         {
            if (!String.IsNullOrEmpty(settings.OCRModule))
            {
               for (int i = 0; i < _cmbOcrModules.Items.Count; i++)
               {
                  MyItemData itemData = (MyItemData)_cmbOcrModules.Items[i];
                  if (itemData.ZoneType == (int)Enum.Parse(typeof(OcrZoneType), settings.OCRModule))
                  {
                     _cmbOcrModules.SelectedIndex = i;
                     break;
                  }
               }
               if (_cmbOcrModules.SelectedIndex < 0) // No match found
               {
                  _cmbOcrModules.SelectedIndex = 0;
               }
            }
            else
            {
               _cmbOcrModules.SelectedIndex = 0;
            }
         }

         if (_ocrEngine != null && _ocrEngine.IsStarted)
         {
            DocumentFormat format = DocumentFormat.Pdf;

            /* Load settings for the selected Document Format */
            if (!String.IsNullOrEmpty(settings.DocumentFormat))
            {
               try
               {
                  format = (DocumentFormat)Enum.Parse(typeof(DocumentFormat), settings.DocumentFormat);
               }
               catch
               {
               }
            }

            _documentFormatSelector.SelectedFormat = format;
         }

         /* Load settings for user selected View Final Document check box status */
         _cbViewFinalDocument.Checked = settings.ViewFinalDocument;
      }

      void SaveSettings()
      {
         try
         {
            Properties.Settings settings = new Properties.Settings();

            settings.OcrEngineType = _ocrEngineType.ToString();
            settings.OCRModule = ((MyItemData)_cmbOcrModules.SelectedItem).OriginalName;
            settings.DocumentFormat = _documentFormatSelector.SelectedFormat.ToString();
            settings.ViewFinalDocument = _cbViewFinalDocument.Checked;
            settings.Save();
            settings.Upgrade();
            settings.Save();
         }
         catch (Exception)
         {
         }
      }

      void AddZones(bool bUserDrawnZone)
      {
         try
         {
            if (bUserDrawnZone && (_frameRect.Width < 2 || _frameRect.Height < 2))
               return;

            // Initialize the OcrZone and add it to the image.
            OcrZone zoneData = new OcrZone();
            MyItemData itemData = (MyItemData)_cmbOcrModules.SelectedItem;
            OcrZoneType selectedModule = (OcrZoneType)itemData.ZoneType;

            switch (selectedModule)
            {
               case OcrZoneType.Text:  // AUTO
                  if (bUserDrawnZone)
                  {
                     zoneData.Bounds = _frameRect;
                     zoneData.ZoneType = OcrZoneType.Text;
                     _ocrPage.Zones.Add(zoneData);
                  }
                  else
                     _ocrPage.AutoZone(null);
                  break;

               case OcrZoneType.Micr:  // MICR
                  if (bUserDrawnZone)
                     zoneData.Bounds = _frameRect;
                  else
                     zoneData.Bounds = new LeadRect(38, 678, 1655, 87);

                  zoneData.ZoneType = OcrZoneType.Micr;
                  _ocrPage.Zones.Add(zoneData);
                  break;

               case OcrZoneType.Omr:  // OMR
                  if (bUserDrawnZone)
                  {
                     zoneData.Bounds = _frameRect;
                     zoneData.ZoneType = OcrZoneType.Omr;
                     _ocrPage.Zones.Add(zoneData);
                  }
                  else
                  {
                     _ocrPage.LoadZones( Path.Combine( ImagesFolder, "Mix_omr.ozf" ) );
                  }
                  break;

               case OcrZoneType.Icr:  // HandPrintedCharacter
                  if (bUserDrawnZone)
                     zoneData.Bounds = _frameRect;
                  else
                     zoneData.Bounds = new LeadRect(0, 0, _ocrPage.Width, _ocrPage.Height);

                  zoneData.ZoneType = OcrZoneType.Icr;
                  zoneData.CharacterFilters = (OcrZoneCharacterFilters)itemData.CharacterFilters;
                  _ocrPage.Zones.Add(zoneData);
                  break;
            }
         }
         catch (Exception ex)
         {
            Messager.ShowError(this, ex);
         }
      }

      void UpdateSupportedOcrModulesList()
      {
         MyItemData[] ocrModules = 
      {
         new MyItemData("Auto - OCR", "", (int)OcrZoneType.Text, (int)OcrZoneCharacterFilters.None, Path.Combine(ImagesFolder, _autoOcrImageName), 0, 0),
         new MyItemData("Auto - MICR", OcrZoneType.Micr.ToString(), (int)OcrZoneType.Micr, (int)OcrZoneCharacterFilters.None, Path.Combine(ImagesFolder, "MICR_SAMPLE.Tif"), 0, 0),
         new MyItemData("OMR", OcrZoneType.Omr.ToString(), (int)OcrZoneType.Omr, (int)OcrZoneCharacterFilters.None, Path.Combine(ImagesFolder, "MIXED.Tif"), 0, 0),
         new MyItemData("Hand Printed Characters", OcrZoneType.Icr.ToString(), (int)OcrZoneType.Icr, (int)OcrZoneCharacterFilters.None, Path.Combine(ImagesFolder, "DEMOICR2.Tif"), 0, 0),
         new MyItemData("Hand Printed Numerals", OcrZoneType.Icr.ToString(), (int)OcrZoneType.Icr, (int)OcrZoneCharacterFilters.Digit, Path.Combine(ImagesFolder, "DEMOICR.Tif"), 0, 0)
      };

         // Clear the previous items
         _cmbOcrModules.Items.Clear();

         if (_ocrEngine != null && _ocrEngine.IsStarted)
         {
            foreach (MyItemData item in ocrModules)
            {
               if (_ocrEngine.ZoneManager.IsZoneTypeSupported((OcrZoneType)item.ZoneType))
                  _cmbOcrModules.Items.Add(item);
            }
         }
      }

      void UpdateMyControls()
      {
         bool bEnable = false;

         if (_ocrEngine != null && _ocrEngine.IsStarted)
         {
            bEnable = true;
            _documentFormatSelector.Enabled = bEnable;

            if (_ocrPage != null && _ocrPage.Zones.Count > 0)
               _btnClearZones.Enabled = bEnable && _ocrPage.Zones.Count > 0;
            else
               _btnClearZones.Enabled = false;
         }
         else
         {
            _documentFormatSelector.Enabled = false;
            _btnClearZones.Enabled = false;
         }

         _cmbOcrModules.Enabled = bEnable;
         _cbViewFinalDocument.Enabled = true;
         _btnBrowseImageFile.Enabled = bEnable;
         _btnRecognize.Enabled = bEnable;

         if (!bEnable)
         {
            _cmbOcrModules.SelectedIndex = -1;
         }
      }

      private void MainForm_Resize(object sender, EventArgs e)
      {
         _lblImageFileName.Width = _statusBar.ClientSize.Width - 25;
      }

      private void _btnBrowseImageFile_Click(object sender, EventArgs e)
      {
         ImageFileLoader loader = new ImageFileLoader();
         loader.OpenDialogInitialPath = _openInitialPath;
         try
         {
            if (loader.Load(this, _codecs, false) > 0)
            {
               if (LoadImage(loader.FileName))
               {
                  _openInitialPath = Path.GetDirectoryName(loader.FileName);
                  _lblImageFileName.Text = loader.FileName;
                  MyItemData itemData = (MyItemData)_cmbOcrModules.Items[_cmbOcrModules.SelectedIndex];
                  itemData.ImageFileName = loader.FileName;
                  this._cmbOcrModules.SelectedIndexChanged -= new System.EventHandler(this._cmbOcrModules_SelectedIndexChanged);
                  _cmbOcrModules.Items[_cmbOcrModules.SelectedIndex] = itemData;
                  this._cmbOcrModules.SelectedIndexChanged += new System.EventHandler(this._cmbOcrModules_SelectedIndexChanged);
               }
            }
         }
         catch (Exception ex)
         {
            Messager.ShowFileOpenError(this, loader.FileName, ex);
         }
      }

      void LoadOcrModuleAssociatedImage()
      {
         MyItemData itemData = (MyItemData)_cmbOcrModules.Items[_cmbOcrModules.SelectedIndex];

         LoadImage(itemData.ImageFileName);
         _lblImageFileName.Text = itemData.ImageFileName;
      }

      private void StartupEngine()
      {
         UpdateMyControls();
      }

      public void ShowError(Exception ex, IWin32Window owner, OcrEngineType engineType)
      {
         if (ex is OcrException)
         {
            OcrException oe = ex as OcrException;
            Messager.ShowError(owner, string.Format("LEADTOOLS Error\nCode: {0}\nMessage:{1}", oe.Code, ex.Message));
         }
         else if (ex is RasterException)
         {
            RasterException re = ex as RasterException;
            Messager.ShowError(owner, string.Format("OCR Error\nCode: {0}\nMessage:{1}", re.Code, ex.Message));
         }
         else
         {
            Messager.ShowError(owner, ex);
         }
      }

      private void _cmbOcrModules_SelectedIndexChanged(object sender, EventArgs e)
      {
         using (WaitCursor wait = new WaitCursor())
         {
            if (_cmbOcrModules.SelectedIndex < 0)
               return;

            if (_ocrPage != null)
            {
               _ocrPage.Dispose();
               _ocrPage = null;
            }

            // Load the default image associated with each ocr module.
            LoadOcrModuleAssociatedImage();

            // Save the image file name the user associate with the selected OCR module.
            MyItemData itemData = (MyItemData)_cmbOcrModules.Items[_cmbOcrModules.SelectedIndex];
            itemData.ImageFileName = _lblImageFileName.Text;
            this._cmbOcrModules.SelectedIndexChanged -= new System.EventHandler(this._cmbOcrModules_SelectedIndexChanged);
            _cmbOcrModules.Items[_cmbOcrModules.SelectedIndex] = itemData;
            this._cmbOcrModules.SelectedIndexChanged += new System.EventHandler(this._cmbOcrModules_SelectedIndexChanged);
            _omrOptionsButton.Enabled = ((OcrZoneType)itemData.ZoneType == OcrZoneType.Omr);

            UpdateMyControls();
         }
      }

      private void _btnRecognize_Click(object sender, EventArgs e)
      {
         try
         {
            using (WaitCursor wait = new WaitCursor())
            {
               DocumentFormat format = _documentFormatSelector.SelectedFormat;
               String documentFileName = _lblImageFileName.Text;

               documentFileName = string.Concat(documentFileName, ".", DocumentWriter.GetFormatFileExtension(format));

               _ocrPage.Recognize(null);
               using (IOcrDocument _document = _ocrEngine.DocumentManager.CreateDocument(null, OcrCreateDocumentOptions.AutoDeleteFile))
               {
                  _document.Pages.Add(_ocrPage);
                  _document.Save(documentFileName, format, null);
               }

               // Engine will correct the page deskew before AutoZone or Recognize, so we need to load the page again form the engine.
               _viewer.Image = _ocrPage.GetRasterImage();
               _viewer.Refresh();
               UpdateMyControls();

               // if the "View Final Document" option is checked then no need to show this message since
               // it will load the saved document file.
               if (!_cbViewFinalDocument.Checked)
               {
                  Messager.ShowInformation(this, String.Format("The output document file was saved at ({0})", documentFileName));
               }
               else
               {
                  if (File.Exists(documentFileName))
                  {
                     try
                     {
                        Process.Start(documentFileName);
                     }
                     catch
                     {
                        Messager.ShowError(this, "Unable to open generated results file with external viewing application");
                     }
                  }
                  else
                  {
                     Messager.ShowError(this, "Unable to open generated results file with external viewing application.\nThe system cannot find the file specified");
                  }
               }
            }
         }
         catch (Exception ex)
         {
            Messager.ShowError(this, ex.Message);
         }
      }

      private void _btnClearZones_Click(object sender, EventArgs e)
      {
         if (_ocrEngine != null)
         {
            if (_ocrEngine.IsStarted)
            {
               _ocrPage.Zones.Clear();
               _viewer.Refresh();
               UpdateMyControls();
            }
         }
      }

      void _viewer_PostRender(object sender, ImageViewerRenderEventArgs e)
      {
         Graphics g = e.PaintEventArgs.Graphics;
         try
         {
            if (_viewer.Image != null && _ocrPage.Zones.Count > 0)
            {
               for (int i = 0; i < _ocrPage.Zones.Count; i++)
               {
                  LeadRect bounds = _ocrPage.Zones[i].Bounds;
                  LeadRect rect = LeadRect.FromLTRB(bounds.Left, bounds.Top, bounds.Right, bounds.Bottom);
                  rect = _viewer.ConvertRect(null, ImageViewerCoordinateType.Image, ImageViewerCoordinateType.Control, rect);
                  using (Pen pen = new Pen(Color.Red, 2))
                  {
                     g.DrawRectangle(pen, Leadtools.Demos.Converters.ConvertRect(rect));
                  }
               }
            }
         }
         catch (Exception)
         {
         }
      }

      private void _rubberBandMode_RubberBandCompleted(object sender, ImageViewerRubberBandEventArgs e)
      {
         _frameRect = _viewer.ConvertRect(null,
            ImageViewerCoordinateType.Control,
            ImageViewerCoordinateType.Image,
            LeadRect.FromLTRB(e.Points[0].X, e.Points[0].Y, e.Points[1].X, e.Points[1].Y));
         try
         {
            if (_viewer.Image != null)
            {
               AddZones(true);
               _viewer.Invalidate();
               UpdateMyControls();
            }
         }
         catch (Exception ex)
         {
            Messager.ShowError(this, ex);
         }
      }

      private void _omrOptionsButton_Click(object sender, EventArgs e)
      {
         using (OcrOmrOptionsDialog dlg = new OcrOmrOptionsDialog(_ocrEngine))
            dlg.ShowDialog(this);
      }

      private void _documentFormatSelector_SelectedFormatChanged(object sender, EventArgs e)
      {
         DocumentOptions options = _ocrEngine.DocumentWriterInstance.GetOptions(_documentFormatSelector.SelectedFormat);
         _documentFormatSelector.TotalPages = 1;
         switch (_documentFormatSelector.SelectedFormat)
         {
            case DocumentFormat.Xps:
               _documentFormatSelector.FormatHasOptions = false;
               break;

            case DocumentFormat.Doc:
               _documentFormatSelector.FormatHasOptions = true;
               break;

            case DocumentFormat.Docx:
               _documentFormatSelector.FormatHasOptions = true;
               break;

            case DocumentFormat.Rtf:
               _documentFormatSelector.FormatHasOptions = true;
               break;

            case DocumentFormat.Xls:
               _documentFormatSelector.FormatHasOptions = false;
               break;

#if LEADTOOLS_V19_OR_LATER
            case DocumentFormat.AltoXml:
               _documentFormatSelector.FormatHasOptions = true;
               break;

            case DocumentFormat.Pub:
               _documentFormatSelector.FormatHasOptions = false;
               break;

            case DocumentFormat.Mob:
               _documentFormatSelector.FormatHasOptions = false;
               break;

            case DocumentFormat.Svg:
               _documentFormatSelector.FormatHasOptions = false;
               break;
#endif // #if LEADTOOLS_V19_OR_LATER

            default:
               _documentFormatSelector.FormatHasOptions = true;
               break;
         }

         if (options != null)
            _ocrEngine.DocumentWriterInstance.SetOptions(_documentFormatSelector.SelectedFormat, options);
      }
   }
}
