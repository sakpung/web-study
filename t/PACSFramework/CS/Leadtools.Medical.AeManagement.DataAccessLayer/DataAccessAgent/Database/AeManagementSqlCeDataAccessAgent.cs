// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
#if DNXCORE50
using Leadtools.Data;
using Leadtools.Practices.EnterpriseLibrary.Data;
using Leadtools.Practices.EnterpriseLibrary.Data.Sql;
using Leadtools.Data.SqlServerCe;
#else
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.SqlCe;
#endif


namespace Leadtools.Medical.AeManagement.DataAccessLayer
{
   public class AeManagementSqlCeDataAccessAgent : AeManagementSqlDataAccessAgent 
   {
      #region Public Methods
      
      public AeManagementSqlCeDataAccessAgent ( string connectionString ) 
      : base ( connectionString ) 
      {
         
      }

      #endregion
      
      #region Protected Methods
      
      protected override Database CreateDatabaseProvider ( )
      {
         return new SqlCeDatabase ( ConnectionString ) ;
      }
      
      #endregion
   }
}
