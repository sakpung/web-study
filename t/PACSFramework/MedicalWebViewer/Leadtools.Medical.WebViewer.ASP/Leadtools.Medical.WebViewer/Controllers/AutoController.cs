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
using System.Collections.Generic;
using System.Net.Http.Formatting;
using System.Threading.Tasks;

namespace Leadtools.Medical.WebViewer.Controllers
{
   [RoutePrefix("api/auto")]
   public class AutoController : ApiController
   {
      private IAutoHandler _impl;
      public AutoController(IAutoHandler impl)
      {
         _impl = impl;
      }

      [Route("ping")]
      [HttpGet]
      public HttpResponseMessage ping()
      {
         HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, "value");
         response.Content = new StringContent("Leadtools Medical Services - Automation", Encoding.Unicode);
         return response;
      }

      Exception Error(Exception e)
      {
         return Error(e, true);
      }

      Exception Error(Exception e, bool stackTrace)
      {
         string message;
         if (stackTrace)
         {
            message = string.Format(e.Message + "\r\n" + e.StackTrace);
         }
         else
         {
            message = string.Format(e.Message);
         }
         var errorResponse = Request.CreateErrorResponse(HttpStatusCode.NotFound, message);
         throw new HttpResponseException(errorResponse);
      }

      
      // Note that for compatibility issues, APIs that return strings are encapsulated in HttpResponseMessage
      // default serializer will add quotes around the string returned and we don't want that behavior
      [Route("Automate")]
      [HttpGet]
      public HttpResponseMessage Automate([FromUri] string auth)
      {
         try
         {
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, "value");
            response.Content = new StringContent(_impl.Automate(auth), Encoding.ASCII);
            return response;
         }
         catch (Exception ex)
         {
            throw Error(ex, false);
         }
      }

      [Route("IsAutomated")]
      [HttpGet]
      public bool IsAutomated([FromUri] string token)
      {
         try
         {
            return _impl.IsAutomated(token);
         }
         catch (Exception ex)
         {
            throw Error(ex, false);
         }
      }

      [Route("QueueCommand")]
      [HttpGet]
      public async Task<HttpResponseMessage> QueueCommand([FromUri] string token, [FromUri] string to, [FromUri] string name, [FromUri] string param)
      {
         try
         {
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, "value");
            response.Content = new StringContent(await _impl.QueueCommand(token, to, name, param), Encoding.ASCII);
            return response;
         }
         catch (Exception ex)
         {
            throw Error(ex, false);
         }
      }

      [Route("GetAndRemoveCommands")]
      [HttpGet]
      public async Task<List<Tuple<string, string, string>>> GetAndRemoveCommands([FromUri] string token)
      {
         try
         {
                string to = token;
            return await _impl.GetAndRemoveCommands(token, to);
         }
         catch (Exception ex)
         {
            throw Error(ex, false);
         }
      }

      [Route("ReportCommandStatus")]
      [HttpGet]
      public void ReportCommandStatus([FromUri] string token, [FromUri] string cmdId, [FromUri] string status, [FromUri] string message = null)
      {
         try
         {
            _impl.ReportCommandStatus(token, cmdId, status, message);
         }
         catch (Exception ex)
         {
            throw Error(ex, false);
         }
      }

      [Route("GetCommandStatus")]
      [HttpGet]
      public async Task<HttpResponseMessage> GetCommandStatus([FromUri] string token, [FromUri] string cmdId)
      {
         try
         {
            var result = await _impl.GetCommandStatus(token, cmdId);

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, "value");
            response.Content = new ObjectContent(typeof(object), new { status = result.Item1, error = result.Item2 } , new JsonMediaTypeFormatter());
            return response;
         }
         catch (Exception ex)
         {
            throw Error(ex, false);
         }
      }

      [Route("Logout")]
      [HttpGet]
      public void Logout([FromUri] string token, [FromUri] string reason = null)
      {
         try
         {
            _impl.Logout(token, reason);
         }
         catch (Exception ex)
         {
            throw Error(ex, false);
         }
      }

   }
}
