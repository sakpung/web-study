' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports Leadtools.MedicalViewer

Namespace FusionDemo
   Partial Public Class FuseTwoCellsProperties : Inherits Form
      Private _orgCellImagesCount As Integer = 0
      Private _fuCellImagesCount As Integer = 0

      Public Sub New()
         InitializeComponent()
      End Sub

      Public ReadOnly Property Start() As Integer
         Get
            Return CInt(_numStart.Value)
         End Get
      End Property

      Public ReadOnly Property [End]() As Integer
         Get
            Return CInt(_numEnd.Value)
         End Get
      End Property

      Public ReadOnly Property UseBestAligned() As Boolean
         Get
            Return _chkBestAligned.Checked AndAlso _chkBestAligned.Enabled
         End Get
      End Property

      Public Property EnableBestAligned() As Boolean
         Get
            Return _chkBestAligned.Enabled
         End Get
         Set(value As Boolean)
            _chkBestAligned.Enabled = value
         End Set
      End Property

      Public Property BestAlignedChecked() As Boolean
         Get
            Return _chkBestAligned.Checked
         End Get
         Set(value As Boolean)
            _chkBestAligned.Checked = value
         End Set
      End Property

      Public Sub New(ByVal orgCell As MedicalViewerMultiCell, ByVal fuCell As MedicalViewerMultiCell)
         InitializeComponent()

         _orgCellImagesCount = orgCell.VirtualImage.Count
         _fuCellImagesCount = fuCell.VirtualImage.Count

         _numStart.Minimum = 1
         _numStart.Value = 1
         _numStart.Maximum = _orgCellImagesCount

         _numEnd.Minimum = 1
         _numEnd.Value = Math.Min(_orgCellImagesCount, _fuCellImagesCount)
         _numEnd.Maximum = _orgCellImagesCount

         AddHandler _numStart.ValueChanged, AddressOf _num_ValueChanged
         AddHandler _numEnd.ValueChanged, AddressOf _num_ValueChanged
      End Sub

      Protected Overrides Sub Finalize()
         RemoveHandler _numStart.ValueChanged, AddressOf _num_ValueChanged
         RemoveHandler _numEnd.ValueChanged, AddressOf _num_ValueChanged
      End Sub

      Private Sub _num_ValueChanged(ByVal sender As Object, ByVal e As EventArgs)
         Dim numberInput As NumericUpDown = CType(sender, NumericUpDown)

         If numberInput Is _numStart Then
            If numberInput.Value > _numEnd.Value Then
               numberInput.Value = _numEnd.Value
            End If
         Else
            If numberInput.Value < _numStart.Value Then
               numberInput.Value = _numStart.Value
            ElseIf numberInput.Value - _numStart.Value + 1 > Math.Min(_orgCellImagesCount, _fuCellImagesCount) Then
               numberInput.Value = Math.Min(Math.Min(_orgCellImagesCount, _fuCellImagesCount) + _numStart.Value - 1, _orgCellImagesCount)
            End If
         End If
      End Sub

      Private Sub _btnOK_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnOK.Click
         Close()
      End Sub
   End Class
End Namespace
