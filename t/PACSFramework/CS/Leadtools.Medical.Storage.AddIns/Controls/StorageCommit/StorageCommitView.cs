// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Windows.Forms;

namespace Leadtools.Medical.Storage.AddIns.Controls.StorageCommit
{
   public partial class StorageCommitView : UserControl
   {
      public StorageCommitView()
      {
         InitializeComponent();

         radioButtonSameAssociation.CheckedChanged += OnRadioButtonChanged;
         radioButtonNewAssociation.CheckedChanged += OnRadioButtonChanged;
         this.radioButtonTrySameThenNew.CheckedChanged += OnRadioButtonChanged;

         Options = null;
      }

      private void OnRadioButtonChanged(object sender, EventArgs e)
      {
         RadioButton rb = sender as RadioButton;
         if (rb != null)
         {
            if (rb.Checked)
            {
               OnSettingsChanged(sender, e);
            }
         }
      }

      private StorageCommitOptions _options;
      public StorageCommitOptions Options
      {
         get { return _options; }
         set { _options = value; }
      }


      private event EventHandler _settingsChanged;
      public event EventHandler SettingsChanged
      {
         add
         {
            _settingsChanged += value;
         }
         remove
         {
            _settingsChanged -= value;
         }
      }

      private void OnSettingsChanged(object sender, EventArgs e)
      {
         try
         {
            if (_settingsChanged != null)
            {
               _settingsChanged(sender, e);
            }
         }
         catch (Exception)
         {
            System.Diagnostics.Debug.Assert(false);
         }
      }

      public void Initialize(StorageCommitOptions options)
      {
         _options = options;
         switch(options.reportType)
         {
            case ReportType.SameAssociation:
               this.radioButtonSameAssociation.Checked = true;
               break;

            case ReportType.NewAssociation:
               this.radioButtonNewAssociation.Checked = true;
               break;

            case ReportType.ConditionalAssociation:
               this.radioButtonTrySameThenNew.Checked = true;
               break;
         }
      }

      public ReportType GetReportType()
      {
         ReportType reportType = ReportType.SameAssociation;
         if (this.radioButtonSameAssociation.Checked)
         {
            reportType = ReportType.SameAssociation;
         }
         else if (this.radioButtonNewAssociation.Checked)
         {
            reportType = ReportType.NewAssociation;
         }
         else
         {
            reportType = ReportType.ConditionalAssociation;
         }
         return reportType;
      }

      public StorageCommitOptions UpdateSettings()
      {
         if (Options == null)
            return null;

         Options.reportType = GetReportType();
         return Options;
      }

   }
}
