' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.IO
Imports System.Windows.Forms
Imports System.Runtime.InteropServices

Imports Leadtools.Demos
Imports Leadtools
Imports Leadtools.Codecs
Imports Leadtools.Document.Writer
Imports Leadtools.Ocr
Imports Leadtools.Caching
Imports Leadtools.Document
Imports Leadtools.Annotations.Rendering
Imports Leadtools.Annotations.WinForms
Imports System

Namespace DocumentConverterDemo
   NotInheritable Class Program
      Private Sub New()
      End Sub
      ''' <summary>
      ''' The main entry point for the application.
      ''' </summary>
      <STAThread()> _
      Shared Function Main(args As String()) As Integer

         Dim preferencesFileName As String = If(args.Length = 1, args(0), Nothing)
         Try
            Return Run(preferencesFileName)
         Catch ex As Exception
            Try
               ' Load it from the file specified by the user
               If Not String.IsNullOrEmpty(preferencesFileName) Then
                  Dim preferences As DocumentConverterPreferences = DocumentConverterPreferences.Load(preferencesFileName)
                  preferences.ErrorMessage = ex.Message
                  preferences.Save(preferencesFileName)
               End If
            Catch
            End Try

            Return 1
         End Try
      End Function

      Private Shared Function Run(preferencesFileName As String) As Integer
         
         If Not Support.SetLicense() Then
            Return 1
         End If

         Application.EnableVisualStyles()
         Application.SetCompatibleTextRenderingDefault(False)

         Messager.Caption = "Document Converter Demo"

         ' Initialize Trace
         Trace.Listeners.Add(New TextWriterTraceListener(Console.Out))

         Console.WriteLine("LEADTOOLS " + Messager.Caption)

         Dim preferences As DocumentConverterPreferences
         Dim convertRedactionOptions As ConvertRedactionOptions = Nothing

         If Not String.IsNullOrEmpty(preferencesFileName) Then
            ' Load it from the file specified by the user
            preferences = DocumentConverterPreferences.Load(preferencesFileName)
            preferences.IsSilentMode = True
         Else

            ' Load the preferences file
            DocumentConverterPreferences.DemoName = "Document Converter Demo"
            DocumentConverterPreferences.XmlFileName = "DocumentConverterDemo"
            preferences = DocumentConverterPreferences.Load()
            preferences.IsSilentMode = False
         End If

         ' Create the rendering engine
         Try
            If preferences.AnnRenderingEngine Is Nothing Then
               preferences.AnnRenderingEngine = New AnnWinFormsRenderingEngine()
               preferences.AnnRenderingEngine.Resources = Tools.LoadResources()
            End If
         Catch
         End Try

         If Not preferences.IsSilentMode Then
            ' Show the OCR engine selection dialog to startup the OCR engine
            Trace.WriteLine("Starting OCR engine")
            Dim engineType As OcrEngineType = preferences.OCREngineType
            Using dlg As OcrEngineSelectDialog = New OcrEngineSelectDialog(DocumentConverterPreferences.DemoName, engineType.ToString(), True)
               dlg.AllowNoOcr = True
               dlg.AllowNoOcrMessage = "The demo runs without OCR functionality but you will not be able to parse text from non-document files such as TIFF or Raster PDF. Click 'Cancel' to start this demo without an OCR engine."
               If dlg.ShowDialog() = DialogResult.OK Then
                  preferences.OcrEngineInstance = dlg.OcrEngine
                  preferences.OCREngineType = dlg.OcrEngine.EngineType
                  Trace.WriteLine(String.Format("OCR engine {0} started", preferences.OCREngineType))
               End If
            End Using
         Else
            ' Initialize the default OCR engine
            preferences.OcrEngineInstance = InitOcrEngine(preferences)
         End If

         ' Initialize the RasterCodecs instance
         Dim rasterCodecs As New RasterCodecs()
         rasterCodecs.Options = DocumentFactory.RasterCodecsTemplate.Options.Clone()
         preferences.RasterCodecsInstance = rasterCodecs

         If Not String.IsNullOrEmpty(preferences.RasterCodecsOptionsPath) Then
            preferences.RasterCodecsInstance.LoadOptions(preferences.RasterCodecsOptionsPath)
         End If

         ' Initialize the DocumentWriter instance
         preferences.DocumentWriterInstance = New DocumentWriter()
         If Not String.IsNullOrEmpty(preferences.DocumentWriterOptionsPath) Then
            preferences.DocumentWriterInstance.LoadOptions(preferences.DocumentWriterOptionsPath)
         End If

         ' Cache to use
         Dim cache As ObjectCache = Nothing

         ' Initialize the cache
         If Not String.IsNullOrEmpty(preferences.CacheDirectory) Then
            Dim fileCache As FileCache = New FileCache()
            fileCache.CacheDirectory = preferences.CacheDirectory
            fileCache.DataSerializationMode = preferences.CacheDataSerializationMode
            fileCache.PolicySerializationMode = preferences.CachePolicySerializationMode
            cache = fileCache
         End If

         ' Do conversions
         Dim more As Boolean = True
         While more
            Console.WriteLine("Obtaining conversion options")

            If Not preferences.IsSilentMode Then
               ' Collect the options
               Using dlg As DocumentConverterDialog = New DocumentConverterDialog()
                  dlg.Preferences = preferences.Clone()
                  dlg.RedactionOptions = convertRedactionOptions
                  If dlg.ShowDialog() = DialogResult.OK Then
                     preferences = dlg.Preferences.Clone()
                     convertRedactionOptions = dlg.RedactionOptions
                  Else
                     more = False
                  End If
               End Using
            End If

            If more Then
               Try
                  ' Save the preferences
                  If Not preferences.IsSilentMode Then
                     preferences.Save()
                  End If

                  ' Run the conversion
                  If preferences.DocumentID IsNot Nothing Then
                     Using document As LEADDocument = DocumentFactory.LoadFromCache(cache, preferences.DocumentId)
                        preferences.Run(cache, document, Nothing, convertRedactionOptions)
                     End Using
                  Else
                     preferences.Run(Nothing, Nothing, Nothing, convertRedactionOptions)
                  End If
               Catch ex As Exception
                  If Not preferences.IsSilentMode Then
                     Messager.ShowError(Nothing, ex.Message)
                  Else
                     preferences.ErrorMessage = ex.Message
                  End If
               End Try
            End If

            If more Then
               If Not preferences.IsSilentMode Then
                  ' Ask if user wants to convert another document
                  more = (Messager.ShowQuestion(Nothing, "Convert more?", MessageBoxButtons.YesNo) = DialogResult.Yes)
               Else
                  more = False
               End If
            End If
         End While

         If preferences.OcrEngineInstance IsNot Nothing Then
            preferences.OcrEngineInstance.Dispose()
         End If

         If preferences.RasterCodecsInstance IsNot Nothing Then
            preferences.RasterCodecsInstance.Dispose()
         End If

         If preferencesFileName IsNot Nothing Then
            preferences.Save(preferencesFileName)
         End If

         If preferences.ErrorMessage IsNot Nothing Then
            Return 1
         End If

         Return 0
      End Function

      ' Initialize the OCR engine used throughout the application
      Private Shared Function InitOcrEngine(preferences As DocumentConverterPreferences) As IOcrEngine
         ' try to start the OCR engine
         Dim ocrEngine As IOcrEngine = Nothing

         Dim ocrEngineType__1 As OcrEngineType = preferences.OCREngineType

         Try
            Trace.WriteLine("Starting OCR engine")

            ocrEngine = OcrEngineManager.CreateEngine(ocrEngineType__1, False)

#If LT_CLICKONCE Then
				Dim ocrEngineRuntimePath = Path.Combine(Application.StartupPath, "OCR Engine")
#Else
            Dim ocrEngineRuntimePath As String = preferences.OCREngineRuntimePath

            If String.IsNullOrEmpty(ocrEngineRuntimePath) Then
               ' Maybe in a local folder under this EXE?
               If ocrEngineType__1 = OcrEngineType.LEAD Then
                  ocrEngineRuntimePath = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "LEADTOOLS\OcrLEADRuntime")
               ElseIf ocrEngineType__1 = OcrEngineType.OmniPage Then
                  If IntPtr.Size = 8 Then
                     ocrEngineRuntimePath = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "LEADTOOLS\OcrOmniPageRuntime64")
                  Else
                     ocrEngineRuntimePath = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "LEADTOOLS\OcrOmniPageRuntime")
                  End If
               End If
            End If


            If Not Directory.Exists(ocrEngineRuntimePath) Then
               ' No, check the registry if this machine has LEADTOOLS installed
               ocrEngineRuntimePath = Nothing
            End If
#End If
            ocrEngine.Startup(Nothing, Nothing, Nothing, ocrEngineRuntimePath)
         Catch ex As Exception
            ocrEngine = Nothing
            Dim message As String = String.Format("Failed to start the OCR engine. The demo will continue running without OCR functionality and you will not be able to parse text from non-document files such as TIFF or Raster PDF." & vbLf & vbLf & "Error message:" & vbLf & "{0}", ex.Message)
            Trace.WriteLine(message)
         End Try

         Return ocrEngine
      End Function
   End Class
End Namespace
