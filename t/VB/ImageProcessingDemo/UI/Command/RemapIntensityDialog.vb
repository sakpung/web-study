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
Imports Leadtools.ImageProcessing.Effects

Namespace ImageProcessingDemo
   'This dialog is used to allow the user to specify values which
   'will be used for the RemapIntensityCommand

   Partial Public Class RemapIntensityDialog : Inherits Form
      Private _RemapIntensityCommand As RemapIntensityCommand
      Private lut As Integer()
      Private CurvePoints As Point() = New Point(255) {}
      Private _start, _end As Integer

      Public Sub New()
         InitializeComponent()
         _RemapIntensityCommand = New RemapIntensityCommand()
         _start = 0
         _end = 255


         'Set command default values
         InitializeUI()
      End Sub

      Public Property RemapIntensityCommand() As RemapIntensityCommand
         Get
            'Update command values
            UpdateCommand()
            Return _RemapIntensityCommand
         End Get
         Set(ByVal value As RemapIntensityCommand)
            _RemapIntensityCommand = value
            InitializeUI()
         End Set
      End Property

      Private Sub InitializeUI()
         Dim names As String()
         names = System.Enum.GetNames(GetType(RemapIntensityCommandFlags))
         For Each name As String In names
            If (name <> "ChangeHighBit") AndAlso (name <> "Normal") Then
               _cmbChannel.Items.Add(name)
            End If
         Next name
         _cmbChannel.SelectedIndex = 0

         _cmbMapping.Items.Add("Increase Intensity")
         _cmbMapping.Items.Add("Decrease Intensity")
         _cmbMapping.Items.Add("Invert")

         _cmbMapping.SelectedIndex = 0

      End Sub

      Private Sub UpdateCommand()
         _RemapIntensityCommand.Flags = CType(0, RemapIntensityCommandFlags)

         _RemapIntensityCommand.Flags = _RemapIntensityCommand.Flags Or TranslateChannel()
         _RemapIntensityCommand.Flags = _RemapIntensityCommand.Flags Or RemapIntensityCommandFlags.Normal

         _start = 0
         _end = 255
         _RemapIntensityCommand.LookupTable = TryCast(lut.Clone(), Integer())
      End Sub

      Public Function TranslateChannel() As RemapIntensityCommandFlags
         Select Case _cmbChannel.SelectedIndex
            Case 0
               Return RemapIntensityCommandFlags.Master
            Case 1
               Return RemapIntensityCommandFlags.Red
            Case 2
               Return RemapIntensityCommandFlags.Green
            Case 3
               Return RemapIntensityCommandFlags.Blue
            Case Else
               Return RemapIntensityCommandFlags.Master
         End Select
      End Function

      Private Sub _lblGraph_Paint(ByVal sender As Object, ByVal e As PaintEventArgs) Handles _lblGraph.Paint
         Dim DrawPen As Pen = New Pen(Brushes.Gray)
         Dim CurvePen As Pen = New Pen(Brushes.Black)

         For i As Integer = 1 To 8
            e.Graphics.DrawLine(DrawPen, New Point(i * 32, 0), New Point(i * 32, 255))
            e.Graphics.DrawLine(DrawPen, New Point(0, i * 32), New Point(255, i * 32))
         Next i

         e.Graphics.DrawCurve(CurvePen, CurvePoints)
      End Sub

      Private Sub _btnOk_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnOk.Click
         UpdateCommand()
         Me.DialogResult = DialogResult.OK
         Me.Close()
      End Sub

      Private Sub _btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnCancel.Click
         Me.DialogResult = DialogResult.Cancel
      End Sub

      Private Sub FillGraph()
         Dim j As Integer
         _start = 0
         _end = 255
         lut = New Integer(255) {}

         If _cmbMapping.SelectedItem.ToString() = "Increase Intensity" Then
            For j = 0 To lut.Length - 1
               If j < 127 Then
                  lut(j) = j * 2
               Else
                  lut(j) = 255
               End If
            Next j
         End If

         If _cmbMapping.SelectedItem.ToString() = "Decrease Intensity" Then
            j = 0
            Do While j < lut.Length
               lut(j) = CType(j / 3, Integer)
               j += 1
            Loop
         End If

         If _cmbMapping.SelectedItem.ToString() = "Invert" Then
            j = 0
            Do While j < lut.Length
               lut(j) = 255 - j
               j += 1
            Loop
         End If


         j = 0
         Do While j < lut.Length
            CurvePoints(j) = New Point(j, 255 - lut(j))
            j += 1
         Loop

         _lblGraph.Invalidate()
         _lblGraph.Refresh()

      End Sub
      Private Sub _cmbMapping_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _cmbMapping.SelectedIndexChanged
         FillGraph()
      End Sub

      Private Sub _lblGraph_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs) Handles _lblGraph.MouseMove
         _lblXVal.Text = e.X.ToString()
         _lblYVal.Text = e.Y.ToString()
      End Sub
   End Class

End Namespace
