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
Imports Leadtools
Imports Leadtools.Demos
Imports Leadtools.Pdf

Namespace PDFDocumentDemo.LoadDocument
   Partial Public Class LoadDocumentOptionsControl
      Inherits UserControl

      Private _document As PDFDocument
      Private Shared _lastResolution As Integer = 150
      Private Shared _lastParseDocumentStructOptions As PDFParseDocumentStructureOptions = PDFParseDocumentStructureOptions.All
      Private Shared _lastParsePagesOptions As PDFParsePagesOptions = (PDFParsePagesOptions.AllIgnoreWhiteSpaces) And Not PDFParsePagesOptions.Signatures
      Private Shared _lastParseChunks As Boolean = True
      Private _resolution As Integer

      Public ReadOnly Property Resolution As Integer
         Get
            Return _resolution
         End Get
      End Property

      Private _parseDocumentStructOptions As PDFParseDocumentStructureOptions

      Public ReadOnly Property ReadDocumentStructOptions As PDFParseDocumentStructureOptions
         Get
            Return _parseDocumentStructOptions
         End Get
      End Property

      Private _parsePagesOptions As PDFParsePagesOptions

      Public ReadOnly Property ParsePagesOptions As PDFParsePagesOptions
         Get
            Return _parsePagesOptions
         End Get
      End Property

      Private _parseChunks As Boolean

      Public ReadOnly Property ParseChunks As Boolean
         Get
            Return _parseChunks
         End Get
      End Property

      Public Sub New()
         InitializeComponent()
      End Sub

      Structure ResolutionItem
         Public Name As String
         Public Value As Integer

         Public Sub New(ByVal nameStr As String, ByVal valueRes As Integer)
            Name = nameStr
            Value = valueRes
         End Sub

         Public Overrides Function ToString() As String
            Return Name
         End Function
      End Structure

      Protected Overrides Sub OnLoad(ByVal e As EventArgs)
         If Not DesignMode Then
            Dim resolutions As Integer() = {72, 96, 150, 200, 300, 600}

            For Each resolution As Integer In resolutions
               Dim item As ResolutionItem = New ResolutionItem(String.Format("{0} pixels/inch", resolution), resolution)
               _resolutionComboBox.Items.Add(item)
            Next
         End If

         MyBase.OnLoad(e)
      End Sub

      Public Sub SetDocument(ByVal document As PDFDocument)
         _document = document

         For Each item As ResolutionItem In _resolutionComboBox.Items

            If item.Value = _lastResolution Then
               _resolutionComboBox.SelectedItem = item
               Exit For
            End If
         Next

         If _resolutionComboBox.SelectedIndex = -1 Then
            _resolutionComboBox.SelectedIndex = 2
         End If

         Dim pageCount As Integer = _document.Pages.Count
         _pagesInfoLabel.Text = _pagesInfoLabel.Text.Replace("###", pageCount.ToString())
         _readBookmarksCheckBox.Checked = (_lastParseDocumentStructOptions And PDFParseDocumentStructureOptions.Bookmarks) = PDFParseDocumentStructureOptions.Bookmarks
         _readFontsCheckBox.Checked = (_lastParseDocumentStructOptions And PDFParseDocumentStructureOptions.Fonts) = PDFParseDocumentStructureOptions.Fonts
         _readInternalLinksCheckBox.Checked = (_lastParseDocumentStructOptions And PDFParseDocumentStructureOptions.InternalLinks) = PDFParseDocumentStructureOptions.InternalLinks
         _parseObjectsCheckBox.Checked = (_lastParsePagesOptions <> PDFParsePagesOptions.None)
         _parseDigitalSignaturesCheckBox.Checked = (_lastParsePagesOptions And PDFParsePagesOptions.Signatures) = PDFParsePagesOptions.Signatures
         _parseChunksCheckBox.Checked = _lastParseChunks

         If pageCount <= 50 Then
            _parseObjectsInfoLabel.Text = "Document contains 50 pages or less and this option is not needed."
            _parseChunksCheckBox.Checked = False
            _parseChunksCheckBox.Enabled = False
         End If
      End Sub

      Public Sub Apply()
         Dim resolutionItem As ResolutionItem = CType(_resolutionComboBox.SelectedItem, ResolutionItem)
         _resolution = resolutionItem.Value
         _parseDocumentStructOptions = PDFParseDocumentStructureOptions.None
         If _readBookmarksCheckBox.Checked Then _parseDocumentStructOptions = _parseDocumentStructOptions Or PDFParseDocumentStructureOptions.Bookmarks
         If _readFontsCheckBox.Checked Then _parseDocumentStructOptions = _parseDocumentStructOptions Or PDFParseDocumentStructureOptions.Fonts
         If _readInternalLinksCheckBox.Checked Then _parseDocumentStructOptions = _parseDocumentStructOptions Or PDFParseDocumentStructureOptions.InternalLinks
         _parsePagesOptions = PDFParsePagesOptions.None
         If _parseObjectsCheckBox.Checked Then _parsePagesOptions = PDFParsePagesOptions.AllIgnoreWhiteSpaces
         If Not _parseDigitalSignaturesCheckBox.Checked Then _parsePagesOptions = _parsePagesOptions And Not PDFParsePagesOptions.Signatures
         _parseChunks = _parseChunksCheckBox.Checked
         _lastResolution = _resolution
         _lastParseDocumentStructOptions = _parseDocumentStructOptions
         _lastParsePagesOptions = _parsePagesOptions
         _lastParseChunks = _parseChunks
      End Sub

      Private Sub _parseDigitalSignaturesCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _parseDigitalSignaturesCheckBox.CheckedChanged
         If _parseDigitalSignaturesCheckBox.Checked Then
            If Not HasDigitalSignatureSupport(Me) Then _parseDigitalSignaturesCheckBox.Checked = False
         End If
      End Sub

      Private Shared Function HasDigitalSignatureSupport(ByVal owner As IWin32Window) As Boolean
         Dim digitalSignatureSupportStatus As RasterExceptionCode = PDFDocument.GetDigitalSignatureSupportStatus()

         If digitalSignatureSupportStatus = RasterExceptionCode.OpenSSLDllMissing Then
            Dim message As String = "To use this feature, download the latest version of the 1.1.0 OpenSSL libraries and copy libcrypto-1_1[-x64].dll and libssl-1_1[-x64].dll to the location of the LEADTOOLS binaries folder." & Environment.NewLine & Environment.NewLine & "LEAD Precompiled and Signed OpenSSL binaries:" & Environment.NewLine & "https://www.leadtools.com/openssl/binaries" & Environment.NewLine & Environment.NewLine & "OpenSSL source code:" & Environment.NewLine & "https://www.openssl.org"
            Dim caption As String = "Download OpenSSL"
            MessageBox.Show(owner, message, caption, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
         Else
            Return True
         End If
      End Function
   End Class
End Namespace
