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
   [RoutePrefix("api/monitorcalibration")]
   public class MonitorCalibrationController : ApiController
   {
      private IMonitorCalibrationHandler _impl;
      public MonitorCalibrationController(IMonitorCalibrationHandler impl)
      {
         _impl = impl;
      }

      [Route("ping")]
      [HttpGet]
      public HttpResponseMessage ping()
      {
         HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, "value");
         response.Content = new StringContent("Leadtools Medical Services - MonitorCalibration", Encoding.Unicode);
         return response;
      }

      Exception Error(Exception e)
      {
         var message = string.Format(e.Message + "\r\n" + e.StackTrace);
         var errorResponse = Request.CreateErrorResponse(HttpStatusCode.NotFound, message);
         throw new HttpResponseException(errorResponse);
      }

      [Route("GetCalibrations")]
      [HttpGet]
      public CalibrationItem[] GetCalibrations([FromUri]string auth)
      {
         return _impl.GetCalibrations(auth);
      }

      [Route("AddCalibration")]
      [HttpPost]
      public void AddCalibration([FromBody]dynamic model)
      {
         _impl.AddCalibration((string)model.authenticationCookie, model.calibration.ToObject<CalibrationItem>());
      }
   }
}
