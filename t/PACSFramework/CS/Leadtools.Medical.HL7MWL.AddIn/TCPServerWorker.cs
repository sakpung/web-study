// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Medical.HL7.V2x.Listener;
using System.Net;
using System.Threading;
using System.Diagnostics;
using Leadtools.DicomDemos;
using Leadtools.Logging;

namespace Leadtools.Medical.HL7MWL.AddIn
{
   public class TCPServerWorker : IDisposable
   {
      static IPEndPoint _endPoint = null;
      static TCPServer _worker = null;
      static object objWorkersLock = new object();
      private bool _disposed = false;
      private string Source = string.Empty;
      
      public TCPServerWorker(string IP, int Port, string source)
      {
         if (IP == "localhost")
         {
            IP = "127.0.0.1";
         }
         _endPoint = new IPEndPoint(IPAddress.Parse(IP), Port);
         Source = source;
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

      public virtual void Dispose(bool bUnmanaged)
      {
         ShutdownWorker();
      }

      void ShutdownWorker()
      {
         TimeSpan timeOut = new TimeSpan(0, 0, 1);

         DateTime dtStart = DateTime.Now;

         if (IsBusy)
         {
            Cancel();
         }

         while (IsBusy)
         {
            System.Threading.Thread.Sleep(TimeSpan.FromMilliseconds(100));

            if (DateTime.Now - dtStart > timeOut)
            {
               break;
            }
         }
      }

      bool IsBusy
      {
         get
         {
            lock (objWorkersLock)
            {
               return _worker != null;
            }
         }
      }

      public void Startup()
      {
         try
         {
            lock (objWorkersLock)
            {
               new Thread(new ParameterizedThreadStart(__Worker)).Start(Source);
            }
         }
         catch
         {
            _worker = null;
            throw;
         }
      }

      public void Cancel()
      {
         lock (objWorkersLock)
         {
            if (null != _worker)
            {
               try
               {
                  _worker.TriggerStop();
               }
               catch
               {
                  //ignore
               }
            }
         }
      }

      static void __Worker(Object Source)
      {
         TCPServer tmpWorker = null;
         lock (objWorkersLock)
         {
            if (null != _worker)
            {
               return;
            }
            try
            {
               _worker = new TCPServer(_endPoint);
            }
            catch (Exception e)
            {
               //no license?
               Logger.Global.Error(Source.ToString(), e.Message);
               _worker = null;
               return;
            }
            
            _worker.RequestHandlerType = typeof(HL7MWLRequest);
            tmpWorker = _worker;
         }

         try
         {
            tmpWorker.Start();
         }
#if DEBUG
         catch (Exception e)
         {
            System.Diagnostics.Trace.WriteLine(e.Message);
            System.Diagnostics.Debugger.Break();
#else 
         catch(Exception)
         {
#endif
         }
         finally
         {
            lock (objWorkersLock)
            {
               _worker.Dispose();
               _worker = null;
            }
         }
      }
   }
}
