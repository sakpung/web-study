// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Medical.Winforms.Forwarder;
using Leadtools.Medical.Winforms.Forwarder.Scheduling;
using System.Diagnostics;
using Leadtools.Medical.Forward.DataAccessLayer;
using Leadtools.Medical.Forward.DataAccessLayer.DataTypes;
using Leadtools.Medical.AeManagement.DataAccessLayer;
using Leadtools.Dicom.Scu;
using System.Net;
using Leadtools.Dicom;
using Leadtools.Logging;
using Leadtools.Logging.Medical;
using Leadtools.Dicom.Scu.Common;
using Leadtools.Medical.Winforms.Forwarder.Controls;
using Leadtools.Medical.Storage.DataAccessLayer;
using Leadtools.Medical.DataAccessLayer;
using Leadtools.Medical.Storage.DataAccessLayer.MatchingParameters;
using Leadtools.Medical.Forwarder.AddIn.Processes;

namespace Leadtools.Medical.Forwarder.AddIn
{
   public class JobManager
   {
      private ForwardOptions _Options;
      private Scheduler Scheduler = new Scheduler();
      private IForwardDataAccessAgent _forwardAgent;
      private IAeManagementDataAccessAgent _aeAgent;
      private IStorageDataAccessAgent _storageAgent;
      private AeInfoExtended _AeInfo;
      private DicomScp _Scp = null;      

      private string _ServerAE;

      public string ServerAE
      {
         get { return _ServerAE; }
         set { _ServerAE = value; }
      }

      public JobManager(ForwardOptions options, IForwardDataAccessAgent fagent, IAeManagementDataAccessAgent aagent, IStorageDataAccessAgent sagent)
      {
         _Options = options;
         _forwardAgent = fagent;
         _aeAgent = aagent;
         _storageAgent = sagent;
      }

      private DateTimeOffset FixUpStartTime(DateTimeOffset startTimeOld, TimeSpan interval)
      {
         DateTimeOffset now = DateTime.Now;

         DateTimeOffset startTime = new DateTimeOffset(startTimeOld.Year, startTimeOld.Month, startTimeOld.Day, startTimeOld.Hour, startTimeOld.Minute, startTimeOld.Second, startTimeOld.Millisecond, now.Offset);
      
         TimeSpan timeSpan_starttimeToNow = now.Subtract(startTime);
         long numberOfIntervals = timeSpan_starttimeToNow.Ticks / interval.Ticks;


         // Do not add extra interval
         // Example 1:
         //    Forward start date:  01/01/2017 at 12:00 PM
         //    Service starts at:   01/01/2018 at 12:00 PM
         //    Interval is:         1 day
         // Then newStartTime becomes DateTime.Now

         // Add extra interval:
         // Example 2:
         //    Forward start date:  01/01/2017 at 12:00 PM
         //    Service starts at:   01/01/2018 at 11:57 AM
         //    Interval is:         1 day
         // Then newStartTime becomes 01/01/2018 at 12:00

         // Add extra interval:
         // Example 3:
         //    Forward start date:  01/01/2017 at 12:00 PM
         //    Service starts at:   01/01/2018 at 12:03 AM
         //    Interval is:         1 day
         // Then newStartTime becomes 01/02/2018 at 12:00

         DateTimeOffset newStartTime = startTime.Add(interval.Multiply(numberOfIntervals));

         if (newStartTime < now)
         {
            newStartTime = newStartTime.Add(interval);
         }

         Debug.Assert(newStartTime >= now);
         return newStartTime;
      }

      private void FixUpJob(Job job)
      {         
         //
         // If start time is less than the current time we need to make start time at the next interval
         //
         if (job.StartTime < DateTime.Now)
         {
            if (job.Interval.HasValue)
            {
               // job.StartTime = DateTime.Now.Add(job.Interval.Value);
               job.StartTime = FixUpStartTime(job.StartTime, job.Interval.Value);
            }
         }
      }

      public void Start()
      {        
         try
         {
            _AeInfo = _aeAgent.GetAeTitle(_Options.ForwardTo);
            if (_AeInfo != null)
            {
               IPAddress address = IPAddress.None;

               if (!IPAddress.TryParse(_AeInfo.Address, out address))
               {
                  IPHostEntry host = Dns.GetHostEntry(_AeInfo.Address);

                  if (host.AddressList.Length > 0)
                  {
                     address = host.AddressList[0];
                  }
               }

               _Scp = new DicomScp(address, _AeInfo.AETitle, _AeInfo.Port);
               if (_Options.Forward != null)
               {
                  FixUpJob(_Options.Forward);
                  Scheduler.SubmitJob(_Options.Forward, new Action<Job>(Forward));
               }

               if (_Options.Clean != null)
               {
                  FixUpJob(_Options.Clean);
                  Scheduler.SubmitJob(_Options.Clean, new Action<Job>(Clean));
               }
            }
         }
         catch { }
      }

      public void Start(ForwardOptions options)
      {
         try
         {
            _AeInfo = _aeAgent.GetAeTitle(options.ForwardTo);
            if (_AeInfo != null)
            {
               IPAddress address = IPAddress.None;

               if (!IPAddress.TryParse(_AeInfo.Address, out address))
               {
                  IPHostEntry host = Dns.GetHostEntry(_AeInfo.Address);

                  if (host.AddressList.Length > 0)
                  {
                     address = host.AddressList[0];
                  }
               }

               _Scp = new DicomScp(address, _AeInfo.AETitle, _AeInfo.Port);
               if (options.Forward != null)
               {
                  FixUpJob(options.Forward);
                  Scheduler.SubmitJob(options.Forward, new Action<Job>(Forward));
               }

               if (options.Clean != null)
               {
                  FixUpJob(options.Clean);
                  Scheduler.SubmitJob(options.Clean, new Action<Job>(Clean));
               }
            }
            _Options = options;
         }
         catch { }
      }      

      public void Stop()
      {
         Scheduler.CancelAll();
      }

      private void MyPauseJob(Job job)
      {
         if (job.Interval != null)
         {
            job.Pause();
         }
      }

      private void MyResumeJob(Job job)
      {
         if (job.Interval != null)
         {
            job.Resume();
         }
      }

      private void Forward(Job job)
      {         
         // job.Pause();
         MyPauseJob(job);
         try
         {            
            new ForwardProcess(_Options, _ServerAE).Run(_Scp, _forwardAgent);
         }
         catch(Exception e)
         {
            string message = string.Format("[Forwarder] Error processing forward request: {0}", e.Message);

            Logger.Global.SystemMessage(LogType.Error, message, _ServerAE);
         }
         finally
         {
            // job.Resume();
            MyResumeJob(job);
         }
      }

      private void Clean(Job job)
      {         
         // job.Pause();
         MyPauseJob(job);
         try
         {
            new CleanProcess(_Options, _ServerAE).Run(_forwardAgent, _storageAgent);
         }
         catch (Exception e)
         {
            string message = string.Format("[Forwarder] Error processing clean request: {0}", e.Message);

            Logger.Global.SystemMessage(LogType.Error, message, _ServerAE);
         }
         finally
         {
            // job.Resume();
            MyResumeJob(job);
         }
      }            
   }
}
