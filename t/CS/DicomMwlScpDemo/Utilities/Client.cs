// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Text;
using System.Threading;
using System.Collections.Generic;

using Leadtools.Dicom;

namespace DicomDemo
{
   public class Client : DicomNet
   {
      DicomTimer _Timer;
      Server server;
      Thread procThread = null;

      public DicomTimer Timer
      {
         get
         {
            return _Timer;
         }
      }

#if !LEADTOOLS_V20_OR_LATER
      public Client(Server server)
         : base(null, DicomNetSecurityeMode.None)
      {
         this.server = server;
         _Timer = new DicomTimer(this, 30);
      }
#else
      public Client(Server server)
         : base(null, DicomNetSecurityMode.None)
      {
         this.server = server;
         _Timer = new DicomTimer(this, 30);
      }
#endif // #if !LEADTOOLS_V20_OR_LATER

      protected override string OnPrivateKeyPassword(bool encryption)
      {
         return "test";
      }

      protected override void OnReceiveAssociateRequest(DicomAssociate association)
      {
         server.DoAssociateRequest(this, association);
      }

       protected override void OnReceiveReleaseRequest()
       {
           server.Clients.Remove(PeerAddress);
           SendReleaseResponse();
       }

      protected void StartAction(DicomAction action)
      {
         if(procThread != null && procThread.IsAlive)
         {
            procThread.Abort();
            procThread = null;
         }
         procThread = new Thread(new ThreadStart(action.DoAction));
         procThread.Start();
      }

      /*
       * Handles a CEcho request
       */
      protected override void OnReceiveCEchoRequest(byte presentationID, int messageID, string affectedClass)
      {
         DicomAction action = server.InitAction("C-ECHO-REQUEST", ProcessType.EchoRequest, this, null);

         action.PresentationID = presentationID;
         action.MessageID = messageID;
         action.Class = affectedClass;
         StartAction(action);
      }

      /*
       * Handles a CFind request
       */
      protected override void OnReceiveCFindRequest(byte presentationID, int messageID, string affectedClass, DicomCommandPriorityType priority, DicomDataSet dataSet)
      {
         DicomAction action = server.InitAction("C-FIND-REQUEST", ProcessType.FindRequest, this, dataSet);

         action.PresentationID = presentationID;
         action.MessageID = messageID;
         action.Class = affectedClass;
         action.Priority = priority;
         StartAction(action);
         
         dataSet.Dispose ( ) ;
      }

      protected override void OnReceiveData(byte presentationID, DicomDataSet cs, DicomDataSet ds)
      {
         base.OnReceiveData(presentationID, cs, ds);
         if ( null != cs ) 
         {
            cs.Dispose ( ) ;
         }
      }
   }
}
