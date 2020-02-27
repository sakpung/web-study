// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using Leadtools.Medical.WebViewer.DataContracts;
using Leadtools.Medical.WebViewer.Services.Interfaces;
using Leadtools.Medical.WebViewer.ServiceContracts;

namespace Leadtools.Medical.WebViewer.Services.Implementation
{


   public class MonitorCalibrationHandler : IMonitorCalibrationHandler
   {
      private IMonitorCalibrationAddin _MonitorCalibration;

      public MonitorCalibrationHandler(AddinsFactory factory)
      {
         _MonitorCalibration = factory.CreateMonitorCalibrationAddin();
      }

      public CalibrationItem[] GetCalibrations(string authenticationCookie)
      {
         AuthHandler.Authorize(authenticationCookie, null);

         return _MonitorCalibration.GetCalibrations();
      }

      public void AddCalibration(string authenticationCookie, CalibrationItem calibration)
      {
         AuthHandler.Authorize(authenticationCookie, null);

         _MonitorCalibration.AddCalibration(calibration);
      }
   }
}
