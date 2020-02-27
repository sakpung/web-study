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
using System.IO;
using Leadtools.Demos;
using JobProcessorDashboardDemo.JobService;
using System.Data.SqlClient;
using System.Threading;
using Microsoft.Win32;
using System.Diagnostics;
using System.Reflection;

namespace JobProcessorDashboardDemo
{
   public partial class ClientForm : Form
   {
      public ClientForm(string wcfAddress, bool isOCRInstalled, bool isMultimediaInstalled)
      {
         InitializeComponent();
         _wcfAddress = wcfAddress;
         _isOCRInstalled = isOCRInstalled;
         _isMultimediaInstalled = isMultimediaInstalled;
      }

      DataTable _mmProfileDataTable = null;
      DataTable _jobsDataTable = null;
      string _userName = String.Empty;
      bool _retrievingJobs = false;
      System.Threading.Timer _refreshTimer = null;
      const int AutoRefreshPeriod = 10000;
      string _wcfAddress = string.Empty;
      bool _isOCRInstalled = false;
      bool _isMultimediaInstalled = false;

#if LTV175_CONFIG
      string[] MultimediaKeys = new string[] { @"LEAD Technologies, Inc.\17.5\LEADTOOLS Multimedia 17.5", @"LEAD Technologies, Inc.\17.5\LEADTOOLS Multimedia EVAL 17.5" };
      string[] OCRKeys = new string[] { @"LEAD Technologies, Inc.\OCRPathAdvantage175" };
#endif
#if LTV18_CONFIG
      string[] MultimediaKeys = new string[] { @"LEAD Technologies, Inc.\18\LEADTOOLS Multimedia 18", @"LEAD Technologies, Inc.\18\LEADTOOLS Multimedia EVAL 18" };
      string[] OCRKeys = new string[] { @"LEAD Technologies, Inc.\OCRPathAdvantage18" };
#endif

#if LTV19_CONFIG
      string[] MultimediaKeys = new string[] { @"LEAD Technologies, Inc.\19\LEADTOOLS Multimedia 19", @"LEAD Technologies, Inc.\19\LEADTOOLS Multimedia EVAL 19" };
      string[] OCRKeys = new string[] { @"LEAD Technologies, Inc.\OCRPathAdvantage19" };
#endif

#if LTV20_CONFIG
      string[] MultimediaKeys = new string[] { @"LEAD Technologies, Inc.\20\LEADTOOLS Multimedia 20", @"LEAD Technologies, Inc.\20\LEADTOOLS Multimedia EVAL 20" };
      string[] OCRKeys = new string[] { @"LEAD Technologies, Inc.\OCRPathLEAD20" };
#endif

      private void ClientForm_Load(object sender, EventArgs e)
      {
         //Set current directory to actual exe directory. This is done to ensure relative paths are resolved correctly,
         //even when running from shortcuts
         Environment.CurrentDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

         LoadSettings();

         //Setup Jobs datatable
         SetupJobsDatatable();

         //Only show multimedia tab if multimedia is installed
         if (!_isMultimediaInstalled)
            _tcJobTypes.TabPages.Remove(_tpMultimedia);
         else
         {
            //Setup multimedia profile datatable
            SetupMMProfileDatatable();
            EnumerateMMProfiles(Properties.Settings.Default.MMProfilePath);
         }

         if (_cmbOCRFormat.Items.Count > 0)
            _cmbOCRFormat.SelectedIndex = 0;

         //Only show ocr tab if ocr is installed
         if (!_isOCRInstalled)
            _tcJobTypes.TabPages.Remove(_tpOCR);
         else if (_cmbOCRFormat.Items.Count > 0)
            _cmbOCRFormat.SelectedIndex = 0;

         UpdateUI();
      }

