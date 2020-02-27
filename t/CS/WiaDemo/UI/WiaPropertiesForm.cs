// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Leadtools.Wia;
using Leadtools.Demos;

namespace WiaDemo
{
   public partial class WiaPropertiesForm : Form
   {
      Int32 _duplexFlags;

      public WiaPropertiesForm()
      {
         InitializeComponent();
      }

      private void WiaPropertiesForm_Load(object sender, EventArgs e)
      {
         MainForm._wiaProperties = WiaProperties.Empty;

         // if the WIA 2.0 version is selected and the ShowUserInterface option is on
         // then in this case WIA 2.0 will only work as file transfer, so we need to set the 
         // transfer mode to file transfer
         if (MainForm._wiaVersion == WiaVersion.Version2 && MainForm._showUserInterface)
         {
#if !LEADTOOLS_V17_OR_LATER
            MainForm._wiaSession.LongValue = (int)WiaTransferMode.File;
            MainForm._wiaSession.SetPropertyLong(MainForm._selectedWiaItem, 
                                                 null, WiaPropertyId.ItemTymed);
#else
            MainForm._wiaSession.SetPropertyLong(MainForm._selectedWiaItem,
                                                 null, WiaPropertyId.ItemTymed, (int)WiaTransferMode.File);
#endif //#if !LEADTOOLS_V17_OR_LATER
         }

         if(MainForm._wiaSession.SelectedDeviceType == WiaDeviceType.Scanner)
         {
            // First, we need to check for the current device intent, if it's None then we need to 
            // set it to Color as the default value.
#if !LEADTOOLS_V17_OR_LATER
            MainForm._wiaSession.GetPropertyLong(MainForm._selectedWiaItem,
                                                 null,
                                                 WiaPropertyId.ScannerItemCurIntent);

            if (MainForm._wiaSession.LongValue == (int)WiaImageType.None)
            {
               // Set the device intent to color intent as the default value.
               MainForm._wiaSession.LongValue = (int)WiaImageType.Color;
               MainForm._wiaSession.SetPropertyLong(MainForm._selectedWiaItem,
                                                    null,
                                                    WiaPropertyId.ScannerItemCurIntent);
            }
#else
            int longValue = MainForm._wiaSession.GetPropertyLong(MainForm._selectedWiaItem,
                                                 null,
                                                 WiaPropertyId.ScannerItemCurIntent);

            if (longValue == (int)WiaImageType.None)
            {
               // Set the device intent to color intent as the default value.
               MainForm._wiaSession.SetPropertyLong(MainForm._selectedWiaItem,
                                                    null,
                                                    WiaPropertyId.ScannerItemCurIntent, (int)WiaImageType.Color);
            }
#endif //#if !LEADTOOLS_V17_OR_LATER
         }

         try
         {
#if !LEADTOOLS_V17_OR_LATER
            MainForm._wiaSession.GetProperties(MainForm._selectedWiaItem);
            MainForm._wiaProperties = MainForm._wiaSession.Properties;
#else
            MainForm._wiaProperties = MainForm._wiaSession.GetProperties(MainForm._selectedWiaItem);
#endif //#if !LEADTOOLS_V17_OR_LATER
         }
         catch(Exception ex)
         {
            Messager.ShowError(this, ex);
            DialogResult = DialogResult.No;
         }

         MainForm._capabilitiesList.Clear();

         // Enable the enumerate capabilities event.
         MainForm._wiaSession.EnumCapabilitiesEvent += new EventHandler<WiaEnumCapabilitiesEventArgs>(_wiaSession_EnumCapabilitiesEvent);

         // Enumerate the WIA root item capabilities in order to get the device capabilities (Duplex modes and Pages count).
         object rootItem = null;
#if !LEADTOOLS_V17_OR_LATER
         MainForm._wiaSession.GetRootItem(null);
         rootItem = MainForm._wiaSession.RootItem;
#else
         rootItem = MainForm._wiaSession.GetRootItem(null);
#endif //#if !LEADTOOLS_V17_OR_LATER

         MainForm._wiaSession.EnumCapabilities(rootItem, WiaEnumCapabilitiesFlags.None);

         FillDlgControlsWithEnumeratedCapsValues();

         MainForm._capabilitiesList.Clear();

         // Enumerate the capabilities for the item the user selected from within the items dialog.
         MainForm._wiaSession.EnumCapabilities(MainForm._selectedWiaItem, WiaEnumCapabilitiesFlags.None);

         FillDlgControlsWithEnumeratedCapsValues();

         // Disable the enumerate capabilities event.
         MainForm._wiaSession.EnumCapabilitiesEvent -= new EventHandler<WiaEnumCapabilitiesEventArgs>(_wiaSession_EnumCapabilitiesEvent);

         if (GetWiaProperties() == false)
         {
            DialogResult = DialogResult.No;
         }
      }

      void _wiaSession_EnumCapabilitiesEvent(object sender, WiaEnumCapabilitiesEventArgs e)
      {
         if(e.CapabilitiesCount > 0)
         {
            MainForm._capabilitiesList.Add(e.Capability);
         }
      }

      private void FillTransferFormatsList()
      {
         // Enable the enumerate formats event.
         MainForm._wiaSession.EnumFormatsEvent += new EventHandler<WiaEnumFormatsEventArgs>(_wiaSession_EnumFormatsEvent);

         MainForm._formatsList.Clear();

         // Enumerate the supported WIA formats and add them to the formats combo box.
         MainForm._wiaSession.EnumFormats(MainForm._selectedWiaItem, 
                                          WiaEnumFormatsFlags.None);

         // Disable the enumerate formats event.
         MainForm._wiaSession.EnumFormatsEvent -= new EventHandler<WiaEnumFormatsEventArgs>(_wiaSession_EnumFormatsEvent);

         FillFormatsListWithEnumeratedFormats();

         int longValue = 0;
#if !LEADTOOLS_V17_OR_LATER
         // Get the currently selected transfer mode and select the related transfer mode radio button.
         MainForm._wiaSession.GetPropertyLong(MainForm._selectedWiaItem, 
                                              null, 
                                              WiaPropertyId.ItemTymed);
         longValue = MainForm._wiaSession.LongValue;
#else
         // Get the currently selected transfer mode and select the related transfer mode radio button.
         longValue = MainForm._wiaSession.GetPropertyLong(MainForm._selectedWiaItem,
                                              null,
                                              WiaPropertyId.ItemTymed);
#endif //#if !LEADTOOLS_V17_OR_LATER

         switch (longValue)
         {
         case (int)WiaTransferMode.Memory:
            _rdMemoryMode.Checked = true;
            break;

         case (int)WiaTransferMode.File:
            _rdFileMode.Checked = true;
            break;
         }

         if (_cmbFormat.Items.Count > 0)
         {
            Guid guidValue = Guid.Empty;
#if !LEADTOOLS_V17_OR_LATER
            // Get the currently selected format and select the relevant format from the formats combo.
            MainForm._wiaSession.GetPropertyGuid(MainForm._selectedWiaItem,
                                                 null,
                                                 WiaPropertyId.ItemFormat);
            guidValue = MainForm._wiaSession.GuidValue;
#else
            // Get the currently selected format and select the relevant format from the formats combo.
            guidValue = MainForm._wiaSession.GetPropertyGuid(MainForm._selectedWiaItem,
                                                 null,
                                                 WiaPropertyId.ItemFormat);
#endif //#if !LEADTOOLS_V17_OR_LATER

            HelperFunctions.SelectFormatFromCombo(_cmbFormat, guidValue);
         }
      }

      void _wiaSession_EnumFormatsEvent(object sender, WiaEnumFormatsEventArgs e)
      {
         if(e.FormatsCount > 0)
         {
            MyFormat myFormat = MyFormat.Empty;
#if !LEADTOOLS_V17_OR_LATER
            WiaSession.GetFormatGuid(e.Format);
            myFormat.Format = WiaSession.FormatGuid;
#else
            myFormat.Format = WiaSession.GetFormatGuid(e.Format);
#endif //#if !LEADTOOLS_V17_OR_LATER
            myFormat.FormatCLSID = myFormat.Format.ToString();
            myFormat.FormatName = e.Format.ToString();
            myFormat.TransferMode = e.TransferMode;
            myFormat.TransferModeString = e.TransferMode.ToString();

            MainForm._formatsList.Add(myFormat);
         }
      }

