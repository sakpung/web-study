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

namespace Serverless_Cloud_Services_API
{
   public static class ExtractText
   {
      [DataContract]
      internal class ExtractTextData
      {
         [DataMember]
         public int PageNumber { get; set; }
         [DataMember]
         public string PageText { get; set; }
         [DataMember(IsRequired = false, EmitDefaultValue = false)]
         public object Words { get; set; }
         [DataMember(IsRequired = false, EmitDefaultValue = false)]
         public object Characters { get; set; }
      }

      [FunctionName("ExtractText")]
      public static async Task<HttpResponseMessage> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = "Recognition/ExtractText")]HttpRequestMessage req, TraceWriter log, ExecutionContext context)
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

               var documentPageText = recognitionEngine.ExtractText(imageReturn.Stream, options);
               List<ExtractTextData> PageDataList = new List<ExtractTextData>();
               int currentPage = options.FirstPageNumber;
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

               using (var ms = new MemoryStream())
               {
                  using (TextWriter tw = new StreamWriter(ms))
                  {
                     tw.Write(JsonConvert.SerializeObject(PageDataList));
                     tw.Flush();
                     ms.Position = 0;

                     Guid id = Guid.NewGuid();
                     string baseName = $"ExtractText-{id}.json";
                     var blobUri = UploadFileToBlobStorage(ms, baseName);
                     var returnRequest = req.CreateResponse(HttpStatusCode.OK);
                     returnRequest.Content = new StringContent(JsonConvert.SerializeObject(blobUri));
                     return returnRequest;
                  }
               }

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
