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
using Leadtools.Medical.Winforms.Forwarder;
using Leadtools.Medical.DataAccessLayer;
using Leadtools.Medical.AeManagement.DataAccessLayer;
using Leadtools.Medical.AeManagement.DataAccessLayer.Configuration;
using Leadtools.DicomDemos;

namespace Leadtools.Medical.Forwarder.AddIn.Dialogs
{
   public class ForwardConfiguration : IConfigureDialog
   {
      private AdvancedSettings _AdvancedSettings = null;
      private ServerSettings _Settings = null;
      private IAeManagementDataAccessAgent _AccessAgent = null;
      private ForwardManagerPresenter _Presenter = null;
      private ConfigureDialog _ConfigureDialog;

      #region IConfigureDialog Members

      public void Close()
      {
         throw new NotImplementedException();
      }

      public void Initialize(AdvancedSettings advancedSettings, ServerSettings Settings, string ServerDirectory)
      {
         _AdvancedSettings = advancedSettings;
         _Settings = Settings;

         if (!DataAccessServices.IsDataAccessServiceRegistered<IAeManagementDataAccessAgent>())
         {
            _AccessAgent = DataAccessFactory.GetInstance(new AeManagementDataAccessConfigurationView(DicomDemoSettingsManager.GetGlobalPacsAddinsConfiguration(ServerDirectory), null, Settings.ServiceName)).CreateDataAccessAgent<IAeManagementDataAccessAgent>();

            DataAccessServices.RegisterDataAccessService<IAeManagementDataAccessAgent>(_AccessAgent);
         }

         _ConfigureDialog = new ConfigureDialog();
         _Presenter = new ForwardManagerPresenter();
         _Presenter.RunView(_ConfigureDialog.View, _AdvancedSettings);
      }

      public void Show(System.Windows.Forms.IWin32Window Owner)
      {         
      }

      public void Show()
      {       
      }

      public void ShowDialog(System.Windows.Forms.IWin32Window Owner)
      {
         if (_ConfigureDialog.ShowDialog(Owner) == DialogResult.OK)
         {
            try
            {
               _Presenter.SaveOptions();
            }
            catch (Exception e)
            {
               Logger.Global.Exception(Module.Source, e);
            }
         }
         else
         {
            _Presenter.CancelOptions();
         }
      }

      public void ShowDialog()
      {
         ShowDialog(null);
      }

      #endregion
   }
}
