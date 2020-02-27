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
using Leadtools.Dicom.Common.DataTypes;
using System.ComponentModel;
using Leadtools.Dicom.Common.Editing.Converters;
using Leadtools.Dicom.Common.DataTypes.PatientUpdater;

namespace DicomDemo.Dicom
{
    [Instance(DicomClassType.Undefined, NActionScu.PatientUpdateClass)]
    public class CopyPatient : PatientUpdate
    {
        private string _OriginalPatientId = string.Empty;

        [Element(DicomTag.OtherPatientIDs)]
        public string OriginalPatientId
        {
            get { return _OriginalPatientId; }
            set { _OriginalPatientId = value; }
        }

        private string _PatientId = string.Empty;

        [Element(DicomTag.PatientID)]
        public string PatientId
        {
            get { return _PatientId; }
            set { _PatientId = value; }
        }

        private PersonName _Name = new PersonName();

        [Element(DicomTag.PatientName)]
        [TypeConverter(typeof(PersonNameConverter))]
        public PersonName Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        private string _Sex;

        [Element(DicomTag.PatientSex)]
        public string Sex
        {
            get { return _Sex; }
            set { _Sex = value; }
        }

        private DateTime? _Birthdate;

        [Element(DicomTag.PatientBirthDate)]
        public DateTime? Birthdate
        {
            get { return _Birthdate; }
            set { _Birthdate = value; }
        }
#if (LEADTOOLS_V19_OR_LATER)
        [Element(DicomTag.OtherPatientIDsSequence)]
        public List<OtherPatientID> OtherPatientIdsSequence { get; set; }
#endif
    }
}
