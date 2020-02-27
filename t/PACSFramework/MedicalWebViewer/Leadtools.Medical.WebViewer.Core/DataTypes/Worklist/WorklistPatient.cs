// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Leadtools.Dicom;
using Leadtools.Dicom.Common.DataTypes;
using Leadtools.Medical.Worklist.DataAccessLayer.MatchingParameters;

namespace Leadtools.Medical.WebViewer.DataContracts
{
    [DataContract]
    public class WorklistPatient : Patient
    {
        private PersonName _PersonName;

        public WorklistPatient()
        {
            _PersonName = new PersonName();    
        }
        
        private List<String> _ContrastAllergies = new List<string>();

        [DataMember]
        public List<String> ContrastAllergies
        {
            get { return _ContrastAllergies; }
            set { _ContrastAllergies = value; }
        }

        private List<string> _MedicalAlerts = new List<string>();

        [DataMember]
        public List<string> MedicalAlerts
        {
            get { return _MedicalAlerts; }
            set { _MedicalAlerts = value; }
        }

        private List<string> _OtherPatientIDs = new List<string>();

        [DataMember]
        public List<string> OtherPatientIDs
        {
            get { return _OtherPatientIDs; }
            set { _OtherPatientIDs = value; }
        }

        [DataMember]
        public string PatientName
        {
            get
            {
                _PersonName.Family = !string.IsNullOrEmpty(PatientNameFamilyName)?PatientNameFamilyName:string.Empty;
                _PersonName.Given = !string.IsNullOrEmpty(PatientNameGivenName)?PatientNameGivenName:string.Empty;
                _PersonName.Middle = !string.IsNullOrEmpty(PatientNameMiddleName)?PatientNameMiddleName:string.Empty;
                _PersonName.Prefix = !string.IsNullOrEmpty(PatientNamePrefix)?PatientNamePrefix:string.Empty;
                _PersonName.Suffix = !string.IsNullOrEmpty(PatientNameSuffix) ? PatientNameSuffix : string.Empty;
                return _PersonName.Full;
            }
            set
            {
                _PersonName = new PersonName(value);
            }
        }
    }
}
