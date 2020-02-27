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
using Leadtools.Medical.UserManagementDataAccessLayer.DataAccessAgent;
using Leadtools.Medical.UserManagementDataAccessLayer.DataAccessAgent.Database;

namespace Leadtools.Medical.UserManagementDataAccessLayer
{
     
public class UserManagementSqlDataAccessAgent2 : UserManagementSqlDataAccessAgent
{
   public UserManagementSqlDataAccessAgent2(string connectionString) 
      : base ( connectionString ) 
      {
         
      }

   public override User[] GetUsers()
   {
      List<User> users;

      using (var selectCommand = DatabaseProvider.DbProviderFactory.CreateCommand())
      {
         users = new List<User>();

         InitializeGetUsersCommand(selectCommand);

         using (var reader = DatabaseProvider.ExecuteReader(selectCommand))
         {
            User user;

            while (reader.Read())
            {
               user = new User(reader.GetString(0));
                  
               user.IsAdmin = (bool)reader["IsAdmin"];
               user.Expires = reader.GetColumnValue<DateTime>("Expires");
#if LEADTOOLS_V19_OR_LATER
               user.UseCardReader = reader.GetColumnValue<bool>("UseCardReader");
               user.FriendlyName = reader.GetColumnValue<string>("FriendlyName");               
               user.UserType = reader.GetColumnValueOrDefault<string>("UserType");
               var extendedName = reader.GetColumnValueOrDefault<string>("ExtendedName");
               //resolve to proper format
               var resolvedName = UserNameResolver.FromDb(user.UserName, extendedName, user.UserType);
               user.UserName = resolvedName.Item1;
               user.UserType = resolvedName.Item2;
#endif
               users.Add(user);
            }
         }
      }
      return users.ToArray();
   }

      
   protected override void InitializeGetUsersCommand(DbCommand command)
   {
      command.CommandText = "Select * From Users";
   }
}

#if LEADTOOLS_V19_OR_LATER
   public class UserManagementSqlDataAccessAgent : UserManagmentDBDataAccessAgent4
#else
   public class UserManagementSqlDataAccessAgent : UserManagmentDBDataAccessAgent2
#endif
   {
      #region Public Methods
      
      public UserManagementSqlDataAccessAgent ( string connectionString ) 
      : base ( connectionString ) 
      {
         
      }

      #endregion
      
      #region Protected Methods
      
      protected override Microsoft.Practices.EnterpriseLibrary.Data.Database CreateDatabaseProvider ( )
      {
         return new SqlDatabase ( ConnectionString ) ;
      }      
      
      protected override void InitializeGetUsersCommand ( DbCommand command ) 
      {
         command.CommandText = "Select * From Users" ;
      }
      
      protected override void InitializeIsUserValidCommand 
      ( 
         DbCommand command, 
         string userName, 
         string password 
      ) 
      {
         command.CommandText = "Select * FROM Users Where UserName=@userName AND Password = @password";
         command.Param("@userName", userName);
         command.Param("@password", password);
      }
      
      protected override void InitializeAddUserCommand
      ( 
         DbCommand command,
         string userName, 
         string password, 
         bool isAdmin
      ) 
      {
         var admin = (isAdmin == true) ? 1 : 0;
         command.CommandText = $"INSERT INTO Users ( UserName, Password, IsAdmin ) Values ( @userName, '{password}', {admin})";
         command.Param("@userName", userName);
      }

#if(LEADTOOLS_V175_OR_LATER)
      
      protected override void InitializeAddUserExpiredCommand(DbCommand command, string userName, string password, DateTime? expireDate)
      {
         if (!expireDate.HasValue)
         {
            InitializeAddUserCommand(command, userName, password, false);
         }
         else
         {
            command.CommandText = $"INSERT INTO Users ( UserName, Password, Expires ) Values ( @UserName, '{password}', @expire )";
            command.Param("@expire", expireDate);
            command.Param("@userName", userName);
         }
      }
#if LEADTOOLS_V19_OR_LATER
      protected override void InitializeAddUserCardReaderCommand(DbCommand command, string userName, string friendlyName, string password, DateTime? expireDate, bool useCardReader)
      {
         string updatedPassword = useCardReader ? string.Empty : password;

         if (!expireDate.HasValue)
         {
            var reader = useCardReader ? 1 : 0;
            command.CommandText = $"INSERT INTO Users ( UserName, FriendlyName, Password, UseCardReader ) Values (  @UserName, '{friendlyName}', '{updatedPassword}', '{reader }')";
            command.Param("@userName", userName);
         }
         else
         {
            var reader = useCardReader ? 1 : 0;
            command.CommandText = $"INSERT INTO Users ( UserName, FriendlyName, Password, Expires, UseCardReader ) Values ( @userName, '{friendlyName}', '{updatedPassword}', '{reader}', @expire)";
            command.Param("@expire", expireDate);
            command.Param("@userName", userName);
         }
      }

      protected override void InitializeGenericAddUserCommand(DbCommand command, string userName, string friendlyName, string password, DateTime? expireDate, string userType)
      {
         if (!expireDate.HasValue)
         {
            command.CommandText = $"INSERT INTO Users ( UserName, FriendlyName, Password, UserType ) Values ( @userName, '{friendlyName}', '{password}',  '{userType}')";
            command.Param("@userName", userName);
         }
         else
         {
            command.CommandText = $"INSERT INTO Users ( UserName, FriendlyName, Password, Expires, UserType ) Values ( @userName, '{friendlyName}', '{password}', '{userType}', @expire)";
            command.Param("@expire", expireDate);
            command.Param("@userName", userName);
         }
      }
      
      protected override void InitializeGenericAddUserCommandExt(DbCommand command, string userName, string userExtendedName, string friendlyName, string password, DateTime? expireDate, string userType)
      {
         command.CommandText = "INSERT INTO Users ( UserName, ExtendedName, FriendlyName, Password, UserType, Expires ) Values ( @UserName, @ExtendedName, @FriendlyName, @Password, @UserType, @Expires)";
         command.Param( "@UserName", userName);
         command.Param( "@ExtendedName", userExtendedName);
         command.Param( "@FriendlyName", friendlyName);
         command.Param( "@Password", password);
         command.Param( "@UserType", userType);
         command.Param( "@Expires", expireDate);
      }
#endif
      protected override void InitializeIsUserPasswordExpiredCommand(DbCommand command, string userName)
      {
         command.CommandText = "SELECT Expires FROM Users WHERE UserName=@userName";
         command.Param("@userName", userName);
      }

      protected override void InitializeSetUserPasswordExpired(DbCommand command, string userName, string newPassword, DateTime? expireDate)
      {
         command.CommandText = $"UPDATE Users SET Password='{newPassword}', Expires=@expire WHERE UserName=@userName";
         command.Param("@expire", expireDate);
         command.Param("@userName", userName);
      }

      protected override void InitializeAddToPasswordHistory(DbCommand command, string userName, string password)
      {
         command.CommandText = $"INSERT INTO PasswordHistory ( [User], Password, AddDate ) Values ( @userName, '{password}', @adddate )";
         command.Param("@adddate",DateTime.Now);
         command.Param("@userName", userName);
      }

      protected override void InitializeGetHistoryCount(DbCommand command, string userName)
      {
         command.CommandText = string.Format("SELECT COUNT(*) FROM PasswordHistory WHERE [User]=@userName");
         command.Param("@userName", userName);
      }

      protected override void InitializeGetUserPasswordHistory(DbCommand command, string userName)
      {
         command.CommandText = string.Format("SELECT * FROM PasswordHistory WHERE [User] = @userName ORDER BY AddDate ASC");
         command.Param("@userName", userName);
      }

      protected override void InitializeDeletePasswordHistory(DbCommand command, long id)
      {
         command.CommandText = $"DELETE FROM PasswordHistory WHERE Id = {id}";
      }

      protected override void InitializeIsPreviousPassword(DbCommand command, string userName, string password)
      {
         command.CommandText = $"SELECT [User] FROM PasswordHistory WHERE [User] = @userName AND Password='{password}'" ;
         command.Param("@userName", userName);
      }

      protected override void InitializeGetUserPassword(DbCommand command, string userName)
      {
         command.CommandText = "SELECT Password FROM Users WHERE UserName = @userName";
         command.Param("@userName", userName);
      }

#endif
      
      protected override void InitializeIsAdminCommand ( DbCommand command, string userName ) 
      {
         command.CommandText = "Select IsAdmin From Users WHERE UserName = @userName" ;
         command.Param("@userName", userName);
      }
      protected override void InitializeIsValidateOnDomainCommand( DbCommand command, string userName ) 
      {
         command.CommandText = "Select UserType From Users WHERE UserName = @userName";
         command.Param("@userName", userName);
      }
      protected override void InitializeRemoveUserCommand  
      ( 
         DbCommand command,
         string userName 
      ) 
      {
         command.CommandText = "DELETE FROM Users WHERE UserName=@userName";
         command.Param("@userName", userName);
      }
      
      protected override void InitializeSetAdminUserCommand 
      ( 
         DbCommand command,
         string userName, 
         bool isAdmin
      ) 
      {
         var admin = (isAdmin) ? 1 : 0;
         command.CommandText = $"UPDATE Users SET IsAdmin={admin} WHERE UserName=@userName";
         command.Param("@userName", userName);
      }
      
      protected override void InitializeSetUserPasswordCommand 
      ( 
         DbCommand command,
         string userName, 
         string newPassword 
      )
      {
         command.CommandText = $"UPDATE Users SET Password='{newPassword}' WHERE UserName=@userName";
         command.Param("@userName", userName);
      }

      protected override void InitializeUserExistsCommand(DbCommand command, string userName)
      {
         command.CommandText = "Select UserName FROM Users Where UserName=@userName";
         command.Param("@userName", userName);
      }

      protected override void InitializeGetUsersCommand(DbCommand command, Dictionary<string, string> query)
      {
         StringBuilder sb = new StringBuilder();

         sb.Append("Select * From Users ");

         if (query.Keys.Count > 0)
         {
            sb.Append("Where ");
            foreach (var kv in query)
            {
               sb.Append($"{kv.Key}");
               sb.Append($"=");
               sb.Append($"@{kv.Key}");
               sb.Append(" AND ");
            }
            sb.Length -= 5;
         }

         command.CommandText = sb.ToString();

         if (query.Keys.Count > 0)
         {
            foreach (var kv in query)
            {
               command.Param($"@{kv.Key}", kv.Value);
            }
         }         
      }
      #endregion
   }
}
