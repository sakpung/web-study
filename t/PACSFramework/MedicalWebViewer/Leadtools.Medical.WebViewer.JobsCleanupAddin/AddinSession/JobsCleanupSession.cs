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
using Leadtools.Medical.DataAccessLayer;
using Leadtools.Medical.WebViewer.Jobs.DataAccessLayer;
using Leadtools.DicomDemos;
using Leadtools.Medical.WebViewer.Jobs.DataAccessLayer.Configuration;

namespace Leadtools.Medical.WebViewer.JobsCleanupAddin
{
   public class JobsCleanupSession : ModuleInit
   {
      static void RegisterDataAccessAgents(string serviceDirectory, string serviceName)
      {
         System.Configuration.Configuration configuration = DicomDemoSettingsManager.GetGlobalPacsAddinsConfiguration(serviceDirectory);


         if (!DataAccessServices.IsDataAccessServiceRegistered<IDownloadJobsDataAccessAgent>())
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

      public override void Load(string _ServiceDirectory, string _DisplayName)
      {
         #region LOG
         {
            string message = @"Jobs Cleanup - Session Load";
            Logger.Global.Log(string.Empty, string.Empty, -1, string.Empty, string.Empty, -1, DicomCommandType.Undefined, DateTime.Now,
                             LogType.Information, MessageDirection.None, message, null, null);
         }
         #endregion
         
         base.Load(_ServiceDirectory, _DisplayName);
         ServiceDirectory = _ServiceDirectory;
         ServiceName = _DisplayName;
         RegisterDataAccessAgents(_ServiceDirectory, _DisplayName);
      }

      public override void AddServices()
      {
         base.AddServices();
         JobsCleanupService.Init();
      }

      public static string ServiceDirectory
      {
         get;
         set;
      }

      public static string ServiceName
      {
         get;
         set;
      }

   }
}
