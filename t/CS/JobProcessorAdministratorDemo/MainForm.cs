// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.ServiceProcess;
using System.IO;
using System.Xml;
using System.Threading;
using System.Diagnostics;

using JobProcessorAdministratorDemo.JobService;
using System.Text.RegularExpressions;
using System.Configuration;
using Leadtools.Demos;

namespace JobProcessorAdministratorDemo
{
   public partial class MainForm : Form
   {
      System.Windows.Forms.Timer scRefreshTimer = null;
      System.Windows.Forms.Timer queryRefreshTimer = null;
      DataTable jobsDataTable = new DataTable();
      DataTable workersDataTable = new DataTable();
      long numRunningThreads = 0;
      string _hostAddress = string.Empty;
      string _IISAddress = string.Empty;
      string _connectionString = string.Empty;
      bool _userHost;
      string currentQuery = String.Empty;
      bool queryInProgress = false;

      public MainForm(string address, bool userHost, string connectionString)
      {
         InitializeComponent();

         if (userHost)
         {
            _hostAddress = address;
         }
         else
         {
            _IISAddress = address;
         }

         _userHost = userHost;
         _connectionString = connectionString;
      }

      public MainForm()
      {
         InitializeComponent();
      }

      private void MainForm_Load(object sender, EventArgs e)
      {
         if (Properties.Settings.Default.ShowTroubleShooting)
         {
            using (TroubleshootingDlg troubleShootingDlg = new TroubleshootingDlg())
               troubleShootingDlg.ShowDialog();
         }

         SetUpWorkerRefreshTimer();
         SetUpQueryRefreshTimer();
         _chkAutoRefreshQuery.Checked = Properties.Settings.Default.AutoRefreshJobs;
         SetupWorkerDatatable();
         _btnReloadWorkerList_Click(this, null);
         SetUpStatusCombo();
         UpdateControllerControls();

         UpdateButtons();
      }

      void UpdateButtons()
      {
         _dtAddDate.Enabled = _cbAddDate.Checked;
         _txtGuid.Enabled = _cbGuid.Checked;

         //The start/stop buttons are enabled/disabled as described below.
         //If no machines are selected, they are disabled.
         //If one or more machines are selected, both buttons are enabled. If a button is clicked, that action will only be carried out if the machine status allows for it.
         if (_dgWorkerMachines.SelectedRows.Count < 1)
         {
            _btnStopNow.Enabled = false;
            _btnStart.Enabled = false;
         }
         else
         {
            _btnStopNow.Enabled = true;
            _btnStart.Enabled = true;
         }
      }

      private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
      {
         SaveSettings();
         scRefreshTimer.Enabled = false;
         //If any threads are running, wait until they are complete to avoid crashes.
         while (Interlocked.Read(ref numRunningThreads) != 0)
         {
            this.Text = "Please wait while all connections with workers are closed.";
            Application.DoEvents();
         }
      }

      void SaveSettings()
      {
         Properties.Settings settings = new Properties.Settings();

         if (_userHost == true)
         {
            settings.HostAddress = _hostAddress;
         }

         settings.UserHost = _userHost;

         settings.ConnectionString = _connectionString;
         settings.AutoRefreshJobs = _chkAutoRefreshQuery.Checked;

         settings.Save();
      }

      private void _menuItemExit_Click(object sender, EventArgs e)
      {
         this.Close();
      }

      private void _menuItemTroubleshooting_Click(object sender, EventArgs e)
      {
         using (TroubleshootingDlg troubleShootingDlg = new TroubleshootingDlg())
            troubleShootingDlg.ShowDialog();
      }

      #region Database Code

      //Timer used to refresh queries
      private void SetUpQueryRefreshTimer()
      {
         try
         {
            queryRefreshTimer = new System.Windows.Forms.Timer();
            queryRefreshTimer.Interval = 5000;
            queryRefreshTimer.Tick += new EventHandler(queryRefreshTimer_Tick);
         }
         catch (Exception ex)
         {
            MessageBox.Show(ex.Message);
         }
      }

