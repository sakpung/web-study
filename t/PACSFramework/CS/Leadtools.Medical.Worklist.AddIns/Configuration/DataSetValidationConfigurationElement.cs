// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Configuration ;
using System.Text;

namespace Leadtools.Medical.Worklist.AddIns.Configuration
{
   public class DataSetValidationElement : ConfigurationElement
   {
      private const string AllowExtraElementsProperty   = "allowExtraElements" ;
      private const string AllowPrivateElementsProperty = "allowPrivateElements" ;
      
      
      [ConfigurationProperty(AllowExtraElementsProperty, IsRequired = false, DefaultValue=true)]
      public bool AllowExtraElements
      {
         get
         {
            return bool.Parse ( base [ AllowExtraElementsProperty ].ToString ( ) ) ;
         }
         
         set
         {
            base [ AllowExtraElementsProperty ] = value ;
         }
      }
      
      [ConfigurationProperty(AllowPrivateElementsProperty, IsRequired = false, DefaultValue=true)]
      public bool AllowPrivateElements
      {
         get
         {
            return bool.Parse ( base [ AllowPrivateElementsProperty ].ToString ( ) ) ;
         }
         
         set
         {
            base [ AllowPrivateElementsProperty ] = value ;
         }
      }
   }
}
