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
Imports System.Configuration
Imports System.IO
Imports Microsoft.Win32
Imports System.Threading
Imports Leadtools
Imports Leadtools.Jpip
Imports Leadtools.Jpip.Client.InteractiveDecoder
Imports Leadtools.Jpip.Client.WinForms
Imports System.Net

#If LEADTOOLS_V17_OR_LATER Then
Imports Leadtools.Drawing
#End If

#If Not LEADTOOLS_V17_OR_LATER Then
Imports LeadPoint = System.Drawing.Point
Imports LeadSize = System.Drawing.Size
Imports LeadRect = System.Drawing.Rectangle
#End If ' #if !LEADTOOLS_V17_OR_LATER
#If LEADTOOLS_V19_OR_LATER Then
Imports Leadtools.Demos.Dialogs
#End If

   Partial Public Class MainForm : Inherits Form
      Private Const MainFormTitle As String = "JPIP Client Demo"
      Private _jpipRasterImageViewer As JpipRasterImageViewer = Nothing
      Private _jpipOpenFileDlg As FileOpenDialog = Nothing

      Public Sub New()
         InitializeComponent()

         Me.Text = MainFormTitle

         Messager.Caption = Me.Text

         _jpipOpenFileDlg = New FileOpenDialog()

         _jpipRasterImageViewer = New JpipRasterImageViewer()

         AddHandler _jpipRasterImageViewer.TotalBytesLoaded, AddressOf Me.TotalBytesLoaded
         AddHandler _jpipRasterImageViewer.StreamingError, AddressOf Me.OnError
         AddHandler _jpipRasterImageViewer.FileOpened, AddressOf _jpipRasterImageViewer_FileOpened
         AddHandler _jpipRasterImageViewer.ProgressStatusUpdated, AddressOf _jpipRasterImageViewer_ProgressStatusUpdated
         AddHandler _jpipRasterImageViewer.ResolutionChanged, AddressOf _jpipRasterImageViewer_ResolutionChanged
         AddHandler _jpipRasterImageViewer.CodeStreamRequest, AddressOf _jpipRasterImageViewer_CodeStreamRequest

         Dim configReader As AppSettingsReader = New AppSettingsReader()
         Dim cacheDirectory As String
         Try
            cacheDirectory = CStr(configReader.GetValue("CacheDirectoryName", GetType(String)))
         Catch ex As Exception
            cacheDirectory = Nothing
         End Try

         If cacheDirectory Is Nothing OrElse cacheDirectory = "" OrElse (Not Directory.Exists(cacheDirectory)) Then
            cacheDirectory = LEADToolsImagesFolder
         End If

         Try
            _jpipRasterImageViewer.CacheDirectoryName = cacheDirectory
         Catch ex As Exception
            ShowErrorMessage(Me, ex)
         End Try
         Try
            _jpipRasterImageViewer.PortNumber = CInt(configReader.GetValue("PortNumber", GetType(Integer)))
         Catch
            _jpipRasterImageViewer.PortNumber = 49201
         End Try
         Try
            _jpipRasterImageViewer.IPAddress = CStr(configReader.GetValue("IPAddress", GetType(String)))
         Catch ex As Exception
            _jpipRasterImageViewer.IPAddress = "127.0.0.1"
         End Try
         Try
            _jpipRasterImageViewer.PacketSize = CInt(configReader.GetValue("PacketSize", GetType(Integer)))
         Catch ex As Exception
            _jpipRasterImageViewer.PacketSize = 16384
         End Try
         Try
            _jpipRasterImageViewer.RequestTimeout = TimeSpan.FromSeconds((CDbl(configReader.GetValue("RequestTimeout", GetType(Double)))))
         Catch ex As Exception
            _jpipRasterImageViewer.RequestTimeout = TimeSpan.FromSeconds(60)
         End Try
         Try
            _jpipRasterImageViewer.ChannelType = CStr(configReader.GetValue("ChannelType", GetType(String)))
         Catch ex As Exception
            _jpipRasterImageViewer.ChannelType = "http"
         End Try
         Try
            _jpipOpenFileDlg.ServiceIpAddress = CStr(configReader.GetValue("IPAddress", GetType(String)))
         Catch ex As Exception
            _jpipOpenFileDlg.ServiceIpAddress = "127.0.0.1"
         End Try
         Try
            _jpipOpenFileDlg.ServicePort = CInt(configReader.GetValue("FileEnumerationPortNumber", GetType(Integer)))
         Catch ex As Exception
            _jpipOpenFileDlg.ServicePort = 49202
         End Try

         Select Case _jpipRasterImageViewer.InteractiveMode
            Case Global.Leadtools.WinForms.RasterViewerInteractiveMode.Pan
               Me.panToolStripMenuItem.Checked = True
               Me.zoomToolStripMenuItem.Checked = False

            Case Else
               Me.panToolStripMenuItem.Checked = False
               Me.zoomToolStripMenuItem.Checked = True
         End Select

         EnableControls(False)
         _jpipRasterImageViewer.Dock = DockStyle.Fill
         Me.Controls.Add(_jpipRasterImageViewer)
         _jpipRasterImageViewer.BringToFront()
      End Sub

      Private Sub _jpipRasterImageViewer_ResolutionChanged(ByVal sender As Object, ByVal e As ResolutionChangedEventArgs)
         UpdateCurrentSizeText(e.ImageSize)
         UpdateImageSizeText()
      End Sub

      Private Sub _jpipRasterImageViewer_CodeStreamRequest(ByVal sender As Object, ByVal e As CodeStreamRequestEventArgs)

         If (InvokeRequired) Then

            Me.Invoke(New EventHandler(Of CodeStreamRequestEventArgs)(AddressOf _jpipRasterImageViewer_CodeStreamRequest), New Object() {sender, e})

            Return

         Else

            UpdateCodeStreamCount()

            EnableControls(True)
         End If
      End Sub



      Private Sub _jpipRasterImageViewer_ProgressStatusUpdated(ByVal sender As Object, ByVal e As ProgressStatusUpdatedEventArgs)
         If InvokeRequired Then

            Invoke(New ParameterizedThreadStart(AddressOf UpdateProgressStatus), e.Status)
         Else
            UpdateProgressStatus(e.Status)
         End If
      End Sub

      Private Sub UpdateProgressStatus(ByVal statusObj As Object)
         Dim status As ProgressStatus

         status = CType(statusObj, ProgressStatus)
         Select Case status
            Case ProgressStatus.Completed
               progressStatusLabel.Text = "Image Completely Streamed"


            Case ProgressStatus.Disconnected
               progressStatusLabel.Text = "Disconnected"


            Case ProgressStatus.Idle
               progressStatusLabel.Text = "Region Loaded"


            Case ProgressStatus.Streaming
               progressStatusLabel.Text = "Streaming..."

         End Select
      End Sub

      Private Sub _jpipRasterImageViewer_FileOpened(ByVal sender As Object, ByVal e As EventArgs)
         If InvokeRequired Then

            Me.Invoke(New MethodInvoker(AddressOf UpdateUI))
         Else
            UpdateUI()
         End If
      End Sub

      Private Sub UpdateUI()
         EnableControls(True)
         UpdateComponentIndexText()
         UpdateImageSizeText()
         AddResolutionsMenu()
         UpdateCodeStreamCount()
      End Sub

      Private Sub ConnectionToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles connectionToolStripMenuItem1.Click
         Try
            Dim connectionDialog As ConnectionDialog = New ConnectionDialog()

            connectionDialog.CacheDirectoryName = _jpipRasterImageViewer.CacheDirectoryName
            connectionDialog.PortNumber = _jpipRasterImageViewer.PortNumber
            connectionDialog.IpAddress = _jpipRasterImageViewer.IPAddress
            connectionDialog.PacketSize = _jpipRasterImageViewer.PacketSize
            connectionDialog.RequestTimeout = _jpipRasterImageViewer.RequestTimeout
            connectionDialog.ChannelType = _jpipRasterImageViewer.ChannelType
            connectionDialog.EnumerationServicePort = _jpipOpenFileDlg.ServicePort

            If connectionDialog.ShowDialog() = DialogResult.OK Then

                  _jpipRasterImageViewer.CacheDirectoryName = connectionDialog.CacheDirectoryName
                  _jpipRasterImageViewer.PortNumber = connectionDialog.PortNumber
                  _jpipRasterImageViewer.IPAddress = connectionDialog.IpAddress
                  _jpipRasterImageViewer.PacketSize = connectionDialog.PacketSize
                  _jpipRasterImageViewer.RequestTimeout = connectionDialog.RequestTimeout
                  _jpipRasterImageViewer.ChannelType = connectionDialog.ChannelType

                  _jpipOpenFileDlg.ServiceIpAddress = connectionDialog.IpAddress
                  _jpipOpenFileDlg.ServicePort = connectionDialog.EnumerationServicePort
            End If

         Catch ex As Exception
            ShowErrorMessage(Me, ex)
         End Try

      End Sub

      Private Sub SaveAppSettings()
         Try
            Dim config As System.Configuration.Configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None)

            AddConfigurationValue(config, "CacheDirectoryName", _jpipRasterImageViewer.CacheDirectoryName)
            AddConfigurationValue(config, "PortNumber", _jpipRasterImageViewer.PortNumber.ToString())
            AddConfigurationValue(config, "IPAddress", _jpipRasterImageViewer.IPAddress)
            AddConfigurationValue(config, "PacketSize", _jpipRasterImageViewer.PacketSize.ToString())
            AddConfigurationValue(config, "RequestTimeout", _jpipRasterImageViewer.RequestTimeout.TotalSeconds.ToString())
            AddConfigurationValue(config, "ChannelType", _jpipRasterImageViewer.ChannelType)
            AddConfigurationValue(config, "FileEnumerationPortNumber", _jpipOpenFileDlg.ServicePort.ToString())

            config.Save(ConfigurationSaveMode.Modified)
            ConfigurationManager.RefreshSection("appSettings")
         Catch exception As Exception
            Messager.ShowError(Me, String.Format("Can't write configuration settings, error is:" & Constants.vbLf & "{0}", exception.Message))
         End Try
      End Sub

      Private Sub AddConfigurationValue(ByVal config As System.Configuration.Configuration, ByVal key As String, ByVal value As String)


         If (Nothing Is config.AppSettings.Settings(key)) Then

            config.AppSettings.Settings.Add(key, value)
         Else

            config.AppSettings.Settings(key).Value = value
         End If
      End Sub

      Private Sub NextComponentBottom_Click(ByVal sender As Object, ByVal e As EventArgs) Handles nextComptoolStripButton.Click, nextComponentToolStripMenuItem.Click
         _jpipRasterImageViewer.ComponentIndex += 1
         UpdateComponentIndexText()
      End Sub

      Private Sub ShowAllBottom_Click(ByVal sender As Object, ByVal e As EventArgs) Handles showAllComptoolStripButton.Click, showAllComponenetsToolStripMenuItem1.Click
         _jpipRasterImageViewer.ComponentIndex = -1
         UpdateComponentIndexText()
      End Sub

      Private Sub CleanCacheButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cleanCacheToolStripMenuItem.Click
         If Not _jpipRasterImageViewer Is Nothing Then
            Dim result As DialogResult = Messager.ShowQuestion(Me, "Are you sure you want to clear all cache contents?", MessageBoxButtons.YesNo)
            If result = DialogResult.Yes Then
               Try
                  _jpipRasterImageViewer.DeleteCacheFiles()
               Catch exception As Exception
                  ShowErrorMessage(Me, exception)
               End Try
            End If
         End If
      End Sub

      Private Sub PanZoom_Click(ByVal sender As Object, ByVal e As EventArgs) Handles zoomToolStripMenuItem.Click, panToolStripMenuItem.Click
         Me.panToolStripMenuItem.Checked = Not Me.panToolStripMenuItem.Checked
         Me.zoomToolStripMenuItem.Checked = Not Me.zoomToolStripMenuItem.Checked

         If Me.panToolStripMenuItem.Checked = True Then
            _jpipRasterImageViewer.InteractiveMode = Global.Leadtools.WinForms.RasterViewerInteractiveMode.Pan
         Else
            _jpipRasterImageViewer.InteractiveMode = Global.Leadtools.WinForms.RasterViewerInteractiveMode.None
         End If
      End Sub

      Private Sub ZoomIn_Click(ByVal sender As Object, ByVal e As EventArgs) Handles zoomIntoolStripMenuItem.Click, zoomIntoolStripButton.Click
         Try
            _jpipRasterImageViewer.ZoomIn()
         Catch ex As Exception
            ShowErrorMessage(Me, ex)
         End Try
      End Sub

      Private Sub ZoomOut_Click(ByVal sender As Object, ByVal e As EventArgs) Handles zoomOuttoolStripMenuItem.Click, zoomOuttoolStripButton.Click
         Try
            _jpipRasterImageViewer.ZoomOut()
         Catch ex As Exception
            ShowErrorMessage(Me, ex)
         End Try
      End Sub

      Private Sub ResolutionsToolStripDropDownButton_DropDownOpened(ByVal sender As Object, ByVal e As EventArgs) Handles resolutionsToolStripDropDownButton.DropDownOpened
         Dim currentResolutionIndex As Integer


         currentResolutionIndex = _jpipRasterImageViewer.CurrentResolutionIndex

         If currentResolutionIndex >= 0 AndAlso currentResolutionIndex < resolutionsToolStripDropDownButton.DropDownItems.Count Then
            Me.resolutionsToolStripDropDownButton.DropDownItems(currentResolutionIndex).Select()
         End If
      End Sub

   Private Sub OnResolutionsMenuButtonClick(ByVal sender As Object, ByVal e As EventArgs)
      Try
         Dim index As Integer = Me.resolutionsToolStripDropDownButton.DropDownItems.IndexOf(CType(sender, ToolStripItem))
         System.Diagnostics.Debug.WriteLine(" Resolution = " & _jpipRasterImageViewer.GetResolutionSize(index).ToString())
         _jpipRasterImageViewer.Zoom(_jpipRasterImageViewer.GetResolutionSize(index))
      Catch ex As Exception
         ShowErrorMessage(Me, ex)
      End Try
   End Sub

      Private Sub OpenFileToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles openImageToolStripMenuItem.Click, openFiletoolStripButton.Click
         If _jpipOpenFileDlg.ShowDialog() = DialogResult.OK Then
            Try
               CloseToolStripMenuItem_Click(Me, New EventArgs())
               If _jpipOpenFileDlg.FileName Is Nothing Then
                  Throw New Exception("A file must be selected")
               End If

            'Use Dns.GetHostAddresses to get an actual IP just in case the provided address is a DNS. If
            'it is already an IP, the IP address will not be changed.
            _jpipRasterImageViewer.IPAddress = Dns.GetHostAddresses(_jpipRasterImageViewer.IPAddress)(0).ToString()
            _jpipRasterImageViewer.Open(_jpipOpenFileDlg.FileName)
            Catch ex As Exception
               ShowErrorMessage(Me, ex)
            End Try
         End If
      End Sub

      Private Sub CloseToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles closeToolStripMenuItem1.Click, CloseStripButton.Click
         Try

            Me.Text = MainFormTitle
            _jpipRasterImageViewer.Close()
            UpdateComponentIndexText()
            UpdateImageSizeText()
            UpdateCurrentSizeText(LeadSize.Empty)
            UpdateCodeStreamCount()
            Me.resolutionsToolStripDropDownButton.DropDownItems.Clear()
            ByteCount.Text = ""
            progressStatusLabel.Text = ""
            EnableControls(False)
         Catch exception As Exception
            ShowErrorMessage(Me, exception)
         End Try
      End Sub

      Private Sub ExitToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles exitToolStripMenuItem1.Click
         Me.Close()
      End Sub

      Private Sub TotalBytesLoaded(ByVal sender As Object, ByVal e As TotalBytesLoadedEventArgs)

         If InvokeRequired Then

            Me.Invoke(New ParameterizedThreadStart(AddressOf UpdateByteCount), e.ByteCount)
         Else
            UpdateByteCount(e.ByteCount)
         End If
      End Sub

      Private Sub UpdateByteCount(ByVal byteCountObj As Object)
         Dim bytesLoaded As Double

         bytesLoaded = (Convert.ToDouble(byteCountObj)) / 1024

         Me.ByteCount.Text = String.Format(" Loaded bytes: {0} KB", bytesLoaded.ToString("0.0"))
      End Sub

      Private Sub OnError(ByVal sender As Object, ByVal e As System.IO.ErrorEventArgs)
         If InvokeRequired Then

            Me.BeginInvoke(New ParameterizedThreadStart(AddressOf CallShowErrorMessage), e.GetException())
         Else
            ShowErrorMessage(Me, e.GetException())
         End If
      End Sub

      Private Sub CallShowErrorMessage(ByVal ExceptionErrorObject As Object)
         Dim ExceptionError As Exception = CType(ExceptionErrorObject, Exception)
         ShowErrorMessage(Me, ExceptionError)
      End Sub

      Private Sub AddResolutionsMenu()
         Try
            Me.resolutionsToolStripDropDownButton.DropDownItems.Clear()
            If Not _jpipRasterImageViewer Is Nothing AndAlso _jpipRasterImageViewer.IsActive = True Then
               Dim numOfRes As Integer = _jpipRasterImageViewer.NumberOfResolutions
               Dim r As Integer = 0

               Do While r < numOfRes
               Dim resSize As LeadSize = _jpipRasterImageViewer.GetResolutionSize(r)
               Dim sizeString As String = resSize.Width.ToString() & "x" & resSize.Height.ToString()
               Me.resolutionsToolStripDropDownButton.DropDownItems.Add(sizeString, Nothing, New EventHandler(AddressOf OnResolutionsMenuButtonClick))
               r += 1
               Loop
            End If
         Catch ex As Exception
            ShowErrorMessage(Me, ex)
         End Try
      End Sub
      Private Sub UpdateCodeStreamCount()
         Try
         Dim codeStreamCount As Integer
         Dim codestreamIndex As Integer

         codeStreamCount = 0
         codestreamIndex = 0

         If Not _jpipRasterImageViewer Is Nothing AndAlso _jpipRasterImageViewer.IsActive = True Then
            codeStreamCount = _jpipRasterImageViewer.CodeStreamCount
            codestreamIndex = _jpipRasterImageViewer.CodeStream + 1
         End If
            Me.CodeStreamCount.Text = String.Format(" [Number Of Frames: ({0}), Current: {1}]", codeStreamCount, codestreamIndex)
         Catch ex As Exception

         End Try
      End Sub

      Private Sub UpdateImageSizeText()
         Dim width As Integer = 0
         Dim height As Integer = 0
         If Not _jpipRasterImageViewer Is Nothing AndAlso _jpipRasterImageViewer.IsActive = True Then
            width = _jpipRasterImageViewer.FullImageSize.Width
            height = _jpipRasterImageViewer.FullImageSize.Height
         End If
         Me.ImageSize.Text = String.Format("Full Size: ({0},{1})", width, height)
      End Sub

   Private Sub UpdateCurrentSizeText(ByVal imageSize As LeadSize)
      Me.CurrentSize.Text = String.Format("Current Size: ({0},{1})", imageSize.Width, imageSize.Height)
   End Sub

      Private Sub UpdateComponentIndexText()
         If Not _jpipRasterImageViewer Is Nothing AndAlso _jpipRasterImageViewer.IsActive = True Then
            If _jpipRasterImageViewer.ComponentIndex < 0 Then
               Me.CompIndex.Text = String.Format("Comp Index: All")
            Else
               Me.CompIndex.Text = String.Format("Comp Index: {0}", _jpipRasterImageViewer.ComponentIndex)
            End If
         Else
            Me.CompIndex.Text = ""
         End If
      End Sub

      Private Sub EnableControls(ByVal isEnabled As Boolean)
         Me.modeToolStripMenuItem.Enabled = isEnabled
         Me.panToolStripMenuItem.Enabled = isEnabled
         Me.zoomToolStripMenuItem.Enabled = isEnabled

         Me.zoomIntoolStripButton.Enabled = isEnabled
         Me.zoomOuttoolStripButton.Enabled = isEnabled
         Me.nextComptoolStripButton.Enabled = isEnabled
         Me.showAllComptoolStripButton.Enabled = isEnabled
         Me.resolutionsToolStripDropDownButton.Enabled = isEnabled

         Me.viewToolStripMenuItem.Enabled = isEnabled
         Me.zoomIntoolStripMenuItem.Enabled = isEnabled
         Me.zoomOuttoolStripMenuItem.Enabled = isEnabled
         Me.nextComponentToolStripMenuItem.Enabled = isEnabled
         Me.showAllComponenetsToolStripMenuItem1.Enabled = isEnabled
         Me.modeToolStripMenuItem.Enabled = isEnabled
         Me.panToolStripMenuItem.Enabled = isEnabled
         Me.zoomToolStripMenuItem.Enabled = isEnabled

         If (isEnabled) Then

            If (_jpipRasterImageViewer.CodeStreamCount > 0) Then

               If (_jpipRasterImageViewer.CodeStream < _jpipRasterImageViewer.CodeStreamCount - 1) Then

                  nextCodeStreamToolStripButton.Enabled = isEnabled
               End If

               If (_jpipRasterImageViewer.CodeStream > 0) Then

                  previousCodeStreamToolStripButton.Enabled = isEnabled
               End If
            Else

               nextCodeStreamToolStripButton.Enabled = False
               previousCodeStreamToolStripButton.Enabled = False
            End If
         Else

            nextCodeStreamToolStripButton.Enabled = False
            previousCodeStreamToolStripButton.Enabled = False
         End If
      End Sub

      Private Sub ShowErrorMessage(ByVal owner As IWin32Window, ByVal ex As Exception)
         If IsDisposed Then
            Return
         End If

         Dim message As String
         message = ex.Message
         If TypeOf ex Is System.Net.WebException Then
            Dim webExc As System.Net.WebException = CType(ex, System.Net.WebException)
            If (Not Nothing Is webExc.Response) AndAlso (TypeOf webExc.Response Is System.Net.HttpWebResponse) Then
               Dim response As System.Net.HttpWebResponse = CType(webExc.Response, System.Net.HttpWebResponse)
               message &= Constants.vbLf & "Server Error:" & Constants.vbLf + response.StatusDescription
            End If
         End If
         Messager.ShowError(owner, message)
      End Sub

   Private Sub aboutToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles aboutToolStripMenuItem.Click
