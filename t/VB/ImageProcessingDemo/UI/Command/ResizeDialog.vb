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
   'will be used for the sizeCommand

   Partial Public Class ResizeDialog : Inherits Form
      Private Shared _initialFlags As RasterSizeFlags = RasterSizeFlags.FavorBlack Or RasterSizeFlags.Resample

      Public ImageWidth As Integer
      Public ImageHeight As Integer
      Public Flags As RasterSizeFlags

      Public Sub New(ByVal imageWidth_Renamed As Integer, ByVal imageHeight_Renamed As Integer)
         InitializeComponent()

         'Set command default values
         ImageWidth = imageWidth_Renamed
         ImageHeight = imageHeight_Renamed
      End Sub

      Private Sub ResizeDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
         'Set command default values
         Flags = _initialFlags

         _numWidth.Value = ImageWidth
         _numHeight.Value = ImageHeight

         Select Case Flags
            Case RasterSizeFlags.FavorBlack
               _rbButtonFavorBlack.Checked = True

            Case RasterSizeFlags.Resample
               _rbButtonResample.Checked = True

            Case RasterSizeFlags.FavorBlack Or RasterSizeFlags.Resample
               _rbButtonFavorBlackOrResample.Checked = True

            Case RasterSizeFlags.Bicubic
               _rbButtonBicubic.Checked = True

            Case RasterSizeFlags.Bicubic Or RasterSizeFlags.FavorBlack
               _rbButtonFavorBlackOrBicubic.Checked = True

            Case Else
               _rbButtonNormal.Checked = True
         End Select
      End Sub

      Private Sub _num_Leave(ByVal sender As Object, ByVal e As System.EventArgs)
         DialogUtilities.NumericOnLeave(sender)
      End Sub

      Private Sub _btnOk_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _btnOk.Click
         'Update command values
         ImageWidth = CInt(_numWidth.Value)
         ImageHeight = CInt(_numHeight.Value)

         If _rbButtonNormal.Checked Then
            Flags = RasterSizeFlags.None
         ElseIf _rbButtonFavorBlack.Checked Then
            Flags = RasterSizeFlags.FavorBlack
         ElseIf _rbButtonResample.Checked Then
            Flags = RasterSizeFlags.Resample
         ElseIf _rbButtonFavorBlackOrResample.Checked Then
            Flags = RasterSizeFlags.FavorBlack Or RasterSizeFlags.Resample
         ElseIf _rbButtonBicubic.Checked Then
            Flags = RasterSizeFlags.Bicubic
         ElseIf _rbButtonFavorBlackOrBicubic.Checked Then
            Flags = RasterSizeFlags.FavorBlack Or RasterSizeFlags.Bicubic
         End If

         _initialFlags = Flags
      End Sub

   End Class
End Namespace
