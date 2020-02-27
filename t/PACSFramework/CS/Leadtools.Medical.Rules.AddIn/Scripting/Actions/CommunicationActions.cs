// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Leadtools.Dicom.AddIn.Interfaces;
using Leadtools.Dicom.AddIn;
using Leadtools.Dicom.Scu;
using System.Net;
using Leadtools.Dicom.AddIn.Common;
using Leadtools.Medical.Rules.AddIn.Workers;
using Leadtools.Dicom;
using Leadtools.Medical.Winforms.Forwarder.Scheduling;
using Leadtools.Logging;
using Leadtools.Medical.Rules.AddIn.Common;

namespace Leadtools.Medical.Rules.AddIn.Scripting.Actions
{
   public class CommunicationActions
   {      
      public static void route_dataset_to(DicomDS wrapper, params string[] aetitles)
      {
         try
         {
            List<DicomScp> scps = GetScps(aetitles);

            if (scps.Count > 0)
            {
               Store(wrapper, scps);
            }
         }
         catch (Exception e)
         {
            Logger.Global.SystemException(string.Empty, e);
         }
         finally
         {
            wrapper.Dataset = null;
            wrapper = null;
         }
      }

      public static void route_dataset_with_retry_to(DicomDS wrapper, int numRetries, int retryTimeout, params string[] aetitles)
      {         
         try
         {
            List<DicomScp> scps = GetScps(aetitles);
            DicomServer server = ServiceLocator.Retrieve<DicomServer>();            

            if (scps.Count > 0)
            {
               Store(wrapper, scps, numRetries, retryTimeout);
            }
         }
         catch(Exception e)
         {
            Logger.Global.SystemException(string.Empty, e);
         }
         finally
         {
            wrapper.Dataset = null;
            wrapper = null;
         }
      }

      public static void route_dataset_with_retry_to(DicomDS wrapper, string aetitle, string ipAddress, int port, int numRetries, int retryTimeout)
      {
         try
         {
            if (!string.IsNullOrEmpty(ipAddress))
            {
               DicomScp scp = new DicomScp(IPAddress.Parse(ipAddress), aetitle, port);

               Store(wrapper, new List<DicomScp>() { scp }, numRetries, retryTimeout);
            }
         }
         catch (Exception e)
         {
            Logger.Global.SystemException(string.Empty, e);
         }
         finally
         {
            wrapper.Dataset = null;
            wrapper = null;
         }
      }

      [CLSCompliant(false)]
      public static Job route_dataset_to_at(DicomDS wrapper, DateTimeOffset time, params string[] aetitles)
      {
         try
         {
            List<DicomScp> scps = GetScps(aetitles);

            if (scps.Count > 0)
            {
               Job job = new Job() { Loops = 1 };
               
               job.StartTime = time;
               Module.Scheduler.SubmitJob(job, (j) => Store(wrapper, scps));               
               Logger.Global.SystemMessage(LogType.Information, "Dataset will be stored to server {0} at {1}".FormatWith(aetitles.ToDisplay(), job.StartTime.ToString("MM/dd/yyyy - hh:mm:ss tt")), "");
               return job;
            }
         }
         catch (Exception e)
         {
            Logger.Global.SystemException(string.Empty, e);
         }         
         return null;
      }

      public static Job route_dataset_to_at(DicomDS wrapper, DateTimeOffset time, string aetitle, string ipAddress, int port)
      {
         try
         {
            if (!string.IsNullOrEmpty(ipAddress))
            {
               DicomScp scp = new DicomScp(IPAddress.Parse(ipAddress), aetitle, port);
               Job job = new Job() { Loops = 1 };                

               job.StartTime = time;
               Module.Scheduler.SubmitJob(job, (j) => Store(wrapper, new List<DicomScp>() {scp}));                                                              
               Logger.Global.SystemMessage(LogType.Information, "Dataset will be stored to server {0} at {1}".FormatWith(aetitle, job.StartTime.ToString("MM/dd/yyyy - hh:mm:ss tt")), "");
               return job;               
            }
         }
         catch (Exception e)
         {
            Logger.Global.SystemException(string.Empty, e);
         }
         finally
         {
            //wrapper.Dataset = null;
            //wrapper = null;
         }
         return null;
      }      

      public static void route_dataset_to(DicomDS wrapper, string aetitle, string ipAddress, int port)
      {
         try
         {
            if (!string.IsNullOrEmpty(ipAddress))
            {
               DicomScp scp = new DicomScp(IPAddress.Parse(ipAddress), aetitle, port);

               Store(wrapper, new List<DicomScp>() { scp });
            }
         }
         catch (Exception e)
         {
            Logger.Global.SystemException(string.Empty, e);
         }
         finally
         {
            wrapper.Dataset = null;
            wrapper = null;
         }
      }

