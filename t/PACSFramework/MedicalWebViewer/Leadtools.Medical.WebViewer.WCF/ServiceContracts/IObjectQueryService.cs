// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;
using System.IO;

using Leadtools.Medical.WebViewer.DataContracts;
using System.ServiceModel.Web;
using Leadtools.Dicom.Common.DataTypes.HangingProtocol;

namespace Leadtools.Medical.WebViewer.ServiceContracts
{
   /// <summary>
   /// Queries local database for patients, studies, series and instances.
   /// </summary>
   /// <remarks>
   /// Local database (or PACS) address is stored in Web config at the server. Use GetQueryServiceInfo to get the its options
   /// Each operation in the services must specifiy what role it falls into. You must first call IsUserInRole to check if the user
   /// can perform the operation
   /// </remarks>
   [ServiceContract]
   public interface IObjectQueryService
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
      [OperationContract]
      [WebInvokeAttribute(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
      PatientData[] FindPatients(string authenticationCookie, QueryOptions options, ExtraOptions extraOptions);

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
      [OperationContract]
      [WebInvokeAttribute( Method="POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
      StudyData[] FindStudies(string authenticationCookie, QueryOptions options, ExtraOptions extraOptions);

      /// <summary>
      /// Find series
      /// </summary>
      /// <param name="authenticationCookie">Cookie</param>
      /// <param name="options">Query options</param>
      /// <param name="filterOptions">Filter options</param>
      /// <param name="extraOptions">Extra options</param>
      /// <returns>Series found</returns>
      /// <remarks>
      /// <para>RoleName:CanQuery</para>
      /// </remarks>
      [OperationContract]
      [WebInvokeAttribute(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
      SeriesData[] FindSeries(string authenticationCookie, QueryOptions options, ExtraOptions extraOptions);

      [OperationContract]
      [WebInvokeAttribute(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
      InstanceData[] FindInstances(string authenticationCookie, QueryOptions options, ExtraOptions extraOptions);

      /// <summary>
      /// finds best representing instances for a study's series(s)
      /// </summary>
      /// <param name="authenticationCookie">Cookie</param>
      /// <param name="options">Query options</param>
      /// <param name="extraOptions">Extra options</param>
      /// <returns>Instances found</returns>
      [OperationContract]
      [WebInvokeAttribute(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
      DICOMQueryResult ElectStudyTimeLineInstances(string authenticationCookie, QueryOptions options, ExtraOptions extraOptions);

      [OperationContract]
      [WebGet( UriTemplate = "/FindPresentationState?auth={authenticationCookie}&series={referencedSeries}&data={userData}",
               RequestFormat = WebMessageFormat.Json, 
               ResponseFormat = WebMessageFormat.Json)]
      PresentationStateData[] FindPresentationState (string authenticationCookie, string referencedSeries,  string userData) ;

      [OperationContract]
      [WebGet(UriTemplate = "/HasPresentationState?auth={authenticationCookie}&series={seriesInstanceUID}&instance={sopInstanceUID}&data={userData}",
              RequestFormat = WebMessageFormat.Json,
              ResponseFormat = WebMessageFormat.Json)]
      bool HasPresentationState(string authenticationCookie, string seriesInstanceUID, string sopInstanceUID, string userData);

      [OperationContract]
      [WebGet(UriTemplate = "/AutoComplete?auth={authenticationCookie}&key={key}&term={term}&data={userData}",
              RequestFormat = WebMessageFormat.Json,
              ResponseFormat = WebMessageFormat.Json)]
      WordResult[] AutoComplete(string authenticationCookie, string key, string term, string userData);
      
#if (LEADTOOLS_V19_OR_LATER)
        [OperationContract]
        [WebInvokeAttribute(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        HangingProtocolQueryResult[] FindHangingProtocols(string authenticationCookie, string studyInstanceUID, string userData);
#endif 
    }   
}
