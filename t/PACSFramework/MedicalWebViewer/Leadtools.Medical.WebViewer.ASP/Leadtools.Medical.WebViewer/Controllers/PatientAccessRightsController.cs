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
using Leadtools.Medical.WebViewer.Common;

namespace Leadtools.Medical.WebViewer.Controllers
{
   [RoutePrefix("api/patientaccessrights")]
   public class PatientAccessRightsController : ApiController
   {
      private IPatientAccessRightsHandler _impl;
      public PatientAccessRightsController(IPatientAccessRightsHandler impl)
      {
         _impl = impl;
      }

      [Route("ping")]
      [HttpGet]
      public HttpResponseMessage ping()
      {
         HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, "value");
         response.Content = new StringContent("Leadtools Medical Services - PatientAccessRights", Encoding.Unicode);
         return response;
      }

      Exception Error(Exception e)
      {
         var message = string.Format(e.Message + "\r\n" + e.StackTrace);
         var errorResponse = Request.CreateErrorResponse(HttpStatusCode.NotFound, message);
         throw new HttpResponseException(errorResponse);
      }

      [Route("GrantUserPatients")]
      [HttpPost]
      public void GrantUserPatients([FromBody]dynamic model)
      {
         _impl.GrantUserPatients((string)model.authenticationCookie, (string)model.user, ParseTools.ToObject<List<string>>(model.patientIds));
      }
      [Route("GrantUserAccess")]
      [HttpPost]
      public void GrantUserAccess([FromBody]dynamic model)
      {
         _impl.GrantUserAccess((string)model.authenticationCookie, ParseTools.ToObject<UserPermissions>(model.userAccess));
      }
      [Route("DenyUserAccess")]
      [HttpPost]
      public void DenyUserAccess([FromBody]dynamic model)
      {
         _impl.DenyUserAccess((string)model.authenticationCookie, ParseTools.ToObject<UserPermissions>(model.userAccess));
      }
      [Route("GrantRolePatients")]
      [HttpPost]
      public void GrantRolePatients([FromBody]dynamic model)
      {
         _impl.GrantRolePatients((string)model.authenticationCookie, (string)model.role, ParseTools.ToObject<List<string>>(model.patientIds));
      }
      [Route("GrantRoleAccess")]
      [HttpPost]
      public void GrantRoleAccess([FromBody]dynamic model)
      {
         _impl.GrantRoleAccess((string)model.authenticationCookie, ParseTools.ToObject<RolePermissions>(model.roleAccess));
      }
      [Route("DenyRoleAccess")]
      [HttpPost]
      public void DenyRoleAccess([FromBody]dynamic model)
      {
         _impl.DenyRoleAccess((string)model.authenticationCookie, ParseTools.ToObject<RolePermissions>(model.roleAccess));
      }
      [Route("GetUserAccess")]
      [HttpPost]
      public UserPermissions[] GetUserAccess([FromBody]dynamic model)
      {
         return _impl.GetUserAccess((string)model.authenticationCookie, (string)model.user);
      }
      [Route("GetRoleAccess")]
      [HttpPost]
      public RolePermissions[] GetRoleAccess([FromBody]dynamic model)
      {
         return _impl.GetRoleAccess((string)model.authenticationCookie, (string)model.role);
      }
      [Route("GetRolesAccess")]
      [HttpPost]
      public RolePermissions[] GetRolesAccess([FromBody]dynamic model)
      {
         return _impl.GetRolesAccess((string)model.authenticationCookie, ParseTools.ToObject<List<string>>(model.roles));
      }

   }
}
