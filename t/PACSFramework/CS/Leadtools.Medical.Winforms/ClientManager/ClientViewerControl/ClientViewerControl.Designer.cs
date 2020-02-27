namespace Leadtools.Medical.Winforms
{
   partial class ClientViewerControl
   {
      /// <summary> 
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.IContainer components = null;

      /// <summary> 
      /// Clean up any resources being used.
      /// </summary>
      /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      protected override void Dispose(bool disposing)
      {
         if (disposing && (components != null))
         {
            components.Dispose();
         }
         base.Dispose(disposing);
      }

      #region Component Designer generated code

      /// <summary> 
      /// Required method for Designer support - do not modify 
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         this.components = new System.ComponentModel.Container();
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClientViewerControl));
         System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
         System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
         this.toolTip = new System.Windows.Forms.ToolTip(this.components);
         this.buttonSearch = new System.Windows.Forms.Button();
         this.buttonSearchClear = new System.Windows.Forms.Button();
         this.InsertClientToolStripButton = new System.Windows.Forms.ToolStripButton();
         this.ColumnAeTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.ColumnFriendlyName = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.ColumnPort = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.ColumnSecurePort = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.ColumnPortUsage = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.toolStripButton = new System.Windows.Forms.ToolStripButton();
         this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
         this.ColumnLastAccessDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.dataGridView1 = new System.Windows.Forms.DataGridView();
         this.miniToolStrip = new System.Windows.Forms.ToolStrip();
         this.AddClientToolStripButton = new System.Windows.Forms.ToolStripButton();
         this.ModifyClientToolStripButton = new System.Windows.Forms.ToolStripButton();
         this.DeleteClienteToolStripButton = new System.Windows.Forms.ToolStripButton();
         this.groupBoxSearch = new System.Windows.Forms.GroupBox();
         this.dateTimePickerEndDate = new System.Windows.Forms.DateTimePicker();
         this.dateTimePickerStartDate = new System.Windows.Forms.DateTimePicker();
         this.labelLastAccess = new System.Windows.Forms.Label();
         this.comboBoxPortUsage = new System.Windows.Forms.ComboBox();
         this.label3 = new System.Windows.Forms.Label();
         this.labelPortUsage = new System.Windows.Forms.Label();
         this.label1 = new System.Windows.Forms.Label();
         this.textBoxSubnetMask = new System.Windows.Forms.TextBox();
         this.labelSubnetMask = new System.Windows.Forms.Label();
         this.checkBoxUpdate = new System.Windows.Forms.CheckBox();
         this.checkBoxOverwrite = new System.Windows.Forms.CheckBox();
         this.checkBoxDelete = new System.Windows.Forms.CheckBox();
         this.labelUpdate = new System.Windows.Forms.Label();
         this.labelOverwrite = new System.Windows.Forms.Label();
         this.labelDelete = new System.Windows.Forms.Label();
         this.labelSecurePort = new System.Windows.Forms.Label();
         this.textBoxSecurePort = new System.Windows.Forms.TextBox();
         this.labelPort = new System.Windows.Forms.Label();
         this.labelAddress = new System.Windows.Forms.Label();
         this.labelAlias = new System.Windows.Forms.Label();
         this.labelAeTitle = new System.Windows.Forms.Label();
         this.textBoxPort = new System.Windows.Forms.TextBox();
         this.textBoxAddress = new System.Windows.Forms.TextBox();
         this.textBoxAlias = new System.Windows.Forms.TextBox();
         this.textBoxAeTitle = new System.Windows.Forms.TextBox();
         this.groupBoxClients = new System.Windows.Forms.GroupBox();
         this.paginationControl1 = new Leadtools.Medical.Winforms.PaginationControl();
         this.clientToolStrip = new System.Windows.Forms.ToolStrip();
         this.ColumnAddress = new Leadtools.Medical.Winforms.MyDataGridViewCheckBoxTextColumn();
         this.ColumnMask = new Leadtools.Medical.Winforms.MyDataGridViewCheckBoxTextColumn();
         this.myDataGridViewCheckBoxTextColumn1 = new Leadtools.Medical.Winforms.MyDataGridViewCheckBoxTextColumn();
         this.myDataGridViewCheckBoxTextColumn2 = new Leadtools.Medical.Winforms.MyDataGridViewCheckBoxTextColumn();
         this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
         this.dataGridViewCheckBoxColumn2 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
         this.dataGridViewCheckBoxColumn3 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
         this.dataGridViewCheckBoxColumn4 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
         this.dataGridViewCheckBoxColumn5 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
         ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
         this.groupBoxSearch.SuspendLayout();
         this.groupBoxClients.SuspendLayout();
         this.clientToolStrip.SuspendLayout();
         this.SuspendLayout();
         // 
         // buttonSearch
         // 
         this.buttonSearch.BackgroundImage = global::Leadtools.Medical.Winforms.Properties.Resources.ClientSearchBig;
         this.buttonSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
         this.buttonSearch.Location = new System.Drawing.Point(849, 29);
         this.buttonSearch.Name = "buttonSearch";
         this.buttonSearch.Size = new System.Drawing.Size(40, 40);
         this.buttonSearch.TabIndex = 26;
         this.toolTip.SetToolTip(this.buttonSearch, "Search");
         this.buttonSearch.UseVisualStyleBackColor = true;
         // 
         // buttonSearchClear
         // 
         this.buttonSearchClear.BackgroundImage = global::Leadtools.Medical.Winforms.Properties.Resources.Remove1;
         this.buttonSearchClear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
         this.buttonSearchClear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
         this.buttonSearchClear.Location = new System.Drawing.Point(821, 29);
         this.buttonSearchClear.Name = "buttonSearchClear";
         this.buttonSearchClear.Size = new System.Drawing.Size(68, 24);
         this.buttonSearchClear.TabIndex = 25;
         this.buttonSearchClear.Text = "Clear";
         this.toolTip.SetToolTip(this.buttonSearchClear, "Clear Search Filter");
         this.buttonSearchClear.UseVisualStyleBackColor = true;
         // 
         // InsertClientToolStripButton
         // 
         this.InsertClientToolStripButton.Name = "InsertClientToolStripButton";
         this.InsertClientToolStripButton.Size = new System.Drawing.Size(23, 23);
         // 
         // ColumnAeTitle
         // 
         this.ColumnAeTitle.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
         this.ColumnAeTitle.HeaderText = "AE Title";
         this.ColumnAeTitle.MinimumWidth = 100;
         this.ColumnAeTitle.Name = "ColumnAeTitle";
         this.ColumnAeTitle.ReadOnly = true;
         // 
         // ColumnFriendlyName
         // 
         this.ColumnFriendlyName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
         this.ColumnFriendlyName.HeaderText = "Alias";
         this.ColumnFriendlyName.Name = "ColumnFriendlyName";
         this.ColumnFriendlyName.ReadOnly = true;
         // 
         // ColumnPort
         // 
         this.ColumnPort.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
         this.ColumnPort.HeaderText = "Port";
         this.ColumnPort.Name = "ColumnPort";
         this.ColumnPort.ReadOnly = true;
         // 
         // ColumnSecurePort
         // 
         this.ColumnSecurePort.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
         this.ColumnSecurePort.HeaderText = "Secure Port";
         this.ColumnSecurePort.Name = "ColumnSecurePort";
         this.ColumnSecurePort.ReadOnly = true;
         // 
         // ColumnPortUsage
         // 
         this.ColumnPortUsage.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
         this.ColumnPortUsage.HeaderText = "Port Usage";
         this.ColumnPortUsage.Name = "ColumnPortUsage";
         this.ColumnPortUsage.ReadOnly = true;
         // 
         // toolStripButton
         // 
         this.toolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.toolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton.Image")));
         this.toolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.toolStripButton.Name = "toolStripButton";
         this.toolStripButton.Size = new System.Drawing.Size(36, 36);
         this.toolStripButton.Text = "toolStripButton1";
         // 
         // toolStripButton1
         // 
         this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
         this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.toolStripButton1.Name = "toolStripButton1";
         this.toolStripButton1.Size = new System.Drawing.Size(36, 36);
         this.toolStripButton1.Text = "toolStripButton1";
         // 
         // ColumnLastAccessDate
         // 
         this.ColumnLastAccessDate.HeaderText = "Last Access";
         this.ColumnLastAccessDate.Name = "ColumnLastAccessDate";
         // 
         // dataGridView1
         // 
         this.dataGridView1.AllowUserToAddRows = false;
         this.dataGridView1.AllowUserToDeleteRows = false;
         this.dataGridView1.AllowUserToResizeRows = false;
         this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
         this.dataGridView1.Location = new System.Drawing.Point(15, 63);
         this.dataGridView1.Name = "dataGridView1";
         this.dataGridView1.RowHeadersVisible = false;
         this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
         this.dataGridView1.Size = new System.Drawing.Size(895, 282);
         this.dataGridView1.TabIndex = 1;
         this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
         this.dataGridView1.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseDoubleClick);
         this.dataGridView1.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dataGridView1_RowsAdded);
         this.dataGridView1.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dataGridView1_RowsRemoved);
         this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
         // 
         // miniToolStrip
         // 
         this.miniToolStrip.AccessibleName = "New item selection";
         this.miniToolStrip.AccessibleRole = System.Windows.Forms.AccessibleRole.ButtonDropDown;
         this.miniToolStrip.AutoSize = false;
         this.miniToolStrip.CanOverflow = false;
         this.miniToolStrip.Dock = System.Windows.Forms.DockStyle.None;
         this.miniToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
         this.miniToolStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
         this.miniToolStrip.Location = new System.Drawing.Point(108, 10);
         this.miniToolStrip.Name = "miniToolStrip";
         this.miniToolStrip.Size = new System.Drawing.Size(111, 39);
         this.miniToolStrip.Stretch = true;
         this.miniToolStrip.TabIndex = 0;
         // 
         // AddClientToolStripButton
         // 
         this.AddClientToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.AddClientToolStripButton.Image = global::Leadtools.Medical.Winforms.Properties.Resources.ClientAdd;
         this.AddClientToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.AddClientToolStripButton.Name = "AddClientToolStripButton";
         this.AddClientToolStripButton.Size = new System.Drawing.Size(36, 36);
         this.AddClientToolStripButton.Text = "Add Client";
         this.AddClientToolStripButton.Click += new System.EventHandler(this.AddClientToolStripButton_Click);
         // 
         // ModifyClientToolStripButton
         // 
         this.ModifyClientToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.ModifyClientToolStripButton.Image = global::Leadtools.Medical.Winforms.Properties.Resources.ClientEdit;
         this.ModifyClientToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.ModifyClientToolStripButton.Name = "ModifyClientToolStripButton";
         this.ModifyClientToolStripButton.Size = new System.Drawing.Size(36, 36);
         this.ModifyClientToolStripButton.Text = "Modify Client";
         this.ModifyClientToolStripButton.Click += new System.EventHandler(this.ModifyClientToolStripButton_Click);
         // 
         // DeleteClienteToolStripButton
         // 
         this.DeleteClienteToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.DeleteClienteToolStripButton.Image = global::Leadtools.Medical.Winforms.Properties.Resources.ClientDelete;
         this.DeleteClienteToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.DeleteClienteToolStripButton.Name = "DeleteClienteToolStripButton";
         this.DeleteClienteToolStripButton.Size = new System.Drawing.Size(36, 36);
         this.DeleteClienteToolStripButton.Text = "Delete Client(s)";
         this.DeleteClienteToolStripButton.Click += new System.EventHandler(this.DeleteClienteToolStripButton_Click);
         // 
         // groupBoxSearch
         // 
         this.groupBoxSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.groupBoxSearch.Controls.Add(this.buttonSearchClear);
         this.groupBoxSearch.Controls.Add(this.buttonSearch);
         this.groupBoxSearch.Controls.Add(this.dateTimePickerEndDate);
         this.groupBoxSearch.Controls.Add(this.dateTimePickerStartDate);
         this.groupBoxSearch.Controls.Add(this.labelLastAccess);
         this.groupBoxSearch.Controls.Add(this.comboBoxPortUsage);
         this.groupBoxSearch.Controls.Add(this.label3);
         this.groupBoxSearch.Controls.Add(this.labelPortUsage);
         this.groupBoxSearch.Controls.Add(this.label1);
         this.groupBoxSearch.Controls.Add(this.textBoxSubnetMask);
         this.groupBoxSearch.Controls.Add(this.labelSubnetMask);
         this.groupBoxSearch.Controls.Add(this.checkBoxUpdate);
         this.groupBoxSearch.Controls.Add(this.checkBoxOverwrite);
         this.groupBoxSearch.Controls.Add(this.checkBoxDelete);
         this.groupBoxSearch.Controls.Add(this.labelUpdate);
         this.groupBoxSearch.Controls.Add(this.labelOverwrite);
         this.groupBoxSearch.Controls.Add(this.labelDelete);
         this.groupBoxSearch.Controls.Add(this.labelSecurePort);
         this.groupBoxSearch.Controls.Add(this.textBoxSecurePort);
         this.groupBoxSearch.Controls.Add(this.labelPort);
         this.groupBoxSearch.Controls.Add(this.labelAddress);
         this.groupBoxSearch.Controls.Add(this.labelAlias);
         this.groupBoxSearch.Controls.Add(this.labelAeTitle);
         this.groupBoxSearch.Controls.Add(this.textBoxPort);
         this.groupBoxSearch.Controls.Add(this.textBoxAddress);
         this.groupBoxSearch.Controls.Add(this.textBoxAlias);
         this.groupBoxSearch.Controls.Add(this.textBoxAeTitle);
         this.groupBoxSearch.Location = new System.Drawing.Point(13, 387);
         this.groupBoxSearch.Name = "groupBoxSearch";
         this.groupBoxSearch.Size = new System.Drawing.Size(895, 82);
         this.groupBoxSearch.TabIndex = 3;
         this.groupBoxSearch.TabStop = false;
         this.groupBoxSearch.Text = "Search Filter";
         // 
         // dateTimePickerEndDate
         // 
         this.dateTimePickerEndDate.Checked = false;
         this.dateTimePickerEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
         this.dateTimePickerEndDate.Location = new System.Drawing.Point(711, 54);
         this.dateTimePickerEndDate.Name = "dateTimePickerEndDate";
         this.dateTimePickerEndDate.ShowCheckBox = true;
         this.dateTimePickerEndDate.Size = new System.Drawing.Size(97, 20);
         this.dateTimePickerEndDate.TabIndex = 24;
         // 
         // dateTimePickerStartDate
         // 
         this.dateTimePickerStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
         this.dateTimePickerStartDate.Location = new System.Drawing.Point(711, 31);
         this.dateTimePickerStartDate.Name = "dateTimePickerStartDate";
         this.dateTimePickerStartDate.ShowCheckBox = true;
         this.dateTimePickerStartDate.Size = new System.Drawing.Size(97, 20);
         this.dateTimePickerStartDate.TabIndex = 22;
         // 
         // labelLastAccess
         // 
         this.labelLastAccess.AutoSize = true;
         this.labelLastAccess.Location = new System.Drawing.Point(711, 14);
         this.labelLastAccess.Name = "labelLastAccess";
         this.labelLastAccess.Size = new System.Drawing.Size(68, 13);
         this.labelLastAccess.TabIndex = 20;
         this.labelLastAccess.Text = "Last Access:";
         // 
         // comboBoxPortUsage
         // 
         this.comboBoxPortUsage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.comboBoxPortUsage.FormattingEnabled = true;
         this.comboBoxPortUsage.Location = new System.Drawing.Point(452, 31);
         this.comboBoxPortUsage.Name = "comboBoxPortUsage";
         this.comboBoxPortUsage.Size = new System.Drawing.Size(94, 21);
         this.comboBoxPortUsage.TabIndex = 13;
         // 
         // label3
         // 
         this.label3.AutoSize = true;
         this.label3.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
         this.label3.Location = new System.Drawing.Point(684, 58);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(29, 13);
         this.label3.TabIndex = 23;
         this.label3.Text = "End:";
         // 
         // labelPortUsage
         // 
         this.labelPortUsage.AutoSize = true;
         this.labelPortUsage.Location = new System.Drawing.Point(452, 14);
         this.labelPortUsage.Name = "labelPortUsage";
         this.labelPortUsage.Size = new System.Drawing.Size(63, 13);
         this.labelPortUsage.TabIndex = 12;
         this.labelPortUsage.Text = "Port Usage:";
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
         this.label1.Location = new System.Drawing.Point(681, 35);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(32, 13);
         this.label1.TabIndex = 21;
         this.label1.Text = "Start:";
         // 
         // textBoxSubnetMask
         // 
         this.textBoxSubnetMask.Location = new System.Drawing.Point(270, 31);
         this.textBoxSubnetMask.Name = "textBoxSubnetMask";
         this.textBoxSubnetMask.Size = new System.Drawing.Size(79, 20);
         this.textBoxSubnetMask.TabIndex = 7;
         // 
         // labelSubnetMask
         // 
         this.labelSubnetMask.AutoSize = true;
         this.labelSubnetMask.Location = new System.Drawing.Point(270, 14);
         this.labelSubnetMask.Name = "labelSubnetMask";
         this.labelSubnetMask.Size = new System.Drawing.Size(73, 13);
         this.labelSubnetMask.TabIndex = 6;
         this.labelSubnetMask.Text = "Subnet Mask:";
         // 
         // checkBoxUpdate
         // 
         this.checkBoxUpdate.AutoSize = true;
         this.checkBoxUpdate.Location = new System.Drawing.Point(649, 34);
         this.checkBoxUpdate.Name = "checkBoxUpdate";
         this.checkBoxUpdate.Size = new System.Drawing.Size(15, 14);
         this.checkBoxUpdate.TabIndex = 19;
         this.checkBoxUpdate.ThreeState = true;
         this.checkBoxUpdate.UseVisualStyleBackColor = true;
         // 
         // checkBoxOverwrite
         // 
         this.checkBoxOverwrite.AutoSize = true;
         this.checkBoxOverwrite.Location = new System.Drawing.Point(602, 34);
         this.checkBoxOverwrite.Name = "checkBoxOverwrite";
         this.checkBoxOverwrite.Size = new System.Drawing.Size(15, 14);
         this.checkBoxOverwrite.TabIndex = 17;
         this.checkBoxOverwrite.ThreeState = true;
         this.checkBoxOverwrite.UseVisualStyleBackColor = true;
         // 
         // checkBoxDelete
         // 
         this.checkBoxDelete.AutoSize = true;
         this.checkBoxDelete.Location = new System.Drawing.Point(555, 34);
         this.checkBoxDelete.Name = "checkBoxDelete";
         this.checkBoxDelete.Size = new System.Drawing.Size(15, 14);
         this.checkBoxDelete.TabIndex = 15;
         this.checkBoxDelete.ThreeState = true;
         this.checkBoxDelete.UseVisualStyleBackColor = true;
         // 
         // labelUpdate
         // 
         this.labelUpdate.AutoSize = true;
         this.labelUpdate.Location = new System.Drawing.Point(635, 14);
         this.labelUpdate.Name = "labelUpdate";
         this.labelUpdate.Size = new System.Drawing.Size(45, 13);
         this.labelUpdate.TabIndex = 18;
         this.labelUpdate.Text = "Update:";
         // 
         // labelOverwrite
         // 
         this.labelOverwrite.AutoSize = true;
         this.labelOverwrite.Location = new System.Drawing.Point(583, 14);
         this.labelOverwrite.Name = "labelOverwrite";
         this.labelOverwrite.Size = new System.Drawing.Size(55, 13);
         this.labelOverwrite.TabIndex = 16;
         this.labelOverwrite.Text = "Overwrite:";
         // 
         // labelDelete
         // 
         this.labelDelete.AutoSize = true;
         this.labelDelete.Location = new System.Drawing.Point(543, 14);
         this.labelDelete.Name = "labelDelete";
         this.labelDelete.Size = new System.Drawing.Size(41, 13);
         this.labelDelete.TabIndex = 14;
         this.labelDelete.Text = "Delete:";
         // 
         // labelSecurePort
         // 
         this.labelSecurePort.AutoSize = true;
         this.labelSecurePort.Location = new System.Drawing.Point(405, 14);
         this.labelSecurePort.Name = "labelSecurePort";
         this.labelSecurePort.Size = new System.Drawing.Size(44, 13);
         this.labelSecurePort.TabIndex = 10;
         this.labelSecurePort.Text = "Secure:";
         // 
         // textBoxSecurePort
         // 
         this.textBoxSecurePort.Location = new System.Drawing.Point(405, 31);
         this.textBoxSecurePort.Name = "textBoxSecurePort";
         this.textBoxSecurePort.Size = new System.Drawing.Size(38, 20);
         this.textBoxSecurePort.TabIndex = 11;
         // 
         // labelPort
         // 
         this.labelPort.AutoSize = true;
         this.labelPort.Location = new System.Drawing.Point(358, 14);
         this.labelPort.Name = "labelPort";
         this.labelPort.Size = new System.Drawing.Size(29, 13);
         this.labelPort.TabIndex = 8;
         this.labelPort.Text = "Port:";
         // 
         // labelAddress
         // 
         this.labelAddress.AutoSize = true;
         this.labelAddress.Location = new System.Drawing.Point(182, 14);
         this.labelAddress.Name = "labelAddress";
         this.labelAddress.Size = new System.Drawing.Size(48, 13);
         this.labelAddress.TabIndex = 4;
         this.labelAddress.Text = "Address:";
         // 
         // labelAlias
         // 
         this.labelAlias.AutoSize = true;
         this.labelAlias.Location = new System.Drawing.Point(94, 14);
         this.labelAlias.Name = "labelAlias";
         this.labelAlias.Size = new System.Drawing.Size(32, 13);
         this.labelAlias.TabIndex = 2;
         this.labelAlias.Text = "Alias:";
         // 
         // labelAeTitle
         // 
         this.labelAeTitle.AutoSize = true;
         this.labelAeTitle.Location = new System.Drawing.Point(6, 14);
         this.labelAeTitle.Name = "labelAeTitle";
         this.labelAeTitle.Size = new System.Drawing.Size(47, 13);
         this.labelAeTitle.TabIndex = 0;
         this.labelAeTitle.Text = "AE Title:";
         // 
         // textBoxPort
         // 
         this.textBoxPort.Location = new System.Drawing.Point(358, 31);
         this.textBoxPort.Name = "textBoxPort";
         this.textBoxPort.Size = new System.Drawing.Size(38, 20);
         this.textBoxPort.TabIndex = 9;
         // 
         // textBoxAddress
         // 
         this.textBoxAddress.Location = new System.Drawing.Point(182, 31);
         this.textBoxAddress.Name = "textBoxAddress";
         this.textBoxAddress.Size = new System.Drawing.Size(79, 20);
         this.textBoxAddress.TabIndex = 5;
         // 
         // textBoxAlias
         // 
         this.textBoxAlias.Location = new System.Drawing.Point(94, 31);
         this.textBoxAlias.Name = "textBoxAlias";
         this.textBoxAlias.Size = new System.Drawing.Size(79, 20);
         this.textBoxAlias.TabIndex = 3;
         // 
         // textBoxAeTitle
         // 
         this.textBoxAeTitle.Location = new System.Drawing.Point(6, 31);
         this.textBoxAeTitle.Name = "textBoxAeTitle";
         this.textBoxAeTitle.Size = new System.Drawing.Size(79, 20);
         this.textBoxAeTitle.TabIndex = 1;
         // 
         // groupBoxClients
         // 
         this.groupBoxClients.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.groupBoxClients.Controls.Add(this.groupBoxSearch);
         this.groupBoxClients.Controls.Add(this.paginationControl1);
         this.groupBoxClients.Controls.Add(this.clientToolStrip);
         this.groupBoxClients.Controls.Add(this.dataGridView1);
         this.groupBoxClients.Location = new System.Drawing.Point(3, 5);
         this.groupBoxClients.Name = "groupBoxClients";
         this.groupBoxClients.Size = new System.Drawing.Size(921, 482);
         this.groupBoxClients.TabIndex = 0;
         this.groupBoxClients.TabStop = false;
         this.groupBoxClients.Text = "Clients";
         // 
         // paginationControl1
         // 
         this.paginationControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.paginationControl1.Location = new System.Drawing.Point(15, 352);
         this.paginationControl1.MaxPageNumber = 5000;
         this.paginationControl1.MinPageNumber = 10;
         this.paginationControl1.Name = "paginationControl1";
         this.paginationControl1.PageNumber = 10;
         this.paginationControl1.PageNumberIncrement = new decimal(new int[] {
            10,
            0,
            0,
            0});
         this.paginationControl1.PageSize = 5;
         this.paginationControl1.PageSizeLabel = "Page Size:";
         this.paginationControl1.Size = new System.Drawing.Size(895, 33);
         this.paginationControl1.Status = "0 / 0";
         this.paginationControl1.TabIndex = 2;
         // 
         // clientToolStrip
         // 
         this.clientToolStrip.Dock = System.Windows.Forms.DockStyle.None;
         this.clientToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
         this.clientToolStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
         this.clientToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddClientToolStripButton,
            this.ModifyClientToolStripButton,
            this.DeleteClienteToolStripButton});
         this.clientToolStrip.Location = new System.Drawing.Point(15, 21);
         this.clientToolStrip.Name = "clientToolStrip";
         this.clientToolStrip.Size = new System.Drawing.Size(111, 39);
         this.clientToolStrip.Stretch = true;
         this.clientToolStrip.TabIndex = 0;
         // 
         // ColumnAddress
         // 
         this.ColumnAddress.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
         dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
         dataGridViewCellStyle3.NullValue = false;
         this.ColumnAddress.DefaultCellStyle = dataGridViewCellStyle3;
         this.ColumnAddress.HeaderText = "Address";
         this.ColumnAddress.MinimumWidth = 120;
         this.ColumnAddress.Name = "ColumnAddress";
         this.ColumnAddress.ReadOnly = true;
         this.ColumnAddress.Width = 130;
         // 
         // ColumnMask
         // 
         this.ColumnMask.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
         dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
         dataGridViewCellStyle4.NullValue = false;
         this.ColumnMask.DefaultCellStyle = dataGridViewCellStyle4;
         this.ColumnMask.HeaderText = "Subnet Mask";
         this.ColumnMask.MinimumWidth = 100;
         this.ColumnMask.Name = "ColumnMask";
         this.ColumnMask.ReadOnly = true;
         this.ColumnMask.Width = 130;
         // 
         // myDataGridViewCheckBoxTextColumn1
         // 
         this.myDataGridViewCheckBoxTextColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
         this.myDataGridViewCheckBoxTextColumn1.HeaderText = "Address";
         this.myDataGridViewCheckBoxTextColumn1.Name = "myDataGridViewCheckBoxTextColumn1";
         this.myDataGridViewCheckBoxTextColumn1.ReadOnly = true;
         // 
         // myDataGridViewCheckBoxTextColumn2
         // 
         this.myDataGridViewCheckBoxTextColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
         this.myDataGridViewCheckBoxTextColumn2.HeaderText = "Subnet Mask";
         this.myDataGridViewCheckBoxTextColumn2.Name = "myDataGridViewCheckBoxTextColumn2";
         this.myDataGridViewCheckBoxTextColumn2.ReadOnly = true;
         // 
         // dataGridViewCheckBoxColumn1
         // 
         this.dataGridViewCheckBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
         this.dataGridViewCheckBoxColumn1.HeaderText = "Query";
         this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
         this.dataGridViewCheckBoxColumn1.ReadOnly = true;
         // 
         // dataGridViewCheckBoxColumn2
         // 
         this.dataGridViewCheckBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
         this.dataGridViewCheckBoxColumn2.HeaderText = "Retrieve";
         this.dataGridViewCheckBoxColumn2.Name = "dataGridViewCheckBoxColumn2";
         this.dataGridViewCheckBoxColumn2.ReadOnly = true;
         // 
         // dataGridViewCheckBoxColumn3
         // 
         this.dataGridViewCheckBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
         this.dataGridViewCheckBoxColumn3.HeaderText = "Overwrite";
         this.dataGridViewCheckBoxColumn3.Name = "dataGridViewCheckBoxColumn3";
         this.dataGridViewCheckBoxColumn3.ReadOnly = true;
         // 
         // dataGridViewCheckBoxColumn4
         // 
         this.dataGridViewCheckBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
         this.dataGridViewCheckBoxColumn4.HeaderText = "Update";
         this.dataGridViewCheckBoxColumn4.Name = "dataGridViewCheckBoxColumn4";
         this.dataGridViewCheckBoxColumn4.ReadOnly = true;
         // 
         // dataGridViewCheckBoxColumn5
         // 
         this.dataGridViewCheckBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
         this.dataGridViewCheckBoxColumn5.HeaderText = "Delete";
         this.dataGridViewCheckBoxColumn5.Name = "dataGridViewCheckBoxColumn5";
         this.dataGridViewCheckBoxColumn5.ReadOnly = true;
         // 
         // ClientViewerControl
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this.groupBoxClients);
         this.Name = "ClientViewerControl";
         this.Size = new System.Drawing.Size(924, 490);
         this.Load += new System.EventHandler(this.ClientViewerControl_Load);
         ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
         this.groupBoxSearch.ResumeLayout(false);
         this.groupBoxSearch.PerformLayout();
         this.groupBoxClients.ResumeLayout(false);
         this.groupBoxClients.PerformLayout();
         this.clientToolStrip.ResumeLayout(false);
         this.clientToolStrip.PerformLayout();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.ToolTip toolTip;
      private MyDataGridViewCheckBoxTextColumn myDataGridViewCheckBoxTextColumn1;
      private MyDataGridViewCheckBoxTextColumn myDataGridViewCheckBoxTextColumn2;
      private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
      private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn2;
      private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn3;
      private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn4;
      private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn5;
      private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAeTitle;
      private System.Windows.Forms.DataGridViewTextBoxColumn ColumnFriendlyName;
      private MyDataGridViewCheckBoxTextColumn ColumnAddress;
      private MyDataGridViewCheckBoxTextColumn ColumnMask;
      private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPort;
      private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSecurePort;
      private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPortUsage;
      public System.Windows.Forms.ToolStripButton InsertClientToolStripButton;
      private System.Windows.Forms.ToolStripButton toolStripButton;
      private System.Windows.Forms.ToolStripButton toolStripButton1;
      private System.Windows.Forms.DataGridViewTextBoxColumn ColumnLastAccessDate;
      private System.Windows.Forms.DataGridView dataGridView1;
      private System.Windows.Forms.ToolStrip miniToolStrip;
      public System.Windows.Forms.ToolStripButton AddClientToolStripButton;
      public System.Windows.Forms.ToolStripButton ModifyClientToolStripButton;
      public System.Windows.Forms.ToolStripButton DeleteClienteToolStripButton;
      private PaginationControl paginationControl1;
      private System.Windows.Forms.GroupBox groupBoxSearch;
      private System.Windows.Forms.DateTimePicker dateTimePickerEndDate;
      private System.Windows.Forms.DateTimePicker dateTimePickerStartDate;
      private System.Windows.Forms.Label labelLastAccess;
      private System.Windows.Forms.ComboBox comboBoxPortUsage;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.Label labelPortUsage;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.TextBox textBoxSubnetMask;
      private System.Windows.Forms.Label labelSubnetMask;
      private System.Windows.Forms.Button buttonSearchClear;
      private System.Windows.Forms.CheckBox checkBoxUpdate;
      private System.Windows.Forms.Button buttonSearch;
      private System.Windows.Forms.CheckBox checkBoxOverwrite;
      private System.Windows.Forms.CheckBox checkBoxDelete;
      private System.Windows.Forms.Label labelUpdate;
      private System.Windows.Forms.Label labelOverwrite;
      private System.Windows.Forms.Label labelDelete;
      private System.Windows.Forms.Label labelSecurePort;
      private System.Windows.Forms.TextBox textBoxSecurePort;
      private System.Windows.Forms.Label labelPort;
      private System.Windows.Forms.Label labelAddress;
      private System.Windows.Forms.Label labelAlias;
      private System.Windows.Forms.Label labelAeTitle;
      private System.Windows.Forms.TextBox textBoxPort;
      private System.Windows.Forms.TextBox textBoxAddress;
      private System.Windows.Forms.TextBox textBoxAlias;
      private System.Windows.Forms.TextBox textBoxAeTitle;
      private System.Windows.Forms.GroupBox groupBoxClients;
      public System.Windows.Forms.ToolStrip clientToolStrip;
      //private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnQuery;
      //private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnRetrieve;
      //private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnCreate;
      //private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnOverwrite;
      //private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnUpdate;
      //private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnDelete;
   }
}
