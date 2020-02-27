// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data;
using System.Security.Cryptography;
using System.Runtime.InteropServices;
using System.Security;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Leadtools.Medical.PermissionsManagement.DataAccessLayer.DataAccessAgent;

namespace Leadtools.Medical.PermissionsManagement.DataAccessLayer
{
   public abstract class PermissionManagementDBDataAccessAgent : IPermissionManagementDataAccessAgent, IPermissionManagementDataAccessAgent2
   {
      private string _ConnectionString;

      public string ConnectionString
      {
         get
         {
            return _ConnectionString;
         }

         private set
         {
            _ConnectionString = value;
         }
      }

      private Database _DatabaseProvider;

      protected Database DatabaseProvider
      {
         get
         {
            if (null == _DatabaseProvider)
            {
               _DatabaseProvider = CreateDatabaseProvider();
            }

            return _DatabaseProvider;
         }

         private set
         {
            _DatabaseProvider = value;
         }
      }

      public PermissionManagementDBDataAccessAgent(string connectionString)
      {
         _ConnectionString = connectionString;
      }

      #region Protected Abstract Methods

      protected abstract Database CreateDatabaseProvider();
      protected abstract object RunQueryScalar(string query);
      protected abstract object RunQueryScalar(DbCommand command);
      protected abstract void InitializeGetPermissions(DbCommand command);
      protected abstract void InitializeGetRoles(DbCommand command);
      protected abstract void InitializeGetRole(DbCommand command, string roleName);
      protected abstract void InitializeGetUserPermissions(DbCommand command, string userName);
      protected abstract void InitializeGetUserRoles(DbCommand command, string userName);
      protected abstract void InitializeGetRolePermissions(DbCommand command, string roleName);
      protected abstract void InitializeAddUserPermission(DbCommand command, string userName, string permission);
      protected abstract void InitializeAddUserRole(DbCommand command, string userName, string role);
      protected abstract void InitializeAddRole(DbCommand command, string roleName, string description);
      protected abstract void InitializeAddRolePermission(DbCommand command, string roleName, string permission);
      protected abstract void InitializeDeleteUserPermission(DbCommand command, string userName, string permission);
      protected abstract void InitializeDeleteUserRole(DbCommand command, string userName, string roleName);
      protected abstract void InitializeDeleteRole(DbCommand command, string roleName);
      protected abstract void InitializeDeleteRolePermissions(DbCommand command, string roleName);
      protected abstract void InitializeGetAllUserPermissions(DbCommand command);
      protected abstract void InitializeUserHasPermission(DbCommand command, string userName, string permission);
      protected abstract void InitializeUserHasRole(DbCommand command, string userName, string role);

      #endregion

      //all interface methods implementations that receive a userName should call this function
      public virtual string FromInputUserName(string userName)
      {
         return UserNameResolver.ToDb(userName, string.Empty).Item1;
      }

      #region IPermissionManagementDataAccessAgent Members

      public Permission[] GetPermissions()
      {

         List<Permission> permissions = new List<Permission>();

         using (var command = DatabaseProvider.DbProviderFactory.CreateCommand())
         {
            InitializeGetPermissions(command);
            using (IDataReader reader = DatabaseProvider.ExecuteReader(command))
            {
               while (reader.Read())
               {
                  Permission p = new Permission();

                  p.Name = reader.GetColumnValue<string>("Permission");
                  p.Description = reader.GetColumnValue<string>("Description");
                  permissions.Add(p);
               }
            }
         }
         return permissions.ToArray();
      }

      public Permission GetPermission(string name)
      {
         throw new NotImplementedException();
      }

      public void UpdatePermission(string name, Permission permission)
      {
         throw new NotImplementedException();
      }

      public void DeletePermission(string name)
      {
         throw new NotImplementedException();
      }

