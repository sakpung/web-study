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
using Leadtools.Ocr;
using Leadtools.Document.Writer;
using Leadtools.Codecs;

namespace OcrAutoRecognizeDemo
{
   public partial class JobForm : Form
   {
      private bool _loadedOk = false;
      private DocumentFormatSelector _documentFormatSelector;
      private int _imageFirstPageNumber;
      private int _imageLastPageNumber;
      private bool _coresWarningMessageDisplayed = false;
      private RasterCodecs _rasterCodecs;

      public JobForm(RasterCodecs rasterCodecs)
      {
         InitializeComponent();
         // Initialize the RasterCodecs object
         _rasterCodecs = rasterCodecs;
      }

      private JobData _jobData;
      public JobData JobData
      {
         get { return _jobData; }
         set { _jobData = value; }
      }

      protected override void OnLoad(EventArgs e)
      {
         if(!DesignMode)
         {
            _documentFormatSelector = new DocumentFormatSelector();
            _documentFormatSelector.Dock = DockStyle.Fill;
            _documentFormatsSelectorPanel.Controls.Add(_documentFormatSelector);
            _documentFormatSelector.BringToFront();

            _documentFormatSelector.SelectedFormatChanged += new EventHandler<EventArgs>(_documentFormatSelector_SelectedFormatChanged);

            Text = Messager.Caption;

            Properties.Settings settings = new Properties.Settings();

            // Show the OCR engine selection dialog to startup the OCR engine
            string engineType = settings.OcrEngineType;

            if(JobData.OcrEngine == null)
            {
               using(OcrEngineSelectDialog dlg = new OcrEngineSelectDialog(Messager.Caption, engineType, true))
               {
                   // Use the same RasterCodecs instance in the OCR engine
                   dlg.RasterCodecsInstance = _rasterCodecs;

                  if(dlg.ShowDialog(this) != DialogResult.OK)
                  {
                     // Close the demo
                     DialogResult = DialogResult.Cancel;
                     Close();
                     return;
                  }
                  else
                  {
                     JobData.OcrEngine = dlg.OcrEngine;
                  }
               }
            }

            Text = string.Format("{0} [{1} Engine]", Messager.Caption, JobData.OcrEngine.EngineType.ToString());

            _imageFileNameTextBox.Text = settings.ImageFileName;
            _imageFirstPageNumber = settings.FirstPageNumber;
            if(_imageFirstPageNumber < 1) _imageFirstPageNumber = 1;
            _imageLastPageNumber = settings.LastPageNumber;
            if(_imageLastPageNumber < _imageFirstPageNumber) _imageLastPageNumber = -1;

            InitFormats(settings);

            _zonesFileNameTextBox.Text = settings.ZonesFileName;

            try
            {
               _maximumThreadsPerJobTextBox.Text = settings.MaximumThreadsPerJob.ToString();
            }
            catch
            {
               _maximumThreadsPerJobTextBox.Text = "0";
            }

            try
            {
               _maximumPagesBeforeLtdTextBox.Text = settings.MaximumPagesBeforeLtd.ToString();
            }
            catch
            {
               _maximumPagesBeforeLtdTextBox.Text = "4";
            }

            if(!JobData.OcrEngine.AutoRecognizeManager.IsMultiThreadedSupported)
            {
               _maximumThreadsPerJobLabel.Visible = false;
               _maximumThreadsPerJobTextBox.Visible = false;
               _maximumThreadsPerJobInfoLabel.Text = "Multi-threaded is not supported in this engine";
            }

            _preprocessingComboBox.Items.Add("None");
            foreach(OcrAutoPreprocessPageCommand command in Enum.GetValues(typeof(OcrAutoPreprocessPageCommand)))
            {
               _preprocessingComboBox.Items.Add(command.ToString());
            }

            _preprocessingComboBox.SelectedItem = "None";

            if(!string.IsNullOrEmpty(settings.Preprocessing))
            {
               if(string.Compare(settings.Preprocessing, "none", true) == 0)
               {
                  _preprocessingComboBox.SelectedItem = "None";
               }
               else
               {
                  try
                  {
                     OcrAutoPreprocessPageCommand command = (OcrAutoPreprocessPageCommand)Enum.Parse(typeof(OcrAutoPreprocessPageCommand), settings.Preprocessing);
                     _preprocessingComboBox.SelectedItem = command.ToString();
                  }
                  catch { }
               }
            }

            _continueOnErrorCheckBox.Checked = settings.ContinueOnRecoverableErrors;
            _enableTraceCheckBox.Checked = settings.EnableTrace;
            _viewFinalDocumentCheckBox.Checked = settings.ViewFinalDocument;

            UpdateMyControls();

            _loadedOk = true;
         }

         base.OnLoad(e);
      }

