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
using Leadtools.Dicom.AddIn.Common;
using Leadtools.Dicom.Common.DataTypes.PatientUpdater;
using System.Runtime.Serialization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Reflection;
using Leadtools.Dicom.AddIn.Controls;
using Leadtools.Dicom.AddIn;
using Leadtools.Dicom.AddIn.Interfaces;
using Leadtools.Medical.DataAccessLayer;
using Leadtools.Medical.Rules.AddIn;
using Leadtools.Medical.Rules.AddIn.Common;
using Leadtools.Dicom;
using Leadtools.Medical.Winforms;
using Leadtools.Demos;
using System.Net;
using Leadtools.Medical.Rules.AddIn.Workers;

namespace Leadtools.Medical.Rules.AddIn.Dialogs
{
   public partial class ConfigureDialog : Form, IRulesConfigurationDialog
   {
      private bool _StoreResendInitialized = false;
      private bool _MoveResendInitialized = false;

      public RuleEditorUserControl View
      {
         get
         {
            return ruleEditorUserControl;
         }
      }

      public event EventHandler<GetFailuresEventArgs<StoreFailure>> GetStoreFailures;      

      protected Dictionary<string, StoreFailure> OnGetStoreFailures()
      {
         if (GetStoreFailures != null)
         {
            GetFailuresEventArgs<StoreFailure> e = new GetFailuresEventArgs<StoreFailure>();

            GetStoreFailures(this, e);
            return e.Failures;
         }
         return new Dictionary<string, StoreFailure>();
      }

      public event EventHandler<GetFailuresEventArgs<MoveServer>> GetMoveFailures;

      protected Dictionary<string, MoveServer> OnGetMoveFailures()
      {
         if (GetStoreFailures != null)
         {
            GetFailuresEventArgs<MoveServer> e = new GetFailuresEventArgs<MoveServer>();

            GetMoveFailures(this, e);
            return e.Failures;
         }
         return new Dictionary<string, MoveServer>();
      }

      public event EventHandler SaveOptions;

      protected void OnSaveOptions()
      {
         if (SaveOptions != null)
            SaveOptions(this, EventArgs.Empty);
      }

      public ConfigureDialog()
      {
         InitializeComponent();

         ruleEditorUserControl = new RuleEditorUserControl();
         ruleEditorUserControl.Dock = DockStyle.Fill;
         tabPageOptions.Controls.Add(ruleEditorUserControl);

         ruleEditorUserControl.SaveRule += new EventHandler<SaveRuleEventArgs>(ruleEditorUserControl_SaveRule);
         ruleEditorUserControl.SaveOptions += new EventHandler(ruleEditorUserControl_SaveOptions);
         Icon = Module.GetAppIcon();
      }

      public override object InitializeLifetimeService()
      {
         return null;
      }

      void ruleEditorUserControl_SaveOptions(object sender, EventArgs e)
      {
         OnSaveOptions();
      }

      void ruleEditorUserControl_SaveRule(object sender, SaveRuleEventArgs e)
      {
         OnSaveRule(e);
      }


      private void ConfigureDialog_Load(object sender, EventArgs e)
      {
         AddVersionInfo();

         AdjustColumns(listViewDatasets);
         AdjustColumns(listViewServers);

         listViewDatasets_SelectedIndexChanged(listViewDatasets, EventArgs.Empty);
         listViewServers_SelectedIndexChanged(listViewServers, EventArgs.Empty);
         listViewMoves_SelectedIndexChanged(listViewMoves, EventArgs.Empty);        

         Application.Idle += new EventHandler(Application_Idle);
      }

      void Application_Idle(object sender, EventArgs e)
      {
         toolStripButtonDeleteAllImages.Enabled = listViewDatasets.Items.Count > 0;
         toolStripButtonDeleteAllServers.Enabled = listViewServers.Items.Count > 0;
         toolStripButtonRetryAll.Enabled = listViewDatasets.Items.Count > 0;
         toolStripButtonRetryAllRequests.Enabled = listViewMoves.Items.Count > 0;
         toolStripButtonDeleteAllRequests.Enabled = listViewMoves.Items.Count > 0;
      }

      private void AdjustColumns(ListView listview)
      {
          int count = (from c in listview.Columns.OfType<ColumnHeader>()
                       where c.Width > 0
                       select c).Count();
         int width = listview.ClientRectangle.Width / count;

         foreach (ColumnHeader column in listview.Columns)
         {
             if(column.Width != 0)
                column.Width = width;
         }
      }

