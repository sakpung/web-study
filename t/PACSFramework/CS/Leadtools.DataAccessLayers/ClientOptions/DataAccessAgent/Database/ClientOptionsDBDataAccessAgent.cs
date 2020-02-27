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
using Leadtools.Dicom.AddIn.Common;

namespace Leadtools.DataAccessLayers
{
   public abstract class ClientOptionsDataAccessAgent : IClientOptionsDataAccessAgent
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

      public ClientOptionsDataAccessAgent(string connectionString)
      {
         ConnectionString = connectionString;
      }                
      
      protected abstract Database CreateDatabaseProvider();
      protected abstract object RunQueryScalar(string query);

      protected abstract void InitializeGetDefaultOptions(DbCommand command);
      protected abstract void InitializeGetClientOptions(DbCommand command, string userName);      

      #region IClientOptionsDataAccessAgent Members

      public Dictionary<string, string> GetDefaultOptions()
      {
         DbCommand command;
         IDataReader reader;
         Dictionary<string, string> options = new Dictionary<string, string>();

         command = DatabaseProvider.DbProviderFactory.CreateCommand();
         InitializeGetDefaultOptions(command);
         reader = DatabaseProvider.ExecuteReader(command);
         while (reader.Read())
         {
            options.Add(reader.GetColumnValue<string>("Key"), reader.GetColumnValue<string>("Value"));
         }
         return options;
      }

      public Dictionary<string, string> GetClientOptions(string userName)
      {
         DbCommand command;
         IDataReader reader;
         Dictionary<string, string> defaultOptions = GetDefaultOptions();
         Dictionary<string, string> clientOptions = new Dictionary<string, string>();

         command = DatabaseProvider.DbProviderFactory.CreateCommand();
         InitializeGetClientOptions(command, userName);
         reader = DatabaseProvider.ExecuteReader(command);
         while (reader.Read())
         {
            clientOptions.Add(reader.GetColumnValue<string>("Key"), reader.GetColumnValue<string>("Value"));
         }

         //
         // Merge the options together to get client specific options
         //
         clientOptions = defaultOptions.MergeLeft(clientOptions);
         return clientOptions;
      }

      public void SetClientOptions(string userName, Dictionary<string, string> options)
      {

      }
      #endregion
   }
}
