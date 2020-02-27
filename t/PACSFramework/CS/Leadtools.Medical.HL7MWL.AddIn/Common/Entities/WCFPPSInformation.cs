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
    
    public class WCFPPSInformation : PPSInformation
    {
        private List<PPSDiscontinuationReasonCodeSequence> _PPSDiscontinuationReasonCodeSequence = new List<PPSDiscontinuationReasonCodeSequence>();

        
        public List<PPSDiscontinuationReasonCodeSequence> PPSDiscontinuationReasonCodeSequence
        {
            get { return _PPSDiscontinuationReasonCodeSequence; }
            set { _PPSDiscontinuationReasonCodeSequence = value; }
        }

        private List<ProcedureCodeSequence> _ProcedureCodeSequence = new List<ProcedureCodeSequence>();

        
        public List<ProcedureCodeSequence> ProcedureCodeSequence
        {
            get { return _ProcedureCodeSequence; }
            set { _ProcedureCodeSequence = value; }
        }

        private List<PerformedProtocolCodeSequence> _PerformedProtocolCodeSequence = new List<PerformedProtocolCodeSequence>();

        
        public List<PerformedProtocolCodeSequence> PerformedProtocolCodeSequence
        {
            get { return _PerformedProtocolCodeSequence; }
            set { _PerformedProtocolCodeSequence = value; }
        }

        private List<PPSRelationship> _PPSRelationShip = new List<PPSRelationship>();

        
        public List<PPSRelationship> PPSRelationShip
        {
            get { return _PPSRelationShip; }
            set { _PPSRelationShip = value; }
        }

        private List<PerformedSeriesSequence> _PerformedSeriesSequence = new List<PerformedSeriesSequence>();

        
        public List<PerformedSeriesSequence> PerformedSeriesSequence
        {
            get { return _PerformedSeriesSequence; }
            set { _PerformedSeriesSequence = value; }
        }

        private List<WCFReferencedImageSequence> _ReferencedImageSequence = new List<WCFReferencedImageSequence>();

        
        public List<WCFReferencedImageSequence> ReferencedImageSequence
        {
            get { return _ReferencedImageSequence; }
            set { _ReferencedImageSequence = value; }
        }

        private List<ReferencedNonImageCompositeSequence> _ReferencedNonImageCompositeSequence = new List<ReferencedNonImageCompositeSequence>();

        
        public List<ReferencedNonImageCompositeSequence> ReferencedNonImageCompositeSequence
        {
            get { return _ReferencedNonImageCompositeSequence; }
            set { _ReferencedNonImageCompositeSequence = value; }
        }

        
        public PatientInfoforUnscheduledPPS UnscheduledPatient { get; set; }

        
        public WCFPatient Patient { get; set; }
    }
}
