// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Data.Linq;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Leadtools.Ccow.Server;
using Leadtools.Ccow.Server.Data;

namespace Leadtools.Ccow.Dialogs
{
   public partial class ConfigurationDialog : Form
   {
      public ConfigurationDialog(string address)
      {
         InitializeComponent();

         if (string.IsNullOrEmpty(address))
         {
            labelCcowWebNote.Visible = true;
            webAdress.Text = string.Empty;
         }
         else
         {
            labelCcowWebNote.Visible = false;
            webAdress.Text = address;
         }
      }

      private void ConfigurationDialog_Load(object sender, EventArgs e)
      {
         listViewApplications.Columns[0].Width = listViewApplications.ClientRectangle.Width;
         listViewSubjects.Columns[0].Width = Convert.ToInt32(listViewSubjects.ClientRectangle.Width * .75);
         listViewSubjects.Columns[1].Width = Convert.ToInt32(listViewSubjects.ClientRectangle.Width * .25);
         Application.Idle += new EventHandler(Application_Idle);
         listViewApplications.ItemChecked -= listViewApplications_ItemChecked;
         LoadApplications();
         LoadSubjects();
         LoadConfiguration();
         listViewApplications.ItemChecked += new ItemCheckedEventHandler(listViewApplications_ItemChecked);
         buttonApplyConfig.Enabled = false;
      }

      public void Restore()
      {
         LoadApplications();
         LoadSubjects();
         LoadConfiguration();
      }

      void Application_Idle(object sender, EventArgs e)
      {
         int maxApps = Config.Get<int>("MaxParticipants", -1);

         buttonDelete.Enabled = listViewApplications.SelectedItems.Count > 0;
         buttonEdit.Enabled = buttonDelete.Enabled;
         buttonDeleteSubject.Enabled = listViewSubjects.SelectedItems.Count > 0;
         buttonEditSubject.Enabled = buttonDeleteSubject.Enabled;
         buttonAllowAll.Enabled = listViewApplications.Items.Count > 0;
         buttonAllowNone.Enabled = listViewApplications.CheckedItems.Count > 0;
         buttonAdd.Enabled = maxApps == -1 || listViewApplications.Items.Count < maxApps;
      }

      /// <summary>
      /// Loads the registered applications.
      /// </summary>
      private void LoadApplications()
      {
         listViewApplications.Items.Clear();
         using (Database db = Leadtools.Ccow.Server.Utils.GetDatabase())
         {
            foreach (CCOWApplication app in db.CCOWApplication)
            {
               AddApplication(app);
            }
         }
      }

      private void LoadConfiguration()
      {
         MaxParticipants.Value = Config.Get<decimal>("MaxParticipants", -1);
         TransactionTimeout.Value = Config.Get<decimal>("TransactionTimeout", 60000);
         ActionTimeout.Value = Config.Get<decimal>("WaitForActionTimeout", 30000);
         NotificationTimeout.Value = Config.Get<decimal>("NotificationTimeout", 15000);
         NotificationRetryInterval.Value = Config.Get<decimal>("NotificationRetryInterval", 15000);
         PingNotificationTimeout.Value = Config.Get<decimal>("PingTimeout", 3000);
         PingInterval.Value = Config.Get<decimal>("PingRetryTimeout", 5000);
         checkBoxPing.Checked = Config.Get<bool>("PingParticipants", false);
      }

      /// <summary>
      /// Loads the subjects supported by the CCOW Server.
      /// </summary>
      private void LoadSubjects()
      {
         listViewSubjects.Items.Clear();
         using (Database db = Leadtools.Ccow.Server.Utils.GetDatabase())
         {
            foreach (CCOWSubject subject in db.CCOWSubject.ToList())
            {
               AddSubject(subject);
            }
         }
      }

      private void AddApplication(CCOWApplication app)
      {
         ListViewItem item = listViewApplications.Items.Add(app.Name);

         item.Checked = app.Allowed.Value;
         item.ImageIndex = !string.IsNullOrEmpty(app.Passcode) ? 0 : -1;
         item.Tag = app.Id;
      }

      private void AddSubject(CCOWSubject subject)
      {
         ListViewItem item = listViewSubjects.Items.Add(subject.Subject);

         item.ImageIndex = subject.Secure ? 0 : -1;
         item.SubItems.Add(!string.IsNullOrEmpty(subject.SecurityType) ? subject.SecurityType : string.Empty);
         item.Tag = subject.Id;
      }

      private void UpdateItem(ListViewItem item, CCOWApplication app)
      {
         item.Checked = app.Allowed.Value;
         item.ImageIndex = !string.IsNullOrEmpty(app.Passcode) ? 0 : -1;
         item.Text = app.Name;
      }

      private void UpdateItem(ListViewItem item, CCOWSubject subject)
      {
         item.Text = subject.Subject;
         item.SubItems[1].Text = !string.IsNullOrEmpty(subject.SecurityType) ? subject.SecurityType : string.Empty;
         item.ImageIndex = subject.Secure ? 0 : -1;
      }

