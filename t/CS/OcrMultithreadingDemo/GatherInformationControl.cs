// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Security.AccessControl;
using System.Windows.Forms;
using System.IO;

using Leadtools.Demos;
using Leadtools;
using Leadtools.Ocr;
using Leadtools.Document.Writer;

namespace OcrMultiThreadingDemo
{
   public partial class GatherInformationControl : UserControl
   {
      private OcrEngineType _ocrEngineType;
      private int _totalPages;

      public GatherInformationControl()
      {
         InitializeComponent();
      }

      public void Init(OcrEngineType ocrEngineType, DocumentWriter docWriter, DemoOptions options, int totalPages)
      {
         _ocrEngineType = ocrEngineType;
         _totalPages = totalPages;

         SetDocumentWriterOptions(docWriter);
         _documentFormatSelector.SetDocumentWriter(docWriter, true);
         _documentFormatSelector.SetOcrEngineType(_ocrEngineType);

         InitFormats();

         LoadSettings(options);

         UpdateMyControls();
      }

      private void SetDocumentWriterOptions(DocumentWriter docWriter)
      {
         DocDocumentOptions docOptions = docWriter.GetOptions(DocumentFormat.Doc) as DocDocumentOptions;
         docOptions.TextMode = DocumentTextMode.Framed;

         DocxDocumentOptions docxOptions = docWriter.GetOptions(DocumentFormat.Docx) as DocxDocumentOptions;
         docxOptions.TextMode = DocumentTextMode.Framed;

         RtfDocumentOptions rtfOptions = docWriter.GetOptions(DocumentFormat.Rtf) as RtfDocumentOptions;
         rtfOptions.TextMode = DocumentTextMode.Framed;

         AltoXmlDocumentOptions altoXmlOptions = docWriter.GetOptions(DocumentFormat.AltoXml) as AltoXmlDocumentOptions;
         altoXmlOptions.Formatted = true;
      }

      private void InitFormats()
      {
         _documentFormatSelector.SelectedFormat = DocumentFormat.Pdf;
      }

      private void SelectFormatByName(string name)
      {
         DocumentFormat format = DocumentFormat.Pdf;
         try
         {
            format = (DocumentFormat)Enum.Parse(typeof(DocumentFormat), name);
         }
         catch
         {
         }

         _documentFormatSelector.SelectedFormat = format;
      }

      private void LoadSettings(DemoOptions options)
      {
         _tbSourceDirectory.Text = options.SourceDirectory != null ? options.SourceDirectory.Trim() : string.Empty;
         _tbFilter.Text = options.SourceFilter != null ? options.SourceFilter.Trim() : string.Empty;
         _tbDestinationDirectory.Text = options.DestinationDirectory != null ? options.DestinationDirectory.Trim() : string.Empty;
         
         string formatName = options.DestinationDocumentFormat.ToString();
         SelectFormatByName(formatName);

         if(string.IsNullOrEmpty(_tbSourceDirectory.Text))
            _tbSourceDirectory.Text = Path.GetFullPath(DemosGlobal.ImagesFolder);

         if(string.IsNullOrEmpty(_tbDestinationDirectory.Text))
            _tbDestinationDirectory.Text = Path.Combine(Path.GetFullPath(DemosGlobal.ImagesFolder), @"MultiThreadedDemoImages");

         if(string.IsNullOrEmpty(_tbFilter.Text))
            _tbFilter.Text = "*.tif";
      }

      public void SaveSettings()
      {
         // Save the last setting
         DemoOptions options = new DemoOptions();
         options.OcrEngineType = _ocrEngineType;
         options.SourceDirectory = _tbSourceDirectory.Text.Trim();
         options.SourceFilter = _tbFilter.Text.Trim();
         options.DestinationDirectory = _tbDestinationDirectory.Text.Trim();
         options.DestinationDocumentFormat = _documentFormatSelector.SelectedFormat;

         options.SaveDefault();
      }

