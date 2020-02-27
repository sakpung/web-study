// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Data.Common;
using System.Data.SqlClient;

#if DNXCORE50
using Leadtools.Data;
using Leadtools.Practices.EnterpriseLibrary.Data;
using Leadtools.Practices.EnterpriseLibrary.Data.Sql;
#else
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
#endif

namespace Leadtools.Medical.OptionsDataAccessLayer
{
   public class OptionsSqlDataAccessAgent : OptionsDataAccessAgent
   {
      public OptionsSqlDataAccessAgent(string connectionString) 
      : base ( connectionString ) 
      {
         
      }      

      protected override Database CreateDatabaseProvider()
      {
         return new SqlDatabase(ConnectionString);
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

      protected override void InitializeSetOption(DbCommand command, string key, string value)
      {
         command.CommandText = string.Format("INSERT INTO Options([Key],Value) VALUES('{0}','{1}')",key,value);
      }

      protected override void InitializeGetOption(DbCommand command, string key)
      {
         command.CommandText = string.Format("SELECT Value FROM Options WHERE [Key]='{0}'", key);
      }

      protected override void InitializeOptionExits(DbCommand command, string key)
      {
         command.CommandText = string.Format("SELECT [Key] FROM Options WHERE [Key] = '{0}'", key);
      }

      protected override void InitializeUpdateOption(DbCommand command, string key, string value)
      {
         command.CommandText = string.Format("UPDATE Options SET Value='{0}' WHERE [Key] = '{1}'", value, key);
      }

      protected override void InitializeDeleteOption(DbCommand command, string key)
      {
         command.CommandText = string.Format( "DELETE FROM Options WHERE [Key] = '{0}'", key ) ;
      }

      protected override void InitializeGetDefaultOptions(DbCommand command)
      {
          //
          // We are excluding options that are not editable in the web client
          //
          command.CommandText = "SELECT * FROM Options WHERE [Key]<>'DatabaseManagerOptions' AND [Key]<>'ClientConfigurationOptions' AND [Key]<>'PasswordOptions' AND [Key]<>'LastUser' AND [Key]<>'PresentationContextList' AND [Key]<>'StorageServerInformation' AND [Key]<>'NextLogDate'";
      }

       protected override void InitializeSaveDefaultOption(DbCommand command, string key, string value)
       {
           command.CommandText = string.Format(@"UPDATE Options SET Value='{1}' WHERE [Key] = '{0}'
                                               IF @@ROWCOUNT = 0
                                               BEGIN
	                                             INSERT INTO Options([Key],Value) VALUES('{0}','{1}')
                                               END", key, value);
       }

      protected override void InitializeGetUserOptions(DbCommand command, string userName)
      {
          command.CommandText = string.Format("SELECT * FROM UserOptions WHERE UserName='{0}'", userName);
      }

      protected override void InitializeGetRoleOptions(DbCommand command, string role)
      {
          command.CommandText = string.Format("SELECT * FROM RoleOptions WHERE Role='{0}' AND IsWebOption=1", role);
      }

      protected override void InitializeSetUserOption(DbCommand command, string userName, string name, string value)
      {
          command.CommandText =string.Format(@"UPDATE UserOptions SET Value='{2}' WHERE [Key] = '{1}' AND UserName='{0}'
                                               IF @@ROWCOUNT = 0
                                               BEGIN
	                                             INSERT INTO UserOptions(UserName,[Key],Value) VALUES('{0}','{1}','{2}')
                                               END", userName, name, value);
      }
      protected override void InitializeDeleteUserOption(DbCommand command, string userName)
      {
         command.CommandText = $"DELETE FROM UserOptions WHERE UserName='{userName}'";
      }

      protected override void InitializeGetRoleOption(DbCommand command, string role, string optionName)
      {
          command.CommandText = string.Format("SELECT Value FROM RoleOptions WHERE [Key]='{0}' AND RoleName='{1}'", optionName, role);
      }

      protected override void InitializeSetRoleOption(DbCommand command, string role, string key, string value)
      {
          command.CommandText = string.Format(@"UPDATE RoleOptions SET Value='{2}' WHERE [Key] = '{1}' AND RoleName='{0}'
                                               IF @@ROWCOUNT = 0
                                               BEGIN
	                                             INSERT INTO RoleOptions(RoleName,[Key],Value) VALUES('{0}','{1}','{2}')
                                               END", role, key, value);
      }
   }
}
