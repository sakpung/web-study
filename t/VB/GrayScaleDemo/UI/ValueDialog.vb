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
Imports System

Partial Public Class ValueDialog
   Inherits Form
   Private _value As Integer
   Private _type As TypeConstants

   Public ReadOnly Property Value() As Integer
      Get
         Return _value
      End Get
   End Property

   Public Sub New(type As TypeConstants)
      InitializeComponent()
      _type = type
   End Sub

   Public Enum TypeConstants
      AddColorToRegion
      Average
      Maximum
      Minimum
      Median
      Sharpen
      Gaussian
      Contrast
      Brightness
      Saturation
      AutoCrop
      FastMagicWand
   End Enum

   Private Structure TypeProp
      Public Type As TypeConstants
      Public CaptionName As String
      Public ValueName As String
      Public InitialValue As Integer
      Public Min As Integer
      Public Max As Integer

      Public Sub New(type__1 As TypeConstants, captionName__2 As String, valueName__3 As String, initialValue__4 As Integer, min__5 As Integer, max__6 As Integer)
         Type = type__1
         CaptionName = captionName__2
         ValueName = valueName__3
         InitialValue = initialValue__4
         Min = min__5
         Max = max__6
      End Sub
   End Structure

   Private Shared _typeProp As TypeProp() = New TypeProp() {New TypeProp(TypeConstants.AddColorToRegion, "Add Color To Region", "Color level", 0, 0, 255), New TypeProp(TypeConstants.Average, "Average", "Dimension", 3, 3, 255), New TypeProp(TypeConstants.Maximum, "Maximum", "Sample Size", 1, 1, 32), New TypeProp(TypeConstants.Minimum, "Minimum", "Sample Size", 1, 1, 32), New TypeProp(TypeConstants.Median, "Median", "Dimension", 2, 2, 64), New TypeProp(TypeConstants.Sharpen, "Sharpen", "Sharpness", 0, -100, 100), _
    New TypeProp(TypeConstants.Gaussian, "Gaussian", "Radius", 1, 1, 1000), New TypeProp(TypeConstants.Contrast, "Contrast", "Contrast", 0, -1000, 1000), New TypeProp(TypeConstants.Brightness, "Brightness", "Brightness", 0, -1000, 1000), New TypeProp(TypeConstants.Saturation, "Saturation", "Change", 0, -500, 500), New TypeProp(TypeConstants.AutoCrop, "Auto Crop", "Threshold ", 0, 0, 255), New TypeProp(TypeConstants.FastMagicWand, "Fast Magic Wand", "Tolerance ", 0, 0, 255), _
    New TypeProp(TypeConstants.FastMagicWand, "Border Color level", "Border ", 0, 0, 255)}

   Private Sub ValueDialog_Load(sender As Object, e As EventArgs) Handles Me.Load
      Dim prop As TypeProp = _typeProp(CInt(_type))
      Text = prop.CaptionName
      _gbOptions.Text = prop.ValueName
      _numValue.Minimum = prop.Min
      _numValue.Maximum = prop.Max
      _numValue.Value = prop.InitialValue
   End Sub

   Private Sub _btnOk_Click(sender As Object, e As EventArgs) Handles _btnOk.Click
      _value = CInt(_numValue.Value)
   End Sub

   Private Sub _btnCancel_Click(sender As Object, e As EventArgs) Handles _btnCancel.Click
      Close()
   End Sub


End Class
