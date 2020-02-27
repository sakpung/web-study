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
   'will be used for the GrayScaleToMultitoneCommand

   Partial Public Class GrayScaleToMultitoneDialog : Inherits Form
      Private _GrayScaleToMultitoneCommand As GrayScaleToMultitoneCommand
      Private _Colors As RasterColor()
      Public Sub New()
         InitializeComponent()
         _GrayScaleToMultitoneCommand = New GrayScaleToMultitoneCommand()

         'Set command default values
         InitializeUI()
      End Sub

      Public Property GrayScaleToMultitoneCommand() As GrayScaleToMultitoneCommand
         Get
            'Update command values
            UpdateCommand()
            Return _GrayScaleToMultitoneCommand
         End Get
         Set(ByVal value As GrayScaleToMultitoneCommand)
            _GrayScaleToMultitoneCommand = value
            InitializeUI()
         End Set
      End Property
      Private Sub InitializeUI()
         Dim names As String()
         names = System.Enum.GetNames(GetType(GrayScaleToMultitoneCommandToneType))
         For Each name As String In names
            _cmbChannels.Items.Add(name)
         Next name
         _cmbChannels.SelectedIndex = 0

         names = System.Enum.GetNames(GetType(GrayScaleToDuotoneCommandMixingType))
         For Each name As String In names
            _cmbType.Items.Add(name)
         Next name
         _cmbType.SelectedIndex = 0
      End Sub

      Private Sub UpdateCommand()
         If _cmbChannels.SelectedItem.ToString() = "Monotone" Then
            _Colors(0) = Leadtools.Demos.Converters.FromGdiPlusColor(_lblColor1.BackColor)
         End If

         If _cmbChannels.SelectedItem.ToString() = "Duotone" Then
            _Colors(0) = Leadtools.Demos.Converters.FromGdiPlusColor(_lblColor1.BackColor)
            _Colors(1) = Leadtools.Demos.Converters.FromGdiPlusColor(_lblColor2.BackColor)
         End If

         If _cmbChannels.SelectedItem.ToString() = "Tritone" Then
            _Colors(0) = Leadtools.Demos.Converters.FromGdiPlusColor(_lblColor1.BackColor)
            _Colors(1) = Leadtools.Demos.Converters.FromGdiPlusColor(_lblColor2.BackColor)
            _Colors(2) = Leadtools.Demos.Converters.FromGdiPlusColor(_lblColor3.BackColor)

         End If

         If _cmbChannels.SelectedItem.ToString() = "Quadtone" Then
            _Colors(0) = Leadtools.Demos.Converters.FromGdiPlusColor(_lblColor1.BackColor)
            _Colors(1) = Leadtools.Demos.Converters.FromGdiPlusColor(_lblColor2.BackColor)
            _Colors(2) = Leadtools.Demos.Converters.FromGdiPlusColor(_lblColor3.BackColor)
            _Colors(3) = Leadtools.Demos.Converters.FromGdiPlusColor(_lblColor4.BackColor)
         End If

         _GrayScaleToMultitoneCommand.Colors = _Colors
         _GrayScaleToMultitoneCommand.Type = TranslateType()
         _GrayScaleToMultitoneCommand.Tone = TranslateChannels()
      End Sub

      Public Function TranslateType() As GrayScaleToDuotoneCommandMixingType
         Select Case _cmbType.SelectedIndex
            Case 0
               Return GrayScaleToDuotoneCommandMixingType.MixWithOldValue
            Case 1
               Return GrayScaleToDuotoneCommandMixingType.ReplaceOldWithNew
            Case Else
               Return GrayScaleToDuotoneCommandMixingType.MixWithOldValue
         End Select
      End Function

      Public Function TranslateChannels() As GrayScaleToMultitoneCommandToneType
         Select Case _cmbChannels.SelectedIndex
            Case 0
               Return GrayScaleToMultitoneCommandToneType.Monotone
            Case 1
               Return GrayScaleToMultitoneCommandToneType.Duotone
            Case 2
               Return GrayScaleToMultitoneCommandToneType.Tritone
            Case 3
               Return GrayScaleToMultitoneCommandToneType.Quadtone
            Case Else
               Return GrayScaleToMultitoneCommandToneType.Monotone
         End Select
      End Function

      Private Sub _cmbChannels_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _cmbChannels.SelectedIndexChanged
         _Colors = Nothing
         _lblColor1.Enabled = False
         _lblColor2.Enabled = False
         _lblColor3.Enabled = False
         _lblColor4.Enabled = False

         If _cmbChannels.SelectedItem.ToString() = "Monotone" Then
            _Colors = New RasterColor(0) {}

            _lblColor1.Enabled = True

            _lblColor1.Visible = True
            _lblColor2.Visible = False
            _lblColor3.Visible = False
            _lblColor4.Visible = False
         End If

         If _cmbChannels.SelectedItem.ToString() = "Duotone" Then
            _Colors = New RasterColor(1) {}

            _lblColor1.Enabled = True
            _lblColor2.Enabled = True

            _lblColor1.Visible = True
            _lblColor2.Visible = True
            _lblColor3.Visible = False
            _lblColor4.Visible = False
         End If

         If _cmbChannels.SelectedItem.ToString() = "Tritone" Then
            _Colors = New RasterColor(2) {}

            _lblColor1.Enabled = True
            _lblColor2.Enabled = True
            _lblColor3.Enabled = True

            _lblColor1.Visible = True
            _lblColor2.Visible = True
            _lblColor3.Visible = True
            _lblColor4.Visible = False
         End If

         If _cmbChannels.SelectedItem.ToString() = "Quadtone" Then
            _Colors = New RasterColor(3) {}

            _lblColor1.Enabled = True
            _lblColor2.Enabled = True
            _lblColor3.Enabled = True
            _lblColor4.Enabled = True

            _lblColor1.Visible = True
            _lblColor2.Visible = True
            _lblColor3.Visible = True
            _lblColor4.Visible = True
         End If
      End Sub
      Private Sub _lblColor1_MouseClick(ByVal sender As Object, ByVal e As MouseEventArgs) Handles _lblColor1.MouseClick
         If e.Button = MouseButtons.Left Then
            Dim ColorDlg As ColorDialog = New ColorDialog()
            If ColorDlg.ShowDialog(Me) = DialogResult.OK Then
               _lblColor1.BackColor = ColorDlg.Color
            End If
         End If
      End Sub

      Private Sub _lblColor2_MouseClick(ByVal sender As Object, ByVal e As MouseEventArgs) Handles _lblColor2.MouseClick
         If e.Button = MouseButtons.Left Then
            Dim ColorDlg As ColorDialog = New ColorDialog()
            If ColorDlg.ShowDialog(Me) = DialogResult.OK Then
               _lblColor2.BackColor = ColorDlg.Color
            End If
         End If
      End Sub

      Private Sub _lblColor3_MouseClick(ByVal sender As Object, ByVal e As MouseEventArgs) Handles _lblColor3.MouseClick
         If e.Button = MouseButtons.Left Then
            Dim ColorDlg As ColorDialog = New ColorDialog()
            If ColorDlg.ShowDialog(Me) = DialogResult.OK Then
               _lblColor3.BackColor = ColorDlg.Color
            End If
         End If
      End Sub

      Private Sub _lblColor4_MouseClick(ByVal sender As Object, ByVal e As MouseEventArgs) Handles _lblColor4.MouseClick
         If e.Button = MouseButtons.Left Then
            Dim ColorDlg As ColorDialog = New ColorDialog()
            If ColorDlg.ShowDialog(Me) = DialogResult.OK Then
               _lblColor4.BackColor = ColorDlg.Color
            End If
         End If
      End Sub

      Private Sub _btnOk_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnOk.Click
         UpdateCommand()
         Me.DialogResult = DialogResult.OK
         Me.Close()
      End Sub

      Private Sub _btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnCancel.Click
         Me.DialogResult = DialogResult.Cancel
      End Sub
   End Class
End Namespace
