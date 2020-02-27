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
using System.IO;
using System.Collections.Generic;
using Leadtools.DataAccessLayers.Core;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Json;

namespace Leadtools.Medical.WebViewer.Controllers
{
   [RoutePrefix("api/template")]
   public class TemplateController : ApiController
   {
      private ITemplateHandler _impl;
      public TemplateController(ITemplateHandler impl)
      {
         _impl = impl;
      }

      [Route("ping")]
      [HttpGet]
      public HttpResponseMessage ping()
      {
         HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, "value");
         response.Content = new StringContent("Leadtools Medical Services - Template", Encoding.Unicode);
         return response;
      }

      Exception Error(Exception e)
      {
         var message = string.Format(e.Message + "\r\n" + e.StackTrace);
         var errorResponse = Request.CreateErrorResponse(HttpStatusCode.NotFound, message);
         throw new HttpResponseException(errorResponse);
      }

      [Route("GetAnatomicDescriptions")]
      [HttpGet]
      public List<AnatomicDescription> GetAnatomicDescriptions([FromUri]string auth, [FromUri]string data = null)
      {
         return _impl.GetAnatomicDescriptions(auth, data);
      }

      [Route("GetAllTemplates")]
      [HttpGet]
      public List<WCFTemplate> GetAllTemplates(string auth, string data = null)
      {
         return _impl.GetAllTemplates(auth, data);
      }

      [Route("AddTemplate")]
      [HttpPost]
      public void AddTemplate([FromBody]dynamic model)
      {
          _impl.AddTemplate((string)model.authenticationCookie, model.template.ToObject<WCFTemplate>(), (string)model.userData);
      }

      [Route("UpdateTemplate")]
      [HttpPost]
      public void UpdateTemplate([FromBody]dynamic model)
      {
         _impl.UpdateTemplate((string)model.authenticationCookie, model.template.ToObject<WCFTemplate>(), (string)model.userData);
      }

      [Route("DeleteTemplate")]
      [HttpPost]
      public void DeleteTemplate([FromBody]dynamic model)
      {
         _impl.DeleteTemplate((string)model.authenticationCookie, (string)model.templateId, (string)model.userData);
      }

      [Route("ExportAllTemplates")]
      [HttpGet]
      public HttpResponseMessage ExportAllTemplates([FromUri]string auth, [FromUri]string data = null)
      {
         var result = _impl.ExportAllTemplates(auth, data);
         var response = Request.CreateResponse(HttpStatusCode.OK);
         response.Content = new StreamContent(result);
         response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
         response.Content.Headers.Add("Content-Disposition", string.Format("attachment; filename=templates.json"));
         return response;
      }

      [Route("ImportTemplates")]
      [HttpPost]
      public List<WCFTemplate> ImportTemplates([FromBody]Stream file)
      {
         return _impl.ImportTemplates(file);
      }
   }
}