      private void ClientForm_FormClosing(object sender, FormClosingEventArgs e)
      {
         if (e.CloseReason == CloseReason.UserClosing)
         {
            //User closing form, just minimize
            this.WindowState = FormWindowState.Minimized;
            e.Cancel = true;
            return;
         }

         if (_mmProfileDataTable != null)
            _mmProfileDataTable.Dispose();

         if (_refreshTimer != null)
            _refreshTimer.Dispose();

         SaveSettings();

         while (_retrievingJobs)
         {
            this.Text = "Please wait while the current operation completes.";
            Application.DoEvents();
         }
      }

      void SaveSettings()
      {
         //Save settings
         Properties.Settings.Default.AutoRefreshJobs = _chkAutoRefreshJobs.Checked;
         Properties.Settings.Default.Username = _userName;
         Properties.Settings.Default.Save();
      }

      void LoadSettings()
      {
         _userName = Properties.Settings.Default.Username;
         _chkAutoRefreshJobs.Checked = Properties.Settings.Default.AutoRefreshJobs;
      }

      private void _btnChangeUsername_Click(object sender, EventArgs e)
      {
         //Change username used to add jobs
         using (UsernameForm userNameForm = new UsernameForm())
         {
            userNameForm.UserName = _userName;
            if (userNameForm.ShowDialog() == DialogResult.OK)
               _userName = userNameForm.UserName;
         }

         UpdateUI();
      }

      void UpdateUI()
      {
         _lblUsername.Text = String.Format("Current Username: {0}", String.IsNullOrEmpty(_userName) ? "NA" : _userName);
         _lblJobCount.Text = String.Format("Job Count: {0}", _dgvJobs.Rows.Count);
      }

      private void _cmJobs_Opening(object sender, CancelEventArgs e)
      {
         _menuItemAbortJob.Enabled = _dgvJobs.SelectedRows.Count > 0;
         _menuItemResetJob.Enabled = _dgvJobs.SelectedRows.Count > 0;
         _menuItemDeleteJob.Enabled = _dgvJobs.SelectedRows.Count > 0;
         _menuItemOpenConvertedFile.Enabled = JobsComplete();
      }

      bool JobsComplete()
      {
         //Return true if at least one selected job is complete
         foreach (DataGridViewRow selectedJob in _dgvJobs.SelectedRows)
         {
            if (selectedJob.Cells[JobProcessorConstants.Database.StatusColumn].Value != DBNull.Value &&
               String.Compare((string)selectedJob.Cells[JobProcessorConstants.Database.StatusColumn].Value, JobStatus.Completed.ToString(), true) == 0)
            {
               return true;
            }
         }
         return false;
      }

      private void _menuItemOpenConvertedFile_Click(object sender, EventArgs e)
      {
         foreach (DataGridViewRow selectedJob in _dgvJobs.SelectedRows)
         {
            try
            {
               if (selectedJob.Cells[JobProcessorConstants.Database.StatusColumn].Value != DBNull.Value &&
                  String.Compare((string)selectedJob.Cells[JobProcessorConstants.Database.StatusColumn].Value, JobStatus.Completed.ToString(), true) == 0)
               {
                  string jobType = selectedJob.Cells[JobProcessorConstants.Database.JobTypeColumn].Value != DBNull.Value ? (string)selectedJob.Cells[JobProcessorConstants.Database.JobTypeColumn].Value : String.Empty;
                  string jobMetadata = selectedJob.Cells[JobProcessorConstants.Database.JobMetadataColumn].Value != DBNull.Value ? (string)selectedJob.Cells[JobProcessorConstants.Database.JobMetadataColumn].Value : String.Empty;

                  if (String.Compare(jobType, "OCR", true) == 0)
                     StartProcess(OcrData.DeserializeFromString(jobMetadata).DocumentFileName);
                  else if (String.Compare(jobType, "Multimedia", true) == 0)
                     StartProcess(MultimediaData.DeserializeFromString(jobMetadata).TargetFile);
               }
            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.Message, "Error");
            }
         } 
      }

