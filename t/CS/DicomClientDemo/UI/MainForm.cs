// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Net;
using System.Configuration;

using Microsoft.Win32;

using Leadtools;
using Leadtools.Demos;
using Leadtools.Demos.Dialogs;
using Leadtools.Dicom;
using Leadtools.Controls;
using Leadtools.DicomDemos;
using Leadtools.DicomDemos.Scu;
using Leadtools.DicomDemos.Scu.CFind;

namespace DicomDemo
{
   /// <summary>
   /// Summary description for Form1.
   /// </summary>
   public class MainForm : System.Windows.Forms.Form
   {
      private System.Windows.Forms.Panel panel1;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.PropertyGrid propertyGridSearch;
      private System.Windows.Forms.Panel panel2;
      private System.Windows.Forms.Button buttonSearch;
      private System.Windows.Forms.Splitter splitter1;
      private IContainer components;

      private CFindQuery query = new CFindQuery();
      private System.Windows.Forms.Panel panel3;
      private System.Windows.Forms.Splitter splitter2;
      private System.Windows.Forms.Panel panel4;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.Button buttonOptions;
      private CFind cfind = new CFind();
      private CFindQuery dcmQuery = new CFindQuery();

      private DicomServer server = new DicomServer();
      private string AETitle = "CLIENT1";
      private bool GroupLengthDataElements = false;
      private System.Windows.Forms.MainMenu mainMenu1;
      private System.Windows.Forms.MenuItem menuItem1;
      private System.Windows.Forms.MenuItem menuItemFileExit;
      private System.Windows.Forms.ListView listViewStudies;
      private System.Windows.Forms.ColumnHeader columnHeader1;
      private System.Windows.Forms.ColumnHeader columnHeader2;
      private System.Windows.Forms.ColumnHeader columnHeader3;
      private System.Windows.Forms.ColumnHeader columnHeader4;
      private System.Windows.Forms.ColumnHeader columnHeader5;
      private System.Windows.Forms.ColumnHeader columnHeader6;
      private System.Windows.Forms.ListView listViewSeries;
      private System.Windows.Forms.ColumnHeader columnHeader7;
      private System.Windows.Forms.ColumnHeader columnHeader8;
      private System.Windows.Forms.ColumnHeader columnHeader9;
      private System.Windows.Forms.ColumnHeader columnHeader10;
      private System.Windows.Forms.Panel panel5;
      private System.Windows.Forms.Splitter splitter3;
      private System.Windows.Forms.Label label4;
      private System.Windows.Forms.Panel panel6;
      private System.Windows.Forms.Splitter splitter4;
      private System.Windows.Forms.ColumnHeader columnHeader11;
      private System.Windows.Forms.RichTextBox Log;
      private System.Windows.Forms.Label label5;
      private System.Windows.Forms.MenuItem menuItemClearLog;
      private System.Windows.Forms.MenuItem menuItem3;
      private System.Windows.Forms.MenuItem menuItemHelp;
      private System.Windows.Forms.MenuItem menuItemAbout;
      private Leadtools.Controls.ImageViewer imageList;
      private int Port = 1000;

      const string CONFIGURATION_IMPLEMENTATIONCLASS = "1.2.840.114257.1123456";
      const string CONFIGURATION_IMPLEMENTATIONVERSIONNAME = "1";
      private MenuItem menuItemOptions;
      private MenuItem menuItemIPv4;
      private MenuItem menuItemIPv6;
      private MenuItem menuItemIpv4Ipv6;
      const string CONFIGURATION_PROTOCOLVERSION = "1";

      private string _settingsLocation = @"SOFTWARE\LEAD Technologies, Inc.\17\VBNet_DicomFindMove17";

      private DicomNetIpTypeFlags _ipType = DicomNetIpTypeFlags.Ipv4;

      public delegate void AddLog(string action, string logText);

      public MainForm( )
      {
         //
         // Required for Windows Form Designer support
         //
         InitializeComponent();

         imageList.ItemSize = LeadSize.Create(100, 100);
         imageList.ItemSizeMode = ControlSizeMode.Fit;
         imageList.InteractiveModes.BeginUpdate();
         imageList.InteractiveModes.Add(new ImageViewerSelectItemsInteractiveMode() { SelectionMode = ImageViewerSelectionMode.Single });
         imageList.InteractiveModes.EndUpdate();
      }

      /// <summary>
      /// Clean up any resources being used.
      /// </summary>
      protected override void Dispose(bool disposing)
      {
         if(disposing)
         {
            if(components != null)
            {
               components.Dispose();
            }
         }
         base.Dispose(disposing);
      }

