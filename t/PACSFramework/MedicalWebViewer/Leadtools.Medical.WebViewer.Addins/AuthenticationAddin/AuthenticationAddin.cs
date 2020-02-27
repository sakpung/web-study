// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Medical.WebViewer.ServiceContracts;
using Leadtools.Medical.WebViewer.DataContracts;
using System.Security.Cryptography;
using System.IO;
using System.Runtime.Serialization;
using Leadtools.Medical.UserManagementDataAccessLayer;
using System.Security;
using Leadtools.Medical.OptionsDataAccessLayer;
using Leadtools.Medical.Winforms;
using System.Text.RegularExpressions;
using System.Configuration;
using Leadtools.Medical.Logging.DataAccessLayer;
using System.Diagnostics;
using System.Runtime.Serialization.Formatters.Binary;
using System.Dynamic;
using System.ComponentModel;

namespace Leadtools.Medical.WebViewer.Addins
{
   #region AES ENCODING/DECODING
   //public class EncryptionServices
   //{
   //   private static string _sEncodingKey = "FF587F26-213D-470E-8645-C1E19E0CC503";
   //   private static byte[] _salt = new byte[] { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0xF1, 0xF0, 0xEE, 0x21, 0x22, 0x45 };

   //   private static DeriveBytes DeriveBytes(string sKey)
   //   {
   //      //derive key from password and salt, salt should be 8 bytes or larger
   //      byte[] b = Encoding.Unicode.GetBytes(sKey);
   //      byte[] b16 = new byte[16];

   //      {
   //         for (int nIndex = 0; nIndex < b16.Length; nIndex++)
   //         {
   //            b16[nIndex] = 0;
   //         }

   //         for (int nIndex = 0; nIndex < b.Length; nIndex++)
   //         {
   //            b16[nIndex % 16] ^= b[(1 + nIndex) % b.Length];
   //         }
   //      }

   //      Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(b16, _salt, 0x3e8);
   //      return pdb;
   //   }

   //   private static Aes GetCryptoServiceProvider()
   //   {
   //      //
   //      // Use AesCryptoServiceProvider instead of AesManaged because AesManaged is not FIPS compliant
   //      // 
   //      Aes aes = new AesCryptoServiceProvider(); //new System.Security.Cryptography.AesManaged();
   //      return aes;
   //   }

   //   private static ICryptoTransform CreateDecryptor(string sKey)
   //   {
   //      DeriveBytes pdb = DeriveBytes(sKey);

   //      Aes cryptic = GetCryptoServiceProvider();

   //      byte[] bKey = pdb.GetBytes(cryptic.KeySize / 8);
   //      byte[] bVector = pdb.GetBytes(cryptic.BlockSize / 8);

   //      cryptic.Key = bKey;
   //      cryptic.IV = bVector;

   //      return cryptic.CreateDecryptor();
   //   }

   //   private static ICryptoTransform CreateEncryptor(string sKey)
   //   {
   //      DeriveBytes pdb = DeriveBytes(sKey);

   //      Aes cryptic = GetCryptoServiceProvider();

   //      byte[] bKey = pdb.GetBytes(cryptic.KeySize / 8);
   //      byte[] bVector = pdb.GetBytes(cryptic.BlockSize / 8);

   //      cryptic.Key = bKey;
   //      cryptic.IV = bVector;

   //      return cryptic.CreateEncryptor();
   //   }

   //   public static AuthenticationInfo Decode(string authenticationCookie)
   //   {
   //      AuthenticationInfo ai = null;
   //      byte[] data = Convert.FromBase64String(authenticationCookie);

   //      using (MemoryStream stream = new MemoryStream())
   //      {
   //         using (var crypt = CreateDecryptor(_sEncodingKey))
   //         {
   //            using (CryptoStream crStream = new CryptoStream(stream, crypt, CryptoStreamMode.Write))
   //            {
   //               try
   //               {
   //                  crStream.Write(data, 0, data.Length);
   //               }
   //               finally
   //               {
   //                  crStream.Close();
   //               }

