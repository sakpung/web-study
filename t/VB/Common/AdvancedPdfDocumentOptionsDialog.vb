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

Imports Leadtools.Document.Writer
Imports System

Partial Public Class AdvancedPdfDocumentOptionsDialog
   Inherits Form
   Private _pdfOptions As PdfDocumentOptions
   Private _totalPages As Integer
   Private _advancedPdfOptionsDefaultSelectedTabIndex As Integer = 0
   Public ShowLinearized As Boolean = True

   Public Sub New(pdfOptions As PdfDocumentOptions, totalPages As Integer, advancedPdfOptionsDefaultSelectedTabIndex As Integer)
      InitializeComponent()

      _pdfOptions = pdfOptions
      _totalPages = totalPages
      _advancedPdfOptionsDefaultSelectedTabIndex = advancedPdfOptionsDefaultSelectedTabIndex
   End Sub

   Protected Overrides Sub OnLoad(e As EventArgs)
      If Not DesignMode Then
         Dim a As Array = [Enum].GetValues(GetType(DocumentFontEmbedMode))
         For Each i As DocumentFontEmbedMode In a
            _fontEmbeddingComboBox.Items.Add(i)
         Next

         a = [Enum].GetValues(GetType(PdfDocumentEncryptionMode))
         For Each i As PdfDocumentEncryptionMode In a
            _encryptionModeComboBox.Items.Add(i)
         Next

         _fontEmbeddingComboBox.SelectedItem = _pdfOptions.FontEmbedMode
         _linearizedCheckBox.Checked = _pdfOptions.Linearized
         _linearizedCheckBox.Visible = ShowLinearized
         _titleTextBox.Text = _pdfOptions.Title
         _subjectTextBox.Text = _pdfOptions.Subject
         _authorTextBox.Text = _pdfOptions.Author
         _creatorTextBox.Text = If(String.IsNullOrEmpty(_pdfOptions.Creator), "LEADTOOLS PDFWriter", _pdfOptions.Creator)
         _producerTextBox.Text = If(String.IsNullOrEmpty(_pdfOptions.Producer), "LEAD Technologies, Inc.", _pdfOptions.Producer)
         _keywordsTextBox.Text = _pdfOptions.Keywords

         _protectedCheckBox.Checked = _pdfOptions.[Protected]
         _encryptionModeComboBox.SelectedItem = _pdfOptions.EncryptionMode
         _userPasswordTextBox.Text = _pdfOptions.UserPassword
         _ownerPasswordTextBox.Text = _pdfOptions.OwnerPassword
         _copyEnabledCheckBox.Checked = _pdfOptions.CopyEnabled
         _editEnabledCheckBox.Checked = _pdfOptions.EditEnabled
         _annotationsEnabledCheckBox.Checked = _pdfOptions.AnnotationsEnabled
         _printEnabledCheckBox.Checked = _pdfOptions.PrintEnabled
         _assemblyEnabledCheckBox.Checked = _pdfOptions.AssemblyEnabled
         _highQualityPrintEnabledCheckBox.Checked = _pdfOptions.HighQualityPrintEnabled

         ' Compression options
         a = [Enum].GetValues(GetType(OneBitImageCompressionType))
         For Each i As OneBitImageCompressionType In a
            _oneBitImageCompressionComboBox.Items.Add(i)
         Next
         _oneBitImageCompressionComboBox.SelectedItem = _pdfOptions.OneBitImageCompression

         a = [Enum].GetValues(GetType(ColoredImageCompressionType))
         For Each i As ColoredImageCompressionType In a
            _coloredImageCompressionComboBox.Items.Add(i)
         Next
         _coloredImageCompressionComboBox.SelectedItem = _pdfOptions.ColoredImageCompression

         _qualityFactorNumericUpDown.Value = _pdfOptions.QualityFactor

         a = [Enum].GetValues(GetType(DocumentImageOverTextSize))
         For Each i As DocumentImageOverTextSize In a
            _imageOverTextSizeComboBox.Items.Add(i)
         Next
         _imageOverTextSizeComboBox.SelectedItem = _pdfOptions.ImageOverTextSize

         a = [Enum].GetValues(GetType(DocumentImageOverTextMode))
         For Each i As DocumentImageOverTextMode In a
            _imageOverTextModeComboBox.Items.Add(i)
         Next
         _imageOverTextModeComboBox.SelectedItem = _pdfOptions.ImageOverTextMode

         ' Initial View Options
         a = [Enum].GetValues(GetType(PdfDocumentPageModeType))
         For Each i As PdfDocumentPageModeType In a
            _pageModeComboBox.Items.Add(i)
         Next
         _pageModeComboBox.SelectedItem = _pdfOptions.PageModeType

         a = [Enum].GetValues(GetType(PdfDocumentPageLayoutType))
         For Each i As PdfDocumentPageLayoutType In a
            _pageLayoutComboBox.Items.Add(i)
         Next
         _pageLayoutComboBox.SelectedItem = _pdfOptions.PageLayoutType

         a = [Enum].GetValues(GetType(PdfDocumentPageFitType))
         For Each i As PdfDocumentPageFitType In a
            _pageFitTypeComboBox.Items.Add(i)
         Next

         Dim predefinedZoomValues As Integer() = {25, 50, 75, 100, 125, 150, _
          200, 400, 800, 1600, 2400, 3200, _
          6400}
         For Each i As Integer In predefinedZoomValues
            _pageFitTypeComboBox.Items.Add(String.Format("{0}%", i))
         Next
         If _pdfOptions.ZoomPercent = 0 Then
            _pageFitTypeComboBox.SelectedItem = _pdfOptions.PageFitType
         Else
            For i As Integer = [Enum].GetValues(GetType(PdfDocumentPageFitType)).Length To _pageFitTypeComboBox.Items.Count - 1
               Dim pageFitType As String = TryCast(_pageFitTypeComboBox.Items(i), String)
               If Not String.IsNullOrEmpty(pageFitType) Then
                  Dim value As Double
                  Dim characterToTrim As Char() = {" "c, "%"c}
                  If Double.TryParse(pageFitType.Trim(characterToTrim), value) Then
                     If value = _pdfOptions.ZoomPercent Then
                        _pageFitTypeComboBox.SelectedIndex = i
                        Exit For
                     End If
                  End If
               End If
            Next
         End If

         If _pageFitTypeComboBox.SelectedItem Is Nothing Then
            If _pdfOptions.ZoomPercent = 0 Then
               _pageFitTypeComboBox.SelectedIndex = 0
            Else
               _pageFitTypeComboBox.Text = String.Format("{0}%", _pdfOptions.ZoomPercent)
            End If
         End If

         _initialPageNumberNumericUpDown.Maximum = _totalPages
         _initialPageNumberNumericUpDown.Value = If((_pdfOptions.InitialPageNumber <= _totalPages), _pdfOptions.InitialPageNumber, _totalPages)
         _numberOfPagesLabel.Text = String.Format("of {0}", _totalPages)
         _resizeWindowCheckBox.Checked = _pdfOptions.FitWindow
         _centerWindowCheckBox.Checked = _pdfOptions.CenterWindow

         _showDocumentTitleComboBox.Items.Add("File Name")
         _showDocumentTitleComboBox.Items.Add("Document Title")
         _showDocumentTitleComboBox.SelectedIndex = If((_pdfOptions.DisplayDocTitle), 1, 0)
         _hideMenuBarCheckBox.Checked = _pdfOptions.HideMenubar
         _hideToolBarCheckBox.Checked = _pdfOptions.HideToolbar
         _hideWindowControlsCheckBox.Checked = _pdfOptions.HideWindowUI

         UpdateUIState()

         If _advancedPdfOptionsDefaultSelectedTabIndex >= _tabControl.TabPages.Count Then
            _advancedPdfOptionsDefaultSelectedTabIndex = _tabControl.TabPages.Count - 1
         End If
         _tabControl.SelectedIndex = _advancedPdfOptionsDefaultSelectedTabIndex
      End If

      MyBase.OnLoad(e)
   End Sub

   Public ReadOnly Property TabControl() As TabControl
      Get
         Return _tabControl
      End Get
   End Property

   Private Sub UpdateUIState()
      ' Disable all controls in this dialog except the "Fast web view (Linearized)" option.
      If _pdfOptions.DocumentType = PdfDocumentType.PdfA Then
         _fontEmbeddingLabel.Enabled = False
         _fontEmbeddingComboBox.Enabled = False
         _securityGroupBox.Enabled = False
      Else
         Dim protectedDocument As Boolean = _protectedCheckBox.Checked

         _encryptionModeComboBox.Enabled = protectedDocument
         _userPasswordTextBox.Enabled = protectedDocument
         _ownerPasswordTextBox.Enabled = protectedDocument
         _permissionsGroupBox.Enabled = protectedDocument

         If protectedDocument AndAlso _encryptionModeComboBox.SelectedItem IsNot Nothing Then
            Dim encryptionMode As PdfDocumentEncryptionMode = CType(_encryptionModeComboBox.SelectedItem, PdfDocumentEncryptionMode)
            _assemblyEnabledCheckBox.Enabled = (encryptionMode = PdfDocumentEncryptionMode.RC128Bit) AndAlso Not _editEnabledCheckBox.Checked
            _highQualityPrintEnabledCheckBox.Enabled = (encryptionMode = PdfDocumentEncryptionMode.RC128Bit AndAlso _printEnabledCheckBox.Checked)
         End If
      End If

      ' Disable the image over text options if not image over text
      _imageOverTextSizeLabel.Enabled = _pdfOptions.ImageOverText
      _imageOverTextSizeComboBox.Enabled = _pdfOptions.ImageOverText
      _imageOverTextModeLabel.Enabled = _pdfOptions.ImageOverText
      _imageOverTextModeComboBox.Enabled = _pdfOptions.ImageOverText

      If _coloredImageCompressionComboBox.SelectedItem IsNot Nothing Then
         Dim coloredImageCompression As ColoredImageCompressionType = CType(_coloredImageCompressionComboBox.SelectedItem, ColoredImageCompressionType)
         If coloredImageCompression = ColoredImageCompressionType.FlateJpeg OrElse coloredImageCompression = ColoredImageCompressionType.LzwJpeg OrElse coloredImageCompression = ColoredImageCompressionType.Jpeg OrElse coloredImageCompression = ColoredImageCompressionType.FlateJpx OrElse coloredImageCompression = ColoredImageCompressionType.LzwJpx OrElse coloredImageCompression = ColoredImageCompressionType.Jpx Then
            _qualityFactorLabel.Enabled = True
            _qualityFactorNumericUpDown.Enabled = True
         Else
            _qualityFactorLabel.Enabled = False
            _qualityFactorNumericUpDown.Enabled = False
         End If
      End If
   End Sub

   Private Sub _protectedCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles _protectedCheckBox.CheckedChanged
      UpdateUIState()
   End Sub

   Private Sub _encryptionModeComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles _encryptionModeComboBox.SelectedIndexChanged
      UpdateUIState()
   End Sub

   Private Sub _okButton_Click(sender As Object, e As EventArgs) Handles _okButton.Click
      _pdfOptions.FontEmbedMode = CType(_fontEmbeddingComboBox.SelectedItem, DocumentFontEmbedMode)
      _pdfOptions.Linearized = _linearizedCheckBox.Checked
      _pdfOptions.Title = _titleTextBox.Text
      _pdfOptions.Subject = _subjectTextBox.Text
      _pdfOptions.Author = _authorTextBox.Text
      _pdfOptions.Creator = _creatorTextBox.Text
      _pdfOptions.Producer = _producerTextBox.Text
      _pdfOptions.Keywords = _keywordsTextBox.Text

      _pdfOptions.[Protected] = _protectedCheckBox.Checked
      _pdfOptions.EncryptionMode = CType(_encryptionModeComboBox.SelectedItem, PdfDocumentEncryptionMode)
      _pdfOptions.UserPassword = _userPasswordTextBox.Text
      _pdfOptions.OwnerPassword = _ownerPasswordTextBox.Text
      _pdfOptions.CopyEnabled = _copyEnabledCheckBox.Checked
      _pdfOptions.EditEnabled = _editEnabledCheckBox.Checked
      _pdfOptions.AnnotationsEnabled = _annotationsEnabledCheckBox.Checked
      _pdfOptions.PrintEnabled = _printEnabledCheckBox.Checked
      _pdfOptions.AssemblyEnabled = _assemblyEnabledCheckBox.Checked
      _pdfOptions.HighQualityPrintEnabled = _highQualityPrintEnabledCheckBox.Checked

      ' Compression options
      _pdfOptions.OneBitImageCompression = CType(_oneBitImageCompressionComboBox.SelectedItem, OneBitImageCompressionType)
      _pdfOptions.ColoredImageCompression = CType(_coloredImageCompressionComboBox.SelectedItem, ColoredImageCompressionType)
      _pdfOptions.QualityFactor = CInt(_qualityFactorNumericUpDown.Value)
      _pdfOptions.ImageOverTextSize = CType(_imageOverTextSizeComboBox.SelectedItem, DocumentImageOverTextSize)
      _pdfOptions.ImageOverTextMode = CType(_imageOverTextModeComboBox.SelectedItem, DocumentImageOverTextMode)

      ' Initial View Options
      _pdfOptions.PageModeType = CType(_pageModeComboBox.SelectedItem, PdfDocumentPageModeType)
      _pdfOptions.PageLayoutType = CType(_pageLayoutComboBox.SelectedItem, PdfDocumentPageLayoutType)
      If _pageFitTypeComboBox.SelectedIndex >= 0 AndAlso _pageFitTypeComboBox.SelectedIndex < [Enum].GetValues(GetType(PdfDocumentPageFitType)).Length Then
         ' Selected item is one of the original enum members, so just use it
         _pdfOptions.PageFitType = CType(_pageFitTypeComboBox.SelectedItem, PdfDocumentPageFitType)
         _pdfOptions.ZoomPercent = 0
      Else
         Dim pageFitType As String = _pageFitTypeComboBox.Text
         Dim value As Double
         Dim characterToTrim As Char() = {" "c, "%"c}
         If Double.TryParse(pageFitType.Trim(characterToTrim), value) Then
            _pdfOptions.ZoomPercent = value
         End If
      End If

      _pdfOptions.InitialPageNumber = CInt(_initialPageNumberNumericUpDown.Value)
      _pdfOptions.FitWindow = _resizeWindowCheckBox.Checked
      _pdfOptions.CenterWindow = _centerWindowCheckBox.Checked
      _pdfOptions.DisplayDocTitle = If((_showDocumentTitleComboBox.SelectedIndex = 1), True, False)
      _pdfOptions.HideMenubar = _hideMenuBarCheckBox.Checked
      _pdfOptions.HideToolbar = _hideToolBarCheckBox.Checked
      _pdfOptions.HideWindowUI = _hideWindowControlsCheckBox.Checked
   End Sub

   Private Sub _printEnabledCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles _printEnabledCheckBox.CheckedChanged
      UpdateUIState()
   End Sub

   Private Sub _editEnabledCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles _editEnabledCheckBox.CheckedChanged
      UpdateUIState()
   End Sub

   Private Sub _coloredImageCompressionComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles _coloredImageCompressionComboBox.SelectedIndexChanged
      UpdateUIState()
   End Sub

   Private Sub _hideMenuBarCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles _hideMenuBarCheckBox.CheckedChanged
      ' Hide Window Controls and Hide Menubar doesn't work together even on Adobe Acrobat side, so we will uncheck the other one if one of them is checked
      If _hideWindowControlsCheckBox.Checked Then
         RemoveHandler _hideWindowControlsCheckBox.CheckedChanged, AddressOf _hideWindowControlsCheckBox_CheckedChanged
         _hideWindowControlsCheckBox.Checked = False
         AddHandler _hideWindowControlsCheckBox.CheckedChanged, AddressOf _hideWindowControlsCheckBox_CheckedChanged
      End If
   End Sub

   Private Sub _hideWindowControlsCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles _hideWindowControlsCheckBox.CheckedChanged
      ' Hide Window Controls and Hide Menubar doesn't work together even on Adobe Acrobat side, so we will uncheck the other one if one of them is checked
      If _hideMenuBarCheckBox.Checked Then
         RemoveHandler _hideMenuBarCheckBox.CheckedChanged, AddressOf _hideMenuBarCheckBox_CheckedChanged
         _hideMenuBarCheckBox.Checked = False
         AddHandler _hideMenuBarCheckBox.CheckedChanged, AddressOf _hideMenuBarCheckBox_CheckedChanged
      End If
   End Sub
End Class
