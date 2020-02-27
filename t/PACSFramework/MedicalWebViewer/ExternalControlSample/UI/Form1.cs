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
using Leadtools.Medical.WebViewer.ExternalControl;
using ExternalControlSample;
using System.Diagnostics;
using Leadtools.Medical.Storage.DataAccessLayer;
using Leadtools.Medical.DataAccessLayer;
using Leadtools.Medical.Storage.DataAccessLayer.Configuration;
using System.Threading;
using Leadtools.Demos;

namespace ExternalControlSample
{
   public partial class Form1 : Form
   {
      public Form1()
      {
         InitializeComponent();
      }

      private int _port = 501;
      private int _timeout = 10;
      private MedicalWebViewerExternalController _controller = null;
      private string _currentUserName = string.Empty;
      private string _currentPassword = string.Empty;
      private MedicalWebViewerBrowser _selectedBrowser = MedicalWebViewerBrowser.InternetExplorer;

      PatientInfo[] samplePatientInfo = new PatientInfo[]
      {
      new PatientInfo("1111", "Smith^Joe^A^Mr^III",      "01/02/1995", "M", "Group1111", "Comments 1111"),
      new PatientInfo("2222", "Jones^Amy^B^^",           "06/05/1961", "F", "Group2222", "Comments 2222"),
      new PatientInfo("3333", "Williams^Kirklin^M^Sir^", "03/08/2000", "M", "Group3333", "Comments 3333"),
      new PatientInfo("4444", "Anderson^Scott^K^^Jr",    "05/16/2003", "M", "Group4444", "Comments 4444"),
      };

      private void Form1_Load(object sender, EventArgs e)
      {
         try
         {
#if LEADTOOLS_V20_OR_LATER
          _controller = new MedicalWebViewerExternalController("http://localhost/MedicalViewer20");
          _controller.ServiceURL = @"http://localhost/MedicalViewerServiceWcf20";
#else
          _controller = new MedicalWebViewerExternalController("http://localhost/MedicalViewer19");
          _controller.ServiceURL = @"http://localhost/MedicalViewerService19";
#endif 
            _controller.BrowserClosed +=new EventHandler<EventArgs>(_controller_BrowserClosed);

          _controller.HeartBeatEvent += new EventHandler<HeartBeatEventArgs>(_controller_HeartBeatEvent);
          _controller.LogoutEvent += new EventHandler<LogoutEventArgs>(_controller_LogoutEvent);
         // Setup Logger
         Logger.ListViewLog = this.listViewLog;
         Logger.Controller = _controller;

         Form1 mainForm = sender as Form1;
         if (mainForm != null)
         {
            mainForm.tabControl1.TabPages.Remove(tabPagePatientInformation);
         }


         // View Instances Tab         
         linkLabelImage.Visible = false;

         // Patient Information Tab
         radioButtonFindPatientAll.Checked = true;

         // Update Patient Tab

         // Add Patient Tab

         patientListControlSample.ListViewPatients.SelectedIndexChanged += new EventHandler(ListViewPatients_SelectedIndexChanged);
         patientListControlSample.Populate(samplePatientInfo);
         patientControlAddPatient.Initialize(patientListControlSample.ListViewPatients);

         patientControlUpdatePatient.Initialize(null);
         patientControlUpdatePatient.ComboBoxPatientId.SelectedIndexChanged += new EventHandler(comboBoxUpdatePatient_SelectedIndexChanged);

         // Update Users Tab
         usersControlUpdateUser.ComboBoxUserName.SelectedIndexChanged += new EventHandler(ComboBoxUserName_SelectedIndexChanged);

         // Add Users Tab

         // Error Provider
         TextBox tbPatientId = patientControlAddPatient.TextBoxPatientId;
         tbPatientId.TextChanged += new EventHandler(tbPatientId_TextChanged);
         errorProvider1.SetIconAlignment(tbPatientId, ErrorIconAlignment.MiddleLeft);

         UpdateUI();
         }
         catch (Exception ex)
         {
             MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
             Close();
         }
      }

