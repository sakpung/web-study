// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Dicom.Server.Admin;
using System.ServiceProcess;
using System.Threading;
using System.Windows.Forms;
using Leadtools.Demos.StorageServer.DataTypes;
using Leadtools.Medical.Winforms;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Net;
using System.Net.NetworkInformation;
using Leadtools.Dicom.AddIn;

#if (LEADTOOLS_V19_OR_LATER_MEDICAL_VERIFY_ADDINS) || (LEADTOOLS_V19_OR_LATER)
using Leadtools.Medical.Winforms.ExternalStore;
using Leadtools.Dicom.AddIn.Common;
#endif

namespace Leadtools.Demos.StorageServer.UI
{
   class ServerInformationPresenter
   {
      private System.Timers.Timer _Timer = new System.Timers.Timer(500);
      private object _TimerLock = new object();

      public void RunView ( ServerInformationView view ) 
      {
         View = view ;
         
         __SyncContext = WindowsFormsSynchronizationContext.Current ;

         ConfigureView ( ) ;

         ServerState.Instance.ServerServiceChanged           += new EventHandler ( OnConfigureView ) ;
         ServerState.Instance.IsRemoteServerChanged          += new EventHandler ( OnConfigureView ) ;
         ServerState.Instance.RemoteServerInformationChanged += new EventHandler ( OnConfigureView ) ;
         
         EventBroker.Instance.Subscribe <ServerSettingsAppliedEventArgs> ( OnConfigureView ) ;         
         _Timer.Elapsed += new System.Timers.ElapsedEventHandler(_Timer_Elapsed);
         _Timer.Enabled = true;
      }

      void _Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
      {
         lock (_TimerLock)
         {
            try
            {
               _Timer.Stop();
               CheckIpAvailability();
            }
            catch { }
            _Timer.Start();
         }
      }      
      
      void OnConfigureView ( object sender, EventArgs e )
      {
         ConfigureView ( ) ;
      }

      private void ConfigureView ( )
      {
         DicomService service = ServerState.Instance.ServerService ;


         __SyncContext.Send ( new SendOrPostCallback ( delegate ( object state ) {
         
         if ( ServerState.Instance.IsRemoteServer )
         {
            View.CanStartStopServer = false ;
            
            if ( null != ServerState.Instance.RemoteServerInformation ) 
            {
               View.ServerDisplayName = ServerState.Instance.RemoteServerInformation.ServiceName ;
               View.ServerAE          = ServerState.Instance.RemoteServerInformation.DicomServer.AE ;
               View.IpAddress         = ServerState.Instance.RemoteServerInformation.DicomServer.IPAddress ;
               View.Port              = ServerState.Instance.RemoteServerInformation.DicomServer.Port.ToString ( ) ;
               View.IsSecure          = ServerState.Instance.RemoteServerInformation.DicomServer.UseTls;
            }
            
            return ;
         }
         
         if ( null != service ) 
         {
            View.ServerDisplayName = service.Settings.Description.Length>0?service.Settings.Description:"Storage Server" ;
            View.ServerAE          = service.Settings.AETitle ;
            View.IpAddress         = service.Settings.IpAddress.ToString ( ) ;
            View.Port              = service.Settings.Port.ToString ( ) ;
            View.IsSecure          = Service.Settings.Secure;

            View.StartService += new EventHandler ( view_StartService ) ;
            View.StopService  += new EventHandler ( view_StopService ) ;

            SetServiceStatus ( ) ;           
             
            Service.StatusChange += new EventHandler ( Service_StatusChange ) ;
            _Timer.Enabled = true;
         }
         else
         {
            _Timer.Enabled = false;
            View.ServerDisplayName = string.Empty ;
            View.ServerAE          = string.Empty ;
            View.IpAddress         = string.Empty ;
            View.Port              = string.Empty ;
            View.IsSecure          = false;

            View.IsServerRunning    = true ;
            View.CanStartStopServer = false ;
            View.Status             = "Not Applicable";               
         }
         } ), null ) ;
      }

