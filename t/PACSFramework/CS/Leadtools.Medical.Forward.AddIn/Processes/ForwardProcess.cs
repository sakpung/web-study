// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Medical.Forward.DataAccessLayer.DataTypes;
using Leadtools.Medical.Forward.DataAccessLayer;
using Leadtools.Dicom;
using Leadtools.Logging.Medical;
using Leadtools.Dicom.Scu;
using Leadtools.Logging;
using Leadtools.Dicom.Scu.Common;
using Leadtools.Medical.Winforms.Forwarder;
using Leadtools.Medical.Winforms.Forwarder.Controls;
using System.IO;
using Leadtools.Dicom.Common.Extensions;
using System.Threading;
using Leadtools.Medical.DataAccessLayer;
using Leadtools.Medical.AeManagement.DataAccessLayer.Configuration;
using Leadtools.Medical.AeManagement.DataAccessLayer;
using Leadtools.Dicom.AddIn.Interfaces;

namespace Leadtools.Medical.Forwarder.AddIn.Processes
{
   public class ForwardProcess
   {      
      private ForwardOptions _Options;
      private string _ServerAE;
      private bool _useTls = false;
      private static object forwardLock = new object();

      public const string CONNECT_REQUEST_SENT = "[Forwarder] Attempt to connect to server.";
      public const string CONNECT_RESPONSE_RECEIVED = "[Forwarder] Sucessfully connected to server.";
      public const string CONNECT_RESPONSE_RECEIVED_FAILURE = "[Forwarder] Failure to connect to server.^{0}";
      public const string SECURE_LINK_READY_CIPHERSUITE = "[Forwarder] Secure link ready.^\tSecure Link Established^\tCipher Suite Sucessfully Negotiated: {0}";
      public const string SECURE_LINK_FAILED = "[Forwarder] Secure link failed.^{0}";
      public const string ASSOCIATE_REQUEST_SENT = "[Forwarder] Associate request sent.^{0}";
      public const string ASSOCIATE_REQUEST_REJECTED = "[Forwarder] Association request rejected.^{0}";
      public const string ASSOCIATE_REQUEST_ACCEPTED = "[Forwarder] Association request accepted.";
      public const string RELEASE_REQUEST_SENT = "[Forwarder] Release request sent.";
      public const string RELEASE_RESPONSE_RECEIVED = "[Forwarder] Release response received.";
      public const string CSTORE_REQUEST_SEND = "[Forwarder] Sending CStore request.^\tMessage ID: {0}.^\tPresentation ID: {1}.^\tAbstract Syntax: {2}.^\tAffected SOP instance UID: {3}";
      public const string CSTORE_RESPONSE_RECEIVED = "[Forwarder] CStore response received.^\tMessage ID: {0}.^\tPresentation ID: {1}.^\tAbstract Syntax: {2}.^\tAffected SOP instance UID: {3}^\tStatus: {4}";
      public const string CFIND_REQUEST_SEND = "[Forwarder] Sending CFind request.^\tMessage ID: {0}.^\tPresentation ID: {1}.^\tAbstract Syntax: {2}.^\tPriority: {3}";
      public const string CFIND_RESPONSE_RECEIVED = "[Forwarder] CFind response received.^\tMessage ID: {0}.^\tPresentation ID: {1}.^\tAbstract Syntax: {2}.^\tStatus: {3}";

      private static bool _cancelForward = false;
      private static bool _serviceShuttingDown = false;


      public ForwardProcess(ForwardOptions options, string ae)
      {         
         _Options = options;
         _ServerAE = ae;

         Module.InitializeDicomSecurity(false);
      }

      public void Run(DicomScp scp, IForwardDataAccessAgent forwardAgent)
      {
         if (_serviceShuttingDown)
         {
            return;
         }

         AeInfoExtended aeInfoExtended = Module._aeManagementAgent.GetAeTitle(scp.AETitle);
         if (aeInfoExtended != null)
         {
            _useTls = aeInfoExtended.ClientPortUsage == ClientPortUsageType.Secure || ((aeInfoExtended.ClientPortUsage == ClientPortUsageType.SameAsServer) && (Module._Server.Secure));
         }

         Thread thread = new Thread(() => RunThread(scp, forwardAgent));
         thread.Start();
      }

