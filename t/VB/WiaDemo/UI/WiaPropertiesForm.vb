' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.IO
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports Leadtools.Wia

Partial Public Class WiaPropertiesForm : Inherits Form
   Private _duplexFlags As Int32

   Public Sub New()
      InitializeComponent()
   End Sub

   Private Sub WiaPropertiesForm_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
      MainForm._wiaProperties = WiaProperties.Empty

      ' if the WIA 2.0 version is selected and the ShowUserInterface option is on
      ' then in this case WIA 2.0 will only work as file transfer, so we need to set the 
      ' transfer mode to file transfer
      If MainForm._wiaVersion = WiaVersion.Version2 AndAlso MainForm._showUserInterface Then
#If (Not LEADTOOLS_V17_OR_LATER) Then
         MainForm._wiaSession.LongValue = CInt(WiaTransferMode.File)
         MainForm._wiaSession.SetPropertyLong(MainForm._selectedWiaItem, Nothing, WiaPropertyId.ItemTymed)
#Else
         MainForm._wiaSession.SetPropertyLong(MainForm._selectedWiaItem, Nothing, WiaPropertyId.ItemTymed, CInt(WiaTransferMode.File))
#End If '#if !LEADTOOLS_V17_OR_LATER
      End If

      If MainForm._wiaSession.SelectedDeviceType = WiaDeviceType.Scanner Then
         ' First, we need to check for the current device intent, if it's None then we need to 
         ' set it to Color as the default value.
#If (Not LEADTOOLS_V17_OR_LATER) Then
         MainForm._wiaSession.GetPropertyLong(MainForm._selectedWiaItem, Nothing, WiaPropertyId.ScannerItemCurIntent)

         If MainForm._wiaSession.LongValue = CInt(WiaImageType.None) Then
            ' Set the device intent to color intent as the default value.
            MainForm._wiaSession.LongValue = CInt(WiaImageType.Color)
            MainForm._wiaSession.SetPropertyLong(MainForm._selectedWiaItem, Nothing, WiaPropertyId.ScannerItemCurIntent)
         End If
#Else
         Dim longValue As Integer = MainForm._wiaSession.GetPropertyLong(MainForm._selectedWiaItem, Nothing, WiaPropertyId.ScannerItemCurIntent)

         If longValue = CInt(WiaImageType.None) Then
            ' Set the device intent to color intent as the default value.
            MainForm._wiaSession.SetPropertyLong(MainForm._selectedWiaItem, Nothing, WiaPropertyId.ScannerItemCurIntent, CInt(WiaImageType.Color))
         End If
#End If '#if !LEADTOOLS_V17_OR_LATER
      End If

      Try
#If (Not LEADTOOLS_V17_OR_LATER) Then
         MainForm._wiaSession.GetProperties(MainForm._selectedWiaItem)
         MainForm._wiaProperties = MainForm._wiaSession.Properties
#Else
         MainForm._wiaProperties = MainForm._wiaSession.GetProperties(MainForm._selectedWiaItem)
#End If '#if !LEADTOOLS_V17_OR_LATER
      Catch ex As Exception
         Messager.ShowError(Me, ex)
         DialogResult = DialogResult.No
      End Try

      MainForm._capabilitiesList.Clear()

      ' Enable the enumerate capabilities event.
      AddHandler MainForm._wiaSession.EnumCapabilitiesEvent, AddressOf _wiaSession_EnumCapabilitiesEvent

      ' Enumerate the WIA root item capabilities in order to get the device capabilities (Duplex modes and Pages count).
      Dim rootItem As Object = Nothing
#If (Not LEADTOOLS_V17_OR_LATER) Then
      MainForm._wiaSession.GetRootItem(Nothing)
      rootItem = MainForm._wiaSession.RootItem
#Else
      rootItem = MainForm._wiaSession.GetRootItem(Nothing)
#End If '#if !LEADTOOLS_V17_OR_LATER

      MainForm._wiaSession.EnumCapabilities(rootItem, WiaEnumCapabilitiesFlags.None)

      FillDlgControlsWithEnumeratedCapsValues()

      MainForm._capabilitiesList.Clear()

      ' Enumerate the capabilities for the item the user selected from within the items dialog.
      MainForm._wiaSession.EnumCapabilities(MainForm._selectedWiaItem, WiaEnumCapabilitiesFlags.None)

      FillDlgControlsWithEnumeratedCapsValues()

      ' Disable the enumerate capabilities event.
      RemoveHandler MainForm._wiaSession.EnumCapabilitiesEvent, AddressOf _wiaSession_EnumCapabilitiesEvent

      If GetWiaProperties() = False Then
         DialogResult = DialogResult.No
      End If
   End Sub

   Private Sub _wiaSession_EnumCapabilitiesEvent(ByVal sender As Object, ByVal e As WiaEnumCapabilitiesEventArgs)
      If e.CapabilitiesCount > 0 Then
         MainForm._capabilitiesList.Add(e.Capability)
      End If
   End Sub

   Private Sub FillTransferFormatsList()
      ' Enable the enumerate formats event.
      AddHandler MainForm._wiaSession.EnumFormatsEvent, AddressOf _wiaSession_EnumFormatsEvent

      MainForm._formatsList.Clear()

      ' Enumerate the supported WIA formats and add them to the formats combo box.
      MainForm._wiaSession.EnumFormats(MainForm._selectedWiaItem, WiaEnumFormatsFlags.None)

      ' Disable the enumerate formats event.
      RemoveHandler MainForm._wiaSession.EnumFormatsEvent, AddressOf _wiaSession_EnumFormatsEvent

      FillFormatsListWithEnumeratedFormats()

      Dim longValue As Integer = 0
#If (Not LEADTOOLS_V17_OR_LATER) Then
      ' Get the currently selected transfer mode and select the related transfer mode radio button.
      MainForm._wiaSession.GetPropertyLong(MainForm._selectedWiaItem, Nothing, WiaPropertyId.ItemTymed)
      longValue = MainForm._wiaSession.LongValue
#Else
      ' Get the currently selected transfer mode and select the related transfer mode radio button.
      longValue = MainForm._wiaSession.GetPropertyLong(MainForm._selectedWiaItem, Nothing, WiaPropertyId.ItemTymed)
#End If '#if !LEADTOOLS_V17_OR_LATER

      Select Case longValue
         Case CInt(WiaTransferMode.Memory)
            _rdMemoryMode.Checked = True

         Case CInt(WiaTransferMode.File)
            _rdFileMode.Checked = True
      End Select

      If _cmbFormat.Items.Count > 0 Then
         Dim guidValue As Guid = Guid.Empty
#If (Not LEADTOOLS_V17_OR_LATER) Then
         ' Get the currently selected format and select the relevant format from the formats combo.
         MainForm._wiaSession.GetPropertyGuid(MainForm._selectedWiaItem, Nothing, WiaPropertyId.ItemFormat)
         guidValue = MainForm._wiaSession.GuidValue
#Else
         ' Get the currently selected format and select the relevant format from the formats combo.
         guidValue = MainForm._wiaSession.GetPropertyGuid(MainForm._selectedWiaItem, Nothing, WiaPropertyId.ItemFormat)
#End If '#if !LEADTOOLS_V17_OR_LATER

         HelperFunctions.SelectFormatFromCombo(_cmbFormat, guidValue)
      End If
   End Sub

   Private Sub _wiaSession_EnumFormatsEvent(ByVal sender As Object, ByVal e As WiaEnumFormatsEventArgs)
      If e.FormatsCount > 0 Then
         Dim myFormat As MyFormat = myFormat.Empty
#If (Not LEADTOOLS_V17_OR_LATER) Then
         WiaSession.GetFormatGuid(e.Format)
         myFormat.Format = WiaSession.FormatGuid
#Else
         myFormat.Format = WiaSession.GetFormatGuid(e.Format)
