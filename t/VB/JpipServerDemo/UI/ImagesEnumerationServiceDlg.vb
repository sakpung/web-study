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




   Partial Public Class ImagesEnumerationServiceDlg : Inherits Form
      Private _enumerationService As ImagesEnumerationService

      Public Sub New()
         InitializeComponent()
      End Sub

      Friend Sub New(ByVal enumerationService As ImagesEnumerationService)
         Me.New()
         _enumerationService = enumerationService

         Init()
      End Sub

      Private Sub Init()
         Try
            txtIpAddress.Text = _enumerationService.IpAddress.ToString()
            mtxtPort.Text = _enumerationService.Port.ToString()

            UpdateUIEnablesState()

            InitExtensions()

         Catch exception As Exception
            Messager.ShowError(Me, exception)
         End Try
      End Sub

      Private Sub UpdateUIEnablesState()
         grpExten.Enabled = Not _enumerationService.Running
         mtxtPort.Enabled = Not _enumerationService.Running
         btnStart.Enabled = Not _enumerationService.Running
         btnStop.Enabled = _enumerationService.Running
      End Sub


      Private Sub InitExtensions()
         DisableCheckChangedEvent()

         RemoveHandler txtExtensions.TextChanged, AddressOf txtExtensions_TextChanged

         For Each extension As String In _enumerationService.ImagesExtension
            If extension.ToLower() = chkJ2kExt.Tag.ToString() Then
               chkJ2kExt.Checked = True
            End If

            If extension.ToLower() = chkJpxExt.Tag.ToString() Then
               chkJpxExt.Checked = True
            End If

            If extension.ToLower() = chkJp2Ext.Tag.ToString() Then
               chkJp2Ext.Checked = True
            End If

            txtExtensions.Text += extension & ";"
         Next extension

         txtExtensions.Text = txtExtensions.Text.TrimEnd(";"c)

         AddHandler txtExtensions.TextChanged, AddressOf txtExtensions_TextChanged

         EnableCheckChangedEvent()
      End Sub

      Private Sub chkJ2kExt_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles chkJ2kExt.CheckedChanged
         Try
            Dim currentCheck As CheckBox


            RemoveHandler txtExtensions.TextChanged, AddressOf txtExtensions_TextChanged

            currentCheck = CType(sender, CheckBox)

            If currentCheck.Checked Then
               If (Not txtExtensions.Text.Contains(currentCheck.Tag.ToString())) Then
                  txtExtensions.Text = currentCheck.Tag.ToString() & ";" & txtExtensions.Text
               End If
            Else
               txtExtensions.Text = txtExtensions.Text.Replace(currentCheck.Tag.ToString(), String.Empty)
            End If

            txtExtensions.Text = txtExtensions.Text.Replace(";;", ";")

            txtExtensions.Text = txtExtensions.Text.Trim(";"c)

            AddHandler txtExtensions.TextChanged, AddressOf txtExtensions_TextChanged
         Catch exception As Exception
            Messager.ShowError(Me, exception)
         End Try

      End Sub

      Private Sub txtExtensions_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtExtensions.TextChanged
         DisableCheckChangedEvent()

         Dim extensions As String()
         Dim j2k As Boolean
         Dim jp2 As Boolean
         Dim jpx As Boolean


         extensions = txtExtensions.Text.Split(";"c)
         j2k = False
         jp2 = False
         jpx = False

         For Each extension As String In extensions
            If extension.ToLower() = chkJ2kExt.Tag.ToString() Then
               j2k = True
            End If

            If extension.ToLower() = chkJp2Ext.Tag.ToString() Then
               jp2 = True
            End If

            If extension.ToLower() = chkJpxExt.Tag.ToString() Then
               jpx = True
            End If
         Next extension

         chkJ2kExt.Checked = j2k
         chkJp2Ext.Checked = jp2
         chkJpxExt.Checked = jpx

         EnableCheckChangedEvent()
      End Sub

      Private Sub DisableCheckChangedEvent()
         RemoveHandler chkJpxExt.CheckedChanged, AddressOf chkJ2kExt_CheckedChanged
         RemoveHandler chkJp2Ext.CheckedChanged, AddressOf chkJ2kExt_CheckedChanged
         RemoveHandler chkJ2kExt.CheckedChanged, AddressOf chkJ2kExt_CheckedChanged

      End Sub

      Private Sub EnableCheckChangedEvent()
         AddHandler chkJpxExt.CheckedChanged, AddressOf chkJ2kExt_CheckedChanged
         AddHandler chkJp2Ext.CheckedChanged, AddressOf chkJ2kExt_CheckedChanged
         AddHandler chkJ2kExt.CheckedChanged, AddressOf chkJ2kExt_CheckedChanged
      End Sub

      Private Sub btnStart_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnStart.Click
         Try
            _enumerationService.Port = Integer.Parse(mtxtPort.Text)

            _enumerationService.ImagesExtension.Clear()

            _enumerationService.ImagesExtension.AddRange(txtExtensions.Text.Split(";"c))

            _enumerationService.Start()
         Catch exception As Exception
            Messager.ShowError(Me, exception)
         End Try
      End Sub

      Private Sub btnStop_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnStop.Click
         Try
            _enumerationService.Stop()
         Catch exception As Exception
            Messager.ShowError(Me, exception)
         End Try
      End Sub

      Private Sub btnOK_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnOK.Click
         Me.Close()
      End Sub

      Private Sub ImagesEnumerationServiceDlg_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

         AddHandler _enumerationService.ServiceStarted, AddressOf _enumerationService_ServiceStarted
         AddHandler _enumerationService.ServiceStoped, AddressOf _enumerationService_ServiceStoped
      End Sub

      Private Sub ImagesEnumerationServiceDlg_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
         RemoveHandler _enumerationService.ServiceStarted, AddressOf _enumerationService_ServiceStarted
         RemoveHandler _enumerationService.ServiceStoped, AddressOf _enumerationService_ServiceStoped
      End Sub
      Private Sub _enumerationService_ServiceStoped(ByVal sender As Object, ByVal e As EventArgs)

         UpdateUIEnablesState()
      End Sub

      Private Sub _enumerationService_ServiceStarted(ByVal sender As Object, ByVal e As EventArgs)
         txtIpAddress.Text = _enumerationService.IpAddress.ToString()
         UpdateUIEnablesState()
      End Sub

   End Class
