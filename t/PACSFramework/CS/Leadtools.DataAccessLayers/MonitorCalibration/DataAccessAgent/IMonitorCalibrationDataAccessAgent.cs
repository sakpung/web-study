// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security;
using Leadtools.Dicom.AddIn.Common;
using Leadtools.DataAccessLayers.Core;

namespace Leadtools.DataAccessLayers
{   
   public interface IMonitorCalibrationDataAccessAgent
   {
      List<Calibration> GetWorkstationCalibrations(string workstation);
      List<Calibration> GetAllCalibrations();
      void AddCalibration(Calibration calibration);
   }
}
