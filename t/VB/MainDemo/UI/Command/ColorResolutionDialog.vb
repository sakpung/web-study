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

Imports Leadtools
Imports Leadtools.ImageProcessing
Imports Leadtools.ImageProcessing.Color
Imports Leadtools.Drawing
Imports Leadtools.Demos


Namespace MainDemo
   Partial Public Class ColorResolutionDialog : Inherits Form
      Private Shared _initialBitsPerPixel As Integer = 24
      Private Shared _initialOrder As RasterByteOrder = RasterByteOrder.Bgr
      Private Shared _initialPaletteFlags As ColorResolutionCommandPaletteFlags = ColorResolutionCommandPaletteFlags.Optimized
      Private Shared _initialDitheringMethod As RasterDitheringMethod = RasterDitheringMethod.None
      Private WithEvents _beforeViewer As ImagePreviewCtrl
      Private WithEvents _afterViewer As ImagePreviewCtrl
      Private _originalImage As RasterImage
      Private _afterImage As RasterImage

      Public BitsPerPixel As Integer = -1
      Public Order As RasterByteOrder
      Public PaletteFlags As ColorResolutionCommandPaletteFlags
      Public DitheringMethod As RasterDitheringMethod
      Public _tempBitsPerPixel As Integer = -1
      Public _tempOrder As RasterByteOrder
      Public _tempPaletteFlags As ColorResolutionCommandPaletteFlags
      Public _tempDitheringMethod As RasterDitheringMethod


      Private Enum MyPaletteType
         Fixed = ColorResolutionCommandPaletteFlags.Fixed
         Optimized = ColorResolutionCommandPaletteFlags.Optimized
         Netscape = ColorResolutionCommandPaletteFlags.Netscape
      End Enum

      Public Sub New(ByVal image As RasterImage, ByVal paintProperties As RasterPaintProperties)
         InitializeComponent()

         If Not image Is Nothing Then
            Dim clone As CloneCommand = New CloneCommand()

            clone.Run(image)

            _originalImage = image
            _afterImage = clone.DestinationImage

            _beforeViewer = New ImagePreviewCtrl(_originalImage, paintProperties, _lblBefore.Location, _lblBefore.Size)
            _afterViewer = New ImagePreviewCtrl(_afterImage, paintProperties, _lblAfter.Location, _lblAfter.Size)

            Controls.Add(_beforeViewer)
            Controls.Add(_afterViewer)
            _beforeViewer.BringToFront()
            _afterViewer.BringToFront()
         Else
            _tsZoomLevel.Visible = False
         End If
      End Sub

      Private Sub ColorResolutionDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
         If Not _beforeViewer Is Nothing Then
            If Not _beforeViewer.Image Is Nothing Then
               _tsbtnFit.Checked = False
               _tsbtnNormal.Checked = True
            End If
         End If

         If BitsPerPixel = -1 Then
            BitsPerPixel = _initialBitsPerPixel
         End If

         Order = _initialOrder
         PaletteFlags = _initialPaletteFlags
         DitheringMethod = _initialDitheringMethod

         Dim bitsPerPixelList As Integer() = {1, 2, 3, 4, 5, 6, 7, 8, 12, 16, 24, 32, 48, 64}
         For Each i As Integer In bitsPerPixelList
            _cbBitsPerPixel.Items.Add(i)
            If BitsPerPixel = i Then
               _cbBitsPerPixel.SelectedItem = i
            End If
         Next i

         Dim a As Array = System.Enum.GetValues(GetType(MyPaletteType))
         For Each i As MyPaletteType In a
            _cbPalette.Items.Add(i)
            If CInt(PaletteFlags) = CInt(i) Then
               _cbPalette.SelectedItem = i
            End If
         Next i

         If _cbPalette.SelectedItem Is Nothing Then
            _cbPalette.SelectedIndex = 0
         End If

         Tools.FillComboBoxWithEnum(_cbDither, GetType(RasterDitheringMethod), DitheringMethod)

         GetUpdateValues()
         UpdateMyControls()
      End Sub

      Private Sub _tsbtnNormal_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _tsbtnNormal.Click
         If Not _beforeViewer.Image Is Nothing Then
            _tsbtnFit.Checked = False
            _tsbtnNormal.Checked = True

            _beforeViewer.FitView = False
            _afterViewer.FitView = False
         End If
      End Sub

      Private Sub _tsbtnFit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _tsbtnFit.Click
         If Not _beforeViewer.Image Is Nothing Then
            _tsbtnFit.Checked = True
            _tsbtnNormal.Checked = False

            _beforeViewer.FitView = True
            _afterViewer.FitView = True
         End If
      End Sub

      Private Sub UpdateMyControls()
         Dim bitsPerPixelList As Integer = CInt(_cbBitsPerPixel.SelectedItem)
         _cbPalette.Enabled = bitsPerPixelList <= 8
         _cbDither.Enabled = bitsPerPixelList <= 8

         If bitsPerPixelList <= 8 Then
            _cbOrder.Items.Clear()
            _cbOrder.Items.Add(Leadtools.Demos.Constants.GetNameFromValue(GetType(RasterByteOrder), RasterByteOrder.Rgb))
            _cbOrder.Enabled = False

            If _cbPalette.Enabled Then
               Dim selectedPalette As MyPaletteType
               If Not _cbPalette.SelectedItem Is Nothing Then
                  selectedPalette = CType(_cbPalette.SelectedItem, MyPaletteType)
               Else
                  selectedPalette = MyPaletteType.Fixed
               End If

               _cbPalette.Items.Clear()

               Dim a As Array = System.Enum.GetValues(GetType(MyPaletteType))
               For Each i As MyPaletteType In a
                  If bitsPerPixelList = 8 OrElse i <> MyPaletteType.Netscape Then
                     _cbPalette.Items.Add(i)
                     If i = selectedPalette Then
                        _cbPalette.SelectedItem = i
                     End If
                  End If
               Next i

               If _cbPalette.SelectedItem Is Nothing Then
                  _cbPalette.SelectedIndex = 0
               End If

               _cbOrder.SelectedIndex = 0
            End If
         ElseIf bitsPerPixelList = 12 Then
            _cbOrder.Items.Clear()
            _cbOrder.Items.Add(Leadtools.Demos.Constants.GetNameFromValue(GetType(RasterByteOrder), RasterByteOrder.Gray))
            _cbOrder.SelectedIndex = 0
            _cbOrder.Enabled = False
         ElseIf bitsPerPixelList = 16 Then
            _cbOrder.Items.Clear()
            Tools.FillComboBoxWithEnum(_cbOrder, GetType(RasterByteOrder), Order, New Object() {RasterByteOrder.Romm})
            If _cbOrder.SelectedItem Is Nothing Then
               _cbOrder.SelectedItem = RasterByteOrder.Bgr
            End If
            _cbOrder.Enabled = True
         Else
            _cbOrder.Items.Clear()
            Tools.FillComboBoxWithEnum(_cbOrder, GetType(RasterByteOrder), Order, New Object() {RasterByteOrder.Gray, RasterByteOrder.Romm, RasterByteOrder.Rgb565})
            If _cbOrder.SelectedItem Is Nothing Then
               _cbOrder.SelectedItem = RasterByteOrder.Bgr
            End If
            _cbOrder.Enabled = True
         End If

         UpdateValues()
      End Sub

      Private Sub _cbBitsPerPixel_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cbBitsPerPixel.SelectedIndexChanged
         UpdateMyControls()
      End Sub

      Private Sub SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cbDither.SelectedIndexChanged, _cbPalette.SelectedIndexChanged, _cbOrder.SelectedIndexChanged
         GetUpdateValues()
         UpdateValues()
      End Sub

      Private Sub _btnOk_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _btnOk.Click
         BitsPerPixel = CInt(_cbBitsPerPixel.SelectedItem)
         Order = CType(Leadtools.Demos.Constants.GetValueFromName(GetType(RasterByteOrder), CStr(_cbOrder.SelectedItem), _initialOrder), RasterByteOrder)
         PaletteFlags = ColorResolutionCommandPaletteFlags.None
         Dim myPalette As MyPaletteType = CType(_cbPalette.SelectedItem, MyPaletteType)
         Select Case myPalette
            Case MyPaletteType.Fixed
               PaletteFlags = PaletteFlags Or ColorResolutionCommandPaletteFlags.Fixed
            Case MyPaletteType.Optimized
               PaletteFlags = PaletteFlags Or ColorResolutionCommandPaletteFlags.Optimized
            Case MyPaletteType.Netscape
               PaletteFlags = PaletteFlags Or ColorResolutionCommandPaletteFlags.Netscape
         End Select

         DitheringMethod = CType(Leadtools.Demos.Constants.GetValueFromName(GetType(RasterDitheringMethod), CStr(_cbDither.SelectedItem), _initialDitheringMethod), RasterDitheringMethod)

         _initialBitsPerPixel = BitsPerPixel
         _initialOrder = Order
         _initialPaletteFlags = PaletteFlags
         _initialDitheringMethod = DitheringMethod
      End Sub

      Protected Sub UpdateValues()
         Try
            Dim tempImage As RasterImage
            Dim clone As CloneCommand = New CloneCommand()

            clone.Run(_originalImage)

            tempImage = clone.DestinationImage

            If DoEffect(tempImage) Then
               If Not _afterImage Is Nothing Then
                  _afterImage.Dispose()

                  _afterImage = Nothing
               End If

               _afterImage = tempImage

               _afterViewer.Image = _afterImage

               _afterViewer.OffsetImage(_beforeViewer.Offset)

               _afterViewer.Invalidate()
            End If
         Catch ex As Exception
            Messager.ShowError(Me, ex)
         End Try
      End Sub

      Protected Overridable Function DoEffect(ByRef effectedImage As RasterImage) As Boolean
         Try
            Dim command As ColorResolutionCommand = New ColorResolutionCommand(ColorResolutionCommandMode.InPlace, _tempBitsPerPixel, _tempOrder, _tempDitheringMethod, _tempPaletteFlags, Nothing)

            AddHandler command.Progress, AddressOf command_Progress

            command.Run(effectedImage)

            _pbProgress.Value = 0
         Catch ex As Exception
            Throw ex
         End Try
         Return True
      End Function

      Private Sub command_Progress(ByVal sender As Object, ByVal e As RasterCommandProgressEventArgs)
         _pbProgress.Value = e.Percent
      End Sub

      Private Sub GetUpdateValues()
         _tempBitsPerPixel = -1

         If Not _cbBitsPerPixel.SelectedItem Is Nothing Then
            _tempBitsPerPixel = CInt(_cbBitsPerPixel.SelectedItem)
         End If

         _tempOrder = RasterByteOrder.Bgr

         If Not _cbOrder.SelectedItem Is Nothing Then
            _tempOrder = CType(Leadtools.Demos.Constants.GetValueFromName(GetType(RasterByteOrder), CStr(_cbOrder.SelectedItem), _initialOrder), RasterByteOrder)
         End If


         _tempPaletteFlags = ColorResolutionCommandPaletteFlags.None

         If Not _cbPalette.SelectedItem Is Nothing Then
            Dim myPalette As MyPaletteType = CType(_cbPalette.SelectedItem, MyPaletteType)
            Select Case myPalette
               Case MyPaletteType.Fixed
                  _tempPaletteFlags = _tempPaletteFlags Or ColorResolutionCommandPaletteFlags.Fixed
               Case MyPaletteType.Optimized
                  _tempPaletteFlags = _tempPaletteFlags Or ColorResolutionCommandPaletteFlags.Optimized
               Case MyPaletteType.Netscape
                  _tempPaletteFlags = _tempPaletteFlags Or ColorResolutionCommandPaletteFlags.Netscape
            End Select
         End If

         _tempDitheringMethod = RasterDitheringMethod.None

         If Not _cbDither.SelectedItem Is Nothing Then
            _tempDitheringMethod = CType(Leadtools.Demos.Constants.GetValueFromName(GetType(RasterDitheringMethod), CStr(_cbDither.SelectedItem), _initialDitheringMethod), RasterDitheringMethod)
         End If
      End Sub
      Private Sub _beforeViewer_PanImage(ByVal sender As Object, ByVal e As PanImageEvent) Handles _beforeViewer.PanImage
         _afterViewer.OffsetImage(e.Offset)
      End Sub
      Private Sub _afterViewer_PanImage(ByVal sender As Object, ByVal e As PanImageEvent) Handles _afterViewer.PanImage
         _beforeViewer.OffsetImage(e.Offset)
      End Sub
   End Class
End Namespace
