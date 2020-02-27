// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;

using System.Text;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Xml.Serialization;

namespace Leadtools.Medical.WebViewer.Jobs
{
   public class Job : Object, IDisposable
   {
      private object synch = new object();
      private Status _status = Status.idle;
      private CompletedStatus _completedStatus = CompletedStatus.failed;
      private int _nProgress = 0;
      private bool _disposed = false;
      private bool _aborttrigger = false;
      public string LastError { get; set; }

      static Job()
      {
      }
            
      public Job()
      {
         status = Status.idle;
      }
      
      ~Job()
      {
         if (!this._disposed)
         {
            this._disposed = true;
            Dispose(false);
         }
      }

      public void Dispose()
      {
         if (!this._disposed)
         {
            this._disposed = true;
            Dispose(true);
            GC.SuppressFinalize(this);
         }
      }

      public virtual void Dispose(bool bUnmanaged) { }

      public enum Status
      {
         idle,
         pending,
         running,
         completed
      }

      public enum CompletedStatus
      {
         success,
         failed,
         aborted
      }

      virtual public void StartJob()
      {         
      }

      virtual public void StopJob() { }
      [XmlIgnore]
      public bool isSuccessfull
      {
         get
         {
            lock (synch)
            {
               return (status == Status.completed) && (completedStatus == CompletedStatus.success);
            }
         }
      }
      [XmlIgnore]
      public bool isFailed
      {
         get
         {
            lock (synch)
            {
               return (status == Status.completed) && (completedStatus != CompletedStatus.success);
            }
         }
      }
      [XmlIgnore]
      public bool isAborted
      {
         get
         {
            lock (synch)
            {
               return (status == Status.completed) && (completedStatus == CompletedStatus.aborted);
            }
         }
      }
      [XmlIgnore]
      public bool isBusy
      {
         get
         {
            return (status == Status.pending) || (status == Status.running);
         }
      }

      public void JobPending()
      {
         lock (synch)
         {
            progress = 0;
            status = Status.pending;
         }
      }

      public void JobRunning()
      {
         lock (synch)
         {
            status = Status.running;
         }
      }

      public void JobSucceeded()
      {
         lock (synch)
         {
            progress = 100;
            completedStatus = CompletedStatus.success;
            status = Status.completed;
         }
      }

      public void JobFailed(string sError)
      {
         lock (synch)
         {
            completedStatus = CompletedStatus.failed;
            status = Status.completed;
            LastError = sError;
         }
      }

      public void JobAborted()
      {
         lock (synch)
         {
            completedStatus = CompletedStatus.aborted;
            status = Status.completed;
         }
      }

      protected virtual void TryAbort()
      {
         //void
      }

      public void TriggerAbort()
      {
         lock (synch)
         {
            _aborttrigger = true;
            
            TryAbort();
         }
      }

      public bool IsAbortTriggered()
      {
         lock (synch)
         {
            return _aborttrigger;
         }
      }
      public Status status
      {
         set
         {
            lock (synch)
            {
               _status = value;
            }            
         }
         get
         {
            Status _localStatus = Status.idle;

            lock (synch)
            {
               _localStatus = _status ;
            }
            return _localStatus;
         }
      }
      
      public CompletedStatus completedStatus
      {
         set
         {
            lock (synch)
            {
               _completedStatus = value;
            }
         }
         get
         {
            CompletedStatus _localCompletedStatus = CompletedStatus.failed;

            lock (synch)
            {
               _localCompletedStatus = _completedStatus ;
            }
            return _localCompletedStatus;
         }
      }
      
      public int progress
      {
         set
         {
            lock (synch)
            {
               _nProgress = value;
            }
         }
         get
         {
            int _localProgress = 0;

            lock (synch)
            {
               _localProgress = _nProgress;
            }
            return _localProgress;
         }
      }
   }
}
