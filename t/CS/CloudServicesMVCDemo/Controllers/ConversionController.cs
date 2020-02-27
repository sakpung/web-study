using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
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

namespace Cloud_Services_Api.Controllers
{
   /// <summary>
   /// Controller to handle any conversion requests made to the service.
   /// </summary>
    public class ConversionController : BaseController
   {

      /// <summary>
      /// Service call to convert a file to any Raster-based LEADTOOLS supported format.  
      /// </summary>
      /// <returns>
      /// Body content of the response will contain a list of URLS.  
      /// </returns>
      [HttpPost]
      //For demoing purposes, GET requests are enabled on this endpoint. In a production environment, disable GET requests on this method.
      [HttpGet] 
      [Route("api/ConvertToRaster")]
      public async Task<HttpResponseMessage> ConvertToRaster([FromUri] RasterConversionWebRequest request)
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
               ConversionEngine conversion = new ConversionEngine()
               {
                  WorkingDirectory = DemoConfiguration.OutputFileDirectory
               };
               LoadDocumentOptions options = new LoadDocumentOptions()
               {
                  FirstPageNumber = request.FirstPage,
                  LastPageNumber = lastPage
               };

               var fileNameList = conversion.Convert(stream, options, request.Format, DocumentFormat.User);

               return new HttpResponseMessage(HttpStatusCode.OK)
               {
                  Content = new StringContent(JsonConvert.SerializeObject(fileNameList))
               };
            }
         }
         catch (Exception e)
         {
            return GenerateExceptionMessage(e);            
         }
      }

      /// <summary>
      /// Service call to convert a file to any Document-based LEADTOOLS supported format.  
      /// </summary>
      /// /// <returns>
      /// Body content of the response will contain a list of URLS 
      /// </returns>
      [HttpPost]
      //For demoing purposes, GET requests are enabled on this endpoint. In a production environment, disable GET requests on this method.
      [HttpGet]
      [Route("api/ConvertToDocument")]
      public async Task<HttpResponseMessage> ConvertToDocument([FromUri] DocumentConversionWebRequest request)
      {
         try
         {
            AuthenticateRequest();

            if (!VerifyCommonParameters(request))
               throw new Exception();

            using (var stream = await GetImageStream(request.fileUrl))
            {
               int lastPage = request.LastPage;
               ValidateFile(stream, ref lastPage);
               ConversionEngine conversion = new ConversionEngine()
               {
                  WorkingDirectory = DemoConfiguration.OutputFileDirectory,
                  OcrEngine = ocrEngine
               };

               LoadDocumentOptions options = new LoadDocumentOptions()
               {
                  FirstPageNumber = request.FirstPage,
                  LastPageNumber = lastPage
               };

               var fileNameList = conversion.Convert(stream, options, Leadtools.RasterImageFormat.Unknown, request.Format);
               return new HttpResponseMessage(HttpStatusCode.OK)
               {
                  Content = new StringContent(JsonConvert.SerializeObject(fileNameList))
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
