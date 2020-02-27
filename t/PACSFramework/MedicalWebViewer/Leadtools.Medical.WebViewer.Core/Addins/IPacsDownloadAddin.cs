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
   public interface IPacsDownloadAddin
   {
      /// <summary>
      /// Downloads the images for a patient, study or series
      /// </summary>
      /// <param name="sUserName">user name</param>
      /// <param name="server">Server info</param>
      /// <param name="client">Client info</param>
      /// <param name="PatientID">Patient ID</param>
      /// <param name="StudyInstanceUID">StudyInstance UID</param>
      /// <param name="SeriesInstanceUID">SeriesInstance UID</param>
      /// <param name="SOPInstanceUID">SOPInstance UID</param>
      /// <param name="extraOptions">Extra options</param>
      /// <returns>Download info. Status could be Completed, Error or Aborted</returns>
      /// <remarks>
      /// This method blocks till the download completes, errors out or gets aborted. Internally, the implementer should create a thread
      /// and finish the download in it
      /// Each operation in the services must specify what role it falls into. You must first call IsUserInRole to check if the user
      /// can perform the operation
      /// <para>RoleName:CanDownloadImages</para>
      /// </remarks>

      DownloadInfo DownloadImages(string sUserName, PACSConnection server, string MoveToAE, string PatientID, 
         string StudyInstanceUID,
         string SeriesInstanceUID,
         string SOPInstanceUID,
         string UserData);

      /// <summary>
      /// Updates the download info. Status should eventually change
      /// </summary>
      /// <param name="sUserName">user name</param>
      /// <param name="info">Download info to update</param>
      /// <param name="extraOptions">Extra options</param>
      /// <returns>The updated download info</returns>
      /// <remarks>
      /// <para>RoleName:CanDownloadImages</para>
      /// </remarks>
      
      DownloadInfo UpdateDownloadInfoStatus( string sUserName, DownloadInfo info);

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

      JobStatus[] GetJobStatus(string authenticationCookie, string[] JobsIds);

      /// <summary>
      /// Gets the downloads for this user based on options
      /// </summary>
      /// <param name="sUserName">user name</param>
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
      DownloadInfo[] GetDownloadInfos(string sUserName, 
                                       PACSConnection server, 
                                       string client,
                                       string patientID, 
                                       string studyInstanceUID, 
                                       string seriesInstanceUID, 
                                       string sopInstanceUID, 
                                       DownloadStatus status);

      /// <summary>
      /// Deletes the images for this user based on options
      /// </summary>
      /// <param name="sUserName">user name</param>
      /// <param name="server">Server info</param>
      /// <param name="client">Client info</param>
      /// <param name="PatientID">Patient ID</param>
      /// <param name="StudyInstanceUID">StudyInstance UID</param>
      /// <param name="SeriesInstanceUID">SeriesInstance UID</param>
      /// <param name="SOPInstanceUID">SOPInstance UID</param>
      /// <param name="extraOptions">Extra options</param>
      /// <remarks>
      /// If options is null, then all the images are deleted. Otherwise, this works as the filter
      /// <para>RoleName:CanDeleteImages</para>
      /// </remarks>
      void DeleteImages(string sUserName, 
         string PatientID,
         string StudyInstanceUID,
         string SeriesInstanceUID,
         string SOPInstanceUID);
   
      void DeleteDownloadInfos
      (
         string sUserName, 
         int[] jobIds
      ) ;
   }
}
