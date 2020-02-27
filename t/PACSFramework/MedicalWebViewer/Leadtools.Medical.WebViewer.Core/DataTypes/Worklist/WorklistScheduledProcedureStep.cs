// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using Leadtools.Medical.Worklist.DataAccessLayer.MatchingParameters;

namespace Leadtools.Medical.WebViewer.DataContracts
{
    [DataContract]
    public class WorklistScheduledProcedureStep : ScheduledProcedureStep
    {
        private List<ScheduledProtocolCodeSequence> _ScheduledProtocolCodeSequence = new List<ScheduledProtocolCodeSequence>();

        [DataMember]
        public List<ScheduledProtocolCodeSequence> ScheduledProtocolCodeSequence
        {
            get { return _ScheduledProtocolCodeSequence; }
            set { _ScheduledProtocolCodeSequence = value; }
        }

        private List<string> _ScheduledStationAETitle = new List<string>();

        [DataMember]
        public List<string> ScheduledStationAETitle
        {
            get { return _ScheduledStationAETitle; }
            set { _ScheduledStationAETitle = value; }
        }

        private List<string> _ScheduledStationName = new List<string>();

        [DataMember]
        public List<string> ScheduledStationName
        {
            get { return _ScheduledStationName; }
            set { _ScheduledStationName = value; }
        }
    }
}
