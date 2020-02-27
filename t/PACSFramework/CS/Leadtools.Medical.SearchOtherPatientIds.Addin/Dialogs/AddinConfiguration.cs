// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using Leadtools.Dicom.AddIn.Interfaces;
using System.Windows.Forms;
using Leadtools.Dicom.AddIn.Configuration;
using Leadtools.Dicom.AddIn.Common;
using Leadtools.Medical.SearchOtherPatientId.Addin.Common;
using Leadtools.Logging;

namespace Leadtools.Medical.SearchOtherPatientId.Addin.Dialogs
{
   public class AddinConfiguration : IConfigureDialog
   {

      private AdvancedSettings _AdvancedSettings;
      private ConfigureDialog _optionsDialog;

      public AddinConfiguration()
      {
         _optionsDialog = null;
         _AdvancedSettings = null;
      }

      #region IConfigureDialog Members

      public void Close()
      {
         // do nothing
      }

      public void Initialize(AdvancedSettings advancedSettings, ServerSettings settings, string serverDirectory)
      {
         Module.ServiceName = settings.ServiceName;
         Module.ServiceDirectory = serverDirectory;

         _AdvancedSettings = advancedSettings;

         try
         {
            if (settings != null)
            {
               Module.ServiceName = settings.ServiceName;
            }
            Module.ServiceDirectory = serverDirectory;

            _optionsDialog = new ConfigureDialog();
            _optionsDialog.FormClosing += new FormClosingEventHandler(_dlgConfigure_FormClosing);
         }
         catch (Exception e)
         {
            Logger.Global.Exception(Module.Source, e);
         }
      }

      static void _dlgConfigure_FormClosing(object sender, FormClosingEventArgs e)
      {
         // do nothing
      }

      public void Show(IWin32Window Owner)
      {
         // do nothing
      }

      public void Show()
      {
         // do nothing
      }

      public void ShowDialog(IWin32Window Owner)
      {
         FindOtherPatientIdsOptions options = Module.GetFindOtherPatientIdOptions(_AdvancedSettings);

         if (options != null)
         {
            _optionsDialog.UseOtherPatientId = options.SearchOtherPatientId;
            if (_optionsDialog.ShowDialog(Owner) == DialogResult.OK)
            {
               try
               {
                  options.SearchOtherPatientId = _optionsDialog.UseOtherPatientId;
                  _AdvancedSettings.RefreshSettings();
                  _AdvancedSettings.SetAddInCustomData<FindOtherPatientIdsOptions>(Module.Source, Module.OptionsName, options);
                  _AdvancedSettings.Save();
               }
               catch (Exception e)
               {
                  Logger.Global.SystemMessage(LogType.Error, e.Message);
               }
            }
         }
      }


      public void ShowDialog()
      {
         ShowDialog(null);
      }

      #endregion
   }
}
