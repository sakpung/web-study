// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Medical.DataAccessLayer;
using Leadtools.Medical.OptionsDataAccessLayer;
using Leadtools.Medical.OptionsDataAccessLayer.Configuration;
using Leadtools.Medical.Winforms.Monitor;
using Leadtools.Demos;
using Leadtools.Medical.UserManagementDataAccessLayer;
using Leadtools.Medical.PermissionsManagement.DataAccessLayer;

namespace Leadtools.Medical.Winforms
{
   public class PasswordOptionsPresenter
   {
      private IdleMonitor _IdleMonitor;
      private int _BackgroundCount = 0;
      private object _BackgroundLock = new object();

      public const string PasswordOptions = "PasswordOptions";      

      private IOptionsDataAccessAgent _optionsAgent;
#if LEADTOOLS_V19_OR_LATER
      private IUserManagementDataAccessAgent4 _userAgent3;
#endif
      private IUserManagementDataAccessAgent2 _userAgent2;

      private IPermissionManagementDataAccessAgent2 _permissionAgent;

      public PasswordOptionsView View { get; private set; }

      public event EventHandler IdleTimeout;

#if LEADTOOLS_V19_OR_LATER
      private void UpdateUsersList()
      {
         User[] users = null;
         if (_userAgent3 != null)
         {
          _userAgent3.GetUsers(true);
         }
         else
         {
            _userAgent2.GetUsers();
         }
  
         if (users != null)
         {
            foreach (User user in users)
            {
               bool isAdmin = _permissionAgent.UserHasPermission("Admin", user.UserName);
               if (user.IsAdmin == false)
               {
                  user.IsAdmin = isAdmin;
               }

               if (user.IsAdmin == false)
               {
                  bool isAdminRole = false;
                  string[] roles = _permissionAgent.GetUserRoles(user.UserName);
                  if (roles != null)
                  {
                     foreach (string role in roles)
                     {
                        if (role == "Administrators")
                        {
                           isAdminRole = true;
                           break;
                        }
                     }
                  }
                  user.IsAdmin = isAdminRole;
               }
            }
            View.CardReaderUsers = users.ToList();
         }
      }
#endif

      public void RunView(PasswordOptionsView view)
      {                  
         EventBroker.Instance.Subscribe<BackgroundProcessEventAgs>(OnBackgroundProcess);

         View = view;

#if LEADTOOLS_V19_OR_LATER
         _userAgent3 = DataAccessServices.GetDataAccessService<IUserManagementDataAccessAgent4>();
         _userAgent2 = DataAccessServices.GetDataAccessService<IUserManagementDataAccessAgent2>();
#else
         _userAgent2 = DataAccessServices.GetDataAccessService<IUserManagementDataAccessAgent2>();
#endif
         _permissionAgent = DataAccessServices.GetDataAccessService<IPermissionManagementDataAccessAgent2>();

#if LEADTOOLS_V19_OR_LATER
         UpdateUsersList();
#endif

         _optionsAgent = DataAccessServices.GetDataAccessService<IOptionsDataAccessAgent>();
         View.Options = _optionsAgent.Get<PasswordOptions>(PasswordOptions, new PasswordOptions());

         View.SettingsChanged +=new EventHandler(View_SettingsChanged);
         
         // Administration: Password Options
         View.ComplexityLowerCaseChanged += new EventHandler(View_ComplexityLowerCaseChanged);
         View.ComplexityUpperCaseChanged += new EventHandler(View_ComplexityUpperCaseChanged);
         View.ComplexitySymbolChanged += new EventHandler(View_ComplexitySymbolChanged);
         View.ComplexityNumberChanged += new EventHandler(View_ComplexityNumberChanged);
         View.MinimumLengthChanged += new EventHandler(View_MinimumLengthChanged);
         View.DaysToExpirationChanged += new EventHandler(View_DaysToExpirationChanged);
         View.MaximumRememberedChanged += new EventHandler(View_MaximumRememberedChanged);
         View.IdleTimeoutEnableChanged += new EventHandler(View_IdleTimeoutEnableChanged);
         View.IdleTimeoutChanged += new EventHandler(View_IdleTimeoutChanged);
         View.LoginTypeChanged += new EventHandler(View_LoginTypeChanged);
         
         if (View.Options.EnableIdleTimeout)
            StartIdleMonitor();
      }

      void OnBackgroundProcess(object sender, BackgroundProcessEventAgs e)
      {
         lock (this)
         {
            if (e.Starting)
            {
               if (_BackgroundCount < 0)
                  _BackgroundCount = 0;

               _BackgroundCount++;
               StopIdleMonitor();
            }
            else
            {
               _BackgroundCount = Math.Max(0, --_BackgroundCount);
               if (_BackgroundCount == 0)
               {
                  if (View.Options.EnableIdleTimeout)
                  {
                     StartIdleMonitor();
                  }
               }
            }
         }
      }

