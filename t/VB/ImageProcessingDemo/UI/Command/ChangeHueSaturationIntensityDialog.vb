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
Imports Leadtools.ImageProcessing.Color

Namespace ImageProcessingDemo
   'This dialog is used to allow the user to specify values which
   'will be used for the ChangeHueSaturationIntensityCommand
   Partial Public Class ChangeHueSaturationIntensityDialog : Inherits Form
      Private _ChangeHueSaturationIntensityCommand As ChangeHueSaturationIntensityCommand
      Private _changeHSIData As ChangeHueSaturationIntensityCommandData() = New ChangeHueSaturationIntensityCommandData(5) {}

      Private _hue, _saturation, _intensity As Integer
      Private _colorHue, _colorSaturation, _colorIntensity As Integer
      Private _innerLow, _innerHigh, _outerLow, _outerHigh As Integer
      Private nPosInit As Integer() = {0, 0, 0, 0, 359, 90, 180}
      Private _lastIndex As Integer
      Private _finished As Boolean

      Public Sub New()
         InitializeComponent()
         _ChangeHueSaturationIntensityCommand = New ChangeHueSaturationIntensityCommand()

         'Set command default values
         InitializeUI()
      End Sub

      Public Property ChangeHueSaturationIntensityCommand() As ChangeHueSaturationIntensityCommand
         Get
            'Update command values
            UpdateCommand()
            Return _ChangeHueSaturationIntensityCommand
         End Get
         Set(ByVal value As ChangeHueSaturationIntensityCommand)
            _ChangeHueSaturationIntensityCommand = value
            InitializeUI()
         End Set
      End Property

      Private Sub InitializeUI()
         _cmbMask.Items.Add("Master")
         _cmbMask.Items.Add("Color 1")
         _cmbMask.Items.Add("Color 2")
         _cmbMask.Items.Add("Color 3")
         _cmbMask.Items.Add("Color 4")
         _cmbMask.Items.Add("Color 5")
         _cmbMask.Items.Add("Color 6")

         _cmbMask.SelectedIndex = 0

         _numIntensity.Value = 0
         _numHue.Value = 0
         _numSaturation.Value = 0
         
         _hue = 0
         _saturation = 0
         _intensity = 0

         
         _numOuterLow.Value = nPosInit(3)
         _outerLow = nPosInit(3)
         
         _numOuterHigh.Value = nPosInit(4)
         _outerHigh = nPosInit(4)
         
         _numInnerLow.Value = nPosInit(5)
         _innerLow = nPosInit(5)
         
         _numInnerHigh.Value = nPosInit(6)
         _innerHigh = nPosInit(6)

         For nCounter As Integer = 0 To 5
            _changeHSIData(nCounter) = New ChangeHueSaturationIntensityCommandData()

            _changeHSIData(nCounter).Intensity = 0
            _changeHSIData(nCounter).Saturation = 0
            _changeHSIData(nCounter).Hue = 0

            _changeHSIData(nCounter).OuterLow = nPosInit(3)
            _changeHSIData(nCounter).OuterHigh = nPosInit(4)
            _changeHSIData(nCounter).InnerLow = nPosInit(5)
            _changeHSIData(nCounter).InnerHigh = nPosInit(6)
         Next nCounter

         _finished = True
      End Sub

      Private Sub UpdateCommand()
         AssignValues()
         _ChangeHueSaturationIntensityCommand.Hue = _hue * 100
         _ChangeHueSaturationIntensityCommand.Saturation = _saturation * 10
         _ChangeHueSaturationIntensityCommand.Intensity = _intensity * 10
         _ChangeHueSaturationIntensityCommand.Data = CType(_changeHSIData.Clone(), ChangeHueSaturationIntensityCommandData())
      End Sub

      Private Sub _cmbMask_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _cmbMask.SelectedIndexChanged
         SetDefaultValues()
      End Sub

      Private Sub SetDefaultValues()
         _finished = False
         If Not _cmbMask.SelectedItem Is Nothing Then
            If _cmbMask.SelectedItem.ToString() = "Master" Then
               _numHue.Value = _hue
               _numSaturation.Value = _saturation
               _numIntensity.Value = _intensity

               _gbInnerRange.Enabled = False
               _gbOuterRange.Enabled = False
            End If

            If _cmbMask.SelectedItem.ToString().LastIndexOf("Color") <> -1 Then
               _gbInnerRange.Enabled = True
               _gbOuterRange.Enabled = True

               If _numInnerLow.Value <= _numOuterLow.Value Then
                  _numInnerLow.Value = _numOuterLow.Value + 1
                  Return
               End If
               If _numInnerHigh.Value <= _numInnerLow.Value Then
                  _numInnerHigh.Value = _numInnerLow.Value + 1
                  Return
               End If
               _numHue.Value = _changeHSIData(_cmbMask.SelectedIndex - 1).Hue
               _numSaturation.Value = _changeHSIData(_cmbMask.SelectedIndex - 1).Saturation
               _numIntensity.Value = _changeHSIData(_cmbMask.SelectedIndex - 1).Intensity
               _numInnerLow.Value = _changeHSIData(_cmbMask.SelectedIndex - 1).InnerLow
               _numInnerHigh.Value = _changeHSIData(_cmbMask.SelectedIndex - 1).InnerHigh
               _numOuterLow.Value = _changeHSIData(_cmbMask.SelectedIndex - 1).OuterLow
               _numOuterHigh.Value = _changeHSIData(_cmbMask.SelectedIndex - 1).OuterHigh
            End If
            _finished = True
         End If
      End Sub
      Private Sub AssignValues()

         If Not _cmbMask.SelectedItem Is Nothing Then
            If _finished Then
               If _cmbMask.SelectedItem.ToString() = "Master" Then
                  _hue = Convert.ToInt32(_numHue.Value)
                  _saturation = Convert.ToInt32(_numSaturation.Value)
                  _intensity = Convert.ToInt32(_numIntensity.Value)

                  _gbInnerRange.Enabled = False
                  _gbOuterRange.Enabled = False
               End If

               If _cmbMask.SelectedItem.ToString().LastIndexOf("Color") <> -1 Then
                  _gbInnerRange.Enabled = True
                  _gbOuterRange.Enabled = True

                  If _numInnerLow.Value <= _numOuterLow.Value Then
                     _numInnerLow.Value = _numOuterLow.Value + 1
                     Return
                  End If
                  If _numInnerHigh.Value <= _numInnerLow.Value Then
                     _numInnerHigh.Value = _numInnerLow.Value + 1
                     Return
                  End If
                  _colorHue = Convert.ToInt32(_numHue.Value)
                  _colorSaturation = Convert.ToInt32(_numSaturation.Value)
                  _colorIntensity = Convert.ToInt32(_numIntensity.Value)
                  _innerLow = Convert.ToInt32(_numInnerLow.Value)
                  _innerHigh = Convert.ToInt32(_numInnerHigh.Value)
                  _outerLow = Convert.ToInt32(_numOuterLow.Value)
                  _outerHigh = Convert.ToInt32(_numOuterHigh.Value)

                  _changeHSIData(_cmbMask.SelectedIndex - 1).Hue = _colorHue
                  _changeHSIData(_cmbMask.SelectedIndex - 1).Saturation = _colorSaturation
                  _changeHSIData(_cmbMask.SelectedIndex - 1).Intensity = _colorIntensity
                  _changeHSIData(_cmbMask.SelectedIndex - 1).InnerLow = _innerLow
                  _changeHSIData(_cmbMask.SelectedIndex - 1).InnerHigh = _innerHigh
                  _changeHSIData(_cmbMask.SelectedIndex - 1).OuterLow = _outerLow
                  _changeHSIData(_cmbMask.SelectedIndex - 1).OuterHigh = _outerHigh
               End If
            End If
         End If
      End Sub

      Private Sub _numHue_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _numHue.ValueChanged
         _tbHue.Value = Convert.ToInt32(_numHue.Value)
         AssignValues()
      End Sub

      Private Sub _numSaturation_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _numSaturation.ValueChanged
         _tbSaturation.Value = Convert.ToInt32(_numSaturation.Value)
         AssignValues()
      End Sub

      Private Sub _numIntensity_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _numIntensity.ValueChanged
         _tbIntensity.Value = Convert.ToInt32(_numIntensity.Value)
         AssignValues()
      End Sub

      Private Sub _numOuterLow_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _numOuterLow.ValueChanged
         _tbOuterLow.Value = Convert.ToInt32(_numOuterLow.Value)
         AssignValues()
      End Sub

      Private Sub _numOuterHigh_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _numOuterHigh.ValueChanged
         _tbOuterHigh.Value = Convert.ToInt32(_numOuterHigh.Value)
         AssignValues()
      End Sub

      Private Sub _numInnerLow_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _numInnerLow.ValueChanged
         _tbInnerLow.Value = Convert.ToInt32(_numInnerLow.Value)
         AssignValues()
      End Sub

      Private Sub _numInnerHigh_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _numInnerHigh.ValueChanged
         _tbInnerHigh.Value = Convert.ToInt32(_numInnerHigh.Value)
         AssignValues()
      End Sub

      Private Sub _numHue_Leave(ByVal sender As Object, ByVal e As EventArgs) Handles _numHue.Leave
         DialogUtilities.NumericOnLeave(sender)
         AssignValues()
      End Sub

      Private Sub _numSaturation_Leave(ByVal sender As Object, ByVal e As EventArgs) Handles _numSaturation.Leave
         DialogUtilities.NumericOnLeave(sender)
         AssignValues()
      End Sub

      Private Sub _numIntensity_Leave(ByVal sender As Object, ByVal e As EventArgs) Handles _numIntensity.Leave
         DialogUtilities.NumericOnLeave(sender)
         AssignValues()
      End Sub

      Private Sub _numOuterLow_Leave(ByVal sender As Object, ByVal e As EventArgs) Handles _numOuterLow.Leave
         DialogUtilities.NumericOnLeave(sender)
         AssignValues()
      End Sub

      Private Sub _numOuterHigh_Leave(ByVal sender As Object, ByVal e As EventArgs) Handles _numOuterHigh.Leave
         DialogUtilities.NumericOnLeave(sender)
         AssignValues()
      End Sub

      Private Sub _numInnerLow_Leave(ByVal sender As Object, ByVal e As EventArgs) Handles _numInnerLow.Leave
         DialogUtilities.NumericOnLeave(sender)
         AssignValues()
      End Sub

      Private Sub _numInnerHigh_Leave(ByVal sender As Object, ByVal e As EventArgs) Handles _numInnerHigh.Leave
         DialogUtilities.NumericOnLeave(sender)
         AssignValues()
      End Sub

      Private Sub _tbHue_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles _tbHue.Scroll
         _numHue.Value = _tbHue.Value
         AssignValues()
      End Sub

      Private Sub _tbSaturation_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles _tbSaturation.Scroll
         _numSaturation.Value = _tbSaturation.Value
         AssignValues()
      End Sub

      Private Sub _tbIntensity_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles _tbIntensity.Scroll
         _numIntensity.Value = _tbIntensity.Value
         AssignValues()
      End Sub

      Private Sub _tbOuterLow_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles _tbOuterLow.Scroll
         If _tbOuterLow.Value <= _tbInnerLow.Value Then
            _numOuterLow.Value = _tbOuterLow.Value
         Else
            _tbOuterLow.Value = _tbInnerLow.Value - 1
            Return
         End If


         AssignValues()
      End Sub

      Private Sub _tbOuterHigh_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles _tbOuterHigh.Scroll
         If _tbOuterHigh.Value > _tbInnerHigh.Value Then
            _numOuterHigh.Value = _tbOuterHigh.Value
         Else
            _tbOuterHigh.Value = _tbInnerHigh.Value + 1
            Return
         End If
         AssignValues()
      End Sub

      Private Sub _tbInnerLow_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles _tbInnerLow.Scroll
         If _tbInnerLow.Value <= _tbInnerHigh.Value Then
            _numInnerLow.Value = _tbInnerLow.Value
         Else
            _tbInnerLow.Value = _tbInnerHigh.Value - 1
            Return
         End If
         AssignValues()
      End Sub

      Private Sub _tbInnerHigh_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles _tbInnerHigh.Scroll
         If _tbInnerHigh.Value <= _tbOuterHigh.Value Then
            _numInnerHigh.Value = _tbInnerHigh.Value
         Else
            _tbInnerHigh.Value = _tbOuterHigh.Value - 1
            Return
         End If

         AssignValues()
      End Sub

      Private Sub _btnok_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnok.Click
         UpdateCommand()
         Me.DialogResult = DialogResult.OK
         Me.Close()
      End Sub

      Private Sub _btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnCancel.Click
         Me.DialogResult = DialogResult.Cancel
      End Sub

      Private Sub ChangeHueSaturationIntensityDialog_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs) Handles MyBase.MouseMove
         _lastIndex = _cmbMask.SelectedIndex
      End Sub
   End Class
End Namespace
