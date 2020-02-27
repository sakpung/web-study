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

Imports Leadtools.Ocr

Namespace FormsDemo
    Partial Public Class AdvancedSettings : Inherits Form

        Public Sub New(ByVal compareAllPages_Renamed As Boolean, ByVal useBarcodeManager_Renamed As Boolean, ByVal useDefaultManager_Renamed As Boolean, ByVal useOCRManager_Renamed As Boolean)
            InitializeComponent()

            _compareAllPages = compareAllPages_Renamed
            _chkCompareAllPages.Checked = compareAllPages_Renamed

            _useBarcodeManager = useBarcodeManager_Renamed
            _chkBarcodeManager.Checked = useBarcodeManager_Renamed

            _useDefaultManager = useDefaultManager_Renamed
            _chkDefaultObjectManager.Checked = useDefaultManager_Renamed

            _useOCRManager = useOCRManager_Renamed
            _chkOCRManager.Checked = useOCRManager_Renamed
        End Sub

        Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
            DialogResult = DialogResult.Cancel
        End Sub

        Private Sub btnOK_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnOK.Click
            _compareAllPages = _chkCompareAllPages.Checked
            _useBarcodeManager = _chkBarcodeManager.Checked
            _useDefaultManager = _chkDefaultObjectManager.Checked
            _useOCRManager = _chkOCRManager.Checked
            DialogResult = DialogResult.OK
        End Sub

        Private _compareAllPages As Boolean
        Public Property CompareAllPages() As Boolean
            Get
                Return _compareAllPages
            End Get
            Set(ByVal value As Boolean)
                _compareAllPages = Value
            End Set
        End Property

        Private _useBarcodeManager As Boolean
        Public Property UseBarcodeManager() As Boolean
            Get
                Return _useBarcodeManager
            End Get
            Set(ByVal value As Boolean)
                _useBarcodeManager = Value
            End Set
        End Property

        Private _useDefaultManager As Boolean
        Public Property UseDefaultManager() As Boolean
            Get
                Return _useDefaultManager
            End Get
            Set(ByVal value As Boolean)
                _useDefaultManager = Value
            End Set
        End Property

        Private _useOCRManager As Boolean
        Public Property UseOCRManager() As Boolean
            Get
                Return _useOCRManager
            End Get
            Set(ByVal value As Boolean)
                _useOCRManager = Value
            End Set
        End Property
    End Class
End Namespace