      private void UpdateWiaPropertiesDlgControls()
      {
         bool enableDuplexRelatedCtrls = false;

         if (_numHorizontalResolution.Text.Length <= 0   || _numVerticalResolution.Value.ToString().Length <= 0   ||
             _numMaxPagesCount.Text.Length <= 0          || _numHorizontalScaling.Text.Length <= 0                ||
             _numVerticalScaling.Text.Length <= 0        || _numXPos.Text.Length <= 0                             ||
             _numYPos.Text.Length <= 0                   || _numWidth.Text.Length <= 0                            ||
             _numHeight.Text.Length <= 0                 || _numBrightness.Text.Length <= 0                       ||
             _numContrast.Text.Length <= 0)
         {
            _btnOk.Enabled = false;
         }
         else
         {
            _btnOk.Enabled = true;
         }

         // Disable the 'Max Pages Count' field if Flatbed is selected.
         if( ((MainForm._wiaProperties.ScanningMode & WiaScanningModeFlags.Flatbed) == WiaScanningModeFlags.Flatbed) || 
             (MainForm._wiaProperties.ScanningMode == WiaScanningModeFlags.None) )
         {
            _numMaxPagesCount.Enabled = false;
         }
         else
         {
            _numMaxPagesCount.Enabled = true;
         }

         if (_cbDuplex.Checked)
            enableDuplexRelatedCtrls = true;

         if (MainForm._wiaSession.SelectedDeviceType == WiaDeviceType.Scanner)
         {
            if (MainForm._wiaVersion == WiaVersion.Version1)
            {
               // Enable the duplex controls
               if ((_duplexFlags & (UInt32)WiaScanningModeFlags.Duplex) == (UInt32)WiaScanningModeFlags.Duplex)
               {
                  if (!enableDuplexRelatedCtrls)
                  {
                     if ((_duplexFlags & (UInt32)WiaScanningModeFlags.FrontOnly) == (UInt32)WiaScanningModeFlags.FrontOnly)
                        _cbFrontOnly.Checked = false;
                  }
               }
            }
            else
            {
               _cbAutoAdvance.Text = DemosGlobalization.GetResxString(GetType(), "Resx_AdvancedDuplex");

               // Disable the Image Data Type combo box while working on WIA 2.0 (mentioned limitation in the 
               // documentation as result for Microsoft's bug - since we have found that if you set both the Image
               // type (ScannerItemCurIntent) and Image data type (ItemDatatype) then the image data type will be ignored).
               // NOTE: If you want to use the nImageDataType member of the properties structure then you have 
               // to set the nImageType member to "None".
               _lblImageDataType.Enabled = false;
               _cmbImageDataType.Enabled = false;
            }

            if ((_duplexFlags & (UInt32)WiaScanningModeFlags.FrontFirst) == (UInt32)WiaScanningModeFlags.FrontFirst)
               _cbFrontFirst.Enabled = enableDuplexRelatedCtrls;
            if ((_duplexFlags & (UInt32)WiaScanningModeFlags.BackFirst) == (UInt32)WiaScanningModeFlags.BackFirst)
               _cbBackFirst.Enabled = enableDuplexRelatedCtrls;
            if ((_duplexFlags & (UInt32)WiaScanningModeFlags.FrontOnly) == (UInt32)WiaScanningModeFlags.FrontOnly)
               _cbFrontOnly.Enabled = enableDuplexRelatedCtrls;
            if ((_duplexFlags & (UInt32)WiaScanningModeFlags.BackOnly) == (UInt32)WiaScanningModeFlags.BackOnly)
               _cbBackOnly.Enabled = enableDuplexRelatedCtrls;

            if (!enableDuplexRelatedCtrls)
            {
               _cbFrontFirst.Checked = false;
               _cbBackFirst.Checked = false;
               _cbBackOnly.Checked = false;
            }
         }
      }

