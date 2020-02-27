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

Imports Leadtools.Drawing

Partial Public Class PaintPropertiesDialog : Inherits Form
   Private Enum CategorizedDithering
      None
      ErrorDiffusion
      Ordered
   End Enum

   Private Enum CategorizedBitonalScaling
      None
      FavorBlack
      ScaleToGray
   End Enum

   Private Enum CategorizedPaintScaling
      None
      Resample
      Bicubic
   End Enum

   Private Enum CategorizedPalette
      Automatic
      Fixed
      Netscape
   End Enum

   Private Structure CategorizedPaintProperties
      Public PaintEngine As RasterPaintEngine
      Public RasterOperation As Integer
      Public Dithering As CategorizedDithering
      Public BitonalScaling As CategorizedBitonalScaling
      Public PaintScaling As CategorizedPaintScaling
      Public Palette As CategorizedPalette
      Public UsePaintPalette As Boolean
      Public IndexedPaint As Boolean
      Public FastPaint As Boolean
      Public HalftonePrint As Boolean

      Public Sub New(ByVal props As RasterPaintProperties)
         PaintEngine = props.PaintEngine
         RasterOperation = props.RasterOperation

         If ((props.PaintDisplayMode And RasterPaintDisplayModeFlags.DitheredPaint) = RasterPaintDisplayModeFlags.DitheredPaint) Then
            If ((props.PaintDisplayMode And RasterPaintDisplayModeFlags.OrderedDither) = RasterPaintDisplayModeFlags.OrderedDither) Then
               Dithering = CategorizedDithering.Ordered
            Else
               Dithering = CategorizedDithering.ErrorDiffusion
            End If
         Else
            Dithering = CategorizedDithering.None
         End If

         If ((props.PaintDisplayMode And RasterPaintDisplayModeFlags.FavorBlack) = RasterPaintDisplayModeFlags.FavorBlack) Then
            BitonalScaling = CategorizedBitonalScaling.FavorBlack
         ElseIf ((props.PaintDisplayMode And RasterPaintDisplayModeFlags.ScaleToGray) = RasterPaintDisplayModeFlags.ScaleToGray) Then
            BitonalScaling = CategorizedBitonalScaling.ScaleToGray
         Else
            BitonalScaling = CategorizedBitonalScaling.None
         End If


         If ((props.PaintDisplayMode And RasterPaintDisplayModeFlags.Resample) = RasterPaintDisplayModeFlags.Resample) Then
            PaintScaling = CategorizedPaintScaling.Resample
         ElseIf ((props.PaintDisplayMode And RasterPaintDisplayModeFlags.Bicubic) = RasterPaintDisplayModeFlags.Bicubic) Then
            PaintScaling = CategorizedPaintScaling.Bicubic
         Else
            PaintScaling = CategorizedPaintScaling.None
         End If

         If ((props.PaintDisplayMode And RasterPaintDisplayModeFlags.FixedPalette) = RasterPaintDisplayModeFlags.FixedPalette) Then
            If ((props.PaintDisplayMode And RasterPaintDisplayModeFlags.NetscapePalette) = RasterPaintDisplayModeFlags.NetscapePalette) Then
               Palette = CategorizedPalette.Netscape
            Else
               Palette = CategorizedPalette.Fixed
            End If
         Else
            Palette = CategorizedPalette.Automatic
         End If

         UsePaintPalette = props.UsePaintPalette
         IndexedPaint = ((props.PaintDisplayMode And RasterPaintDisplayModeFlags.IndexedPaint) = RasterPaintDisplayModeFlags.IndexedPaint)
         FastPaint = ((props.PaintDisplayMode And RasterPaintDisplayModeFlags.FastPaint) = RasterPaintDisplayModeFlags.FastPaint)
         HalftonePrint = ((props.PaintDisplayMode And RasterPaintDisplayModeFlags.HalftonePrint) = RasterPaintDisplayModeFlags.HalftonePrint)
      End Sub

      Public Function ToPaintProperties() As RasterPaintProperties
         Dim props As RasterPaintProperties = RasterPaintProperties.Default
         props.PaintDisplayMode = RasterPaintDisplayModeFlags.None

         props.PaintEngine = PaintEngine
         props.RasterOperation = RasterOperation

         If (Dithering = CategorizedDithering.Ordered) Then
            props.PaintDisplayMode = props.PaintDisplayMode Or RasterPaintDisplayModeFlags.OrderedDither Or RasterPaintDisplayModeFlags.DitheredPaint
         ElseIf (Dithering = CategorizedDithering.ErrorDiffusion) Then
            props.PaintDisplayMode = props.PaintDisplayMode Or RasterPaintDisplayModeFlags.OrderedDither
         End If

         If (BitonalScaling = CategorizedBitonalScaling.ScaleToGray) Then
            props.PaintDisplayMode = props.PaintDisplayMode Or RasterPaintDisplayModeFlags.ScaleToGray
         ElseIf (BitonalScaling = CategorizedBitonalScaling.FavorBlack) Then
            props.PaintDisplayMode = props.PaintDisplayMode Or RasterPaintDisplayModeFlags.FavorBlack
         End If

         If (PaintScaling = CategorizedPaintScaling.Bicubic) Then
            props.PaintDisplayMode = props.PaintDisplayMode Or RasterPaintDisplayModeFlags.Bicubic
         ElseIf (PaintScaling = CategorizedPaintScaling.Resample) Then
            props.PaintDisplayMode = props.PaintDisplayMode Or RasterPaintDisplayModeFlags.Resample
         End If

         If (Palette = CategorizedPalette.Netscape) Then
            props.PaintDisplayMode = props.PaintDisplayMode Or RasterPaintDisplayModeFlags.FixedPalette Or RasterPaintDisplayModeFlags.NetscapePalette
         ElseIf (Palette = CategorizedPalette.Fixed) Then
            props.PaintDisplayMode = props.PaintDisplayMode Or RasterPaintDisplayModeFlags.FixedPalette
         End If

         props.UsePaintPalette = UsePaintPalette

         If (IndexedPaint) Then
            props.PaintDisplayMode = props.PaintDisplayMode Or RasterPaintDisplayModeFlags.IndexedPaint
         End If

         If (FastPaint) Then
            props.PaintDisplayMode = props.PaintDisplayMode Or RasterPaintDisplayModeFlags.FastPaint
         End If

         If (HalftonePrint) Then
            props.PaintDisplayMode = props.PaintDisplayMode Or RasterPaintDisplayModeFlags.HalftonePrint
         End If

         Return props
      End Function
   End Structure

   Private _paintProperties As RasterPaintProperties

   Public Property PaintProperties() As RasterPaintProperties
      Get
         Return _paintProperties
      End Get

      Set(ByVal Value As RasterPaintProperties)
         _paintProperties = Value
      End Set
   End Property

   Public Event Apply As EventHandler

   Private _categorizedProps As CategorizedPaintProperties

   Private Structure ComboBoxItem
      Public Value As Integer
      Public Name As String

      Public Sub New(ByVal val As Integer, ByVal n As String)
         Value = val
         Name = n
      End Sub

      Public Overrides Function ToString() As String
         Return Name
      End Function
   End Structure

   Private Shared ReadOnly _engines() As ComboBoxItem = _
   { _
      New ComboBoxItem(RasterPaintEngine.Gdi, "Win32 GDI"), _
      New ComboBoxItem(RasterPaintEngine.GdiPlus, "GDI+") _
   }

   Private Shared ReadOnly _operations() As ComboBoxItem = _
   { _
      New ComboBoxItem(RasterPaintProperties.SourceCopy, "Source Copy"), _
      New ComboBoxItem(RasterPaintProperties.SourcePaint, "Source Paint"), _
      New ComboBoxItem(RasterPaintProperties.SourceAnd, "Source And"), _
      New ComboBoxItem(RasterPaintProperties.SourceInvert, "Source Invert"), _
      New ComboBoxItem(RasterPaintProperties.SourceErase, "Source Erase"), _
      New ComboBoxItem(RasterPaintProperties.NotSourceCopy, "Not Source Copy"), _
      New ComboBoxItem(RasterPaintProperties.NotSourceErase, "Not Source Erase"), _
      New ComboBoxItem(RasterPaintProperties.MergeCopy, "Merge Copy"), _
      New ComboBoxItem(RasterPaintProperties.MergePaint, "Merge Paint"), _
      New ComboBoxItem(RasterPaintProperties.PatternCopy, "Pattern Copy"), _
      New ComboBoxItem(RasterPaintProperties.PatternPaint, "Pattern Paint"), _
      New ComboBoxItem(RasterPaintProperties.PatternInvert, "Pattern Invert"), _
      New ComboBoxItem(RasterPaintProperties.DestinationInvert, "Destination Invert"), _
      New ComboBoxItem(RasterPaintProperties.Blackness, "Blackness"), _
      New ComboBoxItem(RasterPaintProperties.Whiteness, "Whiteness") _
   }

   Private Shared ReadOnly _ditherings() As ComboBoxItem = _
   { _
      New ComboBoxItem(CategorizedDithering.None, "None"), _
      New ComboBoxItem(CategorizedDithering.ErrorDiffusion, "Error Diffusion"), _
      New ComboBoxItem(CategorizedDithering.Ordered, "Ordered") _
   }

   Private Shared ReadOnly _palettes() As ComboBoxItem = _
   { _
      New ComboBoxItem(CategorizedPalette.Automatic, "Auto"), _
      New ComboBoxItem(CategorizedPalette.Fixed, "LEADTOOLS"), _
      New ComboBoxItem(CategorizedPalette.Netscape, "Netscape") _
   }

   Private Shared ReadOnly _bitonalScalings() As ComboBoxItem = _
   { _
      New ComboBoxItem(CategorizedBitonalScaling.None, "None"), _
      New ComboBoxItem(CategorizedBitonalScaling.FavorBlack, "Favor Black"), _
      New ComboBoxItem(CategorizedBitonalScaling.ScaleToGray, "Scale to Gray") _
   }

   Private Shared ReadOnly _paintScalings() As ComboBoxItem = _
   { _
      New ComboBoxItem(CategorizedPaintScaling.None, "None"), _
      New ComboBoxItem(CategorizedPaintScaling.Resample, "Resample"), _
      New ComboBoxItem(CategorizedPaintScaling.Bicubic, "BiCubic") _
   }
   Public Sub New()
      InitializeComponent()
   End Sub
   Private Sub PaintPropertiesDialog_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      _categorizedProps = New CategorizedPaintProperties(PaintProperties)

      Dim i As ComboBoxItem
      For Each i In _engines
         _cbEngine.Items.Add(CType(i, Object))
         If (i.Value = _categorizedProps.PaintEngine) Then
            _cbEngine.SelectedItem = i
         End If
      Next

      For Each i In _operations
         _cbOperation.Items.Add(i)
         If (i.Value = _categorizedProps.RasterOperation) Then
            _cbOperation.SelectedItem = i
         End If
      Next

      For Each i In _ditherings
         _cbDithering.Items.Add(i)
         If (i.Value = _categorizedProps.Dithering) Then
            _cbDithering.SelectedItem = i
         End If
      Next

      For Each i In _palettes
         _cbPalette.Items.Add(i)
         If (i.Value = _categorizedProps.Palette) Then
            _cbPalette.SelectedItem = i
         End If
      Next

      For Each i In _bitonalScalings
         _cbBitonalScaling.Items.Add(i)
         If (i.Value = _categorizedProps.BitonalScaling) Then
            _cbBitonalScaling.SelectedItem = i
         End If
      Next

      For Each i In _paintScalings
         _cbPaintScaling.Items.Add(i)
         If (i.Value = _categorizedProps.PaintScaling) Then
            _cbPaintScaling.SelectedItem = i
         End If
      Next

      _cbIndexedPaint.Checked = _categorizedProps.IndexedPaint
      _cbFastPaint.Checked = _categorizedProps.FastPaint
      _cbHalftonePrint.Checked = _categorizedProps.HalftonePrint

      CheckApply()
   End Sub

   Private Sub CheckApply()
      Dim canApply As Boolean = False

      Dim props As CategorizedPaintProperties = GetProps()

      If (Not canApply AndAlso props.PaintEngine <> _categorizedProps.PaintEngine) Then
         canApply = True
      End If

      If (Not canApply AndAlso props.RasterOperation <> _categorizedProps.RasterOperation) Then
         canApply = True
      End If

      If (Not canApply AndAlso props.Dithering <> _categorizedProps.Dithering) Then
         canApply = True
      End If

      If (Not canApply AndAlso props.Palette <> _categorizedProps.Palette) Then
         canApply = True
      End If

      If (Not canApply AndAlso props.BitonalScaling <> _categorizedProps.BitonalScaling) Then
         canApply = True
      End If

      If (Not canApply AndAlso props.PaintScaling <> _categorizedProps.PaintScaling) Then
         canApply = True
      End If

      If (Not canApply AndAlso props.UsePaintPalette <> _categorizedProps.UsePaintPalette) Then
         canApply = True
      End If

      If (Not canApply AndAlso props.IndexedPaint <> _categorizedProps.IndexedPaint) Then
         canApply = True
      End If

      If (Not canApply AndAlso props.FastPaint <> _categorizedProps.FastPaint) Then
         canApply = True
      End If

      If (Not canApply AndAlso props.HalftonePrint <> _categorizedProps.HalftonePrint) Then
         canApply = True
      End If

      _btnApply.Enabled = canApply

      _lblOperation.Enabled = (props.PaintEngine <> RasterPaintEngine.GdiPlus)
      _cbOperation.Enabled = (props.PaintEngine <> RasterPaintEngine.GdiPlus)
   End Sub

   Private Function GetProps() As CategorizedPaintProperties
      Dim props As New CategorizedPaintProperties

      If (Not IsNothing(_cbEngine.SelectedItem)) Then
         Dim item As ComboBoxItem = CType(_cbEngine.SelectedItem, ComboBoxItem)
         props.PaintEngine = CType(item.Value, RasterPaintEngine)
      End If

      If (Not IsNothing(_cbOperation.SelectedItem)) Then
         Dim item As ComboBoxItem = CType(_cbOperation.SelectedItem, ComboBoxItem)
         props.RasterOperation = item.Value
      End If

      If (Not IsNothing(_cbDithering.SelectedItem)) Then
         Dim item As ComboBoxItem = CType(_cbDithering.SelectedItem, ComboBoxItem)
         props.Dithering = CType(item.Value, CategorizedDithering)
      End If

      If (Not IsNothing(_cbPalette.SelectedItem)) Then
         Dim item As ComboBoxItem = CType(_cbPalette.SelectedItem, ComboBoxItem)
         props.Palette = CType(item.Value, CategorizedPalette)
      End If

      If (Not IsNothing(_cbBitonalScaling.SelectedItem)) Then
         Dim item As ComboBoxItem = CType(_cbBitonalScaling.SelectedItem, ComboBoxItem)
         props.BitonalScaling = CType(item.Value, CategorizedBitonalScaling)
      End If

      If (Not IsNothing(_cbPaintScaling.SelectedItem)) Then
         Dim item As ComboBoxItem = CType(_cbPaintScaling.SelectedItem, ComboBoxItem)
         props.PaintScaling = CType(item.Value, CategorizedPaintScaling)
      End If

      props.UsePaintPalette = True
      props.IndexedPaint = _cbIndexedPaint.Checked
      props.FastPaint = _cbFastPaint.Checked
      props.HalftonePrint = _cbHalftonePrint.Checked

      Return props
   End Function

   Private Sub ComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
      _cbEngine.SelectedIndexChanged, _
      _cbOperation.SelectedIndexChanged, _
      _cbDithering.SelectedIndexChanged, _
      _cbPalette.SelectedIndexChanged, _
      _cbBitonalScaling.SelectedIndexChanged, _
      _cbPaintScaling.SelectedIndexChanged
      CheckApply()
   End Sub

   Private Sub CheckBox_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _cbIndexedPaint.CheckedChanged, _cbHalftonePrint.CheckedChanged, _cbFastPaint.CheckedChanged
      CheckApply()
   End Sub

   Private Sub _btnApply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _btnApply.Click
      ApplyProps()
      CheckApply()
   End Sub

   Private Sub ApplyProps()
      If (_btnApply.Enabled) Then
         _categorizedProps = GetProps()
         _paintProperties = _categorizedProps.ToPaintProperties()

         RaiseEvent Apply(Me, EventArgs.Empty)
      End If
   End Sub

   Private Sub _btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _btnOk.Click
      ApplyProps()
   End Sub
End Class
