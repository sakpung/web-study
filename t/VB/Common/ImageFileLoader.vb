' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Windows.Forms
Imports System.Text
Imports System.Drawing
Imports System.Collections.Generic

Imports Leadtools
Imports Leadtools.Codecs
Imports Leadtools.WinForms.CommonDialogs.File

Public Class ImageFileLoader
   Private Shared _filterIndex As Integer = 1
   Private _fileName As String
   Private _filters() As RasterOpenDialogLoadFormat
   Private _image As RasterImage
   Private _loadOnlyOnePage As Boolean = False
   Private _firstPage As Integer
   Private _lastPage As Integer
   Private _showLoadPagesDialog As Boolean = False
   Private _showPdfOptions As Boolean = True
   Private _showXpsOptions As Boolean = True
   Private _loadCorrupted As Boolean = False

   Private _showXlsOptions As Boolean = True
   Private _showRasterizeDocumentOptions As Boolean = True

   Private _showAnzOptions As Boolean = True
   Private _showVffOptions As Boolean = True

   Private _showVectorOptions As Boolean = True


   Private _multiSelect As Boolean = False
   Private _useGdiPlus As Boolean = False
   Private _images As List(Of ImageInformation) = New List(Of ImageInformation)()
   Private _openDialogInitialPath As String
   Private _preferVector As Boolean = False

   Public Sub New()
   End Sub

   Public Property FileName() As String
      Get
         Return _fileName
      End Get
      Set(ByVal value As String)
         _fileName = value
      End Set
   End Property

   Public ReadOnly Property Image() As RasterImage
      Get
         Return _image
      End Get
   End Property

   Public ReadOnly Property Images() As List(Of ImageInformation)
      Get
         Return _images
      End Get
   End Property

   Public Property Filters() As RasterOpenDialogLoadFormat()
      Get
         Return _filters
      End Get
      Set(ByVal value As RasterOpenDialogLoadFormat())
         _filters = value
      End Set
   End Property

   Public Property ShowLoadPagesDialog() As Boolean
      Get
         Return _showLoadPagesDialog
      End Get
      Set(ByVal value As Boolean)
         _showLoadPagesDialog = value
      End Set
   End Property

   Public Property LoadOnlyOnePage() As Boolean
      Get
         Return _loadOnlyOnePage
      End Get
      Set(ByVal value As Boolean)
         _loadOnlyOnePage = value
      End Set
   End Property

   Public Shared Property FilterIndex() As Integer
      Get
         Return _filterIndex
      End Get
      Set(ByVal value As Integer)
         _filterIndex = value
      End Set
   End Property

   Public ReadOnly Property FirstPage() As Integer
      Get
         Return _firstPage
      End Get
   End Property

   Public ReadOnly Property LastPage() As Integer
      Get
         Return _lastPage
      End Get
   End Property

   Public Property ShowPdfOptions() As Boolean
      Get
         Return _showPdfOptions
      End Get
      Set(ByVal value As Boolean)
         _showPdfOptions = value
      End Set
   End Property

   Public Property ShowXpsOptions() As Boolean
      Get
         Return _showXpsOptions
      End Get
      Set(ByVal value As Boolean)
         _showXpsOptions = value
      End Set
   End Property

   Public Property ShowXlsOptions() As Boolean
      Get
         Return _showXlsOptions
      End Get
      Set(ByVal value As Boolean)
         _showXlsOptions = value
      End Set
   End Property

   Public Property ShowRasterizeDocumentOptions() As Boolean
      Get
         Return _showRasterizeDocumentOptions
      End Get
      Set(ByVal value As Boolean)
         _showRasterizeDocumentOptions = value
      End Set
   End Property

   Public Property ShowAnzOptions() As Boolean
      Get
         Return _showAnzOptions
      End Get
      Set(ByVal value As Boolean)
         _showAnzOptions = value
      End Set
   End Property

   Public Property ShowVffOptions() As Boolean
      Get
         Return _showVffOptions
      End Get
      Set(ByVal value As Boolean)
         _showVffOptions = value
      End Set
   End Property

   Public Property ShowVectorOptions() As Boolean
      Get
         Return _showVectorOptions
      End Get
      Set(ByVal value As Boolean)
         _showVectorOptions = value
      End Set
   End Property

   Public Property MultiSelect() As Boolean
      Get
         Return _multiSelect
      End Get
      Set(ByVal value As Boolean)
         _multiSelect = value
      End Set
   End Property

   Public Property LoadCorrupted() As Boolean
      Get
         Return _loadCorrupted
      End Get
      Set(value As Boolean)
         _loadCorrupted = value
      End Set
   End Property

   Public Property PreferVector() As Boolean
      Get
         Return _preferVector
      End Get
      Set(value As Boolean)
         _preferVector = value
      End Set
   End Property

   Public Property UseGdiPlus() As Boolean
      Get
         Return _useGdiPlus
      End Get
      Set(ByVal value As Boolean)
         _useGdiPlus = value
      End Set
   End Property

   Public Property OpenDialogInitialPath() As String
      Get
         Return _openDialogInitialPath
      End Get
      Set(ByVal value As String)
         _openDialogInitialPath = value
      End Set
   End Property

   Private ReadOnly Property Is64() As Boolean
      Get
         Return IntPtr.Size = 8
      End Get
   End Property

   Private ReadOnly Property maxDocPages() As Integer
      Get
         If Is64 Then
            Return 200
         Else
            Return 96
         End If
      End Get
   End Property

   Private Const maxDocResolution As Integer = 96

   Private Function SetDocumentLoadResultion(ByVal codecs As RasterCodecs, ByVal info As CodecsImageInfo, ByVal firstPage As Integer, ByVal lastPage As Integer) As Boolean
      If (firstPage < 1) Then
         firstPage = 1
      End If

      If (Not Is64) Then ' No limit for x64
         If info.Document.IsDocumentFile Then ' if the file is a document file format
            If (((lastPage = -1) AndAlso (info.TotalPages > maxDocPages)) OrElse (lastPage - firstPage + 1 > maxDocPages)) AndAlso ((codecs.Options.RasterizeDocument.Load.XResolution > maxDocResolution) OrElse (codecs.Options.RasterizeDocument.Load.YResolution > maxDocResolution)) Then
               Dim promptMessage As String = String.Format("You are trying to load a document file which has more than {0} pages at {1} dpi.{2}{2}", maxDocPages, codecs.Options.RasterizeDocument.Load.XResolution, Environment.NewLine)
               promptMessage = String.Format("{0}This can cause performance issues on machines with limited resources.{1}{1}", promptMessage, Environment.NewLine)
               promptMessage = String.Format("{0}Click 'Yes' to reduce the resolution and continue loading or click 'No' to continue loading with the current resolution.", promptMessage)

               Dim result As DialogResult = MessageBox.Show(promptMessage, "Warning", MessageBoxButtons.YesNoCancel)
               Select Case result
                  Case DialogResult.Yes
                     codecs.Options.RasterizeDocument.Load.XResolution = 96
                     codecs.Options.RasterizeDocument.Load.YResolution = 96
                  Case DialogResult.No
                  Case DialogResult.Cancel
                     Return False
               End Select
            End If
         End If
      End If
      Return True
   End Function

   'Use this load to load a specific image without showing the open dialog
   Public Function Load(ByVal owner As IWin32Window, ByVal fileName As String, ByVal codecs As RasterCodecs, ByVal firstPage As Integer, ByVal lastPage As Integer) As Boolean
      _fileName = fileName
      _firstPage = firstPage
      _lastPage = lastPage

      Using wait As WaitCursor = New WaitCursor()
         Using info As CodecsImageInfo = codecs.GetInformation(fileName, True)

            If (Not SetDocumentLoadResultion(codecs, info, firstPage, lastPage)) Then
               Return False
            End If
         End Using

         _image = codecs.Load(fileName, 0, CodecsLoadByteOrder.BgrOrGray, _firstPage, _lastPage)
      End Using

      Return True
   End Function

   'Use this load to load an image using the open dialog
   Public Function Load(ByVal owner As IWin32Window, ByVal codecs As RasterCodecs, ByVal autoLoad As Boolean) As Integer
      Using ofd As New RasterOpenDialog(codecs)

         ofd.DereferenceLinks = True
         ofd.CheckFileExists = False
         ofd.CheckPathExists = True
         ofd.EnableSizing = True
         ofd.Filter = Filters
         ofd.FilterIndex = _filterIndex
         ofd.LoadFileImage = False
         ofd.LoadOptions = False
         ofd.LoadRotated = True
         ofd.LoadCompressed = True
         ofd.LoadMultithreaded = codecs.Options.Jpeg.Load.Multithreaded
         ofd.ShowLoadMultithreaded = True
         ofd.Multiselect = _multiSelect
         ofd.UseGdiPlus = UseGdiPlus
         ofd.ShowGeneralOptions = True
         ofd.ShowLoadCompressed = True
         ofd.ShowLoadOptions = True
         ofd.ShowLoadRotated = True
         ofd.ShowMultipage = True
         ofd.ShowPdfOptions = ShowPdfOptions
         ofd.ShowXpsOptions = ShowXpsOptions
         ofd.ShowXlsOptions = ShowXlsOptions
         ofd.ShowRasterizeDocumentOptions = ShowRasterizeDocumentOptions
         ofd.EnableFileInfoModeless = True
         ofd.EnableFileInfoResizing = True

         ofd.ShowAnzOptions = ShowAnzOptions
         ofd.ShowVffOptions = ShowVffOptions

         ofd.ShowVectorOptions = ShowVectorOptions

         ofd.ShowPreview = True
         ofd.ShowProgressive = True
         ofd.ShowRasterOptions = True
         ofd.ShowTotalPages = True
         ofd.ShowDeletePage = True
         ofd.ShowFileInformation = True
         ofd.UseFileStamptoPreview = True
         ofd.PreviewWindowVisible = True
         ofd.Title = "LEADTOOLS Open Dialog"
         ofd.FileName = FileName
         ofd.LoadCorrupted = LoadCorrupted
         ofd.PreferVector = PreferVector
         If Not String.IsNullOrEmpty(_openDialogInitialPath) Then
            ofd.InitialDirectory = _openDialogInitialPath
         End If

         If ofd.ShowDialog(owner) = DialogResult.OK Then
            For Each item As RasterDialogFileData In ofd.OpenedFileData
               FileName = item.Name

               _filterIndex = ofd.FilterIndex

               ' Set the RasterizeDocument load options before calling GetInformation
               codecs.Options.RasterizeDocument.Load.PageWidth = item.Options.RasterizeDocumentOptions.PageWidth
               codecs.Options.RasterizeDocument.Load.PageHeight = item.Options.RasterizeDocumentOptions.PageHeight
               codecs.Options.RasterizeDocument.Load.LeftMargin = item.Options.RasterizeDocumentOptions.LeftMargin
               codecs.Options.RasterizeDocument.Load.TopMargin = item.Options.RasterizeDocumentOptions.TopMargin
               codecs.Options.RasterizeDocument.Load.RightMargin = item.Options.RasterizeDocumentOptions.RightMargin
               codecs.Options.RasterizeDocument.Load.BottomMargin = item.Options.RasterizeDocumentOptions.BottomMargin
               codecs.Options.RasterizeDocument.Load.Unit = item.Options.RasterizeDocumentOptions.Unit
               codecs.Options.RasterizeDocument.Load.XResolution = item.Options.RasterizeDocumentOptions.XResolution
               codecs.Options.RasterizeDocument.Load.YResolution = item.Options.RasterizeDocumentOptions.YResolution
               codecs.Options.RasterizeDocument.Load.SizeMode = item.Options.RasterizeDocumentOptions.SizeMode

               If item.FileInfo.Format = RasterImageFormat.Afp Or item.FileInfo.Format = RasterImageFormat.Ptoca Then
                  codecs.Options.Ptoka.Load.Resolution = codecs.Options.RasterizeDocument.Load.XResolution
               End If

               ' Set the user Options
               codecs.Options.Load.Passes = item.Passes
               codecs.Options.Load.Rotated = item.LoadRotated
               codecs.Options.Load.Compressed = item.LoadCompressed
               codecs.Options.Load.LoadCorrupted = ofd.LoadCorrupted
               codecs.Options.Load.PreferVector = ofd.PreferVector
               codecs.Options.Jpeg.Load.Multithreaded = item.LoadMultithreaded

               Select Case item.Options.FileType
                  Case RasterDialogFileOptionsType.Meta
                     ' Set the user options
                     codecs.Options.Wmf.Load.XResolution = item.Options.MetaOptions.XResolution
                     codecs.Options.Wmf.Load.YResolution = item.Options.MetaOptions.XResolution
                     Exit Select

                  Case RasterDialogFileOptionsType.Pdf
                     If codecs.Options.Pdf.Load.UsePdfEngine Then
                        ' Set the user options
                        codecs.Options.Pdf.Load.DisplayDepth = item.Options.PdfOptions.DisplayDepth
                        codecs.Options.Pdf.Load.GraphicsAlpha = item.Options.PdfOptions.GraphicsAlpha
                        codecs.Options.Pdf.Load.TextAlpha = item.Options.PdfOptions.TextAlpha
                        codecs.Options.Pdf.Load.UseLibFonts = item.Options.PdfOptions.UseLibFonts
                     End If

                     Exit Select

                  Case RasterDialogFileOptionsType.Misc
                     Select Case item.FileInfo.Format
                        Case RasterImageFormat.Jbig
                           ' Set the user options
                           codecs.Options.Jbig.Load.Resolution = New LeadSize(item.Options.MiscOptions.XResolution, item.Options.MiscOptions.YResolution)
                           Exit Select

                        Case RasterImageFormat.Cmw
                           ' Set the user options
                           codecs.Options.Jpeg2000.Load.CmwResolution = New LeadSize(item.Options.MiscOptions.XResolution, item.Options.MiscOptions.YResolution)
                           Exit Select

                        Case RasterImageFormat.Jp2
                           ' Set the user options
                           codecs.Options.Jpeg2000.Load.Jp2Resolution = New LeadSize(item.Options.MiscOptions.XResolution, item.Options.MiscOptions.YResolution)
                           Exit Select

                        Case RasterImageFormat.J2k
                           ' Set the user options
                           codecs.Options.Jpeg2000.Load.J2kResolution = New LeadSize(item.Options.MiscOptions.XResolution, item.Options.MiscOptions.YResolution)
                           Exit Select
                     End Select

                     Exit Select

                  Case RasterDialogFileOptionsType.Xls
                     ' Set the user options
                     codecs.Options.Xls.Load.MultiPageSheet = item.Options.XlsOptions.MultiPageSheet
                     codecs.Options.Xls.Load.ShowHiddenSheet = item.Options.XlsOptions.ShowHiddenSheet
