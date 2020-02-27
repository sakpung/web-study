' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Windows.Forms
Imports Leadtools.ScreenCapture
Imports PrintToPACSDemo
Imports Leadtools
Imports System.IO

Namespace PrintToPACSDemo
   Public Partial Class FrmMain

	  Private _engine As ScreenCaptureEngine = Nothing
	  Private _areaOptions As ScreenCaptureAreaOptions
	  Private _objectOptions As ScreenCaptureObjectOptions
	  Private _options As ScreenCaptureOptions
	  Private _isHotKeyEnabled As Boolean
	  Private _captureType As CaptureType
   Private _captureInformation As ScreenCaptureInformation = Nothing

	  Private Sub _engine_CaptureInformation(ByVal sender As Object, ByVal e As ScreenCaptureInformationEventArgs)
		 Dim imagecollection As ListImageBox.ImageCollection = New ListImageBox.ImageCollection("Captured Image")
		 Dim page As Page = New Page()
		 Dim strTemp As String = Nothing
		 page = New Page()
		 strTemp = Path.GetTempFileName()
		 _codec.Save(e.Image, strTemp, RasterImageFormat.Tif, 0)
		 page.FilePath = strTemp
		 page.DeleteOnDispose = True
		 imagecollection.Images.Add(New ListImageBox.ImageItem(_codec.Load(strTemp), imagecollection, page))
		 e.Image.Dispose()

		 _lstBoxPages.AddImageCollection(imagecollection)
		 _captureType = CaptureType.None
		 _engine.StopCapture()
		 UpdateScreenCaptureItems()
		 Me.Invalidate()
	  End Sub

	  Private Sub InitializeScreenCapture()
		 ScreenCaptureEngine.Startup()
		 ' initialize Screen Capture Variables
		 _engine = New ScreenCaptureEngine()
   AddHandler _engine.CaptureInformation, AddressOf _engine_CaptureInformation
		 _areaOptions = ScreenCaptureEngine.DefaultCaptureAreaOptions
		 _objectOptions = ScreenCaptureEngine.DefaultCaptureObjectOptions
		 _options = _engine.CaptureOptions
		 _isHotKeyEnabled = True
	  End Sub

	  Private Shared Sub FinilizeScreenCapture()
		 ScreenCaptureEngine.Shutdown()
	  End Sub

	  Private Sub _miCaptureOptions_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _miCaptureOptions.Click
		 Dim bTopMost As Boolean = logWindow.TopMost
		 logWindow.TopMost = False
		 If _captureType <> CaptureType.None Then
			_captureType = CaptureType.None
			_engine.StopCapture()
			UpdateScreenCaptureItems()
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
		 logWindow.TopMost = bTopMost
	  End Sub

	  Private Sub _miCaptureAreaOptions_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _miCaptureAreaOptions.Click
		 Dim bTopMost As Boolean = logWindow.TopMost
		 logWindow.TopMost = False
		 If _captureType <> CaptureType.None Then
			_captureType = CaptureType.None
			_engine.StopCapture()
			UpdateScreenCaptureItems()
		 End If

		 Try
			_areaOptions = _engine.ShowCaptureAreaOptionsDialog(Me, ScreenCaptureDialogFlags.None, _areaOptions, False, Nothing)
		 Catch ex As Exception
			If ex.Message <> "UserAbort" AndAlso ex.Message <> "User has aborted operation" Then
			   Messager.ShowError(Me, ex)
			End If
		 End Try
		 logWindow.TopMost = bTopMost
	  End Sub

	  Private Sub _miCaptureObjectOptions_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _miCaptureObjectOptions.Click
		 Dim bTopMost As Boolean = logWindow.TopMost
		 logWindow.TopMost = False
		 If _captureType <> CaptureType.None Then
			_captureType = CaptureType.None
			_engine.StopCapture()
			UpdateScreenCaptureItems()
		 End If

		 Try
			_objectOptions = _engine.ShowCaptureObjectOptionsDialog(Me, ScreenCaptureDialogFlags.None, _objectOptions, False, Nothing)
		 Catch ex As Exception
			If ex.Message <> "UserAbort" AndAlso ex.Message <> "User has aborted operation" Then
			   Messager.ShowError(Me, ex)
			End If
		 End Try
		 logWindow.TopMost = bTopMost
	  End Sub

	  Private Sub _miCaptureActiveWindow_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _miCaptureActiveWindow.Click
		 DoCapture(CaptureType.ActiveWindow)
	  End Sub

	  Private Sub _miCaptureFullScreen_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _miCaptureFullScreen.Click
		 DoCapture(CaptureType.FullScreen)
	  End Sub

	  Private Sub _miCaptureSelectedObject_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _miCaptureSelectedObject.Click
		 DoCapture(CaptureType.SelectedObject)
	  End Sub

	  Private Sub _miCaptureSelectedArea_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _miCaptureSelectedArea.Click
		 DoCapture(CaptureType.Area)
	  End Sub

	  Private Sub _miCaptureStopCapture_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _miCaptureStopCapture.Click
		 _captureType = CaptureType.None
		 _engine.StopCapture()
		 UpdateScreenCaptureItems()
	  End Sub

	  Private Sub UpdateScreenCaptureItems()
		 _miCaptureActiveWindow.Checked = False
		 _miCaptureFullScreen.Checked = False
		 _miCaptureSelectedObject.Checked = False
		 _miCaptureSelectedArea.Checked = False

		 Select Case _captureType
			Case CaptureType.ActiveWindow
			   _miCaptureActiveWindow.Checked = True
			   _miCaptureStopCapture.Enabled = True
			Case CaptureType.FullScreen
			   _miCaptureFullScreen.Checked = True
			   _miCaptureStopCapture.Enabled = True
			Case CaptureType.SelectedObject
			   _miCaptureSelectedObject.Checked = True
			   _miCaptureStopCapture.Enabled = True
			Case CaptureType.Area
			   _miCaptureSelectedArea.Checked = True
			   _miCaptureStopCapture.Enabled = True
			Case Else
			   _miCaptureStopCapture.Enabled = False
		 End Select
	  End Sub

	  Private Sub DoCapture(ByVal captureType As CaptureType)
		 If _isHotKeyEnabled Then
			If _captureType = captureType Then
			   UpdateScreenCaptureItems()
			   Return
			End If
		 End If

		 _mySettings._settings.capturetype = captureType
		 _mySettings.Save()
		 UpdateToolBarState()
		 _captureType = captureType
		 UpdateScreenCaptureItems()
		 _engine.StopCapture()
		 Try
			Select Case captureType
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
					 UpdateScreenCaptureItems()
				  Loop While (_captureType = CaptureType.ActiveWindow) AndAlso (_isHotKeyEnabled)

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
					 UpdateScreenCaptureItems()
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
					 UpdateScreenCaptureItems()
				  Loop While (_captureType = CaptureType.SelectedObject) AndAlso (_isHotKeyEnabled)

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
					 UpdateScreenCaptureItems()
				  Loop While (_captureType = CaptureType.Area) AndAlso (_isHotKeyEnabled)
			End Select
		 Catch ex As Exception
			Dim bTopMost As Boolean = logWindow.TopMost
			logWindow.TopMost = False
			If ex.Message <> "NoImage" AndAlso ex.Message <> "UserAbort" AndAlso ex.Message <> "Invalid image" AndAlso ex.Message <> "User has aborted operation" AndAlso ex.Message <> "No menu" Then
			   Messager.ShowError(Me, ex)
			End If
			logWindow.TopMost = bTopMost
			_captureType = CaptureType.None
			UpdateScreenCaptureItems()
		 End Try
	  End Sub
   End Class
   Public Enum CaptureType
	  None
	  ActiveWindow
	  FullScreen
	  SelectedObject
	  Area
   End Enum

End Namespace
