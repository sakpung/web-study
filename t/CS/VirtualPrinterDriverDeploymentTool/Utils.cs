// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Security.Principal;

namespace VirtualPrinterDriverDeploymentTool
{
   public static class Utils
   {
      private const string LEADTOOLS_VIRTUAL_PRINTER = "LEADTOOLS VIRTUAL PRINTER";

      #region Helpers

      /// <summary>
      ///      Copy a file from <paramref name="sourcePath"/> to <paramref name="destPath"/>
      /// </summary>
      /// <param name="sourcePath">The full path to the source file</param>
      /// <param name="destPath">The full path to the destination</param>
      public static void CopyFile(string sourcePath, string destPath)
      {
         if (!File.Exists(sourcePath))
            throw new FileNotFoundException(string.Format("Missing required file:{0}{1}", Environment.NewLine, sourcePath));

         // Ensure the destination path exists
         string destDir = Path.GetDirectoryName(destPath);
         if (!Directory.Exists(destDir))
            Directory.CreateDirectory(destDir);

         File.Copy(sourcePath, destPath, true);

         // Fix the timestamps
         var sourceInfo = new FileInfo(sourcePath);
         var destInfo = new FileInfo(destPath)
         {
            Attributes = sourceInfo.Attributes,
            CreationTime = sourceInfo.CreationTime,
            CreationTimeUtc = sourceInfo.CreationTimeUtc,
            LastAccessTime = sourceInfo.LastAccessTime,
            LastAccessTimeUtc = sourceInfo.LastAccessTimeUtc,
            LastWriteTime = sourceInfo.LastWriteTime,
            LastWriteTimeUtc = sourceInfo.LastWriteTimeUtc,
            IsReadOnly = sourceInfo.IsReadOnly
         };
      }

      /// <summary>
      ///      Get the paths to the PrinterDriver and Virtual Printer folders (these are different depending on if the
      ///      deployment directory is inside a LEADTOOLS SDK installation or not)
      /// </summary>
      /// <param name="deploymentDir">Full path to the deployment directory</param>
      /// <param name="printerDriverFolder">Out parameter, the full path to the PrinterDriver folder</param>
      /// <param name="virtualPrinterFolder">Out parameter, the full path to the Virtual Printer folder</param>
      /// <param name="inLEADOverride">If the installation should be treated as being in an SDK installation</param>
      /// <returns>If the deployment directory appears to be a LEADTOOLS installation</returns>
      public static bool GetFolders(string deploymentDir, out string printerDriverFolder, out string virtualPrinterFolder, bool inLEADOverride)
      {
         bool inLEAD = inLEADOverride || (File.Exists(Path.Combine(deploymentDir, @"Lv.ico")) && new Regex(@"LEADTOOLS \d{2}(?:\.\d)?[\\/]?$", RegexOptions.IgnoreCase).IsMatch(deploymentDir));
         printerDriverFolder = Path.Combine(deploymentDir, inLEAD ? @"Bin\Common\PrinterDriver" : @"PrinterDriver");
         virtualPrinterFolder = Path.Combine(deploymentDir, inLEAD ? @"Redist\Virtual Printer" : @"Virtual Printer");
         return inLEAD;
      }

      /// <summary>
      ///      Installs a printer driver package from the given path and environment
      /// </summary>
      /// <param name="infPath">Full path to the INF file</param>
      /// <param name="environment">The processor architecture (for example, Windows NT x86)</param>
      public static void InstallDriverPackage(string infPath, string environment)
      {
         IntPtr handle = GetDesktopWindow();
         StringBuilder targetPath = new StringBuilder(512);
         ulong targetPathLength = (ulong)targetPath.Capacity;

         // Try to upload the package
         int result = UploadPrinterDriverPackage(null, infPath, environment, UPDP_UPLOAD_ALWAYS, handle, targetPath, out targetPathLength);
         if (result != S_OK)
            throw new Exception(string.Format("Unable to upload printer driver package: {0}", result));

         // Try to install the package
         result = InstallPrinterDriverFromPackage(null, targetPath.ToString(), LEADTOOLS_VIRTUAL_PRINTER, environment, 0);
         if (result != S_OK)
            throw new Exception(string.Format("Unable to install printer driver from package: {0}", result));
      }

