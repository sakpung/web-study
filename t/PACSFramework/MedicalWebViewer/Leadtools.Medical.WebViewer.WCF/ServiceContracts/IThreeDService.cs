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
   public interface IThreeDService
   {
      [OperationContract]
      [WebGet(UriTemplate = "/Get3DImage?auth={authenticationCookie}&id={id}&x={x}&y={y}&width={width}&height={height}&resizeFactor={resizeFactor}&effect={effect}&action={action}&sensitivity={sensitivity}&resizeRatio={resizeRatio}")]
      Stream Get3DImage(string authenticationCookie, string id, int x, int y, int width, int height, int resizeFactor, string effect, int action, float sensitivity, float resizeRatio);

      [OperationContract]
      [WebInvokeAttribute(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
      void End3DObject(string authenticationCookie, string id);

      [OperationContract]
      [WebInvokeAttribute(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
      string Create3DObject(string authenticationCookie, QueryOptions options, string id, int renderingType, ExtraOptions extraOptions);

      [OperationContract]
      [WebInvokeAttribute(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
      void Update3DSettings(string authenticationCookie, string id, string options);

      [OperationContract]
      [WebInvokeAttribute(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
      string Get3DSettings(string authenticationCookie, string id, string options);

      [OperationContract]
      [WebInvokeAttribute(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
      string CheckProgress(string authenticationCookie, string id);

      [OperationContract]
      [WebInvokeAttribute(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
      void KeepAlive(string authenticationCookie, string id);

      [OperationContract]
      [WebGet(UriTemplate = "/GetMPRImage?auth={authenticationCookie}&id={id}&mprType={mprType}&index={index}")]
      Stream GetMPRImage(string authenticationCookie, string id, int mprType, int index);
   }
}
