// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using Leadtools.Medical.WebViewer.DataContracts;
using Leadtools.Medical.WebViewer.Services.Interfaces;
using Leadtools.Medical.WebViewer.ServiceContracts;
using Leadtools.Medical.WebViewer.Wado;
using System.Threading.Tasks;
using Leadtools.Medical.WebViewerModels;

namespace Leadtools.Medical.WebViewer.Services.Implementation
{
   /// <summary>
   /// query remote PACS for DICOM information (Patient, Study, series and instance level).
   /// Mostly delegates all functionality to the PACS Query Addin after authentication and authorization
   /// </summary>

   public class PacsQueryHandler : IPacsQueryHandler
   {
      IPACSQueryAddin _pacsquery;

      public PacsQueryHandler(AddinsFactory factory)
      {
         _pacsquery = factory.CreatePacsQueryAddin();
      }

      #region IPACSQueryHandler

      public Task<PatientData[]> FindPatients(string authenticationCookie, RemoteConnection server, ClientConnection client, QueryOptions options)
      {
         AuthHandler.Authorize(authenticationCookie, PermissionsTable.Instance.CanQueryPACS);

         return Task.Factory.StartNew(() => _pacsquery.FindPatients(server as PACSConnection, client, options));
      }

      public Task<StudyData[]> FindStudies(string authenticationCookie, RemoteConnection server, ClientConnection client, QueryOptions options)
      {
         AuthHandler.Authorize(authenticationCookie, PermissionsTable.Instance.CanQueryPACS);

         return Task.Factory.StartNew<StudyData[]>(() => _pacsquery.FindStudies(server as PACSConnection, client, options));
      }

      public Task<SeriesData[]> FindSeries(string authenticationCookie, RemoteConnection server, ClientConnection client, QueryOptions options)
      {
         AuthHandler.Authorize(authenticationCookie, PermissionsTable.Instance.CanQueryPACS);

         return Task.Factory.StartNew(() => _pacsquery.FindSeries(server as PACSConnection, client, options));
      }

      public Task<InstanceData[]> FindInstances(string authenticationCookie, RemoteConnection server, ClientConnection client, QueryOptions options)
      {
         AuthHandler.Authorize(authenticationCookie, PermissionsTable.Instance.CanQueryPACS);

         return Task.Factory.StartNew(() => _pacsquery.FindInstances(server as PACSConnection, client, options));
      }

      public Task<string> VerifyConnection(string authenticationCookie, RemoteConnection server, ClientConnection client)
      {
         AuthHandler.Authenticate(authenticationCookie);

         return Task.Factory.StartNew(() => _pacsquery.VerifyConnection(server as PACSConnection, client));
      }

      private static int CompareFunc(InstanceData x, InstanceData y)
      {
         if (x.InstanceNumber == null)
         {
            if (y.InstanceNumber == null)
            {
               return 0;
            }
            else
            {
               return -1;
            }
         }
         else
         {
            if (y.InstanceNumber == null)
            {
               return 1;
            }
            else
            {
               int retval = x.InstanceNumber.Length.CompareTo(y.InstanceNumber.Length);

               if (retval != 0)
               {
                  return retval;
               }
               else
               {
                  return x.InstanceNumber.CompareTo(y.InstanceNumber);
               }
            }
         }
      }

      public async Task<DICOMQueryResult> ElectStudyTimeLineInstances(string authenticationCookie, RemoteConnection server, ClientConnection client, QueryOptions options)
      {
         DICOMQueryResult result = new DICOMQueryResult();

         StudyData[] StudiesDataArray = await FindStudies(authenticationCookie, server as PACSConnection, client, options);
         result.Studies = StudiesDataArray;

         SeriesData[] SeriesDataArray = await FindSeries(authenticationCookie, server as PACSConnection, client, options);

         result.Series = SeriesDataArray;

         List<InstanceData> AvailableInstancesList = new List<InstanceData>();

         if (null == options.SeriesOptions)
            options.SeriesOptions = new SeriesQueryOptions();

         foreach (SeriesData series in SeriesDataArray)
         {
            options.SeriesOptions.SeriesInstanceUID = series.InstanceUID;
            InstanceData[] objectsFound = await FindInstances(authenticationCookie, server as PACSConnection, client, options);
            if (objectsFound.Length > 0)
            {
               Array.Sort<InstanceData>(objectsFound, CompareFunc);

               if (string.IsNullOrEmpty(objectsFound[0].SeriesInstanceUID))
                  objectsFound[0].SeriesInstanceUID = series.InstanceUID;

               AvailableInstancesList.Add(objectsFound[0]);
            }
         }

         result.Instances = AvailableInstancesList.ToArray();

         return result;
      }

