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

Imports Leadtools.SpecialEffects
Namespace SpecialEffectsDemo
   Partial Public Class TransitionDialog : Inherits Form

      Public Sub New(ByVal transitionOptions_Renamed As TransitionOptions)
         _transitionOptions = transitionOptions_Renamed

         InitializeComponent()
      End Sub

      Private _transitionOptions As TransitionOptions
      Private _effectType As SpecialEffectsType
      Private Sub TransitionDialog_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
         Dim items As ArrayList = New ArrayList()

         items.Add(New ComboBoxItem("Solid", CInt(SpecialEffectsTransitionStyle.Solid)))
         items.Add(New ComboBoxItem("Horizontal Lines", CInt(SpecialEffectsTransitionStyle.HorzLine)))
         items.Add(New ComboBoxItem("Vertical Lines", CInt(SpecialEffectsTransitionStyle.VertLine)))
         items.Add(New ComboBoxItem("Forward Diagonal Lines", CInt(SpecialEffectsTransitionStyle.UpwardDiagnoal)))
         items.Add(New ComboBoxItem("Backward Diagonal Lines", CInt(SpecialEffectsTransitionStyle.DownwardDiagnoal)))
         items.Add(New ComboBoxItem("Cross Lines", CInt(SpecialEffectsTransitionStyle.Cross)))
         items.Add(New ComboBoxItem("Diagonal Cross Lines", CInt(SpecialEffectsTransitionStyle.DiagCross)))
         items.Add(New ComboBoxItem("Gradient Conical from Bottom", CInt(SpecialEffectsTransitionStyle.ConeFromB)))

         _cmbTransitionStyle.DataSource = items
         _cmbTransitionStyle.DisplayMember = "Display"
         _cmbTransitionStyle.ValueMember = "Value"

         Dim i As Integer = 0
         Do While i < _cmbTransitionStyle.Items.Count
            Dim item As ComboBoxItem = CType(_cmbTransitionStyle.Items(i), ComboBoxItem)
            If _transitionOptions.Style = CType(item.Value, SpecialEffectsTransitionStyle) Then
               _cmbTransitionStyle.SelectedIndex = i
            End If
            i += 1
         Loop

         _btnForeColor.BackColor = _transitionOptions.ForeColor
         _btnBackColor.BackColor = _transitionOptions.BackColor

         _effectType = _transitionOptions.EffectOptions.Type
         _numDelay.Value = _transitionOptions.EffectOptions.Delay
         _numGrain.Value = _transitionOptions.EffectOptions.Grain
         _numPasses.Value = _transitionOptions.EffectOptions.Passes
         _numWand.Value = _transitionOptions.EffectOptions.Wand
      End Sub

      Private Sub _btnEffect_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnEffect.Click
         Dim item As ComboBoxItem = CType(_cmbTransitionStyle.SelectedItem, ComboBoxItem)

         Dim dlg As EffectsDialog = New EffectsDialog(New EffectOptions(_effectType, CInt(_numDelay.Value), CInt(_numGrain.Value), CInt(_numPasses.Value), CInt(_numWand.Value)))

         If dlg.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
            _effectType = dlg.EffectOptions.Type
            _numDelay.Value = dlg.EffectOptions.Delay
            _numGrain.Value = dlg.EffectOptions.Grain
            _numPasses.Value = dlg.EffectOptions.Passes
            _numWand.Value = dlg.EffectOptions.Wand
         End If
      End Sub

      Public ReadOnly Property TransitionOptions() As TransitionOptions
         Get
            Return _transitionOptions
         End Get
      End Property

      Private Sub _btnForeColor_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnForeColor.Click
         Dim dlg As ColorDialog = New ColorDialog()
         If dlg.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
            _btnForeColor.BackColor = dlg.Color
         End If
      End Sub

      Private Sub _btnBackColor_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnBackColor.Click
         Dim dlg As ColorDialog = New ColorDialog()
         If dlg.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
            _btnBackColor.BackColor = dlg.Color
         End If
      End Sub

      Private Sub _btnOK_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnOK.Click
         Dim item As ComboBoxItem = CType(_cmbTransitionStyle.SelectedItem, ComboBoxItem)
         _transitionOptions.Style = CType(item.Value, SpecialEffectsTransitionStyle)
         _transitionOptions.ForeColor = _btnForeColor.BackColor
         _transitionOptions.BackColor = _btnBackColor.BackColor
         _transitionOptions.EffectOptions = New EffectOptions(_effectType, CInt(_numDelay.Value), CInt(_numGrain.Value), CInt(_numPasses.Value), CInt(_numWand.Value))
      End Sub
   End Class
End Namespace