      void View_IdleTimeoutChanged(object sender, EventArgs e)
      {
         LocalAuditLogQueue.AddAuditMessage(AuditMessages.IdleTimeoutChanged.Key,
            string.Format(AuditMessages.IdleTimeoutChanged.Message, View.Options.IdleTimeOut));
      }

      void View_LoginTypeChanged(object sender, EventArgs e)
      {
         LocalAuditLogQueue.AddAuditMessage(AuditMessages.IdleTimeoutChanged.Key,
            string.Format(AuditMessages.LoginTypeChanged.Message, View.Options.LoginType));
      }

      void View_IdleTimeoutEnableChanged(object sender, EventArgs e)
      {
         LocalAuditLogQueue.AddAuditMessage(AuditMessages.IdleTimeoutEnableChanged.Key,
            string.Format(AuditMessages.IdleTimeoutEnableChanged.Message, View.Options.EnableIdleTimeout));
      }

      void View_MaximumRememberedChanged(object sender, EventArgs e)
      {
         LocalAuditLogQueue.AddAuditMessage(AuditMessages.MaximumRememberedChanged.Key,
            string.Format(AuditMessages.MaximumRememberedChanged.Message, View.Options.MaxPasswordHistory));
      }

      void View_DaysToExpirationChanged(object sender, EventArgs e)
      {
         LocalAuditLogQueue.AddAuditMessage(AuditMessages.DaysToExpirationChanged.Key,
            string.Format(AuditMessages.DaysToExpirationChanged.Message, View.Options.DaysToExpire));
      }

      void View_MinimumLengthChanged(object sender, EventArgs e)
      {
         LocalAuditLogQueue.AddAuditMessage(AuditMessages.MinimumLengthChanged.Key,
            string.Format(AuditMessages.MinimumLengthChanged.Message, View.Options.MinimumLength));
      }

      void View_ComplexityNumberChanged(object sender, EventArgs e)
      {
         LocalAuditLogQueue.AddAuditMessage(AuditMessages.ComplexityNumberChanged.Key,
            string.Format(AuditMessages.ComplexityNumberChanged.Message, (View.Options.Complexity & Complexity.Numbers) == Complexity.Numbers));
      }

      void View_ComplexitySymbolChanged(object sender, EventArgs e)
      {
         LocalAuditLogQueue.AddAuditMessage(AuditMessages.ComplexitySymbolChanged.Key,
            string.Format(AuditMessages.ComplexitySymbolChanged.Message, (View.Options.Complexity & Complexity.Symbol) == Complexity.Symbol));
      }

      void View_ComplexityUpperCaseChanged(object sender, EventArgs e)
      {
         LocalAuditLogQueue.AddAuditMessage(AuditMessages.ComplexityUpperCaseChanged.Key,
            string.Format(AuditMessages.ComplexityUpperCaseChanged.Message, (View.Options.Complexity & Complexity.Uppercase) == Complexity.Uppercase));
      }

      void View_ComplexityLowerCaseChanged(object sender, EventArgs e)
      {
         LocalAuditLogQueue.AddAuditMessage(AuditMessages.ComplexityLowerCaseChanged.Key,
            string.Format(AuditMessages.ComplexityLowerCaseChanged.Message, (View.Options.Complexity & Complexity.Lowercase) == Complexity.Lowercase));
      }
      
      public void ResetView ( ) 
      {
         View.Options = _optionsAgent.Get<PasswordOptions>(PasswordOptions, new PasswordOptions());
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

      public bool IsDirty
      {
         get
         {
            return View.IsDirty;
         }
      }

      private void OnUpdateServerSettings(object sender, EventArgs e)
      {
         try
         {
            _optionsAgent.Set<PasswordOptions>(PasswordOptions, View.Options);
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

      public void SaveOptions()
      {
         try
         {
            _optionsAgent.Set<PasswordOptions>(PasswordOptions, View.Options);
            if (View.Options.EnableIdleTimeout)
               StartIdleMonitor();
            else
               StopIdleMonitor();

#if LEADTOOLS_V19_OR_LATER
         UpdateUsersList();
#endif
         }
         catch (Exception exception)
         {
            Messager.ShowError(null, exception);
         }
      }

      private void OnCancelServerSettings(object sender, EventArgs e)
      {        
      }

      public void UpdateIdleMonitor(ActivateIdleMonitorEventArgs e)
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
         if (_BackgroundCount != 0)
            return;

         StopIdleMonitor();
         _IdleMonitor = new IdleMonitor(Math.Max(View.Options.IdleTimeOut,30));
         _IdleMonitor.IdleTimeout += new EventHandler(_IdleMonitor_IdleTimeout);
         _IdleMonitor.Start();
      }

      void _IdleMonitor_IdleTimeout(object sender, EventArgs e)
      {         
         if (IdleTimeout != null)
         {
            IdleTimeout(this, EventArgs.Empty);
         }
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
