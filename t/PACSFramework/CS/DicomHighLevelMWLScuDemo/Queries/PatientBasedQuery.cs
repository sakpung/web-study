// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Text;
using Leadtools.Dicom.Common.DataTypes;
using Leadtools.Dicom.Common.Extensions;
using Leadtools.Dicom;
using System.ComponentModel;
using Leadtools.Dicom.Common.Editing.Converters;

namespace DicomDemo.Queries
{
    class PatientBasedQuery
    {
        private PersonName _PatientName = new PersonName();
        
        [TypeConverter(typeof(PersonNameConverter))]
        [DisplayName("Person Name")]
        public PersonName PatientName
        {
            get { return _PatientName; }
            set { _PatientName = value; }
        }

        private string _PatientId = string.Empty;

        [DisplayName("Patient ID")]
        public string PatientId
        {
            get { return _PatientId; }
            set { _PatientId = value; }
        }

        private string _AccessionNumber = string.Empty;

        [DisplayName("Accession #")]
        public string AccessionNumber
        {
            get { return _AccessionNumber; }
            set { _AccessionNumber = value; }
        }

        private string _RequestedProcedureId = string.Empty;

        [DisplayName("Requested Procedure ID")]
        public string RequestedProcedureId
        {
            get { return _RequestedProcedureId; }
            set { _RequestedProcedureId = value; }
        }
    }
}