      void _controller_LogoutEvent(object sender, LogoutEventArgs e)
      {
         if (_controller != null && _controller.IsLoggedIn)
         {
            Logger.LogControllerResult("UserLogout", ControllerReturnCode.Success);
         }
         LogoutAndCleanup();
      }

      delegate void HeartBeatReceivedCallback(int count);
      void HeartBeatReceived(int count)
      {
         //if (this.InvokeRequired)
         //{
         //   HeartBeatReceivedCallback cb = new HeartBeatReceivedCallback(HeartBeatReceived);
         //   this.Invoke(cb, count);
         //   return;
         //}

         //Logger.LogMessage("Heart Beat", count.ToString());
      }

      void _controller_HeartBeatEvent(object sender, HeartBeatEventArgs e)
      {
         HeartBeatReceived(e.Count);
      }

      void  _controller_BrowserClosed(object sender, EventArgs e)
      {
         LogoutAndCleanup();
      }

      void tbPatientId_TextChanged(object sender, EventArgs e)
      {
         TextBox tb = sender as TextBox;
         if (tb != null)
         {
            errorProvider1.SetError(tb, "");
         }
      }

      void ComboBoxUserName_SelectedIndexChanged(object sender, EventArgs e)
      {
         List<string> userPermissions = new List<string>();
         List<string> userRoles = new List<string>();

         string username = usersControlUpdateUser.ComboBoxUserName.Text;
         if (!string.IsNullOrEmpty(username))
         {
            _controller.GetUserPermissions(username, userPermissions);
            _controller.GetUserRoles(username, userRoles);
         }

         usersControlUpdateUser.Permissions = userPermissions;
         usersControlUpdateUser.Roles = userRoles;
      }


      void ListViewPatients_SelectedIndexChanged(object sender, EventArgs e)
      {
         patientControlAddPatient.UpdatePatient();
      }

      delegate void UpdateUICallback();

      private void UpdateUI()
      {
         if (tabControl1.InvokeRequired)
         {
            UpdateUICallback cb = new UpdateUICallback(UpdateUI);
            this.Invoke(cb);
         }

         else
         {
            menuItemLogin.Enabled = !_controller.IsLoggedIn;
            menuItemLogout.Enabled = _controller.IsLoggedIn;
            tabControl1.Enabled = _controller.IsLoggedIn;

            if (_controller != null && _controller.IsLoggedIn)
            {
               List<Permission> permissionList = new List<Permission>();
               ControllerReturnCode ret = _controller.GetPermissions(permissionList);

               List<Role> roleList = new List<Role>();
               ret = _controller.GetRoles(roleList);

               // Update Users Tab
               usersControlUpdateUser.InitializeDefaults(permissionList, roleList);

               // Add Users Tab
               usersControlAddUser.InitializeDefaults(permissionList, roleList);
            }
         }
      }

      void Stop()
      {
         if (_controller.IsStarted)
         {
            ControllerReturnCode ret = _controller.Shutdown();
            Logger.LogControllerResult("Shutdown", ret);
         }
         UpdateUI();
      }

      // returns 'true' if sending logout message to browser
      // returns 'false' if not logged in
      bool Logout()
      {
         bool updateUI = false;
         bool sentLogout = false;
         if (_controller != null && _controller.IsLoggedIn)
         {
            ControllerReturnCode ret = _controller.UserLogout();
            Logger.LogControllerResult("UserLogout", ret);
            updateUI = true;
            sentLogout = true;
         }

         if (_controller != null && _controller.IsStarted)
         {
            // _controller.CloseApplication();
            updateUI = true;
         }
         if (updateUI)
         {
            UpdateUI();
         }
         return sentLogout;
      }

