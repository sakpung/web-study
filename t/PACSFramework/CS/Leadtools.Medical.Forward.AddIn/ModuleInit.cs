// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Dicom.AddIn;
using Leadtools.Dicom.Common.DataTypes.PatientUpdater;
using Leadtools.Logging;
using Leadtools.Dicom.AddIn.Configuration;
using System.Reflection;
using System.Diagnostics;
using Leadtools.Medical.Winforms.Forwarder;
using Leadtools.Medical.DataAccessLayer;
using Leadtools.Medical.Forward.DataAccessLayer;
using Leadtools.Medical.Forward.DataAccessLayer.Configuration;
using Leadtools.Medical.AeManagement.DataAccessLayer;
using Leadtools.Medical.AeManagement.DataAccessLayer.Configuration;
using Leadtools.Medical.Storage.DataAccessLayer;
using Leadtools.Medical.Storage.DataAccessLayer.Configuration;
using Leadtools.Dicom.AddIn.Interfaces;
using Leadtools.DicomDemos;
using Leadtools.Medical.Storage.AddIns;
using Leadtools.Dicom;

namespace Leadtools.Medical.Forwarder.AddIn
{
   public class Module : ModuleInit, IProcessBreak
   {
      public const string Source = "Forwarder";
      public JobManager JobManager;
      public static DicomServer _Server;
      private static string _serviceDirectory;
      public static StorageModuleConfigurationManager StorageConfigManager;
      public static IAeManagementDataAccessAgent _aeManagementAgent = null;

      // DICOM Security
      public static IDicomSecurity _dicomSecurityAgent;
      public static IDicomSecurityCiphers _dicomSecurityCiphersAgent;
      public static DicomOpenSslContextCreationSettings _openSslOptions = null;
      public static List<DicomTlsCipherSuiteType> _cipherSuiteList = null;

      public static string ServiceDirectory
      {
         get { return _serviceDirectory; }
         set { _serviceDirectory = value; }
      }

      public static string ServiceName
      {
         get;
         set;
      }

      private static string _ServerAE;

      public static string ServerAE
      {
         get { return Module._ServerAE; }
         set { Module._ServerAE = value; }
      }

      private static object optionsLock = new object();
      private static ForwardOptions _Options;

      public static ForwardOptions Options
      {
         get
         {
            lock (optionsLock)
            {
               return Module._Options;
            }
         }
         set
         {
            lock (optionsLock)
            {
               Module._Options = value;
            }
         }
      }

      private static ILicense _License;

      public static ILicense License
      {
         get { return Module._License; }
         set { Module._License = value; }
      }

      private static int _Timeout;

      public static int Timeout
      {
         get
         {
            return _Timeout;
         }
      }