      private void AddVersionInfo()
      {
         VersionInfoControl vi = new VersionInfoControl();

         vi.Dock = DockStyle.Fill;
         vi.Assembly = Assembly.GetExecutingAssembly();
         tabPageDetails.Controls.Add(vi);
      }

      #region IRulesConfigurationDialog Members

      public string AETitle
      {
         get
         {
            return ruleEditorUserControl.AETitle;
         }
         set
         {
            ruleEditorUserControl.AETitle = value;
         }
      }

      public void SetRules(List<RuleItem> rules)
      {
         ruleEditorUserControl.SetRules(rules);
      }

      public bool Save()
      {
         return ruleEditorUserControl.Save();
      }

      public event EventHandler<SaveRuleEventArgs> SaveRule;

      protected void OnSaveRule(SaveRuleEventArgs e)
      {
         if (SaveRule != null)
            SaveRule(this, e);
      }

      #endregion

      private string UidName(string uid)
      {
         if (string.IsNullOrEmpty(uid))
            return string.Empty;

         DicomUid u = DicomUidTable.Instance.Find(uid);

         if (u == null)
            return uid;

         return string.Format("{0} ({1})", u.Name, uid);
      }

      private void tabControlOptions_SelectedIndexChanged(object sender, EventArgs e)
      {
         if (tabControlOptions.SelectedTab == tabPageResends && !_StoreResendInitialized)
         {
            Dictionary<string,StoreFailure> failures = OnGetStoreFailures();

            foreach (KeyValuePair<string,StoreFailure> kv in failures)
            {
               ListViewItem item = listViewDatasets.Items.Add(kv.Value.Dataset.GetValue<string>(DicomTag.PatientName, string.Empty));

               item.SubItems.Add(kv.Value.Dataset.GetValue<string>(DicomTag.PatientID, string.Empty));
               item.SubItems.Add(kv.Value.Dataset.GetValue<string>(DicomTag.StudyID, string.Empty));
               item.SubItems.Add(kv.Value.Dataset.GetValue<string>(DicomTag.Modality, string.Empty));
               item.SubItems.Add(UidName(kv.Value.Dataset.GetValue<string>(DicomTag.TransferSyntaxUID, string.Empty)));
               item.SubItems.Add(kv.Key);
               item.Tag = kv.Value;
            }

            _StoreResendInitialized = true;
         }         
      }

      private void listViewDatasets_DoubleClick(object sender, EventArgs e)
      {
         if (listViewDatasets.SelectedItems.Count == 1)
         {
            toolStripButtonViewInfo_Click(toolStripButtonViewInfo, EventArgs.Empty);
         }
      }

      private void toolStripButtonViewInfo_Click(object sender, EventArgs e)
      {
         StoreFailure failure = listViewDatasets.SelectedItems[0].Tag as StoreFailure;
         ViewDatasetDialog dlgView = new ViewDatasetDialog(failure.Dataset);

         dlgView.ShowDialog(this);
      }

      private void listViewDatasets_SelectedIndexChanged(object sender, EventArgs e)
      {
         toolStripButtonViewInfo.Enabled = listViewDatasets.SelectedItems.Count == 1;
         toolStripButtonDeleteImage.Enabled = listViewDatasets.SelectedItems.Count == 1;
         toolStripButtonRetry.Enabled = listViewDatasets.SelectedItems.Count == 1;

         if (listViewDatasets.SelectedItems.Count == 1)
            LoadServers();
         else
            listViewServers.Items.Clear();
      }

      private void LoadServers()
      {
         StoreFailure failure = listViewDatasets.SelectedItems[0].Tag as StoreFailure;

         listViewServers.BeginUpdate();
         listViewServers.Items.Clear();
         foreach (ResendServer server in failure.Scps)
         {
            ListViewItem item = listViewServers.Items.Add(server.LastStatus);

            item.SubItems.Add(server.Scp.AETitle);
            item.SubItems.Add(server.IPAddress);
            item.SubItems.Add(server.Scp.Port.ToString());
            item.Tag = server;
         }
         if (listViewServers.Items.Count > 0)
         {
            listViewServers.Items[0].Selected = true;
         }
         listViewServers.EndUpdate();
      }

