// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Leadtools.Medical.AeManagement.DataAccessLayer;
using Leadtools.Medical.AeManagement.DataAccessLayer.Configuration;
using Leadtools.Medical.DataAccessLayer;
using System.Diagnostics;
using Leadtools.Dicom.Common.DataTypes.PatientUpdater;
using Leadtools.Dicom.AddIn.Common;
using Leadtools.Dicom.Scu;
using System.Net;
using Leadtools.Logging;
using Leadtools.Logging.Medical;
using Leadtools.Dicom.Scu.Common;
using Leadtools.Dicom;
using Leadtools.DicomDemos;
using Leadtools.Medical.Storage.DataAccessLayer;
using Leadtools.Medical.Storage.DataAccessLayer.Configuration;
using Leadtools.Medical.Storage.DataAccessLayer.MatchingParameters;
using Leadtools.Medical.DataAccessLayer.Catalog;
using System.Data;
using Leadtools.Dicom.Common.Extensions;
using Leadtools.Dicom.AddIn.Interfaces;
using Leadtools.Dicom.AddIn;

namespace Leadtools.Medical.AutoCopy.AddIn.Queue
{
   public class AutoCopyQueue : IDisposable
   {
      private object locker = new object();
      private Thread[] workers;
      private IAeManagementDataAccessAgent _aeManagementAgent;
      private IStorageDataAccessAgent _StorageAgent;

      private AeManagementDataAccessConfigurationView _ConfigView;
      private Queue<AutoCopyItem> _TaskQueue = new Queue<AutoCopyItem>();

      public const string CONNECT_REQUEST_SENT = "[Auto Copy] Attempt to connect to server.";
      public const string CONNECT_RESPONSE_RECEIVED = "[Auto Copy] Sucessfully connected to server.";
      public const string CONNECT_RESPONSE_RECEIVED_FAILURE = "[Auto Copy] Failure to connect to server.^{0}";
      public const string SECURE_LINK_READY_CIPHERSUITE = "[Auto Copy] Secure link ready.^\tSecure Link Established^\tCipher Suite Sucessfully Negotiated: {0}";
      public const string SECURE_LINK_FAILED = "[Auto Copy] Secure link failed.^{0}";
      public const string ASSOCIATE_REQUEST_SENT = "[Auto Copy] Associate request sent.^{0}";
      public const string ASSOCIATE_REQUEST_REJECTED = "[Auto Copy] Association request rejected.^{0}";
      public const string ASSOCIATE_REQUEST_ACCEPTED = "[Auto Copy] Association request accepted.";
      public const string RELEASE_REQUEST_SENT = "[Auto Copy] Release request sent.";
      public const string RELEASE_RESPONSE_RECEIVED = "[Auto Copy] Release response received.";
      public const string CSTORE_REQUEST_SEND = "[Auto Copy] Sending CStore request.^\tMessage ID: {0}.^\tPresentation ID: {1}.^\tAbstract Syntax: {2}.^\tAffected SOP instance UID: {3}";
      public const string CSTORE_RESPONSE_RECEIVED = "[Auto Copy] CStore response received.^\tMessage ID: {0}.^\tPresentation ID: {1}.^\tAbstract Syntax: {2}.^\tAffected SOP instance UID: {3}^\tStatus: {4}";

      public AutoCopyQueue(int workerCount)
      {
         workers = new Thread[workerCount];

         //
         // Create and start a separate thread for each worker
         //
         for (int i = 0; i < workerCount; i++)
            (workers[i] = new Thread(Process)).Start();
      }

