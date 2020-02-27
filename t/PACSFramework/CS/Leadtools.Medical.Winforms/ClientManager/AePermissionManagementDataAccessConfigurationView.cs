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
using Leadtools.Medical.PermissionsManagement.DataAccessLayer;

namespace Leadtools.Medical.Winforms.DataAccessLayer.Configuration
{
   public class AePermissionManagementDataAccessConfigurationView : DataAccessConfigurationView
   {
      private static readonly DataAccessMapping defaultSqlMapping = new DataAccessMapping(DataAccessMapping.DefaultSqlProviderName, typeof(AePermissionManagementSqlDataAccessAgent), null);
      private static readonly DataAccessMapping defaultSqlCeMapping = new DataAccessMapping(DataAccessMapping.DefaultSqlCe3_5ProviderName, typeof(AePermissionManagementSqlCeDataAccessAgent), null);

      public AePermissionManagementDataAccessConfigurationView()
      { }
      
      public AePermissionManagementDataAccessConfigurationView(System.Configuration.Configuration configuration, string productName, string serviceName)
         : base(configuration, productName, serviceName)
      { }
            
      public override string DataAccessSettingsSectionName
      {
         get 
         { 
            return "aePermissionManagementConfiguration175" ; 
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
}
