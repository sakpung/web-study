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
using Leadtools.Medical.AutoCopy.AddIn.Queue;
using System.Diagnostics;
using Leadtools.Medical.Winforms;
using Leadtools.Medical.DataAccessLayer;
using Leadtools.DicomDemos;
using Leadtools.Dicom.AddIn.Interfaces;
using Leadtools.Medical.Storage.DataAccessLayer;
using Leadtools.Dicom;

#if (LEADTOOLS_V19_OR_LATER_MEDICAL_VERIFY_ADDINS) || (LEADTOOLS_V19_OR_LATER)
using Leadtools.Dicom.AddIn.Common;
using Leadtools.Medical.DataAccessLayer.Configuration;
using Leadtools.Medical.AeManagement.DataAccessLayer;
using Leadtools.Medical.Storage.DataAccessLayer.Configuration;
using Leadtools.Medical.AeManagement.DataAccessLayer.Configuration;
#endif

namespace Leadtools.Medical.AutoCopy.AddIn
{
   public class Module : ModuleInit, IProcessBreak
   {
      public const string Source = "Auto Copy";
      public const int AUTOCOPY_RELATION = 914;
      public static AutoCopyQueue CopyQueue = null;
      public static AutoCopyOptions Options;
      public static DicomServer _Server;

      // DICOM Security
      public static IDicomSecurity _dicomSecurityAgent;
      public static IDicomSecurityCiphers _dicomSecurityCiphersAgent;
      public static DicomOpenSslContextCreationSettings _openSslOptions = null;
      public static  List<DicomTlsCipherSuiteType> _cipherSuiteList = null;

      public static string ServiceDirectory
      {
         get;
         set;
      }

      public static string DisplayName
      {
         get;
         set;
      }
      
      public static string ServiceName
      {
         get;
         set;
      }

      public static bool UseTls
      {
         get;
         set;
      }

      public override void Load(string serviceDirectory, string displayName)
      {        
         try
         {
            AdvancedSettings settings = AdvancedSettings.Open(serviceDirectory);

            ServiceDirectory = serviceDirectory ;
            DisplayName      = displayName ;
            _Server = ServiceLocator.Retrieve <DicomServer> ( );
            ServiceName = _Server.Name;

            if (!ServiceLocator.IsRegistered<SettingsChangedNotifier>())
            {
               SettingsChangedNotifier configChangedNotifier = new SettingsChangedNotifier(settings);

               configChangedNotifier.SettingsChanged += new EventHandler(configChangedNotifier_SettingsChanged);
               configChangedNotifier.Enabled = true;
               ServiceLocator.Register<SettingsChangedNotifier>(configChangedNotifier);
            }
            else
            {
               ServiceLocator.Retrieve<SettingsChangedNotifier>().SettingsChanged += new EventHandler(configChangedNotifier_SettingsChanged);
            }

            ConfigureAutoCopy(settings);
         }
         catch (Exception e)
         {
            if (Options == null)
               Options = new AutoCopyOptions();

            Logger.Global.Error(Source, e.Message);
         }
      }

