// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;

#if DNXCORE50
using Leadtools.Data;
using Leadtools.Practices.EnterpriseLibrary.Data;
using Leadtools.Practices.EnterpriseLibrary.Data.Sql;
using Leadtools.Data.SqlServerCe;
#else
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.SqlServerCe;
using Microsoft.Practices.EnterpriseLibrary.Data.SqlCe;
#endif

namespace Leadtools.Medical.OptionsDataAccessLayer
{
   public class OptionsSqlCeDataAccessAgent : OptionsSqlDataAccessAgent 
   {
      #region Public Methods
      
      public OptionsSqlCeDataAccessAgent ( string connectionString ) 
      : base ( connectionString ) 
      {
         
      }

      #endregion
      
      #region Protected Methods       
      
      protected override Database CreateDatabaseProvider ( )
      {
         return new SqlCeDatabase ( ConnectionString ) ;
      }

      protected override object RunQueryScalar(string query)
      {
         try
         {
            // Create a connection, a command and an adapter then fill a dataset and return it
            using (SqlCeConnection connection = new SqlCeConnection(ConnectionString))
            {
               using (SqlCeCommand command = new SqlCeCommand(query, connection))
               {
                  connection.Open();
                  return command.ExecuteScalar();
               }
            }
         }
         catch (Exception exception)
         {
            throw exception;
         }
      }
      
      #endregion
   }
}
