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
   public class SaveImageFormatCollection : ConfigurationElementCollection
   {
      protected override ConfigurationElement CreateNewElement()
      {
         return new SaveImageFormatElement ( ) ;
      }
      
      public void Add ( SaveImageFormatElement element ) 
      {
         BaseAdd ( element ) ;
      }
      
      public void Remove ( SaveImageFormatElement element ) 
      {
         base.BaseRemove ( GetElementKey ( element ) ) ;
      }
      
      public void Clear ( ) 
      {
         BaseClear ( ) ;
      }

      protected override object GetElementKey ( ConfigurationElement element )
      {
         if ( element is SaveImageFormatElement  ) 
         {
            SaveImageFormatElement  imageElement = element as SaveImageFormatElement ;
            
            
            return imageElement.Format ;
         }
         else
         {
            return null ;
         }
      }

      protected override bool ThrowOnDuplicate
      {
         get
         {
            return false ;
         }
      }
   }
}
