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

Namespace Leadtools.Demos
   Partial Public Class RawDialog : Inherits Form
      ' Create an instance of the Raw Data Structure to be used in this dialog for loading Raw Data
      Public CurrentRawData As RawData
      Private _nBitsPerPixelOriginal As Integer = 0
      Private _initializaing As Boolean
      Private _forLoad As Boolean

      Private Structure FormatItem
         Public Format As RasterImageFormat
         Public Name As String

         Public Sub New(ByVal f As RasterImageFormat, ByVal n As String)
            Format = f
            Name = n
         End Sub

         Public Overrides Function ToString() As String
            Return Name
         End Function
      End Structure

      Private Shared ReadOnly _LoadFormats As FormatItem() = {New FormatItem(RasterImageFormat.Raw, "RAW"), New FormatItem(RasterImageFormat.FaxG31DimNoEol, "Group 3-1D [No EOL] Fax"), New FormatItem(RasterImageFormat.FaxG31Dim, "Group 3-1D Fax"), New FormatItem(RasterImageFormat.FaxG32Dim, "Group 3-2D Fax"), New FormatItem(RasterImageFormat.FaxG4, "Group 4 Fax"), New FormatItem(RasterImageFormat.Abic, "ABIC Raw")}

      Private Shared ReadOnly _SaveFormats As FormatItem() = {New FormatItem(RasterImageFormat.Raw, "RAW"), New FormatItem(RasterImageFormat.FaxG31Dim, "Group 3-1D Fax"), New FormatItem(RasterImageFormat.FaxG32Dim, "Group 3-2D Fax"), New FormatItem(RasterImageFormat.FaxG4, "Group 4 Fax"), New FormatItem(RasterImageFormat.Abic, "ABIC Raw")}

      Private Structure PaletteItem
         Public Fixed As Boolean
         Public Name As String

         Public Sub New(ByVal f As Boolean, ByVal n As String)
            Fixed = f
            Name = n
         End Sub

         Public Overrides Function ToString() As String
            Return Name
         End Function
      End Structure

      Private Shared ReadOnly _palettes As PaletteItem() = {New PaletteItem(True, "Fixed Palette"), New PaletteItem(False, "Gray Scale")}

      Public Sub New(ByVal forLoad As Boolean)
         InitializeComponent()

         _forLoad = forLoad
         ' Set the BitsPerPixel to 24
         _nBitsPerPixelOriginal = CurrentRawData.BitsPerPixel
      End Sub

      Private Sub RawDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
         _initializaing = True

         UpdateControlsLoadSave()

         ' Hide this one or save
         _cbWhiteOnBlack.Visible = _forLoad

         If _forLoad Then
            Me.Text = "Raw File Open Dialog"
         Else
            Me.Text = "Raw File Save Dialog"
         End If
         ' Fill values of the RasterByteOrder inside the Color Order combo box to be selected 
         Dim a As Array = System.Enum.GetValues(GetType(RasterByteOrder))
         For Each i As RasterByteOrder In a
            _cmbColorOrder.Items.Add(i)
            If i = CurrentRawData.Order Then
               _cmbColorOrder.SelectedItem = i
            End If
         Next i

         If _forLoad Then
            ' Fill values of the Raw Formats inside the Format combo box to be selected when loading
            For Each i As FormatItem In _LoadFormats
               _cmbFormat.Items.Add(i)
               If i.Format = CurrentRawData.Format Then
                  _cmbFormat.SelectedItem = i
               End If
            Next i
         Else
            ' Fill values of the Raw Formats inside the Format combo box to be selected when saving
            For Each i As FormatItem In _SaveFormats
               _cmbFormat.Items.Add(i)
               If i.Format = CurrentRawData.Format Then
                  _cmbFormat.SelectedItem = i
               End If
            Next i
         End If
         ' Fill the Palette type (0 for grayscale palette and 1 for Leadtools fixed palette) in the Palettes combo box
         For Each i As PaletteItem In _palettes
            _cmbPalette.Items.Add(i)
            If i.Fixed = CurrentRawData.FixedPalette Then
               _cmbPalette.SelectedItem = i
            End If
         Next i

         ' Fill the values of RasterViewPerspective inside the raw data View Perspective combo box.
         a = System.Enum.GetValues(GetType(RasterViewPerspective))
         For Each i As RasterViewPerspective In a
            Dim add As Boolean = True
            Dim j As Integer = 0
            Do While j < _cmbViewPerspective.Items.Count AndAlso add
               If CInt(_cmbViewPerspective.Items(j)) = CInt(i) Then
                  add = False
               End If
               j += 1
            Loop

            If add Then
               _cmbViewPerspective.Items.Add(i)
               If i = CurrentRawData.ViewPerspective Then
                  _cmbViewPerspective.SelectedItem = i
               End If
            End If
         Next i

         ' Set the default values for the Raw Dialog according to the Raw Data Structure.
         _cbPadLine4Bytes.Checked = CurrentRawData.Padding

         _tbWidth.Text = CurrentRawData.Width.ToString()
         _tbHeight.Text = CurrentRawData.Height.ToString()
         _tbHorizontal.Text = CurrentRawData.XResolution.ToString()
         _tbVertical.Text = CurrentRawData.YResolution.ToString()
         _tbOffst.Text = CurrentRawData.Offset.ToString()

         _cbLSBFirst.Checked = CurrentRawData.ReverseBits

         UpdateControls()

         _initializaing = False

         Dim bRaw As Boolean = (CType(_cmbFormat.SelectedItem, FormatItem)).Format = RasterImageFormat.Raw
         Dim bAbic As Boolean = (CType(_cmbFormat.SelectedItem, FormatItem)).Format = RasterImageFormat.Abic

         If bAbic Then
            _cmbPalette.SelectedIndex = 1
         ElseIf bRaw Then
            _cmbPalette.SelectedIndex = 0
         End If
      End Sub

      Private Sub _btnOk_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _btnOk.Click
         ' Create a new instance of the RawData structure
         Dim raw As RawData = New RawData()
         ' Select the Format
         raw.Format = (CType(_cmbFormat.SelectedItem, FormatItem)).Format

         If (Not DialogUtilities.ParseInteger(_tbWidth, "Width", 1, True, 0, False, True, raw.Width)) Then
            Return
         End If

         If (Not DialogUtilities.ParseInteger(_tbHeight, "Height", 1, True, 0, False, True, raw.Height)) Then
            Return
         End If

         If (Not DialogUtilities.ParseInteger(_tbOffst, "Offset", 0, True, 0, False, True, raw.Offset)) Then
            Return
         End If

         If (Not DialogUtilities.ParseInteger(_tbHorizontal, "Horizontal Resolution", 1, True, 0, False, True, raw.XResolution)) Then
            Return
         End If

         If (Not DialogUtilities.ParseInteger(_tbVertical, "Vertical Resolution", 1, True, 0, False, True, raw.YResolution)) Then
            Return
         End If
         ' Set the BitsPerPixel
         raw.BitsPerPixel = CInt(_cbBitsPerPixel.SelectedItem)
         ' Set the ViewPerspective 
         raw.ViewPerspective = CType(_cmbViewPerspective.SelectedItem, RasterViewPerspective)
         ' Set the RasterByteOrder
         raw.Order = CType(_cmbColorOrder.SelectedItem, RasterByteOrder)
         ' Set the Type of Palette
         raw.FixedPalette = (CType(_cmbPalette.SelectedItem, PaletteItem)).Fixed
         raw.PaletteEnabled = _cmbPalette.Enabled
         raw.Padding = _cbPadLine4Bytes.Checked
         raw.ReverseBits = _cbLSBFirst.Checked
         raw.WhiteOnBlack = _cbWhiteOnBlack.Checked
         ' Update the CurrentRawData instance with the new values
         CurrentRawData = raw
      End Sub

      Private Sub UpdateControlsLoadSave()
         Dim bAbic As Boolean

         If _cmbFormat.SelectedIndex <> -1 Then
            bAbic = (CType(_cmbFormat.SelectedItem, FormatItem)).Format = RasterImageFormat.Abic
         Else
            bAbic = False
         End If

         _tbWidth.ReadOnly = Not _forLoad
         _tbHeight.ReadOnly = Not _forLoad
         _tbHorizontal.ReadOnly = Not _forLoad
         _tbVertical.ReadOnly = Not _forLoad
         _cbBitsPerPixel.Enabled = _forLoad OrElse bAbic
         _cmbViewPerspective.Enabled = _forLoad
         _cmbColorOrder.Enabled = _forLoad
         _cmbPalette.Enabled = _forLoad
      End Sub

      Private Sub UpdateBitsPerPixel()
         Dim bRaw As Boolean = (CType(_cmbFormat.SelectedItem, FormatItem)).Format = RasterImageFormat.Raw
         Dim bAbic As Boolean = (CType(_cmbFormat.SelectedItem, FormatItem)).Format = RasterImageFormat.Abic
         Dim nIndex As Integer = -1
         Dim nBPP As Integer

         If bRaw OrElse bAbic Then
            nBPP = _nBitsPerPixelOriginal
         Else
            nBPP = 1
         End If

         'nIndex = _cbBitsPerPixel.FindStringExact(nBPP.ToString());
         'nBPP = 24;

         Dim test As String
         test = nBPP.ToString()
         nIndex = _cbBitsPerPixel.FindStringExact(test)
         If nIndex <> -1 Then
            Dim nBPPTemp As Integer = _nBitsPerPixelOriginal
            _cbBitsPerPixel.SelectedIndex = nIndex
            _nBitsPerPixelOriginal = nBPPTemp
         End If
      End Sub

      Private Sub UpdateControls()
         UpdateBitsPerPixel()

         Dim bRaw As Boolean = (CType(_cmbFormat.SelectedItem, FormatItem)).Format = RasterImageFormat.Raw
         Dim bAbic As Boolean = (CType(_cmbFormat.SelectedItem, FormatItem)).Format = RasterImageFormat.Abic
         _cbPadLine4Bytes.Enabled = bRaw OrElse bAbic

         If _forLoad = False Then
            ' saving
            UpdateControlsLoadSave()
            Return
         End If

         ' loading
         _cbBitsPerPixel.Enabled = bRaw OrElse bAbic
         _cmbViewPerspective.Enabled = True
         _cmbColorOrder.Enabled = bRaw OrElse bAbic
         _cmbPalette.Enabled = bRaw OrElse bAbic
         _cbLSBFirst.Enabled = True
         _cbPadLine4Bytes.Enabled = bRaw OrElse bAbic
         _cbWhiteOnBlack.Enabled = (Not bRaw) AndAlso Not bAbic

         If (Not bRaw) Then
            _cmbPalette.SelectedIndex = 0
            _cmbColorOrder.SelectedItem = RasterByteOrder.Bgr
         Else
            _cbBitsPerPixel.Enabled = True

            If CInt(_cbBitsPerPixel.SelectedItem) > 8 Then
               _cmbPalette.Enabled = True
               _cmbPalette.SelectedIndex = 1
               _cmbPalette.Enabled = False
            Else
               If (Not _cmbPalette.Enabled) Then
                  _cmbPalette.Enabled = True
               End If
            End If
         End If
      End Sub

      Private Sub _cmbFormat_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmbFormat.SelectedIndexChanged
         Dim bRaw As Boolean = (CType(_cmbFormat.SelectedItem, FormatItem)).Format = RasterImageFormat.Raw
         Dim bAbic As Boolean = (CType(_cmbFormat.SelectedItem, FormatItem)).Format = RasterImageFormat.Abic

         If (Not _initializaing) Then
            UpdateControls()
         End If

         If bAbic Then
            Dim bitsPerPixels1 As Integer() = New Integer() {1, 2, 3, 4, 5, 6, 7, 8, 12, 16, 24, 32, 48, 64}

            For Each i As Integer In bitsPerPixels1
               _cbBitsPerPixel.Items.Remove(i)
            Next i

            Dim bitsPerPixels2 As Integer() = New Integer() {1, 4}
            For Each i As Integer In bitsPerPixels2
               _cbBitsPerPixel.Items.Add(i)

            Next i
            _cbBitsPerPixel.SelectedIndex = 0
         Else
            If bRaw Then
               Dim bitsPerPixels1 As Integer() = New Integer() {1, 2, 3, 4, 5, 6, 7, 8, 12, 16, 24, 32, 48, 64}

               For Each i As Integer In bitsPerPixels1
                  _cbBitsPerPixel.Items.Remove(i)
               Next i

               Dim bitsPerPixels2 As Integer() = New Integer() {1, 2, 3, 4, 5, 6, 7, 8, 12, 16, 24, 32, 48, 64}
               For Each i As Integer In bitsPerPixels2
                  _cbBitsPerPixel.Items.Add(i)
               Next i

               _cbBitsPerPixel.SelectedIndex = 10
            End If
         End If

         If _cmbPalette.Items.Count > 0 Then
            If bAbic Then
               _cmbPalette.SelectedIndex = 1
            ElseIf bRaw Then
               _cmbPalette.SelectedIndex = 0
            End If
         End If

         If _cbBitsPerPixel.Items.Count = 0 Then
            Dim bitsPerPixels As Integer() = New Integer() {1}
            For Each i As Integer In bitsPerPixels
               _cbBitsPerPixel.Items.Add(i)
            Next i
            _cbBitsPerPixel.SelectedIndex = 0
         End If
      End Sub

      Private Sub _cbBitsPerPixel_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cbBitsPerPixel.SelectedIndexChanged
         _nBitsPerPixelOriginal = CInt(_cbBitsPerPixel.SelectedItem)
         If (Not _initializaing) Then
            UpdateControls()
         End If
      End Sub
   End Class
End Namespace
