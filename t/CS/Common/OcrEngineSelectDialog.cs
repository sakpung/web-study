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
using System.Reflection;
using Microsoft.Win32;

using Leadtools;
using Leadtools.Ocr;
using Leadtools.Codecs;
using Leadtools.Document.Writer;

namespace Leadtools.Demos
{
   public partial class OcrEngineSelectDialog : Form
   {
      private IOcrEngine _ocrEngine;
      private OcrEngineType _selectedOcrEngineType;
      private string _selectEngineType;
      private bool _autoStart;
      private RasterCodecs _rasterCodecsInstance;
      private bool _allowNoOcr = false;

      private struct EngineProperty
      {
         public string Name;
         public OcrEngineType EngineType;
         public string RuntimePath;
         public string RegistryKeyName;
         public bool Installed;

         public override string ToString()
         {
            return Name;
         }
      }

      private EngineProperty _engineProperty;
      private int _engineFoundCount;

      public OcrEngineSelectDialog(string demoName, string selectEngineType, bool autoStart)
      {
         InitializeComponent();

         Text = demoName;

         _selectEngineType = selectEngineType;
         _autoStart = autoStart;
      }

      public IOcrEngine OcrEngine
      {
         get { return _ocrEngine; }
      }

      public OcrEngineType SelectedOcrEngineType
      {
         get { return _selectedOcrEngineType; }
      }

      public RasterCodecs RasterCodecsInstance
      {
         get { return _rasterCodecsInstance; }
         set { _rasterCodecsInstance = value; }
      }

      public bool AllowNoOcr
      {
         get { return _allowNoOcr; }
         set { _allowNoOcr = value; }
      }

      private string _allowNoOcrMessage;
      public string AllowNoOcrMessage
      {
         get { return _allowNoOcrMessage; }
         set { _allowNoOcrMessage = value; }
      }