      public void RunThread(DicomScp scp, IForwardDataAccessAgent forwardAgent)
      {
         // int threadId = Thread.CurrentThread.ManagedThreadId;
         try
         {
            // Logger.Global.SystemMessage(LogType.Information, string.Format("[Forwarder] [{0:X8}] +++ InternalRunThread starting", threadId), _ServerAE);
            InternalRunThread(scp, forwardAgent);
         }
         finally
         {
            // Logger.Global.SystemMessage(LogType.Information, string.Format("[Forwarder]  [{0:X8}] --- InternalRunThread ending", threadId), _ServerAE);
         }
      }

      public void InternalRunThread(DicomScp scp, IForwardDataAccessAgent forwardAgent)
      {
         lock (forwardLock)
         {
            if (_serviceShuttingDown)
            {
               return;
            }

            ForwardInstance[] instances;
            try
            {
               instances = forwardAgent.GetForwardList();
            }
            catch (Exception ex)
            {
               Logger.Global.SystemMessage(LogType.Error, ex.ToString(), _ServerAE);
               // throw;
               instances = new ForwardInstance[0];
            }

            string message = string.Format("[Forwarder] {0} {1} found to forward", instances.Length, instances.Length == 1 ? "dataset" : "datasets");

            Logger.Global.SystemMessage(LogType.Debug, message, _ServerAE);
            if (instances.Length > 0 && _Options.Verify)
            {
               message = string.Format("[Forwarder] {0} {1} will be verified after forwarding", instances.Length, instances.Length == 1 ? "instance" : "instances");
               Logger.Global.SystemMessage(LogType.Warning, message, _ServerAE);
            }
            foreach (ForwardInstance instance in instances)
            {
#if LEADTOOLS_V18_OR_LATER
               if (_cancelForward)
               {
                  _cancelForward = false;
                  Logger.Global.SystemMessage(LogType.Information, string.Format("Cancelling Forward Process"), _ServerAE);
                  break;
               }

               if (_serviceShuttingDown)
               {
                  break;
               }
#endif // #if LEADTOOLS_V18_OR_LATER

               try
               {
                  if (!File.Exists(instance.ReferencedFile))
                  {
                     message = string.Format("[Forwarder] Referenced file doesn't exist.  Instance ({0}) will be removed from forwarding queue. [{1}]", instance.SOPInstanceUID, instance.ReferencedFile);
                     Logger.Global.SystemMessage(LogType.Warning, message, _ServerAE);
                     forwardAgent.SetInstanceForwarded(instance.SOPInstanceUID, DateTime.Now, null);
                     continue;
                  }

                  // SendInstance can fail because DicomEngine may be locked
                  DicomCommandStatusType status = DicomCommandStatusType.Success;
                  try
                  {
                     status = SendInstance(scp, instance);
                  }
                  catch (Exception)
                  {
                     // Console.WriteLine(ex.Message);
                     throw;
                  }

                  if ( status == DicomCommandStatusType.Success || status == DicomCommandStatusType.DuplicateInstance)
                  {
                     DateTime? expires = null;
                     DateTime forwardDate = DateTime.Now;

                     if (_Options.ImageHold != null && _Options.ImageHold != 0)
                     {
                        switch (_Options.HoldInterval)
                        {
                           case HoldInterval.Days:
                              expires = forwardDate.AddDays(_Options.ImageHold.Value);
                              break;
                           case HoldInterval.Months:
                              expires = forwardDate.AddMonths(_Options.ImageHold.Value);
                              break;
                           default:
                              expires = forwardDate.AddYears(_Options.ImageHold.Value);
                              break;
                        }
                     }
                     if (!_Options.Verify || VerifyInstance(scp, instance.SOPInstanceUID) == DicomCommandStatusType.Success)
                     {
                        if (_Options.Verify)
                        {
                           message = string.Format("[Forwarder] SOP instance successfully verified: {0}", instance.SOPInstanceUID);
                           Logger.Global.SystemMessage(LogType.Debug, message, _ServerAE);
                        }
                        forwardAgent.SetInstanceForwarded(instance.SOPInstanceUID, forwardDate, expires);
                     }
                     else
                     {
                        message = string.Format("[Forwarder] Failed to verify SOP instance: {0}. Instance not marked as forwarded.", instance.SOPInstanceUID);
                        Logger.Global.SystemMessage(LogType.Error, message, _ServerAE);
                     }
                  }
               }
               catch (Exception e)
               {
                  Logger.Global.SystemMessage(LogType.Error, "[Forwarder] " + e.Message, _ServerAE);
               }
            }
         }
      }

