// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.IO;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Collections.Specialized;
using Microsoft.Win32;

using Leadtools;
using Leadtools.Dicom;
using Leadtools.Demos;
using Leadtools.DicomDemos;
using Leadtools.Demos.Database;
using System.Collections.Generic;
using System.Threading;

namespace DicomDemo
{
   /// <summary>
   /// Summary description for Form1.
   /// </summary>
   public class MainForm : System.Windows.Forms.Form
   {
      private System.Windows.Forms.StatusBar statusBar1;
      private System.Windows.Forms.StatusBarPanel statusBarPanelConnect;
      private System.Windows.Forms.Panel panelLog;
      private System.Windows.Forms.Splitter splitter1;
      private System.Windows.Forms.Panel panelTabs;
      private System.Windows.Forms.TabControl tabControlServer;
      private System.Windows.Forms.TabPage tabPageDatabase;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.ToolBar toolBarMain;
      private System.Windows.Forms.TabPage tabPageUsers;
      private System.Windows.Forms.ToolBarButton toolBarButtonActive;
      private System.Windows.Forms.ToolBarButton toolBarButtonOptions;
      private System.Windows.Forms.DataGrid dataGridDicom;
      private System.ComponentModel.IContainer components;

      private UsersDB usersDB = new UsersDB(Application.StartupPath + @"\UsersCS.xml");
      private DicomDB dicomDB = new DicomDB(Application.StartupPath + @"\DicomCS.xml");
      private Server dicomServer = new Server();

      public delegate void LogDelegate(string action, string Log);
      public delegate void LogTagDelegate(string action, string Log, object tag);

      private System.Windows.Forms.ToolBarButton toolBarButtonImport;
      private System.Windows.Forms.ImageList imageListToolbar;
      private System.Windows.Forms.TabPage tabPageClients;
      private System.Windows.Forms.DataGrid dataGridUsers;
      private System.Windows.Forms.ToolBarButton toolBarButtonUserAdd;
      private System.Windows.Forms.ToolBarButton toolBarButtonUserModify;
      private System.Windows.Forms.ToolBarButton toolBarButtonDelete;
      private System.Windows.Forms.ToolBarButton toolBarButton1;
      private System.Windows.Forms.ToolBarButton toolBarButton2;
      private System.Windows.Forms.ToolBarButton toolBarButton3;
      private System.Windows.Forms.ToolBarButton toolBarButtonClearLog;
      private System.Windows.Forms.ToolBarButton toolBarButtonDisconnect;
      private System.Windows.Forms.ColumnHeader columnHeader1;
      private System.Windows.Forms.ColumnHeader columnHeader2;
      private System.Windows.Forms.ColumnHeader columnHeader3;
      private System.Windows.Forms.ColumnHeader columnHeader5;
      private System.Windows.Forms.ListView listViewClients;
      private System.Windows.Forms.ToolBarButton toolBarButton4;
      private System.Windows.Forms.ToolBarButton toolBarButtonAssociation;
      private System.Windows.Forms.ListView listViewLog;
      private System.Windows.Forms.ColumnHeader columnHeader6;
      private System.Windows.Forms.ColumnHeader columnHeader7;
      private System.Windows.Forms.ColumnHeader columnHeader8;
      private System.Windows.Forms.ImageList imageListLog;
      private DataGridTableStyle dataGridTableStyleStudies;
      private DataGridTextBoxColumn dataGridTextBoxColumn1;
      private DataGridTableStyle dataGridTableStylePatients;
      private DataGridTextBoxColumn dataGridTextBoxColumn2;
      private DataGridTextBoxColumn dataGridTextBoxColumn3;
      private DataGridTextBoxColumn dataGridTextBoxColumn4;
      private DataGridTextBoxColumn dataGridTextBoxColumn5;
      private DataGridTextBoxColumn dataGridTextBoxColumn6;
      private DataGridTextBoxColumn dataGridTextBoxColumn7;
      private System.Windows.Forms.ToolBarButton toolBarButtonExit;

      public DicomDB DicomData
      {
         get
         {
            return dicomDB;
         }
      }

      public UsersDB UsersData
      {
         get
         {
            return usersDB;
         }
      }

      public MainForm()
      {
         //
         // Required for Windows Form Designer support
         //
         InitializeComponent();
         Logger.Initialize(listViewLog);
      }