      void queryRefreshTimer_Tick(object sender, EventArgs e)
      {
         if (String.IsNullOrEmpty(currentQuery))
            return;

         if (queryInProgress)
            return;

         DoQuery();
      }

      private void _chkAutoRefreshQuery_CheckedChanged(object sender, EventArgs e)
      {
         queryRefreshTimer.Enabled = _chkAutoRefreshQuery.Checked;
      }

      bool IsGUID(string guidToTest)
      {
         try
         {
            if (!String.IsNullOrEmpty(guidToTest))
            {
               Regex guidRegEx = new Regex(@"^(\{{0,1}([0-9a-fA-F]){8}-([0-9a-fA-F]){4}-([0-9a-fA-F]){4}-([0-9a-fA-F]){4}-([0-9a-fA-F]){12}\}{0,1})$");
               return guidRegEx.IsMatch(guidToTest);
            }
         }
         catch { }
         return false;
      }

      public void _btnDoQuery_Click(object sender, EventArgs e)
      {
         if (queryInProgress)
         {
            MessageBox.Show("A query is currently in progress. Please wait until thr current query has completed", "Error");
            return;
         }

         try
         {
            //Create Query
            List<string> queryList = new List<string>();

            if (_cbGuid.Checked)
            {
               if (!IsGUID(_txtGuid.Text))
               {
                  MessageBox.Show("You must enter a valid ID / Guid (36 characters including 4 hyphens).", "Error");
                  return;
               }

               queryList.Add(String.Format("{0} = '{1}'", JobProcessorConstants.Database.GuidColumn, _txtGuid.Text));
            }

            if (_cbAddDate.Checked)
               queryList.Add(String.Format("{0} >= '{1}' AND {0} < '{2}'", JobProcessorConstants.Database.AddedTimeColumn, _dtAddDate.Value.Date, _dtAddDate.Value.AddDays(1).Date));

            //You can select multiple status values so we OR those together separately then combine it with the main query
            if (_clbStatus.CheckedItems.Count > 0)
            {
               string statusQuery = "(";
               for (int i = 0; i < _clbStatus.CheckedItems.Count; i++)
               {
                  if (i == _clbStatus.CheckedItems.Count - 1) //last item
                     statusQuery += String.Format("{0} = '{1}'", JobProcessorConstants.Database.StatusColumn, _clbStatus.GetItemText(_clbStatus.CheckedItems[i]));
                  else
                     statusQuery += String.Format("{0} = '{1}' OR ", JobProcessorConstants.Database.StatusColumn, _clbStatus.GetItemText(_clbStatus.CheckedItems[i]));
               }
               statusQuery += ")";
               queryList.Add(statusQuery);
            }

            if (queryList.Count == 0)
            {
               MessageBox.Show("You must choose a query option");
               return;
            }

            string concatenatedQuery = String.Empty;
            for (int i = 0; i < queryList.Count; i++)
            {
               if (i == queryList.Count - 1) //last item
                  concatenatedQuery += String.Format(" {0}", queryList[i]);
               else
                  concatenatedQuery += String.Format(" {0} AND", queryList[i]);
            }

            //Send query
            currentQuery = String.Format("select * from {0} where {1}", JobProcessorConstants.Database.JobsTable, concatenatedQuery);
            DoQuery();
         }
         catch (Exception ex)
         {
            MessageBox.Show(ex.Message);
         }
      }

      void DoQuery()
      {
         try
         {
            Thread queryThread = new Thread(new ThreadStart(DoQueryThreadProc));
            queryThread.Start();
         }
         catch (Exception ex)
         {
            MessageBox.Show(ex.Message);
         }
      }

