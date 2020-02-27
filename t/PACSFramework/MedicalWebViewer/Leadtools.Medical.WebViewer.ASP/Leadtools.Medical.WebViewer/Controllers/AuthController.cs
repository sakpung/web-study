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
using Leadtools.Medical.WebViewer.DataContracts;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Configuration;

namespace Leadtools.Medical.WebViewer.Controllers
{
   [RoutePrefix("api/auth")]
   public class AuthController : ApiController
   {
      private IAuthHandler _impl;
      private Lazy<IAutoHandler> _auto;
      private Lazy<IOptionsHandler> _options;

      public AuthController(IAuthHandler impl, Lazy<IAutoHandler> auto, Lazy<IOptionsHandler> options)
      {
         _impl = impl;
         _auto = auto;
         _options = options;
      }

      [Route("ping")]
      [HttpGet]
      public HttpResponseMessage ping()
      {
         HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, "value");
         response.Content = new StringContent("Leadtools Medical Services - Authentication", Encoding.Unicode);
         return response;
      }

      HttpResponseException Error(Exception e)
      {
         return Error(e, true);
      }

      HttpResponseException Error(Exception e, bool stackTrace)
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
         return new HttpResponseException(errorResponse);
      }

      [Route("AuthenticateUser")]
      [HttpPost]
      public HttpResponseMessage AuthenticateUser([FromBody]dynamic model)
      {
         try
         {
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, "value");
            response.Content = new StringContent(_impl.AuthenticateUser((string)model.userName, (string)model.password, (string)model.userData), Encoding.ASCII);
            return response;
         }
         catch (Exception ex)
         {
            throw Error(ex, false);
         }
      }

      /// <summary>
      /// temporary authorizes an anonymous user for certain patient specified in the model
      /// 
      /// </summary>
      /// <param name="model"></param>
      /// <returns>encoded authentication info including a cookie</returns>
      [Route("TempAuthenticate")]
      [HttpPost]
      public async Task<AuthenticationInfo> TempAuthenticate([FromBody]dynamic model)
      {
         try
         {
            var protocol = (string)model.protocol;
            var cookie = (string)model.cookie;

            //read/decode request
            var req = _auto.Value.DecodeRequest(cookie, protocol);

            if(!_auto.Value.IsProtocolAllowed(protocol))
            {
               throw new Exception("Stronger protocol is required for this operation");
            }

            if (_auto.Value.HasReqExpired(req))
            {
               throw new Exception("Request has expired");
            }

            var user = req.GetValue("user").ToString();
            var admin = req.GetValue("admin").ToString();
            var adminPass = req.GetValue("pass").ToString();
            var role = req.GetValue("role").ToString();

            var adminCookie = _impl.AuthenticateUser(admin, adminPass, null, null);
             
            //cleanup
            try
            {
               var expired = _impl.ListExpiredTempUsers();

               foreach(var expiredUser in expired)
               {
                  _impl.DeleteUser(adminCookie, expiredUser, null);
                  //also remove any user options
                  _options.Value.DeleteUserOption(adminCookie, expiredUser);
               }
            }
            catch { }

            var ai = _impl.TempAuthenticate(adminCookie, user, role);
            
            //automate
            var autoCookie = _auto.Value.Automate(ai.Cookie);
            System.Diagnostics.Debug.Assert(autoCookie == ai.Cookie);//client relies on the fact they are equal

            var cmd = req.GetValue("cmd").ToString();
            var cmdParams = req.GetValue("p").ToString();

            await _auto.Value.QueueCommand(autoCookie, autoCookie, cmd, cmdParams);

            return ai;
         }
         catch (Exception ex)
         {
            throw Error(ex);
         }
      }

      /// <summary>
      /// authenticates a user who already been authenticated by an external IdP
      /// 
      /// </summary>
      /// <param name="model"></param>
      /// <returns>encoded authentication info including a cookie</returns>
      [Route("ImplicitAuthenticate")]
      [HttpPost]
      public AuthenticationInfo ImplicitAuthenticate([FromBody]dynamic model)
      {
         try
         {
            var protocol = (string)model.protocol;
            var cookie = (string)model.cookie;

            //read/decode request
            var req = _auto.Value.DecodeRequest(cookie, protocol);

            if (!_auto.Value.IsProtocolAllowed(protocol))
            {
               throw new Exception("Stronger protocol is required for this operation");
            }

            if(_auto.Value.HasReqExpired(req))
            {
               throw new Exception("Request has expired");
            }

            var user = req.GetValue("preferred_username").ToString();
            var auth_cookie = _impl.AuthenticateUser(user, null, null, null, null);
            var ai = _impl.GetAuthenticationInfo(auth_cookie, "");
            ai.Cookie = auth_cookie;
            return ai;
         }
         catch (Exception ex)
         {
            throw Error(ex);
         }
      }

      [Route("GetAuthenticationInfo")]
      [HttpPost]
      public AuthenticationInfo GetAuthenticationInfo([FromBody]dynamic model)
      {
         try
         {
            return _impl.GetAuthenticationInfo((string)model.authenticationCookie, (string)model.userData);
         }
         catch (Exception ex)
         {
            throw Error(ex);
         }
      }

      [Route("ValidatePermission")]
      [HttpPost]
      public AuthenticationInfo ValidatePermission([FromBody]dynamic model)
      {
         return _impl.ValidatePermission((string)model.authenticationCookie, (string)model.permission);
      }

      [Route("IsAuthenticated")]
      [HttpGet]
      public AuthenticationInfo IsAuthenticated([FromUri] string auth)
      {
         return _impl.IsAuthenticated(auth);
      }

      [Route("CreateUser")]
      [HttpPost]
      public void CreateUser([FromBody]dynamic model)
      {
         _impl.CreateUser((string)model.authenticationCookie, (string)model.userName, (string)model.password, (string)model.userType, null);
      }

      [Route("DeleteUser")]
      [HttpPost]
      public void DeleteUser([FromBody]dynamic model)
      {
         _impl.DeleteUser((string)model.authenticationCookie, (string)model.userName, (string)model.userData);
      }

      [Route("GetAllUsers")]
      [HttpGet]
      public dynamic GetAllUsers([FromUri]string auth, [FromUri]string data = null)
      {
         return _impl.GetAllUsers(auth);
      }

      [Route("ResetPassword")]
      [HttpPost]
      public bool ResetPassword([FromBody]dynamic model)
      {
         return _impl.ResetPassword((string)model.authenticationCookie, (string)model.userName, (string)model.newPassword, (string)model.userData);
      }

      [Route("ChangePassword")]
      [HttpPost]
      public bool ChangePassword([FromBody]dynamic model)
      {
         return _impl.ChangePassword((string)model.authenticationCookie, (string)model.userName, (string)model.oldPassword, (string)model.newPassword, (string)model.userData);
      }

      [Route("HasPermission")]
      [HttpGet]
      public bool HasPermission([FromUri]string name, [FromUri]string permit, [FromUri]string data = null)
      {
         return _impl.HasPermission(name, permit, data);
      }

      [Route("GetUserPermissions")]
      [HttpGet]
      public string[] GetUserPermissions([FromUri]string name, [FromUri]string data = null)
      {
         return _impl.GetUserPermissions(name, data);
      }

      [Route("GetUserRoles")]
      [HttpPost]
      public string[] GetUserRoles([FromBody]dynamic model)
      {
         return _impl.GetUserRoles((string)model.username, (string)model.userData);
      }

      [Route("GetPermissions")]
      [HttpPost]
      public Permission[] GetPermissions()
      {
         return _impl.GetPermissions();
      }

      [Route("GetRoles")]
      [HttpPost]
      public Role[] GetRoles()
      {
         return _impl.GetRoles();
      }

      [Route("GetRole")]
      [HttpPost]
      public Role GetRole([FromBody]string roleName)
      {
         return _impl.GetRole(roleName);
      }

      [Route("GetRolesNames")]
      [HttpPost]
      public string[] GetRolesNames()
      {
         return _impl.GetRolesNames();
      }

      [Route("CreateRole")]
      [HttpPost]
      public void CreateRole([FromBody]dynamic model)
      {
         _impl.CreateRole((string)model.authenticationCookie, model.role.ToObject<Role>());
      }

      [Route("UpdateRolePermissions")]
      [HttpPost]
      public void UpdateRolePermissions([FromBody]dynamic model)
      {
         _impl.UpdateRolePermissions((string)model.authenticationCookie, model.role.ToObject<Role>());
      }

      [Route("DeleteRole")]
      [HttpPost]
      public void DeleteRole([FromBody]dynamic model)
      {
         _impl.DeleteRole((string)model.authenticationCookie, (string)model.roleName);
      }

      [Route("GrantPermission")]
      [HttpPost]
      public void GrantPermission([FromBody]dynamic model)
      {
         _impl.GrantPermission((string)model.authenticationCookie, (string)model.username, (string)model.permission, (string)model.userData);
      }

      [Route("DenyPermission")]
      [HttpPost]
      public void DenyPermission([FromBody]dynamic model)
      {
         _impl.DenyPermission((string)model.authenticationCookie, (string)model.username, (string)model.permission, (string)model.userData);
      }

      [Route("GrantRole")]
      [HttpPost]
      public void GrantRole([FromBody]dynamic model)
      {
         _impl.GrantRole((string)model.authenticationCookie, (string)model.username, (string)model.role, (string)model.userData);
      }

      [Route("DenyRole")]
      [HttpPost]
      public void DenyRole([FromBody]dynamic model)
      {
         _impl.DenyRole((string)model.authenticationCookie, (string)model.username, (string)model.role, (string)model.userData);
      }

      [Route("IsAdmin")]
      [HttpGet]
      public bool IsAdmin([FromUri]string auth, [FromUri]string userName, [FromUri]string userData = null)
      {
         return _impl.IsAdmin(auth, userName, userData);
      }

      [Route("ValidatePassword")]
      [HttpPost]
      public string ValidatePassword([FromBody]dynamic model)
      {
         return _impl.ValidatePassword((string)model.password, (string)model.userData);
      }

      [Route("IsPasswordExpired")]
      [HttpGet]
      public bool IsPasswordExpired([FromUri]string userName)
      {
         return _impl.IsPasswordExpired(userName);
      }

      [Route("CreateUserExt")]
      [HttpPost]
      public string CreateUserExt([FromBody]dynamic model)
      {
         return _impl.CreateUserExt((string)model.username,
                  (string)model.password,
                  (string)model.adminUsername,
                  (string)model.adminPassword,
                  (bool)model.isAdmin,
                  model.permissions.ToObject<string[]>(),
                  model.roles.ToObject<string[]>(),
                  model.options.ToObject<CreateUserOptions>(),
                  model.userData);
      }
   }

}
