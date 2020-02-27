// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Leadtools.Ccow.Server.Data;

namespace Leadtools.Ccow.Dialogs
{
   public partial class SubjectDialog : Form
   {
      private CCOWSubject _Subject;
      private Database _db;

      public CCOWSubject Subject
      {
         get
         {
            return _Subject;
         }
         set
         {
            _Subject = value;
         }
      }

      public SubjectDialog(Database db)
      {
         InitializeComponent();
         _Subject = new CCOWSubject();
         _db = db;
         Application.Idle += new EventHandler(Application_Idle);
      }

      void Application_Idle(object sender, EventArgs e)
      {
         listViewApplications.Enabled = Secure.Checked;
         comboBoxSecurityType.Enabled = Secure.Checked;
         buttonItemDelete.Enabled = listViewItems.SelectedItems.Count > 0;
         buttonDependentDelete.Enabled = listViewDependents.SelectedItems.Count > 0;
         buttonDelete.Enabled = listViewApplications.SelectedItems.Count > 0 && Secure.Checked;
         buttonEdit.Enabled = buttonDelete.Enabled;
         buttonAdd.Enabled = Secure.Checked;
      }

      public SubjectDialog(Database db, CCOWSubject subject)
         : this(db)
      {
         _Subject = subject;
         SubjectName.Text = _Subject.Subject;
         Secure.Checked = subject.Secure;
         LoadSubjectItems();
         LoadSubjectDependencies();
      }

      private void SubjectDialog_Load(object sender, EventArgs e)
      {
         listViewApplications.Columns[0].Width = Convert.ToInt32(listViewApplications.ClientRectangle.Width * .75);
         listViewApplications.Columns[1].Width = Convert.ToInt32(listViewApplications.ClientRectangle.Width * .25);
         listViewItems.Columns[0].Width = listViewItems.ClientRectangle.Width;
         listViewDependents.Columns[0].Width = listViewDependents.ClientRectangle.Width;
      }

      private void LoadSubjectItems()
      {
         foreach (CCOWSubjectItems item in _Subject.CCOWSubjectItems)
         {
            ListViewItem i = listViewItems.Items.Add(item.Name);

            i.Tag = item;
         }
      }

      private void LoadSubjectApplications()
      {
         foreach (CCOWSubjectApplication app in _Subject.CCOWSubjectApplication)
         {
            ListViewItem i = listViewApplications.Items.Add(app.CCOWApplication.Name);

            i.SubItems.Add(app.Security);
            i.Tag = app;
         }
      }

      private void LoadSubjectDependencies()
      {
         foreach (CCOWSubjectDependency d in _Subject.DependentSubjects)
         {
            ListViewItem i = listViewDependents.Items.Add(d.CCOWSubject.Subject);

            i.Tag = d.Id;
         }
      }

      private List<string> GetExcludedApps()
      {
         List<string> excluded = new List<string>();

         foreach (ListViewItem item in listViewApplications.Items)
         {
            excluded.Add(item.Text);
         }

         return excluded;
      }

      private void buttonAdd_Click(object sender, EventArgs e)
      {
         List<string> excluded = GetExcludedApps();
         ApplicationListDialog appDialog = new ApplicationListDialog(excluded);

         if (comboBoxSecurityType.Text == "SetGet")
         {
            appDialog.Security = "Seta";
         }
         else
         {
            appDialog.Security = "Set";
         }

         if (appDialog.ShowDialog(this) == DialogResult.OK)
         {
            foreach (CCOWApplication app in appDialog.AllowedApps)
            {
               CCOWSubjectApplication sa = new CCOWSubjectApplication();
               ListViewItem item = listViewApplications.Items.Add(app.Name);

               sa.ApplicationId = app.Id;
               sa.SubjectId = _Subject.Id;
               sa.Id = Guid.NewGuid();
               sa.Security = appDialog.Security;
               item.SubItems.Add(sa.Security);
               _db.CCOWSubjectApplication.InsertOnSubmit(sa);
               item.Tag = sa;
            }
         }
      }

      private void buttonDelete_Click(object sender, EventArgs e)
      {
         foreach (ListViewItem item in listViewApplications.SelectedItems)
         {
            CCOWSubjectApplication app = item.Tag as CCOWSubjectApplication;

            _db.CCOWSubjectApplication.DeleteOnSubmit(app);
            listViewApplications.Items.Remove(item);
         }
      }

