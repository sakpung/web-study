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
   public class SaveImageFormatElement : ConfigurationElement
   {
      private const string WidthProperty   = "width" ;
      private const string HeightProperty  = "height" ;
      private const string QFactorProperty = "qualityFactor" ;
      private const string FormatProperty  = "format" ;
      
      [ConfigurationProperty( WidthProperty, IsRequired=true, DefaultValue=64)]
      public int Width
      {
         get
         {
            return int.Parse ( base [ WidthProperty ].ToString ( ) ) ;
         }
         
         set
         {
            base [ WidthProperty ] = value.ToString ( ) ;
         }
      }
      
      [ConfigurationProperty( HeightProperty, IsRequired=true, DefaultValue=64)]
      public int Height
      {
         get
         {
            return int.Parse ( base [ HeightProperty ].ToString ( ) ) ;
         }
         
         set
         {
            base [ HeightProperty ] = value.ToString ( ) ;
         }
      }
      
      [ConfigurationProperty( QFactorProperty, IsRequired=true, DefaultValue=2)]
      public int QFactor
      {
         get
         {
            return int.Parse ( base [ QFactorProperty ].ToString ( ) ) ;
         }
         
         set
         {
            base [ QFactorProperty ] = value.ToString ( ) ;
         }
      }
      
      [ConfigurationProperty( FormatProperty, IsRequired=true, DefaultValue="")]
      public string Format
      {
         get
         {
            return base [ FormatProperty ].ToString ( ) ;
         }
         
         set
         {
            base [ FormatProperty ] = value.ToString ( ) ;
         }
      }
      
   }
}