#If LEADTOOLS_V20_OR_LATER Then
                     codecs.Options.Xls.Load.MultiPageUseSheetWidth = item.Options.XlsOptions.MultiPageUseSheetWidth
                     codecs.Options.Xls.Load.PageOrderDownThenOver = item.Options.XlsOptions.PageOrderDownThenOver
                     codecs.Options.Xls.Load.MultiPageEnableMargins = item.Options.XlsOptions.MultiPageEnableMargins
#End If ' #if LEADTOOLS_V20_OR_LATER


                  Case RasterDialogFileOptionsType.Vff
                     ' Set the user options
                     codecs.Options.Vff.Load.View = item.Options.VffOptions.View
                  Case RasterDialogFileOptionsType.Anz
                     ' Set the user options
                     codecs.Options.Anz.Load.View = item.Options.AnzOptions.View

                  Case RasterDialogFileOptionsType.Vector
                     ' Set the user options
                     codecs.Options.Vector.Load.BackgroundColor = item.Options.VectorOptions.Options.BackgroundColor
                     codecs.Options.Vector.Load.BitsPerPixel = item.Options.VectorOptions.Options.BitsPerPixel
                     codecs.Options.Vector.Load.ForceBackgroundColor = item.Options.VectorOptions.Options.ForceBackgroundColor
                     codecs.Options.Vector.Load.ViewHeight = item.Options.VectorOptions.Options.ViewHeight
                     codecs.Options.Vector.Load.ViewMode = item.Options.VectorOptions.Options.ViewMode
                     codecs.Options.Vector.Load.ViewWidth = item.Options.VectorOptions.Options.ViewWidth

               End Select

               Dim firstPage As Integer = 1
               Dim lastPage As Integer = 1
               Dim infoTotalPages As Integer

               Dim info As CodecsImageInfo

               Using wait As New WaitCursor
                  info = codecs.GetInformation(FileName, True)

                  infoTotalPages = info.TotalPages

               End Using

               If _showLoadPagesDialog Then
                  firstPage = 1
                  lastPage = infoTotalPages

                  If firstPage <> lastPage Then
                     Using dlg As New ImageFileLoaderPagesDialog(infoTotalPages, LoadOnlyOnePage)
                        If dlg.ShowDialog(owner) = DialogResult.OK Then
                           firstPage = dlg.FirstPage
                           lastPage = dlg.LastPage
                        Else
                           info.Dispose()
                           Return 0
                        End If
                     End Using
                  End If
               Else
                  firstPage = item.PageNumber
                  lastPage = item.PageNumber
               End If

               _firstPage = firstPage
               _lastPage = lastPage

               If (Not SetDocumentLoadResultion(codecs, info, firstPage, lastPage)) Then
                  info.Dispose()
                  Return 0
               End If

               If autoLoad Then
                  Using wait As New WaitCursor
                     _image = codecs.Load(FileName, 0, CodecsLoadByteOrder.BgrOrGray, firstPage, lastPage)
                     If (codecs.LoadStatus <> RasterExceptionCode.Success) Then
                        Dim message As String = String.Format("The image was only partially loaded due to error: {0}", codecs.LoadStatus.ToString())
                        Messager.Show(Nothing, message, MessageBoxIcon.Information, MessageBoxButtons.OK)
                     End If
                     If (_image IsNot Nothing) Then
                        _image.CustomData.Add("IsBigTiff", info.Tiff.IsBigTiff)
                        _images.Add(New ImageInformation(_image, item.Name))
                     End If
                  End Using
               End If

               info.Dispose()

            Next item
         End If

         Return ofd.OpenedFileData.Count
      End Using
   End Function
End Class
