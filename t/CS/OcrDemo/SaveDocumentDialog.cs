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
using Leadtools.Ocr;
using Leadtools.Document.Writer;

namespace OcrDemo
{
   public partial class SaveDocumentDialog : Form
   {
      private IOcrDocument _ocrDocument;
      private DocumentFormat _selectedFormat;
      private string _selectedFileName;
      private string _srcFileName;
      private bool _selectedViewDocument;
      private bool _customFileName = false; // Has user given own file name.
      private PdfDocumentOptions _pdfOptions;

      private class MyFormat
      {
         public DocumentFormat Format;
         public string FriendlyName;

         public MyFormat(DocumentFormat f, string n)
         {
            Format = f;
            FriendlyName = n;
         }

         public override string ToString()
         {
            return FriendlyName;
         }
      }

      private class MyEngineFormat
      {
         public string Format;
         public string FriendlyName;

         public MyEngineFormat(string f, string n)
         {
            Format = f;
            FriendlyName = n;
         }

         public override string ToString()
         {
            return FriendlyName;
         }
      }

      public SaveDocumentDialog(IOcrDocument ocrDocument, DocumentFormat initialFormat, string initialFileName, bool viewDocument, bool customFileName)
      {
         InitializeComponent();
         _srcFileName = initialFileName;
         _customFileName = customFileName;

         _ocrDocument = ocrDocument;

         // Get the formats
         // This is the order of importance, show these first then the rest as they come along
         DocumentFormat[] importantFormats =
         {
            DocumentFormat.Ltd,
            DocumentFormat.Pdf,
            DocumentFormat.Docx,
            DocumentFormat.Rtf,
            DocumentFormat.Text,
            DocumentFormat.Doc,
            DocumentFormat.Xls,
            DocumentFormat.Html
         };

         List<DocumentFormat> formatsToAdd = new List<DocumentFormat>();

         Array temp = Enum.GetValues(typeof(DocumentFormat));
         List<DocumentFormat> allFormats = new List<DocumentFormat>();
         foreach (DocumentFormat format in temp)
            allFormats.Add(format);

         // Add important once first:
         foreach (DocumentFormat format in importantFormats)
         {
            formatsToAdd.Add(format);
            allFormats.Remove(format);
         }

         // Add rest
         formatsToAdd.AddRange(allFormats);

         MyFormat pdfFormat = null;

         DocumentWriter docWriter = _ocrDocument.Engine.DocumentWriterInstance;
         IOcrDocumentManager ocrDocumentManager = _ocrDocument.Engine.DocumentManager;
         string[] engineSupportedFormatNames = ocrDocumentManager.GetSupportedEngineFormats();

         foreach (DocumentFormat format in formatsToAdd)
         {
            bool addFormat = true;

            // If this is the "User" or Engines format, only add it if the OCR engine supports them
            if(format == DocumentFormat.User && engineSupportedFormatNames.Length == 0)
               addFormat = false;

            if(addFormat)
            {
               string friendlyName;
               if(format == DocumentFormat.User)
                  friendlyName = "Engine native";
               else
                  friendlyName = DocumentWriter.GetFormatFriendlyName(format);

               MyFormat mf = new MyFormat(format, friendlyName);

               _formatComboBox.Items.Add(mf);

               if(mf.Format == initialFormat)
                  _formatComboBox.SelectedItem = mf;
               else if(mf.Format == DocumentFormat.Pdf)
                  pdfFormat = mf;
            }

            switch(format)
            {
               case DocumentFormat.User:
                  // Update the User (Engine) options page
                  {
                     foreach(string engineFormatName in engineSupportedFormatNames)
                     {
                        MyEngineFormat mef = new MyEngineFormat(
                           engineFormatName,
                           ocrDocumentManager.GetEngineFormatFriendlyName(engineFormatName));
                        _userFormatNameComboBox.Items.Add(mef);

                        if(mef.Format == ocrDocumentManager.EngineFormat)
                           _userFormatNameComboBox.SelectedItem = mef;
                     }

                     if(_userFormatNameComboBox.SelectedItem == null && _userFormatNameComboBox.Items.Count > 0)
                        _userFormatNameComboBox.SelectedIndex = 0;
                  }
                  break;

               case DocumentFormat.Pdf:
                  // Update the PDF options page
                  {
                     PdfDocumentOptions pdfOptions = docWriter.GetOptions(DocumentFormat.Pdf) as PdfDocumentOptions;

                     // Clone it in case we change it in the Advance PDF options dialog
                     _pdfOptions = pdfOptions.Clone() as PdfDocumentOptions;

                     Array a = Enum.GetValues(typeof(PdfDocumentType));
                     foreach (PdfDocumentType i in a)
                     {
                        _pdfDocumentTypeComboBox.Items.Add(i);
                     }
                     _pdfDocumentTypeComboBox.SelectedItem = _pdfOptions.DocumentType;

                     _pdfImageOverTextCheckBox.Checked = _pdfOptions.ImageOverText;
                     _pdfLinearizedCheckBox.Checked = _pdfOptions.Linearized;

                     if(string.IsNullOrEmpty(_pdfOptions.Creator))
                        _pdfOptions.Creator = "LEADTOOLS PDFWriter";
                     if(string.IsNullOrEmpty(_pdfOptions.Producer))
                        _pdfOptions.Producer = "LEAD Technologies, Inc.";
                  }
                  break;

               case DocumentFormat.Doc:
                  // Update the DOC options page
                  {
                     DocDocumentOptions docOptions = docWriter.GetOptions(DocumentFormat.Doc) as DocDocumentOptions;
                     _cbFramedDoc.Checked = (docOptions.TextMode == DocumentTextMode.Framed) ? true : false;
                  }
                  break;

               case DocumentFormat.Docx:
                  // Update the DOCX options page
                  {
                     DocxDocumentOptions docxOptions = docWriter.GetOptions(DocumentFormat.Docx) as DocxDocumentOptions;
                     _cbFramedDocX.Checked = (docxOptions.TextMode == DocumentTextMode.Framed) ? true : false;
                  }
                  break;

               case DocumentFormat.Rtf:
                  // Update the RTF options page
                  {
                     RtfDocumentOptions rtfOptions = docWriter.GetOptions(DocumentFormat.Rtf) as RtfDocumentOptions;
                     _cbFramedRtf.Checked = (rtfOptions.TextMode == DocumentTextMode.Framed) ? true : false;
                  }
                  break;

               case DocumentFormat.Html:
                  // Update the HTML options page
                  {
                     HtmlDocumentOptions htmlOptions = docWriter.GetOptions(DocumentFormat.Html) as HtmlDocumentOptions;

                     Array a = Enum.GetValues(typeof(DocumentFontEmbedMode));
                     foreach(DocumentFontEmbedMode i in a)
                        _htmlEmbedFontModeComboBox.Items.Add(i);
                     _htmlEmbedFontModeComboBox.SelectedItem = htmlOptions.FontEmbedMode;

                     _htmlUseBackgroundColorCheckBox.Checked = htmlOptions.UseBackgroundColor;

                     _htmlBackgroundColorValueLabel.BackColor = MainForm.ConvertColor(htmlOptions.BackgroundColor);

                     _htmlBackgroundColorLabel.Enabled = _htmlUseBackgroundColorCheckBox.Checked;
                     _htmlBackgroundColorValueLabel.Enabled = _htmlUseBackgroundColorCheckBox.Checked;
                     _htmlBackgroundColorButton.Enabled = _htmlUseBackgroundColorCheckBox.Checked;
                  }
                  break;

               case DocumentFormat.Text:
                  // Update the TEXT options page
                  {
                     TextDocumentOptions textOptions = docWriter.GetOptions(DocumentFormat.Text) as TextDocumentOptions;

                     Array a = Enum.GetValues(typeof(TextDocumentType));
                     foreach (TextDocumentType i in a)
                     {
                        _textDocumentTypeComboBox.Items.Add(i);
                     }
                     _textDocumentTypeComboBox.SelectedItem = textOptions.DocumentType;

                     _textAddPageNumberCheckBox.Checked = textOptions.AddPageNumber;
                     _textAddPageBreakCheckBox.Checked = textOptions.AddPageBreak;
                     _textFormattedCheckBox.Checked = textOptions.Formatted;
                  }
                  break;

               case DocumentFormat.AltoXml:
                  // Update the ALTOXML options page
                  {
                     AltoXmlDocumentOptions altoXmlOptions = docWriter.GetOptions(DocumentFormat.AltoXml) as AltoXmlDocumentOptions;
                     _altoXmlFileNameTextBox.Text = altoXmlOptions.FileName;
                     _altoXmlSoftwareCreatorTextBox.Text = altoXmlOptions.SoftwareCreator;
                     _altoXmlSoftwareNameTextBox.Text = altoXmlOptions.SoftwareName;
                     _altoXmlApplicationDescriptionTextBox.Text = altoXmlOptions.ApplicationDescription;
                     _altoXmlFormattedCheckBox.Checked = altoXmlOptions.Formatted;
                     _altoXmlIndentationTextBox.Text = altoXmlOptions.Indentation;
                     _altoXmlSort.Checked = altoXmlOptions.Sort;
                     _altoXmlPlainText.Checked = altoXmlOptions.PlainText;
                     _altoXmlShowGlyphInfo.Checked = altoXmlOptions.ShowGlyphInfo;
                     _altoXmlShowGlyphVariants.Checked = altoXmlOptions.ShowGlyphVariants;

                     Array a = Enum.GetValues(typeof(AltoXmlMeasurementUnit));
                     foreach (AltoXmlMeasurementUnit i in a)
                        _altoXmlMeasurementUnit.Items.Add(i);
                     _altoXmlMeasurementUnit.SelectedItem = altoXmlOptions.MeasurementUnit;
                  }
                  break;

               case DocumentFormat.Ltd:
               case DocumentFormat.Emf:
               case DocumentFormat.Xls:
               case DocumentFormat.Pub:
               case DocumentFormat.Mob:
               case DocumentFormat.Svg:
               default:
                  // These formats have no options
                  break;
            }
         }

         // Remove all the tab pages
         _optionsTabControl.TabPages.Clear();

         // If no format is selected, default to PDF
         if(_formatComboBox.SelectedIndex == -1)
         {
            if(pdfFormat != null)
               _formatComboBox.SelectedItem = pdfFormat;
            else
               _formatComboBox.SelectedIndex = -1;
         }

         _viewDocumentCheckBox.Checked = viewDocument;
         _fileNameTextBox.Text = initialFileName;

         _formatComboBox_SelectedIndexChanged(this, EventArgs.Empty);
         UpdateUIState();
      }

