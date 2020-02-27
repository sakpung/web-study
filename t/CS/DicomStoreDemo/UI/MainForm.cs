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
using System.Configuration;
using System.Net;
using Microsoft.Win32;
using System.IO;

using Leadtools;
using Leadtools.Dicom;
using Leadtools.Demos;
using Leadtools.DicomDemos;
using Leadtools.DicomDemos.Scu.CStore;
using Leadtools.Dicom.Common.Extensions;

#if LEADTOOLS_V19_OR_LATER
using Leadtools.Demos.Dialogs;
#endif

namespace DicomDemo
{
   /// <summary>
   /// Summary description for Form1.
   /// </summary>
   public class MainForm : System.Windows.Forms.Form
   {
      private System.Windows.Forms.StatusBar statusBar1;
      private System.Windows.Forms.Panel panel2;
      private System.Windows.Forms.Splitter splitter2;
      private System.Windows.Forms.Panel panel3;
      private System.Windows.Forms.ListView listViewImages;
      private System.Windows.Forms.ColumnHeader columnHeader1;
      private System.Windows.Forms.ColumnHeader columnHeader2;
      private System.Windows.Forms.ColumnHeader columnHeader3;
      private System.Windows.Forms.ColumnHeader columnHeader4;
      private System.Windows.Forms.ColumnHeader columnHeader5;
      private System.Windows.Forms.ColumnHeader columnHeader6;
      private IContainer components;
      private System.Windows.Forms.MainMenu mainMenu1;
      private System.Windows.Forms.MenuItem menuItemAddDicom;
      private System.Windows.Forms.MenuItem menuItemAddDicomDir;
      private System.Windows.Forms.OpenFileDialog openFileDialog;

      private System.Windows.Forms.MenuItem menuItem2;
      private System.Windows.Forms.MenuItem menuItemExit;

      private CStore cstore;
      private System.Windows.Forms.MenuItem menuItem3;
      private System.Windows.Forms.MenuItem menuItemCStore;
      private DicomServer server = new DicomServer();
      private System.Windows.Forms.MenuItem menuItem5;
      private System.Windows.Forms.MenuItem Options;

      private string AETitle = "CLIENT1";
      private bool IsSecure = false;
      private bool GroupLengthDataElements = false;
      private System.Windows.Forms.MenuItem menuItemFile;
      private System.Windows.Forms.MenuItem menuItemClearLog;
      private System.Windows.Forms.RichTextBox Log;
      private System.Windows.Forms.MenuItem menuItemHelp;
      private System.Windows.Forms.MenuItem menuItemAbout;

      private bool disableLogging = false;

      private ProgressForm progress = new ProgressForm();

      public delegate void AddLog(string sentence);
      public delegate void EnableMenu(bool enable);


      const string CONFIGURATION_LICENSE = "LEADTOOLS OCX Copyright (c) 1991-2004 LEAD Technologies, Inc.";
      const string CONFIGURATION_IMPLEMENTATIONCLASS = "1.2.840.114257.1123456";
      const string CONFIGURATION_IMPLEMENTATIONVERSIONNAME = "1";
      const string CONFIGURATION_PROTOCOLVERSION = "1";

      private const string _sTab = "\t";
      private string _settingsLocation = @"SOFTWARE\LEAD Technologies, Inc.\17\CSharp_DicomSTR17";

#if LEADTOOLS_V17_OR_LATER
      private DicomNetIpTypeFlags _ipType = DicomNetIpTypeFlags.Ipv4;
#endif

