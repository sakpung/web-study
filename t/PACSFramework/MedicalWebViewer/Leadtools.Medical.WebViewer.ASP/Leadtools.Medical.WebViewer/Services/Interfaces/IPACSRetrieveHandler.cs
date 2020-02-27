// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************

using Leadtools.Medical.WebViewer.DataContracts;
using System.Threading.Tasks;

namespace Leadtools.Medical.WebViewer.Services.Interfaces
{

   public interface IPacsRetrieveHandler
   {
      /// <summary>
      /// Downloads the images for a patient, study or series
      /// </summary>
      /// <returns>Download info. Status could be Completed, Error or Aborted</returns>
      /// <remarks>
      /// retrieve level, so if SOP Instance UID is provided then it is image level if Series Instance UID is provided then it is Series and so on for Study UID and Patient ID.
      /// This method blocks till the download completes, errors out or gets aborted. Internally, the implementer should create a thread
      /// and finish the download in it
      /// Each operation in the services must specify what role it falls into. You must first call IsUserInRole to check if the user
      /// can perform the operation
      /// <para>RoleName:CanDownloadImages</para>
      /// </remarks>
      Task<DownloadInfo> DownloadImages(string authenticationCookie,
         RemoteConnection server,
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
      /// <returns>The updated download info</returns>
      /// <remarks>
      /// <para>RoleName:CanDownloadImages</para>
      /// </remarks>
      Task<DownloadInfo> UpdateDownloadInfoStatus(string authenticationCookie, DownloadInfo info);

      /// <summary>
      /// Gets the downloads' status for this user based on id
      /// </summary>
      /// <param name="authenticationCookie">Cookie</param>
      /// <param name="JobsIds">array of job ids</param>
      /// <returns>A list of the downloads' statuses for this user.</returns>
      /// <remarks>
      /// If options is null, then all the statuses are obtained. Otherwise, this works as the filter
      /// <para>RoleName:CanDownloadImages</para>
      /// </remarks>

      Task<JobStatus[]> GetJobStatus(string authenticationCookie, string[] JobsIds);

      /// <summary>
      /// Gets the downloads for this user based on options
      /// </summary>
      /// <param name="authenticationCookie">Cookie</param>
      /// <param name="server">Server info</param>
      /// <param name="client">Client info</param>
      /// <param name="patientID">Query options for patient</param>
      /// <param name="studyInstanceUID">Query options for study</param>
      /// <param name="seriesInstanceUID">Query options for series</param>
      /// <param name="sopInstanceUID">Query options for instance</param>
      /// <param name="status">Status interested in, pass 'All' to get all</param>
      /// <returns>A list of the downloads for this user.</returns>
      /// <remarks>
      /// If options is null, then all the infos are obtained. Otherwise, this works as the filter
      /// <para>RoleName:CanDownloadImages</para>
      /// </remarks>

      Task<DownloadInfo[]> GetDownloadInfos(string authenticationCookie,
                                      RemoteConnection server,
                                      string client,
                                      string patientID,
                                      string studyInstanceUID,
                                      string seriesInstanceUID,
                                      string sopInstanceUID,
                                      DownloadStatus status);

      /// <summary>
      /// Deletes the images for this user based on options
      /// </summary>
      /// <param name="authenticationCookie">Cookie</param>      
      /// <param name="patientID">Patient ID</param>
      /// <param name="studyInstanceUID">StudyInstance UID</param>
      /// <param name="seriesInstanceUID">SeriesInstance UID</param>
      /// <param name="sopInstanceUID">SOPInstance UID</param>
      /// <remarks>
      /// If options is null, then all the images are deleted. Otherwise, this works as the filter
      /// <para>RoleName:CanDeleteImages</para>
      /// </remarks>
      Task DeleteImages(string authenticationCookie, string patientID,
               string studyInstanceUID,
               string seriesInstanceUID,
               string sopInstanceUID);

      Task DeleteDownloadInfos(string authenticationCookie, int[] jobIds);
   }
}
