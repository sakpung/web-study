// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Medical.WebViewer.ServiceContracts;
using Leadtools.Medical.Storage.DataAccessLayer;
using Leadtools.Medical.DataAccessLayer;
using Leadtools.Medical.Storage.DataAccessLayer.MatchingParameters;
using Leadtools.Medical.WebViewer.DataContracts;
using Leadtools.Medical.WebViewer.Addins.Common;
using Leadtools.Dicom.Common.DataTypes;
using Leadtools.Medical.WebViewer.PatientAccessRights;
using Leadtools.Medical.WebViewer.Jobs;
using System.Net;
using Leadtools.Medical.WebViewer.Jobs.DataAccessLayer;

namespace Leadtools.Medical.WebViewer.Addins
{
   /// <summary>
   /// 
   /// </summary>
   public class DownloadAddin : IPacsDownloadAddin
   {
      IAuthorizedStorageDataAccessAgent _AuthorizedDataAccessAgent = null;
      IDownloadJobsDataAccessAgent _DownloadJobsDataAccessAgent = null;

      public DownloadAddin(PACSConnection localClient, PACSConnection storageServer, IDownloadJobsDataAccessAgent DownloadJobsDataAccessAgent, IAuthorizedStorageDataAccessAgent DataAccess) 
      {
         LocalClient = localClient ;
         StorageServer = storageServer;

         _AuthorizedDataAccessAgent = DataAccess;
         _DownloadJobsDataAccessAgent = DownloadJobsDataAccessAgent;
      }

      public void DeleteImages(
         string sUserName, 
         string PatientID,
         string StudyInstanceUID,
         string SeriesInstanceUID,
         string SOPInstanceUID)
      {
         using (StorageDeleteJob dj = new StorageDeleteJob()
         {
            Owner = sUserName,
            AuthorizedDataAccessAgent = _AuthorizedDataAccessAgent,
            PatientID = PatientID,
            StudyInstanceUID = StudyInstanceUID,
            SeriesInstanceUID = SeriesInstanceUID,
            SOPInstanceUID = SOPInstanceUID
         })
         {

            dj.StartJob();

            if (dj.isFailed && !dj.isAborted)
            {
               throw new Exception(dj.LastError);
            }
         }
      }

      public void DeleteDownloadInfos
      (
         string sUserName, 
         int[] jobIds         
      )
      {
         _DownloadJobsDataAccessAgent.DeleteJobs ( sUserName, jobIds ) ;
      }

      private MoveObjectsJob CreateJob(PACSConnection server, 
         string MoveToAe, 
         string PatientID,
         string StudyInstanceUID,
         string SeriesInstanceUID,
         string SOPInstanceUID)
      {
         DICOMJobSettings _js = new DICOMJobSettings()
         {
            ServerAE = server.AETitle,
            ServerPort = server.Port,
            ServerIP = server.IPAddress,
            ClientAE = LocalClient.AETitle,
            ClientIP = LocalClient.IPAddress,
            ClientPort = LocalClient.Port,
            MoveToClientAE = MoveToAe
         };

         MoveObjectsJobConfig mc = new MoveObjectsJobConfig()
         {
            PatientID = PatientID,
            StudyInstanceUID = StudyInstanceUID,
            SeriesInstanceUID = SeriesInstanceUID,
            SOPInstanceUID = SOPInstanceUID
         };

         MoveObjectsJob mj = new MoveObjectsJob(_js);
         mc.Config(mj);
         return mj;
      }

      public DownloadInfo DownloadImages(string sUserName,
         PACSConnection server, 
         string MoveToAE,
         string PatientID,
         string StudyInstanceUID,
         string SeriesInstanceUID,
         string SOPInstanceUID, 
         string UserData)
      {
         JobProxy jp = new JobProxy(_DownloadJobsDataAccessAgent);
                  
         jp.AddJob(typeof(MoveObjectsJob).ToString(),
                   JobsPersistence.Save(CreateJob(server, MoveToAE, PatientID, StudyInstanceUID, SeriesInstanceUID, SOPInstanceUID)), 
                   0, 
                   0,
                   UserData,
                   sUserName);

         try
         {
            using (ImageDownloadAddin.WebAddin WebInterface = new ImageDownloadAddin.WebAddin())
            {
               WebInterface.SendDownloadRequest(jp.Id.ToString(),
                  LocalClient.AETitle, 
                  LocalClient.IPAddress, 
                  LocalClient.Port, 
                  StorageServer.AETitle, 
                  StorageServer.IPAddress, 
                  StorageServer.Port);
            }
         }
         catch (System.Exception ex)
         {
            jp.SetFailed_NotExecutedYet("Error connecting to the Archive server: " + ex.Message);
         }

         return UpdateDownloadInfoStatus(sUserName, new DownloadInfo() { Id = jp.Id.ToString() }); 
      }

      public JobStatus[] GetJobStatus ( 
         string authenticationCookie, 
         string[] JobsIds )
      {
         List<JobStatus> ds = new List<JobStatus>();
         JobProxy jp = new JobProxy(_DownloadJobsDataAccessAgent);

         foreach (string JobId in JobsIds)
         {
            try
            {
               JobProxy.Status status = JobProxy.Status.idle;
               JobProxy.CompletedStatus completedstatus = JobProxy.CompletedStatus.failed;
               string sError = string.Empty;
               string sUserData = string.Empty;

               jp.Id = int.Parse(JobId);
               jp.GetStatus(out status, out completedstatus, out sError, out sUserData);
               ds.Add(new JobStatus() { Id = jp.Id.ToString(), Status = DecodeStatus(status, completedstatus), ErrorMessage = sError });
            }
            catch (System.Exception)
            {
            	//move to next
            }            
         }

         return ds.ToArray();
      }

