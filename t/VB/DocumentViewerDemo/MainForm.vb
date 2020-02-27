' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports System.IO
Imports System.Diagnostics
Imports System.Drawing.Printing
Imports System
Imports System.Text.RegularExpressions
Imports System.Drawing.Drawing2D

Imports Leadtools.Demos
Imports Leadtools
Imports Leadtools.Codecs
Imports Leadtools.Caching
Imports Leadtools.Document
Imports Leadtools.Document.Viewer
Imports Leadtools.Controls
Imports Leadtools.Ocr
Imports Leadtools.Document.Writer
Imports Leadtools.Drawing
Imports Leadtools.Annotations.Engine
Imports Leadtools.Annotations.Rendering
Imports Leadtools.Annotations.WinForms

Partial Public Class MainForm
   Inherits Form
   ' This app preferences
   Private _preferences As Preferences

   ' Cache to use in this demo
   Private _cache As ObjectCache

   ' Preferences used when converting this document (Save)
   Private _converterPreferences As DocumentConverterPreferences

   ' This is the optional OCR engine used by this demo
   Private _ocrEngine As IOcrEngine

   ' The document viewer
   Private _documentViewer As DocumentViewer

   ' UI Command binder
   Private _commandsBinder As CommandsBinder

   ' View context menu
   Private _viewContextMenu As ViewContextMenu = Nothing

   ' Print page settings
   Private _pageSettings As PageSettings

   Private _countPageRenders As Boolean = False

   Private _viewPageRendersByIndex As SortedDictionary(Of Integer, Integer)

   Private _thumbnailsPageRendersByIndex As SortedDictionary(Of Integer, Integer)

   Private _imagesRecognitionMode As DocumentTextImagesRecognitionMode = DocumentTextImagesRecognitionMode.Auto
   Private _textExtractionMode As DocumentTextExtractionMode = DocumentTextExtractionMode.Auto
   Private _loadDocumentTimeoutMilliseconds As Integer = 0
   Private _maximumImagePixelSize As Integer = 12288

   Public Sub New()
      InitializeComponent()
   End Sub

   Protected Overrides Sub OnLoad(e As EventArgs)
      If Not DesignMode Then
         Try
            InitDemo()
         Catch ex As Exception
            Messager.ShowError(Me, ex)
            Return
         End Try
      End If

      MyBase.OnLoad(e)
   End Sub

   Protected Overrides Sub OnFormClosed(e As FormClosedEventArgs)
      If _documentViewer IsNot Nothing Then
         _preferences.PreferredItemType = _documentViewer.View.PreferredItemType
         _preferences.EnableTooltips = _documentViewer.Annotations.AutomationManager.EnableToolTip
      End If

      _preferences.Save()
      _converterPreferences.Save()

      If _documentViewer IsNot Nothing Then
         RemoveHandler _documentViewer.Operation, AddressOf _documentViewer_Operation

         RemoveHandler _documentViewer.View.ImageViewer.PostRenderItem, AddressOf imageViewer_PostRenderItem
         If _documentViewer.Thumbnails IsNot Nothing Then
            RemoveHandler _documentViewer.Thumbnails.ImageViewer.PostRenderItem, AddressOf imageViewer_PostRenderItem
         End If

         ' To hook from the events
         If _preferences.ShowTextIndicators Then
            _preferences.ShowTextIndicators = False
         End If

         _documentViewer.Dispose()
      End If

      If _ocrEngine IsNot Nothing Then
         _ocrEngine.Dispose()
         _ocrEngine = Nothing
      End If

      MyBase.OnFormClosed(e)
   End Sub

   Private Sub InitDemo()
      ' Load the preferences
      _preferences = Preferences.Load()

      Messager.Caption = "VB Document Viewer Demo"
      Text = Messager.Caption

      ' Init the optional OCR engine used by this app
      InitOcrEngine()

      ' Init the documents cache to use by this app
      InitCache()

      ' Init the preferences used with the document converter (used on the save menu)
      InitDocumentsConverter()

      ' Init the document viewer...
      InitDocumentViewer()
      InitAutomation()

      _commandsBinder = New CommandsBinder(_documentViewer)

      BindFileItems()
      BindEditItems()
      BindViewItems()
      BindPageItems()
      BindInteractiveItems()
      BindAnnotationsItems()

      _commandsBinder.BindActions(True)

      UpdateShowOperation()

      ' Init the UI
      UpdateDocumentSetUIState()

      ' Load the default document
      Dim defaultAnnotationsFileName As String = _preferences.LastAnnotationsFileName
      Dim defaultDocumentFileName As String = _preferences.LastDocumentFileName
      Dim defaultFirstPageNumber As Integer = _preferences.LastDocumentFirstPageNumber
      Dim defaultLastPageNumber As Integer = _preferences.LastDocumentLastPageNumber

      If String.IsNullOrEmpty(defaultDocumentFileName) OrElse Not File.Exists(defaultDocumentFileName) Then
         ' Try our default image
#If LT_CLICKONCE Then
				defaultDocumentFileName = Path.Combine(Application.StartupPath, "Documents\Leadtools.pdf")
#Else
         defaultDocumentFileName = Path.Combine(DemosGlobal.ImagesFolder, "Leadtools.pdf")
#End If
         defaultAnnotationsFileName = Nothing
      End If

      If Not String.IsNullOrEmpty(defaultAnnotationsFileName) AndAlso Not File.Exists(defaultAnnotationsFileName) Then
         defaultAnnotationsFileName = Nothing
      End If

      If Not String.IsNullOrEmpty(defaultDocumentFileName) AndAlso File.Exists(defaultDocumentFileName) Then
         BeginInvoke(CType(Sub()
                              Dim message As String = String.Format("Do you want to re-load the last document?{0}{0}{1}", Environment.NewLine, defaultDocumentFileName)
                              If Messager.ShowQuestion(Me, message, MessageBoxButtons.YesNo) = DialogResult.Yes Then
                                 LoadDocumentFromFile(defaultDocumentFileName, defaultFirstPageNumber, defaultLastPageNumber, defaultAnnotationsFileName, _preferences.LastFileLoadEmbeddedAnnotations)
                              End If
                           End Sub, MethodInvoker))
      End If

      ' Init printing
      If PrinterSettings.InstalledPrinters IsNot Nothing AndAlso PrinterSettings.InstalledPrinters.Count > 0 Then
         _pageSettings = New PageSettings()
      End If
   End Sub

   Private Sub CleanUp()
      If _automationManagerHelper IsNot Nothing Then
         _automationManagerHelper.Dispose()
      End If
   End Sub

   Private Sub InitOcrEngine()
      Try
         _ocrEngine = OcrEngineManager.CreateEngine(OcrEngineType.LEAD, False)

         ' A child directory?
         Dim enginePath As String = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "LEADTOOLS\OcrLEADRuntime")
         If Not Directory.Exists(enginePath) Then
            ' No, perhaps in the registry then
            enginePath = Nothing
         End If