      private void UpdateMyControls()
      {
         _btnGo.Enabled =
            _tbSourceDirectory.Text.Trim() != String.Empty &&
            _tbFilter.Text.Trim() != String.Empty &&
            _tbDestinationDirectory.Text.Trim() != String.Empty;
      }

      private void _tb_TextChanged(object sender, EventArgs e)
      {
         UpdateMyControls();
      }

      private void _btnSourceDirectoryBrowse_Click(object sender, EventArgs e)
      {
         _tbSourceDirectory.Text = BrowseToFolder(_tbSourceDirectory.Text.Trim(), "Select the source directory", false);
      }

      private void _btnDestinationDirectoryBrowse_Click(object sender, EventArgs e)
      {
         _tbDestinationDirectory.Text = BrowseToFolder(_tbDestinationDirectory.Text.Trim(), "Select the destination directory", true);
      }

      private string BrowseToFolder(string path, string description, bool allowCreateNew)
      {
         FolderBrowserDialog dlg = new FolderBrowserDialog();
         dlg.SelectedPath = path;
         dlg.Description = description;
         dlg.ShowNewFolderButton = allowCreateNew;

         if(dlg.ShowDialog(this) == DialogResult.OK)
            path = Path.GetFullPath(dlg.SelectedPath);

         return path;
      }

      private void _btnGo_Click(object sender, EventArgs e)
      {
         // Get the parameters we need

         string sourceDirectory = _tbSourceDirectory.Text.Trim();

         if(!Directory.Exists(sourceDirectory))
         {
            Messager.ShowInformation(this, string.Format("Directory '{0}' does not exist", sourceDirectory));
            _tbSourceDirectory.SelectAll();
            _tbSourceDirectory.Focus();
            return;
         }
         
         string filter = _tbFilter.Text.Trim();

         // Get the files in the source folder
         string[] sourceFiles;

         try
         {
            sourceFiles = Directory.GetFiles(sourceDirectory, filter);
            if(sourceFiles.Length == 0)
            {
               Messager.ShowInformation(this, string.Format("Directory '{0}' does not contain any files matching the filter '{1}'", sourceDirectory, filter));
               _tbFilter.SelectAll();
               _tbFilter.Focus();
               return;
            }
         }
         catch(Exception ex)
         {
            Messager.ShowError(this, ex);
            return;
         }

         string destinationDirectory = _tbDestinationDirectory.Text.Trim();

         if(!Directory.Exists(destinationDirectory))
         {
            // Try to create it
            try
            {
               Directory.CreateDirectory(destinationDirectory);
            }
            catch(Exception ex)
            {
               Messager.ShowError(this, ex);
               _tbDestinationDirectory.SelectAll();
               _tbDestinationDirectory.Focus();
               return;
            }
         }

         try
         {
            DirectorySecurity ds = Directory.GetAccessControl(destinationDirectory);
            if (ds.AreAccessRulesProtected)
            {
               Messager.ShowError(this, "Access to the path " + destinationDirectory + " is denied");
               return;
            }

            string logFileName = Path.Combine(destinationDirectory, "_Log.txt");
            if (File.Exists(logFileName))
               File.Delete(logFileName);
         }
         catch (Exception ex)
         {
            Messager.ShowError(this, ex);
            return;
         }
         
         bool loopContinuously = _cbLoopContinuously.Checked;

         DocumentFormat format = _documentFormatSelector.SelectedFormat;

         if(StartConversion != null)
            StartConversion(this, new StartConversionEventArgs(_ocrEngineType, sourceFiles, destinationDirectory, format, loopContinuously));
      }

      public event EventHandler<StartConversionEventArgs> StartConversion;

      private void _documentFormatSelector_SelectedFormatChanged(object sender, EventArgs e)
      {
         _documentFormatSelector.TotalPages = _totalPages;
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

            default:
               _documentFormatSelector.FormatHasOptions = true;
               break;
         }
      }
   }
}
