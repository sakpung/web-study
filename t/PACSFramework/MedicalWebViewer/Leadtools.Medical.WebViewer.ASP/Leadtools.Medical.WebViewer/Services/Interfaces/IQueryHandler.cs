// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************

using Leadtools.Medical.WebViewer.DataContracts;
using System.Threading.Tasks;

namespace Leadtools.Medical.WebViewer.Services.Interfaces
{
   /// <summary>
   /// Queries local database for patients, studies, series and instances.
   /// </summary>
   /// <remarks>
   /// Local database (or PACS) address is stored in Web config at the server. Use GetQueryServiceInfo to get the its options
   /// Each operation in the services must specify what role it falls into. You must first call IsUserInRole to check if the user
   /// can perform the operation
   /// </remarks>

   public interface IQueryHandler
   {
      /// <summary>
      /// Find patients
      /// </summary>
      /// <param name="authenticationCookie">Cookie</param>
      /// <param name="options">Query options</param>
      /// <param name="extraOptions">Extra options</param>
      /// <returns>Patients found</returns>
      /// <remarks>
      /// <para>RoleName:CanQuery</para>
      /// </remarks>
      Task<PatientData[]> FindPatients(string authenticationCookie, QueryOptions options, ExtraOptions extraOptions);

      /// <summary>
      /// Find studies
      /// </summary>
      /// <param name="authenticationCookie">Cookie</param>
      /// <param name="options">Query options</param>
      /// <param name="extraOptions">Extra options</param>
      /// <returns>Studies found</returns>
      /// <remarks>
      /// <para>RoleName:CanQuery</para>
      /// </remarks>
      Task<StudyData[]> FindStudies(string authenticationCookie, QueryOptions options, ExtraOptions extraOptions);

      /// <summary>
      /// Find series
      /// </summary>
      /// <param name="authenticationCookie">Cookie</param>
      /// <param name="options">Query options</param>
      /// <param name="extraOptions">Extra options</param>
      /// <returns>Series found</returns>
      /// <remarks>
      /// <para>RoleName:CanQuery</para>
      /// </remarks>
      Task<SeriesData[]> FindSeries(string authenticationCookie, QueryOptions options, ExtraOptions extraOptions);

      Task<InstanceData[]> FindInstances(string authenticationCookie, QueryOptions options, string baseUrl, ExtraOptions extraOptions);

      /// <summary>
      /// finds best representing instances for a study's series(s)
      /// </summary>
      /// <param name="authenticationCookie">Cookie</param>
      /// <param name="options">Query options</param>
      /// <returns>Instances found</returns>
      DICOMQueryResult ElectStudyTimeLineInstances(string authenticationCookie, QueryOptions options);

      PresentationStateData[] FindPresentationState(string authenticationCookie, string referencedSeries, string userData);

      bool HasPresentationState(string authenticationCookie, string seriesInstanceUID, string sopInstanceUID, string userData);

      WordResult[] AutoComplete(string authenticationCookie, string key, string term, string userData);

      HangingProtocolQueryResult[] FindHangingProtocols(string authenticationCookie, string studyInstanceUID, string userData);
   }
}
