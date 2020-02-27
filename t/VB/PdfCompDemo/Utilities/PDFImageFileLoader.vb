' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Windows.Forms
Imports System.Text
Imports System.Drawing

Imports Leadtools
Imports Leadtools.Codecs
Imports Leadtools.WinForms.CommonDialogs.File

#If (Not LEADTOOLS_V17_OR_LATER) Then
Imports LeadPoint = System.Drawing.Point
Imports LeadSize = System.Drawing.Size
Imports LeadRect = System.Drawing.Rectangle
#End If ' #if !LEADTOOLS_V17_OR_LATER

#If LEADTOOLS_V17_OR_LATER Then
Imports Leadtools.Drawing
#End If ' #if LEADTOOLS_V17_OR_LATER

Public Class PdfImageFileLoader
   Private Shared _filterIndex As Integer = 1
   Private _fileName As String
   Private _filters As RasterOpenDialogLoadFormat()
   Private _image As RasterImage
   Private _loadOnlyOnePage As Boolean = False
   Private _firstPage As Integer
   Private _lastPage As Integer
   Private _showLoadPagesDialog As Boolean = False
   Private _FileFormatType As RasterDialogFileOptionsType
   Private Shared _firstPdfLoaded As Boolean = False

   Public Sub New()
   End Sub

   Public Property FileName() As String
      Get
         Return _fileName
      End Get
      Set(value As String)
         _fileName = value
      End Set
   End Property

   Public ReadOnly Property Image() As RasterImage
      Get
         Return _image
      End Get
   End Property

   Public Property Filters() As RasterOpenDialogLoadFormat()
      Get
         Return _filters
      End Get
      Set(value As RasterOpenDialogLoadFormat())
         _filters = value
      End Set
   End Property

   Public Property ShowLoadPagesDialog() As Boolean
      Get
         Return _showLoadPagesDialog
      End Get
      Set(value As Boolean)
         _showLoadPagesDialog = value
      End Set
   End Property

   Public Property LoadOnlyOnePage() As Boolean
      Get
         Return _loadOnlyOnePage
      End Get
      Set(value As Boolean)
         _loadOnlyOnePage = value
      End Set
   End Property

   Public Shared Property FilterIndex() As Integer
      Get
         Return _filterIndex
      End Get
      Set(value As Integer)
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

   Public ReadOnly Property FileFormatType() As RasterDialogFileOptionsType
      Get
         Return _FileFormatType
      End Get
   End Property

   Public Function Load(ByVal owner As IWin32Window, ByVal codecs As RasterCodecs, ByVal autoLoad As Boolean) As Boolean
#If LEADTOOLS_V16_OR_LATER AndAlso (Not LEADTOOLS_V17_OR_LATER) Then
	  ' Load using the RasterizeDocument options
	  codecs.Options.RasterizeDocument.Load.Enabled = True
#End If

      Dim ofd As RasterOpenDialog = New RasterOpenDialog(codecs)

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
      ofd.Multiselect = False
      ofd.ShowGeneralOptions = True
      ofd.ShowLoadCompressed = True
      ofd.ShowLoadOptions = True
      ofd.ShowLoadRotated = True
      ofd.ShowMultipage = True
      ofd.ShowPdfOptions = True
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
#If LEADTOOLS_V16_OR_LATER Then
      ofd.ShowRasterizeDocumentOptions = True
      ofd.ShowXlsOptions = True
#End If
      Dim ok As Boolean = False

      If ofd.ShowDialog(owner) = System.Windows.Forms.DialogResult.OK Then
         Dim firstItem As RasterDialogFileData = TryCast(ofd.OpenedFileData(0), RasterDialogFileData)
         FileName = firstItem.Name

         ok = True

         _filterIndex = ofd.FilterIndex

         Dim info As CodecsImageInfo

         Using wait As WaitCursor = New WaitCursor()
            info = codecs.GetInformation(FileName, True)
         End Using

         If info.Format = RasterImageFormat.RasPdf OrElse info.Format = RasterImageFormat.RasPdfG31Dim OrElse info.Format = RasterImageFormat.RasPdfG32Dim OrElse info.Format = RasterImageFormat.RasPdfG4 OrElse info.Format = RasterImageFormat.RasPdfJpeg OrElse info.Format = RasterImageFormat.RasPdfJpeg422 OrElse info.Format = RasterImageFormat.RasPdfJpeg411 Then
            If (Not codecs.Options.Pdf.IsEngineInstalled) Then
#If (Not LEADTOOLS_V17_OR_LATER) Then
				  Dim dlg As PdfEngineDialog = New PdfEngineDialog()
				  If dlg.ShowDialog(owner) <> System.Windows.Forms.DialogResult.OK Then
					 Return False
				  End If
#End If
            End If
         End If

#If LEADTOOLS_V16_OR_LATER Then
         ' Set the RasterizeDocument load options before calling GetInformation
#If (Not LEADTOOLS_V17_OR_LATER) Then
			codecs.Options.RasterizeDocument.Load.Enabled = firstItem.Options.RasterizeDocumentOptions.Enabled