      public bool CustomFileName
      {
         get
         {
            return _customFileName;
         }
         set
         {
            _customFileName = value;
         }
      }
      public DocumentFormat SelectedFormat
      {
         get
         {
            return _selectedFormat;
         }
      }

      public string SelectedFileName
      {
         get
         {
            return _selectedFileName;
         }
      }

      public bool SelectedViewDocument
      {
         get
         {
            return _selectedViewDocument;
         }
      }

      private void _fileNameTextBox_TextChanged(object sender, EventArgs e)
      {
         UpdateUIState();
      }

      private string GetFileExtension(DocumentFormat format)
      {
         string extension;

         if(format == DocumentFormat.User)
         {
            MyEngineFormat mef = _userFormatNameComboBox.SelectedItem as MyEngineFormat;
            IOcrDocumentManager ocrDocumentManager = _ocrDocument.Engine.DocumentManager;
            extension = ocrDocumentManager.GetEngineFormatFileExtension(mef.Format);
         }
         else
            extension = DocumentWriter.GetFormatFileExtension(format);

         return extension;
      }

      private void _browseButton_Click(object sender, EventArgs e)
      {
         // Show the save file dialog

         using(SaveFileDialog dlg = new SaveFileDialog())
         {
            // Get the selected format name and extension
            MyFormat mf = _formatComboBox.SelectedItem as MyFormat;

            string extension = GetFileExtension(mf.Format);

            dlg.Filter = string.Format("{0} (*.{1})|*.{1}|All Files (*.*)|*.*", mf.FriendlyName, extension);
            dlg.DefaultExt = extension;
            dlg.FileName = Path.GetFileName(_fileNameTextBox.Text);

            if(dlg.ShowDialog(this) == DialogResult.OK)
               _fileNameTextBox.Text = dlg.FileName;
         }
      }

