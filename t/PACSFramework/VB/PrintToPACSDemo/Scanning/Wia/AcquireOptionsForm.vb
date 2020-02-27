' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports Leadtools.Wia

Namespace PrintToPACSDemo
   Public Partial Class AcquireOptionsForm : Inherits Form
	  Public Sub New()
		 InitializeComponent()
	  End Sub

	  Private Sub AcquireOptionsForm_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
		 InitializeAcquireOptionsDlg()
	  End Sub

	  Public Sub InitializeAcquireOptionsDlg()
		 ' if the WIA 2.0 version is selected and the Show UserInterface option is on
		 ' then in this case WIA 2.0 will only work as TYMED_FILE, so we need to set the 
		 ' transfer mode to TYMED_FILE
		 If FrmMain._wiaVersion = WiaVersion.Version2 AndAlso FrmMain._showUserInterface Then
			FrmMain._wiatransferMode = WiaTransferMode.File
		 Else
			' Get the transfer mode selected in the properties dialog and set it as the default mode.
			If FrmMain._wiaProperties.DataTransfer.TransferMode <> WiaTransferMode.None Then ' GetProperties() method already called.
			   FrmMain._wiatransferMode = FrmMain._wiaProperties.DataTransfer.TransferMode
			Else
			   FrmMain._wiatransferMode = WiaTransferMode.Memory
			End If
		 End If

		 If FrmMain._wiatransferMode = WiaTransferMode.Memory Then
			_rdMemoryMode.Checked = True
		 Else
			_rdFileMode.Checked = True
		 End If

		 If FrmMain._wiaVersion = WiaVersion.Version2 AndAlso FrmMain._showUserInterface Then
			_rdMemoryMode.Enabled = False
		 Else
			_rdMemoryMode.Enabled = True
		 End If

		 ' Set the file name (if available).
		 If (Not String.IsNullOrEmpty(FrmMain._wiaAcquireOptions.FileName)) Then
			_tbFileName.Text = FrmMain._wiaAcquireOptions.FileName
		 Else
			_tbFileName.Text = FrmMain._wiaAcquireOptions.FileName
		 End If

		 _cbSaveToOneFile.Checked = FrmMain._wiaAcquireOptions.SaveToOneFile
		 _cbOverwriteExisting.Checked = FrmMain._wiaAcquireOptions.OverwriteExisting
		 _cbAppendToFile.Checked = FrmMain._wiaAcquireOptions.Append
		 _cbEnableDoubleBuffer.Checked = FrmMain._wiaAcquireOptions.DoubleBuffer

		 _numMemoryBufferSize.Value = FrmMain._wiaAcquireOptions.MemoryBufferSize
		 UpdateDlgControls()
	  End Sub

	  Private Sub _btnBrowse_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnBrowse.Click
		 BrowseFile()
	  End Sub

	  Public Sub BrowseFile()
		 Dim filter As String = String.Empty
		 Dim extension As String = String.Empty

		 Dim dlg As SaveFileDialog = New SaveFileDialog()

		 HelperFunctions.GetFormatFilterAndExtension()

		 dlg.Filter = HelperFunctions.Filter
		 dlg.DefaultExt = HelperFunctions.Extension
		 dlg.Title = "Save File"
		 If dlg.ShowDialog(Me) = DialogResult.OK Then
			_tbFileName.Text = dlg.FileName
		 End If
	  End Sub

	  Public Sub UpdateDlgControls()
		 Dim bMemMode As Boolean = True

		 ' Enable/Disable the File Mode options
		 If _rdMemoryMode.Checked Then
			bMemMode = True
		 Else
			bMemMode = False
		 End If

		 ' Disable all the controls that are related to file transfer mode
		 EnableFileModeOptionsControls((Not bMemMode))

		 ' Enable the memory buffer size and double buffer controls.
		 _numMemoryBufferSize.Enabled = bMemMode
		 _cbEnableDoubleBuffer.Enabled = bMemMode

		 ' Check if the file name field or buffer size fields are empty then disable the "OK" button.
		 If (String.IsNullOrEmpty(_tbFileName.Text) AndAlso (bMemMode = False)) OrElse (String.IsNullOrEmpty(_tbFileName.Text)) OrElse (String.IsNullOrEmpty(_numMemoryBufferSize.Text)) Then
			_btnOk.Enabled = False
		 Else
			_btnOk.Enabled = True
		 End If
	  End Sub

	  Public Sub EnableFileModeOptionsControls(ByVal bEnable As Boolean)
		 _lblFileName.Enabled = bEnable
		 _tbFileName.Enabled = bEnable
		 _btnBrowse.Enabled = bEnable

		 If FrmMain._wiaVersion = WiaVersion.Version2 AndAlso FrmMain._showUserInterface Then
			_cbSaveToOneFile.Enabled = False
			_cbOverwriteExisting.Enabled = False
			_cbAppendToFile.Enabled = False
		 Else
			_cbSaveToOneFile.Enabled = bEnable
			_cbOverwriteExisting.Enabled = bEnable
			_cbAppendToFile.Enabled = bEnable

			' Enable the "Save To One File" and "Append To File" buttons if multi-page format selected.
			If FrmMain._wiaProperties.DataTransfer.Format = WiaFileFormats.Tiff OrElse FrmMain._wiaProperties.DataTransfer.Format = WiaFileFormats.Gif OrElse FrmMain._wiaProperties.DataTransfer.Format = WiaFileFormats.Ico OrElse FrmMain._wiaProperties.DataTransfer.Format = WiaFileFormats.Pdfa OrElse FrmMain._wiaProperties.DataTransfer.Format = WiaFileFormats.Rtf OrElse FrmMain._wiaProperties.DataTransfer.Format = WiaFileFormats.Txt OrElse FrmMain._wiaProperties.DataTransfer.Format = WiaFileFormats.Html Then
			   _cbSaveToOneFile.Enabled = True
			   _cbAppendToFile.Enabled = True
			Else
			   _cbSaveToOneFile.Checked = False
			   _cbAppendToFile.Checked = False
			   _cbSaveToOneFile.Enabled = False
			   _cbAppendToFile.Enabled = False
			End If
		 End If
	  End Sub

	  Public Sub SetWiaAcquireOptions()
		 ' Check for file mode or memory mode
		 If _rdMemoryMode.Checked Then
			FrmMain._wiatransferMode = WiaTransferMode.Memory
		 Else
			FrmMain._wiatransferMode = WiaTransferMode.File
		 End If

		 ' Check for the user specified file name
		 If FrmMain._wiatransferMode = WiaTransferMode.File Then
			FrmMain._wiaAcquireOptions.FileName = _tbFileName.Text

			' Check for the "Save To One File" option.
			If _cbSaveToOneFile.Checked Then
			   FrmMain._wiaAcquireOptions.SaveToOneFile = True
			Else
			   FrmMain._wiaAcquireOptions.SaveToOneFile = False
			End If

			' Check for the "Overwrite existing" option.
			If _cbOverwriteExisting.Checked Then
			   FrmMain._wiaAcquireOptions.OverwriteExisting = True
			Else
			   FrmMain._wiaAcquireOptions.OverwriteExisting = False
			End If

			' Check for the "Append To File" option.
			If _cbAppendToFile.Checked Then
			   FrmMain._wiaAcquireOptions.Append = True
			Else
			   FrmMain._wiaAcquireOptions.Append = False
			End If
		 End If

		 ' Get the memory buffer size
		 FrmMain._wiaAcquireOptions.MemoryBufferSize = System.Convert.ToInt32(_numMemoryBufferSize.Value)

		 ' Check for the "Enable Double Buffer" option.
		 If _cbEnableDoubleBuffer.Checked Then
			FrmMain._wiaAcquireOptions.DoubleBuffer = True
		 Else
			FrmMain._wiaAcquireOptions.DoubleBuffer = False
		 End If
	  End Sub

	  Private Sub _rdMemoryMode_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _rdMemoryMode.Click
		 UpdateDlgControls()
	  End Sub

	  Private Sub _rdFileMode_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _rdFileMode.Click
		 UpdateDlgControls()
	  End Sub

	  Private Sub _tbFileName_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _tbFileName.TextChanged
		 UpdateDlgControls()
	  End Sub

	  Private Sub _cbOverwriteExisting_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _cbOverwriteExisting.Click
		 _cbAppendToFile.Checked = False
	  End Sub

	  Private Sub _cbAppendToFile_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _cbAppendToFile.Click
		 _cbOverwriteExisting.Checked = False
	  End Sub

	  Private Sub _btnOk_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnOk.Click
		 SetWiaAcquireOptions()
		 DialogResult = DialogResult.OK
	  End Sub

	  Private Sub _numMemoryBufferSize_Leave(ByVal sender As Object, ByVal e As EventArgs) Handles _numMemoryBufferSize.Leave
		 UpdateDlgControls()
	  End Sub
   End Class
End Namespace
