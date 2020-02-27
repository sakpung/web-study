// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Leadtools.Medical.PermissionsManagement.DataAccessLayer
{
   [Serializable]
   public class Permission
   {
      public Permission()
      {
      }

      public Permission(string name, string description)
      {
         Name = name;
         Description = description;
      }

      public string Name { get; set; }
      public string Description { get; set; }
   }

   [Serializable]
   public class Role
   {
      public Role()
      {
         AssignedPermissions = new string[0];
      }

      public Role(string name, string description)
      {
         Name = name;
         Description = description;
         AssignedPermissions = new string[0];
      }

      public string Name { get; set; }
      public string Description { get; set; }
      public string[] AssignedPermissions { get; set; }

      public override string ToString()
      {
         return Name;
      }
   }

   [Serializable]
   public class UserPermission
   {
      public string Username { get; set; }
      public string Permission { get; set; }
   }

   public interface IPermissionManagementDataAccessAgent
   {
      Permission[] GetPermissions();
      Permission GetPermission(string name);
      void UpdatePermission(string name, Permission permission);
      void DeletePermission(string name);
      string[] GetUserPermissions(string userName);
      void AddUserPermission(string permissionName, string userName);
      void DeleteUserPermission(string permissionName, string userName);
      UserPermission[] GetAllUserPermissions();
      bool UserHasPermission(string permissionName, string userName);
   }

   public interface IPermissionManagementDataAccessAgent2 : IPermissionManagementDataAccessAgent
   {
      bool RoleExist(string roleName);
      Role[] GetRoles();
      Role[] GetRolesLight();
      void AddRole(Role role);
      Role GetRole(string roleName);
      string[] GetRolePermissions(string roleName);
      void UpdateRole(Role role);
      void DeleteRole(string roleName);
      string[] GetUserRoles(string userName);
      void AddUserRole(string roleName, string userName);
      void DeleteUserRole(string roleName, string userName);
   }
}