      private DicomCommandStatusType SendInstance(DicomScp scp, ForwardInstance instance)
      {
         StoreScu store = null;
         if (_useTls && Module.IsDicomSecurityAvailable())
         {
            store = new StoreScu(Module._Server.TemporaryDirectory, DicomNetSecurityMode.Tls, Module._openSslOptions) { AETitle = _Options.UseCustomAE ? _Options.CustomAE : _ServerAE };
            Module.SetCiphers(store);
         }
         else
         {
            store = new StoreScu() { AETitle = _Options.UseCustomAE ? _Options.CustomAE : _ServerAE };
         }

         store.Tag = DicomCommandStatusType.Failure;
         try
         {            
            store.BeforeConnect += new BeforeConnectDelegate(BeforeConnect);
            store.AfterConnect += new AfterConnectDelegate(AfterConnect);
            store.AfterSecureLinkReady += AfterSecureLinkReady;
            store.BeforeAssociateRequest += new BeforeAssociationRequestDelegate(BeforeAssociateRequest);
            store.AfterAssociateRequest += new AfterAssociateRequestDelegate(AfterAssociateRequest);
            store.BeforeCStore += new BeforeCStoreDelegate(store_BeforeCStore);
            store.AfterCStore += new AfterCStoreDelegate(store_AfterCStore);
            store.BeforeReleaseRequest += new EventHandler(BeforeReleaseRequest);
            store.AfterReleaseRequest += new EventHandler(AfterReleaseRequest);
            store.Store(scp, instance.ReferencedFile);
         }
         catch (ClientAssociationException ce)
         {
            string message = string.Format("[Forwarder] Failed to establish association with server: {0}.", ce.Reason);

            LogEvent(LogType.Error, MessageDirection.None, message, DicomCommandType.Undefined, null, store, null);
         }
         catch (DicomException de)
         {
            string message = string.Format("[Forwarder] Error: {0}.", de.Message);

            LogEvent(LogType.Error, MessageDirection.Input, message, DicomCommandType.Undefined, null, store, null);
         }
         catch (Exception e)
         {
            string message = "[Forwarder] " + e.Message;

            Logger.Global.Log(string.Empty, string.Empty, -1, string.Empty, string.Empty, -1, DicomCommandType.Undefined,
                              DateTime.Now, LogType.Error, MessageDirection.None, message, null, null);
         }
         finally
         {
            store.BeforeConnect -= new BeforeConnectDelegate(BeforeConnect);
            store.AfterConnect -= new AfterConnectDelegate(AfterConnect);
            store.AfterSecureLinkReady -= AfterSecureLinkReady;
            store.BeforeAssociateRequest -= new BeforeAssociationRequestDelegate(BeforeAssociateRequest);
            store.AfterAssociateRequest -= new AfterAssociateRequestDelegate(AfterAssociateRequest);
            store.BeforeCStore -= new BeforeCStoreDelegate(store_BeforeCStore);
            store.AfterCStore -= new AfterCStoreDelegate(store_AfterCStore);
            store.BeforeReleaseRequest -= new EventHandler(BeforeReleaseRequest);
            store.AfterReleaseRequest -= new EventHandler(AfterReleaseRequest);
            store.Dispose();
         }
         return (DicomCommandStatusType)store.Tag;
      }

      void BeforeConnect(object sender, BeforeConnectEventArgs e)
      {
         DicomConnection connection = sender as DicomConnection;

         LogEvent(LogType.Information, MessageDirection.Output, CONNECT_REQUEST_SENT, DicomCommandType.Undefined, null, connection, null);
      }

      void AfterConnect(object sender, AfterConnectEventArgs e)
      {
         DicomConnection connection = sender as DicomConnection;
         string message = CONNECT_RESPONSE_RECEIVED;

         if (e.Error != DicomExceptionCode.Success)
         {
            message = string.Format(CONNECT_RESPONSE_RECEIVED_FAILURE, e.Error);
         }

         LogEvent(LogType.Information, MessageDirection.Input, message, DicomCommandType.Undefined, null, connection, null);
      }

