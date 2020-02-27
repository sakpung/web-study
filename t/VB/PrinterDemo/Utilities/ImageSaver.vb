' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Windows.Forms
Imports System.Collections.Generic
Imports System.Drawing.Imaging
Imports System.Drawing

Imports Leadtools
Imports Leadtools.Codecs
Imports Leadtools.WinForms.CommonDialogs.File

Public Class ImageFileSaver
   Private _fileName As String
   Private _format As RasterImageFormat
   Private _fileTypeIndex As RasterDialogFileTypesIndex
   Private _fileSubTypeIndex As Integer
   Private _bitsPerPixel As Integer
   Private _firstPage As Integer
   Private _lastPage As Integer
   Private _savePageNumber As Integer
   Private _pageMode As CodecsSavePageMode
   Private _saveFormats As RasterSaveDialogFileFormatsList
   Private _autoSave As Boolean
   Private _pdfProfile As FileSavePdfProfiles

   Public Sub New()
      _fileName = String.Empty
      _bitsPerPixel = 24
      _firstPage = 0
      _lastPage = 0
      _savePageNumber = 1
      _pageMode = CodecsSavePageMode.Overwrite
      _saveFormats = Nothing
      _fileTypeIndex = RasterDialogFileTypesIndex.Lead
      _fileSubTypeIndex = CInt(RasterDialogCmpSubTypesIndex.Progressive)
      _autoSave = True
      _pdfProfile = FileSavePdfProfiles.Pdf14
   End Sub

   Public Property FileName() As String
      Get
         Return _fileName
      End Get
      Set(ByVal value As String)
         _fileName = value
      End Set
   End Property

   Public Property SaveFormats() As RasterSaveDialogFileFormatsList
      Get
         Return _saveFormats
      End Get
      Set(ByVal value As RasterSaveDialogFileFormatsList)
         _saveFormats = value
      End Set
   End Property

   Public Property FormatIndex() As RasterDialogFileTypesIndex
      Get
         Return _fileTypeIndex
      End Get
      Set(ByVal value As RasterDialogFileTypesIndex)
         _fileTypeIndex = value
      End Set
   End Property

   Public Property SubTypeIndex() As Integer
      Get
         Return _fileSubTypeIndex
      End Get
      Set(ByVal value As Integer)
         _fileSubTypeIndex = value
      End Set
   End Property

   Public ReadOnly Property Format() As RasterImageFormat
      Get
         Return _format
      End Get
   End Property

   Public ReadOnly Property BitsPerPixel() As Integer
      Get
         Return _bitsPerPixel
      End Get
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

   Public ReadOnly Property SavePageNumber() As Integer
      Get
         Return _savePageNumber
      End Get
   End Property

   Public ReadOnly Property PageMode() As CodecsSavePageMode
      Get
         Return _pageMode
      End Get
   End Property

   Public Property AutoSave() As Boolean
      Get
         Return _autoSave
      End Get
      Set(ByVal value As Boolean)
         _autoSave = value
      End Set
   End Property

   Public Property PdfProfile() As FileSavePdfProfiles
      Get
         Return _pdfProfile
      End Get

      Set(ByVal value As FileSavePdfProfiles)
         _pdfProfile = value
      End Set
   End Property

   Public Function Save(ByVal owner As IWin32Window, ByVal codecs As RasterCodecs, ByVal tempFiles As List(Of String), ByVal viewOutputFile As Boolean) As Boolean
      _format = RasterImageFormat.Unknown
      _firstPage = -1
      _lastPage = -1
      _savePageNumber = -1
      _pageMode = CodecsSavePageMode.Overwrite

      Dim dlg As RasterSaveDialog = New RasterSaveDialog(codecs)

      dlg.PromptOverwrite = True
      dlg.ShowFileOptionsBasicJ2kOptions = False
      dlg.ShowFileOptionsJ2kOptions = False
      dlg.ShowFileOptionsJbig2Options = False
      dlg.ShowPdfProfiles = True
      dlg.PdfProfile = PdfProfile
      dlg.ShowFileOptionsMultipage = True
      dlg.ShowFileOptionsProgressive = True
      dlg.ShowFileOptionsQualityFactor = True
      dlg.ShowFileOptionsStamp = True
      dlg.ShowOptions = True
      dlg.ShowQualityFactor = True
      dlg.PageNumber = SavePageNumber
      dlg.Title = "LEADTOOLS Save Dialog"
      dlg.EnableSizing = True
      dlg.FileName = FileName
      dlg.FileSubTypeIndex = _fileSubTypeIndex
      dlg.FileTypeIndex = _fileTypeIndex
      dlg.BitsPerPixel = 0

      If Nothing Is SaveFormats Then
         dlg.FileFormatsList = New RasterSaveDialogFileFormatsList(RasterDialogFileFormatDataContent.Default)
      Else
         dlg.FileFormatsList = SaveFormats
      End If

      If dlg.ShowDialog(owner) = DialogResult.OK Then
         Application.DoEvents()
         System.Windows.Forms.Cursor.Current = Cursors.WaitCursor
         FileName = dlg.FileName
         _fileSubTypeIndex = dlg.FileSubTypeIndex
         _fileTypeIndex = dlg.FileTypeIndex
         _format = dlg.Format
         _bitsPerPixel = dlg.BitsPerPixel
         _firstPage = dlg.PageNumber
         _lastPage = dlg.PageNumber
         _savePageNumber = dlg.PageNumber
         _pageMode = dlg.MultiPage

         If _autoSave Then
            Select Case dlg.Format
               Case RasterImageFormat.Abc
                  codecs.Options.Abc.Save.QualityFactor = dlg.AbcQualityFactor

                  Exit Select
