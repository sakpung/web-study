// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Text;
using Leadtools.Wia;
using Leadtools.Codecs;
using System.Collections;
using Leadtools.Demos;
using System.Windows.Forms;
using PrintToPACSDemo.UI;
using System.IO;

namespace PrintToPACSDemo
{
   public partial class FrmMain
   {
      public static WiaSession _wiaSession;
      public static WiaAcquireOptions _wiaAcquireOptions = WiaAcquireOptions.Empty;
      public static WiaProperties _wiaProperties = WiaProperties.Empty;
      public static WiaVersion _wiaVersion;
      public static WiaTransferMode _wiatransferMode;
      public static ArrayList _wiaerrorList;
      public static ArrayList _enumeratedItemsList;
      public static ArrayList _capabilitiesList;
      public static ArrayList _formatsList;
      public static ArrayList _flagValuesStrings;
      public static int _selectedItemIndex = -1;
      public static bool _forCapabilities = false;
      public static bool _showUserInterface = true;
      public static bool _acquireFromFeeder = true;
      public Leadtools.Demos.ProgressForm _progressDlg;
      private bool _wiaAvailable = false;
      private bool _wiaSourceSelected = false;
      private bool _wiaAcquiring = false;
      private object _sourceItem = null;
      ListImageBox.ImageCollection wiaImageCollection;


      private void InitializeWia()
      {
         if (_mySettings._settings.wiaVersion == 0)
            return;

         _wiaVersion = (WiaVersion)_mySettings._settings.wiaVersion;
         _wiaAvailable = WiaSession.IsAvailable(_wiaVersion);

         if (_wiaAvailable)
         {
            _wiaSession = new WiaSession();
            _wiaSession.Startup(_wiaVersion);
            _miWiaSelectSource.Enabled = true;

            // Set the default acquire path for file transfer to My Documents folder.
            string myDocumentsPath;
            HelperFunctions.GetFormatFilterAndExtension();

            myDocumentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            _wiaAcquireOptions.FileName = string.Format("{0}{1}{2}", myDocumentsPath, "\\WiaTest.", HelperFunctions.Extension);

            if (_wiaProperties.DataTransfer.TransferMode == WiaTransferMode.None) // GetProperties() method not called yet.
            {
               _wiatransferMode = WiaTransferMode.Memory;
            }
            else
            {
               _wiatransferMode = _wiaProperties.DataTransfer.TransferMode;
            }

            _wiaSession.AcquireEvent += new EventHandler<WiaAcquireEventArgs>(_wiaSession_AcquireEvent);
         }
         else
         {
            _miWiaSelectSource.Enabled = false;
         }

         _wiaerrorList = new ArrayList();
         _enumeratedItemsList = new ArrayList();
         _capabilitiesList = new ArrayList();
         _formatsList = new ArrayList();
         _flagValuesStrings = new ArrayList();

         _wiaSourceSelected = _mySettings._settings.wiaSelectedDevice != null;
         if (_wiaSourceSelected)
            try
            {
               _wiaSession.SelectDevice(_mySettings._settings.wiaSelectedDevice);
            }
            catch
            {
               _wiaSourceSelected = false;
            }

      }

      private void _miWia_DropDownOpening(object sender, EventArgs e)
      {
         if (_wiaAvailable && _wiaSourceSelected && !_wiaAcquiring)
         {
            _miWiaAcquire.Enabled = true;
            _miWiaOptions.Enabled = true;
            _miWiaCapabilities.Enabled = true;
            _miWiaProperties.Enabled = true;
         }
         else
         {
            if (_wiaAcquiring || _mySettings._settings.wiaVersion == 0)
            {
               _miWiaSelectSource.Enabled = false;
            }
            else
            {
               _miWiaSelectSource.Enabled = true;
            }

            _miWiaOptions.Enabled = false;
            _miWiaCapabilities.Enabled = false;
            _miWiaProperties.Enabled = false;
            _miWiaAcquire.Enabled = false;
         }
      }

