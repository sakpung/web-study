// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using Leadtools.Dicom.AddIn;
using Leadtools.Dicom.AddIn.Configuration;
using Leadtools.Dicom.AddIn.Interfaces;
using Leadtools.Logging;
using Leadtools.Medical.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Leadtools.Medical.Winforms.SecurityOptions
{
   public class SecurityOptionsPresenter
   {
      private static string _addinName = "DicomSecurity";
      private static string _customDataName = "DicomSecurityOptions";

      DicomSecurityOptions _options;
      SecurityOptionsView _view;
      AdvancedSettings _settings;
      private IDicomSecurity _dicomSecurityAgent = null;

      public static string AddinName
      {
         get
         {
            return _addinName;
         }
      }

      public static string CustomDataName
      {
         get
         {
            return _customDataName;
         }
      }


      public bool IsDirty
      {
         get
         {
            DicomSecurityOptions tempOptions = _view.UpdateSettings();
            bool isEqual = DicomSecurityOptions.IsEqual(tempOptions, _options);
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
         OnWriteSecurityOptions(_view.Options);
         _options = _view.Options.Clone<DicomSecurityOptions>();
      }

      public delegate DicomSecurityOptions ReadSecurityOptionsDelegate();
      public event ReadSecurityOptionsDelegate ReadSecurityOptionsEvent = null;

      public delegate void WriteSecurityOptionsDelegate(DicomSecurityOptions options);
      public event WriteSecurityOptionsDelegate WriteSecurityOptionsEvent = null;


      private DicomSecurityOptions DefaultReadSecurityOptions()
      {
         DicomSecurityOptions options = null;
         if (_settings != null)
            options = _settings.GetAddInCustomData<DicomSecurityOptions>(_addinName, _customDataName);
         return options;
      }

      private void DefaultWriteSecurityOptions(DicomSecurityOptions securityOptions)
      {
         if (_settings != null)
         {
            _settings.SetAddInCustomData<DicomSecurityOptions>(_addinName, _customDataName, securityOptions);
            try
            {
               _settings.Save();
            }
            catch (Exception)
            {
            }
         }
      }

      private DicomSecurityOptions OnReadSecurityOptions()
      {
         if (ReadSecurityOptionsEvent == null)
         {
            return DefaultReadSecurityOptions();
         }
         else
         {
            return ReadSecurityOptionsEvent();
         }
      }

      private void OnWriteSecurityOptions(DicomSecurityOptions options)
      {
         if (WriteSecurityOptionsEvent == null)
         {
            DefaultWriteSecurityOptions(options);
         }
         else
         {
            WriteSecurityOptionsEvent(options);
         }
      }

      public void RunView(SecurityOptionsView view)
      {
         RunView(view, null);
      }

      public void RunView(SecurityOptionsView view, AdvancedSettings settings)
      {
         DicomSecurityOptions clonedOptions;

         _view = view;
         _settings = settings;

         if (ServiceLocator.IsRegistered<IDicomSecurity>())
         {
            _dicomSecurityAgent = ServiceLocator.Retrieve<IDicomSecurity>();
         }

         try
         {
            _options = OnReadSecurityOptions();
            if (_options == null)
            {
               _options = new DicomSecurityOptions();
               OnWriteSecurityOptions(_options);
            }
         }
         catch (Exception e)
         {
            Logger.Global.Exception("DICOM Security", e);
            if (_options == null)
               _options = new DicomSecurityOptions();
         }

         clonedOptions = _options.Clone<DicomSecurityOptions>();
         _view.Initialize(clonedOptions);
         _view.Enabled = true;

         _view.SettingsChanged += new EventHandler(View_SettingsChanged);

      }
   }
}
