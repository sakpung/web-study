using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Cloud_Services_Api.Configuration;
using Cloud_Services_Api.Helper;
using System.Threading.Tasks;
using Leadtools.CloudServices;
using Leadtools.Document;
using Leadtools.Codecs;
using Newtonsoft.Json;
using Leadtools.Ocr;
using Leadtools.Document.Writer;
using Leadtools.Barcode;
using System.IO;
using System.Drawing;
using System.Web.Http.Description;

namespace Cloud_Services_Api.Controllers
{
   /// <summary>
   /// Controller to handle any recognition requests that are made to the services. 
   /// </summary>
   public class RecognitionController : BaseController
   {

      /// <summary>
      /// Method to extract barcode information from a file
      /// </summary>
      [ApiExplorerSettings(IgnoreApi = true)]
      private async Task<HttpResponseMessage> ExtractBarcodes([FromUri] BarcodeWebRequest request, int barcodeAmount)
      {
         try 
         {
            AuthenticateRequest();

            if (!VerifyCommonParameters(request))
               throw new MalformedRequestException();

            var symbologyList = new List<BarcodeSymbology>();
            if (string.IsNullOrEmpty(request.symbologies))//If no symbology string is passed, default to all symbologies. 
            {
               symbologyList = Enum.GetValues(typeof(BarcodeSymbology)).OfType<BarcodeSymbology>().ToList();
               symbologyList.Remove(BarcodeSymbology.Unknown); 
            }  
            else
            {
               symbologyList = ExtractBarcodeSymbologies(request.symbologies);
               //If the user did supply a list of symbologies, but they could not be parsed, we will deny the request.
               if (symbologyList.Count == 0)
                  throw new MalformedRequestException();
            }


            using (var stream = await GetImageStream(request.fileUrl))
            {
               int lastPage = request.LastPage;
               ValidateFile(stream, ref lastPage);
               ConversionEngine conversion = new ConversionEngine();
               LoadDocumentOptions options = new LoadDocumentOptions()
               {
                  FirstPageNumber = request.FirstPage,
                  LastPageNumber = lastPage
               };
               RecognitionEngine recognitionEngine = new RecognitionEngine();
               BarcodeEngine barcodeEngine = new BarcodeEngine();
 
               var barcodeList = recognitionEngine.ExtractBarcode(stream, options, barcodeEngine, symbologyList.ToArray(), barcodeAmount, false);
               List<BarcodeResultData> results = new List<BarcodeResultData>();
               foreach (var obj in barcodeList)
               {
                  foreach(var d in obj.BarcodeData)
                  {
                     var result = new BarcodeResultData(obj.PageNumber, d.Symbology.ToString(), d.Value, new Rectangle(d.Bounds.X, d.Bounds.Y, d.Bounds.Width, d.Bounds.Height), d.RotationAngle); ;
                     results.Add(result);
                  }
               }
                  

               return new HttpResponseMessage(HttpStatusCode.OK)
               {
                  Content = new StringContent(JsonConvert.SerializeObject(results))
               };
            }
         }
         catch (Exception e)
         {
            return GenerateExceptionMessage(e);
         }
      }

      /// <summary>
      /// Service call to extract every barcode from a file.  
      /// </summary>
      /// <returns>
      /// Body content of the response will contain a list of Barcode Results.
      /// </returns>
      [HttpPost]
      //For demoing purposes, GET requests are enabled on this endpoint. In a production environment, disable GET requests on this method.
      [HttpGet]
      [Route("api/ExtractAllBarcodes")]
      public async Task<HttpResponseMessage> ExtractAllBarcodes([FromUri] BarcodeWebRequest request)
      {
         //Passing 0 for the barcode amount parameter indicates that all barcodes should be pulled from the stream.
         return await ExtractBarcodes(request, 0);
      }

      /// <summary>
      /// Service call to extract a single barcode from a file.  
      /// </summary>
      /// <returns>
      /// Body content of the response will contain a list of Barcode Results.
      /// </returns>
      [HttpPost]
      //For demoing purposes, GET requests are enabled on this endpoint. In a production environment, disable GET requests on this method.
      [HttpGet]
      [Route("api/ExtractBarcode")]
      public async Task<HttpResponseMessage> ExtractBarcode([FromUri] BarcodeWebRequest request)
      {
         return await ExtractBarcodes(request, 1);
      }

