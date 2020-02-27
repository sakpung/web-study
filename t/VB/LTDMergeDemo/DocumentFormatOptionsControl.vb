' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************

Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports Leadtools.Document.Writer
Imports System.IO
Imports Leadtools
Imports Leadtools.Demos
Imports System

Imports Leadtools.Drawing

<DefaultEvent("SelectedFormatChanged")>
Partial Public Class DocumentFormatOptionsControl
   Inherits UserControl
   Private _docWriter As DocumentWriter
   Private _pdfOptions As PdfDocumentOptions

   Private Class MyFormat
      Public Format As DocumentFormat
      Public FriendlyName As String
      Public Extension As String

      Public Sub New(f As DocumentFormat, n As String, e As String)
         Format = f
         FriendlyName = n
         Extension = e
      End Sub

      Public Overrides Function ToString() As String
         Return (FriendlyName & Convert.ToString(" (")) + Extension.ToUpper() + ")"
      End Function
   End Class

   Public Sub New()
      InitializeComponent()
   End Sub

   Public ReadOnly Property SelectedDocumentFormat() As DocumentFormat
      Get
         Dim mf As MyFormat = TryCast(_formatComboBox.SelectedItem, MyFormat)
         Return mf.Format
      End Get
   End Property

   Public ReadOnly Property SelectedDocumentFormatFriendlyName() As String
      Get
         Dim mf As MyFormat = TryCast(_formatComboBox.SelectedItem, MyFormat)
         Return mf.FriendlyName
      End Get
   End Property

   Public Sub SetDocumentWriter(docWriter As DocumentWriter)
      ' Get the last format, options and document file name selected by the user
      _docWriter = docWriter

      Dim settings As New LTDMergeDemo.Settings()
      Dim initialFormat As DocumentFormat = DocumentFormat.Pdf

      If Not String.IsNullOrEmpty(settings.Format) Then
         Try
            initialFormat = CType([Enum].Parse(GetType(DocumentFormat), settings.Format), DocumentFormat)
         Catch
         End Try
      End If

      If Not String.IsNullOrEmpty(settings.FormatOptionsXml) Then
         ' Set the document writer options from the last one we saved
         Try
            Dim buffer As Byte() = Encoding.Unicode.GetBytes(settings.FormatOptionsXml)
            Using ms As New MemoryStream(buffer)
               _docWriter.LoadOptions(ms)
            End Using
         Catch
         End Try
      End If

      ' Get the formats
      ' This is the order of importance, show these first then the rest as they come along
      Dim importantFormats As DocumentFormat() = {DocumentFormat.Pdf, DocumentFormat.Docx, DocumentFormat.Rtf, DocumentFormat.Text, DocumentFormat.Doc, DocumentFormat.Xls,
       DocumentFormat.Html}

      Dim formatsToAdd As New List(Of DocumentFormat)()

      Dim temp As Array = [Enum].GetValues(GetType(DocumentFormat))
      Dim allFormats As New List(Of DocumentFormat)()
      For Each format As DocumentFormat In temp
         allFormats.Add(format)
      Next

      ' Add important once first:
      For Each format As DocumentFormat In importantFormats
         formatsToAdd.Add(format)
         allFormats.Remove(format)
      Next

      ' Add rest
      formatsToAdd.AddRange(allFormats)

      Dim pdfFormat As MyFormat = Nothing

      For Each format As DocumentFormat In formatsToAdd
         If format <> DocumentFormat.User Then
            Dim friendlyName As String = DocumentWriter.GetFormatFriendlyName(format)
            Dim extension As String = DocumentWriter.GetFormatFileExtension(format).ToUpper()

            Dim mf As New MyFormat(format, friendlyName, extension)

            _formatComboBox.Items.Add(mf)

            If mf.Format = initialFormat Then
               _formatComboBox.SelectedItem = mf
            ElseIf mf.Format = DocumentFormat.Pdf Then
               pdfFormat = mf
            End If

            Select Case format
               Case DocumentFormat.Pdf
                  ' Update the PDF options page
                  If True Then
                     Dim pdfOptions As PdfDocumentOptions = TryCast(_docWriter.GetOptions(DocumentFormat.Pdf), PdfDocumentOptions)

                     ' Clone it in case we change it in the Advance PDF options dialog
                     _pdfOptions = TryCast(pdfOptions.Clone(), PdfDocumentOptions)

                     Dim a As Array = [Enum].GetValues(GetType(PdfDocumentType))
                     For Each i As PdfDocumentType In a
                        _pdfDocumentTypeComboBox.Items.Add(i)
                     Next
                     _pdfDocumentTypeComboBox.SelectedItem = _pdfOptions.DocumentType

                     _pdfImageOverTextCheckBox.Checked = _pdfOptions.ImageOverText
                     _pdfLinearizedCheckBox.Checked = _pdfOptions.Linearized

                     If String.IsNullOrEmpty(_pdfOptions.Creator) Then
                        _pdfOptions.Creator = "LEADTOOLS PDFWriter"
                     End If
                     If String.IsNullOrEmpty(_pdfOptions.Producer) Then
                        _pdfOptions.Producer = "LEAD Technologies, Inc."
                     End If
                  End If
                  Exit Select

               Case DocumentFormat.Doc
                  ' Update the DOC options page
                  If True Then
                     Dim docOptions As DocDocumentOptions = TryCast(_docWriter.GetOptions(DocumentFormat.Doc), DocDocumentOptions)
                     _cbFramedDoc.Checked = If((docOptions.TextMode = DocumentTextMode.Framed), True, False)
                  End If
                  Exit Select

               Case DocumentFormat.Docx
                  ' Update the DOCX options page
                  If True Then
                     Dim docxOptions As DocxDocumentOptions = TryCast(_docWriter.GetOptions(DocumentFormat.Docx), DocxDocumentOptions)
                     _cbFramedDocX.Checked = If((docxOptions.TextMode = DocumentTextMode.Framed), True, False)
                  End If
                  Exit Select

               Case DocumentFormat.Rtf
                  ' Update the RTF options page
                  If True Then
                     Dim rtfOptions As RtfDocumentOptions = TryCast(_docWriter.GetOptions(DocumentFormat.Rtf), RtfDocumentOptions)
                     _cbFramedRtf.Checked = If((rtfOptions.TextMode = DocumentTextMode.Framed), True, False)
                  End If
                  Exit Select

               Case DocumentFormat.Html
                  ' Update the HTML options page
                  If True Then
                     Dim htmlOptions As HtmlDocumentOptions = TryCast(_docWriter.GetOptions(DocumentFormat.Html), HtmlDocumentOptions)

                     Dim a As Array = [Enum].GetValues(GetType(DocumentFontEmbedMode))
                     For Each i As DocumentFontEmbedMode In a
                        _htmlEmbedFontModeComboBox.Items.Add(i)
                     Next
                     _htmlEmbedFontModeComboBox.SelectedItem = htmlOptions.FontEmbedMode

                     _htmlUseBackgroundColorCheckBox.Checked = htmlOptions.UseBackgroundColor

                     _htmlBackgroundColorValueLabel.BackColor = ConvertColor(htmlOptions.BackgroundColor)

                     _htmlBackgroundColorLabel.Enabled = _htmlUseBackgroundColorCheckBox.Checked
                     _htmlBackgroundColorValueLabel.Enabled = _htmlUseBackgroundColorCheckBox.Checked
                     _htmlBackgroundColorButton.Enabled = _htmlUseBackgroundColorCheckBox.Checked
                  End If
                  Exit Select

               Case DocumentFormat.Text
                  ' Update the TEXT options page
                  If True Then
                     Dim textOptions As TextDocumentOptions = TryCast(_docWriter.GetOptions(DocumentFormat.Text), TextDocumentOptions)

                     Dim a As Array = [Enum].GetValues(GetType(TextDocumentType))
                     For Each i As TextDocumentType In a
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
                     Dim altoXmlOptions As AltoXmlDocumentOptions = TryCast(_docWriter.GetOptions(DocumentFormat.AltoXml), AltoXmlDocumentOptions)
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

                     Dim a As Array = [Enum].GetValues(GetType(AltoXmlMeasurementUnit))
                     For Each unit As AltoXmlMeasurementUnit In a
                        _altoXmlMeasurementUnit.Items.Add(unit)
                     Next

                     _altoXmlMeasurementUnit.SelectedItem = altoXmlOptions.MeasurementUnit

                  End If
                  Exit Select

               Case DocumentFormat.Emf, DocumentFormat.Xls, DocumentFormat.Pub, DocumentFormat.Mob, DocumentFormat.Svg
                  ' These formats have no options
                  Exit Select
            End Select
         End If
      Next

      ' Remove all the tab pages
      _optionsTabControl.TabPages.Clear()

      ' If no format is selected, default to PDF
      If _formatComboBox.SelectedIndex = -1 Then
         If pdfFormat IsNot Nothing Then
            _formatComboBox.SelectedItem = pdfFormat
         Else
            _formatComboBox.SelectedIndex = -1
         End If
      End If

      _formatComboBox_SelectedIndexChanged(Me, EventArgs.Empty)

      UpdateUIState()
   End Sub

   Private Sub UpdateUIState()
      Dim mf As MyFormat = TryCast(_formatComboBox.SelectedItem, MyFormat)
      If mf Is Nothing Then
         Return
      End If

      If mf.Format = DocumentFormat.Html Then
         _htmlBackgroundColorLabel.Enabled = _htmlUseBackgroundColorCheckBox.Checked
         _htmlBackgroundColorValueLabel.Enabled = _htmlUseBackgroundColorCheckBox.Checked
         _htmlBackgroundColorButton.Enabled = _htmlUseBackgroundColorCheckBox.Checked
      End If

      _altoXmlIndentationLabel.Enabled = _altoXmlFormattedCheckBox.Checked
      _altoXmlIndentationTextBox.Enabled = _altoXmlFormattedCheckBox.Checked
   End Sub

   Public Event SelectedFormatChanged As EventHandler(Of EventArgs)
   Private Sub _formatComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles _formatComboBox.SelectedIndexChanged
      Dim mf As MyFormat = TryCast(_formatComboBox.SelectedItem, MyFormat)

      ' Show only the options page corresponding to this format
      If _optionsTabControl.TabPages.Count > 0 Then
         _optionsTabControl.TabPages.Clear()
      End If

      Select Case mf.Format
         Case DocumentFormat.Emf
            _optionsTabControl.TabPages.Add(_emfOptionsTabPage)
            Exit Select

         Case DocumentFormat.Pdf
            _optionsTabControl.TabPages.Add(_pdfOptionsTabPage)
            Exit Select

         Case DocumentFormat.Doc
            _optionsTabControl.TabPages.Add(_docOptionsTabPage)
            Exit Select

         Case DocumentFormat.Docx
            _optionsTabControl.TabPages.Add(_docxOptionsTabPage)
            Exit Select

         Case DocumentFormat.Rtf
            _optionsTabControl.TabPages.Add(_rtfOptionsTabPage)
            Exit Select

         Case DocumentFormat.Html
            _optionsTabControl.TabPages.Add(_htmlOptionsTabPage)
            Exit Select

         Case DocumentFormat.Text
            _optionsTabControl.TabPages.Add(_textOptionsTabPage)
            Exit Select

         Case DocumentFormat.Xps
            _optionsTabControl.TabPages.Add(_xpsOptionsTabPage)
            Exit Select

         Case DocumentFormat.Xls
            _optionsTabControl.TabPages.Add(_xlsOptionsTabPage)
            Exit Select

         Case DocumentFormat.Pub
            _optionsTabControl.TabPages.Add(_ePubOptionsTabPage)
            Exit Select

         Case DocumentFormat.Mob
            _optionsTabControl.TabPages.Add(_mobOptionsTabPage)
            Exit Select

         Case DocumentFormat.Svg
            _optionsTabControl.TabPages.Add(_svgOptionsTabPage)
            Exit Select

         Case DocumentFormat.AltoXml
            _optionsTabControl.TabPages.Add(_altoXmlOptionsTabPage)
            Exit Select

         Case DocumentFormat.Ltd
            _optionsTabControl.TabPages.Add(_ltdOptionsTabPage)
            Exit Select
      End Select

      _optionsTabControl.Visible = _optionsTabControl.TabPages.Count > 0

      UpdateUIState()

      RaiseEvent SelectedFormatChanged(Me, EventArgs.Empty)
   End Sub

   Private Sub _pdfDocumentTypeComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles _pdfDocumentTypeComboBox.SelectedIndexChanged
      _pdfOptions.DocumentType = CType(_pdfDocumentTypeComboBox.SelectedItem, PdfDocumentType)
      UpdateUIState()
   End Sub

   Private Sub _pdfAdvanctionOptionsButton_Click(sender As Object, e As EventArgs) Handles _pdfAdvanctionOptionsButton.Click
      Dim settings As New LTDMergeDemo.Settings()

      Using dlg As New AdvancedPdfDocumentOptionsDialog(_pdfOptions, 1, settings.AdvancedPdfOptionsSelectedTabIndex)
         dlg.ShowLinearized = False
         If dlg.ShowDialog(Me) = DialogResult.OK Then
            UpdateDocumentWriterOptions()
            settings.AdvancedPdfOptionsSelectedTabIndex = dlg.TabControl.SelectedIndex
            settings.Save()
         End If
      End Using
   End Sub

   Private Sub _htmlBackgroundColorButton_Click(sender As Object, e As EventArgs) Handles _htmlBackgroundColorButton.Click
      Using dlg As New ColorDialog()
         dlg.Color = _htmlBackgroundColorValueLabel.BackColor
         If dlg.ShowDialog(Me) = DialogResult.OK Then
            _htmlBackgroundColorValueLabel.BackColor = dlg.Color
         End If
      End Using
   End Sub

   Private Sub _htmlUseBackgroundColorCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles _htmlUseBackgroundColorCheckBox.CheckedChanged
      _htmlBackgroundColorLabel.Enabled = _htmlUseBackgroundColorCheckBox.Checked
      _htmlBackgroundColorValueLabel.Enabled = _htmlUseBackgroundColorCheckBox.Checked
      _htmlBackgroundColorButton.Enabled = _htmlUseBackgroundColorCheckBox.Checked
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

   Public Sub UpdateDocumentWriterOptions()
      ' Save the options
      Dim format As DocumentFormat = Me.SelectedDocumentFormat

      Dim settings As New LTDMergeDemo.Settings()
      settings.Format = format.ToString()

      ' Update the options
      Dim documentOptions As DocumentOptions = _docWriter.GetOptions(format)

      Select Case format
         Case DocumentFormat.Pdf
            ' Update the PDF options
            If True Then
               Dim pdfOptions As PdfDocumentOptions = TryCast(documentOptions, PdfDocumentOptions)

               pdfOptions.DocumentType = CType(_pdfDocumentTypeComboBox.SelectedItem, PdfDocumentType)
               pdfOptions.ImageOverText = _pdfImageOverTextCheckBox.Checked
               pdfOptions.Linearized = _pdfLinearizedCheckBox.Checked
               pdfOptions.PageRestriction = DocumentPageRestriction.Relaxed

               ' Description options
               pdfOptions.Title = _pdfOptions.Title
               pdfOptions.Subject = _pdfOptions.Subject
               pdfOptions.Keywords = _pdfOptions.Keywords
               pdfOptions.Author = _pdfOptions.Author
               pdfOptions.Creator = _pdfOptions.Creator
               pdfOptions.Producer = _pdfOptions.Producer

               ' Fonts options
               pdfOptions.FontEmbedMode = _pdfOptions.FontEmbedMode
               pdfOptions.Linearized = _pdfOptions.Linearized

               ' Security options
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
               Dim docOptions As DocDocumentOptions = TryCast(documentOptions, DocDocumentOptions)
               docOptions.TextMode = If((_cbFramedDoc.Checked), DocumentTextMode.Framed, DocumentTextMode.NonFramed)
            End If
            Exit Select

         Case DocumentFormat.Docx
            ' Update the DOCX options
            If True Then
               Dim docxOptions As DocxDocumentOptions = TryCast(documentOptions, DocxDocumentOptions)
               docxOptions.TextMode = If((_cbFramedDocX.Checked), DocumentTextMode.Framed, DocumentTextMode.NonFramed)
            End If
            Exit Select

         Case DocumentFormat.Rtf
            ' Update the RTF options
            If True Then
               Dim rtfOptions As RtfDocumentOptions = TryCast(documentOptions, RtfDocumentOptions)
               rtfOptions.TextMode = If((_cbFramedRtf.Checked), DocumentTextMode.Framed, DocumentTextMode.NonFramed)
            End If
            Exit Select

         Case DocumentFormat.Html
            ' Update the HTML options
            If True Then
               Dim htmlOptions As HtmlDocumentOptions = TryCast(documentOptions, HtmlDocumentOptions)
               htmlOptions.FontEmbedMode = CType(_htmlEmbedFontModeComboBox.SelectedItem, DocumentFontEmbedMode)
               htmlOptions.UseBackgroundColor = _htmlUseBackgroundColorCheckBox.Checked
               htmlOptions.BackgroundColor = ConvertColor(_htmlBackgroundColorValueLabel.BackColor)
            End If
            Exit Select

         Case DocumentFormat.Text
            ' Update the TEXT options
            If True Then
               Dim textOptions As TextDocumentOptions = TryCast(documentOptions, TextDocumentOptions)
               textOptions.DocumentType = CType(_textDocumentTypeComboBox.SelectedItem, TextDocumentType)
               textOptions.AddPageNumber = _textAddPageNumberCheckBox.Checked
               textOptions.AddPageBreak = _textAddPageBreakCheckBox.Checked
               textOptions.Formatted = _textFormattedCheckBox.Checked
            End If
            Exit Select

         Case DocumentFormat.AltoXml
            ' Update the DOCX options
            If True Then
               Dim altoXmlOptions As AltoXmlDocumentOptions = TryCast(documentOptions, AltoXmlDocumentOptions)
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
               altoXmlOptions.MeasurementUnit = CType(_altoXmlMeasurementUnit.SelectedItem, AltoXmlMeasurementUnit)
            End If
            Exit Select

         Case DocumentFormat.Emf, DocumentFormat.Xls, DocumentFormat.Pub, DocumentFormat.Mob, DocumentFormat.Svg
            ' These formats have no options
            Exit Select
      End Select

      If documentOptions IsNot Nothing Then
         _docWriter.SetOptions(format, documentOptions)
      End If

      Using ms As New MemoryStream()
         _docWriter.SaveOptions(ms)
         settings.FormatOptionsXml = Encoding.Unicode.GetString(ms.ToArray())
      End Using

      settings.Save()
   End Sub

   Public Shared Function ConvertColor(color As RasterColor) As Color
      Return RasterColorConverter.ToColor(color)
   End Function

   Public Shared Function ConvertColor(color As Color) As RasterColor
      Return RasterColorConverter.FromColor(color)
   End Function
End Class
