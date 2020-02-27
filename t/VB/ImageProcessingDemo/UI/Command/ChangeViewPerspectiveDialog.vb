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
Imports Leadtools.ImageProcessing

Namespace ImageProcessingDemo
   'This dialog is used to allow the user to specify values which
   'will be used for the ChangeViewPerspectiveCommand

   Partial Public Class ChangeViewPerspectiveDialog : Inherits Form
      Private _ChangeViewPerspectiveCommand As ChangeViewPerspectiveCommand

      Public Sub New()
         InitializeComponent()
         _ChangeViewPerspectiveCommand = New ChangeViewPerspectiveCommand()

         'Set command default values
         InitializeUI()

      End Sub
      Private Sub InitializeUI()
            Dim names As String()
            Dim Values As Array
            names = System.Enum.GetNames(GetType(RasterViewPerspective))
            Values = System.Enum.GetValues(GetType(RasterViewPerspective))
            Dim i As Integer

            For i = 1 To 8
                _cmbViewPerspective.Items.Add(CType(i, RasterViewPerspective).ToString())
            Next

            _cmbViewPerspective.SelectedIndex = 0
        End Sub
      Public Property ChangeViewPerspectivecommand() As ChangeViewPerspectiveCommand
         Get
            'Update command values
            UpdateCommand()
            Return _ChangeViewPerspectiveCommand
         End Get
         Set(ByVal value As ChangeViewPerspectiveCommand)
            _ChangeViewPerspectiveCommand = value
            InitializeUI()
         End Set
      End Property
      Private Sub UpdateCommand()
         _ChangeViewPerspectiveCommand.ViewPerspective = TranslateViewPerspective()
      End Sub

      Public Function TranslateViewPerspective() As RasterViewPerspective
         Select Case _cmbViewPerspective.SelectedItem.ToString()
            Case "BottomLeft"
               Return RasterViewPerspective.BottomLeft
            Case "BottomLeft180"
               Return RasterViewPerspective.BottomLeft180
            Case "BottomLeft270"
               Return RasterViewPerspective.BottomLeft270
            Case "BottomLeft90"
               Return RasterViewPerspective.BottomLeft90
            Case "BottomRight"
               Return RasterViewPerspective.BottomRight
            Case "LeftBottom"
               Return RasterViewPerspective.LeftBottom
            Case "LeftTop"
               Return RasterViewPerspective.LeftTop
            Case "RightBottom"
               Return RasterViewPerspective.RightBottom
            Case "RightTop"
               Return RasterViewPerspective.RightTop
            Case "TopLeft"
               Return RasterViewPerspective.TopLeft
            Case "TopLeft180"
               Return RasterViewPerspective.TopLeft180
            Case "TopLeft270"
               Return RasterViewPerspective.TopLeft270
            Case "TopLeft90"
               Return RasterViewPerspective.TopLeft90
            Case "TopRight"
               Return RasterViewPerspective.TopRight
            Case Else
               Return RasterViewPerspective.TopLeft
         End Select
      End Function

      Private Sub _btnok_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnok.Click
         UpdateCommand()
         Me.DialogResult = DialogResult.OK
         Me.Close()
      End Sub

      Private Sub _btncancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btncancel.Click
         Me.DialogResult = DialogResult.Cancel
      End Sub
   End Class
End Namespace