      private void listViewServers_SelectedIndexChanged(object sender, EventArgs e)
      {
         toolStripButtonDeleteServer.Enabled = listViewServers.SelectedItems.Count == 1;
         toolStripButtonVerify.Enabled = listViewServers.SelectedItems.Count == 1;
      }

      private void toolStripButtonVerify_Click(object sender, EventArgs e)
      {
         ResendServer server = listViewServers.SelectedItems[0].Tag as ResendServer;

         using (WaitCursor wait = new WaitCursor())
         {
            try
            {
              server.Verify(ProcessorConfiguration.Settings.AETitle);
              MessageBox.Show( "Successfull Verification", "Verified " + server.Scp.AETitle, MessageBoxButtons.OK, MessageBoxIcon.Error);              
            }
            catch (Exception ex)
            {
               MessageBox.Show( ex.Message, "Error verifying " + server.Scp.AETitle,MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
         }
      }

      private void toolStripButtonRetry_Click(object sender, EventArgs e)
      {
         ListViewItem item = listViewDatasets.SelectedItems[0];

         SendStoreItem(item);
      }

      private void SendStoreItem(ListViewItem item)
      {
         StoreFailure failure = item.Tag as StoreFailure;

         using (ProgressDialog progress = new ProgressDialog())
         {
            progress.Title = "Retrying";
            progress.CancelMessage = "Please wait...";
            progress.Line1 = failure.Dataset.GetValue<string>(DicomTag.PatientName, string.Empty) + "(" + failure.Dataset.GetValue<string>(DicomTag.StudyID, string.Empty) + ")";            
            progress.ShowDialog(this, DialogFlags.Modal | DialogFlags.NoMinimize | DialogFlags.AutoTime | DialogFlags.NoProgressBar);
            foreach (ResendServer server in failure.Scps.ToArray())
            {
               string status = string.Empty;

               progress.Line2 = server.Scp.AETitle + " - " + server.IPAddress + ":" + server.Scp.Port.ToString();
               server.Scp.PeerAddress = IPAddress.Parse(server.IPAddress);
               if (!StoreClient.Store(ProcessorConfiguration.Settings.AETitle, server.Scp, failure.Dataset, ref status))
               {
                  UpdateServerStatus(server, status);
               }
               else
               {
                  failure.Scps.Remove(server);
                  RemoveServer(server);
               }
            }
         }

         if (failure.Scps.Count > 0)
            failure.Save();
         else
         {
            listViewDatasets.Items.Remove(item);
            failure.Delete();
         }
      }      

      private void UpdateServerStatus(ResendServer server,string status)
      {
         ListViewItem item = (from i in listViewMoves.Items.OfType<ListViewItem>()
                              where i.Tag == server
                              select i).FirstOrDefault();

         if (item != null)
         {
            server.LastStatus = status;
            item.Text = status;
         }         
      }

      private void RemoveServer(ResendServer server)
      {
         ListViewItem item = (from i in listViewMoves.Items.OfType<ListViewItem>()
                              where i.Tag == server
                              select i).FirstOrDefault();

         if (item != null)
         {
            listViewServers.Items.Remove(item);
         }
      }

      private void toolStripButtonRetryAll_Click(object sender, EventArgs e)
      {
         foreach (ListViewItem item in listViewDatasets.Items.Cast<ListViewItem>())
         {
            SendStoreItem(item);
         }
      }

      private void toolStripButtonDeleteServer_Click(object sender, EventArgs e)
      {
         ListViewItem item = listViewServers.SelectedItems[0];

         RemoveServerItem(item);
      }

      private void RemoveServerItem(ListViewItem item)
      {
         ResendServer server = item.Tag as ResendServer;
         ListViewItem failureItem = listViewDatasets.SelectedItems[0];
         StoreFailure failure = failureItem.Tag as StoreFailure;

         listViewServers.Items.Remove(item);
         failure.Scps.Remove(server);
         if (failure.Scps.Count == 0)
         {
            RemoveFailureItem(failureItem);
         }
      }

      private void toolStripButtonDeleteAllServers_Click(object sender, EventArgs e)
      {
         foreach (ListViewItem item in listViewServers.Items.Cast<ListViewItem>())
         {
            RemoveServerItem(item);
         }
      }

      private void toolStripButtonDeleteImage_Click(object sender, EventArgs e)
      {
         ListViewItem item = listViewDatasets.SelectedItems[0];

         RemoveFailureItem(item);
      }

      private void RemoveFailureItem(ListViewItem item)
      {
         try
         {
            StoreFailure failure = item.Tag as StoreFailure;
            string fileName = item.SubItems[5].Text;

            listViewServers.Items.Clear();
            if (failure != null && failure.Dataset != null)
            {
               failure.Dataset.Dispose();
               failure.Dataset = null;
            }
            listViewDatasets.Items.Remove(item);
            failure.Delete();
            File.Delete(fileName);
         }
         catch (Exception e)
         {
            MessageBox.Show(this, e.Message, "Error Deleteting Failure Item", MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
      }

      private void toolStripButtonDeleteAllImages_Click(object sender, EventArgs e)
      {
         foreach (ListViewItem item in listViewDatasets.Items.Cast<ListViewItem>())
         {
            RemoveFailureItem(item);
         }
      }

      private void tabControlStoreMove_SelectedIndexChanged(object sender, EventArgs e)
      {
         if (tabControlStoreMove.SelectedTab == tabPageMoves && !_MoveResendInitialized)
         {
            Dictionary<string,MoveServer> failures = OnGetMoveFailures();

            foreach (KeyValuePair<string,MoveServer> kv in failures)
            {
               ListViewItem item = listViewMoves.Items.Add(kv.Value.LastStatus);

               item.SubItems.Add(kv.Value.DestinationAE);
               item.SubItems.Add(kv.Value.Info.Id);
               item.SubItems.Add(kv.Value.Info.MoveType.ToString());
               item.SubItems.Add(kv.Key);
               item.Tag = kv.Value;
            }
            _MoveResendInitialized = true;
         }
      }

      private void listViewMoves_SelectedIndexChanged(object sender, EventArgs e)
      {
         toolStripButtonDeleteRequest.Enabled = listViewMoves.SelectedItems.Count > 0;
         toolStripButtonRetryRequest.Enabled = listViewMoves.SelectedItems.Count > 0;
      }

      private void SendMoveItem(ListViewItem item)
      {
         MoveServer failure = item.Tag as MoveServer;

         using (ProgressDialog progress = new ProgressDialog())
         {
            string status = string.Empty;

            progress.Title = "Retrying";
            progress.CancelMessage = "Please wait...";
            progress.Line1 = string.Format("Sending {0} move request to server.",failure.Info.MoveType);
            progress.ShowDialog(this, DialogFlags.Modal | DialogFlags.NoMinimize | DialogFlags.AutoTime | DialogFlags.NoProgressBar);
            progress.Line2 = "Server AE: " + failure.Scp.AETitle;
            failure.Scp.PeerAddress = IPAddress.Parse(failure.IPAddress);
            if (!MoveClient.Move(failure.Scp,failure.Info, failure.DestinationAE, ProcessorConfiguration.Settings.TemporaryDirectory, ref status))
            {
               UpdateMoveStatus(failure, status);
            }
            else
            {
               RemoveMoveItem(item);
            }
         }         
      }

      private void toolStripButtonRetryRequest_Click(object sender, EventArgs e)
      {
         SendMoveItem(listViewMoves.SelectedItems[0]);
      }

      private void toolStripButtonRetryAllRequests_Click(object sender, EventArgs e)
      {
         foreach (ListViewItem item in listViewMoves.Items.Cast<ListViewItem>())
         {
            SendMoveItem(item);
         }
      }

      private void UpdateMoveStatus(MoveServer server, string status)
      {
         ListViewItem item = (from i in listViewMoves.Items.OfType<ListViewItem>()
                             where i.Tag == server
                             select i).FirstOrDefault();

         if (item != null)
         {
            server.LastStatus = status;
            item.Text = status;
         }
      }

      private void RemoveMoveItem(ListViewItem item)
      {
         MoveServer server = item.Tag as MoveServer;

         listViewMoves.Items.Remove(item);
         server.Delete();
      }

      private void toolStripButtonDeleteRequest_Click(object sender, EventArgs e)
      {
         RemoveMoveItem(listViewMoves.SelectedItems[0]);
      }

      private void toolStripButtonDeleteAllRequests_Click(object sender, EventArgs e)
      {
         foreach (ListViewItem item in listViewMoves.Items.Cast<ListViewItem>())
         {
            RemoveMoveItem(item);
         }
      }

      private void ConfigureDialog_FormClosing(object sender, FormClosingEventArgs e)
      {
         //Save();
      }
   }
}