      [CLSCompliant(false)]
      public static Job route_dataset_with_retry_to_at(DicomDS wrapper, DateTimeOffset time, int numRetries, int retryTimeout, params string[] aetitles)
      {
         try
         {
            List<DicomScp> scps = GetScps(aetitles);
            DicomServer server = ServiceLocator.Retrieve<DicomServer>();

            if (scps.Count > 0)
            {
               Job job = new Job() { Loops = 1 };

               job.StartTime = time;
                Module.Scheduler.SubmitJob(job, (j) => Store(wrapper, scps, numRetries, retryTimeout));
                Logger.Global.SystemMessage(LogType.Information, "Dataset will be stored to server {0} at {1}".FormatWith(aetitles.ToDisplay(), job.StartTime.ToString("MM/dd/yyyy - hh:mm:ss tt")), "");
                return job;
            }
         }
         catch (Exception e)
         {
            Logger.Global.SystemException(string.Empty, e);
         }         
         return null;
      }

      [CLSCompliant(false)]
      public static Job route_dataset_with_retry_to_at(DicomDS wrapper, string aetitle, string ipAddress, int port, DateTimeOffset time, int numRetries, int retryTimeout)
      {
         try
         {
            if (!string.IsNullOrEmpty(ipAddress))
            {
               DicomScp scp = new DicomScp(IPAddress.Parse(ipAddress), aetitle, port);
               Job job = new Job() { Loops = 1 };

               job.StartTime = time;
               Module.Scheduler.SubmitJob(job, (j) => Store(wrapper, new List<DicomScp>() { scp }, numRetries, retryTimeout));
               Logger.Global.SystemMessage(LogType.Information, "Dataset will be stored to server {0} at {1}".FormatWith(aetitle, job.StartTime.ToString("MM/dd/yyyy - hh:mm:ss tt")), "");
               return job;
            }
         }
         catch (Exception e)
         {
            Logger.Global.SystemException(string.Empty, e);
         }        
         return null;
      }

      #region Script Move Functions

      public static void move(MoveType type, string id, params string[] aetitles)
      {          
         try
         {
            switch (type)
            {
               case MoveType.Patient:
                  move_patient_to(id, aetitles);
                  break;
               case MoveType.Study:
                  move_study_to(id, aetitles);
                  break;
               case MoveType.Series:
                  move_series_to(id, aetitles);
                  break;
               default:
                  move_instance_to(id,aetitles);
                  break;
            }
         }
         catch (Exception e)
         {
            Logger.Global.SystemException(string.Empty, e);
         }
      }

      [CLSCompliant(false)]
      public static Job move_at(MoveType type, string id, DateTimeOffset time, params string[] aetitles)
      {
         try
         {
            switch (type)
            {
               case MoveType.Patient:
                  return move_patient_at(id, time, aetitles);                  
               case MoveType.Study:
                  return move_study_at(id, time, aetitles);                  
               case MoveType.Series:
                  return move_series_at(id, time, aetitles);                  
               default:
                  return move_instance_at(id, time, aetitles);                  
            }
         }
         catch (Exception e)
         {
            Logger.Global.SystemException(string.Empty, e);
         }
         return null;
      }

      public static void move_with_retry(MoveType type, string id, int numRetries, int retryTimeout, params string[] aetitles)
      {
         try
         {
            switch (type)
            {
               case MoveType.Patient:
                  move_patient_with_retry(id, numRetries, retryTimeout, aetitles);
                  break;
               case MoveType.Study:
                  move_study_with_retry(id, numRetries, retryTimeout, aetitles);
                  break;
               case MoveType.Series:
                  move_series_with_retry(id, numRetries, retryTimeout, aetitles);
                  break;
               default:
                  move_instance_with_retry(id, numRetries, retryTimeout, aetitles);
                  break;
            }
         }
         catch (Exception e)
         {
            Logger.Global.SystemException(string.Empty, e);
         }
      }

      [CLSCompliant(false)]
      public static Job move_at_with_retry(MoveType type, string id, DateTimeOffset time, int numRetries, int retryTimeout, params string[] aetitles)
      {
         try
         {
            Job job = new Job() { Loops = 1 };

            job.StartTime = time;                        
            switch (type)
            {
               case MoveType.Patient:
                  Module.Scheduler.SubmitJob(job, (j) => move_patient_with_retry(id, numRetries, retryTimeout, aetitles));
                  break;
               case MoveType.Study:
                  Module.Scheduler.SubmitJob(job, (j) => move_study_with_retry(id, numRetries, retryTimeout, aetitles));
                  break;
               case MoveType.Series:
                  Module.Scheduler.SubmitJob(job, (j) => move_series_with_retry(id, numRetries, retryTimeout, aetitles));
                  break;
               default:
                  Module.Scheduler.SubmitJob(job, (j) => move_instance_with_retry(id, numRetries, retryTimeout, aetitles));
                  break;
            }
            return job;
         }
         catch (Exception e)
         {
            Logger.Global.SystemException(string.Empty, e);
         }
         return null;
      }

