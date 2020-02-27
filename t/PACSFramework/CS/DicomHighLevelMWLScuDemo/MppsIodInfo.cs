// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Text;
using Leadtools.Dicom.Common.Extensions;
using Leadtools.Dicom;
using Leadtools.Dicom.Common.DataTypes;

namespace DicomDemo
{
    public class MppsIodInfo
    {
        private string _StudyInstanceUID;

        [Element(DicomTag.StudyInstanceUID)]
        public string StudyInstanceUID
        {
            get { return _StudyInstanceUID; }
            set { _StudyInstanceUID = value; }
        }

        private List<SopInstanceReference> _ReferencedStudySequence;
        
        [Element(DicomTag.ReferencedStudySequence)]
        public List<SopInstanceReference> ReferencedStudySequence
        {
            get { return _ReferencedStudySequence; }
            set { _ReferencedStudySequence = value; }
        }

        private string _AccessionNumber;

        [Element(DicomTag.AccessionNumber)]
        public string AccessionNumber
        {
            get { return _AccessionNumber; }
            set { _AccessionNumber = value; }
        }

        private List<RequestAttributes> _RequestAttributesSequence;

        [Element(DicomTag.RequestAttributesSequence)]
        public List<RequestAttributes> RequestAttributesSequence
        {
            get { return _RequestAttributesSequence; }
            set { _RequestAttributesSequence = value; }
        }

        private string _StudyID;

        [Element(DicomTag.StudyID)]
        public string StudyID
        {
            get { return _StudyID; }
            set { _StudyID = value; }
        }

        private string _PerformedProcedureStepID;

        [Element(DicomTag.PerformedProcedureStepID)]
        public string PerformedProcedureStepID
        {
            get { return _PerformedProcedureStepID; }
            set { _PerformedProcedureStepID = value; }
        }

        private DateTime? _PerformedProcedureStepStartDate;

        [Element(DicomTag.PerformedProcedureStepStartDate)]
        public DateTime? PerformedProcedureStepStartDate
        {
            get { return _PerformedProcedureStepStartDate; }
            set { _PerformedProcedureStepStartDate = value; }
        }

        private DateTime? _PerformedProcedureStepStartTime;

        [Element(DicomTag.PerformedProcedureStepStartTime)]
        public DateTime? PerformedProcedureStepStartTime
        {
            get { return _PerformedProcedureStepStartTime; }
            set { _PerformedProcedureStepStartTime = value; }
        }

        private string _PerformedProcedureStepDescription;

        [Element(DicomTag.PerformedProcedureStepDescription)]
        public string PerformedProcedureStepDescription
        {
            get { return _PerformedProcedureStepDescription; }
            set { _PerformedProcedureStepDescription = value; }
        }

        private List<CodeSequence> _ProcedureCodeSequence = new List<CodeSequence>();
        
        [Element(DicomTag.ProcedureCodeSequence)]
        public List<CodeSequence> ProcedureCodeSequence
        {
            get { return _ProcedureCodeSequence; }
            set { _ProcedureCodeSequence = value; }
        }

        private List<SopInstanceReference> _ReferencedPerformedProcedureStepSequence;

        [Element(DicomTag.ReferencedPerformedProcedureStepSequence)]
        public List<SopInstanceReference> ReferencedPerformedProcedureStepSequence
        {
            get { return _ReferencedPerformedProcedureStepSequence; }
            set { _ReferencedPerformedProcedureStepSequence = value; }
        }

        private string _ProtocolName;

        [Element(DicomTag.ProtocolName)]
        public string ProtocolName
        {
            get { return _ProtocolName; }
            set { _ProtocolName = value; }
        }
    }
}