      private void _miWiaVersion_Click(object sender, EventArgs e)
      {
         bool bTopMost = logWindow.TopMost;
         logWindow.TopMost = false;
         try
         {
            using (WiaVersionForm WiaVersionDlg = new WiaVersionForm())
            {
               if (WiaVersionDlg.ShowDialog() == DialogResult.OK)
               {
                  _wiaVersion = WiaVersionDlg._selectedWiaVersion;
                  _mySettings._settings.wiaVersion = (int)_wiaVersion;
                  _mySettings.Save();
                  InitializeWia();
               }
            }
         }
         catch { }
         logWindow.TopMost = bTopMost;
      }

      void _wiaSession_AcquireEvent(object sender, WiaAcquireEventArgs e)
      {
         string strInfoMsg;

         // Update the progress bar with the received percent value;
         if (_progressDlg.Visible)
         {
            // Show the user some information about the file we are acquiring 
            // to (if the user chooses file transfer).

            if ((e.Flags & WiaAcquiredPageFlags.StartOfPage) == WiaAcquiredPageFlags.StartOfPage)
            {
               if (_wiatransferMode == WiaTransferMode.File)
               {
                  strInfoMsg = string.Format("Transferring to file:\n\n{0}", e.FileName);
                  _progressDlg.InformationString = strInfoMsg;
               }
            }

            if (((e.Flags & WiaAcquiredPageFlags.StartOfPage) == WiaAcquiredPageFlags.StartOfPage) &&
                ((e.Flags & WiaAcquiredPageFlags.EndOfPage) != WiaAcquiredPageFlags.EndOfPage))
            {
               _progressDlg.Percent = 0;
            }
            else
            {
               _progressDlg.Percent = (Int32)e.Percent;
            }

            Application.DoEvents();

            if (_progressDlg.Abort)
               e.Cancel = true;
         }

         if (_wiatransferMode != WiaTransferMode.File)
         {
            if (e.Image != null)
            {
               Page page = new Page();
               page.DeleteOnDispose = false;
               string strTemp = Path.GetTempFileName();
               _codec.Save(e.Image, strTemp, Leadtools.RasterImageFormat.Tif, 0);
               page.FilePath = strTemp;
               wiaImageCollection.Images.Add(new ListImageBox.ImageItem(_codec.Load(strTemp), wiaImageCollection, page));
               e.Image.Dispose();
               Application.DoEvents();
            }
         }
      }

      private void _miWiaOptions_DropDownOpening(object sender, EventArgs e)
      {
         if (_wiaAvailable && _wiaSourceSelected && !_wiaAcquiring)
         {
            _miOptionsAcquireOptions.Enabled = true;
            _miOptionsShowUI.Enabled = true;
         }
         else
         {
            _miOptionsAcquireOptions.Enabled = false;
            _miOptionsShowUI.Enabled = false;
         }

         _miOptionsShowUI.Checked = _showUserInterface;
      }

      private void _miWiaCapabilities_DropDownOpening(object sender, EventArgs e)
      {
         if (_wiaAvailable && _wiaSourceSelected && !_wiaAcquiring)
         {
            _miCapabilitiesShowCapabilities.Enabled = true;
            _miCapabilitiesShowFormats.Enabled = true;
         }
         else
         {
            _miCapabilitiesShowCapabilities.Enabled = false;
            _miCapabilitiesShowFormats.Enabled = false;
         }
      }

      private void _miWiaProperties_DropDownOpening(object sender, EventArgs e)
      {
         if (_wiaAvailable && _wiaSourceSelected && !_wiaAcquiring)
         {
            _miPropertiesWiaProperties.Enabled = true;
            if (_wiaerrorList.Count > 0)
               _miPropertiesShowErrors.Enabled = true;
            else
               _miPropertiesShowErrors.Enabled = false;
         }
         else
         {
            _miPropertiesWiaProperties.Enabled = false;
            _miPropertiesShowErrors.Enabled = false;
         }
      }

