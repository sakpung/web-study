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
   public class NotifyReceiveMessage : NotifyReceiveMessageBase
   {
      public override void OnReceiveCStoreRequest
      (
         DicomClient Client, 
         byte presentationID, 
         int messageID, 
         string affectedClass, 
         string instance, 
         Leadtools.Dicom.DicomCommandPriorityType priority, 
         string moveAE, 
         int moveMessageID, 
         Leadtools.Dicom.DicomDataSet dataSet
      )
      {
         base.OnReceiveCStoreRequest(Client, presentationID, messageID, affectedClass, instance, priority, moveAE, moveMessageID, dataSet);
         
         ServerEventBroker.Instance.PublishEvent <CStoreRequestReceivedEventArgs> ( this, new CStoreRequestReceivedEventArgs ( instance, dataSet ) ) ;
      }
   }
   
   
   public class CStoreRequestReceivedEventArgs : EventArgs
   {
      public CStoreRequestReceivedEventArgs ( string instanceUID, DicomDataSet request )
      {
         RequestDataSet = request ;
         SopInstanceUID = instanceUID ;
      }
      
      public DicomDataSet RequestDataSet
      {
         get;
         private set ;
      }
      public string SopInstanceUID
      {
         get ;
         private set ;
      }
   }
}
