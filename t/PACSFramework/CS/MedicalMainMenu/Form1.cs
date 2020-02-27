using System;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System.Diagnostics;
using Leadtools.Dicom;
using Leadtools.DicomDemos;
using Leadtools.Demos.StorageServer.DataTypes;
using System.Collections.Generic;
using System.ComponentModel;

namespace MedicalMainMenu
{
   public partial class Form1 : Form
   {

      public List<Process> demoprocessList = new List<Process>();
      public Form1()
      {
         InitializeComponent();
      }

      public static string AssemblyDirectory
      {
         get
         {
            string codeBase = Assembly.GetExecutingAssembly().CodeBase;
            UriBuilder uri = new UriBuilder(codeBase);
            string path = Uri.UnescapeDataString(uri.Path);
            return Path.GetDirectoryName(path);
         }
      }

      private void InitializeDataGridView(DataGridView dgv)
      {
         dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
         dgv.RowHeadersVisible = false;

         dgv.AllowDrop = false;
         dgv.AllowUserToAddRows = false;
         dgv.AllowUserToDeleteRows = false;
         dgv.AllowUserToOrderColumns = false;
         dgv.AllowUserToResizeColumns = false;
         dgv.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
         dgv.AutoResizeColumns();

         dgv.DefaultCellStyle.SelectionBackColor = Color.White;
         dgv.DefaultCellStyle.SelectionForeColor = Color.Black;
         dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
         dgv.Columns[0].DefaultCellStyle.WrapMode = DataGridViewTriState.False;
         dgv.CellContentClick += DataGridView1_CellContentClick;
      }

      private void RunPacsConfigDemo()
      {
         string dbManagerFileName = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "CSPacsConfigDemo_Original.exe");

         if (!File.Exists(dbManagerFileName))
         {
            dbManagerFileName = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "CSPacsConfigDemo.exe");
         }

         if (File.Exists(dbManagerFileName))
         {
            Process dbConfigProcess = new Process();
            dbConfigProcess.StartInfo.FileName = dbManagerFileName;

            dbConfigProcess.Start();
            dbConfigProcess.WaitForExit();
         }
         else
         {
            MessageBox.Show("Could not find the CSPacsConfigDemo.exe", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
         }
      }

      private void Initialize()
      {
         //   DicomEngine.Startup();
         //   {
         //      string missingDbComponents;
         //      //DialogResult result = DialogResult.Yes;
         //      //Messager.Caption = _demoName;
         //      //string platform = "32-bit";
         //      //if (DicomDemoSettingsManager.Is64Process())
         //      //   platform = "64-bit";

         //      string[] productsToCheck = new string[] { DicomDemoSettingsManager.ProductNameDemoServer, DicomDemoSettingsManager.ProductNameWorkstation, DicomDemoSettingsManager.ProductNameStorageServer };

         //      bool isDbConfigured = GlobalPacsUpdater.IsDbComponentsConfigured(productsToCheck, out missingDbComponents);
         //      if (!isDbConfigured) // databases not configured
         //      {
         //      //string message = "The following databases are not configured:\n\n{0}\nRun the {1} CSPacsDatabaseConfigurationDemo to configure the missing databases then run this demo again.\n\nDo you want to run the {2} CSPacsDatabaseConfigurationDemo wizard now?";
         //      //message = string.Format(message, missingDbComponents, platform, platform);

         //      //result = Messager.ShowQuestion(null, message, MessageBoxButtons.YesNo);
         //      //if (DialogResult.Yes == result)
         //      //{
         //      //   RunDatabaseConfigurationDemo();
         //      //}
         //      RunPacsConfigDemo();
         //      }


         //   // DicomEngine.Shutdown();
         //}
      }

