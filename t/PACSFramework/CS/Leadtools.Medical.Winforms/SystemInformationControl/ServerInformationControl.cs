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
using System.Data.SqlClient;
using Leadtools.Medical.DataAccessLayer;
using Leadtools.Medical.Storage.DataAccessLayer;
using Leadtools.Medical.Storage.DataAccessLayer.MatchingParameters;
using System.IO;
using System.Threading;
using System.Reflection;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.ServiceProcess;
using System.Collections;

namespace Leadtools.Medical.Winforms
{
   public partial class ServerInformationControl : UserControl
   {

      [DllImport("advapi32.dll", EntryPoint = "OpenSCManagerW", ExactSpelling = true, CharSet = CharSet.Unicode, SetLastError = true)]
      public static extern IntPtr OpenSCManager(string machineName, string databaseName, uint dwAccess);
      [DllImport("advapi32.dll", SetLastError = true, CharSet = CharSet.Auto)]
      static extern IntPtr OpenService(IntPtr hSCManager, string lpServiceName, uint dwDesiredAccess);
      [DllImport("advapi32.dll", SetLastError = true)]
      [return: MarshalAs(UnmanagedType.Bool)]
      public static extern bool CloseServiceHandle(IntPtr hSCObject);
      [DllImport("advapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
      static extern bool QueryServiceStatusEx(IntPtr serviceHandle, int infoLevel, IntPtr buffer, int bufferSize, out int bytesNeeded);

      private const uint SERVICE_NO_CHANGE = 0xffffffff; //this value is found in winsvc.h
      private const uint SERVICE_QUERY_CONFIG = 0x00000001;
      private const uint SERVICE_CHANGE_CONFIG = 0x00000002;
      private const uint SERVICE_QUERY_STATUS = 0x00000004;
      private const uint SERVICE_ENUMERATE_DEPENDENTS = 0x00000008;
      private const uint SERVICE_START = 0x00000010;
      private const uint SERVICE_STOP = 0x00000020;
      private const uint SERVICE_PAUSE_CONTINUE = 0x00000040;
      private const uint SERVICE_INTERROGATE = 0x00000080;
      private const uint SERVICE_USER_DEFINED_CONTROL = 0x00000100;
      private const uint STANDARD_RIGHTS_REQUIRED = 0x000F0000;
      private const uint SERVICE_ALL_ACCESS = (STANDARD_RIGHTS_REQUIRED | SERVICE_QUERY_CONFIG |
                          SERVICE_CHANGE_CONFIG |
                          SERVICE_QUERY_STATUS |
                          SERVICE_ENUMERATE_DEPENDENTS |
                          SERVICE_START |
                          SERVICE_STOP |
                          SERVICE_PAUSE_CONTINUE |
                          SERVICE_INTERROGATE |
                          SERVICE_USER_DEFINED_CONTROL);

      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
      public class SERVICE_STATUS_PROCESS
      {
         public int serviceType;
         public int currentState;
         public int controlsAccepted;
         public int win32ExitCode;
         public int serviceSpecificExitCode;
         public int checkPoint;
         public int waitHint;
         public int processID;
         public int serviceFlags;
      }

      public DateTime? StartTime { get; set; }

      [Flags]
      public enum SCM_ACCESS : uint
      {
         STANDARD_RIGHTS_REQUIRED = 0xF0000,
         SC_MANAGER_CONNECT = 0x00001,
         SC_MANAGER_CREATE_SERVICE = 0x00002,
         SC_MANAGER_ENUMERATE_SERVICE = 0x00004,
         SC_MANAGER_LOCK = 0x00008,
         SC_MANAGER_QUERY_LOCK_STATUS = 0x00010,
         SC_MANAGER_MODIFY_BOOT_CONFIG = 0x00020,
         SC_MANAGER_ALL_ACCESS = STANDARD_RIGHTS_REQUIRED |
             SC_MANAGER_CONNECT |
             SC_MANAGER_CREATE_SERVICE |
             SC_MANAGER_ENUMERATE_SERVICE |
             SC_MANAGER_LOCK |
             SC_MANAGER_QUERY_LOCK_STATUS |
             SC_MANAGER_MODIFY_BOOT_CONFIG
      }

      private static List<ProcessModule> _Modules = new List<ProcessModule>();
      private ListViewColumnSorter _Sorter = new ListViewColumnSorter();

      public ServerInformationControl()
      {
         InitializeComponent();
         _sqlDatabaseList = new Dictionary<string, string>();
         _mpc = new MatchingParameterCollection();
         _mpc.Add(new MatchingParameterList());
         progressBar.Visible = false;
         _Sorter.Order = System.Windows.Forms.SortOrder.Ascending;
         listViewModules.ListViewItemSorter = _Sorter;
         LoadModules();
      }

      private void LoadModules()
      {
         Process process = Process.GetCurrentProcess();
         List<string> modules = new List<string>();
         
         foreach (ProcessModule module in process.Modules)
         {
            if (module.ModuleName.Contains("Leadtools") || module.ModuleName.Contains("Medicor"))
            {
               ListViewItem item = new ListViewItem(module.ModuleName);

               if(!modules.Contains(module.ModuleName.ToLower()))
               {
                  item.SubItems.Add(module.FileVersionInfo.FileVersion);
                  listViewModules.Items.Add(item);
                  modules.Add(module.ModuleName.ToLower());
               }
            }
         }
         listViewModules.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
         SortColumns(listViewModules, 0);
         modules.Clear();
      }

      private void SortColumns(ListView listView, int column)
      {         
         // Determine if clicked column is already the column that is being sorted.
         if (column == _Sorter.SortColumn)
         {
            // Reverse the current sort direction for this column.
            if (_Sorter.Order == System.Windows.Forms.SortOrder.Ascending)
            {
               _Sorter.Order = System.Windows.Forms.SortOrder.Descending;
            }
            else
            {
               _Sorter.Order = System.Windows.Forms.SortOrder.Ascending;
            }
         }
         else
         {
            // Set the column number that is to be sorted; default to ascending.
            _Sorter.SortColumn = column;
            _Sorter.Order = System.Windows.Forms.SortOrder.Ascending;
         }

         // Perform the sort with these new sort options.
         listView.Sort();
      }

      public int CurrentClientConnectionCount
      {
         set
         {
            textBoxCurrentConnections.Text = value.ToString();
         }
      }

      public int MaximumClientConnectionCount
      {
         set
         {
            textBoxMaximumConnections.Text = value.ToString();
         }
      }

      public string ServiceName
      {
         get
         {
            return linkLabelServiceName.Text;
         }
         set
         {
            linkLabelServiceName.Text = value;
         }
      }

      public bool HideUserDetails { get; set; }

      public delegate void RequestCurrentClientConnectionCountHandler(object sender, CurrentClientConnectionCountEventArgs e);

      public event EventHandler<CurrentClientConnectionCountEventArgs> RequestCurrentClientConnectionCount;

      protected virtual void OnRequestCurrentClientConnectionCount(CurrentClientConnectionCountEventArgs e)
      {
         if (RequestCurrentClientConnectionCount != null)
            RequestCurrentClientConnectionCount(this, e);
      }

      private void buttonSystemInformation_Click(object sender, EventArgs e)
      {
         System.Diagnostics.Process.Start("msinfo32.exe");
      }

      private Dictionary<string, string> _sqlDatabaseList;

      public Dictionary<string, string> SqlDatabaseList
      {
         get { return _sqlDatabaseList; }
         set { _sqlDatabaseList = value; }
      }
      
      public string StorageDatabaseName
      {
         get ;
         set ;
      }

      private ConnectionInformation _ciStorage = null;
      private MatchingParameterCollection _mpc = null;
      private int _patientCount = 0;
      private int _studiesCount = 0;
      private int _seriesCount = 0;
      private int _imageCount = 0;

      private ConnectionInformation GetInfo(string friendlyName, string connectionString)
      {
         ConnectionInformation ci = new ConnectionInformation();
         ci.FriendlyName = friendlyName;
         ci.ConnectionString = connectionString;
         if (connectionString.Contains(".sdf"))
            GetInfoSqlCe(ci);
         else
            ci = GetInfoSql(ci);

         return ci;
      }

      private string GetSqlCeDataSource(string connectionString)
      {
         string dataSourceString = "Data Source";
         int index = connectionString.IndexOf(dataSourceString, StringComparison.OrdinalIgnoreCase);
         string dataSource = connectionString.Substring(index + dataSourceString.Length);
         index = dataSource.IndexOf("=", StringComparison.OrdinalIgnoreCase);
         dataSource = dataSource.Substring(index + 1);
         dataSource = dataSource.Trim();
         return dataSource;
      }

      private void GetInfoSqlCe(ConnectionInformation ci)
      {
         SqlConnectionStringBuilder csB = new SqlConnectionStringBuilder(ci.ConnectionString);

         // Uncomment the code below to verify that the SqlCe connection string is valid
         //
         // SqlCeConnection conn = new SqlCeConnection(csB.ConnectionString);
         // ci.IsSqlCe = true;
         // ci.CanConnect = true;
         //try
         //{
         //   conn.Open();
         //}
         //catch (Exception ex)
         //{
         //   ci.CanConnect = false;
         //   ci.ErrorString = ex.Message;
         //}

         ci.SqlServerVersion = "SQL Server Compact" ;
         
         ci.IsSqlCe = true;
         
         try
         {
            Assembly assem = Assembly.Load ( "System.Data.SqlServerCe" ) ;
         
            if ( null != assem ) 
            {
               AssemblyName name = assem.GetName ( ) ;
               ci.SqlServerVersion = name.Name + " - " + name.Version.ToString ( ) ;
            }
         }
         catch {}
         
         ci.SqlDataSource = GetSqlCeDataSource(ci.ConnectionString);
      }
      

      string SqlVersionExtraInfo(string csVersion)
      {
         string result = csVersion;
         string csExtra = string.Empty;

         // SQL Server 2008 R2
         if (csVersion.Contains("10.50.1600.1"))
            csExtra = "(RTM)";
         else if (csVersion.Contains("10.50.2500.0"))
            csExtra = "(SP1)";

         // SQL Server 2008
         if (csVersion.Contains("10.00.1600.22"))
            csExtra = "(RTM)";
         else if (csVersion.Contains("10.00.2531.00"))
            csExtra = "(SP1)";
         else if (csVersion.Contains("10.00.4000.00"))
            csExtra = "(SP2)";

         // SQL Server 2005
         if (csVersion.Contains("9.00.1399"))
            csExtra = "(RTM)";
         else if (csVersion.Contains("9.00.2047"))
            csExtra = "(SP1)";
         else if (csVersion.Contains("9.00.3042"))
            csExtra = "(SP2)";
         else if (csVersion.Contains("9.00.4035"))
            csExtra = "(SP3)";
         else if (csVersion.Contains("9.00.5000.00"))
            csExtra = "(SP4)";

         // SQL Server 2000
         if (csVersion.Contains("8.00.194"))
            csExtra = "(RTM)";
         else if (csVersion.Contains("8.00.384"))
            csExtra = "(SP1)";
         else if (csVersion.Contains("8.00.534"))
            csExtra = "(SP2)";
         else if (csVersion.Contains("8.00.760"))
            csExtra = "(SP3)";
         else if (csVersion.Contains("8.00.2039"))
            csExtra = "(SP4)";

         // SQL Server 7.0
         else if (csVersion.Contains("7.00.1063"))
            csExtra = "(SP4)";
         else if (csVersion.Contains("7.00.961 "))
            csExtra = "(SP3)";
         else if (csVersion.Contains("7.00.842 "))
            csExtra = "(SP2)";
         else if (csVersion.Contains("7.00.699 "))
            csExtra = "(SP1)";
         else if (csVersion.Contains("7.00.623 "))
            csExtra = "(RTM)";

         // SQL Server 6.5
         else if (csVersion.Contains("6.50.479"))
            csExtra = "(SP5a Update)";
         else if (csVersion.Contains("6.50.416"))
            csExtra = "(SP5a)";
         else if (csVersion.Contains("6.50.415"))
            csExtra = "(SP5)";
         else if (csVersion.Contains("6.50.281"))
            csExtra = "(SP4)";
         else if (csVersion.Contains("6.50.258"))
            csExtra = "(SP3)";
         else if (csVersion.Contains("6.50.240"))
            csExtra = "(SP2)";
         else if (csVersion.Contains("6.50.213"))
            csExtra = "(SP1)";
         else if (csVersion.Contains("6.50.201"))
            csExtra = "(RTM)";

         csVersion = csVersion + " " + csExtra;
         return csVersion;
      }

      private string CleanupVersionString(string sqlVersion)
      {
         // Remove Microsoft
         sqlVersion = sqlVersion.Replace("Microsoft", string.Empty);

         // Remove (Intel X86)
         sqlVersion = sqlVersion.Replace("(Intel X86)", string.Empty);

         // Remove everything after first newline
         string[] results = sqlVersion.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

         string cleanString = string.Empty;
         if (results.Length > 0)
         {
            cleanString = SqlVersionExtraInfo(results[0].Trim());
         }
         return cleanString;
      }

      private ConnectionInformation GetInfoSql(ConnectionInformation ci)
      {
         SqlConnectionStringBuilder csB = new SqlConnectionStringBuilder(ci.ConnectionString);
         SqlConnection conn = new SqlConnection(csB.ConnectionString);

         ci.CanConnect = true;

         try
         {
            conn.Open();

            SqlCommand command = new SqlCommand();
            command.CommandTimeout = 10;
            command.Connection = conn;
            command.CommandText = @"SELECT @@VERSION  AS version";

            string sqlVersion;
            using (SqlDataReader reader = command.ExecuteReader())
            {
               if (reader.Read())
               {
                  sqlVersion = reader[0].ToString();
                  sqlVersion = CleanupVersionString(sqlVersion);
                  ci.SqlServerVersion = sqlVersion;
                  ci.SqlDataSource = conn.DataSource;
                  ci.SsqlDatabase = conn.Database;
               }
            }

            command.CommandText = "sp_helpfile";
            using (SqlDataReader reader = command.ExecuteReader())
            {
               while (reader.Read())
               {
                  try
                  {
                     SqlFileInformation s = new SqlFileInformation();
                     s.Name = reader[0].ToString();
                     s.FileId = reader[1].ToString();
                     s.FileName = reader[2].ToString();
                     s.FileGroup = reader[3].ToString();
                     s.Size = reader[4].ToString();
                     s.MaxSize = reader[5].ToString();
                     s.Growth = reader[6].ToString();
                     s.Usage = reader[7].ToString();
                     ci.SqlFiles.Add(s);
                  }
                  catch (Exception ex)
                  {
                     ci.ErrorString = ex.Message;
                     ci.CanConnect = false;
                  }
               }
            }
         }
         catch (SqlException ex)
         {
            ci.ErrorString = ex.Message;
            ci.CanConnect = false;
         }
         return ci;
      }

      private void UpdateDatabaseDetails(ConnectionInformation ci)
      {
         TreeNode node = treeViewSqlServerInformation.Nodes.Add(ci.FriendlyName);
         string connection = ci.ConnectionString;

         if (HideUserDetails)
         {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(connection);

            builder.UserID = "****";
            builder.Password = "****";
            connection = builder.ConnectionString;
         }
         node.Nodes.Add("Connection String: " + connection);

         if (ci.IsSqlCe)
         {
            node.Nodes.Add(ci.SqlServerVersion);
            node.Nodes.Add("Data Source: " + ci.SqlDataSource);
         }
         else if (ci.CanConnect)
         {
            node.Nodes.Add(ci.SqlServerVersion);
            node.Nodes.Add("Data Source: " + ci.SqlDataSource);
            node.Nodes.Add("Database: " + ci.SsqlDatabase);
            foreach (SqlFileInformation file in ci.SqlFiles)
            {
               TreeNode nodeFile = node.Nodes.Add(file.Name);
               nodeFile.Nodes.Add("ID: " + file.FileId);
               nodeFile.Nodes.Add("Name: " + file.FileName);
               nodeFile.Nodes.Add("Group: " + file.FileGroup);
               nodeFile.Nodes.Add("Size: " + file.Size);
               nodeFile.Nodes.Add("MaxSize: " + file.MaxSize);
               nodeFile.Nodes.Add("Growth: " + file.Growth);
               nodeFile.Nodes.Add("Usage: " + file.Usage);
            }
         }
         else
         {
            node.Nodes.Add("Error: " + ci.ErrorString);
         }
      }

      private void Initialize()
      {
         if (treeViewSqlServerInformation != null && treeViewSqlServerInformation.Nodes != null)
         {
            treeViewSqlServerInformation.Nodes.Clear();
         }

         _ciStorage = null;
         // Sql Server Information
         foreach (KeyValuePair<string, string> kvp in this.SqlDatabaseList)
         {
            ConnectionInformation ci = GetInfo(kvp.Key, kvp.Value);
            UpdateDatabaseDetails(ci);
            if (ci.FriendlyName == StorageDatabaseName)
               _ciStorage = ci;
         }

         // Patient, study, series, image count
         if (_ciStorage != null)
         {
            IStorageDataAccessAgent db = GetDataAccessAgent();

            textBoxTotalPatients.Text = "0";
            textBoxTotalStudies.Text = "0";
            textBoxTotalSeries.Text = "0";
            textBoxTotalImages.Text = "0";

            double dTotalMBytes = 0;
            try
            {
               _patientCount = db.FindPatientsCount(_mpc);
               _studiesCount = db.FindStudiesCount(_mpc);
               _seriesCount = db.FindSeriesCount(_mpc);
               _imageCount = db.FindCompositeInstancesCount(_mpc);

               // RecalculateTotalDataStored();
            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.Message);
            }

            textBoxTotalPatients.Text = _patientCount.ToString();
            textBoxTotalStudies.Text = _studiesCount.ToString();
            textBoxTotalSeries.Text = _seriesCount.ToString();
            textBoxTotalImages.Text = _imageCount.ToString();

            textBoxTotalDataStored.Text = string.Format("{0:F1} MB", dTotalMBytes);
         }
      }

      private void ServerInformationControl_Load(object sender, EventArgs e)
      {
      }

      private IStorageDataAccessAgent GetDataAccessAgent()
      {
         if (_ciStorage == null)
            return null;

         IStorageDataAccessAgent db = null;

         if (!DataAccessServices.IsDataAccessServiceRegistered<IStorageDataAccessAgent>())
         {
            throw new InvalidOperationException(typeof(IStorageDataAccessAgent).Name + " is not registered.");
         }

         db = DataAccessServices.GetDataAccessService<IStorageDataAccessAgent>();
         
         return db;
      }

      private void textBoxTotalPatients_DoubleClick(object sender, EventArgs e)
      {
         IStorageDataAccessAgent db = GetDataAccessAgent();
         if (db != null)
         {
            _patientCount = db.FindPatientsCount(_mpc);
            textBoxTotalPatients.Text = _patientCount.ToString();
         }
      }

      private void textBoxTotalStudies_DoubleClick(object sender, EventArgs e)
      {
         IStorageDataAccessAgent db = GetDataAccessAgent();
         if (db != null)
         {
            _studiesCount = db.FindStudiesCount(_mpc);
            textBoxTotalStudies.Text = _studiesCount.ToString();
         }
      }

      private void textBoxTotalSeries_DoubleClick(object sender, EventArgs e)
      {
         IStorageDataAccessAgent db = GetDataAccessAgent();
         if (db != null)
         {
            _seriesCount = db.FindSeriesCount(_mpc);
            textBoxTotalSeries.Text = _seriesCount.ToString();
         }
      }

      private void textBoxTotalImages_DoubleClick(object sender, EventArgs e)
      {
         IStorageDataAccessAgent db = GetDataAccessAgent();
         if (db != null)
         {
            _imageCount = db.FindCompositeInstancesCount(_mpc);
            textBoxTotalImages.Text = _imageCount.ToString();
         }
      }


      private void backgroundworker_DoWork(object sender, DoWorkEventArgs e)
      {
         try
         {
            int nPercentComplete = 0;
            backgroundWorker.ReportProgress(nPercentComplete);
            IStorageDataAccessAgent db = GetDataAccessAgent();
            if (db == null)
            {
               e.Result = 0.0;
               backgroundWorker.ReportProgress(100);
               return;
            }
           
            // This takes a long time
            DataSet compositeInstance = db.QueryCompositeInstances(_mpc);;

            long totalBytes = 0;
            int count = compositeInstance.Tables[DataTableHelper.InstanceTableName].Rows.Count;

            int i = 0;
            while (!backgroundWorker.CancellationPending && i < count)
            {
               string sFile = RegisteredDataRows.InstanceInfo.ReferencedFile(compositeInstance.Tables[DataTableHelper.InstanceTableName].Rows[0]);
               FileInfo fi = new FileInfo(sFile);
               
               if ( fi.Exists ) 
               {
                  totalBytes += fi.Length;
                  nPercentComplete = 100 * (i + 1) / count;
               }
               
               backgroundWorker.ReportProgress ( nPercentComplete ) ;
               
               i++;
            }

            if (backgroundWorker.CancellationPending)
            {
               e.Cancel = true;
            }
            else
            {
               double dTotalMBytes = ((double)totalBytes / (1024.0 * 1024.0));
               e.Result = dTotalMBytes;
               backgroundWorker.ReportProgress(100);
            }
         }
         catch (Exception ex)
         {
            MessageBox.Show(ex.Message);
         }
      }

      private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
      {
         progressBar.PerformStep();
         if (e.ProgressPercentage > 0)
            buttonRecalculateTotalDataStored.Enabled = true;
      }


      private void backgroundworker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
      {
         // progressBar.Visible = false;
         if (e.Cancelled)
         {
            progressBar.Value = 0;
            MessageBox.Show("Calculate Total Data Stored - Cancelled", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
         }
         else
         {
            double dTotalMBytes = 0 ;
            
            if ( null != e.Result ) 
            {
               dTotalMBytes = (double)e.Result;
            }
            
            textBoxTotalDataStored.Text = string.Format("{0:F1} MB", dTotalMBytes);
            // MessageBox.Show("Total data stored: " + textBoxTotalDataStored.Text, "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
         }
         buttonRecalculateTotalDataStored.Text = "Calculate Total Data Stored";
         progressBar.Visible = false;
      }

      private void RecalculateTotalDataStored()
      {
         if (buttonRecalculateTotalDataStored.Text.Contains("Calculate"))
         {
            progressBar.Visible = true;
            progressBar.Value = 0;
            progressBar.Minimum = 0;
            progressBar.Maximum = _imageCount;
            progressBar.Step = 1;

            buttonRecalculateTotalDataStored.Text = "Cancel";
            buttonRecalculateTotalDataStored.Enabled = false;
            backgroundWorker.RunWorkerAsync();
         }
         else
         {
            backgroundWorker.CancelAsync();
         }
      }

      private void buttonRecalculateTotalDataStored_Click(object sender, EventArgs e)
      {
         RecalculateTotalDataStored();
      }

      private System.Threading.Timer _timer;

      private int _count = 0;
      public void _timerCallback(object state)
      {
         CurrentClientConnectionCountEventArgs e = new CurrentClientConnectionCountEventArgs();
         OnRequestCurrentClientConnectionCount(e);
         Console.WriteLine(_count.ToString());
         SetUptime();
         _count++;         
      }

      void SetUptime()
      {
         if (InvokeRequired)
         {
            Invoke(new MethodInvoker(SetUptime));
         }
         else
         {
            CalculateUptime();
         }
      }

      private void ServerInformationControl_VisibleChanged(object sender, EventArgs e)
      {
         if (Visible)
         {
            Initialize();
             _timer = new System.Threading.Timer(_timerCallback, null, 0, 1000);
         }
         else
         {
            if (_timer != null)
            {
               _timer.Dispose();
               _timer = null;
            }
         }
      }

      private void linkLabelServiceName_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
      {
         ProcessStartInfo psi = new ProcessStartInfo();

         psi.UseShellExecute = false;
         psi.FileName = "mmc";
         psi.Arguments = "services.msc";
         Process.Start(psi);
      }

      public void ResetStartTime()
      {
         StartTime = null;
      }

      public void SetStartTime()
      {
         IntPtr handle = IntPtr.Zero;
         IntPtr service = IntPtr.Zero;

         try
         {
            handle = OpenSCManager(null, null, (uint)SCM_ACCESS.SC_MANAGER_ALL_ACCESS);
            if (handle != IntPtr.Zero)
            {
               service = OpenService(handle, ServiceName, (uint)SERVICE_ALL_ACCESS);
               if (service != IntPtr.Zero)
               {
                  SERVICE_STATUS_PROCESS status = QueryServiceStatusEx(service);

                  if (status != null)
                  {
                     Process process = Process.GetProcessById(status.processID);

                     StartTime = process.StartTime;
                     SetUptime();
                  }
               }
            }
         }
         catch { }
         finally
         {
            if (service != IntPtr.Zero)
               CloseServiceHandle(service);
            if (handle != IntPtr.Zero)
               CloseServiceHandle(handle);
         }
      }

      public void CalculateUptime()
      {
         if (StartTime.HasValue)
         {
            TimeSpan uptime = DateTime.Now - StartTime.Value;
            string formatted = string.Format("{0}{1}{2}{3}",
                                             uptime.Days > 0 ? uptime.Days > 1 ? string.Format("{0:0} days, ", uptime.Days) : string.Format("{0:0} day, ", uptime.Days) : string.Empty,
                                             uptime.Hours > 0 ? uptime.Hours > 1 ? string.Format("{0:0} hours, ", uptime.Hours) : string.Format("{0:0} hour, ", uptime.Hours) : string.Empty,
                                             uptime.Minutes > 0 ? uptime.Minutes > 1 ? string.Format("{0:0} minutes, ", uptime.Minutes) : string.Format("{0:0} minute, ", uptime.Minutes) : string.Empty,
                                             uptime.Seconds > 0 ? string.Format("{0:0} seconds", uptime.Seconds) : string.Empty);


            if (formatted.EndsWith(", "))
            {
               formatted = formatted.Substring(0, formatted.Length - 2);
            }
            labelUptime.Text = formatted;
         }
         else
         {
            labelUptime.Text = string.Empty;
         }
      }

      public SERVICE_STATUS_PROCESS QueryServiceStatusEx(IntPtr serviceHandle)
      {
         IntPtr buf = IntPtr.Zero;
         try
         {
            int size = 0;

            QueryServiceStatusEx(serviceHandle, 0, buf, size, out size);

            buf = Marshal.AllocHGlobal(size);

            if (!QueryServiceStatusEx(serviceHandle, 0, buf, size, out size))
            {
               throw new Win32Exception(Marshal.GetLastWin32Error());
            }

            return (SERVICE_STATUS_PROCESS)Marshal.PtrToStructure(buf, typeof(SERVICE_STATUS_PROCESS));
         }
         finally
         {
            if (!buf.Equals(IntPtr.Zero))
               Marshal.FreeHGlobal(buf);
         }
      }

      private void listViewModules_ColumnClick(object sender, ColumnClickEventArgs e)
      {
         SortColumns(listViewModules, e.Column);
      }

   }

   public class CurrentClientConnectionCountEventArgs : EventArgs
   {
   }   
}