      private bool GetWiaProperties()
      {
         try
         {
#if !LEADTOOLS_V17_OR_LATER
            MainForm._wiaSession.GetProperties(MainForm._selectedWiaItem);
            MainForm._wiaProperties = MainForm._wiaSession.Properties;
#else
            MainForm._wiaProperties = MainForm._wiaSession.GetProperties(MainForm._selectedWiaItem);
#endif //#if !LEADTOOLS_V17_OR_LATER
         }
         catch(Exception ex)
         {
            Messager.ShowError(this, ex);
            DialogResult = DialogResult.No;
         }

         // Select the paper source and duplex mode values.
         if ((MainForm._wiaProperties.ScanningMode & WiaScanningModeFlags.Feeder) == WiaScanningModeFlags.Feeder)
         {
            _cbFeeder.Checked = true;
         }
         if ((MainForm._wiaProperties.ScanningMode & WiaScanningModeFlags.Flatbed) == WiaScanningModeFlags.Flatbed)
         {
            _cbFlatbed.Checked = true;
         }
         if ((MainForm._wiaProperties.ScanningMode & WiaScanningModeFlags.Duplex) == WiaScanningModeFlags.Duplex)
         {
            _cbDuplex.Checked = true;
         }
         if ((MainForm._wiaProperties.ScanningMode & WiaScanningModeFlags.FrontFirst) == WiaScanningModeFlags.FrontFirst)
         {
            _cbFrontFirst.Checked = true;
         }
         if ((MainForm._wiaProperties.ScanningMode & WiaScanningModeFlags.BackFirst) == WiaScanningModeFlags.BackFirst)
         {
            _cbBackFirst.Checked = true;
         }
         if ((MainForm._wiaProperties.ScanningMode & WiaScanningModeFlags.FrontOnly) == WiaScanningModeFlags.FrontOnly)
         {
            _cbFrontOnly.Checked = true;
         }
         if ((MainForm._wiaProperties.ScanningMode & WiaScanningModeFlags.BackOnly) == WiaScanningModeFlags.BackOnly)
         {
            _cbBackOnly.Checked = true;
         }
         if ((MainForm._wiaProperties.ScanningMode & WiaScanningModeFlags.NextPage) == WiaScanningModeFlags.NextPage)
         {
            _cbNextPage.Checked = true;
         }
         if ((MainForm._wiaProperties.ScanningMode & WiaScanningModeFlags.Prefeed) == WiaScanningModeFlags.Prefeed)
         {
            _cbPrefeed.Checked = true;
         }
         if ((MainForm._wiaProperties.ScanningMode & WiaScanningModeFlags.AutoAdvance) == WiaScanningModeFlags.AutoAdvance ||
             (MainForm._wiaProperties.ScanningMode & WiaScanningModeFlags.AdvancedDuplex) == WiaScanningModeFlags.AdvancedDuplex)
         {
            _cbAutoAdvance.Checked = true;
         }

         if(_cmbOrientation.Items.Count > 0)
         {
            HelperFunctions.SelectItemFromCombo(_cmbOrientation, (int)MainForm._wiaProperties.Orientation);
         }

         // Check the Image Type check boxes according to the retrieved Image type flags.
         if( MainForm._wiaProperties.ImageType == WiaImageType.Color )
         {
            _cbColored.Checked = true;
            _cbGrayscale.Checked = false;
            _cbText.Checked = false;
         }
         else if ( MainForm._wiaProperties.ImageType == WiaImageType.Grayscale )
         {
            _cbGrayscale.Checked = true;
            _cbColored.Checked = false;
            _cbText.Checked = false;
         }
         else if( MainForm._wiaProperties.ImageType == WiaImageType.Text )
         {
            _cbText.Checked = true;
            _cbColored.Checked = false;
            _cbGrayscale.Checked = false;
         }
         else
         {
            _cbColored.Checked = true;
            _cbGrayscale.Checked = false;
            _cbText.Checked = false;
         }

         // Set the Max pages count value according to the retrieved one, unless the selected source is Flatbed, 
         // then set the default value to "1".
         if( (MainForm._wiaProperties.ScanningMode & WiaScanningModeFlags.Flatbed) == WiaScanningModeFlags.Flatbed || 
             (MainForm._wiaProperties.ScanningMode == WiaScanningModeFlags.None) )
         {
            _numMaxPagesCount.Text = "1";
         }
         else
         {
            _numMaxPagesCount.Text = MainForm._wiaProperties.MaximumNumberOfPages.ToString();
         }

         // Select the Bits per pixel value from the combo box according to the retrieved one.
         if(_cmbBitsPerPixel.Items.Count > 1)
         {
            HelperFunctions.SelectItemFromCombo(_cmbBitsPerPixel, MainForm._wiaProperties.ImageResolution.BitsPerPixel);
         }
         else
         {
            _cmbBitsPerPixel.Items.Clear();
            _cmbBitsPerPixel.Items.Add(MainForm._wiaProperties.ImageResolution.BitsPerPixel.ToString());
            _cmbBitsPerPixel.SelectedIndex = 0;
         }

         // Select the Rotation Angle value from the combo box according to the retrieved one.
         if(_cmbRotationAngle.Items.Count > 0)
         {
            HelperFunctions.SelectItemFromCombo(_cmbRotationAngle, MainForm._wiaProperties.ImageResolution.RotationAngle);
         }

         // Set the Horizontal Resolution value according to the retrieved one.
         if (_numHorizontalResolution.Visible == true)
         {
            _numHorizontalResolution.Value = MainForm._wiaProperties.ImageResolution.HorizontalResolution;
         }
         else
         {
            if (_cmbHorizontalResolution.Items.Count > 0)
            {
               HelperFunctions.SelectItemFromCombo(_cmbHorizontalResolution, MainForm._wiaProperties.ImageResolution.HorizontalResolution);
            }
         }

         // Set the Vertical Resolution value according to the retrieved one.
         if (_numVerticalResolution.Visible == true)
         {
            _numVerticalResolution.Value = MainForm._wiaProperties.ImageResolution.VerticalResolution;
         }
         else
         {
            if (_cmbVerticalResolution.Items.Count > 0)
            {
               HelperFunctions.SelectItemFromCombo(_cmbVerticalResolution, MainForm._wiaProperties.ImageResolution.VerticalResolution);
            }
         }

         // Set the Horizontal Scaling value according to the retrieved one.
         _numHorizontalScaling.Value = MainForm._wiaProperties.ImageResolution.XScaling;

         // Set the Vertical Scaling value according to the retrieved one.
         _numVerticalScaling.Value = MainForm._wiaProperties.ImageResolution.YScaling;

         // Set the XPos value according to the retrieved one.
         _numXPos.Value = MainForm._wiaProperties.ImageResolution.XPos;

         // Set the YPos value according to the retrieved one.
         _numYPos.Value = MainForm._wiaProperties.ImageResolution.YPos;

         // Set the Width value according to the retrieved one.
         if (MainForm._wiaProperties.ImageResolution.Width > _numWidth.Maximum)
            _numWidth.Maximum = MainForm._wiaProperties.ImageResolution.Width;
         _numWidth.Value = MainForm._wiaProperties.ImageResolution.Width;

         // Set the Height value according to the retrieved one.
         if (MainForm._wiaProperties.ImageResolution.Height > _numHeight.Maximum)
            _numHeight.Maximum = MainForm._wiaProperties.ImageResolution.Height;
         _numHeight.Value = MainForm._wiaProperties.ImageResolution.Height;

         // Select the Transfer Format value from the combo box according to the retrieved one.
         if(_cmbFormat.Items.Count > 0)
         {
#if !LEADTOOLS_V17_OR_LATER
            WiaSession.GetFormatGuid(MainForm._wiaProperties.DataTransfer.Format);
            System.Guid formatGuid = WiaSession.FormatGuid;
#else
            System.Guid formatGuid = WiaSession.GetFormatGuid(MainForm._wiaProperties.DataTransfer.Format);
#endif //#if !LEADTOOLS_V17_OR_LATER
            HelperFunctions.SelectFormatFromCombo(_cmbFormat, formatGuid);
         }

         // Select the Compression value from the combo box according to the retrieved one.
         if(_cmbCompression.Items.Count > 0)
         {
            HelperFunctions.SelectItemFromCombo(_cmbCompression, (int)MainForm._wiaProperties.DataTransfer.Compression);
         }

         // Select the Image Data Type value from the combo box according to the retrieved one.
         if(_cmbImageDataType.Items.Count > 0)
         {
            HelperFunctions.SelectItemFromCombo(_cmbImageDataType, (int)MainForm._wiaProperties.DataTransfer.ImageDataType);
         }

         // Disable the memory mode if the WIA version is 2.0 while the Show user interface options is ON
         if(MainForm._wiaVersion == WiaVersion.Version2 && MainForm._showUserInterface)
         {
            _rdFileMode.Enabled = true;
            _rdMemoryMode.Enabled = false;
            _rdFileMode.Checked = true;
         }
         else
         {
            _rdFileMode.Enabled = true;
            _rdMemoryMode.Enabled = true;
         }

         // Set the Brightness value according to the retrieved one.
         _numBrightness.Value = MainForm._wiaProperties.ImageEffects.Brightness;

         // Set the Contrast value according to the retrieved one.
         _numContrast.Value = MainForm._wiaProperties.ImageEffects.Contrast;

         UpdateWiaPropertiesDlgControls();

         return true;
      }

