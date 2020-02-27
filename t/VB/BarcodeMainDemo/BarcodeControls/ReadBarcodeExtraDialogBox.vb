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

Partial Public Class ReadBarcodeExtraDialogBox : Inherits Form
    Private _useAllSymbologies As Boolean
    Public Property UseAllSymbologies() As Boolean
        Get
            Return _useAllSymbologies
        End Get
        Set(value As Boolean)
            _useAllSymbologies = value
        End Set
    End Property

    Private _useBothDirections As Boolean
    Public Property UseBothDirections() As Boolean
        Get
            Return _useBothDirections
        End Get
        Set(value As Boolean)
            _useBothDirections = value
        End Set
    End Property

    Private _useDoublePass As Boolean
    Public Property UseDoublePass() As Boolean
        Get
            Return _useDoublePass
        End Get
        Set(value As Boolean)
            _useDoublePass = value
        End Set
    End Property

    Private _usePreprocessing As Boolean
    Public Property UsePreprocessing() As Boolean
        Get
            Return _usePreprocessing
        End Get
        Set(value As Boolean)
            _usePreprocessing = value
        End Set
    End Property

    Public Sub New()
        InitializeComponent()
    End Sub

    Protected Overrides Sub OnLoad(ByVal e As EventArgs)
        If (Not DesignMode) Then
            _allSymbologiesCheckBox.Checked = UseAllSymbologies
            _directionCheckBox.Checked = UseBothDirections
            _doublePassCheckBox.Checked = UseDoublePass
            _imagePreprocessingCheckBox.Checked = UsePreprocessing
        End If

        MyBase.OnLoad(e)
    End Sub

    Private Sub _okButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _okButton.Click
        UseAllSymbologies = _allSymbologiesCheckBox.Checked
        UseBothDirections = _directionCheckBox.Checked
        UseDoublePass = _doublePassCheckBox.Checked
        UsePreprocessing = _imagePreprocessingCheckBox.Checked
    End Sub
End Class
