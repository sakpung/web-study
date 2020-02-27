Imports Leadtools
Imports Leadtools.Barcode
Imports Leadtools.Forms.Common

Friend Class DetectBarcodeOperation
   Inherits BusyOperation

   Public Property DetectedSymbology As BarcodeSymbology
   Public Property IsSymbologyDetected As Boolean
   Private image As RasterImage
   Private rect As LeadRect

   Public Sub New(ByVal loadedImage As RasterImage, ByVal lr As LeadRect)
      MyBase.New()
      image = loadedImage
      rect = lr
   End Sub

   Protected Overrides Sub Run()
      Progress(33, "Creating components")
      Dim engine As BarcodeEngine = New BarcodeEngine()
      Dim options As BarcodeReadOptions() = GetHorizontalAndVerticalReadBarcodeOptions(engine.Reader)
      Progress(66, "Detecting barcode symbology")
      Dim bc As BarcodeData() = engine.Reader.ReadBarcodes(image, rect, 1, engine.Reader.GetAvailableSymbologies(), options)

      If bc IsNot Nothing AndAlso bc.Length > 0 Then
         DetectedSymbology = bc(0).Symbology
         IsSymbologyDetected = True
      Else
         IsSymbologyDetected = False
      End If

      MyBase.Run()
   End Sub

   Private Shared Function GetHorizontalAndVerticalReadBarcodeOptions(ByVal reader As BarcodeReader) As BarcodeReadOptions()
      Dim oneDReadOptions As OneDBarcodeReadOptions = TryCast(reader.GetDefaultOptions(BarcodeSymbology.UPCA).Clone(), OneDBarcodeReadOptions)
      oneDReadOptions.SearchDirection = BarcodeSearchDirection.HorizontalAndVertical
      Dim fourStateReadOptions As FourStateBarcodeReadOptions = TryCast(reader.GetDefaultOptions(BarcodeSymbology.USPS4State).Clone(), FourStateBarcodeReadOptions)
      fourStateReadOptions.SearchDirection = BarcodeSearchDirection.HorizontalAndVertical
      Dim postNetPlanetReadOptions As PostNetPlanetBarcodeReadOptions = TryCast(reader.GetDefaultOptions(BarcodeSymbology.PostNet).Clone(), PostNetPlanetBarcodeReadOptions)
      postNetPlanetReadOptions.SearchDirection = BarcodeSearchDirection.HorizontalAndVertical
      Dim gs1StackedReadOptions As GS1DatabarStackedBarcodeReadOptions = TryCast(reader.GetDefaultOptions(BarcodeSymbology.GS1DatabarStacked).Clone(), GS1DatabarStackedBarcodeReadOptions)
      gs1StackedReadOptions.SearchDirection = BarcodeSearchDirection.HorizontalAndVertical
      Dim patchCodeReadOptions As PatchCodeBarcodeReadOptions = TryCast(reader.GetDefaultOptions(BarcodeSymbology.PatchCode).Clone(), PatchCodeBarcodeReadOptions)
      patchCodeReadOptions.SearchDirection = BarcodeSearchDirection.HorizontalAndVertical
      Dim pdf417ReadOptions As PDF417BarcodeReadOptions = TryCast(reader.GetDefaultOptions(BarcodeSymbology.PDF417).Clone(), PDF417BarcodeReadOptions)
      pdf417ReadOptions.SearchDirection = BarcodeSearchDirection.HorizontalAndVertical
      Dim microPdf417ReadOptions As MicroPDF417BarcodeReadOptions = TryCast(reader.GetDefaultOptions(BarcodeSymbology.MicroPDF417).Clone(), MicroPDF417BarcodeReadOptions)
      microPdf417ReadOptions.SearchDirection = BarcodeSearchDirection.HorizontalAndVertical
      Dim readOptions As BarcodeReadOptions() = {oneDReadOptions, fourStateReadOptions, postNetPlanetReadOptions, gs1StackedReadOptions, patchCodeReadOptions, pdf417ReadOptions, microPdf417ReadOptions}
      Return readOptions
   End Function
End Class