      public string[] GetUserPermissions(string userName)
      {
         userName = FromInputUserName(userName);

         List<string> permissions = new List<string>();

         using (var command = DatabaseProvider.DbProviderFactory.CreateCommand())
         {
            InitializeGetUserPermissions(command, userName);
            using (IDataReader reader = DatabaseProvider.ExecuteReader(command))
            {
               while (reader.Read())
               {
                  permissions.Add(reader.GetColumnValue<string>("Permission"));
               }
            }
         }
         return permissions.ToArray();
      }

      public void AddUserPermission(string permissionName, string userName)
      {
         userName = FromInputUserName(userName);

         if (!UserHasPermission(permissionName, userName))
         {


            using (var command = DatabaseProvider.DbProviderFactory.CreateCommand())
            {
               InitializeAddUserPermission(command, userName, permissionName);
               DatabaseProvider.ExecuteNonQuery(command);
            }
         }
      }

      public void DeleteUserPermission(string permissionName, string userName)
      {
         userName = FromInputUserName(userName);

         using (var command = DatabaseProvider.DbProviderFactory.CreateCommand())
         {
            InitializeDeleteUserPermission(command, userName, permissionName);
            DatabaseProvider.ExecuteNonQuery(command);
         }
      }

      public UserPermission[] GetAllUserPermissions()
      {

         List<UserPermission> permissions = new List<UserPermission>();

         using (var command = DatabaseProvider.DbProviderFactory.CreateCommand())
         {
            InitializeGetAllUserPermissions(command);
            using (IDataReader reader = DatabaseProvider.ExecuteReader(command))
            {
               while (reader.Read())
               {
                  UserPermission up = new UserPermission();

                  up.Permission = reader.GetColumnValue<string>("Permission");
                  up.Username = reader.GetColumnValue<string>("Username");

                  var userType = reader.GetColumnValueOrDefault<string>("UserType");
                  var extendedName = reader.GetColumnValueOrDefault<string>("ExtendedName");
                  //resolve to proper format
                  var resolvedName = UserNameResolver.FromDb(up.Username, extendedName, userType);
                  up.Username = resolvedName.Item1;
                  
                  permissions.Add(up);
               }
            }
         }

         return permissions.ToArray();
      }

      public bool UserHasPermission(string permissionName, string userName)
      {
         userName = FromInputUserName(userName);

         using (var command = DatabaseProvider.DbProviderFactory.CreateCommand())
         {
            InitializeUserHasPermission(command, userName, permissionName);
            return RunQueryScalar(command) != null;
         }
      }

      public bool UserHasRole(string permissionName, string userName)
      {
         userName = FromInputUserName(userName);

         using (var command = DatabaseProvider.DbProviderFactory.CreateCommand())
         {
            InitializeUserHasRole(command, userName, permissionName);
            return RunQueryScalar(command) != null;
         }
      }

      public string[] GetRolePermissions(string roleName)
      {

         List<string> permissions = new List<string>();

         using (var command = DatabaseProvider.DbProviderFactory.CreateCommand())
         {
            InitializeGetRolePermissions(command, roleName);
            using (IDataReader reader = DatabaseProvider.ExecuteReader(command))
            {
               while (reader.Read())
               {
                  permissions.Add(reader.GetColumnValue<string>("Permission"));
               }
            }
         }
         return permissions.ToArray();
      }

      public Role GetRole(string roleName)
      {

         List<Role> roles = new List<Role>();

         using (var command = DatabaseProvider.DbProviderFactory.CreateCommand())
         {
            InitializeGetRole(command, roleName);
            using (IDataReader reader = DatabaseProvider.ExecuteReader(command))
            {
               if (reader.Read())
               {
                  Role role = new Role();

                  role.Name = reader.GetColumnValue<string>("RoleName");
                  role.Description = reader.GetColumnValue<string>("Description");
                  role.AssignedPermissions = GetRolePermissions(role.Name);

                  return role;
               }
            }
         }
         return null;
      }

      public Role[] GetRoles()
      {

         List<Role> roles = new List<Role>();

         using (var command = DatabaseProvider.DbProviderFactory.CreateCommand())
         {
            InitializeGetRoles(command);
            using (IDataReader reader = DatabaseProvider.ExecuteReader(command))
            {
               while (reader.Read())
               {
                  Role role = new Role();

                  role.Name = reader.GetColumnValue<string>("RoleName");
                  role.Description = reader.GetColumnValue<string>("Description");
                  role.AssignedPermissions = GetRolePermissions(role.Name);

                  roles.Add(role);
               }
            }
         }
         return roles.ToArray();
      }