      /// <summary>
      /// This method is used by the ExtractText/ExtractTextAdditional API methods in order to extract textual information from a file. 
      /// </summary>
      [ApiExplorerSettings(IgnoreApi = true)]
      private async Task<HttpResponseMessage> ParseText([FromUri] LeadWebRequest request, bool additionalInfo)
      {
         try
         {
            AuthenticateRequest();

            if (!VerifyCommonParameters(request))
               throw new MalformedRequestException();

            using (var stream = await GetImageStream(request.fileUrl))
            {
               int lastPage = request.LastPage;
               ValidateFile(stream, ref lastPage);
               LoadDocumentOptions options = new LoadDocumentOptions()
               {
                  FirstPageNumber = request.FirstPage,
                  LastPageNumber = lastPage
               };

               RecognitionEngine recognitionEngine = new RecognitionEngine();
               recognitionEngine.OcrEngine = ocrEngine;
               recognitionEngine.WorkingDirectory = Path.GetTempPath();

               var documentPageText = recognitionEngine.ExtractText(stream, options);
               List<ExtractTextData> PageDataList = new List<ExtractTextData>();
               int currentPage = options.FirstPageNumber;
               if (!additionalInfo)
               {
                  foreach (var page in documentPageText)
                  {
                     for (int i = 0; i < page.Words.Count; i++)
                     {
                        var word = page.Words[i];
                        word.Bounds = word.Bounds.ToLeadRect().ToLeadRectD();
                        page.Words[i] = word;
                     }

                     ExtractTextData pageData = new ExtractTextData
                     {
                        PageNumber = currentPage,
                        PageText = page.Text,
                        Words = page.Words.Select(w => new { w.Value, w.Bounds }).ToList()
                     };
                     PageDataList.Add(pageData);
                     currentPage++;
                  }
               }
               else
               {
                  foreach (var page in documentPageText)
                  {
                     for (int i = 0; i < page.Words.Count; i++)
                     {
                        var word = page.Words[i];
                        word.Bounds = word.Bounds.ToLeadRect().ToLeadRectD();
                        page.Words[i] = word;
                     }
                     for (int i = 0; i < page.Characters.Count; i++)
                     {
                        var character = page.Characters[i];
                        character.Bounds = character.Bounds.ToLeadRect().ToLeadRectD();
                        page.Characters[i] = character;
                     }

                     ExtractTextData pageData = new ExtractTextData
                     {
                        PageNumber = currentPage,
                        PageText = page.Text,
                        Words = page.Words,
                        Characters = page.Characters
                     };
                     PageDataList.Add(pageData);
                     currentPage++;
                  }                 
               }

               using (var ms = new MemoryStream())
               {
                  using (TextWriter tw = new StreamWriter(ms))
                  {
                     tw.Write(JsonConvert.SerializeObject(PageDataList));
                     tw.Flush();
                     ms.Position = 0;

                     Guid id = Guid.NewGuid();
                     string baseName = $"ExtractText-{id}.json";
                     string urlPath = $"{Url.Request.RequestUri.GetComponents(UriComponents.SchemeAndServer, UriFormat.Unescaped)}/{new DirectoryInfo(DemoConfiguration.OutputFileDirectory).Name}/{baseName}";
                     string serverFilePath = $"{DemoConfiguration.OutputFileDirectory}{baseName}";
                     SaveToDisk(ms, serverFilePath);
                     return new HttpResponseMessage(HttpStatusCode.OK)
                     {
                        Content = new StringContent(urlPath)
                     };
                  }
               }

            }
         }
         catch (Exception e)
         {
            return GenerateExceptionMessage(e);
         }
      }

      /// <summary>
      /// Service call to extract all text from a file.  
      /// </summary>
      /// <returns>
      /// Body content of the response will contain a list of Text Results from a file.  Will pull all the text and words from a file. 
      /// 
      /// </returns>
      [HttpPost]
      //For demoing purposes, GET requests are enabled on this endpoint. In a production environment, disable GET requests on this method.
      [HttpGet]
      [Route("api/ExtractText")]
      public async Task<HttpResponseMessage> ExtractText([FromUri] ExtractTextWebRequest request)
      {
         return await ParseText(request, request.extractCharacters);
      }

      /// <summary>
      /// Service call to extract all check information from a file. 
      /// </summary>
      /// <returns>
      ///  Body content of the response will contain a list of all MICR information in a file.
      /// </returns>
      [HttpPost]
      //For demoing purposes, GET requests are enabled on this endpoint. In a production environment, disable GET requests on this method.
      [HttpGet]
      [Route("api/ExtractCheck")]
      public async Task<HttpResponseMessage> ExtractCheck([FromUri] LeadWebRequest request)
      {
         try
         {
            AuthenticateRequest();

            if (!VerifyCommonParameters(request))
               throw new MalformedRequestException();

            using (var stream = await GetImageStream(request.fileUrl))
            {
               int lastPage = request.LastPage;
               ValidateFile(stream, ref lastPage);

               LoadDocumentOptions options = new LoadDocumentOptions()
               {
                  FirstPageNumber = request.FirstPage,
                  LastPageNumber = lastPage
               };
               RecognitionEngine recognitionEngine = new RecognitionEngine();
               recognitionEngine.OcrEngine = ocrEngine;
               var micrResults = recognitionEngine.ExtractMicr(stream, options, Leadtools.Forms.Commands.BankCheckMicrFontType.Unknown);
               return new HttpResponseMessage(HttpStatusCode.OK)
               {
                 Content = new StringContent(JsonConvert.SerializeObject(micrResults))
               };
            }
         }
         catch (Exception e)
         {
            return GenerateExceptionMessage(e);
         }
      }
   }
}