      public override void Load(string serviceDirectory, string displayName)
      {
         IForwardDataAccessAgent forwardAgent;
         IAeManagementDataAccessAgent aeAgent;
         IStorageDataAccessAgent storageAgent;
         AdvancedSettings settings = AdvancedSettings.Open(serviceDirectory);

         RegisterServerEvents(settings);
         _serviceDirectory = serviceDirectory;
         
         DicomServer server = ServiceLocator.Retrieve<DicomServer>();
         ServiceName = server.Name;
         _Timeout = server.ClientTimeout <= 0 ? 30 : server.ClientTimeout;

         try
         {            
            Options = settings.GetAddInCustomData<ForwardOptions>(ForwardManagerPresenter._addinName, "ForwardOptions");
            if (Options == null)
            {
               Options = new ForwardOptions();               
            }
         }
         catch (Exception e)
         {
            if (Options == null)
               Options = new ForwardOptions();

            Logger.Global.Error(Source, e.Message);
         }

         StorageConfigManager = new StorageModuleConfigurationManager( true );
         StorageConfigManager.Load(ServiceDirectory);
         System.Configuration.Configuration configuration = DicomDemoSettingsManager.GetGlobalPacsAddinsConfiguration(serviceDirectory);
         if (!DataAccessServices.IsDataAccessServiceRegistered<IForwardDataAccessAgent>())
         {
            forwardAgent = DataAccessFactory.GetInstance(new ForwardDataAccessConfigurationView(configuration, null, displayName)).CreateDataAccessAgent<IForwardDataAccessAgent>();
            DataAccessServices.RegisterDataAccessService<IForwardDataAccessAgent>(forwardAgent);
         }
         else
            forwardAgent = DataAccessServices.GetDataAccessService<IForwardDataAccessAgent>();

         if (!DataAccessServices.IsDataAccessServiceRegistered<IAeManagementDataAccessAgent>())
         {
            aeAgent = DataAccessFactory.GetInstance(new AeManagementDataAccessConfigurationView(configuration, null, displayName)).CreateDataAccessAgent<IAeManagementDataAccessAgent>();
            DataAccessServices.RegisterDataAccessService<IAeManagementDataAccessAgent>(aeAgent);
         }
         else
            aeAgent = DataAccessServices.GetDataAccessService<IAeManagementDataAccessAgent>();

         _aeManagementAgent = aeAgent;

         if (!DataAccessServices.IsDataAccessServiceRegistered<IStorageDataAccessAgent>())
         {
            storageAgent = DataAccessFactory.GetInstance(new StorageDataAccessConfigurationView(configuration, null, displayName)).CreateDataAccessAgent<IStorageDataAccessAgent>();
            DataAccessServices.RegisterDataAccessService<IStorageDataAccessAgent>(storageAgent);
         }
         else
            storageAgent = DataAccessServices.GetDataAccessService<IStorageDataAccessAgent>();

         JobManager = new JobManager(Options, forwardAgent, aeAgent, storageAgent);
         JobManager.ServerAE = _ServerAE;
         if (IsLicenseValid())
         {
            JobManager.Start();
         }
      }

      /// <summary>
      /// Determines whether the server has a valid license for forwarding.
      /// </summary>
      /// <returns>
      ///   <c>true</c> if the license is valid; otherwise, <c>false</c>.
      /// </returns>
      private bool IsLicenseValid()
      {
         if (ServiceLocator.IsRegistered<ILicense>())
         {
            DicomServer server = ServiceLocator.Retrieve<DicomServer>();

            _License = ServiceLocator.Retrieve<ILicense>();
            _License.LicenseChanged += new EventHandler(OnLicenseChanged);
            if (!License.IsFeatureValid(ServerFeatures.Forwarding))
            {
               Logger.Global.SystemMessage(LogType.Error, "[Forwarder] No valid license for forwarding found.  Forwarding will not be available.", server.AETitle);
               return false;
            }
            else if (_License.IsFeatureEvaluation(ServerFeatures.Forwarding) && _License.IsFeatureExpired(ServerFeatures.Forwarding))
            {
               Logger.Global.SystemMessage(LogType.Error, "[Forwarder] Evaluation period for forwarding has expired.  Forwarding will not be available.", server.AETitle);
               return false;
            }
         }
         return true;
      }

      void OnLicenseChanged(object sender, EventArgs e)
      {
         if (JobManager != null)
         {
            JobManager.Stop();
            if (IsLicenseValid())
            {
               JobManager.Start();
            }
         }
      }

      private void RegisterServerEvents(AdvancedSettings settings)
      {
         DicomServer server = ServiceLocator.Retrieve<DicomServer>();

         if (server != null)
         {
            _Server = server;
            _ServerAE = server.AETitle;
            server.ServerSettingsChanged += new EventHandler(server_ServerSettingsChanged);
         }

         if (settings != null)
         {
            if (!ServiceLocator.IsRegistered<SettingsChangedNotifier>())
            {
               SettingsChangedNotifier configChangedNotifier = new SettingsChangedNotifier(settings);

               configChangedNotifier.SettingsChanged += new EventHandler(server_AdvancedSettingsChanged);
               configChangedNotifier.Enabled = true;
               ServiceLocator.Register<SettingsChangedNotifier>(configChangedNotifier);
            }
            else
               ServiceLocator.Retrieve<SettingsChangedNotifier>().SettingsChanged += new EventHandler(server_AdvancedSettingsChanged);
         }
      }

