﻿// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Dicom;
using Leadtools.Dicom.Scp;

namespace Leadtools.Medical.HL7PatientUpdate.AddIn
{
   class OfflineNActionClientSessionProxy : DicomCommandClientSessionProxy, INActionClientSessionProxy
   {
      public OfflineNActionClientSessionProxy
      (
         ClientSession Session,
         byte presentationID,
         int messageID,
         string requestedClass,
         string requestedInstance,
         int actionTypeId,
         DicomDataSet responseDataSet
      )
         : base(Session, presentationID, messageID, requestedClass)
      {
         RequestedSopInstanceUID = requestedInstance;
         ActionTypeID = actionTypeId;
      }

      #region INActionClientSessionProxy Members

      public void SendNActionResponse
      (
         DicomCommandStatusType status,
         DicomDataSet responseDataset,
         string descriptionMessage
      )
      {
         Status = status;
         DescriptionMessage = descriptionMessage;
      }

      public string RequestedSopInstanceUID
      {
         get;
         set;
      }

      public int ActionTypeID
      {
         get;
         set;
      }
      public DicomDataSet ResponseDataSet
      {
         get;
         set;
      }
      #endregion

      public DicomCommandStatusType Status
      {
         get;
         set;
      }
      public string DescriptionMessage
      {
         get;
         set;
      }
   }
}
