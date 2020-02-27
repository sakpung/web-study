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
Imports Leadtools.Dicom
Imports System

Namespace DicomVideoCaptureDemo.UI
   Partial Public Class EditItemDlg
      Inherits Form
      Public Property strValue() As String
         Get
            Return _txtBox_Value.Text
         End Get
         Set(ByVal value As String)
            _txtBox_Value.Text = value
         End Set
      End Property

      Public Property strVRInfo() As String
         Get
            Return _txtBox_VR_Info.Text
         End Get
         Set(ByVal value As String)
            _txtBox_VR_Info.Text = value
         End Set
      End Property

      Public m_nType As EditItemDlgEnums
      Public m_nVR As DicomVRType
      Public m_nSelected As Integer

      Public Enum EditItemDlgEnums
         INSERT_ITEM
         MODIFY_ITEM
      End Enum



      Public Sub New()
         InitializeComponent()
      End Sub

      Private Sub EnableDateCtrl(ByVal bEnable As Boolean)
         _txtBox_Value.Visible = Not bEnable
         _dateTimePicker.Visible = bEnable
      End Sub

      Private Sub _btn_OK_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btn_OK.Click
         If m_nVR = DicomVRType.DA Then
            strValue = GetDate()
         Else
            strValue = _txtBox_Value.Text
         End If

         strValue.TrimStart()
         strValue.TrimEnd()
      End Sub


      Private Function SetDate(ByVal strDate As String) As Boolean
         strDate.TrimStart()
         strDate.TrimEnd()
         If strDate.Length <> 10 Then
            Return False
         End If


         Dim szDate As Char() = strDate.ToCharArray()

         If (szDate(2) <> "/"c) OrElse (szDate(5) <> "/"c) Then
            Return False
         End If

         Dim mm As Integer, dd As Integer, yyyy As Integer
         mm = Convert.ToInt32(szDate(0)) << 1 + Convert.ToInt32(szDate(1))
         dd = Convert.ToInt32(szDate(3)) << 1 + Convert.ToInt32(szDate(4))
         yyyy = Convert.ToInt32(szDate(6)) << 3 + Convert.ToInt32(szDate(7)) << 2 + Convert.ToInt32(szDate(8)) << 1 + Convert.ToInt32(szDate(9))

         _dateTimePicker.Value = New DateTime(yyyy, mm, dd)

         Return True
      End Function

      Private Function GetDate() As String
         Dim mm As Integer, dd As Integer, yyyy As Integer
         mm = _dateTimePicker.Value.Month
         dd = _dateTimePicker.Value.Day
         yyyy = _dateTimePicker.Value.Year
         Return String.Format("{0:D2}/{1:D2}/{2:D4}", mm, dd, yyyy)
      End Function

      Private Sub EditItemDlg_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
         Select Case m_nType
            Case EditItemDlgEnums.INSERT_ITEM
               Me.Text = "Insert Item"
               Exit Select

            Case EditItemDlgEnums.MODIFY_ITEM
               Me.Text = "Modify Item"
               Exit Select
         End Select

         If m_nVR = DicomVRType.DA Then
            EnableDateCtrl(True)
            _dateTimePicker.Format = DateTimePickerFormat.[Custom]
            _dateTimePicker.CustomFormat = "MM/dd/yyy"
            SetDate(strValue)
            _dateTimePicker.Focus()
         Else
            EnableDateCtrl(False)
            _txtBox_Value.SelectionStart = 0
            _txtBox_Value.SelectionLength = _txtBox_Value.Text.Length
            _txtBox_Value.Focus()
         End If
      End Sub
   End Class
End Namespace