      void StartProcess(string fileName)
      {
         if (!File.Exists(fileName))
            return;

         using (Process openFileProcess = new Process())
         {
            openFileProcess.StartInfo.FileName = fileName;
            openFileProcess.Start();
         }
      }

      bool DeleteJob(string jobID)
      {
         using (JobServiceClient jobService = new JobServiceClient())
         {
            string address = string.Format("{0}/JobService.svc", _wcfAddress);
            jobService.Endpoint.Address = new System.ServiceModel.EndpointAddress(address);

            //Delete the selected job using the DeleteJob WCF Service
            DeleteJobRequest deleteJobRequest = new DeleteJobRequest();
            deleteJobRequest.ID = jobID;
            DeleteJobResponse deleteJobResponse = jobService.DeleteJob(deleteJobRequest);
            return deleteJobResponse.IsDeleted;
         }
      }

      private void _dgvJobs_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
      {
         try
         {
            //Delete job from database first
            if (!DeleteJob((string)e.Row.Cells[JobProcessorConstants.Database.GuidColumn].Value))
            {
               //Job not successfully removed from database
               MessageBox.Show("Error removing job", "Error");
               e.Cancel = true;
            }
         }
         catch (Exception ex)
         {
            MessageBox.Show(ex.Message, "Error");
            e.Cancel = true;
         }
      }

      private void _menuItemDeleteJob_Click(object sender, EventArgs e)
      {
         try
         {
            foreach (DataGridViewRow selectedJob in _dgvJobs.SelectedRows)
            {
               if (DeleteJob((string)selectedJob.Cells[JobProcessorConstants.Database.GuidColumn].Value))
               {
                  //Remove from grid. Check if job stil exist in case it was removed by a refresh
                  if (_dgvJobs.Rows.IndexOf(selectedJob) != -1)
                     _dgvJobs.Rows.Remove(selectedJob);
               }
               else
               {
                  MessageBox.Show("Error removing job", "Error");
               }
            }
         }
         catch (Exception ex)
         {
            MessageBox.Show(ex.Message, "Error");
         }

         GetClientJobs();
         UpdateUI();
      }

      private void _menuItemAbortJob_Click(object sender, EventArgs e)
      {
         try
         {
            using (JobServiceClient jobService = new JobServiceClient())
            {
               string address = string.Format("{0}/JobService.svc", _wcfAddress);
               jobService.Endpoint.Address = new System.ServiceModel.EndpointAddress(address);

               //Abort each selected job using the AbortJob WCF Service
               foreach (DataGridViewRow selectedJob in _dgvJobs.SelectedRows)
               {
                  AbortJobRequest abortJobRequest = new AbortJobRequest();
                  abortJobRequest.ID = (string)selectedJob.Cells[JobProcessorConstants.Database.GuidColumn].Value; //"cGuid" is the ID (Guid) column name in the database
                  jobService.AbortJob(abortJobRequest);
               }
            }
         }
         catch (Exception ex)
         {
            MessageBox.Show(ex.Message, "Error");
         }

         GetClientJobs();
      }

      private void _menuItemResetJob_Click(object sender, EventArgs e)
      {
         try
         {
            using (JobServiceClient jobService = new JobServiceClient())
            {
               string address = string.Format("{0}/JobService.svc", _wcfAddress);
               jobService.Endpoint.Address = new System.ServiceModel.EndpointAddress(address);

               //Reset each selected job using the ResetJob WCF Service
               foreach (DataGridViewRow selectedJob in _dgvJobs.SelectedRows)
               {
                  ResetJobRequest resetJobRequest = new ResetJobRequest();
                  resetJobRequest.ID = (string)selectedJob.Cells[JobProcessorConstants.Database.GuidColumn].Value; //"cGuid" is the ID (Guid) column name in the database
                  jobService.ResetJob(resetJobRequest);
               }
            }
         }
         catch (Exception ex)
         {
            MessageBox.Show(ex.Message, "Error");
         }

         GetClientJobs();
      }

