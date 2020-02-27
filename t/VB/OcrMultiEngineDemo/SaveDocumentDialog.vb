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
Imports System.IO

Imports Leadtools.Ocr
Imports Leadtools.Document.Writer

Namespace OcrMultiEngineDemo
   Partial Public Class SaveDocumentDialog
      Inherits Form
      Private _ocrDocument As IOcrDocument
      Private _selectedFormat As DocumentFormat
      Private _selectedFileName As String
      Private _selectedViewDocument As Boolean
      Private _pdfOptions As PdfDocumentOptions
      Private _isCustomFileName As Boolean = False
      Private _outputDir As String = String.Empty
      Private _initialFileName As String = String.Empty

      Private Class MyFormat
         Public Format As DocumentFormat
         Public FriendlyName As String

         Public Sub New(f As DocumentFormat, n As String)
            Format = f
            FriendlyName = n
         End Sub

         Public Overrides Function ToString() As String
            Return FriendlyName
         End Function
      End Class

      Private Class MyEngineFormat
         Public Format As String
         Public FriendlyName As String

         Public Sub New(f As String, n As String)
            Format = f
            FriendlyName = n
         End Sub

         Public Overrides Function ToString() As String
            Return FriendlyName
         End Function
      End Class

      Public Sub New(ocrDocument As IOcrDocument, initialFormat As DocumentFormat, initialFileName As String, isCustomFileName As Boolean, outputDir As String, viewDocument As Boolean)
         InitializeComponent()

         _ocrDocument = ocrDocument
         _outputDir = outputDir

         ' Get the formats
         ' This is the order of importance, show these first then the rest as they come along
         Dim importantFormats() As DocumentFormat =
         {
            DocumentFormat.Ltd,
            DocumentFormat.Pdf,
            DocumentFormat.Docx,
            DocumentFormat.Rtf,
            DocumentFormat.Text,
            DocumentFormat.Doc,
            DocumentFormat.Xls,
            DocumentFormat.Html
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

         Dim docWriter As DocumentWriter = _ocrDocument.Engine.DocumentWriterInstance
         Dim ocrDocumentManager As IOcrDocumentManager = _ocrDocument.Engine.DocumentManager
         Dim engineSupportedFormatNames As String() = ocrDocumentManager.GetSupportedEngineFormats()

         For Each format As DocumentFormat In formatsToAdd
            Dim addFormat As Boolean = True

            ' If this is the "User" or Engines format, only add it if the OCR engine supports them
            If format = DocumentFormat.User AndAlso engineSupportedFormatNames.Length = 0 Then
               addFormat = False
            End If

            If addFormat Then
               Dim friendlyName As String
               If format = DocumentFormat.User Then
                  friendlyName = "Engine native"
               Else
                  friendlyName = DocumentWriter.GetFormatFriendlyName(format)
               End If

               Dim mf As New MyFormat(format, friendlyName)

               _formatComboBox.Items.Add(mf)

               If mf.Format = initialFormat Then
                  _formatComboBox.SelectedItem = mf
               ElseIf mf.Format = DocumentFormat.Pdf Then
                  pdfFormat = mf
               End If
            End If

            Select Case format
               Case DocumentFormat.User
                  ' Update the User (Engine) options page
                  If True Then
                     For Each engineFormatName As String In engineSupportedFormatNames
                        Dim mef As New MyEngineFormat(engineFormatName, ocrDocumentManager.GetEngineFormatFriendlyName(engineFormatName))
                        _userFormatNameComboBox.Items.Add(mef)

                        If mef.Format = ocrDocumentManager.EngineFormat Then
                           _userFormatNameComboBox.SelectedItem = mef
                        End If
                     Next

                     If _userFormatNameComboBox.SelectedItem Is Nothing AndAlso _userFormatNameComboBox.Items.Count > 0 Then
                        _userFormatNameComboBox.SelectedIndex = 0
                     End If
                  End If
                  Exit Select

               Case DocumentFormat.Pdf
                  ' Update the PDF options page
                  If True Then
                     Dim pdfOptions As PdfDocumentOptions = TryCast(docWriter.GetOptions(DocumentFormat.Pdf), PdfDocumentOptions)

                     ' Clone it in case we change it in the Advance PDF options dialog
                     _pdfOptions = TryCast(pdfOptions.Clone(), PdfDocumentOptions)

                     Dim a As Array = [Enum].GetValues(GetType(PdfDocumentType))
                     For Each i As PdfDocumentType In a
                        ' PDFA does NOT support Arabic characters so we are not adding it in case of Arabic OCR engine.
                        If i = PdfDocumentType.PdfA AndAlso _ocrDocument.Engine.EngineType = OcrEngineType.OmniPageArabic Then
                           Continue For
                        End If

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
                        If i = TextDocumentType.Ansi Then
                           If textOptions.DocumentType = TextDocumentType.Ansi Then
                              textOptions.DocumentType = TextDocumentType.Unicode
                           End If
                           If _ocrDocument.Engine.EngineType = OcrEngineType.OmniPageArabic Then
                              Continue For
                           End If
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

               Case DocumentFormat.Ltd, DocumentFormat.Emf, DocumentFormat.Xls, DocumentFormat.Pub, DocumentFormat.Mob, DocumentFormat.Svg
                  ' These formats have no options
                  Exit Select
            End Select
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
         _initialFileName = initialFileName
         _isCustomFileName = isCustomFileName

         If Not String.IsNullOrEmpty(_outputDir) Then
            Dim trimChars As Char() = {"\"c}
            _fileNameTextBox.Text = _outputDir.TrimEnd(trimChars) + "\" + Path.GetFileName(initialFileName)
            If Not _isCustomFileName Then
               _fileNameTextBox.Text += "." + GetFileExtension(CType(_formatComboBox.SelectedItem, MyFormat).Format)
            End If
         Else
            _fileNameTextBox.Text = initialFileName
         End If

         _formatComboBox_SelectedIndexChanged(Me, EventArgs.Empty)
         UpdateUIState()
      End Sub


      Public ReadOnly Property IsCustomFileName As Boolean
         Get
            Return _isCustomFileName
         End Get
      End Property

      Public ReadOnly Property OutputDir As String
         Get
            Return _outputDir
         End Get
      End Property

      Public ReadOnly Property SelectedFormat() As DocumentFormat
         Get
            Return _selectedFormat
         End Get
      End Property

      Public ReadOnly Property SelectedFileName() As String
         Get
            Return _selectedFileName
         End Get
      End Property

      Public ReadOnly Property SelectedViewDocument() As Boolean
         Get
            Return _selectedViewDocument
         End Get
      End Property

      Private Sub _fileNameTextBox_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _fileNameTextBox.TextChanged
         UpdateUIState()
      End Sub

      Private Function GetFileExtension(format As DocumentFormat) As String
         Dim extension As String = String.Empty

         If format = DocumentFormat.User Then
            Dim mef As MyEngineFormat = TryCast(_userFormatNameComboBox.SelectedItem, MyEngineFormat)
            If mef IsNot Nothing Then
               Dim ocrDocumentManager As IOcrDocumentManager = _ocrDocument.Engine.DocumentManager
               extension = ocrDocumentManager.GetEngineFormatFileExtension(mef.Format)
            End If
         Else
            extension = DocumentWriter.GetFormatFileExtension(format)
         End If

         Return extension
      End Function

      Private Sub _browseButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _browseButton.Click
         ' Show the save file dialog

         Using dlg As New SaveFileDialog()
            ' Get the selected format name and extension
            Dim mf As MyFormat = TryCast(_formatComboBox.SelectedItem, MyFormat)

            Dim extension As String = GetFileExtension(mf.Format)

            dlg.FileName = Path.GetFileName(_fileNameTextBox.Text)
            dlg.Filter = String.Format("{0} (*.{1})|*.{1}|All Files (*.*)|*.*", mf.FriendlyName, extension)
            dlg.DefaultExt = extension

            If dlg.ShowDialog(Me) = DialogResult.OK Then
               _fileNameTextBox.Text = dlg.FileName
               _isCustomFileName = True
            End If
         End Using
      End Sub

      Private Sub _formatComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _formatComboBox.SelectedIndexChanged
         Dim mf As MyFormat = TryCast(_formatComboBox.SelectedItem, MyFormat)

         ' Update the extension of the file name
         ' Update the current format options tab page
         Dim fileName As String = _fileNameTextBox.Text
         Dim extension As String = GetFileExtension(mf.Format)

         If Not String.IsNullOrEmpty(fileName) Then
            If fileName.Equals(_initialFileName) And Not _isCustomFileName Then
               _fileNameTextBox.Text += "." + extension
            Else
               _fileNameTextBox.Text = Path.ChangeExtension(fileName, extension)
            End If
         End If


         ' Show only the options page corresponding to this format
         If _optionsTabControl.TabPages.Count > 0 Then
            _optionsTabControl.TabPages.Clear()
         End If

         Select Case mf.Format
            Case DocumentFormat.Ltd
               _optionsTabControl.TabPages.Add(_ldOptionsTabPage)
               Exit Select

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

            Case DocumentFormat.User
               _optionsTabControl.TabPages.Add(_userOptionsTabPage)
               Exit Select

            Case DocumentFormat.AltoXml
               _optionsTabControl.TabPages.Add(_altoXmlOptionsTabPage)
               Exit Select
         End Select

         _optionsTabControl.Visible = _optionsTabControl.TabPages.Count > 0

         UpdateUIState()
      End Sub

      Private Sub UpdateUIState()
         _okButton.Enabled = _fileNameTextBox.Text.Trim().Length > 0

         Dim mf As MyFormat = TryCast(_formatComboBox.SelectedItem, MyFormat)
         If mf Is Nothing Then
            Return
         End If

         If mf.Format = DocumentFormat.Ltd Then
            _viewDocumentCheckBox.Checked = False
            _viewDocumentCheckBox.Enabled = False

            _viewDocumentCheckBox.Enabled = False
         Else
            If mf.Format = DocumentFormat.Html Then
               _htmlBackgroundColorLabel.Enabled = _htmlUseBackgroundColorCheckBox.Checked
               _htmlBackgroundColorValueLabel.Enabled = _htmlUseBackgroundColorCheckBox.Checked
               _htmlBackgroundColorButton.Enabled = _htmlUseBackgroundColorCheckBox.Checked
            End If

            _viewDocumentCheckBox.Enabled = True
         End If

         _altoXmlIndentationLabel.Enabled = _altoXmlFormattedCheckBox.Checked
         _altoXmlIndentationTextBox.Enabled = _altoXmlFormattedCheckBox.Checked
      End Sub

      Private Sub _htmlBackgroundColorButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _htmlBackgroundColorButton.Click
         Using dlg As New ColorDialog()
            dlg.Color = _htmlBackgroundColorValueLabel.BackColor
            If dlg.ShowDialog(Me) = DialogResult.OK Then
               _htmlBackgroundColorValueLabel.BackColor = dlg.Color
            End If
         End Using
      End Sub

      Private Sub _userFormatNameComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _userFormatNameComboBox.SelectedIndexChanged
         ' Update the extension of the file name
         ' Update the current format options tab page
         Dim fileName As String = _fileNameTextBox.Text
         If Not String.IsNullOrEmpty(fileName) Then
            Dim extension As String = GetFileExtension(DocumentFormat.User)
            _fileNameTextBox.Text = Path.ChangeExtension(fileName, extension)
         End If

         UpdateUIState()
      End Sub

      Private Sub _pdfDocumentTypeComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _pdfDocumentTypeComboBox.SelectedIndexChanged
         _pdfOptions.DocumentType = CType(_pdfDocumentTypeComboBox.SelectedItem, PdfDocumentType)
         UpdateUIState()
      End Sub

      Private Sub _pdfAdvanctionOptionsButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _pdfAdvanctionOptionsButton.Click
         Dim tabIndex As Integer = My.Settings.AdvancedPdfOptionsSelectedTabIndex
         Using dlg As New AdvancedPdfDocumentOptionsDialog(_pdfOptions, If((_ocrDocument IsNot Nothing AndAlso _ocrDocument.Pages IsNot Nothing), (If((_ocrDocument.Pages.Count > 0), _ocrDocument.Pages.Count, 1)), 1), tabIndex)
            dlg.ShowLinearized = False
            If dlg.ShowDialog(Me) = DialogResult.OK Then
               My.Settings.AdvancedPdfOptionsSelectedTabIndex = dlg.TabControl.SelectedIndex
               My.Settings.Save()
            End If
         End Using
      End Sub

      Private Sub _htmlUseBackgroundColorCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _htmlUseBackgroundColorCheckBox.CheckedChanged
         _htmlBackgroundColorLabel.Enabled = _htmlUseBackgroundColorCheckBox.Checked
         _htmlBackgroundColorValueLabel.Enabled = _htmlUseBackgroundColorCheckBox.Checked
         _htmlBackgroundColorButton.Enabled = _htmlUseBackgroundColorCheckBox.Checked
      End Sub

      Private Sub _okButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _okButton.Click
         Dim docWriter As DocumentWriter = _ocrDocument.Engine.DocumentWriterInstance
         Dim ocrDocumentManager As IOcrDocumentManager = _ocrDocument.Engine.DocumentManager

         ' Save the options
         Dim mf As MyFormat = TryCast(_formatComboBox.SelectedItem, MyFormat)

         Dim documentOptions As DocumentOptions
         If mf.Format <> DocumentFormat.User Then
            documentOptions = docWriter.GetOptions(mf.Format)
         Else
            documentOptions = Nothing
         End If

         Select Case mf.Format
            Case DocumentFormat.User
               ' Update the User (Engine) options
               Dim mef As MyEngineFormat = TryCast(_userFormatNameComboBox.SelectedItem, MyEngineFormat)
               ocrDocumentManager.EngineFormat = mef.Format
               Exit Select

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
               ' Update the DOC options
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
               altoXmlOptions.Indentation = _altoXmlIndentationTextBox.Text
               altoXmlOptions.Sort = _altoXmlSortCheckBox.Checked
               altoXmlOptions.PlainText = _altoXmlPlainTextCheckBox.Checked
               altoXmlOptions.ShowGlyphInfo = _altoXmlShowGlyphInfoCheckBox.Checked
               altoXmlOptions.ShowGlyphVariants = _altoXmlShowGlyphVariantsCheckBox.Checked
               altoXmlOptions.MeasurementUnit = CType(_altoXmlMeasurementUnit.SelectedItem, AltoXmlMeasurementUnit)
               Exit Select

            Case DocumentFormat.Ltd, DocumentFormat.Emf, DocumentFormat.Xls, DocumentFormat.Pub, DocumentFormat.Mob, DocumentFormat.Svg
               ' These formats have no options
               Exit Select
         End Select

         If documentOptions IsNot Nothing Then
            docWriter.SetOptions(mf.Format, documentOptions)
         End If

         ' Get the save parameters
         _selectedFileName = _fileNameTextBox.Text
         _selectedFormat = mf.Format
         _selectedViewDocument = _viewDocumentCheckBox.Checked

         If _isCustomFileName Then
            _outputDir = Path.GetDirectoryName(SelectedFileName)
         End If
      End Sub

      Private Sub _pdfImageOverTextCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles _pdfImageOverTextCheckBox.CheckedChanged
         _pdfOptions.ImageOverText = _pdfImageOverTextCheckBox.Checked
      End Sub

      Private Sub _pdfLinearizedCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles _pdfLinearizedCheckBox.CheckedChanged
         _pdfOptions.Linearized = _pdfLinearizedCheckBox.Checked
      End Sub

      Private Sub _altoXmlFormattedCheckBox_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles _altoXmlFormattedCheckBox.CheckedChanged
         UpdateUIState()
      End Sub
   End Class
End Namespace
