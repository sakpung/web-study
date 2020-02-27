' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms

Imports Leadtools
Imports Leadtools.Controls
Imports Leadtools.ColorConversion

Namespace ColorConversionDemo
   ''' <summary>
   ''' Summary description for ConvertToDialog.
   ''' </summary>
   Public Class ConvertToDialog : Inherits System.Windows.Forms.Form
      Private WithEvents _btnOK As System.Windows.Forms.Button
      Private _btnCancel As System.Windows.Forms.Button
      Private WithEvents _cbFit As System.Windows.Forms.CheckBox
      Private _pnlViewer As System.Windows.Forms.Panel
      Private _gbSwapColors As System.Windows.Forms.GroupBox
      Private WithEvents _cbColorFormat As System.Windows.Forms.ComboBox
      Private _lblWarning As System.Windows.Forms.Label
      ''' <summary>
      ''' Required designer variable.
      ''' </summary>
      Private components As System.ComponentModel.Container = Nothing

      Public Sub New(ByVal image As RasterImage, ByVal srcFormat As ConversionColorFormat)
         '
         ' Required for Windows Form Designer support
         '
         InitializeComponent()

         '
         ' TODO: Add any constructor code after InitializeComponent call
         '
         InitClass(image, srcFormat)
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
         Me._btnOK = New System.Windows.Forms.Button()
         Me._btnCancel = New System.Windows.Forms.Button()
         Me._pnlViewer = New System.Windows.Forms.Panel()
         Me._cbFit = New System.Windows.Forms.CheckBox()
         Me._gbSwapColors = New System.Windows.Forms.GroupBox()
         Me._lblWarning = New System.Windows.Forms.Label()
         Me._cbColorFormat = New System.Windows.Forms.ComboBox()
         Me._gbSwapColors.SuspendLayout()
         Me.SuspendLayout()
         ' 
         ' _btnOK
         ' 
         Me._btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
         Me._btnOK.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._btnOK.Location = New System.Drawing.Point(456, 328)
         Me._btnOK.Name = "_btnOK"
         Me._btnOK.Size = New System.Drawing.Size(75, 23)
         Me._btnOK.TabIndex = 3
         Me._btnOK.Text = "OK"
         ' 
         ' _btnCancel
         ' 
         Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
         Me._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._btnCancel.Location = New System.Drawing.Point(456, 360)
         Me._btnCancel.Name = "_btnCancel"
         Me._btnCancel.Size = New System.Drawing.Size(75, 23)
         Me._btnCancel.TabIndex = 4
         Me._btnCancel.Text = "Cancel"
         ' 
         ' _pnlViewer
         ' 
         Me._pnlViewer.Location = New System.Drawing.Point(8, 40)
         Me._pnlViewer.Name = "_pnlViewer"
         Me._pnlViewer.Size = New System.Drawing.Size(528, 208)
         Me._pnlViewer.TabIndex = 1
         ' 
         ' _cbFit
         ' 
         Me._cbFit.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._cbFit.Location = New System.Drawing.Point(8, 8)
         Me._cbFit.Name = "_cbFit"
         Me._cbFit.Size = New System.Drawing.Size(80, 24)
         Me._cbFit.TabIndex = 0
         Me._cbFit.Text = "&Fit Image"
         ' 
         ' _gbSwapColors
         ' 
         Me._gbSwapColors.Controls.Add(Me._lblWarning)
         Me._gbSwapColors.Controls.Add(Me._cbColorFormat)
         Me._gbSwapColors.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._gbSwapColors.Location = New System.Drawing.Point(8, 256)
         Me._gbSwapColors.Name = "_gbSwapColors"
         Me._gbSwapColors.Size = New System.Drawing.Size(432, 128)
         Me._gbSwapColors.TabIndex = 2
         Me._gbSwapColors.TabStop = False
         Me._gbSwapColors.Text = "&Swap Colors:"
         ' 
         ' _lblWarning
         ' 
         Me._lblWarning.ForeColor = System.Drawing.Color.Red
         Me._lblWarning.Location = New System.Drawing.Point(16, 64)
         Me._lblWarning.Name = "_lblWarning"
         Me._lblWarning.Size = New System.Drawing.Size(400, 48)
         Me._lblWarning.TabIndex = 1
         Me._lblWarning.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
         ' 
         ' _cbColorFormat
         ' 
         Me._cbColorFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
         Me._cbColorFormat.Location = New System.Drawing.Point(16, 32)
         Me._cbColorFormat.Name = "_cbColorFormat"
         Me._cbColorFormat.Size = New System.Drawing.Size(168, 21)
         Me._cbColorFormat.TabIndex = 0
         ' 
         ' ConvertToDialog
         ' 
         Me.AcceptButton = Me._btnOK
         Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
         Me.CancelButton = Me._btnCancel
         Me.ClientSize = New System.Drawing.Size(546, 400)
         Me.Controls.Add(Me._gbSwapColors)
         Me.Controls.Add(Me._pnlViewer)
         Me.Controls.Add(Me._btnCancel)
         Me.Controls.Add(Me._btnOK)
         Me.Controls.Add(Me._cbFit)
         Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
         Me.MaximizeBox = False
         Me.MinimizeBox = False
         Me.Name = "ConvertToDialog"
         Me.ShowInTaskbar = False
         Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
         Me.Text = "Convert"
         Me._gbSwapColors.ResumeLayout(False)
         Me.ResumeLayout(False)

      End Sub