      protected override void OnLoad(EventArgs e)
      {
         if(!DesignMode)
         {
            // Check what OCR engines are installed using the registry
            var engineProperties = new List<EngineProperty>();
            engineProperties.Add(new EngineProperty
            {
               Name = "LEADTOOLS - LEAD OCR Engine",
               EngineType = OcrEngineType.LEAD,
               RuntimePath = @"LEADTOOLS\OcrLEADRuntime",
               RegistryKeyName = "OCRPathLEAD20"
            });
#if !LT_CLICKONCE && !FOR_NUGET
            if (IntPtr.Size == 8)
            {
               engineProperties.Add(new EngineProperty
               {
                  Name = "LEADTOOLS - OmniPage OCR Engine",
                  EngineType = OcrEngineType.OmniPage,
                  RuntimePath = @"LEADTOOLS\OCROmniPageRuntime64",
                  RegistryKeyName = "OCRPathOmniPage20_64"
               });
               engineProperties.Add(new EngineProperty
               {
                  Name = "LEADTOOLS - OmniPage Arabic OCR Engine",
                  EngineType = OcrEngineType.OmniPageArabic,
                  RuntimePath = @"LEADTOOLS\OCROmniPageArabicRuntime64",
                  RegistryKeyName = "OCRPathOmniPageArabic20_64"
               });
            }
            else
            {
               engineProperties.Add(new EngineProperty
               {
                  Name = "LEADTOOLS - OmniPage OCR Engine",
                  EngineType = OcrEngineType.OmniPage,
                  RuntimePath = @"LEADTOOLS\OCROmniPageRuntime",
                  RegistryKeyName = "OCRPathOmniPage20"
               });
               engineProperties.Add(new EngineProperty
               {
                  Name = "LEADTOOLS - OmniPage Arabic OCR Engine",
                  EngineType = OcrEngineType.OmniPageArabic,
                  RuntimePath = @"LEADTOOLS\OCROmniPageArabicRuntime",
                  RegistryKeyName = "OCRPathOmniPageArabic20"
               });
            }
#endif // #if !LT_CLICKONCE && !FOR_NUGET

            if (_allowNoOcr && !string.IsNullOrEmpty(_allowNoOcrMessage))
               _lblAllowNoOcr.Text = _allowNoOcrMessage;

            _engineFoundCount = 0;

            for(int i = 0; i < engineProperties.Count; i++)
            {
               EngineProperty engineProperty = engineProperties[i];

               engineProperty.Installed = IsOcrEngineInstalled(engineProperty.RuntimePath, engineProperty.RegistryKeyName);

               engineProperties[i] = engineProperty;

               if(engineProperty.Installed)
                  _engineFoundCount++;
            }

            if(_allowNoOcr)
            {
                _btnCancel.Text = DemosGlobalization.GetResxString(GetType(), "Resx_Cancel");
            }

            // 1. If we do not have any OCR engines installed, the demo will not start (if AllowNoOcr is false), so show the messages
            // where the user can download the OCR engines and hide the OK button

            // 2. If we have one engine, start it up

            // 3. If we have more than one engine, show the selection combo box

            if(_engineFoundCount == 0)
            {
               StringBuilder sb = new StringBuilder();
               sb.AppendLine(DemosGlobalization.GetResxString(GetType(), "Resx_OCREngineNotFound"));
               sb.AppendLine();

               if(!_allowNoOcr)
               {
                   sb.AppendLine(DemosGlobalization.GetResxString(GetType(), "Resx_OCRCapabilities"));
               }

               sb.AppendLine();
               sb.AppendLine(DemosGlobalization.GetResxString(GetType(), "Resx_OCREngineVersion"));

               _lblNoEnginesFound.Text = sb.ToString();

               _tcMain.TabPages.Remove(_tpSelectEngine);
               _tcMain.TabPages.Remove(_tpStartEngine);

               _btnOk.Enabled = false;
               _btnOk.Visible = false;
            }
            else if(_engineFoundCount == 1 && !_allowNoOcr)
            {
               _tcMain.TabPages.Remove(_tpNoEnginesFound);
               _tcMain.TabPages.Remove(_tpSelectEngine);

               foreach(EngineProperty engineProperty in engineProperties)
               {
                  if(engineProperty.Installed)
                     _engineProperty = engineProperty;
               }

               _btnOk.Enabled = false;
               _btnOk.Visible = false;

               BeginInvoke(new StartEngineDelegate(StartEngine));
            }
            else
            {
               _tcMain.TabPages.Remove(_tpNoEnginesFound);
               _tcMain.TabPages.Remove(_tpStartEngine);

               foreach(EngineProperty engineProperty in engineProperties)
               {
                  if(engineProperty.Installed)
                  {
                     _cbEngineSelection.Items.Add(engineProperty);

                     if(string.Compare(_selectEngineType, engineProperty.EngineType.ToString(), StringComparison.InvariantCultureIgnoreCase) == 0)
                     {
                        _cbEngineSelection.SelectedItem = engineProperty;
                     }
                  }
               }

               if(_cbEngineSelection.SelectedIndex == -1)
                  _cbEngineSelection.SelectedIndex = 0;
            }
         }

         base.OnLoad(e);
      }

      private static bool IsOcrEngineInstalled(string runtimePath, string registryKeyName)
      {
#if LT_CLICKONCE
         return true;
#else
         // First check a path under the current EXE. The LEADTOOLS OCR nugets adds this
         string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), runtimePath);
         if (Directory.Exists(path))
            return true;

         // Check the registry. The LEADTOOLS setup adds this
         RegistryKey rk = OpenSoftwareKey(@"LEAD Technologies, Inc.\" + registryKeyName);
         if (rk != null)
         {
            rk.Close();
            return true;
         }
         else
            return false;
#endif // #if LT_CLICKONCE
      }

      private static RegistryKey OpenSoftwareKey(string keyName)
      {
         RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Wow6432Node\" + keyName);
         if (key == null)
         {
            key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\" + keyName);
            if (key == null)
               key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\" + keyName);
         }

         return key;
      }