      private void _miWiaSelectSource_Click(object sender, System.EventArgs e)
      {
         bool bTopMost = logWindow.TopMost;
         logWindow.TopMost = false;
         try
         {
#if LEADTOOLS_V19_OR_LATER
            DialogResult res = _wiaSession.SelectDeviceDlg(this.Handle, WiaDeviceType.Default, WiaSelectSourceFlags.NoDefault);
#else
            DialogResult res = _wiaSession.SelectDeviceDlg(this, WiaDeviceType.Default, WiaSelectSourceFlags.NoDefault);
#endif // #if LEADTOOLS_V19_OR_LATER
            if (res == DialogResult.OK)
            {
               _mySettings._settings.wiaSelectedDevice = _wiaSession.GetSelectedDevice();
               _wiaSourceSelected = true;
               _mySettings.Save();
            }
         }
         catch (Exception ex)
         {
            _wiaSourceSelected = false;
            Messager.ShowError(this, ex);
         }
         logWindow.TopMost = bTopMost;
      }

      private void _miWiaAcquire_Click(object sender, System.EventArgs e)
      {
         bool bTopMost = logWindow.TopMost;
         logWindow.TopMost = false;
         WiaAcquireFlags flags;
         bool showProgress = true;

         _progressDlg = new ProgressForm("Transferring...", "", 100);

         _wiaAcquiring = true;

         flags = WiaAcquireFlags.UseCommonUI;
         if (_showUserInterface)
         {
            flags |= WiaAcquireFlags.ShowUserInterface;
         }
         else
         {
            // Check if the selected device is scanner and that it has multiple sources (Feeder & Flatbed)
            // then show the select source dialog box.
            if (SelectAcquireSource() != DialogResult.OK)
            {
               _wiaAcquiring = false;
               logWindow.TopMost = bTopMost;
               return;
            }
         }

         if (_showUserInterface)
         {
            if (_wiaVersion == WiaVersion.Version1)
               showProgress = true;
            else
               showProgress = false;
         }
         else
         {
            showProgress = true;
         }

         if (showProgress)
         {
            // Show the progress dialog.
            _progressDlg.Show(this);
         }

         try
         {
            _wiaSession.AcquireOptions = _wiaAcquireOptions;

            if (_wiaProperties.DataTransfer.TransferMode == WiaTransferMode.None) // GetProperties() method not called yet.
            {
               _wiatransferMode = WiaTransferMode.Memory;
            }
            else
            {
               _wiatransferMode = _wiaProperties.DataTransfer.TransferMode;
            }

            // Disable the minimize and maximize buttons.
            this.MinimizeBox = false;
            this.MaximizeBox = false;

            wiaImageCollection = new ListImageBox.ImageCollection("WIA Scanned");

#if LEADTOOLS_V19_OR_LATER
            _wiaSession.Acquire(this.Handle, _sourceItem, flags);
#else
            _wiaSession.Acquire(this, _sourceItem, flags);
#endif // #if LEADTOOLS_V19_OR_LATER

            // Enable back the minimize and maximize buttons.
            this.MinimizeBox = true;
            this.MaximizeBox = true;

            if (_progressDlg.Visible)
            {
               if (!_progressDlg.Abort)
                  _progressDlg.Dispose();
            }

            if (_enumeratedItemsList.Count > 0)
            {
               _enumeratedItemsList.Clear();
            }
            if (_sourceItem != null)
            {
               _sourceItem = null;
            }

            if (_wiaSession.FilesCount > 0)  // This property indicates how many files where saved when the transfer mode is File mode.
            {
               string strMsg = "Acquired page(s) were saved to:\n\n";
               if (_wiaSession.FilesPaths.Count > 0)
               {
                  for (int i = 0; i < _wiaSession.FilesPaths.Count; i++)
                  {
                     string strTemp = string.Format("{0}\n", _wiaSession.FilesPaths[i]);
                     strMsg += strTemp;
                  }
                  MessageBox.Show(this, strMsg, "File Transfer", MessageBoxButtons.OK, MessageBoxIcon.Information);
               }
            }

            _wiaAcquiring = false;
         }
         catch (Exception ex)
         {
            // Enable back the minimize and maximize buttons.
            this.MinimizeBox = true;
            this.MaximizeBox = true;

            _wiaAcquiring = false;
            if (_progressDlg.Visible)
            {
               if (!_progressDlg.Abort)
                  _progressDlg.Dispose();
            }

            Messager.ShowError(this, ex);
         }
         if (wiaImageCollection.Images.Count > 0)
            _lstBoxPages.AddImageCollection(wiaImageCollection);
         logWindow.TopMost = bTopMost;
      }

