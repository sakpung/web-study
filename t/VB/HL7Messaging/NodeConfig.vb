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
Imports System.Text.RegularExpressions
Imports System.Net
Imports Leadtools.Medical.HL7.V2x.Models
Imports System

Namespace HL7Messaging
   Partial Public Class NodeConfig
      Inherits Form
      Public Property Node() As ConnectionNode
         Get
            Return m_Node
         End Get
         Set(value As ConnectionNode)
            m_Node = Value
         End Set
      End Property
      Private m_Node As ConnectionNode

      Public Sub New()
         Node = New ConnectionNode()
         InitializeComponent()
      End Sub

      Private Sub button1_Click(sender As Object, e As EventArgs) Handles button1.Click
         Me.DialogResult = DialogResult.Cancel
         Me.Close()
      End Sub

      Private Sub OnError(ex As Exception)
         MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
      End Sub

      Private Shared Function VerifyIP(str As String) As Boolean
         If String.IsNullOrEmpty(str) Then
            Return False
         End If
         Dim hst As IPHostEntry = Dns.GetHostEntry(str)
         If hst.AddressList.Length = 0 Then
            Return False
         End If
         Dim ip As IPAddress = hst.AddressList(0)

         Return True
      End Function

      Private Shared Function VerifyPort(str As String) As Boolean
         Dim port As Integer
         If Integer.TryParse(str, port) Then
            Return (port >= 0 AndAlso port <= 65535)
         End If
         Return False
      End Function

      Private Shared Function VerifyHex(hex As String) As Boolean
         Dim HexNumber As Int32
         Return Int32.TryParse(hex, System.Globalization.NumberStyles.HexNumber, Nothing, HexNumber)
      End Function

      Private Sub InitialVerify()
         If Not VerifyIP(textBox1.Text) Then
            Throw New Exception("Invalid Remote IP specified")
         End If
         If Not VerifyPort(textBox5.Text) Then
            Throw New Exception("Invalid Remote Port specified")
         End If
         If Not VerifyHex(textBox4.Text) Then
            Throw New Exception("Invalid MLP prefix specified, use only hex values")
         End If
         If Not VerifyHex(textBox9.Text) Then
            Throw New Exception("Invalid MLP suffix specified, use only hex values")
         End If
         If String.IsNullOrEmpty(textBox8.Text) Then
            Throw New Exception("Invalid Timeout specified")
         End If
      End Sub

      Private Sub button2_Click(sender As Object, e As EventArgs) Handles button2.Click
         Try
            InitialVerify()

            Node.Name = textBox10.Text
            Node.RemoteIP = textBox1.Text
            Node.RemotePort = Integer.Parse(textBox5.Text)
            Node.RemoteAppName = textBox2.Text
            Node.RemoteFacility = textBox3.Text
            Node.ClientAppName = textBox7.Text
            Node.ClientFacility = textBox6.Text
            Node.Timeout = Integer.Parse(textBox8.Text)
            Node.MessagingVersion = comboBox1.SelectedItem.ToString()
            Node.MLPPrefix = textBox4.Text
            Node.MLPSuffix = textBox9.Text
            Node.WaitForACK = checkBox1.Checked

            Me.DialogResult = DialogResult.OK
            Me.Close()
         Catch ex As System.Exception
            OnError(ex)
         End Try
      End Sub

      Private Sub BuildView()
         comboBox1.Items.Clear()
         comboBox1.Items.AddRange(HL7Package.EnumV2xVersions())
         comboBox1.SelectedIndex = comboBox1.Items.Count - 1
      End Sub

      Private Sub UpdateView()
         If Node Is Nothing Then
            Return
         End If

         textBox10.Text = Node.Name
         textBox1.Text = Node.RemoteIP
         textBox5.Text = Node.RemotePort.ToString()
         textBox2.Text = Node.RemoteAppName
         textBox3.Text = Node.RemoteFacility
         textBox7.Text = Node.ClientAppName
         textBox6.Text = Node.ClientFacility
         textBox8.Text = Node.Timeout.ToString()
         If Not String.IsNullOrEmpty(Node.MessagingVersion) Then
            comboBox1.SelectedIndex = comboBox1.Items.IndexOf(Node.MessagingVersion)
         End If
         textBox4.Text = Node.MLPPrefix
         textBox9.Text = Node.MLPSuffix
         checkBox1.Checked = Node.WaitForACK
      End Sub

      Private Sub NodeConfig_Load(sender As Object, e As EventArgs) Handles Me.Load
         BuildView()
         UpdateView()
      End Sub

      Private Sub textBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles textBox1.KeyPress

      End Sub

      Private Sub textBox5_KeyPress(sender As Object, e As KeyPressEventArgs) Handles textBox5.KeyPress
         If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> "."c Then
            e.Handled = True
         End If
      End Sub
   End Class
End Namespace
