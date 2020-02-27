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
using Leadtools.Medical.OptionsDataAccessLayer;
using Leadtools.Medical.OptionsDataAccessLayer.Configuration;
using Leadtools.Medical.PermissionsManagement.DataAccessLayer;
using Leadtools.Medical.PermissionsManagement.DataAccessLayer.Configuration;
using Leadtools.Medical.Winforms;
using Leadtools.DicomDemos;
using Leadtools.Demos.StorageServer.DataTypes;
using Leadtools.Medical.DataAccessLayer.Configuration;
using Leadtools.Medical.UserManagementDataAccessLayer.DataAccessAgent.Database;
using System.Configuration;

namespace Leadtools.Demos.StorageServer.UI.AdministrativeSettings.Users
{
   public static class UserManager
   {
      private static ManagerUser _User;

      private static System.Configuration.Configuration _globalPacsConfiguration = DicomDemoSettingsManager.GetGlobalPacsConfiguration();

      public static System.Configuration.Configuration GlobalPacsConfiguration
      {
         get { return UserManager._globalPacsConfiguration; }
      }

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

#if LEADTOOLS_V19_OR_LATER
      private static IUserManagementDataAccessAgent4 userAgent;
#else
      private static IUserManagementDataAccessAgent2 userAgent;
#endif
      private static IPermissionManagementDataAccessAgent permissionsAgent;
      private static IPermissionManagementDataAccessAgent2 permissionsAgent2;
      private static IOptionsDataAccessAgent optionsAgent;

      static UserManager()
      {
#if LEADTOOLS_V19_OR_LATER
         userAgent = GetDataAccess<IUserManagementDataAccessAgent4>(new UserManagementDataAccessConfigurationView2(GlobalPacsConfiguration, DicomDemoSettingsManager.ProductNameStorageServer, null));
#else
         userAgent = GetDataAccess<IUserManagementDataAccessAgent2>(new UserManagementDataAccessConfigurationView2(GlobalPacsConfiguration, DicomDemoSettingsManager.ProductNameStorageServer, null));
#endif
         permissionsAgent = GetDataAccess<IPermissionManagementDataAccessAgent>(new PermissionManagementDataAccessConfigurationView(GlobalPacsConfiguration, DicomDemoSettingsManager.ProductNameStorageServer, null));
         optionsAgent = GetDataAccess<IOptionsDataAccessAgent>(new OptionsDataAccessConfigurationView(GlobalPacsConfiguration, DicomDemoSettingsManager.ProductNameStorageServer, null));
         permissionsAgent2 = GetDataAccess<IPermissionManagementDataAccessAgent2>(new PermissionManagementDataAccessConfigurationView(GlobalPacsConfiguration, DicomDemoSettingsManager.ProductNameStorageServer, null));
      }

      private static T GetDataAccess<T>(DataAccessConfigurationView configView)
      {
         T service;

         if (!DataAccessServices.IsDataAccessServiceRegistered<T>())
         {
            service = DataAccessFactory.GetInstance(configView).CreateDataAccessAgent<T>();
            DataAccessServices.RegisterDataAccessService<T>(service);
         }
         else
            service = DataAccessServices.GetDataAccessService<T>();
         return service;
      }

      public static bool Authenticate(string username, SecureString password)
      {                  
         return userAgent.IsUserValid(username, password);
      }

      public static bool IsPasswordExpired(string userName)
      {         
         return userAgent.IsUserPasswordExpired(userName);
      }

      public static UsersSource LoadUsers(bool cardUsers)
      {                  
         IEnumerable<User> users;
         UsersSource usersDataSet;

#if LEADTOOLS_V19_OR_LATER
         users = userAgent.GetUsers(cardUsers);
#else
            users = userAgent.GetUsers();
#endif
         usersDataSet = new UsersSource();


         foreach (User userData in users)
         {
            UsersSource.UsersRow user;
            string[] permissions = permissionsAgent.GetUserPermissions(userData.UserName);

            user = usersDataSet.Users.NewUsersRow();
            user.UserName = userData.UserName;
            user.IsAdmin = userData.IsAdmin;
            if (userData.Expires.HasValue)
               user.Expires = userData.Expires.Value;
#if LEADTOOLS_V19_OR_LATER
            user.UseCardReader = userData.UseCardReader;
            user.FriendlyName = userData.FriendlyName;
#endif
            usersDataSet.Users.AddUsersRow(user);

            foreach (string permission in permissions)
            {
               UsersSource.UserPermissionsRow p;

               p = usersDataSet.UserPermissions.NewUserPermissionsRow();
               p.UserName = userData.UserName;
               p.Permission = permission;
               usersDataSet.UserPermissions.AddUserPermissionsRow(p);
            }
         }

         usersDataSet.AcceptChanges();

         return usersDataSet;
      }

