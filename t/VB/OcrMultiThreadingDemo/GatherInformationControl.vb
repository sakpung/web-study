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
Imports System.Security.AccessControl
Imports System.Windows.Forms
Imports System.IO

Imports Leadtools
Imports Leadtools.Ocr
Imports Leadtools.Document.Writer

Namespace OcrMultiThreadingDemo
   Partial Public Class GatherInformationControl
      Inherits UserControl
      Private _ocrEngineType As OcrEngineType
      Private _totalPages As Integer

      Public Sub New()
         InitializeComponent()
      End Sub

      Public Sub Init(ocrEngineType As OcrEngineType, docWriter As DocumentWriter, options As DemoOptions, totalPages As Integer)
         _ocrEngineType = ocrEngineType
         _totalPages = totalPages

         SetDocumentWriterOptions(docWriter)
         _documentFormatSelector.SetDocumentWriter(docWriter, True)
         _documentFormatSelector.SetOcrEngineType(_ocrEngineType)

         InitFormats()

         LoadSettings(options)

         UpdateMyControls()
      End Sub

      Private Sub SetDocumentWriterOptions(docWriter As DocumentWriter)
         Dim docOptions As DocDocumentOptions = TryCast(docWriter.GetOptions(DocumentFormat.Doc), DocDocumentOptions)
         docOptions.TextMode = DocumentTextMode.Framed

         Dim docxOptions As DocxDocumentOptions = TryCast(docWriter.GetOptions(DocumentFormat.Docx), DocxDocumentOptions)
         docxOptions.TextMode = DocumentTextMode.Framed

         Dim rtfOptions As RtfDocumentOptions = TryCast(docWriter.GetOptions(DocumentFormat.Rtf), RtfDocumentOptions)
         rtfOptions.TextMode = DocumentTextMode.Framed

         Dim altoXmlOptions As AltoXmlDocumentOptions = TryCast(docWriter.GetOptions(DocumentFormat.AltoXml), AltoXmlDocumentOptions)
         altoXmlOptions.Formatted = True
      End Sub

      Private Sub InitFormats()
         _documentFormatSelector.SelectedFormat = DocumentFormat.Pdf
      End Sub

      Private Sub SelectFormatByName(name As String)
         Dim format As DocumentFormat = DocumentFormat.Pdf
         Try
            format = CType([Enum].Parse(GetType(DocumentFormat), name), DocumentFormat)
         Catch
         End Try

         _documentFormatSelector.SelectedFormat = format
      End Sub

      Private Sub LoadSettings(options As DemoOptions)
         _tbSourceDirectory.Text = If(options.SourceDirectory IsNot Nothing, options.SourceDirectory.Trim(), String.Empty)
         _tbFilter.Text = If(options.SourceFilter IsNot Nothing, options.SourceFilter.Trim(), String.Empty)
         _tbDestinationDirectory.Text = If(options.DestinationDirectory IsNot Nothing, options.DestinationDirectory.Trim(), String.Empty)

         Dim formatName As String = options.DestinationDocumentFormat.ToString()
         SelectFormatByName(formatName)

         If String.IsNullOrEmpty(_tbSourceDirectory.Text) Then
            _tbSourceDirectory.Text = Path.GetFullPath(DemosGlobal.ImagesFolder)
         End If

         If String.IsNullOrEmpty(_tbDestinationDirectory.Text) Then
            _tbDestinationDirectory.Text = Path.Combine(Path.GetFullPath(DemosGlobal.ImagesFolder), "MultiThreadedDemoImages")
         End If

         If String.IsNullOrEmpty(_tbFilter.Text) Then
            _tbFilter.Text = "*.tif"
         End If
      End Sub

      Public Sub SaveSettings()
         ' Save the last setting
         Dim options As New DemoOptions()
         options.OcrEngineType = _ocrEngineType
         options.SourceDirectory = _tbSourceDirectory.Text.Trim()
         options.SourceFilter = _tbFilter.Text.Trim()
         options.DestinationDirectory = _tbDestinationDirectory.Text.Trim()
         options.DestinationDocumentFormat = _documentFormatSelector.SelectedFormat

         options.SaveDefault()
      End Sub

      Private Sub UpdateMyControls()
         _btnGo.Enabled = _tbSourceDirectory.Text.Trim() <> String.Empty AndAlso _tbFilter.Text.Trim() <> String.Empty AndAlso _tbDestinationDirectory.Text.Trim() <> String.Empty
      End Sub

      Private Sub _tb_TextChanged(sender As Object, e As EventArgs) Handles _tbDestinationDirectory.TextChanged, _tbFilter.TextChanged, _tbSourceDirectory.TextChanged
         UpdateMyControls()
      End Sub

      Private Sub _btnSourceDirectoryBrowse_Click(sender As Object, e As EventArgs) Handles _btnSourceDirectoryBrowse.Click
         _tbSourceDirectory.Text = BrowseToFolder(_tbSourceDirectory.Text.Trim(), "Select the source directory", False)
      End Sub

      Private Sub _btnDestinationDirectoryBrowse_Click(sender As Object, e As EventArgs) Handles _btnDestinationDirectoryBrowse.Click
         _tbDestinationDirectory.Text = BrowseToFolder(_tbDestinationDirectory.Text.Trim(), "Select the destination directory", True)
      End Sub

      Private Function BrowseToFolder(path__1 As String, description As String, allowCreateNew As Boolean) As String
         Dim dlg As New FolderBrowserDialog()
         dlg.SelectedPath = path__1
         dlg.Description = description
         dlg.ShowNewFolderButton = allowCreateNew

         If dlg.ShowDialog(Me) = DialogResult.OK Then
            path__1 = Path.GetFullPath(dlg.SelectedPath)
         End If

         Return path__1
      End Function

      Private Sub _btnGo_Click(sender As Object, e As EventArgs) Handles _btnGo.Click
         ' Get the parameters we need

         Dim sourceDirectory As String = _tbSourceDirectory.Text.Trim()

         If Not Directory.Exists(sourceDirectory) Then
            Messager.ShowInformation(Me, String.Format("Directory '{0}' does not exist", sourceDirectory))
            _tbSourceDirectory.SelectAll()
            _tbSourceDirectory.Focus()
            Return
         End If

         Dim filter As String = _tbFilter.Text.Trim()

         ' Get the files in the source folder
         Dim sourceFiles As String()

         Try
            sourceFiles = Directory.GetFiles(sourceDirectory, filter)
            If sourceFiles.Length = 0 Then
               Messager.ShowInformation(Me, String.Format("Directory '{0}' does not contain any files matching the filter '{1}'", sourceDirectory, filter))
               _tbFilter.SelectAll()
               _tbFilter.Focus()
               Return
            End If
         Catch ex As Exception
            Messager.ShowError(Me, ex)
            Return
         End Try

         Dim destinationDirectory As String = _tbDestinationDirectory.Text.Trim()

         If Not Directory.Exists(destinationDirectory) Then
            ' Try to create it
            Try
               Directory.CreateDirectory(destinationDirectory)
            Catch ex As Exception
               Messager.ShowError(Me, ex)
               _tbDestinationDirectory.SelectAll()
               _tbDestinationDirectory.Focus()
               Return
            End Try
         End If

         Try
            Dim ds As DirectorySecurity = Directory.GetAccessControl(destinationDirectory)
            If ds.AreAccessRulesProtected Then
               Messager.ShowError(Me, "Access to the path " & destinationDirectory & " is denied")
               Return
            End If

            Dim logFileName As String = Path.Combine(destinationDirectory, "_Log.txt")
            If File.Exists(logFileName) Then
               File.Delete(logFileName)
            End If
         Catch ex As Exception
            Messager.ShowError(Me, ex)
            Return
         End Try

         Dim loopContinuously As Boolean = _cbLoopContinuously.Checked

         Dim format As DocumentFormat = _documentFormatSelector.SelectedFormat

         RaiseEvent StartConversion(Me, New StartConversionEventArgs(_ocrEngineType, sourceFiles, destinationDirectory, format, loopContinuously))
      End Sub

      Public Event StartConversion As EventHandler(Of StartConversionEventArgs)

      Private Sub _documentFormatSelector_SelectedFormatChanged(sender As Object, e As EventArgs) Handles _documentFormatSelector.SelectedFormatChanged
         _documentFormatSelector.TotalPages = _totalPages
         Select Case _documentFormatSelector.SelectedFormat
            Case DocumentFormat.Xps
               _documentFormatSelector.FormatHasOptions = False
               Exit Select

            Case DocumentFormat.Doc
               _documentFormatSelector.FormatHasOptions = True
               Exit Select

            Case DocumentFormat.Docx
               _documentFormatSelector.FormatHasOptions = True
               Exit Select

            Case DocumentFormat.Rtf
               _documentFormatSelector.FormatHasOptions = True
               Exit Select

#If LEADTOOLS_V17_OR_LATER Then
            Case DocumentFormat.Xls
               _documentFormatSelector.FormatHasOptions = False
               Exit Select
#End If

            Case DocumentFormat.AltoXml
               _documentFormatSelector.FormatHasOptions = True
               Exit Select

            Case DocumentFormat.Pub
               _documentFormatSelector.FormatHasOptions = False
               Exit Select

            Case DocumentFormat.Mob
               _documentFormatSelector.FormatHasOptions = False
               Exit Select

            Case DocumentFormat.Svg
               _documentFormatSelector.FormatHasOptions = False
               Exit Select
            Case Else

               _documentFormatSelector.FormatHasOptions = True
               Exit Select
         End Select
      End Sub
   End Class
End Namespace