   //               byte[] dataDecrypted = dataDecrypted = stream.ToArray();
   //               stream.Close();

   //               {
   //                  ai = new AuthenticationInfo();
   //                  ai.ReadFromStream(new MemoryStream(dataDecrypted));
   //               }
   //            }
   //         }
   //      }

   //      return ai;
   //   }

   //   public static string Encode(AuthenticationInfo ai)
   //   {
   //      //text to buffer
   //      byte[] dataEncrypted;

   //      using (MemoryStream stream = new MemoryStream())
   //      {
   //         using (var encrypt = CreateEncryptor(_sEncodingKey))
   //         {
   //            using (CryptoStream crStream = new CryptoStream(stream, encrypt, CryptoStreamMode.Write))
   //            {
   //               //encode
   //               try
   //               {
   //                  ai.WriteToStream(crStream);
   //               }
   //               catch (SerializationException)
   //               {
   //                  throw;
   //               }
   //               finally
   //               {
   //                  crStream.Close();
   //               }
   //            }
   //         }

   //         //read resulted buffer
   //         dataEncrypted = stream.ToArray();
   //         stream.Close();
   //      }

   //      //convert buffer to string
   //      string sEncoded = Convert.ToBase64String(dataEncrypted);

   //      return sEncoded;
   //   }
   //}
   #endregion

   #region MD5/RC4 ENCODING/DECODING
   public class RC4
   {
      //MD5 hashed private key ("FF587F26-213D-470E-8645-C1E19E0CC503")
      static readonly byte[] m_s = new byte[256] { 137, 164, 8, 213, 173, 203, 198, 91, 155, 53, 32, 157, 9, 70, 222, 99, 60, 14, 94, 98, 6, 34, 47, 159, 89, 86, 66, 118, 72, 25, 46, 97, 122, 100, 209, 37, 111, 17, 80, 103, 165, 238, 124, 145, 78, 234, 130, 121, 207, 231, 177, 18, 179, 43, 194, 63, 114, 3, 180, 230, 68, 214, 51, 181, 83, 115, 195, 247, 69, 4, 65, 170, 219, 58, 93, 76, 112, 116, 166, 228, 110, 169, 148, 254, 176, 174, 129, 77, 128, 210, 135, 147, 75, 161, 26, 84, 73, 248, 125, 233, 200, 95, 188, 133, 246, 0, 106, 126, 41, 120, 20, 48, 71, 224, 102, 38, 152, 151, 175, 30, 140, 1, 182, 101, 119, 211, 250, 208, 144, 123, 232, 33, 229, 141, 138, 132, 81, 90, 168, 12, 241, 143, 27, 244, 171, 199, 156, 240, 223, 196, 57, 227, 39, 253, 109, 5, 204, 221, 193, 191, 50, 22, 24, 56, 88, 131, 44, 187, 87, 201, 189, 149, 113, 96, 160, 82, 108, 62, 52, 45, 134, 79, 64, 255, 54, 92, 167, 163, 28, 190, 205, 236, 220, 85, 237, 235, 21, 7, 42, 215, 16, 31, 216, 11, 202, 217, 107, 67, 153, 226, 35, 243, 192, 218, 13, 59, 252, 10, 104, 178, 197, 136, 162, 40, 23, 225, 184, 242, 127, 186, 19, 74, 2, 172, 183, 55, 249, 245, 251, 142, 139, 117, 185, 239, 15, 146, 154, 29, 212, 158, 150, 61, 105, 49, 36, 206 };

      static public byte[] Transform(byte[] src)
      {
         byte m_i = 0;
         byte m_j = 0;

         int len = src.Length;
         byte[] dst = new byte[len];

         for (uint n = 0; n < len; n++)
         {
            m_i++;
            m_j = (byte)(m_j + m_s[m_i]);
            dst[n] = (byte)(src[n] ^ m_s[(byte)(m_s[m_i] + m_s[m_j])]);
         }
         return dst;
      }
   }

