// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;
using Leadtools;
using Leadtools.Demos;

namespace CCOWDashboard
{
   public partial class MainForm : Form
   {
      private List<Scenario> _Scenarios;
      private ActiveScenario _ActiveScenario;
      private Process _Participant1;
      private Process _Participant2;
      private Process _Participant3;

      static class Program
      {
         /// <summary>
         /// The main entry point for the application.
         /// </summary>
         [STAThread]
         static void Main(string[] args)
         {
            if (!Support.SetLicense())
               return;

            if (RasterSupport.IsLocked(RasterSupportType.Ccow))
            {
               MessageBox.Show("CCOW Support is locked!  Application will exit.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
               return;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
         }
      }

      public MainForm()
      {
         InitializeComponent();
#if LEADTOOLS_V19_OR_LATER
         this.linkLabelWebWarning.LinkClicked += new LinkLabelLinkClickedEventHandler(this.LinkLabel_LinkClicked);
         this.buttonLaunchWebParticipant1.Click += new System.EventHandler(this.buttonLaunchWebParticipant1_Click);
         this.buttonLaunchWebParticipant2.Click += new System.EventHandler(this.buttonLaunchWebParticipant2_Click);
         CheckWebComponents();
#else
            this.Height = 377;
#endif // #if !LEADTOOLS_V19_OR_LATER
      }

      private void MainForm_Load(object sender, EventArgs e)
      {
         Messager.Caption = "CCOW Dashboard";
         Text = "C# " + Messager.Caption;
         Application.Idle += new EventHandler(Application_Idle);
         _ActiveScenario = ActiveScenario.Load();
         InitializeScenarios();
      }

      private void Application_Idle(object sender, EventArgs e)
      {
         buttonLaunchParticipant1.Enabled = CanLaunchParticipant(_Participant1);
         buttonLaunchParticipant2.Enabled = CanLaunchParticipant(_Participant2);
         buttonLaunchParticipant3.Enabled = CanLaunchParticipant(_Participant3);
      }

      private void InitializeScenarios()
      {
         _Scenarios = Scenario.LoadScenarios();
         foreach (Scenario scenario in _Scenarios)
         {
            int i = comboBoxScenarios.Items.Add(scenario);
            FileInfo a = new FileInfo(_ActiveScenario.Filename.ToLower());
            FileInfo b = new FileInfo(scenario.Filename.ToLower());

            if (a.Name.ToLower() == b.Name.ToLower())
               comboBoxScenarios.SelectedIndex = i;
         }
      }

      private bool CanLaunchParticipant(Process process)
      {
         if (process == null || (process != null && process.HasExited))
            return true;

         return false;
      }

      private void exitToolStripMenuItem_Click(object sender, EventArgs e)
      {
         Close();
      }

      private void LaunchParticipant(string args, ref Process process, Color color, int applicationIndex)
      {
         string participantFileName = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "CSCCOWClientParticipationDemo_Original.exe");

         if (!File.Exists(participantFileName))
         {
            participantFileName = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "CSCCOWClientParticipationDemo.exe");
         }

         if (File.Exists(participantFileName))
         {
            if (process == null)
            {
               process = new Process();
               process.EnableRaisingEvents = true;
               process.Exited += new EventHandler(Process_Exited);
               process.StartInfo.FileName = participantFileName;
            }

            process.StartInfo.Arguments = "/dashboard " + args + " /color=" + ColorTranslator.ToHtml(color) +
                                          " /index=" + applicationIndex.ToString();
            process.Start();
         }
         else
         {
            Messager.ShowError(null, "Could not find the CSCCOWClientParticipationDemo");
         }
      }

      private void Process_Exited(object sender, EventArgs e)
      {
         Process process = sender as Process;

         if (process != null)
         {
            if (process == _Participant1)
               Invoke(new MethodInvoker(() => buttonLaunchParticipant1.Enabled = true));
            else if (process == _Participant2)
               Invoke(new MethodInvoker(() => buttonLaunchParticipant2.Enabled = true));
            else if (process == _Participant3)
               Invoke(new MethodInvoker(() => buttonLaunchParticipant3.Enabled = true));
         }
      }

      private void comboBoxScenarios_SelectedIndexChanged(object sender, EventArgs e)
      {
         Scenario scenario = comboBoxScenarios.SelectedItem as Scenario;

         if (scenario != null)
         {
            _ActiveScenario.Filename = scenario.Filename;
            _ActiveScenario.Scenario = scenario;
            _ActiveScenario.Save();
         }
      }

