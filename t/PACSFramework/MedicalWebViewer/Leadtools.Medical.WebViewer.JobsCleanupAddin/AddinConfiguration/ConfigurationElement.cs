// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration ;

namespace Leadtools.Medical.WebViewer.JobsCleanupAddin
{
   public class JobsCleanupAddInConfigurationElement : ConfigurationElement
   {
      private const string RunProperty = "RunProperty";
      private const string EnableProperty = "EnableProperty";
      private const string CheckIntervalProperty = "CheckIntervalProperty" ;
      private const string CheckIntervalCustomProperty = "CheckIntervalCustomProperty" ;
      private const string ExpiryIntervalProperty = "ExpiryIntervalProperty" ;
      private const string ExpiryIntervalCustomProperty = "ExpiryIntervalCustomProperty" ;
      private const string MaxRetryProperty = "MaxRetryProperty";

      [ConfigurationProperty(RunProperty, IsRequired = false, DefaultValue = null)]
      public DateTime? Run
      {
         get
         {
            return base[RunProperty] as DateTime?;
         }

         set
         {
            base[RunProperty] = value;
         }
      }
      
      [ConfigurationProperty(EnableProperty, IsRequired = false, DefaultValue = "True")]
      public bool? Enable
      {
         get
         {
            return base[EnableProperty] as bool?;
         }
         
         set
         {
            base[EnableProperty] = value;
         }
      }
         [ConfigurationProperty(CheckIntervalProperty, IsRequired=false, DefaultValue="0")]
      public int? CheckInterval
      {
         get
         {
            return base[CheckIntervalProperty] as int?;
         }
         
         set
         {
            base[CheckIntervalProperty] = value;
         }
      }
         [ConfigurationProperty(CheckIntervalCustomProperty, IsRequired=false, DefaultValue="2")]
      public int? CheckIntervalCustom
      {
         get
         {
            return base[CheckIntervalCustomProperty] as int?;
         }
         
         set
         {
            base[CheckIntervalCustomProperty] = value;
         }
      }
         [ConfigurationProperty(ExpiryIntervalProperty, IsRequired=false, DefaultValue="0")]
      public int? ExpiryInterval
      {
         get
         {
            return base[ExpiryIntervalProperty] as int?;
         }
         
         set
         {
            base[ExpiryIntervalProperty] = value;
         }
      }
         [ConfigurationProperty(ExpiryIntervalCustomProperty, IsRequired=false, DefaultValue="2")]
      public int? ExpiryIntervalCustom
      {
         get
         {
            return base[ExpiryIntervalCustomProperty] as int?;
         }
         
         set
         {
            base[ExpiryIntervalCustomProperty] = value;
         }
      }
         [ConfigurationProperty(MaxRetryProperty, IsRequired = false, DefaultValue = "3")]
      public int? MaxRetry
         {
            get
            {
               return base[MaxRetryProperty] as int?;
            }

            set
            {
               base[MaxRetryProperty] = value;
            }
         }
     
   }
}
