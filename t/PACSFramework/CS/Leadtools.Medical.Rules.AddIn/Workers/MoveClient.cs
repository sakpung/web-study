// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Dicom.Scu;
using Leadtools.Dicom.AddIn;
using Leadtools.Dicom;
using Leadtools.Medical.Rules.AddIn.Common;
using Leadtools.Logging;
using Leadtools.Logging.Medical;
using Leadtools.Dicom.Scu.Common;
using Leadtools.Medical.Winforms.Forwarder.Scheduling;
using System.Net;

namespace Leadtools.Medical.Rules.AddIn.Workers
{
   public class MoveClient : RetryBase
   {      
      private List<string> _AeTitles = new List<string>();
      private DicomScp _Scp;

      public const string CMOVE_REQUEST_SENT = "[Rules] CMove request sent.^\tMessage ID: {0}.^\tPresentation ID: {1}.^\tAffected SOP instance UID: {2}.^\tPriority: {3}.^\tMove AE: {4}";
      public const string CMOVE_RESPONSE_RECEIVED = "[Rules] CMove response received.^\tMessage ID: {0}.^\tPresentation ID: {1}.^\tAbstract Syntax: {2}.^\tStatus: {3}.^\tRemaining: {4}.^\tCompleted: {5}.^\tFailed: {6}.^\tWarning: {7}";

      public MoveClient(DicomScp scp, List<string> aetitles)
      {        
         _Scp = scp;
         _Scp.Relational = true;
         _AeTitles.AddRange(aetitles);
      }

      public void Move(MoveInfo info)
      {
         try
         {
            DicomServer dicomServer = ServiceLocator.Retrieve<DicomServer>();
            string lastStatus = string.Empty;

            _Scp.Timeout = dicomServer.ClientTimeout;
            foreach (string aetitle in _AeTitles)
            {
               if (!Move(_Scp, info, aetitle, dicomServer.TemporaryDirectory, ref lastStatus) && EnableRetry && NumberOfRetries > 0)
               {
                  MoveServer server = new MoveServer(_Scp);
                  Job<MoveServer> retryJob = new Job<MoveServer>() { Loops = 1, Data = server };

                  server.DestinationAE = aetitle;
                  server.Info = info;
                  server.RetryCount = NumberOfRetries;
                  server.LastStatus = lastStatus;
                  server.IPAddress = _Scp.PeerAddress.ToString();
                  retryJob.StartTime = Timeout.Milliseconds().FromNow();
                  Module.Scheduler.SubmitJob<MoveServer>(retryJob, Retry);
               }
            }
         }
         catch (Exception e)
         {
            Logger.Global.SystemException(string.Empty, e);
         }
      }

