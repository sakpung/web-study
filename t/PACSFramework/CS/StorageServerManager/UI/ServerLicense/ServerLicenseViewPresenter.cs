// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Medical.Winforms.LicenseManager;
using Leadtools.Dicom.AddIn;
using System.Windows.Forms;
using System.IO;
using Leadtools.DicomDemos;
using Leadtools.Demos.StorageServer.DataTypes;
using Leadtools.Demos.StorageServer.UI.AdministrativeSettings.Users;

namespace Leadtools.Demos.StorageServer.UI.ServerLicense
{
   public class ServerLicenseViewPresenter
   {
      private LicenseView _View;

      public void RunView(LicenseView view)
      {
         ServerState.Instance.ServerServiceChanged += new EventHandler(OnConfigureView);
         ServerState.Instance.ServiceAdminChanged += new EventHandler(OnConfigureView);
         ServerState.Instance.IsRemoteServerChanged += new EventHandler(OnConfigureView);

         _View = view;
         if (ServerState.Instance.License!=null)
         {
            _View.SetLicense(ServerState.Instance.ServerService.Settings.LicenseFile,
                             ServerState.Instance.License);
         }
         SetHardwareCodes();
         ConfigureView();
         _View.OpenLicense += new EventHandler<OpenLicenseEventArgs>(OnOpenLicense);
         _View.RemoveLicense += new EventHandler<EventArgs>(OnRemoveLicense);
      }

      public void SetHardwareCodes()
      {
         List<string> codes = new List<string>();

         codes.Add(new MachineIDMash(true,false,false).Id);
         codes.Add(new MachineIDMash(false, false, true).Id);
         codes.Add(new MachineIDMash(false, true, false).Id);
         _View.SetHardwareCodes(codes.ToArray());
      }

      void OnOpenLicense(object sender, OpenLicenseEventArgs e)
      {
         try
         {
            if (ServerState.Instance.License != null)
            {
               ServerState.Instance.License.Load(e.FileName);
               if (ServerState.Instance.License.IsValid())
               {
                  ServerState.Instance.ServerService.Settings.LicenseFile = e.FileName;
                  ServerState.Instance.ServerService.Settings = ServerState.Instance.ServerService.Settings;
                  _View.SetLicense(e.FileName, ServerState.Instance.License);
                  ServerState.Instance.OnLicenseChanged();
               }
               else
               {
                  Messager.ShowError(Application.OpenForms[0], "Invalid License File: " + e.FileName);
               }
            }
         }
         catch (Exception exception)
         {
            Messager.ShowError(Application.OpenForms[0], exception);
         }
      }
      
      void OnRemoveLicense(object sender, EventArgs e)
      {
         OpenLicenseEventArgs args = new OpenLicenseEventArgs(string.Empty);
         OnOpenLicense(sender, args);
      }

      private void ConfigureView()
      {
         _View.Enabled = ServerState.Instance.ServerService != null && UserManager.User.IsAdmin();
         if (_View.Enabled && ServerState.Instance.License != null)
         {
            _View.SetLicense(ServerState.Instance.ServerService.Settings.LicenseFile, ServerState.Instance.License);
         }
         else
         {
            _View.Clear();
         }
      }

      void OnConfigureView(object sender, EventArgs e)
      {
         ConfigureView();
      }
   }
}
