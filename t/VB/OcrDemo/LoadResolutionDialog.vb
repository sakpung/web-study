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
Imports System.IO
Imports System.Diagnostics

Imports Leadtools.Ocr
Imports Leadtools.Codecs
Imports System

Namespace OcrDemo
   Partial Public Class LoadResolutionDialog
      Inherits Form
      Private _rasterCodecs As RasterCodecs

      Public Sub New(codecs As RasterCodecs)
         InitializeComponent()

         _rasterCodecs = codecs
      End Sub

      Protected Overrides Sub OnLoad(e As EventArgs)
         If Not DesignMode Then
            _xResolutionTextBox.Text = _rasterCodecs.Options.RasterizeDocument.Load.XResolution.ToString()
            _yResolutionTextBox.Text = _rasterCodecs.Options.RasterizeDocument.Load.YResolution.ToString()
         End If

         MyBase.OnLoad(e)
      End Sub

      Private Sub _okButton_Click(sender As Object, e As EventArgs) Handles _okButton.Click
         Dim value As Integer = 0
         If Integer.TryParse(_xResolutionTextBox.Text, value) Then
            _rasterCodecs.Options.RasterizeDocument.Load.XResolution = value
         End If

         If Integer.TryParse(_yResolutionTextBox.Text, value) Then
            _rasterCodecs.Options.RasterizeDocument.Load.YResolution = value
         End If
      End Sub
   End Class
End Namespace