      private void buttonLaunchParticipant1_Click(object sender, EventArgs e)
      {
         LaunchParticipant(checkBoxSSO1.Checked ? "/link=user" : string.Empty, ref _Participant1, panelParticipant1.BackColor, 0);
      }

      private void buttonLaunchParticipant2_Click(object sender, EventArgs e)
      {
         LaunchParticipant(checkBoxSSO2.Checked ? "/link=user" : string.Empty, ref _Participant2, panelParticipant2.BackColor, 1);
      }

      private void buttonLaunchParticipant3_Click(object sender, EventArgs e)
      {
         LaunchParticipant(checkBoxSSO3.Checked ? "/link=user" : string.Empty, ref _Participant3, panelParticipant3.BackColor, 2);
      }

      private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
      {
         AboutDialog dlgAbout = new AboutDialog(Messager.Caption);

         dlgAbout.ShowDialog(this);
      }

      private void showDetailedHelpToolStripMenuItem_Click(object sender, EventArgs e)
      {
         bool bHelpFound = true;
         try
         {
            DemosGlobal.LaunchHelp2("CcowDashboardDemo");
         }
         catch (Exception)
         {
            bHelpFound = false;
         }
         finally
         {
            if (!bHelpFound)
               Messager.ShowWarning(this, "Help failed to load.");
         }

      }

#if LEADTOOLS_V19_OR_LATER

#if LTV20_CONFIG
      private const string LT_VER = "20";
#elif LTV19_CONFIG
      private const string LT_VER = "19";
#endif // #if LTV20_CONFIG

      private string _webDemoUrl = string.Format("http://localhost/CCOW{0}/CCOWWebClientParticipationDemo/index.html", LT_VER);

      private void EnableWebUIElements(bool enable)
      {
         this.buttonLaunchWebParticipant1.Enabled = enable;
         this.buttonLaunchWebParticipant2.Enabled = enable;
         this.checkBoxWebSSO1.Enabled = enable;
         this.checkBoxWebSSO2.Enabled = enable;
      }

      private void CheckWebComponents()
      {
         bool isAdmin = DemosGlobal.IsAdmin();
         bool isWebHosted = WebDemoHosted();
         if (isAdmin && isWebHosted)
         {
            StartCcowServer();
            this.linkLabelWebWarning.Visible = false;
            EnableWebUIElements(true);
         }
         else
         {
            if (!isAdmin)
               this.labelWebWarning.Visible = true;
            else if (!isWebHosted)
               this.linkLabelWebWarning.Visible = true;

            EnableWebUIElements(false);
         }
      }

      private void LaunchWebParticipant(bool userLink, Color color, int applicationIndex)
      {
         Process.Start(string.Format("{0}?dashboard={1}&userlink={1}&color={2}&index={3}", _webDemoUrl, userLink, ColorTranslator.ToHtml(color), applicationIndex));
      }

      private void buttonLaunchWebParticipant1_Click(object sender, EventArgs e)
      {
         LaunchWebParticipant(checkBoxWebSSO1.Checked, panelWebParticipant1.BackColor, 1);
      }

      private void buttonLaunchWebParticipant2_Click(object sender, EventArgs e)
      {
         LaunchWebParticipant(checkBoxWebSSO2.Checked, panelWebParticipant2.BackColor, 2);
      }

      private bool WebDemoHosted()
      {
         try
         {
            // First check if it is reachable through HTTP
            HttpWebRequest request = WebRequest.Create(_webDemoUrl) as HttpWebRequest;
            request.Timeout = 5000;

            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
               using (StreamReader reader = new StreamReader(response.GetResponseStream()))
               {
                  string str = reader.ReadToEnd();
               }
            }

            return true;
         }
         catch
         {
            return false;
         }
      }

      private void LinkLabel_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
      {
         try
         {
            string serviceManagerPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "LeadtoolsServicesHostManager_Original.exe");
            Process.Start(serviceManagerPath, "/group:\"LEADTOOLS CCOW Web Participation Demo (Version 19)\"").WaitForExit();
            CheckWebComponents();
         }
         catch (Exception ex)
         {
            Messager.ShowError(this, ex);
         }
      }

      private void StartCcowServer()
      {
         string serverPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "CSCcowServerDemo_Original.exe");
         try
         {
            if (Process.GetProcessesByName("CSCcowServerDemo_Original").Length == 0)
            {
               Process.Start(serverPath);
            }
         }
         catch (Exception ex)
         {
            Messager.ShowError(this, ex);
         }
      }
#endif // #if !LEADTOOLS_V19_OR_LATER
   }
}
