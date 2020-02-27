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
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.SqlClient;
using Leadtools.Medical.PermissionsManagement.DataAccessLayer.DataAccessAgent;

namespace Leadtools.Medical.PermissionsManagement.DataAccessLayer
{

   public class AePermissionManagementSqlDataAccessAgent : PermissionManagementSqlDataAccessAgent
   {
   public AePermissionManagementSqlDataAccessAgent(string connectionString) 
      : base ( connectionString, "AePermissionsList", "AePermissions" ) 
      {
      } 
   }
   
   
   public class PermissionManagementSqlDataAccessAgent : PermissionManagementDBDataAccessAgent
   {
      #region Public Methods

      public PermissionManagementSqlDataAccessAgent(string connectionString) 
      : base ( connectionString ) 
      {
         
      }
      
      public PermissionManagementSqlDataAccessAgent(string connectionString, string permissionListTableName, string userPermissionsTableName) 
      : base ( connectionString ) 
      {
         _permissionListTableName = permissionListTableName;
         _userPermissionsTableName = userPermissionsTableName;
      }

      protected string _permissionListTableName = "UserPermissionsList"; //"Permissions";
      protected string _userPermissionsTableName = "UserPermissions";   //"UserPermissions";

      protected string _rolesListTableName = "RolesList";
      protected string _rolePermissionsTableName = "RolesPermissions";
      protected string _userRolesTableName = "UserRoles";   

      public string PermissionListTableName
      {
         get { return _permissionListTableName; }
         set { _permissionListTableName = value; }
      }

      public string UserPermissionsTableName
      {
         get { return _userPermissionsTableName; }
         set { _userPermissionsTableName = value; }
      }
      public string RolesListTableName {
         get { return _rolesListTableName ; }
         set { _rolesListTableName = value; }
      }
      public string RolePermissionsTableName {
         get { return _rolePermissionsTableName ; }
         set { _rolePermissionsTableName = value; }
      }
      public string UserRolesTableName {
         get { return _userRolesTableName; }
         set { _userRolesTableName = value; }
      }

      #endregion
      
      #region Protected Methods
      
      protected override Microsoft.Practices.EnterpriseLibrary.Data.Database CreateDatabaseProvider ( )
      {
         return new SqlDatabase ( ConnectionString ) ;
      }

      protected override object RunQueryScalar(DbCommand command)
      {
         using (SqlConnection connection = new SqlConnection(ConnectionString))
         {
            command.Connection = connection;
            connection.Open();
            return command.ExecuteScalar();
         }
      }
      protected override object RunQueryScalar(string query)
      {
         try
         {
            // Create a connection, a command and an adapter then fill a dataset and return it
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
               using (SqlCommand command = new SqlCommand(query, connection))
               {
                  connection.Open();
                  return command.ExecuteScalar();
               }
            }
         }
         catch (Exception exception)
         {
            throw exception;
         }
      }

      protected override void InitializeGetPermissions(DbCommand command)
      {
         command.CommandText = "SELECT * FROM " + PermissionListTableName;         
      }

      protected override void InitializeGetRoles(DbCommand command)
      {
         command.CommandText = $"SELECT * FROM {RolesListTableName}";
      }

      protected override void InitializeGetRole(DbCommand command, string roleName)
      {
         var names = roleName.Replace("'", "''");
         command.CommandText = $"SELECT * FROM {RolesListTableName} WHERE RoleName = '{names}'";
      }

      protected override void InitializeGetUserPermissions(DbCommand command, string userName)
      {
         command.CommandText = $"SELECT * FROM {UserPermissionsTableName} WHERE UserName = @userName";
         command.Param("@userName", userName);
      }

      protected override void InitializeGetUserRoles(DbCommand command, string userName)
      {
         command.CommandText = $"SELECT * FROM {UserRolesTableName} WHERE UserName = @userName";
         command.Param("@userName", userName);
      }

      protected override void InitializeGetRolePermissions(DbCommand command, string roleName)
      {
         var role = roleName.Replace("'", "''");
         command.CommandText = $"SELECT * FROM {RolePermissionsTableName} WHERE RoleName = '{role}'";
      }

