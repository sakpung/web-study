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

namespace DicomDemo.Dicom
{
    public class MergePatientSequence
    {
        private string _PatientId = string.Empty;

        [Element(DicomTag.PatientID)]
        public string PatientId
        {
            get { return _PatientId; }
            set { _PatientId = value; }
        }

        public MergePatientSequence(string patientID)
        {
            _PatientId = patientID;
        }
    }
}