      void SetupJobsDatatable()
      {
         try
         {
            _jobsDataTable = new DataTable();

            //Set up the jobs table with the column in the database so we can bind it to the grid.
            _jobsDataTable.Columns.Add(JobProcessorConstants.Database.GuidColumn);
            _jobsDataTable.Columns.Add(JobProcessorConstants.Database.StatusColumn);
            _jobsDataTable.Columns.Add(JobProcessorConstants.Database.AddedTimeColumn);
            _jobsDataTable.Columns.Add(JobProcessorConstants.Database.AttemptsColumn);
            _jobsDataTable.Columns.Add(JobProcessorConstants.Database.CompletedTimeColumn);
            _jobsDataTable.Columns.Add(JobProcessorConstants.Database.FailedErrorIDColumn);
            _jobsDataTable.Columns.Add(JobProcessorConstants.Database.FailedMessageColumn);
            _jobsDataTable.Columns.Add(JobProcessorConstants.Database.FailedTimeColumn);
            _jobsDataTable.Columns.Add(JobProcessorConstants.Database.JobMetadataColumn);
            _jobsDataTable.Columns.Add(JobProcessorConstants.Database.JobTypeColumn);
            _jobsDataTable.Columns.Add(JobProcessorConstants.Database.LastStartedTimeColumn);
            _jobsDataTable.Columns.Add(JobProcessorConstants.Database.LastUpdatedTimeColumn);
            _jobsDataTable.Columns.Add(JobProcessorConstants.Database.MustAbortColumn);
            _jobsDataTable.Columns.Add(JobProcessorConstants.Database.AbortReasonColumn);
            _jobsDataTable.Columns.Add(JobProcessorConstants.Database.PercentageColumn);
            _jobsDataTable.Columns.Add(JobProcessorConstants.Database.UserTokenColumn);
            _jobsDataTable.Columns.Add(JobProcessorConstants.Database.WorkerColumn);
            _jobsDataTable.Columns.Add(JobProcessorConstants.Database.WorkerMetadataColumn);
         }
         catch (Exception ex)
         {
            MessageBox.Show(ex.Message, "Error");
         }
      }

      private void _chkAutoRefreshJobs_CheckedChanged(object sender, EventArgs e)
      {
         int dueTime = _chkAutoRefreshJobs.Checked ? 0 : Timeout.Infinite;

         if (_refreshTimer == null)
            _refreshTimer = new System.Threading.Timer(RefreshTimerCallback, null, dueTime, AutoRefreshPeriod);
         else
            _refreshTimer.Change(dueTime, AutoRefreshPeriod);
      }

      private void _btnRefreshJobs_Click(object sender, EventArgs e)
      {
         GetClientJobs();
      }

      private void RefreshTimerCallback(object state)
      {
         GetClientJobs();
      }

      void GetClientJobs()
      {
         //No need in spawning a new thread to retrieve jobs if we are already doing so
         if (_retrievingJobs)
            return;

         Thread getClientJobsThread = new Thread(new ThreadStart(GetClientJobsThreadProc));
         getClientJobsThread.Name = "getClientJobsThread";
         getClientJobsThread.Start();
      }

