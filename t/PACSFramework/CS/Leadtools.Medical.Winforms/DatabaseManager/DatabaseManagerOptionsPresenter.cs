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

namespace Leadtools.Medical.Winforms.DatabaseManager
{
   public class DatabaseManagerOptionsPresenter
   {

      public const string DatabaseManagerOptions = "DatabaseManagerOptions";

      private IOptionsDataAccessAgent _Options;

      public DatabaseManagerOptionsView View { get; private set; }

      public void RunView(DatabaseManagerOptionsView view)
      {
         // EventBroker.Instance.Subscribe<BackgroundProcessEventAgs>(OnBackgroundProcess);

         View = view;
         _Options = DataAccessServices.GetDataAccessService<IOptionsDataAccessAgent>();
         View.Options = _Options.Get<DatabaseManagerOptions>(DatabaseManagerOptions, new DatabaseManagerOptions());
         View.SettingsChanged += new EventHandler(View_SettingsChanged);

         // Administration:
         View.PageSizeChanged += new EventHandler(View_PageSizeChanged);
         View.PaginationDisplayOptionChanged += new EventHandler(View_PaginationDisplayOptionChanged);
      }

      void View_PaginationDisplayOptionChanged(object sender, EventArgs e)
      {
         LocalAuditLogQueue.AddAuditMessage(AuditMessages.DatabaseManagerPaginationDisplayOptionChanged.Key,
            string.Format(AuditMessages.DatabaseManagerPaginationDisplayOptionChanged.Message, View.Options.GetDisplayOptionString()));
      }

      void View_PageSizeChanged(object sender, EventArgs e)
      {
         LocalAuditLogQueue.AddAuditMessage(AuditMessages.DatabaseManagerPageSizeChanged.Key,
            string.Format(AuditMessages.DatabaseManagerPageSizeChanged.Message, View.Options.PageSize));
      }

      public void ResetView()
      {
         View.Options = _Options.Get<DatabaseManagerOptions>(DatabaseManagerOptions, new DatabaseManagerOptions());
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
            _Options.Set<DatabaseManagerOptions>(DatabaseManagerOptions, View.Options);
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
            _Options.Set<DatabaseManagerOptions>(DatabaseManagerOptions, View.Options);
         }
         catch (Exception exception)
         {
            Messager.ShowError(null, exception);
         }
      }

   }
}