#If LT_CLICKONCE Then
				_ocrEngine.Startup(Nothing, Nothing, Nothing, Application.StartupPath + "\OCR Engine")
#Else
#End If

         _ocrEngine.Startup(Nothing, Nothing, Nothing, enginePath)
      Catch ex As Exception
         Helper.ShowWarning(Me, String.Format("Failed to start the LEAD OCR engine. The demo will continue running without OCR functionality and you will not be able to parse text from non-document files such as TIFF or Raster PDF." & vbLf + vbLf & "Error message:" & vbLf & "{0}", ex.Message))
      End Try
   End Sub

   ' Init the documents cache
   Private Sub InitCache()
      ' This demo does not require cache, however, using cache will speed up loading of resources from a document with a large number of pages
      ' Setup the cache directory
      Dim cacheDir As String = _preferences.CacheDir
      If Not Directory.Exists(cacheDir) Then
         Directory.CreateDirectory(cacheDir)
      End If

      ' Now setup a new LEADTOOLS file cache object and set it as the cache object to use from now on
      Dim cache As FileCache = New FileCache()
      cache.CacheDirectory = cacheDir
      _cache = cache
   End Sub

   Private Sub InitDocumentsConverter()
      ' Load the converters preferences file
      DocumentConverterPreferences.DemoName = "Document Viewer Demo"
      DocumentConverterPreferences.XmlFileName = "DocumentViewerDemo_Converters"
      _converterPreferences = DocumentConverterPreferences.Load()

      ' Create the rendering engine
      Try
         If _converterPreferences.AnnRenderingEngine Is Nothing Then
            _converterPreferences.AnnRenderingEngine = New AnnWinFormsRenderingEngine()
            _converterPreferences.AnnRenderingEngine.Resources = Tools.LoadResources()
         End If
      Catch
      End Try

      ' Initialize OCR engine
      _converterPreferences.OcrEngineInstance = Me._ocrEngine

      ' Initialize the RasterCodecs instance
      _converterPreferences.RasterCodecsInstance = DocumentFactory.RasterCodecsTemplate

      ' Initialize the DocumentWriter instance
      _converterPreferences.DocumentWriterInstance = New DocumentWriter()
   End Sub

   ' Create the document viewer
   Private Sub InitDocumentViewer()
      Dim createOptions As DocumentViewerCreateOptions = New DocumentViewerCreateOptions()

      ' Set the UI part where the main view is displayed
      createOptions.ViewContainer = _centerPanel
      ' Set the UI part where the thumbnails are displayed
      createOptions.ThumbnailsContainer = _thumbnailsTabPage
      ' Set the UI part where the bookmarks are displayed
      createOptions.BookmarksContainer = _bookmarksTabPage
      createOptions.UseAnnotations = True

      ' Now create the viewer
      _documentViewer = DocumentViewerFactory.CreateDocumentViewer(createOptions)
      ' Set the user name
      _documentViewer.UserName = Environment.UserName
      _documentViewer.View.PreferredItemType = _preferences.PreferredItemType

      Dim imageViewer As ImageViewer = _documentViewer.View.ImageViewer
      imageViewer.BackColor = SystemColors.AppWorkspace

      ' Helps with debugging of there was a rendering error
      AddHandler imageViewer.RenderError, Sub(sender As Object, e As ImageViewerRenderEventArgs)
                                             Dim message As String = String.Format("Error during render item {0} part {1}: {2}", If(e.Item IsNot Nothing, imageViewer.Items.IndexOf(e.Item), -1), e.Part, e.[Error].Message)
                                             _outputWindow.AddTextLine(message, OutputWindow.LineStyle.[Error])

                                          End Sub
      _documentViewer.Text.AutoGetText = _preferences.AutoGetText
      _documentViewer.Commands.Run(DocumentViewerCommands.InteractiveAutoPan)
      ' Call this if you prefer Pan/Zoom as the default interactive mode
      '_documentViewer.Commands.Run(DocumentViewerCommands.InteractivePanZoom);

      ' Set enable tooltip default value
      _documentViewer.Annotations.AutomationManager.EnableToolTip = _preferences.EnableTooltips

      ' See if we need to enable inertia scroll
      If _preferences.EnableInertiaScroll Then
         ToggleInertiaScroll(True)
      End If

      AddHandler _documentViewer.Operation, AddressOf _documentViewer_Operation

      AddHandler _documentViewer.View.ImageViewer.PostRenderItem, AddressOf imageViewer_PostRenderItem
      If _documentViewer.Thumbnails IsNot Nothing Then
         AddHandler _documentViewer.Thumbnails.ImageViewer.PostRenderItem, AddressOf imageViewer_PostRenderItem
      End If
   End Sub

   ' Update the UI state of the app
   Private Sub UpdateDocumentSetUIState()
      Dim hasDocument As Boolean = _documentViewer.HasDocument

      If hasDocument Then
         If Not _leftPanel.Visible Then
            _leftPanel.Visible = True
         End If

         If Not _centerPanel.Visible Then
            _centerPanel.Visible = True
         End If

         If _documentViewer.Document.IsStructureSupported Then
            If Not _leftTabControl.TabPages.Contains(_bookmarksTabPage) Then
               _leftTabControl.TabPages.Add(_bookmarksTabPage)
            End If
         Else
            If _leftTabControl.TabPages.Contains(_bookmarksTabPage) Then
               _leftTabControl.TabPages.Remove(_bookmarksTabPage)
            End If
         End If

         If Not _documentViewer.Document.IsReadOnly Then
            _loadingThumbnailsProgressBar.Visible = False
         End If

         UpdateAnnotationsControlsVisiblity()
      Else
         _leftPanel.Visible = False
         _rightPanel.Visible = False
         _centerPanel.Visible = False
      End If

      UpdateUIState()
   End Sub

   Private Sub UpdateUIState()
      _commandsBinder.Run()
   End Sub

   Private Sub LoadDocumentFromFile(documentFileName As String, firstPageNumber As Integer, lastPageNumber As Integer, annotationsFileName As String, loadEmbeddedAnnotations As Boolean)
      ' This could take some time, so run it as a busy operation
      ' Setup the document load options

      ' On success, set it as the last document file we opened
      Dim operation As BusyOperation(Of LEADDocument) = New BusyOperation(Of LEADDocument)("Load document from file") With {
        .Begin = Sub()
                    Me.BeginBusyOperation()
                    Dim pagesMessage As String
                    If (firstPageNumber = 0 AndAlso lastPageNumber = 0) OrElse (firstPageNumber = 1 AndAlso lastPageNumber = -1) Then
                       pagesMessage = String.Empty
                    Else
                       If lastPageNumber = 0 OrElse lastPageNumber = -1 Then
                          pagesMessage = String.Format("{0}From page {1} to last page", Environment.NewLine, firstPageNumber)
                       Else
                          pagesMessage = String.Format("{0}From page {1} to {2}", Environment.NewLine, firstPageNumber, lastPageNumber)
                       End If
                    End If

                    Dim annotationsMessage As String
                    If Not annotationsFileName Is Nothing Then
                       annotationsMessage = String.Format("{0}With annotations from {1}", Environment.NewLine, annotationsFileName)
                    ElseIf loadEmbeddedAnnotations Then
                       annotationsMessage = String.Format("{0}With embedded annotations if exist", Environment.NewLine)
                    Else
                       annotationsMessage = String.Format("{0}With no annotations", Environment.NewLine)
                    End If

                    Dim message As String = String.Format("Loading document from {0}{1}{2}", documentFileName, pagesMessage, annotationsMessage)
                    ShowBusyDialog(False, message)
                 End Sub,
        .InThread = Function()
                       Dim options As LoadDocumentOptions = New LoadDocumentOptions()
                       options.Cache = _cache
                       options.UseCache = _cache IsNot Nothing
                       options.TimeoutMilliseconds = _loadDocumentTimeoutMilliseconds
                       options.MaximumImagePixelSize = _maximumImagePixelSize
                       If annotationsFileName IsNot Nothing Then
                          options.AnnotationsUri = New Uri(annotationsFileName)
                       Else
                          options.AnnotationsUri = Nothing
                       End If
                       options.LoadEmbeddedAnnotations = loadEmbeddedAnnotations
                       options.FirstPageNumber = firstPageNumber
                       options.LastPageNumber = lastPageNumber
                       Return DocumentFactory.LoadFromFile(documentFileName, options)

                    End Function,
        .End = AddressOf EndBusyOperation,
        .ThenInvoke = Sub(document As LEADDocument)
                         Try
                            If document IsNot Nothing Then
                               ' Auto-delete from cache when its disposed
                               document.AutoDeleteFromCache = True
                               SetDocument(document)
                               _preferences.LastDocumentFileName = documentFileName
                               _preferences.LastDocumentFirstPageNumber = firstPageNumber
                               _preferences.LastDocumentLastPageNumber = lastPageNumber
                               _preferences.LastAnnotationsFileName = annotationsFileName
                               _preferences.LastFileLoadEmbeddedAnnotations = loadEmbeddedAnnotations
                            Else
                               Helper.ShowError(Me, "Loading document timed-out")
                            End If
                         Catch ex As Exception
                            Helper.ShowError(Me, ex)
                         End Try

                      End Sub,
        .Error = Sub(ex As Exception)
                    Helper.ShowError(Me, ex)

                 End Sub
      }
      operation.Run(Me)
   End Sub

   Public Function LoadDocumentFromUri(dialog As OpenDocumentUrlDialog, documentUri As Uri, firstPageNumber As Integer, lastPageNumber As Integer, annotationsUri As Uri, loadEmbeddedAnnotations As Boolean) As Boolean
      Try
         Dim options As LoadDocumentAsyncOptions = New LoadDocumentAsyncOptions()

         ' Setup the progress and completed event
         Dim progress As EventHandler(Of LoadAsyncProgressEventArgs) = Nothing
         Dim completed As EventHandler(Of LoadAsyncCompletedEventArgs) = Nothing

         progress = Sub(sender, e)
                       dialog.SetProgress(e.ProgressPercentage)
                       If dialog.IsCancelPending Then
                          e.IsCancelPending = True
                       End If

                    End Sub

         completed = Sub(sender, e)
                        ' Remove our events
                        Dim thisOptions As LoadDocumentAsyncOptions = TryCast(sender, LoadDocumentAsyncOptions)
                        RemoveHandler thisOptions.Progress, progress
                        RemoveHandler thisOptions.Completed, completed

                        If e.Cancelled OrElse e.[Error] IsNot Nothing Then
                           If Not e.Cancelled Then
                              Helper.ShowError(Me, e.[Error])
                           End If

                           dialog.Finish(False)
                           Return
                        End If

                        dialog.Finish(True)

                        Dim document As LEADDocument = e.Document
                        If document IsNot Nothing Then
                           ' We have a document, set it
                           ' Auto-delete from cache when its disposed
                           document.AutoDeleteFromCache = True
                           SetDocument(document)
                        Else
                           Helper.ShowError(Me, "Loading document timed-out")
                        End If

                     End Sub

         AddHandler options.Progress, progress
         AddHandler options.Completed, completed

         options.FirstPageNumber = firstPageNumber
         options.LastPageNumber = lastPageNumber

         options.LoadEmbeddedAnnotations = loadEmbeddedAnnotations
         options.AnnotationsUri = annotationsUri
         options.Cache = _cache
         options.UseCache = _cache IsNot Nothing
         options.TimeoutMilliseconds = _loadDocumentTimeoutMilliseconds
         options.MaximumImagePixelSize = _maximumImagePixelSize
         DocumentFactory.LoadFromUriAsync(documentUri, options)
         _preferences.LastDocumentUri = documentUri.ToString()
         _preferences.LastDocumentUriFirstPageNumber = firstPageNumber
         _preferences.LastDocumentUriLastPageNumber = lastPageNumber
         _preferences.LastAnnotationsUri = If(annotationsUri IsNot Nothing, annotationsUri.ToString(), Nothing)
         _preferences.LastUriLoadEmbeddedAnnotations = loadEmbeddedAnnotations

         Return True
      Catch ex As Exception
         Helper.ShowError(Me, ex)
         Return False
      End Try
   End Function

   Private Sub LoadDocumentFromCache(ByVal documentId As String)
      Dim operation As New BusyOperation(Of LEADDocument)("Load document from cache")
      operation.Begin = Sub()
                           Me.BeginBusyOperation()
                           Dim message As String = String.Format("Loading document {0} from the cache", documentId)
                           ShowBusyDialog(False, message)
                        End Sub

      operation.InThread = Function()
                              Return DocumentFactory.LoadFromCache(_cache, documentId)
                           End Function
      operation.End = AddressOf Me.EndBusyOperation
      operation.ThenInvoke = Sub(document As LEADDocument)
                                If document Is Nothing Then
                                   Helper.ShowError(Me, String.Format("Document with ID '{0}' was not found in the cache or has been expired", documentId))
                                   Return
                                End If

                                Try
                                   SetDocument(document)
                                Catch ex As Exception
                                   Helper.ShowError(Me, ex)
                                End Try
                             End Sub
      operation.Error = Sub(ex As Exception)
                           Helper.ShowError(Me, ex)
                        End Sub
      operation.Run(Me)
   End Sub

   Private Sub SaveDocumentToCache()
      Try
         Dim document As LEADDocument = _documentViewer.Document
         document.AutoSaveToCache = False
         document.AutoDeleteFromCache = False
         Dim annotations As DocumentViewerAnnotations = _documentViewer.Annotations
         If annotations IsNot Nothing AndAlso annotations.IsContainerModified(0) Then
            Dim operation As New BusyOperation(Of Boolean)("Updating the document annotations")
            operation.Begin = Sub()
                                 Me.BeginBusyOperation()
                                 ShowBusyDialog(False, "Updating the document annotations")
                              End Sub

            operation.InThread = Function()
                                    _documentViewer.PrepareToSave()
                                    Return True
                                 End Function

            operation.End = AddressOf Me.EndBusyOperation
            operation.ThenInvoke = Sub(result)
                                      SaveDocumentToCache(_documentViewer.Document, True)
                                   End Sub
            operation.Error = Sub(ex As Exception)
                                 Helper.ShowError(Me, ex)
                              End Sub
            operation.Run(Me)
         Else
            SaveDocumentToCache(_documentViewer.Document, True)
         End If
      Catch ex As Exception
         Helper.ShowError(Me, ex)
      End Try
   End Sub

   Private Sub SaveDocumentToCache(ByVal document As LEADDocument, showInfo As Boolean)
      document.SaveToCache()

      If showInfo Then
         Dim dlg As InputDialog = New InputDialog()
         dlg.IsReadOnly = True
         dlg.Value = document.DocumentId
         dlg.ValueDescription1 = "The document with the following ID has been successfully saved to the cache"
         dlg.ShowDialog(Me)
      End If

   End Sub

   Private Sub SetDocument(document As LEADDocument)
      If document.IsEncrypted AndAlso Not document.IsDecrypted Then
         ' This document requires a password
         DecryptDocument(document)

         ' If still, then dispose it and dont set it
         If document.IsEncrypted AndAlso Not document.IsDecrypted Then
            document.Dispose()
            Return
         End If
      End If

      FinishSetDocument(document)
   End Sub

   Private Sub FinishSetDocument(document As LEADDocument)
      ' If we have an OCR engine, use it
      document.Text.OcrEngine = _ocrEngine
      document.Text.ImagesRecognitionMode = _imagesRecognitionMode
      document.Text.TextExtractionMode = _textExtractionMode

      ' Set it in the document viewer
      _documentViewer.SetDocument(document)

      ' Show the document name in the caption
      Me.Text = String.Format("{0} - {1}", GetDocumentPath(_documentViewer.Document), Messager.Caption)

      ' Update the UI
      UpdateDocumentSetUIState()
   End Sub

   Private Shared Function GetDocumentPath(document As LEADDocument) As String
      Dim documentPath As String

      Dim documentUri As Uri = document.Uri
      If documentUri IsNot Nothing Then
         If documentUri.IsFile Then
            documentPath = documentUri.LocalPath
         Else
            documentPath = documentUri.ToString()
         End If
      Else
         documentPath = "[[Virtual]]"
      End If

      Return documentPath
   End Function

   Private Shared Sub RestoreTextFilter(rasterCodecs As RasterCodecs, originalSetting As Boolean)
      If rasterCodecs.Options.Txt.Load.Enabled <> originalSetting Then
         rasterCodecs.Options.Txt.Load.Enabled = originalSetting
      End If
   End Sub

   Private Sub CloseDocument()
      If _documentViewer.Document Is Nothing Then
         Return
      End If

      _documentViewer.SetDocument(Nothing)

      Me.Text = Messager.Caption

      UpdateDocumentSetUIState()
   End Sub

   Private Sub DecryptDocument(document As LEADDocument)
      Dim done As Boolean = False

      While Not done
         Using dlg As InputDialog = New InputDialog()
            dlg.Text = "Enter Password"
            dlg.ValueTitle = Nothing
            dlg.ValueDescription1 = "This document is encrypted. Enter the password to decrypt it"
            dlg.IsPassword = True
            If dlg.ShowDialog(Me) = DialogResult.OK Then
               Try
                  ' Try the password
                  If document.Decrypt(dlg.Value) Then
                     done = True
                  Else
                     Helper.ShowError(Me, "Invalid password")
                  End If
               Catch ex As Exception
                  Helper.ShowError(Me, ex)
                  done = True
               End Try
            Else
               ' Use canceled, so they dont want to load it, return
               done = True
            End If
         End Using
      End While
   End Sub

   Private Sub _documentViewer_Operation(sender As Object, e As DocumentViewerOperationEventArgs)
      Dim updater As Action(Of DocumentViewerOperationEventArgs) = Sub(args As DocumentViewerOperationEventArgs)
                                                                      ' If we have an error, show it
                                                                      If args.[Error] IsNot Nothing Then
                                                                         Dim message As String = String.Format("Error in {0}{1} operation. {2}", If(args.IsPostOperation, "Post-", "Pre-"), args.Operation, args.[Error].Message)
                                                                         _outputWindow.AddTextLine(message, OutputWindow.LineStyle.[Error])
                                                                      End If

                                                                      '
                                                                      ' Updating the UI state is expensive - we check UI elements for their ability
                                                                      ' to run commands based on the state of the DocumentViewer.
                                                                      ' So we must approve each operation that we want to update the UI for.
                                                                      '
                                                                      Dim updateUIStateFlag As Boolean = False
                                                                      ' 
                                                                      ' Some operations don't need to be logged, either
                                                                      '
                                                                      Dim logOperationsInfo As Boolean = False

                                                                      Select Case args.Operation
                                                                         Case DocumentViewerOperation.GetPage, DocumentViewerOperation.GotoPage, DocumentViewerOperation.GetAnnotations, DocumentViewerOperation.RenderItemPlaceholder, DocumentViewerOperation.AutomationStateChanged
                                                                            updateUIStateFlag = True
                                                                            Exit Select
                                                                         Case DocumentViewerOperation.RenderSelectedText
                                                                            If (args.IsPostOperation) Then
                                                                               updateUIStateFlag = True
                                                                            End If
                                                                            Exit Select
                                                                         Case Else
                                                                            Exit Select
                                                                      End Select

                                                                      Dim sb As StringBuilder = New StringBuilder()
                                                                      Dim documentViewer As DocumentViewer = TryCast(sender, DocumentViewer)
                                                                      Dim document As LEADDocument = If((documentViewer IsNot Nothing), documentViewer.Document, Nothing)

                                                                      If _preferences.ShowOperations Then
                                                                         sb.AppendFormat("{0}{1} operation", If(args.IsPostOperation, "Post-", "Pre-"), args.Operation)
                                                                      End If

                                                                      Select Case args.Operation
                                                                         Case DocumentViewerOperation.RunCommand
                                                                            updateUIStateFlag = True
                                                                            logOperationsInfo = True

                                                                            If _preferences.ShowOperations Then
                                                                               Dim command As DocumentViewerCommand = TryCast(args.Data1, DocumentViewerCommand)
                                                                               sb.AppendFormat(" Command:{0}", command.Name)

                                                                               If args.IsPostOperation AndAlso command.Name = DocumentViewerCommands.InteractiveSelectText Then
                                                                                  ' Check if we have any text
                                                                                  CanPerformTextOperation("Cannot select text", True)
                                                                               End If
                                                                            End If
                                                                            Exit Select

                                                                         Case DocumentViewerOperation.AttachToDocument
                                                                            If Not args.IsPostOperation Then
                                                                               _viewPageRendersByIndex = New SortedDictionary(Of Integer, Integer)()
                                                                               _thumbnailsPageRendersByIndex = New SortedDictionary(Of Integer, Integer)()
                                                                            End If
                                                                            Exit Select

                                                                         Case DocumentViewerOperation.LoadingThumbnails
                                                                            updateUIStateFlag = True
                                                                            logOperationsInfo = True
                                                                            If Not document.IsReadOnly Then
                                                                               _loadingThumbnailsProgressBar.Visible = Not _documentViewer.Thumbnails.LazyLoad AndAlso Not args.IsPostOperation
                                                                            End If

                                                                            Exit Select

                                                                         Case DocumentViewerOperation.LoadingAnnotations
                                                                            updateUIStateFlag = True
                                                                            logOperationsInfo = True
                                                                            _loadingAnnotationsProgressBar.Visible = Not args.IsPostOperation
                                                                            Exit Select

                                                                         Case DocumentViewerOperation.PagesAdded, DocumentViewerOperation.PagesRemoved
                                                                            updateUIStateFlag = True
                                                                            logOperationsInfo = True
                                                                            If e.IsPostOperation Then
                                                                               If _documentViewer.Annotations IsNot Nothing Then
                                                                                  HandleContainersAddedOrRemoved()
                                                                               End If
                                                                               UpdateDocumentSetUIState()
                                                                            End If
                                                                            Exit Select

                                                                         Case DocumentViewerOperation.RenderViewPage, DocumentViewerOperation.RenderThumbnailPage

                                                                            If _countPageRenders And args.IsPostOperation Then
                                                                               Dim isView As Boolean = args.Operation = DocumentViewerOperation.RenderViewPage
                                                                               Dim renders As SortedDictionary(Of Integer, Integer)
                                                                               If isView Then
                                                                                  renders = _viewPageRendersByIndex
                                                                               Else
                                                                                  renders = _thumbnailsPageRendersByIndex
                                                                               End If
                                                                               Dim index As Integer = args.PageNumber - 1

                                                                               If (renders.ContainsKey(index)) Then
                                                                                  renders(index) = renders(index) + 1
                                                                               Else
                                                                                  logOperationsInfo = True
                                                                                  renders(index) = 1
                                                                                  Dim tmp As String
                                                                                  If isView Then
                                                                                     tmp = "View"
                                                                                  Else
                                                                                     tmp = "Thumbnails"
                                                                                  End If
                                                                                  sb.AppendFormat(" First {0} Render for page {1}", tmp, args.PageNumber)
                                                                               End If
                                                                            End If
                                                                            Exit Select


                                                                         Case DocumentViewerOperation.LoadingBookmarks
                                                                            updateUIStateFlag = True
                                                                            logOperationsInfo = True
                                                                            _loadingBookmarksProgressBar.Visible = Not args.IsPostOperation
                                                                            Exit Select

                                                                         Case DocumentViewerOperation.GetText
                                                                            If True Then
                                                                               ' Have to wait for it to finish. So show the busy dialog
                                                                               If Not args.IsPostOperation Then
                                                                                  If _isInsideBusyOperation Then
                                                                                     ShowBusyDialog(True, String.Format("Getting text for page {0}", args.PageNumber))
                                                                                  Else
                                                                                     ' This was not requested by us, cancel it and start to get the text ourselves
                                                                                     args.Abort = True
                                                                                     Me.BeginInvoke(CType(Sub() GetPagesText(args.PageNumber), MethodInvoker))
                                                                                  End If
                                                                               Else
                                                                                  updateUIStateFlag = True
                                                                                  logOperationsInfo = True
                                                                                  ' When we are done, invalidate the items
                                                                                  If args.PageNumber <> 0 Then
                                                                                     _documentViewer.View.ImageViewer.InvalidateItemByIndex(args.PageNumber - 1)
                                                                                  Else
                                                                                     _documentViewer.View.ImageViewer.Invalidate()
                                                                                  End If

                                                                                  If _documentViewer.Thumbnails IsNot Nothing Then
                                                                                     If args.PageNumber <> 0 Then
                                                                                        _documentViewer.Thumbnails.ImageViewer.InvalidateItemByIndex(args.PageNumber - 1)
                                                                                     Else
                                                                                        _documentViewer.Thumbnails.ImageViewer.Invalidate()
                                                                                     End If
                                                                                  End If
                                                                               End If
                                                                            End If
                                                                            Exit Select

                                                                         Case DocumentViewerOperation.CreateAutomation
                                                                            ' After the document viewer creates the automation object, we need to hook to some events
                                                                            If args.IsPostOperation Then
                                                                               HandleCreateAutomation()
                                                                            End If
                                                                            Exit Select

                                                                         Case DocumentViewerOperation.DestroyAutomation
                                                                            ' Before the document viewer destroys the automation object, we need to unhook from the events
                                                                            If Not args.IsPostOperation Then
                                                                               HandleDestroyAutomation()
                                                                            End If
                                                                            Exit Select

                                                                         Case DocumentViewerOperation.RunLink
                                                                            updateUIStateFlag = True
                                                                            logOperationsInfo = True
                                                                            If args.IsPostOperation AndAlso args.[Error] Is Nothing Then
                                                                               ' Get the link and check if its an external one
                                                                               Dim link As DocumentLink = CType(args.Data1, DocumentLink)
                                                                               If link.LinkType = DocumentLinkType.Value AndAlso Not String.IsNullOrEmpty(link.Value) Then
                                                                                  sb.AppendFormat(" Running link value:" + link.Value)
                                                                                  RunValueLink(link.Value)
                                                                               End If
                                                                            End If
                                                                            Exit Select

                                                                         Case DocumentViewerOperation.HoverLink
                                                                            updateUIStateFlag = True
                                                                            logOperationsInfo = True
                                                                            If args.IsPostOperation Then
                                                                               If args.Data1 IsNot Nothing Then
                                                                                  ' We are hovered over a new link, can show a tooltip for example
                                                                                  ' This demo will just dump the link info

                                                                                  Dim link As DocumentLink = CType(args.Data1, DocumentLink)

                                                                                  If link.LinkType = DocumentLinkType.TargetPage Then
                                                                                     sb.AppendFormat(" Link with target page {0}", link.Target.PageNumber)
                                                                                  Else
                                                                                     sb.AppendFormat(" Link with value {0}", link.Value)
                                                                                  End If
                                                                               Else
                                                                                  ' We are not hovering over any links any more, can hide the tooltip for example
                                                                                  sb.Append(" No link")
                                                                               End If
                                                                            End If
                                                                            Exit Select
                                                                         Case DocumentViewerOperation.PagesDisabledEnabled
                                                                            updateUIStateFlag = True
                                                                            logOperationsInfo = True
                                                                            If args.IsPostOperation Then
                                                                               HandleAnnotationsPagesDisabledEnabled()
                                                                            End If
                                                                            Exit Select
                                                                         Case Else

                                                                            Exit Select
                                                                      End Select

                                                                      If _preferences.ShowOperations And logOperationsInfo Then
                                                                         _outputWindow.AddTextLine(sb.ToString())
                                                                      End If

                                                                      If args.IsPostOperation And updateUIStateFlag Then
                                                                         UpdateUIState()
                                                                      End If

                                                                   End Sub

      ' Try to abort before doing anything
      If _isInsideBusyOperation Then
         If IsBusyDialogCancelled Then
            e.Abort = True
         End If
      End If

      If Me.InvokeRequired Then
         Me.BeginInvoke(CType(updater, Action(Of DocumentViewerOperationEventArgs)), New Object() {e})
      Else
         updater(e)
      End If
   End Sub

   Private _busyDialog As BusyDialog
   Private _isInsideBusyOperation As Boolean
   Private _busyDialogActiveForm As Form

   Public Sub BeginBusyOperation()
      ' Get ready ...
      _isInsideBusyOperation = True
      Me.Enabled = False
   End Sub

   Public Sub EndBusyOperation()
      If Me.InvokeRequired Then
         BeginInvoke(New MethodInvoker(AddressOf EndBusyOperation))
         Return
      End If

      If _isInsideBusyOperation Then
         _isInsideBusyOperation = False

         Me.Enabled = True

         HideBusyDialog()
      End If
   End Sub

   Private Sub ShowBusyDialog(enableCancellation As Boolean, description As String)
      If _busyDialog Is Nothing Then
         _busyDialog = New BusyDialog()
         _busyDialog.Text = Messager.Caption
         _busyDialog.EnableCancellation = enableCancellation

         _busyDialogActiveForm = Form.ActiveForm

         If _busyDialogActiveForm Is Nothing Then
            _busyDialog.Show(Me)
         Else
            _busyDialog.Show(_busyDialogActiveForm)
         End If
      End If

      _busyDialog.UpdateDescription(description)
   End Sub

   Private Sub HideBusyDialog()
      If _busyDialog Is Nothing Then
         Return
      End If

      _busyDialog.IsWorking = False
      _busyDialog.Dispose()
      _busyDialog = Nothing

      If _busyDialogActiveForm IsNot Nothing Then
         _busyDialogActiveForm.Activate()
         _busyDialogActiveForm = Nothing
      End If
   End Sub

   Private ReadOnly Property IsBusyDialogCancelled() As Boolean
      Get
         Return _busyDialog IsNot Nothing AndAlso _busyDialog.IsCancelled
      End Get
   End Property

   Private Sub ShowDocumentProperties()
      Using dlg As DocumentPropertiesDialog = New DocumentPropertiesDialog()
         dlg.Document = _documentViewer.Document
         dlg.ShowDialog(Me)
      End Using
   End Sub

   Private Sub ToggleInertiaScroll(turnOn As Boolean)
      ' These commands have ImageViewerPanZoomInteractiveMode in the tag, update the value
      Dim commandNames As String() = {DocumentViewerCommands.InteractivePanZoom, DocumentViewerCommands.InteractivePan}
      For Each commandName As String In commandNames
         Dim mode As ImageViewerPanZoomInteractiveMode = TryCast(_documentViewer.Commands.GetCommand(commandName).Tag, ImageViewerPanZoomInteractiveMode)
         If mode IsNot Nothing Then
            Dim options As ControlInertiaScrollOptions = mode.InertiaScrollOptions
            options.IsEnabled = If(turnOn, True, Not options.IsEnabled)
            mode.InertiaScrollOptions = options
            _preferences.EnableInertiaScroll = options.IsEnabled
         End If
      Next
   End Sub

   Private Sub UpdateShowOperation()
      If _preferences.ShowOperations Then
         _bottomPanel.Visible = True
      Else
         _bottomPanel.Visible = False
      End If
   End Sub

   Public Function CanPerformTextOperation(operation As String, noPages As Boolean) As Boolean
      If Not _documentViewer.Text.AutoGetText AndAlso Not _documentViewer.Text.HasAnyDocumentPageText() Then
         ' This means auto-get text is off and we never got any text, warn the user
         Dim message As String = Helper.AddTextNote(operation, noPages)
         Helper.ShowInformation(Me, message)
         Return False
      End If

      Return True
   End Function

   Private Sub UpdateShowTextIndicators()
      _documentViewer.View.Invalidate()
      If _documentViewer.Thumbnails IsNot Nothing Then
         _documentViewer.Thumbnails.Invalidate()
      End If
   End Sub

   Private Shared _alphaBrush As Brush = New SolidBrush(Color.FromArgb(128, Color.White))
   Private Shared _hasTextFont As New Font("Arial", 12, FontStyle.Bold)
   Private Shared _noTextFont As New Font("Arial", 12, FontStyle.Regular)

   Private Sub imageViewer_PostRenderItem(ByVal sender As Object, ByVal e As ImageViewerRenderEventArgs)
      Dim document As LEADDocument = _documentViewer.Document
      If document Is Nothing Then
         Return
      End If

      Dim imageViewer As ImageViewer = TryCast(sender, ImageViewer)
      Dim isView As Boolean = imageViewer Is _documentViewer.View.ImageViewer

      Dim showTextIndicators As Boolean = _preferences.ShowTextIndicators
      Dim pageNumber As Integer = imageViewer.Items.IndexOf(e.Item) + 1
      Dim page As DocumentPage = document.Pages(pageNumber - 1)

      Dim isDisabled As Boolean = page.IsDeleted

      If (Not showTextIndicators) AndAlso (Not isDisabled) Then
         Return
      End If

      Dim graphics As Graphics = e.PaintEventArgs.Graphics
      Dim transform As LeadMatrix = imageViewer.GetItemImageTransform(e.Item)
      Dim imageSize As LeadSize = e.Item.ImageSize

      Dim bounds As LeadRectD = LeadRectD.Create(0, 0, imageSize.Width, imageSize.Height)
      Dim corners As LeadPointD() = {LeadPointD.Create(bounds.Left, bounds.Top),
                                     LeadPointD.Create(bounds.Right, bounds.Top),
                                     LeadPointD.Create(bounds.Right, bounds.Bottom),
                                     LeadPointD.Create(bounds.Left, bounds.Bottom)}

      transform.TransformPoints(corners)

      If showTextIndicators Then
         ' render a small T at the top-right corner
         Dim hasText As Boolean = _documentViewer.Text.HasDocumentPageText(pageNumber)

         ' Get the top-right point
         Dim topRight As LeadPointD = corners(0)
         Dim i As Integer = 1
         Do While i < corners.Length
            If corners(i).X > topRight.X Then
               topRight.X = corners(i).X
            End If
            If corners(i).Y < topRight.Y Then
               topRight.Y = corners(i).Y
            End If
            i += 1
         Loop

         Dim text As String = "T"
         Dim font As Font
         If hasText Then
            font = _hasTextFont
         Else
            font = _noTextFont
         End If
         Dim textSize As SizeF = graphics.MeasureString(text, font)
         Dim rect As Rectangle = New Rectangle(CInt(CSng(topRight.X) - textSize.Width + 0.5), CInt(CSng(topRight.Y) + 0.5), CInt(textSize.Width + 0.5F), CInt(textSize.Height + 0.5F))

         graphics.FillRectangle(_alphaBrush, rect)

         Dim textColor As Color
         If hasText Then
            textColor = Color.Blue
         Else
            textColor = Color.Gray
         End If
         TextRenderer.DrawText(graphics, text, font, rect, textColor, Color.Transparent)
      End If

      If isDisabled Then
         Dim size As Double
         If isView Then
            size = 30
         Else
            size = 20
         End If
         Dim transformedBounds As LeadRectD = GeometryTools.GetBoundingRect(corners)
         If isView Then
            ' Keep the size reasonable when the page scales
            size = GetScaledRender(bounds, 0.2, size)
         End If

         ' Get the top-right point
         Dim topLeft As LeadPointD = corners(0)
         Dim i As Integer = 1
         Do While i < corners.Length
            If corners(i).X < topLeft.X Then
               topLeft.X = corners(i).X
            End If
            If corners(i).Y < topLeft.Y Then
               topLeft.Y = corners(i).Y
            End If
            i += 1
         Loop

         Dim triangleLength As Double = (size * 1.8)
         Using path As GraphicsPath = New GraphicsPath()
            path.AddLine(CSng(topLeft.X), CSng(topLeft.Y), CSng(topLeft.X + triangleLength), CSng(topLeft.Y))
            path.AddLine(CSng(topLeft.X + triangleLength), CSng(topLeft.Y), CSng(topLeft.X), CSng(topLeft.Y + triangleLength))
            path.CloseFigure()

            graphics.FillPath(Brushes.DarkRed, path)
         End Using

         Dim disabledPageBitmap As Bitmap = Resources.DisabledPage
         graphics.DrawImage(disabledPageBitmap, CSng(topLeft.X), CSng(topLeft.Y), CSng(triangleLength) / 2.0F, CSng(triangleLength) / 2.0F)
         graphics.FillRectangle(_alphaBrush, CSng(transformedBounds.X), CSng(transformedBounds.Y), CSng(transformedBounds.Width), CSng(transformedBounds.Height))
      End If
   End Sub

   Private Shared Function GetScaledRender(ByVal bounds As LeadRectD, ByVal maxSizeRatio As Double, ByVal original As Double) As Double
      Dim shortSide As Double = Math.Min(bounds.Width, bounds.Height)
      Dim sizeRatio As Double = Math.Min(maxSizeRatio, original / shortSide)
      original = sizeRatio * shortSide
      Return original
   End Function

   Private Sub SaveDocumentBegin()
      Me.BeginBusyOperation()
      ShowBusyDialog(False, "Updating the document annotations")
   End Sub

   Private Function SaveDocumentInThread() As Boolean
      _documentViewer.PrepareToSave()
      Return True
   End Function

   Private Sub SaveDocumentThenInvoke()
      SaveDocument(_documentViewer.Document)
   End Sub

   Private Sub SaveDocumentError(ex As Exception)
      Helper.ShowError(Me, ex)
   End Sub

   Private Sub SaveDocument()
      ' If any of the annotation containers have been modified, save it into the document so the converter gets the latest version
      Dim annotations As DocumentViewerAnnotations = _documentViewer.Annotations
      If annotations IsNot Nothing AndAlso annotations.IsContainerModified(0) Then
         Dim operation As BusyOperation(Of Boolean) = New BusyOperation(Of Boolean)("Updating the document annotations")
         operation.Begin = AddressOf SaveDocumentBegin
         operation.InThread = AddressOf SaveDocumentInThread
         operation.End = AddressOf EndBusyOperation
         operation.ThenInvoke = AddressOf SaveDocumentThenInvoke
         operation.Error = AddressOf SaveDocumentError

         operation.Run(Me)
      Else
         ' Save it directly
         SaveDocument(_documentViewer.Document)
      End If
   End Sub

   Private Sub SaveDocument(document As LEADDocument)
      Dim run As Boolean = False

      ' Collect the options
      Using dlg As DocumentConverterDialog = New DocumentConverterDialog()
         dlg.Preferences = _converterPreferences.Clone()
         dlg.InputDocument = document
         If dlg.ShowDialog(Me) = DialogResult.OK Then
            run = True
            _converterPreferences = dlg.Preferences.Clone()
         End If
      End Using

      ' Run it
      If run Then
         Using dlg As DocumentConverterRunner = New DocumentConverterRunner()
            dlg.Preferences = _converterPreferences
            dlg.InputDocument = document
            dlg.Cache = _cache
            dlg.ShowDialog(Me)
         End Using
      End If
   End Sub

   Private Shared ReadOnly _emailRegex As New Regex("[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?")

   Private Sub RunValueLink(linkValue As String)
      ' Check if this is an email address
      If Not linkValue.ToLower().StartsWith("mailto:") AndAlso _emailRegex.IsMatch(linkValue) Then
         ' Yes,
         linkValue = Convert.ToString("mailto:") & linkValue
      End If

      Dim hasRun As Boolean = False

      Try
         ' Try default
         Process.Start(linkValue)
         hasRun = True
      Catch
      End Try

      If Not hasRun Then
         ' Error, ask use what to do with this, application
         Using dlg As LinkValueDialog = New LinkValueDialog()
            dlg.LinkValue = linkValue
            dlg.ShowDialog(Me)
         End Using
      End If
   End Sub

   Private Function CheckPrinters() As Boolean
      If _pageSettings Is Nothing Then
         Helper.ShowError(Me, "No printers were found on this machine. Install a printer then try again")
         Return False
      End If

      Return True
   End Function

   Private Sub PrintSetup()
      If Not CheckPrinters() Then
         Return
      End If

      Using dlg As PageSetupDialog = New PageSetupDialog()
         dlg.PageSettings = _pageSettings
         dlg.ShowDialog()
      End Using
   End Sub

   Private Sub PrintDocument()
      If Not CheckPrinters() Then
         Return
      End If

      Dim pageCount As Integer = _documentViewer.PageCount
      If pageCount = 0 Then
         Return
      End If

      Using printDocument__1 As PrintDocument = New PrintDocument()
         printDocument__1.PrinterSettings.MinimumPage = 1
         printDocument__1.PrinterSettings.MaximumPage = pageCount
         printDocument__1.PrinterSettings.FromPage = 1
         printDocument__1.PrinterSettings.ToPage = pageCount
         printDocument__1.DefaultPageSettings = _pageSettings

         Using dlg As PrintDialog = New PrintDialog()
            dlg.Document = printDocument__1
            dlg.PrinterSettings = printDocument__1.PrinterSettings
            dlg.AllowCurrentPage = True
            dlg.AllowSomePages = True
            If dlg.ShowDialog(Me) <> DialogResult.OK Then
               Return
            End If
         End Using

         Dim document As LEADDocument = _documentViewer.Document
         Dim annRenderingEngine As AnnRenderingEngine = Nothing
         If _documentViewer.Annotations IsNot Nothing AndAlso _documentViewer.Annotations.AutomationManager IsNot Nothing Then
            annRenderingEngine = _documentViewer.Annotations.AutomationManager.RenderingEngine
         End If

         Dim pageNumber As Integer = printDocument__1.PrinterSettings.FromPage

         Dim printPageHandler As PrintPageEventHandler = Sub(sender, e)
                                                            ' Print next undeleted page
                                                            Dim page As DocumentPage = Nothing
                                                            Do
                                                               page = document.Pages(pageNumber - 1)
                                                               If page.IsDeleted Then

                                                                  page = Nothing
                                                                  pageNumber += 1
                                                               End If
                                                            Loop While page Is Nothing AndAlso pageNumber <= printDocument__1.PrinterSettings.ToPage

                                                            If page IsNot Nothing Then

                                                               PrintPage(document, pageNumber, annRenderingEngine, printDocument__1, e)
                                                               pageNumber += 1
                                                            End If

                                                            e.HasMorePages = (pageNumber <= printDocument__1.PrinterSettings.ToPage)
                                                            If Not e.HasMorePages Then
                                                               pageNumber = 1
                                                            End If
                                                         End Sub

         AddHandler printDocument__1.PrintPage, printPageHandler

         Try

            Using dlg As PrintPreviewDialog = New PrintPreviewDialog()
               dlg.Document = printDocument__1
               dlg.ShowDialog(Me)
            End Using
         Catch ex As Exception
            Helper.ShowError(Me, ex)
         Finally
            RemoveHandler printDocument__1.PrintPage, printPageHandler
         End Try
      End Using
   End Sub

   Private Sub PrintPage(document As LEADDocument, pageNumber As Integer, annRenderingEngine As AnnRenderingEngine, printDocument As PrintDocument, e As PrintPageEventArgs)
      Dim page As DocumentPage = document.Pages(pageNumber - 1)

      ' Get page size in pixels
      Dim pixelSize As LeadSize = document.SizeToPixels(page.Size)
      ' Convert to DPI
      Dim size As LeadSize = LeadSizeD.Create(pixelSize.Width * 96.0 / page.Resolution, pixelSize.Height * 96.0 / page.Resolution).ToLeadSize()
      ' Fit in the margin bounds
      Dim destRect As LeadRect = LeadRect.Create(e.MarginBounds.X, e.MarginBounds.Y, e.MarginBounds.Width, e.MarginBounds.Height)
      destRect = RasterImage.CalculatePaintModeRectangle(size.Width, size.Height, destRect, RasterPaintSizeMode.Fit, RasterPaintAlignMode.Center, RasterPaintAlignMode.Center)

      ' Get the page image
      Using rasterImage__1 As RasterImage = page.GetImage()
         ' Render annotations
         If annRenderingEngine IsNot Nothing Then
            Dim annContainer As AnnContainer = page.GetAnnotations(False)
            If annContainer IsNot Nothing Then
               annRenderingEngine.RenderOnImage(annContainer, rasterImage__1)
            End If
         End If

         ' Convert to GDI+ bitmap and print it
         Using bitmap As Image = RasterImageConverter.ConvertToImage(rasterImage__1, ConvertToImageOptions.None)
            e.Graphics.DrawImage(bitmap, destRect.X, destRect.Y, destRect.Width, destRect.Height)
         End Using
      End Using
   End Sub
End Class
