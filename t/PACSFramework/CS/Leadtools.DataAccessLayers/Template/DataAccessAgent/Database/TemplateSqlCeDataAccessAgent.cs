// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.SqlCe;

namespace Leadtools.DataAccessLayers
{
    public class TemplateSqlCeDataAccessAgent : TemplateSqlDataAccessAgent
    {
        public TemplateSqlCeDataAccessAgent ( string connectionString ) 
      : base ( connectionString ) 
      {
         
      }
            
      
      protected override Database CreateDatabaseProvider ( )
      {
         return new SqlCeDatabase ( ConnectionString ) ;
      }
    }
}