      private void AfterSecureLinkReady(object sender, AfterSecureLinkReadyEventArgs e)
      {
         DicomConnection connection = sender as DicomConnection;

         if (e.Error == DicomExceptionCode.Success)
         {
            DicomTlsCipherSuiteType cipher = connection.GetTlsCipherSuite();

            LogEvent(LogType.Information, MessageDirection.Input,
                             String.Format(SECURE_LINK_READY_CIPHERSUITE, cipher.GetCipherFriendlyName()),
                             DicomCommandType.Undefined, null, connection, null);
         }
         else
         {
            LogEvent(LogType.Information, MessageDirection.Input,
                             String.Format(SECURE_LINK_FAILED, e.Error),
                             DicomCommandType.Undefined, null, connection, null);
         }
      }

      void BeforeAssociateRequest(object sender, BeforeAssociateRequestEventArgs e)
      {
         DicomConnection connection = sender as DicomConnection;

         LogEvent(LogType.Information, MessageDirection.Output, string.Format(ASSOCIATE_REQUEST_SENT, e.Associate.ToString()),
                  DicomCommandType.Undefined, null, connection, null);
      }

      void AfterAssociateRequest(object sender, AfterAssociateRequestEventArgs e)
      {
         DicomConnection connection = sender as DicomConnection;

         if (!e.Rejected)
         {
            LogEvent(LogType.Information, MessageDirection.Input, ASSOCIATE_REQUEST_ACCEPTED,
                     DicomCommandType.Undefined, null, connection, null);
         }
         else
         {
            LogEvent(LogType.Information, MessageDirection.Input, string.Format(ASSOCIATE_REQUEST_REJECTED, e.Reason),
                     DicomCommandType.Undefined, null, connection, null);
         }
      }

      void store_BeforeCStore(object sender, BeforeCStoreEventArgs e)
      {
         StoreScu scu = sender as StoreScu;
         string message = string.Format(CSTORE_REQUEST_SEND, e.MessageId, e.PresentationID, e.AffectedClass, e.Instance);

         LogEvent(LogType.Information, MessageDirection.Output, message, DicomCommandType.CStore, e.Dataset, scu, null);
      }

      void store_AfterCStore(object sender, AfterCStoreEventArgs e)
      {
         StoreScu scu = sender as StoreScu;
         string message = string.Format(CSTORE_RESPONSE_RECEIVED, e.MessageId, e.PresentationID, e.AffectedClass, e.Instance, e.Status);

         scu.Tag = e.Status;
         LogEvent(LogType.Information, MessageDirection.Input, message, DicomCommandType.CStore, null, scu, null);
      }

      void BeforeReleaseRequest(object sender, EventArgs e)
      {
         DicomConnection connection = sender as DicomConnection;

         LogEvent(LogType.Information, MessageDirection.Output, RELEASE_REQUEST_SENT, DicomCommandType.Undefined, null, connection, null);
      }

      void AfterReleaseRequest(object sender, EventArgs e)
      {
         DicomConnection connection = sender as DicomConnection;

         LogEvent(LogType.Information, MessageDirection.Input, RELEASE_RESPONSE_RECEIVED, DicomCommandType.Undefined, null, connection, null);
      }

      private DicomCommandStatusType VerifyInstance(DicomScp scp, string sopInstanceUID)
      {
         ForwardFind find = new ForwardFind() { AETitle = _Options.UseCustomAE ? _Options.CustomAE : _ServerAE };

         find.Tag = DicomCommandStatusType.Failure;
         find.BeforeConnect += new BeforeConnectDelegate(BeforeConnect);
         find.AfterConnect += new AfterConnectDelegate(AfterConnect);
         find.BeforeAssociateRequest += new BeforeAssociationRequestDelegate(BeforeAssociateRequest);
         find.AfterAssociateRequest += new AfterAssociateRequestDelegate(AfterAssociateRequest);
         find.BeforeReleaseRequest += new EventHandler(BeforeReleaseRequest);
         find.AfterReleaseRequest += new EventHandler(AfterReleaseRequest);
         find.BeforeCFind += new BeforeCFindDelegate(find_BeforeCFind);         
         try
         {
            ImageQuery query = new ImageQuery() { SOPInstanceUID = sopInstanceUID };

            find.Find<ImageQuery, ImageQuery>(scp, query, (image, ds) =>
               {
                  //
                  // Instance found on the remote server
                  //
                  find.Tag = DicomCommandStatusType.Success;
               });
         }
         catch (ClientAssociationException ce)
         {
            string message = string.Format("[Forwarder] Failed to establish association with server: {0}.", ce.Reason);

            LogEvent(LogType.Error, MessageDirection.None, message, DicomCommandType.Undefined, null, find, null);
         }
         catch (DicomException de)
         {
            string message = string.Format("[Forwarder] Error: {0}.", de.Message);

            LogEvent(LogType.Error, MessageDirection.Input, message, DicomCommandType.Undefined, null, find, null);
         }
         catch (Exception e)
         {
            string message = "[Forwarder] " + e.Message;

            Logger.Global.Log(string.Empty, string.Empty, -1, string.Empty, string.Empty, -1, DicomCommandType.Undefined,
                              DateTime.Now, LogType.Error, MessageDirection.None, message, null, null);
         }
         finally
         {
            find.BeforeConnect -= new BeforeConnectDelegate(BeforeConnect);
            find.AfterConnect -= new AfterConnectDelegate(AfterConnect);
            find.BeforeAssociateRequest -= new BeforeAssociationRequestDelegate(BeforeAssociateRequest);
            find.AfterAssociateRequest -= new AfterAssociateRequestDelegate(AfterAssociateRequest);
            find.BeforeReleaseRequest -= new EventHandler(BeforeReleaseRequest);
            find.AfterReleaseRequest -= new EventHandler(AfterReleaseRequest);
            find.BeforeCFind -= new BeforeCFindDelegate(find_BeforeCFind);            
         }

         return (DicomCommandStatusType)find.Tag;
      }

