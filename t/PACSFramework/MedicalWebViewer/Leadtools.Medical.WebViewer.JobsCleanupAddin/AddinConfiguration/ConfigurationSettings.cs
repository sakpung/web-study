// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Configuration ;
using System.Text;
using System.Linq ;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration ;


namespace Leadtools.Medical.WebViewer.JobsCleanupAddin
{
   public class StorageAddInsConfiguration : SerializableConfigurationSection
   {
      public const string SectionName = "storageAddInsSettings" ;
      public const string PresentationContextSectionName = "presentationContextSettings";

      private const string JobsCleanupAddInProperty = "jobsCleanupAddIn";
      
      public static StorageAddInsConfiguration Instance
      {
         get
         {
            IConfigurationSource configuration = ConfigurationSourceFactory.Create ( ) ;
            
            
            return configuration.GetSection ( SectionName ) as StorageAddInsConfiguration ;
         }
      }
      
      public override bool IsReadOnly ( )
      {
         return false ;
      }

      [ConfigurationProperty(JobsCleanupAddInProperty, IsRequired = false)]
      public JobsCleanupAddInConfigurationElement JobsCleanupAddIn
      {
         get
         {
            return base[JobsCleanupAddInProperty] as JobsCleanupAddInConfigurationElement;
         }
         
         set
         {
            base[JobsCleanupAddInProperty] = value;
         }
      }
   }
}
