' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System.IO

Imports Leadtools.Ocr
Imports Leadtools.Document.Writer

Public Class ConvertLdDialog
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

      Public Sub New(ByVal f As DocumentFormat, ByVal n As String, ByVal e As String)
         Format = f
         FriendlyName = n
         Extension = e
      End Sub

      Public Overrides Function ToString() As String
         Return FriendlyName + " (" + Extension.ToUpper() + ")"
      End Function
   End Class

   Public Sub New(ByVal ocrDocument As IOcrDocument, ByVal docWriter As DocumentWriter, ByVal initialFormat As DocumentFormat, ByVal initialLdFileName As String, ByVal viewDocument As Boolean)
      ' This call is required by the Windows Form Designer.
      InitializeComponent()

      _ocrDocument = ocrDocument
      _docWriter = docWriter

      ' Get the formats
      ' This is the order of importance, show these first then the rest as they come along
      Dim importantFormats() As DocumentFormat =
      {
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
                  Dim pdfOptions As PdfDocumentOptions = CType(docWriter.GetOptions(DocumentFormat.Pdf), PdfDocumentOptions)

                  ' Clone it in case we change it in the Advance PDF options dialog
                  _pdfOptions = CType(pdfOptions.Clone(), PdfDocumentOptions)

                  Dim a As Array = System.Enum.GetValues(GetType(PdfDocumentType))
                  For Each i As PdfDocumentType In a
                     ' PDFA does NOT support Arabic characters so we are not adding it in case of Arabic OCR engine.
                     If _ocrDocument.Engine.EngineType = OcrEngineType.OmniPageArabic And i = PdfDocumentType.PdfA Then
                        Continue For
                     End If
                     _pdfDocumentTypeComboBox.Items.Add(i)
                  Next
                  _pdfDocumentTypeComboBox.SelectedItem = pdfOptions.DocumentType
                  _pdfImageOverTextCheckBox.Checked = _pdfOptions.ImageOverText
                  _pdfLinearizedCheckBox.Checked = _pdfOptions.Linearized

                  If (String.IsNullOrEmpty(_pdfOptions.Creator)) Then
                     _pdfOptions.Creator = "LEADTOOLS PDFWriter"
                  End If
                  If (String.IsNullOrEmpty(_pdfOptions.Producer)) Then
                     _pdfOptions.Producer = "LEAD Technologies, Inc."
                  End If

               Case DocumentFormat.Doc
                  ' Update the DOC options page
                  Dim docOptions As DocDocumentOptions = CType(docWriter.GetOptions(DocumentFormat.Doc), DocDocumentOptions)
                  _cbFramedDoc.Checked = If((docOptions.TextMode = DocumentTextMode.Framed), True, False)

               Case DocumentFormat.Docx
                  ' Update the DOCX options page
                  Dim docxOptions As DocxDocumentOptions = CType(docWriter.GetOptions(DocumentFormat.Docx), DocxDocumentOptions)
                  _cbFramedDocX.Checked = If((docxOptions.TextMode = DocumentTextMode.Framed), True, False)

               Case DocumentFormat.Rtf
                  ' Update the RTF options page
                  Dim rtfOptions As RtfDocumentOptions = CType(docWriter.GetOptions(DocumentFormat.Rtf), RtfDocumentOptions)
                  _cbFramedRtf.Checked = If((rtfOptions.TextMode = DocumentTextMode.Framed), True, False)

               Case DocumentFormat.Html
                  ' Update the HTML options page
                  Dim htmlOptions As HtmlDocumentOptions = CType(docWriter.GetOptions(DocumentFormat.Html), HtmlDocumentOptions)

                  Dim a As Array = System.Enum.GetValues(GetType(DocumentFontEmbedMode))
                  For Each i As DocumentFontEmbedMode In a
                     _htmlEmbedFontModeComboBox.Items.Add(i)
                  Next
                  _htmlEmbedFontModeComboBox.SelectedItem = htmlOptions.FontEmbedMode

                  _htmlUseBackgroundColorCheckBox.Checked = htmlOptions.UseBackgroundColor

                  _htmlBackgroundColorValueLabel.BackColor = MainForm.ConvertColor(htmlOptions.BackgroundColor)

                  _htmlBackgroundColorLabel.Enabled = _htmlUseBackgroundColorCheckBox.Checked
                  _htmlBackgroundColorValueLabel.Enabled = _htmlUseBackgroundColorCheckBox.Checked
                  _htmlBackgroundColorButton.Enabled = _htmlUseBackgroundColorCheckBox.Checked

               Case DocumentFormat.Text
                  ' Update the TEXT options page
                  Dim textOptions As TextDocumentOptions = CType(docWriter.GetOptions(DocumentFormat.Text), TextDocumentOptions)

                  Dim a As Array = System.Enum.GetValues(GetType(TextDocumentType))
                  For Each i As TextDocumentType In a
                     If (i = TextDocumentType.Ansi) Then
                        If (textOptions.DocumentType = TextDocumentType.Ansi) Then
                           textOptions.DocumentType = TextDocumentType.Unicode
                        End If

                        If (_ocrDocument.Engine.EngineType = OcrEngineType.OmniPageArabic) Then
                           Continue For
                        End If
                     End If
                     _textDocumentTypeComboBox.Items.Add(i)
                  Next
                  _textDocumentTypeComboBox.SelectedItem = textOptions.DocumentType

                  _textAddPageNumberCheckBox.Checked = textOptions.AddPageNumber
                  _textAddPageBreakCheckBox.Checked = textOptions.AddPageBreak
                  _textFormattedCheckBox.Checked = textOptions.Formatted

               Case DocumentFormat.AltoXml
                  ' Update the ALTOXML options page
                  Dim altoXmlOptions As AltoXmlDocumentOptions = CType(docWriter.GetOptions(DocumentFormat.AltoXml), AltoXmlDocumentOptions)
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
               Case DocumentFormat.Emf
               Case DocumentFormat.Xls
               Case DocumentFormat.Pub
               Case DocumentFormat.Mob
               Case DocumentFormat.Svg
                  ' These formats have no options
            End Select
         End If
      Next

      ' Remove all the tab pages
      _optionsTabControl.TabPages.Clear()

      ' If no format is selected, default to PDF
      If _formatComboBox.SelectedIndex = -1 Then
         If Not IsNothing(pdfFormat) Then
            _formatComboBox.SelectedItem = pdfFormat
         Else
            _formatComboBox.SelectedIndex = -1
         End If
      End If

      _viewDocumentCheckBox.Checked = viewDocument

      _formatComboBox_SelectedIndexChanged(Me, EventArgs.Empty)

      If Not (String.IsNullOrEmpty(initialLdFileName)) Then
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

   Private Sub _ldFileNameTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _ldFileNameTextBox.TextChanged
      UpdateUIState()
   End Sub

   Private Sub _outputFileNameTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _outputFileNameTextBox.TextChanged
      UpdateUIState()
   End Sub

   Private Sub _ldFileNameBrowseButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _ldFileNameBrowseButton.Click
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
      Dim mf As MyFormat = CType(_formatComboBox.SelectedItem, MyFormat)
      Dim extension As String = DocumentWriter.GetFormatFileExtension(mf.Format)
      Dim outputFileName As String = Path.ChangeExtension(inputFileName, extension)
      _outputFileNameTextBox.Text = outputFileName
   End Sub

   Private Sub _outputFileNameBrowseButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _outputFileNameBrowseButton.Click
      ' Show the save file dialog

      Using dlg As New SaveFileDialog()
         ' Get the selected format name and extension
         Dim mf As MyFormat = CType(_formatComboBox.SelectedItem, MyFormat)

         Dim extension As String = DocumentWriter.GetFormatFileExtension(mf.Format)

         dlg.Filter = String.Format("{0} (*.{1})|*.{1}|All Files (*.*)|*.*", mf.FriendlyName, extension)
         dlg.DefaultExt = extension

         If dlg.ShowDialog(Me) = DialogResult.OK Then
            _outputFileNameTextBox.Text = dlg.FileName
         End If
      End Using
   End Sub

   Private Sub _formatComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _formatComboBox.SelectedIndexChanged
      Dim mf As MyFormat = CType(_formatComboBox.SelectedItem, MyFormat)

      ' Update the extension of the output file name
      ' Update the current format options tab page
      Dim fileName As String = _outputFileNameTextBox.Text
      If Not (String.IsNullOrEmpty(fileName)) Then
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

         Case DocumentFormat.Pdf
            _optionsTabControl.TabPages.Add(_pdfOptionsTabPage)

         Case DocumentFormat.Doc
            _optionsTabControl.TabPages.Add(_docOptionsTabPage)

         Case DocumentFormat.Rtf
            _optionsTabControl.TabPages.Add(_rtfOptionsTabPage)

         Case DocumentFormat.Html
            _optionsTabControl.TabPages.Add(_htmlOptionsTabPage)

         Case DocumentFormat.Text
            _optionsTabControl.TabPages.Add(_textOptionsTabPage)

         Case DocumentFormat.Xps
            _optionsTabControl.TabPages.Add(_xpsOptionsTabPage)

         Case DocumentFormat.Docx
            _optionsTabControl.TabPages.Add(_docxOptionsTabPage)

         Case DocumentFormat.AltoXml
            _optionsTabControl.TabPages.Add(_altoXmlOptionsTabPage)

         Case DocumentFormat.Xls
            _optionsTabControl.TabPages.Add(_xlsOptionsTabPage)

         Case DocumentFormat.Pub
            _optionsTabControl.TabPages.Add(_ePubOptionsTabPage)

         Case DocumentFormat.Mob
            _optionsTabControl.TabPages.Add(_mobOptionsTabPage)

         Case DocumentFormat.Svg
            _optionsTabControl.TabPages.Add(_svgOptionsTabPage)
      End Select

      _optionsTabControl.Visible = (_optionsTabControl.TabPages.Count > 0)

      UpdateUIState()
   End Sub

   Private Sub UpdateUIState()
      _okButton.Enabled = (_outputFileNameTextBox.Text.Trim().Length > 0) AndAlso (_ldFileNameTextBox.Text.Trim().Length > 0)

      Dim mf As MyFormat = CType(_formatComboBox.SelectedItem, MyFormat)
      If mf Is Nothing Then
         Exit Sub
      End If

      If mf.Format = DocumentFormat.Html Then
         _htmlBackgroundColorLabel.Enabled = _htmlUseBackgroundColorCheckBox.Checked
         _htmlBackgroundColorValueLabel.Enabled = _htmlUseBackgroundColorCheckBox.Checked
         _htmlBackgroundColorButton.Enabled = _htmlUseBackgroundColorCheckBox.Checked
      End If

      _altoXmlIndentationLabel.Enabled = _altoXmlFormattedCheckBox.Checked
      _altoXmlIndentationTextBox.Enabled = _altoXmlFormattedCheckBox.Checked
   End Sub

   Private Sub _pdfDocumentTypeComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _pdfDocumentTypeComboBox.SelectedIndexChanged
      _pdfOptions.DocumentType = CType(_pdfDocumentTypeComboBox.SelectedItem, PdfDocumentType)
      UpdateUIState()
   End Sub

   Private Sub _pdfAdvanctionOptionsButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _pdfAdvanctionOptionsButton.Click
      Dim tabIndex As Integer = My.Settings.AdvancedPdfOptionsSelectedTabIndex
      Using dlg As New AdvancedPdfDocumentOptionsDialog(_pdfOptions, If((_ocrDocument IsNot Nothing AndAlso _ocrDocument.Pages IsNot Nothing), (If((_ocrDocument.Pages.Count > 0), _ocrDocument.Pages.Count, 1)), 1), tabIndex)
         dlg.ShowLinearized = False
         If dlg.ShowDialog(Me) = DialogResult.OK Then
            My.Settings.AdvancedPdfOptionsSelectedTabIndex = dlg.TabControl.SelectedIndex
            My.Settings.Save()
         End If
      End Using
   End Sub

   Private Sub _htmlBackgroundColorButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _htmlBackgroundColorButton.Click
      Using dlg As New ColorDialog()
         dlg.Color = _htmlBackgroundColorValueLabel.BackColor
         If dlg.ShowDialog(Me) = DialogResult.OK Then
            _htmlBackgroundColorValueLabel.BackColor = dlg.Color
         End If
      End Using
   End Sub

   Private Sub _htmlUseBackgroundColorCheckBox_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _htmlUseBackgroundColorCheckBox.CheckedChanged
      _htmlBackgroundColorLabel.Enabled = _htmlUseBackgroundColorCheckBox.Checked
      _htmlBackgroundColorValueLabel.Enabled = _htmlUseBackgroundColorCheckBox.Checked
      _htmlBackgroundColorButton.Enabled = _htmlUseBackgroundColorCheckBox.Checked
   End Sub

   Private Sub _okButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _okButton.Click
      ' Save the options
      Dim mf As MyFormat = CType(_formatComboBox.SelectedItem, MyFormat)

      ' Update the options
      Dim options As DocumentOptions = _docWriter.GetOptions(mf.Format)

      Select Case mf.Format
         Case DocumentFormat.Pdf
            ' Update the PDF options
            Dim pdfOptions As PdfDocumentOptions = CType(options, PdfDocumentOptions)

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
            pdfOptions.Linearized = _pdfOptions.Linearized

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
            Dim docOptions As DocDocumentOptions = CType(options, DocDocumentOptions)
            docOptions.TextMode = If((_cbFramedDoc.Checked), DocumentTextMode.Framed, DocumentTextMode.NonFramed)
            Exit Select

         Case DocumentFormat.Docx
            ' Update the DOCX options page
            Dim docxOptions As DocxDocumentOptions = CType(options, DocxDocumentOptions)
            docxOptions.TextMode = If((_cbFramedDocX.Checked), DocumentTextMode.Framed, DocumentTextMode.NonFramed)
            Exit Select

         Case DocumentFormat.Rtf
            ' Update the RTF options
            Dim rtfOptions As RtfDocumentOptions = CType(options, RtfDocumentOptions)
            rtfOptions.TextMode = If((_cbFramedRtf.Checked), DocumentTextMode.Framed, DocumentTextMode.NonFramed)
            Exit Select

         Case DocumentFormat.Html
            ' Update the HTML options
            Dim htmlOptions As HtmlDocumentOptions = CType(options, HtmlDocumentOptions)
            htmlOptions.FontEmbedMode = CType(_htmlEmbedFontModeComboBox.SelectedItem, DocumentFontEmbedMode)
            htmlOptions.UseBackgroundColor = _htmlUseBackgroundColorCheckBox.Checked
            htmlOptions.BackgroundColor = MainForm.ConvertColor(_htmlBackgroundColorValueLabel.BackColor)
            Exit Select

         Case DocumentFormat.Text
            ' Update the TEXT options
            Dim textOptions As TextDocumentOptions = CType(options, TextDocumentOptions)
            textOptions.DocumentType = CType(_textDocumentTypeComboBox.SelectedItem, TextDocumentType)
            textOptions.AddPageNumber = _textAddPageNumberCheckBox.Checked
            textOptions.AddPageBreak = _textAddPageBreakCheckBox.Checked
            textOptions.Formatted = _textFormattedCheckBox.Checked
            Exit Select

         Case DocumentFormat.AltoXml
            ' Update the ALTOXML options page
            Dim altoXmlOptions As AltoXmlDocumentOptions = CType(options, AltoXmlDocumentOptions)
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

         Case DocumentFormat.Emf
         Case DocumentFormat.Xls
         Case DocumentFormat.Pub
         Case DocumentFormat.Mob
         Case DocumentFormat.Svg
            ' This format have no options
            Exit Select
      End Select

      If Not IsNothing(options) Then
         _docWriter.SetOptions(mf.Format, options)
      End If

      ' Get the save parameters
      _selectedInputFileName = _ldFileNameTextBox.Text
      _selectedFormat = mf.Format
      _selectedOutputFileName = _outputFileNameTextBox.Text
      _selectedViewDocument = _viewDocumentCheckBox.Checked
   End Sub

   Private Sub _pdfImageOverTextCheckBox_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles _pdfImageOverTextCheckBox.CheckedChanged
      _pdfOptions.ImageOverText = _pdfImageOverTextCheckBox.Checked
   End Sub

   Private Sub _pdfLinearizedCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles _pdfLinearizedCheckBox.CheckedChanged
      _pdfOptions.Linearized = _pdfLinearizedCheckBox.Checked
   End Sub

   Private Sub _altoXmlFormattedCheckBox_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles _altoXmlFormattedCheckBox.CheckedChanged
      UpdateUIState()
   End Sub
End Class
