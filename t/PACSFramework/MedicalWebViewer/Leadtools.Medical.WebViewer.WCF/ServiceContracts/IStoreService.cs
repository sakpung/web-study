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
using System.Runtime.Serialization;
//using Leadtools.Caching;
//using Leadtools.Caching.Core;
using System.Linq;
using Leadtools.DataAccessLayers.Core;
using Leadtools.Dicom.Common.DataTypes.HangingProtocol;
using Leadtools.Medical.WebViewer.Core.DataTypes;

namespace Leadtools.Medical.WebViewer.ServiceContracts
{

    public enum StoreReturnCode
    {
        Failure = 0,
        Success = 1,
        PendingMoreData = 2
    }

    public enum StoreImageFormatCode
    {
        DCM = 0,
        JPEG = 1,
        PNG = 2,
    }

    [DataContract]
    public class PatientInfo_Json
    {
       public PatientInfo_Json(
                          string patientId,
                          string name,
                          string sex,
                          string birthDate,
                          string ethnicGroup,
                          string comments)
       {
          this.PatientId = patientId;
          this.Name = name;
          this.Sex = sex;
          this.BirthDate = birthDate;
          this.EthnicGroup = ethnicGroup;
          this.Comments = comments;
       }

       [DataMember]
       public string PatientId { get; set; }

       [DataMember]
       public string Name { get; set; }

       [DataMember]
       public string Sex { get; set; }

       [DataMember]
       public string BirthDate { get; set; }

       [DataMember]
       public string EthnicGroup { get; set; }

       [DataMember]
       public string Comments { get; set; }
    }

    [DataContract]
    public class StoreStatus_Json
    {
        public StoreStatus_Json(StoreReturnCode storeReturnCode, string message)
        {
            this.ReturnCode = (int)storeReturnCode;
            this.Message = message;
        }

        [DataMember]
        public int ReturnCode { get; set; }

        [DataMember]
        public string Message { get; set; }
    }

    /// <summary>
    /// Stores images to DICOM
    /// </summary>
    /// <remarks>
    /// As previous services, can store to remote PACS or local database
    /// Each operation in the services must specifiy what role it falls into. You must first call IsUserInRole to check if the user
    /// can perform the operation
    /// </remarks>
    [ServiceContract]
    public interface IStoreService 
    {
        /// <summary>
        /// Stores a secondary capture item from user's machine
        /// </summary>
        /// <param name="authenticationCookie">cookie</param>
        /// <param name="EncodedCapture">base64 encoded png image</param>
        /// <param name="OriginalSOPInstance">uid of related SOP</param>
        /// <param name="SeriesNumber">Series Number</param>
        /// <param name="SeriesDescription">Series Description</param>
        /// <param name="ProtocolName">Protocol Name</param>
        [OperationContract]
        [WebInvokeAttribute(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        SeriesData StoreSecondaryCapture(string authenticationCookie, string EncodedCapture, string OriginalSOPInstance, string SeriesNumber, string SeriesDescription, string ProtocolName);

        [OperationContract]
        [WebInvokeAttribute(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        PresentationStateData StoreAnnotations(string authenticationCookie, string seriesInstanceUID, string annotationData, string description, string userData);

        [OperationContract]
        [WebInvokeAttribute(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        string UploadDicomImage(string authenticationCookie, string dicomData, string status, string fileName);

        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        void DeletePresentationState(string authenticationCookie, string sopInstanceUID, string userData);

        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        StoreStatus_Json StoreImage(string authenticationCookie, int formatCode, string imageData, string userData);

        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, ResponseFormat = WebMessageFormat.Json)]
        void StoreSeriesLayout(string authenticationCookie, string seriesInstanceUID, string templateId, ImageBox[] boxes, string userData);
#if LEADTOOLS_V19_OR_LATER
        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, ResponseFormat = WebMessageFormat.Json)]
        void DeleteSeriesLayout(string authenticationCookie, string seriesInstanceUID, string userData);

        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, ResponseFormat = WebMessageFormat.Json)]
        void StoreStudyLayout(string authenticationCookie, string studyInstanceUID, StudyLayout studyLayout, string userData);

        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, ResponseFormat = WebMessageFormat.Json)]
        void DeleteStudyLayout(string authenticationCookie, string studyInstanceUID, string userData);

        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, ResponseFormat = WebMessageFormat.Json)]
        void StoreHangingProtocol(string authenticationCookie, WCFHangingProtocol hangingProtocol, string userData);
      
#endif
    }
}