      protected override void OnFormClosed(FormClosedEventArgs e)
      {
         if(!DesignMode)
         {
            _documentFormatSelector.SelectedFormatChanged -= new EventHandler<EventArgs>(_documentFormatSelector_SelectedFormatChanged);

            // Clean up
            if(_loadedOk)
            {
               // Save the last setting
               Properties.Settings settings = new Properties.Settings();

               if(JobData.OcrEngine != null)
               {
                  settings.OcrEngineType = JobData.OcrEngine.EngineType.ToString();

                  using(MemoryStream ms = new MemoryStream())
                  {
                     JobData.OcrEngine.DocumentWriterInstance.SaveOptions(ms);
                     settings.FormatOptionsXml = Encoding.Unicode.GetString(ms.ToArray());
                  }
               }

               settings.ImageFileName = _imageFileNameTextBox.Text;
               settings.FirstPageNumber = _imageFirstPageNumber;
               settings.LastPageNumber = _imageLastPageNumber;
               settings.Format = _documentFormatSelector.SelectedFormat.ToString();
               settings.DocumentFileName = _documentFileNameTextBox.Text;
               settings.ZonesFileName = _zonesFileNameTextBox.Text;

               int val;
               if(int.TryParse(_maximumThreadsPerJobTextBox.Text.Trim(), out val))
               {
                  settings.MaximumThreadsPerJob = val;
               }

               if(int.TryParse(_maximumPagesBeforeLtdTextBox.Text.Trim(), out val))
               {
                  settings.MaximumPagesBeforeLtd = val;
               }

               settings.Preprocessing = _preprocessingComboBox.SelectedItem.ToString();

               settings.ContinueOnRecoverableErrors = _continueOnErrorCheckBox.Checked;
               settings.EnableTrace = _enableTraceCheckBox.Checked;
               settings.ViewFinalDocument = _viewFinalDocumentCheckBox.Checked;

               settings.Save();
            }
         }

         base.OnFormClosed(e);
      }

      private void UpdateMyControls()
      {
         if(_imageFirstPageNumber == 1 && _imageLastPageNumber == -1)
         {
            _imageFileNamePagesValueLabel.Text = "All pages";
         }
         else if(_imageLastPageNumber == -1)
         {
            _imageFileNamePagesValueLabel.Text = string.Format("{0} to last", _imageFirstPageNumber);
         }
         else
         {
            _imageFileNamePagesValueLabel.Text = string.Format("{0} to {1}", _imageFirstPageNumber, _imageLastPageNumber);
         }
      }

      private void InitFormats(Properties.Settings settings)
      {
         DocumentFormat initialFormat = DocumentFormat.Pdf;

         if(!string.IsNullOrEmpty(settings.Format))
         {
            try
            {
               initialFormat = (DocumentFormat)Enum.Parse(typeof(DocumentFormat), settings.Format);
            }
            catch { }
         }

         if(!string.IsNullOrEmpty(settings.FormatOptionsXml))
         {
            // Set the document writer options from the last one we saved
            try
            {
               byte[] buffer = Encoding.Unicode.GetBytes(settings.FormatOptionsXml);
               using(MemoryStream ms = new MemoryStream(buffer))
               {
                  JobData.OcrEngine.DocumentWriterInstance.LoadOptions(ms);
               }
            }
            catch
            {
            }
         }

         _documentFormatSelector.SetDocumentWriter(JobData.OcrEngine.DocumentWriterInstance, true);
         _documentFormatSelector.SetOcrEngineType(JobData.OcrEngine.EngineType);
         _documentFormatSelector.SelectedFormat = initialFormat;

         _documentFileNameTextBox.Text = settings.DocumentFileName;
         string extension = DocumentWriter.GetFormatFileExtension(_documentFormatSelector.SelectedFormat);

         if (string.IsNullOrEmpty(_documentFileNameTextBox.Text))
            _documentFileNameTextBox.Text += settings.ImageFileName + "." + extension;
      }