      public static bool IsDicomSecurityAvailable()
      {
         return ServiceLocator.IsRegistered<IDicomSecurity>();
      }

      public static void SetCiphers(DicomNet dicomNet)
      {
         if (_dicomSecurityCiphersAgent == null)
            return;

         int index = 0;
         foreach (DicomTlsCipherSuiteType cipher in _dicomSecurityCiphersAgent.CipherSuiteList)
         {
            dicomNet.SetTlsCipherSuiteByIndex(index, cipher);
            index++;
         }
      }

      public static void InitializeDicomSecurity(bool forceInitialize)
      {
         if ((_dicomSecurityAgent == null) || (forceInitialize))
         {
            if (ServiceLocator.IsRegistered<IDicomSecurity>())
            {
               _dicomSecurityAgent = ServiceLocator.Retrieve<IDicomSecurity>();
            }
         }

         if ((_dicomSecurityCiphersAgent == null) || (forceInitialize))
         {
            if (ServiceLocator.IsRegistered<IDicomSecurityCiphers>())
            {
               _dicomSecurityCiphersAgent = ServiceLocator.Retrieve<IDicomSecurityCiphers>();
            }
         }

         if (_cipherSuiteList == null || (forceInitialize))
         {
            if (_dicomSecurityCiphersAgent != null)
            {
               _cipherSuiteList = _dicomSecurityCiphersAgent.CipherSuiteList;
            }
         }

         if ((_openSslOptions == null) || (forceInitialize))
         {
            if (_dicomSecurityAgent != null)
            {
               _openSslOptions =
                  new DicomOpenSslContextCreationSettings(
                     _dicomSecurityAgent.SslMethodType,
                     _dicomSecurityAgent.CertificationAuthoritiesFileName,
                     _dicomSecurityAgent.VerificationFlags,
                     _dicomSecurityAgent.MaximumVerificationDepth,
                     _dicomSecurityAgent.Options);
            }
         }
      }

      /// <summary>
      /// Handles the AdvancedSettingsChanged event of the server control.
      /// </summary>
      /// <param name="sender">The source of the event.</param>
      /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
      /// <remarks>
      /// If the forwarding options changed we need to reinitialize the forwarding engine.
      /// </remarks>
      void server_AdvancedSettingsChanged(object sender, EventArgs e)
      {
         ForwardOptions options;
         AdvancedSettings settings = AdvancedSettings.Open(_serviceDirectory);

         if (settings != null)
         {
            settings.RefreshSettings();
            options = settings.GetAddInCustomData<ForwardOptions>(ForwardManagerPresenter._addinName, "ForwardOptions");
            if (Options == null && options == null)
            {
               options = new ForwardOptions();
            }
            Options = options;
            if (JobManager != null)
            {
               JobManager.Stop();
               if (IsLicenseValid())
               {
                  JobManager.Start(Options);
               }
            }
         }

         // Reinitialize the dicom security settings
         InitializeDicomSecurity(true);
      }
     
      void server_ServerSettingsChanged(object sender, EventArgs e)
      {
         _ServerAE = _Server.AETitle;
         _Timeout = _Server.ClientTimeout <= 0 ? 30 : _Server.ClientTimeout;
         if (JobManager != null)
         {
            JobManager.ServerAE = _ServerAE;
         }
      }

      #region IProcessBreak Members

      public void Break(BreakType type)
      {
         if (JobManager != null)
         {
            JobManager.Stop();
         }
      }

      #endregion
   }
}
