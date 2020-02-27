// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Dicom.AddIn.Interfaces;
using Leadtools.Dicom.AddIn.Configuration;
using Leadtools.Dicom.AddIn.Common;
using Leadtools.Dicom.Common.DataTypes.PatientUpdater;
using System.Reflection;
using System.Windows.Forms;
using Leadtools.Logging;
using Leadtools.Dicom.Scp.Command.NAction.PatientUpdater;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using Leadtools.Medical.OptionsDataAccessLayer;
using Leadtools.Medical.DataAccessLayer;
using Leadtools.Medical.AeManagement.DataAccessLayer;

namespace Leadtools.Medical.Winforms
{
   public class PatientUpdaterPresenter 
   {
      private string _AddIn = "PatientUpdater";
      private string _Name = "PatientUpdaterOptions";
      private AdvancedSettings _Settings = null;

      private string _ServiceDirectory;

      public string ServiceDirectory
      {
         get { return _ServiceDirectory; }
         set 
         {             
            _ServiceDirectory = value;
            if (!string.IsNullOrEmpty(_ServiceDirectory))
            {
               InitializeView();
            }
         }
      }

      #region IConfigureDialog Members

      public void RunView(PatientUpdaterConfigurationView view, string serviceDirectory)
      {         
         _ServiceDirectory = serviceDirectory;                            
         _view = view ;
         
         if ( !DataAccessServices.IsDataAccessServiceRegistered <IOptionsDataAccessAgent> ( ) )
         {
            throw new InvalidOperationException ( typeof ( IOptionsDataAccessAgent ).Name + " is not registered." ) ;
         }
         
         if ( !DataAccessServices.IsDataAccessServiceRegistered<IAeManagementDataAccessAgent> ( ) )
         {
            throw new InvalidOperationException ( typeof ( IAeManagementDataAccessAgent ).Name + " is not registered." ) ;
         }
                  
         _aeAccessAgent = DataAccessServices.GetDataAccessService<IAeManagementDataAccessAgent> ( ) ;         
                  
         _view.SettingsChanged += new EventHandler(View_SettingsChanged);

         EventBroker.Instance.Subscribe<ClientAddedEventArgs>(new EventHandler<ClientAddedEventArgs>(OnClientAdded));
         EventBroker.Instance.Subscribe<ClientRemovedEventArgs>(new EventHandler<ClientRemovedEventArgs>(OnClientRemoved));

         InitializeView();
         view.RequireStationNameChanged += new EventHandler(view_RequireStationNameChanged);
         view.RequireOperatorsNameChanged += new EventHandler(view_RequireOperatorsNameChanged);
         view.RequireTransactionUidChanged += new EventHandler(view_RequireTransactionUidChanged);
         view.RequireTransactionDateChanged += new EventHandler(view_RequireTransactionDateChanged);
         view.RequireTransactionTimeChanged += new EventHandler(view_RequireTransactionTimeChanged);
         view.RequireDescriptionChanged += new EventHandler(view_RequireDescriptionChanged);
         view.RequireReasonChanged += new EventHandler(view_RequireReasonChanged);
         view.AutoUpdateEnableChanged += new EventHandler(view_AutoUpdateEnableChanged);
         view.EnableRetryChanged += new EventHandler(view_EnableRetryChanged);
         view.RetrySecondsChanged += new EventHandler(view_RetrySecondsChanged);
         view.RetryExpirationDaysChanged += new EventHandler(view_RetryExpirationDaysChanged);
         view.RetryDirectoryChanged += new EventHandler(view_RetryDirectoryChanged);
         view.UseCustomAeTitleChanged += new EventHandler(view_UseCustomAeTitleChanged);
         view.CustomAeTitleChanged += new EventHandler(view_CustomAeTitleChanged);
         view.AutoUpdateProcessingThreadsChanged += new EventHandler(view_AutoUpdateProcessingThreadsChanged);         
      }