      private void buttonClearLog_Click(object sender, EventArgs e)
      {
         listViewLog.Items.Clear();
      }

      private void buttonShowPatient_Click(object sender, EventArgs e)
      {
         string patientId = comboBoxPatientIdViewInstances.Text.Trim();

         ControllerReturnCode ret = _controller.ShowPatient(patientId);
         Logger.LogControllerResult("ShowPatient", ret);
         if (ret == ControllerReturnCode.Success)
         {
            Logger.LogMessage(string.Empty, string.Format("PatientId: {0}", patientId));
         }
      }

      private void buttonShowStudy_Click(object sender, EventArgs e)
      {
         string studyInstanceUid = comboBoxStudyInstanceUid.Text.Trim();
         ControllerReturnCode ret = _controller.ShowStudy(studyInstanceUid);
         Logger.LogControllerResult("ShowStudy", ret);
         if (ret == ControllerReturnCode.Success)
         {
            Logger.LogMessage(string.Empty, string.Format("StudyInstanceUid: {0}", studyInstanceUid));
         }
      }

      private void buttonShowSeries_Click(object sender, EventArgs e)
      {
         string seriesInstanceUid = comboBoxSeriesInstanceUid.Text.Trim();
         ControllerReturnCode ret = _controller.ShowSeries(seriesInstanceUid);
         Logger.LogControllerResult("ShowSeries", ret);
         if (ret == ControllerReturnCode.Success)
         {
            Logger.LogMessage(string.Empty, string.Format("SeriesInstanceUid: {0}", seriesInstanceUid));
         }
      }

      private void buttonFindPatient_Click(object sender, EventArgs e)
      {
         string patientId = comboBoxPatientIdPatientInformation.Text.Trim();
         FindPatientOptions options = radioButtonFindPatientAll.Checked ? FindPatientOptions.All : FindPatientOptions.WithInstances;
         PatientInfo info = new PatientInfo();

         List<PatientInfo> patients = new List<PatientInfo>();
         ControllerReturnCode ret = _controller.FindPatient(patientId, options, patients);
         Logger.LogControllerResult("FindPatient", ret);
         if (ret == ControllerReturnCode.Success)
         {
            Logger.LogMessage(patients[0]);
         }
      }

      private void buttonGetImage_Click(object sender, EventArgs e)
      {
         string imagePath = _controller.GetImage(comboBoxSopInstanceUid.Text);

         bool validPath = !string.IsNullOrEmpty(imagePath);

         linkLabelImage.Visible = validPath;

         Logger.LogMessage("GetImage: ", string.Format("'{0}'", imagePath));
         linkLabelImage.Text = imagePath;
         linkLabelImage.LinkVisited = false;
      }

      private void linkLabelImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
      {
         string url;
         if (e.Link.LinkData != null)
            url = e.Link.LinkData.ToString();
         else
            url = linkLabelImage.Text.Substring(e.Link.Start, e.Link.Length);

         if (!url.Contains("://"))
            url = "http://" + url;

         var si = new ProcessStartInfo(url);
         Process.Start(si);
         linkLabelImage.LinkVisited = true;
      }

      private void buttonUpdatePatient_Click(object sender, EventArgs e)
      {
         PatientInfo info = patientControlUpdatePatient.GetPatientInfo();

         info.PatientId = patientControlUpdatePatient.ComboBoxPatientId.GetItemText(patientControlUpdatePatient.ComboBoxPatientId.SelectedItem);

         ControllerReturnCode ret = _controller.UpdatePatient(info);
         Logger.LogControllerResult("UpdatePatient", ret);
         if (ret == ControllerReturnCode.Success)
         {
            Logger.LogMessage(info);
         }
      }

