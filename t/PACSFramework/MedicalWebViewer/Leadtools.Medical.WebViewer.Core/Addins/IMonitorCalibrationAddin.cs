// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Medical.WebViewer.DataContracts;

namespace Leadtools.Medical.WebViewer.ServiceContracts
{
    public interface IMonitorCalibrationAddin
    {
        CalibrationItem[] GetCalibrations();
        void AddCalibration(CalibrationItem item);
    }
}