      /// <summary>
      ///      Check if the program is running as administrator
      /// </summary>
      /// <remarks>
      /// https://stackoverflow.com/a/18525782/8945895
      /// </remarks>
      /// <returns>If the current user is an administrator</returns>
      public static bool IsUserAdministrator()
      {
         bool isAdmin;
         try
         {
            WindowsIdentity user = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new WindowsPrincipal(user);
            isAdmin = principal.IsInRole(WindowsBuiltInRole.Administrator);
         }
         catch (UnauthorizedAccessException)
         {
            isAdmin = false;
         }
         catch (Exception)
         {
            isAdmin = false;
         }
         return isAdmin;
      }

      /// <summary>
      ///      Check if the current operating system is Windows Vista or later
      /// </summary>
      /// <remarks>
      ///      https://stackoverflow.com/a/2732463/8945895
      /// </remarks>
      /// <returns>If the current operating system is Windows Vista or later</returns>
      public static bool IsVistaOrLater()
      {
         OperatingSystem OS = Environment.OSVersion;
         return (OS.Platform == PlatformID.Win32NT) && (OS.Version.Major >= 6);
      }

      /// <summary>
      ///      Attempt to execute the specified program
      /// </summary>
      /// <param name="fileName">The file to execute</param>
      /// <param name="arguments">Command line arguments</param>
      /// <param name="directory">Working directory</param>
      private static void ShellExecute(string fileName, string arguments, string directory)
      {
         ProcessStartInfo processStartInfo = new ProcessStartInfo
         {
            Arguments = arguments,
            CreateNoWindow = false,
            FileName = fileName,
            UseShellExecute = true,
            WindowStyle = ProcessWindowStyle.Normal,
            WorkingDirectory = directory
         };
         Process process = null;
         try
         {
            process = Process.Start(processStartInfo);
            if (process == null)
               throw new Exception("Program failed to start");
         }
         catch (Exception ex)
         {
            throw new Exception(string.Format("Unable to launch process: {0} {1}: {2}", fileName, arguments, ex.Message));
         }
         if (!process.HasExited)
            process.WaitForExit();
         if (process.ExitCode != 0)
            throw new Exception(string.Format("The process exitted with a non-zero code: {0} {1} -> {2}", fileName, arguments, process.ExitCode));
      }

      /// <summary>
      ///      Try to register a component
      /// </summary>
      /// <param name="printerDriverFolder">Full path to the PrinterDriver folder</param>
      /// <param name="file">The file name</param>
      public static void RegisterComponent(string printerDriverFolder, string file)
      {
         if (file.ToLower().EndsWith(".dll"))
            ShellExecute("regsvr32.exe", string.Format("/s \"{0}\"", file), printerDriverFolder);
         else
            ShellExecute(file, "/Regserver", printerDriverFolder);
      }

      /// <summary>
      ///      Uninstalls the printer driver for the given environment
      /// </summary>
      /// <param name="environment">The processor architecture (for example, Windows NT x86)</param>
      public static void UninstallPrinterDriver(string environment)
      {
         Task<Win32Exception> uninstallTask = Task.Factory.StartNew(() =>
         {
            if (!DeletePrinterDriverEx(null, environment, LEADTOOLS_VIRTUAL_PRINTER, DPD_DELETE_ALL_FILES, 0))
            {
               Win32Exception lastError = new Win32Exception(Marshal.GetLastWin32Error());
               if (CheckIfPrinterDriverInstalled(environment, LEADTOOLS_VIRTUAL_PRINTER) == S_OK)
                  return lastError;
            }
            return null;
         });
         if (!uninstallTask.Wait(30000))
            throw new Exception("Uninstallation of printer driver took longer than 30 seconds");
         else if (uninstallTask.Result != null)
            throw uninstallTask.Result;
      }

      /// <summary>
      ///      Try to unregister a component
      /// </summary>
      /// <param name="printerDriverFolder">Full path to the PrinterDriver folder</param>
      /// <param name="file">The file name</param>
      public static void UnregisterComponent(string printerDriverFolder, string file)
      {
         if (file.ToLower().EndsWith(".dll"))
            ShellExecute("regsvr32.exe", string.Format("/u /s \"{0}\"", file), printerDriverFolder);
         else
            ShellExecute(file, "/UnRegserver", printerDriverFolder);
      }

      #endregion

      #region Interop Methods

