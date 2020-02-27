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

Imports Leadtools.Demos
Imports Leadtools
Imports Leadtools.ImageProcessing.Core
Imports Leadtools.Controls
Imports Leadtools.ImageProcessing
Imports System

Namespace MainDemo
   Partial Public Class WienerFilterDialog
      Inherits Form
      Private _viewer As ImageViewer
      Private _form As MainDemo.ViewerForm
      Private _mainForm As MainDemo.MainForm
      Private _applied As Boolean
      Private _orgImage As RasterImage
      Private _psf As PointSpreadFunctionData
      Private _nsr As Double = 0.001
      Private _parameter1 As Double = 5.0
      Private _parameter2 As Double = 0.8
      Private _parameter3 As PreDefinedFilterType = PreDefinedFilterType.GAUSSIAN

      Public Sub New(form As MainDemo.MainForm, viewer As MainDemo.ViewerForm)
         _mainForm = form
         _form = viewer
         _viewer = viewer.Viewer
         InitializeComponent()
      End Sub

      Private Sub WienerFilterDialog_Load(sender As Object, e As EventArgs) Handles Me.Load
         _applied = False
         _orgImage = _viewer.Image.Clone()
         _btnApply.Enabled = True
         _btnReset.Enabled = False

         Tools.FillComboBoxWithEnum(_cbP3, GetType(PreDefinedFilterType), PreDefinedFilterType.GAUSSIAN)
         _numFirstP.Text = _parameter1.ToString()
         _numSecondP.Text = _parameter2.ToString()
         _numNSR.Text = _nsr.ToString()

         Try
            If _viewer.Floater IsNot Nothing Then
               _viewer.Floater.Dispose()
               _viewer.Floater = Nothing
            End If
         Catch ex As Exception
            Messager.ShowError(Me, ex)
         End Try
      End Sub

      Private Sub ApplyFilter()
         Using wait As New WaitCursor()
            _applied = True
            _viewer.Image.MakeRegionEmpty()
            _parameter1 = Double.Parse(_numFirstP.Text)
            _parameter2 = Double.Parse(_numSecondP.Text)
            _nsr = Double.Parse(_numNSR.Text)
            _parameter3 = If((_cbP3.SelectedIndex = 0), PreDefinedFilterType.GAUSSIAN, PreDefinedFilterType.MOTION)

            Dim command As RasterCommand

            command = New PreDefinedFilterCommand(_parameter1, _parameter2, _parameter3)
            Try
               command.Run(_viewer.Image)
            Catch ex As System.Exception
               Messager.ShowError(Me, ex)
               Return
            End Try
            _psf = TryCast(command, PreDefinedFilterCommand).PSF

            command = New WienerFilterCommand(_psf, _nsr)
            Try
               command.Run(_viewer.Image)
            Catch ex As System.Exception
               Messager.ShowError(Me, ex)
               Return
            End Try

            _viewer.Invalidate()
            _form.Invalidate()
            _btnReset.Enabled = True
            _btnApply.Enabled = False
         End Using
      End Sub

      Private Sub _bntApply_Click(sender As Object, e As EventArgs) Handles _btnApply.Click
         ApplyFilter()
      End Sub

      Private Sub _btnOK_Click(sender As Object, e As EventArgs) Handles _btnOK.Click
         If Not _applied Then
            ApplyFilter()
         End If
         Me.Close()
      End Sub

      Private Sub WienerFilterDialog_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
         _viewer.Invalidate()
         _form.Invalidate()
      End Sub

      Private Sub _btnReset_Click(sender As Object, e As EventArgs) Handles _btnReset.Click
         _viewer.Image = _orgImage.Clone()
         _applied = False
         _btnApply.Enabled = True
         _btnReset.Enabled = False
      End Sub

      Private Sub _btnCancel_Click(sender As Object, e As EventArgs) Handles _btnCancel.Click
         If _applied Then
            _viewer.Image = _orgImage.Clone()
         End If
         Me.Close()
      End Sub

      Private Sub WienerFilter_ChangeLabels(sender As Object, e As EventArgs) Handles _cbP3.SelectedIndexChanged
         If _cbP3.SelectedItem.ToString() = "Gaussian" Then
            labelP1.Text = "Size"
            labelP2.Text = "Sigma"
         ElseIf _cbP3.SelectedItem.ToString() = "Motion" Then
            labelP1.Text = "Length"
            labelP2.Text = "Angle"
         End If
      End Sub
   End Class
End Namespace
