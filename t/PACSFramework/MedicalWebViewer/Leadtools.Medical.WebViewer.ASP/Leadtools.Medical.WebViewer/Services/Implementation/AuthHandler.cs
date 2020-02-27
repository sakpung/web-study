// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Linq;
using Leadtools.Medical.WebViewer.Services.Interfaces;
using Leadtools.Medical.WebViewer.ServiceContracts;
using Leadtools.Medical.WebViewer.DataContracts;
using Leadtools.Medical.WebViewer.Errors;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Text;
using Newtonsoft.Json.Linq;
using System.Security.Cryptography;
using System.IO;
using System.Configuration;

namespace Leadtools.Medical.WebViewer.Services.Implementation
{
   public class AuthHandler : IAuthHandler, IDisposable
   {
      private IAuthenticationAddin _auth;

      public AuthHandler(AddinsFactory factory)
      {
         _auth = factory.CreateAuthenticationAddin();
      }

      private bool _disposed = false;
      ~AuthHandler()
      {
         if (!this._disposed)
         {
            this._disposed = true;
            Dispose();
         }
      }

      public void Dispose()
      {
         if (!this._disposed)
         {
            this._disposed = true;

            //DicomEngine.Shutdown();

            GC.SuppressFinalize(this);
         }
      }
            
      public string AuthenticateUser(string userName, string password, string userData, TimeSpan? lifeTime, string impersonatedUser)
      {
         var cookie = "";
         if (lifeTime.HasValue)
         {
            cookie = _auth.AuthenticateUser(userName, password, userData, lifeTime.Value, impersonatedUser);
         }
         else
         {
            cookie = _auth.AuthenticateUser(userName, password, userData);
         }
         if (string.IsNullOrEmpty(cookie))
         {
            throw new Exception("Invalid User Name or Password");
         }
         return cookie;
      }

      /// <summary>
      /// Checks the authentication cookie and extract/returns the user name. If user is not authenticated it throws the appropriate exception
      /// </summary>
      /// <param name="authenticationService"></param>
      /// <param name="authenticationCookie"></param>
      /// <param name="userName"></param>
      /// <param name="extraOptions"></param>
      internal static void Authenticate(IAuthenticationAddin authenticationService, string authenticationCookie, out string userName, ExtraOptions extraOptions)
      {
         
         AuthenticationInfo info = null;

         try
         {
            info = authenticationService.GetAuthenticationInfo(authenticationCookie, null);
         }
         catch (Exception ex)
         {
            throw new ServiceAuthenticationException(ex.Message);
         }

         userName = "";

         if (null != info)
         {
            userName = info.UserName;

            if (authenticationService.IsTimedOut(info, null))
            {
               throw new ServiceAuthenticationException("Timed-out");
            }
         }
         else
         {
            throw new ServiceAuthenticationException("Not Authenticated");
         }

      }
      internal static string Authenticate(string authenticationCookie, bool impersonater = false)
      {
         
         AuthenticationInfo ai = null;
         var srv = AddinsFactory.CreateSessionAuthenticationAddin();

         try
         {
            ai = srv.GetAuthenticationInfo(authenticationCookie);
         }
         catch (Exception ex)
         {
            throw new ServiceAuthenticationException(ex.Message);
         }

         if (srv.IsTimedOut(ai))
         {
            throw new ServiceAuthenticationException("Timed-out");
         }

         if (impersonater && !string.IsNullOrEmpty(ai.ImpersonatedUserName))
         {
            return ai.ImpersonatedUserName;
         }
         else
         {
            return ai.UserName;
         }
      }

      /// <summary>
      /// Checks if the user has permission to perform an operation and throws exception if not.
      /// </summary>
      /// <param name="authenticationService"></param>
      /// <param name="userName"></param>
      /// <param name="permission"></param>
      /// <param name="extraOptions"></param>
      private static void Authorize(IAuthenticationAddin authenticationService, string userName, Permission permission, ExtraOptions extraOptions)
      {
         
         if (!authenticationService.HasPermission(userName, permission.Name, null))
         {
            throw new ServiceAuthorizationException("Not enough permissions.");
         }
      }
      internal static string Authorize(string authenticationCookie, Permission permission)
      {
         
         AuthenticationInfo ai = null;
         var srv = AddinsFactory.CreateSessionAuthenticationAddin();

         try
         {
            ai = srv.GetAuthenticationInfo(authenticationCookie);
         }
         catch (Exception ex)
         {
            throw new ServiceAuthenticationException(ex.Message);
         }

         if (srv.IsTimedOut(ai))
         {
            throw new ServiceAuthenticationException("Timed-out");
         }

         if (!srv.HasPermission(ai, permission))
         {
            throw new ServiceAuthenticationException("Not Authenticated");
         }

         //passed
         return ai.UserName;
      }
      public AuthenticationInfo GetAuthenticationInfo(string authenticationCookie, string userData)
      {
         return _auth.GetAuthenticationInfo(authenticationCookie, userData);
      }
      
