// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Dicom.Common.Extensions;
using Leadtools.Dicom;
using Leadtools.Dicom.Common.Attributes;

namespace DicomDemo.Dicom
{
    [Instance(DicomClassType.Undefined, NActionScu.PatientUpdateClass)]
    public class MergeStudy : PatientUpdate
    {
        private string _PatientId = string.Empty;

        [Element(DicomTag.PatientID)]
        public string PatientId
        {
            get { return _PatientId; }
            set { _PatientId = value; }
        }

        private string _StudyInstanceUID;

        [Element(DicomTag.StudyInstanceUID)]
        public string StudyInstanceUID
        {
            get { return _StudyInstanceUID; }
            set { _StudyInstanceUID = value; }
        }

        private List<MergePatientSequence> _PatientToMerge = new List<MergePatientSequence>();

        [Element(DicomTag.ReferencedPatientSequence)]
        public List<MergePatientSequence> PatientToMerge
        {
            get { return _PatientToMerge; }
            set { _PatientToMerge = value; }
        }
    }

    [Instance(DicomClassType.Undefined, NActionScu.PatientUpdateClass)]
    public class MoveSeries : PatientUpdate
    {
       private string _PatientId = string.Empty;

       [Element(DicomTag.PatientID)]
       public string PatientId
       {
          get { return _PatientId; }
          set { _PatientId = value; }
       }

       private string _SeriesInstanceUID;

       [Element(DicomTag.SeriesInstanceUID)]
       public string SeriesInstanceUID
       {
          get { return _SeriesInstanceUID; }
          set { _SeriesInstanceUID = value; }
       }

       private List<MergePatientSequence> _PatientToMerge = new List<MergePatientSequence>();

       [Element(DicomTag.ReferencedPatientSequence)]
       public List<MergePatientSequence> PatientToMerge
       {
          get { return _PatientToMerge; }
          set { _PatientToMerge = value; }
       }
    }
}
