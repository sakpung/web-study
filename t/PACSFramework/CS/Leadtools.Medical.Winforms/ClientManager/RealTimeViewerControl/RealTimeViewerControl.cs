// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Leadtools.Dicom.AddIn.Common;
using System.Runtime.InteropServices;
using Leadtools.Medical.Winforms.Forwarder.Scheduling;
using Leadtools.Dicom.AddIn;
using Leadtools.Dicom;
using Leadtools.Dicom.Common.Extensions;
using System.IO;
using System.Reflection;
using System.Diagnostics;
using System.Collections.Concurrent;

namespace Leadtools.Medical.Winforms.ClientManager
{   
   public partial class RealTimeViewerControl : UserControl
   {
      private object _listLock = new object();
      private Scheduler _Scheduler = new Scheduler();
      private Scheduler _DeleteScheduler = new Scheduler();
      private ConcurrentDictionary<string, List<ActionInfo>> _ClientActions = new ConcurrentDictionary<string, List<ActionInfo>>();

      private const int COLUMN_AETITLE = 1;
      private const int COLUMN_ACTION = 3;
      private const int COLUMN_TOTAL_CONNECT_TIME = 4;

      public event EventHandler<DisconnectClientEventArgs> DisconnectClient;

       private class ActionInfo
       {
           public string Action { get; set; }
           public DicomDataSet Dataset { get; set; }
       }

      protected void OnDisconnectClient(ClientInfo clientInfo)
      {
         if (DisconnectClient != null)
         {
            DisconnectClient(this, new DisconnectClientEventArgs(clientInfo));
         }
      }

      public RealTimeViewerControl()
      {
         InitializeComponent();
         listViewClients.SizeChanged += listViewClients_SizeChanged;
         Application.Idle += new EventHandler(Application_Idle);

         SetDoubleBuffered(listViewClients, true);          
      }

       private bool Resizing = false;
      void listViewClients_SizeChanged(object sender, EventArgs e)
      {
          // Don't allow overlapping of SizeChanged calls
          if (!Resizing)
          {
              // Set the resizing flag
              Resizing = true;

              ListView listView = sender as ListView;
              if (listView != null)
              {
                  float totalColumnWidth = 0;

                  // Get the sum of all column tags
                  for (int i = 0; i < listView.Columns.Count; i++)
                      totalColumnWidth += Convert.ToInt32(listView.Columns[i].Tag);

                  // Calculate the percentage of space each column should 
                  // occupy in reference to the other columns and then set the 
                  // width of the column to that percentage of the visible space.
                  for (int i = 0; i < listView.Columns.Count; i++)
                  {
                      float colPercentage = (Convert.ToInt32(listView.Columns[i].Tag) / totalColumnWidth);
                      listView.Columns[i].Width = (int)(colPercentage * listView.ClientRectangle.Width);
                  }
              }
          }

          // Clear the resizing flag
          Resizing = false;
      }

      void Application_Idle(object sender, EventArgs e)
      {
         toolStripButtonViewAssociation.Enabled = listViewClients.SelectedItems.Count == 1;
         toolStripButtonDisconnectClient.Enabled = toolStripButtonViewAssociation.Enabled;
      }

      public void ClientConnected(ClientInfo client)
      {
         lock (_listLock)
         {
             _ClientActions[client.Id] = new List<ActionInfo>();
            AddClient(client);             
         }
      }

       public void AddConnectedClients(List<ClientInfo> clients)
      {
           foreach(ClientInfo client in clients)
           {
               ClientConnected(client);
           }
      }

      public void ClientDisconnected(ClientInfo client)
      {
         lock (_listLock)
         {
            RemoveClient(client);
         }
      }

      public void ClientAssociated(ClientInfo client)
      {
         lock (_listLock)
         {
            UpdateClient(client);
         }
      }

      public void SetClientAction(string id, string action,string dataset)
      {
         lock (_listLock)
         {
             ActionInfo actionInfo = new ActionInfo();
            
             if (!string.IsNullOrEmpty(dataset))
             {
                 MemoryStream stream = dataset.ToStream();
                 DicomDataSet ds = new DicomDataSet();

                 try
                 {
                     ds.LoadXml(stream, DicomDataSetLoadXmlFlags.None);
                     if (action.Contains("C-FIND"))
                     {
                         string qr = ds.GetValue<string>(DicomTag.QueryRetrieveLevel, string.Empty);

                         if(!string.IsNullOrEmpty(qr))
                         {
                             action += " [" + qr + "]";
                         }
                     }
                     actionInfo.Dataset = ds;
                 }
                 catch (Exception e)
                 {
                     Debug.WriteLine(e.Message);
                 }
             }

             actionInfo.Action = action;
             _ClientActions[id].Add(actionInfo);     
            SetLastAction(id, action);
         }
      }

