// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;
using System.IO;
using System.ServiceModel.Web;
using System.Xml;

using Leadtools.Medical.WebViewer.DataContracts;
using Leadtools.Dicom.Common.DataTypes.HangingProtocol;
using Leadtools.Medical.WebViewer.Core.DataTypes;

namespace Leadtools.Medical.WebViewer.ServiceContracts
{
    /// <summary>
    /// Retrieves objects from local
    /// </summary>
    /// <remarks>
    /// Each operation in the services must specify what role it falls into. You must first call IsUserInRole to check if the user
    /// can perform the operation
    /// </remarks>
    [ServiceContract]
    public interface IObjectRetrieveService
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
        [OperationContract]
        [WebGet(UriTemplate = "/GetImage?auth={authenticationCookie}&instance={sopInstanceUID}&frame={frame}&mime={mimeType}&bp={bitsPerPixel}&qf={qualityFactor}&cx={width}&cy={height}&data={userData}")]
        Stream GetImage(string authenticationCookie, string sopInstanceUID, int frame, string mimeType, int bitsPerPixel, int qualityFactor, int width, int height, string userData);

        /// <summary>
        /// Download a single image
        /// </summary>
        /// <param name="authenticationCookie"></param>
        /// <param name="sopInstanceUID"></param>
        /// <returns></returns>
        /// <remarks>
        /// <para>RoleName:CanRetrieve</para>
        /// </remarks>
        [OperationContract]
        [WebGet(UriTemplate = "/DownloadImage?auth={authenticationCookie}&instance={sopInstanceUID}&frame={frame}&bp={bitsPerPixel}&qf={qualityFactor}&cx={width}&cy={height}&annotationFileName={annotationFileName}&xDpi={xDpi}&yDpi={yDpi}&data={userData}")]
        Stream DownloadImage(string authenticationCookie, string sopInstanceUID, int frame, int bitsPerPixel, int qualityFactor, int width, int height, string annotationFileName, double xDpi, double yDpi, string userData);

        [OperationContract(Name = "UploadAnnotations", IsTerminating = false, IsInitiating = true, IsOneWay = false, AsyncPattern = false, Action = "UploadAnnotations")]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        string UploadAnnotations(string authenticationCookie, XmlElement data);

        /// <summary>
        /// Gets the raw DICOM object for an object
        /// </summary>
        /// <param name="authenticationCookie">Cookie</param>
        /// <param name="uid">UIDs. Only SOPInstanceUID is used</param>
        /// <param name="options">Query options</param>
        /// <param name="extraOptions">Extra options</param>
        /// <returns>The DICOM as stream</returns>
        /// <remarks>
        /// <para>RoleName:CanRetrieve</para>
        /// </remarks>
        Stream GetDicom(string authenticationCookie, ObjectUID uid, GetDicomOptions options, ExtraOptions extraOptions);

        //[OperationContract]
        //[WebGet(UriTemplate = "/GetDicomImageData?auth={authenticationCookie}&study={studyInstanceUID}&sereis={seriesInstanceUID}&instance={sopInstanceUID}&frame={frame}&data={userData}",
        //            RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        //Stream GetDicomImageData(string authenticationCookie, string studyInstanceUID, string seriesInstanceUID, string sopInstanceUID, int frame, string userData);