      private void SetWiaProperties(object item)
      {
         // Reset the properties structure members first to set the selected flags and values.
         MainForm._wiaProperties = WiaProperties.Empty;

         WiaDataTransferProperties dataTransfer = MainForm._wiaProperties.DataTransfer;
         WiaImageResolutionProperties imageResolution = MainForm._wiaProperties.ImageResolution;
         WiaImageEffectsProperties imageEffects = MainForm._wiaProperties.ImageEffects;

         // Set the user selected Image type (intent).
         if( _cbColored.Checked )
         {
            MainForm._wiaProperties.ImageType = WiaImageType.Color;
         }
         else if( _cbGrayscale.Checked )
         {
            MainForm._wiaProperties.ImageType = WiaImageType.Grayscale;
         }
         else
         {
            MainForm._wiaProperties.ImageType = WiaImageType.Text;
         }

         // Set the user specified Transfer Mode.
         if( _rdMemoryMode.Checked )
         {
            dataTransfer.TransferMode = WiaTransferMode.Memory;
         }
         else
         {
            dataTransfer.TransferMode = WiaTransferMode.File;
         }

         // Set the user specified Transfer Format.
         if(_cmbFormat.Items.Count > 0)
         {
            HelperFunctions.GetSelectedFormatFromCombo(_cmbFormat);
            dataTransfer.Format = HelperFunctions.Format;
         }

         // Set the user specified max pages count.
         MainForm._wiaProperties.MaximumNumberOfPages = Convert.ToInt32(_numMaxPagesCount.Value);

         // Set the user selected paper source and duplex mode.
         if( _cbFeeder.Checked )
         {
            MainForm._wiaProperties.ScanningMode |= WiaScanningModeFlags.Feeder;
         }
         else if( _cbFlatbed.Checked )
         {
            MainForm._wiaProperties.ScanningMode |= WiaScanningModeFlags.Flatbed;
         }
         if( _cbDuplex.Checked )
         {
            MainForm._wiaProperties.ScanningMode |= WiaScanningModeFlags.Duplex;
         }
         if( _cbAutoAdvance.Checked )
         {
            MainForm._wiaProperties.ScanningMode |= WiaScanningModeFlags.AutoAdvance;
         }
         if( _cbFrontFirst.Checked )
         {
            MainForm._wiaProperties.ScanningMode |= WiaScanningModeFlags.FrontFirst;
         }
         if( _cbBackFirst.Checked )
         {
            MainForm._wiaProperties.ScanningMode |= WiaScanningModeFlags.BackFirst;
         }
         if( _cbFrontOnly.Checked )
         {
            MainForm._wiaProperties.ScanningMode |= WiaScanningModeFlags.FrontOnly;
         }
         if( _cbBackOnly.Checked )
         {
            MainForm._wiaProperties.ScanningMode |= WiaScanningModeFlags.BackOnly;
         }
         if( _cbNextPage.Checked )
         {
            MainForm._wiaProperties.ScanningMode |= WiaScanningModeFlags.NextPage;
         }
         if( _cbPrefeed.Checked )
         {
            MainForm._wiaProperties.ScanningMode |= WiaScanningModeFlags.Prefeed;
         }

         // Set the user selected Orientation.
         if(_cmbOrientation.Items.Count > 0)
         {
            MyItemData myItem = (MyItemData)_cmbOrientation.SelectedItem;
            MainForm._wiaProperties.Orientation = (WiaOrientation)myItem.ItemData;
         }

         // Set the user selected BPP.
         if(_cmbBitsPerPixel.Items.Count > 0)
         {
            imageResolution.BitsPerPixel = Convert.ToInt32(_cmbBitsPerPixel.Text);
         }

         // Set the user selected Rotation Angle.
         if(_cmbRotationAngle.Items.Count > 0)
         {
            MyItemData myItem = (MyItemData)_cmbRotationAngle.SelectedItem;
            imageResolution.RotationAngle = myItem.ItemData;
         }

         // Set the user specified Horizontal Resolution.
         if (_numHorizontalResolution.Visible == true)
         {
            imageResolution.HorizontalResolution = Convert.ToInt32(_numHorizontalResolution.Value);
         }
         else
         {
            if (_cmbHorizontalResolution.Items.Count > 0)
            {
               MyItemData myItem = (MyItemData)_cmbHorizontalResolution.SelectedItem;
               imageResolution.HorizontalResolution = myItem.ItemData;
            }
         }

         // Set the user specified Vertical Resolution.
         if (_numHorizontalResolution.Visible == true)
         {
            imageResolution.VerticalResolution = Convert.ToInt32(_numVerticalResolution.Value);
         }
         else
         {
            if (_cmbVerticalResolution.Items.Count > 0)
            {
               MyItemData myItem = (MyItemData)_cmbVerticalResolution.SelectedItem;
               imageResolution.VerticalResolution = myItem.ItemData;
            }
         }

         // Set the user specified Horizontal Scaling.
         imageResolution.XScaling = Convert.ToInt32(_numHorizontalScaling.Value);

         // Set the user specified Vertical Scaling.
         imageResolution.YScaling = Convert.ToInt32(_numVerticalScaling.Value);

         // Set the user specified XPos.
         imageResolution.XPos = Convert.ToInt32(_numXPos.Value);

         // Set the user specified YPos.
         imageResolution.YPos = Convert.ToInt32(_numYPos.Value);

         // Set the user specified Width.
         imageResolution.Width = Convert.ToInt32(_numWidth.Value);

         // Set the user specified Height.
         imageResolution.Height = Convert.ToInt32(_numHeight.Value);

         // Set the user specified Compression.
         if(_cmbCompression.Items.Count > 0)
         {
            MyItemData myItem = (MyItemData)_cmbCompression.SelectedItem;
            dataTransfer.Compression = (WiaCompressionMode)myItem.ItemData;
         }

         // Set the user specified Image Data Type.
         if(_cmbImageDataType.Items.Count > 0)
         {
            MyItemData myItem = (MyItemData)_cmbImageDataType.SelectedItem;
            dataTransfer.ImageDataType = (WiaImageDataType)myItem.ItemData;
         }

         // Set the user specified Brightness.
         imageEffects.Brightness = Convert.ToInt32(_numBrightness.Value);

         // Set the user specified Contrast.
         imageEffects.Contrast = Convert.ToInt32(_numContrast.Value);

         // Clear the previous properties errors
         MainForm._errorList.Clear();

         MainForm._wiaProperties.DataTransfer = dataTransfer;
         MainForm._wiaProperties.ImageResolution = imageResolution;
         MainForm._wiaProperties.ImageEffects = imageEffects;

         // Enable the set properties event.
         MainForm._wiaSession.SetPropertiesEvent += new EventHandler<WiaSetPropertiesEventArgs>(_wiaSession_SetPropertiesEvent);

#if !LEADTOOLS_V17_OR_LATER
         // Set the properties property first before calling the SetProperties function.
         MainForm._wiaSession.Properties = MainForm._wiaProperties;

         MainForm._wiaSession.SetProperties(item);
#else
         // Set the properties property first before calling the SetProperties function.
         MainForm._wiaSession.SetProperties(item, MainForm._wiaProperties);
#endif //#if !LEADTOOLS_V17_OR_LATER

         // Disable the set properties event.
         MainForm._wiaSession.SetPropertiesEvent -= new EventHandler<WiaSetPropertiesEventArgs>(_wiaSession_SetPropertiesEvent);
      }

      void _wiaSession_SetPropertiesEvent(object sender, WiaSetPropertiesEventArgs e)
      {
         if (e.Error <= 0)
         {
            MyPropertiesErrors propsErrors = MyPropertiesErrors.Empty;

            object rootItem = null;
#if !LEADTOOLS_V17_OR_LATER
            rootItem = MainForm._wiaSession.RootItem;

            // Add the Device Name to the errors array.
            MainForm._wiaSession.GetPropertyString(rootItem, null, WiaPropertyId.DeviceInfoDevName);
            propsErrors.DeviceName = MainForm._wiaSession.StringValue;

            // Add the Item Name to the errors array.
            MainForm._wiaSession.GetPropertyString(MainForm._selectedWiaItem, null, WiaPropertyId.ItemName);
            propsErrors.ItemName = MainForm._wiaSession.StringValue;
#else
            rootItem = MainForm._wiaSession.GetRootItem(null);

            // Add the Device Name to the errors array.
            propsErrors.DeviceName = MainForm._wiaSession.GetPropertyString(rootItem, null, WiaPropertyId.DeviceInfoDevName);

            // Add the Item Name to the errors array.
            propsErrors.ItemName = MainForm._wiaSession.GetPropertyString(MainForm._selectedWiaItem, null, WiaPropertyId.ItemName);
#endif //#if !LEADTOOLS_V17_OR_LATER

            // Add the Property Name to the errors array.
            HelperFunctions.FindRelevantPropName(e.PropertyId, e.Value);
            propsErrors.PropertyName = HelperFunctions.PropertyName;

            // Add the Property Value to the errors array.
            HelperFunctions.FindRelevantPropValue(e.PropertyId, e.Value);
            propsErrors.PropertyValue = HelperFunctions.PropertyValueString;

            // Add the Error code to the errors array.
            propsErrors.ErrorCodeString = e.Error.ToString();

            MainForm._errorList.Add(propsErrors);
         }
      }

