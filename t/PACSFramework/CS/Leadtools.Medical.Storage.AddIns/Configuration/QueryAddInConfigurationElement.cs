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
   public class QueryAddInConfigurationElement : ConfigurationElement
   {
      private const string QueryIODPathProperty             = "queryIODPath" ;
      private const string DataSetRequestValidationProperty = "datasetRequestValidation" ;
      private const string DataSetResponseOptionsProperty   = "datasetResponseOptions" ;
      private const string LimitCFindRspProperty            = "limitCFindRsp";
      private const string MaximumCFindRspCountProperty     = "maxCFindRspCount";
      private const string ServiceStatusProperty            = "serviceStatus";
      
      [ConfigurationProperty( QueryIODPathProperty, IsRequired=false)]
      public string QueryIODPath
      {
         get
         {
            return base [ QueryIODPathProperty ].ToString ( ) ;
         }
         
         set
         {
            base [ QueryIODPathProperty ] = value ;
         }
      }
      
      [ConfigurationProperty( LimitCFindRspProperty, IsRequired=false)]
      public bool LimitCFindRsp
      {
         get
         {
             return bool.Parse ( base [ LimitCFindRspProperty ].ToString());
         }
         
         set
         {
            base [ LimitCFindRspProperty ] = value ;
         }
      }
      
      [ConfigurationProperty( MaximumCFindRspCountProperty, IsRequired=false)]
      public int MaximumCFindRspCount
      {
         get
         {
             return int.Parse ( base [ MaximumCFindRspCountProperty ].ToString());
         }
         
         set
         {
            base [ MaximumCFindRspCountProperty ] = value ;
         }
      }
      
      [ConfigurationProperty( ServiceStatusProperty, IsRequired=false)]
      public int ServiceStatus
      {
         get
         {
             return int.Parse ( base [ ServiceStatusProperty ].ToString());
         }
         
         set
         {
            base [ ServiceStatusProperty ] = value ;
         }
      }
      
      
      [ConfigurationProperty( DataSetRequestValidationProperty, IsRequired=false )]
      public QueryDataSetValidationElement DataSetRequestValidation
      {
         get
         {
            return base [ DataSetRequestValidationProperty ] as QueryDataSetValidationElement ;
         }
         
         set
         {
            base [ DataSetRequestValidationProperty ] = value ;
         }
      }
      
      [ConfigurationProperty( DataSetResponseOptionsProperty, IsRequired=false)]
      public QueryResponseDataSetElement DataSetResponseOptions
      {
         get
         {
            return base [ DataSetResponseOptionsProperty ] as QueryResponseDataSetElement ;
         }
         
         set
         {
            base [ DataSetResponseOptionsProperty ] = value ;
         }
      }
      
   }
}
