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

namespace Leadtools.Medical.WebViewer.Controllers
{
   [RoutePrefix("api/audit")]
   public class AuditController : ApiController
   {
      private IAuditHandler _impl;
      public AuditController(IAuditHandler impl)
      {
         _impl = impl;
      }

      [Route("ping")]
      [HttpGet]
      public HttpResponseMessage ping()
      {
         HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, "value");
         response.Content = new StringContent("Leadtools Medical Services - Auditing", Encoding.Unicode);
         return response;
      }

      [Route("Log")]
      [HttpPost]
      public void Log([FromBody]dynamic model)
      {
         _impl.Log((string)model.authenticationCookie, (string)model.user, (string)model.workstation, (DateTime)model.date, (string)model.details, (string)model.userData);
      }

   }
}