      private void buttonItemDelete_Click(object sender, EventArgs e)
      {
         if (_Subject != null)
         {
            CCOWSubjectItems item = listViewItems.SelectedItems[0].Tag as CCOWSubjectItems;

            if (item != null)
            {
               try
               {
                  _db.CCOWSubjectItems.DeleteOnSubmit(item);
                  listViewItems.Items.Remove(listViewItems.SelectedItems[0]);
               }
               catch { }
            }
         }
      }


      private static string InputBox(string Prompt, string Title, string defaultValue)
      {
         InputDialog dlg = new InputDialog();

         dlg.Prompt = Prompt;
         dlg.Title = Title;
         dlg.DefaultValue = defaultValue;
         if (dlg.ShowDialog() == DialogResult.OK)
         {
            return dlg.Response;
         }
         return string.Empty;
      }

      private void buttonItemAdd_Click(object sender, EventArgs e)
      {
         string item = InputBox("Item:", "Enter Subject Item", string.Empty);

         if (item != string.Empty)
         {
            CCOWSubjectItems si = new CCOWSubjectItems();
            ListViewItem i = listViewItems.Items.Add(item);

            si.Id = Guid.NewGuid();
            si.Name = item;
            si.SubjectId = _Subject.Id;
            _db.CCOWSubjectItems.InsertOnSubmit(si);
            i.Tag = si;
         }
      }

      private void SubjectDialog_FormClosing(object sender, FormClosingEventArgs e)
      {
         if (DialogResult == DialogResult.OK)
         {
            _Subject.Subject = SubjectName.Text;
            _Subject.Secure = Secure.Checked;
            if (Secure.Checked)
               _Subject.SecurityType = comboBoxSecurityType.Text;
            else
               _Subject.SecurityType = null;
         }
      }

      private void buttonDependentAdd_Click(object sender, EventArgs e)
      {
         List<string> exclude = new List<string>();
         SubjectListDialog dialog;

         exclude.Add(SubjectName.Text);
         foreach (ListViewItem item in listViewDependents.Items)
         {
            exclude.Add(item.Text);
         }

         dialog = new SubjectListDialog(exclude);
         if (dialog.ShowDialog(this) == DialogResult.OK)
         {
            foreach (CCOWSubject subject in dialog.Subjects)
            {
               ListViewItem item = listViewDependents.Items.Add(subject.Subject);
               CCOWSubjectDependency d = new CCOWSubjectDependency();

               d.Id = Guid.NewGuid();
               item.Tag = d.Id;
               d.SubjectId = _Subject.Id;
               d.DependentSubjectId = subject.Id;
               _db.CCOWSubjectDependency.InsertOnSubmit(d);
            }
         }
      }

      private void buttonDependentDelete_Click(object sender, EventArgs e)
      {
         Guid guid = (Guid)listViewDependents.SelectedItems[0].Tag;
         CCOWSubjectDependency d = _db.CCOWSubjectDependency.First(sd => sd.Id == guid);

         _db.CCOWSubjectDependency.DeleteOnSubmit(d);
         listViewDependents.Items.Remove(listViewDependents.SelectedItems[0]);
      }

      private void Secure_CheckedChanged(object sender, EventArgs e)
      {
         listViewApplications.Items.Clear();
         if (Secure.Checked)
         {
            LoadSubjectApplications();
            if (string.IsNullOrEmpty(_Subject.SecurityType))
               comboBoxSecurityType.SelectedIndex = 0;
            else
               comboBoxSecurityType.Text = _Subject.SecurityType;
         }
         else
            comboBoxSecurityType.SelectedIndex = -1;
      }

      private void buttonEdit_Click(object sender, EventArgs e)
      {
         ApplicationSecurityDialog dlgSecurity = new ApplicationSecurityDialog();

         if (listViewApplications.SelectedItems.Count > 1)
            dlgSecurity.Security = string.Empty;
         else
         {
            CCOWSubjectApplication app = listViewApplications.SelectedItems[0].Tag as CCOWSubjectApplication;

            dlgSecurity.Security = app.Security;
         }

         if (dlgSecurity.ShowDialog(this) == DialogResult.OK)
         {
            CCOWSubjectApplication app = null;

            if (listViewApplications.SelectedItems.Count > 1)
            {
               foreach (ListViewItem item in listViewApplications.Items)
               {
                  app = item.Tag as CCOWSubjectApplication;
                  app.Security = dlgSecurity.Security;
                  item.SubItems[1].Text = app.Security;
               }
            }
            else
            {
               app = listViewApplications.SelectedItems[0].Tag as CCOWSubjectApplication;

               app.Security = dlgSecurity.Security;
               listViewApplications.SelectedItems[0].SubItems[1].Text = app.Security;
            }
         }
      }
   }
}