      private void FillDlgControlsWithEnumeratedCapsValues()
      {
         if(MainForm._capabilitiesList.Count <= 0)
            return;

         // Loop through the enumerated capabilities array and update the dialog controls
         foreach(WiaCapability i in MainForm._capabilitiesList)
         {
            // Check if the property ID is supported by the received device capabilities 
            // then enable related controls.
            switch(i.PropertyId)
            {
            case WiaPropertyId.ScannerItemCurIntent:               // Image type
               if ((i.PropertyAttributes & WiaPropertyAttributesFlags.Write) == WiaPropertyAttributesFlags.Write)
               {
                  _cbColored.Enabled = true;
                  _cbGrayscale.Enabled = true;
                  _cbText.Enabled = true;
               }
               break;

            case WiaPropertyId.ScannerDeviceDocumentHandlingSelect: // Paper source and duplex mode
               if (((i.PropertyAttributes & WiaPropertyAttributesFlags.Flag) == WiaPropertyAttributesFlags.Flag) &&
                   ((i.PropertyAttributes & WiaPropertyAttributesFlags.Write) == WiaPropertyAttributesFlags.Write))
               {
                  _duplexFlags = i.Values.FlagsValues.FlagValues;
                  if( (_duplexFlags & (UInt32)WiaScanningModeFlags.Feeder) == (UInt32)WiaScanningModeFlags.Feeder )
                  {
                     _cbFeeder.Enabled = true;
                  }
                  if( (_duplexFlags & (UInt32)WiaScanningModeFlags.Flatbed) == (UInt32)WiaScanningModeFlags.Flatbed )
                  {
                     _cbFlatbed.Enabled = true;
                  }
                  if( (_duplexFlags & (UInt32)WiaScanningModeFlags.Duplex) == (UInt32)WiaScanningModeFlags.Duplex )
                  {
                     _cbDuplex.Enabled = true;
                  }
                  if( (_duplexFlags & (UInt32)WiaScanningModeFlags.FrontOnly) == (UInt32)WiaScanningModeFlags.FrontOnly )
                  {
                     _cbFrontOnly.Enabled = true;
                  }
                  if( (_duplexFlags & (UInt32)WiaScanningModeFlags.BackOnly) == (UInt32)WiaScanningModeFlags.BackOnly )
                  {
                     _cbBackOnly.Enabled = true;
                  }
                  if( (_duplexFlags & (UInt32)WiaScanningModeFlags.FrontFirst) == (UInt32)WiaScanningModeFlags.FrontFirst )
                  {
                     _cbFrontFirst.Enabled = true;
                  }
                  if( (_duplexFlags & (UInt32)WiaScanningModeFlags.BackFirst) == (UInt32)WiaScanningModeFlags.BackFirst )
                  {
                     _cbBackFirst.Enabled = true;
                  }
                  if( (_duplexFlags & (UInt32)WiaScanningModeFlags.NextPage) == (UInt32)WiaScanningModeFlags.NextPage )
                  {
                     _cbNextPage.Enabled = true;
                  }
                  if( (_duplexFlags & (UInt32)WiaScanningModeFlags.Prefeed) == (UInt32)WiaScanningModeFlags.Prefeed )
                  {
                     _cbPrefeed.Enabled = true;
                  }
                  if( (_duplexFlags & (UInt32)WiaScanningModeFlags.AutoAdvance) == (UInt32)WiaScanningModeFlags.AutoAdvance || 
                      (_duplexFlags & (UInt32)WiaScanningModeFlags.AdvancedDuplex) == (UInt32)WiaScanningModeFlags.AdvancedDuplex)
                  {
                     _cbAutoAdvance.Enabled = true;
                  }
               }
               break;

            case WiaPropertyId.ScannerDevicePages:                    // Max pages count
               if ((i.PropertyAttributes & WiaPropertyAttributesFlags.Write) == WiaPropertyAttributesFlags.Write)
               {
                  _numMaxPagesCount.Enabled = true;
                  _numMaxPagesCount.Minimum = i.Values.RangeValues.MinimumValue;
                  _numMaxPagesCount.Maximum = i.Values.RangeValues.MaximumValue;
                  _numMaxPagesCount.Increment = i.Values.RangeValues.Step;
               }
               break;

            case WiaPropertyId.ScannerDeviceOrientation:              // Orientation
               if ((i.PropertyAttributes & WiaPropertyAttributesFlags.Write) == WiaPropertyAttributesFlags.Write)
               {
                  _cmbOrientation.Enabled = true;
               }

               // Fill the orientation list.
               HelperFunctions.FillComboWithValidValues(_cmbOrientation, i);
               break;

            case WiaPropertyId.ItemDepth:                    // Bits per pixel
               if ((i.PropertyAttributes & WiaPropertyAttributesFlags.Write) == WiaPropertyAttributesFlags.Write)
               {
                  _cmbBitsPerPixel.Enabled = true;
               }

               // Fill the bits per pixel list.
               HelperFunctions.FillComboWithValidValues(_cmbBitsPerPixel, i);
               break;

            case WiaPropertyId.ScannerItemRotation:                 // Rotation
               if ((i.PropertyAttributes & WiaPropertyAttributesFlags.Write) == WiaPropertyAttributesFlags.Write)
               {
                  _cmbRotationAngle.Enabled = true;
               }

               // Fill the rotation angle list.
               HelperFunctions.FillComboWithValidValues(_cmbRotationAngle, i);
               break;

            case WiaPropertyId.ScannerItemXRes:                     // Horizontal Resolution
               if ((i.PropertyAttributes & WiaPropertyAttributesFlags.Write) == WiaPropertyAttributesFlags.Write)
               {
                  _numHorizontalResolution.Enabled = true;
                  if ((i.PropertyAttributes & WiaPropertyAttributesFlags.Range) == WiaPropertyAttributesFlags.Range)
                  {
                     _cmbHorizontalResolution.Visible = false;
                     _numHorizontalResolution.Visible = true;
                     _numHorizontalResolution.Minimum = i.Values.RangeValues.MinimumValue;
                     _numHorizontalResolution.Maximum = i.Values.RangeValues.MaximumValue;
                     _numHorizontalResolution.Increment = i.Values.RangeValues.Step;
                  }
                  else if ((i.PropertyAttributes & WiaPropertyAttributesFlags.List) == WiaPropertyAttributesFlags.List)
                  {
                     _cmbHorizontalResolution.Visible = true;
                     _numHorizontalResolution.Visible = false;

                     HelperFunctions.FillComboWithValidValues(_cmbHorizontalResolution, i);
                  }
               }
               break;

            case WiaPropertyId.ScannerItemYRes:                     // Vertical Resolution
               if ((i.PropertyAttributes & WiaPropertyAttributesFlags.Write) == WiaPropertyAttributesFlags.Write)
               {
                  _numVerticalResolution.Enabled = true;
                  if ((i.PropertyAttributes & WiaPropertyAttributesFlags.Range) == WiaPropertyAttributesFlags.Range)
                  {
                     _cmbVerticalResolution.Visible = false;
                     _numVerticalResolution.Visible = true;
                     _numVerticalResolution.Minimum = i.Values.RangeValues.MinimumValue;
                     _numVerticalResolution.Maximum = i.Values.RangeValues.MaximumValue;
                     _numVerticalResolution.Increment = i.Values.RangeValues.Step;
                  }
                  else if ((i.PropertyAttributes & WiaPropertyAttributesFlags.List) == WiaPropertyAttributesFlags.List)
                  {
                     _cmbVerticalResolution.Visible = true;
                     _numVerticalResolution.Visible = false;

                     HelperFunctions.FillComboWithValidValues(_cmbVerticalResolution, i);
                  }
               }
               break;

            case WiaPropertyId.ScannerItemXScaling:                 // Horizontal Scaling
               if ((i.PropertyAttributes & WiaPropertyAttributesFlags.Write) == WiaPropertyAttributesFlags.Write)
               {
                  _numHorizontalScaling.Enabled = true;
                  _numHorizontalScaling.Minimum = i.Values.RangeValues.MinimumValue;
                  _numHorizontalScaling.Maximum = i.Values.RangeValues.MaximumValue;
                  _numHorizontalScaling.Increment = i.Values.RangeValues.Step;
               }
               break;

            case WiaPropertyId.ScannerItemYScaling:                 // Vertical Scaling
               if ((i.PropertyAttributes & WiaPropertyAttributesFlags.Write) == WiaPropertyAttributesFlags.Write)
               {
                  _numVerticalScaling.Enabled = true;
                  _numVerticalScaling.Minimum = i.Values.RangeValues.MinimumValue;
                  _numVerticalScaling.Maximum = i.Values.RangeValues.MaximumValue;
                  _numVerticalScaling.Increment = i.Values.RangeValues.Step;
               }
               break;

            case WiaPropertyId.ScannerItemXPos:                     // XPos
               if ((i.PropertyAttributes & WiaPropertyAttributesFlags.Write) == WiaPropertyAttributesFlags.Write)
               {
                  _numXPos.Enabled = true;
                  _numXPos.Minimum = i.Values.RangeValues.MinimumValue;
                  _numXPos.Maximum = i.Values.RangeValues.MaximumValue;
                  _numXPos.Increment = i.Values.RangeValues.Step;
               }
               break;

            case WiaPropertyId.ScannerItemYPos:                     // YPos
               if ((i.PropertyAttributes & WiaPropertyAttributesFlags.Write) == WiaPropertyAttributesFlags.Write)
               {
                  _numYPos.Enabled = true;
                  _numYPos.Minimum = i.Values.RangeValues.MinimumValue;
                  _numYPos.Maximum = i.Values.RangeValues.MaximumValue;
                  _numYPos.Increment = i.Values.RangeValues.Step;
               }
               break;

            case WiaPropertyId.ScannerItemXExtent:                  // Width
               if ((i.PropertyAttributes & WiaPropertyAttributesFlags.Write) == WiaPropertyAttributesFlags.Write)
               {
                  _numWidth.Enabled = true;
                  _numWidth.Minimum = i.Values.RangeValues.MinimumValue;
                  _numWidth.Maximum = i.Values.RangeValues.MaximumValue;
                  _numWidth.Increment = i.Values.RangeValues.Step;
               }
               break;

            case WiaPropertyId.ScannerItemYExtent:                  // Height
               if ((i.PropertyAttributes & WiaPropertyAttributesFlags.Write) == WiaPropertyAttributesFlags.Write)
               {
                  _numHeight.Enabled = true;
                  _numHeight.Minimum = i.Values.RangeValues.MinimumValue;
                  _numHeight.Maximum = i.Values.RangeValues.MaximumValue;
                  _numHeight.Increment = i.Values.RangeValues.Step;
               }
               break;

            case WiaPropertyId.ItemFormat:                   // Format
               if ((i.PropertyAttributes & WiaPropertyAttributesFlags.Write) == WiaPropertyAttributesFlags.Write)
               {
                  _cmbFormat.Enabled = true;
               }

               // Fill the formats list.
               FillTransferFormatsList();
               break;

            case WiaPropertyId.ItemCompression:              // Compression
               if ((i.PropertyAttributes & WiaPropertyAttributesFlags.Write) == WiaPropertyAttributesFlags.Write)
               {
                  _cmbCompression.Enabled = true;
               }

               // Fill the compression list.
               HelperFunctions.FillComboWithValidValues(_cmbCompression, i);
               break;

            case WiaPropertyId.ItemDatatype:                 // Image data type
               if ((i.PropertyAttributes & WiaPropertyAttributesFlags.Write) == WiaPropertyAttributesFlags.Write)
               {
                  _cmbImageDataType.Enabled = true;
               }

               // Fill the image data type list.
               HelperFunctions.FillComboWithValidValues(_cmbImageDataType, i);
               break;

            case WiaPropertyId.ItemTymed:                    // Transfer mode
               // These controls will be updated when we enumerate the WIA formats, since the TYMED
               // is one of the formats enumeration callback parameters.
               break;

            case WiaPropertyId.ScannerItemBrightness:               // Brightness
               if ((i.PropertyAttributes & WiaPropertyAttributesFlags.Write) == WiaPropertyAttributesFlags.Write)
               {
                  _numBrightness.Enabled = true;
                  _numBrightness.Minimum = i.Values.RangeValues.MinimumValue;
                  _numBrightness.Maximum = i.Values.RangeValues.MaximumValue;
                  _numBrightness.Increment = i.Values.RangeValues.Step;
               }

               // Set the brightness effect ranges.
               _lblBrightness.Text = string.Format(DemosGlobalization.GetResxString(GetType(), "Resx_Brightness") + " ({0} To {1})", i.Values.RangeValues.MinimumValue.ToString(), i.Values.RangeValues.MaximumValue.ToString());
               break;

            case WiaPropertyId.ScannerItemContrast:                 // Contrast
               if ((i.PropertyAttributes & WiaPropertyAttributesFlags.Write) == WiaPropertyAttributesFlags.Write)
               {
                  _numContrast.Enabled = true;
                  _numContrast.Minimum = i.Values.RangeValues.MinimumValue;
                  _numContrast.Maximum = i.Values.RangeValues.MaximumValue;
                  _numContrast.Increment = i.Values.RangeValues.Step;
               }

               // Set the contrast effect ranges.
               _lblContrast.Text = string.Format(DemosGlobalization.GetResxString(GetType(), "Resx_Contrast") + " ({0} To {1})", i.Values.RangeValues.MinimumValue.ToString(), i.Values.RangeValues.MaximumValue.ToString());
               break;
            }
         }
      }

