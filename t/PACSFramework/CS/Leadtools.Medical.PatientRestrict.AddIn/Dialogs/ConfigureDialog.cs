// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************

using Leadtools.Dicom.Server.Admin;
using Leadtools.Medical.AeManagement.DataAccessLayer;
using Leadtools.Medical.PatientRestrict.AddIn.Common;
using Leadtools.Medical.PermissionsManagement.DataAccessLayer;
using Leadtools.Medical.WebViewer.PatientAccessRights;
using Leadtools.Medical.Winforms.ClientManager;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace Leadtools.Medical.PatientRestrict.AddIn.Dialogs
{
   public partial class ConfigureDialog : Form
   {
      public ConfigureDialog()
      {
         InitializeComponent();
      }

      public List<AeAccessKey> aeRoleList;

      public int PageSize;
      public bool PatientRestrictEnabled;

      private const int AeTitleIndex = 0;
      private const int RoleIndex = 1;

      public delegate bool ApplyOptionsMethodDelegate(bool refresh);

      public ApplyOptionsMethodDelegate ApplyOptionsMethod = null;

      private void ChangeRowData(int rowIndex, AeAccessKey ci)
      {
         // AE Title
         dataGridView1.Rows[rowIndex].Cells[AeTitleIndex].Value = ci.AeTitle;

         // Friendly Name
         dataGridView1.Rows[rowIndex].Cells[RoleIndex].Value = ci.AccessKey;


         // invalidate
         dataGridView1.InvalidateRow(rowIndex);
      }

      private void AddRow(AeAccessKey ci)
      {
         if (dataGridView1.ColumnCount > 0)
         {
            int rowIndex = dataGridView1.Rows.Add();
            ChangeRowData(rowIndex, ci);
         }
      }

      public void SetupDataViewGrid()
      {
         dataGridView1.AllowDrop = false;
         dataGridView1.AllowUserToAddRows = false;
         dataGridView1.AllowUserToDeleteRows = false;
         dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
         dataGridView1.ReadOnly = true;
         foreach (AeAccessKey aeAccessKey in aeRoleList)
         {
            AddRow(aeAccessKey);
         }
      }

      private void RemoveAllRows()
      {
         if (dataGridView1 != null)
         {
            if (dataGridView1.DataSource != null)
            {
               dataGridView1.DataSource = null;
            }
            else
            {
               dataGridView1.Rows.Clear();
            }
         }
      }

      private void Freeze(IntPtr handle)
      {
         try
         {
            Win32APIWrapper.SendMessage(handle, Win32APIWrapper.Win32Constants.WindowsMessage.WM_SETREDRAW,
                                        0, IntPtr.Zero);
         }
         catch (Exception exception)
         {
            System.Diagnostics.Debug.Assert(false);

            throw exception;
         }
      }

      private void Unfreeze(IntPtr handle)
      {
         try
         {
            Win32APIWrapper.SendMessage(handle, Win32APIWrapper.Win32Constants.WindowsMessage.WM_SETREDRAW,
                                        1, IntPtr.Zero);
         }
         catch (Exception exception)
         {
            System.Diagnostics.Debug.Assert(false);

            throw exception;
         }
      }

      private static int CalculateMaxPageNumber(int pageSize, int clientCount)
      {
         int maxPageNumber = 0;
         double totalPages = ((double)clientCount / (double)pageSize);
         maxPageNumber = (int)Math.Ceiling(totalPages); // - 1;
         if (maxPageNumber == 0)
         {
            maxPageNumber = 1;
         }
         return maxPageNumber;
      }

      private void UpdatePaginationMaxPageNumber()
      {
         if (aeRoleList != null)
         {
            int searchDictionaryCount = aeRoleList.Count;
            if (_searchList != null)
            {
               searchDictionaryCount = _searchList.Count;
            }
            paginationControl1.MaxPageNumber = CalculateMaxPageNumber(paginationControl1.PageSize, searchDictionaryCount);
            paginationControl1.UpdateStatus();
         }
      }

      private List<AeAccessKey> _searchList = null;

      private void UpdateSearchDictionary()
      {
         if (aeRoleList == null)
            return;

         if (_searchList == null)
         {
            _searchList = new List<AeAccessKey>();
         }
         _searchList.Clear();

         foreach (AeAccessKey aeAccessKey in aeRoleList)
         {
            bool contains = true;

            // AE Title
            if (contains)
            {
               string aeTitle = textBoxAeTitle.Text.Trim();
               if (!string.IsNullOrWhiteSpace(aeTitle))
               {
                  contains = aeAccessKey.AeTitle.CaseInsensitiveContains(aeTitle);
               }
            }

            // Role
            if (contains)
            {
               string roleName = textBoxRole.Text.Trim();
               if (!string.IsNullOrWhiteSpace(roleName))
               {
                  contains = aeAccessKey.AccessKey.CaseInsensitiveContains(roleName);
               }
            }

            // 
            if (contains)
            {
               _searchList.Add(aeAccessKey);
            }
         }
         UpdatePaginationMaxPageNumber();
         //UpdateUI();
      }


      private void UpdateGridview()
      {
         if (dataGridView1 == null)
            return;

         try
         {
            RemoveAllRows();
            Freeze(dataGridView1.Handle);

            ColumnAeTitle.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            ColumnRole.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;


            // paginationControl1.PageNumber is 1-based
            paginationControl1.PageSize = PageSize; //_options.PageSize;
            // UpdatePaginationMaxPageNumber();
            int nStart = paginationControl1.PageSize * (paginationControl1.PageNumber - 1);
            int nEnd = nStart + this.paginationControl1.PageSize;

            UpdateSearchDictionary();

            if (_searchList != null)
            {

               this.paginationControl1.Enabled = true;
               this.paginationControl1.EnableItems(true);

               PaginationDisplayOptions paginationDisplayOptions = PaginationDisplayOptions.ShowAlways;
               switch (paginationDisplayOptions)
               {
                  case PaginationDisplayOptions.ShowAlways:
                     paginationControl1.Visible = true;
                     break;

                  case PaginationDisplayOptions.ShowWhenNecessary:
                     paginationControl1.Visible = (_searchList.Count > paginationControl1.PageSize);
                     break;

                  case PaginationDisplayOptions.ShowNever:
                     paginationControl1.Visible = false;
                     break;
               }

               if (paginationControl1.Visible)
               {
                  dataGridView1.Height = paginationControl1.Top - dataGridView1.Top - 2;
               }
               else
               {
                  dataGridView1.Height = groupBoxSearch.Top - dataGridView1.Top - 2;
               }

               for (int i = nStart; i < nEnd; i++)
               {
                  if (i < _searchList.Count)
                  {
                     AddRow(_searchList[i]);
                  }
               }
            }

         }
         finally
         {
            ColumnAeTitle.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            ColumnRole.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Unfreeze(dataGridView1.Handle);
            dataGridView1.Refresh();
            paginationControl1.UpdateStatus();
         }
      }

      private string _instructions = "" +
            "The PatientRestrict Addin is used to define the patients that a user can access.\r\n\r\n" +
            "Check 'Enable Patient Restrict' to enable the following behavior:\r\n" +
            "*\tThe DICOM listening service receives a C-STORE-REQ from an AE Title\r\n" +
            "*\tThe AE Title is located in the table to get a list of 'Roles'\r\n" +
            "*\tEach User with any corresponding role is configured to have access to the PatientID\r\n" +
            " \tof the corresponding stored DICOM dataset.\r\n" +
            "*\tThis behavior shows in the Medical Web Viewer when setting the 'Enable Patient Restriction' option.";

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

      private void ConfigureDialog_Load(object sender, EventArgs e)
      {
         if (Module.Service == null)
         {
            string assemblyDirectory = AssemblyDirectory;
            string serviceDirectory = System.IO.Directory.GetParent(assemblyDirectory).FullName;
            string displayName = new DirectoryInfo(serviceDirectory).Name;
            Module.GetService(serviceDirectory, displayName);
         }
         SetupDataViewGrid();

         checkBoxEnablePatientRestrict.Checked = PatientRestrictEnabled;

         // setup pagination control
         paginationControl1.Enabled = true;
         paginationControl1.MinPageNumber = 1;
         paginationControl1.PageSizeLabel = "Page Size:";
         paginationControl1.PageSize = PageSize;
         paginationControl1.PageNumberIncrement = 1;

         paginationControl1.FirstClicked += PaginationControl1_FirstClicked;
         paginationControl1.LastClicked += PaginationControl1_LastClicked;
         paginationControl1.PreviousClicked += PaginationControl1_PreviousClicked;
         paginationControl1.NextClicked += PaginationControl1_NextClicked;
         paginationControl1.GotoPageClicked += PaginationControl1_GotoPageClicked;

         // dataGridView1 events
         dataGridView1.SelectionChanged += DataGridView1_SelectionChanged;

         textBoxAeTitle.TextChanged += UpdateSearch;
         textBoxRole.TextChanged += UpdateSearch;

         buttonSearchClear.Click += ButtonSearchClear_Click;

         AddClientToolStripButton.Click += AddClientToolStripButton_Click;
         ModifyClientToolStripButton.Click += ModifyClientToolStripButton_Click;
         DeleteClienteToolStripButton.Click += DeleteClienteToolStripButton_Click;

         this.helpProvider1.SetHelpString(this, _instructions);

         this.paginationControl1.PageSizeReadOnly = false;
         this.paginationControl1.PageSizeChanged += PaginationControl1_PageSizeChanged; ;

         Clear();

         // Call OnSettingsChanged if any settings change
         checkBoxEnablePatientRestrict.CheckedChanged += new EventHandler(OnSettingsChanged);
         this.buttonApply.Enabled = false;
      }

      private void EnableAddClient()
      {
         AddClientToolStripButton.Enabled = true;
      }

      private void EnableItems()
      {
         int selectedRowCount = dataGridView1.SelectedRows.Count;

         EnableAddClient();
         this.ModifyClientToolStripButton.Enabled = (selectedRowCount == 1);
         this.DeleteClienteToolStripButton.Enabled = (selectedRowCount >= 1);
      }


      // dataGridView1 events
      private void DataGridView1_SelectionChanged(object sender, EventArgs e)
      {
         EnableItems();
      }

      private bool InsertClient(InsertModifyAeRoleControlType dialogType)
      {
         bool ret = false;
         InsertModifyAeRoleDialog dialog = new InsertModifyAeRoleDialog() { DialogType = dialogType };

         dialog.aeRoleList = aeRoleList;

         AeInfoExtended[] aeInfoExtended =  Module.AeManagementDataAccessAgent.GetAeTitles();
         dialog.aeList = aeInfoExtended.Select(x => x.AETitle).Distinct().ToList();

         Role[] roles = Module.PermissionManagementDataAccessAgent.GetRoles();
         dialog.roleList = roles.Select(x=>x.Name).Distinct().ToList();

         AeAccessKey aeAccessKey = new AeAccessKey();

         if (dataGridView1.SelectedRows.Count > 0)
         {
            aeAccessKey.AeTitle = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();

            if (dialogType == InsertModifyAeRoleControlType.Modify)
            {
               aeAccessKey.AccessKey = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            }

         }
         dialog.aeRole = aeAccessKey;

         dialog.ValidateAeRoleData += Dialog_ValidateAeRoleData;
         if (DialogResult.OK == dialog.ShowDialog(this))
         {
            AddRow(dialog.aeRole);
            aeRoleList.Add(dialog.aeRole);
            ret = true;
         }
         return ret;
      }

      private void DeleteClients()
      {
         foreach (DataGridViewRow row in dataGridView1.SelectedRows)
         {
            string aeTitle = row.Cells[0].Value.ToString();
            string role = row.Cells[1].Value.ToString();

            AeAccessKey aeAccessKey = new AeAccessKey { AeTitle = aeTitle, AccessKey = role};
       
            if (aeRoleList.MyContains(aeAccessKey))
            {
               dataGridView1.Rows.Remove(row);
               aeRoleList.MyRemoveAll(aeAccessKey);
            }
         }
      }

      private void Dialog_ValidateAeRoleData(object sender, AeRoleEventArgs e)
      {
         string error = string.Empty;
         InsertModifyAeRoleDialog dialog = (InsertModifyAeRoleDialog)sender;

         e.IsValid = true;

         // Clear existing errors
         dialog.ValidateAeTitle(string.Empty);
         dialog.ValidateRole(string.Empty);

         // AETitle
         if (!Leadtools.DicomDemos.Utils.IsValidApplicationEntity(e.AeRole.AeTitle, out error))
         {
            dialog.ValidateAeTitle(error);
            e.IsValid = false;
         }
         else if (e.IsInsert && (aeRoleList.MyContains(e.AeRole)))
         {
            // insert -- verify AeTile does not already exist
            dialog.ValidateAeTitle("Record already exists with this AE Title and Role.");
            e.IsValid = false;
         }
         else if (!e.IsInsert && e.IsNewAeTitle && (aeRoleList.MyContains(e.AeRole)))
         {
            // modify and the aeTitle has changed -- verify the AeTitle does not already exist
            dialog.ValidateAeTitle("Record already exists with this AE Title and Role.");
            e.IsValid = false;
         }
      }

      private void AddClientToolStripButton_Click(object sender, EventArgs e)
      {
         if (InsertClient(InsertModifyAeRoleControlType.Insert))
         {
            OnSettingsChanged(sender, e);
         }
      }

      private void ModifyClientToolStripButton_Click(object sender, EventArgs e)
      {
         if (InsertClient(InsertModifyAeRoleControlType.Modify))
         {
            OnSettingsChanged(sender, e);
         }
      }

      private void DeleteClienteToolStripButton_Click(object sender, EventArgs e)
      {
         DeleteClients();
         OnSettingsChanged(sender, e);
      }

      private void PaginationControl1_PageSizeChanged(object sender, EventArgs e)
      {
         PageSize = paginationControl1.PageSize;
         FirstPage();
         UpdateGridview();
      }

      private int IncrementPage()
      {
         if (paginationControl1.PageNumber < paginationControl1.MaxPageNumber)
         {
            paginationControl1.PageNumber++;
         }
         return paginationControl1.PageNumber;
      }

      private int DecrementPage()
      {
         if (paginationControl1.PageNumber > 1)
         {
            paginationControl1.PageNumber--;
         }
         return paginationControl1.PageNumber;
      }

      private int FirstPage()
      {
         paginationControl1.PageNumber = paginationControl1.MinPageNumber;
         return paginationControl1.PageNumber;
      }

      private int LastPage()
      {
         paginationControl1.PageNumber = paginationControl1.MaxPageNumber;
         return paginationControl1.PageNumber;
      }

      private void PaginationControl1_GotoPageClicked(object sender, EventArgs e)
      {
         UpdateGridview();
      }

      private void PaginationControl1_NextClicked(object sender, EventArgs e)
      {
         IncrementPage();
         UpdateGridview();
      }

      private void PaginationControl1_PreviousClicked(object sender, EventArgs e)
      {
         DecrementPage();
         UpdateGridview();
      }

      private void PaginationControl1_LastClicked(object sender, EventArgs e)
      {
         LastPage();
         UpdateGridview();
      }

      private void PaginationControl1_FirstClicked(object sender, EventArgs e)
      {
         FirstPage();
         UpdateGridview();
      }

      private void Clear()
      {
         this.textBoxAeTitle.Text = string.Empty;
         this.textBoxRole.Text = string.Empty;

         paginationControl1.PageNumber = 1;
         UpdateGridview();
      }

      private void ButtonSearchClear_Click(object sender, EventArgs e)
      {
        Clear();
      }

      private void UpdateSearch(object sender, EventArgs e)
      {
         paginationControl1.PageNumber = 1;
         UpdateGridview();
      }

      private void buttonOK_Click(object sender, EventArgs e)
      {
         PatientRestrictEnabled = checkBoxEnablePatientRestrict.Checked;
         PageSize = paginationControl1.PageSize;
         Module.MyTellServiceSettingsHaveChanged();
      }

      private void ConfigureDialog_HelpButtonClicked(object sender, System.ComponentModel.CancelEventArgs e)
      {
         Help.ShowPopup(this, _instructions, Cursor.Position);
         e.Cancel = true;
      }

      private void buttonApply_Click(object sender, EventArgs e)
      {
         PatientRestrictEnabled = checkBoxEnablePatientRestrict.Checked;
         PageSize = paginationControl1.PageSize;
         if (ApplyOptionsMethod != null)
         {
            ApplyOptionsMethod(true);
            buttonApply.Enabled = false;
            Module.MyTellServiceSettingsHaveChanged();
         }
      }

      private void OnSettingsChanged(object sender, EventArgs e)
      {
         try
         {
            buttonApply.Enabled = true;
         }
         catch (Exception)
         {
            System.Diagnostics.Debug.Assert(false);
         }
      }
   }
}
