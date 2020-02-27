' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms

Namespace Leadtools.Demos.StorageServer
   Partial Public Class ServerNetworkingView : Inherits UserControl
#Region "Public"

#Region "Methods"

      Public Sub New()
         InitializeComponent()

         AddHandler PDUMaxLengthCheckBox.CheckedChanged, AddressOf PDUMaxLengthCheckBox_CheckedChanged

         AddHandler PDUMaxLengthCheckBox.CheckedChanged, AddressOf OnSettingsChanged
         AddHandler NoDelayCheckBox.CheckedChanged, AddressOf OnSettingsChanged
         AddHandler PDUMaxLengthNumericUpDown.ValueChanged, AddressOf OnSettingsChanged
         AddHandler ReceiveBufferNumericUpDown.ValueChanged, AddressOf OnSettingsChanged
         AddHandler SendBufferNumericUpDown.ValueChanged, AddressOf OnSettingsChanged
      End Sub

      Public Property IsMaxPduLengthChecked() As Boolean
         Get
            Return PDUMaxLengthCheckBox.Checked
         End Get

         Set(ByVal value As Boolean)
            PDUMaxLengthCheckBox.Checked = value

            PDUMaxLengthNumericUpDown.Enabled = value
         End Set
      End Property

#End Region

#Region "Properties"

      Public Property MaxPduLength() As Integer
         Get
            Return CInt(PDUMaxLengthNumericUpDown.Value)
         End Get

         Set(ByVal value As Integer)
            PDUMaxLengthNumericUpDown.Value = value
         End Set
      End Property

      Public Property ReceiveBufferSize() As Integer
         Get
            Return CInt(ReceiveBufferNumericUpDown.Value)
         End Get

         Set(ByVal value As Integer)
            ReceiveBufferNumericUpDown.Value = value
         End Set
      End Property

      Public Property SendBufferSize() As Integer
         Get
            Return CInt(SendBufferNumericUpDown.Value)
         End Get

         Set(ByVal value As Integer)
            SendBufferNumericUpDown.Value = value
         End Set
      End Property

      Public Property NoDelay() As Boolean
         Get
            Return NoDelayCheckBox.Checked
         End Get

         Set(ByVal value As Boolean)
            NoDelayCheckBox.Checked = value
         End Set
      End Property

#End Region

#Region "Data Types Definition"

#End Region

#Region "Callbacks"

      Public Event SettingsChanged As EventHandler

#End Region

#End Region

#Region "Protected"

#Region "Methods"

#End Region

#Region "Properties"

#End Region

#Region "Data Types Definition"

#End Region

#End Region

#Region "Private"

#Region "Methods"

#End Region

#Region "Properties"

#End Region

#Region "Events"

      Public Sub OnSettingsChanged(ByVal sender As Object, ByVal e As EventArgs)
         Try
            If Not Nothing Is SettingsChangedEvent Then
               RaiseEvent SettingsChanged(Me, e)
            End If
         Catch ex As Exception
            Messager.ShowError(Me, ex)
         End Try
      End Sub

      Private Sub PDUMaxLengthCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
         Try
            PDUMaxLengthNumericUpDown.Enabled = PDUMaxLengthCheckBox.Checked
         Catch ex As Exception
            Messager.ShowError(Me, ex)
         End Try
      End Sub

#End Region

#Region "Data Members"

#End Region

#Region "Data Types Definition"

#End Region

#End Region

#Region "internal"

#Region "Methods"

#End Region

#Region "Properties"

#End Region

#Region "Data Types Definition"

#End Region

#Region "Callbacks"

#End Region

#End Region
   End Class
End Namespace
