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

using Leadtools;
using Leadtools.Codecs;
using Leadtools.DicomDemos;
using Leadtools.Dicom.AddIn.Common;
using Leadtools.Medical.PermissionsManagement.DataAccessLayer;
using Leadtools.Medical.AeManagement.DataAccessLayer;
using Leadtools.Medical.Winforms.Win32;
using System.Diagnostics;
using Leadtools.Medical.DataAccessLayer;
using Leadtools.Medical.Winforms.ClientManager;
using Leadtools.Dicom;

namespace Leadtools.Medical.Winforms
{
   public partial class ClientViewerControl : UserControl
   {

      private bool _serverSecure = false;
      public bool ServerSecure
      {
         get
         {
            return _serverSecure;
         }
         set
         {
            _serverSecure = value;
            UpdateColorPorts();
            UpdateLastAccessDateDisplayOption();
         }
      }
      private int? _MaxClients = null;

      public int? MaxClients
      {
         get { return _MaxClients; }
         set 
         {
            if (_MaxClients != value)
            {
               _MaxClients = value;
               EnableAddClient();
            }
         }
      }

      public ClientViewerControl()
      {
         InitializeComponent();

         this.checkBoxDelete.CheckState = CheckState.Indeterminate;
         this.checkBoxOverwrite.CheckState = CheckState.Indeterminate;
         this.checkBoxUpdate.CheckState = CheckState.Indeterminate;

         paginationControl1.Enabled = true;
         paginationControl1.MinPageNumber = 1;
         paginationControl1.PageSizeLabel = "Page Size:";
         paginationControl1.PageSize = _options.PageSize;
         paginationControl1.PageNumberIncrement = 1;

         paginationControl1.FirstClicked += PaginationControl1_FirstClicked;
         paginationControl1.LastClicked += PaginationControl1_LastClicked;
         paginationControl1.PreviousClicked += PaginationControl1_PreviousClicked;
         paginationControl1.NextClicked += PaginationControl1_NextClicked;
         paginationControl1.GotoPageClicked += PaginationControl1_GotoPageClicked;

         buttonSearch.Click += ButtonSearch_Click;
         buttonSearchClear.Click += ButtonSearchClear_Click;

         dataGridView1.DefaultCellStyleChanged += DataGridView1_DefaultCellStyleChanged;

         //
         textBoxAeTitle.TextChanged += UpdateSearch;
         textBoxAlias.TextChanged += UpdateSearch;
         textBoxAddress.TextChanged += UpdateSearch;
         textBoxSubnetMask.TextChanged += UpdateSearch;
         textBoxPort.TextChanged += UpdateSearch;
         textBoxSecurePort.TextChanged += UpdateSearch;
         comboBoxPortUsage.SelectedValueChanged += UpdateSearch;
         checkBoxDelete.CheckedChanged += UpdateSearch;
         checkBoxOverwrite.CheckedChanged += UpdateSearch;
         checkBoxUpdate.CheckedChanged += UpdateSearch;
         dateTimePickerStartDate.ValueChanged += UpdateSearch;
         dateTimePickerEndDate.ValueChanged += UpdateSearch;

         // Hide the 'Search Button'
         // Now, the search is automatic when you type in any of the search fields
         buttonSearch.Enabled = false;
         buttonSearch.Visible = false;


      }

      private void UpdateSearch(object sender, EventArgs e)
      {
         ButtonSearch_Click(sender, e);
      }

      private void DataGridView1_DefaultCellStyleChanged(object sender, EventArgs e)
      {
      }

      ClientConfigurationOptions _options = new ClientConfigurationOptions();
      public ClientConfigurationOptions Options
      {
         get
         {
            return _options;
         }
         set
         {
            _options = value;

            paginationControl1.PageSize = _options.PageSize;
            paginationControl1.PageNumber = 1;

            UpdatePaginationMaxPageNumber();
            UpdateGridview();
         }
      }

      public event EventHandler<EventArgs> LoadClients = delegate {};


      private ClientInformationList _clientInformationList;      