      public static bool Move(DicomScp scp, MoveInfo info, string aetitle, string temporaryDirectory, ref string lastStatus)
      {
         bool success = false;         
         RuleQueryRetrieve scu;

         scu = new RuleQueryRetrieve(temporaryDirectory);
         scu.BeforeConnect += new BeforeConnectDelegate(scu_BeforeConnect);
         scu.AfterConnect += new AfterConnectDelegate(scu_AfterConnect);
         scu.BeforeAssociateRequest += new BeforeAssociationRequestDelegate(scu_BeforeAssociateRequest);
         scu.AfterAssociateRequest += new AfterAssociateRequestDelegate(scu_AfterAssociateRequest);
         scu.BeforeCMove += new BeforeCMoveDelegate(scu_BeforeCMove);
         scu.AfterCMove += new AfterCMoveDelegate(scu_AfterCMove);
         scu.BeforeReleaseRequest += new EventHandler(scu_BeforeReleaseRequest);
         scu.AfterReleaseRequest += new EventHandler(scu_AfterReleaseRequest);
         scu.AETitle = Module._Options.AETitle;         

         try
         {            
            switch (info.MoveType)
            {
               case MoveType.Patient:
                  scu.MovePatient(scp, aetitle, info.Id);
                  break;
               case MoveType.Study:
                  scu.Move(scp, aetitle, info.Id);
                  break;
               case MoveType.Series:
                  scu.Move(scp, aetitle, string.Empty, info.Id);
                  break;
               case MoveType.Instance:
                  scu.Move(scp, aetitle, string.Empty, string.Empty, info.Id);
                  break;
            }

            if (scu.Rejected)
            {
               lastStatus = scu.RejectReason;
            }
            else
            {
               if (scu.Status != DicomCommandStatusType.Success)
                  lastStatus = scu.Status.ToString();
               else
                  success = true;
            }
         }
         catch (Exception e)
         {
            if (e is ClientAssociationException)
            {
               ClientAssociationException ce = e as ClientAssociationException;
               string message = string.Format("[Rules] Failed to establish association with server: {0}.", ce.Reason);

               Utils.LogEvent(LogType.Error, MessageDirection.None, message, DicomCommandType.Undefined, null, scu, null);
               lastStatus = message;
            }
            if (e is DicomException)
            {
               DicomException de = e as DicomException;
               string message = string.Format("[Rules] Error: {0}.", de.Message);

               Utils.LogEvent(LogType.Error, MessageDirection.Input, message, DicomCommandType.Undefined, null, scu, null);
               lastStatus = de.Message;
            }
            else
            {
               string message = "[Rules] " + e.Message;

               Logger.Global.Log(string.Empty, string.Empty, -1, string.Empty, string.Empty, -1, DicomCommandType.Undefined,
                                 DateTime.Now, LogType.Error, MessageDirection.None, message, null, null);
               lastStatus = e.Message;
            }
         }
         finally
         {
            scu.BeforeConnect -= scu_BeforeConnect;
            scu.AfterConnect -= scu_AfterConnect;
            scu.BeforeAssociateRequest -= scu_BeforeAssociateRequest;
            scu.AfterAssociateRequest -= scu_AfterAssociateRequest;
            scu.BeforeCMove -= new BeforeCMoveDelegate(scu_BeforeCMove);
            scu.AfterCMove -= new AfterCMoveDelegate(scu_AfterCMove);
            scu.BeforeReleaseRequest -= scu_BeforeReleaseRequest;
            scu.AfterReleaseRequest -= scu_AfterReleaseRequest;
         }

         return success;
      }

      private void Retry(Job<MoveServer> job, MoveServer server)
      {
         string lastStatus = string.Empty;
         DicomServer dicomServer = ServiceLocator.Retrieve<DicomServer>();
         bool success;

         server.Scp.AETitle = dicomServer.AETitle;
         server.Scp.PeerAddress = IPAddress.Parse(dicomServer.HostAddress);
         server.Scp.Timeout = dicomServer.ClientTimeout;
         success = Move(server.Scp, server.Info, server.DestinationAE, dicomServer.TemporaryDirectory, ref lastStatus);
         server.RetryCount--;
         //
         // If the store operation failed and we do not have not exhausted our retry count we
         // will try to send this dataset again later
         //
         if (!success && server.RetryCount > 0)
         {
            Job<MoveServer> retryJob = new Job<MoveServer>() { Loops = 1, Data = server };
            string retryMessage = server.RetryCount > 0 ? string.Format("are {0} retries", server.RetryCount) : "is only 1 retry";
            string message = string.Format("[Rules] Failed to successfully move dataset to {0}. There {0} left.", server.Scp.AETitle, retryMessage);

            Logger.Global.SystemMessage(LogType.Error, message, string.Empty);
            retryJob.StartTime = Timeout.Milliseconds().FromNow();
            Module.Scheduler.SubmitJob<MoveServer>(retryJob, Retry);
         }
         else
         {
            //
            // If the dataset is not successfully store we need to save the info so that it can be manually sent to
            // its destination.
            //
            if (!success)
            {
               try
               {
                  string message = string.Format("[Rules] Failed to successfully move dataset to {0} after {1} retries. Dataset will be added to manual resend queue", server.Scp.AETitle, NumberOfRetries);

                  Logger.Global.SystemMessage(LogType.Error, message, string.Empty);
                  server.Save();
               }
               catch (Exception e)
               {
                  Logger.Global.SystemException(string.Empty, e);
               }
            }            
         }
      }

