// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using Leadtools.Medical.WebViewer.DataContracts;
using System.ServiceModel.Web;
using Leadtools.Medical.WebViewer.ServiceContracts;
using Leadtools.Medical.WebViewer.Addins;
using Leadtools.Dicom;
using System.Web.Services;
using System.ServiceModel.Activation;
using Leadtools.Medical.WebViewer.Wcf.Helper;
using System.Net;

namespace Leadtools.Medical.WebViewer.Wcf
{
   /// <summary>
   /// The service retrieve DICOM images from remote server through the Storage Server. 
   /// service client sends a MOVE request to the remote server asking it to store the images into our local storage server.
   /// 
   /// </summary>
   [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
   [WebService(Namespace = "http://leadtools.com/" )]
   public class PACSRetrieveService : IPACSRetrieveService
   {
      IPacsDownloadAddin _addin;
      
      public PACSRetrieveService()
      {
         _addin = AddinsFactory.CreatePacsDownloadAddin();      
      }

      public DownloadInfo DownloadImages
      (
         string authenticationCookie,
         PACSConnection server,
         string client,
         string PatientID, 
         string StudyInstanceUID,
         string SeriesInstanceUID,
         string SOPInstanceUID,
         ExtraOptions extraOptions
      )
      {
         string userName ;
         
         userName = ServiceUtils.Authorize(authenticationCookie, PermissionsTable.Instance.CanDownloadImages);

         return _addin.DownloadImages(userName, server, "LTSTORAGESERVER", PatientID, StudyInstanceUID, SeriesInstanceUID, SOPInstanceUID, null!=extraOptions?extraOptions.UserData:"");
      }

      public DownloadInfo UpdateDownloadInfoStatus(string authenticationCookie, DownloadInfo info, ExtraOptions extraOptions)
      {
         string userName ;

         
         userName = ServiceUtils.Authorize(authenticationCookie,PermissionsTable.Instance.CanDownloadImages) ;

         return _addin.UpdateDownloadInfoStatus(userName, info);
      }

      public JobStatus[] GetJobStatus(string authenticationCookie, string[] JobsIds, ExtraOptions extraOptions)
      {
         string userName ;

         
         userName = ServiceUtils.Authorize( authenticationCookie, PermissionsTable.Instance.CanDownloadImages) ;
         
         return _addin.GetJobStatus( userName, JobsIds);
         
      }

      public DownloadInfo[] GetDownloadInfos
      (
         string authenticationCookie, 
         PACSConnection server, 
         string client,                                       
         string patientID, 
         string studyInstanceUID, 
         string seriesInstanceUID, 
         string sopInstanceUID, 
         DownloadStatus status, 
         ExtraOptions extraOptions)
      {
         string userName ;

         
         userName = ServiceUtils.Authorize(authenticationCookie,PermissionsTable.Instance.CanDownloadImages) ;
         
         return _addin.GetDownloadInfos( userName,
                                          server, 
                                          client,          
                                          patientID, 
                                          studyInstanceUID, 
                                          seriesInstanceUID,    
                                          sopInstanceUID, 
                                          status);
      }
            
      public void DeleteDownloadInfos (string authenticationCookie, int[] jobIds, ExtraOptions extraOptions )
      {
         string userName ;

         
         userName = ServiceUtils.Authorize(authenticationCookie,PermissionsTable.Instance.CanDeleteDownloadInfo) ;
         
         _addin.DeleteDownloadInfos(userName, jobIds);
      }

      public void DeleteImages(string authenticationCookie, 
         string patientID,
         string studyInstanceUID,
         string seriesInstanceUID,
         string sopInstanceUID, ExtraOptions extraOptions)
      {
         string userName ;

         
         userName = ServiceUtils.Authorize(authenticationCookie,PermissionsTable.Instance.CanDeleteImages) ;
         
         _addin.DeleteImages(userName, patientID, studyInstanceUID, seriesInstanceUID, sopInstanceUID);
      }


   }
}
