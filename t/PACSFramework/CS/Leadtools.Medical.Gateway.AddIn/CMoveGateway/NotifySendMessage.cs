// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Dicom.AddIn;
using Leadtools.Dicom;

namespace Leadtools.Medical.Gateway
{
   public class NotifySendMessage : NotifySendMessageBase
   {
      public override void OnSendCStoreResponse(DicomClient Client, byte presentationID, int messageID, string affectedClass, string instance, Leadtools.Dicom.DicomCommandStatusType status)
      {
         base.OnSendCStoreResponse ( Client, presentationID, messageID, affectedClass, instance, status ) ;
         
         ServerEventBroker.Instance.PublishEvent <CStoreResponseSentEventArgs> ( this, new CStoreResponseSentEventArgs ( instance, status ) ) ;
      }
   }
   
   public class CStoreResponseSentEventArgs : EventArgs
   {
      public CStoreResponseSentEventArgs ( string instance, DicomCommandStatusType status )
      {
         Instance = instance ;
         Status   = status ;
      }
      
      public string Instance
      {
         get ;
         private set ;
      }
      
      public DicomCommandStatusType Status
      {
         get ;
         private set ;
      }
   }
}
