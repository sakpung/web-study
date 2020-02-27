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
using System.Text;

using Leadtools;
using Leadtools.Demos;
using System.IO;
using Leadtools.Common.JobProcessor;
using System.Reflection;
using System.Xml;
using Microsoft.Win32;
using System.Resources;
using JobProcessorDashboardDemo.Properties;

namespace JobProcessorDashboardDemo
{
   /// <summary>
   /// Summary description for MainForm.
   /// </summary>
   public class MainForm : System.Windows.Forms.Form
   {
      private System.Windows.Forms.MainMenu _mmMain;
      private System.Windows.Forms.MenuItem _miFile;
      private System.Windows.Forms.MenuItem _miHelp;
      private System.Windows.Forms.MenuItem _miHelpAbout;
      private System.Windows.Forms.MenuItem _miFileExit;
      private System.Windows.Forms.MenuItem _miFileSep1;
      private System.Windows.Forms.MenuItem _miFileClose;
      private System.Windows.Forms.MenuItem _mmFileSep2;
      private System.Windows.Forms.MenuItem _miWindow;
      private System.Windows.Forms.MenuItem _miWindowCascade;
      private System.Windows.Forms.MenuItem _miWindowTileHorizontally;
      private System.Windows.Forms.MenuItem _miWindowTileVertically;
      private System.Windows.Forms.MenuItem _miWindowArrangeIcons;
      private System.Windows.Forms.MenuItem _miWindowCloseAll;
      private MenuItem _miShowJobViewer;
      private MenuItem _miAddWorker;
      private MenuItem _miTools;
      private IContainer components;
      string _hostAddress = string.Empty;
      string _IISAddress = string.Empty;
      private MenuItem _miAddMultimediaWorker;
      private MenuItem _miAddOCRWorker;
      bool _userHost;
      bool bOCRInstalled = false;
      bool bMultimediaInstalled = false;

#if LTV175_CONFIG
      string[] MultimediaKeys = new string[] { @"LEAD Technologies, Inc.\17.5\LEADTOOLS Multimedia 17.5", @"LEAD Technologies, Inc.\17.5\LEADTOOLS Multimedia EVAL 17.5" };
      string[] OCRKeys = new string[] { @"LEAD Technologies, Inc.\OCRPathAdvantage175" };
#endif
#if LTV18_CONFIG
      string[] MultimediaKeys = new string[] { @"LEAD Technologies, Inc.\18\LEADTOOLS Multimedia 18", @"LEAD Technologies, Inc.\18\LEADTOOLS Multimedia EVAL 18" };
      string[] OCRKeys = new string[] { @"LEAD Technologies, Inc.\OCRPathAdvantage18" };
#endif

#if LTV19_CONFIG
      string[] MultimediaKeys = new string[] { @"LEAD Technologies, Inc.\19\LEADTOOLS Multimedia 19", @"LEAD Technologies, Inc.\19\LEADTOOLS Multimedia EVAL 19", @"LEAD Technologies, Inc.\19\LEADTOOLS Medical Multimedia Module 19", @"LEAD Technologies, Inc.\19\LEADTOOLS Multimedia Suite 19" };
      string[] OCRKeys = new string[] { @"LEAD Technologies, Inc.\OCRPathAdvantage19" };
#endif

#if LTV20_CONFIG
      string[] MultimediaKeys = new string[] { @"LEAD Technologies, Inc.\20\LEADTOOLS Multimedia 20", @"LEAD Technologies, Inc.\20\LEADTOOLS Multimedia EVAL 20", @"LEAD Technologies, Inc.\20\LEADTOOLS Medical Multimedia Module 20", @"LEAD Technologies, Inc.\20\LEADTOOLS Multimedia Suite 20" };
      string[] OCRKeys = new string[] { @"LEAD Technologies, Inc.\OCRPathLEAD20" };
#endif

      public MainForm(string address, bool userHost)
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
      }