      static void scu_BeforeConnect(object sender, BeforeConnectEventArgs e)
      {
         DicomConnection scu = sender as DicomConnection;

         Utils.LogEvent(LogType.Information, MessageDirection.Output, Utils.CONNECT_REQUEST_SENT, DicomCommandType.Undefined, null, scu, null);
      }

      static void scu_AfterConnect(object sender, AfterConnectEventArgs e)
      {
         DicomConnection scu = sender as DicomConnection;
         string message = Utils.CONNECT_RESPONSE_RECEIVED;

         if (e.Error != DicomExceptionCode.Success)
         {
            message = string.Format(Utils.CONNECT_RESPONSE_RECEIVED_FAILURE, e.Error);
         }

         Utils.LogEvent(LogType.Information, MessageDirection.Input, message, DicomCommandType.Undefined, null, scu, null);
      }

      static void scu_BeforeAssociateRequest(object sender, BeforeAssociateRequestEventArgs e)
      {
         DicomConnection scu = sender as DicomConnection;

         Utils.LogEvent(LogType.Information, MessageDirection.Output, string.Format(Utils.ASSOCIATE_REQUEST_SENT, e.Associate.ToString()),
                  DicomCommandType.Undefined, null, scu, null);
      }

      static void scu_AfterAssociateRequest(object sender, AfterAssociateRequestEventArgs e)
      {
         DicomConnection scu = sender as DicomConnection;

         if (!e.Rejected)
         {
            Utils.LogEvent(LogType.Information, MessageDirection.Input, Utils.ASSOCIATE_REQUEST_ACCEPTED,
                     DicomCommandType.Undefined, null, scu, null);
         }
         else
         {
            Utils.LogEvent(LogType.Information, MessageDirection.Input, string.Format(Utils.ASSOCIATE_REQUEST_REJECTED, e.Reason),
                     DicomCommandType.Undefined, null, scu, null);
         }
      }

      static void scu_BeforeCMove(object sender, BeforeCMoveEventArgs e)
      {
         DicomConnection scu = sender as DicomConnection;
         string msg = string.Format(CMOVE_REQUEST_SENT,e.MessageId, e.PresentationID, e.AffectedClass, e.Priority, e.DestinationAETitle);

         Utils.LogEvent(LogType.Information, MessageDirection.Output, msg, DicomCommandType.CMove, e.Dataset, scu, null);
      }

      static void scu_AfterCMove(object sender, AfterCMoveEventArgs e)
      {
         DicomConnection scu = sender as DicomConnection;
         string msg = string.Format(CMOVE_RESPONSE_RECEIVED, e.MessageId, e.PresentationID, e.AffectedClass, e.Status, e.Remaining, e.Completed, e.Failed, e.Warning);

         Utils.LogEvent(LogType.Information, MessageDirection.Input, msg, DicomCommandType.CMove, e.Dataset, scu, null);
      }

      static void scu_BeforeReleaseRequest(object sender, EventArgs e)
      {
         DicomConnection scu = sender as DicomConnection;

         Utils.LogEvent(LogType.Information, MessageDirection.Output, Utils.RELEASE_REQUEST_SENT, DicomCommandType.Undefined, null, scu, null);
      }

      static void scu_AfterReleaseRequest(object sender, EventArgs e)
      {
         DicomConnection scu = sender as DicomConnection;

         Utils.LogEvent(LogType.Information, MessageDirection.Input, Utils.RELEASE_RESPONSE_RECEIVED, DicomCommandType.Undefined, null, scu, null);
      } 
   }

   public class RuleQueryRetrieve : QueryRetrieveScu
   {
      private bool _Accepted = false;

#if !LEADTOOLS_V20_OR_LATER
      public RuleQueryRetrieve(string temporaryDirectory)
         : base(temporaryDirectory, DicomNetSecurityeMode.None, null)
      {
      }
#else
      public RuleQueryRetrieve(string temporaryDirectory)
         : base(temporaryDirectory, DicomNetSecurityMode.None, null)
      {
      }
#endif // #if !LEADTOOLS_V20_OR_LATER

