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
   public class QueryDataSetValidationElement : ConfigurationElement 
   {
      private const string AllowExtraElementsProperty   = "allowExtraElements" ;
      private const string AllowPrivateElementsProperty = "allowPrivateElements" ;
      private const string AllowZeroItemsSequenceProperty     = "allowZeroItemsSequence" ;
      private const string AllowMultipleItemsSequenceProperty = "allowMultipleItemsSequence" ;

      
      
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
      
      [ConfigurationProperty(AllowZeroItemsSequenceProperty, IsRequired = false, DefaultValue=true)]
      public bool AllowZeroItemsSequence
      {
         get
         {
            return bool.Parse ( base [ AllowZeroItemsSequenceProperty ].ToString ( ) ) ;
         }
         
         set
         {
            base [ AllowZeroItemsSequenceProperty ] = value ;
         }
      }
      
      [ConfigurationProperty(AllowMultipleItemsSequenceProperty, IsRequired = false, DefaultValue=true)]
      public bool AllowMultipleItemsSequence
      {
         get
         {
            return bool.Parse ( base [ AllowMultipleItemsSequenceProperty ].ToString ( ) ) ;
         }
         
         set
         {
            base [ AllowMultipleItemsSequenceProperty ] = value ;
         }
      }
   }
}