      void GetClientJobsThreadProc()
      {
         _retrievingJobs = true;
         try
         {
            using (JobServiceClient jobService = new JobServiceClient())
            {
               string address = string.Format("{0}/JobService.svc", _wcfAddress);
               jobService.Endpoint.Address = new System.ServiceModel.EndpointAddress(address);

               GetClientJobsRequest getClientJobsRequest = new GetClientJobsRequest();
               getClientJobsRequest.UserToken = _userName;
               GetClientJobsResponse getClientJobsResponse = jobService.GetClientJobs(getClientJobsRequest);

               this.Invoke(new MethodInvoker(delegate()
               {
                  _jobsDataTable.Clear();

                  _jobsDataTable.BeginLoadData();

                  foreach (string jobID in getClientJobsResponse.JobsIds)
                  {
                     GetJobInformationRequest getJobInformationRequest = new GetJobInformationRequest();
                     getJobInformationRequest.ID = jobID;
                     GetJobInformationResponse getJobInformationResponse = jobService.GetJobInformation(getJobInformationRequest);

                     DataRow jobRow = _jobsDataTable.NewRow();
                     jobRow[JobProcessorConstants.Database.AddedTimeColumn] = getJobInformationResponse.JobInformation.AddedTime;
                     jobRow[JobProcessorConstants.Database.AttemptsColumn] = getJobInformationResponse.JobInformation.Attempts;
                     jobRow[JobProcessorConstants.Database.CompletedTimeColumn] = getJobInformationResponse.JobInformation.CompletedTime;
                     jobRow[JobProcessorConstants.Database.FailedErrorIDColumn] = getJobInformationResponse.JobInformation.FailureInformation.FailedErrorID;
                     jobRow[JobProcessorConstants.Database.FailedMessageColumn] = getJobInformationResponse.JobInformation.FailureInformation.FailedMessage;
                     jobRow[JobProcessorConstants.Database.FailedTimeColumn] = getJobInformationResponse.JobInformation.FailedTime;
                     jobRow[JobProcessorConstants.Database.GuidColumn] = getJobInformationResponse.JobInformation.ID;
                     jobRow[JobProcessorConstants.Database.JobMetadataColumn] = getJobInformationResponse.JobInformation.Metadata.JobMetadata;
                     jobRow[JobProcessorConstants.Database.JobTypeColumn] = getJobInformationResponse.JobInformation.JobType;
                     jobRow[JobProcessorConstants.Database.LastStartedTimeColumn] = getJobInformationResponse.JobInformation.LastStartedTime;
                     jobRow[JobProcessorConstants.Database.LastUpdatedTimeColumn] = getJobInformationResponse.JobInformation.LastUpdatedTime;
                     jobRow[JobProcessorConstants.Database.MustAbortColumn] = getJobInformationResponse.JobInformation.Abort.MustAbort;
                     jobRow[JobProcessorConstants.Database.AbortReasonColumn] = getJobInformationResponse.JobInformation.Abort.AbortReason;
                     jobRow[JobProcessorConstants.Database.PercentageColumn] = getJobInformationResponse.JobInformation.Percentage;
                     jobRow[JobProcessorConstants.Database.StatusColumn] = getJobInformationResponse.JobInformation.Status;
                     jobRow[JobProcessorConstants.Database.UserTokenColumn] = getJobInformationResponse.JobInformation.Metadata.UserToken;
                     jobRow[JobProcessorConstants.Database.WorkerColumn] = getJobInformationResponse.JobInformation.Worker;
                     jobRow[JobProcessorConstants.Database.WorkerMetadataColumn] = getJobInformationResponse.JobInformation.Metadata.WorkerMetadata;

                     _jobsDataTable.Rows.Add(jobRow);
                  }

                  _jobsDataTable.EndLoadData();
               }));


               this.BeginInvoke(new MethodInvoker(delegate()
               {
                  _dgvJobs.DataSource = _jobsDataTable;
                  UpdateUI();
               }));
            }
         }
         catch (Exception ex)
         {
            this.Invoke(new MethodInvoker(delegate()
            {
               MessageBox.Show(ex.Message, "Error");
            }));
         }

         _retrievingJobs = false;
      }

      #region OCR Jobs

