// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Leadtools.Document.Writer;
using System.IO;
using Leadtools;
using Leadtools.Demos;

namespace LTDMergeDemo
{
   [DefaultEvent("SelectedFormatChanged")]
   public partial class DocumentFormatOptionsControl : UserControl
   {
      private DocumentWriter _docWriter;
      private PdfDocumentOptions _pdfOptions;

      private class MyFormat
      {
         public DocumentFormat Format;
         public string FriendlyName;
         public string Extension;

         public MyFormat(DocumentFormat f, string n, string e)
         {
            Format = f;
            FriendlyName = n;
            Extension = e;
         }

         public override string ToString()
         {
            return FriendlyName + " (" + Extension.ToUpper() + ")";
         }
      }

      public DocumentFormatOptionsControl()
      {
         InitializeComponent();
      }

      public DocumentFormat SelectedDocumentFormat
      {
         get
         {
            MyFormat mf = _formatComboBox.SelectedItem as MyFormat;
            return mf.Format;
         }
      }

      public string SelectedDocumentFormatFriendlyName
      {
         get
         {
            MyFormat mf = _formatComboBox.SelectedItem as MyFormat;
            return mf.FriendlyName;
         }
      }

      public void SetDocumentWriter(DocumentWriter docWriter)
      {
         // Get the last format, options and document file name selected by the user
         _docWriter = docWriter;

         Properties.Settings settings = new Properties.Settings();
         DocumentFormat initialFormat = DocumentFormat.Pdf;

         if (!string.IsNullOrEmpty(settings.Format))
         {
            try
            {
               initialFormat = (DocumentFormat)Enum.Parse(typeof(DocumentFormat), settings.Format);
            }
            catch { }
         }

         if (!string.IsNullOrEmpty(settings.FormatOptionsXml))
         {
            // Set the document writer options from the last one we saved
            try
            {
               byte[] buffer = Encoding.Unicode.GetBytes(settings.FormatOptionsXml);
               using (MemoryStream ms = new MemoryStream(buffer))
                  _docWriter.LoadOptions(ms);
            }
            catch { }
         }

         // Get the formats
         // This is the order of importance, show these first then the rest as they come along
         DocumentFormat[] importantFormats =
         {
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

         foreach (DocumentFormat format in formatsToAdd)
         {
            if (format != DocumentFormat.User)
            {
               string friendlyName = DocumentWriter.GetFormatFriendlyName(format);
               string extension = DocumentWriter.GetFormatFileExtension(format).ToUpper();

               MyFormat mf = new MyFormat(format, friendlyName, extension);

               _formatComboBox.Items.Add(mf);

               if (mf.Format == initialFormat)
                  _formatComboBox.SelectedItem = mf;
               else if (mf.Format == DocumentFormat.Pdf)
                  pdfFormat = mf;

               switch (format)
               {
                  case DocumentFormat.Pdf:
                     // Update the PDF options page
                     {
                        PdfDocumentOptions pdfOptions = _docWriter.GetOptions(DocumentFormat.Pdf) as PdfDocumentOptions;

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

                        if (string.IsNullOrEmpty(_pdfOptions.Creator))
                           _pdfOptions.Creator = "LEADTOOLS PDFWriter";
                        if (string.IsNullOrEmpty(_pdfOptions.Producer))
                           _pdfOptions.Producer = "LEAD Technologies, Inc.";
                     }
                     break;

                  case DocumentFormat.Doc:
                     // Update the DOC options page
                     {
                        DocDocumentOptions docOptions = _docWriter.GetOptions(DocumentFormat.Doc) as DocDocumentOptions;
                        _cbFramedDoc.Checked = (docOptions.TextMode == DocumentTextMode.Framed) ? true : false;
                     }
                     break;

                  case DocumentFormat.Docx:
                     // Update the DOCX options page
                     {
                        DocxDocumentOptions docxOptions = _docWriter.GetOptions(DocumentFormat.Docx) as DocxDocumentOptions;
                        _cbFramedDocX.Checked = (docxOptions.TextMode == DocumentTextMode.Framed) ? true : false;
                     }
                     break;

                  case DocumentFormat.Rtf:
                     // Update the RTF options page
                     {
                        RtfDocumentOptions rtfOptions = _docWriter.GetOptions(DocumentFormat.Rtf) as RtfDocumentOptions;
                        _cbFramedRtf.Checked = (rtfOptions.TextMode == DocumentTextMode.Framed) ? true : false;
                     }
                     break;

                  case DocumentFormat.Html:
                     // Update the HTML options page
                     {
                        HtmlDocumentOptions htmlOptions = _docWriter.GetOptions(DocumentFormat.Html) as HtmlDocumentOptions;

                        Array a = Enum.GetValues(typeof(DocumentFontEmbedMode));
                        foreach (DocumentFontEmbedMode i in a)
                           _htmlEmbedFontModeComboBox.Items.Add(i);
                        _htmlEmbedFontModeComboBox.SelectedItem = htmlOptions.FontEmbedMode;

                        _htmlUseBackgroundColorCheckBox.Checked = htmlOptions.UseBackgroundColor;

                        _htmlBackgroundColorValueLabel.BackColor = ConvertColor(htmlOptions.BackgroundColor);

                        _htmlBackgroundColorLabel.Enabled = _htmlUseBackgroundColorCheckBox.Checked;
                        _htmlBackgroundColorValueLabel.Enabled = _htmlUseBackgroundColorCheckBox.Checked;
                        _htmlBackgroundColorButton.Enabled = _htmlUseBackgroundColorCheckBox.Checked;
                     }
                     break;

                  case DocumentFormat.Text:
                     // Update the TEXT options page
                     {
                        TextDocumentOptions textOptions = _docWriter.GetOptions(DocumentFormat.Text) as TextDocumentOptions;

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
                        AltoXmlDocumentOptions altoXmlOptions = _docWriter.GetOptions(DocumentFormat.AltoXml) as AltoXmlDocumentOptions;
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
         }

         // Remove all the tab pages
         _optionsTabControl.TabPages.Clear();

         // If no format is selected, default to PDF
         if (_formatComboBox.SelectedIndex == -1)
         {
            if (pdfFormat != null)
               _formatComboBox.SelectedItem = pdfFormat;
            else
               _formatComboBox.SelectedIndex = -1;
         }

         _formatComboBox_SelectedIndexChanged(this, EventArgs.Empty);

         UpdateUIState();
      }

      private void UpdateUIState()
      {
         MyFormat mf = _formatComboBox.SelectedItem as MyFormat;
         if (mf == null)
            return;

         if (mf.Format == DocumentFormat.Html)
         {
            _htmlBackgroundColorLabel.Enabled = _htmlUseBackgroundColorCheckBox.Checked;
            _htmlBackgroundColorValueLabel.Enabled = _htmlUseBackgroundColorCheckBox.Checked;
            _htmlBackgroundColorButton.Enabled = _htmlUseBackgroundColorCheckBox.Checked;
         }

         _altoXmlIndentationLabel.Enabled = _altoXmlFormattedCheckBox.Checked;
         _altoXmlIndentationTextBox.Enabled = _altoXmlFormattedCheckBox.Checked;
      }

      public event EventHandler<EventArgs> SelectedFormatChanged;
      private void _formatComboBox_SelectedIndexChanged(object sender, EventArgs e)
      {
         MyFormat mf = _formatComboBox.SelectedItem as MyFormat;

         // Show only the options page corresponding to this format
         if (_optionsTabControl.TabPages.Count > 0)
            _optionsTabControl.TabPages.Clear();

         switch (mf.Format)
         {
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

            case DocumentFormat.AltoXml:
               _optionsTabControl.TabPages.Add(_altoXmlOptionsTabPage);
               break;

            case DocumentFormat.Ltd:
               _optionsTabControl.TabPages.Add(_ltdOptionsTabPage);
               break;
         }

         _optionsTabControl.Visible = _optionsTabControl.TabPages.Count > 0;

         UpdateUIState();

         if (SelectedFormatChanged != null)
            SelectedFormatChanged(this, EventArgs.Empty);
      }

      private void _pdfDocumentTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
      {
         _pdfOptions.DocumentType = (PdfDocumentType)_pdfDocumentTypeComboBox.SelectedItem;
         UpdateUIState();
      }

      private void _pdfAdvanctionOptionsButton_Click(object sender, EventArgs e)
      {
         Properties.Settings settings = new Properties.Settings();

         using (AdvancedPdfDocumentOptionsDialog dlg = new AdvancedPdfDocumentOptionsDialog(_pdfOptions, 1, settings.AdvancedPdfOptionsSelectedTabIndex))
         {
            dlg.ShowLinearized = false;

            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
               UpdateDocumentWriterOptions();
               settings.AdvancedPdfOptionsSelectedTabIndex = dlg.TabControl.SelectedIndex;
               settings.Save();
            }
         }
      }

      private void _htmlBackgroundColorButton_Click(object sender, EventArgs e)
      {
         using (ColorDialog dlg = new ColorDialog())
         {
            dlg.Color = _htmlBackgroundColorValueLabel.BackColor;
            if (dlg.ShowDialog(this) == DialogResult.OK)
               _htmlBackgroundColorValueLabel.BackColor = dlg.Color;
         }
      }

      private void _htmlUseBackgroundColorCheckBox_CheckedChanged(object sender, EventArgs e)
      {
         _htmlBackgroundColorLabel.Enabled = _htmlUseBackgroundColorCheckBox.Checked;
         _htmlBackgroundColorValueLabel.Enabled = _htmlUseBackgroundColorCheckBox.Checked;
         _htmlBackgroundColorButton.Enabled = _htmlUseBackgroundColorCheckBox.Checked;
      }

      private void _pdfImageOverTextCheckBox_CheckedChanged(object sender, EventArgs e)
      {
         _pdfOptions.ImageOverText = _pdfImageOverTextCheckBox.Checked;
      }

      private void _pdfLinearizedCheckBox_CheckedChanged(object sender, EventArgs e)
      {
         _pdfOptions.Linearized = _pdfLinearizedCheckBox.Checked;
      }

      private void _altoXmlFormattedCheckBox_CheckedChanged(object sender, EventArgs e)
      {
         UpdateUIState();
      }

      public void UpdateDocumentWriterOptions()
      {
         // Save the options
         DocumentFormat format = this.SelectedDocumentFormat;

         Properties.Settings settings = new Properties.Settings();
         settings.Format = format.ToString();

         // Update the options
         DocumentOptions documentOptions = _docWriter.GetOptions(format);

         switch (format)
         {
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
                  pdfOptions.Linearized = _pdfOptions.Linearized;

                  // Security options
                  pdfOptions.Protected = _pdfOptions.Protected;
                  if (pdfOptions.Protected)
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
               // Update the DOCX options
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
                  htmlOptions.BackgroundColor = ConvertColor(_htmlBackgroundColorValueLabel.BackColor);
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
               // Update the DOCX options
               {
                  AltoXmlDocumentOptions altoXmlOptions = documentOptions as AltoXmlDocumentOptions;
                  altoXmlOptions.FileName = _altoXmlFileNameTextBox.Text;
                  altoXmlOptions.SoftwareCreator = _altoXmlSoftwareCreatorTextBox.Text;
                  altoXmlOptions.SoftwareName = _altoXmlSoftwareNameTextBox.Text;
                  altoXmlOptions.ApplicationDescription = _altoXmlApplicationDescriptionTextBox.Text;
                  altoXmlOptions.Formatted = _altoXmlFormattedCheckBox.Checked;
                  altoXmlOptions.Indentation = _altoXmlIndentationTextBox.Text;
                  altoXmlOptions.Sort = _altoXmlSort.Checked;
                  altoXmlOptions.PlainText = _altoXmlPlainText.Checked;
                  altoXmlOptions.ShowGlyphInfo = _altoXmlShowGlyphInfo.Checked;
                  altoXmlOptions.ShowGlyphVariants = _altoXmlShowGlyphVariants.Checked;
                  altoXmlOptions.MeasurementUnit = (AltoXmlMeasurementUnit)_altoXmlMeasurementUnit.SelectedItem;
               }
               break;

            case DocumentFormat.Emf:
            case DocumentFormat.Xls:
            case DocumentFormat.Pub:
            case DocumentFormat.Mob:
            case DocumentFormat.Svg:
            default:
               // These formats have no options
               break;
         }

         if (documentOptions != null)
            _docWriter.SetOptions(format, documentOptions);

         using (MemoryStream ms = new MemoryStream())
         {
            _docWriter.SaveOptions(ms);
            settings.FormatOptionsXml = Encoding.Unicode.GetString(ms.ToArray());
         }

         settings.Save();
      }

      public static Color ConvertColor(RasterColor color)
      {
         return Leadtools.Drawing.RasterColorConverter.ToColor(color);
      }

      public static RasterColor ConvertColor(Color color)
      {
         return Leadtools.Drawing.RasterColorConverter.FromColor(color);
      }
   }
}
