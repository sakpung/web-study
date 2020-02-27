// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.DicomDemos;
using Leadtools.Demos;
using System.Net;
using DicomDemo.Dicom;
using Leadtools.Dicom;
using Leadtools.Dicom.Scu.Common;

namespace DicomDemo
{
   public partial class MainForm
   {
      private void LoadSettings()
      {
         try
         {
            // Settings are stored at:
            // %USERPROFILE%\Local Settings\Application Data\<Company Name>\<appdomainname>_<eid>_<hash>\<verison>\user.config

            _mySettings = null;

            try
            {
               _mySettings = DicomDemoSettingsManager.LoadSettings(_demoName);
               if (_mySettings == null)
               {
                  DicomDemoSettingsManager.RunPacsConfigDemo();
                  _mySettings = DicomDemoSettingsManager.LoadSettings(_demoName);
               }
            }
            catch (Exception)
            {
            }
            if (_mySettings == null)
            {
               _mySettings = DefaultSettings();
            }
            else
            {
               // found settings -- set any necessary defaults 
               if ((_mySettings.FirstRun && _mySettings.IsPreconfigured))
               {
                  SetOtherDefaults(_mySettings);
               }
            }

            // SetDefaultQueryServer();
            _mySettings.FirstRun = false;
            DicomDemoSettingsManager.SaveSettings(_demoName, _mySettings);
         }
         catch (Exception ex)
         {
            System.Diagnostics.Debug.Assert(false, ex.Message);
         }
      }

      private void About()
      {
         AboutDialog dlg = new AboutDialog("DICOM High Level Patient Updater");

         dlg.ShowDialog(this);
      }

      partial void DoOptions()
      {
         OptionsDialog dlgOptions = new OptionsDialog();

         DicomAE scp = _mySettings.GetServer(_mySettings.HighLevelStorageServer);
         if (scp == null)
            return;

         dlgOptions.ServerAE = scp.AE;
         dlgOptions.ServerPort = scp.Port;
         dlgOptions.ServerIP = scp.IPAddress;
         dlgOptions.ClientAE = _mySettings.ClientAe.AE;
         dlgOptions.Timeout = scp.Timeout;
         if (dlgOptions.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
         {
            scp.AE = dlgOptions.ServerAE;
            scp.Port = dlgOptions.ServerPort;
            scp.IPAddress = dlgOptions.ServerIP;
            scp.Timeout = dlgOptions.Timeout;
            _mySettings.ClientAe.AE = dlgOptions.ClientAE;
            _mySettings.HighLevelStorageServer = dlgOptions.ServerAE;
            DicomDemoSettingsManager.SaveSettings(_demoName, _mySettings);
            CreateFind();
         }
      }

      partial void CreateFind()
      {
         if (_find != null)
         {
            _find.Dispose();
         }

#if !LEADTOOLS_V20_OR_LATER
         _find = new PatientUpdateQuery(_mySettings.TemporaryDirectory, DicomNetSecurityeMode.None, null);
#else
         _find = new PatientUpdateQuery(_mySettings.TemporaryDirectory, DicomNetSecurityMode.None, null);
#endif // #if !LEADTOOLS_V20_OR_LATER

         _find.ImplementationClass = _mySettings.ImplementationClass;
         _find.ProtocolVersion = _mySettings.ProtocolVersion;
         _find.ImplementationVersionName = _mySettings.ImplementationVersionName;
         _find.AETitle = _mySettings.ClientAe.AE;

         _find.BeforeConnect += new BeforeConnectDelegate(_find_BeforeConnect);
         _find.AfterConnect += new AfterConnectDelegate(_find_AfterConnect);
         _find.BeforeAssociateRequest += new BeforeAssociationRequestDelegate(_find_BeforeAssociateRequest);
         _find.AfterAssociateRequest += new AfterAssociateRequestDelegate(_find_AfterAssociateRequest);
         _find.BeforeCFind += new BeforeCFindDelegate(_find_BeforeCFind);
         _find.AfterCFind += new AfterCFindDelegate(_find_AfterCFind);

         CreateNAction();
      }

      partial void CreateNAction()
      {
         if (_naction != null)
         {
            _naction.Dispose();
         }


#if !LEADTOOLS_V20_OR_LATER
         _naction = new NActionScu(_mySettings.TemporaryDirectory, DicomNetSecurityeMode.None, null);
#else
         _naction = new NActionScu(_mySettings.TemporaryDirectory, DicomNetSecurityMode.None, null);
#endif // #if !LEADTOOLS_V20_OR_LATER

         _naction.ImplementationClass = _mySettings.ImplementationClass;
         _naction.ProtocolVersion = _mySettings.ProtocolVersion;
         _naction.ImplementationVersionName = _mySettings.ImplementationVersionName;
         _naction.AETitle = _mySettings.ClientAe.AE;

         _naction.BeforeConnect += new BeforeConnectDelegate(_find_BeforeConnect);
         _naction.AfterConnect += new AfterConnectDelegate(_find_AfterConnect);
         _naction.BeforeAssociateRequest += new BeforeAssociationRequestDelegate(_find_BeforeAssociateRequest);
         _naction.AfterAssociateRequest += new AfterAssociateRequestDelegate(_find_AfterAssociateRequest);
      }

      private DicomAE GetScp()
      {
         return _mySettings.GetServer(_mySettings.HighLevelStorageServer);
      }

      private void Initialize()
      {
         if (_mySettings != null)
         {
            DicomAE scp = GetScp();
            if (scp == null)
               return;

            if (!string.IsNullOrEmpty(scp.IPAddress))
            {
               IPAddress ip = IPAddress.None;

               if (IPAddress.TryParse(scp.IPAddress, out ip))
                  _server.PeerAddress = ip;
            }
            CreateFind();
         }
      }
   }
}