      public MainForm()
      {
         InitializeComponent();
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
         this._mmMain = new System.Windows.Forms.MainMenu(this.components);
         this._miFile = new System.Windows.Forms.MenuItem();
         this._miFileSep1 = new System.Windows.Forms.MenuItem();
         this._miFileClose = new System.Windows.Forms.MenuItem();
         this._mmFileSep2 = new System.Windows.Forms.MenuItem();
         this._miFileExit = new System.Windows.Forms.MenuItem();
         this._miTools = new System.Windows.Forms.MenuItem();
         this._miAddWorker = new System.Windows.Forms.MenuItem();
         this._miAddMultimediaWorker = new System.Windows.Forms.MenuItem();
         this._miAddOCRWorker = new System.Windows.Forms.MenuItem();
         this._miShowJobViewer = new System.Windows.Forms.MenuItem();
         this._miWindow = new System.Windows.Forms.MenuItem();
         this._miWindowCascade = new System.Windows.Forms.MenuItem();
         this._miWindowTileHorizontally = new System.Windows.Forms.MenuItem();
         this._miWindowTileVertically = new System.Windows.Forms.MenuItem();
         this._miWindowArrangeIcons = new System.Windows.Forms.MenuItem();
         this._miWindowCloseAll = new System.Windows.Forms.MenuItem();
         this._miHelp = new System.Windows.Forms.MenuItem();
         this._miHelpAbout = new System.Windows.Forms.MenuItem();
         this.SuspendLayout();
         // 
         // _mmMain
         // 
         this._mmMain.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._miFile,
            this._miTools,
            this._miWindow,
            this._miHelp});
         // 
         // _miFile
         // 
         this._miFile.Index = 0;
         this._miFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._miFileSep1,
            this._miFileClose,
            this._mmFileSep2,
            this._miFileExit});
         this._miFile.Text = "&File";
         // 
         // _miFileSep1
         // 
         this._miFileSep1.Index = 0;
         this._miFileSep1.Text = "-";
         // 
         // _miFileClose
         // 
         this._miFileClose.Index = 1;
         this._miFileClose.Text = "&Close";
         this._miFileClose.Click += new System.EventHandler(this._miFileClose_Click);
         // 
         // _mmFileSep2
         // 
         this._mmFileSep2.Index = 2;
         this._mmFileSep2.Text = "-";
         // 
         // _miFileExit
         // 
         this._miFileExit.Index = 3;
         this._miFileExit.Text = "E&xit";
         this._miFileExit.Click += new System.EventHandler(this._miFileExit_Click);
         // 
         // _miTools
         // 
         this._miTools.Index = 1;
         this._miTools.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._miAddWorker,
            this._miShowJobViewer});
         this._miTools.Text = "&Tools";
         // 
         // _miAddWorker
         // 
         this._miAddWorker.Index = 0;
         this._miAddWorker.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._miAddMultimediaWorker,
            this._miAddOCRWorker});
         this._miAddWorker.Text = "Add Worker";
         // 
         // _miAddMultimediaWorker
         // 
         this._miAddMultimediaWorker.Index = 0;
         this._miAddMultimediaWorker.Shortcut = System.Windows.Forms.Shortcut.CtrlM;
         this._miAddMultimediaWorker.Text = "Add Multimedia Worker";
         this._miAddMultimediaWorker.Click += new System.EventHandler(this._miAddMultimediaWorker_Click);
         // 
         // _miAddOCRWorker
         // 
         this._miAddOCRWorker.Index = 1;
         this._miAddOCRWorker.Shortcut = System.Windows.Forms.Shortcut.CtrlO;
         this._miAddOCRWorker.Text = "Add OCR Worker";
         this._miAddOCRWorker.Click += new System.EventHandler(this._miAddOCRWorker_Click);
         // 
         // _miShowJobViewer
         // 
         this._miShowJobViewer.Index = 1;
         this._miShowJobViewer.Text = "Show Job Viewer";
         this._miShowJobViewer.Click += new System.EventHandler(this._miShowJobViewer_Click);
         // 
         // _miWindow
         // 
         this._miWindow.Index = 2;
         this._miWindow.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._miWindowCascade,
            this._miWindowTileHorizontally,
            this._miWindowTileVertically,
            this._miWindowArrangeIcons,
            this._miWindowCloseAll});
         this._miWindow.Text = "&Windows";
         // 
         // _miWindowCascade
         // 
         this._miWindowCascade.Index = 0;
         this._miWindowCascade.Text = "&Cascade";
         this._miWindowCascade.Click += new System.EventHandler(this._miWindow_Click);
         // 
         // _miWindowTileHorizontally
         // 
         this._miWindowTileHorizontally.Index = 1;
         this._miWindowTileHorizontally.Text = "Tile &Horizontally";
         this._miWindowTileHorizontally.Click += new System.EventHandler(this._miWindow_Click);
         // 
         // _miWindowTileVertically
         // 
         this._miWindowTileVertically.Index = 2;
         this._miWindowTileVertically.Text = "Tile &Vertically";
         this._miWindowTileVertically.Click += new System.EventHandler(this._miWindow_Click);
         // 
         // _miWindowArrangeIcons
         // 
         this._miWindowArrangeIcons.Index = 3;
         this._miWindowArrangeIcons.Text = "Arrange &Icons";
         this._miWindowArrangeIcons.Click += new System.EventHandler(this._miWindow_Click);
         // 
         // _miWindowCloseAll
         // 
         this._miWindowCloseAll.Index = 4;
         this._miWindowCloseAll.Text = "Close &All";
         this._miWindowCloseAll.Click += new System.EventHandler(this._miWindow_Click);
         // 
         // _miHelp
         // 
         this._miHelp.Index = 3;
         this._miHelp.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._miHelpAbout});
         this._miHelp.Text = "&Help";
         // 
         // _miHelpAbout
         // 
         this._miHelpAbout.Index = 0;
         this._miHelpAbout.Text = "&About";
         this._miHelpAbout.Click += new System.EventHandler(this._miHelpAbout_Click);
         // 
         // MainForm
         // 
         this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
         this.ClientSize = new System.Drawing.Size(881, 485);
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.IsMdiContainer = true;
         this.Menu = this._mmMain;
         this.Name = "MainForm";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         this.Text = "JobProcessor Dashboard C# Demo";
         this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
         this.Load += new System.EventHandler(this.MainForm_Load);
         this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
         this.ResumeLayout(false);

      }
      #endregion

      /// <summary>
      /// The main entry point for the application.
      /// </summary>
      [STAThread]
      static void Main()
      {
         Application.EnableVisualStyles();

         bool userHost = true;
         string address = string.Empty;

         Properties.Settings settings = new Properties.Settings();
         if (settings["HostAddress"] != null) address = settings.HostAddress;
         if (settings["UserHost"] != null) userHost = settings.UserHost;

         if (String.IsNullOrEmpty(address))
         {
            address = string.Format("http://{0}:8181/LEADTOOLSJobProcessorServices", Environment.MachineName);
         }

         ConnectionForm connectionForm = new ConnectionForm(userHost, address, string.Empty, "LEADTOOLS C# JobProcessor Administrator Demo", true, true);
         connectionForm.Type = ServicesType.JobProcessorJobService;

         if (connectionForm.ShowDialog() == DialogResult.OK)
         {
           Application.Run(new MainForm(connectionForm.Address, connectionForm.UserHost));
         }
      }

      ClientForm clientForm = null;
      int workerCounter = 0;

      private void MainForm_Load(object sender, System.EventArgs e)
      {
         if (Properties.Settings.Default.ShowAbout)
         {
            using (AboutForm aboutForm = new AboutForm())
               aboutForm.ShowDialog();
         }

         bOCRInstalled = IsInstalled(OCRKeys);
         if (!bOCRInstalled)
            _miAddWorker.MenuItems.Remove(_miAddOCRWorker);

         bMultimediaInstalled = IsInstalled(MultimediaKeys);
         if (!bMultimediaInstalled)
            _miAddWorker.MenuItems.Remove(_miAddMultimediaWorker);

         if (!bOCRInstalled && !bMultimediaInstalled)
         {
            //No toolkits were installed. 
            _miAddWorker.Enabled = false;
            MessageBox.Show("The 'Add Job' and 'Add Worker' feature of this demo has been disabled because neither the LEADTOOLS Multimedia or LEAD OCR SDK was found.", "Error");
         }

         //Show Client Form
         clientForm = new ClientForm(_userHost? _hostAddress : _IISAddress, bOCRInstalled, bMultimediaInstalled);
         clientForm.MdiParent = this;
         clientForm.Show();
      }

      private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
      {
         SaveSettings();
         foreach (Form childForm in this.MdiChildren)
            childForm.Dispose();
      }

      void SaveSettings()
      {
         Properties.Settings settings = new Properties.Settings();

         if (_userHost == true)
         {
            settings.HostAddress = _hostAddress;
         }

         settings.UserHost = _userHost;

         settings.Save();
      }

      private void _miFileExit_Click(object sender, System.EventArgs e)
      {
         Close();
      }

      private void _miFileClose_Click(object sender, System.EventArgs e)
      {
         ActiveMdiChild.Close();
      }

      private void _miHelpAbout_Click(object sender, System.EventArgs e)
      {
         using (AboutForm aboutForm = new AboutForm())
            aboutForm.ShowDialog();
      }

      private void _miWindow_Click(object sender, EventArgs e)
      {
         if (sender == _miWindowCascade)
            LayoutMdi(MdiLayout.Cascade);
         else if (sender == _miWindowTileHorizontally)
            LayoutMdi(MdiLayout.TileHorizontal);
         else if (sender == _miWindowTileVertically)
            LayoutMdi(MdiLayout.TileVertical);
         else if (sender == _miWindowArrangeIcons)
            LayoutMdi(MdiLayout.ArrangeIcons);
         else if (sender == _miWindowCloseAll)
         {
            foreach (Form child in MdiChildren)
            {
               child.Close();
            }
         }
      }

      private void _miShowJobViewer_Click(object sender, EventArgs e)
      {
         //Restore client form if mimimized
         if (clientForm.WindowState == FormWindowState.Minimized)
            clientForm.WindowState = FormWindowState.Normal;

         clientForm.Focus();
      }

      private void _miAddMultimediaWorker_Click(object sender, EventArgs e)
      {
         if (!DesignMode)
         {
            try
            {
               Assembly assembly = Assembly.Load("Leadtools.Multimedia");
            }
            catch (FileNotFoundException)
            {
               MessageBox.Show(this, "Leadtools.Multimedia missing. This demo requires LEADTOOLS Multimedia to be integrated on this machine.", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
               return;
            }
         }

         string fileName = Path.GetTempFileName();
         using (StreamWriter writer = new StreamWriter(fileName))
         {
            writer.Write(Resources.Multimedia);
         }

         AddWorker("Multimedia", fileName);
      }

      private void _miAddOCRWorker_Click(object sender, EventArgs e)
      {
         string fileName = Path.GetTempFileName();
         using (StreamWriter writer = new StreamWriter(fileName))
         {
            writer.Write(Resources.OCR);
         }

         AddWorker("OCR", fileName);
      }

      void AddWorker(string jobType, string configPath)
      {
         try
         {
            //Add new worker form
            UpdateWCFEndpointAddress(configPath);
            workerCounter++;
            string workerName = String.Format("Worker {0}", workerCounter);
            WorkerForm newWorker = new WorkerForm(workerName, configPath);
            newWorker.FormClosing += new FormClosingEventHandler(newWorker_FormClosing);
            newWorker.MdiParent = this;
            newWorker.Show();
            newWorker.Activate();
         }
         catch (Exception ex)
         {
            MessageBox.Show(ex.Message);
         }
      }

      void UpdateWCFEndpointAddress(string configPath)
      {
         //When we create a worker, it needs a configuration file.
         //This file contains information about the types of jobs
         //to process, worker assmebly, and the address of the WCF 
         //WorkerService. We will update this address based on 
         //the settings chosen in the connection form.
         XmlDocument configDocument = new XmlDocument();
         configDocument.Load(configPath);

         //Get the endpoint node and update the address
         XmlNode endPointNode = configDocument.SelectSingleNode("//client/endpoint[@address]");
         if (endPointNode != null)
         {
            endPointNode.Attributes["address"].Value = string.Format("{0}/WorkerService.svc", _userHost ? _hostAddress : _IISAddress);
            configDocument.Save(configPath);
         }
         else
            throw new Exception("The WCF Endpoint was not found in the configuration file.");
      }

      void newWorker_FormClosing(object sender, FormClosingEventArgs e)
      {
         WorkerForm workerForm = sender as WorkerForm;
         workerForm.FormClosing -= new FormClosingEventHandler(newWorker_FormClosing);
         workerForm.Dispose();
      }

      //Check if a toolkit is installed based on registry key
      bool IsInstalled(string[] registryKeys)
      {
         foreach (string registryKey in registryKeys)
         {
            using (RegistryKey key = OpenSoftwareKey(registryKey))
            {
               if (key != null)
                  return true;
            }
         }

         return false;
      }

      private RegistryKey OpenSoftwareKey(string keyName)
      {
         RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Wow6432Node\" + keyName);
         if (key == null)
         {
            key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\" + keyName);
            if (key == null)
               key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\" + keyName);
         }

         return key;
      }
   }
}