      public void InitializeDatabase()
      {
         System.Configuration.Configuration configuration = DicomDemoSettingsManager.GetGlobalPacsAddinsConfiguration(Module.ServiceDirectory);

         if (!DataAccessServices.IsDataAccessServiceRegistered<IAeManagementDataAccessAgent>())
         {
            _ConfigView = new AeManagementDataAccessConfigurationView(configuration, null, Module.ServiceName);
            _aeManagementAgent = DataAccessFactory.GetInstance(_ConfigView).CreateDataAccessAgent<IAeManagementDataAccessAgent>();
            DataAccessServices.RegisterDataAccessService<IAeManagementDataAccessAgent>(_aeManagementAgent);
         }
         else
         {
            _aeManagementAgent = DataAccessServices.GetDataAccessService<IAeManagementDataAccessAgent>();
         }

         if (!DataAccessServices.IsDataAccessServiceRegistered<IStorageDataAccessAgent>())
         {
            _StorageAgent = DataAccessFactory.GetInstance(new StorageDataAccessConfigurationView(configuration, null, Module.ServiceName)).CreateDataAccessAgent<IStorageDataAccessAgent>();
            DataAccessServices.RegisterDataAccessService<IStorageDataAccessAgent>(_StorageAgent);
         }
         else
         {
            _StorageAgent = DataAccessServices.GetDataAccessService<IStorageDataAccessAgent>();
         }
      }

      private void Process()
      {
         try
         {
            while (true)
            {
               AutoCopyItem item = null;

               lock (locker)
               {
                  while (_TaskQueue.Count == 0)
                     Monitor.Wait(locker);
                  item = _TaskQueue.Dequeue();
               }

               if (item == null)
                  break;
               SendCopy(item);
            }
         }
         catch (ThreadAbortException)
         {
         }
         catch (Exception e)
         {
            string message = "[Auto Copy] " + e.Message;

            Logger.Global.Log(string.Empty, string.Empty, -1, string.Empty, string.Empty, -1, DicomCommandType.Undefined,
                               DateTime.Now, LogType.Error, MessageDirection.None, message, null, null);
         }
      }

      private void AddEventHandlers(StoreScu store, string clientAe)
      {
         if (store != null)
         {
            store.AETitle = clientAe;
            store.BeforeConnect += new BeforeConnectDelegate(store_BeforeConnect);
            store.AfterConnect += new AfterConnectDelegate(store_AfterConnect);
            store.AfterSecureLinkReady += store_AfterSecureLinkReady;
            store.BeforeAssociateRequest += new BeforeAssociationRequestDelegate(store_BeforeAssociateRequest);
            store.AfterAssociateRequest += new AfterAssociateRequestDelegate(store_AfterAssociateRequest);
            store.BeforeCStore += new BeforeCStoreDelegate(store_BeforeCStore);
            store.AfterCStore += new AfterCStoreDelegate(store_AfterCStore);
            store.BeforeReleaseRequest += new EventHandler(store_BeforeReleaseRequest);
            store.AfterReleaseRequest += new EventHandler(store_AfterReleaseRequest);
         }
      }

      private void RemoveEventHandlers(StoreScu store)
      {
         if (store != null)
         {
            store.BeforeConnect -= new BeforeConnectDelegate(store_BeforeConnect);
            store.AfterConnect -= new AfterConnectDelegate(store_AfterConnect);
            store.AfterSecureLinkReady -= store_AfterSecureLinkReady;
            store.BeforeAssociateRequest -= new BeforeAssociationRequestDelegate(store_BeforeAssociateRequest);
            store.AfterAssociateRequest -= new AfterAssociateRequestDelegate(store_AfterAssociateRequest);
            store.BeforeCStore -= new BeforeCStoreDelegate(store_BeforeCStore);
            store.AfterCStore -= new AfterCStoreDelegate(store_AfterCStore);
            store.BeforeReleaseRequest -= new EventHandler(store_BeforeReleaseRequest);
            store.AfterReleaseRequest -= new EventHandler(store_AfterReleaseRequest);
         }
      }

