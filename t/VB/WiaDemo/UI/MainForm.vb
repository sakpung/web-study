' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data

Imports Leadtools
Imports Leadtools.Wia
Imports Leadtools.Codecs
Imports Leadtools.WinForms
Imports System.IO

#If LEADTOOLS_V19_OR_LATER Then
Imports Leadtools.Demos.Dialogs
#End If

Public Class MainForm : Inherits System.Windows.Forms.Form
   Private _mmMain As System.Windows.Forms.MainMenu
   Private WithEvents _miFile As System.Windows.Forms.MenuItem
   Private WithEvents _miFileOpen As System.Windows.Forms.MenuItem
   Private WithEvents _miHelp As System.Windows.Forms.MenuItem
   Private WithEvents _miHelpAbout As System.Windows.Forms.MenuItem
   Private WithEvents _miFileSave As System.Windows.Forms.MenuItem
   Private WithEvents _miFileExit As System.Windows.Forms.MenuItem
   Private _miFileSep1 As System.Windows.Forms.MenuItem
   Private WithEvents _miFileClose As System.Windows.Forms.MenuItem
   Private _mmFileSep2 As System.Windows.Forms.MenuItem
   Private WithEvents _miWia As MenuItem
   Private WithEvents _miWiaSelectSource As MenuItem
   Private WithEvents _miWiaAcquire As MenuItem
   Private WithEvents _miProperties As MenuItem
   Private WithEvents _miPropertiesWiaProperties As MenuItem
   Private menuItem3 As MenuItem
   Private WithEvents _miPropertiesShowErrors As MenuItem
   Private WithEvents _miOptions As MenuItem
   Private WithEvents _miOptionsAcquireOptions As MenuItem
   Private WithEvents _miCapabilities As MenuItem
   Private WithEvents _miCapabilitiesShowCapabilities As MenuItem
   Private WithEvents _miCapabilitiesShowFormats As MenuItem
   Private WithEvents _miWiaAcquireStillImages As MenuItem
   Private components As IContainer

   Public Shared _codecs As RasterCodecs
   Public Shared _wiaSession As WiaSession
   Public Shared _wiaAcquireOptions As WiaAcquireOptions = WiaAcquireOptions.Empty
   Public Shared _wiaProperties As WiaProperties = WiaProperties.Empty
   Public Shared _wiaVersion As WiaVersion
   Public Shared _transferMode As WiaTransferMode
   Public Shared _errorList As ArrayList
   Public Shared _selectedWiaItem As Object = Nothing
   Public Shared _capabilitiesList As ArrayList
   Public Shared _formatsList As ArrayList
   Public Shared _flagValuesStrings As ArrayList
   Public Shared _forCapabilities As Boolean = False
   Public Shared _showUserInterface As Boolean = True
   Public Shared _acquireFromFeeder As Boolean = True
   Public _progressDlg As ProgressForm
   Private _scanCount As Integer = 0
   Private _wiaAvailable As Boolean = False
   Private _wiaSourceSelected As Boolean = False
   Private _wiaVideoStreamSource As Boolean = False
   Private _wiaAcquiring As Boolean = False
   Private menuItem1 As MenuItem
   Private WithEvents _miOptionsShowUI As MenuItem
   Private _sourceItem As Object = Nothing
   Private _enumeratedWiaItems As New ArrayList
   Private _openInitialPath As String = ""

   Public Sub New()
      '
      ' Required for Windows Form Designer support
      '
      InitializeComponent()

      '
      ' TODO: Add any constructor code after InitializeComponent call
      ''
   End Sub

   ''' <summary>
   ''' Clean up any resources being used.
   ''' </summary>
   Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
      If disposing Then
         If Not components Is Nothing Then
            components.Dispose()
         End If
      End If
      MyBase.Dispose(disposing)
   End Sub

#Region "Windows Form Designer generated code"
   ''' <summary>
   ''' Required method for Designer support - do not modify
   ''' the contents of this method with the code editor.
   ''' </summary>
   Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
      Me._mmMain = New System.Windows.Forms.MainMenu(Me.components)
      Me._miFile = New System.Windows.Forms.MenuItem()
      Me._miFileOpen = New System.Windows.Forms.MenuItem()
      Me._miFileSave = New System.Windows.Forms.MenuItem()
      Me._miFileSep1 = New System.Windows.Forms.MenuItem()
      Me._miFileClose = New System.Windows.Forms.MenuItem()
      Me._mmFileSep2 = New System.Windows.Forms.MenuItem()
      Me._miFileExit = New System.Windows.Forms.MenuItem()
      Me._miWia = New System.Windows.Forms.MenuItem()
      Me._miWiaSelectSource = New System.Windows.Forms.MenuItem()
      Me._miWiaAcquire = New System.Windows.Forms.MenuItem()
      Me._miWiaAcquireStillImages = New System.Windows.Forms.MenuItem()
      Me._miOptions = New System.Windows.Forms.MenuItem()
      Me._miOptionsAcquireOptions = New System.Windows.Forms.MenuItem()
      Me.menuItem1 = New System.Windows.Forms.MenuItem()
      Me._miOptionsShowUI = New System.Windows.Forms.MenuItem()
      Me._miCapabilities = New System.Windows.Forms.MenuItem()
      Me._miCapabilitiesShowCapabilities = New System.Windows.Forms.MenuItem()
      Me._miCapabilitiesShowFormats = New System.Windows.Forms.MenuItem()
      Me._miProperties = New System.Windows.Forms.MenuItem()
      Me._miPropertiesWiaProperties = New System.Windows.Forms.MenuItem()
      Me.menuItem3 = New System.Windows.Forms.MenuItem()
      Me._miPropertiesShowErrors = New System.Windows.Forms.MenuItem()
      Me._miHelp = New System.Windows.Forms.MenuItem()
      Me._miHelpAbout = New System.Windows.Forms.MenuItem()
      Me.SuspendLayout()
      ' 
      ' _mmMain
      ' 
      Me._mmMain.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._miFile, Me._miWia, Me._miOptions, Me._miCapabilities, Me._miProperties, Me._miHelp})
      ' 
      ' _miFile
      ' 
      Me._miFile.Index = 0
      Me._miFile.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._miFileOpen, Me._miFileSave, Me._miFileSep1, Me._miFileClose, Me._mmFileSep2, Me._miFileExit})
      Me._miFile.Text = "&File"
      '         Me._miFile.Popup += New System.EventHandler(Me._miFile_Popup);
      ' 
      ' _miFileOpen
      ' 
      Me._miFileOpen.Index = 0
      Me._miFileOpen.Shortcut = System.Windows.Forms.Shortcut.CtrlO
      Me._miFileOpen.Text = "&Open"
      '         Me._miFileOpen.Click += New System.EventHandler(Me._miFileOpen_Click);
      ' 
      ' _miFileSave
      ' 
      Me._miFileSave.Index = 1
      Me._miFileSave.Shortcut = System.Windows.Forms.Shortcut.CtrlS
      Me._miFileSave.Text = "&Save"
      '         Me._miFileSave.Click += New System.EventHandler(Me._miFileSave_Click);
      ' 
      ' _miFileSep1
      ' 
      Me._miFileSep1.Index = 2
      Me._miFileSep1.Text = "-"
      ' 
      ' _miFileClose
      ' 
      Me._miFileClose.Index = 3
      Me._miFileClose.Text = "&Close"
      '         Me._miFileClose.Click += New System.EventHandler(Me._miFileClose_Click);
      ' 
      ' _mmFileSep2
      ' 
      Me._mmFileSep2.Index = 4
      Me._mmFileSep2.Text = "-"
      ' 
      ' _miFileExit
      ' 
      Me._miFileExit.Index = 5
      Me._miFileExit.Text = "E&xit"
      '         Me._miFileExit.Click += New System.EventHandler(Me._miFileExit_Click);
      ' 
      ' _miWia
      ' 
      Me._miWia.Index = 1
      Me._miWia.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._miWiaSelectSource, Me._miWiaAcquire, Me._miWiaAcquireStillImages})
      Me._miWia.Text = "&WIA"
      '         Me._miWia.Popup += New System.EventHandler(Me._miWia_Popup);
      ' 
      ' _miWiaSelectSource
      ' 
      Me._miWiaSelectSource.Index = 0
      Me._miWiaSelectSource.Text = "&Select Source..."
      '         Me._miWiaSelectSource.Click += New System.EventHandler(Me._miWiaSelectSource_Click);
      ' 
      ' _miWiaAcquire
      ' 
      Me._miWiaAcquire.Index = 1
      Me._miWiaAcquire.Text = "Ac&quire"
      '         Me._miWiaAcquire.Click += New System.EventHandler(Me._miWiaAcquire_Click);
      ' 
      ' _miWiaAcquireStillImages
      ' 
      Me._miWiaAcquireStillImages.Index = 2
      Me._miWiaAcquireStillImages.Text = "Acquire Still &Images From Streaming Video..."
      '         Me._miWiaAcquireStillImages.Click += New System.EventHandler(Me._miWiaAcquireStillImages_Click);
      ' 
      ' _miOptions
      ' 
      Me._miOptions.Index = 2
      Me._miOptions.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._miOptionsAcquireOptions, Me.menuItem1, Me._miOptionsShowUI})
      Me._miOptions.Text = "&Options"
      '         Me._miOptions.Popup += New System.EventHandler(Me._miOptions_Popup);
      ' 
      ' _miOptionsAcquireOptions
      ' 
      Me._miOptionsAcquireOptions.Index = 0
      Me._miOptionsAcquireOptions.Text = "Acquire &Options..."
      '         Me._miOptionsAcquireOptions.Click += New System.EventHandler(Me._miOptionsAcquireOptions_Click);
      ' 
      ' menuItem1
      ' 
      Me.menuItem1.Index = 1
      Me.menuItem1.Text = "-"
      ' 
      ' _miOptionsShowUI
      ' 
      Me._miOptionsShowUI.Index = 2
      Me._miOptionsShowUI.Text = "Show Acquire User &Interface"
      '         Me._miOptionsShowUI.Click += New System.EventHandler(Me._miOptionsShowUI_Click);
      ' 
      ' _miCapabilities
      ' 
      Me._miCapabilities.Index = 3
      Me._miCapabilities.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._miCapabilitiesShowCapabilities, Me._miCapabilitiesShowFormats})
      Me._miCapabilities.Text = "&Capabilities"
      '         Me._miCapabilities.Popup += New System.EventHandler(Me._miCapabilities_Popup);
      ' 
      ' _miCapabilitiesShowCapabilities
      ' 
      Me._miCapabilitiesShowCapabilities.Index = 0
      Me._miCapabilitiesShowCapabilities.Text = "Show Supported &Capabilities..."
      '         Me._miCapabilitiesShowCapabilities.Click += New System.EventHandler(Me._miCapabilitiesShowCapabilities_Click);
      ' 
      ' _miCapabilitiesShowFormats
      ' 
      Me._miCapabilitiesShowFormats.Index = 1
      Me._miCapabilitiesShowFormats.Text = "Show Supported &Formats..."
      '         Me._miCapabilitiesShowFormats.Click += New System.EventHandler(Me._miCapabilitiesShowFormats_Click);
      ' 
      ' _miProperties
      ' 
      Me._miProperties.Index = 4
      Me._miProperties.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._miPropertiesWiaProperties, Me.menuItem3, Me._miPropertiesShowErrors})
      Me._miProperties.Text = "&Properties"
      '         Me._miProperties.Popup += New System.EventHandler(Me._miProperties_Popup);
      ' 
      ' _miPropertiesWiaProperties
      ' 
      Me._miPropertiesWiaProperties.Index = 0
      Me._miPropertiesWiaProperties.Text = "&WIA Properties..."
      '         Me._miPropertiesWiaProperties.Click += New System.EventHandler(Me._miPropertiesWiaProperties_Click);
      ' 
      ' menuItem3
      ' 
      Me.menuItem3.Index = 1
      Me.menuItem3.Text = "-"
      ' 
      ' _miPropertiesShowErrors
      ' 
      Me._miPropertiesShowErrors.Index = 2
      Me._miPropertiesShowErrors.Text = "Show Properties &Errors..."
      '         Me._miPropertiesShowErrors.Click += New System.EventHandler(Me._miPropertiesShowErrors_Click);
      ' 
      ' _miHelp
      ' 
      Me._miHelp.Index = 5
      Me._miHelp.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._miHelpAbout})
      Me._miHelp.Text = "&Help"
      '         Me._miHelp.Popup += New System.EventHandler(Me._miHelp_Popup);
      ' 
      ' _miHelpAbout
      ' 
      Me._miHelpAbout.Index = 0
      Me._miHelpAbout.Text = "&About"
      '         Me._miHelpAbout.Click += New System.EventHandler(Me._miHelpAbout_Click);
      ' 
      ' MainForm
      ' 
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.ClientSize = New System.Drawing.Size(868, 568)
      Me.Icon = (CType(resources.GetObject("$this.Icon"), System.Drawing.Icon))
      Me.IsMdiContainer = True
      Me.Menu = Me._mmMain
      Me.Name = "MainForm"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "LEADTOOLS WIA VB.NET Demo"
      '         Me.Load += New System.EventHandler(Me.MainForm_Load);
      '         Me.Closing += New System.ComponentModel.CancelEventHandler(Me.MainForm_Closing);
      Me.ResumeLayout(False)

   End Sub
#End Region

   ''' <summary>
   ''' The main entry point for the application.
   ''' </summary>
   <STAThread()> _
   Shared Sub Main()
      
      If Not Support.SetLicense() Then
         Return
      End If

      Using WiaVersionDlg As WiaVersionForm = New WiaVersionForm()
         If WiaVersionDlg.ShowDialog() = DialogResult.OK Then
            _wiaVersion = WiaVersionDlg._selectedWiaVersion
         Else
            Return
         End If
      End Using

      Application.Run(New MainForm())
   End Sub

   Private Sub MainForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
      ' initialize the codecs object
      _codecs = New RasterCodecs()

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
            _transferMode = WiaTransferMode.Memory
         Else
            _transferMode = _wiaProperties.DataTransfer.TransferMode
         End If

         AddHandler _wiaSession.AcquireEvent, AddressOf _wiaSession_AcquireEvent
      Else
         _miWiaSelectSource.Enabled = False
      End If

      EnableMenuItems(False)
      _errorList = New ArrayList()
      _capabilitiesList = New ArrayList()
      _formatsList = New ArrayList()
      _flagValuesStrings = New ArrayList()
   End Sub

   Private Sub MainForm_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
      ' prevent the application from closing while acquiring.
      If _wiaAcquiring Then
         e.Cancel = True
         Return
      End If
      RemoveHandler _wiaSession.AcquireEvent, AddressOf _wiaSession_AcquireEvent

      If _wiaAvailable Then
         _wiaSession.Shutdown()
      End If
   End Sub

   Private Sub _miFile_Popup(ByVal sender As Object, ByVal e As EventArgs) Handles _miFile.Popup
      _miFileOpen.Enabled = Not _wiaAcquiring
      _miFileExit.Enabled = Not _wiaAcquiring
   End Sub

   Private Sub _miWia_Popup(ByVal sender As Object, ByVal e As EventArgs) Handles _miWia.Popup
      If _wiaAvailable AndAlso _wiaSourceSelected AndAlso (Not _wiaAcquiring) Then
         _miWiaAcquire.Enabled = True
         If _wiaVideoStreamSource Then
            _miWiaAcquireStillImages.Enabled = True
         Else
            _miWiaAcquireStillImages.Enabled = False
         End If
      Else
         If _wiaAcquiring Then
            _miWiaSelectSource.Enabled = False
         Else
            _miWiaSelectSource.Enabled = True
         End If

         _miWiaAcquire.Enabled = False
         _miWiaAcquireStillImages.Enabled = False
      End If
   End Sub

   Private Sub _miOptions_Popup(ByVal sender As Object, ByVal e As EventArgs) Handles _miOptions.Popup
      If _wiaAvailable AndAlso _wiaSourceSelected AndAlso (Not _wiaAcquiring) Then
         _miOptionsAcquireOptions.Enabled = True
         _miOptionsShowUI.Enabled = True
      Else
         _miOptionsAcquireOptions.Enabled = False
         _miOptionsShowUI.Enabled = False
      End If

      _miOptionsShowUI.Checked = _showUserInterface
   End Sub

   Private Sub _miCapabilities_Popup(ByVal sender As Object, ByVal e As EventArgs) Handles _miCapabilities.Popup
      If _wiaAvailable AndAlso _wiaSourceSelected AndAlso (Not _wiaAcquiring) Then
         _miCapabilitiesShowCapabilities.Enabled = True
         _miCapabilitiesShowFormats.Enabled = True
      Else
         _miCapabilitiesShowCapabilities.Enabled = False
         _miCapabilitiesShowFormats.Enabled = False
      End If
   End Sub

   Private Sub _miProperties_Popup(ByVal sender As Object, ByVal e As EventArgs) Handles _miProperties.Popup
      If _wiaAvailable AndAlso _wiaSourceSelected AndAlso (Not _wiaAcquiring) Then
         _miPropertiesWiaProperties.Enabled = True
         If _errorList.Count > 0 Then
            _miPropertiesShowErrors.Enabled = True
         Else
            _miPropertiesShowErrors.Enabled = False
         End If
      Else
         _miPropertiesWiaProperties.Enabled = False
         _miPropertiesShowErrors.Enabled = False
      End If
   End Sub

   Private Sub _miHelp_Popup(ByVal sender As Object, ByVal e As EventArgs) Handles _miHelp.Popup
      _miHelpAbout.Enabled = Not _wiaAcquiring
   End Sub

   Public Sub CreateChildForm(ByVal img As RasterImage, ByVal caption As String)
      Dim child As ChildForm = New ChildForm()
      child.MdiParent = Me
      child.InsertImage(img, caption)
      child.Show()

      EnableMenuItems(True)
   End Sub

   Public Sub EnableMenuItems(ByVal enable As Boolean)
      _miFileSave.Enabled = enable
      _miFileClose.Enabled = enable
   End Sub

   Private Sub _miFileOpen_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _miFileOpen.Click
      Dim loader As ImageFileLoader = New ImageFileLoader()

      Try
         loader.LoadOnlyOnePage = True
         loader.OpenDialogInitialPath = _openInitialPath
         If loader.Load(Me, _codecs, True) > 0 Then
            _openInitialPath = Path.GetDirectoryName(loader.FileName)
            CreateChildForm(loader.Image, loader.FileName)
         End If
      Catch ex As Exception
         Messager.ShowFileOpenError(Me, loader.FileName, ex)
      End Try
   End Sub

   Private Sub _miFileSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _miFileSave.Click
      Dim saver As ImageFileSaver = New ImageFileSaver()

      Try
         Dim child As ChildForm = CType(ActiveMdiChild, ChildForm)
         saver.Save(Me, _codecs, child._viewer.Image)
      Catch ex As Exception
         Messager.ShowFileSaveError(Me, saver.FileName, ex)
      End Try
   End Sub

   Private Sub _miFileExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _miFileExit.Click
      Close()
   End Sub

   Private Sub _miFileClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _miFileClose.Click
      ActiveMdiChild.Close()
   End Sub

   Private Sub _miHelpAbout_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _miHelpAbout.Click
