// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Dicom.AddIn.Interfaces;
using My.Medical.Storage.DataAccessLayer;
using Leadtools.Medical.Storage.DataAccessLayer;
using Leadtools.Medical.DataAccessLayer;
using Leadtools.DicomDemos;
using System.Diagnostics;
using Leadtools.Dicom.AddIn;
using My.Medical.Storage.DataAccessLayer.Entities;
using Leadtools.Medical.Storage.DataAccessLayer.Interface;

namespace My.Medical.Storage.Configuration
{
   public class AddInsSessions : IServerConfig
   {

      private static IStorageDataAccessAgent3 _dataAccess;
      
      public static IStorageDataAccessAgent3 DataAccess
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

      
      public static string ServiceDirectory
      {
         get;
         set;
      }
      
      static void RegisterInterfaces()
      {
         DataAccessServiceLocator.Register<IPatientInfo>(new MyPatientInfo());
         DataAccessServiceLocator.Register<IStudyInfo>(new MyStudyInfo());
         DataAccessServiceLocator.Register<ISeriesInfo>(new MySeriesInfo());
         DataAccessServiceLocator.Register<IInstanceInfo>(new MyInstanceInfo());
         
         RegisteredEntities.Items.Add(RegisteredEntities.PatientEntityName, typeof(MyPatient));
         RegisteredEntities.Items.Add(RegisteredEntities.StudyEntityName, typeof(MyStudy));
         RegisteredEntities.Items.Add(RegisteredEntities.SeriesEntityName, typeof(MySeries));
         RegisteredEntities.Items.Add(RegisteredEntities.InstanceEntityName, typeof(MyInstance));
      }

      static void RegisterDataAccessAgents(string serviceName)
      {
         System.Configuration.Configuration configuration = DicomDemoSettingsManager.GetGlobalPacsAddinsConfiguration(ServiceDirectory);
         if (!DataAccessServices.IsDataAccessServiceRegistered<IStorageDataAccessAgent3>())
         {
            IStorageDataAccessAgent3 storageDataAccess = 
               DataAccessFactory.GetInstance(new MyStorageDataAccessConfigurationView(configuration, null, serviceName)).CreateDataAccessAgent<IStorageDataAccessAgent3>();

            DataAccessServices.RegisterDataAccessService<IStorageDataAccessAgent3>(storageDataAccess);

            DataAccess = storageDataAccess;
         }
         else
         {
            DataAccess = DataAccessServices.GetDataAccessService<IStorageDataAccessAgent3>();
         }
      }
      
      public void Configure(Leadtools.Dicom.AddIn.DicomServer server)
      {
         ServiceDirectory = server.ServerDirectory;

         RegisterDataAccessAgents(ServiceDirectory);
         RegisterInterfaces();
      }
   }
}
