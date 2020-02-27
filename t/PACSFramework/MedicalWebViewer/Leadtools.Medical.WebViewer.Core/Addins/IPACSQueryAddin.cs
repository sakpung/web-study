// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Text;

using Leadtools.Medical.WebViewer.DataContracts;

namespace Leadtools.Medical.WebViewer.ServiceContracts
{
   /// <summary>
   /// Queries PACS for patients, studies, series and instance
   /// </summary>
   /// <remarks>
   /// The local PACS connection is stored in web config. You can get this info using GetLocalPACSInfo.
   /// Each operation in the services must specifiy what role it falls into. You must first call IsUserInRole to check if the user
   /// can perform the operation
   /// </remarks>
   public interface IPACSQueryAddin
   {
      /// <summary>
      /// Find patients
      /// </summary>
      /// <param name="authenticationCookie">Cookie</param>
      /// <param name="server">Server info</param>
      /// <param name="client">Client info</param>
      /// <param name="options">Query options</param>
      /// <param name="filterOptions">Filter options</param>
      /// <param name="extraOptions">Extra options</param>
      /// <returns>Patients found</returns>
      /// <remarks>
      /// <para>RoleName:CanQueryPACS</para>
      /// </remarks>
      PatientData[] FindPatients(PACSConnection server, ClientConnection client, QueryOptions options);

      /// <summary>
      /// Find studies
      /// </summary>
      /// <param name="authenticationCookie">Cookie</param>
      /// <param name="server">Server info</param>
      /// <param name="client">Client info, only ClientAE is used</param>
      /// <param name="options">Query options</param>
      /// <param name="filterOptions">Filter options</param>
      /// <param name="extraOptions">Extra options</param>
      /// <returns>Studies found</returns>
      /// <remarks>
      /// <para>RoleName:CanQueryPACS</para>
      /// </remarks>
      StudyData[] FindStudies(PACSConnection server, ClientConnection client, QueryOptions options);

      /// <summary>
      /// Find series
      /// </summary>
      /// <param name="authenticationCookie">Cookie</param>
      /// <param name="server">Server info</param>
      /// <param name="client">Client info, only ClientAE is used</param>
      /// <param name="options">Query options</param>
      /// <param name="filterOptions">Filter options</param>
      /// <param name="extraOptions">Extra options</param>
      /// <returns>Series found</returns>
      /// <remarks>
      /// <para>RoleName:CanQueryPACS</para>
      /// </remarks>
      SeriesData[] FindSeries(PACSConnection server, ClientConnection client, QueryOptions options);

      InstanceData[] FindInstances(PACSConnection server, ClientConnection client, QueryOptions options);

      string VerifyConnection(PACSConnection server, ClientConnection client);
   }
}
