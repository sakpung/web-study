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
using Leadtools.Printer.Client.Installer;
using System.Security.Principal;
using System.Diagnostics;
using System.Drawing.Printing;
using System.Net;

namespace PrinterClientInstaller
{
   public partial class MainForm : Form
   {
      //list of the Connection we made
      List<NetworkConnection> _networkConnections = new List<NetworkConnection>();

      [STAThread]
      static void Main(string[] args)
      {
         try
         {
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
         Enabled = false;
         _txtPrinterDll.Text = Path.GetDirectoryName(Application.ExecutablePath) + "\\CSPrinterClientDemo.dll";
      }

      private void _btnBrowse_Click(object sender, EventArgs e)
      {
         OpenFileDialog dlgOpen = new OpenFileDialog();
         dlgOpen.Filter = "DLL File(*.dll)|*.dll";

         DialogResult dlgRes = dlgOpen.ShowDialog();

         if (dlgRes != DialogResult.OK)
            return;

         _txtPrinterDll.Text = dlgOpen.FileName;
      }

      private void _btnInstall_Click(object sender, EventArgs e)
      {
         string strServer, strPrinter;

         strServer = _txtServerName.Text;
         strPrinter = _cmbPrinters.Text.ToString();

         if (string.IsNullOrEmpty(strServer) || string.IsNullOrEmpty(strPrinter) || string.IsNullOrEmpty(_txtPrinterDll.Text))
         {
            MessageBox.Show(this, "Printer Name, Printer Server and Printer Demo DLL Should be specified", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
         }

         if (!File.Exists(_txtPrinterDll.Text))
         {
            MessageBox.Show(this, "Printer Demo DLL does not exist", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
         }

         try
         {
            PrinterInstaller.SetPrinterConnectionDll(strPrinter, _txtPrinterDll.Text, strServer);
            MessageBox.Show(this, "Printer installed and connected to demo DLL successfully", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
         }
         catch (PrinterDriverClientException ex)
         {
            MessageBox.Show(this, ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
      }

      private bool Is64Bit()
      {
         return IntPtr.Size == 8;
      }

      private void MainForm_Shown(object sender, EventArgs e)
      {
         Enabled = true;
         if(Is64Bit())
            Text = "LEADTOOLS C# Printer Client Installer 64-bit";
         else
            Text = "LEADTOOLS C# Printer Client Installer 32-bit";
         BringToFront();
      }

      private void _btnRefresh_Click(object sender, EventArgs e)
      {
         _cmbPrinters.Items.Clear();
         List<string> lstPrinters = new List<string>();

         //We need to have access to the printer server in order to list the shared printers
         //Do we have access?
         if (!NetShares.IsServerAccessible(_txtServerName.Text))
         {
            //We dont have access create attempt to connect to the server
            NetworkConnection netConnection = new NetworkConnection(_txtServerName.Text, this.Handle);
            if(netConnection.ConnectToServer())
            {
               //add the new connection to the list
               if (!_networkConnections.Contains(netConnection))
                  _networkConnections.Add(netConnection);
            }
            else
            {
               //we cant connect to server
               _cmbPrinters.Enabled = false;
               MessageBox.Show(this, "The requested server can not be accessed", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
               return;
            }
         }

         if (!String.IsNullOrEmpty(_txtServerName.Text))
            lstPrinters = NetShares.GetSharedPrinter(_txtServerName.Text);

         if (lstPrinters.Count <= 0)
         {
            _cmbPrinters.Enabled = false;
            MessageBox.Show(this, "No shared printers found in the domain", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
         }

         _cmbPrinters.Enabled = true;

         foreach (string strPrinter in lstPrinters)
         {
            _cmbPrinters.Items.Add(strPrinter);
         }

         if (_cmbPrinters.Items.Count > 0)
            _cmbPrinters.SelectedIndex = 0;
      }

      private void _txtServerName_TextChanged(object sender, EventArgs e)
      {
         _btnRefresh.Enabled = _txtServerName.Text.Length > 0;
      }

      private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
      {
         foreach (NetworkConnection connection in _networkConnections)
         {
            //Remove all connection we made.
            connection.DisconnectFromServer();
         }
      }
   }

   public class NetShares
   {
      #region External Calls
      [DllImport("Netapi32.dll", SetLastError = true)]
      static extern int NetApiBufferFree(IntPtr Buffer);
      [DllImport("Netapi32.dll", CharSet = CharSet.Unicode)]
      private static extern int NetShareEnum(
           StringBuilder ServerName,
           int level,
           ref IntPtr bufPtr,
           uint prefmaxlen,
           ref int entriesread,
           ref int totalentries,
           ref int resume_handle
           );
      #endregion
      #region External Structures

      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
      public struct SHARE_INFO_1
      {
         public string shi1_netname;
         public uint shi1_type;
         public string shi1_remark;
         public SHARE_INFO_1(string sharename, uint sharetype, string remark)
         {
            this.shi1_netname = sharename;
            this.shi1_type = sharetype;
            this.shi1_remark = remark;
         }
         public override string ToString()
         {
            return shi1_netname;
         }
      }
      #endregion

      const uint MAX_PREFERRED_LENGTH = 0xFFFFFFFF;
      const int NERR_Success = 0;
      private enum NetError : uint
      {
         NERR_Success = 0,
         NERR_BASE = 2100,
         NERR_UnknownDevDir = (NERR_BASE + 16),
         NERR_DuplicateShare = (NERR_BASE + 18),
         NERR_BufTooSmall = (NERR_BASE + 23),
      }
      private enum SHARE_TYPE : uint
      {
         STYPE_DISKTREE = 0,
         STYPE_PRINTQ = 1,
         STYPE_DEVICE = 2,
         STYPE_IPC = 3,
         STYPE_SPECIAL = 0x80000000,
      }

      public static bool IsServerAccessible(string Server)
      {
         int entriesread = 0;
         int totalentries = 0;
         int resume_handle = 0;
         IntPtr bufPtr = IntPtr.Zero;
         StringBuilder server = new StringBuilder(Server);

         //Try to enumerate the server resources
         int ret = NetShareEnum(server, 1, ref bufPtr, MAX_PREFERRED_LENGTH, ref entriesread, ref totalentries, ref resume_handle);
         NetApiBufferFree(bufPtr);

         //if we can enumerate then we have access to the server
         return ret == NERR_Success;
      }

      public static SHARE_INFO_1[] EnumNetShares(string Server)
      {
         List<SHARE_INFO_1> ShareInfos = new List<SHARE_INFO_1>();
         int entriesread = 0;
         int totalentries = 0;
         int resume_handle = 0;
         int nStructSize = Marshal.SizeOf(typeof(SHARE_INFO_1));
         IntPtr bufPtr = IntPtr.Zero;
         StringBuilder server = new StringBuilder(Server);
         int ret = NetShareEnum(server, 1, ref bufPtr, MAX_PREFERRED_LENGTH, ref entriesread, ref totalentries, ref resume_handle);
         if (ret == NERR_Success)
         {
            IntPtr currentPtr = bufPtr;
            for (int i = 0; i < entriesread; i++)
            {
               SHARE_INFO_1 shi1 = (SHARE_INFO_1)Marshal.PtrToStructure(currentPtr, typeof(SHARE_INFO_1));
               ShareInfos.Add(shi1);
               currentPtr = new IntPtr(currentPtr.ToInt32() + nStructSize);
            }
            NetApiBufferFree(bufPtr);
            return ShareInfos.ToArray();
         }
         else
         {
            ShareInfos.Add(new SHARE_INFO_1("ERROR=" + ret.ToString(), 10, string.Empty));
            return ShareInfos.ToArray();
         }
      }

      public static List<string> GetSharedPrinter(string Server)
      {
         List<string> lstString = new List<string>();
         SHARE_INFO_1[] shareInfo = EnumNetShares(Server);

         for (int i = 0; i < shareInfo.Length; i++)
         {
            SHARE_INFO_1 info = shareInfo[i];
            if (info.shi1_type == Convert.ToInt32(SHARE_TYPE.STYPE_PRINTQ))
            {
               lstString.Add(info.shi1_netname);
            }
         }

         return lstString;
      }
   }

   public class NetworkConnection : IEquatable<NetworkConnection>
   {
      #region External Calls

      [DllImport("mpr.dll")]
      private static extern int WNetUseConnection(IntPtr hWndOwner,
          NetResource lpNetResource, string lpPassword,
          string lpUserName, int dwFlags, string lpAccessName,
         ref int lpBufferSize, out int lpResult);

      [DllImport("mpr.dll")]
      private static extern int WNetCancelConnection2(string name, int flags,
      bool force);

      #endregion
      #region External Structures

      public enum ResourceDisplaytype : int
      {
         Generic = 0x0,
         Domain = 0x01,
         Server = 0x02,
         Share = 0x03,
         File = 0x04,
         Group = 0x05,
         Network = 0x06,
         Root = 0x07,
         Shareadmin = 0x08,
         Directory = 0x09,
         Tree = 0x0a,
         Ndscontainer = 0x0b
      }

      public enum ResourceType : int
      {
         Any = 0,
         Disk = 1,
         Print = 2,
         Reserved = 8,
      }

      public enum ResourceScope : int
      {
         Connected = 1,
         GlobalNetwork,
         Remembered,
         Recent,
         Context
      };

      [StructLayout(LayoutKind.Sequential)]
      public class NetResource
      {
         public ResourceScope Scope;
         public ResourceType ResourceType;
         public ResourceDisplaytype DisplayType;
         public int Usage;
         public string LocalName;
         public string RemoteName;
         public string Comment;
         public string Provider;
      }

      #endregion

      string _networkName;
      NetResource _netResource;
      IntPtr _mainWinHandle;

      public NetworkConnection(string networkName, IntPtr mainWinHandle)
      {
         _networkName = "\\\\" + networkName;
         _mainWinHandle = mainWinHandle;

         _netResource = new NetResource()
         {
            Scope = ResourceScope.GlobalNetwork,
            ResourceType = ResourceType.Disk,
            DisplayType = ResourceDisplaytype.Share,
            RemoteName = _networkName
         };
      }

      public void DisconnectFromServer()
      {
         //Cancel the connection to the server
         WNetCancelConnection2(_networkName, 0, true);
      }

      public bool ConnectToServer()
      {
         int nBuffSize = 0;
         int nResult = 0;
         //Connect to the server
         int result = WNetUseConnection(_mainWinHandle, _netResource, null, null, 8, null, ref nBuffSize, out nResult);

         return result == 0;
      }

      public bool Equals(NetworkConnection connection)
      {
         return connection._networkName == _networkName;
      }
   }
}
