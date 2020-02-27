// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace PDFDocumentDemo.Workers
{
   class ThreadedPageWorkerPageProcessedEventArgs : EventArgs
   {
      private ThreadedPageWorkerPageProcessedEventArgs()
      {
      }

      public ThreadedPageWorkerPageProcessedEventArgs(int pageNumber, object data, Exception error)
      {
         _pageNumber = pageNumber;
         _data = data;
         _error = error;
      }

      private int _pageNumber;
      public int PageNumber
      {
         get { return _pageNumber; }
      }

      private object _data;
      public object Data
      {
         get { return _data; }
      }

      private Exception _error;
      public Exception Error
      {
         get { return _error; }
      }
   }

   // Base class for a threaded helper that works on pages
   abstract class ThreadedPageWorker : IDisposable
   {
      protected ThreadedPageWorker()
      {
      }

      ~ThreadedPageWorker()
      {
         Dispose(false);
      }

      public void Dispose()
      {
         Dispose(true);
         GC.SuppressFinalize(this);
      }

      protected virtual void Dispose(bool disposing)
      {
         if(disposing)
         {
            // Stop first
            StopWork();
         }
      }

      // Our thread
      private Thread _thread;
      // Synchronization object
      private static object _threadLockObject = new object();
      // Fires when loading all threads is finished or when aborted
      private AutoResetEvent _finishedEvent;
      // Indicates the pages that have been visited, when all is true, we are done
      private bool[] _visited;

      private bool _isWorking;
      private bool _IsAbortPending;

      // Are we working?
      public bool IsWorking
      {
         get
         {
            lock(_threadLockObject)
            {
               return _isWorking;
            }
         }
      }

      // Are we aborting?
      public bool IsAbortPending
      {
         get
         {
            lock(_threadLockObject)
            {
               return _IsAbortPending;
            }
         }
         set
         {
            lock(_threadLockObject)
            {
               _IsAbortPending = value;
            }
         }
      }

      private int _nextPageNumber;

      // Next page number to work, start at 1. Can be changed for example if this is a thumbnail generator and the UI changes
      // this value when the image list scrolls
      public int NextPageNumber
      {
         get
         {
            lock(_threadLockObject)
            {
               return _nextPageNumber;
            }
         }
         set
         {
            lock(_threadLockObject)
            {
               _nextPageNumber = value;
            }
         }
      }

      // Start working
      protected void StartWork(int pageCount)
      {
         // Stop before we start again
         StopWork();

         // Create the thread
         _thread = new Thread(new ParameterizedThreadStart(ThreadProc));
         _thread.IsBackground = true;

         // Create the events
         _finishedEvent = new AutoResetEvent(false);
         // Reset the visited pages
         _visited = new bool[pageCount];

         // Next page is first page
         NextPageNumber = 1;

         // Start working
         _isWorking = true;
         _IsAbortPending = false;
         _thread.Start(pageCount);
      }

      protected void StopWork()
      {
         if(_thread != null && IsWorking)
         {
            // Abort
            IsAbortPending = true;
            _finishedEvent.WaitOne();

            _thread = null;

            _finishedEvent.Close();
            _finishedEvent = null;
            _isWorking = false;
         }
      }

      protected abstract ThreadedPageWorkerPageProcessedEventArgs ProcessPage(int pageNumber);

      // Fires everytime a page is processed (before and after)
      public event EventHandler<ThreadedPageWorkerPageProcessedEventArgs> PrePageProcessed;
      public event EventHandler<ThreadedPageWorkerPageProcessedEventArgs> PostPageProcessed;
      public event EventHandler<EventArgs> ProcessFinished;

      // Get the next page to work on
      private int GetNextPageNumber(int pageCount)
      {
         // Find the next page to process
         int pageNumber = NextPageNumber;
         if(pageNumber < 1)
         {
            pageNumber = 1;
         }

         while(pageNumber <= pageCount && _visited[pageNumber - 1])
         {
            pageNumber++;
         }

         if(pageNumber > pageCount)
         {
            pageNumber = 1;
            while(pageNumber <= pageCount && _visited[pageNumber - 1])
            {
               pageNumber++;
            }
         }

         return pageNumber;
      }

      private void ThreadProc(object state)
      {
         int pageCount = (int)state;
         try
         {
            bool done = false;
            int visitedCount = 0;
            while(!done)
            {
               // Check if we need to abort
               if(IsAbortPending)
               {
                  return;
               }

               // Get next page number
               int pageNumber = GetNextPageNumber(pageCount);

               if(pageNumber > pageCount)
               {
                  // We are done
                  return;
               }

               // We worked on this
               _visited[pageNumber - 1] = true;

               if(PrePageProcessed != null)
               {
                  ThreadedPageWorkerPageProcessedEventArgs e = new ThreadedPageWorkerPageProcessedEventArgs(pageNumber, null, null);
                  PrePageProcessed(this, e);
               }

               visitedCount++;

               // Report it
               if(PostPageProcessed != null)
               {
                  ThreadedPageWorkerPageProcessedEventArgs e = ProcessPage(pageNumber);
                  PostPageProcessed(this, e);
               }

               if(visitedCount >= pageCount)
               {
                  done = true;
               }
            }
         }
         finally
         {
            if(ProcessFinished != null)
            {
               ProcessFinished(this, EventArgs.Empty);
            }

            _finishedEvent.Set();
         }
      }
   }
}
