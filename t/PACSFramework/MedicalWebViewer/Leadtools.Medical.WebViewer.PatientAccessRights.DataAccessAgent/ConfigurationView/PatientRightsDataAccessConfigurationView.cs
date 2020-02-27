// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Medical.DataAccessLayer.Configuration;

namespace Leadtools.Medical.WebViewer.PatientAccessRights.DataAccessAgent
{
   /// <summary>
   /// this is the configuration view class that is common for all DALs, used to get the config section name and define the default DALs for each provider
   /// </summary>
   public class PatientRightsDataAccessConfigurationView : DataAccessConfigurationView
   {
      private static readonly DataAccessMapping defaultSqlMapping = new DataAccessMapping(DataAccessMapping.DefaultSqlProviderName, typeof(PatientRightsSqlDbDataAccessAgent), null);
      
      public PatientRightsDataAccessConfigurationView()
      {
      }
            
      public PatientRightsDataAccessConfigurationView(System.Configuration.Configuration configuration, string productName, string serviceName)
      : base(configuration, productName, serviceName)
      {
      }

      public override string DataAccessSettingsSectionName
      {
         get 
         { 
            return "patientRightsConfiguration175" ; 
         }
      }

      protected override DataAccessMapping GetDefaultMapping ( string name, string dbProviderName )
      {
         // try to short circuit by default name
         if (DataAccessMapping.DefaultSqlProviderName.Equals(dbProviderName))
            return defaultSqlMapping;


         return null;
      }
   }
}
