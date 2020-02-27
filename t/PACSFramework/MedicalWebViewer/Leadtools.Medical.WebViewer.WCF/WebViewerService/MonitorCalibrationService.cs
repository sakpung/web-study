// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Leadtools.Medical.WebViewer.ServiceContracts;
using Leadtools.Medical.WebViewer.Wcf.Helper;
using System.Web.Services;
using System.ServiceModel.Activation;
using Leadtools.Medical.WebViewer.DataContracts;

namespace Leadtools.Medical.WebViewer.Wcf
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [WebService(Namespace = "http://leadtools.com/")]
    public class MonitorCalibrationService : IMonitorCalibrationService
    {
        private IMonitorCalibrationAddin _MonitorCalibration;

        public MonitorCalibrationService()
        {
           _MonitorCalibration = AddinsFactory.CreateMonitorCalibrationAddin();
        }

        public CalibrationItem[] GetCalibrations(string authenticationCookie)
        {
            ServiceUtils.Authorize(authenticationCookie, null);

            return _MonitorCalibration.GetCalibrations();
        }

        public void AddCalibration(string authenticationCookie, CalibrationItem calibration)
        {
            ServiceUtils.Authorize(authenticationCookie, null);

            _MonitorCalibration.AddCalibration(calibration);
        }
    }
}
