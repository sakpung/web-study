// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;

using Leadtools.Medical.WebViewer.DataContracts;
using System.IO;
using System.ServiceModel.Web;

namespace Leadtools.Medical.WebViewer.ServiceContracts
{

   public enum CreateUserOptions : long
   {
      None              = 0x00,
      CreateUser        = 0x01,
      UpdateUser        = 0x02,
      Login             = 0x04,
      UpdatePassword    = 0x10,
      UpdatePermissions = 0x20,
      UpdateRoles       = 0x40,
   }

   /// <summary>
   /// The service contract for the authentication service
   /// </summary>
   [ServiceContract]
   public interface IAuthenticationService
   {
      [OperationContract]
      [WebGet(UriTemplate = "/ping", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
      WcfPingResponse Ping();
      /// <summary>
      /// Authenticate a user
      /// </summary>
      /// <param name="userName">User name, must be previously created</param>
      /// <param name="password">Password</param>
      /// <param name="extraOptions">Extra options passed to implementation</param>
      /// <returns>an encrypted string (authenticationCookie), the returned string should be passed to
      /// all methods in the other services as the "authenticationCookie" parameter</returns>
      /// <remarks>
      /// In implementation, there should be string CreateAuthenticationCookie(userName, password)
      /// and IIdentity GetIdentity(authenticationCookie), this IIdentity is passed to the implementation
      /// ctors through the factory. GetIdentity will throw an exception if timed out or invalid
      /// Each operation in the services must specify what role it falls into. You must first call IsUserInRole to check if the user
      /// can perform the operation
      /// </remarks>
      [OperationContract]
      [WebInvokeAttribute ( BodyStyle=WebMessageBodyStyle.WrappedRequest)]
      Stream AuthenticateUser(string userName, string password, string userData) ;

      /// <summary>
      /// Returns the info for the authentication cookie such as user name, expiration time and any extra options
      /// </summary>
      /// <param name="authenticationCookie">Cookie</param>
      /// <param name="extraOptions">Extra options</param>
      /// <returns>AuthenticationInfo</returns>
      /// <remarks>
      /// Copy same extra options in the return value .ExtraOption property in default implementation
      /// </remarks>
      [OperationContract]
      [WebInvokeAttribute ( BodyStyle=WebMessageBodyStyle.WrappedRequest, ResponseFormat=WebMessageFormat.Json)]
      AuthenticationInfo GetAuthenticationInfo(string authenticationCookie, string userData);

      /// <summary>
      /// Checks if the cookie is timed out
      /// </summary>
      /// <param name="AuthenticationInfo">Authentication Info</param>
      /// <param name="extraOptions">Extra options</param>
      /// <returns>true/false</returns>
      /// <remarks>
      /// If timed out, the app needs to call AuthenticateUser again
      /// </remarks>
      [OperationContract]
      [WebInvokeAttribute ( BodyStyle=WebMessageBodyStyle.WrappedRequest)]
      bool IsTimedOut(AuthenticationInfo ai, string userData);

      /// <summary>
      /// validates the cookie for being authorized and against the passed permission
      /// throws an exception if not valid for any reason
      /// </summary>
      /// <param name="authenticationCookie">Cookie</param>
      /// <param name="permission">permission name, pass empty string for validating cookie only</param>
      [OperationContract]
      [WebInvokeAttribute ( BodyStyle=WebMessageBodyStyle.WrappedRequest)]
      AuthenticationInfo ValidatePermission(string authenticationCookie, string permission);

      /// <summary>
      /// validates the cookie for authentication
      /// </summary>
      /// <param name="authenticationCookie">cookie</param>
      /// <returns></returns>
      [OperationContract]
      [WebGet ( UriTemplate = "/IsAuthenticated?auth={authenticationCookie}",
                BodyStyle=WebMessageBodyStyle.WrappedRequest, RequestFormat=WebMessageFormat.Json, ResponseFormat=WebMessageFormat.Json)]
      AuthenticationInfo IsAuthenticated(string authenticationCookie);

      [OperationContract]
      [WebInvokeAttribute(BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
      void CreateUser(string authenticationCookie, string userName, string password, string userType);

      [OperationContract]
      [WebInvokeAttribute(BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
      void DeleteUser(string authenticationCookie, string userName, string userData);

      [OperationContract]
      [WebGet(UriTemplate = "/GetAllUsers?auth={authenticationCookie}&data={userData}",
                BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
      string[] GetAllUsers(string authenticationCookie, string userData);

      [OperationContract]
      [WebInvokeAttribute(BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
      bool ResetPassword(string authenticationCookie, string userName, string newPassword, string userData);

      [OperationContract]
      [WebInvokeAttribute(BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
      bool ChangePassword(string authenticationCookie, string userName, string oldPassword, string newPassword, string userData);

      /// <summary>
      /// Checks if permission is available for a user
      /// </summary>
      /// <param name="username">user name</param>
      /// <param name="permission">permission name</param>
      /// <param name="extraOptions">Extra options</param>
      /// <returns></returns>
      [OperationContract]
      [WebGet(UriTemplate = "/HasPermission?name={userName}&permit={permission}&data={userData}",
                BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
      bool HasPermission(string username, string permission, string userData);

      /// <summary>
      /// returns user's permissions
      /// </summary>
      /// <param name="username">user name</param>
      /// <param name="extraOptions">Extra options</param>
      /// <returns>array of permissions names</returns>
      [OperationContract]
      [WebGet(UriTemplate = "/GetUserPermissions?name={userName}&data={userData}",
                BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
      string[] GetUserPermissions(string username, string userData);

      /// <summary>
      /// returns user's roles
      /// </summary>
      /// <param name="username">user name</param>
      /// <param name="extraOptions">Extra options</param>
      /// <returns>array of roles names</returns>
      [OperationContract]
      [WebInvokeAttribute(BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
      string[] GetUserRoles(string username, string userData);

      [OperationContract]
      [WebInvokeAttribute(BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
      Permission[] GetPermissions();

      [OperationContract]
      [WebInvokeAttribute(BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
      Role[] GetRoles();

      [OperationContract]
      [WebInvokeAttribute(BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
      Role GetRole(string roleName);

      [OperationContract]
      [WebInvokeAttribute(BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
      string[] GetRolesNames();

      [OperationContract]
      [WebInvokeAttribute(BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
      void CreateRole(string authenticationCookie, Role role);

      [OperationContract]
      [WebInvokeAttribute(BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
      void UpdateRolePermissions(string authenticationCookie, Role role);
      
      [OperationContract]
      [WebInvokeAttribute(BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
      void DeleteRole(string authenticationCookie, string roleName);

      /// <summary>
      /// adds permission
      /// </summary>
      /// <param name="username">usern name</param>
      /// <param name="permission">permission name</param>
      /// <param name="extraOptions">extra options</param>
      [OperationContract]
      [WebInvokeAttribute(BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
      void GrantPermission(string authenticationCookie, string username, string permission, string userData);

      /// <summary>
      /// removes permission
      /// </summary>
      /// <param name="username">usern name</param>
      /// <param name="permission">permission name</param>
      /// <param name="extraOptions">extra options</param>
      [OperationContract]
      [WebInvokeAttribute(BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
      void DenyPermission(string authenticationCookie, string username, string permission, string userData);

      /// <summary>
      /// adds role
      /// </summary>
      /// <param name="username">usern name</param>
      /// <param name="permission">permission name</param>
      /// <param name="extraOptions">extra options</param>
      [OperationContract]
      [WebInvokeAttribute(BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
      void GrantRole(string authenticationCookie, string username, string role, string userData);

      /// <summary>
      /// removes role
      /// </summary>
      /// <param name="username">usern name</param>
      /// <param name="permission">permission name</param>
      /// <param name="extraOptions">extra options</param>
      [OperationContract]
      [WebInvokeAttribute(BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
      void DenyRole(string authenticationCookie, string username, string role, string userData);

      [OperationContract]
      [WebGet(UriTemplate = "/IsAdmin?auth={authenticationCookie}&userName={userName}&userData={userData}",
                BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
      bool IsAdmin ( string authenticationCookie, string userName, string userData ) ;

      [OperationContract]
      [WebInvokeAttribute(BodyStyle = WebMessageBodyStyle.WrappedRequest, ResponseFormat=WebMessageFormat.Json)]
      string ValidatePassword(string password, string userData);

      [OperationContract]
      [WebGet(UriTemplate = "/IsPasswordExpired?userName={userName}",
                BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
      bool IsPasswordExpired(string userName);


      [OperationContract]
      [WebInvokeAttribute(BodyStyle = WebMessageBodyStyle.WrappedRequest, ResponseFormat=WebMessageFormat.Json)]
      string CreateUserExt(
                                    string username, 
                                    string password,
                                    string adminUsername,
                                    string adminPassword,
                                    bool   isAdmin,
                                    string []permissions,
                                    string []roles,
                                    CreateUserOptions options,
                                    string userData
                                    );
   }
}