      private void InitializeView()
      {
         PatientUpdaterOptions clonedOptions;

         if (!string.IsNullOrEmpty(_ServiceDirectory))
         {
            _Settings = AdvancedSettings.Open(_ServiceDirectory);

            _options = _Settings.GetAddInCustomData<PatientUpdaterOptions>(_AddIn, _Name);
            if(_options == null)            
            {
               _options = new PatientUpdaterOptions();
            }
         }
         else
         {
            _Settings = null;
            _options = new PatientUpdaterOptions();
         }

         if (string.IsNullOrEmpty(_options.RetryDirectory))
         {
            _options.RetryDirectory = Path.Combine(_ServiceDirectory, @"AutoUpdate\");
         }

         clonedOptions = Clone(_options);
         _view.Initialize(clonedOptions, _aeAccessAgent);         
      }

      void view_AutoUpdateProcessingThreadsChanged(object sender, EventArgs e)
      {
         LocalAuditLogQueue.AddAuditMessage(AuditMessages.AutoUpdateProcessingThreadsChanged.Key,
            string.Format(AuditMessages.AutoUpdateProcessingThreadsChanged.Message, _view.AutoUpdateProcessingThreads));
      }

      void view_CustomAeTitleChanged(object sender, EventArgs e)
      {
         LocalAuditLogQueue.AddAuditMessage(AuditMessages.CustomAeTitleChanged.Key,
            string.Format(AuditMessages.CustomAeTitleChanged.Message, _view.CustomAeTitle));
      }

      void view_UseCustomAeTitleChanged(object sender, EventArgs e)
      {
         LocalAuditLogQueue.AddAuditMessage(AuditMessages.UseCustomAeTitleChanged.Key,
            string.Format(AuditMessages.UseCustomAeTitleChanged.Message, _view.UseCustomAeTitle));
      }

      void view_RetryDirectoryChanged(object sender, EventArgs e)
      {
         LocalAuditLogQueue.AddAuditMessage(AuditMessages.RetryDirectoryChanged.Key,
            string.Format(AuditMessages.RetryDirectoryChanged.Message, _view.RetryDirectory));
      }

      void view_RetryExpirationDaysChanged(object sender, EventArgs e)
      {
         LocalAuditLogQueue.AddAuditMessage(AuditMessages.RetryExpirationDaysChanged.Key,
            string.Format(AuditMessages.RetryExpirationDaysChanged.Message, _view.RetryExpirationDays));
      }

      void view_RetrySecondsChanged(object sender, EventArgs e)
      {
         LocalAuditLogQueue.AddAuditMessage(AuditMessages.RetrySecondsChanged.Key,
            string.Format(AuditMessages.RetrySecondsChanged.Message, _view.RetrySeconds));
      }

      void view_EnableRetryChanged(object sender, EventArgs e)
      {
         LocalAuditLogQueue.AddAuditMessage(AuditMessages.EnableRetryChanged.Key,
            string.Format(AuditMessages.EnableRetryChanged.Message, _view.EnableRetry));
      }

      void view_AutoUpdateEnableChanged(object sender, EventArgs e)
      {
         LocalAuditLogQueue.AddAuditMessage(AuditMessages.AutoUpdateEnableChanged.Key,
            string.Format(AuditMessages.AutoUpdateEnableChanged.Message, _view.AutoUpdateEnable));
      }

      void view_RequireReasonChanged(object sender, EventArgs e)
      {
         LocalAuditLogQueue.AddAuditMessage(AuditMessages.RequireReasonChanged.Key,
            string.Format(AuditMessages.RequireReasonChanged.Message, _view.RequireReason));
      }

      void view_RequireDescriptionChanged(object sender, EventArgs e)
      {
         LocalAuditLogQueue.AddAuditMessage(AuditMessages.RequireDescriptionChanged.Key,
            string.Format(AuditMessages.RequireDescriptionChanged.Message, _view.RequireDescription));
      }

      void view_RequireTransactionTimeChanged(object sender, EventArgs e)
      {
         LocalAuditLogQueue.AddAuditMessage(AuditMessages.RequireTransactionTimeChanged.Key,
            string.Format(AuditMessages.RequireTransactionTimeChanged.Message, _view.RequireTransactionTime));
      }

      void view_RequireTransactionDateChanged(object sender, EventArgs e)
      {
         LocalAuditLogQueue.AddAuditMessage(AuditMessages.RequireTransactionDateChanged.Key,
            string.Format(AuditMessages.RequireTransactionDateChanged.Message, _view.RequireTransactionDate));
      }

      void view_RequireTransactionUidChanged(object sender, EventArgs e)
      {
         LocalAuditLogQueue.AddAuditMessage(AuditMessages.RequireTransactionUidChanged.Key,
            string.Format(AuditMessages.RequireTransactionUidChanged.Message, _view.RequireTransactionUid));
      }

      void view_RequireOperatorsNameChanged(object sender, EventArgs e)
      {
         LocalAuditLogQueue.AddAuditMessage(AuditMessages.RequireOperatorsNameChanged.Key,
            string.Format(AuditMessages.RequireOperatorsNameChanged.Message, _view.RequireOperatersName));
      }

      void view_RequireStationNameChanged(object sender, EventArgs e)
      {
         LocalAuditLogQueue.AddAuditMessage(AuditMessages.RequireStationNameChanged.Key,
            string.Format(AuditMessages.RequireStationNameChanged.Message, _view.RequireStationName));
      }

      public event EventHandler SettingsChanged;

      private void View_SettingsChanged(object sender, EventArgs e)
      {
         try
         {
            if (SettingsChanged != null)
            {
               SettingsChanged(sender, e);
            }
         }
         catch (Exception)
         {
            System.Diagnostics.Debug.Assert(false);
         }
      }

      public bool IsDirty
      {
         get
         {
            return _view.IsDirty;
         }
      }

      public void SaveOptions ( ) 
      {
         _view.UpdateSettings ( ) ;

         if (_Settings != null)
         {
            // _Settings.RefreshSettings(); // **** Don't do this here or settings will be undone -- it is now done in ServerSettingsPresenter.cs, before any calls to UpdateSettings
            _Settings.SetAddInCustomData<PatientUpdaterOptions>(_AddIn, _Name, _view.Options);
            _Settings.Save();
            _options = Clone(_view.Options);
         }
      }
      
      public void CancelOptions ( ) 
      {
         _view.Initialize ( Clone ( _options ), _aeAccessAgent ) ;
      }
      
      public PatientUpdaterOptions Clone ( PatientUpdaterOptions options )
      {
         try
         {
            //
            // Don't serialize a null object, simply return the default for that object
            //
            if (Object.ReferenceEquals(options, null))
            {
               return null;
            }

            if (!options.GetType().IsSerializable)
            {
               throw new ArgumentException("The type must be serializable.", "source");
            }
            
            AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler ( CurrentDomain_AssemblyResolve ) ;

            IFormatter formatter = new BinaryFormatter();
            Stream stream = new MemoryStream();

            using (stream)
            {
               formatter.Serialize(stream, options);
               stream.Seek(0, SeekOrigin.Begin);

               return (PatientUpdaterOptions)formatter.Deserialize(stream);
            }
         }
         finally
         {
            AppDomain.CurrentDomain.AssemblyResolve -= CurrentDomain_AssemblyResolve;
         }
      }
      
      Assembly CurrentDomain_AssemblyResolve ( object sender, ResolveEventArgs args )
      {
         Assembly ayResult = null;
         string sShortAssemblyName = args.Name.Split(',')[0];
         Assembly[] ayAssemblies = AppDomain.CurrentDomain.GetAssemblies();

         foreach (Assembly ayAssembly in ayAssemblies)
         {
            if (sShortAssemblyName == ayAssembly.FullName.Split(',')[0])
            {
               ayResult = ayAssembly;
               break;
            }
         }
         return ayResult;
      }

      private void OnClientAdded(object sender, ClientAddedEventArgs e)
      {
         _view.AddAeTitle(e.NewClient);
      }

      private void OnClientRemoved(object sender, ClientRemovedEventArgs e)
      {
         _view.RemoveAeTitle(e.Ae);
      }     

      #endregion
      
      PatientUpdaterOptions _options ;
      private PatientUpdaterConfigurationView _view;

      public PatientUpdaterConfigurationView View
      {
         get { return _view; }
         set { _view = value; }
      }            
      private IAeManagementDataAccessAgent _aeAccessAgent ;
      
      string _optionsKeyName = typeof ( PatientUpdaterOptions ).Name ;
   }
}