   public class EncryptionServices
   {
      static public AuthenticationInfo Decode(string authenticationCookie)
      {
         byte[] data = Convert.FromBase64String(authenticationCookie);
         RC4.Transform(data);

         using (var stream = new MemoryStream(data))
         {
            var ai = new AuthenticationInfo();
            ai.ReadFromStream(stream);
            return ai;
         }
      }

      static public string Encode(AuthenticationInfo ai)
      {
         using (var stream = new MemoryStream())
         {
            ai.WriteToStream(stream);
            var data = stream.ToArray();

            RC4.Transform(data);

            string sEncoded = Convert.ToBase64String(data);
            return sEncoded;
         }
      }
   }
   #endregion


   /// <summary>
   /// light-weight alternative for in-session authentication
   /// </summary>
   public class SessionAuthenticationAddin : ISessionAuthenticationAddin
   {
      public AuthenticationInfo GetAuthenticationInfo(string authenticationCookie)
      {
         if (string.IsNullOrEmpty(authenticationCookie))
         {
            throw new ArgumentException("authenticationCookie");
         }

         AuthenticationInfo ai = EncryptionServices.Decode(authenticationCookie);

         return ai;
      }

      public bool HasPermission(AuthenticationInfo ai, string permission)
      {
         if (string.IsNullOrEmpty(permission))
         {
            return true;
         }

         return PermissionsTable.Instance.Contains(ai.PermissionsToken, permission);
      }

      public bool IsTimedOut(AuthenticationInfo ai)
      {
         if (ai.ExpirationTime < DateTime.UtcNow)
         {
            return true;
         }

         return false;
      }


      public bool HasPermission(AuthenticationInfo ai, Permission permission)
      {
         if (null == permission)
         {
            return true;
         }

         return PermissionsTable.Instance.Contains(ai.PermissionsToken, permission);
      }
   }

   /// <summary>
   /// 
   /// </summary>
   public class AuthenticationAddin : IAuthenticationAddin
   {
      const int _CookieTimeOutInHours = 10;

      IUserManagementDataAccessAgent4 UserManagementAgent { get; set; }
      Leadtools.Medical.PermissionsManagement.DataAccessLayer.IPermissionManagementDataAccessAgent2 PermissionManagementAgent { get; set; }
      IOptionsDataAccessAgent OptionsAgent { get; set; }
      ILoggingDataAccessAgent LoggingAgent { get; set; }

      public AuthenticationAddin(IUserManagementDataAccessAgent4 UserManagementDataAccessAgent, Leadtools.Medical.PermissionsManagement.DataAccessLayer.IPermissionManagementDataAccessAgent2 PermissionManagementDataAccessAgent, IOptionsDataAccessAgent optionsAgent,
                                   ILoggingDataAccessAgent loggingAgent)
      {
         UserManagementAgent = UserManagementDataAccessAgent;
         PermissionManagementAgent = PermissionManagementDataAccessAgent;
         OptionsAgent = optionsAgent;
         LoggingAgent = loggingAgent;

         AuthenticationLogger.OptionsAgent = optionsAgent;
      }

      private SecureString ToSecureString(string s)
      {
         if (string.IsNullOrEmpty(s))
            return null;

         SecureString ss = new SecureString();

         char[] Chars = s.ToCharArray();
         foreach (char c in Chars)
         {
            ss.AppendChar(c);
         }
         return ss;
      }

      public string AuthenticateUser(string userName, string password, string userData)
      {
         return AuthenticateUser(userName, password, userData, TimeSpan.FromHours(_CookieTimeOutInHours), null);
      }

      public string AuthenticateUser(string userName, string password, string userData, TimeSpan lifeTime, string impersonatedUser)
      {
         if (!ValidateUser(userName, password, null))
         {
            LoggingAgent.Login(userName, false);
            //throw new Exception("User name or password is incorrect");
            return string.Empty;
         }

         AuthenticationInfo ai = new AuthenticationInfo()
         {
            UserName = userName,
            ExpirationTime = DateTime.UtcNow + lifeTime,
            PermissionsToken = PermissionsTable.Instance.ToToken(GetUserPermissions(userName)),
            ImpersonatedUserName = impersonatedUser
         };

         LoggingAgent.Login(userName, true);
         return EncryptionServices.Encode(ai);
      }

