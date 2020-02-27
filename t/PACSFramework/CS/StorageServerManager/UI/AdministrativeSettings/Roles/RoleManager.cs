// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Medical.PermissionsManagement.DataAccessLayer;
using System.Collections.ObjectModel;
using Leadtools.Medical.DataAccessLayer;
using Leadtools.Medical.DataAccessLayer.Configuration;
using Leadtools.Medical.PermissionsManagement.DataAccessLayer.Configuration;
using Leadtools.DicomDemos;

namespace Leadtools.Demos.StorageServer.UI.AdministrativeSettings.Users
{
   public static class RoleManager
   {
      private static List<Role> _BuiltInRoles = new List<Role>();
      private static IPermissionManagementDataAccessAgent2 permissionsAgent;

      public static ReadOnlyCollection<Role> BuiltInRoles 
      {
         get
         {
            return _BuiltInRoles.AsReadOnly();
         }
      }

      public static readonly Role Admin = new Role() { Name = "Administrators", Description = "Web viewer administrator, full permissions.", AssignedPermissions = PermissionsTable.Instance.PermissionsNames.ToArray() };

      static RoleManager()
      {
         _BuiltInRoles.Add(Admin);
         permissionsAgent = GetDataAccess<IPermissionManagementDataAccessAgent2>(new PermissionManagementDataAccessConfigurationView(DicomDemoSettingsManager.GetGlobalPacsConfiguration(), DicomDemoSettingsManager.ProductNameStorageServer, null));
      }

      public static Role[] GetAllRoles()
      {
         List<Role> roles = new List<Role>();

         foreach (Role role in BuiltInRoles)
         {
            roles.Add(role);
         }

         foreach(Role role in permissionsAgent.GetRoles())
         {
            roles.Add(role);
         }

         return roles.ToArray();
      }

      public static Role[] GetUserRoles(string userName)
      {
         List<Role> roles = new List<Role>();
         string[] temp_roles = permissionsAgent.GetUserRoles(userName);

         foreach (string roleName in temp_roles)
         {
            Role role = permissionsAgent.GetRole(roleName);
            Role builtIn = Find(roleName);

            if (role != null)
               roles.Add(role);

            if (builtIn != null)
               roles.Add(builtIn);
         }

         if (permissionsAgent.UserHasPermission(UserPermissions.Admin, userName))
         {
            if (!roles.Contains(Admin, new RoleComparer()))
               roles.Add(Admin);
         }

         return roles.ToArray();
      }

      public static Role Find(string name)
      {
         Role result = _BuiltInRoles.Find(delegate(Role Role) { return Role.Name == name; });

         return result;
      }

      public static void UpdateRole(Role role)
      {
         permissionsAgent.UpdateRole(role);
      }

      public static void AddRole(Role role)
      {
         permissionsAgent.AddRole(role);
      }

      public static void DeleteRole(string roleName)
      {
         permissionsAgent.DeleteRole(roleName);
      }

      public static void SetUserRoles(string userName, List<Role> roles)
      {
         List<string> currentRoles = GetUserRoles(userName).Select(r=>r.Name).ToList();
         List<string> deleteRoles = currentRoles.Except(roles.Select(r => r.Name)).ToList();

         foreach (Role role in roles)
         {
            permissionsAgent.AddUserRole(role.Name, userName);
         }

         foreach (string role in deleteRoles)
         {
            permissionsAgent.DeleteUserRole(role, userName);
         }
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
   }

   public class RoleComparer : IEqualityComparer<Role>
   {
      public bool Equals(Role r1, Role r2)
      {
         return r1.Name == r2.Name;
      }

      public int GetHashCode(Role r)
      {
         return r.Name.GetHashCode();
      }
   }

   public class PermissionsTable
   {
      const string _prefix = "MWV.";

      static PermissionsTable _instance = new PermissionsTable();
      public static PermissionsTable Instance { get { return _instance; } }

      public readonly Permission CanDownloadImages = new Permission() { Name = _prefix + "CanDownloadImages", Description = "Allow users to Move images from remote PACS." };
      public readonly Permission CanDeleteImages = new Permission() { Name = "CanDeleteFromDatabase",  Description = "Allow users to delete from storage database." };
      public readonly Permission CanDeleteDownloadInfo = new Permission() { Name = _prefix + "CanDeleteDownloadInfo",  Description = "Allow users to delete jobs in download queue." };
      public readonly Permission CanRetrieve = new Permission() { Name = _prefix + "CanRetrieve",  Description = "Allow users to request DICOM DataSet through the web interface." };
      public readonly Permission CanQueryPACS = new Permission() { Name = _prefix + "CanQueryPACS",  Description = "Allow users to query remote PACS through the web interface." };
      public readonly Permission CanQuery = new Permission() { Name = _prefix + "CanQuery",  Description = "Allow users to query local images through the web interface." };
      public readonly Permission CanManageUsers = new Permission() { Name = _prefix + "CanManageUsers",  Description = "Allow users to manage other users through the web interface." };
      public readonly Permission CanManageRoles = new Permission() { Name = _prefix + "CanManageRoles",  Description = "Allow users to manage roles through the web interface." };
      public readonly Permission CanManageAccessRight = new Permission() { Name = _prefix + "CanManageAccessRight",  Description = "Allow users to grant or deny access to patient information through the web interface." };
      public readonly Permission CanStore = new Permission() { Name = _prefix + "CanStore",  Description = "Allow users to store to server." };
      public readonly Permission CanViewAnnotations = new Permission() { Name = _prefix + "CanViewAnnotations",  Description = "Allow users to load annotations." };
      public readonly Permission CanStoreAnnotations = new Permission() { Name = _prefix + "CanStoreAnnotations",  Description = "Allow users to save annotations." };
      public readonly Permission CanDeleteAnnotations = new Permission() { Name = _prefix + "CanDeleteAnnotations",  Description = "Allow users to save annotations." };
      public List<Permission> Permissions { get; private set; }

      public List<string> PermissionsNames
      {
         get 
         {
            List<string> permissionsNames = new List<string>();
            foreach (Permission permission in Permissions)
            {
               permissionsNames.Add(permission.Name);
            }
            return permissionsNames;
         }
      }

      public PermissionsTable()
      {
         Permissions = new List<Permission>();

         Permissions.Add(CanDownloadImages);
         // Permissions.Add(CanDeleteImages);
         Permissions.Add(CanDeleteDownloadInfo);
         Permissions.Add(CanRetrieve);
         Permissions.Add(CanQueryPACS);
         Permissions.Add(CanQuery);
         Permissions.Add(CanManageUsers);
         Permissions.Add(CanManageRoles);
         Permissions.Add(CanManageAccessRight);
         Permissions.Add(CanStore);
         Permissions.Add(CanViewAnnotations);
         Permissions.Add(CanStoreAnnotations);
         Permissions.Add(CanDeleteAnnotations);
      }
      
      public Permission Find(string name)
      {
         Permission result = Permissions.Find(delegate(Permission permission) { return permission.Name == name; });
         return result;
      }

      public Permission[] Find(string[] names)
      {
         List<Permission> result = new List<Permission>();
         foreach (string p in names)
         {
            result.Add(Find(p));
         }
         return result.ToArray();
      }
   }
}
