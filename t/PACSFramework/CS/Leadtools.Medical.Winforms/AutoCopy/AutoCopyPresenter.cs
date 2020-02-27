// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Dicom.AddIn.Configuration;
using Leadtools.Dicom.AddIn.Common;
using Leadtools.Dicom.AddIn.Interfaces;
using Leadtools.Logging;
using System.Windows.Forms;
using System.Reflection;
using Leadtools.Medical.DataAccessLayer;
using Leadtools.Medical.OptionsDataAccessLayer;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using Leadtools.Medical.AeManagement.DataAccessLayer;

namespace Leadtools.Medical.Winforms
{
   public class AutoCopyPresenter
   {
      private AutoCopyOptions _Options;
      private AdvancedSettings _Settings;
      public const int AUTOCOPY_RELATION = 914;

      private AutoCopyView _view;

      public AutoCopyView View
      {
         get { return _view; }
         set { _view = value; }
      }

      private IAeManagementDataAccessAgent _aeAccessAgent;

      string _optionsKeyName = typeof(AutoCopyOptions).Name;

      public void RunView(AutoCopyView view, AdvancedSettings settings)
      {
         AutoCopyOptions clonedOptions ;
         
         _view = view ;
         _Settings = settings;
         
         
         if ( !DataAccessServices.IsDataAccessServiceRegistered<IAeManagementDataAccessAgent> ( ) )
         {
            throw new InvalidOperationException ( typeof ( IAeManagementDataAccessAgent ).Name + " is not registered." ) ;
         }
         
         _aeAccessAgent = DataAccessServices.GetDataAccessService<IAeManagementDataAccessAgent> ( ) ;

         if (settings != null)
         {
            try
            {
               _Options = _Settings.GetAddInCustomData<AutoCopyOptions>("Auto Copy", "AutoCopyOptions");
               if (_Options == null)
               {
                  _Options = new AutoCopyOptions();
                  _Settings.SetAddInCustomData<AutoCopyOptions>("Auto Copy", "AutoCopyOptions", _Options);
                  _Settings.Save();
               }
            }
            catch (Exception e)
            {
               Logger.Global.Exception("Auto Copy", e);
               if (_Options == null)
                  _Options = new AutoCopyOptions();
            }

            clonedOptions = Clone(_Options);            
            view.Initialize(clonedOptions, AUTOCOPY_RELATION, _aeAccessAgent);
            _view.SettingsChanged += new EventHandler(View_SettingsChanged);
         }

         EventBroker.Instance.Subscribe<ClientAddedEventArgs>(new EventHandler<ClientAddedEventArgs>(OnClientAdded));
         EventBroker.Instance.Subscribe<ClientRemovedEventArgs>(new EventHandler<ClientRemovedEventArgs>(OnClientRemoved));         
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

      public void UpdateSettings(AdvancedSettings settings)
      {
         AutoCopyOptions clonedOptions;

         _Settings = settings;

         try
         {
            _Options = _Settings.GetAddInCustomData<AutoCopyOptions>("Auto Copy", "AutoCopyOptions");
            if (_Options == null)
            {
               _Options = new AutoCopyOptions();
               _Settings.SetAddInCustomData<AutoCopyOptions>("Auto Copy", "AutoCopyOptions", _Options);
               _Settings.Save();
            }
         }
         catch (Exception e)
         {
            Logger.Global.Exception("Auto Copy", e);
            if (_Options == null)
               _Options = new AutoCopyOptions();
         }

         clonedOptions = Clone(_Options);
         _view.Initialize(clonedOptions, AUTOCOPY_RELATION, _aeAccessAgent);
      }

      public void SaveOptions ( ) 
      {
         _view.UpdateOptions ( ) ;

         if (_Settings != null)
         {
            _Settings.SetAddInCustomData<AutoCopyOptions>("Auto Copy", "AutoCopyOptions", _view.Options);
            _Settings.Save();
         }
         _Options = _view.Options;
      }
      
      public void CancelOptions ( ) 
      {
         _view.Initialize ( Clone ( _Options ), AUTOCOPY_RELATION, _aeAccessAgent ) ;
      }
      
      public AutoCopyOptions Clone ( AutoCopyOptions options )
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

               return (AutoCopyOptions)formatter.Deserialize(stream);
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
         if (_Settings != null)
         {
            _view.AddAeTitle(e.NewClient);
         }
      }

      private void OnClientRemoved(object sender, ClientRemovedEventArgs e)
      {
         if (_Settings != null)
         {
            _view.RemoveAeTitle(e.Ae);
         }
      }               
   }
}