      private void SendCopy(AutoCopyItem item)
      {
         AeInfoExtended[] aes = _aeManagementAgent.GetRelatedAeTitles(item.SourceAE, Module.AUTOCOPY_RELATION);
         StoreScu store = new StoreScu();

         Module.InitializeDicomSecurity(false);
         StoreScu storeSecure = null;

         DicomOpenSslVersion dicomOpenSslVersion = DicomNet.GetOpenSslVersion();
         if (dicomOpenSslVersion.IsAvailable)
         {
            storeSecure = new StoreScu(Module._Server.TemporaryDirectory, DicomNetSecurityMode.Tls, Module._openSslOptions);
            Module.SetCiphers(storeSecure);
         }

         DicomScp scp = null;
         string[] sopInstances = item.Datasets.ToArray();

         if (aes == null || aes.Length == 0)
            return;

         string clientAe = Module.Options.UseCustomAE ? Module.Options.AutoCopyAE : item.ClientAE;

         AddEventHandlers(store, clientAe);
         AddEventHandlers(storeSecure, clientAe);

         foreach (AeInfoExtended ae in aes)
         {
#if LEADTOOLS_V20_OR_LATER
            // Update dbo.AeInfo.LastAccessDate to Date.Now
            ae.LastAccessDate = DateTime.Now;
            _aeManagementAgent.Update(ae.AETitle, ae);
#endif

            bool useTls = ae.ClientPortUsage == ClientPortUsageType.Secure || ((ae.ClientPortUsage == ClientPortUsageType.SameAsServer) && (Module._Server.Secure));
            useTls = (useTls && dicomOpenSslVersion.IsAvailable);

            foreach (string sopInstance in sopInstances)
            {
               MatchingParameterCollection mpc = new MatchingParameterCollection();
               MatchingParameterList mpl = new MatchingParameterList();

               ICatalogEntity instanceEntity = RegisteredEntities.GetInstanceEntity(sopInstance);
               mpl.Add(instanceEntity);
               mpc.Add(mpl);

               DataSet instanceData = _StorageAgent.QueryCompositeInstances(mpc);
               // if (instanceData.Instance.Rows.Count == 1)
               if (instanceData.Tables[DataTableHelper.InstanceTableName].Rows.Count == 1)
               {
                  // string file = instanceData.Instance[0].ReferencedFile;
                  DataRow instanceRow = instanceData.Tables[DataTableHelper.InstanceTableName].Rows[0];
                  string file = RegisteredDataRows.InstanceInfo.ReferencedFile(instanceRow);

                  scp = new DicomScp(IPAddress.Parse(ae.Address), ae.AETitle, ae.Port);
                  try
                  {
                     if (useTls)
                     {
                        storeSecure.Store(scp, file);
                     }
                     else
                     {
                        store.Store(scp, file);
                     }
                  }
                  catch (ClientAssociationException ce)
                  {
                     string message = string.Format("[Auto Copy] Failed to establish association with server: {0}.", ce.Reason);

                     LogEvent(LogType.Error, MessageDirection.None, message, DicomCommandType.Undefined, null, store, null);
                  }
                  catch (DicomException de)
                  {
                     string message = string.Format("[Auto Copy] Error: {0}.", de.Message);

                     LogEvent(LogType.Error, MessageDirection.Input, message, DicomCommandType.Undefined, null, store, null);
                  }
                  catch (Exception e)
                  {
                     string message = "[Auto Copy] " + e.Message;

                     Logger.Global.Log(string.Empty, string.Empty, -1, string.Empty, string.Empty, -1, DicomCommandType.Undefined,
                                        DateTime.Now, LogType.Error, MessageDirection.None, message, null, null);
                  }
               }
            }
         }

         RemoveEventHandlers(store);
         RemoveEventHandlers(storeSecure);

         foreach (string sopInstance in sopInstances)
         {
            item.Datasets.Remove(sopInstance);
         }
      }

      void store_BeforeConnect(object sender, BeforeConnectEventArgs e)
      {
         StoreScu scu = sender as StoreScu;

         LogEvent(LogType.Information, MessageDirection.Output, CONNECT_REQUEST_SENT, DicomCommandType.Undefined, null, scu, null);
      }

