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
   public partial class SubjectListDialog : Form
   {
      private List<string> _Excluded = new List<string>();

      private List<CCOWSubject> _Subjects = new List<CCOWSubject>();
      public List<CCOWSubject> Subjects
      {
         get
         {
            return _Subjects;
         }
      }

      public SubjectListDialog()
      {
         InitializeComponent();
      }

      public SubjectListDialog(List<string> excluded)
         : this()
      {
         _Excluded.AddRange(excluded);
         listViewSubjects.Columns[0].Width = listViewSubjects.ClientRectangle.Width;
      }

      private void SubjectListDialog_Load(object sender, EventArgs e)
      {
         Monitor.Enter(CcowServer.LockObject);
         try
         {
            using (Database db = Leadtools.Ccow.Server.Utils.GetDatabase())
            {
               List<CCOWSubject> subjects = (from s in db.CCOWSubject
                                             where !_Excluded.Contains(s.Subject)
                                             select s).ToList();


               foreach (CCOWSubject subject in subjects)
               {
                  ListViewItem item = listViewSubjects.Items.Add(subject.Subject);

                  item.Tag = subject;
               }
            }
         }
         finally
         {
            Monitor.Exit(CcowServer.LockObject);
         }
      }

      private void SubjectListDialog_FormClosing(object sender, FormClosingEventArgs e)
      {
         if (DialogResult == DialogResult.OK)
         {
            foreach (ListViewItem item in listViewSubjects.SelectedItems)
            {
               _Subjects.Add(item.Tag as CCOWSubject);
            }
         }
      }
   }
}
