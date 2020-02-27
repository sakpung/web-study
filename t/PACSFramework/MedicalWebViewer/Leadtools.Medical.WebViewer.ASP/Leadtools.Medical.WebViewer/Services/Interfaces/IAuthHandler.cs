// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using Leadtools.Medical.WebViewer.DataContracts;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Leadtools.Medical.WebViewer.Services.Interfaces
{
   public enum CreateUserOptions : long
   {
      None = 0x00,
      CreateUser = 0x01,
      UpdateUser = 0x02,
      Login = 0x04,
      UpdatePassword = 0x10,
      UpdatePermissions = 0x20,
      UpdateRoles = 0x40,
   }

   public interface IAuthHandler
   {
      /// <summary>
      /// Authenticate a user
      /// </summary>
      /// <param name="userName">User name, must be previously created</param>
      /// <param name="password">Password</param>
      /// <param name="userData">Extra options passed to implementation</param>
      /// <param name="lifeTime">overrides the 10 hours lifetime</param>
      /// <param name="impersonatedUser">impersonated user</param>
      /// <returns>an encrypted string (authenticationCookie), the returned string should be passed to
      /// all methods in the other services as the "authenticationCookie" parameter</returns>
      /// <remarks>
      /// In implementation, there should be string CreateAuthenticationCookie(userName, password)
      /// and IIdentity GetIdentity(authenticationCookie), this IIdentity is passed to the implementation
      /// ctors through the factory. GetIdentity will throw an exception if timed out or invalid
      /// Each operation in the services must specify what role it falls into. You must first call IsUserInRole to check if the user
      /// can perform the operation
      /// </remarks>
      string AuthenticateUser(string userName, string password, string userData, TimeSpan? lifeTime=null, string impersonatedUser=null);

      /// <summary>
      /// Returns the info for the authentication cookie such as user name, expiration time and any extra options
      /// </summary>
      /// <param name="authenticationCookie">Cookie</param>
      /// <param name="userData">Extra options</param>
      /// <returns>AuthenticationInfo</returns>
      /// <remarks>
      /// Copy same extra options in the return value .ExtraOption property in default implementation
      /// </remarks>
      AuthenticationInfo GetAuthenticationInfo(string authenticationCookie, string userData);
      AuthenticationInfo TempAuthenticate(string adminCookie, string impersonatedUser, string role);
      List<string> ListExpiredTempUsers();

      /// <summary>
      /// Checks if the cookie is timed out
      /// </summary>
      /// <param name="ai">Authentication Info</param>
      /// <param name="userData">Extra options</param>
      /// <returns>true/false</returns>
      /// <remarks>
      /// If timed out, the app needs to call AuthenticateUser again
      /// </remarks>
      bool IsTimedOut(AuthenticationInfo ai, string userData);

      /// <summary>
      /// validates the cookie for being authorized and against the passed permission
      /// throws an exception if not valid for any reason
      /// </summary>
      /// <param name="authenticationCookie">Cookie</param>
      /// <param name="permission">permission name, pass empty string for validating cookie only</param>
      AuthenticationInfo ValidatePermission(string authenticationCookie, string permission);

      /// <summary>
      /// validates the cookie for authentication
      /// </summary>
      /// <param name="authenticationCookie">cookie</param>
      /// <returns></returns>
      AuthenticationInfo IsAuthenticated(string authenticationCookie);

      void CreateUser(string authenticationCookie, string userName, string password, string userType, DateTime? expires);
      void DeleteUser(string authenticationCookie, string userName, string userData);
      dynamic GetAllUsers(string authenticationCookie);      
      bool ResetPassword(string authenticationCookie, string userName, string newPassword, string userData);
      bool ChangePassword(string authenticationCookie, string userName, string oldPassword, string newPassword, string userData);

      /// <summary>
      /// Checks if permission is available for a user
      /// </summary>
      /// <param name="username">user name</param>
      /// <param name="permission">permission name</param>
      /// <param name="userData">Extra options</param>
      /// <returns></returns>
      bool HasPermission(string username, string permission, string userData);

      /// <summary>
      /// returns user's permissions
      /// </summary>
      /// <param name="username">user name</param>
      /// <param name="userData">Extra options</param>
      /// <returns>array of permissions names</returns>
      string[] GetUserPermissions(string username, string userData);

      /// <summary>
      /// returns user's roles
      /// </summary>
      /// <param name="username">user name</param>
      /// <param name="userData">Extra options</param>
      /// <returns>array of roles names</returns>
      string[] GetUserRoles(string username, string userData);

      Permission[] GetPermissions();

      Role[] GetRoles();
      Role GetRole(string roleName);
      string[] GetRolesNames();
      void CreateRole(string authenticationCookie, Role role);
      void UpdateRolePermissions(string authenticationCookie, Role role);
      void DeleteRole(string authenticationCookie, string roleName);

      /// <summary>
      /// adds permission
      /// </summary>
      /// <param name="authenticationCookie">Authentication Info</param>
      /// <param name="username">user name</param>
      /// <param name="permission">permission name</param>
      /// <param name="userData">extra options</param>
      void GrantPermission(string authenticationCookie, string username, string permission, string userData);

      /// <summary>
      /// removes permission
      /// </summary>
      /// <param name="authenticationCookie">Authentication Info</param>
      /// <param name="username">user name</param>
      /// <param name="permission">permission name</param>
      /// <param name="userData">extra options</param>
      void DenyPermission(string authenticationCookie, string username, string permission, string userData);

      /// <summary>
      /// adds role
      /// </summary>
      /// <param name="authenticationCookie">Authentication Info</param>
      /// <param name="username">user name</param>
      /// <param name="role">role name</param>
      /// <param name="userData">extra options</param>
      void GrantRole(string authenticationCookie, string username, string role, string userData);

      /// <summary>
      /// removes role
      /// </summary>
      /// <param name="authenticationCookie">Authentication Info</param>
      /// <param name="username">user name</param>
      /// <param name="role">role name</param>
      /// <param name="userData">extra options</param>
      void DenyRole(string authenticationCookie, string username, string role, string userData);
      bool IsAdmin(string authenticationCookie, string userName, string userData);
      string ValidatePassword(string password, string userData);
      bool IsPasswordExpired(string userName);
      string CreateUserExt(string username, string password, string adminUsername, string adminPassword, bool isAdmin, string[] permissions, string[] roles, CreateUserOptions options, string userData);
   }
}
