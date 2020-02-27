// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Dicom.AddIn.Configuration;
using Leadtools.Medical.Winforms;

namespace Leadtools.Medical.Logging.Addins
{
   public class LoggingModuleConfigurationManager : IDisposable
   {
      #region Public
         
         #region Methods
         
            public LoggingModuleConfigurationManager ( bool autoRefresh ) 
            {
               AutoRefresh = autoRefresh ;
            }
            
            public void Dispose ( )
            {
               Dispose(true);
               GC.SuppressFinalize ( this ) ;
            }
            
            public bool AutoRefresh
            {
               get ;
               private set ;
            }
            
            public void Save ( ) 
            {
               if ( IsLoaded ) 
               {
                  _settingsChangedNotify.Enabled = false ;
                  
                  _settingsChangedNotify.SettingsChanged -= new EventHandler ( notifier_SettingsChanged ) ;
                  
                  
                  try
                  {
                     _advancedSettings.Save ( ) ;
                  }
                  finally
                  {
                     _settingsChangedNotify.SettingsChanged += new EventHandler ( notifier_SettingsChanged ) ;
                     
                     _settingsChangedNotify.Enabled = true ;
                  }
               }
               else
               {
                  throw new InvalidOperationException ( "Service has not been initialized. Call the Load method" ) ;
               }
            }
            
            public void Load ( string serviceDirectory )
            {
               if ( IsLoaded ) 
               {
                  Unload ( ) ;
               }
               _advancedSettings = AdvancedSettings.Open ( serviceDirectory ) ;
               
               _settingsChangedNotify = new SettingsChangedNotifier ( _advancedSettings ) ;

               _settingsChangedNotify.SettingsChanged += new EventHandler ( notifier_SettingsChanged ) ;
               
               _settingsChangedNotify.Enabled = true ;
            }

            public void Unload ( ) 
            {
               if ( IsLoaded ) 
               {
                  _settingsChangedNotify.SettingsChanged -= new EventHandler ( notifier_SettingsChanged ) ;
                  
                  _settingsChangedNotify.Enabled = false ;
                  
                  _settingsChangedNotify.Dispose ( ) ;
                  
                  _settingsChangedNotify = null ;
               }
               
               _advancedSettings = null ;
               _loggingState     = null ;
            }
            
            public LoggingState GetLoggingState ( )
            {
               if ( null == _loggingState  )
               {
                  _loggingState = GetLoggingStateInternal ( ) ;
               }
               
               return _loggingState ;
            }
            
            private LoggingState GetLoggingStateInternal ( )
            {
               string       addInName ;
               string       loggingStateKey ;
               LoggingState state ;
               
               
               if ( null == _advancedSettings ) 
               {
                  throw new InvalidOperationException ( "Service has not been initialized. Call the Load method" ) ;
               }
               
               addInName       = typeof ( LoggingConfigurationSession ).Name ;
               loggingStateKey = typeof ( LoggingState ).Name ;
               
               if ( null == ( state = _advancedSettings.GetAddInCustomData <LoggingState> (  addInName, loggingStateKey ) ) )
               {
                  state =  new LoggingState ( ) ;
               }
               
               return state ;
            }
            
            public void SetLoggingState ( LoggingState state )
            {
               string addInKeyName ;
               string loggingStateKey ;
               
               
               if ( null == _advancedSettings) 
               {
                  throw new InvalidOperationException ( "Service has not been initialized. Call the Load method" ) ;
               }
               
               addInKeyName    = typeof ( LoggingConfigurationSession ) .Name ;
               loggingStateKey = typeof ( LoggingState ).Name ;
               
               _advancedSettings.SetAddInCustomData <LoggingState> ( addInKeyName, loggingStateKey, state ) ;
            }
            
         #endregion
         
         #region Properties
         
            public bool IsLoaded
            {
               get
               {
                  return _advancedSettings != null ;
               }
            }
            
         #endregion
         
         #region Data Types Definition
            
         #endregion
         
         #region Callbacks
         
            public event EventHandler SettingsUpdated ;
            
         #endregion
         
      #endregion
      
      #region Protected
         
         #region Methods
         
             protected virtual void Dispose ( bool disposing )
             {
                 if ( disposing ) 
                 {
                     // free managed resources
                     if ( null != _settingsChangedNotify )
                     {
                         _settingsChangedNotify.Dispose ( ) ;
                         
                         _settingsChangedNotify = null;
                     }
                 }
             }
            
         #endregion
         
         #region Properties
            
         #endregion
         
         #region Data Types Definition
            
         #endregion
         
      #endregion
      
      #region Private
         
         #region Methods
            
         #endregion
         
         #region Properties
            
         #endregion
         
         #region Events
         
            private void notifier_SettingsChanged ( object sender, EventArgs e )
            {
               try
               {
                  if ( IsLoaded )
                  {
                     if ( AutoRefresh ) 
                     {
                        _advancedSettings.RefreshSettings ( ) ;
                     }
                     
                     _loggingState = GetLoggingStateInternal ( ) ;
                     
                     if ( null != SettingsUpdated ) 
                     {
                        SettingsUpdated ( this, EventArgs.Empty ) ;
                     }
                  }
               }
               catch ( Exception exception ) 
               {
                  System.Diagnostics.Debug.Assert ( false, exception.Message ) ;
               }
            }
         
         #endregion
         
         #region Data Members
         
            private AdvancedSettings _advancedSettings ;
            private SettingsChangedNotifier _settingsChangedNotify ;
            private LoggingState     _loggingState ;
            
         #endregion
         
         #region Data Types Definition
            
         #endregion
         
      #endregion
      
      #region internal
         
         #region Methods
            
         #endregion
         
         #region Properties
            
         #endregion
         
         #region Data Types Definition
            
         #endregion
         
         #region Callbacks
            
         #endregion
         
      #endregion
   }
}
