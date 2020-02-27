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
using System.Data.SqlClient;
using Leadtools.DataAccessLayers.Core;

namespace Leadtools.DataAccessLayers
{
   public class MonitorCalibrationSqlDataAccessAgent : MonitorCalibrationDataAccessAgent
   {
      public MonitorCalibrationSqlDataAccessAgent(string connectionString) 
      : base ( connectionString ) 
      {
         
      }      

      protected override Database CreateDatabaseProvider()
      {
         return new SqlDatabase(ConnectionString);
      }

      protected override object RunQueryScalar(string query)
      {
         try
         {
            // Create a connection, a command and an adapter then fill a dataset and return it
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
               using (SqlCommand command = new SqlCommand(query, connection))
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

      protected override void InitializeAddCalibration(DbCommand command, Calibration calibration)
      {
         DbParameter p = command.CreateParameter();

         p.ParameterName = "@time";
         p.Value = calibration.CalibrationTime;
         command.CommandText = string.Format(@"INSERT INTO MonitorCalibration(CalibrationTime,Username,Workstation,Comments) VALUES 
                                              (@time,'{0}','{1}','{2}')", calibration.Username, calibration.Workstation, calibration.Comments);
         command.Parameters.Add(p);
      }

      protected override void InitializeGetAllCalibrations(DbCommand command)
      {
         command.CommandText = string.Format("SELECT * FROM MonitorCalibration ORDER BY CalibrationTime DESC");
      }

      protected override void InitializeGetWorkstationCalibrations(DbCommand command, string workstation)
      {
         command.CommandText = string.Format("SELECT * FROM MonitorCalibration WHERE Workstation='{0}' ORDER BY CalibrationTime DESC", workstation);
      }     
   }
}
