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

Imports Leadtools.ImageProcessing
Imports Leadtools.ImageProcessing.Color
Imports Leadtools.ImageProcessing.Effects

Namespace MainDemo
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

         Public Sub New(ByVal type_ As TypeConstants, _
            ByVal captionName_ As String, _
            ByVal valueName_ As String, _
            ByVal initialValue_ As Integer, _
            ByVal readInitialValue_ As Boolean, _
            ByVal min_ As Integer, _
            ByVal max_ As Integer, _
            ByVal multiplyBy_ As Integer)
            Type = type_
            CaptionName = captionName_
            ValueName = valueName_
            InitialValue = initialValue_
            ReadInitialValue = readInitialValue_
            Min = min_
            Max = max_
            MultiplyBy = multiplyBy_
         End Sub
      End Structure

        Private Shared _typeProp As TypeProp() = New TypeProp() {New TypeProp(TypeConstants.ScaleFactor, "Scale Factor (%)", "Scale Factor", 0, True, 1, 1000, 1), New TypeProp(TypeConstants.PaintIntensity, "Paint Intensity", "Paint Intensity", 0, True, -100, 100, 10), New TypeProp(TypeConstants.PaintContrast, "Paint Contrast", "Paint Contrast", 0, True, -100, 100, 10), New TypeProp(TypeConstants.PaintGamma, "Paint Gamma", "Paint Gamma", 0, True, 10, 500, 1), New TypeProp(TypeConstants.AutoCrop, "Auto Crop (Trim)", "Threshold", 0, True, 0, 244, 1), New TypeProp(TypeConstants.Average, "Average", "Dimension", 3, False, 3, 255, 1), New TypeProp(TypeConstants.Gaussian, "Gaussian", "Radius", 0, False, 1, 1000, 1), New TypeProp(TypeConstants.Median, "Median", "Dimension", 2, False, 2, 64, 1), New TypeProp(TypeConstants.Mosaic, "Mosaic", "Dimension", 2, False, 2, 64, 1), New TypeProp(TypeConstants.Oilify, "Oilify", "Dimension", 2, False, 2, 255, 1), New TypeProp(TypeConstants.Posterize, "Posterize", "Levels", 2, False, 2, 64, 1), New TypeProp(TypeConstants.Sharpen, "Sharpen", "Sharpness", 0, False, -100, 100, 10), New TypeProp(TypeConstants.Min, "Min Filter", "Sample Size", 1, False, 1, 32, 1), New TypeProp(TypeConstants.Max, "Max Filter", "Sample Size", 1, False, 1, 32, 1), New TypeProp(TypeConstants.HistoContrast, "Histo Contrast", "Contrast", 0, False, -100, 100, 10), New TypeProp(TypeConstants.Hue, "Hue", "Angle", 0, False, -360, 360, 1), New TypeProp(TypeConstants.Solarize, "Solarize", "Threshold", 0, False, 0, 255, 1), New TypeProp(TypeConstants.Temperature, "Temperature", "Threshold", 0, False, -1000, 1000, 1)}



      Public Sub New(ByVal type As TypeConstants)
         '
         ' Required for Windows Form Designer support
         '
         InitializeComponent()

         '
         ' TODO: Add any constructor code after InitializeComponent call
         '
         _type = type
      End Sub

      Private Sub ValueDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
End Namespace
