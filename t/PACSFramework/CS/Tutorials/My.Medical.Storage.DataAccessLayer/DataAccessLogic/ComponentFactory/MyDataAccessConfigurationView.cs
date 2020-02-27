// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Medical.DataAccessLayer.Configuration;
using Leadtools.Medical.Storage.DataAccessLayer;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;

namespace My.Medical.Storage.DataAccessLayer
{
   /// <summary>
   /// Helper class used to create the data access agent. 
   /// Internally stores the type that implements IStorageDataAccessAgent (MyStorageSqlDbDataAccessAgent), so it can be created dynamically.  
   /// Associates a DataAccessLayer with a DataAccessAgent and a configuration file (GlobalPacs.config).  
   /// Defines the DataAccessLayer section name (used in GlobalPacs.config).  
   /// GlobalPacs.config in turn associates the DataAccessLayer section name with a connection string.  
   /// </summary>
   public class MyStorageDataAccessConfigurationView  : DataAccessConfigurationView
   {
      private static readonly DataAccessMapping defaultSqlMapping   = new DataAccessMapping(DataAccessMapping.DefaultSqlProviderName, typeof(MyStorageSqlDbDataAccessAgent), typeof(StorageCatalog));
      // private static readonly DataAccessMapping defaultSqlCeMapping = new DataAccessMapping(DataAccessMapping.DefaultSqlCe3_5ProviderName, typeof(StorageSqlCeDataAccessAgent), typeof(StorageCatalog));

      public MyStorageDataAccessConfigurationView ( )
      : base ( )
      {}

      public MyStorageDataAccessConfigurationView ( IConfigurationSource configurationSource )
      : base ( configurationSource )
      {}

      public MyStorageDataAccessConfigurationView(System.Configuration.Configuration configuration, string productName, string serviceName)
         : base(configuration, productName, serviceName)
      { }
   
      protected override DataAccessMapping GetDefaultMapping(string name, string dbProviderName)
      {
         // try to short circuit by default name
         if (DataAccessMapping.DefaultSqlProviderName.Equals(dbProviderName))
            return defaultSqlMapping;


         //if (DataAccessMapping.DefaultSqlCe3_5ProviderName.Equals(dbProviderName))
         //   return defaultSqlCeMapping;
         
         return null;
      }

      public override string DataAccessSettingsSectionName
      {
         get 
         { 
            return "myStorageDataAccessConfiguration175" ; 
         }
      }
   }
}
