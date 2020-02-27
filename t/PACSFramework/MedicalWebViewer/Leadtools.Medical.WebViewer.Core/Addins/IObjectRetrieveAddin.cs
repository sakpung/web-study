// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;

using Leadtools.Medical.WebViewer.DataContracts;
using Leadtools.Dicom.Common.DataTypes.HangingProtocol;
using Leadtools.Medical.WebViewer.Core.DataTypes;

namespace Leadtools.Medical.WebViewer.ServiceContracts
{
   public class ImageSize
   {
      public int width;
      public int height;
      public List<ImageProcessingFunction> functions;
      public string policy;
   }

    /// <summary>
    /// Retrieves DICOM objects from local storage
    /// </summary>
    /// <remarks>
    /// Each operation in the services must specifiy what role it falls into. You must first call IsUserInRole to check if the user
    /// can perform the operation
    /// </remarks>
    public interface IObjectRetrieveAddin
    {
        /// <summary>
        /// Gets a single image
        /// </summary>
        /// <param name="authenticationCookie"></param>
        /// <param name="sopInstanceUID"></param>
        /// <returns></returns>
        /// <remarks>
        /// <para>RoleName:CanRetrieve</para>
        /// </remarks>
        Stream GetImage(string sopInstanceUID, int frame, string mimeType, int bitsPerPixel, int qualityFactor, int width, int height, string userData);

        Stream DownloadImage(string sopInstanceUID, int frame, string mimeType, int bitsPerPixel, int qualityFactor, int width, int height, string annotationData, double xDpi, double yDpi, string userData);

        /// <summary>
        /// Gets audio stream
        /// </summary>
        /// <param name="sopInstanceUID"></param>
        /// <param name="mimeType"></param>
        /// <returns></returns>
        Stream GetAudio(string sopInstanceUID, int groupIndex, string mimeType);

        /// <summary>
        /// Gets audio groups count
        /// </summary>
        /// <param name="sopInstanceUID"></param>
        /// <returns></returns>
        int GetAudioGroupsCount(string sopInstanceUID);

        /// <summary>
        /// Gets the binary data for a DICOM DataSet
        /// </summary>
        /// <param name="authenticationCookie">Cookie</param>
        /// <param name="uid">UIDs. Only SOPInstanceUID is used</param>
        /// <param name="options">Query options</param>
        /// <param name="extraOptions">Extra options</param>
        /// <returns>The DICOM as stream</returns>
        /// <remarks>
        /// <para>RoleName:CanRetrieve</para>
        /// </remarks>
        Stream GetDicom(ObjectUID uid, GetDicomOptions options);

        /// <summary>
        /// Gets the raw DICOM DataSet as XML
        /// </summary>
        /// <param name="authenticationCookie">Cookie</param>
        /// <param name="uid">UIDs. Only SOPInstanceUID is used</param>
        /// <param name="options">Query options</param>
        /// <param name="extraOptions">Extra options</param>
        /// <returns>The DICOM as XML</returns>
        /// <remarks>
        /// <para>RoleName:CanRetrieve</para>
        /// </remarks>
        XmlElement GetDicomXml(ObjectUID uid);

        /// <summary>
        /// Gets the raw DICOM image as a base64 stream
        /// </summary>
        /// <param name="uid">UIDs. Only SOPInstanceUID is used</param>
        /// <param name="options">Query options</param>
        /// <param name="extraOptions">Extra options</param>
        /// <returns>raw DICOM image as a base64 stream</returns>
        /// <remarks>
        /// <para>RoleName:CanRetrieve</para>
        /// </remarks>
        //Stream GetDicomImageData(ObjectUID uid, int frame, ImageSize? imageSize = null);

        /// <summary>
        /// Get the raw DICOM image as binary
        /// </summary>
        /// <param name="uid">Contians the UID for the DICOM Object</param>
        /// <param name="extraOptions">cusomt user data</param>
        /// <param name="frame">the frame number of the image</param>
        /// <returns></returns>
        byte[] GetBinaryDicomImageData(ObjectUID uid, int frame, ImageSize imageSize = null);

        /// <summary>
        /// Get the raw DICOM image as PNG
        /// </summary>
        /// <param name="uid">Contains the UID for the DICOM Object</param>
        /// <param name="extraOptions">custom user data</param>
        /// <param name="frame">the frame number of the image</param>
        /// <returns></returns>
        byte[] GetBinaryDicomImageDataAsPNG(ObjectUID uid, int frame, ImageSize imageSize = null);

        /// <summary>
        /// Gets presentation information for a series
        /// </summary>
        /// <param name="uid">UIDs. Only SeriesInstanceUID is used</param>
        /// <returns>The PresentationInfo for a series' instances</returns>
        /// <remarks>
        /// <para>RoleName:CanRetrieve</para>
        /// </remarks>
        //PresentationInfo[] GetPresentationInfo(ObjectUID uid);

        /// <summary>
        /// Returns a serialized AnnotationContainer that represents the object presentation state
        /// </summary>
        /// <param name="sopInstanceUID">The DICOM presentation state object SOP Instance UID</param>
        /// <param name="userData">Custom data</param>
        /// <returns>Returns a serialized Annotations Container object</returns>
        Stream GetPresentationAnnotations(string sopInstanceUID, string userData);

        Layout GetSeriesLayout(string userName, string seriesInstanceUID, Lazy<IStoreAddin> storeAddin, string userData);

#if LEADTOOLS_V19_OR_LATER
        StudyLayout GetStudyLayout(string userName, string studyInstanceUID, string userData);

        List<StudyLayout> GetPatientStructuredDisplay(string userName, string patientID, string userData);
#endif

        Stream GetSeriesThumbnail(string userName, string seriesInstanceUID, string mimeType, int bitsPerPixel, int qualityFactor, int width, int height);

        int[] GetMinMaxValues(string sopInstanceUID, int frameNumber);

        List<StackItem> GetSeriesStacks(string seriesInstanceUID);

#if LEADTOOLS_V19_OR_LATER

        Stream GetMPRImage(string id, int mprType, int index);

        Stream GetImageTile(string sopInstanceUID, int frameNumber, LeadRect tile, int xResolution, int yResolution, Boolean wldata, string userData, out string mime);

        string GetDicomJSON(ObjectUID uid);

        WCFHangingProtocol GetHangingProtocol(string userName, string sopInstanceUID, string userData);

        List<DisplaySetView> GetHangingProtocolInstances(string userName, string hangingProtocolSOP, string patientId, string studyInstanceUID, string studyDateMostRecent, string userData);
#endif

    }
}
