// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using Leadtools.Dicom.Common.DataTypes;

namespace DicomDemo.Queries
{
    public class BroadBasedQuery
    {

#if (LEADTOOLS_V18_OR_LATER)
        private DateRange _ScheduledProcedureStepStartDate = new DateRange();

        [TypeConverter(typeof(ExpandableObjectConverter))]
        [DisplayName("Scheduled Procedure Step Start Date")]
        public DateRange ScheduledProcedureStepStartDate
        {
            get { return _ScheduledProcedureStepStartDate; }
            set { _ScheduledProcedureStepStartDate = value; }
        }
#else
       private DateTime _ScheduledProcedureStepStartDate;

        [DisplayName("Scheduled Procedure Step Start Date")]
        public DateTime ScheduledProcedureStepStartDate
        {
            get { return _ScheduledProcedureStepStartDate; }
            set { _ScheduledProcedureStepStartDate = value; }
        }
#endif

        private string _Modality;
        
        public string Modality
        {
            get { return _Modality; }
            set { _Modality = value; }
        }

        private string _ScheduledStationAeTitle;

        [DisplayName("Scheduled Station AE")]
        public string ScheduledStationAeTitle
        {
            get { return _ScheduledStationAeTitle; }
            set { _ScheduledStationAeTitle = value; }
        }
    }
}
