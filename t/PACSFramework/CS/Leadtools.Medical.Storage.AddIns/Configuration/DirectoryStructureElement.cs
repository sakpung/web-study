// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration ;


namespace Leadtools.Medical.Storage.AddIns.Configuration
{
   public class DirectoryStructureElement : ConfigurationElement
   {
      private const string CreatePatientFolderProperty   = "createPatientFolder" ;
      private const string CreateStudyFolderProperty     = "createSeriesFolder" ;
      private const string CreateSeriesFolderProperty    = "createSeriesFolder" ;
      private const string UsePatientNameProperty        = "usePatientName" ;
      private const string SplitPatientIdProperty        = "splitPatientId";
      
      
      [ConfigurationProperty( CreatePatientFolderProperty, IsRequired=false, DefaultValue=true)]
      public bool CreatePatientFolder
      {
         get
         {
            return bool.Parse ( base [ CreatePatientFolderProperty ].ToString ( ) ) ;
         }
         
         set
         {
            base [ CreatePatientFolderProperty ] = value ;
         }
      }
      
      [ConfigurationProperty( CreateStudyFolderProperty, IsRequired=false, DefaultValue=true)]
      public bool CreateStudyFolder
      {
         get
         {
            return bool.Parse ( base [ CreateStudyFolderProperty ].ToString ( ) ) ;
         }
         
         set
         {
            base [ CreateStudyFolderProperty ] = value ;
         }
      }
      
      [ConfigurationProperty( CreateSeriesFolderProperty, IsRequired=false, DefaultValue=true)]
      public bool CreateSeriesFolder
      {
         get
         {
            return bool.Parse ( base [ CreateSeriesFolderProperty ].ToString ( ) ) ;
         }
         
         set
         {
            base [ CreateSeriesFolderProperty ] = value ;
         }
      }
      
      [ConfigurationProperty( UsePatientNameProperty, IsRequired=false, DefaultValue=true)]
      public bool UsePatientName
      {
         get
         {
            return bool.Parse ( base [ UsePatientNameProperty ].ToString ( ) ) ;
         }
         
         set
         {
            base [ UsePatientNameProperty ] = value ;
         }
      }

      [ConfigurationProperty(SplitPatientIdProperty, IsRequired = false, DefaultValue = false)]
      public bool SplitPatientId
      {
         get
         {
            return bool.Parse(base[SplitPatientIdProperty].ToString());
         }

         set
         {
            base[SplitPatientIdProperty] = value;
         }
      }
      
   }
}