#If LEADTOOLS_V19_OR_LATER Then
      Using aboutDialog As New AboutDialog("WIA", ProgrammingInterface.VB)
         aboutDialog.ShowDialog(Me)
      End Using
#Else
      Using aboutDialog As New AboutDialog("WIA")
	      aboutDialog.ShowDialog(Me)
      End Using
#End If
   End Sub

   Private Sub _miWiaSelectSource_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _miWiaSelectSource.Click
      Try
#If Not LEADTOOLS_V19_OR_LATER Then
         Dim res As DialogResult = _wiaSession.SelectDeviceDlg(Me, WiaDeviceType.Default, WiaSelectSourceFlags.NoDefault)
#Else
         Dim res As DialogResult = _wiaSession.SelectDeviceDlg(Me.Handle, WiaDeviceType.Default, WiaSelectSourceFlags.NoDefault)
#End If ' #If Not LEADTOOLS_V19_OR_LATER Then
         If res = DialogResult.OK Then
            _wiaSourceSelected = True
            If _wiaSession.SelectedDeviceType = WiaDeviceType.StreamingVideo Then
               _wiaVideoStreamSource = True
            Else
               _wiaVideoStreamSource = False
            End If
         End If
      Catch ex As Exception
         _wiaSourceSelected = False
         _wiaVideoStreamSource = False
         Messager.ShowError(Me, ex)
      End Try
   End Sub

   Private Sub _miWiaAcquire_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _miWiaAcquire.Click
      Dim flags As WiaAcquireFlags = WiaAcquireFlags.None
      Dim showProgress As Boolean = True

      _progressDlg = New ProgressForm("Transferring...", "", 100)

      _wiaAcquiring = True

      If _showUserInterface Then
         flags = WiaAcquireFlags.UseCommonUI Or WiaAcquireFlags.ShowUserInterface
      Else
         ' Check if the selected device is scanner and that it has multiple sources (Feeder & Flatbed)
         ' then show the select source dialog box.
         If SelectAcquireSource() <> DialogResult.OK Then
            _wiaAcquiring = False
            Return
         End If
      End If

      If _showUserInterface Then
         If _wiaVersion = WiaVersion.Version2 Then
            showProgress = False
         End If
      End If

      If showProgress Then
         ' Show the progress dialog.
         _progressDlg.Show(Me)
      End If

      Try
         _wiaSession.AcquireOptions = _wiaAcquireOptions

         If _wiaProperties.DataTransfer.TransferMode = WiaTransferMode.None Then ' GetProperties() method not called yet.
            _transferMode = WiaTransferMode.Memory
         Else
            _transferMode = _wiaProperties.DataTransfer.TransferMode
         End If

         ' Disable the minimize and maximize buttons.
         Me.MinimizeBox = False
         Me.MaximizeBox = False

