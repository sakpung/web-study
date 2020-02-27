' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports Leadtools.Dicom

Namespace Leadtools.Demos.StorageServer.UI
   Partial Friend Class AeInfoDetails : Inherits Form
      Public Sub New()
         InitializeComponent()

         AddHandler ConfirmChangesButton.Click, AddressOf ConfirmChangesButton_Click
      End Sub

      Private Sub ConfirmChangesButton_Click(ByVal sender As Object, ByVal e As EventArgs)
         DialogResult = DialogResult.OK

         If AETitleTextBox.Text.Length = 0 OrElse AETitleTextBox.Text.Length > 16 Then
            errorProvider1.SetError(AETitleTextBox, "AE Title must be 16 characters.")

            DialogResult = DialogResult.None
         Else
            errorProvider1.SetError(AETitleTextBox, String.Empty)
         End If

         If IpAddressComboBox.Text.Length = 0 Then
            errorProvider1.SetError(IpAddressComboBox, "Enter an IP Address.")

            DialogResult = DialogResult.None
         Else
            errorProvider1.SetError(IpAddressComboBox, String.Empty)
         End If

         If PortNumericUpDown.Value = 0 Then
            errorProvider1.SetError(PortNumericUpDown, "Enter a port.")

            DialogResult = DialogResult.None
         Else
            errorProvider1.SetError(PortNumericUpDown, String.Empty)
         End If
      End Sub

      Public Sub SetIpAddressList(ByVal ipadresses As String())
         IpAddressComboBox.DataSource = ipadresses
      End Sub

      Public Property DialogTitle() As String
         Get
            Return Me.Text
         End Get

         Set(ByVal value As String)
            Me.Text = value
         End Set
      End Property

      Public Property AETitle() As String
         Get
            Return AETitleTextBox.Text
         End Get

         Set(ByVal value As String)
            AETitleTextBox.Text = value
         End Set
      End Property

      Public Property Address() As String
         Get
            Return IpAddressComboBox.Text
         End Get

         Set(ByVal value As String)
            IpAddressComboBox.Text = value
         End Set
      End Property

      Public Property Port() As Integer
         Get
            Return CInt(PortNumericUpDown.Value)
         End Get

         Set(ByVal value As Integer)
            PortNumericUpDown.Value = value
         End Set
      End Property

      Public Property Secure() As Boolean
         Get
            Return SecureCheckBox.Checked
         End Get

         Set(ByVal value As Boolean)
            SecureCheckBox.Checked = value
         End Set
      End Property

      Public Property ConfirmText() As String
         Get
            Return ConfirmChangesButton.Text
         End Get

         Set(ByVal value As String)
            ConfirmChangesButton.Text = value
         End Set
      End Property

      Public Property CanEnterIp() As Boolean
         Get
            Return (IpAddressComboBox.DropDownStyle <> ComboBoxStyle.DropDownList)
         End Get

         Set(ByVal value As Boolean)
            If (value) Then
               IpAddressComboBox.DropDownStyle = ComboBoxStyle.Simple
            Else
               IpAddressComboBox.DropDownStyle = ComboBoxStyle.DropDownList
            End If
         End Set
      End Property

   End Class
End Namespace