#End If '#if !LEADTOOLS_V17_OR_LATER
         myFormat.FormatCLSID = myFormat.Format.ToString()
         myFormat.FormatName = e.Format.ToString()
         myFormat.TransferMode = e.TransferMode
         myFormat.TransferModeString = e.TransferMode.ToString()

         MainForm._formatsList.Add(myFormat)
      End If
   End Sub

   Private Sub UpdateWiaPropertiesDlgControls()
      Dim enableDuplexRelatedCtrls As Boolean = False

      If _numHorizontalResolution.Text.Length <= 0 OrElse _numVerticalResolution.Value.ToString().Length <= 0 OrElse _numMaxPagesCount.Text.Length <= 0 OrElse _numHorizontalScaling.Text.Length <= 0 OrElse _numVerticalScaling.Text.Length <= 0 OrElse _numXPos.Text.Length <= 0 OrElse _numYPos.Text.Length <= 0 OrElse _numWidth.Text.Length <= 0 OrElse _numHeight.Text.Length <= 0 OrElse _numBrightness.Text.Length <= 0 OrElse _numContrast.Text.Length <= 0 Then
         _btnOk.Enabled = False
      Else
         _btnOk.Enabled = True
      End If

      ' Disable the 'Max Pages Count' field if Flatbed is selected.
      If ((MainForm._wiaProperties.ScanningMode And WiaScanningModeFlags.Flatbed) = WiaScanningModeFlags.Flatbed) OrElse (MainForm._wiaProperties.ScanningMode = WiaScanningModeFlags.None) Then
         _numMaxPagesCount.Enabled = False
      Else
         _numMaxPagesCount.Enabled = True
      End If

      If _cbDuplex.Checked Then
         enableDuplexRelatedCtrls = True
      End If

      If MainForm._wiaSession.SelectedDeviceType = WiaDeviceType.Scanner Then
         If MainForm._wiaVersion = WiaVersion.Version1 Then
            ' Enable the duplex controls
            If (_duplexFlags And CUInt(WiaScanningModeFlags.Duplex)) = CUInt(WiaScanningModeFlags.Duplex) Then
               If (Not enableDuplexRelatedCtrls) Then
                  If (_duplexFlags And CUInt(WiaScanningModeFlags.FrontOnly)) = CUInt(WiaScanningModeFlags.FrontOnly) Then
                     _cbFrontOnly.Checked = False
                  End If
               End If
            End If
         Else
            _cbAutoAdvance.Text = "Advanced Duplex"

            ' Disable the Image Data Type combo box while working on WIA 2.0 (mentioned limitation in the 
            ' documentation as result for Microsoft's bug - since we have found that if you set both the Image
            ' type (ScannerItemCurIntent) and Image data type (ItemDatatype) then the image data type will be ignored).
            ' NOTE: If you want to use the nImageDataType member of the properties structure then you have 
            ' to set the nImageType member to "None".
            _lblImageDataType.Enabled = False
            _cmbImageDataType.Enabled = False
         End If

         If (_duplexFlags And CUInt(WiaScanningModeFlags.FrontFirst)) = CUInt(WiaScanningModeFlags.FrontFirst) Then
            _cbFrontFirst.Enabled = enableDuplexRelatedCtrls
         End If
         If (_duplexFlags And CUInt(WiaScanningModeFlags.BackFirst)) = CUInt(WiaScanningModeFlags.BackFirst) Then
            _cbBackFirst.Enabled = enableDuplexRelatedCtrls
         End If
         If (_duplexFlags And CUInt(WiaScanningModeFlags.FrontOnly)) = CUInt(WiaScanningModeFlags.FrontOnly) Then
            _cbFrontOnly.Enabled = enableDuplexRelatedCtrls
         End If
         If (_duplexFlags And CUInt(WiaScanningModeFlags.BackOnly)) = CUInt(WiaScanningModeFlags.BackOnly) Then
            _cbBackOnly.Enabled = enableDuplexRelatedCtrls
         End If

         If (Not enableDuplexRelatedCtrls) Then
            _cbFrontFirst.Checked = False
            _cbBackFirst.Checked = False
            _cbBackOnly.Checked = False
         End If
      End If
   End Sub

   Private Function GetWiaProperties() As Boolean
      Try
#If (Not LEADTOOLS_V17_OR_LATER) Then
         MainForm._wiaSession.GetProperties(MainForm._selectedWiaItem)
         MainForm._wiaProperties = MainForm._wiaSession.Properties
#Else
         MainForm._wiaProperties = MainForm._wiaSession.GetProperties(MainForm._selectedWiaItem)
#End If '#if !LEADTOOLS_V17_OR_LATER
      Catch ex As Exception
         Messager.ShowError(Me, ex)
         DialogResult = DialogResult.No
      End Try

      ' Select the paper source and duplex mode values.
      If (MainForm._wiaProperties.ScanningMode And WiaScanningModeFlags.Feeder) = WiaScanningModeFlags.Feeder Then
         _cbFeeder.Checked = True
      End If
      If (MainForm._wiaProperties.ScanningMode And WiaScanningModeFlags.Flatbed) = WiaScanningModeFlags.Flatbed Then
         _cbFlatbed.Checked = True
      End If
      If (MainForm._wiaProperties.ScanningMode And WiaScanningModeFlags.Duplex) = WiaScanningModeFlags.Duplex Then
         _cbDuplex.Checked = True
      End If
      If (MainForm._wiaProperties.ScanningMode And WiaScanningModeFlags.FrontFirst) = WiaScanningModeFlags.FrontFirst Then
         _cbFrontFirst.Checked = True
      End If
      If (MainForm._wiaProperties.ScanningMode And WiaScanningModeFlags.BackFirst) = WiaScanningModeFlags.BackFirst Then
         _cbBackFirst.Checked = True
      End If
      If (MainForm._wiaProperties.ScanningMode And WiaScanningModeFlags.FrontOnly) = WiaScanningModeFlags.FrontOnly Then
         _cbFrontOnly.Checked = True
      End If
      If (MainForm._wiaProperties.ScanningMode And WiaScanningModeFlags.BackOnly) = WiaScanningModeFlags.BackOnly Then
         _cbBackOnly.Checked = True
      End If
      If (MainForm._wiaProperties.ScanningMode And WiaScanningModeFlags.NextPage) = WiaScanningModeFlags.NextPage Then
         _cbNextPage.Checked = True
      End If
      If (MainForm._wiaProperties.ScanningMode And WiaScanningModeFlags.Prefeed) = WiaScanningModeFlags.Prefeed Then
         _cbPrefeed.Checked = True
      End If
      If (MainForm._wiaProperties.ScanningMode And WiaScanningModeFlags.AutoAdvance) = WiaScanningModeFlags.AutoAdvance OrElse (MainForm._wiaProperties.ScanningMode And WiaScanningModeFlags.AdvancedDuplex) = WiaScanningModeFlags.AdvancedDuplex Then
         _cbAutoAdvance.Checked = True
      End If

      If _cmbOrientation.Items.Count > 0 Then
         HelperFunctions.SelectItemFromCombo(_cmbOrientation, CInt(MainForm._wiaProperties.Orientation))
      End If

      ' Check the Image Type check boxes according to the retrieved Image type flags.
      If MainForm._wiaProperties.ImageType = WiaImageType.Color Then
         _cbColored.Checked = True
         _cbGrayscale.Checked = False
         _cbText.Checked = False
      ElseIf MainForm._wiaProperties.ImageType = WiaImageType.Grayscale Then
         _cbGrayscale.Checked = True
         _cbColored.Checked = False
         _cbText.Checked = False
      ElseIf MainForm._wiaProperties.ImageType = WiaImageType.Text Then
         _cbText.Checked = True
         _cbColored.Checked = False
         _cbGrayscale.Checked = False
      Else
         _cbColored.Checked = True
         _cbGrayscale.Checked = False
         _cbText.Checked = False
      End If

      ' Set the Max pages count value according to the retrieved one, unless the selected source is Flatbed, 
      ' then set the default value to "1".
      If (MainForm._wiaProperties.ScanningMode And WiaScanningModeFlags.Flatbed) = WiaScanningModeFlags.Flatbed OrElse (MainForm._wiaProperties.ScanningMode = WiaScanningModeFlags.None) Then
         _numMaxPagesCount.Text = "1"
      Else
         _numMaxPagesCount.Text = MainForm._wiaProperties.MaximumNumberOfPages.ToString()
      End If

      ' Select the Bits per pixel value from the combo box according to the retrieved one.
      If _cmbBitsPerPixel.Items.Count > 1 Then
         HelperFunctions.SelectItemFromCombo(_cmbBitsPerPixel, MainForm._wiaProperties.ImageResolution.BitsPerPixel)
      Else
         _cmbBitsPerPixel.Items.Clear()
         _cmbBitsPerPixel.Items.Add(MainForm._wiaProperties.ImageResolution.BitsPerPixel.ToString())
         _cmbBitsPerPixel.SelectedIndex = 0
      End If

      ' Select the Rotation Angle value from the combo box according to the retrieved one.
      If _cmbRotationAngle.Items.Count > 0 Then
         HelperFunctions.SelectItemFromCombo(_cmbRotationAngle, MainForm._wiaProperties.ImageResolution.RotationAngle)
      End If

      ' Set the Horizontal Resolution value according to the retrieved one.
      If _numHorizontalResolution.Visible = True Then
         _numHorizontalResolution.Value = MainForm._wiaProperties.ImageResolution.HorizontalResolution
      Else
         If _cmbHorizontalResolution.Items.Count > 0 Then
            HelperFunctions.SelectItemFromCombo(_cmbHorizontalResolution, MainForm._wiaProperties.ImageResolution.HorizontalResolution)
         End If
      End If

      ' Set the Vertical Resolution value according to the retrieved one.
      If _numVerticalResolution.Visible = True Then
         _numVerticalResolution.Value = MainForm._wiaProperties.ImageResolution.VerticalResolution
      Else
         If _cmbVerticalResolution.Items.Count > 0 Then
            HelperFunctions.SelectItemFromCombo(_cmbVerticalResolution, MainForm._wiaProperties.ImageResolution.VerticalResolution)
         End If
      End If

      ' Set the Horizontal Scaling value according to the retrieved one.
      _numHorizontalScaling.Value = MainForm._wiaProperties.ImageResolution.XScaling

      ' Set the Vertical Scaling value according to the retrieved one.
      _numVerticalScaling.Value = MainForm._wiaProperties.ImageResolution.YScaling

      ' Set the XPos value according to the retrieved one.
      _numXPos.Value = MainForm._wiaProperties.ImageResolution.XPos

      ' Set the YPos value according to the retrieved one.
      _numYPos.Value = MainForm._wiaProperties.ImageResolution.YPos

      ' Set the Width value according to the retrieved one.
      If (MainForm._wiaProperties.ImageResolution.Width > _numWidth.Maximum) Then
         _numWidth.Maximum = MainForm._wiaProperties.ImageResolution.Width
      End If
      _numWidth.Value = MainForm._wiaProperties.ImageResolution.Width

      ' Set the Height value according to the retrieved one.
      If (MainForm._wiaProperties.ImageResolution.Height > _numHeight.Maximum) Then
         _numHeight.Maximum = MainForm._wiaProperties.ImageResolution.Height
      End If
      _numHeight.Value = MainForm._wiaProperties.ImageResolution.Height

      ' Select the Transfer Format value from the combo box according to the retrieved one.
      If _cmbFormat.Items.Count > 0 Then
