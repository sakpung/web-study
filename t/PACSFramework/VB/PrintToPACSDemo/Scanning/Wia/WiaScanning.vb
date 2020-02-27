' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports Leadtools.Wia
Imports Leadtools.Codecs
Imports System.Collections
Imports System.Windows.Forms
Imports System.IO

Namespace PrintToPACSDemo
   Partial Public Class FrmMain
      Public Shared _wiaSession As WiaSession
      Public Shared _wiaAcquireOptions As WiaAcquireOptions = WiaAcquireOptions.Empty
      Public Shared _wiaProperties As WiaProperties = WiaProperties.Empty
      Public Shared _wiaVersion As WiaVersion
      Public Shared _wiatransferMode As WiaTransferMode
      Public Shared _wiaerrorList As ArrayList
      Public Shared _enumeratedItemsList As ArrayList
      Public Shared _capabilitiesList As ArrayList
      Public Shared _formatsList As ArrayList
      Public Shared _flagValuesStrings As ArrayList
      Public Shared _selectedItemIndex As Integer = -1
      Public Shared _forCapabilities As Boolean = False
      Public Shared _showUserInterface As Boolean = True
      Public Shared _acquireFromFeeder As Boolean = True
      Public _progressDlg As ProgressForm
      Private _wiaAvailable As Boolean = False
      Private _wiaSourceSelected As Boolean = False
      Private _wiaAcquiring As Boolean = False
      Private _sourceItem As Object = Nothing
      Private wiaImageCollection As ListImageBox.ImageCollection


      Private Sub InitializeWia()
         If _mySettings._settings.wiaVersion = 0 Then
            Return
         End If

         _wiaVersion = CType(_mySettings._settings.wiaVersion, WiaVersion)
         _wiaAvailable = WiaSession.IsAvailable(_wiaVersion)

         If _wiaAvailable Then
            _wiaSession = New WiaSession()
            _wiaSession.Startup(_wiaVersion)
            _miWiaSelectSource.Enabled = True

            ' Set the default acquire path for file transfer to My Documents folder.
            Dim myDocumentsPath As String
            HelperFunctions.GetFormatFilterAndExtension()

            myDocumentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
            _wiaAcquireOptions.FileName = String.Format("{0}{1}{2}", myDocumentsPath, "\WiaTest.", HelperFunctions.Extension)

            If _wiaProperties.DataTransfer.TransferMode = WiaTransferMode.None Then ' GetProperties() method not called yet.
               _wiatransferMode = WiaTransferMode.Memory
            Else
               _wiatransferMode = _wiaProperties.DataTransfer.TransferMode
            End If

            AddHandler _wiaSession.AcquireEvent, AddressOf _wiaSession_AcquireEvent
         Else
            _miWiaSelectSource.Enabled = False
         End If

         _wiaerrorList = New ArrayList()
         _enumeratedItemsList = New ArrayList()
         _capabilitiesList = New ArrayList()
         _formatsList = New ArrayList()
         _flagValuesStrings = New ArrayList()

         _wiaSourceSelected = Not _mySettings._settings.wiaSelectedDevice Is Nothing
         If _wiaSourceSelected Then
            Try
               _wiaSession.SelectDevice(_mySettings._settings.wiaSelectedDevice)
            Catch
               _wiaSourceSelected = False
            End Try
         End If

      End Sub

      Private Sub _miWia_DropDownOpening(ByVal sender As Object, ByVal e As EventArgs) Handles _miWia.DropDownOpening
         If _wiaAvailable AndAlso _wiaSourceSelected AndAlso (Not _wiaAcquiring) Then
            _miWiaAcquire.Enabled = True
            _miWiaOptions.Enabled = True
            _miWiaCapabilities.Enabled = True
            _miWiaProperties.Enabled = True
         Else
            If _wiaAcquiring OrElse _mySettings._settings.wiaVersion = 0 Then
               _miWiaSelectSource.Enabled = False
            Else
               _miWiaSelectSource.Enabled = True
            End If

            _miWiaOptions.Enabled = False
            _miWiaCapabilities.Enabled = False
            _miWiaProperties.Enabled = False
            _miWiaAcquire.Enabled = False
         End If
      End Sub

      Private Sub _miWiaVersion_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _miWiaVersion.Click
         Dim bTopMost As Boolean = logWindow.TopMost
         logWindow.TopMost = False
         Try
            Using WiaVersionDlg As WiaVersionForm = New WiaVersionForm()
               If WiaVersionDlg.ShowDialog() = DialogResult.OK Then
                  _wiaVersion = WiaVersionDlg._selectedWiaVersion
                  _mySettings._settings.wiaVersion = CInt(_wiaVersion)
                  _mySettings.Save()
                  InitializeWia()
               End If
            End Using
         Catch
         End Try
         logWindow.TopMost = bTopMost
      End Sub

      Private Sub _wiaSession_AcquireEvent(ByVal sender As Object, ByVal e As WiaAcquireEventArgs)
         Dim strInfoMsg As String

         ' Update the progress bar with the received percent value;
         If _progressDlg.Visible Then
            ' Show the user some information about the file we are acquiring 
            ' to (if the user chooses file transfer).

            If (e.Flags And WiaAcquiredPageFlags.StartOfPage) = WiaAcquiredPageFlags.StartOfPage Then
               If _wiatransferMode = WiaTransferMode.File Then
                  strInfoMsg = String.Format("Transferring to file:" & Constants.vbLf + Constants.vbLf & "{0}", e.FileName)
                  _progressDlg.InformationString = strInfoMsg
               End If
            End If

            If ((e.Flags And WiaAcquiredPageFlags.StartOfPage) = WiaAcquiredPageFlags.StartOfPage) AndAlso ((e.Flags And WiaAcquiredPageFlags.EndOfPage) <> WiaAcquiredPageFlags.EndOfPage) Then
               _progressDlg.Percent = 0
            Else
               _progressDlg.Percent = CInt(e.Percent)
            End If

            Application.DoEvents()

            If _progressDlg.Abort Then
               e.Cancel = True
            End If
         End If

         If _wiatransferMode <> WiaTransferMode.File Then
            If Not e.Image Is Nothing Then
               Dim page As Page = New Page()
               page.DeleteOnDispose = False
               Dim strTemp As String = Path.GetTempFileName()
               _codec.Save(e.Image, strTemp, Leadtools.RasterImageFormat.Tif, 0)
               page.FilePath = strTemp
               wiaImageCollection.Images.Add(New ListImageBox.ImageItem(_codec.Load(strTemp), wiaImageCollection, page))
               e.Image.Dispose()
               Application.DoEvents()
            End If
         End If
      End Sub

      Private Sub _miWiaOptions_DropDownOpening(ByVal sender As Object, ByVal e As EventArgs) Handles _miWiaOptions.DropDownOpening
         If _wiaAvailable AndAlso _wiaSourceSelected AndAlso (Not _wiaAcquiring) Then
            _miOptionsAcquireOptions.Enabled = True
            _miOptionsShowUI.Enabled = True
         Else
            _miOptionsAcquireOptions.Enabled = False
            _miOptionsShowUI.Enabled = False
         End If

         _miOptionsShowUI.Checked = _showUserInterface
      End Sub

      Private Sub _miWiaCapabilities_DropDownOpening(ByVal sender As Object, ByVal e As EventArgs) Handles _miWiaCapabilities.DropDownOpening
         If _wiaAvailable AndAlso _wiaSourceSelected AndAlso (Not _wiaAcquiring) Then
            _miCapabilitiesShowCapabilities.Enabled = True
            _miCapabilitiesShowFormats.Enabled = True
         Else
            _miCapabilitiesShowCapabilities.Enabled = False
            _miCapabilitiesShowFormats.Enabled = False
         End If
      End Sub

      Private Sub _miWiaProperties_DropDownOpening(ByVal sender As Object, ByVal e As EventArgs) Handles _miWiaProperties.DropDownOpening
         If _wiaAvailable AndAlso _wiaSourceSelected AndAlso (Not _wiaAcquiring) Then
            _miPropertiesWiaProperties.Enabled = True
            If _wiaerrorList.Count > 0 Then
               _miPropertiesShowErrors.Enabled = True
            Else
               _miPropertiesShowErrors.Enabled = False
            End If
         Else
            _miPropertiesWiaProperties.Enabled = False
            _miPropertiesShowErrors.Enabled = False
         End If
      End Sub

      Private Sub _miWiaSelectSource_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _miWiaSelectSource.Click
         Dim bTopMost As Boolean = logWindow.TopMost
         logWindow.TopMost = False
         Try

