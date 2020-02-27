// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Medical.DataAccessLayer.Configuration;
using Leadtools.Medical.UserManagementDataAccessLayer.Configuration;
using System.Data.Common;
using System.Data;
using System.Security;

namespace Leadtools.Medical.UserManagementDataAccessLayer.DataAccessAgent.Database
{
   public abstract class UserManagmentDBDataAccessAgent2 : UserManagementDBDataAccessAgent, IUserManagementDataAccessAgent2
   {
      #region Protected Abstract Methods

      protected abstract void InitializeAddUserExpiredCommand(DbCommand command, string userName, string password, DateTime? expireDate);
      protected abstract void InitializeIsUserPasswordExpiredCommand(DbCommand command, string userName);
      protected abstract void InitializeSetUserPasswordExpired(DbCommand command, string userName, string newPassword, DateTime? expireDate);
      protected abstract void InitializeAddToPasswordHistory(DbCommand command, string userName, string newPassword);
      protected abstract void InitializeGetHistoryCount(DbCommand command, string userName);
      protected abstract void InitializeGetUserPasswordHistory(DbCommand command, string userName);
      protected abstract void InitializeDeletePasswordHistory(DbCommand command, long id);
      protected abstract void InitializeIsPreviousPassword(DbCommand command, string userName, string password);
      protected abstract void InitializeGetUserPassword(DbCommand command, string userName);

      #endregion

      
      public UserManagmentDBDataAccessAgent2(string connectionString) : base(connectionString)
      {        
      }

      
      #region IUserManagementDataAccessAgent2 Members

      public virtual bool IsUserPasswordExpired(string username)
      {
         username = FromInputUserName(username);

         using (var command = DatabaseProvider.DbProviderFactory.CreateCommand())
         {
            object result;
            DateTime? expireDate = null;

            InitializeIsUserPasswordExpiredCommand(command, username);
            result = DatabaseProvider.ExecuteScalar(command);
            if (result == DBNull.Value)
               return false;

            if (result != null)
            {
               DateTime value;

               if (DateTime.TryParse(result.ToString(), out value))
               {
                  expireDate = value;
               }
            }
            return ReturnFromScalarResult(expireDate);
         }
      }

      public virtual bool SetUserPassword(string userName, SecureString newPassword, DateTime? expireDate, int historyCount)
      {
         userName = FromInputUserName(userName);

         string oldPassword = string.Empty;
         bool ret;

         if (historyCount > 0)
         {
            using (DbCommand c = DatabaseProvider.DbProviderFactory.CreateCommand())
            {
               object result;

               InitializeGetUserPassword(c, userName);
               result = DatabaseProvider.ExecuteScalar(c);
               oldPassword = result != null ? result.ToString() : string.Empty;
            }
         }

         if (expireDate.HasValue)
         {
            using (DbCommand command = DatabaseProvider.DbProviderFactory.CreateCommand())
            {
               InitializeSetUserPasswordExpired(command, userName, GetHashedPassword(newPassword), expireDate);
               ret = DatabaseProvider.ExecuteNonQuery(command) > 0;
            }
         }
         else
            ret = SetUserPassword(userName, newPassword);

         if (ret && historyCount > 0 && !string.IsNullOrEmpty(oldPassword))
         {
            AddToPasswordHistory(userName, oldPassword, historyCount);
         }
         return ret;
      }

      private bool AddToPasswordHistory(string userName, string newPassword, int historyCount)
      {
         using (DbCommand command = DatabaseProvider.DbProviderFactory.CreateCommand())
         {
            object result;

            InitializeGetHistoryCount(command, userName);
            result = DatabaseProvider.ExecuteScalar(command);
            if (result != null && Convert.ToInt32(result) >= historyCount)
            {
               int count = Convert.ToInt32(result) - historyCount;
               int itemCount = 0;

               InitializeGetUserPasswordHistory(command, userName);
               using (var reader = DatabaseProvider.ExecuteReader(command))
               {
                  while (reader.Read())
                  {
                     if (itemCount <= count)
                     {
                        using (DbCommand delCommand = DatabaseProvider.DbProviderFactory.CreateCommand())
                        {
                           InitializeDeletePasswordHistory(delCommand, reader.GetColumnValue<long>("Id"));
                           DatabaseProvider.ExecuteNonQuery(delCommand);
                        }
                     }
                     itemCount++;
                  }
               }
            }
            InitializeAddToPasswordHistory(command, userName, newPassword);
            return DatabaseProvider.ExecuteNonQuery(command) > 0;
         }
      }

      public virtual bool AddToPasswordHistory(string userName, SecureString newPassword, int historyCount)
      {
         userName = FromInputUserName(userName);

         using (DbCommand command = DatabaseProvider.DbProviderFactory.CreateCommand())
         {
            object result;

            InitializeGetHistoryCount(command, userName);
            result = DatabaseProvider.ExecuteScalar(command);
            if (result != null && Convert.ToInt32(result) >= historyCount)
            {
               int count = Convert.ToInt32(result) - historyCount;
               int itemCount = 0;

               InitializeGetUserPasswordHistory(command, userName);
               using (var reader = DatabaseProvider.ExecuteReader(command))
               {
                  while (reader.Read())
                  {
                     if (itemCount <= count)
                     {
                        using (DbCommand delCommand = DatabaseProvider.DbProviderFactory.CreateCommand())
                        {
                           InitializeDeletePasswordHistory(delCommand, reader.GetColumnValue<long>("Id"));
                           DatabaseProvider.ExecuteNonQuery(delCommand);
                        }
                     }
                     itemCount++;
                  }
               }
            }
            InitializeAddToPasswordHistory(command, userName, GetHashedPassword(newPassword));
            return DatabaseProvider.ExecuteNonQuery(command) > 0;
         }
      }

      public virtual bool IsPreviousPassword(string userName, SecureString password)
      {
         userName = FromInputUserName(userName);

         using (DbCommand command = DatabaseProvider.DbProviderFactory.CreateCommand())
         {
            object result;

            InitializeIsPreviousPassword(command, userName, GetHashedPassword(password));
            result = DatabaseProvider.ExecuteScalar(command);
            return ReturnFromScalarResult(result);
         }
      }

      public bool AddUser(string userName, SecureString password, DateTime? expireDate)
      {
         using (var command = DatabaseProvider.DbProviderFactory.CreateCommand())
         {
            InitializeAddUserExpiredCommand(command, userName, GetHashedPassword(password), expireDate);
            return (DatabaseProvider.ExecuteNonQuery(command) > 0);
         }
      }

      #endregion
   }
}