#If (Not LEADTOOLS_V17_OR_LATER) Then
         WiaSession.GetFormatGuid(MainForm._wiaProperties.DataTransfer.Format)
         Dim formatGuid As System.Guid = WiaSession.FormatGuid
#Else
         Dim formatGuid As System.Guid = WiaSession.GetFormatGuid(MainForm._wiaProperties.DataTransfer.Format)
#End If '#if !LEADTOOLS_V17_OR_LATER
         HelperFunctions.SelectFormatFromCombo(_cmbFormat, formatGuid)
      End If

      ' Select the Compression value from the combo box according to the retrieved one.
      If _cmbCompression.Items.Count > 0 Then
         HelperFunctions.SelectItemFromCombo(_cmbCompression, CInt(MainForm._wiaProperties.DataTransfer.Compression))
      End If

      ' Select the Image Data Type value from the combo box according to the retrieved one.
      If _cmbImageDataType.Items.Count > 0 Then
         HelperFunctions.SelectItemFromCombo(_cmbImageDataType, CInt(MainForm._wiaProperties.DataTransfer.ImageDataType))
      End If

      ' Disable the memory mode if the WIA version is 2.0 while the Show user interface options is ON
      If MainForm._wiaVersion = WiaVersion.Version2 AndAlso MainForm._showUserInterface Then
         _rdFileMode.Enabled = True
         _rdMemoryMode.Enabled = False
         _rdFileMode.Checked = True
      Else
         _rdFileMode.Enabled = True
         _rdMemoryMode.Enabled = True
      End If

      ' Set the Brightness value according to the retrieved one.
      _numBrightness.Value = MainForm._wiaProperties.ImageEffects.Brightness

      ' Set the Contrast value according to the retrieved one.
      _numContrast.Value = MainForm._wiaProperties.ImageEffects.Contrast

      UpdateWiaPropertiesDlgControls()

      Return True
   End Function

   Private Sub SetWiaProperties(ByVal item As Object)
      ' Reset the properties structure members first to set the selected flags and values.
      MainForm._wiaProperties = WiaProperties.Empty

      Dim dataTransfer As WiaDataTransferProperties = MainForm._wiaProperties.DataTransfer
      Dim imageResolution As WiaImageResolutionProperties = MainForm._wiaProperties.ImageResolution
      Dim imageEffects As WiaImageEffectsProperties = MainForm._wiaProperties.ImageEffects

      ' Set the user selected Image type (intent).
      If _cbColored.Checked Then
         MainForm._wiaProperties.ImageType = WiaImageType.Color
      ElseIf _cbGrayscale.Checked Then
         MainForm._wiaProperties.ImageType = WiaImageType.Grayscale
      Else
         MainForm._wiaProperties.ImageType = WiaImageType.Text
      End If

      ' Set the user specified Transfer Mode.
      If _rdMemoryMode.Checked Then
         dataTransfer.TransferMode = WiaTransferMode.Memory
      Else
         dataTransfer.TransferMode = WiaTransferMode.File
      End If

      ' Set the user specified Transfer Format.
      If _cmbFormat.Items.Count > 0 Then
         HelperFunctions.GetSelectedFormatFromCombo(_cmbFormat)
         dataTransfer.Format = HelperFunctions.Format
      End If

      ' Set the user specified max pages count.
      MainForm._wiaProperties.MaximumNumberOfPages = Convert.ToInt32(_numMaxPagesCount.Value)

      ' Set the user selected paper source and duplex mode.
      If _cbFeeder.Checked Then
         MainForm._wiaProperties.ScanningMode = MainForm._wiaProperties.ScanningMode Or WiaScanningModeFlags.Feeder
      ElseIf _cbFlatbed.Checked Then
         MainForm._wiaProperties.ScanningMode = MainForm._wiaProperties.ScanningMode Or WiaScanningModeFlags.Flatbed
      End If
      If _cbDuplex.Checked Then
         MainForm._wiaProperties.ScanningMode = MainForm._wiaProperties.ScanningMode Or WiaScanningModeFlags.Duplex
      End If
      If _cbAutoAdvance.Checked Then
         MainForm._wiaProperties.ScanningMode = MainForm._wiaProperties.ScanningMode Or WiaScanningModeFlags.AutoAdvance
      End If
      If _cbFrontFirst.Checked Then
         MainForm._wiaProperties.ScanningMode = MainForm._wiaProperties.ScanningMode Or WiaScanningModeFlags.FrontFirst
      End If
      If _cbBackFirst.Checked Then
         MainForm._wiaProperties.ScanningMode = MainForm._wiaProperties.ScanningMode Or WiaScanningModeFlags.BackFirst
      End If
      If _cbFrontOnly.Checked Then
         MainForm._wiaProperties.ScanningMode = MainForm._wiaProperties.ScanningMode Or WiaScanningModeFlags.FrontOnly
      End If
      If _cbBackOnly.Checked Then
         MainForm._wiaProperties.ScanningMode = MainForm._wiaProperties.ScanningMode Or WiaScanningModeFlags.BackOnly
      End If
      If _cbNextPage.Checked Then
         MainForm._wiaProperties.ScanningMode = MainForm._wiaProperties.ScanningMode Or WiaScanningModeFlags.NextPage
      End If
      If _cbPrefeed.Checked Then
         MainForm._wiaProperties.ScanningMode = MainForm._wiaProperties.ScanningMode Or WiaScanningModeFlags.Prefeed
      End If

      ' Set the user selected Orientation.
      If _cmbOrientation.Items.Count > 0 Then
         Dim myItem As MyItemData = CType(_cmbOrientation.SelectedItem, MyItemData)
         MainForm._wiaProperties.Orientation = CType(myItem.ItemData, WiaOrientation)
      End If

      ' Set the user selected BPP.
      If _cmbBitsPerPixel.Items.Count > 0 Then
         imageResolution.BitsPerPixel = Convert.ToInt32(_cmbBitsPerPixel.Text)
      End If

      ' Set the user selected Rotation Angle.
      If _cmbRotationAngle.Items.Count > 0 Then
         Dim myItem As MyItemData = CType(_cmbRotationAngle.SelectedItem, MyItemData)
         imageResolution.RotationAngle = myItem.ItemData
      End If

      ' Set the user specified Horizontal Resolution.
      If _numHorizontalResolution.Visible = True Then
         imageResolution.HorizontalResolution = Convert.ToInt32(_numHorizontalResolution.Value)
      Else
         If _cmbHorizontalResolution.Items.Count > 0 Then
            Dim myItem As MyItemData = CType(_cmbHorizontalResolution.SelectedItem, MyItemData)
            imageResolution.HorizontalResolution = myItem.ItemData
         End If
      End If

      ' Set the user specified Vertical Resolution.
      If _numHorizontalResolution.Visible = True Then
         imageResolution.VerticalResolution = Convert.ToInt32(_numVerticalResolution.Value)
      Else
         If _cmbVerticalResolution.Items.Count > 0 Then
            Dim myItem As MyItemData = CType(_cmbVerticalResolution.SelectedItem, MyItemData)
            imageResolution.VerticalResolution = myItem.ItemData
         End If
      End If

      ' Set the user specified Horizontal Scaling.
      imageResolution.XScaling = Convert.ToInt32(_numHorizontalScaling.Value)

      ' Set the user specified Vertical Scaling.
      imageResolution.YScaling = Convert.ToInt32(_numVerticalScaling.Value)

      ' Set the user specified XPos.
      imageResolution.XPos = Convert.ToInt32(_numXPos.Value)

      ' Set the user specified YPos.
      imageResolution.YPos = Convert.ToInt32(_numYPos.Value)

      ' Set the user specified Width.
      imageResolution.Width = Convert.ToInt32(_numWidth.Value)

      ' Set the user specified Height.
      imageResolution.Height = Convert.ToInt32(_numHeight.Value)

      ' Set the user specified Compression.
      If _cmbCompression.Items.Count > 0 Then
         Dim myItem As MyItemData = CType(_cmbCompression.SelectedItem, MyItemData)
         dataTransfer.Compression = CType(myItem.ItemData, WiaCompressionMode)
      End If

      ' Set the user specified Image Data Type.
      If _cmbImageDataType.Items.Count > 0 Then
         Dim myItem As MyItemData = CType(_cmbImageDataType.SelectedItem, MyItemData)
         dataTransfer.ImageDataType = CType(myItem.ItemData, WiaImageDataType)
      End If

      ' Set the user specified Brightness.
      imageEffects.Brightness = Convert.ToInt32(_numBrightness.Value)

      ' Set the user specified Contrast.
      imageEffects.Contrast = Convert.ToInt32(_numContrast.Value)

      ' Clear the previous properties errors
      MainForm._errorList.Clear()

      MainForm._wiaProperties.DataTransfer = dataTransfer
      MainForm._wiaProperties.ImageResolution = imageResolution
      MainForm._wiaProperties.ImageEffects = imageEffects

      ' Enable the set properties event.
      AddHandler MainForm._wiaSession.SetPropertiesEvent, AddressOf _wiaSession_SetPropertiesEvent