      #endregion
   }

   public class WadoAsPacsQueryHandler : IPacsQueryHandler
   {
      private IRemoteQueryAddin _query;

      public WadoAsPacsQueryHandler(AddinsFactory factory)
      {
         _query = factory.CreateWadoQueryAddin();
      }

      public async Task<PatientData[]> FindPatients(string authenticationCookie, RemoteConnection server, ClientConnection client, QueryOptions options)
      {
         AuthHandler.Authorize(authenticationCookie, PermissionsTable.Instance.CanQueryPACS);

         var patients = await _query.FindPatients(RemoteConnectionFactory.Config(server as WadoConnection), options);
         return patients;
      }

      public async Task<StudyData[]> FindStudies(string authenticationCookie, RemoteConnection server, ClientConnection client, QueryOptions options)
      {
         AuthHandler.Authorize(authenticationCookie, PermissionsTable.Instance.CanQueryPACS);

         var studies = await _query.FindStudies(RemoteConnectionFactory.Config(server as WadoConnection), options);
         return studies;
      }

      public async Task<SeriesData[]> FindSeries(string authenticationCookie, RemoteConnection server, ClientConnection client, QueryOptions options)
      {
         AuthHandler.Authorize(authenticationCookie, PermissionsTable.Instance.CanQueryPACS);

         var series = await _query.FindSeries(RemoteConnectionFactory.Config(server as WadoConnection), options);
         return series;
      }

      public async Task<InstanceData[]> FindInstances(string authenticationCookie, RemoteConnection server, ClientConnection client, QueryOptions options)
      {
         AuthHandler.Authorize(authenticationCookie, PermissionsTable.Instance.CanQueryPACS);

         var instances = await _query.FindInstances(RemoteConnectionFactory.Config(server as WadoConnection), options);
         return instances;
      }

      public async Task<string> VerifyConnection(string authenticationCookie, RemoteConnection server, ClientConnection client)
      {
         return await Task.Factory.StartNew<string>(() => string.Empty );
      }

      public async Task<DICOMQueryResult> ElectStudyTimeLineInstances(string authenticationCookie, RemoteConnection server, ClientConnection client, QueryOptions options)
      {
         DICOMQueryResult result = new DICOMQueryResult();

         StudyData[] StudiesDataArray = await FindStudies(authenticationCookie, server as PACSConnection, client, options);
         result.Studies = StudiesDataArray;

         SeriesData[] SeriesDataArray = await FindSeries(authenticationCookie, server as PACSConnection, client, options);

         result.Series = SeriesDataArray;

         List<InstanceData> AvailableInstancesList = new List<InstanceData>();

         if (null == options.SeriesOptions)
            options.SeriesOptions = new SeriesQueryOptions();

         foreach (SeriesData series in SeriesDataArray)
         {
            options.SeriesOptions.SeriesInstanceUID = series.InstanceUID;
            InstanceData[] objectsFound = await FindInstances(authenticationCookie, server as PACSConnection, client, options);
            if (objectsFound.Length > 0)
            {
               Array.Sort<InstanceData>(objectsFound, CompareFunc);

               if (string.IsNullOrEmpty(objectsFound[0].SeriesInstanceUID))
                  objectsFound[0].SeriesInstanceUID = series.InstanceUID;

               AvailableInstancesList.Add(objectsFound[0]);
            }
         }

         result.Instances = AvailableInstancesList.ToArray();

         return result;
      }

      private static int CompareFunc(InstanceData x, InstanceData y)
      {
         if (x.InstanceNumber == null)
         {
            if (y.InstanceNumber == null)
            {
               return 0;
            }
            else
            {
               return -1;
            }
         }
         else
         {
            if (y.InstanceNumber == null)
            {
               return 1;
            }
            else
            {
               int retval = x.InstanceNumber.Length.CompareTo(y.InstanceNumber.Length);

               if (retval != 0)
               {
                  return retval;
               }
               else
               {
                  return x.InstanceNumber.CompareTo(y.InstanceNumber);
               }
            }
         }
      }
   }
}
