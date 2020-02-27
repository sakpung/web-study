' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms

Imports Leadtools.Ocr
Imports Leadtools.Document.Writer

Partial Public Class DocumentFormatOptionsDialog
   Inherits Form
   Private _ocrEngineType As OcrEngineType
   Private _documentWriter As DocumentWriter
   Private _format As DocumentFormat
   Private _pdfOptions As PdfDocumentOptions
   Private _totalPages As Integer

   Public Sub New(ocrEngineType__1 As OcrEngineType, docWriter As DocumentWriter, format As DocumentFormat, totalPages As Integer)
      InitializeComponent()

      _ocrEngineType = ocrEngineType__1
      _documentWriter = docWriter
      _format = format
      _totalPages = totalPages

      _optionsTabControl.TabPages.Clear()

      Select Case _format
         Case DocumentFormat.Pdf
            ' Update the PDF options page
            If True Then
               _optionsTabControl.TabPages.Add(_pdfOptionsTabPage)

               Dim pdfOptions As PdfDocumentOptions = TryCast(_documentWriter.GetOptions(DocumentFormat.Pdf), PdfDocumentOptions)

               ' Clone it in case we change it in the Advance PDF options dialog
               _pdfOptions = TryCast(pdfOptions.Clone(), PdfDocumentOptions)

               Dim a As Array = [Enum].GetValues(GetType(PdfDocumentType))
               For Each i As PdfDocumentType In a
                  ' PDFA does NOT support Arabic characters so we are not adding it in case of Arabic OCR engine.
                  If ocrEngineType__1 = OcrEngineType.OmniPageArabic AndAlso i = PdfDocumentType.PdfA Then
                     Continue For
                  End If

                  _pdfDocumentTypeComboBox.Items.Add(i)
               Next
               _pdfDocumentTypeComboBox.SelectedItem = pdfOptions.DocumentType

               _pdfImageOverTextCheckBox.Checked = pdfOptions.ImageOverText
               _pdfLinearizedCheckBox.Checked = pdfOptions.Linearized
            End If
            Exit Select

         Case DocumentFormat.Doc
            ' Update the DOC options page
            If True Then
               _optionsTabControl.TabPages.Add(_docOptionsTabPage)
               Dim docOptions As DocDocumentOptions = TryCast(_documentWriter.GetOptions(DocumentFormat.Doc), DocDocumentOptions)
               _docFramedCheckBox.Checked = If((docOptions.TextMode = DocumentTextMode.Framed), True, False)
            End If
            Exit Select

         Case DocumentFormat.Docx
            ' Update the DOCX options page
            If True Then
               _optionsTabControl.TabPages.Add(_docxOptionsTabPage)
               Dim docxOptions As DocxDocumentOptions = TryCast(_documentWriter.GetOptions(DocumentFormat.Docx), DocxDocumentOptions)
               _docxFramedCheckBox.Checked = If((docxOptions.TextMode = DocumentTextMode.Framed), True, False)
            End If
            Exit Select

         Case DocumentFormat.Rtf
            ' Update the RTF options page
            If True Then
               _optionsTabControl.TabPages.Add(_rtfOptionsTabPage)
               Dim rtfOptions As RtfDocumentOptions = TryCast(_documentWriter.GetOptions(DocumentFormat.Rtf), RtfDocumentOptions)
               _rtfFramedCheckBox.Checked = If((rtfOptions.TextMode = DocumentTextMode.Framed), True, False)
            End If
            Exit Select

         Case DocumentFormat.Html
            ' Update the HTML options page
            If True Then
               _optionsTabControl.TabPages.Add(_htmlOptionsTabPage)

               Dim htmlOptions As HtmlDocumentOptions = TryCast(_documentWriter.GetOptions(DocumentFormat.Html), HtmlDocumentOptions)

               Dim a As Array = [Enum].GetValues(GetType(DocumentFontEmbedMode))
               For Each i As DocumentFontEmbedMode In a
                  _htmlEmbedFontModeComboBox.Items.Add(i)
               Next
               _htmlEmbedFontModeComboBox.SelectedItem = htmlOptions.FontEmbedMode

               _htmlUseBackgroundColorCheckBox.Checked = htmlOptions.UseBackgroundColor

               _htmlBackgroundColorValueLabel.BackColor = Leadtools.Demos.Converters.ToGdiPlusColor(htmlOptions.BackgroundColor)

               _htmlBackgroundColorLabel.Enabled = _htmlUseBackgroundColorCheckBox.Checked
               _htmlBackgroundColorValueLabel.Enabled = _htmlUseBackgroundColorCheckBox.Checked
               _htmlBackgroundColorButton.Enabled = _htmlUseBackgroundColorCheckBox.Checked
            End If
            Exit Select

         Case DocumentFormat.Text
            ' Update the TEXT options page
            If True Then
               _optionsTabControl.TabPages.Add(_textOptionsTabPage)

               Dim textOptions As TextDocumentOptions = TryCast(_documentWriter.GetOptions(DocumentFormat.Text), TextDocumentOptions)

               Dim a As Array = [Enum].GetValues(GetType(TextDocumentType))
               For Each i As TextDocumentType In a
                  If i = TextDocumentType.Ansi And ocrEngineType__1 = OcrEngineType.OmniPageArabic Then
                     Continue For
                  End If
                  _textDocumentTypeComboBox.Items.Add(i)
               Next
               _textDocumentTypeComboBox.SelectedItem = textOptions.DocumentType

               _textAddPageNumberCheckBox.Checked = textOptions.AddPageNumber
               _textAddPageBreakCheckBox.Checked = textOptions.AddPageBreak
               _textFormattedCheckBox.Checked = textOptions.Formatted
            End If
            Exit Select

         Case DocumentFormat.AltoXml
            ' Update the ALTOXML options page
            If True Then
               _optionsTabControl.TabPages.Add(_altoXmlOptionsTabPage)
               Dim altoXmlOptions As AltoXmlDocumentOptions = TryCast(_documentWriter.GetOptions(DocumentFormat.AltoXml), AltoXmlDocumentOptions)
               Dim a As Array = [Enum].GetValues(GetType(AltoXmlMeasurementUnit))
               For Each i As AltoXmlMeasurementUnit In a
                  _altoXmlMeasurementUnitComboBox.Items.Add(i)
               Next
               _altoXmlMeasurementUnitComboBox.SelectedItem = altoXmlOptions.MeasurementUnit

               _altoXmlFileNameTextBox.Text = altoXmlOptions.FileName
               _altoXmlSoftwareCreatorTextBox.Text = altoXmlOptions.SoftwareCreator
               _altoXmlSoftwareNameTextBox.Text = altoXmlOptions.SoftwareName
               _altoXmlApplicationDescriptionTextBox.Text = altoXmlOptions.ApplicationDescription
               _altoXmlFormattedCheckBox.Checked = altoXmlOptions.Formatted
               _altoXmlIndentationTextBox.Text = altoXmlOptions.Indentation
               _altoXmlSortCheckBox.Checked = altoXmlOptions.Sort
               _altoXmlPlainTextCheckBox.Checked = altoXmlOptions.PlainText
               _altoXmlShowGlyphInfoCheckBox.Checked = altoXmlOptions.ShowGlyphInfo
               _altoXmlShowGlyphVariantsCheckBox.Checked = altoXmlOptions.ShowGlyphVariants
            End If
            Exit Select

         Case DocumentFormat.Ltd
            If True Then
               _optionsTabControl.TabPages.Add(_ldOptionsTabPage)
            End If
            Exit Select

         Case DocumentFormat.Emf
            If True Then
               _optionsTabControl.TabPages.Add(_emfOptionsTabPage)
            End If
            Exit Select
         Case Else

            If True Then
               _optionsTabControl.TabPages.Add(_emptyOptionsTabPage)
               _emptyOptionsTabPage.Text = String.Format("{0} Options", DocumentWriter.GetFormatFileExtension(_format).ToUpperInvariant())
            End If
            Exit Select
      End Select

      Text = DocumentWriter.GetFormatFriendlyName(_format) + " Options"

      UpdateUIState()
   End Sub

   Private Sub UpdateUIState()
      If _format = DocumentFormat.Html Then
         _htmlBackgroundColorLabel.Enabled = _htmlUseBackgroundColorCheckBox.Checked
         _htmlBackgroundColorValueLabel.Enabled = _htmlUseBackgroundColorCheckBox.Checked
         _htmlBackgroundColorButton.Enabled = _htmlUseBackgroundColorCheckBox.Checked
      End If

      _altoXmlIndentationLabel.Enabled = _altoXmlFormattedCheckBox.Checked
      _altoXmlIndentationTextBox.Enabled = _altoXmlFormattedCheckBox.Checked
   End Sub

   Private Sub _htmlBackgroundColorButton_Click(sender As Object, e As EventArgs) Handles _htmlBackgroundColorButton.Click
      Using dlg As New ColorDialog()
         dlg.Color = _htmlBackgroundColorValueLabel.BackColor
         If dlg.ShowDialog(Me) = DialogResult.OK Then
            _htmlBackgroundColorValueLabel.BackColor = dlg.Color
         End If
      End Using
   End Sub

   Private Sub _pdfDocumentTypeComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles _pdfDocumentTypeComboBox.SelectedIndexChanged
      _pdfOptions.DocumentType = CType(_pdfDocumentTypeComboBox.SelectedItem, PdfDocumentType)
      UpdateUIState()
   End Sub

   Private Sub _htmlUseBackgroundColorCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles _htmlUseBackgroundColorCheckBox.CheckedChanged
      UpdateUIState()
   End Sub

   Private Sub _pdfAdvanctionOptionsButton_Click(sender As Object, e As EventArgs) Handles _pdfAdvanctionOptionsButton.Click
      Using dlg As New AdvancedPdfDocumentOptionsDialog(_pdfOptions, _totalPages, 0)
         dlg.ShowLinearized = False
         dlg.ShowDialog(Me)
      End Using
   End Sub

   Private Sub _okButton_Click(sender As Object, e As EventArgs) Handles _okButton.Click
      Dim options As DocumentOptions = _documentWriter.GetOptions(_format)

      Select Case _format
         Case DocumentFormat.Pdf
            ' Update the PDF options
            If True Then
               Dim pdfOptions As PdfDocumentOptions = TryCast(options, PdfDocumentOptions)
               pdfOptions.DocumentType = CType(_pdfDocumentTypeComboBox.SelectedItem, PdfDocumentType)
               pdfOptions.ImageOverText = _pdfImageOverTextCheckBox.Checked
               pdfOptions.Linearized = _pdfLinearizedCheckBox.Checked
               pdfOptions.FontEmbedMode = _pdfOptions.FontEmbedMode
               pdfOptions.Linearized = _pdfOptions.Linearized
               pdfOptions.Title = _pdfOptions.Title
               pdfOptions.Subject = _pdfOptions.Subject
               pdfOptions.Keywords = _pdfOptions.Keywords
               pdfOptions.Author = _pdfOptions.Author
               pdfOptions.Creator = _pdfOptions.Creator
               pdfOptions.Producer = _pdfOptions.Producer
               pdfOptions.PageRestriction = DocumentPageRestriction.Relaxed

               pdfOptions.[Protected] = _pdfOptions.[Protected]
               If pdfOptions.[Protected] Then
                  pdfOptions.UserPassword = _pdfOptions.UserPassword
                  pdfOptions.OwnerPassword = _pdfOptions.OwnerPassword
                  pdfOptions.EncryptionMode = _pdfOptions.EncryptionMode
                  pdfOptions.PrintEnabled = _pdfOptions.PrintEnabled
                  pdfOptions.HighQualityPrintEnabled = _pdfOptions.HighQualityPrintEnabled
                  pdfOptions.CopyEnabled = _pdfOptions.CopyEnabled
                  pdfOptions.EditEnabled = _pdfOptions.EditEnabled
                  pdfOptions.AnnotationsEnabled = _pdfOptions.AnnotationsEnabled
                  pdfOptions.AssemblyEnabled = _pdfOptions.AssemblyEnabled
               End If

               ' Compression options
               pdfOptions.OneBitImageCompression = _pdfOptions.OneBitImageCompression
               pdfOptions.ColoredImageCompression = _pdfOptions.ColoredImageCompression
               pdfOptions.QualityFactor = _pdfOptions.QualityFactor
               pdfOptions.ImageOverTextSize = _pdfOptions.ImageOverTextSize
               pdfOptions.ImageOverTextMode = _pdfOptions.ImageOverTextMode

               ' Linearized
               pdfOptions.Linearized = _pdfOptions.Linearized

               ' Initial View Options
               pdfOptions.PageModeType = _pdfOptions.PageModeType
               pdfOptions.PageLayoutType = _pdfOptions.PageLayoutType
               pdfOptions.PageFitType = _pdfOptions.PageFitType
               pdfOptions.ZoomPercent = _pdfOptions.ZoomPercent
               pdfOptions.InitialPageNumber = _pdfOptions.InitialPageNumber
               pdfOptions.FitWindow = _pdfOptions.FitWindow
               pdfOptions.CenterWindow = _pdfOptions.CenterWindow
               pdfOptions.DisplayDocTitle = _pdfOptions.DisplayDocTitle
               pdfOptions.HideMenubar = _pdfOptions.HideMenubar
               pdfOptions.HideToolbar = _pdfOptions.HideToolbar
               pdfOptions.HideWindowUI = _pdfOptions.HideWindowUI
            End If
            Exit Select

         Case DocumentFormat.Doc
            ' Update the DOC options
            If True Then
               Dim docOptions As DocDocumentOptions = TryCast(options, DocDocumentOptions)
               docOptions.TextMode = If((_docFramedCheckBox.Checked), DocumentTextMode.Framed, DocumentTextMode.NonFramed)
            End If
            Exit Select

         Case DocumentFormat.Docx
            ' Update the DOCX options
            If True Then
               Dim docxOptions As DocxDocumentOptions = TryCast(options, DocxDocumentOptions)
               docxOptions.TextMode = If((_docxFramedCheckBox.Checked), DocumentTextMode.Framed, DocumentTextMode.NonFramed)
            End If
            Exit Select

         Case DocumentFormat.Rtf
            ' Update the RTF options
            If True Then
               Dim rtfOptions As RtfDocumentOptions = TryCast(options, RtfDocumentOptions)
               rtfOptions.TextMode = If((_rtfFramedCheckBox.Checked), DocumentTextMode.Framed, DocumentTextMode.NonFramed)
            End If
            Exit Select

         Case DocumentFormat.Html
            ' Update the HTML options
            If True Then
               Dim htmlOptions As HtmlDocumentOptions = TryCast(options, HtmlDocumentOptions)
               htmlOptions.FontEmbedMode = CType(_htmlEmbedFontModeComboBox.SelectedItem, DocumentFontEmbedMode)
               htmlOptions.UseBackgroundColor = _htmlUseBackgroundColorCheckBox.Checked
               htmlOptions.BackgroundColor = Leadtools.Demos.Converters.FromGdiPlusColor(_htmlBackgroundColorValueLabel.BackColor)
            End If
            Exit Select

         Case DocumentFormat.Text
            ' Update the TEXT options
            If True Then
               Dim textOptions As TextDocumentOptions = TryCast(options, TextDocumentOptions)
               textOptions.DocumentType = CType(_textDocumentTypeComboBox.SelectedItem, TextDocumentType)
               textOptions.AddPageNumber = _textAddPageNumberCheckBox.Checked
               textOptions.AddPageBreak = _textAddPageBreakCheckBox.Checked
               textOptions.Formatted = _textFormattedCheckBox.Checked
            End If
            Exit Select

         Case DocumentFormat.AltoXml
            ' Update the ALTOXML options
            If True Then
               Dim altoXmlOptions As AltoXmlDocumentOptions = TryCast(options, AltoXmlDocumentOptions)
               altoXmlOptions.MeasurementUnit = CType(_altoXmlMeasurementUnitComboBox.SelectedItem, AltoXmlMeasurementUnit)
               altoXmlOptions.FileName = _altoXmlFileNameTextBox.Text
               altoXmlOptions.SoftwareCreator = _altoXmlSoftwareCreatorTextBox.Text
               altoXmlOptions.SoftwareName = _altoXmlSoftwareNameTextBox.Text
               altoXmlOptions.ApplicationDescription = _altoXmlApplicationDescriptionTextBox.Text
               altoXmlOptions.Formatted = _altoXmlFormattedCheckBox.Checked
               altoXmlOptions.Indentation = _altoXmlIndentationTextBox.Text
               altoXmlOptions.Sort = _altoXmlSortCheckBox.Checked
               altoXmlOptions.PlainText = _altoXmlPlainTextCheckBox.Checked
               altoXmlOptions.ShowGlyphInfo = _altoXmlShowGlyphInfoCheckBox.Checked
               altoXmlOptions.ShowGlyphVariants = _altoXmlShowGlyphVariantsCheckBox.Checked
            End If
            Exit Select

         Case DocumentFormat.Ltd, DocumentFormat.Emf
            ' These formats have no options
            Exit Select
      End Select

      If options IsNot Nothing Then
         _documentWriter.SetOptions(_format, options)
      End If
   End Sub

   Private Sub _pdfImageOverTextCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles _pdfImageOverTextCheckBox.CheckedChanged
      _pdfOptions.ImageOverText = _pdfImageOverTextCheckBox.Checked
   End Sub

   Private Sub _pdfLinearizedCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles _pdfLinearizedCheckBox.CheckedChanged
      _pdfOptions.Linearized = _pdfLinearizedCheckBox.Checked
   End Sub

   Private Sub _altoXmlFormattedCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles _altoXmlFormattedCheckBox.CheckedChanged
      UpdateUIState()
   End Sub
End Class
