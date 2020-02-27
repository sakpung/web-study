// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.SqlCe;
using System.Data.SqlServerCe;

namespace Leadtools.DataAccessLayers
{
   public class MonitorCalibrationSqlCeDataAccessAgent : MonitorCalibrationSqlDataAccessAgent 
   {
      #region Public Methods
      
      public MonitorCalibrationSqlCeDataAccessAgent ( string connectionString ) 
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