      public AuthenticationInfo GetAuthenticationInfo(string authenticationCookie, string userData)
      {
         if (string.IsNullOrEmpty(authenticationCookie))
         {
            throw new ArgumentException("authenticationCookie");
         }

         AuthenticationInfo ai = EncryptionServices.Decode(authenticationCookie);

         return ai;
      }

      public bool IsTimedOut(AuthenticationInfo ai, string userData)
      {
         if (ai.ExpirationTime < DateTime.UtcNow)
         {
            return true;
         }

         return false;
      }

      public bool HasPermission(string username, string permission, string userData)
      {
         if (string.IsNullOrEmpty(permission))
         {
            return true;
         }

         return GetUserPermissionsNames(username).Contains(permission);
      }

      public Permission[] GetUserAssignedPermissions(string username)
      {
         List<Permission> permissions = new List<Permission>();

         string[] permissionsNames = PermissionManagementAgent.GetUserPermissions(username);
         foreach (string p in permissionsNames)
         {
            permissions.Add(PermissionsTable.Instance.Find(p));
         }

         return permissions.ToArray();
      }

      public string[] GetUserAssignedPermissionsNames(string username)
      {
         List<string> permissionsnames = new List<string>();
         Permission[] permissions = GetUserAssignedPermissions(username);
         foreach (Permission p in permissions)
         {
            if (null != p)
            {
               permissionsnames.Add(p.Name);
            }
         }
         return permissionsnames.ToArray();
      }

      public string[] GetUserPermissionsNames(string username)
      {
         List<string> permissionsnames = new List<string>();
         Permission[] permissions = GetUserPermissions(username);
         foreach (Permission p in permissions)
         {
            if (null != p)
            {
               permissionsnames.Add(p.Name);
            }
         }
         return permissionsnames.ToArray();
      }

      public Permission[] GetUserPermissions(string username)
      {
         if (IsAdmin(username, ""))
         {
            //all are granted
            return PermissionsTable.Instance.Permissions.ToArray();
         }

         Permission[] permissions = GetUserAssignedPermissions(username);
         Role[] roles = GetUserRoles(username);
         return MergePermissions(roles, permissions);
      }

      public void GrantPermission(string authUser, string username, string permission, string userData)
      {
         bool audit = false;

         if (string.IsNullOrEmpty(permission))
         {
            return;
         }

         audit = !PermissionManagementAgent.UserHasPermission(permission, username);
         PermissionManagementAgent.AddUserPermission(permission, username);
         if (audit)
         {
            LoggingAgent.ChangePermission(authUser, username, permission, "Granted");
         }
      }

      public void DenyPermission(string authUser, string username, string permission, string userData)
      {
         bool audit = false;

         if (string.IsNullOrEmpty(permission))
         {
            return;
         }

         audit = PermissionManagementAgent.UserHasPermission(permission, username);
         PermissionManagementAgent.DeleteUserPermission(permission, username);
         if (audit)
         {
            LoggingAgent.ChangePermission(authUser, username, permission, "Denied");
         }
      }


      Permission[] MergePermissions(Role[] roles, Permission[] permissions)
      {
         Dictionary<string, Permission> UnionPermissions = new Dictionary<string, Permission>();

         foreach (Role role in roles)
         {
            if (null != role)
            {
               List<string> PermissionsList = role.AssignedPermissions;
               foreach (string permission in PermissionsList)
               {
                  if (null != permission)
                  {
                     UnionPermissions[permission] = PermissionsTable.Instance.Find(permission);
                  }
               }
            }
         }

         foreach (Permission permission in permissions)
         {
            if (null != permission)
            {
               UnionPermissions[permission.Name] = permission;
            }
         }

         return UnionPermissions.Values.ToArray();
      }


      bool RoleExist(string roleName)
      {
         return RoleIsBuiltIn(roleName) || PermissionManagementAgent.RoleExist(roleName);
      }

