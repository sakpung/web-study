// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using Leadtools.Medical.DataAccessLayer.Configuration;

namespace Leadtools.Medical.OptionsDataAccessLayer.Configuration
{
   public class OptionsDataAccessConfigurationView : DataAccessConfigurationView
   {
      private static readonly DataAccessMapping defaultSqlMapping   = new DataAccessMapping(DataAccessMapping.DefaultSqlProviderName, typeof(OptionsSqlDataAccessAgent), null);
      private static readonly DataAccessMapping defaultSqlCeMapping = new DataAccessMapping(DataAccessMapping.DefaultSqlCe3_5ProviderName, typeof(OptionsSqlCeDataAccessAgent), null);

      public OptionsDataAccessConfigurationView()
         : base()
      { }

#if DNXCORE50
        public OptionsDataAccessConfigurationView(Leadtools.Configuration.Configuration configuration, string productName, string serviceName)
 : base(configuration, productName, serviceName)
        { }
#else
        public OptionsDataAccessConfigurationView(System.Configuration.Configuration configuration, string productName, string serviceName)
         : base(configuration, productName, serviceName)
      { }
#endif

        public override string DataAccessSettingsSectionName
      {
         get 
         {
#if LTV17_CONFIG
            return "optionsConfiguration" ; 
#else
            return "optionsConfiguration175";
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