      private void _formatComboBox_SelectedIndexChanged(object sender, EventArgs e)
      {
         MyFormat mf = _formatComboBox.SelectedItem as MyFormat;

         // Update the extension of the file name
         // Update the current format options tab page
         string fileName = _fileNameTextBox.Text;
         if(!string.IsNullOrEmpty(fileName))
         {
            string extension = GetFileExtension(mf.Format);

            if (fileName.Equals(_srcFileName) && !_customFileName)
               _fileNameTextBox.Text += "." + extension;
            else
               _fileNameTextBox.Text = Path.ChangeExtension(fileName, extension);
         }

         // Show only the options page corresponding to this format
         if(_optionsTabControl.TabPages.Count > 0)
            _optionsTabControl.TabPages.Clear();

         switch(mf.Format)
         {
            case DocumentFormat.Ltd:
               _optionsTabControl.TabPages.Add(_ldOptionsTabPage);
               break;

            case DocumentFormat.Emf:
               _optionsTabControl.TabPages.Add(_emfOptionsTabPage);
               break;

            case DocumentFormat.Pdf:
               _optionsTabControl.TabPages.Add(_pdfOptionsTabPage);
               break;

            case DocumentFormat.Doc:
               _optionsTabControl.TabPages.Add(_docOptionsTabPage);
               break;

            case DocumentFormat.Docx:
               _optionsTabControl.TabPages.Add(_docxOptionsTabPage);
               break;

            case DocumentFormat.Rtf:
               _optionsTabControl.TabPages.Add(_rtfOptionsTabPage);
               break;

            case DocumentFormat.Html:
               _optionsTabControl.TabPages.Add(_htmlOptionsTabPage);
               break;

            case DocumentFormat.Text:
               _optionsTabControl.TabPages.Add(_textOptionsTabPage);
               break;

            case DocumentFormat.Xps:
               _optionsTabControl.TabPages.Add(_xpsOptionsTabPage);
               break;

            case DocumentFormat.Xls:
               _optionsTabControl.TabPages.Add(_xlsOptionsTabPage);
               break;

            case DocumentFormat.Pub:
               _optionsTabControl.TabPages.Add(_ePubOptionsTabPage);
               break;

            case DocumentFormat.Mob:
               _optionsTabControl.TabPages.Add(_mobOptionsTabPage);
               break;

            case DocumentFormat.Svg:
               _optionsTabControl.TabPages.Add(_svgOptionsTabPage);
               break;

            case DocumentFormat.User:
               _optionsTabControl.TabPages.Add(_userOptionsTabPage);
               break;

            case DocumentFormat.AltoXml:
               _optionsTabControl.TabPages.Add(_altoXmlOptionsTabPage);
               break;
         }

         _optionsTabControl.Visible = _optionsTabControl.TabPages.Count > 0;

         UpdateUIState();
      }

