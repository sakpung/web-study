// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Leadtools.Medical.WebViewer.Services.Interfaces;
using Leadtools.Medical.WebViewerModels;
using Leadtools.Medical.WebViewer.DataContracts;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.IO;
using System.Web;
using Leadtools.Medical.WebViewer.Common;

namespace Leadtools.Medical.WebViewer.Controllers
{
   [RoutePrefix("api/export")]
   public class ExportController : ApiController
   {
      private IExportHandler _impl;
      
      public ExportController(IExportHandler impl)
      {
         _impl = impl;
      }

      [Route("ping")]
      [HttpGet]
      public HttpResponseMessage ping()
      {
         HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, "value");
         response.Content = new StringContent("Leadtools Medical Services - Export", Encoding.Unicode);
         return response;
      }
      
      private void DelayDelete(string authenticationCookie, string url, TimeSpan span)
      {
         try
         {
            var path = _impl.MapPath(authenticationCookie, url);
            Task.Delay(span).ContinueWith((t) =>
            {
               if (File.Exists(path))
               {
                  File.Delete(path);
               }
            });
         }
         catch { }
      }

      private HttpResponseMessage Prepare(string authenticationCookie, string url)
      {
         //schedule a delete after 1 min
         DelayDelete(authenticationCookie, url, TimeSpan.FromMinutes(1));

         var response = Request.CreateResponse(HttpStatusCode.OK);
         response.Content = new StringContent("export/ret?url=" + HttpUtility.UrlEncode(url));
         //client will have to append authentication: &auth=authenticationCookie, to the url
         return response;
      }

      private string DenoteContentDisposition(string url)
      {
         var pdf = Path.GetExtension(url).ToLower() == ".pdf";
         if (!pdf)
         {
            return "attachment";
         }
         else
         {
            return "inline";
         }
      }

      private string DenoteMediaType(string url)
      {
         var pdf = Path.GetExtension(url).ToLower() == ".pdf";
         if (!pdf)
         {
            return "application/octet-stream";
         }
         else
         {
            return "application/pdf";
         }
      }

      [Route("ret")]
      [HttpGet]
      public HttpResponseMessage ret([FromUri]string url, [FromUri]string auth)
      {
         try
         {
            var path = _impl.MapPath(auth, url);
            var stream = new FileStream(path, FileMode.Open);
            var result = new AutoDeleteFileHttpResponseMessage(path) { StatusCode = HttpStatusCode.OK };
            result.Content = new StreamContent(stream);
            result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue(DenoteContentDisposition(url)){ FileName = url };
            result.Content.Headers.ContentType = new MediaTypeHeaderValue(DenoteMediaType(url));
            result.Content.Headers.ContentLength = stream.Length;
            return result;
         }
         catch{}

         var errorResponse = Request.CreateErrorResponse(HttpStatusCode.NotFound, "File was not found!");
         throw new HttpResponseException(errorResponse);
      }
      
      [Route("ExportAllSeries")]
      [HttpPost]
      public async Task<HttpResponseMessage> ExportAllSeries([FromBody]dynamic model)
      {
         return Prepare((string)model.authenticationCookie,
            await _impl.ExportAllSeries((string)model.authenticationCookie, (string)model.patientID, model.options.ToObject<ExportOptions>()));
      }
      [Route("ExportSeries")]
      [HttpPost]
      public async Task<HttpResponseMessage> ExportSeries([FromBody]dynamic model)
      {
         return Prepare((string)model.authenticationCookie,
            await _impl.ExportSeries((string)model.authenticationCookie, model.seriesInstanceUIDs.ToObject<string[]>(), model.options.ToObject<ExportOptions>()));
      }
      [Route("ExportInstances")]
      [HttpPost]
      public async Task<HttpResponseMessage> ExportInstances([FromBody]dynamic model)
      {
         return Prepare((string)model.authenticationCookie,
            await _impl.ExportInstances((string)model.authenticationCookie, model.instanceUIDs.ToObject<string[]>(), model.options.ToObject<ExportOptions>()));
      }
      [Route("ExportLayout")]
      [HttpPost]
      public async Task<HttpResponseMessage> ExportLayout([FromBody]dynamic model)
      {
         return Prepare((string)model.authenticationCookie,
            await _impl.ExportLayout((string)model.authenticationCookie, (string)model.seriesInstanceUID, model.layout.ToObject<Layout>(), (bool)model.burnAnnotations, (CompressionType)model.compression, (int)model.width));
      }
      [Route("PrintAllSeries")]
      [HttpPost]
      public async Task<HttpResponseMessage> PrintAllSeries([FromBody]dynamic model)
      {
         if (model.patientID!=null)
         {
            return Prepare((string)model.authenticationCookie,
               await _impl.PrintAllSeries((string)model.authenticationCookie, (string)model.patientID, model.options.ToObject<PrintOptions>()));
         }
         else
         {
            return Prepare((string)model.authenticationCookie,
               await _impl.PrintSeries((string)model.authenticationCookie, model.seriesInstanceUIDs.ToObject<string[]>(), model.options.ToObject<PrintOptions>()));
         }
      }
      
      [Route("PrintInstances")]
      [HttpPost]
      public async Task<HttpResponseMessage> PrintInstances([FromBody]dynamic model)
      {
         return Prepare((string)model.authenticationCookie,
            await _impl.PrintInstances((string)model.authenticationCookie, model.instanceUIDs.ToObject<string[]>(), model.options.ToObject<PrintOptions>()));
      }
      [Route("PrintLayout")]
      [HttpPost]
      public async Task<HttpResponseMessage> PrintLayout([FromBody]dynamic model)
      {
         return Prepare((string)model.authenticationCookie,
         await _impl.PrintLayout((string)model.authenticationCookie, (string)model.seriesInstanceUID, model.layout.ToObject<Layout>(), model.options.ToObject<PrintOptions>()));
      }
      [Route("GetInstanceLocalPathName")]
      [HttpPost]
      public async Task<string> GetInstanceLocalPathName([FromBody]dynamic model)
      {
         return await _impl.GetInstanceLocalPathName((string)model.authenticationCookie, (string)model.instanceUID);
      }
   }
}
