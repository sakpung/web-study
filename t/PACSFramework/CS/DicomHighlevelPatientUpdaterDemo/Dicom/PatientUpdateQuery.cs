// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Dicom.Scu;
using Leadtools.Dicom;
using System.Windows.Forms;

namespace DicomDemo.Dicom
{
    public class PatientUpdateQuery : QueryRetrieveScu
    {

       public new bool Rejected
       {
          get { return _Rejected; }
       }

        private string _Reason;

        public string Reason
        {
            get { return _Reason; }
        }       
        
        public PatientUpdateQuery()
            : base()
        {
        }

#if !LEADTOOLS_V20_OR_LATER
        public PatientUpdateQuery(string TemporaryDirectory, DicomNetSecurityeMode SecurityMode, DicomOpenSslContextCreationSettings openSslContextCreationSettings)
           : base(TemporaryDirectory, SecurityMode, openSslContextCreationSettings)
        {
        }
#else
        public PatientUpdateQuery(string TemporaryDirectory, DicomNetSecurityMode SecurityMode, DicomOpenSslContextCreationSettings openSslContextCreationSettings)
            : base(TemporaryDirectory, SecurityMode, openSslContextCreationSettings)
        {
        }
#endif // #if !LEADTOOLS_V20_OR_LATER

        protected override void OnReceiveAssociateReject(DicomAssociateRejectResultType result, DicomAssociateRejectSourceType source, DicomAssociateRejectReasonType reason)
        {           
            base.OnReceiveAssociateReject(result, source, reason);           
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