      private void buttonAddPatient_Click(object sender, EventArgs e)
      {
         PatientInfo info = patientControlAddPatient.GetPatientInfo();
         if (string.IsNullOrEmpty(info.PatientId))
         {
            string msg = "'Patient ID' must contain a value.";
            TextBox tbPatientId = patientControlAddPatient.TextBoxPatientId;
            errorProvider1.SetError(tbPatientId, msg);
            Logger.LogMessage("AddPatient", "Error: " + msg);
            return;
         }
         ControllerReturnCode ret = _controller.AddPatient(info);
         Logger.LogControllerResult("AddPatient", ret);
         if (ret == ControllerReturnCode.Success)
         {
            Logger.LogMessage(info);
         }
      }

      private void buttonDeletePatient_Click(object sender, EventArgs e)
      {
         string patientId = patientControlUpdatePatient.ComboBoxPatientId.GetItemText(patientControlUpdatePatient.ComboBoxPatientId.SelectedItem);

         if (string.IsNullOrEmpty(patientId))
            return;

         string msg = string.Format("Delete patient with PatientId: '{0}'?", patientId);
         if (DialogResult.No == MessageBox.Show(this, msg, "Delete Patient", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            return;

         ControllerReturnCode ret = _controller.DeletePatient(patientId);
         Logger.LogControllerResult("DeletePatient", ret);
         if (ret == ControllerReturnCode.Success)
         {
            Logger.LogMessage(string.Empty, string.Format("Patient Deleted: PatientId {0}: ", patientId));
            IntializeTabUpdatePatient();
            UpdateUI_TabUpdatePatient();
         }
      }


      private void buttonGetCurrentPatient_Click(object sender, EventArgs e)
      {
         PatientInfo info = new PatientInfo();
         ControllerReturnCode ret = _controller.GetCurrentPatient(out info);
         Logger.LogControllerResult("GetCurrentPatient", ret);
         if (ret == ControllerReturnCode.Success)
         {
            Logger.LogMessage(info);
         }
      }


      private void UpdateUI_TabUpdatePatient()
      {
         if (patientControlUpdatePatient.ComboBoxPatientId.Items.Count > 0)
         {
            string patientId = patientControlUpdatePatient.ComboBoxPatientId.GetItemText(patientControlUpdatePatient.ComboBoxPatientId.SelectedItem);
            if (!string.IsNullOrEmpty(patientId))
            {
               List<PatientInfo> patients = new List<PatientInfo>();
               ControllerReturnCode ret = _controller.FindPatient(patientId, FindPatientOptions.All, patients);
               if (ret == ControllerReturnCode.Success)
               {
                  patientControlUpdatePatient.UpdatePatient(patients[0]);
               }
            }
         }
         else
         {
             patientControlUpdatePatient.UpdatePatient(null);
         }
      }

      private string PopulatePatientIdComboBox(ComboBox cb)
      {
         cb.Items.Clear();

         List<PatientInfo> patients = new List<PatientInfo>();
         ControllerReturnCode ret = _controller.FindPatient(null, FindPatientOptions.All, patients, MaxQueryResults.Patient);
         if (ret != ControllerReturnCode.Success)
         {
            Logger.LogControllerResult("FindPatient", ret);
         }

         foreach (PatientInfo p in patients)
         {
            cb.Items.Add(p.PatientId);
         }

         if (cb.Items.Count > 0)
         {
            cb.SelectedIndex = 0;
         }

         return cb.Text;
      }

      private string PopulateStudyInstanceUidComboBox(string patientId, ComboBox cb)
      {
         cb.Items.Clear();

         List<StudyInfo> studies = new List<StudyInfo>();
         ControllerReturnCode ret = _controller.FindStudies(patientId, studies);
         if (ret != ControllerReturnCode.Success)
         {
            Logger.LogControllerResult("FindStudies", ret);
         }

         foreach (StudyInfo p in studies)
         {
            cb.Items.Add(p.StudyInstanceUid);
         }

         if (cb.Items.Count > 0)
         {
            cb.SelectedIndex = 0;
         }

         return cb.Text;
      }

      private string PopulateSeriesInstanceUidComboBox(string patientId, string studyinstanceUid, ComboBox cb)
      {
         cb.Items.Clear();

         List<SeriesInfo> series = new List<SeriesInfo>();
         ControllerReturnCode ret = _controller.FindSeries(patientId, studyinstanceUid, series);
         if (ret != ControllerReturnCode.Success)
         {
            Logger.LogControllerResult("FindSeries", ret);
         }

         foreach (SeriesInfo p in series)
         {
            cb.Items.Add(p.SeriesInstanceUid);
         }

         if (cb.Items.Count > 0)
         {
            cb.SelectedIndex = 0;
         }

         return cb.Text;
      }

      private string PopulateSopInstanceUidComboBox(string patientId, string studyInstanceUid, string seriesInstanceUid, ComboBox cb)
      {
         cb.Items.Clear();

         List<InstanceInfo> instances = new List<InstanceInfo>();
         ControllerReturnCode ret = _controller.FindInstances(patientId, studyInstanceUid, seriesInstanceUid, instances);
         if (ret != ControllerReturnCode.Success)
         {
            Logger.LogControllerResult("FindInstances", ret);
         }

         foreach (InstanceInfo p in instances)
         {
            cb.Items.Add(p.SopInstanceUid);
         }

         if (cb.Items.Count > 0)
         {
            cb.SelectedIndex = 0;
         }

         return cb.Text;
      }

      private void IntializeTabUpdatePatient()
      {
         PopulatePatientIdComboBox(patientControlUpdatePatient.ComboBoxPatientId);

         // Enable Items
         bool enable = patientControlUpdatePatient.ComboBoxPatientId.Items.Count > 0;
         EnableTabPage(tabPageUpdatePatient, enable);
      }

      private bool firstInitializeTabAddPatient = true;
      private void InitializeTabAddPatient()
      {
         if (firstInitializeTabAddPatient)
         {
            patientListControlSample.ListViewPatients.Items[0].Selected = true;
            firstInitializeTabAddPatient = false;
         }
      }

      private void InitializeTabUpdateUser()
      {
         List<string> userList = new List<string>();
         ControllerReturnCode ret = _controller.GetUsers(userList);
         Logger.LogControllerResult("GetPermissions", ret);
         if (ret == ControllerReturnCode.Success)
         {
            usersControlUpdateUser.UpdateUserList(userList);
            usersControlUpdateUser.ComboBoxUserName.SelectedIndex = 0;
         }
      }

      private bool _updatingViewInstancesComboBoxes = false;

      private void ClearViewInstances()
      {
         comboBoxPatientIdViewInstances.Items.Clear();
         comboBoxStudyInstanceUid.Items.Clear();
         comboBoxSeriesInstanceUid.Items.Clear();
         comboBoxSopInstanceUid.Items.Clear();
      }

      private void EnableTabPage(TabPage page, bool enable)
      {
         foreach (Control ctl in page.Controls)
            ctl.Enabled = enable;
      }

      private void UpdateViewInstances(ViewInstancesOptions options)
      {
         _updatingViewInstancesComboBoxes = true;
         string patientId = comboBoxPatientIdViewInstances.Text;
         string studyInstanceUid = comboBoxStudyInstanceUid.Text;
         string seriesInstanceUid = comboBoxSeriesInstanceUid.Text;
         string sopInstanceUid = comboBoxSopInstanceUid.Text;

         switch (options)
         {
            case ViewInstancesOptions.Patient:
               patientId = PopulatePatientIdComboBox(comboBoxPatientIdViewInstances);
               goto case ViewInstancesOptions.Study;

            case ViewInstancesOptions.Study:
               studyInstanceUid = PopulateStudyInstanceUidComboBox(patientId, comboBoxStudyInstanceUid);
               goto case ViewInstancesOptions.Series;

            case ViewInstancesOptions.Series:
               seriesInstanceUid = PopulateSeriesInstanceUidComboBox(patientId, studyInstanceUid, comboBoxSeriesInstanceUid);
               goto case ViewInstancesOptions.Instance;

            case ViewInstancesOptions.Instance:
               PopulateSopInstanceUidComboBox(patientId, studyInstanceUid, seriesInstanceUid, comboBoxSopInstanceUid);
               break;
         }

         // Enable Items
         bool enable = comboBoxPatientIdViewInstances.Items.Count > 0;
         EnableTabPage(tabPageViewInstances, enable);

         _updatingViewInstancesComboBoxes = false;
      }

      private void InitializeTabViewInstances()
      {
         UpdateViewInstances(ViewInstancesOptions.Patient);
      }

      private void IntializeTabPatientInformation()
      {
         PopulatePatientIdComboBox(comboBoxPatientIdPatientInformation);

         // Enable Items
         bool enable = comboBoxPatientIdPatientInformation.Items.Count > 0;
         EnableTabPage(tabPagePatientInformation, enable);
      }


      private void comboBoxUpdatePatient_SelectedIndexChanged(object sender, EventArgs e)
      {
         UpdateUI_TabUpdatePatient();
      }

      private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
      {
         if (tabControl1.SelectedTab == tabPageViewInstances)
         {
            InitializeTabViewInstances();
         }
         else if (tabControl1.SelectedTab == tabPagePatientInformation)
         {
            IntializeTabPatientInformation();
         }
         else if (tabControl1.SelectedTab == tabPageAddPatient)
         {
            InitializeTabAddPatient();
         }
         else if (tabControl1.SelectedTab == tabPageUpdatePatient)
         {
            IntializeTabUpdatePatient();
         }
         else if (tabControl1.SelectedTab == tabPageAddUser)
         {
         }
         else if (tabControl1.SelectedTab == tabPageUpdateUser)
         {
            InitializeTabUpdateUser();
         }
      }

      private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
      {
         e.Cancel = !e.TabPage.Enabled;
      }

      delegate void LogoutAndCleanupCallback();
      private void LogoutAndCleanup()
      {
         if (tabControl1.InvokeRequired)
         {
            LogoutAndCleanupCallback cb = new LogoutAndCleanupCallback(LogoutAndCleanup);
            this.Invoke(cb);
         }
         else
         {
            try
            {
               tabControl1.SelectTab(0);
            }
            catch (Exception ex)
            {
               Console.WriteLine(ex.Message);
            }

            ClearViewInstances();
            Logout();
         }
      }

      private void menuItemLogout_Click(object sender, EventArgs e)
      {
         LogoutAndCleanup();
      }

      private void ShowLoginDialog()
      {
         LoginDialog dlg = new LoginDialog();
         dlg.UserName = _currentUserName;
         dlg.Password = _currentPassword;
         dlg.SelectedBrowser = _selectedBrowser;

         dlg.Controller = _controller;
         dlg.Timeout = _timeout;
         dlg.Port = _port;

         DialogResult dr = dlg.ShowDialog(this);
         if (DialogResult.OK == dr)
         {
            _currentUserName = dlg.UserName;
            _currentPassword = dlg.Password;
            _selectedBrowser = dlg.SelectedBrowser;

            InitializeTabViewInstances();
            UpdateUI();
         }
      }

      private void menuItemLogin_Click(object sender, EventArgs e)
      {
         ShowLoginDialog();
      }

      private void Form1_Shown(object sender, EventArgs e)
      {
         ShowLoginDialog();
      }

      private void buttonUpdateUser_Click(object sender, EventArgs e)
      {
         string username = usersControlUpdateUser.UserName;
         string password = usersControlUpdateUser.Password;
         List<string> roles = usersControlUpdateUser.Roles;
         List<string> permissions = usersControlUpdateUser.Permissions;

         CreateUserOptions options = CreateUserOptions.UpdateUser | CreateUserOptions.UpdatePermissions | CreateUserOptions.UpdateRoles;

         if (usersControlUpdateUser.UpdatePassword)
         {
            options |= CreateUserOptions.UpdatePassword;
         }

         ControllerReturnCode ret = _controller.CreateUser(
                                          username,
                                          password,
                                          _currentUserName,
                                          _currentPassword,
                                          false,
                                          permissions.ToArray(),
                                          roles.ToArray(),
                                          options);

         Logger.LogControllerResult("UpdateUser", ret);
      }


      private void buttonDeleteUser_Click(object sender, EventArgs e)
      {
         string username = usersControlUpdateUser.UserName;

         string msg = string.Format("Delete user: '{0}'?", username);
         if (DialogResult.No == MessageBox.Show(this, msg, "Delete User", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            return;

         if (string.Compare(username.Trim(), _currentUserName.Trim(), true) == 0)
         {
            string sMsg = "Failed to delete user '" + username + "'.  The currently logged in user cannot be deleted.";

            Logger.LogMessage("Delete User", sMsg);
            return;
         }

         ControllerReturnCode ret = _controller.DeleteUser(username);
         if (ret == ControllerReturnCode.Success)
         {
            InitializeTabUpdateUser();
         }
         Logger.LogControllerResult("DeleteUser", ret);
         Logger.LogMessage(string.Empty, string.Format("User '{0}' successfuly deleted.", username));
      }

      private void buttonAddUser_Click(object sender, EventArgs e)
      {
         string username = usersControlAddUser.UserName;
         string password = usersControlAddUser.Password;
         List<string> roles = usersControlAddUser.Roles;
         List<string> permissions = usersControlAddUser.Permissions;

         CreateUserOptions options = CreateUserOptions.CreateUser;

         ControllerReturnCode ret = _controller.CreateUser(
                                          username,
                                          password,
                                          _currentUserName,
                                          _currentPassword,
                                          false,
                                          permissions.ToArray(),
                                          roles.ToArray(),
                                          options);

         Logger.LogControllerResult("AddUser", ret);
      }

      private void comboBoxPatientIdViewInstances_SelectedIndexChanged(object sender, EventArgs e)
      {
         if (!_updatingViewInstancesComboBoxes)
         {
            UpdateViewInstances(ViewInstancesOptions.Study);
         }
      }

      private void comboBoxStudyInstanceUid_SelectedIndexChanged(object sender, EventArgs e)
      {
         if (!_updatingViewInstancesComboBoxes)
         {
            UpdateViewInstances(ViewInstancesOptions.Series);
         }
      }

      private void comboBoxSeriesInstanceUid_SelectedIndexChanged(object sender, EventArgs e)
      {
         if (!_updatingViewInstancesComboBoxes)
         {
            UpdateViewInstances(ViewInstancesOptions.Instance);
         }
      }

      private void menuItemExit_Click(object sender, EventArgs e)
      {
         // Logout();

         // Wait for the logout command to finish being processed
         // Thread.Sleep(500);

         Application.Exit();
      }

      private void menuItemAbout_Click(object sender, EventArgs e)
      {
         AboutDialog dlg = new AboutDialog("ExternalWebViewer Controller");
         dlg.ShowDialog(this);
      }

      private void Form1_FormClosing(object sender, FormClosingEventArgs e)
      {
         //if (Logout())
         //{
         //   // Wait for the logout command to finish being processed
         //   Thread.Sleep(500);
         //}
      }
   }

   public enum ViewInstancesOptions
   {
      Patient,
      Study,
      Series,
      Instance
   }

   // Change these constants to display for patients, studies, series, instances in the Instances tab page
   // These are capped in case the database contains a large number of patients, etc. (i.e millions)
   public static class MaxQueryResults
   {
      public const int Patient = 20;
      public const int Study = 15;
      public const int Series = 15;
      public const int Instance = 40;
   }
}