      bool RoleIsBuiltIn(string roleName)
      {
         return (null != RolesBuiltInTable.Instance.Find(roleName));
      }

      public void GrantRole(string username, string role, string userData)
      {
         if (string.IsNullOrEmpty(role))
         {
            return;
         }

         if (!RoleExist(role))
         {
            throw new Exception("Role doesn't exist");
         }

         PermissionManagementAgent.AddUserRole(role, username);
      }

      public void DenyRole(string username, string role, string userData)
      {
         if (string.IsNullOrEmpty(role))
         {
            return;
         }

         PermissionManagementAgent.DeleteUserRole(role, username);
         if (role == RolesBuiltInTable.Instance.Admin.Name)
         {
            PermissionManagementAgent.DeleteUserPermission("Admin", username);
         }
      }

      public void CreateUser(string authUser, string username, string password, string userType, DateTime? expires)
      {
         User[] users = UserManagementAgent.GetUsers();
         PasswordOptions options;

         if (expires == null)
         {
            options = OptionsAgent.Get<PasswordOptions>(PasswordOptionsPresenter.PasswordOptions, new PasswordOptions());
            if (options.DaysToExpire > 0)
            {
               expires = DateTime.Now.AddDays(options.DaysToExpire);
            }
         }

         if (UserManagementAgent.UserExists(username))
         {
            throw new Exception("User already exist.");
         }

         UserManagementAgent.AddUser(username, string.Empty, ToSecureString(password), expires, userType);
         LoggingAgent.AddUser(authUser, username);
      }

      public void DeleteUser(string authUser, string username, string userData)
      {
         string[] userRoles = PermissionManagementAgent.GetUserRoles(username);
         string[] userPermissions = PermissionManagementAgent.GetUserPermissions(username);

         foreach (string role in userRoles)
         {
            PermissionManagementAgent.DeleteUserRole(role, username);
         }

         foreach (string permission in userPermissions)
         {
            PermissionManagementAgent.DeleteUserPermission(permission, username);
         }

         UserManagementAgent.RemoveUser(username);
         LoggingAgent.DeleteUser(authUser, username);
      }

      public static dynamic ToDynamic(Leadtools.Medical.UserManagementDataAccessLayer.User user)
      {
         dynamic d = new ExpandoObject();
         d.Expires = user.Expires;
         d.FriendlyName = user.FriendlyName;
         d.IsAdmin = user.IsAdmin;
         d.UseCardReader = user.UseCardReader;
         d.UserName = user.UserName;
         d.UserType = user.UserType;

         return d;
      }

      public dynamic[] GetAllUsersFullInfo()
      {
         return UserManagementAgent.GetUsers().Select(i => ToDynamic(i)).ToArray();
      }

      public string[] GetAllUsers(string userData)
      {
         List<string> usersList = new List<string>();
         Leadtools.Medical.UserManagementDataAccessLayer.User[] Users = UserManagementAgent.GetUsers();

         foreach (Leadtools.Medical.UserManagementDataAccessLayer.User user in Users)
         {
            usersList.Add(user.UserName);
         }
         return usersList.ToArray();
      }

      public dynamic[] GetAllUsers(Dictionary<string,string> query)
      {
         return UserManagementAgent.GetUsers(query).Select(i => ToDynamic(i)).ToArray();
      }

      public bool ValidateUser(string username, string password, string userData)
      {
         return UserManagementAgent.IsUserValid(username, ToSecureString(password));
      }

      public bool ResetPassword(string username, string newPassowrd, string userData)
      {
         PasswordOptions options;
         DateTime? expires = null;

         options = OptionsAgent.Get<PasswordOptions>(PasswordOptionsPresenter.PasswordOptions, new PasswordOptions());
         if (options.DaysToExpire > 0)
         {
            expires = DateTime.Now.AddDays(options.DaysToExpire);
         }

         return UserManagementAgent.SetUserPassword(username, ToSecureString(newPassowrd), expires, options.MaxPasswordHistory);
      }

