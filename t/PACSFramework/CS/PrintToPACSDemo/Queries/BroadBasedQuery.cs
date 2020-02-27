// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using Leadtools.Dicom.Common.DataTypes;
using Leadtools.Dicom.Common.Extensions;
using Leadtools.Dicom;

namespace PrintToPACSDemo.Queries
{
    public class BroadBasedQuery
    {

        private DateRange _ScheduledProcedureStepStartDate = new DateRange();

        [DisplayName("Scheduled Procedure Step Start Date")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public DateRange ScheduledProcedureStepStartDate
        {
            get { return _ScheduledProcedureStepStartDate; }
            set { _ScheduledProcedureStepStartDate = value; }
        }

        private string _Modality;

        [Browsable(true)]
        [Category("Study")]
        [Description("Modalities in Study")]
        [DisplayName("Modalities in Study")]
        [TypeConverter(typeof(DicomModalityConvertor))]
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
