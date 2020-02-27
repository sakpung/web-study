// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

using Leadtools.Demos;
using Leadtools;
using Leadtools.Codecs;
using Leadtools.Ocr;
using Leadtools.Document.Writer;
using Leadtools.Twain;

#if LEADTOOLS_V19_OR_LATER
using Leadtools.Demos.Dialogs;
#endif

namespace OcrTwainScanningDemo
{
   public partial class MainForm : Form
   {
      private OcrEngineType _ocrEngineType;
      private IOcrEngine _ocrEngine;
      private TwainSession _twainSession = null;

      public MainForm()
      {
         InitializeComponent();
      }

      protected override void OnLoad(EventArgs e)
      {
         // Setup the Messager
         Messager.Caption = "C# OCR Twain Scanning Demo";
         Text = Messager.Caption;

         if(!DesignMode)
         {
            BeginInvoke(new MethodInvoker(Startup));
         }

         base.OnLoad(e);
      }

      private void Startup()
      {
         try
         {
            // Initialize the TWAIN session
#if !LEADTOOLS_V19_OR_LATER
            if(TwainSession.IsAvailable(this))
#else
            if (TwainSession.IsAvailable(this.Handle))
#endif // #if !LEADTOOLS_V19_OR_LATER
            {
               _twainSession = new TwainSession();
#if !LEADTOOLS_V19_OR_LATER
               _twainSession.Startup(this, "LEAD Technologies, Inc.", "LEADTOOLS", "Version 1.0", "OCR Twain Scanning Demo", TwainStartupFlags.None);
#else
               _twainSession.Startup(this.Handle, "LEAD Technologies, Inc.", "LEADTOOLS", "Version 1.0", "OCR Twain Scanning Demo", TwainStartupFlags.None);
#endif // #if !LEADTOOLS_V19_OR_LATER
               try
                {
                    string temp = _twainSession.SelectedSourceName();
                }
                catch
                {
                    _twainSession.Shutdown();
                    _twainSession = null;
                    Messager.ShowInformation(this, "Could not find any TWAIN compatible scanners in the machine. This demo cannot function without TWAIN support and therefore will exit now");
                    Close();
                    return;
                }
            }
            else
            {
               Messager.ShowInformation(this, "Could not find any TWAIN compatible scanners in the machine. This demo cannot function without TWAIN support and therefore will exit now");
               Close();
               return;
            }
         }
         catch(TwainException ex)
         {
            if(ex.Code == TwainExceptionCode.InvalidDll)
            {
               _twainSession = null;
               Messager.ShowError(this, "You have an old version of TWAINDSM.DLL. Please download latest version of this DLL from www.twain.org");
               Close();
            }
            else
            {
               _twainSession = null;
               Messager.ShowError(this, ex);
            }
         }
         catch(Exception ex)
         {
            Messager.ShowError(this, ex);
            _twainSession = null;
         }

         // Load the settings from app.config
         if(!LoadSettings())
         {
            Close();
            return;
         }

         UpdateMyControls();
      }

      protected override void OnFormClosed(FormClosedEventArgs e)
      {
         // Save the settings
         SaveSettings();

         // Shutdown the OCR engine if started
         if(_ocrEngine != null)
         {
            _ocrEngine.Shutdown();
            _ocrEngine.Dispose();
         }

         if(_twainSession != null)
            _twainSession.Shutdown();

         base.OnFormClosed(e);
      }


      private void _miFileExit_Click(object sender, EventArgs e)
      {
         Close();
      }

      private void _miHelpAbout_Click(object sender, EventArgs e)
      {
#if LEADTOOLS_V19_OR_LATER
         using (AboutDialog aboutDialog = new AboutDialog("OCR Twain Scanning", ProgrammingInterface.CS))
            aboutDialog.ShowDialog(this);
#else
         using (AboutDialog aboutDialog = new AboutDialog("OCR Twain Scanning"))
            aboutDialog.ShowDialog(this);
#endif
      }

      private void _miOcrSettings_Click(object sender, EventArgs e)
      {
         OcrEngineSettingsDialog dlg = new OcrEngineSettingsDialog(_ocrEngine);
         dlg.ShowDialog(this);
      }

      private void _miOcrComponents_Click(object sender, EventArgs e)
      {
         OcrEngineComponentsDialog dlg = new OcrEngineComponentsDialog(_ocrEngine);
         dlg.ShowDialog(this);
      }

      private void _miTwainSelectSource_Click(object sender, EventArgs e)
      {
         try
         {
            _twainSession.SelectSource(null);
         }
         catch(Exception ex)
         {
            ShowError(ex, this, _ocrEngineType);
         }
         finally
         {
            UpdateMyControls();
         }
      }

      private void _tbFinalDocumentFileName_TextChanged(object sender, EventArgs e)
      {
         UpdateMyControls();
      }

