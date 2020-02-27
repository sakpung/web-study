' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************

Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms

Imports Leadtools
Imports Leadtools.ImageProcessing
Imports Leadtools.ImageProcessing.Color
Imports System

Namespace AnimationDemo
   Partial Public Class ColorResolutionDialog
      Inherits Form
      Private Shared _initialBitsPerPixel As Integer = 24
      Private Shared _initialOrder As RasterByteOrder = RasterByteOrder.Bgr
      Private Shared _initialPaletteFlags As ColorResolutionCommandPaletteFlags = ColorResolutionCommandPaletteFlags.Optimized
      Private Shared _initialDitheringMethod As RasterDitheringMethod = RasterDitheringMethod.None

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

      Public Sub New(image As RasterImage)
         InitializeComponent()
      End Sub

      Private Sub ColorResolutionDialog_Load(sender As Object, e As System.EventArgs) Handles Me.Load
         If BitsPerPixel = -1 Then
            BitsPerPixel = _initialBitsPerPixel
         End If

         Order = _initialOrder
         PaletteFlags = _initialPaletteFlags
         DitheringMethod = _initialDitheringMethod

         Dim bitsPerPixel__1 As Integer() = {1, 2, 3, 4, 5, 6, _
          7, 8, 12, 16, 24, 32, _
          48, 64}
         For Each i As Integer In bitsPerPixel__1
            _cbBitsPerPixel.Items.Add(i)
            If BitsPerPixel = i Then
               _cbBitsPerPixel.SelectedItem = i
            End If
         Next

         Dim a As Array = [Enum].GetValues(GetType(MyPaletteType))
         For Each i As MyPaletteType In a
            _cbPalette.Items.Add(i)
            If CInt(PaletteFlags) = CInt(i) Then
               _cbPalette.SelectedItem = i
            End If
         Next

         If _cbPalette.SelectedItem Is Nothing Then
            _cbPalette.SelectedIndex = 0
         End If

         Tools.FillComboBoxWithEnum(_cbDither, GetType(RasterDitheringMethod), DitheringMethod)

         GetUpdateValues()
         UpdateMyControls()
      End Sub

      Private Sub UpdateMyControls()
         Dim bitsPerPixel As Integer = CInt(_cbBitsPerPixel.SelectedItem)
         _cbPalette.Enabled = bitsPerPixel <= 8
         _cbDither.Enabled = bitsPerPixel <= 8

         If bitsPerPixel <= 8 Then
            _cbOrder.Items.Clear()
            _cbOrder.Items.Add(Constants.GetNameFromValue(GetType(RasterByteOrder), RasterByteOrder.Rgb))
            _cbOrder.SelectedIndex = 0
            _cbOrder.Enabled = False

            If _cbPalette.Enabled Then
               Dim selectedPalette As MyPaletteType
               If _cbPalette.SelectedItem IsNot Nothing Then
                  selectedPalette = CType(_cbPalette.SelectedItem, MyPaletteType)
               Else
                  selectedPalette = MyPaletteType.Fixed
               End If

               _cbPalette.Items.Clear()

               Dim a As Array = [Enum].GetValues(GetType(MyPaletteType))
               For Each i As MyPaletteType In a
                  If bitsPerPixel = 8 OrElse i <> MyPaletteType.Netscape Then
                     _cbPalette.Items.Add(i)
                     If i = selectedPalette Then
                        _cbPalette.SelectedItem = i
                     End If
                  End If
               Next

               If _cbPalette.SelectedItem Is Nothing Then
                  _cbPalette.SelectedIndex = 0
               End If
            End If
         ElseIf bitsPerPixel = 12 Then
            _cbOrder.Items.Clear()
            _cbOrder.Items.Add(Constants.GetNameFromValue(GetType(RasterByteOrder), RasterByteOrder.Gray))
            _cbOrder.SelectedIndex = 0
            _cbOrder.Enabled = False
         ElseIf bitsPerPixel = 16 Then
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
      End Sub

      Private Sub _cbBitsPerPixel_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles _cbBitsPerPixel.SelectedIndexChanged
         UpdateMyControls()
      End Sub

      Private Sub SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles _cbOrder.SelectedIndexChanged, _cbOrder.SelectedIndexChanged, _cbPalette.SelectedIndexChanged, _cbDither.SelectedIndexChanged
         GetUpdateValues()
      End Sub

      Private Sub _btnOk_Click(sender As Object, e As System.EventArgs) Handles _btnOk.Click
         BitsPerPixel = CInt(_cbBitsPerPixel.SelectedItem)
         Order = CType(Constants.GetValueFromName(GetType(RasterByteOrder), CType(_cbOrder.SelectedItem, String), _initialOrder), RasterByteOrder)
         PaletteFlags = ColorResolutionCommandPaletteFlags.None
         Dim myPalette As MyPaletteType = CType(_cbPalette.SelectedItem, MyPaletteType)
         Select Case myPalette
            Case MyPaletteType.Fixed
               PaletteFlags = PaletteFlags Or ColorResolutionCommandPaletteFlags.Fixed
               Exit Select
            Case MyPaletteType.Optimized
               PaletteFlags = PaletteFlags Or ColorResolutionCommandPaletteFlags.Optimized
               Exit Select
            Case MyPaletteType.Netscape
               PaletteFlags = PaletteFlags Or ColorResolutionCommandPaletteFlags.Netscape
               Exit Select
         End Select

         DitheringMethod = CType(Constants.GetValueFromName(GetType(RasterDitheringMethod), CType(_cbDither.SelectedItem, String), _initialDitheringMethod), RasterDitheringMethod)

         _initialBitsPerPixel = BitsPerPixel
         _initialOrder = Order
         _initialPaletteFlags = PaletteFlags
         _initialDitheringMethod = DitheringMethod
      End Sub

      Private Sub GetUpdateValues()
         _tempBitsPerPixel = -1

         If _cbBitsPerPixel.SelectedItem IsNot Nothing Then
            _tempBitsPerPixel = CInt(_cbBitsPerPixel.SelectedItem)
         End If

         _tempOrder = RasterByteOrder.Bgr

         If _cbOrder.SelectedItem IsNot Nothing Then
            _tempOrder = CType(Constants.GetValueFromName(GetType(RasterByteOrder), CType(_cbOrder.SelectedItem, String), _initialOrder), RasterByteOrder)
         End If


         _tempPaletteFlags = ColorResolutionCommandPaletteFlags.None

         If _cbPalette.SelectedItem IsNot Nothing Then
            Dim myPalette As MyPaletteType = CType(_cbPalette.SelectedItem, MyPaletteType)
            Select Case myPalette
               Case MyPaletteType.Fixed
                  _tempPaletteFlags = _tempPaletteFlags Or ColorResolutionCommandPaletteFlags.Fixed
                  Exit Select
               Case MyPaletteType.Optimized
                  _tempPaletteFlags = _tempPaletteFlags Or ColorResolutionCommandPaletteFlags.Optimized
                  Exit Select
               Case MyPaletteType.Netscape
                  _tempPaletteFlags = _tempPaletteFlags Or ColorResolutionCommandPaletteFlags.Netscape
                  Exit Select
            End Select
         End If

         _tempDitheringMethod = RasterDitheringMethod.None

         If _cbDither.SelectedItem IsNot Nothing Then
            _tempDitheringMethod = CType(Constants.GetValueFromName(GetType(RasterDitheringMethod), CType(_cbDither.SelectedItem, String), _initialDitheringMethod), RasterDitheringMethod)
         End If
      End Sub

   End Class
End Namespace
