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
   public class QueryResponseDataSetElement : ConfigurationElement 
   {
      private const string IncludeNumberOfPatientStudiesProperty   = "includeNumberOfPatientRelatedStudies" ;
      private const string IncludeNumberOfPatientSeriesProperty    = "includeNumberOfPatientRelatedSeries" ;
      private const string IncludeNumberOfPatientInstancesProperty = "includeNumberOfPatientRelatedInstances" ;
      private const string IncludeNumberOfStudySeriesProperty      = "includeNumberOfStudyRelatedSeries" ;
      private const string IncludeNumberOfStudyInstancesProperty   = "includeNumberOfStudyRelatedInstances" ;
      private const string IncludeNumberOfSeriesInstancesProperty  = "includeNumberOfSeriesRelatedInstances" ;
      
      
      [ConfigurationProperty( IncludeNumberOfPatientStudiesProperty, IsRequired=false, DefaultValue=true)]
      public bool IncludeNumberOfPatientStudies
      {
         get
         {
            return bool.Parse ( base [ IncludeNumberOfPatientStudiesProperty ].ToString ( ) ) ;
         }
         
         set
         {
            base [ IncludeNumberOfPatientStudiesProperty ] = value ;
         }
      }
      
      [ConfigurationProperty( IncludeNumberOfPatientSeriesProperty, IsRequired=false, DefaultValue=true)]
      public bool IncludeNumberOfPatientSeries
      {
         get
         {
            return bool.Parse ( base [ IncludeNumberOfPatientSeriesProperty ].ToString ( ) ) ;
         }
         
         set
         {
            base [ IncludeNumberOfPatientSeriesProperty ] = value ;
         }
      }
      
      [ConfigurationProperty( IncludeNumberOfPatientInstancesProperty, IsRequired=false, DefaultValue=true)]
      public bool IncludeNumberOfPatientInstances
      {
         get
         {
            return bool.Parse ( base [ IncludeNumberOfPatientInstancesProperty ].ToString ( ) ) ;
         }
         
         set
         {
            base [ IncludeNumberOfPatientInstancesProperty ] = value ;
         }
      }
      
      [ConfigurationProperty( IncludeNumberOfStudySeriesProperty, IsRequired=false, DefaultValue=true)]
      public bool IncludeNumberOfStudySeries
      {
         get
         {
            return bool.Parse ( base [ IncludeNumberOfStudySeriesProperty ].ToString ( ) ) ;
         }
         
         set
         {
            base [ IncludeNumberOfStudySeriesProperty ] = value ;
         }
      }
      
      [ConfigurationProperty( IncludeNumberOfStudyInstancesProperty, IsRequired=false, DefaultValue=true)]
      public bool IncludeNumberOfStudyInstances
      {
         get
         {
            return bool.Parse ( base [ IncludeNumberOfStudyInstancesProperty ].ToString ( ) ) ;
         }
         
         set
         {
            base [ IncludeNumberOfStudyInstancesProperty ] = value ;
         }
      }
      
      [ConfigurationProperty( IncludeNumberOfSeriesInstancesProperty , IsRequired=false, DefaultValue=true)]
      public bool IncludeNumberOfSeriesInstances
      {
         get
         {
            return bool.Parse ( base [ IncludeNumberOfSeriesInstancesProperty  ].ToString ( ) ) ;
         }
         
         set
         {
            base [ IncludeNumberOfSeriesInstancesProperty  ] = value ;
         }
      }
   }
}
