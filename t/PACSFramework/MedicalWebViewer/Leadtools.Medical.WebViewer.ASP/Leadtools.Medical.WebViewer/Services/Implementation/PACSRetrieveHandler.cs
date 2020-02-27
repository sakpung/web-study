// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using Leadtools.Medical.WebViewer.DataContracts;
using Leadtools.Medical.WebViewer.Services.Interfaces;
using Leadtools.Medical.WebViewer.ServiceContracts;
using System.Threading.Tasks;
using Leadtools.Medical.WebViewer.Wado;
using Leadtools.Medical.WebViewerModels;
using Leadtools.Dicom;
using System;
using System.Collections.Generic;

namespace Leadtools.Medical.WebViewer.Services.Implementation
{
   /// <summary>
   /// The Handler retrieves DICOM images from remote server through the Storage Server. 
   /// Handler client sends a MOVE request to the remote server asking it to store the images into our local storage server.
   /// 
   /// </summary>

   public class PacsRetrieveHandler : IPacsRetrieveHandler
   {
      IPacsDownloadAddin _addin;

      public PacsRetrieveHandler(AddinsFactory factory)
      {
         _addin = factory.CreatePacsDownloadAddin();
      }

      public Task<DownloadInfo> DownloadImages
      (
         string authenticationCookie,
         RemoteConnection server,
         string client,
         string PatientID,
         string StudyInstanceUID,
         string SeriesInstanceUID,
         string SOPInstanceUID,
         ExtraOptions extraOptions
      )
      {
         var userName = AuthHandler.Authorize(authenticationCookie, PermissionsTable.Instance.CanDownloadImages);

         return Task.Factory.StartNew(() => _addin.DownloadImages(userName, server as PACSConnection, "LTSTORAGESERVER", PatientID, StudyInstanceUID, SeriesInstanceUID, SOPInstanceUID, null != extraOptions ? extraOptions.UserData : ""));
      }

      public Task<DownloadInfo> UpdateDownloadInfoStatus(string authenticationCookie, DownloadInfo info)
      {
         var userName = AuthHandler.Authorize(authenticationCookie, PermissionsTable.Instance.CanDownloadImages);

         return Task.Factory.StartNew(() => _addin.UpdateDownloadInfoStatus(userName, info));
      }

      public Task<JobStatus[]> GetJobStatus(string authenticationCookie, string[] JobsIds)
      {
         var userName = AuthHandler.Authorize(authenticationCookie, PermissionsTable.Instance.CanDownloadImages);

         return Task.Factory.StartNew(() => _addin.GetJobStatus(userName, JobsIds));

      }

      public Task<DownloadInfo[]> GetDownloadInfos
      (
         string authenticationCookie,
         RemoteConnection server,
         string client,
         string patientID,
         string studyInstanceUID,
         string seriesInstanceUID,
         string sopInstanceUID,
         DownloadStatus status)
      {
         var userName = AuthHandler.Authorize(authenticationCookie, PermissionsTable.Instance.CanDownloadImages);

         return Task.Factory.StartNew(() => _addin.GetDownloadInfos(userName,server as PACSConnection,client,patientID,studyInstanceUID,seriesInstanceUID,sopInstanceUID,status));
      }

      public Task DeleteDownloadInfos(string authenticationCookie, int[] jobIds)
      {
         var userName = AuthHandler.Authorize(authenticationCookie, PermissionsTable.Instance.CanDeleteDownloadInfo);

         return Task.Factory.StartNew(() => _addin.DeleteDownloadInfos(userName, jobIds));
      }

      public Task DeleteImages(string authenticationCookie,string patientID,string studyInstanceUID,string seriesInstanceUID,string sopInstanceUID)
      {
         var userName = AuthHandler.Authorize(authenticationCookie, PermissionsTable.Instance.CanDeleteImages);

         return Task.Factory.StartNew(() => _addin.DeleteImages(userName, patientID, studyInstanceUID, seriesInstanceUID, sopInstanceUID));
      }
   }

   public class WadoAsPacsRetrieveHandler : IPacsRetrieveHandler
   {
      private IRemoteQueryAddin _query;
      private IRemoteRetrieveAddin _ret;
      private IStoreAddin _store;
      
      public WadoAsPacsRetrieveHandler (AddinsFactory factory)
      {
         _query = factory.CreateWadoQueryAddin();
         _ret = factory.CreateWadoRetrieveAddin();
         _store = factory.CreateStoreAddin();
      }
      private async Task<List<string>> QuerySeries(RemoteConnection server, string PatientID, string StudyInstanceUID, string SeriesInstanceUID)
      {
         //study should be provided
         if(string.IsNullOrEmpty(StudyInstanceUID))
         {
            throw new ArgumentNullException("StudyInstanceUID");
         }

         //figure out series
         var SeriesInstanceUIDList = new List<string>();

         if(string.IsNullOrEmpty(SeriesInstanceUID))
         {
            var query = new QueryOptions()
            {
               StudiesOptions = new StudiesQueryOptions() { StudyInstanceUID = StudyInstanceUID },
               PatientsOptions = new PatientsQueryOptions() { PatientID = PatientID }
            };

            var series = await _query.FindSeries(RemoteConnectionFactory.Config(server as WadoConnection), query);

            foreach(var s in series)
            {
               SeriesInstanceUIDList.Add(s.InstanceUID);
            }
         }
         else
         {
            SeriesInstanceUIDList.Add(SeriesInstanceUID); //single series specified
         }

         return SeriesInstanceUIDList;
      }

