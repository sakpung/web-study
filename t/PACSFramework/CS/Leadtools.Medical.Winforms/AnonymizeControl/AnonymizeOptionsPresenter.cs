// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Medical.OptionsDataAccessLayer;
using Leadtools.Medical.DataAccessLayer;
using System.Runtime.Serialization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Reflection;
using System.Xml.Serialization;
using Leadtools.Medical.Winforms.DatabaseManager.Export;

namespace Leadtools.Medical.Winforms.Anonymize
{
   public class AnonymizeOptionsPresenter
   {
      private IOptionsDataAccessAgent _optionsAgent;

      public const string AnonymizeOptionsKey = "AnonymizeOptions";

      private AnonymizeOptionsView _view;
      private AnonymizeScripts _settings;

      public AnonymizeOptionsPresenter()
      {
         EventBroker.Instance.Subscribe <SaveAnonymizeSettingsEventArgs>        ( OnSaveAnonymizeSettingsEventArgs ) ;
      }

      ~AnonymizeOptionsPresenter()
      {
         EventBroker.Instance.Unsubscribe <SaveAnonymizeSettingsEventArgs>        ( OnSaveAnonymizeSettingsEventArgs ) ;
      }

      private void  OnSaveAnonymizeSettingsEventArgs  ( object sender, SaveAnonymizeSettingsEventArgs e ) 
      {
         // UpdateSettings( ) ;
         _settings = Clone(e.Scripts);
         ResetSettings();
      }

      public AnonymizeOptionsView View
      {
         get { return _view; }
         set { _view = value; }
      }


      public AnonymizeScripts LoadSettings()
      {
         AnonymizeScripts scripts;


         if (null == _optionsAgent)
         {
            _optionsAgent = GetOptionsDataAccessAgent();
         }

         if (null != _optionsAgent && _optionsAgent.OptionExits(AnonymizeOptionsKey))
         {
            scripts = _optionsAgent.Get<AnonymizeScripts>(AnonymizeOptionsKey, null, new Type[0]);
         }
         else
         {
            scripts = new AnonymizeScripts(true);

            if (null != _optionsAgent)
            {
               _optionsAgent.Set<AnonymizeScripts>(AnonymizeOptionsKey, scripts, new Type[0]);
            }
         }

         return scripts;
      }

      private static AnonymizeScripts Clone(AnonymizeScripts options)
      {
         AnonymizeScripts clone = null;

         try
         {
            using (MemoryStream stream = new MemoryStream())
            {
               XmlSerializer s = new XmlSerializer(typeof(AnonymizeScripts));
               s.Serialize(stream, options);

               stream.Seek(0, SeekOrigin.Begin);
               clone = (AnonymizeScripts)s.Deserialize(stream);

            }
         }
         catch (Exception ex)
         {
            Console.WriteLine(ex.Message);
            // throw;
         }


         return clone;
         //try
         //{
         //   //
         //   // Don't serialize a null object, simply return the default for that object
         //   //
         //   if (Object.ReferenceEquals(options, null))
         //   {
         //      return null;
         //   }

         //   if (!options.GetType().IsSerializable)
         //   {
         //      throw new ArgumentException("The type must be serializable.", "source");
         //   }

         //   AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(CurrentDomain_AssemblyResolve);

         //   IFormatter formatter = new BinaryFormatter();
         //   Stream stream = new MemoryStream();

         //   using (stream)
         //   {
         //      formatter.Serialize(stream, options);
         //      stream.Seek(0, SeekOrigin.Begin);

         //      return (AnonymizeScripts)formatter.Deserialize(stream);
         //   }
         //}
         //finally
         //{
         //   AppDomain.CurrentDomain.AssemblyResolve -= CurrentDomain_AssemblyResolve;
         //}
      }

      //Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
      //{
      //   Assembly ayResult = null;
      //   string sShortAssemblyName = args.Name.Split(',')[0];
      //   Assembly[] ayAssemblies = AppDomain.CurrentDomain.GetAssemblies();

      //   foreach (Assembly ayAssembly in ayAssemblies)
      //   {
      //      if (sShortAssemblyName == ayAssembly.FullName.Split(',')[0])
      //      {
      //         ayResult = ayAssembly;
      //         break;
      //      }
      //   }
      //   return ayResult;
      //}

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

      public void RunView(AnonymizeOptionsView view)
      {
         _view = view;

         _settings = LoadSettings();

         view.AnonymizeScripts = Clone(_settings);
         // _view.Initialize();
         _view.SettingsChanged += new EventHandler(_view_SettingsChanged);
      }

      public event EventHandler SettingsChanged;
      private void _view_SettingsChanged(object sender, EventArgs e)
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

      public void ResetSettings()
      {
         _view.AnonymizeScripts = Clone(_settings);
         _view.Initialize();
      }

      public bool IsDirty
      {
         get
         {
            return _view.IsDirty;
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

         if (_settings.Equals(_view))
            return;

         if ( _view.IsDirty )
         {
            _settings = Clone(_view.AnonymizeScripts);

            _optionsAgent.Set<AnonymizeScripts>(AnonymizeOptionsKey, _settings, new Type[0]);
            
            _view.ChangesCommited ( ) ;
         }
      }
   }





}
