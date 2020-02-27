' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************

Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports Leadtools.Demos
Imports System.IO
Imports Leadtools
Imports Leadtools.Twain
Imports Leadtools.Codecs
Imports Leadtools.Forms.Auto
Imports Leadtools.Forms.Common

Imports System

Partial Public Class MasterFormsWizard
   Inherits Form
   Public Sub New()
      InitializeComponent()
   End Sub
   Private scannedImage As RasterImage = Nothing
   Private twainSession As TwainSession = Nothing

   <STAThread()> _
   Shared Sub Main()
      If Not Support.SetLicense() Then
         Return
      End If

      Dim bLocked As [Boolean] = RasterSupport.IsLocked(RasterSupportType.Forms)
      If bLocked Then
         MessageBox.Show("Forms support must be unlocked for this demo!", "Support Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
      End If

      Dim bOCRLocked As [Boolean] = RasterSupport.IsLocked(RasterSupportType.OcrLEAD) And RasterSupport.IsLocked(RasterSupportType.OcrOmniPage)
      If bOCRLocked Then
         MessageBox.Show("OCR support must be unlocked for this demo!", "Support Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
      End If

      If bLocked Or bOCRLocked Then
         Return
      End If

      Application.EnableVisualStyles()
      Application.SetCompatibleTextRenderingDefault(False)
      Application.Run(New MasterFormsWizard())
   End Sub

   Private Sub MasterFormsWizard_Load(sender As Object, e As EventArgs) Handles Me.Load
      _tbMain.Appearance = TabAppearance.FlatButtons
      _tbMain.ItemSize = New Size(0, 1)
      _tbMain.SizeMode = TabSizeMode.Fixed

      If [String].IsNullOrEmpty(Settings.[Default].MasterFormsPath) Then
         _txtMasterFormsPath.Text = DemosGlobal.ImagesFolder + "\" + "Forms\MasterForm Sets"
         _txtPagePath.Text = DemosGlobal.ImagesFolder + "\" + "Forms\MasterForm Sets"
         _txtMasterFormsDirectory.Text = DemosGlobal.ImagesFolder + "\" + "Forms\MasterForm Sets"
      Else
         _txtMasterFormsPath.Text = Settings.[Default].MasterFormsPath
         _txtPagePath.Text = Settings.[Default].MasterFormsPath
         _txtMasterFormsDirectory.Text = Settings.[Default].MasterFormsPath
      End If

      _txtMasterFormsName.Text = "NewMasterForm"
   End Sub

   Private Sub _lblLink_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles _lblLink.LinkClicked
      System.Diagnostics.Process.Start("https://www.leadtools.com/videos/playvideo.asp?id=30")
   End Sub

   Private Sub _btnCancel_Click(sender As Object, e As EventArgs)
      If MessageBox.Show("Are you sure you want to exit?", "Cancel", MessageBoxButtons.YesNo) = System.Windows.Forms.DialogResult.Yes Then
         Application.[Exit]()
      End If
   End Sub

   Private Sub _btnNext_Click(sender As Object, e As EventArgs) Handles _btnNext.Click
      If _rdLoad.Checked Then
         _tbMain.SelectedTab = _tbMain.TabPages("_tbLoad")
      Else
         _tbMain.SelectedTab = _tbMain.TabPages("_tbCreate")
      End If
   End Sub

   Private Sub _btnNextAbout_Click(sender As Object, e As EventArgs) Handles _btnNextAbout.Click
      _tbMain.SelectedTab = _tbMain.TabPages("_tbOptions")
   End Sub

   Private Sub _btnPrevOptions_Click(sender As Object, e As EventArgs) Handles _btnPrevOptions.Click
      _tbMain.SelectedTab = _tbMain.TabPages("_tbAboutDemo")
   End Sub

   Private Sub _btnFinish_Click(sender As Object, e As EventArgs) Handles _btnFinishLoad.Click
      If Not Directory.Exists(_txtMasterFormsPath.Text) Then
         MessageBox.Show("Please select valid folder")
         _txtMasterFormsPath.Focus()
         Return
      End If

      Dim infoDlg As New InformationDlg()
      If infoDlg.ShouldShow() Then
         infoDlg.ShowDialog()
      End If

      Dim frm As New MainForm(_txtMasterFormsPath.Text)
      Me.Hide()
      frm.Show()
   End Sub

   Private Sub _btnBrowse_Click(sender As Object, e As EventArgs) Handles _btnBrowseMaster.Click
      Using browseDlg As New FolderBrowserDialogEx()
         browseDlg.ShowNewFolderButton = False
         browseDlg.ShowEditBox = True
         browseDlg.ShowFullPathInEditBox = True
         browseDlg.ShowNewFolderButton = False
         browseDlg.Description = "Select Master Forms Path"
         browseDlg.RootFolder = Environment.SpecialFolder.MyComputer
         browseDlg.SelectedPath = _txtMasterFormsPath.Text
         If browseDlg.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            _txtMasterFormsPath.Text = browseDlg.SelectedPath
         End If
      End Using
   End Sub

   Private Sub _btnBrowsePage_Click(sender As Object, e As EventArgs) Handles _btnBrowsePage.Click
      Using dlg As New OpenFileDialog()
         dlg.CheckFileExists = True
         If [String].IsNullOrEmpty(Settings.[Default].MasterFormsPath) Then
            dlg.InitialDirectory = DemosGlobal.ImagesFolder + "\" + "Forms\MasterForm Sets"
         Else
            dlg.InitialDirectory = Settings.[Default].MasterFormsPath
         End If

         If dlg.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            _txtPagePath.Text = dlg.FileName
         End If
      End Using
   End Sub

   Private Sub UpdateControls()
      _txtPagePath.Visible = _rdFromDisk.Checked
      _btnBrowsePage.Visible = _rdFromDisk.Checked
      _lblImagePath.Visible = _rdFromDisk.Checked
      _btnAcquirePage.Visible = _rdFromScanner.Checked
   End Sub

   Private Sub _rdFromDisk_CheckedChanged(sender As Object, e As EventArgs) Handles _rdFromDisk.CheckedChanged
      UpdateControls()
   End Sub

   Private Sub _rdFromScanner_CheckedChanged(sender As Object, e As EventArgs) Handles _rdFromScanner.CheckedChanged
      UpdateControls()
   End Sub

   Private Sub _btnNextCreate_Click(sender As Object, e As EventArgs) Handles _btnNextCreate.Click
      If [String].IsNullOrEmpty(_txtMasterFormsName.Text) Then
         MessageBox.Show("Master forms name can not be empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
         _txtMasterFormsName.Focus()
         Return
      End If

      If [String].IsNullOrEmpty(_txtMasterFormsDirectory.Text) Then
         MessageBox.Show("Please select a valid master forms directory", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
         _txtMasterFormsDirectory.Focus()
         Return
      End If

      If Not Directory.Exists(_txtMasterFormsDirectory.Text) Then
         Try
            Directory.CreateDirectory(_txtMasterFormsDirectory.Text)
         Catch exp As Exception
            Messager.ShowError(Me, exp)
            _txtMasterFormsDirectory.Focus()
            Return
         End Try
      End If

      If Not IsFormsNameValid() Then
         _txtMasterFormsName.Focus()
         Return
      End If

      _tbMain.SelectedTab = _tbMain.TabPages("_tbAddPage")
   End Sub
   Private Function IsFormsNameValid() As Boolean
      Dim parentCategory As IMasterFormsCategory = Nothing

      Dim workingRepository As New DiskMasterFormsRepository(New RasterCodecs(), _txtMasterFormsDirectory.Text)
      parentCategory = workingRepository.RootCategory

      'Build array of current form names
      Dim existingForms As String() = New String(parentCategory.MasterForms.Count - 1) {}
      For i As Integer = 0 To parentCategory.MasterForms.Count - 1
         existingForms(i) = parentCategory.MasterForms(i).Name
      Next

      For Each existingForm As String In existingForms
         If existingForm.ToUpper() = _txtMasterFormsName.Text.Trim().ToUpper() Then
            MessageBox.Show("That Master Forms already exist", "Error")
            Return False
         End If
      Next
      Return True
   End Function

   Private Sub _btnAcquirePage_Click(sender As Object, e As EventArgs) Handles _btnAcquirePage.Click
      If scannedImage IsNot Nothing Then
         scannedImage.Dispose()
         scannedImage = Nothing
      End If

      Try
         Messager.Show(Me, "For best results, scan at 150DPI (or higher) and 1 bits per pixel", MessageBoxIcon.Information, MessageBoxButtons.OK)
         StartupTwain()

         If (Not DemosGlobal.CheckKnown3rdPartyTwainIssues(Me, twainSession.SelectedSourceName())) Then
            Return
         End If

         If twainSession.SelectSource([String].Empty) = DialogResult.OK Then
            twainSession.Acquire(TwainUserInterfaceFlags.Show)
         End If

         If twainSession IsNot Nothing Then
            twainSession.Shutdown()
         End If
      Catch exp As Exception
         Messager.ShowError(Me, exp)
      End Try
   End Sub

   Private Sub StartupTwain()
      Try
         twainSession = New TwainSession()
         If twainSession.IsAvailable(Me.Handle) Then
            twainSession.Startup(Me.Handle, "LEAD Technologies, Inc.", "LEAD Test Applications", "Version 1.0", "TWAIN Test Application", TwainStartupFlags.None)
            AddHandler twainSession.AcquirePage, AddressOf twainSession_AcquirePage
         End If
      Catch ex As TwainException
         If ex.Code = TwainExceptionCode.InvalidDll Then
            twainSession = Nothing
            Messager.ShowError(Me, "You have an old version of TWAINDSM.DLL. Please download latest version of this DLL from www.twain.org")
         Else
            twainSession = Nothing
            Messager.ShowError(Me, ex)
         End If
      Catch ex As Exception
         Messager.ShowError(Me, ex)
         twainSession = Nothing
      End Try
   End Sub

   Private Sub twainSession_AcquirePage(sender As Object, e As TwainAcquirePageEventArgs)
      If scannedImage Is Nothing Then
         scannedImage = e.Image.Clone()
      Else
         scannedImage.AddPage(e.Image.Clone())
      End If
   End Sub

   Private Sub _btnFinishCreate_Click(sender As Object, e As EventArgs) Handles _btnFinishCreate.Click
      Try
         If _rdFromDisk.Checked Then
            Using codecs As New RasterCodecs()
               codecs.Options.Load.Resolution = 300
               codecs.Options.RasterizeDocument.Load.Resolution = 300
               scannedImage = codecs.Load(_txtPagePath.Text)
            End Using
         End If

         If scannedImage Is Nothing Then
            MessageBox.Show("Please add a valid image")
            Return
         End If
         Dim pageType As FormsPageType = FormsPageType.Normal

         If _rbNormal.Checked Then
            pageType = FormsPageType.Normal
         ElseIf _rbIDCard.Checked Then
            pageType = FormsPageType.IDCard
         ElseIf _rbOmr.Checked Then
            pageType = FormsPageType.Omr
         End If

         Dim frm As New MainForm(scannedImage.CloneAll(), _txtMasterFormsName.Text, _txtMasterFormsDirectory.Text, pageType)
         scannedImage.Dispose()
         scannedImage = Nothing
         Me.Hide()
         frm.Show()
      Catch exp As Exception
         Messager.ShowError(Me, exp)
      End Try
   End Sub

   Private Sub _btnMasterDirectory_Click(sender As Object, e As EventArgs) Handles _btnMasterDirectory.Click
      Using browseDlg As New FolderBrowserDialogEx()
         browseDlg.ShowNewFolderButton = True
         browseDlg.ShowEditBox = True
         browseDlg.ShowFullPathInEditBox = True
         browseDlg.Description = "Select Master Forms Directory"
         browseDlg.RootFolder = Environment.SpecialFolder.MyComputer
         browseDlg.SelectedPath = _txtMasterFormsDirectory.Text
         If browseDlg.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            _txtMasterFormsDirectory.Text = browseDlg.SelectedPath
         End If
      End Using
   End Sub

   Private Sub _btnPrevCreate_Click(sender As Object, e As EventArgs) Handles _btnPrevCreate.Click
      _tbMain.SelectedTab = _tbMain.TabPages("_tbOptions")
   End Sub

   Private Sub _btnPrevAddPage_Click(sender As Object, e As EventArgs) Handles _btnPrevAddPage.Click
      If scannedImage IsNot Nothing Then
         scannedImage.Dispose()
         scannedImage = Nothing
      End If

      UpdateControls()

      _tbMain.SelectedTab = _tbMain.TabPages("_tbCreate")
   End Sub

   Private Sub _btnPrevLoad_Click(sender As Object, e As EventArgs) Handles _btnPrevLoad.Click
      _tbMain.SelectedTab = _tbMain.TabPages("_tbOptions")
   End Sub

   Private Sub MasterFormsWizard_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
      If scannedImage IsNot Nothing Then
         scannedImage.Dispose()
         scannedImage = Nothing
      End If
   End Sub
End Class