#End If
         codecs.Options.RasterizeDocument.Load.PageWidth = firstItem.Options.RasterizeDocumentOptions.PageWidth
         codecs.Options.RasterizeDocument.Load.PageHeight = firstItem.Options.RasterizeDocumentOptions.PageHeight
         codecs.Options.RasterizeDocument.Load.LeftMargin = firstItem.Options.RasterizeDocumentOptions.LeftMargin
         codecs.Options.RasterizeDocument.Load.TopMargin = firstItem.Options.RasterizeDocumentOptions.TopMargin
         codecs.Options.RasterizeDocument.Load.RightMargin = firstItem.Options.RasterizeDocumentOptions.RightMargin
         codecs.Options.RasterizeDocument.Load.BottomMargin = firstItem.Options.RasterizeDocumentOptions.BottomMargin
         codecs.Options.RasterizeDocument.Load.Unit = firstItem.Options.RasterizeDocumentOptions.Unit
         codecs.Options.RasterizeDocument.Load.XResolution = firstItem.Options.RasterizeDocumentOptions.XResolution
         codecs.Options.RasterizeDocument.Load.YResolution = firstItem.Options.RasterizeDocumentOptions.YResolution
         codecs.Options.RasterizeDocument.Load.SizeMode = firstItem.Options.RasterizeDocumentOptions.SizeMode
#End If

         ' Set the user Options
         codecs.Options.Load.Passes = firstItem.Passes
         codecs.Options.Load.Rotated = firstItem.LoadRotated
         codecs.Options.Load.Compressed = firstItem.LoadCompressed
         _FileFormatType = firstItem.Options.FileType

         Select Case firstItem.Options.FileType
            Case RasterDialogFileOptionsType.Meta
               ' Set the user options               
               codecs.Options.Wmf.Load.XResolution = firstItem.Options.MetaOptions.XResolution
               codecs.Options.Wmf.Load.YResolution = firstItem.Options.MetaOptions.XResolution

               Exit Select

            Case RasterDialogFileOptionsType.Pdf
               If codecs.Options.Pdf.IsEngineInstalled Then
#If (Not LEADTOOLS_V175_OR_LATER) Then
						If (Not _firstPdfLoaded) Then
						   Dim DPIOptions As PdfDPIOptions = New PdfDPIOptions()

						   If DPIOptions.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
							  codecs.Options.Pdf.Load.XResolution = DPIOptions.XResolution
							  codecs.Options.Pdf.Load.YResolution = DPIOptions.YResolution
							  _firstPdfLoaded = True
						   Else
							  codecs.Options.Pdf.Load.XResolution = 150
							  codecs.Options.Pdf.Load.YResolution = 150
						   End If
						Else
						   ' Set the user options
						   codecs.Options.Pdf.Load.DisplayDepth = firstItem.Options.PdfOptions.DisplayDepth
						   codecs.Options.Pdf.Load.GraphicsAlpha = firstItem.Options.PdfOptions.GraphicsAlpha
						   codecs.Options.Pdf.Load.TextAlpha = firstItem.Options.PdfOptions.TextAlpha
						   codecs.Options.Pdf.Load.UseLibFonts = firstItem.Options.PdfOptions.UseLibFonts
						End If
#End If
               End If

               Exit Select

            Case RasterDialogFileOptionsType.Misc
               Select Case firstItem.FileInfo.Format
                  Case RasterImageFormat.Jbig
                     ' Set the user options
                     codecs.Options.Jbig.Load.Resolution = New LeadSize(firstItem.Options.MiscOptions.XResolution, firstItem.Options.MiscOptions.YResolution)
                     Exit Select

                  Case RasterImageFormat.Cmw
                     ' Set the user options
                     codecs.Options.Jpeg2000.Load.CmwResolution = New LeadSize(firstItem.Options.MiscOptions.XResolution, firstItem.Options.MiscOptions.YResolution)
                     Exit Select

                  Case RasterImageFormat.Jp2
                     ' Set the user options
                     codecs.Options.Jpeg2000.Load.Jp2Resolution = New LeadSize(firstItem.Options.MiscOptions.XResolution, firstItem.Options.MiscOptions.YResolution)
                     Exit Select

                  Case RasterImageFormat.J2k
                     ' Set the user options
                     codecs.Options.Jpeg2000.Load.J2kResolution = New LeadSize(firstItem.Options.MiscOptions.XResolution, firstItem.Options.MiscOptions.YResolution)
                     Exit Select
               End Select

               Exit Select
         End Select

         Dim firstPage_Renamed As Integer = 1
         Dim lastPage_Renamed As Integer = 1

         If ShowLoadPagesDialog Then
            firstPage_Renamed = 1
            lastPage_Renamed = info.TotalPages

            If firstPage_Renamed <> lastPage_Renamed Then
               Dim dlg As ImageFileLoaderPagesDialog = New ImageFileLoaderPagesDialog(info.TotalPages, LoadOnlyOnePage)
               If dlg.ShowDialog(owner) = System.Windows.Forms.DialogResult.OK Then
                  firstPage_Renamed = dlg.FirstPage
                  lastPage_Renamed = dlg.LastPage
               Else
                  ok = False
               End If
            End If
         Else
            firstPage_Renamed = firstItem.PageNumber
            lastPage_Renamed = firstItem.PageNumber
         End If

         _firstPage = firstPage_Renamed
         _lastPage = lastPage_Renamed

         If autoLoad AndAlso ok Then
            Using wait As WaitCursor = New WaitCursor()
               _image = codecs.Load(FileName, 0, CodecsLoadByteOrder.BgrOrGray, firstPage_Renamed, lastPage_Renamed)
            End Using
         End If
      End If

      Return ok
   End Function
End Class

