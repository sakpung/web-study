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
using Leadtools.Medical.DataAccessLayer;
using Leadtools.Medical.Winforms;
using Leadtools.DicomDemos;
using Leadtools.Medical.Rules.AddIn;
using Leadtools.Dicom;

namespace Leadtools.Medical.Rules.AddIn.Dialogs
{
   public class ProcessorConfiguration : IConfigureDialog
   {
      private AdvancedSettings _AdvancedSettings = null;
      private static ServerSettings _Settings = null;
      private ConfigureDialog _dlgConfigure = null;
      private RuleEditorPresenter _Presenter;

      public static ServerSettings Settings
      {
         get
         {
            return _Settings;
         }
      }

      #region IConfigureDialog Members

      public void Close()
      {         
      }

      public void Initialize(AdvancedSettings advancedSettings, ServerSettings Settings, string ServerDirectory)
      {
          _AdvancedSettings = advancedSettings;
          _Settings = Settings;

          Module.InitializeLicense();
          DicomEngine.Startup();
          DicomNet.Startup();         
          Module.InitializeFailureDirectory(ServerDirectory);
          Module.ServiceName = Settings.ServiceName;
          Module.ServiceDirectory = ServerDirectory;

          try
          {
             if (Settings != null)
                Module.ServiceName = Settings.ServiceName;
             Module.ServiceDirectory = ServerDirectory;
             Module.ConfigureRuleProcessor(_AdvancedSettings);

             _dlgConfigure = new ConfigureDialog();
             _dlgConfigure.FormClosing += new FormClosingEventHandler(_dlgConfigure_FormClosing);
             _Presenter = new RuleEditorPresenter(Module._Options, ServerDirectory);
             _Presenter.RunView(_dlgConfigure, advancedSettings);
          }
          catch (Exception e)
          {
             Logger.Global.Exception(Module.Source, e);
          }          
      }

      void _dlgConfigure_FormClosing(object sender, FormClosingEventArgs e)
      {         
          e.Cancel = _Presenter.Save();
      }

      public void Show(System.Windows.Forms.IWin32Window Owner)
      {         
      }

      public void Show()
      {       
      }

      public void ShowDialog(IWin32Window Owner)
      {
          if (_dlgConfigure!=null)
          {
              if (_dlgConfigure.ShowDialog(Owner) == DialogResult.OK)
              {
                  try
                  {
                     string name = Assembly.GetExecutingAssembly().GetName().Name;

                     _Presenter.UpdateOptions();
                     _AdvancedSettings.RefreshSettings();
                     _AdvancedSettings.SetAddInCustomData<RuleProcessorOptions>(name, Module.Source, Module._Options);
                     _AdvancedSettings.Save(); 
                  }
                  catch (Exception e)
                  {
                      Logger.Global.Exception(Module.Source, e);
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
