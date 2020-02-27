// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Leadtools.Medical.WebViewer.Common
{
   public class RequireHttpsAttribute : AuthorizationFilterAttribute
   {
      public override void OnAuthorization(HttpActionContext actionContext)
      {
         if (actionContext.Request.RequestUri.Scheme != Uri.UriSchemeHttps)
         {
            actionContext.Response = new HttpResponseMessage(System.Net.HttpStatusCode.Forbidden)
            {
               ReasonPhrase = "HTTPS Required"
            };
         }
         else
         {
            base.OnAuthorization(actionContext);
         }
      }
   }
}
