// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Dicom.AddIn.Interfaces;
using Leadtools.Dicom.AddIn.Configuration;
using Leadtools.Dicom.AddIn.Common;
using Leadtools.Dicom.Common.DataTypes.PatientUpdater;
using System.Reflection;
using System.Windows.Forms;
using Leadtools.Logging;
using Leadtools.Dicom.Scp.Command.NAction.PatientUpdater;
using System.IO;
using Leadtools.Medical.DataAccessLayer;
using Leadtools.Medical.AeManagement.DataAccessLayer;
using Leadtools.Medical.AeManagement.DataAccessLayer.Configuration;
using Leadtools.Medical.OptionsDataAccessLayer;
using Leadtools.Medical.OptionsDataAccessLayer.Configuration;
using Leadtools.Medical.Winforms;
using Leadtools.DicomDemos;

namespace Leadtools.Medical.PatientUpdater.AddIn.Dialogs
{
   public class PatientUpdaterConfiguration : IConfigureDialog
   {
      private AdvancedSettings _AdvancedSettings = null;
      private ServerSettings _Settings = null;
      private ConfigureDialog _patientUpdaterDlg = null;
      private PatientUpdaterPresenter _patientUpdaterPresenter = null;

      #region IConfigureDialog Members

      public void Close()
      {         
      }

      public void Initialize(AdvancedSettings advancedSettings, ServerSettings Settings, string ServerDirectory)
      {
         _AdvancedSettings = advancedSettings;
         _Settings = Settings;

         try
         {
            IOptionsDataAccessAgent      optionsAgent ;
            IAeManagementDataAccessAgent aeManagementAgent ;
            
            
            if ( !DataAccessServices.IsDataAccessServiceRegistered <IOptionsDataAccessAgent> ( ) )
            {
               optionsAgent = DataAccessFactory.GetInstance(new OptionsDataAccessConfigurationView(DicomDemoSettingsManager.GetGlobalPacsAddinsConfiguration(ServerDirectory), null, Settings.ServiceName)).CreateDataAccessAgent<IOptionsDataAccessAgent>();
         
               DataAccessServices.RegisterDataAccessService<IOptionsDataAccessAgent>(optionsAgent);
            }
            
            if ( !DataAccessServices.IsDataAccessServiceRegistered<IAeManagementDataAccessAgent> ( ) )
            {
               aeManagementAgent = DataAccessFactory.GetInstance(new AeManagementDataAccessConfigurationView(DicomDemoSettingsManager.GetGlobalPacsAddinsConfiguration(ServerDirectory), null, Settings.ServiceName)).CreateDataAccessAgent<IAeManagementDataAccessAgent>();
         
               DataAccessServices.RegisterDataAccessService<IAeManagementDataAccessAgent>(aeManagementAgent);
            }
         

            _patientUpdaterDlg = new ConfigureDialog ( ) ;
            _patientUpdaterPresenter = new PatientUpdaterPresenter ( ) ;
            
            _patientUpdaterPresenter.RunView ( _patientUpdaterDlg.PatientUpdaterConfigurationView, ServerDirectory ) ;
         }
         catch (Exception e)
         {
            Logger.Global.Exception(Module.Source, e);
         }
      }

      public void Show(IWin32Window Owner)
      {           
      }

      public void Show()
      {         
      }

      public void ShowDialog(IWin32Window Owner)
      {
         if ( null != _patientUpdaterDlg && null != _patientUpdaterPresenter )
         {
            if (_patientUpdaterDlg.ShowDialog(Owner) == DialogResult.OK)
            {
               try
               {
                  _patientUpdaterPresenter.SaveOptions ( ) ;
               }
               catch (Exception e)
               {
                  Logger.Global.Exception(Module.Source, e);
               }
            }
            else
            {
               _patientUpdaterPresenter.CancelOptions ( ) ;
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