      private DialogResult SelectAcquireSource()
      {
         if (_wiaSession.SelectedDeviceType == WiaDeviceType.Scanner)
         {
            Object rootItem = _wiaSession.GetRootItem(null);
            if(_wiaVersion == WiaVersion.Version1)
            {
               int longValue = _wiaSession.GetPropertyLong(rootItem, null, WiaPropertyId.ScannerDeviceDocumentHandlingCapabilities);

               if (((longValue & (int)WiaDocumentHandlingCapabilitiesFlags.Feeder) == (int)WiaDocumentHandlingCapabilitiesFlags.Feeder) &&
                   ((longValue & (int)WiaDocumentHandlingCapabilitiesFlags.Flatbed) == (int)WiaDocumentHandlingCapabilitiesFlags.Flatbed)) // scanner with multiple sources.
               {
                  using (AcquireSourceForm AcquireSourceDlg = new AcquireSourceForm())
                  {
                     if (AcquireSourceDlg.ShowDialog() != DialogResult.OK)
                     {
                        return DialogResult.Cancel;
                     }
                  }

                  if (_acquireFromFeeder)
                  {
                     longValue = (int)WiaScanningModeFlags.Feeder;
                  }
                  else
                  {
                     longValue = (int)WiaScanningModeFlags.Flatbed;
                  }

                  _wiaSession.SetPropertyLong(rootItem, null, WiaPropertyId.ScannerDeviceDocumentHandlingSelect, longValue);
               }
            }
            else
            {
               // Enable the enumerate items event.
               _wiaSession.EnumItemsEvent += new EventHandler<WiaEnumItemsEventArgs>(_wiaSession_EnumItemsEvent);

               _wiaSession.EnumChildItems(rootItem);

               // Disable the enumerate items event.
               _wiaSession.EnumItemsEvent -= new EventHandler<WiaEnumItemsEventArgs>(_wiaSession_EnumItemsEvent);

               if (_enumeratedItemsList.Count > 1)  // scanner with multiple sources.
               {
                  using (AcquireSourceForm AcquireSourceDlg = new AcquireSourceForm())
                  {
                     if (AcquireSourceDlg.ShowDialog() != DialogResult.OK)
                     {
                        _enumeratedItemsList.Clear();
                        return DialogResult.Cancel;
                     }
                  }

                  if (_acquireFromFeeder)
                  {
                     foreach (object item in _enumeratedItemsList)
                     {
                        Guid guidCategory = FrmMain._wiaSession.GetPropertyGuid(item, null, WiaPropertyId.ItemCategory);
                        Guid guidValue = WiaSession.GetCategoryGuid(WiaCategories.Feeder);
                        if (guidValue == guidCategory)
                        {
                           _sourceItem = item;
                           break;
                        }
                        guidValue = WiaSession.GetCategoryGuid(WiaCategories.FeederBack);
                        if (guidValue == guidCategory)
                        {
                           _sourceItem = item;
                           break;
                        }
                        guidValue = WiaSession.GetCategoryGuid(WiaCategories.FeederFront);
                        if (guidValue == guidCategory)
                        {
                           _sourceItem = item;
                           break;
                        }
                     }
                  }
                  else
                  {
                     foreach (object item in _enumeratedItemsList)
                     {
                        Guid guidValue = FrmMain._wiaSession.GetPropertyGuid(item, null, WiaPropertyId.ItemCategory);
                        Guid guidCategory = WiaSession.GetCategoryGuid(WiaCategories.Flatbed);
                        if (guidValue == guidCategory)
                        {
                           _sourceItem = item;
                           break;
                        }
                     }
                  }

                  if (_enumeratedItemsList.Count > 0)
                     _enumeratedItemsList.Clear();
               }
            }
         }

         return DialogResult.OK;
      }


