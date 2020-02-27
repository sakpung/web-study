// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Text;
using Leadtools.Dicom.AddIn.Interfaces;
using Leadtools.Dicom;
using Leadtools.Dicom.AddIn;
using Leadtools.Dicom.AddIn.Attributes;

namespace Leadtools.AddIn.Move
{

    [DicomAddIn("CMOVE AddIn", "1.0.0.0", Description = "Implements C-MOVE-REQ", Author = "")]
    public class MoveAddIn : IProcessCMove, IProcessCGet
    {
        internal BreakType BreakType;
        internal bool Cancel = false;

        #region IProcessCMove Members

        public event MoveDataSetDelegate MoveDataSet;

        [PresentationContext ( DicomUidType.PatientRootQueryGet, DicomUidType.ImplicitVRLittleEndian )]
        [PresentationContext ( DicomUidType.StudyRootQueryGet, DicomUidType.ImplicitVRLittleEndian )]
        public DicomCommandStatusType OnGet ( DicomClient Client, byte PresentationId, int MessageId, string AffectedClass, DicomCommandPriorityType Priority, DicomDataSet Request )
        {
           return DoCStores ( Client, PresentationId, MessageId, AffectedClass, Priority, Request );
        }

        [PresentationContext(DicomUidType.PatientRootQueryMove, DicomUidType.ImplicitVRLittleEndian)]
        [PresentationContext(DicomUidType.StudyRootQueryMove, DicomUidType.ImplicitVRLittleEndian)]
        public DicomCommandStatusType OnMove(DicomClient Client, byte PresentationId, int MessageId, string AffectedClass, DicomCommandPriorityType Priority, string MoveAE, DicomDataSet Request)
        {
           return DoCStores ( Client, PresentationId, MessageId, AffectedClass, Priority, Request );
        }

        #endregion

        internal DicomCommandStatusType OnMoveDataSet(MoveDataSetEventArgs e)
        {
            if (MoveDataSet != null)
            {
                MoveDataSet(this, e);
                return e.Status;
            }
            return DicomCommandStatusType.Success;
        }

        #region IProcessBreak Members

        public void Break(BreakType type)
        {
            Cancel = true;
            BreakType = type;
        }

        #endregion

        internal DicomCommandStatusType DoCStores ( DicomClient Client, byte PresentationId, int MessageId, string AffectedClass, DicomCommandPriorityType Priority, DicomDataSet Request )
        {
           if (Request == null)
              return DicomCommandStatusType.InvalidArgumentValue;

           try
           {
              string level = Request.GetValue<string> ( DicomTag.QueryRetrieveLevel, string.Empty );
              DicomCommandStatusType status = Module.GetAttributeStatus ( level, AffectedClass, Request );

              if (status != DicomCommandStatusType.Success)
              {
                 return status;
              }

              switch (level.ToUpper ( ))
              {
                 case "PATIENT":
                 case "STUDY":
                 case "SERIES":
                 case "IMAGE":
                    status = DB.MoveImages ( this, level, AffectedClass, Module.ConnectionString, Request );
                    break;
                 default:
                    return DicomCommandStatusType.InvalidAttributeValue;
              }
              return status;
           }
           catch
           {
              return DicomCommandStatusType.ProcessingFailure;
           }
        }

    }
}
