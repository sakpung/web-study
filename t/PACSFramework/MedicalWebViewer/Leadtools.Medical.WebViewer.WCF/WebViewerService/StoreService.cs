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
using System.Diagnostics;
using System.IO;
//using Leadtools.Caching;
//using Leadtools.Caching.Core;
using Leadtools.Dicom.Common.Extensions;
using HttpUtils;
using System.Runtime.Serialization.Json;
using Leadtools.Dicom.Common.DataTypes.HangingProtocol;
using Leadtools.Medical.WebViewer.Core.DataTypes;

namespace Leadtools.Medical.WebViewer.Wcf
{

    /// <summary>
    /// Stores any DICOM related information into the local service/database. All functionality is done through the add-in after authentication and authorization.
    /// </summary>
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [WebService(Namespace = "http://leadtools.com/")]
    public class StoreService : IStoreService
    {
        // private static DiskCacheStore _diskCacheStore ;// = new DiskCacheStore(@"d:\erase");
        // private static DiskCacheStore _diskCacheStore = new DiskCacheStore(Path.Combine(Path.GetTempPath(), @"LTStoreServiceCacheDB"), Path.Combine(Path.GetTempPath(), @"LTStoreServiceCacheItems"), true);
        IStoreAddin _addin;

        public StoreService()
        {
           _addin = AddinsFactory.CreateStoreAddin();
        }


        public SeriesData StoreSecondaryCapture(string authenticationCookie, string EncodedCapture, string OriginalSOPInstance, string SeriesNumber, string SeriesDescription, string ProtocolName)
        {
            try
            {

                string userName;

                userName = ServiceUtils.Authorize(authenticationCookie, PermissionsTable.Instance.CanStore);

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

            userName = ServiceUtils.Authorize(authenticationCookie, PermissionsTable.Instance.CanStoreAnnotations);

            return ((StoreAddin)_addin).UploadFile(userName, dicomData, status, fileName);
        }


        public PresentationStateData StoreAnnotations(string authenticationCookie, string seriesInstanceUID, string annotationData, string description, string userData)
        {
            string userName;

            
            userName = ServiceUtils.Authorize(authenticationCookie, PermissionsTable.Instance.CanStoreAnnotations);

            return _addin.StoreAnnotations(userName, seriesInstanceUID, annotationData, description, userData);
        }

        public void DeletePresentationState(string authenticationCookie, string sopInstanceUID, string userData)
        {
            string userName;

            userName = ServiceUtils.Authorize(authenticationCookie, PermissionsTable.Instance.CanDeleteAnnotations);

            _addin.DeletePresentationState(sopInstanceUID, userData);
        }

        public StoreStatus_Json StoreImage(string authenticationCookie, int formatCode, string imageData, string userData)
        {
            try
            {
                string userName;
                
                userName = ServiceUtils.Authorize(authenticationCookie, PermissionsTable.Instance.CanStore);

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

        public void StoreSeriesLayout(string authenticationCookie, string seriesInstanceUID, string templateId, ImageBox[] boxes, string userData)
        {
            // deprectated 
        }
#if (LEADTOOLS_V19_OR_LATER)
        public void DeleteSeriesLayout(string authenticationCookie, string seriesInstanceUID, string userData)
        {
            // deprectated 
        }

        public void StoreStudyLayout(string authenticationCookie, string studyInstanceUID, StudyLayout studyLayout, string userData)
        {
            string userName;

            try
            {
                
                userName = ServiceUtils.Authorize(authenticationCookie, PermissionsTable.Instance.CanSaveSeriesLayout);
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
                
                userName = ServiceUtils.Authorize(authenticationCookie, PermissionsTable.Instance.CanSaveHangingProtocol);
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
                
                userName = ServiceUtils.Authorize(authenticationCookie, PermissionsTable.Instance.CanDeleteImages);
            }
            catch (ServiceAuthorizationException)
            {
                throw new ServiceAuthorizationException("Access denied, please login with different user to have this feature available.");
            }

            _addin.DeleteStudyLayout(studyInstanceUID, userData);
        }
#endif

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