      private bool LoadSettings()
      {
         Properties.Settings settings = new Properties.Settings();

         string engineType = settings.OcrEngineType;

         // Show the engine selection dialog
         using(OcrEngineSelectDialog dlg = new OcrEngineSelectDialog(Messager.Caption, engineType, true))
         {
            if(dlg.ShowDialog(this) == DialogResult.OK)
            {
               _ocrEngine = dlg.OcrEngine;
               _ocrEngineType = dlg.SelectedOcrEngineType;

               RasterCodecs codecs = _ocrEngine.RasterCodecsInstance;
#if !LEADTOOLS_V175_OR_LATER
               codecs.Options.Pdf.Load.XResolution = 300;
               codecs.Options.Pdf.Load.YResolution = 300;
               codecs.Options.RasterizeDocument.Load.Enabled = true;
               codecs.Options.Load.AutoFixImageResolution = true;
#endif

#if LEADTOOLS_V16_OR_LATER
               // Use the new RasterizeDocumentOptions to default loading document files at 300 DPI
               codecs.Options.RasterizeDocument.Load.XResolution = 300;
               codecs.Options.RasterizeDocument.Load.YResolution = 300;
               codecs.Options.Pdf.Load.EnableInterpolate = true;
               codecs.Options.Load.AutoFixImageResolution = true;
#endif // #if LEADTOOLS_V16_OR_LATER
            }
            else
               return false;
         }

         UpdateDocumentFormats();

         string twainSourceName = settings.TwainSourceName;
         if(!string.IsNullOrEmpty(twainSourceName))
         {
            try
            {
               _twainSession.SelectSource(twainSourceName);
            }
            catch
            {
            }
         }

         _tbFinalDocumentFileName.Text = settings.DocumentFileName.Trim();
         if(string.IsNullOrEmpty(_tbFinalDocumentFileName.Text))
            _tbFinalDocumentFileName.Text = Path.Combine(Path.GetFullPath(DemosGlobal.ImagesFolder), "OcrTwainScanningDemo");

         SelectFormatByName(settings.DocumentFormat);

         _documentFormatSelector_SelectedFormatChanged(null, EventArgs.Empty);

         return true;
      }

      private void UpdateDocumentFormats()
      {
         _documentFormatSelector.SetDocumentWriter(_ocrEngine.DocumentWriterInstance, false);
         _documentFormatSelector.SetOcrEngineType(_ocrEngineType);
         _documentFormatSelector.SelectedFormat = DocumentFormat.Pdf;
      }

      private void SelectFormatByName(string documentFormatName)
      {
         DocumentFormat format = DocumentFormat.Pdf;
         try
         {
            format = (DocumentFormat)Enum.Parse(typeof(DocumentFormat), documentFormatName);
         }
         catch
         {
         }

         _documentFormatSelector.SelectedFormat = format;
      }

      private void _documentFormatSelector_SelectedFormatChanged(object sender, EventArgs e)
      {
         // Update the file name of the document with the correct extension
         string documentFileName = _tbFinalDocumentFileName.Text.Trim();
         if(!string.IsNullOrEmpty(documentFileName))
         {
            DocumentFormat format = _documentFormatSelector.SelectedFormat;
            string extension = DocumentWriter.GetFormatFileExtension(format);
            documentFileName = Path.ChangeExtension(documentFileName, extension);
            _tbFinalDocumentFileName.Text = documentFileName;
         }

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

#if LEADTOOLS_V17_OR_LATER
            case DocumentFormat.Xls:
               _documentFormatSelector.FormatHasOptions = false;
               break;
#endif // #if LEADTOOLS_V17_OR_LATER

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

      private void _btnFinalDocumentFileName_Click(object sender, EventArgs e)
      {
         DocumentFormat format = _documentFormatSelector.SelectedFormat;
         string extension = DocumentWriter.GetFormatFileExtension(format);

         SaveFileDialog dlg = new SaveFileDialog();
         dlg.Filter = string.Format("{0} Files (*.{1})|*.{1}|All Files|*.*", DocumentWriter.GetFormatFriendlyName(format), extension);
         dlg.DefaultExt = extension;
         dlg.FileName = _tbFinalDocumentFileName.Text.Trim();
         if(dlg.ShowDialog(this) == DialogResult.OK)
            _tbFinalDocumentFileName.Text = dlg.FileName;
      }

      private void SaveSettings()
      {
          try
          {
              Properties.Settings settings = new Properties.Settings();
              settings.OcrEngineType = _ocrEngineType.ToString();
              settings.TwainSourceName = _twainSession != null ? _twainSession.SelectedSourceName() : string.Empty;
              settings.DocumentFileName = _tbFinalDocumentFileName.Text;
              settings.DocumentFormat = _documentFormatSelector.SelectedFormat.ToString();
              settings.Save();
          }
          catch { }
      }

      private void UpdateMyControls()
      {
         _lblTwainSourceName.Text = _twainSession != null ? _twainSession.SelectedSourceName() : string.Empty;
         _lblOcrEngineName.Text = string.Format("LEADTOOLS OCR {0} Engine", _ocrEngineType.ToString());
         _btnScan.Enabled = _twainSession != null && _tbFinalDocumentFileName.Text.Trim().Length > 0;
      }

      public static void ShowError(Exception ex, IWin32Window owner, OcrEngineType ocrEngineType)
      {
         if(ex is OcrException)
         {
            OcrException oe = ex as OcrException;
            Messager.ShowError(owner, string.Format("LEADTOOLS Error\nCode: {0}\nMessage:{1}", oe.Code, ex.Message));
         }
         else if(ex is RasterException)
         {
            RasterException re = ex as RasterException;
            Messager.ShowError(owner, string.Format("OCR Error\nCode: {0}\nMessage:{1}", re.Code, ex.Message));
         }
         else
         {
            Messager.ShowError(owner, ex);
         }
      }

      private void _btnScan_Click(object sender, EventArgs e)
      {
         string documentFileName = _tbFinalDocumentFileName.Text.Trim();
         DocumentFormat format = _documentFormatSelector.SelectedFormat;

         ProcessDialog dlg = new ProcessDialog(_twainSession, _ocrEngine, documentFileName, format);
         dlg.ShowDialog(this);
      }
   }
}
