// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;

using Leadtools.Medical.WebViewer.DataContracts;
using System.ServiceModel.Web;

namespace Leadtools.Medical.WebViewer.ServiceContracts
{
   /// <summary>
   /// Queries PACS for patients, studies, series and instance
   /// </summary>
   /// <remarks>
   /// The local PACS connection is stored in web config. You can get this info using GetLocalPACSInfo.
   /// Each operation in the services must specify what role it falls into. You must first call IsUserInRole to check if the user
   /// can perform the operation
   /// </remarks>
   [ServiceContract]
   public interface IPACSQueryService
   {
      /// <summary>
      /// Gets the local database info, required to return local AETitle, anything else is up to implementer
      /// </summary>
      /// <param name="authenticationCookie">Cookie</param>
      /// <param name="extraOptions">Extra options</param>
      /// <returns>Client connection info</returns>
      /// <remarks>
      /// Put extraOptions in returned ClientConnection.ExtraOptions in default implementation
      /// <para>RoleName:CanQueryServiceInfo</para>
      /// </remarks>
      [OperationContract]
      [WebGet( RequestFormat = WebMessageFormat.Json, 
               ResponseFormat = WebMessageFormat.Json,
               UriTemplate = "/GetConnectionInfo")]
      PACSConnection[] GetConnectionInfo();

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
      [OperationContract]
      [WebInvokeAttribute(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
      PatientData[] FindPatients(string authenticationCookie, PACSConnection server, ClientConnection client, QueryOptions options, ExtraOptions extraOptions);

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
      [OperationContract]
      [WebInvokeAttribute(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
      StudyData[] FindStudies(string authenticationCookie, PACSConnection server, ClientConnection client, QueryOptions options, ExtraOptions extraOptions);

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
      [OperationContract]
      [WebInvokeAttribute(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
      SeriesData[] FindSeries(string authenticationCookie, PACSConnection server, ClientConnection client, QueryOptions options, ExtraOptions extraOptions);

      [OperationContract]
      [WebInvokeAttribute(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
      InstanceData[] FindInstances(string authenticationCookie, PACSConnection server, ClientConnection client, QueryOptions options, ExtraOptions extraOptions);

      /// <summary>
      /// finds best representing instances for a study's series(s)
      /// </summary>
      /// <param name="authenticationCookie">Cookie</param>
      /// <param name="server">Server info</param>
      /// <param name="client">Client info, only ClientAE is used</param>
      /// <param name="options">Query options</param>
      /// <param name="extraOptions">Extra options</param>
      /// <returns>Instances found</returns>
      [OperationContract]
      [WebInvokeAttribute(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
      DICOMQueryResult ElectStudyTimeLineInstances(string authenticationCookie, PACSConnection server, ClientConnection client, QueryOptions options, ExtraOptions extraOptions);

      [OperationContract]
      [WebInvokeAttribute(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
      string VerifyConnection(string authenticationCookie, PACSConnection server, ClientConnection client, ExtraOptions extraOptions);
   }
}
