// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using Leadtools.Medical.WebViewer.Common;
using Leadtools.Medical.WebViewer.DataContracts;
using Leadtools.Medical.WebViewer.ServiceContracts;
using Leadtools.Medical.WebViewer.Services.Interfaces;
using Microsoft.Practices.Unity;
using System;
using System.Threading.Tasks;

namespace Leadtools.Medical.WebViewer.Services.Implementation
{
   public class QueryHandler : IQueryHandler
   {
      Lazy<IQueryAddin> _queryAddin;

      public QueryHandler(AddinsFactory factory)
      {
         _queryAddin = new Lazy<IQueryAddin>(() => { return factory.CreateQueryAddin(); });
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
            if (extraOptions != null && extraOptions.UserData2 != null)
            {
               return extraOptions.UserData2;
            }
         return string.Empty;
      }

      public Task<PatientData[]> FindPatients(string authenticationCookie, DataContracts.QueryOptions options, ExtraOptions extraOptions)
      {
         var userName = AuthHandler.Authorize(authenticationCookie, PermissionsTable.Instance.CanQuery);

         return Task.Factory.StartNew(() => _queryAddin.Value.FindPatients(userName, options, MaxQueryResults(extraOptions)));
      }

      public Task<StudyData[]> FindStudies(string authenticationCookie, DataContracts.QueryOptions options, DataContracts.ExtraOptions extraOptions)
      {
         var userName = AuthHandler.Authorize(authenticationCookie, PermissionsTable.Instance.CanQuery);

         return Task.Factory.StartNew(() => _queryAddin.Value.FindStudies(userName, options, MaxQueryResults(extraOptions), ReadModalitiesInStudy(extraOptions)));
      }

      public Task<SeriesData[]> FindSeries(string authenticationCookie, DataContracts.QueryOptions options, DataContracts.ExtraOptions extraOptions)
      {
         var userName = AuthHandler.Authorize(authenticationCookie, PermissionsTable.Instance.CanQuery);

         return Task.Factory.StartNew(() => _queryAddin.Value.FindSeries(userName, options, MaxQueryResults(extraOptions), LightQuery(extraOptions)));
      }

      public Task<InstanceData[]> FindInstances(string authenticationCookie, DataContracts.QueryOptions options, string baseUrl, DataContracts.ExtraOptions extraOptions)
      {
         var userName = AuthHandler.Authorize(authenticationCookie, PermissionsTable.Instance.CanQuery);

         return Task.Factory.StartNew(() => _queryAddin.Value.FindInstances(userName, options, MaxQueryResults(extraOptions), LightQuery(extraOptions), NoSort(extraOptions), StackInstanceUID(extraOptions)));
      }

      public PresentationStateData[] FindPresentationState(string authenticationCookie, string referencedSeries, string userData)
      {
         var userName = AuthHandler.Authorize(authenticationCookie, PermissionsTable.Instance.CanQuery);

         return _queryAddin.Value.FindPresentationState(userName, referencedSeries, userData);
      }

      public bool HasPresentationState(string authenticationCookie, string seriesInstanceUID, string sopInstanceUID, string userData)
      {
         var userName = AuthHandler.Authorize(authenticationCookie, PermissionsTable.Instance.CanQuery);

         return _queryAddin.Value.HasPresentationState(userName, seriesInstanceUID, sopInstanceUID, userData);
      }

      public DICOMQueryResult ElectStudyTimeLineInstances(string authenticationCookie, QueryOptions options)
      {
         var userName = AuthHandler.Authorize(authenticationCookie, PermissionsTable.Instance.CanQuery);

         return _queryAddin.Value.ElectStudyTimeLineInstances(userName, options, authenticationCookie);
      }

      public WordResult[] AutoComplete(string authenticationCookie, string key, string term, string userData)
      {
         var userName = AuthHandler.Authorize(authenticationCookie, PermissionsTable.Instance.CanQuery);

         return _queryAddin.Value.AutoComplete(userName, key, term, userData);
      }

      public HangingProtocolQueryResult[] FindHangingProtocols(string authenticationCookie, string studyInstanceUID, string userData)
      {
         var userName = AuthHandler.Authorize(authenticationCookie, PermissionsTable.Instance.CanQuery);

         return _queryAddin.Value.FindHangingProtocols(userName, studyInstanceUID, userData);
      }

   }
}