#If LEADTOOLS_V19_OR_LATER Then
      Using aboutDialog As New AboutDialog("JPIP Client", ProgrammingInterface.VB)
         aboutDialog.ShowDialog(Me)
      End Using
#Else
      Using aboutDialog As New AboutDialog("JPIP Client")
	      aboutDialog.ShowDialog(Me)
      End Using
#End If
   End Sub

      Private Shared ReadOnly Property LEADToolsImagesFolder() As String
         Get
            Return DemosGlobal.ImagesFolder
         End Get
      End Property

   Private Sub MainForm_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing
      If Not RasterSupport.KernelExpired Then
         _jpipRasterImageViewer.Close()
         SaveAppSettings()
         _jpipRasterImageViewer = Nothing
      End If
   End Sub

   Private Sub howToToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles howToToolStripMenuItem.Click
      Try
         DemosGlobal.LaunchHowTo("Jpip.html")
      Catch ex As Exception
         Messager.ShowError(Me, ex.Message)
      End Try
   End Sub

   Private Sub previousCodeStreamToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles previousCodeStreamToolStripButton.Click
      Try

         If (_jpipRasterImageViewer.CodeStream <= 0) Then

            Return
         End If

         _jpipRasterImageViewer.SetCodeStreamIndex(_jpipRasterImageViewer.CodeStream - 1)

         EnableControls(False)

      Catch ex As Exception
         ShowErrorMessage(Me, ex)
      End Try
   End Sub

Private Sub nextCodeStreamToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nextCodeStreamToolStripButton.Click
         Try

            Dim streamCount As Integer


            streamCount = _jpipRasterImageViewer.CodeStreamCount

            If (_jpipRasterImageViewer.CodeStream >= streamCount - 1) Then

               Return
            End If

            _jpipRasterImageViewer.SetCodeStreamIndex(_jpipRasterImageViewer.CodeStream + 1)

            EnableControls(False)

         Catch ex As Exception
            ShowErrorMessage(Me, ex)
         End Try
End Sub

   Private Sub resolutionsToolStripDropDownButton_DropDownOpening(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles resolutionsToolStripDropDownButton.DropDownOpening
         AddResolutionsMenu()
   End Sub

Private Sub MainForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
         Dim configReader As AppSettingsReader = New AppSettingsReader()
      Dim showOverview As Boolean


      Try
         showOverview = CBool(configReader.GetValue("ShowOverView", GetType(Boolean)))
      Catch e1 As Exception
         showOverview = True
      End Try


      If showOverview Then
         Dim overviewDlg As DemoOverViewDialog



         overviewDlg = New DemoOverViewDialog()

         overviewDlg.TopLevel = True

         overviewDlg.Show(Me)
      End If


End Sub
End Class
