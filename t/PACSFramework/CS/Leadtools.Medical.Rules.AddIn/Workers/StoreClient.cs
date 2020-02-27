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
using Leadtools.Logging;
using Leadtools.Dicom;
using Leadtools.Logging.Medical;
using Leadtools.Dicom.Scu.Common;
using Leadtools.Medical.Rules.AddIn.Common;
using Leadtools.Medical.Winforms.Forwarder.Scheduling;
using Leadtools.Medical.Winforms.Forwarder.Controls;
using System.Net;

namespace Leadtools.Medical.Rules.AddIn.Workers
{
   public class StoreClient : RetryBase
   {
      private StoreScu _Scu;
      private List<DicomScp> _Scps = new List<DicomScp>();

      public const string CSTORE_REQUEST_SEND = "[Rules] Sending CStore request.^\tMessage ID: {0}.^\tPresentation ID: {1}.^\tAbstract Syntax: {2}.^\tAffected SOP instance UID: {3}";
      public const string CSTORE_RESPONSE_RECEIVED = "[Rules] CStore response received.^\tMessage ID: {0}.^\tPresentation ID: {1}.^\tAbstract Syntax: {2}.^\tAffected SOP instance UID: {3}^\tStatus: {4}";

      private DicomDS _DataSet;

      public DicomDS DataSet
      {
         get { return _DataSet; }         
      }

      public StoreClient(List<DicomScp> scps, DicomDataSet ds)
      {
         DicomServer server = ServiceLocator.Retrieve<DicomServer>();

         _Scu = new StoreScu(server.TemporaryDirectory);
         _DataSet = ds;
          _Scps.AddRange(scps);
      }

      public void Store()
      {   
         StoreFailure storeFailures = new StoreFailure();
         DicomServer dcmServer = ServiceLocator.Retrieve<DicomServer>();

         try
         {            
            foreach (DicomScp scp in _Scps)
            {
               string lastStatus = string.Empty;
               string clientAE = Module._Options.AETitle.Length > 0 ? Module._Options.AETitle : dcmServer.AETitle;

               //
               // If the store operation failed and we have enabled retry we need to schedule this action to be retried again
               //
               if (!Store(clientAE, scp, _DataSet, ref lastStatus))
               {
                  ResendServer server = new ResendServer(scp);

                  server.AETitle = clientAE;
                  server.RetryCount = NumberOfRetries;
                  server.LastStatus = lastStatus;
                  server.IPAddress = scp.PeerAddress.ToString();
                  storeFailures.Scps.Add(server);
               }                              
            }
         }
         catch (Exception ex)
         {
            Logger.Global.SystemException(string.Empty,ex);
         }

         if (storeFailures.Scps.Count > 0 )
         {            
            storeFailures.Dataset = _DataSet;            
            if (EnableRetry && NumberOfRetries > 0)
            {
                Job<StoreFailure> retryJob = new Job<StoreFailure>() { Loops = 1, Data = storeFailures };

                retryJob.StartTime = Timeout.Milliseconds().FromNow();
                Module.Scheduler.SubmitJob<StoreFailure>(retryJob, Retry);
            }
            else
            {
                //
                // Since we have no retries we will send this to manual resend
                //
                storeFailures.Save();
            }
         }
      }

      public static bool Store(string serverAE, DicomScp scp, DicomDataSet ds, ref string lastStatus)
      {
         StoreScu store = new StoreScu();
         DicomServer server = ServiceLocator.Retrieve<DicomServer>();
         
         bool success = false;

         store.AETitle = serverAE;
         store.BeforeConnect += new BeforeConnectDelegate(store_BeforeConnect);
         store.AfterConnect += new AfterConnectDelegate(store_AfterConnect);
         store.BeforeAssociateRequest += new BeforeAssociationRequestDelegate(store_BeforeAssociateRequest);
         store.AfterAssociateRequest += new AfterAssociateRequestDelegate(store_AfterAssociateRequest);
         store.BeforeCStore += new BeforeCStoreDelegate(store_BeforeCStore);
         store.AfterCStore += new AfterCStoreDelegate(store_AfterCStore);
         store.BeforeReleaseRequest += new EventHandler(store_BeforeReleaseRequest);
         store.AfterReleaseRequest += new EventHandler(store_AfterReleaseRequest);

         try
         {
            scp.Timeout = server.ClientTimeout;
            store.Store(scp, ds);
            if (store.Rejected)
            {
               lastStatus = store.RejectReason;
            }
            else
            {
               if (store.Status != DicomCommandStatusType.Success)
                  lastStatus = store.Status.ToString();
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

               Utils.LogEvent(LogType.Error, MessageDirection.None, message, DicomCommandType.Undefined, null, store, null);
               lastStatus = message;
            }
            if (e is DicomException)
            {
               DicomException de = e as DicomException;
               string message = string.Format("[Rules] Error: {0}.", de.Message);

               Utils.LogEvent(LogType.Error, MessageDirection.Input, message, DicomCommandType.Undefined, null, store, null);
               lastStatus = de.Code.ToString();
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
            store.BeforeConnect -= new BeforeConnectDelegate(store_BeforeConnect);
            store.AfterConnect -= new AfterConnectDelegate(store_AfterConnect);
            store.BeforeAssociateRequest -= new BeforeAssociationRequestDelegate(store_BeforeAssociateRequest);
            store.AfterAssociateRequest -= new AfterAssociateRequestDelegate(store_AfterAssociateRequest);
            store.BeforeCStore -= new BeforeCStoreDelegate(store_BeforeCStore);
            store.AfterCStore -= new AfterCStoreDelegate(store_AfterCStore);
            store.BeforeReleaseRequest -= new EventHandler(store_BeforeReleaseRequest);
            store.AfterReleaseRequest -= new EventHandler(store_AfterReleaseRequest);
            ds = null;
         }
         return success;
      }

      private void Retry(Job<StoreFailure> job, StoreFailure storeFailure)
      {
         int count = storeFailure.Scps.Count;
         DicomServer dcmServer = ServiceLocator.Retrieve<DicomServer>();

         foreach (ResendServer server in storeFailure.Scps.ToList())
         {
            string lastStatus = string.Empty;
            bool success;
            string aetitle = !string.IsNullOrEmpty(server.AETitle) ? server.AETitle : dcmServer.AETitle;

            server.Scp.PeerAddress = IPAddress.Parse(server.IPAddress);
            success = Store(aetitle, server.Scp, storeFailure.Dataset, ref lastStatus);

            server.RetryCount--;
            //
            // If the store operation failed and we do not have not exhausted our retry count we
            // will try to send this dataset again later
            //
            if (!success && server.RetryCount > 0)
            {
               string retryMessage = server.RetryCount > 0 ? string.Format("are {0} retries", server.RetryCount) : "is only 1 retry";
               string message = string.Format("[Rules] Failed to successfully store dataset to {0}. There {1} left.", server.Scp.AETitle, retryMessage);

               Logger.Global.SystemMessage(LogType.Error, message, string.Empty);             
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
                     string message = string.Format("[Rules] Failed to successfully store dataset to {0} after {1} retries. Dataset will be added to manual resend queue", server.Scp.AETitle, NumberOfRetries);

                     Logger.Global.SystemMessage(LogType.Error, message, string.Empty);
                  }
                  catch (Exception e)
                  {
                     Logger.Global.SystemException(string.Empty, e);
                  }
               }
               else
               {
                  storeFailure.Scps.Remove(server);                   
               }
            }
         }

