// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Medical.Worklist.DataAccessLayer.MatchingParameters;
using System.Runtime.Serialization;

namespace Leadtools.Medical.HL7MWL.AddIn
{
    
    public class WCFScheduledProcedureStep : ScheduledProcedureStep
    {
        private List<ScheduledProtocolCodeSequence> _ScheduledProtocolCodeSequence = new List<ScheduledProtocolCodeSequence>();

        
        public List<ScheduledProtocolCodeSequence> ScheduledProtocolCodeSequence
        {
            get { return _ScheduledProtocolCodeSequence; }
            set { _ScheduledProtocolCodeSequence = value; }
        }

        private List<string> _ScheduledStationAETitle = new List<string>();

        
        public List<string> ScheduledStationAETitle
        {
            get { return _ScheduledStationAETitle; }
            set { _ScheduledStationAETitle = value; }
        }

        private List<string> _ScheduledStationName = new List<string>();

        
        public List<string> ScheduledStationName
        {
            get { return _ScheduledStationName; }
            set { _ScheduledStationName = value; }
        }
    }
}
