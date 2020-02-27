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
Imports System.Configuration

Imports Leadtools
Imports Leadtools.Jpip
Imports Leadtools.Jpip.Client.WinForms




   Partial Public Class ConnectionDialog : Inherits Form
      Private _defualtCacheDirectoryName As String
      Private _defaultPortNumber As Integer
      Private _defaultIPAddress As String
      Private _defaultEnumerationServicePort As Integer
      Private _defaultPacketSize As Integer
      Private _defaultRequestTimeout As TimeSpan
      Private _defaultChannelType As String

      Public Sub New()
         InitializeComponent()

         Dim channelTypeLookup As DataSet = New DataSet()
         channelTypeLookup.Tables.Add()

         channelTypeLookup.Tables(0).Columns.Add("ConnectionName", GetType(String))
         channelTypeLookup.Tables(0).Columns.Add("ConnectionType", GetType(String))

         channelTypeLookup.Tables(0).Rows.Add(New Object() {"Stateless", Global.Leadtools.Jpip.JpipChannelTypes.StatelessChannel})
         channelTypeLookup.Tables(0).Rows.Add(New Object() {"HTTP", Global.Leadtools.Jpip.JpipChannelTypes.HttpChannel})
         channelTypeLookup.Tables(0).Rows.Add(New Object() {"HTTP TCP", Global.Leadtools.Jpip.JpipChannelTypes.HttpTcpChannel})

         cmbConnectionType.DataSource = channelTypeLookup.DefaultViewManager
         cmbConnectionType.DisplayMember = channelTypeLookup.Tables(0).TableName & "." & channelTypeLookup.Tables(0).Columns(0).ColumnName
         cmbConnectionType.ValueMember = channelTypeLookup.Tables(0).TableName & "." & channelTypeLookup.Tables(0).Columns(1).ColumnName


         Dim ipAddrressMap As DataTable


         ipAddrressMap = New DataTable()

         ipAddrressMap.Columns.Add("DisplayName", GetType(String))
         ipAddrressMap.Columns.Add("Value", GetType(String))

         ipAddrressMap.Rows.Add(New Object() {"127.0.0.1 (localhost)", "127.0.0.1"})
      ipAddrressMap.Rows.Add(New Object() {"jpipserver.leadtools.com (LEAD hosted server)", "jpipserver.leadtools.com"})

         cmbIpAddress.DataSource = ipAddrressMap
         cmbIpAddress.DisplayMember = "DisplayName"
         cmbIpAddress.ValueMember = "Value"

         AddHandler cmbIpAddress.SelectionChangeCommitted, AddressOf cmbIpAddress_SelectionChangeCommitted

         Dim configReader As AppSettingsReader = New AppSettingsReader()

         Try
            _defualtCacheDirectoryName = CStr(configReader.GetValue("CacheDirectoryName", GetType(String)))
         Catch
            _defualtCacheDirectoryName = Application.StartupPath
         End Try
         Try
            _defaultPortNumber = CInt(configReader.GetValue("PortNumber", GetType(Integer)))
         Catch
            _defaultPortNumber = 49201
         End Try
         Try
            _defaultIPAddress = CStr(configReader.GetValue("IPAddress", GetType(String)))
         Catch
            _defaultIPAddress = "127.0.0.1"
         End Try
         Try
            _defaultEnumerationServicePort = CInt(configReader.GetValue("FileEnumerationPortNumber", GetType(Integer)))
         Catch
            _defaultEnumerationServicePort = 49202
         End Try
         Try
            _defaultPacketSize = CInt(configReader.GetValue("PacketSize", GetType(Integer)))
         Catch
            _defaultPacketSize = 16384
         End Try
         Try
            _defaultRequestTimeout = TimeSpan.FromSeconds((CDbl(configReader.GetValue("RequestTimeout", GetType(Double)))))
         Catch
            _defaultRequestTimeout = TimeSpan.FromSeconds(60)
         End Try
         Try
            _defaultChannelType = CStr(configReader.GetValue("ChannelType", GetType(String)))
         Catch
            _defaultChannelType = "http"
         End Try
      End Sub

      Public Property ChannelType() As String
         Set(ByVal value As String)
            cmbConnectionType.SelectedValue = value
         End Set
         Get
            Return CStr(cmbConnectionType.SelectedValue)
         End Get
      End Property

      Public Property IpAddress() As String
         Set(ByVal value As String)
            cmbIpAddress.SelectedValue = value

            If cmbIpAddress.SelectedIndex = -1 Then
               cmbIpAddress.Text = value
            End If
         End Set
         Get
            If cmbIpAddress.Text <> "" Then
               If cmbIpAddress.SelectedIndex <> -1 Then
                  Return cmbIpAddress.SelectedValue.ToString()
               Else
                  Return cmbIpAddress.Text
               End If
            Else
               Return _defaultIPAddress
            End If
         End Get
      End Property

      Public Property PortNumber() As Integer
         Set(ByVal value As Integer)
            textPortNumber.Text = value.ToString()
         End Set
         Get
            If textPortNumber.Text <> "" Then
               Return Convert.ToInt32(textPortNumber.Text)
            Else
               Return _defaultPortNumber
            End If
         End Get
      End Property

      Public Property EnumerationServicePort() As Integer
         Set(ByVal value As Integer)
            txtEnumerationServicePort.Text = value.ToString()
         End Set
         Get
            If txtEnumerationServicePort.Text <> "" Then
               Return Convert.ToInt32(txtEnumerationServicePort.Text)
            Else
               Return _defaultEnumerationServicePort
            End If
         End Get
      End Property


      Public Property PacketSize() As Integer
         Set(ByVal value As Integer)
            textPacketSize.Text = value.ToString()
         End Set
         Get
            If textPacketSize.Text <> "" Then
               Return Convert.ToInt32(textPacketSize.Text)
            Else
               Return _defaultPacketSize
            End If
         End Get
      End Property

      Public Property RequestTimeout() As TimeSpan
         Set(ByVal value As TimeSpan)
            textRequestTimeout.Text = value.TotalSeconds.ToString()

            If (value = TimeSpan.MaxValue) Then
               textRequestTimeout.Enabled = False
               chkRequestTimeout.Checked = True
            End If

         End Set
         Get
            If chkRequestTimeout.Checked Then
               Return TimeSpan.MaxValue
            ElseIf textRequestTimeout.Text <> "" Then
               Return TimeSpan.FromSeconds(Convert.ToDouble(textRequestTimeout.Text))
            Else
               Return _defaultRequestTimeout
            End If
         End Get
      End Property

      Public Property CacheDirectoryName() As String
         Set(ByVal value As String)
            textCacheDirectoryName.Text = value
         End Set
         Get
            If textCacheDirectoryName.Text <> "" Then
               Return textCacheDirectoryName.Text
            Else
               Return Nothing ' mean don't use cache file
            End If
         End Get
      End Property

      Private Sub OpenFolderDialogButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles OpenFolderDialogButton.Click
         If folderBrowserDialog.ShowDialog() = DialogResult.OK Then
            textCacheDirectoryName.Text = folderBrowserDialog.SelectedPath
         End If
      End Sub

      Private Sub btnOK_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnOK.Click
         If cmbIpAddress.Text = "" Then
            Messager.ShowError(Me, "Invaild IP Address")
            Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.Retry
            Me.DialogResult = System.Windows.Forms.DialogResult.None
            Return
         End If

         If textPortNumber.Text = "" Then
            Messager.ShowError(Me, "Invaild Port Number")
            Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.Retry
            Me.DialogResult = System.Windows.Forms.DialogResult.None
            Return
         End If

         If textPacketSize.Text = "" Then
            Messager.ShowError(Me, "Invaild Packet Size")
            Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.Retry
            Me.DialogResult = System.Windows.Forms.DialogResult.None
            Return
         End If

         If textRequestTimeout.Text = "" Then
            Messager.ShowError(Me, "Invaild Request Timeout")
            Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.Retry
            Me.DialogResult = System.Windows.Forms.DialogResult.None
            Return
         End If

         Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
      End Sub

      Private Sub btnDefault_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnDefault.Click
         cmbConnectionType.SelectedValue = _defaultChannelType
         textCacheDirectoryName.Text = _defualtCacheDirectoryName
         IpAddress = _defaultIPAddress
         textPortNumber.Text = _defaultPortNumber.ToString()
         EnumerationServicePort = _defaultEnumerationServicePort
         textPacketSize.Text = _defaultPacketSize.ToString()
         textRequestTimeout.Text = _defaultRequestTimeout.TotalSeconds.ToString()
      End Sub

      Private Sub cmbIpAddress_SelectionChangeCommitted(ByVal sender As Object, ByVal e As EventArgs)
         If cmbIpAddress.SelectedIndex = 1 Then
            textPortNumber.Text = "49201" 'this is the port for LEAD public server.
            txtEnumerationServicePort.Text = "49202" 'this is the port for LEAD public server enumeration service.
         End If
      End Sub

   Private Sub chkRequestTimeout_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkRequestTimeout.CheckedChanged
      textRequestTimeout.Enabled = Not chkRequestTimeout.Checked
   End Sub
   End Class