      #endregion

      private static void move_patient_to(string patientID, params string[] aetitles)
      {
         try
         {
            MoveInfo info = new MoveInfo(patientID, MoveType.Patient);

            Move(info, aetitles);
         }
         catch (Exception e)
         {
            Logger.Global.SystemException(string.Empty, e);
         }
      }
      
      private static Job move_patient_at(string patientID, DateTimeOffset time, params string[] aetitles)
      {
         try
         {
            Job job = new Job() { Loops = 1 };

            job.StartTime = time;
            Module.Scheduler.SubmitJob(job, (j) => move_patient_to(patientID,aetitles));
            Logger.Global.SystemMessage(LogType.Information, "Patient {0} will be moved to server {0} at {1}".FormatWith(patientID, aetitles.ToDisplay(), job.StartTime.ToString("MM/dd/yyyy - hh:mm:ss tt")), "");
            return job;
         }
         catch (Exception e)
         {
            Logger.Global.SystemException(string.Empty, e);
         }
         return null;
      }

      private static void move_patient_with_retry(string patientId, int numRetries, int retryTimeout, params string[] aetitles)
      {
         try
         {
            MoveInfo info = new MoveInfo(patientId, MoveType.Patient);

            Move(info, numRetries, retryTimeout, aetitles);
         }
         catch (Exception e)
         {
            Logger.Global.SystemException(string.Empty, e);
         }
      }

      private static void move_study_to(string instanceUID, params string[] aetitles)
      {
         try
         {
            MoveInfo info = new MoveInfo(instanceUID, MoveType.Study);

            Move(info, aetitles);
         }
         catch (Exception e)
         {
            Logger.Global.SystemException(string.Empty, e);
         }
      }

      private static void move_study_with_retry(string instanceUID, int numRetries, int retryTimeout, params string[] aetitles)
      {
         try
         {
            MoveInfo info = new MoveInfo(instanceUID, MoveType.Study);

            Move(info, numRetries, retryTimeout, aetitles);
         }
         catch (Exception e)
         {
            Logger.Global.SystemException(string.Empty, e);
         }
      }
      
      private static Job move_study_at(string instanceUID, DateTimeOffset time, params string[] aetitles)
      {
         try
         {
            Job job = new Job() { Loops = 1 };

            job.StartTime = time;
            Module.Scheduler.SubmitJob(job, (j) => move_study_to(instanceUID, aetitles));
            Logger.Global.SystemMessage(LogType.Information, "Study {0} will be moved to server {1} at {2}".FormatWith(instanceUID, aetitles.ToDisplay(), job.StartTime.ToString("MM/dd/yyyy - hh:mm:ss tt")), "");
            return job;
         }
         catch (Exception e)
         {
            Logger.Global.SystemException(string.Empty, e);
         }
         return null;
      }

      private static void move_series_to(string instanceUID, params string[] aetitles)
      {
         try
         {
            MoveInfo info = new MoveInfo(instanceUID, MoveType.Series);

            Move(info, aetitles);
         }
         catch (Exception e)
         {
            Logger.Global.SystemException(string.Empty, e);
         }
      }
      
      private static Job move_series_at(string instanceUID, DateTimeOffset time, params string[] aetitles)
      {
         try
         {
            Job job = new Job() { Loops = 1 };

            job.StartTime = time;
            Module.Scheduler.SubmitJob(job, (j) => move_series_to(instanceUID, aetitles));
            Logger.Global.SystemMessage(LogType.Information, "Series {0} will be moved to server {0} at {1}".FormatWith(instanceUID, aetitles.ToDisplay(), job.StartTime.ToString("MM/dd/yyyy - hh:mm:ss tt")), "");
            return job;
         }
         catch (Exception e)
         {
            Logger.Global.SystemException(string.Empty, e);
         }
         return null;
      }

      private static void move_series_with_retry(string instanceUID, int numRetries, int retryTimeout, params string[] aetitles)
      {
         try
         {
            MoveInfo info = new MoveInfo(instanceUID, MoveType.Series);

            Move(info, numRetries, retryTimeout, aetitles);
         }
         catch (Exception e)
         {
            Logger.Global.SystemException(string.Empty, e);
         }
      }

      private static void move_instance_to(string instanceUID, params string[] aetitles)
      {
         try
         {
            MoveInfo info = new MoveInfo(instanceUID, MoveType.Instance);

            Move(info, aetitles);
         }
         catch (Exception e)
         {
            Logger.Global.SystemException(string.Empty, e);
         }
      }
     