      public void Clear()
      {
         lock (_listLock)
         {
             if (listViewClients.Items.Count > 0)
             {
                 listViewClients.Items.Clear();
                 _Scheduler.CancelAll();
             }
         }
      }

       public void PauseScheduler()
      {
          _Scheduler.PauseAllJobs();
      }

       public void ResumeScheduler()
       {
           _Scheduler.ResumeAllJobs();
       }
      
      private void AddClient(ClientInfo client)
      {
         ListViewItem item = listViewClients.Items.Add(client.IpAddress);

         item.Tag = client;
         item.SubItems.Add(client.AETitle);
         item.SubItems.Add(client.ConnectTime.ToString());
         item.SubItems.Add(string.Empty);
         item.SubItems.Add(string.Empty);
         ScheduleUpdateJob(client, item);
      }      


      /// <summary>
      /// Removes the client.
      /// </summary>
      /// <param name="client">The client.</param>
      private void RemoveClient(ClientInfo client)
      {
         foreach (ListViewItem item in listViewClients.Items)
         {
            ClientInfo lvc = item.Tag as ClientInfo;

            if (lvc.Id == client.Id)
            {
               item.Font = new Font(item.Font, FontStyle.Italic);
               item.ForeColor = Color.Red;
               _Scheduler.CancelJob(lvc.Id);
               ScheduleDelete(item);               
               break;
            }
         }
      }

      private void UpdateClient(ClientInfo client)
      {
         foreach (ListViewItem item in listViewClients.Items)
         {
            ClientInfo lvc = item.Tag as ClientInfo;

            if (lvc.Id == client.Id)
            {
               item.Text = client.IpAddress;
               item.SubItems[COLUMN_AETITLE].Text = client.AETitle;
               item.Tag = client;
            }
         }
      }

      private void SetLastAction(string id, string action)
      {
         foreach (ListViewItem item in listViewClients.Items)
         {
            ClientInfo c = item.Tag as ClientInfo;

            if (c.Id == id)
            {
               item.SubItems[COLUMN_ACTION].Text = action;
               break;
            }
         }
      }

      private void toolStripButtonViewAssociation_Click(object sender, EventArgs e)
      {
         ClientInfo client = listViewClients.SelectedItems[0].Tag as ClientInfo;
         AssociationDialog dialog = new AssociationDialog(client);

         dialog.ShowDialog(this);
      }

      private void toolStripButtonDisconnectClient_Click(object sender, EventArgs e)
      {
         OnDisconnectClient(listViewClients.SelectedItems[0].Tag as ClientInfo);
      }

      private void ScheduleDelete(ListViewItem item)
      {
          Job deleteJob = new Job();

          deleteJob.Run.From(DateTime.Now.AddMilliseconds(500)).Once();
          _DeleteScheduler.SubmitJob(deleteJob, job =>
          {
              ClientInfo info = item.Tag as ClientInfo;
             List<ActionInfo> notUsed;

              _ClientActions.TryRemove(info.Id, out notUsed);
              AsyncHelper.SynchronizedInvoke(listViewClients,() => listViewClients.Items.Remove(item));
          });
      }

      private void ScheduleUpdateJob(ClientInfo info, ListViewItem item)
      {
          Job updateJob = new Job(info.Id);

          updateJob.Run.From(DateTime.Now).Every.Milliseconds(300);
          _Scheduler.SubmitJob(updateJob, job =>
          {
              TimeSpan span = DateTime.Now - info.ConnectTime;

              AsyncHelper.SynchronizedInvoke(listViewClients, () =>
              {
                  item.SubItems[COLUMN_TOTAL_CONNECT_TIME].Text = span.ToReadableString();
              });
          });
      }

      private void SetDoubleBuffered(System.Windows.Forms.Control control, bool enable)
      {
          var doubleBufferPropertyInfo = control.GetType().GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);

          doubleBufferPropertyInfo.SetValue(control, enable, null);
      }
   }
}
