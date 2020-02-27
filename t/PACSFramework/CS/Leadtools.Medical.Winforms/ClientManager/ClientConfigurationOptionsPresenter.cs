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
using Leadtools.Demos;

namespace Leadtools.Medical.Winforms.ClientManager
{
   public class ClientConfigurationOptionsPresenter
   {

      public const string ClientConfigurationOptions = "ClientConfigurationOptions";

      private IOptionsDataAccessAgent _Options;

      public ClientConfigurationOptionsView View { get; private set; }

      public void RunView(ClientConfigurationOptionsView view)
      {
         // EventBroker.Instance.Subscribe<BackgroundProcessEventAgs>(OnBackgroundProcess);

         View = view;
         _Options = DataAccessServices.GetDataAccessService<IOptionsDataAccessAgent>();
         View.Options = _Options.Get<ClientConfigurationOptions>(ClientConfigurationOptions, new ClientConfigurationOptions());
         View.SettingsChanged += new EventHandler(View_SettingsChanged);

         // Administration:
         View.PageSizeChanged += new EventHandler(View_PageSizeChanged);
         View.PaginationDisplayOptionChanged += new EventHandler(View_PaginationDisplayOptionChanged);
         View.LastViewDisplayOptionChanged += View_LastAccessDateDisplayOptionChanged;
      }

      private void View_LastAccessDateDisplayOptionChanged(object sender, EventArgs e)
      {
         LocalAuditLogQueue.AddAuditMessage(AuditMessages.ClientConfigurationLastAccessDateDisplayOptionChanged.Key,
            string.Format(AuditMessages.ClientConfigurationLastAccessDateDisplayOptionChanged.Message, View.Options.GetLastAccessDateString()));
      }

      void View_PaginationDisplayOptionChanged(object sender, EventArgs e)
      {
         LocalAuditLogQueue.AddAuditMessage(AuditMessages.ClientConfigurationPaginationDisplayOptionChanged.Key,
            string.Format(AuditMessages.ClientConfigurationPaginationDisplayOptionChanged.Message, View.Options.GetDisplayOptionString()));
      }

      void View_PageSizeChanged(object sender, EventArgs e)
      {
         LocalAuditLogQueue.AddAuditMessage(AuditMessages.ClientConfigurationPageSizeChanged.Key,
            string.Format(AuditMessages.ClientConfigurationPageSizeChanged.Message, View.Options.PageSize));
      }

      public void ResetView()
      {
         View.Options = _Options.Get<ClientConfigurationOptions>(ClientConfigurationOptions, new ClientConfigurationOptions());
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
            _Options.Set<ClientConfigurationOptions>(ClientConfigurationOptions, View.Options);
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
            _Options.Set<ClientConfigurationOptions>(ClientConfigurationOptions, View.Options);
         }
         catch (Exception exception)
         {
            Messager.ShowError(null, exception);
         }
      }

   }
}
