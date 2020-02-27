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
#if (LEADTOOLS_V19_OR_LATER)
using Leadtools.Medical.Storage.AddIns.Controls.StorageCommit;
#endif


namespace Leadtools.Medical.Storage.AddIns.Configuration
{
   public class StorageAddInsConfiguration : SerializableConfigurationSection
   {
      public const string SectionName = "storageAddInsSettings" ;
      public const string PresentationContextSectionName = "presentationContextSettings";
      private const string QueryAddInProperty = "queryAddIn" ;
      private const string StoreAddInProperty = "storeAddIn" ;
      private const string StorageCommitAddInProperty = "storageCommitAddIn" ;

      
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
      
      [ConfigurationProperty( QueryAddInProperty, IsRequired=false)]
      public QueryAddInConfigurationElement QueryAddIn
      {
         get
         {
            return base [ QueryAddInProperty ] as QueryAddInConfigurationElement ;
         }
         
         set
         {
            base [ QueryAddInProperty ] = value ;
         }
      }
      
      [ConfigurationProperty( StoreAddInProperty, IsRequired=false )]
      public StoreAddInConfigurationElement StoreAddIn
      {
         get
         {
            return base [ StoreAddInProperty ] as StoreAddInConfigurationElement ;
         }
         
         set
         {
            base [ StoreAddInProperty ] = value ;
         }
      }
   }
}