      private void _imageFileNameBrowseButton_Click(object sender, EventArgs e)
      {
         using(OpenFileDialog dlg = new OpenFileDialog())
         {
            dlg.Title = "Select image file to OCR";
            dlg.Filter = "All Files|*.*";
            if(dlg.ShowDialog(this) == DialogResult.OK)
            {
               _imageFileNameTextBox.Text = dlg.FileName;
               if (!string.IsNullOrEmpty(_documentFileNameTextBox.Text))
               {
                  char[] trimChars = { '\\' };
                  _documentFileNameTextBox.Text = ((string.IsNullOrEmpty(Path.GetDirectoryName(_documentFileNameTextBox.Text))) ? Path.GetDirectoryName(dlg.FileName) : Path.GetDirectoryName(_documentFileNameTextBox.Text).TrimEnd(trimChars)) + "\\" + Path.GetFileName(dlg.FileName);
               }
               else
                  _documentFileNameTextBox.Text = dlg.FileName;

               _documentFileNameTextBox.Text += "." +  DocumentWriter.GetFormatFileExtension(_documentFormatSelector.SelectedFormat);
            }
         }
      }

      private void _imageFilePagesBrowseButton_Click(object sender, EventArgs e)
      {
         using(SelectPagesDialog dlg = new SelectPagesDialog())
         {
            dlg.FirstPageNumber = _imageFirstPageNumber;
            dlg.LastPageNumber = _imageLastPageNumber;
            if(dlg.ShowDialog(this) == DialogResult.OK)
            {
               _imageFirstPageNumber = dlg.FirstPageNumber;
               _imageLastPageNumber = dlg.LastPageNumber;
               UpdateMyControls();
            }
         }
      }

      private void _documentFileNameBrowseButton_Click(object sender, EventArgs e)
      {
         using(SaveFileDialog dlg = new SaveFileDialog())
         {
            dlg.Title = "Select output document file name";
            DocumentFormat format = _documentFormatSelector.SelectedFormat;
            string extension = DocumentWriter.GetFormatFileExtension(format);
            string formatName = DocumentWriter.GetFormatFriendlyName(format);
            dlg.Filter = string.Format("{0} (*.{1})|*.{1}|All Files|*.*", formatName, extension);
            dlg.DefaultExt = extension;
            dlg.FileName = Path.GetFileName(_documentFileNameTextBox.Text);

            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
               _documentFileNameTextBox.Text = dlg.FileName;
            }
         }
      }

      private void _documentFormatSelector_SelectedFormatChanged(object sender, EventArgs e)
      {
         // Change the Document Image file extension when the document format is changed.
         DocumentFormat format = _documentFormatSelector.SelectedFormat;
         string extension = DocumentWriter.GetFormatFileExtension(format);
         _documentFileNameTextBox.Text = Path.ChangeExtension(_documentFileNameTextBox.Text, extension);

         DocumentOptions options = JobData.OcrEngine.DocumentWriterInstance.GetOptions(_documentFormatSelector.SelectedFormat);
         _documentFormatSelector.TotalPages = JobData.LastPageNumber - JobData.FirstPageNumber;
         switch(_documentFormatSelector.SelectedFormat)
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
#endif

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

         if(options != null)
         {
            JobData.OcrEngine.DocumentWriterInstance.SetOptions(_documentFormatSelector.SelectedFormat, options);
         }
      }

      private void _zonesFileNameBrowseButton_Click(object sender, EventArgs e)
      {
         using(OpenFileDialog dlg = new OpenFileDialog())
         {
            dlg.Title = "Select input zones file name";
            dlg.Filter = "OCR zone files (*.ozf)|*.ozf|All Files|*.*";
            if(dlg.ShowDialog(this) == DialogResult.OK)
            {
               _zonesFileNameTextBox.Text = dlg.FileName;
            }
         }
      }

      private void _exitButton_Click(object sender, EventArgs e)
      {
         DialogResult = DialogResult.Cancel;
         Close();
      }