      public bool ChangePassword(string username, string oldpassword, string newpassword, string userData)
      {
         if (ValidateUser(username, oldpassword, null))
         {
            return ResetPassword(username, newpassword, null);
         }
         return false;
      }


      public bool IsAdmin(string username, string userData)
      {
         bool admin = PermissionManagementAgent.UserHasPermission("Admin", username);

         if (!admin)
         {
            string[] roles = PermissionManagementAgent.GetUserRoles(username);

            admin = roles.Contains(RolesBuiltInTable.Instance.Admin.Name);

            if (!admin)
            {
               foreach (var role in roles)
               {
                  var rolePermissions = PermissionManagementAgent.GetRolePermissions(role);
                  if(rolePermissions.Contains("Admin"))
                  {
                     admin = true;
                     break;
                  }
               }
            }
         }
         return admin;
      }

      public Role[] GetUserRoles(string username)
      {
         List<Role> roles = new List<Role>();
         string[] temp_roles = PermissionManagementAgent.GetUserRoles(username);

         foreach (string da_roleName in temp_roles)
         {
            Leadtools.Medical.PermissionsManagement.DataAccessLayer.Role da_role = PermissionManagementAgent.GetRole(da_roleName);
            if (null != da_role)
               roles.Add(TranslateRole(da_role));

            //also look in built-in roles
            {
               Role r = RolesBuiltInTable.Instance.Find(da_roleName);
               if (null != r)
                  roles.Add(r);
            }
         }

         if (IsAdmin(username, ""))
         {
            if (!roles.Contains(RolesBuiltInTable.Instance.Admin, new RoleComparer()))
            {
               roles.Add(RolesBuiltInTable.Instance.Admin);
            }
         }

         return roles.ToArray();
      }

      public string[] GetUserRolesNames(string username)
      {
         string[] temp_roles = PermissionManagementAgent.GetUserRoles(username);
         List<string> roles = new List<string>(temp_roles);

         if (IsAdmin(username, ""))
         {
            if (!roles.Contains(RolesBuiltInTable.Instance.Admin.Name))
            {
               roles.Add(RolesBuiltInTable.Instance.Admin.Name);
            }
         }

         return roles.ToArray();
      }

      Role TranslateRole(Leadtools.Medical.PermissionsManagement.DataAccessLayer.Role r1)
      {
         Role r2 = new Role();
         r2.Name = r1.Name;
         r2.Description = r1.Description;
         r2.AssignedPermissions = new List<string>();
         if (null != r1.AssignedPermissions)
         {
            foreach (string p1 in r1.AssignedPermissions)
            {
               Permission permission = PermissionsTable.Instance.Find(p1);
               if (null != permission)
                  r2.AssignedPermissions.Add(permission.Name);
            }
         }
         return r2;
      }

      Leadtools.Medical.PermissionsManagement.DataAccessLayer.Role TranslateRole(Role r1)
      {
         Leadtools.Medical.PermissionsManagement.DataAccessLayer.Role r2 = new Leadtools.Medical.PermissionsManagement.DataAccessLayer.Role();
         r2.Name = r1.Name;
         r2.Description = r1.Description;
         List<string> AssignedPermissions = new List<string>();
         if (null != r1.AssignedPermissions)
         {
            foreach (string p1 in r1.AssignedPermissions)
            {
               AssignedPermissions.Add(p1);
            }
         }
         r2.AssignedPermissions = AssignedPermissions.ToArray();
         return r2;
      }

      void IncludeBuiltInRoles(List<Role> roles)
      {
         foreach (Role role in RolesBuiltInTable.Instance.Roles)
         {
            roles.Add(role);
         }
      }

      Role GetBuiltInRole(string roleName)
      {
         foreach (Role role in RolesBuiltInTable.Instance.Roles)
         {
            if (role.Name == roleName)
            {
               return role;
            }
         }
         return null;
      }

      public string[] GetRolesNames()
      {
         List<string> RolesNamesLst = new List<string>();
         Role[] roles = GetRoles();
         foreach (Role r in roles)
         {
            RolesNamesLst.Add(r.Name);
         }
         return RolesNamesLst.ToArray();
      }

