// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using Leadtools.Medical.WebViewer.Common;
using Leadtools.Medical.WebViewer.DataContracts;
using Leadtools.Medical.WebViewer.ServiceContracts;
using Leadtools.Medical.WebViewer.Services.Interfaces;
using Leadtools.Medical.WebViewer.Wado;
using Leadtools.Medical.WebViewerModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Leadtools.Medical.WebViewer.Services.Implementation
{
   public class WadoQueryHandler : IQueryHandler
   {
      private IRemoteQueryAddin _query;

      public WadoQueryHandler(AddinsFactory factory)
      {
         _query = factory.CreateWadoQueryAddin();
      }

      private int MaxQueryResults(ExtraOptions extraOptions)
      {
         if (extraOptions != null && extraOptions.UserData != null)
         {
            return Convert.ToInt32(extraOptions.UserData);
         }
         return 0;
      }
      private bool ReadModalitiesInStudy(ExtraOptions extraOptions)
      {
         if (extraOptions != null && extraOptions.UserData2 != null)
         {
            return (extraOptions.UserData2.ToLower() == "readmodalitiesinstudy");
         }
         return false;
      }

      private bool LightQuery(ExtraOptions extraOptions)
      {
         if (extraOptions != null && extraOptions.UserData2 != null)
         {
            return (extraOptions.UserData2.ToLower() == "lightQuery");
         }
         return false;
      }

      private bool NoSort(ExtraOptions extraOptions)
      {
         if (extraOptions != null && extraOptions.UserData3 != null)
         {
            return (extraOptions.UserData3.ToLower() == "nosort");
         }
         return false;
      }

      private string StackInstanceUID(ExtraOptions extraOptions)
      {
         if (!LightQuery(extraOptions))
            if (extraOptions != null && extraOptions.UserData3 != null)
            {
               return extraOptions.UserData2;
            }
         return string.Empty;
      }
      
      public Task<PatientData[]> FindPatients(string authenticationCookie, DataContracts.QueryOptions options, ExtraOptions extraOptions)
      {
         AuthHandler.Authorize(authenticationCookie, PermissionsTable.Instance.CanQuery);
         return null;

         //this may be implemented as follows:
         //var config = RemoteConnectionFactory.Config(new WadoConnection() { dicomWebRoot = @"http://localhost/WadoService/api/", qido = "qido-rs" });
         //var patients = await _query.FindPatients(config , options);
         //return patients;
         //MaxQueryResults(extraOptions)
         
      }

      public Task<StudyData[]> FindStudies(string authenticationCookie, DataContracts.QueryOptions options, DataContracts.ExtraOptions extraOptions)
      {
         AuthHandler.Authorize(authenticationCookie, PermissionsTable.Instance.CanQuery);
         return null;
         
         //this may be implemented as follows:
         //var config = RemoteConnectionFactory.Config(new WadoConnection() { dicomWebRoot = @"http://localhost/WadoService/api/", qido = "qido-rs" });
         //var studies = await _query.FindStudies(config , options);
         //return studies;
         //MaxQueryResults(extraOptions)
         //ReadModalitiesInStudy(extraOptions) 
      }

      public Task<SeriesData[]> FindSeries(string authenticationCookie, DataContracts.QueryOptions options, DataContracts.ExtraOptions extraOptions)
      {
         AuthHandler.Authorize(authenticationCookie, PermissionsTable.Instance.CanQuery);
         return null;

         //this may be implemented as follows:
         //var config = RemoteConnectionFactory.Config(new WadoConnection() { dicomWebRoot = @"http://localhost/WadoService/api/", qido = "qido-rs" });
         //var series = await _query.FindSeries(config , options);
         //return series;
         //MaxQueryResults(extraOptions)
         //LightQuery(extraOptions) 
      }

      public Task<InstanceData[]> FindInstances(string authenticationCookie, DataContracts.QueryOptions options, string baseUrl, DataContracts.ExtraOptions extraOptions)
      {
         AuthHandler.Authorize(authenticationCookie, PermissionsTable.Instance.CanQuery);
         return null;

         //this may be implemented as follows:
         //var config = RemoteConnectionFactory.Config(new WadoConnection() { dicomWebRoot = @"http://localhost/WadoService/api/", qido = "qido-rs" });
         //var instances = await _query.FindInstances(config , options);
         //return instances;
         //authenticationCookie, 
         //MaxQueryResults(extraOptions), 
         //LightQuery(extraOptions), 
         //NoSort(extraOptions), 
         //StackInstanceUID(extraOptions), 
         //TimeStampProvider.GetTimeStamp(), 
      }

      public PresentationStateData[] FindPresentationState(string authenticationCookie, string referencedSeries, string userData)
      {
         AuthHandler.Authorize(authenticationCookie, PermissionsTable.Instance.CanQuery);

         return null;
      }

      public bool HasPresentationState(string authenticationCookie, string seriesInstanceUID, string sopInstanceUID, string userData)
      {
         return false;
      }

      public DICOMQueryResult ElectStudyTimeLineInstances(string authenticationCookie, QueryOptions options)
      {
         AuthHandler.Authorize(authenticationCookie, PermissionsTable.Instance.CanQuery);
         return null;
      }

      public WordResult[] AutoComplete(string authenticationCookie, string key, string term, string userData)
      {
         return null;
      }

      public HangingProtocolQueryResult[] FindHangingProtocols(string authenticationCookie, string studyInstanceUID, string userData)
      {
         return null;
      }

   }
}
