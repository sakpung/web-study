// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

using Leadtools.Medical.WebViewer.DataContracts;
using Leadtools.Dicom.Common.DataTypes.HangingProtocol;

namespace Leadtools.Medical.WebViewer.ServiceContracts
{
   /// <summary>
   /// Queries local database for patients, studies, series and instances.
   /// </summary>
   /// <remarks>
   /// Local database (or PACS) address is stored in Web config at the server. Use GetQueryServiceInfo to get the its options
   /// Each operation in the services must specify what role it falls into. You must first call IsUserInRole to check if the user
   /// can perform the operation
   /// </remarks>
   public interface IQueryAddin
   {
      /// <summary>
      /// Find patients
      /// </summary>
      /// <param name="authenticationCookie">Cookie</param>
      /// <param name="options">Query options</param>
      /// <param name="filterOptions">Filter options</param>
      /// <param name="extraOptions">Extra options</param>
      /// <returns>Patients found</returns>
      /// <remarks>
      /// <para>RoleName:CanQuery</para>
      /// </remarks>
      PatientData[] FindPatients(string userName, QueryOptions options, int maxQueryResults = 0);

      /// <summary>
      /// Find studies
      /// </summary>
      /// <param name="authenticationCookie">Cookie</param>
      /// <param name="options">Query options</param>
      /// <param name="filterOptions">Filter options</param>
      /// <param name="extraOptions">Extra options</param>
      /// <returns>Studies found</returns>
      /// <remarks>
      /// <para>RoleName:CanQuery</para>
      /// </remarks>
      StudyData[] FindStudies(string userName, QueryOptions options, int maxQueryResults = 0, bool readModalitiesInStudy = false);

      /// <summary>
      /// Find series
      /// </summary>
      /// <param name="options">Query options</param>
      /// <param name="filterOptions">Filter options</param>
      /// <param name="extraOptions">Extra options</param>
      /// <returns>Series found</returns>
      /// <remarks>
      /// <para>RoleName:CanQuery</para>
      /// </remarks>
      SeriesData[] FindSeries(string userName, QueryOptions options, int maxQueryResults = 0, bool lightQuery = false);

      InstanceData[] FindInstances(string userName, DataContracts.QueryOptions options, int maxQueryResults = 0, bool lightQuery = false, bool noSort = false, string stackInstanceUID = "");
      
      PresentationStateData[] FindPresentationState (string userName, string referencedSeries,  string userData);

      bool HasPresentationState(string userName, string referencedSeriesInstanceUID, string sopInstanceUID, string userData);

        HangingProtocolQueryResult[] FindHangingProtocols(string userName, string studyInstanceUID, string userData);

        WordResult[] AutoComplete(string user, string key, string term, string userData);

        DICOMQueryResult ElectStudyTimeLineInstances(string userName, DataContracts.QueryOptions options, string authCookie, string serviceUri = null);

#if LEADTOOLS_V19_OR_LATER
      bool ItemExists(string id);
      void LockTimeOut(string id);
      void UnlockTimeOut(string id);
      void Initialize3DObject(string id);
        string Start3DObject(string userName, DataContracts.QueryOptions options, bool cacheEnabled = true, string cachePath = "", string id = "", string stackInstanceUID = "", int renderingType = 1);

        Stream Get3DImage(string id = "", int x = 0, int y = 0, int width = 1, int height = 1, int resizeFactor = 0, string effect = "", int action = 0, float sensitivity = 1.0f, float ratio = 1.0f);

        Stream GetPanoramicImage(string id = "", int resizeFactor = 0, string polygonInfo = "", string polygonData = "");

        void Update3DSettings(string id = "", string options = "");

        void End3DObject(string id = "");

        string CheckProgress(string id = "");

        void KeepAlive(string id = "");

        string Get3DSettings(string id = "", string options = "");
#endif

   }
}