      private void DoQueryThreadProc()
      {
         Interlocked.Increment(ref numRunningThreads);
         DataTable temptable = null;
         try
         {
            if (String.IsNullOrEmpty(currentQuery))
               return;

            queryInProgress = true;

            this.BeginInvoke(new MethodInvoker(delegate()
            {
               jobsDataTable.Clear();
            }));

            //Use a temp table since dataAdapter.Fill can take time and needs to run on the UI thread (it is bound to the grid). We do not want to block the UI
            temptable = new DataTable();
            using (SqlDataAdapter dataAdapter = new SqlDataAdapter(currentQuery, _connectionString))
               dataAdapter.Fill(temptable);

            this.Invoke(new MethodInvoker(delegate()
            {
               jobsDataTable = temptable.Copy();
               _dgDBJobs.DataSource = jobsDataTable;
               UpdateRowCount();
            }));
         }
         catch (Exception ex)
         {
            this.Invoke(new MethodInvoker(delegate()
            {
               MessageBox.Show(ex.Message);
            }));
         }
         finally
         {
            if (temptable != null)
               temptable.Dispose();

            queryInProgress = false;
         }

         Interlocked.Decrement(ref numRunningThreads);
      }

      private void UpdateRowCount()
      {
         _lblRowCount.Text = String.Format("Job Count: {0}", _dgDBJobs.RowCount.ToString());
      }

      private void _btnCustomQuery_Click(object sender, EventArgs e)
      {
         if (queryInProgress)
         {
            MessageBox.Show("A query is currently in progress. Please wait until thr current query has completed", "Error");
            return;
         }

         //show custom query dialog
         using (CustomQueryDlg customQueryDlg = new CustomQueryDlg())
         {
            if (customQueryDlg.ShowDialog() == DialogResult.OK)
            {
               currentQuery = customQueryDlg.CustomQuery;
               DoQuery();
            }
         }
      }

      private void SetUpStatusCombo()
      {
         try
         {
            //load FileStatus enum values into checklistbox
            foreach (JobStatus jobStatus in Enum.GetValues(typeof(JobStatus)))
            {
               if (jobStatus != JobStatus.NotFound)
                  _clbStatus.Items.Add(jobStatus);
            }
         }
         catch (Exception ex)
         {
            MessageBox.Show(ex.Message);
         }
      }

      private void _cmJobOptions_Opening(object sender, CancelEventArgs e)
      {
         _tsResetJob.Enabled = _dgDBJobs.SelectedRows.Count > 0;
         _tsDeleteJob.Enabled = _dgDBJobs.SelectedRows.Count > 0;
      }

      private void _tsDeleteJob_Click(object sender, EventArgs e)
      {
         string address = string.Format("{0}/JobService.svc", _userHost ? _hostAddress : _IISAddress);

         try
         {
            using (JobServiceClient jobService = new JobServiceClient())
            {
               jobService.Endpoint.Address = new System.ServiceModel.EndpointAddress(address);
               foreach (DataGridViewRow rowToDelete in _dgDBJobs.SelectedRows)
               {
                  //Remove from database
                  DeleteJobRequest deleteRequest = new DeleteJobRequest();
                  deleteRequest.ID = rowToDelete.Cells[JobProcessorConstants.Database.GuidColumn].Value.ToString();
                  DeleteJobResponse deleteJobResponse = jobService.DeleteJob(deleteRequest);
                  if (deleteJobResponse.IsDeleted)
                  {
                     //Remove from grid. Check if job stil exist in case it was removed by a refresh
                     if (_dgDBJobs.Rows.IndexOf(rowToDelete) != -1)
                        _dgDBJobs.Rows.Remove(rowToDelete);
                  }
                  else
                  {
                     MessageBox.Show("Error removing job");
                  }
               }
            }
         }
         catch (Exception ex)
         {
            MessageBox.Show(ex.Message);
         }

         UpdateRowCount();
      }

