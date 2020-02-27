// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Leadtools.Medical.WebViewer.JobsCleanupAddin
{
   public partial class ConfigurationDialog : Form
   {
      public JobsCleanupConfigurationViewProxy CleanupProxy { get; set; }

      public ConfigurationDialog()
      {
         InitializeComponent();                  
      }

      void UpdateView()
      {
         if (null == CleanupProxy)
         {
            return;
         }
         
         checkBox1.Checked = CleanupProxy.Enable;

         radioButton6.Checked = CleanupProxy.CheckIntervalProperty == JobsCleanupConfigurationViewProxy.CheckInterval.custom;
         radioButton5.Checked = CleanupProxy.CheckIntervalProperty == JobsCleanupConfigurationViewProxy.CheckInterval.daily;
         radioButton4.Checked = CleanupProxy.CheckIntervalProperty == JobsCleanupConfigurationViewProxy.CheckInterval.weekly;

         radioButton7.Checked = CleanupProxy.ExpiryIntervalProperty == JobsCleanupConfigurationViewProxy.ExpiryInterval.custom;
         radioButton8.Checked = CleanupProxy.ExpiryIntervalProperty == JobsCleanupConfigurationViewProxy.ExpiryInterval.day;
         radioButton9.Checked = CleanupProxy.ExpiryIntervalProperty == JobsCleanupConfigurationViewProxy.ExpiryInterval.week;
         radioButton10.Checked = CleanupProxy.ExpiryIntervalProperty == JobsCleanupConfigurationViewProxy.ExpiryInterval.month;

         numericUpDown2.Value = CleanupProxy.CheckIntervalCustomProperty;
         numericUpDown3.Value = CleanupProxy.ExpiryIntervalCustomProperty;
         numericUpDown4.Value = CleanupProxy.MaxRetry;
      }

      void ApplySettings()
      {
         if (null == CleanupProxy)
         {
            return;
         }

         CleanupProxy.Enable = checkBox1.Checked; 

         if(radioButton6.Checked)
         CleanupProxy.CheckIntervalProperty = JobsCleanupConfigurationViewProxy.CheckInterval.custom;
         if(radioButton5.Checked)
         CleanupProxy.CheckIntervalProperty = JobsCleanupConfigurationViewProxy.CheckInterval.daily;
         if(radioButton4.Checked )
            CleanupProxy.CheckIntervalProperty = JobsCleanupConfigurationViewProxy.CheckInterval.weekly;

         if(radioButton7.Checked)
            CleanupProxy.ExpiryIntervalProperty = JobsCleanupConfigurationViewProxy.ExpiryInterval.custom;
         if(radioButton8.Checked)
            CleanupProxy.ExpiryIntervalProperty = JobsCleanupConfigurationViewProxy.ExpiryInterval.day;
         if(radioButton9.Checked )
            CleanupProxy.ExpiryIntervalProperty = JobsCleanupConfigurationViewProxy.ExpiryInterval.week;
         if(radioButton10.Checked )
            CleanupProxy.ExpiryIntervalProperty = JobsCleanupConfigurationViewProxy.ExpiryInterval.month;

         CleanupProxy.CheckIntervalCustomProperty = (int)numericUpDown2.Value;
         CleanupProxy.ExpiryIntervalCustomProperty = (int)numericUpDown3.Value;
         CleanupProxy.MaxRetry = (int)numericUpDown4.Value;

         CleanupProxy.Apply();
      }

      private void button1_Click(object sender, EventArgs e)
      {
         try
         {
            if (null == CleanupProxy)
            {
               return;
            }
            CleanupProxy.RunCleanupNow();
         }
         catch (Exception ex)
         {
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
      }

      private void ConfigurationDialog_Load(object sender, EventArgs e)
      {
         UpdateView();
      }

      private void button2_Click(object sender, EventArgs e)
      {
         try
         {
            ApplySettings();
            Close();
         }
         catch (System.Exception ex)
         {
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
      }

      private void button3_Click(object sender, EventArgs e)
      {
         Close();
      }
   }
}
