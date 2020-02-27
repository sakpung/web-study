// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data;
using System.Security.Cryptography;
using System.Runtime.InteropServices;
using System.Security;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using Microsoft.Practices.EnterpriseLibrary.Data.SqlCe;

namespace Leadtools.Medical.Forward.DataAccessLayer
{
   public class ForwardSqlCeDataAccessAgent : ForwardSqlDataAccessAgent 
   {
      #region Public Methods
      
      public ForwardSqlCeDataAccessAgent ( string connectionString ) 
      : base ( connectionString ) 
      {
         
      }

      #endregion
      
      #region Protected Methods
      
      protected override Microsoft.Practices.EnterpriseLibrary.Data.Database CreateDatabaseProvider ( )
      {
         return new SqlCeDatabase ( ConnectionString ) ;
      }
      
      #endregion
   }
}
