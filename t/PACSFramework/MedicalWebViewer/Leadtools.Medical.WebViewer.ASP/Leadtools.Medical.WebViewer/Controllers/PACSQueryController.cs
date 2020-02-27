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
using Leadtools.Medical.WebViewer.Services;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;

namespace Leadtools.Medical.WebViewer.Controllers
{
   [RoutePrefix("api/pacsquery")]
   public class PacsQueryController : ApiController
   {
      private IPacsQueryHandler _impl;
      private IPacsQueryHandler _wimpl;
      private Lazy<ConnectionSettings> _connectionSettings;

      public PacsQueryController([Dependency("pacsquery")] IPacsQueryHandler impl, [Dependency("wadoaspacsquery")] IPacsQueryHandler wimpl, Lazy<ConnectionSettings> connectionSettings)
      {
         _impl = impl;
         _wimpl = wimpl;
         _connectionSettings = connectionSettings;
      }
      
      private IPacsQueryHandler impl(dynamic model)
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
         response.Content = new StringContent("Leadtools Medical Services - PACSQuery", Encoding.Unicode);
         return response;
      }

      Exception Error(Exception e)
      {
         var message = string.Format(e.Message + "\r\n" + e.StackTrace);
         var errorResponse = Request.CreateErrorResponse(HttpStatusCode.NotFound, message);
         throw new HttpResponseException(errorResponse);
      }

      
      /// <summary>
      /// Gets the local database info, required to return local AETitle, anything else is up to implementer
      /// </summary>
      /// <returns>Client connection info</returns>
      [Route("GetConnectionInfo")]
      [HttpGet]
      public PACSConnection[] GetConnectionInfo()
      {
         var storageServerConnection = _connectionSettings.Value.StorageServerConnection;
         var clientConnection = _connectionSettings.Value.ClientConnection;
         return new PACSConnection[] { clientConnection, storageServerConnection };
      }

      [Route("FindPatients")]
      [HttpPost]
      public async Task<PatientData[]> FindPatients([FromBody]dynamic model)
      {
         return await impl(model).FindPatients((string)model.authenticationCookie, RemoteConnectionFactory.Server(model), model.client.ToObject<ClientConnection>(), model.options.ToObject<QueryOptions>());
      }

      [Route("FindStudies")]
      [HttpPost]
      public async Task<StudyData[]> FindStudies([FromBody]dynamic model)
      {
         return await impl(model).FindStudies((string)model.authenticationCookie, RemoteConnectionFactory.Server(model), model.client.ToObject<ClientConnection>(), model.options.ToObject<QueryOptions>());
      }

      [Route("FindSeries")]
      [HttpPost]
      public async Task<SeriesData[]> FindSeries([FromBody]dynamic model)
      {
         return await impl(model).FindSeries((string)model.authenticationCookie, RemoteConnectionFactory.Server(model), model.client.ToObject<ClientConnection>(), model.options.ToObject<QueryOptions>());
      }

      [Route("FindInstances")]
      [HttpPost]
      public async Task<InstanceData[]> FindInstances([FromBody]dynamic model)
      {
         return await impl(model).FindInstances((string)model.authenticationCookie, RemoteConnectionFactory.Server(model), model.client.ToObject<ClientConnection>(), model.options.ToObject<QueryOptions>());
      }

      [Route("ElectStudyTimeLineInstances")]
      [HttpPost]
      public async Task<DICOMQueryResult> ElectStudyTimeLineInstances([FromBody]dynamic model)
      {
         return await impl(model).ElectStudyTimeLineInstances((string)model.authenticationCookie, RemoteConnectionFactory.Server(model), model.client.ToObject<ClientConnection>(), model.options.ToObject<QueryOptions>());
      }

      [Route("VerifyConnection")]
      [HttpPost]
      public async Task<string> VerifyConnection([FromBody]dynamic model)
      {
         return await impl(model).VerifyConnection((string)model.authenticationCookie, RemoteConnectionFactory.Server(model), model.client.ToObject<ClientConnection>());
      }
   }
}
