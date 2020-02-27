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
using Leadtools.Medical.WebViewer.Common;
using Microsoft.Practices.Unity;
using System.Threading.Tasks;

namespace Leadtools.Medical.WebViewer.Controllers
{
   [RoutePrefix("api/pacsretrieve")]
   public class PACSRetrieveController : ApiController
   {
      private IPacsRetrieveHandler _impl;
      private IPacsRetrieveHandler _wimpl;

      public PACSRetrieveController([Dependency("pacsretrieve")] IPacsRetrieveHandler impl, [Dependency("wadoaspacsretrieve")] IPacsRetrieveHandler wimpl)
      {
         _impl = impl;
         _wimpl = wimpl;
      }
            
      private IPacsRetrieveHandler impl(dynamic model)
      {
         var server = RemoteConnectionFactory.BaseServer(model);
         if (RemoteConnectionFactory.IsWADO(server))
            return _wimpl;
         else 
            return _impl;
      }

      [Route("ping")]
      [HttpGet]
      public HttpResponseMessage ping()
      {
         HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, "value");
         response.Content = new StringContent("Leadtools Medical Services - PACSRetrieve", Encoding.Unicode);
         return response;
      }

      Exception Error(Exception e)
      {
         var message = string.Format(e.Message + "\r\n" + e.StackTrace);
         var errorResponse = Request.CreateErrorResponse(HttpStatusCode.NotFound, message);
         throw new HttpResponseException(errorResponse);
      }

      [Route("DownloadImages")]
      [HttpPost]
      public Task<DownloadInfo> DownloadImages([FromBody]dynamic model)
      {
         return impl(model).DownloadImages((string)model.authenticationCookie,
         RemoteConnectionFactory.Server(model),
         (string)model.client,
         (string)model.patientID,
         (string)model.studyInstanceUID,
         (string)model.seriesInstanceUID,
         (string)model.sopInstanceUID,
         ParseTools.ToObject<ExtraOptions>(model.extraOptions));
      }

      [Route("UpdateDownloadInfoStatus")]
      [HttpPost]
      public Task<DownloadInfo> UpdateDownloadInfoStatus([FromBody]dynamic model)
      {
         return impl(model).UpdateDownloadInfoStatus((string)model.authenticationCookie, model.info.ToObject<DownloadInfo>());
      }

      [Route("GetJobStatus")]
      [HttpPost]
      public Task<JobStatus[]> GetJobStatus([FromBody]dynamic model)
      {
         return impl(model).GetJobStatus((string)model.authenticationCookie, model.JobsIds.ToObject<string[]>());
      }


      [Route("GetDownloadInfos")]
      [HttpPost]
      public Task<DownloadInfo[]> GetDownloadInfos([FromBody]dynamic model)
      {
         return impl(model).GetDownloadInfos((string)model.authenticationCookie,
                                      RemoteConnectionFactory.Server(model),
                                      (string)model.client,
                                      (string)model.patientID,
                                      (string)model.studyInstanceUID,
                                      (string)model.seriesInstanceUID,
                                      (string)model.sopInstanceUID,
                                      (DownloadStatus)model.status);
      }


      [Route("DeleteImages")]
      [HttpPost]
      public Task DeleteImages([FromBody]dynamic model)
      {
         return impl(model).DeleteImages((string)model.authenticationCookie, (string)model.patientID,
               (string)model.studyInstanceUID,
               (string)model.seriesInstanceUID,
               (string)model.sopInstanceUID);
      }

      [Route("DeleteDownloadInfos")]
      [HttpPost]
      public Task DeleteDownloadInfos([FromBody]dynamic model)
      {
         return impl(model).DeleteDownloadInfos((string)model.authenticationCookie, model.jobIds.ToObject<int[]>());
      }
   }
}
