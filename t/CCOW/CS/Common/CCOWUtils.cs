// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System.Security.Cryptography;
using System.Text;
using System;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;
using System.Reflection;
using System.Security.Permissions;
using System.Runtime.InteropServices;

namespace Leadtools.Demos
{
    public enum InstallPlatform
    {
        win32 = 0,
        x64 = 1
    };

    public class Win32Window : IWin32Window
    {
        private IntPtr _Handle = IntPtr.Zero;

        public Win32Window(IntPtr handle)
        {
            _Handle = handle;
        }

        #region IWin32Window Members

        public IntPtr Handle
        {
            get 
            {
                return _Handle;
            }
        }

        #endregion
    }

    public static class CCOWUtils
    {
        private static readonly Random random = new Random();
        private const string _Chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        public static string EncodePassword(string originalPassword)
        {
            //Declarations
            Byte[] originalBytes;
            Byte[] encodedBytes;
            MD5 md5;

            //Instantiate MD5CryptoServiceProvider, get bytes for original password and compute hash (encoded password)
            md5 = new MD5CryptoServiceProvider();
            originalBytes = ASCIIEncoding.Default.GetBytes(originalPassword);
            encodedBytes = md5.ComputeHash(originalBytes);

            //Convert encoded bytes back to a 'readable' string
            return BitConverter.ToString(encodedBytes);
        }

        public static string GetUniqueId(int size)
        {
            char[] buffer = new char[size];

            for (int i = 0; i < size; i++)
            {
                buffer[i] = _Chars[random.Next(_Chars.Length)];
            }
            return new string(buffer);
        }

        public static bool LauchAuthApplication(EventHandler handler)
        {
            string dbAuthAppFileName = Path.Combine(Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath), "CSCCOWAuthenticationDemo_Original.exe");

            if (!File.Exists(dbAuthAppFileName))
            {
                dbAuthAppFileName = Path.Combine(Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath), "CSCCOWAuthenticationDemo.exe");
            }

            if (File.Exists(dbAuthAppFileName))
            {
                Process dbAuthProcess = new Process();
                string[] args = Environment.GetCommandLineArgs();               

                dbAuthProcess.EnableRaisingEvents = true;
                dbAuthProcess.StartInfo.Arguments = string.Join(" ", args, 1, args.Length - 1);
                if(handler!=null)
                    dbAuthProcess.Exited += handler;
                dbAuthProcess.StartInfo.FileName = dbAuthAppFileName;
                if (dbAuthProcess.Start())
                {
                    return true;
                }
            }
            else
            {
                Messager.ShowError(null, "Could not find the CSCCOWAuthenticationDemo");
            }

            return false;
        }

        [DllImport("shfolder.dll", CharSet = CharSet.Auto)]
        private static extern int SHGetFolderPath(IntPtr hwndOwner, int nFolder, IntPtr hToken, int dwFlags, StringBuilder lpszPath);

        private const int CommonDocumentsFolder = 0x2e;

        private static string GetFolderPath()
        {
            StringBuilder lpszPath = new StringBuilder(260);
            // CommonDocuments is the folder than any Vista user (including 'guest') has read/write access
            SHGetFolderPath(IntPtr.Zero, (int)CommonDocumentsFolder, IntPtr.Zero, 0, lpszPath);
            string path = lpszPath.ToString();
            new FileIOPermission(FileIOPermissionAccess.PathDiscovery, path).Demand();
            return path;
        }

        public static string GetSettingsFilename(string demo, InstallPlatform platform)
        {
            string commonFolder = GetFolderPath();
            string sPlatform = "32";

            if (platform == InstallPlatform.x64)
            {
                sPlatform = "64";
            }
            else
            {
                sPlatform = "32";
            }

            string ext = Path.GetExtension(demo);
            string name = Path.GetFileNameWithoutExtension(demo);

            string settingsFilename = string.Format("{0}\\{1}{2}{3}_17.xml", commonFolder, name, sPlatform, ext);
            return settingsFilename;
        }

        private static string GetActiveScenarioFilename(InstallPlatform platform)
        {
            string commonFolder = GetFolderPath();            
            string settingsFilename = string.Format("{0}\\{1}_17.xml", commonFolder, "ActiveScenario");

            return settingsFilename;
        }

        public static string GetActiveScenarioFilename()
        {
            return GetActiveScenarioFilename(DemosGlobal.Is64Process() ? InstallPlatform.x64 : InstallPlatform.win32);
        }

        private static string GetSettingsFilename(string demo)
        {            
            if (DemosGlobal.Is64Process())
            {
                return GetSettingsFilename(demo, InstallPlatform.x64);
            }
            else
            {
                return GetSettingsFilename(demo, InstallPlatform.win32);
            }
        }

        private static string GetSettingsFilename()
        {
            string fullname = Assembly.GetExecutingAssembly().Location;
            string settingsFilename = GetSettingsFilename(Path.GetFileName(fullname));

            return settingsFilename;
        }

        public static void Restart()
        {
            string arguments = string.Empty;
            string[] args = Environment.GetCommandLineArgs();

            for (int i = 1; i < args.Length; i++)
            {
                arguments += args[i] + " ";
            }
          
            Process.Start(Application.ExecutablePath, arguments);
        }
    }
}