#End Region

      Private _viewer As ImageViewer
      Private _srcFormat As ConversionColorFormat

      ' Original image Buffer
      Private _orgBuffer As Byte()

      ' original image Width
      Private _width As Integer

      ' original image Height
      Private _height As Integer

      ' original image bytes/line
      Private _bytesPerLine As Integer

      Private _resultImage As RasterImage

      Private Structure ConvertItem
         Public Format As ConversionColorFormat
         Public Name As String

         Public Sub New(ByVal f As ConversionColorFormat, ByVal n As String)
            Format = f
            Name = n
         End Sub

         Public Overrides Function ToString() As String
            Return Name
         End Function
      End Structure

      Private Shared _convertItems As ConvertItem() = {New ConvertItem(ConversionColorFormat.Rgb, "RGB"), New ConvertItem(ConversionColorFormat.Yuv, "YUV"), New ConvertItem(ConversionColorFormat.Cmyk, "CMYK"), New ConvertItem(ConversionColorFormat.Hsv, "HSV"), New ConvertItem(ConversionColorFormat.Cmy, "CMY"), New ConvertItem(ConversionColorFormat.Hls, "HLS"), New ConvertItem(ConversionColorFormat.Yiq, "YIQ"), New ConvertItem(ConversionColorFormat.Lab, "LAB"), New ConvertItem(ConversionColorFormat.Xyz, "XYZ"), New ConvertItem(ConversionColorFormat.Yuy2, "YUY2"), New ConvertItem(ConversionColorFormat.Yvu9, "YVU9"), New ConvertItem(ConversionColorFormat.Uyvy, "UYVY"), New ConvertItem(ConversionColorFormat.Ycc, "YCC")}

      Private Sub InitClass(ByVal image As RasterImage, ByVal srcFormat As ConversionColorFormat)
         _viewer = New ImageViewer()
         _viewer.BackColor = Color.DarkGray
         _viewer.ViewHorizontalAlignment = ControlAlignment.Near
         _viewer.Dock = DockStyle.Fill
         _pnlViewer.Controls.Add(_viewer)
         _viewer.BringToFront()
         _viewer.Zoom(ControlSizeMode.Fit, 1, _viewer.DefaultZoomOrigin)

         _cbFit.Checked = _viewer.SizeMode = ControlSizeMode.Fit

         ' Start up the Color conversion toolkit.
         RasterColorConverterEngine.Startup()
         Dim tempImage As RasterImage = image.Clone()
         If tempImage.ViewPerspective <> RasterViewPerspective.TopLeft Then
            tempImage.ChangeViewPerspective(RasterViewPerspective.TopLeft)
         End If

         _width = tempImage.Width
         _height = tempImage.Height
         _bytesPerLine = tempImage.BytesPerLine

         _orgBuffer = New Byte(_bytesPerLine * _height - 1) {}

         tempImage.Access()

         Dim y As Integer = 0
         Do While y < _height - 1
            tempImage.GetRow(y, _orgBuffer, (y * _width * 3), _width * 3)
            y += 1
         Loop

         _viewer.Image = tempImage

         tempImage.Release()

         _srcFormat = srcFormat

         For Each i As ConvertItem In _convertItems
            _cbColorFormat.Items.Add(i)
            If i.Format = ConversionColorFormat.Yuv Then
               _cbColorFormat.SelectedItem = i
            End If
         Next i

         UpdateMyControls()
      End Sub

      Private Sub _cbFit_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)Handles _cbFit.CheckedChanged
         Dim sizeMode As ControlSizeMode = ControlSizeMode.ActualSize

         If _cbFit.Checked Then
            sizeMode = ControlSizeMode.Fit
         End If

         _viewer.Zoom(sizeMode, 1, _viewer.DefaultZoomOrigin)
      End Sub

      Private Sub _cbColorFormat_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)Handles _cbColorFormat.SelectedIndexChanged
         Dim item As ConvertItem = CType(_cbColorFormat.SelectedItem, ConvertItem)
         UpdateMyControls()
         ConvertToColorSpace(item.Format)
      End Sub

      Private Sub ConvertToColorSpace(ByVal colorFormat As ConversionColorFormat)
         If _btnOK.Enabled Then
            Using wait As WaitCursor = New WaitCursor()
               Try
                  Dim bufferSize As Integer

                  If colorFormat = ConversionColorFormat.Cmyk Then
                     bufferSize = CInt((_bytesPerLine * _height) + ((_bytesPerLine * _height) / 3))
                  Else
                     bufferSize = _bytesPerLine * _height
                  End If

                  Dim newBuffer As Byte() = New Byte(bufferSize - 1) {}

                  RasterColorConverterEngine.ConvertDirect(_srcFormat, colorFormat, _orgBuffer, 0, newBuffer, 0, _width, _height, 0, 0)

                  RasterColorConverterEngine.ConvertDirectToImage(colorFormat, _srcFormat, newBuffer, 0, _viewer.Image, _width, _height, 0, (_bytesPerLine - _width * 3))

                  _viewer.Invalidate()

                  For Each i As ConvertItem In _convertItems
                     If i.Format = colorFormat Then
                        MainForm.ConversionType = i.Name
                     End If
                  Next i
               Catch ex As Exception
                  Messager.ShowError(Me, ex.Message)
               End Try
            End Using
         End If
      End Sub

      Private Sub _btnOK_Click(ByVal sender As Object, ByVal e As System.EventArgs)Handles _btnOK.Click
         _viewer.AutoDisposeImages = False
         _resultImage = _viewer.Image
         _viewer.Image = Nothing
         _viewer.AutoDisposeImages = True
      End Sub

      Public ReadOnly Property ResultImage() As RasterImage
         Get
            Return _resultImage
         End Get
      End Property

      Private Sub UpdateMyControls()
         Dim enableOkButton As Boolean = True
         Dim warningMessage As String = String.Empty

         ' For YVU9, the image must have a width and height that is a multiple of 4
         ' For YUY2 and UYVY, the width and height that is a multiple of 2

         Dim item As ConvertItem = CType(_cbColorFormat.SelectedItem, ConvertItem)
         If item.Format = ConversionColorFormat.Yvu9 Then
            If (_width Mod 4) <> 0 OrElse (_height Mod 4) <> 0 Then
               enableOkButton = False
               warningMessage = String.Format("For YVU9 color format, the image must have a width and height value that is a multiple of 4.{0}Current image has a width of {1} and height of {2} pixels.", Environment.NewLine, _width, _height)
            End If
         ElseIf item.Format = ConversionColorFormat.Yuy2 OrElse item.Format = ConversionColorFormat.Uyvy Then
            If (_width Mod 2) <> 0 OrElse (_height Mod 2) <> 0 Then
               enableOkButton = False
               warningMessage = String.Format("For YUY2 and UYVY color format, the image must have a width and height value that is a multiple of 2.{0}Current image has a width of {1} and height of {2} pixels.", Environment.NewLine, _width, _height)
            End If
         End If

         _btnOK.Enabled = enableOkButton
         _lblWarning.Text = warningMessage
      End Sub
   End Class
End Namespace
