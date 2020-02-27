// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Leadtools.JobProcessor.WorkerService;
using Leadtools.Demos;
using System.IO;

namespace JobProcessorDashboardDemo
{
   public partial class WorkerForm : Form
   {
      WorkerService workerService = null;
      bool serviceStarted = false;
      string _configFilePath = String.Empty;
      string _workerName = string.Empty;

      public WorkerForm(string workerName, string configFilePath)
      {
         InitializeComponent();
         _workerName = workerName;

         this.Text = workerName;
         _configFilePath = configFilePath;

         try
         {
            //Create new instance of service class
            workerService = new WorkerService();
            workerService.OnLogging += new EventHandler<LoggingEventArgs>(workerService_OnLogging);
         }
         catch (Exception ex)
         {
            MessageBox.Show(ex.Message, "Error");
         }

         UpdateUI();
      }

      private void Worker_FormClosing(object sender, FormClosingEventArgs e)
      {
         if (workerService != null)
         {
            workerService.OnLogging -= new EventHandler<LoggingEventArgs>(workerService_OnLogging);
            workerService.Dispose();
         }

         if (File.Exists(_configFilePath))
         {
            File.Delete(_configFilePath);
         }
      }

      //This event can be used to receive log information from the service class
      void workerService_OnLogging(object sender, LoggingEventArgs e)
      {
         _lvLogging.Invoke(new MethodInvoker(delegate
         {
            //Add log event
            ListViewItem newItem = new ListViewItem(DateTime.Now.ToString());
            newItem.SubItems.Add(e.Message);
            newItem.SubItems.Add(e.Source);
            newItem.SubItems.Add(e.Type.ToString());
            _lvLogging.Items.Add(newItem);
         }));
      }

      private void _btnStart_Click(object sender, EventArgs e)
      {
         workerService.StartVirtual(_workerName, _configFilePath);
         serviceStarted = true;
         UpdateUI();
      }

      private void _btnStop_Click(object sender, EventArgs e)
      {
         workerService.StopVirtual();
         serviceStarted = false;
         UpdateUI();
      }

      private void _btnClearLog_Click(object sender, EventArgs e)
      {
         _lvLogging.Items.Clear();
      }

      private void UpdateUI()
      {
         _btnStart.Enabled = !serviceStarted;
         _btnStop.Enabled = serviceStarted;
      }

      private void _btnExportLog_Click(object sender, EventArgs e)
      {
         try
         {
            if (_lvLogging.Items.Count == 0)
            {
               MessageBox.Show("There is no log information to export");
               return;
            }

            //Export to file
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
               sfd.Filter = "Log files (*.log)|*.log|All files (*.*)|*.*";
               if (sfd.ShowDialog() == DialogResult.OK)
               {
                  using (StreamWriter textFile = new StreamWriter(sfd.FileName))
                  {
                     foreach (ListViewItem logItem in _lvLogging.Items)
                        textFile.WriteLine(String.Format("Date / Time: {0}{1}Message: {2}{1}Source: {3}{1}Type: {4}{1}{1}", logItem.Text, Environment.NewLine, logItem.SubItems[1].Text, logItem.SubItems[2].Text, logItem.SubItems[3].Text));
                  }
               }
            }
         }
         catch (Exception ex)
         {
            MessageBox.Show(ex.Message, "Error");
         }
      }
   }
}
