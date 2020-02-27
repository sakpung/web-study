using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using Leadtools;
using Leadtools.CloudServices;
using Leadtools.Document;
using Leadtools.Codecs;
using Serverless_Cloud_Services_API;
using static Serverless_Cloud_Services_API.CommonMethods;
using System;
using Leadtools.Document.Writer;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Serverless_Cloud_Services_API
{

   public static class ConvertToDocument
   {
      internal static ConvertToDocumentParseReturn ParseConvertToDocumentParameters(HttpRequestMessage request)
      {
         var nameValuePairs = request.GetQueryNameValuePairs();

         var outputFormat = nameValuePairs.FirstOrDefault(q => string.Compare(q.Key, "format", true) == 0).Value;

         if (Enum.TryParse(outputFormat, true, out DocumentFormat format) && Enum.IsDefined(typeof(DocumentFormat), format.ToString()))
         {
            return new ConvertToDocumentParseReturn()
            {
               Successful = true,
               OutputFormat = format
            };
         }

         return new ConvertToDocumentParseReturn() { Successful = false };
      }

      [FunctionName("ConvertToDocument")]
      public static async Task<HttpResponseMessage> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = "Conversion/ConvertToDocument")]HttpRequestMessage req, TraceWriter log, ExecutionContext context)
      {
         try
         {
            if (!DemoConfiguration.UnlockSupport(log))
               return GenerateErrorMessage(ApiError.LicenseNotSet, req);

            var leadParameterObject = ParseLeadWebRequestParameters(req);
            if (!leadParameterObject.Successful)
               return GenerateErrorMessage(ApiError.InvalidRequest, req);

            var convertToDocuemntParameterObject = ParseConvertToDocumentParameters(req);
            if (!convertToDocuemntParameterObject.Successful)
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

               ConversionEngine engine = new ConversionEngine
               {
                  OcrEngine = GetOcrEngine(),
                  Preprocess = false,
                  UseThreads = false
               };
               var filenamelist = engine.Convert(imageReturn.Stream, options, RasterImageFormat.Unknown , convertToDocuemntParameterObject.OutputFormat);

               var returnRequest = req.CreateResponse(HttpStatusCode.OK);
               returnRequest.Content = new StringContent(JsonConvert.SerializeObject(filenamelist));
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
