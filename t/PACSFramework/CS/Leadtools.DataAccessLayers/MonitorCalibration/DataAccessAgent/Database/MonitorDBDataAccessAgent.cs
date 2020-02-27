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
using Leadtools.Dicom.AddIn.Common;
using Leadtools.DataAccessLayers.Core;

namespace Leadtools.DataAccessLayers
{
   public abstract class MonitorCalibrationDataAccessAgent : IMonitorCalibrationDataAccessAgent
   {
      private string _ConnectionString;

      public string ConnectionString
      {
         get
         {
            return _ConnectionString;
         }

         private set
         {
            _ConnectionString = value;
         }
      }

      private Database _DatabaseProvider;

      protected Database DatabaseProvider
      {
         get
         {
            if (null == _DatabaseProvider)
            {
               _DatabaseProvider = CreateDatabaseProvider();
            }

            return _DatabaseProvider;
         }

         private set
         {
            _DatabaseProvider = value;
         }
      }

      public MonitorCalibrationDataAccessAgent(string connectionString)
      {
         ConnectionString = connectionString;
      }                
      
      protected abstract Database CreateDatabaseProvider();
      protected abstract object RunQueryScalar(string query);
      protected abstract void InitializeGetWorkstationCalibrations(DbCommand command, string workstation);
      protected abstract void InitializeGetAllCalibrations(DbCommand command);
      protected abstract void InitializeAddCalibration(DbCommand command, Calibration calibration);         
     
      #region IMonitorCalibrationDataAccessAgent Members

      public List<Calibration> GetWorkstationCalibrations(string workstation)
      {
         DbCommand command;        

         command = DatabaseProvider.DbProviderFactory.CreateCommand();
         InitializeGetWorkstationCalibrations(command, workstation);
         return GetCalibrations(command);
      }

      public List<Calibration> GetAllCalibrations()
      {
         DbCommand command;                  

         command = DatabaseProvider.DbProviderFactory.CreateCommand();
         InitializeGetAllCalibrations(command);         
         return GetCalibrations(command);
      }

      public List<Calibration> GetCalibrations(DbCommand command)
      {
         List<Calibration> calibrations = new List<Calibration>();
         
         using (var reader = DatabaseProvider.ExecuteReader(command))
         {
            while (reader.Read())
            {
               Calibration calibration = new Calibration();

               calibration.CalibrationTime = reader.GetColumnValue<DateTime>("CalibrationTime");
               calibration.Username = reader.GetColumnValue<string>("Username");
               calibration.Workstation = reader.GetColumnValue<string>("Workstation");
               calibration.Comments = reader.GetColumnValue<string>("Comments");
               calibrations.Add(calibration);
            }
         }
         return calibrations;
      }

      public void AddCalibration(Calibration calibration)
      {
         DbCommand command;

         command = DatabaseProvider.DbProviderFactory.CreateCommand();
         InitializeAddCalibration(command, calibration);
         DatabaseProvider.ExecuteNonQuery(command);
      }

      #endregion
   }
}
