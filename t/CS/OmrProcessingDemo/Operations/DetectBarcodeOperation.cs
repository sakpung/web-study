
using Leadtools;
using Leadtools.Barcode;
using Leadtools.Forms.Common;

namespace OmrProcessingDemo.Operations
{
   internal class DetectBarcodeOperation : BusyOperation
   {
      public BarcodeSymbology DetectedSymbology { get; private set; }
      public bool IsSymbologyDetected { get; private set; }

      RasterImage image;
      LeadRect rect;
      public DetectBarcodeOperation(RasterImage loadedImage, LeadRect lr) : base()
      {
         image = loadedImage;
         rect = lr;
      }

      protected override void Run()
      {
         Progress(33, "Creating components");
         BarcodeEngine engine = new BarcodeEngine();
         BarcodeReadOptions[] options = GetHorizontalAndVerticalReadBarcodeOptions(engine.Reader);

         Progress(66, "Detecting barcode symbology");
         BarcodeData[] bc = engine.Reader.ReadBarcodes(image, rect, 1, engine.Reader.GetAvailableSymbologies(), options);

         if (bc != null && bc.Length > 0)
         {
            DetectedSymbology = bc[0].Symbology;
            IsSymbologyDetected = true;
         }
         else
         {
            IsSymbologyDetected = false;
         }

         base.Run();
      }

      private static BarcodeReadOptions[] GetHorizontalAndVerticalReadBarcodeOptions(BarcodeReader reader)
      {
         // By default, the options read horizontal barcodes only, create an array of options capable of reading vertical barcodes 

         // Notice, we cloned the default options in reader so we will not change the original options 

         OneDBarcodeReadOptions oneDReadOptions = reader.GetDefaultOptions(BarcodeSymbology.UPCA).Clone() as OneDBarcodeReadOptions;
         oneDReadOptions.SearchDirection = BarcodeSearchDirection.HorizontalAndVertical;

         FourStateBarcodeReadOptions fourStateReadOptions = reader.GetDefaultOptions(BarcodeSymbology.USPS4State).Clone() as FourStateBarcodeReadOptions;
         fourStateReadOptions.SearchDirection = BarcodeSearchDirection.HorizontalAndVertical;

         PostNetPlanetBarcodeReadOptions postNetPlanetReadOptions = reader.GetDefaultOptions(BarcodeSymbology.PostNet).Clone() as PostNetPlanetBarcodeReadOptions;
         postNetPlanetReadOptions.SearchDirection = BarcodeSearchDirection.HorizontalAndVertical;

         GS1DatabarStackedBarcodeReadOptions gs1StackedReadOptions = reader.GetDefaultOptions(BarcodeSymbology.GS1DatabarStacked).Clone() as GS1DatabarStackedBarcodeReadOptions;
         gs1StackedReadOptions.SearchDirection = BarcodeSearchDirection.HorizontalAndVertical;

         PatchCodeBarcodeReadOptions patchCodeReadOptions = reader.GetDefaultOptions(BarcodeSymbology.PatchCode).Clone() as PatchCodeBarcodeReadOptions;
         patchCodeReadOptions.SearchDirection = BarcodeSearchDirection.HorizontalAndVertical;

         PDF417BarcodeReadOptions pdf417ReadOptions = reader.GetDefaultOptions(BarcodeSymbology.PDF417).Clone() as PDF417BarcodeReadOptions;
         pdf417ReadOptions.SearchDirection = BarcodeSearchDirection.HorizontalAndVertical;

         MicroPDF417BarcodeReadOptions microPdf417ReadOptions = reader.GetDefaultOptions(BarcodeSymbology.MicroPDF417).Clone() as MicroPDF417BarcodeReadOptions;
         microPdf417ReadOptions.SearchDirection = BarcodeSearchDirection.HorizontalAndVertical;

         // Even though this array will not contain all options, it should be enough to read all barcodes, since the version of ReadBarcodes we will use 
         // will use the default options if an override is not passed 
         BarcodeReadOptions[] readOptions =
         {
            oneDReadOptions, fourStateReadOptions, postNetPlanetReadOptions, gs1StackedReadOptions, patchCodeReadOptions, pdf417ReadOptions, microPdf417ReadOptions
         };

         return readOptions;
      }
   }
}