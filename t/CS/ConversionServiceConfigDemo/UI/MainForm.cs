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
using System.IO;
using System.ServiceProcess;
using System.Reflection;
using ConversionServiceHelper;
using Leadtools.Demos;
using System.Diagnostics;
using Microsoft.Win32;

namespace ConversionServiceConfigDemo
{
   public partial class MainForm : Form
   {
      public MainForm()
      {
         InitializeComponent();

         Messager.Caption = "C# Conversion Service Configuration Demo";
      }

      bool _bServiceInstalled = false;

      private void Form1_Load(object sender, EventArgs e)
      {
         try
         {
            this.Text = Messager.Caption;
            LoadSettings();
            UpdateServiceStatus();
         }
         catch
         {
            Messager.ShowError(this, "Error loading application settings. The application will now close.");
            this.Close();
            return;
         }
      }

      private void LoadSettings()
      {
         string settingsFile = Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), Constants.ConfigFile);

         if (!File.Exists(settingsFile))
         {
            string projFolder = Application.ExecutablePath;
            int index = projFolder.ToLower().IndexOf("bin");
            projFolder = projFolder.Substring(0, index);

            settingsFile = Path.Combine(projFolder, Constants.ConfigFile);
         }

         SettingsHelper.ConversionSettings conversionSettings = SettingsHelper.LoadSettings(settingsFile);