#If (Not LEADTOOLS_V17_OR_LATER) Then
      ' Set the properties property first before calling the SetProperties function.
      MainForm._wiaSession.Properties = MainForm._wiaProperties

      MainForm._wiaSession.SetProperties(item)
#Else
      ' Set the properties property first before calling the SetProperties function.
      MainForm._wiaSession.SetProperties(item, MainForm._wiaProperties)
#End If '#if !LEADTOOLS_V17_OR_LATER

      ' Disable the set properties event.
      RemoveHandler MainForm._wiaSession.SetPropertiesEvent, AddressOf _wiaSession_SetPropertiesEvent
   End Sub

   Private Sub _wiaSession_SetPropertiesEvent(ByVal sender As Object, ByVal e As WiaSetPropertiesEventArgs)
      If e.Error <= 0 Then
         Dim propsErrors As MyPropertiesErrors = MyPropertiesErrors.Empty

         Dim rootItem As Object = Nothing
#If (Not LEADTOOLS_V17_OR_LATER) Then
         rootItem = MainForm._wiaSession.RootItem

         ' Add the Device Name to the errors array.
         MainForm._wiaSession.GetPropertyString(rootItem, Nothing, WiaPropertyId.DeviceInfoDevName)
         propsErrors.DeviceName = MainForm._wiaSession.StringValue

         ' Add the Item Name to the errors array.
         MainForm._wiaSession.GetPropertyString(MainForm._selectedWiaItem, Nothing, WiaPropertyId.ItemName)
         propsErrors.ItemName = MainForm._wiaSession.StringValue
#Else
         rootItem = MainForm._wiaSession.GetRootItem(Nothing)

         ' Add the Device Name to the errors array.
         propsErrors.DeviceName = MainForm._wiaSession.GetPropertyString(rootItem, Nothing, WiaPropertyId.DeviceInfoDevName)

         ' Add the Item Name to the errors array.
         propsErrors.ItemName = MainForm._wiaSession.GetPropertyString(MainForm._selectedWiaItem, Nothing, WiaPropertyId.ItemName)
