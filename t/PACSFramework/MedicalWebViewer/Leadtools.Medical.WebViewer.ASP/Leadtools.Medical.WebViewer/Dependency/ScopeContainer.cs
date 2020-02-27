// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;

namespace Leadtools.Medical.WebViewer.Dependency
{
   //public class ReqSecPerformanceCounter
   //{
   //   public static string Category = "Leadtools Medical Services";
   //   public static string Name = "# req received / sec";

   //   private PerformanceCounter counter;

   //   public ReqSecPerformanceCounter(string instance)
   //   {
   //      counter = new PerformanceCounter();
   //      counter.CategoryName = Category;
   //      counter.InstanceName = instance;
   //      counter.CounterName = Name;
   //      counter.MachineName = ".";
   //      counter.ReadOnly = false;
   //      counter.RawValue = 0;
   //   }

   //   public void Increment(int req)
   //   {
   //      counter.IncrementBy(req*100);
   //   }

   //   static public void CheckPerformanceCategory()
   //   {
   //      if (PerformanceCounterCategory.Exists(Category))
   //      {
   //         PerformanceCounterCategory.Delete(Category);
   //      }

   //      if (!PerformanceCounterCategory.Exists(Category))
   //      {
   //         CounterCreationDataCollection counters = new CounterCreationDataCollection();

   //         CounterCreationData receivedCounter = new CounterCreationData();
   //         receivedCounter.CounterName = Name;
   //         receivedCounter.CounterHelp = Name;
   //         receivedCounter.CounterType = PerformanceCounterType.SampleCounter;
   //         counters.Add(receivedCounter);

   //         PerformanceCounterCategory.Create(Category, "Performance counters for " + Category, PerformanceCounterCategoryType.MultiInstance, counters);
   //      }
   //   }
   //}

   public class ScopeContainer : IDependencyScope
   {
      protected IUnityContainer container;
      //protected ReqSecPerformanceCounter _counter = null;

      public ScopeContainer(IUnityContainer container)
      {
         if (container == null)
         {
            throw new ArgumentNullException("container");
         }
         this.container = container;

         try
         {
            //ReqSecPerformanceCounter.CheckPerformanceCategory();
            //_counter = new ReqSecPerformanceCounter("IIS");
         }
         catch { }
      }

      
      protected static string GetIPAddress()
      {
         System.Web.HttpContext context = System.Web.HttpContext.Current;
         string ipAddress = context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

         if (!string.IsNullOrEmpty(ipAddress))
         {
            string[] addresses = ipAddress.Split(',');
            if (addresses.Length != 0)
            {
               return addresses[0];
            }
         }

         return context.Request.ServerVariables["REMOTE_ADDR"];
      }

      public object GetService(Type serviceType)
      {
         //use this for entrprise lib 6
         //if (container.IsRegistered(serviceType))
         //{
         //   return container.Resolve(serviceType);
         //}
         //else
         //{
         //   return null;
         //}
         try
         {
            //System.Diagnostics.Debug.WriteLine("request: " + GetIPAddress() + "   -" + serviceType.Name);
            
            if (serviceType.Namespace.Contains("Leadtools.Medical.WebViewer.Controllers"))
            {
               //if(serviceType.Name=="ThreeDController")
               {
                  //_counter?.Increment(1);
               }

               return container.Resolve(serviceType);
            }
         }
         catch (Exception e)
         {
            Debug.WriteLine(e.Message);
         }
         return null;
      }

      public IEnumerable<object> GetServices(Type serviceType)
      {
         //use this for entrprise lib 6
         //if (container.IsRegistered(serviceType))
         //{
         //   return container.ResolveAll(serviceType);
         //}
         //else
         //{
         //   return new List<object>();
         //}
         try
         {
            if (serviceType.Namespace.Contains("Leadtools.Medical.WebViewer.Controllers"))
               return container.ResolveAll(serviceType);
         }
         catch (Exception e)
         {
            Debug.WriteLine(e.Message);
         }
         return new List<object>();
      }

      public void Dispose()
      {
         container.Dispose();
      }
   }

   class IoCContainer : ScopeContainer, IDependencyResolver
   {
      public IoCContainer(IUnityContainer container)
         : base(container)
      {
      }

      public IDependencyScope BeginScope()
      {
         var child = container.CreateChildContainer();
         return new ScopeContainer(child);
      }
   }
}
