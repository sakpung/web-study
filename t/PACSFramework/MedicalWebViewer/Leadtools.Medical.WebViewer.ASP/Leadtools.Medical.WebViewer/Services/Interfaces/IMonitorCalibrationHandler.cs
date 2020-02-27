// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using Leadtools.Medical.WebViewer.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Leadtools.Medical.WebViewer.Services.Interfaces
{

   public interface IMonitorCalibrationHandler
   {
      CalibrationItem[] GetCalibrations(string authenticationCookie);
      void AddCalibration(string authenticationCookie, CalibrationItem calibration);
   }
}