      public static UsersSource LoadUsersCardReader()
      {                  
         IEnumerable<User> users;
         UsersSource usersDataSet;
                  
         users = userAgent.GetUsers();
         usersDataSet = new UsersSource();


         foreach (User userData in users)
         {
            UsersSource.UsersRow user;
            string[] permissions = permissionsAgent.GetUserPermissions(userData.UserName);

            user = usersDataSet.Users.NewUsersRow();
            user.UserName = userData.UserName;
            user.IsAdmin = userData.IsAdmin;
            if (userData.Expires.HasValue)
               user.Expires = userData.Expires.Value;
#if LEADTOOLS_V19_OR_LATER
            user.UseCardReader = userData.UseCardReader;
            user.FriendlyName = userData.FriendlyName;
#endif
            usersDataSet.Users.AddUsersRow(user);

            foreach (string permission in permissions)
            {
               UsersSource.UserPermissionsRow p;

               p = usersDataSet.UserPermissions.NewUserPermissionsRow();
               p.UserName = userData.UserName;
               p.Permission = permission;
               usersDataSet.UserPermissions.AddUserPermissionsRow(p);
            }
         }

         usersDataSet.AcceptChanges();

         return usersDataSet;
      }

      private static bool IsDeleteAllUsers(User[] currentUsers, UsersSource usersDataSet)
      {
         if ((currentUsers == null) || (usersDataSet == null))
            return false;

         bool isDeleteAllUsers = false;
         int deleteCount = 0;
         foreach (UsersSource.UsersRow user in usersDataSet.Users)
         {
            if (user.RowState == DataRowState.Deleted)
            {
               deleteCount++;
            }
         }

         isDeleteAllUsers = (currentUsers.Length == deleteCount);
         return isDeleteAllUsers;
      }

      private const string ForceDeleteAllUsers = "ForceDeleteAllUsers";

      public static bool IsForceDeleteAllUsers()
      {
         string s = ConfigurationManager.AppSettings[ForceDeleteAllUsers];
         bool b = false;

         if (string.IsNullOrEmpty(s))
            return false;

         if (!bool.TryParse(s, out b))
            return false;

         return b;
      }

