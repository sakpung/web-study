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
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using System.Linq;
using Leadtools.Medical.WebViewer.Common;

namespace Leadtools.Medical.WebViewer.Controllers
{
   [RoutePrefix("api/options")]
   public class OptionsController : ApiController
   {
      private IOptionsHandler _impl;
      public OptionsController(IOptionsHandler impl)
      {
         _impl = impl;
      }

      [Route("ping")]
      [HttpGet]
      public HttpResponseMessage ping()
      {
         HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, "value");
         response.Content = new StringContent("Leadtools Medical Services - Options", Encoding.Unicode);
         return response;
      }

      Exception Error(Exception e)
      {
         var message = string.Format(e.Message + "\r\n" + e.StackTrace);
         var errorResponse = Request.CreateErrorResponse(HttpStatusCode.NotFound, message);
         throw new HttpResponseException(errorResponse);
      }

      [Route("GetUserOptions")]
      [HttpGet]
      public Dictionary<string, string> GetUserOptions([FromUri]string auth)
      {
         return _impl.GetUserOptions(auth);
      }

      [Route("GetDefaultOptions")]
      [HttpGet]
      public Dictionary<string, string> GetDefaultOptions([FromUri]string authenticationCookie)
      {
         return _impl.GetDefaultOptions(authenticationCookie);
      }

      [Route("GetDefaultOption")]
      [HttpGet]
      public string GetDefaultOption([FromUri]string authenticationCookie, [FromUri]string key)
      {
         return _impl.GetDefaultOption(authenticationCookie, key);
      }

      [Route("SaveUserOption")]
      [HttpPost]

      public void SaveUserOption([FromBody]dynamic model)
      {
         _impl.SaveUserOption((string)model.authenticationCookie, (string)model.optionName, (string)model.optionValue);
      }

      [Route("SaveDefaultOptions")]
      [HttpPost]
      public void SaveDefaultOptions([FromBody]dynamic model)
      {
         //you may use (ParseTools.ToDictionary) to overwrite on duplicate keys
         var dict = ((JArray)model.options).ToDictionary(k => k.Values().First().Value<string>(), v => v.Values().Last().Value<string>());

         _impl.SaveDefaultOptions((string)model.authenticationCookie, dict);
      }

      [Route("GetRoleOption")]
      [HttpPost]
      public string GetRoleOption([FromBody]dynamic model)
      {
         return _impl.GetRoleOption((string)model.authenticationCookie, (string)model.role, (string)model.optionName);
      }

      [Route("SaveRoleOptions")]
      [HttpPost]
      public void SaveRoleOptions([FromBody]dynamic model)
      {
         //you may use (ParseTools.ToDictionary) to overwrite on duplicate keys
         var dict = ((JArray)model.options).ToDictionary(k => k.Values().First().Value<string>(), v => v.Values().Last().Value<string>());

         _impl.SaveRoleOptions((string)model.authenticationCookie, (string)model.role, dict);
      }
   }
}
