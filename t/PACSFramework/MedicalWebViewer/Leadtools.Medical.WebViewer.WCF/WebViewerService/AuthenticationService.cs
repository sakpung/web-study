// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using Leadtools.Medical.WebViewer.DataContracts;
using System.ServiceModel.Web;
using Leadtools.Medical.WebViewer.ServiceContracts;
using Leadtools.Medical.WebViewer.Addins;
using Leadtools.Dicom;
using System.ServiceModel.Activation;
using System.IO;
using Leadtools.Medical.WebViewer.Wcf.Helper;
using System.Diagnostics;

namespace Leadtools.Medical.WebViewer.Wcf
{

   sealed class ErrorStrings
   {

      private ErrorStrings()
      {
      }


      public const string AdminUsernamePasswordInvalid = "adminUsername/adminPassword combination is not valid.";
      public const string UserDoesNotExist = "User '{0}' does not exist.";
      public const string UserAlreadyExists = "User '{0}' already exists.";
      public const string InvalidParameter = "Invalid Parameter: '{0}' {1}.";
      public const string Success = "Success";
   }

   /// <summary>
   /// Used for user authentication and authorization (permissions), also create, update and return users and roles.
   /// 
   /// </summary>
   [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
   public class AuthenticationService : IAuthenticationService
   {
      IAuthenticationAddin _addin;

      public AuthenticationService()
      {
         _addin = AddinsFactory.CreateAuthenticationAddin();
      }

      public WcfPingResponse Ping()
      {
         var response = new WcfPingResponse();
         response.message = "Ready";
         response.time = DateTime.Now.ToString();

         try
         {
            response.isLicenseChecked = true;
            response.isLicenseExpired = RasterSupport.KernelExpired;
            response.kernelType = RasterSupport.KernelType.ToString();
         }
         catch (Exception)
         {
            response.isLicenseChecked = false;
            response.isLicenseExpired = true;
            response.kernelType = null;
         }

         return response;
      }

      public Stream AuthenticateUser(string userName, string password, string userData)
      {
         try
         {
            string authentication = _addin.AuthenticateUser(userName, password, userData);
            if (null != WebOperationContext.Current)
               WebOperationContext.Current.OutgoingResponse.ContentType = "text/plain";
            if (!string.IsNullOrEmpty(authentication))
            {
               return new MemoryStream(ASCIIEncoding.Default.GetBytes(authentication));
            }
         }
         catch (Exception ex)
         {
            ServiceUtils.Log(ex.Message);
            WebOperationContext.Current.OutgoingResponse.ContentType = "application/json";

            if (ex != null && !string.IsNullOrWhiteSpace(ex.Message))
            {
               string errorMessage = ex.Message;
               errorMessage = errorMessage.Replace("\r\n", " ");
               WebOperationContext.Current.OutgoingResponse.StatusDescription = errorMessage; //  "Yellow Error"; // ex.Message;
            }

            throw new WebFaultException(System.Net.HttpStatusCode.Unused);
         }

         ServiceUtils.Log("Invalid User Name or Password");
         throw new ServiceAuthenticationException("Invalid User Name or Password");
      }

      public AuthenticationInfo GetAuthenticationInfo(string authenticationCookie, string userData)
      {
         return _addin.GetAuthenticationInfo(authenticationCookie, userData);
      }

      public bool IsTimedOut(AuthenticationInfo ai, string userData)
      {
         return _addin.IsTimedOut(ai, userData);
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

      public void CreateUser(string authenticationCookie, string userName, string password, string userType)
      {
         string authUserName;
         ServiceUtils.Authenticate(_addin, authenticationCookie, out authUserName, null);
         ServiceUtils.Authorize(_addin, authUserName, PermissionsTable.Instance.CanManageUsers, null);

         _addin.CreateUser(authUserName, userName, password, userType, null);
      }

      public void DeleteUser(string authenticationCookie, string userName, string userData)
      {
         string authUserName;
         ServiceUtils.Authenticate(_addin, authenticationCookie, out authUserName, null);
         ServiceUtils.Authorize(_addin, authUserName, PermissionsTable.Instance.CanManageUsers, null);

         _addin.DeleteUser(authUserName, userName, userData);
      }

      public string[] GetAllUsers(string authenticationCookie, string userData)
      {
         string authUserName;
         ServiceUtils.Authenticate(_addin, authenticationCookie, out authUserName, null);
         ServiceUtils.Authorize(_addin, authUserName, PermissionsTable.Instance.CanManageUsers, null);

         return _addin.GetAllUsers(userData);
      }

      public bool ResetPassword(string authenticationCookie, string userName, string newPassword, string userData)
      {
         string authUserName;

         ServiceUtils.Authenticate(_addin, authenticationCookie, out authUserName, null);

         if (string.Compare(authUserName, userName, true) == 0 ||
              _addin.HasPermission(authUserName, PermissionsTable.Instance.CanManageUsers.Name, userData))
         {
            return _addin.ResetPassword(userName, newPassword, userData);
         }
         else
         {
            //this should throw authorization exception
            ServiceUtils.Authorize(_addin, authUserName, PermissionsTable.Instance.CanManageUsers, null);

            return false;
         }
      }

      public bool ChangePassword(string authenticationCookie, string userName, string oldPassword, string newPassword, string userData)
      {
         string authUserName;

         ServiceUtils.Authenticate(_addin, authenticationCookie, out authUserName, null);

         if (string.IsNullOrEmpty(userName) || (string.Compare(authUserName, userName, true) == 0))
         {
            return _addin.ChangePassword(authUserName, oldPassword, newPassword, userData);
         }
         else
         {
            ServiceUtils.Authorize(_addin, authUserName, PermissionsTable.Instance.CanManageUsers, null);
            return _addin.ChangePassword(userName, oldPassword, newPassword, userData);
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

         return _addin.HasPermission(username, permission, userData);
      }

      public string[] GetUserPermissions(string username, string userData)
      {
         Permission[] permissions = _addin.GetUserPermissions(username);

         return (from p in permissions
                 select p.Name).ToArray();
      }

      public void GrantPermission(string authenticationCookie, string username, string permission, string userData)
      {
         string authUser;

         ServiceUtils.Authenticate(_addin, authenticationCookie, out authUser, null);
         ValidatePermission(authenticationCookie, PermissionsTable.Instance.CanManageUsers.Name);

         _addin.GrantPermission(authUser, username, permission, userData);
      }

      public void DenyPermission(string authenticationCookie, string username, string permission, string userData)
      {
         string authUser;

         ServiceUtils.Authenticate(_addin, authenticationCookie, out authUser, null);
         ValidatePermission(authenticationCookie, PermissionsTable.Instance.CanManageUsers.Name);

         _addin.DenyPermission(authUser, username, permission, userData);
      }

      public bool IsAdmin(string authenticationCookie, string userName, string userData)
      {
         string authUser;
         ServiceUtils.Authenticate(_addin, authenticationCookie, out authUser, null);

         return _addin.IsAdmin(userName, userData);
      }

      #region IAuthenticationService Members


      public string[] GetUserRoles(string username, string userData)
      {
         return _addin.GetUserRolesNames(username);
      }

      public void GrantRole(string authenticationCookie, string username, string role, string userData)
      {
         ValidatePermission(authenticationCookie, PermissionsTable.Instance.CanManageUsers.Name);

         _addin.GrantRole(username, role, userData);
      }

      public void DenyRole(string authenticationCookie, string username, string role, string userData)
      {
         ValidatePermission(authenticationCookie, PermissionsTable.Instance.CanManageUsers.Name);

         _addin.DenyRole(username, role, userData);
      }

      public Permission[] GetPermissions()
      {
         return _addin.GetPermissions();
      }

      public Role[] GetRoles()
      {
         return _addin.GetRoles();
      }

      public Role GetRole(string roleName)
      {
         return _addin.GetRole(roleName);
      }

      public string[] GetRolesNames()
      {
         return _addin.GetRolesNames();
      }


      public void CreateRole(string authenticationCookie, Role role)
      {
         string authUser;

         ServiceUtils.Authenticate(_addin, authenticationCookie, out authUser, null);
         ValidatePermission(authenticationCookie, PermissionsTable.Instance.CanManageRoles.Name);
         _addin.CreateRole(authUser, role);
      }
      public void UpdateRolePermissions(string authenticationCookie, Role role)
      {
         string authUser;

         ServiceUtils.Authenticate(_addin, authenticationCookie, out authUser, null);
         ValidatePermission(authenticationCookie, PermissionsTable.Instance.CanManageRoles.Name);
         _addin.UpdateRolePermissions(authUser, role);
      }
      public void DeleteRole(string authenticationCookie, string roleName)
      {
         string authUser;

         ServiceUtils.Authenticate(_addin, authenticationCookie, out authUser, null);
         ValidatePermission(authenticationCookie, PermissionsTable.Instance.CanManageRoles.Name);
         _addin.DeleteRole(authUser, roleName);
      }

      public string ValidatePassword(string password, string userData)
      {
         return _addin.ValidatePassword(password, userData);
      }

      public bool IsPasswordExpired(string userName)
      {
         return _addin.IsPasswordExpired(userName);
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
            FailureMessage = string.Format(ErrorStrings.InvalidParameter, "username", ": cannot be empty");
            return FailureMessage;
         }

         List<string> permissionsList = new List<string>(permissions);


         if (!permissions.Contains(_adminPermissionName))
         {
            if (isAdmin || roles.Contains(_adminRoleName))
            {
               permissionsList.Add(_adminPermissionName);
            }
         }


         //// If only logging in (not updating or creating), then call UserLogin
         //if (options == CreateUserOptions.Login)
         //{
         //   return UserLogin(username, password);
         //}

         //try
         //{
         //   AssertStarted();
         //}
         //catch
         //{
         //   return ControllerReturnCode.NotProperlyInitiated;
         //}
         //AuthenticationServiceProxy authenticationService = new AuthenticationServiceProxy(_webViewerDomain + MedicalWebViewerServices.AuthenticationService);

         // Verify that adminUsername and adminPassword are valid

         string authenticationToken = string.Empty;
         try
         {
            authenticationToken = _addin.AuthenticateUser(adminUsername, adminPassword, string.Empty);
         }
         finally
         {
         }

         if (string.IsNullOrEmpty(authenticationToken))
         {
            FailureMessage = ErrorStrings.AdminUsernamePasswordInvalid;
            return FailureMessage;
         }

         string[] userList = new string[] { };
         if (IsFlagged(options, CreateUserOptions.CreateUser) || IsFlagged(options, CreateUserOptions.UpdateUser))
         {
            userList = _addin.GetAllUsers(userData);
         }

         bool userExists = userList.Contains(username);
         bool passwordUpdated = false;


         // 
         if (IsFlagged(options, CreateUserOptions.CreateUser))
         {
            if (!userExists)
            {
               CreateUser(authenticationToken, username, password, userData);
               passwordUpdated = true;
               userExists = true;
            }
            else
            {
               // user already exists
               if (!IsFlagged(options, CreateUserOptions.UpdateUser))
               {
                  FailureMessage = string.Format(ErrorStrings.UserAlreadyExists, username);
                  return FailureMessage;
               }
            }
         }

         if (IsFlagged(options, CreateUserOptions.CreateUser | CreateUserOptions.UpdateUser | CreateUserOptions.UpdateRoles | CreateUserOptions.UpdatePermissions | CreateUserOptions.UpdatePassword))
         {
            if (userExists == false)
            {
               FailureMessage = string.Format(ErrorStrings.UserDoesNotExist, username);
               return FailureMessage;
            }
         }

         if (IsFlagged(options, CreateUserOptions.CreateUser | CreateUserOptions.UpdatePassword))
         {
            if (passwordUpdated == false)
            {
               _addin.ResetPassword(username, password, userData);
            }
         }

         if (IsFlagged(options, CreateUserOptions.CreateUser | CreateUserOptions.UpdatePermissions))
         {
            // Delete the 'admin' permission initially
            _addin.DenyPermission(adminUsername, username, _adminPermissionName, string.Empty);


            // Deny existing permissions that are not in the permissions list
            string[] currentPermissions = GetUserPermissions(username, string.Empty);
            foreach (string currentPermission in currentPermissions)
            {
               if (false == permissions.Contains(currentPermission))
               {
                  _addin.DenyPermission(adminUsername, username, currentPermission, string.Empty);
               }
            }

            // Add all permissions in the permission list
            foreach (string permission in permissionsList)
            {
               _addin.GrantPermission(adminUsername, username, permission, userData);
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
                  _addin.DenyRole(username, currentRole, string.Empty);
               }
            }

            // Add all roles in role list
            foreach (string role in roles)
            {
               _addin.GrantRole(username, role, userData);
            }
         }


         //// After creating/updating the user, now login if necessary
         //if (IsFlagged(options, CreateUserOptions.Login))
         //{
         //   return UserLogin(username, password);
         //}

         return ErrorStrings.Success;
      }

      #endregion

   }
}
