// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration ;
using System.IO;

namespace Leadtools.Medical.Worklist.AddIns
{
   public class WorklistDataAccessFactory : Leadtools.Medical.DataAccessLayer.DataAccessFactory
   {
      public override T CreateDataAccessAgent<T>()
      {
         string addInsConfigFile ;
         
         
         addInsConfigFile = Path.Combine ( AddInsSession.ServiceDirectory, "service.config" ) ;
         
         if ( File.Exists ( addInsConfigFile ) )
         {
            base.ConfigurationView.ConfigurationSource = new FileConfigurationSource ( addInsConfigFile ) ;
         }
         
         return base.CreateDataAccessAgent<T>();
      }
   }
   
   public class WorklistCatalogFactory : Leadtools.Medical.DataAccessLayer.CatalogFactory
   {
      public override Leadtools.Medical.DataAccessLayer.Catalog.ICatalog CreateCatalog ( )
      {
         string addInsConfigFile ;
         
         
         addInsConfigFile = Path.Combine ( AddInsSession.ServiceDirectory, "service.config" ) ;
         
         if ( File.Exists ( addInsConfigFile ) )
         {
            base.ConfigurationView.ConfigurationSource = new FileConfigurationSource ( addInsConfigFile ) ;
         }
         
         return base.CreateCatalog ( );
      }
   }
}
