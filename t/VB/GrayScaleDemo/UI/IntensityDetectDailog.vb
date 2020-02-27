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

Imports GrayScaleDemo.Leadtools.Demos
Imports Leadtools
Imports Leadtools.ImageProcessing.Color
Imports System



Partial Public Class IntensityDetectDailog
   Inherits Form
   Private Shared _initialLow As Integer
   Private Shared _initialHigh As Integer
   Private _OutColorLevel As Integer, _InColorLevel As Integer
   Private Shared _initialChannel As IntensityDetectCommandFlags
   Private _isGray As Boolean

   Public Low As Integer
   Public High As Integer
   Public Channel As IntensityDetectCommandFlags
   Public OutColor As RasterColor, InColor As RasterColor

   Public Sub New(isGray As Boolean)
      InitializeComponent()
      _isGray = isGray
   End Sub

   Private Structure ChannelType
      Public Name As String
      Public Flags As IntensityDetectCommandFlags

      Public Sub New(n As String, f As IntensityDetectCommandFlags)
         Name = n
         Flags = f
      End Sub

      Public Overrides Function ToString() As String
         Return Name
      End Function
   End Structure

   Private Shared ReadOnly _channels As ChannelType() = {New ChannelType("Master", IntensityDetectCommandFlags.Master), New ChannelType("Red", IntensityDetectCommandFlags.Red), New ChannelType("Green", IntensityDetectCommandFlags.Green), New ChannelType("Blue", IntensityDetectCommandFlags.Blue), New ChannelType("Red and Green", IntensityDetectCommandFlags.Red Or IntensityDetectCommandFlags.Green), New ChannelType("Red and Blue", IntensityDetectCommandFlags.Red Or IntensityDetectCommandFlags.Blue), _
    New ChannelType("Green and Blue", IntensityDetectCommandFlags.Green Or IntensityDetectCommandFlags.Blue), New ChannelType("Red, Green and Blue", IntensityDetectCommandFlags.Red Or IntensityDetectCommandFlags.Green Or IntensityDetectCommandFlags.Blue)}

   Private Sub IntensityDetectDailog_Load(sender As Object, e As EventArgs) Handles Me.Load
      Dim command As New IntensityDetectCommand()
      _initialLow = command.LowThreshold
      _initialHigh = command.HighThreshold

      If _initialLow >= _initialHigh Then
         _initialHigh = _initialLow + 1
      End If

      _InColorLevel = 0
      _OutColorLevel = 0
      _initialChannel = command.Channel

      Low = _initialLow
      High = _initialHigh
      Channel = _initialChannel

      _numLow.Value = Low
      _numHigh.Value = High
      _numOutColorLevel.Value = 0
      _numInColorLevel.Value = 0
      _pnlInRevColor.BackColor = Color.Black
      _pnlOutRevColor.BackColor = Color.Black

      If _isGray Then
         _pnlColor.Visible = False
         _pnlLevel.Visible = True
      Else
         _pnlColor.Visible = True
         _pnlLevel.Visible = False
      End If


      For Each i As ChannelType In _channels
         _cbChannel.Items.Add(i)
         If i.Flags = Channel Then
            _cbChannel.SelectedItem = i
         End If
      Next

      If _cbChannel.SelectedItem Is Nothing Then
         _cbChannel.SelectedIndex = 0
      End If
   End Sub

   Private Sub _btnOk_Click(sender As Object, e As EventArgs) Handles _btnOk.Click
      If _numLow.Value >= _numHigh.Value Then
         Messager.ShowWarning(Me, _lblMsg.Text)
         DialogResult = DialogResult.None
         Return
      End If

      Low = CInt(_numLow.Value)
      High = CInt(_numHigh.Value)
      _InColorLevel = CInt(_numInColorLevel.Value)
      _OutColorLevel = CInt(_numOutColorLevel.Value)

      Dim ct As ChannelType = CType(_cbChannel.SelectedItem, ChannelType)
      Channel = ct.Flags

      _initialLow = Low
      _initialHigh = High
      _initialChannel = 0

      If _isGray Then
         OutColor = New RasterColor(_OutColorLevel, _OutColorLevel, _OutColorLevel)
         InColor = New RasterColor(_InColorLevel, _InColorLevel, _InColorLevel)
      End If
   End Sub

   Private Sub _btnColor_Click(sender As Object, e As EventArgs) Handles _btnOutColor.Click, _btnInColor.Click
      Dim colorDlg As New ColorDialog()
      If colorDlg.ShowDialog() = DialogResult.OK Then
         If sender Is _btnInColor Then
            _pnlInRevColor.BackColor = colorDlg.Color
            InColor = Converters.FromGdiPlusColor(colorDlg.Color)
         ElseIf sender Is _btnOutColor Then
            _pnlOutRevColor.BackColor = colorDlg.Color
            OutColor = Converters.FromGdiPlusColor(colorDlg.Color)
         End If
      End If
   End Sub
End Class
