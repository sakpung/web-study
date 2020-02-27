// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Text;
using Leadtools.Dicom.Scu;
using Leadtools.Dicom;

namespace DicomDemo
{
    public class MyPerformedProcedureStepScu : PerformedProcedureStepScu
    {
        private const string _sNewlineTab = "\r\n\t";
        public MainForm _mainForm = null;

        private DicomCommandStatusType _Status = DicomCommandStatusType.Success;

        public DicomCommandStatusType Status
        {
            get { return _Status; }
            set { _Status = value; }
        }

        public MyPerformedProcedureStepScu(MainForm mainForm)
            : base()
        {
            _mainForm = mainForm;
        }

#if LEADTOOLS_V20_OR_LATER
        public MyPerformedProcedureStepScu(MainForm mainForm, string TemporaryDirectory, DicomNetSecurityMode SecurityMode, DicomOpenSslContextCreationSettings openSslContextCreationSettings) :
            base(TemporaryDirectory, SecurityMode, openSslContextCreationSettings)
        {
            _mainForm = mainForm;
        }
#else
        public MyPerformedProcedureStepScu(MainForm mainForm, string TemporaryDirectory, DicomNetSecurityeMode SecurityMode, DicomOpenSslContextCreationSettings openSslContextCreationSettings) :
            base(TemporaryDirectory, SecurityMode, openSslContextCreationSettings)
        {
            _mainForm = mainForm;
        }
#endif // #if LEADTOOLS_V20_OR_LATER

        protected override void OnReceiveNCreateResponse(byte presentationID, int messageID, string affectedClass, string instance, DicomCommandStatusType status, DicomDataSet dataSet)
        {           
            base.OnReceiveNCreateResponse(presentationID, messageID, affectedClass, instance, status, dataSet);
            _Status = status;
        }

        protected override void OnReceiveNSetResponse(byte presentationID, int messageID, string affectedClass, string instance, DicomCommandStatusType status, DicomDataSet dataSet)
        {                                
            base.OnReceiveNSetResponse(presentationID, messageID, affectedClass, instance, status, dataSet);
            _Status = status;
        }

        protected override void OnReceiveReleaseResponse()
        {
            if ((_mainForm != null) && (_mainForm._mySettings.LogLowLevel))
            {
                _mainForm.LogText("OnReceiveReleaseResponse", string.Empty, System.Drawing.Color.Green);
            }
            base.OnReceiveReleaseResponse();
        }

        protected override void OnReceiveAssociateAccept(DicomAssociate association)
        {
            if ((_mainForm != null) && (_mainForm._mySettings.LogLowLevel))
            {
                _mainForm.LogText("OnReceiveAssociateAccept", string.Empty, System.Drawing.Color.Green);
            }
            base.OnReceiveAssociateAccept(association);
        }
    }
}
