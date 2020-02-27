// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Configuration ;
using System.Linq;
using System.Text;

namespace Leadtools.Medical.Worklist.AddIns.Configuration
{
   public class ModalityWorklistDataSetValidationElement : DataSetValidationElement
   {
      private const string AllowZeroItemsSequenceProperty     = "allowZeroItemsSequence" ;
      private const string AllowMultipleItemsSequenceProperty = "allowMultipleItemsSequence" ;
      
      
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
