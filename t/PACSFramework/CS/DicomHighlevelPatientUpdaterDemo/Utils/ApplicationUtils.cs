// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Threading;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace DicomDemo.Utils
{
    public enum LogonTypes : uint
    {
        Interactive = 2,
        Network,
        Batch,
        Service,
        NetworkCleartext = 8,
        NewCredentials
    }

    public enum LogonProviders : uint
    {
        Default = 0, // default for platform (use this!)
        WinNT35, // sends smoke signals to authority
        WinNT40, // uses NTLM
        WinNT50 // negotiates Kerb or NTLM
    }
    
    public static class ApplicationUtils
    {       
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool CloseHandle(IntPtr handle);

        [DllImport("advapi32.dll", SetLastError = true)]
        public static extern bool LogonUser(string principal,string authority,string password,
                                            LogonTypes logonType,LogonProviders logonProvider,out IntPtr token);
        [DllImport("user32.dll")]
        public static extern bool ShowWindowAsync(IntPtr hWnd, int nCmdShow);

        [DllImport("user32.dll")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        public static extern bool EnumWindows(EnumWindowsProcDel lpEnumFunc, Int32 lParam);

        [DllImport("user32.dll")]
        public static extern int GetWindowThreadProcessId(IntPtr hWnd,
            ref Int32 lpdwProcessId);

        [DllImport("user32.dll")]
        public static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString,
            Int32 nMaxCount);

        [DllImport("user32.dll")]
        public static extern IntPtr FindWindow(StringBuilder lpClassName, StringBuilder lpWindowName);

        public const int SW_SHOWNORMAL = 1;

        public static bool Login(string domain,string user, string password)
        {            
            IntPtr token;
            WindowsIdentity id;            

            bool result = LogonUser(user, domain, password, LogonTypes.Interactive,
                                    LogonProviders.Default, out token);

            if (!result)
                return false;

            id = new WindowsIdentity(token);
            CloseHandle(token);
            WindowsPrincipal p = new WindowsPrincipal(id);
            Thread.CurrentPrincipal = p;

            return true;
        }

        public static void SynchronizedInvoke(Control owner,MethodInvoker del)
        {
            if (owner!=null && owner.InvokeRequired)
                owner.BeginInvoke(del, null);
            else
                del();
        }

        public static void ShowException(Control owner,Exception e)
        {            
            SynchronizedInvoke(owner, () => MessageBox.Show(owner,e.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error));
        }

        public delegate bool EnumWindowsProcDel(IntPtr hWnd, Int32 lParam);

        static private bool EnumWindowsProc(IntPtr hWnd, Int32 lParam)
        {
           int processId = 0;
           GetWindowThreadProcessId(hWnd, ref processId);

           StringBuilder caption = new StringBuilder(1024);
           GetWindowText(hWnd, caption, 1024);

           // Use IndexOf to make sure our required string is in the title.
           if (processId == lParam && (caption.ToString().IndexOf(_requiredString,
               StringComparison.OrdinalIgnoreCase) != -1))
           {
              // Restore the window.
              ShowWindowAsync(hWnd, SW_SHOWNORMAL);
              SetForegroundWindow(hWnd);
           }
           return true; // Keep this.
        }

        static string _requiredString;

        static public bool IsOnlyProcess(string forceTitle)
        {
           string exeName = Path.GetFileNameWithoutExtension(Application.ExecutablePath);
           Process current = Process.GetCurrentProcess();

           _requiredString = forceTitle;

           foreach (Process proc in Process.GetProcessesByName(exeName).Where(process => process.SessionId == current.SessionId))
           {
              if (proc.Id != current.Id)
              {
                 EnumWindows(new EnumWindowsProcDel(EnumWindowsProc), proc.Id);

                 IntPtr windowHandle = FindWindow(null, new StringBuilder(proc.MainWindowTitle));

                 return false;
              }
           }

           return true;
        }
    }
}