      /// <summary>
      ///      The DeletePrinterDriverEx function removes the specified printer-driver name from the list of names of
      ///      supported drivers on a server and deletes the files associated with the driver. This function can also
      ///      delete specific versions of the driver.
      /// </summary>
      /// <remarks>
      ///      https://msdn.microsoft.com/en-us/library/windows/desktop/dd183546(v=vs.85).aspx
      /// </remarks>
      /// <param name="pName">
      ///      A pointer to a null-terminated string that specifies the name of the server from which the driver is to
      ///      be deleted. If this parameter is NULL, the function deletes the printer-driver from the local computer.
      /// </param>
      /// <param name="pEnvironment">
      ///      A pointer to a null-terminated string that specifies the environment from which the driver is to be
      ///      deleted (for example, Windows NT x86, Windows IA64, or Windows x64). If this parameter is NULL, the
      ///      driver name is deleted from the current environment of the calling application and client computer (not
      ///      of the destination application and print server).
      /// </param>
      /// <param name="pDriverName">
      ///      A pointer to a null-terminated string specifying the name of the driver to delete.
      /// </param>
      /// <param name="dwDeleteFlag">
      ///      The options for deleting files and versions of the driver. This parameter can be one or more of the
      ///      following values.
      ///      <para />
      ///      DPD_DELETE_SPECIFIC_VERSION (0x00000002) : Deletes the version specified in
      ///      <paramref name="dwVersionFlag"/>. This does not ensure that the driver will be removed from the list of
      ///      supported drivers for the server.
      ///      <para />
      ///      DPD_DELETE_UNUSED_FILES (0x00000001) : Removes any unused driver files
      ///      <para />
      ///      DPD_DELETE_ALL_FILES (0x00000004) : Deletes the driver only if all its associated files can be removed.
      ///      The delete operation fails if any of the driver's files are being used by some other installed driver.
      ///      <para />
      ///      If DPD_DELETE_SPECIFIC_VERSION is not specified, the function deletes all versions of the driver if
      ///      none of them is in use. If neither DPD_DELETE_UNUSED_FILES nor DPD_DELETE_ALL_FILES is specified, the
      ///      function does not delete driver files.
      /// </param>
      /// <param name="dwVersionFlag">
      ///      The version of the driver to be deleted. This parameter can be 0, 1, 2 or 3. This parameter is used
      ///      only if <paramref name="dwDeleteFlag"/> includes the DPD_DELETE_SPECIFIC_VERSION flag.
      /// </param>
      /// <returns>If the function was successful</returns>
      [DllImport("Winspool.drv", SetLastError = true)]
      [return: MarshalAs(UnmanagedType.Bool)]
      private static extern bool DeletePrinterDriverEx(string pName, string pEnvironment, string pDriverName, int dwDeleteFlag, int dwVersionFlag);

