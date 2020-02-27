' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Media
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports System.Reflection

Imports Leadtools
Imports Leadtools.ScreenCapture
Imports Leadtools.Codecs
Imports Leadtools.Controls
Imports Leadtools.Demos.Dialogs

Namespace ScreenCaptureDemo
   Partial Public Class MainForm : Inherits Form
      ' Constructor
      Public Sub New()
         InitializeComponent()
      End Sub

      ' *****************
      ' VARIABLES SECTION
      ' *****************

      ''' <summary>
      ''' What to capture in this app.
      ''' </summary>
      Private Enum CaptureType
         None
         Window
         ActiveWindow
         ActiveClient
         WallPaper
         FullScreen
         MenuUnderCursor
         WindowUnderCursor
         SelectedObject
         Area
         MouseCursor
         FromExeTree
         FromExeTab
      End Enum

      ' current capture type
      Private _captureType As CaptureType

      ' the raster codecs used in load/save
      Private _codecs As RasterCodecs

      ' number of opened images
      Private _countOfOpenedImages As Integer

      ' boolean variables for menu items (checked or unchecked)
      Private _isBeepOn As Boolean
      Private _minimizeOnCapture As Boolean
      Private _activateAfterCapture As Boolean
      Private _isImageSaved As Boolean
      Private _cutImage As Boolean
      Private _previousWindowState As FormWindowState

      ' Screen Capture Specific Variables
      Private _engine As ScreenCaptureEngine = Nothing
      Private _areaOptions As ScreenCaptureAreaOptions
      Private _objectOptions As ScreenCaptureObjectOptions
      Private _options As ScreenCaptureOptions
      Private _captureInformation As ScreenCaptureInformation
      Private _isHotKeyEnabled As Boolean

      Private ReadOnly Property ActiveCapturedImageForm() As CapturedImageForm
         Get
            Return TryCast(ActiveMdiChild, CapturedImageForm)
         End Get
      End Property

      Public Property CountOfOpenedImages() As Integer
         Get
            Return _countOfOpenedImages
         End Get
         Set(value As Integer)
            _countOfOpenedImages = Value
         End Set
      End Property

      Public ReadOnly Property IsCutActive() As Boolean
         Get
            Return _cutImage
         End Get
      End Property

      Public WriteOnly Property EnableSaveAs() As Boolean
         Set(value As Boolean)
            _miFileSaveAs.Enabled = Value
         End Set
      End Property

      Public WriteOnly Property EnableCut() As Boolean
         Set(value As Boolean)
            _miEditCut.Enabled = Value
         End Set
      End Property

      Public WriteOnly Property EnableCopy() As Boolean
         Set(value As Boolean)
            _miEditCopy.Enabled = Value
         End Set
      End Property

      ' **************************
      ' PROGRAM SPECIFIC FUNCTIONS
      ' **************************

      Private Sub MainForm_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
         ' setup our caption
         Messager.Caption = "LEADTOOLS VB Screen Capture Demo"
         Text = Messager.Caption

         ' what to capture
         _captureType = CaptureType.None

         ' set the current window state
         _previousWindowState = Me.WindowState

         ' as a start, do not beep when capturing
         _isBeepOn = False

         ' minimize window on capturing
         _minimizeOnCapture = True

         ' activate window after capturing
         _activateAfterCapture = True

         ' beeping is off
         _isBeepOn = False

         ' no cut is active
         _cutImage = False

         ' initialize the codecs object
         _codecs = New RasterCodecs()

         ' no opened images for now
         _countOfOpenedImages = 0

         ' startup the engine
         ScreenCaptureEngine.Startup()

         ' initialize Screen Capture Variables
         _engine = New ScreenCaptureEngine()
         AddHandler _engine.CaptureInformation, AddressOf _engine_CaptureInformation
         _areaOptions = ScreenCaptureEngine.DefaultCaptureAreaOptions
         _objectOptions = ScreenCaptureEngine.DefaultCaptureObjectOptions
         _options = _engine.CaptureOptions
         _captureInformation = Nothing
         _isHotKeyEnabled = True

         UpdateMyControls()
         UpdateStatusBarText()
      End Sub

      Private Sub MainForm_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles Me.FormClosing
         ScreenCaptureEngine.Shutdown()
      End Sub

      Private Sub _engine_CaptureInformation(ByVal sender As Object, ByVal e As ScreenCaptureInformationEventArgs)
         Dim child As CapturedImageForm = New CapturedImageForm()

         _countOfOpenedImages += 1
         child.MdiParent = Me
         child.Viewer.Image = e.Image
         child.Text = "Captured Image " + _countOfOpenedImages.ToString()
         child.Show()

         If _activateAfterCapture Then
            Me.WindowState = _previousWindowState
         End If

         If _isBeepOn Then
            SystemSounds.Beep.Play()
         End If
      End Sub

      Private Sub UpdateMyControls()
         ' if we have an image then enable the Save
         Dim capturedImageForm As CapturedImageForm = ActiveCapturedImageForm

         If Not capturedImageForm Is Nothing Then
            _miFileSaveAs.Enabled = True
            _miEditCopy.Enabled = True
            _miEditCut.Enabled = True
         Else
            _miFileSaveAs.Enabled = False
            _miEditCopy.Enabled = False
            _miEditCut.Enabled = False
         End If

         _miCaptureActiveWindow.Checked = False
         _miCaptureActiveClient.Checked = False
         _miCaptureFullScreen.Checked = False
         _miCaptureSelectedObject.Checked = False
         _miCaptureMenuUnderCursor.Checked = False
         _miCaptureSelectedArea.Checked = False
         _miCaptureWallpaper.Checked = False
         _miCaptureMouseCursor.Checked = False
         _miCaptureWindowUnderCursor.Checked = False

         Select Case _captureType
            Case CaptureType.ActiveWindow
               _miCaptureActiveWindow.Checked = True
               _miCaptureStopCapture.Enabled = True
            Case CaptureType.ActiveClient
               _miCaptureActiveClient.Checked = True
               _miCaptureStopCapture.Enabled = True
            Case CaptureType.FullScreen
               _miCaptureFullScreen.Checked = True
               _miCaptureStopCapture.Enabled = True
            Case CaptureType.SelectedObject
               _miCaptureSelectedObject.Checked = True
               _miCaptureStopCapture.Enabled = True
            Case CaptureType.MenuUnderCursor
               _miCaptureMenuUnderCursor.Checked = True
               _miCaptureStopCapture.Enabled = True
            Case CaptureType.Area
               _miCaptureSelectedArea.Checked = True
               _miCaptureStopCapture.Enabled = True
            Case CaptureType.WallPaper
               _miCaptureWallpaper.Checked = True
               _miCaptureStopCapture.Enabled = True
            Case CaptureType.MouseCursor
               _miCaptureMouseCursor.Checked = True
               _miCaptureStopCapture.Enabled = True
            Case CaptureType.WindowUnderCursor
               _miCaptureWindowUnderCursor.Checked = True
               _miCaptureStopCapture.Enabled = True
            Case Else
               _miCaptureStopCapture.Enabled = False
         End Select
      End Sub

      Private Sub UpdateStatusBarText()
         ' update the status bar text
         Select Case (_captureType)
            Case CaptureType.ActiveWindow
               _sbiText.Text = "Capture the Active Window"

            Case CaptureType.ActiveClient
               _sbiText.Text = "Capture the Active Client"

            Case CaptureType.FullScreen
               _sbiText.Text = "Capture Full Screen"

            Case CaptureType.SelectedObject
               _sbiText.Text = "Capture the Selected Object"

            Case CaptureType.MenuUnderCursor
               _sbiText.Text = "Capture the Menu Under the Cursor"

            Case CaptureType.Area
               _sbiText.Text = "Capture a selected Area"

            Case CaptureType.WallPaper
               _sbiText.Text = "Capture the Wallpaper"

            Case CaptureType.MouseCursor
               _sbiText.Text = "Capture the Mouse Cursor"

            Case CaptureType.WindowUnderCursor
               _sbiText.Text = "Capture the Window Under the Cursor"

            Case CaptureType.FromExeTab
               _sbiText.Text = "Capture from EXE file, Tabbed View"

            Case CaptureType.FromExeTree
               _sbiText.Text = "Capture from EXE file, Tree View"

            Case Else
               _sbiText.Text = "Ready - No Capture Activated"
         End Select
      End Sub

      ''' <summary>
      ''' Saves the image
      ''' </summary>
      ''' <returns>True if the image is saved successfully, false otherwise.</returns>
      Public Function SaveAs() As Boolean
         _miFileSaveAs_Click(Me, Nothing)
         Return _isImageSaved
      End Function

      ' *********
      ' FILE MENU
      ' *********

      ' File Menu - Exit
      Private Sub _miFileExit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _miFileExit.Click
         Close()
      End Sub

      ' File Menu - SaveAs
      Private Sub _miFileSaveAs_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _miFileSaveAs.Click
         Dim saver As ImageFileSaver = New ImageFileSaver()
         _isImageSaved = False

         Try
            Dim activeForm As CapturedImageForm = ActiveCapturedImageForm
            saver.Save(Me, _codecs, activeForm.Viewer.Image)
            _isImageSaved = True
         Catch ex As Exception
            Messager.ShowFileSaveError(Me, saver.FileName, ex)
            _isImageSaved = False
         End Try
      End Sub

      ' ************
      ' OPTIONS MENU
      ' ************

      ' Options Menu - Minimize Application On Capture
      Private Sub _miOptionsMinimizeApplicationOnCapture_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _miOptionsMinimizeApplicationOnCapture.Click
         _minimizeOnCapture = Not _minimizeOnCapture
         _miOptionsMinimizeApplicationOnCapture.Checked = Not _miOptionsMinimizeApplicationOnCapture.Checked
      End Sub

      ' Options Menu - Activate Application After Capture
      Private Sub _miOptionsActivateApplicationAfterCapture_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _miOptionsActivateApplicationAfterCapture.Click
         _activateAfterCapture = Not _activateAfterCapture
         _miOptionsActivateApplicationAfterCapture.Checked = Not _miOptionsActivateApplicationAfterCapture.Checked
      End Sub

      ' Options Menu - Beep On Capture
      Private Sub _miOptionsBeepOnCapture_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _miOptionsBeepOnCapture.Click
         _isBeepOn = Not _isBeepOn
         _miOptionsBeepOnCapture.Checked = Not _miOptionsBeepOnCapture.Checked
      End Sub

      ' Options Menu - Capture Options ...
      Private Sub _miOptionsCaptureOptions_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _miOptionsCaptureOptions.Click
         If _captureType <> CaptureType.None Then
            _captureType = CaptureType.None
            _engine.StopCapture()
            UpdateMyControls()
            UpdateStatusBarText()
         End If

         Try
            _options = _engine.ShowCaptureOptionsDialog(Me, ScreenCaptureDialogFlags.None, _options, Nothing)
            _engine.CaptureOptions = _options
            If (_options.Hotkey = Keys.None) Then
               _isHotKeyEnabled = False
            Else
               _isHotKeyEnabled = True
            End If
         Catch ex As Exception
            If ex.Message <> "UserAbort" AndAlso ex.Message <> "User has aborted operation" Then
               Messager.ShowError(Me, ex)
            End If
         End Try
      End Sub

      ' Options - Capture Area Options ...
      Private Sub _miOptionsCaptureAreaOptions_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _miOptionsCaptureAreaOptions.Click
         If _captureType <> CaptureType.None Then
            _captureType = CaptureType.None
            _engine.StopCapture()
            UpdateMyControls()
            UpdateStatusBarText()
         End If

         Try
            _areaOptions = _engine.ShowCaptureAreaOptionsDialog(Me, ScreenCaptureDialogFlags.None, _areaOptions, False, Nothing)
         Catch ex As Exception
            If ex.Message <> "UserAbort" AndAlso ex.Message <> "User has aborted operation" Then
               Messager.ShowError(Me, ex)
            End If
         End Try
      End Sub

      ' Options - Capture Object Options ...
      Private Sub _miOptionsCaptureObjectOptions_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _miOptionsCaptureObjectOptions.Click
         If _captureType <> CaptureType.None Then
            _captureType = CaptureType.None
            _engine.StopCapture()
            UpdateMyControls()
            UpdateStatusBarText()
         End If

         Try
            _objectOptions = _engine.ShowCaptureObjectOptionsDialog(Me, ScreenCaptureDialogFlags.None, _objectOptions, False, Nothing)
         Catch ex As Exception
            If ex.Message <> "UserAbort" AndAlso ex.Message <> "User has aborted operation" Then
               Messager.ShowError(Me, ex)
            End If
         End Try
      End Sub

      ' *********
      ' VIEW MENU
      ' *********
      ' View Menu - StatusBar
      Private Sub _miViewStatusBar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _miViewStatusBar.Click
         _miViewStatusBar.Checked = Not _miViewStatusBar.Checked
         _sbMain.Visible = Not _sbMain.Visible
         UpdateStatusBarText()
      End Sub

      ' *********
      ' EDIT MENU
      ' *********

      ' Edit Menu - Cut
      Private Sub _miEditCut_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _miEditCut.Click
         _miEditCopy_Click(sender, e)
         Dim capturedImageForm As CapturedImageForm = ActiveCapturedImageForm
         _cutImage = True
         capturedImageForm.Close()
         _cutImage = False
      End Sub

      ' Edit Menu - Copy
      Private Sub _miEditCopy_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _miEditCopy.Click
         Dim capturedImageForm As CapturedImageForm = ActiveCapturedImageForm

         Try
            Using wait As WaitCursor = New WaitCursor()
               RasterClipboard.Copy(Me.Handle, capturedImageForm.Viewer.Image, RasterClipboardCopyFlags.Empty Or RasterClipboardCopyFlags.Dib Or RasterClipboardCopyFlags.Palette Or RasterClipboardCopyFlags.Region)
            End Using
         Catch ex As Exception
            Messager.ShowError(Me, ex)
         Finally
            UpdateMyControls()
         End Try
      End Sub

      ' *********
      ' HELP MENU
      ' *********

      ' Help Menu - About
      Private Sub _miHelpAbout_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _miHelpAbout.Click
         Using aboutDialog As New AboutDialog("Screen Capture", ProgrammingInterface.VB)
            aboutDialog.ShowDialog(Me)
         End Using
      End Sub

      ' ************
      ' CAPTURE MENU
      ' ************

      ' Capture Menu - Capture Active Window
      Private Sub _miCaptureActiveWindow_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _miCaptureActiveWindow.Click
         DoCapture(CaptureType.ActiveWindow)
      End Sub

      ' Capture Menu - Capture Active Client
      Private Sub _miCaptureActiveClient_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _miCaptureActiveClient.Click
         DoCapture(CaptureType.ActiveClient)
      End Sub

      ' Capture Menu - Capture Full Screen
      Private Sub _miCaptureFullScreen_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _miCaptureFullScreen.Click
         DoCapture(CaptureType.FullScreen)
      End Sub

      ' Capture Menu - Capture Selected Object
      Private Sub _miCaptureSelectedObject_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _miCaptureSelectedObject.Click
         DoCapture(CaptureType.SelectedObject)
      End Sub

      ' Capture Menu - Capture Menu Under Cursor
      Private Sub _miCaptureMenuUnderCursor_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _miCaptureMenuUnderCursor.Click
         DoCapture(CaptureType.MenuUnderCursor)
      End Sub

      ' Capture Menu - Capture Selected Area
      Private Sub _miCaptureSelectedArea_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _miCaptureSelectedArea.Click
         DoCapture(CaptureType.Area)
      End Sub

      ' Capture Menu - Capture Wallpaper
      Private Sub _miCaptureWallpaper_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _miCaptureWallpaper.Click
         DoCapture(CaptureType.WallPaper)
      End Sub

      ' Capture Menu - Capture Mouse Cursor
      Private Sub _miCaptureMouseCursor_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _miCaptureMouseCursor.Click
         DoCapture(CaptureType.MouseCursor)
      End Sub

      ' Capture Menu - Capture Window Under Cursor
      Private Sub _miCaptureWindowUnderCursor_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _miCaptureWindowUnderCursor.Click
         DoCapture(CaptureType.WindowUnderCursor)
      End Sub

      Private Sub DoCapture(ByVal captureType_Renamed As CaptureType)
         If _isHotKeyEnabled Then
            If _captureType = captureType_Renamed Then
               Return
            End If
         End If

         _captureType = captureType_Renamed
         _engine.StopCapture()
         UpdateMyControls()
         UpdateStatusBarText()

         Dim hotkeyMsg As String = String.Format("To activate the capture, press <{0}>", _options.Hotkey.ToString())
         MessageBox.Show(hotkeyMsg)

         If _minimizeOnCapture Then
            _previousWindowState = Me.WindowState
            Me.WindowState = FormWindowState.Minimized
         End If

         Try
            Select Case captureType_Renamed
               Case CaptureType.ActiveWindow
                  Do
                     Dim image As RasterImage = Nothing
                     Try
                        image = _engine.CaptureActiveWindow(_captureInformation)
                     Catch ex As RasterException
                        If ex.Message = "UserAbort" OrElse ex.Message = "User has aborted operation" Then
                           _captureType = CaptureType.None
                        End If
                     End Try
                     If image Is Nothing Then
                        _captureType = CaptureType.None
                     Else
                        _isHotKeyEnabled = False
                     End If
                     UpdateMyControls()
                  Loop While (_captureType = CaptureType.ActiveWindow) AndAlso (_isHotKeyEnabled)

               Case CaptureType.ActiveClient
                  Do
                     Dim image As RasterImage = Nothing
                     Try
                        image = _engine.CaptureActiveClient(_captureInformation)
                     Catch ex As RasterException
                        If ex.Message = "UserAbort" OrElse ex.Message = "User has aborted operation" Then
                           _captureType = CaptureType.None
                        End If
                     End Try
                     If image Is Nothing Then
                        _captureType = CaptureType.None
                     End If
                     UpdateMyControls()
                  Loop While (_captureType = CaptureType.ActiveClient) AndAlso (_isHotKeyEnabled)

               Case CaptureType.FullScreen
                  Do
                     Dim image As RasterImage = Nothing
                     Try
                        image = _engine.CaptureFullScreen(_captureInformation)
                     Catch ex As RasterException
                        If ex.Message = "UserAbort" OrElse ex.Message = "User has aborted operation" Then
                           _captureType = CaptureType.None
                        End If
                     End Try
                     If image Is Nothing Then
                        _captureType = CaptureType.None
                     End If
                     UpdateMyControls()
                  Loop While (_captureType = CaptureType.FullScreen) AndAlso (_isHotKeyEnabled)

               Case CaptureType.SelectedObject
                  Do
                     Dim image As RasterImage = Nothing
                     Try
                        image = _engine.CaptureSelectedObject(_objectOptions, _captureInformation)
                     Catch ex As RasterException
                        If ex.Message = "UserAbort" OrElse ex.Message = "User has aborted operation" Then
                           _captureType = CaptureType.None
                        End If
                     End Try
                     If image Is Nothing Then
                        _captureType = CaptureType.None
                     End If
                     UpdateMyControls()
                  Loop While (_captureType = CaptureType.SelectedObject) AndAlso (_isHotKeyEnabled)

               Case CaptureType.MenuUnderCursor
                  Do
                     Dim image As RasterImage = Nothing
                     Try
                        image = _engine.CaptureMenuUnderCursor(_captureInformation)
                     Catch ex As RasterException
                        If ex.Message = "UserAbort" OrElse ex.Message = "User has aborted operation" Then
                           _captureType = CaptureType.None
                        End If
                     End Try
                     If image Is Nothing Then
                        _captureType = CaptureType.None
                     End If
                     UpdateMyControls()
                  Loop While (_captureType = CaptureType.MenuUnderCursor) AndAlso (_isHotKeyEnabled)

               Case CaptureType.Area
                  Do
                     Dim image As RasterImage = Nothing
                     Try
                        image = _engine.CaptureArea(_areaOptions, _captureInformation)
                     Catch ex As RasterException
                        If ex.Message = "UserAbort" OrElse ex.Message = "User has aborted operation" Then
                           _captureType = CaptureType.None
                        End If
                     End Try
                     If image Is Nothing Then
                        _captureType = CaptureType.None
                     End If
                     UpdateMyControls()
                  Loop While (_captureType = CaptureType.Area) AndAlso (_isHotKeyEnabled)

               Case CaptureType.WallPaper
                  Do
                     Dim image As RasterImage = Nothing
                     Try
                        image = _engine.CaptureWallpaper(_captureInformation)
                     Catch ex As RasterException
                        If ex.Message = "UserAbort" OrElse ex.Message = "User has aborted operation" Then
                           _captureType = CaptureType.None
                        End If
                     End Try
                     If image Is Nothing Then
                        _captureType = CaptureType.None
                     End If
                     UpdateMyControls()
                  Loop While (_captureType = CaptureType.WallPaper) AndAlso (_isHotKeyEnabled)

               Case CaptureType.MouseCursor
                  Do
                     Dim image As RasterImage = Nothing
                     Try
                        image = _engine.CaptureMouseCursor(Color.Yellow, _captureInformation)
                     Catch ex As RasterException
                        If ex.Message = "UserAbort" OrElse ex.Message = "User has aborted operation" Then
                           _captureType = CaptureType.None
                        End If
                     End Try
                     If image Is Nothing Then
                        _captureType = CaptureType.None
                     End If
                     UpdateMyControls()
                  Loop While (_captureType = CaptureType.MouseCursor) AndAlso (_isHotKeyEnabled)

               Case CaptureType.WindowUnderCursor
                  Do
                     Dim image As RasterImage = Nothing
                     Try
                        image = _engine.CaptureWindowUnderCursor(_captureInformation)
                     Catch ex As RasterException
                        If ex.Message = "UserAbort" OrElse ex.Message = "User has aborted operation" Then
                           _captureType = CaptureType.None
                        End If
                     End Try
                     If image Is Nothing Then
                        _captureType = CaptureType.None
                     End If
                     UpdateMyControls()
                  Loop While (_captureType = CaptureType.WindowUnderCursor) AndAlso (_isHotKeyEnabled)
            End Select
         Catch ex As Exception
            If ex.Message <> "NoImage" AndAlso ex.Message <> "UserAbort" AndAlso ex.Message <> "Invalid image" AndAlso ex.Message <> "User has aborted operation" AndAlso ex.Message <> "No menu" Then
               Messager.ShowError(Me, ex)
            End If

            _captureType = CaptureType.None
            UpdateMyControls()
            UpdateStatusBarText()

            If _minimizeOnCapture Then
               Me.WindowState = _previousWindowState
            End If
         End Try
      End Sub

      ' Capture Menu - Stop Capture
      Private Sub _miCaptureStopCapture_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _miCaptureStopCapture.Click
         _captureType = CaptureType.None
         _engine.StopCapture()
         UpdateMyControls()
         UpdateStatusBarText()
      End Sub

      ' Capture Menu - Capture From Exe Dialog - Tree View
      Private Sub _miCaptureFromExeDialogTree_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _miCaptureFromExeDialogTree.Click
         _captureType = CaptureType.FromExeTree
         _engine.StopCapture()
         UpdateMyControls()
         UpdateStatusBarText()

         Try
            Dim image As RasterImage = _engine.ShowCaptureFromExeDialog(String.Empty, Color.Transparent, ScreenCaptureResourceType.Icon Or ScreenCaptureResourceType.Cursor Or ScreenCaptureResourceType.Bitmap, ScreenCaptureFromExeDialogType.TreeView, ScreenCaptureDialogFlags.None, _captureInformation, Nothing)
            If image Is Nothing Then
               _captureType = CaptureType.None
            End If
            UpdateMyControls()
         Catch ex As Exception
            Messager.ShowError(Me, ex)
         End Try

         _captureType = CaptureType.None
         UpdateStatusBarText()
      End Sub

      ' Capture Menu - Capture From Exe Dialog - Tabbed View
      Private Sub _miCaptureFromExeDialogTabbedView_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _miCaptureFromExeDialogTabbedView.Click
         _captureType = CaptureType.FromExeTab
         _engine.StopCapture()
         UpdateMyControls()
         UpdateStatusBarText()

         Try
            Dim image As RasterImage = _engine.ShowCaptureFromExeDialog(String.Empty, Color.Transparent, ScreenCaptureResourceType.Icon Or ScreenCaptureResourceType.Cursor Or ScreenCaptureResourceType.Bitmap, ScreenCaptureFromExeDialogType.TabView, ScreenCaptureDialogFlags.None, _captureInformation, Nothing)
            If image Is Nothing Then
               _captureType = CaptureType.None
            End If
            UpdateMyControls()
         Catch ex As Exception
            Messager.ShowError(Me, ex)
         End Try

         _captureType = CaptureType.None
         UpdateStatusBarText()
      End Sub

      Private Sub MainForm_Activated(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Activated
         If _captureType <> CaptureType.None Then
            _captureType = CaptureType.None
            _engine.StopCapture()
            UpdateMyControls()
            UpdateStatusBarText()
         End If
      End Sub
   End Class
End Namespace