#If LEADTOOLS_V19_OR_LATER Then
            Dim res As DialogResult = _wiaSession.SelectDeviceDlg(Me.Handle, WiaDeviceType.Default, WiaSelectSourceFlags.NoDefault)
#Else
            Dim res As DialogResult = _wiaSession.SelectDeviceDlg(Me, WiaDeviceType.Default, WiaSelectSourceFlags.NoDefault)
#End If
            If res = DialogResult.OK Then
               _mySettings._settings.wiaSelectedDevice = _wiaSession.GetSelectedDevice()
               _wiaSourceSelected = True
               _mySettings.Save()
            End If
         Catch ex As Exception
            _wiaSourceSelected = False
            Messager.ShowError(Me, ex)
         End Try
         logWindow.TopMost = bTopMost
      End Sub

      Private Sub _miWiaAcquire_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _miWiaAcquire.Click
         Dim bTopMost As Boolean = logWindow.TopMost
         logWindow.TopMost = False
         Dim flags As WiaAcquireFlags
         Dim showProgress As Boolean = True

         _progressDlg = New ProgressForm("Transferring...", "", 100)

         _wiaAcquiring = True

         flags = WiaAcquireFlags.UseCommonUI
         If _showUserInterface Then
            flags = flags Or WiaAcquireFlags.ShowUserInterface
         Else
            ' Check if the selected device is scanner and that it has multiple sources (Feeder & Flatbed)
            ' then show the select source dialog box.
            If SelectAcquireSource() <> DialogResult.OK Then
               _wiaAcquiring = False
               logWindow.TopMost = bTopMost
               Return
            End If
         End If

         If _showUserInterface Then
            If _wiaVersion = WiaVersion.Version1 Then
               showProgress = True
            Else
               showProgress = False
            End If
         Else
            showProgress = True
         End If

         If showProgress Then
            ' Show the progress dialog.
            _progressDlg.Show(Me)
         End If

         Try
            _wiaSession.AcquireOptions = _wiaAcquireOptions

            If _wiaProperties.DataTransfer.TransferMode = WiaTransferMode.None Then ' GetProperties() method not called yet.
               _wiatransferMode = WiaTransferMode.Memory
            Else
               _wiatransferMode = _wiaProperties.DataTransfer.TransferMode
            End If

            ' Disable the minimize and maximize buttons.
            Me.MinimizeBox = False
            Me.MaximizeBox = False

            wiaImageCollection = New ListImageBox.ImageCollection("WIA Scanned")
