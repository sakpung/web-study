// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Leadtools.Medical.WebViewer.DataContracts;
using System.ServiceModel.Web;
using System.ServiceModel;
using System.Xml;
using Leadtools.DataAccessLayers.Core;

namespace Leadtools.Medical.WebViewer.ServiceContracts
{
   /// <summary>
   /// The service contract for the annotations service (not used anymore)
   /// </summary>
   [ServiceContract]
   public interface ITemplateService
   {
       [OperationContract]
       [WebGet(UriTemplate = "/GetAnatomicDescriptions?auth={authenticationCookie}&data={userData}",
               RequestFormat = WebMessageFormat.Json,
               ResponseFormat = WebMessageFormat.Json)]
       List<AnatomicDescription> GetAnatomicDescriptions(string authenticationCookie, string userData);

       [OperationContract]
       [WebGet(UriTemplate = "/GetAllTemplates?auth={authenticationCookie}&data={userData}",
               RequestFormat = WebMessageFormat.Json,
               ResponseFormat = WebMessageFormat.Json)]
       List<WCFTemplate> GetAllTemplates(string authenticationCookie, string userData);

       [OperationContract]
       [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
       void AddTemplate(string authenticationCookie, WCFTemplate template, string userData);

       [OperationContract]
       [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
       void UpdateTemplate(string authenticationCookie, WCFTemplate template, string userData);

       [OperationContract]
       [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
       void DeleteTemplate(string authenticationCookie, string templateId, string userData);

       [OperationContract]
       [WebGet(UriTemplate = "/ExportAllTemplates?auth={authenticationCookie}&data={userData}", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
       Stream ExportAllTemplates(string authenticationCookie, string userData);

       [OperationContract]
       [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
       List<WCFTemplate> ImportTemplates(Stream file);       
   }
}