      private void _btnOCRAddJob_Click(object sender, EventArgs e)
      {
         //Validate conversion profile
         if (_cmbOCRFormat.SelectedIndex == -1)
         {
            MessageBox.Show("You must select a valid format", "Invalid Format");
            return;
         }

         try
         {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
               ofd.Multiselect = true;
               ofd.Filter = "Image Files(*.CMP;*.CMW;*.PDF;*.TIF;*.TIFF;*.PNG;*.BMP;*.JPG;*.GIF)|*.CMP;*.CMW;*.PDF;*.TIF;*.TIFF;*.PNG;*.BMP;*.JPG;*.GIF|All files (*.*)|*.*";
               if (ofd.ShowDialog(this) == DialogResult.OK)
               {
                  List<AddJobRequest> addJobRequestList = new List<AddJobRequest>(ofd.FileNames.Length);
                  foreach (string file in ofd.FileNames)
                  {
                     //Create output directory.
                     string outputDirectory = Path.Combine(Path.GetDirectoryName(file), "Dashboard Output");
                     if (!Directory.Exists(outputDirectory))
                     {
                        try
                        {
                           Directory.CreateDirectory(outputDirectory);
                        }
                        catch
                        {
                           outputDirectory = Path.GetDirectoryName(file);
                        }
                     }

                     //Create job metadata
                     OcrData ocrData = new OcrData(file, outputDirectory, _cmbOCRFormat.Text);
                     AddJobRequest addJobRequest = new AddJobRequest();
                     addJobRequest.UserToken = _userName;
                     addJobRequest.JobMetadata = OcrData.SerializeToString(ocrData);
                     addJobRequest.JobType = "OCR";
                     addJobRequestList.Add(addJobRequest);
                  }

                  using (JobServiceClient jobService = new JobServiceClient())
                  {
                     //Add jobs as in a batch
                     jobService.Endpoint.Address = new System.ServiceModel.EndpointAddress(string.Format("{0}/JobService.svc", _wcfAddress));

                     AddJobsRequest addJobsRequest  = new AddJobsRequest();
                     addJobsRequest.AddRange(addJobRequestList);
                     jobService.AddJobs(addJobsRequest);
                  }

                  MessageBox.Show("Job added successfully", "Success");
                  GetClientJobs();
               }
            }
         }
         catch (Exception ex)
         {
            MessageBox.Show(ex.Message, "Error");
         }