#End If '#if !LEADTOOLS_V17_OR_LATER

         ' Add the Property Name to the errors array.
         HelperFunctions.FindRelevantPropName(e.PropertyId, e.Value)
         propsErrors.PropertyName = HelperFunctions.PropertyName

         ' Add the Property Value to the errors array.
         HelperFunctions.FindRelevantPropValue(e.PropertyId, e.Value)
         propsErrors.PropertyValue = HelperFunctions.PropertyValueString

         ' Add the Error code to the errors array.
         propsErrors.ErrorCodeString = e.Error.ToString()

         MainForm._errorList.Add(propsErrors)
      End If
   End Sub

   Private Sub FillDlgControlsWithEnumeratedCapsValues()
      If MainForm._capabilitiesList.Count <= 0 Then
         Return
      End If

      ' Loop through the enumerated capabilities array and update the dialog controls
      For Each i As WiaCapability In MainForm._capabilitiesList
         ' Check if the property ID is supported by the received device capabilities 
         ' then enable related controls.
         Select Case i.PropertyId
            Case WiaPropertyId.ScannerItemCurIntent ' Image type
               If (i.PropertyAttributes And WiaPropertyAttributesFlags.Write) = WiaPropertyAttributesFlags.Write Then
                  _cbColored.Enabled = True
                  _cbGrayscale.Enabled = True
                  _cbText.Enabled = True
               End If

            Case WiaPropertyId.ScannerDeviceDocumentHandlingSelect ' Paper source and duplex mode
               If ((i.PropertyAttributes And WiaPropertyAttributesFlags.Flag) = WiaPropertyAttributesFlags.Flag) AndAlso ((i.PropertyAttributes And WiaPropertyAttributesFlags.Write) = WiaPropertyAttributesFlags.Write) Then
                  _duplexFlags = i.Values.FlagsValues.FlagValues
                  If (_duplexFlags And CUInt(WiaScanningModeFlags.Feeder)) = CUInt(WiaScanningModeFlags.Feeder) Then
                     _cbFeeder.Enabled = True
                  End If
                  If (_duplexFlags And CUInt(WiaScanningModeFlags.Flatbed)) = CUInt(WiaScanningModeFlags.Flatbed) Then
                     _cbFlatbed.Enabled = True
                  End If
                  If (_duplexFlags And CUInt(WiaScanningModeFlags.Duplex)) = CUInt(WiaScanningModeFlags.Duplex) Then
                     _cbDuplex.Enabled = True
                  End If
                  If (_duplexFlags And CUInt(WiaScanningModeFlags.FrontOnly)) = CUInt(WiaScanningModeFlags.FrontOnly) Then
                     _cbFrontOnly.Enabled = True
                  End If
                  If (_duplexFlags And CUInt(WiaScanningModeFlags.BackOnly)) = CUInt(WiaScanningModeFlags.BackOnly) Then
                     _cbBackOnly.Enabled = True
                  End If
                  If (_duplexFlags And CUInt(WiaScanningModeFlags.FrontFirst)) = CUInt(WiaScanningModeFlags.FrontFirst) Then
                     _cbFrontFirst.Enabled = True
                  End If
                  If (_duplexFlags And CUInt(WiaScanningModeFlags.BackFirst)) = CUInt(WiaScanningModeFlags.BackFirst) Then
                     _cbBackFirst.Enabled = True
                  End If
                  If (_duplexFlags And CUInt(WiaScanningModeFlags.NextPage)) = CUInt(WiaScanningModeFlags.NextPage) Then
                     _cbNextPage.Enabled = True
                  End If
                  If (_duplexFlags And CUInt(WiaScanningModeFlags.Prefeed)) = CUInt(WiaScanningModeFlags.Prefeed) Then
                     _cbPrefeed.Enabled = True
                  End If
                  If (_duplexFlags And CUInt(WiaScanningModeFlags.AutoAdvance)) = CUInt(WiaScanningModeFlags.AutoAdvance) OrElse (_duplexFlags And CUInt(WiaScanningModeFlags.AdvancedDuplex)) = CUInt(WiaScanningModeFlags.AdvancedDuplex) Then
                     _cbAutoAdvance.Enabled = True
                  End If
               End If

            Case WiaPropertyId.ScannerDevicePages ' Max pages count
               If (i.PropertyAttributes And WiaPropertyAttributesFlags.Write) = WiaPropertyAttributesFlags.Write Then
                  _numMaxPagesCount.Enabled = True
                  _numMaxPagesCount.Minimum = i.Values.RangeValues.MinimumValue
                  _numMaxPagesCount.Maximum = i.Values.RangeValues.MaximumValue
                  _numMaxPagesCount.Increment = i.Values.RangeValues.Step
               End If

            Case WiaPropertyId.ScannerDeviceOrientation ' Orientation
               If (i.PropertyAttributes And WiaPropertyAttributesFlags.Write) = WiaPropertyAttributesFlags.Write Then
                  _cmbOrientation.Enabled = True
               End If

               ' Fill the orientation list.
               HelperFunctions.FillComboWithValidValues(_cmbOrientation, i)

            Case WiaPropertyId.ItemDepth ' Bits per pixel
               If (i.PropertyAttributes And WiaPropertyAttributesFlags.Write) = WiaPropertyAttributesFlags.Write Then
                  _cmbBitsPerPixel.Enabled = True
               End If

               ' Fill the bits per pixel list.
               HelperFunctions.FillComboWithValidValues(_cmbBitsPerPixel, i)

            Case WiaPropertyId.ScannerItemRotation ' Rotation
               If (i.PropertyAttributes And WiaPropertyAttributesFlags.Write) = WiaPropertyAttributesFlags.Write Then
                  _cmbRotationAngle.Enabled = True
               End If

               ' Fill the rotation angle list.
               HelperFunctions.FillComboWithValidValues(_cmbRotationAngle, i)

            Case WiaPropertyId.ScannerItemXRes ' Horizontal Resolution
               If (i.PropertyAttributes And WiaPropertyAttributesFlags.Write) = WiaPropertyAttributesFlags.Write Then
                  _numHorizontalResolution.Enabled = True
                  If (i.PropertyAttributes And WiaPropertyAttributesFlags.Range) = WiaPropertyAttributesFlags.Range Then
                     _cmbHorizontalResolution.Visible = False
                     _numHorizontalResolution.Visible = True
                     _numHorizontalResolution.Minimum = i.Values.RangeValues.MinimumValue
                     _numHorizontalResolution.Maximum = i.Values.RangeValues.MaximumValue
                     _numHorizontalResolution.Increment = i.Values.RangeValues.Step
                  ElseIf (i.PropertyAttributes And WiaPropertyAttributesFlags.List) = WiaPropertyAttributesFlags.List Then
                     _cmbHorizontalResolution.Visible = True
                     _numHorizontalResolution.Visible = False

                     HelperFunctions.FillComboWithValidValues(_cmbHorizontalResolution, i)
                  End If
               End If

            Case WiaPropertyId.ScannerItemYRes ' Vertical Resolution
               If (i.PropertyAttributes And WiaPropertyAttributesFlags.Write) = WiaPropertyAttributesFlags.Write Then
                  _numVerticalResolution.Enabled = True
                  If (i.PropertyAttributes And WiaPropertyAttributesFlags.Range) = WiaPropertyAttributesFlags.Range Then
                     _cmbVerticalResolution.Visible = False
                     _numVerticalResolution.Visible = True
                     _numVerticalResolution.Minimum = i.Values.RangeValues.MinimumValue
                     _numVerticalResolution.Maximum = i.Values.RangeValues.MaximumValue
                     _numVerticalResolution.Increment = i.Values.RangeValues.Step
                  ElseIf (i.PropertyAttributes And WiaPropertyAttributesFlags.List) = WiaPropertyAttributesFlags.List Then
                     _cmbVerticalResolution.Visible = True
                     _numVerticalResolution.Visible = False

                     HelperFunctions.FillComboWithValidValues(_cmbVerticalResolution, i)
                  End If
               End If

            Case WiaPropertyId.ScannerItemXScaling ' Horizontal Scaling
               If (i.PropertyAttributes And WiaPropertyAttributesFlags.Write) = WiaPropertyAttributesFlags.Write Then
                  _numHorizontalScaling.Enabled = True
                  _numHorizontalScaling.Minimum = i.Values.RangeValues.MinimumValue
                  _numHorizontalScaling.Maximum = i.Values.RangeValues.MaximumValue
                  _numHorizontalScaling.Increment = i.Values.RangeValues.Step
               End If

            Case WiaPropertyId.ScannerItemYScaling ' Vertical Scaling
               If (i.PropertyAttributes And WiaPropertyAttributesFlags.Write) = WiaPropertyAttributesFlags.Write Then
                  _numVerticalScaling.Enabled = True
                  _numVerticalScaling.Minimum = i.Values.RangeValues.MinimumValue
                  _numVerticalScaling.Maximum = i.Values.RangeValues.MaximumValue
                  _numVerticalScaling.Increment = i.Values.RangeValues.Step
               End If

            Case WiaPropertyId.ScannerItemXPos ' XPos
               If (i.PropertyAttributes And WiaPropertyAttributesFlags.Write) = WiaPropertyAttributesFlags.Write Then
                  _numXPos.Enabled = True
                  _numXPos.Minimum = i.Values.RangeValues.MinimumValue
                  _numXPos.Maximum = i.Values.RangeValues.MaximumValue
                  _numXPos.Increment = i.Values.RangeValues.Step
               End If

            Case WiaPropertyId.ScannerItemYPos ' YPos
               If (i.PropertyAttributes And WiaPropertyAttributesFlags.Write) = WiaPropertyAttributesFlags.Write Then
                  _numYPos.Enabled = True
                  _numYPos.Minimum = i.Values.RangeValues.MinimumValue
                  _numYPos.Maximum = i.Values.RangeValues.MaximumValue
                  _numYPos.Increment = i.Values.RangeValues.Step
               End If

            Case WiaPropertyId.ScannerItemXExtent ' Width
               If (i.PropertyAttributes And WiaPropertyAttributesFlags.Write) = WiaPropertyAttributesFlags.Write Then
                  _numWidth.Enabled = True
                  _numWidth.Minimum = i.Values.RangeValues.MinimumValue
                  _numWidth.Maximum = i.Values.RangeValues.MaximumValue
                  _numWidth.Increment = i.Values.RangeValues.Step
               End If

            Case WiaPropertyId.ScannerItemYExtent ' Height
               If (i.PropertyAttributes And WiaPropertyAttributesFlags.Write) = WiaPropertyAttributesFlags.Write Then
                  _numHeight.Enabled = True
                  _numHeight.Minimum = i.Values.RangeValues.MinimumValue
                  _numHeight.Maximum = i.Values.RangeValues.MaximumValue
                  _numHeight.Increment = i.Values.RangeValues.Step
               End If

            Case WiaPropertyId.ItemFormat ' Format
               If (i.PropertyAttributes And WiaPropertyAttributesFlags.Write) = WiaPropertyAttributesFlags.Write Then
                  _cmbFormat.Enabled = True
               End If

               ' Fill the formats list.
               FillTransferFormatsList()

            Case WiaPropertyId.ItemCompression ' Compression
               If (i.PropertyAttributes And WiaPropertyAttributesFlags.Write) = WiaPropertyAttributesFlags.Write Then
                  _cmbCompression.Enabled = True
               End If

               ' Fill the compression list.
               HelperFunctions.FillComboWithValidValues(_cmbCompression, i)

            Case WiaPropertyId.ItemDatatype ' Image data type
               If (i.PropertyAttributes And WiaPropertyAttributesFlags.Write) = WiaPropertyAttributesFlags.Write Then
                  _cmbImageDataType.Enabled = True
               End If

               ' Fill the image data type list.
               HelperFunctions.FillComboWithValidValues(_cmbImageDataType, i)

            Case WiaPropertyId.ItemTymed ' Transfer mode
               ' These controls will be updated when we enumerate the WIA formats, since the TYMED
               ' is one of the formats enumeration callback parameters.

            Case WiaPropertyId.ScannerItemBrightness ' Brightness
               If (i.PropertyAttributes And WiaPropertyAttributesFlags.Write) = WiaPropertyAttributesFlags.Write Then
                  _numBrightness.Enabled = True
                  _numBrightness.Minimum = i.Values.RangeValues.MinimumValue
                  _numBrightness.Maximum = i.Values.RangeValues.MaximumValue
                  _numBrightness.Increment = i.Values.RangeValues.Step
               End If

               ' Set the brightness effect ranges.
               _lblBrightness.Text = String.Format("Brightness ({0} To {1})", i.Values.RangeValues.MinimumValue.ToString(), i.Values.RangeValues.MaximumValue.ToString())

            Case WiaPropertyId.ScannerItemContrast ' Contrast
               If (i.PropertyAttributes And WiaPropertyAttributesFlags.Write) = WiaPropertyAttributesFlags.Write Then
                  _numContrast.Enabled = True
                  _numContrast.Minimum = i.Values.RangeValues.MinimumValue
                  _numContrast.Maximum = i.Values.RangeValues.MaximumValue
                  _numContrast.Increment = i.Values.RangeValues.Step
               End If

               ' Set the contrast effect ranges.
               _lblContrast.Text = String.Format("Contrast ({0} To {1})", i.Values.RangeValues.MinimumValue.ToString(), i.Values.RangeValues.MaximumValue.ToString())
         End Select
      Next i
   End Sub

   Private Sub FillFormatsListWithEnumeratedFormats()
      If MainForm._formatsList.Count <= 0 Then
         Return
      End If

      _cmbFormat.Items.Clear()
      For Each i As MyFormat In MainForm._formatsList
         ' Enable the supported transfer mode radio button according to whether it's supported on not.
         Select Case i.TransferMode
            Case WiaTransferMode.Memory
               _rdMemoryMode.Enabled = True

            Case WiaTransferMode.File
               _rdFileMode.Enabled = True
         End Select

         ' Only add the formats that match the selected transfer mode (TYMED).
         If i.TransferMode = MainForm._wiaProperties.DataTransfer.TransferMode Then
            _cmbFormat.Items.Add(i.FormatName)
            _cmbFormat.SelectedIndex = 0
         End If
      Next i

      If _cmbFormat.Items.Count <= 0 Then
         _cmbFormat.Enabled = False
      Else
         _cmbFormat.Enabled = True
      End If
   End Sub

   Private Sub WiaPropertiesForm_FormClosed(ByVal sender As Object, ByVal e As FormClosedEventArgs) Handles MyBase.FormClosed
      MainForm._formatsList.Clear()
      MainForm._capabilitiesList.Clear()
   End Sub

   Private Sub _cbColored_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _cbColored.Click
