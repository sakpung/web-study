// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using Leadtools.Medical.PatientUpdater.AddIn.Retry;
using Leadtools.Medical.AeManagement.DataAccessLayer;
using Leadtools.Medical.AeManagement.DataAccessLayer.Configuration;
using Leadtools.DicomDemos;

namespace Leadtools.Medical.PatientUpdater.AddIn.Queue
{
   public class AutoUpdateQueue : IDisposable
   {
      private object locker = new object();
      private Thread[] workers;
      private Queue<AutoUpdateItem> _TaskQueue = new Queue<AutoUpdateItem>();
      private IAeManagementDataAccessAgent _AccessAgent;
      private AeManagementDataAccessConfigurationView _ConfigView;      
      private const int UPDATE_RELATION = 923;      
           
      public AutoUpdateQueue(int workerCount)
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
         _ConfigView = new AeManagementDataAccessConfigurationView(DicomDemoSettingsManager.GetGlobalPacsAddinsConfiguration(Module.ServiceDirectory), null, Module.ServiceName);
         _AccessAgent = DataAccessFactory.GetInstance(_ConfigView).CreateDataAccessAgent<IAeManagementDataAccessAgent>();
      }

      private void Process()
      {         
         while (true)
         {
            AutoUpdateItem item = null;

            lock (locker)
            {
               while (_TaskQueue.Count == 0)
                  Monitor.Wait(locker);
               item = _TaskQueue.Dequeue();
            }

            if (item == null)
               break;
            
            SendUpdate(item);
         }
      }

      private void SendUpdate(AutoUpdateItem item)
      {
         AeInfo[] aes = _AccessAgent.GetRelatedAeTitles(item.SourceAE, UPDATE_RELATION);
         DicomScp scp = null;
                  
         if (aes == null || aes.Length == 0)
            return;
                                   
         foreach (AeInfo ae in aes)
         {
            using (UpdateProcessor processor = new UpdateProcessor(Module.Options.UseCustomAE ? Module.Options.AutoUpdateAE : item.ClientAE))
            {
               try
               {
                  DicomCommandStatusType status = DicomCommandStatusType.Reserved4;

                  if (processor.Scu.IsConnected())
                     processor.Scu.CloseForced(true);
                  scp = new DicomScp(IPAddress.Parse(ae.Address), ae.AETitle, ae.Port);
                  status = processor.SendUpdate(scp, item.Dicom, item.Action);
                  if (status != DicomCommandStatusType.Success)
                  {                     
                     if (status != DicomCommandStatusType.MissingAttribute && status != DicomCommandStatusType.AttributeOutOfRange)
                     {                        
                        AddRetry(scp, item, ae.Address);
                     }
                  }
               }
               catch (ClientAssociationException ce)
               {
                  string message = string.Format("[Auto Update] Failed to establish association with server: {0}.  Adding {1} action to update retry queue.", ce.Reason, 
                                                 AutoRetryProcessor.Actions[item.Action]);

                  UpdateProcessor.LogEvent(LogType.Error, MessageDirection.None, message, DicomCommandType.Undefined, null, processor.Scu, null);
                  AddRetry(scp, item, ae.Address);
               }
               catch (DicomException de)
               {
                  string message = string.Format("[Auto Update] Error: {0}. Adding {1} action to update retry queue.", de.Message, AutoRetryProcessor.Actions[item.Action]);

                  UpdateProcessor.LogEvent(LogType.Error, MessageDirection.Input, message, DicomCommandType.Undefined, null, processor.Scu, null);
                  AddRetry(scp, item, ae.Address);
               }
               catch (Exception e)
               {
                  string message = "[Auto Update] " + e.Message;

                  Logger.Global.Log(string.Empty, string.Empty, -1, string.Empty, string.Empty, -1, DicomCommandType.Undefined,
                                 DateTime.Now, LogType.Error, MessageDirection.None, message, null, null);
               }
               finally
               {
               }
            }
         }                
      }                   

      #region IDisposable Members

      public void Dispose()
      {
         try
         {
            foreach (Thread worker in workers)
               worker.Abort();
         }
         catch { }
      }

      #endregion

      public void AddItem(AutoUpdateItem item)
      {
         lock (locker)
         {
            _TaskQueue.Enqueue(item);
            Monitor.PulseAll(locker);
         }
      }

      public static void AddRetry(DicomScp scp, AutoUpdateItem item, string ae)
      {
         if(Module.RetryProcessor!=null)
         {
            Module.RetryProcessor.AddRetry(scp,item,ae);
         }
      }
   }
}
