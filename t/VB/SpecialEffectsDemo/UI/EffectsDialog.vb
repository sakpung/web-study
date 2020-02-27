' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms

Imports Leadtools
Imports Leadtools.SpecialEffects

Namespace SpecialEffectsDemo
   Partial Public Class EffectsDialog : Inherits Form
      Public Sub New(ByVal options As EffectOptions)
         _effectOptions = options

         InitializeComponent()
      End Sub

      Private _effectOptions As EffectOptions

      Private Sub EffectsDialog_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
         Dim items As ArrayList = New ArrayList()

         items.Add(New ComboBoxItem("No Effect", CInt(SpecialEffectsType.None)))
         items.Add(New ComboBoxItem("Linear Wipes: Left To Right", CInt(SpecialEffectsType.WipeLToR)))
         items.Add(New ComboBoxItem("Rectangle Wipes: In", CInt(SpecialEffectsType.WipeRectangleIn)))
         items.Add(New ComboBoxItem("Circular Wipes: Center CW from Left", CInt(SpecialEffectsType.WipeCircleCCWFromL)))
         items.Add(New ComboBoxItem("Pushes: Right to Left", CInt(SpecialEffectsType.PushRToL)))
         items.Add(New ComboBoxItem("Slides: Right to Left", CInt(SpecialEffectsType.SlideRToL)))
         items.Add(New ComboBoxItem("Rolls: Left to Right", CInt(SpecialEffectsType.RollLToR)))
         items.Add(New ComboBoxItem("Rotates: Left to Right", CInt(SpecialEffectsType.RotateTToB)))
         items.Add(New ComboBoxItem("Zooms: to Center", CInt(SpecialEffectsType.ZoomToC)))
         items.Add(New ComboBoxItem("Drips: Top to Bottom", CInt(SpecialEffectsType.DripTToB)))
         items.Add(New ComboBoxItem("Blinds: Top to Bottom", CInt(SpecialEffectsType.BlindTToB)))
         items.Add(New ComboBoxItem("Random Effects: Bars Right to Left", CInt(SpecialEffectsType.RandomBarsRToL)))
         items.Add(New ComboBoxItem("CheckerBorads: Top to Bottom then Top to Bottom", CInt(SpecialEffectsType.CheckboardTToBThenTToB)))
         items.Add(New ComboBoxItem("Blocks: Top to Bottom", CInt(SpecialEffectsType.BlocksTToB)))
         items.Add(New ComboBoxItem("Circular Effects: Center In", CInt(SpecialEffectsType.CircleCIn)))
         items.Add(New ComboBoxItem("Elliptical Effects: Center In", CInt(SpecialEffectsType.EllipseCIn)))

         _cmbEffectStyle.DataSource = items
         _cmbEffectStyle.DisplayMember = "Display"
         _cmbEffectStyle.ValueMember = "Value"

         Dim i As Integer = 0
         Do While i < _cmbEffectStyle.Items.Count
            Dim item As ComboBoxItem = CType(_cmbEffectStyle.Items(i), ComboBoxItem)
            If _effectOptions.Type = CType(item.Value, SpecialEffectsType) Then
               _cmbEffectStyle.SelectedIndex = i
            End If
            i += 1
         Loop

         _numDelay.Minimum = 0
         _numDelay.Maximum = 999
         _numDelay.Value = _effectOptions.Delay

         _numGrain.Minimum = 1
         _numGrain.Maximum = 256
         _numGrain.Value = _effectOptions.Grain

         _numPasses.Minimum = 1
         _numPasses.Maximum = 64
         _numPasses.Value = _effectOptions.Passes

         _numWand.Minimum = 0
         _numWand.Maximum = 256
         _numWand.Value = _effectOptions.Wand
      End Sub

      Private Sub _btnOK_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnOK.Click
         Dim item As ComboBoxItem = CType(_cmbEffectStyle.SelectedItem, ComboBoxItem)

         _effectOptions.Type = CType(item.Value, SpecialEffectsType)
         _effectOptions.Delay = CInt(_numDelay.Value)
         _effectOptions.Grain = CInt(_numGrain.Value)
         _effectOptions.Passes = CInt(_numPasses.Value)
         _effectOptions.Wand = CInt(_numWand.Value)
      End Sub

      Public ReadOnly Property EffectOptions() As EffectOptions
         Get
            Return _effectOptions
         End Get
      End Property
   End Class
End Namespace
