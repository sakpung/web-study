// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.ServiceProcess;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VirtualPrinterDriverDeploymentTool
{
   public partial class MainForm : Form
   {
      /// <summary>
      ///      Files that will be copied into the 64-bit System32 folder
      /// </summary>
      /// <remarks>
      ///      Item1: Name of file
      ///      Item2: If the file gets copied into the spool folders
      /// </remarks>
      private Tuple<string, bool>[] filesForSystem32X64 = new Tuple<string, bool>[]
      {
            new Tuple<string, bool>(@"LPDRV06x.dll", true),
            new Tuple<string, bool>(@"LPPMN06x.dll", false),
            new Tuple<string, bool>(@"LPUID06x.dll", true)
      };

      /// <summary>
      ///      Files that will be copied into the 32-bit System32 folder
      /// </summary>
      /// <remarks>
      ///      Item1: Name of file
      ///      Item2: If the file gets copied into the spool folders
      /// </remarks>
      private Tuple<string, bool>[] filesForSystem32Win32 = new Tuple<string, bool>[]
      {
            new Tuple<string, bool>(@"LPDRV06n.dll", true),
            new Tuple<string, bool>(@"LPPMN06u.dll", false),
            new Tuple<string, bool>(@"LPUID06n.dll", true)
      };

      /// <summary>
      ///      Create a new MainForm
      /// </summary>
      public MainForm()
      {
         InitializeComponent();

         // Initialize deployment directory to a temp folder (will get overwritten if previously modified)
         string deployDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), @"PrinterDriver");
         // If they have LEADTOOLS installed at the default location, use that instead
         if (Directory.Exists(@"C:\LEADTOOLS 20") && File.Exists(@"C:\LEADTOOLS 20\Lv.ico"))
         {
            Properties.Settings.Default.DeployDir = deployDir = @"C:\LEADTOOLS 20";
            Properties.Settings.Default.InLEADOverride = true;
            Properties.Settings.Default.Save();
         }
         textBoxDeploymentDirectory.Text = textBoxUninstallDirectory.Text = deployDir;

         // Setup shield icon
         Icon shieldIcon = new Icon(SystemIcons.Shield, buttonDeploy.Height, buttonDeploy.Height);
         Bitmap shieldBitmap = shieldIcon.ToBitmap();
         buttonDeploy.Image = buttonUninstall.Image = shieldBitmap;
         buttonDeploy.ImageAlign = buttonUninstall.ImageAlign = ContentAlignment.MiddleLeft;

         // Restore settings
         if (!string.IsNullOrWhiteSpace(Properties.Settings.Default.LeadtoolsDir))
            textBoxLeadtoolsInstallDirectory.Text = Properties.Settings.Default.LeadtoolsDir;
         if (!string.IsNullOrWhiteSpace(Properties.Settings.Default.DeployDir))
            textBoxDeploymentDirectory.Text = textBoxUninstallDirectory.Text = Properties.Settings.Default.DeployDir;
         checkBoxDualInstall.Checked = Properties.Settings.Default.DualInstall;
         checkBoxInLEAD.Checked = Properties.Settings.Default.InLEADOverride;

#if WIN64
         // Default to 64-bit if running 64-bit version
         comboBoxTargetBitness.SelectedIndex = 1;
#else
         // Restrict to 32-bit if not 64-bit build
         comboBoxTargetBitness.SelectedIndex = 0;
         comboBoxTargetBitness.Enabled = false;
         checkBoxDualInstall.Checked = checkBoxDualInstall.Enabled = false;
#endif

         // Show the main panel
         ShowPanel(tableLayoutPanelMain);
      }

      /// <summary>
      ///      Create a package ZIP from the required files
      /// </summary>
      /// <param name="sender">Unused</param>
      /// <param name="e">Unused</param>
      private void ButtonCreatePackage_Click(object sender, EventArgs e)
      {
         // Ensure the directory exists
         string leadtoolsDir = textBoxLeadtoolsInstallDirectory.Text;
         if (!Directory.Exists(leadtoolsDir))
         {
            MessageBox.Show("The input directory does not exist");
            return;
         }

         // Ensure there is at least one bitness selected
         if (!checkBoxIncludeWin32.Checked && !checkBoxIncludex64.Checked)
         {
            MessageBox.Show("You must have at least one bitness (Win32 or x64) selected");
            return;
         }

         // Prompt for an output ZIP file path
         string zipFile = null;
         using (SaveFileDialog dlg = new SaveFileDialog())
         {
            dlg.FileName = "Package.zip";
            dlg.Filter = "ZIP Files (*.zip)|*.zip";
            if (dlg.ShowDialog() == DialogResult.OK)
               zipFile = Path.GetFullPath(dlg.FileName);
         }

         // Exit if no zip chosen
         if (string.IsNullOrEmpty(zipFile))
            return;

         // Get a temp directory for building the ZIP
         string tempDir = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
         Directory.CreateDirectory(tempDir);

         // Create the ZIP
         Cursor = Cursors.WaitCursor;
         try
         {
            List<string> requiredFiles = new List<string>
            {
               @"Common\Bin\LeadtoolsPrinter.exe",
               @"Common\ComSrv\LPCLB06n.dll",
               @"Common\ComSrv\LPCMG06n.exe",
               @"Common\ComSrv\LPCPN06N.dll",
               @"Common\ComSrv\LpPrinterThunk.exe",
               @"Common\ComSrv\LpPrnCon.dll",
               @"Common\ComSrv\LPWSE06n.exe"
            };
            if (checkBoxIncludeWin32.Checked)
               requiredFiles.AddRange(new List<string>
               {
                  @"CDLL\Win32\ltPrinterClientInstalleru.dll",
                  @"CDLL\Win32\ltPrinteru.dll",
                  @"Common\Driver\Win32\LPPMn06u.dll",
                  @"DriverPackageX86\i386\LPDRV06n.dll",
                  @"DriverPackageX86\i386\LPUID06n.dll",
                  @"DriverPackageX86\LeadtoolsVirtualPrinter.INF",
                  @"DriverPackageX86\leadtoolsvirtualprinter_x86.cat"
               });
            if (checkBoxIncludex64.Checked)
               requiredFiles.AddRange(new List<string>
               {
                  @"CDLL\x64\ltPrinterClientInstallerx.dll",
                  @"CDLL\x64\ltPrinterx.dll",
                  @"Common\Driver\x64\LPPMn06x.dll",
                  @"DriverPackageX64\amd64\LPDRV06x.dll",
                  @"DriverPackageX64\amd64\LPUID06x.dll",
                  @"DriverPackageX64\LeadtoolsVirtualPrinter.INF",
                  @"DriverPackageX64\leadtoolsvirtualprinter_amd64.cat"
               });
            foreach (string file in requiredFiles)
               Utils.CopyFile(Path.Combine(leadtoolsDir, @"Redist\Virtual Printer", file), Path.Combine(tempDir, file));

            // Zip up the temp directory
            ZipFile.CreateFromDirectory(tempDir, zipFile);

            // Delete the temp directory
            new DirectoryInfo(tempDir).Attributes &= ~FileAttributes.ReadOnly;
            Directory.Delete(tempDir, true);

            Cursor = Cursors.Default;
            MessageBox.Show("Package created successfully");
         }
         catch (Exception ex)
         {
            new DirectoryInfo(tempDir).Attributes &= ~FileAttributes.ReadOnly;
            Directory.Delete(tempDir, true);

            Cursor = Cursors.Default;
            MessageBox.Show(string.Format("Failed to create package: {0}", ex.Message));
         }
      }

      /// <summary>
      ///      Deploy a package ZIP
      /// </summary>
      /// <param name="sender">Unused</param>
      /// <param name="e">Unused</param>
      private void ButtonDeploy_Click(object sender, EventArgs e)
      {
         string deploymentDir = textBoxDeploymentDirectory.Text;

         // Check if the user is an administrator
         if (!Utils.IsUserAdministrator())
         {
            MessageBox.Show("You must be running this application as administrator to deploy a package", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
         }

         // Get the ZIP file
         string zipFile = null;
         using (OpenFileDialog dlg = new OpenFileDialog())
         {
            dlg.FileName = "Package.zip";
            dlg.Filter = "ZIP Files (*.zip)|*.zip";
            if (dlg.ShowDialog() == DialogResult.OK)
               zipFile = Path.GetFullPath(dlg.FileName);
         }

         // Exit if no zip chosen
         if (string.IsNullOrEmpty(zipFile))
            return;

         // Update the saved path if altered manually
         if (deploymentDir != Properties.Settings.Default.DeployDir)
         {
            // Update other text box
            textBoxUninstallDirectory.Text = deploymentDir;

            // Remember
            Properties.Settings.Default.DeployDir = deploymentDir;
         }

         // Update the internal state
         bool inLEADOverride = checkBoxInLEAD.Checked;
         Properties.Settings.Default.InLEADOverride = inLEADOverride;
         Properties.Settings.Default.Save();

         // Create the temporary directory for unzipping
         string tempDir = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
         Directory.CreateDirectory(tempDir);

         // Callbacks for dialog
         bool target64 = comboBoxTargetBitness.SelectedIndex == 1;
         bool dualInstall = checkBoxDualInstall.Checked;
         Action<ProcessDialog> task = new Action<ProcessDialog>((dlg) => Install(dlg, tempDir, deploymentDir, zipFile, target64, dualInstall, inLEADOverride));
         Action cleanup = new Action(() =>
         {
            if (Directory.Exists(tempDir))
            {
               new DirectoryInfo(tempDir).Attributes &= ~FileAttributes.ReadOnly;
               Directory.Delete(tempDir, true);
            }
         });

         // Install
         using (ProcessDialog dlg = new ProcessDialog("Deploying Package...", task, cleanup))
            dlg.ShowDialog();
      }

      /// <summary>
      ///      Browse for a new deployment directory
      /// </summary>
      /// <param name="sender">Unused</param>
      /// <param name="e">Unused</param>
      private void ButtonDeploymentDirectory_Click(object sender, EventArgs e)
      {
         using (FolderBrowserDialog dlg = new FolderBrowserDialog())
         {
            dlg.ShowNewFolderButton = true;
            if (Directory.Exists(textBoxDeploymentDirectory.Text))
               dlg.SelectedPath = textBoxDeploymentDirectory.Text;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
               // Set text
               string dir = Path.GetFullPath(dlg.SelectedPath);
               textBoxDeploymentDirectory.Text = textBoxUninstallDirectory.Text = dir;

               // Remember
               Properties.Settings.Default.DeployDir = dir;
               Properties.Settings.Default.Save();
            }
         }
      }

      /// <summary>
      ///      Goto the deploy panel
      /// </summary>
      /// <param name="sender">Unused</param>
      /// <param name="e">Unused</param>
      private void ButtonGotoDeploy_Click(object sender, EventArgs e)
      {
         ShowPanel(tableLayoutPanelDeploy);
      }

      /// <summary>
      ///      Goto the development panel
      /// </summary>
      /// <param name="sender">Unused</param>
      /// <param name="e">Unused</param>
      private void ButtonGotoDevelopment_Click(object sender, EventArgs e)
      {
         ShowPanel(tableLayoutPanelDevelopment);
      }

      /// <summary>
      ///      Goto the main panel
      /// </summary>
      /// <param name="sender">Unused</param>
      /// <param name="e">Unused</param>
      private void ButtonGotoMain_Click(object sender, EventArgs e)
      {
         ShowPanel(tableLayoutPanelMain);
      }

      /// <summary>
      ///      Goto the uninstall panel
      /// </summary>
      /// <param name="sender">Unused</param>
      /// <param name="e">Unused</param>
      private void ButtonGotoUninstall_Click(object sender, EventArgs e)
      {
         ShowPanel(tableLayoutPanelUninstall);
      }

      /// <summary>
      ///      Browse for a different LEADTOOLS installation directory
      /// </summary>
      /// <param name="sender">Unused</param>
      /// <param name="e">Unused</param>
      private void ButtonLeadtoolsInstallDirectory_Click(object sender, EventArgs e)
      {
         using (FolderBrowserDialog dlg = new FolderBrowserDialog())
         {
            dlg.ShowNewFolderButton = false;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
               // Ensure the directory exists
               string dir = Path.GetFullPath(dlg.SelectedPath);
               if (!Directory.Exists(dir))
               {
                  MessageBox.Show("The selected directory does not exist");
                  return;
               }

               // Set to text box
               textBoxLeadtoolsInstallDirectory.Text = dir;

               // Remember
               Properties.Settings.Default.LeadtoolsDir = dir;
               Properties.Settings.Default.Save();
            }
         }
      }

      /// <summary>
      ///      Uninstall the deployed package
      /// </summary>
      /// <param name="sender">Unused</param>
      /// <param name="e">Unused</param>
      private void ButtonUninstall_Click(object sender, EventArgs e)
      {
         string deploymentDir = textBoxUninstallDirectory.Text;

         // Check if the user is an administrator
         if (!Utils.IsUserAdministrator())
         {
            MessageBox.Show("You must be running this application as administrator to deploy a package", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
         }

         // Ensure the directory exists
         if (!Directory.Exists(deploymentDir))
         {
            MessageBox.Show("Selected directory does not exist");
            return;
         }

         // Callback for dialog
         Action<ProcessDialog> task = new Action<ProcessDialog>((dlg) => Uninstall(dlg, deploymentDir));

         // Install
         using (ProcessDialog dlg = new ProcessDialog("Uninstalling Package...", task))
            dlg.ShowDialog();
      }

      /// <summary>
      ///      Browse for a different uninstall directory
      /// </summary>
      /// <param name="sender">Unused</param>
      /// <param name="e">Unused</param>
      private void ButtonUninstallDirectory_Click(object sender, EventArgs e)
      {
         using (FolderBrowserDialog dlg = new FolderBrowserDialog())
         {
            dlg.ShowNewFolderButton = true;
            if (Directory.Exists(textBoxUninstallDirectory.Text))
               dlg.SelectedPath = textBoxUninstallDirectory.Text;
            if (dlg.ShowDialog() == DialogResult.OK)
               textBoxUninstallDirectory.Text = Path.GetFullPath(dlg.SelectedPath);
         }
      }

      /// <summary>
      ///      Save the new dual install preference
      /// </summary>
      /// <param name="sender">Unused</param>
      /// <param name="e">Unused</param>
      private void BheckBoxDualInstall_CheckedChanged(object sender, EventArgs e)
      {
         // Remember
         Properties.Settings.Default.DualInstall = checkBoxDualInstall.Checked;
         Properties.Settings.Default.Save();
      }

      /// <summary>
      ///      Enable/disable the dual install checkbox based on new target bitness
      /// </summary>
      /// <param name="sender">Unused</param>
      /// <param name="e">Unused</param>
      private void ComboBoxTargetBitness_SelectedIndexChanged(object sender, EventArgs e)
      {
         // Only enable the dual install option for 64-bite
         checkBoxDualInstall.Enabled = comboBoxTargetBitness.SelectedIndex == 1;
      }

      /// <summary>
      ///      Copy a file and log it
      /// </summary>
      /// <param name="dlg">The dialog that will display the output</param>
      /// <param name="sourcePath">Full path to the source file</param>
      /// <param name="destPath">Full path to the destination</param>
      private void CopyFile(ProcessDialog dlg, string sourcePath, string destPath)
      {
         try
         {
            Utils.CopyFile(sourcePath, destPath);
            dlg.Log(string.Format("Copied \"{0}\" to \"{1}\"", sourcePath, destPath));
         }
         catch (Exception ex)
         {
            throw new Exception(string.Format("Failed to copy \"{0}\" to \"{1}\"{2}{3}", sourcePath, destPath, Environment.NewLine, ex.Message));
         }
      }

      /// <summary>
      ///      Copy a file from the package's temporary directory and log it
      /// </summary>
      /// <param name="dlg">The dialog that will display the output</param>
      /// <param name="tempDir">The temporary directory for extracting the package ZIP</param>
      /// <param name="sourceSubPath">Local path (relative to the temporary directory) to the source file</param>
      /// <param name="destPath">Full path to the destination</param>
      private void CopyFromPackage(ProcessDialog dlg, string tempDir, string sourceSubPath, string destPath)
      {
         try
         {
            Utils.CopyFile(Path.Combine(tempDir, sourceSubPath), destPath);
            dlg.Log(string.Format("Copied \"Package\\{0}\" to \"{1}\"", sourceSubPath, destPath));
         }
         catch (Exception ex)
         {
            throw new Exception(string.Format("Failed to copy \"Package\\{0}\" to \"{1}\"{2}{3}", sourceSubPath, destPath, Environment.NewLine, ex.Message));
         }
      }

      /// <summary>
      ///      Delete a file if it exists and log it
      /// </summary>
      /// <param name="dlg">The dialog that will display the output</param>
      /// <param name="filePath">The full path to the file to delete</param>
      private void DeleteIfPresent(ProcessDialog dlg, string filePath)
      {
         int retries = 3;
         while (retries > 0 && File.Exists(filePath))
         {
            try
            {
               Task<Exception> deletionTask = Task.Factory.StartNew(() =>
               {
                  try
                  {
                     new FileInfo(filePath).Attributes &= ~FileAttributes.ReadOnly;
                     File.Delete(filePath);
                  }
                  catch (Exception ex)
                  {
                     return ex;
                  }
                  return null;
               });
               if (!deletionTask.Wait(10000))
                  throw new Exception("Deletion took longer than 10 seconds");
               else if (deletionTask.Result != null)
                  throw deletionTask.Result;
               else
               {
                  dlg.Log(string.Format("Deleted \"{0}\"", filePath));
                  return;
               }
            }
            catch (Exception ex)
            {
               if (retries-- <= 0)
                  throw new Exception(string.Format("Failed to delete \"{0}\"{1}{2}", filePath, Environment.NewLine, ex.Message));
               else
                  Thread.Sleep(1000);
            }
         }
         dlg.Log(string.Format("File not found, skipped deleting: \"{0}\"", filePath));
      }

      /// <summary>
      ///      Copy the various files from the temporary directory to the desired locations
      /// </summary>
      /// <param name="dlg">The dialog that will display the output</param>
      /// <param name="tempDir">The temporary directory for extracting the package ZIP</param>
      /// <param name="installWin32">Whether or not to extract the 32-bit files</param>
      /// <param name="installX64">Whether or not to extract the 64-bit files</param>
      /// <param name="printerDriverFolder">Full path to the PrinterDriver folder</param>
      /// <param name="virtualPrinterFolder">Full path to the Virtual Printer folder</param>
      private void ExtractPackage(ProcessDialog dlg, string tempDir, bool installWin32, bool installX64, string printerDriverFolder, string virtualPrinterFolder)
      {
         // Copy to PrinterDriver folder
         CopyFromPackage(dlg, tempDir, @"Common\Bin\LeadtoolsPrinter.exe", Path.Combine(printerDriverFolder, @"Bin\LeadtoolsPrinter.exe"));
         List<string> filesToCopy = new List<string>
               {
                  "LPCLB06n.dll",
                  "LPCMG06n.exe",
                  "LPCPN06N.dll",
                  "LpPrinterThunk.exe",
                  "LpPrnCon.dll",
                  "LPWSE06n.exe"
               };
         foreach (string file in filesToCopy)
            CopyFromPackage(dlg, tempDir, Path.Combine(@"Common\ComSrv", file), Path.Combine(printerDriverFolder, file));

         // Ensure there is a blank Spool folder
         string spoolDirectory = Path.Combine(printerDriverFolder, "Spool");
         if (!Directory.Exists(spoolDirectory))
         {
            Directory.CreateDirectory(spoolDirectory);
            dlg.Log("Created Spool directory");
         }

         // Copy to Virtual Printer folder
         filesToCopy = new List<string>
               {
                  @"Common\Bin\LeadtoolsPrinter.exe",
                  @"Common\ComSrv\LPCLB06n.dll",
                  @"Common\ComSrv\LPCMG06n.exe",
                  @"Common\ComSrv\LPCPN06N.dll",
                  @"Common\ComSrv\LpPrinterThunk.exe",
                  @"Common\ComSrv\LpPrnCon.dll",
                  @"Common\ComSrv\LPWSE06n.exe"
               };
         if (installWin32)
            filesToCopy.AddRange(new List<string>
                  {
                     @"CDLL\Win32\ltPrinterClientInstalleru.dll",
                     @"CDLL\Win32\ltPrinteru.dll",
                     @"Common\Driver\Win32\LPPMn06u.dll",
                     @"DriverPackageX86\i386\LPDRV06n.dll",
                     @"DriverPackageX86\i386\LPUID06n.dll",
                     @"DriverPackageX86\LeadtoolsVirtualPrinter.INF",
                     @"DriverPackageX86\leadtoolsvirtualprinter_x86.cat"
                  });
         if (installX64)
            filesToCopy.AddRange(new List<string>
                  {
                     @"CDLL\x64\ltPrinterClientInstallerx.dll",
                     @"CDLL\x64\ltPrinterx.dll",
                     @"Common\Driver\x64\LPPMn06x.dll",
                     @"DriverPackageX64\amd64\LPDRV06x.dll",
                     @"DriverPackageX64\amd64\LPUID06x.dll",
                     @"DriverPackageX64\LeadtoolsVirtualPrinter.INF",
                     @"DriverPackageX64\leadtoolsvirtualprinter_amd64.cat"
                  });
         foreach (string file in filesToCopy)
            CopyFromPackage(dlg, tempDir, file, Path.Combine(virtualPrinterFolder, file));

         // Copy certain files to another location
         if (installWin32)
         {
            CopyFromPackage(dlg, tempDir, @"DriverPackageX86\i386\LPDRV06n.dll", Path.Combine(virtualPrinterFolder, @"Common\Driver\Win32\LPDRV06n.dll"));
            CopyFromPackage(dlg, tempDir, @"DriverPackageX86\i386\LPUID06n.dll", Path.Combine(virtualPrinterFolder, @"Common\Driver\Win32\LPUID06n.dll"));
         }
         if (installX64)
         {
            CopyFromPackage(dlg, tempDir, @"DriverPackageX64\amd64\LPDRV06x.dll", Path.Combine(virtualPrinterFolder, @"Common\Driver\x64\LPDRV06x.dll"));
            CopyFromPackage(dlg, tempDir, @"DriverPackageX64\amd64\LPUID06x.dll", Path.Combine(virtualPrinterFolder, @"Common\Driver\x64\LPUID06x.dll"));
         }
      }

      /// <summary>
      ///      Perform the installation
      /// </summary>
      /// <param name="dlg">The dialog that will display the output</param>
      /// <param name="tempDir">The temporary directory for extracting the package ZIP</param>
      /// <param name="deploymentDir">Where to deploy the package</param>
      /// <param name="zipFile">Full path to the package ZIP</param>
      /// <param name="target64">If deploying to 64-bit</param>
      /// <param name="dualInstall">If 32-bit drivers should also be installed during a 64-bit installation</param>
      /// <param name="inLEADOverride">If the installation should be treated as being in an SDK installation</param>
      private void Install(ProcessDialog dlg, string tempDir, string deploymentDir, string zipFile, bool target64, bool dualInstall, bool inLEADOverride)
      {
         // Unzip
         try
         {
            ZipFile.ExtractToDirectory(zipFile, tempDir);
            dlg.Log("Unzipped package to temporary directory");
         }
         catch (Exception ex)
         {
            dlg.Finished(string.Format("Unable to extract package to temporary directory:{0}{1}", Environment.NewLine, ex.Message));
            return;
         }

         // Copy files and install
         try
         {
            // Check for what's in the package
            bool hasWin32 = File.Exists(Path.Combine(tempDir, @"DriverPackageX86\LeadtoolsVirtualPrinter.INF"));
            bool hasX64 = File.Exists(Path.Combine(tempDir, @"DriverPackageX64\LeadtoolsVirtualPrinter.INF"));
            if (!hasWin32 && !hasX64)
               throw new Exception("Missing all required files");

            // Ensure the different installation options are detected
            bool installWin32 = !target64 || dualInstall;
            if (!hasWin32 && installWin32)
               throw new Exception("Missing 32-bit required files");
            bool installX64 = target64;
            if (!hasX64 && installX64)
               throw new Exception("Missing 64-bit required files");

            // Different folder structure if in the LEADTOOLS root
            bool inLEAD = Utils.GetFolders(deploymentDir, out string printerDriverFolder, out string virtualPrinterFolder, inLEADOverride);
            if (inLEAD && !inLEADOverride)
               dlg.Log("Deployment path appears to be in LEADTOOLS installation");

            // Extract package
            ExtractPackage(dlg, tempDir, installWin32, installX64, printerDriverFolder, virtualPrinterFolder);
            dlg.Log("Finished extracting package");

            // Install the printers
            InstallPrinters(dlg, installWin32, installX64, printerDriverFolder, virtualPrinterFolder);
            dlg.Log("Printer drivers installed successfully");

            // Clean up temporary folder
            new DirectoryInfo(tempDir).Attributes &= ~FileAttributes.ReadOnly;
            Directory.Delete(tempDir, true);
            dlg.Log("Deleted temporary directory");

            // All done
            dlg.Finished(string.Format("Deployment package installed successfully{0}Note: A restart may be required before the functionality is available", Environment.NewLine));
         }
         catch (Exception ex)
         {
            dlg.Finished(string.Format("Unable to install deployment package:{0}{1}", Environment.NewLine, ex.Message));
         }
      }

      /// <summary>
      ///      Install the printers following the guide:
      ///      https://www.leadtools.com/help/leadtools/v20/dh/to/printer-driver-files-to-be-included-with-your-application.html
      /// </summary>
      /// <param name="dlg">The dialog that will display the output</param>
      /// <param name="installWin32">Whether or not to install the 32-bit drivers</param>
      /// <param name="installX64">Whether or not to install the 64-bit drivers</param>
      /// <param name="printerDriverFolder">Full path to the PrinterDriver folder</param>
      /// <param name="virtualPrinterFolder">Full path to the Virtual Printer folder</param>
      private void InstallPrinters(ProcessDialog dlg, bool installWin32, bool installX64, string printerDriverFolder, string virtualPrinterFolder)
      {
         // Install the printer driver packages (only for Vista or later)
         if (Utils.IsVistaOrLater())
         {
            dlg.Log("Installing driver package(s)");
            if (installX64)
            {
               Utils.InstallDriverPackage(Path.Combine(virtualPrinterFolder, @"DriverPackageX64\LeadtoolsVirtualPrinter.INF"), "Windows x64");
               dlg.Log("Installed 64-bit driver package");
            }
            if (installWin32)
            {
               Utils.InstallDriverPackage(Path.Combine(virtualPrinterFolder, @"DriverPackageX86\LeadtoolsVirtualPrinter.INF"), "Windows NT x86");
               dlg.Log("Installed 32-bit driver package");
            }
         }

         // Stop the spooler service
         dlg.Log("Stopping spooler service...");
         ServiceController spoolerService = new ServiceController("Spooler");
         spoolerService.Stop();
         spoolerService.WaitForStatus(ServiceControllerStatus.Stopped);
         dlg.Log("Spooler service stopped");

         try
         {
            // Copy files to System32
            if (installX64)
            {
               string system32 = Environment.GetFolderPath(Environment.SpecialFolder.System);
               foreach (Tuple<string, bool> pair in filesForSystem32X64)
               {
                  // Get the source path
                  string sourcePath = Path.Combine(virtualPrinterFolder, @"Common\Driver\x64", pair.Item1);

                  // Copy to System32
                  CopyFile(dlg, sourcePath, Path.Combine(system32, pair.Item1));

                  if (pair.Item2)
                  {
                     // Copy to System32\spool\drivers\x64
                     CopyFile(dlg, sourcePath, Path.Combine(system32, @"spool\drivers\x64", pair.Item1));

                     // Copy to System32\spool\drivers\x64\3
                     string destPath = Path.Combine(system32, @"spool\drivers\x64\3", pair.Item1);
                     try
                     {
                        CopyFile(dlg, sourcePath, destPath);
                     }
                     catch (Exception ex)
                     {
                        if (Utils.IsVistaOrLater() && File.Exists(destPath))
                           dlg.Log(string.Format("File already exists (driver package may have installed), skipped copying \"{0}\" to \"{1}\"", sourcePath, destPath));
                        else
                           throw ex;
                     }
                  }
               }
            }
            if (installWin32)
            {
               string system32 = Environment.GetFolderPath(Environment.SpecialFolder.SystemX86);
               foreach (Tuple<string, bool> pair in filesForSystem32Win32)
               {
                  // Get the source path
                  string sourcePath = Path.Combine(virtualPrinterFolder, @"Common\Driver\Win32", pair.Item1);

                  // Copy to System32
                  CopyFile(dlg, sourcePath, Path.Combine(system32, pair.Item1));

                  if (pair.Item2)
                  {
                     // Copy to System32\spool\drivers\W32X86
                     CopyFile(dlg, sourcePath, Path.Combine(system32, @"spool\drivers\W32X86", pair.Item1));

                     // Copy to System32\spool\drivers\W32X86\3
                     string destPath = Path.Combine(system32, @"spool\drivers\W32X86\3", pair.Item1);
                     try
                     {
                        CopyFile(dlg, sourcePath, destPath);
                     }
                     catch (Exception ex)
                     {
                        if (Utils.IsVistaOrLater() && File.Exists(destPath))
                           dlg.Log(string.Format("File already exists (driver package may have installed), skipped copying \"{0}\" to \"{1}\"", sourcePath, destPath));
                        else
                           throw ex;
                     }
                  }
               }
            }
         }
         catch (Exception ex)
         {
            dlg.Log("There was a problem...");
            throw ex;
         }
         finally
         {
            // Start the spooler service again
            dlg.Log("Starting spooler service...");
            spoolerService.Start();
            spoolerService.WaitForStatus(ServiceControllerStatus.Running);
            dlg.Log("Spooler service started");
         }

         // Register common components
         string[] commonFiles = new string[]
         {
            "LPCLB06N.dll",
            "LPCMG06N.exe",
            "LPWSE06N.exe",
            "LPCPN06N.dll",
            "LPPRNCON.dll",
            "LpPrinterThunk.exe"
         };
         foreach (string file in commonFiles)
         {
            Utils.RegisterComponent(printerDriverFolder, file);
            dlg.Log(string.Format("Registered {0}", file));
         }
      }

      /// <summary>
      ///      Set <paramref name="target"/> as the current visible panel (disables all other panels)
      /// </summary>
      /// <param name="target">Panel to enable</param>
      private void ShowPanel(TableLayoutPanel target)
      {
         // Disable all panels
         foreach (Control control in Controls)
            if (control is TableLayoutPanel tableLayoutPanel)
               tableLayoutPanel.Enabled = tableLayoutPanel.Visible = false;

         // Enable target
         target.Enabled = target.Visible = true;
      }

      /// <summary>
      ///      Perform the uninstallation
      /// </summary>
      /// <param name="dlg">The dialog that will display the output</param>
      /// <param name="deploymentDir">Where to deploy the package</param>
      private void Uninstall(ProcessDialog dlg, string deploymentDir)
      {
         // Different folder structure if in the LEADTOOLS root
         bool inLEADOverride = Properties.Settings.Default.InLEADOverride;
         bool inLEAD = Utils.GetFolders(deploymentDir, out string printerDriverFolder, out string virtualPrinterFolder, inLEADOverride);
         if (inLEAD && !inLEADOverride)
            dlg.Log("Deployment path appears to be in LEADTOOLS installation");

         try
         {
            // Uninstall the printer drivers (only for Vista or later)
            if (Utils.IsVistaOrLater())
            {
               dlg.Log("Uninstalling printer driver(s)");
               try
               {
                  if (File.Exists(Path.Combine(virtualPrinterFolder, @"DriverPackageX64\LeadtoolsVirtualPrinter.INF")))
                  {
                     dlg.Log("Uninstalling 64-bit printer driver...");
                     Utils.UninstallPrinterDriver("Windows x64");
                     dlg.Log("Successfully uninstalled 64-bit printer driver");
                  }
                  if (File.Exists(Path.Combine(virtualPrinterFolder, @"DriverPackageX86\LeadtoolsVirtualPrinter.INF")))
                  {
                     dlg.Log("Uninstalling 32-bit printer driver...");
                     Utils.UninstallPrinterDriver("Windows NT x86");
                     dlg.Log("Successfully uninstalled  32-bit printer driver");
                  }
               }
               catch (Win32Exception ex)
               {
                  if (inLEAD && ex.NativeErrorCode == Utils.ERROR_PRINTER_DRIVER_IN_USE)
                     throw new Exception("Failed to uninstall driver package, it is currently in use. Please ensure there are no LEADTOOLS printers currently running.");
                  else
                     throw ex;
               }
            }

            // Stop the spooler service
            dlg.Log("Stopping spooler service...");
            ServiceController spoolerService = new ServiceController("Spooler");
            spoolerService.Stop();
            spoolerService.WaitForStatus(ServiceControllerStatus.Stopped);
            dlg.Log("Spooler service stopped");

            try
            {
               // Delete 64-bit files from System32
               string system32X64 = Path.GetFullPath(Environment.GetFolderPath(Environment.SpecialFolder.System));
               foreach (Tuple<string, bool> pair in filesForSystem32X64)
               {
                  // Delete from System32
                  DeleteIfPresent(dlg, Path.Combine(system32X64, pair.Item1));

                  if (pair.Item2)
                  {
                     // Delete from System32\spool\drivers\x64
                     DeleteIfPresent(dlg, Path.Combine(system32X64, @"spool\drivers\x64", pair.Item1));

                     // Delete from System32\spool\drivers\x64\3
                     DeleteIfPresent(dlg, Path.Combine(system32X64, @"spool\drivers\x64\3", pair.Item1));
                  }
               }

               // Delete 32-bit files from System32
               string system32Win32 = Path.GetFullPath(Environment.GetFolderPath(Environment.SpecialFolder.SystemX86));
               foreach (Tuple<string, bool> pair in filesForSystem32Win32)
               {
                  // Delete from System32
                  DeleteIfPresent(dlg, Path.Combine(system32Win32, pair.Item1));

                  if (pair.Item2)
                  {
                     // Delete from System32\spool\drivers\W32X86
                     DeleteIfPresent(dlg, Path.Combine(system32Win32, @"spool\drivers\W32X86", pair.Item1));

                     // Delete from System32\spool\drivers\W32X86\3
                     DeleteIfPresent(dlg, Path.Combine(system32Win32, @"spool\drivers\W32X86\3", pair.Item1));
                  }
               }
            }
            catch (Exception ex)
            {
               dlg.Log("There was a problem...");
               throw ex;
            }
            finally
            {
               // Start the spooler service again
               dlg.Log("Starting spooler service...");
               spoolerService.Start();
               spoolerService.WaitForStatus(ServiceControllerStatus.Running);
               dlg.Log("Spooler service started");
            }

            // Unregister common components
            string[] commonFiles = new string[]
            {
            "LPCLB06N.dll",
            "LPCMG06N.exe",
            "LPWSE06N.exe",
            "LPCPN06N.dll",
            "LPPRNCON.dll",
            "LpPrinterThunk.exe"
            };
            foreach (string file in commonFiles)
            {
               if (File.Exists(Path.Combine(printerDriverFolder, file)))
               {
                  Utils.UnregisterComponent(printerDriverFolder, file);
                  dlg.Log(string.Format("Unregistered {0}", file));
               }
               else
                  dlg.Log(string.Format("File not found, skipped unregistering: {0}", file));
            }

            // Prompt for deletion inside LEADTOOLS installation
            if (inLEAD)
            {
               // Verify the user wants to delete the files
               if (MessageBox.Show("Deployment path appears to be inside a LEADTOOLS installation, would you like to delete the files anyway?", "Caution", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
               {
                  // Only delete the PrinterDriver and Virtual Printer folders, not the whole SDK
                  Directory.Delete(printerDriverFolder, true);
                  Directory.Delete(virtualPrinterFolder, true);
                  dlg.Log("PrinterDriver and Virtual Printer directories deleted");
               }
               else
                  dlg.Log("Deployment path inside LEADTOOLS installation, not deleting");
            }
            else
            {
               // Delete the entire directory
               Directory.Delete(deploymentDir, true);
               dlg.Log("Deployment path deleted");
            }

            // All done
            dlg.Finished("Deployment uninstalled successfully");
         }
         catch (Exception ex)
         {
            dlg.Finished(string.Format("Unable to uninstall:{0}{1}", Environment.NewLine, ex.Message));
         }
      }
   }
}
