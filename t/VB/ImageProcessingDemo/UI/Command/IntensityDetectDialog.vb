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
   'will be used for the IntensityDetectCommand

   Partial Public Class IntensityDetectDialog : Inherits Form
      Private Shared _firstTimer As Boolean = True
      Private Shared _initialLow As Integer
      Private Shared _initialHigh As Integer
      Private Shared _initialInColor As RasterColor
      Private Shared _initialOutColor As RasterColor
      Private Shared _initialChannel As IntensityDetectCommandFlags

      Public Low As Integer
      Public High As Integer
      Public InColor As RasterColor
      Public OutColor As RasterColor
      Public Channel As IntensityDetectCommandFlags

      Private Structure ChannelType
         Public Name As String
         Public Flags As IntensityDetectCommandFlags

         Public Sub New(ByVal n As String, ByVal f As IntensityDetectCommandFlags)
            Name = n
            Flags = f
         End Sub

         Public Overrides Function ToString() As String
            Return Name
         End Function
      End Structure

      Private Shared ReadOnly _channels As ChannelType() = {New ChannelType("Master", IntensityDetectCommandFlags.Master), New ChannelType("Red", IntensityDetectCommandFlags.Red), New ChannelType("Green", IntensityDetectCommandFlags.Green), New ChannelType("Blue", IntensityDetectCommandFlags.Blue), New ChannelType("Red and Green", IntensityDetectCommandFlags.Red Or IntensityDetectCommandFlags.Green), New ChannelType("Red and Blue", IntensityDetectCommandFlags.Red Or IntensityDetectCommandFlags.Blue), New ChannelType("Green and Blue", IntensityDetectCommandFlags.Green Or IntensityDetectCommandFlags.Blue), New ChannelType("Red, Green and Blue", IntensityDetectCommandFlags.Red Or IntensityDetectCommandFlags.Green Or IntensityDetectCommandFlags.Blue)}

      Public Sub New()
         InitializeComponent()
      End Sub

      Private Sub IntensityDetectDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
         'Set command default values

         If _firstTimer Then
            _firstTimer = False
            Dim command As IntensityDetectCommand = New IntensityDetectCommand()
            _initialLow = 128
            _initialHigh = 255

            If _initialLow >= _initialHigh Then
               _initialHigh = _initialLow + 1
            End If

            _initialInColor = command.InColor
            _initialOutColor = command.OutColor
            _initialChannel = command.Channel
         End If

         Low = _initialLow
         High = _initialHigh
         InColor = _initialInColor
         OutColor = _initialOutColor
         Channel = _initialChannel

         _numLow.Value = Low
         _numHigh.Value = High

         For Each i As ChannelType In _channels
            _cbChannel.Items.Add(i)
            If i.Flags = Channel Then
               _cbChannel.SelectedItem = i
            End If
         Next i

         If _cbChannel.SelectedItem Is Nothing Then
            _cbChannel.SelectedIndex = 0
         End If
      End Sub

      Private Sub _num_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles _numHigh.Leave, _numLow.Leave
         DialogUtilities.NumericOnLeave(sender)
      End Sub

      Private Sub _pnlInColor_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles _pnlInColor.Paint
         e.Graphics.FillRectangle(New SolidBrush(Leadtools.Demos.Converters.ToGdiPlusColor(InColor)), _pnlInColor.ClientRectangle)
      End Sub

      Private Sub _pnlOutColor_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles _pnlOutColor.Paint
         e.Graphics.FillRectangle(New SolidBrush(Leadtools.Demos.Converters.ToGdiPlusColor(OutColor)), _pnlOutColor.ClientRectangle)
      End Sub

      Private Sub _btnInColor_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _btnInColor.Click
         Dim dlg As ColorDialog = New ColorDialog()
         dlg.AllowFullOpen = True
         dlg.AnyColor = True
         Dim res As DialogResult = dlg.ShowDialog(Me)
         If res = DialogResult.OK Then
            InColor = Leadtools.Demos.Converters.FromGdiPlusColor(dlg.Color)
         End If
         _pnlInColor.Refresh()
      End Sub

      Private Sub _btnOutColor_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _btnOutColor.Click
         Dim dlg As ColorDialog = New ColorDialog()
         dlg.AllowFullOpen = True
         dlg.AnyColor = True
         Dim res As DialogResult = dlg.ShowDialog(Me)
         If res = DialogResult.OK Then
            OutColor = Leadtools.Demos.Converters.FromGdiPlusColor(dlg.Color)
         End If
         _pnlOutColor.Refresh()
      End Sub

      Private Sub _btnOk_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _btnOk.Click
         'Update command values
         If _numLow.Value >= _numHigh.Value Then
            Messager.ShowWarning(Me, _lblMsg.Text)
            DialogResult = DialogResult.None
            Return
         End If

         Low = CInt(_numLow.Value)
         High = CInt(_numHigh.Value)

         Dim ct As ChannelType = CType(_cbChannel.SelectedItem, ChannelType)
         Channel = ct.Flags

         _initialLow = Low
         _initialHigh = High
         _initialInColor = InColor
         _initialOutColor = OutColor
         _initialChannel = 0
      End Sub

      Private Sub EnableColorItems(ByVal enable As Boolean)
         _lblInColor.Enabled = enable
         _pnlInColor.Enabled = enable
         _btnInColor.Enabled = enable

         _lblOutColor.Enabled = enable
         _pnlOutColor.Enabled = enable
         _btnOutColor.Enabled = enable

      End Sub

      Private Sub _cbChannel_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cbChannel.SelectedIndexChanged
         Dim enable As Boolean

         Dim ct As ChannelType = CType(_cbChannel.SelectedItem, ChannelType)

         enable = (ct.Flags <> IntensityDetectCommandFlags.Master)
         EnableColorItems(enable)
      End Sub
   End Class
End Namespace