      private void _tsResetJob_Click(object sender, EventArgs e)
      {
         try
         {
            using (JobServiceClient jobService = new JobServiceClient())
            {
               string address = string.Format("{0}/JobService.svc", _userHost ? _hostAddress : _IISAddress);
               jobService.Endpoint.Address = new System.ServiceModel.EndpointAddress(address);

               foreach (DataGridViewRow rowToDelete in _dgDBJobs.SelectedRows)
               {
                  //Reset job
                  ResetJobRequest resetRequest = new ResetJobRequest();
                  resetRequest.ID = rowToDelete.Cells[JobProcessorConstants.Database.GuidColumn].Value.ToString();
                  jobService.ResetJob(resetRequest);
               }
            }
         }
         catch (Exception ex)
         {
            MessageBox.Show(ex.Message);
         }
      }

      private void _cbGuid_CheckedChanged(object sender, EventArgs e)
      {
         UpdateButtons();
      }

      private void _cbAddDate_CheckedChanged(object sender, EventArgs e)
      {
         UpdateButtons();
      }

      private void _btnAnalyzeDB_Click(object sender, EventArgs e)
      {
         if (queryInProgress)
         {
            MessageBox.Show("A query is currently in progress. Please wait until thr current query has completed", "Error");
            return;
         }

         //Check to make sure all services are stopped
         foreach (DataRow workerRow in workersDataTable.Rows)
         {
            if (String.Compare((string)workerRow[_clmWorkerStatus.Name], ServiceControllerStatus.Stopped.ToString(), true) != 0)
            {
               MessageBox.Show("All worker machine services should be stopped before using the 'Analyze Database' feature");
               return;
            }
         }

         if (MessageBox.Show("The 'Analyze Database' feature will reset all jobs with a status of 'Queried' or 'Started' to 'New'. All worker machine services should be stopped before using this feature.",
            "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
         {
            try
            {
               using (SqlConnection dbConnection = new SqlConnection(_connectionString))
               {
                  dbConnection.Open();
                  using (SqlCommand command = new SqlCommand())
                  {
                     command.CommandType = CommandType.Text;
                     command.Connection = dbConnection;
                     //Query for all jobs this machine is working on whose status is Started
                     //Update JobsTable Set StatusColumn = JobStatus.New Where StatusColumn = JobStatus.Queried Or StatusColumn = JobStatus.Started
                     command.CommandText = String.Format("Update {0} Set {1} = '{2}' Where {1} = '{3}' Or {1} = '{4}'",
                        JobProcessorConstants.Database.JobsTable, JobProcessorConstants.Database.StatusColumn, JobStatus.New, JobStatus.Queried.ToString(), JobStatus.Started.ToString());
                     command.ExecuteNonQuery();

                     MessageBox.Show("Analyze Complete", "Complete");
                  }
               }
            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.Message);
            }
         }
      }

      #endregion

      #region Service Controller / Worker Information

      //Used to send machine and service information to the worker thread
      struct ServiceThreadData
      {
         public ServiceAction ServiceAction;
         public string MachineName;
         public string ServiceName;

         public ServiceThreadData(ServiceAction _serviceAction, string _machineName, string _serviceName)
         {
            ServiceAction = _serviceAction;
            MachineName = _machineName;
            ServiceName = _serviceName;
         }
      }

      private enum ServiceAction
      {
         StartService,
         StopService,
      }

      struct WorkerInfo
      {
         public string Name;
         public string ServiceName;
         public string ServiceStatus;
         public int CPUUsage;
         public int JobCount;
      }

      private void _btnReloadWorkerList_Click(object sender, EventArgs e)
      {
         //Load worker information in background thread to prevent locking UI
         Thread loadWorkerThread = new Thread(new ThreadStart(LoadWorkers));
         loadWorkerThread.Name = "loadWorkerThread";
         loadWorkerThread.Start();
      }

      private void SetupWorkerDatatable()
      {
         //Setup workersDataTable
         workersDataTable.Columns.Add(_clmWorkerName.Name, typeof(string));
         workersDataTable.Columns.Add(_clmWorkerServiceName.Name, typeof(string));
         workersDataTable.Columns.Add(_clmWorkerStatus.Name, typeof(string));
         workersDataTable.Columns.Add(_clmWorkerCPUUsage.Name, typeof(string));
         workersDataTable.Columns.Add(_clmWorkerJobCount.Name, typeof(string));
         workersDataTable.Columns.Add(_clmWorkerIsRetrieving.Name, typeof(bool));
         workersDataTable.Columns.Add(_clmWorkerIsSending.Name, typeof(bool));

         //Primary key will be worker name and service name since this is unique
         workersDataTable.PrimaryKey = new DataColumn[] { workersDataTable.Columns[_clmWorkerName.Name], workersDataTable.Columns[_clmWorkerServiceName.Name] };
      }

      private void LoadWorkers()
      {
         this.Invoke(new MethodInvoker(delegate()
         {
            this.scRefreshTimer.Enabled = false;
            this._gbServiceController.Enabled = this._gbQueryOptions.Enabled = _dgDBJobs.Enabled = _mainMenu.Enabled = false;
            _lblWorkerMachines.Text = "Worker Machines (Loading Worker Information...)";
            _pbLoadingWorkers.Visible = true;
            this.workersDataTable.Rows.Clear();
         }));

         //Wait for all other pending request to finish executing.
         while (Interlocked.Read(ref numRunningThreads) != 0)
            Application.DoEvents();

         Interlocked.Increment(ref numRunningThreads);

         //We are loading worker information in a thread so we will create a list of errors and show them
         //once after all machine information had been loaded
         List<string> errorList = new List<string>();
         try
         {
            //Get the list of workers machines. This allows us to retrieve updated worker information and control the windows service on each worker.
            //We will use a 'select distinct' query on the database to obtain the list of workers.
            List<string> machineNames = new List<string>();
            string sqlQuery = String.Format("select distinct {0} from {1}", JobProcessorConstants.Database.WorkerColumn, JobProcessorConstants.Database.JobsTable);
            using (SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlQuery, _connectionString))
            {
               using (DataTable dataTable = new DataTable())
               {
                  dataAdapter.Fill(dataTable);

                  foreach (DataRow workerMachine in dataTable.Rows)
                  {
                     if (workerMachine[JobProcessorConstants.Database.WorkerColumn] == DBNull.Value || String.IsNullOrEmpty((string)workerMachine[JobProcessorConstants.Database.WorkerColumn]))
                        continue;

                     machineNames.Add((string)workerMachine[JobProcessorConstants.Database.WorkerColumn]);
                  }
               }
            }

            foreach (string machineName in machineNames)
            {
               ServiceController[] serviceControllers = null;
               try
               {
                  //Get list of services on this machine.
                  serviceControllers = ServiceController.GetServices(machineName);
                  foreach (ServiceController serviceController in serviceControllers)
                  {
                     //If the service name includes 'LEADTOOLS' and 'JobProcessor', we will add it to our list
                     if (serviceController.ServiceName.IndexOf("LEADTOOLS", StringComparison.InvariantCultureIgnoreCase) == -1 ||
                         serviceController.ServiceName.IndexOf("JobProcessor", StringComparison.InvariantCultureIgnoreCase) == -1)
                        continue;

                     this.Invoke(new MethodInvoker(delegate()
                     {
                        DataRow newWorker = workersDataTable.NewRow();
                        newWorker[_clmWorkerName.Name] = machineName;
                        newWorker[_clmWorkerServiceName.Name] = serviceController.ServiceName;
                        newWorker[_clmWorkerStatus.Name] = "Unknown";
                        newWorker[_clmWorkerCPUUsage.Name] = "Unknown";
                        newWorker[_clmWorkerJobCount.Name] = "Unknown";
                        newWorker[_clmWorkerIsRetrieving.Name] = false;
                        newWorker[_clmWorkerIsSending.Name] = false;

                        workersDataTable.Rows.Add(newWorker);
                     }));
                  }
               }
               catch (Exception ex)
               {
                  //Add error to list
                  errorList.Add(ex.Message);
               }
               finally
               {
                  if (serviceControllers != null)
                  {
                     foreach (ServiceController serviceController in serviceControllers)
                        serviceController.Dispose();
                  }
               }
            }

            this.BeginInvoke(new MethodInvoker(delegate()
            {
               //Bind worker grid view
               _dgWorkerMachines.DataSource = workersDataTable;
            }));
         }
         catch (Exception ex)
         {
            //Add error to list
            errorList.Add(ex.Message);
         }

         //Check if any errors occured
         if (errorList.Count > 0)
         {
            string displayMessage = "The following errors occured while attempting to load worker information. Please see 'Help' --> 'Troubleshooting' for more information.";
            foreach (string error in errorList)
               displayMessage = String.Format("{0}{1}{1}{2}", displayMessage, Environment.NewLine, error);

            this.Invoke(new MethodInvoker(delegate()
            {
               MessageBox.Show(this, displayMessage, "Error");
            }));
         }

         this.BeginInvoke(new MethodInvoker(delegate()
         {
            this.scRefreshTimer.Enabled = true;
            this._gbServiceController.Enabled = this._gbQueryOptions.Enabled = _dgDBJobs.Enabled = _mainMenu.Enabled = true;
            _lblWorkerMachines.Text = "Workers Machines";
            _pbLoadingWorkers.Visible = false;
            UpdateButtons();
         }));

         Interlocked.Decrement(ref numRunningThreads);
      }

