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
using Leadtools;
using Leadtools.CloudServices;
using Leadtools.Document;
using Leadtools.Codecs;
using Serverless_Cloud_Services_API;
using static Serverless_Cloud_Services_API.CommonMethods;
using Leadtools.Forms.Commands;

namespace Serverless_Cloud_Services_API
{
   public static class ExtractCheck
   {
      [FunctionName("ExtractCheck")]
      public static async Task<HttpResponseMessage> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = "Recognition/ExtractCheck")]HttpRequestMessage req, TraceWriter log, ExecutionContext context)
      {
         try
         {
            if (!DemoConfiguration.UnlockSupport(log))
               return GenerateErrorMessage(ApiError.LicenseNotSet, req);

            var leadParameterObject = ParseLeadWebRequestParameters(req);
            if (!leadParameterObject.Successful)
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

               RecognitionEngine recognitionEngine = new RecognitionEngine
               {
                  WorkingDirectory = Path.GetTempPath(),
                  OcrEngine = GetOcrEngine()
               };

               var micrResults = recognitionEngine.ExtractMicr(imageReturn.Stream, options, BankCheckMicrFontType.Unknown);
               var returnRequest = req.CreateResponse(HttpStatusCode.OK);
               returnRequest.Content = new StringContent(JsonConvert.SerializeObject(micrResults));
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