      public static void UpdateUsers(UsersSource users)
      {         
         UsersSource usersDataSet;
         PasswordOptions options = optionsAgent.Get<PasswordOptions>(PasswordOptionsPresenter.PasswordOptions,new PasswordOptions());

         User[] currentUsers = userAgent.GetUsers();

         // int xxx = 100;
         // if (xxx != 100)
         // {
         //   users.Dispose();
         //   GC.Collect();
         //   GC.WaitForPendingFinalizers();
         // }

         bool forceDeleteAllUsers = IsForceDeleteAllUsers();
         if (forceDeleteAllUsers)
         {
            var rowsToDelete = new List<DataRow>();
            foreach (DataRow row in users.Users.Rows)
            {
               rowsToDelete.Add(row);
            }

            foreach (DataRow row in rowsToDelete)
            {
               // users.Users.Rows.Remove(row);
               row.Delete();
            }

         }

         usersDataSet = (UsersSource)users.GetChanges();

         if (null == usersDataSet)
         {
            return;
         }

         if (IsDeleteAllUsers(currentUsers, usersDataSet))
         {
            users.RejectChanges();
            Shell.LogAudit(string.Format("Rejected: Delete All Users"));
            // System.Windows.Forms.MessageBox.Show("Rejected: Delete All Users");
            return;
         }

         int i = 0;

         foreach (UsersSource.UsersRow user in usersDataSet.Users)
         {
            if (user.RowState == DataRowState.Added)
            {
               DateTime? expires = null;

               if (user.IsNewPasswordNull())
               {
                  throw new InvalidOperationException("New user has no password.");
               }
               if (!user.IsExpiresNull())
                  expires = user.Expires;
#if LEADTOOLS_V19_OR_LATER
               //userAgent.AddUser(user.UserName, user.FriendlyName, user.NewPassword, expires, user.UseCardReader);
               userAgent.AddUser(user.UserName, user.FriendlyName, user.NewPassword, expires, user.UseCardReader?"smartcard":"classic");
#else
               userAgent.AddUser(user.UserName, user.NewPassword, expires);
#endif
               
               Shell.LogAudit ( string.Format ( AuditMessages.NewUserAdded.Message, user.GetDisplayName() ) ) ;
            }
            else if (user.RowState == DataRowState.Deleted)
            {
               string username = Convert.ToString(usersDataSet.Users.Rows[i][0, DataRowVersion.Original]);
               string displayNameTemp = Convert.ToString(usersDataSet.Users.Rows[i][5, DataRowVersion.Original]);

               string displayName = username;
               if (!string.IsNullOrEmpty(displayNameTemp))
               {
                  displayName = displayNameTemp;
               }

               userAgent.RemoveUser(username);
               
               Shell.LogAudit ( string.Format ( AuditMessages.UserRemoved.Message, displayName ) ) ;
            }
            else if (user.RowState == DataRowState.Modified)
            {
               if (!user.IsNewPasswordNull())
               {
                  DateTime? expires = null;

                  if (!user.IsExpiresNull())
                     expires = user.Expires;

                  userAgent.SetUserPassword(user.UserName, user.NewPassword, expires, options.MaxPasswordHistory);
                  
                  Shell.LogAudit ( string.Format ( AuditMessages.UserPasswordChanged.Message, user.GetDisplayName() ) ) ;
               }
            }
            i++;
         }

         i = 0;
         bool currentUserPermissionChanged = false ;
         
         foreach (UsersSource.UserPermissionsRow permission in usersDataSet.UserPermissions)
         {
            string username = string.Empty;
            if (permission.RowState == DataRowState.Added)
            {
               username = permission.UserName;
            }
            else if (permission.RowState == DataRowState.Deleted)
            {
               username = Convert.ToString(usersDataSet.UserPermissions.Rows[i][0, DataRowVersion.Original]);
            }

            Leadtools.Medical.UserManagementDataAccessLayer.User existingUser =
               currentUsers.SingleOrDefault(x => x.UserName == username);
               
            UsersSource.UsersRow addedUserRow = usersDataSet.Users.SingleOrDefault(x => x.UserName == username);

            string displayName = username;

#if LEADTOOLS_V19_OR_LATER
            if (existingUser != null)
            {
               displayName = existingUser.GetDisplayName();
            }
            else if (addedUserRow !=null)
            {
               displayName = addedUserRow.GetDisplayName();
            }
#endif

            if (permission.RowState == DataRowState.Added)
            {
               permissionsAgent.AddUserPermission(permission.Permission, permission.UserName);

               Shell.LogAudit(string.Format(AuditMessages.PermissionAdded.Message, displayName, permission.Permission));

               if (permission.UserName == User.Name)
               {
                  currentUserPermissionChanged = true;

                  User.Permissions.Add(permission.Permission);
               }
            }
            else if (permission.RowState == DataRowState.Deleted)
            {
               string p = Convert.ToString(usersDataSet.UserPermissions.Rows[i][1, DataRowVersion.Original]);

               permissionsAgent.DeleteUserPermission(p, username);

               Shell.LogAudit(string.Format(AuditMessages.PermissionRemoved.Message, displayName, p));

               if (username == User.Name)
               {
                  currentUserPermissionChanged = true;

                  User.Permissions.Remove(p);
               }

               i++;
            }
         }

         users.AcceptChanges ( ) ;
         
         if ( currentUserPermissionChanged ) 
         {
            EventBroker.Instance.PublishEvent <CurrentUserPemissionsChangedEventArgs> ( null, new CurrentUserPemissionsChangedEventArgs ( ) ) ;
         }
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

#if LEADTOOLS_V19_OR_LATER
      public static List<string> GetCardReaderNames()
      {
         List<string> cardUsers = new List<string>();

         string[] cardReaderNames = userAgent.GetCardReaderNames();
         foreach(string cardReaderName in cardReaderNames)
         {
            cardUsers.Add(cardReaderName);

         }
         return cardUsers;
      }

      public static List<User> GetUsers(bool useCardReader)
      {
         return userAgent.GetUsers(useCardReader).ToList();
      }

      public static AuthenticateCardUserResult AuthenticateCardUser(int cardReaderIndex, string pin, bool checkPinOnly, out string ediNumber, out int pinCounter)
      {
         int result = userAgent.AuthenticateCardUser(cardReaderIndex, pin, checkPinOnly, out ediNumber, out pinCounter);
         return (AuthenticateCardUserResult)result;
      }

      public static bool IsUserCardReaderReady(int cardReaderIndex)
      {
         return userAgent.IsUserCardReaderReady(cardReaderIndex);
      }
#endif
   }

   public class UserPermissions
   {
      public const string Admin                   = "Admin";
      public const string CanDeleteFromDatabase   = "CanDeleteFromDatabase";
      public const string CanEmptyDatabase        = "CanEmptyDatabase";
      public const string CanChangeServerSettings = "CanChangeServerSettings";
      
   }

   public class ManagerUser
   {
      public string Name { get; set; }
      public string FriendlyName { get; set;}

      public List<string> Permissions { get; set; }

      public ManagerUser(string userName, string friendlyName, List<string> permissions)
      {
         Name = userName;
         FriendlyName = friendlyName;
         Permissions = new List<string>();
         Permissions.AddRange(permissions);
      }

      public bool IsAuthorized ( string permission ) 
      {
         return Permissions.Contains ( permission ) ;
      }

      public bool IsAdmin()
      {
         return Permissions.Contains(UserPermissions.Admin);
      }
   }
}