      private void CheckIpAvailability()
      {
         IPGlobalProperties ipGlobalProperties = IPGlobalProperties.GetIPGlobalProperties();
         IPEndPoint[] endpoints = ipGlobalProperties.GetActiveTcpListeners();
         bool available = true;

         if (View.IsServerRunning)
            return;

         if (Service != null && Service.Settings != null)
         {
            foreach (IPEndPoint endpoint in endpoints)
            {
               if (endpoint.Address.ToString() == Service.Settings.IpAddress && endpoint.Port == Service.Settings.Port)
               {
                  available = false;
                  break;
               }
            }
         }

         if (!available && View.CanStart)
         {
            AsyncHelper.SynchronizedInvoke(View, () =>
            {
               View.CanStart = false;
               if (Service != null && Service.Settings != null)
               {
                  View.Port = Service.Settings.Port.ToString() + " [Port Unavailable]";
               }
            });
         }
         else if (available)
         {
            AsyncHelper.SynchronizedInvoke(View, () =>
           {
              View.CanStart = true;
              if (Service != null && Service.Settings != null)
              {
                 View.Port = Service.Settings.Port.ToString();
              }
           });
         }
      }

      void view_StartService ( object sender, EventArgs e )
      {
         _Timer.Enabled = false;
         if (Service != null)
         {
            Service.Start();
         }
      }

      void view_StopService(object sender, EventArgs e)
      {
         if (Service != null)
         {
            ServerState.Instance.ServerService.SendMessage(MessageNames.ServiceShuttingDown);
            Service.Stop();
         }
      }

      void Service_StatusChange ( object sender, EventArgs e )
      {
         if (Service.Status == ServiceControllerStatus.Stopped)
         {
            _Timer.Interval = 500;
            _Timer.Start();
         }

         SetServiceStatus ( ) ;
      }

#if (LEADTOOLS_V19_OR_LATER_MEDICAL_VERIFY_ADDINS) || (LEADTOOLS_V19_OR_LATER)
      private void QueryAddins()
      {
         if (ServerState.Instance.ServerService != null)
         {
            ServiceMessage message = new ServiceMessage();
            message.Message = MessageNames.IsAddinHealthy;
            message.Broadcast = true;

            try
            {
               // (05.23.2019)
               // If the administrative pipe is not connected, this can cause the StorageServerManager.exe UI to crash
               // I noticed this when the CSDicomHighLevelClient demo does a move, and I stop/start the CSStorageServerManger.exe listening service during the move
               // The UI will sometimes crash
               ServerState.Instance.ServerService.SendMessage(message);
            }
            catch (Exception)
            {
               // Console.WriteLine(ex.Message);
            }
         }
      }
#endif // #if (LEADTOOLS_V19_OR_LATER_MEDICAL_VERIFY_ADDINS) || (LEADTOOLS_V19_OR_LATER)

      private void SetServiceStatus ( )
      {
         string status = Regex.Replace(Service.Status.ToString(), "(\\B[A-Z])", " $1");

         __SyncContext.Send ( new SendOrPostCallback ( delegate ( object state ) {
            
                       
            View.IsServerRunning = Service.Status == ServiceControllerStatus.Running;
            View.CanStartStopServer = View.IsServerRunning ;                           

            //
            // Convert CamelCase Status to a space delimeted status.  StartPending becomes Start Pending
            //
            View.Status = status;

         } ), null ) ;

#if (LEADTOOLS_V19_OR_LATER_MEDICAL_VERIFY_ADDINS) || (LEADTOOLS_V19_OR_LATER)
         if (string.Equals(status, "Running",StringComparison.OrdinalIgnoreCase))
         {
            QueryAddins();
         }
#endif // #if (LEADTOOLS_V19_OR_LATER_MEDICAL_VERIFY_ADDINS) || (LEADTOOLS_V19_OR_LATER)
      }

      public ServerInformationView View
      {
         get ;
         private set ;
      }

      public DicomService Service
      {
         get 
         {
            return ServerState.Instance.ServerService ;
         }
      }

      private SynchronizationContext __SyncContext 
      {
         get ;
         set ;
      }
   }
}
