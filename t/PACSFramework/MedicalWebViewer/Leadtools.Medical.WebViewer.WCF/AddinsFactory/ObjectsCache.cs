// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.IO;
using System.Diagnostics;
using System.Configuration;
using System.Security;
using System.Threading;
using System.Collections.Concurrent;
using Leadtools.Medical.WebViewer.Wcf.Helper;
using System.Net;

namespace Leadtools.Medical.WebViewer.Wcf
{
   public interface IServiceObjectsFactory
   {
      T Get<T>(Func<T> create);
      void Release<T>(T obj);
   }
   
   /// <summary>
   /// normal behavior where objects are cached and shared throw threads
   /// </summary>
   public class ServiceObjectsFactory : IServiceObjectsFactory
   {
      public T Get<T>(Func<T> create)
      {
         var name = typeof(T).Name;
         T obj;
         obj = (T)ServiceObjectsCache.Instance.Get(name);
         if (null == obj)
         {
            System.Diagnostics.Debug.WriteLine("lt: creating object: " + name);

            try
            {
               obj = create();
            }
            catch (Exception e)
            {
               throw new ServiceException("Failed to create object of type: " + name + ": " + e.Message, HttpStatusCode.InternalServerError);
            }

            if (null == obj)
            {
               System.Diagnostics.Debug.WriteLine("Failed to create object of type: " + name);
               throw new ServiceException("Failed to create object of type: " + name, HttpStatusCode.InternalServerError);
            }

            ServiceObjectsCache.Instance.Put(name, obj);
         }
         return obj;
      }
      public void Release<T>(T obj)
      {
         //not required
      }
   }

   /// <summary>
   /// no caching behavior, where objects are created each and every time
   /// </summary>
   public class ServiceObjectsFactoryNoCaching : IServiceObjectsFactory
   {
      public T Get<T>(Func<T> create)
      {
         var name = typeof(T).Name;
         T obj;
         System.Diagnostics.Debug.WriteLine("lt: creating object: " + name);

         try
         {
            obj = create();
         }
         catch (Exception e)
         {
            throw new ServiceException("Failed to create object of type: " + name + ": " + e.Message, HttpStatusCode.InternalServerError);
         }

         if (null == obj)
         {
            System.Diagnostics.Debug.WriteLine("Failed to create object of type: " + name);
            throw new ServiceException("Failed to create object of type: " + name, HttpStatusCode.InternalServerError);
         }
         return obj;
      }
      
      public void Release<T>(T obj)
      {
         //not required   
      }
   }

   /// <summary>
   /// none-threaded behavior where objects are reused but not shared between threads
   /// </summary>
   public class ServiceObjectsFactoryNoneThreaded : IServiceObjectsFactory
   {
      public T Get<T>(Func<T> create)
      {
         var name = typeof(T).Name;
         T obj;
         obj = (T)ServiceObjectsCache.Instance.GetAndRemove(name, false);
         if (null == obj)
         {
            System.Diagnostics.Debug.WriteLine("lt: creating object: " + name);

            try
            {
               obj = create();
            }
            catch (Exception e)
            {
               throw new ServiceException("Failed to create object of type: " + name + ": " + e.Message, HttpStatusCode.InternalServerError);
            }

            if (null == obj)
            {
               System.Diagnostics.Debug.WriteLine("Failed to create object of type: " + name);
               throw new ServiceException("Failed to create object of type: " + name, HttpStatusCode.InternalServerError);
            }

            ServiceObjectsCache.Instance.Put(name, obj);
         }
         return obj;
      }
      public void Release<T>(T obj)
      {
         if (null != obj)
         {
            var name = typeof(T).Name;
            ServiceObjectsCache.Instance.Put(name, obj);
         }
      }
   }

   public sealed class ServiceObjectsCache : IDisposable
   {
      private static readonly ServiceObjectsCache instance = new ServiceObjectsCache();

      // Explicit static constructor to tell C# compiler
      // not to mark type as beforefieldinit
      static ServiceObjectsCache()
      {
      }

      private ServiceObjectsCache()
      {
         InitDisposableMembers();
      }

