// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Data.Common;

#if DNXCORE50
using Leadtools.Data;
using Leadtools.Practices.EnterpriseLibrary.Data;
#else
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
#endif

namespace Leadtools.Medical.OptionsDataAccessLayer
{
   public abstract class OptionsDataAccessAgent : IOptionsDataAccessAgent
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

      public OptionsDataAccessAgent(string connectionString)
      {
         ConnectionString = connectionString;
      }

      protected abstract Database CreateDatabaseProvider();
      protected abstract object RunQueryScalar(string query);
      protected abstract void InitializeSetOption(DbCommand command, string key, string value);
      protected abstract void InitializeGetOption(DbCommand command, string key);
      protected abstract void InitializeOptionExits(DbCommand command, string key);
      protected abstract void InitializeUpdateOption(DbCommand command, string key, string value);
      protected abstract void InitializeDeleteOption(DbCommand command, string key);
      protected abstract void InitializeGetDefaultOptions(DbCommand command);
      protected abstract void InitializeSaveDefaultOption(DbCommand command, string key, string value);
      protected abstract void InitializeGetUserOptions(DbCommand command, string userName);
      protected abstract void InitializeSetUserOption(DbCommand command, string userName, string name, string value);
      protected abstract void InitializeDeleteUserOption(DbCommand command, string userName);

      protected abstract void InitializeGetRoleOptions(DbCommand command, string role);
      protected abstract void InitializeGetRoleOption(DbCommand command, string role, string optionName);
      protected abstract void InitializeSetRoleOption(DbCommand command, string role, string key, string value);

      #region IOptionsDataAccessAgent Members

      public T Get<T>(string key, T defaultValue, params Type[] otherTypes)
      {
         if (!OptionExits(key))
         {
            return defaultValue;
         }
         else
         {
            string xml;
            object o;

            using (var command = DatabaseProvider.DbProviderFactory.CreateCommand())
            {
               InitializeGetOption(command, key);
               o = DatabaseProvider.ExecuteScalar(command);
               if (o == null)
               {
                  return defaultValue;
               }
               xml = o.ToString();
               return xml.FromXml<T>(otherTypes);
            }
         }
      }

      public bool OptionExits(string key)
      {
         using (var command = DatabaseProvider.DbProviderFactory.CreateCommand())
         {
            InitializeOptionExits(command, key);
            return RunQueryScalar(command.CommandText) != null;
         }
      }

      public void Set<T>(string key, T value, params Type[] otherTypes)
      {
         string xml = value == null ? string.Empty : value.ToXml(otherTypes);

         using (var command = DatabaseProvider.DbProviderFactory.CreateCommand())
         {
            if (!OptionExits(key))
            {
               InitializeSetOption(command, key, xml);
            }
            else
            {
               InitializeUpdateOption(command, key, xml);
            }
            DatabaseProvider.ExecuteNonQuery(command);
         }
      }

      public void DeleteOption(string key)
      {
         using (var command = DatabaseProvider.DbProviderFactory.CreateCommand())
         {

            if (OptionExits(key))
            {
               InitializeDeleteOption(command, key);
            }

            DatabaseProvider.ExecuteNonQuery(command);
         }
      }

      public Dictionary<string, string> GetDefaultOptions()
      {
         using (var command = DatabaseProvider.DbProviderFactory.CreateCommand())
         {
            Dictionary<string, string> options = new Dictionary<string, string>();

            InitializeGetDefaultOptions(command);

            using (var reader = DatabaseProvider.ExecuteReader(command))
            {
               while (reader.Read())
               {
                  options.Add(reader.GetColumnValue<string>("Key"), reader.GetColumnValue<string>("Value"));
               }
            }
            return options;
         }
      }

      public void SaveDefaultOptions(Dictionary<string, string> options)
      {
         using (var command = DatabaseProvider.DbProviderFactory.CreateCommand())
         {

            foreach (KeyValuePair<string, string> option in options)
            {
               InitializeSaveDefaultOption(command, option.Key, option.Value);
               DatabaseProvider.ExecuteNonQuery(command);
            }
         }
      }

      public Dictionary<string, string> GetUserOptions(string userName)
      {
         using (var command = DatabaseProvider.DbProviderFactory.CreateCommand())
         {

            Dictionary<string, string> defaultOptions = GetDefaultOptions();
            Dictionary<string, string> userOptions = new Dictionary<string, string>();

            InitializeGetUserOptions(command, userName);
            using (var reader = DatabaseProvider.ExecuteReader(command))
            {
               while (reader.Read())
               {
                  userOptions.Add(reader.GetColumnValue<string>("Key"), reader.GetColumnValue<string>("Value"));
               }
            }

            userOptions = defaultOptions.MergeLeft(userOptions);
            return userOptions;
         }
      }

      public void SetUserOptions(string userName, Dictionary<string, string> options)
      {
         using (var command = DatabaseProvider.DbProviderFactory.CreateCommand())
         {
            foreach (KeyValuePair<string, string> option in options)
            {
               InitializeSetUserOption(command, userName, option.Key, option.Value);
               DatabaseProvider.ExecuteNonQuery(command);
            }
         }
      }
      public void DeleteUserOptions(string userName)
      {
         using (var command = DatabaseProvider.DbProviderFactory.CreateCommand())
         {
            InitializeDeleteUserOption(command, userName);
            DatabaseProvider.ExecuteNonQuery(command);
         }
      }
      public Dictionary<string, string> GetRoleOptions(string role)
      {
         throw new NotImplementedException();
      }

      public string GetRoleOption(string role, string optionName)
      {
         using (var command = DatabaseProvider.DbProviderFactory.CreateCommand())
         {

            InitializeGetRoleOption(command, role, optionName);
            return DatabaseProvider.ExecuteScalar(command) as string;
         }
      }

      public void SaveRoleOptions(string role, Dictionary<string, string> options)
      {
         using (var command = DatabaseProvider.DbProviderFactory.CreateCommand())
         {

            foreach (KeyValuePair<string, string> option in options)
            {
               InitializeSetRoleOption(command, role, option.Key, option.Value);
               DatabaseProvider.ExecuteNonQuery(command);
            }
         }
      }

      #endregion
   }
}
