// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Dicom.Common.Attributes;
using Leadtools.Dicom.Common.Extensions;
using Leadtools.Dicom;

namespace DicomDemo.Dicom
{
    [Instance(DicomClassType.Undefined, NActionScu.PatientUpdateClass)]
    public class DeleteSeries : PatientUpdate
    {
        private string _StudyInstanceUID;

        [Element(DicomTag.StudyInstanceUID)]
        public string StudyInstanceUID
        {
            get { return _StudyInstanceUID; }
            set { _StudyInstanceUID = value; }
        }

        private string _SeriesInstanceUID;

        [Element(DicomTag.SeriesInstanceUID)]
        public string SeriesInstanceUID
        {
            get { return _SeriesInstanceUID; }
            set { _SeriesInstanceUID = value; }
        }
    }
}
