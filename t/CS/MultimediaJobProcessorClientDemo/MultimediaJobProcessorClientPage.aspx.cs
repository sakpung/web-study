// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Net;

using MultimediaJobProcessorClientDemo.JobServiceReference;
using Leadtools.Demos;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace MultimediaJobProcessorClientDemo
{
   public partial class MultimediaJobProcessorClientPage : System.Web.UI.Page
   {
      private string _inputFilesUrl;
      private string _outputFilesUrl;
      private string _outputFilesName;
      private string _profilesUrl;
      private JobService _jobService;

      protected void Page_Load(object sender, EventArgs e)
      {
         if (Page.PreviousPage != null && Page.PreviousPage.IsValid)
         {
            // Get the value of UserName and Token from the page that posted to this page.
            string userName = ((TextBox)PreviousPage.FindControl("_tbUserName")).Text;
            // If user name was specified, use it as the user token.
            if (!string.IsNullOrEmpty(userName))
               _hiddenFieldClientMetadata.Value = userName;
         }

         if (!IsPostBack)
         {
            // Enumerate the source files and conversion profiles on the server path
            EnumerateURLSourceFiles();
            EnumerateProfiles();

            Session["tblSelected"] = null;

            // Initially sort the jobs list by their added Date/Time
            ViewState["SortExpression"] = "Added Data/Time";
            GetClientJobs();
         }

         UpdateUIState();
      }

      protected override void OnInit(EventArgs e)
      {
         // Load the input and output files URL paths from the config file.
         Properties.Settings settings = new Properties.Settings();

         // make sure the input and output directories contains "\" at the end.
         _inputFilesUrl = settings.InputFilesUrl;
         if (_inputFilesUrl[_inputFilesUrl.Length - 1] != '\\')
            _inputFilesUrl += "\\";

         _outputFilesUrl = settings.OutputFilesUrl;
         if (_outputFilesUrl[_outputFilesUrl.Length - 1] != '\\')
            _outputFilesUrl += "\\";

         _profilesUrl = settings.ProfilesUrl;
         if (_profilesUrl[_profilesUrl.Length - 1] != '\\')
            _profilesUrl += "\\";

         //Set the virtual address of the output files
         if (Request.Url.GetLeftPart(UriPartial.Authority).Contains("localhost:"))
            _outputFilesName = "http://localhost/JobProcessorFiles/Output/";
         else
            _outputFilesName = Request.Url.GetLeftPart(UriPartial.Authority) + "/Media/Output/";

         _jobService = new JobService();

         base.OnInit(e);
      }

      void EnumerateProfiles()
      {
         // Enumerate all available profiles on the provided server URL path
         if (!string.IsNullOrEmpty(_profilesUrl))
         {
            _cmbConversionProfile.Items.Clear();

            List<string> files = new List<string>();
            files.AddRange(Directory.GetFiles(_profilesUrl, "*.profile"));

            foreach (string file in files)
            {
               string fileName = Path.GetFileNameWithoutExtension(file);
               _cmbConversionProfile.Items.Add(new ListItem(fileName, file));
            }

            // select the first item in the list box.
            if (_cmbConversionProfile.Items.Count > 0)
               _cmbConversionProfile.Items[0].Selected = true;
         }
      }

      void EnumerateURLSourceFiles()
      {
         string searchPattern = "*.avi|*.mpg|*.mpeg|*.mxf|*.mkv|*.ogg|*.wmv|*.asf|*.qt|*.mov|*.m2v|*.m1v|*.ts|*.m2ts|*.mp4|*.3gp|*.flv|*.f4v|*.wav|*.wma|*.ogg|*.mpa|*.mp2|*.mp3|*.mxf|*.mkv|*.au|*.aif|*.aiff|*.snd|*.aac";

         // Enumerate all available images on the provided server URL path
         if (!string.IsNullOrEmpty(_inputFilesUrl))
         {
            _cmbSourceFiles.Items.Clear();

            string[] searchPatterns = searchPattern.Split('|');
            List<string> files = new List<string>();
            foreach (string sp in searchPatterns)
               files.AddRange(Directory.GetFiles(_inputFilesUrl, sp));

            foreach (string file in files)
            {
               string fileName = Path.GetFileName(file);
               _cmbSourceFiles.Items.Add(new ListItem(fileName, file));
            }

            // select the first item in the list box.
            if (_cmbSourceFiles.Items.Count > 0)
               _cmbSourceFiles.Items[0].Selected = true;
         }
      }

      void GetClientJobs()
      {
         _gridViewClientJobs.DataBind();
         // Get all jobs related to this client
         GetClientJobsRequest getClientJobsRequest = new GetClientJobsRequest();
         getClientJobsRequest.UserToken = _hiddenFieldClientMetadata.Value;
         GetClientJobsResponse getClientJobsResponse = _jobService.GetClientJobs(getClientJobsRequest);
         if (getClientJobsResponse != null && getClientJobsResponse.JobsIds != null && getClientJobsResponse.JobsIds.Length > 0)
         {
            // First, delete all elements form the grid
            ViewState["CurrentData"] = null;

            foreach (string id in getClientJobsResponse.JobsIds)
            {
               GetJobInformationRequest getJobInfoRequest = new GetJobInformationRequest();
               getJobInfoRequest.ID = id;
               GetJobInformationResponse getJobInfoResponse = _jobService.GetJobInformation(getJobInfoRequest);
               AddJobToGridView(getJobInfoResponse.JobInformation);
            }
         }
         else
            AddJobToGridView(null); // just display an empty grid view

         string sortExpression = ViewState["SortExpression"] as string;
         SortGridView(sortExpression, false);
         RefreshGridView();
      }

      void RefreshGridView()
      {
         List<int> rowsIndicesToDelete = new List<int>();
         if (Session["tblSelected"] != null)
         {
            DataTable dt = (DataTable)Session["tblSelected"];
            foreach (DataRow row in dt.Rows)
            {
               if (UpdateRowAndPageIndexFromDB(row))
               {
                  int pageIndex = Convert.ToInt32(row["pageIndex"].ToString());
                  int rowIndex = Convert.ToInt32(row["rowIndex"].ToString());
                  bool selected = Convert.ToBoolean(row["selected"].ToString());
                  SaveGridViewSelectedIndices(row["id"].ToString(), pageIndex, rowIndex, selected);
                  if (pageIndex == _gridViewClientJobs.PageIndex && rowIndex < _gridViewClientJobs.Rows.Count)
                  {
                     CheckBox cb = (CheckBox)_gridViewClientJobs.Rows[rowIndex].FindControl("_cbSelectRow");
                     if (cb != null)
                        cb.Checked = true;
                  }
               }
               else
               {
                  // if the DataGrid doesn't contains the row from the Session["tblSelected"] then add 
                  // this row index to the list of rows to be deleted from Session["tblSelected"].
                  rowsIndicesToDelete.Add(dt.Rows.IndexOf(row));
               }
            }

            // Delete the rows from Session["tblSelected"] for the corresponding deleted rows from the GridView
            if (rowsIndicesToDelete.Count > 0)
            {
               for (int i = rowsIndicesToDelete.Count - 1; i >= 0; i--)
                  dt.Rows.RemoveAt(i);

               Session["tblSelected"] = (dt.Rows.Count > 0) ? dt : null;
            }

            UpdateHeaderCheckBox();
         }

         UpdateUIState();
      }

      bool UpdateRowAndPageIndexFromDB(DataRow row)
      {
         // save the current grid view page index before iterating through pages
         int currentPageIndex = _gridViewClientJobs.PageIndex;

         if (_gridViewClientJobs.PageIndex != 0)
         {
            _gridViewClientJobs.PageIndex = 0;
            _gridViewClientJobs.DataBind();
         }

         try
         {
            for (int i = 0; i < _gridViewClientJobs.PageCount; i++)
            {
               for (int j = 0; j < _gridViewClientJobs.Rows.Count; j++)
               {
                  Label lblJobID = (Label)_gridViewClientJobs.Rows[j].FindControl("_lblJobID");
                  if (lblJobID != null)
                  {
                     if (lblJobID.Text == row["id"].ToString())
                     {
                        row["pageIndex"] = i.ToString();
                        row["rowIndex"] = j.ToString();
                        return true;
                     }
                  }
               }

               if (_gridViewClientJobs.PageCount > i + 1)
               {
                  _gridViewClientJobs.PageIndex = _gridViewClientJobs.PageIndex + 1;
                  _gridViewClientJobs.DataBind();
               }
            }
         }
         finally
         {
            if (_gridViewClientJobs.PageIndex != currentPageIndex)
            {
               _gridViewClientJobs.PageIndex = currentPageIndex;
               _gridViewClientJobs.DataBind();
            }
         }

         return false;
      }

      void AddJobToGridView(JobServiceReference.JobInformation jobInformation)
      {
         // Check if the ViewState has a data associated within it.
         if (ViewState["CurrentData"] != null)
         {
            DataTable dt = (DataTable)ViewState["CurrentData"];
            int count = dt.Rows.Count;
            BindGrid(count, jobInformation);
         }
         else
         {
            BindGrid(1, jobInformation);
         }

         _lblJobsCount.Text = "Total Jobs: " + _gridViewClientJobs.Rows.Count.ToString();
      }

      protected void _btnAddJob_Click(object sender, EventArgs e)
      {
         if (string.IsNullOrEmpty(_cmbSourceFiles.Text))
            return;

         if (string.IsNullOrEmpty(_cmbConversionProfile.Text))
            return;

         MultimediaData multimediaData = new MultimediaData(_cmbSourceFiles.Text, _outputFilesUrl, File.ReadAllBytes(_cmbConversionProfile.SelectedItem.Value), _cmbConversionProfile.SelectedItem.Text);

         // Add new job.
         AddJobRequest AddJobRequest = new AddJobRequest();
         AddJobRequest.UserToken = _hiddenFieldClientMetadata.Value;
         AddJobRequest.JobMetadata = MultimediaData.SerializeToString(multimediaData);
         AddJobRequest.JobType = "Multimedia";
         AddJobResponse addJobResponse = _jobService.AddJob(AddJobRequest);

         GetJobInformationRequest getJobInfoRequest = new GetJobInformationRequest();
         getJobInfoRequest.ID = addJobResponse.Id;
         GetJobInformationResponse getJobInfoResponse = _jobService.GetJobInformation(getJobInfoRequest);
         AddJobToGridView(getJobInfoResponse.JobInformation);

         GetClientJobs();
      }

      private void BindGrid(int rowcount, JobServiceReference.JobInformation jobInformation)
      {
         if (jobInformation == null)
            return;

         //Only show multimedia jobs in this demo
         if (String.Compare(jobInformation.JobType, "Multimedia", true) != 0)
            return;

         MultimediaData multimediaData = MultimediaData.DeserializeFromString(jobInformation.Metadata.JobMetadata);
         string inputFileName = multimediaData.SourceFile.Length > 0 ? Path.GetFileName(multimediaData.SourceFile) : String.Empty;
         string outputFileName = jobInformation.Status == JobStatus.Completed && multimediaData.TargetFile.Length > 0 ? Path.GetFileName(multimediaData.TargetFile) : String.Empty;

         DataColumn[] dataColums = new DataColumn[]
         {
            new DataColumn("Job ID", typeof(string)),
            new DataColumn("Status", typeof(string)),
            new DataColumn("Worker", typeof(string)),
            new DataColumn("Percentage", typeof(int)),
            new DataColumn("Added Data/Time", Nullable.GetUnderlyingType(typeof(Nullable<DateTime>))),
            new DataColumn("Completed Data/Time", Nullable.GetUnderlyingType(typeof(Nullable<DateTime>))),
            new DataColumn("Error ID", typeof(int)),
            new DataColumn("Error Message", typeof(string)),
            new DataColumn("Input File", typeof(string)),
            new DataColumn("Output File", typeof(string)),
            new DataColumn("Full Path", typeof(string)),
            new DataColumn("Target Format", typeof(string)),
         };

         DataTable dt = new DataTable();
         dt.Columns.AddRange(dataColums);

         DataRow dr;
         if (ViewState["CurrentData"] != null)
         {
            for (int i = 0; i < rowcount; i++)
            {
               dt = (DataTable)ViewState["CurrentData"];
               if (dt.Rows.Count > 0)
               {
                  dr = dt.NewRow();
                  dr[0] = dt.Rows[i][0].ToString();
                  dr[1] = dt.Rows[i][1].ToString();
                  dr[2] = dt.Rows[i][2].ToString();
                  dr[3] = dt.Rows[i][3].ToString();
                  if (dt.Rows[i][3] != null)
                     dr[4] = dt.Rows[i][4];
                  else
                     dr[4] = DBNull.Value;

                  if (dt.Rows[i][4] != null)
                     dr[5] = dt.Rows[i][5];
                  else
                     dr[5] = DBNull.Value;
                  dr[6] = dt.Rows[i][6].ToString();
                  dr[7] = dt.Rows[i][7].ToString();
                  dr[8] = dt.Rows[i][8].ToString();
                  dr[9] = dt.Rows[i][9].ToString();
                  dr[10] = dt.Rows[i][10].ToString();
                  dr[11] = dt.Rows[i][11].ToString();
               }
            }
            if (jobInformation != null)
            {
               dr = dt.NewRow();
               dr[0] = jobInformation.ID;
               dr[1] = jobInformation.Status;
               dr[2] = jobInformation.Worker;
               dr[3] = jobInformation.Percentage;
               if (jobInformation.AddedTime != null)
                  dr[4] = jobInformation.AddedTime;
               else
                  dr[4] = DBNull.Value;

               if (jobInformation.CompletedTime != null)
                  dr[5] = jobInformation.CompletedTime;
               else
                  dr[5] = DBNull.Value;
               dr[6] = jobInformation.FailureInformation.FailedErrorID;
               dr[7] = jobInformation.FailureInformation.FailedMessage;
               dr[8] = inputFileName;
               dr[9] = outputFileName;
               dr[10] = _outputFilesName + outputFileName;
               dr[11] = multimediaData.ProfileName;
               dt.Rows.Add(dr);
            }
         }
         else
         {
            if (jobInformation != null)
            {
               dr = dt.NewRow();
               dr[0] = jobInformation.ID;
               dr[1] = jobInformation.Status;
               dr[2] = jobInformation.Worker;
               dr[3] = jobInformation.Percentage;
               if (jobInformation.AddedTime != null)
                  dr[4] = jobInformation.AddedTime;
               else
                  dr[4] = DBNull.Value;

               if (jobInformation.CompletedTime != null)
                  dr[5] = jobInformation.CompletedTime;
               else
                  dr[5] = DBNull.Value;
               dr[6] = jobInformation.FailureInformation.FailedErrorID;
               dr[7] = jobInformation.FailureInformation.FailedMessage;
               dr[8] = inputFileName;
               dr[9] = outputFileName;
               dr[10] = _outputFilesName + outputFileName;
               dr[11] = multimediaData.ProfileName;
               dt.Rows.Add(dr);
            }
         }

         // If ViewState has a data then use the value as the DataSource
         if (ViewState["CurrentData"] != null)
         {
            _gridViewClientJobs.DataSource = (DataTable)ViewState["CurrentData"];
            _gridViewClientJobs.DataBind();
         }
         else
         {
            // Bind GridView with the initial data associated in the DataTable
            _gridViewClientJobs.DataSource = dt;
            _gridViewClientJobs.DataBind();
         }
         // Store the DataTable in ViewState to retain the values
         ViewState["CurrentData"] = dt;
      }

      protected void _timer_Tick(object sender, EventArgs e)
      {
         // Update client jobs information each minute.
         GetClientJobs();
      }

      protected void _cbSelectRow_CheckedChanged(object sender, EventArgs e)
      {
         CheckBox cb = (CheckBox)sender;
         GridViewRow gridRow = (GridViewRow)cb.NamingContainer;
         if (gridRow != null)
         {
            Label lblJobID = (Label)gridRow.FindControl("_lblJobID");
            if (lblJobID != null)
            {
               SaveGridViewSelectedIndices(lblJobID.Text, _gridViewClientJobs.PageIndex, gridRow.RowIndex, cb.Checked);
               UpdateHeaderCheckBox();
               UpdateUIState();
            }
         }
      }

      protected void _cbSelectAllRows_CheckedChanged(object sender, EventArgs e)
      {
         CheckBox headerCheckBox = (CheckBox)sender;
         if (headerCheckBox != null)
         {
            // check if all items is checked then uncheck them all
            bool allSelected = IsAllItemsChecked();

            for (int j = 0; j < _gridViewClientJobs.Rows.Count; j++)
            {
               CheckBox rowCheckBox = (CheckBox)_gridViewClientJobs.Rows[j].FindControl("_cbSelectRow");
               if (rowCheckBox != null)
               {
                  rowCheckBox.Checked = !allSelected;
                  Label lblJobID = (Label)_gridViewClientJobs.Rows[j].FindControl("_lblJobID");
                  if (lblJobID != null)
                  {
                     SaveGridViewSelectedIndices(lblJobID.Text, _gridViewClientJobs.PageIndex, j, rowCheckBox.Checked);
                  }
               }
            }

            UpdateUIState();
         }
      }

      void UpdateUIState()
      {
         bool enabled = IsThereAnySelectedItem();
         _btnDeleteSelected.Enabled = enabled;
         _btnAbortSelected.Enabled = enabled;
         _btnMarkAsNew.Enabled = enabled;
      }

      bool IsThereAnySelectedItem()
      {
         if (Session["tblSelected"] != null && ((DataTable)Session["tblSelected"]).Rows.Count > 0)
            return true;

         return false;
      }

      bool IsAllItemsChecked()
      {
         int checkedCount = 0;
         for (int j = 0; j < _gridViewClientJobs.Rows.Count; j++)
         {
            CheckBox rowCheckBox = (CheckBox)_gridViewClientJobs.Rows[j].FindControl("_cbSelectRow");
            if (rowCheckBox != null)
            {
               if (rowCheckBox.Checked)
                  checkedCount++;
            }
         }

         bool allSelected = (checkedCount == _gridViewClientJobs.Rows.Count) ? true : false;
         return allSelected;
      }

      void UpdateHeaderCheckBox()
      {
         // Update the check boxes column header check state
         bool allSelected = IsAllItemsChecked();
         CheckBox cbHeader = (CheckBox)_gridViewClientJobs.HeaderRow.FindControl("_cbSelectAllRows");
         if (cbHeader != null)
            cbHeader.Checked = allSelected;
      }

      void SaveGridViewSelectedIndices(string jobID, int pageIndex, int rowIndex, bool selected)
      {
         DataTable tblSelected = new DataTable();

         if (Session["tblSelected"] == null)
         {
            // ID column
            DataColumn dcID = new DataColumn("id");
            dcID.DataType = Type.GetType("System.String");
            tblSelected.Columns.Add(dcID);

            // GridView Page index
            DataColumn dcPageIndex = new DataColumn("pageIndex");
            dcPageIndex.DataType = Type.GetType("System.Int32");
            tblSelected.Columns.Add(dcPageIndex);

            // Row index column
            DataColumn dcRowIndex = new DataColumn("rowIndex");
            dcRowIndex.DataType = Type.GetType("System.Int32");
            tblSelected.Columns.Add(dcRowIndex);

            // Selected column
            DataColumn dcSelected = new DataColumn("selected");
            dcSelected.DataType = Type.GetType("System.Boolean");
            tblSelected.Columns.Add(dcSelected);

            DataColumn[] pCol = new DataColumn[1];
            pCol[0] = dcID;
            tblSelected.PrimaryKey = pCol;
         }
         else
         {
            tblSelected = (DataTable)Session["tblSelected"];
            Session["tblSelected"] = null;
         }

         DataRow dRow = tblSelected.NewRow();
         dRow["id"] = jobID;
         dRow["pageIndex"] = pageIndex;
         dRow["rowIndex"] = rowIndex;
         dRow["selected"] = selected;

         if (!tblSelected.Rows.Contains(jobID))
         {
            tblSelected.Rows.Add(dRow);
         }
         else
            tblSelected.Rows.Find(jobID)["selected"] = selected;

         for (int i = 0; i < tblSelected.Rows.Count; i++)
         {
            for (int j = 0; j < _gridViewClientJobs.Rows.Count; j++)
            {
               Label lblJobID = (Label)_gridViewClientJobs.Rows[j].FindControl("_lblJobID");
               if (lblJobID != null)
               {
                  if (lblJobID.Text == tblSelected.Rows[i]["id"].ToString())
                  {
                     if (Convert.ToBoolean(tblSelected.Rows[i]["selected"].ToString()))
                     {
                        _gridViewClientJobs.Rows[j].BackColor = _gridViewClientJobs.SelectedRowStyle.BackColor;
                        _gridViewClientJobs.Rows[j].ForeColor = _gridViewClientJobs.SelectedRowStyle.ForeColor;
                     }
                     else
                     {
                        _gridViewClientJobs.Rows[j].BackColor = _gridViewClientJobs.EmptyDataRowStyle.BackColor;
                        _gridViewClientJobs.Rows[j].ForeColor = _gridViewClientJobs.EmptyDataRowStyle.ForeColor;
                     }
                     break;
                  }
               }
            }
         }

         if (!selected)
            tblSelected.Rows.Find(jobID).Delete();

         // Session variable to store the DataTable
         // This session variable can be used in different pages
         // to display the user selected items throughout the session
         Session["tblSelected"] = tblSelected;
      }

      protected void _gridViewClientJobs_PreRender(object sender, EventArgs e)
      {
         RefreshGridView();
      }

      protected void _btnDeleteSelected_Click(object sender, EventArgs e)
      {
         // Iterate through the Session variable, get the primary key and then delete the 
         // relevant row from the database.
         if (Session["tblSelected"] != null)
         {
            DataTable tblSelected = (DataTable)Session["tblSelected"];
            for (int i = 0; i < tblSelected.Rows.Count; i++)
            {
               for (int j = 0; j < _gridViewClientJobs.Rows.Count; j++)
               {
                  Label lblJobID = (Label)_gridViewClientJobs.Rows[j].FindControl("_lblJobID");
                  if (lblJobID != null)
                  {
                     if (lblJobID.Text == tblSelected.Rows[i]["id"].ToString())
                     {
                        DeleteJobRequest deleteRequest = new DeleteJobRequest();
                        deleteRequest.ID = tblSelected.Rows[i]["id"].ToString();
                        _jobService.DeleteJob(deleteRequest);
                        if (_gridViewClientJobs.Rows.Count == tblSelected.Rows.Count) // Delete all records
                           ViewState["CurrentData"] = null;
                        break;
                     }
                  }
               }
            }

            Session["tblSelected"] = null;
            GetClientJobs();
         }
         else
            UpdateUIState();
      }

      protected void _btnAbortSelected_Click(object sender, EventArgs e)
      {
         // Iterate through the Session variable, get the primary key and then abort the 
         // relevant jobs.
         if (Session["tblSelected"] != null)
         {
            DataTable tblSelected = (DataTable)Session["tblSelected"];
            for (int i = 0; i < tblSelected.Rows.Count; i++)
            {
               for (int j = 0; j < _gridViewClientJobs.Rows.Count; j++)
               {
                  Label lblJobID = (Label)_gridViewClientJobs.Rows[j].FindControl("_lblJobID");
                  if (lblJobID != null)
                  {
                     if (lblJobID.Text == tblSelected.Rows[i]["id"].ToString())
                     {
                        AbortJobRequest abortRequest = new AbortJobRequest();
                        abortRequest.ID = tblSelected.Rows[i]["id"].ToString();
                        abortRequest.Reason = "Aborted by client";
                        _jobService.AbortJob(abortRequest);
                        break;
                     }
                  }
               }
            }

            GetClientJobs();
         }
         else
            UpdateUIState();
      }

      protected void _btnMarkAsNew_Click(object sender, EventArgs e)
      {
         // Iterate through the Session variable, get the primary key and then change the selected jobs status to "New".
         if (Session["tblSelected"] != null)
         {
            DataTable tblSelected = (DataTable)Session["tblSelected"];
            for (int i = 0; i < tblSelected.Rows.Count; i++)
            {
               for (int j = 0; j < _gridViewClientJobs.Rows.Count; j++)
               {
                  Label lblJobID = (Label)_gridViewClientJobs.Rows[j].FindControl("_lblJobID");
                  if (lblJobID != null)
                  {
                     if (lblJobID.Text == tblSelected.Rows[i]["id"].ToString())
                     {
                        // Get current job information first.
                        GetJobInformationRequest getInfoRequest = new GetJobInformationRequest();
                        getInfoRequest.ID = tblSelected.Rows[i]["id"].ToString();
                        GetJobInformationResponse getJobInfoResponse = _jobService.GetJobInformation(getInfoRequest);
                        if (getJobInfoResponse.JobInformation != null && !string.IsNullOrEmpty(getJobInfoResponse.JobInformation.ID))
                        {
                           ResetJobRequest resetJobRequest = new ResetJobRequest();
                           resetJobRequest.ID = tblSelected.Rows[i]["id"].ToString();
                           _jobService.ResetJob(resetJobRequest);
                        }
                        break;
                     }
                  }
               }
            }

            GetClientJobs();
         }
         else
            UpdateUIState();
      }

      protected void _gridViewClientJobs_Sorting(object sender, GridViewSortEventArgs e)
      {
         SortGridView(e.SortExpression, true);
      }

      private void SortGridView(string sortExpression, bool reverseSortDirection)
      {
         if (string.IsNullOrEmpty(sortExpression))
            return;

         //Retrieve the table from the session object.
         DataTable dt = ViewState["CurrentData"] as DataTable;
         if (dt != null)
         {
            //Sort the data.
            dt.DefaultView.Sort = sortExpression + " " + GetSortDirection(sortExpression, reverseSortDirection);
            ViewState["CurrentData"] = dt;
            _gridViewClientJobs.DataSource = ViewState["CurrentData"];
            _gridViewClientJobs.DataBind();
         }
      }

      private string GetSortDirection(string column, bool reverseSortDirection)
      {
         // By default, set the sort direction to ascending.
         string sortDirection = "ASC";

         // Retrieve the last column that was sorted.
         string sortExpression = ViewState["SortExpression"] as string;
         if (sortExpression != null)
         {
            // Check if the same column is being sorted.
            // Otherwise, the default value can be returned.
            if (sortExpression == column)
            {
               string lastDirection = ViewState["SortDirection"] as string;
               if (lastDirection != null)
               {
                  if (reverseSortDirection)
                  {
                     if (lastDirection == "ASC")
                        sortDirection = "DESC";
                  }
                  else
                     sortDirection = lastDirection;
               }
            }
         }

         // Save new values in ViewState.
         ViewState["SortDirection"] = sortDirection;
         ViewState["SortExpression"] = column;

         return sortDirection;
      }
   }
}