      void store_AfterConnect(object sender, AfterConnectEventArgs e)
      {
         StoreScu scu = sender as StoreScu;
         string message = CONNECT_RESPONSE_RECEIVED;

         if (e.Error != DicomExceptionCode.Success)
         {
            message = string.Format(CONNECT_RESPONSE_RECEIVED_FAILURE, e.Error);
         }

         LogEvent(LogType.Information, MessageDirection.Input, message, DicomCommandType.Undefined, null, scu, null);
      }

      private void store_AfterSecureLinkReady(object sender, AfterSecureLinkReadyEventArgs e)
      {
         StoreScu connection = sender as StoreScu;

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

      void store_BeforeAssociateRequest(object sender, BeforeAssociateRequestEventArgs e)
      {
         StoreScu scu = sender as StoreScu;

         LogEvent(LogType.Information, MessageDirection.Output, string.Format(ASSOCIATE_REQUEST_SENT, e.Associate.ToString()),
                  DicomCommandType.Undefined, null, scu, null);
      }

      void store_AfterAssociateRequest(object sender, AfterAssociateRequestEventArgs e)
      {
         StoreScu scu = sender as StoreScu;

         if (!e.Rejected)
         {
            LogEvent(LogType.Information, MessageDirection.Input, ASSOCIATE_REQUEST_ACCEPTED,
                     DicomCommandType.Undefined, null, scu, null);
         }
         else
         {
            LogEvent(LogType.Information, MessageDirection.Input, string.Format(ASSOCIATE_REQUEST_REJECTED, e.Reason),
                     DicomCommandType.Undefined, null, scu, null);
         }
      }

      void store_BeforeCStore(object sender, BeforeCStoreEventArgs e)
      {
         StoreScu scu = sender as StoreScu;
         string message = string.Format(CSTORE_REQUEST_SEND, e.MessageId, e.PresentationID, e.AffectedClass, e.Instance);

         LogEvent(LogType.Information, MessageDirection.Output, message, DicomCommandType.CStore, null, scu, null);
      }

      void store_AfterCStore(object sender, AfterCStoreEventArgs e)
      {
         StoreScu scu = sender as StoreScu;
         string message = string.Format(CSTORE_RESPONSE_RECEIVED, e.MessageId, e.PresentationID, e.AffectedClass, e.Instance, e.Status);

         LogEvent(LogType.Information, MessageDirection.Input, message, DicomCommandType.CStore, null, scu, null);
      }

      void store_BeforeReleaseRequest(object sender, EventArgs e)
      {
         StoreScu scu = sender as StoreScu;

         LogEvent(LogType.Information, MessageDirection.Output, RELEASE_REQUEST_SENT, DicomCommandType.Undefined, null, scu, null);
      }

      void store_AfterReleaseRequest(object sender, EventArgs e)
      {
         StoreScu scu = sender as StoreScu;

         LogEvent(LogType.Information, MessageDirection.Input, RELEASE_RESPONSE_RECEIVED, DicomCommandType.Undefined, null, scu, null);
      }

      public static void LogEvent(LogType type, MessageDirection messageDirection, string description,
                                    DicomCommandType command, DicomDataSet dataset,
                                    StoreScu Client, SerializableDictionary<string, object> customInformation)
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

            Logger.Global.Log("Auto Copy", Client.CurrentScp.AETitle, Client.CurrentScp.PeerAddress.ToString(),
                              Client.CurrentScp.Port, net.IsAssociated() ? net.Association.Calling : ae,
                              net.HostAddress != null ? net.HostAddress.ToString() : string.Empty,
                              net.IsConnected() ? net.HostPort : -1, command, DateTime.Now, type,
                              messageDirection, description, dataset, logCustomInformation);
         }
         catch (Exception exception)
         {
            Logger.Global.Exception("Auto Copy", exception);
         }
      }

      #region IDisposable Members

      public void Dispose()
      {
         // 
         // Add null script to signal thead end
         //
         try
         {
            foreach (Thread worker in workers)
               worker.Abort();
         }
         catch { }
      }

      #endregion

      public void AddItem(AutoCopyItem item)
      {
         lock (locker)
         {
            _TaskQueue.Enqueue(item);
            Monitor.PulseAll(locker);
         }
      }
   }
}
