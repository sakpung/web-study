// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using Leadtools.Medical.WebViewer.DataContracts;
using Leadtools.Medical.WebViewer.Addins;
using Leadtools.Dicom;
using System.IO;
//using Leadtools.Caching;
//using Leadtools.Caching.Core;
using Leadtools.Medical.WebViewer.Core.DataTypes;
using Leadtools.Medical.WebViewer.Services.Interfaces;
using Leadtools.Medical.WebViewer.Errors;
using Leadtools.Medical.WebViewer.ServiceContracts;

namespace Leadtools.Medical.WebViewer.Services.Implementation
{

   /// <summary>
   /// Stores any DICOM related information into the local Handler/database. All functionality is done through the add-in after authentication and authorization.
   /// </summary>


   public class StoreHandler : IStoreHandler
   {
      // private static DiskCacheStore _diskCacheStore ;// = new DiskCacheStore(@"d:\erase");
      // private static DiskCacheStore _diskCacheStore = new DiskCacheStore(Path.Combine(Path.GetTempPath(), @"LTStoreHandlerCacheDB"), Path.Combine(Path.GetTempPath(), @"LTStoreHandlerCacheItems"), true);
      IStoreAddin _addin;

      public StoreHandler(AddinsFactory factory)
      {
         _addin = factory.CreateStoreAddin();
      }


      public SeriesData StoreSecondaryCapture(string authenticationCookie, string EncodedCapture, string OriginalSOPInstance, string SeriesNumber, string SeriesDescription, string ProtocolName)
      {
         try
         {

            string userName;

            userName = AuthHandler.Authorize(authenticationCookie, PermissionsTable.Instance.CanStore);

            return _addin.StoreSecondaryCapture(userName, EncodedCapture, OriginalSOPInstance, SeriesNumber, SeriesDescription, ProtocolName);
         }
         catch (ServiceAuthorizationException)
         {
            throw new ServiceAuthorizationException("Access denied, please login with different user to have this feature available.");
         }
      }

      public string UploadDicomImage(string authenticationCookie, string dicomData, string status, string fileName)
      {
         string userName;

         userName = AuthHandler.Authorize(authenticationCookie, PermissionsTable.Instance.CanStoreAnnotations);

         return ((StoreAddin)_addin).UploadFile(userName, dicomData, status, fileName);
      }


      public PresentationStateData StoreAnnotations(string authenticationCookie, string seriesInstanceUID, string annotationData, string description, string userData)
      {
         string userName;


         userName = AuthHandler.Authorize(authenticationCookie, PermissionsTable.Instance.CanStoreAnnotations);

         return _addin.StoreAnnotations(userName, seriesInstanceUID, annotationData, description, userData);
      }

      public void DeletePresentationState(string authenticationCookie, string sopInstanceUID, string userData)
      {
         string userName;

         userName = AuthHandler.Authorize(authenticationCookie, PermissionsTable.Instance.CanDeleteAnnotations);

         _addin.DeletePresentationState(sopInstanceUID, userData);
      }

      public StoreStatus_Json StoreImage(string authenticationCookie, int formatCode, string imageData, string userData)
      {
         try
         {
            string userName;

            userName = AuthHandler.Authorize(authenticationCookie, PermissionsTable.Instance.CanStore);

            StoreImageFormatCode format = (StoreImageFormatCode)formatCode;

            // last resort. Should have already been removed by client side JS
            if (imageData.StartsWith("data"))
            {
               int indexOfComma = imageData.IndexOf(',');
               imageData = imageData.Substring(indexOfComma + 1);
            }

            StoreReturnCode ret;
            string message;

            switch (format)
            {
               case StoreImageFormatCode.DCM:
                  {
                     //DicomDataSet  ds = createDatasetFromBase64String(imageData);
                     //ds.Save(@"D:\Delete\Other_Temp\TestOut.dcm", DicomDataSetSaveFlags.None);
                     ret = StoreReturnCode.Success;
                     message = "Success";
                  }
                  break;

               case StoreImageFormatCode.JPEG:
                  {
                     ret = StoreReturnCode.Failure;
                     message = "JPEG Store not yet implemented";
                  }
                  break;
               case StoreImageFormatCode.PNG:
                  {
                     ret = StoreReturnCode.Failure;
                     message = "PNG store not yet implemented";
                  }
                  break;
               default:
                  throw new Exception("Invalid format specified");
            }

            return new StoreStatus_Json(ret, message);
         }
         catch (ServiceAuthorizationException)
         {
            throw new ServiceAuthorizationException("Access denied, please login with different user to have this feature available.");
         }
      }

      public void StoreStudyLayout(string authenticationCookie, string studyInstanceUID, StudyLayout studyLayout, string userData)
      {
         string userName;

         try
         {

            userName = AuthHandler.Authorize(authenticationCookie, PermissionsTable.Instance.CanSaveSeriesLayout);
         }
         catch (ServiceAuthorizationException)
         {
            throw new ServiceAuthorizationException("Access denied, please login with different user to have this feature available.");
         }

         _addin.StoreStudyLayout(userName, studyInstanceUID, studyLayout, userData);
      }

      public void StoreHangingProtocol(string authenticationCookie, WCFHangingProtocol hangingProtocol, string userData)
      {
         string userName;

         try
         {

            userName = AuthHandler.Authorize(authenticationCookie, PermissionsTable.Instance.CanSaveHangingProtocol);
         }
         catch (ServiceAuthorizationException)
         {
            throw new ServiceAuthorizationException("Access denied, please login with different user to have this feature available.");
         }

         _addin.StoreHangingProtocol(userName, hangingProtocol, userData);
      }

      public void DeleteStudyLayout(string authenticationCookie, string studyInstanceUID, string userData)
      {
         string userName;

         try
         {

            userName = AuthHandler.Authorize(authenticationCookie, PermissionsTable.Instance.CanDeleteImages);
         }
         catch (ServiceAuthorizationException)
         {
            throw new ServiceAuthorizationException("Access denied, please login with different user to have this feature available.");
         }

         _addin.DeleteStudyLayout(studyInstanceUID, userData);
      }

      private DicomDataSet createDatasetFromBase64String(string imageData)
      {
         byte[] bytes = Convert.FromBase64String(imageData);
         Stream ms = new MemoryStream(bytes);
         DicomDataSet ds = new DicomDataSet();
         ds.Load(ms, DicomDataSetLoadFlags.None);
         return ds;
      }
   }
}
