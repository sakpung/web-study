// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Medical.PermissionsManagement.DataAccessLayer;
using Leadtools.Medical.DataAccessLayer;
using Leadtools.Medical.Winforms;
using Leadtools.Medical.OptionsDataAccessLayer;
using System.Runtime.Serialization;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;

namespace Leadtools.Medical.Winforms
{
   public class StorageClassesPresenter
{
      public StorageClassesPresenter()
      {
         _controlType = StorageClassesControlType.StorageClasses;
      }

      public StorageClassesPresenter(StorageClassesControlType controlType)
      {
         _controlType = controlType;
      }
      
      public event EventHandler SettingsChanged;
      

      void _view_SettingsChanged(object sender, EventArgs e)
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

      private StorageClassesTabControl _view;

      public StorageClassesTabControl View
      {
         get { return _view; }
         set { _view = value; }
      }
      private IOptionsDataAccessAgent _optionsAgent ;
      private PresentationContextList _settings = null;
      private string _settingsKeyName = typeof(PresentationContextList).Name;
      private string _settingsKeyNameTransferSytax = typeof(TransferSyntaxList).Name;
      private StorageClassesControlType _controlType = StorageClassesControlType.StorageClasses;
      
      public StorageClassesControlType ControlType
      {
         get { return _controlType; }
         set { _controlType = value; }
      }

      public void RunView ( StorageClassesTabControl view ) 
      {
         _view = view;

         _settings = LoadSettings ( ) ;

         view.PresentationContextList = Clone ( _settings ) ;
         _view.Initialize();
         _view.SettingsChanged += new EventHandler(_view_SettingsChanged);
      }

      public bool IsOptionsAgentRegistered()
      {
         return (null != _optionsAgent);
      }

      public PresentationContextList LoadSettings ( )
      {
         PresentationContextList list ;
         
         
         if ( null == _optionsAgent ) 
         {
            _optionsAgent = GetOptionsDataAccessAgent ( );
         }
         
         if (null != _optionsAgent && _optionsAgent.OptionExits(_settingsKeyName))
         {
            list = _optionsAgent.Get<PresentationContextList>(_settingsKeyName, null, new Type[0]);
         }
         else
         {
            list = new PresentationContextList();
            list.Default();
            
            if ( null != _optionsAgent ) 
            {
               _optionsAgent.Set <PresentationContextList> ( _settingsKeyName, list, new Type[0] ) ;
            }
         }
         
         return list ;
      }

      private IOptionsDataAccessAgent GetOptionsDataAccessAgent()
      {
         if (!DataAccessServices.IsDataAccessServiceRegistered<IOptionsDataAccessAgent>())
         {
            // Here need to check if OptionsAgent is registered in GlobalPacsConfig or machine.config
            // If not, just return
            // throw new InvalidOperationException(typeof(IOptionsDataAccessAgent).Name + " is not registered.");
            return null;
         }

         return DataAccessServices.GetDataAccessService<IOptionsDataAccessAgent>();
      }
      
      public bool IsDirty
      {
         get
         {
            return _view.IsDirty ;
         }
      }

      public void UpdateSettings ( )
      {
         if (_optionsAgent == null)
         {
            _optionsAgent = GetOptionsDataAccessAgent();
         }

         // If _optionsAgent is still null, then the optionsAgent is not registered
         // This can happen occur with older installation of v17.5, when the optionsAgent did not exist
         if (_optionsAgent == null)
         {
            return;
         }

         if (_settings.Equals(_view.PresentationContextList))
            return;

         if ( _view.IsDirty )
         {
            _settings = Clone(_view.PresentationContextList);

            _optionsAgent.Set<PresentationContextList>(_settingsKeyName, _settings, new Type[0]);
            
            _view.ChangesCommited ( ) ;
         }
      }

      public void ResetSettings()
      {
         _view.PresentationContextList = Clone(_settings);
         _view.Reset();
      }

      private PresentationContextList Clone(PresentationContextList options)
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

            AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(CurrentDomain_AssemblyResolve);

            IFormatter formatter = new BinaryFormatter();
            Stream stream = new MemoryStream();

            using (stream)
            {
               formatter.Serialize(stream, options);
               stream.Seek(0, SeekOrigin.Begin);

               return (PresentationContextList)formatter.Deserialize(stream);
            }
         }
         finally
         {
            AppDomain.CurrentDomain.AssemblyResolve -= CurrentDomain_AssemblyResolve;
         }
      }

      Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
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
   }
}
