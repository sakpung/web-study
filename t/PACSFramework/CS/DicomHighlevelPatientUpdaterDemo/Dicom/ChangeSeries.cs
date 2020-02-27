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
using Leadtools.Dicom.Common.DataTypes;

namespace DicomDemo.Dicom
{
    [Instance(DicomClassType.Undefined, NActionScu.PatientUpdateClass)]
    public class ChangeSeries : PatientUpdate
    {
        private DateTime? _SeriesDate;

        [Element(DicomTag.SeriesDate)]        
        public DateTime? SeriesDate
        {
            get { return _SeriesDate; }
            set { _SeriesDate = value; }
        }

        private DateTime? _SeriesTime;

        [Element(DicomTag.SeriesTime)]
        public DateTime? SeriesTime
        {
            get { return _SeriesTime; }
            set { _SeriesTime = value; }
        }

        private string _SeriesDescription;

        [Element(DicomTag.SeriesDescription)]
        public string SeriesDescription
        {
            get { return _SeriesDescription; }
            set { _SeriesDescription = value; }
        }

        private string _Modality;

        [Element(DicomTag.Modality)]
        public string Modality
        {
            get { return _Modality; }
            set { _Modality = value; }
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
