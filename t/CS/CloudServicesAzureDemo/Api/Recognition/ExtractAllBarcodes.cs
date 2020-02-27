using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using Newtonsoft.Json;
using System.IO;
using System.Collections.Generic;
using System.Reflection;
using Leadtools.CloudServices;
using Leadtools.Document;
using Leadtools.Codecs;
using Leadtools.Ocr;
using Leadtools.Document.Writer;
using Leadtools.Barcode;
using Serverless_Cloud_Services_API;
using static Serverless_Cloud_Services_API.CommonMethods;
using System.Runtime.Serialization;
using System.Drawing;

namespace Serverless_Cloud_Services_API
{
   public static class ExtractAllBarcodes
   {
      [FunctionName("ExtractAllBarcodes")]
      public static async Task<HttpResponseMessage> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = "Recognition/ExtractAllBarcodes")]HttpRequestMessage req, TraceWriter log, ExecutionContext context)
      {
         try
         {
            if (!DemoConfiguration.UnlockSupport(log))
               return GenerateErrorMessage(ApiError.LicenseNotSet, req);

            var leadParameterObject = ParseLeadWebRequestParameters(req);
            if (!leadParameterObject.Successful)
               return GenerateErrorMessage(ApiError.InvalidRequest, req);

            var barcodeList = ExtractBarcodeSymbologies(req);
            if (barcodeList.Count == 0)
               return GenerateErrorMessage(ApiError.InvalidRequest, req);

            var imageReturn = await GetImageStreamAsync(leadParameterObject.LeadWebRequest.fileUrl, req, DemoConfiguration.MaxUrlMbs);
            if (!imageReturn.Successful)
               return GenerateErrorMessage(imageReturn.ErrorType.Value, req);

            using (imageReturn.Stream)
            {

               LoadDocumentOptions options = new LoadDocumentOptions()
               {
                  FirstPageNumber = leadParameterObject.LeadWebRequest.FirstPage,
                  LastPageNumber = leadParameterObject.LeadWebRequest.LastPage
               };

               RecognitionEngine recognitionEngine = new RecognitionEngine();
               recognitionEngine.WorkingDirectory = Path.GetTempPath();
               BarcodeEngine barcodeEngine = new BarcodeEngine();
               var barcodeResults = recognitionEngine.ExtractBarcode(imageReturn.Stream, options, barcodeEngine, barcodeList.ToArray(), 0, true);
               List<BarcodeResultData> results = new List<BarcodeResultData>();
               foreach (var pageBarcodeData in barcodeResults)
               {
                  foreach (var d in pageBarcodeData.BarcodeData)
                     if (d != null && d.Value != null)
                     {
                        var rect = new Rectangle(d.Bounds.X, d.Bounds.Y, d.Bounds.Width, d.Bounds.Height);
                        results.Add(new BarcodeResultData(pageBarcodeData.PageNumber, d.Symbology.ToString(), d.Value, rect, d.RotationAngle));
                     }
               }
               var returnRequest = req.CreateResponse(HttpStatusCode.OK);
               returnRequest.Content = new StringContent(JsonConvert.SerializeObject(results));
               return returnRequest;
            }
         }
         catch (Exception ex)
         {
            log.Error($"API Error occurred for request: {context.InvocationId} \n Details: {JsonConvert.SerializeObject(ex)}");
            return GenerateErrorMessage(ApiError.InternalServerError, req);
         }
      }
   }
}