      //Timer used to refresh worker information
      private void SetUpWorkerRefreshTimer()
      {
         try
         {
            scRefreshTimer = new System.Windows.Forms.Timer();
            scRefreshTimer.Interval = 5000;
            scRefreshTimer.Tick += new EventHandler(scRefreshTimer_Tick);
         }
         catch (Exception ex)
         {
            MessageBox.Show(ex.Message);
         }
      }

      private void _lvMachines_SelectedIndexChanged(object sender, EventArgs e)
      {
         UpdateButtons();
      }

      void scRefreshTimer_Tick(object sender, EventArgs e)
      {
         UpdateControllerControls();
      }

      private void UpdateControllerControls()
      {
         //Update all machines if they are not busy
         for (int i = 0; i < _dgWorkerMachines.Rows.Count; i++)
         {
            if ((bool)_dgWorkerMachines.Rows[i].Cells[_clmWorkerIsRetrieving.Name].Value)
               continue;

            WorkerInfo workerInfo = new WorkerInfo();
            workerInfo.Name = (string)_dgWorkerMachines.Rows[i].Cells[_clmWorkerName.Name].Value;
            workerInfo.ServiceName = (string)_dgWorkerMachines.Rows[i].Cells[_clmWorkerServiceName.Name].Value;

            Thread statusThread = new Thread(new ParameterizedThreadStart(GetMachineStatus));
            statusThread.Start(workerInfo);
         }
      }

