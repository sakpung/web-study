' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms

Imports Leadtools.ImageProcessing
Imports Leadtools.ImageProcessing.Color
Imports Leadtools.ImageProcessing.Effects
Imports BarcodeMainDemo.Leadtools.Demos

Partial Public Class ValueDialog : Inherits Form
   Public Value As Integer
   Private _type As TypeConstants
   Public Enum TypeConstants
      ScaleFactor
      PaintIntensity
      PaintContrast
      PaintGamma
      AutoCrop
      Average
      Gaussian
      Median
      Mosaic
      Oilify
      Posterize
      Sharpen
      Min
      Max
      HistoContrast
      Hue
      Solarize
      Temperature
   End Enum


   Private Structure TypeProp
      Public Type As TypeConstants
      Public CaptionName As String
      Public ValueName As String
      Public InitialValue As Integer
      Public ReadInitialValue As Boolean
      Public Min As Integer
      Public Max As Integer
      Public MultiplyBy As Integer

      Public Sub New(ByVal type_Renamed As TypeConstants, ByVal captionName_Renamed As String, ByVal valueName_Renamed As String, ByVal initialValue_Renamed As Integer, ByVal readInitialValue_Renamed As Boolean, ByVal min_Renamed As Integer, ByVal max_Renamed As Integer, ByVal multiplyBy_Renamed As Integer)
         Type = type_Renamed
         CaptionName = captionName_Renamed
         ValueName = valueName_Renamed
         InitialValue = initialValue_Renamed
         ReadInitialValue = readInitialValue_Renamed
         Min = min_Renamed
         Max = max_Renamed
         MultiplyBy = multiplyBy_Renamed
      End Sub
   End Structure

   Private _typeProp As TypeProp()


   Public Sub New(ByVal type As TypeConstants)
      '
      ' Required for Windows Form Designer support
      '
      _typeProp = New TypeProp() {New TypeProp(TypeConstants.ScaleFactor, DemosGlobalization.GetResxString(Me.GetType(), "Resx_ScaleFactorPercent"), DemosGlobalization.GetResxString(Me.GetType(), "Resx_ScaleFactor"), 0, True, 1, 1000, 1), New TypeProp(TypeConstants.PaintIntensity, DemosGlobalization.GetResxString(Me.GetType(), "Resx_PaintIntensity"), DemosGlobalization.GetResxString(Me.GetType(), "Resx_PaintIntensity"), 0, True, -100, 100, 10), New TypeProp(TypeConstants.PaintContrast, DemosGlobalization.GetResxString(Me.GetType(), "Resx_PaintContrast"), DemosGlobalization.GetResxString(Me.GetType(), "Resx_PaintContrast"), 0, True, -100, 100, 10), New TypeProp(TypeConstants.PaintGamma, DemosGlobalization.GetResxString(Me.GetType(), "Resx_PaintGamma"), DemosGlobalization.GetResxString(Me.GetType(), "Resx_PaintGamma"), 0, True, 10, 500, 1), New TypeProp(TypeConstants.AutoCrop, DemosGlobalization.GetResxString(Me.GetType(), "Resx_AutoCrop"), DemosGlobalization.GetResxString(Me.GetType(), "Resx_Threshold"), 0, True, 0, 244, 1), New TypeProp(TypeConstants.Average, DemosGlobalization.GetResxString(Me.GetType(), "Resx_Average"), DemosGlobalization.GetResxString(Me.GetType(), "Resx_Dimension"), 3, False, 3, 255, 1), New TypeProp(TypeConstants.Gaussian, DemosGlobalization.GetResxString(Me.GetType(), "Resx_Gaussian"), DemosGlobalization.GetResxString(Me.GetType(), "Resx_Radius"), 0, False, 1, 1000, 1), New TypeProp(TypeConstants.Median, DemosGlobalization.GetResxString(Me.GetType(), "Resx_Median"), DemosGlobalization.GetResxString(Me.GetType(), "Resx_Dimension"), 2, False, 2, 64, 1), New TypeProp(TypeConstants.Mosaic, DemosGlobalization.GetResxString(Me.GetType(), "Resx_Mosac"), DemosGlobalization.GetResxString(Me.GetType(), "Resx_Dimension"), 2, False, 2, 64, 1), New TypeProp(TypeConstants.Oilify, DemosGlobalization.GetResxString(Me.GetType(), "Resx_Oilify"), DemosGlobalization.GetResxString(Me.GetType(), "Resx_Dimension"), 2, False, 2, 255, 1), New TypeProp(TypeConstants.Posterize, DemosGlobalization.GetResxString(Me.GetType(), "Resx_Posterize"), DemosGlobalization.GetResxString(Me.GetType(), "Resx_Levels"), 2, False, 2, 64, 1), New TypeProp(TypeConstants.Sharpen, DemosGlobalization.GetResxString(Me.GetType(), "Resx_Sharpen"), DemosGlobalization.GetResxString(Me.GetType(), "Resx_Sharpness"), 0, False, -100, 100, 10), New TypeProp(TypeConstants.Min, DemosGlobalization.GetResxString(Me.GetType(), "Resx_MinFilter"), DemosGlobalization.GetResxString(Me.GetType(), "Resx_SampleSize"), 1, False, 1, 32, 1), New TypeProp(TypeConstants.Max, DemosGlobalization.GetResxString(Me.GetType(), "Resx_MaxFilter"), DemosGlobalization.GetResxString(Me.GetType(), "Resx_SampleSize"), 1, False, 1, 32, 1), New TypeProp(TypeConstants.HistoContrast, DemosGlobalization.GetResxString(Me.GetType(), "Resx_HistoContrast"), DemosGlobalization.GetResxString(Me.GetType(), "Resx_Contrast"), 0, False, -100, 100, 10), New TypeProp(TypeConstants.Hue, DemosGlobalization.GetResxString(Me.GetType(), "Resx_Hue"), DemosGlobalization.GetResxString(Me.GetType(), "Resx_Angle"), 0, False, -360, 360, 1), New TypeProp(TypeConstants.Solarize, DemosGlobalization.GetResxString(Me.GetType(), "Resx_Solarize"), DemosGlobalization.GetResxString(Me.GetType(), "Resx_Threshold"), 0, False, 0, 255, 1), New TypeProp(TypeConstants.Temperature, DemosGlobalization.GetResxString(Me.GetType(), "Resx_Temperature"), DemosGlobalization.GetResxString(Me.GetType(), "Resx_Threshold"), 0, False, -1000, 1000, 1)}
      InitializeComponent()

      '
      ' TODO: Add any constructor code after InitializeComponent call
      '
      _type = type
   End Sub

   Private Sub ValueDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
      Dim prop As TypeProp = _typeProp(CInt(_type))
      Text = prop.CaptionName
      _gbOptions.Text = prop.ValueName
      _numValue.Minimum = prop.Min
      _numValue.Maximum = prop.Max
      If prop.ReadInitialValue Then
         prop.InitialValue = Value
      Else
         Value = prop.InitialValue
      End If

      DialogUtilities.SetNumericValue(_numValue, CInt(Value / prop.MultiplyBy))
   End Sub

   Private Sub _num_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles _numValue.Leave
      DialogUtilities.NumericOnLeave(sender)
   End Sub

   Private Sub _btnOk_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _btnOk.Click
      Dim index As Integer = CInt(_type)
      Value = CInt(_numValue.Value) * _typeProp(index).MultiplyBy
      _typeProp(index).InitialValue = Value
   End Sub
End Class
