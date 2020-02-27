// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

using Leadtools.Medical.WebViewer.DataContracts;
using Leadtools.Medical.WebViewer.Core.DataTypes;
using System.Threading.Tasks;

namespace Leadtools.Medical.WebViewer.Services.Interfaces
{
    /// <summary>
    /// Retrieves objects from local
    /// </summary>
    /// <remarks>
    /// Each operation in the services must specify what role it falls into. You must first call IsUserInRole to check if the user
    /// can perform the operation
    /// </remarks>

    public interface IRetrieveHandler
    {
        /// <summary>
        /// Gets a single image
        /// </summary>
        /// <remarks>
        /// <para>RoleName:CanRetrieve</para>
        /// </remarks>
        Stream GetImage(string authenticationCookie, string sopInstanceUID, int frame, string mimeType, int bitsPerPixel, int qualityFactor, int width, int height, string userData);

        /// <summary>
        /// Download a single image
        /// </summary>
        /// <remarks>
        /// <para>RoleName:CanRetrieve</para>
        /// </remarks>
        Stream DownloadImage(string authenticationCookie, string sopInstanceUID, int frame, int bitsPerPixel, int qualityFactor, int width, int height, string annotationFileName, double xDpi, double yDpi, string userData);

        string UploadAnnotations(string authenticationCookie, string data);

        /// <summary>
        /// Gets the raw DICOM object for an object
        /// </summary>
        /// <param name="authenticationCookie">Cookie</param>
        /// <param name="uid">UIDs. Only SOPInstanceUID is used</param>
        /// <param name="options">Query options</param>
        /// <returns>The DICOM as stream</returns>
        /// <remarks>
        /// <para>RoleName:CanRetrieve</para>
        /// </remarks>
        Stream GetDicom(string authenticationCookie, ObjectUID uid, GetDicomOptions options);

        XmlElement GetPresentationAnnotations(string authenticationCookie, string sopInstanceUID, string userData);
        string GetPresentationAnnotationsString(string authenticationCookie, string sopInstanceUID, string userData);

        /// <summary>
        /// streams audio from and IOD that supports audio
        /// </summary>
        /// <returns></returns>
        Stream GetAudio(string authenticationCookie, string sopInstanceUID, int groupIndex, string mimeType);

        /// <summary>
        /// checks if audio is available for selected instance
        /// </summary>
        /// <returns></returns>
        int GetAudioGroupsCount(string authenticationCookie, string sopInstanceUID);

        Layout GetSeriesLayout(string authenticationCookie, string seriesInstanceUID, string userData);

        List<StudyLayout> GetPatientStructuredDisplay(string authenticationCookie, string patientID, string userData);

        StudyLayout GetStudyLayout(string authenticationCookie, string studyInstanceUID, string userData);

        Task<Stream> GetSeriesThumbnail(string authenticationCookie, string studyInstanceUID, string seriesInstanceUID, string mimeType, int bitsPerPixel, int qualityFactor, int width, int height);

        List<StackItem> GetSeriesStacks(string authenticationCookie, string seriesInstanceUID, string userData);

        Task<Tuple<Stream, string>> GetImageTile(string authenticationCookie, string sopInstanceUID, int frame, int x, int y, int width, int height, int xResolution, int yResolution, Boolean wldata, string userData);

        Task<string> GetDicomJSON(string authenticationCookie, string studyInstanceUID, string seriesInstanceUID, string sopInstanceUID, string userData);
        WCFHangingProtocol GetHangingProtocol(string authenticationCookie, string sopInstanceUID, string userData);

        List<DisplaySetView> GetHangingProtocolInstances(string authenticationCookie, string hangingProtocolSOP, string patientID, string studyInstanceUID, string studyDateMostRecent, string userData);

        void ClearCache(string authenticationCookie);
    }
}