      //Delegate used to update all of the machines info
      private delegate void UpdateMachineInfoDelegate(WorkerInfo workerInfo);
      private void UpdateMachineInfo(WorkerInfo workerInfo)
      {
         DataRow workerRow = workersDataTable.Rows.Find(new object[] { workerInfo.Name, workerInfo.ServiceName });
         if (workerRow != null)
         {
            //Service Status
            if (!String.IsNullOrEmpty(workerInfo.ServiceStatus))
               workerRow[_clmWorkerStatus.Name] = workerInfo.ServiceStatus;

            //CPU Usage
            workerRow[_clmWorkerCPUUsage.Name] = workerInfo.CPUUsage == -1 ? "Unknown" : String.Format("{0} %", workerInfo.CPUUsage);
            //Job Count
            workerRow[_clmWorkerJobCount.Name] = workerInfo.JobCount == -1 ? "Unknown" : workerInfo.JobCount.ToString();
         }
         _dgWorkerMachines.DataSource = workersDataTable;
      }

      //Delegate used to update the retrieving status of a worker machine
      private delegate void UpdateRetrievingStatusDelegate(string machineName, string serviceName, bool isRetrieving);
      private void UpdateRetrievingStatus(string machineName, string serviceName, bool isRetrieving)
      {
         DataRow workerRow = workersDataTable.Rows.Find(new object[] { machineName, serviceName });
         if (workerRow != null)
            workerRow[_clmWorkerIsRetrieving.Name] = isRetrieving;

         _dgWorkerMachines.DataSource = workersDataTable;
      }