      private async Task<List<string>> QueryInstances(RemoteConnection server, string PatientID, string StudyInstanceUID, string SeriesInstanceUID)
      {
         //study/series should be provided
         if(string.IsNullOrEmpty(StudyInstanceUID)||string.IsNullOrEmpty(SeriesInstanceUID))
         {
            throw new ArgumentNullException("StudyInstanceUID or SeriesInstanceUID");
         }

         var query = new QueryOptions()
         {
            SeriesOptions = new SeriesQueryOptions() { SeriesInstanceUID = SeriesInstanceUID },
            StudiesOptions = new StudiesQueryOptions() { StudyInstanceUID = StudyInstanceUID },
            PatientsOptions = new PatientsQueryOptions() { PatientID = PatientID }
         };

         var instances = await _query.FindInstances(RemoteConnectionFactory.Config(server as WadoConnection), query);

         var SOPInstanceUIDList = new List<string>();

         foreach (var instance in instances)
         {
            SOPInstanceUIDList.Add(instance.SOPInstanceUID);
         }

         return SOPInstanceUIDList;
      }

      private async Task<QueryOptions[]> Query(RemoteConnection server, string PatientID, string StudyInstanceUID, string SeriesInstanceUID, string SOPInstanceUID)
      {
         var ql = new List<QueryOptions>();

         //study should be provided
         if(string.IsNullOrEmpty(StudyInstanceUID))
         {
            throw new ArgumentNullException("StudyInstanceUID");
         }

         //figure out series
         var SeriesInstanceUIDList = await QuerySeries(server, PatientID, StudyInstanceUID, SeriesInstanceUID);

         foreach (var series in SeriesInstanceUIDList)
         {
            var SOPInstanceUIDList = await QueryInstances(server, PatientID, StudyInstanceUID, series);

            foreach (var instance in SOPInstanceUIDList)
            {
               var query = new QueryOptions()
               {
                  InstancesOptions = new InstancesQueryOptions() { SOPInstanceUID = instance },
                  SeriesOptions = new SeriesQueryOptions() { SeriesInstanceUID = series },
                  StudiesOptions = new StudiesQueryOptions() { StudyInstanceUID = StudyInstanceUID },
                  PatientsOptions = new PatientsQueryOptions() { PatientID = PatientID }
               };

               ql.Add(query);
            }
         }

         return ql.ToArray();
      }

      public async Task<DownloadInfo> DownloadImages
      (
         string authenticationCookie,
         RemoteConnection server,
         string client,
         string PatientID,
         string StudyInstanceUID,
         string SeriesInstanceUID,
         string SOPInstanceUID,
         ExtraOptions extraOptions
      )
      {
         try
         {
            var userName = AuthHandler.Authorize(authenticationCookie, PermissionsTable.Instance.CanDownloadImages);

            var queries = await Query(server, PatientID, StudyInstanceUID, SeriesInstanceUID, SOPInstanceUID);

            foreach (var query in queries)
            {
               using (var stream = await _ret.RetrieveDataset(RemoteConnectionFactory.Config(server as WadoConnection), query))
               using (var ds = new DicomDataSet())
               {
                  ds.Load(stream, DicomDataSetLoadFlags.None);
                  _store.DoStore(ds);                 
               }
            }

             return new DownloadInfo()
            {
               Id = "-1",
               Status = DownloadStatus.Completed
            };
         }
         catch(Exception e)
         {
            return new DownloadInfo()
               {
                  Id = "-1",
                  Status = DownloadStatus.Error,
                  ErrorMessage = e.Message
               };
         }
      }

      public Task<DownloadInfo> UpdateDownloadInfoStatus(string authenticationCookie, DownloadInfo info)
      {
         var userName = AuthHandler.Authorize(authenticationCookie, PermissionsTable.Instance.CanDownloadImages);

         return null;//return Task.Factory.StartNew(() => _addin.UpdateDownloadInfoStatus(userName, info));
      }

      public Task<JobStatus[]> GetJobStatus(string authenticationCookie, string[] JobsIds)
      {
         var userName = AuthHandler.Authorize(authenticationCookie, PermissionsTable.Instance.CanDownloadImages);

         return null;
      }

      public Task<DownloadInfo[]> GetDownloadInfos
      (
         string authenticationCookie,
         RemoteConnection server,
         string client,
         string patientID,
         string studyInstanceUID,
         string seriesInstanceUID,
         string sopInstanceUID,
         DownloadStatus status)
      {
         var userName = AuthHandler.Authorize(authenticationCookie, PermissionsTable.Instance.CanDownloadImages);

         return null;
      }

      public Task DeleteDownloadInfos(string authenticationCookie, int[] jobIds)
      {
         var userName = AuthHandler.Authorize(authenticationCookie, PermissionsTable.Instance.CanDeleteDownloadInfo);

         return null;
      }

      public Task DeleteImages(string authenticationCookie,string patientID,string studyInstanceUID,string seriesInstanceUID,string sopInstanceUID)
      {
         var userName = AuthHandler.Authorize(authenticationCookie, PermissionsTable.Instance.CanDeleteImages);

         return null;
      }
   }
}
