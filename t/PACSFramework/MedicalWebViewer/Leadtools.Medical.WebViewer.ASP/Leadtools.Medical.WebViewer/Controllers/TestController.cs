// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using Leadtools.Medical.WebViewerModels;
using System;
using System.Web.Http;

namespace Leadtools.Medical.WebViewer.Controllers
{
   [RoutePrefix("api/test")]
   public class TestController : ApiController
   {
      /* This Ping() method is used to detect that everything is working fine
       * before a demo begins. Otherwise, errors from loading the initial document
       * may tell the wrong story because the user hasn't set up the service yet.
       */

      public TestController()
      {
         // There is no need to call ServiceHelper.InitializeController here since this controller will
         // set the license manually to check for errors
      }

      /// <summary>
      ///   Pings the service to ensure a connection, returning data about the status of the LEADTOOLS license.
      /// </summary>
      [Route("ping")]
      [HttpPost, HttpGet]
      public PingResponse Ping()
      {
         var response = new PingResponse();
         response.message = "Ready";
         response.time = DateTime.Now;

         try
         {
            response.isLicenseChecked = true;
            response.isLicenseExpired = RasterSupport.KernelExpired;
            response.kernelType = RasterSupport.KernelType.ToString();
         }
         catch (Exception)
         {
            response.isLicenseChecked = false;
            response.isLicenseExpired = true;
            response.kernelType = null;
         }

         return response;
      }
   }
}