      //Delegate used to update the sending status of a worker machine
      private delegate void UpdateSendingStatusDelegate(string machineName, string serviceName, bool isSending);
      private void UpdateSendingStatus(string machineName, string serviceName, bool isSending)
      {
         DataRow workerRow = workersDataTable.Rows.Find(new object[] { machineName, serviceName });
         if (workerRow != null)
            workerRow[_clmWorkerIsSending.Name] = isSending;

         _dgWorkerMachines.DataSource = workersDataTable;
      }

      private void _btnStart_Click(object sender, EventArgs e)
      {
         //Only attempt to start the service on machines which are selected
         for (int i = 0; i < _dgWorkerMachines.SelectedRows.Count; i++)
         {
            if ((bool)_dgWorkerMachines.SelectedRows[i].Cells[_clmWorkerIsSending.Name].Value)
               continue; //already sending a service action

            Thread commandThread = new Thread(new ParameterizedThreadStart(SendServiceCommand));
            commandThread.Start(new ServiceThreadData(ServiceAction.StartService, (string)_dgWorkerMachines.SelectedRows[i].Cells[_clmWorkerName.Name].Value, (string)_dgWorkerMachines.SelectedRows[i].Cells[_clmWorkerServiceName.Name].Value));
         }
      }

      private void _btnStop_Click(object sender, EventArgs e)
      {
         //Only attempt to stop the service on machines which are selected
         for (int i = 0; i < _dgWorkerMachines.SelectedRows.Count; i++)
         {
            if ((bool)_dgWorkerMachines.SelectedRows[i].Cells[_clmWorkerIsSending.Name].Value)
               continue; //already sending a service action

            Thread commandThread = new Thread(new ParameterizedThreadStart(SendServiceCommand));
            commandThread.Start(new ServiceThreadData(ServiceAction.StopService, (string)_dgWorkerMachines.SelectedRows[i].Cells[_clmWorkerName.Name].Value, (string)_dgWorkerMachines.SelectedRows[i].Cells[_clmWorkerServiceName.Name].Value));
         }
      }

