// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using Leadtools.Medical.DataAccessLayer.Configuration;

namespace Leadtools.Medical.AeManagement.DataAccessLayer.Configuration
{
   public class AeManagementDataAccessConfigurationView : DataAccessConfigurationView
   {
      private static readonly DataAccessMapping defaultSqlMapping   = new DataAccessMapping(DataAccessMapping.DefaultSqlProviderName, typeof(AeManagementSqlDataAccessAgent), null);
      private static readonly DataAccessMapping defaultSqlCeMapping = new DataAccessMapping(DataAccessMapping.DefaultSqlCe3_5ProviderName, typeof(AeManagementSqlCeDataAccessAgent), null);

#if DNXCORE50
        public AeManagementDataAccessConfigurationView(Leadtools.Configuration.Configuration configuration, string productName, string serviceName)
 : base(configuration, productName, serviceName)
        { }
#else
        public AeManagementDataAccessConfigurationView(System.Configuration.Configuration configuration, string productName, string serviceName)
         : base(configuration, productName, serviceName)
      { }
#endif

        public AeManagementDataAccessConfigurationView()
         : base()
      { }
      
      public override string DataAccessSettingsSectionName
      {
         get 
         {
#if LTV17_CONFIG
            return "aeManagementConfiguration" ; 
#else
            return "aeManagementConfiguration175";
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
}
