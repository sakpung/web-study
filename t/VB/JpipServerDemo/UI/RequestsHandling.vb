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



   Partial Public Class RequestsHandling : Inherits Form
      Private _ipAddressesList As List(Of String)
      Private _ipAddressesBinding As BindingList(Of String)

      Public Sub New()
         InitializeComponent()

         _ipAddressesList = New List(Of String)()

         AddHandler Load, AddressOf Requests_Handling_Load
      End Sub

      Public Sub New(ByVal ipAddress As String())
         Me.New()
         IpAddresses = ipAddress

         _ipAddressesList.AddRange(IpAddresses)

         _ipAddressesBinding = New BindingList(Of String)(_ipAddressesList)
      End Sub

      Private Sub Requests_Handling_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
         lstAddresses.DataSource = _ipAddressesBinding
      End Sub

      Public IpAddresses As String()

      Private Sub btnAdd_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAdd.Click
         Dim address As System.Net.IPAddress = Nothing


         If System.Net.IPAddress.TryParse(mtxtIpAddress.Text, address) Then
            _ipAddressesBinding.Add(address.ToString())
         Else
            Messager.ShowError(Me, "Invalid IP address format.")
         End If
      End Sub

      Private Sub btnRemove_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnRemove.Click
         If Not lstAddresses.SelectedItem Is Nothing Then
            _ipAddressesBinding.Remove(lstAddresses.SelectedItem.ToString())
         End If
      End Sub

      Private Sub btnOK_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnOK.Click
         IpAddresses = _ipAddressesList.ToArray()
      End Sub
   End Class
