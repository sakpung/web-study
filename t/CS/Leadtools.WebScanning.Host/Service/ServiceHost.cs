// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.IO;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Web;
using System.Windows.Forms;
using Leadtools.Services.Twain;
using Leadtools.Wcf;
using Leadtools.WebScanning.Commands;

namespace Leadtools.WebScanning.Host
{
   internal class TwainServiceHost : IDisposable
   {
      private int _clientsCount = 0;

      public TwainServiceHost()
      {
      }

      public TwainScanningService ScanningService { get; private set; }
      public WebServiceHost ServiceHost { get; private set; }

      public bool IsStarted { get; private set; }

      public void Start(IntPtr owner)
      {
         if (this.IsStarted)
            Stop();

         WebServiceHost tempServiceHost = null;
         TwainScanningService tempScanningService = null;

         try
         {
            Uri localAddress = new Uri(DemoUtils.ServiceUrl);

            CorsSupportBehavior corsSupport = new CorsSupportBehavior();
            WebHttpBehavior httpBehavior = new WebHttpBehavior();
            Uri[] baseAddresses = null;

            tempScanningService = new TwainScanningService(owner);
            baseAddresses = new Uri[] { localAddress };
            tempServiceHost = new WebServiceHost(tempScanningService, baseAddresses);
#if HTTPS_SUPPORT
            WebHttpBinding secureWebHttpBinding = new WebHttpBinding(WebHttpSecurityMode.Transport) { Name = "secureHttpWeb" };
            secureWebHttpBinding.CrossDomainScriptAccessEnabled = true;
            ServiceEndpoint secureEndPoint = tempServiceHost.AddServiceEndpoint(typeof(ITwainScanningService), secureWebHttpBinding, "");
            secureEndPoint.Behaviors.Add(corsSupport);
            secureEndPoint.Behaviors.Add(httpBehavior);
#else
            WebHttpBinding binding = new WebHttpBinding();
            binding.CrossDomainScriptAccessEnabled = true;
            ServiceEndpoint endpoint = tempServiceHost.AddServiceEndpoint(typeof(ITwainScanningService), binding, localAddress);
            endpoint.Behaviors.Add(corsSupport);
            endpoint.Behaviors.Add(httpBehavior);
#endif // #if HTTPS_SUPPORT


            tempServiceHost.Open();

            // all success
            this.ServiceHost = tempServiceHost;
            this.ScanningService = tempScanningService;
            this.IsStarted = true;

            this.ScanningService.ImageProcessing += ScanningService_ImageProcessing;
            this.ScanningService.ClientStarted += ScanningService_ClientStarted;
            this.ScanningService.ClientStopped += ScanningService_ClientStopped;
            this.ScanningService.RunCommandCallBack = CommandCallBack;
         }
         catch(Exception ex)
         {
            try
            {
               if (tempServiceHost != null)
               {
                  tempServiceHost.Close();
                  tempServiceHost = null;
               }

               if (tempScanningService != null)
               {
                  tempScanningService.Dispose();
                  tempScanningService = null;
               }
            }
            catch { }

            Console.WriteLine(ex.Message);
            throw;
         }
      }

      private Stream CommandCallBack(CommandEventArgs args)
      {
         Console.WriteLine(args.CommandName);
         Console.WriteLine(args.Arguments);
         // TODO: Handle custom user command

         // Check if the user command is "loadcommand"
         if (args.CommandName.ToLower() == "loadcommand")
         {
            // Deserialize arguments to LoadCommandArgs
            LoadCommandArgs loadArgs = LoadCommandArgs.FromJSON(args.Arguments);
            // Run the load command
            LoadCommand.Run(args.Id, this.ScanningService, loadArgs);
         }

         return null;
      }

      private void ScanningService_ClientStarted(object sender, ClientConnectionEventArgs e)
      {
         _clientsCount++;
      }

      private void ScanningService_ClientStopped(object sender, ClientConnectionEventArgs e)
      {
         _clientsCount--;

         if (_clientsCount == 0)
         {
            Application.Exit();
         }
      }

      private void ScanningService_ImageProcessing(object sender, PageImageProcessingEventArgs e)
      {
         // Perform image processing
         ImageProcessing.Run(e);
      }

      public void Stop()
      {
         if (!this.IsStarted)
            return;

         if (this.ScanningService != null)
         {
            this.ScanningService.RunCommandCallBack = null;
            this.ScanningService.ClientStopped -= ScanningService_ClientStopped;
            this.ScanningService.ClientStarted -= ScanningService_ClientStarted;
            this.ScanningService.ImageProcessing -= ScanningService_ImageProcessing;
            this.ScanningService.Dispose();
            this.ScanningService = null;
         }

         if (this.ServiceHost != null)
         {
            this.ServiceHost.Close();
            this.ServiceHost = null;
         }

         this.IsStarted = false;
      }

      #region IDisposable
      public void Dispose()
      {
         Dispose(false);


         GC.SuppressFinalize(this);
      }
      ~TwainServiceHost()
      {
         Dispose(false);
      }
      protected virtual void Dispose(bool disposing)
      {
         if (disposing)
         {
            if (this.IsStarted)
               Stop();
         }
      }
      #endregion //#region IDisposable
   }
}
