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
      DicomAction action;

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

      //Use this constructor for TLS secure communication
#if !LEADTOOLS_V20_OR_LATER
      public Client(Server server, bool reserved)
         : base(null, DicomNetSecurityeMode.Tls, reserved)
#else
      public Client(Server server, bool reserved)
         : base(null, DicomNetSecurityMode.Tls, reserved)
#endif // #if !LEADTOOLS_V20_OR_LATER
      {
         this.server = server;
         _Timer = new DicomTimer(this, 30);
      }

      protected override string OnPrivateKeyPassword(bool encryption)
      {
         return "test";
      }

      protected override void OnClose(DicomExceptionCode error, DicomNet net)
      {
         base.OnClose(error, net);
      }

      protected override void OnReceiveAssociateRequest(DicomAssociate association)
      {
         server.mf.UpdateClient(this, association.Calling, "Associate");
         server.mf.Log("ASSOCIATE-REQUEST", "Received from " + association.Calling);

         if (!server.usersDB.FindUser(PeerAddress, association.Calling))
         {
            SendAssociateReject(DicomAssociateRejectResultType.Permanent,
                DicomAssociateRejectSourceType.User,
                DicomAssociateRejectReasonType.Calling);
            server.mf.Log("ASSOCIATE-REJECT", "Invalid calling AE Title: " + association.Calling);
         }
         else
         {
            server.DoAssociateRequest(this, association);
            server.mf.EnableTimer(this, association.Calling, true);
            server.mf.Log("ASSOCIATE-REQUEST", "Association accepted from " +
                          association.Calling + " (" + PeerAddress + ")");
         }
      }

      protected override void OnReceiveReleaseRequest( )
      {
          server.Clients.Remove(PeerAddress + "_" + PeerPort);
         server.mf.RemoveClient(this);
         SendReleaseResponse();
      }

      protected override void OnReceiveData(byte presentationID, DicomDataSet cs, DicomDataSet ds)
      {
         if (Logger.DisableLogging == false)
         {
            if (server.SaveCSReceived && cs != null)
            {
               server.LogCS(this, cs);
            }

            //if you don't need the CommandSet DataSet then dispose it here. Otherwise GC will take care if it.
            if (null != cs)
            {
               cs.Dispose();
            }
         }
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

      protected override void OnReceiveCEchoRequest(byte presentationID, int messageID, string affectedClass)
      {
         action = server.InitAction("C-ECHO-REQUEST", ProcessType.EchoRequest, this, null);

         action.PresentationID = presentationID;
         action.MessageID = messageID;
         action.Class = affectedClass;
         StartAction(action);
      }

      protected override void OnReceiveCStoreRequest(byte presentationID, int messageID, string affectedClass, string instance, DicomCommandPriorityType priority, string moveAE, int moveMessageID, DicomDataSet dataSet)
      {
         action = server.InitAction("C-STORE-REQUEST", ProcessType.StoreRequest, this, dataSet);

         action.PresentationID = presentationID;
         action.MessageID = messageID;
         action.Class = affectedClass;
         action.Instance = instance;
         action.Priority = priority;
         action.MoveAETitle = moveAE;
         action.MoveMessageID = moveMessageID;
         StartAction(action);
         dataSet.Dispose ( ) ;
      }

      protected override void OnReceiveCFindRequest(byte presentationID, int messageID, string affectedClass, DicomCommandPriorityType priority, DicomDataSet dataSet)
      {
         action = server.InitAction("C-FIND-REQUEST", ProcessType.FindRequest, this, dataSet);

         action.PresentationID = presentationID;
         action.MessageID = messageID;
         action.Class = affectedClass;
         action.Priority = priority;
         StartAction(action);
         dataSet.Dispose ( ) ;
      }

      protected override void OnReceiveCMoveRequest(byte presentationID, int messageID, string affectedClass, DicomCommandPriorityType priority, string moveAE, DicomDataSet dataSet)
      {
         action = server.InitAction("C-MOVE-REQUEST", ProcessType.MoveRequest, this, dataSet);

         action.PresentationID = presentationID;
         action.MessageID = messageID;
         action.Class = affectedClass;
         action.Priority = priority;
         action.MoveAETitle = moveAE;
         StartAction(action);
         dataSet.Dispose ( ) ;
      }

      protected override void OnReceiveCCancelRequest(byte presentationID, int messageID)
      {
         if(procThread != null && procThread.IsAlive)
         {
            procThread.Abort();
            procThread = null;
         }
      }

      public void Terminate()
      {
          if (action != null)
              action.Close();
          if (procThread != null && procThread.IsAlive)
          {
              procThread.Abort();
              procThread = null;
          }         
      }
   }
}
