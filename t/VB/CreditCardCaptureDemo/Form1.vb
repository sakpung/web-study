' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************

Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports Leadtools
Imports Leadtools.Drawing
Imports Leadtools.Multimedia
Imports LMVCallbackLib
Imports Leadtools.Demos
Imports Leadtools.Demos.Dialogs
Imports Leadtools.Codecs
Imports Leadtools.CreditCards
Imports System.Diagnostics
Imports System.Text
Imports Leadtools.ImageProcessing
Imports System

Partial Public Class Form1
   Inherits Form
   Private _captureCtrl As CaptureCtrl
   Private _lmvCallBkPlay As ILMVCallback
   Private _lmvMyCallback As Callback

   Public Sub New()
      InitializeComponent()

      _lmvMyCallback = New Callback(Me)
      InitializeCaptureCtrl()
   End Sub

   Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
      RemoveCallback()
   End Sub

   Private Sub Form1_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
      If _lmvMyCallback IsNot Nothing AndAlso _lmvMyCallback.Image IsNot Nothing Then
         Dim destRect As LeadRect = LeadRect.Create(0, 0, Me.ClientSize.Width, Me.ClientSize.Height)

         Using destImage As New RasterImage(RasterMemoryFlags.Conventional, Me.ClientSize.Width, Me.ClientSize.Height, _lmvMyCallback.Image.BitsPerPixel, _lmvMyCallback.Image.Order, _lmvMyCallback.Image.ViewPerspective, _
          _lmvMyCallback.Image.GetPalette(), IntPtr.Zero, 0)
            ' Resize the source image into the destination image
            Dim command As New ResizeCommand()
            command.DestinationImage = destImage
            command.Flags = RasterSizeFlags.Bicubic
            command.Run(_lmvMyCallback.Image)

            destRect = RasterImage.CalculatePaintModeRectangle(destImage.ImageWidth, destImage.ImageHeight, destRect, RasterPaintSizeMode.FitAlways, RasterPaintAlignMode.Center, RasterPaintAlignMode.Center)
            Dim destClipRect As LeadRect = LeadRect.Create(e.ClipRectangle.X, e.ClipRectangle.Y, e.ClipRectangle.Width, e.ClipRectangle.Height)

            Using rg As RasterGraphics = RasterImagePainter.CreateGraphics(destImage)
               rg.Graphics.DrawRectangle(New Pen(Color.Red), _lmvMyCallback.GuideRect.X, _lmvMyCallback.GuideRect.Y, _lmvMyCallback.GuideRect.Width, _lmvMyCallback.GuideRect.Height)
            End Using

            RasterImagePainter.Paint(destImage, e.Graphics, LeadRect.Empty, LeadRect.Empty, destRect, destClipRect, _
             RasterPaintProperties.[Default])
         End Using
      End If
   End Sub

   Public Sub RemoveCallback()
      If _lmvMyCallback IsNot Nothing Then
         _lmvMyCallback.Dispose()
      End If

      For Each vp As Processor In _captureCtrl.VideoProcessors
         If vp.FriendlyName.Equals("LEAD Video Callback Filter (2.0)") Then
            _captureCtrl.SelectedVideoProcessors.Remove(vp)
            Exit For
         End If
      Next
   End Sub

   Private Sub InitializeCaptureCtrl()
      _captureCtrl = New CaptureCtrl()
      CType(_captureCtrl, System.ComponentModel.ISupportInitialize).BeginInit()
      _captureCtrl.AudioCompressors.Selection = -1
      _captureCtrl.AudioDevices.Selection = -1
      _captureCtrl.Location = New Point(0, 0)
      _captureCtrl.Name = "_captureCtrl"
      _captureCtrl.Size = New Size(618, 382)
      _captureCtrl.TabIndex = 3
      _captureCtrl.TargetDevices.Selection = -1
      _captureCtrl.VideoCompressors.Selection = -1
      _captureCtrl.VideoDevices.Selection = -1
      _captureCtrl.WMProfile.Description = ""
      _captureCtrl.WMProfile.Name = ""
      _captureCtrl.VideoWindowSizeMode = SizeMode.Normal
      _captureCtrl.Preview = True
      _captureCtrl.Visible = False

      Me.MinimumSize = _captureCtrl.Size

      If _captureCtrl.VideoDevices.Count > 0 Then
         For Each dev As Device In _captureCtrl.VideoDevices
            If dev.FriendlyName = "LEAD Screen Capture (2.0)" Then
               Continue For
            End If

            Dim menuItem2 As MenuItem = New MenuItem(dev.FriendlyName)
            _optionsMenuVideoDevice.MenuItems.Add(menuItem2)
            AddHandler menuItem2.Click, AddressOf VideoDevice_Click
         Next
      End If

      Me.Controls.Add(_captureCtrl)

      CType(_captureCtrl, System.ComponentModel.ISupportInitialize).EndInit()
   End Sub

   Private Sub VideoDevice_Click(sender As Object, e As System.EventArgs) Handles _optionsMenuVideoDeviceNone.Click
      'Point to menu item clicked
      Dim objCurMenuItem As MenuItem = CType(sender, MenuItem)

      For Each item As MenuItem In _optionsMenuVideoDevice.MenuItems
         If item Is objCurMenuItem Then
            item.Checked = True
         Else
            item.Checked = False
         End If
      Next

      Try
         _captureCtrl.VideoDevices.Selection = objCurMenuItem.Index - 1
         AddCallback(_lmvMyCallback)

         If _captureCtrl.VideoDevices.Selection >= 0 Then
            _optionsMenu.MenuItems(2).Enabled = True
         Else
            _optionsMenu.MenuItems(2).Enabled = False
         End If
      Catch
         MessageBox.Show("This video capture device is not available. Make sure no other program is using the device or try changing the display resolution", "Error")
      End Try

      objCurMenuItem = Nothing
   End Sub

   Private Sub CaptureOptions_Click(sender As Object, e As EventArgs) Handles _captureOptions.Click
      _captureCtrl.ShowDialog(CaptureDlg.Capture, Me)
   End Sub

   Private Sub FileExit_Click(sender As Object, e As EventArgs) Handles _fileExit.Click
      _captureCtrl.StopCapture()
      ' Give the threads from the Callback time to stop
      System.Threading.Thread.Sleep(500)

      Me.Close()
   End Sub

   Private Sub AddCallback(pCallback As Object)
      Try
         If _lmvCallBkPlay Is Nothing Then
            For Each vp As Processor In _captureCtrl.VideoProcessors
               If vp.FriendlyName.Equals("LEAD Video Callback Filter (2.0)") Then
                  _captureCtrl.SelectedVideoProcessors.Add(vp)
                  _lmvCallBkPlay = TryCast(_captureCtrl.GetSubObject(CaptureObject.SelVideoProcessor), ILMVCallback)
                  _lmvCallBkPlay.ReceiveProcObj = pCallback
               End If
            Next
         Else
            _lmvCallBkPlay.ReceiveProcObj = pCallback
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message)
      End Try
   End Sub

   Public ReadOnly Property CaptureCtrl() As CaptureCtrl
      Get
         Return _captureCtrl
      End Get
   End Property

   Private Sub _miHelpAbout_Click(sender As Object, e As System.EventArgs) Handles _miHelpAbout.Click
      Using aboutDialog As New AboutDialog("CreditCardCapture", ProgrammingInterface.VB)
         aboutDialog.ShowDialog(Me)
      End Using
   End Sub
End Class
