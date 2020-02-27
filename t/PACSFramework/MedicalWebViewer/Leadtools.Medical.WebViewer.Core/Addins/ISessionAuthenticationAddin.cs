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
   public interface ISessionAuthenticationAddin
   {
      /// <summary>
      /// Returns the info for the authentication cookie such as user name, expiration time and any extra options
      /// </summary>
      /// <param name="authenticationCookie">Cookie</param>
      /// <param name="extraOptions">Extra options</param>
      /// <returns>User name</returns>
      /// <remarks>
      /// Copy same extra options in the return value .ExtraOption property in default implementation
      /// </remarks>
      AuthenticationInfo GetAuthenticationInfo(string authenticationCookie);

      /// <summary>
      /// Checks if the cookie is timed out
      /// </summary>
      /// <param name="AuthenticationInfo">Authentication Info structure</param>
      /// <param name="extraOptions">Extra options</param>
      /// <returns>true/false</returns>
      /// <remarks>
      /// If timed out, the app needs to call AuthenticateUser again
      /// </remarks>
      bool IsTimedOut(AuthenticationInfo ai);

      /// <summary>
      /// Checks if permission is available for a user
      /// </summary>
      /// <param name="username">user name</param>
      /// <param name="permission">permission name</param>
      /// <param name="extraOptions">Extra options</param>
      /// <returns></returns>
      bool HasPermission(AuthenticationInfo ai, string permission);
      bool HasPermission(AuthenticationInfo ai, Permission permission);
   }
}