      private void ConfigureAutoCopy(AdvancedSettings settings)
      {         
         string name = Assembly.GetExecutingAssembly().GetName().Name;

         Options = GetAutoCopyOptions(settings);

         if (Options.EnableAutoCopy)
         {
            if (CopyQueue != null)
               CopyQueue.Dispose();

            CopyQueue = new AutoCopyQueue(Options.AutoCopyThreads);
            CopyQueue.InitializeDatabase();
         }
         else
         {
            if (CopyQueue != null)
            {
               CopyQueue.Dispose();
               CopyQueue = null;
            }
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

      void configChangedNotifier_SettingsChanged(object sender, EventArgs e)
      {
         // Reinitialize the dicom security settings
         InitializeDicomSecurity(true);

         AdvancedSettings settings = AdvancedSettings.Open(ServiceDirectory);

         ConfigureAutoCopy(settings);
      }
      
      public static AutoCopyOptions GetAutoCopyOptions (AdvancedSettings settings ) 
      {         
         AutoCopyOptions options = null ;

         try
         {
            options = settings.GetAddInCustomData<AutoCopyOptions>(Source, "AutoCopyOptions");
            if (options == null)
            {
               options = new AutoCopyOptions();
            }
         }
         catch (Exception e)
         {
            if (options == null)
               options = new AutoCopyOptions();

            Logger.Global.Error(Source, e.Message);
         }

         return options;
      }          

      #region IProcessBreak Members

      public void Break(BreakType type)
      {
         if (CopyQueue != null)
         {
            CopyQueue.Dispose();
         }
      }

      #endregion
   }

#if (LEADTOOLS_V19_OR_LATER_MEDICAL_VERIFY_ADDINS) || (LEADTOOLS_V19_OR_LATER)
   public class AutoCopyServerMessage : IProcessServiceMessage
   {
      #region IProcessServiceMessage Members

      public bool CanProcess(string MessageId)
      {
         return (
                 MessageId == MessageNames.IsAddinHealthy
                 );
      }

      private string _assemblyName = string.Empty;
      public string AssemblyName
      {
         get
         {
            if (string.IsNullOrEmpty(_assemblyName))
            {
               System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
               if (assembly != null)
               {
                  _assemblyName = assembly.ManifestModule.Name;
               }
            }
            return _assemblyName;
         }
      }

      public static T GetAgent<T>(System.Configuration.Configuration configuration, DataAccessConfigurationView view )
      {
         T agent;

         if (!DataAccessServices.IsDataAccessServiceRegistered<T>())
         {
            agent = DataAccessFactory.GetInstance(view).CreateDataAccessAgent<T>();
            DataAccessServices.RegisterDataAccessService<T>(agent);
         }
         else
         {
            agent = DataAccessServices.GetDataAccessService<T>();
         }
         return agent;
      }

      public bool CanAccessDatabase(out string error)
      {
         error = string.Empty;
         bool ret = false;
         try
         {
            System.Configuration.Configuration configuration = DicomDemoSettingsManager.GetGlobalPacsAddinsConfiguration(Module.ServiceDirectory);

            IStorageDataAccessAgent storageAgent = GetAgent<IStorageDataAccessAgent>(configuration, new StorageDataAccessConfigurationView(configuration, null, Module.ServiceName));
            IAeManagementDataAccessAgent aeManagementAgent = GetAgent<IAeManagementDataAccessAgent>(configuration, new AeManagementDataAccessConfigurationView(configuration, null, Module.ServiceName));

            bool bContinue = true;
            if (aeManagementAgent == null)
            {
               error = string.Format("{0} {1}", AssemblyName, "Cannot create IAeManagementDataAccessAgent");
               bContinue = false;
            }

            if (bContinue)
            {
               if (storageAgent == null)
               {
                  error = string.Format("{0} {1}", AssemblyName, "Cannot create IStorageDataAccessAgent");
                  bContinue = false;
               }
            }

            if (bContinue)
            {
               storageAgent.MaxQueryResults = 10;
               storageAgent.IsPatientsExists("patientIdNotUsed");

               aeManagementAgent.GetAeTitle("notUsed");
            }
         }
         catch (Exception e)
         {
            error = string.Format("{0} {1}", AssemblyName, e.Message);
         }

         ret = string.IsNullOrEmpty(error);
         return ret;
      }

      public ServiceMessage Process(ServiceMessage Message)
      {
         ServiceMessage serviceMessage = null;
         switch (Message.Message)
         {
            case MessageNames.IsAddinHealthy:
               serviceMessage = new ServiceMessage();
               string error;
               serviceMessage.Message = Message.Message;
               serviceMessage.Success = CanAccessDatabase(out error);
               serviceMessage.Error = error;
               break;
         }
         return serviceMessage;
      }

      #endregion
   }
#endif // #if (LEADTOOLS_V19_OR_LATER_MEDICAL_VERIFY_ADDINS) || (LEADTOOLS_V19_OR_LATER)
}
