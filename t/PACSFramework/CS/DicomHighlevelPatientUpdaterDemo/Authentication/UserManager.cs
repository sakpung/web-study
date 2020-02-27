// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Medical.UserManagementDataAccessLayer;
using Leadtools.Medical.DataAccessLayer;
using Leadtools.Medical.UserManagementDataAccessLayer.Configuration;
using System.Data;
using System.Security;
using Leadtools.Medical.PermissionsManagement.DataAccessLayer;
using Leadtools.Medical.PermissionsManagement.DataAccessLayer.Configuration;
using Leadtools.Medical.OptionsDataAccessLayer;
using Leadtools.Medical.Winforms;
using Leadtools.Medical.OptionsDataAccessLayer.Configuration;
using Leadtools.DicomDemos;

namespace DicomDemo.Authentication
{
   public static class UserManager
   {
      private static ManagerUser _User;

      public static ManagerUser User
      {
         get
         {
            return _User;
         }
         set
         {
            _User = value;
         }
      }

      private static System.Configuration.Configuration _globalPacsConfiguration = DicomDemoSettingsManager.GetGlobalPacsConfiguration();

      public static System.Configuration.Configuration GlobalPacsConfiguration
      {
         get { return UserManager._globalPacsConfiguration; }
      }

      private static IUserManagementDataAccessAgent2 userAgent;
      private static IPermissionManagementDataAccessAgent2 permissionsAgent2;
      private static IOptionsDataAccessAgent optionsAgent;

      static UserManager()
      {
         userAgent = Program.GetUserAgent(GlobalPacsConfiguration);
         permissionsAgent2 = Program.GetPermissionsAgent(GlobalPacsConfiguration);
         optionsAgent = Program.GetOptionsAgent(GlobalPacsConfiguration);
      }
      
      public enum AuthenticateResult
      {
         Success = 0,
         InvalidUser = 1,
         ErrorInvalidDatabase = 2,
         ErrorUnknown = 3,
      }

      public static AuthenticateResult Authenticate(string username, SecureString password, out string errorString)
      {         
         errorString = string.Empty;
         bool userValid = false;
         AuthenticateResult result = AuthenticateResult.InvalidUser;
         
         try
         {
            userValid = userAgent.IsUserValid(username, password);
            result = userValid ? AuthenticateResult.Success : AuthenticateResult.InvalidUser;
         }
         catch (Exception ex)
         {
            errorString = ex.Message;
            if (ex.Message.Contains("Invalid object name 'Users'"))
               result = AuthenticateResult.ErrorInvalidDatabase;
            else
               result = AuthenticateResult.ErrorUnknown;
         }
         return result;
      }

      public static bool IsPasswordExpired(string userName)
      {
         return userAgent.IsUserPasswordExpired(userName);
      }           

      public static List<string> GetUserPermissions(string userName)
      {
         List<string> permissions = new List<string>();
         string[] roles = permissionsAgent2.GetUserRoles(userName);

         permissions.AddRange(permissionsAgent2.GetUserPermissions(userName));
         foreach (string role in roles)
         {
            List<string> rolePermissions = new List<string>(permissionsAgent2.GetRolePermissions(role));

            permissions = permissions.Union(rolePermissions).ToList();
         }
         return permissions;
      }

      public static void ResetPassword(string userName, SecureString password)
      {                  
         PasswordOptions options;
         DateTime? expires = null;
         
         options = optionsAgent.Get<PasswordOptions>(PasswordOptionsPresenter.PasswordOptions, new PasswordOptions());
         if (options.DaysToExpire > 0)
         {            
            expires = DateTime.Now.AddDays(options.DaysToExpire);
         }
         userAgent.SetUserPassword(userName, password, expires, options.MaxPasswordHistory);
      }

      public static bool ValidatePassword(string password, string confirmPassword, out string message)
      {         
         PasswordOptions options;         
         
         options = optionsAgent.Get<PasswordOptions>(PasswordOptionsPresenter.PasswordOptions, new PasswordOptions());
         if (!PasswordValidator.Validate(password, confirmPassword, options, out message))
         {
            return false;
         }
         else
            return true;
      }      

      public static bool IsPreviousPassword(string userName, SecureString password)
      {                  
         return userAgent.IsPreviousPassword(userName, password);       
      }
   }

   public class UserPermissions
   {
      public const string PatientUpdaterAdmin = "PatientUpdaterAdmin";
      public const string PatientUpdaterEdit = "PatientUpdaterEdit";
      public const string PatientUpdaterDelete = "PatientUpdaterDelete";
   }

   public class ManagerUser
   {
      public string Name { get; set; }

      public List<string> Permissions { get; set; }

      public ManagerUser(string userName, List<string> permissions)
      {
         Name = userName;
         Permissions = new List<string>();
         Permissions.AddRange(permissions);
      }

      public bool IsAdmin()
      {
         return Permissions.Contains(UserPermissions.PatientUpdaterAdmin);
      }

      public bool CanEdit()
      {
         return IsAdmin() || Permissions.Contains(UserPermissions.PatientUpdaterEdit);
      }

      public bool CanDelete()
      {
         return IsAdmin() || Permissions.Contains(UserPermissions.PatientUpdaterDelete);
      }
   }
}