      private void UpdateUIState()
      {
         _okButton.Enabled = _fileNameTextBox.Text.Trim().Length > 0;

         MyFormat mf = _formatComboBox.SelectedItem as MyFormat;
         if (mf == null)
            return;

         if (mf.Format == DocumentFormat.Ltd)
         {
            _viewDocumentCheckBox.Checked = false;
            _viewDocumentCheckBox.Enabled = false;

            _viewDocumentCheckBox.Enabled = false;
         }
         else
         {
            if(mf.Format == DocumentFormat.Html)
            {
               _htmlBackgroundColorLabel.Enabled = _htmlUseBackgroundColorCheckBox.Checked;
               _htmlBackgroundColorValueLabel.Enabled = _htmlUseBackgroundColorCheckBox.Checked;
               _htmlBackgroundColorButton.Enabled = _htmlUseBackgroundColorCheckBox.Checked;
            }

            _viewDocumentCheckBox.Enabled = true;
         }

         _altoXmlIndentationLabel.Enabled = _altoXmlFormattedCheckBox.Checked;
         _altoXmlIndentationTextBox.Enabled = _altoXmlFormattedCheckBox.Checked;
      }

      private void _htmlBackgroundColorButton_Click(object sender, EventArgs e)
      {
         using(ColorDialog dlg = new ColorDialog())
         {
            dlg.Color = _htmlBackgroundColorValueLabel.BackColor;
            if(dlg.ShowDialog(this) == DialogResult.OK)
               _htmlBackgroundColorValueLabel.BackColor = dlg.Color;
         }
      }