      private void AllowApplications(bool allow)
      {

         foreach (ListViewItem item in listViewApplications.Items)
         {
            item.Checked = allow;
         }
      }

      private void listViewApplications_ItemChecked(object sender, ItemCheckedEventArgs e)
      {
         if (e.Item.Tag == null)
            return;

         Monitor.Enter(CcowServer.LockObject);
         try
         {
            using (Database db = Leadtools.Ccow.Server.Utils.GetDatabase())
            {
               Guid appId = (Guid)e.Item.Tag;
               CCOWApplication app = db.CCOWApplication.First(a => a.Id == appId);

               app.Allowed = e.Item.Checked;
               db.SubmitChanges();
            }
         }
         finally
         {
            Monitor.Exit(CcowServer.LockObject);
         }
      }

      private void buttonAdd_Click(object sender, EventArgs e)
      {
         ApplicationDialog addDialog = new ApplicationDialog();

         if (addDialog.ShowDialog(this) == DialogResult.OK)
         {
            Monitor.Enter(CcowServer.LockObject);
            try
            {
               using (Database db = Leadtools.Ccow.Server.Utils.GetDatabase())
               {
                  db.CCOWApplication.InsertOnSubmit(addDialog.App);
                  db.SubmitChanges();
                  AddApplication(addDialog.App);
               }
            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
               Monitor.Exit(CcowServer.LockObject);
            }
         }
      }

      private void buttonDelete_Click(object sender, EventArgs e)
      {
         Monitor.Enter(CcowServer.LockObject);
         try
         {
            using (Database db = Leadtools.Ccow.Server.Utils.GetDatabase())
            {
               Guid appId = (Guid)listViewApplications.SelectedItems[0].Tag;
               CCOWApplication app = db.CCOWApplication.First(a => a.Id == appId);

               try
               {
                  db.CCOWApplication.DeleteOnSubmit(app);
                  db.SubmitChanges();
                  listViewApplications.Items.Remove(listViewApplications.SelectedItems[0]);
               }
               catch (Exception ex)
               {
                  MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
               }
            }
         }
         finally
         {
            Monitor.Exit(CcowServer.LockObject);
         }
      }

      private void buttonEdit_Click(object sender, EventArgs e)
      {
         Monitor.Enter(CcowServer.LockObject);
         try
         {
            using (Database db = Leadtools.Ccow.Server.Utils.GetDatabase())
            {
               Guid appId = (Guid)listViewApplications.SelectedItems[0].Tag;
               CCOWApplication app = db.CCOWApplication.First(a => a.Id == appId);
               ApplicationDialog addDialog = new ApplicationDialog(app);

               if (addDialog.ShowDialog(this) == DialogResult.OK)
               {
                  try
                  {
                     db.SubmitChanges();
                     UpdateItem(listViewApplications.SelectedItems[0], app);
                  }
                  catch (Exception ex)
                  {
                     MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                  }
               }
            }
         }
         finally
         {
            Monitor.Exit(CcowServer.LockObject);
         }
      }