      private void _runButton_Click(object sender, EventArgs e)
      {
         // Collect the job data
         string imageFileName = _imageFileNameTextBox.Text.Trim();
         if(string.IsNullOrEmpty(imageFileName))
         {
            Messager.ShowInformation(this, "Enter a valid image file name");
            _imageFileNameTextBox.SelectAll();
            _imageFileNameTextBox.Focus();
            return;
         }

         string documentFileName = _documentFileNameTextBox.Text.Trim();
         if(string.IsNullOrEmpty(documentFileName))
         {
            Messager.ShowInformation(this, "Enter a valid document file name");
            _documentFileNameTextBox.SelectAll();
            _documentFileNameTextBox.Focus();
            return;
         }

         string zonesFileName = _zonesFileNameTextBox.Text.Trim();

         int maximumPagesBeforeLtd;
         if(!int.TryParse(_maximumPagesBeforeLtdTextBox.Text, out maximumPagesBeforeLtd) || maximumPagesBeforeLtd < 0)
         {
            Messager.ShowInformation(this, "Enter a valud equals to or greater than zero for LTD pages");
            _maximumPagesBeforeLtdTextBox.SelectAll();
            _maximumPagesBeforeLtdTextBox.Focus();
            return;
         }

         int maximumThreadsPerJob = 0;
         if(_maximumThreadsPerJobTextBox.Visible)
         {
            if(!int.TryParse(_maximumThreadsPerJobTextBox.Text, out maximumThreadsPerJob) || maximumThreadsPerJob < 0)
            {
               Messager.ShowInformation(this, "Enter a valud equals to or greater than zero for multi-threaded documents");
               _maximumThreadsPerJobTextBox.SelectAll();
               _maximumThreadsPerJobTextBox.Focus();
               return;
            }
         }

         JobData.ImageFileName = imageFileName;
         JobData.FirstPageNumber = _imageFirstPageNumber;
         JobData.LastPageNumber = _imageLastPageNumber;
         JobData.Format = _documentFormatSelector.SelectedFormat;
         JobData.DocumentFileName = documentFileName;
         if(!string.IsNullOrEmpty(zonesFileName))
         {
            JobData.ZonesFileName = zonesFileName;
         }
         else
         {
            JobData.ZonesFileName = null;
         }
         JobData.EnableTrace = _enableTraceCheckBox.Checked;
         if(_continueOnErrorCheckBox.Checked)
         {
            JobData.JobErrorMode = OcrAutoRecognizeManagerJobErrorMode.Continue;
         }
         else
         {
            JobData.JobErrorMode = OcrAutoRecognizeManagerJobErrorMode.Abort;
         }
         JobData.MaximumPagesBeforeLtd = maximumPagesBeforeLtd;
         JobData.MaximumThreadsPerJob = maximumThreadsPerJob;

         if(JobData.PreprocessPageCommands == null)
         {
            JobData.PreprocessPageCommands = new List<OcrAutoPreprocessPageCommand>();
         }

         JobData.PreprocessPageCommands.Clear();

         if(_preprocessingComboBox.SelectedItem.ToString() != "None")
         {
            JobData.PreprocessPageCommands.Add((OcrAutoPreprocessPageCommand)Enum.Parse(typeof(OcrAutoPreprocessPageCommand), _preprocessingComboBox.SelectedItem.ToString()));
         }

         JobData.ViewFinalDocument = _viewFinalDocumentCheckBox.Checked;

         if(!_coresWarningMessageDisplayed && JobData.MaximumThreadsPerJob > Environment.ProcessorCount)
         {
            _coresWarningMessageDisplayed = true;

            if(MessageBox.Show(
               this,
               string.Format(
               "You selected a maximum number of threads per job ({0}) that is greater than the number of cores in this machine ({1}).\n" +
               "This will result in performance that is not optimal. Continue with these values?\n\nThis message will not be displayed again.",
               JobData.MaximumThreadsPerJob, Environment.ProcessorCount),
               Messager.Caption,
               MessageBoxButtons.YesNo,
               MessageBoxIcon.Warning) == DialogResult.No)
            {
               DialogResult = DialogResult.None;
               return;
            }
         }

         DialogResult = DialogResult.OK;
         Close();
      }

      private void _engineSettingsButton_Click(object sender, EventArgs e)
      {
         using(EngineSettingsDialog dlg = new EngineSettingsDialog(JobData.OcrEngine))
         {
            dlg.ShowDialog(this);
         }
      }

      private void _engineLanguagesButton_Click(object sender, EventArgs e)
      {
         using(EnableLanguagesDialog dlg = new EnableLanguagesDialog(JobData.OcrEngine))
         {
            dlg.ShowDialog(this);
         }
      }
   }
}