         //
         // Some items still failed so we need to resubmit
         //
         if (storeFailure.Scps.Count > 0)
         {
             int itemsToRetry = (from scp in storeFailure.Scps
                          where scp.RetryCount > 0
                          select scp).Count();


             if (itemsToRetry > 0)
             {
                 Job<StoreFailure> retryJob = new Job<StoreFailure>() {Loops = 1, Data = storeFailure};

                 retryJob.StartTime = Timeout.Milliseconds().FromNow();
                 Module.Scheduler.SubmitJob<StoreFailure>(retryJob, Retry);
             }
             else
             {
                 storeFailure.Save();
             }                           
         }
      }

      static void store_BeforeConnect(object sender, BeforeConnectEventArgs e)
      {
         StoreScu scu = sender as StoreScu;

         Utils.LogEvent(LogType.Information, MessageDirection.Output, Utils.CONNECT_REQUEST_SENT, DicomCommandType.Undefined, null, scu, null);
      }

      static void store_AfterConnect(object sender, AfterConnectEventArgs e)
      {
         StoreScu scu = sender as StoreScu;
         string message = Utils.CONNECT_RESPONSE_RECEIVED;

         if (e.Error != DicomExceptionCode.Success)
         {
            message = string.Format(Utils.CONNECT_RESPONSE_RECEIVED_FAILURE, e.Error);
         }

         Utils.LogEvent(LogType.Information, MessageDirection.Input, message, DicomCommandType.Undefined, null, scu, null);
      }

      static void store_BeforeAssociateRequest(object sender, BeforeAssociateRequestEventArgs e)
      {
         StoreScu scu = sender as StoreScu;

         Utils.LogEvent(LogType.Information, MessageDirection.Output, string.Format(Utils.ASSOCIATE_REQUEST_SENT, e.Associate.ToString()),
                  DicomCommandType.Undefined, null, scu, null);
      }

      static void store_AfterAssociateRequest(object sender, AfterAssociateRequestEventArgs e)
      {
         StoreScu scu = sender as StoreScu;

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

      static void store_BeforeCStore(object sender, BeforeCStoreEventArgs e)
      {
         StoreScu scu = sender as StoreScu;
         string message = string.Format(CSTORE_REQUEST_SEND, e.MessageId, e.PresentationID, e.AffectedClass, e.Instance);

         Utils.LogEvent(LogType.Information, MessageDirection.Output, message, DicomCommandType.CStore, null, scu, null);
      }

      static void store_AfterCStore(object sender, AfterCStoreEventArgs e)
      {
         StoreScu scu = sender as StoreScu;
         string message = string.Format(CSTORE_RESPONSE_RECEIVED, e.MessageId, e.PresentationID, e.AffectedClass, e.Instance, e.Status);

         Utils.LogEvent(LogType.Information, MessageDirection.Input, message, DicomCommandType.CStore, null, scu, null);
      }

      static void store_BeforeReleaseRequest(object sender, EventArgs e)
      {
         StoreScu scu = sender as StoreScu;

         Utils.LogEvent(LogType.Information, MessageDirection.Output, Utils.RELEASE_REQUEST_SENT, DicomCommandType.Undefined, null, scu, null);
      }

      static void store_AfterReleaseRequest(object sender, EventArgs e)
      {
         StoreScu scu = sender as StoreScu;

         Utils.LogEvent(LogType.Information, MessageDirection.Input, Utils.RELEASE_RESPONSE_RECEIVED, DicomCommandType.Undefined, null, scu, null);
      }      
   }
}
