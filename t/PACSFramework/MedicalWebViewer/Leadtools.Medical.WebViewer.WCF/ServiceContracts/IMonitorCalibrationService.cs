// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Medical.WebViewer.DataContracts;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace Leadtools.Medical.WebViewer.ServiceContracts
{
    [ServiceContract]
    public interface IMonitorCalibrationService
    {
        [OperationContract]
        [WebGet(UriTemplate = "/GetCalibrations?auth={authenticationCookie}",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json)]
        CalibrationItem[] GetCalibrations(string authenticationCookie);
        [OperationContract]
        [WebInvokeAttribute(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        void AddCalibration(string authenticationCookie, CalibrationItem calibration);
    }
}