      public static UInt64 GetUInt64HashCode()
      {
         var guid = Guid.NewGuid().ToString().Replace("-", "");
         byte[] buf = Encoding.ASCII.GetBytes(guid);
         var hashCodeStart = BitConverter.ToUInt64(buf, 0);
         var hashCodeMedium = BitConverter.ToUInt64(buf, 8);
         var hashCodeEnd = BitConverter.ToUInt64(buf, 24);
         var hashCode = hashCodeStart ^ hashCodeMedium ^ hashCodeEnd;
         return (hashCode);
      }
      public static string NewUnique16BytesId()
      {
         return GetUInt64HashCode().ToString("X2");
      }
      
      private void DeleteExpiredUsers(string authCookie)
      {
         try
         {
            var users = ListExpiredTempUsers();

            foreach (var user in users)
            {
               DeleteUser(authCookie, user, null);
            }
         }
         catch { }
      }

      public List<string> ListExpiredTempUsers()
      {
         var expired = new List<string>();

         try
         {            
            var tempUsers = new Dictionary<string, string> { { "UserType", "temp" } };
            var users = _auth.GetAllUsers(tempUsers).Take(10);

            foreach (var user in users)
            {
               var userName = user.UserName as string;

               if (!string.IsNullOrEmpty(userName))
               {
                  if (user.Expires != null)
                  {
                     var expires = user.Expires as DateTime?;
                     if (expires.HasValue)
                     {
                        if (expires.Value < DateTime.UtcNow)
                        {
                           expired.Add(userName);
                        }
                     }
                  }
               }
            }
         }
         catch { }

         return expired;
      }

