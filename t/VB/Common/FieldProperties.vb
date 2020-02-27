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

Namespace FormsDemo
   Partial Public Class FieldProperties : Inherits Form
      Private _enableOcr As Boolean
      Private _enableIcr As Boolean
      Private _isNumerical As Boolean
      Private _name As String
      Private _type As ProcessingFieldType
      Private _left As Double
      Private _top As Double
      Private _width As Double
      Private _height As Double

      Public Sub New(ByVal name As String, ByVal type As ProcessingFieldType, ByVal bounds As LogicalRectangle, ByVal enableIcr_Renamed As Boolean, ByVal enableOcr_Renamed As Boolean, ByVal isNumerical_Renamed As Boolean, ByVal isICRSupported As Boolean)
         InitializeComponent()

         Me.Text = """" & name & """" & " Properties"

         If type = ProcessingFieldType.Text Then
            _methodGroup.Enabled = True
            _typeGroup.Enabled = True
            _enableOcr = enableOcr_Renamed
            _chkEnableOcr.Checked = enableOcr_Renamed

            _enableIcr = enableIcr_Renamed
            _chkEnableIcr.Checked = enableIcr_Renamed AndAlso isICRSupported

            _isNumerical = isNumerical_Renamed
            _radioTextNumerical.Checked = isNumerical_Renamed
            _radioTextCharacter.Checked = Not isNumerical_Renamed
         Else
            _methodGroup.Enabled = False
            _typeGroup.Enabled = False

            _enableOcr = True
            _chkEnableOcr.Checked = True

            _enableIcr = False
            _chkEnableIcr.Checked = False

            _isNumerical = False
            _radioTextNumerical.Checked = False
            _radioTextCharacter.Checked = True
         End If

         _chkEnableIcr.Enabled = isICRSupported

         _name = name
         _txtName.Text = name

         _type = type
         _cmbType.Text = type.ToString()

         _left = bounds.Left
         _txtLeft.Text = bounds.Left.ToString()

         _top = bounds.Top
         _txtTop.Text = bounds.Top.ToString()

         _width = bounds.Width
         _txtWidth.Text = bounds.Width.ToString()

         _height = bounds.Height
         _txtHeight.Text = bounds.Height.ToString()
      End Sub

      Private Function ConvertToProcessingFieldType(ByVal type As String) As ProcessingFieldType
         Dim returnType As ProcessingFieldType = ProcessingFieldType.None

         Select Case type
            Case "Barcode"
               returnType = ProcessingFieldType.Barcode

            Case "Image"
               returnType = ProcessingFieldType.Image

            Case "None"
               returnType = ProcessingFieldType.None

            Case "Text"
               returnType = ProcessingFieldType.Text

            Case "Omr"
               returnType = ProcessingFieldType.Omr
         End Select

         Return returnType
      End Function

      Private Sub _btnOk_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnOk.Click
         _enableOcr = _chkEnableOcr.Checked
         _enableIcr = _chkEnableIcr.Checked
         _isNumerical = _radioTextNumerical.Checked
         _name = _txtName.Text
         _type = ConvertToProcessingFieldType(_cmbType.Text)
         _left = System.Convert.ToDouble(_txtLeft.Text)
         _top = System.Convert.ToDouble(_txtTop.Text)
         _width = System.Convert.ToDouble(_txtWidth.Text)
         _height = System.Convert.ToDouble(_txtHeight.Text)
         DialogResult = System.Windows.Forms.DialogResult.OK
      End Sub

      Private Sub _btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnCancel.Click
         _chkEnableIcr.Checked = _enableIcr
         _chkEnableOcr.Checked = _enableOcr
         _radioTextNumerical.Checked = _isNumerical
         _radioTextCharacter.Checked = Not _isNumerical
         _txtName.Text = _name
         _cmbType.Text = _type.ToString()
         _txtLeft.Text = _left.ToString()
         _txtTop.Text = _top.ToString()
         _txtWidth.Text = _width.ToString()
         _txtHeight.Text = _height.ToString()
         DialogResult = DialogResult.Cancel
      End Sub

      Public ReadOnly Property EnableOcr() As Boolean
         Get
            Return _enableOcr
         End Get
      End Property

      Public ReadOnly Property EnableIcr() As Boolean
         Get
            Return _enableIcr
         End Get
      End Property

      Public ReadOnly Property IsNumerical() As Boolean
         Get
            Return _isNumerical
         End Get
      End Property

      Public ReadOnly Property FieldName() As String
         Get
            Return _name
         End Get
      End Property

      Public ReadOnly Property FieldType() As ProcessingFieldType
         Get
            Return _type
         End Get
      End Property

      Public ReadOnly Property FieldBounds() As LogicalRectangle
         Get
            Return New LogicalRectangle(_left, _top, _width, _height, LogicalUnit.Pixel)
         End Get
      End Property

      Private Sub _cmbType_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _cmbType.SelectedIndexChanged
         Try
            If _cmbType.Text.CompareTo(ProcessingFieldType.Text.ToString()) = 0 Then
               _typeGroup.Enabled = True
               _methodGroup.Enabled = True
            Else
               _methodGroup.Enabled = False
               _typeGroup.Enabled = False
            End If
         Catch exp As Exception
            Messager.ShowError(Me, exp)
         End Try
      End Sub
   End Class
End Namespace