      public static ServiceObjectsCache Instance
      {
         get
         {
            return instance;
         }
      }

      public ConcurrentDictionary<string, object> CachedObjects = new ConcurrentDictionary<string, object>();

      private void Purge(bool disposing)
      {
         if (!disposing && this.IsDisposed)
         {
            return;
         }

         try
         {
            foreach (var item in CachedObjects)
            {
               var obj = GetAndRemove(item.Key, disposing);
               if (null != obj)
               {
                  Debug.WriteLine("lt: purge item: " + item.Key);
                  if (obj is IDisposable)
                  {
                     ((IDisposable)obj).Dispose();
                  }
               }
            }

            if (CachedObjects.Count > 0)
            {
               Debug.WriteLine("lt: (warning) items where added asynchronously");
            }
         }
         catch
         {
         }
      }

      public object GetAndRemove(string id, bool disposing)
      {
         if (!disposing && this.IsDisposed)
         {
            return null;
         }

         object obj;

         if (CachedObjects.TryRemove(id, out obj))
         {
            return obj;
         }
         else
         {
            Debug.WriteLine("lt: (warning) item was not found: " + id);
         }

         return null;
      }

      public object Get(string id)
      {
         if (this.IsDisposed)
         {
            return null;
         }

         object obj;

         if (CachedObjects.TryGetValue(id, out obj))
         {
            return obj;
         }

         return null;
      }

      public bool Contains(string id)
      {
         if (this.IsDisposed)
         {
            return false;
         }

         return CachedObjects.ContainsKey(id);
      }

      public void Put(string id, object obj)
      {
         if (this.IsDisposed)
         {
            return;
         }

         CachedObjects.TryAdd(id, obj);
      }

      private int _disposed;

      private bool IsDisposed
      {
         get
         {
            return this._disposed == 1;
         }
      }

      public void Dispose()
      {
         if (Interlocked.Exchange(ref this._disposed, 1) == 0)
         {
            Dispose(true);
            DisposeSafeCritical();
            GC.SuppressFinalize(this);
         }
      }

      ~ServiceObjectsCache()
      {
         Dispose(false);
      }

      void Dispose(bool disposing)
      {
         if (disposing)
         {
            Purge(disposing);
         }
      }

      private UnhandledExceptionEventHandler _onUnhandledException;

      private void OnAppDomainUnload(object unusedObject, EventArgs unusedEventArgs)
      {
         Debug.WriteLine("lt: OnAppDomainUnload");
         this.Dispose();
      }

      private void OnUnhandledException(object sender, UnhandledExceptionEventArgs eventArgs)
      {
         if (eventArgs.IsTerminating)
         {
            this.Dispose();
         }
      }

      [SecuritySafeCritical]
      //[PermissionSet(SecurityAction.Assert, Unrestricted = true)]
      private void InitDisposableMembers()
      {
         bool success = false;

         try
         {
            AppDomain.CurrentDomain.ProcessExit -= OnAppDomainUnload;

            if (AppDomain.CurrentDomain.IsDefaultAppDomain())
            {
               AppDomain.CurrentDomain.ProcessExit += OnAppDomainUnload;
            }
            else
            {
               AppDomain.CurrentDomain.DomainUnload += OnAppDomainUnload;
            }

            _onUnhandledException = new UnhandledExceptionEventHandler(OnUnhandledException);
            AppDomain.CurrentDomain.UnhandledException += _onUnhandledException;

            success = true;
         }
         finally
         {
            if (!success)
            {
               this.Dispose();
            }
         }
      }

      [SecuritySafeCritical]
      //[PermissionSet(SecurityAction.Assert, Unrestricted = true)]
      private void DisposeSafeCritical()
      {
         AppDomain.CurrentDomain.ProcessExit -= OnAppDomainUnload;
         AppDomain.CurrentDomain.DomainUnload -= OnAppDomainUnload;
         AppDomain.CurrentDomain.UnhandledException -= this._onUnhandledException;
         _onUnhandledException = null;

         Debug.WriteLine("lt: DisposeSafeCritical");
      }
   }
}
