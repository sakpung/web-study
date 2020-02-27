// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************

using Leadtools.Dicom.AddIn.Common;
using Leadtools.Dicom.AddIn.Configuration;
using Leadtools.Dicom.AddIn.Interfaces;
using Leadtools.Logging;
using Leadtools.Medical.PatientRestrict.AddIn.Common;
using Leadtools.Medical.WebViewer.PatientAccessRights;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Leadtools.Medical.PatientRestrict.AddIn.Dialogs
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

      public bool UpdateOptions(bool refresh)
      {
         PatientRestrictOptions options = new PatientRestrictOptions();
         options.PageSize = _optionsDialog.PageSize;
         options.PatientRestrictEnabled = _optionsDialog.PatientRestrictEnabled;

         List<AeAccessKey> aeRoleListNew = _optionsDialog.aeRoleList;

         // Save AdvancedSettings settings;
         _AdvancedSettings.RefreshSettings();
         _AdvancedSettings.SetAddInCustomData<PatientRestrictOptions>(Module.Source, Module.OptionsName, options);
         _AdvancedSettings.Save();

         // Save Database Settings
         List<AeAccessKey> aeRoleListOriginal = Module.PatientRightsDataAccess.GetAllAeRoleRecords();

         // We want to remove all items from each list that are IN BOTH LISTS
         // After this:
         //    aeRoleListOriginal will contain elements to be deleted 
         //    aeRoleListNew      will contain elements to be added
         for (int i = aeRoleListNew.Count - 1; i >= 0; i--)
         {
            AeAccessKey value = aeRoleListNew[i];
            int countRemoved = aeRoleListOriginal.MyRemoveAll(value);

            if (countRemoved > 0)
            {
               aeRoleListNew.RemoveAt(i);
            }
         }

         int deletedCount = aeRoleListOriginal.Count;
         int addedCount = aeRoleListNew.Count;

         // aeRoleListOriginal now contains elements to be deleted
         foreach (AeAccessKey value in aeRoleListOriginal)
         {
            Module.PatientRightsDataAccess.DeleteAeRole(value.AeTitle, value.AccessKey);
         }

         // aeRoleListNew now contains elements to be added
         foreach (AeAccessKey value in aeRoleListNew)
         {
            Module.PatientRightsDataAccess.AddAeRole(value.AeTitle, value.AccessKey);
         }

         if ((addedCount != 0) || (deletedCount != 0))
         {
            string message = string.Format("Records Added: {0}\r\nRecords Deleted: {1}", addedCount, deletedCount);
            MessageBox.Show(message, "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
         }

         if (refresh)
         {
            aeRoleListNew = Module.PatientRightsDataAccess.GetAllAeRoleRecords();
            _optionsDialog.aeRoleList = aeRoleListNew;
         }

         return true;
      }

      public void ShowDialog(IWin32Window Owner)
      {

         List<AeAccessKey> aeRoleListNew =  Module.PatientRightsDataAccess.GetAllAeRoleRecords();
         _optionsDialog.aeRoleList = aeRoleListNew;

         PatientRestrictOptions options = Module.GetPatientRestrictOptions(_AdvancedSettings);
         _optionsDialog.PageSize = options.PageSize;
         _optionsDialog.PatientRestrictEnabled = options.PatientRestrictEnabled;
         _optionsDialog.ApplyOptionsMethod = UpdateOptions;

         {
            if (_optionsDialog.ShowDialog(Owner) == DialogResult.OK)
            {
               try
               {
                  UpdateOptions(false);

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