      private void FillFormatsListWithEnumeratedFormats()
      {
         if (MainForm._formatsList.Count <= 0)
            return;

         _cmbFormat.Items.Clear();
         foreach(MyFormat i in MainForm._formatsList)
         {
            // Enable the supported transfer mode radio button according to whether it's supported on not.
            switch(i.TransferMode)
            {
            case WiaTransferMode.Memory:
               _rdMemoryMode.Enabled = true;
               break;

            case WiaTransferMode.File:
               _rdFileMode.Enabled = true;
               break;
            }

            // Only add the formats that match the selected transfer mode (TYMED).
            if(i.TransferMode == MainForm._wiaProperties.DataTransfer.TransferMode)
            {
               _cmbFormat.Items.Add(i.FormatName);
               _cmbFormat.SelectedIndex = 0;
            }
         }

         if (_cmbFormat.Items.Count <= 0)
         {
            _cmbFormat.Enabled = false;
         }
         else
         {
            _cmbFormat.Enabled = true;
         }
      }

      private void WiaPropertiesForm_FormClosed(object sender, FormClosedEventArgs e)
      {
         MainForm._formatsList.Clear();
         MainForm._capabilitiesList.Clear();
      }

      private void _cbColored_Click(object sender, EventArgs e)
      {
#if !LEADTOOLS_V17_OR_LATER
         MainForm._wiaSession.LongValue = (int)WiaImageType.Color;
         MainForm._wiaSession.SetPropertyLong(MainForm._selectedWiaItem, null, WiaPropertyId.ScannerItemCurIntent);
#else
         MainForm._wiaSession.SetPropertyLong(MainForm._selectedWiaItem, null, WiaPropertyId.ScannerItemCurIntent, (int)WiaImageType.Color);
#endif //#if !LEADTOOLS_V17_OR_LATER
         GetWiaProperties();
      }

      private void _cbGrayscale_Click(object sender, EventArgs e)
      {
#if !LEADTOOLS_V17_OR_LATER
         MainForm._wiaSession.LongValue = (int)WiaImageType.Grayscale;
         MainForm._wiaSession.SetPropertyLong(MainForm._selectedWiaItem, null, WiaPropertyId.ScannerItemCurIntent);
#else
         MainForm._wiaSession.SetPropertyLong(MainForm._selectedWiaItem, null, WiaPropertyId.ScannerItemCurIntent, (int)WiaImageType.Grayscale);
#endif //#if !LEADTOOLS_V17_OR_LATER
         GetWiaProperties();
      }

      private void _cbText_Click(object sender, EventArgs e)
      {
#if !LEADTOOLS_V17_OR_LATER
         MainForm._wiaSession.LongValue = (int)WiaImageType.Text;
         MainForm._wiaSession.SetPropertyLong(MainForm._selectedWiaItem, null, WiaPropertyId.ScannerItemCurIntent);
#else
         MainForm._wiaSession.SetPropertyLong(MainForm._selectedWiaItem, null, WiaPropertyId.ScannerItemCurIntent, (int)WiaImageType.Text);
#endif //#if !LEADTOOLS_V17_OR_LATER
         GetWiaProperties();
      }

      private void _cbDuplex_Click(object sender, EventArgs e)
      {
         if (MainForm._wiaVersion == WiaVersion.Version2)
         {
            _cbAutoAdvance.Checked = false;
         }
         UpdateWiaPropertiesDlgControls();
      }

      private void _cbAutoAdvance_Click(object sender, EventArgs e)
      {
         if (MainForm._wiaVersion == WiaVersion.Version2)
         {
            _cbDuplex.Checked = false;
         }
         UpdateWiaPropertiesDlgControls();
      }

      private void _rdMemoryMode_Click(object sender, EventArgs e)
      {
         WiaDataTransferProperties dataTransfer = MainForm._wiaProperties.DataTransfer;
         dataTransfer.TransferMode = WiaTransferMode.Memory;
         MainForm._wiaProperties.DataTransfer = dataTransfer;

         // Enable the enumerate formats event.
         MainForm._wiaSession.EnumFormatsEvent += new EventHandler<WiaEnumFormatsEventArgs>(_wiaSession_EnumFormatsEvent);

         MainForm._formatsList.Clear();

         // Enumerate the supported WIA formats and add them to the formats combo box.
         MainForm._wiaSession.EnumFormats(MainForm._selectedWiaItem, WiaEnumFormatsFlags.None);

         // Disable the enumerate formats event.
         MainForm._wiaSession.EnumFormatsEvent -= new EventHandler<WiaEnumFormatsEventArgs>(_wiaSession_EnumFormatsEvent);

         FillFormatsListWithEnumeratedFormats();

         UpdateWiaPropertiesDlgControls();
      }

      private void _rdFileMode_Click(object sender, EventArgs e)
      {
         WiaDataTransferProperties dataTransfer = MainForm._wiaProperties.DataTransfer;
         dataTransfer.TransferMode = WiaTransferMode.File;
         MainForm._wiaProperties.DataTransfer = dataTransfer;

         // Enable the enumerate formats event.
         MainForm._wiaSession.EnumFormatsEvent += new EventHandler<WiaEnumFormatsEventArgs>(_wiaSession_EnumFormatsEvent);

         MainForm._formatsList.Clear();

         // Enumerate the supported WIA formats and add them to the formats combo box.
         MainForm._wiaSession.EnumFormats(MainForm._selectedWiaItem, WiaEnumFormatsFlags.None);

         // Disable the enumerate formats event.
         MainForm._wiaSession.EnumFormatsEvent -= new EventHandler<WiaEnumFormatsEventArgs>(_wiaSession_EnumFormatsEvent);

         FillFormatsListWithEnumeratedFormats();

         UpdateWiaPropertiesDlgControls();
      }

