// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using Leadtools.Dicom.AddIn.Configuration;
using Leadtools.Logging;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Leadtools.Medical.Storage.AddIns.Controls.StorageCommit
{
   public class StorageCommitPresenter
   {
      private StorageCommitView _view;
      private AdvancedSettings _settings;
      private StorageCommitOptions _options;
      private const string _storageCommitOptionsName = @"StorageCommitOptions";
      private const string _name = @"Leadtools.Medical.Storage.AddIns";

      private static StorageCommitOptions Clone(StorageCommitOptions options)
      {
         //
         // Don't serialize a null object, simply return the default for that object
         //
         if (ReferenceEquals(options, null))
         {
            return null;
         }

         if (!options.GetType().IsSerializable)
         {
            throw new ArgumentException(@"The type must be serializable.", @"options");
         }

         IFormatter formatter = new BinaryFormatter();
         Stream stream = new MemoryStream();

         using (stream)
         {
            formatter.Serialize(stream, options);
            stream.Seek(0, SeekOrigin.Begin);

            return (StorageCommitOptions)formatter.Deserialize(stream);
         }
      }

      public bool IsDirty
      {
         get
         {
            StorageCommitOptions tempOptions = _view.UpdateSettings();
            bool isEqual = StorageCommitOptions.IsEqual(tempOptions, _options);
            return !isEqual;
         }
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

      public void SaveOptions()
      {
         _view.UpdateSettings();
         if (_settings != null)
         {
            _settings.SetAddInCustomData<StorageCommitOptions>(_name, _storageCommitOptionsName, _view.Options);

            try
            {
               _settings.Save();
            }
            catch (Exception)
            {
            }
         }
         _options = Clone(_view.Options);
      }

      public void RunView(StorageCommitView storageCommitView, AdvancedSettings settings)
      {
         _view = storageCommitView;
         _settings = settings;

         if (settings != null)
         {
            try
            {
               _options = _settings.GetAddInCustomData<StorageCommitOptions>(_name, _storageCommitOptionsName);
               if (_options == null)
               {
                  _options = new StorageCommitOptions();
                  
                  _settings.SetAddInCustomData<StorageCommitOptions>(_name, _storageCommitOptionsName, _options);
                  _settings.Save();
               }
            }
            catch (Exception e)
            {
               Logger.Global.Exception(_storageCommitOptionsName, e);
               if (_options == null)
                  _options = new StorageCommitOptions();
            }

            StorageCommitOptions tempOptions = Clone(_options);

            _view.Initialize(tempOptions);
            // _view.Enabled = false;
         }

         _view.SettingsChanged += new EventHandler(View_SettingsChanged);
      }

   }
}
