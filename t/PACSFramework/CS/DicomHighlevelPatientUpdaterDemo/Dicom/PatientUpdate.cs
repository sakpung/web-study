// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Dicom.Common.Extensions;
using Leadtools.Dicom;

namespace DicomDemo.Dicom
{
    public class PatientUpdate
    {
        private string _Description = string.Empty;

        [Element(DicomTag.RequestedProcedureDescription)]
        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }

        private string _Reason;

        [Element(DicomTag.ReasonForTheRequestedProcedure)]
        public string Reason
        {
            get { return _Reason; }
            set { _Reason = value; }
        }

        private string _Operator = string.Empty;

        [Element(DicomTag.OperatorName)]
        public string Operator
        {
            get { return _Operator; }
            set { _Operator = value; }
        }

        private string _Station = Environment.MachineName;

        [Element(DicomTag.StationName)]
        public string Station
        {
            get { return _Station; }
            set { _Station = value; }
        }        

        private DateTime _Date = DateTime.Now;

        [Element(DicomTag.InstanceCreationDate)]
        public DateTime Date
        {
            get { return _Date; }
            set { _Date = value; }
        }

        private DateTime _Time = DateTime.Now;

        [Element(DicomTag.InstanceCreationTime)]
        public DateTime Time
        {
            get { return _Time; }
            set { _Time = value; }
        }

        private string _TransactionID = Guid.NewGuid().ToString();

        [Element(DicomTag.TransactionUID)]
        public string TransactionID
        {
            get { return _TransactionID; }
            set { _TransactionID = value; }
        }
    }    
}