      private void _btnOk_Click(object sender, EventArgs e)
      {
         SetWiaProperties(MainForm._selectedWiaItem);

         // Update the file name extension for the szFileName member of the acquire options structure.
         HelperFunctions.GetFormatFilterAndExtension();

         MainForm._wiaAcquireOptions.FileName = Path.ChangeExtension(MainForm._wiaAcquireOptions.FileName, HelperFunctions.Extension);

         DialogResult = DialogResult.OK;
      }

      private void _cmbHorizontalResolution_SelectedIndexChanged(object sender, EventArgs e)
      {
         try
         {
            WiaImageResolutionProperties ImageResProps = MainForm._wiaProperties.ImageResolution;
            MyItemData myItem = (MyItemData)_cmbHorizontalResolution.SelectedItem;

            int longValue = 0;
#if !LEADTOOLS_V17_OR_LATER
            MainForm._wiaSession.LongValue = myItem.ItemData;
            MainForm._wiaSession.SetPropertyLong(MainForm._selectedWiaItem, null, WiaPropertyId.ScannerItemXRes);
            MainForm._wiaSession.GetPropertyLong(MainForm._selectedWiaItem, null, WiaPropertyId.ScannerItemXExtent);
            longValue = MainForm._wiaSession.LongValue;
#else
            MainForm._wiaSession.SetPropertyLong(MainForm._selectedWiaItem, null, WiaPropertyId.ScannerItemXRes, myItem.ItemData);
            longValue = MainForm._wiaSession.GetPropertyLong(MainForm._selectedWiaItem, null, WiaPropertyId.ScannerItemXExtent);
#endif //#if !LEADTOOLS_V17_OR_LATER

            ImageResProps.Width = longValue;
            _numWidth.Maximum = longValue;
            _numWidth.Value = longValue;

            MainForm._wiaProperties.ImageResolution = ImageResProps;
         }
         catch(Exception)
         {
            ; // Do nothing
         }
      }

      private void _cmbVerticalResolution_SelectedIndexChanged(object sender, EventArgs e)
      {
         try
         {
            WiaImageResolutionProperties ImageResProps = MainForm._wiaProperties.ImageResolution;
            MyItemData myItem = (MyItemData)_cmbVerticalResolution.SelectedItem;

            int longValue = 0;
#if !LEADTOOLS_V17_OR_LATER
            MainForm._wiaSession.LongValue = myItem.ItemData;
            MainForm._wiaSession.SetPropertyLong(MainForm._selectedWiaItem, null, WiaPropertyId.ScannerItemYRes);
            MainForm._wiaSession.GetPropertyLong(MainForm._selectedWiaItem, null, WiaPropertyId.ScannerItemYExtent);
            longValue = MainForm._wiaSession.LongValue;
#else
            MainForm._wiaSession.SetPropertyLong(MainForm._selectedWiaItem, null, WiaPropertyId.ScannerItemYRes, myItem.ItemData);
            longValue = MainForm._wiaSession.GetPropertyLong(MainForm._selectedWiaItem, null, WiaPropertyId.ScannerItemYExtent);
#endif //#if !LEADTOOLS_V17_OR_LATER

            ImageResProps.Height = longValue;
            _numHeight.Maximum = longValue;
            _numHeight.Value = longValue;
            MainForm._wiaProperties.ImageResolution = ImageResProps;
         }
         catch(Exception)
         {
            ; // Do nothing
         }
      }

      private void _numHorizontalResolution_Leave(object sender, EventArgs e)
      {
         try
         {
            WiaImageResolutionProperties ImageResProps = MainForm._wiaProperties.ImageResolution;

#if !LEADTOOLS_V17_OR_LATER
            MainForm._wiaSession.LongValue = Convert.ToInt32(_numHorizontalResolution.Value);
            MainForm._wiaSession.SetPropertyLong(MainForm._selectedWiaItem, null, WiaPropertyId.ScannerItemXRes);
#else
            MainForm._wiaSession.SetPropertyLong(MainForm._selectedWiaItem, null, WiaPropertyId.ScannerItemXRes, Convert.ToInt32(_numHorizontalResolution.Value));
#endif //#if !LEADTOOLS_V17_OR_LATER

            int longValue = 0;
#if !LEADTOOLS_V17_OR_LATER
            MainForm._wiaSession.GetPropertyLong(MainForm._selectedWiaItem, null, WiaPropertyId.ScannerItemXExtent);
            longValue = MainForm._wiaSession.LongValue;
#else
            longValue = MainForm._wiaSession.GetPropertyLong(MainForm._selectedWiaItem, null, WiaPropertyId.ScannerItemXExtent);
#endif //#if !LEADTOOLS_V17_OR_LATER
            ImageResProps.Width = longValue;
            _numWidth.Maximum = longValue;
            _numWidth.Value = longValue;

            if(System.Environment.OSVersion.Version.Major >= 6)   // VISTA or later
            {
#if !LEADTOOLS_V17_OR_LATER
               MainForm._wiaSession.GetPropertyLong(MainForm._selectedWiaItem, null, WiaPropertyId.ScannerItemXScaling);
               longValue = MainForm._wiaSession.LongValue;
#else
               longValue = MainForm._wiaSession.GetPropertyLong(MainForm._selectedWiaItem, null, WiaPropertyId.ScannerItemXScaling);
#endif //#if !LEADTOOLS_V17_OR_LATER

               ImageResProps.XScaling = longValue;
               _numHorizontalScaling.Maximum = longValue;
               _numHorizontalScaling.Value = longValue;
            }
            MainForm._wiaProperties.ImageResolution = ImageResProps;
            UpdateWiaPropertiesDlgControls();
         }
         catch(Exception)
         {
            ; // Do nothing
         }
      }

      private void _numVerticalResolution_Leave(object sender, EventArgs e)
      {
         try
         {
            WiaImageResolutionProperties ImageResProps = MainForm._wiaProperties.ImageResolution;

            int longValue = 0;
#if !LEADTOOLS_V17_OR_LATER
            MainForm._wiaSession.LongValue = Convert.ToInt32(_numVerticalResolution.Value);
            MainForm._wiaSession.SetPropertyLong(MainForm._selectedWiaItem, null, WiaPropertyId.ScannerItemYRes);
            MainForm._wiaSession.GetPropertyLong(MainForm._selectedWiaItem, null, WiaPropertyId.ScannerItemYExtent);
            longValue = MainForm._wiaSession.LongValue;
#else
            MainForm._wiaSession.SetPropertyLong(MainForm._selectedWiaItem, null, WiaPropertyId.ScannerItemYRes, Convert.ToInt32(_numVerticalResolution.Value));
            longValue = MainForm._wiaSession.GetPropertyLong(MainForm._selectedWiaItem, null, WiaPropertyId.ScannerItemYExtent);
#endif //#if !LEADTOOLS_V17_OR_LATER

            ImageResProps.Height = longValue;
            _numHeight.Maximum = longValue;
            _numHeight.Value = longValue;

            if (System.Environment.OSVersion.Version.Major >= 6)   // VISTA or later
            {
#if !LEADTOOLS_V17_OR_LATER
               MainForm._wiaSession.GetPropertyLong(MainForm._selectedWiaItem, null, WiaPropertyId.ScannerItemYScaling);
               longValue = MainForm._wiaSession.LongValue;
#else
               longValue = MainForm._wiaSession.GetPropertyLong(MainForm._selectedWiaItem, null, WiaPropertyId.ScannerItemYScaling);
#endif //#if !LEADTOOLS_V17_OR_LATER

               ImageResProps.YScaling = longValue;
               _numVerticalScaling.Maximum = longValue;
               _numVerticalScaling.Value = longValue;
            }
            MainForm._wiaProperties.ImageResolution = ImageResProps;
            UpdateWiaPropertiesDlgControls();
         }
         catch(Exception)
         {
            ; // Do nothing
         }
      }