#If (Not LEADTOOLS_V17_OR_LATER) Then
      MainForm._wiaSession.LongValue = CInt(WiaImageType.Color)
      MainForm._wiaSession.SetPropertyLong(MainForm._selectedWiaItem, Nothing, WiaPropertyId.ScannerItemCurIntent)
#Else
      MainForm._wiaSession.SetPropertyLong(MainForm._selectedWiaItem, Nothing, WiaPropertyId.ScannerItemCurIntent, CInt(WiaImageType.Color))
#End If '#if !LEADTOOLS_V17_OR_LATER
      GetWiaProperties()
   End Sub

   Private Sub _cbGrayscale_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _cbGrayscale.Click
#If (Not LEADTOOLS_V17_OR_LATER) Then
      MainForm._wiaSession.LongValue = CInt(WiaImageType.Grayscale)
      MainForm._wiaSession.SetPropertyLong(MainForm._selectedWiaItem, Nothing, WiaPropertyId.ScannerItemCurIntent)
#Else
      MainForm._wiaSession.SetPropertyLong(MainForm._selectedWiaItem, Nothing, WiaPropertyId.ScannerItemCurIntent, CInt(WiaImageType.Grayscale))
#End If '#if !LEADTOOLS_V17_OR_LATER
      GetWiaProperties()
   End Sub

   Private Sub _cbText_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _cbText.Click
#If (Not LEADTOOLS_V17_OR_LATER) Then
      MainForm._wiaSession.LongValue = CInt(WiaImageType.Text)
      MainForm._wiaSession.SetPropertyLong(MainForm._selectedWiaItem, Nothing, WiaPropertyId.ScannerItemCurIntent)
#Else
      MainForm._wiaSession.SetPropertyLong(MainForm._selectedWiaItem, Nothing, WiaPropertyId.ScannerItemCurIntent, CInt(WiaImageType.Text))
#End If '#if !LEADTOOLS_V17_OR_LATER
      GetWiaProperties()
   End Sub

   Private Sub _cbDuplex_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _cbDuplex.Click
      If MainForm._wiaVersion = WiaVersion.Version2 Then
         _cbAutoAdvance.Checked = False
      End If
      UpdateWiaPropertiesDlgControls()
   End Sub

   Private Sub _cbAutoAdvance_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _cbAutoAdvance.Click
      If MainForm._wiaVersion = WiaVersion.Version2 Then
         _cbDuplex.Checked = False
      End If
      UpdateWiaPropertiesDlgControls()
   End Sub

   Private Sub _rdMemoryMode_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _rdMemoryMode.Click
      Dim dataTransfer As WiaDataTransferProperties = MainForm._wiaProperties.DataTransfer
      dataTransfer.TransferMode = WiaTransferMode.Memory
      MainForm._wiaProperties.DataTransfer = dataTransfer

      ' Enable the enumerate formats event.
      AddHandler MainForm._wiaSession.EnumFormatsEvent, AddressOf _wiaSession_EnumFormatsEvent

      MainForm._formatsList.Clear()

      ' Enumerate the supported WIA formats and add them to the formats combo box.
      MainForm._wiaSession.EnumFormats(MainForm._selectedWiaItem, WiaEnumFormatsFlags.None)

      ' Disable the enumerate formats event.
      RemoveHandler MainForm._wiaSession.EnumFormatsEvent, AddressOf _wiaSession_EnumFormatsEvent

      FillFormatsListWithEnumeratedFormats()

      UpdateWiaPropertiesDlgControls()
   End Sub

   Private Sub _rdFileMode_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _rdFileMode.Click
      Dim dataTransfer As WiaDataTransferProperties = MainForm._wiaProperties.DataTransfer
      dataTransfer.TransferMode = WiaTransferMode.File
      MainForm._wiaProperties.DataTransfer = dataTransfer

      ' Enable the enumerate formats event.
      AddHandler MainForm._wiaSession.EnumFormatsEvent, AddressOf _wiaSession_EnumFormatsEvent

      MainForm._formatsList.Clear()

      ' Enumerate the supported WIA formats and add them to the formats combo box.
      MainForm._wiaSession.EnumFormats(MainForm._selectedWiaItem, WiaEnumFormatsFlags.None)

      ' Disable the enumerate formats event.
      RemoveHandler MainForm._wiaSession.EnumFormatsEvent, AddressOf _wiaSession_EnumFormatsEvent

      FillFormatsListWithEnumeratedFormats()

      UpdateWiaPropertiesDlgControls()
   End Sub

   Private Sub _btnOk_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnOk.Click
      SetWiaProperties(MainForm._selectedWiaItem)

      ' Update the file name extension for the szFileName member of the acquire options structure.
      HelperFunctions.GetFormatFilterAndExtension()

      MainForm._wiaAcquireOptions.FileName = Path.ChangeExtension(MainForm._wiaAcquireOptions.FileName, HelperFunctions.Extension)

      DialogResult = DialogResult.OK
   End Sub

   Private Sub _cmbHorizontalResolution_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _cmbHorizontalResolution.SelectedIndexChanged
      Try
         Dim ImageResProps As WiaImageResolutionProperties = MainForm._wiaProperties.ImageResolution
         Dim myItem As MyItemData = CType(_cmbHorizontalResolution.SelectedItem, MyItemData)

         Dim longValue As Integer = 0