         UpdateUI();
      }

      #endregion //OCR Jobs

      #region MM Jobs

      private void _btnMMAddJob_Click(object sender, EventArgs e)
      {
         //Validate conversion profile
         if (_cmbMMConversionProfile.SelectedIndex == -1)
         {
            MessageBox.Show("You must select a conversion profile", "Invalid Profile");
            return;
         }

         try
         {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
               ofd.Multiselect = true;
               ofd.Filter = "Video Files (*.avi;*.mpg;*.mpeg;*.mxf;*.mkv;*.ogg;*.wmv.*.asf;*.qt;*.mov;*.m2v;*.m1v;*.ts;*.m2ts;*.mp4;*.3gp;*.flv;*.f4v;video_ts.ifo;*.LBL)|*.avi;*.mpg;*.mpeg;*.mxf;*.mkv;*.ogg;*.wmv.*.asf;*.qt;*.mov;*.m2v;*.m1v;*.ts;*.m2ts;*.mp4;*.3gp;*.flv;*.f4v;video_ts.ifo;*.LBL|Audio files (*.wav;*.wma;*.ogg;*.mpa;*.mp2;*.mp3;*.mxf;*.mkv;*.au;*.aif;*.aiff;*.snd;*.aac)|*.wav;*.wma;*.ogg;*.mpa;*.mp2;*.mp3;*.mxf;*.mkv;*.au;*.aif;*.aiff;*.snd;*.aac|MPEG Files (*.mpg;*.mpeg;*.m2v;*.m1v;*.ts;*.m2ts)|*.mpg;*.mpeg;*.m2v;*.m1v;*.ts;*.m2ts|MXF Files (*.mxf)|*.mxf|MKV Files (*.mkv)|*.mkv|Windows Media Files (*.asf;*.wma;*.wmv)|*.asf;*.wma;*.wmv|DVD Files (video_ts.ifo)|video_ts.ifo|All Files (*.*)|*.*";
               if (ofd.ShowDialog() == DialogResult.OK)
               {
                  List<AddJobRequest> addJobRequestList = new List<AddJobRequest>(ofd.FileNames.Length);
                  foreach (string file in ofd.FileNames)
                  {
                     //Create output directory.
                     string outputDirectory = Path.Combine(Path.GetDirectoryName(file), "Dashboard Output");
                     if (!Directory.Exists(outputDirectory))
                     {
                        try
                        {
                           Directory.CreateDirectory(outputDirectory);
                        }
                        catch
                        {
                           outputDirectory = Path.GetDirectoryName(file);
                        }
                     }

                     //Create job metadata
                     MultimediaData multimediaData = new MultimediaData(file, outputDirectory, File.ReadAllBytes((string)_cmbMMConversionProfile.SelectedValue), _cmbMMConversionProfile.Text);
                     AddJobRequest addJobRequest = new AddJobRequest();
                     addJobRequest.UserToken = _userName;
                     addJobRequest.JobMetadata = MultimediaData.SerializeToString(multimediaData);
                     addJobRequest.JobType = "Multimedia";
                     addJobRequestList.Add(addJobRequest);
                  }

                  using (JobServiceClient jobService = new JobServiceClient())
                  {
                     //Add jobs as a batch
                     jobService.Endpoint.Address = new System.ServiceModel.EndpointAddress(string.Format("{0}/JobService.svc", _wcfAddress));

                     AddJobsRequest addJobsRequest = new AddJobsRequest();
                     addJobsRequest.AddRange(addJobRequestList);
                     jobService.AddJobs(addJobsRequest);
                  }

                  MessageBox.Show("Job added successfully", "Success");
                  GetClientJobs();
               }
            }
         }
         catch (Exception ex)
         {
            MessageBox.Show(ex.Message, "Error");
         }
      }

      private void SetupMMProfileDatatable()
      {
         _mmProfileDataTable = new DataTable();
         _mmProfileDataTable.Columns.Add("Displayname");
         _mmProfileDataTable.Columns.Add("Filepath");
      }

      private void _btnMMLoadProfiles_Click(object sender, EventArgs e)
      {
         using (FolderBrowserDialog fbd = new FolderBrowserDialog())
         {
            fbd.Description = "Select Multimedia Profile Directory (*.profile)";
            if (fbd.ShowDialog() == DialogResult.OK)
            {
               //Save new path
               Properties.Settings.Default.MMProfilePath = fbd.SelectedPath;
               EnumerateMMProfiles(fbd.SelectedPath);
            }
         }
      }

      void EnumerateMMProfiles(string profilePath)
      {
         try
         {
            _mmProfileDataTable.Rows.Clear();

            // Enumerate all available profiles on the provided URL path (application settings)
            if (!String.IsNullOrEmpty(profilePath))
            {
               //The path may be a relative path, so we use 'GetFullPath' to obtain the absolute path
               profilePath = Path.GetFullPath(profilePath);

               if (!Directory.Exists(profilePath))
                  return;

               string[] mmProfiles = Directory.GetFiles(profilePath, "*.profile");
               _cmbMMConversionProfile.DisplayMember = "Displayname";
               foreach (string mmProfile in mmProfiles)
               {
                  DataRow newMMProfile = _mmProfileDataTable.NewRow();
                  newMMProfile["Displayname"] = Path.GetFileNameWithoutExtension(mmProfile);
                  newMMProfile["Filepath"] = mmProfile;
                  _mmProfileDataTable.Rows.Add(newMMProfile);
               }

               _cmbMMConversionProfile.DisplayMember = "Displayname";
               _cmbMMConversionProfile.ValueMember = "Filepath";
               _cmbMMConversionProfile.DataSource = _mmProfileDataTable;

               // select the first item in the list box.
               if (_cmbMMConversionProfile.Items.Count > 0)
                  _cmbMMConversionProfile.SelectedIndex = 0;
            }
         }
         catch (Exception ex)
         {
            MessageBox.Show(ex.Message);
         }
      }

      #endregion //MM Jobs
   }
}