      private void _numHorizontalScaling_Leave(object sender, EventArgs e)
      {
         try
         {
            WiaImageResolutionProperties ImageResProps = MainForm._wiaProperties.ImageResolution;
            int longValue = 0;
#if !LEADTOOLS_V17_OR_LATER
            MainForm._wiaSession.LongValue = Convert.ToInt32(_numHorizontalScaling.Value);
            MainForm._wiaSession.SetPropertyLong(MainForm._selectedWiaItem, null, WiaPropertyId.ScannerItemXScaling);
            MainForm._wiaSession.GetPropertyLong(MainForm._selectedWiaItem, null, WiaPropertyId.ScannerItemXPos);
            longValue = MainForm._wiaSession.LongValue;
#else
            MainForm._wiaSession.SetPropertyLong(MainForm._selectedWiaItem, null, WiaPropertyId.ScannerItemXScaling, Convert.ToInt32(_numHorizontalScaling.Value));
            longValue = MainForm._wiaSession.GetPropertyLong(MainForm._selectedWiaItem, null, WiaPropertyId.ScannerItemXPos);
#endif //#if !LEADTOOLS_V17_OR_LATER

            ImageResProps.XPos = longValue;
            _numXPos.Maximum = longValue;
            _numXPos.Value = longValue;

#if !LEADTOOLS_V17_OR_LATER
            MainForm._wiaSession.GetPropertyLong(MainForm._selectedWiaItem, null, WiaPropertyId.ScannerItemXExtent);
            longValue = MainForm._wiaSession.LongValue;
#else
            longValue = MainForm._wiaSession.GetPropertyLong(MainForm._selectedWiaItem, null, WiaPropertyId.ScannerItemXExtent);
#endif //#if !LEADTOOLS_V17_OR_LATER

            ImageResProps.Width = longValue;
            _numWidth.Maximum = longValue;
            _numWidth.Value = longValue;

#if !LEADTOOLS_V17_OR_LATER
            MainForm._wiaSession.GetPropertyLong(MainForm._selectedWiaItem, null, WiaPropertyId.ScannerItemXRes);
            longValue = MainForm._wiaSession.LongValue;
#else
            longValue = MainForm._wiaSession.GetPropertyLong(MainForm._selectedWiaItem, null, WiaPropertyId.ScannerItemXRes);
#endif //#if !LEADTOOLS_V17_OR_LATER

            ImageResProps.HorizontalResolution = longValue;
            _numHorizontalResolution.Maximum = longValue;
            _numHorizontalResolution.Value = longValue;
            MainForm._wiaProperties.ImageResolution = ImageResProps;

            UpdateWiaPropertiesDlgControls();
         }
         catch (Exception)
         {
            ; // Do nothing
         }
      }

      private void _numVerticalScaling_Leave(object sender, EventArgs e)
      {
         try
         {
            WiaImageResolutionProperties ImageResProps = MainForm._wiaProperties.ImageResolution;
            int longValue = 0;
#if !LEADTOOLS_V17_OR_LATER
            MainForm._wiaSession.LongValue = Convert.ToInt32(_numVerticalScaling.Value);
            MainForm._wiaSession.SetPropertyLong(MainForm._selectedWiaItem, null, WiaPropertyId.ScannerItemYScaling);
            MainForm._wiaSession.GetPropertyLong(MainForm._selectedWiaItem, null, WiaPropertyId.ScannerItemYPos);
            longValue = MainForm._wiaSession.LongValue;
#else
            MainForm._wiaSession.SetPropertyLong(MainForm._selectedWiaItem, null, WiaPropertyId.ScannerItemYScaling, Convert.ToInt32(_numVerticalScaling.Value));
            longValue = MainForm._wiaSession.GetPropertyLong(MainForm._selectedWiaItem, null, WiaPropertyId.ScannerItemYPos);
#endif //#if !LEADTOOLS_V17_OR_LATER

            ImageResProps.YPos = longValue;
            _numYPos.Maximum = longValue;
            _numYPos.Value = longValue;

#if !LEADTOOLS_V17_OR_LATER
            MainForm._wiaSession.GetPropertyLong(MainForm._selectedWiaItem, null, WiaPropertyId.ScannerItemYExtent);
            longValue = MainForm._wiaSession.LongValue;
#else
            longValue = MainForm._wiaSession.GetPropertyLong(MainForm._selectedWiaItem, null, WiaPropertyId.ScannerItemYExtent);
#endif //#if !LEADTOOLS_V17_OR_LATER

            ImageResProps.Height = longValue;
            _numHeight.Maximum = longValue;
            _numHeight.Value = longValue;

#if !LEADTOOLS_V17_OR_LATER
            MainForm._wiaSession.GetPropertyLong(MainForm._selectedWiaItem, null, WiaPropertyId.ScannerItemYRes);
            longValue = MainForm._wiaSession.LongValue;
#else
            longValue = MainForm._wiaSession.GetPropertyLong(MainForm._selectedWiaItem, null, WiaPropertyId.ScannerItemYRes);
#endif //#if !LEADTOOLS_V17_OR_LATER

            ImageResProps.VerticalResolution = longValue;
            _numVerticalResolution.Maximum = longValue;
            _numVerticalResolution.Value = longValue;
            MainForm._wiaProperties.ImageResolution = ImageResProps;

            UpdateWiaPropertiesDlgControls();
         }
         catch (Exception)
         {
            ; // Do nothing
         }
      }

      private void _numXPos_Leave(object sender, EventArgs e)
      {
         try
         {
            WiaImageResolutionProperties ImageResProps = MainForm._wiaProperties.ImageResolution;
            int longValue = 0;
#if !LEADTOOLS_V17_OR_LATER
            MainForm._wiaSession.LongValue = Convert.ToInt32(_numXPos.Value);
            MainForm._wiaSession.SetPropertyLong(MainForm._selectedWiaItem, null, WiaPropertyId.ScannerItemXPos);
            MainForm._wiaSession.GetPropertyLong(MainForm._selectedWiaItem, null, WiaPropertyId.ScannerItemXExtent);
            longValue = MainForm._wiaSession.LongValue;
#else
            MainForm._wiaSession.SetPropertyLong(MainForm._selectedWiaItem, null, WiaPropertyId.ScannerItemXPos, Convert.ToInt32(_numXPos.Value));
            longValue = MainForm._wiaSession.GetPropertyLong(MainForm._selectedWiaItem, null, WiaPropertyId.ScannerItemXExtent);
#endif //#if !LEADTOOLS_V17_OR_LATER

            ImageResProps.Width = longValue;
            _numWidth.Maximum = longValue;
            _numWidth.Value = longValue;
            MainForm._wiaProperties.ImageResolution = ImageResProps;

            UpdateWiaPropertiesDlgControls();
         }
         catch (Exception)
         {
            ; // Do nothing
         }
      }

      private void _numYPos_Leave(object sender, EventArgs e)
      {
         try
         {
            WiaImageResolutionProperties ImageResProps = MainForm._wiaProperties.ImageResolution;
            int longValue = 0;
#if !LEADTOOLS_V17_OR_LATER
            MainForm._wiaSession.LongValue = Convert.ToInt32(_numYPos.Value);
            MainForm._wiaSession.SetPropertyLong(MainForm._selectedWiaItem, null, WiaPropertyId.ScannerItemYPos);
            MainForm._wiaSession.GetPropertyLong(MainForm._selectedWiaItem, null, WiaPropertyId.ScannerItemYExtent);
            longValue = MainForm._wiaSession.LongValue;
#else
            MainForm._wiaSession.SetPropertyLong(MainForm._selectedWiaItem, null, WiaPropertyId.ScannerItemYPos, Convert.ToInt32(_numYPos.Value));
            longValue = MainForm._wiaSession.GetPropertyLong(MainForm._selectedWiaItem, null, WiaPropertyId.ScannerItemYExtent);
#endif //#if !LEADTOOLS_V17_OR_LATER

            ImageResProps.Height = longValue;
            _numHeight.Maximum = longValue;
            _numHeight.Value = longValue;
            MainForm._wiaProperties.ImageResolution = ImageResProps;

            UpdateWiaPropertiesDlgControls();
         }
         catch (Exception)
         {
            ; // Do nothing
         }
      }

      private void _num_Leave(object sender, EventArgs e)
      {
         UpdateWiaPropertiesDlgControls();
      }
   }
}