      /// <summary>
      /// Clean up any resources being used.
      /// </summary>
      protected override void Dispose(bool disposing)
      {
         if (disposing)
         {
            if (components != null)
            {
               components.Dispose();
               ForceCloseClients();
            }
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
         this.statusBar1 = new System.Windows.Forms.StatusBar();
         this.statusBarPanelConnect = new System.Windows.Forms.StatusBarPanel();
         this.panelLog = new System.Windows.Forms.Panel();
         this.listViewLog = new System.Windows.Forms.ListView();
         this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
         this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
         this.imageListLog = new System.Windows.Forms.ImageList(this.components);
         this.label1 = new System.Windows.Forms.Label();
         this.splitter1 = new System.Windows.Forms.Splitter();
         this.toolBarMain = new System.Windows.Forms.ToolBar();
         this.toolBarButtonImport = new System.Windows.Forms.ToolBarButton();
         this.toolBarButtonActive = new System.Windows.Forms.ToolBarButton();
         this.toolBarButton3 = new System.Windows.Forms.ToolBarButton();
         this.toolBarButtonClearLog = new System.Windows.Forms.ToolBarButton();
         this.toolBarButtonOptions = new System.Windows.Forms.ToolBarButton();
         this.toolBarButton1 = new System.Windows.Forms.ToolBarButton();
         this.toolBarButtonUserAdd = new System.Windows.Forms.ToolBarButton();
         this.toolBarButtonUserModify = new System.Windows.Forms.ToolBarButton();
         this.toolBarButtonDelete = new System.Windows.Forms.ToolBarButton();
         this.toolBarButton4 = new System.Windows.Forms.ToolBarButton();
         this.toolBarButtonAssociation = new System.Windows.Forms.ToolBarButton();
         this.toolBarButtonDisconnect = new System.Windows.Forms.ToolBarButton();
         this.toolBarButton2 = new System.Windows.Forms.ToolBarButton();
         this.toolBarButtonExit = new System.Windows.Forms.ToolBarButton();
         this.imageListToolbar = new System.Windows.Forms.ImageList(this.components);
         this.panelTabs = new System.Windows.Forms.Panel();
         this.tabControlServer = new System.Windows.Forms.TabControl();
         this.tabPageDatabase = new System.Windows.Forms.TabPage();
         this.dataGridDicom = new System.Windows.Forms.DataGrid();
         this.dataGridTableStylePatients = new System.Windows.Forms.DataGridTableStyle();
         this.dataGridTableStyleStudies = new System.Windows.Forms.DataGridTableStyle();
         this.dataGridTextBoxColumn6 = new System.Windows.Forms.DataGridTextBoxColumn();
         this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
         this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
         this.dataGridTextBoxColumn3 = new System.Windows.Forms.DataGridTextBoxColumn();
         this.dataGridTextBoxColumn4 = new System.Windows.Forms.DataGridTextBoxColumn();
         this.dataGridTextBoxColumn5 = new System.Windows.Forms.DataGridTextBoxColumn();
         this.tabPageUsers = new System.Windows.Forms.TabPage();
         this.dataGridUsers = new System.Windows.Forms.DataGrid();
         this.tabPageClients = new System.Windows.Forms.TabPage();
         this.listViewClients = new System.Windows.Forms.ListView();
         this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
         this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
         this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
         this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
         this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
         this.dataGridTextBoxColumn7 = new System.Windows.Forms.DataGridTextBoxColumn();
         ((System.ComponentModel.ISupportInitialize)(this.statusBarPanelConnect)).BeginInit();
         this.panelLog.SuspendLayout();
         this.panelTabs.SuspendLayout();
         this.tabControlServer.SuspendLayout();
         this.tabPageDatabase.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.dataGridDicom)).BeginInit();
         this.tabPageUsers.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.dataGridUsers)).BeginInit();
         this.tabPageClients.SuspendLayout();
         this.SuspendLayout();
         // 
         // statusBar1
         // 
         this.statusBar1.Location = new System.Drawing.Point(0, 343);
         this.statusBar1.Name = "statusBar1";
         this.statusBar1.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.statusBarPanelConnect});
         this.statusBar1.Size = new System.Drawing.Size(544, 22);
         this.statusBar1.TabIndex = 0;
         // 
         // statusBarPanelConnect
         // 
         this.statusBarPanelConnect.Name = "statusBarPanelConnect";
         this.statusBarPanelConnect.Text = "Connected";
         // 
         // panelLog
         // 
         this.panelLog.Controls.Add(this.listViewLog);
         this.panelLog.Controls.Add(this.label1);
         this.panelLog.Dock = System.Windows.Forms.DockStyle.Bottom;
         this.panelLog.Location = new System.Drawing.Point(0, 243);
         this.panelLog.Name = "panelLog";
         this.panelLog.Size = new System.Drawing.Size(544, 100);
         this.panelLog.TabIndex = 1;
         // 
         // listViewLog
         // 
         this.listViewLog.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader6,
            this.columnHeader7});
         this.listViewLog.Dock = System.Windows.Forms.DockStyle.Fill;
         this.listViewLog.FullRowSelect = true;
         this.listViewLog.GridLines = true;
         this.listViewLog.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
         this.listViewLog.Location = new System.Drawing.Point(0, 16);
         this.listViewLog.Name = "listViewLog";
         this.listViewLog.Size = new System.Drawing.Size(544, 84);
         this.listViewLog.SmallImageList = this.imageListLog;
         this.listViewLog.TabIndex = 1;
         this.listViewLog.UseCompatibleStateImageBehavior = false;
         this.listViewLog.View = System.Windows.Forms.View.Details;
         this.listViewLog.DoubleClick += new System.EventHandler(this.listViewLog_DoubleClick);
         // 
         // columnHeader6
         // 
         this.columnHeader6.Text = "Action";
         this.columnHeader6.Width = 100;
         // 
         // columnHeader7
         // 
         this.columnHeader7.Text = "Info";
         this.columnHeader7.Width = 200;
         // 
         // imageListLog
         // 
         this.imageListLog.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListLog.ImageStream")));
         this.imageListLog.TransparentColor = System.Drawing.Color.Transparent;
         this.imageListLog.Images.SetKeyName(0, "");
         // 
         // label1
         // 
         this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this.label1.Dock = System.Windows.Forms.DockStyle.Top;
         this.label1.Location = new System.Drawing.Point(0, 0);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(544, 16);
         this.label1.TabIndex = 0;
         this.label1.Text = "Log: (Double click item with image icon to see dataset)";
         // 
         // splitter1
         // 
         this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
         this.splitter1.Location = new System.Drawing.Point(0, 240);
         this.splitter1.Name = "splitter1";
         this.splitter1.Size = new System.Drawing.Size(544, 3);
         this.splitter1.TabIndex = 2;
         this.splitter1.TabStop = false;
         // 
         // toolBarMain
         // 
         this.toolBarMain.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
         this.toolBarMain.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
            this.toolBarButtonImport,
            this.toolBarButtonActive,
            this.toolBarButton3,
            this.toolBarButtonClearLog,
            this.toolBarButtonOptions,
            this.toolBarButton1,
            this.toolBarButtonUserAdd,
            this.toolBarButtonUserModify,
            this.toolBarButtonDelete,
            this.toolBarButton4,
            this.toolBarButtonAssociation,
            this.toolBarButtonDisconnect,
            this.toolBarButton2,
            this.toolBarButtonExit});
         this.toolBarMain.DropDownArrows = true;
         this.toolBarMain.ImageList = this.imageListToolbar;
         this.toolBarMain.Location = new System.Drawing.Point(0, 0);
         this.toolBarMain.Name = "toolBarMain";
         this.toolBarMain.ShowToolTips = true;
         this.toolBarMain.Size = new System.Drawing.Size(544, 42);
         this.toolBarMain.TabIndex = 3;
         this.toolBarMain.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBarMain_ButtonClick);
         // 
         // toolBarButtonImport
         // 
         this.toolBarButtonImport.ImageIndex = 0;
         this.toolBarButtonImport.Name = "toolBarButtonImport";
         this.toolBarButtonImport.Text = "Import";
         this.toolBarButtonImport.ToolTipText = "Import file";
         // 
         // toolBarButtonActive
         // 
         this.toolBarButtonActive.ImageIndex = 1;
         this.toolBarButtonActive.Name = "toolBarButtonActive";
         this.toolBarButtonActive.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton;
         this.toolBarButtonActive.Text = "Active";
         this.toolBarButtonActive.ToolTipText = "Start/stop server";
         // 
         // toolBarButton3
         // 
         this.toolBarButton3.Name = "toolBarButton3";
         this.toolBarButton3.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
         // 
         // toolBarButtonClearLog
         // 
         this.toolBarButtonClearLog.ImageIndex = 7;
         this.toolBarButtonClearLog.Name = "toolBarButtonClearLog";
         this.toolBarButtonClearLog.Text = "Clear";
         this.toolBarButtonClearLog.ToolTipText = "Clear log";
         // 
         // toolBarButtonOptions
         // 
         this.toolBarButtonOptions.ImageIndex = 2;
         this.toolBarButtonOptions.Name = "toolBarButtonOptions";
         this.toolBarButtonOptions.Text = "Options";
         this.toolBarButtonOptions.ToolTipText = "Server options";
         // 
         // toolBarButton1
         // 
         this.toolBarButton1.Name = "toolBarButton1";
         this.toolBarButton1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
         // 
         // toolBarButtonUserAdd
         // 
         this.toolBarButtonUserAdd.Enabled = false;
         this.toolBarButtonUserAdd.ImageIndex = 4;
         this.toolBarButtonUserAdd.Name = "toolBarButtonUserAdd";
         this.toolBarButtonUserAdd.Text = "Add";
         this.toolBarButtonUserAdd.ToolTipText = "Add User";
         // 
         // toolBarButtonUserModify
         // 
         this.toolBarButtonUserModify.Enabled = false;
         this.toolBarButtonUserModify.ImageIndex = 6;
         this.toolBarButtonUserModify.Name = "toolBarButtonUserModify";
         this.toolBarButtonUserModify.Text = "Modify";
         this.toolBarButtonUserModify.ToolTipText = "Modify user";
         // 
         // toolBarButtonDelete
         // 
         this.toolBarButtonDelete.Enabled = false;
         this.toolBarButtonDelete.ImageIndex = 5;
         this.toolBarButtonDelete.Name = "toolBarButtonDelete";
         this.toolBarButtonDelete.Text = "Delete";
         this.toolBarButtonDelete.ToolTipText = "Delete user";
         // 
         // toolBarButton4
         // 
         this.toolBarButton4.Name = "toolBarButton4";
         this.toolBarButton4.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
         // 
         // toolBarButtonAssociation
         // 
         this.toolBarButtonAssociation.Enabled = false;
         this.toolBarButtonAssociation.ImageIndex = 9;
         this.toolBarButtonAssociation.Name = "toolBarButtonAssociation";
         this.toolBarButtonAssociation.Text = "Association";
         this.toolBarButtonAssociation.ToolTipText = "View association";
         // 
         // toolBarButtonDisconnect
         // 
         this.toolBarButtonDisconnect.Enabled = false;
         this.toolBarButtonDisconnect.ImageIndex = 8;
         this.toolBarButtonDisconnect.Name = "toolBarButtonDisconnect";
         this.toolBarButtonDisconnect.Text = "Close";
         this.toolBarButtonDisconnect.ToolTipText = "Close user connection";
         // 
         // toolBarButton2
         // 
         this.toolBarButton2.Name = "toolBarButton2";
         this.toolBarButton2.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
         // 
         // toolBarButtonExit
         // 
         this.toolBarButtonExit.ImageIndex = 3;
         this.toolBarButtonExit.Name = "toolBarButtonExit";
         this.toolBarButtonExit.Text = "Exit";
         this.toolBarButtonExit.ToolTipText = "Exit application";
         // 
         // imageListToolbar
         // 
         this.imageListToolbar.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListToolbar.ImageStream")));
         this.imageListToolbar.TransparentColor = System.Drawing.Color.Transparent;
         this.imageListToolbar.Images.SetKeyName(0, "");
         this.imageListToolbar.Images.SetKeyName(1, "");
         this.imageListToolbar.Images.SetKeyName(2, "");
         this.imageListToolbar.Images.SetKeyName(3, "");
         this.imageListToolbar.Images.SetKeyName(4, "");
         this.imageListToolbar.Images.SetKeyName(5, "");
         this.imageListToolbar.Images.SetKeyName(6, "");
         this.imageListToolbar.Images.SetKeyName(7, "");
         this.imageListToolbar.Images.SetKeyName(8, "");
         this.imageListToolbar.Images.SetKeyName(9, "");
         // 
         // panelTabs
         // 
         this.panelTabs.Controls.Add(this.tabControlServer);
         this.panelTabs.Dock = System.Windows.Forms.DockStyle.Fill;
         this.panelTabs.Location = new System.Drawing.Point(0, 42);
         this.panelTabs.Name = "panelTabs";
         this.panelTabs.Size = new System.Drawing.Size(544, 198);
         this.panelTabs.TabIndex = 4;
         // 
         // tabControlServer
         // 
         this.tabControlServer.Controls.Add(this.tabPageDatabase);
         this.tabControlServer.Controls.Add(this.tabPageUsers);
         this.tabControlServer.Controls.Add(this.tabPageClients);
         this.tabControlServer.Dock = System.Windows.Forms.DockStyle.Fill;
         this.tabControlServer.Location = new System.Drawing.Point(0, 0);
         this.tabControlServer.Name = "tabControlServer";
         this.tabControlServer.SelectedIndex = 0;
         this.tabControlServer.Size = new System.Drawing.Size(544, 198);
         this.tabControlServer.TabIndex = 0;
         this.tabControlServer.SelectedIndexChanged += new System.EventHandler(this.tabControlServer_SelectedIndexChanged);
         // 
         // tabPageDatabase
         // 
         this.tabPageDatabase.Controls.Add(this.dataGridDicom);
         this.tabPageDatabase.Location = new System.Drawing.Point(4, 22);
         this.tabPageDatabase.Name = "tabPageDatabase";
         this.tabPageDatabase.Size = new System.Drawing.Size(536, 172);
         this.tabPageDatabase.TabIndex = 0;
         this.tabPageDatabase.Text = "Database";
         // 
         // dataGridDicom
         // 
         this.dataGridDicom.CaptionText = "Dicom Server Database";
         this.dataGridDicom.DataMember = "";
         this.dataGridDicom.Dock = System.Windows.Forms.DockStyle.Fill;
         this.dataGridDicom.HeaderForeColor = System.Drawing.SystemColors.ControlText;
         this.dataGridDicom.Location = new System.Drawing.Point(0, 0);
         this.dataGridDicom.Name = "dataGridDicom";
         this.dataGridDicom.ReadOnly = true;
         this.dataGridDicom.Size = new System.Drawing.Size(536, 172);
         this.dataGridDicom.TabIndex = 0;
         this.dataGridDicom.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStylePatients,
            this.dataGridTableStyleStudies});
         this.dataGridDicom.CurrentCellChanged += new System.EventHandler(this.datagrid_CurrentCellChanged);
         this.dataGridDicom.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridDicom_KeyDown);
         // 
         // dataGridTableStylePatients
         // 
         this.dataGridTableStylePatients.DataGrid = this.dataGridDicom;
         this.dataGridTableStylePatients.HeaderForeColor = System.Drawing.SystemColors.ControlText;
         this.dataGridTableStylePatients.MappingName = "Patients";
         // 
         // dataGridTableStyleStudies
         // 
         this.dataGridTableStyleStudies.DataGrid = this.dataGridDicom;
         this.dataGridTableStyleStudies.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn6,
            this.dataGridTextBoxColumn1,
            this.dataGridTextBoxColumn2,
            this.dataGridTextBoxColumn3,
            this.dataGridTextBoxColumn4,
            this.dataGridTextBoxColumn5,
            this.dataGridTextBoxColumn7});
         this.dataGridTableStyleStudies.HeaderForeColor = System.Drawing.SystemColors.ControlText;
         this.dataGridTableStyleStudies.MappingName = "Studies";
         // 
         // dataGridTextBoxColumn6
         // 
         this.dataGridTextBoxColumn6.Format = "";
         this.dataGridTextBoxColumn6.FormatInfo = null;
         this.dataGridTextBoxColumn6.HeaderText = "StudyInstanceUID";
         this.dataGridTextBoxColumn6.MappingName = "StudyInstanceUID";
         this.dataGridTextBoxColumn6.Width = 75;
         // 
         // dataGridTextBoxColumn1
         // 
         this.dataGridTextBoxColumn1.Format = "";
         this.dataGridTextBoxColumn1.FormatInfo = null;
         this.dataGridTextBoxColumn1.HeaderText = "StudyDate";
         this.dataGridTextBoxColumn1.MappingName = "StudyDate";
         this.dataGridTextBoxColumn1.Width = 75;
         // 
         // dataGridTextBoxColumn2
         // 
         this.dataGridTextBoxColumn2.Format = "hh:mm:ss.ff";
         this.dataGridTextBoxColumn2.FormatInfo = null;
         this.dataGridTextBoxColumn2.HeaderText = "Study Time";
         this.dataGridTextBoxColumn2.MappingName = "StudyTime";
         this.dataGridTextBoxColumn2.Width = 75;
         // 
         // dataGridTextBoxColumn3
         // 
         this.dataGridTextBoxColumn3.Format = "";
         this.dataGridTextBoxColumn3.FormatInfo = null;
         this.dataGridTextBoxColumn3.HeaderText = "AccessionNumber";
         this.dataGridTextBoxColumn3.MappingName = "AccessionNumber";
         this.dataGridTextBoxColumn3.Width = 75;
         // 
         // dataGridTextBoxColumn4
         // 
         this.dataGridTextBoxColumn4.Format = "";
         this.dataGridTextBoxColumn4.FormatInfo = null;
         this.dataGridTextBoxColumn4.HeaderText = "StudyID";
         this.dataGridTextBoxColumn4.MappingName = "StudyID";
         this.dataGridTextBoxColumn4.Width = 75;
         // 
         // dataGridTextBoxColumn5
         // 
         this.dataGridTextBoxColumn5.Format = "";
         this.dataGridTextBoxColumn5.FormatInfo = null;
         this.dataGridTextBoxColumn5.HeaderText = "StudyDescription";
         this.dataGridTextBoxColumn5.MappingName = "StudyDescription";
         this.dataGridTextBoxColumn5.Width = 75;
         // 
         // tabPageUsers
         // 
         this.tabPageUsers.Controls.Add(this.dataGridUsers);
         this.tabPageUsers.Location = new System.Drawing.Point(4, 22);
         this.tabPageUsers.Name = "tabPageUsers";
         this.tabPageUsers.Size = new System.Drawing.Size(536, 172);
         this.tabPageUsers.TabIndex = 1;
         this.tabPageUsers.Text = "Users";
         // 
         // dataGridUsers
         // 
         this.dataGridUsers.CaptionText = "Valid server users";
         this.dataGridUsers.DataMember = "";
         this.dataGridUsers.Dock = System.Windows.Forms.DockStyle.Fill;
         this.dataGridUsers.HeaderForeColor = System.Drawing.SystemColors.ControlText;
         this.dataGridUsers.Location = new System.Drawing.Point(0, 0);
         this.dataGridUsers.Name = "dataGridUsers";
         this.dataGridUsers.ReadOnly = true;
         this.dataGridUsers.Size = new System.Drawing.Size(536, 172);
         this.dataGridUsers.TabIndex = 2;
         this.dataGridUsers.CurrentCellChanged += new System.EventHandler(this.datagrid_CurrentCellChanged);
         // 
         // tabPageClients
         // 
         this.tabPageClients.Controls.Add(this.listViewClients);
         this.tabPageClients.Location = new System.Drawing.Point(4, 22);
         this.tabPageClients.Name = "tabPageClients";
         this.tabPageClients.Size = new System.Drawing.Size(536, 172);
         this.tabPageClients.TabIndex = 2;
         this.tabPageClients.Text = "Clients";
         // 
         // listViewClients
         // 
         this.listViewClients.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader8,
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader5});
         this.listViewClients.Dock = System.Windows.Forms.DockStyle.Fill;
         this.listViewClients.FullRowSelect = true;
         this.listViewClients.GridLines = true;
         this.listViewClients.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
         this.listViewClients.HideSelection = false;
         this.listViewClients.Location = new System.Drawing.Point(0, 0);
         this.listViewClients.MultiSelect = false;
         this.listViewClients.Name = "listViewClients";
         this.listViewClients.Size = new System.Drawing.Size(536, 172);
         this.listViewClients.TabIndex = 0;
         this.listViewClients.UseCompatibleStateImageBehavior = false;
         this.listViewClients.View = System.Windows.Forms.View.Details;
         // 
         // columnHeader8
         // 
         this.columnHeader8.Text = "Id";
         this.columnHeader8.Width = 100;
         // 
         // columnHeader1
         // 
         this.columnHeader1.Text = "AETitle";
         this.columnHeader1.Width = 100;
         // 
         // columnHeader2
         // 
         this.columnHeader2.Text = "Host";
         this.columnHeader2.Width = 100;
         // 
         // columnHeader3
         // 
         this.columnHeader3.Text = "Connect Time";
         this.columnHeader3.Width = 100;
         // 
         // columnHeader5
         // 
         this.columnHeader5.Text = "Last Action";
         this.columnHeader5.Width = 100;
         // 
         // dataGridTextBoxColumn7
         // 
         this.dataGridTextBoxColumn7.Format = "";
         this.dataGridTextBoxColumn7.FormatInfo = null;
         this.dataGridTextBoxColumn7.HeaderText = "ReferringDrName";
         this.dataGridTextBoxColumn7.MappingName = "ReferringDrName";
         this.dataGridTextBoxColumn7.Width = 75;
         // 
         // MainForm
         // 
         this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
         this.ClientSize = new System.Drawing.Size(544, 365);
         this.Controls.Add(this.panelTabs);
         this.Controls.Add(this.toolBarMain);
         this.Controls.Add(this.splitter1);
         this.Controls.Add(this.panelLog);
         this.Controls.Add(this.statusBar1);
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.Name = "MainForm";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         this.Text = "LEADTOOLS Dicom Server (C#)";
         this.Load += new System.EventHandler(this.MainForm_Load);
         this.Closed += new System.EventHandler(this.MainForm_Closed);
         this.Closing += new System.ComponentModel.CancelEventHandler(this.MainForm_Closing);
         ((System.ComponentModel.ISupportInitialize)(this.statusBarPanelConnect)).EndInit();
         this.panelLog.ResumeLayout(false);
         this.panelTabs.ResumeLayout(false);
         this.tabControlServer.ResumeLayout(false);
         this.tabPageDatabase.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.dataGridDicom)).EndInit();
         this.tabPageUsers.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.dataGridUsers)).EndInit();
         this.tabPageClients.ResumeLayout(false);
         this.ResumeLayout(false);
         this.PerformLayout();

      }
      #endregion

      /// <summary>
      /// The main entry point for the application.
      /// </summary>
      [STAThread]
      static void Main(string[] args)
      {
         Application.EnableVisualStyles();
#if LEADTOOLS_V175_OR_LATER
         if (!Support.SetLicense())
            return;
#else
         Support.Unlock(false);
#endif // #if LTV175_CONFIG

#if LEADTOOLS_V175_OR_LATER
         if (RasterSupport.IsLocked(RasterSupportType.DicomCommunication))
         {
            MessageBox.Show(String.Format("{0} Support is locked!", RasterSupportType.DicomCommunication.ToString()), "Warning");
            return;
         }
#else
         if ( RasterSupport.IsLocked ( RasterSupportType.MedicalNet ) )
         {
            MessageBox.Show(String.Format("{0} Support is locked!", RasterSupportType.MedicalNet.ToString()), "Warning");
            return;
         }
#endif // #if LEADTOOLS_V175_OR_LATER

         if (DemosGlobal.MustRestartElevated())
         {
            DemosGlobal.TryRestartElevated(args);
            return;
         }

         Utils.EngineStartup();
         Utils.DicomNetStartup();

         Application.Run(new MainForm());
      }

      private void AddUser()
      {
         UserPropertiesDlg dlgUsers = new UserPropertiesDlg();

         dlgUsers.Edit = false;
         if (dlgUsers.ShowDialog(this) == DialogResult.OK)
         {
            UserInfo userInfo = dlgUsers.User;

            usersDB.AddUser(ref userInfo);
            usersDB.Save();
         }
      }

      private void ModifyUser()
      {
         if (dataGridUsers.CurrentRowIndex == -1)
            return;

         string id;
         UserPropertiesDlg dlgUsers = new UserPropertiesDlg();

         id = usersDB.DB.Tables["Users"].Rows[dataGridUsers.CurrentRowIndex]["Id"].ToString();
         dlgUsers.Edit = true;
         dlgUsers.User = usersDB.LoadUser(id);
         if (dlgUsers.ShowDialog(this) == DialogResult.OK)
         {
            usersDB.UpdateUser(dlgUsers.User);
            usersDB.Save();
         }
      }

      private void MainForm_Load(object sender, System.EventArgs e)
      {

         if (!Directory.Exists(dicomServer.ImageDir))
         {
            Directory.CreateDirectory(dicomServer.ImageDir);
         }

         LoadSettings();
         dicomDB.ImageDir = dicomServer.ImageDir;
         if (dicomDB.NeedImport)
         {
            //
            // We just created a new dicom database. Therefore, we need to import 
            //  some images.  By default we will import any dicom file installed
            //  by LEADTOOLS.
            //
            LoadDefaultImages();
         }

         dicomServer.usersDB = usersDB;
         dicomServer.dicomDB = dicomDB;
         dicomServer.mf = this;
         StartServer();

         dataGridDicom.DataSource = dicomDB.DB;
         //AddTableStyles(dataGridDicom, dicomDB);

         //
         // Remove duplicated columns from the datagrid
         //
         RemoveColumn(dataGridDicom, "Studies", "PatientID");
         RemoveColumn(dataGridDicom, "Studies", "PatientName");
         RemoveColumn(dataGridDicom, "Series", "StudyInstanceUID");
         RemoveColumn(dataGridDicom, "Series", "PatientID");
         RemoveColumn(dataGridDicom, "Images", "StudyInstanceUID");
         RemoveColumn(dataGridDicom, "Images", "PatientID");
         RemoveColumn(dataGridDicom, "Images", "SeriesInstanceUID");
         dataGridDicom.DataMember = "Patients";

         dataGridUsers.DataSource = usersDB.DB;
         AddTableStyles(dataGridUsers, usersDB);
         dataGridUsers.DataMember = "Users";
         RemoveColumn(dataGridUsers, "Users", "Id");

         Application.ApplicationExit += new EventHandler(Application_ApplicationExit);
      }

      private void LoadDefaultImages()
      {
         StringCollection importFiles = new StringCollection();
         RegistryKey local = Registry.LocalMachine;

         ImportDefaultDlg dlgImport = new ImportDefaultDlg();

         string dicomImagesFolder = DemosGlobal.ImagesFolder;
         if (dicomImagesFolder.Length > 0)
         {
            string fileName = dicomImagesFolder + @"\IMAGE1.dcm";
            importFiles.Add(fileName);

            fileName = dicomImagesFolder + @"\IMAGE2.dcm";
            importFiles.Add(fileName);

            fileName = dicomImagesFolder + @"\IMAGE3.dcm";
            importFiles.Add(fileName);
         }

         dlgImport.FillFileList(importFiles);
         if (dlgImport.ShowDialog() == DialogResult.OK)
         {
            WaitCursor cursor = new WaitCursor();

            // Import LEAD installed dicom files.
            foreach (string file in importFiles)
            {
               InsertReturn ret;

               ret = dicomDB.Insert(file);
               switch (ret)
               {
                  case InsertReturn.Success:
                     Logger.Log("Import", file);
                     break;
                  case InsertReturn.Exists:
                     Logger.Log("Import", file + " not imported.  Record already exists");
                     ;
                     break;
                  case InsertReturn.Error:
                     Logger.Log("Import", file + " not imported.  Error during import");
                     break;
               }
            }

            // Import additional directory of files
            if (Directory.Exists(dlgImport.AdditionalDir))
            {
               string[] userFiles;

               userFiles = Directory.GetFiles(dlgImport.AdditionalDir, "*.*");
               foreach (string file in userFiles)
               {
                  InsertReturn ret;

                  ret = dicomDB.Insert(file);
                  switch (ret)
                  {
                     case InsertReturn.Success:
                        Logger.Log("Import", file);
                        break;
                     case InsertReturn.Exists:
                        Logger.Log("Import", file + " not imported.  Record already exists");
                        ;
                        break;
                     case InsertReturn.Error:
                        Logger.Log("Import", file + " not imported.  Error during import");
                        break;
                  }
               }
            }
         }
      }

      private void DeleteUser()
      {
         string id;

         if (dataGridUsers.CurrentRowIndex == -1)
            return;

         id = usersDB.DB.Tables["Users"].Rows[dataGridUsers.CurrentRowIndex]["Id"].ToString();
         usersDB.RemoveUser(id);
         usersDB.Save();
      }

      private void toolBarMain_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
      {
         switch (e.Button.Text)
         {
            case "Import":
               Import();
               break;
            case "Clear":
               listViewLog.Items.Clear();
               break;
            case "Active":
               SetServerStatus();
               break;
            case "Options":
               ChangeOptions();
               break;
            case "Add":
               AddUser();
               break;
            case "Modify":
               ModifyUser();
               break;
            case "Delete":
               DeleteUser();
               break;
            case "Association":
               DisplayAssociate();
               break;
            case "Close":
               CloseClient();
               break;
            case "Exit":
               Close();
               break;
         }
      }

      private void Import()
      {
         OpenFileDialog dlgOpen = new OpenFileDialog();

         dlgOpen.Title = "Import Dicom File";
         dlgOpen.Filter = "Dicom Files (*.dcm;*.dic)| *.dcm;*.dic|All files (*.*)|*.*";
         dlgOpen.Multiselect = true;
         if (dlgOpen.ShowDialog() == DialogResult.OK)
         {
            WaitCursor cursor = new WaitCursor();
            foreach (string file in dlgOpen.FileNames)
            {
               InsertReturn ret;

               ret = dicomDB.Insert(file);
               switch (ret)
               {
                  case InsertReturn.Success:
                     Logger.Log("Import", file);
                     break;
                  case InsertReturn.Exists:
                     Logger.Log("Import", file + " not imported.  Record already exists");
                     ;
                     break;
                  case InsertReturn.Error:
                     Logger.Log("Import", file + " not imported.  Error during import");
                     break;
               }
            }
            cursor = null;
         }
      }

      private void SetServerStatus()
      {
         if (!toolBarButtonActive.Pushed)
         {
            StopServer();
         }
         else
         {
            StartServer();
         }
      }

      private void StopServer()
      {
         CancelEventArgs e = new CancelEventArgs();

         MainForm_Closing(this, e);
         if (!e.Cancel || dicomServer.Clients.Count == 0)
         {
            dicomServer.Clients.Clear();
            listViewClients.Items.Clear();
            dicomServer.Close();
            Logger.Log("Shutdown", "Server stopped");
            toolBarButtonActive.Pushed = false;
         }
      }

      private void StartServer()
      {
         DicomExceptionCode ret;

         ret = dicomServer.Listen();
         toolBarButtonActive.Pushed = (ret == DicomExceptionCode.Success);
      }

      private void AddTableStyles(DataGrid dg, DBBase db)
      {
         foreach (DataTable table in db.DB.Tables)
         {
            DataGridTableStyle style = new DataGridTableStyle();

            style.MappingName = table.TableName;
            dg.DataMember = table.TableName;
            dg.TableStyles.Add(style);
         }
      }

      private void RemoveColumn(DataGrid dg, string table, string column)
      {
         DataGridTableStyle style = dg.TableStyles[table];

         if (style != null)
         {
            DataGridColumnStyle gridColumn = style.GridColumnStyles[column];

            if (gridColumn != null)
            {
               style.GridColumnStyles.Remove(gridColumn);
            }
         }
      }

      public void Log(string action, string text)
      {
         if (this.InvokeRequired)
         {
            this.Invoke(new LogDelegate(Logger.Log), new object[] { action, text });
         }
         else
         {
            Logger.Log(action, text);
         }
      }

      public void Log(string action, string text, object tag)
      {
         if (this.InvokeRequired)
         {
            this.Invoke(new LogTagDelegate(Logger.Log), new object[] { action, text, tag });
         }
         else
         {
            Logger.Log(action, text, tag);
         }
      }


      private void Application_ApplicationExit(object sender, EventArgs e)
      {
         Utils.EngineShutdown();
         Utils.DicomNetShutdown();
      }

      private void datagrid_CurrentCellChanged(object sender, System.EventArgs e)
      {
         DataGrid dg = sender as DataGrid;

         dg.Select(dg.CurrentCell.RowNumber);
      }

      private void tabControlServer_SelectedIndexChanged(object sender, System.EventArgs e)
      {
         TabPage page = tabControlServer.TabPages[tabControlServer.SelectedIndex];
         bool enable = page.Text == "Users";

         toolBarButtonUserAdd.Enabled = enable;
         toolBarButtonUserModify.Enabled = enable;
         toolBarButtonDelete.Enabled = enable;

         enable = page.Text == "Clients";
         toolBarButtonDisconnect.Enabled = enable && listViewClients.SelectedItems.Count > 0;
         toolBarButtonAssociation.Enabled = enable && listViewClients.SelectedItems.Count > 0;
      }

      /// <summary>
      /// Add client to the client list view.
      /// </summary>
      /// <param name="hClient">Client network handle.</param>
      /// <param name="ipAddress">Client ip address.</param>
      /// <param name="time">Date & time client connected to server.</param>
      public void AddClient(Client client, DateTime time)
      {
         if (Logger.DisableLogging == false)
         {
            ListViewItem item;

            client.Timer.Tick += new EventHandler(Timer_Tick);
            item = listViewClients.Items.Add(client.PeerAddress);
            item.Tag = client;
            item.SubItems.Add("");
            item.SubItems.Add(client.PeerAddress);
            item.SubItems.Add(time.ToString());
            item.SubItems.Add("Connect");
            item.Selected = true;
         }
      }

      public void UpdateClient(Client client, string aeTitle, string action)
      {
         ListViewItem item = FindClient(client);

         if (item != null)
         {
            if (aeTitle.Length > 0)
            {
               item.SubItems[1].Text = aeTitle;
            }
            item.SubItems[4].Text = action;
         }
      }

      public delegate ListViewItem FindClientDelegate(Client client);

      public ListViewItem FindClient(Client client)
      {
         if (InvokeRequired)
         {
            Invoke(new FindClientDelegate(FindClient), client);
         }
         else
         {
            foreach (ListViewItem item in listViewClients.Items)
            {
               Client ci = item.Tag as Client;

               if (ci == client)
               {
                  return item;
               }
            }
         }
         return null;
      }

      public void RemoveClient(Client client)
      {
         ListViewItem item = FindClient(client);

         if (item != null)
         {
            Client ci = item.Tag as Client;

            ci.Timer.Stop();
            listViewClients.Items.Remove(item);
         }
      }

      public void EnableTimer(Client client, string aeTitle, bool enable)
      {
         ListViewItem item = FindClient(client);

         if (item != null)
         {
            Client ci = item.Tag as Client;
            UserInfo ui = usersDB.LoadUser(client.PeerAddress, aeTitle);

            if (enable && ui.Timeout > 0)
            {
               ci.Timer.Interval = (ui.Timeout * 60) * 1000;
               ci.Timer.Start();
            }
            else
            {
               ci.Timer.Stop();
            }
         }
      }

      private void Timer_Tick(object sender, EventArgs e)
      {
         DicomTimer dt = sender as DicomTimer;
         ListViewItem item = FindClient(dt.Client);

         if (item != null)
         {
            if (dt.Client.IsConnected())
            {
               dicomServer.CloseClient(dt.Client);
            }
            dt.Stop();
            listViewClients.Items.Remove(item);
         }
      }

      private void CloseClient()
      {
         ListViewItem item = listViewClients.SelectedItems[0];
         Client client = item.Tag as Client;

         client.Timer.Stop();
         if (MessageBox.Show("Forcefully close client?", "Warning", MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning) == DialogResult.Yes)
         {
            dicomServer.CloseClient(client);
            listViewClients.Items.Remove(item);
         }
         else
         {
            client.Timer.Start();
         }
      }

      private void DisplayAssociate()
      {
         if (listViewClients.SelectedItems.Count > 0)
         {
            ListViewItem item = listViewClients.SelectedItems[0];
            AssociationDlg dlgAssociate = new AssociationDlg(item.Tag as Client);

            dlgAssociate.ShowDialog(this);
         }
      }

      private void ChangeOptions()
      {
         OptionsDlg dlgOptions = new OptionsDlg();

         //
         // Initialize server options
         //
         dlgOptions.AETitle = dicomServer.CalledAE;
         dlgOptions.ImageDir = dicomServer.ImageDir;
         dlgOptions.sIPAddress = dicomServer.IPAddress;
         dlgOptions.Port = dicomServer.Port;
         dlgOptions.Timeout = dicomServer.Timeout;
         dlgOptions.MaxClients = dicomServer.Peers;
         dlgOptions.IsSecure = dicomServer.IsSecure;

#if LEADTOOLS_V17_OR_LATER
         dlgOptions.IpType = dicomServer.IpType;
#endif

         //
         // Initialize log options
         //
         dlgOptions.SaveCSReceived = dicomServer.SaveCSReceived;
         dlgOptions.SaveDSReceived = dicomServer.SaveDSReceived;
         dlgOptions.SaveDSSent = dicomServer.SaveDSSent;
         dlgOptions.LogDir = dicomServer.LogDir;
         dlgOptions.DisableLogging = Logger.DisableLogging;

         if (dlgOptions.ShowDialog() == DialogResult.OK)
         {
            bool restart = false;

            dicomServer.CalledAE = dlgOptions.AETitle;
            dicomServer.Timeout = dlgOptions.Timeout;
            dicomServer.ImageDir = dlgOptions.ImageDir;
            dicomDB.ImageDir = dicomServer.ImageDir;

#if LEADTOOLS_V17_OR_LATER
            if (dicomServer.IpType != dlgOptions.IpType)
            {
               restart = true;
               dicomServer.IpType = dlgOptions.IpType;
            }
#endif

            if (dicomServer.IPAddress != dlgOptions.sIPAddress)
            {
               restart = true;
               dicomServer.IPAddress = dlgOptions.sIPAddress;
            }

            if (dicomServer.Port != dlgOptions.Port)
            {
               restart = true;
               dicomServer.Port = dlgOptions.Port;
            }

            if (dicomServer.Peers != dlgOptions.MaxClients)
            {
               restart = true;
               dicomServer.Peers = dlgOptions.MaxClients;
            }
            if (dlgOptions.IsSecure != dicomServer.IsSecure)
            {
               restart = true;
               dicomServer.IsSecure = dlgOptions.IsSecure;
            }

            if (restart)
            {
               StopServer();
               StartServer();
            }

            dicomServer.SaveCSReceived = dlgOptions.SaveCSReceived;
            dicomServer.SaveDSReceived = dlgOptions.SaveDSReceived;
            dicomServer.SaveDSSent = dlgOptions.SaveDSSent;
            dicomServer.LogDir = dlgOptions.LogDir;
            Logger.DisableLogging = dlgOptions.DisableLogging;
         }
      }

      private void MainForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
      {
         if (dicomServer.Clients.Count > 0)
         {
            string msg;

            if (dicomServer.Clients.Count > 1)
               msg = "There are " + dicomServer.Clients.Count.ToString() + " connected!  Do you wish to shutdown?";
            else
               msg = "There is 1 client connected! Do you wish to shutdown?";

            tabControlServer.SelectedTab = tabPageClients;
            e.Cancel = MessageBox.Show(msg, "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No;

            if (!e.Cancel)
            {
               ForceCloseClients();
            }
         }
      }


      private void ForceCloseClients()
      {
         if (dicomServer.Clients.Count > 0)
         {
            foreach (KeyValuePair<string, Client> client in dicomServer.Clients)
            {
               if (client.Value.IsConnected())
                  client.Value.CloseForced(true);
               client.Value.Terminate();
            }
         }
      }

      private bool Is64
      {
         get
         {
            return IntPtr.Size == 8;
         }
      }

      private void LoadSettings()
      {
         RegistryKey user = Registry.CurrentUser;

         String settingsString;
#if LTV20_CONFIG
         settingsString = @"SOFTWARE\LEAD Technologies, Inc.\20\DICOMSVRCSHAR20_Dotnet4";
#endif
         if (Is64)
            settingsString += "_x64";

         RegistryKey settings = user.OpenSubKey(settingsString, true);
         if (settings == null)
         {
            // We haven't saved any setting yet. Will use the default settings.
            return;
         }

         dicomServer.CalledAE = Convert.ToString(settings.GetValue("AETitle", "LEAD_SERVER"));
         dicomServer.Port = Convert.ToInt32(settings.GetValue("Port", 104));
         dicomServer.Peers = Convert.ToInt32(settings.GetValue("Peers", 5));
         dicomServer.IPAddress = Convert.ToString(settings.GetValue("IPAddress"));
         string sValue = Convert.ToString(settings.GetValue("IpType"));
         if (string.IsNullOrEmpty(sValue))
            dicomServer.IpType = DicomNetIpTypeFlags.Ipv4;
         else
            dicomServer.IpType = (DicomNetIpTypeFlags)DemosGlobal.StringToEnum(typeof(DicomNetIpTypeFlags), sValue);
         dicomServer.Timeout = Convert.ToInt32(settings.GetValue("Timeout", 0));
         dicomServer.LogDir = Convert.ToString(settings.GetValue("LogDir"));
         dicomServer.ImageDir = Convert.ToString(settings.GetValue("ImageDir"));
         dicomServer.SaveCSReceived = Convert.ToBoolean(settings.GetValue("SaveCSReceived"));
         dicomServer.SaveDSReceived = Convert.ToBoolean(settings.GetValue("SaveDSReceived"));
         dicomServer.SaveDSSent = Convert.ToBoolean(settings.GetValue("SaveDSSent"));
         Logger.DisableLogging = Convert.ToBoolean(settings.GetValue("DisableLogging"));
      }

      private void SaveSettings()
      {
         RegistryKey user = Registry.CurrentUser;
         String settingsString;
#if LTV20_CONFIG
         settingsString = @"SOFTWARE\LEAD Technologies, Inc.\20\DICOMSVRCSHAR20_Dotnet4";
#endif
         if (Is64)
            settingsString += "_x64";

         RegistryKey settings = user.OpenSubKey(settingsString, true);
         if (settings == null)
         {
            // We haven't saved any setting yet. Will use the default settings.
            return;
         }

         if (settings == null)
            settings = user.CreateSubKey(settingsString);

         settings.SetValue("AETitle", dicomServer.CalledAE);
         settings.SetValue("Port", dicomServer.Port);
         settings.SetValue("Peers", dicomServer.Peers);
         settings.SetValue("IPAddress", dicomServer.IPAddress);
         settings.SetValue("Timeout", dicomServer.Timeout);
         settings.SetValue("LogDir", dicomServer.LogDir);
         settings.SetValue("ImageDir", dicomServer.ImageDir);
         settings.SetValue("SaveCSReceived", dicomServer.SaveCSReceived);
         settings.SetValue("SaveDSReceived", dicomServer.SaveDSReceived);
         settings.SetValue("SaveDSSent", dicomServer.SaveDSSent);
         settings.SetValue("DisableLogging", Logger.DisableLogging);
         settings.Close();
      }

      private void MainForm_Closed(object sender, System.EventArgs e)
      {
         SaveSettings();
      }

      private void listViewLog_DoubleClick(object sender, System.EventArgs e)
      {
         string file;

         if (listViewLog.SelectedItems.Count == 0)
            return;

         file = listViewLog.SelectedItems[0].Tag as string;
         if (file != null && file.Length > 0)
         {
            DicomInfoDlg dlgInfo = new DicomInfoDlg();

            if (dlgInfo.UpdateTree(file) == DicomExceptionCode.Success)
            {
               dlgInfo.ShowDialog(this);
            }
         }
      }

      public ArrayList GetSelectedRows(DataGrid dg)
      {
         ArrayList al = new ArrayList();
         CurrencyManager cm = (CurrencyManager)this.BindingContext[dg.DataSource, dg.DataMember];
         DataView dv = (DataView)cm.List;

         for (int i = 0; i < dv.Count; ++i)
         {

            if (dg.IsSelected(i))
               al.Add(i);
         }

         return al;
      }

      private void dataGridDicom_KeyDown(object sender, KeyEventArgs e)
      {
         ArrayList rows = GetSelectedRows(dataGridDicom);

         if (e.KeyCode == Keys.Delete && rows.Count > 0)
         {
            string table = "";
            string field = "";

            switch (dataGridDicom.DataMember)
            {
               case "Patients":
                  table = "Patients";
                  field = "PatientID";
                  break;

               case "Patients.Studies":
                  table = "Studies";
                  field = "StudyInstanceUID";
                  break;

               case "Patients.Studies.Series":
                  table = "Series";
                  field = "SeriesInstanceUID";
                  break;

               case "Patients.Studies.Series.Images":
                  table = "Images";
                  field = "SOPInstanceUID";
                  break;

            }

            foreach (int row in rows)
            {
               string key;

               key = dicomDB.DB.Tables[table].Rows[row][field].ToString();
               dicomDB.Delete(table, field, key);
            }

            dicomDB.Save();
         }
      }
   }
}