      void find_BeforeCFind(object sender, BeforeCFindEventArgs e)
      {
         DicomConnection connection = sender as DicomConnection;
         string message = string.Format(CFIND_REQUEST_SEND, e.MessageId, e.PresentationID, e.AffectedClass, e.Priority);

         LogEvent(LogType.Information, MessageDirection.Output, message, DicomCommandType.CFind, e.Dataset, connection, null);
      }      
     
      public static void LogEvent(LogType type, MessageDirection messageDirection, string description,
                                  DicomCommandType command, DicomDataSet dataset,
                                  DicomConnection Client, SerializableDictionary<string, object> customInformation)
      {
         try
         {
            string ae = Client.AETitle;
            DicomNet net = Client as DicomNet;

            SerializableDictionary<string, object> logCustomInformation = DicomLogEntry.CustomInformationDicomMessage;
            if (customInformation != null)
            {
               logCustomInformation = new SerializableDictionary<string, object>();
               foreach (KeyValuePair<string, object> kvp in customInformation)
               {
                  logCustomInformation.Add(kvp.Key, kvp.Value);
               }
               logCustomInformation.Add(DicomLogEntry.DicomMessageKey, DicomLogEntry.DicomMessageValue);
            }

            Logger.Global.Log("Forwarder", Client.CurrentScp.AETitle, Client.CurrentScp.PeerAddress.ToString(),
                              Client.CurrentScp.Port, net.IsAssociated() ? net.Association.Calling : ae,
                              net.HostAddress != null ? net.HostAddress.ToString() : string.Empty,
                              net.IsConnected() ? net.HostPort : -1, command, DateTime.Now, type,
                              messageDirection, description, dataset, logCustomInformation);
         }
         catch (Exception exception)
         {
            Logger.Global.Exception("Forwarder", exception);
         }
      }
  
#if LEADTOOLS_V18_OR_LATER
      public void Cancel()
      {
         DicomUtilities.DebugString(DebugStringOptions.ShowCounter, "ForwardProcess.Cancel");

         // The idea here is to enable the cancel flag, and disable it after you acquire the restoreLock
         // You can only acquire the forwardLock after the forward process ends
         _cancelForward = true;
         lock (forwardLock)
         {
            _cancelForward = false;
         }
      }
#endif // #if LEADTOOLS_V18_OR_LATER

      public void ServiceShuttingDown()
      {
         _serviceShuttingDown = true;
      }
   }

   public class ForwardFind : QueryRetrieveScu
   {
      protected override void OnReceiveCFindResponse(byte presentationID, int messageID, string affectedClass, DicomCommandStatusType status, DicomDataSet dataSet)
      {
         string message = string.Format(ForwardProcess.CFIND_RESPONSE_RECEIVED, messageID, presentationID, affectedClass, status);

         ForwardProcess.LogEvent(LogType.Information, MessageDirection.Input, message, DicomCommandType.CFind, dataSet, this, null);
         base.OnReceiveCFindResponse(presentationID, messageID, affectedClass, status, dataSet);
      }
   }
}
