// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Dicom.Common.Attributes;
using Leadtools.Dicom;
using Leadtools.Dicom.Common.Extensions;

namespace DicomDemo.Dicom
{
    [Instance(DicomClassType.Undefined, NActionScu.PatientUpdateClass)]
    public class DeletePatient : PatientUpdate
    {
        private string _PatientId = string.Empty;

        [Element(DicomTag.PatientID)]
        public string PatientId
        {
            get { return _PatientId; }
            set { _PatientId = value; }
        }        
    }
}
