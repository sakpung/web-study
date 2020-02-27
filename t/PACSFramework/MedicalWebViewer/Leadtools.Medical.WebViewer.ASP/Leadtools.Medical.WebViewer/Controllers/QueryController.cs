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
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Leadtools.Medical.WebViewer.Common;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using System.Net.Http.Headers;

namespace Leadtools.Medical.WebViewer.Controllers
{
   [RoutePrefix("api/query")]
   public class QueryController : ApiController
   {
      private IQueryHandler _impl;
      private IQueryHandler _wimpl;
      
      public QueryController([Dependency("local")] IQueryHandler impl, [Dependency("wado")] IQueryHandler wimpl, IThreeDHandler threedmpl)
      {
         _impl = impl;
         _wimpl = wimpl;         
      }

      [Route("ping")]
      [HttpGet]
      public HttpResponseMessage ping()
      {
         HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, "value");
         response.Content = new StringContent("Leadtools Medical Services - ObjectQuery", Encoding.Unicode);
         return response;
      }

      Exception Error(Exception e)
      {
         var message = string.Format(e.Message + "\r\n" + e.StackTrace);
         var errorResponse = Request.CreateErrorResponse(HttpStatusCode.NotFound, message);
         throw new HttpResponseException(errorResponse);
      }

      private IQueryHandler impl(dynamic model)
      {
         return _impl;
      }

      [Route("FindPatients")]
      [HttpPost]
      public async Task<PatientData[]> FindPatients([FromBody]dynamic model)
      {
         return await impl(model).FindPatients((string)model.authenticationCookie, ParseTools.ToObject<QueryOptions>(model.options), ParseTools.ToObject<ExtraOptions>(model.extraOptions));
      }

      [Route("FindStudies")]
      [HttpPost]
      public async Task<StudyData[]> FindStudies([FromBody]dynamic model)
      {
         return await impl(model).FindStudies((string)model.authenticationCookie, ParseTools.ToObject<QueryOptions>(model.options), ParseTools.ToObject<ExtraOptions>(model.extraOptions));
      }

      [Route("FindSeries")]
      [HttpPost]
      public async Task<SeriesData[]> FindSeries([FromBody]dynamic model)
      {
         return await impl(model).FindSeries((string)model.authenticationCookie, ParseTools.ToObject<QueryOptions>(model.options), ParseTools.ToObject<ExtraOptions>(model.extraOptions));
      }

      [Route("FindInstances")]
      [HttpPost]
      public async Task<InstanceData[]> FindInstances([FromBody]dynamic model)
      {
         var fullUrl = Request.RequestUri.OriginalString;
         var index = fullUrl.LastIndexOf("/api/");
         var baseUrl = fullUrl.Substring(0, index + 1);
         return await impl(model).FindInstances((string)model.authenticationCookie, ParseTools.ToObject<QueryOptions>(model.options), baseUrl, ParseTools.ToObject<ExtraOptions>(model.extraOptions));
      }

      [Route("ElectStudyTimeLineInstances")]
      [HttpPost]
      public DICOMQueryResult ElectStudyTimeLineInstances([FromBody]dynamic model)
      {
         return impl(model).ElectStudyTimeLineInstances((string)model.authenticationCookie, ParseTools.ToObject<QueryOptions>(model.options));
      }

      [Route("FindPresentationState")]
      [HttpGet]
      public PresentationStateData[] FindPresentationState([FromUri]string auth, [FromUri]string series, [FromUri]string data = null)
      {
         return impl(data).FindPresentationState(auth, series, data);

         //consider adding this following line:
         //.Headers.Add ( "Cache-Control", "must-revalidate, max-age=0" ) ;
      }

      [Route("HasPresentationState")]
      [HttpGet]
      public bool HasPresentationState([FromUri]string auth, [FromUri]string series, [FromUri]string instance, [FromUri]string data = null)
      {
         return impl(data).HasPresentationState(auth, series, instance, data);
      }

      [Route("AutoComplete")]
      [HttpGet]
      public WordResult[] AutoComplete([FromUri]string auth, [FromUri]string key, [FromUri]string term, [FromUri]string data = null)
      {
         return impl(data).AutoComplete(auth, key, term, data);
      }

      [Route("FindHangingProtocols")]
      [HttpPost]
      public HangingProtocolQueryResult[] FindHangingProtocols([FromBody]dynamic model)
      {
         return impl(model).FindHangingProtocols((string)model.authenticationCookie, (string)model.studyInstanceUID, (string)model.userData);
      }      
   }
}
