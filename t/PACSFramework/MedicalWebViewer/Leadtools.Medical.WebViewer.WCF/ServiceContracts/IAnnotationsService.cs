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

namespace Leadtools.Medical.WebViewer.ServiceContracts
{
   /// <summary>
   /// The service contract for the annotations service (not used anymore)
   /// </summary>
   [ServiceContract]
   public interface IAnnotationsService
   {
      [OperationContract]
      [WebInvoke ( BodyStyle=WebMessageBodyStyle.WrappedRequest, RequestFormat=WebMessageFormat.Json, ResponseFormat=WebMessageFormat.Json)]
      AnnotationIdentifier SaveAnnotations ( string authenticationCookie, string seriesInstanceUID, string annotationData, string userData ) ;
      
      [OperationContract]
      [WebGet(UriTemplate = "/GetAnnotations?auth={authenticationCookie}&annId={annotationID}&data={userData}",
              RequestFormat=WebMessageFormat.Json,
              ResponseFormat=WebMessageFormat.Xml)]
      XmlElement GetAnnotations ( string authenticationCookie, string annotationID, string userData ) ;
      
      //POST so it won't be cached if deleted!
      [OperationContract]
      [WebInvoke( BodyStyle=WebMessageBodyStyle.WrappedRequest,
                 RequestFormat=WebMessageFormat.Json,
                 ResponseFormat=WebMessageFormat.Json )]
      AnnotationIdentifier[] FindSeriesAnnotations ( string authenticationCookie, string seriesInstanceUID, string userData ) ;
      
      [OperationContract]
      [WebInvoke (Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
      void DeleteAnnotations ( string authenticationCookie, string annotationID, string userData ) ;
   }
}
