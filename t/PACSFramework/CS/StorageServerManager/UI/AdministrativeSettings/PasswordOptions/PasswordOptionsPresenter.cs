// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Demos.StorageServer.DataTypes;
using Leadtools.Medical.DataAccessLayer;
using Leadtools.Medical.OptionsDataAccessLayer;
using Leadtools.Medical.OptionsDataAccessLayer.Configuration;
using Leadtools.Demos.StorageServer.DataTypes.Options;
using Leadtools.Medical.Winforms.Monitor;
using Leadtools.Demos.StorageServer.UI.AdministrativeSettings;

namespace Leadtools.Demos.StorageServer.UI
{
   public class PasswordOptionsPresenter
   {
      private IdleMonitor _IdleMonitor;

      public const string PasswordOptions = "PasswordOptions";      

      private IOptionsDataAccessAgent _Options;      

      public PasswordOptionsView View { get; private set; }      

      public void RunView(PasswordOptionsView view)
      {         
         ServerEventBroker.Instance.Subscribe<ApplyServerSettingsEventArgs>(OnUpdateServerSettings);
         ServerEventBroker.Instance.Subscribe<CancelServerSettingsEventArgs>(OnCancelServerSettings);
         ServerEventBroker.Instance.Subscribe<ActivateIdleMonitorEventArgs>(UpdateIdleMonitor);

         View = view;
         _Options = DataAccessServices.GetDataAccessService<IOptionsDataAccessAgent>();
         View.Options = _Options.Get<PasswordOptions>(PasswordOptions, new PasswordOptions());
         if (View.Options.EnableIdleTimeout)
            StartIdleMonitor();
      }

      private void OnUpdateServerSettings(object sender, EventArgs e)
      {
         try
         {
            _Options.Set<PasswordOptions>(PasswordOptions, View.Options);
            if (View.Options.EnableIdleTimeout)
               StartIdleMonitor();
            else
               StopIdleMonitor();
         }
         catch (Exception exception)
         {
            Messager.ShowError(null, exception);
         }
      }

      private void OnCancelServerSettings(object sender, EventArgs e)
      {        
      }

      private void UpdateIdleMonitor(object sender, ActivateIdleMonitorEventArgs e)
      {
         if (e.Activate && View.Options.EnableIdleTimeout)
         {
            StartIdleMonitor();
         }
         else
         {
            StopIdleMonitor();
         }
      }

      private void StartIdleMonitor()
      {
         StopIdleMonitor();
         _IdleMonitor = new IdleMonitor(View.Options.IdleTimeOut);
         _IdleMonitor.IdleTimeout += new EventHandler(_IdleMonitor_IdleTimeout);
         _IdleMonitor.Start();
      }

      void _IdleMonitor_IdleTimeout(object sender, EventArgs e)
      {
         ServerEventBroker.Instance.PublishEvent<LoginEventArgs>(this, new LoginEventArgs());
      }

      private void StopIdleMonitor()
      {
         if (_IdleMonitor != null)
         {
            _IdleMonitor.IdleTimeout -= _IdleMonitor_IdleTimeout;
            _IdleMonitor.Stop();
            _IdleMonitor.Dispose();
            _IdleMonitor = null;
         }
      }
   }
}
