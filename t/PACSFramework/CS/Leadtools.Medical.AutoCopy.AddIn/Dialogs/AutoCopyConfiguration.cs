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
using Leadtools.Medical.AeManagement.DataAccessLayer;
using Leadtools.Medical.DataAccessLayer;
using Leadtools.Medical.AeManagement.DataAccessLayer.Configuration;
using Leadtools.Medical.Winforms;
using Leadtools.DicomDemos;

namespace Leadtools.Medical.AutoCopy.AddIn.Dialogs
{
   public class AutoCopyConfiguration : IConfigureDialog
   {
      private AdvancedSettings _AdvancedSettings = null;
      private ServerSettings _Settings = null;
      private ConfigureDialog _autoCopyDlg = null;
      private AutoCopyPresenter _autoCopyPresenter = null;

      #region IConfigureDialog Members

      public void Close()
      {
         throw new NotImplementedException();
      }

      public void Initialize(AdvancedSettings advancedSettings, ServerSettings Settings, string ServerDirectory)
      {         
         _AdvancedSettings = advancedSettings;
         _Settings = Settings;
         
         if (Settings != null)
            Module.ServiceName = Settings.ServiceName;
         
         try
         {            
            IAeManagementDataAccessAgent aeManagementAgent ;

            if (!DataAccessServices.IsDataAccessServiceRegistered<IAeManagementDataAccessAgent>())
            {
               aeManagementAgent = DataAccessFactory.GetInstance(new AeManagementDataAccessConfigurationView(DicomDemoSettingsManager.GetGlobalPacsAddinsConfiguration(ServerDirectory), null, Settings.ServiceName)).CreateDataAccessAgent<IAeManagementDataAccessAgent>();

               DataAccessServices.RegisterDataAccessService<IAeManagementDataAccessAgent>(aeManagementAgent);
            }
            else
               aeManagementAgent = DataAccessServices.GetDataAccessService<IAeManagementDataAccessAgent>();
         
            
            _autoCopyDlg = new ConfigureDialog ( ) ;
            _autoCopyPresenter = new AutoCopyPresenter ( ) ;

            _autoCopyPresenter.RunView(_autoCopyDlg.AutoCopyView, advancedSettings);
         }
         catch (Exception e)
         {
            Logger.Global.Exception(Module.Source, e);
         }
      }

      public void Show(System.Windows.Forms.IWin32Window Owner)
      {         
      }

      public void Show()
      {       
      }

      public void ShowDialog(System.Windows.Forms.IWin32Window Owner)
      {
         if ( null != _autoCopyDlg && null != _autoCopyPresenter )
         {
            if (_autoCopyDlg.ShowDialog(Owner) == DialogResult.OK)
            {
               try
               {
                  _autoCopyPresenter.SaveOptions ( ) ;
               }
               catch (Exception e)
               {
                  Logger.Global.Exception(Module.Source, e);
               }
            }
            else
            {
               _autoCopyPresenter.CancelOptions ( ) ;
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