      private Dictionary<string, DataGridViewCheckBoxColumn> _permissionColumns = new Dictionary<string, DataGridViewCheckBoxColumn>(StringComparer.InvariantCultureIgnoreCase);

      public void SetupDataViewGrid()
      {
         if (dataGridView1.Columns.Count > 0)
            return;

#if (LEADTOOLS_V20_OR_LATER)
         this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnAeTitle,
            this.ColumnFriendlyName,
            this.ColumnAddress,
            this.ColumnMask,
            this.ColumnPort,
            this.ColumnSecurePort,
            this.ColumnPortUsage,
         });
#elif (LEADTOOLS_V19_OR_LATER_MEDICAL_CLIENT_FRIENDLY_NAME) || (LEADTOOLS_V19_OR_LATER)
      this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnAeTitle,
            this.ColumnFriendlyName,
            this.ColumnAddress,
            this.ColumnMask,
            this.ColumnPort,
            this.ColumnSecurePort,
         });
#else
       this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnAeTitle,
            this.ColumnAddress,
            this.ColumnMask,
            this.ColumnPort,
            this.ColumnSecurePort,
         });
#endif



         // Permissions = new Permission[] { new Permission("Test1", "Test1Desc"), new Permission("Test2", "Test2Desc") };

         if (Permissions != null)
         {
            foreach (Permission permission in Permissions)
            {
               DataGridViewCheckBoxColumn col = new DataGridViewCheckBoxColumn();
               col.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
               col.HeaderText = permission.Name;
               col.ReadOnly = true;
               col.Width = 40;
               _permissionColumns.Add(permission.Name, col);

               dataGridView1.Columns.Add(col);
            }
         }

         // Last Access Date
         dataGridView1.Columns.Add(this.ColumnLastAccessDate);

         ResetLastAccessDate();
      }

      private void ResetLastAccessDate()
      {

         dateTimePickerStartDate.Value = DateTime.Now.AddYears(-1);
         dateTimePickerStartDate.Checked = false;

         dateTimePickerEndDate.Value = DateTime.Today;
         dateTimePickerEndDate.Checked = false;
      }

      public ClientInformationList ClientInformationList
      {
         get { return _clientInformationList; }
         set { _clientInformationList = value; }
      }

      public Permission[] Permissions
      {
         get;
         set;
      }
      
      public Permission[] NewClientPermissions
      {
         get;
         set;
      }

      private void UpdateSelectedRow(ClientInformation ci)
      {
         int rowIndex = dataGridView1.SelectedRows[0].Index;
         ChangeRowData(rowIndex, ci);
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
         
         // This way is too slow if there are many records (i.e. more than 1000)
         //while (dataGridView1.Rows.Count > 0)
         //{
         //   dataGridView1.Rows.RemoveAt(0);
         //}
      }

      private void AddRow(ClientInformation ci)
      {
         if (dataGridView1.ColumnCount >  0)
         {
            int rowIndex = dataGridView1.Rows.Add();
            ChangeRowData(rowIndex, ci);
         }
      }

#if (LEADTOOLS_V19_OR_LATER_MEDICAL_CLIENT_FRIENDLY_NAME) || (LEADTOOLS_V19_OR_LATER)
      private const int AeTitleIndex = 0;
      private const int FriendlyNameIndex = 1;
      private const int AddressIndex = 2;
      private const int SubnetMaskIndex = 3;
      private const int PortIndex = 4;
      private const int SecurePortIndex = 5; 
      private const int PortUsageIndex = 6;
      private const int DeleteIndex = 7;
      private const int OverwriteIndex = 8;
      private const int UpdateIndex = 9;
      private const int LastAccessDateIndex = 10;
#else
      private const int AeTitleIndex = 0;
      private const int AddressIndex = 1;
      private const int SubnetMaskIndex = 2;
      private const int PortIndex = 3;
      private const int SecurePortIndex = 4; 
