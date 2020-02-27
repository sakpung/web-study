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
using Leadtools.Medical.WebViewer.ServiceContracts;
using System.ServiceModel.Activation;
using Leadtools.Medical.WebViewer.Wcf.Helper;
using System.ServiceModel.Web;
using Leadtools.Dicom;
using System.Net;
using System.Xml;

namespace Leadtools.Medical.WebViewer.Wcf
{
   /// <summary>
   /// Do Not use. 
   /// The annotations service is used to store and retrieve annotations (this is not used now and annotations are stored as DICOM instances with the StoreService and retrieved using the ObjectRetrieve Service)
   /// </summary>
   [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
   public class AnnotationsService : IAnnotationsService
   {
      public AnnotationsService ( )
      {
      }

      public AnnotationIdentifier SaveAnnotations(string authenticationCookie, string seriesInstanceUID, string annotationData, string userData)
      {
         ServiceUtils.Authorize(authenticationCookie, PermissionsTable.Instance.CanStoreAnnotations);

         string identifier = AddinsFactory.CreateAnnotationsAddin().SaveAnnotations(seriesInstanceUID, annotationData, userData);
         
         if ( !string.IsNullOrEmpty ( identifier ) )
         {
            AnnotationIdentifier annID = new AnnotationIdentifier ( ) ;
            
            annID.UserData = userData ;
            annID.SeriesInstanceUID = seriesInstanceUID ;
            annID.AnnotationID = identifier ;
            
            return annID ;
         }
         else
         {
            return null ;
         }
      }

      public XmlElement GetAnnotations(string authenticationCookie, string annotationID, string userData)
      {
         ServiceUtils.Authorize(authenticationCookie, PermissionsTable.Instance.CanViewAnnotations);
         
         Stream annStream = AddinsFactory.CreateAnnotationsAddin ( ).GetAnnotations ( annotationID, userData ) ;
         
         if ( null == annStream ) 
         {
            return null ;
         }
         else
         {
            annStream.Position = 0 ;
            XmlDocument document = new XmlDocument ( ) ;
            document.Load ( annStream ) ;
            return document.DocumentElement ;
         }
      }

      public AnnotationIdentifier[] FindSeriesAnnotations(string authenticationCookie, string seriesInstanceUID, string userData)
      {
         ServiceUtils.Authorize(authenticationCookie, PermissionsTable.Instance.CanViewAnnotations);
         
         return AddinsFactory.CreateAnnotationsAddin ( ).FindSeriesAnnotations ( seriesInstanceUID, userData ) ;
      }

      public void DeleteAnnotations(string authenticationCookie, string annotationID, string userData)
      {
         ServiceUtils.Authorize(authenticationCookie, PermissionsTable.Instance.CanDeleteAnnotations);
         
         AddinsFactory.CreateAnnotationsAddin ( ).DeleteAnnotations ( annotationID, userData ) ;
      }
   }
}
