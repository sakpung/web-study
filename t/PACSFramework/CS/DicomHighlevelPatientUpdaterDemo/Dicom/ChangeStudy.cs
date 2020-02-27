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
using System.ComponentModel;
using Leadtools.Dicom.Common.Editing.Converters;

namespace DicomDemo.Dicom
{
    [Instance(DicomClassType.Undefined, NActionScu.PatientUpdateClass)]
    public class ChangeStudy : PatientUpdate
    {
        private DateTime? _StudyDate;

        [Element(DicomTag.StudyDate)]
        public DateTime? StudyDate
        {
            get { return _StudyDate; }
            set { _StudyDate = value; }
        }

        private string _StudyDescription;

        [Element(DicomTag.StudyDescription)]
        public string StudyDescription
        {
            get { return _StudyDescription; }
            set { _StudyDescription = value; }
        }

        private string _StudyID;
        [Element(DicomTag.StudyID)]
        public string StudyID
        {
            get { return _StudyID; }
            set { _StudyID = value; }
        }

        private string _AccessionNumber;
        [Element(DicomTag.AccessionNumber)]
        public string AccessionNumber
        {
            get { return _AccessionNumber; }
            set { _AccessionNumber = value; }
        }

        private DicomAgeValue? _PatientAge;
        [Element(DicomTag.PatientAge)]
        [TypeConverter(typeof(DicomAgeValueConverter))]
        public DicomAgeValue? PatientAge
        {
            get { return _PatientAge; }
            set { _PatientAge = value; }
        }

        private double? _PatientSize;
        [Element(DicomTag.PatientSize)]
        public double? PatientSize
        {
            get { return _PatientSize; }
            set { _PatientSize = value; }
        }

        private double? _PatientWeight;
        [Element(DicomTag.PatientWeight)]
        public double? PatientWeight
        {
            get { return _PatientWeight; }
            set { _PatientWeight = value; }
        }

        private string _StudyInstanceUID;

        [Element(DicomTag.StudyInstanceUID)]
        public string StudyInstanceUID
        {
            get { return _StudyInstanceUID; }
            set { _StudyInstanceUID = value; }
        }
    }
}