      protected override void InitializeAddUserPermission(DbCommand command, string userName, string permission)
      {
         command.CommandText = $"INSERT INTO {UserPermissionsTableName} (UserName,Permission) VALUES(@userName, @permission)";
         command.Param("@userName", userName);
         command.Param("@permission", permission);
      }

      protected override void InitializeAddUserRole(DbCommand command, string userName, string roleName)
      {
         command.CommandText = $"INSERT INTO {UserRolesTableName} (UserName,RoleName) VALUES(@userName,@roleName)";
         command.Param("@userName", userName);
         command.Param("@roleName", roleName.Replace("'", "''"));
      }

      protected override void InitializeAddRole(DbCommand command, string roleName, string description)
      {
         var name = roleName.Replace("'", "''");
         command.CommandText = $"INSERT INTO {RolesListTableName} (RoleName,Description) VALUES('{name}','{description}')";
      }

      protected override void InitializeAddRolePermission(DbCommand command, string roleName, string permission)
      {
         var name = roleName.Replace("'", "''");
         command.CommandText = $"INSERT INTO {RolePermissionsTableName} (RoleName,Permission) VALUES('{name}','{permission}')";
      }

      protected override void InitializeDeleteUserPermission(DbCommand command, string userName, string permission)
      {
         if (string.IsNullOrEmpty(userName) && string.IsNullOrEmpty(permission))
         {
            command.CommandText = $"DELETE FROM {UserPermissionsTableName}";
         }
         else if (string.IsNullOrEmpty(permission))
         {
            command.CommandText = $"DELETE FROM {UserPermissionsTableName} WHERE UserName = @userName";
            command.Param("@userName", userName);
         }
         else
         {
            command.CommandText = $"DELETE FROM {UserPermissionsTableName} WHERE UserName = @userName AND Permission = @permission";
            command.Param("@userName", userName);
            command.Param("@permission", permission);
         }
      }

      protected override void InitializeDeleteUserRole(DbCommand command, string userName, string roleName)
      {
         if (string.IsNullOrEmpty(userName) && string.IsNullOrEmpty(roleName))
         {
            command.CommandText = $"DELETE FROM {UserPermissionsTableName}";
         }
         else if (string.IsNullOrEmpty(roleName))
         {
            command.CommandText = $"DELETE FROM {UserRolesTableName} WHERE UserName = '@userName'";
            command.Param("@userName", userName);
         }
         else if (string.IsNullOrEmpty(userName))
         {
            var role = roleName.Replace("'", "''");
            command.CommandText = $"DELETE FROM {UserRolesTableName} WHERE RoleName = '{role}'";
         }
         else
         {
            command.CommandText = $"DELETE FROM {UserRolesTableName} WHERE UserName = @UserName AND RoleName = @roleName";
            command.Param("@userName", userName);
            command.Param("@roleName", roleName.Replace("'", "''"));
         }
      }

      protected override void InitializeDeleteRole(DbCommand command, string roleName)
      {
         var role = roleName.Replace("'", "''");
         command.CommandText = $"DELETE FROM {RolesListTableName} WHERE RoleName = '{role}'";
      }

      protected override void InitializeDeleteRolePermissions(DbCommand command, string roleName)
      {
         var role = roleName.Replace("'", "''");
         command.CommandText = $"DELETE FROM {RolePermissionsTableName} WHERE RoleName = '{role}'";
      }

      protected override void InitializeGetAllUserPermissions(DbCommand command)
      {
         command.CommandText = $"SELECT * FROM {UserPermissionsTableName}";
      }

      protected override void InitializeUserHasPermission(DbCommand command, string userName, string permission)
      {
         command.CommandText = $"SELECT Permission FROM {UserPermissionsTableName} WHERE UserName = @userName AND Permission = @permission";
         command.Param("@userName", userName);
         command.Param("@permission", permission);
      }

      protected override void InitializeUserHasRole(DbCommand command, string userName, string roleName)
      {
         command.CommandText = $"SELECT roleName FROM {UserRolesTableName} WHERE UserName = @userName AND roleName = @roleName";
         command.Param("@userName", userName);
         command.Param("@roleName", roleName.Replace("'", "''"));
      }
      
      #endregion
   }
}
