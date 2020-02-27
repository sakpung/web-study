// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Dicom.AddIn;
using Leadtools.Dicom;
using Leadtools.Logging;
using Leadtools.Logging.Medical;
using Leadtools.DicomDemos;
using Leadtools.Medical.Storage.DataAccessLayer;
using Leadtools.Medical.DataAccessLayer;
using Leadtools.Medical.Storage.DataAccessLayer.Configuration;
using Leadtools.Medical.WebViewer.PatientAccessRights;
using Leadtools.Medical.WebViewer.PatientAccessRights.DataAccessAgent;
using Leadtools.Medical.WebViewer.Jobs.DataAccessLayer;
using Leadtools.Medical.WebViewer.Jobs.DataAccessLayer.Configuration;
using Leadtools.DicomDemos.From.Medical.WebViewer.ImageDownLoadAddin;

namespace Leadtools.Medical.WebViewer.ImageDownloadAddin
{
   public class ImageDownloadSession : ModuleInit
   {
      public static string StorageServerAE { get; set; }

      static ImageDownloadSession()
      {
         StorageServerAE = string.Empty;
      }

      public override void Load(string serviceDirectory, string displayName)
      {
         #region LOG
         {
            string message = @"Image Download - Session Load";
            Logger.Global.Log(string.Empty, string.Empty, -1, string.Empty, string.Empty, -1, DicomCommandType.Undefined, DateTime.Now,
                             LogType.Information, MessageDirection.None, message, null, null);
         }
         #endregion

         StorageServerAE = displayName;
         
         RegisterDataAccessAgents ( serviceDirectory, displayName ) ;

         base.Load(serviceDirectory, displayName);         
      }

      static void RegisterDataAccessAgents ( string serviceDirectory, string serviceName)
      {
         System.Configuration.Configuration configuration = DicomDemoSettingsManager.GetGlobalPacsAddinsConfiguration(serviceDirectory);

         if ( !DataAccessServices.IsDataAccessServiceRegistered <IStorageDataAccessAgent> ( ) )
         {
            IStorageDataAccessAgent storageDataAccess = DataAccessFactory.GetInstance ( new StorageDataAccessConfigurationView (configuration, null, serviceName) ).CreateDataAccessAgent <IStorageDataAccessAgent> ( ) ;
            
            DataAccessServices.RegisterDataAccessService <IStorageDataAccessAgent> ( storageDataAccess ) ;
         }
         
         if ( !DataAccessServices.IsDataAccessServiceRegistered <IPatientRightsDataAccessAgent> ( ) )
         {
            try
            {
               IPatientRightsDataAccessAgent patientRightsDataAccess = DataAccessFactory.GetInstance(new PatientRightsDataAccessConfigurationView(configuration, null, serviceName)).CreateDataAccessAgent<IPatientRightsDataAccessAgent>();

               DataAccessServices.RegisterDataAccessService<IPatientRightsDataAccessAgent>(patientRightsDataAccess);
            }
            catch (Exception)
            {
               //Log
            }
         }
         
         if ( !DataAccessServices.IsDataAccessServiceRegistered <IDownloadJobsDataAccessAgent> ( ) )
         {
            try
            {
               IDownloadJobsDataAccessAgent downloadDataAccess = DataAccessFactory.GetInstance(new DownloadJobsDataAccessConfigurationView(configuration, null, serviceName)).CreateDataAccessAgent<IDownloadJobsDataAccessAgent>();

               DataAccessServices.RegisterDataAccessService<IDownloadJobsDataAccessAgent>(downloadDataAccess);
            }
            catch (Exception)
            {
            }
         }
      }

      public override void AddServices()
      {
         #region LOG
         {
            string message = @"Image Download - Session AddServices";
            Logger.Global.Log(string.Empty, string.Empty, -1, string.Empty, string.Empty, -1, DicomCommandType.Undefined, DateTime.Now,
                             LogType.Information, MessageDirection.None, message, null, null);
         }
         #endregion

         base.AddServices();

         {
            DicomTagTable.Instance.Insert(CustomTags.JobID, 0xffffffff, "MWV175JobIdTAG", DicomVRType.LT, 1, 1, 1);
         }

         JobsService.Init();
         JobsService.Instance.RetryFailedjobs();
      }
   }
}
