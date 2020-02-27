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
using System.Management;
using System.Runtime.InteropServices;
using System.IO;
using System.Security.Principal;
using System.Diagnostics;
using System.Drawing.Printing;
using PrinterServiceIISConfigDemo;
using System.Net;
using System.Xml.XPath;
using System.Xml;
using System.Security.AccessControl;

namespace PrinterServerISSConfig
{
   public partial class MainForm : Form
   {
      bool _tested;
      string _errorMessage = "";

      private static bool CheckAdminRights()
      {
         bool elevate = false;

         bool needUAC = false;

         // Check if we need UAC to elevate the rights
         OperatingSystem os = Environment.OSVersion;
         if (os.Platform == PlatformID.Win32NT && os.Version.Major >= 6)
            needUAC = true;
         else
            needUAC = false;

         if (needUAC)
         {
            // Check if we are not running in admin mode
            WindowsIdentity wi = WindowsIdentity.GetCurrent();
            WindowsPrincipal wp = new WindowsPrincipal(wi);

            if (!wp.IsInRole(WindowsBuiltInRole.Administrator))
               elevate = true;
         }

         if (elevate)
         {
            // We must restart this application elevated as admin
            ProcessStartInfo startInfo = new ProcessStartInfo();

            startInfo.UseShellExecute = true;
            startInfo.WorkingDirectory = Environment.CurrentDirectory;
            startInfo.FileName = Application.ExecutablePath;
            startInfo.Verb = "runas";

            try
            {
               Process p = Process.Start(startInfo);
            }
            catch (Win32Exception)
            {
            }
         }

         return !elevate;
      }

      [STAThread]
      static void Main(string[] args)
      {
         try
         {
            if (!CheckAdminRights())
               return;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try
            {
               Application.Run(new MainForm());
            }
            catch (Exception)
            {

            }
         }
         catch { }
      }

      public MainForm()
      {
         InitializeComponent();
      }

      private void MainForm_Load(object sender, EventArgs e)
      {
         string strRet;
         if (!Globals.Initialize(false, out strRet))
         {
            Close();
            return;
         }

         _machineTextBox.Text = Globals.Machine;
         _iisVersionTextBox.Text = Globals.IISVersion;

         _virtualDirNameTextBox.Text = Globals.VirtualDirName;
         _virtualDirPathTextBox.Text = Globals.VirtualDirPath;

         FillServiceBox();

      }

      private void MainForm_Shown(object sender, EventArgs e)
      {
         Enabled = true;
         Text = "LEADTOOLS C# Printer Server IIS Config Demo";
      }

      private void _testButton_Click(object sender, EventArgs e)
      {
         this.Cursor = Cursors.WaitCursor;

         try
         {
            // Test a connection to all the URLs

            _tested = true;

            string url = "http://localhost/VirtualPrinterWebService" + Globals._toolkitVersion.Replace(".", "") + "/VirtualPrinterWebService.asmx";

            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            request.Timeout = 180000;

            try
            {
               TestService("VirtualPrinterWebService", url);
               _errorMessage = null;
            }
            catch (Exception ex)
            {
               _errorMessage = ex.Message;
            }

         }
         finally
         {
            FillServiceBox();
            this.Cursor = Cursors.Default;
         }
      }

