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
Imports Leadtools.ImageProcessing.Core

Namespace ImageProcessingDemo
   'This dialog is used to allow the user to specify values which
   'will be used for the ColorResolutionCommand

   Partial Public Class ColorResolutionDialog : Inherits Form
      Private _ColorResolutionCommand As ColorResolutionCommand = Nothing
      Private _bPP As Integer = 1

      Public Sub New()
         InitializeComponent()
         _ColorResolutionCommand = New ColorResolutionCommand()
         InitializeUI()
      End Sub
      Public Sub New(ByVal ColorResolutionCommand As ColorResolutionCommand, ByVal BPP As Integer)
         InitializeComponent()
         _ColorResolutionCommand = ColorResolutionCommand
         _bPP = BPP

         'Set command default values
         InitializeUI()
      End Sub
      Public Property ColorResolutionCommand() As ColorResolutionCommand
         Get
            'Update command values
            UpdateCommand()
            Return _ColorResolutionCommand
         End Get
         Set(ByVal value As ColorResolutionCommand)
            _ColorResolutionCommand = value
            InitializeUI()
         End Set
      End Property
      Private Sub _btnOk_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnOk.Click
         UpdateCommand()
         Me.DialogResult = DialogResult.OK
         Me.Close()
      End Sub

      Private Sub _btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnCancel.Click
         Me.DialogResult = DialogResult.Cancel
      End Sub
      Private Sub InitializeUI()
         _cmbBitsPerPixel.Items.Add(1)
         _cmbBitsPerPixel.Items.Add(2)
         _cmbBitsPerPixel.Items.Add(3)
         _cmbBitsPerPixel.Items.Add(4)
         _cmbBitsPerPixel.Items.Add(5)
         _cmbBitsPerPixel.Items.Add(6)
         _cmbBitsPerPixel.Items.Add(7)
         _cmbBitsPerPixel.Items.Add(8)
         _cmbBitsPerPixel.Items.Add(12)
         _cmbBitsPerPixel.Items.Add(16)
         _cmbBitsPerPixel.Items.Add(24)
         _cmbBitsPerPixel.Items.Add(32)
         _cmbBitsPerPixel.Items.Add(48)
         _cmbBitsPerPixel.Items.Add(64)


         AddHandler _cmbBitsPerPixel.SelectedIndexChanged, AddressOf _cmbBitsPerPixel_SelectedIndexChanged
         _cmbBitsPerPixel.SelectedIndex = _cmbBitsPerPixel.Items.IndexOf(_ColorResolutionCommand.BitsPerPixel)


         Dim names As String()
         names = System.Enum.GetNames(GetType(RasterDitheringMethod))
         For Each name As String In names
            _cmbDitherMethod.Items.Add(name)
         Next name
         _cmbDitherMethod.SelectedIndex = _cmbDitherMethod.Items.IndexOf(_ColorResolutionCommand.DitheringMethod.ToString())

         names = System.Enum.GetNames(GetType(ColorResolutionCommandPaletteFlags))
         For Each name As String In names
            If name = "Fixed" Then
               _cmbPalette.Items.Add(name)
            End If

            If name = "Optimized" Then
               _cmbPalette.Items.Add(name)
            End If
         Next name
         _cmbPalette.SelectedIndex = _cmbPalette.Items.IndexOf(_ColorResolutionCommand.PaletteFlags.ToString())

         _cmbColorOrder.Items.Add("Blue-Green-Red (BGR)")
         _cmbColorOrder.Items.Add("Red-Green-Blue (RGB)")
         _cmbColorOrder.SelectedIndex = 0

         For Each i As Object In _cmbBitsPerPixel.Items
            If i.ToString() = _bPP.ToString() Then
               _cmbBitsPerPixel.SelectedItem = i
               Exit For
            End If
         Next i
      End Sub
      Private Sub UpdateCommand()
         If _cmbBitsPerPixel.Text <> "" Then
            _ColorResolutionCommand.BitsPerPixel = Convert.ToInt32(_cmbBitsPerPixel.Text)
         Else
            _ColorResolutionCommand.BitsPerPixel = _bPP
         End If

         If _cmbDitherMethod.Text <> "" Then
            _ColorResolutionCommand.DitheringMethod = CType(System.Enum.Parse(GetType(RasterDitheringMethod), _cmbDitherMethod.Text), RasterDitheringMethod)
         End If
         _ColorResolutionCommand.Order = TranslateOrder()
         If _cmbPalette.Text <> "" Then
            _ColorResolutionCommand.PaletteFlags = CType(System.Enum.Parse(GetType(ColorResolutionCommandPaletteFlags), _cmbPalette.Text), ColorResolutionCommandPaletteFlags)
         End If
      End Sub
      Private Sub _cmbBitsPerPixel_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
         If _cmbBitsPerPixel.SelectedIndex < 8 Then
            _cmbDitherMethod.Enabled = True
            _cmbPalette.Enabled = True
            _cmbColorOrder.Enabled = False
            _cmbPalette.Items.Remove("Netscape")

            If _cmbBitsPerPixel.SelectedIndex = 7 Then
               _cmbPalette.Items.Add("Netscape")
            End If

            _cmbPalette.SelectedIndex = 1
         ElseIf _cmbBitsPerPixel.SelectedIndex = 8 Then
            _cmbDitherMethod.Enabled = False
            _cmbPalette.Enabled = False
            _cmbColorOrder.Enabled = False
         Else
            _cmbDitherMethod.Enabled = False
            _cmbPalette.Enabled = False
            _cmbColorOrder.Enabled = True
            _cmbColorOrder.Items.Remove("Grayscale")
            If _cmbBitsPerPixel.SelectedIndex = 9 Then
               _cmbColorOrder.Items.Add("Grayscale")
            End If
         End If
      End Sub
      Public Function TranslateOrder() As RasterByteOrder
         Select Case _cmbColorOrder.SelectedIndex
            Case 0
               Return RasterByteOrder.Bgr

            Case 1
               Return RasterByteOrder.Rgb

            Case 2
               Return RasterByteOrder.Gray

            Case Else
               Return RasterByteOrder.Bgr
         End Select
      End Function
   End Class
End Namespace