#If LEADTOOLS_V19_OR_LATER Then
            _wiaSession.Acquire(Me.Handle, _sourceItem, flags)
#Else
            _wiaSession.Acquire(Me, _sourceItem, flags)
#End If
            ' Enable back the minimize and maximize buttons.
            Me.MinimizeBox = True
            Me.MaximizeBox = True

            If _progressDlg.Visible Then
               If (Not _progressDlg.Abort) Then
                  _progressDlg.Dispose()
               End If
            End If

            If _enumeratedItemsList.Count > 0 Then
               _enumeratedItemsList.Clear()
            End If
            If Not _sourceItem Is Nothing Then
               _sourceItem = Nothing
            End If

            If _wiaSession.FilesCount > 0 Then ' This property indicates how many files where saved when the transfer mode is File mode.
               Dim strMsg As String = "Acquired page(s) were saved to:" & Constants.vbLf + Constants.vbLf
               If _wiaSession.FilesPaths.Count > 0 Then
                  Dim i As Integer = 0
                  Do While i < _wiaSession.FilesPaths.Count
                     Dim strTemp As String = String.Format("{0}" & Constants.vbLf, _wiaSession.FilesPaths(i))
                     strMsg &= strTemp
                     i += 1
                  Loop
                  MessageBox.Show(Me, strMsg, "File Transfer", MessageBoxButtons.OK, MessageBoxIcon.Information)
               End If
            End If

            _wiaAcquiring = False
         Catch ex As Exception
            ' Enable back the minimize and maximize buttons.
            Me.MinimizeBox = True
            Me.MaximizeBox = True

            _wiaAcquiring = False
            If _progressDlg.Visible Then
               If (Not _progressDlg.Abort) Then
                  _progressDlg.Dispose()
               End If
            End If

            Messager.ShowError(Me, ex)
         End Try
         If wiaImageCollection.Images.Count > 0 Then
            _lstBoxPages.AddImageCollection(wiaImageCollection)
         End If
         logWindow.TopMost = bTopMost
      End Sub

      Private Function SelectAcquireSource() As DialogResult
         If _wiaSession.SelectedDeviceType = WiaDeviceType.Scanner Then
            Dim rootItem As Object = _wiaSession.GetRootItem(Nothing)
            If _wiaVersion = WiaVersion.Version1 Then
               Dim longValue As Integer = _wiaSession.GetPropertyLong(rootItem, Nothing, WiaPropertyId.ScannerDeviceDocumentHandlingCapabilities)

               If ((longValue And CInt(WiaDocumentHandlingCapabilitiesFlags.Feeder)) = CInt(WiaDocumentHandlingCapabilitiesFlags.Feeder)) AndAlso ((longValue And CInt(WiaDocumentHandlingCapabilitiesFlags.Flatbed)) = CInt(WiaDocumentHandlingCapabilitiesFlags.Flatbed)) Then ' scanner with multiple sources.
                  Using AcquireSourceDlg As AcquireSourceForm = New AcquireSourceForm()
                     If AcquireSourceDlg.ShowDialog() <> DialogResult.OK Then
                        Return DialogResult.Cancel
                     End If
                  End Using

                  If _acquireFromFeeder Then
                     longValue = CInt(WiaScanningModeFlags.Feeder)
                  Else
                     longValue = CInt(WiaScanningModeFlags.Flatbed)
                  End If

                  _wiaSession.SetPropertyLong(rootItem, Nothing, WiaPropertyId.ScannerDeviceDocumentHandlingSelect, longValue)
               End If
            Else
               ' Enable the enumerate items event.
               AddHandler _wiaSession.EnumItemsEvent, AddressOf _wiaSession_EnumItemsEvent

               _wiaSession.EnumChildItems(rootItem)

               ' Disable the enumerate items event.
               RemoveHandler _wiaSession.EnumItemsEvent, AddressOf _wiaSession_EnumItemsEvent

               If _enumeratedItemsList.Count > 1 Then ' scanner with multiple sources.
                  Using AcquireSourceDlg As AcquireSourceForm = New AcquireSourceForm()
                     If AcquireSourceDlg.ShowDialog() <> DialogResult.OK Then
                        _enumeratedItemsList.Clear()
                        Return DialogResult.Cancel
                     End If
                  End Using

                  If _acquireFromFeeder Then
                     For Each item As Object In _enumeratedItemsList
                        Dim guidCategory As Guid = FrmMain._wiaSession.GetPropertyGuid(item, Nothing, WiaPropertyId.ItemCategory)

                        Dim guidValue As Guid = WiaSession.GetCategoryGuid(WiaCategories.Feeder)
                        If guidValue = guidCategory Then
                           _sourceItem = item
                           Exit For
                        End If
                        guidValue = WiaSession.GetCategoryGuid(WiaCategories.FeederBack)
                        If guidValue = guidCategory Then
                           _sourceItem = item
                           Exit For
                        End If
                        guidValue = WiaSession.GetCategoryGuid(WiaCategories.FeederFront)
                        If guidValue = guidCategory Then
                           _sourceItem = item
                           Exit For
                        End If
                     Next item
                  Else
                     For Each item As Object In _enumeratedItemsList
                        Dim guidCategory As Guid = FrmMain._wiaSession.GetPropertyGuid(item, Nothing, WiaPropertyId.ItemCategory)

                        Dim guidValue As Guid = WiaSession.GetCategoryGuid(WiaCategories.Flatbed)
                        If guidValue = guidCategory Then
                           _sourceItem = item
                           Exit For
                        End If
                     Next item
                  End If

                  If _enumeratedItemsList.Count > 0 Then
                     _enumeratedItemsList.Clear()
                  End If
               End If
            End If
         End If

         Return DialogResult.OK
      End Function


      Private Sub FinilizeWia()
         If Not _wiaSession Is Nothing Then
            _wiaSession.Shutdown()
         End If
      End Sub

      Private Sub _wiaSession_EnumItemsEvent(ByVal sender As Object, ByVal e As WiaEnumItemsEventArgs)
         _enumeratedItemsList.Add(e.Item)
      End Sub

      Private Sub _miOptionsAcquireOptions_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _miOptionsAcquireOptions.Click
         Dim bTopMost As Boolean = logWindow.TopMost
         logWindow.TopMost = False
         Using AcquireOptionsDlg As AcquireOptionsForm = New AcquireOptionsForm()
            AcquireOptionsDlg.ShowDialog(Me)
         End Using
         logWindow.TopMost = bTopMost
      End Sub

      Private Sub _miOptionsShowUI_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _miOptionsShowUI.Click
         _showUserInterface = Not _showUserInterface
      End Sub

      Private Sub _miCapabilitiesShowCapabilities_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _miCapabilitiesShowCapabilities.Click
         Dim bTopMost As Boolean = logWindow.TopMost
         logWindow.TopMost = False
         _forCapabilities = True
         Using DeviceItemsDlg As WiaDeviceItemsForm = New WiaDeviceItemsForm()
            If DeviceItemsDlg.ShowDialog(Me) = DialogResult.OK Then
               Using SupportedCapsDlg As SupportedCapabilitiesForm = New SupportedCapabilitiesForm()
                  SupportedCapsDlg.ShowDialog(Me)
               End Using
            End If
         End Using
         logWindow.TopMost = bTopMost
      End Sub

      Private Sub _miCapabilitiesShowFormats_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _miCapabilitiesShowFormats.Click
         Dim bTopMost As Boolean = logWindow.TopMost
         logWindow.TopMost = False
         _forCapabilities = True
         Using DeviceItemsDlg As WiaDeviceItemsForm = New WiaDeviceItemsForm()
            If DeviceItemsDlg.ShowDialog(Me) = DialogResult.OK Then
               Using SupportedFormatsDlg As SupportedFormatsForm = New SupportedFormatsForm()
                  SupportedFormatsDlg.ShowDialog(Me)
               End Using
            End If
         End Using
         logWindow.TopMost = bTopMost
      End Sub

      Private Sub _miPropertiesWiaProperties_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _miPropertiesWiaProperties.Click
         Dim bTopMost As Boolean = logWindow.TopMost
         logWindow.TopMost = False
         _forCapabilities = False
         Using DeviceItemsDlg As WiaDeviceItemsForm = New WiaDeviceItemsForm()
            If DeviceItemsDlg.ShowDialog(Me) = DialogResult.OK Then
               Using PropertiesDlg As WiaPropertiesForm = New WiaPropertiesForm()
                  If PropertiesDlg.ShowDialog(Me) = DialogResult.OK Then
                     If _wiaerrorList.Count > 0 Then
                        Using ErrorsDlg As WiaPropertiesErrorsForm = New WiaPropertiesErrorsForm()
                           ErrorsDlg.ShowDialog(Me)
                        End Using
                     End If
                  End If
               End Using
            End If
         End Using
         logWindow.TopMost = bTopMost
      End Sub

      Private Sub _miPropertiesShowErrors_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _miPropertiesShowErrors.Click
         Dim bTopMost As Boolean = logWindow.TopMost
         logWindow.TopMost = False
         Using ErrorsDlg As WiaPropertiesErrorsForm = New WiaPropertiesErrorsForm()
            ErrorsDlg.ShowDialog(Me)
         End Using
         logWindow.TopMost = bTopMost
      End Sub

   End Class
End Namespace