#If Not LEADTOOLS_V19_OR_LATER Then
         Dim dlgResult As DialogResult = _wiaSession.Acquire(Me, _sourceItem, flags)
#Else
         Dim dlgResult As DialogResult = _wiaSession.Acquire(Me.Handle, _sourceItem, flags)
#End If ' #If Not LEADTOOLS_V19_OR_LATER Then
         If (dlgResult <> DialogResult.OK) Then
            Return
         End If

         ' Enable back the minimize and maximize buttons.
         Me.MinimizeBox = True
         Me.MaximizeBox = True

         If _progressDlg.Visible Then
            If (Not _progressDlg.Abort) Then
               _progressDlg.Dispose()
            End If
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
         Else
            If _wiaVersion = WiaVersion.Version2 Then
               'WIA 2.0 sometimes doesn't return the acquired files count and paths, so this message will show 
               'the directory where the saved files were saved.
               Dim len As Integer = _wiaAcquireOptions.FileName.LastIndexOf("\")
               Dim strFilesDirectory As String = _wiaAcquireOptions.FileName.Substring(0, len)
               Dim strMsg As String = String.Format("Acquired page(s) were saved to:{0}{1}{2}", Constants.vbLf, Constants.vbLf, strFilesDirectory)
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
      Finally
         ' Enable back the minimize and maximize buttons.
         Me.MinimizeBox = True
         Me.MaximizeBox = True

         _wiaAcquiring = False
      End Try
   End Sub

   Private Sub _wiaSession_AcquireEvent(ByVal sender As Object, ByVal e As WiaAcquireEventArgs)
      Dim strInfoMsg As String

      ' Update the progress bar with the received percent value;
      If _progressDlg.Visible Then
         ' Show the user some information about the file we are acquiring 
         ' to (if the user chooses file transfer).

         If (e.Flags And WiaAcquiredPageFlags.StartOfPage) = WiaAcquiredPageFlags.StartOfPage Then
            If _transferMode = WiaTransferMode.File Then
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

      If Not _transferMode = WiaTransferMode.File Then
         If Not e.Image Is Nothing Then
            _scanCount += 1
            Dim childCaption As String = String.Format("WIA Scanned page {0}", _scanCount.ToString())
            CreateChildForm(e.Image, childCaption)

            Application.DoEvents()
         End If
      End If
   End Sub

   Private Function SelectAcquireSource() As DialogResult
      _forCapabilities = True
      Dim dlgResult As DialogResult = DialogResult.Cancel

      Using DeviceItemsDlg As WiaDeviceItemsForm = New WiaDeviceItemsForm()
         dlgResult = DeviceItemsDlg.ShowDialog(Me)
         If dlgResult = DialogResult.OK Then
            _sourceItem = _selectedWiaItem
         End If
      End Using

      Return dlgResult
   End Function

   Private Sub _wiaSession_EnumItemsEvent(ByVal sender As Object, ByVal e As WiaEnumItemsEventArgs)
      _enumeratedWiaItems.Add(e.Item)
   End Sub

   Private Sub _miOptionsAcquireOptions_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _miOptionsAcquireOptions.Click
      Using AcquireOptionsDlg As AcquireOptionsForm = New AcquireOptionsForm()
         AcquireOptionsDlg.ShowDialog(Me)
      End Using
   End Sub

   Private Sub _miOptionsShowUI_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _miOptionsShowUI.Click
      _showUserInterface = Not _showUserInterface
   End Sub

   Private Sub _miWiaAcquireStillImages_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _miWiaAcquireStillImages.Click
      Using CaptureStillImagesDlg As CaptureStillImagesForm = New CaptureStillImagesForm()
         CaptureStillImagesDlg.FormParent = Me
         CaptureStillImagesDlg.ShowDialog(Me)
      End Using
   End Sub

   Private Sub _miCapabilitiesShowCapabilities_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _miCapabilitiesShowCapabilities.Click
      _forCapabilities = True
      Using DeviceItemsDlg As WiaDeviceItemsForm = New WiaDeviceItemsForm()
         If DeviceItemsDlg.ShowDialog(Me) = DialogResult.OK Then
            Using SupportedCapsDlg As SupportedCapabilitiesForm = New SupportedCapabilitiesForm()
               SupportedCapsDlg.ShowDialog(Me)
            End Using
         End If
      End Using
   End Sub

   Private Sub _miCapabilitiesShowFormats_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _miCapabilitiesShowFormats.Click
      _forCapabilities = True
      Using DeviceItemsDlg As WiaDeviceItemsForm = New WiaDeviceItemsForm()
         If DeviceItemsDlg.ShowDialog(Me) = DialogResult.OK Then
            Using SupportedFormatsDlg As SupportedFormatsForm = New SupportedFormatsForm()
               SupportedFormatsDlg.ShowDialog(Me)
            End Using
         End If
      End Using
   End Sub

   Private Sub _miPropertiesWiaProperties_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _miPropertiesWiaProperties.Click
      _forCapabilities = False
      Using DeviceItemsDlg As WiaDeviceItemsForm = New WiaDeviceItemsForm()
         If DeviceItemsDlg.ShowDialog(Me) = DialogResult.OK Then
            Using PropertiesDlg As WiaPropertiesForm = New WiaPropertiesForm()
               If PropertiesDlg.ShowDialog(Me) = DialogResult.OK Then
                  If _errorList.Count > 0 Then
                     Using ErrorsDlg As WiaPropertiesErrorsForm = New WiaPropertiesErrorsForm()
                        ErrorsDlg.ShowDialog(Me)
                     End Using
                  End If
               End If
            End Using
         End If
      End Using
   End Sub

   Private Sub _miPropertiesShowErrors_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _miPropertiesShowErrors.Click
      Using ErrorsDlg As WiaPropertiesErrorsForm = New WiaPropertiesErrorsForm()
         ErrorsDlg.ShowDialog(Me)
      End Using
   End Sub
End Class

Public Class ItemData
   Private _item As Object
   Private _node As Object

   Public Sub New(ByVal wiaItem As Object)
      _item = wiaItem
   End Sub

   Public Property Item() As Object
      Get
         Return _item
      End Get
      Set(ByVal value As Object)
         _item = value
      End Set
   End Property

   'Used to save corresponding TreeNode.
   Public Property Node() As Object
      Get
         Return _node
      End Get
      Set(ByVal value As Object)
         _node = value
      End Set
   End Property
End Class