      public Role[] GetRolesLight()
      {

         List<Role> roles = new List<Role>();

         using (var command = DatabaseProvider.DbProviderFactory.CreateCommand())
         {
            InitializeGetRoles(command);
            using (IDataReader reader = DatabaseProvider.ExecuteReader(command))
            {
               while (reader.Read())
               {
                  Role role = new Role();

                  role.Name = reader.GetColumnValue<string>("RoleName");
                  role.Description = reader.GetColumnValue<string>("Description");
                  role.AssignedPermissions = null;

                  roles.Add(role);
               }
            }
         }
         return roles.ToArray();
      }

      public bool RoleExist(string roleName)
      {
         return GetRole(roleName) != null;
      }

      void AddRolePermission(string roleName, string AssignedPermission)
      {


         using (var command = DatabaseProvider.DbProviderFactory.CreateCommand())
         {
            InitializeAddRolePermission(command, roleName, AssignedPermission);
            DatabaseProvider.ExecuteNonQuery(command);
         }
      }

      public void AddRole(Role role)
      {
         if (RoleExist(role.Name))
         {
            throw new Exception("Role already exist.");
         }

         {


            using (var command = DatabaseProvider.DbProviderFactory.CreateCommand())
            {
               InitializeAddRole(command, role.Name, role.Description);
               DatabaseProvider.ExecuteNonQuery(command);
            }
         }

         foreach (string p in role.AssignedPermissions)
         {
            AddRolePermission(role.Name, p);
         }
      }

      public void UpdateRole(Role role)
      {
         if (!RoleExist(role.Name))
         {
            throw new Exception(@"Role doesn't exist.");
         }

         _DeleteRole(role.Name);
         DeleteRolePermissions(role.Name);
         AddRole(role);
      }

      public void DeleteRole(string roleName)
      {
         _DeleteRole(roleName);
         DeleteUserRole(roleName, null);
         DeleteRolePermissions(roleName);
      }

      void _DeleteRole(string roleName)
      {


         using (var command = DatabaseProvider.DbProviderFactory.CreateCommand())
         {
            InitializeDeleteRole(command, roleName);
            DatabaseProvider.ExecuteNonQuery(command);
         }
      }

      void DeleteRolePermissions(string roleName)
      {


         using (var command = DatabaseProvider.DbProviderFactory.CreateCommand())
         {
            InitializeDeleteRolePermissions(command, roleName);
            DatabaseProvider.ExecuteNonQuery(command);
         }
      }

      public string[] GetUserRoles(string userName)
      {
         userName = FromInputUserName(userName);

         List<string> permissions = new List<string>();

         using (var command = DatabaseProvider.DbProviderFactory.CreateCommand())
         {
            InitializeGetUserRoles(command, userName);
            using (IDataReader reader = DatabaseProvider.ExecuteReader(command))
            {
               while (reader.Read())
               {
                  permissions.Add(reader.GetColumnValue<string>("RoleName"));
               }
            }
         }
         return permissions.ToArray();
      }

      public void AddUserRole(string roleName, string userName)
      {
         userName = FromInputUserName(userName);

         if (!UserHasRole(roleName, userName))
         {


            using (var command = DatabaseProvider.DbProviderFactory.CreateCommand())
            {
               InitializeAddUserRole(command, userName, roleName);
               DatabaseProvider.ExecuteNonQuery(command);
            }
         }
      }

      public void DeleteUserRole(string roleName, string userName)
      {
         userName = FromInputUserName(userName);

         using (var command = DatabaseProvider.DbProviderFactory.CreateCommand())
         {
            InitializeDeleteUserRole(command, userName, roleName);
            DatabaseProvider.ExecuteNonQuery(command);
         }
      }
      #endregion
   }
}