      private static Job move_instance_at(string instanceUID, DateTimeOffset time, params string[] aetitles)
      {
         try
         {
            Job job = new Job() { Loops = 1 };

            job.StartTime = time;
            Module.Scheduler.SubmitJob(job, (j) => move_instance_to(instanceUID, aetitles));
            Logger.Global.SystemMessage(LogType.Information, "Instance {0} will be moved to server {0} at {1}".FormatWith(instanceUID, aetitles.ToDisplay(), job.StartTime.ToString("MM/dd/yyyy - hh:mm:ss tt")), "");
            return job;
         }
         catch (Exception e)
         {
            Logger.Global.SystemException(string.Empty, e);
         }
         return null;
      }

      private static void move_instance_with_retry(string instanceUID, int numRetries, int retryTimeout, params string[] aetitles)
      {
         try
         {
            MoveInfo info = new MoveInfo(instanceUID, MoveType.Series);

            Move(info, numRetries, retryTimeout, aetitles);
         }
         catch (Exception e)
         {
            Logger.Global.SystemException(string.Empty, e);
         }
      }

      private static void Store(DicomDataSet ds, List<DicomScp> scps)
      {
         try
         {
            if (scps.Count > 0)
            {
               StoreWorker sw = new StoreWorker(scps, ds);

               sw.RunWorkerAsync();
            }
         }
         finally
         {
            ds = null;
         }
      }

      private static void Store(DicomDataSet ds, List<DicomScp> scps, int retries, int retryTimeout)
      {
         try
         {
            if (scps.Count > 0)
            {
               DicomServer server = ServiceLocator.Retrieve<DicomServer>();
               StoreWorker sw = new StoreWorker(scps, ds);

               sw.EnableRetry = true;
               sw.NumberOfRetries = retries;
               sw.Timeout = retryTimeout;
               sw.RunWorkerAsync();
            }
         }
         finally
         {
            ds = null;
         }
      }      

      private static void Move(MoveInfo info, params string[] aetitles)
      {
         if (aetitles.Length > 0)
         {
            DicomServer server = ServiceLocator.Retrieve<DicomServer>();
            DicomScp scp = new DicomScp(IPAddress.Parse(server.HostAddress), server.AETitle, server.Port);
            MoveWorker mw = new MoveWorker(scp, aetitles.ToList(), info);

            mw.RunWorkerAsync();
         }
      }

      private static void Move(MoveInfo info,int retries, int retryTimeout, params string[] aetitles)
      {
         if (aetitles.Length > 0)
         {
            DicomServer server = ServiceLocator.Retrieve<DicomServer>();
            DicomScp scp = new DicomScp(IPAddress.Parse(server.HostAddress), server.AETitle, server.Port);
            MoveWorker mw = new MoveWorker(scp, aetitles.ToList(), info);

            mw.NumberOfRetries = retries;
            mw.Timeout = retryTimeout;
            mw.EnableRetry = true;
            mw.RunWorkerAsync();
         }
      }

      public static System.Net.IPAddress ResolveIPAddress(string hostNameOrAddress)
      {
         IPAddress[] addresses;
         addresses = Dns.GetHostAddresses(hostNameOrAddress.Trim());
         if (addresses == null || addresses.Length == 0)
         {
            throw new ArgumentException("Invalid hostNameOrAddress parameter.");
         }
         else
         {
            IPAddress address = (from a in addresses.OfType<IPAddress>()
                                where a.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork
                                select a).FirstOrDefault();

            if(address == null)
            {
               address = (from a in addresses.OfType<IPAddress>()
                          where a.AddressFamily == System.Net.Sockets.AddressFamily.InterNetworkV6
                          select a).FirstOrDefault();
            }

            if (address != null)
               return address;

            throw new ArgumentException("Could not resolve a valid host Address. Address must conform to IPv4 or IPv6.");
         }
      }

      private static List<DicomScp> GetScps(string[] aetitles)
      {
         List<DicomScp> scps = new List<DicomScp>();
         IAETitle aetitle = ServiceLocator.Retrieve<IAETitle>();

         foreach (string ae in aetitles)
         {
            try
            {               
               AeInfo info = aetitle.GetAeInfo(ae);               

               if (info != null && !string.IsNullOrEmpty(info.Address))
               {
#if LEADTOOLS_V20_OR_LATER
                  // Update dbo.AeInfo.LastAccessDate to Date.Now
                  info.LastAccessDate = DateTime.Now;
                  aetitle.Update(info.AETitle, info);
#endif

                  DicomScp scp = new DicomScp(ResolveIPAddress(info.Address), ae, info.Port);

                  scps.Add(scp);
               }
            }
            catch (Exception e)
            {
               Logger.Global.SystemException(string.Empty, e);
            }
         }
         return scps;
      }       
   }
}
