// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************

#define USE_SMART_CARD

using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Security;
// using My.SmartCard;

#if (USE_SMART_CARD)
using System.Linq;
using Leadtools.Medical.DataAccessLayer;
using SmartCard;
#endif

namespace Leadtools.Medical.UserManagementDataAccessLayer.DataAccessAgent.Database
{
   public abstract class UserManagmentDBDataAccessAgent4 : UserManagmentDBDataAccessAgent3, IUserManagementDataAccessAgent4
   {
      #region Protected Abstract Methods

      protected abstract void InitializeGenericAddUserCommand(DbCommand command, string userName, string friendlyName, string password, DateTime? expireDate, string userType);
      protected abstract void InitializeGenericAddUserCommandExt(DbCommand command, string userName, string userExtendedName, string friendlyName, string password, DateTime? expireDate, string userType);
      
      public bool AddUser(string userName, string friendlyName, SecureString password, DateTime? expireDate, string userType)
      {
         Exception _e = null;

         try
         {
            using (var command = DatabaseProvider.DbProviderFactory.CreateCommand())
            {
               var resolvedName = UserNameResolver.ToDb(userName, userType);
               InitializeGenericAddUserCommandExt(command, resolvedName.Item1, resolvedName.Item2, friendlyName, GetHashedPassword(password), expireDate, resolvedName.Item3);
               return (DatabaseProvider.ExecuteNonQuery(command) > 0);
            }
         }
         catch (Exception e)
         {
            //might fail for older schema databases, we fall through for backward compatibility 
            _e = e;
         }

         try
         {
            using (var command = DatabaseProvider.DbProviderFactory.CreateCommand())
            {
               InitializeGenericAddUserCommand(command, userName, friendlyName, GetHashedPassword(password), expireDate, string.IsNullOrEmpty(userType) ? UserType.Classic : userType);
               return (DatabaseProvider.ExecuteNonQuery(command) > 0);
            }
         }
         catch (Exception e)
         {
            //might fail for older schema databases, we fall through for backward compatibility 
            _e = e;
         }

         if (string.IsNullOrEmpty(userType) || userType == UserType.Classic)
         {
            return base.AddUser(userName, friendlyName, password, expireDate, false);
         }
         else if (userType == UserType.SmartCard)
         {
            return base.AddUser(userName, friendlyName, password, expireDate, true);
         }
         else
         {
            throw _e;
         }
      }

      public string GetUserType(string userName)
      {
         if(IsValidateOnDomain(userName))
         {
            return UserType.ActiveDirectory;
         }
         
         return UserType.Classic;
      }

      #endregion


      public UserManagmentDBDataAccessAgent4 (string connectionString) : base(connectionString)
      {        
      }

      protected abstract void InitializeUserExistsCommand(DbCommand command, string userName);
      protected abstract void InitializeGetUsersCommand(DbCommand command, Dictionary<string,string> query);

      public virtual bool UserExists(string userName)
      {
         var mappedUserName = FromInputUserName(userName);

         using (var command = DatabaseProvider.DbProviderFactory.CreateCommand())
         {
            InitializeUserExistsCommand(command, userName);

            var result = DatabaseProvider.ExecuteScalar(command);

            //TODO: slight connection leak, scalar doesnt close the connection afterward
            return ReturnFromScalarResult(result);
         }
      }

      public virtual User[] GetUsers(Dictionary<string, string> query)
      {
         List<User> users;

         using (var selectCommand = DatabaseProvider.DbProviderFactory.CreateCommand())
         {
            users = new List<User>();

            InitializeGetUsersCommand(selectCommand, query);

            using (var reader = DatabaseProvider.ExecuteReader(selectCommand))
            {
               User user;

               while (reader.Read())
               {
                  user = new User(reader.GetString(0));

                  user.IsAdmin = (bool)reader["IsAdmin"];
                  user.Expires = reader.GetColumnValue<DateTime>("Expires");
                  user.UseCardReader = reader.GetColumnValue<bool>("UseCardReader");
                  user.FriendlyName = reader.GetColumnValue<string>("FriendlyName");
                  user.UserType = reader.GetColumnValueOrDefault<string>("UserType");
                  var extendedName = reader.GetColumnValueOrDefault<string>("ExtendedName");
                  //resolve to proper format
                  var resolvedName = UserNameResolver.FromDb(user.UserName, extendedName, user.UserType);
                  user.UserName = resolvedName.Item1;
                  user.UserType = resolvedName.Item2;
                  users.Add(user);
               }
            }
         }
         return users.ToArray();         
      }
   }   
}
