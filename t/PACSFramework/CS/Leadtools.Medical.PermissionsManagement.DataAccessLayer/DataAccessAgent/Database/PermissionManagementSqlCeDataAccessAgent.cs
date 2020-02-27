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
using Microsoft.Practices.EnterpriseLibrary.Data.SqlCe;
using System.Data.SqlServerCe;

namespace Leadtools.Medical.PermissionsManagement.DataAccessLayer
{
   public class PermissionManagementSqlCeDataAccessAgent : PermissionManagementSqlDataAccessAgent 
   {
      #region Public Methods

      public PermissionManagementSqlCeDataAccessAgent(string connectionString) 
      : base ( connectionString ) 
      {
         
      }
      
      public PermissionManagementSqlCeDataAccessAgent(string connectionString, string permissionListTableName, string userPermissionsTableName) 
      : base ( connectionString, permissionListTableName, userPermissionsTableName)
      {
         
      }

      #endregion
      
      #region Protected Methods
      
      protected override Microsoft.Practices.EnterpriseLibrary.Data.Database CreateDatabaseProvider ( )
      {
         return new SqlCeDatabase ( ConnectionString ) ;
      }

      protected override object RunQueryScalar(DbCommand command)
      {
         using (SqlCeConnection connection = new SqlCeConnection(ConnectionString))
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
            using (SqlCeConnection connection = new SqlCeConnection(ConnectionString))
            {
               using (SqlCeCommand command = new SqlCeCommand(query, connection))
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
      
      #endregion
   }
   
   public class AePermissionManagementSqlCeDataAccessAgent : PermissionManagementSqlCeDataAccessAgent
   {
      public AePermissionManagementSqlCeDataAccessAgent(string connectionString) 
      : base ( connectionString, "AePermissionsList", "AePermissions") 
      {
      } 
      
   }
}
