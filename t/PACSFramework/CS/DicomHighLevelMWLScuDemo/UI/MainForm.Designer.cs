using Dicom.UI;

namespace DicomDemo
{
   partial class MainForm
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

      #region Windows Form Designer generated code

      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         this.components = new System.ComponentModel.Container();
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
         this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.searchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
         this.clearLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
         this.saveAsDicomFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
         this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.showHelpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._menuStrip = new System.Windows.Forms.MenuStrip();
         this.dICOMSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.mPPSTemplateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.serversToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.mWLScpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.toolStripComboBoxMWLScp = new System.Windows.Forms.ToolStripComboBox();
         this.mPPSScpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.toolStripComboBoxMPPSScp = new System.Windows.Forms.ToolStripComboBox();
         this.storeScpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.toolStripComboBoxStoreScp = new System.Windows.Forms.ToolStripComboBox();
         this._contextMenuStripLog = new System.Windows.Forms.ContextMenuStrip(this.components);
         this._toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
         this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
         this.statusStrip1 = new System.Windows.Forms.StatusStrip();
         this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
         this.toolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
         this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
         this.toolStripStatusLabelMWL = new System.Windows.Forms.ToolStripStatusLabel();
         this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
         this.toolStripStatusLabelMPPS = new System.Windows.Forms.ToolStripStatusLabel();
         this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
         this.toolStripStatusLabelStore = new System.Windows.Forms.ToolStripStatusLabel();
         this._splitContainer3 = new System.Windows.Forms.SplitContainer();
         this.groupBox2 = new System.Windows.Forms.GroupBox();
         this._listViewWorkItems = new DicomDemo.MyListView();
         this._columnAccessionNum = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this._columnHeaderPatientId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this._columnHeaderPatientName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this._columnHeaderBirthdate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this._columnHeaderGender = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this._columnHeaderScheduledStartDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this.columnHeaderModality = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this.columnHeaderScheduledStationAe = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this.columnHeaderDescription = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this._label2 = new System.Windows.Forms.Label();
         this.panel1 = new System.Windows.Forms.Panel();
         this.buttonCreateMPPS = new Dicom.UI.SplitButton();
         this.contextMenuStripMPPS = new System.Windows.Forms.ContextMenuStrip(this.components);
         this.panel3 = new System.Windows.Forms.Panel();
         this.groupBox3 = new System.Windows.Forms.GroupBox();
         this._propertyGrid = new System.Windows.Forms.PropertyGrid();
         this.panel4 = new System.Windows.Forms.Panel();
         this.buttonCancel = new System.Windows.Forms.Button();
         this.buttonSearch = new Dicom.UI.SplitButton();
         this.contextMenuStripMWL = new System.Windows.Forms.ContextMenuStrip(this.components);
         this.splitContainer1 = new System.Windows.Forms.SplitContainer();
         this.splitContainer2 = new System.Windows.Forms.SplitContainer();
         this.groupBox1 = new System.Windows.Forms.GroupBox();
         this.listViewInProgress = new System.Windows.Forms.ListView();
         this.columnHeaderAccessionNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this.columnHeaderPatientId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this.columnHeaderPPSModality = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this.columnHeaderPPSStartDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this.columnHeaderPPSStartTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this.columnHeaderPPSId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this.columnHeaderPerformedStationAeTile = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this.columnHeaderPerformedStationName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this.label1 = new System.Windows.Forms.Label();
         this.panel2 = new System.Windows.Forms.Panel();
         this.buttonCompleteMPPS = new System.Windows.Forms.Button();
         this.buttonCancelMPPS = new System.Windows.Forms.Button();
         this.buttonAddImage = new Dicom.UI.SplitButton();
         this.contextMenuStripStore = new System.Windows.Forms.ContextMenuStrip(this.components);
         this.buttonSetMPPS = new System.Windows.Forms.Button();
         this._richTextBoxLog = new System.Windows.Forms.RichTextBox();
         this._label5 = new System.Windows.Forms.Label();
         this._splitContainer1 = new System.Windows.Forms.SplitContainer();
         this._menuStrip.SuspendLayout();
         this._contextMenuStripLog.SuspendLayout();
         this.statusStrip1.SuspendLayout();
         this._splitContainer3.Panel1.SuspendLayout();
         this._splitContainer3.Panel2.SuspendLayout();
         this._splitContainer3.SuspendLayout();
         this.groupBox2.SuspendLayout();
         this.panel1.SuspendLayout();
         this.panel3.SuspendLayout();
         this.groupBox3.SuspendLayout();
         this.panel4.SuspendLayout();
         this.splitContainer1.Panel1.SuspendLayout();
         this.splitContainer1.Panel2.SuspendLayout();
         this.splitContainer1.SuspendLayout();
         this.splitContainer2.Panel1.SuspendLayout();
         this.splitContainer2.SuspendLayout();
         this.groupBox1.SuspendLayout();
         this.panel2.SuspendLayout();
         this._splitContainer1.Panel2.SuspendLayout();
         this._splitContainer1.SuspendLayout();
         this.SuspendLayout();
         // 
         // fileToolStripMenuItem
         // 
         this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.searchToolStripMenuItem,
            this.toolStripSeparator1,
            this.clearLogToolStripMenuItem,
            this.toolStripSeparator3,
            this.saveAsDicomFileToolStripMenuItem,
            this.toolStripSeparator2,
            this.exitToolStripMenuItem});
         this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
         this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
         this.fileToolStripMenuItem.Text = "&File";
         // 
         // searchToolStripMenuItem
         // 
         this.searchToolStripMenuItem.Name = "searchToolStripMenuItem";
         this.searchToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
         this.searchToolStripMenuItem.Text = "&Search";
         this.searchToolStripMenuItem.Click += new System.EventHandler(this.searchToolStripMenuItem_Click);
         // 
         // toolStripSeparator1
         // 
         this.toolStripSeparator1.Name = "toolStripSeparator1";
         this.toolStripSeparator1.Size = new System.Drawing.Size(167, 6);
         // 
         // clearLogToolStripMenuItem
         // 
         this.clearLogToolStripMenuItem.Name = "clearLogToolStripMenuItem";
         this.clearLogToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
         this.clearLogToolStripMenuItem.Text = "&Clear Log";
         this.clearLogToolStripMenuItem.Click += new System.EventHandler(this.clearLogToolStripMenuItem_Click);
         // 
         // toolStripSeparator3
         // 
         this.toolStripSeparator3.Name = "toolStripSeparator3";
         this.toolStripSeparator3.Size = new System.Drawing.Size(167, 6);
         // 
         // saveAsDicomFileToolStripMenuItem
         // 
         this.saveAsDicomFileToolStripMenuItem.Name = "saveAsDicomFileToolStripMenuItem";
         this.saveAsDicomFileToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
         this.saveAsDicomFileToolStripMenuItem.Text = "&Save DICOM File...";
         this.saveAsDicomFileToolStripMenuItem.Click += new System.EventHandler(this.saveAsDicomFileToolStripMenuItem_Click);
         // 
         // toolStripSeparator2
         // 
         this.toolStripSeparator2.Name = "toolStripSeparator2";
         this.toolStripSeparator2.Size = new System.Drawing.Size(167, 6);
         // 
         // exitToolStripMenuItem
         // 
         this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
         this.exitToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
         this.exitToolStripMenuItem.Text = "&Exit";
         this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
         // 
         // helpToolStripMenuItem
         // 
         this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showHelpToolStripMenuItem,
            this.aboutToolStripMenuItem});
         this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
         this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
         this.helpToolStripMenuItem.Text = "&Help";
         // 
         // showHelpToolStripMenuItem
         // 
         this.showHelpToolStripMenuItem.Name = "showHelpToolStripMenuItem";
         this.showHelpToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
         this.showHelpToolStripMenuItem.Text = "Show &Help...";
         this.showHelpToolStripMenuItem.Click += new System.EventHandler(this.showHelpToolStripMenuItem_Click);
         // 
         // aboutToolStripMenuItem
         // 
         this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
         this.aboutToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
         this.aboutToolStripMenuItem.Text = "&About...";
         this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
         // 
         // _menuStrip
         // 
         this._menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.dICOMSettingsToolStripMenuItem,
            this.mPPSTemplateToolStripMenuItem,
            this.serversToolStripMenuItem,
            this.helpToolStripMenuItem});
         this._menuStrip.Location = new System.Drawing.Point(0, 0);
         this._menuStrip.Name = "_menuStrip";
         this._menuStrip.Size = new System.Drawing.Size(1276, 24);
         this._menuStrip.TabIndex = 0;
         this._menuStrip.Text = "menuStrip1";
         // 
         // dICOMSettingsToolStripMenuItem
         // 
         this.dICOMSettingsToolStripMenuItem.Name = "dICOMSettingsToolStripMenuItem";
         this.dICOMSettingsToolStripMenuItem.Size = new System.Drawing.Size(112, 20);
         this.dICOMSettingsToolStripMenuItem.Text = "&DICOM Settings...";
         this.dICOMSettingsToolStripMenuItem.Click += new System.EventHandler(this.Options_Click);
         // 
         // mPPSTemplateToolStripMenuItem
         // 
         this.mPPSTemplateToolStripMenuItem.Name = "mPPSTemplateToolStripMenuItem";
         this.mPPSTemplateToolStripMenuItem.Size = new System.Drawing.Size(135, 20);
         this.mPPSTemplateToolStripMenuItem.Text = "&Edit MPPS Template...";
         this.mPPSTemplateToolStripMenuItem.Click += new System.EventHandler(this.buttonEditMPPSDataset_Click);
         // 
         // serversToolStripMenuItem
         // 
         this.serversToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mWLScpToolStripMenuItem,
            this.mPPSScpToolStripMenuItem,
            this.storeScpToolStripMenuItem});
         this.serversToolStripMenuItem.Name = "serversToolStripMenuItem";
         this.serversToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
         this.serversToolStripMenuItem.Text = "&Servers";
         // 
         // mWLScpToolStripMenuItem
         // 
         this.mWLScpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripComboBoxMWLScp});
         this.mWLScpToolStripMenuItem.Name = "mWLScpToolStripMenuItem";
         this.mWLScpToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
         this.mWLScpToolStripMenuItem.Text = "&MWL Scp";
         // 
         // toolStripComboBoxMWLScp
         // 
         this.toolStripComboBoxMWLScp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.toolStripComboBoxMWLScp.Name = "toolStripComboBoxMWLScp";
         this.toolStripComboBoxMWLScp.Size = new System.Drawing.Size(121, 23);
         this.toolStripComboBoxMWLScp.SelectedIndexChanged += new System.EventHandler(this._comboBoxMwl_SelectionChangeCommitted);
         // 
         // mPPSScpToolStripMenuItem
         // 
         this.mPPSScpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripComboBoxMPPSScp});
         this.mPPSScpToolStripMenuItem.Name = "mPPSScpToolStripMenuItem";
         this.mPPSScpToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
         this.mPPSScpToolStripMenuItem.Text = "M&PPS Scp";
         // 
         // toolStripComboBoxMPPSScp
         // 
         this.toolStripComboBoxMPPSScp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.toolStripComboBoxMPPSScp.Name = "toolStripComboBoxMPPSScp";
         this.toolStripComboBoxMPPSScp.Size = new System.Drawing.Size(121, 23);
         this.toolStripComboBoxMPPSScp.SelectedIndexChanged += new System.EventHandler(this._comboBoxMpps_SelectionChangeCommitted);
         // 
         // storeScpToolStripMenuItem
         // 
         this.storeScpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripComboBoxStoreScp});
         this.storeScpToolStripMenuItem.Name = "storeScpToolStripMenuItem";
         this.storeScpToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
         this.storeScpToolStripMenuItem.Text = "&Store Scp";
         // 
         // toolStripComboBoxStoreScp
         // 
         this.toolStripComboBoxStoreScp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.toolStripComboBoxStoreScp.Name = "toolStripComboBoxStoreScp";
         this.toolStripComboBoxStoreScp.Size = new System.Drawing.Size(121, 23);
         this.toolStripComboBoxStoreScp.SelectedIndexChanged += new System.EventHandler(this._comboBoxStore_SelectionChangeCommitted);
         // 
         // _contextMenuStripLog
         // 
         this._contextMenuStripLog.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._toolStripMenuItem1});
         this._contextMenuStripLog.Name = "_contextMenuStripLog";
         this._contextMenuStripLog.Size = new System.Drawing.Size(125, 26);
         // 
         // _toolStripMenuItem1
         // 
         this._toolStripMenuItem1.Name = "_toolStripMenuItem1";
         this._toolStripMenuItem1.Size = new System.Drawing.Size(124, 22);
         this._toolStripMenuItem1.Text = "&Clear Log";
         this._toolStripMenuItem1.Click += new System.EventHandler(this._toolStripMenuItem1_Click);
         // 
         // openFileDialog
         // 
         this.openFileDialog.Filter = "DICOM|*.dcm;*.dic|All Files|*.*";
         this.openFileDialog.Multiselect = true;
         this.openFileDialog.Title = "Select Files To Add To MPPS";
         // 
         // statusStrip1
         // 
         this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripProgressBar,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabelMWL,
            this.toolStripStatusLabel3,
            this.toolStripStatusLabelMPPS,
            this.toolStripStatusLabel4,
            this.toolStripStatusLabelStore});
         this.statusStrip1.Location = new System.Drawing.Point(0, 710);
         this.statusStrip1.Name = "statusStrip1";
         this.statusStrip1.Size = new System.Drawing.Size(1276, 24);
         this.statusStrip1.TabIndex = 2;
         this.statusStrip1.Text = "statusStrip1";
         // 
         // toolStripStatusLabel1
         // 
         this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
         this.toolStripStatusLabel1.Size = new System.Drawing.Size(600, 19);
         this.toolStripStatusLabel1.Spring = true;
         // 
         // toolStripProgressBar
         // 
         this.toolStripProgressBar.Name = "toolStripProgressBar";
         this.toolStripProgressBar.Size = new System.Drawing.Size(250, 18);
         this.toolStripProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
         this.toolStripProgressBar.Visible = false;
         // 
         // toolStripStatusLabel2
         // 
         this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
         this.toolStripStatusLabel2.Size = new System.Drawing.Size(73, 19);
         this.toolStripStatusLabel2.Text = "MWL Server:";
         // 
         // toolStripStatusLabelMWL
         // 
         this.toolStripStatusLabelMWL.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
         this.toolStripStatusLabelMWL.BorderStyle = System.Windows.Forms.Border3DStyle.Adjust;
         this.toolStripStatusLabelMWL.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
         this.toolStripStatusLabelMWL.Name = "toolStripStatusLabelMWL";
         this.toolStripStatusLabelMWL.Size = new System.Drawing.Size(153, 19);
         this.toolStripStatusLabelMWL.Text = "toolStripStatusLabelMWL";
         // 
         // toolStripStatusLabel3
         // 
         this.toolStripStatusLabel3.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
         this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
         this.toolStripStatusLabel3.Size = new System.Drawing.Size(80, 19);
         this.toolStripStatusLabel3.Text = "MPPS Server:";
         // 
         // toolStripStatusLabelMPPS
         // 
         this.toolStripStatusLabelMPPS.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
         this.toolStripStatusLabelMPPS.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
         this.toolStripStatusLabelMPPS.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
         this.toolStripStatusLabelMPPS.Name = "toolStripStatusLabelMPPS";
         this.toolStripStatusLabelMPPS.Size = new System.Drawing.Size(156, 19);
         this.toolStripStatusLabelMPPS.Text = "toolStripStatusLabelMPPS";
         // 
         // toolStripStatusLabel4
         // 
         this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
         this.toolStripStatusLabel4.Size = new System.Drawing.Size(72, 19);
         this.toolStripStatusLabel4.Text = "Store Server:";
         // 
         // toolStripStatusLabelStore
         // 
         this.toolStripStatusLabelStore.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
         this.toolStripStatusLabelStore.Name = "toolStripStatusLabelStore";
         this.toolStripStatusLabelStore.Size = new System.Drawing.Size(127, 19);
         this.toolStripStatusLabelStore.Text = "toolStripStatusLabel4";
         // 
         // _splitContainer3
         // 
         this._splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
         this._splitContainer3.Location = new System.Drawing.Point(0, 0);
         this._splitContainer3.Name = "_splitContainer3";
         this._splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
         // 
         // _splitContainer3.Panel1
         // 
         this._splitContainer3.Panel1.Controls.Add(this.groupBox2);
         this._splitContainer3.Panel1.Controls.Add(this.panel3);
         // 
         // _splitContainer3.Panel2
         // 
         this._splitContainer3.Panel2.Controls.Add(this.splitContainer1);
         this._splitContainer3.Size = new System.Drawing.Size(1276, 686);
         this._splitContainer3.SplitterDistance = 231;
         this._splitContainer3.TabIndex = 0;
         // 
         // groupBox2
         // 
         this.groupBox2.Controls.Add(this._listViewWorkItems);
         this.groupBox2.Controls.Add(this._label2);
         this.groupBox2.Controls.Add(this.panel1);
         this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
         this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.groupBox2.Location = new System.Drawing.Point(274, 0);
         this.groupBox2.Name = "groupBox2";
         this.groupBox2.Size = new System.Drawing.Size(1002, 231);
         this.groupBox2.TabIndex = 7;
         this.groupBox2.TabStop = false;
         this.groupBox2.Text = "2.  Create MPPS from worklist item";
         // 
         // _listViewWorkItems
         // 
         this._listViewWorkItems.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this._columnAccessionNum,
            this._columnHeaderPatientId,
            this._columnHeaderPatientName,
            this._columnHeaderBirthdate,
            this._columnHeaderGender,
            this._columnHeaderScheduledStartDate,
            this.columnHeaderModality,
            this.columnHeaderScheduledStationAe,
            this.columnHeaderDescription});
         this._listViewWorkItems.Dock = System.Windows.Forms.DockStyle.Fill;
         this._listViewWorkItems.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this._listViewWorkItems.FullRowSelect = true;
         this._listViewWorkItems.GridLines = true;
         this._listViewWorkItems.HideSelection = false;
         this._listViewWorkItems.Location = new System.Drawing.Point(3, 86);
         this._listViewWorkItems.MultiSelect = false;
         this._listViewWorkItems.Name = "_listViewWorkItems";
         this._listViewWorkItems.Size = new System.Drawing.Size(996, 142);
         this._listViewWorkItems.StartedMPPS = ((System.Collections.Generic.List<System.Windows.Forms.ListViewItem>)(resources.GetObject("_listViewWorkItems.StartedMPPS")));
         this._listViewWorkItems.TabIndex = 1;
         this._listViewWorkItems.UseCompatibleStateImageBehavior = false;
         this._listViewWorkItems.View = System.Windows.Forms.View.Details;
         this._listViewWorkItems.SelectedIndexChanged += new System.EventHandler(this._listViewWorkItems_SelectedIndexChanged);
         this._listViewWorkItems.DoubleClick += new System.EventHandler(this._listViewWorkItems_DoubleClick);
         this._listViewWorkItems.Resize += new System.EventHandler(this._listViewWorkItems_Resize);
         // 
         // _columnAccessionNum
         // 
         this._columnAccessionNum.Text = "Accession Number";
         this._columnAccessionNum.Width = 125;
         // 
         // _columnHeaderPatientId
         // 
         this._columnHeaderPatientId.Text = "Patient ID";
         // 
         // _columnHeaderPatientName
         // 
         this._columnHeaderPatientName.Text = "Patient Name";
         this._columnHeaderPatientName.Width = 125;
         // 
         // _columnHeaderBirthdate
         // 
         this._columnHeaderBirthdate.Text = "Birthdate";
         this._columnHeaderBirthdate.Width = 84;
         // 
         // _columnHeaderGender
         // 
         this._columnHeaderGender.Text = "Gender";
         // 
         // _columnHeaderScheduledStartDate
         // 
         this._columnHeaderScheduledStartDate.Text = "Scheduled Start Date";
         this._columnHeaderScheduledStartDate.Width = 75;
         // 
         // columnHeaderModality
         // 
         this.columnHeaderModality.Text = "Modality";
         // 
         // columnHeaderScheduledStationAe
         // 
         this.columnHeaderScheduledStationAe.Text = "Scheduled Station AE";
         this.columnHeaderScheduledStationAe.Width = 120;
         // 
         // columnHeaderDescription
         // 
         this.columnHeaderDescription.Text = "Scheduled Procedure Step Description";
         this.columnHeaderDescription.Width = 197;
         // 
         // _label2
         // 
         this._label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
         this._label2.Dock = System.Windows.Forms.DockStyle.Top;
         this._label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this._label2.Location = new System.Drawing.Point(3, 68);
         this._label2.Name = "_label2";
         this._label2.Size = new System.Drawing.Size(996, 18);
         this._label2.TabIndex = 0;
         this._label2.Text = "Worklist Items Found (Double click to see worklist dataset): ";
         // 
         // panel1
         // 
         this.panel1.Controls.Add(this.buttonCreateMPPS);
         this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
         this.panel1.Location = new System.Drawing.Point(3, 16);
         this.panel1.Name = "panel1";
         this.panel1.Size = new System.Drawing.Size(996, 52);
         this.panel1.TabIndex = 5;
         // 
         // buttonCreateMPPS
         // 
         this.buttonCreateMPPS.AutoSize = true;
         this.buttonCreateMPPS.ContextMenuStrip = this.contextMenuStripMPPS;
         this.buttonCreateMPPS.Enabled = false;
         this.buttonCreateMPPS.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.buttonCreateMPPS.Image = global::DicomDemo.Properties.Resources.StartMPPS;
         this.buttonCreateMPPS.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
         this.buttonCreateMPPS.Location = new System.Drawing.Point(0, 0);
         this.buttonCreateMPPS.Name = "buttonCreateMPPS";
         this.buttonCreateMPPS.Size = new System.Drawing.Size(131, 51);
         this.buttonCreateMPPS.TabIndex = 0;
         this.buttonCreateMPPS.Text = "Create MPPS...";
         this.buttonCreateMPPS.UseVisualStyleBackColor = true;
         this.buttonCreateMPPS.Click += new System.EventHandler(this.buttonCreateMPPS_Click);
         // 
         // contextMenuStripMPPS
         // 
         this.contextMenuStripMPPS.Name = "contextMenuStripMPPS";
         this.contextMenuStripMPPS.Size = new System.Drawing.Size(61, 4);
         this.contextMenuStripMPPS.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStripMPPS_Opening);
         // 
         // panel3
         // 
         this.panel3.Controls.Add(this.groupBox3);
         this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
         this.panel3.Location = new System.Drawing.Point(0, 0);
         this.panel3.Name = "panel3";
         this.panel3.Size = new System.Drawing.Size(274, 231);
         this.panel3.TabIndex = 6;
         // 
         // groupBox3
         // 
         this.groupBox3.Controls.Add(this._propertyGrid);
         this.groupBox3.Controls.Add(this.panel4);
         this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
         this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.groupBox3.Location = new System.Drawing.Point(0, 0);
         this.groupBox3.Name = "groupBox3";
         this.groupBox3.Size = new System.Drawing.Size(274, 231);
         this.groupBox3.TabIndex = 3;
         this.groupBox3.TabStop = false;
         this.groupBox3.Text = "1.  Search for a work list item";
         // 
         // _propertyGrid
         // 
         this._propertyGrid.Dock = System.Windows.Forms.DockStyle.Fill;
         this._propertyGrid.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this._propertyGrid.HelpVisible = false;
         this._propertyGrid.Location = new System.Drawing.Point(3, 68);
         this._propertyGrid.Name = "_propertyGrid";
         this._propertyGrid.PropertySort = System.Windows.Forms.PropertySort.Categorized;
         this._propertyGrid.Size = new System.Drawing.Size(268, 160);
         this._propertyGrid.TabIndex = 2;
         // 
         // panel4
         // 
         this.panel4.Controls.Add(this.buttonCancel);
         this.panel4.Controls.Add(this.buttonSearch);
         this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
         this.panel4.Location = new System.Drawing.Point(3, 16);
         this.panel4.Name = "panel4";
         this.panel4.Size = new System.Drawing.Size(268, 52);
         this.panel4.TabIndex = 6;
         // 
         // buttonCancel
         // 
         this.buttonCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.buttonCancel.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
         this.buttonCancel.Location = new System.Drawing.Point(137, 0);
         this.buttonCancel.Name = "buttonCancel";
         this.buttonCancel.Size = new System.Drawing.Size(131, 51);
         this.buttonCancel.TabIndex = 1;
         this.buttonCancel.Text = "Cancel";
         this.buttonCancel.UseVisualStyleBackColor = true;
         this.buttonCancel.Click += new System.EventHandler(this._buttonCancel_Click);
         // 
         // buttonSearch
         // 
         this.buttonSearch.AutoSize = true;
         this.buttonSearch.ContextMenuStrip = this.contextMenuStripMWL;
         this.buttonSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.buttonSearch.Image = global::DicomDemo.Properties.Resources.Search;
         this.buttonSearch.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
         this.buttonSearch.Location = new System.Drawing.Point(0, 0);
         this.buttonSearch.Name = "buttonSearch";
         this.buttonSearch.Size = new System.Drawing.Size(131, 51);
         this.buttonSearch.TabIndex = 0;
         this.buttonSearch.Text = "Search";
         this.buttonSearch.UseVisualStyleBackColor = true;
         this.buttonSearch.Click += new System.EventHandler(this._buttonSearch_Click);
         // 
         // contextMenuStripMWL
         // 
         this.contextMenuStripMWL.Name = "contextMenuStripMPPS";
         this.contextMenuStripMWL.Size = new System.Drawing.Size(61, 4);
         this.contextMenuStripMWL.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStripMWL_Opening);
         // 
         // splitContainer1
         // 
         this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
         this.splitContainer1.Location = new System.Drawing.Point(0, 0);
         this.splitContainer1.Name = "splitContainer1";
         this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
         // 
         // splitContainer1.Panel1
         // 
         this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
         // 
         // splitContainer1.Panel2
         // 
         this.splitContainer1.Panel2.Controls.Add(this._richTextBoxLog);
         this.splitContainer1.Panel2.Controls.Add(this._label5);
         this.splitContainer1.Size = new System.Drawing.Size(1276, 451);
         this.splitContainer1.SplitterDistance = 204;
         this.splitContainer1.TabIndex = 0;
         // 
         // splitContainer2
         // 
         this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
         this.splitContainer2.Location = new System.Drawing.Point(0, 0);
         this.splitContainer2.Name = "splitContainer2";
         // 
         // splitContainer2.Panel1
         // 
         this.splitContainer2.Panel1.Controls.Add(this.groupBox1);
         this.splitContainer2.Panel2Collapsed = true;
         this.splitContainer2.Size = new System.Drawing.Size(1276, 204);
         this.splitContainer2.SplitterDistance = 422;
         this.splitContainer2.TabIndex = 0;
         // 
         // groupBox1
         // 
         this.groupBox1.Controls.Add(this.listViewInProgress);
         this.groupBox1.Controls.Add(this.label1);
         this.groupBox1.Controls.Add(this.panel2);
         this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
         this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.groupBox1.Location = new System.Drawing.Point(0, 0);
         this.groupBox1.Name = "groupBox1";
         this.groupBox1.Size = new System.Drawing.Size(1276, 204);
         this.groupBox1.TabIndex = 9;
         this.groupBox1.TabStop = false;
         this.groupBox1.Text = "3.  Work with in progress MPPS";
         // 
         // listViewInProgress
         // 
         this.listViewInProgress.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderAccessionNumber,
            this.columnHeaderPatientId,
            this.columnHeaderPPSModality,
            this.columnHeaderPPSStartDate,
            this.columnHeaderPPSStartTime,
            this.columnHeaderPPSId,
            this.columnHeaderPerformedStationAeTile,
            this.columnHeaderPerformedStationName});
         this.listViewInProgress.Dock = System.Windows.Forms.DockStyle.Fill;
         this.listViewInProgress.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.listViewInProgress.FullRowSelect = true;
         this.listViewInProgress.GridLines = true;
         this.listViewInProgress.HideSelection = false;
         this.listViewInProgress.Location = new System.Drawing.Point(3, 86);
         this.listViewInProgress.MultiSelect = false;
         this.listViewInProgress.Name = "listViewInProgress";
         this.listViewInProgress.Size = new System.Drawing.Size(1270, 115);
         this.listViewInProgress.TabIndex = 6;
         this.listViewInProgress.UseCompatibleStateImageBehavior = false;
         this.listViewInProgress.View = System.Windows.Forms.View.Details;
         this.listViewInProgress.SelectedIndexChanged += new System.EventHandler(this.listViewInProgress_SelectedIndexChanged);
         this.listViewInProgress.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listViewInProgress_KeyDown);
         // 
         // columnHeaderAccessionNumber
         // 
         this.columnHeaderAccessionNumber.Text = "Accession Number";
         this.columnHeaderAccessionNumber.Width = 125;
         // 
         // columnHeaderPatientId
         // 
         this.columnHeaderPatientId.Text = "Patient ID";
         // 
         // columnHeaderPPSModality
         // 
         this.columnHeaderPPSModality.Text = "Modality";
         this.columnHeaderPPSModality.Width = 84;
         // 
         // columnHeaderPPSStartDate
         // 
         this.columnHeaderPPSStartDate.Text = "PPS Start Date";
         // 
         // columnHeaderPPSStartTime
         // 
         this.columnHeaderPPSStartTime.Text = "PPS Start Time";
         this.columnHeaderPPSStartTime.Width = 75;
         // 
         // columnHeaderPPSId
         // 
         this.columnHeaderPPSId.Text = "PPS Id";
         // 
         // columnHeaderPerformedStationAeTile
         // 
         this.columnHeaderPerformedStationAeTile.Text = "Performed Station AE";
         this.columnHeaderPerformedStationAeTile.Width = 120;
         // 
         // columnHeaderPerformedStationName
         // 
         this.columnHeaderPerformedStationName.Text = "Performed Station Name";
         this.columnHeaderPerformedStationName.Width = 197;
         // 
         // label1
         // 
         this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
         this.label1.ContextMenuStrip = this._contextMenuStripLog;
         this.label1.Dock = System.Windows.Forms.DockStyle.Top;
         this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label1.Location = new System.Drawing.Point(3, 68);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(1270, 18);
         this.label1.TabIndex = 5;
         this.label1.Text = "In Progress MPPS:";
         // 
         // panel2
         // 
         this.panel2.Controls.Add(this.buttonCompleteMPPS);
         this.panel2.Controls.Add(this.buttonCancelMPPS);
         this.panel2.Controls.Add(this.buttonAddImage);
         this.panel2.Controls.Add(this.buttonSetMPPS);
         this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
         this.panel2.Location = new System.Drawing.Point(3, 16);
         this.panel2.Name = "panel2";
         this.panel2.Size = new System.Drawing.Size(1270, 52);
         this.panel2.TabIndex = 8;
         // 
         // buttonCompleteMPPS
         // 
         this.buttonCompleteMPPS.Enabled = false;
         this.buttonCompleteMPPS.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.buttonCompleteMPPS.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
         this.buttonCompleteMPPS.Location = new System.Drawing.Point(277, 1);
         this.buttonCompleteMPPS.Name = "buttonCompleteMPPS";
         this.buttonCompleteMPPS.Size = new System.Drawing.Size(131, 51);
         this.buttonCompleteMPPS.TabIndex = 3;
         this.buttonCompleteMPPS.Text = "Complete MPPS ...";
         this.buttonCompleteMPPS.UseVisualStyleBackColor = true;
         this.buttonCompleteMPPS.Click += new System.EventHandler(this.buttonCompleteMPPS_Click);
         // 
         // buttonCancelMPPS
         // 
         this.buttonCancelMPPS.Enabled = false;
         this.buttonCancelMPPS.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.buttonCancelMPPS.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
         this.buttonCancelMPPS.Location = new System.Drawing.Point(140, 0);
         this.buttonCancelMPPS.Name = "buttonCancelMPPS";
         this.buttonCancelMPPS.Size = new System.Drawing.Size(131, 51);
         this.buttonCancelMPPS.TabIndex = 2;
         this.buttonCancelMPPS.Text = "Discontinue MPPS ...";
         this.buttonCancelMPPS.UseVisualStyleBackColor = true;
         this.buttonCancelMPPS.Click += new System.EventHandler(this.buttonCancelMPPS_Click);
         // 
         // buttonAddImage
         // 
         this.buttonAddImage.AutoSize = true;
         this.buttonAddImage.ContextMenuStrip = this.contextMenuStripStore;
         this.buttonAddImage.Enabled = false;
         this.buttonAddImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.buttonAddImage.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
         this.buttonAddImage.Location = new System.Drawing.Point(414, 1);
         this.buttonAddImage.Name = "buttonAddImage";
         this.buttonAddImage.Size = new System.Drawing.Size(131, 51);
         this.buttonAddImage.TabIndex = 1;
         this.buttonAddImage.Text = "Add DICOM...";
         this.buttonAddImage.UseVisualStyleBackColor = true;
         this.buttonAddImage.Click += new System.EventHandler(this.toolStripButtonAddImage_Click);
         // 
         // contextMenuStripStore
         // 
         this.contextMenuStripStore.Name = "contextMenuStripMPPS";
         this.contextMenuStripStore.Size = new System.Drawing.Size(61, 4);
         this.contextMenuStripStore.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStripStore_Opening);
         // 
         // buttonSetMPPS
         // 
         this.buttonSetMPPS.Enabled = false;
         this.buttonSetMPPS.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.buttonSetMPPS.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
         this.buttonSetMPPS.Location = new System.Drawing.Point(3, 0);
         this.buttonSetMPPS.Name = "buttonSetMPPS";
         this.buttonSetMPPS.Size = new System.Drawing.Size(131, 51);
         this.buttonSetMPPS.TabIndex = 0;
         this.buttonSetMPPS.Text = "Update MPPS...";
         this.buttonSetMPPS.UseVisualStyleBackColor = true;
         this.buttonSetMPPS.Click += new System.EventHandler(this.toolStripButtonSet_Click);
         // 
         // _richTextBoxLog
         // 
         this._richTextBoxLog.ContextMenuStrip = this._contextMenuStripLog;
         this._richTextBoxLog.Dock = System.Windows.Forms.DockStyle.Fill;
         this._richTextBoxLog.Location = new System.Drawing.Point(0, 23);
         this._richTextBoxLog.Name = "_richTextBoxLog";
         this._richTextBoxLog.ReadOnly = true;
         this._richTextBoxLog.Size = new System.Drawing.Size(1276, 220);
         this._richTextBoxLog.TabIndex = 3;
         this._richTextBoxLog.Text = "";
         this._richTextBoxLog.WordWrap = false;
         // 
         // _label5
         // 
         this._label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
         this._label5.ContextMenuStrip = this._contextMenuStripLog;
         this._label5.Dock = System.Windows.Forms.DockStyle.Top;
         this._label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this._label5.Location = new System.Drawing.Point(0, 0);
         this._label5.Name = "_label5";
         this._label5.Size = new System.Drawing.Size(1276, 23);
         this._label5.TabIndex = 4;
         this._label5.Text = "Log: (Right-click to clear)";
         // 
         // _splitContainer1
         // 
         this._splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
         this._splitContainer1.Location = new System.Drawing.Point(0, 24);
         this._splitContainer1.Name = "_splitContainer1";
         this._splitContainer1.Panel1Collapsed = true;
         // 
         // _splitContainer1.Panel2
         // 
         this._splitContainer1.Panel2.Controls.Add(this._splitContainer3);
         this._splitContainer1.Size = new System.Drawing.Size(1276, 686);
         this._splitContainer1.SplitterDistance = 417;
         this._splitContainer1.TabIndex = 1;
         // 
         // MainForm
         // 
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
         this.ClientSize = new System.Drawing.Size(1276, 734);
         this.Controls.Add(this._splitContainer1);
         this.Controls.Add(this._menuStrip);
         this.Controls.Add(this.statusStrip1);
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.MainMenuStrip = this._menuStrip;
         this.MinimumSize = new System.Drawing.Size(640, 480);
         this.Name = "MainForm";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         this.Text = "LEADTOOLS High Level DICOM MWL & MPPS SCU Demo - C#";
         this.Activated += new System.EventHandler(this.MainForm_Activated);
         this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
         this.Load += new System.EventHandler(this.MainForm_Load);
         this._menuStrip.ResumeLayout(false);
         this._menuStrip.PerformLayout();
         this._contextMenuStripLog.ResumeLayout(false);
         this.statusStrip1.ResumeLayout(false);
         this.statusStrip1.PerformLayout();
         this._splitContainer3.Panel1.ResumeLayout(false);
         this._splitContainer3.Panel2.ResumeLayout(false);
         this._splitContainer3.ResumeLayout(false);
         this.groupBox2.ResumeLayout(false);
         this.panel1.ResumeLayout(false);
         this.panel1.PerformLayout();
         this.panel3.ResumeLayout(false);
         this.groupBox3.ResumeLayout(false);
         this.panel4.ResumeLayout(false);
         this.panel4.PerformLayout();
         this.splitContainer1.Panel1.ResumeLayout(false);
         this.splitContainer1.Panel2.ResumeLayout(false);
         this.splitContainer1.ResumeLayout(false);
         this.splitContainer2.Panel1.ResumeLayout(false);
         this.splitContainer2.ResumeLayout(false);
         this.groupBox1.ResumeLayout(false);
         this.panel2.ResumeLayout(false);
         this.panel2.PerformLayout();
         this._splitContainer1.Panel2.ResumeLayout(false);
         this._splitContainer1.ResumeLayout(false);
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem clearLogToolStripMenuItem;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
      private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
      private System.Windows.Forms.MenuStrip _menuStrip;
      private System.Windows.Forms.ContextMenuStrip _contextMenuStripLog;
      private System.Windows.Forms.ToolStripMenuItem _toolStripMenuItem1;
      private System.Windows.Forms.ToolStripMenuItem searchToolStripMenuItem;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
      private System.Windows.Forms.ToolStripMenuItem showHelpToolStripMenuItem;
      private System.Windows.Forms.OpenFileDialog openFileDialog;
      private System.Windows.Forms.StatusStrip statusStrip1;
      private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
      private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar;
      private System.Windows.Forms.ToolStripMenuItem serversToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem mWLScpToolStripMenuItem;
      private System.Windows.Forms.ToolStripComboBox toolStripComboBoxMWLScp;
      private System.Windows.Forms.ToolStripMenuItem mPPSScpToolStripMenuItem;
      private System.Windows.Forms.ToolStripComboBox toolStripComboBoxMPPSScp;
      private System.Windows.Forms.ToolStripMenuItem storeScpToolStripMenuItem;
      private System.Windows.Forms.ToolStripComboBox toolStripComboBoxStoreScp;
      private System.Windows.Forms.SplitContainer _splitContainer3;
      private MyListView _listViewWorkItems;
      private System.Windows.Forms.ColumnHeader _columnAccessionNum;
      private System.Windows.Forms.ColumnHeader _columnHeaderPatientId;
      private System.Windows.Forms.ColumnHeader _columnHeaderPatientName;
      private System.Windows.Forms.ColumnHeader _columnHeaderBirthdate;
      private System.Windows.Forms.ColumnHeader _columnHeaderGender;
      private System.Windows.Forms.ColumnHeader _columnHeaderScheduledStartDate;
      private System.Windows.Forms.ColumnHeader columnHeaderModality;
      private System.Windows.Forms.ColumnHeader columnHeaderScheduledStationAe;
      private System.Windows.Forms.ColumnHeader columnHeaderDescription;
      private System.Windows.Forms.Label _label2;
      private System.Windows.Forms.Panel panel1;
      private System.Windows.Forms.PropertyGrid _propertyGrid;
      private SplitButton buttonCreateMPPS;
      private System.Windows.Forms.SplitContainer splitContainer1;
      private System.Windows.Forms.SplitContainer splitContainer2;
      private System.Windows.Forms.ListView listViewInProgress;
      private System.Windows.Forms.ColumnHeader columnHeaderAccessionNumber;
      private System.Windows.Forms.ColumnHeader columnHeaderPatientId;
      private System.Windows.Forms.ColumnHeader columnHeaderPPSModality;
      private System.Windows.Forms.ColumnHeader columnHeaderPPSStartDate;
      private System.Windows.Forms.ColumnHeader columnHeaderPPSStartTime;
      private System.Windows.Forms.ColumnHeader columnHeaderPPSId;
      private System.Windows.Forms.ColumnHeader columnHeaderPerformedStationAeTile;
      private System.Windows.Forms.ColumnHeader columnHeaderPerformedStationName;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Panel panel2;
      private SplitButton buttonAddImage;
      private System.Windows.Forms.Button buttonSetMPPS;
      private System.Windows.Forms.RichTextBox _richTextBoxLog;
      private System.Windows.Forms.Label _label5;
      private System.Windows.Forms.SplitContainer _splitContainer1;
      private System.Windows.Forms.Panel panel3;
      private System.Windows.Forms.GroupBox groupBox1;
      private System.Windows.Forms.GroupBox groupBox2;
      private System.Windows.Forms.GroupBox groupBox3;
      private System.Windows.Forms.Button buttonCompleteMPPS;
      private System.Windows.Forms.Button buttonCancelMPPS;
      private System.Windows.Forms.Panel panel4;
      private System.Windows.Forms.Button buttonCancel;
      private SplitButton buttonSearch;
      private System.Windows.Forms.ContextMenuStrip contextMenuStripMPPS;
      private System.Windows.Forms.ContextMenuStrip contextMenuStripMWL;
      private System.Windows.Forms.ContextMenuStrip contextMenuStripStore;
      private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelMWL;
      private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelMPPS;
      private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelStore;
      private System.Windows.Forms.ToolStripMenuItem dICOMSettingsToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem mPPSTemplateToolStripMenuItem;
      private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
      private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
      private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
      private System.Windows.Forms.ToolStripMenuItem saveAsDicomFileToolStripMenuItem;

   }
}

