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
   public class DatabaseOptionsElement : ConfigurationElement
   {
      private const string UpdateExistentPatientProperty = "updateExistentPatient" ;
      private const string UpdateExistentStudyProperty = "updateExistentStudy" ;
      private const string UpdateExistentSeriesProperty = "updateExistentSeries" ;
      private const string UpdateExistentInstanceProperty = "updateExistentInstance" ;
      
      [ConfigurationProperty( UpdateExistentPatientProperty, IsRequired=false, DefaultValue=false)]
      public bool UpdateExistentPatient
      {
         get
         {
            return bool.Parse ( base [ UpdateExistentPatientProperty ].ToString ( ) ) ;
         }
         
         set
         {
            base [ UpdateExistentPatientProperty ] = value ;
         }
      }
      
      [ConfigurationProperty( UpdateExistentStudyProperty, IsRequired=false, DefaultValue=false)]
      public bool UpdateExistentStudy
      {
         get
         {
            return bool.Parse ( base [ UpdateExistentStudyProperty ].ToString ( ) ) ;
         }
         
         set
         {
            base [ UpdateExistentStudyProperty ] = value ;
         }
      }
      
      [ConfigurationProperty( UpdateExistentSeriesProperty, IsRequired=false, DefaultValue=false)]
      public bool UpdateExistentSeries
      {
         get
         {
            return bool.Parse ( base [ UpdateExistentSeriesProperty ].ToString ( ) ) ;
         }
         
         set
         {
            base [ UpdateExistentSeriesProperty ] = value ;
         }
      }
      
      [ConfigurationProperty( UpdateExistentInstanceProperty, IsRequired=false, DefaultValue=false)]
      public bool UpdateExistentInstance
      {
         get
         {
            return bool.Parse ( base [ UpdateExistentInstanceProperty ].ToString ( ) ) ;
         }
         
         set
         {
            base [ UpdateExistentInstanceProperty ] = value ;
         }
      }
      
   }
}
