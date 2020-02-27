' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports LTRASTERLib

Public NotInheritable Class ComSupport
   Private Sub New()
   End Sub

   Private Const KeyDocument As String = "IxKjEexxS"
   Private Const KeyGifLzw As String = "GJmtRtHS"
   Private Const KeyTifLzw As String = "NhY5543d"
   Private Const KeyOcr As String = "B6e8Az"
   Private Const KeyMedical As String = "jYrHNuh"
   Private Const KeyMedicalNet As String = "27dQQnet"
   Private Const KeyVector As String = "yzr8Xxae"
   Private Const KeyBarcodes1d As String = "83JKwDkH"
   Private Const KeyBarcodes2dRead As String = "dfq3k79"
   Private Const KeyBarcodes2dWrite As String = "qw2er3ty"
   Private Const KeyBarcodesPdfRead As String = "WPdSf8rMM"
   Private Const KeyBarcodesPdfWrite As String = "aLpH5989"
   Private Const KeyPdf As String = "haDLeYrAE"
   Private Const KeyJ2k As String = "SLedfish"
   Private Const KeyCmw As String = "bigCOmp9x"
   Private Const KeyDicom As String = "FfifTeeN"
   Private Const KeyExtGray As String = "38Tvsp8"
   Private Const KeyBitonal As String = "eMMaLine"
   Private Const KeyPdfSave As String = "Ukk5XBb"
   Private Const KeyOcrPdfOutput As String = "YqpqxRa"
   Private Const KeyBarcodesDatamatrixRead As String = "2kwINbAR"
   Private Const KeyBarcodesDatamatrixWrite As String = "38hrxBB2"
   Private Const KeyLtPro As String = "KdIjXuhG"
   Private Const KeyOcrAsian As String = "UndrrWaX"
   Private Const KeyIcr As String = "pcEjjTT"
   Private Const KeyOmr As String = "beAt43SS"

   Private Shared RasterFactory As New LEADRasterFactoryClass

   Public Shared License As String = Nothing

   Public Shared Sub Unlock()
      Dim raster As LEADRaster = CType(RasterFactory.CreateObject("LEADRaster.LEADRaster", License), LEADRaster)

      raster.UnlockSupport(RasterSupportLockConstants.L_SUPPORT_DOCUMENT, KeyDocument)
      raster.UnlockSupport(RasterSupportLockConstants.L_SUPPORT_GIFLZW, KeyGifLzw)
      raster.UnlockSupport(RasterSupportLockConstants.L_SUPPORT_TIFLZW, KeyTifLzw)
      raster.UnlockSupport(RasterSupportLockConstants.L_SUPPORT_OCR, KeyOcr)
      raster.UnlockSupport(RasterSupportLockConstants.L_SUPPORT_MEDICAL, KeyMedical)
      raster.UnlockSupport(RasterSupportLockConstants.L_SUPPORT_VECTOR, KeyVector)
      raster.UnlockSupport(RasterSupportLockConstants.L_SUPPORT_MEDICAL_NET, KeyMedicalNet)
      raster.UnlockSupport(RasterSupportLockConstants.L_SUPPORT_BARCODES_1D, KeyBarcodes1d)
      raster.UnlockSupport(RasterSupportLockConstants.L_SUPPORT_BARCODES_2D_READ, KeyBarcodes2dRead)
      raster.UnlockSupport(RasterSupportLockConstants.L_SUPPORT_BARCODES_2D_WRITE, KeyBarcodes2dWrite)
      raster.UnlockSupport(RasterSupportLockConstants.L_SUPPORT_BARCODES_PDF_READ, KeyBarcodesPdfRead)
      raster.UnlockSupport(RasterSupportLockConstants.L_SUPPORT_BARCODES_PDF_WRITE, KeyBarcodesPdfWrite)
      raster.UnlockSupport(RasterSupportLockConstants.L_SUPPORT_PDF, KeyPdf)
      raster.UnlockSupport(RasterSupportLockConstants.L_SUPPORT_J2K, KeyJ2k)
      raster.UnlockSupport(RasterSupportLockConstants.L_SUPPORT_CMW, KeyCmw)
      raster.UnlockSupport(RasterSupportLockConstants.L_SUPPORT_DICOM, KeyDicom)
      raster.UnlockSupport(RasterSupportLockConstants.L_SUPPORT_EXTGRAY, KeyExtGray)
      raster.UnlockSupport(RasterSupportLockConstants.L_SUPPORT_BITONAL, KeyBitonal)
   End Sub
End Class