#If (Not LEADTOOLS_V17_OR_LATER) Then
         MainForm._wiaSession.LongValue = myItem.ItemData
         MainForm._wiaSession.SetPropertyLong(MainForm._selectedWiaItem, Nothing, WiaPropertyId.ScannerItemXRes)
         MainForm._wiaSession.GetPropertyLong(MainForm._selectedWiaItem, Nothing, WiaPropertyId.ScannerItemXExtent)
         longValue = MainForm._wiaSession.LongValue
#Else
         MainForm._wiaSession.SetPropertyLong(MainForm._selectedWiaItem, Nothing, WiaPropertyId.ScannerItemXRes, myItem.ItemData)
         longValue = MainForm._wiaSession.GetPropertyLong(MainForm._selectedWiaItem, Nothing, WiaPropertyId.ScannerItemXExtent)
#End If '#if !LEADTOOLS_V17_OR_LATER

         ImageResProps.Width = longValue
         _numWidth.Maximum = longValue
         _numWidth.Value = longValue

         MainForm._wiaProperties.ImageResolution = ImageResProps
      Catch e1 As Exception
         ' Do nothing
      End Try
   End Sub

   Private Sub _cmbVerticalResolution_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _cmbVerticalResolution.SelectedIndexChanged
      Try
         Dim ImageResProps As WiaImageResolutionProperties = MainForm._wiaProperties.ImageResolution
         Dim myItem As MyItemData = CType(_cmbVerticalResolution.SelectedItem, MyItemData)

         Dim longValue As Integer = 0
#If (Not LEADTOOLS_V17_OR_LATER) Then
         MainForm._wiaSession.LongValue = myItem.ItemData
         MainForm._wiaSession.SetPropertyLong(MainForm._selectedWiaItem, Nothing, WiaPropertyId.ScannerItemYRes)
         MainForm._wiaSession.GetPropertyLong(MainForm._selectedWiaItem, Nothing, WiaPropertyId.ScannerItemYExtent)
         longValue = MainForm._wiaSession.LongValue
#Else
         MainForm._wiaSession.SetPropertyLong(MainForm._selectedWiaItem, Nothing, WiaPropertyId.ScannerItemYRes, myItem.ItemData)
         longValue = MainForm._wiaSession.GetPropertyLong(MainForm._selectedWiaItem, Nothing, WiaPropertyId.ScannerItemYExtent)
#End If '#if !LEADTOOLS_V17_OR_LATER

         ImageResProps.Height = longValue
         _numHeight.Maximum = longValue
         _numHeight.Value = longValue
         MainForm._wiaProperties.ImageResolution = ImageResProps
      Catch e1 As Exception
         ' Do nothing
      End Try
   End Sub

   Private Sub _numHorizontalResolution_Leave(ByVal sender As Object, ByVal e As EventArgs) Handles _numHorizontalResolution.Leave
      Try
         Dim ImageResProps As WiaImageResolutionProperties = MainForm._wiaProperties.ImageResolution

#If (Not LEADTOOLS_V17_OR_LATER) Then
         MainForm._wiaSession.LongValue = Convert.ToInt32(_numHorizontalResolution.Value)
         MainForm._wiaSession.SetPropertyLong(MainForm._selectedWiaItem, Nothing, WiaPropertyId.ScannerItemXRes)
#Else
         MainForm._wiaSession.SetPropertyLong(MainForm._selectedWiaItem, Nothing, WiaPropertyId.ScannerItemXRes, Convert.ToInt32(_numHorizontalResolution.Value))
#End If '#if !LEADTOOLS_V17_OR_LATER

         Dim longValue As Integer = 0
#If (Not LEADTOOLS_V17_OR_LATER) Then
         MainForm._wiaSession.GetPropertyLong(MainForm._selectedWiaItem, Nothing, WiaPropertyId.ScannerItemXExtent)
         longValue = MainForm._wiaSession.LongValue
#Else
         longValue = MainForm._wiaSession.GetPropertyLong(MainForm._selectedWiaItem, Nothing, WiaPropertyId.ScannerItemXExtent)
#End If '#if !LEADTOOLS_V17_OR_LATER
         ImageResProps.Width = longValue
         _numWidth.Maximum = longValue
         _numWidth.Value = longValue

         If System.Environment.OSVersion.Version.Major >= 6 Then ' VISTA or later
#If (Not LEADTOOLS_V17_OR_LATER) Then
            MainForm._wiaSession.GetPropertyLong(MainForm._selectedWiaItem, Nothing, WiaPropertyId.ScannerItemXScaling)
            longValue = MainForm._wiaSession.LongValue
#Else
            longValue = MainForm._wiaSession.GetPropertyLong(MainForm._selectedWiaItem, Nothing, WiaPropertyId.ScannerItemXScaling)
#End If '#if !LEADTOOLS_V17_OR_LATER

            ImageResProps.XScaling = longValue
            _numHorizontalScaling.Maximum = longValue
            _numHorizontalScaling.Value = longValue
         End If
         MainForm._wiaProperties.ImageResolution = ImageResProps
         UpdateWiaPropertiesDlgControls()
      Catch e1 As Exception
         ' Do nothing
      End Try
   End Sub

   Private Sub _numVerticalResolution_Leave(ByVal sender As Object, ByVal e As EventArgs) Handles _numVerticalResolution.Leave
      Try
         Dim ImageResProps As WiaImageResolutionProperties = MainForm._wiaProperties.ImageResolution

         Dim longValue As Integer = 0
#If (Not LEADTOOLS_V17_OR_LATER) Then
         MainForm._wiaSession.LongValue = Convert.ToInt32(_numVerticalResolution.Value)
         MainForm._wiaSession.SetPropertyLong(MainForm._selectedWiaItem, Nothing, WiaPropertyId.ScannerItemYRes)
         MainForm._wiaSession.GetPropertyLong(MainForm._selectedWiaItem, Nothing, WiaPropertyId.ScannerItemYExtent)
         longValue = MainForm._wiaSession.LongValue
#Else
         MainForm._wiaSession.SetPropertyLong(MainForm._selectedWiaItem, Nothing, WiaPropertyId.ScannerItemYRes, Convert.ToInt32(_numVerticalResolution.Value))
         longValue = MainForm._wiaSession.GetPropertyLong(MainForm._selectedWiaItem, Nothing, WiaPropertyId.ScannerItemYExtent)
#End If '#if !LEADTOOLS_V17_OR_LATER

         ImageResProps.Height = longValue
         _numHeight.Maximum = longValue
         _numHeight.Value = longValue

         If System.Environment.OSVersion.Version.Major >= 6 Then ' VISTA or later
#If (Not LEADTOOLS_V17_OR_LATER) Then
            MainForm._wiaSession.GetPropertyLong(MainForm._selectedWiaItem, Nothing, WiaPropertyId.ScannerItemYScaling)
            longValue = MainForm._wiaSession.LongValue
#Else
            longValue = MainForm._wiaSession.GetPropertyLong(MainForm._selectedWiaItem, Nothing, WiaPropertyId.ScannerItemYScaling)
#End If '#if !LEADTOOLS_V17_OR_LATER

            ImageResProps.YScaling = longValue
            _numVerticalScaling.Maximum = longValue
            _numVerticalScaling.Value = longValue
         End If
         MainForm._wiaProperties.ImageResolution = ImageResProps
         UpdateWiaPropertiesDlgControls()
      Catch e1 As Exception
         ' Do nothing
      End Try
   End Sub

   Private Sub _numHorizontalScaling_Leave(ByVal sender As Object, ByVal e As EventArgs) Handles _numHorizontalScaling.Leave
      Try
         Dim ImageResProps As WiaImageResolutionProperties = MainForm._wiaProperties.ImageResolution
         Dim longValue As Integer = 0
#If (Not LEADTOOLS_V17_OR_LATER) Then
         MainForm._wiaSession.LongValue = Convert.ToInt32(_numHorizontalScaling.Value)
         MainForm._wiaSession.SetPropertyLong(MainForm._selectedWiaItem, Nothing, WiaPropertyId.ScannerItemXScaling)
         MainForm._wiaSession.GetPropertyLong(MainForm._selectedWiaItem, Nothing, WiaPropertyId.ScannerItemXPos)
         longValue = MainForm._wiaSession.LongValue
