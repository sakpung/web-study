' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Windows.Forms

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
   Private _passes As Integer

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
      _passes = -1
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

   Public Property BitsPerPixel() As Integer
      Get
         Return _bitsPerPixel
      End Get
      Set(value As Integer)
         _bitsPerPixel = value
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

   Public Property Passes() As Integer
      Get
         Return _passes
      End Get

      Set(ByVal value As Integer)
         _passes = value
      End Set
   End Property


   Public Function Save(ByVal owner As IWin32Window, ByVal codecs As RasterCodecs, ByVal image As RasterImage) As Boolean
      _format = RasterImageFormat.Unknown
      _firstPage = -1
      _lastPage = -1
      _savePageNumber = -1
      _pageMode = CodecsSavePageMode.Overwrite

      Using dlg As RasterSaveDialog = New RasterSaveDialog(codecs)
         dlg.PromptOverwrite = True
         dlg.ShowFileOptionsBasicJ2kOptions = True
         dlg.ShowFileOptionsJ2kOptions = True
         dlg.ShowFileOptionsJbig2Options = True
         dlg.ShowFileOptionsMultipage = True
         dlg.ShowFileOptionsProgressive = True
         dlg.Passes = _passes
         dlg.ShowFileOptionsQualityFactor = True
         dlg.ShowFileOptionsStamp = True
         dlg.ShowPdfProfiles = True
         dlg.PdfProfile = PdfProfile
         dlg.ShowOptions = True
         dlg.ShowQualityFactor = True
         dlg.PageNumber = SavePageNumber
         dlg.Title = "LEADTOOLS Save Dialog"
         dlg.EnableSizing = True
         dlg.FileName = FileName
         dlg.FileSubTypeIndex = _fileSubTypeIndex
         dlg.FileTypeIndex = _fileTypeIndex
         If Not (image Is Nothing) Then
            dlg.BitsPerPixel = image.BitsPerPixel
         Else
            dlg.BitsPerPixel = 0
         End If

         If Nothing Is SaveFormats Then
            dlg.FileFormatsList = New RasterSaveDialogFileFormatsList(RasterDialogFileFormatDataContent.Default)
         Else
            dlg.FileFormatsList = SaveFormats
         End If

         If dlg.ShowDialog(owner) = DialogResult.OK Then
            FileName = dlg.FileName
            _fileSubTypeIndex = dlg.FileSubTypeIndex
            _fileTypeIndex = dlg.FileTypeIndex
            _format = dlg.Format
            _bitsPerPixel = dlg.BitsPerPixel
            _firstPage = dlg.PageNumber
            _lastPage = dlg.PageNumber
            _savePageNumber = dlg.PageNumber
            _pageMode = dlg.MultiPage
            _passes = dlg.Passes

            If _autoSave Then
               Select Case dlg.Format
                  Case RasterImageFormat.Abc
                     codecs.Options.Abc.Save.QualityFactor = dlg.AbcQualityFactor

                     Exit Select

#If Not LEADTOOLS_V20_OR_LATER Then
                  Case RasterImageFormat.Ecw
                     codecs.Options.Ecw.Save.QualityFactor = dlg.QualityFactor

                     Exit Select
#End If ' #if not LEADTOOLS_V20_OR_LATER then

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
                     codecs.Options.Jpeg.Save.Passes = dlg.Passes

                     Exit Select

                  Case RasterImageFormat.Xps
                     codecs.Options.Save.InitAlpha = True

                     Exit Select

                  Case RasterImageFormat.Gif
                     codecs.Options.Gif.Save.Interlaced = dlg.Interlaced

                     Exit Select

                  Case Else
                     codecs.Options.Jpeg.Save.QualityFactor = dlg.QualityFactor
                     codecs.Options.Jpeg.Save.Passes = dlg.Passes

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

               If Format = RasterImageFormat.Jbig2 Then
                  codecs.Options.Jbig2.Save.ImageQualityFactor = dlg.QualityFactor
               End If

               PdfProfile = dlg.PdfProfile
               If (Format = RasterImageFormat.RasPdf) OrElse _
                  (Format = RasterImageFormat.RasPdfG31Dim) OrElse _
                  (Format = RasterImageFormat.RasPdfG32Dim) OrElse _
                  (Format = RasterImageFormat.RasPdfG4) OrElse _
                  (Format = RasterImageFormat.RasPdfJbig2) OrElse _
                  (Format = RasterImageFormat.RasPdfJpeg) OrElse _
                  (Format = RasterImageFormat.RasPdfJpeg422) OrElse _
                  (Format = RasterImageFormat.RasPdfJpeg411) OrElse _
                  (Format = RasterImageFormat.RasPdfJpx) Then

                  Select Case PdfProfile
                     Case FileSavePdfProfiles.PdfA
                        codecs.Options.Pdf.Save.Version = CodecsRasterPdfVersion.PdfA

                     Case FileSavePdfProfiles.Pdf14
                        codecs.Options.Pdf.Save.Version = CodecsRasterPdfVersion.V14

                     Case FileSavePdfProfiles.Pdf15
                        codecs.Options.Pdf.Save.Version = CodecsRasterPdfVersion.V15

                     Case FileSavePdfProfiles.Pdf16
                        codecs.Options.Pdf.Save.Version = CodecsRasterPdfVersion.V16

                     Case FileSavePdfProfiles.Pdf13
                        codecs.Options.Pdf.Save.Version = CodecsRasterPdfVersion.V13

                     Case FileSavePdfProfiles.Pdf17
                        codecs.Options.Pdf.Save.Version = CodecsRasterPdfVersion.V17

                        'Case FileSavePdfProfiles.Default
                     Case Else
                        codecs.Options.Pdf.Save.Version = CodecsRasterPdfVersion.V12
                  End Select
               End If

#If LEADTOOLS_V19_OR_LATER Then
               If (dlg.BigTiff) Then
                  codecs.Options.Tiff.Save.BigTiff = True
               Else
                  codecs.Options.Tiff.Save.BigTiff = False
               End If
#End If

               codecs.Save(image, _fileName, _format, _bitsPerPixel, image.Page, image.PageCount, _savePageNumber, _pageMode)
            End If


            Return True
         Else
            Return False
         End If
      End Using
   End Function
End Class