#If Not LEADTOOLS_V20_OR_LATER Then
               Case RasterImageFormat.Ecw
                  codecs.Options.Ecw.Save.QualityFactor = dlg.QualityFactor

                  Exit Select
#End If ' #If Not LEADTOOLS_V20_OR_LATER Then
               Case RasterImageFormat.Png
                  codecs.Options.Png.Save.QualityFactor = dlg.QualityFactor
                  codecs.Options.Save.InitAlpha = True
                  Exit Select

               Case RasterImageFormat.PngIco
                  codecs.Options.Save.InitAlpha = True
                  Exit Select

               Case RasterImageFormat.Cmp
                  codecs.Options.Jpeg.Save.QualityFactor = dlg.QualityFactor
                  codecs.Options.Jpeg.Save.CmpQualityFactorPredefined = dlg.CmpQualityFactor

                  Exit Select
               Case RasterImageFormat.Xps
                  codecs.Options.Save.InitAlpha = True

                  Exit Select

               Case Else
                  codecs.Options.Jpeg.Save.QualityFactor = dlg.QualityFactor

                  Exit Select
            End Select

            codecs.Options.Jpeg.Save.SaveWithStamp = dlg.WithStamp
            codecs.Options.Jpeg.Save.StampWidth = dlg.StampWidth
            codecs.Options.Jpeg.Save.StampHeight = dlg.StampHeight
            codecs.Options.Jpeg.Save.StampBitsPerPixel = dlg.StampBitsPerPixel

            If (Format = RasterImageFormat.Cmw) OrElse (Format = RasterImageFormat.J2k) OrElse (Format = RasterImageFormat.Jp2) OrElse (Format = RasterImageFormat.TifJ2k) Then
               codecs.Options.Jpeg2000.Save.CompressionControl = dlg.FileJ2kOptions.CompressionControl
               codecs.Options.Jpeg2000.Save.CompressionRatio = dlg.FileJ2kOptions.CompressionRatio
               codecs.Options.Jpeg2000.Save.DecompositionLevels = dlg.FileJ2kOptions.DecompositionLevels
               codecs.Options.Jpeg2000.Save.DerivedQuantization = dlg.FileJ2kOptions.DerivedQuantization
               codecs.Options.Jpeg2000.Save.ImageAreaHorizontalOffset = dlg.FileJ2kOptions.ImageAreaHorizontalOffset
               codecs.Options.Jpeg2000.Save.ImageAreaVerticalOffset = dlg.FileJ2kOptions.ImageAreaVerticalOffset
               codecs.Options.Jpeg2000.Save.ProgressingOrder = dlg.FileJ2kOptions.ProgressingOrder
               codecs.Options.Jpeg2000.Save.ReferenceTileHeight = dlg.FileJ2kOptions.ReferenceTileHeight
               codecs.Options.Jpeg2000.Save.ReferenceTileWidth = dlg.FileJ2kOptions.ReferenceTileWidth
               codecs.Options.Jpeg2000.Save.RegionOfInterest = dlg.FileJ2kOptions.RegionOfInterest
               codecs.Options.Jpeg2000.Save.RegionOfInterestRectangle = dlg.FileJ2kOptions.RegionOfInterestRectangle
               codecs.Options.Jpeg2000.Save.RegionOfInterestWeight = dlg.FileJ2kOptions.RegionOfInterestWeight
               codecs.Options.Jpeg2000.Save.TargetFileSize = dlg.FileJ2kOptions.TargetFileSize
               codecs.Options.Jpeg2000.Save.TileHorizontalOffset = dlg.FileJ2kOptions.TileHorizontalOffset
               codecs.Options.Jpeg2000.Save.TileVerticalOffset = dlg.FileJ2kOptions.TileVerticalOffset
               codecs.Options.Jpeg2000.Save.UseColorTransform = dlg.FileJ2kOptions.UseColorTransform
               codecs.Options.Jpeg2000.Save.UseEphMarker = dlg.FileJ2kOptions.UseEphMarker
               codecs.Options.Jpeg2000.Save.UseRegionOfInterest = dlg.FileJ2kOptions.UseRegionOfInterest
               codecs.Options.Jpeg2000.Save.UseSopMarker = dlg.FileJ2kOptions.UseSopMarker
            End If

            If (Format = RasterImageFormat.TifJbig2) OrElse (Format = RasterImageFormat.Jbig2) Then
               codecs.Options.Jbig2.Save.EnableDictionary = dlg.FileJbig2Options.EnableDictionary
               codecs.Options.Jbig2.Save.ImageGbatX1 = dlg.FileJbig2Options.ImageGbatX1
               codecs.Options.Jbig2.Save.ImageGbatX2 = dlg.FileJbig2Options.ImageGbatX2
               codecs.Options.Jbig2.Save.ImageGbatX3 = dlg.FileJbig2Options.ImageGbatX3
               codecs.Options.Jbig2.Save.ImageGbatX4 = dlg.FileJbig2Options.ImageGbatX4
               codecs.Options.Jbig2.Save.ImageGbatY1 = dlg.FileJbig2Options.ImageGbatY1
               codecs.Options.Jbig2.Save.ImageGbatY2 = dlg.FileJbig2Options.ImageGbatY2
               codecs.Options.Jbig2.Save.ImageGbatY3 = dlg.FileJbig2Options.ImageGbatY3
               codecs.Options.Jbig2.Save.ImageGbatY4 = dlg.FileJbig2Options.ImageGbatY4
               codecs.Options.Jbig2.Save.ImageQualityFactor = dlg.FileJbig2Options.ImageQualityFactor
               codecs.Options.Jbig2.Save.ImageTemplateType = dlg.FileJbig2Options.ImageTemplateType
               codecs.Options.Jbig2.Save.ImageTypicalPredictionOn = dlg.FileJbig2Options.ImageTypicalPredictionOn
               codecs.Options.Jbig2.Save.RemoveEofSegment = dlg.FileJbig2Options.RemoveEofSegment
               codecs.Options.Jbig2.Save.RemoveEopSegment = dlg.FileJbig2Options.RemoveEopSegment
               codecs.Options.Jbig2.Save.RemoveHeaderSegment = dlg.FileJbig2Options.RemoveHeaderSegment
               codecs.Options.Jbig2.Save.RemoveMarker = dlg.FileJbig2Options.RemoveMarker
               codecs.Options.Jbig2.Save.TextDifferentialThreshold = dlg.FileJbig2Options.TextDifferentialThreshold
               codecs.Options.Jbig2.Save.TextGbatX1 = dlg.FileJbig2Options.TextGbatX1
               codecs.Options.Jbig2.Save.TextGbatX2 = dlg.FileJbig2Options.TextGbatX2
               codecs.Options.Jbig2.Save.TextGbatX3 = dlg.FileJbig2Options.TextGbatX3
               codecs.Options.Jbig2.Save.TextGbatX4 = dlg.FileJbig2Options.TextGbatX4
               codecs.Options.Jbig2.Save.TextGbatY1 = dlg.FileJbig2Options.TextGbatY1
               codecs.Options.Jbig2.Save.TextGbatY2 = dlg.FileJbig2Options.TextGbatY2
               codecs.Options.Jbig2.Save.TextGbatY3 = dlg.FileJbig2Options.TextGbatY3
               codecs.Options.Jbig2.Save.TextGbatY4 = dlg.FileJbig2Options.TextGbatY4
               codecs.Options.Jbig2.Save.TextKeepAllSymbols = dlg.FileJbig2Options.TextKeepAllSymbols
               codecs.Options.Jbig2.Save.TextMaximumSymbolArea = dlg.FileJbig2Options.TextMaximumSymbolArea
               codecs.Options.Jbig2.Save.TextMaximumSymbolHeight = dlg.FileJbig2Options.TextMaximumSymbolHeight
               codecs.Options.Jbig2.Save.TextMaximumSymbolWidth = dlg.FileJbig2Options.TextMaximumSymbolWidth
               codecs.Options.Jbig2.Save.TextMinimumSymbolArea = dlg.FileJbig2Options.TextMinimumSymbolArea
               codecs.Options.Jbig2.Save.TextMinimumSymbolHeight = dlg.FileJbig2Options.TextMinimumSymbolHeight
               codecs.Options.Jbig2.Save.TextMinimumSymbolWidth = dlg.FileJbig2Options.TextMinimumSymbolWidth
               codecs.Options.Jbig2.Save.TextQualityFactor = dlg.FileJbig2Options.TextQualityFactor
               codecs.Options.Jbig2.Save.TextRemoveUnrepeatedSymbol = dlg.FileJbig2Options.TextRemoveUnrepeatedSymbol
               codecs.Options.Jbig2.Save.TextTemplateType = dlg.FileJbig2Options.TextTemplateType
               codecs.Options.Jbig2.Save.XResolution = dlg.FileJbig2Options.XResolution
               codecs.Options.Jbig2.Save.YResolution = dlg.FileJbig2Options.YResolution
            End If

            If Format = RasterImageFormat.Gif Then
               codecs.Options.Gif.Save.Interlaced = dlg.Interlaced
            End If

            PdfProfile = dlg.PdfProfile
            If (Format = RasterImageFormat.RasPdf) OrElse (Format = RasterImageFormat.RasPdfG31Dim) OrElse (Format = RasterImageFormat.RasPdfG32Dim) OrElse (Format = RasterImageFormat.RasPdfG4) OrElse (Format = RasterImageFormat.RasPdfJbig2) OrElse (Format = RasterImageFormat.RasPdfJpeg) OrElse (Format = RasterImageFormat.RasPdfJpeg422) OrElse (Format = RasterImageFormat.RasPdfJpeg411) Then

               codecs.Options.Pdf.Save.SavePdfA = False
               codecs.Options.Pdf.Save.SavePdfv13 = False
               codecs.Options.Pdf.Save.SavePdfv14 = False
               codecs.Options.Pdf.Save.SavePdfv15 = False
               codecs.Options.Pdf.Save.SavePdfv16 = False

               Select Case PdfProfile
                  Case FileSavePdfProfiles.PdfA
                     codecs.Options.Pdf.Save.SavePdfA = True
                  Case FileSavePdfProfiles.Pdf13
                     codecs.Options.Pdf.Save.SavePdfv13 = True
                  Case FileSavePdfProfiles.Pdf14
                     codecs.Options.Pdf.Save.SavePdfv14 = True
                  Case FileSavePdfProfiles.Pdf15
                     codecs.Options.Pdf.Save.SavePdfv15 = True
                  Case FileSavePdfProfiles.Pdf16
                     codecs.Options.Pdf.Save.SavePdfv16 = True
               End Select
            End If
            Dim image As RasterImage = codecs.Load(tempFiles(0))
            Dim i As Integer = 1
            Do While i < tempFiles.Count
               image.AddPage(codecs.Load(tempFiles(i)))
               i += 1
            Loop

            If _format = RasterImageFormat.Ani OrElse _format = RasterImageFormat.Gif OrElse _format = RasterImageFormat.Cals OrElse _format = RasterImageFormat.Cals2 OrElse _format = RasterImageFormat.Cals3 OrElse _format = RasterImageFormat.Cals4 OrElse _format = RasterImageFormat.Pcx OrElse _format = RasterImageFormat.Fpx OrElse _format = RasterImageFormat.FpxJpeg OrElse _format = RasterImageFormat.FpxJpegQFactor OrElse _format = RasterImageFormat.FpxSingleColor OrElse _format = RasterImageFormat.Flc OrElse _format = RasterImageFormat.IffCat OrElse _format = RasterImageFormat.IcaAbic OrElse _format = RasterImageFormat.IcaG31Dim OrElse _format = RasterImageFormat.IcaG32Dim OrElse _format = RasterImageFormat.IcaG4 OrElse _format = RasterImageFormat.IcaIbmMmr OrElse _format = RasterImageFormat.IcaUncompressed OrElse _format = RasterImageFormat.AfpIcaG31Dim OrElse _format = RasterImageFormat.AfpIcaG32Dim OrElse _format = RasterImageFormat.AfpIcaG4 OrElse _format = RasterImageFormat.AfpIcaIbmMmr OrElse _format = RasterImageFormat.AfpIcaUncompressed OrElse _format = RasterImageFormat.Mng OrElse _format = RasterImageFormat.MngGray OrElse _format = RasterImageFormat.MngJng OrElse _format = RasterImageFormat.MngJng411 OrElse _format = RasterImageFormat.MngJng422 OrElse _format = RasterImageFormat.Pct OrElse _format = RasterImageFormat.Pcx OrElse _format = RasterImageFormat.RasPdf OrElse _format = RasterImageFormat.RasPdfCmyk OrElse _format = RasterImageFormat.RasPdfG31Dim OrElse _format = RasterImageFormat.RasPdfG32Dim OrElse _format = RasterImageFormat.RasPdfG4 OrElse _format = RasterImageFormat.RasPdfJbig2 OrElse _format = RasterImageFormat.RasPdfJpeg OrElse _format = RasterImageFormat.RasPdfJpeg411 OrElse _format = RasterImageFormat.RasPdfJpeg422 OrElse _format = RasterImageFormat.RasPdfLzw OrElse _format = RasterImageFormat.RasPdfLzwCmyk OrElse _format = RasterImageFormat.Sff OrElse _format = RasterImageFormat.Ccitt OrElse _format = RasterImageFormat.CcittGroup31Dim OrElse _format = RasterImageFormat.CcittGroup32Dim OrElse _format = RasterImageFormat.CcittGroup4 OrElse _format = RasterImageFormat.GeoTiff OrElse _format = RasterImageFormat.Exif OrElse _format = RasterImageFormat.ExifJpeg OrElse _format = RasterImageFormat.ExifJpeg411 OrElse _format = RasterImageFormat.ExifJpeg422 OrElse _format = RasterImageFormat.ExifYcc OrElse _format = RasterImageFormat.Tif OrElse _format = RasterImageFormat.TifAbc OrElse _format = RasterImageFormat.TifAbic OrElse _format = RasterImageFormat.TifCmp OrElse _format = RasterImageFormat.TifCmw OrElse _format = RasterImageFormat.TifCmyk OrElse _format = RasterImageFormat.TifCustom OrElse _format = RasterImageFormat.TifDxf OrElse _format = RasterImageFormat.TifJ2k OrElse _format = RasterImageFormat.TifJbig OrElse _format = RasterImageFormat.TifJbig2 OrElse _format = RasterImageFormat.TifJpeg OrElse _format = RasterImageFormat.TifJpeg411 OrElse _format = RasterImageFormat.TifJpeg422 OrElse _format = RasterImageFormat.TifLead1Bit OrElse _format = RasterImageFormat.TifLzw OrElse _format = RasterImageFormat.TifLzwCmyk OrElse _format = RasterImageFormat.TifLzwYcc OrElse _format = RasterImageFormat.TifPackBits OrElse _format = RasterImageFormat.TifPackBitsCmyk OrElse _format = RasterImageFormat.TifPackbitsYcc OrElse _format = RasterImageFormat.TifUnknown OrElse _format = RasterImageFormat.TifxFaxG31D OrElse _format = RasterImageFormat.TifxFaxG32D OrElse _format = RasterImageFormat.TifxFaxG4 OrElse _format = RasterImageFormat.TifxJbig OrElse _format = RasterImageFormat.TifxJbigT43 OrElse _format = RasterImageFormat.TifxJbigT43Gs OrElse _format = RasterImageFormat.TifxJbigT43ItuLab OrElse _format = RasterImageFormat.TifxJpeg OrElse _format = RasterImageFormat.TifYcc OrElse _format = RasterImageFormat.TifZip Then
               codecs.Save(image, _fileName, _format, _bitsPerPixel, image.Page, image.PageCount, _savePageNumber, _pageMode)

               If viewOutputFile Then
                  System.Diagnostics.Process.Start(_fileName)
               End If
            Else
               i = 0
               Do While i < image.PageCount
                  Dim ext As String = System.IO.Path.GetExtension(_fileName)
                  Dim index As Integer = _fileName.IndexOf(ext)
                  Dim newFileName As String = _fileName.Insert(index, "_" & (i + 1).ToString())

                  image.Page = i + 1
                  codecs.Save(image, newFileName, _format, _bitsPerPixel, i + 1, i + 1, 0, CodecsSavePageMode.Overwrite)
                  i += 1
               Loop

               Dim ext2 As String = System.IO.Path.GetExtension(_fileName)
               Dim index2 As Integer = _fileName.IndexOf(ext2)
               Dim openFileName As String = _fileName.Insert(index2, "_" & 1.ToString())

               If viewOutputFile Then
                  System.Diagnostics.Process.Start(openFileName)
               End If
            End If

            If Not image Is Nothing Then
               image.Dispose()
            End If
         End If

         Return True
      Else
         Return False
      End If
   End Function
End Class