         _txtJPEGInputPath.Text = conversionSettings.JPEGInputPath;
         _txtPDFInputPath.Text = conversionSettings.PDFInputPath;
         _txtOutputPath.Text = conversionSettings.OutputPath;
         _nudConversionFrequency.Value = conversionSettings.ConversionFrequency;
         _txtMoveSourceTo.Text = conversionSettings.MoveSourcePath;
         _chkDeleteSource.Checked = String.IsNullOrEmpty(conversionSettings.MoveSourcePath);
      }

      private void SaveSettings()
      {
         SettingsHelper.ConversionSettings conversionSettings = new SettingsHelper.ConversionSettings();

         conversionSettings.JPEGInputPath = _txtJPEGInputPath.Text;
         conversionSettings.PDFInputPath = _txtPDFInputPath.Text;
         conversionSettings.OutputPath = _txtOutputPath.Text;
         conversionSettings.ConversionFrequency = Convert.ToInt32(_nudConversionFrequency.Value);
         conversionSettings.MoveSourcePath = _txtMoveSourceTo.Text;

         SettingsHelper.SaveSettings(Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), Constants.ConfigFile), conversionSettings);
      }

      private bool CreateDirectory(string directory)
      {
         try
         {
            if (!Directory.Exists(directory))
               Directory.CreateDirectory(directory);

            return true;
         }
         catch (Exception ex)
         {
            string message = String.Format("An error occured while creating directory '{0}'. Exception = {1})", directory, ex.Message);
            Messager.ShowError(this, message);
            return false;
         }
      }

      private void _btnApply_Click(object sender, EventArgs e)
      {
         //Validate JPEG path
         if (String.IsNullOrEmpty(_txtJPEGInputPath.Text))
         {
            Messager.ShowError(this, "You must specify a valid path for the JPEG Input Directory.");
            return;
         }

         if (!CreateDirectory(_txtJPEGInputPath.Text))
            return;

         //Validate pdf path
         if (String.IsNullOrEmpty(_txtPDFInputPath.Text))
         {
            Messager.ShowError(this, "You must specify a valid path for the PDF Input Directory.");
            return;
         }

         if (!CreateDirectory(_txtPDFInputPath.Text))
            return;

         //Validate output path
         if (String.IsNullOrEmpty(_txtOutputPath.Text))
         {
            Messager.ShowError(this, "You must specify a valid path for the Output Directory.");
            return;
         }

         if (!CreateDirectory(_txtOutputPath.Text))
            return;

         //Validate move source to path
         if (!_chkDeleteSource.Checked)
         {
            if (String.IsNullOrEmpty(_txtMoveSourceTo.Text))
            {
               Messager.ShowError(this, "You must specify a valid path for the 'Move Source To' Directory.");
               return;
            }

            if (!CreateDirectory(_txtMoveSourceTo.Text))
               return;
         }

         string[] paths;
         if (_chkDeleteSource.Checked)
            paths = new string[] { _txtJPEGInputPath.Text, _txtPDFInputPath.Text, _txtOutputPath.Text };
         else
            paths = new string[] { _txtJPEGInputPath.Text, _txtPDFInputPath.Text, _txtOutputPath.Text, _txtMoveSourceTo.Text };

         if (!UniquePaths(paths))
         {
            Messager.ShowError(this, "All paths must be unique");
            return;
         }

         //Conversion frequency already validated by numeric up/down control

         try
         {
            SaveSettings();

            if (_bServiceInstalled)
               ForceServiceReload();

            Messager.ShowInformation(this, "The new settings have been successfully saved.");
         }
         catch
         {
            Messager.ShowError(this, "An error occured while savings the settings.");
            return;
         }
      }

      private bool UniquePaths(string[] paths)
      {
         for (int i = 0; i < paths.Length; i++)
         {
            for (int j = i + 1; j < paths.Length; j++)
            {
               if (String.Compare(paths[i], paths[j], true) == 0)
                  return false;
            }
         }

         return true;
      }

      private void _btnBrowseJPEGInputPath_Click(object sender, EventArgs e)
      {
         BrowsePath(_txtJPEGInputPath);
      }

      private void _btnBrowsePDFInputPath_Click(object sender, EventArgs e)
      {
         BrowsePath(_txtPDFInputPath);
      }

      private void _btnBrowseOutputPath_Click(object sender, EventArgs e)
      {
         BrowsePath(_txtOutputPath);
      }

      private void _btnBrowseMoveSourceTo_Click(object sender, EventArgs e)
      {
         BrowsePath(_txtMoveSourceTo);
      }

      private void BrowsePath(TextBox textBoxToUpdate)
      {
         using (FolderBrowserDialog fbd = new FolderBrowserDialog())
         {
            if (fbd.ShowDialog() == DialogResult.OK)
               textBoxToUpdate.Text = fbd.SelectedPath;
         }
      }

      private void _chkDeleteSource_CheckedChanged(object sender, EventArgs e)
      {
         _txtMoveSourceTo.Enabled = _btnBrowseMoveSourceTo.Enabled = !_chkDeleteSource.Checked;
         if (_chkDeleteSource.Checked)
            _txtMoveSourceTo.Text = String.Empty;
      }

      private void ForceServiceReload()
      {
         //Force the service to reload the settings
         using (ServiceController conversionService = new ServiceController(Constants.ServiceName))
         {
            if (conversionService.Status == ServiceControllerStatus.Running)
               conversionService.ExecuteCommand(Constants.ReloadSettingsCommand);
         }
      }

      private void UpdateServiceStatus()
      {
         _bServiceInstalled = false;

         try
         {
            ServiceController[] installedServices = ServiceController.GetServices();
            foreach (ServiceController installedService in installedServices)
            {
               if (String.Compare(installedService.ServiceName, Constants.ServiceName, true) == 0)
               {
                  _bServiceInstalled = true;

                  // If service is stopped failed, start the service
                  if (installedService.Status == ServiceControllerStatus.Stopped)
                  {
                     installedService.Start();
                  }

                  //Get the service path so we can update the radio buttons
                  string servicePath = GetServicePath();
                  if (!String.IsNullOrEmpty(servicePath))
                  {                     
                     if (servicePath.IndexOf("x64", StringComparison.InvariantCultureIgnoreCase) != -1)
                        _rbInstall64Bit.Checked = true;
                     else
                        _rbInstall32Bit.Checked = true;
                  }

                  break;
               }
            }
         }
         catch { }

         _lblConversionStatus.Text = _bServiceInstalled ? "Service Status: Installed" : "Service Status: Not Installed";
         _gbPlatform.Enabled =_btnInstallService.Enabled = !_bServiceInstalled;
         _btnUninstallService.Enabled = !_btnInstallService.Enabled;
      }

      private string GetServicePath()
      {
         try
         {
            //Get the installed path of the service
            string registryKey = String.Format(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\services\{0}", Constants.ServiceName);
            return (string)Registry.GetValue(registryKey, "ImagePath", String.Empty);
         }
         catch { return String.Empty; }
      }

      private void _btnInstallService_Click(object sender, EventArgs e)
      {
         //Install service. We need to build the correct paths to the service exe and InstallUtil.exe based on the platform and framework selected
         try
         {
            string installUtilPath = Environment.GetEnvironmentVariable("SYSTEMROOT");
            string servicePath = Application.ExecutablePath;
            int index = servicePath.ToLower().IndexOf("bin");
            servicePath = servicePath.Remove(index);

            if (_rbInstall32Bit.Checked)
            {
               //32 bit               
               //.NET 4
               servicePath = Path.Combine(servicePath, @"bin\dotnet4\win32\CSConversionServiceDemo_Original.exe");
               installUtilPath = Path.Combine(installUtilPath, @"Microsoft.NET\Framework\v4.0.30319\InstallUtil.exe");

               if (!File.Exists(servicePath))
               {
                  servicePath = Application.StartupPath;
                  int indexOfRoot = servicePath.ToLower().LastIndexOf("conversionserviceconfigdemo");
                  servicePath = servicePath.Substring(0, indexOfRoot) + @"ConversionServiceDemo\Bin\x86\Debug\CSConversionServiceDemo.exe";
                  if (!File.Exists(servicePath))
                     servicePath = servicePath.Substring(0, indexOfRoot) + @"ConversionServiceDemo\Bin\x86\Release\CSConversionServiceDemo.exe";
               }

            }
            else
            {
               //64 bit 
               //.NET 4
               servicePath = Path.Combine(servicePath, @"bin\dotnet4\x64\CSConversionServiceDemo_Original.exe");
               installUtilPath = Path.Combine(installUtilPath, @"Microsoft.NET\Framework64\v4.0.30319\InstallUtil.exe");

               if (!File.Exists(servicePath))
               {
                  servicePath = Application.StartupPath;
                  int indexOfRoot = servicePath.ToLower().LastIndexOf("conversionserviceconfigdemo");
                  servicePath = servicePath.Substring(0, indexOfRoot) + @"ConversionServiceDemo\Bin\x64\Debug\CSConversionServiceDemo.exe";
                  if (!File.Exists(servicePath))
                     servicePath = servicePath.Substring(0, indexOfRoot) + @"ConversionServiceDemo\Bin\x64\Release\CSConversionServiceDemo.exe";
               }

            }

            if (File.Exists(servicePath))
               RunInstallUtil(installUtilPath, servicePath);
            else
               Messager.ShowError(this, String.Format("{0} was not found", servicePath));
         }
         catch (Exception ex)
         {
            Messager.ShowError(this, ex.Message);
         }

         UpdateServiceStatus();
      }

      void RunInstallUtil(string installUtilPath, string servicePath)
      {
         ProcessStartInfo startInfo = new ProcessStartInfo();
         startInfo.FileName = installUtilPath;
         startInfo.Arguments = String.Format("\"{0}\"", servicePath);
         using (Process process = new Process())
         {
            process.StartInfo = startInfo;
            process.Start();
            process.WaitForExit();
            if (process.ExitCode == 0)
               Messager.ShowInformation(this, "Service successfully installed");
            else
               Messager.ShowInformation(this, String.Format("An error occured while installing the service. Return Code = {0}", process.ExitCode));
         }
      }

      private void _btnUninstallService_Click(object sender, EventArgs e)
      {
         if (!_bServiceInstalled)
         {
            Messager.ShowInformation(this, "Service is not installed");
            return;
         }

         using (Process process = new Process())
         {
            process.StartInfo.FileName = "CMD.exe";

            //Stopping the Service
            process.StartInfo.Arguments = "/c SC STOP " + Constants.ServiceName;
            process.Start();
            if (!process.WaitForExit(10000))
            {
               process.Close();
               MessageBox.Show(this, "The service is taking long time to get stopped", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
               UpdateServiceStatus();
               return;
            }

            //Deleting the Service
            process.StartInfo.Arguments = "/c SC DELETE " + Constants.ServiceName;
            process.Start();
            if (!process.WaitForExit(10000))
            {
               process.Close();
               MessageBox.Show(this, "The service is taking long time to get deleted", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
               UpdateServiceStatus();
               return;
            }

            if (process.ExitCode == 0)
               Messager.ShowInformation(this, "Service successfully uninstalled");
            else
               Messager.ShowInformation(this, String.Format("An error occured while uninstalling the service. Return Code = {0}", process.ExitCode));

            UpdateServiceStatus();
         }
      }
   }
}