      private void FinilizeWia()
      {
          if (_wiaSession != null)
              _wiaSession.Shutdown();
      }

      void _wiaSession_EnumItemsEvent(object sender, WiaEnumItemsEventArgs e)
      {
         _enumeratedItemsList.Add(e.Item);
      }

      private void _miOptionsAcquireOptions_Click(object sender, EventArgs e)
      {
         bool bTopMost = logWindow.TopMost;
         logWindow.TopMost = false;
         using (AcquireOptionsForm AcquireOptionsDlg = new AcquireOptionsForm())
         {
            AcquireOptionsDlg.ShowDialog(this);
         }
         logWindow.TopMost = bTopMost;
      }

      private void _miOptionsShowUI_Click(object sender, EventArgs e)
      {
         _showUserInterface = !_showUserInterface;
      }

      private void _miCapabilitiesShowCapabilities_Click(object sender, EventArgs e)
      {
         bool bTopMost = logWindow.TopMost;
         logWindow.TopMost = false;
         _forCapabilities = true;
         using (WiaDeviceItemsForm DeviceItemsDlg = new WiaDeviceItemsForm())
         {
            if (DeviceItemsDlg.ShowDialog(this) == DialogResult.OK)
            {
               using (SupportedCapabilitiesForm SupportedCapsDlg = new SupportedCapabilitiesForm())
               {
                  SupportedCapsDlg.ShowDialog(this);
               }
            }
         }
         logWindow.TopMost = bTopMost;
      }

      private void _miCapabilitiesShowFormats_Click(object sender, EventArgs e)
      {
         bool bTopMost = logWindow.TopMost;
         logWindow.TopMost = false;
         _forCapabilities = true;
         using (WiaDeviceItemsForm DeviceItemsDlg = new WiaDeviceItemsForm())
         {
            if (DeviceItemsDlg.ShowDialog(this) == DialogResult.OK)
            {
               using (SupportedFormatsForm SupportedFormatsDlg = new SupportedFormatsForm())
               {
                  SupportedFormatsDlg.ShowDialog(this);
               }
            }
         }
         logWindow.TopMost = bTopMost;
      }

      private void _miPropertiesWiaProperties_Click(object sender, EventArgs e)
      {
         bool bTopMost = logWindow.TopMost;
         logWindow.TopMost = false;
         _forCapabilities = false;
         using (WiaDeviceItemsForm DeviceItemsDlg = new WiaDeviceItemsForm())
         {
            if (DeviceItemsDlg.ShowDialog(this) == DialogResult.OK)
            {
               using (WiaPropertiesForm PropertiesDlg = new WiaPropertiesForm())
               {
                  if (PropertiesDlg.ShowDialog(this) == DialogResult.OK)
                  {
                     if (_wiaerrorList.Count > 0)
                     {
                        using (WiaPropertiesErrorsForm ErrorsDlg = new WiaPropertiesErrorsForm())
                        {
                           ErrorsDlg.ShowDialog(this);
                        }
                     }
                  }
               }
            }
         }
         logWindow.TopMost = bTopMost;
      }

      private void _miPropertiesShowErrors_Click(object sender, EventArgs e)
      {
         bool bTopMost = logWindow.TopMost;
         logWindow.TopMost = false;
         using (WiaPropertiesErrorsForm ErrorsDlg = new WiaPropertiesErrorsForm())
         {
            ErrorsDlg.ShowDialog(this);
         }
         logWindow.TopMost = bTopMost;
      }

   }
}