        [OperationContract]
        [WebGet(UriTemplate = "/GetDicomImageDataAsPNG?auth={authenticationCookie}&study={studyInstanceUID}&sereis={seriesInstanceUID}&instance={sopInstanceUID}&frame={frame}&data={userData}",
                    RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        Stream GetDicomImageDataAsPNG(string authenticationCookie, string studyInstanceUID, string seriesInstanceUID, string sopInstanceUID, int frame, string userData);

        /// <summary>
        /// Gets the raw DICOM object as XML
        /// </summary>
        /// <param name="authenticationCookie">Cookie</param>
        /// <param name="uid">UIDs. Only SOPInstanceUID is used</param>
        /// <param name="options">Query options</param>
        /// <param name="extraOptions">Extra options</param>
        /// <returns>The DICOM as XML</returns>
        /// <remarks>
        /// <para>RoleName:CanRetrieve</para>
        /// </remarks>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1059:MembersShouldNotExposeCertainConcreteTypes", MessageId = "System.Xml.XmlNode")]
        [OperationContract]
        [WebGet(UriTemplate = "/GetDicomXml?auth={authenticationCookie}&study={studyInstanceUID}&sereis={seriesInstanceUID}&instance={sopInstanceUID}&data={userData}",
                    RequestFormat = WebMessageFormat.Json,
                    ResponseFormat = WebMessageFormat.Xml)]
        XmlElement GetDicomXml(string authenticationCookie, string studyInstanceUID, string seriesInstanceUID, string sopInstanceUID, string userData);        

        /// <summary>
        /// Gets presentation info required to display a series of instances 
        /// </summary>
        /// <param name="authenticationCookie">Cookie</param>
        /// <param name="studyInstanceUID">query specific studyInstanceUID</param>
        /// <param name="seriesInstanceUID">query specific seriesInstanceUID</param>
        /// <param name="sopInstanceUID">query specific sopInstanceUID</param>
        /// <param name="userData">user data</param>
        /// <returns>PresentationInfo array</returns>
        /// <remarks>
        /// <para>RoleName:CanRetrieve</para>
        /// </remarks>
        //[OperationContract]
        //[WebGet(UriTemplate = "/GetPresentationInfo?auth={authenticationCookie}&study={studyInstanceUID}&series={seriesInstanceUID}&instance={sopInstanceUID}&data={userData}",
        //            RequestFormat = WebMessageFormat.Json,
        //            ResponseFormat = WebMessageFormat.Json)]
        //PresentationInfo[] GetPresentationInfo(string authenticationCookie, string studyInstanceUID, string seriesInstanceUID, string sopInstanceUID, string userData);


        [OperationContract]
        [WebGet(UriTemplate = "GetPresentationAnnotations?auth={authenticationCookie}&instance={sopInstanceUID}&data={userData}",
                 RequestFormat = WebMessageFormat.Json,
                 ResponseFormat = WebMessageFormat.Xml)]
        XmlElement GetPresentationAnnotations(string authenticationCookie, string sopInstanceUID, string userData);

        /// <summary>
        /// streams audio from and IOD that supports audio
        /// </summary>
        /// <param name="authenticationCookie"></param>
        /// <param name="sopInstanceUID"></param>
        /// <param name="mimeType"></param>
        /// <returns></returns>
        [OperationContract]
        [WebGet(UriTemplate = "/GetAudio?auth={authenticationCookie}&instance={sopInstanceUID}&group={groupIndex}&mime={mimeType}")]
        Stream GetAudio(string authenticationCookie, string sopInstanceUID, int groupIndex, string mimeType);

        /// <summary>
        /// checks if audio is available for selected instance
        /// </summary>
        /// <param name="authenticationCookie"></param>
        /// <param name="sopInstanceUID"></param>
        /// <param name="mimeType"></param>
        /// <returns></returns>
        [OperationContract]
        [WebInvokeAttribute(BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        int GetAudioGroupsCount(string authenticationCookie, string sopInstanceUID);        

        [OperationContract]
        [WebGet(UriTemplate = "GetSeriesLayout?auth={authenticationCookie}&seriesInstanceUID={seriesInstanceUID}&data={userData}",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json)]
        Layout GetSeriesLayout(string authenticationCookie, string seriesInstanceUID, string userData);

        [WebGet(UriTemplate = "GetStudyLayout?auth={authenticationCookie}&studyInstanceUID={studyInstanceUID}&data={userData}",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json)]
        StudyLayout GetStudyLayout(string authenticationCookie, string studyInstanceUID, string userData);


        [OperationContract]
        [WebGet(UriTemplate = "/GetSeriesThumbnail?auth={authenticationCookie}&study={studyInstanceUID}&series={seriesInstanceUID}&cx={width}&cy={height}")]
        Stream GetSeriesThumbnail(string authenticationCookie, string studyInstanceUID, string seriesInstanceUID, int width, int height);

        [OperationContract]
        [WebGet(UriTemplate = "/GetMinMaxValues?auth={authenticationCookie}&instance={sopInstanceUID}&frame={frameNumber}&data={userData}",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json)]
        int[] GetMinMaxValues(string authenticationCookie, string sopInstanceUID, int frameNumber, string userData);

        [OperationContract]
        [WebGet(UriTemplate = "GetSeriesStacks?auth={authenticationCookie}&seriesInstanceUID={seriesInstanceUID}&data={userData}",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json)]
        List<StackItem> GetSeriesStacks(string authenticationCookie, string seriesInstanceUID, string userData);

        [OperationContract]
        [WebGet(UriTemplate = "/GetImageTile?auth={authenticationCookie}&instance={sopInstanceUID}&frame={frame}&x={x}&y={y}&w={width}&h={height}&xr={xResolution}&yr={yResolution}&wldata={wldata}&data={userData}")]
        Stream GetImageTile(string authenticationCookie, string sopInstanceUID, int frame, int x, int y, int width, int height, int xResolution, int yResolution, Boolean wldata, string userData);

        [OperationContract]
        [WebGet(UriTemplate = "/GetDicomJSON?auth={authenticationCookie}&study={studyInstanceUID}&series={seriesInstanceUID}&instance={sopInstanceUID}&data={userData}",
                RequestFormat = WebMessageFormat.Json,ResponseFormat = WebMessageFormat.Json)]
        string GetDicomJSON(string authenticationCookie, string studyInstanceUID, string seriesInstanceUID, string sopInstanceUID, string userData);

        [OperationContract]
        [WebGet(UriTemplate = "/GetHangingProtocol?auth={authenticationCookie}&instance={sopInstanceUID}&data={userData}",
                RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        WCFHangingProtocol GetHangingProtocol(string authenticationCookie, string sopInstanceUID, string userData);

        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, ResponseFormat = WebMessageFormat.Json)]
        List<DisplaySetView> GetHangingProtocolInstances(string authenticationCookie, string hangingProtocolSOP, string patientID, string studyInstanceUID, string studyDateMostRecent, string userData);

        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, ResponseFormat = WebMessageFormat.Json)]
        void ClearCache(string authenticationCookie);

    }
}