#endif

      void ColorCell(DataGridViewCell cell, bool securePort, ClientPortUsageType portUsage)
      {
         bool secure = (portUsage == ClientPortUsageType.Secure) || ( (portUsage == ClientPortUsageType.SameAsServer) && ServerSecure);
         if (secure == securePort)
         {
            cell.Style.ForeColor = dataGridView1.DefaultCellStyle.ForeColor;
            cell.Style.SelectionForeColor = dataGridView1.DefaultCellStyle.SelectionForeColor;
         }
         else
         {
            cell.Style.ForeColor = Color.LightGray;
            cell.Style.SelectionForeColor = Color.DarkGray;
         }
      }

      private void UpdateColorPorts()
      {
         foreach (DataGridViewRow row in dataGridView1.Rows)
         {
            DataGridViewCell cell = row.Cells[PortUsageIndex];
            

            ClientPortUsageType portUsage = (ClientPortUsageType)cell.Value;

            // Port
            cell = row.Cells[PortIndex];
            ColorCell(cell, false, portUsage);

            // Secure Port
            cell = row.Cells[SecurePortIndex];
            ColorCell(cell, true, portUsage);
         }
      }

      private void UpdateLastAccessDateDisplayOption()
      {
         if (_options.LastAccessDateDisplay == LastAccessDateDisplayOptions.ShowDateOnly)
         {
            ColumnLastAccessDate.DefaultCellStyle.Format = "MM/dd/yyyy";
         }
         else
         {
            ColumnLastAccessDate.DefaultCellStyle.Format = "MM/dd/yyyy hh:mm:ss tt";
         }
      }

      private void ChangeRowData(int rowIndex, ClientInformation ci)
      {
         DataGridViewCell cell = null;

         // AE Title
         dataGridView1.Rows[rowIndex].Cells[AeTitleIndex].Value = ci.Client.AETitle;

#if (LEADTOOLS_V19_OR_LATER_MEDICAL_CLIENT_FRIENDLY_NAME) || (LEADTOOLS_V19_OR_LATER)
         // Friendly Name
         dataGridView1.Rows[rowIndex].Cells[FriendlyNameIndex].Value = ci.Client.FriendlyName;
#endif //

         // Address
         MyDataGridViewCheckBoxTextCell address = (MyDataGridViewCheckBoxTextCell)(dataGridView1.Rows[rowIndex].Cells[AddressIndex]);
         if (address != null)
         {
            address.Value = ci.Client.VerifyAddress;
            address.Text = ci.Client.Address;
         }

         // Subnet Mask
         MyDataGridViewCheckBoxTextCell mask = (MyDataGridViewCheckBoxTextCell)(dataGridView1.Rows[rowIndex].Cells[SubnetMaskIndex]);
         if (address != null)
         {
            mask.Value = ci.Client.VerifyMask;
            mask.Text = ci.Client.Mask;
         }

         // Port
         cell = dataGridView1.Rows[rowIndex].Cells[PortIndex];
         cell.Value = ci.Client.Port;
         ColorCell(cell, false, ci.Client.ClientPortUsage);

         // Secure Port
         cell = dataGridView1.Rows[rowIndex].Cells[SecurePortIndex];
         cell.Value = ci.Client.SecurePort;
         ColorCell(cell, true, ci.Client.ClientPortUsage);

         // Port Usage
         dataGridView1.Rows[rowIndex].Cells[PortUsageIndex].Value = ci.Client.ClientPortUsage;

         // Last Access
         dataGridView1.Rows[rowIndex].Cells[LastAccessDateIndex].Value = ci.Client.LastAccessDate;
         UpdateLastAccessDateDisplayOption();

         foreach (KeyValuePair<string, DataGridViewCheckBoxColumn> kvp in _permissionColumns)
         {
            string sPermission = kvp.Key;
            dataGridView1.Rows[rowIndex].Cells[kvp.Value.Index].Value = ci.Permissions.Contains(sPermission);
         }

         // invalidate
         dataGridView1.InvalidateRow(rowIndex);
      }

      private void Freeze(IntPtr handle)
      {
         try
         {
            Win32APIWrapper.SendMessage(handle,Win32APIWrapper.Win32Constants.WindowsMessage.WM_SETREDRAW,
                                        0,IntPtr.Zero);
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
            Win32APIWrapper.SendMessage(handle,Win32APIWrapper.Win32Constants.WindowsMessage.WM_SETREDRAW,
                                        1,IntPtr.Zero);
         }
         catch (Exception exception)
         {
            System.Diagnostics.Debug.Assert(false);

            throw exception;
         }
      }

      private void UpdateSearchDictionary()
      {
         if (_clientInformationList == null)
            return;

         // Dictionary<string, ClientInformation> d = new Dictionary<string, ClientInformation>();

         if (_searchDictionary == null)
         {
            _searchDictionary = new Dictionary<string, ClientInformation>();
         }
         _searchDictionary.Clear();

         foreach (var value in _clientInformationList.ClientDictionary)
         {
            ClientInformation ci = value.Value;
            AeInfoExtended ae = ci.Client;

            bool contains = true;

            // AE Title
            if (contains)
            {
               string aeTitle = textBoxAeTitle.Text.Trim();
               if (!string.IsNullOrWhiteSpace(aeTitle))
               {
                  contains = ae.AETitle.CaseInsensitiveContains(aeTitle);
               }
            }

            // Alias
            if (contains)
            {
               string friendlyName = textBoxAlias.Text.Trim();
               if (!string.IsNullOrWhiteSpace(friendlyName))
               {
                  contains = ae.FriendlyName.CaseInsensitiveContains(friendlyName);
               }
            }

            // Address
            if (contains)
            {
               string address = textBoxAddress.Text.Trim();
               if (!string.IsNullOrWhiteSpace(address))
               {
                  contains = ae.Address.CaseInsensitiveContains(address);
               }
            }

            // Subnet Mask
            if (contains)
            {
               string subnetMask = textBoxSubnetMask.Text.Trim();
               if (!string.IsNullOrWhiteSpace(subnetMask))
               {
                  contains = ae.Address.CaseInsensitiveContains(subnetMask);
               }
            }

            // Port
            if (contains)
            {
               string port = textBoxPort.Text.Trim();
               if (!string.IsNullOrWhiteSpace(port))
               {
                  string stringPort = ae.Port.ToString();
                  contains = stringPort.CaseInsensitiveContains(port);
               }
            }

            // Secure Port
            if (contains)
            {
               string securePort = textBoxSecurePort.Text.Trim();
               if (!string.IsNullOrWhiteSpace(securePort))
               {
                  string stringPort = ae.SecurePort.ToString();
                  contains = stringPort.CaseInsensitiveContains(securePort);
               }
            }

            // Port Usage
            if (contains)
            {
               if (comboBoxPortUsage.SelectedItem is ClientPortUsageType)
               {
                  ClientPortUsageType clientPortUsage = (ClientPortUsageType)comboBoxPortUsage.SelectedItem;

                  if (clientPortUsage != ClientPortUsageType.None)
                  {
                     contains = (ae.ClientPortUsage == clientPortUsage);
                  }
               }
            }

            // Delete
            if (contains)
            {
               if (this.checkBoxDelete.CheckState != CheckState.Indeterminate)
               {
                  bool containsPermission = ci.Permissions.Contains("Delete");
                  contains = 
                     (containsPermission && (checkBoxDelete.CheckState == CheckState.Checked)) ||
                      (!containsPermission && (checkBoxDelete.CheckState != CheckState.Checked));
               }
            }

            // Overwrite
            if (contains)
            {
               if (this.checkBoxOverwrite.CheckState != CheckState.Indeterminate)
               {
                  bool containsPermission = ci.Permissions.Contains("Overwrite");
                  contains = 
                     (containsPermission && (checkBoxOverwrite.CheckState == CheckState.Checked)) ||
                      (!containsPermission && (checkBoxOverwrite.CheckState != CheckState.Checked));
               }
            }

            // Update
            if (contains)
            {
               if (this.checkBoxUpdate.CheckState != CheckState.Indeterminate)
               {
                  bool containsPermission = ci.Permissions.Contains("Update");
                  contains = 
                     (containsPermission && (checkBoxUpdate.CheckState == CheckState.Checked)) ||
                      (!containsPermission && (checkBoxUpdate.CheckState != CheckState.Checked));
               }
            }

            // Last Access
            if (contains)
            {
               if (dateTimePickerStartDate.Checked)
               {
                  contains = (ae.LastAccessDate >= dateTimePickerStartDate.Value);
               }
            }

            if (contains)
            {
               if (dateTimePickerEndDate.Checked)
               {
                  DateTime myEndDate = dateTimePickerEndDate.Value;
                  myEndDate = myEndDate.AddDays(1).AddTicks(-1);
                  contains = (ae.LastAccessDate <= myEndDate);
               }
            }

            // 
            if (contains)
            {
               _searchDictionary.Add(value.Key, value.Value);
            }
         }
         UpdatePaginationMaxPageNumber();
         UpdateUI();
      }

      private Dictionary<string, ClientInformation> _searchDictionary = null;

      private void UpdateGridview()
      {
         if (dataGridView1 == null)
            return;

         try
         {
            RemoveAllRows();
            Freeze(dataGridView1.Handle);
            //
            // ADF: This is a fix for incident (12489IDT=> http://http://192.168.0.120/DesktopModules/ViewIncident.aspx?rqstno=12489IDT)
            // If you don't disable this the datagrid will try to resize all cells everytime a new row is added.
            //
            ColumnPort.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            ColumnSecurePort.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            ColumnPortUsage.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            ColumnLastAccessDate.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;


            // paginationControl1.PageNumber is 1-based
            paginationControl1.PageSize = _options.PageSize;
            UpdatePaginationMaxPageNumber();
            int nStart = paginationControl1.PageSize * (paginationControl1.PageNumber - 1);
            int nEnd = nStart + this.paginationControl1.PageSize;

             UpdateSearchDictionary();

            if (_searchDictionary != null)
               {

               this.paginationControl1.Enabled = true;
               this.paginationControl1.EnableItems(true);

               switch (_options.PaginationDisplay)
               {
                  case PaginationDisplayOptions.ShowAlways:
                     paginationControl1.Visible = true;
                     break;

                  case PaginationDisplayOptions.ShowWhenNecessary:
                     paginationControl1.Visible = (_searchDictionary.Count > paginationControl1.PageSize);
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
                  if (i < _searchDictionary.Values.Count)
                  {
                     AddRow(_searchDictionary.Values.ElementAt(i));
                  }
               }
            }

         }
         finally
         {
            ColumnPort.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            ColumnSecurePort.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            ColumnPortUsage.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            ColumnLastAccessDate.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            Unfreeze(dataGridView1.Handle);
            dataGridView1.Refresh();
            paginationControl1.UpdateStatus();
         }
      }

      private void SetupPortUsage()
      {
         if (comboBoxPortUsage.Items.Count == 0)
         {
            comboBoxPortUsage.Items.Add("");
            comboBoxPortUsage.Items.Add(ClientPortUsageType.Unsecure);
            comboBoxPortUsage.Items.Add(ClientPortUsageType.Secure);
            comboBoxPortUsage.Items.Add(ClientPortUsageType.SameAsServer);

            comboBoxPortUsage.SelectedIndex = (int)ClientPortUsageType.None;
         }
      }


      private void ClientViewerControl_Load(object sender, EventArgs e)
      {
         SetupDataViewGrid();

         // Remove any rows from datagridview
         RemoveAllRows();

         SetupPagination();

         SetupPortUsage();

         LoadClients(this, EventArgs.Empty);
         if (_clientInformationList != null)
         {
           UpdateGridview();
         }
         else
         {
            _clientInformationList = new ClientInformationList();
         }

         EnableItems();
         EnableAddClient();
         UpdateUI();
      }

      QueryPageInfo _queryPageInfo = new QueryPageInfo(5, 10);

      public QueryPageInfo PaginationOptions
      {
         get
         {
            return _queryPageInfo;
         }
         set
         {
            _queryPageInfo = value;
         }
      }

      private static int CalculateMaxPageNumber(int pageSize, int clientCount)
      {
         int maxPageNumber = 0;
         double totalPages = ((double)clientCount/ (double)pageSize);
         maxPageNumber = (int)Math.Ceiling(totalPages); // - 1;
         if (maxPageNumber == 0)
         {
            maxPageNumber = 1;
         }
         return maxPageNumber;
      }

      private void UpdatePaginationMaxPageNumber()
      {
         if (_clientInformationList != null && _clientInformationList.ClientDictionary != null)
         {
            int searchDictionaryCount = _clientInformationList.ClientDictionary.Count;
            if (_searchDictionary != null)
            {
               searchDictionaryCount = _searchDictionary.Count;
            }
            // paginationControl1.MaxPageNumber = CalculateMaxPageNumber(paginationControl1.PageSize, _clientInformationList.ClientDictionary.Count);
            paginationControl1.MaxPageNumber = CalculateMaxPageNumber(paginationControl1.PageSize, searchDictionaryCount);
            paginationControl1.UpdateStatus();
         }
      }

      private void SetupPagination()
      {
         paginationControl1.Enabled = true;
         // paginationControl1.PageSize = 5;
         paginationControl1.MinPageNumber = 1;
         UpdatePaginationMaxPageNumber();
         paginationControl1.PageNumber = 1;
      }

      private void ButtonSearchClear_Click(object sender, EventArgs e)
      {
         this.textBoxAeTitle.Text = string.Empty;
         this.textBoxAlias.Text = string.Empty;
         this.textBoxAddress.Text = string.Empty;
         this.textBoxSubnetMask.Text = string.Empty;
         this.textBoxPort.Text = string.Empty;
         this.textBoxSecurePort.Text = string.Empty;

         this.checkBoxDelete.CheckState = CheckState.Indeterminate;
         this.checkBoxOverwrite.CheckState = CheckState.Indeterminate;
         this.checkBoxUpdate.CheckState = CheckState.Indeterminate;
         this.comboBoxPortUsage.SelectedIndex = (int)ClientPortUsageType.None;

         ResetLastAccessDate();

         paginationControl1.PageNumber = 1;
         UpdateGridview();
      }

      private void ButtonSearch_Click(object sender, EventArgs e)
      {
         paginationControl1.PageNumber = 1;
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

      private void EnableItems()
      {
         int selectedRowCount = dataGridView1.SelectedRows.Count;

         EnableAddClient();
         this.ModifyClientToolStripButton.Enabled = (selectedRowCount == 1);
         this.DeleteClienteToolStripButton.Enabled = (selectedRowCount >= 1);
      }

      private void dataGridView1_SelectionChanged(object sender, EventArgs e)
      {
         EnableItems();
      }

      private void DeleteClients()
      {
         foreach (DataGridViewRow row in dataGridView1.SelectedRows)
         {
            string aeTitle = row.Cells[0].Value.ToString();
            ClientInformation ci;
            if (_clientInformationList.ClientDictionary.TryGetValue(aeTitle, out ci))
            {
               dataGridView1.Rows.Remove(row);
               _clientInformationList.ClientDictionary.Remove(aeTitle);
            }
         }
      }

      private bool InsertClient()
      {
         bool ret = false;
         InsertModifyClientDialog dialog = new InsertModifyClientDialog() { DialogType = InsertModifyClientControlType.Insert };
         dialog.ServerSecure = ServerSecure;
         dialog.Permissions = Permissions;
         List<string> permissionList = new List<string>();
         foreach (Permission p in NewClientPermissions)
         {
            permissionList.Add(p.Name);
         }
         dialog.ClientInformation = new ClientInformation(null, permissionList.ToArray());
         dialog.ValidateClientData += new EventHandler<ClientInformationEventArgs>(dialog_Validate);
         if (DialogResult.OK == dialog.ShowDialog())
         {
            AddRow(dialog.ClientInformation);
            _clientInformationList.ClientDictionary.Add(dialog.ClientInformation.Client.AETitle, dialog.ClientInformation);
            ret = true;
         }
         return ret;
      }


      void dialog_Validate(object sender, ClientInformationEventArgs e)
      {
         string error = string.Empty;
         InsertModifyClientDialog dialog = (InsertModifyClientDialog)sender;

         e.IsValid = true;
         // Clear existing errors
         dialog.ValidateAeTitle(string.Empty);
         dialog.ValidateAddress(string.Empty);
         dialog.ValidateMask(string.Empty);
         dialog.ValidatePort(string.Empty);
         dialog.ValidateSecurePort(string.Empty);

         // AETitle
         if (!Utils.IsValidApplicationEntity(e.ClientInformation.Client.AETitle, out error))
         {
            dialog.ValidateAeTitle(error);
            e.IsValid = false;
         }
         else if (e.IsInsert && (ClientInformationList.ClientDictionary.ContainsKey(e.ClientInformation.Client.AETitle.Trim())))
         {
            // insert -- verify AeTile does not already exist
            dialog.ValidateAeTitle("Duplicate Application Entity Title.");
            e.IsValid = false;
         }
         else if (!e.IsInsert && e.IsNewAeTitle && (ClientInformationList.ClientDictionary.ContainsKey(e.ClientInformation.Client.AETitle.Trim())))
         {
            // modify and the aeTitle has changed -- verify the AeTitle does not already exist
            dialog.ValidateAeTitle("Duplicate Application Entity Title.");
            e.IsValid = false;
         }
         else if (e.ClientInformation.Client.VerifyAddress && !Utils.IsValidHostnameOrAddress(e.ClientInformation.Client.Address, out error))
         {
            // Address
            dialog.ValidateAddress(error);
            e.IsValid = false;
         }
         else if (e.ClientInformation.Client.VerifyMask && !Utils.IsValidHostnameOrAddress(e.ClientInformation.Client.Mask, out error))
         {
            // Mask
            dialog.ValidateMask(error);
            e.IsValid = false;
         }
         else if (e.ClientInformation.Client.Port == 0)
         {
            // port
            dialog.ValidatePort("Port must be non-zero");
            e.IsValid = false;
         }
         else if (e.ClientInformation.Client.SecurePort == 0)
         {
            // secure port
            dialog.ValidateSecurePort("Port must be non-zero");
            e.IsValid = false;
         }


      }


      private bool ModifyClient()
      {
         bool ret = false;
         InsertModifyClientDialog dialog = new InsertModifyClientDialog() { DialogType = InsertModifyClientControlType.Modify };
         dialog.ServerSecure = ServerSecure;
         dialog.ValidateClientData += new EventHandler<ClientInformationEventArgs>(dialog_Validate);
         dialog.Permissions = Permissions;
         string aeTitle = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
         if (_clientInformationList.ClientDictionary.ContainsKey(aeTitle))
         {
            ClientInformation ciTemp = new ClientInformation(_clientInformationList.ClientDictionary[aeTitle]);
            dialog.ClientInformation = ciTemp;
            if (DialogResult.OK == dialog.ShowDialog())
            {
               _clientInformationList.ClientDictionary.Remove(aeTitle);
               _clientInformationList.ClientDictionary.Add(ciTemp.Client.AETitle, ciTemp);
               UpdateSelectedRow(dialog.ClientInformation);
               ret = true;
            }
         }
         return ret;
      }

      private void dataGridView1_DoubleClick(object sender, EventArgs e)
      {
         if (dataGridView1.SelectedRows.Count == 1)
         {
            if (ModifyClient())
            {
               OnSetIsDirty(sender, e);
            }
         }
      }

      private void AddClientToolStripButton_Click(object sender, EventArgs e)
      {
         if (InsertClient())
         {
            OnSetIsDirty(sender, e);
         }
         UpdatePaginationMaxPageNumber();
      }

      private void ModifyClientToolStripButton_Click(object sender, EventArgs e)
      {
         if (ModifyClient())
         {
            OnSetIsDirty(sender, e);
         }
      }

      private void DeleteClienteToolStripButton_Click(object sender, EventArgs e)
      {
         int count = dataGridView1.SelectedRows.Count;
         string msg = string.Format("You are about to permanently delete {0} client(s).\n\rDo you want to continue?", count);
         DialogResult dr = MessageBox.Show(msg, "Delete Client(s)", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
         if (dr == DialogResult.Yes)
         {
            DeleteClients();
            OnSetIsDirty(sender, e);
         }
         UpdatePaginationMaxPageNumber();
      }

      private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
      {
         EnableAddClient();
      }

      private void dataGridView1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
      {
         EnableAddClient(); 
      }

      private void EnableAddClient()
      {        
         AddClientToolStripButton.Enabled = MaxClients == null || dataGridView1.Rows.Count < MaxClients.Value;
      }

      private static void AllowColumnResizing(DataGridViewColumn c)
      {
         c.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
         int widthCol = c.Width;
         c.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
         c.Width = widthCol;
      }

      private void AllowColumnResizing()
      {
         AllowColumnResizing(ColumnAeTitle);
         AllowColumnResizing(ColumnFriendlyName);
         AllowColumnResizing(ColumnAddress);
         AllowColumnResizing(ColumnMask);
         AllowColumnResizing(ColumnPort);
         AllowColumnResizing(ColumnSecurePort);
         AllowColumnResizing(ColumnPortUsage);
         AllowColumnResizing(ColumnLastAccessDate);
      }
      
      private void UpdateUI()
      {
         string groupBoxHeader = "Clients";
         try
         {
            int count = this._searchDictionary.Count();

            if ((MaxClients == null) || (MaxClients == int.MaxValue))
            {
               groupBoxHeader = string.Format("Clients (Search count: {0})", count);
            }
            else
            {
               groupBoxHeader = string.Format("Clients (Search count: {0} of {1} Maximum)", count, MaxClients);
            }
         }
         catch (Exception)
         {
         }
         finally
         {
            groupBoxClients.Text = groupBoxHeader;
            AllowColumnResizing();
         }
      }

      private void OnSetIsDirty(object sender, EventArgs e)
      {
         try
         {
            IsDirty = true;
            UpdateUI();
            OnSettingsChanged(sender, e);
         }
         catch (Exception)
         {
            System.Diagnostics.Debug.Assert(false);
         }
      }

      private bool _isDirty = false;

      public bool IsDirty
      {
         get
         {
            return _isDirty;
         }
         private set
         {
            _isDirty = value;
         }
      }

      public event EventHandler SettingsChanged;


      private void OnSettingsChanged(object sender, EventArgs e)
      {
         try
         {
            if (SettingsChanged != null)
            {
               SettingsChanged(sender, e);
            }
         }
         catch (Exception)
         {
            System.Diagnostics.Debug.Assert(false);
         }
      }

      private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
      {
         if (
               (dataGridView1.SelectedRows.Count == 1) &&
               (e.RowIndex > -1) &&
               (e.ColumnIndex > -1)
            )
         {
            if (ModifyClient())
            {
               OnSetIsDirty(sender, e);
            }
         }
      }

      private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
      {
         DataGridView dgv = (DataGridView)sender;
         if (dgv.Columns[e.ColumnIndex].Name == ColumnLastAccessDate.Name && e.RowIndex >= 0 /*&& dgv["TargetColumnName", e.RowIndex].Value is int*/)
         {
            object myValue = dgv[ColumnLastAccessDate.Name, e.RowIndex].Value;

            bool neverAccessed = false;
            if (myValue == null)
            {
               neverAccessed = true;
            }
            else
            {
               if (myValue is DateTime)
               {
                  DateTime dateTime = (DateTime)myValue;
                  if (dateTime == DateTime.MinValue)
                  {
                     neverAccessed = true;
                  }
               }
            }

            if (neverAccessed)
            {
               e.Value = "None";
               e.FormattingApplied = true;
            }
         }
      }
   }

   internal static class MyExtensions
   {
      public static bool CaseInsensitiveContains(this string text, string value, StringComparison stringComparison = StringComparison.CurrentCultureIgnoreCase)
      {
         return text.IndexOf(value, stringComparison) >= 0;
      }
   }
}