      private void _lbDownload_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
      {
         System.Diagnostics.Process.Start(_lbDownload.Text);
      }

      private void _btnOk_Click(object sender, EventArgs e)
      {
         _engineProperty = (EngineProperty)_cbEngineSelection.SelectedItem;
         _tcMain.TabPages.Remove(_tpSelectEngine);
         _tcMain.TabPages.Add(_tpStartEngine);

         DialogResult = DialogResult.None;

         _btnOk.Enabled = false;
         _btnOk.Visible = false;

         BeginInvoke(new StartEngineDelegate(StartEngine));
      }

      private delegate void StartEngineDelegate();

      private void StartEngine()
      {
         if (_autoStart)
         {
            _btnCancel.Enabled = false;
            _lblDownload.Visible = false;
            _lbDownload.Visible = false;

            _lblStartEngine.Text = string.Format(DemosGlobalization.GetResxString(GetType(), "Resx_StartUp"), _engineProperty.Name);
            Application.DoEvents();

            IOcrEngine ocrEngine = null;

            try
            {
               ocrEngine = OcrEngineManager.CreateEngine(_engineProperty.EngineType, false);

#if LT_CLICKONCE
               ocrEngine.Startup( _rasterCodecsInstance, null, null, Application.StartupPath + @"\OCR Engine" );
#else
               ocrEngine.Startup(_rasterCodecsInstance, null, null, null);
#endif // #if LT_CLICKONCE



               _lblStatus.ForeColor = SystemColors.ControlText;

               if(_allowNoOcr)
               {
                   _lblStatus.Text = DemosGlobalization.GetResxString(GetType(), "Resx_SuccessContinuing");
               }
               else
               {
                   _lblStatus.Text = DemosGlobalization.GetResxString(GetType(), "Resx_SuccessStarting");
               }

               _ocrEngine = ocrEngine;
               _selectedOcrEngineType = _engineProperty.EngineType;

               // Set document writer options
               SetDocumentWriterOptions();

               Application.DoEvents();
               System.Threading.Thread.Sleep(1000);
               DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
               _lblStatus.ForeColor = Color.Red;

               if(_allowNoOcr)
               {
                   _lblStatus.Text = string.Format(DemosGlobalization.GetResxString(GetType(), "Resx_ErrorOCRCapabilities"), ex.Message, Environment.NewLine);
               }
               else
               {
                   _lblStatus.Text = string.Format(DemosGlobalization.GetResxString(GetType(), "Resx_ErrorOCRWithoutCapabilities"), ex.Message, Environment.NewLine);
               }

               _lblDownload.Visible = false;
               _lbDownload.Visible = false;

               if (_ocrEngine != null)
                  _ocrEngine.Dispose();
            }
            finally
            {
               _btnCancel.Enabled = true;
            }
         }
         else
         {
            _ocrEngine = null;
            _selectedOcrEngineType = _engineProperty.EngineType;
            DialogResult = DialogResult.OK;
         }
      }

      private void SetDocumentWriterOptions()
      {
         DocDocumentOptions docOptions = _ocrEngine.DocumentWriterInstance.GetOptions(DocumentFormat.Doc) as DocDocumentOptions;
         docOptions.TextMode = DocumentTextMode.Framed;

         DocxDocumentOptions docxOptions = _ocrEngine.DocumentWriterInstance.GetOptions(DocumentFormat.Docx) as DocxDocumentOptions;
         docxOptions.TextMode = DocumentTextMode.Framed;

         RtfDocumentOptions rtfOptions = _ocrEngine.DocumentWriterInstance.GetOptions(DocumentFormat.Rtf) as RtfDocumentOptions;
         rtfOptions.TextMode = DocumentTextMode.Framed;

         AltoXmlDocumentOptions altoXmlOptions = _ocrEngine.DocumentWriterInstance.GetOptions(DocumentFormat.AltoXml) as AltoXmlDocumentOptions;
         altoXmlOptions.Formatted = true;
      }
   }
}