      protected override DicomAssociate BuildAssociation(DicomScp scp)
      {
         DicomAssociate associate = base.BuildAssociation(scp);
         byte pid = associate.FindAbstract(DicomUidType.PatientRootQueryMove);

         if (pid != 0)
            associate.SetExtendedData(pid, new byte[] { 1 });
         return associate;
      }

      protected override List<Leadtools.Dicom.Scu.Common.PresentationContext> GetPresentationContexts()
      {
         List<Leadtools.Dicom.Scu.Common.PresentationContext> contexts = base.GetPresentationContexts();
         Leadtools.Dicom.Scu.Common.PresentationContext context = new Leadtools.Dicom.Scu.Common.PresentationContext(DicomUidType.PatientRootQueryMove);

         context.TransferSyntaxes.Add(DicomUidType.ImplicitVRLittleEndian);
         contexts.Add(context);
         return contexts;
      }

      protected override void OnReceiveAssociateAccept(DicomAssociate association)
      {
         base.OnReceiveAssociateAccept(association);
         _Accepted = true;
      }

      public void MovePatient(DicomScp scp,string aetitle, string patientID)
      {
         DicomServer server = ServiceLocator.Retrieve<DicomServer>();

         using (DicomDataSet ds = new DicomDataSet(server.TemporaryDirectory))
         {
            try
            {
               Connect(scp);
               if (_Accepted)
               {
                  ds.Initialize(DicomClassType.Undefined, DicomDataSetInitializeFlags.ExplicitVR | DicomDataSetInitializeFlags.LittleEndian);
                  ds.InsertElementAndSetValue(DicomTag.QueryRetrieveLevel, "PATIENT");
                  ds.InsertElementAndSetValue(DicomTag.PatientID, patientID);

                  SendPatientMove(ds, aetitle);
               }
            }
            finally
            {
               if (IsConnected())
               {
                  OnBeforeClose();
                  Close();
                  OnAfterClose();
               }
            }
         }
      }

      private void SendPatientMove(DicomDataSet wrapper, string DestAE)
      {
         bool moveFinish = false;
         try
         {
            BeforeCMoveEventArgs e = new BeforeCMoveEventArgs(ActiveScp, wrapper, DicomCommandPriorityType.Medium, string.IsNullOrEmpty(DestAE) ? Association.Calling : DestAE);
            byte pid = 0;
            DicomCommandPriorityType priority;

            pid = Association.FindAbstract(DicomUidType.PatientRootQueryMove);
            e.MessageId = 1;
            e.PresentationID = pid;
            e.AffectedClass = DicomUidType.StudyRootQueryMove;
            priority = OnBeforeCMove(e);            
            CurrentPid = pid;
            CurrentMessageId = e.MessageId;
            LogSendCMoveRequest(pid, e.MessageId, DicomUidType.PatientRootQueryMove, priority,
                             string.IsNullOrEmpty(DestAE) ? Association.Calling : DestAE, wrapper);
            SendCMoveRequest(pid, e.MessageId, DicomUidType.PatientRootQueryMove, priority,
                             string.IsNullOrEmpty(DestAE) ? Association.Calling : DestAE, wrapper);


            Wait();
            moveFinish = true;            
         }
         catch (Exception e)
         {            
            if (IsConnected())
            {
               OnBeforeClose();
               Close();
               OnAfterClose();
            }
            throw e;
         }         

         if (moveFinish)
         {
            AfterCMoveEventArgs e = new AfterCMoveEventArgs(ActiveScp, parameters.Completed, parameters.Failed, parameters.Warning, parameters.Dataset, parameters.Status);

            e.PresentationID = parameters.PresentationID;
            e.MessageId = parameters.MessageID;
            e.AffectedClass = parameters.AffectedClass;
            e.Remaining = parameters.Remaining;

            Release();
            OnAfterCMove(e); ;
         }

         if (IsConnected())
         {
            OnBeforeClose();
            Close();
            OnAfterClose();
         }        
      }
   }
}