#Else
         MainForm._wiaSession.SetPropertyLong(MainForm._selectedWiaItem, Nothing, WiaPropertyId.ScannerItemXScaling, Convert.ToInt32(_numHorizontalScaling.Value))
         longValue = MainForm._wiaSession.GetPropertyLong(MainForm._selectedWiaItem, Nothing, WiaPropertyId.ScannerItemXPos)
#End If '#if !LEADTOOLS_V17_OR_LATER

         ImageResProps.XPos = longValue
         _numXPos.Maximum = longValue
         _numXPos.Value = longValue

#If (Not LEADTOOLS_V17_OR_LATER) Then
         MainForm._wiaSession.GetPropertyLong(MainForm._selectedWiaItem, Nothing, WiaPropertyId.ScannerItemXExtent)
         longValue = MainForm._wiaSession.LongValue
#Else
         longValue = MainForm._wiaSession.GetPropertyLong(MainForm._selectedWiaItem, Nothing, WiaPropertyId.ScannerItemXExtent)
#End If '#if !LEADTOOLS_V17_OR_LATER

         ImageResProps.Width = longValue
         _numWidth.Maximum = longValue
         _numWidth.Value = longValue

#If (Not LEADTOOLS_V17_OR_LATER) Then
         MainForm._wiaSession.GetPropertyLong(MainForm._selectedWiaItem, Nothing, WiaPropertyId.ScannerItemXRes)
         longValue = MainForm._wiaSession.LongValue
#Else
         longValue = MainForm._wiaSession.GetPropertyLong(MainForm._selectedWiaItem, Nothing, WiaPropertyId.ScannerItemXRes)
#End If '#if !LEADTOOLS_V17_OR_LATER

         ImageResProps.HorizontalResolution = longValue
         _numHorizontalResolution.Maximum = longValue
         _numHorizontalResolution.Value = longValue
         MainForm._wiaProperties.ImageResolution = ImageResProps

         UpdateWiaPropertiesDlgControls()
      Catch e1 As Exception
         ' Do nothing
      End Try
   End Sub

   Private Sub _numVerticalScaling_Leave(ByVal sender As Object, ByVal e As EventArgs) Handles _numVerticalScaling.Leave
      Try
         Dim ImageResProps As WiaImageResolutionProperties = MainForm._wiaProperties.ImageResolution
         Dim longValue As Integer = 0
#If (Not LEADTOOLS_V17_OR_LATER) Then
         MainForm._wiaSession.LongValue = Convert.ToInt32(_numVerticalScaling.Value)
         MainForm._wiaSession.SetPropertyLong(MainForm._selectedWiaItem, Nothing, WiaPropertyId.ScannerItemYScaling)
         MainForm._wiaSession.GetPropertyLong(MainForm._selectedWiaItem, Nothing, WiaPropertyId.ScannerItemYPos)
         longValue = MainForm._wiaSession.LongValue
#Else
         MainForm._wiaSession.SetPropertyLong(MainForm._selectedWiaItem, Nothing, WiaPropertyId.ScannerItemYScaling, Convert.ToInt32(_numVerticalScaling.Value))
         longValue = MainForm._wiaSession.GetPropertyLong(MainForm._selectedWiaItem, Nothing, WiaPropertyId.ScannerItemYPos)
#End If '#if !LEADTOOLS_V17_OR_LATER

         ImageResProps.YPos = longValue
         _numYPos.Maximum = longValue
         _numYPos.Value = longValue

#If (Not LEADTOOLS_V17_OR_LATER) Then
         MainForm._wiaSession.GetPropertyLong(MainForm._selectedWiaItem, Nothing, WiaPropertyId.ScannerItemYExtent)
         longValue = MainForm._wiaSession.LongValue
#Else
         longValue = MainForm._wiaSession.GetPropertyLong(MainForm._selectedWiaItem, Nothing, WiaPropertyId.ScannerItemYExtent)
#End If '#if !LEADTOOLS_V17_OR_LATER

         ImageResProps.Height = longValue
         _numHeight.Maximum = longValue
         _numHeight.Value = longValue

#If (Not LEADTOOLS_V17_OR_LATER) Then
         MainForm._wiaSession.GetPropertyLong(MainForm._selectedWiaItem, Nothing, WiaPropertyId.ScannerItemYRes)
         longValue = MainForm._wiaSession.LongValue
#Else
         longValue = MainForm._wiaSession.GetPropertyLong(MainForm._selectedWiaItem, Nothing, WiaPropertyId.ScannerItemYRes)
#End If '#if !LEADTOOLS_V17_OR_LATER

         ImageResProps.VerticalResolution = longValue
         _numVerticalResolution.Maximum = longValue
         _numVerticalResolution.Value = longValue
         MainForm._wiaProperties.ImageResolution = ImageResProps

         UpdateWiaPropertiesDlgControls()
      Catch e1 As Exception
         ' Do nothing
      End Try
   End Sub

   Private Sub _numXPos_Leave(ByVal sender As Object, ByVal e As EventArgs) Handles _numXPos.Leave
      Try
         Dim ImageResProps As WiaImageResolutionProperties = MainForm._wiaProperties.ImageResolution
         Dim longValue As Integer = 0
#If (Not LEADTOOLS_V17_OR_LATER) Then
         MainForm._wiaSession.LongValue = Convert.ToInt32(_numXPos.Value)
         MainForm._wiaSession.SetPropertyLong(MainForm._selectedWiaItem, Nothing, WiaPropertyId.ScannerItemXPos)
         MainForm._wiaSession.GetPropertyLong(MainForm._selectedWiaItem, Nothing, WiaPropertyId.ScannerItemXExtent)
         longValue = MainForm._wiaSession.LongValue
#Else
         MainForm._wiaSession.SetPropertyLong(MainForm._selectedWiaItem, Nothing, WiaPropertyId.ScannerItemXPos, Convert.ToInt32(_numXPos.Value))
         longValue = MainForm._wiaSession.GetPropertyLong(MainForm._selectedWiaItem, Nothing, WiaPropertyId.ScannerItemXExtent)
#End If '#if !LEADTOOLS_V17_OR_LATER

         ImageResProps.Width = longValue
         _numWidth.Maximum = longValue
         _numWidth.Value = longValue
         MainForm._wiaProperties.ImageResolution = ImageResProps

         UpdateWiaPropertiesDlgControls()
      Catch e1 As Exception
         ' Do nothing
      End Try
   End Sub

   Private Sub _numYPos_Leave(ByVal sender As Object, ByVal e As EventArgs) Handles _numYPos.Leave
      Try
         Dim ImageResProps As WiaImageResolutionProperties = MainForm._wiaProperties.ImageResolution
         Dim longValue As Integer = 0
#If (Not LEADTOOLS_V17_OR_LATER) Then
         MainForm._wiaSession.LongValue = Convert.ToInt32(_numYPos.Value)
         MainForm._wiaSession.SetPropertyLong(MainForm._selectedWiaItem, Nothing, WiaPropertyId.ScannerItemYPos)
         MainForm._wiaSession.GetPropertyLong(MainForm._selectedWiaItem, Nothing, WiaPropertyId.ScannerItemYExtent)
         longValue = MainForm._wiaSession.LongValue
#Else
         MainForm._wiaSession.SetPropertyLong(MainForm._selectedWiaItem, Nothing, WiaPropertyId.ScannerItemYPos, Convert.ToInt32(_numYPos.Value))
         longValue = MainForm._wiaSession.GetPropertyLong(MainForm._selectedWiaItem, Nothing, WiaPropertyId.ScannerItemYExtent)
#End If '#if !LEADTOOLS_V17_OR_LATER

         ImageResProps.Height = longValue
         _numHeight.Maximum = longValue
         _numHeight.Value = longValue
         MainForm._wiaProperties.ImageResolution = ImageResProps

         UpdateWiaPropertiesDlgControls()
      Catch e1 As Exception
         ' Do nothing
      End Try
   End Sub

   Private Sub _num_Leave(ByVal sender As Object, ByVal e As EventArgs) Handles _numMaxPagesCount.Leave, _numHeight.Leave, _numWidth.Leave, _numContrast.Leave, _numBrightness.Leave
      UpdateWiaPropertiesDlgControls()
   End Sub
End Class