      private void _userFormatNameComboBox_SelectedIndexChanged(object sender, EventArgs e)
      {
         // Update the extension of the file name
         // Update the current format options tab page
         string fileName = _fileNameTextBox.Text;
         if (!string.IsNullOrEmpty(fileName))
         {
            string extension = GetFileExtension(DocumentFormat.User);

            if (fileName.Equals(_srcFileName) && _customFileName)
               _fileNameTextBox.Text += "." + extension;
            else
               _fileNameTextBox.Text = Path.ChangeExtension(fileName, extension);
         }

         UpdateUIState();
      }

      private void _pdfDocumentTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
      {
         _pdfOptions.DocumentType = (PdfDocumentType)_pdfDocumentTypeComboBox.SelectedItem;
         UpdateUIState();
      }

      private void _pdfAdvanctionOptionsButton_Click(object sender, EventArgs e)
      {
         Properties.Settings settings = new Properties.Settings();
         int tabIndex = settings.AdvancedPdfOptionsSelectedTabIndex;

         _pdfOptions.ImageOverText = _pdfImageOverTextCheckBox.Checked;
         _pdfOptions.Linearized = _pdfLinearizedCheckBox.Checked;
         using (AdvancedPdfDocumentOptionsDialog dlg = new AdvancedPdfDocumentOptionsDialog(_pdfOptions, (_ocrDocument != null && _ocrDocument.Pages != null) ? ((_ocrDocument.Pages.Count > 0) ? _ocrDocument.Pages.Count : 1) : 1, tabIndex))
         {
            dlg.ShowLinearized = false;
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
               settings.AdvancedPdfOptionsSelectedTabIndex = dlg.TabControl.SelectedIndex;
               settings.Save();
            }
         }
      }

      private void _htmlUseBackgroundColorCheckBox_CheckedChanged(object sender, EventArgs e)
      {
         _htmlBackgroundColorLabel.Enabled = _htmlUseBackgroundColorCheckBox.Checked;
         _htmlBackgroundColorValueLabel.Enabled = _htmlUseBackgroundColorCheckBox.Checked;
         _htmlBackgroundColorButton.Enabled = _htmlUseBackgroundColorCheckBox.Checked;
      }