      public DownloadInfo[] GetDownloadInfos( string sUserName,
                                              PACSConnection server, 
                                              string client,                                       
                                              string patientID, 
                                              string studyInstanceUID, 
                                              string seriesInstanceUID, 
                                              string sopInstanceUID, 
                                              DownloadStatus status)
      {
         List<DownloadInfo> di = new List<DownloadInfo>();

         JobsProxy jsp = new JobsProxy(_DownloadJobsDataAccessAgent);
         JobProxy[] jpa = jsp.GetAll(EncodeStatus(status), EncodeCompletedStatus(status), sUserName);

         foreach (JobProxy jp in jpa)
         {
            if (jp.Match(patientID,
                     studyInstanceUID,
                     seriesInstanceUID,
                     sopInstanceUID))
            {
               di.Add(UpdateDownloadInfoStatus(sUserName, new DownloadInfo() { Id = jp.Id.ToString() }));
            }
         }

         return di.ToArray();
      }

      private JobProxy.CompletedStatus EncodeCompletedStatus(DownloadStatus downloadstatus)
      {
         JobProxy.CompletedStatus status = JobProxy.CompletedStatus.undefined;

         switch (downloadstatus)
         {
            case DownloadStatus.Completed:
               {
                  status = JobProxy.CompletedStatus.success;
               }
               break;
            case DownloadStatus.Aborted:
               {
                  status = JobProxy.CompletedStatus.aborted;
               }
               break;
            case DownloadStatus.Error:
               {
                  status = JobProxy.CompletedStatus.failed;
               }
               break;
         }

         return status;
      }
      
      private JobProxy.Status EncodeStatus(DownloadStatus downloadstatus)
      {
         JobProxy.Status status = JobProxy.Status.undefined;

         switch (downloadstatus)
         {
            case DownloadStatus.Idle:
               {
                  status = JobProxy.Status.idle;
               }
               break;
            case DownloadStatus.Started:
               {
                  status = JobProxy.Status.running;
               }
               break;
            case DownloadStatus.Completed:
            case DownloadStatus.Aborted:
            case DownloadStatus.Error:
               {
                  status = JobProxy.Status.completed;
               }
               break;
         }

         return status;
      }

      private DownloadStatus DecodeStatus(JobProxy.Status status, JobProxy.CompletedStatus completedstatus)
      {
         DownloadStatus downloadstatus;

         switch (status)
         {
            case JobProxy.Status.idle:
               {
                  downloadstatus = DownloadStatus.Idle;
               }
               break;
            case JobProxy.Status.pending:
            case JobProxy.Status.running:
               {
                  downloadstatus = DownloadStatus.Started;
               }
               break;
            case JobProxy.Status.completed:
               {
                  switch (completedstatus)
                  {
                     case JobProxy.CompletedStatus.success:
                        {
                           downloadstatus = DownloadStatus.Completed;
                        }
                        break;

                     case JobProxy.CompletedStatus.aborted:
                        {
                           downloadstatus = DownloadStatus.Aborted;
                        }
                        break;

                     case JobProxy.CompletedStatus.failed:
                        {
                           downloadstatus = DownloadStatus.Error;
                        }
                        break;

                     default:
                        {
                           throw new Exception();
                        }
                  }
               }
               break;
            default:
               {
                  throw new Exception();
               }
         }

         return downloadstatus;
      }

      public DownloadInfo UpdateDownloadInfoStatus(string sUserName, DownloadInfo info)
      {
         JobProxy.Status status = JobProxy.Status.idle;
         JobProxy.CompletedStatus completedstatus = JobProxy.CompletedStatus.failed;
         string sError = string.Empty;
         string sUserData = string.Empty;
         string sOwner = string.Empty;

         string PatientID= string.Empty;
         string StudyInstanceUID= string.Empty;
         string SeriesInstanceUID= string.Empty;
         string SOPInstanceUID= string.Empty;
         string ServerAE= string.Empty;
         string ServerIP= string.Empty;
         int ServerPort= 0;
         int ServerTimeout= 0;
         string ClientAE= string.Empty;
         string MoveToClientAE= string.Empty;
         string ClientIP= string.Empty;
         int ClientPort= 0;

         JobProxy jp = new JobProxy(_DownloadJobsDataAccessAgent) { Id = int.Parse(info.Id) };

         //mini status
         //jp.GetStatus(out status, out completedstatus, out sError, out sUserData);

         //whole status
         jp.GetAllDetails
         (
         out status,
         out completedstatus,
         out sError,
         out sUserData,
         out sOwner,
         out PatientID,
         out StudyInstanceUID,
         out SeriesInstanceUID,
         out SOPInstanceUID,
         out ServerAE,
         out ServerIP,
         out ServerPort,
         out ServerTimeout,
         out ClientAE,
         out MoveToClientAE,
         out ClientIP,
         out ClientPort
         );

         return new DownloadInfo()
         {
            Id = info.Id,
            Status = DecodeStatus(status, completedstatus),
            ErrorMessage = sError,
            UserData = sUserData,

            PatientID = PatientID,
            StudyInstanceUID =StudyInstanceUID ,
            SeriesInstanceUID =SeriesInstanceUID ,
            SOPInstanceUID = SOPInstanceUID,

            Server = new PACSConnection()
            {
               IPAddress = ServerIP,
               Port = ServerPort,
               AETitle = ServerAE
            },

            Client = new ClientConnection()
            {
               AETitle = ClientAE
            }
         };
      }

      public PACSConnection LocalClient { get; set; }
      public PACSConnection StorageServer { get; set; }
   }
}
