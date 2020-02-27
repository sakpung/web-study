' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports System.IO

Imports Leadtools.Ocr
Imports Leadtools.Document.Writer
Imports System

Namespace OcrDemo
   Partial Public Class ConvertLdDialog
      Inherits Form
      Private _ocrDocument As IOcrDocument
      Private _docWriter As DocumentWriter
      Private _selectedInputFileName As String
      Private _selectedFormat As DocumentFormat
      Private _selectedOutputFileName As String
      Private _selectedViewDocument As Boolean
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
            Return FriendlyName & " (" & Extension.ToUpper() & ")"
         End Function
      End Class

      Public Sub New(ocrDocument As IOcrDocument, docWriter As DocumentWriter, initialFormat As DocumentFormat, initialLdFileName As String, viewDocument As Boolean)
         InitializeComponent()

         _ocrDocument = ocrDocument
         _docWriter = docWriter

         ' Get the formats
         ' This is the order of importance, show these first then the rest as they come along
         Dim importantFormats() As DocumentFormat = _
         { _
            DocumentFormat.Pdf, _
            DocumentFormat.Docx, _
            DocumentFormat.Rtf, _
            DocumentFormat.Text, _
            DocumentFormat.Doc, _
            DocumentFormat.Xls, _
            DocumentFormat.Html _
         }

         Dim formatsToAdd As List(Of DocumentFormat) = New List(Of DocumentFormat)()

         Dim temp As Array = [Enum].GetValues(GetType(DocumentFormat))
         Dim allFormats As List(Of DocumentFormat) = New List(Of DocumentFormat)()
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
            Dim addFormat As Boolean = True

            ' If this is the "User" or Engines format, only add it if the OCR engine supports them
            If format = DocumentFormat.User OrElse format = DocumentFormat.Ltd Then
               addFormat = False
            End If

            If addFormat Then
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
                        Dim pdfOptions As PdfDocumentOptions = TryCast(docWriter.GetOptions(DocumentFormat.Pdf), PdfDocumentOptions)

                        ' Clone it in case we change it in the Advance PDF options dialog
                        _pdfOptions = TryCast(pdfOptions.Clone(), PdfDocumentOptions)

                        Dim a As Array = [Enum].GetValues(GetType(PdfDocumentType))
                        For Each i As PdfDocumentType In a
                           _pdfDocumentTypeComboBox.Items.Add(i)
                        Next
                        _pdfDocumentTypeComboBox.SelectedItem = _pdfOptions.DocumentType
                        _pdfImageOverTextCheckBox.Checked = _pdfOptions.ImageOverText
                        _pdfLinearizedCheckBox.Checked = _pdfOptions.Linearized

                        If (String.IsNullOrEmpty(_pdfOptions.Creator)) Then
                           _pdfOptions.Creator = "LEADTOOLS PDFWriter"
                        End If
                        If (String.IsNullOrEmpty(_pdfOptions.Producer)) Then
                           _pdfOptions.Producer = "LEAD Technologies, Inc."
                        End If
                     End If
                     Exit Select

                  Case DocumentFormat.Doc
                     ' Update the DOC options page
                     If True Then
                        Dim docOptions As DocDocumentOptions = TryCast(docWriter.GetOptions(DocumentFormat.Doc), DocDocumentOptions)
                        _cbFramedDoc.Checked = If((docOptions.TextMode = DocumentTextMode.Framed), True, False)
                     End If
                     Exit Select

                  Case DocumentFormat.Docx
                     ' Update the DOCX options page
                     If True Then
                        Dim docxOptions As DocxDocumentOptions = TryCast(docWriter.GetOptions(DocumentFormat.Docx), DocxDocumentOptions)
                        _cbFramedDocX.Checked = If((docxOptions.TextMode = DocumentTextMode.Framed), True, False)
                     End If
                     Exit Select

                  Case DocumentFormat.Rtf
                     ' Update the RTF options page
                     If True Then
                        Dim rtfOptions As RtfDocumentOptions = TryCast(docWriter.GetOptions(DocumentFormat.Rtf), RtfDocumentOptions)
                        _cbFramedRtf.Checked = If((rtfOptions.TextMode = DocumentTextMode.Framed), True, False)
                     End If
                     Exit Select

                  Case DocumentFormat.Html
                     ' Update the HTML options page
                     If True Then
                        Dim htmlOptions As HtmlDocumentOptions = TryCast(docWriter.GetOptions(DocumentFormat.Html), HtmlDocumentOptions)

                        Dim a As Array = [Enum].GetValues(GetType(DocumentFontEmbedMode))
                        For Each i As DocumentFontEmbedMode In a
                           _htmlEmbedFontModeComboBox.Items.Add(i)
                        Next
                        _htmlEmbedFontModeComboBox.SelectedItem = htmlOptions.FontEmbedMode

                        _htmlUseBackgroundColorCheckBox.Checked = htmlOptions.UseBackgroundColor

                        _htmlBackgroundColorValueLabel.BackColor = MainForm.ConvertColor(htmlOptions.BackgroundColor)

                        _htmlBackgroundColorLabel.Enabled = _htmlUseBackgroundColorCheckBox.Checked
                        _htmlBackgroundColorValueLabel.Enabled = _htmlUseBackgroundColorCheckBox.Checked
                        _htmlBackgroundColorButton.Enabled = _htmlUseBackgroundColorCheckBox.Checked
                     End If
                     Exit Select

                  Case DocumentFormat.Text
                     ' Update the TEXT options page
                     If True Then
                        Dim textOptions As TextDocumentOptions = TryCast(docWriter.GetOptions(DocumentFormat.Text), TextDocumentOptions)

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
                        Dim altoXmlOptions As AltoXmlDocumentOptions = TryCast(docWriter.GetOptions(DocumentFormat.AltoXml), AltoXmlDocumentOptions)
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

                  Case Else
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

         _viewDocumentCheckBox.Checked = viewDocument

         _formatComboBox_SelectedIndexChanged(Me, EventArgs.Empty)

         If Not String.IsNullOrEmpty(initialLdFileName) Then
            _ldFileNameTextBox.Text = initialLdFileName
            UpdateOutputFileName()
         End If

         UpdateUIState()
      End Sub

      Public ReadOnly Property SelectedInputFileName() As String
         Get
            Return _selectedInputFileName
         End Get
      End Property

      Public ReadOnly Property SelectedFormat() As DocumentFormat
         Get
            Return _selectedFormat
         End Get
      End Property

      Public ReadOnly Property SelectedOutputFileName() As String
         Get
            Return _selectedOutputFileName
         End Get
      End Property

      Public ReadOnly Property SelectedViewDocument() As Boolean
         Get
            Return _selectedViewDocument
         End Get
      End Property

      Private Sub _ldFileNameTextBox_TextChanged(sender As Object, e As EventArgs) Handles _ldFileNameTextBox.TextChanged
         UpdateUIState()
      End Sub

      Private Sub _outputFileNameTextBox_TextChanged(sender As Object, e As EventArgs) Handles _outputFileNameTextBox.TextChanged
         UpdateUIState()
      End Sub

      Private Sub _ldFileNameBrowseButton_Click(sender As Object, e As EventArgs) Handles _ldFileNameBrowseButton.Click
         Using dlg As New OpenFileDialog()
            Dim extension As String = DocumentWriter.GetFormatFileExtension(DocumentFormat.Ltd)
            Dim friendlyName As String = DocumentWriter.GetFormatFriendlyName(DocumentFormat.Ltd)
            dlg.Filter = String.Format("{0} (*.{1})|*.{1}|All Files (*.*)|*.*", friendlyName, extension)
            dlg.DefaultExt = extension
            If dlg.ShowDialog(Me) = DialogResult.OK Then
               _ldFileNameTextBox.Text = dlg.FileName

               If _outputFileNameTextBox.Text.Trim().Length = 0 Then
                  UpdateOutputFileName()
               End If
            End If
         End Using
      End Sub

      Private Sub UpdateOutputFileName()
         Dim inputFileName As String = _ldFileNameTextBox.Text.Trim()
         Dim mf As MyFormat = TryCast(_formatComboBox.SelectedItem, MyFormat)
         Dim extension As String = DocumentWriter.GetFormatFileExtension(mf.Format)
         Dim outputFileName As String = Path.ChangeExtension(inputFileName, extension)
         _outputFileNameTextBox.Text = outputFileName
      End Sub

      Private Sub _outputFileNameBrowseButton_Click(sender As Object, e As EventArgs) Handles _outputFileNameBrowseButton.Click
         ' Show the save file dialog

         Using dlg As New SaveFileDialog()
            ' Get the selected format name and extension
            Dim mf As MyFormat = TryCast(_formatComboBox.SelectedItem, MyFormat)

            Dim extension As String = DocumentWriter.GetFormatFileExtension(mf.Format)

            dlg.Filter = String.Format("{0} (*.{1})|*.{1}|All Files (*.*)|*.*", mf.FriendlyName, extension)
            dlg.DefaultExt = extension

            If dlg.ShowDialog(Me) = DialogResult.OK Then
               _outputFileNameTextBox.Text = dlg.FileName
            End If
         End Using
      End Sub

      Private Sub _formatComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles _formatComboBox.SelectedIndexChanged
         Dim mf As MyFormat = TryCast(_formatComboBox.SelectedItem, MyFormat)

         ' Update the extension of the output file name
         ' Update the current format options tab page
         Dim fileName As String = _outputFileNameTextBox.Text
         If Not String.IsNullOrEmpty(fileName) Then
            Dim extension As String = DocumentWriter.GetFormatFileExtension(mf.Format)
            _outputFileNameTextBox.Text = Path.ChangeExtension(fileName, extension)
         End If

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
         End Select

         _optionsTabControl.Visible = _optionsTabControl.TabPages.Count > 0

         UpdateUIState()
      End Sub

      Private Sub UpdateUIState()
         _okButton.Enabled = (_outputFileNameTextBox.Text.Trim().Length > 0) AndAlso (_ldFileNameTextBox.Text.Trim().Length > 0)

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

      Private Sub _pdfDocumentTypeComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles _pdfDocumentTypeComboBox.SelectedIndexChanged
         _pdfOptions.DocumentType = CType(_pdfDocumentTypeComboBox.SelectedItem, PdfDocumentType)
         UpdateUIState()
      End Sub

      Private Sub _pdfAdvanctionOptionsButton_Click(sender As Object, e As EventArgs) Handles _pdfAdvanctionOptionsButton.Click
         Dim settings As New Settings()
         Dim tabIndex As Integer = settings.AdvancedPdfOptionsSelectedTabIndex

         Using dlg As New AdvancedPdfDocumentOptionsDialog(_pdfOptions, If((_ocrDocument IsNot Nothing AndAlso _ocrDocument.Pages IsNot Nothing), (If((_ocrDocument.Pages.Count > 0), _ocrDocument.Pages.Count, 1)), 1), tabIndex)
            dlg.ShowLinearized = False
            If dlg.ShowDialog(Me) = DialogResult.OK Then
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

      Private Sub _okButton_Click(sender As Object, e As EventArgs) Handles _okButton.Click
         ' Save the options
         Dim mf As MyFormat = TryCast(_formatComboBox.SelectedItem, MyFormat)

         ' Update the options
         Dim documentOptions As DocumentOptions = _docWriter.GetOptions(mf.Format)

         Select Case mf.Format
            Case DocumentFormat.Pdf
               ' Update the PDF options
               Dim pdfOptions As PdfDocumentOptions = TryCast(documentOptions, PdfDocumentOptions)

               pdfOptions.DocumentType = CType(_pdfDocumentTypeComboBox.SelectedItem, PdfDocumentType)
               pdfOptions.ImageOverText = _pdfImageOverTextCheckBox.Checked
               pdfOptions.Linearized = _pdfLinearizedCheckBox.Checked
               pdfOptions.PageRestriction = DocumentPageRestriction.Relaxed

               ' Description Options
               pdfOptions.Title = _pdfOptions.Title
               pdfOptions.Subject = _pdfOptions.Subject
               pdfOptions.Keywords = _pdfOptions.Keywords
               pdfOptions.Author = _pdfOptions.Author
               pdfOptions.Creator = _pdfOptions.Creator
               pdfOptions.Producer = _pdfOptions.Producer

               ' Fonts Options
               pdfOptions.FontEmbedMode = _pdfOptions.FontEmbedMode

               ' Security Options
               pdfOptions.Protected = _pdfOptions.Protected
               If pdfOptions.Protected Then
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
               Exit Select

            Case DocumentFormat.Doc
               ' Update the DOC options
               Dim docOptions As DocDocumentOptions = TryCast(documentOptions, DocDocumentOptions)
               docOptions.TextMode = If((_cbFramedDoc.Checked), DocumentTextMode.Framed, DocumentTextMode.NonFramed)
               Exit Select

            Case DocumentFormat.Docx
               ' Update the DOCX options
               Dim docxOptions As DocxDocumentOptions = TryCast(documentOptions, DocxDocumentOptions)
               docxOptions.TextMode = If((_cbFramedDocX.Checked), DocumentTextMode.Framed, DocumentTextMode.NonFramed)
               Exit Select

            Case DocumentFormat.Rtf
               ' Update the RTF options
               Dim rtfOptions As RtfDocumentOptions = TryCast(documentOptions, RtfDocumentOptions)
               rtfOptions.TextMode = If((_cbFramedRtf.Checked), DocumentTextMode.Framed, DocumentTextMode.NonFramed)
               Exit Select

            Case DocumentFormat.Html
               ' Update the HTML options
               Dim htmlOptions As HtmlDocumentOptions = TryCast(documentOptions, HtmlDocumentOptions)
               htmlOptions.FontEmbedMode = CType(_htmlEmbedFontModeComboBox.SelectedItem, DocumentFontEmbedMode)
               htmlOptions.UseBackgroundColor = _htmlUseBackgroundColorCheckBox.Checked
               htmlOptions.BackgroundColor = MainForm.ConvertColor(_htmlBackgroundColorValueLabel.BackColor)
               Exit Select

            Case DocumentFormat.Text
               ' Update the TEXT options
               Dim textOptions As TextDocumentOptions = TryCast(documentOptions, TextDocumentOptions)
               textOptions.DocumentType = CType(_textDocumentTypeComboBox.SelectedItem, TextDocumentType)
               textOptions.AddPageNumber = _textAddPageNumberCheckBox.Checked
               textOptions.AddPageBreak = _textAddPageBreakCheckBox.Checked
               textOptions.Formatted = _textFormattedCheckBox.Checked
               Exit Select

            Case DocumentFormat.AltoXml
               ' Update the ALTOXML options
               Dim altoXmlOptions As AltoXmlDocumentOptions = TryCast(documentOptions, AltoXmlDocumentOptions)
               altoXmlOptions.FileName = _altoXmlFileNameTextBox.Text
               altoXmlOptions.SoftwareCreator = _altoXmlSoftwareCreatorTextBox.Text
               altoXmlOptions.SoftwareName = _altoXmlSoftwareNameTextBox.Text
               altoXmlOptions.ApplicationDescription = _altoXmlApplicationDescriptionTextBox.Text
               altoXmlOptions.Formatted = _altoXmlFormattedCheckBox.Checked
               altoXmlOptions.Indentation = If(altoXmlOptions.Formatted, _altoXmlIndentationTextBox.Text, "")
               altoXmlOptions.Sort = _altoXmlSortCheckBox.Checked
               altoXmlOptions.PlainText = _altoXmlPlainTextCheckBox.Checked
               altoXmlOptions.ShowGlyphInfo = _altoXmlShowGlyphInfoCheckBox.Checked
               altoXmlOptions.ShowGlyphVariants = _altoXmlShowGlyphVariantsCheckBox.Checked
               altoXmlOptions.MeasurementUnit = CType(_altoXmlMeasurementUnit.SelectedItem, AltoXmlMeasurementUnit)
               Exit Select

            Case Else
               ' These formats have no options
               Exit Select
         End Select

         If documentOptions IsNot Nothing Then
            _docWriter.SetOptions(mf.Format, documentOptions)
         End If

         ' Get the save parameters
         _selectedInputFileName = _ldFileNameTextBox.Text
         _selectedFormat = mf.Format
         _selectedOutputFileName = _outputFileNameTextBox.Text
         _selectedViewDocument = _viewDocumentCheckBox.Checked
      End Sub

      Private Sub _altoXmlFormattedCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles _altoXmlFormattedCheckBox.CheckedChanged
         UpdateUIState()
      End Sub
   End Class
End Namespace
