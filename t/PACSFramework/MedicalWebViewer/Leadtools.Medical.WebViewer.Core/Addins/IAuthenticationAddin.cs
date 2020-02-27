// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Text;

using Leadtools.Medical.WebViewer.DataContracts;

namespace Leadtools.Medical.WebViewer.ServiceContracts
{
   /// <summary>
   /// The interface for the authentication Add-in created by the WCF service
   /// </summary>
   public interface IAuthenticationAddin
   {
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
      string AuthenticateUser(string userName, string password, string userData);
      string AuthenticateUser(string userName, string password, string userData, TimeSpan lifeTime, string impersonatedUser);

      /// <summary>
      /// Returns the info for the authentication cookie such as user name, expiration time and any extra options
      /// </summary>
      /// <param name="authenticationCookie">Cookie</param>
      /// <param name="extraOptions">Extra options</param>
      /// <returns>User name</returns>
      /// <remarks>
      /// Copy same extra options in the return value .ExtraOption property in default implementation
      /// </remarks>
      AuthenticationInfo GetAuthenticationInfo(string authenticationCookie, string userData);

      /// <summary>
      /// Checks if the cookie is timed out
      /// </summary>
      /// <param name="AuthenticationInfo">Authentication Info structure</param>
      /// <param name="extraOptions">Extra options</param>
      /// <returns>true/false</returns>
      /// <remarks>
      /// If timed out, the app needs to call AuthenticateUser again
      /// </remarks>
      bool IsTimedOut(AuthenticationInfo ai, string userData);

      /// <summary>
      /// Checks if permission is available for a user
      /// </summary>
      /// <param name="username">user name</param>
      /// <param name="permission">permission name</param>
      /// <param name="extraOptions">Extra options</param>
      /// <returns></returns>
      bool HasPermission(string username, string permission, string userData);

      /// <summary>
      /// Checks if permission is available for a user
      /// </summary>
      /// <param name="username">user name</param>
      /// <param name="extraOptions">Extra options</param>
      /// <returns>array of permissions</returns>
      Permission[] GetUserPermissions(string username);
      string[] GetUserPermissionsNames(string username);

      Permission[] GetUserAssignedPermissions(string username);
      string[] GetUserAssignedPermissionsNames(string username);
      
      Role[] GetUserRoles(string username);
      string[] GetUserRolesNames(string username);

      void GrantPermission(string authUser, string username, string permission, string userData);
      void DenyPermission(string authUser, string username, string permission, string userData);

      void GrantRole(string username, string role, string userData);
      void DenyRole(string username, string role, string userData);
      Role[] GetRoles();
      string[] GetRolesNames();
      Role GetRole(string roleName);

      void CreateRole(string authUser, Role role);
      void UpdateRolePermissions(string authUser, Role role);
      void DeleteRole(string authUser, string roleName);

      void CreateUser(string authUser, string userName, string password, string userType, DateTime? expires);
      
      void DeleteUser(string authUser, string userName, string userData);
      
      string[] GetAllUsers( string userData);
      dynamic[] GetAllUsersFullInfo();
      dynamic[] GetAllUsers(Dictionary<string, string> query);

      bool ResetPassword( string userName, string newPassword, string userData);

      bool ChangePassword( string userName, string oldPassword, string newPassword, string userData);
      
      bool IsAdmin ( string userName, string userData ) ;

      string ValidatePassword(string password, string userData);

      bool IsPasswordExpired(string userName);

      Permission[] GetPermissions();
   }
}