      public MainForm( )
      {
         //
         // Required for Windows Form Designer support
         //
         InitializeComponent();
         Utils.EngineStartup();
         Utils.DicomNetStartup();
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
          this.statusBar1 = new System.Windows.Forms.StatusBar();
          this.panel2 = new System.Windows.Forms.Panel();
          this.listViewImages = new System.Windows.Forms.ListView();
          this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
          this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
          this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
          this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
          this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
          this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
          this.splitter2 = new System.Windows.Forms.Splitter();
          this.panel3 = new System.Windows.Forms.Panel();
          this.Log = new System.Windows.Forms.RichTextBox();
          this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
          this.menuItemFile = new System.Windows.Forms.MenuItem();
          this.Options = new System.Windows.Forms.MenuItem();
          this.menuItemClearLog = new System.Windows.Forms.MenuItem();
          this.menuItem5 = new System.Windows.Forms.MenuItem();
          this.menuItemAddDicom = new System.Windows.Forms.MenuItem();
          this.menuItemAddDicomDir = new System.Windows.Forms.MenuItem();
          this.menuItem3 = new System.Windows.Forms.MenuItem();
          this.menuItemCStore = new System.Windows.Forms.MenuItem();
          this.menuItem2 = new System.Windows.Forms.MenuItem();
          this.menuItemExit = new System.Windows.Forms.MenuItem();
          this.menuItemHelp = new System.Windows.Forms.MenuItem();
          this.menuItemAbout = new System.Windows.Forms.MenuItem();
          this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
          this.panel2.SuspendLayout();
          this.panel3.SuspendLayout();
          this.SuspendLayout();
          // 
          // statusBar1
          // 
          this.statusBar1.Location = new System.Drawing.Point(0, 391);
          this.statusBar1.Name = "statusBar1";
          this.statusBar1.ShowPanels = true;
          this.statusBar1.Size = new System.Drawing.Size(680, 22);
          this.statusBar1.SizingGrip = false;
          this.statusBar1.TabIndex = 0;
          // 
          // panel2
          // 
          this.panel2.Controls.Add(this.listViewImages);
          this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
          this.panel2.Location = new System.Drawing.Point(0, 0);
          this.panel2.Name = "panel2";
          this.panel2.Size = new System.Drawing.Size(680, 240);
          this.panel2.TabIndex = 3;
          // 
          // listViewImages
          // 
          this.listViewImages.CheckBoxes = true;
          this.listViewImages.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
          this.listViewImages.Dock = System.Windows.Forms.DockStyle.Fill;
          this.listViewImages.FullRowSelect = true;
          this.listViewImages.GridLines = true;
          this.listViewImages.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
          this.listViewImages.HideSelection = false;
          this.listViewImages.Location = new System.Drawing.Point(0, 0);
          this.listViewImages.Name = "listViewImages";
          this.listViewImages.Size = new System.Drawing.Size(680, 240);
          this.listViewImages.TabIndex = 0;
          this.listViewImages.UseCompatibleStateImageBehavior = false;
          this.listViewImages.View = System.Windows.Forms.View.Details;
          this.listViewImages.SizeChanged += new System.EventHandler(this.listViewImages_SizeChanged);
          this.listViewImages.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.listViewImages_ItemCheck);
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
          this.columnHeader3.Text = "Study ID";
          // 
          // columnHeader4
          // 
          this.columnHeader4.Text = "Modality";
          // 
          // columnHeader5
          // 
          this.columnHeader5.Text = "Transfer Syntax";
          // 
          // columnHeader6
          // 
          this.columnHeader6.Text = "File Path";
          // 
          // splitter2
          // 
          this.splitter2.Dock = System.Windows.Forms.DockStyle.Top;
          this.splitter2.Location = new System.Drawing.Point(0, 240);
          this.splitter2.Name = "splitter2";
          this.splitter2.Size = new System.Drawing.Size(680, 3);
          this.splitter2.TabIndex = 4;
          this.splitter2.TabStop = false;
          // 
          // panel3
          // 
          this.panel3.Controls.Add(this.Log);
          this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
          this.panel3.Location = new System.Drawing.Point(0, 243);
          this.panel3.Name = "panel3";
          this.panel3.Size = new System.Drawing.Size(680, 148);
          this.panel3.TabIndex = 5;
          // 
          // Log
          // 
          this.Log.Dock = System.Windows.Forms.DockStyle.Fill;
          this.Log.Location = new System.Drawing.Point(0, 0);
          this.Log.Name = "Log";
          this.Log.ReadOnly = true;
          this.Log.Size = new System.Drawing.Size(680, 148);
          this.Log.TabIndex = 0;
          this.Log.Text = "";
          // 
          // mainMenu1
          // 
          this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemFile,
            this.menuItemHelp});
          // 
          // menuItemFile
          // 
          this.menuItemFile.Index = 0;
          this.menuItemFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.Options,
            this.menuItemClearLog,
            this.menuItem5,
            this.menuItemAddDicom,
            this.menuItemAddDicomDir,
            this.menuItem3,
            this.menuItemCStore,
            this.menuItem2,
            this.menuItemExit});
          this.menuItemFile.Text = "&File";
          this.menuItemFile.Popup += new System.EventHandler(this.menuItem1_Popup);
          // 
          // Options
          // 
          this.Options.Index = 0;
          this.Options.Text = "&Options...";
          this.Options.Click += new System.EventHandler(this.Options_Click);
          // 
          // menuItemClearLog
          // 
          this.menuItemClearLog.Index = 1;
          this.menuItemClearLog.Text = "&Clear Log";
          this.menuItemClearLog.Click += new System.EventHandler(this.menuItemClearLog_Click);
          // 
          // menuItem5
          // 
          this.menuItem5.Index = 2;
          this.menuItem5.Text = "-";
          // 
          // menuItemAddDicom
          // 
          this.menuItemAddDicom.Index = 3;
          this.menuItemAddDicom.Text = "Add Dicom...";
          this.menuItemAddDicom.Click += new System.EventHandler(this.menuItemAddDicom_Click);
          // 
          // menuItemAddDicomDir
          // 
          this.menuItemAddDicomDir.Index = 4;
          this.menuItemAddDicomDir.Text = "Add Dicom Dir...";
          this.menuItemAddDicomDir.Click += new System.EventHandler(this.menuItemAddDicomDir_Click);
          // 
          // menuItem3
          // 
          this.menuItem3.Index = 5;
          this.menuItem3.Text = "-";
          // 
          // menuItemCStore
          // 
          this.menuItemCStore.Index = 6;
          this.menuItemCStore.Text = "&Store";
          this.menuItemCStore.Click += new System.EventHandler(this.menuItemCStore_Click);
          // 
          // menuItem2
          // 
          this.menuItem2.Index = 7;
          this.menuItem2.Text = "-";
          // 
          // menuItemExit
          // 
          this.menuItemExit.Index = 8;
          this.menuItemExit.Text = "&Exit";
          this.menuItemExit.Click += new System.EventHandler(this.menuItemExit_Click);
          // 
          // menuItemHelp
          // 
          this.menuItemHelp.Index = 1;
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
          // openFileDialog
          // 
          this.openFileDialog.Multiselect = true;
          // 
          // MainForm
          // 
          this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
          this.ClientSize = new System.Drawing.Size(680, 413);
          this.Controls.Add(this.panel3);
          this.Controls.Add(this.splitter2);
          this.Controls.Add(this.panel2);
          this.Controls.Add(this.statusBar1);
          this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
          this.Menu = this.mainMenu1;
          this.Name = "MainForm";
          this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
          this.Text = "LEADTOOLS Dicom Storage SCU - C#";
          this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
          this.Load += new System.EventHandler(this.MainForm_Load);
          this.Closing += new System.ComponentModel.CancelEventHandler(this.MainForm_Closing);
          this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
          this.panel2.ResumeLayout(false);
          this.panel3.ResumeLayout(false);
          this.ResumeLayout(false);

      }
      #endregion

      /// <summary>
      /// The main entry point for the application.
      /// </summary>
      [STAThread]
      static void Main( )
      {
         Application.EnableVisualStyles();
#if LEADTOOLS_V175_OR_LATER
         if (!Support.SetLicense())
            return;
#else
         Support.Unlock(false);
#endif // #if LEADTOOLS_V175_OR_LATER

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

            Application.Run(new MainForm());
      }

      void CreateCStoreObject(bool secure)
      {
         if (cstore != null)
         {
            cstore.Dispose();
         }
         if (secure)
         {
            string clientPEM = Application.StartupPath + @"\client.pem";
            string privateKeyPassword = "test";

            cstore = new CStore(clientPEM, DicomTlsCipherSuiteType.EcdheRsaWithAes256GcmSha384, DicomTlsCertificateType.Pem, privateKeyPassword);
         }
         else
         {
            cstore = new CStore();
         }

         cstore.ImplementationClass = CONFIGURATION_IMPLEMENTATIONCLASS;
         cstore.ImplementationVersionName = CONFIGURATION_IMPLEMENTATIONVERSIONNAME;
         cstore.ProtocolVersion = CONFIGURATION_PROTOCOLVERSION;
         cstore.Status += new StatusEventHandler(cstore_Status);
         cstore.ProgressFiles += new ProgressFilesEventHandler(cstore_ProgressFiles);

      }

      private void MainForm_Load(object sender, System.EventArgs e)
      {

#if LTV20_CONFIG
         _settingsLocation = @"SOFTWARE\LEAD Technologies, Inc.\20\CSharp_DicomSTR20";
#elif LTV19_CONFIG
         _settingsLocation = @"SOFTWARE\LEAD Technologies, Inc.\19\CSharp_DicomSTR19";
#elif LTV18_CONFIG
         _settingsLocation = @"SOFTWARE\LEAD Technologies, Inc.\18\CSharp_DicomSTR18";
#elif LTV175_CONFIG
         _settingsLocation = @"SOFTWARE\LEAD Technologies, Inc.\17.5\CSharp_DicomSTR17.5";
#elif LTV17_CONFIG
         _settingsLocation = @"SOFTWARE\LEAD Technologies, Inc.\17\CSharp_DicomSTR17";
#elif LTV16_CONFIG
         _settingsLocation = @"SOFTWARE\LEAD Technologies, Inc.\16\CSharp_DicomSTR16";
#else
         _settingsLocation = @"SOFTWARE\LEAD Technologies, Inc.\15\CSharp_DicomSTR15";
#endif


         LoadSettings();
         cstore = null;
         CreateCStoreObject(_useTls);
         if (cstore != null)
         {
            cstore.PresentationContextType = _presentationContextType;
            cstore.Compression = _cstoreCompressionType;
         }

         using ( DicomDataSet dcm = new DicomDataSet() ) 
         {
            if(dcm == null)
            {
               MessageBox.Show("Can't create dicom object. Quitting app.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
               Application.Exit();
               return;
            }
         }
         
         using ( DicomDataSet dcmDir = new DicomDataSet() ) 
         {
            if(dcmDir == null)
            {
               MessageBox.Show("Can't create dicom object. Quitting app.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
               Application.Exit();
               return;
            }
         }

         panel2.Height = Convert.ToInt32(this.ClientSize.Height * 0.50);

         UpdateCStoreOptions();

         Application.ApplicationExit += new EventHandler(Application_ApplicationExit);
      }

      void Application_ApplicationExit(object sender, EventArgs e)
      {
         Utils.EngineShutdown();
         Utils.DicomNetShutdown();
      }

      private void menuItemAddDicom_Click(object sender, System.EventArgs e)
      {
         openFileDialog.Title = "Add DICOM File";
         openFileDialog.Filter = "DICOM Files (*.dic;*.dcm)|*.dic;*.dcm|All files (*.*)|*.*";
         if(openFileDialog.ShowDialog() == DialogResult.OK)
         {
            foreach(string file in openFileDialog.FileNames)
            {
               LoadDicomFile(file);
            }
         }
      }

      private void menuItemAddDicomDir_Click(object sender, System.EventArgs e)
      {
         openFileDialog.Title = "Add DICOM Dir";
         openFileDialog.Filter = "All Files|*.*";
         openFileDialog.FileName = "DICOMDIR";
         if(openFileDialog.ShowDialog() == DialogResult.OK)
         {
            foreach(string file in openFileDialog.FileNames)
            {
               LoadDicomDir(file);
            }
         }
      }

      private void LogText(string s1, string s2)
      {
         if (disableLogging)
            return;

         Log.Text = Log.Text + s1 + s2 + "\r\n";
      }

      bool LoadDicomFile(string filename)
      {
         //if (_cancel)
         //   return false;

         using ( DicomDataSet ds = new DicomDataSet() )
         {
            ListViewItem item = null;
            DicomElement element;
            string strTransferSyntax = "";
            bool succeeded = true;

            try
            {
               this.Cursor = Cursors.WaitCursor;
               ds.Load(filename, DicomDataSetLoadFlags.None);
               item = listViewImages.Items.Add(ds.GetValue<string>(DicomTag.PatientName, string.Empty));
               item.SubItems.Add(ds.GetValue<string>(DicomTag.PatientID, string.Empty));
               item.SubItems.Add(ds.GetValue<string>(DicomTag.StudyID, string.Empty));
               item.SubItems.Add(ds.GetValue<string>(DicomTag.Modality, string.Empty));

               strTransferSyntax = "Implicit VR - Little Endian";

               element = ds.FindFirstElement(null, DicomTag.TransferSyntaxUID, false);
               if (element != null && ds.GetElementValueCount(element) > 0)
               {
                  string uidString;
                  DicomUid uid;

                  uidString = ds.GetValue<string>(element, string.Empty);
                  uid = DicomUidTable.Instance.Find(uidString);
                  if (uid != null)
                  {
                     strTransferSyntax = uid.Name;
                  }
               }
            }
            catch (DicomException de)
            {
               LogText("Dicom error: " + de.Code.ToString(), filename);
               succeeded = false;
            }

            if (succeeded)
            {
               // Mark item read if we have a basic directory
               if (ds.InformationClass == DicomClassType.BasicDirectory)
               {
                  item.Font = new Font(listViewImages.Font, FontStyle.Bold);
               }

               item.SubItems.Add(strTransferSyntax);
               item.SubItems.Add(filename);

               item.Checked = true;
            }
            this.Cursor = Cursors.Default;
            return succeeded;
         }
      }

      private void LoadDicomDir(string filename)
      {
         using ( DicomDataSet ds = new DicomDataSet() ) 
         {
            string pathname = string.Empty;
            string refFilename = string.Empty;
            DicomElement element = null;
            int count = 0;
            int totalCount = 0;
            int nMod = 10;
            string sMsg = string.Empty;


            if (!filename.ToUpper().Contains("DICOMDIR"))
               return;

            pathname = Path.GetDirectoryName(filename) + "\\";
            try
            {
               this.Cursor = Cursors.WaitCursor;
               ds.Load(filename, DicomDataSetLoadFlags.None);

               // Get the total count
               element = ds.FindFirstElement(null, DicomTag.ReferencedFileID, false);
               while (element != null)
               {
                  totalCount++;
                  element = ds.FindNextElement(element, false);
               }

               if (totalCount > 20)
                  nMod = 10;

               // now get the datasets
               element = ds.FindFirstElement(null, DicomTag.ReferencedFileID, false);
               if (element != null && ds.GetElementValueCount(element) > 0)
               {
                  //if (!_cancel)
                  {
                     LogText("Loading DICOMDIR", string.Empty);
                     refFilename = ds.GetConvertValue(element);
                     if (LoadDicomFile(pathname + refFilename))
                        count++;
                     Application.DoEvents();
                  }
               }

               while ((refFilename.Length > 0) /*&& (!_cancel)*/)
               {
                  element = ds.FindNextElement(element, false);
                  if (element != null && ds.GetElementValueCount(element) > 0)
                  {
                     refFilename = ds.GetConvertValue(element);
                     if (LoadDicomFile(pathname + refFilename))
                        count++;
                     Application.DoEvents();
                  }
                  else
                     refFilename = "";
                  if (count % nMod == 0)
                  {
                     sMsg = string.Format("Loaded {0} of {1} files...", count.ToString(), totalCount.ToString());
                     LogText(string.Empty, _sTab + sMsg);
                     //StatusText(sMsg);
                  }
               }
            }
            catch (DicomException de)
            {
               LogText("Dicom error: " + de.Code.ToString(), filename);
            }
            sMsg = string.Format("Loaded {0} of {1} total files", count.ToString(), totalCount.ToString());
            LogText(string.Empty, _sTab + sMsg);
            // StatusText(sMsg);
            this.Cursor = Cursors.Default;
         }
      }

      private void menuItemExit_Click(object sender, System.EventArgs e)
      {
         Close();
      }

      private void listViewImages_SizeChanged(object sender, System.EventArgs e)
      {
         foreach(ColumnHeader col in listViewImages.Columns)
         {
            col.Width = listViewImages.Width / listViewImages.Columns.Count;
         }
      }

      private void menuItemCStore_Click(object sender, System.EventArgs e)
      {
         menuItemFile.Enabled = false;
         cstore.Store(server, AETitle);
      }

      private void listViewImages_ItemCheck(object sender, System.Windows.Forms.ItemCheckEventArgs e)
      {
         string filename;

         filename = listViewImages.Items[e.Index].SubItems[5].Text;

         if(e.NewValue == CheckState.Checked)
         {
            //
            // add file to cstore object
            //
            cstore.Files.Add(filename);
         }
         else
         {
            //
            // remove file from cstore object
            //
            cstore.Files.Remove(filename);
         }
      }

      private void menuItem1_Popup(object sender, System.EventArgs e)
      {
         menuItemCStore.Enabled = (cstore.Files.Count > 0 && server.AETitle.Length > 0 &&
                                   AETitle.Length > 0);
      }

      public void LogText(string logText)
      {
         if (disableLogging)
            return;

         if(InvokeRequired)
            Invoke(new AddLog(LogText), new object[] { logText });
         else
            Log.Text = Log.Text + logText + "\r\n";
         ;
      }

      public void EnableFileMenu(bool enable)
      {
         if(this.InvokeRequired)
         {
            Invoke(new EnableMenu(EnableFileMenu), new object[] { enable });
         }
         else
            menuItemFile.Enabled = enable;
      }

      private void cstore_Status(object sender, StatusEventArgs e)
      {
         string message = "";
         bool done = false;

         if(e.Type == StatusType.Error)
         {
            message = "DICOM error. The process will be terminated! -- Error code is: " + e.Error.ToString();
         }
         else
         {
            switch(e.Type)
            {
               case StatusType.ConnectFailed:
                  message = "Connect operation failed.";
                  done = true;
                  break;
               case StatusType.ConnectSucceeded:
                  message = "Connected successfully.\n";
                  message += "\tPeer Address:\t" + e.PeerIP.ToString() + "\n";
                  message += "\tPeer Port:\t\t" + e.PeerPort.ToString();
                  break;
               case StatusType.SendAssociateRequest:
                  message = "Sending association request...";
                  break;
               case StatusType.ReceiveAssociateAccept:
                  message = "Received Associate Accept.\n";
                  message += "\tCalling AE:\t" + e.CallingAE + "\n";
                  message += "\tCalled AE:\t" + e.CalledAE;
                  break;
               case StatusType.ReceiveAssociateReject:
                  message = "Received Associate Reject!";
                  message += "\tResult: " + e.Result.ToString();
                  message += "\tReason: " + e.Reason.ToString();
                  message += "\tSource: " + e.Source.ToString();
                  break;
               case StatusType.AbstractSyntaxNotSupported:
                  message = "Abstract Syntax NOT supported!";
                  break;
               case StatusType.SendCStoreRequest:
                  message = "Sending C-STORE Request...";
                  break;
               case StatusType.ReceiveCStoreResponse:
                  if(e.Error == DicomExceptionCode.Success)
                  {
                     message = "**** Storage completed successfully ****";
                  }
                  else
                  {
                     message = "**** Storage failed with status: " + e.Status.ToString();
                  }
                  break;
               case StatusType.ConnectionClosed:
                  message = "Network Connection closed!";
                  done = true;
                  break;
               case StatusType.ProcessTerminated:
                  message = "Process has been terminated!";
                  done = true;
                  break;
               case StatusType.SendReleaseRequest:
                  message = "Sending release request...";
                  break;
               case StatusType.ReceiveReleaseResponse:
                  message = "Receiving release response";
                  done = true;
                  break;
               case StatusType.Timeout:
                  message = "Communication timeout. Process will be terminated.";
                  done = true;
                  break;
               case StatusType.SecureLinkReady:
                  {
                     DicomNet net = sender as DicomNet;
                     if (net != null)
                     {
                        DicomTlsCipherSuiteType cipher = net.GetTlsCipherSuite();
                        if (e.Error == DicomExceptionCode.Success)
                        {
                           message = string.Format("\n\tSecure Link Ready\n\tCipher Suite: {0}", cipher.GetCipherFriendlyName());
                        }
                        else
                        {
                           message =
                              "\n\t" + "Secure Link Failed" +
                              "\n\t" + "Error:\t" + e.Error.ToString();
                        }
                     }
                  }
                  break;
            }
         }
         LogText(message);
         if(done)
         {
            EnableFileMenu(true);

            if(cstore.IsConnected())
               cstore.Close();
         }
      }

      private void cstore_ProgressFiles(object sender, ProgressFilesEventArgs e)
      {
         string message;

         message = "File to be stored: " + e.File.FullName;
         message += "\n\tSize: " + e.File.Length.ToString();
         LogText(message);
      }

      // Settings
      public DicomDemoSettings _mySettings = null; 
      public string _demoName = Path.GetFileName(Application.ExecutablePath);

      private void Options_Click(object sender, System.EventArgs e)
      {
         OptionsDialog optionDlg = new OptionsDialog();

         optionDlg.DisableLogging = disableLogging;
         optionDlg.ServerAE.Text = server.AETitle;
         optionDlg.ServerPort.Text = server.Port.ToString();
         optionDlg.ServerIp.Text = server.Address.ToString();
         optionDlg.IpType = server.IpType;
         optionDlg.Compression = cstore.Compression;
         optionDlg.PresentationContextType = cstore.PresentationContextType;
         optionDlg.Timeout.Text = server.Timeout.ToString();
         optionDlg.ClientAE.Text = AETitle;
         optionDlg.UseSecureTLSCommunication.Checked = IsSecure;
         optionDlg.GroupLengthDataElements = GroupLengthDataElements;
         optionDlg.UseSecureTLSCommunication.Checked = _useTls;
         optionDlg.CipherSuites = _mySettings.CipherSuites;
         if(optionDlg.ShowDialog() == DialogResult.OK)
         {
            disableLogging = optionDlg.DisableLogging;
            server.AETitle = optionDlg.ServerAE.Text;
            server.Port = Convert.ToInt32(optionDlg.ServerPort.Text);
            server.Address = IPAddress.Parse(optionDlg.ServerIp.Text);
            server.IpType = optionDlg.IpType;
            cstore.Compression = optionDlg.Compression;
            cstore.PresentationContextType = optionDlg.PresentationContextType;
            server.Timeout = Convert.ToInt32(optionDlg.Timeout.Text);
            AETitle = optionDlg.ClientAE.Text;
            if (IsSecure != optionDlg.UseSecureTLSCommunication.Checked)
            {
               Cursor = Cursors.WaitCursor;

               try
               {
                  IsSecure = optionDlg.UseSecureTLSCommunication.Checked;
                  CreateCStoreObject(IsSecure);
                  string filename;
                  foreach (ListViewItem item in listViewImages.Items)
                  {
                     if (item.Checked == true)
                     {
                        filename = item.SubItems[5].Text;
                        if (filename != null)
                           cstore.Files.Add(filename);
                     }
                  }
               }
               catch (Exception /*exception*/)
               {

               }
               finally
               {
                  Cursor = Cursors.Arrow;
               }
            }
            GroupLengthDataElements = optionDlg.GroupLengthDataElements;
            _useTls = optionDlg.UseSecureTLSCommunication.Checked;
            _mySettings.CipherSuites = optionDlg.CipherSuites;
            SaveSettings();
            UpdateCStoreOptions();
         }
      }

      bool _useTls = false;
      DicomImageCompressionType _cstoreCompressionType = DicomImageCompressionType.None;
      int _presentationContextType = 0;

      private void LoadSettings( )
      {
         _mySettings = DicomDemoSettingsManager.LoadSettings(_demoName);
         if (_mySettings == null)
         {
            _mySettings = new DicomDemoSettings();
            _mySettings.FirstRun = false;
            DicomDemoSettingsManager.SaveSettings(_demoName, _mySettings);
         }

         RegistryKey user = Registry.CurrentUser;
         RegistryKey settings = user.OpenSubKey(_settingsLocation, true);
         if (settings == null)
         {
            //
            // We haven't saved any setting yet.  Will use the default
            //  settings.
            return;
         }

         _useTls = Convert.ToBoolean(settings.GetValue("UseTls", false));

         if (_useTls)
         {
            if (Utils.VerifyOpensslVersion(this) == false)
            {
               _useTls = false;
            }
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
         disableLogging = Convert.ToBoolean(settings.GetValue("DisableLogging"));
         GroupLengthDataElements = Convert.ToBoolean(settings.GetValue("GroupLengthDataElements", false));
         

         _presentationContextType = Convert.ToInt32(settings.GetValue("PresentationContextType"));
         _cstoreCompressionType = (DicomImageCompressionType)Enum.Parse(typeof(DicomImageCompressionType), Convert.ToString(settings.GetValue("Compression")));

         if (cstore != null)
         {
            cstore.PresentationContextType = _presentationContextType;
            cstore.Compression = _cstoreCompressionType;
         }
      }

      private void SaveSettings( )
      {
         RegistryKey user = Registry.CurrentUser;
         RegistryKey settings = user.OpenSubKey(_settingsLocation, true);

         if (settings == null)
         {
            settings = user.CreateSubKey(_settingsLocation);
         }

         settings.SetValue("UseTls", _useTls);

         settings.SetValue("ServerAE", server.AETitle);
         settings.SetValue("ServerPort", server.Port);
         settings.SetValue("ServerAddress", server.Address.ToString());
         settings.SetValue("ServerIpType", server.IpType);
         settings.SetValue("Compression", cstore.Compression);
         settings.SetValue("ServerTimeout", server.Timeout);
         settings.SetValue("ClientAE", AETitle);
         settings.SetValue("PresentationContextType", cstore.PresentationContextType);

         settings.SetValue("DisableLogging", disableLogging);
#if LEADTOOLS_V19_OR_LATER
         settings.SetValue("GroupLengthDataElements", GroupLengthDataElements);
#endif
         settings.Close();

         DicomDemoSettingsManager.SaveSettings(_demoName, _mySettings);
      }

      private void SetCipherSuites(DicomNet scu)
      {
         // Zero out the CipherSuite list
         scu.SetTlsCipherSuiteByIndex(0, DicomTlsCipherSuiteType.None);

         // Add the new CipherSuites in order of priority
         int cipherCount = 0;
         foreach (CipherSuiteItem cipherSuiteItem in _mySettings.CipherSuites.ItemList)
         {
            if (cipherSuiteItem.IsChecked)
            {
               scu.SetTlsCipherSuiteByIndex(cipherCount, cipherSuiteItem.Cipher);
               cipherCount++;
            }
         }
      }

      private void UpdateCStoreOptions()
      {
#if LEADTOOLS_V19_OR_LATER
         cstore.Flags = DicomNetFlags.None;
         if (GroupLengthDataElements)
         {
            cstore.Flags |= DicomNetFlags.SendDataWithGroupLengthStandardDataElements;
         }

         if (cstore.IsSecureTLS)
            SetCipherSuites(cstore);
#endif
      }

      private void MainForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
      {
         //cstore.Shutdown();
      }

      private void menuItemClearLog_Click(object sender, System.EventArgs e)
      {
         Log.Clear();
      }

      private void menuItemAbout_Click(object sender, System.EventArgs e)
      {
#if LEADTOOLS_V19_OR_LATER
         using (AboutDialog aboutDialog = new AboutDialog("Dicom Storage SCU", ProgrammingInterface.CS))
            aboutDialog.ShowDialog(this);
#else
         using (AboutDialog aboutDialog = new AboutDialog("Dicom Storage SCU"))
            aboutDialog.ShowDialog(this);
#endif
      }

      private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
      {
          if (cstore != null && cstore.IsConnected())
          {
              cstore.Terminate();              
          }
      }
   }
}