      private void _okButton_Click(object sender, EventArgs e)
      {
         DocumentWriter docWriter = _ocrDocument.Engine.DocumentWriterInstance;
         IOcrDocumentManager ocrDocumentManager = _ocrDocument.Engine.DocumentManager;

         // Save the options
         MyFormat mf = _formatComboBox.SelectedItem as MyFormat;

         DocumentOptions documentOptions;
         if(mf.Format != DocumentFormat.User)
            documentOptions = docWriter.GetOptions(mf.Format);
         else
            documentOptions = null;

         switch(mf.Format)
         {
            case DocumentFormat.User:
               // Update the User (Engine) options
               {
                  MyEngineFormat mef = _userFormatNameComboBox.SelectedItem as MyEngineFormat;
                  ocrDocumentManager.EngineFormat = mef.Format;
               }
               break;

            case DocumentFormat.Pdf:
               // Update the PDF options
               {
                  PdfDocumentOptions pdfOptions = documentOptions as PdfDocumentOptions;

                  pdfOptions.DocumentType = (PdfDocumentType)_pdfDocumentTypeComboBox.SelectedItem;
                  pdfOptions.ImageOverText = _pdfImageOverTextCheckBox.Checked;
                  pdfOptions.Linearized = _pdfLinearizedCheckBox.Checked;
                  pdfOptions.PageRestriction = DocumentPageRestriction.Relaxed;

                  // Description options
                  pdfOptions.Title = _pdfOptions.Title;
                  pdfOptions.Subject = _pdfOptions.Subject;
                  pdfOptions.Keywords = _pdfOptions.Keywords;
                  pdfOptions.Author = _pdfOptions.Author;
                  pdfOptions.Creator = _pdfOptions.Creator;
                  pdfOptions.Producer = _pdfOptions.Producer;

                  // Fonts options
                  pdfOptions.FontEmbedMode = _pdfOptions.FontEmbedMode;

                  // Security options
                  pdfOptions.Protected = _pdfOptions.Protected;
                  if(pdfOptions.Protected)
                  {
                     pdfOptions.UserPassword = _pdfOptions.UserPassword;
                     pdfOptions.OwnerPassword = _pdfOptions.OwnerPassword;
                     pdfOptions.EncryptionMode = _pdfOptions.EncryptionMode;
                     pdfOptions.PrintEnabled = _pdfOptions.PrintEnabled;
                     pdfOptions.HighQualityPrintEnabled = _pdfOptions.HighQualityPrintEnabled;
                     pdfOptions.CopyEnabled = _pdfOptions.CopyEnabled;
                     pdfOptions.EditEnabled = _pdfOptions.EditEnabled;
                     pdfOptions.AnnotationsEnabled = _pdfOptions.AnnotationsEnabled;
                     pdfOptions.AssemblyEnabled = _pdfOptions.AssemblyEnabled;
                  }

                  // Compression options
                  pdfOptions.OneBitImageCompression = _pdfOptions.OneBitImageCompression;
                  pdfOptions.ColoredImageCompression = _pdfOptions.ColoredImageCompression;
                  pdfOptions.QualityFactor = _pdfOptions.QualityFactor;
                  pdfOptions.ImageOverTextSize = _pdfOptions.ImageOverTextSize;
                  pdfOptions.ImageOverTextMode = _pdfOptions.ImageOverTextMode;

                  // Initial View Options
                  pdfOptions.PageModeType = _pdfOptions.PageModeType;
                  pdfOptions.PageLayoutType = _pdfOptions.PageLayoutType;
                  pdfOptions.PageFitType = _pdfOptions.PageFitType;
                  pdfOptions.ZoomPercent = _pdfOptions.ZoomPercent;
                  pdfOptions.InitialPageNumber = _pdfOptions.InitialPageNumber;
                  pdfOptions.FitWindow = _pdfOptions.FitWindow;
                  pdfOptions.CenterWindow = _pdfOptions.CenterWindow;
                  pdfOptions.DisplayDocTitle = _pdfOptions.DisplayDocTitle;
                  pdfOptions.HideMenubar = _pdfOptions.HideMenubar;
                  pdfOptions.HideToolbar = _pdfOptions.HideToolbar;
                  pdfOptions.HideWindowUI = _pdfOptions.HideWindowUI;
               }
               break;

            case DocumentFormat.Doc:
               // Update the DOC options
               {
                  DocDocumentOptions docOptions = documentOptions as DocDocumentOptions;
                  docOptions.TextMode = (_cbFramedDoc.Checked) ? DocumentTextMode.Framed : DocumentTextMode.NonFramed;
               }
               break;

            case DocumentFormat.Docx:
               // Update the DOC options
               {
                  DocxDocumentOptions docxOptions = documentOptions as DocxDocumentOptions;
                  docxOptions.TextMode = (_cbFramedDocX.Checked) ? DocumentTextMode.Framed : DocumentTextMode.NonFramed;
               }
               break;

            case DocumentFormat.Rtf:
               // Update the RTF options
               {
                  RtfDocumentOptions rtfOptions = documentOptions as RtfDocumentOptions;
                  rtfOptions.TextMode = (_cbFramedRtf.Checked) ? DocumentTextMode.Framed : DocumentTextMode.NonFramed;
               }
               break;

            case DocumentFormat.Html:
               // Update the HTML options
               {
                  HtmlDocumentOptions htmlOptions = documentOptions as HtmlDocumentOptions;
                  htmlOptions.FontEmbedMode = (DocumentFontEmbedMode)_htmlEmbedFontModeComboBox.SelectedItem;
                  htmlOptions.UseBackgroundColor = _htmlUseBackgroundColorCheckBox.Checked;
                  htmlOptions.BackgroundColor = MainForm.ConvertColor(_htmlBackgroundColorValueLabel.BackColor);
               }
               break;

            case DocumentFormat.Text:
               // Update the TEXT options
               {
                  TextDocumentOptions textOptions = documentOptions as TextDocumentOptions;
                  textOptions.DocumentType = (TextDocumentType)_textDocumentTypeComboBox.SelectedItem;
                  textOptions.AddPageNumber = _textAddPageNumberCheckBox.Checked;
                  textOptions.AddPageBreak = _textAddPageBreakCheckBox.Checked;
                  textOptions.Formatted = _textFormattedCheckBox.Checked;
               }
               break;

            case DocumentFormat.AltoXml:
               // Update the ALTOXML options
               {
                  AltoXmlDocumentOptions altoXmlOptions = documentOptions as AltoXmlDocumentOptions;
                  altoXmlOptions.FileName = _altoXmlFileNameTextBox.Text;
                  altoXmlOptions.SoftwareCreator = _altoXmlSoftwareCreatorTextBox.Text;
                  altoXmlOptions.SoftwareName = _altoXmlSoftwareNameTextBox.Text;
                  altoXmlOptions.ApplicationDescription = _altoXmlApplicationDescriptionTextBox.Text;
                  altoXmlOptions.Formatted = _altoXmlFormattedCheckBox.Checked;
                  altoXmlOptions.Indentation = (altoXmlOptions.Formatted) ? _altoXmlIndentationTextBox.Text : "";
                  altoXmlOptions.Sort = _altoXmlSort.Checked;
                  altoXmlOptions.PlainText = _altoXmlPlainText.Checked;
                  altoXmlOptions.ShowGlyphInfo = _altoXmlShowGlyphInfo.Checked;
                  altoXmlOptions.ShowGlyphVariants = _altoXmlShowGlyphVariants.Checked;
                  altoXmlOptions.MeasurementUnit = (AltoXmlMeasurementUnit)_altoXmlMeasurementUnit.SelectedItem;
               }
               break;

            case DocumentFormat.Ltd:
            case DocumentFormat.Emf:
            case DocumentFormat.Xls:
            case DocumentFormat.Pub:
            case DocumentFormat.Mob:
            case DocumentFormat.Svg:
            default:
               // These formats have no options
               break;
         }

         if(documentOptions != null)
            docWriter.SetOptions(mf.Format, documentOptions);

         // Get the save parameters
         _selectedFileName = _fileNameTextBox.Text;
         _selectedFormat = mf.Format;
         _selectedViewDocument = _viewDocumentCheckBox.Checked;
      }

      private void _altoXmlFormattedCheckBox_CheckedChanged(object sender, EventArgs e)
      {
         UpdateUIState();
      }
   }
}
