// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.IO;
using Leadtools.Medical.WebViewer.DataContracts;
using System.ServiceModel.Web;

namespace Leadtools.Medical.WebViewer.ServiceContracts
{
   [ServiceContract]
   public interface IExportService
   {
      [OperationContract]
      [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
      string ExportAllSeries(string authenticationCookie, string patientID, ExportOptions options);
      [OperationContract]
      [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
      string ExportSeries(string authenticationCookie, string[] seriesInstanceUIDs, ExportOptions options);
      [OperationContract]
      [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
      string ExportInstances(string authenticationCookie, string[] instanceUIDs, ExportOptions options);
      [OperationContract]
      [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
      string ExportLayout(string authenticationCookie, string seriesInstanceUID, Layout layout, bool burnAnnotations, CompressionType compression, int width);

      [OperationContract]
      [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
      string PrintAllSeries(string authenticationCookie, string patientID, PrintOptions options);
      [OperationContract]
      [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
      string PrintSeries(string authenticationCookie, string[] seriesInstanceUIDs, PrintOptions options);
      [OperationContract]
      [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
      string PrintInstances(string authenticationCookie, string[] instanceUIDs, PrintOptions options);
      [OperationContract]
      [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
      string PrintLayout(string authenticationCookie, string seriesInstanceUID, Layout layout, PrintOptions options);

      [OperationContract]
      [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
      string GetInstanceLocalPathName(string authenticationCookie, string instanceUID);
   }
}