      #region Windows Form Designer generated code
      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent( )
      {
          this.components = new System.ComponentModel.Container();
          System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
          this.panel1 = new System.Windows.Forms.Panel();
          this.propertyGridSearch = new System.Windows.Forms.PropertyGrid();
          this.label1 = new System.Windows.Forms.Label();
          this.panel2 = new System.Windows.Forms.Panel();
          this.buttonSearch = new System.Windows.Forms.Button();
          this.buttonOptions = new System.Windows.Forms.Button();
          this.splitter1 = new System.Windows.Forms.Splitter();
          this.panel3 = new System.Windows.Forms.Panel();
          this.listViewStudies = new System.Windows.Forms.ListView();
          this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
          this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
          this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
          this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
          this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
          this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
          this.label2 = new System.Windows.Forms.Label();
          this.splitter2 = new System.Windows.Forms.Splitter();
          this.panel4 = new System.Windows.Forms.Panel();
          this.listViewSeries = new System.Windows.Forms.ListView();
          this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
          this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
          this.columnHeader9 = new System.Windows.Forms.ColumnHeader();
          this.columnHeader10 = new System.Windows.Forms.ColumnHeader();
          this.columnHeader11 = new System.Windows.Forms.ColumnHeader();
          this.label3 = new System.Windows.Forms.Label();
          this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
          this.menuItem1 = new System.Windows.Forms.MenuItem();
          this.menuItemClearLog = new System.Windows.Forms.MenuItem();
          this.menuItem3 = new System.Windows.Forms.MenuItem();
          this.menuItemFileExit = new System.Windows.Forms.MenuItem();
          this.menuItemOptions = new System.Windows.Forms.MenuItem();
          this.menuItemIPv4 = new System.Windows.Forms.MenuItem();
          this.menuItemIPv6 = new System.Windows.Forms.MenuItem();
          this.menuItemIpv4Ipv6 = new System.Windows.Forms.MenuItem();
          this.menuItemHelp = new System.Windows.Forms.MenuItem();
          this.menuItemAbout = new System.Windows.Forms.MenuItem();
          this.panel5 = new System.Windows.Forms.Panel();
          this.Log = new System.Windows.Forms.RichTextBox();
          this.label4 = new System.Windows.Forms.Label();
          this.splitter3 = new System.Windows.Forms.Splitter();
          this.panel6 = new System.Windows.Forms.Panel();
          this.imageList = new Leadtools.Controls.ImageViewer(new ImageViewerHorizontalViewLayout() { Rows = 1 });
          this.label5 = new System.Windows.Forms.Label();
          this.splitter4 = new System.Windows.Forms.Splitter();
          this.panel1.SuspendLayout();
          this.panel2.SuspendLayout();
          this.panel3.SuspendLayout();
          this.panel4.SuspendLayout();
          this.panel5.SuspendLayout();
          this.panel6.SuspendLayout();
          this.SuspendLayout();
          // 
          // panel1
          // 
          this.panel1.Controls.Add(this.propertyGridSearch);
          this.panel1.Controls.Add(this.label1);
          this.panel1.Controls.Add(this.panel2);
          this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
          this.panel1.Location = new System.Drawing.Point(0, 0);
          this.panel1.Name = "panel1";
          this.panel1.Size = new System.Drawing.Size(192, 713);
          this.panel1.TabIndex = 0;
          // 
          // propertyGridSearch
          // 
          this.propertyGridSearch.Cursor = System.Windows.Forms.Cursors.HSplit;
          this.propertyGridSearch.Dock = System.Windows.Forms.DockStyle.Fill;
          this.propertyGridSearch.HelpVisible = false;
          this.propertyGridSearch.LineColor = System.Drawing.SystemColors.ScrollBar;
          this.propertyGridSearch.Location = new System.Drawing.Point(0, 16);
          this.propertyGridSearch.Name = "propertyGridSearch";
          this.propertyGridSearch.PropertySort = System.Windows.Forms.PropertySort.Categorized;
          this.propertyGridSearch.Size = new System.Drawing.Size(192, 657);
          this.propertyGridSearch.TabIndex = 1;
          this.propertyGridSearch.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.propertyGridSearch_PropertyValueChanged);
          // 
          // label1
          // 
          this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
          this.label1.Dock = System.Windows.Forms.DockStyle.Top;
          this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
          this.label1.Location = new System.Drawing.Point(0, 0);
          this.label1.Name = "label1";
          this.label1.Size = new System.Drawing.Size(192, 16);
          this.label1.TabIndex = 0;
          this.label1.Text = "Search Params:";
          // 
          // panel2
          // 
          this.panel2.Controls.Add(this.buttonSearch);
          this.panel2.Controls.Add(this.buttonOptions);
          this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
          this.panel2.Location = new System.Drawing.Point(0, 673);
          this.panel2.Name = "panel2";
          this.panel2.Size = new System.Drawing.Size(192, 40);
          this.panel2.TabIndex = 2;
          // 
          // buttonSearch
          // 
          this.buttonSearch.Dock = System.Windows.Forms.DockStyle.Fill;
          this.buttonSearch.Location = new System.Drawing.Point(75, 0);
          this.buttonSearch.Name = "buttonSearch";
          this.buttonSearch.Size = new System.Drawing.Size(117, 40);
          this.buttonSearch.TabIndex = 0;
          this.buttonSearch.Text = "Search";
          this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
          // 
          // buttonOptions
          // 
          this.buttonOptions.Dock = System.Windows.Forms.DockStyle.Left;
          this.buttonOptions.Location = new System.Drawing.Point(0, 0);
          this.buttonOptions.Name = "buttonOptions";
          this.buttonOptions.Size = new System.Drawing.Size(75, 40);
          this.buttonOptions.TabIndex = 1;
          this.buttonOptions.Text = "Options";
          this.buttonOptions.Click += new System.EventHandler(this.buttonOptions_Click);
          // 
          // splitter1
          // 
          this.splitter1.Location = new System.Drawing.Point(192, 0);
          this.splitter1.Name = "splitter1";
          this.splitter1.Size = new System.Drawing.Size(3, 713);
          this.splitter1.TabIndex = 1;
          this.splitter1.TabStop = false;
          // 
          // panel3
          // 
          this.panel3.Controls.Add(this.listViewStudies);
          this.panel3.Controls.Add(this.label2);
          this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
          this.panel3.Location = new System.Drawing.Point(195, 0);
          this.panel3.Name = "panel3";
          this.panel3.Size = new System.Drawing.Size(693, 208);
          this.panel3.TabIndex = 2;
          // 
          // listViewStudies
          // 
          this.listViewStudies.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
          this.listViewStudies.Dock = System.Windows.Forms.DockStyle.Fill;
          this.listViewStudies.FullRowSelect = true;
          this.listViewStudies.GridLines = true;
          this.listViewStudies.HideSelection = false;
          this.listViewStudies.Location = new System.Drawing.Point(0, 16);
          this.listViewStudies.Name = "listViewStudies";
          this.listViewStudies.Size = new System.Drawing.Size(693, 192);
          this.listViewStudies.TabIndex = 0;
          this.listViewStudies.UseCompatibleStateImageBehavior = false;
          this.listViewStudies.View = System.Windows.Forms.View.Details;
          this.listViewStudies.Resize += new System.EventHandler(this.listViewStudies_Resize);
          this.listViewStudies.SelectedIndexChanged += new System.EventHandler(this.listViewStudies_SelectedIndexChanged);
          // 
          // columnHeader1
          // 
          this.columnHeader1.Text = "Patient Name";
          // 
          // columnHeader2
          // 
          this.columnHeader2.Text = "Patient ID";
          // 
          // columnHeader3
          // 
          this.columnHeader3.Text = "Accession #";
          // 
          // columnHeader4
          // 
          this.columnHeader4.Text = "Study Date";
          // 
          // columnHeader5
          // 
          this.columnHeader5.Text = "Refer Dr Name";
          // 
          // columnHeader6
          // 
          this.columnHeader6.Text = "Description";
          // 
          // label2
          // 
          this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
          this.label2.Dock = System.Windows.Forms.DockStyle.Top;
          this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
          this.label2.Location = new System.Drawing.Point(0, 0);
          this.label2.Name = "label2";
          this.label2.Size = new System.Drawing.Size(693, 16);
          this.label2.TabIndex = 1;
          this.label2.Text = "Studies Found: (Select item to retrieve series)";
          // 
          // splitter2
          // 
          this.splitter2.Dock = System.Windows.Forms.DockStyle.Top;
          this.splitter2.Location = new System.Drawing.Point(195, 208);
          this.splitter2.Name = "splitter2";
          this.splitter2.Size = new System.Drawing.Size(693, 3);
          this.splitter2.TabIndex = 3;
          this.splitter2.TabStop = false;
          // 
          // panel4
          // 
          this.panel4.Controls.Add(this.listViewSeries);
          this.panel4.Controls.Add(this.label3);
          this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
          this.panel4.Location = new System.Drawing.Point(195, 211);
          this.panel4.Name = "panel4";
          this.panel4.Size = new System.Drawing.Size(693, 219);
          this.panel4.TabIndex = 4;
          // 
          // listViewSeries
          // 
          this.listViewSeries.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10,
            this.columnHeader11});
          this.listViewSeries.Dock = System.Windows.Forms.DockStyle.Fill;
          this.listViewSeries.FullRowSelect = true;
          this.listViewSeries.GridLines = true;
          this.listViewSeries.HideSelection = false;
          this.listViewSeries.Location = new System.Drawing.Point(0, 16);
          this.listViewSeries.Name = "listViewSeries";
          this.listViewSeries.Size = new System.Drawing.Size(693, 203);
          this.listViewSeries.TabIndex = 1;
          this.listViewSeries.UseCompatibleStateImageBehavior = false;
          this.listViewSeries.View = System.Windows.Forms.View.Details;
          this.listViewSeries.Resize += new System.EventHandler(this.listViewSeries_Resize);
          this.listViewSeries.DoubleClick += new System.EventHandler(this.listViewSeries_DoubleClick);
          // 
          // columnHeader7
          // 
          this.columnHeader7.Text = "Date";
          // 
          // columnHeader8
          // 
          this.columnHeader8.Text = "Series Number";
          // 
          // columnHeader9
          // 
          this.columnHeader9.Text = "Description";
          // 
          // columnHeader10
          // 
          this.columnHeader10.Text = "Modality";
          // 
          // columnHeader11
          // 
          this.columnHeader11.Text = "Number of Instances";
          // 
          // label3
          // 
          this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
          this.label3.Dock = System.Windows.Forms.DockStyle.Top;
          this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
          this.label3.Location = new System.Drawing.Point(0, 0);
          this.label3.Name = "label3";
          this.label3.Size = new System.Drawing.Size(693, 16);
          this.label3.TabIndex = 0;
          this.label3.Text = "Series Found: (Double click to retrieve images)";
          // 
          // mainMenu1
          // 
          this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem1,
            this.menuItemOptions,
            this.menuItemHelp});
          // 
          // menuItem1
          // 
          this.menuItem1.Index = 0;
          this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemClearLog,
            this.menuItem3,
            this.menuItemFileExit});
          this.menuItem1.Text = "&File";
          // 
          // menuItemClearLog
          // 
          this.menuItemClearLog.Index = 0;
          this.menuItemClearLog.Text = "&Clear Log";
          this.menuItemClearLog.Click += new System.EventHandler(this.menuItemClearLog_Click);
          // 
          // menuItem3
          // 
          this.menuItem3.Index = 1;
          this.menuItem3.Text = "-";
          // 
          // menuItemFileExit
          // 
          this.menuItemFileExit.Index = 2;
          this.menuItemFileExit.Shortcut = System.Windows.Forms.Shortcut.AltF4;
          this.menuItemFileExit.Text = "&Exit";
          this.menuItemFileExit.Click += new System.EventHandler(this.menuItemFileExit_Click);
          // 
          // menuItemOptions
          // 
          this.menuItemOptions.Index = 1;
          this.menuItemOptions.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemIPv4,
            this.menuItemIPv6,
            this.menuItemIpv4Ipv6});
          this.menuItemOptions.Text = "&Options";
          this.menuItemOptions.Popup += new System.EventHandler(this.menuItemOptions_Popup);
          // 
          // menuItemIPv4
          // 
          this.menuItemIPv4.Index = 0;
          this.menuItemIPv4.Text = "IPv4";
          this.menuItemIPv4.Click += new System.EventHandler(this.menuItemIPv4_Click);
          // 
          // menuItemIPv6
          // 
          this.menuItemIPv6.Index = 1;
          this.menuItemIPv6.Text = "IPv6";
          this.menuItemIPv6.Click += new System.EventHandler(this.menuItemIPv6_Click);
          // 
          // menuItemIpv4Ipv6
          // 
          this.menuItemIpv4Ipv6.Index = 2;
          this.menuItemIpv4Ipv6.Text = "IPv4 or IPv6";
          this.menuItemIpv4Ipv6.Click += new System.EventHandler(this.menuItemIpv4Ipv6_Click);
          // 
          // menuItemHelp
          // 
          this.menuItemHelp.Index = 2;
          this.menuItemHelp.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemAbout});
          this.menuItemHelp.Text = "&Help";
          this.menuItemHelp.Click += new System.EventHandler(this.menuItemAbout_Click);
          // 
          // menuItemAbout
          // 
          this.menuItemAbout.Index = 0;
          this.menuItemAbout.Text = "&About";
          this.menuItemAbout.Click += new System.EventHandler(this.menuItemAbout_Click);
          // 
          // panel5
          // 
          this.panel5.Controls.Add(this.Log);
          this.panel5.Controls.Add(this.label4);
          this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
          this.panel5.Location = new System.Drawing.Point(195, 593);
          this.panel5.Name = "panel5";
          this.panel5.Size = new System.Drawing.Size(693, 120);
          this.panel5.TabIndex = 5;
          // 
          // Log
          // 
          this.Log.Dock = System.Windows.Forms.DockStyle.Fill;
          this.Log.Location = new System.Drawing.Point(0, 16);
          this.Log.Name = "Log";
          this.Log.ReadOnly = true;
          this.Log.Size = new System.Drawing.Size(693, 104);
          this.Log.TabIndex = 1;
          this.Log.Text = "";
          // 
          // label4
          // 
          this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
          this.label4.Dock = System.Windows.Forms.DockStyle.Top;
          this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
          this.label4.Location = new System.Drawing.Point(0, 0);
          this.label4.Name = "label4";
          this.label4.Size = new System.Drawing.Size(693, 16);
          this.label4.TabIndex = 0;
          this.label4.Text = "Log:";
          // 
          // splitter3
          // 
          this.splitter3.Dock = System.Windows.Forms.DockStyle.Bottom;
          this.splitter3.Location = new System.Drawing.Point(195, 591);
          this.splitter3.Name = "splitter3";
          this.splitter3.Size = new System.Drawing.Size(693, 2);
          this.splitter3.TabIndex = 6;
          this.splitter3.TabStop = false;
          // 
          // panel6
          // 
          this.panel6.Controls.Add(this.imageList);
          this.panel6.Controls.Add(this.label5);
          this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
          this.panel6.Location = new System.Drawing.Point(195, 430);
          this.panel6.Name = "panel6";
          this.panel6.Size = new System.Drawing.Size(693, 161);
          this.panel6.TabIndex = 7;
          this.panel6.SizeChanged += new System.EventHandler(this.panel6_SizeChanged);
          // 
          // ImageList
          // 
          this.imageList.AutoDisposeImages = false;
          this.imageList.Dock = System.Windows.Forms.DockStyle.Top;
          this.imageList.Location = new System.Drawing.Point(0, 16);
          this.imageList.Name = "ImageList";
          this.imageList.Size = new System.Drawing.Size(693, 64);
          this.imageList.TabIndex = 7;
          this.imageList.SelectedItemsChanged += new System.EventHandler(this.ImageList_SelectedItemsChanged);
          // 
          // label5
          // 
          this.label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
          this.label5.Dock = System.Windows.Forms.DockStyle.Top;
          this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
          this.label5.Location = new System.Drawing.Point(0, 0);
          this.label5.Name = "label5";
          this.label5.Size = new System.Drawing.Size(693, 16);
          this.label5.TabIndex = 0;
          this.label5.Text = "Images:";
          // 
          // splitter4
          // 
          this.splitter4.Dock = System.Windows.Forms.DockStyle.Top;
          this.splitter4.Location = new System.Drawing.Point(195, 430);
          this.splitter4.Name = "splitter4";
          this.splitter4.Size = new System.Drawing.Size(693, 3);
          this.splitter4.TabIndex = 8;
          this.splitter4.TabStop = false;
          // 
          // MainForm
          // 
          this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
          this.ClientSize = new System.Drawing.Size(888, 713);
          this.Controls.Add(this.splitter4);
          this.Controls.Add(this.panel6);
          this.Controls.Add(this.panel4);
          this.Controls.Add(this.splitter3);
          this.Controls.Add(this.panel5);
          this.Controls.Add(this.splitter2);
          this.Controls.Add(this.panel3);
          this.Controls.Add(this.splitter1);
          this.Controls.Add(this.panel1);
          this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
          this.Menu = this.mainMenu1;
          this.MinimumSize = new System.Drawing.Size(640, 480);
          this.Name = "MainForm";
          this.RightToLeftLayout = true;
          this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
          this.Text = "LEADTOOLS Dicom Client Demo - C#";
          this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
          this.Load += new System.EventHandler(this.MainForm_Load);
          this.Closing += new System.ComponentModel.CancelEventHandler(this.MainForm_Closing);
          this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
          this.Resize += new System.EventHandler(this.MainForm_Resize);
          this.panel1.ResumeLayout(false);
          this.panel2.ResumeLayout(false);
          this.panel3.ResumeLayout(false);
          this.panel4.ResumeLayout(false);
          this.panel5.ResumeLayout(false);
          this.panel6.ResumeLayout(false);
          this.ResumeLayout(false);

      }
      #endregion

      /// <summary>
      /// The main entry point for the application.
      /// </summary>
      [STAThread]
      static void Main(string[] args)
      {
         if (!Support.SetLicense())
            return;

         if (RasterSupport.IsLocked(RasterSupportType.DicomCommunication))
         {
            MessageBox.Show(String.Format("{0} Support is locked!", RasterSupportType.DicomCommunication.ToString()), "Warning");
            return;
         }

         //if (DemosGlobal.MustRestartElevated())
         //{
         //   DemosGlobal.TryRestartElevated(args);
         //   return;
         //}

         Utils.EngineStartup();
         Utils.DicomNetStartup();

         try
         {
             Application.Run(new MainForm());
         }
         catch (Exception)
         {
         }
         finally
         {
             Utils.EngineShutdown();
             Utils.DicomNetShutdown();
         }
      }

      // Raster viewer object.
      private ImageViewer _viewer;

      private void LoadSettings( )
      {
         RegistryKey user = Registry.CurrentUser;
         RegistryKey settings = user.OpenSubKey(_settingsLocation, true);
         if (settings == null)
         {
            //
            // We haven't saved any setting yet.  Will use the default
            //  settings.
            return;
         }

         server.AETitle = Convert.ToString(settings.GetValue("ServerAE"));
         server.Port = Convert.ToInt32(settings.GetValue("ServerPort", 104));

         string sValue = Convert.ToString(settings.GetValue("ServerIpType"));

         if (string.IsNullOrEmpty(sValue))
            server.IpType = DicomNetIpTypeFlags.Ipv4;
         else
            server.IpType = (DicomNetIpTypeFlags)DemosGlobal.StringToEnum(typeof(DicomNetIpTypeFlags), sValue);
         _ipType = server.IpType;

         server.Address = IPAddress.Parse(Convert.ToString(settings.GetValue("ServerAddress", "127.0.0.1")));
         server.Timeout = Convert.ToInt32(settings.GetValue("ServerTimeout", 0));
         AETitle = Convert.ToString(settings.GetValue("ClientAE"));
         Port = Convert.ToInt32(settings.GetValue("ClientPort", 1000));
         GroupLengthDataElements = Convert.ToBoolean(settings.GetValue("GroupLengthDataElements", false));
      }

      private void SaveSettings( )
      {
         RegistryKey user = Registry.CurrentUser;
         RegistryKey settings = user.OpenSubKey(_settingsLocation, true);
         if (settings == null)
         {
            settings = user.CreateSubKey(_settingsLocation);
         }

         settings.SetValue("ServerAE", server.AETitle);
         settings.SetValue("ServerPort", server.Port);
         settings.SetValue("ServerAddress", server.Address.ToString());
         settings.SetValue("ServerTimeout", server.Timeout);
         settings.SetValue("ClientAE", AETitle);
         settings.SetValue("ClientPort", Port);
         settings.SetValue("ServerIpType", server.IpType.ToString());
         settings.SetValue("GroupLengthDataElements", GroupLengthDataElements);
         settings.Close();
      }

      private void UpdateCFindOptions()
      {
#if LEADTOOLS_V19_OR_LATER
         cfind.Flags = DicomNetFlags.None;
         if (GroupLengthDataElements)
         {
            cfind.Flags |= DicomNetFlags.SendDataWithGroupLengthStandardDataElements;
         }
#endif
      }

      private void MainForm_Load(object sender, System.EventArgs e)
      {
#if LTV20_CONFIG
         _settingsLocation = @"SOFTWARE\LEAD Technologies, Inc.\20\CSharp__DicomFindMove20";
#elif LTV19_CONFIG
         _settingsLocation = @"SOFTWARE\LEAD Technologies, Inc.\19\CSharp__DicomFindMove19";
#endif

         // Initialize the raster viewer object
         _viewer = new ImageViewer();
         _viewer.Dock = DockStyle.Fill;
         panel6.Controls.Add(_viewer);
         _viewer.BringToFront();

         cfind.ImplementationClass = CONFIGURATION_IMPLEMENTATIONCLASS;
         cfind.ProtocolVersion = CONFIGURATION_PROTOCOLVERSION;
         cfind.ImplementationVersionName = CONFIGURATION_IMPLEMENTATIONVERSIONNAME;
         LoadSettings();
         UpdateCFindOptions();

         SizeColumns(listViewStudies);
         SizeColumns(listViewSeries);

         cfind.Status += new StatusEventHandler(cfind_Status);
         cfind.FindComplete += new FindCompleteEventHandler(cfind_FindComplete);
         cfind.MoveComplete += new MoveCompleteEventHandler(cfind_MoveComplete);

         propertyGridSearch.SelectedObject = query;
      }


      private void buttonOptions_Click(object sender, System.EventArgs e)
      {
         OptionsDialog options = new OptionsDialog();

         options.ServerIp.Text = server.Address.ToString();
         options.ServerAE.Text = server.AETitle;
         options.ServerPort.Text = server.Port.ToString();
         options.Timeout.Text = server.Timeout.ToString();
         options.ClientAE.Text = AETitle;
         options.ClientPort.Text = Port.ToString();
         options.GroupLengthDataElements = GroupLengthDataElements;
         if(options.ShowDialog() == DialogResult.OK)
         {
            server.AETitle = options.ServerAE.Text;
            server.Port = Convert.ToInt32(options.ServerPort.Text);
            server.Address = IPAddress.Parse(options.ServerIp.Text);
            server.Timeout = Convert.ToInt32(options.Timeout.Text);
            AETitle = options.ClientAE.Text;
            Port = Convert.ToInt32(options.ClientPort.Text);
            GroupLengthDataElements = options.GroupLengthDataElements;
            SaveSettings();
            UpdateCFindOptions();
         }
      }

      private void menuItemFileExit_Click(object sender, System.EventArgs e)
      {
         Application.Exit();
      }

      private void listViewStudies_Resize(object sender, System.EventArgs e)
      {
         SizeColumns(listViewStudies);
      }

      private void SizeColumns(ListView lv)
      {
         foreach(ColumnHeader header in lv.Columns)
         {
            header.Width = lv.Width / lv.Columns.Count;
         }
      }

      private void listViewSeries_Resize(object sender, System.EventArgs e)
      {
         SizeColumns(listViewSeries);
      }

      private void MainForm_Resize(object sender, System.EventArgs e)
      {
         panel3.Height = Convert.ToInt32(ClientSize.Height * .15);
         panel4.Height = Convert.ToInt32(ClientSize.Height * .15);
         panel5.Height = Convert.ToInt32(ClientSize.Height * .15);
         panel6.Height = Convert.ToInt32(ClientSize.Height * .55);
      }

      private void buttonSearch_Click(object sender, System.EventArgs e)
      {
         _viewer.Image = null;
         listViewStudies.Items.Clear();
         listViewSeries.Items.Clear();
         imageList.Items.Clear();
         EnableItems(false);
         cfind.Find(server, FindType.Study, dcmQuery, AETitle);
      }

      public void LogText(string action, string logText)
      {
         if(this.InvokeRequired)
         {
            this.Invoke(new AddLog(LogText),
               new object[] { action, logText });
         }
         else
         {
            AddAction(action);
            Log.AppendText(logText);
            Log.AppendText("\r\n");
         }
      }

      private void AddAction(string action)
      {
         System.Drawing.Color oldColor = Log.SelectionColor;

         Log.SelectionLength = 0;
         Log.SelectionStart = Log.Text.Length;
         Log.SelectionColor = Color.Blue;
         Log.SelectionFont = new Font(Log.SelectionFont, FontStyle.Bold);
         Log.AppendText(action + ": ");

         Log.SelectionColor = oldColor;
      }

      private void cfind_Status(object sender, StatusEventArgs e)
      {
         string message = "Unknown Error";
         String action = "";
         bool done = false;

         if(e.Type == StatusType.Error)
         {
            action = "Error";
            message = "Error occurred.\r\n";
            message += "\tError code is:\t" + e.Error.ToString();
         }
         else
         {
            switch(e.Type)
            {
               case StatusType.ConnectFailed:
                  action = "Connect";
                  message = "Operation failed.";
                  done = true;
                  break;
               case StatusType.ConnectSucceeded:
                  action = "Connect";
                  message = "Operation succeeded.\r\n";
                  message += "\tPeer Address:\t" + e.PeerIP.ToString() + "\r\n";
                  message += "\tPeer Port:\t\t" + e.PeerPort.ToString();
                  break;
               case StatusType.SendAssociateRequest:
                  action = "Associate Request";
                  message = "Request sent.";
                  break;
               case StatusType.ReceiveAssociateAccept:
                  action = "Associate Accept";
                  message = "Received.\r\n";
                  message += "\tCalling AE:\t" + e.CallingAE + "\r\n";
                  message += "\tCalled AE:\t" + e.CalledAE;
                  break;
               case StatusType.ReceiveAssociateRequest:
                  action = "Associate Request";
                  message = "Received.\r\n";
                  message += "\tCalling AE:\t" + e.CallingAE + "\r\n";
                  message += "\tCalled AE:\t" + e.CalledAE;
                  break;
               case StatusType.ReceiveAssociateReject:
                  action = "Associate Reject";
                  message = "Received Associate Reject!";
                  message += "\r\n\tSource: " + e.Source.ToString();
                  message += "\r\n\tResult: " + e.Result.ToString();
                  message += "\r\n\tReason: " + e.Reason.ToString();
                  done = true;
                  break;
               case StatusType.AbstractSyntaxNotSupported:
                  action = "Error";
                  message = "Abstract Syntax NOT supported!";
                  done = true;
                  break;
               case StatusType.SendCFindRequest:
                  action = "C-FIND";
                  message = "Sending request";
                  break;
               case StatusType.ReceiveCFindResponse:
                  action = "C-FIND";
                  if(e.Error == DicomExceptionCode.Success)
                  {
                     message = "Operation completed successfully.";
                  }
                  else
                  {

                     if(e.Status == DicomCommandStatusType.Pending)
                     {
                        message = "Additional operations pending.";
                     }
                     else
                     {
                        message = "Error in response Status code is: " + e.Status.ToString();
                     }
                  }
                  break;
               case StatusType.ConnectionClosed:
                  action = "Connect";
                  message = "Network Connection closed!";
                  done = true;
                  break;
               case StatusType.ProcessTerminated:
                  action = "";
                  message = "Process has been terminated!";
                  done = true;
                  break;
               case StatusType.SendReleaseRequest:
                  action = "Release Request";
                  message = "Request sent.";
                  break;
               case StatusType.ReceiveReleaseResponse:
                  action = "Release Response";
                  message = "Response received.";
                  done = true;
                  break;
               case StatusType.SendCMoveRequest:
                  action = "C-MOVE";
                  message = "Sending request";
                  break;
               case StatusType.ReceiveCMoveResponse:
                  action = "C-MOVE";
                  message = "Received response\r\n";
                  message += "\tStatus: " + e.Status.ToString() + "\r\n";
                  message += "\tNumber Completed: " + e.NumberCompleted.ToString() + "\r\n";
                  message += "\tNumber Remaining: " + e.NumberRemaining.ToString();
                  break;
               case StatusType.SendCStoreResponse:
                  action = "C-STORE";
                  message = "Sending response";
                  break;
               case StatusType.ReceiveCStoreRequest:
                  action = "C-STORE";
                  message = "Received request";
                  break;
               case StatusType.Timeout:
                  message = "Communication timeout. Process will be terminated.";
                  done = true;
                  break;
            }
         }
         LogText(action, message);
         if(done)
         {
            EnableItems(true);
         }
      }

      private void propertyGridSearch_PropertyValueChanged(object s, System.Windows.Forms.PropertyValueChangedEventArgs e)
      {
         switch(e.ChangedItem.Label)
         {
            case "PatientName":
               dcmQuery.PatientName = e.ChangedItem.Value.ToString();
               break;
            case "PatientID":
               dcmQuery.PatientID = e.ChangedItem.Value.ToString();
               break;
            case "StudyID":
               dcmQuery.StudyID = e.ChangedItem.Value.ToString();
               break;
            case "StudyStartDate":
               dcmQuery.StudyStartDate = (DateTime)e.ChangedItem.Value;
               break;
            case "StudyEndDate":
               dcmQuery.StudyEndDate = Convert.ToDateTime(e.ChangedItem.Value);
               break;
            case "ReferringPhysiciansName":
               dcmQuery.ReferringPhysiciansName = e.ChangedItem.Value.ToString();
               break;
            case "AccessionNo":
               dcmQuery.AccessionNo = e.ChangedItem.Value.ToString();
               break;
            case "StudyInstanceUid":
               dcmQuery.StudyInstanceUid = e.ChangedItem.Value.ToString();
               break;
         }
      }

      public delegate void StartUpdateDelegate(ListView lv);
      private void StartUpdate(ListView lv)
      {
         if(InvokeRequired)
         {
            Invoke(new StartUpdateDelegate(StartUpdate), lv);
         }
         else
         {
            lv.Items.Clear();
            lv.BeginUpdate();
         }
      }

      public delegate void EndUpdateDelegate(ListView lv);
      private void EndUpdate(ListView lv)
      {
         if(InvokeRequired)
         {
            Invoke(new EndUpdateDelegate(EndUpdate), lv);
         }
         else
         {
            lv.EndUpdate();
         }
      }

      public delegate void AddStudyItemDelegate(DicomDataSet ds);
      private void AddStudyItem(DicomDataSet ds)
      {
         ListViewItem item;
         string tagValue;

         if(InvokeRequired)
         {
            Invoke(new AddStudyItemDelegate(AddStudyItem), ds);
         }
         else
         {
            tagValue = Utils.GetStringValue(ds, DemoDicomTags.PatientName);
            item = listViewStudies.Items.Add(tagValue);

            tagValue = Utils.GetStringValue(ds, DemoDicomTags.PatientID);
            item.SubItems.Add(tagValue);

            tagValue = Utils.GetStringValue(ds, DemoDicomTags.AccessionNumber);
            item.SubItems.Add(tagValue);

            tagValue = Utils.GetStringValue(ds, DemoDicomTags.StudyDate);
            item.SubItems.Add(tagValue);

            tagValue = Utils.GetStringValue(ds, DemoDicomTags.ReferringPhysicianName);
            item.SubItems.Add(tagValue);

            tagValue = Utils.GetStringValue(ds, DemoDicomTags.StudyDescription);
            item.SubItems.Add(tagValue);

            item.Tag = Utils.GetStringValue (ds, DemoDicomTags.StudyInstanceUID);
         }
      }

      public delegate void AddSeriesItemDelegate(DicomDataSet ds);
      private void AddSeriesItem(DicomDataSet ds)
      {
         ListViewItem item;
         string tagValue;

         if(InvokeRequired)
         {
            Invoke(new AddSeriesItemDelegate(AddSeriesItem), ds);
         }
         else
         {
            tagValue = Utils.GetStringValue(ds, DemoDicomTags.SeriesDate);
            item = listViewSeries.Items.Add(tagValue);

            tagValue = Utils.GetStringValue(ds, DemoDicomTags.SeriesNumber);
            item.SubItems.Add(tagValue);

            tagValue = Utils.GetStringValue(ds, DemoDicomTags.SeriesDescription);
            item.SubItems.Add(tagValue);

            tagValue = Utils.GetStringValue(ds, DemoDicomTags.Modality);
            item.SubItems.Add(tagValue);

            tagValue = Utils.GetStringValue(ds, DemoDicomTags.NumberOfSeriesRelatedInstances);
            item.SubItems.Add(tagValue);

            item.Tag = Utils.GetStringValue (ds, DemoDicomTags.SeriesInstanceUID);
         }
      }

      private void cfind_FindComplete(object sender, FindCompleteEventArgs e)
      {
         switch(e.Type)
         {
            case FindType.Study:
               StartUpdate(listViewStudies);
               foreach(DicomDataSet ds in e.Datasets)
               {
                  AddStudyItem(ds);
               }
               EndUpdate(listViewStudies);
               break;

            case FindType.StudySeries:
               StartUpdate(listViewSeries);
               foreach(DicomDataSet ds in e.Datasets)
               {
                  AddSeriesItem(ds);
               }
               EndUpdate(listViewSeries);
               break;
         }

      }

      private void listViewStudies_SelectedIndexChanged(object sender, System.EventArgs e)
      {
         if(listViewStudies.SelectedItems.Count == 0)
            return;

         string study = listViewStudies.SelectedItems[0].Tag as string;

         imageList.Items.Clear();
         _viewer.Image = null;
         if(null != study && study.Length > 0)
         {
            CFindQuery query = new CFindQuery();

            query.StudyInstanceUid = study;
            query.PatientID = listViewStudies.SelectedItems[0].SubItems [1].Text;
            EnableItems(false);
            cfind.Find(server, FindType.StudySeries, query, AETitle);
         }
      }

      private void panel6_SizeChanged(object sender, System.EventArgs e)
      {
         imageList.Height = Convert.ToInt32(panel6.ClientSize.Height * .25);
      }

      private void listViewSeries_DoubleClick(object sender, System.EventArgs e)
      {
         if(listViewStudies.SelectedItems.Count == 0)
            return;

         imageList.Items.Clear();

         string patientID, studyInstance, seriesInstance;
         
         patientID = listViewStudies.SelectedItems[0].SubItems [1].Text;
         studyInstance = listViewStudies.SelectedItems[0].Tag as string;
         seriesInstance = listViewSeries.SelectedItems[0].Tag as string ;

         EnableItems(false);
         cfind.MoveSeries(server, AETitle, patientID, studyInstance, seriesInstance, Port);
      }


      private void cfind_MoveComplete(object sender, MoveCompleteEventArgs e)
      {
         if(InvokeRequired)
         {
            Invoke(new MoveCompleteEventHandler(cfind_MoveComplete), sender, e);
         }
         else
         {
            imageList.BeginUpdate();
            foreach(DicomDataSet ds in e.Datasets)
            {
               DicomElement element;

               try
               {
                  element = ds.FindFirstElement(null, DemoDicomTags.PixelData, true);
                  if(element == null)
                     continue;

                  for(int i = 0; i < ds.GetImageCount(element); i++)
                  {
                     RasterImage image;
                     DicomImageInformation info = ds.GetImageInformation(element, i);

                     image = ds.GetImage(element, i, 0, info.IsGray ? RasterByteOrder.Gray : RasterByteOrder.Rgb, 
                                         DicomGetImageFlags.AutoApplyModalityLut |
                                         DicomGetImageFlags.AutoApplyVoiLut      | 
                                         DicomGetImageFlags.AllowRangeExpansion);
                     if(image != null)
                     {
                        ImageViewerItem item = new ImageViewerItem()
                        {
                           Text = "",
                           Image = image
                        };
                        
                        
                        imageList.Items.Insert(imageList.Items.Count, item);
                     }
                  }
               }
               catch(DicomException de)
               {
                  StatusEventArgs eventArg = new StatusEventArgs();

                  eventArg._Error = de.Code;
                  eventArg._Type = StatusType.Error;
                  cfind_Status(this, eventArg);
               }
            }
            if(imageList.Items.Count > 0)
            {
               imageList.Items[0].IsSelected = true;
               SetImage(imageList.Items.GetSelected()[0]);
            }
            imageList.EndUpdate();
         }

      }

      public delegate void EnableItemsDelegate(bool enable);
      public void EnableItems(bool enable)
      {
         if(InvokeRequired)
         {
            Invoke(new EnableItemsDelegate(EnableItems), enable);
         }
         else
         {
            listViewStudies.Enabled = enable;
            listViewSeries.Enabled = enable;
            buttonSearch.Enabled = enable;
         }
      }

      private void menuItemClearLog_Click(object sender, System.EventArgs e)
      {
         Log.Clear();
      }

      private void menuItemAbout_Click(object sender, System.EventArgs e)
      {
         using (AboutDialog aboutDialog = new AboutDialog("Dicom Client", ProgrammingInterface.CS))
            aboutDialog.ShowDialog(this);
      }

      private void SetImage(ImageViewerItem item)
      {
         _viewer.Image = item.Image.Clone();
      }

      private void MainForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
      {
         cfind.Terminate();
      }

      private void ImageList_SelectedItemsChanged(object sender, System.EventArgs e)
      {
         if(imageList.Items.GetSelected().Length > 0)
            SetImage(imageList.Items.GetSelected()[0]);
      }

      private void menuItemIPv4_Click(object sender, EventArgs e)
      {
         if (_ipType != DicomNetIpTypeFlags.Ipv4)
         {
            _ipType = DicomNetIpTypeFlags.Ipv4;
            server.IpType = _ipType;
            SaveSettings();
         }
      }

      private void menuItemIPv6_Click(object sender, EventArgs e)
      {
         if (_ipType != DicomNetIpTypeFlags.Ipv6)
         {
            _ipType = DicomNetIpTypeFlags.Ipv6;
            server.IpType = _ipType;
            SaveSettings();
         }
      }

      private void menuItemIpv4Ipv6_Click(object sender, EventArgs e)
      {
         if (_ipType != DicomNetIpTypeFlags.Ipv4OrIpv6)
         {
            _ipType = DicomNetIpTypeFlags.Ipv4OrIpv6;
            server.IpType = _ipType;
            SaveSettings();
         }
      }

      private void menuItemOptions_Popup(object sender, EventArgs e)
      {
         menuItemIPv4.Checked = (_ipType == DicomNetIpTypeFlags.Ipv4);
         menuItemIPv6.Checked = (_ipType == DicomNetIpTypeFlags.Ipv6);
         menuItemIpv4Ipv6.Checked = (_ipType == DicomNetIpTypeFlags.Ipv4OrIpv6);
         menuItemIpv4Ipv6.Enabled = DemosGlobal.IsOnVistaOrLater;
      }

      private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
      {
          if (cfind != null)
          {
              cfind.CloseForced(true);
          }
      }
   }
}
