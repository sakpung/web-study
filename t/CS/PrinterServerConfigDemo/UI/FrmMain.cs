// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;
using Leadtools.Demos;
using Leadtools.Printer;
using PrinterDemo;
using System.IO;
using System.Runtime.InteropServices;
using Microsoft.Win32;
using System.Diagnostics;

namespace ServerPrinterConfigDemo.UI
{
   public partial class FrmMain : Form
   {
      #region Main...
      /// <summary>
      /// The main entry point for the application.
      /// </summary>
      [STAThread]
      static void Main(string[] args)
      {
         try
         {
            if (!Support.SetLicense())
               return;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmMain());
         }
         catch (Exception ex)
         {
            MessageBox.Show(ex.Message);
         }
      }

      private static bool Is64Bit()
      {
         return IntPtr.Size == 8;
      }
      #endregion

      #region Fields...
      PrinterSettings _printerSettings;
      public static string _strTittle
      {
         get
         {
            if (Is64Bit())
               return "LEADTOOLS C# Printer Server Config Demo 64-bit";
            else
               return "LEADTOOLS C# Printer Server Config Demo 32-bit";
         }
      }

      Printer _printer;
      string _currentPrinterName = string.Empty;
      bool _EnableNetworkPrinting = false;
      bool _bUpdate = false;
      List<TextBox> _lstTextBox = new List<TextBox>();
      #endregion