      private void ShowErrorMessage(Exception ex)
      {
         COMException comException = ex as COMException;

         if (comException != null && (uint)comException.ErrorCode == 0x80005000)
         {
            string message = "Incorrect IIS Configuration - Could not navigate the virtual directories of IIS on this machine.\n\n" +
               "This happens when some of the IIS subcomponents are not installed.\n\n" +
               "Make sure that all IIS subcomponents are installed correctly.\n\n" +
               "Do you want to view the LEADTOOLS Printer Server IIS Config Demo Troubleshooting Guide now?";

            if (MessageBox.Show(this, message, Text, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
               _troubleShootButton_Click(null, null);
         }
         else
            MessageBox.Show(this, ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }

      private void _createButton_Click(object sender, EventArgs e)
      {
         this.Cursor = Cursors.WaitCursor;

#if LEADTOOLS_V20_OR_LATER
         string dotnetRuntimeVersion = "v4.0";
#else
         string dotnetRuntimeVersion = "v2.0";
#endif // #if LEADTOOLS_V20_OR_LATER

         try
         {
            // First, delete the app pool and virtual directory
            DeleteHost(Text);

            // Now re-create it
            FolderACL("Everyone", Globals.VirtualDirPath);

            // Create ApplicationPool
            ApplicationPool.CreateApplicationPool(
               Globals.Machine,
               Globals.UserName,
               Globals.Password,
               Globals.AppPoolName,
               false,
               dotnetRuntimeVersion);


            // Create the virtual directory
            VirtualDirectory.CreateVirtualDirectory(
               Globals.Machine,
               Globals.UserName,
               Globals.Password,
               Globals.VirtualDirName,
               Globals.VirtualDirPath,
               Globals.AppPoolName);

            System.Threading.Thread.Sleep(1000);
            Application.DoEvents();
            _testButton.PerformClick();
         }
         catch (Exception ex)
         {
            ShowErrorMessage(ex);
         }
         finally
         {
            this.Cursor = Cursors.Default;
         }
      }

      private void _deleteButton_Click(object sender, EventArgs e)
      {
         this.Cursor = Cursors.WaitCursor;

         try
         {
            DeleteHost(Text);
         }
         catch (Exception ex)
         {
            ShowErrorMessage(ex);
         }
         finally
         {
            _tested = false;
            _errorMessage = null;

            FillServiceBox();
            this.Cursor = Cursors.Default;
         }

      }

      public static void FolderACL(String accountName, String folderPath)
      {

         FileSystemRights Rights;

         //What rights are we setting?

         Rights = FileSystemRights.FullControl;
         bool modified;
         InheritanceFlags none = new InheritanceFlags();
         none = InheritanceFlags.None;

         //set on dir itself
         FileSystemAccessRule accessRule = new FileSystemAccessRule(accountName, Rights, none, PropagationFlags.NoPropagateInherit, AccessControlType.Allow);
         DirectoryInfo dInfo = new DirectoryInfo(folderPath);
         DirectorySecurity dSecurity = dInfo.GetAccessControl();
         dSecurity.ModifyAccessRule(AccessControlModification.Set, accessRule, out modified);

         //Always allow objects to inherit on a directory 
         InheritanceFlags iFlags = new InheritanceFlags();
         iFlags = InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit;

         //Add Access rule for the inheritance
         FileSystemAccessRule accessRule2 = new FileSystemAccessRule(accountName, Rights, iFlags, PropagationFlags.InheritOnly, AccessControlType.Allow);
         dSecurity.ModifyAccessRule(AccessControlModification.Add, accessRule2, out modified);

         dInfo.SetAccessControl(dSecurity);
      }

      public void DeleteHost(string strTitle)
      {
         string[] vDirs = VirtualDirectory.GetVirtualDirectories(
                     Globals.Machine,
                     Globals.UserName,
                     Globals.Password);

         foreach (string dir in vDirs)
         {
            if (dir != Globals.VirtualDirName)
               continue;

            // Check if the virtual directory exists
            VirtualDirectory.DeleteVirtualDirectory(
               Globals.Machine,
               Globals.UserName,
               Globals.Password,
               Globals.VirtualDirName
               );
         }

         string[] appPoolNames = ApplicationPool.GetApplicationPools(
                     Globals.Machine,
                     Globals.UserName,
                     Globals.Password);

         foreach (string appPool in appPoolNames)
         {
            if (appPool != Globals.AppPoolName)
               continue;

            ApplicationPool.DeleteApplicationPool(
                  Globals.Machine,
                  Globals.UserName,
                  Globals.Password,
                  Globals.AppPoolName);
         }

         System.Threading.Thread.Sleep(1000);
      }

      private static void TestService(string name, string url)
      {
         // Check if we can access it through the URL
         CanReachThroughHttp(url);

         // Now check if it is a service
         CheckService(name, url);
      }

      private static void CanReachThroughHttp(string url)
      {
         // First check if it is reachable through HTTP
         HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
         request.Timeout = 180000;

         using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
         {
            using (StreamReader reader = new StreamReader(response.GetResponseStream()))
            {
               string str = reader.ReadToEnd();
            }
         }
      }

      private static void CheckService(string name, string url)
      {
         // First check if it is reachable through HTTP
         HttpWebRequest request = WebRequest.Create(url + "?wsdl") as HttpWebRequest;
         request.Timeout = 180000;

         using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
         {
            string errorMessage = "Service not installed in IIS. Register ASP.NET for IIS and try again.";

            using (StreamReader reader = new StreamReader(response.GetResponseStream()))
            {
               try
               {
                  XPathDocument doc = new XPathDocument(reader);
                  XPathNavigator nav = doc.CreateNavigator();
                  if (nav == null)
                     throw new Exception(errorMessage);

                  XmlNamespaceManager manager = new XmlNamespaceManager(nav.NameTable);
                  manager.AddNamespace("wsdl", "http://schemas.xmlsoap.org/wsdl/");

                  XPathNavigator wsdlNav = nav.SelectSingleNode("//wsdl:service", manager);
                  if (wsdlNav == null)
                     throw new Exception(errorMessage);

                  string svcName = wsdlNav.GetAttribute("name", string.Empty);
                  if (svcName == null || string.Compare(svcName, name, StringComparison.InvariantCultureIgnoreCase) != 0)
                     throw new Exception(errorMessage);
               }
               catch (Exception)
               {
                  throw new Exception(errorMessage);
               }
            }
         }
      }

      private void FillServiceBox()
      {
         bool bError = false;
         _networkComponentsRichTextBox.Clear();

         AddText("Service: ", Color.Black, false);
         AddText("Virtual Printer Web Service " + Globals._toolkitVersion + Environment.NewLine, Color.Blue, false);
         string url = "http://localhost/VirtualPrinterWebService" + Globals._toolkitVersion.Replace(".", "") + "/VirtualPrinterWebService.asmx";
         AddText("URL: ", Color.Black, false);
         AddText(url + Environment.NewLine, Color.Black, false);
         AddText("Status: ", Color.Black, false);

         if (_tested)
         {
            if (!string.IsNullOrEmpty(_errorMessage))
            {
               AddText("Error: " + _errorMessage, Color.Red, true);
               bError = true;
            }
            else
               AddText("Success", Color.Blue, true);
         }
         else
            AddText("Not tested yet", Color.Blue, false);

         AddText(Environment.NewLine, Color.Black, false);
         AddText(Environment.NewLine, Color.Black, false);

         if (bError)
            _troubleShootButton_Click(null, null);

      }

      public void AddText(string text, Color color, bool bold)
      {
         int oldSelectionStart = _networkComponentsRichTextBox.SelectionStart;

         _networkComponentsRichTextBox.AppendText(text);

         int newSelectionStart = _networkComponentsRichTextBox.SelectionStart;
         _networkComponentsRichTextBox.SelectionStart = oldSelectionStart;
         _networkComponentsRichTextBox.SelectionLength = newSelectionStart - oldSelectionStart;

         _networkComponentsRichTextBox.SelectionColor = color;
         FontStyle style = bold ? FontStyle.Bold : FontStyle.Regular;
         using (Font font = new Font(Font.FontFamily, Font.Size, style))
            _networkComponentsRichTextBox.SelectionFont = font;

         _networkComponentsRichTextBox.SelectionStart = newSelectionStart;

         _networkComponentsRichTextBox.ScrollToCaret();
      }

      private void _troubleShootButton_Click(object sender, EventArgs e)
      {
         FrmUsage frmUsage = new FrmUsage();
         frmUsage.ShowDialog();
      }

   }
}
