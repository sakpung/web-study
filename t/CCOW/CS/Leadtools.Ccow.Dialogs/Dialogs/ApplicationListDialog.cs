// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Leadtools.Ccow.Server;
using Leadtools.Ccow.Server.Data;

namespace Leadtools.Ccow.Dialogs
{
   public partial class ApplicationListDialog : Form
   {
      private List<CCOWApplication> _AllowedApps = new List<CCOWApplication>();
      public List<CCOWApplication> AllowedApps
      {
         get
         {
            return _AllowedApps;
         }
      }

      public string Security
      {
         get { return comboBoxSecurityType.Text; }
         set { comboBoxSecurityType.Text = value; }
      }

      private List<string> _Excluded = new List<string>();

      public ApplicationListDialog(List<string> excluded)
      {
         InitializeComponent();
         listViewApplications.Columns[0].Width = listViewApplications.ClientRectangle.Width;
         _Excluded.AddRange(excluded);
      }

      private void ApplicationListDialog_Load(object sender, EventArgs e)
      {
         Monitor.Enter(CcowServer.LockObject);
         try
         {
            using (Database context = Leadtools.Ccow.Server.Utils.GetDatabase())
            {
               List<CCOWApplication> apps = (from a in context.CCOWApplication
                                             where a.Allowed == true &&
                                             a.Passcode != string.Empty && a.Passcode != null &&
                                             !_Excluded.Contains(a.Name)
                                             select a).ToList();


               foreach (CCOWApplication app in apps)
               {
                  ListViewItem item = listViewApplications.Items.Add(app.Name);

                  item.Tag = app;
               }
            }
         }
         finally
         {
            Monitor.Exit(CcowServer.LockObject);
         }
      }

      private void ApplicationListDialog_FormClosing(object sender, FormClosingEventArgs e)
      {
         if (DialogResult == DialogResult.OK)
         {
            foreach (ListViewItem item in listViewApplications.SelectedItems)
            {
               CCOWApplication app = item.Tag as CCOWApplication;

               _AllowedApps.Add(app);
            }
         }
      }
   }
}