      public AuthenticationInfo TempAuthenticate(string adminCookie, string impersonatedUser, string role)
      {
         if (string.IsNullOrEmpty(adminCookie) )
         {
            throw new Exception("Admin authorization is required");
         }

         TimeSpan lifeTime;
         if (!TimeSpan.TryParse(ConfigurationManager.AppSettings.Get("UrlInterface.Timeout"), out lifeTime))
         {
            lifeTime = TimeSpan.FromMinutes(1);
         }

         //1 min minimum
         if (lifeTime < TimeSpan.FromMinutes(1))
            lifeTime = TimeSpan.FromMinutes(1);

         var tmpUser = NewUnique16BytesId();         
         CreateUser(adminCookie, tmpUser, tmpUser, "temp", DateTime.UtcNow + lifeTime);

         if (!string.IsNullOrEmpty(role))
         {
            GrantRole(adminCookie, tmpUser, role, null); //this should impersonate a certain role with access to patients and other rights
         }
         else
         {
            //if no role is specified, we add permissions
            //GrantPermission(adminCookie, tmpUser, PermissionsTable.Instance.CanAddTemplates.Name, null);
            GrantPermission(adminCookie, tmpUser, PermissionsTable.Instance.CanCalibrateMonitor.Name, null);
            //GrantPermission(adminCookie, tmpUser, PermissionsTable.Instance.CanDeleteAnnotations.Name, null);
            //GrantPermission(adminCookie, tmpUser, PermissionsTable.Instance.CanDeleteCache.Name, null);
            //GrantPermission(adminCookie, tmpUser, PermissionsTable.Instance.CanDeleteDownloadInfo.Name, null);
            //GrantPermission(adminCookie, tmpUser, PermissionsTable.Instance.CanDeleteImages.Name, null);
            //GrantPermission(adminCookie, tmpUser, PermissionsTable.Instance.CanDeleteTemplates.Name, null);
            GrantPermission(adminCookie, tmpUser, PermissionsTable.Instance.CanDownloadImages.Name, null);
            //GrantPermission(adminCookie, tmpUser, PermissionsTable.Instance.CanEditTemplates.Name, null);
            GrantPermission(adminCookie, tmpUser, PermissionsTable.Instance.CanExport.Name, null);
            GrantPermission(adminCookie, tmpUser, PermissionsTable.Instance.CanExportTemplates.Name, null);
            GrantPermission(adminCookie, tmpUser, PermissionsTable.Instance.CanImportTemplates.Name, null);
            //GrantPermission(adminCookie, tmpUser, PermissionsTable.Instance.CanManageAccessRight.Name, null);
            //GrantPermission(adminCookie, tmpUser, PermissionsTable.Instance.CanManageRemotePACS.Name, null);
            //GrantPermission(adminCookie, tmpUser, PermissionsTable.Instance.CanManageRoles.Name, null);
            //GrantPermission(adminCookie, tmpUser, PermissionsTable.Instance.CanManageUsers.Name, null);
            //GrantPermission(adminCookie, tmpUser, PermissionsTable.Instance.CanModifyBuiltInTemplates.Name, null);
            GrantPermission(adminCookie, tmpUser, PermissionsTable.Instance.CanQuery.Name, null);
            GrantPermission(adminCookie, tmpUser, PermissionsTable.Instance.CanQueryPACS.Name, null);
            GrantPermission(adminCookie, tmpUser, PermissionsTable.Instance.CanRetrieve.Name, null);
            GrantPermission(adminCookie, tmpUser, PermissionsTable.Instance.CanSaveHangingProtocol.Name, null);
            GrantPermission(adminCookie, tmpUser, PermissionsTable.Instance.CanSaveSeriesLayout.Name, null);
            GrantPermission(adminCookie, tmpUser, PermissionsTable.Instance.CanStore.Name, null);
            GrantPermission(adminCookie, tmpUser, PermissionsTable.Instance.CanStoreAnnotations.Name, null);
            GrantPermission(adminCookie, tmpUser, PermissionsTable.Instance.CanViewAnnotations.Name, null);
            GrantPermission(adminCookie, tmpUser, PermissionsTable.Instance.CanViewTemplates.Name, null);
         }

         var auth_user = tmpUser;
         var auth_pass = tmpUser;

         //cleanup
         DeleteExpiredUsers(adminCookie);

         //authenticate by user's credentials
         var auth_cookie = AuthenticateUser(auth_user, auth_pass, null, lifeTime, impersonatedUser);
         var ai = GetAuthenticationInfo(auth_cookie, "");
         ai.Cookie = auth_cookie;         
         return ai;
      }
      
      public bool IsTimedOut(AuthenticationInfo ai, string userData)
      {
         return _auth.IsTimedOut(ai, userData);
      }

      public AuthenticationInfo IsAuthenticated(string authenticationCookie)
      {
         AuthenticationInfo ai = GetAuthenticationInfo(authenticationCookie, null);

         if (IsTimedOut(ai, null))
         {
            throw new Exception("Cookie timed out");
         }

         return ai;
      }

      public AuthenticationInfo ValidatePermission(string authenticationCookie, string permission)
      {
         AuthenticationInfo ai = GetAuthenticationInfo(authenticationCookie, null);

         if (IsTimedOut(ai, null))
         {
            throw new Exception("Cookie timed out");
         }

         if (!HasPermission(ai.UserName, permission, null))
         {
            throw new Exception("User lacks permission");
         }

         return ai;
      }

      public void CreateUser(string authenticationCookie, string userName, string password, string userType, DateTime? expires)
      {
         string authUserName;
         Authenticate(_auth, authenticationCookie, out authUserName, null);
         Authorize(_auth, authUserName, PermissionsTable.Instance.CanManageUsers, null);

         _auth.CreateUser(authUserName, userName, password, userType, expires);
      }

      public void DeleteUser(string authenticationCookie, string userName, string userData)
      {
         string authUserName;
         Authenticate(_auth, authenticationCookie, out authUserName, null);
         Authorize(_auth, authUserName, PermissionsTable.Instance.CanManageUsers, null);

         _auth.DeleteUser(authUserName, userName, userData);
      }

      public dynamic GetAllUsers(string authenticationCookie)
      {
         string authUserName;
         Authenticate(_auth, authenticationCookie, out authUserName, null);
         Authorize(_auth, authUserName, PermissionsTable.Instance.CanManageUsers, null);

         return _auth.GetAllUsersFullInfo();
      }

