// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************

using Leadtools.Medical.WebViewer.DataContracts;
using System.Threading.Tasks;

namespace Leadtools.Medical.WebViewer.Services.Interfaces
{
   /// <summary>
   /// Queries PACS for patients, studies, series and instance
   /// </summary>
   /// <remarks>
   /// The local PACS connection is stored in web config. You can get this info using GetLocalPACSInfo.
   /// Each operation in the services must specify what role it falls into. You must first call IsUserInRole to check if the user
   /// can perform the operation
   /// </remarks>
   public interface IPacsQueryHandler
   {
      /// <summary>
      /// Find patients
      /// </summary>
      /// <param name="authenticationCookie">Cookie</param>
      /// <param name="server">Server info</param>
      /// <param name="client">Client info</param>
      /// <param name="options">Query options</param>
      /// <returns>Patients found</returns>
      /// <remarks>
      /// <para>RoleName:CanQueryPACS</para>
      /// </remarks>
      Task<PatientData[]> FindPatients(string authenticationCookie, RemoteConnection server, ClientConnection client, QueryOptions options);

      /// <summary>
      /// Find studies
      /// </summary>
      /// <param name="authenticationCookie">Cookie</param>
      /// <param name="server">Server info</param>
      /// <param name="client">Client info, only ClientAE is used</param>
      /// <param name="options">Query options</param>
      /// <returns>Studies found</returns>
      /// <remarks>
      /// <para>RoleName:CanQueryPACS</para>
      /// </remarks>
      Task<StudyData[]> FindStudies(string authenticationCookie, RemoteConnection server, ClientConnection client, QueryOptions options);

      /// <summary>
      /// Find series
      /// </summary>
      /// <param name="authenticationCookie">Cookie</param>
      /// <param name="server">Server info</param>
      /// <param name="client">Client info, only ClientAE is used</param>
      /// <param name="options">Query options</param>
      /// <returns>Series found</returns>
      /// <remarks>
      /// <para>RoleName:CanQueryPACS</para>
      /// </remarks>
      Task<SeriesData[]> FindSeries(string authenticationCookie, RemoteConnection server, ClientConnection client, QueryOptions options);

      Task<InstanceData[]> FindInstances(string authenticationCookie, RemoteConnection server, ClientConnection client, QueryOptions options);

      /// <summary>
      /// finds best representing instances for a study's series(s)
      /// </summary>
      /// <param name="authenticationCookie">Cookie</param>
      /// <param name="server">Server info</param>
      /// <param name="client">Client info, only ClientAE is used</param>
      /// <param name="options">Query options</param>
      /// <returns>Instances found</returns>
      Task<DICOMQueryResult> ElectStudyTimeLineInstances(string authenticationCookie, RemoteConnection server, ClientConnection client, QueryOptions options);

      Task<string> VerifyConnection(string authenticationCookie, RemoteConnection server, ClientConnection client);
   }
}
