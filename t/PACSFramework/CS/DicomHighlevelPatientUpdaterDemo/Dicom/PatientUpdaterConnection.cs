// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Dicom.Scu.Common;
using Leadtools.Dicom;

namespace DicomDemo.Dicom
{
    public class PatientUpdaterConnection : DicomConnection
    {
        private new bool _Rejected = false;

        public new bool Rejected
        {
            get { return _Rejected; }           
        }       

        private string _Reason;

        public string Reason
        {
            get { return _Reason; }            
        }

        protected override void OnReceiveAssociateReject(DicomAssociateRejectResultType result, DicomAssociateRejectSourceType source, DicomAssociateRejectReasonType reason)
        {
            base.OnReceiveAssociateReject(result, source, reason);                       
            _Rejected = true;
            switch (reason)
            {
                case DicomAssociateRejectReasonType.Called:
                    _Reason = "Called AE Title not recognized.";
                    break;
                case DicomAssociateRejectReasonType.Calling:
                    _Reason = "Calling AE Title not recognized.";
                    break;               
                case DicomAssociateRejectReasonType.Congestion:
                    _Reason = "Temporary congestion";
                    break;
                default:
                    _Reason = "Uknown association rejection.";
                    break;
            }
        }
    }
}