      public bool ResetPassword(string authenticationCookie, string userName, string newPassword, string userData)
      {
         string authUserName;

         Authenticate(_auth, authenticationCookie, out authUserName, null);

         if (string.Compare(authUserName, userName, true) == 0 ||
              _auth.HasPermission(authUserName, PermissionsTable.Instance.CanManageUsers.Name, userData))
         {
            return _auth.ResetPassword(userName, newPassword, userData);
         }
         else
         {
            //this should throw authorization exception
            Authorize(_auth, authUserName, PermissionsTable.Instance.CanManageUsers, null);

            return false;
         }
      }

      public bool ChangePassword(string authenticationCookie, string userName, string oldPassword, string newPassword, string userData)
      {
         string authUserName;

         Authenticate(_auth, authenticationCookie, out authUserName, null);

         if( string.IsNullOrEmpty(userName) || (string.Compare(authUserName, userName, true) == 0) )
         {
            return _auth.ChangePassword(authUserName, oldPassword, newPassword, userData);
         }
         else 
         {
            Authorize(_auth, authUserName, PermissionsTable.Instance.CanManageUsers, null);
            return _auth.ChangePassword(userName, oldPassword, newPassword, userData);
         }
      }

      public AuthenticationInfo VerifyIsAuthorizedForRole(string authenticationCookie, string roleName)
      {
         return ValidatePermission(authenticationCookie, roleName);
      }

      public bool HasPermission(string username, string permission, string userData)
      {
         if (string.IsNullOrEmpty(permission))
            return false;

         return _auth.HasPermission(username, permission, userData);
      }

      public string[] GetUserPermissions(string username, string userData)
      {
         Permission[] permissions = _auth.GetUserPermissions(username);

         return (from p in permissions
                 select p.Name).ToArray();
      }

      public void GrantPermission(string authenticationCookie, string username, string permission, string userData)
      {
         string authUser;

         Authenticate(_auth, authenticationCookie, out authUser, null);
         ValidatePermission(authenticationCookie, PermissionsTable.Instance.CanManageUsers.Name);

         _auth.GrantPermission(authUser, username, permission, userData);
      }

      public void DenyPermission(string authenticationCookie, string username, string permission, string userData)
      {
         string authUser;

         Authenticate(_auth, authenticationCookie, out authUser, null);
         ValidatePermission(authenticationCookie, PermissionsTable.Instance.CanManageUsers.Name);

         _auth.DenyPermission(authUser, username, permission, userData);
      }

      public bool IsAdmin(string authenticationCookie, string userName, string userData)
      {
         string authUser;
         Authenticate(_auth, authenticationCookie, out authUser, null);

         return _auth.IsAdmin(userName, userData);
      }

      #region IAuthenticationService Members


      public string[] GetUserRoles(string username, string userData)
      {
         return _auth.GetUserRolesNames(username);
      }

      public void GrantRole(string authenticationCookie, string username, string role, string userData)
      {
         ValidatePermission(authenticationCookie, PermissionsTable.Instance.CanManageUsers.Name);

         _auth.GrantRole(username, role, userData);
      }

      public void DenyRole(string authenticationCookie, string username, string role, string userData)
      {
         ValidatePermission(authenticationCookie, PermissionsTable.Instance.CanManageUsers.Name);

         _auth.DenyRole(username, role, userData);
      }

      public Permission[] GetPermissions()
      {
         return _auth.GetPermissions();
      }

      public Role[] GetRoles()
      {
         return _auth.GetRoles();
      }

      public Role GetRole(string roleName)
      {
         return _auth.GetRole(roleName);
      }

      public string[] GetRolesNames()
      {
         return _auth.GetRolesNames();
      }


      public void CreateRole(string authenticationCookie, Role role)
      {
         string authUser;

         Authenticate(_auth, authenticationCookie, out authUser, null);
         ValidatePermission(authenticationCookie, PermissionsTable.Instance.CanManageRoles.Name);
         _auth.CreateRole(authUser, role);
      }
      public void UpdateRolePermissions(string authenticationCookie, Role role)
      {
         string authUser;

         Authenticate(_auth, authenticationCookie, out authUser, null);
         ValidatePermission(authenticationCookie, PermissionsTable.Instance.CanManageRoles.Name);
         _auth.UpdateRolePermissions(authUser, role);
      }
      public void DeleteRole(string authenticationCookie, string roleName)
      {
         string authUser;

         Authenticate(_auth, authenticationCookie, out authUser, null);
         ValidatePermission(authenticationCookie, PermissionsTable.Instance.CanManageRoles.Name);
         _auth.DeleteRole(authUser, roleName);
      }