      public Role GetRole(string roleName)
      {
         Role roleBuiltIn = GetBuiltInRole(roleName);
         if (null != roleBuiltIn)
         {
            return roleBuiltIn;
         }

         Leadtools.Medical.PermissionsManagement.DataAccessLayer.Role da_role = PermissionManagementAgent.GetRole(roleName);
         if (null != da_role)
         {
            return TranslateRole(da_role);
         }

         return null;
      }

      public Role[] GetRoles()
      {
         List<Role> roles = new List<Role>();

         IncludeBuiltInRoles(roles);

         Leadtools.Medical.PermissionsManagement.DataAccessLayer.Role[] da_roles = PermissionManagementAgent.GetRoles();

         foreach (Leadtools.Medical.PermissionsManagement.DataAccessLayer.Role da_role in da_roles)
         {
            roles.Add(TranslateRole(da_role));
         }

         return roles.ToArray();
      }

      public void CreateRole(string authUser, Role role)
      {
         if (RoleExist(role.Name))
         {
            throw new Exception("Role already exist");
         }

         PermissionManagementAgent.AddRole(TranslateRole(role));
         LoggingAgent.AddRole(authUser, role.Name);
      }

      public void UpdateRolePermissions(string authUser, Role role)
      {
         IEnumerable<string> permissionsToAdd;
         IEnumerable<string> permissionsToDelete;

         if (RoleIsBuiltIn(role.Name))
         {
            throw new Exception("Role can't be customized");
         }

         Role roleToUpdate = TranslateRole(PermissionManagementAgent.GetRole(role.Name));

         permissionsToAdd = role.AssignedPermissions.Except(roleToUpdate.AssignedPermissions);
         permissionsToDelete = roleToUpdate.AssignedPermissions.Except(role.AssignedPermissions);

         foreach (string permission in permissionsToAdd)
         {
            LoggingAgent.ChangePermission(authUser, role.Name, permission, "Role Granted");
         }

         foreach (string permission in permissionsToDelete)
         {
            LoggingAgent.ChangePermission(authUser, role.Name, permission, "Role Denied");
         }

         roleToUpdate.AssignedPermissions = role.AssignedPermissions;

         PermissionManagementAgent.UpdateRole(TranslateRole(roleToUpdate));
      }

      public void DeleteRole(string authUser, string roleName)
      {
         if (RoleIsBuiltIn(roleName))
         {
            throw new Exception("Role can't be deleted");
         }

         PermissionManagementAgent.DeleteRole(roleName);
         LoggingAgent.DeleteRole(authUser, roleName);
      }

      public string ValidatePassword(string password, string userData)
      {
         PasswordOptions options;
         string message;

         options = OptionsAgent.Get<PasswordOptions>(PasswordOptionsPresenter.PasswordOptions, new PasswordOptions());
         if (!PasswordValidator.Validate(password, password, options, out message))
         {
            return message;
         }

         return string.Empty;
      }

      public bool IsPasswordExpired(string userName)
      {
         return UserManagementAgent.IsUserPasswordExpired(userName);
      }

      public Permission[] GetPermissions()
      {
         PermissionsManagement.DataAccessLayer.Permission[] permissions = PermissionManagementAgent.GetPermissions();
         var allPermissions = (from p in permissions
                               select new Permission
                               {
                                  Name = p.Name,
                                  Description = p.Description,
                                  FriendlyName = p.Name.Replace("MWV.", string.Empty).SplitCamelCase()
                               }
                 ).ToArray();

         if (Convert.ToBoolean(ConfigurationManager.AppSettings["AllPermissions"]) == true)
            return allPermissions;

         return allPermissions.Where((p) => p.Name.Contains("MWV")).ToArray();
      }
   }
}

static class StringExtensions
{
    public static string SplitCamelCase(this string str)
    {
        return Regex.Replace(Regex.Replace(str, @"(\P{Ll})(\P{Ll}\p{Ll})", "$1 $2"), @"(\p{Ll})(\P{Ll})", "$1 $2");
    }
}