      /// <summary>
      ///      Check if the a printer driver is installed with the given name and environment
      /// </summary>
      /// <param name="pEnvironment">
      ///      A pointer to a constant, null-terminated string that specifies the processor architecture (for example,
      ///      Windows NT x86). This can be NULL.
      /// </param>
      /// <param name="pDriverName">
      ///      A pointer to a null-terminated string specifying the name of the driver to check for
      ///   </param>
      /// <returns>The status of the search</returns>
      [DllImport("UtilityLibrary.dll", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
      private static extern int CheckIfPrinterDriverInstalled([MarshalAs(UnmanagedType.LPTStr)]string pEnvironment, [MarshalAs(UnmanagedType.LPTStr)]string pDriverName);

      /// <summary>
      ///      Retrieves a handle to the desktop window. The desktop window covers the entire screen. The desktop
      ///      window is the area on top of which other windows are painted.
      /// </summary>
      /// <remarks>
      ///      https://msdn.microsoft.com/en-us/library/windows/desktop/ms633504(v=vs.85).aspx
      /// </remarks>
      /// <returns>The return value is a handle to the desktop window</returns>
      [DllImport("user32.dll")]
      private static extern IntPtr GetDesktopWindow();

      /// <summary>
      ///      Installs a printer driver from a driver package that is in the print server's driver store
      /// </summary>
      /// <remarks>
      ///      https://msdn.microsoft.com/en-us/library/windows/desktop/dd144997(v=vs.85).aspx
      /// </remarks>
      /// <param name="pszServer">
      ///      A pointer to a constant, null-terminated string that specifies the name of the print server. NULL means
      ///      the local computer.
      ///   </param>
      /// <param name="pszInfPath">
      ///      A pointer to a constant, null-terminated string that specifies the driver store path to the print
      ///      driver's .inf file. NULL means the driver is in an inf file that shipped with Windows.
      /// </param>
      /// <param name="pszDriverName">
      ///      A pointer to a constant, null-terminated string that specifies the name of the driver.
      /// </param>
      /// <param name="pszEnvironment">
      ///      A pointer to a constant, null-terminated string that specifies the processor architecture (for example,
      ///      Windows NT x86). This can be NULL.
      /// </param>
      /// <param name="dwFlags">
      ///      This can only be 0 or IPDFP_COPY_ALL_FILES. A value of 0 means that the printer driver must be added
      ///      and any files in the printer driver directory that are newer than corresponding files currently in use
      ///      must be copied. A value of IPDFP_COPY_ALL_FILES means the printer driver and all the files in the
      ///      printer driver directory must be added. The file time stamps are ignored when dwFlags has a value of
      ///      IPDFP_COPY_ALL_FILES.
      /// </param>
      /// <returns>
      ///      If the operation succeeds, the return value is S_OK (0), otherwise the result will contain an error
      ///      code
      /// </returns>
      [DllImport("Winspool.drv")]
      private static extern Int32 InstallPrinterDriverFromPackage(string pszServer, string pszInfPath, string pszDriverName, string pszEnvironment, uint dwFlags);

      /// <summary>
      ///      Uploads a printer driver to the print server's driver store so that it can be installed by calling
      ///      <see cref="InstallPrinterDriverFromPackage(string, string, string, string, uint)"/>
      /// </summary>
      /// <remarks>
      ///      https://msdn.microsoft.com/en-us/library/windows/desktop/dd145168(v=vs.85).aspx
      /// </remarks>
      /// <param name="pszServer">
      ///      A pointer to a constant, null-terminated string that specifies the name of the print server. Use NULL
      ///      if the server is the local computer.
      /// </param>
      /// <param name="pszInfPath">
      ///      A pointer to a constant ,null-terminated string that specifies the source path to the driver's .inf
      ///      file.
      /// </param>
      /// <param name="pszEnvironment">
      ///      A pointer to a constant, null-terminated string that specifies the server's processor architecture (for
      ///      example, Windows NT x86). This can be NULL.
      /// </param>
      /// <param name="dwFlags">
      ///      This can be any of the following values:
      ///      <para />
      ///      UPDP_SILENT_UPLOAD (0x00000001) : The UI will not be shown during the upload
      ///      <para />
      ///      UPDP_UPLOAD_ALWAYS (0x00000002) : The files will be uploaded even if the package is already in the
      ///      server's driver store
      ///      <para />
      ///      UPDP_CHECK_DRIVERSTORE (0x00000004) : The server's driver store will be checked before upload to see if
      ///      the package is already there. This setting is ignored if UPDP_UPLOAD_ALWAYS is set.
      /// </param>
      /// <param name="hwnd">A handle to the copying user interface</param>
      /// <param name="pszDestInfPath">
      ///      A pointer to the destination path, in the driver store, to which the driver's .inf file was copied
      /// </param>
      /// <param name="pcchDestInfPath">
      ///      On input, specifies the size, in characters, of the <paramref name="pszDestInfPath"/> buffer. On
      ///      output, receives the size, in characters, of the path string, including the terminating null character.
      /// </param>
      /// <returns>
      ///      If the operation succeeds, the return value is S_OK (0), otherwise the result will contain an error
      ///      code
      /// </returns>
      [DllImport("Winspool.drv")]
      private static extern Int32 UploadPrinterDriverPackage(string pszServer, string pszInfPath, string pszEnvironment, uint dwFlags, IntPtr hwnd, StringBuilder pszDestInfPath, out ulong pcchDestInfPath);

      #endregion

      #region Windows SDK Constants

      /// <summary>
      ///      Delete all files associated with the printer driver
      /// </summary>
      /// <remarks>
      ///      See WinSpool.h
      /// </remarks>
      private const int DPD_DELETE_ALL_FILES = 0x00000004;

      /// <summary>
      ///      The specified printer driver is currently in use
      /// </summary>
      /// <remarks>
      ///      See WinError.h
      /// </remarks>
      public const int ERROR_PRINTER_DRIVER_IN_USE = 3001;

      /// <summary>
      ///      Success code
      /// </summary>
      /// <remarks>
      ///      See WinError.h
      /// </remarks>
      private const Int32 S_OK = 0x00000000;

      /// <summary>
      ///      Will not do the optimization of not uploading the files if the driver package is already present on
      ///      remote machine.
      /// </summary>
      /// <remarks>
      ///      See WinSpool.h
      /// </remarks>
      private const int UPDP_UPLOAD_ALWAYS = 0x00000002;

      #endregion
   }
}