      private void SendServiceCommand(object threadData)
      {
         Interlocked.Increment(ref numRunningThreads);
         ServiceThreadData serviceThreadData = (ServiceThreadData)threadData;

         //Update the sending status to true
         this.Invoke(new UpdateSendingStatusDelegate(UpdateSendingStatus), new Object[] { serviceThreadData.MachineName, serviceThreadData.ServiceName, true });

         //Attempt to connect to remote service and performed the specified action
         try
         {
            using (ServiceController controller = new ServiceController(serviceThreadData.ServiceName, serviceThreadData.MachineName))
            {
               switch (serviceThreadData.ServiceAction)
               {
                  case ServiceAction.StartService:
                     if (controller.Status == ServiceControllerStatus.Stopped)
                     {
                        controller.Start();
                        controller.WaitForStatus(ServiceControllerStatus.Running, new TimeSpan(0, 0, 10));
                     }
                     else if (controller.Status == ServiceControllerStatus.Paused)
                     {
                        // Restart the service
                        controller.Stop();
                        controller.WaitForStatus(ServiceControllerStatus.Stopped, new TimeSpan(0, 0, 10));

                        controller.Start();
                        controller.WaitForStatus(ServiceControllerStatus.Running, new TimeSpan(0, 0, 10));
                     }
                     break;

                  case ServiceAction.StopService:
                     if ((controller.Status == ServiceControllerStatus.Running || controller.Status == ServiceControllerStatus.Paused) && controller.CanStop == true)
                     {
                        controller.Stop();
                        controller.WaitForStatus(ServiceControllerStatus.Stopped, new TimeSpan(0, 0, 10));
                     }
                     break;

                  default:
                     MessageBox.Show("Default");
                     break;
               }
            }
         }
         catch(Exception ex)
         {
            this.BeginInvoke(new MethodInvoker(delegate()
            {
               string message = String.Format("The {0} service on {1} did not {2} within the timeout period. Check the event viewer on the worker for more information.",
                  serviceThreadData.ServiceName, serviceThreadData.MachineName, serviceThreadData.ServiceAction == ServiceAction.StartService ? "start" : "stop");
               MessageBox.Show(this, message, "Error");
            }));
         }

         //Update the sending status to false
         this.Invoke(new UpdateSendingStatusDelegate(UpdateSendingStatus), new Object[] { serviceThreadData.MachineName, serviceThreadData.ServiceName, false });

         Interlocked.Decrement(ref numRunningThreads);
      }

      private void GetMachineStatus(object threadData)
      {
         Interlocked.Increment(ref numRunningThreads);

         WorkerInfo workerInfo = (WorkerInfo)threadData;

         //Update the retrieving status to true
         this.Invoke(new UpdateRetrievingStatusDelegate(UpdateRetrievingStatus), new Object[] { workerInfo.Name, workerInfo.ServiceName, true });

         //Update service status
         try
         {
            using (ServiceController controller = new ServiceController(workerInfo.ServiceName, workerInfo.Name))
               workerInfo.ServiceStatus = controller.Status.ToString();
         }
         catch (Exception ex)
         {
            //Update status with error message
            workerInfo.ServiceStatus = String.Format("Error - {0}", ex.Message);
         }

         //Update CPU usage
         try
         {
            using (PerformanceCounter performanceCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total", workerInfo.Name))
            {
               performanceCounter.NextValue();
               //Wait 1 second so the counter can update.
               Thread.Sleep(1000);
               workerInfo.CPUUsage = (int)performanceCounter.NextValue();
            }
         }
         catch
         {
            workerInfo.CPUUsage = -1;
         }

         //Update job count
         try
         {
            using (SqlConnection dbConnection = new SqlConnection(_connectionString))
            {
               dbConnection.Open();
               using (SqlCommand command = new SqlCommand())
               {
                  command.CommandType = CommandType.Text;
                  command.Connection = dbConnection;
                  //Query for all jobs this machine is working on whose status is Started
                  command.CommandText = String.Format("select count({0}) from {1} where {2} = '{3}' AND {4} = '{5}'",
                     JobProcessorConstants.Database.GuidColumn, JobProcessorConstants.Database.JobsTable, JobProcessorConstants.Database.WorkerColumn,
                     workerInfo.Name, JobProcessorConstants.Database.StatusColumn, JobStatus.Started);
                  object jobCount = command.ExecuteScalar();
                  workerInfo.JobCount = jobCount == DBNull.Value ? 0 : (int)jobCount;
               }
            }
         }
         catch
         {
            workerInfo.JobCount = -1;
         }

         //Update the info
         this.Invoke(new UpdateMachineInfoDelegate(UpdateMachineInfo), new Object[] { workerInfo });

         //Update the retrieving status to false
         this.Invoke(new UpdateRetrievingStatusDelegate(UpdateRetrievingStatus), new Object[] { workerInfo.Name, workerInfo.ServiceName, false });

         Interlocked.Decrement(ref numRunningThreads);
      }

      #endregion

      protected override void OnClosed(EventArgs e)
      {
         base.OnClosed(e);
      }
   }
}
