// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Dicom.Server.Admin;
using Leadtools.Medical.Winforms;
using Leadtools.Medical.AeManagement.DataAccessLayer;
using Leadtools.Medical.Storage.AddIns.Configuration;
using Leadtools.Medical.Gateway.CFindAddin.DataTypes;
using Leadtools.Dicom.AddIn.Interfaces;
using Leadtools.DicomDemos;

namespace Leadtools.Demos.StorageServer
{
   public class ServerState
   {
      private ServerState ( ){}

      static ServerState ( ) 
      {
         _instance = new ServerState ( ) ;
      }

      public static ServerState Instance
      {
         get
         {
            return _instance ;
         }
      }

      public DicomService ServerService
      {
         get
         {
            return _serverService ;
         }

         set
         {
            if ( value != _serverService ) 
            {
               _serverService = value ;

               OnServerServiceChanged ( ) ;
            }
         }
      }

      public ServiceAdministrator ServiceAdmin
      {
         get 
         {
            return _serviceAdmin ;
         }

         set
         {
            if ( value != _serviceAdmin ) 
            {
               _serviceAdmin = value ;

               OnServiceAdminChanged ( ) ;
            }
         }
      }

      public string BaseDirectory
      {
         get
         {
            return _baseDirectory ;
         }

         set
         {
            if ( value != _baseDirectory ) 
            {
               _baseDirectory = value ;

               OnBaseDirectoryChanged ( ) ;
            }
         }
      }

      public string ServiceName
      {
         get
         {
            return _serviceName ;
         }

         set
         {
            if ( value != _serviceName ) 
            {
               _serviceName = value ;

               OnServiceNameChanged ( ) ;
            }
         }
      }
      
      public LoggingState LoggingState
      {
         get 
         {
            return _loggingState ;
         }
         
         set 
         {
            if ( _loggingState != value ) 
            {
               _loggingState = value ;
               
               OnLoggingStateChanged ( ) ;
            }
         }
      }

      public bool IsRemoteServer
      {
         get
         {
            return _isRemoteServer ;
         }
         
         set
         {
            if ( value != _isRemoteServer ) 
            {
               _isRemoteServer = value ;
               
               OnIsRemoteServerChanged ( ) ;
            }
         }
      }

      public ClientInformationList ClientList
      {
         get;
         set;
      }

      public StorageServerInformation RemoteServerInformation
      {
         get
         {
            return _remoteServerInformation ;
         }
         
         set
         {
            if ( value != _remoteServerInformation ) 
            {
               _remoteServerInformation = value ;
               
               OnRemoteServerInformationChanged ( ) ;
            }
         }
      }
      
      private ILicense _License;

      public ILicense License
      {
         get
         {
            return _License;
         }

         set
         {
            if (_License != value)
            {
               _License = value;
               OnLicenseChanged();
            }
         }
      }
      
      public List <string> GatewayServers
      {
         get ;
         set ;
      }
      
      private void OnServiceNameChanged()
      {
         if ( null != ServiceNameChanged ) 
         {
            ServiceNameChanged ( this, EventArgs.Empty ) ;
         }
      }
      
      private void OnLoggingStateChanged()
      {
         if ( LoggingStateChanged != null ) 
         {
            LoggingStateChanged ( this, EventArgs.Empty ) ;
         }
      }

      private void OnServiceAdminChanged()
      {
         if ( null != ServiceAdminChanged ) 
         {
            ServiceAdminChanged ( this, EventArgs.Empty ) ;
         }
      }
      
      private void OnBaseDirectoryChanged()
      {
         if ( null != BaseDirectoryChanged ) 
         {
            BaseDirectoryChanged ( this, EventArgs.Empty ) ;
         }
      }
      
      private void OnIsRemoteServerChanged()
      {
         if ( null != IsRemoteServerChanged ) 
         {
            IsRemoteServerChanged ( this, EventArgs.Empty ) ;
         }
      }
      
      private void OnRemoteServerInformationChanged ( )
      {
         if ( null != RemoteServerInformationChanged )
         {
            RemoteServerInformationChanged ( this, EventArgs.Empty ) ;
         }
      }
      
      public void OnLicenseChanged()
      {
         if (LicenseChanged != null)
         {
            LicenseChanged(this, EventArgs.Empty);
         }
      }

      public event EventHandler ServerServiceChanged ;
      public event EventHandler ServiceAdminChanged ;
      public event EventHandler BaseDirectoryChanged ;
      public event EventHandler ServiceNameChanged ;
      public event EventHandler IsRemoteServerChanged ;
      public event EventHandler RemoteServerInformationChanged ;
      public event EventHandler LicenseChanged;
      public event EventHandler LoggingStateChanged ;

      private void OnServerServiceChanged ( ) 
      {
         if ( null != ServerServiceChanged ) 
         {
            ServerServiceChanged ( this, EventArgs.Empty ) ;
         }
      }

      private static ServerState       _instance ;
      private DicomService             _serverService ;
      private ServiceAdministrator     _serviceAdmin ;
      private string                   _baseDirectory ;
      private string                   _serviceName ;
      private bool                     _isRemoteServer ;
      private StorageServerInformation _remoteServerInformation ;
      private LoggingState               _loggingState ;
   }
}
