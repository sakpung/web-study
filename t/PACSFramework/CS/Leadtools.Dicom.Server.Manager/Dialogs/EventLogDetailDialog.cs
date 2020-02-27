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
using Leadtools.Medical.Winforms;

namespace Leadtools.Dicom.Server.Manager.Dialogs
{
   public partial class EventLogDetailDialog : Form
   {
      public EventLogDetailDialog()
      {
         InitializeComponent();
      }

      private void buttonClose_Click(object sender, EventArgs e)
      {
         Close();
      }
      
      public string ServerAeTitle
      {
         get;
         set;
      }
      
      public string ServerIpAddress
      {
         get;
         set;
      }
      
      public string ServerPort
      {
         get;
         set;
      }
      
       public string ClientAeTitle
      {
         get;
         set;
      }
      
      public string ClientIpAddress
      {
         get;
         set;
      }
      
      public string ClientPort
      {
         get;
         set;
      }
      
      public string Command
      {
         get;
         set;
      }
      
      public string EventDateTime
      {
         get;
         set;
      }
      
      public string Description
      {
         get;
         set;
      }
      
      public string DatasetPath
      {
         get;
         set;
      }

      private void EventLogDetailDialog_Load(object sender, EventArgs e)
      {
         textBoxServerAeTitle.Text = ServerAeTitle;
         textBoxServerIpAddress.Text = ServerIpAddress;
         textBoxServerPort.Text = ServerPort;
         textBoxClientAeTitle.Text = ClientAeTitle;
         textBoxClientHostAddress.Text = ClientIpAddress;
         textBoxClientPort.Text = ClientPort;
         textBoxCommand.Text = Command;
         textBoxEventDateTime.Text = EventDateTime;
         textBoxDescription.Text = Description;
         
         buttonViewDataset.Enabled = !string.IsNullOrEmpty(DatasetPath);
      }

      private void buttonViewDataset_Click(object sender, EventArgs e)
      {
         using (DicomDataSet ds = new DicomDataSet())
         {
            ds.Load(DatasetPath, DicomDataSetLoadFlags.None);
            ViewDatasetDialog dlg = new ViewDatasetDialog(ds);
            dlg.StartPosition = FormStartPosition.CenterParent;
            dlg.ShowDialog(this);
         }
      } 
   }
}
