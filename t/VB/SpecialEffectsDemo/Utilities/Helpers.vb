' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Drawing

Imports Leadtools.SpecialEffects

Namespace SpecialEffectsDemo
   Friend Class ComboBoxItem
      Private _display As String
      Private _value As Integer

      Public Sub New(ByVal display_Renamed As String, ByVal value_Renamed As Integer)
         _display = display_Renamed
         _value = value_Renamed
      End Sub

      Public ReadOnly Property Display() As String
         Get
            Return _display
         End Get
      End Property

      Public ReadOnly Property Value() As Integer
         Get
            Return _value
         End Get
      End Property
   End Class

   Public Structure EffectOptions
      Public Type As SpecialEffectsType
      Public Delay As Integer
      Public Grain As Integer
      Public Passes As Integer
      Public Wand As Integer

      Public Sub New(ByVal type_Renamed As SpecialEffectsType, ByVal delay_Renamed As Integer, ByVal grain_Renamed As Integer, ByVal passes_Renamed As Integer, ByVal wand_Renamed As Integer)
         Type = type_Renamed
         Delay = delay_Renamed
         Grain = grain_Renamed
         Passes = passes_Renamed
         Wand = wand_Renamed
      End Sub
   End Structure

   Public Structure TransitionOptions
      Public Style As SpecialEffectsTransitionStyle
      Public ForeColor As Color
      Public BackColor As Color
      Public EffectOptions As EffectOptions

      Public Sub New(ByVal style_Renamed As SpecialEffectsTransitionStyle, ByVal foreColor_Renamed As Color, ByVal backColor_Renamed As Color, ByVal effectOptions_Renamed As EffectOptions)
         Style = style_Renamed
         ForeColor = foreColor_Renamed
         BackColor = backColor_Renamed
         EffectOptions = effectOptions_Renamed
      End Sub
   End Structure

   Public Structure ShapeOptions
      Public ShapeStyle As SpecialEffectsShape
      Public FillStyle As SpecialEffectsFillStyle
      Public ForeColor As Color
      Public BackColor As Color

      Public Sub New(ByVal shapeStyle_Renamed As SpecialEffectsShape, ByVal fillStyle_Renamed As SpecialEffectsFillStyle, ByVal foreColor_Renamed As Color, ByVal backColor_Renamed As Color)
         ShapeStyle = shapeStyle_Renamed
         FillStyle = fillStyle_Renamed
         ForeColor = foreColor_Renamed
         BackColor = backColor_Renamed
      End Sub
   End Structure

   Public Structure TextOptions
      Public Text As String
      Public Style As SpecialEffectsTextStyle
      Public TextColor As Color
      Public BorderColor As Color

      Public Sub New(ByVal text_Renamed As String, ByVal style_Renamed As SpecialEffectsTextStyle, ByVal textColor_Renamed As Color, ByVal borderColor_Renamed As Color)
         Text = text_Renamed
         Style = style_Renamed
         TextColor = textColor_Renamed
         BorderColor = borderColor_Renamed
      End Sub
   End Structure
End Namespace