      private void Form1_Load(object sender, EventArgs e)
      {

         richTextBoxCaption.Text = "Click on any link to run the demo.  Note that it is not necessary to run the Configuration Demos, as they run automatically when needed.";

         InitializeDataGridView(dataGridViewConfiguration);
         dataGridViewConfiguration.Rows.Add(@"Utility to create required databases", "CSPacsDatabaseConfigurationDemo.exe");
         dataGridViewConfiguration.Rows.Add(@"Utility to create DICOM Listening Services", "CSPACSConfigDemo.exe");

         InitializeDataGridView(dataGridViewDicomServers);
         dataGridViewDicomServers.Rows.Add(@"Production level DICOM Storage Server", "CSStorageServerManagerDemo.exe");
         dataGridViewDicomServers.Rows.Add(@"Simple DICOM MWL Server", "CSLeadtools.Dicom.Server.Manager.exe");

         InitializeDataGridView(dataGridViewDicomClients);
         dataGridViewDicomClients.Rows.Add(@"DICOM Query/Retrieve SCU", "CSDicomHighlevelClientDemo.exe");
         dataGridViewDicomClients.Rows.Add(@"DICOM Store SCU", "CSDicomHighlevelStoreDemo.exe");
         dataGridViewDicomClients.Rows.Add(@"DICOM Modality Worklist SCU Demo", "CSDicomHighLevelMwlScuDemo.exe");
         dataGridViewDicomClients.Rows.Add(@"DICOM Patient Updater SCU", "CSDicomHighlevelPatientUpdaterDemo.exe");

         InitializeDataGridView(this.dataGridViewDicomViewers);
         dataGridViewDicomViewers.Rows.Add(@"Medical Workstation Viewer", "CSMedicalWorkstationMainDemo.exe");
         dataGridViewDicomViewers.Rows.Add(@"HTML5 Medical Web Viewer (Configure and Run)", "WebViewerConfiguration.exe");

         InitializeDataGridView(this.dataGridViewTroubleshooting);
         dataGridViewTroubleshooting.Rows.Add(@"Recompiling gives 'File in Use' error", "Click to stop all DICOM Listening Services");
         dataGridViewTroubleshooting.Rows.Add(@"Close all medical demos", "Click to close all medical demos");
      }

      private void CloseAllDemos()
      {
         for (int i = demoprocessList.Count - 1; i >= 0; i--)
         {
            if (demoprocessList[i].HasExited)
            {
               demoprocessList.RemoveAt(i);
            }
         }

         if (demoprocessList.Count == 0)
         {
            MessageBox.Show(this, "There are no medical demos running.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
         }
         else
         {
            int totalCount = 0;
            bool success = true;

            try
            {
               foreach (Process process in demoprocessList)
               {
                  bool exited = process.HasExited;
                  Utils.KillOneProccess(process);
                  totalCount++;
               }
            }
            catch (Exception ex)
            {
               success = false;
               MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            if (success)
            {
               string message = string.Format("Medical demos closed: {0}", totalCount);
               MessageBox.Show(message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
         }
         demoprocessList.Clear();
      }

      private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
      {
         DataGridView dgv = sender as DataGridView;
         if (dgv != null)
         {
            if (dgv == this.dataGridViewTroubleshooting)
            {
               string linkText =  dgv[e.ColumnIndex, e.RowIndex].Value.ToString();
               if (linkText.Contains("Click to stop all DICOM Listening Services"))
               {
                  int count = 0;
                  bool success = true;
                  try
                  {
                     count = Utils.KillProcessesByName("Leadtools.Dicom.Server");
                  }
                  catch (Exception ex)
                  {
                     success = false;
                     MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                  }
                  if (success)
                  {
                     if (count == 0)
                     {
                        MessageBox.Show("There are no DICOM Listening Services running.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                     }
                     else
                     {
                        string message = string.Format("DICOM Listening Services Stopped: {0}", count);
                        MessageBox.Show(message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                     }
                  }
               }
               else if (linkText.Contains("Click to close all medical demos"))
               {
                  CloseAllDemos();
               }
            }
            else if (dgv.Columns[e.ColumnIndex] is DataGridViewLinkColumn)
            {
               string exePath = Path.Combine(AssemblyDirectory, dgv[e.ColumnIndex, e.RowIndex].Value.ToString());
               string exePathOriginal = exePath.Replace(".exe", "_Original.exe");
               if (File.Exists(exePath))
               {
                  demoprocessList.Add(Process.Start(exePath));
               }
               else if (File.Exists(exePathOriginal))
               {
                  demoprocessList.Add(Process.Start(exePathOriginal));
               }
               else
               {
                  MessageBox.Show("File not found: " + exePath, "Information", MessageBoxButtons.OK);
               }
            }
         }
      }

   }

   public static class Utils
   {
      public static List<Process> GetKillProcessList(string processName)
      {
         List<Process> processList = new List<Process>();

         foreach (Process p in System.Diagnostics.Process.GetProcessesByName(processName))
         {
            if (p != null && p.MainModule != null)
            {
               processList.Add(p);
            }
         }
         return processList;
      }

      public static void KillOneProccess(Process p)
      {
         try
         {
            if (p != null)
            {
               p.Kill();
               p.WaitForExit(); // possibly with a timeout
            }

         }
         catch (Win32Exception )
         {
            // process was terminating or cannot be terminate
         }
         catch (InvalidOperationException )
         {
            // process has already exited 
         }
      }

      public static int KillProcessesByName(string processName)
      {
         int count = 0;
         List<Process> processList = GetKillProcessList(processName);
         foreach (Process p in processList)
         {
            KillOneProccess(p);
            count++;
         }
         return count;
      }
   }
}
