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
   [ServiceContract]
   public interface IPACSRetrieveService
   {
      /// <summary>
      /// Downloads the images for a patient, study or series
      /// </summary>
      /// <param name="authenticationCookie">Cookie</param>
      /// <param name="server">Server info</param>
      /// <param name="client">Client info</param>
      /// <param name="string">PatientID</param>
      /// <param name="string">StudyInstanceUID</param>
      /// <param name="string">SeriesInstanceUID</param>
      /// <param name="string">SOPInstanceUID</param>
      /// <param name="extraOptions">Extra options</param>
      /// <returns>Download info. Status could be Completed, Error or Aborted</returns>
      /// <remarks>
      /// retrieve level, so if SOP Instance UID is provided then it is image level if Series Instance UID is provided then it is Series and so on for Study UID and Patient ID.
      /// This method blocks till the download completes, errors out or gets aborted. Internally, the implementer should create a thread
      /// and finish the download in it
      /// Each operation in the services must specify what role it falls into. You must first call IsUserInRole to check if the user
      /// can perform the operation
      /// <para>RoleName:CanDownloadImages</para>
      /// </remarks>
      [OperationContract]
      [WebInvokeAttribute(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
      DownloadInfo DownloadImages(string authenticationCookie, 
         PACSConnection server, 
         string client,
         string patientID, 
         string studyInstanceUID,
         string seriesInstanceUID,
         string sopInstanceUID,
         ExtraOptions extraOptions);

      /// <summary>
      /// Updates the download info. Status should eventually change
      /// </summary>
      /// <param name="authenticationCookie">Cookie</param>
      /// <param name="info">Download info to update</param>
      /// <param name="extraOptions">Extra options</param>
      /// <returns>The updated download info</returns>
      /// <remarks>
      /// <para>RoleName:CanDownloadImages</para>
      /// </remarks>
      [OperationContract]
      [WebInvokeAttribute(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
      DownloadInfo UpdateDownloadInfoStatus(string authenticationCookie, DownloadInfo info, ExtraOptions extraOptions);

      /// <summary>
      /// Gets the downloads' status for this user based on id
      /// </summary>
      /// <param name="authenticationCookie">Cookie</param>
      /// <param name="JobsIds">array of job ids</param>
      /// <param name="extraOptions">Extra options</param>
      /// <returns>A list of the downloads' statuses for this user.</returns>
      /// <remarks>
      /// If options is null, then all the statuses are obtained. Otherwise, this works as the filter
      /// <para>RoleName:CanDownloadImages</para>
      /// </remarks>

      [OperationContract]
      [WebInvokeAttribute(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
      JobStatus[] GetJobStatus(string authenticationCookie, string[] JobsIds, ExtraOptions extraOptions);

      /// <summary>
      /// Gets the downloads for this user based on options
      /// </summary>
      /// <param name="authenticationCookie">Cookie</param>
      /// <param name="server">Server info</param>
      /// <param name="client">Client info</param>
      /// <param name="options">Query options, null to return all</param>
      /// <param name="status">Status interested in, pass 'All' to get all</param>
      /// <param name="extraOptions">Extra options</param>
      /// <returns>A list of the downloads for this user.</returns>
      /// <remarks>
      /// If options is null, then all the infos are obtained. Otherwise, this works as the filter
      /// <para>RoleName:CanDownloadImages</para>
      /// </remarks>
      
      [OperationContract]
      [WebInvokeAttribute(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
      DownloadInfo[] GetDownloadInfos(string authenticationCookie, 
                                      PACSConnection server, 
                                      string client, 
                                      string patientID, 
                                      string studyInstanceUID, 
                                      string seriesInstanceUID, 
                                      string sopInstanceUID,
                                      DownloadStatus status, 
                                      ExtraOptions extraOptions ) ;

      /// <summary>
      /// Deletes the images for this user based on options
      /// </summary>
      /// <param name="authenticationCookie">Cookie</param>      
      /// <param name="PatientID">Patient ID</param>
      /// <param name="StudyInstanceUID">StudyInstance UID</param>
      /// <param name="SeriesInstanceUID">SeriesInstance UID</param>
      /// <param name="SOPInstanceUID">SOPInstance UID</param>
      /// <param name="extraOptions">Extra options</param>
      /// <remarks>
      /// If options is null, then all the images are deleted. Otherwise, this works as the filter
      /// <para>RoleName:CanDeleteImages</para>
      /// </remarks>
      [OperationContract]
      [WebInvokeAttribute(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
      void DeleteImages(string authenticationCookie, string patientID,
               string studyInstanceUID,
               string seriesInstanceUID,
               string sopInstanceUID, ExtraOptions extraOptions);

      [OperationContract]
      [WebInvokeAttribute(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
      void DeleteDownloadInfos (string authenticationCookie, int[] jobIds, ExtraOptions extraOptions ) ;
   }
}
