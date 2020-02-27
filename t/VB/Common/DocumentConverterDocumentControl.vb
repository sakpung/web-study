' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Text
Imports System.Windows.Forms
Imports System.Diagnostics
Imports System.IO

Imports Leadtools
Imports Leadtools.Document.Writer
Imports Leadtools.Document
Imports Leadtools.Document.Converter

Partial Public Class DocumentConverterDocumentControl
   Inherits UserControl
   Public Sub New()
      InitializeComponent()
   End Sub

   Private _preferences As DocumentConverterPreferences
   Private _inputDocument As LEADDocument

   Private _documentFormatSelector As DocumentFormatSelector

   ' Raster formats supported by this demo
   ' You can add as many as you want here
   Private Shared ReadOnly _rasterFormats As DocumentConverterRasterFormat() = {New DocumentConverterRasterFormat() With {
      .FriendlyName = "TIFF Color",
      .BitsPerPixel = 24,
      .RasterImageFormat = RasterImageFormat.TifJpeg422,
      .Extension = "tif"
   }, New DocumentConverterRasterFormat() With {
      .FriendlyName = "TIFF B/W",
      .BitsPerPixel = 1,
      .RasterImageFormat = RasterImageFormat.CcittGroup4,
      .Extension = "tif"
   }, New DocumentConverterRasterFormat() With {
      .FriendlyName = "PDF Color with JPEG",
      .BitsPerPixel = 24,
      .RasterImageFormat = RasterImageFormat.RasPdfJpeg422,
      .Extension = "pdf"
   }, New DocumentConverterRasterFormat() With {
      .FriendlyName = "PDF Color with JPEG 2000",
      .BitsPerPixel = 24,
      .RasterImageFormat = RasterImageFormat.RasPdfJpx,
      .Extension = "pdf"
   }, New DocumentConverterRasterFormat() With {
      .FriendlyName = "PDF B/W",
      .BitsPerPixel = 1,
      .RasterImageFormat = RasterImageFormat.RasPdfG4,
      .Extension = "pdf"
   }}

   Private Sub CleanUp()
      RemoveHandler _documentFormatSelector.SelectedFormatChanged, AddressOf _documentFormatSelector_SelectedFormatChanged
      _documentFormatSelector.Dispose()
   End Sub

   ' Populate the UI from preferences
   Public Sub Populate(document As LEADDocument, preferences As DocumentConverterPreferences)
      _preferences = preferences
      _inputDocument = document

      _documentFormatSelector = New DocumentFormatSelector()
      _documentFormatSelector.Dock = DockStyle.Fill
      _outputFormatPanel.Controls.Add(_documentFormatSelector)
      _documentFormatSelector.BringToFront()

      _documentFormatSelector.SetDocumentWriter(_preferences.DocumentWriterInstance, True)

      If _preferences.OcrEngineInstance IsNot Nothing Then
         _documentFormatSelector.SetOcrEngineType(_preferences.OcrEngineInstance.EngineType)
      End If

      AddHandler _documentFormatSelector.SelectedFormatChanged, AddressOf _documentFormatSelector_SelectedFormatChanged

      For Each format As DocumentConverterRasterFormat In _rasterFormats
         _rasterImageFormatComboBox.Items.Add(format)
      Next

      ' Input ...
      If _inputDocument Is Nothing Then
         _inputDocumentFileTextBox.Text = _preferences.InputDocumentFileName
         If _preferences.LoadEmbeddedAnnotation Then
            _inputAnnotationsModeComboBox.SelectedIndex = 1
            ' Load embedded
         ElseIf Not String.IsNullOrEmpty(_preferences.InputAnnotationsFileName) Then
            _inputAnnotationsModeComboBox.SelectedIndex = 2
         Else
            ' Import from external file
            _inputAnnotationsModeComboBox.SelectedIndex = 0
         End If
         ' Do not import annotations
         _inputAnnotationsFileTextBox.Text = _preferences.InputAnnotationsFileName
      Else
         Dim documentPath As String
         Dim documentUri As Uri = _inputDocument.Uri
         If documentUri IsNot Nothing Then
            If documentUri.IsFile Then
               documentPath = documentUri.LocalPath
            Else
               documentPath = documentUri.ToString()
            End If
         Else
            documentPath = "input.ext"
         End If

         _inputDocumentFileTextBox.Text = documentPath
         _inputDocumentFileTextBox.[ReadOnly] = True
         _inputDocumentFileBrowseButton.Visible = False
         _inputAnnotationsModeLabel.Visible = False
         _inputAnnotationsModeComboBox.Visible = False
         _inputAnnotationsFileLabel.Visible = False
         _inputAnnotationsFileTextBox.Visible = False
         _inputAnnotationsFileBrowseButton.Visible = False
      End If

      ' Output ...
      If _preferences.DocumentFormat = DocumentFormat.User AndAlso _preferences.RasterImageFormat = RasterImageFormat.Unknown Then
         ' Cannot do that, lets pick PDF
         _preferences.DocumentFormat = DocumentFormat.Pdf
      End If

      _documentFormatSelector.SelectedFormat = _preferences.DocumentFormat

      For Each format As DocumentConverterRasterFormat In _rasterFormats
         If format.RasterImageFormat = _preferences.RasterImageFormat Then
            _rasterImageFormatComboBox.SelectedItem = format
            Exit For
         End If
      Next

      If _rasterImageFormatComboBox.SelectedIndex = -1 Then
         _rasterImageFormatComboBox.SelectedIndex = 0
      End If

      ' 0 = Document, 1 = Raster
      If _preferences.DocumentFormat <> DocumentFormat.User Then
         _outputFormatComboBox.SelectedIndex = 0
      Else
         _outputFormatComboBox.SelectedIndex = 1
      End If

      If _inputDocument Is Nothing OrElse _inputDocument.Uri IsNot Nothing Then
         _outputDocumentFileTextBox.Text = _preferences.OutputDocumentFileName
         _outputAnnotationsModeComboBox.SelectedIndex = CInt(_preferences.OutputAnnotationsMode)
         _outputAnnotationsFileTextBox.Text = _preferences.OutputAnnotationsFileName
      Else
         _outputDocumentFileTextBox.Text = "output.ext"
         _outputAnnotationsModeComboBox.SelectedIndex = CInt(_preferences.OutputAnnotationsMode)
         _outputAnnotationsFileTextBox.Text = _preferences.OutputAnnotationsFileName

         _outputDocumentFileTextBox.[ReadOnly] = True
         _outputDocumentFileBrowseButton.Enabled = False
         _outputAnnotationsModeComboBox.Enabled = False
      End If

      UpdateInputPages(False)
   End Sub

   ' Populate preferences from the UI
   Public Sub ApplyToPreferences()
      ' Input ...
      If _inputDocument Is Nothing Then
         _preferences.InputDocumentFileName = _inputDocumentFileTextBox.Text.Trim()
      End If

      _preferences.InputFirstPage = If(_fromPageNumericUpDown.Enabled, CInt(_fromPageNumericUpDown.Value), 1)
      _preferences.InputLastPage = If(_toPageNumericUpDown.Enabled, CInt(_toPageNumericUpDown.Value), -1)

      If _inputDocument Is Nothing Then
         If _inputAnnotationsModeComboBox.SelectedIndex = 0 Then
            ' Do not import annotations
            _preferences.LoadEmbeddedAnnotation = False
            _preferences.InputAnnotationsFileName = Nothing
         ElseIf _inputAnnotationsModeComboBox.SelectedIndex = 1 Then
            ' Load embedded
            _preferences.LoadEmbeddedAnnotation = True
            _preferences.InputAnnotationsFileName = Nothing
         Else
            ' Load from external
            _preferences.LoadEmbeddedAnnotation = False
            _preferences.InputAnnotationsFileName = _inputAnnotationsFileTextBox.Text.Trim()
         End If
      End If

      ' Output ...
      _preferences.OutputDocumentFileName = _outputDocumentFileTextBox.Text.Trim()

      ' 0 = Document, 1 = Raster
      If _outputFormatComboBox.SelectedIndex = 0 Then
         ' Get the document format
         _preferences.DocumentFormat = _documentFormatSelector.SelectedFormat
         ' Ignore the raster format
         _preferences.RasterImageFormat = RasterImageFormat.Unknown
      Else
         ' Get the raster format
         Dim rasterFormat As DocumentConverterRasterFormat = CType(_rasterImageFormatComboBox.SelectedItem, DocumentConverterRasterFormat)
         _preferences.RasterImageFormat = rasterFormat.RasterImageFormat
         _preferences.RasterImageBitsPerPixel = rasterFormat.BitsPerPixel

         ' Ignore the document format
         _preferences.DocumentFormat = DocumentFormat.User
      End If

      _preferences.OutputAnnotationsMode = CType(_outputAnnotationsModeComboBox.SelectedIndex, DocumentConverterAnnotationsMode)
      If _preferences.OutputAnnotationsMode = DocumentConverterAnnotationsMode.External Then
         _preferences.OutputAnnotationsFileName = _outputAnnotationsFileTextBox.Text.Trim()
      Else
         _preferences.OutputAnnotationsFileName = Nothing
      End If

      UpdateUIState()
   End Sub

   Public ReadOnly Property CanApplyToPreferences() As Boolean
      Get
         ' Input ...

         ' We must have a input document file
         If _inputDocument Is Nothing AndAlso String.IsNullOrEmpty(_inputDocumentFileTextBox.Text.Trim()) Then
            Return False
         End If

         ' If input annotations mode is external file, then we must have one
         ' load external file
         If _inputDocument Is Nothing AndAlso _inputAnnotationsModeComboBox.SelectedIndex = 2 AndAlso String.IsNullOrEmpty(_inputAnnotationsFileTextBox.Text.Trim()) Then
            Return False
         End If

         ' Output ...

         If String.IsNullOrEmpty(_outputDocumentFileTextBox.Text.Trim()) Then
            Return False
         End If

         ' If output annotations mode is external file, then we must have one
         If _outputAnnotationsModeComboBox.SelectedIndex = CInt(DocumentConverterAnnotationsMode.External) AndAlso String.IsNullOrEmpty(_outputAnnotationsFileTextBox.Text.Trim()) Then
            Return False
         End If

         Return True
      End Get
   End Property

   Public Event UIStateChanged As EventHandler
   Private Sub UpdateUIState()
      ' 2 = Load external file
      _inputAnnotationsFileTextBox.Enabled = (_inputAnnotationsModeComboBox.SelectedIndex = 2)
      _inputAnnotationsFileLabel.Enabled = _inputAnnotationsFileTextBox.Enabled
      _inputAnnotationsFileBrowseButton.Enabled = _inputAnnotationsFileTextBox.Enabled

      _outputAnnotationsFileTextBox.Enabled = (_outputAnnotationsModeComboBox.SelectedIndex = CInt(DocumentConverterAnnotationsMode.External))
      _outputAnnotationsFileLabel.Enabled = _outputAnnotationsFileTextBox.Enabled
      _outputAnnotationsFileBrowseButton.Enabled = _outputAnnotationsFileTextBox.Enabled

      RaiseEvent UIStateChanged(Me, EventArgs.Empty)
   End Sub

   Private Sub UpdateInputPages(reset As Boolean)
      Try
         Using wait As WaitCursor = New WaitCursor()
            Dim fileName As String = _inputDocumentFileTextBox.Text.Trim()
            If File.Exists(fileName) Then
               _preferences.InputDocumentPageCount = _preferences.RasterCodecsInstance.GetTotalPages(fileName)
            End If
         End Using
      Catch ex As Exception
         ' We do not know
         _preferences.InputDocumentPageCount = 0
         Debug.WriteLine(ex.Message)
      End Try

      ' Reset the pages
      If _preferences.InputDocumentPageCount > 0 Then
         ' We know the pages
         _fromPageNumericUpDown.Maximum = _preferences.InputDocumentPageCount
         _toPageNumericUpDown.Maximum = _preferences.InputDocumentPageCount
      Else
         ' We do not know the pages
         _fromPageNumericUpDown.Maximum = Int16.MaxValue
         _toPageNumericUpDown.Maximum = Int16.MaxValue
      End If


      If reset OrElse _preferences.InputFirstPage > _preferences.InputDocumentPageCount OrElse _preferences.InputLastPage > _preferences.InputDocumentPageCount OrElse (_preferences.InputFirstPage = 1 AndAlso (_preferences.InputLastPage = -1 OrElse _preferences.InputLastPage = _preferences.InputDocumentPageCount)) Then
         _fromPageNumericUpDown.Value = 1
         _toPageNumericUpDown.Value = Math.Max(1, Math.Max(_preferences.InputLastPage, _preferences.InputDocumentPageCount))

         _firstPageCheckBox.Checked = True
         _lastPageCheckBox.Checked = True
      Else
         _fromPageNumericUpDown.Value = _preferences.InputFirstPage
         If _preferences.InputLastPage = -1 Then
            If _preferences.InputDocumentPageCount > 0 Then
               _toPageNumericUpDown.Value = _preferences.InputDocumentPageCount
            Else
               _toPageNumericUpDown.Value = 1
            End If
         Else
            _toPageNumericUpDown.Value = _preferences.InputLastPage
         End If

         _firstPageCheckBox.Checked = False
         _lastPageCheckBox.Checked = (_preferences.InputLastPage = -1)
      End If

      UpdateActualTotalPages()
   End Sub

   Private Sub UpdateOutputDocumentExtension()
      Dim documentFileName As String = _outputDocumentFileTextBox.Text.Trim()
      If String.IsNullOrEmpty(documentFileName) Then
         Return
      End If

      Dim extension As String

      ' Get the current format
      If _outputFormatComboBox.SelectedIndex = 0 Then
         Dim format As DocumentFormat = _documentFormatSelector.SelectedFormat
         extension = DocumentWriter.GetFormatFileExtension(format)
      Else
         Dim format As DocumentConverterRasterFormat = CType(_rasterImageFormatComboBox.SelectedItem, DocumentConverterRasterFormat)
         extension = format.Extension
      End If

      Try
         documentFileName = Path.ChangeExtension(documentFileName, extension)
         _outputDocumentFileTextBox.Text = documentFileName
      Catch
      End Try
   End Sub

   Private Sub _inputDocumentFileBrowseButton_Click(sender As Object, e As EventArgs) Handles _inputDocumentFileBrowseButton.Click
      Using dlg As OpenFileDialog = New OpenFileDialog()
         dlg.Filter = "All files|*.*"
         If dlg.ShowDialog(Me) = DialogResult.OK Then
            _inputDocumentFileTextBox.Text = dlg.FileName
            UpdateInputPages(True)
         End If
      End Using
   End Sub

   Private Sub _inputDocumentFileTextBox_TextChanged(sender As Object, e As EventArgs) Handles _inputDocumentFileTextBox.TextChanged
      If (File.Exists(_inputDocumentFileTextBox.Text)) Then
         UpdateInputPages(True)
      End If
      UpdateUIState()
   End Sub

   Private Sub _inputAnnotationsModeComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles _inputAnnotationsModeComboBox.SelectedIndexChanged
      If _inputAnnotationsModeComboBox.SelectedIndex = 0 Then
         ' Do not import annotations
         ' Then nothing to export either
         _outputAnnotationsModeComboBox.SelectedIndex = CInt(DocumentConverterAnnotationsMode.None)
         _outputAnnotationsModeComboBox.Enabled = False
      Else
         _outputAnnotationsModeComboBox.Enabled = True
      End If

      UpdateUIState()
   End Sub

   Private Sub _inputAnnotationsFileBrowseButton_Click(sender As Object, e As EventArgs) Handles _inputAnnotationsFileBrowseButton.Click
      Using dlg As OpenFileDialog = New OpenFileDialog()
         dlg.Filter = "Annotation files (*.xml)|*.xml|All files|*.*"
         If dlg.ShowDialog(Me) = DialogResult.OK Then
            _inputAnnotationsFileTextBox.Text = dlg.FileName
            UpdateUIState()
         End If
      End Using
   End Sub

   Private Sub _inputAnnotationsFileTextBox_TextChanged(sender As Object, e As EventArgs) Handles _inputAnnotationsFileTextBox.TextChanged
      UpdateUIState()
   End Sub

   Private Sub _documentFormatSelector_SelectedFormatChanged(sender As Object, e As EventArgs)
      ' Change the output file extension when the document format is changed
      ' ???
      ' also disable annotations on LTD!
      UpdateOutputDocumentExtension()
   End Sub

   Private Sub _outputFormatComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles _outputFormatComboBox.SelectedIndexChanged
      ' 0 = Document, 1 = Raster
      _documentFormatSelector.Visible = (_outputFormatComboBox.SelectedIndex = 0)
      _rasterImageFormatComboBox.Visible = (_outputFormatComboBox.SelectedIndex = 1)
      UpdateOutputDocumentExtension()
   End Sub

   Private Sub _rasterImageFormatComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles _rasterImageFormatComboBox.SelectedIndexChanged
      UpdateOutputDocumentExtension()
   End Sub

   Private Sub _outputDocumentFileBrowseButton_Click(sender As Object, e As EventArgs) Handles _outputDocumentFileBrowseButton.Click
      Dim friendlyName As String
      Dim extension As String

      ' Get the current format
      If _outputFormatComboBox.SelectedIndex = 0 Then
         Dim format As DocumentFormat = _documentFormatSelector.SelectedFormat
         friendlyName = DocumentWriter.GetFormatFriendlyName(format)
         extension = DocumentWriter.GetFormatFileExtension(format)
      Else
         Dim format As DocumentConverterRasterFormat = CType(_rasterImageFormatComboBox.SelectedItem, DocumentConverterRasterFormat)
         friendlyName = format.FriendlyName
         extension = format.Extension
      End If

      Using dlg As SaveFileDialog = New SaveFileDialog()
         dlg.Filter = String.Format("{0} (*.{1}) files|*.{1}|All files|*.*", friendlyName, extension)
         dlg.DefaultExt = extension
         If dlg.ShowDialog(Me) = DialogResult.OK Then
            _outputDocumentFileTextBox.Text = dlg.FileName
            UpdateUIState()
         End If
      End Using
   End Sub

   Private Sub _outputDocumentFileTextBox_TextChanged(sender As Object, e As EventArgs) Handles _outputDocumentFileTextBox.TextChanged
      UpdateUIState()
   End Sub

   Private Sub _outputAnnotationsModeComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles _outputAnnotationsModeComboBox.SelectedIndexChanged
      UpdateUIState()
   End Sub

   Private Sub _outputAnnotationsFileTextBox_TextChanged(sender As Object, e As EventArgs) Handles _outputAnnotationsFileTextBox.TextChanged
      UpdateUIState()
   End Sub

   Private Sub _outputAnnotationsFileBrowseButton_Click(sender As Object, e As EventArgs) Handles _outputAnnotationsFileBrowseButton.Click
      Using dlg As SaveFileDialog = New SaveFileDialog()
         dlg.Filter = "Annotation files (*.xml)|*.xml|All files|*.*"
         dlg.DefaultExt = "xml"
         If dlg.ShowDialog(Me) = DialogResult.OK Then
            _outputAnnotationsFileTextBox.Text = dlg.FileName
            UpdateUIState()
         End If
      End Using
   End Sub

   Private Sub _firstPageCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles _firstPageCheckBox.CheckedChanged
      If _firstPageCheckBox.Checked Then
         _fromPageNumericUpDown.Value = 1
      End If

      _fromPageNumericUpDown.Enabled = Not _firstPageCheckBox.Checked
      UpdateActualTotalPages()
   End Sub

   Private Sub _fromPageNumericUpDown_ValueChanged(sender As Object, e As EventArgs) Handles _fromPageNumericUpDown.ValueChanged
      If _toPageNumericUpDown.Enabled AndAlso _toPageNumericUpDown.Value < _fromPageNumericUpDown.Value Then
         _toPageNumericUpDown.Value = _fromPageNumericUpDown.Value
      End If
      UpdateActualTotalPages()
   End Sub

   Private Sub _lastPageCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles _lastPageCheckBox.CheckedChanged
      If _lastPageCheckBox.Checked Then
         _toPageNumericUpDown.Value = If(_preferences.InputDocumentPageCount > 0, _preferences.InputDocumentPageCount, 1)
      End If

      _toPageNumericUpDown.Enabled = Not _lastPageCheckBox.Checked
      UpdateActualTotalPages()
   End Sub

   Private Sub _toPageNumericUpDown_ValueChanged(sender As Object, e As EventArgs) Handles _toPageNumericUpDown.ValueChanged
      If _fromPageNumericUpDown.Enabled AndAlso _fromPageNumericUpDown.Value > _toPageNumericUpDown.Value Then
         _fromPageNumericUpDown.Value = _toPageNumericUpDown.Value
      End If
      UpdateActualTotalPages()
   End Sub

   Private Sub UpdateActualTotalPages()
      If _preferences Is Nothing Then
         Return
      End If

      Dim firstPage As Integer = If((_firstPageCheckBox.Checked), 1, CInt(_fromPageNumericUpDown.Value))
      Dim lastPage As Integer = If((_lastPageCheckBox.Checked), _preferences.InputDocumentPageCount, CInt(_toPageNumericUpDown.Value))

      _documentFormatSelector.TotalPages = lastPage - firstPage + 1
   End Sub
End Class
