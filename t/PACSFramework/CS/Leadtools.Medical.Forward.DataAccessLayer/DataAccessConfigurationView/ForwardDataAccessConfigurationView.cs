// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Medical.DataAccessLayer.Configuration;

namespace Leadtools.Medical.Forward.DataAccessLayer.Configuration
{
   public class ForwardDataAccessConfigurationView : DataAccessConfigurationView
   {
      private static readonly DataAccessMapping defaultSqlMapping   = new DataAccessMapping(DataAccessMapping.DefaultSqlProviderName, typeof(ForwardSqlDataAccessAgent), null);
      private static readonly DataAccessMapping defaultSqlCeMapping = new DataAccessMapping(DataAccessMapping.DefaultSqlCe3_5ProviderName, typeof(ForwardSqlCeDataAccessAgent), null);
      
      public override string DataAccessSettingsSectionName
      {
         get 
         {
#if LTV17_CONFIG
            return "forwardConfiguration" ; 
#else
            return "forwardConfiguration175";
#endif
         }
      }

      public ForwardDataAccessConfigurationView(System.Configuration.Configuration configuration, string productName, string serviceName)
         : base(configuration, productName, serviceName)
      { }
      
      public ForwardDataAccessConfigurationView()
      { }

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
