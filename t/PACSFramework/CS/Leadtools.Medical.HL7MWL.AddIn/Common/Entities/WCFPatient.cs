// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Leadtools.Medical.Worklist.DataAccessLayer.MatchingParameters;

namespace Leadtools.Medical.HL7MWL.AddIn
{
    
    public class WCFPatient : Patient
    {
        private List<String> _ContrastAllergies = new List<string>();

        
        public List<String> ContrastAllergies
        {
            get { return _ContrastAllergies; }
            set { _ContrastAllergies = value; }
        }

        private List<string> _MedicalAlerts = new List<string>();

        
        public List<string> MedicalAlerts
        {
            get { return _MedicalAlerts; }
            set { _MedicalAlerts = value; }
        }

        private List<string> _OtherPatientIDs = new List<string>();

        
        public List<string> OtherPatientIDs
        {
            get { return _OtherPatientIDs; }
            set { _OtherPatientIDs = value; }
        }

         private string _ScheduledStationAE;

         public string ScheduledStationAE
         {
            get { return _ScheduledStationAE; }
            set { _ScheduledStationAE = value; }
         }
   }
}
