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

namespace Leadtools.Medical.WebViewer.Controllers
{
   [RoutePrefix("api/patient")]
   public class PatientController : ApiController
   {
      private IPatientHandler _impl;
      public PatientController(IPatientHandler impl)
      {
         _impl = impl;
      }

      [Route("ping")]
      [HttpGet]
      public HttpResponseMessage ping()
      {
         HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, "value");
         response.Content = new StringContent("Leadtools Medical Services - Patient", Encoding.Unicode);
         return response;
      }

      Exception Error(Exception e)
      {
         var message = string.Format(e.Message + "\r\n" + e.StackTrace);
         var errorResponse = Request.CreateErrorResponse(HttpStatusCode.NotFound, message);
         throw new HttpResponseException(errorResponse);
      }

      [Route("UpdatePatient")]
      [HttpPost]
      public bool UpdatePatient([FromBody]dynamic model)
      {
         return _impl.UpdatePatient((string)model.authenticationCookie, model.info.ToObject<PatientInfo_Json>());
      }

      [Route("AddPatient")]
      [HttpPost]
      public bool AddPatient([FromBody]dynamic model)
      {
         return _impl.AddPatient((string)model.authenticationCookie, model.info.ToObject<PatientInfo_Json>(), (string)model.userData);
      }

      [Route("DeletePatient")]
      [HttpPost]
      public bool DeletePatient([FromBody]dynamic model)
      {
         return _impl.DeletePatient((string)model.patientId);
      }
   }
}
