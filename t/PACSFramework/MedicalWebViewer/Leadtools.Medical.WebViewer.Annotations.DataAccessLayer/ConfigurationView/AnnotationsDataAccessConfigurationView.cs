// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Medical.DataAccessLayer.Configuration;
using Leadtools.Medical.WebViewer.Annotations;

namespace Leadtools.Medical.WebViewer.Annotations.DataAccessAgent
{
   public class AnnotationsDataAccessConfigurationView : DataAccessConfigurationView
   {
      private static readonly DataAccessMapping defaultSqlMapping = new DataAccessMapping(DataAccessMapping.DefaultSqlProviderName, typeof(AnnotationsSqlDbDataAccessAgent), null);
      
      public AnnotationsDataAccessConfigurationView()
      {
      }
            
      public AnnotationsDataAccessConfigurationView(System.Configuration.Configuration configuration, string productName, string serviceName)
      : base(configuration, productName, serviceName)
      {
      }

      public override string DataAccessSettingsSectionName
      {
         get 
         { 
            return "annotationsConfiguration175" ; 
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