      private void buttonAddSubject_Click(object sender, EventArgs e)
      {
         try
         {
            using (Database db = Leadtools.Ccow.Server.Utils.GetDatabase())
            {
               SubjectDialog subjectDialog = new SubjectDialog(db);
               bool doAdd = true;

               try
               {
                  Monitor.Enter(CcowServer.LockObject);
                  subjectDialog.Subject = new CCOWSubject() { Id = Guid.NewGuid() };
                  db.CCOWSubject.InsertOnSubmit(subjectDialog.Subject);
               }
               catch (Exception ex)
               {
                  MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                  doAdd = false;
               }
               finally
               {
                  Monitor.Exit(CcowServer.LockObject);
               }

               if (doAdd)
               {
                  if (subjectDialog.ShowDialog(this) == DialogResult.OK)
                  {
                     try
                     {
                        Monitor.Enter(CcowServer.LockObject);
                        db.SubmitChanges();
                        AddSubject(subjectDialog.Subject);
                     }
                     catch (Exception ex)
                     {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                     }
                     finally
                     {
                        Monitor.Exit(CcowServer.LockObject);
                     }
                  }
               }
            }
         }
         catch (Exception exception)
         {
            MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
      }

      private void buttonEditSubject_Click(object sender, EventArgs e)
      {
         try
         {
            using (Database db = Leadtools.Ccow.Server.Utils.GetDatabase())
            {
               DataLoadOptions o = new DataLoadOptions();
               Guid subjectid = (Guid)listViewSubjects.SelectedItems[0].Tag;
               SubjectDialog subjectDialog;
               CCOWSubject subject;

               o.LoadWith<CCOWSubjectItems>(i => i.CCOWSubject);
               o.LoadWith<CCOWSubjectDependency>(d => d.CCOWSubject);
               o.LoadWith<CCOWSubjectApplication>(f => f.CCOWApplication);
               db.LoadOptions = o;

               try
               {
                  Monitor.Enter(CcowServer.LockObject);
                  subject = db.CCOWSubject.First(s => s.Id == subjectid);
               }
               finally
               {
                  Monitor.Exit(CcowServer.LockObject);
               }

               subjectDialog = new SubjectDialog(db, subject);

               if (subjectDialog.ShowDialog(this) == DialogResult.OK)
               {
                  try
                  {
                     Monitor.Enter(CcowServer.LockObject);
                     db.SubmitChanges();
                     UpdateItem(listViewSubjects.SelectedItems[0], subject);
                  }
                  catch (Exception ex)
                  {
                     MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                  }
                  finally
                  {
                     Monitor.Exit(CcowServer.LockObject);
                  }
               }
            }
         }
         catch (Exception exception)
         {
            MessageBox.Show(exception.Message, "Database access failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
      }

      private void buttonDeleteSubject_Click(object sender, EventArgs e)
      {
         Monitor.Enter(CcowServer.LockObject);
         try
         {
            using (Database db = Leadtools.Ccow.Server.Utils.GetDatabase())
            {
               DataLoadOptions o = new DataLoadOptions();
               Guid subjectid = (Guid)listViewSubjects.SelectedItems[0].Tag;
               CCOWSubject subject = null;

               o.LoadWith<CCOWSubjectItems>(i => i.CCOWSubject);
               o.LoadWith<CCOWSubjectDependency>(d => d.CCOWSubject);
               db.LoadOptions = o;

               subject = db.CCOWSubject.First(s => s.Id == subjectid);
               foreach (CCOWSubjectDependency d in subject.CCOWSubjectDependency)
               {
                  db.GetTable<CCOWSubjectDependency>().DeleteOnSubmit(d);
               }

               foreach (CCOWSubjectItems i in subject.CCOWSubjectItems)
               {
                  db.GetTable<CCOWSubjectItems>().DeleteOnSubmit(i);
               }

               db.CCOWSubject.DeleteOnSubmit(subject);
               db.SubmitChanges();
               listViewSubjects.Items.Remove(listViewSubjects.SelectedItems[0]);
            }
         }
         finally
         {
            Monitor.Exit(CcowServer.LockObject);
         }
      }

      private void listViewSubjects_DoubleClick(object sender, EventArgs e)
      {
         if (listViewSubjects.SelectedItems.Count > 0)
         {
            buttonEditSubject_Click(buttonEditSubject, EventArgs.Empty);
         }
      }

      private void ConfigurationDialog_FormClosing(object sender, FormClosingEventArgs e)
      {
         if (e.CloseReason == CloseReason.UserClosing)
         {
            e.Cancel = true;
            Hide();
         }
      }

      protected override void OnFormClosing(FormClosingEventArgs e)
      {
         base.OnFormClosing(e);
      }

      private void buttonOK_Click(object sender, EventArgs e)
      {
         Hide();
      }

      private void buttonAllowAll_Click(object sender, EventArgs e)
      {
         AllowApplications(true);
      }

      private void buttonAllowNone_Click(object sender, EventArgs e)
      {
         AllowApplications(false);
      }

      private void ConfigChanged(object sender, EventArgs e)
      {
         buttonApplyConfig.Enabled = true;
         PingNotificationTimeout.Enabled = checkBoxPing.Checked;
         PingInterval.Enabled = checkBoxPing.Checked;
      }

      private void buttonApplyConfig_Click(object sender, EventArgs e)
      {
         Config.Set<decimal>("MaxParticipants", MaxParticipants.Value);
         Config.Set<decimal>("TransactionTimeout", TransactionTimeout.Value);
         Config.Set<decimal>("WaitForActionTimeout", ActionTimeout.Value);
         Config.Set<decimal>("NotificationTimeout", NotificationTimeout.Value);
         Config.Set<decimal>("NotificationRetryInterval", NotificationRetryInterval.Value);
         Config.Set<decimal>("PingTimeout", PingNotificationTimeout.Value);
         Config.Set<decimal>("PingRetryTimeout", PingInterval.Value);
         Config.Set<bool>("PingParticipants", checkBoxPing.Checked);

         buttonApplyConfig.Enabled = false;
      }

      private void ConfigEdit_KeyPress(object sender, KeyPressEventArgs e)
      {
         if (e.KeyChar == '-')
         {
            if (sender == MaxParticipants)
            {
            }
            else
               e.Handled = true;
         }
         else
            if ((Keys)e.KeyChar != Keys.Back && !char.IsNumber(e.KeyChar))
               e.Handled = true;
         if ((Keys)e.KeyChar == Keys.Back && (sender as TextBox).TextLength == 1)
            e.Handled = true;
      }
   }
}
