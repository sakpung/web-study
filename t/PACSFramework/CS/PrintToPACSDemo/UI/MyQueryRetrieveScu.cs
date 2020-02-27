// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Text;

using Leadtools;
using Leadtools.Dicom;
using Leadtools.Dicom.Scu;
using Leadtools.Dicom.Scu.Common;
using Leadtools.Demos;

namespace PrintToPACSDemo
{
    public class MyQueryRetrieveScu : QueryRetrieveScu
    {
        private const string _sNewlineTab = "\r\n\t";
        public FrmMain _mainForm = null;


           // Summary:
        //     Initializes a new instance of the Leadtools.Dicom.Scu.QueryRetrieveScu class.
       public MyQueryRetrieveScu()
          : base()
       {
       }

       public MyQueryRetrieveScu(FrmMain mainForm)
          : base()
       {
          _mainForm = mainForm;
       }

#if !LEADTOOLS_V20_OR_LATER
       public MyQueryRetrieveScu(FrmMain mainForm, string TemporaryDirectory, DicomNetSecurityeMode SecurityMode, DicomOpenSslContextCreationSettings openSslContextCreationSettings) :
          base(TemporaryDirectory, SecurityMode, openSslContextCreationSettings)
       {
          _mainForm = mainForm;
       }
#else
      public MyQueryRetrieveScu(FrmMain mainForm, string TemporaryDirectory, DicomNetSecurityMode SecurityMode, DicomOpenSslContextCreationSettings openSslContextCreationSettings) :
            base(TemporaryDirectory, SecurityMode, openSslContextCreationSettings)
      {
         _mainForm = mainForm;
      }
#endif // #if !LEADTOOLS_V20_OR_LATER


       protected override void OnReceive(DicomExceptionCode error, DicomPduType pduType, IntPtr buffer, int bytes)
        {
            // Uncomment the lines below to log the OnReceive events
            //if ((_mainForm != null) && (_mainForm._mySettings._settings.logLowLevel))
            //{
            //   string sMsg =
            //      _sNewlineTab + "error:\t" + error.ToString() +
            //      _sNewlineTab + "pduType:\t" + pduType.ToString() +
            //      _sNewlineTab + "bytes:\t" + bytes.ToString();

            //   _mainForm.LogText("OnReceive", sMsg, System.Drawing.Color.Green);
            //}
            base.OnReceive(error, pduType, buffer, bytes);
        }

        protected override void OnReceiveCStoreRequest(QueryRetrieveScu scu,byte presentationID, int messageID, string affectedClass, string instance, DicomCommandPriorityType priority, string moveAE, int moveMessageID, DicomDataSet dataSet)
        {
            if ((_mainForm != null) && (_mainForm._mySettings._settings.logLowLevel))
            {
               string sMsg =
                  _sNewlineTab + "scu:\t" + scu.ToString() +
                  _sNewlineTab + "presentationID:\t" + presentationID.ToString() +
                  _sNewlineTab + "messageID:\t" + messageID.ToString() +
                  _sNewlineTab + "affectedClass:\t" + affectedClass +
                  _sNewlineTab + "instance:\t" + instance +
                  _sNewlineTab + "priority:\t" + priority.ToString() +
                  _sNewlineTab + "moveAE:\t" + moveAE +
                  _sNewlineTab + "moveMessageID:\t" + moveMessageID.ToString();

               _mainForm.LogText("OnReceiveCStoreRequest", sMsg, System.Drawing.Color.Green);
            }
            base.OnReceiveCStoreRequest(scu,presentationID, messageID, affectedClass, instance, priority, moveAE, moveMessageID, dataSet);
        }

       protected override void OnReceiveCFindResponse(byte presentationID, int messageID, string affectedClass, DicomCommandStatusType status, DicomDataSet dataSet)
       {
          if ((_mainForm != null) && (_mainForm._mySettings._settings.logLowLevel))
          {
             string sMsg =
                _sNewlineTab + "presentationID:\t" + presentationID.ToString() +
                _sNewlineTab + "messageID:\t" + messageID.ToString() +
                _sNewlineTab + "affectedClass:\t" + affectedClass +
                _sNewlineTab + "status:\t" + status.ToString();

             _mainForm.LogText("OnReceiveCFindResponse", sMsg, System.Drawing.Color.Green);
          }
          base.OnReceiveCFindResponse(presentationID, messageID, affectedClass, status, dataSet);
       }

       protected override void OnReceiveReleaseResponse()
       {
          if ((_mainForm != null) && (_mainForm._mySettings._settings.logLowLevel))
          {
             _mainForm.LogText("OnReceiveReleaseResponse", string.Empty, System.Drawing.Color.Green);
          }
          base.OnReceiveReleaseResponse();
       }

       protected override void OnReceiveAssociateAccept(DicomAssociate association)
       {
          if ((_mainForm != null) && (_mainForm._mySettings._settings.logLowLevel))
          {
             _mainForm.LogText("OnReceiveAssociateAccept", string.Empty, System.Drawing.Color.Green);
          }
          base.OnReceiveAssociateAccept(association);
       }
    }
}
