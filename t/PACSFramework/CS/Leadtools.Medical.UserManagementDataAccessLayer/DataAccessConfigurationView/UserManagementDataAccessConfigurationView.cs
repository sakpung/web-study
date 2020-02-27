// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Medical.DataAccessLayer.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;

namespace Leadtools.Medical.UserManagementDataAccessLayer.Configuration
{
   public class UserManagementDataAccessConfigurationView : DataAccessConfigurationView
   {
      private static readonly DataAccessMapping defaultSqlMapping   = new DataAccessMapping(DataAccessMapping.DefaultSqlProviderName, typeof(UserManagementSqlDataAccessAgent), null);
      private static readonly DataAccessMapping defaultSqlCeMapping = new DataAccessMapping(DataAccessMapping.DefaultSqlCe3_5ProviderName, typeof(UserManagementSqlCeDataAccessAgent), null);

      public UserManagementDataAccessConfigurationView ( )
      : base ( )
      {}
      
      public UserManagementDataAccessConfigurationView (System.Configuration.Configuration configuration, string productName, string serviceName)
      : base (configuration, productName, serviceName)
      {}

      //public UserManagementDataAccessConfigurationView ( IConfigurationSource configurationSource )
      //: base ( configurationSource )
      //{}
      
      public override string DataAccessSettingsSectionName
      {
         get 
         { 
#if LTV17_CONFIG
            return "userManagementConfigurationSample" ; 
#else
            return "userManagementConfigurationSample175" ; 
#endif
         }
      }

      protected override DataAccessMapping GetDefaultMapping ( string name, string dbProviderName )
      {
         // try to short circuit by default name
         if (DataAccessMapping.DefaultSqlProviderName.Equals(dbProviderName))
            return defaultSqlMapping;


         if (DataAccessMapping.DefaultSqlCe3_5ProviderName.Equals(dbProviderName))
            return defaultSqlCeMapping;
         
         return null;
      }
   }

   public class UserManagementDataAccessConfigurationView2 : DataAccessConfigurationView
   {
      private static readonly DataAccessMapping defaultSqlMapping = new DataAccessMapping(DataAccessMapping.DefaultSqlProviderName, typeof(UserManagementSqlDataAccessAgent2), null);
      private static readonly DataAccessMapping defaultSqlCeMapping = new DataAccessMapping(DataAccessMapping.DefaultSqlCe3_5ProviderName, typeof(UserManagementSqlCeDataAccessAgent2), null);

      public UserManagementDataAccessConfigurationView2()
         : base()
      { }

      public UserManagementDataAccessConfigurationView2(System.Configuration.Configuration configuration, string productName, string serviceName)
         : base(configuration, productName, serviceName)
      { }

      //public UserManagementDataAccessConfigurationView2 ( IConfigurationSource configurationSource )
      //: base ( configurationSource )
      //{}

      public override string DataAccessSettingsSectionName
      {
         get
         {
            return "userManagementConfigurationSample175";
         }
      }

      protected override DataAccessMapping GetDefaultMapping(string name, string dbProviderName)
      {
         // try to short circuit by default name
         if (DataAccessMapping.DefaultSqlProviderName.Equals(dbProviderName))
            return defaultSqlMapping;


         if (DataAccessMapping.DefaultSqlCe3_5ProviderName.Equals(dbProviderName))
            return defaultSqlCeMapping;

         return null;
      }
   }
}
