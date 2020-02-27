// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Text;
using Leadtools.Medical.Worklist.DataAccessLayer;
using Leadtools.Medical.DataAccessLayer;
using Leadtools.DicomDemos;
using Leadtools.Medical.Worklist.DataAccessLayer.Configuration;

namespace Leadtools.Medical.HL7MWL.AddIn
{
   public static class DB
   {
      public static void RegisterDataAccessAgents(string serviceDirectory, string serviceName)
      {
         System.Configuration.Configuration configuration = DicomDemoSettingsManager.GetGlobalPacsAddinsConfiguration(serviceDirectory);
         if (!DataAccessServices.IsDataAccessServiceRegistered<IWorklistDataAccessAgent2>())
         {
            IWorklistDataAccessAgent2 worklistDataAccess = DataAccessFactory.GetInstance(new WorklistDataAccessConfigurationView(configuration, null, serviceName)).CreateDataAccessAgent<IWorklistDataAccessAgent2>();

            DataAccessServices.RegisterDataAccessService<IWorklistDataAccessAgent2>(worklistDataAccess);

            DataAccess = worklistDataAccess;
         }
         else
         {
            DataAccess = DataAccessServices.GetDataAccessService<IWorklistDataAccessAgent2>();
         }
      }

      public static IWorklistDataAccessAgent2 DataAccess
      {
         get
         {
            return _dataAccess;
         }

         set
         {
            _dataAccess = value;
         }
      }

      private static IWorklistDataAccessAgent2 _dataAccess = null;      
   }
}