      public FrmMain()
      {
         try
         {
            InitializeComponent();
            Text = _strTittle;

            _lstTextBox.Add(_txtLocationPDF);
            _lstTextBox.Add(_txtLocationDoc);
            _lstTextBox.Add(_txtLocationXps);
            _lstTextBox.Add(_txtLocationTxt);

            _btnSave.Enabled = false;

            FillLeadtoolsPrintersList(null, false);
            if (_cmbNetworkPrinters.Items.Count == 0)
            {
               _cmbNetworkPrinters.Enabled = false;
               _ckNetworkEnabled.Enabled = false;
               _ckSharePrinter.Enabled = false;
               _grpPrinterSettings.Enabled = false;
               _btnUninstall.Enabled = false;
            }
            else
            {
               _bUpdate = false;
               _EnableNetworkPrinting = _printer.EnableNetworkPrinting;
               _ckNetworkEnabled_CheckedChanged(null, null);
               _bUpdate = true;
            }

         }
         catch (Exception Ex)
         {
            MessageBox.Show(Ex.Message, _strTittle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            Close();
         }
      }

      private void FillLeadtoolsPrintersList(string strDefault, bool bDefaultEnable)
      {
         string setupPrinter = string.Empty;

#if LTV20_CONFIG
         if(Is64Bit())
            setupPrinter = "LEADTOOLS 20 .NET Network Printer 64-bit";
         else
            setupPrinter = "LEADTOOLS 20 .NET Network Printer 32-bit";
#endif

         if (!string.IsNullOrEmpty(strDefault))
         {
            setupPrinter = strDefault;
         }

         try
         {
            _cmbNetworkPrinters.Items.Clear();
            _cmbNetworkPrinters.Items.AddRange(PrintingUtilities.GetLeadtoolsPrintersList());

            if (_cmbNetworkPrinters.Items.Count > 0)
            {
               _cmbNetworkPrinters.SelectedIndex = 0;

               for (int i = 0; i < _cmbNetworkPrinters.Items.Count; i++)
               {
                  if ((_cmbNetworkPrinters.Items[i] as string).ToLower() == setupPrinter.ToLower())
                     _cmbNetworkPrinters.SelectedIndex = i;
               }

               _printer = new Printer(_cmbNetworkPrinters.SelectedItem.ToString());

               if (bDefaultEnable)
               {
                  _printer.EnableNetworkPrinting = true;
                  _ckNetworkEnabled.Checked = true;
               }
               else
               {

                  _ckNetworkEnabled.Checked = _printer.EnableNetworkPrinting;
                  _ckSharePrinter.Checked = PrinterConfiguration.IsPrinterShared(_printer.PrinterName);
               }

            }
            else
            {
               string errorMessage = "No printers are available.";
               MessageBox.Show(errorMessage, _strTittle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
         }
         catch (Exception Ex)
         {
            MessageBox.Show(Ex.ToString(), _strTittle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
         }
      }

      private void ApplyPrinterSettings()
      {
         _txtPrinterDescription.Text = _printerSettings._strDescreption;

         foreach (TextBox txtBox in _lstTextBox)
         {
            txtBox.Clear();
         }

         for (int i = 0; i < _printerSettings._lstFormats.Count; i++)
         {
            PrinterFileFormat fileFormat = _printerSettings._lstFormats[i];
            _lstTextBox[i].Text = fileFormat._strSaveLocation;
         }
      }

      private void _ckNetworkEnabled_CheckedChanged(object sender, EventArgs e)
      {
         try
         {
            if (_bUpdate && _printer.EnableNetworkPrinting != _ckNetworkEnabled.Checked)
               _printer.EnableNetworkPrinting = _ckNetworkEnabled.Checked;

            _grpPrinterSettings.Enabled = _ckNetworkEnabled.Checked;

            if (_ckNetworkEnabled.Checked)
            {
               byte[] bytes = _printer.GetNetworkInitialData();
               if (bytes == null || bytes.Length == 0)
               {
                  _printerSettings = new PrinterSettings();
                  try
                  {
                     _printer.SetNetworkInitialData(_printerSettings.GetBytes());
                  }
                  catch
                  {
                     string strMessage = "Incorrect IIS Configuration - Error retrieving data from Web service.\n\n" +
                                         "In order to use LEADTOOLS Network Virtual Printer:\n" +
                                         "   1. IIS should be installed.\n" +
                                         "   2. IIS must be configured using the LEADTOOLS Printer Server IIS Configuration Demo.\n\n" +
                                         "Do you want to launch the LEADTOOLS Printer Server IIS Configuration Demo?";
                     DialogResult dlgRes = MessageBox.Show(strMessage, Text, MessageBoxButtons.YesNo, MessageBoxIcon.Error);

                     if (dlgRes == DialogResult.Yes)
                     {
                        string strConfigPath;
                        strConfigPath = Path.GetDirectoryName(Application.ExecutablePath);
                        Process.Start(strConfigPath + "\\" + "CSPrinterServerIISConfigDemo_Original.exe");
                     }

                     this.Close();
                     Environment.Exit(0);

                     return;
                  }

               }
               else
               {
                  _printerSettings = new PrinterSettings(bytes);
               }

               ApplyPrinterSettings();
            }
            else
            {
               for (int i = 0; i < _lstTextBox.Count; i++)
               {
                  _lstTextBox[i].Clear();
               }
               _txtPrinterDescription.Clear();
            }
         }
         catch (PrinterDriverException ex)
         {
            if (ex.Code == PrinterDriverExceptionCode.PrinterStateLocked)
            {
               MessageBox.Show(null, "Cannot enable network printing for a locked printer", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
               _ckNetworkEnabled.Checked = false;
            }
         }


      }

      private void _cmbNetworkPrinters_SelectedIndexChanged(object sender, EventArgs e)
      {
         if (_ckNetworkEnabled.Checked && _btnSave.Enabled)
         {
            DialogResult dlgRes = MessageBox.Show("Printer Settings Changed\nDo you want to save them?", _strTittle, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dlgRes == DialogResult.Yes)
            {
               _btnSave.PerformClick();
            }
         }

         _btnSave.Enabled = false;

         if (_printer == null || String.IsNullOrEmpty(_cmbNetworkPrinters.SelectedItem.ToString()) ||
             (_printer.PrinterName == _cmbNetworkPrinters.SelectedItem.ToString()))
            return;

         _printer.Dispose();

         _printer = new Printer(_cmbNetworkPrinters.SelectedItem.ToString());

         _ckNetworkEnabled.Checked = _printer.EnableNetworkPrinting;
         _ckSharePrinter.Checked = PrinterConfiguration.IsPrinterShared(_printer.PrinterName);
         _ckNetworkEnabled_CheckedChanged(null, null);
      }

      private void _btnSave_Click(object sender, EventArgs e)
      {
         try
         {
            _printerSettings._strDescreption = _txtPrinterDescription.Text;

            for (int i = 0; i < _printerSettings._lstFormats.Count; i++)
            {
               _printerSettings._lstFormats[i]._strSaveLocation = _lstTextBox[i].Text;
            }

            _printer.SetNetworkInitialData(_printerSettings.GetBytes());
            _btnSave.Enabled = false;
         }
         catch (Exception ex)
         {
            MessageBox.Show(ex.Message);
         }
      }

      private bool CheckDirectory(string strPath)
      {
         if (Directory.Exists(strPath) || string.IsNullOrEmpty(strPath))
            return true;

         DialogResult dlgRes = MessageBox.Show("Folder does not exist\nDo you want to create it?", _strTittle, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
         if (dlgRes == DialogResult.Yes)
         {
            Directory.CreateDirectory(strPath);
            return true;
         }

         return false;
      }

      private void _btnBrowse_Click(object sender, EventArgs e)
      {
         FolderBrowserDialog folderDialog = new FolderBrowserDialog();
         int nTextBox = Convert.ToInt32(((Button)sender).Tag);
         if (CheckDirectory(_lstTextBox[nTextBox].Text))
            folderDialog.SelectedPath = _lstTextBox[nTextBox].Text;

         DialogResult dlgRes = folderDialog.ShowDialog(this);

         if (dlgRes == DialogResult.OK)
         {
            _lstTextBox[nTextBox].Text = folderDialog.SelectedPath;
         }


      }

      private void _btnAddNewPrinter_Click(object sender, EventArgs e)
      {
         try
         {
            FrmInstallPrinter frmInstallPrinter = new FrmInstallPrinter();
            DialogResult dialogResult = frmInstallPrinter.ShowDialog();

            if (dialogResult == DialogResult.OK)
            {
               Cursor = Cursors.WaitCursor;
               string newPrinterName = _currentPrinterName = frmInstallPrinter.PrinterName;
               string newPrinterPassword = "";

               PrintingUtilities.InstallNewPrinter(newPrinterName, newPrinterPassword);
               _currentPrinterName = newPrinterName;
               _EnableNetworkPrinting = frmInstallPrinter.EnableNetwork;

               FillLeadtoolsPrintersList(_currentPrinterName, _EnableNetworkPrinting);
               if (_cmbNetworkPrinters.Items.Count == 0)
               {
                  _cmbNetworkPrinters.Enabled = false;
                  _ckNetworkEnabled.Enabled = false;
                  _ckSharePrinter.Enabled = false;
                  _grpPrinterSettings.Enabled = false;
                  _btnUninstall.Enabled = false;
               }
               else
               {
                  _cmbNetworkPrinters.Enabled = true;
                  _ckNetworkEnabled.Enabled = true;
                  _ckSharePrinter.Enabled = true;
                  _grpPrinterSettings.Enabled = true;
                  _btnUninstall.Enabled = true;

                  _EnableNetworkPrinting = _printer.EnableNetworkPrinting;
                  _ckNetworkEnabled_CheckedChanged(null, null);

                  _ckSharePrinter.Checked = true;
                  PrinterConfiguration.SharePrinter(_cmbNetworkPrinters.SelectedItem.ToString(), _ckSharePrinter.Checked);
               }
            }
         }
         catch (Exception Ex)
         {
            MessageBox.Show(Ex.ToString(), "LEADTOOLS Printer Demo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
         }
         finally
         {
            Cursor = Cursors.Default;
         }

      }

      private void _txtLocation_TextChanged(object sender, EventArgs e)
      {
         CheckSettingsChanged();
      }

      private void _txtLocation_Leave(object sender, EventArgs e)
      {
         int nTextBox = Convert.ToInt32(((TextBox)sender).Tag);
         TextBox txtBox = _lstTextBox[nTextBox];
         _lstTextBox[nTextBox].Text = _lstTextBox[nTextBox].Text.Trim();
         CheckSettingsChanged();

         if (_printerSettings._lstFormats[nTextBox]._strSaveLocation != txtBox.Text)
            if (!CheckDirectory(txtBox.Text))
               txtBox.Text = _printerSettings._lstFormats[nTextBox]._strSaveLocation;
      }

      bool CheckSettingsChanged()
      {
         bool bSaveChanged = false;
         for (int i = 0; i < _lstTextBox.Count; i++)
         {
            if (_printerSettings._lstFormats[i]._strSaveLocation.ToUpper() != _lstTextBox[i].Text.ToUpper())
            {
               bSaveChanged = true;
               break;
            }
         }

         bool bDescreptionChanged = false;

         bDescreptionChanged = _txtPrinterDescription.Text != _printerSettings._strDescreption;

         return _btnSave.Enabled = bSaveChanged || bDescreptionChanged;
      }


      private void _txtPrinterDescription_TextChanged(object sender, EventArgs e)
      {
         CheckSettingsChanged();
      }

      private void _ckSharePrinter_CheckedChanged(object sender, EventArgs e)
      {
         PrinterConfiguration.SharePrinter(_cmbNetworkPrinters.SelectedItem.ToString(), _ckSharePrinter.Checked);
      }

      private DialogResult UninstallPrinter(string printerName)
      {
         DialogResult dialogResult = DialogResult.Ignore;

         try
         {
            string warningMessage = string.Format("Are you sure you want to remove the {0} printer from the system?", printerName);
            dialogResult = MessageBox.Show(warningMessage, Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dialogResult == DialogResult.Yes)
            {
               PrinterInfo printerInfo = new PrinterInfo();
               printerInfo.PrinterName = printerName;
               printerInfo.MonitorName = printerName;
               printerInfo.PortName = printerName;

               Printer.UnInstall(printerInfo);
               MessageBox.Show("Uninstalling Printer Completed Successfully", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
         }
         catch (Exception Ex)
         {
            MessageBox.Show(Ex.ToString(), Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
         }

         return dialogResult;
      }

      private void _btnUninstall_Click(object sender, EventArgs e)
      {
         if (UninstallPrinter(_printer.PrinterName) != DialogResult.Yes)
            return;

         FillLeadtoolsPrintersList(null, false);
         if (_cmbNetworkPrinters.Items.Count == 0)
         {
            _cmbNetworkPrinters.Enabled = false;
            _ckNetworkEnabled.Enabled = false;
            _ckSharePrinter.Enabled = false;
            _grpPrinterSettings.Enabled = false;
            _btnUninstall.Enabled = false;
         }
         else
         {
            _EnableNetworkPrinting = _printer.EnableNetworkPrinting;
            _ckNetworkEnabled_CheckedChanged(null, null);
         }

      }

      private void FrmMain_Shown(object sender, EventArgs e)
      {
         Activate();
      }
   }

   class PrinterSettings
   {
      public string _strDescreption;
      public List<PrinterFileFormat> _lstFormats;

      public PrinterSettings(string strDescreption, List<PrinterFileFormat> lstFormats)
      {
         _strDescreption = strDescreption;
         _lstFormats = lstFormats;
      }

      public PrinterSettings(byte[] bytes)
      {
         _lstFormats = new List<PrinterFileFormat>();
         SetBytes(bytes);
      }

      public PrinterSettings()
      {
         _strDescreption = "Insert actual printer descriptions here, this description will be sent to the " +
                            "user client demo as initialization data";

         _lstFormats = new List<PrinterFileFormat>();

         String PersonalFolder = (string)
               Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Shell Folders", "Common Documents", "");

         if (PersonalFolder == "")
            PersonalFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

         PrinterFileFormat fileFormat = new PrinterFileFormat("PDF", PersonalFolder);
         _lstFormats.Add(fileFormat);
         fileFormat = new PrinterFileFormat("DOC", PersonalFolder);
         _lstFormats.Add(fileFormat);
         fileFormat = new PrinterFileFormat("XPS", PersonalFolder);
         _lstFormats.Add(fileFormat);
         fileFormat = new PrinterFileFormat("TEXT", PersonalFolder);
         _lstFormats.Add(fileFormat);

      }

      public PrinterSettings(string strDescreption)
         : this()
      {

         _strDescreption = strDescreption;
      }

      public void AddFileFormat(PrinterFileFormat fileFormat)
      {
         _lstFormats.Add(fileFormat);
      }

      public byte[] GetBytes()
      {
         string strReturn = "";
         strReturn += _strDescreption;
         strReturn += "---";

         foreach (PrinterFileFormat fileFormat in _lstFormats)
         {
            strReturn += fileFormat._strFileFormat;
            strReturn += "---";
            strReturn += fileFormat._strSaveLocation;
            strReturn += "---";
         }

         Encoding unicode = Encoding.Unicode;

         return unicode.GetBytes(strReturn.ToCharArray());
      }

      public string GetSavePath(string strFormat)
      {
         foreach (PrinterFileFormat fileFormat in _lstFormats)
         {
            if (fileFormat._strFileFormat.ToUpper() == strFormat.ToUpper())
            {
               return fileFormat._strSaveLocation;
            }
         }

         return "";
      }

      public void SetBytes(byte[] bytes)
      {
         Encoding unicode = Encoding.Unicode;

         if (_lstFormats != null)
            _lstFormats.Clear();

         string strBytes = new string(unicode.GetChars(bytes));
         int nIndex;
         nIndex = strBytes.IndexOf("---");

         _strDescreption = strBytes.Substring(0, nIndex);
         strBytes = strBytes.Substring(nIndex + 3);

         string strFormat = "", strLocation = "";
         while (true)
         {
            try
            {
               nIndex = strBytes.IndexOf("---");
               strFormat = strBytes.Substring(0, nIndex);
               strBytes = strBytes.Substring(nIndex + 3);

               nIndex = strBytes.IndexOf("---");
               strLocation = strBytes.Substring(0, nIndex);
               strBytes = strBytes.Substring(nIndex + 3);

               PrinterFileFormat fileFormat = new PrinterFileFormat(strFormat, strLocation);
               _lstFormats.Add(fileFormat);

            }
            catch
            {
               break;
            }

         }
      }

   }

   class PrinterFileFormat
   {
      public string _strFileFormat;
      public string _strSaveLocation;

      public PrinterFileFormat(string strFileFormat, string strSaveLocation)
      {
         _strSaveLocation = strSaveLocation;
         _strFileFormat = strFileFormat;
      }
   }

   public class PrinterConfiguration
   {

      #region PRINTER_INFO_2
      [StructLayout(LayoutKind.Sequential)]
      struct PRINTER_INFO_2
      {
         [MarshalAs(UnmanagedType.LPStr)]
         public string pServerName;
         [MarshalAs(UnmanagedType.LPStr)]
         public string pPrinterName;
         [MarshalAs(UnmanagedType.LPStr)]
         public string pShareName;
         [MarshalAs(UnmanagedType.LPStr)]
         public string pPortName;
         [MarshalAs(UnmanagedType.LPStr)]
         public string pDriverName;
         [MarshalAs(UnmanagedType.LPStr)]
         public string pComment;
         [MarshalAs(UnmanagedType.LPStr)]
         public string pLocation;
         public IntPtr pDevMode;
         [MarshalAs(UnmanagedType.LPStr)]
         public string pSepFile;
         [MarshalAs(UnmanagedType.LPStr)]
         public string pPrintProcessor;
         [MarshalAs(UnmanagedType.LPStr)]
         public string pDatatype;
         [MarshalAs(UnmanagedType.LPStr)]
         public string pParameters;
         public IntPtr pSecurityDescriptor;
         public Int32 Attributes;
         public Int32 Priority;
         public Int32 DefaultPriority;
         public Int32 StartTime;
         public Int32 UntilTime;
         public Int32 Status;
         public Int32 cJobs;
         public Int32 AveragePPM;
      }
      #endregion PRINTER_INFO_2

      #region "Private Variables"
      private static IntPtr _hPrinter = new System.IntPtr();
      private static PRINTER_DEFAULTS _PrinterValues = new PRINTER_DEFAULTS();
      private static PRINTER_INFO_2 _pinfo = new PRINTER_INFO_2();
      private static IntPtr _PtrPrinterInfo;
      private static int _LastError;
      private static int _NBytesNeeded;
      private static long _NRet;
      private static System.Int32 _NJunk;
      #endregion

      #region "Win API Def"

      [DllImport("kernel32.dll", EntryPoint = "GetLastError", SetLastError = false,
      ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
      private static extern Int32 GetLastError();

      [DllImport("winspool.Drv", EntryPoint = "ClosePrinter", SetLastError = true,
      ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
      private static extern bool ClosePrinter(IntPtr hPrinter);


      [DllImport("winspool.Drv", EntryPoint = "GetPrinterA", SetLastError = true, CharSet = CharSet.Ansi,
      ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
      private static extern bool GetPrinter(IntPtr hPrinter, Int32 dwLevel,
      IntPtr pPrinter, Int32 dwBuf, out Int32 dwNeeded);

      [DllImport("winspool.Drv", EntryPoint = "OpenPrinterA", SetLastError = true, CharSet = CharSet.Ansi,
      ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
      private static extern bool OpenPrinter([MarshalAs(UnmanagedType.LPStr)] string szPrinter,
      out IntPtr hPrinter, ref PRINTER_DEFAULTS pd);

      [DllImport("winspool.drv", CharSet = CharSet.Ansi, SetLastError = true)]
      private static extern bool SetPrinter(IntPtr hPrinter, int Level, IntPtr
      pPrinter, int Command);

      [DllImport("winspool.drv", CharSet = CharSet.Ansi, SetLastError = true)]
      private static extern bool SetPrinter(IntPtr hPrinter, int Level, PRINTER_INFO_2
      pPrinter, int Command);


      #endregion

      #region "Constants"
      private const int DM_DUPLEX = 0x1000;
      private const int DM_IN_BUFFER = 8;
      private const int DM_OUT_BUFFER = 2;
      private const int PRINTER_ACCESS_ADMINISTER = 0x4;
      private const int PRINTER_ACCESS_USE = 0x8;
      private const int STANDARD_RIGHTS_REQUIRED = 0xF0000;
      private const int PRINTER_ALL_ACCESS = (STANDARD_RIGHTS_REQUIRED | PRINTER_ACCESS_ADMINISTER | PRINTER_ACCESS_USE);
      #endregion

      [StructLayout(LayoutKind.Sequential)]
      public struct PRINTER_DEFAULTS
      {
         public IntPtr pDatatype;
         public IntPtr pDevMode;
         public ulong DesiredAccess;
      }

      public static bool IsPrinterShared(string printerName)
      {
         bool bShare = false;
         PRINTER_INFO_2 pi2;
         pi2 = GetPrinterSettings(printerName);

         pi2.pSecurityDescriptor = IntPtr.Zero;

         if ((pi2.Attributes & (uint)0x8) == (uint)0x8)
            bShare = true;

         Marshal.FreeHGlobal(_PtrPrinterInfo);
         return bShare;
      }

      public static bool SharePrinter(string printerName, bool share)
      {
         try
         {
            _pinfo = GetPrinterSettings(printerName);
            _pinfo.pSecurityDescriptor = IntPtr.Zero;


            if (share)
            {
               _pinfo.pShareName = printerName;
               _pinfo.Attributes |= 0x8;
            }
            else
            {
               _pinfo.Attributes = _pinfo.Attributes & (~0x8);
            }

            Marshal.StructureToPtr(_pinfo, _PtrPrinterInfo, false);
            _LastError = Marshal.GetLastWin32Error();

            _NRet = Convert.ToInt16(SetPrinter(_hPrinter, 2, _PtrPrinterInfo, 0));

            if (_NRet == 0)
            {
               _LastError = Marshal.GetLastWin32Error();
               throw new Win32Exception(Marshal.GetLastWin32Error());
            }
         }
         finally
         {
            if (_hPrinter != IntPtr.Zero)
            {

               ClosePrinter(_hPrinter);
            }
         }
         Marshal.FreeHGlobal(_PtrPrinterInfo);
         return Convert.ToBoolean(_NRet);
      }

      private static PRINTER_INFO_2 GetPrinterSettings(string PrinterName)
      {
         const int PRINTER_ACCESS_ADMINISTER = 0x4;
         const int PRINTER_ACCESS_USE = 0x8;
         const int PRINTER_ALL_ACCESS = (STANDARD_RIGHTS_REQUIRED | PRINTER_ACCESS_ADMINISTER | PRINTER_ACCESS_USE);

         _PrinterValues.pDatatype = IntPtr.Zero;
         _PrinterValues.pDevMode = IntPtr.Zero;
         _PrinterValues.DesiredAccess = PRINTER_ALL_ACCESS;
         _NRet = Convert.ToInt32(OpenPrinter(PrinterName, out _hPrinter, ref _PrinterValues));
         if (_NRet == 0)
         {
            _LastError = Marshal.GetLastWin32Error();
            throw new Win32Exception(Marshal.GetLastWin32Error());
         }
         GetPrinter(_hPrinter, 2, IntPtr.Zero, 0, out _NBytesNeeded);
         if (_NBytesNeeded <= 0)
         {
            throw new System.Exception("Unable to allocate memory");

         }
         else
         {
            _PtrPrinterInfo = Marshal.AllocHGlobal(_NBytesNeeded);

            _NRet = Convert.ToInt32(GetPrinter(_hPrinter, 2, _PtrPrinterInfo, _NBytesNeeded, out _NJunk));

            if (_NRet == 0)
            {
               _LastError = Marshal.GetLastWin32Error();
               throw new Win32Exception(Marshal.GetLastWin32Error());
            }
            _pinfo = (PRINTER_INFO_2)Marshal.PtrToStructure(_PtrPrinterInfo, typeof(PRINTER_INFO_2));

            if ((_NRet == 0) || (_hPrinter == IntPtr.Zero))
            {

               _LastError = Marshal.GetLastWin32Error();
               throw new Win32Exception(Marshal.GetLastWin32Error());
            }
            return _pinfo;
         }

      }
   }
}
