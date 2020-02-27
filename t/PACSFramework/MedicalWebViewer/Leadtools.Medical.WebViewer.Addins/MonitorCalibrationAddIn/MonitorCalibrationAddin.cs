// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.DataAccessLayers;
using Leadtools.DataAccessLayers.Core;
using Leadtools.Medical.WebViewer.Core.Addins;
using Leadtools.Medical.WebViewer.DataContracts;
using Leadtools.Medical.WebViewer.ServiceContracts;

namespace Leadtools.Medical.WebViewer.Addins
{
    public class MonitorCalibrationAddin : IMonitorCalibrationAddin
    {
        private IMonitorCalibrationDataAccessAgent _DataAccessAgent;

        public MonitorCalibrationAddin(IMonitorCalibrationDataAccessAgent agent)
        {
            _DataAccessAgent = agent;
        }

        public CalibrationItem[] GetCalibrations()
        {
            List<Calibration> calibrations = _DataAccessAgent.GetAllCalibrations();
            List<CalibrationItem> items = new List<CalibrationItem>();

            foreach(Calibration item in calibrations)
            {
                CalibrationItem ci = new CalibrationItem();

                ci.CalibrationTime = item.CalibrationTime.ToString();
                ci.Comments = item.Comments;
                ci.Username = item.Username;
                ci.Workstation = item.Workstation;
                items.Add(ci);
            }

            return items.ToArray();
        }

        public void AddCalibration(CalibrationItem item)
        {    
            Calibration calibration = new Calibration(DateTime.Parse(item.CalibrationTime), item.Username, item.Workstation, item.Comments);

            _DataAccessAgent.AddCalibration(calibration);
        }
    }
}