      public string ValidatePassword(string password, string userData)
      {
         return _auth.ValidatePassword(password, userData);
      }

      public bool IsPasswordExpired(string userName)
      {
         return _auth.IsPasswordExpired(userName);
      }

      public static bool IsFlagged(CreateUserOptions options, CreateUserOptions option)
      {
         return ((options & option) != (CreateUserOptions.None));
      }

      private const string _adminRoleName = "Administrators";
      private const string _adminPermissionName = "Admin";

      public string CreateUserExt(
                                    string username,
                                    string password,
                                    string adminUsername,
                                    string adminPassword,
                                    bool isAdmin,
                                    string[] permissions,
                                    string[] roles,
                                    CreateUserOptions options,
                                    string userData
                                    )
      {
         string FailureMessage = string.Empty;
         username = username.Trim();
         password = password.Trim();

         if (string.IsNullOrEmpty(username))
         {
            return "Invalid Parameter: username cannot be empty.";
         }

         List<string> permissionsList = new List<string>(permissions);


         if (!permissions.Contains(_adminPermissionName))
         {
            if (isAdmin || roles.Contains(_adminRoleName))
            {
               permissionsList.Add(_adminPermissionName);
            }
         }

         string authenticationToken = string.Empty;
         try
         {
            authenticationToken = _auth.AuthenticateUser(adminUsername, adminPassword, string.Empty);
         }
         finally
         {
         }

         if (string.IsNullOrEmpty(authenticationToken))
         {
            return "adminUsername/adminPassword combination is not valid.";
         }

         string[] userList = new string[] { };
         if (IsFlagged(options, CreateUserOptions.CreateUser) || IsFlagged(options, CreateUserOptions.UpdateUser))
         {
            userList = _auth.GetAllUsers(userData);
         }

         bool userExists = userList.Contains(username);
         bool passwordUpdated = false;


         // 
         if (IsFlagged(options, CreateUserOptions.CreateUser))
         {
            if (!userExists)
            {
               CreateUser(authenticationToken, username, password, userData, null);
               passwordUpdated = true;
               userExists = true;
            }
            else
            {
               // user already exists
               if (!IsFlagged(options, CreateUserOptions.UpdateUser))
               {
                  FailureMessage = string.Format("User '{0}' already exists.", username);
                  return FailureMessage;
               }
            }
         }

         if (IsFlagged(options, CreateUserOptions.CreateUser | CreateUserOptions.UpdateUser | CreateUserOptions.UpdateRoles | CreateUserOptions.UpdatePermissions | CreateUserOptions.UpdatePassword))
         {
            if (userExists == false)
            {
               FailureMessage = string.Format("User '{0}' does not exist.", username);
               return FailureMessage;
            }
         }

         if (IsFlagged(options, CreateUserOptions.CreateUser | CreateUserOptions.UpdatePassword))
         {
            if (passwordUpdated == false)
            {
               _auth.ResetPassword(username, password, userData);
            }
         }

         if (IsFlagged(options, CreateUserOptions.CreateUser | CreateUserOptions.UpdatePermissions))
         {
            // Delete the 'admin' permission initially
            _auth.DenyPermission(adminUsername, username, _adminPermissionName, string.Empty);


            // Deny existing permissions that are not in the permissions list
            string[] currentPermissions = GetUserPermissions(username, string.Empty);
            foreach (string currentPermission in currentPermissions)
            {
               if (false == permissions.Contains(currentPermission))
               {
                  _auth.DenyPermission(adminUsername, username, currentPermission, string.Empty);
               }
            }

            // Add all permissions in the permission list
            foreach (string permission in permissionsList)
            {
               _auth.GrantPermission(adminUsername, username, permission, userData);
            }
         }

         if (IsFlagged(options, CreateUserOptions.CreateUser | CreateUserOptions.UpdateRoles))
         {
            // Deny any existing roles that are not in the role list
            string[] currentRoles = GetUserRoles(username, string.Empty);
            foreach (string currentRole in currentRoles)
            {
               if (false == roles.Contains(currentRole))
               {
                  _auth.DenyRole(username, currentRole, string.Empty);
               }
            }

            // Add all roles in role list
            foreach (string role in roles)
            {
               _auth.GrantRole(username, role, userData);
            }
         }

         return "Success";
      }

      #endregion
   }
}
